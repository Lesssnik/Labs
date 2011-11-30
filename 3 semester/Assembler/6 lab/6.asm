.model small
.stack 1000h
.data 
  color   		db 30 
  x       		dw 0 
  y       		dw 0 
  x0      		dw 0
  y0      		dw 0 
  x1      		dw ? 
  y1      		dw ? 
  delta   		dw 0 
  error   		dw 0 
  error2  		dw ? 
  delta_x 		dw ? 
  delta_y 		dw ? 
  sign_x  		dw ?
  sign_y  		dw ? 
  k_hx    		dw 1 
  k_hy    		dw 1
  k_wx    		dw 1
  k_wy    		dw 1
  nx      		dw ?
  ny      		dw ?
  radius        dw 0 
  standard_mode db ? 
.code
.486

;��������� ����������� �����
init_graph_mode proc
    
  mov AH, 0fh
  int 10h
  mov standard_mode, AL

  mov AH, 0
  mov AL, 13h
  int 10h

  ret
init_graph_mode endp

;��������������� ����������� �����
close_graph_mode proc

  mov AH, 0
  mov AL, standard_mode
  int 10h

  ret
close_graph_mode endp

;������ �����
draw_point proc
  pop BP
  mov AH, 0ch
  mov BH, 0h
  mov AL, color
  pop DX
  pop CX
  
  int 10h
  push BP
  ret
draw_point endp

