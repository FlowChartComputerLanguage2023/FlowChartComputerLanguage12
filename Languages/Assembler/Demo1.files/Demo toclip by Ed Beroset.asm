; toclip.asm
;
; written on 10 June 1998 by Edward J. Beroset
; cleaned up and posted on Sat  08-25-2001
;
; This code may be assembled and linked using Borland's TASM:
;   tasm /la /m2 toclip
;   tlink /Tdc toclip
;
; It also works with Microsoft's MASM:
;   ml /Fl toclip.asm
;
STDIN                   equ     00h     ; handle of standard input device
STDOUT                  equ     01h     ; handle of standard output device
STDERR                  equ     02h     ; handle of standard error device

DOS_READ_HANDLE         equ     03fh    ; read from handle
DOS_WRITE_HANDLE        equ     040h    ; write to handle
DOS_ALLOC_MEM           equ     048h    ; allocate memory block
DOS_RESIZE_MEM          equ     04ah    ; resize memory block
DOS_TERMINATE           equ     04ch    ; terminate with error code

WIN_VERSION             equ     01700h  ; identify WinOldAp version
WIN_OPEN_CLIP           equ     01701h  ; open clipboard
WIN_EMPTY_CLIP          equ     01702h  ; empty clipboard
WIN_SET_CLIP            equ     01703h  ; set clipboard data
WIN_CLOSE_CLIP          equ     01708h  ; close clipboard

; clipboard formats:
CLIP_FMT_TXT            equ     01h     ; text format
CLIP_FMT_BMP            equ     02h     ; bitmap format
CLIP_FMT_TIFF           equ     06h     ; TIFF
CLIP_FMT_OEMTXT         equ     07h     ; OEM text


WININT macro function
        mov ax,(function)
        int 2fh
endm

DOSINT macro function, subfunction
        IFB <subfunction>
                mov     ah,(function AND 0ffh)
        ELSE
                mov     ax,(function SHL 8) OR (subfunction AND 0ffh)
        ENDIF
        int     21h                     ; invoke DOS function
endm

ERRMSG macro tag, message
        LOCAL nextmsg
tag     db nextmsg-$
        db message
nextmsg = $
endm

        .model small
        .386
        .stack 100h
        .data
ERRMSG cantresize, <"ERROR: can't resize memory",0dh,0ah>
ERRMSG noclipboard,<"ERROR: no clipboard",0dh,0ah>
ERRMSG emptyclip,  <"ERROR: cannot empty clipboard",0dh,0ah>
ERRMSG openclip,   <"ERROR: cannot open clipboard",0dh,0ah>
ERRMSG allocerror, <"ERROR: can't allocate 64K buffer",0dh,0ah>
ERRMSG readerr,    <"ERROR: can't read data from stdin",0dh, 0ah>
ERRMSG pasteerr,   <"ERROR: can't paste data to clipboard",0dh,0ah>

        .code
start proc
        mov bx,ss               ;   stack segment
        mov ax,ds               ; -  data segment
        sub bx,ax               ; = size of all but stack
        add bx,10h              ; add in stack size (in paragraphs)
        DOSINT DOS_RESIZE_MEM   ;
        mov di,offset cantresize
        jc  error
        WININT WIN_VERSION
        cmp ax,WIN_VERSION
        mov di,offset noclipboard
        jz  error               ;

        WININT WIN_OPEN_CLIP    ; open clipboard
        or  ax,ax               ; nonzero status means error
        mov di,offset openclip
        jz  error               ;

        WININT WIN_EMPTY_CLIP   ; empty clipboard
        or  ax,ax               ; nonzero status means error
        mov di,offset emptyclip
        jz  error               ;

        ; allocate a big buffer
        mov bx,1000h            ; 1000h paragraphs = 64K
        DOSINT DOS_ALLOC_MEM    ;
        mov di,offset allocerror
        jc  error               ;


        mov ds,ax               ;
        mov es,ax               ;
        ; read from the input file
        mov bx,STDIN            ; stdin
        mov cx,0ffffh           ; read a whole bunch of data
;        ds:dx ==> data buffer
        xor dx,dx               ;
        DOSINT DOS_READ_HANDLE  ;
        mov di,offset readerr
        jc  error               ;
        xor si,si               ;
        mov cx,ax               ; size

        ; paste the file buffer into the clipboard
;       mov es:bx ==> data
        xor bx,bx
;       mov si:cx, size of data
        mov dx,CLIP_FMT_TXT     ; text data
        WININT WIN_SET_CLIP     ;
        or  ax,ax
        mov di,offset pasteerr  ;
        jz  error               ;
        WININT WIN_CLOSE_CLIP   ; close clipboard
        DOSINT DOS_TERMINATE,0  ; exit with error code = 0
error:
        mov bx,@data            ;
        mov ds,bx               ;
        xor cx,cx               ;
        mov cl,byte ptr[di]     ; fetch length
        mov dx,di               ; point to data
        inc dx                  ; advance beyond length
        mov bx,STDERR           ; write to stderr
        DOSINT DOS_WRITE_HANDLE ; write to handle
        DOSINT DOS_TERMINATE,1  ; error exit
start endp
        END start
