.model small
.stack 100h
.386
.data
inputstr db "Please, input string: $"
test_gl db "aeiouyAEIOUY$"
buffer_string db 256 dup(?) 
words db 256 dup(0)
syllables db 256 dup(0)
result db 256 dup(0)
temp_1 db 256 dup(0)
temp_2 db 256 dup(0)
temp_3 db 256 dup(0)
clear_helper db 256 dup(0)
.code
ASSUME ds:@data, es:@data
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ReadString PROC ;Процедура ввода строки
	POP BP ;Берем текущую положение стека
	XOR BX, BX ;Обнуляем BX (BX будет счетчиком длины строки)

	read_str: 
	    mov AH, 01h
		int 21h ;Запрашиваем символ

		CMP AL, 13 ;Проверяем, является ли введенный символ Enter
		JE end_read_str ;Если ввели Enter, заканчиваем ввод строки
		;Желательно вставить проверку на то, является ли символ буквой
		
		CMP BX, 255 ;Проверяем, не превышает ли длина строки максимальную
		JNL end_read_str ;Если строка длиннее максимума, заканчиваем ее ввод

		MOV [buffer_string + BX], AL ;Копируем символ в строку
		INC BX ;Увеличиваем длину строки на 1
		JMP read_str ;Продолжаем ввод строки

	end_read_str:
	
	MOV [buffer_string + BX], '$' ;Вставляем в конец строки символ $ чтобы можно было вывести строку
	PUSH BX
	PUSH BP
	RET
ENDP ReadString
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
StringToWords PROC ;Процедура, разделяющая строку на слова
	PUSH AX
	PUSH BX
	PUSH CX
	PUSH DX
	PUSH SI
	PUSH DI
	PUSHF
	
	XOR AX, AX ;В AX будет очередной символ из строки
	MOV BX, 0 ;Позиция в массиве
	MOV DL, 0 ;Длина слова
	MOV DI, 0 ;Длина строки
	@1_for_loop:
		MOV AL, buffer_string[DI]
			
		CMP AL, '$'
		JE end_of_for_loop
		
		CMP AL, ' '
		JE @1_for_loop_continue
		
		MOV words[BX], AL
		INC BX
		INC DL
		INC DI
		JMP @1_for_loop
		
		@1_for_loop_continue:
		MOV words[BX], '$'
		CALL WordToSyllables ;Разделяем слово на слога
		CALL ClearWord ;Очищаем, чтобы засунуть следующее слово
		XOR BX, BX
		INC DI
		JMP @1_for_loop
	end_of_for_loop:
	MOV words[BX], '$'
	CALL WordToSyllables ;Разделяем слово на слога
	POPF
	POP DI
	POP SI
	POP DX
	POP CX
	POP BX
	POP AX
	RET
ENDP StringToWords
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
WordToSyllables PROC ;Процедура, разделяющая слова на слога
	PUSH AX
	PUSH BX
	PUSH CX
	PUSH DX
	PUSH SI
	PUSH DI
	PUSHF
	
	XOR BX, BX 
	XOR DI, DI ;Итератор, по которому считается длина слова
	XOR SI, SI ;Индикатор гласности/согласности
	
	@1_word_loop:
		CMP words[DI], '$'
		JE @1_word_loop_continue
		@2_word_loop:
			MOV AL, words[DI]
			
			CMP AL, '$'
			JE @1_word_loop_continue
			
			CMP SI, 1    
			JNE not_vowel
			
			CALL IsVowel ;Проверяем, гласная ли буква
			CMP SI, 1
			JE not_vowel
		
			MOV syllables[BX], ' '
			INC BX
			JMP not_vowel
	
		@1_word_loop_continue:
		
		MOV syllables[BX], '$'
		CALL PrintResult
		
		JMP end_of_word_loop
		
	not_vowel:
		MOV syllables[BX], AL
		INC BX
		INC DI
		CALL IsVowel
		JMP @2_word_loop
		
	end_of_word_loop:
	
	POPF
	POP DI
	POP SI
	POP DX
	POP CX
	POP BX
	POP AX
	RET
ENDP WordToSyllables
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
IsVowel PROC ;Процедура, которая проверяет, гласная ли буква (буква в AL)
	PUSH CX
	PUSH DI
	
	XOR SI, SI
	CLD
	LEA DI, test_gl
	MOV CX, 12
REPNE SCAS test_gl
	JNE finish_vowel
	MOV SI, 1
	finish_vowel:
	POP DI
	POP CX
	RET
ENDP IsVowel
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ClearWord PROC ;Процедура, очищающая words
	PUSH DI
	PUSH SI
	PUSH CX
	CLD
	MOV DI, 0
	LEA SI, clear_helper
	LEA DI, words
	MOV CX, 256
REP MOVS words, clear_helper
	POP CX
	POP SI
	POP DI
	RET
