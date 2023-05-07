ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ;  limit stays in effect, giving "flat real mode." " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ;  limit stays in effect, giving "flat real mode." " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         .model tiny
jmp ^$^ 
ComeFromLastLine ^$^ : 
         .model tiny
jmp ^$^ 
ComeFromLastLine ^$^ : 
         .code
jmp ^$^ 
ComeFromLastLine ^$^ : 
         .code
jmp ^$^ 
ComeFromLastLine ^$^ : 
         .code
jmp ^$^ 
ComeFromLastLine ^$^ : 
 DESC386 STRUC
jmp ^$^ 
ComeFromLastLine ^$^ : 
 DESC386 STRUC
jmp ^$^ 
ComeFromLastLine ^$^ : 
         limlo   dw      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
         limlo   dw      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
         limlo   dw      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
         basemid db      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
         basemid db      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
         dpltype db      ?       ; " ; p(1) dpl(2) s(1) type(4) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         dpltype db      ?       ; " ; p(1) dpl(2) s(1) type(4) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         dpltype db      ?       ; " ; p(1) dpl(2) s(1) type(4) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         basemid db      ?
jmp ^$^ 
ComeFromLastLine ^$^ : 
 DESC386 ENDS
jmp ^$^ 
ComeFromLastLine ^$^ : 
 DESC386 ENDS
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ORG 100h
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ORG 100h
jmp ^$^ 
ComeFromLastLine ^$^ : 
 start:
jmp ^$^ 
ComeFromLastLine ^$^ : 
 start:
jmp ^$^ 
ComeFromLastLine ^$^ : 
         call  flatmode          ; " ; go into flat real mode (fs reg only) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         call  flatmode          ; " ; go into flat real mode (fs reg only) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         call  flatmode          ; " ; go into flat real mode (fs reg only) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         int 21h                 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         int 21h                 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen proc
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen proc
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ifdef BEROSET
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ifdef BEROSET
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 else
jmp ^$^ 
ComeFromLastLine ^$^ : 
 else
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     di,0b800h       ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     di,0b800h       ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     di,0b800h       ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         xor     edi,edi         ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         xor     edi,edi         ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 endif
jmp ^$^ 
ComeFromLastLine ^$^ : 
 endif
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 start:
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     al,fs:[esi]     ; " ; read ROM byte " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     al,fs:[esi]     ; " ; read ROM byte " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ifdef BEROSET
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     fs:[edi],ax     ; " ; store to screen with attribute " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     fs:[edi],ax     ; " ; store to screen with attribute " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 else
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     fs:[edi],ax     ; " ; store to screen with attribute " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 endif
jmp ^$^ 
ComeFromLastLine ^$^ : 
         inc     esi             ; " ; increment source ptr " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         inc     esi             ; " ; increment source ptr " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         inc     esi             ; " ; increment source ptr " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         inc     edi             ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         inc     edi             ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         loop    myloop          ; " ; keep going " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         loop    myloop          ; " ; keep going " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ret                     ; " ; and quit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ret                     ; " ; and quit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen endp
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen endp
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen proc
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         xor     edx,edx         ; " ; clear edx " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         xor     edx,edx         ; " ; clear edx " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         xor     edx,edx         ; " ; clear edx " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     dx,ds           ; " ; get the data segment " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     dx,ds           ; " ; get the data segment " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         shl     edx,4           ; " ; shift it over a bit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         shl     edx,4           ; " ; shift it over a bit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         add     dword ptr [gdt+2],edx   ; " ; store as GDT linear base addr " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         add     dword ptr [gdt+2],edx   ; " ; store as GDT linear base addr " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ; " ; flatmode.asm " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         lgdt    fword ptr gdt   ; " ; load GDT base (286-style 24-bit load) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         lgdt    fword ptr gdt   ; " ; load GDT base (286-style 24-bit load) " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     bx,1 * size DESC386 ; " ; point to first descriptor " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov     bx,1 * size DESC386 ; " ; point to first descriptor " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         or      al,1            ; " ; flip the PE bit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         or      al,1            ; " ; flip the PE bit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         cli                     ; " ; turn off interrupts " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         cli                     ; " ; turn off interrupts " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         and     al,0FEh         ; " ; clear the PE bit again " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         and     al,0FEh         ; " ; clear the PE bit again " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         mov ax,4c00h            ; " ; do a standard DOS exit " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         sti                     ; " ; resume handling interrupts " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         sti                     ; " ; resume handling interrupts " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ret                     ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
         ret                     ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 fillscreen endp
jmp ^$^ 
ComeFromLastLine ^$^ : 
 ;
jmp ^$^ 
ComeFromLastLine ^$^ : 
 GDT     DESC386 <GDT_END - GDT - 1, GDT, 0, 0, 0, 0>  ; " ; the GDT itself " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 GDT     DESC386 <GDT_END - GDT - 1, GDT, 0, 0, 0, 0>  ; " ; the GDT itself " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         DESC386 <0ffffh, 0, 0, 091h, 0cfh, 0>          ; " ; 4G data segment " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
         DESC386 <0ffffh, 0, 0, 091h, 0cfh, 0>          ; " ; 4G data segment " 
jmp ^$^ 
ComeFromLastLine ^$^ : 
 start:
jmp ^$^ 
ComeFromLastLine ^$^ : 
 end start
jmp ^$^ 
ComeFromLastLine ^$^ : 
 end start
jmp ^$^ 
