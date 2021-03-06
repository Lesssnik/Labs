.model small
.stack 100h
.data
InputA db "Input first number: $"
InputB db "Input second number: $"
Zero db "You can`t divide by zero $"
Result1 db "A/B = : $"
Result2 db " A%B = : $"
Negative db "-$"
.code

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Input PROC ; ���������, ������� ��������� ����� � ����������

PUSH SI
PUSH BX
PUSH CX
PUSH DX
PUSHF 

XOR SI, SI ; �������� SI
XOR BX, BX ; �������� BX
XOR CX, CX ; �������� CX

MOV AH, 1 
int 21h ; �������� ������

CMP AL, '-'
JNE NumberPositive

MOV SI, 1 ; ���� ����� �������������, ��������� � SI 1, ��� ������, ��� ����� �������������...

Entering:

MOV AH, 1 
int 21h ; �������� ������

NumberPositive:

CMP AL, 13 ; Enter ��� ���
JZ EndOfInput

CMP AL, '0' ; > 0 ��� ��� 
JC Entering

CMP AL, ':' ; < : ��� ���
JNC Entering

MOV CL, AL ; �������� ��������, ���������� �� ������������ � CX

MOV AX, 10
MUL BX ; �������� ����� �� ������ 
MOV BX, AX 

SUB CX, '0' ; ����������� ������ � �����
ADD BX, CX ; ��������� ����� � �����

JMP Entering

EndOfInput:

CMP SI, 1 ; ���� ����� �������������, �������� ����
JNE ToPositive
NEG BX

ToPositive:

MOV AX, BX ; �� BX, ��� �� ������� �����, ��������� ��� � AX

POPF
POP DX
POP CX
POP BX
POP SI

RET
Input ENDP 

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Output PROC ; ������� �������� AX �� �����

PUSH AX
PUSH BX
PUSH CX
PUSH DX
PUSHF 

MOV BX, AX
SHL AX, 1
JNC ContinuePrinting ; ���� ����� �������������, ���� ������� ���� "-" � ������� NEG ��� ���� 

LEA DX, Negative
MOV AH, 9
int 21h

MOV AX, BX
NEG AX
JMP PrintingPositive

ContinuePrinting:

MOV AX, BX

PrintingPositive:

MOV BX, 10 ; ��������� � BX 10, ��� ���������� ����� �� �����
XOR CX, CX ; �������� CX

Loop1:

XOR DX, DX ; �������� DX
DIV BX ; ���������� ������� �� 10 (��������� �����)
PUSH DX ; ������� � ���� ���������� �����
INC CX ; ����������� ������� ���������� ���� �� 1

CMP AX, 0 ; ���������, ���� �� ������ ��������� �����
JNZ Loop1 

Loop2: ; ���� for, ����������� �� ����� ������

POP DX ; ������� ����� �� �����
ADD DX, '0' ; ����������� ����� � ������

MOV AH, 2 ; ����� �� DX �� �����
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

CALL Input ; ��������� ������ �����

MOV BX, AX 

LEA DX, InputB
MOV AH, 9
int 21h

CALL Input ; ��������� ������ �����

CMP AX, 0
JE NumberZero

XOR DX,DX ; �������� DX

MOV CX, BX 
MOV BX, AX
MOV AX, CX ; �������� ������� AX � BX, ����� ���������� �������

CWD
IDIV BX ; ���� �������. � AX ����� �����, � DX �������

PUSH AX ; ��������� �������� �������� � �����
MOV BX, DX ; ���������� � BX �������� ������� �� �������

LEA DX, Result1
MOV AH, 9
int 21h

POP AX 
CALL Output ; �������� �������� �������� �� �������

CMP BX, 0
JE EndOfProgram

MOV AX, BX ; ���������� � AX �������� �������
PUSH AX

LEA DX, Result2
MOV AH, 9
int 21h

POP AX
CALL Output ; �������� �������� ������� �� �������
JMP EndOfProgram

NumberZero:
	LEA DX, Zero
	MOV AH, 9
	int 21h
	
EndOfProgram:
MOV AH, 4ch ; ��������� ���������
int 21h

end start;