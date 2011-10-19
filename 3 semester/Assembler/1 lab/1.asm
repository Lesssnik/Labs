.model small
.stack 100h
.data
   a db 10
   c db 2
   d db 1
   five db 5
   two db 2
   null db 0
.code
start:
   MOV AX, @data
   MOV DS, AX

   MOV AL, a     
   MOV AH, null
   MOV BL, five
   DIV BL  ;����� �� 5
   
   cmp AH, null
   je without ;���� ����� ������� ��� �������, ��������� �� �����
   
   MOV AL, AH   ;�������� � ����� ������� �� �������
   MOV AH, null   
   JMP close
   
without:
   MOV AL, a
   MOV BL, two
   DIV BL  ;��������� �� ��������
   
   cmp AH, null
   JNE number_odd   ;���� ����� ��������, ��������� �� �����
   
   MOV DL, d
   MOV AL, d
   MUL DL
   MOV DL, AL ;�������� d^2
   
   MOV CL, c
   MOV AL, c
   MUL CL
   MUL CL ;�������� c^3
   
   sub AL, DL ;������� � AX c^3-d^2
   JMP close
   
number_odd:   
   MOV CL, c
   MOV AL, c
   MUL CL
   MUL CL    ;������� � AX c^3
   
close:
   MOV AH, 4CH
   int 21h
end start