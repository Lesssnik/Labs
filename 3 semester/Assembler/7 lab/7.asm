.model tiny
.code
.startup
.386
jmp real_start  ;на начало программы
	installed dw 8888 ;будем потом проверят,установлена прога или нет
	old_int9h_offset dw ?
	old_int9h_segment dw ?
	Button1 db 0
	Button2 db 0
	Button3 db 0
	Button4 db 0
	Button5 db 0	
	Button6 db 0
	Button7 db 0 
	Button8 db 0
	Button9 db 0
	Button0 db 0
	ButtonCtrl db 0
	ButtonAlt db 0
	temp db ' ','$'
	TextButton1 db 13,10,'1 : $'
	TextButton2 db 13,10,'2 : $'
	TextButton3 db 13,10,'3 : $'
	TextButton4 db 13,10,'4 : $'
	TextButton5 db 13,10,'5 : $'
	TextButton6 db 13,10,'6 : $'
	TextButton7 db 13,10,'7 : $'
	TextButton8 db 13,10,'8 : $'
	TextButton9 db 13,10,'9 : $'
	TextButton0 db 13,10,'0 : $'
	TextButtonCtrl db 13,10,'Ctrl : $'
	TextButtonAlt db 13,10,'Alt : $'
	NextString db 13,10,'$'
	
		
; Выяснить, почему все делает два раза?
new_int9h proc far 
    pusha
    push es
    push ds
    push cs
    pop ds
    pushf

    mov bx,0
    mov dx,0
 
    call dword ptr cs:[old_int9h_offset]
    IN AL,60h  
	
	CMP AL, 2h
	JE button_1
	CMP AL, 3h
	JE button_2
	CMP AL, 4h
	JE button_3
	CMP AL, 5h
	JE button_4
	CMP AL, 6h
	JE button_5
	CMP AL, 7h
	JE button_6
	CMP AL, 8h
	JE button_7
	CMP AL, 9h
	JE button_8
	CMP AL, 0ah
	JE button_9
	CMP AL, 0bh
	JE button_0
	CMP AL, 1dh 
	JE button_Ctrl
	CMP AL, 38h 
	JE button_Alt
	CMP AL, 3bh 
	JE button_F1
	CMP AL, 3ch 
	JE button_F2
	JMP quit
button_1:
	INC Button1
	JMP quit
button_2:
	INC Button2
	JMP quit
button_3:
	INC Button3
	JMP quit
button_4:
	INC Button4
	JMP quit
button_5:
	INC Button5
	JMP quit
button_6:
	INC Button6
	JMP quit
button_7:
	INC Button7
	JMP quit
button_8:
	INC Button8
	JMP quit
button_9:
	INC Button9
	JMP quit
button_0:
	INC Button0
	JMP quit
button_Ctrl:
	INC ButtonCtrl
	JMP quit
button_Alt:
	INC ButtonAlt
	JMP quit
button_F1: ;Переделать вывод чисел (чтобы выводило любой длины)
	MOV AH, 9h
	MOV DX, offset TextButton1
	int 21h
	MOV BL, Button1
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton2
	int 21h
	MOV BL, Button2
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton3
	int 21h
	MOV BL, Button3
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton4
	int 21h
	MOV BL, Button4
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton5
	int 21h
	MOV BL, Button5
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton6
	int 21h
	MOV BL, Button6
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton7
	int 21h
	MOV BL, Button7
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton8
	int 21h
	MOV BL, Button8
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton9
	int 21h
	MOV BL, Button9
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButton0
	int 21h
	MOV BL, Button0
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButtonCtrl
	int 21h
	MOV BL, ButtonCtrl
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset TextButtonAlt
	int 21h
	MOV BL, ButtonAlt
	ADD BL, '0'
	MOV [temp], BL
	MOV DX, offset temp
	int 21h
	MOV DX, offset NextString
	int 21h
	JMP quit
button_F2:
	MOV Button1, 	0
	MOV Button2, 	0
	MOV Button3, 	0
	MOV Button4, 	0
	MOV Button5, 	0
	MOV Button6, 	0
	MOV Button7, 	0
	MOV Button8, 	0
	MOV Button9, 	0
	MOV Button0,    0
	MOV ButtonCtrl, 0
	MOV ButtonAlt,  0
	MOV AH, 9h
	MOV DX, offset clear_msg
	int 21h
	MOV DX, offset NextString
	int 21h
	JMP quit

quit:
	pop ds
    pop es
    popa
    iret
new_int9h endp  

real_start:                                                     ; старт основной программы
    mov ax,3509h                                    ; получить в ES:BX вектор 09
    int 21h                                                 ; прерывания
    cmp word ptr es:installed,8888  ; проверка того, загружена ли уже программа
    je remove                                               ; если загружена - выгружаем
    push es
    mov ax, ds:[2Ch]                                ; psp
    mov es, ax
    mov ah, 49h                                             ; хватит памяти чтоб остаться
    int 21h                                                 ; резидентом?
    pop es
    jc not_mem                                              ; не хватило - выходим
    mov cs:old_int9h_offset, bx             ; запомним старый адрес 09
    mov cs:old_int9h_segment, es            ; прерывания
    mov ax, 2509h                                   ; установим вектор на 09
    mov dx, offset new_int9h                        ; прерывание
    int 21h
    mov dx, offset ok_installed             ; выводим что все ок
    mov ah, 9
    int 21h
    mov dx, offset real_start               ; остаемся в памяти резидентом
    int 27h                                                 ; и выходим
    ; конец основной программы      
remove:                                                         ; выгрузка программы из памяти
	push es
	push ds
	mov dx, es:old_int9h_offset             ; возвращаем вектор прерывания
	mov ds, es:old_int9h_segment            ; на место
	mov ax, 2509h
	int 21h
	pop ds
	pop es
	mov ah, 49h                                     ; освобождаем память
	int 21h
	jc not_remove                                   ; не освободилась - ошибка
	mov dx, offset removed_msg              ; все хорошо
	mov ah, 9
	int 21h
	jmp exit                                                ; выходим из программы
not_remove:                                                     ; ошибка с высвобождением памяти.
	mov dx, offset noremove_msg                                             
	mov ah, 9
	int 21h
	jmp exit
not_mem:                                                        ; не хватает памяти, чтобы остаться резидентом
	mov dx, offset nomem_msg
	mov ah, 9
	int 21h
exit:                                                           ; выход
	int 20h
ok_installed db 'Installed$'
nomem_msg db 'Out of memory$'
removed_msg db 'Uninstalled$'
noremove_msg db 'Error: cannot unload program$'
clear_msg db 'Information cleared$'
end