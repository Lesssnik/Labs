.model small
.stack 100h
.data
InputA db "Input first number: $"
InputB db "Input second number: $"
Zero db "You can`t divide by zero $"
Result1 db "A/B = : $"
Result2 db " A%B = : $"
.code

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Input PROC ; Процедура, корорая считывает число с клавиатуры

PUSH BX
PUSH CX
PUSH DX
PUSHF 

XOR BX, BX ; Обнулили BX
XOR CX, CX ; Обнулили CX

Entering:

MOV AH, 1 
int 21h ; Получили символ

CMP AL, 13 ; Enter или нет
JZ EndOfInput

CMP AL, '0' ; > 0 или нет 
JC Entering

CMP AL, ':' ; < : или нет
JNC Entering

MOV CL, AL ; Сохраним значение, полученное от пользователя в CX

MOV AX, 10
MUL BX ; Умножаем число на десять 
MOV BX, AX 

SUB CX, '0' ; Преобразуем символ в цифру
ADD BX, CX ; Добавляем цифру в число

JMP Entering

EndOfInput:

MOV AX, BX ; Из BX, где мы собрали число, переносим его в AX

POPF
POP DX
POP CX
POP BX

RET
Input ENDP 

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Output PROC ; Выводит значение AX на экран

PUSH AX
PUSH BX
PUSH CX
PUSH DX
PUSHF 

MOV BX, 10 ; Переносим в BX 10, для разделения числа на части
XOR CX, CX ; Обнуляем CX

Loop1:

XOR DX, DX ; Обнулили DX
DIV BX ; Производим деление на 10 (разделяем число)
PUSH DX ; Заносим в стек выделенную часть
INC CX ; Увеличиваем счетчик количества цифр на 1

CMP AX, 0 ; Проверяем, надо ли дальше разделять число
JNZ Loop1 

Loop2: ; Цикл for, выполняется по числу частей

POP DX ; Достаем число из стека
ADD DX, '0' ; Преобразуем число в символ

MOV AH, 2 ; Вывод из DX на экран
int 21h 

LOOP Loop2

POPF 
POP DX
POP CX
POP BX
POP AX

RET
Output ENDP

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
start:

MOV AX, @DATA
MOV DS, AX

LEA DX, InputA
MOV AH, 9
int 21h

CALL Input ; Запросили первое число
MOV BX, AX 

LEA DX, InputB
MOV AH, 9
int 21h

CALL Input ; Запросили второе число

CMP AX, 0
JE NumberZero

XOR DX,DX ; Обнуляем DX

MOV CX, BX 
MOV BX, AX
MOV AX, CX ; Поменяли местами AX и BX, чтобы произвести деление

DIV BX ; Само деление. В AX будет целое, в DX остаток

PUSH AX ; Сохраняем значение частного в стеке
MOV BX, DX ; Перемещаем в BX значение остатка от деления

LEA DX, Result1
MOV AH, 9
int 21h

POP AX 
CALL Output ; Печатаем значение частного от деления

CMP BX, 0
JE EndOfProgram

MOV AX, BX ; Перемещаем в AX значение остатка
PUSH AX

LEA DX, Result2
MOV AH, 9
int 21h

POP AX
CALL Output ; Печатаем значение остатка от деления
JMP EndOfProgram

NumberZero:
	LEA DX, Zero
	MOV AH, 9
	int 21h
	
EndOfProgram:
MOV AH, 4ch ; Окончание программы
int 21h

end start;