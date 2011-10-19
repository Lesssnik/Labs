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
   DIV BL  ;Делим на 5
   
   cmp AH, null
   je without ;Если число делится без остатка, переходим по метке
   
   MOV AL, AH   ;Помещяем в ответ остаток от деления
   MOV AH, null   
   JMP close
   
without:
   MOV AL, a
   MOV BL, two
   DIV BL  ;Проверяем на четность
   
   cmp AH, null
   JNE number_odd   ;Если число нечетное, переходим по метке
   
   MOV DL, d
   MOV AL, d
   MUL DL
   MOV DL, AL ;Получаем d^2
   
   MOV CL, c
   MOV AL, c
   MUL CL
   MUL CL ;Получаем c^3
   
   sub AL, DL ;Заносим в AX c^3-d^2
   JMP close
   
number_odd:   
   MOV CL, c
   MOV AL, c
   MUL CL
   MUL CL    ;Заносим в AX c^3
   
close:
   MOV AH, 4CH
   int 21h
end start