;������ ���� �� ���� ������ � �������
draw_circle proc

  ;� ����� ������, � ��� 0
  mov x, 0
  mov AX, radius
  mov y, AX

  ;����������� ��������� ����� (������� delta = 2 - 2*R
  mov delta, 2
  shl AX, 1
  sub delta, AX
  mov error, 0

  circle_step:
    ;��������� ������, ����� ��� ������ ����
    mov AX, y
    cmp AX, 0
    jnge end_circledraw
    
    ;���������� �����������
    mov AX, x
    imul k_hx
    cwd
    idiv k_wx
    mov nx, AX ;� nx ���������� x
    mov AX, y
    imul k_hy
    cwd
    idiv k_hx
    mov ny, AX ;� ny ���������� y

; ������ ������ ����� ����������

    mov AX, x0
    add AX, nx
    push AX
    mov AX, y0
    add AX, ny
    push AX
    call draw_point    
    
    mov AX, x0
    sub AX, nx
    push AX
    mov AX, y0
    add AX, ny
    push AX
    call draw_point
    
    mov AX, x0
    add AX, nx
    push AX
    mov AX, y0
    sub AX, ny
    push AX  
    call draw_point
  
    mov AX, x0
    sub AX, nx
    push AX
    mov AX, y0
    sub AX, ny
    push AX
    call draw_point 

	;��������� error �� ������� error = 2 * (delta + y) - 1
    mov AX, delta
    mov error, AX
    mov AX, y
    add error, AX
    shl error, 1
    dec error
 
    cmp error, 0
    jg circle_check2
    cmp delta, 0
    jge circle_check2

	;��������� delta �� ������� delta += 2 * (++x) + 1
    inc x
    mov BX, x
    shl BX, 1
    inc BX
    add delta, BX
    jmp circle_step

    circle_check2:

	;���������  error �� ������� error = 2 * (delta - x) - 1
    mov AX, delta
    mov error, AX
    mov AX, x
    sub error, AX
    shl error, 1
    dec error

    cmp error, 0
    jle circle_endcycle
    cmp delta, 0
    jle circle_endcycle
    
    ;��������� delta �� ������� delta += 1 - 2 * (--y)
    dec y
    mov BX, y
    shl BX, 1
    mov AX, 1
    sub AX, BX
    add delta, AX
    jmp circle_step
    
    circle_endcycle:

	;����������� x
    inc x
	;��������� delta �� ������� delta += 2 * (x - y)
    mov BX, x
    sub BX, y
    shl BX, 1
    add delta, BX
	;��������� y
    dec y
    jmp circle_step
       
  end_circledraw:
  ret
draw_circle endp

;������ �����
absP proc
  pop BP
  pop AX
  
  cmp AX, 0
  jge end_abs
  neg AX
  
  end_abs:
  push AX
  push BP
  ret
absP endp

;������ �����
sign proc
  pop BP

  pop AX
  cmp AX, 0
  jge sign_above
  mov AX, -1
  jmp end_sign
  
  sign_above:
  mov AX, 1
  
  end_sign:
  push AX
  push BP
  ret
sign endp

;��������� ����� �� ���� ������
draw_line proc

  ;�������� ������ ���������� x
  mov AX, x1
  sub AX, x0
  push AX
  call absP
  pop delta_x

  ;�������� ������ ���������� y
  mov BX, y1
  sub BX, y0
  push BX
  call absP
  pop delta_y

  ;������ �����������
  push AX
  call sign
  pop sign_x

  push BX
  call sign
  pop sign_y

  ;��������� error �� ������� error = delta_x - delta_y
  mov AX, delta_x
  sub AX, delta_y
  mov error, AX

;��������� �����
  line_step:
    ;������ �����
    push x0
    push y0
    call draw_point

    ;���������, �� ����� �� �� �� �����
    mov AX, x0
    cmp AX, x1
    jne continue_line
    mov AX, y0
    cmp AX, y1
    jne continue_line

    jmp exit_line
    
    continue_line:
	  ;��������� error2 �� ������� error2 = error * 2
      mov AX, error
      shl AX, 1
      mov error2, AX	
      
	  ;���� error2 > -delta_y
	  ;�� ��������� error -= delta_y
	  ;x0 += sign_x
      mov AX, delta_y
      neg AX
      cmp error2, AX
      jng check_line2
      mov AX, delta_y
      sub error, AX
      mov AX, sign_x
      add x0, AX
	  
      check_line2:
        ;���� error2 < delta_x
	    ;�� ��������� error += delta_x
	    ;y0 += sign_y
        mov AX, delta_x
        cmp error2, AX
        jnl line_step
        mov AX, delta_x
        add error, AX
        mov AX, sign_y
        add y0, AX
        
	jmp line_step

    exit_line:
      ret
draw_line endp

main:
  mov AX, @data
  mov DS, AX

  call init_graph_mode

  mov color, 30
  
;������ ��� (���������)
  mov x0, 160
  mov y0, 158
  mov radius, 40
  call draw_circle

;������� ���
  mov x0, 160
  mov y0, 88
  mov radius, 30
  call draw_circle

;������� ��� (������) 
  mov x0, 160
  mov y0, 38
  mov radius, 20
  call draw_circle

mov color, 150

;������ ����
  mov x0, 155
  mov y0, 30
  mov radius, 2
  call draw_circle

mov color, 120

;����� ����
  mov x0, 170
  mov y0, 30
  mov radius, 2
  call draw_circle

mov color, 25

;��������� �����
  mov x0, 160
  mov y0, 20
  mov radius, 5
  mov k_hx, 2
  mov k_hy, 1
  mov k_wx, 1
  mov k_wy, 1
  call draw_circle

;������� ��������� �����
  mov x0, 160
  mov y0, 5
  mov radius, 3
  mov k_hx, 2
  mov k_hy, 1
  mov k_wx, 1
  mov k_wy, 1
  call draw_circle

;����� ������� ������ �����
  mov x0, 147
  mov y0, 20
  mov x1, 150
  mov y1, 5
  call draw_line

;������ ������� ������ �����
  mov x0, 170
  mov y0, 5
  mov x1, 173
  mov y1, 20
  call draw_line

mov color, 160

;������ ����
  mov x0, 192
  mov y0, 88
  mov x1, 230
  mov y1, 108
  call draw_line

;����� ����
  mov x0, 92
  mov y0, 68
  mov x1, 128
  mov y1, 88
  call draw_line

mov color, 40

;���
  mov x0, 165
  mov y0, 35
  mov x1, 175
  mov y1, 45
  call draw_line
  mov x0, 160
  mov y0, 35
  mov x1, 175
  mov y1, 45
  call draw_line

mov color, 160

;�������
  mov x0, 230
  mov y0, 200
  mov x1, 230
  mov y1, 60
  call draw_line
  mov x0, 231
  mov y0, 200
  mov x1, 231
  mov y1, 60
  call draw_line
  mov x0, 232
  mov y0, 200
  mov x1, 232
  mov y1, 60
  call draw_line
  
mov color, 30  
  
;�����������
  mov x0, 200
  mov y0, 60
  mov x1, 264
  mov y1, 60
  call draw_line
  mov x0, 200
  mov y0, 10
  mov x1, 200
  mov y1, 60
  call draw_line
  mov x0, 264
  mov y0, 10
  mov x1, 264
  mov y1, 60
  call draw_line
  mov x0, 200
  mov y0, 10
  mov x1, 264
  mov y1, 10
  call draw_line
  mov x0, 225
  mov y0, 10
  mov x1, 230
  mov y1, 40
  call draw_line
  mov x0, 235
  mov y0, 40
  mov x1, 240
  mov y1, 10
  call draw_line
  mov x0, 230
  mov y0, 40
  mov x1, 235
  mov y1, 40
  call draw_line
  
  mov AH, 01h
  int 21h

  call close_graph_mode

  mov AH, 4ch
  int 21h	

end main