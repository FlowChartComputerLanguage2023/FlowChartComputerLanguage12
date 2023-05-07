; test1.asm
;
;  This program uses flat real mode to read the contents of arbitrary
;  memory locations to the screen.  It assumes that flat real mode (4G
;  limit) is already in place for the FS segment.
;
;  This code is intended to be run on a Pentium or better.
;
;  To assemble:
;
; using Microsoft's MASM 6.11 or better
;   ml /Fl flatmode.asm
;
; or Borland's TASM version 4.0 or better
;   tasm /la /m2 flatmode.asm
;   tlink /Tdc flatmode
;
; written on Wed  12-17-1997  by Ed Beroset and
;   donated to the public domain by the author
;
;----------------------------------------------------------------------
        .model tiny
        .code
        .586P

;----------------------------------------------------------------------
        ORG 100h
start:
        call  fillscreen        ; fill the screen using 4G descriptor
        mov ax,4c00h            ; do a standard DOS exit
        int 21h                 ;
;----------------------------------------------------------------------
fillscreen proc
        mov     esi,0FFFFFF70h     ; point to ROM
        mov     edi,0B8000h     ; point to screen
        mov     cx,160          ; just two lines
        mov     ah,1Eh          ; yellow on blue screen attrib
myloop:
        mov     al,fs:[esi]     ; read ROM byte
        mov     fs:[edi],ax     ; store to screen with attribute
        inc     esi             ; increment source ptr
        inc     edi             ; increment dest ptr by two
        inc     edi             ;
        loop    myloop          ; keep going
        ret                     ; and quit
fillscreen endp
end start