ENDP ClearWord
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
PrintResult PROC ;Процедура, которая выводит измененное слово
	PUSH DI
	PUSH SI
	PUSH CX
	PUSH AX
	PUSH DX
	
	XOR AX, AX
	XOR DI, DI
	XOR BX, BX
	XOR DX, DX
	XOR CX, CX
	
	print_loop:
		MOV AL, syllables[DI]
		
		CMP AL, '$'
		JE print_last_step
		
		CMP AL, ' '
		JE print_whitespace
		
		MOV temp_1[BX], AL
		INC BX
		INC DI
		
		JMP print_loop
	
	print_whitespace:	
		
		CALL Temp3ToTemp2
		CALL ClearTemp3		
		CALL Temp1ToTemp3
		CALL ClearTemp1
		
	XOR BX, BX
	INC DI	
	JMP print_loop
	
	print_last_step:
		;Проверяем, последняя буква гласная или согласная
		;Если гласная, то схема temp_1->temp_2->temp_2
		;Если согласная, то схема temp_3->temp_1->temp_2
		DEC DI
		MOV AL, syllables[DI]
		XOR DI, DI
		CALL IsVowel
		CMP SI, 1
		JE print_when_vowel 
		
		CALL Temp3ToResult
		CALL Temp1ToResult
		CALL Temp2ToResult
		JMP finishing
		
	print_when_vowel:
		CALL Temp1ToResult
		CALL Temp2ToResult
		CALL Temp3ToResult
		
	finishing:
	MOV result[DI], ' '
	INC DI
	MOV result[DI], '$'
	LEA DX, result
	MOV AH, 9h
	int 21h
	
	CALL ClearTemp1
	CALL ClearTemp2
	CALL ClearTemp3
	
	POP DX
	POP AX
	POP CX
	POP SI
	POP DI
	RET
ENDP PrintResult 
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Temp3ToTemp2 PROC ;temp_3 в temp_2
	PUSH SI
	PUSH DI
	PUSH AX
	XOR DI, DI
	XOR AX, AX
	temp_3_to_temp_2:
		MOV AL, temp_3[DI]
		CMP AL, 0
		JE end_of_temp_3_to_temp_2
		MOV SI, DX
		MOV temp_2[SI], AL
		INC DI
		INC DX
		JMP temp_3_to_temp_2
	end_of_temp_3_to_temp_2:
	POP AX
	POP DI
	POP SI
	RET
ENDP Temp3ToTemp2
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ClearTemp3 PROC ;Процедура, очищающая temp_3
	PUSH DI
	PUSH SI
	PUSH CX
	CLD
	MOV DI, 0
	LEA SI, clear_helper
	LEA DI, temp_3
	MOV CX, 256
REP MOVS words, clear_helper
	POP CX
	POP SI
	POP DI
	RET
ENDP ClearTemp3
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Temp1ToTemp3 PROC ;temp_1 в temp_3
	PUSH DI
	PUSH AX
	XOR DI, DI
	XOR AX, AX
	temp_1_to_temp_3:
		MOV AL, temp_1[DI]
		CMP AL, 0
		JE end_of_temp_1_to_temp_3
		MOV temp_3[DI], AL
		INC DI
		JMP temp_1_to_temp_3	
	end_of_temp_1_to_temp_3:
	POP AX
	POP DI
	RET
ENDP Temp1ToTemp3
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ClearTemp1 PROC ;Процедура, очищающая temp_1
	PUSH DI
	PUSH SI
	PUSH CX
	CLD
	MOV DI, 0
	LEA SI, clear_helper
	LEA DI, temp_1
	MOV CX, 256
REP MOVS words, clear_helper
	POP CX
	POP SI
	POP DI
	RET
ENDP ClearTemp1
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ClearTemp2 PROC ;Процедура, очищающая temp_1
	PUSH DI
	PUSH SI
	PUSH CX
	CLD
	MOV DI, 0
	LEA SI, clear_helper
	LEA DI, temp_2
	MOV CX, 256
REP MOVS words, clear_helper
	POP CX
	POP SI
	POP DI
	RET
ENDP ClearTemp2
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Temp1ToResult PROC ;temp_1 в result
	PUSH SI
	PUSH AX
	XOR SI, SI
	XOR AX, AX
	temp_1_to_result:
		MOV AL, temp_1[SI]
		CMP AL, 0
		JE end_of_temp_1_to_result
		MOV result[DI], AL
		INC SI
		INC DI
		JMP temp_1_to_result
	end_of_temp_1_to_result:
	POP AX
	POP SI
	RET	
ENDP Temp1ToResult
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Temp2ToResult PROC ;temp_2 в result
PUSH SI
	PUSH AX
	XOR SI, SI
	XOR AX, AX
	temp_2_to_result:
		MOV AL, temp_2[SI]
		CMP AL, 0
		JE end_of_temp_2_to_result
		MOV result[DI], AL
		INC SI
		INC DI
		JMP temp_2_to_result
	end_of_temp_2_to_result:
	POP AX
	POP SI
	RET
ENDP Temp2ToResult
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Temp3ToResult PROC ;temp_3 в result
PUSH SI
	PUSH AX
	XOR SI, SI
	XOR AX, AX
	temp_3_to_result:
		MOV AL, temp_3[SI]
		CMP AL, 0
		JE end_of_temp_3_to_result
		MOV result[DI], AL
		INC SI
		INC DI
		JMP temp_3_to_result
	end_of_temp_3_to_result:
	POP AX
	POP SI
	RET
ENDP Temp3ToResult
;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
start:

MOV AX, @DATA
MOV DS, AX
MOV ES, AX

LEA DX, inputstr
MOV AH, 9h
int 21h
CALL ReadString

CALL StringToWords

MOV AH, 4ch ; Окончание программы
int 21h
end start;