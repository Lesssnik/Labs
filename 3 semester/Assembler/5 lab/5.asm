.model small
.386
.stack 1000h
.data
DataFileName db "INPUT.txt", 0
AnswerFileName db "OUTPUT.txt", 0
BufferLength db 255
Buffer db 255 dup(0)
TempBuffer db ?
Solution_fd db ?
WriteTemp db 10 dup(0)
End_line db 13, 10
Space db " "

arr db 255 dup (0)
m db ?
n db ?
temp db ?
.code

;Чтение матрицы из файла
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ReadFromFile PROC
PUSHA

;Открываем файл, расположенный по пути, прописанному в DataFileName
MOV AH, 3Dh
MOV AL, 00000010b
LEA DX, DataFileName
MOV CL, 00000000b 			
int 21h						

;Считываем информацию из файла
MOV BX, AX					
MOV AH, 3Fh
MOV CL, BufferLength
LEA DX, Buffer
int 21h

XOR AX, AX
XOR SI, SI
XOR BX, BX
XOR CX, CX
XOR DI, DI

;Считываем число строк и столбцов матрицы
MOV AL, buffer[SI]
SUB AL, '0'
MOV n, AL
INC SI
INC SI
MOV AL, buffer[SI]
SUB AL, '0'
MOV m, AL
INC SI
INC SI
INC SI

;Цикл считывания матрицы
read_start:
    ;Считываем строки
	CMP BL, m
    JAE read_next_step
	
	;Считываем число из строки
	CALL ReadNumber
	;Заносим число в массив
	MOV arr[DI], AL
	INC SI
	INC BX
	INC DI
	JMP read_start
	read_next_step:
	    ;Считываем столбцы
		INC CX
	    CMP CL, n
		JAE read_finish
		INC SI
		XOR BX, BX
		JMP read_start
		
read_finish:
MOV AH, 3Eh
int 21h

POPA
RET
ReadFromFile ENDP
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;Чтение числа из буфера
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ReadNumber PROC
PUSHF
PUSH BX
PUSH CX
PUSH DX

XOR AX, AX		
XOR CH, CH		
MOV BX, 10
XOR DL, DL

ReadNumber_WhileLoop:	
;Помещаем в CL число
MOV CL, buffer[SI]
;Пробел?
CMP CL, ' '		
JZ ReadNumber_BreakWhileLoop
;Перевод строки?
CMP CL, 13
JZ ReadNumber_BreakWhileLoop
;0?
CMP CL, 0
JZ ReadNumber_BreakWhileLoop
	;Магические пассы с числом
	PUSH DX
	MUL BX	
	POP DX
	SUB CX, '0'		
	ADD AX, CX
	INC SI	
	JMP ReadNumber_WhileLoop	

ReadNumber_BreakWhileLoop:
POP DX
POP CX
POP BX
POPF
RET
ReadNumber ENDP
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;Запись матрицы в файл
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
WriteToFile PROC
PUSHA

;Открываем файл для записи, путь к которому прописан по AnswerFileName
MOV AH, 3Ch
MOV AL, 00000010b
LEA DX, AnswerFileName 
XOR CX, CX
int 21h
MOV Solution_fd, AL

XOR SI, SI
XOR BX, BX
XOR DI, DI

;Записываем количество строк и столбцов
ADD n, '0'
ADD m, '0'
MOV BL, Solution_fd
XOR CX, CX
MOV CL, 1
MOV DX, offset n
MOV AH, 40h
int 21h
MOV DX, offset Space
MOV AH, 40h
int 21h
MOV DX, offset m
MOV AH, 40h
int 21h
MOV CL, 2
MOV DX, offset End_line
MOV AH, 40h
int 21h

SUB n, '0'
SUB m, '0'
XOR SI, SI
XOR BX, BX
XOR DI, DI

;Записываем матрицу
Start_write_file:
MOV CX, SI
CMP CL, n
JAE End_of_write_file

CMP BL, m
JAE Temp_end_of_write_file

CALL WriteNumber

PUSH BX
MOV BL, Solution_fd
XOR CX, CX
MOV CL, 1
MOV DX, offset Space
MOV AH, 40h
int 21h
POP BX
INC BX
JMP Start_write_file

Temp_end_of_write_file:
INC SI	

MOV BL, Solution_fd
XOR CX, CX
MOV CL, 2
MOV DX, offset End_line
MOV AH, 40h
int 21h

XOR BX, BX
JMP Start_write_file

End_of_write_file:
MOV AH, 3Eh
int 21h

POPA
RET
WriteToFile ENDP
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;Чтение числа из буфера
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
WriteNumber PROC
PUSHF
PUSH AX
PUSH CX
PUSH DX
PUSH DI

XOR AX, AX		
XOR CX, CX		
XOR DI, DI
XOR DX, DX

PUSH SI
MOV AL, m
MUL SI
MOV SI, AX
MOV CL, arr[SI][BX]
POP SI

Write_Div_Loop:
PUSH AX
MOV AX, CX
XOR DX, DX
MOV CX, 10
DIV CX
MOV CX, AX
POP AX
CMP CL, 0
JE Write_Print_Loop

MOV WriteTemp[DI], DL
INC DI
JMP Write_Div_Loop

Write_Print_Loop:
MOV WriteTemp[DI], DL

PUSH BX
Write_Print_Number_Loop:
MOV BX, 0
DEC BX
CMP DI, BX
JE Write_End_Print_Loop

MOV CL, WriteTemp[DI]
ADD Cl, '0'
MOV TempBuffer, CL
XOR BX, BX
MOV BL, Solution_fd
XOR CX, CX
MOV CL, 1
MOV DX, offset TempBuffer
MOV AH, 40h
int 21h
DEC DI
JMP Write_Print_Number_Loop

Write_End_Print_Loop:
POP BX
POP DI
POP DX
POP CX
POP AX
POPF
RET
WriteNumber ENDP
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;Преобразование диагоналей выше главной
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
TransformUpper PROC
	PUSH DX
	PUSH DI
	PUSH SI
	PUSH CX
	PUSH BX
	PUSH AX

	MOV AL, n
	CMP AL, 1
	JE upper_special_matrix
	MOV AL, m
	CMP AL, 1
	JE upper_special_matrix
	
	XOR AX, AX 
	XOR DX, DX 
	XOR CX, CX 
	XOR BX, BX 
	XOR SI, SI 
	XOR DI, DI
	
	upper_start_testing:
	PUSH BX
	
	MOV CL, arr[SI][BX]
	MOV temp, CL
	
	upper_continue_transforming:
	MOV DI, SI
	INC SI
	INC BX
	
	MOV DL, n
	CMP SI, DX
	JAE upper_temp_finish_testing
	
	MOV DL, m
	CMP BX, DX
	JAE upper_temp_finish_testing

	upper_continue_testing:
		PUSH SI
		MOV AL, m
		MUL SI
		MOV SI, AX
		MOV CL, arr[SI][BX]
		
		MOV SI, DI
		DEC BX
		MOV AL, m
		MUL SI
		MOV SI, AX
		MOV arr[SI][BX], CL
		
		POP SI
		INC BX
		JMP upper_continue_transforming
		
	upper_temp_finish_testing:
		DEC BX
		DEC SI
		MOV AL, m
		MUL SI
		MOV SI, AX
		MOV AL, temp
		MOV arr[SI][BX], AL
		
		POP BX
		XOR SI, SI
		INC BX 
		MOV AL, m
		CMP BX, AX
		JNAE upper_start_testing

	upper_special_matrix:
	POP AX
	POP BX
	POP CX
	POP SI
	POP DI
	POP DX
	RET
ENDP TransformUpper
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;Преобразование диагоналей ниже главной
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
TransformLower PROC
	PUSH DX
	PUSH DI
	PUSH SI
	PUSH CX
	PUSH BX
	PUSH AX

	MOV AL, n
	CMP AL, 1
	JE lower_special_matrix_temp
	MOV AL, m
	CMP AL, 1
	JE lower_special_matrix_temp
	
	XOR AX, AX
	XOR DX, DX 
	XOR CX, CX 
	XOR BX, BX 
	XOR SI, SI 
	XOR DI, DI
	
	INC SI
	
	lower_start_testing:
	PUSH SI
	
	PUSH SI
	MOV AL, n  
	DEC AL     
	SUB AX, SI
	
	MOV BL, m
	DEC BL
	CMP AX, BX
	JNA lower_smaller
	MOV AL, m
	DEC AX
	lower_smaller:
	MOV BX, AX 
	
	MOV AX, BX
	ADD SI, BX
	MOV AL, m
	MUL SI
	MOV SI, AX
		
		
	MOV CL, arr[SI][BX]
	MOV temp, CL
	POP SI
	
	PUSH SI
		XOR BX, BX
		MOV AL, m
		MUL SI
		MOV SI, AX
		MOV AL, temp
		MOV CL, arr[SI][BX]
		MOV arr[SI][BX], AL
	POP SI
	JMP lower_continue_transforming
	
	lower_special_matrix_temp:
	JMP lower_special_matrix
	
	lower_continue_transforming:
	INC SI
	INC BX
	
	MOV DL, n
	CMP SI, DX
	JAE lower_temp_finish_testing
	
	MOV DL, m
	CMP BX, DX
	JA lower_temp_finish_testing

	lower_continue_testing:
		PUSH SI
		
		MOV AL, m
		MUL SI
		MOV SI, AX
		MOV AL, CL
		MOV CL, arr[SI][BX]
		MOV arr[SI][BX], AL
		
		POP SI
		JMP lower_continue_transforming
		
	lower_temp_finish_testing:
		POP SI
		XOR BX, BX
		INC SI
		MOV AL, n
		CMP SI, AX
		JNE lower_start_testing
		
	lower_special_matrix:
	POP AX
	POP BX
	POP CX
	POP SI
	POP DI
	POP DX
	RET
ENDP TransformLower
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

start:
   MOV AX, @data
   MOV DS, AX

   CALL ReadFromFile
   CALL TransformUpper
   CALL TransformLower
   CALL WriteToFile
   
   MOV AH, 4CH
   int 21h
end start