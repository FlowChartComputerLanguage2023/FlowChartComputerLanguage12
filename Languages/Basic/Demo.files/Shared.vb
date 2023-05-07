


'OptionScreen.ComboBoxRotation
Option Strict On
Option Infer Off
Option Compare Text
Option Explicit On


Namespace MyFlowChartNameSpace
    Public Class F_C
        Public Const ShowScreen As Int32 = 1 '1 means to show this form
        Public Const HideScreen As Int32 = 0 '0 means to hide this form 
        Public Const LeaveScreenAlone As Int32 = -1 ' -1 means to not do anything


        ' Turn Faster to Yes to make it faster
        '#Const Faster = "No"
        ' Turn Faster to No to make it slower
        '#Const Faster = "Yes"
        '#Const NotUsed = "No"

        Public Shared TimerCounter As Int32 ' This is only for the timers routines to know to go to the next symbol/path

        Public Shared MyErrorList() As String = {
        "1001 Symbol does not have a /point CameFrom",
        "1002 Symbol does not have a /point GotoNextLine",
        "1003 Symbol goes to two or more places (A symbol can come from many places, but can only goto one place)",
        "1004 Points of a symbol is not connected to any path",
        "1005 Paths are not connected to any symbol or constant - they must all connect to both ends to symbol or another path, or a constant",
        "1006 Not all of the point names are in the syntax",
        "1007 That the syntax matches the program text.",
        "1008 Make sure that the point names are in the point list",
        "1009 All paths must have at least one output or constant",
        "1010 All Points have a valid Datatype",
        "1011 All Datatype have a valid Color",
        "1012 All Colors are valid (in microsoft, they can only be the assigned colors, and are 'switched if wrong)",
        "1013 All /point names are in either the ProgramText or the Syntax",
        "1014 No Duplicate /point names",
        "1015 No Syntax and No Program Code to make it from"
            }


        Public Const constantALLFILES As Int32 = 256
        Public Const constantALLTables As Int32 = 256
        Public Const ConstantCharterLength As Int32 = 16000


        Public Const MyConstantIgnoreFunctionOperatorsKeywords As String = "zzzzzzzzz"

        Public Const FD As String = ","
        '|~!@%^&*()_-+={[}]\:;'<,>.?/   'Available special characters for make symntax between two  rmstart & myuniverse.sysgen.rmEnd

        ' So That I can remember which is which constants
        Public Const constantCOME_FROM As Int32 = 1
        Public Const constantGOTOS As Int32 = 0
        Public Const constantBufferSizeBeforeChangingSizeOfArray As Int32 = 64
        Public Const constantMyErrorCode As Int32 = -1

        'space (U+0020), line feed (U+000A), carriage return (U+000D), horizontal tab (U+0009), vertical tab (U+000B), form feed (U+000C) and null (U+0000).
        'Public Const ConstantWhiteSpace As String = " " & vbLf & vbCr & Strings.Chr(9) & Strings.Chr(11) & Strings.Chr(12) '& Strings.Chr(0)
        Public Const ConstantWhiteSpace As String = " " & vbLf & vbCr & Strings.Chr(9) & vbVerticalTab & vbFormFeed & vbCrLf

        Public Const ConstantDelimeters As String = ConstantWhiteSpace & FD & ",=" ' White Space
        'Public Const ConstantDirectionMap As String = " " &
        'vbCrLf & "14_15__16__01_02" &
        'vbCrLf & "13__\__|___/__03" &
        'vbCrLf & "12-----0------04" &
        'vbCrLf & "11__/__|___\__05" &
        'vbCrLf & "10_09__08__07_06"

        '        Public Const ConstantExplainCompared As String = vbCrLf & "Compare Results " & vbCrLf & "  -2 Top of the list" & vbCrLf & "  -1 Less than" & vbCrLf & "   0 they match" & vbCrLf & "   1 greater than" & vbCrLf & "   2 bottom of the list"
        'Public Const ConstantExplainedCompared3 As String = vbCrLf & "." & vbCrLf & "." & vbCrLf &
        '    "      0 if the middle is null" & vbCrLf &
        '    "      0 if first = third are null" & vbCrLf &
        '    "then -1 if .{[(string1)]}. = .{[(string2)]}." & vbCrLf &
        '    "then  1 if .{[(string2)]}. = .{[(string3)]}." & vbCrLf &
        '    "then -4 if .{[(string1)]}. = Null & .{[(string2)]}. < .{[(string3)]}." & vbCrLf &
        '    "then  4 if .{[(string3)]}. = Null And .{[(string2)]}. > .{[(string1)]}." & vbCrLf &
        '    "then -4 if .{[(string1)]}. = ''" & vbCrLf &
        '    "then  4 if .{[(string3)]}. = ''" & vbCrLf &
        '    "then -5 if .{[(string1)]}. > .{[(string3)]}. (error in list)" & vbCrLf &
        '    "then  0 if .{[(string1)]}. < .{[(string2)]}. & .{[(string2)]}. < .{[(string3)]}." & vbCrLf &
        '    "then -3 if .{[(string1)]}. > .{[(string2)]}." & vbCrLf &
        '    "then -2 if .{[(string2)]}. > .{[(string3)]}." & vbCrLf &
        '    "then  3 if .{[(string2)]}. < .{[(string3)]}." & vbCrLf &
        '    "then  2 if .{[(string1)]}. > .{[(string2)]}." & vbCrLf &
        '    "then  5 if none of the above(Error in logic)"


        'because there are 436 routines
        Public Shared TraceWords(436) As String 'hack
        Public Shared TraceCounts(436) As Int64 'hack
        Public Shared TraceNumberOfLines(436) As Int32 'hack


        Public Shared Language_KeyWords(1) As String ' 2020/6/22 Changing to require from input file
        Public Shared Language_Functions(1) As String ' 2020/6/22 Changing to require from input file
        Public Shared Language_Operators(1) As String ' 2020/6/22 Changing to require from input file


        Public Shared My_KeyWords(32) As String
        Public Const My_KeyConstUnknown As Int32 = 0
        Public Const My_KeyConstUnKnownError As Int32 = 1
        Public Const My_KeyConstName As Int32 = 2
        Public Const My_KeyConstPoint As Int32 = 3
        Public Const My_KeyConstLine As Int32 = 4
        Public Const My_KeyConstUse As Int32 = 5
        Public Const My_KeyConstPath As Int32 = 6
        Public Const My_KeyConstDataType As Int32 = 7
        Public Const My_KeyConstFileName As Int32 = 8
        Public Const My_KeyConstVersion As Int32 = 9
        Public Const My_KeyConstAuthor As Int32 = 10
        Public Const My_KeyConstLanguage As Int32 = 11
        Public Const My_KeyConstStroke As Int32 = 12
        Public Const My_KeyConstError As Int32 = 13
        Public Const My_KeyConstDelete As Int32 = 14
        Public Const My_KeyConstConstant As Int32 = 15
        Public Const My_KeyConstX1 As Int32 = 16
        Public Const My_KeyConstY1 As Int32 = 17
        Public Const My_KeyConstX2 As Int32 = 18
        Public Const My_KeyConstY2 As Int32 = 19
        Public Const My_KeyConstColor As Int32 = 20
        Public Const My_KeyConstprogramtext As Int32 = 21
        Public Const My_KeyConstNotes As Int32 = 22
        Public Const My_KeyConstOpcode As Int32 = 23
        Public Const My_KeyConstThisCode As Int32 = 24
        Public Const My_KeyConstOption As Int32 = 25
        Public Const My_KeyConstSyntax As Int32 = 26
        Public Const My_KeyConstLanguageKeyWord As Int32 = 27
        'Public Const My_KeyConstUnused28 as int32 = 28
        'Public Const My_KeyConstUnused29 as int32 = 29
        'Public Const My_KeyConstUnused30 as int32 = 30
        'Public Const My_KeyConstUnused31 as int32 = 31
        'Public Const My_KeyConstUnused32 as int32 = 32





        ' See init () for the assignmane because what is allowed is sometimes defined by what is in a combobox list
        Public Shared formatLanguage As String ' "/Language=language, ---> optional --> (case Sensitive Yes,No),(inline comment),(filename Extension),(between Statements on one line),(Last character to continue next line),(Characters in variable names besides a-z,A-Z, 0-9),(Goto " & rmstart & "GoToNextLine" & myuniverse.sysgen.rmEnd & "),(CameFrom " & rmstart & "Camefromlastline" & myuniverse.sysgen.rmEnd & " ),(reserved),(reserved)
        Public Shared formatColor As String ' "/Color=Color Name" & FD & " Alpha" & FD & " Red" & FD & " Green" & FD & " Blue" & FD & " Style" & FD & " StartCap" & FD & " EndCap"
        Public Shared formatDatatype As String ' "/datatype=datatypename" & FD & " Number Of Bytes" & FD & " Color Name" & FD & " Color Width" & FD & " Describtion"
        Public Shared formatSymbolName As String ' "/Name=Symbol Name" & FD & " options"
        Public Shared formatPoint As String ' "/Point = X" & FD & " Y" & FD & " {Input/Output...}" & FD & " Data Type" & FD & " Name"
        Public Shared formatLine As String ' "/Line=x1" & FD & " y1" & FD & " x2" & FD & " y2" & FD & " Color"
        Public Shared formatNameOfFile As String ' "/FileName=Device:/Path/FileName.Extension"
        Public Shared formatStroke As String ' "/Stroke={}"
        Public Shared formatNotes As String ' "/Notes={}"
        Public Shared formatVersion As String ' "/Version={}"
        Public Shared formatAuthor As String ' "/Author={}"
        Public Shared formatOpcode As String ' "/OpCode={}"
        Public Shared formatPath As String ' "/Path=Name" & FD & " x1" & FD & " y1" & FD & " x2" & FD & " y2" & FD & " Data type"
        Public Shared formatUse As String ' "/Use=Name" & FD & " X" & FD & " Y" & FD & " rotation" & FD & " future dynamic options"
        Public Shared formatConstant As String ' "/Constant=name " & FD & " X" & FD & " Y" & FD & " Value"
        Public Shared formatProgramText As String ' "/programtext= Text [replacements] text ..."
        Public Shared FormatOption As String ' "/Option=number" & FD & "{on or off}  or /Option as string 'ComputerLanguage"
        Public Shared FormatError As String '"/error  as string ' Code" & FD & " name" & FD & " x1" & FD & " y1" & FD & " Name " & FD & " {other things maybe}"
        Public Shared FormatDelete As String '"/Delete ..."
        Public Shared FormatThisCode As String ' "/ThisCode added to /path or /constant "
        Public Shared FormatLanguage_KeyWord As String ' "/Keyword=ReservedWord"
        Public Shared FormatLanguage_Function As String ' "/function=FunctionWord"
        Public Shared FormatLanguage_operator As String ' "/Operator=operator"
        Public Shared FormatSyntaxKeyWord As String ' "/Syntax={keyword" & FD & "special characters" & FD & rmstart & "variable" & myuniverse.sysgen.rmEnd & " " & FD & rmstart & "quote" & myuniverse.sysgen.rmEnd & FD & rmstart & "number" & myuniverse.sysgen.rmEnd & FD & "Alphabetics" & FD & " and so on}"
        Public Shared FormatSet_ As String

        '1-8 is unusable
        '9- (  MyUniverse.SysGen.Constantfirstlanguage-1) is options
        '( constantfirstlanguage to constantlastlanguage )is for computer languages that is build into for special rules (as yet unknown)
        '  (  MyUniverse.SysGen.Constantlastlanguage +1 to 9999 is for messages (msgbox, and just sending to the text status .text box)
        Public Shared MyMessageBits(1250) As Byte ' 1250 givess exactly 10,000 bit settings for yes or no

        ' not used?  Public Shared FastFlipFlop(4, 14) As Short

        '
        '        'Fliping instruction X=XX+XY, Y=YX+YY   to flip X=-1+0, Y=0+1 (see The first 0 of each for the default non Flipable example)
        '0=defalut, 1=flip, 2=flop, 3=Rotate90, 4=Rotate180, 5=Rotate270
        ' Flip=sidways, Flop=top2bottom, 
        'Matrix
        '0  1  2  3  4  5     6    7    8    9   10   11
        '1  -1 1  0  1  0
        '0  0  0  1  0  -1
        '0  0  0  -1 -1 1
        '1  1  -1 0  0  0





        Public Structure MyPointStructure
            Dim X As Int32
            Dim Y As Int32
        End Structure


        Public Structure MyLineStructure
            Dim a As MyPointStructure
            Dim b As MyPointStructure
        End Structure

        Structure MyRECTStructure
            Public MyTablesXY As MyLineStructure            'Used for real world XY
            Public MyInputScreenXY As MyLineStructure       'Used for the screen XY
        End Structure


        Public Structure MyScreenInfoStructure
            Dim MouseStatus As String
            Dim MouseStroke As String
            Dim MyScreen As MyLineStructure
            Dim PaintThisOrEraseThis As Boolean
        End Structure

        Public Structure MyDisplayStructure
            Dim X As Int32
            Dim Y As Int32
            Dim Color As Brush
        End Structure

        Public Structure SystemStuffStructure

            Public NumberOfButtonsActive As Int32
            Public HighestSymbolNumber As Int32
            Public MySnap As Int32
            Public MinBox As Int32  'Min Size of box to select all
            Public MyScale As Double
            Public Size As MyPointStructure
            Public ReSize As Int16 ' Used as a flag to not let resize call it's self recursively (987 vs anything else)
            Public DontAskToAdd As Boolean
            Public MaxSymbolInYSpacing As Int32
            Public UseX1 As Int32
            Public UseY1 As Int32
            Public outputfilename1 As String
            Public outputfilename2 As String
            Public outputfilename3 As String
            Public RMStart As String
            Public RMEnd As String


            Public ConstantQuote As String
            Public ConstantQuotes As String
            Public ConstantVariable As String
            Public ConstantNumber As String
            Public ConstantAlpha As String
            Public ConstantSpecialCharacter As String
            Public ConstantGoToNextLineSyntax As String
            Public ConstantCameFromLastLineSyntax As String
            Public ConstantComment As String
            Public SyntaxFormats() As String
            Public constantSymbolCenter As Int32
            Public constantSpacingFactor As Int32
            Public constantMinPenSize As Int32
            Public constantMaxPenSize As Int32
            Public constantMinBoxSize As Int32
            Public constantFirstLineTextOffset As Int32
            Public constantSecondLineTextOffset As Int32
            Public constantDistanceBetweenControls As Int32
            Public constantRecordsBeforeSaveIsAllowed As Int32
            Public constantDistanceToMovePaths As Int32
            Public ConstantSpecialCharacters As String

        End Structure


        Structure InternalStructure
            Public SelectedObject As Int32
            Public Tagged As Int32
            Public tag As Int32
            Public LookforX, LookForY As Int32
            Public FoundX, FoundY As Int32
            Public MinXY As MyPointStructure            ' Location of total picture
            Public MaxXY As MyPointStructure
        End Structure


        Public Structure MyCheatingStructure
            Dim LastDataTypeFound As String 'shorten finddatatypeorcolor()
            Dim LastColorFound As String 'shorten finddatatypeorcolor()
            Dim LastTable As String
            Dim LastString As String
            Dim LastIndex As Int32
            Dim LastSearchString As String
            Dim LastSearchFind As String
            Dim LastiSAMStringTable As String
            Dim LastiSAMStringString As String
            Dim LastiSAMStringIndex As Int32
            Dim LastiSAMNumberTable As String
            Dim LastiSAMNumberNumber As Int32
            Dim LastiSAMNumberIndex As Int32
            Dim ColorsSorted As Int32
            Dim DataTypeSorted As Int32
            Dim NamedSorted As Int32
            Dim FlowChartSorted As Int32
            Dim BugsCounted As Int32
            Dim LastSortedStringTable As String
            Dim LastSortedStringString As String
            Dim LastSortedStringIndex As Int32
            Dim Last_UnSortedStringTable As String
            Dim Last_UnSortedStringString As String
            Dim Last_UnSortedStringIndex As Int32
            Dim LastLanguageTable As String
            Dim LastLanguageString As String
            Dim LastLanguageIndex As Int32
        End Structure

        Structure CStructure
            Dim StillComment As Boolean ' This is for the /* to the */ comments
        End Structure

        Structure LanguageStructure
            Dim C As CStructure
        End Structure

        Structure MySymbolPointPreference
            Dim X As Int32
            Dim Y As Int32
        End Structure



        Structure DefaultStructure
            Dim ConstantDEFAULTCOLORNAME As String
        End Structure

        Public Structure MyUniverseStructure
            Dim MyDefaults As DefaultStructure
            Dim MySS As ImportLineStruct
            Dim MyMouseAndDrawing As MyScreenInfoStructure
            Dim Area As MyRECTStructure
            Dim MyCheatSheet As MyCheatingStructure
            Dim MyStaticData As InternalStructure
            Dim SysGen As SystemStuffStructure
            Dim Languages As LanguageStructure
            Dim DropDownColor As String
            Dim MySymbolPoints() As MySymbolPointPreference
            Dim OptionDisplay() As MyDisplayStructure
        End Structure

        Public Structure IndexsStruct
            Dim IndexFlowChart As Int32
            Dim IndexNamed As Int32
            Dim IndexSymbol As Int32
            Dim IndexDataType As Int32
            Dim IndexColor As Int32

        End Structure


        Public Structure MyRecordStruct
            Dim Coded As Byte
            Dim X1, Y1 As Int32
            Dim X2_io, Y2_dt, NameOfPoint As String
        End Structure

        Public Structure TempsStructure
            Dim TempFormat As String 'hack
            Dim TempRecord As Int32
            Dim TempInteger1 As Int32 ' no longer temp(s)
            Dim TempString2 As String 'on/off or true/false ...
            Dim TempInt32 As Int32
        End Structure

        Public Structure TextsStructure
            Dim KeyWord As String
            Dim KeyLine As String
            Dim Inputline As String
            Dim LineNumberIn As Int32
        End Structure

        Public Structure ImportLineStruct
            Dim Inputs As TextsStructure
            Dim Temps As TempsStructure
            Dim LastName As String
            Dim IndexName, IndexSymbol As Int32
            Dim Idt As Int32
            Dim TopMost As Int32
            Dim MyRecord As MyRecordStruct
            Dim Index As IndexsStruct
        End Structure



        Public Shared MyUniverse As MyUniverseStructure

        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        'This is data file stuff (That should be in a data file)
        Public Shared Named_TableCount As Int32            'This is one for each symbol 
        Public Shared Symbol_TableCount As Int32         ' Number in the MyArray (Points to last)
        Public Shared FlowChart_TableCount As Int32         ' Number in the MyArray (Points to last)
        Public Shared DataType_TableCount As Int32 ' The number of DataType_Tables in the table
        Public Shared Color_TableCount As Int32       ' A list of the colors available to use
        Public Shared SymbolNumber_Counter As Int32




        Public Shared ZeroZero As MyPointStructure
        'Public Shared Code_Line(0) As String
        'Public Shared MyParsed_Line(constantALLFILES) As String
        Public Shared My_Syntax_Line_Parsed(constantALLFILES) As String
        Public Shared My_Code_Line_Parsed(constantALLFILES) As String


        Public Shared Color_iSAM_(256) As Int32         'Sorted Pointers to MyArray
        Public Shared Color_FileName(256) As String
        Public Shared Color_FileAlpha(256) As Byte
        Public Shared Color_FileRed(256) As Byte
        Public Shared Color_FileGreen(256) As Byte
        Public Shared Color_FileBlue(256) As Byte
        Public Shared Color_FileEndCap(256) As Byte
        Public Shared Color_FileStartCap(256) As Byte
        Public Shared Color_FileStyle(256) As Byte


        'One record per each symbol
        Public Shared Named_File_iSAM(constantALLFILES) As Int32            'sorted Indexess to MyArrays
        Public Shared Named_FileSyntax_Isam(constantALLFILES) As Int32                  ' Only used during Decompile and reset to length of one afterwards
        Public Shared Named_FileSymbolName(constantALLFILES) As String       'Name of the symbol
        Public Shared Named_FileIndexes(constantALLFILES) As Int32      ' A Indexes to this symbol in the Symbol Graphics Table         'Find the symbol name and this Indexes should point to the first record of the file_symbol list of graphics
        Public Shared Named_FileProgramText(constantALLFILES) As String       'The actural program ProgramText to be 'fixed'
        Public Shared Named_FileSyntax(constantALLFILES) As String ' The syntax for the decompiler made from the progam test 2020/6/22
        Public Shared Named_FileOpCode(constantALLFILES) As String     'The Machine code of this assemble symbol
        Public Shared Named_FileNotes(constantALLFILES) As String      'Notes for this symbol
        Public Shared Named_FileNameOfFile(constantALLFILES) As String   'The device:/path/Filename where this came from 
        '2020 08 12 removed because each symbol is NOT language related, only the whole FlowChart        'Public Shared Named_FileLanguage(constantALLFILES) As String   'The computer language this applies to
        Public Shared Named_FileAuthor(constantALLFILES) As String 'Who wrote or responsable for this symbol
        Public Shared Named_FileVersion(constantALLFILES) As String ' the date of the latest update
        Public Shared Named_FileStroke(constantALLFILES) As String     'The movement of the mouse that id's this symbol


        'Does not have a sorted way of finding things (yet) should search Named and then get the index/key
        ' This is mostly the graphics of a symbol, It has to remane unsorted.  A Indexes from the sorted NAME list should be used
        Public Shared Symbol_FileSymbolName(constantALLTables) As String 'The name of this symbol for /Name code
        Public Shared Symbol_FileCoded(constantALLTables) As Byte  'The code /line /point etc 
        Public Shared Symbol_FileX1(constantALLTables) As Int32
        Public Shared Symbol_FileY1(constantALLTables) As Int32
        Public Shared Symbol_FileX2_io(constantALLTables) As Int32  'Used also as enum Input/output/bot/optional IO . . . . 
        Public Shared Symbol_FileY2_dt(constantALLTables) As Int32   ' Also used as the index to the data type
        Public Shared Symbol_File_NameOfPoint(constantALLTables) As String


        Public Shared NetNames_File(0) As String ' This hold the name of the paths
        Public Shared NetLinks_File(0) As String ' This holds all of the link numbers that are connected together.

        Public Shared FlowChart_FileNamed(constantALLTables) As String  ' The name of the /use, the variable name of /Path & /Constant
        Public Shared FlowChart_FileCoded(constantALLTables) As Byte ' The codes /Use, /Path, /Constant
        Public Shared FlowChart_FileX1(constantALLTables) As Int32
        Public Shared FlowChart_FileY1(constantALLTables) As Int32
        Public Shared FlowChart_FileX2_Rotation(constantALLTables) As Int32       'X2 for /path, Rotation for /use
        Public Shared FlowChart_FileY2_Option(constantALLTables) As Int32       'Y2 for path , future options for /use
        Public Shared FlowChart_File_DataType(constantALLTables) As String  'The datatype for /Path /constant
        ' Holes information strings during compile (Path Connections, and completed Code)
        Public Shared FlowChart_FilePathLinks_And_CompiledCode(constantALLTables) As String

        Public Shared FlowChart_iSAM_X1(constantALLTables) As Int32     'Holds Indexess to the FlowChart, sorted (Indexd Sequencial Access Method
        Public Shared FlowChart_iSAM_Y1(constantALLTables) As Int32
        Public Shared FlowChart_iSAM_X2(constantALLTables) As Int32
        Public Shared FlowChart_iSAM_Y2(constantALLTables) As Int32
        Public Shared FlowChart_iSAM_Name(constantALLTables) As Int32



        Public Shared DataType_iSAM_(constantALLTables) As Int32        'Sorted MyArray to Names of the datatypes
        Public Shared DataType_FileName(constantALLTables) As String    'Name of the datatype
        Public Shared DataType_FileDescribtion(constantALLTables) As String
        Public Shared DataType_FileNumberOfBytes(constantALLTables) As Int32      ' size in bytes of the data
        Public Shared DataType_FileColorIndex(constantALLTables) As Int32   'number of the color in color_file... to use
        Public Shared DataType_FileWidth(constantALLTables) As Byte     'Width of the /Path and diramter of the /Points


        Public Shared DrillDown_FileName As String      'ONLY CUrrent File name Device:/Paths/Filename.Extension


        '(direction, First/Second line, X/Y
        Public Shared MyDirections(16, 2, 2) As SByte  ' This is the matrix to determine the two end points from the center
        Public Shared MyBits() As Int32 = {1, 2, 4, 8, 16, 32, 64, 128}


        Public Shared MyCmdModeString As String

        Public Shared GetMyPen As Pen




        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        '**************************************************
        ' Programing routines to follow
        '********************************************************


        Public Shared Sub ShowSorts(ByRef MyTable As String, Total As Int32) 'Displays the number of sorts made
            Dim Count As Int32
            MyTrace(1, "ShowSorts", 46 - 41)

            Count = MyUniverse.MyCheatSheet.BugsCounted
            MyUniverse.MyCheatSheet.BugsCounted = 0
            If Total > 0 And Count > 0 Then
                DisplayMyStatus(MyTable & " Still working . . . swapped " & Total & " Total problems detected " & Count)
            ElseIf Total > 0 Then
                DisplayMyStatus(MyTable & " Still working . . . swapped " & Total)
            ElseIf Int((Count - 1) / 10) * 10 = Count Then
                DisplayMyStatus(MyTable & " Total problems detected " & Count)
            End If

        End Sub

        '   mine()
        Public Shared Function MyMsgCtr(SubName As String, MessageNumber As Integer, String1 As String, String2 As String, String3 As String, String4 As String, String5 As String, String6 As String, String7 As String, String8 As String, String9 As String) As MsgBoxResult
            Dim X, J As String
            Dim Temp As Integer
            Dim RtnMsgBox As MsgBoxResult
            ' must turn off #'s to avoid loop forever and crash stack
            MyTrace(2, "MyMsgCtr", 614 - 549)

            MyMsgCtr = MsgBoxResult.Ignore
            If IsBitSet(MessageNumber) Then
                X = " No Warning Message!"
                Temp = OptionScreen.ComboBoxDebug.Items.Count
                Temp = FindMessageNumber(MessageNumber)
                If Temp < 1 Or Temp > OptionScreen.ComboBoxDebug.Items.Count Then Exit Function

                X = OptionScreen.ComboBoxDebug.Items.Item(Temp).ToString
                If PopValue(X) = MessageNumber Then
                    J = Pop(X, ConstantDelimeters)
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd, SubName)
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd, MessageNumber.ToString)
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd, PrintAbleNull(String1))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd, PrintAbleNull(String2))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd, PrintAbleNull(String3))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd, PrintAbleNull(String4))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd, PrintAbleNull(String5))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd, PrintAbleNull(String6))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd, PrintAbleNull(String7))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd, PrintAbleNull(String8))
                    X = MyReplace(X, MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd, PrintAbleNull(String9))
                    X = MessageNumber & FD & J & FD & SubName & "() " & vbCrLf & X ' Put it back
                    Abug(9200, "Msg", X, "")
                    Select Case LCase(Trim(J))
                        Case "wrong"
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.Information, "Cancel will stop showing this message")
                        Case "error"
                            FindingMyBugs(10) 'hack Least amount of checking here 'hack
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.YesNoCancel, "Cancel will stop showing this message")
                        Case "warning"
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.YesNoCancel, "Cancel will stop showing this message")
                        Case "information"
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.YesNoCancel, "Cancel will stop showing this message")
                        Case "status"
                            DisplayMyStatus(MessageNumber & " Unknown Error Message TypeOf " & X)
                        Case "display" ' Dont Use For right now
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.OkCancel, "Cancel will stop showing this message")
                        Case Else
                            RtnMsgBox = MsgBox(X, MsgBoxStyle.OkCancel, "Unknown Type=" & J & vbCrLf & "unknown message number " & MessageNumber & vbCrLf & " Cancel will stop this message")
                    End Select
                    Select Case RtnMsgBox
                        Case MsgBoxResult.Abort
                        Case MsgBoxResult.Cancel
                            BitSet(MessageNumber, "off")
                        Case MsgBoxResult.Ignore
                        Case MsgBoxResult.No
                        Case MsgBoxResult.Ok
                        Case MsgBoxResult.Retry
                        Case MsgBoxResult.Yes
                    End Select
                    Return RtnMsgBox
                End If
                ' We should never get here
                Return MsgBox("MessageNumber  =" & MessageNumber &
                              vbCrLf & " A = " & String1 &
                              vbCrLf & " B = " & String2 &
                              vbCrLf & " C = " & String3 &
                              vbCrLf & " D = " & String4 &
                              vbCrLf & " E = " & String5 &
                              vbCrLf & " F = " & String6 &
                              vbCrLf & " G = " & String7 &
                              vbCrLf & " H = " & String8 &
                              vbCrLf & " I = " & String9,
                              MsgBoxStyle.AbortRetryIgnore,
                              "No Error Message for " & MessageNumber & vbCrLf & X)
            Else
                Return MsgBoxResult.Ignore
            End If
        End Function


        'Routine  This returns a pen color by name (cause I can't make my own from RGB() to work, cause I lazy right now)
        Public Shared Sub MyGetPen_Static(PassedColorORDataTypeName As String)        'Converts from Red/Green/Blue/Alpha to Color structure into global GetMyPen
            Dim IndexColor As Int32
            Dim ColorORDataTypeName As String
            MyTrace(3, "MyGetPen_Static", 1058 - 618)

            GetMyPen = Pens.Black
            ColorORDataTypeName = Trim(FindColorFromDataType(Trim(PassedColorORDataTypeName)))
            If IsNothing(ColorORDataTypeName) Or ColorORDataTypeName = "" Then
                ' This is if it was a color name
                ColorORDataTypeName = Trim(PassedColorORDataTypeName)
            Else
                'This is if it was a data type name passed
                ColorORDataTypeName = Trim(ColorORDataTypeName)
            End If


            If MyUniverse.MyMouseAndDrawing.PaintThisOrEraseThis = False Then
                GetMyPen = Pens.White
                Exit Sub
            End If

            Select Case UCase(Left(ColorORDataTypeName, 1))
                Case "A"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("AliceBlue")
                            GetMyPen = Pens.AliceBlue
                        Case UCase("AntiqueWhite")
                            GetMyPen = Pens.AntiqueWhite
                        Case UCase("Aqua")
                            GetMyPen = Pens.Aqua
                        Case UCase("Aquamarine")
                            GetMyPen = Pens.Aquamarine
                        Case UCase("Azure")
                            GetMyPen = Pens.Azure
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "B"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Beige")
                            GetMyPen = Pens.Beige
                        Case UCase("Bisque")
                            GetMyPen = Pens.Bisque
                        Case UCase("Black")
                            GetMyPen = Pens.Black
                        Case UCase("BlanchedAlmond")
                            GetMyPen = Pens.BlanchedAlmond
                        Case UCase("Blue")
                            GetMyPen = Pens.Blue
                        Case UCase("BlueViolet")
                            GetMyPen = Pens.BlueViolet
                        Case UCase("Brown")
                            GetMyPen = Pens.Brown
                        Case UCase("BurlyWood")
                            GetMyPen = Pens.BurlyWood
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "C"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("CadetBlue")
                            GetMyPen = Pens.CadetBlue
                        Case UCase("Chartreuse")
                            GetMyPen = Pens.Chartreuse
                        Case UCase("Chocolate")
                            GetMyPen = Pens.Chocolate
                        Case UCase("Coral")
                            GetMyPen = Pens.Coral
                        Case UCase("CornflowerBlue")
                            GetMyPen = Pens.CornflowerBlue
                        Case UCase("Cornsilk")
                            GetMyPen = Pens.Cornsilk
                        Case UCase("Crimson")
                            GetMyPen = Pens.Crimson
                        Case UCase("Cyan")
                            GetMyPen = Pens.Cyan
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "D"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("DataTypeError")
                            GetMyPen = Pens.Red
                        Case UCase("DarkBlue")
                            GetMyPen = Pens.DarkBlue
                        Case UCase("DarkCyan")
                            GetMyPen = Pens.DarkCyan
                        Case UCase("DarkGoldenrod")
                            GetMyPen = Pens.DarkGoldenrod
                        Case UCase("DarkGray")
                            GetMyPen = Pens.DarkGray
                        Case UCase("DarkGreen")
                            GetMyPen = Pens.DarkGreen
                        Case UCase("DarkKhaki")
                            GetMyPen = Pens.DarkKhaki
                        Case UCase("DarkMagenta")
                            GetMyPen = Pens.DarkMagenta
                        Case UCase("DarkOliveGreen")
                            GetMyPen = Pens.DarkOliveGreen
                        Case UCase("DarkOrange")
                            GetMyPen = Pens.DarkOrange
                        Case UCase("DarkOrchid")
                            GetMyPen = Pens.DarkOrchid
                        Case UCase("DarkRed")
                            GetMyPen = Pens.DarkRed
                        Case UCase("DarkSalmon")
                            GetMyPen = Pens.DarkSalmon
                        Case UCase("DarkSeaGreen")
                            GetMyPen = Pens.DarkSeaGreen
                        Case UCase("DarkSlateBlue")
                            GetMyPen = Pens.DarkSlateBlue
                        Case UCase("DarkSlateGray")
                            GetMyPen = Pens.DarkSlateGray
                        Case UCase("DarkTurquoise")
                            GetMyPen = Pens.DarkTurquoise
                        Case UCase("DarkViolet")
                            GetMyPen = Pens.DarkViolet
                        Case UCase("DeepPink")
                            GetMyPen = Pens.DeepPink
                        Case UCase("DeepSkyBlue")
                            GetMyPen = Pens.DeepSkyBlue
                        Case UCase("DimGray")
                            GetMyPen = Pens.DimGray
                        Case UCase("DodgerBlue")
                            GetMyPen = Pens.DodgerBlue
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "F"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Firebrick")
                            GetMyPen = Pens.Firebrick
                        Case UCase("FloralWhite")
                            GetMyPen = Pens.FloralWhite
                        Case UCase("ForestGreen")
                            GetMyPen = Pens.ForestGreen
                        Case UCase("Fuchsia")
                            GetMyPen = Pens.Fuchsia
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "G"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Gainsboro")
                            GetMyPen = Pens.Gainsboro
                        Case UCase("GhostWhite")
                            GetMyPen = Pens.GhostWhite
                        Case UCase("Gold")
                            GetMyPen = Pens.Gold
                        Case UCase("Goldenrod")
                            GetMyPen = Pens.Goldenrod
                        Case UCase("Gray")
                            GetMyPen = Pens.Gray
                        Case UCase("Green")
                            GetMyPen = Pens.Green
                        Case UCase("GreenYellow")
                            GetMyPen = Pens.GreenYellow
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "H"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Honeydew")
                            GetMyPen = Pens.Honeydew
                        Case UCase("HotPink")
                            GetMyPen = Pens.HotPink
                    End Select
                Case "I"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("IndianRed")
                            GetMyPen = Pens.IndianRed
                        Case UCase("Indigo")
                            GetMyPen = Pens.Indigo
                        Case UCase("Ivory")
                            GetMyPen = Pens.Ivory
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "K"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Khaki")
                            GetMyPen = Pens.Khaki
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "L"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Lavender")
                            GetMyPen = Pens.Lavender
                        Case UCase("LavenderBlush")
                            GetMyPen = Pens.LavenderBlush
                        Case UCase("LawnGreen")
                            GetMyPen = Pens.LawnGreen
                        Case UCase("LemonChiffon")
                            GetMyPen = Pens.LemonChiffon
                        Case UCase("LightBlue")
                            GetMyPen = Pens.LightBlue
                        Case UCase("LightCoral")
                            GetMyPen = Pens.LightCoral
                        Case UCase("LightCyan")
                            GetMyPen = Pens.LightCyan
                        Case UCase("LightGoldenrodYellow")
                            GetMyPen = Pens.LightGoldenrodYellow
                        Case UCase("LightGray")
                            GetMyPen = Pens.LightGray
                        Case UCase("LightGreen")
                            GetMyPen = Pens.LightGreen
                        Case UCase("LightPink")
                            GetMyPen = Pens.LightPink
                        Case UCase("LightSalmon")
                            GetMyPen = Pens.LightSalmon
                        Case UCase("LightSeaGreen")
                            GetMyPen = Pens.LightSeaGreen
                        Case UCase("LightSkyBlue")
                            GetMyPen = Pens.LightSkyBlue
                        Case UCase("LightSlateGray")
                            GetMyPen = Pens.LightSlateGray
                        Case UCase("LightSteelBlue")
                            GetMyPen = Pens.LightSteelBlue
                        Case UCase("LightYellow")
                            GetMyPen = Pens.LightYellow
                        Case UCase("Lime")
                            GetMyPen = Pens.Lime
                        Case UCase("LimeGreen")
                            GetMyPen = Pens.LimeGreen
                        Case UCase("Linen")
                            GetMyPen = Pens.Linen
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "M"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Magenta")
                            GetMyPen = Pens.Magenta
                        Case UCase("Maroon")
                            GetMyPen = Pens.Maroon
                        Case UCase("MediumAquamarine")
                            GetMyPen = Pens.MediumAquamarine
                        Case UCase("MediumBlue")
                            GetMyPen = Pens.MediumBlue
                        Case UCase("MediumOrchid")
                            GetMyPen = Pens.MediumOrchid
                        Case UCase("MediumPurple")
                            GetMyPen = Pens.MediumPurple
                        Case UCase("MediumSeaGreen")
                            GetMyPen = Pens.MediumSeaGreen
                        Case UCase("MediumSlateBlue")
                            GetMyPen = Pens.MediumSlateBlue
                        Case UCase("MediumSpringGreen")
                            GetMyPen = Pens.MediumSpringGreen
                        Case UCase("MediumTurquoise")
                            GetMyPen = Pens.MediumTurquoise
                        Case UCase("MediumVioletRed")
                            GetMyPen = Pens.MediumVioletRed
                        Case UCase("MidnightBlue")
                            GetMyPen = Pens.MidnightBlue
                        Case UCase("MintCream")
                            GetMyPen = Pens.MintCream
                        Case UCase("MistyRose")
                            GetMyPen = Pens.MistyRose
                        Case UCase("Moccasin")
                            GetMyPen = Pens.Moccasin
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "N"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("NavajoWhite")
                            GetMyPen = Pens.NavajoWhite
                        Case UCase("Navy")
                            GetMyPen = Pens.Navy
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "O"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("OldLace")
                            GetMyPen = Pens.OldLace
                        Case UCase("Olive")
                            GetMyPen = Pens.Olive
                        Case UCase("OliveDrab")
                            GetMyPen = Pens.OliveDrab
                        Case UCase("Orange")
                            GetMyPen = Pens.Orange
                        Case UCase("OrangeRed")
                            GetMyPen = Pens.OrangeRed
                        Case UCase("Orchid")
                            GetMyPen = Pens.Orchid
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "P"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("PaleGoldenrod")
                            GetMyPen = Pens.PaleGoldenrod
                        Case UCase("PaleGreen")
                            GetMyPen = Pens.PaleGreen
                        Case UCase("PaleTurquoise")
                            GetMyPen = Pens.PaleTurquoise
                        Case UCase("PaleVioletRed")
                            GetMyPen = Pens.PaleVioletRed
                        Case UCase("PapayaWhip")
                            GetMyPen = Pens.PapayaWhip
                        Case UCase("PeachPuff")
                            GetMyPen = Pens.PeachPuff
                        Case UCase("Peru")
                            GetMyPen = Pens.Peru
                        Case UCase("Pink")
                            GetMyPen = Pens.Pink
                        Case UCase("Plum")
                            GetMyPen = Pens.Plum
                        Case UCase("PowderBlue")
                            GetMyPen = Pens.PowderBlue
                        Case UCase("Purple")
                            GetMyPen = Pens.Purple
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "R"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Red")
                            GetMyPen = Pens.Red
                        Case UCase("RosyBrown")
                            GetMyPen = Pens.RosyBrown
                        Case UCase("RoyalBlue")
                            GetMyPen = Pens.RoyalBlue
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "S"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("SaddleBrown")
                            GetMyPen = Pens.SaddleBrown
                        Case UCase("Salmon")
                            GetMyPen = Pens.Salmon
                        Case UCase("SandyBrown")
                            GetMyPen = Pens.SandyBrown
                        Case UCase("SeaGreen")
                            GetMyPen = Pens.SeaGreen
                        Case UCase("SeaShell")
                            GetMyPen = Pens.SeaShell
                        Case UCase("Sienna")
                            GetMyPen = Pens.Sienna
                        Case UCase("Silver")
                            GetMyPen = Pens.Silver
                        Case UCase("SkyBlue")
                            GetMyPen = Pens.SkyBlue
                        Case UCase("SlateBlue")
                            GetMyPen = Pens.SlateBlue
                        Case UCase("SlateGray")
                            GetMyPen = Pens.SlateGray
                        Case UCase("Snow")
                            GetMyPen = Pens.Snow
                        Case UCase("SpringGreen")
                            GetMyPen = Pens.SpringGreen
                        Case UCase("SteelBlue")
                            GetMyPen = Pens.SteelBlue
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "T"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Tan")
                            GetMyPen = Pens.Tan
                        Case UCase("Teal")
                            GetMyPen = Pens.Teal
                        Case UCase("Thistle")
                            GetMyPen = Pens.Thistle
                        Case UCase("Tomato")
                            GetMyPen = Pens.Tomato
                        Case UCase("Transparent")
                            GetMyPen = Pens.Transparent
                        Case UCase("Turquoise")
                            GetMyPen = Pens.Turquoise
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "V"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Violet")
                            GetMyPen = Pens.Violet
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "W"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Wheat")
                            GetMyPen = Pens.Wheat
                        Case UCase("White")
                            GetMyPen = Pens.White
                        Case UCase("WhiteSmoke")
                            GetMyPen = Pens.WhiteSmoke
                        Case Else
                            GetMyPen = Pens.Black
                    End Select
                Case "Y"
                    Select Case UCase(ColorORDataTypeName)
                        Case UCase("Yellow")
                            GetMyPen = Pens.Yellow
                        Case UCase("YellowGreen")
                            GetMyPen = Pens.YellowGreen
                        Case Else
                            GetMyPen = Pens.Black
                    End Select

                Case Else
                    '???? Why am I looking it up in the color table? and then making it black
                    ' ohh because the RGB pen creation was to hard to do, cause Im lazy
                    GetMyPen = Pens.Black
                    'To bad I cant make it into red green blue pen yet
            End Select
            If IsNothing(GetMyPen) Then
                MyMsgCtr("GetMyPen", 1269, PassedColorORDataTypeName, ColorORDataTypeName, ColorORDataTypeName, "", "", "", "", "", "")
                GetMyPen = Pens.Red
            End If



            IndexColor = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, ColorORDataTypeName)

            MyCheckIndexs(0, 0, 0, IndexColor, 0)
            If IndexColor > 0 Then
                If Color_TableStartCap(IndexColor) > 0 Then
                    'ERROR IN START  'gloe20
                    '''''''''''GetMyPen.StartCap = Drawing2D.LineCap.ArrowAnchor  ' MyCapCode(cint(MyUnEnum(Color_TableStartCap(IndexColor), symbolscreen.ToolStripDropDownPathStart, 1)))
                    '''''''''''GetMyPen.StartCap = MyCapCode(cint(MyUnEnum(Color_TableStartCap(IndexColor), SymbolScreen.ToolStripDropDownPathStart, 1)))
                Else
                    GetMyPen.StartCap = Drawing2D.LineCap.Flat
                End If
                If Color_TableEndCap(IndexColor) > 0 Then
                    'ERROR in End cap
                    ''''''''''''''GetMyPen.EndCap = Drawing2D.LineCap.RoundAnchor 'MyCapCode(cint(MyUnEnum(Color_TableEndCap(IndexColor), SymbolScreen.ToolStripDropDownPathEnd.DropDownItems, 1)))
                Else
                    GetMyPen.EndCap = Drawing2D.LineCap.Flat
                End If
                If Color_TableStyle(IndexColor) <> 0 Then
                    'flow10''''''''''''''''''GetMyPen.DashStyle = Color_TableStyle(IndexColor)
                Else
                    'ERROR this is no longer working
                    ''''''''''''''''''''''GetMyPen.DashStyle = Drawing2D.DashStyle.Solid
                End If
            Else ' Cant find the color
                'flow10 '''''''GetMyPen.DashStyle = Drawing2D.DashStyle.Solid
                'flow10 '''''''GetMyPen.StartCap = Drawing2D.LineCap.Flat
                'flow10 '''''''GetMyPen.EndCap = Drawing2D.LineCap.Flat
            End If
        End Sub



        Public Shared Function MySign(A As Int32) As Int32       'Returns the sign value
            MySign = 0
            If A > 0 Then Return 1
            If A < 0 Then Return -1
        End Function


        'Routine  This returns an absolute value (ie: never negitive)
        Public Shared Function MyABS(A As Int32) As Int32       'Returns the absolute value
            MyTrace(5, "MyABS", 72 - 63)

            If A > 0 Then
                MyABS = A
                Exit Function
            End If
            MyABS = -A
            Exit Function
        End Function


        'routine to get the max value (dumb, should be a default function ! )
        Public Shared Function MyMax(a As Int32, b As Int32) As Int32
            If a > b Then
                MyMax = a
            Else
                MyMax = b
            End If
        End Function


        'Routine This returns the minium of the two (long) values
        Public Shared Function MyMiNLong(a As Int32, b As Int32) As Int32
            'MyTrace(6, "MyMinLong", 83 - 77)

            If a < b Then
                MyMiNLong = a
            Else
                MyMiNLong = b
            End If
        End Function

        '**************************************************************************************************
        'Routine This returns the number forced to be between 
        'This routine returns  Min <= A <= Max
        Public Shared Function MyMinMax(A As Int32, MinimunValue As Int32, MaximunValue As Int32) As Integer
            'MyTrace(7, "MyMinMax", 95 - 86) called to often Need to fix it

            If A < MinimunValue Then
                MyMinMax = MinimunValue : Exit Function
            ElseIf A > MaximunValue Then
                MyMinMax = MaximunValue : Exit Function
            End If
            MyMinMax = A
        End Function

        '*******************************************************************
        'Routine This returns the maxiumn of the two values
        Public Shared Function MyMaXLong(a As Int32, b As Int32) As Int32
            MyMaXLong = b
            If a > b Then MyMaXLong = a
        End Function

        Public Shared Sub MakeItTheBiggestSymbolNumber(ByRef SymbolName As String) ' Finds the number part of a string
            Dim A As String
            Dim B As Int32
            MyTrace(9, "MakeItTheBiggestSymbolNumber", 84 - 70)

            A = SymbolName
            While ThisIsAnAlpha(A)
                A = Mid(A, 2, Len(A))
            End While
            B = Popvalue(A)
            If ThisIsAnAlpha(A) Then
                If B > MyUniverse.SysGen.HighestSymbolNumber Then
                    MyUniverse.SysGen.HighestSymbolNumber = B
                End If
            End If
        End Sub


        'Routine This makes sure ALL MyArray bounds will never become to small.
        'Routine (continued) It also displays on OptionScreen. the size, and amount used.
        Public Shared Sub MyMakeArraySizesBigger() ' Checks that all of the arrays have room to add to
            MyTrace(11, "MyMakeArraySizesBigger", 1222 - 1109)

            Dim MyNumber As Integer
            Dim Named_Counter, FlowChart_Counter, Symbol_Counter, Color_Counter, DataType_Counter As int32

            'Named_Counter = TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
            If Named_TableCount > UBound(Named_FileSymbolName) Then Named_Counter = UBound(Named_FileSymbolName) Else Named_Counter = Named_TableCount
            If Named_Counter + constantBufferSizeBeforeChangingSizeOfArray / 2 > UBound(Named_FileSymbolName) Then
                MyNumber = CInt(MyMaXLong(Named_Counter + constantBufferSizeBeforeChangingSizeOfArray, 16))
                ReDim Preserve Named_File_iSAM(MyNumber)
                ReDim Preserve Named_FileSyntax_Isam(MyNumber)
                ReDim Preserve Named_FileSymbolName(MyNumber)
                ReDim Preserve Named_FileProgramText(MyNumber)
                ReDim Preserve Named_FileSyntax(MyNumber)
                ReDim Preserve Named_FileOpCode(MyNumber)
                ReDim Preserve Named_FileNotes(MyNumber)
                ReDim Preserve Named_FileNameOfFile(MyNumber)
                ReDim Preserve Named_FileStroke(MyNumber)
                ReDim Preserve Named_FileIndexes(MyNumber)
                ReDim Preserve Named_FileVersion(MyNumber)
                ReDim Preserve Named_FileAuthor(MyNumber)
                FileInputOutputScreen.PB_Size1.Width = CInt((MyNumber ^ 0.5))
                FileInputOutputScreen.PB_Size1.Value = CInt(100.0 * Named_Counter / UBound(Named_FileSymbolName))
                FileInputOutputScreen.PB_LabelSizeNamed.Text = "Named"
                Application.DoEvents()
            End If

            'Symbol_Counter = MyMinMax(Symbol_TableCount, 1, UBound(Symbol_FileCoded))
            If Symbol_TableCount > UBound(Symbol_FileCoded) Then Symbol_Counter = UBound(Symbol_FileCoded) Else Symbol_Counter = Symbol_TableCount
            If Symbol_Counter + constantBufferSizeBeforeChangingSizeOfArray / 2 > UBound(Symbol_FileSymbolName) Then
                MyNumber = CInt(MyMaXLong(Symbol_Counter + constantBufferSizeBeforeChangingSizeOfArray, 16))
                ' sorted by symbolname
                ReDim Preserve Symbol_FileSymbolName(MyNumber)
                ReDim Preserve Symbol_FileCoded(MyNumber)
                ReDim Preserve Symbol_FileX1(MyNumber)
                ReDim Preserve Symbol_FileY1(MyNumber)
                ReDim Preserve Symbol_FileX2_io(MyNumber)
                ReDim Preserve Symbol_FileY2_dt(MyNumber)
                ReDim Preserve Symbol_File_NameOfPoint(MyNumber)
                FileInputOutputScreen.PB_Size2.Width = CInt(MyNumber ^ 0.5)
                FileInputOutputScreen.PB_Size2.Value = CInt(100.0 * Symbol_Counter / UBound(Symbol_FileSymbolName))
                FileInputOutputScreen.PB_LabelSizeSymbol.Text = "Symbols"
                Application.DoEvents()
            End If

            'FlowChart_Counter = MyMinMax(FlowChart_TableCount, 1, UBound(FlowChart_FileCoded))
            'TopOfFile("FlowChart", FlowChart_FileCoded)
            If FlowChart_TableCount > UBound(FlowChart_FileCoded) Then FlowChart_Counter = UBound(FlowChart_FileCoded) Else FlowChart_Counter = FlowChart_TableCount
            If FlowChart_Counter + constantBufferSizeBeforeChangingSizeOfArray / 2 > UBound(FlowChart_FileCoded) Then
                MyNumber = CInt(MyMaXLong(FlowChart_Counter + constantBufferSizeBeforeChangingSizeOfArray, 16))
                ReDim Preserve FlowChart_FileCoded(MyNumber)
                ReDim Preserve FlowChart_FileNamed(MyNumber)
                ReDim Preserve FlowChart_FileX1(MyNumber)
                ReDim Preserve FlowChart_FileY1(MyNumber)
                ReDim Preserve FlowChart_FileX2_Rotation(MyNumber)
                ReDim Preserve FlowChart_FileY2_Option(MyNumber)
                ReDim Preserve FlowChart_File_DataType(MyNumber)
                ReDim Preserve FlowChart_FilePathLinks_And_CompiledCode(MyNumber)
                ReDim Preserve FlowChart_iSAM_X1(MyNumber)
                ReDim Preserve FlowChart_iSAM_Y1(MyNumber)
                ReDim Preserve FlowChart_iSAM_X2(MyNumber)
                ReDim Preserve FlowChart_iSAM_Y2(MyNumber)
                ReDim Preserve FlowChart_iSAM_Name(MyNumber)

                FileInputOutputScreen.PB_Size3.Width = CInt(MyNumber ^ 0.5)
                FileInputOutputScreen.PB_Size3.Value = CInt(100.0 * FlowChart_Counter / UBound(FlowChart_FileCoded))
                FileInputOutputScreen.PB_LabelSizeFlowChart.Text = "FlowChart"
                Application.DoEvents()
            End If


            'TopOfFile("Color", Color_FileName, Color_iSAM_)
            'Color_Counter = MyMinMax(Color_TableCount, 1, UBound(Color_FileBlue))
            If Color_TableCount > UBound(Color_FileName) Then Color_Counter = UBound(Color_FileName) Else Color_Counter = Color_TableCount
            If Color_Counter + constantBufferSizeBeforeChangingSizeOfArray / 2 > UBound(Color_FileName) Then
                MyNumber = CInt(MyMaXLong(Color_Counter + constantBufferSizeBeforeChangingSizeOfArray, 16))
                ReDim Preserve Color_FileName(MyNumber)
                ReDim Preserve Color_FileAlpha(MyNumber)
                ReDim Preserve Color_FileRed(MyNumber)
                ReDim Preserve Color_FileGreen(MyNumber)
                ReDim Preserve Color_FileBlue(MyNumber)
                ReDim Preserve Color_FileStyle(MyNumber) '1, dash , 2, dot, 3, dashdot, 4, dashdotdot
                ReDim Preserve Color_FileStartCap(MyNumber)
                ReDim Preserve Color_FileEndCap(MyNumber)
                ReDim Preserve Color_iSAM_(MyNumber)
                FileInputOutputScreen.PB_Size4.Width = CInt(MyNumber ^ 0.5)
                FileInputOutputScreen.PB_Size4.Value = CInt(100.0 * Color_Counter / UBound(Color_FileName))
                FileInputOutputScreen.PB_LabelSizeColor.Text = "Colors"
                Application.DoEvents()
            End If

            'TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
            'DataType_Counter = MyMinMax(DataType_TableCount, 1, UBound(FlowChart_FileCoded))
            If DataType_TableCount > UBound(DataType_FileName) Then DataType_Counter = UBound(DataType_FileName) Else DataType_Counter = DataType_TableCount
            If DataType_Counter + constantBufferSizeBeforeChangingSizeOfArray / 2 > UBound(DataType_FileName) Then
                MyNumber = CInt(MyMaXLong(DataType_Counter + constantBufferSizeBeforeChangingSizeOfArray, 16))
                ReDim Preserve DataType_iSAM_(MyNumber)
                ReDim Preserve DataType_FileName(MyNumber)
                ReDim Preserve DataType_FileColorIndex(MyNumber)
                ReDim Preserve DataType_FileDescribtion(MyNumber)
                ReDim Preserve DataType_FileNumberOfBytes(MyNumber)
                ReDim Preserve DataType_FileWidth(MyNumber)
                FileInputOutputScreen.PB_Size5.Width = CInt(MyNumber ^ 0.5)
                FileInputOutputScreen.PB_Size5.Value = CInt(100.0 * DataType_Counter / UBound(DataType_FileName))
                FileInputOutputScreen.PB_LabelSizeDataType.Text = "DataType"
                Application.DoEvents()
            End If
        End Sub


        '*****************************************************************
        'This makes sure that the file counters of where you are is inside the bounds of the arrays
        Public Shared Function FileCounter(ByRef MyTable As String) As int32
            MyTrace(12, "FileCounter", 241 - 224)

            MyMakeArraySizesBigger()
            FileCounter = 1 ' Minium for ever file.
            Select Case MyTable
                Case "color"
                    FileCounter = MyMinMax(Color_TableCount, 1, UBound(FlowChart_FileCoded))
                Case "FlowChart"
                    FileCounter = MyMinMax(FlowChart_TableCount, 1, UBound(FlowChart_FileCoded))
                Case "named"
                    FileCounter = MyMinMax(Named_TableCount, 1, UBound(FlowChart_FileCoded))
                Case "symbol"
                    FileCounter = MyMinMax(Symbol_TableCount, 1, UBound(FlowChart_FileCoded))
                Case "datatype"
                    FileCounter = MyMinMax(DataType_TableCount, 1, UBound(FlowChart_FileCoded))
                Case Else
                    Abug(765, "Wrong table name", MyTable, 0)
                    FileCounter = CInt((Color_TableCount + FlowChart_TableCount + Named_TableCount + Symbol_TableCount + DataType_TableCount) / 5)
            End Select
        End Function


        Public Shared Sub FileCounter(ByRef MyTable As String, NewValue As int32) ' Keeps track of the highest pointer of the MyTable Arrays
            MyTrace(13, "FileCounter", 60 - 45)

            Select Case MyTable
                Case "Color"
                    Color_TableCount = NewValue
                Case "FlowChart"
                    FlowChart_TableCount = NewValue
                Case "Named"
                    Named_TableCount = NewValue
                Case "Symbol"
                    If NewValue + 2 < Symbol_TableCount Then
                        NewValue = NewValue
                    End If

                    If Symbol_TableCount > NewValue Then
                        NewValue = Symbol_TableCount
                    End If
                    Symbol_TableCount = NewValue
                Case "DataType"
                    DataType_TableCount = NewValue
                Case Else 'hack
                    Abug(764, "FileCounter: ", MyTable, 0) 'hack
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack
                    NewValue = NewValue 'hack should never happen
            End Select
            MyMakeArraySizesBigger()
        End Sub



        '****************************************************************
        'returns the new top of the data in the array
        'version 1 for bytes (.coded)
        Public Shared Function NewTopOfFile(ByRef MyTable As String, ByRef MyArray() As Byte) As int32
            MyTrace(14, "NewTopOfFile", 68 - 64)

            NewTopOfFile = TopOfFile(MyTable, MyArray)
            While MyArray(NewTopOfFile) <> 0
                NewTopOfFile += 1
            End While
            If NewTopOfFile < 1 Then
                NewTopOfFile = 1
            End If
        End Function



        '************************************************************************************
        'One of many routines that returns the top of the data in the array
        Public Shared Function TopOfFile(ByRef MyTable As String, ByRef MyArray() As Byte) As int32
            MyTrace(15, "TopOfFile", 79 - 71)

            TopOfFile = FileCounter(MyTable)
            While IsNothing(MyArray(TopOfFile)) '20200630 In case the end of the file has increased )
                TopOfFile = TopOfFile - 1 '20200630
            End While '20200625
            While MyArray(TopOfFile) > 0 '20200625 In case the end of the file has increased 
                TopOfFile = TopOfFile + 1 '20200625
            End While '20200625
            While MyArray(TopOfFile) <= 0 And TopOfFile > 1
                TopOfFile = MyMaXLong(1, TopOfFile - 1)
            End While
            FileCounter(MyTable, TopOfFile) ' Save it for next time
        End Function

        '****************************************************************
        'returns the new top of the data in the array
        'version 2 for strings (named...)
        Public Shared Function NewTopOfFile(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32) As int32
            MyTrace(16, "NewTopOfFile", 91 - 84)

            NewTopOfFile = TopOfFile(MyTable, MyArray, iSAM)
            While Not IsNothing(MyArray(NewTopOfFile))
                NewTopOfFile += 1
            End While
        End Function



        '*********************************************************************************************************************
        'This is to keep track of the top of the USED arrays (as opposed to the size of the array)

        Public Shared Function TopOfFile(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32) As Integer
            MyTrace(17, "TopOfFile", 309 - 294)

            TopOfFile = FileCounter(MyTable) ' get the max size that it should be
            If TopOfFile > UBound(MyArray) Then
                Abug(762, "The top of file counter is greater then the array size", TopOfFile, UBound(MyArray))
                MyMakeArraySizesBigger()
            End If
            If TopOfFile > UBound(MyArray) Then
                TopOfFile = UBound(MyArray) - 1 'Error Should Never happen
                Abug(760, "The top of file counter is greater then the array size, so it was reset", TopOfFile, UBound(MyArray))
            End If
            While Not IsNothing(MyArray(TopOfFile)) And TopOfFile < UBound(MyArray)
                TopOfFile = MyMinMax(TopOfFile + 1, 1, UBound(MyArray))
                'CheckMyArraySizes()
            End While
            While IsNothing(MyArray(TopOfFile)) And TopOfFile > 1
                TopOfFile = MyMinMax(TopOfFile - 1, 1, UBound(MyArray))
            End While
            FileCounter(MyTable, TopOfFile) ' Save it for next time
        End Function

        '****************************************************************
        'returns the new top of the data in the array
        'version 3 for floxchartx1,y1,x2,y2, 
        Public Shared Function NewTopOfFile(ByRef MyTable As String, ByRef MyArrayLong() As Int32, ByRef iSAM() As Int32) As Int32
            MyTrace(18, "NewTopOfFile", 17 - 13)

            NewTopOfFile = TopOfFile(MyTable, MyArrayLong, iSAM)
            While Not IsNothing(MyArrayLong(NewTopOfFile)) Or MyArrayLong(NewTopOfFile) <> 0
                NewTopOfFile += 1
            End While
            If Not IsNothing(MyArrayLong(NewTopOfFile)) Then
                NewTopOfFile -= 1
            End If
        End Function

        Public Shared Function TopOfFile(ByRef MyTable As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32) As int32 ' returns the highest number used in the string MyArray
            MyTrace(19, "TopOfFile", 39 - 20)

            TopOfFile = FileCounter(MyTable)
            While (TopOfFile > 1) And (iSAM(TopOfFile) = constantMyErrorCode)
                SwapNn(MyTable, MyArrayLong, iSAM, TopOfFile, TopOfFile - 1)
                TopOfFile -= 1
            End While
            While IsNothing(iSAM(TopOfFile)) Or iSAM(TopOfFile) = 0 And TopOfFile > 1 '20200625
                If TopOfFile < 1 Then
                    TopOfFile = 1
                    Exit Function
                End If
                TopOfFile -= 1
            End While

            While MyArrayLong(iSAM(TopOfFile)) = 0 And TopOfFile > 1 '20200625
                If TopOfFile <= 1 Then
                    TopOfFile = 1
                    Exit Function
                End If
                TopOfFile -= 1
                If TopOfFile <= 1 Then Exit While
                If iSAM(TopOfFile) < 1 Then Exit While
            End While
            FileCounter(MyTable, TopOfFile)
        End Function


        Public Shared Sub OptionsSetDefaults(E As ToolStripDropDownButton, DeFaultOption As String)
            Dim I As Int32
            Dim X As String
            'undone not sure if this works
            'E.DropDownItems.Find(DeFaultOption, True)
            For I = 0 To E.DropDownItems.Count - 1
                X = LCase(Trim(E.DropDownItems(I).ToString))
                If LCase(Left(X, Len(DeFaultOption))) = LCase(Trim(DeFaultOption)) Then
                    E.DropDownItems(I).Select()
                    E.Text = E.DropDownItems(I).ToString
                    Exit Sub
                End If
            Next I
            E.DropDownItems(0).Select()
            E.Text = ""
        End Sub


        Public Shared Sub ShowThisScreen(F As Form, status As Integer)
            Select Case status
                Case LeaveScreenAlone
                    F.SendToBack()
                Case HideScreen
                    F.Visible = False
                    F.SendToBack()
                Case ShowScreen
                    F.Visible = True
                    F.BringToFront()
                    MyButtonsEnableRules(F) ' enable and disable the buttons on all forms
            End Select

        End Sub


        Public Shared Sub UpDateComputerLanguage()
            Dim I As Int32
            Dim XX As String

            XX = Nothing
            For I = 0 To 32 'hack
                If OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Item(I).Selected = True Then
                    XX = OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Item(I).Text
                    ComputerLanguageTurnedOn(Pop(XX, FD))
                    Exit For
                End If
            Next I

            If IsNothing(XX) Then Exit Sub

            'SelectInToolStripDropDownButton(OptionScreen.ToolStripDropDownComputerLanguageX, MyUniverse.MySS.Inputs.KeyWord)
            FileInputOutputScreen.TextBoxStatus1.Text = "Name=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 0)
            FileInputOutputScreen.TextBoxStatus2.Text = "Case=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 1)
            FileInputOutputScreen.TextBoxStatus3.Text = "Comment=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 2)
            FileInputOutputScreen.TextBoxStatus4.Text = "Ext=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 3)
            FileInputOutputScreen.TextBoxStatus5.Text = "2lines1 =" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 4)
            FileInputOutputScreen.TextBoxStatus6.Text = "Cont=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 5)
            FileInputOutputScreen.TextBoxStatus7.Text = "Names=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 6)
            FileInputOutputScreen.TextBoxNetLinks.Text = "Goto=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 7)
            FileInputOutputScreen.TextBoxStatus9.Text = "Come=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 8)
            FileInputOutputScreen.TextBoxStatus10.Text = "Reserved1=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 9)
            FileInputOutputScreen.TextBoxStatus11.Text = "Reserved2=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 10)
            FileInputOutputScreen.TextBoxStatus12.Text = "Reserved3=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 10)
            FileInputOutputScreen.TextBoxStatus13.Text = "Reserved4=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 10)
            FileInputOutputScreen.TextBoxStatus14.Text = "Reserved5=" & MyUnEnum(MyEnumValue(WhatComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 10)

            Application.DoEvents()
        End Sub



        Public Shared Sub ShowAllForms(FormFlowChart As Integer, FormSymbol As Integer, FormOption As Integer, FormFileIO As Integer, FormStatus As Integer, FormHelp As Integer)
            '-1 is no change (sent to the back)
            '0 is make it invisible (not being used right now)
            '1 is make it the front and visible
            MyTrace(21, "ShowAllForms", 401 - 346)
            GetAllSymbolNames("Start") 'todo check that this is require HERE?

            If SplashScreen.Visible = True Then
                ShowThisScreen(FlowChartScreen, HideScreen)
                ShowThisScreen(SymbolScreen, HideScreen)
                ShowThisScreen(OptionScreen, HideScreen)
                ShowThisScreen(FileInputOutputScreen, HideScreen)
                ShowThisScreen(StatusScreen, HideScreen) ' Not using anymore
                ShowThisScreen(HelpScreen, HideScreen)
            Else
                ShowThisScreen(FlowChartScreen, FormFlowChart)
                ShowThisScreen(SymbolScreen, FormSymbol)
                ShowThisScreen(OptionScreen, FormOption)
                ShowThisScreen(FileInputOutputScreen, FormFileIO)
                ShowThisScreen(StatusScreen, HideScreen) ' Not using anymore
                ShowThisScreen(HelpScreen, FormHelp)
                Application.DoEvents()
            End If
            UpDateComputerLanguage() 'This changes the language (if changed) 'hack this really is just a hack job and needs to be fixed.
            Application.DoEvents()
        End Sub


        Public Shared Function MyRotated_1(IndexSymbol As Int32, IndexFlowChart As Int32, RotationName As String) As MyPointStructure
            Dim InputXY As MyPointStructure
            Dim OffsetXY As MyPointStructure
            MyTrace(22, "MyRotated_1", 49 - 33)

            MyCheckIndexs(IndexFlowChart, IndexSymbol, 0, 0, 0)
            If IndexSymbol = 0 Then
                InputXY.X = 0
                InputXY.Y = 0
            Else
                InputXY.X = Symbol_TableX1(IndexSymbol)
                InputXY.Y = Symbol_TableY1(IndexSymbol)
            End If
            OffsetXY.X = FlowChart_TableX1(IndexFlowChart)
            OffsetXY.Y = FlowChart_TableY1(IndexFlowChart)
            MyRotated_1 = MyRotated_x(InputXY, OffsetXY, RotationName)
        End Function

        Public Shared Function MyRotated_1(IndexSymbol As Int32, OffsetXY As MyPointStructure, RotationName As String) As MyPointStructure
            MyTrace(23, "MyRotated_1", 23 - 16)
            Dim InputXY As MyPointStructure
            MyCheckIndexs(0, IndexSymbol, 0, 0, 0)
            InputXY.X = Symbol_TableX1(IndexSymbol)
            InputXY.Y = Symbol_TableY1(IndexSymbol)
            MyRotated_1 = MyRotated_x(InputXY, OffsetXY, RotationName)
        End Function


        Public Shared Function MyRotated_1a(IndexSymbol As Int32, RotationName As String) As MyPointStructure
            MyTrace(24, "MyRotated_1a", 23 - 16)

            Dim InputXY As MyPointStructure
            MyCheckIndexs(0, IndexSymbol, 0, 0, 0)
            InputXY.X = Symbol_TableX1(IndexSymbol)
            InputXY.Y = Symbol_TableY1(IndexSymbol)
            MyRotated_1a = MyRotated_x(InputXY, ZeroZero, RotationName)
        End Function




        Public Shared Function MyRotated_2(IndexSymbol As Int32, IndexFlowChart As Int32, RotationName As String) As MyPointStructure
            Dim InputXY As MyPointStructure
            Dim OffsetXY As MyPointStructure
            MyTrace(25, "MyRotated_2", 10)

            MyCheckIndexs(IndexFlowChart, IndexSymbol, 0, 0, 0)
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
            InputXY.X = Symbol_TableX2_io(IndexSymbol)
            InputXY.Y = Symbol_TableY2_dt(IndexSymbol)
            OffsetXY.X = FlowChart_TableX1(IndexFlowChart)
            OffsetXY.Y = FlowChart_TableY1(IndexFlowChart)
            MyRotated_2 = MyRotated_x(InputXY, OffsetXY, RotationName)
        End Function

        Public Shared Function MyRotated_2(IndexSymbol As Int32, OffsetXY As MyPointStructure, RotationName As String) As MyPointStructure
            MyTrace(26, "MyRotated_2", 45 - 38)

            Dim InputXY As MyPointStructure
            MyCheckIndexs(0, IndexSymbol, 0, 0, 0)
            FindingMyBugs(10) 'hace Least amount of checking here 'hack
            InputXY.X = Symbol_TableX2_io(IndexSymbol)
            InputXY.Y = Symbol_TableY2_dt(IndexSymbol)
            MyRotated_2 = MyRotated_x(InputXY, OffsetXY, RotationName)
        End Function

        Public Shared Function FlipFlop(WhichOne As Int32, Index As Int32) As Int32
            Dim Temp As String
            MyTrace(27, "FlipFlop", 57 - 47)

            If Index = -1 Then Index = 0
            Temp = SymbolScreen.ToolStripDropDownRotation.DropDownItems.Item(Index).ToString
            Pop(Temp, ConstantDelimeters) ' Get rid of name
            FlipFlop = Popvalue(Temp) : If WhichOne = 1 Then Exit Function
            FlipFlop = Popvalue(Temp) : If WhichOne = 2 Then Exit Function
            FlipFlop = Popvalue(Temp) : If WhichOne = 3 Then Exit Function
            FlipFlop = Popvalue(Temp) : If WhichOne = 4 Then Exit Function
        End Function


        Public Shared Function MyRotated_x(InputXY As MyPointStructure, OffsetXY As MyPointStructure, RotationName As String) As MyPointStructure
            Dim R As Int32
            MyTrace(28, "My_Rotated_x", 80 - 60)

            R = MyEnumValue(RotationName, SymbolScreen.ToolStripDropDownRotation)
            If R < 0 Or R > 16 Then
                MyMsgCtr("MyRotated_x", 1273, R.ToString, RotationName, "", "", "", "", "", "", "")
                R = 1
            End If
            MyRotated_x.X = InputXY.X * FlipFlop(1, R) + InputXY.Y * FlipFlop(2, R)
            MyRotated_x.Y = InputXY.X * FlipFlop(3, R) + InputXY.Y * FlipFlop(4, R)
            MyRotated_x.X = MyRotated_x.X + OffsetXY.X
            MyRotated_x.Y = MyRotated_x.Y + OffsetXY.Y
        End Function

        Public Shared Sub AddNewSymbol(SymbolName As String)
            Dim IndexNamed, IndexSymbol As Int32
            'First make sure that we are not changing the name to something already there

            IndexNamed = FindiSAM_IN_Table("Named", "Do Not add",
             Named_FileSymbolName,
             Named_File_iSAM,
             SymbolName)
            If IndexNamed > constantMyErrorCode Then Exit Sub 'Name already there so dont add it again

            'If we are then get all of the old information
            ' Second Add it to the Named Table if not already there
            IndexNamed = FindiSAM_IN_Table("Named", "add",
             Named_FileSymbolName,
             Named_File_iSAM,
             SymbolName)
            'third add it to the symbol table If not already therecoded
            IndexSymbol = CInt(FindInSymbolList(SymbolName))
            If IndexSymbol <= 0 Then
                'add in the name record for this symbol
                MyInsertSymbolRecord_Line(NewTopOfFile("Symbol", Symbol_FileCoded),
                                                          SymbolName,
                                                          "/name",
                                                          MyLine1(0, 0, 0, 0),
                                                          "")
            End If
            MyMakeArraySizesBigger()
            '2020 07 17 removed because only the named needs to be sorted, aand is done on insert 'SortALLisam()
            'reget all symbol names (could replace this with only adding the symbol name added
            'GetAllSymbolNames(SymbolName)
            AddSymbolToDropDown(SymbolName)
        End Sub

        Public Shared Sub AddAtomsToKeywordORoperatorsORFunctionList(ByRef MyTable As String, Key As String, ByRef MyArray() As String, PB As ProgressBar)
            Dim I As Int32
            Dim PerCentageFull As Int32 ' percentage as integer
            MyTrace(29, "AddAtomsToKeywordORoperatorsORFunctionList", 55 - 32)

            MyMakeArraySizesBigger()
            If IsNothing(Key) Then ' Never add a blank keyword
                Exit Sub
            End If
            If Key = "" Then ' Never add a blank keyword
                Exit Sub
            End If
            I = FindInSortedLanguageList(MyTable, Trim(Key), MyArray)
            If I <> constantMyErrorCode Then
                Exit Sub ' Never add a duplicate key
            End If


            I = UBound(MyArray) + 1 ' Find the top
            While I > 1 And MyArray(UBound(MyArray)) = Nothing ' Find the top of the data
                I = I - 1
            End While


            If IsNothing(MyArray(I)) Then ' Incase we are the first one
                If I = 1 Then
                    I = 1
                Else
                    I = I + 1
                End If
            Else
                While (I < UBound(MyArray)) And (Not IsNothing(MyArray(I)))
                    If I = UBound(MyArray) Then
                        ReDim Preserve MyArray(I + 1)
                    End If
                    I = I + 1
                End While
            End If

            MyArray(I) = Key ' We should be at an empty one
            ShowSorts(MyTable, ReSortLanguageKeyWords(MyTable, MyArray, I))

            ReDim Preserve MyArray(UBound(MyArray) + 1)

            Application.DoEvents()

            Select Case MyTable
                Case "Functions"
                    PerCentageFull = CInt(100.0 * I / UBound(Language_Functions))
                    FileInputOutputScreen.ProgressBarFunctions.Value = PerCentageFull
                    FileInputOutputScreen.LabelFunctions.Text = "function:" & I & "/" & UBound(Language_Functions)
                Case "Operators"
                    PerCentageFull = CInt(100.0 * I / UBound(Language_Operators))
                    FileInputOutputScreen.ProgressBarOperators.Value = PerCentageFull
                    FileInputOutputScreen.LabelOperators.Text = "Operator:" & I & "/" & UBound(Language_Operators)
                Case "Keywords"
                    PerCentageFull = CInt(100.0 * I / UBound(Language_KeyWords))
                    FileInputOutputScreen.ProgressBarKeyWords.Value = PerCentageFull
                    FileInputOutputScreen.LabelKeyWords.Text = "Function:" & I & "/" & UBound(Language_KeyWords)
            End Select
            Application.DoEvents()
        End Sub

        'Routine  Sets up (and resets) the orginal values for all parameters (for new, open, and next level file)
        Public Shared Sub Init() ' Load all Starting list, combobox(s) and other Information(s)
            Dim D As SByte
            Dim I As Int32
            Dim II, Idex As Int32

            SplashScreen.Visible = True

            MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME = "BLACK"
            MyUniverse.SysGen.outputfilename1 = "\Dump1.txt"
            MyUniverse.SysGen.outputfilename2 = "\Dump2.txt"
            MyUniverse.SysGen.outputfilename3 = "\Dump3.txt"

            MyUniverse.SysGen.RMStart = "{[("
            MyUniverse.SysGen.RMEnd = ")]}"

            MyUniverse.SysGen.ConstantQuote = " " & Chr(34) & " " ' Put white space around quotes 2020 08 20
            MyUniverse.SysGen.ConstantQuotes = MyUniverse.SysGen.RMStart & Chr(34) & Chr(34) & MyUniverse.SysGen.RMEnd '<"">
            MyUniverse.SysGen.ConstantVariable = MyUniverse.SysGen.RMStart & "Variable" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantNumber = MyUniverse.SysGen.RMStart & "Number" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantAlpha = MyUniverse.SysGen.RMStart & "Alpha" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantSpecialCharacter = MyUniverse.SysGen.RMStart & "Special" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantGoToNextLineSyntax = MyUniverse.SysGen.RMStart & "GoToNextLine" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantCameFromLastLineSyntax = MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.ConstantComment = MyUniverse.SysGen.RMStart & "Comment" & MyUniverse.SysGen.RMEnd

            ReDim MyUniverse.SysGen.SyntaxFormats(25)
            MyUniverse.SysGen.SyntaxFormats(0) = MyUniverse.SysGen.RMStart & "'" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(1) = MyUniverse.SysGen.RMStart & "|" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(2) = MyUniverse.SysGen.RMStart & "~" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(3) = MyUniverse.SysGen.RMStart & "!" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(4) = MyUniverse.SysGen.RMStart & "@" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(5) = MyUniverse.SysGen.RMStart & "%" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(6) = MyUniverse.SysGen.RMStart & "&" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(7) = MyUniverse.SysGen.RMStart & "*" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(8) = MyUniverse.SysGen.RMStart & "_" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(9) = MyUniverse.SysGen.RMStart & "-" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(10) = MyUniverse.SysGen.RMStart & "+" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(11) = MyUniverse.SysGen.RMStart & "=" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(12) = MyUniverse.SysGen.RMStart & "{" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(13) = MyUniverse.SysGen.RMStart & "[" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(14) = MyUniverse.SysGen.RMStart & "}" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(15) = MyUniverse.SysGen.RMStart & "]" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(16) = MyUniverse.SysGen.RMStart & "\" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(17) = MyUniverse.SysGen.RMStart & ":" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(18) = MyUniverse.SysGen.RMStart & ";" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(19) = MyUniverse.SysGen.RMStart & "'" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(20) = MyUniverse.SysGen.RMStart & "<" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(21) = MyUniverse.SysGen.RMStart & "," & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(22) = MyUniverse.SysGen.RMStart & ">" & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(23) = MyUniverse.SysGen.RMStart & "." & MyUniverse.SysGen.RMEnd
            MyUniverse.SysGen.SyntaxFormats(24) = MyUniverse.SysGen.RMStart & "/" & MyUniverse.SysGen.RMEnd


            MyUniverse.SysGen.ConstantSymbolCenter = 250
            MyUniverse.SysGen.ConstantSpacingFactor = 20

            MyUniverse.SysGen.ConstantMinPenSize = 4
            MyUniverse.SysGen.ConstantMaxPenSize = 25

            MyUniverse.SysGen.ConstantMinBoxSize = 100
            MyUniverse.SysGen.ConstantFirstLineTextOffset = 50
            MyUniverse.SysGen.ConstantSecondLineTextOffset = 100
            MyUniverse.SysGen.ConstantDistanceBetweenControls = 5
            MyUniverse.SysGen.ConstantRecordsBeforeSaveIsAllowed = 0
            MyUniverse.SysGen.ConstantDistanceToMovePaths = 101
            MyUniverse.SysGen.ConstantSpecialCharacters = "`~!@#$%^&*()_-+={[}]|\:;, '<,>.?/" & Chr(34)


            MyUniverse.SysGen.MaxSymbolInYSpacing = 100000

            'Load the options here
            For I = 1 To 32
                OptionScreen.CheckedListBoxOptionSelection.Items.Add(Str(I), CheckState.Unchecked)
            Next


            I = 0 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Check List"
            I = 1 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display PointNames" : OptionScreen.CheckedListBoxOptionSelection.SetItemCheckState(I, CheckState.Checked)
            I = 2 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display SymbolName" : OptionScreen.CheckedListBoxOptionSelection.SetItemCheckState(I, CheckState.Checked)
            I = 3 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display IDStroke"
            I = 4 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display FileName"
            I = 5 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display Notes"
            I = 6 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display OpCode"
            I = 7 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display Code"
            I = 8 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display Index Short Cut Pointer"
            I = 9 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display ErrorText"
            I = 10 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display InputOutPut"
            I = 11 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display ????"
            I = 12 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display PathNames" : OptionScreen.CheckedListBoxOptionSelection.SetItemCheckState(I, CheckState.Checked)
            I = 13 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display Constants"
            I = 14 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Make Paths Orthogonal"
            I = 15 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Move Symbols from on top of each other"
            I = 16 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Output Line Numbers"
            I = 17 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Display Data Value on Paths"
            I = 18 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 18"
            I = 19 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 19"
            I = 20 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 20"
            I = 21 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 21"
            I = 22 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 22"
            I = 23 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 23"
            I = 24 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 24"
            I = 25 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 25"
            I = 26 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 26"
            I = 27 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 27"
            I = 28 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 28"
            I = 29 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "Reserved 29"
            I = 30 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "write warning and errors"
            I = 31 : OptionScreen.CheckedListBoxOptionSelection.Items(I) = "internal Testing"


            MyUniverse.SysGen.NumberOfButtonsActive = 1 'Init causes it to reset
            MyTrace(31, "Init", 2241 - 1483)

            GetMyPen = Pens.Black
            'Make sure all of te forms are loaded. 
            'flow10' Can I not do this yet?            ShowAllForms(ShowScreen, ShowScreen, ShowScreen, ShowScreen, ShowScreen, ShowScreen)
            'flow10' can I not do this yet?            ShowAllForms(HideScreen, HideScreen, HideScreen, ShowScreen, HideScreen, HideScreen)
            ' Need to remove the second parameter and replace it with the actual location when it is found(Looked for)
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Clear()
            '0 Computer language name
            '1 Case sensitive'IGNORING FOR NOW
            '2 in line comment
            '3 extension 
            '4 Statement on same line
            '5 line-continuation character 
            '6 Additional Characters allowed in Names  
            '7 Goto syntax format rmstart & "(" & myuniverse.sysgen.rmEnd
            '8 CameFrom syntax format (alisa for label, line number, etc) rmstart & ")" & myuniverse.sysgen.rmEnd
            '9 Option number list
            '10 reserved
            '            SymbolScreen.ComboBox_Language_Table.Items.Add(" Computer language name" & FD & "Case sensitive" & FD & "in line comment" & FD & "extension " & FD & "Statement on same line" & FD & "line-continuation character " & FD & "Additional Characters allowed in Names  " & FD & "Goto syntax format" & RMStart & " ? " & myuniverse.sysgen.rmEnd & FD & "CameFrom syntax format" & RMStart & " ? " & myuniverse.sysgen.rmEnd & FD & "Option number list" & FD & "-")
            'OptionScreen.ToolStripDropDownComputerLanguageX.DropDownItems.Add("(Language)" & FD & "(case)" & FD & "(comment)" & FD & "(.ext)" & FD & "(SameLine)" & FD & "(Continue Next)" & FD & "(In Names)" & FD & "(end Goto)" & FD & "(start CameFrom)" & FD & "(reserved)" & FD & "(reserved)")
            '                                       (Language)        (case)    (comment)  (.ext)   (SameLine)(Continue Next)(In Names) (end Goto)       (start CameFrom)         (reserved)(reserved)
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Assembly" & FD & "No" & FD & " ; " & FD & "asm" & FD & vbCrLf & FD & "`" & FD & "_" & FD & "jmp " & MyUniverse.SysGen.RMStart & "variable" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "variable" & MyUniverse.SysGen.RMEnd & ":" & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Bash" & FD & "`" & FD & "#" & FD & "sh" & FD & "`" & FD & "\" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & " CameFromLastLine " & MyUniverse.SysGen.RMStart & "variable" & MyUniverse.SysGen.RMEnd & " " & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Basic" & FD & "No" & FD & "REM" & FD & "bas" & FD & ":" & FD & "_" & FD & "$#_" & FD & " GoTo " & MyUniverse.SysGen.RMStart & "number" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "number" & MyUniverse.SysGen.RMEnd & " " & FD & "`" & FD & "`")
            '                                       (Language)    (case)    (comment)    (.ext) (SameLine)(Continue Next) (In Names)   (end Goto)       (start CameFrom)         (reserved)(reserved)
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("C" & FD & "Yes" & FD & "//" & FD & "C" & FD & "`" & FD & "\" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("C#" & FD & "Yes" & FD & "//" & FD & "CS" & FD & "`" & FD & "_" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("C++" & FD & "Yes" & FD & "`" & FD & "CPP" & FD & "`" & FD & "\" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("COBOL" & FD & "Yes" & FD & "Comment" & FD & "COBOL" & FD & "`" & FD & "`" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Clojure" & FD & "no" & FD & "`" & FD & "Clj" & FD & "`" & FD & "`" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`") 'Lisp like
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Dart" & FD & "`" & FD & "//" & FD & "Dart" & FD & "`" & FD & "`" & FD & "$_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Dos" & FD & "No" & FD & "REM " & FD & "bat" & FD & "`" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Elixir" & FD & "`" & FD & "#" & FD & "EX" & FD & "`" & FD & "`" & FD & "?!" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Forth" & FD & "No" & FD & "/" & FD & "Forth" & FD & "`" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Fortran" & FD & "Yes" & FD & "/" & FD & "ftn" & FD & "`" & FD & ";" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Generic" & FD & "No" & FD & ";'Comment" & FD & "txt" & FD & "`" & FD & "`" & FD & "_$#" & FD & " GoToNextLine " & MyUniverse.SysGen.ConstantGoToNextLineSyntax & FD & vbCrLf & MyUniverse.SysGen.ConstantCameFromLastLineSyntax & ": " & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Go" & FD & "Both" & FD & "// " & FD & "C" & FD & "`" & FD & ":" & FD & "?" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`") 'Example for later
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("PowerShell" & FD & "`" & FD & "//" & FD & "PSD" & FD & "`" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Java" & FD & "Yes" & FD & "//" & FD & "Java" & FD & ";" & FD & "`" & FD & "$" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("JavaScript" & FD & "Yes" & FD & "//" & FD & "js" & FD & ";" & FD & "`" & FD & "$" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Kotlin" & FD & "`" & FD & "//" & FD & "kt" & FD & ";" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Lisp" & FD & "`" & FD & ";" & FD & "lisp" & FD & "`" & FD & "`" & FD & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("ObjectiveC" & FD & "Yes" & FD & "`" & FD & "C" & FD & ";" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Pascal" & FD & "No" & FD & "`" & FD & "pascal" & FD & ";" & FD & "`" & FD & "!%]$" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Perl" & FD & "`" & FD & "/" & FD & "perl" & FD & ";" & FD & "`" & FD & "$" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("PHP" & FD & "Yes" & FD & "//" & FD & "PHP" & FD & ";" & FD & "`" & FD & "$" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Python" & FD & "Yes" & FD & "# " & FD & "py" & FD & "\" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("R" & FD & "`" & FD & "<!-- [Notes] -->" & FD & "r" & FD & "`" & FD & "`" & FD & "._" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Ruby" & FD & "Yes" & FD & "#" & FD & "rb" & FD & ":" & FD & "`" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Rust" & FD & "`" & FD & "//" & FD & "rs" & FD & ";" & FD & "`" & FD & "_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Scala" & FD & "`" & FD & "//" & FD & "sc" & FD & ";" & FD & "`" & FD & "$_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("SQL" & FD & "No" & FD & "--" & FD & "SQL" & FD & "`" & FD & "`" & FD & "$_" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("Swift" & FD & "Yes" & FD & "//" & FD & "swift" & FD & ";" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("TypeScript" & FD & "`" & FD & "//" & FD & "ts" & FD & "`" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("VBA" & FD & "No" & FD & "'" & FD & "Bas" & FD & ":" & FD & "_" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")
            OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add("WebAssembly" & FD & "Yes" & FD & ";;" & FD & "Wasm" & FD & "`" & FD & "`" & FD & "`" & FD & " " & MyUniverse.SysGen.RMStart & "GotoNextLine" & MyUniverse.SysGen.RMEnd & " " & FD & MyUniverse.SysGen.RMStart & "CameFromLastLine" & MyUniverse.SysGen.RMEnd & FD & "`" & FD & "`")


            '            OptionScreen.ToolStripDropDownComputerLanguageX.SelectedIndex = 14 ' Generic
            'flow10'removed            SelectInToolStripDropDownButton(OptionScreen.ToolStripDropDownComputerLanguageX, "NoLanguageSelected")
            Application.DoEvents()


            AddAtomsToKeywordORoperatorsORFunctionList("Functions", MyConstantIgnoreFunctionOperatorsKeywords & "Functions", Language_Functions, FileInputOutputScreen.ProgressBarFunctions)
            AddAtomsToKeywordORoperatorsORFunctionList("Operators", MyConstantIgnoreFunctionOperatorsKeywords & "Operators", Language_Operators, FileInputOutputScreen.ProgressBarOperators)
            AddAtomsToKeywordORoperatorsORFunctionList("Keywords", MyConstantIgnoreFunctionOperatorsKeywords & "Keywords", Language_KeyWords, FileInputOutputScreen.ProgressBarKeyWords)


            DrillDown_FileName = "*"
            '
            My_KeyWords(My_KeyConstUnknown) = "/unknown"
            My_KeyWords(My_KeyConstName) = "/name"            'symbol
            My_KeyWords(My_KeyConstPoint) = "/point"           'symbol
            My_KeyWords(My_KeyConstLine) = "/line"            'symbol
            My_KeyWords(My_KeyConstUse) = "/use"             'FlowChart
            My_KeyWords(My_KeyConstPath) = "/path"            'FlowChart
            My_KeyWords(My_KeyConstDataType) = "/datatype"        '
            My_KeyWords(My_KeyConstFileName) = "/filename"        'symbol
            My_KeyWords(My_KeyConstVersion) = "/version"         'symbol
            My_KeyWords(My_KeyConstAuthor) = "/author"          'symbol
            My_KeyWords(My_KeyConstLanguage) = "/language"        '
            My_KeyWords(My_KeyConstStroke) = "/stroke"         'symbol
            My_KeyWords(My_KeyConstError) = "/error"           'FlowChart
            My_KeyWords(My_KeyConstDelete) = "/delete"          'FlowChart
            My_KeyWords(My_KeyConstConstant) = "/constant" 'FlowChart
            My_KeyWords(My_KeyConstX1) = "/x1" 'not required
            My_KeyWords(My_KeyConstY1) = "/y1" 'not required
            My_KeyWords(My_KeyConstX2) = "/x2" 'not required
            My_KeyWords(My_KeyConstY2) = "/y2" 'not required
            My_KeyWords(My_KeyConstColor) = "/color" '
            My_KeyWords(My_KeyConstprogramtext) = "/programtext" 'symbol
            My_KeyWords(My_KeyConstNotes) = "/notes" 'symbol
            My_KeyWords(My_KeyConstOpcode) = "/opcode" 'symbol
            My_KeyWords(My_KeyConstThisCode) = "/thiscode"
            My_KeyWords(My_KeyConstOption) = "/option"
            My_KeyWords(My_KeyConstLanguageKeyWord) = "/keyword"
            My_KeyWords(My_KeyConstprogramtext) = "/ProgramText" 'symbol
            'My_KeyWords(My_KeyConstUnused29) = "/unknown_29" 'Future
            'My_KeyWords(My_KeyConstUnused30) = "/unknown_30" 'Future
            'My_KeyWords(My_KeyConstUnused31) = "/unknown_31" 'Future
            'My_KeyWords(My_KeyConstUnused32) = "/unknown_32" 'Future


            DoOption(51, "on", "")

            MyUniverse.MyCheatSheet.ColorsSorted = 0 ' Flagged as nothing to sort.
            MyUniverse.MyCheatSheet.DataTypeSorted = 0
            MyUniverse.MyCheatSheet.NamedSorted = 0
            MyUniverse.MyCheatSheet.FlowChartSorted = 0

            MyAddErrorMessages()
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("both, 3")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("input, 1")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("All, 0")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("optionalboth, 6")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("optionalinput, 4")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("optionaloutput, 5")
            SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Add("output, 2")

            'SupportTables (Unchangable)
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Add("Dash, 1")
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Add("DashDot, 3")
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Add("DashDotDot, 4")
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Add("Dot, 2")
            SymbolScreen.ToolStripDropDownPathLineStyle.DropDownItems.Add("Solid, 0")

            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("AnchorMask, 240")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("ArrowAnchor, 20")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("DiamondAnchor, 19")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("Flat, 0")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("NoAnchor, 16")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("Round, 2")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("RoundAnchor, 18")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("Square, 1")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("SquareAnchor, 17")
            SymbolScreen.ToolStripDropDownPathStart.DropDownItems.Add("Triangle, 3")

            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("AnchorMask, 240")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("ArrowAnchor, 20")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("DiamondAnchor, 19")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("Flat, 0")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("NoAnchor, 16")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("Round, 2")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("RoundAnchor, 18")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("Square, 1")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("SquareAnchor, 17")
            SymbolScreen.ToolStripDropDownPathEnd.DropDownItems.Add("Triangle, 3")


            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Default, 1 , 0 , 0 , 1, ^. Flips to  ^. Stays the same ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Flip, -1 , 0 , 0 , 1, ^. Flips to  v. sideways flip ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Flop, 1 , 0 , 0 , -1, ^. Flips to  v. top side flips down ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Rotate90 , 0 , 1 , -1 , 0, ^. Flips to  > rotate 90 degrees period on bottom")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Rotate180 , -1 , 0 , 0 , -1, ^. Flips to  .v rotate 180")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("Rotate270, 0 , -1 , 1 , 0, ^. Flips to  < rotate 270 ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlipRotate90, 0 , -1 , 1 , 0, ^. Flips to  > period on top flip then rotate 90 ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlipRotate180, 1 , 0 , 0 , -1, ^. Flips to  v. flip then rotate 180 (mirror image of) ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlipRotate270 , 0 , -1 , -1 , 0, ^. Flips to  < Period on bottom ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlopRotate90 , 0 , -1 , -1 , 0, ^. Flips to  > period on bottom Same as ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlopRotate180, -1 , 0 , 0 , 1, ^. Flips to  .^ same as flip rotate180 ")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlopRotate270 , 0 , 1 , 1 , 0, ^. Flips to  ^. period on top")
            SymbolScreen.ToolStripDropDownRotation.DropDownItems.Add("FlipFlop, 0 , -1 , -1 , 0, ^. Flips to  ^. same as rotate180 ")



            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("0")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("1")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("2")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("4")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("8")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("16")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("32")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("64")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("128")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("256")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("512")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("1024")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("2048")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("4096")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("8192")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("16384")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("32768")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("65536")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("131072")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("262144")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("524288")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("1048576")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("2097152")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("4194304")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("8388608")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("16777216")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("33554432")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("67108864")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("134217728")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("268435456")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("536870912")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("1073741824")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("2147483648")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("4294967296")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("8589934592")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("17179869184")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("17179869184")
            SymbolScreen.ToolStripDropDownNumberOfBytes.DropDownItems.Add("34359738378")




            SymbolScreen.ToolStripDropDownLineWidth.DropDownItems.Clear()
            For II = 0 To 50
                SymbolScreen.ToolStripDropDownLineWidth.DropDownItems.Add(Str(II))
            Next II


            ' Orginal changed for testing.
            D = 0 : MyDirections(D, 1, 1) = -10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = 10 : MyDirections(D, 2, 2) = -10 'No Direction
            D = 1 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10 '-10  '
            D = 2 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  'NorthEast

            D = 3 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = 10 : MyDirections(D, 2, 2) = -10 '
            D = 4 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = 10 : MyDirections(D, 2, 2) = -10 'Right
            D = 5 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = 10 : MyDirections(D, 2, 2) = -10 '

            D = 6 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = 10  '
            D = 7 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = 10  '
            D = 8 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = 10  'Bottom
            D = 9 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = 10  '
            D = 10 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = 10  '

            D = 11 : MyDirections(D, 1, 1) = -10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  '
            D = 12 : MyDirections(D, 1, 1) = -10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  'Left
            D = 13 : MyDirections(D, 1, 1) = -10 : MyDirections(D, 1, 2) = 10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  '

            D = 14 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  '
            D = 15 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  '
            D = 16 : MyDirections(D, 1, 1) = 10 : MyDirections(D, 1, 2) = -10 : MyDirections(D, 2, 1) = -10 : MyDirections(D, 2, 2) = -10  'Top


            MyUniverse.SysGen.MySnap = 50 'It's fixed for now, but should be an option
            MyUniverse.MyMouseAndDrawing.PaintThisOrEraseThis = True


            ' almost a constant
            ZeroZero.X = 0
            ZeroZero.Y = 0

            MyUniverse.SysGen.HighestSymbolNumber = CInt(Rnd(1000)) * 1000 + 100
            'Popvalue(Mid(TimeString, 7, 2) & Mid(TimeString, 4, 2) & Mid(TimeString, 1, 2))

            MyUniverse.SysGen.MinBox = MyUniverse.SysGen.ConstantMinBoxSize
            MyUniverse.SysGen.MyScale = 0.0625 '1=1,    1/2=.5,     1/4=.25,    1/8=.125,       1/16=.0625
            LimitScale()
            MyUniverse.SysGen.Size.X = 1000
            MyUniverse.SysGen.Size.Y = 1000

            SymbolScreen.ToolStripDropDownButtonColor.DropDownItems.Clear()
            ' Known Colors right now. (Can/Should be added to with Alpha/Red/Green/Blue (Later))
            ImportColors(“AliceBlue" & FD & "255" & FD & "240" & FD & "248" & FD & "255" & FD & "DashDotDot" & FD & "Triangle" & FD & "RoundAnchor“)
            ImportColors(“AntiqueWhite" & FD & "255" & FD & "250" & FD & "235" & FD & "215" & FD & "DashDot" & FD & "RoundAnchor" & FD & "ArrowAnchor“)
            ImportColors(“aqua" & FD & "255" & FD & "1" & FD & "255" & FD & "255" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“aquamarine" & FD & "255" & FD & "127" & FD & "255" & FD & "212" & FD & "DashDotDot" & FD & "Round" & FD & "NoAnchor“)
            ImportColors(“Azure" & FD & "255" & FD & "240" & FD & "255" & FD & "255" & FD & "DashDot" & FD & "flat" & FD & "NoAnchor“)
            ImportColors(“beige" & FD & "255" & FD & "245" & FD & "245" & FD & "220" & FD & "Dot" & FD & "flat" & FD & "Square“)
            ImportColors(“bisque" & FD & "255" & FD & "255" & FD & "228" & FD & "196" & FD & "DashDotDot" & FD & "DiamondAnchor" & FD & "SquareAnchor“)
            ImportColors(“Black" & FD & "255" & FD & "1" & FD & "1" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“BlanchedAlmond" & FD & "255" & FD & "255" & FD & "235" & FD & "205" & FD & "Dash" & FD & "DiamondAnchor" & FD & "Triangle“)
            ImportColors(“Blue" & FD & "255" & FD & "1" & FD & "1" & FD & "255" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“BlueViolet" & FD & "255" & FD & "138" & FD & "43" & FD & "226" & FD & "DashDotDot" & FD & "Triangle" & FD & "SquareAnchor“)
            ImportColors(“Brown" & FD & "255" & FD & "165" & FD & "42" & FD & "42" & FD & "Dash" & FD & "NoAnchor" & FD & "flat“)
            ImportColors(“BurlyWood" & FD & "255" & FD & "222" & FD & "184" & FD & "135" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "NoAnchor“)
            ImportColors(“CadetBlue" & FD & "255" & FD & "95" & FD & "158" & FD & "160" & FD & "DashDot" & FD & "NoAnchor" & FD & "flat“)
            ImportColors(“Chartreuse" & FD & "255" & FD & "127" & FD & "255" & FD & "1" & FD & "Dash" & FD & "DiamondAnchor" & FD & "Round“)
            ImportColors(“Chocolate" & FD & "255" & FD & "210" & FD & "105" & FD & "30" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "Square“)
            ImportColors(“Coral" & FD & "255" & FD & "255" & FD & "127" & FD & "80" & FD & "DashDot" & FD & "NoAnchor" & FD & "flat“)
            ImportColors(“CornflowerBlue" & FD & "255" & FD & "100" & FD & "149" & FD & "237" & FD & "Dot" & FD & "RoundAnchor" & FD & "SquareAnchor“)
            ImportColors(“Cornsilk" & FD & "255" & FD & "255" & FD & "248" & FD & "220" & FD & "DashDotDot" & FD & "RoundAnchor" & FD & "NoAnchor“)
            ImportColors(“Crimson" & FD & "255" & FD & "220" & FD & "20" & FD & "60" & FD & "DashDot" & FD & "Round" & FD & "NoAnchor“)
            ImportColors(“Cyan" & FD & "255" & FD & "1" & FD & "255" & FD & "255" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“DarkBlue" & FD & "255" & FD & "1" & FD & "1" & FD & "139" & FD & "Dot" & FD & "flat" & FD & "SquareAnchor“)
            ImportColors(“DarkCyan" & FD & "255" & FD & "1" & FD & "139" & FD & "139" & FD & "DashDotDot" & FD & "Round" & FD & "flat“)
            ImportColors(“DarkGoldenrod" & FD & "255" & FD & "184" & FD & "134" & FD & "11" & FD & "DashDot" & FD & "Square" & FD & "NoAnchor“)
            ImportColors(“DarkGray" & FD & "255" & FD & "169" & FD & "169" & FD & "169" & FD & "Dash" & FD & "Square" & FD & "flat“)
            ImportColors(“DarkGreen" & FD & "255" & FD & "1" & FD & "100" & FD & "1" & FD & "Dot" & FD & "Triangle" & FD & "NoAnchor“)
            ImportColors(“DarkKhaki" & FD & "255" & FD & "189" & FD & "183" & FD & "107" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "SquareAnchor“)
            ImportColors(“DarkMagenta" & FD & "255" & FD & "139" & FD & "1" & FD & "139" & FD & "DashDot" & FD & "RoundAnchor" & FD & "DiamondAnchor“)
            ImportColors(“DarkOliveGreen" & FD & "255" & FD & "85" & FD & "107" & FD & "47" & FD & "Dash" & FD & "DiamondAnchor" & FD & "RoundAnchor“)
            ImportColors(“DarkOrange" & FD & "255" & FD & "255" & FD & "140" & FD & "1" & FD & "Dot" & FD & "Triangle" & FD & "RoundAnchor“)
            ImportColors(“DarkOrchid" & FD & "255" & FD & "153" & FD & "50" & FD & "204" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "Round“)
            ImportColors(“DarkRed" & FD & "255" & FD & "139" & FD & "1" & FD & "1" & FD & "DashDot" & FD & "DiamondAnchor" & FD & "Round“)
            ImportColors(“DarkSalmon" & FD & "255" & FD & "233" & FD & "150" & FD & "122" & FD & "Dot" & FD & "Square" & FD & "Square“)
            ImportColors(“DarkSeaGreen" & FD & "255" & FD & "143" & FD & "188" & FD & "139" & FD & "DashDotDot" & FD & "flat" & FD & "SquareAnchor“)
            ImportColors(“DarkSlateBlue" & FD & "255" & FD & "72" & FD & "61" & FD & "139" & FD & "DashDot" & FD & "NoAnchor" & FD & "DiamondAnchor“)
            ImportColors(“DarkSlateGray" & FD & "255" & FD & "47" & FD & "79" & FD & "79" & FD & "Dash" & FD & "Square" & FD & "Triangle“)
            ImportColors(“DarkTurquoise" & FD & "255" & FD & "1" & FD & "206" & FD & "209" & FD & "Dot" & FD & "Square" & FD & "Square“)
            ImportColors(“DarkViolet" & FD & "255" & FD & "148" & FD & "1" & FD & "211" & FD & "DashDotDot" & FD & "Triangle" & FD & "DiamondAnchor“)
            ImportColors(“DataTypeError" & FD & "255" & FD & "255" & FD & "1" & FD & "1" & FD & "DashDotDot" & FD & "Triangle" & FD & "DiamondAnchor“)
            ImportColors(“DeepPink" & FD & "255" & FD & "255" & FD & "20" & FD & "147" & FD & "DashDot" & FD & "Square" & FD & "flat“)
            ImportColors(“DeepSkyBlue" & FD & "255" & FD & "1" & FD & "191" & FD & "255" & FD & "Dash" & FD & "NoAnchor" & FD & "flat“)
            ImportColors(“DimGray" & FD & "255" & FD & "105" & FD & "105" & FD & "105" & FD & "Dot" & FD & "NoAnchor" & FD & "Square“)
            ImportColors(“DodgerBlue" & FD & "255" & FD & "30" & FD & "144" & FD & "255" & FD & "DashDotDot" & FD & "Triangle" & FD & "ArrowAnchor“)
            ImportColors(“Firebrick" & FD & "255" & FD & "178" & FD & "34" & FD & "34" & FD & "DashDot" & FD & "Round" & FD & "Triangle“)
            ImportColors(“FloralWhite" & FD & "255" & FD & "255" & FD & "250" & FD & "240" & FD & "Dash" & FD & "Triangle" & FD & "flat“)
            ImportColors(“ForestGreen" & FD & "255" & FD & "34" & FD & "139" & FD & "34" & FD & "Dot" & FD & "NoAnchor" & FD & "Triangle“)
            ImportColors(“Fuchsia" & FD & "255" & FD & "255" & FD & "1" & FD & "255" & FD & "DashDotDot" & FD & "SquareAnchor" & FD & "Round“)
            ImportColors(“Gainsboro" & FD & "255" & FD & "220" & FD & "220" & FD & "220" & FD & "Dash" & FD & "Round" & FD & "ArrowAnchor“)
            ImportColors(“GhostWhite" & FD & "255" & FD & "248" & FD & "248" & FD & "255" & FD & "Dot" & FD & "NoAnchor" & FD & "SquareAnchor“)
            ImportColors(“Gold" & FD & "255" & FD & "255" & FD & "215" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Goldenrod" & FD & "255" & FD & "218" & FD & "165" & FD & "32" & FD & "DashDot" & FD & "NoAnchor" & FD & "SquareAnchor“)
            ImportColors(“Gray" & FD & "255" & FD & "128" & FD & "128" & FD & "128" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Green" & FD & "255" & FD & "1" & FD & "128" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“GreenYellow" & FD & "255" & FD & "173" & FD & "255" & FD & "47" & FD & "DashDot" & FD & "NoAnchor" & FD & "NoAnchor“)
            ImportColors(“Honeydew" & FD & "255" & FD & "240" & FD & "255" & FD & "240" & FD & "Dash" & FD & "ArrowAnchor" & FD & "NoAnchor“)
            ImportColors(“HotPink" & FD & "255" & FD & "255" & FD & "105" & FD & "180" & FD & "Dot" & FD & "SquareAnchor" & FD & "NoAnchor“)
            ImportColors(“IndianRed" & FD & "255" & FD & "205" & FD & "92" & FD & "92" & FD & "DashDot" & FD & "Triangle" & FD & "NoAnchor“)
            ImportColors(“Indigo" & FD & "255" & FD & "75" & FD & "1" & FD & "130" & FD & "Dash" & FD & "ArrowAnchor" & FD & "NoAnchor“)
            ImportColors(“Ivory" & FD & "255" & FD & "255" & FD & "255" & FD & "240" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Khaki" & FD & "255" & FD & "240" & FD & "230" & FD & "140" & FD & "DashDotDot" & FD & "flat" & FD & "Round“)
            ImportColors(“Lavender" & FD & "255" & FD & "230" & FD & "230" & FD & "250" & FD & "DashDot" & FD & "RoundAnchor" & FD & "SquareAnchor“)
            ImportColors(“LavenderBlush" & FD & "255" & FD & "255" & FD & "240" & FD & "245" & FD & "Dash" & FD & "RoundAnchor" & FD & "ArrowAnchor“)
            ImportColors(“LawnGreen" & FD & "255" & FD & "124" & FD & "252" & FD & "1" & FD & "Dot" & FD & "SquareAnchor" & FD & "ArrowAnchor“)
            ImportColors(“LemonChiffon" & FD & "255" & FD & "255" & FD & "250" & FD & "205" & FD & "DashDot" & FD & "Triangle" & FD & "RoundAnchor“)
            ImportColors(“LightBlue" & FD & "255" & FD & "173" & FD & "216" & FD & "230" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "flat“)
            ImportColors(“LightCoral" & FD & "255" & FD & "240" & FD & "128" & FD & "128" & FD & "DashDot" & FD & "flat" & FD & "NoAnchor“)
            ImportColors(“LightCyan" & FD & "255" & FD & "224" & FD & "255" & FD & "255" & FD & "Dash" & FD & "flat" & FD & "Round“)
            ImportColors(“LightGoldenrodYellow" & FD & "255" & FD & "250" & FD & "250" & FD & "210" & FD & "Dot" & FD & "Triangle" & FD & "Square“)
            ImportColors(“LightGray" & FD & "255" & FD & "211" & FD & "211" & FD & "211" & FD & "DashDotDot" & FD & "RoundAnchor" & FD & "Square“)
            ImportColors(“LightGreen" & FD & "255" & FD & "144" & FD & "238" & FD & "144" & FD & "DashDot" & FD & "Triangle" & FD & "Round“)
            ImportColors(“LightPink" & FD & "255" & FD & "255" & FD & "182" & FD & "193" & FD & "Dash" & FD & "SquareAnchor" & FD & "NoAnchor“)
            ImportColors(“LightSalmon" & FD & "255" & FD & "255" & FD & "160" & FD & "122" & FD & "Dot" & FD & "Triangle" & FD & "SquareAnchor“)
            ImportColors(“LightSeaGreen" & FD & "255" & FD & "32" & FD & "178" & FD & "170" & FD & "DashDotDot" & FD & "ArrowAnchor" & FD & "flat“)
            ImportColors(“LightSkyBlue" & FD & "255" & FD & "135" & FD & "206" & FD & "250" & FD & "DashDot" & FD & "Triangle" & FD & "NoAnchor“)
            ImportColors(“LightSlateGray" & FD & "255" & FD & "119" & FD & "136" & FD & "153" & FD & "Dot" & FD & "DiamondAnchor" & FD & "RoundAnchor“)
            ImportColors(“LightSteelBlue" & FD & "255" & FD & "176" & FD & "196" & FD & "222" & FD & "DashDotDot" & FD & "RoundAnchor" & FD & "SquareAnchor“)
            ImportColors(“LightYellow" & FD & "255" & FD & "255" & FD & "255" & FD & "224" & FD & "DashDot" & FD & "ArrowAnchor" & FD & "NoAnchor“)
            ImportColors(“Lime" & FD & "255" & FD & "1" & FD & "255" & FD & "1" & FD & "Dash" & FD & "ArrowAnchor" & FD & "Round“)
            ImportColors(“LimeGreen" & FD & "255" & FD & "50" & FD & "205" & FD & "50" & FD & "Dot" & FD & "flat" & FD & "Round“)
            ImportColors(“Linen" & FD & "255" & FD & "250" & FD & "240" & FD & "230" & FD & "DashDotDot" & FD & "Round" & FD & "Triangle“)
            'ImportColors(“Logic"& FD & "255"& FD & "255"& FD & "255"& FD & "255"& FD & "Solid"& FD & "square"& FD & "square“)
            ImportColors(“Magenta" & FD & "255" & FD & "255" & FD & "1" & FD & "255" & FD & "DashDot" & FD & "NoAnchor" & FD & "Triangle“)
            ImportColors(“Maroon" & FD & "255" & FD & "128" & FD & "1" & FD & "1" & FD & "Dot" & FD & "Triangle" & FD & "ArrowAnchor“)
            ImportColors(“MediumAquamarine" & FD & "255" & FD & "102" & FD & "205" & FD & "170" & FD & "Dash" & FD & "SquareAnchor" & FD & "Square“)
            ImportColors(“MediumBlue" & FD & "255" & FD & "1" & FD & "1" & FD & "205" & FD & "Dot" & FD & "NoAnchor" & FD & "Round“)
            ImportColors(“MediumOrchid" & FD & "255" & FD & "186" & FD & "85" & FD & "211" & FD & "DashDotDot" & FD & "ArrowAnchor" & FD & "Round“)
            ImportColors(“MediumPurple" & FD & "255" & FD & "147" & FD & "112" & FD & "219" & FD & "DashDot" & FD & "Square" & FD & "RoundAnchor“)
            ImportColors(“MediumSeaGreen" & FD & "255" & FD & "60" & FD & "179" & FD & "113" & FD & "Dash" & FD & "Triangle" & FD & "NoAnchor“)
            ImportColors(“MediumSlateBlue" & FD & "255" & FD & "123" & FD & "104" & FD & "238" & FD & "Dot" & FD & "SquareAnchor" & FD & "flat“)
            ImportColors(“MediumSpringGreen" & FD & "255" & FD & "1" & FD & "250" & FD & "154" & FD & "DashDot" & FD & "Triangle" & FD & "Triangle“)
            ImportColors(“MediumTurquoise" & FD & "255" & FD & "72" & FD & "209" & FD & "204" & FD & "Dash" & FD & "flat" & FD & "Triangle“)
            ImportColors(“MediumVioletRed" & FD & "255" & FD & "199" & FD & "21" & FD & "133" & FD & "Dot" & FD & "NoAnchor" & FD & "Round“)
            ImportColors(“MidnightBlue" & FD & "255" & FD & "25" & FD & "25" & FD & "112" & FD & "DashDotDot" & FD & "RoundAnchor" & FD & "Square“)
            ImportColors(“MintCream" & FD & "255" & FD & "245" & FD & "255" & FD & "250" & FD & "DashDot" & FD & "RoundAnchor" & FD & "DiamondAnchor“)
            ImportColors(“MistyRose" & FD & "255" & FD & "255" & FD & "228" & FD & "225" & FD & "Dash" & FD & "ArrowAnchor" & FD & "NoAnchor“)
            ImportColors(“Moccasin" & FD & "255" & FD & "255" & FD & "228" & FD & "181" & FD & "Dot" & FD & "Square" & FD & "DiamondAnchor“)
            ImportColors(“NavajoWhite" & FD & "255" & FD & "255" & FD & "222" & FD & "173" & FD & "DashDotDot" & FD & "SquareAnchor" & FD & "NoAnchor“)
            ImportColors(“Navy" & FD & "255" & FD & "1" & FD & "1" & FD & "128" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“OldLace" & FD & "255" & FD & "253" & FD & "245" & FD & "230" & FD & "Dash" & FD & "NoAnchor" & FD & "SquareAnchor“)
            ImportColors(“Olive" & FD & "255" & FD & "128" & FD & "128" & FD & "1" & FD & "Dot" & FD & "Round" & FD & "DiamondAnchor“)
            ImportColors(“OliveDrab" & FD & "255" & FD & "107" & FD & "142" & FD & "35" & FD & "DashDot" & FD & "NoAnchor" & FD & "Square“)
            ImportColors(“Orange" & FD & "255" & FD & "255" & FD & "165" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“OrangeRed" & FD & "255" & FD & "255" & FD & "69" & FD & "1" & FD & "Dot" & FD & "SquareAnchor" & FD & "NoAnchor“)
            ImportColors(“Orchid" & FD & "255" & FD & "218" & FD & "112" & FD & "214" & FD & "DashDotDot" & FD & "Round" & FD & "RoundAnchor“)
            ImportColors(“PaleGoldenrod" & FD & "255" & FD & "238" & FD & "232" & FD & "170" & FD & "Dash" & FD & "SquareAnchor" & FD & "SquareAnchor“)
            ImportColors(“PaleGreen" & FD & "255" & FD & "152" & FD & "251" & FD & "152" & FD & "Dot" & FD & "RoundAnchor" & FD & "DiamondAnchor“)
            ImportColors(“PaleTurquoise" & FD & "255" & FD & "175" & FD & "238" & FD & "238" & FD & "DashDotDot" & FD & "SquareAnchor" & FD & "Triangle“)
            ImportColors(“PaleVioletRed" & FD & "255" & FD & "219" & FD & "112" & FD & "147" & FD & "DashDot" & FD & "ArrowAnchor" & FD & "Square“)
            ImportColors(“PapayaWhip" & FD & "255" & FD & "255" & FD & "239" & FD & "213" & FD & "Dash" & FD & "ArrowAnchor" & FD & "flat“)
            ImportColors(“PeachPuff" & FD & "255" & FD & "255" & FD & "218" & FD & "185" & FD & "Dot" & FD & "Triangle" & FD & "Round“)
            ImportColors(“Peru" & FD & "255" & FD & "205" & FD & "133" & FD & "63" & FD & "DashDotDot" & FD & "Triangle" & FD & "Round“)
            ImportColors(“Pink" & FD & "255" & FD & "255" & FD & "192" & FD & "203" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Plum" & FD & "255" & FD & "221" & FD & "160" & FD & "221" & FD & "Dash" & FD & "DiamondAnchor" & FD & "Round“)
            ImportColors(“PowderBlue" & FD & "255" & FD & "176" & FD & "224" & FD & "230" & FD & "DashDotDot" & FD & "Round" & FD & "Square“)
            ImportColors(“Purple" & FD & "255" & FD & "128" & FD & "1" & FD & "128" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Red" & FD & "255" & FD & "255" & FD & "1" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“RosyBrown" & FD & "255" & FD & "188" & FD & "143" & FD & "143" & FD & "DashDot" & FD & "SquareAnchor" & FD & "NoAnchor“)
            ImportColors(“RoyalBlue" & FD & "255" & FD & "65" & FD & "105" & FD & "225" & FD & "Dash" & FD & "SquareAnchor" & FD & "DiamondAnchor“)
            ImportColors(“SaddleBrown" & FD & "255" & FD & "139" & FD & "69" & FD & "19" & FD & "DashDotDot" & FD & "RoundAnchor" & FD & "Triangle“)
            ImportColors(“Salmon" & FD & "255" & FD & "250" & FD & "128" & FD & "114" & FD & "DashDot" & FD & "RoundAnchor" & FD & "ArrowAnchor“)
            ImportColors(“SandyBrown" & FD & "255" & FD & "244" & FD & "164" & FD & "96" & FD & "Dash" & FD & "RoundAnchor" & FD & "Round“)
            ImportColors(“SeaGreen" & FD & "255" & FD & "46" & FD & "139" & FD & "87" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“SeaShell" & FD & "255" & FD & "255" & FD & "245" & FD & "238" & FD & "DashDotDot" & FD & "Round" & FD & "SquareAnchor“)
            ImportColors(“Sienna" & FD & "255" & FD & "160" & FD & "82" & FD & "45" & FD & "DashDot" & FD & "DiamondAnchor" & FD & "SquareAnchor“)
            ImportColors(“Silver" & FD & "255" & FD & "192" & FD & "192" & FD & "192" & FD & "Dash" & FD & "DiamondAnchor" & FD & "NoAnchor“)
            ImportColors(“SkyBlue" & FD & "255" & FD & "135" & FD & "206" & FD & "235" & FD & "Dot" & FD & "Square" & FD & "NoAnchor“)
            ImportColors(“SlateBlue" & FD & "255" & FD & "106" & FD & "90" & FD & "205" & FD & "DashDot" & FD & "ArrowAnchor" & FD & "RoundAnchor“)
            ImportColors(“SlateGray" & FD & "255" & FD & "112" & FD & "128" & FD & "144" & FD & "Dash" & FD & "Triangle" & FD & "Square“)
            ImportColors(“Snow" & FD & "255" & FD & "255" & FD & "250" & FD & "250" & FD & "Dot" & FD & "flat" & FD & "ArrowAnchor“)
            ImportColors(“SpringGreen" & FD & "255" & FD & "1" & FD & "255" & FD & "127" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "Triangle“)
            ImportColors(“SteelBlue" & FD & "255" & FD & "70" & FD & "130" & FD & "180" & FD & "DashDot" & FD & "NoAnchor" & FD & "Triangle“)
            ImportColors(“Tan" & FD & "255" & FD & "210" & FD & "180" & FD & "140" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Teal" & FD & "255" & FD & "1" & FD & "128" & FD & "128" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Thistle" & FD & "255" & FD & "216" & FD & "191" & FD & "216" & FD & "DashDotDot" & FD & "NoAnchor" & FD & "RoundAnchor“)
            ImportColors(“Tomato" & FD & "255" & FD & "255" & FD & "99" & FD & "71" & FD & "DashDot" & FD & "Round" & FD & "DiamondAnchor“)
            ImportColors(“Transparent" & FD & "1" & FD & "1" & FD & "1" & FD & "1" & FD & "Solid" & FD & "NoAnchor" & FD & "NoAnchor“)
            ImportColors(“Turquoise" & FD & "255" & FD & "64" & FD & "224" & FD & "208" & FD & "Dash" & FD & "ArrowAnchor" & FD & "SquareAnchor“)
            ImportColors(“Violet" & FD & "255" & FD & "238" & FD & "130" & FD & "238" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“Wheat" & FD & "255" & FD & "245" & FD & "222" & FD & "179" & FD & "DashDotDot" & FD & "SquareAnchor" & FD & "DiamondAnchor“)
            ImportColors(“White" & FD & "255" & FD & "255" & FD & "255" & FD & "255" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“WhiteSmoke" & FD & "255" & FD & "245" & FD & "245" & FD & "245" & FD & "Dash" & FD & "NoAnchor" & FD & "SquareAnchor“)
            ImportColors(“Yellow" & FD & "255" & FD & "255" & FD & "255" & FD & "1" & FD & "Solid" & FD & "Round" & FD & "Round“)
            ImportColors(“YellowGreen" & FD & "255" & FD & "154" & FD & "205" & FD & "50" & FD & "DashDotDot" & FD & "ArrowAnchor" & FD & "flat“)


            'SymbolScreen.ComboBoxDataType.Items.Clear()
            SymbolScreen.ToolStripDropDownDataType.DropDownItems.Clear()
            SymbolScreen.ToolStripDropDownDataType.DropDownItems.Clear()




            ImportDataTypes("Bit" & FD & "1" & FD & "Blue" & FD & "3" & FD & "A Single On/off", -100)
            'ImportDataTypes("Boolean" & FD & "1" & FD & "Green" & FD & "3" & FD & "A Boolean variable", -99)
            ImportDataTypes("Byte" & FD & "8" & FD & "MistyRose" & FD & "4" & FD & "A Byte (8 bits)", -98)
            ImportDataTypes("errored" & FD & "1" & FD & "Red" & FD & "1" & FD & "Logic Path For Errors", -97)
            ImportDataTypes("erase" & FD & "1" & FD & "oRANGE" & FD & "1" & FD & "Logic Path For Errors", -97) 'cHANGE THIS BACK TO wHITE
            ImportDataTypes("Floating" & FD & "8" & FD & "DodgerBlue" & FD & "8" & FD & "A floating-point variable WinDef", -96)
            ImportDataTypes("Int16" & FD & "2" & FD & "Aquamarine" & FD & "2" & FD & "A 16-bit Or 2 bytes signed Integer BaseTsd", -97)
            ImportDataTypes("Int32" & FD & "4" & FD & "Aqua" & FD & "4" & FD & "A 32-bit Or 4 bytes signed Integer -2147483648 through 2147483647 BaseTsd", -91)
            ImportDataTypes("Int64" & FD & "8" & FD & "Red" & FD & "8" & FD & "A 64-bit Or 8 bytes signed Integer ?+/- 9223372036854775807", -90)
            ImportDataTypes("INT8" & FD & "1" & FD & "Orange" & FD & "2" & FD & "An 8-bit Or 1 Byte signed Integer BaseTsd", -89)
            ImportDataTypes("Integer" & FD & "2" & FD & "Orange" & FD & "2" & FD & "An 16-bit Or 2 Byte signed Integer", -95)
            ImportDataTypes("logic" & FD & "1" & FD & "Black" & FD & "3" & FD & "Logic Path", -94)
            ImportDataTypes("Long" & FD & "4" & FD & "CadetBlue" & FD & "4" & FD & "4 bytes – 32 bits", -93)
            'ImportDataTypes("LongLong" & FD & "8" & FD & "CornflowerBlue" & FD & "8" & FD & "8bytes – 84 bits", -92)
            'ImportDataTypes("Void" & FD & "1" & FD & "YellowGreen" & FD & "5" & FD & "Any type WinNT")
            'ImportDataTypes("WINAPI,8" & FD & "ForestGreen" & FD & "10" & FD & "The calling convention For system functions WinDef")
            ImportDataTypes("Word" & FD & "2" & FD & "BlueViolet" & FD & "2" & FD & "2 bytes - 16 Bits", -91)

            ReDim MyUniverse.MySymbolPoints(125) ' Maxium number of points in a 500x500 on grid of 50
            ImportSymbolPointPreference()

            ReDim MyUniverse.OptionDisplay(32) ' Fixed number of the options disl;aydss
            ' I lost what the defauls of this use to be.

            'hack the color of the text is fixed for now, but needs to be be able to change it from the imports (later)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.AliceBlue : MyUniverse.OptionDisplay(I).X = 0 : MyUniverse.OptionDisplay(0).Y = 0 ' Check list (No Used)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.LawnGreen : MyUniverse.OptionDisplay(1).X = 0 : MyUniverse.OptionDisplay(1).Y = -25 ' Display Point names
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.DarkBlue : MyUniverse.OptionDisplay(2).X = 0 : MyUniverse.OptionDisplay(2).Y = -250 ' Display Symbol Name
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.OrangeRed : MyUniverse.OptionDisplay(3).X = -250 : MyUniverse.OptionDisplay(3).Y = -225 ' Display ID Stroke
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.ForestGreen : MyUniverse.OptionDisplay(4).X = -250 : MyUniverse.OptionDisplay(4).Y = -175 ' Display File Name
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Gray : MyUniverse.OptionDisplay(5).X = 250 : MyUniverse.OptionDisplay(5).Y = 150 ' Display Notes
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.DarkOrchid : MyUniverse.OptionDisplay(6).X = -250 : MyUniverse.OptionDisplay(6).Y = -125 ' Display OpCode
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Blue : MyUniverse.OptionDisplay(7).X = 250 : MyUniverse.OptionDisplay(7).Y = 250 ' Display Program Code Text
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.YellowGreen : MyUniverse.OptionDisplay(8).X = -250 : MyUniverse.OptionDisplay(8).Y = -225 ' Display Short Cut Pointer (Should never use)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(9).X = -250 : MyUniverse.OptionDisplay(9).Y = 75 ' Display Error Text
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.SaddleBrown : MyUniverse.OptionDisplay(10).X = -25 : MyUniverse.OptionDisplay(10).Y = -25 'Display Input Output name type
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.GreenYellow : MyUniverse.OptionDisplay(11).X = +25 : MyUniverse.OptionDisplay(11).Y = -25 'Display Point Names
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Maroon : MyUniverse.OptionDisplay(12).X = 0 : MyUniverse.OptionDisplay(12).Y = -25 'Display Path Names
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Black : MyUniverse.OptionDisplay(13).X = 0 : MyUniverse.OptionDisplay(13).Y = -25 'Display Constants
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(14).X = 0 : MyUniverse.OptionDisplay(14).Y = 0 'Make Paths Orthogonal(No Used)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Wheat : MyUniverse.OptionDisplay(15).X = 0 : MyUniverse.OptionDisplay(15).Y = 0 'Move Symbols from on top of each other (The amount moved each time Times 2)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(16).X = 0 : MyUniverse.OptionDisplay(16).Y = 0 'Output Line Number (Not used)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.RosyBrown : MyUniverse.OptionDisplay(17).X = 0 : MyUniverse.OptionDisplay(17).Y = -25 'Display Data Vbalue on Paths (Only after I finish my interrupter)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(18).X = 0 : MyUniverse.OptionDisplay(18).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(19).X = 0 : MyUniverse.OptionDisplay(19).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(20).X = 0 : MyUniverse.OptionDisplay(20).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(21).X = 0 : MyUniverse.OptionDisplay(21).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(22).X = 0 : MyUniverse.OptionDisplay(22).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(23).X = 0 : MyUniverse.OptionDisplay(23).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(24).X = 0 : MyUniverse.OptionDisplay(24).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(25).X = 0 : MyUniverse.OptionDisplay(25).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(26).X = 0 : MyUniverse.OptionDisplay(26).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(27).X = 0 : MyUniverse.OptionDisplay(27).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(28).X = 0 : MyUniverse.OptionDisplay(28).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(29).X = 0 : MyUniverse.OptionDisplay(29).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(30).X = 0 : MyUniverse.OptionDisplay(30).Y = 0 '
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(31).X = 0 : MyUniverse.OptionDisplay(31).Y = 0 'Write warning and errors (not used)
            I = 0 : MyUniverse.OptionDisplay(I).Color = Brushes.Red : MyUniverse.OptionDisplay(32).X = 0 : MyUniverse.OptionDisplay(32).Y = 0 'Debug (mydebug() checking)

            Idex = AddNewNamedRecord("Start", "GoToNextLine Start", "  jmp main", "Start of the Program", "Internal", "No Language", "FlowChart Program", "0.1", "ABCDEFGHIJKLMNOP", vbTab & "jmp " & FD & MyUniverse.SysGen.RMStart & "GoToNextLine.PathName" & MyUniverse.SysGen.RMEnd & FD & vbTab & ";ReplaceStart")
            AddNEWSymbolRecord("Start", "/name", 0, 0, "0", "0", "?", 0)
            AddNEWSymbolRecord("Start", "/point", 250, 250, "Output", "logic", "CommandLine", 0)
            AddNEWSymbolRecord("Start", "/point", 0, 250, "output", "logic", "GotoNextLine", 0)
            GetSelfCorrectingIndexes("Start")

            MyUniverse.MyStaticData.MinXY.X = FlowChartScreen.PictureBox1.Top
            MyUniverse.MyStaticData.MaxXY.X = FlowChartScreen.PictureBox1.Width

            MyUniverse.MyStaticData.MinXY.Y = FlowChartScreen.PictureBox1.Left
            MyUniverse.MyStaticData.MaxXY.Y = FlowChartScreen.PictureBox1.Height



            'Makeing sure that there is at least a start symbol defined for everything

            ShowSorts("Named", ReSortStringArray("Named", Named_FileSyntax, Named_FileSyntax_Isam))
            ShowSorts("Named", ReSortStringArray("Named", Named_FileSymbolName, Named_File_iSAM))
            CheckForAnySortNeeded("Init", 103) 'hack

            Idex = AddANewFlowChartRecord()
            FlowChart_FileCoded(Idex) = CByte(MyKeyword_2_Byte("/error")) 'hack
            FlowChart_FileNamed(Idex) = "Origin" 'hack

            FlowChart_TableCode_X(Idex, "/error") 'hack
            FlowChart_TableNamed(Idex, "Origin")

            CheckForAnySortNeeded("", 104) 'hack
            ShowSorts("FlowChart", ReSortFlowChart(Idex))
            CheckForAnySortNeeded("", 105) 'hack

            MyUniverse.SysGen.UseX1 = MyMinMax(MyUniverse.SysGen.UseX1, 1000, MyUniverse.SysGen.UseX1 + 1000)
            MyUniverse.SysGen.UseY1 = MyMinMax(MyUniverse.SysGen.UseY1, 1000, MyUniverse.SysGen.MaxSymbolInYSpacing)

            ShowAllForms(ShowScreen, ShowScreen, ShowScreen, HideScreen, HideScreen, HideScreen)

            formatLanguage = "/language=(Language Name)" & FD & "{case Sensitive Yes,No}" & FD & "{inline comment}" & FD & "{.Extension}" & FD & "{between Statements on one line}" & FD & "{Last character to continue next line}" & FD & "{Characters in variable names besides a-z,A-Z}" & FD & MyUniverse.SysGen.RMStart & "GoToNextLine" & myuniverse.sysgen.rmEnd & FD & MyUniverse.SysGen.RMStart & "CameFromLast" & myuniverse.sysgen.rmEnd & FD & "{reserved}" & FD & "{reserved}"
            formatColor = "/Color=Color Name" & FD & " Alpha" & FD & " Red" & FD & " Green" & FD & " Blue" & FD & " Style" & FD & " StartCap" & FD & " EndCap"
            formatDatatype = "/datatype=datatypename" & FD & " Number Of Bytes" & FD & " Color Name" & FD & " Color Width" & FD & " Describtion"
            formatSymbolName = "/Name=Symbol Name" & FD & " options"
            'Need to get the {/...} options from the combobox 
            formatPoint = "/Point = X" & FD & " Y" & FD & " {Input/Output...}" & FD & " Data Type" & FD & " Name"
            formatLine = "/Line=x1" & FD & " y1" & FD & " x2" & FD & " y2" & FD & " Color"
            formatNameOfFile = "/FileName=Device:/Path/FileName.Extension"
            formatStroke = "/Stroke={}"
            formatNotes = "/Notes={}"
            formatVersion = "/Version={}"
            formatAuthor = "/Author={}"
            formatOpcode = "/OpCode={}"
            formatPath = "/Path=Name" & FD & " x1" & FD & " y1" & FD & " x2" & FD & " y2" & FD & " Data type"
            formatUse = "/Use=Name" & FD & " X" & FD & " Y" & FD & " rotation" & FD & " future dynamic options"
            formatConstant = "/Constant=name " & FD & " X" & FD & " Y" & FD & " Value"
            formatProgramText = "/programtext= Text " & MyUniverse.SysGen.RMStart & " replacements" & myuniverse.sysgen.rmEnd & " text ..."
            FormatOption = "/Option=number" & FD & "{on or off}"
            FormatError = "/error = Code" & FD & " name" & FD & " x1" & FD & " y1" & FD & " Name " & FD & " {other things maybe}"
            FormatDelete = "/Delete ..."
            FormatThisCode = "/ThisCode added to /path or /constant "
            FormatLanguage_KeyWord = "/Keyword=ReservedWord  {" & FD & "only one word" & FD & " no spaces allowed currently}"
            FormatLanguage_Function = "/Function=FunctionWord  " & FD & "only one function name no (), {}, [] etc " & FD
            FormatLanguage_operator = "/Operator=Operator  {" & FD & "only one operator ie: +" & FD & " no space allowed currently}"
            FormatSyntaxKeyWord = "/Syntax={keyword" & FD &
                "special characters" & FD &
                MyUniverse.SysGen.RMStart & "variables" & myuniverse.sysgen.rmEnd & " for variables " & FD &
                "quote marks " & FD &
                " between each one   ect..."


            FileInputOutputScreen.ToolStripButtonFlowChartToSourceCode.ToolTipText = "FlowChart to Source Code"
            FileInputOutputScreen.ToolStripButtonOpenFile.ToolTipText = "Open FlowChart File"
            FileInputOutputScreen.ToolStripButtonSaveFileAs.ToolTipText = "Save File As"
            FileInputOutputScreen.ToolStripButtonShowFlowChart.ToolTipText = "Show FlowChart Screen"
            FileInputOutputScreen.ToolStripButtonSourceCodeToFlowChartCode.ToolTipText = "Decompile Source Code to FlowChart"

            FlowChartScreen.ButtonAddConstant.ToolTipText = "Add Constant"
            FlowChartScreen.ButtonAddPath.ToolTipText = "Add Path"
            FlowChartScreen.ButtonDeleteobject.ToolTipText = "Delete "
            FlowChartScreen.ButtonMoveObject.ToolTipText = "Move"
            FlowChartScreen.ButtonOpenForm.ToolTipText = "File I/O"
            FlowChartScreen.ButtonOptionForm.ToolTipText = "Show Options Screen"
            FlowChartScreen.ButtonRedraw.ToolTipText = "Redraw"
            FlowChartScreen.ButtonSymbolForm.ToolTipText = "Show Symbol Screen"
            FlowChartScreen.ButtonZoomIn.ToolTipText = "Zoom In"
            FlowChartScreen.ButtonZoomOut.ToolTipText = "Zoom Out"
            FlowChartScreen.ToolStripDropDownSelectSymbol.ToolTipText = "Select Symbol To Place"


            SymbolScreen.ToolStripButtonAddLine.ToolTipText = "Add a colored Line"
            SymbolScreen.ToolStripButtonAddPoint.ToolTipText = "Add a Named Point"
            SymbolScreen.ToolStripButtonDelete.ToolTipText = "Delete A Point/Line"
            SymbolScreen.ToolStripButtonFlowChartForm_FromSymbolScreen.ToolTipText = "Show FlowChart Screen"
            SymbolScreen.ToolStripButtonMove.ToolTipText = "Move Point/Line"
            SymbolScreen.ToolStripButtonNewSymbol.ToolTipText = "Make A New Symbol"
            SymbolScreen.ToolStripButtonOptionForm_FromSymbolScreen.ToolTipText = "Show Options"
            SymbolScreen.ToolStripButtonUpdateSymbol.ToolTipText = "Update the Symbol"
            SymbolScreen.ToolStripDropDownButtonColor.ToolTipText = "Select the Color of Lines (and DataTypes)"
            SymbolScreen.ToolStripDropDownDataType.ToolTipText = "Select the Data type"
            SymbolScreen.ToolStripDropDownSelectSymbol.ToolTipText = "Select the Symbol"



            OptionScreen.ToolStripButtonCheckAllData.ToolTipText = "Check All FlowChart Data"
            OptionScreen.ToolStripButtonDeleteUnusedSymbols.ToolTipText = "Delete all Unused Symbols"
            OptionScreen.ToolStripButtonDump.ToolTipText = "Dump into File ..."
            OptionScreen.ToolStripButtonDeleteUnusedSymbols.ToolTipText = "Remove all unused symbols"
            OptionScreen.ToolStripButtonDeleteErrorMsgs.ToolTipText = "Delete FlowChart rrror messages"
            OptionScreen.ToolStripButtonFlowChartForm_FromOptionScreen.ToolTipText = "Show FlowChart"
            OptionScreen.ToolStripButtonSymbolForm_FromOptionScreen.ToolTipText = "Show Symbol"

            'Abug(700, "Timer set to ", SymbolScreen.Timer1.ToString(), SymbolScreen.Timer1.Interval)
            'SymbolScreen.Timer1.Interval = 32000
            'SymbolScreen.Timer1.Start()


            'First Stop
            ShowAllForms(HideScreen, HideScreen, ShowScreen, HideScreen, HideScreen, HideScreen)
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownPathStart, "ArrowAnchor")
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownPathEnd, "ArrowAnchor")
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownPathLineStyle, "Solid")
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownRotation, "Default")
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownInputOutput, "Both")
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownNumberOfBytes, "4") ' Assume 32 bit default data type
            OptionsSetDefaults(SymbolScreen.ToolStripDropDownLineWidth, "1") '
            SplashScreen.Visible = False
            ShowAllForms(HideScreen, HideScreen, ShowScreen, HideScreen, HideScreen, HideScreen)
            Abug(9000, "Init() Finished", "", ShowStatuss)
        End Sub ' End of INIT()

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function MyKeyword2String(Keyword As Int32) As String
            MyTrace(32, "MyKeyWords", 4)
            MyKeyword2String = My_KeyWords(Keyword)
        End Function


        '*************************************************************************
        'Returns the number of the character string
        Public Shared Function MyKeyword_2_Byte(Keyword As String) As Byte         'My_KeyWords are now always in order, so I need to change this to a binary search (Cause the list can be in the thounsands)
            MyTrace(33, "MyKeyWords", 57 - 49)

            For MyKeyword_2_Byte = CByte(LBound(My_KeyWords)) To CByte(UBound(My_KeyWords))
                If My_KeyWords(MyKeyword_2_Byte) = Trim(Keyword) Then
                    Exit Function
                End If
            Next
            MyKeyword_2_Byte = CByte(LBound(My_KeyWords)) ' allways points to unknown?????
        End Function


        Public Shared Sub ShowButton(YesOrNo As Boolean, Butt As Button) 'Turn button enable and visible on or off
            MyTrace(34, "ShowButton", 72 - 63)

            If YesOrNo = True Then
                Butt.Enabled = True
                Butt.Visible = True
            Else
                Butt.Enabled = False
                Butt.Visible = False
            End If
        End Sub


        '***********************************************************************
        'Routine Just to let the user know whats going on, more or less
        Public Shared Sub DisplayMyStatus(MyMessage As String) ' puts a status string into the textbox on all forms
            MyTrace(38, "DisplayMyStatus", 99 - 87)

            'Save updating the screen if it is the same status
            If MyTrim(MyMessage) = FlowChartScreen.LabelProgramStatus.Text Then Exit Sub
            If FlowChartScreen.Visible = True Then
                FlowChartScreen.LabelProgramStatus.Text = MyTrim(MyMessage)
            End If
            If SymbolScreen.Visible = True Then
                SymbolScreen.LabelProgramStatus.Text = MyTrim(MyMessage)
            End If
            If OptionScreen.Visible = True Then
                OptionScreen.LabelProgramStatus.Text = MyTrim(MyMessage)
            End If
            If FileInputOutputScreen.Visible = True Then
                FileInputOutputScreen.LabelProgramStatus.Text = MyTrim(MyMessage)
            End If
            Application.DoEvents() ' To make sure that a message gets updated on the screed.
        End Sub


        Public Shared Sub MyOpen(Where As PictureBox, DoingWhat As String)        'Routine This is actuall to open a new file to edit. 
            MyTrace(39, "MyOpen", 19 - 2)

            Dim MyFileName As String
            ''''''MyMsgCtr("MyOpen", 1259, DoingWhat, "", "", "", "", "", "", "", "")

            'Show the FileioScreen and the Status Screen
            ShowAllForms(HideScreen, HideScreen, HideScreen, ShowScreen, ShowScreen, HideScreen)

            CheckForAnySortNeeded("", 300)
            Select Case LCase(Trim(DoingWhat))
                Case "write"
                    MyFileName = XOpenFile("write", "Saving the file for this symbol " & DrillDown_FileName & "." & ComputerLanguageExtention()) ', DrillDown_FileName & "." & ComputerLanguageExtention())
                    If MyFileName = Nothing Then Exit Sub
                    Export(Where, MyFileName)
                Case "read"
                    MyFileName = XOpenFile("read", "Open the file for this FlowChart " & DrillDown_FileName) ' & ".", DrillDownFileName)
                    If MyFileName = Nothing Then Exit Sub
                    Import(Where, MyFileName)
                Case Else
                    MyMsgCtr("MyOpen", 1001, DoingWhat, DrillDown_FileName, "", "", "", "", "", "", "")
            End Select
        End Sub


        'This fills temp MyArrays with a symbols information
        ' changed on 20200711
        Public Shared Function GetSelfCorrectingIndexes(SymbolName As String) As Int32
            Dim IndexNamed As Int32
            MyTrace(41, "GetSelfCorrectingIndexes", 75 - 23)

            GetSelfCorrectingIndexes = constantMyErrorCode
            'FindingIndexesBug(IndexNamed) 'hack ' why am I finding if its wrong when I am trying to correct it?

            IndexNamed = FindIndexIniSAMTable("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, SymbolName)
            If (IndexNamed = constantMyErrorCode) Or (IndexNamed = 0) Then
                GetSelfCorrectingIndexes = constantMyErrorCode
                Exit Function ' This name is not a valid symbol name in the table, so ignore it
            End If ' we have a valid symbol, that shoul have graphics with it.

            'If there is a short cut then
            ' Get the short cut
            GetSelfCorrectingIndexes = Named_TableIndexes(IndexNamed) 'Named_TableIndexes(SymbolName, IndexNamed)
            If GetSelfCorrectingIndexes > 0 Then ' then it might be valid
                If Symbol_TableCoded_String(GetSelfCorrectingIndexes) = "/name" Then ' it is the first of the symbol graphics then every thing is ok
                    If Symbol_TableSymbolName(GetSelfCorrectingIndexes) = SymbolName Then
                        ' We have matching names, and it is the start of the symbol graphics with a /name
                        Exit Function ' This is a good record
                        'else we have to find/update it
                    End If ' Pointing to the start of the wrong symbol So Fix it
                End If ' Pointing to something other than the start of the symbol so fix it
                'Is the short cut valid
            End If ' We have a valid named symbol, but not graphics (or the graphics point got lost) so fix it

            ' IndexNamed is valid
            ' but index_symbol is not so we have to fix it  [ by checking every one ]
            ' Find the name again to correct
            For GetSelfCorrectingIndexes = 1 To TopOfFile("Symbol", Symbol_FileCoded)
                If Symbol_TableCoded_String(GetSelfCorrectingIndexes) = "/name" Then ' it is the first of the symbol graphics then every thing is ok
                    If Symbol_TableSymbolName(GetSelfCorrectingIndexes) = SymbolName Then ' we also have a match so save it
                        Named_TableIndexes(IndexNamed, GetSelfCorrectingIndexes) 'updating it with a new corfrect Indexes'("Named", IndexNamed, GetSelfCorrectingIndexes) 'updating it with a new corfrect Indexes
                        Exit Function
                        'else we have to find/update it
                    End If ' Pointing to the start of the wrong symbol So Fix it
                End If ' Pointing to something other than the start of the symbol so fix it
            Next GetSelfCorrectingIndexes
            ' This should flag it for future that it has been check and not found. 
            Named_TableIndexes(IndexNamed, constantMyErrorCode) ' an error as it has no symbol graphics, only a name
            GetSelfCorrectingIndexes = constantMyErrorCode
        End Function

        Public Shared Function FlowChart_Replacement_Text(IndexFlowChart As int32, MyString As String) As String
            Dim MyStringTemp As String
            Dim EditedString As String
            Dim FindingString As String
            Dim RePlaceMentString As String
            Dim IndexNamed As int32
            MyTrace(42, "FlowChart_Replacement_Text", 527 - 477)

            'Find the symbol
            CheckForAnySortNeeded("", 112)
            IndexNamed = FindIndexIniSAMTable("Named", "donotadd", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(IndexFlowChart))
            CheckForAnySortNeeded("", 113)
            MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)

            MyMsgCtr("GetSelfCorrectingIndexes", 1340,
                     "8 Names:",
                     FlowChart_TableNamed(IndexFlowChart),
                     Named_TableSymbolName(Named_File_iSAM(IndexNamed - 1)),
                     Named_TableSymbolName(Named_File_iSAM(IndexNamed)),
                     Named_TableSymbolName(Named_File_iSAM(IndexNamed + 1)),
                     CStr(IndexFlowChart), CStr(IndexNamed), "", "")
            If IndexNamed < 1 Then
                Return Nothing
            End If
            'I = Named_File_iSAM(I)
            'get the symbol program source code to edit.
            EditedString = Named_TableProgramText(IndexNamed)

            '03/12/19 Removed all of the test for the right properities named, because if it's the wrong name, then it will be ignored in the replace attempt
            '03/12/19 TopOfFile code by 1/3 
            MyStringTemp = Trim(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))

            While Len(MyStringTemp) > 1

                'Get Rid of anything so that we correct it back to start with a "/"
                While Left(MyStringTemp & "?", 1) <> "/" And Len(MyStringTemp) > 0
                    MyStringTemp = Mid(MyStringTemp, 2)
                End While

                FindingString = MyUniverse.SysGen.RMStart & Trim(Mid(Pop(MyStringTemp, ConstantDelimeters), 3)) & myuniverse.sysgen.rmEnd
                RePlaceMentString = Pop(MyStringTemp, ConstantDelimeters)
                EditedString = MyReplace(EditedString, FindingString, RePlaceMentString)
            End While
            FlowChart_Replacement_Text = EditedString
        End Function


        Public Shared Sub MyDeCompile(where As PictureBox)  ' Converts from language into FlowChart
            Dim InputFileName As String
            Dim Idex As Int32
            MyTrace(43, "MyDeCompile", 2604 - 2530)

            ' Bugs:
            ' It does not make /paths for all of the connections to a symbol. 
            ' It does not connect paths of the same name to each other. (Updatedlinks to do this)
            ' It does not place symbols in the 'best' place
            'ReDim Named_FileSyntax_Isam(UBound(Named_FileSymbolName)) ' and deleted afwards



            ' no one had this many lines of code (or it would destrory the program anyway)
            MyUniverse.MySS = FillImportLine()
            'MyUniverse.SymbolPointCount = 1 ' First point 
            MyUniverse.SysGen.UseX1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
            MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor

            MyMsgCtr("MyDeCompile", 1116, "", "", "", "", "", "", "", "", "")
            InputFileName = XOpenFile("decompile", "Open The Source Code File")

            If InputFileName = Nothing Then Exit Sub

            If Dir(InputFileName) = "" Then ' need to create the file if it does not exist then you can ...
                Exit Sub
            End If

            ' Now open it for output

            MyMsgCtr("MyDeCompile", 1149, InputFileName, "", "", "", "", "", "", "", "")

            Clear_Screen_Only(where)

            ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) ' Show each symbol (Later make an option)
            ShowAllForms(ShowScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) 'hack

            ' make symbols for everything that has programtext and no syntax
            For MyUniverse.MySS.Index.IndexNamed = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                Named_FileSyntax_Isam(MyUniverse.MySS.Index.IndexNamed) = MyUniverse.MySS.Index.IndexNamed
                If Named_TableSyntax(MyUniverse.MySS.Index.IndexNamed) = "" Then
                    If MyTrim(Named_TableProgramText(MyUniverse.MySS.Index.IndexNamed)) = "" Then
                        Abug(982, "No Program Text", "No Syntax", Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed))
                        Named_TableProgramText(MyUniverse.MySS.Index.IndexNamed, ComputerLanguageComment())
                        Named_TableSyntax(MyUniverse.MySS.Index.IndexNamed, ComputerLanguageComment())
                    Else
                        If PrintAbleNull(Named_TableSyntax(MyUniverse.MySS.Index.IndexNamed)) = "_" Then
                            MyUniverse.MySS.Inputs.KeyLine = MyTrim(Named_TableProgramText(MyUniverse.MySS.Index.IndexNamed))
                            Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters) ' get ride of the sort section of the program text
                            Named_TableSyntax(MyUniverse.MySS.Index.IndexNamed, Trim(ConvertProgramText2Syntax(My_Code_Line_Parsed, MyUniverse.MySS.Inputs.KeyLine)))
                        End If
                    End If
                End If
                MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, MyUniverse.MySS.Index.IndexNamed)
                MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, TopOfFile("named", Named_FileSyntax, Named_FileSyntax_Isam))
            Next MyUniverse.MySS.Index.IndexNamed

            Using reader As System.IO.TextReader = System.IO.File.OpenText(InputFileName)
                ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) ' Show each symbol (Later make an option)
                FindingMyBugs(10) 'hack Least amount of checking here

                MyUniverse.MySS.Inputs.Inputline = reader.ReadLine() ' For blank lines
                MyUniverse.MySS.Inputs.LineNumberIn += 1
                MyUniverse.MySS.Inputs.KeyLine = MyUniverse.MySS.Inputs.Inputline
                While Not IsNothing(MyUniverse.MySS.Inputs.KeyLine)
                    'Application.DoEvents()
                    If IsNothing(MyUniverse.MySS.Inputs.KeyLine) Then
                        ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) ' Show each symbol (Later make an option)
                        GoTo MyEnding
                    End If

                    While MyUniverse.MySS.Inputs.KeyLine = "" ' for blank lines
                        MyUniverse.MySS.Inputs.Inputline = reader.ReadLine() ' For blank lines
                        MyUniverse.MySS.Inputs.LineNumberIn += 1
                        MyUniverse.MySS.Inputs.KeyLine = MyUniverse.MySS.Inputs.Inputline
                        If IsNothing(MyUniverse.MySS.Inputs.KeyLine) Then
                            ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) ' Show each symbol (Later make an option)
                            GoTo MyEnding
                        End If
                    End While

                    'Application.DoEvents()
                    MyDeCompileLine(where, MyUniverse.MySS.Inputs.Inputline)
                    'Application.DoEvents()

                    MyUniverse.MySS.Inputs.Inputline = reader.ReadLine() ' For blank lines
                    MyUniverse.MySS.Inputs.LineNumberIn += 1
                    MyUniverse.MySS.Inputs.KeyLine = MyUniverse.MySS.Inputs.Inputline
                    'Application.DoEvents()

                    While MyUniverse.MySS.Inputs.KeyLine = ""
                        'Application.DoEvents()
                        MyUniverse.MySS.Inputs.Inputline = reader.ReadLine() ' For blank lines
                        MyUniverse.MySS.Inputs.KeyLine = MyUniverse.MySS.Inputs.Inputline
                        'Application.DoEvents()

                        If IsNothing(MyUniverse.MySS.Inputs.KeyLine) Then
                            ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone) ' Show each symbol (Later make an option)
                            GoTo MyEnding
                        End If
                        FindingMyBugs(10) 'hack Least amount of checking here
                        'Application.DoEvents()
                        MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, TopOfFile("named", Named_FileSyntax, Named_FileSyntax_Isam))

                    End While
                    'Application.DoEvents()
                    FindingMyBugs(10) 'hace Least amount of checking here
                    'MyUniverse.SymbolPointCount = 1
                    'Application.DoEvents()
                End While

                ' Never reach the actual end 1=1
MyEnding:
                reader.Close()
            End Using
            'ReDim Named_FileSyntax_Isam(1) ' and deleted afwards
            For Idex = TopOfFile("FlowChart", FlowChart_FileCoded) To 1 Step -1
                DisplayMyStatus("Linking " & Idex)
                'Application.DoEvents()
                UpDateFlowChartLinks(Idex, MyUniverse.MySS.Inputs.LineNumberIn)
            Next
            DisplayMyStatus("Finished Doing the Compile.")
            'Application.DoEvents()

        End Sub

        Public Shared Sub MyDeCompileLine(where As PictureBox, My_InputCodeLine As String) ' Converts each line of source code into a FlowChart (and symbol if required)
            Dim SymbolName As String
            Dim MyErrors As int32
            MyTrace(44, "MyDeCompileLine", 2687 - 2606)

            MyUniverse.MySS.Inputs.Inputline = My_InputCodeLine
            MyUniverse.MySS.Inputs.KeyLine = ComputerLanguagePreProcessor(My_InputCodeLine)
            MyErrors = 999999999 '9,223,372,036,854,775,807 ' This should be enough to avoid a forever loop
            MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, TopOfFile("named", Named_FileSyntax, Named_FileSyntax_Isam))
            While MyErrors > 0  ' will exit when the end of file is reached.
                MyErrors -= 1
                While Len(MyUniverse.MySS.Inputs.KeyLine) > 0
                    FindingMyBugs(10) 'hace Least amount of checking here
                    'MyParse(My_Syntax_Line_Parsed, MyUniverse.MySS.Inputs.KeyLine)
                    MyMakeArraySizesBigger()
                    MyUniverse.MySS.Index.IndexNamed = FindSymbolSyntax(MyUniverse.MySS.Inputs.KeyLine)
                    If MyUniverse.MySS.Index.IndexNamed > constantMyErrorCode Then
                        SymbolName = Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed)
                    Else
                        SymbolName = Nothing
                    End If
                    MyCheckIndexs(0, 0, MyUniverse.MySS.Index.IndexNamed, 0, 0)
                    If MyUniverse.MySS.Index.IndexNamed <= 0 Then
                        MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.UseY1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        If MyUniverse.SysGen.UseY1 > MyUniverse.SysGen.MaxSymbolInYSpacing Then
                            MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                            MyUniverse.SysGen.UseX1 = MyUniverse.SysGen.UseX1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        End If
                        MyUniverse.MySS.Index.IndexNamed = MakeSymbolFromSyntax(MyUniverse.MySS.Inputs.KeyLine, MyUniverse.SysGen.UseX1, MyUniverse.SysGen.UseY1, MyUniverse.MySS.Inputs.LineNumberIn)
                        If MyUniverse.MySS.Index.IndexNamed > 0 Then
                            SymbolName = Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed)
                            Application.DoEvents()
                            PaintAll(where, TopOfFile("FlowChart", FlowChart_FileCoded) - 1, TopOfFile("FlowChart", FlowChart_FileCoded) + 1)
                            Application.DoEvents()
                        Else
                            Abug(980, " added a line, and did not get a symbol named in return ", MyUniverse.MySS.Index.IndexNamed, MyUniverse.MySS.Inputs.KeyLine)
                        End If
                        '                            SymbolName = AddNewName("Error_")
                        MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.UseY1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        If MyUniverse.SysGen.UseY1 > MyUniverse.SysGen.MaxSymbolInYSpacing Then
                            MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                            MyUniverse.SysGen.UseX1 = MyUniverse.SysGen.UseX1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        End If
                        MakeUseANDPath(MyUniverse.MySS.Inputs.KeyLine, SymbolName, MyUniverse.MySS.Index.IndexNamed, MyUniverse.SysGen.UseX1, MyUniverse.SysGen.UseY1, MyUniverse.MySS.Inputs.LineNumberIn)
                        MyUniverse.MySS.Inputs.KeyLine = ""
                        Application.DoEvents()
                        PaintAll(where, TopOfFile("FlowChart", FlowChart_FileCoded) - 1, TopOfFile("FlowChart", FlowChart_FileCoded) + 1)

                        SelectInToolStrip(SymbolScreen.ToolStripDropDownSelectSymbol, Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed))

                        Application.DoEvents()
                    Else
                        MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.UseY1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        If MyUniverse.SysGen.UseY1 > MyUniverse.SysGen.MaxSymbolInYSpacing Then
                            MyUniverse.SysGen.UseY1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                            MyUniverse.SysGen.UseX1 = MyUniverse.SysGen.UseX1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        End If
                        MakeUseANDPath(MyUniverse.MySS.Inputs.KeyLine, SymbolName, MyUniverse.MySS.Index.IndexNamed, MyUniverse.SysGen.UseX1, MyUniverse.SysGen.UseY1, MyUniverse.MySS.Inputs.LineNumberIn)
                        MyUniverse.MySS.Inputs.KeyLine = "" ' End of this line???????
                        'Application.DoEvents()
                        PaintAll(where, TopOfFile("FlowChart", FlowChart_FileCoded) - 1, TopOfFile("FlowChart", FlowChart_FileCoded) + 1)
                        'Application.DoEvents()
                    End If
                    'Application.DoEvents()
                    'should we be searching for keylin, or symbolname????????? (Changed to symbolname 2020 08 17 for no reason
                    MyUniverse.MySS.Index.IndexNamed = FindIndexIniSAMTable("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, SymbolName) 'MyUniverse.MySS.Inputs.KeyLine)
                    If MyUniverse.MySS.Index.IndexNamed = constantMyErrorCode Then
                        MyUniverse.MySS.Index.IndexNamed = CheckNotInList("named", "Do Not Add", Named_FileSymbolName, Named_File_iSAM, SymbolName) 'MyUniverse.MySS.Inputs.KeyLine)
                    End If
                    If MyUniverse.MySS.Index.IndexNamed < 1 Then
                        Abug(978, " The symbol " & SymbolName, "was not found!", MyUniverse.MySS.Index.IndexNamed)
                        'Application.DoEvents()
                    Else
                        'Application.DoEvents()
                        AddSymbolToDropDown(Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed))
                        SelectInToolStrip(SymbolScreen.ToolStripDropDownSelectSymbol, Named_TableSymbolName(MyUniverse.MySS.Index.IndexNamed))
                    End If
                    'Application.DoEvents()
                    Clear_Screen(SymbolScreen.PictureBox1)
                    'Application.DoEvents()
                End While
                'Application.DoEvents()
                If Len(MyUniverse.MySS.Inputs.KeyLine) <= 0 Then Exit Sub ' to avoid error count
            End While
            ReSortSymbolList()
        End Sub



        Public Shared Function ConvertProgramText2Syntax(ByRef MyArray() As String, ProgramText As String) As String
            MyTrace(45, "ConvertProgramText2Syntax", 27 - 18)

            MyParse(MyArray, ProgramText)
            ConvertProgramText2Syntax = Trim(MakeStatementSyntax(MyArray))
        End Function



        ' This should update all of the links to this 'set' of paths connect to this link's (X-Y)
        ' And return the next use index number to compile
        Public Shared Function CompileThisSymbolText(IndexFlowChart As int32) As String
            Dim IndexNamed As int32
            Dim MyConnectionsToMyCode As String
            Dim ThisIs As String
            'Dim ThisIsAt as int32
            Dim ThisIsSymbolName As String
            Dim ThisIsExtensionName As String
            Dim ThisIsValue As String
            Dim SaveNextGoTo As String
            Dim Temp, Temp2 As String
            Dim I1, I2, I3, I4, I5 As Integer
            MyTrace(46, "CompileThisSymbolText", 94 - 9)

            CheckForAnySortNeeded("", 114)
            IndexNamed = FindIndexIniSAMTable("Named", "Dontadd", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(IndexFlowChart))
            CheckForAnySortNeeded("", 115)
            MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)

            CompileThisSymbolText = Named_TableProgramText(IndexNamed)

            Select Case LCase(FlowChart_TableCode(IndexFlowChart)) ' Should only get /USE codes
                Case "/use"
                    MyConnectionsToMyCode = FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)
                    ' Find The Next Goto Symbol to compile As The Next One  (If already processed then Pick one not done (at Random?))
                    CheckForAnySortNeeded("", 116)
                    IndexNamed = FindIndexIniSAMTable("Named", "Dontadd", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(IndexFlowChart))
                    CheckForAnySortNeeded("", 117)
                    MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)

                    CompileThisSymbolText = FlowChart_Replacement_Text(IndexFlowChart, Named_TableProgramText(IndexNamed)) '3/16/19
                    'Now Get all of the names of the variables that connect to this use and replace them.
                    I1 = 1
                    While (I1 + 3 < Len(MyConnectionsToMyCode))
                        ThisIs = Trim(Pop(MyConnectionsToMyCode, ConstantDelimeters))
                        I1 = InStr(I1, MyConnectionsToMyCode & MyUniverse.SysGen.RMStart, MyUniverse.SysGen.RMStart) 'start 
                        I2 = InStr(I1, MyConnectionsToMyCode & ".", ".") 'middle of it
                        I3 = InStr(I1, MyConnectionsToMyCode & myuniverse.sysgen.rmEnd, myuniverse.sysgen.rmEnd) 'end of it
                        I4 = InStr(I1, MyConnectionsToMyCode & "=", "=") ' get the value of what this is
                        I5 = InStr(I1 + 1, MyConnectionsToMyCode & MyUniverse.SysGen.RMStart, MyUniverse.SysGen.RMStart) 'start of the Next and end of the line

                        If I2 > I3 Then I2 = I3 - 1

                        ThisIsSymbolName = Mid(MyConnectionsToMyCode, I1 + 1, I2 - I1 - 1) ' From [ to .
                        'wrong
                        'MyUniverse.DebugA = "" 'hack
                        ThisIsExtensionName = Mid(MyConnectionsToMyCode, I2 + 1, I3 - I2 - 1) 'from . to ]
                        'wrong
                        'MyUniverse.DebugA = "" 'hack
                        ThisIsValue = Mid(MyConnectionsToMyCode, I4 + 1, I5 - I4 - 1) 'from = to [


                        ThisIsExtensionName = Mid(MyConnectionsToMyCode, I2 + 1, I3 - I2 - 1) 'from . to ]
                        CompileThisSymbolText = MyReplace(CompileThisSymbolText,
                                                          MyUniverse.SysGen.RMStart &
                                                          ThisIsSymbolName &
                                                          "." &
                                                          ThisIsExtensionName &
                                                          myuniverse.sysgen.rmEnd,
                                                          ThisIsValue)
                        AWarning(999, "Do we need all of the rest of this? ", 0, 0)
                        Select Case LCase(Trim(ThisIs))
                            Case "/point"
                                Temp = MyConnectionsToMyCode ' FlowChart_TableLinks(IndexFlowChart)
                                Temp = MyFixLine(Temp)
                                While Len(Temp) > 0
                                    Temp2 = Pop(Temp, ConstantDelimeters)
                                    While Left(Temp2, 1) = FD
                                        Temp2 = Mid(Temp2, 2, Len(Temp2))
                                    End While
                                    FindingMyBugs(10) 'hace Least amount of checking here
                                    Select Case LCase(Trim(Temp2))
                                        Case "/x1"
                                            Temp2 = Pop(Temp, ConstantDelimeters)
                                        Case "/y1"
                                            Temp2 = Pop(Temp, ConstantDelimeters)
                                        Case "/x2"
                                            Temp2 = Pop(Temp, ConstantDelimeters)
                                        Case "/y2"
                                            Temp2 = Pop(Temp, ConstantDelimeters)
                                        Case Else
                                    End Select
                                End While
                                If LCase(Temp) = "logic" Then
                                    SaveNextGoTo = Temp
                                End If
                            Case "/use", "/path", "/line"
                                Temp = ""
                            Case Else
                                MyMsgCtr("MyCompile", 1030, FlowChart_TableCode(IndexFlowChart) & MyConnectionsToMyCode, ThisIs, "", "", "", "", "", "", "")
                        End Select ' Ench item of the status of this use
                    End While ' Get the next item of this use status
                Case "/error"  'ignore all errors for now
                Case "/constant" 'ignore all constants for now
                Case "/path"  ' Ignore all paths for now
                    ConnectPath(IndexFlowChart)
                Case Else 'Not a Use so goto the next GoTo
                    MyMsgCtr("CompileThisSymbolText", 1117, FlowChart_TableCode(IndexFlowChart), "", "", "", "", "", "", "", "")
            End Select
        End Function

        Public Shared Sub MyCompile(Where As PictureBox) ' Converts from a FlowChart into Source Code
            Dim IndexFlowChart As int32
            Dim IndexNamed As int32
            Dim IndexSymbol As int32
            Dim OutputFileName As String
            'Dim MySS As ImportLineStruct
            Dim MyCode As String
            MyTrace(47, "MyCompile", 756 - 696)

            MyUniverse.MySS = FillImportLine()

            Clear_Screen_Only(Where)
            OutputFileName = XOpenFile("compile", "Saving the compiled source For " & DrillDown_FileName & "." & ComputerLanguageExtention()) ' 2020 08 10 , DrillDownFileName)
            If OutputFileName = Nothing Then Exit Sub

            If Dir(OutputFileName) = "" Then ' need to create the file if it does not exist then you can ...
                'System.IO.File.Create(OutputFileName)
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(OutputFileName)
                End Using
            End If

            ' Now open it for output
            Using Writer As System.IO.FileStream = System.IO.File.OpenWrite(OutputFileName)

                Clear_Screen_Only(Where)
                FindingMyBugs(10) 'hack Least amount of checking here

                For IndexFlowChart = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                    CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
                    MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)
                    UpDateFlowChartLinks(IndexFlowChart, MyUniverse.MySS.Inputs.LineNumberIn)
                    ReSetScrollBars(Where, IndexFlowChart)

                    Select Case LCase(FlowChart_TableCode(IndexFlowChart))
                        Case "/use"
                            CheckForAnySortNeeded("", 118)
                            IndexNamed = FindIndexIniSAMTable("Named", "dontadd", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(IndexFlowChart))
                            CheckForAnySortNeeded("", 119)
                            MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)
                            IndexSymbol = Named_File_iSAM(IndexNamed)
                            CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
                            MyCheckIndexs(IndexFlowChart, 0, IndexNamed, 0, 0)
                            'Added 3/16/19 for check of replacements
                            MyCode = CompileEachSymbol(IndexFlowChart, MyUniverse.MySS.Inputs.LineNumberIn)
                            'CheckBoxOutputLineNumbers
                            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(16) = True Then
                                MyCode = MyCode & ComputerLanguageComment() & MyUniverse.MySS.Inputs.LineNumberIn
                            Else
                            End If
                            MyWrite(0, Writer, MyCode) ' write out line number zero as special case to not write it.
                            MyUniverse.MySS.Inputs.LineNumberIn += 1

                        Case "/path"
                            ConnectPath(IndexFlowChart)
                        Case "/error"

                        Case "/constant"

                        Case Else
                            MyMsgCtr("MyCompile", 1030, FlowChart_TableCode(IndexFlowChart), IndexFlowChart.ToString, "", "", "", "", "", "", "")
                    End Select
                Next
                Writer.Close()
            End Using
            MyMsgCtr("MyCompile", 1009, OutputFileName, "", "", "", "", "", "", "", "")
            Clear_Screen(Where)
        End Sub



        'Routine 'Compile' is where it starts checking, then makes the text output
        Public Shared Function CompileEachSymbol(IndexFlowChart As int32, LineNumber As int32) As String
            MyTrace(48, "CompileEachSymbol", 71 - 61)

            'Get the links between the symbols (path names)
            UpDateFlowChartLinks(IndexFlowChart, LineNumber)
            'Replace the code with the names of the paths (And other information)
            CompileEachSymbol = CompileThisSymbolText(IndexFlowChart) ' Write out this symbol then get the next one to do
        End Function


        Public Shared Sub MakePaths(Idex As int32, jdex As int32, LineNumber As int32) 'make new paths connecting two together
            Dim SymbolNamed As String 'Links,DataTypeIs 
            Dim X1, Y1, X2, Y2 As int32
            Dim Net1, Net2 As String
            Dim NetA, NetB As String
            Dim DebugA, DebugB As String 'hack
            Dim A1, A2 As String
            Dim InNetLinksAt As int32
            MyTrace(49, "MakePaths", 2946 - 2870)

            If Idex = jdex Then Exit Sub ' do not make a path from itself to itself

            'must be /paths
            If FlowChart_TableCode(Idex) <> "/path" Then Exit Sub
            If FlowChart_TableCode(jdex) <> "/path" Then Exit Sub

            DebugA = MyShowFlowChartRecord(Idex) ' FlowChart_TableNamed(Idex) 'hack
            DebugB = MyShowFlowChartRecord(jdex) ' FlowChart_TableNamed(jdex) 'hack

            Net1 = NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(Idex)))
            Net2 = NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(jdex)))

            'error two nets are the same, so should delete one
            If Net1 = Net2 Then
                Abug(691, " Two nets are the same ", Net1, Net2)
                Exit Sub 'cause the nets are already connected
            End If

            'NetA = NetNames(My_Int(FlowChart_PathLinks_And_CompiledCode(Idex)))
            'NetB = NetNames(My_Int(FlowChart_PathLinks_And_CompiledCode(jdex)))
            'ERROR
            ' This is wrong, it should be as above (which does not work yet)
            NetA = FlowChart_TableNamed(Idex)
            NetB = FlowChart_TableNamed(jdex)

            InNetLinksAt = FindInNetLinks(Idex)

            If NetA <> NetB Then
                'we should be combinine two differant named nets together?????
                Abug(696, "Two differant nets " & Idex & ":" & jdex, DebugA & ":" & DebugB, Net1 & ":" & Net2) 'hack
                SymbolNamed = FlowChart_TableNamed(Idex) & "&" & FlowChart_TableNamed(Idex)
            Else
                SymbolNamed = FlowChart_TableNamed(Idex)
            End If

            ' Must have the same name (maybe, or else it is an error , it is an error, )
            If FlowChart_TableNamed(Idex) <> FlowChart_TableNamed(jdex) Then Exit Sub

            'From the second point in one
            X1 = FlowChart_TableX2_Rotation(Idex)
            Y1 = FlowChart_TableY2_Option(Idex)
            'To the second point in the other
            X2 = FlowChart_TableX2_Rotation(jdex)
            Y2 = FlowChart_TableY2_Option(jdex)
            ' should also clean the two of them out 
            A1 = NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(Idex)))
            A2 = NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(jdex)))
            ' Index outside the bounds of the array
            NetA = NetNames(My_INT(FlowChart_PathLinks_And_CompiledCode(Idex)))
            NetB = NetNames(My_INT(FlowChart_PathLinks_And_CompiledCode(jdex)))
            UpDateFlowChartLinks(TopOfFile("FlowChart", FlowChart_FileCoded), LineNumber)
            AddNEWFlowChartRecord(SymbolNamed, "/path", X1, Y1, CStr(X2), CStr(Y2), "error", LineNumber)
        End Sub


        Public Shared Sub UpDateFlowChartLinks(IndexFlowChart As Int32, LineNumber As Int32) '/Use fills in information /Path adds to net number list and saves netnumber into links
            Dim idex As Int32
            Dim IndexNamed, IndexSymbol, PathX, PathY, IndexPath, MY_Datatype As Int32
            Dim My_RotationName, My_Input_Output_Both, SL, MyPathName As String
            Dim ThisSymbolName As String ' holds the symbol name
            Dim ThisPointName As String ' holds the name of the point(s)
            Dim Temp As String
            Dim SymbolXY As MyPointStructure
            MyTrace(51, "UpDateFlowChartLinks", 970 - 2774)

            FindingMyBugs(10) 'hace Least amount of checking here
            'The following causes the links to double in size
            'Application.DoEvents()
            Select Case LCase(FlowChart_TableCode(IndexFlowChart))
                Case "/use"  ' Find all of the points of a symbol (And Put them Together in FCStatus)
                    If MyCheckValidUse(IndexFlowChart) = False Then Exit Sub
                    CheckForAnySortNeeded("", 120)
                    IndexNamed = FindIndexIniSAMTable("Named", "Add", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(IndexFlowChart))
                    If IndexNamed = constantMyErrorCode Then ' We can not find the index, so we whould add it.
                        Exit Sub
                    End If
                    CheckForAnySortNeeded("", 121)
                    MyCheckIndexs(IndexFlowChart, IndexSymbol, IndexNamed, 0, 0)
                    ThisSymbolName = Named_FileSymbolName(IndexNamed) ' need to check for error of -1 return
                    IndexSymbol = GetSelfCorrectingIndexes(FlowChart_TableNamed(IndexFlowChart))
                    MyCheckIndexs(IndexFlowChart, IndexSymbol, IndexNamed, 0, 0)
                    ThisSymbolName = FlowChart_TableNamed(IndexFlowChart)
                    SL = ""
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".name" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(ThisSymbolName) ' This symbol name
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".name" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableSymbolName(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".index" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(IndexFlowChart.ToString)
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".x" & myuniverse.sysgen.rmEnd & "=" & FlowChart_TableX1(IndexFlowChart).ToString
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".y" & myuniverse.sysgen.rmEnd & "=" & FlowChart_TableY1(IndexFlowChart).ToString
                    SL = SL & Temp
                    'rotation
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".Rotation" & myuniverse.sysgen.rmEnd & "=" & MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0)
                    SL = SL & Temp
                    'Temp = ConstantSeperators & myuniverse.sysgen.rmstart  & ThisSymbolName & ".y2" & myuniverse.sysgen.rmEnd & "=" & FlowChart_TableY2_Option(IndexFlowChart)
                    'SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".DataType" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(FlowChart_Table_DataType(IndexFlowChart))
                    SL = SL & Temp
                    '                    Temp = ConstantSeperators & myuniverse.sysgen.rmstart  & ThisSymbolName & ".programtext" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableProgramText(IndexNamed))
                    '                   SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".OpCode" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableOpCode(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".notes" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableNotes(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".FileName" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableNameofFile(IndexNamed))
                    SL = SL & Temp
                    '                    Temp = ConstantSeperators & myuniverse.sysgen.rmstart  & ThisSymbolName & ".language" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableLanguage(IndexNamed))
                    '                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".Author" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableAuthor(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".Version" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableVersion(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".Stroke" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableStroke(IndexNamed))
                    SL = SL & Temp
                    Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".Indexes" & myuniverse.sysgen.rmEnd & "=" & Named_TableIndexes(IndexNamed)
                    SL = SL & Temp

                    If IndexSymbol > 0 Then
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        If Symbol_TableCoded_String(IndexSymbol) = "/name" Then
                            If Len(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)) > 2 Then
                                Abug(972, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), 0, 0)
                                FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, FD & FlowChart_PathLinks_And_CompiledCode(IndexFlowChart) & ", /Error, ") ' Saving incase there is an error for later processing as if there was'nt an error
                            Else
                            End If
                            My_RotationName = MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0)
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack
                            Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".name" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Symbol_TableSymbolName(IndexSymbol))
                            SL = SL & Temp
                            Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".xa" & myuniverse.sysgen.rmEnd & "=" & MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).X
                            SL = SL & Temp
                            Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".ya" & myuniverse.sysgen.rmEnd & "=" & MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).Y
                            SL = SL & Temp
                            Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".rotation" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(My_RotationName)
                            SL = SL & Temp
                            If LCase(Symbol_TableSymbolName(IndexSymbol)) = LCase(FlowChart_TableNamed(IndexFlowChart)) Then ' Making sure that is right
                                Temp = MyUniverse.SysGen.RMStart & ThisSymbolName & ".code" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Named_TableProgramText(IndexSymbol))
                                SL = SL & Temp & "*****"

                                IndexSymbol = IndexSymbol + 1
                                MyCheckIndexs(IndexFlowChart, IndexSymbol, IndexNamed, 0, 0)
                                While Symbol_TableCoded_String(IndexSymbol) <> "/name" And IndexSymbol < TopOfFile("Symbol", Symbol_FileCoded)
                                    Select Case Symbol_TableCoded_String(IndexSymbol)
                                        Case "/point"
                                            ThisPointName = Symbol_Table_NameOfPoint(IndexSymbol)
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".name" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(ThisPointName)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".index" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(IndexSymbol.ToString)
                                            SL = SL & Temp
                                            My_RotationName = MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0)
                                            My_Input_Output_Both = MyUnEnum(Symbol_TableX2_io(IndexSymbol), SymbolScreen.ToolStripDropDownInputOutput, 0)
                                            MY_Datatype = Symbol_TableY2_dt(IndexSymbol)
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".name" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(Symbol_Table_NameOfPoint(IndexSymbol))
                                            SL = SL & Temp
                                            SymbolXY.X = MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).X
                                            SymbolXY.Y = MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).Y
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".x" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).X.ToString)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".y" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName).Y.ToString)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".IO" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(My_Input_Output_Both)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Rotation" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(My_RotationName)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Datatype" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(DataType_TableName(MY_Datatype))
                                            SL = SL & Temp

                                            IndexPath = CInt(FindPathNameAt(MyPoint1(PathX, PathY)))
                                            MyPathName = FlowChart_TableNamed(IndexPath) 'data type
                                            'PathX = MyRotated_1(IndexSymbol, IndexPath, My_RotationName).X
                                            'PathY = MyRotated_1(IndexSymbol, IndexPath, My_RotationName).Y
                                            ' 2020  07 16 change it to have not rotation aor symbol (Cause Im calling the wrong subroutine.) 

                                            If MyDistance(
                                               MyPoint1(FlowChart_TableX1(IndexPath), FlowChart_TableY1(IndexPath)),
                                               MyPoint2(SymbolXY.X, SymbolXY.Y)
                                               ) <
                                            MyDistance(
                                                MyPoint1(FlowChart_TableX2_Rotation(IndexPath), FlowChart_TableY2_Option(IndexPath)),
                                                MyPoint2(SymbolXY.X, SymbolXY.Y)) Then
                                                PathX = FlowChart_TableX1(IndexPath)
                                                PathY = FlowChart_TableY1(IndexPath)
                                            Else
                                                PathX = FlowChart_TableX2_Rotation(IndexPath)
                                                PathY = FlowChart_TableY2_Option(IndexPath)
                                            End If
                                            'PathX = MyRotated_1(0, IndexPath, "default").X
                                            'PathY = MyRotated_1(0, IndexPath, "default").Y
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".PathName" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(MyPathName)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Variable" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(MyPathName)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".PathX" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(PathX.ToString)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".pathY" & myuniverse.sysgen.rmEnd & "=" & PrintAbleNull(PathY.ToString)
                                            SL = SL & Temp
                                            ' This is not the distance from the symbol to the path
                                            'Temp = ConstantSeperators & myuniverse.sysgen.rmstart  & ThisPointName & ".Distance =" &
                                            'MyDistance(MyRotated_1(IndexSymbol, IndexFlowChart, My_RotationName),
                                            'MyPoint2(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)))
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Distance" & myuniverse.sysgen.rmEnd & "=" &
                                                MyDistance(MyPoint2(PathX, PathY), MyPoint2(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)))
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".DataTypeName" & myuniverse.sysgen.rmEnd & "=" & DataType_TableName(MY_Datatype)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".DataTypeDescribtion" & myuniverse.sysgen.rmEnd & "=" & DataType_TableDescribtion(MY_Datatype)
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Bytes" & myuniverse.sysgen.rmEnd & "=" & DataType_TableNumberOfBytes(MY_Datatype)
                                            SL = SL & Temp

                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".DataTypeColor" & myuniverse.sysgen.rmEnd & "=" & FindColorFromDataType(DataType_TableName(MY_Datatype))
                                            SL = SL & Temp
                                            Temp = MyUniverse.SysGen.RMStart & ThisPointName & ".Width" & myuniverse.sysgen.rmEnd & "=" & DataType_TableWidth(MY_Datatype)
                                            SL = SL & Temp

                                            FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, MyFixLine(SL))
                                            ' Takes more time to move all of this sting but it's easier to debug for now
                                            MyCheckValidUse(IndexFlowChart)
                                        Case "/line" ' Ignore
                                    End Select
                                    IndexSymbol = IndexSymbol + 1
                                    MyCheckIndexs(IndexFlowChart, IndexSymbol, IndexNamed, 0, 0)
                                End While
                            End If
                        End If
                    End If
                    'Change the /path links to point to NetLinks() number of this net link
                Case "/path" 'Find all of the lines of a path (And put them together in FCStatus)
                    ConnectPath(idex)
                    AWarning(653, 0, 0, 0)
                    ''FlowChart_TableNets(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                    'Connected to both ends
                    AWarning(652, 0, 0, 0)
                    ''FlowChart_TableLinks(IndexFlowChart)
                    'Application.DoEvents()
                    FindAllPaths(IndexFlowChart, MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart))) 'byXY
                    'Application.DoEvents()
                    FindAllPaths(IndexFlowChart, MyPoint1(FlowChart_TableX2_Rotation(IndexFlowChart), FlowChart_TableY2_Option(IndexFlowChart))) 'byXY
                    'Application.DoEvents()
                    FindAllPaths_2(IndexFlowChart, LineNumber) 'By Path Name
                    ''                    FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                    ConnectPath(IndexFlowChart)
                    'Application.DoEvents()
                Case "/constant" 'I'm ignoring this for now. 
                    Abug(970, "UpdateFlowChartLinks", 0, 1)
                    FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, FD & IndexFlowChart & FD & FlowChart_TableNamed(IndexFlowChart) & FD & FlowChart_Table_DataType(IndexFlowChart))
                Case "/error"
                    Abug(969, "UpdateFlowChartLinks", 0, 2)                    ' Not sure if this is a bug
                    FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, "/error" & FD & FlowChart_TableX1(IndexFlowChart) & FD & FlowChart_TableY1(IndexFlowChart) & FD & FlowChart_Table_DataType(IndexFlowChart) & FD & FlowChart_TableNamed(IndexFlowChart))
                Case Else
                    AWarning(999, "not updating Links for ", FlowChart_TableCode(IndexFlowChart), IndexFlowChart)
            End Select
            CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
        End Sub

        Public Shared Sub MyMouseWheel(e As MouseEventArgs) 'catches the mouse wheel to zoom in or out
            MyTrace(52, "MyMouseWheel", 8)

            If e.Delta() > 0 Then
                MyZoomIn(e)
            ElseIf e.Delta < 0 Then
                MyZoomOut(e)
            End If
        End Sub



        Public Shared Sub LimitScale()
            If MyUniverse.SysGen.MyScale <= 0.00001 Then
                MyUniverse.SysGen.MyScale = 0.0625 '1/16
            End If
            If MyUniverse.SysGen.MyScale >= 10 Then
                MyUniverse.SysGen.MyScale = 10
            End If
        End Sub




        'Routine Makes the pictures bigger
        Public Shared Sub MyZoomIn(e As EventArgs) ' Steps scale up
            MyTrace(53, "MyZoomIn", 79 - 74)
            MyUniverse.SysGen.MyScale = MyUniverse.SysGen.MyScale * 2
            limitscale()
            Clear_Screen(FlowChartScreen.PictureBox1)
        End Sub

        'Routine makes the picture smaller
        Public Shared Sub MyZoomOut(e As EventArgs) ' steps scale down
            MyTrace(54, "MyZoomOut", 87 - 82)
            MyUniverse.SysGen.MyScale = MyUniverse.SysGen.MyScale / 2
            limitscale()
            Clear_Screen(FlowChartScreen.PictureBox1)
        End Sub


        'Routine just save where the mouse went down at.
        Public Shared Sub MyMouseDown(Where As PictureBox, e As MouseEventArgs) 'saves xy for mouse button pushed down
            MyTrace(55, "MyMouseDown", 98 - 91)

            MyUniverse.Area.MyInputScreenXY.a.X = e.X
            MyUniverse.Area.MyInputScreenXY.a.Y = e.Y
            MyUniverse.MyMouseAndDrawing.MouseStroke = "" 'New Symbol
        End Sub

        'UNFINISHED
        Public Shared Sub SnapPathToPoint(Where As PictureBox) ' moves all path ends to connect to something
            Dim IndexFlowChart, Jdex As int32
            Dim XY As MyPointStructure
            MyTrace(56, "SnapPathToPoint", 33 - 16)

            For IndexFlowChart = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                UpDateFlowChartLinks(IndexFlowChart, 0)
                Select Case FlowChart_TableCode(IndexFlowChart)
                    Case MyKeyword_2_Byte("/path").ToString  'KeyConstPath
                        XY.X = FlowChart_TableX1(IndexFlowChart)
                        XY.Y = FlowChart_TableY1(IndexFlowChart)
                        Jdex = MyFindPoint(Where, XY)
                        XY.X = FlowChart_TableX2_Rotation(IndexFlowChart)
                        XY.Y = FlowChart_TableY2_Option(IndexFlowChart)
                        Jdex = MyFindPoint(Where, XY)
                End Select
            Next
        End Sub





        'Routine Most everything is done in mouse up button
        Public Shared Sub MyMouseMove(Where As PictureBox, e As MouseEventArgs)
            Dim XY As MyPointStructure
            Dim XY2 As MyPointStructure
            MyTrace(57, "MyMouseMove", 86 - 39)

            XY2.X = e.X
            XY2.Y = e.Y
            XY = Copy2MyScale(Where, XY2)
            ' 2020 07 17 If MyCmdModeString <> "" Then MyMsgCtr("MyMouseMove", 1148, MyCmdModeString, XY.X, XY.Y, e.Button, e.Delta, "", "", "", "")

            ' This is here only to remind me to do something about it.
            Select Case (e.Button)
                Case MouseButtons.Left
                Case MouseButtons.Right
                Case MouseButtons.Middle
                Case MouseButtons.None
                Case MouseButtons.XButton1
                Case MouseButtons.XButton1
            End Select

            Select Case LCase(Trim(MyCmdModeString))
                Case "", Nothing
                Case "cmdaddpath" ' do nothing (later draw line where line should go (and deleete the previous line))
                    Select Case (e.Button)
                        Case MouseButtons.Left ' Draw a following line only if you use the left button
                            MyDrawLineXY_XY(Where, MyUniverse.Area.MyTablesXY, "WHITE") 'Erase the last line
                            MyUniverse.Area.MyInputScreenXY.b.X = e.X
                            MyUniverse.Area.MyInputScreenXY.b.Y = e.Y
                            MyUniverse.Area.MyTablesXY.a = Copy2MyScale(Where, MyUniverse.Area.MyInputScreenXY.a)
                            MyUniverse.Area.MyTablesXY.b = Copy2MyScale(Where, MyUniverse.Area.MyInputScreenXY.b)
                            'MakePathOrthogonal(MyUniverse.Area)
                            MyDrawLineXY_XY(Where, MyUniverse.Area.MyTablesXY, "errored")   ' width should/can only be one 
                        Case MouseButtons.Right ' Reserved for /Stroke
                        Case MouseButtons.Middle
                        Case MouseButtons.None
                        Case MouseButtons.XButton1
                        Case MouseButtons.XButton1
                    End Select
                Case "cmdaddsymbol" ' do nothing (We should be in the select symbol mode just before this
                Case "cmdaddpoint"
                Case "cmdaddline"
                Case "cmdmove"
                    MyCmdModeString = MyCmdModeString
                Case Else
                    Abug(968, "MyMouseMove() : Error ", "-->" & MyCmdModeString & "<--", "Unknown Command Mode Set")
                    'MyMsgCtr("MyMouseMove", 1114, "Error " & MyCmdModeString, "", "", "", "", "", "", "", "")
            End Select
        End Sub


        'Routine This is the major routines to do everything the user wanted with the mouse button UP .
        Public Shared Sub MyMouseUp(Where As PictureBox, e As MouseEventArgs)
            Dim IndexNamed, IndexSymbol, IndexFlowChart, RecordNumber As Int32
            Dim NOPoints, NOLines, NOErrors, NOOthers As Int32
            MyTrace(58, "MyMouseUp", 217 - 51)
            MyUniverse.Area.MyInputScreenXY.b.X = e.X 'Where the mouse button is up
            MyUniverse.Area.MyInputScreenXY.b.Y = e.Y

            'Convert the mouse down and mouse up to be in real world (vs screen world) numbers
            ' This is now failing, and always returns -500,-500
            MyUniverse.Area.MyTablesXY.a = Copy2MyScale(Where, MyUniverse.Area.MyInputScreenXY.a) 'Mouse button down
            MyUniverse.Area.MyTablesXY.b = Copy2MyScale(Where, MyUniverse.Area.MyInputScreenXY.b) ' Mouse button up

            If MyUniverse.SysGen.MinBox < MyUniverse.SysGen.ConstantMinBoxSize Then MyUniverse.SysGen.MinBox = MyUniverse.SysGen.ConstantMinBoxSize
            Select Case LCase(Trim(MyCmdModeString))
                Case "", Nothing
                Case "cmdaddpath"
                    MyMakeArraySizesBigger()
                    'Search for the closest point First and then connect it
                    IndexFlowChart = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded))
                    FlowChart_TableNamed(IndexFlowChart, MakeNewName("Path1", 0))   'unnamed path
                    FlowChart_TableCode_X(IndexFlowChart, MyKeyword_2_Byte("/path").ToString)
                    FlowChart_TableX1(IndexFlowChart, Snap(MyUniverse.Area.MyTablesXY.a.X))
                    FlowChart_TableX2_Rotation(IndexFlowChart, Snap(MyUniverse.Area.MyTablesXY.b.X))
                    FlowChart_TableY1(IndexFlowChart, Snap(MyUniverse.Area.MyTablesXY.a.Y))
                    FlowChart_TableY2_Option(IndexFlowChart, Snap(MyUniverse.Area.MyTablesXY.b.Y))
                    FlowChart_Table_DataType(IndexFlowChart, FlowChartScreen.ToolStripTextBoxMyInputText.Text) 'No Information


                    MakePathOrthogonal(IndexFlowChart)
                    'Paint the orginal end of table record then 
                    PaintAll(Where, IndexFlowChart - 1, IndexFlowChart + 1)
                    'assume that MakePathOrthogonal adds a record at the end of the table, if not, still no harm? just slower
                    PaintAll(Where, TopOfFile("FlowChart", FlowChart_FileCoded), TopOfFile("FlowChart", FlowChart_FileCoded))
                Case "cmdaddsymbol"
                    ' Must have an active symbol to add it.
                    MyMakeArraySizesBigger()
                    If FlowChartScreen.ToolStripDropDownSelectSymbol.Text = "" Then
                        ShowAllForms(HideScreen, ShowScreen, LeaveScreenAlone, ShowScreen, LeaveScreenAlone, HideScreen)
                        FlowChart_TableNamed(TopOfFile("FlowChart", FlowChart_FileCoded), MakeNewName("Path2", 0))
                        Exit Sub
                    Else
                    End If
                    RecordNumber = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded)) ' need to have a resort, for the last item added only
                    FlowChart_TableCode_X(RecordNumber, MyKeyword_2_Byte("/Use").ToString) 'KeyConstUse) '"/use")
                    FlowChart_TableNamed(RecordNumber, FlowChartScreen.ToolStripDropDownSelectSymbol.Text) '
                    FlowChart_TableCode_X(RecordNumber, MyKeyword_2_Byte("/uSe").ToString) 'KeyConstUse) '"/use")
                    FlowChart_TableX1(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.X))
                    FlowChart_TableY1(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.Y))
                    ' This is in a NAMED() not FlowChart. !!!! FlowChart_Tablestroke(RecordNumber, MyUniverse.MyMouseAndDrawing.MouseStroke)
                    FlowChart_TableX2_Rotation(RecordNumber, 0) 'Rotation is assumed to be none for now
                    FlowChart_TableY2_Option(RecordNumber, 0) ' Future opotions

                    CheckForAnySortNeeded("", 122) 'hack
                    ShowSorts("FlowChart", ReSortFlowChart(RecordNumber))
                    CheckForAnySortNeeded("", 123) 'hack
                    PaintAll(Where, RecordNumber - 1, RecordNumber + 1)

                Case "cmdaddconstant"
                    MyMakeArraySizesBigger()

                    RecordNumber = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded))
                    FlowChart_TableCode_X(RecordNumber, "/constant")


                    FlowChart_TableX1(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.X))
                    FlowChart_TableY1(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.Y))
                    'FlowChart_Table_DataType(RecordNumber, SymbolScreen.ComboBoxDataType.SelectedText)
                    FlowChart_Table_DataType(RecordNumber, SymbolScreen.ToolStripDropDownDataType.Text)
                    RecordNumber = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded))
                    FlowChart_TableX2_Rotation(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.X))
                    FlowChart_TableY2_Option(RecordNumber, Snap(MyUniverse.Area.MyTablesXY.a.Y))

                    PaintAll(Where, RecordNumber - 1, RecordNumber + 1)
                    CheckForAnySortNeeded("", 124) 'hack
                    ShowSorts("FlowChart", ReSortFlowChart(RecordNumber)) ' need to have a resort, for the last item added only
                    CheckForAnySortNeeded("", 125) 'hack

                Case "cmdaddline"
                    MyMakeArraySizesBigger()
                    If PrintAbleNull(SymbolScreen.ToolStripDropDownSelectSymbol.Text) = "_" Then ''
                        MyMsgCtr("MyGetPen", 1413, "SymbolScreen.ToolStripDropDownButtonSynbolNames.text.ToString", "4", "", "", "", "", "", "", "")
                    End If
                    CheckForAnySortNeeded("", 126)
                    ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, IndexNamed)) '3/12/19
                    IndexNamed = FindIndexIniSAMTable("Named", "add", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.ToolStripDropDownSelectSymbol.Text) '
                    If IndexNamed < 1 Then
                        FindingMyBugs(10) 'hace Least amount of checking here
                        MyMsgCtr("MyMouseUp", 1268, SymbolScreen.ToolStripDropDownSelectSymbol.Text, "", "", "", "", "", "", "", "") '
                    End If
                    IndexSymbol = Named_TableIndexes(IndexNamed)

                    If IndexSymbol = constantMyErrorCode Then
                        Abug(967, MyCmdModeString, IndexSymbol, 0)
                        IndexSymbol = GetSelfCorrectingIndexes(SymbolScreen.TextBoxSymbolName.Text)
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        If IndexSymbol < 1 Then
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                            '
                            MyInsertSymbolRecord_Line(NewTopOfFile("Symbol", Symbol_FileCoded),
                                                 SymbolScreen.ToolStripDropDownSelectSymbol.Text,'
                                                 "/name",
                                                 MyLine1(ZeroZero, ZeroZero),
                                                 "")
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                        Else
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                            '
                            MyInsertSymbolRecord_Line(NewTopOfFile("Symbol", Symbol_FileCoded),
                                                 SymbolScreen.ToolStripDropDownSelectSymbol.Text,'
                                                 "/line",
                                                 MyUniverse.Area.MyTablesXY,
                                                 "")
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                        End If
                        CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                    Else
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                        MyInsertSymbolRecord_Line(IndexSymbol + 1,
                                             Named_TableSymbolName(IndexNamed),
                                             "/line",
                                             MyUniverse.Area.MyTablesXY,
                                             SymbolScreen.ToolStripDropDownButtonColor.ToString)
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                    End If
                Case "cmdaddpoint"
                    If SymbolScreen.ToolStripDropDownSelectSymbol.Text = "" Then
                        ShowAllForms(HideScreen, ShowScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone, HideScreen)
                        FlowChart_TableNamed(TopOfFile("FlowChart", FlowChart_FileCoded), MakeNewName("Path2", 0))
                        Exit Sub
                    Else
                    End If
                    If PrintAbleNull(SymbolScreen.TextBoxSymbolName.Text) = "_" Then MyMsgCtr("MyMouseUp", 1413, SymbolScreen.TextBoxSymbolName.Text, "5", "", "", "", "", "", "", "")
                    CheckForAnySortNeeded("", 130)
                    ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, IndexNamed)) '3/12/19
                    IndexNamed = FindIndexIniSAMTable("Named", "add", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.TextBoxSymbolName.Text)
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                    IndexSymbol = Named_TableIndexes(IndexNamed)
                    If IndexSymbol <= 0 Then
                        IndexSymbol = GetSelfCorrectingIndexes(SymbolScreen.TextBoxSymbolName.Text)
                        If IndexSymbol < 1 Then
                            ' Add a missing name record to the table
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                            MyInsertSymbolRecord_Line(NewTopOfFile("Symbol", Symbol_FileCoded),
                                             Named_TableSymbolName(IndexNamed),
                                "/name",
                                             MyUniverse.Area.MyTablesXY,
                                "")
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                            IndexSymbol = GetSelfCorrectingIndexes(SymbolScreen.TextBoxSymbolName.Text)
                        Else
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        End If
                    Else
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        If Symbol_TableCoded_String(IndexSymbol) <> "/name" Then ' We have  a wrong Indexes
                            F_C.GetSelfCorrectingIndexes(SymbolScreen.TextBoxSymbolName.Text)
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        End If
                    End If
                    UpdateThePointsLineComboBox(SymbolScreen.TextBoxSymbolName.Text)
                    ' This makes sure that the names of the points, and the color of the lines are in the list box 
                    MyUniverse.Area.MyTablesXY.b.X = FindIndexIniSAMTable("Datatype", "Donotadd", DataType_FileName, DataType_iSAM_, SymbolScreen.ToolStripDropDownDataType.Text) 'MyEnumValue(Pop(SymbolScreen.ToolStripDropDownButtonPointDataType.Text, ConstantDelimeters), SymbolScreen.ToolStripDropDownButtonPointDataType)
                    MyUniverse.Area.MyTablesXY.b.Y = MyEnumValue(Pop(SymbolScreen.ToolStripDropDownInputOutput.Text, ConstantDelimeters), SymbolScreen.ToolStripDropDownInputOutput)
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04

                    '
                    NumberGraphicsInASymbol(IndexSymbol, NOPoints, NOLines, NOErrors, NOOthers)


                    'todo bug in that this is not giving the correct name, and needs to be written
                    MyInsertSymbolRecord_Line(IndexSymbol + 1,
                                                 SymbolScreen.ToolStripDropDownSelectSymbol.Text,
                                                 "/point",
                                                 MyUniverse.Area.MyTablesXY,
                    SymbolScreen.ComboBoxPointNameList.Items(NOPoints).ToString)


                    CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
                    FindingMyBugs(10)'hace Least amount of checking here 'hack 2020 08 04
                    ' 2020 07 18 meaningless !!!                    MyUniverse.Area.MyTablesXY.b.X = SymbolScreen.ToolStripDropDownInputOutput.SelectedIndex
                Case "cmdmove"
                    MyCmdMove(Where)
                    CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
                Case "cmddelete"
                    Select Case Where.Parent.Name
                        Case "FlowChartScreen"
                            MyUniverse.MyStaticData.SelectedObject = MyFindPoint(Where, MyUniverse.Area.MyTablesXY.a)
                            PaintErase(Where, MyUniverse.MyStaticData.SelectedObject)
                            FlowChart_TableCode_X(MyUniverse.MyStaticData.SelectedObject, "/delete") 'Delete Mark Only
                            ' We should be turning off the item
                            PaintAll(Where, MyUniverse.MyStaticData.SelectedObject - 1, MyUniverse.MyStaticData.SelectedObject + 1)
                        Case "SymbolScreen"
                            MyUniverse.MyStaticData.SelectedObject = MyFindPoint(Where, MyUniverse.Area.MyTablesXY.a)
                            'PaintErase(Where, myuniverse.Mystaticdata.SelectedObject)
                            Symbol_TableCode(MyUniverse.MyStaticData.SelectedObject, "/delete") 'Delete Mark Only
                            FindingMyBugs(10) 'hace Least amount of checking here 'hack
                            CheckForAnySortNeeded("", 134)
                            RecordNumber = FindIndexIniSAMTable("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.ToolStripDropDownSelectSymbol.Text) '
                            CheckForAnySortNeeded("", 135)
                            If RecordNumber = constantMyErrorCode Then
                            Else
                                Named_TableIndexes(RecordNumber, 0) ' Delete the old Indexes (for now)
                                Clear_Screen(Where)
                            End If
                            RecordNumber = MyUniverse.SysGen.ConstantSymbolCenter + MyUniverse.SysGen.ConstantSymbolCenter
                            PaintEach(SymbolScreen.PictureBox1,
                                         MyPoint1(RecordNumber, RecordNumber),
                                         SymbolScreen.ToolStripDropDownSelectSymbol.Text, "Default")'
                            ' We should be turning off the item
                        Case "OptionScreen"
                    End Select
                Case Else
                    MyMsgCtr("MyMouseUp", 1283, MyCmdModeString, "", "", "", "", "", "", "", "")
            End Select
            CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
        End Sub

        Public Shared Sub UpdateThePointsLineComboBox(SymbolName As String)
            Dim NumberOfPoints, NumberOfLines, NumberOfErrors, NumberOfOther As Int32 ' Number of points/Lines in a symbol 
            ' need to have the point name, and the Datatype, and the IO 
            NumberGraphicsInASymbol(FindInSymbolList(SymbolName), NumberOfPoints, NumberOfLines, NumberOfErrors, NumberOfOther)

            While NumberOfPoints + 4 >= SymbolScreen.ComboBoxPointNameList.Items.Count
                SymbolScreen.ComboBoxPointNameList.Items.Add("VariableName" & CStr(SymbolScreen.ComboBoxPointNameList.Items.Count))
            End While
            While NumberOfLines + 4 >= SymbolScreen.ComboBoxLineNameList.Items.Count
                SymbolScreen.ComboBoxLineNameList.Items.Add("Line Color" & CStr(SymbolScreen.ComboBoxLineNameList.Items.Count))
            End While
        End Sub




        Public Shared Sub MyCmdMove(Where As PictureBox)
            MyTrace(59, "MyCmdMove", 85 - 20)

            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    'Get the closest object (/path could be either end of the path)
                    MyUniverse.MyStaticData.SelectedObject = MyFindPoint(Where, MyUniverse.Area.MyTablesXY.a)
                    'We should flash this object 
                    If MyUniverse.MyStaticData.SelectedObject <> constantMyErrorCode Then
                        PaintAll(Where, MyUniverse.MyStaticData.SelectedObject, MyUniverse.MyStaticData.SelectedObject)
                        If LCase(Trim(FlowChart_TableCode(MyUniverse.MyStaticData.SelectedObject))) = "/path" Then
                            ' need to find the closest end to change
                            If MyABS(MyUniverse.Area.MyTablesXY.a.X - FlowChart_TableX1(MyUniverse.MyStaticData.SelectedObject)) +
                               MyABS(MyUniverse.Area.MyTablesXY.a.Y - FlowChart_TableY1(MyUniverse.MyStaticData.SelectedObject)) >
                               MyABS(MyUniverse.Area.MyTablesXY.a.X - FlowChart_TableX2_Rotation(MyUniverse.MyStaticData.SelectedObject)) +
                               MyABS(MyUniverse.Area.MyTablesXY.a.Y - FlowChart_TableY2_Option(MyUniverse.MyStaticData.SelectedObject)) Then
                                PaintErase(Where, MyUniverse.MyStaticData.SelectedObject)
                                FlowChart_TableX2_Rotation(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.X))
                                FlowChart_TableY2_Option(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.Y))
                            Else
                                PaintErase(Where, MyUniverse.MyStaticData.SelectedObject)
                                FlowChart_TableX1(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.X))
                                FlowChart_TableY1(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.Y))
                            End If
                        ElseIf LCase(Trim(FlowChart_TableCode(MyUniverse.MyStaticData.SelectedObject))) = "/use" Then
                            MoveSymbolAndAllPaths(Where, MyUniverse.MyStaticData.SelectedObject, MyPoint1(MyUniverse.Area.MyTablesXY.b.X - MyUniverse.Area.MyTablesXY.a.X, MyUniverse.Area.MyTablesXY.b.Y - MyUniverse.Area.MyTablesXY.a.Y))
                        Else ' /use or constant
                            'move to where the mouse button let up
                            PaintErase(Where, MyUniverse.MyStaticData.SelectedObject)
                            FlowChart_TableX1(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.X))
                            FlowChart_TableY1(MyUniverse.MyStaticData.SelectedObject, Snap(MyUniverse.Area.MyTablesXY.b.Y))
                        End If

                        'redisplay 1 (We should be turning off the old location)
                        PaintAll(Where, MyUniverse.MyStaticData.SelectedObject, MyUniverse.MyStaticData.SelectedObject)
                    Else
                        PaintAll(Where, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
                    End If
                Case "SymbolScreen" 'Move
                    'Get the closest object (/path could be either end of the path)
                    MyUniverse.MyStaticData.SelectedObject = MyFindSymbolPoint(Where, MyUniverse.Area.MyTablesXY.a, SymbolScreen.ToolStripDropDownSelectSymbol.Text) '
                    'We should flash this object 
                    '                            PaintAll(FlowChartScreen.PictureBox1, MyStaticData.SelectedObject, MyStaticData.SelectedObject)

                    If Symbol_TableCoded_String(MyUniverse.MyStaticData.SelectedObject) = "/line" Then
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        ' need to find the closest end to change
                        If MyABS(MyUniverse.Area.MyTablesXY.a.X - Symbol_TableX1(MyUniverse.MyStaticData.SelectedObject)) +
                                     MyABS(MyUniverse.Area.MyTablesXY.a.Y - Symbol_TableY1(MyUniverse.MyStaticData.SelectedObject)) >
                                     MyABS(MyUniverse.Area.MyTablesXY.a.X - Symbol_TableX2_io(MyUniverse.MyStaticData.SelectedObject)) +
                                     MyABS(MyUniverse.Area.MyTablesXY.a.Y - Symbol_TableY2_dt(MyUniverse.MyStaticData.SelectedObject)) Then
                            Symbol_TableX2_io(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.X)
                            Symbol_TableY2_dt(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.Y)
                        Else
                            Symbol_TableX1(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.X)
                            Symbol_TableY1(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.Y)
                        End If
                    Else ' /Point
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        'move to where the mouse button let up
                        Symbol_TableX1(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.X)
                        Symbol_TableY1(MyUniverse.MyStaticData.SelectedObject, MyUniverse.Area.MyTablesXY.b.Y)
                    End If

                    'redisplay 1 (We should be turning off the old location)
                    PaintAll(Where, MyUniverse.MyStaticData.SelectedObject, MyUniverse.MyStaticData.SelectedObject)
            End Select


        End Sub


        'Gives the Indexes to the data
        Public Shared Function FindiSAM_IN_Table(ByRef MyTable As String, Myfunction As String, ByRef MyArray() As String, ByRef iSAM() As int32, WhatToFind As String) As int32
            MyTrace(61, "FindiSAM_IN_Table", 311 - 291)

            If MyCompared1_a(MyUniverse.MyCheatSheet.LastString, WhatToFind) = 0 Then
                If MyUniverse.MyCheatSheet.LastIndex < UBound(MyArray) And MyUniverse.MyCheatSheet.LastIndex > 0 Then
                    If MyCompared1_a(MyArray(MyUniverse.MyCheatSheet.LastIndex), WhatToFind) = 0 Then
                        FindiSAM_IN_Table = MyUniverse.MyCheatSheet.LastIndex
                        Exit Function
                    End If
                End If
            End If
            CheckForAnySortNeeded("", 136)
            FindiSAM_IN_Table = FindIndexIniSAMTable(MyTable, Myfunction, MyArray, iSAM, WhatToFind)
            CheckForAnySortNeeded("", 137)
            If FindiSAM_IN_Table = constantMyErrorCode Then
                FindingMyBugs(10) 'hace Least amount of checking here
            Else
                FindiSAM_IN_Table = iSAM(MyMinMax(FindiSAM_IN_Table, 1, UBound(MyArray)))
            End If
        End Function



        'Gives the Indexes to the data
        Public Shared Function FindiSAM_IN_Table(ByRef MyTable As String, ByRef Myfunction As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32, WhatToFind As int32) As int32
            Dim I As int32
            MyTrace(62, "FindiSAM_IN_Table", 29 - 16)

            CheckForAnySortNeeded("", 138)
            I = FindIndexIniSAMTable(MyTable, Myfunction, MyArrayLong, iSAM, WhatToFind)
            CheckForAnySortNeeded("", 139)
            If I = constantMyErrorCode Then
                Abug(966, MyTable, Myfunction, 0)
                FindiSAM_IN_Table = I
            Else
                FindiSAM_IN_Table = iSAM(MyMinMax(I, 1, UBound(MyArrayLong)))
            End If
        End Function



        Public Shared Sub SelectInToolStrip(DD As ToolStripDropDownButton, s As String)
            DD.Text = s
        End Sub


        Public Shared Sub SelectInToolStripDropDownButton(CB As ToolStripDropDownButton, WhatToSelect As String)
            MyTrace(63, "SelectInToolStripDropDownButton", 3582 - 3564)
            If IsNothing(WhatToSelect) Then Exit Sub
            CB.DropDownItems.Find(WhatToSelect, True) ' undone not sure if this will work yet
        End Sub

        '***********************************************************************
        'checking that the symbol name is not already in the symbol table
        Public Shared Function CheckNotInList(ByRef MyTable As String, ByRef MyFunction As String, ByRef MyArray() As String, ByRef iSAM() As Int32, ByRef SymbolName As String) As Int32
            Dim Idex As Int32
            MyTrace(64, "CheckNotInList", 3607 - 3584)

            For Idex = 1 To TopOfFile(MyTable, MyArray, iSAM)
                Select Case MyCompared3(MyArray(Idex), SymbolName, MyArray(Idex))
                    Case -5
                    Case -4
                    Case -3
                    Case -2
                    Case -1 'a=b
                        CheckNotInList = Idex
                        Exit Function
                    Case -0
                    Case 1 'b=c
                        CheckNotInList = Idex
                        Exit Function
                    Case 2
                    Case 3
                    Case 4
                    Case 5
                End Select
            Next
            CheckNotInList = constantMyErrorCode  ' Still Not Found 
        End Function


        '*******************************************
        'returns the Indexes to the index of the iSAM 
        Public Shared Function FindIndexIniSAMTable(ByRef MyTable As String, MyFunction As String, ByRef MyArray() As String, ByRef iSAM() As int32, WhatToFind As String) As int32
            ' Follow IDEX it is using the top of file twice
            '************************* This needs to be changed to a binary search instead of a=going through all of the list
            Dim Jdex, Kdex, Idex As int32
            Dim ErrorCount As int32
            MyTrace(65, "FindIndexIniSAMTable", 475 - 335)

            If Trim(WhatToFind) = "" Then
                FindIndexIniSAMTable = constantMyErrorCode
                Abug(964, "Searching for nothing in table " & MyTable, MyTable, MyFunction)
                Return constantMyErrorCode
            End If


            '20200711 updated cheat 
            ' If what you want to find is already found last time and so check if you do not have to find it again
            If LCase(Trim(MyTable)) = LCase(Trim(MyUniverse.MyCheatSheet.LastiSAMStringTable)) Then
                If MyCompared1_a(MyUniverse.MyCheatSheet.LastiSAMStringString, WhatToFind) = 0 Then
                    If MyUniverse.MyCheatSheet.LastiSAMStringIndex <= TopOfFile(MyTable, MyArray, iSAM) Then
                        FindIndexIniSAMTable = MyUniverse.MyCheatSheet.LastiSAMStringIndex
                        Exit Function
                    End If
                End If
            End If

            ' Now do binary search for it
            Kdex = TopOfFile(MyTable, MyArray, iSAM)

            Idex = MyMinMax(CInt(Kdex / 2), 1, Kdex)
            Jdex = MyMinMax(CInt(Idex / 2), 1, Kdex)

            ErrorCount = 2048


            While ErrorCount > 0
                ErrorCount -= 1
                ' Need test when to exit while
                Idex = MyMinMax(Idex, 1, Kdex)
                Select Case MyCompared3(MyArray(iSAM(Idex)), WhatToFind, MyArray(iSAM(Idex + 1)))
                    Case -5 '-5 A is not <= than C (A>C) Error
                        Abug(963, "FindIndexInIsamTable", "Sorting bug somewhere else", Idex)
                        ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, Idex))
                        ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, Idex - 1))
                        ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, Idex + 1))
                        FindIndexIniSAMTable = FindIndexIniSAMTable(MyTable, MyFunction, MyArray, iSAM, WhatToFind)
                        Exit Function
                    Case -4 '-4 A = start Of list (So Lowest)
                        If Idex = 1 Then
                            Idex = Kdex
                            Exit While
                        End If
                        Idex = MyMinMax(Idex + 1, 1, Kdex)
                    Case -3 '-3 A is higher than B  
                        If Idex = 1 Then
                            Idex = Kdex
                            Exit While ' In case what we want is before the beggining
                        End If
                        Idex = MyMinMax(Idex - Jdex, 1, Kdex)
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case -2 '-2 B is higher than C ' So you have to look forwards 
                        Idex = MyMinMax(Idex + Jdex, 1, Kdex)
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    'Case -1'-1 A = B
                    Case -1  '-1 is equal to A and 0 is between A and C
                        MyUniverse.MyCheatSheet.LastiSAMStringTable = MyTable
                        MyUniverse.MyCheatSheet.LastiSAMStringString = WhatToFind
                        MyUniverse.MyCheatSheet.LastiSAMStringIndex = iSAM(Idex)
                        FindIndexIniSAMTable = iSAM(Idex)
                        Exit Function
                    Case 0 'test 2 & 10 A and C = nothing or A<b<C should be between these two
                        ' binary search is failing here, but double checknot in list is finding it ERROR 'hack
                        'This is all extra code
                        FindIndexIniSAMTable = CheckNotInList(MyTable, MyFunction, MyArray, iSAM, WhatToFind)
                        If FindIndexIniSAMTable = constantMyErrorCode Then
                            Exit While
                        Else
                            Exit Function
                        End If
                    Case 1 ' 1 B = C
                        Idex = MyMinMax(Idex + 1, 1, Kdex) ' forward on so that you have what you found the one before
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case 2 ' 2 A is lower than B 
                        Idex = MyMinMax(Idex + Jdex, 1, Kdex) ' back up one
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case 3 ' 3 Or C is higher then B
                        Idex = MyMinMax(Idex - Jdex, 1, Kdex) ' back up one
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case 4 ' 4 C is the end of the list (So Highest) [ Found this to not be true when B>A and C=nothing ]  and B > A 
                        Idex = Idex + 1 ' To point the the end of the list
                        If MyArray(iSAM(Idex)) > WhatToFind Then
                            Abug(746, "Program data error!!! An invalid assumption because the list is not sorted correctly", PrintAbleNull(MyArray(iSAM(Idex))) & " : " & PrintAbleNull(WhatToFind & " : " & MyArray(iSAM(Idex + 1))), 0)
                        End If
                        Exit While 'Insert it at the end if "Add"
                    Case 5 ' 5 Error (unknown relationship)
                        Abug(962, MyTable, MyFunction, 0)
                        FindIndexIniSAMTable = NewTopOfFile(MyTable, MyArray, iSAM)
                        Exit Function
                End Select
            End While
            If WhatToFind = "_" Or WhatToFind = "" Or IsNothing(WhatToFind) Then
                FindIndexIniSAMTable = constantMyErrorCode
                Exit Function
            End If

            If LCase(Trim(MyFunction)) = "add" Then
                Idex = MyMinMax(Idex, 1, NewTopOfFile(MyTable, MyArray, iSAM))
                If MyCompared1_a(MyArray(Idex), WhatToFind) = 0 Then ' then we have relly found it
                    CheckThis("FindIndexIniSAMTable", 6, MyArray, iSAM, Idex)
                    FindIndexIniSAMTable = Idex '3/13/19 Should return the one found
                    Exit Function
                End If

                If PrintAbleNull(WhatToFind) = "_" Then MyMsgCtr("FindIndexIniSAMTable", 1413, WhatToFind, "6", "", "", "", "", "", "", "")

                '20200625 Below fixes a problem of adding something where there is something already.
                Idex = NewTopOfFile(MyTable, MyArray, iSAM)
                While Not IsNothing(MyArray(Idex))
                    Idex += 1
                End While

                MyArray(Idex) = WhatToFind
                iSAM(Idex) = Idex
                ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, Idex)) 'sorted
                Select Case LCase(MyTable)'220200711 changed to resort instead of flagging to resort it all
                    Case "color"
                        ShowSorts("Color", MyReSort("Color", Color_FileName, Color_iSAM_, Idex)) ' Try to only sort the one added
                        'MyUniverse.MyCheatSheet.ColorsSorted += 1 ' Mark as needs sorting
                    Case "datatype"
                        ShowSorts("DataType", MyReSort("DataType", DataType_FileName, DataType_iSAM_, Idex))
                        'MyUniverse.MyCheatSheet.DataTypeSorted += 1
                    Case "named"
                        ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, Idex))
                        'MyUniverse.MyCheatSheet.NamedSorted += 1
                    Case "FlowChart"
                        ReSortFlowChart(Idex)
                        'MyUniverse.MyCheatSheet.FlowChartSorted += 1
                    Case Else
                        ShowSorts("Color", MyReSort("Color", Color_FileName, Color_iSAM_, Idex)) ' Try to only sort the one added
                        ShowSorts("DataType", MyReSort("DataType", DataType_FileName, DataType_iSAM_, Idex))
                        ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, Idex))
                        ShowSorts("Named", MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, Idex))
                        ReSortFlowChart(Idex)
                End Select
                FindIndexIniSAMTable = Idex
            Else ' Not a bug, it just can not be found 
                FindIndexIniSAMTable = CheckNotInList(MyTable, MyFunction, MyArray, iSAM, WhatToFind)
                If FindIndexIniSAMTable <= 0 Then
                    FindIndexIniSAMTable = constantMyErrorCode
                Else
                    AWarning(700, "Found it the hard way in doublchecknotinlist()", WhatToFind, MyTable)
                    FindIndexIniSAMTable = FindIndexIniSAMTable
                End If
            End If
        End Function

        '***********************************************************************************
        ' Find the string name in the array of names (table listed for referance only)
        Public Shared Function FindInSortedLanguageList(ByRef MyTable As String, ByRef WhatToFind As String, ByRef MyArray() As String) As Int32
            Dim Jdex, Kdex, MaxDex, MinDex, MyErrors As Int32
            MyTrace(66, "FindInSortedLanguageList", 3880 - 3772)

            ' Never search for no name
            If Trim(WhatToFind) = "" Or IsNothing(WhatToFind) Then
                FindInSortedLanguageList = constantMyErrorCode
                Exit Function
            End If
            MyErrors = 1024  'This is only to avoid looping for ever if there is a problem
            Kdex = UBound(MyArray) ' Get the top of the array
            FindInSortedLanguageList = MyMinMax(CInt(Kdex / 2), 1, Kdex)    ' The current location of this name 
            Jdex = MyMinMax(CInt(FindInSortedLanguageList / 2), 1, Kdex)    ' How much to move up or down the list

            ' This is to avoid a repeat search of the same thing. Os I check and save the last one that was found, and reuse it again
            If MyUniverse.MyCheatSheet.LastLanguageTable = MyTable Then
                If MyUniverse.MyCheatSheet.LastLanguageString = WhatToFind Then
                    FindInSortedLanguageList = MyUniverse.MyCheatSheet.LastLanguageIndex
                    If FindInSortedLanguageList > UBound(MyArray) Then
                        Abug(999, "Index outside the boundries Array ", FindInSortedLanguageList, UBound(MyArray))
                        FindInSortedLanguageList = UBound(MyArray)
                    End If
                    Exit Function
                End If
            End If
            'Application.DoEvents()

            While MyErrors > 0 ' just to avoid a loop forever
                MyErrors -= 1 ' Can only loop X number of times.
                FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList, 1, Kdex)
                MaxDex = MyMinMax(FindInSortedLanguageList + 1, 1, Kdex)
                MinDex = MyMinMax(FindInSortedLanguageList, 1, Kdex)
                FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList, 1, Kdex) '2020 09 25

                Select Case MyCompared3(MyArray(MinDex), WhatToFind, MyArray(MaxDex))
                    Case -5 '-5 A is not <= than C (A>C) Error
                        Abug(961, "FindInSortedLanguageList()", "Sorting bug somewhere else", FindInSortedLanguageList)
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, MinDex))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, FindInSortedLanguageList))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, MaxDex))
                        FindInSortedLanguageList = constantMyErrorCode
                        If FindInSortedLanguageList > UBound(MyArray) Then
                            Abug(999, "Index outside the boundries Array ", FindInSortedLanguageList, UBound(MyArray))
                            FindInSortedLanguageList = UBound(MyArray)
                        End If
                        Exit Function
                    Case -4 '-4 A = start Of list (So Lowest)
                        If Jdex = 1 Then
                            FindInSortedLanguageList = Kdex
                            Exit While
                        End If
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList + 1, 1, Kdex)
                    Case -3 '-3 A is higher than B  
                        If FindInSortedLanguageList = 1 Then
                            '???? Why the end of the list instead of the beggining of the list, 
                            'because A > B, so we should return 1 or not found
                            FindInSortedLanguageList = Kdex
                            Exit While ' In case what we want is before the beggining
                        End If
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList - Jdex, 1, Kdex)
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case -2 '-2 B is higher than C ' So you have to look forwards 
                        If FindInSortedLanguageList >= Kdex And Jdex = 1 Then
                            Exit While ' This is then at the end of the list
                        End If
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList + Jdex, 1, Kdex)
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    'Case -1'-1 A = B
                    Case -1  '-1 is equal to A and 0 is between A and C
                        MyUniverse.MyCheatSheet.LastLanguageTable = MyTable
                        MyUniverse.MyCheatSheet.LastLanguageString = WhatToFind
                        MyUniverse.MyCheatSheet.LastLanguageIndex = FindInSortedLanguageList
                        If FindInSortedLanguageList > UBound(MyArray) Then
                            Abug(999, "Index outside the boundries Array ", FindInSortedLanguageList, UBound(MyArray))
                            FindInSortedLanguageList = UBound(MyArray)
                        End If
                        Exit Function
                    Case 0 'test 2 & 10 A and C = nothing or A<b<C should be between these two
                        FindInSortedLanguageList = constantMyErrorCode
                        Exit While
                    Case 1 ' 1 B = C
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList + 1, 1, Kdex) ' forward on so that you have what you found the one before' 2020 09 07
                        Jdex = 1' MyMinMax(cint(Jdex / 2), 1, Kdex) 2020 09 07
                    Case 2 ' 2 A is lower than B 
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList + Jdex, 1, Kdex) ' back up one
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case 3 ' 3 Or C is higher then B
                        FindInSortedLanguageList = MyMinMax(FindInSortedLanguageList - Jdex, 1, Kdex) ' back up one
                        Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                    Case 4 ' 4 C is the end of the list (So Highest) and B > A 
                        '2020 09 07 added if it is the last one in the list
                        If MyArray(FindInSortedLanguageList) = WhatToFind Then
                            MyUniverse.MyCheatSheet.LastLanguageTable = MyTable
                            MyUniverse.MyCheatSheet.LastLanguageString = WhatToFind
                            MyUniverse.MyCheatSheet.LastLanguageIndex = FindInSortedLanguageList
                            If FindInSortedLanguageList > UBound(MyArray) Then
                                Abug(999, "Index outside the boundries Array ", FindInSortedLanguageList, UBound(MyArray))
                                FindInSortedLanguageList = UBound(MyArray)
                            End If
                            Exit Function
                        End If
                        FindInSortedLanguageList = FindInSortedLanguageList + 1 ' To point the the end of the list
                        Exit While 'Insert it at the end if "Add"
                    Case 5 ' 5 Error (unknown relationship)
                        If IsNothing(WhatToFind) Then
                            Exit While
                        End If
                        If Trim(WhatToFind) = "" Then
                            Exit While
                        End If
                        If WhatToFind = FD Then
                            Exit While
                        End If
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, MinDex))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, FindInSortedLanguageList))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, MaxDex))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, UBound(MyArray) - 2))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, UBound(MyArray) - 1))
                        ShowSorts("LanguageKeyWords", ReSortLanguageKeyWords("LanguageKeyWords", MyArray, UBound(MyArray)))
                        FindInSortedLanguageList = UBound(MyArray)
                        If FindInSortedLanguageList > UBound(MyArray) Then
                            Abug(999, "Index outside the boundries Array ", FindInSortedLanguageList, UBound(MyArray))
                            FindInSortedLanguageList = UBound(MyArray)
                        End If
                        Exit Function
                End Select
            End While

            FindInSortedLanguageList = constantMyErrorCode
        End Function



        '*******************************************
        'Gives the Indexes to the index of the iSAM 
        Public Shared Function FindIndexIniSAMTable(ByRef MyTable As String, ByRef MyFunction As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32, ByRef WhatToFind As int32) As int32
            '************************* This needs to be changed to a binary search instead of a=going through all of the list
            Dim Index, J, Kdex As int32
            MyTrace(67, "FindIndexIniSAMTable", 612 - 482)

            Index = TopOfFile(MyTable, MyArrayLong, iSAM)
            Kdex = MyMinMax(Index, 1, TopOfFile(MyTable, MyArrayLong, iSAM)) '3/15/19 Removed +1  to the index
            Index = MyMinMax(Index, 1, Kdex)
            J = CInt(Index / 2)
            If IsNothing(MyArrayLong(1)) Then ' Test for first one
            Else

                'This does no good if I do not set them on finding a match last time
                If MyUniverse.MyCheatSheet.LastiSAMNumberTable = MyTable Then
                    If MyCompared1(MyUniverse.MyCheatSheet.LastiSAMNumberNumber, WhatToFind) = 0 Then
                        If MyUniverse.MyCheatSheet.LastiSAMNumberIndex <= Kdex Then
                            If MyArrayLong(iSAM(MyUniverse.MyCheatSheet.LastiSAMNumberIndex)) = WhatToFind Then
                                FindIndexIniSAMTable = iSAM(MyUniverse.MyCheatSheet.LastiSAMNumberIndex)
                                Exit Function
                            End If
                        End If
                    End If
                End If
                While 1 = 1 ' Forever loop
                    Application.DoEvents()
                    If MyCompared2(MyArrayLong, iSAM, Index - 1, Index) = 1 And '  MyArrayLong(iSAM(Index - 1)), MyArrayLong(iSAM(Index))) = 1 And
                        MyCompared2(MyArrayLong, iSAM, Index, Index + 1) = -1 Then 'MyArrayLong(iSAM(Index)), MyArrayLong(iSAM(Index + 1))) = -1 Then
                        'The MyArrayLong is not in the correct order
                        CheckForAnySortNeeded("", 144) 'hack
                        ShowSorts(MyTable, MyReSort_long(MyTable, MyArrayLong, iSAM, MyMinMax(Index - 1, 1, Kdex)))
                        ShowSorts(MyTable, MyReSort_long(MyTable, MyArrayLong, iSAM, MyMinMax(Index, 1, Kdex)))
                        ShowSorts(MyTable, MyReSort_long(MyTable, MyArrayLong, iSAM, MyMinMax(Index + 1, 1, Kdex)))
                        CheckForAnySortNeeded("", 145) 'hack
                    End If

                    If MyCompared1(MyArrayLong(iSAM(Index)), WhatToFind) < 0 And
                                MyCompared1(MyArrayLong(iSAM(Index + 1)), WhatToFind) > 0 Then
                        FindIndexIniSAMTable = Index
                        Exit While
                    End If

                    Select Case MyCompared1(MyArrayLong(iSAM(Index)), WhatToFind)
                        Case -3
                            Index = Index + J
                        Case -2
                            Index = Index + J
                        Case -1
                            Index = Index + J
                        Case 0 ' Match so return
                            FindIndexIniSAMTable = Index
                            MyUniverse.MyCheatSheet.LastiSAMNumberTable = MyTable
                            MyUniverse.MyCheatSheet.LastiSAMNumberNumber = WhatToFind
                            MyUniverse.MyCheatSheet.LastiSAMNumberIndex = Index
                            FindIndexIniSAMTable = iSAM(MyUniverse.MyCheatSheet.LastiSAMNumberIndex)
                            Exit Function
                        Case 1
                            Index = Index - J
                        Case 2
                            Index = Index - J
                        Case 3
                            Index = Index - J
                        Case Else
                            Index = Index + J
                    End Select
                    If Index > Kdex And J = 1 Then
                        J = 0
                        Exit While
                    End If
                    Index = MyMinMax(Index, 1, Kdex)
                    If Index = 1 Then
                        If MyCompared1(MyArrayLong(iSAM(1)), WhatToFind) = 1 Then
                            Abug(959, MyTable, MyFunction, 0) ' Not sure if this is an error, or just not found
                            J = 0
                            Index = constantMyErrorCode
                            Exit While
                        End If
                    End If
                    If iSAM(Index) <> 0 Then
                        If J = 1 Then
                            If MyCompared1(MyArrayLong(iSAM(Index)), WhatToFind) = -1 Then
                                If MyCompared1(MyArrayLong(iSAM(MyMinMax(Index + 1, 1, Kdex))), WhatToFind) >= 1 Then
                                    J = 0
                                    Exit While
                                End If
                            End If
                        End If
                    End If
                    J = MyMinMax(CInt(J / 2), 1, Kdex)
                End While
            End If

            If LCase(MyFunction) = "add" Then
                FindingMyBugs(10) 'hace Least amount of checking here
                '******* hack becase I still have a bug keeping the MyArray sorted.
                'Last attempt to find be3cause I've got a bug
                For Index = 1 To UBound(MyArrayLong)
                    If MyCompared1(MyArrayLong(Index), WhatToFind) = 0 Then
                        MyMsgCtr("FindIndexIniSAMTable", 1215, MyArrayLong(Index).ToString, WhatToFind.ToString, "", "", "", "", "", "", "")
                        FindIndexIniSAMTable = Index
                        SortALLiSAM() 'Resort everything 
                        FindingMyBugs(10) 'hace Least amount of checking here
                        Exit Function
                    End If
                Next Index
                ' If the above fails then try a SLOW loop of everything
                '******** End of hack 

                Index = TopOfFile(MyTable, MyArrayLong, iSAM)
                If IsNothing(MyArrayLong(Index)) Then
                Else
                    Index = Index + 1
                End If

                If PrintAbleNull(WhatToFind.ToString) = "_" Then MyMsgCtr("FindIndexIniSAMTable", 1413, WhatToFind.ToString, "7", "", "", "", "", "", "", "")

                FindingMyBugs(10) 'hace Least amount of checking here
                MyArrayLong(Index) = WhatToFind
                FindIndexIniSAMTable = Index
                iSAM(Index) = Index
                CheckForAnySortNeeded("", 148) 'hack
                ShowSorts(MyTable, MyReSort(MyTable, MyArrayLong, iSAM, Index))
                CheckForAnySortNeeded("", 149) 'hack
            Else
                FindIndexIniSAMTable = Index - 1
            End If
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function


        Public Shared Function FindInNetLinks(IndexFlowChart As Int32) As Int32 ' Return the Net Link Index
            Dim I As Int32
            MyTrace(68, "FindinNetLinks()", 4040 - 4017)

            If FlowChart_TableCode(IndexFlowChart) <> "/path" Then Return constantMyErrorCode
            For I = LBound(NetLinks_File) To UBound(NetLinks_File)
                If InStr(NetLinks(I), FD & IndexFlowChart & FD) > 0 Then
                    Return I
                End If
            Next
            ' It is not in any net links so make it in a new on
            If FlowChart_TableCode(IndexFlowChart) <> "/path" Then Return constantMyErrorCode 'hack
            ReDim Preserve NetLinks_File(UBound(NetLinks_File) + 1)
            ReDim Preserve NetNames_File(UBound(NetNames_File) + 1)
            I = UBound(NetLinks_File)
            netlinks(I, NetLinks(I) & FD & IndexFlowChart & FD) ' nothing and this indexFlowChart starts a new one
            FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, I.ToString) ' Save shat net number we assigned to it
            If NetNames(I) = Nothing Or NetNames(I) = "" Then
                netnames(I, FlowChart_TableNamed(IndexFlowChart))
            Else
                netnames(I, NetNames(I) & "__&__" & FlowChart_TableNamed(IndexFlowChart))
            End If
            FileInputOutputScreen.TextBoxNetLinks.Text = NetNames(I) & NetLinks(I)
            Return I
        End Function




        ' counts the number of ???? in an existing symbol
        Public Shared Sub NumberGraphicsInASymbol(SymbolNumber As Int32,
                                                  ByRef NumberOfPoints As Int32,
                                                  ByRef NumberOfLines As Int32,
                                                  ByRef NumberOfErrors As Int32,
                                                  ByRef NumberOfOthers As Int32)
            Dim Idex As Int32

            NumberOfPoints = 0
            NumberOfLines = 0
            NumberOfErrors = 0
            NumberOfOthers = 0

            Idex = SymbolNumber + 1
            If Idex < 1 Then Exit Sub 'hack This should also never get here with a -`, or zero
            For Idex = SymbolNumber + 1 To TopOfFile("Symbol", Symbol_FileCoded)

                Select Case PrintAbleNull(Symbol_TableCoded_String(Idex).ToString)
                    Case "/name" ' Start of the next symbol
                        Exit Sub
                    Case "/point"
                        NumberOfPoints += 1
                        While NumberOfPoints + 4 >= SymbolScreen.ComboBoxPointNameList.Items.Count
                            SymbolScreen.ComboBoxPointNameList.Items.Add("VariableName" & CStr(SymbolScreen.ComboBoxPointNameList.Items.Count))
                        End While
                        SymbolScreen.ComboBoxPointNameList.Items.Item(NumberOfPoints) = CStr(Symbol_Table_NameOfPoint(Idex).ToString)
                    Case "/lines"
                        NumberOfLines += 1
                        If NumberOfLines >= SymbolScreen.ComboBoxLineNameList.Items.Count Then
                            SymbolScreen.ComboBoxLineNameList.Items.Add("Line Color" & CStr(SymbolScreen.ComboBoxLineNameList.Items.Count))
                        End If
                        SymbolScreen.ComboBoxPointNameList.Items.Item(NumberOfOthers) = Symbol_TableCoded_String(Idex).ToString()
                    Case "/error"
                        NumberOfErrors += 1 ' just counting the number of error records found in the table
                    Case Else
                        NumberOfOthers += 1 ' just count other things (not accountied for)
                End Select
            Next
        End Sub

        ' rewrote 20200711
        'Gets the index in symbol from just the name (looks it up in named first)
        Public Shared Function FindInSymbolList(ByRef WhatToFind As String) As Int32 'Gets the index in symbol from just the name (looks it up in named first)
            Dim Temp As String
            Dim IndexNamed, IndexSymbol As Int32            'MyArray() As String,  is always symbol file anem
            MyTrace(69, "FindInSymbolList", 658 - 617)

            ' Cheat first now

            If MyUniverse.MyCheatSheet.Last_UnSortedStringTable = "symbol" Then
                If MyUniverse.MyCheatSheet.Last_UnSortedStringString = WhatToFind Then
                    FindInSymbolList = MyUniverse.MyCheatSheet.Last_UnSortedStringIndex
                    Exit Function
                End If
            End If

            FindingMyBugs(10) 'hace Least amount of checking here

            IndexNamed = FindIndexIniSAMTable("Named", "donotadd", Named_FileSymbolName, Named_File_iSAM, WhatToFind)
            If IndexNamed <= 0 Then
                IndexNamed = CheckNotInList("named", "Do Not Add", Named_FileSymbolName, Named_File_iSAM, WhatToFind)
            End If
            If IndexNamed <= 0 Then
                IndexNamed = IndexNamed 'hack
                ' Invalid symbol name to find so exit the cheat way, and try harder
                FindingMyBugs(10) 'hace Least amount of checking here 'hack
            Else
                IndexSymbol = Named_TableIndexes(IndexNamed)
                If IndexSymbol <= 0 Then ' We have no cheater/faster Indexes to the name of this symbol. (We might need to complete re-find all of the Indexess???)
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack
                    IndexSymbol = GetSelfCorrectingIndexes(WhatToFind) ' At least fix this Indexes
                    ' in the name table, but not in the symbol table
                    If IndexSymbol < 0 Then ' Then there is no symbols
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        FindInSymbolList = constantMyErrorCode
                        Exit Function ' not a valid symbol name in the symbol table
                    ElseIf IndexSymbol > 0 Then
                        Named_TableIndexes(IndexNamed, IndexSymbol) 'update the missing Indexes
                        FindInSymbolList = IndexSymbol 'return the new index number that is found and updated
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        Exit Function
                    Else
                        Abug(651, "The indexsymbol = " & IndexSymbol, 0, 0)
                    End If
                Else
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack
                    Temp = Symbol_TableSymbolName(IndexSymbol)
                    If MyCompared1_a(WhatToFind, Temp) = 0 Then    'GREAT we found a match
                        FindingMyBugs(10) 'hace Least amount of checking here 'hack
                        FindInSymbolList = IndexSymbol
                        Exit Function
                    Else ' The Indexes is off again
                        IndexSymbol = GetSelfCorrectingIndexes(WhatToFind) ' The Indexess are off so fix them if possible

                        ' So Do We need to search it again"
                        IndexSymbol = Named_TableIndexes(IndexNamed) ' See if it is corrected
                        Abug(998, "Fixing named and symbol for " & WhatToFind,
                             IndexNamed & " : " & Named_TableSymbolName(IndexNamed),
                             IndexSymbol & " : " & Symbol_TableSymbolName(IndexSymbol))
                    End If
                End If
                ' END OF THE SHORT CUT CHEAT 
            End If
            ' Failed above so we have to do this the hard way.
            ' And assume that it is an unsorted list now
            FindingMyBugs(10) 'hace Least amount of checking here 'hack
            For IndexSymbol = 1 To TopOfFile("Symbol", Symbol_FileCoded)
                Temp = Symbol_TableSymbolName(IndexSymbol)
                ' Finds the first one, not the /name one
                If MyCompared1_a(WhatToFind, Temp) = 0 Then    'GREAT we found a match
                    If Symbol_TableCoded_String(IndexSymbol) = "/name" Then
                        FindingMyBugs(10) 'hace Least amount of checking here
                        Abug(748, "We had to find a symbol name match the hard way! Program data error", IndexSymbol, WhatToFind & " : " & Temp)
                        FindInSymbolList = IndexSymbol ' If we find it this way then there is a problem some where
                        GetSelfCorrectingIndexes(WhatToFind)
                        MyUniverse.MyCheatSheet.Last_UnSortedStringTable = "symbol"
                        MyUniverse.MyCheatSheet.Last_UnSortedStringString = WhatToFind
                        'FindInSymbolList = MyUniverse.MyCheatSheet.Last_UnSortedStringIndex
                        CheckForErrors(0, IndexNamed, IndexSymbol)
                        Exit Function
                    Else ' we found a match of the symbol name, but not the /name record ' report it, and continue on
                        Abug(743, "The Symbols must be out of order, because the first one found was not a /name code at " & IndexSymbol, WhatToFind, Temp)
                        FindingMyBugs(10) 'hace Least amount of checking here ' Because the /name should be the first on in the list
                    End If
                End If
            Next IndexSymbol
            'failed to find it the hard way so it's not there
            FindInSymbolList = constantMyErrorCode
        End Function



        Public Shared Function AddInTable(ByRef MyTable As String, ByRef MyFunction As String, ByRef MyArray() As String, ByRef iSAM() As Int32, WhatToFind As String, IndexPassed As Int32) As Int32
            Dim index As Int32
            MyTrace(71, "AddInTable", 99 - 62)

            MyMakeArraySizesBigger()

            AddInTable = IndexPassed
            CheckForAnySortNeeded("", 150) 'hack
            ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, 1))
            CheckForAnySortNeeded("", 151) 'hack
            ShowSorts(MyTable, MyReSort(MyTable, MyArray, iSAM, IndexPassed))
            CheckForAnySortNeeded("", 152) 'hack
            'Not in the list so add it, or not
            If LCase(Trim(MyFunction)) = "add" Then
                FindingMyBugs(10) 'hace Least amount of checking here
                'Last attempt to find because I've got a bug
                For index = 1 To TopOfFile(MyTable, MyArray, iSAM)
                    CheckThis("AddInTable", 10, MyArray, iSAM, index)
                    If MyCompared1_a(MyArray(index), WhatToFind) = 0 Then
                        MyMsgCtr("AddInTable", 1270, MyArray(index), WhatToFind, "", "", "", "", "", "", "")
                        AddInTable = index
                        Exit Function
                    End If
                    FindingMyBugs(10) 'hace Least amount of checking here
                Next index

                MyMakeArraySizesBigger() '????? Do I need This
                index = TopOfFile(MyTable, MyArray, iSAM)
                AddInTable = index
                If PrintAbleNull(WhatToFind) = "_" Then MyMsgCtr("AddInTable", 1413, WhatToFind, "8", "", "", "", "", "", "", "")
                MyArray(index) = WhatToFind
                iSAM(index) = index
                MyUniverse.MyCheatSheet.LastString = WhatToFind
                MyUniverse.MyCheatSheet.LastIndex = AddInTable
                CheckThis("AddInTable", 11, MyArray, iSAM, index)
                CheckForAnySortNeeded("", 153) 'hack
                QuickCheckSort("AddInTable 90", MyArray, iSAM, index) 'hack                
                CheckForAnySortNeeded("", 154) 'hack
            Else
                AddInTable = IndexPassed
            End If
            CheckForAnySortNeeded("AddInTable", 999)
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function



        Public Shared Function FindMessageNumber(Level As Integer) As Integer
            Dim Idex, Jdex, Kdex As int32
            Dim X As String
            Dim Zdex As int32
            Dim ErrorKounter As int32
            MyTrace(72, "FindMessageNumber", 39 - 3)

            FindMessageNumber = My_KeyConstError
            ErrorKounter = -16

            Kdex = OptionScreen.ComboBoxDebug.Items.Count - 1
            If Kdex < 4 Then Exit Function
            Idex = MyMinMax(CInt(Kdex / 2), 0, Kdex)
            Jdex = MyMinMax(CInt(Idex / 2), 1, Kdex)
            While 1 = 1
                Application.DoEvents()
                ErrorKounter += 1
                If ErrorKounter > OptionScreen.ComboBoxDebug.Items.Count Then
                    Abug(958, ErrorKounter, 0, 0) ' just not found, but need to excape
                    'Tried to many times must be a problem (most likely not found in a sorted list
                    FindMessageNumber = 0 ' default to the first message, what ever it might be.
                    Exit Function
                End If
                X = OptionScreen.ComboBoxDebug.Items.Item(Idex).ToString
                Zdex = Popvalue(X)
                If Zdex > Level Then
                    Idex = MyMinMax(Idex - Jdex, 0, Kdex)
                    Jdex = MyMinMax(CInt(Jdex / 2), 1, Idex)
                ElseIf Zdex < Level Then
                    Idex = MyMinMax(Idex + Jdex, 0, Kdex)
                    Jdex = MyMinMax(CInt(Jdex / 2), 1, Idex)
                ElseIf Zdex = Level Then
                    FindMessageNumber = Idex
                    Exit Function
                Else
                    FindMessageNumber = 0 ' default to the first message, what ever it might be.
                End If
                ' Need to put in a test for end of file
            End While
            FindMessageNumber = 0 ' default to the first message, what ever it might be.
        End Function


        'Routine Just gets the size of the circle or path width 
        Public Shared Function FindMySize(Where As PictureBox, DataTypeName As String) As int32
            Dim IndexDataType As int32
            MyTrace(73, "FindMySize", 63 - 45)

            CheckForAnySortNeeded("", 155)
            IndexDataType = FindIndexIniSAMTable("DataType", "DoNotAdd", DataType_FileName, DataType_iSAM_, Trim(DataTypeName))
            CheckForAnySortNeeded("", 156)
            If IndexDataType = constantMyErrorCode Then
                Abug(957, DataTypeName, 0, 0)
                MyMsgCtr("FindMySize", 1291, DataTypeName, "", "", "", "", "", "", "", "")
                FindMySize = MyUniverse.SysGen.ConstantMinPenSize
                Exit Function
            End If
            FindMySize = MyMinMax(DataType_TableWidth(IndexDataType), MyUniverse.SysGen.ConstantMinPenSize, MyUniverse.SysGen.ConstantMaxPenSize)
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function


        'Routine This is called to draw the inside symbol lines 
        Public Shared Sub MyDrawLineXY_XY(Where As PictureBox, Xy As MyLineStructure, ColorName As String)
            MyTrace(74, "MyDrawLineXY_XY", 4)

            MyDrawLineS_PathS(Where, Xy, ColorName, 10)
        End Sub


        'This is called to draw the inside symbol lines with a width of 1
        Public Shared Sub MyDrawLineWithIndex(Where As PictureBox, IndexSymbol As int32, XYOffSet As MyPointStructure, RotationName As String)
            '' Cheat and us the path to draw the line
            MyTrace(75, "MyDrawLineWithIndex", 83 - 75)

            MyDrawLineS_PathS(Where,
                   MyLine1(MyRotated_1(IndexSymbol, XYOffSet, RotationName),
                   MyRotated_2(IndexSymbol, XYOffSet, RotationName)),
                   Symbol_Table_NameOfPoint(IndexSymbol), 1)
        End Sub
        'MyDrawLineWithIndex(Where, IndexSymbol, XYOffSet, RotationName)
        'Routine This is used to draw the paths between the symbol points (with a min width of 3
        Public Shared Sub MyDrawPath(Where As PictureBox, XY As MyLineStructure, DataTypeName As String)
            Dim ColorName As String
            Dim IndexDataTypeOrColor As int32
            Dim Width As int32
            MyTrace(76, "MyDrawPath", 825 - 786)

            MyMakeArraySizesBigger()

            ColorName = "Black" ' default color if any errors
            'CheckForAnySortNeeded("", 157)
            IndexDataTypeOrColor = FindIndexIniSAMTable("DataType", "DoNotAdd", DataType_FileName, DataType_iSAM_, PrintAbleNull(DataTypeName))
            If IndexDataTypeOrColor = constantMyErrorCode Then ' Not a dataType, but a color name passed
                IndexDataTypeOrColor = FindColor(DataTypeName)
                If IndexDataTypeOrColor = constantMyErrorCode Then
                    Abug(954, "Error : ALSO Invalid Datatype or Color ", DataTypeName, "")
                    IndexDataTypeOrColor = FindColor("black")
                    If IndexDataTypeOrColor = constantMyErrorCode Then
                        Abug(953, "ERROR: Invalid Color/Code for black : " & DataTypeName, IndexDataTypeOrColor, "Made into " & Color_TableName(1))
                        IndexDataTypeOrColor = 1
                        ColorName = MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME
                    Else
                        ColorName = Color_TableName(IndexDataTypeOrColor) ' For color black
                        Width = 1 'default width for all non datatypes
                    End If
                Else ' Was A Color Name
                    ColorName = Color_TableName(IndexDataTypeOrColor)
                    Width = 1 'default width for all non datatypes
                End If
            Else
                'Found a DataType
                ColorName = Color_TableName(Color_iSAM_(DataType_TableColorIndex(IndexDataTypeOrColor)))
                Width = MyMinMax(DataType_TableWidth(IndexDataTypeOrColor), MyUniverse.SysGen.ConstantMinPenSize, MyUniverse.SysGen.ConstantMaxPenSize)
            End If
            If ColorName = "" Or IsNothing(ColorName) Then
                DataType_TableColorIndex(IndexDataTypeOrColor, FindColor(MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME))
            End If
            MyDrawLineS_PathS(Where, XY, ColorName, Width)
        End Sub


        Public Shared Function InsertFlowChartRecord(RecordNumber As int32, SymbolName As String, CodedString As String, xy1 As MyPointStructure, xy2 As MyPointStructure, DataType_Color As String) As int32
            MyTrace(77, "InsertFlowChartRecord", 45 - 28)

            MyMakeArraySizesBigger()
            NewFlowChartRecord(RecordNumber)
            FlowChart_TableCode_X(RecordNumber, MyKeyword_2_Byte(CodedString).ToString)
            FlowChart_TableNamed(RecordNumber, SymbolName)
            FlowChart_Table_DataType(RecordNumber, DataType_Color)
            FlowChart_TableX1(RecordNumber, xy1.X)
            FlowChart_TableY1(RecordNumber, xy1.Y)
            FlowChart_TableX2_Rotation(RecordNumber, xy2.X)
            FlowChart_TableY2_Option(RecordNumber, xy2.Y)
            InsertFlowChartRecord = RecordNumber
            ShowSorts("FlowChart", SortFlowChart())
        End Function


        'need to make sure that this error message is not already in the list.
        Public Shared Sub MakeErrorAt(Where As PictureBox, myXY As MyPointStructure, ErrorMessage As String)
            Dim Idex As Int32
            Dim IndexSymbol As Int32
            MyTrace(78, "MakeErrorAt", 53 - 47)

            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    'Idex = MyFindPoint(Where, myXY) 'Find the closest point
                    ' Need to find the closest if this error is already in the FlowChart file, other wise it will go on forever building errors
                    For Idex = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                        If FlowChart_TableCode(Idex) = "/error" Then ' only check errors
                            If myXY.X = FlowChart_TableX1(Idex) Then
                                If myXY.Y = FlowChart_TableY1(Idex) Then
                                    ' Do not put errors ontop of the same errors
                                    If ErrorMessage = FlowChart_TableNamed(Idex) Then
                                        Exit Sub ' not at the same message?
                                    End If
                                End If
                            End If
                        End If
                    Next
                    InsertFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded), ErrorMessage, "/error", myXY, ZeroZero, "red") ' color??
                Case "SymbolScreen"
                    If SymbolScreen.ToolStripDropDownSelectSymbol.Text <> "" Then ' Only do it if there is a selected symbol
                        Idex = FindInSymbolList(SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                        IndexSymbol = Idex + 1
                        While IndexSymbol < TopOfFile("symbol", Symbol_FileCoded) And Symbol_TableCoded_String(IndexSymbol) <> "/name"
                            If Symbol_TableCoded_String(IndexSymbol) = "/error" Then
                                If myXY.X = Symbol_FileX1(IndexSymbol) Then
                                    If myXY.Y = Symbol_FileY1(IndexSymbol) Then
                                        Exit Sub ' It is already in the symbol
                                    End If
                                End If
                            End If
                            IndexSymbol += 1
                        End While

                        'Will insert multiply of this right now
                        MyInsertSymbolRecordX1Y1IODT(Idex, SymbolScreen.ToolStripDropDownSelectSymbol.Text, "/error", myXY.X, myXY.Y, "0", "0", ErrorMessage)
                        Abug(9301, Idex & " : " & SymbolScreen.ToolStripDropDownSelectSymbol.Text, "Error (" & CStr(myXY.X) & "," & CStr(myXY.Y) & ")", ErrorMessage)
                    End If
            End Select

        End Sub


        'Routine This draws all text on the screen
        Public Shared Sub MyDrawText(Where As PictureBox, xy As MyPointStructure, MyString As String, BrushOptionNumber As Int32)
            Dim XY1 As Point
            Dim MyFonts As Font
            Dim MyBrushes As Brush
            MyTrace(79, "MyDrawText", 75 - 57)

            If MyString = Nothing Then Exit Sub
            If MyString = "" Then Exit Sub
            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(BrushOptionNumber) = False Then Exit Sub


            MyBrushes = MyUniverse.OptionDisplay(BrushOptionNumber).Color
            XY1 = Copy2Screen(Where, xy)
            MyFonts = SystemFonts.DefaultFont

            If MyUniverse.MyMouseAndDrawing.PaintThisOrEraseThis = False Then
                MyBrushes = Brushes.White
            Else
                MyBrushes = SystemBrushes.WindowText
            End If
            Where.CreateGraphics.DrawString(MyString, MyFonts, MyBrushes, XY1)
        End Sub

        'Routine This is the actuall routine that write out text , called by everything else
        Public Shared Sub MyDrawLineS_PathS(Where As PictureBox, XY As MyLineStructure, ColorName As String, Width As int32)
            Dim XY_a, XY_b As Point
            Dim MinePen As Pen
            Dim indexColor As int32
            MyTrace(81, "MyDrawLineS_PathS", 913 - 878)

            If (ColorName = "") Or IsNothing(ColorName) Then
                MinePen = Pens.Black
                ColorName = MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME
            Else
                MyGetPen_Static(ColorName)
                MinePen = GetMyPen
            End If

            'flow10'      MinePen.Width = MyMinMax(Width, 1, 24)

            XY_a = Copy2Screen(Where, XY.a)
            XY_b = Copy2Screen(Where, XY.b)
            Where.CreateGraphics.DrawLine(MinePen, XY_a, XY_b)
            If Width <= 1 Then Width = 2 'flow10' This is to force drawing 'ERROR 
            If Width > 1 Then ' Then This is a path
                CheckForAnySortNeeded("", 163)
                indexColor = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, ColorName)
                CheckForAnySortNeeded("", 164)
                If indexColor > 0 Then
                    MyDrawCircle(Where, XY.a, Color_TableName(indexColor), "")
                    MyDrawCircle(Where, XY.b, Color_TableName(indexColor), "")
                End If
            End If
            'flow10 '''''''''''''''''''''            MinePen.Dispose()
        End Sub


        'Routine This draws a big cross where the symbol is at.
        Public Shared Sub MyDrawCross(Where As PictureBox, xy As MyPointStructure, MyDataType As String, MyString As String)
            Dim xy1 As Point
            Dim xy2 As Point
            Dim tempsize As int32
            MyTrace(82, "MyDrawCross", 44 - 20)

            tempsize = 10

            xy1 = Copy2Screen(Where, xy)
            xy2.X = xy1.X + tempsize
            xy2.Y = xy1.Y + tempsize
            xy1.X = xy1.X - tempsize
            xy1.Y = xy1.Y - tempsize
            Where.CreateGraphics.DrawLine(Pens.Black, xy1, xy2)


            xy1 = Copy2Screen(Where, xy)
            xy2.X = xy1.X - tempsize
            xy2.Y = xy1.Y + tempsize
            xy1.X = xy1.X + tempsize
            xy1.Y = xy1.Y - tempsize
            Where.CreateGraphics.DrawLine(Pens.Black, xy1, xy2)

        End Sub

        Public Shared Function MyDistancePath(XY1 As MyLineStructure, XY2 As MyLineStructure) As Int32 'Find The Distance From XY1  to XY2
            Dim T1, T2, T3, T4 As Int32
            MyTrace(83, "MyDistancePath", 53 - 49)

            T1 = MyABS(XY1.a.X - XY2.a.X) + MyABS(XY1.a.Y - XY2.a.Y) '1A to 2A
            T2 = MyABS(XY1.b.X - XY2.a.X) + MyABS(XY1.b.Y - XY2.a.Y) '1B to 2A
            T3 = MyABS(XY1.a.X - XY2.b.X) + MyABS(XY1.a.Y - XY2.b.Y) '1A to 2B
            T4 = MyABS(XY1.b.X - XY2.b.X) + MyABS(XY1.b.Y - XY2.b.Y) '1b to 2B
            MyDistancePath = MyMiNLong(T1, T2) ' Between t1 & t2
            MyDistancePath = MyMiNLong(MyDistancePath, T3) ' Between t1 & t2
            MyDistancePath = MyMiNLong(MyDistancePath, T4) ' Between t1 & t2
            MyMsgCtr("MyDistancePath", 1285, MyDistancePath.ToString, "(" & XY1.a.X & FD & XY1.a.Y & ")", "(" & XY1.b.X & FD & XY1.b.Y & ")", "(" & XY2.a.X & FD & XY2.a.Y & ")", "(" & XY2.b.X & FD & XY2.b.Y & ")", T1.ToString, T2.ToString, T3.ToString, T4.ToString)
        End Function



        'routine to see the distance between two points (OK, so I didn't square amounts and take the root
        Public Shared Function MyDistance(A As MyPointStructure, B As MyPointStructure) As int32
            MyTrace(84, "MyDistance", 53 - 49)
            MyDistance = MyABS(A.X - B.X) + MyABS(A.Y - B.Y)
            MyMsgCtr("MyDistance", 1286, "Testing Distance=" & MyDistance.ToString, "(" & A.X.ToString & ",", A.Y.ToString & "),", "(" & B.X.ToString & ",", B.Y.ToString & ")", "", "", "", "")
        End Function


        'Routine This routine returns a 16 unit clock of the direction of the second point from the first point
        Public Shared Function MyDirection(where As PictureBox, XY1 As MyPointStructure, XY2 As MyPointStructure) As Byte
            'Dim TDist as int32
            Dim dX, dY As int32
            MyTrace(85, "MyDirection", 4057 - 3957)

            ' This should return the following 'clock' of the direction of the second from the centered first points
            'TDist = myuniverse.sysgen.ConstantSymbolCenter * 2
            '14 15 16 01 02
            '13 /  |   / 03
            '12 ---0-----04
            '11 /  |   / 05
            '10 09 08 07 06
            '
            'Just to make it simple
            dX = XY2.X - XY1.X
            dY = XY2.Y - XY1.Y

            If dX = 0 And dY = 0 Then ' ontop of each other
                MyDirection = 0
                Exit Function
            End If

            If dX = 0 Then
                If dY < 0 Then
                    MyDirection = 16 : Exit Function
                Else
                    MyDirection = 8 : Exit Function
                End If
            End If

            If dY = 0 Then
                If dX > 0 Then
                    MyDirection = 4 : Exit Function
                Else
                    MyDirection = 12 : Exit Function
                End If
            End If


            If dX > 0 Then '1-7
                If dY > 0 Then '1, 2, 3
                    If MyABS(dX) = MyABS(dY) Then
                        MyDirection = 6 : Exit Function
                    End If
                    If MyABS(dX) > MyABS(dY) Then
                        MyDirection = 5 : Exit Function
                    Else
                        MyDirection = 7 : Exit Function
                    End If
                Else '5, 6, 7
                    If MyABS(dX) = MyABS(dY) Then
                        MyDirection = 2 : Exit Function
                    End If
                    If MyABS(dX) > MyABS(dY) Then
                        MyDirection = 3 : Exit Function
                    Else
                        MyDirection = 1 : Exit Function
                    End If
                End If
            Else ' dx <08-15
                If dY > 0 Then '13, 14, 15
                    If MyABS(dX) = MyABS(dY) Then
                        MyDirection = 10 : Exit Function
                    End If
                    If MyABS(dX) > MyABS(dY) Then
                        MyDirection = 11 : Exit Function
                    Else
                        MyDirection = 9 : Exit Function
                    End If
                Else        '9, 10, 11
                    If MyABS(dX) = MyABS(dY) Then
                        MyDirection = 14 : Exit Function
                    End If
                    If MyABS(dX) > MyABS(dY) Then
                        MyDirection = 13 : Exit Function
                    Else
                        MyDirection = 15 : Exit Function
                    End If
                End If
            End If
            MyDirection = 0
            ' For now only returning up
        End Function




        'Routine This draws the input/output arrows at each point
        Public Shared Sub MyDrawPointArrow(Where As PictureBox,
                                           CenterXY As MyPointStructure,
                                           ArrowXY As MyPointStructure,
                                           DataTypeName As String,
                                           DirectionString As String,
                                           InputOrOutPut As int32)
            'Dim MineXY1 As MyLineStructure
            Dim TempPenWidthSize, ArrowFactor, DirectionIs As int32
            Dim IndexDataType As int32 '  Used Only For Trying to improve the speed by not sorting
            Dim MinePen As Pen
            Dim MyXY1 As MyPointStructure       ' center point to show direction
            Dim MyXY2 As MyPointStructure       ' shows direction of path into the symbol
            Dim XY1 As Point            ' Used only to dieplay points (as lines)
            Dim XY2 As Point            ' Other end of the line
            Dim index As Int32           ' Index of this data type
            Dim clrName, Temp As String
            Dim Input_Output_Both_Direction As int32
            Dim IO_SizeModifier(16) As Integer
            MyTrace(86, "MyDrawPointArrow", 178 - 63)


            'todo This is bombing out string to integer
            Temp = MyUnEnum(InputOrOutPut, SymbolScreen.ToolStripDropDownInputOutput, 1)
            Input_Output_Both_Direction = Popvalue(Temp)
            'This changes the size based on the direction of the arrow.

            IO_SizeModifier(0) = 1
            IO_SizeModifier(1) = 3            'input
            IO_SizeModifier(2) = -3            'output
            IO_SizeModifier(3) = 4            'both
            IO_SizeModifier(4) = 4            'Optionalinput
            IO_SizeModifier(5) = -2            'optional output
            IO_SizeModifier(6) = 2           'optional both
            IO_SizeModifier(7) = 1            'anything else
            IO_SizeModifier(8) = 1            'anything else
            IO_SizeModifier(9) = 10 'Future
            IO_SizeModifier(10) = 10 'Future
            IO_SizeModifier(11) = 10 'Future
            IO_SizeModifier(12) = 10 'Future
            IO_SizeModifier(13) = 10 'Future
            IO_SizeModifier(14) = 10 'Future
            IO_SizeModifier(15) = 10 'Future
            IO_SizeModifier(16) = 10 'Future

            ArrowFactor = 1
            If IsNothing(DataTypeName) Then
                Abug(951, "MyDrawPointArrow", "No datatypename passed", 0)
                DataTypeName = "DataTypeError"
            End If
            If PrintAbleNull(DataTypeName) = "_" Then MyMsgCtr("MyDrawPointArrow", 1413, DataTypeName, "10", "", "", "", "", "", "", "")
            IndexDataType = FindIndexIniSAMTable("DataType", "DoNotAdd", DataType_FileName, DataType_iSAM_, DataTypeName) 'Add this datatype 
            If IndexDataType = constantMyErrorCode Then
                Abug(949, IndexDataType, 0, 0)
                Exit Sub
            Else
                clrName = Color_TableName(DataType_TableColorIndex(IndexDataType))
            End If
            MyMakeArraySizesBigger()                                           ' Make sure we are not over flowing the MyArrays'
            clrName = FindColorFromDataType(DataType_TableName(IndexDataType))
            '            clrName = DataType_TableColor(IndexDataType)

            If IsNothing(clrName) Then 'We get here when a new datatype name was added
                If IsNothing(DataType_TableColorIndex(index)) Then
                    DataType_TableColorIndex(index, FindColor("Red"))
                End If
                clrName = "Red"
            End If
            TempPenWidthSize = 1 'MyMinMax(FindMySize(Where, Trim(DataTypeName)), 1, 550) ' Already set between 10 and 250 


            ' Get this pen color
            MyGetPen_Static(Trim(clrName))
            MinePen = GetMyPen
            'MinePen.Width = MyMinMax(ScaledSize(TempPenWidthSize), 1, 250) '???????
            If ScaledSize(TempPenWidthSize) < 1 Then
                'flow10 ''''''''''''MinePen.Width = 1
            ElseIf ScaledSize(TempPenWidthSize) > 250 Then
                MinePen.Width = 250
            Else
                'flow10 'MinePen.Width = 10 'TempPenWidthSize
            End If
            '            MyXYCenter.X = myuniverse.sysgen.ConstantSymbolCenter
            '           MyXYCenter.Y = myuniverse.sysgen.ConstantSymbolCenter

            DirectionIs = MyDirection(Where, ZeroZero, ArrowXY)


            If Where.Parent.Name = "SymbolScreen" Then
                MyXY1 = CenterXY                  'Save the center of where we should show
                MyXY1.Y = MyXY1.Y - MyUniverse.OptionDisplay(10).X ' Display Input/output text
                MyDrawText(Where, MyXY1,
                           SymbolScreen.ToolStripDropDownInputOutput.DropDownItems(
                            MyMinMax(Input_Output_Both_Direction, 1,
                                     SymbolScreen.ToolStripDropDownInputOutput.DropDownItems.Count)).ToString, 10)
            End If
            ' For Direction, for the second part of the line
            MyXY1 = CenterXY : MyXY2 = CenterXY 'Save the center of where we should show
            MyXY2.X = MyXY2.X + CInt(MyDirections(DirectionIs, 1, 1) * TempPenWidthSize * IO_SizeModifier(MyMinMax(Input_Output_Both_Direction, 0, 8)) / ArrowFactor)
            MyXY2.Y = MyXY2.Y + CInt(MyDirections(DirectionIs, 1, 2) * TempPenWidthSize * IO_SizeModifier(MyMinMax(Input_Output_Both_Direction, 0, 8)) / ArrowFactor)
            XY1 = Copy2Screen(Where, MyXY1) : XY2 = Copy2Screen(Where, MyXY2)
            Where.CreateGraphics.DrawLine(MinePen, XY1, XY2)
            MyXY1 = CenterXY : MyXY2 = CenterXY 'Save the center of where we should show
            MyXY2.X = MyXY2.X + CInt(MyDirections(DirectionIs, 2, 1) * TempPenWidthSize * IO_SizeModifier(MyMinMax(Input_Output_Both_Direction, 0, 8)) / ArrowFactor)
            MyXY2.Y = MyXY2.Y + CInt(MyDirections(DirectionIs, 2, 2) * TempPenWidthSize * IO_SizeModifier(MyMinMax(Input_Output_Both_Direction, 0, 8)) / ArrowFactor)
            XY1 = Copy2Screen(Where, MyXY1) : XY2 = Copy2Screen(Where, MyXY2)
            ' This is only for output or both
            Where.CreateGraphics.DrawLine(MinePen, XY1, XY2) ' Second part of the Indexes (v, or ^ or < or > )
            'flow10;'''''''MinePen.Dispose()
        End Sub


        'Routine The draws a circle where each point is
        Public Shared Sub MyDrawCircle(Where As PictureBox, XY As MyPointStructure, ColorName As String, DataTypeName As String)
            Dim MyRec As Rectangle
            Dim TempSize As int32
            Dim ScreenPoint As Point
            Dim IndexColor As int32
            Dim IndexDataType As int32
            Dim MinePen As Pen
            Dim ColorNameIs As String
            MyTrace(87, "MyDrawCircle", 240 - 182)

            If IsNothing(ColorName) Or ColorName = "" Then ColorName = "Red"

            CheckForAnySortNeeded("", 170)
            IndexColor = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, ColorName)
            CheckForAnySortNeeded("", 171)


            If IndexDataType = constantMyErrorCode Then ' Not a color so try a datatype
                Abug(948, DataTypeName, IndexDataType, 0)
                MyMsgCtr("MyDrawCircle", 1413, DataTypeName, "11", "", "", "", "", "", "", "")
                CheckForAnySortNeeded("", 172)
                IndexDataType = FindIndexIniSAMTable("DataType", "add", DataType_FileName, DataType_iSAM_, DataTypeName)
                CheckForAnySortNeeded("", 173)
                CheckForAnySortNeeded("", 174) 'hack
                ShowSorts("DataType", MyReSort("DataType", DataType_FileName, DataType_iSAM_, IndexDataType))
                CheckForAnySortNeeded("", 175) 'hack

                TempSize = FindMySize(Where, DataTypeName)
                ColorNameIs = MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME
            Else
                TempSize = 2
                ColorNameIs = ColorName
            End If
            MyGetPen_Static(ColorNameIs)
            MinePen = GetMyPen

            ScreenPoint = Copy2Screen(Where, XY)

            MyRec.X = ScreenPoint.X - CInt(TempSize / 2)
            MyRec.Y = ScreenPoint.Y - CInt(TempSize / 2)
            MyRec.Width = TempSize
            MyRec.Height = TempSize
            Where.CreateGraphics.DrawEllipse(MinePen, MyRec)
            'flow10'''''''''''MinePen.Dispose()
            Application.DoEvents()
        End Sub


        'Routine this draws a circle where each error is 
        'bug 'todo clrname is being passed the name of the point
        Public Shared Sub MyDrawCircle_At(Where As PictureBox, xy As MyPointStructure, TextString As String, clrName As String)
            Dim IndexColor As int32
            Dim MyColorName As String
            MyTrace(88, "MyDrawCircle_At", 74 - 44)

            '  Just to make sure we have a valid color (Do I need this?)
            CheckForAnySortNeeded("", 176)
            IndexColor = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, clrName)
            CheckForAnySortNeeded("", 177)
            If IndexColor = constantMyErrorCode Then
                MyColorName = MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME
                IndexColor = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, MyColorName)
            Else
                MyColorName = clrName
            End If

            MyDrawCircle(SymbolScreen.PictureBox1, xy, MyColorName, "") ' Color, not datatype

            'Display Point Names
            MyDrawText(SymbolScreen.PictureBox1, MyOffset(xy, CStr(MyUniverse.OptionDisplay(1).X), CStr(MyUniverse.OptionDisplay(1).Y)), TextString, 1)
        End Sub



        Public Shared Sub Clear_Screen_Only(Where As PictureBox)
            MyTrace(91, "Clear_Screen_Only", 2)

            Where.Image = Nothing ' Clear the screen only (And Not RePaint
        End Sub


        'Routine This will clear the screen and then redraw everything

        Public Shared Sub Clear_Screen(Where As PictureBox)
            Dim Temp As int32
            MyTrace(92, "Clear_Screen", 363 - 303)

            If IsNothing(Where.Parent) Then Exit Sub

            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    If Where.Parent.Visible = False Then Exit Sub
                    Clear_Screen_Only(Where)
                    SetScreenArea()
                    MyUniverse.SysGen.ReSize = 987
                    If FlowChartScreen.PictureBox1.Width = FlowChartScreen.Width - FlowChartScreen.VScrollBar1.Width - 10 Then
                        MyUniverse.SysGen.ReSize = 0
                    Else
                        MyUniverse.SysGen.ReSize = 987 ' Flag to not let resize call it's self
                        FlowChartScreen.PictureBox1.Width = FlowChartScreen.Width - FlowChartScreen.VScrollBar1.Width - 10
                    End If
                    PaintAll(FlowChartScreen.PictureBox1, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
                Case "SymbolScreen"
                    If Where.Visible = False Then Exit Sub
                    Clear_Screen_Only(Where)
                    'Application.DoEvents()
                    Temp = MyUniverse.SysGen.ConstantSymbolCenter + MyUniverse.SysGen.ConstantSymbolCenter
                    If SymbolScreen.ToolStripDropDownSelectSymbol.Text <> "" Then
                        PaintEach(SymbolScreen.PictureBox1,
                                 MyPoint1(Temp, Temp),
                                 SymbolScreen.ToolStripDropDownSelectSymbol.Text, "default")
                    End If
            End Select
        End Sub




        'Routine this keeps track of where the working area is located, 
        Public Shared Sub SetScreenArea()
            MyTrace(93, "SetScreenArea", 79 - 69)

            MyUniverse.MyMouseAndDrawing.MyScreen.a.X = MyUniverse.MyStaticData.MinXY.X - ScaledSize(100)
            MyUniverse.MyMouseAndDrawing.MyScreen.a.Y = MyUniverse.MyStaticData.MinXY.Y - ScaledSize(100)
            MyUniverse.MyMouseAndDrawing.MyScreen.b.X = MyUniverse.MyStaticData.MaxXY.X + ScaledSize(100)
            MyUniverse.MyMouseAndDrawing.MyScreen.b.Y = MyUniverse.MyStaticData.MaxXY.Y + ScaledSize(100)

        End Sub

        Public Shared Function FindSymbolName(IndexSymbol As int32) As String ' Finds tha name of the symbol from the index in the graphic symbols
            Dim Idex As int32
            MyTrace(94, "FindSymbolName", 9)

            Idex = IndexSymbol
            While Idex > 0 And Symbol_TableCoded_String(Idex) <> "/name"
                Idex -= 1
            End While
            Return Symbol_TableSymbolName(Idex)
        End Function



        Public Shared Function FindSymbol_StartIndex(SymbolName As String) As Int32
            Dim IndexNamed As Int32
            MyTrace(95, "FindSymbolStartIndex", 410 - 381)

            MyMsgCtr("FindSymbolStartIndex", 1293, SymbolName, "", "", "", "", "", "", "", "")
            CheckForAnySortNeeded("", 180) 'hack
            FindSymbol_StartIndex = FindInSymbolList(SymbolName)
            CheckForAnySortNeeded("", 181) 'hack
            If FindSymbol_StartIndex = constantMyErrorCode Then
                Abug(947, "Not able to find symbol name ", SymbolName, 0)
                Exit Function ' not named symbol
            End If
            If LCase(Symbol_TableSymbolName(FindSymbol_StartIndex)) = LCase(SymbolName) Then
                Exit Function ' Indexes is to the right place
            End If

            'wrong Indexes here, so fix if possible, otherwise change Indexes back to a 0 to search every time(yuck)
            For IndexNamed = 1 To TopOfFile("named", Named_FileSymbolName, Named_File_iSAM)
                FindSymbol_StartIndex = Named_TableIndexes(IndexNamed)
                If Symbol_TableCoded_String(FindSymbol_StartIndex) = "/name" Then
                    If LCase(Symbol_TableSymbolName(FindSymbol_StartIndex)) = LCase(SymbolName) Then
                        Named_TableIndexes(IndexNamed) ' short cut
                        Exit Function
                    Else
                        Named_TableIndexes(FindSymbol_StartIndex, 0) ' Lost the Indexes
                    End If
                Else
                    Named_TableIndexes(FindSymbol_StartIndex, 0) ' Lost the Indexes
                End If
            Next
            Named_TableIndexes(FindSymbol_StartIndex, 0) ' Fix wrong point, and not able to find it anyway.
            Abug(946, SymbolName, 0, 0)
            FindSymbol_StartIndex = constantMyErrorCode ' not findable
        End Function

        'Routine 
        Public Shared Sub DisplayOBject(Where As PictureBox, XYOffsets As MyPointStructure, symbolName As String, RotationName As String)
            MyTrace(96, "DisplayObject", 18 - 13)
            PaintEach(Where, XYOffsets, symbolName, RotationName)
        End Sub

        Public Shared Function MyFindSymbolPoint(where As PictureBox,
                                                 MyXY As MyPointStructure,
                                                 SymbolName As String) As Int32
            Dim IndexSymbol As Int32
            Dim IndexStart As Int32
            Dim Dist1, Dist3 As Int32
            MyTrace(97, "MyFindSymolPoint", 67 - 20)

            MyMsgCtr("FindSymbolPoint", 1294, SymbolName, MyXY.X.ToString, MyXY.Y.ToString, "", "", "", "", "", "")

            Dist1 = 9999999 ' biggest number possible
            Dist3 = Dist1

            IndexStart = FindSymbol_StartIndex(SymbolName)

            MyFindSymbolPoint = constantMyErrorCode
            If IndexStart = constantMyErrorCode Then
                Abug(944, "Can not find the symbol name ", SymbolName, 0)
                Return constantMyErrorCode
            End If
            IndexStart = IndexStart + 1
            For IndexSymbol = IndexStart To TopOfFile("Symbol", Symbol_FileCoded)
                Select Case Symbol_TableCoded_String(IndexSymbol)
                    Case "/name"  ' Next name so skip it
                        Exit For
                    Case "/point"
                        Dist1 = MyDistance(MyXY, MyRotated_1(IndexSymbol, ZeroZero, "Default"))
                        If Dist1 < Dist3 Then
                            MyFindSymbolPoint = IndexSymbol
                            Dist3 = Dist1
                        End If
                    Case "/line"
                        'Dist1 = MyABS(MyXY.X - Symbol_TableX1(Index)) + MyABS(MyXY.Y - Symbol_TableY1(Index))
                        Dist1 = MyDistance(MyXY, MyRotated_1(IndexSymbol, ZeroZero, "Default"))
                        If Dist1 < Dist3 Then
                            MyFindSymbolPoint = IndexSymbol
                            Dist3 = Dist1
                        End If
                        Dist1 = MyDistance(MyXY, MyRotated_2(IndexSymbol, ZeroZero, "Default"))
                        If Dist1 < Dist3 Then
                            MyFindSymbolPoint = IndexSymbol
                            Dist3 = Dist1
                        End If
                    Case Else

                End Select

            Next

        End Function

        'finds the closest symbol center, each end of the paths, 
        Public Shared Function MyFindPoint(Where As PictureBox, MyXY As MyPointStructure) As int32 ' Find the Symbol/Path/point/Line closest to X & Y
            Dim IndexFlowChart, IndexNamed As int32, StartAt As int32
            Dim Idex As int32
            Dim Dist1, Dist3 As int32
            MyTrace(98, "MyFindPoint", 582 - 4470)

            MyMsgCtr("MyFindPoint", 1295, MyXY.X.ToString, MyXY.Y.ToString, "", "", "", "", "", "", "")

            MyFindPoint = constantMyErrorCode
            Dist1 = 9999999 ' biggest number possible
            Dist3 = Dist1
            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    MyFindPoint = constantMyErrorCode
                    For IndexFlowChart = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                        Select Case LCase(Trim(FlowChart_TableCode(IndexFlowChart)))
                            Case "/use"
                                Dist1 = MyDistance(MyXY, MyPoint1(IndexFlowChart))
                                If Dist1 < Dist3 Then
                                    MyFindPoint = IndexFlowChart
                                    Dist3 = Dist1
                                End If
                            Case "/path"
                                Dist1 = MyDistance(MyXY, MyPoint1(IndexFlowChart))
                                If Dist1 < Dist3 Then
                                    MyFindPoint = IndexFlowChart
                                    Dist3 = Dist1
                                End If
                                Dist1 = MyABS(MyXY.X - FlowChart_TableX2_Rotation(IndexFlowChart)) + MyABS(MyXY.Y - FlowChart_TableY2_Option(IndexFlowChart))
                                Dist1 = MyDistance(MyXY, MyPoint2_2(IndexFlowChart))
                                If Dist1 < Dist3 Then
                                    MyFindPoint = IndexFlowChart
                                    Dist3 = Dist1
                                End If
                            Case "/constant"
                                'Dist1 = MyABS(MyXY.X - FlowChart_TableX1(IndexNamed)) + MyABS(MyXY.Y - FlowChart_TableY1(IndexNamed))
                                Dist1 = MyDistance(MyXY, MyPoint1(IndexFlowChart))
                                If Dist1 < Dist3 Then
                                    MyFindPoint = IndexFlowChart
                                    Dist3 = Dist1
                                End If
                            Case Else
                        End Select
                    Next
                Case "SymbolScreen" ' Find the active point for the selected symbol table
                    CheckForAnySortNeeded("", 182)
                    StartAt = FindIndexIniSAMTable("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                    CheckForAnySortNeeded("", 183)
                    If StartAt <> constantMyErrorCode Then


                        ' This is wrong because the selected item is a string, and the p() requires a number
                        ' I f I stop here then find and fix the problem
                        StartAt = Named_TableIndexes(My_Int(SymbolScreen.ToolStripDropDownSelectSymbol.Text)) ', IndexNamed) ' Shortcut





                    Else
                        Abug(943, StartAt, MyXY.X, MyXY.Y)
                        StartAt = 1
                    End If

                    If LCase(Symbol_TableSymbolName(StartAt)) <> "/name" Then
                        Named_TableIndexes(StartAt, 1)
                        StartAt = 1
                    End If


                    For IndexNamed = StartAt To TopOfFile("Symbol", Symbol_FileCoded)
                        If Symbol_TableCoded_String(IndexNamed) = "/name" Then
                            '
                            If LCase(Trim(Symbol_TableSymbolName(IndexNamed))) = LCase(Trim(SymbolScreen.ToolStripDropDownSelectSymbol.Text)) Then
                                Idex = IndexNamed
                                While Idex < TopOfFile("Symbol", Symbol_FileCoded) - 1
                                    FindingMyBugs(10) 'hace Least amount of checking here
                                    MyMsgCtr("MyFindPoint", 1038, Symbol_TableCoded_String(Idex), Idex.ToString, MyXY.X.ToString, MyXY.Y.ToString, "", "", "", "", "")
                                    Idex = Idex + 1
                                    Select Case Symbol_TableCoded_String(Idex)
                                        Case "/name", "/constant"  ' Added constant incase we are at the end
                                            Exit Function
                                        Case "/point"
                                            Dist1 = MyABS(MyXY.X - Symbol_TableX1(Idex)) + MyABS(MyXY.Y - Symbol_TableY1(Idex))
                                            Dist1 = MyDistance(MyXY, MyPoint1(Idex))
                                            If Dist1 < Dist3 Then
                                                MyFindPoint = Idex
                                                Dist3 = Dist1
                                            End If
                                        Case "/line"
                                            Dist1 = MyABS(MyXY.X - Symbol_TableX1(Idex)) + MyABS(MyXY.Y - Symbol_TableY1(Idex))
                                            Dist1 = MyDistance(MyXY, MyPoint1(Idex))
                                            If Dist1 < Dist3 Then
                                                MyFindPoint = Idex
                                                Dist3 = Dist1
                                            End If
                                            'Dist1 = MyABS(MyXY.X - Symbol_TableX2_io(index)) + MyABS(MyXY.Y - Symbol_TableY2_dt(index))
                                            Dist1 = MyDistance(MyXY, MyPoint2_2(Idex))
                                            If Dist1 < Dist3 Then
                                                MyFindPoint = Idex
                                                Dist3 = Dist1
                                            End If
                                        Case Else
                                    End Select
                                End While
                            End If
                        End If
                    Next

                Case "OptionScreen" 'Never happen
                    FindingMyBugs(10)'hace Least amount of checking here
                Case "FileIOScreen"
                    FindingMyBugs(10)'hace Least amount of checking here
                Case "StatusScreen"
                    FindingMyBugs(10) 'hace Least amount of checking here
                Case Else
                    FindingMyBugs(10) 'hace Least amount of checking here
            End Select
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function


        'Routine 
        Public Shared Function Find_Point(where As PictureBox, atXY As MyPointStructure) As int32
            Dim index As int32
            Dim j As int32
            Dim K As int32
            Dim Dist As int32
            Dim Dist2 As int32
            MyTrace(99, "Find_Point", 646 - 592)

            index = CInt(TopOfFile("FlowChart", FlowChart_FileCoded) / 2)               ' Start in the middle
            K = CInt(index / 2)
            While K > 0
                Application.DoEvents()
                MyMsgCtr("Find_Point", 1039, FlowChart_TableCode(index), atXY.X.ToString, atXY.Y.ToString, index.ToString, K.ToString, "", "", "", "")
                If My_Int(FlowChart_TableCode(index)) > atXY.X Then
                    MyMsgCtr("Find_Point", 1106, index.ToString, FlowChart_TableX1(index).ToString, FlowChart_TableY1(index).ToString, atXY.X.ToString, atXY.Y.ToString, "", "", "", "")
                    index = index - K
                Else
                    MyMsgCtr("Find_Point", 1107, index.ToString, FlowChart_TableX1(index).ToString, FlowChart_TableY1(index).ToString, atXY.X.ToString, atXY.Y.ToString, "", "", "", "")
                    index = index + K
                End If
                K = CInt(K / 2)
            End While

            MyMsgCtr("Find_Point", 1105, index.ToString, FlowChart_TableX1(index).ToString, FlowChart_TableY1(index).ToString, atXY.X.ToString, atXY.Y.ToString, "", "", "", "")
            FindingMyBugs(10) 'hace Least amount of checking here
            j = index
            'Dist = MyABS(FlowChart_TableX1(Index) - atXY.X) + MyABS(FlowChart_TableY1(Index) - atXY.Y)
            Dist = MyDistance(atXY, MyPoint1(index))

            Dist2 = Dist + 1
            K = CInt(TopOfFile("FlowChart", FlowChart_FileCoded) / 2)
            For K = -1 To 1 Step 2
                MyMsgCtr("Find_Point", 1108, CStr(K), "", "", "", "", "", "", "", "")
                While Dist > MyDistance(atXY, MyPoint1(index)) And index > 0 And index < TopOfFile("FlowChart", FlowChart_FileCoded)
                    Application.DoEvents()
                    If FlowChart_TableCode(index) = "/name" Then
                        Dist2 = MyDistance(atXY, MyPoint1(index))
                        If Dist > Dist2 Then
                            MyMsgCtr("Find_Point", 1109, Dist.ToString, Dist2.ToString, index.ToString, j.ToString, atXY.X.ToString, atXY.Y.ToString, MyPoint1(index).X.ToString, MyPoint1(index).Y.ToString, "")
                            Dist = Dist2
                            j = index
                            'WhichEnd = 0
                        End If
                        'Dist2 = MyABS(FlowChart_TableX2_Rotation(Index) - atXY.X) + MyABS(FlowChart_TableY2_Option(Index) - atXY.Y)
                        Dist2 = MyDistance(atXY, MyPoint2_2(index))
                        If Dist > Dist2 Then
                            MyMsgCtr("Find_Point", 1110, Dist.ToString, Dist2.ToString, j.ToString, index.ToString, "", "", "", "", "")
                            Dist = Dist2
                            j = index
                            'WhichEnd = 1
                        End If
                    End If
                    index = MyMinMax(index + K, 0, TopOfFile("FlowChart", FlowChart_FileCoded))
                End While
                index = MyMinMax(j - K, 0, TopOfFile("FlowChart", FlowChart_FileCoded))
            Next K
            MyMsgCtr("Find_Point", 1111, atXY.X.ToString, atXY.Y.ToString, FlowChart_TableX1(j).ToString, FlowChart_TableY1(j).ToString, FlowChart_TableX2_Rotation(j).ToString, FlowChart_TableY2_Option(j).ToString, j.ToString, "", "")
            Find_Point = j
        End Function

        'Routine this finds where to start everything at
        Public Shared Function Find_Start(Where As PictureBox) As Int32
            Dim Index As Int32
            MyTrace(101, "Find_Start", 71 - 49)

            MyMsgCtr("Find_Start", 1090, "", "", "", "", "", "", "", "", "")
            ' This sets up to run the interactive
            For Index = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If LCase(Trim(FlowChart_TableCode(Index))) = "/use" Then
                    MyMsgCtr("Find_Start", 1112, FlowChart_TableCode(Index), FlowChart_TableNamed(Index), Index.ToString, "", "", "", "", "", "")
                    If UCase(FlowChart_TableNamed(Index)) = "START" Or UCase(FlowChart_TableNamed(Index)) = "MAIN" Then
                        MyUniverse.MyStaticData.SelectedObject = Index
                        Find_Start = Index
                        ReSetScrollBars(Where, Index)
                        Clear_Screen(Where)
                        Exit Function
                    End If
                End If
            Next
            MyMsgCtr("Find_Point", 1214, "", "", "", "", "", "", "", "", "")
            Find_Start = constantMyErrorCode
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function


        'Routine while getpoint is 1 (true) then getting the next point
        Public Shared Function GetPoint(IndexFlowChart As int32, atXY As MyPointStructure, CountOfPoints As int32) As MyPointStructure 'Get the closest Point to X & Y 
            Dim IndexSymbol As int32
            MyTrace(102, "GetPoint", 713 - 675)

            CheckForAnySortNeeded("", 184) 'hack
            IndexSymbol = FindInSymbolList(FlowChart_TableNamed(IndexFlowChart))
            CheckForAnySortNeeded("", 185) 'hack
            If IndexSymbol = constantMyErrorCode Then
                Abug(942, CountOfPoints, 0, TopOfFile("Symbol", Symbol_FileCoded))
                GetPoint = ZeroZero ' failed to get this point number (because the symbol doesn't exist)
                Exit Function
            End If

            IndexSymbol = IndexSymbol + 1 ' Jump over the name of this symbol

            'Count down till we have the point number
            FindingMyBugs(10) 'hace Least amount of checking here
            While CountOfPoints > 1 And IndexSymbol < TopOfFile("Symbol", Symbol_FileCoded) - 1
                MyMsgCtr("GetPoint", 1028, Symbol_TableCoded_String(IndexSymbol), IndexSymbol.ToString, "", "", "", "", "", "", "")
                Select Case Symbol_TableCoded_String(IndexSymbol)
                    Case "/name"         'Next symbol
                        GetPoint = ZeroZero    ' No more points in the symbol table
                        Exit Function
                    Case "/point"
                        If CountOfPoints < 0 Then ' we are trying to get more points than exist somehow
                            GetPoint = ZeroZero    ' No more points in the symbol table
                            Exit Function
                        End If
                        If CountOfPoints = 0 Then
                            atXY = MyRotated_1(IndexSymbol, IndexFlowChart, MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 1)) ' constantEnumRotation))
                            GetPoint = atXY     ' We have the count of points into the sumbol
                            Exit Function
                        End If
                        CountOfPoints -= 1 'CountOfPoints = CountOfPoints -1 ' get the next one
                    Case Else
                        GetPoint = ZeroZero    ' No more points in the symbol table
                End Select
            End While
            FindingMyBugs(10) 'hace Least amount of checking here
            GetPoint = ZeroZero    'Should never get here 
        End Function


        'Routine 
        Public Shared Function GetSymbolPoint(Where As PictureBox, SymbolName As String, xy As MyPointStructure, PointCount As int32) As Boolean
            Dim IndexSymbol As int32
            Dim Index As int32
            Dim NumberOfThisPoint As int32
            MyTrace(103, "GetSymbolPoint", 52 - 17)

            GetSymbolPoint = False

            CheckForAnySortNeeded("", 186) 'hack

            IndexSymbol = FindInSymbolList(SymbolName)
            CheckForAnySortNeeded("", 187) 'hack
            If IndexSymbol = constantMyErrorCode Then
                Abug(941, SymbolName, 0, 0)
                Exit Function
            End If

            IndexSymbol = IndexSymbol + 1 ' Get it off of the name
            NumberOfThisPoint = 0
            FindingMyBugs(10) 'hace Least amount of checking here
            For Index = IndexSymbol To PointCount
                Select Case Symbol_TableCoded_String(Index)
                    Case "/name"
                        Exit Function 'no more points
                    Case "/point"
                        NumberOfThisPoint = NumberOfThisPoint + 1 ' Count of the number of points
                        If NumberOfThisPoint = PointCount Then
                            xy = MyRotated_1(Index, ZeroZero, "Default")
                            GetSymbolPoint = True ' Means that is has found a point
                            Exit Function
                        End If
                    Case Else
                        'ignore everything else
                End Select
            Next
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function


        'Routine 
        Public Shared Function GetSymbol(Where As PictureBox, XY As MyPointStructure, DIRECTION As int32) As int32  'Check if a Symbol Point is at This X, Y
            Dim Dist As int32
            Dim Dist2 As int32
            Dim IndexInFlowChart As int32
            Dim xxyy As MyPointStructure
            Dim Test As MyPointStructure
            Dim CounterofKounter As int32
            MyTrace(104, "GetSymbol", 788 - 4756)

            CounterofKounter = constantMyErrorCode
            Dist = MyUniverse.SysGen.MySnap * MyUniverse.SysGen.MySnap
            ' index = Find_Point(100, -1, x, Y)
            FindingMyBugs(10) 'hace Least amount of checking here
            For IndexInFlowChart = 0 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If LCase(Trim(FlowChart_TableCode(IndexInFlowChart))) = "/use" Then
                    '                    Where = 0
                    Test = MyPoint1(IndexInFlowChart)
                    While Test.X <> 0 And Test.Y <> 0
                        Test = GetPoint(IndexInFlowChart, xxyy, DIRECTION)
                        Dist2 = MyDistance(XY, xxyy)
                        If Dist > Dist2 And Test.X <> 0 And Test.Y <> 0 Then
                            MyMsgCtr("GetSymbol", 1029, Test.X.ToString, Test.Y.ToString, XY.X.ToString, XY.Y.ToString, xxyy.X.ToString, xxyy.Y.ToString, CounterofKounter.ToString, Dist.ToString, Dist2.ToString)
                            CounterofKounter = IndexInFlowChart
                            Dist = Dist2
                        End If
                        'Where = Where + 1
                    End While
                End If
            Next
            FindingMyBugs(10) 'hace Least amount of checking here
            MyMsgCtr("GetSymbol", 1113, CounterofKounter.ToString, Dist.ToString, XY.X.ToString, XY.Y.ToString, FlowChart_TableX1(CounterofKounter).ToString, FlowChart_TableY1(CounterofKounter).ToString, FlowChart_FileNamed(CounterofKounter), "", "")
            GetSymbol = CounterofKounter
            FindingMyBugs(10) 'hace Least amount of checking here
        End Function



        'Routine Testing for two points inside the screen
        Public Shared Function InSideMyScreen(Where As PictureBox, RealWorld1 As MyPointStructure, RealWorld2 As MyPointStructure) As Boolean
            Dim WhereAt1 As Point
            Dim WhereAt2 As Point
            MyTrace(105, "InSideMyScreen", 824 - 793)

            WhereAt1 = Copy2Screen(Where, RealWorld1)
            WhereAt2 = Copy2Screen(Where, RealWorld2)

            ' All Left of my screen
            If WhereAt1.X < MyUniverse.MyMouseAndDrawing.MyScreen.a.X And WhereAt2.X < MyUniverse.MyMouseAndDrawing.MyScreen.a.X Then
                InSideMyScreen = False
                Exit Function
            End If
            ' All Right of my screen
            If WhereAt1.X > MyUniverse.MyMouseAndDrawing.MyScreen.b.X And WhereAt2.X > MyUniverse.MyMouseAndDrawing.MyScreen.b.X Then
                InSideMyScreen = False
                Exit Function
            End If
            ' All abobe my screen
            If WhereAt1.Y < MyUniverse.MyMouseAndDrawing.MyScreen.a.Y And WhereAt2.Y < MyUniverse.MyMouseAndDrawing.MyScreen.a.Y Then
                InSideMyScreen = False
                Exit Function
            End If
            If WhereAt1.Y > MyUniverse.MyMouseAndDrawing.MyScreen.b.Y And WhereAt2.Y > MyUniverse.MyMouseAndDrawing.MyScreen.b.Y Then
                InSideMyScreen = False
                Exit Function
            End If
            ' Else It miight be true, 

            InSideMyScreen = True
        End Function


        'Routine Texting for single point inside the screen
        Public Shared Function InSideMyScreen(Where As PictureBox, RealWorld As MyPointStructure) As Boolean
            Dim WhereAt1 As Point
            MyTrace(106, "InSideMyScreen", 73 - 30)

            If MyUniverse.MyMouseAndDrawing.MyScreen.a.X = 0 Then
                If MyUniverse.MyMouseAndDrawing.MyScreen.a.Y = 0 Then
                    If MyUniverse.MyMouseAndDrawing.MyScreen.b.X = 0 Then
                        If MyUniverse.MyMouseAndDrawing.MyScreen.b.Y = 0 Then
                            InSideMyScreen = True ' cause we dont know yet how big the screen is , so everthing i sconsidered inside
                            Exit Function
                        End If
                    End If
                End If
            End If
            InSideMyScreen = True
            Exit Function
            WhereAt1 = Copy2Screen(Where, RealWorld)

            ' All Left of my screen
            If WhereAt1.X < MyUniverse.MyMouseAndDrawing.MyScreen.a.X Then
                MyMsgCtr("InSideMyscreen", 1260, MyUniverse.MyMouseAndDrawing.MyScreen.a.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.a.Y.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.Y.ToString, "", "", "", "", "")
                InSideMyScreen = False
                Exit Function
            End If
            ' All Right of my screen
            If WhereAt1.X > MyUniverse.MyMouseAndDrawing.MyScreen.b.X Then
                MyMsgCtr("InSideMyscreen", 1260, MyUniverse.MyMouseAndDrawing.MyScreen.a.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.a.Y.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.Y.ToString, "", "", "", "", "")
                InSideMyScreen = False
                Exit Function
            End If
            ' All abobe my screen
            If WhereAt1.Y < MyUniverse.MyMouseAndDrawing.MyScreen.a.Y Then
                MyMsgCtr("InSideMyscreen", 1260, MyUniverse.MyMouseAndDrawing.MyScreen.a.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.a.Y.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.Y.ToString, "", "", "", "", "")
                InSideMyScreen = False
                Exit Function
            End If
            If WhereAt1.Y > MyUniverse.MyMouseAndDrawing.MyScreen.b.Y Then
                MyMsgCtr("InSideMyscreen", 1260, MyUniverse.MyMouseAndDrawing.MyScreen.a.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.a.Y.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.X.ToString, MyUniverse.MyMouseAndDrawing.MyScreen.b.Y.ToString, "", "", "", "", "")
                InSideMyScreen = False
                Exit Function
            End If
            ' Else It miight be true, 

            InSideMyScreen = True
            Exit Function
        End Function

        '************************************************************************************************************
        ' Between the first value and the third value, this compares where the second (middle) value belongs at.
        'Test #	Results	Testing A, b, C
        '1   5	        b=nothing
        '2   0  	    A And C = nothing
        '3   -1	        A=b
        '4   1  	    b=C
        '5   -4 	    A=nothing And b< C
        '6   4	        C=nothing And b > A
        '7   -4 	    A=Nothing
        '8   4	        C = nothing
        '9   -5 	    A > C 'Unsorted List
        '10  0	        A<b<C 'not in the list but should go between these
        '11  -3	        A>b
        '12  -2 	    b > C
        '13  3	        b < C
        '14  2  	    A < b
        '15  5	        default fails everything above (Should never happen)




        Public Shared Function MyCompared3(StringA As String, StringB As String, StringC As String) As SByte
            Dim A, B, C As String
            MyTrace(107, "MyCompared3", 943 - 890)
            'Test #	Results	Testing A, b, C
            '1   5	    b=nothing (So you are at the end of the list (Assume that B > a or A = nothing)
            '2   0  	A And C = nothing (No Items in the list , empty list)
            '3   -1	    A=b
            '4   1  	b=C
            '5   -4 	A=nothing And b< C
            '6   4	    C=nothing And b > A
            '7   -4 	A=Nothing
            '8   4	    C = nothing
            '9   -5 	A > C 'Unsorted List
            '10  0	    A<b<C 'not in the list but should go between these
            '11  -3	    A>b
            '12  -2 	b > C
            '13  3	    b < C
            '14  2  	A < b
            '15  5	    default fails everything above (Should never happen)

            A = LCase(MyTrim(StringA))
            B = LCase(MyTrim(StringB))
            C = LCase(MyTrim(StringC))

            '2020-12-12 Added test to make sure that A is not null (or nothing)
            If Not (IsNothing(StringA) Or A = "") And (IsNothing(StringB) Or B = "") Then Return 5 'End of the list (and not the beggining of the list
            'First One in the List is between them 
            If IsNullOrNothing(A) And IsNullOrNothing(C) Then Return 0 'First item in the list
            '-1 A = B
            If A = B Then Return -1
            ' 1 B = C
            If B = C Then Return 1
            '-4 A = start Of list (So Lowest)
            If IsNullOrNothing(A) And B < C Then Return -4 ' Start of the list (See below also)
            ' 4 C is the end of the list (So Highest)
            If IsNullOrNothing(C) And B > A Then Return 4 ' end of the list (See below also)

            '2020 07 31 'special case if there is a sortedd list at the top or bottom
            If A = C And B < C Then Return -4 ' Start of the list (See below also)
            ' 4 C is the end of the list (So Highest)
            If A = C And B > A Then Return 4 ' end of the list (See below also)

            If IsNullOrNothing(A) Then Return -4 ' Start of the list?????
            ' 4 C is the end of the list (So Highest)
            If IsNullOrNothing(C) Then Return 4 ' end of the list (Also)?????
            '-5 A is not <= than C (A>C) Error
            If A > C Then Return -5
            ' 0 B is between A and C
            If (A < B) And (B < C) Then Return 0
            '-3 A is higher than B  
            If A > B Then Return -3
            '-2 B is higher than C
            If B > C Then Return -2
            ' 3 C is higher then B
            If B < C Then Return 3
            ' 2 A is lower than B 
            If A < B Then Return 2
            ' 5 Error
            Abug(940, A, B, C)
            Return 5 ' default error
        End Function

        '*******************************************************************
        'This is used for checking if the indexes are valid or not
        Public Shared Function MyCompared2(ByRef MyArray() As String, ByRef iSAM() As Int32, A As Int32, B As Int32) As Int32
            MyTrace(108, "MyCompared2", 77 - 62)

            If InvalidIndex(A, MyArray, iSAM) Then Return -5
            If InvalidIndex(B, MyArray, iSAM) Then Return -5
            If InvalidIndex(iSAM(A), MyArray, iSAM) Then Return -5
            If InvalidIndex(iSAM(B), MyArray, iSAM) Then Return -5
            MyCompared2 = MyCompared1_a(MyArray(iSAM(A)), MyArray(iSAM(B)))
        End Function


        Public Shared Function MyCompared2(ByRef Myarraylong() As Int32, ByRef iSAM() As Int32, A As Int32, B As Int32) As Integer
            MyTrace(109, "MyCompared2", 20)

            If InvalidIndex(A, Myarraylong, iSAM) Then
                MyCompared2 = -5
                Exit Function
            End If
            If InvalidIndex(B, Myarraylong, iSAM) Then
                MyCompared2 = -5
                Exit Function
            End If
            If InvalidIndex(iSAM(A), Myarraylong, iSAM) Then
                MyCompared2 = -5
                Exit Function
            End If
            If InvalidIndex(iSAM(B), Myarraylong, iSAM) Then
                MyCompared2 = -5
                Exit Function
            End If
            MyCompared2 = MyCompared1(Myarraylong(iSAM(A)), Myarraylong(iSAM(B)))
        End Function



        Public Shared Function MyCompared1(A As Int32, B As Int32) As SByte
            MyTrace(111, "MyCompared1", 967 - 947)

            '-2 A = start Of list (So Lowest)
            '-1 A is lower than B (Default if nothing else)
            ' 0 A and B match 
            ' 1 A is higher than B
            ' 2 B is the end of the list (So Highest)

            If A = B Then Return 0
            'If the first Is nothing then it is considered the largest
            If IsNothing(A) Then Return -2 'Nothing or null is always the highest
            ' If the second is nothing then 
            If IsNothing(B) Then Return 2 ' You are always searching for something less than nothing or a null

            'Now we can actually test the two string
            If A > B Then Return 1
            'The default is A < B and anything else is false
            If B > A Then Return -1
            ' Al conditions should have been meet
            Abug(648, "A and B is not comparable ", A, B)
            Return -5 'Error
        End Function

        '***************************************************************************************
        '-2=(start), -1=(A<B), 0=(A=B),1=(A>B),2=(B=End)
        ' Compare two strings to see the order they should be in
        '-2 A = start Of list (So Lowest)
        '-1 A is lower than B (Default if nothing else)
        ' 0 A and B match 
        ' 1 A is higher than B
        ' 2 B is the end of the list (So Highest)


        Public Shared Function MyCompared1_a(StringA As String, StringB As String) As SByte
            Dim A, B As String
            MyTrace(111, "MyCompared1", 967 - 947)

            '-2 A = start Of list (So Lowest)
            '-1 A is lower than B (Default if nothing else)
            ' 0 A and B match 
            ' 1 A is higher than B
            ' 2 B is the end of the list (So Highest)

            A = LCase(MyTrim(StringA))
            B = LCase(MyTrim(StringB))
            If A = B Then Return 0
            'If the first Is nothing then it is considered the largest
            If A = "_" Or A = "" Or IsNothing(A) Then Return -2 'Nothing or null is always the highest
            ' If the second is nothing then 
            If B = "_" Or B = "" Or IsNothing(B) Then Return 2 ' You are always searching for something less than nothing or a null

            'Now we can actually test the two string
            If A > B Then Return 1
            'The default is A < B and anything else is false
            If B > A Then Return -1
            ' Al conditions should have been meet
            Abug(648, "A and B is not comparable ", A, B)
            Return -5 'Error
        End Function

        Public Shared Function ComputerFileNamesAre() As String
            MyTrace(112, "ComputerFileNamesAre", 8)

            ComputerFileNamesAre = WhatComputerLanguage()
            ComputerFileNamesAre = ComputerFileNamesAre &
                " (*." & ComputerLanguageExtention() & ")" &
                "|*." & ComputerLanguageExtention() & "|"
            ComputerFileNamesAre = ComputerFileNamesAre & "all files (*.*)|*.*"
        End Function


        Public Shared Function My_VariableName(CodeLine As String, NumberOfTheVariable As Int32, LineNumber As Int32) As String 'This should return the name of the variabl
            'ERROR this is not getting the correct variable name
            Dim MyArray(256) As String
            Dim Idex, CountDown As Int32
            MyTrace(113, "My_VariableName", 92 - 50)

            My_VariableName = "_" & NoWhiteSpaceS(CodeLine) ' This Should Never Be used
            CountDown = NumberOfTheVariable
            MyParse(MyArray, CodeLine)
            For Idex = 1 To UBound(MyArray)
                Select Case ThisIsAWhat(MyArray(Idex))
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(MyArray(Idex)) & " Is ignored", Idex, 0)
                    Case "ComputerLanguageCameFromLastLine"
                        My_VariableName = MyArray(Idex) & "_" & "ComputerLanguageCameFromLastLine" ' took back out 2020 08 20
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "ComputerLanguageComment"
                        AWarning(999, ThisIsAWhat(MyArray(Idex)) & " Is ignored", Idex, 0)
                    Case "ComputerLanguageExtention"
                        AWarning(999, ThisIsAWhat(MyArray(Idex)) & " Is ignored", Idex, 0)
                    Case "ComputerLanguageGoToNextLine"
                        My_VariableName = MyArray(Idex) & "_" & "ComputerLanguageGoToNextLine" ' took back out 2020 08 20
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(MyArray(Idex)) & " Is ignored", Idex, 0)
                    Case "ComputerLanguageVariableNameCharacters"
                        AWarning(999, ThisIsAWhat(MyArray(Idex)) & " Is ignored", Idex, 0)
                    Case "number" 'missing 2020 09 28
                        My_VariableName = MyArray(Idex) & "_" & NumberOfTheVariable
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "alpha" 'missing  2020 09 28
                        My_VariableName = MyArray(Idex)  '& "_" & NumberOfTheVariable ' took back out 2020 08 20
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "Variable"
                        My_VariableName = MyArray(Idex) '& "_" & NumberOfTheVariable ' took back out 2020 08 20
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "Quote"
                        ' Need to change this to make a Quote a /constant and the name of the point Quote_LineNumber
                        My_VariableName = MyArray(Idex) '& "_" & NumberOfTheVariable ' took back out 2020 08 20
                        My_VariableName = "Quote_" & LineNumber
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "CameFromLastLine"
                        My_VariableName = LineNumber - 1 & MyUniverse.SysGen.ConstantCameFromLastLineSyntax & "_" & NumberOfTheVariable
                        My_VariableName = "CameFromLine" & LineNumber - 1 '& ConstantCameFromLastLineSyntax & "_" & NumberOfTheVariable
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case "GotoNextLine" ' These requires a point on the symbol 2020 08 26
                        My_VariableName = LineNumber & MyUniverse.SysGen.ConstantGoToNextLineSyntax & "_" & NumberOfTheVariable
                        My_VariableName = "GotoNextLine" & LineNumber '& myuniverse.sysgen.ConstantGoToNextLineSyntax & "_" & NumberOfTheVariable
                        CountDown = CountDown - 1
                        If CountDown <= 0 Then Exit Function
                    Case Nothing
                        Exit Function
                    Case Else
                        Abug(999, "Failed to do this option in My_Variable Name", MyArray(Idex), CodeLine)
                End Select
            Next Idex
        End Function


        Public Shared Function MakeNewName(StartOfName As String, LineNumber As int32) As String
            MyTrace(114, "MakeNewName", 11)

            MyMakeArraySizesBigger()
            If MyUniverse.SysGen.HighestSymbolNumber < 100 Then
                MyUniverse.SysGen.HighestSymbolNumber = Popvalue(Mid(TimeString, 7, 2) & Mid(TimeString, 4, 2) & Mid(TimeString, 1, 2))
            End If
            MyUniverse.SysGen.HighestSymbolNumber += 1
            MakeNewName = StartOfName & "_" & LineNumber & "_" & MyUniverse.SysGen.HighestSymbolNumber

        End Function


        ' This inserts all new records after the end of the /name, instead of at the end of the list after name (before the next /name)
        Public Shared Function AddNEWFlowChartRecord(SymbolName As String, Coded As String, X1 As int32, Y1 As int32, X2_io As String, Y2_dt As String, MyDataType As String, LineNumber As int32) As int32
            MyTrace(115, "AddNEWFlowChartRecord", 7)

            MyMakeArraySizesBigger()
            AddNEWFlowChartRecord = NewTopOfFile("FlowChart", FlowChart_FileCoded)
            AddNEWFlowChartRecord = AddFlowChartRecord(SymbolName, Coded, X1, Y1, My_Int(X2_io), My_Int(Y2_dt), MyDataType.ToString, "", LineNumber)
        End Function




        ' This inserts all new records after the end of the /name, instead of at the end of the list after name (before the next /name)
        Public Shared Sub AddNEWSymbolRecord(SymbolName As String, Coded As String, X1 As int32, Y1 As int32, X2_io As String, Y2_dt As String, MyName_Of_Point As String, LineNumber As int32)
            Dim IndexSymbol, IndexNamed As int32
            Dim PointName As String
            MyTrace(116, "AddNEWSymbolRecord", 88 - 21)

            FindingMyBugs(10) 'hace Least amount of checking here 'hack
            PointName = MyName_Of_Point
            PointName = Pop(PointName, ConstantDelimeters) ' make sure that it is only one word
            MakeItTheBiggestSymbolNumber(PointName)
            MyMakeArraySizesBigger()

            IndexNamed = FindIndexIniSAMTable("named", "donotadd", Named_FileSymbolName, Named_File_iSAM, SymbolName)
            If IndexNamed = constantMyErrorCode Then
                IndexNamed = CheckNotInList("named", "donotadd", Named_FileSymbolName, Named_File_iSAM, SymbolName)
                If IndexNamed = constantMyErrorCode Then
                    IndexNamed = AddNewNamedRecord(SymbolName, "Missing", "Opcode", "Added Named that was missing", CreateFileNameFromSyntax(Coded & MyName_Of_Point, LineNumber), WhatComputerLanguage(), "Auto", "Version", "", "")
                    ReSortStringArray("named", Named_FileSymbolName, Named_File_iSAM)
                    ReSortStringArray("named", Named_FileSyntax, Named_FileSyntax_Isam)
                End If
            End If
            ' The following is not return correctly
            IndexSymbol = FindInSymbolList(SymbolName) ' Search the named 
            FindingMyBugs(10) 'hace Least amount of checking here 'hack
            If IndexSymbol > 0 Then
                ' move a blank record to after the name record, then update it 
                ' It is moving the name record also
                IndexSymbol += 1 ' move to one after the name
                'Moving record is ddonte in insert 2020 08 01
                'For idex = NewTopOfFile("Symbol", Symbol_FileCoded) To IndexSymbol + 1 Step -1
                ' SwapSymbolList(idex, idex - 1) ' Move a nothing to after the name record
                ' Next
                'UpdateSymbolRecordAt(IndexSymbol, SymbolName, Coded, X1, Y1, X2_io, Y2_dt, PointName)
                FindingMyBugs(10) 'hace Least amount of checking here 'hack
                If LCase(Coded) <> "/name" Then '2020 08 01 we do not want to add two name records, 
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04



                    MyInsertSymbolRecordX1Y1IODT(IndexSymbol, SymbolName, Coded, X1, Y1, X2_io, Y2_dt, PointName)
                    MyMakeArraySizesBigger()
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                Else ' 2020 08 11 but we will NOT update the record after the name name record
                    '                    FindingMyBugs(10)'hace Least amount of checking here 'hack 2020 08 04
                    '                    UpdateSymbolRecordAt(IndexSymbol, SymbolName, Coded, X1, Y1, NumberOrIO(X2_io), NumberOrDT(Y2_dt), PointName)
                    '                    FindingMyBugs(10)'hace Least amount of checking here 'hack 2020 08 04
                End If
            Else
                ' New name and record so add name if not already there (which its not) and then this record
                IndexSymbol = NewTopOfFile("Symbol", Symbol_FileCoded)
                ' AddFlowChartRecord() the record to the end after a New name record cause there is no name record now.
                If LCase(Coded) = "/name" Then ' We have to add a missing /name record
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                    ' We have to have a sumbol name first
                    UpdateSymbolRecordAt(IndexSymbol, SymbolName, Coded, X1, Y1, X2_io, Y2_dt, PointName)
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 06
                    Exit Sub
                Else '2020 08 06
                    'We are not updating /name records ever here
                    'UpdateSymbolRecordAt(IndexSymbol, SymbolName, "/name", 0, 0, "both", "default", "default")
                    ' set the record after 
                    IndexSymbol += 1 ' To one after the end of the end of the file 2020 08 06
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                    MyInsertSymbolRecordX1Y1IODT(IndexSymbol, SymbolName, Coded, X1, Y1, X2_io, Y2_dt, PointName)
                    FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
                End If
            End If
            ReSortSymbolList()
            FindingMyBugs(10) 'hace Least amount of checking here 'hack 2020 08 04
            TopOfFile("Symbol", Symbol_FileCoded) ' This is to update the top of the file counter
        End Sub


        '*******************************************************
        'Make a new symbol, or get the data from an old symbol
        'based on the name in the symbol text box
        '
        'Updates the text boxes on the symbol screen and redraw.

        Public Shared Sub UpdateSymbolRecordFromSymbolScreen() 'undone needs to update the toolstrip symbol selection on both the symbol and flowchart
            Dim Temp As Int32 ' max size of a symbol
            Dim IndexNamed, IndexSymbol As Int32

            MyTrace(117, "UpdateSymbolRecordFromSymbolScreen", 784 - 693)

            SymbolScreen.ComboBoxPointNameList.Text = ""
            SymbolScreen.ComboBoxLineNameList.Text = ""
            Clear_Screen(SymbolScreen.PictureBox1)
            'Me.PictureBox1.Image = Nothing

            Application.DoEvents()
            Temp = MyUniverse.SysGen.ConstantSymbolCenter * 2


            '
            PaintEach(SymbolScreen.PictureBox1, MyPoint1(Temp, Temp), SymbolScreen.ToolStripDropDownSelectSymbol.Text, "default") ' redraw the symbol
            IndexNamed = FindiSAM_IN_Table("named", "AddressOf", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.ToolStripDropDownSelectSymbol.Text) ' Get where it is in the symbols

            If IndexNamed = -1 Then ' Not found in the Named table, so Assume there is not defined symbol
                'it as a new symbol
                IndexNamed = FindiSAM_IN_Table("named", "Add", Named_FileSymbolName, Named_File_iSAM, SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                If IndexNamed > 0 Then
                    SymbolScreen.TextBoxProgramText.Text = ""
                    Application.DoEvents()
                    SymbolScreen.TextBoxNamedFilename.Text = SymbolScreen.ToolStripDropDownSelectSymbol.Text
                    SymbolScreen.TextBoxNamedNotes.Text = ""
                    SymbolScreen.TextBoxNamedOpCode.Text = ""
                    SymbolScreen.TextBoxNamedStroke.Text = ""
                    Application.DoEvents()
                    SymbolScreen.TextBoxSymbolName.Text = ""
                    SymbolScreen.ComboBoxPointNameList.Text = "" : SymbolScreen.ComboBoxPointNameList.Items.Clear()
                    SymbolScreen.ComboBoxLineNameList.Text = "" : SymbolScreen.ComboBoxLineNameList.Items.Clear()
                    SymbolScreen.TextBoxSymbolVersionAuthor.Text = ""
                    Application.DoEvents()
                    Exit Sub
                End If
            Else ' If the symbol already exist then update the screen with the data in the 'file'
                Application.DoEvents()
                IndexNamed = Named_File_iSAM(IndexNamed)
                If IndexNamed <= 0 Then
                    Abug(758, 0, 0, 0)
                    Exit Sub
                End If
                SymbolScreen.TextBoxProgramText.Text = Named_TableProgramText(IndexNamed)
                SymbolScreen.TextBoxNamedFilename.Text = Named_TableNameofFile(IndexNamed)
                SymbolScreen.TextBoxNamedNotes.Text = Named_TableNotes(IndexNamed)
                SymbolScreen.TextBoxNamedOpCode.Text = Named_TableOpCode(IndexNamed)
                SymbolScreen.TextBoxNamedStroke.Text = Named_TableStroke(IndexNamed)
                SymbolScreen.TextBoxSymbolName.Text = Named_TableSymbolName(IndexNamed)
                SymbolScreen.TextBoxSymbolVersionAuthor.Text = Named_TableVersion(IndexNamed) & "," & Named_TableAuthor(IndexNamed)
                SymbolScreen.ComboBoxPointNameList.Text = ""
                Application.DoEvents()
                ' Updating the chint quick Indexes to the symbol
                IndexSymbol = Named_TableIndexes(IndexNamed)
                If IndexSymbol > 0 Then ' make sure we have a Indexes
                    CheckForErrors(0, IndexNamed, IndexSymbol)
                    If Named_TableSymbolName(IndexNamed) = Symbol_TableSymbolName(IndexSymbol) Then ' make sure its the same symbol still
                        If Symbol_TableCoded_String(IndexSymbol) = "/name" Then ' make sure its the start of the symbol
                            IndexSymbol += 1
                            While Symbol_TableCoded_String(IndexSymbol) <> "/name" And IndexSymbol < TopOfFile("symbol", Symbol_FileCoded)
                                If Symbol_TableCoded_String(IndexSymbol) = "/point" Then
                                    SymbolScreen.ComboBoxPointNameList.Text = SymbolScreen.ComboBoxPointNameList.Text & ", " & Symbol_Table_NameOfPoint(IndexSymbol)
                                    Application.DoEvents()
                                End If
                                IndexSymbol += 1
                            End While
                        Else
                            GetSelfCorrectingIndexes(SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                        End If
                    Else
                        GetSelfCorrectingIndexes(SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                    End If
                Else
                    GetSelfCorrectingIndexes(SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                End If
            End If
        End Sub



        Public Shared Sub UpdateSymbolRecordAt(Idex As int32, SymbolName As String, Coded As String, X1 As int32, Y1 As int32, X2_io As String, Y2_dt As String, NameOfPoint As String)
            MyTrace(118, "UpdateSymbolRecordAt", 980 - 970)

            TopOfFile("Symbol", Symbol_FileCoded) ' This is to reset the top of file counter only
            FindingMyBugs(10) 'hace Least amount of checking here
            If InvalidIndex(Idex, Symbol_FileSymbolName) Then
                Abug(939, "UpdatesymbolRecordAt has an index problem : ", Idex, " So can not update Name=" & SymbolName & " code= " & Coded)
                Exit Sub
            End If
            Symbol_FileCoded(Idex) = MyKeyword_2_Byte(Coded) ' I think that I forgot this one.
            Symbol_FileSymbolName(Idex) = SymbolName
            Symbol_TableX1(Idex, X1)
            Symbol_TableY1(Idex, Y1)
            Symbol_TableX2_io(Idex, X2_io) ' these have to check for x2 or a io-name
            Symbol_TableY2_dt(Idex, Y2_dt) ' these have to check for y2 or a datatype-name
            Symbol_File_NameOfPoint(Idex) = NameOfPoint
            FindingMyBugs(10) 'hack Least amount of checking here ' 2020 07 22
            ReSortSymbolList()
        End Sub


        Public Shared Function AddNewNamedRecord(SymbolName As String,
                                                 text As String,
                                                 opcode As String,
                                                 notes As String,
                                                 filename As String,
                                                 language As String,
                                                 author As String,
                                                 version As String,
                                                 stroke As String,
                                                 Syntax As String) As int32
            '2020/6/22 change to return the record numberinstead of passing it.
            ' Bugs:
            ' Does not check if this name is already there. 
            MyTrace(119, "AddNewNamedRecord", 108 - 95)

            MyMakeArraySizesBigger()
            AddNewNamedRecord = FindIndexIniSAMTable("named", "Donotadd", Named_FileSymbolName, Named_File_iSAM, SymbolName)
            If AddNewNamedRecord > 0 Then
                AWarning(993, "this symbol is already in the named list", AddNewNamedRecord, SymbolName)
                Exit Function
            End If
            AddNewNamedRecord = NewTopOfFile("named", Named_FileSymbolName, Named_File_iSAM)
            Named_File_iSAM(AddNewNamedRecord) = AddNewNamedRecord
            Named_FileSyntax_Isam(AddNewNamedRecord) = AddNewNamedRecord
            Named_FileSymbolName(AddNewNamedRecord) = SymbolName

            Named_TableSymbolName(AddNewNamedRecord, SymbolName) 'Name of the symbol
            Named_TableIndexes(AddNewNamedRecord, GetSelfCorrectingIndexes(SymbolName)) ' A Indexes to this symbol in the Symbol Graphics Table
            Named_TableProgramText(AddNewNamedRecord, text) 'The actural program code to be 'fixed'
            Named_TableOpCode(AddNewNamedRecord, opcode) 'The Machine code of this assemble symbol
            Named_TableNotes(AddNewNamedRecord, notes) 'Notes for this symbol

            Named_FileNameOfFile(AddNewNamedRecord) = filename '*******'*' This is to avoid index checking not having anything
            Named_TableNameOfFile(AddNewNamedRecord, filename)  'The device:/path/Filename where this came from 

            '            Named_TableLanguage(AddNewNamedRecord, language) 'The computer language this applies to
            Named_TableAuthor(AddNewNamedRecord, author) 'Who wrote or responsable for this symbol
            Named_TableVersion(AddNewNamedRecord, version) ' the date of the latest update
            Named_TableStroke(AddNewNamedRecord, stroke) 'The movement of the mouse that id's this symbol
            Named_TableSyntax(AddNewNamedRecord, Syntax) ' The syntax for this
            Named_FileSyntax_Isam(AddNewNamedRecord) = AddNewNamedRecord

            ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, AddNewNamedRecord))
            ShowSorts("named", MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, AddNewNamedRecord))
            GetSelfCorrectingIndexes(SymbolName)
            ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, AddNewNamedRecord))
            TopOfFile("named", Named_FileSymbolName, Named_File_iSAM) ' This is to update the top of file, and make the array bigger
        End Function

        Public Shared Function AddANewFlowChartRecord() As Int32
            '2020/6/22 change to return the record numberinstead of passing it.
            MyTrace(121, "AddANewFlowChartRecord", 21)

            MyMakeArraySizesBigger()
            AddANewFlowChartRecord = NewTopOfFile("FlowChart", FlowChart_FileCoded)
            If FlowChart_iSAM_Name(AddANewFlowChartRecord) <> 0 Then
                If FlowChart_iSAM_Name(AddANewFlowChartRecord) <> AddANewFlowChartRecord() Then
                    MyMsgCtr("AddFlowChartRecord", 1018, FlowChart_TableNamed(AddANewFlowChartRecord), "", "", "", "", "", "", "", "")
                    AddANewFlowChartRecord = AddANewFlowChartRecord
                End If
            End If

            MyMakeArraySizesBigger()
            If QuickCheckSort("AddFlowChartRecord 100", FlowChart_FileNamed, FlowChart_iSAM_Name, AddANewFlowChartRecord) < 0 Then
                FindingMyBugs(10) 'hack Least amount of checking here
                Exit Function
            End If
            FlowChart_iSAM_Name(AddANewFlowChartRecord) = AddANewFlowChartRecord

            If QuickCheckSort("AddANewFlowChartRecord 110", FlowChart_FileNamed, FlowChart_iSAM_Name, AddANewFlowChartRecord) < 0 Then
                FindingMyBugs(10) 'hack Least amount of checking here
                Exit Function
            End If
            FlowChart_iSAM_X1(AddANewFlowChartRecord) = AddANewFlowChartRecord
            FlowChart_iSAM_Y1(AddANewFlowChartRecord) = AddANewFlowChartRecord
            FlowChart_iSAM_X2(AddANewFlowChartRecord) = AddANewFlowChartRecord
            FlowChart_iSAM_Y2(AddANewFlowChartRecord) = AddANewFlowChartRecord
        End Function

        Public Shared Function AddFlowChartRecord(named As String, coded As String, x1 As int32, y1 As int32, x2_Rotation As int32, y2 As int32, MyDataType As String, Links As String, LineNumber As int32) As int32
            '2020/6/22 change to return the record numberinstead of passing it.
            MyTrace(122, "AddFlowChartRecord", 54 - 31)

            MyMakeArraySizesBigger()
            AddFlowChartRecord = NewTopOfFile("FlowChart", FlowChart_FileCoded)
            MyMakeArraySizesBigger()
            FlowChart_iSAM_Name(AddFlowChartRecord) = AddFlowChartRecord
            FlowChart_iSAM_X1(AddFlowChartRecord) = AddFlowChartRecord
            FlowChart_iSAM_Y1(AddFlowChartRecord) = AddFlowChartRecord
            FlowChart_iSAM_X2(AddFlowChartRecord) = AddFlowChartRecord
            FlowChart_iSAM_Y2(AddFlowChartRecord) = AddFlowChartRecord

            FlowChart_FileNamed(AddFlowChartRecord) = named
            FlowChart_TableNamed(AddFlowChartRecord, named)
            FlowChart_TableCode_X(AddFlowChartRecord, MyKeyword_2_Byte(coded).ToString)
            FlowChart_TableX1(AddFlowChartRecord, x1)
            FlowChart_TableY1(AddFlowChartRecord, y1)
            FlowChart_TableX2_Rotation(AddFlowChartRecord, x2_Rotation)
            FlowChart_TableY2_Option(AddFlowChartRecord, y2)
            FlowChart_Table_DataType(AddFlowChartRecord, MyDataType) 'The datatype for /Path /constant
            FlowChart_PathLinks_And_CompiledCode(AddFlowChartRecord, Links) ' Holes information strings during compile (Path Connections, and completed Code)
            ShowSorts("FlowChart", ReSortFlowChart(AddFlowChartRecord))
            FindingMyBugs(10) 'hack Least amount of checking here
            TopOfFile("FlowChart", FlowChart_FileCoded) ' This is to update the top of file, and make the array bigger
            FindInNetLinks(AddFlowChartRecord)
            Return AddFlowChartRecord
        End Function



        Public Shared Function ReSortFlowChart(Index As int32) As int32
            '03/12/19 changed to only resort the top added item
            MyTrace(123, "ReSortFlowChart", 74 - 58)

            ReSortFlowChart = MyReSort("FlowChart", FlowChart_FileNamed, FlowChart_iSAM_Name, Index)
            ReSortFlowChart += MyReSort("FlowChart", FlowChart_FileX1, FlowChart_iSAM_X1, Index)
            ReSortFlowChart += MyReSort("FlowChart", FlowChart_FileY1, FlowChart_iSAM_Y1, Index)
            ReSortFlowChart += MyReSort("FlowChart", FlowChart_FileX2_Rotation, FlowChart_iSAM_X2, Index)
            ReSortFlowChart += MyReSort("FlowChart", FlowChart_FileY2_Option, FlowChart_iSAM_Y2, Index)

            CheckThis("ReSortFlowChart", 12, FlowChart_FileNamed, FlowChart_iSAM_Name, Index) 'hack
            '20200709 ReSortFlowChart += (QuickCheckSort("ReSortFlowChart 120", FlowChart_FileNamed, FlowChart_iSAM_Name, Index)) 'hack
        End Function


        Public Shared Function MyReSortAll_long(ByRef MyTable As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32) As int32
            Dim iDex As int32
            MyTrace(124, "MyReSortAll_Long", 87 - 77)

            MyReSortAll_long = 0
            For iDex = 1 To TopOfFile(MyTable, MyArrayLong, iSAM)
                MyReSortAll_long += (MyReSort_long(MyTable, MyArrayLong, iSAM, iDex))
            Next
            FindingMyBugs(10) 'hack Least amount of checking here
        End Function

        Public Shared Function MyReSort_long(ByRef MyTable As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32, Index As int32) As int32
            MyTrace(125, "ReSort_Long", 109 - 89)

            MyReSort_long = 0
            If InvalidIndex(Index, MyArrayLong, iSAM) Then
                Exit Function
            End If
            If iSAM(Index) <> 0 Then
                If iSAM(Index - 1) > 0 Then
                    If MyArrayLong(iSAM(Index - 1)) > MyArrayLong(iSAM(Index)) Then
                        SwapNn(MyTable, MyArrayLong, iSAM, Index - 1, Index)
                        MyReSort_long += 1
                        MyReSort_long += (MyReSort_long(MyTable, MyArrayLong, iSAM, Index - 1))
                        MyReSort_long += (MyReSort_long(MyTable, MyArrayLong, iSAM, Index + 1))
                        MyReSort_long += (MyReSort_long(MyTable, MyArrayLong, iSAM, Index))
                    End If
                End If
            End If
            FindingMyBugs(10) 'hack Least amount of checking here
        End Function

        '*******************************************************************
        'This is used to resort the array at the indexinput (Recursive if change is needed)
        'This needs to be changed to an insert sort (Faster)
        Public Shared Function MyReSort(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As Int32, IndexInput As Int32) As Int32
            Dim TopMost As Int32
            Dim Idex, Jdex As Int32
            Dim IdexTemp As Int32
            Dim ErrorCount As Int32
            MyTrace(126, "ReSort", 276 - 113)
            'If Int((MyUniverse.Recursion + 1) / 10) * 10 = MyUniverse.Recursion + 1 Then
            ' Abug(999, "Resort recursion is over " & MyUniverse.Recursion & " deep", MyUniverse.Recursion, 0)
            ' End If

            MyReSort = 0

            TopMost = TopOfFile(MyTable, MyArray, iSAM)
            Idex = IndexInput

            If IndexInput > UBound(MyArray) Then Exit Function '2020 09 25
            If IndexInput > TopMost Then Exit Function '2020 09 25

            ErrorCount = 8192


            While ErrorCount > 0
                ErrorCount -= 1

                Idex = MyMinMax(Idex, 1, UBound(MyArray) - 1) ' 2020 09 25
                Select Case MyCompared3(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1)))
                    Case 5
                        If PrintAbleNull(MyArray(iSAM(Idex - 1))) = "_" Then Return 5
                        If PrintAbleNull(MyArray(iSAM(Idex))) = "_" Then Return 5
                        If PrintAbleNull(MyArray(iSAM(Idex + 1))) = "_" Then Return 5
                        '15            5 if none of the below (Error in logic)"
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        'FindingMyBugs(10)'hack Least amount of checking here
                        Exit While
                    Case 4
                        '6            4 if  C = Null And C > A
                        '8            4 if C = ''
                        If Idex = MyMinMax(Idex, 1, TopMost) Then
                            IdexTemp = Idex
                            'C is null but is A > B then we...
                            While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1
                                SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex)
                                MyReSort += 1
                                Idex = MyMinMax(Idex - 1, 1, TopMost)
                            End While
                            If MyReSort > 0 Then
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                Idex = IdexTemp
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                            End If
                        End If
                        Exit Function
                    Case 3 ' So that we swap every thing up and down from here
                        '13            3 if B < C
                        Idex = IdexTemp
                        While MyCompared2(MyArray, iSAM, Idex, Idex + 1) < 0
                            SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                            MyReSort += 1
                            Idex = MyMinMax(Idex + 1, 1, TopMost)
                        End While
                        If MyReSort > 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            Idex = IdexTemp
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                        End If
                            'FindingMyBugs(10)'hack Least amount of checking here
                    Case 2
                        '14            2 if A > B

                        If MyCompared2(MyArray, iSAM, Idex - 1, Idex) >= 0 Then
                            'If MyArray(iSAM(Idex - 1)) > MyArray(iSAM(Idex)) Then 'hack
                            SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex)
                            MyReSort += 1
                            'FindingMyBugs(10)'hack Least amount of checking here
                        Else ' Error 'hack
                            Idex = MyMinMax(Idex, 1, TopMost) 'hack
                            FindingMyBugs(10) 'hack Least amount of checking here
                        End If 'hack
                        If MyReSort > 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            Idex = IdexTemp
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                        End If
                    Case 1 ' Duplication' check to make sure it is not out of order at the beggining of the dup's
                        Idex -= 1
                        'should we just ignore this duplications?
                        '4            1 if B = C
                        'While Idex > 1 And MyArray(iSAM(Idex)) = MyArray(iSAM(Idex - 1))
                        ' SwapN(MyTable, MyArray, iSAM, Idex, Idex - 1)
                        ' Idex -= 1
                        ' End While
                        '             While Idex > 1 And MyArray(iSAM(Idex - 1)) > MyArray(iSAM(Idex))
                        '             SwapN(MyTable, MyArray, iSAM, Idex, Idex - 1)
                        '             Idex -= 1
                        ' End While
                        '             While Idex - 2 < UBound(MyArray) And MyArray(iSAM(Idex)) > MyArray(iSAM(Idex + 1))
                        '             SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                        '             Idex += 1
                        ' End While
                        'MyUniverse.Recursion -= 1
                        'Exit Function
                    Case 0 ' This should never happen but when it does, we should do nothing
                        '1            0 if the middle Is null
                        '2            0 if first = third are null
                        '10            0 if A < B & B < C
                        Idex = IndexInput
                        While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1
                            SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex)
                            Idex = MyMinMax(Idex - 1, 1, TopMost)
                        End While
                        While MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1
                            SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                            Idex = MyMinMax(Idex + 1, 1, TopMost)
                        End While
                        If MyReSort > 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            Idex = IdexTemp
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        End If
                        Exit Function ' Should not swap anything up or down
                    Case -1 ' Duplication
                        '3            -1 if A = B
                        Jdex = Idex
                        While MyCompared2(MyArray, iSAM, Jdex, Jdex + 1) > 0
                            SwapN(MyTable, MyArray, iSAM, Jdex, Jdex + 1)
                            Jdex += 1
                        End While
                        Jdex = Idex


                        ' Find the beggining and cause a sort from there
                        'While MyCompared2(MyArray(iSAM(Idex)), MyArray(iSAM(Idex - 1)) = 0' Same
                        While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 0
                            Idex -= 1
                        End While
                        While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 0
                            'While MyCompared2(MyArray(iSAM(Jdex)), MyArray(iSAM(Jdex + 1)) = 0
                            Jdex += 1
                        End While


                        'If MyCompared2(MyArray(iSAM(Idex)), MyArray(iSAM(Idex - 1)) <= 0 Then' 
                        If MyCompared2(MyArray, iSAM, Idex - 1, Idex) >= 0 Then
                            MyReSort(MyTable, MyArray, iSAM, Idex)
                            MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            MyReSort(MyTable, MyArray, iSAM, Idex)
                            MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        End If

                        If MyCompared2(MyArray, iSAM, Jdex, Jdex + 1) > 0 Then
                            'If MyCompared2(MyArray(iSAM(Jdex)), MyArray(iSAM(Idex + 1)) > 0 Then
                            MyReSort(MyTable, MyArray, iSAM, Jdex)
                            MyReSort(MyTable, MyArray, iSAM, Jdex + 1)
                            MyReSort(MyTable, MyArray, iSAM, Jdex)
                            MyReSort(MyTable, MyArray, iSAM, Jdex + 1)
                        End If
                        Exit Function
                    Case -2
                        '12            -2 if B > C
                        While MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1 'hack
                            SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                            MyReSort += 1
                            Idex = MyMinMax(Idex + 1, 1, TopMost)
                        End While

                        'Removed cause it cause recursion problems
                        'If MyReSort > 0 Then
                        ' MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                        ' MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        ' MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        ' Idex = IdexTemp
                        ' MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        ' MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                       ' End If
                    Case -3
                        '11            -3 if A > B
                        If MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1 Then 'MyCompared(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))) = 1 Then 'hack
                            IdexTemp = Idex
                            While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1 'MyCompared(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))) = 1
                                SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex)
                                MyReSort += 1
                                Idex = MyMinMax(Idex - 1, 1, TopMost)
                            End While
                            If MyReSort > 0 Then
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                Idex = IdexTemp
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                            End If
                        End If
                        If MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 Then 'mycompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1 Then 'hack
                            IdexTemp = Idex
                            While MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1
                                SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                                MyReSort += 1
                                Idex = MyMinMax(Idex + 1, 1, TopMost)
                            End While
                            If MyReSort > 0 Then
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                Idex = IdexTemp
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                            End If
                        End If
                        'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        Idex = IdexTemp
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            'MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex))
                    Case -4
                        '5            -4 if A = Null & B < C
                        '7            -4 if A = ''
                        IdexTemp = Idex
                        If Idex > 1 Then
                            While MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1
                                SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                                MyReSort += 1
                                Idex = MyMinMax(Idex + 1, 1, TopMost)
                            End While
                            If MyReSort > 0 Then
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                                Idex = IdexTemp
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                                MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            End If
                        End If
                        Exit Function
                    Case -5
                        '9            -5 if A > C (error in list)
                        SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex + 1) ' swap A & C which is being wrong

                        While MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 1 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 1
                            SwapN(MyTable, MyArray, iSAM, Idex, Idex + 1)
                            MyReSort += 1
                            Idex = MyMinMax(Idex + 1, 1, TopMost)
                        End While
                        While MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1 'MyCompared(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))) = 1
                            SwapN(MyTable, MyArray, iSAM, Idex - 1, Idex)
                            MyReSort += 1
                            Idex = MyMinMax(Idex - 1, 1, TopMost)
                        End While
                        If MyReSort > 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            Idex = IdexTemp
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                            ' Taken out for now 
                            '                            For Idex = 1 To TopMost 'kludge
                            '                           MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex) 'kludge
                            '                            Next Idex 'hack kludge
                        End If
                        'maybe below we should just exit???????
                        If MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1 Then 'MyCompared(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))) = 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            Exit Function
                        End If
                        If MyCompared2(MyArray, iSAM, Idex, Idex + 1) = 0 Then 'MyCompared(MyArray(iSAM(Idex)), MyArray(iSAM(Idex + 1))) = 0 Then
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                            MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                            Exit Function
                        End If

                    Case Else ' Invalid return from compared3() sHOULD NEVER HAPPEN
                        If MyReSort <> 0 Then DisplayMyStatus(MyTable & " = " & MyReSort)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                        Idex = IdexTemp
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                        MyReSort += MyReSort(MyTable, MyArray, iSAM, Idex)
                        Exit Function
                End Select
            End While
        End Function


        'Only sort the last inserted NOT the whole MyArray
        Public Shared Function MyReSort(ByRef MyTable As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32, IndexInput As int32) As int32
            Dim TopMost, Idex As int32
            Dim Flag As Boolean
            MyTrace(127, "MyReSort", 315 - 280)

            MyReSort = 0
            TopMost = TopOfFile(MyTable, MyArrayLong, iSAM)
            ' Check if the index is inbounds
            If IndexInput <> MyMinMax(IndexInput, 1, UBound(iSAM)) Then
                Exit Function
            End If

            If InvalidIndex(IndexInput, MyArrayLong, iSAM) Then
                Exit Function
            End If

            If InvalidIndex(IndexInput - 1, MyArrayLong, iSAM) Then
            Else
                Idex = IndexInput
                Flag = False
                While (Idex > 0 And
                    InvalidIndex(Idex, MyArrayLong, iSAM) = False And
                    InvalidIndex(Idex - 1, MyArrayLong, iSAM) = False And
                    MyArrayLong(iSAM(Idex)) < MyArrayLong(iSAM(Idex - 1)))
                    SwapNn(MyTable, MyArrayLong, iSAM, Idex - 1, Idex)
                    Flag = True
                    MyReSort += 1
                    Idex -= 1
                    'FindingMyBugs(10)'hack Least amount of checking here
                End While
                If Flag = True Then
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, Idex - 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput - 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput + 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, Idex + 1)
                End If
            End If

            If InvalidIndex(Idex + 1, MyArrayLong, iSAM) Then
            Else
                Idex = IndexInput
                Flag = False
                While Idex > 0 And
                    InvalidIndex(Idex, MyArrayLong, iSAM) = False And
                    InvalidIndex(Idex + 1, MyArrayLong, iSAM) = False And
                    MyArrayLong(iSAM(Idex + 1)) < MyArrayLong(iSAM(Idex))
                    SwapNn(MyTable, MyArrayLong, iSAM, Idex, Idex + 1)
                    Flag = True
                    MyReSort += 1
                    Idex -= 1
                    'FindingMyBugs(10)'hack Least amount of checking here
                End While
                If Flag = True Then
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, Idex - 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput - 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, IndexInput + 1)
                    MyReSort += MyReSort(MyTable, MyArrayLong, iSAM, Idex + 1)
                End If
            End If
        End Function

        Public Shared Function SortiSAMs() As int32
            MyTrace(128, "SortiSAMs", 26 - 17)

            SortiSAMs = 0
            SortiSAMs += (SortColors())
            SortiSAMs += (SortDataType())
            SortiSAMs += (SortNamed())
            SortiSAMs += (SortFlowChart())
            FindingMyBugs(10) 'hack Least amount of checking here
        End Function

        Public Shared Function SortColors() As int32            'First Sort Color iSAMe (again?)
            MyTrace(129, "SortColors", 36 - 28)

            SortColors = (MySortStringArray("Color", Color_FileName, Color_iSAM_))
            MyUniverse.MyCheatSheet.ColorsSorted = 0
        End Function
        '***********************************************************************
        'This sorts the datatype array
        Public Shared Function SortDataType() As int32
            MyTrace(131, "SortDataType", 45 - 38)

            SortDataType = (MySortStringArray("DataType", DataType_FileName, DataType_iSAM_))
            MyUniverse.MyCheatSheet.DataTypeSorted = 0
        End Function
        '***********************************************************************
        'sorts the symbol array by the name of the symbol
        Public Shared Function SortNamed() As Int32
            MyTrace(132, "SortNamed", 56 - 48)

            'Next Names Of symbols and other things
            SortNamed = MySortStringArray("Named", Named_FileSymbolName, Named_File_iSAM)
            SortNamed += MySortStringArray("named", Named_FileSyntax, Named_FileSyntax_Isam) ' added 2020 08 12
            MyUniverse.MyCheatSheet.NamedSorted = 0
        End Function

        Public Shared Function SortFlowChart() As int32
            MyTrace(133, "SortFlowChart", 71 - 58)

            SortFlowChart = 0
            If TopOfFile("FlowChart", FlowChart_FileCoded) = 1 Then Exit Function
            SortFlowChart += (MySortStringArray("FlowChart", FlowChart_FileNamed, FlowChart_iSAM_Name))
            SortFlowChart += (MySortNumberArray("FlowChart", FlowChart_FileX1, FlowChart_iSAM_X1))
            SortFlowChart += (MySortNumberArray("FlowChart", FlowChart_FileY1, FlowChart_iSAM_Y1))
            SortFlowChart += (MySortNumberArray("FlowChart", FlowChart_FileX2_Rotation, FlowChart_iSAM_X2))
            SortFlowChart += (MySortNumberArray("FlowChart", FlowChart_FileY2_Option, FlowChart_iSAM_Y2))
            MyUniverse.MyCheatSheet.FlowChartSorted = 0
        End Function

        Public Shared Sub SortALLiSAM()
            Dim Index As int32
            MyTrace(134, "SortALLiSAM", 449 - 373)

            'Get rid of all old information

            'MyStatus("Setting Sort . . . Colors")
            For Index = 1 To TopOfFile("Color", Color_FileName, Color_iSAM_)
                Color_iSAM_(Index) = Index
            Next Index
            For Index = TopOfFile("Color", Color_FileName, Color_iSAM_) + 1 To UBound(Color_FileName)
                Color_iSAM_(Index) = 0
            Next Index

            ShowSorts("Colors", SortColors())

            'MyStatus("Setting Sort . . . DataTypes")
            For Index = 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                DataType_iSAM_(Index) = Index
            Next Index
            'For Index = TopOfFile("DataType", DataType_FileName, DataType_iSAM_) + 1 To UBound(DataType_FileName)
            ' DataType_iSAM_(Index) = 0
            ' Next Index

            ShowSorts("DataType", SortDataType())

            'MyStatus("Setting Sort . . . Symbol Names")
            For Index = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                Named_File_iSAM(Index) = Index
                Named_FileSyntax_Isam(Index) = Index
            Next Index
            'set unused records to zero
            For Index = TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) + 1 To UBound(Named_FileSymbolName)
                Named_File_iSAM(Index) = 0
                Named_FileSyntax_Isam(Index) = 0
            Next Index

            ShowSorts("Named", SortNamed())

            'MyStatus("Setting Sort . . . FlowChart")
            For Index = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                Select Case LCase(Trim(FlowChart_TableCode(Index)))
                    Case "/use", "/constant", "/error"
                        FlowChart_iSAM_Name(Index) = Index
                        FlowChart_iSAM_X1(Index) = Index
                        FlowChart_iSAM_Y1(Index) = Index
                        FlowChart_iSAM_X2(Index) = Index ' Rotation
                        FlowChart_iSAM_Y2(Index) = Index
                    Case "/path", ""
                        FlowChart_iSAM_Name(Index) = Index
                        FlowChart_iSAM_X1(Index) = Index
                        FlowChart_iSAM_Y1(Index) = Index
                        FlowChart_iSAM_X2(Index) = Index
                        FlowChart_iSAM_Y2(Index) = Index
                    Case Else
                        MyMsgCtr("SortAlliSAM", 1375, "Unknow Code ", ">" & LCase(Trim(FlowChart_TableCode(Index))) & "<",
                                 "Code= >" & MyKeyword_2_Byte(FlowChart_TableCode(Index)) & "<",
                                 "(" & FlowChart_TableX1(Index) & FD & FlowChart_TableY1(Index) & ")",
                                 "(" & FlowChart_TableX2_Rotation(Index) & FD & FlowChart_TableY2_Option(Index) & ")",
                                 "Links = " & FlowChart_PathLinks_And_CompiledCode(Index),
                                 "Named = " & FlowChart_TableNamed(Index),
                                 "Datatype = " & FlowChart_Table_DataType(Index),
                                 "Index = " & Index)
                        FlowChart_iSAM_Name(Index) = Index
                        FlowChart_iSAM_X1(Index) = 0
                        FlowChart_iSAM_Y1(Index) = 0
                        FlowChart_iSAM_X2(Index) = 0
                        FlowChart_iSAM_Y2(Index) = 0
                        MyMsgCtr("SortAlliSAM", 1277, Index.ToString, FlowChart_TableCode(Index), "", "", "", "", "", "", "")
                End Select
            Next


            'Hack Why do I set it above and then here set everything to no index??
            For Index = TopOfFile("FlowChart", FlowChart_FileCoded) + 1 To UBound(FlowChart_FileCoded)
                FlowChart_iSAM_Name(Index) = 0
                FlowChart_iSAM_X1(Index) = 0
                FlowChart_iSAM_Y1(Index) = 0
                FlowChart_iSAM_X2(Index) = 0
                FlowChart_iSAM_Y2(Index) = 0
            Next Index
            ShowSorts("FlowChart", SortFlowChart())

            'SortALLiSAM = SortALLiSAM + ShowSorts(mytable,SortiSAMs())
            ' Removed right after sorting every thing '20200628
            'MyCheatSheet.ColorsSorted += 1 : MyCheatSheet.DataTypeSorted += 1 : MyCheatSheet.NamedSorted += 1 : MyCheatSheet.FlowChartSorted += 1
        End Sub


        Public Shared Function MySortNumberArray(ByRef MyTable As String, ByRef MyArrayLong() As int32, ByRef iSAM() As int32) As int32
            MyTrace(135, "MySortNumberArray", 5)

            MySortNumberArray = (MyQuickNumbersort(MyTable, MyArrayLong, iSAM, 0, 0))
            '            MySortNumberArray = MySortNumberArray + MyFixSort(MyTable, MyArrayLong, iSAM)
        End Function
        '****************************************************************************
        ' This is to find the location of where to inset this record in an already sorted List at index
        Public Shared Function InsertReSortLanguageKeyWords(ByRef MyTable As String, ByRef MyArray() As String, Index As Int32) As Int32
            Dim Cdex As Int32 ' Where to insert at
            Dim SavedItem As String
            Dim I As Int32 ' loop through and move all of the list one items
            'Finst find where it goes in the sorted list

            If UBound(MyArray) < Index Then
                ReDim Preserve MyArray(Index)
            End If

            InsertReSortLanguageKeyWords = 0 'number of swaps made
            If Index <> MyMinMax(Index, LBound(MyArray), UBound(MyArray)) Then Exit Function ' If invalid index then do nothing

            SavedItem = MyArray(Index) ' save the item to be moved
            ''''''''    MyArray(Index) = Nothing

            Cdex = MyMinMax(Index + 1, LBound(MyArray), UBound(MyArray)) ' The Next one
            While MyCompared1_a(MyArray(Index), MyArray(Cdex)) = 1 And Index <> Cdex
                Cdex = MyMinMax(Index + 1, LBound(MyArray), UBound(MyArray))
            End While

            While MyCompared1_a(MyArray(Index), MyArray(Cdex)) = -1 And Index <> Cdex
                Cdex = MyMinMax(Index - 1, LBound(MyArray), UBound(MyArray))
            End While



            'Cdex should now be where Index (This insert record goes)
            If Index < Cdex Then
                For I = UBound(MyArray) To Cdex Step -1
                    MyArray(I) = MyArray(I - 1)
                Next
            Else
                For I = UBound(MyArray) To Cdex Step -1
                    MyArray(I) = MyArray(I - 1)
                Next
            End If
            MyArray(Index) = SavedItem
        End Function
        '****************************************************************************
        ' Make sure that the language keywords (and operator key words) are sorted for ordered (binary) search
        Public Shared Function ReSortLanguageKeyWords(ByRef MyTable As String, ByRef MyArray() As String, Index As int32) As int32
            Dim Adex As int32
            Dim Idex As int32
            Dim Cdex As int32
            Dim Flag As Boolean
            Dim ResortCount As int32
            MyTrace(136, "ReSortStringArray", 156 - 116)

            ResortCount = 0
            ReSortLanguageKeyWords = 0
            Flag = False

            ' This is here to just test if an insert sort works faster
            ' This seems to break sorting ReSortLanguageKeyWords = InsertReSortLanguageKeyWords(MyTable, MyArray, Index)


            If Index <> MyMinMax(Index, LBound(MyArray), UBound(MyArray)) Then Exit Function
            Idex = MyMinMax(Index, LBound(MyArray), UBound(MyArray))
            Cdex = MyMinMax(Idex + 1, LBound(MyArray), UBound(MyArray))
            While MyCompared1_a(MyArray(Idex), MyArray(Cdex)) = 1 And Idex <> Cdex
                SwapLanguageKeyWords(MyTable, MyArray, Idex, Cdex)
                ResortCount += 1
                Flag = True
                ReSortLanguageKeyWords += 1
                Idex = MyMinMax(Idex + 1, LBound(MyArray), UBound(MyArray) - 1)
                Cdex = MyMinMax(Index + 1, LBound(MyArray), UBound(MyArray))
            End While

            'try the other way
            Idex = MyMinMax(Index, LBound(MyArray), UBound(MyArray))
            Adex = MyMinMax(Idex - 1, LBound(MyArray), UBound(MyArray))
            While MyCompared1_a(MyArray(Adex), MyArray(Idex)) = 1 And Adex <> Idex
                SwapLanguageKeyWords(MyTable, MyArray, Adex, Idex)
                Flag = True
                Idex = MyMinMax(Idex - 1, LBound(MyArray) + 1, UBound(MyArray))
                Adex = MyMinMax(Idex - 1, LBound(MyArray), UBound(MyArray))
            End While


            ' Just to see if it does it here (to save recursion)
            Idex = MyMinMax(Index, LBound(MyArray), UBound(MyArray))
            Cdex = MyMinMax(Idex + 1, LBound(MyArray), UBound(MyArray))
            While MyCompared1_a(MyArray(Idex), MyArray(Cdex)) = 1 And Idex <> Cdex
                Abug(937, "ReSortLanguageKeyWords", MyArray(Idex), MyArray(Cdex)) ' we should never beable to do it twice
                SwapLanguageKeyWords(MyTable, MyArray, Idex, Cdex)
                Flag = True
                Idex = MyMinMax(Idex + 1, LBound(MyArray), UBound(MyArray) - 1)
                Cdex = MyMinMax(Idex + 1, LBound(MyArray), UBound(MyArray))
            End While

            'try the other way
            Idex = MyMinMax(Index, LBound(MyArray), UBound(MyArray))
            Adex = MyMinMax(Idex - 1, LBound(MyArray), UBound(MyArray))
            While MyCompared1_a(MyArray(Adex), MyArray(Idex)) = 1 And Adex <> Idex
                Abug(936, "ResortLanguageKeyWords():", MyArray(Adex), MyArray(Idex)) ' we should never beable to do it twice
                SwapLanguageKeyWords(MyTable, MyArray, Idex - 1, Idex)
                Flag = True
                Idex = MyMinMax(Idex - 1, LBound(MyArray) + 1, UBound(MyArray))
                Adex = MyMinMax(Idex - 1, LBound(MyArray), UBound(MyArray))
            End While

            If Flag = True Then
                ResortCount = 0 ' This is to see if all (OR ANY) of this checksorting is needed!
                ResortCount += ReSortLanguageKeyWords(MyTable, MyArray, Idex - 1)
                ResortCount += +ReSortLanguageKeyWords(MyTable, MyArray, Idex + 1) 'hack
                ResortCount += +ReSortLanguageKeyWords(MyTable, MyArray, Idex)
                Idex = Index 'hack
                ResortCount += +ReSortLanguageKeyWords(MyTable, MyArray, Index - 1) 'hack
                ResortCount += +ReSortLanguageKeyWords(MyTable, MyArray, Index + 1) 'hack
                ResortCount += ReSortLanguageKeyWords(MyTable, MyArray, Index)
                ReSortLanguageKeyWords += ResortCount
            End If
            ' We get here only if we do nothing
            FindingMyBugs(10) 'hack Least amount of checking here
        End Function


        Public Shared Function ReSortStringArray(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32) As int32
            Dim TopMost As int32
            Dim Index As int32
            MyTrace(137, "MySortStringArray", 97 - 75)

            ReSortStringArray = 0
            'First Try to sort just the top
            If UBound(iSAM) <> UBound(MyArray) Then
                MyMsgCtr("ReSortStringArray", 1007, UBound(MyArray).ToString, UBound(iSAM).ToString, "", "", "", "", "", "", "")
            End If
            TopMost = TopOfFile(MyTable, MyArray, iSAM)
            For Index = 2 To TopMost
                ReSortStringArray += MyReSort(MyTable, MyArray, iSAM, Index)
            Next Index
            ReSortStringArray += MyReSort(MyTable, MyArray, iSAM, TopMost)
            If MyIsValidCheckSortAll_String(MyTable, MyArray, iSAM) = False Then
                ReSortStringArray += ReBubbleSortAll(MyTable, MyArray, iSAM)
                MyIsValidCheckSortAll_String(MyTable, MyArray, iSAM) 'hack so I can see why it's here
            End If
        End Function

        '***********************************************************************
        'bubble sort the array 
        'Which means sorting the index to the array and never changing the array, so that Indexess/indexs stay the same
        Public Shared Function MySortStringArray(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As Int32) As Int32 ' returns the number sorted
            Dim Idex As Int32
            Dim NumberSorted As Int32
            MyTrace(138, "MySortStringArray", 10)

            MySortStringArray = 0
            'FindingMyBugs(10)'hack Least amount of checking here no reason to check and get an out of order before sorting
            For Idex = TopOfFile(MyTable, MyArray, iSAM) To 1 Step -1
                NumberSorted = MyReSort(MyTable, MyArray, iSAM, Idex) '20200703'+20200708
                MySortStringArray += NumberSorted
                If NumberSorted > 0 Then
                    NumberSorted = MyReSort(MyTable, MyArray, iSAM, Idex - 1)
                    MySortStringArray += NumberSorted
                    NumberSorted = MyReSort(MyTable, MyArray, iSAM, Idex)
                    MySortStringArray += NumberSorted
                    NumberSorted = MyReSort(MyTable, MyArray, iSAM, Idex + 1)
                    MySortStringArray += NumberSorted
                End If
            Next

            If MyIsValidCheckSortAll_String(MyTable, MyArray, iSAM) = False Then
                MySortStringArray += (ReBubbleSortAll(MyTable, MyArray, iSAM))
            End If
            FindingMyBugs(10) 'hack Least amount of checking here ' Check after sorting
        End Function

        Public Shared Sub MyInsertSymbolRecordX1Y1IODT(IndexSymbol As Int32,
                                                       Symbolname As String,
                                                       Code As String,
                                                       X As Int32,
                                                       Y As Int32,
                                                       IO As String,
                                                       DT As String,
                                                       MyNameOfPoint As String)
            MyTrace(139, "MyInsertSymbolRecordX1Y1IODT", 5)

            MyMakeArraySizesBigger()
            MyInsertSymbolRecord_Line(IndexSymbol, Symbolname, Code, MyLine1(X, Y, NumberOrIO(IO.ToString), NumberOrDT(DT.ToString)), MyNameOfPoint)
        End Sub


        Public Shared Sub MyInsertSymbolRecord_Line(IndexSymbol As int32, Symbolname As String, Code As String, XY As MyLineStructure, MyNameOfPoint As String)
            ',            'Named As String)
            Dim Index As int32
            Dim IndexAt As int32
            MyTrace(141, "MyInsertSymbolRecord", 50 - 12)

            MyMakeArraySizesBigger()
            FindingMyBugs(10) 'hack Least amount of checking here 'hack make sure that there is no errors first  (Buge before here) 2020 08 04


            ' This extra code is because of a bug somewhere else.
            ' bug, we should never be trying to inser two name records.
            If Code = "/name" Then 'hack
                For Index = 1 To NewTopOfFile("symbol", Symbol_FileCoded) 'hack
                    If Index <> IndexSymbol Then
                        If Symbol_TableCoded_String(Index) = "/name" Then 'hack
                            If Symbol_TableSymbolName(Index) = Symbolname Then 'hack
                                Abug(997, "Trying to insert the /name=" & Symbolname, " record again At " & IndexSymbol & " : " &
                                     Symbol_TableCoded_Byte(IndexSymbol) & ":" & Symbol_TableCoded_String(IndexSymbol) & ":" & Symbol_TableSymbolName(IndexSymbol), "Is already at=" & Index & " : " &
                                     Symbol_TableCoded_Byte(Index) & " : " & Symbol_TableCoded_String(Index) & ":" & Symbol_TableSymbolName(Index)) 'hack
                                Exit Sub ' extra Just ignor the error in the program that is doing this
                            End If 'hack
                        End If 'hack
                    End If ' extra
                Next Index 'hack
            End If ' extra
            If PrintAbleNull(Symbolname) = "_" Then MyMsgCtr("MyInsertSymbolRecord", 1413, Symbolname, "12", "", "", "", "", "", "", "")
            '2021 01 04 removed ReSortSymbolList() 'hack this might change where you are inserting at,  needs to be done at the end, or better yet after finishing all inserting
            CheckForAnySortNeeded("", 127)
            IndexAt = IndexSymbol
            '20200629 ShowSorts(mytable,ReSortStringArray("Symbol", Symbol_FileSymbolName, Symbol_iSAM_))
            ' 2020 07 18 FindInSymbolList(Symbolname) ' Shortcort to Indexes
            If IndexAt = constantMyErrorCode Then
                MyMakeArraySizesBigger()
                ' special case, it goes at the end of the file
                IndexAt = NewTopOfFile("Symbol", Symbol_FileCoded)
                'hack indexat = FindInSymbolList(Symbolname)+1 'Should this be inserted here to force an insert right after the name
                Symbol_TableSymbolName(IndexAt, Symbolname)
                'Symbol_TableCode(IndexAt, "/name")
                Symbol_TableCode(IndexAt, Code)
                Symbol_TableX1(IndexAt, XY.a.X)
                Symbol_TableY1(IndexAt, XY.a.Y)
                Symbol_TableX2_io(IndexAt, XY.b.X)
                Symbol_TableY2_dt(IndexAt, XY.b.Y)
                Symbol_Table_NameOfPoint(IndexAt, MyNameOfPoint)
                ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, IndexAt))
                IndexAt = FindInSymbolList(Symbolname) ' Shortcort to Indexes
                ReSortSymbolList()

                If LCase(Code) = "/name" Then
                    Exit Sub ' so we do not add two name records
                End If
            Else
            End If

            For Index = NewTopOfFile("Symbol", Symbol_FileCoded) To IndexAt Step -1
                'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 04
                SwapSymbolList(Index, Index + 1) ' Move it one record in the 'sorted file, because it's Import to keep them in 'order'
                'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 04
            Next
            'Add this record right after the name  record (I hope)
            'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 05
            Symbol_TableSymbolName(IndexAt, Symbolname)
            'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 05
            Symbol_TableCode(IndexAt, Code)
            'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 05
            Symbol_TableX1(IndexAt, XY.a.X)
            Symbol_TableY1(IndexAt, XY.a.Y)
            Symbol_TableX2_io(IndexAt, XY.b.X)
            Symbol_TableY2_dt(IndexAt, XY.b.Y)
            Symbol_Table_NameOfPoint(IndexAt, MyNameOfPoint)
            'Why are we resorting the named table when we add to the unsorted symbol table?  2020 07 18
            'ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, IndexAt))
            ReSortSymbolList()
            FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 05
        End Sub


        'Routine Paint ALL Where is the for, (-) is to erase it
        Public Shared Sub PaintEach(Where As PictureBox, XYOffSet As MyPointStructure, SymbolName As String, RotationName As String)
            Dim IndexNamed As int32
            Dim IndexSymbol As int32
            Dim RotatedXY As MyPointStructure
            MyTrace(142, "PaintEach", 5710 - 5557)

            If IsNothing(SymbolName) Or SymbolName = "" Then
                Exit Sub ' Because this is not a symbol
            End If
            'TDist = myuniverse.sysgen.ConstantSymbolCenter - (myuniverse.sysgen.ConstantSymbolCenter / 10) ' Gives me 9/10 of the distance

            'Display the symbol name in on screen
            MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(2).X), CStr(MyUniverse.OptionDisplay(2).Y)), SymbolName, 2)

            IndexNamed = FindIndexIniSAMTable("Named", "NeverAddWhilePainting", Named_FileSymbolName, Named_File_iSAM, SymbolName)
            If IndexNamed = constantMyErrorCode Then
                MyMsgCtr("Paint Each", 1021, "Symbol Name Not Found", SymbolName, "", "", "", "", "", "", "")
                Exit Sub
            End If

            'Never update the Indexes while painting
            IndexNamed = CheckNotInList("Named", "NeverAddWhilePainting", Named_FileSymbolName, Named_File_iSAM, SymbolName)
            If IndexNamed = constantMyErrorCode Then                                     ' If found in the named table
                IndexNamed = IndexNamed 'error cant find'error'hack
            Else
                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(3) = True Then 'stroke
                    MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(3).X), CStr(MyUniverse.OptionDisplay(3).Y)), Named_TableStroke(IndexNamed), 3)
                End If
                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(4) = True Then 'filename
                    MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(4).X), CStr(MyUniverse.OptionDisplay(4).Y)), Named_TableNameofFile(IndexNamed), 4)
                End If

                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(5) = True Then 'Notes
                    MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(5).X), CStr(MyUniverse.OptionDisplay(5).Y)), Named_TableNotes(IndexNamed), 5)
                    Application.DoEvents()
                End If

                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(6) = True Then ' Opcode
                    MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(6).X), CStr(MyUniverse.OptionDisplay(6).Y)), Named_TableOpCode(IndexNamed), 6)
                    Application.DoEvents()
                End If

                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(7) = True Then ' Program code text
                    MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(7).X), CStr(MyUniverse.OptionDisplay(7).Y)), Named_TableProgramText(IndexNamed), 7)
                    Application.DoEvents()
                End If

                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(8) = True Then ' short cut Indexes
                    If F_C.InvalidIndex(Named_TableIndexes(IndexNamed), F_C.Named_FileSymbolName) Then
                        MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(8).X), CStr(MyUniverse.OptionDisplay(8).Y)), "?", 8)
                        Application.DoEvents()
                    Else
                        MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(8).X), CStr(MyUniverse.OptionDisplay(8).Y)), Named_TableIndexes(IndexNamed).ToString, 8)
                        Application.DoEvents()
                    End If
                End If
                GetSelfCorrectingIndexes(SymbolName)
                IndexSymbol = Named_TableIndexes(IndexNamed) ' GetSelfCorrectingIndexes(SymbolName)
                If IndexSymbol = 0 Then ' update the Indexes, if and only if it is pointing to nothing
                    Named_TableIndexes(IndexNamed, GetSelfCorrectingIndexes(SymbolName))
                    IndexSymbol = Named_TableIndexes(IndexNamed) ' GetSelfCorrectingIndexes(SymbolName)
                End If

                If IndexSymbol > constantMyErrorCode Then                                   ' If there is a name in the named table then
                    If IndexSymbol > 0 Then
                        If Symbol_TableCoded_String(IndexSymbol) <> "/name" Or Symbol_TableSymbolName(IndexSymbol) <> SymbolName Then   ' If the names do note match (error)
                            IndexSymbol = FindInSymbolList(SymbolName) '20200711 '20200629   ' Find the actual location in the symbol table
                            If IndexSymbol <= 0 Then                          ' If there is a name in the symbol table 
                            Else
                                Abug(934, SymbolName, RotationName, IndexSymbol)
                                IndexSymbol = constantMyErrorCode                              ' not in the symbol talbe anyway
                                Exit Sub ' 20200713 because we have no graphics to show
                            End If
                            'Else
                            '    Index = IndexSymbol                                  'Shortcut worked here
                        Else
                            IndexSymbol = GetSelfCorrectingIndexes(SymbolName) 'not in the named table (so assumed not in the symbol table
                        End If
                    Else
                        'This is an named symbol with no graphics, so it's an error if we ever get here. but fix it for next time????????
                        IndexSymbol = GetSelfCorrectingIndexes(SymbolName) 'not in the named table (so assumed not in the symbol table
                        If IndexSymbol > 0 Then
                            Named_TableIndexes(IndexNamed, IndexSymbol)
                        Else
                            Abug(933, SymbolName, IndexNamed, IndexSymbol)
                            IndexNamed = constantMyErrorCode                                          ' Not in the named table.
                        End If
                    End If
                Else
                    Abug(932, "PaintEach(): Symbol Name Not Found in named_Table", SymbolName, RotationName) ' invalid symbol index?????
                End If
            End If


            If IndexSymbol = constantMyErrorCode Then 'hack? because we have to exit if there is no graphices for the symbol
                Abug(931, SymbolName, IndexNamed, IndexSymbol)
                Exit Sub
            End If
            IndexSymbol = IndexSymbol + 1 ' after the MyKeyword_2_string(KeyConstName )  for the rest of the symbol till the next name or end
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
            While (Symbol_TableCoded_String(IndexSymbol) <> "/name") And (IndexSymbol < TopOfFile("Symbol", Symbol_FileCoded))
                Select Case Symbol_TableCoded_String(IndexSymbol)
                    Case "/line"  'Line Start
                        MyDrawLineWithIndex(Where, IndexSymbol, XYOffSet, RotationName)
                    Case "/point"
                        RotatedXY = MyRotated_1(IndexSymbol, ZeroZero, RotationName)
                        MyDrawCircle_At(Where, MyPoint1(RotatedXY.X + XYOffSet.X, RotatedXY.Y + XYOffSet.Y), Symbol_TableSymbolName(IndexSymbol), Symbol_Table_NameOfPoint(IndexSymbol))

                        ', Symbol_TableSymbolName(IndexSymbol) , 
                        MyDrawPointArrow(Where,
                                         MyRotated_1(IndexSymbol, XYOffSet, RotationName),
                                         MyRotated_1a(IndexSymbol, RotationName),
                                        DataType_TableName(Symbol_TableY2_dt(IndexSymbol)),
                                         RotationName,
                                         Symbol_TableX2_io(IndexSymbol))
                        'MyUnEnum(Symbol_TableX2_io(IndexSymbol), SymbolScreen.ToolStripDropDownInputOutput, 1), from above
                        MyDrawText(Where, MyRotated_1(IndexSymbol, MyPoint1(XYOffSet.X + CInt(MyUniverse.OptionDisplay(11).X), XYOffSet.Y + CInt(MyUniverse.OptionDisplay(11).Y)), RotationName), Symbol_TableSymbolName(IndexSymbol), 11)
                        MyDrawText(Where, MyRotated_1(IndexSymbol, MyPoint1(XYOffSet.X + CInt(MyUniverse.OptionDisplay(1).X), XYOffSet.Y + CInt(MyUniverse.OptionDisplay(1).X)), RotationName), Symbol_Table_NameOfPoint(IndexSymbol), 1)
                    Case "/name"
                        MyDrawText(Where, MyRotated_1(IndexSymbol, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(2).X), CStr(MyUniverse.OptionDisplay(2).Y)), RotationName), Symbol_TableSymbolName(IndexSymbol), 2)
                    Case "/delete"
                        MyDrawCircle_At(Where, ZeroZero, "red", LCase(Symbol_Table_NameOfPoint(IndexSymbol)))
                    Case "/error"
                        MyDrawText(Where, MyOffset(XYOffSet, CStr(MyUniverse.OptionDisplay(2).X), CStr(MyUniverse.OptionDisplay(2).Y)), SymbolName, 2)
                        MyDrawCircle_At(Where, XYOffSet, "red", LCase(Symbol_TableSymbolName(IndexSymbol)))
                        MyDrawCircle_At(Where, XYOffSet, "red", LCase(Symbol_Table_NameOfPoint(IndexSymbol)))
                    Case Else
                        MyDrawCircle_At(Where, ZeroZero, "red", Symbol_TableCoded_String(IndexSymbol))
                        Exit Sub
                End Select
                IndexSymbol = IndexSymbol + 1
                Application.DoEvents()
            End While

        End Sub

        Public Shared Sub PaintErase(Where As PictureBox, Index As int32)
            MyTrace(143, "PaintErase", 24 - 12)

            MyUniverse.MyMouseAndDrawing.PaintThisOrEraseThis = False
            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    PaintAll(Where, Index, Index)
                Case "SymbolScreen"
                    PaintEach(Where, ZeroZero, SymbolScreen.ToolStripDropDownSelectSymbol.Text, "default")
            End Select
            MyUniverse.MyMouseAndDrawing.PaintThisOrEraseThis = True
        End Sub


        Public Shared Sub ReSetScrollBars(Where As PictureBox, Index As int32)
            Dim A As int32
            Dim T1, T2 As Single
            ' Make this symbol/Path the center of the page
            MyTrace(144, "ReSetScrollBars", 46 - 27)

            T1 = FlowChart_TableX1(Index) + FlowChartScreen.VScrollBar1.Minimum
            T2 = FlowChartScreen.VScrollBar1.Maximum - FlowChartScreen.VScrollBar1.Minimum
            A = CInt(T1 / T2 * (FlowChartScreen.VScrollBar1.Maximum - FlowChartScreen.VScrollBar1.Minimum) / 100)
            FlowChartScreen.VScrollBar1.Value = MyMinMax(A, FlowChartScreen.VScrollBar1.Minimum, FlowChartScreen.VScrollBar1.Maximum)

            T1 = FlowChart_TableY1(Index) + FlowChartScreen.HScrollBar1.Minimum
            T2 = FlowChartScreen.HScrollBar1.Maximum - FlowChartScreen.HScrollBar1.Minimum
            A = CInt(T2 / T1 * (FlowChartScreen.HScrollBar1.Maximum - FlowChartScreen.HScrollBar1.Minimum) / 100)
            FlowChartScreen.HScrollBar1.Value = MyMinMax(A, FlowChartScreen.HScrollBar1.Minimum, FlowChartScreen.HScrollBar1.Maximum)
        End Sub



        'Routine Paint ALL Where is the for, (-) is to erase it
        Public Shared Sub PaintAll(Where As PictureBox, Start As int32, Ending As int32)
            Dim MyXY As MyPointStructure
            Dim IndexFlowChart As int32
            Dim MyRotationName As String
            MyTrace(145, "PaintAll", 832 - 751)

            FindingMyBugs(10) 'hack Least amount of checking here
            Start = MyMinMax(Start, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
            Ending = MyMinMax(Ending, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
            If MyABS(Ending - Start) > 10 Then
                MyMsgCtr("PaintAll", 1032, Start.ToString, Ending.ToString, (Ending - Start).ToString, "", "", "", "", "", "")
            End If
            For IndexFlowChart = Start To Ending
                Select Case LCase(FlowChart_TableCode(IndexFlowChart))
                    Case "/delete"
                        'deleted Text & error text flag
                        MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), CStr(MyUniverse.OptionDisplay(9).X), CStr(MyUniverse.OptionDisplay(9).Y)), FlowChart_TableNamed(IndexFlowChart), 9)
                    Case "/error"
                        'Error Text
                        MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), CStr(MyUniverse.OptionDisplay(9).X), CStr(MyUniverse.OptionDisplay(9).Y)), FlowChart_TableNamed(IndexFlowChart), 9)
                    Case "/use"
                        If InSideMyScreen(Where, MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart))) Then
                            MyRotationName = MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0)
                            DisplayOBject(Where,
                                               MyPoint1(FlowChart_TableX1(IndexFlowChart),
                                               FlowChart_TableY1(IndexFlowChart)),
                                               FlowChart_TableNamed(IndexFlowChart),
                                               MyRotationName)
                            MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), CStr(MyUniverse.OptionDisplay(2).X), CStr(MyUniverse.OptionDisplay(2).Y)), FlowChart_Table_DataType(IndexFlowChart), 2)
                            'input/output
                            MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), CStr(MyUniverse.OptionDisplay(10).X), CStr(MyUniverse.OptionDisplay(10).Y)), FlowChart_TableNamed(IndexFlowChart), 10)


                            'Path Data Values
                            If Len(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)) > 1 Then
                                MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), (MyUniverse.SysGen.constantSymbolCenter * -1).ToString, (-MyUniverse.SysGen.constantSymbolCenter).ToString), FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), 17)
                            End If


                        End If

                    Case "/path"

                        MyDrawLineS_PathS(Where, MyLine1(
                                    MyPoint1(FlowChart_TableX1(IndexFlowChart),
                                          FlowChart_TableY1(IndexFlowChart)),
                                     MyPoint2(FlowChart_TableX2_Rotation(IndexFlowChart),
                                          FlowChart_TableY2_Option(IndexFlowChart))),
                                          FindColorFromDataType(Trim(FlowChart_Table_DataType(IndexFlowChart))),
                                          FindWidthFromDataType(Trim(FlowChart_Table_DataType(IndexFlowChart))))

                        'MyDrawPath(Where, MyLine2(IndexFlowChart, IndexFlowChart), Trim(FlowChart_Table_DataType(IndexFlowChart)))
                        MyDrawPath(Where, MyLine2(IndexFlowChart, IndexFlowChart), FindColorFromDataType(Trim(FlowChart_Table_DataType(IndexFlowChart))))
                        If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(1) = True Then 'path names
                            MyXY.X = CInt((FlowChart_TableX1(IndexFlowChart) + FlowChart_TableX2_Rotation(IndexFlowChart)) / 2)
                            MyXY.Y = CInt((FlowChart_TableY1(IndexFlowChart) + FlowChart_TableY2_Option(IndexFlowChart)) / 2)
                            MyXY = MyOffset(MyXY, CStr(MyUniverse.OptionDisplay(12).X), CStr(MyUniverse.OptionDisplay(12).Y))
                            MyDrawText(Where, MyXY, FlowChart_TableNamed(IndexFlowChart), 1)
                        End If
                    Case "/constant"
                        If InSideMyScreen(Where, MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart))) Then
                            MyDrawCross(Where, MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), FlowChart_Table_DataType(IndexFlowChart), FlowChart_TableNamed(IndexFlowChart))
                            'constants
                            MyDrawText(Where, MyOffset(MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)), CStr(MyUniverse.OptionDisplay(13).X), CStr(MyUniverse.OptionDisplay(13).Y)), FlowChart_Table_DataType(IndexFlowChart), 11)
                        End If
                    Case Nothing
                        MyMsgCtr("PaintAll", 1096, IndexFlowChart.ToString, "", "", "", "", "", "", "", "")
                    Case Else
                        'This should never be drawn
                        MyMsgCtr("PaintAll", 1278, FlowChart_TableCode(IndexFlowChart), "", "", "", "", "", "", "", "")
                        'MyDrawCircle_At(Where, ZeroZero, 0, LCase(Symbol_TableCode(index)))
                End Select
            Next
        End Sub



        Public Shared Function AddCameFromLastLine(ByRef Keyline As String, IndexForInsert As int32, SubLine As int32) As int32 ' returns the number of characters it added to the string
            Dim Temp As String
            Dim K As int32
            MyTrace(146, "AddCameFromLastLine", 61 - 45)

            K = Len(Keyline)
            If SubLine = 0 Then
                Temp = " "
            Else
                Temp = "_" & Trim(Str(SubLine)) & " "
            End If
            If IndexForInsert = 1 Then
                Keyline = ComputerLanguageCameFromLastLine() & Temp & ComputerLanguageMultiLine() & " " & Mid(Keyline, IndexForInsert, Len(Keyline)) '2020 08 20 added space between 
            Else
                Keyline = Mid(Keyline, 1, IndexForInsert) & ComputerLanguageCameFromLastLine() & Temp & ComputerLanguageMultiLine() & " " & Mid(Keyline, IndexForInsert, Len(Keyline))
            End If
            Return Len(Keyline) - K ' cause we always add something
        End Function

        Public Shared Function AddGotoNextLine(ByRef Keyline As String, IndexForInsert As int32, SubLine As int32) As int32 'return the number characters it added to the string
            Dim Temp As String
            Dim K As int32
            MyTrace(147, "AddGotoNextLine", 64 - 46)

            K = Len(Keyline)
            If SubLine = 0 Then
                Temp = " "
            Else
                Temp = "_" & Trim(Str(SubLine)) & " "
            End If
            If IndexForInsert >= Len(Keyline) Then
                Keyline = Keyline & ComputerLanguageMultiLine() & ComputerLanguageGoToNextLine() & Temp
            Else
                Keyline = Mid(Keyline, 1, IndexForInsert - 1) & ComputerLanguageMultiLine() & ComputerLanguageGoToNextLine() & Temp & Mid(Keyline, IndexForInsert, Len(Keyline))
            End If
            Return Len(Keyline) - K
        End Function



        ' Why this and also mytrim() ?????
        Public Shared Function Make_NoWhiteSpace(S As String, WhiteSpaces As String) As String
            Dim I As int32
            Dim Orginal As String
            MyTrace(148, "NoWhiteSpace", 92 - 77)

            Orginal = S
            Make_NoWhiteSpace = Orginal
            While Orginal <> Make_NoWhiteSpace
                Orginal = Make_NoWhiteSpace
                For I = 1 To Len(WhiteSpaces)
                    While Left(Make_NoWhiteSpace, 1) = Mid(WhiteSpaces, I, 1)
                        Make_NoWhiteSpace = Mid(Make_NoWhiteSpace, 2, Len(Make_NoWhiteSpace))
                    End While
                    While Right(Make_NoWhiteSpace, 1) = Mid(WhiteSpaces, I, 1)
                        Make_NoWhiteSpace = Left(Make_NoWhiteSpace, Len(Make_NoWhiteSpace) - 1)
                    End While
                Next I
            End While
        End Function




        Public Shared Function NoWhiteSpaceS(S As String) As String ' Remove all white space to return just a character string (For Filenames etc)
            Dim I, j As int32
            Dim T As String
            MyTrace(149, "NoWhiteSpaceS", 92 - 77)

            T = S
            For j = 1 To Len(S)
                For I = 1 To Len(ConstantDelimeters & MyUniverse.SysGen.ConstantSpecialCharacters)
                    If Mid(S, j, 1) = Mid(ConstantDelimeters & MyUniverse.SysGen.ConstantSpecialCharacters, I, 1) Then
                        Mid(T, j, 1) = " "
                    End If
                Next I
            Next j

            NoWhiteSpaceS = ""
            For j = 1 To Len(Trim(T))
                If Mid(T, j, 1) <> " " Then NoWhiteSpaceS = NoWhiteSpaceS & Mid(T, j, 1)
            Next j
            While ThisIsANumber(Left(NoWhiteSpaceS & "a", 1))
                NoWhiteSpaceS = Mid(NoWhiteSpaceS, 2, Len(NoWhiteSpaceS))
            End While

        End Function


        '***********************************************************************
        'Routine This returns and removes the till the first 'white' space
        ' and returns the string without the whitespace delimiters
        Public Shared Function Pop(ByRef A As String, Delimiters As String) As String ' Returns the first "word" and never the seperating character(s)
            Dim X As String
            MyTrace(151, "Pop", 13)

            A = Trim(A)
            X = Left(A, 1)
            A = Mid(A, 2, Len(A))
            ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
            While InStr(Delimiters, Left(A, 1)) = 0
                X = X + Left(A, 1)
                A = Mid(A, 2, Len(A))
            End While
            Pop = X
            A = Trim(Mid(A, 2, Len(A))) ' to get rid of the character that stopped the pop
        End Function

        '*******************************************************************
        'Routine This returns and removes the till the first 'white' space
        Public Shared Function Pop1(ByRef A As String, Delimiters As String) As String ' Pop the first parsed "word" or special character (See Pop)
            Dim X As String
            MyTrace(152, "Pop1", 13)

            ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
            X = ""
            While InStr(Delimiters, Left(A, 1)) = 0
                X = X + Left(A, 1)
                A = Mid(A, 2, Len(A))
            End While
            If X <> "" Then
                Pop1 = X
            Else
                X = Left(A, 1) ' first character is a delimiters character
                A = Mid(A, 2, Len(A))
                Pop1 = X
            End If
            A = Trim(A) ' Do not get rid of the character that stopped the pop
            Pop1 = Trim(Pop1)
        End Function

        '************************************************************************************
        ' This seperates the string into parts.
        'see ThisIsAWhat()
        'Basiclly it is parsed by trying to find 
        '   first keywords, operators, and other known inputs
        '   second then variable name

        Public Shared Function MyParse(ByRef MyArray() As String, From_What As String) As Int32 ' makes array of parsed atoms from the codeline
            Const Increase As Int32 = 2 ' 20'so I can watch it I set it to 5
            Dim A, B As String
            Dim MyErrors As int32
            'Dim TempKeyWord As String
            MyTrace(153, "MyParse", 63 - 12)

            For MyErrors = LBound(MyArray) To UBound(MyArray)
                MyArray(MyErrors) = Nothing
            Next
            MyErrors = 1024

            A = MyTrim(From_What)
            MyParse = 1 ' because I dont use z(zero) anywhere else

            While Len(A) > 0
                While MyErrors > 1 ' so I have an exit point
                    MyErrors -= 1
                    A = Trim(A)

                    If Len(A) < 1 Then Exit While
                    B = Trim(A) ' so we do not loose anythig in the pop (first special character is lost)
                    B = Pop1(B, ConstantDelimeters & ComputerLanguageMultiLine())
                    If UBound(MyArray) - Increase < MyParse Then
                        MyParse = constantMyErrorCode
                        Exit Function
                    End If

                    ' Need to get all of a marker

                    Select Case ThisIsAWhat(B)
                        Case "ComputerLanguageMultiLine"
                            MyArray(MyParse) = MyArray(MyParse) & B
                            A = Mid(A, 1 + Len(B), Len(A))
                        Case "ComputerLanguageCameFromLastLine"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(ThisIsAWhat(B)))
                        Case "ComputerLanguageComment"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            'A = Mid(A, 2, Len(ThisIsAWhat(B)))
                            A = ComputerLanguageGoToNextLine()
                        Case "ComputerLanguageExtention"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(ThisIsAWhat(B)))
                        Case "ComputerLanguageGoToNextLine"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(ThisIsAWhat(B)))
                        Case "ComputerLanguageMultiLine"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(ThisIsAWhat(B)))
                        Case "ComputerLanguageVariableNameCharacters"
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(ThisIsAWhat(B)))

                        Case "CameFromLastLine"
                            A = Trim(A)
                            B = Trim(A)
                            B = Pop1(B, ConstantDelimeters)
                            If ThisIsAMarker(B) > 0 Then
                                MyArray(MyParse) = Trim(B)
                            Else
                                MyArray(MyParse) = Trim(B)
                            End If
                            A = Trim(Mid(Trim(A), Len(B) + 1, Len(A))) 'remove B From A
                        Case "GotoNextLine"
                            A = Trim(A)
                            B = Trim(A)
                            B = Pop1(B, ConstantDelimeters)
                            If ThisIsAMarker(B) > 0 Then
                                MyArray(MyParse) = Trim(B)
                            Else
                                MyArray(MyParse) = Trim(B)
                            End If
                            A = Trim(Mid(Trim(A), Len(B) + 1, Len(A))) 'remove B From A
                        Case "Quote"
                            ' Save The First Quote
                            MyArray(MyParse) = Left(A, 1) : A = Mid(A, 2, Len(A))
                            While Left(A, 1) <> Trim(MyUniverse.SysGen.ConstantQuote) And Len(A) > 0
                                MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                                A = Mid(A, 2, Len(A))
                            End While
                            ' Save The Last Quote also
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(A))
                        Case "comment"
                            MyArray(MyParse) = Trim(A)
                            A = "" ' everything afterwards is considered part of the comment
                            A = ComputerLanguageGoToNextLine()' Except that we have to goto the next line 
                        Case "KeyWord", "Operator", "Function"
                            A = Trim(A)
                            B = Trim(A) ' so we do not loose anythig in the pop (first special character is lost)
                            B = Pop1(B, ConstantDelimeters)
                            If ThisIsAMarker(B) > 0 Then
                                MyArray(MyParse) = Trim(B)
                            Else
                                MyArray(MyParse) = Trim(B)
                            End If
                            A = Trim(Mid(Trim(A), Len(B) + 1, Len(A))) 'remove B From A
                        Case "Alpha"
                            While ThisIsAnAlpha(A)
                                MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                                A = Mid(A, 2, Len(A))
                            End While
                        Case "Number"
                            If ThisIsAMarker(A) > 0 Then
                                MyArray(MyParse) = Trim(Left(A, ThisIsAMarker(A) + 1))
                                A = Mid(A, ThisIsAMarker(A) + 1, Len(A))
                            Else
                                While ThisIsANumber(A)
                                    MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                                    A = Mid(A, 2, Len(A))
                                End While
                            End If
                        Case "SpecialCharacter"
                            While ThisIsASpecalCharacter(A) And Len(A) > 0
                                MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                                A = Mid(A, 2, Len(A))
                            End While
                        Case "Variable"
                            While ThisIsAVariableName(A)
                                MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                                A = Mid(A, 2, Len(A))
                            End While
                        Case "Unknown"
                            Abug(789, "unknown Character Clasifacition", A, ThisIsAWhat(A))
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(A))
                        Case Else
                            Abug(929, "program problem", "Did not take care of a ThisIsAWhat()", ThisIsAWhat(A))
                            MyArray(MyParse) = MyArray(MyParse) & Left(A, 1)
                            A = Mid(A, 2, Len(A))
                    End Select
                    MyParse = MyParse + 1
                End While
            End While
        End Function

        '***********************************************************************
        'Test if imbedded mark
        Public Shared Function ThisIsAGotoNextLine(CodeLine As String) As Boolean
            MyTrace(154, "ThisIsAGotoNextLine", 5)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantGoToNextLineSyntax)) = MyUniverse.SysGen.ConstantGoToNextLineSyntax Then Return True
            Return False
        End Function
        '***********************************************************************
        'Test if imbedded mark
        Public Shared Function ThisIsACameFromLastLine(CodeLine As String) As Boolean
            MyTrace(155, "ThisIsACameFromLastLine", 5)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantCameFromLastLineSyntax)) = MyUniverse.SysGen.ConstantCameFromLastLineSyntax Then Return True
            Return False
        End Function

        '***************************************************************
        'This determines what part of the code string is:
        ' A inputed language keyword
        ' A inputed language operator
        ' A inputed language function name
        ' A quote or comment
        ' and then a number, an alpha, or a variable name or special namings

        'ie:
        ' a=b & "that"  
        ' gives the symtax of 
        ' variablemarkder specialmarker variablemarkder specialmarker quotemarker

        Public Shared Function ThisIsAWhat(CodeLine As String) As String
            Dim X As String
            MyTrace(156, "ThisisAWhat()", 43 - 19)
            If IsNothing(CodeLine) Then Return Nothing
            If CodeLine = "" Then Return ""

            If ThisIsAGotoNextLine(CodeLine) Then Return "GotoNextLine"
            If ThisIsACameFromLastLine(CodeLine) Then Return "CameFromLastLine"
            If ThisIsAQuote(CodeLine) Then Return "Quote"
            If ThisIsAComment(CodeLine) Then Return "Comment"
            If ThisIsA_KeyWord(CodeLine) Then Return "KeyWord"
            If ThisIsA_Function(CodeLine) Then Return "Function"
            If ThisIsA_Operator(CodeLine) Then Return "Operator"
            If ThisIsANumber(CodeLine) Then Return "Number" 'number is alway a variable(Need to add option to over ride, and a mnemonic)
            If ThisIsAnAlpha(CodeLine) Then Return "Alpha" 'Alpha is always a variable (Need to add an option to over ride, and also a mnemonic)
            If ThisIsAVariableName(CodeLine) Then Return "Variable"

            X = ComputerLanguageMultiLine() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageMultiLine"
            X = ComputerLanguageCameFromLastLine() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageCameFromLastLine"
            X = ComputerLanguageComment() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageComment"
            X = ComputerLanguageExtention() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageExtention"
            X = ComputerLanguageGoToNextLine() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageGoToNextLine"
            X = ComputerLanguageMultiLine() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageMultiLine"
            X = ComputerLanguageVariableNameCharacters() : If Left(CodeLine, Len(X)) = X Then Return "ComputerLanguageVariableNameCharacters"

            If ThisIsAMarker(CodeLine) > 0 Then Return "variable" ' this will return if it is a  myuniverse.sysgen.rmstart & point.name & myuniverse.sysgen.rmEnd  format which is a variable
            If ThisIsAMarker2(CodeLine) > 0 Then Return "variable"
            If ThisIsASpecalCharacter(CodeLine) Then Return "SpecialCharacter"



            Return "Unknown"

        End Function


        '***********************************************************************
        'Test if imbedded mark is a start of a comment
        Public Shared Function ThisIsAComment(CodeLine As String) As Boolean
            MyTrace(157, "ThisIsAComment", 9)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantComment)) = MyUniverse.SysGen.ConstantComment Then Return True
            If CodeLine = ComputerLanguageComment() Then
                Return True
            End If
            If ThisIsAMarker(CodeLine) > 0 Then Return False
            Return False
        End Function



        '***********************************************************************
        'Test if the string is all digits
        Public Shared Function ThisIsANumber(CodeLine As String) As Boolean
            MyTrace(158, "ThisIsANumber", 7)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantNumber)) = MyUniverse.SysGen.ConstantNumber Then Return True
            If ThisIsAMarker(CodeLine) > 0 Then Return False
            If Left(CodeLine, 1) >= "0" And Left(CodeLine, 1) <= "9" Then Return True
            Return False
        End Function

        '***********************************************************************
        'Test if the string is all alapha characters
        Public Shared Function ThisIsAnAlpha(CodeLine As String) As Boolean
            MyTrace(159, "ThisIsAnAlpha", 9)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantAlpha)) = MyUniverse.SysGen.ConstantAlpha Then Return True
            If ThisIsAMarker(CodeLine) > 0 Then Return False 'any other marker
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantAlpha)) = MyUniverse.SysGen.ConstantAlpha Then Return True
            If Left(CodeLine, 1) >= "A" And Left(CodeLine, 1) <= "Z" Then Return True
            If Left(CodeLine, 1) >= "a" And Left(CodeLine, 1) <= "z" Then Return True
            Return False
        End Function


        '***********************************************************************
        'Test if the string is special character mark
        Public Shared Function ThisIsASpecalCharacter(CodeLine As String) As Boolean
            ' First test if it a marker
            MyTrace(161, "ThisIsASpecalCharacter", 87 - 70)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantSpecialCharacter)) = MyUniverse.SysGen.ConstantSpecialCharacter Then Return True
            If ThisIsAMarker(CodeLine) > 0 Then Return False
            If ThisIsAVariableName(CodeLine) = True Then Return False ' if it is a variable name (including special characters for this language

            'make sure that special characters for this language for this variable is not included
            Select Case Left(CodeLine, 1)
                Case "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "[", "}", "]", "|", "", ":", ";", Chr(34), "'", "<", ",", ">", ".", "?", "/"
                    'Case "=", "+", "-", "/", "*", "<", ">", "(", ")", "[", "]", "{", "}", "&", ".", ",", ";", "_", "$"
                    Return True
                Case vbCr, vbLf, vbTab, ConstantWhiteSpace
                    Return True
                Case FD
                    Return True
                Case Else
                    Return False
            End Select
        End Function

        '***********************************************************************
        'Test if imbedded mark for a quote
        Public Shared Function ThisIsAQuote(CodeLine As String) As Boolean ' returns is this is the start of a quote
            MyTrace(162, "ThisIsAQuote", 9)

            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantQuotes)) = MyUniverse.SysGen.ConstantQuotes Then Return True
            If Left(Trim(CodeLine), 1) = Trim(MyUniverse.SysGen.ConstantQuote) Then Return True
            If ThisIsAMarker(CodeLine) > 0 Then Return False ' casue its not quotes
            Return False
        End Function


        '***********************************************************************
        ' We are still not finding it in the list even tho it is there (Found with a loop through them all

        Public Shared Function ThisIsA_KeyWord(CodeLine As String) As Boolean ' returns is this is in the keyword list (ignores markers)
            Dim I As int32
            Dim A, B As String
            MyTrace(163, "ThisIsAKeyWord", 77 - 66)

            ThisIsA_KeyWord = False
            A = CodeLine
            B = A
            B = Trim(Pop1(B, ConstantWhiteSpace))  ' Trim(Pop1(B, ConstantDelimeters))
            If IsNothing(B) Or B = "" Then Exit Function
            I = FindInSortedLanguageList("Keyword", B, Language_KeyWords)
            If I > UBound(Language_KeyWords) Then
                Abug(999, "Index returnd outside of array size " & I, UBound(Language_KeyWords), 0)
            End If
            If I <> constantMyErrorCode Then
                If Language_KeyWords(I) = B Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' Else we have to search it item by item (and resort it also
            For I = 1 To UBound(Language_KeyWords)
                If LCase(B) = LCase(Language_KeyWords(I)) Then
                    Abug(647, "(This is a function(): find in sorted language list() failed to find an existing word", B, "Found at " & I)
                    Return True
                End If
            Next
            Return False
        End Function

        '***********************************************************************
        'Test if this is in the inputed keywords list
        Public Shared Function ThisIsA_Function(CodeLine As String) As Boolean ' returns is this is in the keyword list (ignores markers)
            Dim I As int32
            Dim A, B As String
            MyTrace(164, "ThisIsAKeyWord", 77 - 66)

            A = CodeLine
            B = A
            'B = Trim(Pop1(B, ConstantDelimeters & " " & "(){}[]!@#$%^&*-+*+/\:;.^")) ' to get just one word
            B = Trim(Pop1(B, ConstantWhiteSpace)) ' Trim(Pop1(B, ConstantDelimeters & " " & "(){}[]!@#$%^&*-+*+/\:;.")) ' to get just one word
            If IsNothing(B) Or B = "" Then Return False
            ' Hardcoded for now all keywords I can think of untill I put it in a /Keyword,language,Keywords
            I = FindInSortedLanguageList("Function", B, Language_Functions)
            If I <> constantMyErrorCode Then
                If Language_Functions(I) = B Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' Else we have to search it item by item (and resort it also
            For I = 1 To UBound(Language_Functions)
                If LCase(B) = LCase(Language_Functions(I)) Then
                    Abug(646, "(This is a function(): find in sorted language list() failed to find an existing word", B, "Found at " & I)
                    Return True
                End If
            Next
            If ThisIsAMarker(CodeLine) > 0 Then Return False
            Return False
        End Function

        '***********************************************************************
        'Test if this is in the inputed operator list
        Public Shared Function ThisIsA_Operator(CodeLine As String) As Boolean ' returns is this is in the keyword list (ignores markers)
            Dim I As Int32
            Dim A, B As String
            MyTrace(165, "ThisIsAKeyWord", 77 - 66)

            A = CodeLine
            B = A
            'B = Trim(Pop1(B, ConstantDelimeters & " " & "(){}[]!@#$%^&*-+*+/\:;.^")) ' to get just one word
            B = Trim(Pop1(B, ConstantWhiteSpace)) ' Trim(Pop1(B, ConstantDelimeters & " " & "(){}[]!@#$%^&*-+*+/\:;.")) ' to get just one word
            If IsNothing(B) Or B = "" Then Return False
            ' Hardcoded for now all keywords I can think of untill I put it in a /Keyword,language,Keywords

            I = FindInSortedLanguageList("Operator", B, Language_Operators)
            If I <> constantMyErrorCode Then
                If Language_Operators(I) = B Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' Else we have to search it item by item (and resort it also
            For I = 1 To UBound(Language_Operators)
                If LCase(B) = LCase(Language_Operators(I)) Then
                    Abug(645, "(This is a function(): find in sorted language list() failed to find an existing word", B, "Found at " & I)
                    Return True
                End If
            Next
            If ThisIsAMarker(CodeLine) > 0 Then Return False
            Return False ' Not an operator
        End Function

        '***********************************************************************
        'Test if imbedded mark for a variable name
        Public Shared Function ThisIsAVariableName(Codeline As String) As Boolean
            Dim C As String
            Dim I As int32
            MyTrace(166, "ThisIsAVariableName", 94 - 81)

            If Left(Codeline, Len(MyUniverse.SysGen.ConstantVariable)) = MyUniverse.SysGen.ConstantVariable Then Return True
            If ThisIsAMarker(Codeline) > 0 Then Return False
            If Len(Codeline) = 0 Then Return False
            C = Left(Codeline, 1)
            If ThisIsAnAlpha(C) Then Return True
            If ThisIsANumber(C) Then Return True
            C = ComputerLanguageVariableNameCharacters()

            For I = 1 To Len(C)
                If Left(Codeline, 1) = Mid(C, I, 1) Then
                    Return True
                End If
            Next

            Return False
        End Function


        '***********************************************************************
        'returns the length of the marker (if any)
        ' returns zero if not a marker
        Public Shared Function ThisIsAMarker(CodeLine As String) As Int32 ' this returns the length of the marker (Which is always 3, excepte for one case, and if it changes in the future)
            Dim X As String
            MyTrace(167, "ThisIsAMarker", 43 - 22)

            If CodeLine = "" Then Return 0
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantQuotes)) = MyUniverse.SysGen.ConstantQuotes Then Return Len(MyUniverse.SysGen.ConstantQuotes)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantVariable)) = MyUniverse.SysGen.ConstantVariable Then Return Len(MyUniverse.SysGen.ConstantVariable)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantNumber)) = MyUniverse.SysGen.ConstantNumber Then Return Len(MyUniverse.SysGen.ConstantNumber)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantAlpha)) = MyUniverse.SysGen.ConstantAlpha Then Return Len(MyUniverse.SysGen.ConstantAlpha)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantGoToNextLineSyntax)) = MyUniverse.SysGen.ConstantGoToNextLineSyntax Then Return Len(MyUniverse.SysGen.ConstantGoToNextLineSyntax)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantCameFromLastLineSyntax)) = MyUniverse.SysGen.ConstantCameFromLastLineSyntax Then Return Len(MyUniverse.SysGen.ConstantCameFromLastLineSyntax)
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantComment)) = MyUniverse.SysGen.ConstantComment Then Return Len(MyUniverse.SysGen.ConstantComment)
            X = ComputerLanguageMultiLine() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageCameFromLastLine() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageComment() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageExtention() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageGoToNextLine() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageMultiLine() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            X = ComputerLanguageVariableNameCharacters() : If Left(CodeLine, Len(X)) = X Then Return Len(X)
            If ThisIsAMarker2(CodeLine) > 0 Then Return ThisIsAMarker2(CodeLine) ' Returns the length of this marker format myuniverse.sysgen.rmstart & point.name & myuniverse.sysgen.rmEnd

            ' All special characters are after language special characters
            If Left(CodeLine, Len(MyUniverse.SysGen.ConstantSpecialCharacter)) = MyUniverse.SysGen.ConstantSpecialCharacter Then Return Len(MyUniverse.SysGen.ConstantSpecialCharacter)

            Return 0 ' Not a marker but might still be one of this kind
        End Function



        '*******************************************************************
        'This will return the variable if in the form variable.variable 
        'This has not be verified to work
        Public Shared Function ThisIsAMarker2(CodeLine As String) As Int32 ' this will return the variable if in formation [variable.option]
            Dim X As String
            Dim I As Int32
            MyTrace(437, "ThisIsAMarker2", 60 - 40)
            X = CodeLine
            If Left(X, Len(MyUniverse.SysGen.RMStart)) = MyUniverse.SysGen.RMStart Then
                X = Mid(X, Len(MyUniverse.SysGen.RMStart) + 1, Len(X))
                If ThisIsAVariableName(X) Then
                    X = Pop(X, ".")
                    If Left(X, 1) = "." Then
                        I = InStr(X & myuniverse.sysgen.rmEnd, myuniverse.sysgen.rmEnd)
                        X = Mid(X, Len(MyUniverse.SysGen.RMStart), Len(X))
                        If ThisIsAVariableName(X) Then
                            ' This should chane to be x = mid(codeline,instr(x,myuniverse.sysgen.rmEnd),len(codeline)
                            X = Pop(X, myuniverse.sysgen.rmEnd)
                            Return Len(CodeLine) - Len(X)
                        End If
                    End If
                End If
            End If
            Return 0
        End Function




        '***********************************************************************
        'Routine This returns and removes till a carriage return or Line Feed
        Public Shared Function PopLine(ByRef A As String) As String ' Return up to the first CRLF, CR or LF
            Dim B As String
            MyTrace(168, "PopLine", 11)

            PopLine = Left(A, 1)
            A = Mid(A, 2)
            B = Left(A & Chr(10), 1)
            While Len(A) >= 1 And B <> vbCr And B <> vbCrLf And B <> vbLf 'B > Chr(16) And '
                PopLine = PopLine + Left(A, 1)
                A = Mid(A, 2)
                B = Left(A & Chr(10), 1)
            End While
        End Function



        Public Shared Function My_INT(Text As String) As Int32 ' Cint() ignore all first ,'s.
            Dim Sign As Int32
            Dim Temp As String
            Temp = Text
            If Left(Temp, Len(FD)) = FD Then
                Temp = Mid(Temp, 2, Len(Temp))
            End If
            Sign = 1
            My_INT = 0
            While Len(Temp) > 0
                Select Case Left(Temp, 1)

                    Case "-"
                        Sign = -1
                    Case "0"
                        My_INT = My_INT * 10 + 0
                    Case "1"
                        My_INT = My_INT * 10 + 1
                    Case "2"
                        My_INT = My_INT * 10 + 2
                    Case "3"
                        My_INT = My_INT * 10 + 3
                    Case "4"
                        My_INT = My_INT * 10 + 4
                    Case "5"
                        My_INT = My_INT * 10 + 5
                    Case "6"
                        My_INT = My_INT * 10 + 6
                    Case "7"
                        My_INT = My_INT * 10 + 7
                    Case "8"
                        My_INT = My_INT * 10 + 8
                    Case "9"
                        My_INT = My_INT * 10 + 9
                    Case ","
                        Exit Function
                    Case Else
                        My_INT = My_INT 'This should never happen 
                End Select
                Temp = Mid(Temp, 2, Len(Temp))
            End While
        End Function




        '***********************************************************************
        'Routine This returns and removes all numbers before 'white' space
        Public Shared Function PopValue(ByRef A As String) As Int32 ' Returns a number from the string My_Int() & Value()
            Dim Xstring As String
            Dim Ystring As String
            Dim Sign, Multiplyer As Integer
            MyTrace(169, "PopValue", 29 - 11)

            Sign = 1 ' final sign of the number
            Multiplyer = 10 ' stops when there is a period .
            PopValue = 0
            A = MyTrim(A)
            Xstring = ""
            Ystring = " "
            ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
            While Len(Xstring) < 8 And (Ystring >= "0" And Ystring <= "9") Or Ystring = " " Or Ystring = "-"
                Xstring = Xstring + Ystring
                Select Case Ystring
                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        PopValue = PopValue * Multiplyer + My_Int(Ystring)
                    Case "."
                        Multiplyer = 1
                    Case "-"
                        Sign = -1
                End Select
                Ystring = Left$(A, 1)
                If Len(A) > 0 Then A = Mid(A, 2, Len(A))
            End While
            'flow10''''''' Change to get the value character by character ''''''''
            '  Popvalue = My_Int(Trim(Xstring) & ".0")
        End Function


        '***********************************************************************
        'Returns the whole list of this record
        Public Shared Function MyUnEnum(Number As Int32, MyCombobox As ToolStripDropDownButton, ItemNumberOffset As Int32) As String
            Dim I As Int32, Temp As String
            Dim Count As Int32
            Static LastCombox, LastUnEnum, LastResults(20) As String
            MyTrace(171, "MyUnEnum", 46 - 35)

            Count = MyCombobox.DropDownItems.Count
            MyUnEnum = ""
            If Number = constantMyErrorCode Then
                Abug(928, "Error code is invalid index into the combobox" & MyCombobox.Name, Number, ItemNumberOffset)
                MyUnEnum = ""
                MyMsgCtr("MyUnEnum", 1024, MyCombobox.Name, Number.ToString, ItemNumberOffset.ToString, "", "", "", "", "", "")
                Exit Function
            End If
            ' Test if this is a number and not a Indexes to the combobox
            If Number > Count - 1 Then
                Abug(928, "The index is bigger than the combobox list in " & MyCombobox.Name & " at " & Number, MyCombobox.DropDownItems.Count, ItemNumberOffset)
                MyUnEnum = CStr(Number)
                Exit Function
            End If
            Temp = MyCombobox.DropDownItems.Item(MyMinMax(Number, 0, Count - 1)).ToString ' Should this allow combobox.items(0)?????
            If MyCombobox.Name = LastCombox Then
                If Temp = LastUnEnum Then
                    If LastResults(ItemNumberOffset) <> Nothing Then
                        MyUnEnum = LastResults(ItemNumberOffset)
                        Exit Function
                    End If
                End If
            Else
                ReDim LastResults(20) ' get rid of everything
            End If

            LastCombox = MyCombobox.Name
            LastUnEnum = Temp
            For I = 0 To ItemNumberOffset
                Temp = Trim(Temp)
                MyUnEnum = Pop(Temp, FD)
                LastResults(I) = MyUnEnum
            Next I
        End Function

        '***********************************************************************
        'converts from a number into the cap start/end type
        'This is erroring out, and not reutnr a valid type of data for this
        Public Shared Function MyCapCode(Anumber As Int32) As Drawing2D.LineCap
            Select Case Anumber
                Case 1
                    Return Drawing2D.LineCap.AnchorMask
                Case 2
                    Return Drawing2D.LineCap.ArrowAnchor
                Case 3
                    Return Drawing2D.LineCap.DiamondAnchor
                Case 4
                    Return Drawing2D.LineCap.Flat
                Case 5
                    Return Drawing2D.LineCap.NoAnchor
                Case 6
                    Return Drawing2D.LineCap.Round
                Case 7
                    Return Drawing2D.LineCap.RoundAnchor
                Case 8
                    Return Drawing2D.LineCap.Square
                Case 9
                    Return Drawing2D.LineCap.SquareAnchor
                Case 10
                    Return Drawing2D.LineCap.Triangle
                Case Else
                    Return Drawing2D.LineCap.AnchorMask 'if cant / dont know what it is 
            End Select
        End Function


        '***********************************************************************
        'Returns the number of the first item in this number
        Public Shared Function MyEnumValue(Whatstring As String, MyComboBox As ToolStripDropDownButton) As Int32
            Static Last_WhatString As String = Nothing
            Static Last_ComboBox As String = Nothing
            Static Last_MyEnum As Int32 = -1
            Dim I As Int32, Low, Idex, Jdex, Kdex, ErrorKounter As Int32
            Dim SearchingFor As String
            Dim Count As Int32
            MyTrace(172, "MyEnumValue", 127 - 50)


            If Last_ComboBox = MyComboBox.Name Then ' same as last 
                If Last_WhatString = Whatstring Then
                    Return Last_MyEnum ' return shortcut
                End If
            End If

            Count = MyComboBox.DropDownItems.Count
            If Count < 1 Then Return 0
            Low = 0
            Kdex = Count - 1
            SearchingFor = MyTrim(Whatstring)
            If SearchingFor = "" Or SearchingFor = " " Then
                Abug(927, "MyEnumValue():", "Can not find an empty String in the list ", 0)
                Last_ComboBox = MyComboBox.Name
                Last_WhatString = Whatstring
                Last_MyEnum = constantMyErrorCode
                MyEnumValue = constantMyErrorCode
                Exit Function
            End If

            'Lets try a binary search first
            Kdex = Count - 1
            Idex = MyMinMax(CInt(Kdex / 2), Low, Kdex)
            Jdex = MyMinMax(CInt(Idex / 2), Low, Kdex)
            ErrorKounter = -(Count + 8) ' Try to find it eight times to many
            'Temp = MyComboBox.Items.Item(Idex).ToString 'hack
            'Temp = Trim(Pop(MyComboBox.Items.Item(Idex).ToString, ConstantDelimeters)) 'hack
            I = MyCompared1_a(SearchingFor, Trim(Pop(MyComboBox.DropDownItems.Item(Idex).ToString, ConstantDelimeters)))
            While I <> 0
                ErrorKounter += 1
                If ErrorKounter + 2 > Count Then
                    'Abug(, 0, 0, 0)  'This Is Not always an Error since, I look For things In a list And If Not found Then Do something Else
                    ' Not found and searched almost for ever.
                    Last_ComboBox = MyComboBox.Name
                    Last_WhatString = Whatstring
                    Last_MyEnum = Nothing
                    MyEnumValue = Nothing
                    GoTo FailedBinarySearch
                End If
                If I < 0 Then
                    Idex = MyMinMax(Idex - Jdex, Low, Kdex)
                Else
                    Idex = MyMinMax(Idex + Jdex, Low, Kdex)
                End If
                Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
                'Temp = MyComboBox.Items.Item(Idex).ToString 'hack
                'Temp = Trim(Pop(MyComboBox.Items.Item(Idex).ToString, ConstantDelimeters)) 'hack
                I = MyCompared1_a(SearchingFor, Trim(Pop(MyComboBox.DropDownItems.Item(Idex).ToString, ConstantDelimeters)))
            End While
            Last_ComboBox = MyComboBox.Name
            Last_WhatString = Whatstring
            Last_MyEnum = Idex
            MyEnumValue = Idex
            Exit Function


            ' The above should replace the below, but should add an excape incase it's not in the List to avoid a forever loop
FailedBinarySearch:
            SearchingFor = MyTrim(Whatstring)
            If SearchingFor = "" Or SearchingFor = " " Then
                Abug(926, "MyEnumValue", 0, 2)
                Last_ComboBox = MyComboBox.Name
                Last_WhatString = Whatstring
                Last_MyEnum = constantMyErrorCode
                MyEnumValue = constantMyErrorCode
                Exit Function
            End If
            Last_ComboBox = MyComboBox.Name
            Last_WhatString = Whatstring
            Last_MyEnum = Nothing
            MyEnumValue = Nothing
        End Function


        '***********************************************************************
        'swaps the array (assumed no key
        Public Shared Sub Swap(ByRef MyTable As String, MyArray() As Int32, A As Int32, B As Int32) ' Swap the two numbers
            Dim Temp As Int32
            MyTrace(173, "Swap", 42 - 36)
            Temp = MyArray(A)
            MyArray(A) = MyArray(B)
            MyArray(B) = Temp
        End Sub

        '***********************************************************************
        'swap the two numbers 
        ' It looks lik it does not return the swapped values?
        ' Why is A & B not by REF ?
        Public Shared Sub Swap(ByRef MyTable As String, A As int32, B As int32) ' Swap the two numbers
            Dim Temp As int32
            MyTrace(174, "Swap", 42 - 36)
            Temp = A
            A = B
            B = Temp
        End Sub



        'Routine  changes places between two string locations in an MyArray
        Public Shared Sub Swap(ByRef MyTable As String, ByRef MyArray() As String, A As int32, B As int32) ' Swap the two items in the myArray
            Dim TempA As String
            MyTrace(175, "Swap", 57 - 47)
            TempA = MyArray(A)
            MyArray(A) = MyArray(B)
            MyArray(B) = TempA
        End Sub

        '***********************************************************************
        ' Swaps the two places of the keywords array (Sorting them to keep them in order, should look into an insert sort method)
        Public Shared Sub SwapLanguageKeyWords(ByRef MyTable As String, ByRef MyArray() As String, A As int32, B As int32)
            Dim T As String
            MyTrace(176, "SwapLanguageKeyWords", 47 - 32)

            If A < 0 Then Exit Sub
            If B < 0 Then Exit Sub
            If A > UBound(MyArray) Then Exit Sub
            If B > UBound(MyArray) Then Exit Sub
            T = MyArray(A)
            MyArray(A) = MyArray(B)
            MyArray(B) = T
            T = MyArray(B) 'hack
        End Sub

        Public Shared Sub SwapBytes(ByRef MyTable As String, MyArray() As Byte, A As int32, B As int32)
            Dim TempA As Byte
            Dim TempB As Byte
            MyTrace(177, "SwapBytes", 69 - 60)

            'Should have an error message out here. and not swap anything (better yet, test it before it gets here)
            If MyMinMax(A, 1, UBound(MyArray) - 1) <> A Then Exit Sub
            If MyMinMax(B, 1, UBound(MyArray) - 1) <> B Then Exit Sub
            TempB = MyArray(B) : TempA = MyArray(A)
            MyArray(A) = TempB : MyArray(B) = TempA
        End Sub



        'Routine changes places between two number locations in a number MyArray
        Public Shared Sub SwapN(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32, A As int32, B As int32)
            Dim TempA As int32
            MyTrace(178, "SwapN", 94 - 74)

            ' Just to make sure that it is always valid

            If MyMinMax(A, 1, UBound(iSAM) - 1) <> A Then
                Abug(999, "Index outside of array ", A, B)
                Exit Sub
            End If
            If MyMinMax(B, 1, UBound(iSAM) - 1) <> B Then
                Abug(999, "Index outside of array", B, A)
                Exit Sub
            End If
            TempA = iSAM(A)
            iSAM(A) = iSAM(B)
            iSAM(B) = TempA
        End Sub



        'Routine changes places between two number locations in a number MyArray
        Public Shared Sub SwapNn(ByRef MyTable As String, MyArray() As int32, ByRef iSAM() As int32, A As int32, B As int32)
            Dim TempA As int32
            MyTrace(179, "SwapNn", 19 - 2)

            ' Just to make sure that it is always valid
            If MyMinMax(A, 1, UBound(iSAM) - 1) <> A Then
                Exit Sub
            End If
            If MyMinMax(B, 1, UBound(iSAM) - 1) <> B Then
                MyMsgCtr("swapn", 1437, "1", A.ToString, UBound(iSAM).ToString, "", "", "", "", "", "")
                Exit Sub
            End If
            TempA = iSAM(A)
            iSAM(A) = iSAM(B)
            iSAM(B) = TempA
        End Sub


        Public Shared Sub ReSortSymbolList() ' Used only in decompileline
            Dim I, IndexSymbol As int32
            MyTrace(181, "ReSortSymbolList", 7631 - 7608)

            For IndexSymbol = 2 To TopOfFile("Symbol", Symbol_FileCoded)
                I = IndexSymbol
                While Symbol_FileCoded(I) = MyKeyword_2_Byte("/name") ' Moving /name to the top of the list
                    While Symbol_FileSymbolName(I - 1) = Symbol_FileSymbolName(I) ' A point name is before the symbol name
                        ' Should never get here, if we do its a program bug
                        'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 04
                        SwapSymbolList(IndexSymbol, IndexSymbol + 1)
                        'FindingMyBugs(10)'hack Least amount of checking here 'hack 2020 08 04
                        I -= 1
                    End While
                    I -= 1
                End While
                I = IndexSymbol
                While Symbol_FileCoded(I) = MyKeyword_2_Byte("/name") And Symbol_FileCoded(I - 1) = MyKeyword_2_Byte("/name") And Symbol_FileSymbolName(I - 1) = Symbol_FileSymbolName(I)
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                    SwapSymbolList(IndexSymbol, IndexSymbol + 1)
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                    I -= 1
                End While
            Next
        End Sub



        'Routine swaps in all symbol MyArrays two locations
        Public Shared Sub SwapSymbolList(A As int32, B As int32) ' With one higher ' inserting records in a non-index-file
            MyTrace(182, "SwapSymbolList", 36 - 24)

            MyMakeArraySizesBigger()
            If InvalidIndex(A, Symbol_FileSymbolName) Or InvalidIndex(B, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            'MyMsgCtr("SwapSymbolList", 1051, Symbol_TableSymbolName(A), Symbol_TableSymbolName(B), A, B, "", "", "", "", "")
            SwapBytes("Symbol", Symbol_FileCoded, A, B)
            Swap("Symbol", Symbol_File_NameOfPoint, A, B)
            Swap("Symbol", Symbol_FileSymbolName, A, B)
            Swap("Symbol", Symbol_FileX1, A, B)
            Swap("Symbol", Symbol_FileY1, A, B)
            Swap("Symbol", Symbol_FileX2_io, A, B)
            Swap("Symbol", Symbol_FileY2_dt, A, B)
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
        End Sub



        '***********************************************************************
        'Routine returns from 'real' world to screen scale
        Public Shared Function ScaledSize(MyNumber As Int32) As Int32 'single
            MyTrace(183, "ScaledSize", 4)
            ScaledSize = CInt(MyNumber * MyUniverse.SysGen.MyScale)
        End Function

        '***********************************************************************
        'moves the x & y to the grid
        Public Shared Function SnapXY(XY As MyPointStructure) As MyPointStructure
            MyTrace(184, "SnapXY", 5)

            SnapXY.X = Snap(XY.X)
            SnapXY.Y = Snap(XY.Y)
        End Function

        '***********************************************************************
        'Move the point to the grid
        Public Shared Function Snap(XY As int32) As int32
            MyTrace(185, "Snap", 5)
            If MyUniverse.SysGen.MySnap = 0 Then MyUniverse.SysGen.MySnap = 50
            Snap = CInt(XY / MyUniverse.SysGen.MySnap) * MyUniverse.SysGen.MySnap
        End Function

        Public Shared Function MakePathOrthogonal(IndexFlowChart As int32) As Boolean ' returns if changed the line
            Dim DX, DY, RecordNumber As int32
            MyTrace(186, "MakePathOrthogonal", 80 - 65)

            MakePathOrthogonal = False ' Didn't change anything
            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(14) = False Then Exit Function 'Orthogonal paths
            '            MyMsgCtr("MakePathOrthogonal", 1296, "", "", "", "", "", "", "", "", "")
            ' Need to make sure this is a path first

            If FlowChart_TableCode(IndexFlowChart) <> "/path" Then
                Exit Function ' this is not a path to beable to change
            End If

            'It's check so make this rect Orthogonal 
            ' Get the distances between the two points on the line
            DX = MyABS(FlowChart_TableX1(IndexFlowChart) - FlowChart_TableX2_Rotation(IndexFlowChart))
            DY = MyABS(FlowChart_TableY1(IndexFlowChart) - FlowChart_TableY2_Option(IndexFlowChart))
            If DX = 0 Or DY = 0 Then Exit Function ' The X or Y is already stright up/down OR level right/left
            RecordNumber = InsertFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded),
                                                 FlowChart_TableNamed(IndexFlowChart),
                                                 "/path",
                                                 MyPoint1(FlowChart_TableX1(IndexFlowChart), FlowChart_TableY1(IndexFlowChart)),
                                                 MyPoint2(FlowChart_TableX2_Rotation(IndexFlowChart), FlowChart_TableY2_Option(IndexFlowChart)),
                                                 FlowChart_Table_DataType(IndexFlowChart))
            MyMakeArraySizesBigger()
            PaintAll(FlowChartScreen.PictureBox1, IndexFlowChart, IndexFlowChart) : PaintAll(FlowChartScreen.PictureBox1, RecordNumber, RecordNumber)
            If DX >= DY Then
                DX = FlowChart_TableX1(IndexFlowChart)
                DY = FlowChart_TableY2_Option(IndexFlowChart)
                FlowChart_TableX1(RecordNumber, DX)
                FlowChart_TableY1(RecordNumber, DY)
                FlowChart_TableX2_Rotation(IndexFlowChart, DX)
                FlowChart_TableY2_Option(IndexFlowChart, DY)
                PaintAll(FlowChartScreen.PictureBox1, IndexFlowChart, IndexFlowChart) : PaintAll(FlowChartScreen.PictureBox1, RecordNumber, RecordNumber)
            Else
                DX = FlowChart_TableX2_Rotation(IndexFlowChart)
                DY = FlowChart_TableY1(IndexFlowChart)
                FlowChart_TableX1(RecordNumber, DX)
                FlowChart_TableY1(RecordNumber, DY)
                FlowChart_TableX2_Rotation(IndexFlowChart, DX)
                FlowChart_TableY2_Option(IndexFlowChart, DY)
                PaintAll(FlowChartScreen.PictureBox1, IndexFlowChart, IndexFlowChart) : PaintAll(FlowChartScreen.PictureBox1, RecordNumber, RecordNumber)
                '2020 07 20 changed to also add a record ThisArea.MyTablesXY.a.X = ThisArea.MyTablesXY.b.X
            End If
        End Function

        Public Shared Sub SetMyLimitScreen(where As PictureBox, FromXY As MyPointStructure)
            MyTrace(187, "SetMyLimitScreen", 98 - 82)

            If MyUniverse.MyStaticData.MinXY.X > FromXY.X Then
                MyUniverse.MyStaticData.MinXY.X = FromXY.X - 1000
            End If
            If MyUniverse.MyStaticData.MinXY.Y > FromXY.Y Then
                MyUniverse.MyStaticData.MinXY.Y = FromXY.Y - 1000
            End If
            If MyUniverse.MyStaticData.MaxXY.X < FromXY.X Then
                MyUniverse.MyStaticData.MaxXY.X = FromXY.X + 1000
            End If
            If MyUniverse.MyStaticData.MaxXY.Y < FromXY.Y Then
                MyUniverse.MyStaticData.MaxXY.Y = FromXY.Y + 1000
            End If


        End Sub



        'Routine returns from 'real' world to screen scale
        Public Shared Function Copy2Screen(Where As PictureBox, FromXY As MyPointStructure) As Point
            Dim TempH, TempV As Int32
            MyTrace(188, "Copy2Screen", 21 - 3)

            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    SetMyLimitScreen(Where, FromXY)
                    TempH = CInt((MyUniverse.MyMouseAndDrawing.MyScreen.b.X + MyUniverse.MyMouseAndDrawing.MyScreen.a.X) * MyMinMax(FlowChartScreen.HScrollBar1.Value, 1, 64000) / FlowChartScreen.HScrollBar1.Maximum)
                    TempV = CInt((MyUniverse.MyMouseAndDrawing.MyScreen.b.Y - MyUniverse.MyMouseAndDrawing.MyScreen.a.Y) * MyMinMax(FlowChartScreen.VScrollBar1.Value, 1, 64000) / FlowChartScreen.VScrollBar1.Maximum)

                    Copy2Screen.X = CInt((FromXY.X - (TempH)) * MyUniverse.SysGen.MyScale)
                    Copy2Screen.Y = CInt((FromXY.Y - (TempV)) * MyUniverse.SysGen.MyScale)
                Case "SymbolScreen"
                    TempH = 2
                    Copy2Screen.X = CInt(((FromXY.X / 2) - (MyUniverse.SysGen.ConstantSymbolCenter / 2) + MyUniverse.SysGen.ConstantSymbolCenter) / 2)
                    Copy2Screen.Y = CInt(((FromXY.Y / 2) - (MyUniverse.SysGen.ConstantSymbolCenter / 2) + MyUniverse.SysGen.ConstantSymbolCenter) / 2)
                    Copy2Screen.X = CInt(((FromXY.X / TempH) - (MyUniverse.SysGen.ConstantSymbolCenter / 2) + MyUniverse.SysGen.ConstantSymbolCenter) / 2)
                    Copy2Screen.Y = CInt(((FromXY.Y / TempH) - (MyUniverse.SysGen.ConstantSymbolCenter / 2) + MyUniverse.SysGen.ConstantSymbolCenter) / 2)
            End Select
        End Function


        'Routine copies from screen scale to 'real' world scale
        Public Shared Function Copy2MyScale(Where As PictureBox, From As MyPointStructure) As MyPointStructure
            Dim TempH, TempV As Single
            'MyTrace(189, "Copy2MyScale", 45 - 25)

            Select Case Where.Parent.Name
                Case "FlowChartScreen"
                    TempH = CInt((MyUniverse.MyMouseAndDrawing.MyScreen.b.X + MyUniverse.MyMouseAndDrawing.MyScreen.a.X) * MyMinMax(FlowChartScreen.HScrollBar1.Value, 1, 64000) / FlowChartScreen.HScrollBar1.Maximum)
                    TempV = CInt((MyUniverse.MyMouseAndDrawing.MyScreen.b.Y - MyUniverse.MyMouseAndDrawing.MyScreen.a.Y) * MyMinMax(FlowChartScreen.VScrollBar1.Value, 1, 64000) / FlowChartScreen.VScrollBar1.Maximum)
                    If MyUniverse.SysGen.MyScale <= 0.00001 Then MyUniverse.SysGen.MyScale = 0.0625 '1/16
                    If MyUniverse.SysGen.MyScale >= 10 Then MyUniverse.SysGen.MyScale = 10
                    Copy2MyScale.X = Snap(CInt((From.X / MyUniverse.SysGen.MyScale) + TempH))
                    Copy2MyScale.Y = Snap(CInt((From.Y / MyUniverse.SysGen.MyScale) + TempV))
                Case "SymbolScreen"
                    'Copy2MyScale.X = MyMinMax(((From.X - myuniverse.sysgen.ConstantSymbolCenter) * scale1 - myuniverse.sysgen.ConstantSymbolCenter), -myuniverse.sysgen.ConstantSymbolCenter * scale1, myuniverse.sysgen.ConstantSymbolCenter * scale1)
                    'Copy2MyScale.Y = MyMinMax(((From.Y - myuniverse.sysgen.ConstantSymbolCenter) * scale1 - myuniverse.sysgen.ConstantSymbolCenter), -myuniverse.sysgen.ConstantSymbolCenter * scale1, myuniverse.sysgen.ConstantSymbolCenter * scale1)
                    Copy2MyScale.X = MyMinMax(From.X - MyUniverse.SysGen.ConstantSymbolCenter, -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter)
                    Copy2MyScale.Y = MyMinMax(From.Y - MyUniverse.SysGen.ConstantSymbolCenter, -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter)
            End Select

        End Function

        '******************************************************************************
        'This is where all file openings take place
        'ReadOrWrite is a string of "read" for input of a FlowChart
        '                           "write" for output of a FlowChart
        '                           "decompile" for input from source code
        '                           "compile" for output to source code
        ' All of them open a dialog box to get the file name (SaveAs, there is no save (yet))

        'Routine Returns the file name opened. (Does not change the input file name

        Public Shared Function XOpenFile(ReadOrWrite As String, MyTitle As String) As String ' , My_FileName As String) As String 'Opens the standard selection box'2020 08 10
            Dim My_FileName As String
            MyTrace(191, "XOpenFile", 439 - 352)

            My_FileName = Nothing
            'OpenFileDialog 
            Select Case LCase(ReadOrWrite)
                Case "read"
                    Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog()
                    'If MyFileName = Nothing Then 2020 08 10
                    My_FileName = DrillDown_FileName & "." & ComputerLanguageExtention()
                    openFileDialog1.Title = MyTitle
                    openFileDialog1.FileName = My_FileName
                    openFileDialog1.InitialDirectory = "c:\\"
                    openFileDialog1.Filter = "Software Schematic files (*.FlowChart)|*.FlowChart|Symbol files (*.Symbol)|*.Symbol|TextFile (*.txt)|*.txt|All Files (*.*)|*.*"
                    openFileDialog1.RestoreDirectory = True
                    openFileDialog1.AddExtension = True
                    openFileDialog1.DefaultExt = ".FlowChart"
                    openFileDialog1.Multiselect = False
                    If openFileDialog1.ShowDialog() = DialogResult.OK Then
                        My_FileName = openFileDialog1.FileName
                    Else
                        My_FileName = Nothing
                    End If
                    XOpenFile = My_FileName
                    openFileDialog1.Dispose()

                Case "decompile"
                    Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog()
                    'If My_FileName = Nothing Then 
                    My_FileName = DrillDown_FileName & "." & ComputerLanguageExtention()
                    openFileDialog1.Title = MyTitle
                    openFileDialog1.FileName = My_FileName
                    openFileDialog1.InitialDirectory = "c:\\"
                    openFileDialog1.Filter = ComputerFileNamesAre()
                    openFileDialog1.RestoreDirectory = True
                    openFileDialog1.AddExtension = True
                    openFileDialog1.DefaultExt = ComputerFileNamesAre() '"*." & ComputerLanguageExtention() ' should be an option in the imort file 
                    openFileDialog1.Multiselect = False
                    If openFileDialog1.ShowDialog() = DialogResult.OK Then
                        My_FileName = openFileDialog1.FileName
                    Else
                        My_FileName = Nothing
                    End If
                    XOpenFile = My_FileName
                    openFileDialog1.Dispose()

                Case "write"
                    Dim SaveFileDialog1 As SaveFileDialog = New SaveFileDialog()
                    If My_FileName = Nothing Then My_FileName = "Start" & "." & ComputerLanguageExtention()
                    SaveFileDialog1.Title = MyTitle
                    SaveFileDialog1.FileName = My_FileName
                    SaveFileDialog1.InitialDirectory = "c:\\"
                    SaveFileDialog1.Filter = "Software Schematic files (*.FlowChart)|*.FlowChart|Symbol files (*.Symbol)|*.Symbol|TextFile (*.txt)|*.txt|All Files (*.*)|*.*"
                    SaveFileDialog1.RestoreDirectory = True
                    SaveFileDialog1.AddExtension = True
                    SaveFileDialog1.DefaultExt = ".FlowChart"
                    SaveFileDialog1.CheckFileExists = False
                    SaveFileDialog1.CheckPathExists = True
                    If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                        My_FileName = SaveFileDialog1.FileName
                    Else
                        My_FileName = Nothing
                    End If
                    XOpenFile = My_FileName
                    SaveFileDialog1.Dispose()
                Case "compile"
                    Dim SaveFileDialog1 As SaveFileDialog = New SaveFileDialog()
                    If My_FileName = Nothing Then My_FileName = DrillDown_FileName & "." & ComputerLanguageExtention()
                    SaveFileDialog1.Title = MyTitle
                    SaveFileDialog1.FileName = My_FileName
                    SaveFileDialog1.InitialDirectory = "c:\\"

                    SaveFileDialog1.Filter = "Source files (*.Src)|*.txt|Source files (*.Source)|*.Source|TextFile (*.txt)|*.txt|All Files (*.*)|*.*"

                    SaveFileDialog1.RestoreDirectory = True
                    SaveFileDialog1.AddExtension = True
                    SaveFileDialog1.DefaultExt = ".Source"
                    SaveFileDialog1.CheckFileExists = False
                    SaveFileDialog1.CheckPathExists = True
                    If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                        My_FileName = SaveFileDialog1.FileName
                    Else
                        My_FileName = Nothing
                    End If
                    XOpenFile = My_FileName
                    SaveFileDialog1.Dispose()
                Case Else
                    XOpenFile = Nothing
            End Select
        End Function


        'Routine This will write out one line of text to the file stream I/O
        Public Shared Sub MyWrite(LineNumber As int32, Writer As System.IO.FileStream, OutPutString As String)
            Dim A As String
            Dim Index As int32
            MyTrace(192, "MyWrite", 59 - 43)

            If OutPutString = Nothing Then Exit Sub ' We never write nothing(just blank lines)

            If LineNumber > 0 Then
                If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(16) = True Then 'output line numbers
                    A = OutPutString & FD & " " & FD & ComputerLanguageComment() & FD & LineNumber
                Else
                    A = OutPutString
                End If
            Else
                A = OutPutString
            End If

            Dim Temp(Len(OutPutString) + 100) As Byte

            Temp(0) = Asc("/") ' Why are we doing this for program text output???? (And not passing it for Save or Export)
            For Index = 1 To Len(A)
                Temp(Index) = CByte(Asc(Mid(A, Index, 1)))
            Next

            Temp(Len(A) + 1) = Asc(vbCr)
            Temp(Len(A) + 2) = Asc(vbLf)
            Writer.WriteAsync(Temp, 1, Len(A) + 2)

        End Sub

        Public Shared Function NoComments(MyCodeLine As String) As String
            Dim TempComment As String
            MyTrace(193, "NoComments", 10)

            NoComments = MyCodeLine
            TempComment = ComputerLanguageComment()
            If InStr(MyCodeLine, TempComment) > 0 Then
                NoComments = Mid(MyCodeLine, 1, InStr(MyCodeLine, TempComment) - 1)
                Exit Function
            End If
        End Function


        '*******************************************************************
        ' This is parsing the inport file from the format /keyword=options....
        Public Shared Function TrimEqual(InputString As String) As String
            MyTrace(194, "TrimEqual", 8)

            If Left(InputString, 1) = "=" Then ' change in the delimiters 2020 08 13
                TrimEqual = Trim(Mid(InputString, 2, Len(InputString)))
            Else
                TrimEqual = InputString
            End If
        End Function


        Public Shared Function XTrim(StringtoTrim As String) As String
            MyTrace(195, "XTrim", 7)

            XTrim = Trim(StringtoTrim)
            While Left(XTrim, 1) = FD
                XTrim = Mid(XTrim, 2, Len(XTrim))
            End While
        End Function


        '***************************************************************
        'Routine This will trim a string from all spaces, carrage returns, and Linefeeds
        ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
        Public Shared Function MyTrim(StringToTrim As String) As String
            Dim X As String
            Dim Index As int32
            Dim Flag As Boolean
            'MyTrace(196, "MyTrim", 90 - 64)

            MyTrim = Trim(StringToTrim)
            X = vbCr & vbLf ' removed extra characters because they might be a part of the keyword 2020 07 31
            ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
            Do
                Flag = False
                For Index = 1 To Len(X)
                    While Left(MyTrim, 1) = Mid(X, Index, 1)
                        ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
                        MyTrim = Mid(MyTrim, 2, Len(MyTrim))
                        Flag = True
                    End While
                    While Right(MyTrim, 1) = Mid(X, Index, 1)
                        ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
                        MyTrim = Left(MyTrim, Len(MyTrim) - 1)
                        Flag = True
                    End While
                Next
            Loop Until Flag = False
            ' This needs to be changed so that we find where the trim is, and then move the string only once, becuse this way is VERY slow.
        End Function


        'Routine This writes out all of the data in the MyArrays to a file (Has error, not able to create a new file yet)
        Public Shared Sub Export(Where As PictureBox, OutputFileName As String)
            Dim MinePen As Pen
            Dim X3, X2 As String
            Dim OutPutLine As String
            Dim I, IndexFlowChart, IndexiSAM, IndexNamed As Int32
            Dim TempFormat As String 'hack (and all lines that use it
            Dim MyLineNumber As int32 ' extra saving the line number and other stuff at the end for now
            MyTrace(197, "Export", 786 - 494)

            MyLineNumber = 1
            If Dir(OutputFileName) = "" Then ' need to create the file if it does not exist then you can ...
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(OutputFileName)
                End Using
            Else
                'System.IO.File.Create(OutputFileName)
                Kill(OutputFileName)
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(OutputFileName)
                End Using
            End If


            For IndexFlowChart = LBound(Language_KeyWords) + 1 To UBound(Language_KeyWords)
                ReSortLanguageKeyWords("LanguageKeyWords", Language_KeyWords, IndexFlowChart)
            Next
            For IndexFlowChart = LBound(Language_Functions) + 1 To UBound(Language_Functions)
                ReSortLanguageKeyWords("LanguageFunctions", Language_Functions, IndexFlowChart)
            Next
            For IndexFlowChart = LBound(Language_Operators) + 1 To UBound(Language_Operators)
                ReSortLanguageKeyWords("LanguageOperators", Language_Operators, IndexFlowChart)
            Next

            'Make sure everthing is in sorted order, cause Ima putting it out in sorted order, so it will be easier to re-input (except for FlowChart_Table...)

            SortColors()
            SortDataType()
            SortNamed()
            SortFlowChart()

            ' Now open it for output
            Using Writer As System.IO.FileStream = System.IO.File.OpenWrite(OutputFileName)
                MyMsgCtr("Export", 1136, OutputFileName, "", "", "", "", "", "", "", "")
                DisplayMyStatus("Exporting Language Key Words")
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatColor) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatDatatype) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatSymbolName) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatPoint) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatLine) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatNameOfFile) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatLanguage) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatStroke) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatNotes) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatVersion) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatAuthor) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatOpcode) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatPath) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatUse) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatConstant) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatProgramText) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatOption) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatError) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatDelete) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatThisCode) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatLanguage_KeyWord) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatLanguage_operator) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatLanguage_Function) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & formatProgramText) : MyLineNumber += 1
                MyWrite(MyLineNumber, Writer, "/Ignore= " & FormatSyntaxKeyWord) : MyLineNumber += 1



                ' Write out all of the options that are turned OFF
                OutPutLine = "/Language=" & WhatComputerLanguage()
                OutPutLine = "/language=" &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 0) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 1) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 2) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 3) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 4) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 5) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 6) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 7) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 8) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 9) & FD &
                    MyUnEnum(MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage), OptionScreen.ToolStripDropDownComputerLanguage, 10)


                For IndexFlowChart = 1 To 999
                    If IsBitSet(IndexFlowChart) Then
                        'MyWrite(mylinenumber, Writer, "/Option=" & Index & FD & "on")
                        'MyLineNumber += 1
                    Else
                        MyWrite(MyLineNumber, Writer, "/Option=" & IndexFlowChart & FD & "off")
                        MyLineNumber += 1
                    End If
                Next

                'write out all of the message options options that are turned off (Escape on the message box)
                For IndexFlowChart = 1000 To 9999
                    If IsBitSet(IndexFlowChart) Then
                        'MyWrite(mylinenumber, Writer, "/Option=" & Index & FD & "on")
                        'MyLineNumber += 1
                    Else
                        MyWrite(MyLineNumber, Writer, "/Option=" & IndexFlowChart & FD & "off")
                        MyLineNumber += 1
                    End If
                Next



                'Write out all of the key words
                TempFormat = FormatLanguage_KeyWord
                For IndexFlowChart = LBound(Language_KeyWords) To UBound(Language_KeyWords)
                    If Language_KeyWords(IndexFlowChart) <> "" And
                        Left(Language_KeyWords(IndexFlowChart), Len(Language_KeyWords(IndexFlowChart))) <> MyConstantIgnoreFunctionOperatorsKeywords Then

                        OutPutLine = "/keyword" & "=" & Language_KeyWords(IndexFlowChart)
                        MyWrite(MyLineNumber, Writer, OutPutLine)
                        MyLineNumber += 1
                    End If
                Next IndexFlowChart

                TempFormat = FormatLanguage_operator
                For IndexFlowChart = LBound(Language_Operators) To UBound(Language_Operators)
                    If Language_Operators(IndexFlowChart) <> "" Then
                        OutPutLine = "/operator" & "=" & Language_Operators(IndexFlowChart)
                        MyWrite(MyLineNumber, Writer, OutPutLine)
                        MyLineNumber += 1
                    End If
                Next IndexFlowChart

                TempFormat = FormatLanguage_Function
                For IndexFlowChart = LBound(Language_Functions) To UBound(Language_Functions)
                    If Language_Functions(IndexFlowChart) <> "" Then
                        OutPutLine = "/Function" & "=" & Language_Functions(IndexFlowChart)
                        MyWrite(MyLineNumber, Writer, OutPutLine)
                        MyLineNumber += 1
                    End If
                Next IndexFlowChart

                'Write out all of the color information (Including all of those that are not used here
                DisplayMyStatus("Exporting Colors")
                TempFormat = formatColor
                For IndexiSAM = 1 To TopOfFile("Color", Color_FileName, Color_iSAM_) - 1
                    I = Color_iSAM_(IndexiSAM)
                    OutPutLine = "/color" & " = " & Color_TableName(I)
                    MyGetPen_Static(Color_TableName(I))
                    MinePen = GetMyPen
                    OutPutLine = OutPutLine & FD & Color_TableAlpha(I) 'PenColor.Color.A
                    OutPutLine = OutPutLine & FD & Color_TableRed(I) 'PenColor.Color.R
                    OutPutLine = OutPutLine & FD & Color_TableGreen(I) 'PenColor.Color.G
                    OutPutLine = OutPutLine & FD & Color_TableBlue(I) 'PenColor.Color.B
                    OutPutLine = OutPutLine & FD & Color_TableStyle(I)
                    OutPutLine = OutPutLine & FD & MyUnEnum(Color_TableStartCap(I), SymbolScreen.ToolStripDropDownPathStart, 0) 'constantEnumCaps)
                    OutPutLine = OutPutLine & FD & MyUnEnum(Color_TableEndCap(I), SymbolScreen.ToolStripDropDownPathEnd, 0) 'constantEnumCaps)
                    MyWrite(MyLineNumber, Writer, OutPutLine)
                    MyLineNumber += 1
                    ''''MinePen.Dispose()
                Next


                DisplayMyStatus("Exporting Data Types")
                TempFormat = formatDatatype
                'datatypes are not getting sorted before export

                For IndexiSAM = 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                    I = DataType_iSAM_(IndexiSAM)
                    OutPutLine = "/datatype" & " = " & DataType_TableName(I)
                    OutPutLine = OutPutLine & FD & DataType_TableNumberOfBytes(I)
                    OutPutLine = OutPutLine & FD & Color_TableName(DataType_TableColorIndex(I)) 'DataType_TableColor( i )
                    OutPutLine = OutPutLine & FD & DataType_TableWidth(I)
                    OutPutLine = OutPutLine & FD & PrintAbleNull(Trim(DataType_TableDescribtion(I)))
                    MyWrite(MyLineNumber, Writer, OutPutLine)
                    MyLineNumber += 1
                Next
                OutPutLine = Nothing


                ' We have to output it in the order of the file.
                DisplayMyStatus("Exporting Symbols")
                FindingMyBugs(10) 'hack Least amount of checking here 'hack
                For I = 1 To TopOfFile("Symbol", Symbol_FileCoded)
                    Select Case Symbol_TableCoded_String(I)
                        Case "/name"
                            'MyMakeArraySizesBigger() never needs to check the size because we are never adding anything (I hope)
                            TempFormat = formatSymbolName
                            DisplayMyStatus("Exporting Symbol " & Symbol_TableSymbolName(I))
                            OutPutLine = "/name"
                            OutPutLine = OutPutLine & "=" & Symbol_TableSymbolName(I)
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1

                            'We are adding here so that there will be no error message later, (How did it happend anyway?)
                            If PrintAbleNull(Symbol_TableSymbolName(I)) = "_" Then MyMsgCtr("Export", 1413, Symbol_TableSymbolName(I), "14", "", "", "", "", "", "", "")

                            IndexNamed = FindIndexIniSAMTable("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, Symbol_TableSymbolName(I))
                            If IndexNamed = constantMyErrorCode Then
                                IndexNamed = CheckNotInList("Named", "DoNotAdd", Named_FileSymbolName, Named_File_iSAM, Symbol_TableSymbolName(I))
                            End If
                            If IndexNamed = constantMyErrorCode Then
                                Abug(699, "named not found ", Symbol_TableSymbolName(I), I)
                            Else
                                If Not IsNothing(Named_TableAuthor(IndexNamed)) Then
                                    TempFormat = formatAuthor
                                    OutPutLine = "/Author" & " = " & Named_TableAuthor(IndexNamed)
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End If
                                If Not IsNothing(Named_TableVersion(IndexNamed)) Then
                                    TempFormat = formatVersion
                                    OutPutLine = "/version" & " = " & Named_TableVersion(IndexNamed)
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End If
                                If Not IsNothing(Named_TableNameofFile(IndexNamed)) Then
                                    TempFormat = formatNameOfFile
                                    OutPutLine = "/filename" & " = " & Named_TableNameofFile(IndexNamed)
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End If

                                If Not IsNothing(Named_TableStroke(IndexNamed)) Then
                                    TempFormat = formatStroke
                                    OutPutLine = "/stroke" & " = " & Named_TableStroke(IndexNamed)
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End If
                                '/programtext the same as /code 
                                X2 = MyTrim(Named_TableProgramText(IndexNamed))
                                While X2 <> ""
                                    TempFormat = formatProgramText
                                    OutPutLine = "/programtext" & " = " & MyTrim(PopLine(X2))
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End While
                                X2 = MyTrim(Named_TableSyntax(IndexNamed))
                                While X2 <> ""
                                    TempFormat = formatProgramText
                                    OutPutLine = "/syntax" & " = " & MyTrim(PopLine(X2))
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End While
                                X2 = MyTrim(Named_TableNotes(IndexNamed))
                                While X2 <> ""
                                    TempFormat = formatNotes
                                    OutPutLine = "/notes" & " = " & MyTrim(PopLine(X2))
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End While
                                X2 = MyTrim(Named_TableOpCode(IndexNamed))
                                While X2 <> ""
                                    TempFormat = formatOpcode
                                    OutPutLine = "/opcode" & " = " & PopLine(X2)
                                    MyWrite(MyLineNumber, Writer, OutPutLine)
                                    MyLineNumber += 1
                                End While
                            End If
                        Case "/point"
                            TempFormat = formatPoint
                            X3 = "None"
                            X3 = MyUnEnum(Symbol_TableX2_io(I), SymbolScreen.ToolStripDropDownInputOutput, 0)
                            X2 = "None"
                            'X2 = MyUnEnum(Symbol_TableX2_io(I), SymbolScreen.ToolStripDropDownButtonPointDataType, 0)
                            X2 = SymbolScreen.ToolStripDropDownDataType.Text
                            X2 = CStr(FindIndexIniSAMTable("Datatype", "Donotadd", DataType_FileName, DataType_iSAM_, SymbolScreen.ToolStripDropDownDataType.Text))

                            '/Point=X, Y, Input/Output, Data Type, Name
                            OutPutLine = "/point"
                            OutPutLine = OutPutLine & " = " & Symbol_TableX1(I)
                            OutPutLine = OutPutLine & " , " & Symbol_TableY1(I)
                            OutPutLine = OutPutLine & " , " & X3 ' input or output point
                            OutPutLine = OutPutLine & " , " & X2 ' datatype of this point
                            OutPutLine = OutPutLine & " , " & Symbol_Table_NameOfPoint(I) 'Point Name
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1

                        Case "/line"
                            TempFormat = formatLine
                            OutPutLine = "/line"
                            OutPutLine = OutPutLine & " = " & Symbol_TableX1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableX2_io(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY2_dt(I)
                            OutPutLine = OutPutLine & FD & Symbol_Table_NameOfPoint(I)
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/delete"
                            TempFormat = FormatDelete
                            OutPutLine = "/delete"
                            OutPutLine = OutPutLine & " = " & Symbol_TableX1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY1(I)
                            'i MIGHT HAVE THESE TWO BACKWARDS error?
                            OutPutLine = OutPutLine & FD & Symbol_TableSymbolName(I)
                            OutPutLine = OutPutLine & FD & Symbol_Table_NameOfPoint(I)
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/error"
                            TempFormat = FormatError
                            OutPutLine = "/error"
                            OutPutLine = OutPutLine & " = " & Symbol_TableX1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY1(I)
                            OutPutLine = OutPutLine & " = " & Symbol_TableX2_io(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY2_dt(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableSymbolName(I)
                            OutPutLine = OutPutLine & FD & Symbol_Table_NameOfPoint(I)
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case Else
                            OutPutLine = "/ProgramError Symbol Data Unknown /error = " & I & FD
                            OutPutLine = OutPutLine & Symbol_TableCoded_String(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableX1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY1(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableX2_io(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableY2_dt(I)
                            OutPutLine = OutPutLine & FD & Symbol_Table_NameOfPoint(I)
                            OutPutLine = OutPutLine & FD & Symbol_TableSymbolName(I)
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                    End Select
                Next


                DisplayMyStatus("Exporting FlowChart Details")

                For IndexFlowChart = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                    I = FlowChart_iSAM_Name(IndexFlowChart)
                    Select Case LCase(FlowChart_TableCode(I))
                        Case "/use"
                            TempFormat = formatUse
                            ' Error here X3 should never be Null (-1)
                            X3 = MyUnEnum(FlowChart_TableX2_Rotation(I), SymbolScreen.ToolStripDropDownRotation, 0) ' constantEnumRotation)
                            DisplayMyStatus("Exporting Call " & FlowChart_TableNamed(I))
                            OutPutLine = "/use" & "=" & PrintAbleNull(FlowChart_TableNamed(I)) ' Name First
                            OutPutLine = OutPutLine & FD & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & FD & X3
                            OutPutLine = OutPutLine & FD & PrintAbleNull(FlowChart_Table_DataType(I))
                            OutPutLine = OutPutLine & FD & PrintAbleNull(FlowChart_TableY2_Option(I).ToString) 'hack
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/path"
                            DisplayMyStatus("Exporting Path " & FlowChart_TableNamed(I))
                            OutPutLine = "/path" & "=" & FlowChart_TableNamed(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableX2_Rotation(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY2_Option(I)
                            OutPutLine = OutPutLine & FD & FlowChart_Table_DataType(I)
                            'OutPutLine = OutPutLine & ", \ i =" & PrintAbleNull( i ) ' print out but ignored on input.
                            'OutPutLine = OutPutLine & ", \linkd=" & PrintAbleNull(FlowChart_TableLinks( i )) ' print out but ignored on input.
                            TempFormat = formatPath
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/constant"
                            OutPutLine = "/constant" & "="
                            OutPutLine = OutPutLine & FD & FlowChart_TableNamed(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_Table_DataType(I)
                            TempFormat = formatConstant
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/delete"
                            OutPutLine = "/delete" & " = "
                            OutPutLine = OutPutLine & FD & PrintAbleNull(FlowChart_TableNamed(I))
                            OutPutLine = OutPutLine & FD & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableX2_Rotation(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY2_Option(I)
                            OutPutLine = OutPutLine & FD & PrintAbleNull(FlowChart_Table_DataType(I))
                            'OutPutLine = OutPutLine & ", \ i =" & PrintAbleNull( i ) ' print out but ignored on input.
                            'OutPutLine = OutPutLine & ", \linkd=" & PrintAbleNull(FlowChart_TableLinks( i )) ' print out but ignored on input.
                            TempFormat = FormatDelete
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/error"
                            TempFormat = FormatError
                            OutPutLine = "/error" & " = " & FlowChart_TableCode(I)
                            OutPutLine = OutPutLine & FD & PrintAbleNull(FlowChart_TableNamed(I))
                            OutPutLine = OutPutLine & FD & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableX2_Rotation(I)
                            OutPutLine = OutPutLine & FD & FlowChart_TableY2_Option(I)
                            OutPutLine = OutPutLine & FD & FlowChart_Table_DataType(I) ' datatype is not required (ignored) on Import and should be '_' Null
                            'OutPutLine = OutPutLine & ", \ i =" & PrintAbleNull( i ) ' print out but ignored on input.
                            'OutPutLine = OutPutLine & ", \linkd=" & PrintAbleNull(FlowChart_TableLinks( i )) ' print out but ignored on input.
                            TempFormat = FormatError
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case "/programtext"
                            TempFormat = formatProgramText
                            X2 = FlowChart_TableCode(I)
                            While X2 <> ""
                                TempFormat = formatProgramText
                                MyWrite(MyLineNumber, Writer, "/programtext" & " = " & PopLine(X2))
                                MyLineNumber += 1
                            End While
                            OutPutLine = "/ProgramText" & " = "
                            OutPutLine = OutPutLine & ",\Named =" & PrintAbleNull(FlowChart_TableNamed(I))
                            OutPutLine = OutPutLine & ",\X1 =" & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & ",\y1 =" & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & ",\X2 =" & FlowChart_TableX2_Rotation(I)
                            OutPutLine = OutPutLine & ",\Y2 =" & FlowChart_TableY2_Option(I)
                            OutPutLine = OutPutLine & ",\Datatype =" & DataType_TableName(My_Int(FlowChart_Table_DataType(I)))
                            'OutPutLine = OutPutLine & ", \ i  =" & PrintAbleNull( i ) ' print out but ignored on input.
                            'OutPutLine = OutPutLine & ", \linkd =" & PrintAbleNull(FlowChart_TableLinks( i )) ' print out but ignored on input.
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                        Case Else
                            OutPutLine = "/Error=Export FlowChart unknown /"
                            OutPutLine = OutPutLine & FlowChart_TableCode(I)
                            OutPutLine = OutPutLine & ",\Code= " & FlowChart_TableCode(I)
                            OutPutLine = OutPutLine & ",\Named= " & FlowChart_TableNamed(I)
                            OutPutLine = OutPutLine & ",\X1 = " & FlowChart_TableX1(I)
                            OutPutLine = OutPutLine & ",\Y1 = " & FlowChart_TableY1(I)
                            OutPutLine = OutPutLine & ",\X2 = " & FlowChart_TableX2_Rotation(I)
                            OutPutLine = OutPutLine & ",\Y2 = " & FlowChart_TableY2_Option(I)
                            OutPutLine = OutPutLine & ",\DataType = " & PrintAbleNull(FlowChart_Table_DataType(I))
                            OutPutLine = OutPutLine & ",\ i  =" & PrintAbleNull(I.ToString) ' print out but ignored on input.
                            OutPutLine = OutPutLine & ",\linkd =" & PrintAbleNull(FlowChart_PathLinks_And_CompiledCode(I)) ' print out but ignored on input.
                            MyWrite(MyLineNumber, Writer, OutPutLine)
                            MyLineNumber += 1
                    End Select
                Next
                MyWrite(MyLineNumber, Writer, "/endoffile")
                MyLineNumber += 1
                Writer.Flush()
                Writer.Close()
            End Using
            ShowAllForms(ShowScreen, HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, HideScreen)
            DisplayMyStatus("Export Finished. . .Written " & MyLineNumber & " lines")
        End Sub

        Public Shared Sub ImportDataTypes(Key_line As String, LineNumber As int32)
            Dim IndexDataType As int32
            Dim Inputline As String
            Dim DataTypeName As String
            Dim LostColorName As String
            Dim LostColorIndex As int32
            MyTrace(198, "ImportDataTypes", 825 - 788)

            Inputline = Trim(Key_line)
            Inputline = trimequal(Key_line)
            DataTypeName = MyTrim(Pop(Inputline, vbLf & vbCr & FD & ",=/\" & vbCrLf))

            If PrintAbleNull(DataTypeName) = "_" Then MyMsgCtr("ImportDataTypes", 1413, DataTypeName, "15", "", "", "", "", "", "", "") : Exit Sub
            'CheckForAnySortNeeded("", 205)
            DataType_FileColorIndex(NewTopOfFile("Datatype", DataType_FileName, DataType_iSAM_)) = FindColor("Black") '20200628'to fool FindingMyBugs for now
            IndexDataType = FindIndexIniSAMTable("DataType", "add", DataType_FileName, DataType_iSAM_, DataTypeName)
            ' ****** incase we added then it is out of order
            'ShowSorts("DataType", SortDataType())
            'CheckForAnySortNeeded("", 206)
            'IndexDataType = MyMinMax(TopOfFile("DataType", DataType_FileName, DataType_iSAM_), IndexDataType, TopOfFile("DataType", DataType_FileName, DataType_iSAM_))
            '*******
            'DataType_TableName(Index) = Pop(KeyLine)
            DataType_TableNumberOfBytes(IndexDataType, Popvalue(Inputline))
            LostColorName = Pop(Inputline, ConstantDelimeters)
            LostColorName = MyTrim(LostColorName)
            LostColorIndex = FindColor(LostColorName)
            If LostColorIndex = constantMyErrorCode Then
                ShowSorts("color", SortColors())
            End If
            DataType_TableColorIndex(IndexDataType, FindColor(LostColorName))
            If DataType_TableColorIndex(IndexDataType) < 1 Then
                DataType_TableColorIndex(IndexDataType, FindColor("RED"))
            End If
            If DataType_TableColorIndex(IndexDataType) = constantMyErrorCode Then
                FindingMyBugs(10) 'hack Least amount of checking here
                MyMsgCtr("ImportDataTypes", 1048, LostColorName, DataType_TableName(IndexDataType), IndexDataType.ToString, LineNumber.ToString, MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME, "", "", "", "")
                DataType_TableColorIndex(IndexDataType, FindColor(MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME))
            End If
            DataType_TableWidth(IndexDataType, CByte(MyABS(Popvalue(Inputline))))

            DataType_TableDescribtion(IndexDataType, Pop(Inputline, FD & vbCr & vbLf & vbCrLf))
            'CheckForAnySortNeeded("", 207) 'hack
            ShowSorts("DataType", MyReSort("DataType", DataType_FileName, DataType_iSAM_, IndexDataType)) '03/12/19 Only resort the top item
            SortDataType()
            CheckForAnySortNeeded("", 208) 'hack
            MyMakeArraySizesBigger()
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
            SymbolScreen.ToolStripDropDownDataType.DropDownItems.Add(DataType_TableName(IndexDataType))
        End Sub


        Public Shared Sub SetOptions(ImportLine As String)
            Dim X0, X1, X2, X3, X4 As String
            Dim I, I1, I2, I3 As Int32
            X0 = ImportLine
            X1 = Pop(X0, FD) 'What
            Select Case LCase(X1)                    ' format /language=(name of language) then all of the options
                Case "points" ' Location of the points (first to last point) 1-121??
                    'The first two points are the camefrom and goto (1 and 2)
                    I1 = MyMinMax(My_INT(Pop(X0, FD)), 0, UBound(MyUniverse.MySymbolPoints))
                    I2 = MyMinMax(My_INT(Pop(X0, FD)), MyUniverse.SysGen.constantSymbolCenter, MyUniverse.SysGen.constantSymbolCenter)
                    I3 = MyMinMax(My_INT(Pop(X0, FD)), MyUniverse.SysGen.constantSymbolCenter, MyUniverse.SysGen.constantSymbolCenter)
                    MyUniverse.OptionDisplay(I1).X = I2 : MyUniverse.MySymbolPoints(I1).Y = I3
                Case "points" ' Location of the options to display 
                    'The first two points are the camefrom and goto (1 and 2)
                    I1 = MyMinMax(My_INT(Pop(X0, FD)), 0, UBound(MyUniverse.OptionDisplay))
                    I2 = MyMinMax(My_INT(Pop(X0, FD)), MyUniverse.SysGen.constantSymbolCenter, MyUniverse.SysGen.constantSymbolCenter)
                    I3 = MyMinMax(My_INT(Pop(X0, FD)), MyUniverse.SysGen.constantSymbolCenter, MyUniverse.SysGen.constantSymbolCenter)
                    MyUniverse.OptionDisplay(I1).X = I2 : MyUniverse.MySymbolPoints(I1).Y = I3
                Case "delimiters"
                    MyUniverse.SysGen.RMStart = Pop(X0, FD)
                    MyUniverse.SysGen.RMEnd = Pop(X0, FD)
                Case "language" ' Set a new language parameter (for any new language)
                    'hack, need to also see if this language is already there and replace it.
                    OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Add(X0)
                    'todo Also Select this as the default language now
                Case "options"
                    'Force it to only change the available list
                    X2 = Pop(X0, FD)
                    I = MyMinMax(My_INT(X2), 0, OptionScreen.CheckedListBoxOptionSelection.Items.Count - 1)
                    OptionScreen.CheckedListBoxOptionSelection.SetItemCheckState(I, CheckState.Checked)
                Case "scale"
                    X2 = Pop(X0, FD)
                    MyUniverse.SysGen.MyScale = My_INT(X2) / 1000
                    LimitScale()
                Case "spacing"
                    MyUniverse.SysGen.MaxSymbolInYSpacing = MyMinMax(My_INT(Pop(X0, FD)), MyUniverse.SysGen.constantSymbolCenter * 2, MyUniverse.SysGen.constantSymbolCenter * 10)
                Case "dump"
                    X2 = Pop(X0, FD)
                    X3 = Pop(X0, FD)
                    X4 = Pop(X0, FD)
                    MyUniverse.SysGen.outputfilename1 = X2
                    MyUniverse.SysGen.outputfilename2 = X3
                    MyUniverse.SysGen.outputfilename3 = X4
            End Select
        End Sub


        Public Shared Sub DoOption(whichComputerLanguage As String) ' Turns the computer language on
            MyTrace(199, "DoOption", 4)

            ComputerLanguageTurnedOn(whichComputerLanguage)
        End Sub


        Public Shared Sub DoOption(WhichOne As int32, HowMuch As String, OtherOptions As String)
            Dim I As int32
            Dim X As String
            Dim Level As int32
            MyTrace(201, "DoOption", 904 - 827)

            Select Case WhichOne
                Case 51
                    For I = LBound(MyMessageBits) To UBound(MyMessageBits)
                        MyMessageBits(I) = 255 ' Turn "on" all message and debug bits
                    Next I
                    ' Turn off these language bit, reserved for later usage(in five years for new languages)
                    'BitSet (  MyUniverse.SysGen.ConstantLastLanguage + 0, "Off")
                    'BitSet (  MyUniverse.SysGen.ConstantLastLanguage - 1, "Off")
                    'BitSet (  MyUniverse.SysGen.ConstantLastLanguage - 2, "Off")
                    'BitSet (  MyUniverse.SysGen.ConstantLastLanguage - 3, "Off")
                    'BitSet (  MyUniverse.SysGen.ConstantLastLanguage - 4, "Off")
                Case 52         ' Turn off Display messages
                    For I = 0 To OptionScreen.ComboBoxDebug.Items.Count - 1
                        X = OptionScreen.ComboBoxDebug.Items.Item(I).ToString
                        Level = Popvalue(X) ' remove level number
                        If LCase(Trim(Pop(X, ConstantDelimeters))) = "display" Then
                            BitSet(Level, "off") ' turn off all displays that can show up
                        End If
                    Next
                Case 53 '                Turn off information messages
                    For I = 0 To OptionScreen.ComboBoxDebug.Items.Count - 1
                        X = OptionScreen.ComboBoxDebug.Items.Item(I).ToString
                        Level = Popvalue(X)
                        If LCase(Trim(Pop(X, ConstantDelimeters))) = "information" Then
                            BitSet(Level, "off") ' turn on or off all information that can show up
                        End If
                    Next
                Case 54 '                Turn off warning messages
                    For I = 0 To OptionScreen.ComboBoxDebug.Items.Count - 1
                        X = OptionScreen.ComboBoxDebug.Items.Item(I).ToString
                        Level = Popvalue(X)
                        If LCase(Trim(Pop(X, ConstantDelimeters))) = "warning" Then
                            BitSet(Level, "off") ' turn on or off all information that can show up
                        End If
                    Next
                Case 55 '                Turn off wrong messages
                    For I = 0 To OptionScreen.ComboBoxDebug.Items.Count - 1
                        X = OptionScreen.ComboBoxDebug.Items.Item(I).ToString
                        Level = Popvalue(X)
                        If LCase(Trim(Pop(X, ConstantDelimeters))) = "wrong" Then
                            BitSet(Level, "off") ' turn on or off all information that can show up
                        End If
                    Next
                Case Else
                    If WhichOne > 999 And WhichOne < 10000 Then
                        BitSet(WhichOne, HowMuch)
                    End If
            End Select
        End Sub



        Public Shared Sub ImportColors(Key_Line As String)
            Dim Temp As String
            Dim Temp2 As int32
            Dim IndexColor As int32
            Dim Inputline As String
            MyTrace(202, "ImportColors", 88 - 8)

            Inputline = TrimEqual(Key_Line)

            MyMakeArraySizesBigger()
            Temp = Pop(Inputline, ConstantDelimeters)
            If Temp = "=" Then ' this is added because of the change in delimeters 2020 08 13
                Temp = Pop(Inputline, ConstantDelimeters)
            End If
            Temp = MyTrim(Temp)
            'should never return a -1
            If PrintAbleNull(Temp) = "_" Then If PrintAbleNull(Temp) = "_" Then MyMsgCtr("ImportColors", 1413, Temp, "16", "", "", "", "", "", "", "")
            CheckForAnySortNeeded("", 209)
            'ShowSorts("Color", MyReSort("Color", Color_FileName, Color_iSAM_, IndexColor)) '3/13/19 incase of a color being added to the end
            IndexColor = FindIndexIniSAMTable("Color", "add", Color_FileName, Color_iSAM_, Temp) 'hack
            'ShowSorts("Color", MyReSort("Color", Color_FileName, Color_iSAM_, IndexColor)) '3/13/19 incase of a color being added to the end
            'IndexColor = FindIndexIniSAMTable("Color", "add", Color_FileName, Color_iSAM_, Temp) 'hack
            If IndexColor < 0 Then 'This is if the color is not found and can not be added.
                MyMsgCtr("ImportColors", 1014, Temp, IndexColor.ToString, "", "", "", "", "", "", "") 'hack
                If PrintAbleNull(Temp) = "_" Then MyMsgCtr("ImportColors", 1413, Temp, "17", "", "", "", "", "", "", "")
                CheckForAnySortNeeded("", 215)
                IndexColor = FindIndexIniSAMTable("Color", "add", Color_FileName, Color_iSAM_, Temp) 'hack
                If IndexColor = constantMyErrorCode Then
                    IndexColor = NewTopOfFile("Color", Color_FileName, Color_iSAM_)
                End If
            Else
                Temp2 = MyMinMax(IndexColor, 1, NewTopOfFile("Color", Color_FileName, Color_iSAM_))
                If Temp2 <> IndexColor Then
                    Abug(924, "ImportColors():", Temp2, IndexColor)
                End If
            End If

            'Color_TableName(Index) = Pop(KeyLine)
            Color_TableAlpha(IndexColor, Popvalue(Inputline)) 'Alpha
            Color_TableRed(IndexColor, Popvalue(Inputline)) 'Red
            Color_TableGreen(IndexColor, Popvalue(Inputline)) 'Green
            Color_TableBlue(IndexColor, Popvalue(Inputline)) 'Blue
            '****** This is wrong, because all of the options are not available for all of the CAP styles, need to fix this later
            Color_TableStyle(IndexColor, Pop(Inputline, ConstantDelimeters)) ' constantEnumStyle, Inputline)
            Color_TableStartCap(IndexColor, MyEnumValue(Pop(Inputline, ConstantDelimeters), SymbolScreen.ToolStripDropDownPathStart))
            Color_TableEndCap(IndexColor, MyEnumValue(Pop(Inputline, ConstantDelimeters), SymbolScreen.ToolStripDropDownPathEnd))
            CheckForAnySortNeeded("", 217) 'hack
            ShowSorts("Color", MyReSort("Color", Color_FileName, Color_iSAM_, IndexColor)) '03/12/19 only resort top item if changed
            CheckForAnySortNeeded("", 218) 'hack
            'DisplayMyStatus(" Added Color " & Temp)
            TopOfFile("color", Color_FileAlpha) ' This is to update the top of file, and make the array bigger

        End Sub


        Public Shared Sub ImportSymbolPointPreference()
            MyTrace(203, "ImportSymbolPointPreference()", 8696 - 8573)

            MyUniverse.MySymbolPoints(1).X = 0 : MyUniverse.MySymbolPoints(1).Y = -250
            MyUniverse.MySymbolPoints(2).X = 0 : MyUniverse.MySymbolPoints(2).Y = 250
            MyUniverse.MySymbolPoints(3).X = -250 : MyUniverse.MySymbolPoints(3).Y = 0
            MyUniverse.MySymbolPoints(4).X = 250 : MyUniverse.MySymbolPoints(4).Y = 0
            MyUniverse.MySymbolPoints(5).X = -250 : MyUniverse.MySymbolPoints(5).Y = -100
            MyUniverse.MySymbolPoints(6).X = 250 : MyUniverse.MySymbolPoints(6).Y = -100
            MyUniverse.MySymbolPoints(7).X = -250 : MyUniverse.MySymbolPoints(7).Y = 100
            MyUniverse.MySymbolPoints(8).X = 250 : MyUniverse.MySymbolPoints(8).Y = 100
            MyUniverse.MySymbolPoints(9).X = -250 : MyUniverse.MySymbolPoints(9).Y = -250
            MyUniverse.MySymbolPoints(10).X = -250 : MyUniverse.MySymbolPoints(10).Y = 250
            MyUniverse.MySymbolPoints(11).X = 250 : MyUniverse.MySymbolPoints(11).Y = -250
            MyUniverse.MySymbolPoints(12).X = 250 : MyUniverse.MySymbolPoints(12).Y = 250
            MyUniverse.MySymbolPoints(13).X = -150 : MyUniverse.MySymbolPoints(13).Y = 250
            MyUniverse.MySymbolPoints(14).X = 150 : MyUniverse.MySymbolPoints(14).Y = 250
            MyUniverse.MySymbolPoints(15).X = -150 : MyUniverse.MySymbolPoints(15).Y = -250
            MyUniverse.MySymbolPoints(16).X = 150 : MyUniverse.MySymbolPoints(16).Y = -250
            MyUniverse.MySymbolPoints(17).X = -250 : MyUniverse.MySymbolPoints(17).Y = -200
            MyUniverse.MySymbolPoints(18).X = -250 : MyUniverse.MySymbolPoints(18).Y = -150
            MyUniverse.MySymbolPoints(19).X = -250 : MyUniverse.MySymbolPoints(19).Y = -50
            MyUniverse.MySymbolPoints(20).X = -250 : MyUniverse.MySymbolPoints(20).Y = 50
            MyUniverse.MySymbolPoints(21).X = -250 : MyUniverse.MySymbolPoints(21).Y = 150
            MyUniverse.MySymbolPoints(22).X = -250 : MyUniverse.MySymbolPoints(22).Y = 200
            MyUniverse.MySymbolPoints(23).X = -200 : MyUniverse.MySymbolPoints(23).Y = 250
            MyUniverse.MySymbolPoints(24).X = -100 : MyUniverse.MySymbolPoints(24).Y = 250
            MyUniverse.MySymbolPoints(25).X = -50 : MyUniverse.MySymbolPoints(25).Y = 250
            MyUniverse.MySymbolPoints(26).X = 50 : MyUniverse.MySymbolPoints(26).Y = 250
            MyUniverse.MySymbolPoints(27).X = 100 : MyUniverse.MySymbolPoints(27).Y = 250
            MyUniverse.MySymbolPoints(28).X = 200 : MyUniverse.MySymbolPoints(28).Y = 250
            MyUniverse.MySymbolPoints(29).X = 250 : MyUniverse.MySymbolPoints(29).Y = 200
            MyUniverse.MySymbolPoints(30).X = 250 : MyUniverse.MySymbolPoints(30).Y = 150
            MyUniverse.MySymbolPoints(31).X = 250 : MyUniverse.MySymbolPoints(31).Y = 50
            MyUniverse.MySymbolPoints(32).X = 250 : MyUniverse.MySymbolPoints(32).Y = -50
            MyUniverse.MySymbolPoints(33).X = 250 : MyUniverse.MySymbolPoints(33).Y = -150
            MyUniverse.MySymbolPoints(34).X = 250 : MyUniverse.MySymbolPoints(34).Y = -200
            MyUniverse.MySymbolPoints(35).X = 200 : MyUniverse.MySymbolPoints(35).Y = -250
            MyUniverse.MySymbolPoints(36).X = 100 : MyUniverse.MySymbolPoints(36).Y = -250
            MyUniverse.MySymbolPoints(37).X = 50 : MyUniverse.MySymbolPoints(37).Y = -250
            MyUniverse.MySymbolPoints(38).X = -50 : MyUniverse.MySymbolPoints(38).Y = -250
            MyUniverse.MySymbolPoints(39).X = -100 : MyUniverse.MySymbolPoints(39).Y = -250
            MyUniverse.MySymbolPoints(40).X = -200 : MyUniverse.MySymbolPoints(40).Y = -250
            MyUniverse.MySymbolPoints(41).X = -200 : MyUniverse.MySymbolPoints(41).Y = -200
            MyUniverse.MySymbolPoints(42).X = -200 : MyUniverse.MySymbolPoints(42).Y = -150
            MyUniverse.MySymbolPoints(43).X = -200 : MyUniverse.MySymbolPoints(43).Y = -100
            MyUniverse.MySymbolPoints(44).X = -200 : MyUniverse.MySymbolPoints(44).Y = -50
            MyUniverse.MySymbolPoints(45).X = -200 : MyUniverse.MySymbolPoints(45).Y = 0
            MyUniverse.MySymbolPoints(46).X = -200 : MyUniverse.MySymbolPoints(46).Y = 50
            MyUniverse.MySymbolPoints(47).X = -200 : MyUniverse.MySymbolPoints(47).Y = 100
            MyUniverse.MySymbolPoints(48).X = -200 : MyUniverse.MySymbolPoints(48).Y = 150
            MyUniverse.MySymbolPoints(49).X = -200 : MyUniverse.MySymbolPoints(49).Y = 200
            MyUniverse.MySymbolPoints(50).X = -150 : MyUniverse.MySymbolPoints(50).Y = -200
            MyUniverse.MySymbolPoints(51).X = -150 : MyUniverse.MySymbolPoints(51).Y = -150
            MyUniverse.MySymbolPoints(52).X = -150 : MyUniverse.MySymbolPoints(52).Y = -100
            MyUniverse.MySymbolPoints(53).X = -150 : MyUniverse.MySymbolPoints(53).Y = -50
            MyUniverse.MySymbolPoints(54).X = -150 : MyUniverse.MySymbolPoints(54).Y = 0
            MyUniverse.MySymbolPoints(55).X = -150 : MyUniverse.MySymbolPoints(55).Y = 50
            MyUniverse.MySymbolPoints(56).X = -150 : MyUniverse.MySymbolPoints(56).Y = 100
            MyUniverse.MySymbolPoints(57).X = -150 : MyUniverse.MySymbolPoints(57).Y = 150
            MyUniverse.MySymbolPoints(58).X = -150 : MyUniverse.MySymbolPoints(58).Y = 200
            MyUniverse.MySymbolPoints(59).X = -100 : MyUniverse.MySymbolPoints(59).Y = -200
            MyUniverse.MySymbolPoints(60).X = -100 : MyUniverse.MySymbolPoints(60).Y = -150
            MyUniverse.MySymbolPoints(61).X = -100 : MyUniverse.MySymbolPoints(61).Y = -100
            MyUniverse.MySymbolPoints(62).X = -100 : MyUniverse.MySymbolPoints(62).Y = -50
            MyUniverse.MySymbolPoints(63).X = -100 : MyUniverse.MySymbolPoints(63).Y = 0
            MyUniverse.MySymbolPoints(64).X = -100 : MyUniverse.MySymbolPoints(64).Y = 50
            MyUniverse.MySymbolPoints(65).X = -100 : MyUniverse.MySymbolPoints(65).Y = 100
            MyUniverse.MySymbolPoints(66).X = -100 : MyUniverse.MySymbolPoints(66).Y = 150
            MyUniverse.MySymbolPoints(67).X = -100 : MyUniverse.MySymbolPoints(67).Y = 200
            MyUniverse.MySymbolPoints(68).X = -50 : MyUniverse.MySymbolPoints(68).Y = -200
            MyUniverse.MySymbolPoints(69).X = -50 : MyUniverse.MySymbolPoints(69).Y = -150
            MyUniverse.MySymbolPoints(70).X = -50 : MyUniverse.MySymbolPoints(70).Y = -100
            MyUniverse.MySymbolPoints(71).X = -50 : MyUniverse.MySymbolPoints(71).Y = -50
            MyUniverse.MySymbolPoints(72).X = -50 : MyUniverse.MySymbolPoints(72).Y = 0
            MyUniverse.MySymbolPoints(73).X = -50 : MyUniverse.MySymbolPoints(73).Y = 50
            MyUniverse.MySymbolPoints(74).X = -50 : MyUniverse.MySymbolPoints(74).Y = 100
            MyUniverse.MySymbolPoints(75).X = -50 : MyUniverse.MySymbolPoints(75).Y = 150
            MyUniverse.MySymbolPoints(76).X = -50 : MyUniverse.MySymbolPoints(76).Y = 200
            MyUniverse.MySymbolPoints(77).X = 0 : MyUniverse.MySymbolPoints(77).Y = -200
            MyUniverse.MySymbolPoints(78).X = 0 : MyUniverse.MySymbolPoints(78).Y = -150
            MyUniverse.MySymbolPoints(79).X = 0 : MyUniverse.MySymbolPoints(79).Y = -100
            MyUniverse.MySymbolPoints(80).X = 0 : MyUniverse.MySymbolPoints(80).Y = -50
            MyUniverse.MySymbolPoints(81).X = 0 : MyUniverse.MySymbolPoints(81).Y = 0
            MyUniverse.MySymbolPoints(82).X = 0 : MyUniverse.MySymbolPoints(82).Y = 50
            MyUniverse.MySymbolPoints(83).X = 0 : MyUniverse.MySymbolPoints(83).Y = 100
            MyUniverse.MySymbolPoints(84).X = 0 : MyUniverse.MySymbolPoints(84).Y = 150
            MyUniverse.MySymbolPoints(85).X = 0 : MyUniverse.MySymbolPoints(85).Y = 200
            MyUniverse.MySymbolPoints(86).X = 50 : MyUniverse.MySymbolPoints(86).Y = -200
            MyUniverse.MySymbolPoints(87).X = 50 : MyUniverse.MySymbolPoints(87).Y = -150
            MyUniverse.MySymbolPoints(88).X = 50 : MyUniverse.MySymbolPoints(88).Y = -100
            MyUniverse.MySymbolPoints(89).X = 50 : MyUniverse.MySymbolPoints(89).Y = -50
            MyUniverse.MySymbolPoints(90).X = 50 : MyUniverse.MySymbolPoints(90).Y = 0
            MyUniverse.MySymbolPoints(91).X = 50 : MyUniverse.MySymbolPoints(91).Y = 50
            MyUniverse.MySymbolPoints(92).X = 50 : MyUniverse.MySymbolPoints(92).Y = 100
            MyUniverse.MySymbolPoints(93).X = 50 : MyUniverse.MySymbolPoints(93).Y = 150
            MyUniverse.MySymbolPoints(94).X = 50 : MyUniverse.MySymbolPoints(94).Y = 200
            MyUniverse.MySymbolPoints(95).X = 100 : MyUniverse.MySymbolPoints(95).Y = -200
            MyUniverse.MySymbolPoints(96).X = 100 : MyUniverse.MySymbolPoints(96).Y = -150
            MyUniverse.MySymbolPoints(97).X = 100 : MyUniverse.MySymbolPoints(97).Y = -100
            MyUniverse.MySymbolPoints(98).X = 100 : MyUniverse.MySymbolPoints(98).Y = -50
            MyUniverse.MySymbolPoints(99).X = 100 : MyUniverse.MySymbolPoints(99).Y = 0
            MyUniverse.MySymbolPoints(100).X = 100 : MyUniverse.MySymbolPoints(100).Y = 50
            MyUniverse.MySymbolPoints(101).X = 100 : MyUniverse.MySymbolPoints(101).Y = 100
            MyUniverse.MySymbolPoints(102).X = 100 : MyUniverse.MySymbolPoints(102).Y = 150
            MyUniverse.MySymbolPoints(103).X = 100 : MyUniverse.MySymbolPoints(103).Y = 200
            MyUniverse.MySymbolPoints(104).X = 150 : MyUniverse.MySymbolPoints(104).Y = -200
            MyUniverse.MySymbolPoints(105).X = 150 : MyUniverse.MySymbolPoints(105).Y = -150
            MyUniverse.MySymbolPoints(106).X = 150 : MyUniverse.MySymbolPoints(106).Y = -100
            MyUniverse.MySymbolPoints(107).X = 150 : MyUniverse.MySymbolPoints(107).Y = -50
            MyUniverse.MySymbolPoints(108).X = 150 : MyUniverse.MySymbolPoints(108).Y = 0
            MyUniverse.MySymbolPoints(109).X = 150 : MyUniverse.MySymbolPoints(109).Y = 50
            MyUniverse.MySymbolPoints(110).X = 150 : MyUniverse.MySymbolPoints(110).Y = 100
            MyUniverse.MySymbolPoints(111).X = 150 : MyUniverse.MySymbolPoints(111).Y = 150
            MyUniverse.MySymbolPoints(112).X = 150 : MyUniverse.MySymbolPoints(112).Y = 200
            MyUniverse.MySymbolPoints(113).X = 200 : MyUniverse.MySymbolPoints(113).Y = -200
            MyUniverse.MySymbolPoints(114).X = 200 : MyUniverse.MySymbolPoints(114).Y = -150
            MyUniverse.MySymbolPoints(115).X = 200 : MyUniverse.MySymbolPoints(115).Y = -100
            MyUniverse.MySymbolPoints(116).X = 200 : MyUniverse.MySymbolPoints(116).Y = -50
            MyUniverse.MySymbolPoints(117).X = 200 : MyUniverse.MySymbolPoints(117).Y = 0
            MyUniverse.MySymbolPoints(118).X = 200 : MyUniverse.MySymbolPoints(118).Y = 50
            MyUniverse.MySymbolPoints(119).X = 200 : MyUniverse.MySymbolPoints(119).Y = 100
            MyUniverse.MySymbolPoints(120).X = 200 : MyUniverse.MySymbolPoints(120).Y = 150
            MyUniverse.MySymbolPoints(121).X = 200 : MyUniverse.MySymbolPoints(121).Y = 200

        End Sub


        Public Shared Function FillImportLine() As ImportLineStruct
            MyTrace(204, "FillImportLine", 28)

            FillImportLine.Idt = -1
            FillImportLine.LastName = ""
            FillImportLine.IndexName = -1
            FillImportLine.IndexSymbol = -1
            FillImportLine.TopMost = -1


            FillImportLine.Inputs.Inputline = "?"
            FillImportLine.Inputs.KeyLine = "?"
            FillImportLine.Inputs.KeyWord = "?"
            FillImportLine.Inputs.LineNumberIn = 0

            FillImportLine.Temps.TempInteger1 = -1
            FillImportLine.Temps.TempString2 = "off"
            FillImportLine.Temps.TempFormat = "?"
            FillImportLine.Temps.TempRecord = -1
            MyUniverse.SysGen.UseX1 = MyMinMax(MyUniverse.SysGen.UseX1, 1000, MyUniverse.SysGen.UseX1 + 1000)
            MyUniverse.SysGen.UseY1 = MyMinMax(MyUniverse.SysGen.UseY1, 1000, MyUniverse.SysGen.MaxSymbolInYSpacing)

            FillImportLine.MyRecord.Coded = 0
            FillImportLine.MyRecord.X1 = -1
            FillImportLine.MyRecord.Y1 = -1
            FillImportLine.MyRecord.X2_io = "0"
            FillImportLine.MyRecord.Y2_dt = "0"
            FillImportLine.MyRecord.NameOfPoint = "?"

        End Function


        'Public Shared Sub ImportLineFromLine(where As PictureBox, CodeLine As String)
        '    'Dim MySS As ImportLineStruct
        '    MyTrace(205, "ImportLineFromLine", 7)
        '
        '            MyUniverse.MySS = FillImportLine()
        '            MyUniverse.MySS.Inputs.Inputline = CodeLine
        '            MyUniverse.MySS.Inputs.KeyLine = CodeLine
        '            ImportLine(where)
        '        End Sub



        Public Shared Sub ImportLine(where As PictureBox)
            MyTrace(206, "ImportLine", 8046 - 7800)

            MyMakeArraySizesBigger()
            MyUniverse.MySS.Inputs.KeyWord = LCase(Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters))
            MyUniverse.MySS.Inputs.KeyLine = TrimEqual(MyUniverse.MySS.Inputs.KeyLine)
            If Int(MyUniverse.MySS.Inputs.LineNumberIn / 100) * 100 = MyUniverse.MySS.Inputs.LineNumberIn Then
                DisplayMyStatus("At Line " & MyUniverse.MySS.Inputs.LineNumberIn)
            End If
            Select Case LCase(Trim(MyUniverse.MySS.Inputs.KeyWord))
                Case "/ignore"
                    MyUniverse.MySS.Inputs.KeyLine = ""' Ignore everything on this
                Case "/set"
                    SetOptions(MyUniverse.MySS.Inputs.KeyLine)
                Case "/option"
                    MyUniverse.MySS.Temps.TempFormat = FormatOption
                    If ThisIsANumber(MyUniverse.MySS.Inputs.KeyLine) Then
                        DoOption(MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyUniverse.MySS.Temps.TempInteger1 = Popvalue(MyUniverse.MySS.Inputs.KeyLine)

                        MyUniverse.MySS.Temps.TempInt32 = Popvalue(MyUniverse.MySS.Inputs.KeyLine)
                        If MyUniverse.MySS.Temps.TempInt32 = 0 Then
                            MyUniverse.MySS.Temps.TempString2 = "off"
                        Else
                            MyUniverse.MySS.Temps.TempString2 = "on"
                        End If

                        If MyUniverse.MySS.Temps.TempInteger1 < 1000 Then
                            DoOption(MyUniverse.MySS.Temps.TempInteger1, MyUniverse.MySS.Temps.TempString2, MyUniverse.MySS.Inputs.KeyLine)
                        Else
                            BitSet(MyMinMax(MyUniverse.MySS.Temps.TempInteger1, 1, 9999), MyUniverse.MySS.Temps.TempString2)
                        End If
                    End If
                Case "/color"
                    MyUniverse.MySS.Temps.TempFormat = formatColor
                    ImportColors(MyUniverse.MySS.Inputs.KeyLine)
                    ShowSorts("Color", SortColors())'20200702
                Case "/datatype"
                    MyUniverse.MySS.Temps.TempFormat = formatDatatype
                    ImportDataTypes(MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn)
                    SortDataType()
                Case "/name"
                    MyUniverse.MySS.Temps.TempFormat = formatSymbolName
                    ShowSorts("Named", MyReSort("Named", Named_FileSyntax, Named_FileSyntax_Isam, TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)))
                    ShowSorts("Named", MyReSort("Named", Named_FileSymbolName, Named_File_iSAM, TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)))
                    MyUniverse.MySS.LastName = Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)
                    MakeItTheBiggestSymbolNumber(MyUniverse.MySS.LastName)
                    CheckForAnySortNeeded("", 219)
                    ' ***********************************************************
                    ' is returning the wrong should be 1 and returns 0
                    MyUniverse.MySS.IndexName = FindIndexIniSAMTable("Named", "add", Named_FileSymbolName, Named_File_iSAM, MyUniverse.MySS.LastName)
                    '*********************************************************
                    If MyUniverse.MySS.IndexName = constantMyErrorCode Then
                        Abug(923, MyUniverse.MySS.Inputs.Inputline, 1, 1)
                        MyUniverse.MySS.IndexName = AddNewNamedRecord(MyUniverse.MySS.LastName, "?", "?", "?", "?", "?", "?", "?", "?", "?")
                        MyUniverse.MySS.IndexName = TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                        MyUniverse.MySS.IndexName = FindIndexIniSAMTable("Named", "Don Add Find Again after Sort", Named_FileSymbolName, Named_File_iSAM, MyUniverse.MySS.LastName)
                        CheckForAnySortNeeded("", 223)
                    End If
                    If MyUniverse.MySS.IndexName = constantMyErrorCode Then
                        Abug(922, MyUniverse.MySS.Inputs.Inputline, 0, 0) ' We should find it after adding it
                        MyMsgCtr("Import", 1100, MyUniverse.MySS.LastName, MyUniverse.MySS.Inputs.Inputline, MyUniverse.MySS.Inputs.LineNumberIn.ToString, "", "", "", "", "", "")
                    Else
                        ' Get the Direct Array Indexes
                        If Named_TableSymbolName(MyUniverse.MySS.IndexName) <> MyUniverse.MySS.LastName Then
                            Abug(921, MyUniverse.MySS.Inputs.Inputline, 3, 3) ' we should always have the name after we have just found it'
                        End If
                        'Named_TableSymbolName(MyUniverse.MySS.indexname, MyUniverse.MySS.lastname) ' why are we replacing it when we just found it?
                        MyMakeArraySizesBigger()
                        If PrintAbleNull(MyUniverse.MySS.Inputs.KeyLine) = "_" Then ' This is testing for all options that should be in this symbol
                            ' MyMsgCtr("Import", 1414, KeyLine, 18, Myss3.Inputs.Inputline, TempFormat, MyUniverse.MySS.Inputs.LineNumberIn.tostring , "", "", "", "")
                            MyUniverse.MySS.Inputs.KeyLine = "?" & MyUniverse.MySS.LastName
                        End If
                        'If PrintAbleNull(MyUniverse.MySS.Inputs.keyline) = "_" Then
                        'MyMsgCtr("Import", 1414, MyUniverse.MySS.Inputs.keyline, 19, Myss3.Inputs.Inputline, TempFormat, MyUniverse.MySS.Inputs.LineNumberIn.tostring , "", "", "", "")
                        'MyUniverse.MySS.Inputs.keyline = "?" & MyUniverse.MySS.lastname
                        'End If
                        MyUniverse.MySS.IndexSymbol = FindInSymbolList(MyUniverse.MySS.LastName)
                        If MyUniverse.MySS.IndexSymbol = constantMyErrorCode Then
                            AddNEWSymbolRecord(MyUniverse.MySS.LastName, "/name", 0, 0, "0", "0", MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn)
                            MyUniverse.MySS.IndexSymbol = TopOfFile("Symbol", Symbol_FileCoded)
                        End If
                        If MyUniverse.MySS.IndexSymbol <> constantMyErrorCode Then ' replace any information that is already there (If added, then is always something there
                            'Debug, check if this is updating the table after finding it above
                            Symbol_FileCoded(MyUniverse.MySS.IndexSymbol) = MyKeyword_2_Byte("/name") ' KeyConstName '"/name"
                            'Symbol_TableSymbolName(MyUniverse.MySS.indexsymbol, MyUniverse.MySS.lastname)' Did not need to do it again!!!!!
                            Symbol_Table_NameOfPoint(MyUniverse.MySS.IndexSymbol, MyUniverse.MySS.Inputs.KeyLine)
                            Symbol_TableX1(MyUniverse.MySS.IndexSymbol, 1)
                            Symbol_TableY1(MyUniverse.MySS.IndexSymbol, 1)
                            Symbol_TableX2_io(MyUniverse.MySS.IndexSymbol, 1)
                            Symbol_TableY2_dt(MyUniverse.MySS.IndexSymbol, 1)
                            Symbol_TableX1(MyUniverse.MySS.IndexSymbol, 1)
                        Else
                            MyMsgCtr("Import", 1411, MyUniverse.MySS.IndexSymbol.ToString, TopOfFile("Symbol", Symbol_FileCoded).ToString, MyUniverse.MySS.Inputs.KeyWord, MyUniverse.MySS.Inputs.Inputline, MyUniverse.MySS.Inputs.LineNumberIn.ToString, "", "", "", "")
                        End If
                    End If
                Case "/point"
                    MyUniverse.MySS.Temps.TempFormat = formatPoint
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.MyRecord.X1 = Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine))
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.MyRecord.Y1 = Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine))
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.MyRecord.X2_io = Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.MyRecord.Y2_dt = Trim(Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters))
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.MyRecord.NameOfPoint = MyUniverse.MySS.Inputs.KeyLine
                    MyUniverse.MySS.Inputs.KeyLine = XTrim(MyUniverse.MySS.Inputs.KeyLine)

                    ' This will inser them backwards, but who cares? (It should not make a difference because each record should be independant.
                    AddNEWSymbolRecord(MyUniverse.MySS.LastName, "/point", MyUniverse.MySS.MyRecord.X1, MyUniverse.MySS.MyRecord.Y1, MyUniverse.MySS.MyRecord.X2_io, MyUniverse.MySS.MyRecord.Y2_dt, MyUniverse.MySS.MyRecord.NameOfPoint, MyUniverse.MySS.Inputs.LineNumberIn)
                    CheckForAnySortNeeded("", 230)
                    MyUniverse.MySS.Idt = MyMinMax(Symbol_TableY2_dt(TopOfFile("Symbol", Symbol_FileCoded)), 2, UBound(DataType_FileName) - 1)
                    Symbol_Table_NameOfPoint(TopOfFile("Symbol", Symbol_FileCoded), MyUniverse.MySS.Inputs.KeyLine) ' For A point
                    ShowSorts("DataType", MyReSort("DataType", DataType_FileName, DataType_iSAM_, MyUniverse.MySS.Idt)) '3/12/19 only sort added 
                Case "/line"
                    MyUniverse.MySS.Temps.TempFormat = formatLine
                    MyUniverse.MySS.TopMost = NewTopOfFile("Symbol", Symbol_FileCoded)
                    Symbol_FileSymbolName(MyUniverse.MySS.TopMost) = "L_" & MyUniverse.MySS.TopMost ' No lines have input names, only color, so this is to allow other sorts to work
                    Symbol_TableCode(MyUniverse.MySS.TopMost, MyKeyword_2_Byte(MyUniverse.MySS.Inputs.KeyWord))
                    Symbol_TableX1(MyUniverse.MySS.TopMost, MyMinMax(Snap(PopValue(MyUniverse.MySS.Inputs.KeyLine)), -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter))
                    Symbol_TableY1(MyUniverse.MySS.TopMost, MyMinMax(Snap(PopValue(MyUniverse.MySS.Inputs.KeyLine)), -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter))
                    Symbol_TableX2_io(MyUniverse.MySS.TopMost, MyMinMax(Snap(PopValue(MyUniverse.MySS.Inputs.KeyLine)), -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter))
                    Symbol_TableY2_dt(MyUniverse.MySS.TopMost, MyMinMax(Snap(PopValue(MyUniverse.MySS.Inputs.KeyLine)), -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter))
                    Symbol_Table_NameOfPoint(MyUniverse.MySS.TopMost, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)) ' Color
                    If MyUniverse.MySS.Inputs.KeyLine = "" Then
                        Symbol_TableSymbolName(MyUniverse.MySS.TopMost, "Line" & TopOfFile("Symbol", Symbol_FileCoded))
                    Else
                        Symbol_TableSymbolName(MyUniverse.MySS.TopMost, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)) ' Optional, but should never be a named line, Only Paths
                    End If
                    MyMakeArraySizesBigger()
                Case "/path"
                    MyUniverse.MySS.Temps.TempFormat = formatPath
                    MyUniverse.MySS.Temps.TempRecord = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded))
                    FlowChart_TableCode_X(MyUniverse.MySS.Temps.TempRecord, "/path") 'KeyConstPath)
                    FlowChart_TableNamed(MyUniverse.MySS.Temps.TempRecord, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)) 'name last
                    FlowChart_TableX1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableY1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableX2_Rotation(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableY2_Option(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_Table_DataType(MyUniverse.MySS.Temps.TempRecord, Trim(Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters))) ' Datatype
                    ShowSorts("FlowChart", ReSortFlowChart(MyUniverse.MySS.Temps.TempRecord))
                    '20200709                            PaintAll(Where, myy.temps.temprecord, myy.temps.temprecord)
                    MyMakeArraySizesBigger()
                    PaintAll(where, MyUniverse.MySS.Temps.TempRecord, MyUniverse.MySS.Temps.TempRecord)
                Case "/use"
                    MyUniverse.MySS.Temps.TempFormat = formatUse 'hack
                    MyUniverse.MySS.Temps.TempRecord = NewFlowChartRecord(NewTopOfFile("FlowChart", FlowChart_FileCoded))
                    FlowChart_TableCode_X(MyUniverse.MySS.Temps.TempRecord, "/use")
                    FlowChart_TableNamed(MyUniverse.MySS.Temps.TempRecord, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)) 'Name First
                    FlowChart_TableX1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableY1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableX2_Rotation(MyUniverse.MySS.Temps.TempRecord, MyEnumValue(Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters), SymbolScreen.ToolStripDropDownRotation))
                    FlowChart_Table_DataType(MyUniverse.MySS.Temps.TempRecord, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters)) ' later for dynamic symbols
                    ShowSorts("FlowChart", ReSortFlowChart(MyUniverse.MySS.Temps.TempRecord))
                    PaintAll(where, MyUniverse.MySS.Temps.TempRecord, MyUniverse.MySS.Temps.TempRecord)
                Case "/thiscode" ' Ignore it
                    MyUniverse.MySS.Temps.TempFormat = FormatThisCode
                    If TopOfFile("FlowChart", FlowChart_FileCoded) > 0 Then
                        FlowChart_Table_DataType(TopOfFile("FlowChart", FlowChart_FileCoded), FlowChart_Table_DataType(TopOfFile("FlowChart", FlowChart_FileCoded)) & vbCrLf & MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1402, "/thiscode" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If

                Case "/programtext", "/code"
                    MyUniverse.MySS.Temps.TempFormat = formatProgramText
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableProgramText(MyUniverse.MySS.IndexName, Named_TableProgramText(MyUniverse.MySS.IndexName) & MyUniverse.MySS.Inputs.KeyLine & ComputerLanguageMultiLine())
                    Else
                        MyMsgCtr("Import", 1403, "/programtext", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/syntax"
                    MyUniverse.MySS.Temps.TempFormat = FormatSyntaxKeyWord
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableSyntax(MyUniverse.MySS.IndexName, Named_TableSyntax(MyUniverse.MySS.IndexName) & vbCr & MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1403, "/syntax", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If

                Case "/filename"
                    MyUniverse.MySS.Temps.TempFormat = formatNameOfFile
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableNameOfFile(MyUniverse.MySS.IndexName, MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1404, "/filename", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If



                    ' Needdc To change the options if it is already there 
                Case "/language"
                    MyUniverse.MySS.Temps.TempFormat = formatLanguage
                    Dim X As String
                    X = MyUniverse.MySS.Inputs.KeyLine ' Save The entire line as input
                    MyUniverse.MySS.Inputs.KeyWord = Pop(MyUniverse.MySS.Inputs.KeyLine, FD) ' Get Which Language
                    ComputerLanguageTurnedOn(MyUniverse.MySS.Inputs.KeyWord)
                    SelectInToolStripDropDownButton(OptionScreen.ToolStripDropDownComputerLanguage, MyUniverse.MySS.Inputs.KeyWord)
                    ComputerLanguageTurnedOn(MyUniverse.MySS.Inputs.KeyWord)
                    UpDateComputerLanguage()
                    If Len(MyUniverse.MySS.Inputs.KeyLine) > 10 Then ' If there is more than ten letters then replace the language with this new thing.
                        If OptionScreen.ToolStripDropDownComputerLanguage.Text = "" Then
                            'OptionScreen.ToolStripDropDownComputerLanguageX.DropDownItems.Item(SymbolScreen.ToolStripDropDownComputerLanguageX.SelectedIndex) = X ' Replace it
                            SelectInToolStripDropDownButton(OptionScreen.ToolStripDropDownComputerLanguage, X)
                        End If
                    End If

                    AddAtomsToKeywordORoperatorsORFunctionList("Keywords", MyUniverse.MySS.Inputs.KeyWord, Language_KeyWords, FileInputOutputScreen.ProgressBarKeyWords)
                    ' still need to replace the language line if all new inputs are here

                    'Should this show form be here?
                    ShowAllForms(HideScreen, ShowScreen, HideScreen, ShowScreen, LeaveScreenAlone, HideScreen)

                    Application.DoEvents()
                Case "/stroke"
                    MyUniverse.MySS.Temps.TempFormat = formatStroke
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableStroke(MyUniverse.MySS.IndexName, MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1406, "/stroke" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/notes"
                    MyUniverse.MySS.Temps.TempFormat = formatNotes
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableNotes(MyUniverse.MySS.IndexName, Named_TableNotes(MyUniverse.MySS.IndexName) & vbCr & PopLine(MyUniverse.MySS.Inputs.KeyLine))
                    Else
                        MyMsgCtr("Import", 1407, "/notes" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/version"
                    MyUniverse.MySS.Temps.TempFormat = formatVersion
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableVersion(MyUniverse.MySS.IndexName, MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1408, "/version" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/author"
                    MyUniverse.MySS.Temps.TempFormat = formatAuthor
                    If MyUniverse.MySS.IndexName > 0 Then
                        Named_TableAuthor(MyUniverse.MySS.IndexName, MyUniverse.MySS.Inputs.KeyLine)
                    Else
                        MyMsgCtr("Import", 1409, "/author" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/opcode"
                    MyUniverse.MySS.Temps.TempFormat = formatOpcode
                    If MyUniverse.MySS.IndexName > 0 Then
                        If Len(Named_TableOpCode(MyUniverse.MySS.IndexName)) > 0 Then
                            Named_TableOpCode(MyUniverse.MySS.IndexName, Named_TableOpCode(MyUniverse.MySS.IndexName) & ComputerLanguageMultiLine() & MyUniverse.MySS.Inputs.KeyLine)
                        Else
                            Named_TableOpCode(MyUniverse.MySS.IndexName, MyUniverse.MySS.Inputs.KeyLine)
                        End If
                    Else
                        MyMsgCtr("Import", 1410, "/opcode" & " : ", MyUniverse.MySS.Inputs.KeyWord & "=" & MyUniverse.MySS.Inputs.KeyLine, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.LastName, "", "", "", "", "")
                    End If
                Case "/constant"
                    MyUniverse.MySS.Temps.TempFormat = formatConstant
                    MyUniverse.MySS.Temps.TempRecord = TopOfFile("FlowChart", FlowChart_FileCoded)
                    FlowChart_TableCode_X(MyUniverse.MySS.Temps.TempRecord, MyUniverse.MySS.Inputs.KeyWord)
                    FlowChart_TableX1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_TableY1(MyUniverse.MySS.Temps.TempRecord, Snap(Popvalue(MyUniverse.MySS.Inputs.KeyLine)))
                    FlowChart_Table_DataType(MyUniverse.MySS.Temps.TempRecord, Pop(MyUniverse.MySS.Inputs.KeyLine, ConstantDelimeters))
                    FlowChart_TableNamed(MyUniverse.MySS.Temps.TempRecord, MyUniverse.MySS.Inputs.KeyLine)
                    ShowSorts("FlowChart", ReSortFlowChart(MyUniverse.MySS.Temps.TempRecord))
                    CheckForAnySortNeeded("", 231)
                    ReSetScrollBars(where, MyUniverse.MySS.Temps.TempRecord)
                Case "/error"
                    MyUniverse.MySS.Temps.TempFormat = FormatError
                            'ignore error imports
                Case "/delete"
                    MyUniverse.MySS.Temps.TempFormat = FormatDelete
                            ' ignore deleted stuff also
                Case "/keyword"
                    ' Bug keywords are not being sorted
                    FindingMyBugs(10) 'hack Least amount of checking here
                    MyUniverse.MySS.Inputs.KeyLine = Trim(Mid(MyUniverse.MySS.Inputs.Inputline, Len("/keyword=") + 1, Len(MyUniverse.MySS.Inputs.Inputline)))
                    If MyUniverse.MySS.Inputs.KeyLine = ComputerLanguageComment() Then
                        AWarning(639, "Comment keyword is already inside the language selection", MyUniverse.MySS.Inputs.KeyLine, ComputerLanguageComment())
                    Else
                        AddAtomsToKeywordORoperatorsORFunctionList("keywords", MyUniverse.MySS.Inputs.KeyLine, Language_KeyWords, FileInputOutputScreen.ProgressBarKeyWords)
                        Pop1(MyUniverse.MySS.Inputs.KeyLine, FD)
                    End If
                Case "/operator"
                    'Pop(MyUniverse.MySS.Inputs.keyline, ConstantDelimeters) ' get rid of the language name first ' removed, language becomes a keyword
                    FindingMyBugs(10) 'hack Least amount of checking here
                    MyUniverse.MySS.Inputs.KeyLine = Trim(Mid(MyUniverse.MySS.Inputs.Inputline, Len("/operator=") + 1, Len(MyUniverse.MySS.Inputs.Inputline)))
                    AddAtomsToKeywordORoperatorsORFunctionList("Operators", MyTrim(MyUniverse.MySS.Inputs.KeyLine), Language_Operators, FileInputOutputScreen.ProgressBarOperators) ' Get rid of the '=' sign
                    Pop1(MyUniverse.MySS.Inputs.KeyLine, FD)
                Case "/function"
                    FindingMyBugs(10) 'hack Least amount of checking here
                    'Pop(MyUniverse.MySS.Inputs.keyline, ConstantDelimeters) ' get rid of the language name first ' removed, language becomes a keyword
                    MyUniverse.MySS.Inputs.KeyLine = Trim(Mid(MyUniverse.MySS.Inputs.Inputline, Len("/function=") + 1, Len(MyUniverse.MySS.Inputs.Inputline)))
                    AddAtomsToKeywordORoperatorsORFunctionList("Functions", Trim(MyUniverse.MySS.Inputs.KeyLine), Language_Functions, FileInputOutputScreen.ProgressBarFunctions) ' get rid of the equal sign and any white space
                    Pop1(MyUniverse.MySS.Inputs.KeyLine, FD)
                Case "", Nothing '2020 07 31
                    'if nothing then do nothing.
                Case "/endoffile"
                Case Else
                    SortALLiSAM()
                    Select Case MyMsgCtr("Import", 1211, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.Inputs.KeyWord, MyUniverse.MySS.Inputs.Inputline, MyUniverse.MySS.Inputs.LineNumberIn.ToString, MyUniverse.MySS.Inputs.KeyLine, "", "", "", "")
                        Case vbNo

                        Case vbOK, vbYes
                            MyMakeArraySizesBigger()
                            FlowChart_TableCode_X(TopOfFile("FlowChart", FlowChart_FileCoded), "/error")
                            FlowChart_Table_DataType(TopOfFile("FlowChart", FlowChart_FileCoded), MyUniverse.MySS.Inputs.Inputline)
                            SortALLiSAM()
                        Case vbCancel
                            Init()
                            Exit Sub
                            '****************************************************
                        Case Else
                            Abug(999, "Invalid inputs to program", MyUniverse.MySS.Inputs.KeyWord, MyUniverse.MySS.Inputs.KeyWord)
                    End Select
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack
            End Select
        End Sub




        'Routine This reads in an file with all of the information for a FlowChart & symbol.
        Public Shared Sub Import(Where As PictureBox, InputFileName As String) ' Yes I know its spelled Import, but I did not want to confuse it between the two
            MyTrace(207, "Import", 7308 - 6992)

            MyUniverse.SysGen.DontAskToAdd = True
            ' Start off with junk
            MyUniverse.MySS = FillImportLine()

            ShowAllForms(ShowScreen, HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, HideScreen)
            Using reader As System.IO.TextReader = System.IO.File.OpenText(InputFileName)

                MyUniverse.MySS.Inputs.LineNumberIn = 1
                MyUniverse.MySS.Inputs.Inputline = "Junk" ' Used to get through the first time only

                Do While MyUniverse.MySS.Inputs.Inputline <> Nothing
                    MyUniverse.MySS.Inputs.Inputline = reader.ReadLine()
                    MyUniverse.MySS.Inputs.KeyLine = MyUniverse.MySS.Inputs.Inputline
                    MyUniverse.MySS.Inputs.KeyLine = MyFixLine(MyUniverse.MySS.Inputs.KeyLine)
                    MyUniverse.MySS.Inputs.LineNumberIn = MyUniverse.MySS.Inputs.LineNumberIn + 1
                    ' Does all of the work
                    MyMakeArraySizesBigger()

                    DisplayMyStatus(MyUniverse.MySS.Inputs.LineNumberIn & " : " & MyUniverse.MySS.Inputs.KeyLine)
                    ImportLine(Where)
                Loop
                reader.Close()
            End Using
            '            ReSortFlowChart(TopOfFile("FlowChart",FlowChart_FileCoded))
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
            SortALLiSAM()
            ShowAllForms(ShowScreen, HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, HideScreen)
            MyUniverse.SysGen.DontAskToAdd = False
            '            Clear_Screen(FlowChartScreen.PictureBox1)
            ''''            MyMsgCtr("Import", 1134, MyUniverse.MySS.Inputs.LineNumberIn.ToString, TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM).ToString, TopOfFile("Symbol", Symbol_FileCoded).ToString, TopOfFile("FlowChart", FlowChart_FileCoded).ToString, TopOfFile("DataType", DataType_FileName, DataType_iSAM_).ToString, TopOfFile("Color", Color_FileName, Color_iSAM_).ToString, "", "", "")
            FindingMyBugs(10) 'hack Least amount of checking here
            PaintAll(Where, 1, TopOfFile("FlowChart", FlowChart_FileCoded)) '20200709
            DisplayMyStatus("Finished Importing.  Number of lines =" & MyUniverse.MySS.Inputs.LineNumberIn)
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
        End Sub



        ' A line (distance) between two record points
        Public Shared Function MyLine2(Idex As int32, Jdex As int32) As MyLineStructure
            MyTrace(208, "MyLine2", 7)

            MyLine2.a.X = FlowChart_TableX1(Idex)
            MyLine2.a.Y = FlowChart_TableY1(Idex)
            MyLine2.b.X = FlowChart_TableX1(Jdex)
            MyLine2.b.Y = FlowChart_TableY1(Jdex)
        End Function


        ' A line (distance) between two record points
        Public Shared Function MyLine1(a As MyPointStructure, b As MyPointStructure) As MyLineStructure
            MyTrace(209, "MyLine1", 7)

            MyLine1.a.X = a.X
            MyLine1.a.Y = a.Y
            MyLine1.b.X = b.X
            MyLine1.b.Y = b.Y
        End Function

        Public Shared Function MyLine1(X1 As int32, Y1 As int32, X2 As int32, Y2 As int32) As MyLineStructure
            MyTrace(211, "MyLine1", 7)

            MyLine1.a.X = X1
            MyLine1.a.Y = Y1
            MyLine1.b.X = X2
            MyLine1.b.Y = Y2
        End Function


        ' a line in one record
        Public Shared Function MyLine1(Idex As int32) As MyLineStructure
            MyTrace(212, "MyLine1", 7)

            MyLine1.a.X = FlowChart_TableX1(Idex)
            MyLine1.a.Y = FlowChart_TableY1(Idex)
            MyLine1.b.X = FlowChart_TableX2_Rotation(Idex)
            MyLine1.b.Y = FlowChart_TableY2_Option(Idex)
        End Function


        'Routine converts from two numbers (x, y) to structure xy
        Public Shared Function MyPoint1(X As int32, Y As int32) As MyPointStructure
            '''''''MyTrace(213, "MyPoint1", 6)
            MyPoint1.X = X
            MyPoint1.Y = Y
        End Function

        Public Shared Function MyPoint1(IndexFlowChart As int32) As MyPointStructure
            MyTrace(214, "MyPoint1", 6)

            MyPoint1.X = Snap(FlowChart_TableX1(IndexFlowChart))
            MyPoint1.Y = Snap(FlowChart_TableY1(IndexFlowChart))
        End Function

        Public Shared Function MyPoint1_1(IndexFlowChart As int32) As MyPointStructure
            MyTrace(215, "MyPoint1_1", 6)

            MyPoint1_1.X = Snap(FlowChart_TableX1(IndexFlowChart))
            MyPoint1_1.Y = Snap(FlowChart_TableY1(IndexFlowChart))
        End Function

        Public Shared Function MyPoint2(X As int32, Y As int32) As MyPointStructure
            MyTrace(216, "MyPoint2", 5)

            MyPoint2.X = X
            MyPoint2.Y = Y
        End Function

        Public Shared Function MyPoint2_1(IndexFlowChart As int32) As MyPointStructure
            MyTrace(217, "MyPoint2_1", 5)

            MyPoint2_1.X = Snap(FlowChart_TableX2_Rotation(IndexFlowChart))
            MyPoint2_1.Y = Snap(FlowChart_TableY2_Option(IndexFlowChart))
        End Function

        Public Shared Function MyPoint2_2(IndexFlowChart As int32) As MyPointStructure
            MyTrace(218, "MyPoint2_2", 91 - 86)
            MyPoint2_2.X = Snap(FlowChart_TableX2_Rotation(IndexFlowChart))
            MyPoint2_2.Y = Snap(FlowChart_TableY2_Option(IndexFlowChart))
        End Function

        Public Shared Function MyPoint3(X As int32, Y As int32) As MyPointStructure
            MyTrace(219, "MyPoint3", 98 - 93)

            MyMsgCtr("MyPoint3", 1321, X.ToString, Y.ToString, "", "", "", "", "", "", "")
            MyPoint3.X = X
            MyPoint3.Y = Y
        End Function


        'Routine 
        Public Shared Function MyFixLine(Astring As String) As String
            Dim Index As int32
            MyTrace(221, "MyFixLine", 35 - 2)

            MyFixLine = Astring
            For Index = 1 To Len(MyFixLine) - 1
                If Mid(MyFixLine, Index, 1) = FD Or Mid(MyFixLine, Index, 1) = FD Then
                    If Mid(MyFixLine, Index + 1, 1) = FD Or Mid(MyFixLine, Index + 1, 1) = FD Then
                        MyFixLine = Left(MyFixLine, Index) & " " & Mid(MyFixLine, Index + 1, Len(MyFixLine))
                    End If
                End If

                If Mid(MyFixLine, Index, 1) = FD Or Mid(MyFixLine, Index, 1) = FD Then
                    If Mid(MyFixLine, Index + 1, 1) = vbCr Then
                        MyFixLine = Left(MyFixLine, Index) & " " & Mid(MyFixLine, Index + 1, Len(MyFixLine))
                    End If
                End If

                If Mid(MyFixLine, Index, 1) = FD Or Mid(MyFixLine, Index, 1) = FD Then
                    If Mid(MyFixLine, Index + 1, 1) = vbLf Then
                        MyFixLine = Left(MyFixLine, Index) & " " & Mid(MyFixLine, Index + 1, Len(MyFixLine))
                    End If
                End If

                If Mid(MyFixLine, Index, 1) = FD Or Mid(MyFixLine, Index, 1) = FD Then
                    If Mid(MyFixLine, Index + 1, 1) = "/" Then
                        MyFixLine = Left(MyFixLine, Index) & " " & Mid(MyFixLine, Index + 1, Len(MyFixLine))
                    End If
                End If


            Next
        End Function



        Public Shared Function MyGetMySymbolName(IndexesIndex As Int32) As String
            Dim Index As Int32
            MyTrace(222, "MyGetMySymbolName", 53 - 41)

            MyMsgCtr("MyGetMySymbolName", 1298, IndexesIndex.ToString, "", "", "", "", "", "", "", "")

            Index = IndexesIndex
            While Index >= 1
                If Symbol_TableCoded_String(Index) = "/name" Then
                    MyGetMySymbolName = Symbol_TableSymbolName(Index)
                    Exit Function
                End If
                Index -= 1 'Index = Index -1
            End While
            MyGetMySymbolName = "" ' Not found or else index=-1
        End Function





        'This is used to fill/refill the list of currently available lib symbols 
        Public Shared Sub GetAllSymbolNames(SelectedSymbolName As String)
            Dim Index As int32
            Dim IndexDropDown As Integer
            Dim IndexColor As int32
            Dim ColorName As String
            MyTrace(223, "GetAllSymbolNames", 94 - 56)

            ColorName = "black" ' only to avoid a warning message.


            SymbolScreen.ToolStripDropDownSelectSymbol.DropDownItems.Clear()
            FlowChartScreen.ToolStripDropDownSelectSymbol.DropDownItems.Clear()

            '  Adding all symbol names to the symbol select list(S). (only button that should be on two screens)
            For Index = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                If IsNothing(Named_TableSymbolName(Index)) Then
                Else
                    AddSymbolToDropDown(Named_TableSymbolName(Index))
                End If
            Next


            For IndexDropDown = 0 To SymbolScreen.ToolStripDropDownSelectSymbol.DropDownItems.Count - 1
                If SelectedSymbolName = SymbolScreen.ToolStripDropDownSelectSymbol.DropDownItems.Item(IndexDropDown).Text Then
                    SelectInToolStrip(SymbolScreen.ToolStripDropDownSelectSymbol, SymbolScreen.ToolStripDropDownSelectSymbol.Text)
                    SelectInToolStrip(FlowChartScreen.ToolStripDropDownSelectSymbol, FlowChartScreen.ToolStripDropDownSelectSymbol.Text)
                    Exit For
                End If
            Next

            ' need to make the datatype selected from something
            SymbolScreen.ToolStripDropDownDataType.DropDownItems.Clear()
            For Index = 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                If IsNothing(DataType_TableName(Index)) Then
                    Abug(9997, "No Color Name at " & Index, "", "")
                Else
                    SymbolScreen.ToolStripDropDownDataType.DropDownItems.Add(DataType_TableName(Index))
                End If
            Next


            For IndexDropDown = 0 To SymbolScreen.ToolStripDropDownDataType.DropDown.Items.Count - 1
                If LCase(SymbolScreen.ToolStripDropDownDataType.DropDownItems.Item(IndexDropDown).Text) = "logic" Then
                    'SymbolScreen.ToolStripDropDownButtonPointDataType.Text = "logic"
                    'SymbolScreen.ComboBoxDataType.Select(Index, 1)
                    Exit For
                End If
            Next IndexDropDown

            SymbolScreen.ToolStripDropDownButtonColor.DropDownItems.Clear()
            FlowChartScreen.ToolStripDropDownSelectSymbol.DropDownItems.Clear()
            For Index = 1 To TopOfFile("Color", Color_FileName, Color_iSAM_)
                IndexColor = Color_iSAM_(Index)
                If IsNothing(Color_TableName(IndexColor)) Or Color_TableName(IndexColor) = "" Then
                    Abug(919, "GetAllSymbolNames() This is an empty color name", Index, IndexColor)
                Else
                    SymbolScreen.ToolStripDropDownButtonColor.DropDown.Items.Add(Color_TableName(IndexColor))
                End If
            Next



            For IndexDropDown = 0 To SymbolScreen.ToolStripDropDownButtonColor.DropDownItems.Count - 1
                If LCase(Trim(SymbolScreen.ToolStripDropDownButtonColor.DropDownItems.Item(IndexDropDown).Text)) = LCase(Trim(ColorName)) Then
                    SymbolScreen.ToolStripDropDownButtonColor.Text = ColorName
                    Exit For
                End If
            Next Indexdropdown
        End Sub


        Public Shared Sub YouHaveAnErrorMessage(WhichOne As int32, WhatIsIt As String)
            MyTrace(224, "YouHaveAnErrorMessage", 5)
            MyMsgCtr("YouHaveAnErrorMessage", 1276, WhichOne.ToString, WhatIsIt, "", "", "", "", "", "", "")
            DisplayMyStatus("You have an error message " & WhatIsIt)
        End Sub



        Public Shared Sub MoveAllPaths(Where As PictureBox, At As MyPointStructure, MoveOver As MyPointStructure)
            Dim Index As int32
            MyTrace(225, "MoveAllPaths", 32 - 5)

            For Index = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If LCase(FlowChart_TableCode(Index)) = "/path" Then
                    'Try One End 
                    If Snap(FlowChart_TableX1(Index)) = Snap(At.X) Then
                        If Snap(FlowChart_TableY1(Index)) = Snap(At.Y) Then
                            PaintErase(Where, Index)
                            FlowChart_TableX1(Index, Snap(FlowChart_TableX1(Index) + MoveOver.X))
                            FlowChart_TableY1(Index, Snap(FlowChart_TableY1(Index) + MoveOver.Y))
                            PaintAll(Where, Index, Index)
                        End If
                    End If
                    'Try the other end
                    If Snap(FlowChart_TableX2_Rotation(Index)) = Snap(At.X) Then
                        If Snap(FlowChart_TableY2_Option(Index)) = Snap(At.Y) Then
                            PaintErase(Where, Index)
                            FlowChart_TableX2_Rotation(Index, Snap(FlowChart_TableX2_Rotation(Index) + MoveOver.X))
                            FlowChart_TableY2_Option(Index, Snap(FlowChart_TableY2_Option(Index) + MoveOver.Y))
                            PaintAll(Where, Index, Index)
                        End If
                    End If
                End If
            Next
        End Sub



        Public Shared Sub MoveSymbolAndAllPaths(Where As PictureBox, Index As int32, MyDist As MyPointStructure)
            ' Need to change this to also move any connected paths before moving the symbol
            Dim IndexPoint As int32
            Dim XY As MyPointStructure
            Dim XDist As int32
            Dim YDist As int32
            MyTrace(226, "MoveSymbolAndAllPaths", 70 - 36)

            XDist = MyDist.X
            YDist = MyDist.Y

            IndexPoint = FindInSymbolList(FlowChart_TableNamed(Index))

            If IndexPoint <> constantMyErrorCode Then
                IndexPoint = IndexPoint + 1 ' Skip over the name
                While IndexPoint < TopOfFile("Symbol", Symbol_FileCoded) And Symbol_TableCoded_String(IndexPoint) <> "/name"
                    Select Case Symbol_TableCoded_String(IndexPoint)
                        Case "/point"
                            XY = MyRotated_1(Index, IndexPoint, MyUnEnum(FlowChart_TableX2_Rotation(Index), SymbolScreen.ToolStripDropDownRotation, 0)) ' constantEnumRotation))
                            MoveAllPaths(Where, XY, MyDist)
                        Case "/line"
                        Case Else
                    End Select

                    IndexPoint = IndexPoint + 1 ' Skip over the name
                End While
            End If
            PaintErase(Where, Index)
            FlowChart_TableX1(Index, Snap(FlowChart_TableX1(Index) + XDist))
            FlowChart_TableY1(Index, Snap(FlowChart_TableY1(Index) + YDist))
            PaintAll(Where, Index, Index)

        End Sub

        Public Shared Function SymbolOnTop(where As PictureBox, A As int32, B As int32) As Boolean
            Dim T2 As int32
            MyTrace(227, "SymbolOnTop", 85 - 72)

            'T1 = MyDirection(where, MyPoint1(A), MyPoint2(B))
            MyMsgCtr("SymbolOnTop", 1104, FlowChart_TableCode(A), FlowChart_TableCode(B), "", "", "", "", "", "", "")
            T2 = MyDistance(MyPoint1(A), MyPoint1_1(B))
            Application.DoEvents()
            If T2 <= MyUniverse.SysGen.ConstantSymbolCenter * 3 Then ' Not close to each other either
                SymbolOnTop = True
            Else
                SymbolOnTop = False
            End If

        End Function

        Public Shared Function PathAboveOrBelow(aY As int32, bY1 As int32, bY2 As int32) As Boolean
            MyTrace(228, "PathAboveOrBelow", 10)

            If aY > bY1 And aY > bY2 Then 'Ignore it its all above the line
                PathAboveOrBelow = False
            ElseIf aY < bY1 And aY < bY2 Then                 'ignore it is below the other
                PathAboveOrBelow = False
            Else 'they are on top of each other
                PathAboveOrBelow = True
            End If
        End Function


        Public Shared Function DoesPathMatch(A As MyLineStructure, B As MyLineStructure) As Boolean
            MyTrace(229, "DoesPathMatch", 13)

            If A.a.X = B.a.X Then DoesPathMatch = True : Exit Function 'a1x=b1x
            If A.b.X = B.a.X Then DoesPathMatch = True : Exit Function 'a2x=b1x
            If A.a.X = B.b.X Then DoesPathMatch = True : Exit Function 'a1x=b2x
            If A.b.X = B.b.X Then DoesPathMatch = True : Exit Function 'a2x=b2x
            If A.a.X = B.a.X Then DoesPathMatch = True : Exit Function
            If A.b.X = B.a.X Then DoesPathMatch = True : Exit Function 'Same for Y's
            If A.a.X = B.b.X Then DoesPathMatch = True : Exit Function
            If A.b.X = B.b.X Then DoesPathMatch = True : Exit Function
            DoesPathMatch = False
        End Function



        Public Shared Function PathOnTop(where As PictureBox, A As MyLineStructure, B As MyLineStructure) As Boolean ' Is the Path on top of each other
            ' I am only checking if the distance is close to each other, not if they lines are on top of each other.
            ' On top of each other is only if theyt are up/down and/or right/left - angle lines should be change 
            '(if the option is checked) other wise no checking
            Dim T1, T2, T3, T4, Temp As int32
            MyTrace(231, "PathOnTop", 85 - 72)

            'If this option is chosen
            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(14) = True Then ' Orthogonal paths
                If DoesPathMatch(A, B) = True Then
                    If PathAboveOrBelow(A.a.X, B.a.X, B.b.X) = True Then PathOnTop = True : Exit Function
                    If PathAboveOrBelow(A.a.Y, B.a.Y, B.b.Y) = True Then PathOnTop = True : Exit Function
                    If PathAboveOrBelow(A.b.X, B.a.X, B.b.X) = True Then PathOnTop = True : Exit Function
                    If PathAboveOrBelow(A.b.Y, B.a.Y, B.b.Y) = True Then PathOnTop = True : Exit Function
                End If

            Else ' If the option is not chosen
                T1 = MyDistance(MyPoint1(A.a.X, A.a.Y), MyPoint2(B.a.X, B.a.Y)) 'a1-b1
                T2 = MyDistance(MyPoint1(A.a.X, A.a.Y), MyPoint2(B.b.X, B.b.Y)) 'a1-b2
                T3 = MyDistance(MyPoint1(A.b.X, A.b.Y), MyPoint2(B.a.X, B.a.Y)) 'a2-b1
                T4 = MyDistance(MyPoint1(A.b.X, A.b.Y), MyPoint2(B.b.X, B.b.Y)) 'a2-b2
                Temp = T1
                If Temp < T2 Then Temp = T2
                If Temp < T3 Then Temp = T3
                If Temp < T4 Then Temp = T4
                If Temp < MyUniverse.SysGen.constantDistanceBetweenControls Then
                    PathOnTop = True : Exit Function
                End If
            End If
            PathOnTop = False
        End Function



        Public Shared Sub CheckColorTable()
            Dim IndexColor As int32
            Dim JdexColor As int32
            Dim I As int32
            MyTrace(232, "CheckColorTable", 603 - 587)

            MyMsgCtr("CheckColorTable", 1234, TopOfFile("Color", Color_FileName, Color_iSAM_).ToString, "color table", "", "", "", "", "", "", "")
            For I = 1 To TopOfFile("Color", Color_FileName, Color_iSAM_) - 1
                Application.DoEvents()
                IndexColor = Color_iSAM_(I)
                JdexColor = Color_iSAM_(I + 1)
                If LCase(Trim(Color_TableName(IndexColor))) = LCase(Trim(Color_TableName(JdexColor))) Then
                    YouHaveAnErrorMessage(1, "dublicate color named " & LCase(Color_TableName(IndexColor)) & " and " & LCase(Color_TableName(JdexColor)))
                    Color_TableName(IndexColor, Color_TableName(IndexColor) & "_Duplicate_Copy" & I)
                End If
            Next
        End Sub

        Public Shared Sub CheckDataType_Table()
            Dim Index As int32
            Dim jdex As int32
            MyTrace(233, "CheckDataType_Table", 20 - 5)

            MyMsgCtr("CheckDataType_Table", 1234, TopOfFile("DataType", DataType_FileName, DataType_iSAM_).ToString, "Data Type table", "", "", "", "", "", "", "")
            For Index = 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                Application.DoEvents()
                For jdex = Index + 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                    Application.DoEvents()
                    If LCase(DataType_TableName(Index)) = LCase(DataType_TableName(jdex)) Then
                        YouHaveAnErrorMessage(1, "dublicate data type named " & LCase(DataType_TableName(Index)) & " and " & LCase(DataType_TableName(jdex)))
                        DataType_TableName(Index, DataType_TableName(Index) & "_Copy")
                    End If
                Next
            Next
        End Sub



        Public Shared Sub CheckNamed_Table()
            Dim Index As int32
            Dim jdex As int32
            MyTrace(234, "CheckNamed_Table", 40 - 24)

            MyMsgCtr("CheckNamed_Table", 1234, TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM).ToString, "Names table", "", "", "", "", "", "", "")
            For Index = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                Application.DoEvents()
                jdex = Index + 1
                Application.DoEvents()
                If LCase(Named_TableSymbolName(Index)) = LCase(Named_TableSymbolName(jdex)) Then
                    MyMsgCtr("CheckNamed_Table", 1132, Index.ToString, Named_TableSymbolName(Index), jdex.ToString, Named_TableSymbolName(jdex), "", "", "", "", "")
                    YouHaveAnErrorMessage(1, "dublicate Symbol named " & LCase(Named_TableSymbolName(Index)) & " and " & LCase(Named_TableSymbolName(jdex)))
                    Named_TableSymbolName(jdex, Named_TableSymbolName(jdex) & "_Copy")
                End If
            Next
        End Sub


        Public Shared Sub MyCheckForMovingPathEnds(where As PictureBox, index As int32, xy As MyPointStructure)
            Dim XY1 As MyPointStructure
            MyTrace(235, "MyCheckForMovingPathEnds", 70 - 43)

            MyMsgCtr("MyCheckForMovingPathEnds", 1237, index.ToString, xy.X.ToString, xy.Y.ToString, "", "", "", "", "", "")
            If LCase(FlowChart_TableCode(index)) <> "/path" Then Exit Sub ' not a path to modify, program should never reach here
            XY1.X = FlowChart_TableX1(index)
            XY1.Y = FlowChart_TableY1(index)
            If MyDistance(XY1, xy) <= MyUniverse.SysGen.constantDistanceToMovePaths Then
                'MyStatus("Changing " & FlowChart_TableX1(index) & " To " & xy.X & " and also " & FlowChart_TableY1(index) & " To " & xy.Y)
                PaintErase(where, index) ' get rid of where it was and
                FlowChart_TableX1(index, xy.X)
                FlowChart_TableY1(index, xy.Y)
                PaintAll(where, index, index) 'repaint it where its going to
                'MyStatus("")
            End If


            XY1.X = FlowChart_TableX2_Rotation(index)
            XY1.Y = FlowChart_TableY2_Option(index)
            If MyDistance(XY1, xy) <= MyUniverse.SysGen.constantDistanceToMovePaths Then
                '                MyStatus("Changing " & FlowChart_TableX2_Rotation(index) & " To " & xy.X & " and also " & FlowChart_TableY2_Option(index) & " To " & xy.Y)
                PaintErase(where, index) ' get rid of where it was and
                FlowChart_TableX2_Rotation(index, xy.X)
                FlowChart_TableY2_Option(index, xy.Y)
                PaintAll(where, index, index) 'repaint it where its going to
                '               MyStatus("")
            End If
        End Sub


        Public Shared Sub CheckPaths(Where As PictureBox)
            Dim Flag As Boolean
            Dim MyXYXY1 As MyRECTStructure
            Dim MyXY2 As MyPointStructure
            Dim FlowChartUseIndex, FlowChartPathIndex, FLowChartCheckingPathIndex As Int32
            MyTrace(236, "CheckPaths", 795 - 673)

            For FlowChartUseIndex = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                Application.DoEvents()
                Flag = False
                MyXYXY1.MyTablesXY.a.X = FlowChart_TableX1(FlowChartUseIndex)
                MyXYXY1.MyTablesXY.a.Y = FlowChart_TableY1(FlowChartUseIndex)
                MyXYXY1.MyTablesXY.b.X = FlowChart_TableX2_Rotation(FlowChartUseIndex)
                MyXYXY1.MyTablesXY.b.Y = FlowChart_TableY2_Option(FlowChartUseIndex)
                Application.DoEvents()
                MyMsgCtr("CheckPaths", 1015, FlowChartUseIndex.ToString, MyXYXY1.MyTablesXY.a.X.ToString, MyXYXY1.MyTablesXY.a.Y.ToString, MyXYXY1.MyTablesXY.b.X.ToString, MyXYXY1.MyTablesXY.b.Y.ToString, FlowChart_TableNamed(FlowChartUseIndex), "", "", "")
                Select Case LCase(FlowChart_TableCode(FlowChartUseIndex))
                    Case "" ' ignore if nothing also
                        Flag = True
                    Case "/path", "/use"
                        ' We are looking at a symbol points connecting
                        For FlowChartPathIndex = FlowChartUseIndex + 1 To TopOfFile("FlowChart", FlowChart_FileCoded) ' Looking only for /use statements
                            Application.DoEvents()
                            PaintErase(Where, FlowChartPathIndex)
                            MyMsgCtr("CheckPaths", 1131, FlowChart_TableX1(FlowChartPathIndex).ToString, FlowChart_TableY1(FlowChartPathIndex).ToString, FlowChart_TableX2_Rotation(FlowChartPathIndex).ToString, FlowChart_TableY2_Option(FlowChartPathIndex).ToString, FlowChart_TableX1(FlowChartUseIndex).ToString, FlowChart_TableY1(FlowChartUseIndex).ToString, FlowChart_TableX2_Rotation(FlowChartUseIndex).ToString, FlowChart_TableY2_Option(FlowChartUseIndex).ToString, "")
                            Select Case LCase(FlowChart_TableCode(FlowChartPathIndex))
                                Case "/use"
                                    FLowChartCheckingPathIndex = FindInSymbolList(FlowChart_TableNamed(FlowChartPathIndex))
                                    If FLowChartCheckingPathIndex = constantMyErrorCode Then
                                        Abug(918, Symbol_FileSymbolName(FlowChartPathIndex), 0, 0)
                                        MakeErrorAt(Where, MyXYXY1.MyInputScreenXY.a, "There is no symbol defined in the libaray with the name >" & FlowChart_TableNamed(FlowChartPathIndex) & "< ")
                                        MakeErrorAt(Where, MyXYXY1.MyInputScreenXY.b, "There is no symbol defined in the libaray with the name >" & FlowChart_TableNamed(FlowChartPathIndex) & "< ")
                                    Else
                                        FLowChartCheckingPathIndex = FLowChartCheckingPathIndex + 1 ' skip over the name of the symbol
                                        'MyStatus("Comparing " & Index & " : " & FlowChartPathIndex & " : " & FLowChartCheckingPathIndex)
                                        While FLowChartCheckingPathIndex < TopOfFile("Symbol", Symbol_FileCoded)  ' Till the next name
                                            Application.DoEvents()
                                            '    MyStatus("Comparing index " & Index & " with index " & FlowChartPathIndex & " with index  " & FLowChartCheckingPathIndex)
                                            MyMsgCtr("CheckPaths", 1281, FlowChartUseIndex.ToString, FlowChartPathIndex.ToString, FLowChartCheckingPathIndex.ToString, "", "", "", "", "", "")
                                            Select Case Symbol_TableCoded_String(FLowChartCheckingPathIndex)
                                                Case "/name"
                                                    Exit While ' End of the symbol (starting of the next symbol)
                                                Case "/line"  'Line Start so ignore - cause lines have no meaning
                                                Case "/point"  ' See if the path matches the point
                                                    MyXY2 = MyRotated_1(FLowChartCheckingPathIndex, FlowChartPathIndex, MyUnEnum(FlowChart_TableX2_Rotation(FlowChartPathIndex), SymbolScreen.ToolStripDropDownRotation, 1)) ' constantEnumRotation))
                                                    ' Checking of point points to here.
                                                    If MyDistance(MyXY2, MyXYXY1.MyTablesXY.a) < MyUniverse.SysGen.constantDistanceToMovePaths Then
                                                        Abug(917, Symbol_FileSymbolName(FLowChartCheckingPathIndex), 0, MyDistance(MyXY2, MyXYXY1.MyTablesXY.a))
                                                        MyCheckForMovingPathEnds(Where, FlowChartPathIndex, MyXY2)
                                                        Flag = True
                                                        Exit For
                                                    End If
                                                    If MyDistance(MyXY2, MyXYXY1.MyTablesXY.b) < MyUniverse.SysGen.constantDistanceToMovePaths Then
                                                        Abug(916, Symbol_FileSymbolName(FLowChartCheckingPathIndex), 0, MyDistance(MyXY2, MyXYXY1.MyTablesXY.b))
                                                        MyCheckForMovingPathEnds(Where, FlowChartPathIndex, MyXY2)
                                                        Flag = True
                                                        Exit For
                                                    End If
                                                Case "/delete"
                                                Case "/error"
                                                Case Else
                                            End Select ' end of the symbols
                                            FLowChartCheckingPathIndex = FLowChartCheckingPathIndex + 1 ' Should I ?
                                            '                                            MyStatus("Comparing " & Index & " : " & FlowChartPathIndex & " : " & FLowChartCheckingPathIndex)
                                        End While ' next record in the symbols
                                    End If ' Testing if this is a /use
                                Case "/path"
                                    ' check if two paths are connected
                                    'FlowChartPathIndex = Index
                                    MyMsgCtr("CheckPaths", 1131, FlowChart_TableX1(FlowChartPathIndex).ToString, FlowChart_TableY1(FlowChartPathIndex).ToString, FlowChart_TableX2_Rotation(FlowChartPathIndex).ToString, FlowChart_TableY2_Option(FlowChartPathIndex).ToString, FlowChart_TableX1(FlowChartUseIndex).ToString, FlowChart_TableY1(FlowChartUseIndex).ToString, FlowChart_TableX2_Rotation(FlowChartUseIndex).ToString, FlowChart_TableY2_Option(FlowChartUseIndex).ToString, "")
                                    If LCase(FlowChart_TableCode(FlowChartUseIndex)) = "/path" Then
                                        For FLowChartCheckingPathIndex = FlowChartPathIndex To TopOfFile("FlowChart", FlowChart_FileCoded)
                                            Application.DoEvents()
                                            If FLowChartCheckingPathIndex <> FlowChartUseIndex Then ' Dont conpare the same path
                                                If LCase(FlowChart_TableCode(FLowChartCheckingPathIndex)) = "/path" Then ' only compart paths to other paths
                                                    'xy1 to xy2
                                                    If MyDistance(MyPoint1_1(FlowChartUseIndex), MyPoint2_2(FLowChartCheckingPathIndex)) = 0 Then
                                                        Abug(915, "CheckPaths():", FlowChartUseIndex, FLowChartCheckingPathIndex)
                                                        ' We are matching two paths together so Ignore ifit goes to another.
                                                        '**** We need to check that the names (name of the variable) are the same for the two paths (or can make them the same)
                                                        MyCheckForMovingPathEnds(Where, FlowChartUseIndex, MyPoint2_2(FLowChartCheckingPathIndex))
                                                        Flag = True
                                                        ' dont exit, check all other paths also 'Exit For
                                                    End If
                                                    ' xy2 to xy1
                                                    If MyDistance(MyPoint2_1(FlowChartUseIndex), MyPoint1(FLowChartCheckingPathIndex)) = 0 Then
                                                        Abug(914, "CheckPaths", FlowChartUseIndex, FLowChartCheckingPathIndex)
                                                        MyCheckForMovingPathEnds(Where, FlowChartUseIndex, MyPoint1(FLowChartCheckingPathIndex))
                                                        Flag = True
                                                        ' dont exit, check all other paths also 'Exit For
                                                    End If

                                                    If MyDistance(MyPoint2_1(FlowChartUseIndex), MyPoint2_2(FLowChartCheckingPathIndex)) = 0 Then
                                                        Abug(913, "CheckPaths():", MyShowFlowChartRecord(FlowChartUseIndex), MyShowFlowChartRecord(FLowChartCheckingPathIndex))
                                                        MyCheckForMovingPathEnds(Where, FlowChartUseIndex, MyPoint2_2(FLowChartCheckingPathIndex))
                                                        Flag = True
                                                        ' dont exit, check all other paths also 'Exit For
                                                    End If
                                                    If MyDistance(MyPoint2_1(FlowChartUseIndex), MyPoint2_2(FLowChartCheckingPathIndex)) = 0 Then
                                                        Abug(912, "CheckPaths():", MyShowFlowChartRecord(FlowChartUseIndex), MyShowFlowChartRecord(FLowChartCheckingPathIndex))
                                                        MyCheckForMovingPathEnds(Where, FlowChartUseIndex, MyPoint2_2(FLowChartCheckingPathIndex))
                                                        Flag = True
                                                        ' dont exit, check all other paths also 'Exit For
                                                    End If
                                                End If
                                            End If
                                        Next
                                    End If
                                Case "/constant"
                                    Flag = True
                                Case "/delete"
                                    Flag = True
                                Case "/error"
                                    Flag = True
                                Case Else
                            End Select
                            If Flag = False Then 'hack
                                Abug(911, "Path Goes Nowhere", MyShowFlowChartRecord(FlowChartUseIndex), MyShowFlowChartRecord(FLowChartCheckingPathIndex)) 'hack
                                MakeErrorAt(Where, MyPoint1_1(FlowChartUseIndex), "Path goes no where")
                            End If
                        Next
                End Select

            Next ' Index

        End Sub


        Public Shared Sub CheckSymbols(Where As PictureBox)
            Dim FlowChartIndex As Int32
            Dim Jdex As int32
            Dim MyXY As MyPointStructure
            MyTrace(237, "CheckSymbols", 31 - 3)

            Clear_Screen_Only(Where)
            For FlowChartIndex = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                Application.DoEvents()
                If LCase(FlowChart_TableCode(FlowChartIndex)) = "/use" Then
                    PaintEach(Where, MyPoint1(FlowChart_TableX1(FlowChartIndex), FlowChart_TableY1(FlowChartIndex)), FlowChart_TableNamed(FlowChartIndex), FlowChart_TableX2_Rotation(FlowChartIndex).ToString)
                    For Jdex = FlowChartIndex + 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                        Application.DoEvents()
                        If LCase(FlowChart_TableCode(Jdex)) = "/use" Then
                            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(15) = True Then 'Auto Move Symbols ontop of each other
                                While SymbolOnTop(Where, FlowChartIndex, Jdex) = True
                                    Application.DoEvents()
                                    MyMsgCtr("CheckSymbols", 1282, FlowChart_TableNamed(FlowChartIndex), FlowChart_TableNamed(Jdex), "", "", "", "", "", "", "")
                                    MoveSymbolAndAllPaths(Where, Jdex, MyPoint1(50, 0))
                                    Application.DoEvents()
                                    '                                PaintEach(Where, MyPoint1(FlowChart_TableX1(FlowChartIndex), FlowChart_TableY1(FlowChartIndex)), FlowChart_TableNamed(Index))
                                    MyDrawLineXY_XY(Where, MyLine2(FlowChartIndex, Jdex), "red")
                                End While
                            Else
                                If SymbolOnTop(Where, FlowChartIndex, Jdex) = True Then
                                    Abug(910, "Symbol on Top of each other", FlowChartIndex, Jdex)
                                    MyXY.X = FlowChart_TableX1(FlowChartIndex)
                                    MyXY.Y = FlowChart_TableY1(FlowChartIndex)
                                    MakeErrorAt(Where, MyXY, "Symbol Overlaps " & Symbol_TableSymbolName(FlowChartIndex) & " with " & Symbol_TableSymbolName(Jdex))
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
        End Sub


        Public Shared Sub CheckThisLong(FromWhere As String, Item As int32, MyArrayLong() As int32, ByRef iSAM() As int32, Index As int32)
            MyTrace(238, "CheckThisLong", 60 - 34)

            '            CheckThisLong = false
            If Index <= 0 Then
                Abug(908, "CheckThisLong(#1):", 0, 1390)
                MyMsgCtr("CheckThisLong", 1390, "", "", "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            If Index > UBound(MyArrayLong) - 1 Then
                Abug(906, "CheckThisLong(#2):", 0, 1391)
                MyMsgCtr("CheckThisLong", 1391, "", "", "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            If Index > UBound(iSAM) - 1 Then
                Abug(904, "CheckThisLong(#3):", 0, 1392)
                MyMsgCtr("CheckThisLong", 1392, "", "", "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            ' Need to check if at the end of the MyArray here (as in the string MyArray check
            If iSAM(Index) < 1 Then
                Abug(903, "CheckThisLong(#4):", 0, 1380)
                MyMsgCtr("CheckThisLong", 1380, "", iSAM(Index).ToString, Index.ToString, "", "", "", "", FromWhere.ToString, Item.ToString)
                Exit Sub
            End If
            If iSAM(Index) >= UBound(MyArrayLong) - 1 Then
                Abug(902, "CheckThisLong)#5):", 0, 1387)
                MyMsgCtr("CheckThisLong", 1387, "", iSAM(Index).ToString, Index.ToString, "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            ' No errors detected if here
            '            CheckThisLong = true
        End Sub


        Public Shared Sub CheckThis(FromWhere As String, Item As int32, ByRef MyArray() As String, ByRef iSAM() As int32, Index As int32)
            MyTrace(239, "CheckThis", 97 - 63)

            '            CheckThis = false
            If Index <= 0 Then
                Abug(899, "CheckThis(#1):", 0, 1390)
                'MyMsgCtr("CheckThis", 1390, "", "", "", "", "", "", "", FromWhere, Item)
                Exit Sub
            End If
            If Index > UBound(MyArray) - 1 Then
                Abug(898, "CheckThis", 0, 1393)
                MyMsgCtr("CheckThis", 1393, "", "", "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            If Index > UBound(iSAM) - 1 Then
                Abug(897, "CheckThis", 0, 1394)
                MyMsgCtr("CheckThis", 1394, "", "", "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If


            If Index <> 1 And IsNothing(MyArray(Index - 1)) And IsNothing(MyArray(Index + 1)) Then
                Abug(896, "CheckThis", 0, 1013)
                MyMsgCtr("CheckThis", 1013, (Index - 1).ToString, MyArray(Index - 1), Index.ToString, MyArray(Index), (Index + 1).ToString, MyArray(Index + 1), "", FromWhere, Item.ToString)
            End If
            If IsNothing(MyArray(Index)) Then
                Abug(895, "CheckThis", 0, 1189)
                MyMsgCtr("CheckThis", 1189, Index.ToString, iSAM(Index).ToString, "", "", "", "", "", FromWhere, Item.ToString)
                Exit Sub 'Because iSAM checks are meaningless after
            End If
            If iSAM(Index) < 1 Then
                Abug(894, "CheckThis", 0, 1388)
                MyMsgCtr("CheckThis", 1388, "", iSAM(Index).ToString, Index.ToString, "", "", "", "", FromWhere, Item.ToString)
                Exit Sub
            End If
            If iSAM(Index) >= UBound(MyArray) - 1 Then
                Abug(893, "CheckThis", 0, 1389)
                MyMsgCtr("CheckThis", 1389, "", iSAM(Index).ToString, Index.ToString, "", "", "", "CheckThis", FromWhere, Item.ToString)
                Exit Sub
            End If
            ' No errors detected if here
        End Sub


        ' This is to check everything (It should be a thread that is always running on new/moved/delete)
        Public Shared Sub CheckAll()
            MyTrace(241, "CheckAll", 20 - 1)

            Application.DoEvents()
            'First check for two named symbols in the named/DataType/COlor table
            CheckColorTable()
            Application.DoEvents()
            CheckDataType_Table()
            Application.DoEvents()
            CheckNamed_Table()
            Application.DoEvents()
            CheckPaths(FlowChartScreen.PictureBox1)
            Application.DoEvents()
            CheckSymbols(FlowChartScreen.PictureBox1)
            Application.DoEvents()
        End Sub

        Public Shared Sub MyRemoveAllUnusedSymbols()
            Dim Index As int32
            Dim Jdex As Int32
            MyTrace(242, "MyRemoveAllUnusedSymbols", 64 - 22)


            MyMsgCtr("MyRemoveAllUnusedSymbols", 1241, TopOfFile("Named",
                                                                 Named_FileSymbolName,
                                                                 Named_File_iSAM).ToString,
                                                                TopOfFile("Symbol", Symbol_FileCoded).ToString,
                                                                TopOfFile("FlowChart", FlowChart_FileCoded).ToString,
                                                                TopOfFile("DataType", DataType_FileName, DataType_iSAM_).ToString,
                                                                TopOfFile("Color", Color_FileName, Color_iSAM_).ToString, "", "", "", "")
            'Need to Add to make sure that every /name in symbols has a name in Named_Table also
            ShowSorts("Named", MySortStringArray("Named", Named_FileSyntax, Named_FileSyntax_Isam))
            ShowSorts("Named", MySortStringArray("Named", Named_FileSymbolName, Named_File_iSAM)) ' make sure that the named symbol table is in order for this to work.
            For Index = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                If LCase(Named_TableSymbolName(Index)) = LCase(Named_TableSymbolName(Index + 1)) Then
                    If Named_TableSymbolName(Index) <> "" Then
                        MyReMoveSymbol(Named_TableSymbolName(Index)) ' From both named and symbol
                        MyReMoveNamed(Index)
                    End If
                End If
            Next

            For Index = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                If Named_TableSymbolName(Index) = "" Then
                    Abug(891, "MyRemoveAllUnusedSymbols():Null Symbol Name", 0, 0)
                    ' Need to see if there is anything I need to add here later
                Else
                    CheckForAnySortNeeded("", 244)
                    Jdex = FindIndexIniSAMTable("FlowChart", "DoNotAdd", FlowChart_FileNamed, FlowChart_iSAM_Name, Named_TableSymbolName(Index))
                    CheckForAnySortNeeded("", 245)
                    If Jdex > 1 Then
                        MyMsgCtr("MyRemoveAllUnusedSymbols",
                             1366,
                             "39 Names : ",
                             Named_TableSymbolName(Index),
                             Named_TableSymbolName(Named_File_iSAM(Jdex - 1)),
                             Named_TableSymbolName(Named_File_iSAM(Jdex)),
                             Named_TableSymbolName(Named_File_iSAM(Jdex + 1)), "", "", "", "")
                    End If
                    If Jdex = constantMyErrorCode Then
                        MyReMoveSymbol(Named_TableSymbolName(Index)) ' From both named and symbol
                        MyReMoveNamed(Index)
                    End If
                End If
            Next
            ShowSorts("Named", MySortStringArray("Named", Named_FileSyntax, Named_FileSyntax_Isam)) ' make sure that the named symbol table is in order for this to work.
            ShowSorts("Named", MySortStringArray("Named", Named_FileSymbolName, Named_File_iSAM))

        End Sub

        Public Shared Sub MyReMoveNamed(IndexNamed As int32) ' completel destroy it (for now)
            MyTrace(243, "MyReMoveNamed", 7977 - 7966)

            MyMsgCtr("MyReMoveNamed", 1242, IndexNamed.ToString, "FlowChart names", "", "", "", "", "", "", "")
            Named_TableSymbolName(IndexNamed, Nothing)
            Named_TableProgramText(IndexNamed, Nothing)
            '            Named_TableLanguage(IndexNamed, Nothing)
            Named_TableNotes(IndexNamed, Nothing)
            Named_TableOpCode(IndexNamed, Nothing)
            Named_TableIndexes(IndexNamed, Nothing)
            Named_TableNameOfFile(IndexNamed, Nothing)
            Named_TableStroke(IndexNamed, Nothing)
        End Sub

        Public Shared Sub MyReMoveSymbol(SymbolName As String)
            Dim Index As int32
            MyTrace(244, "MyReMoveSymbol", 7997 - 7979)

            Index = FindInSymbolList(SymbolName)

            If Index = constantMyErrorCode Then
                Abug(889, SymbolName, 0, 0)
            Else
                MyMsgCtr("MyReMoveSymbol", 1242, Index.ToString, SymbolName, "", "", "", "", "", "", "")
                If LCase(Symbol_TableSymbolName(Index)) = LCase(SymbolName) Then
                    Symbol_TableCode(Index, "/delete")
                    While Symbol_TableCoded_String(Index) <> "/name" And Index < TopOfFile("Symbol", Symbol_FileCoded)
                        Symbol_TableCode(Index, "/delete") ' consider making it nothing.
                        Index = Index + 1
                    End While
                Else
                    ' We have some kind of internal error here.
                End If
            End If
        End Sub

        'Need to make sure that we Sort after at least one of these (and reset the kounter)
        Public Shared Sub MyDeleteDataType_Table(Index As int32)
            MyTrace(245, "MyDeleteDataType_Table", 8008 - 8000)

            MyMsgCtr("MyDeleteDataType_Table", 1242, Index.ToString, DataType_TableName(Index), "", "", "", "", "", "", "")
            DataType_TableName(Index, Nothing)
            DataType_TableColorIndex(Index, 0L)
            DataType_TableDescribtion(Index, Nothing)
            DataType_TableNumberOfBytes(Index, Nothing)
            DataType_TableWidth(Index, Nothing)
            'now we should move everthing up (reverse insert sort)
        End Sub


        Public Shared Sub DeleteAllErrorMessages()
            Dim Index As int32
            Dim Jdex As int32
            MyTrace(246, "DeleteAllErrorMessages", 44 - 11)

            Jdex = 0 ' one before the usable records
            For Index = 1 To TopOfFile("Symbol", Symbol_FileCoded)
                If Symbol_TableCoded_String(Index) = "/error" Or Symbol_TableCoded_String(Index) = "/delete" Then
                    MyMsgCtr("DeleteAllErrorMessages", 1242, Index.ToString, Symbol_TableSymbolName(Index), "", "", "", "", "", "", "")
                Else
                    Jdex = Jdex + 1
                End If
                If Index <> Jdex Then
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                    SwapSymbolList(Index, Jdex) ' Move the records forward over the bad record to compress
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                End If
            Next

            Jdex = 0
            For Index = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If FlowChart_TableCode(Index) = "/error" Or FlowChart_TableCode(Index) = "/delete" Then
                    MyMsgCtr("DeleteAllErrorMessages", 1242, Index.ToString, Symbol_TableSymbolName(Index), "", "", "", "", "", "", "")
                Else
                    Jdex = Jdex + 1
                End If
                If Index <> Jdex Then
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                    SwapSymbolList(Index, Jdex) ' Move the records forward over the bad record to compress
                    FindingMyBugs(10) 'hack Least amount of checking here 'hack 2020 08 04
                End If
            Next
            SortALLiSAM()
            FindingMyBugs(10) 'hack Least amount of checking here 'hack
        End Sub

        '*******************************************************************
        'This makes sure that something is printable (make it an underline instead of nothing)
        Public Shared Function PrintAbleNull(A As Object) As String
            MyTrace(247, "PrintAbleNull", 71 - 47)

            If TypeOf A Is String Then
                If Len(A.ToString) = 0 Or IsNothing(A) Then
                    PrintAbleNull = "_"
                Else
                    PrintAbleNull = A.ToString
                End If
            ElseIf TypeOf A Is Long Then
                PrintAbleNull = Str(A)
            ElseIf TypeOf A Is Integer Then
                PrintAbleNull = Str(A)
            ElseIf TypeOf A Is int32 Then
                PrintAbleNull = Str(A)
            ElseIf TypeOf A Is Byte Then
                PrintAbleNull = Str(A)
            Else
                If IsNothing(A) Then
                    PrintAbleNull = "_"
                Else
                    PrintAbleNull = " " & A.ToString
                End If
            End If
        End Function


        Public Shared Function MyOffset(XY As MyPointStructure, X As String, Y As String) As MyPointStructure
            'flow10'''''''MyTrace(248, "MyOffSet", 4)
            MyOffset.X = XY.X + My_Int(X)
            MyOffset.Y = XY.Y + My_Int(Y)
        End Function

        ' This routine returns the name of (any-First) path that it finds closest to this location
        Public Shared Function FindPathNameAt(XY As MyPointStructure) As int32 ' index of path
            Dim D1, D2 As int32
            Dim Found As int32 ' First Found One
            Dim Index As int32
            MyTrace(249, "FindPathNameAt", 8113 - 8086)

            Found = 0
            For Index = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                Select Case LCase(FlowChart_TableCode(Index))
                    Case "/path"
                        If Found = 0 Then
                            Found = Index
                            Exit Select
                        End If
                        D1 = MyDistance(XY, MyPoint1(Index))
                        D2 = MyDistance(XY, MyPoint1(Found))

                        If D1 < D2 Then
                            Found = Index
                        End If
                    Case Else
                End Select

            Next

            If Found > 0 Then
                FindPathNameAt = Found
                '                FindPathNameAt = FlowChart_TableNamed(Found)
            Else
                Abug(888, XY.X & FD & XY.Y, D1, D2)
                FindPathNameAt = constantMyErrorCode
            End If
        End Function

        'RECURSIVE routine to find all of the paths connected together to XY.
        Public Shared Sub FindAllPaths(IndexFlowChart As int32, XY As MyPointStructure)
            '***************** Yes I know that it causes recursion loop that will never stop, I'll fix it later - Really I will
            ' Find all of the points to this location and return as a string of the index to that path
            Dim I As int32
            Dim IndexFlowChartX1 As int32
            MyTrace(251, "FindAllPaths", 86 - 21)

            If MyInListOfNumbers(IndexFlowChart) = True Then Exit Sub


            If IndexFlowChart < 1 Then
                Abug(887, XY.X, XY.Y, IndexFlowChart)
                Exit Sub
            End If
            If IndexFlowChart > TopOfFile("FlowChart", FlowChart_FileCoded) Then Exit Sub
            If LCase(FlowChart_TableCode(IndexFlowChart)) <> "/path" Then Exit Sub


            CheckForAnySortNeeded("", 248)
            '******************** Error this is not returning the index of a found item
            IndexFlowChartX1 = FindIndexIniSAMTable("FlowChart", "DoNotAdd", FlowChart_FileX1, FlowChart_iSAM_X1, FlowChart_TableX1(IndexFlowChart))

            I = MyUniverse.MyCheatSheet.LastiSAMNumberIndex

            CheckForAnySortNeeded("", 248)
            If MyCheckIndex_long("FlowChart", IndexFlowChartX1, FlowChart_FileX2_Rotation, FlowChart_iSAM_X1) = False Then Exit Sub
            IndexFlowChartX1 = MyMinMax(IndexFlowChartX1, 1, UBound(FlowChart_iSAM_X1))
            MyMsgCtr("FindAllPaths", 1130, IndexFlowChart.ToString, XY.X.ToString, XY.Y.ToString, "", "", "", "", "", "")

            'Why does the following line error out? It works the first few times
            '??????????????????????????????????????????????????????
            'Lets make sure we are at the geggining of the first isam(index)
            While FlowChart_TableX1(FlowChart_iSAM_X1(IndexFlowChartX1 - 1)) < FlowChart_TableX1(IndexFlowChart)
                Application.DoEvents()
                IndexFlowChartX1 += 1
            End While

            While FlowChart_TableX1(FlowChart_iSAM_X1(IndexFlowChartX1 - 1)) = FlowChart_TableX1(IndexFlowChart)
                Application.DoEvents()
                IndexFlowChartX1 -= 1
            End While

            If FindInNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))) > 0 Then Exit Sub ' already in a net
            'Already in a net 
            While FlowChart_TableX1(FlowChart_iSAM_X1(IndexFlowChartX1)) <= FlowChart_TableX1(IndexFlowChart)
                Application.DoEvents()
                I = FlowChart_iSAM_X1(IndexFlowChartX1)
                If IndexFlowChart <> IndexFlowChartX1 Then
                    Select Case LCase(FlowChart_TableCode(I))
                        Case "/path"
                            If IndexFlowChart <> I Then
                                CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                                If MyInListOfNumbers(IndexFlowChart) = True Then
                                    MyMsgCtr("FindAllPaths", 1246, I.ToString, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), "", "", "", "", "", "", "")
                                Else
                                    'Check The first point
                                    If XY.X = FlowChart_TableX1(I) Then
                                        If XY.Y = FlowChart_TableY1(I) Then
                                            CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                                            MyMsgCtr("CheckPaths", 1131, FlowChart_TableX1(I).ToString, FlowChart_TableY1(I).ToString, FlowChart_TableX2_Rotation(I).ToString, FlowChart_TableY2_Option(I).ToString, FlowChart_TableX1(IndexFlowChart).ToString, FlowChart_TableY1(IndexFlowChart).ToString, FlowChart_TableX2_Rotation(IndexFlowChart).ToString, FlowChart_TableY2_Option(IndexFlowChart).ToString, "")
                                            ' Start new tree search
                                            FindAllPaths(I, MyPoint1(FlowChart_TableX1(I), FlowChart_TableY1(I)))
                                            FindAllPaths(I, MyPoint2(FlowChart_TableX2_Rotation(I), FlowChart_TableY2_Option(I)))
                                            'FindAllPaths_2(I) 'By Path Name
                                            MyMsgCtr("FindAllPaths", 1131, IndexFlowChart.ToString, I.ToString, XY.X.ToString, XY.Y.ToString, FlowChart_TableX2_Rotation(I).ToString, FlowChart_TableY2_Option(I).ToString, "", "", "")
                                        End If
                                    End If
                                    'Check The Second point
                                    If XY.X = FlowChart_TableX2_Rotation(I) Then
                                        If XY.Y = FlowChart_TableY2_Option(I) Then
                                            CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                                            MyMsgCtr("CheckPaths", 1131, FlowChart_TableX1(I).ToString, FlowChart_TableY1(I).ToString, FlowChart_TableX2_Rotation(I).ToString, FlowChart_TableY2_Option(I).ToString, FlowChart_TableX1(IndexFlowChart).ToString, FlowChart_TableY1(IndexFlowChart).ToString, FlowChart_TableX2_Rotation(IndexFlowChart).ToString, FlowChart_TableY2_Option(IndexFlowChart).ToString, "")
                                            ConnectPaths(I, IndexFlowChart)
                                            ' Start new tree search
                                            FindAllPaths(I, MyPoint1(FlowChart_TableX1(I), FlowChart_TableY1(I)))
                                            FindAllPaths(I, MyPoint2(FlowChart_TableX2_Rotation(I), FlowChart_TableY2_Option(I)))
                                            'FindAllPaths_2(I) 'By Path Name
                                            MyMsgCtr("CheckPaths", 1131, FlowChart_TableX1(I).ToString, FlowChart_TableY1(I).ToString, FlowChart_TableX2_Rotation(I).ToString, FlowChart_TableY2_Option(I).ToString, FlowChart_TableX1(IndexFlowChart).ToString, FlowChart_TableY1(IndexFlowChart).ToString, FlowChart_TableX2_Rotation(IndexFlowChart).ToString, FlowChart_TableY2_Option(IndexFlowChart).ToString, "")
                                        End If
                                    End If
                                End If
                            End If
                    End Select
                End If
                ''                FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                MyMsgCtr("FindAllPaths", 1247, IndexFlowChart.ToString, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))), "", "", "", "", "", "")
                IndexFlowChartX1 = IndexFlowChartX1 + 1

                If InvalidIndex(IndexFlowChartX1, FlowChart_FileX1, FlowChart_iSAM_X1) Then
                    Abug(886, "FindAllPaths():", IndexFlowChartX1, 0)
                    Exit While
                End If

            End While
            ' Got here cause this XY is not anywhere else 
            ''            FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
            CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
            MyMsgCtr("FindAllPaths", 1248, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), NetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))), "", "", "", "", "", "", "")
        End Sub



        Public Shared Sub FindAllPaths_2(IndexFlowChart As int32, LineNumber As int32) ' This does findallpaths()  but by name
            '***************** Yes I know that it causes recursion loop that will never stop, I'll fix it later - Really I will
            ' Find all of the points to this location and return as a string of the index to that path
            Dim Index As int32
            Dim Jdex As int32
            MyTrace(252, "FindAllPaths_2", 86 - 21)

            If IndexFlowChart < 1 Then
                Exit Sub
            End If
            If IndexFlowChart > TopOfFile("FlowChart", FlowChart_FileCoded) Then Exit Sub
            If LCase(FlowChart_TableCode(IndexFlowChart)) <> "/path" Then Exit Sub

            '****************************** I can speed it up later
            CheckForAnySortNeeded("", 249)
            Jdex = FindiSAM_IN_Table("FlowChart", "DoNotAdd", FlowChart_FileNamed, FlowChart_iSAM_Name, FlowChart_TableNamed(IndexFlowChart))
            CheckForAnySortNeeded("", 249)
            If MyCheckIndex_String("FlowChart", Jdex, FlowChart_FileNamed, FlowChart_iSAM_Name) = False Then Exit Sub
            ' above is all extra and dow not work right( I used it wrongly)


            'Get the index in the isam of the start
            Jdex = FindIndexIniSAMTable("FlowChart", "DoNotAdd", FlowChart_FileNamed, FlowChart_iSAM_Name, FlowChart_TableNamed(IndexFlowChart))

            Index = MyUniverse.MyCheatSheet.LastiSAMNumberIndex ' Is this what I want? and not jdex (ie set jdex to this )

            While FlowChart_TableNamed(FlowChart_iSAM_Name(Jdex)) < FlowChart_TableNamed(IndexFlowChart) And Jdex > 1
                MyMsgCtr("FindAllPaths_2",
                         1026,
                         FlowChart_TableNamed(FlowChart_iSAM_Name(Jdex)),
                         FlowChart_TableNamed(IndexFlowChart), CStr(Jdex), "", "", "", "", "", "")
                Jdex += 1
            End While

            While FlowChart_TableNamed(FlowChart_iSAM_Name(Jdex - 1)) = FlowChart_TableNamed(IndexFlowChart) And Jdex > 1
                Jdex -= 1
            End While

            While FlowChart_TableNamed(FlowChart_iSAM_Name(Jdex)) <= FlowChart_TableNamed(IndexFlowChart)
                Index = FlowChart_iSAM_Name(Jdex)
                If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                    Abug(886, "FindAllPaths_2():", 0, 0)
                    Exit While
                End If
                Select Case LCase(FlowChart_TableCode(Index))
                    Case "/path"
                        If IndexFlowChart <> Index Then
                            CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                            ''                            FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                            If MyInListOfNumbers(IndexFlowChart) = True Then
                                MyMsgCtr("FindAllPaths_2", 1246, Index.ToString, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), "", "", "", "", "", "", "")
                            Else
                                'Check The first point
                                If FlowChart_TableNamed(IndexFlowChart) = FlowChart_TableNamed(Index) Then
                                    CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                                    ''                                    FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                                    ' This name is not in the list of path links , so lets connect them together
                                    MakePaths(IndexFlowChart, Index, LineNumber)
                                    'FLOW10' Causes recursion never ending ''''''''''''UpDateFlowChartLinks(Index, LineNumber)
                                    PaintAll(FlowChartScreen.PictureBox1, IndexFlowChart, IndexFlowChart)
                                    PaintAll(FlowChartScreen.PictureBox1, Index, Index)
                                End If
                            End If
                        End If
                        CleanListOfNetLinks(My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)))
                        ''                        FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, CleanListOfNets(IndexFlowChart))
                End Select
                Jdex += 1

                If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                    Abug(886, "FindAllPaths_2():", 0, 0)
                    Exit While
                End If

            End While
            ' Got here cause this XY is not anywhere else 
            MyMsgCtr("FindAllPaths_2", 1248, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), "", "", "", "", "", "", "", "")
        End Sub





        Public Shared Function NewFlowChartRecord(Index As int32) As int32
            MyTrace(253, "NewFlowChartRecord", 8)

            FlowChart_FileNamed(Index) = "?" ' just to make no errors 
            FlowChart_iSAM_Name(Index) = Index
            FlowChart_iSAM_X1(Index) = Index
            FlowChart_iSAM_Y1(Index) = Index
            FlowChart_iSAM_X2(Index) = Index
            FlowChart_iSAM_Y2(Index) = Index
            NewFlowChartRecord = Index
        End Function



        ' returns true if the indexflowchart is in the list of number in symbol table data
        ' returns false if not, or problem
        Public Shared Function MyInListOfNumbers(IndexFlowChart As int32) As Boolean
            Dim Temp, Numbers As String
            Dim J As Int32
            MyTrace(254, "MyInListOfNumbers", 12)

            Temp = FD & IndexFlowChart & FD 'create a string to search for - Make sure the comma before and after so that it only find the complete number

            Numbers = FlowChart_PathLinks_And_CompiledCode(IndexFlowChart) 'This is the list of index numbers 
            J = My_INT(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))

            'hack  looking for errors
            If Numbers = "," Then
                Abug(9101, "comma number comma inside ... ", "Looking for " & Temp, " Have invalid " & Numbers)
                Return False
            End If
            If NetLinks(J) = "," Then
                netlinks(J, "")
                Abug(9102, "comma number comma inside ... ", "Looking for " & Temp, " Have invalid " & NetLinks(J))
                Return False
            End If
            'hack end


            'Check that the index is inside the netlinks bounds
            If J >= LBound(NetLinks_File) Then
                If J <= UBound(NetLinks_File) Then
                    Numbers = NetLinks(J) ' J is a valid pointer to get the netlink information
                Else
                    'hack, there is a problem with a pointer, points to something not in the array yet
                    MyMsgCtr("MyInListOfNumbers", 1022, CStr(LBound(NetLinks_File)), CStr(J), CStr(UBound(NetLinks_File)), Numbers, "", "", "", "", "")
                    ReDim NetLinks_File(MyMinMax(J + 1, UBound(NetLinks_File), UBound(NetLinks_File) + J + 1))
                    ReDim NetNames_File(MyMinMax(J + 1, UBound(NetLinks_File), UBound(NetLinks_File) + J + 1))
                    '                    Numbers = "" 'hack
                End If
            Else
                MyMsgCtr("MyInListOfNumbers", 1022, CStr(LBound(NetLinks_File)), CStr(J), CStr(UBound(NetLinks_File)), Numbers, "", "", "", "", "")
                Numbers = "" 'hack
            End If
            If InStr(Temp, Numbers) > 0 Then Return True

            ' We should never get here 
            'todo 'hack needs to make sure this will never happen
            Temp = Numbers
            While Len(Temp) > 0
                If Popvalue(Temp) = IndexFlowChart Then
                    Return True
                End If
            End While
            Return False
        End Function



        ' This will return the index in netlink() of this index
        Public Shared Function CleanListOfNetLinks(IndexNetLinks As int32) As int32 ' always return index to netlinks
            Dim I, K As int32
            Dim CleanList As String
            Dim MyList(1) As int32
            MyTrace(255, "CleanListOfNets", 53 - 23)

            If IndexNetLinks < 1 Then Return constantMyErrorCode
            If IndexNetLinks > UBound(NetLinks_File) Then
                ReDim Preserve NetLinks_File(IndexNetLinks + 1)
                ReDim Preserve NetNames_File(IndexNetLinks + 1)
            End If

            CleanList = NetLinks(IndexNetLinks)

            MyList(1) = 0
            While Len(CleanList) > 0
                ReDim Preserve MyList(UBound(MyList) + 1)
                K = Popvalue(CleanList)
                If K <> 0 Then
                    MyList(UBound(MyList) - 1) = K
                End If
            End While
            For I = 1 To UBound(MyList)
                If MyList(I) <> 0 Then ' Do not check not used /deleted numbers
                    For K = I + 1 To UBound(MyList)
                        If MyList(I) = MyList(K) Then
                            MyList(I) = 0 ' Delete the duplicate
                        End If
                    Next K
                End If
            Next I

            For I = 1 To UBound(MyList) - 1
                If MyList(I) <> 0 Then
                    If CleanList = "" Then CleanList = FD 'changes to only have it if there is going to be something.
                    CleanList = CleanList & MyList(I) & FD
                End If
            Next I
            If CleanList = "" Then
                AWarning(9114, " Cleaned up the list and it is now nothing ", "Was ->" & NetLinks(IndexNetLinks) & "<-", "")
            End If
            netlinks(IndexNetLinks, CleanList) 'Update this net List
            Return IndexNetLinks
        End Function

        Public Shared Sub ChangeOptionScreenSelectedIndex(Where As PictureBox)
            Dim I As Int32
            MyTrace(256, "ChangeFrom3SewlectedIndex", 69 - 55)

            CheckForAnySortNeeded("", 250)
            I = FindIndexIniSAMTable("Color", "DoNotAdd", Color_FileName, Color_iSAM_, SymbolScreen.ToolStripDropDownButtonColor.Text)
            CheckForAnySortNeeded("", 251)
            If I = constantMyErrorCode Then
                Abug(884, "FindAllPaths() : ", 0, SymbolScreen.ToolStripDropDownButtonColor.Text)
                Exit Sub
            End If
            'MyUnEnum(Color_TableStyle(I), OptionScreen.ComboBoxLineStyle, 2)



            'Error needs To be fixed
            'Temp = Color_TableStyle(I)



            SymbolScreen.ToolStripDropDownPathLineStyle.Text = I.ToString 'Color_TableStyle(I)
            SymbolScreen.ToolStripDropDownPathStart.Text = MyUnEnum(Color_TableStartCap(I), SymbolScreen.ToolStripDropDownPathStart, 0)
            SymbolScreen.ToolStripDropDownPathEnd.Text = MyUnEnum(Color_TableEndCap(I), SymbolScreen.ToolStripDropDownPathEnd, 1)

        End Sub



        'The following is to preview and print pages
        'Dim objCallback As System.Drawing.Image.GetThumbnailImageAbort = New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim printer As PrintDocument = New PrintDocument
        'AddHandler() printer.PrintPage, AddressOf PrintImage
        'printer.Print()
        'End Sub
        'Private Sub PrintImage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        'Dim img As Image = PictureBox1.Image
        'img = img.GetThumbnailImage(300, 300, objCallback, IntPtr.Zero)
        'e.Graphics.DrawImage(img, 0, 0)
        'End Sub
        'Function ThumbnailCallback() As Boolean
        'Return false
        'End Function
        '***************************************** Another Example to print ***************************
        'Public Sub printImage()
        'Dim objPrint As New PrintDocument
        'AddHandler() objPrint.PrintPage, AddressOf PrintImage_PrintPage
        '    objPrint.Print()
        'End Sub
        'Private Sub PrintImage_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        '    e.Graphics.DrawImage(PictureBox1.Image, 0, 0, PictureBox1.Width, PictureBox1.Height)
        'End Sub




        Public Shared Sub TimerTicked(sender As Object, e As EventArgs)
            MyTrace(257, "TimerTicked", 9) ' Dont count the comments (:

            ' should try to:
            'where logic paths have only one goto and one CameFrom move to gether
            'move symbols to have the logic shorter
            ' make the paths routed and stright
            ' move symbols as needed to make paths (ie move everything greater then X and/or Y right and/or down)
            ' Add variables are passed, so that multi threads can be running
            ' All subroutines used should start with "Timed_" so that the can be id'd
            Application.DoEvents() ' required always
            timer_MoveNextSymbol(TimerCounter)
            Application.DoEvents()
            If timer_MoveNextPath(TimerCounter) = True Then
                Application.DoEvents()
                timer_RerouteNextPath(TimerCounter)
            End If
            Application.DoEvents()
        End Sub

        Public Shared Sub timer_MoveNextSymbol(Idex As int32) ' always get the next to work on
            Dim Jdex As int32
            MyTrace(258, "timer_MoveNextSymbol", 74 - 59)

            Idex = MyMinMax(Idex, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
            If FlowChart_TableCode(Idex) <> "/use" Then Exit Sub ' cause we only want to work on symbol right now.
            For Jdex = Idex + 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If MyKeyword2String(My_Int(FlowChart_TableCode(Idex))) = "/use" Then
                    If SymbolOnTop(FlowChartScreen.PictureBox1, Idex, Jdex) = True Then
                        'move one of the symbols
                        MoveSymbolAndAllPaths(FlowChartScreen.PictureBox1, Idex, MyPoint1(CInt(MyUniverse.SysGen.ConstantSymbolCenter + MyUniverse.SysGen.ConstantSymbolCenter / 2), 0)) ' move over in the X the distance of this
                        ' Of course it will make it land on another one, but 
                    End If
                End If
            Next Jdex
        End Sub
        Public Shared Function timer_MoveNextPath(idex As int32) As Boolean
            Dim Jdex As int32
            Dim Line1, Line2 As MyLineStructure
            MyTrace(259, "timer_MoveNextPath", 25)

            timer_MoveNextPath = False
            idex = MyMinMax(idex, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
            Application.DoEvents()
            If FlowChart_TableCode(idex) <> "/path" Then Exit Function ' cause we only want to work on paths right now
            Application.DoEvents()
            For Jdex = idex + 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                Application.DoEvents()
                If FlowChart_TableCode(idex) = "/path" Then
                    Line1 = MyLine2(idex, idex)
                    Line2 = MyLine2(Jdex, Jdex)
                    If PathOnTop(FlowChartScreen.PictureBox1, Line1, Line2) = True Then
                        'move one of the symbols
                        timer_MoveNextPath = True
                        ' Move it nex if true
                        'MoveSymbolAndAllPaths(FlowChartScreen.PictureBox1, idex, MyPoint1(myuniverse.sysgen.ConstantSymbolCenter + myuniverse.sysgen.ConstantSymbolCenter / 2, 0)) ' move over in the X the distance of this
                        ' Of course it will make it land on another one, but 
                    End If
                    Application.DoEvents()
                End If
            Next Jdex
            Application.DoEvents()
        End Function


        Public Shared Sub timer_RerouteNextPath(Idex As int32)
            MyTrace(261, "timer_RerouteNextPath", 9)

            Idex = MyMinMax(Idex, 1, TopOfFile("FlowChart", FlowChart_FileCoded))
            Application.DoEvents()
            If FlowChart_TableCode(Idex) = "/path" Then Exit Sub ' cause we only want to work on paths right now
            Application.DoEvents()
            MoveSymbolAndAllPaths(FlowChartScreen.PictureBox1, Idex, MyPoint1(MyUniverse.SysGen.ConstantSymbolCenter, 0)) ' move over in the X the distance of this
            Application.DoEvents()
        End Sub



        Public Shared Function NetNames(Index As Int32) As String
            If Index < 1 Or Index > UBound(NetNames_File) Then Return Nothing 'Need to show an error 
            Return NetNames_File(Index)
        End Function
        Public Shared Sub netnames(Index As Int32, Value As String)
            If Index < 1 Or Index > UBound(NetNames_File) Then Return 'Need to show an error 
            NetNames_File(Index) = Value
        End Sub


        Public Shared Function NetLinks(Index As Int32) As String
            If Index < 1 Or Index > UBound(NetLinks_File) Then Return Nothing 'Need to show an error 
            If Len(NetLinks_File(Index)) < 3 And Not IsNothing(NetLinks_File(Index)) Then 'hack
                Abug(9105, "Finding bugs in the nex link table ", NetLinks_File(Index), "") 'hack
            End If 'hack
            Return NetLinks_File(Index)
        End Function
        Public Shared Sub netlinks(Index As Int32, Value As String)
            If Index < 1 Or Index > UBound(NetLinks_File) Then Return 'Need to show an error 
            If Len(Value) < 3 Then 'hack
                Abug(9106, "Finding bugs in setting the net link table ", Value, "") 'hack
                Exit Sub
            End If 'hack
            NetLinks_File(Index) = Value
        End Sub





        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableSymbolName(Index As Int32) As String
            MyTrace(262, "Named_TableSymbolName", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableSymbolName = Nothing
                Exit Function
            End If
            Named_TableSymbolName = Named_FileSymbolName(Index)
        End Function

        Public Shared Sub Named_TableSymbolName(Index As int32, Value As String)
            MyTrace(263, "Named_TableSymbolName", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileSymbolName(Index) = Value
            '           FindingMyBugs(10)'hack Least amount of checking here'hack '2020 07 19
            MyUniverse.MyCheatSheet.NamedSorted += 1
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableProgramText(Index As Int32) As String
            MyTrace(264, "Named_TableProgramText", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableProgramText = Nothing
                Exit Function
            End If
            Named_TableProgramText = Named_FileProgramText(Index)
        End Function

        Public Shared Sub Named_TableProgramText(Index As int32, Value As String)
            MyTrace(265, "Named_TableProgramText", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileProgramText(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableOpCode(Index As Int32) As String
            MyTrace(266, "Named_TableOpCode", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableOpCode = Nothing
                Exit Function
            End If
            Named_TableOpCode = Named_FileOpCode(Index)
        End Function

        Public Shared Sub Named_TableOpCode(Index As int32, Value As String)
            MyTrace(267, "Named_TableOpCode", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileOpCode(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableIndexes(Index As Int32) As Int32
            MyTrace(268, "Named_TableIndexes", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableIndexes = Nothing
                Exit Function
            End If
            Named_TableIndexes = Named_FileIndexes(Index)
        End Function



        Public Shared Sub Named_TableIndexes(Index As Int32, value As Int32)
            MyTrace(269, "Named_TableIndexes_ByName", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileIndexes(Index) = value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableStroke(Index As Int32) As String
            MyTrace(271, "Named_TableStroke", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableStroke = Nothing
                Exit Function
            End If
            Named_TableStroke = Named_FileStroke(Index)
        End Function



        Public Shared Sub Named_TableStroke(Index As int32, Value As String)
            MyTrace(272, "Named_TableStroke", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileStroke(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableNameofFile(Index As Int32) As String
            MyTrace(273, "Named_TableFileName", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableNameofFile = Nothing
                Exit Function
            End If
            Named_TableNameofFile = Named_FileNameOfFile(Index)
        End Function


        Public Shared Sub Named_TableNameOfFile(Index As int32, Value As String)
            MyTrace(274, "Named_TableFileName", 7)

            If InvalidIndex(Index, Named_FileNameOfFile, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileNameOfFile(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableNotes(Index As Int32) As String
            MyTrace(275, "Named_TableNotes", 6)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableNotes = Nothing
                Exit Function
            End If
            Named_TableNotes = Named_FileNotes(Index)
        End Function

        Public Shared Sub Named_TableNotes(Index As int32, Value As String)
            MyTrace(276, "Named_TableNotes", 6)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileNotes(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableAuthor(Index As Int32) As String
            MyTrace(277, "Named_TableAuthor", 8)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableAuthor = Nothing
                Exit Function
            End If
            Named_TableAuthor = Named_FileAuthor(Index)
        End Function


        Public Shared Sub Named_TableAuthor(Index As int32, Value As String)
            MyTrace(278, "Named_TableAuthor", 7)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileAuthor(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableVersion(Index As Int32) As String
            MyTrace(279, "Named_TableVersion", 502 - 495)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableVersion = Nothing
                Exit Function
            End If
            Named_TableVersion = Named_FileVersion(Index)
        End Function


        Public Shared Sub Named_TableVersion(Index As int32, Value As String)
            MyTrace(281, "Named_TableVersion", 11 - 5)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileVersion(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Named_TableSyntax(Index As Int32) As String
            MyTrace(282, "Named_TableSyntax", 502 - 495)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Named_TableSyntax = Nothing
                Exit Function
            End If
            Named_TableSyntax = Named_FileSyntax(Index)
        End Function


        Public Shared Sub Named_TableSyntax(Index As int32, Value As String)
            MyTrace(283, "Named_TableSyntax", 11 - 5)

            If InvalidIndex(Index, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            Named_FileSyntax(Index) = Value
        End Sub


        Public Shared Function FindColorFromDataType(DataTypeName As String) As String
            Dim Idex, Kdex, Jdex As int32
            MyTrace(284, "FindColorFromDataType", 72 - 13)

            If DataTypeName = "" Or IsNothing(DataTypeName) Then
                FindColorFromDataType = Nothing
            End If

            If Trim(DataTypeName) = Trim(MyUniverse.MyCheatSheet.LastDataTypeFound) Then
                FindColorFromDataType = Trim(MyUniverse.MyCheatSheet.LastColorFound)
                Exit Function
            End If


            Kdex = TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
            Idex = CInt(Kdex / 2)
            Jdex = CInt((Idex - 4) / 2)
            While 1 = 1
                Select Case MyCompared3(DataType_TableName(DataType_iSAM_(Idex)), DataTypeName, DataType_TableName(DataType_iSAM_(Idex + 1)))
                    Case -5 ' Test 9 A > C unsorted list error
                        Abug(883, DataType_TableName(DataType_iSAM_(Idex)), DataTypeName, DataType_TableName(DataType_iSAM_(Idex + 1)))
                        Idex = Idex - Jdex
                    Case -4 'Test 5 & 7  both A=nothing and b = c then only A=nothing
                        FindColorFromDataType = Nothing
                        Idex = Idex + 1
                    Case -3 'test 11 A>b
                        Idex = Idex - Jdex
                    Case -2 'test 12  b>C
                        Idex = Idex + Jdex
                    Case -1 'Test 3 --> A = b
                        FindColorFromDataType = Color_TableName(DataType_TableColorIndex(Idex))
                        MyUniverse.MyCheatSheet.LastDataTypeFound = Trim(DataTypeName)
                        MyUniverse.MyCheatSheet.LastColorFound = Trim(FindColorFromDataType)
                        Exit Function
                    Case 0 'Test 2 & 10 A and C are both null or nothing then A<b<C not in list
                        FindColorFromDataType = Nothing
                        Exit While
                    Case 1 'Test 4 --> b=C so move forward just one.
                        Idex = Idex + 1
                    Case 2 'test 14 A<b
                        Idex = Idex + Jdex
                    Case 3 'test 13 b < C
                        Idex = Idex + Jdex
                    Case 4 'test 6 & 8 -->>> C is nothing and b > A then C=nothing
                        FindColorFromDataType = Nothing
                        Exit While
                    Case 5 'Test 1 & 15 --> b=nothing then no other test works (Error)
                        Abug(882, "FindColorFromData() : BinarySearchFail error >" & DataType_TableName(DataType_iSAM_(Idex)) & "<>" & DataTypeName & "<>" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "<", Idex, 0)
                        FindColorFromDataType = Nothing
                        Exit While
                End Select
                If Idex = 0 And Jdex = 1 Then
                    Exit While
                End If
                Idex = MyMinMax(Idex, 1, Kdex)
                Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
            End While

            FindColorFromDataType = Nothing
        End Function


        Public Shared Function FindWidthFromDataType(DataTypeName As String) As int32
            Dim I As int32
            Dim Idex, Kdex, Jdex As int32
            Dim ErrorCount As int32
            MyTrace(285, "FindWidthFromDataType", 633 - 576)

            Kdex = TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
            Idex = CInt(Kdex / 2)
            Jdex = CInt((Idex - 4) / 2)
            ErrorCount = 2048
            While ErrorCount > 0
                ErrorCount -= 1
                Select Case MyCompared3(DataType_TableName(DataType_iSAM_(Idex)), DataTypeName, DataType_TableName(DataType_iSAM_(Idex + 1)))
                    Case -5 ' Test 9 A > C unsorted list error
                        Abug(881, DataType_TableName(DataType_iSAM_(Idex)), DataTypeName, DataType_TableName(DataType_iSAM_(Idex + 1)))
                        Idex = Idex - Jdex
                    Case -4 'Test 5 & 7  both A=nothing and b = c then only A=nothing
                        FindWidthFromDataType = 0
                        Idex = Idex + 1
                    Case -3 'test 11 A>b
                        Idex = Idex - Jdex
                    Case -2 'test 12  b>C
                        Idex = Idex + Jdex
                    Case -1 'Test 3 --> A = b
                        FindWidthFromDataType = DataType_TableWidth(I)
                        Exit Function
                    Case 0 'Test 2 & 10 A and C are both null or nothing then A<b<C not in list
                        FindWidthFromDataType = 0
                        Exit While
                    Case 1 'Test 4 --> b=C so move forward just one.
                        Idex = Idex + 1
                    Case 2 'test 14 A<b
                        Idex = Idex + Jdex
                    Case 3 'test 13 b < C
                        Idex = Idex + Jdex
                    Case 4 'test 6 & 8 -->>> C is nothing and b > A then C=nothing
                        FindWidthFromDataType = 0
                        Exit While
                    Case 5 'Test 1 & 15 --> b=nothing then no other test works (Error)
                        Abug(879, DataType_TableName(DataType_iSAM_(Idex)), DataTypeName, DataType_TableName(DataType_iSAM_(Idex + 1)))
                        FindWidthFromDataType = 0
                        Exit Function
                End Select
                If Idex = 0 And Jdex = 1 Then
                    Exit While
                End If
                Idex = MyMinMax(Idex, 1, Kdex)
                Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
            End While

            For I = 1 To TopOfFile("DataType", DataType_FileName, DataType_iSAM_)
                If LCase(Trim(DataTypeName)) = LCase(Trim(DataType_TableName(I))) Then
                    FindWidthFromDataType = DataType_TableWidth(I)
                    Exit Function
                End If
            Next
            FindWidthFromDataType = 1 'default min datatype/line width
        End Function

        '***********************************************************************
        'returns the index of the name of the color
        Public Shared Function FindColor(Clr As String) As int32
            Dim I As int32
            Dim Idex, Kdex, Jdex As int32
            MyTrace(286, "FindColor", 95 - 37)

            If IsNothing(Clr) Then FindColor = constantMyErrorCode : Exit Function
            If Trim(Clr) = "" Then FindColor = constantMyErrorCode : Exit Function
            Kdex = TopOfFile("Color", Color_FileName, Color_iSAM_)
            Idex = CInt(Kdex / 2)
            Jdex = CInt((Idex - 4) / 2)
            While 1 = 1
                Select Case MyCompared3(Color_TableName(Color_iSAM_(Idex)), Clr, Color_TableName(Color_iSAM_(Idex + 1)))
                    Case -5 ' Test 9 A > C unsorted list error
                        Abug(878, Color_TableName(Color_iSAM_(Idex)), Clr, Color_TableName(Color_iSAM_(Idex + 1)))
                        Idex = Idex - Jdex
                    Case -4 'Test 5 & 7  both A=nothing and b = c then only A=nothing
                        FindColor = 1
                        Exit Function
                    Case -3 'test 11 A>b
                        Idex = Idex - Jdex
                    Case -2 'test 12  b>C
                        Idex = Idex + Jdex
                    Case -1 'Test 3 --> A = b
                        FindColor = Idex
                        Exit Function
                    Case 0 'Test 2 & 10 A and C are both null or nothing then A<b<C not in list
                        FindColor = constantMyErrorCode
                        Exit Function
                    Case 1 'Test 4 --> b=C so move forward just one.
                        Idex = Idex + 1
                    Case 2 'test 14 A<b
                        Idex = Idex + Jdex
                    Case 3 'test 13 b < C
                        Idex = Idex + Jdex
                    Case 4 'test 6 & 8 -->>> C is nothing and b > A then C=nothing
                        FindColor = Idex 'end of the file
                        Exit Function
                    Case 5 'Test 1 & 15 --> b=nothing then no other test works (Error)
                        If IsNothing(Clr) Then Exit While
                        If Trim(Clr) = "" Then Exit While
                        If Clr = FD Then Exit While
                        Abug(877, "Finding Color returns 5, meaning out of order", Color_TableName(Color_iSAM_(Idex)) & " : " & Clr & " : " & Color_TableName(Color_iSAM_(Idex + 1)), 0)
                        FindColor = constantMyErrorCode
                        Exit Function
                End Select
                If Idex = 0 And Jdex = 1 Then Exit While
                Idex = MyMinMax(Idex, 1, Kdex)
                Jdex = MyMinMax(CInt(Jdex / 2), 1, Kdex)
            End While
            'FindColor = -1
            'Exit Function

            'failed so try everything loop

            For I = 1 To UBound(Color_FileName)
                If LCase(Trim(Clr)) = LCase(Trim(Color_TableName(I))) Then
                    Abug(761, "FindColor() Failed to find it but a search of each and every one turned it up", I, Clr)
                    FindColor = I
                    Exit Function
                End If
            Next
            Abug(876, "FindColor():", Clr, 0)
            FindColor = constantMyErrorCode
        End Function

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableName(Index As Int32) As String
            MyTrace(287, "Color_TableName", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableName = Nothing
                Exit Function
            End If
            Color_TableName = Color_FileName(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableName(Index As Int32, Value As String)
            MyTrace(288, "Color_TableName", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileName(Index) = Value
            MyUniverse.MyCheatSheet.ColorsSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableStartCap(Index As Int32) As Int32
            MyTrace(289, "Color_TableStartCap", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableStartCap = Nothing
                Exit Function
            End If
            Color_TableStartCap = Color_FileStartCap(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableEndCap(Index As Int32) As Int32
            MyTrace(291, "Color_TableEndCap", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableEndCap = Nothing
                Exit Function
            End If
            Color_TableEndCap = Color_FileEndCap(Index)
        End Function


        '***********************************************************************
        'this returns the line style from the line number type
        Public Shared Function Color_TableStyle(Index As Int32) As Drawing2D.DashStyle
            MyTrace(292, "Color_TableStyle", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableStyle = Nothing
                Exit Function
            End If

            Select Case My_Int(MyUnEnum(Color_FileStyle(Index), SymbolScreen.ToolStripDropDownPathLineStyle, 1))
                Case 0
                    Return Drawing2D.DashStyle.Solid
                Case 1
                    Return Drawing2D.DashStyle.Dash
                Case 2
                    Return Drawing2D.DashStyle.DashDot
                Case 3
                    Return Drawing2D.DashStyle.DashDotDot
                Case 4
                    Return Drawing2D.DashStyle.Dot
                Case Else
                    Return Drawing2D.DashStyle.Solid
            End Select
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableAlpha(Index As Int32) As String
            MyTrace(293, "Color_TableAlpha", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableAlpha = Nothing
                Exit Function
            End If
            Color_TableAlpha = CStr(Color_FileAlpha(Index))
        End Function
        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableRed(Index As Int32) As String
            MyTrace(294, "Color_TableRed", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableRed = Nothing
                Exit Function
            End If
            Color_TableRed = CStr(Color_FileRed(Index))
        End Function
        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableGreen(Index As Int32) As String
            MyTrace(295, "Color_TableGreen", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableGreen = Nothing
                Exit Function
            End If
            Color_TableGreen = CStr(Color_FileGreen(Index))
        End Function
        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Color_TableBlue(Index As Int32) As String
            MyTrace(296, "Color_TableBlue", 8)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Color_TableBlue = Nothing
                Exit Function
            End If
            Color_TableBlue = CStr(Color_FileBlue(Index))
        End Function

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableStartCap(Index As Int32, value As Int32)
            MyTrace(297, "Color_TableStartCap", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileStartCap(Index) = CByte(MyMinMax(value, 0, 255))
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableEndCap(Index As Int32, value As Int32)
            MyTrace(298, "Color_TableEndCap", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileEndCap(Index) = CByte(MyMinMax(value, 0, 255))
        End Sub

        '*******************************************************************
        'This saves the style of color index in the drop down 
        ' one for string input 
        Public Shared Sub Color_TableStyle(Index As int32, value As String)
            MyTrace(299, "Color_TableStyle", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileStyle(Index) = CByte(MyMinMax(MyEnumValue(Trim(value), SymbolScreen.ToolStripDropDownPathLineStyle), 0, 255))
        End Sub
        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        'one for DataType_FileNumberOfBytes input
        Public Shared Sub Color_TableStyle(Index As int32, value As int32)
            MyTrace(301, "Color_TableStyle", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileStyle(Index) = CByte(MyMinMax(value, 0, 255))
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableAlpha(Index As Int32, Value As Int32)
            MyTrace(302, "Color_TableAlpha", 7)
            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileAlpha(Index) = CByte(MyMinMax(Value, 0, 255))
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableRed(Index As Int32, Value As Int32)
            MyTrace(303, "Color_TableRed", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileRed(Index) = CByte(MyMinMax(Value, 0, 255))
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableGreen(Index As Int32, Value As Int32)
            MyTrace(304, "Color_TableGreen", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileGreen(Index) = CByte(MyMinMax(Value, 0, 255))
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Color_TableBlue(Index As Int32, Value As Int32)
            MyTrace(305, "Color_TableBlue", 7)

            If InvalidIndex(Index, Color_FileName, Color_iSAM_) Then
                Exit Sub
            End If
            Color_FileBlue(Index) = CByte(MyMinMax(Value, 0, 255))
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableCode(Index As Int32, value As Byte)
            MyTrace(306, "Symbol_TableCode", 5)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileCoded(Index) = value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableCode(Index As Int32, value As String)
            MyTrace(307, "Symbol_TableCode", 5)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileCoded(Index) = MyKeyword_2_Byte(value)
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableSymbolName(Index As Int32) As String
            MyTrace(308, "Symbol_TableSymbolName", 70 - 66)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableSymbolName = constantMyErrorCode.ToString
                Exit Function
            End If
            Symbol_TableSymbolName = Symbol_FileSymbolName(Index)
        End Function



        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableSymbolName(Index As Int32, value As String)
            MyTrace(309, "Symbol_TableSymbolName", 75 - 71)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileSymbolName(Index) = value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableCoded_String(Index As Int32) As String
            MyTrace(311, "Symbol_TableCoded_String", 83 - 76)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableCoded_String = Nothing
                Exit Function
            End If
            Symbol_TableCoded_String = MyKeyword2String(Symbol_FileCoded(Index))
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableCoded_Byte(Index As Int32) As Byte
            MyTrace(312, "Symbol_TableCode_Byte", 91 - 84)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableCoded_Byte = Nothing
                Exit Function
            End If
            Symbol_TableCoded_Byte = Symbol_FileCoded(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableX1(Index As Int32) As Int32
            MyTrace(313, "Symbol_TableX1", 99 - 93)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableX1 = Nothing
                Exit Function
            End If
            Symbol_TableX1 = Symbol_FileX1(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableX1(Index As Int32, value As Int32)
            MyTrace(314, "Symbol_TableX1", 5)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileX1(Index) = value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableY1(Index As Int32) As Int32
            MyTrace(315, "Symbol_TableY1", 14 - 8)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableY1 = Nothing
                Exit Function
            End If
            Symbol_TableY1 = Symbol_FileY1(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableY1(Index As Int32, value As Int32)
            MyTrace(316, "Symbol_TableY1", 21 - 16)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileY1(Index) = value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableX2_io(Index As Int32) As Int32
            MyTrace(317, "Symbol_TableX2_io", 7)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableX2_io = Nothing
                Exit Function
            End If
            Symbol_TableX2_io = Symbol_FileX2_io(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableX2_io(Index As Int32, value As Int32)
            MyTrace(318, "Symbol_TableX2_io", 6)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileX2_io(Index) = value
        End Sub


        ' These two routines determines if it is a string or number and always returns a number
        Public Shared Function NumberOrIO(NumberIO As Int32) As Int32
            Return NumberIO
        End Function
        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function NumberOrIO(NumberIO As String) As Int32
            Return Popvalue(NumberIO)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableX2_io(Index As Int32, value As String)
            MyTrace(321, "Symbol_TableX2_io", 43 - 37)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileX2_io(Index) = NumberOrIO(value)
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_TableY2_dt(Index As Int32) As Int32
            MyTrace(322, "Symbol_TableY1_dt", 54 - 48)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_TableY2_dt = Nothing
                Exit Function
            End If
            Symbol_TableY2_dt = Symbol_FileY2_dt(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableY2_dt(Index As Int32, value As Int32)
            MyTrace(323, "Symbol_TableY1_dt", 61 - 55)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileY2_dt(Index) = value
        End Sub

        '***********************************************************************
        'forces it to be a number
        Public Shared Function NumberOrDT(Y2_DT As Int32) As Int32
            Return Y2_DT ' Assumed it is a Value
        End Function


        '***********************************************************************
        'forces it to find the index number
        Public Shared Function NumberOrDT(Y2_DT As String) As Int32
            Dim TempValue As Int32
            TempValue = FindIndexIniSAMTable("DataType", "Do Not Add", DataType_FileName, DataType_iSAM_, Y2_DT)
            If TempValue = constantMyErrorCode Then
                Return constantMyErrorCode
            Else
                Return TempValue ' Assumed it is a Value
            End If
        End Function

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_TableY2_dt(Index As Int32, Value As String) ' Assumed Datatype if passing a string
            MyTrace(325, "Symbol_TableY1_dt", 68 - 62)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_FileY2_dt(Index) = NumberOrDT(Value) ' Assumed it is a Value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function Symbol_Table_NameOfPoint(Index As Int32) As String
            MyTrace(326, "Symbol_Table_NameOfPoint", 77 - 70)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Symbol_Table_NameOfPoint = Nothing
                Exit Function
            End If
            Symbol_Table_NameOfPoint = Symbol_File_NameOfPoint(Index)
        End Function



        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub Symbol_Table_NameOfPoint(Index As Int32, value As String)
            MyTrace(327, "Symbol_Table_NameOfPoint", 5)

            If InvalidIndex(Index, Symbol_FileSymbolName) Then
                Exit Sub
            End If
            Symbol_File_NameOfPoint(Index) = value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableCode(Index As Int32) As String
            MyTrace(328, "FlowChart_TableCode", 92 - 89)

            If InvalidIndex(Index, FlowChart_FileNamed) Then
                FlowChart_TableCode = Nothing
                Exit Function
            End If
            FlowChart_TableCode = MyKeyword2String(FlowChart_FileCoded(Index))
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        'converts it from a string (name or number passed as a styring) to save.
        Public Shared Sub FlowChart_TableCode_X(Index As Int32, Value As String)
            MyTrace(329, "FlowChart_TableCode", 9002 - 8996)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                Exit Sub
            End If
            Select Case LCase(Value)
                Case "/use", "5"
                    FlowChart_FileCoded(Index) = 5
                Case "/path", "6"
                    FlowChart_FileCoded(Index) = 6
                Case "/delete", "14"
                    FlowChart_FileCoded(Index) = 14
                Case "/constant", "15"
                    FlowChart_FileCoded(Index) = 15
                Case "/error", "13"
                    FlowChart_FileCoded(Index) = 13
                Case Else
                    FlowChart_FileCoded(Index) = 0 'unknown
                    Abug(874, "FlowChart_TableCode():", "Unknown code ", Value)
            End Select
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableNamed(Index As Int32) As String
            MyTrace(331, "FlowChart_TableNamed", 11 - 5)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_TableNamed = Nothing
                Exit Function
            End If
            FlowChart_TableNamed = FlowChart_FileNamed(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub FlowChart_TableNamed(Index As Int32, Value As String)
            MyTrace(332, "FlowChart_TableNamed", 20 - 14)
            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                Exit Sub
            End If
            If Value = "$" Then 'hack
                Abug(999, "Stop and fix the path name from here", 0, 0)
            End If
            If Left(Value, 12) = "/path=Path_" Then 'hack
                Abug(767, "Stop here and check _,_ ", Index, Value) 'hack
            End If 'hack
            FlowChart_FileNamed(Index) = Value
            MyUniverse.MyCheatSheet.FlowChartSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_PathLinks_And_CompiledCode(IndexFlowChart As Int32) As String
            MyTrace(333, "FlowChart_TableLinks", 37 - 23)

            FlowChart_PathLinks_And_CompiledCode = Nothing
            If InvalidIndex(IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                Exit Function
            End If
            FlowChart_PathLinks_And_CompiledCode = FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart)
        End Function


        Public Shared Sub FlowChart_PathLinks_And_CompiledCode(IndexFlowChart As Int32, Value As String)
            MyTrace(334, "FlowChart_TableLinks", 59 - 42)

            If InvalidIndex(IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                Exit Sub
            End If
            If IsNothing(Value) Or Len(Value) < 3 Then
                AWarning(9110, "Saving small thing", CStr(IndexFlowChart), Value)
            End If
            FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableX1(Index As Int32) As Int32
            MyTrace(335, "FlowChart_TableX1", 7)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_TableX1 = Nothing
                Exit Function
            End If
            FlowChart_TableX1 = FlowChart_FileX1(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub FlowChart_TableX1(Index As Int32, Value As Int32)
            MyTrace(336, "FlowChart_TableX1", 77 - 69)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                'FlowChart_TableX1 = Nothing
                Exit Sub
            End If
            FlowChart_FileX1(Index) = Value
            MyUniverse.MyCheatSheet.FlowChartSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableY1(Index As Int32) As Int32
            MyTrace(337, "FlowChart_TableY1", 86 - 79)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_TableY1 = Nothing
                Exit Function
            End If
            FlowChart_TableY1 = FlowChart_FileY1(Index)
        End Function



        Public Shared Sub FlowChart_TableY1(Index As int32, Value As int32)
            MyTrace(338, "FlowChart_TableY1", 95 - 87)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                'FlowChart_TableY1 = Nothing
                Exit Sub
            End If
            FlowChart_FileY1(Index) = Value
            MyUniverse.MyCheatSheet.FlowChartSorted += 1
        End Sub



        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableX2_Rotation(Index As Int32) As Int32
            MyTrace(339, "FlowChart_TableX2_Rotation", 104 - 98)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_TableX2_Rotation = Nothing
                Exit Function
            End If
            FlowChart_TableX2_Rotation = FlowChart_FileX2_Rotation(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub FlowChart_TableX2_Rotation(Index As Int32, Value As Int32)
            MyTrace(341, "FlowChart_TableX2_Rotation", 13 - 5)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                'FlowChart_TableX2_Rotation = Nothing
                Exit Sub
            End If
            FlowChart_FileX2_Rotation(Index) = Value
            MyUniverse.MyCheatSheet.FlowChartSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_TableY2_Option(Index As Int32) As Int32
            MyTrace(342, "FlowChart_TableY2_Option", 22 - 16)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_TableY2_Option = Nothing
                Exit Function
            End If
            FlowChart_TableY2_Option = FlowChart_FileY2_Option(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub FlowChart_TableY2_Option(Index As Int32, Value As Int32)
            MyTrace(343, "FlowChart_TableY2_Option", 31 - 23)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                '                FlowChart_TableY2_Option = Nothing
                Exit Sub
            End If
            FlowChart_FileY2_Option(Index) = Value
            MyUniverse.MyCheatSheet.FlowChartSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function FlowChart_Table_DataType(Index As Int32) As String
            MyTrace(344, "FlowChart_Table_DataType", 40 - 33)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                FlowChart_Table_DataType = Nothing
                Exit Function
            End If
            FlowChart_Table_DataType = FlowChart_File_DataType(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub FlowChart_Table_DataType(Index As Int32, Value As String)
            MyTrace(345, "FlowChart_Table_DataType", 48 - 41)

            If InvalidIndex(Index, FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                'FlowChart_Table_DataType = Nothing
                Exit Sub
            End If
            FlowChart_File_DataType(Index) = Value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_TableName(Index As Int32) As String
            MyTrace(346, "DataType_TableName", 9 - 2)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_TableName = Nothing
                Exit Function
            End If
            DataType_TableName = DataType_FileName(Index)
        End Function

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub DataType_TableName(Index As Int32, Value As String)
            MyTrace(347, "DataType_TableName", 78 - 61)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                Exit Sub
            End If
            DataType_FileName(Index) = Value
            MyUniverse.MyCheatSheet.DataTypeSorted += 1
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_Color(Index As Int32) As String ' returns the name of this color number in the color table
            MyTrace(348, "DataType_Color", 63 - 57)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_Color = Nothing
                Exit Function
            End If
            DataType_Color = Color_FileName(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_TableColorIndex(Index As Int32) As Int32
            MyTrace(349, "DataType_TableColorIndex", 8 - 2)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_TableColorIndex = Nothing
                Exit Function
            End If
            DataType_TableColorIndex = DataType_FileColorIndex(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub DataType_TableColorIndex(Index As Int32, Value As Int32)
            MyTrace(351, "DataType_TableColorIndex", 96 - 90)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                Exit Sub
            End If
            DataType_FileColorIndex(Index) = Value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_TableDescribtion(Index As Int32) As String
            MyTrace(352, "DataType_TableDescribtion", 205 - 198)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_TableDescribtion = Nothing
                Exit Function
            End If
            DataType_TableDescribtion = DataType_FileDescribtion(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub DataType_TableDescribtion(Index As Int32, Value As String)
            MyTrace(353, "DataType_TableDescribtion", 12 - 7)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                Exit Sub
            End If
            DataType_FileDescribtion(Index) = Value
        End Sub

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_TableWidth(Index As Int32) As Byte
            MyTrace(354, "DataType_TableWidth", 21 - 14)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_TableWidth = Nothing
                Exit Function
            End If
            DataType_TableWidth = DataType_FileWidth(Index)
        End Function


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub DataType_TableWidth(Index As Int32, Value As Byte)
            MyTrace(355, "DataType_TableWidth", 8 - 3)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                Exit Sub
            End If
            DataType_FileWidth(Index) = Value
        End Sub


        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Function DataType_TableNumberOfBytes(Index As Int32) As String
            MyTrace(356, "DataType_TableNumberOfBytes", 37 - 31)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                DataType_TableNumberOfBytes = Nothing
                Exit Function
            End If
            DataType_TableNumberOfBytes = CStr(DataType_FileNumberOfBytes(Index))
        End Function

        '***********************************************************************
        ' This is to isolate the actual data from the program (So that it can be converted later versions)
        Public Shared Sub DataType_TableNumberOfBytes(Index As Int32, Value As Int32)
            MyTrace(357, "DataType_TableNuumberOfBytes", 45 - 39)

            If InvalidIndex(Index, DataType_FileName, DataType_iSAM_) Then
                Exit Sub
            End If
            DataType_FileNumberOfBytes(Index) = Value
        End Sub


        '***********************************************************************
        'Double checks that everything sorted correctly 
        'hack
        'can delete when it no longer finds problems
        Public Shared Function MyIsValidCheckSortAll_String(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32) As Boolean
            Dim Idex, Topmost As int32
            MyTrace(358, "MyIsValidCheckSortAll_String", 53 - 23)

            Topmost = TopOfFile(MyTable, MyArray, iSAM) 'UBound(MyArray) ' Changed 04/09/19 to get a lower number checking
            MyIsValidCheckSortAll_String = True

            For Idex = Topmost To 2 Step -1
                If IsNothing(MyArray(Idex)) And iSAM(Idex) <> 0 Then
                    MyMsgCtr("MyIsValidCheckSortAll_String", 1385, Idex.ToString, iSAM(Idex).ToString, "Data Set to Nothing", "", "", "", "", "", "")
                    MyIsValidCheckSortAll_String = False ' Can not index nothing????????
                End If
                If iSAM(Idex) <= 0 Or iSAM(Idex) > UBound(MyArray) Then
                    MyMsgCtr("MyIsValidCheckSortAll_String", 1123, Idex.ToString, iSAM(Idex).ToString, "1", UBound(MyArray).ToString, "?", "?", "?", "?", "?")
                    MyIsValidCheckSortAll_String = False
                    Exit For
                End If
                ' If two iSAMs equal each other then we have major problems with the iSAM
                If iSAM(Idex) <> 0 And iSAM(Idex - 1) = iSAM(Idex) Then
                    MyMsgCtr("MyIsValidCheckSortAll_String", 1017, Idex.ToString, iSAM(Idex - 1).ToString, iSAM(Idex).ToString, "", "", "", "", "", "")
                    MyIsValidCheckSortAll_String = False
                    Exit For
                End If
                If iSAM(Idex - 1) = iSAM(Idex) Then
                    MyMsgCtr("MyIsValidCheckSortAll_String", 1003, (Idex - 1).ToString, Idex.ToString, MyCompared1_a(MyArray(iSAM(Idex - 1)).ToString, MyArray(iSAM(Idex))).ToString, MyArray(iSAM(Idex - 1)).ToString, MyArray(iSAM(Idex)).ToString, "", "", "", "2") ' EXTRA so I can see why it's here
                    MyIsValidCheckSortAll_String = False
                    FindingMyBugs(10) 'hack Least amount of checking here
                    Exit For
                End If
                ' Is Array Is out of order (returns 0 if equal, -1 if A < B, 1 if A > B which is an error
                If MyCompared2(MyArray, iSAM, Idex - 1, Idex) = 1 Then 'MyCompared(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))) = 1 Then
                    'MyMsgCtr("MyIsValidCheckSortAll_String", 1003, Idex - 1, Idex, MyCompared1_a(MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex))), MyArray(iSAM(Idex - 1)), MyArray(iSAM(Idex)), "", "", "", "2") ' EXTRA so I can see why it's here
                    MyIsValidCheckSortAll_String = False
                    Select Case LCase(MyTable)
                        Case "FlowChart"
                            MyUniverse.MyCheatSheet.FlowChartSorted += 1
                        Case "datatype"
                            MyUniverse.MyCheatSheet.DataTypeSorted += 1
                        Case "color"
                            MyUniverse.MyCheatSheet.ColorsSorted += 1
                        Case "named"
                            MyUniverse.MyCheatSheet.NamedSorted += 1
                        Case Else ' sort every thing
                            MyUniverse.MyCheatSheet.FlowChartSorted += 1
                            MyUniverse.MyCheatSheet.DataTypeSorted += 1
                            MyUniverse.MyCheatSheet.ColorsSorted += 1
                            MyUniverse.MyCheatSheet.NamedSorted += 1
                    End Select
                    Exit For
                End If
            Next
        End Function
        '***********************************************************************
        ' This is to make sure that all array referances are inside the array
        Public Shared Function InvalidIndex(Index As int32, MyArray() As String) As Boolean
            MyTrace(359, "InvalidIndex", 6)
            If Index < 1 Then Return True ' I dont use array zero
            If Index > UBound(MyArray) Then Return True
            Return False
        End Function


        'change to be fewer test 2020 09 02
        '        '*******************************************************************
        'Checking if the index to the array is inside the bounds or not.
        'It should never be outside, or else there is a programming bug again
        Public Shared Function InvalidIndex(Index As int32, ByRef MyArray() As String, ByRef iSAM() As int32) As Boolean
            MyTrace(361, "InvalidIndex", 7)

            If Index < 1 Then Return True 'Index has not been set yet
            If Index >= UBound(iSAM) - 1 Then Return True
            If iSAM(Index) < 1 Then Return True ' Isam index has not been set

            If UBound(MyArray) <> UBound(iSAM) Then Return True
            If Index <> MyMinMax(Index, 1, UBound(MyArray)) Then Return True
            If iSAM(Index) <> MyMinMax(iSAM(Index), 1, UBound(iSAM)) Then Return True
            Return False
        End Function


        '***********************************************************************
        'Checks to see if it is a valid index for this array
        Public Shared Function InvalidIndex(Index As Int32, MyArrayLong() As Int32, ByRef iSAM() As Int32) As Boolean
            MyTrace(362, "InvalidIndex", 8)
            If Index < 1 Then Return True
            If iSAM(Index) < 1 Then Return True
            If MyArrayLong(Index) = Nothing Then Return True

            If UBound(MyArrayLong) <> UBound(iSAM) Then Return True
            If Index <> MyMinMax(Index, 1, UBound(MyArrayLong)) Then Return True
            If iSAM(Index) <> MyMinMax(iSAM(Index), 1, UBound(iSAM)) Then Return True
            If iSAM(Index) <> 0 And MyArrayLong(Index) = Nothing Then Return True
            Return False
        End Function

        '***********************************************************************
        'This will replace the string with it replacement 
        Public Shared Sub MyReplaceAll(ByRef String1 As String, ChangeFrom As String, ChangeTo As String)
            Dim I, K, K1, K2 As Integer
            MyTrace(363, "MyReplaceAll", 460 - 449)

            I = InStr(Chr(179), String1)
            While I <> 0
                String1 = Mid(String1, 1, I) & ComputerLanguageGoToNextLine() & Mid(String1, I, Len(String1))
                K1 = AddGotoNextLine(String1, I, I) ' Add it first so that the I does not change
                K2 = AddCameFromLastLine(String1, I + K1, I) 'After the cr
                'need to also add a CameFrom before the cr and a gotonext after it 
                K = I + Len(ComputerLanguageMultiLine()) + Len(MyUniverse.SysGen.ConstantGoToNextLineSyntax) + Len(MyUniverse.SysGen.ConstantCameFromLastLineSyntax)
                I = InStr(K, String1, Chr(179))
            End While

        End Sub

        '***********************************************************************
        'This returns each line of code to decompile, converting into a generaic syntax (keywords, operators, ...)
        'None of this is checked yet
        Public Shared Function ComputerLanguagePreProcessor(Key_Line As String) As String
            Dim I As int32
            Dim K1, K2 As Integer
            Dim CommentLanguage As String
            MyTrace(364, "ComputerLanguagePreProcessor", 558 - 466)

            ' make evertying a quote after a comment
            CommentLanguage = ""

            CommentLanguage = Key_Line
            MyReplaceAll(Key_Line, ComputerLanguageMultiLine(), Chr(179)) ' Temp replacement
            If ComputerLanguageComment() <> "" And ComputerLanguageComment() = Nothing Then
                ' First put remarks inside quotes so that it can be treated as a quote constant (Notes are for symbols only this will keep it as a constant with the symbol
                I = InStr(Key_Line, ComputerLanguageComment())
                CommentLanguage = Key_Line
                If I > 0 Then
                    CommentLanguage = Mid(CommentLanguage, 1, I - 1 + Len(ComputerLanguageComment())) & MyUniverse.SysGen.ConstantQuote & Mid(CommentLanguage, I, Len(CommentLanguage)) & MyUniverse.SysGen.ConstantQuote
                End If

                MyReplaceAll(CommentLanguage, Chr(179), ComputerLanguageMultiLine())
                '' Add CameFrom and goto after taking care of all of the multi line CameFrom's
                K1 = AddCameFromLastLine(CommentLanguage, 1, 0)
                K2 = AddGotoNextLine(CommentLanguage, Len(CommentLanguage), 0) ' Need to add a gotonext
                MyReplaceAll(CommentLanguage, Chr(179), ComputerLanguageMultiLine())
            Else
                K1 = AddCameFromLastLine(CommentLanguage, 1, 0) ' Need to add a CameFrom before
                K2 = AddGotoNextLine(CommentLanguage, Len(CommentLanguage), 0) ' Need to add a gotonext
                MyReplaceAll(CommentLanguage, Chr(179), ComputerLanguageMultiLine())
            End If
            Select Case WhatComputerLanguage()
                Case "Generic"
                    Return CommentLanguage
                Case "Assembly" : Return CommentLanguage
                Case "Bash" : Return CommentLanguage
                Case "Basic"
                    Return CommentLanguage
                Case "Dos" : Return CommentLanguage
                Case "PowerShell" : Return CommentLanguage
                Case "C"
                    ' The comments need to be quoted to keep them together
                    ' Searches for 2
                    'I = InStr("/" & "/", CommentLanguage) ' Does not work
                    I = InStr(CommentLanguage, "//")
                    If I > 0 Then ' 2020 08 12 added a space after the // to make sure that there is white space between the two ie:  // "
                        CommentLanguage = Mid(CommentLanguage, 1, I - 1) & "// " & Chr(34) & Mid(CommentLanguage, I + 2, Len(CommentLanguage)) & Chr(34)
                    End If
                    If InStr(CommentLanguage, "/*") > 0 Then ' Start of comment
                        I = InStr(CommentLanguage, "/*")
                        CommentLanguage = Mid(CommentLanguage, 1, I - 1) & "// " & Chr(34) & Mid(CommentLanguage, I + 2, Len(CommentLanguage)) & Chr(34) ' Converted to line comment
                        MyUniverse.Languages.C.StillComment = True
                    ElseIf InStr(CommentLanguage, "*/") > 0 Then ' End of comment
                        I = InStr(CommentLanguage, "*/")
                        CommentLanguage = Mid(CommentLanguage, 1, I - 1) & "// " & Chr(34) & Mid(CommentLanguage, I + 2, Len(CommentLanguage)) & Chr(34) ' Converted to line comment
                        MyUniverse.Languages.C.StillComment = False
                    ElseIf MyUniverse.Languages.C.StillComment = True Then ' Still comment lines
                        'Convert this line to a line comment
                        CommentLanguage = "// " & CommentLanguage
                    End If
                    Return CommentLanguage
                Case "C#" : Return CommentLanguage
                Case "C++" : Return CommentLanguage
                Case "Clojure" : Return CommentLanguage
                Case "Dart" : Return CommentLanguage
                Case "DOS" : Return CommentLanguage
                Case "Elixir" : Return CommentLanguage
                Case "Forth" : Return CommentLanguage
                Case "Go" : Return CommentLanguage
                Case "Java" : Return CommentLanguage
                Case "JavaScript" : Return CommentLanguage
                Case "Kotlin" : Return CommentLanguage
                Case "Lisp" : Return CommentLanguage
                Case "ObjectiveC" : Return CommentLanguage
                Case "PHP" : Return CommentLanguage
                Case "Python" : Return CommentLanguage
                Case "R" : Return CommentLanguage
                Case "Ruby" : Return CommentLanguage
                Case "Rust" : Return CommentLanguage
                Case "Scala" : Return CommentLanguage
                Case "SQL" : Return CommentLanguage
                Case "Swift" : Return CommentLanguage
                Case "TypeScript" : Return CommentLanguage
                Case "VBA" : Return CommentLanguage
                Case "WebAssembly" : Return CommentLanguage
                Case "LanguageA" : Return CommentLanguage
                Case "LanguageB" : Return CommentLanguage
                Case "LanguageC" : Return CommentLanguage
                Case "LanguageD" : Return CommentLanguage
                Case "LanguageE" : Return CommentLanguage
                Case "LanguageF" : Return CommentLanguage
                Case "LanguageG" : Return CommentLanguage
                Case "LanguageH" : Return CommentLanguage
                Case "LanguageI" : Return CommentLanguage
                Case "LanguageJ" : Return CommentLanguage
                Case Else
                    Abug(742, "no computer language checked - Preprocessor", 0, 0)
                    Return CommentLanguage
            End Select
        End Function

        '***********************************************************************
        'This returns each line of code to decompile, converting into a generaic syntax (keywords, operators, ...)
        'None of this is checked yet (or used yet)

        Public Shared Function ComputerLanguageMidProcessor(KeyLine As String) As String
            MyTrace(365, "ComputerLanguageMidProcessor", 610 - 562)

            Select Case WhatComputerLanguage()
                Case "Generic" : Return KeyLine
                Case "Assembly" : Return KeyLine
                Case "Bash" : Return KeyLine
                Case "Basic" : Return KeyLine
                Case "Dos" : Return KeyLine
                Case "PowerShell" : Return KeyLine
                Case "C" : Return KeyLine
                Case "C#" : Return KeyLine
                Case "C++" : Return KeyLine
                Case "Clojure" : Return KeyLine
                Case "Dart" : Return KeyLine
                Case "Elixir" : Return KeyLine
                Case "Go" : Return KeyLine
                Case "Java" : Return KeyLine
                Case "JavaScript" : Return KeyLine
                Case "Kotlin" : Return KeyLine
                Case "ObjectiveC" : Return KeyLine
                Case "PHP" : Return KeyLine
                Case "Python" : Return KeyLine
                Case "R" : Return KeyLine
                Case "Ruby" : Return KeyLine
                Case "Rust" : Return KeyLine
                Case "Scala" : Return KeyLine
                Case "SQL" : Return KeyLine
                Case "Swift" : Return KeyLine
                Case "TypeScript" : Return KeyLine
                Case "VBA" : Return KeyLine
                Case "WebAssembly" : Return KeyLine
                Case "Lisp" : Return KeyLine
                Case "Forth" : Return KeyLine
                Case "DOS" : Return KeyLine
                Case "LanguageA" : Return KeyLine
                Case "LanguageB" : Return KeyLine
                Case "LanguageC" : Return KeyLine
                Case "LanguageD" : Return KeyLine
                Case "LanguageE" : Return KeyLine
                Case "LanguageF" : Return KeyLine
                Case "LanguageG" : Return KeyLine
                Case "LanguageH" : Return KeyLine
                Case "LanguageI" : Return KeyLine
                Case "LanguageJ" : Return KeyLine
                Case Else
                    Abug(742, "no computer language checked - Mid Processor", 0, 0)
                    Return KeyLine
            End Select

        End Function




        '***********************************************************************
        'This returns each line of code to decompile, converting into a generaic syntax (keywords, operators, ...)
        'None of this is checked yet, AND IT IS NOT USED.

        Public Shared Function ComputerLanguagePostProcessor(KeyLine As String) As String
            MyTrace(366, "ComputerLanguagePostProcessor", 663 - 615)

            Select Case WhatComputerLanguage()
                Case "Generic" : Return KeyLine
                Case "Assembly" : Return KeyLine
                Case "Bash" : Return KeyLine
                Case "Basic" : Return KeyLine
                Case "Dos" : Return KeyLine
                Case "PowerShell" : Return KeyLine
                Case "C" : Return KeyLine
                Case "C#" : Return KeyLine
                Case "C++" : Return KeyLine
                Case "Clojure" : Return KeyLine
                Case "Dart" : Return KeyLine
                Case "Elixir" : Return KeyLine
                Case "Go" : Return KeyLine
                Case "Java" : Return KeyLine
                Case "JavaScript" : Return KeyLine
                Case "Kotlin" : Return KeyLine
                Case "ObjectiveC" : Return KeyLine
                Case "PHP" : Return KeyLine
                Case "Python" : Return KeyLine
                Case "R" : Return KeyLine
                Case "Ruby" : Return KeyLine
                Case "Rust" : Return KeyLine
                Case "Scala" : Return KeyLine
                Case "SQL" : Return KeyLine
                Case "Swift" : Return KeyLine
                Case "TypeScript" : Return KeyLine
                Case "VBA" : Return KeyLine
                Case "WebAssembly" : Return KeyLine
                Case "Lisp" : Return KeyLine
                Case "Forth" : Return KeyLine
                Case "LanguageA" : Return KeyLine
                Case "LanguageB" : Return KeyLine
                Case "LanguageC" : Return KeyLine
                Case "LanguageD" : Return KeyLine
                Case "LanguageE" : Return KeyLine
                Case "LanguageF" : Return KeyLine
                Case "LanguageG" : Return KeyLine
                Case "LanguageH" : Return KeyLine
                Case "LanguageI" : Return KeyLine
                Case "LanguageJ" : Return KeyLine
                Case Else
                    Abug(742, "no computer language checked - Post Processor", 0, 0)
                    Return KeyLine
            End Select

        End Function


        '*******************************************************************
        'This returns what a comment language string starts with 
        'See INIT() for what number 2 is
        Public Shared Function ComputerLanguageComment() As String ' Returns what a comment is in this language
            Dim I As Int32
            MyTrace(367, "ComputerLanguageComment", 6)

            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageComment = MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 2)
        End Function

        '*******************************************************************
        'See INIT() for what number 6 is
        Public Shared Function ComputerLanguageVariableNameCharacters() As String ' Returns if this is a valid character for a Variable name in this language
            Dim I As Int32
            MyTrace(368, "ComputerLanguageVariableNameCharacters", 6)

            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageVariableNameCharacters = MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 6)
        End Function

        '*******************************************************************
        'This is the default of the file extension for this language 
        'Note that some languages have more than one extension and
        'needs to be fixed in future versions.
        'See INIT() for what number 3 is
        Public Shared Function ComputerLanguageExtention() As String ' Returns the name of this number for the computer language
            Dim I As Int32
            MyTrace(369, "ComputerLanguageExtention", 6)

            ' Get the index to this computer language
            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageExtention = MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 3)
        End Function

        '*******************************************************************
        'This is where the logic goes to next step, it can only goto one location, you can not branch here ???
        'See INIT() for what number 7 is
        Public Shared Function ComputerLanguageGoToNextLine() As String ' 
            Dim I As Int32
            MyTrace(371, "ComputerLanguageGoToNextLine", 6)

            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageGoToNextLine = Trim(MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 7))
        End Function

        '*******************************************************************
        ' This is where the symbol logic comes from (Logic can go only one place, but can come from many differant places.)
        '(Assumed not multi processor etc...)
        'See INIT() for what number 8 is

        Public Shared Function ComputerLanguageCameFromLastLine() As String ' This is usually called a lable, it's where a goto goes.
            Dim I As Int32
            MyTrace(372, "ComputerLanguageCameFromLastLin", 6)

            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageCameFromLastLine = Trim(MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 8))
        End Function

        '***********************************************************************
        ' Returns the character string between statements on oneline 
        'See INIT() for what number 4 is
        Public Shared Function ComputerLanguageMultiLine() As String
            Dim I As Int32
            MyTrace(373, "ComputerLanguageMultiLine", 6)

            ' Get the index to this computer language
            I = MyEnumValue(WhatComputerLanguage(), OptionScreen.ToolStripDropDownComputerLanguage)
            ComputerLanguageMultiLine = MyUnEnum(I, OptionScreen.ToolStripDropDownComputerLanguage, 4) ' Get start of comment
        End Function

        '***********************************************************************
        ' Turns the language on or off, for pre-mid-post processing
        Public Shared Function ComputerLanguageTurnedOn(WhichComputerLanguage As String) As Boolean ' Turns On this language
            Dim XX As Int32
            MyTrace(374, "ComputerLanguageTurnedOn", 8)
            XX = MyEnumValue(WhichComputerLanguage, OptionScreen.ToolStripDropDownComputerLanguage)
            SelectInToolStripDropDownButton(OptionScreen.ToolStripDropDownComputerLanguage, WhichComputerLanguage)
            OptionScreen.ToolStripDropDownComputerLanguage.Text = WhichComputerLanguage
            Return True ' just to make all of the computerlanguage...() functions
        End Function


        '***********************************************************************
        ' Need to change this to just return I 2020 08 16
        Public Shared Function ComputerLanguageNumber(Whichlanguage As String) As int32 ' Returns the number of the computer language (index in the combobox)
            MyTrace(375, "ComputerLanguageNumber", 4)
            ComputerLanguageNumber = MyEnumValue(Whichlanguage, OptionScreen.ToolStripDropDownComputerLanguage)
            'ComputerLanguageNumber = Popvalue(MyUnEnum(ComputerLanguageNumber , OptionScreen.ToolStripDropDownComputerLanguage, 1))
        End Function



        '*******************************************************************
        'See INIT() for what number 0 is
        'Never used - used WhatComputerLanguage() to get the current language , Here only for reference
        Public Shared Function ComputerLanguageString(WhichLanguage As int32) As String ' Returns the name of this number for the computer language
            MyTrace(376, "ComputerLanguageString", 4)

            ComputerLanguageString = MyUnEnum(WhichLanguage, OptionScreen.ToolStripDropDownComputerLanguage, 0)
        End Function


        '***********************************************************************
        'This changes the state of a options bit 
        'Assumes on, off is passed only
        Public Shared Sub Toggle(AString As String)
            Dim MyNumber As int32
            MyTrace(377, "Toggle", 54 - 42)
            MyNumber = ComputerLanguageNumber(AString)
            If IsBitSet(MyNumber) Then
                BitSet(MyNumber, "off")
            Else
                BitSet(MyNumber, "on")
            End If
            Exit Sub
        End Sub

        '***********************************************************************
        'returns that name of the current selected language
        Public Shared Function WhatComputerLanguage() As String
            Dim XX As String
            MyTrace(378, "WhatComputerLanguage", 69 - 57)
            XX = OptionScreen.ToolStripDropDownComputerLanguage.Text
            If OptionScreen.ToolStripDropDownComputerLanguage.Text = "" Then
                OptionScreen.ToolStripDropDownComputerLanguage.DropDownItems.Find("Generic", True)
                Application.DoEvents()
                WhatComputerLanguage = "generic"
                Exit Function
            End If
            XX = OptionScreen.ToolStripDropDownComputerLanguage.Text
            WhatComputerLanguage = Trim(Pop(XX, FD))
        End Function

        '***********************************************************************
        'This sets, or unsets a bit option
        ' Level is the number 1-1000, and passed on/off , yes/no, true/false
        Public Shared Sub BitSet(Level As Int32, SetBitTo As String)
            Dim MyByte As Int32
            Dim MyBit As Int32
            MyTrace(379, "BitSet", 503 - 476)

            If Level < 9 Or Level > 9990 Then
                Abug(853, "BitSet():", Level, SetBitTo)
                MyMsgCtr("BitSet", 1436, "Invalid Message Error Number " & Level, "ERROR *******", "", "", "", "", "", "", "")
            End If
            MyByte = CInt(Fix(Level / 8))
            MyByte = MyMinMax(MyByte, 1, UBound(MyMessageBits) - 1)
            MyBit = MyMinMax(Level - (MyByte * 8), 0, 7)

            Select Case LCase(SetBitTo)
                Case "yes", "true", "on"
                    MyMessageBits(MyByte) = CByte(MyMessageBits(MyByte) Or MyBits(MyBit))
                Case "no", "false", "off"
                    MyMessageBits(MyByte) = CByte(MyMessageBits(MyByte) And (Not MyBits(MyBit)))
                Case "otherthingsxxxx" 'Options for the third parameter
                Case Else
                    MyMsgCtr("BitSet",
                             1000,
                             "bitset()  Not yes,no, True,False, On,off ",
                             "Set To >" & SetBitTo & "<",
                             " Level=" & Level,
                             " Bit=" & MyBit,
                             " Byte=" & MyByte,
                             "", "", "", "")
            End Select
        End Sub

        '***********************************************************************
        'returns if the bit is set or not
        Public Shared Function IsBitSet(Level As Int32) As Boolean
            Dim MyByte As Int32
            Dim MyBit As Int32
            Dim Temp As Int32
            MyTrace(381, " IsBitSet", 23 - 7)

            MyByte = CInt(Fix(Level / 8))
            MyByte = MyMinMax(MyByte, 1, UBound(MyMessageBits) - 1)
            MyBit = MyMinMax(Level - (MyByte * 8), 0, 7)

            Temp = MyMessageBits(MyByte) And MyBits(MyBit)

            If (MyMessageBits(MyByte) And MyBits(MyBit)) > 0 Then
                IsBitSet = True
            Else
                IsBitSet = False
            End If
        End Function


        '***********************************************************************
        'NOT USED
        'This returns if the point is closest enough to move (snap grid)

        Public Shared Function FlowChart_XY_IsClose(Index As int32, X1 As int32, Y1 As int32, X2 As int32, Y2 As int32) As Boolean
            Dim Dist As int32
            MyTrace(382, " FlowChart_XY_IsClose", 44 - 27)

            FlowChart_XY_IsClose = False
            If Index < 1 Then Exit Function
            Dist = MyDistance(MyPoint1(X1, Y1), MyPoint2(X2, Y2))
            If Dist <= MyUniverse.SysGen.ConstantDistanceToMovePaths Then
                FlowChart_XY_IsClose = True
            End If

            If MyABS(X1 - X2) < MyUniverse.SysGen.ConstantDistanceToMovePaths Then
                FlowChart_XY_IsClose = True
            End If

            If MyABS(Y1 - Y2) < MyUniverse.SysGen.ConstantDistanceToMovePaths Then
                FlowChart_XY_IsClose = True
            End If

        End Function


        '***********************************************************************
        ' Checking if I had forgotten to sort an array?
        Public Shared Sub CheckForAnySortNeeded(WhereFrom As String, Level As Int32)
            Dim Idex As Int32
            MyTrace(383, "CheckForAnySortNeeded", 76 - 49)

            If MyUniverse.MyCheatSheet.ColorsSorted <> 0 Then
                ShowSorts("Colors", SortColors()) : MyUniverse.MyCheatSheet.ColorsSorted = 0
            End If
            If MyUniverse.MyCheatSheet.DataTypeSorted <> 0 Then
                ShowSorts("DataType", SortDataType()) : MyUniverse.MyCheatSheet.DataTypeSorted = 0
            End If
            If MyUniverse.MyCheatSheet.NamedSorted <> 0 Then
                ShowSorts("Named", SortNamed())
                ' This is just to make sure the symbol table is still in order
                For Idex = 1 To TopOfFile("named", Named_FileSymbolName, Named_File_iSAM)
                    GetSelfCorrectingIndexes(Named_TableSymbolName(Idex))
                Next Idex
                MyUniverse.MyCheatSheet.NamedSorted = 0
            End If
            If MyUniverse.MyCheatSheet.FlowChartSorted <> 0 Then
                ShowSorts("FlowChart", SortFlowChart()) : MyUniverse.MyCheatSheet.FlowChartSorted = 0
            End If

        End Sub

        '***********************************************************************
        'Checking that everything is OK
        'Should be called inside of findingmybugs
        Public Shared Function MyCheckValidFlowChartRecord(Index As Int32) As Boolean
            MyTrace(384, "MyCheckValidFlowChartRecord", 624 - 580)

            MyCheckValidFlowChartRecord = True
            'First check if valid Index
            If Index < 1 Then
                MyMsgCtr("MyCheckValidFlowChartRecord", 1390, Index.ToString, "", "", "", "", "", "", "", "")
                Return False
            End If
            If Index > TopOfFile("FlowChart", FlowChart_FileNamed, FlowChart_iSAM_Name) Then
                MyMsgCtr("MyCheckValidFlowChartRecord", 1250, Index.ToString, TopOfFile("FlowChart", FlowChart_FileNamed, FlowChart_iSAM_Name).ToString, "", "", "", "", "", "", "")
                Return False
            End If
            ' Next check for a valid code
            'Also Then CHeck for the correct information on each type of Record
            Select Case LCase(FlowChart_TableCode(Index))
                Case "/use"
                    If MyCheckValidUse(Index) = False Then
                        Return False
                    End If
                Case "/path"
                    If ConnectPath(Index) = 0 Then
                        Return False
                    End If
                Case "/constant"
                    Abug(852, "MyCheckValidFlowChartRecord():", Index, "/constant")
                Case "/error"
                    Abug(851, "MyCheckValidFlowChartRecord():", Index, "/error")
                Case Else
                    MyMsgCtr("MyCheckValidFlowChartRecord", 2312, FlowChart_TableCode(Index), Index.ToString, "", "", "", "", "", "", "")
                    Return False
            End Select
            ' if it makes all of these test then it must be a good/ok record ???
            Return True
        End Function

        '***********************************************************************
        Public Shared Function MyCheckValidUse(IndexFlowChart As Int32) As Boolean
            Dim Temp As Int32
            MyTrace(385, "MyCheckValidUse", 684 - 628)

            MyCheckValidUse = False

            ' for now print out all things that are being checked
            'Check if valid index
            If MyCheckIndex_String("FlowChart", IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name) = False Then Exit Function
            'if named
            If Len(FlowChart_TableNamed(IndexFlowChart)) < 1 Then
                MyMsgCtr("MyCheckValidUse", 1164, Str(IndexFlowChart), Str(IndexFlowChart), "", "", "", "", "", "", "")
                Exit Function
            End If
            'use code           
            Select Case LCase(FlowChart_TableCode(IndexFlowChart))
                Case "/use"
                    MyCheckValidUse = Not InvalidUsePath_In_PassedValue(IndexFlowChart, FlowChart_PathLinks_And_CompiledCode(IndexFlowChart))
                Case Else
                    MyMsgCtr("MyCheckValidUse", 1159, FlowChart_TableCode(IndexFlowChart), "", "", "", "", "", "", "", "")
                    Exit Function
            End Select
            ' Checking that ALL iSAMs are indexed to something. (Should also make sure that it returns a match to what it is searching for
            'name
            Temp = FindIndexIniSAMTable("FlowChart", "DontAdd", FlowChart_FileNamed, FlowChart_iSAM_Name, FlowChart_TableNamed(IndexFlowChart))
            If Temp < 1 Then
                MyCheckValidUse = MyCheckIndex_String("FlowChart", IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name)
            End If
            'X1
            Temp = FindIndexIniSAMTable("FlowChart", "DontAdd", FlowChart_FileX1, FlowChart_iSAM_X1, FlowChart_TableX1(IndexFlowChart))
            If Temp < 1 Then
                MyCheckValidUse = MyCheckIndex_String("FlowChart", IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name)
            End If
            'Y1
            Temp = FindIndexIniSAMTable("FlowChart", "DontAdd", FlowChart_FileY1, FlowChart_iSAM_Y1, FlowChart_TableY1(IndexFlowChart))
            If MyCheckIndex_String("FlowChart", IndexFlowChart, FlowChart_FileNamed, FlowChart_iSAM_Name) = False Then
                Exit Function
            End If
            If MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0) = "" Then
                MyMsgCtr("MyCheckValidUse", 1163, FlowChart_TableX2_Rotation(IndexFlowChart).ToString, MyUnEnum(FlowChart_TableX2_Rotation(IndexFlowChart), SymbolScreen.ToolStripDropDownRotation, 0), "", "", "", "", "", "", "")
                Exit Function
            End If
            ' All Else works so it must be OK
            MyCheckValidUse = True
        End Function


        '***********************************************************************
        Public Shared Function MyCheckIndex_long(ByRef MyTable As String, Index As Int32, MyArray() As Int32, ByRef iSAM() As Int32) As Boolean ' returns false if the index is outside the array
            MyTrace(386, "MyCheckIndex_Long", 38 - 6)

            MyCheckIndex_long = False

            If Index < 1 Then
                MyMsgCtr("MyCheckIndex_long", 1158, Index.ToString, "", "", "", "", "", "", "", "")
                Exit Function
            End If
            If Index > TopOfFile(MyTable, MyArray, iSAM) Then
                MyMsgCtr("MyCheckIndex_long", 1256, Str(Index), Str(TopOfFile(MyTable, MyArray, iSAM)), "", "", "", "", "", "", "")
                Exit Function
            End If
            If iSAM(Index) <> 0 And iSAM(Index - 1) = iSAM(Index) Then
                DisplayMyStatus("7845  Index Is wrong  index=" & Index & " iSAM = " & iSAM(Index - 1) & " : " & iSAM(Index))
                Exit Function
            End If
            If iSAM(1) <> 0 And iSAM(1) = iSAM(2) Then
                MyMsgCtr("MyCheckIndex_long", 1169, "", "", "", "", "", "", "", "", "")
                Exit Function
            End If
            If Index = 0 Then
                MyMsgCtr("MyCheckIndex_long", 1170, Index.ToString, iSAM(Index).ToString, "", "", "", "", "", "", "Index < 1")
                Exit Function
            End If
            If iSAM(Index) = 0 Then
                MyMsgCtr("MyCheckIndex_long", 1170, Index.ToString, iSAM(Index).ToString, "", "", "", "", "", "", "iSAM(index) < 1")
                Exit Function
            End If
            MyCheckIndex_long = True
        End Function


        Public Shared Function MyCheckIndex_String(ByRef MyTable As String, Index As int32, ByRef MyArray() As String, ByRef iSAM() As int32) As Boolean
            MyTrace(387, "MyCheckIndex_String", 781 - 751)

            MyCheckIndex_String = False
            If Index < 1 Then
                MyMsgCtr("MyCheckIndex_String", 1158, Index.ToString, "", "", "", "", "", "", "", "")
                Exit Function
            End If
            If Index > TopOfFile(MyTable, MyArray, iSAM) Then
                MyMsgCtr("MyCheckIndex_String", 1256, Str(Index), Str(TopOfFile(MyTable, MyArray, iSAM)), "", "", "", "", "", "", "")
                Exit Function
            End If
            If iSAM(Index) <> 0 And iSAM(Index - 1) = iSAM(Index) Then
                DisplayMyStatus("7845  Index Is wrong  index=" & Index & " iSAM = " & iSAM(Index - 1) & " : " & iSAM(Index))
                Exit Function
            End If
            If iSAM(1) <> 0 And iSAM(1) = iSAM(2) Then
                MyMsgCtr("MyCheckIndex_String", 1169, "", "", "", "", "", "", "", "", "")
                Exit Function
            End If
            If Index = 0 Then
                MyMsgCtr("MyCheckIndex_String", 1170, Index.ToString, iSAM(Index).ToString, "", "", "", "", "", "", "Index < 1")
                Exit Function
            End If
            If iSAM(Index) = 0 Then
                MyMsgCtr("MyCheckIndex_String", 1170, Index.ToString, iSAM(Index).ToString, "", "", "", "", "", "", "iSAM(index) < 1")
                Exit Function
            End If
            MyCheckIndex_String = True
        End Function


        '**********************************************************************
        'replacement string

        Public Shared Function MyReplace(InputString As String, FindingString As String, ReplacementString As String) As String
            MyTrace(388, "MyReplace", 4)

            MyReplace = Strings.Replace(InputString, FindingString, ReplacementString, , , CompareMethod.Text)
        End Function



        Public Shared Function MyShowFlowChartRecord(IndexFlowChart As int32) As String
            MyTrace(389, "MyShowFlowChartRecord", 41 - 25)

            If InvalidIndex(IndexFlowChart, FlowChart_FileNamed) Then
                MyShowFlowChartRecord = "Invalid Index : " & IndexFlowChart
                Exit Function
            End If
            MyShowFlowChartRecord = "Index=" & IndexFlowChart & " "
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " Code =" & FlowChart_TableCode(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " X1 =" & FlowChart_TableX1(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " Y1 =" & FlowChart_TableY1(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " X2_rot =" & FlowChart_TableX2_Rotation(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " Y2_op =" & FlowChart_TableY2_Option(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " DataType =" & FlowChart_Table_DataType(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " Named =" & FlowChart_TableNamed(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " iSAM Name =" & FlowChart_iSAM_Name(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " iSAM x1 =" & FlowChart_iSAM_X1(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " iSAM y1 =" & FlowChart_iSAM_Y1(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " iSAM x2 =" & FlowChart_iSAM_X2(IndexFlowChart)
            MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " iSAM y2 =" & FlowChart_iSAM_Y2(IndexFlowChart)

            Select Case FlowChart_TableCode(IndexFlowChart)
                Case "/use"
                    MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " links  =" & FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart)
                Case "/path"
                    MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " netlinks  =" & NetLinks(My_INT(FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart)))
                Case Else
                    MyShowFlowChartRecord = MyShowFlowChartRecord & vbTab & " Info  =" & FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart)
            End Select
        End Function

        Public Shared Function MyShowNamed(idex As int32) As String
            MyTrace(391, "MyShowNamed", 51 - 36)

            If Named_FileSymbolName(idex) = "" Or IsNothing(Named_FileSymbolName(idex)) Then
                MyShowNamed = Nothing
                Exit Function
            End If

            MyShowNamed = vbTab & "\Index=" & idex & " "
            MyShowNamed = MyShowNamed & vbTab & "/Name = " & Named_FileSymbolName(idex)
            MyShowNamed = MyShowNamed & vbTab & "/Author = " & Named_FileAuthor(idex)
            MyShowNamed = MyShowNamed & vbTab & "/FileName = " & Named_FileNameOfFile(idex)
            MyShowNamed = MyShowNamed & vbTab & "/OpCode = " & Named_FileOpCode(idex)
            MyShowNamed = MyShowNamed & vbTab & "/Indexes = " & Named_FileIndexes(idex)
            MyShowNamed = MyShowNamed & vbTab & "/Version = " & Named_FileVersion(idex)
            MyShowNamed = MyShowNamed & vbTab & "/ProgramText = " & Named_FileProgramText(idex)
            MyShowNamed = MyShowNamed & vbTab & "/Stroke = " & Named_FileStroke(idex)
            MyShowNamed = MyShowNamed & vbTab & "/Syntax = " & Named_FileSyntax(idex)
            MyShowNamed = MyShowNamed & vbTab & "\iSAM = " & Named_File_iSAM(idex)
            MyShowNamed = MyShowNamed & vbTab & "\SyntaxIsam = " & Named_FileSyntax_Isam(idex)
        End Function

        Public Shared Function MyShowSymbolGraphic(Idex As int32) As String
            MyTrace(392, "MyShowSymbolGraphic", 12)

            MyShowSymbolGraphic = vbTab & "/Index=" & Idex & ":"
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\Code = " & Symbol_FileCoded(Idex) & ":" & Symbol_TableCoded_String(Idex)
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\Name = " & Symbol_FileSymbolName(Idex)
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\X1 = " & Symbol_FileX1(Idex)
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\Y1 = " & Symbol_FileY1(Idex)
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\X2_io = " & Symbol_FileX2_io(Idex) & " : " & MyUnEnum(Symbol_TableX2_io(Idex), SymbolScreen.ToolStripDropDownInputOutput, 0)
            '            MyShowSymbolGraphic = MyShowSymbolGraphic & vbtab & "\Y2_dt = " & Symbol_FileY2_dt(Idex) & " : " & MyUnEnum(Symbol_TableY2_dt(Idex), SymbolScreen.ToolStripDropDownButtonPointDataType, 0)
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\Y2_dt = " & Symbol_FileY2_dt(Idex) & " : " & DataType_TableName(FindIndexIniSAMTable("Datatype", "Donotadd", DataType_FileName, DataType_iSAM_, SymbolScreen.ToolStripDropDownDataType.Text))
            MyShowSymbolGraphic = MyShowSymbolGraphic & vbTab & "\Pt = " & Symbol_File_NameOfPoint(Idex)
        End Function

        Public Shared Function MyShowDataTable(Idex As int32) As String
            MyTrace(393, "MyShowDataTable", 9)

            MyShowDataTable = "/Index=" & Idex & " "
            MyShowDataTable = MyShowDataTable & vbTab & "\Name = " & DataType_FileName(Idex)
            MyShowDataTable = MyShowDataTable & vbTab & "\Bytes = " & DataType_FileNumberOfBytes(Idex)
            MyShowDataTable = MyShowDataTable & vbTab & "\Width = " & DataType_FileWidth(Idex)
            MyShowDataTable = MyShowDataTable & vbTab & "\Describtion = " & DataType_FileDescribtion(Idex)
            MyShowDataTable = MyShowDataTable & vbTab & "/DataTypeIndex = " & DataType_FileColorIndex(Idex)
        End Function


        Public Shared Function MakeStatementReplacements(CodeLine As String) As String
            Dim Idex As int32
            Dim A As String
            Dim myarray(256) As String
            MyTrace(394, "MakeStatementReplacements", 147 - 94)

            MakeStatementReplacements = ""
            ' Idex might be counting twice and missing syntax
            Idex = 1
            MyParse(myarray, CodeLine)

            While PrintAbleNull(MyArray(Idex)) <> "_"
                A = MyArray(Idex)
                Select Case ThisIsAWhat(A)
                    Case "ComputerLanguageMultiLine"
                    Case "ComputerLanguageCameFromLastLine"
                    Case "ComputerLanguageComment"
                    Case "ComputerLanguageExtention"
                    Case "ComputerLanguageGoToNextLine"
                    Case "ComputerLanguageMultiLine"
                    Case "ComputerLanguageVariableNameCharacters"
                    Case "CameFromLastLine"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & ComputerLanguageComment() & A)
                    Case "GotoNextLine"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & ComputerLanguageComment() & A)
                    Case "comment" 'Ignore the rest of the line
                        MakeStatementReplacements = Trim(MakeStatementReplacements & ComputerLanguageComment() & A)' Just add a comment
                    Case "Quote"
                        ' Save The First Quote
                        MakeStatementReplacements = Trim(MakeStatementReplacements & A) ' This should be Quote Marks
                    Case "KeyWord", "Function", "Operator"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & " " & A) & " "' put space arount any keyword
                    Case "Alpha"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & MyUniverse.SysGen.RMStart & A & ".value" & myuniverse.sysgen.rmEnd)
                    Case "Number"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & MyUniverse.SysGen.RMStart & A & ".value") & myuniverse.sysgen.rmEnd & " "
                    Case "SpecialCharacter"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & " " & A) & " "
                    Case "Variable"
                        MakeStatementReplacements = Trim(MakeStatementReplacements & MyUniverse.SysGen.RMStart & A & ".name") & myuniverse.sysgen.rmEnd & " "
                    Case "Unknown"
                        Abug(789, "unknown Character Clasifacition", A, ThisIsAWhat(A))
                        MakeStatementReplacements = Trim(MakeStatementReplacements & A)
                    Case Else
                        Abug(929, "program problem", "Did not take care of a ThisIsAWhat", ThisIsAWhat(A))
                        MakeStatementReplacements = Trim(MakeStatementReplacements & " " & A) & " "
                End Select
                ' I need to explain why I did this and am missing a null field?
                Idex += 1
            End While
            If Right(MakeStatementReplacements, Len(FD)) <> FD Then
                MakeStatementReplacements = MakeStatementReplacements & FD
            End If
        End Function



        Public Shared Function MakeStatementSyntax(MyArray() As String) As String
            Dim Idex As int32
            Dim A As String
            Dim Delim As String
            MyTrace(395, "MakeStatementSyntax", 222 - 158)

            MakeStatementSyntax = ""
            ' Idex might be counting twice and missing syntax
            Delim = "" ' Do not start with a comma(or what ever the field delimeter is right now
            Idex = 1
            While PrintAbleNull(MyArray(Idex)) <> "_"
                A = MyArray(Idex)
                Select Case ThisIsAWhat(A)
                    Case "ComputerLanguageMultiLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageMultiLine())
                    Case "ComputerLanguageCameFromLastLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageCameFromLastLine())
                    Case "ComputerLanguageComment"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageComment())
                    Case "ComputerLanguageExtention"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageExtention())
                    Case "ComputerLanguageGoToNextLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageGoToNextLine())
                    Case "ComputerLanguageMultiLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageMultiLine())
                    Case "ComputerLanguageVariableNameCharacters" ' Not so sure about this!!!!!!! ' Possible error
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & ComputerLanguageVariableNameCharacters())


                    Case "GotoNextLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantGoToNextLineSyntax)
                    Case "CameFromLastLine"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantCameFromLastLineSyntax)
                    Case "comment" 'Ignore the rest of the line
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & A)
                    Case "Quote"
                        ' Save The First Quote
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantQuotes)
                    Case "KeyWord", "Operator", "Function"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & A)
                    Case "Alpha"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantAlpha)
                    Case "Number"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantNumber)
                    Case "SpecialCharacter"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantSpecialCharacter)
                    Case "Variable"
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & MyUniverse.SysGen.ConstantVariable)
                    Case "Unknown"
                        Abug(789, "unknown Character Clasifacition", A, ThisIsAWhat(A))
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & A)
                    Case Else
                        Abug(929, "program problem", "Did not take care of a ThisIsAWhat()", ThisIsAWhat(A))
                        MakeStatementSyntax = Trim(MakeStatementSyntax & Delim & A)
                End Select
                ' I need to explain why I did this and am missing a null field?
                'While Right(MakeStatementSyntax, 2) = Delim & Delim
                ' MakeStatementSyntax = Left(MakeStatementSyntax, Len(MakeStatementSyntax) - 1)
                ' End While
                '     While Left(MakeStatementSyntax, 1) = Delim
                '     MakeStatementSyntax = Mid(MakeStatementSyntax, 2, Len(MakeStatementSyntax))
                ' End While
                Idex += 1
                Delim = FD ' Now make everthing seperated witha Field delimeter
            End While
            If Right(MakeStatementSyntax, Len(FD)) <> FD Then
                MakeStatementSyntax = MakeStatementSyntax & FD
            End If
        End Function




        Public Shared Function FindSymbolSyntax(Keyline As String) As int32 ' This will return the Named_File(index) of the matching syntax
            Dim MySyntax As String
            MyTrace(396, "FindSymbolSyntax", 243 - 227)

            MySyntax = Keyline
            MyParse(My_Syntax_Line_Parsed, MySyntax)
            MySyntax = MakeStatementSyntax(My_Syntax_Line_Parsed)
            FindSymbolSyntax = TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
            While FindSymbolSyntax > 0
                AWarning(635, "Comparing -->" & MySyntax & " to symbol " & Named_TableSymbolName(FindSymbolSyntax) & " ", "", "")
                If MySyntax = Named_TableSyntax(FindSymbolSyntax) Then
                    Exit Function
                End If
                FindSymbolSyntax -= 1
            End While
            FindSymbolSyntax = constantMyErrorCode
        End Function

        Public Shared Function FindSymbolSyntax_1(KeyLine As String) As int32 ' assumed that line has been MYparsed
            Dim IndexNamed As int32
            Dim SymbolName As String
            MyTrace(397, "FindSymbolSyntax_1", 76 - 45)

            FindSymbolSyntax_1 = -1 ' Assume that we do not find anything
            SymbolName = Nothing
            MyParse(My_Syntax_Line_Parsed, KeyLine)
            ' search through all of the symbols
            MyMakeArraySizesBigger()
            For IndexNamed = 1 To TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM)
                MyMakeArraySizesBigger()
                ' Get which symbol name for later if match
                SymbolName = Named_TableSymbolName(IndexNamed)
                '                FindSymbolSyntax = IndexNamed 'removed 2020 07 22
                MyParse(My_Code_Line_Parsed, Named_TableSyntax(IndexNamed))
                If MySyntaxCompare() = True Then
                    FindSymbolSyntax_1 = IndexNamed
                    Exit Function
                End If
            Next
            'If here then didn't find a syntax match
            ' Not a bug, it will do this most of the time. Abug(849, "FindSymbolSyntax():", KeyLine, 0)
            FindSymbolSyntax_1 = constantMyErrorCode
        End Function


        Public Shared Function InvalidUsePath_In_PassedValue(IndexFlowChart As int32, Value As String) As Boolean
            Dim X As String
            MyTrace(399, "InvalidUsePath_In_PassedValue", 931 - 9879)

            If FlowChart_FilePathLinks_And_CompiledCode(IndexFlowChart) = Nothing Then
                Return False
            End If

            If MyTrim(FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)) = "" Then
                Return False
            End If

            X = FlowChart_PathLinks_And_CompiledCode(IndexFlowChart)
            If (Value = Nothing Or Value = "") And (X = Nothing Or X = "") Then
                Return False
            End If

            Select Case LCase(FlowChart_TableCode(IndexFlowChart))
                Case "/use"
                    If Value = Nothing Then Return False
                    If Value = "" Then Return False
                    If InStr(Value, "/") > 0 Then
                        Abug(848, IndexFlowChart, Value, 0)
                        'true So this is OK
                        ' NEED TO ALSO CHECK FOR MULTIPLY /programtext WORDS THAT SHOULDN'T BE THERE. (pORGRAM ERROR)
                        Return False ' return false because it is not invalide
                    Else
                        MyMsgCtr("InvalidUsePath_In_PassedValue", 1036, IndexFlowChart.ToString, FlowChart_TableCode(IndexFlowChart), FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), "", "", "", "", "", "")
                        'false
                        Return True ' No Slash so this link is invalid
                    End If
                Case "/path"
                    If InStr(Value, "/") > 0 Then
                        MyMsgCtr("InvalidUsePath_In_PassedValue", 1035, IndexFlowChart.ToString, FlowChart_TableCode(IndexFlowChart), FlowChart_PathLinks_And_CompiledCode(IndexFlowChart), "", "", "", "", "", "")
                        Return True ' This has a slash so it is invalid path
                    Else
                        If InStr(Value, FD) > 0 Or InStr(Value, FD) > 0 Then
                            ' Correct there should not be a slash in a path linking paths together.
                            Return False 'because this path has no slash and a comma so it must be OK
                        Else
                            'if no comma then this is an invalid path link
                            'MyMsgCtr("InvalidUsePath_In_PassedValue", 1034, IndexFlowChart, FlowChart_FileCoded(IndexFlowChart), FlowChart_FileLinks(IndexFlowChart), "", "", "", "", "", "")
                            Return True ' This path is invalid
                        End If
                    End If
                Case "/error"
                    'All Error codes are valid (for now) are valid
                    Return False
                Case "/constant"
                    Return False
                Case Else
                    Return False
            End Select
            Return True ' What Ever else this is it is invalid
        End Function


        Public Shared Function MySyntaxCompare() As Boolean
            ', Mycode_Line() As String, Mysyntax_Line() As String
            Dim ParsedItem, MyErrors As int32
            MyTrace(399, "MySyntaxCompare", 60 - 37)

            MyErrors = 1024
            ' for now stupid comparison test
            ParsedItem = 0
            MySyntaxCompare = True

            While myerrors > 1
                Select Case ThisIsAWhat(My_Syntax_Line_Parsed(ParsedItem))
                    Case "ComputerLanguageMultiLine"
                    Case "ComputerLanguageCameFromLastLine"
                    Case "ComputerLanguageComment"
                    Case "ComputerLanguageExtention"
                    Case "ComputerLanguageGoToNextLine"
                    Case "ComputerLanguageMultiLine"
                    Case "ComputerLanguageVariableNameCharacters"
                    Case "CameFromLastLine"
                        If Not ThisIsACameFromLastLine(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "GotoNextLine"
                        If Not ThisIsAGotoNextLine(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "Comment" ' The rest is all comment 
                        If Not ThisIsAComment(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "KeyWord", "Function", "Operator" 'must match exactly
                        If My_Syntax_Line_Parsed(ParsedItem) <> My_Code_Line_Parsed(ParsedItem) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "SpecialCharacter" 'must match exactly
                        If My_Syntax_Line_Parsed(ParsedItem) <> My_Code_Line_Parsed(ParsedItem) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "Variable"
                        If Not ThisIsAVariableName(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "quote"
                        If Not ThisIsAQuote(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "Alpha"
                        If Not ThisIsAnAlpha(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case "Number"
                        If Not ThisIsANumber(My_Code_Line_Parsed(ParsedItem)) Then
                            MySyntaxCompare = False
                            Exit Function
                        End If
                    Case Nothing ' ran out of syntax to compare to
                        MySyntaxCompare = False
                        Exit Function
                    Case "Unknown" ' dont know what it is but it is not a good suntax
                        'If My_Code_Line_Parsed(ParsedItem)) Then
                        MySyntaxCompare = False
                        Exit Function
                        'End If
                End Select
                ParsedItem += 1
            End While
        End Function

        Public Shared Function MakeUseANDPath(myCodeLine As String, SymbolName As String, IndexSymbol As int32, UseX1 As int32, UseY1 As int32, LineNumber As int32) As int32
            Dim Idex, FCKounter, IndexFlowChart As int32
            Dim x1, y1 As int32
            Dim D As int32 : Dim TempXY As MyPointStructure
            Dim NumberOfPoints As int32
            MyTrace(401, "MakeUseANDPath", 80 - 64)

            If Len(SymbolName) < 2 Then
                SymbolName = MakeNewName("Copy3" & Symbol_TableSymbolName(IndexSymbol), LineNumber)
            End If
            NumberOfPoints = 1
            x1 = MyUniverse.MySymbolPoints(NumberOfPoints).X ' This should be from the symbol !
            y1 = MyUniverse.MySymbolPoints(NumberOfPoints).Y
            'Abug(757, "This is at " & MyUniverse.SymbolPointCount, "x=" & x1, "y=" & y1)

            Idex = AddFlowChartRecord(SymbolName, "/use", UseX1, UseY1, MyEnumValue("default", SymbolScreen.ToolStripDropDownRotation), 0, "", "", LineNumber) 'no datatype, no links
            FCKounter = TopOfFile("FlowChart", FlowChart_FileCoded) - 1
            Idex = 1
            While PrintAbleNull(My_Code_Line_Parsed(Idex)) <> "_"
                FindingMyBugs(10) 'hack Least amount of checking here
                Select Case ThisIsAWhat(My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageCameFromLastLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageComment"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageExtention"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageGoToNextLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "ComputerLanguageVariableNameCharacters"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "CameFromLastLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "GotoNextLine"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "Comment"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "KeyWord", "Function", "Operator"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "Quote"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "Alpha", "Number", "Variable"
                        x1 = MyUniverse.MySymbolPoints(NumberOfPoints).X
                        y1 = MyUniverse.MySymbolPoints(NumberOfPoints).Y
                        TempXY = OtherEndOfNewMadePath(D, UseX1, UseY1, x1, y1)
                        NumberOfPoints += 1
                        FindingMyBugs(10) 'hack Least amount of checking here

                        ' Need to have the line point away from the center of the symbol, not at the center (usex1,usey1) 2020 08 17  "Errored" datatype, since we do not know it yet
                        IndexFlowChart = AddNEWFlowChartRecord(My_VariableName(myCodeLine, Idex, LineNumber), "/Path", TempXY.X, TempXY.Y,
                                                               (UseX1 + x1).ToString,
                                                               (UseY1 + y1).ToString,
                                                               "errored",
                                                               LineNumber) 'MakeNewName("Copy5_" & myCodeLine))
                        UpDateFlowChartLinks(IndexFlowChart, LineNumber)
                        ConnectPath(IndexFlowChart)
                        FindingMyBugs(10) 'hack Least amount of checking here
                        UseY1 += MyUniverse.SysGen.ConstantSymbolCenter ' who knows where it is going to point?
                        If UseY1 > MyUniverse.SysGen.MaxSymbolInYSpacing Then
                            UseY1 = MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                            UseX1 = UseX1 + MyUniverse.SysGen.ConstantSymbolCenter * MyUniverse.SysGen.ConstantSpacingFactor
                        End If
                    Case "SpecialCharacter"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case Nothing
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case "Unknown"
                        AWarning(999, ThisIsAWhat(My_Code_Line_Parsed(Idex)) & " Is ignored", Idex, My_Code_Line_Parsed(Idex))
                    Case Else
                End Select
                Idex += 1
            End While
            Abug(876, "Added /path to a symbol record " & IndexSymbol, "(" & UseX1 & FD & UseY1 & ")-(" & UseX1 + MyUniverse.SysGen.ConstantSymbolCenter * 2 & FD & UseY1 + MyUniverse.SysGen.ConstantSymbolCenter * 2 & ")", 0)
            Return constantMyErrorCode
        End Function


        Public Shared Function CreateFileNameFromSyntax(SyntaxLine As String, LineNumber As int32) As String
            Dim X, Y As String
            Dim I As int32
            MyTrace(402, "CreateFileNameFromSyntax", 537 - 474)

            Y = ""
            X = SyntaxLine
            CreateFileNameFromSyntax = ""
            While Len(X) > 0
                Select Case ThisIsAWhat(X)
                    Case "ComputerLanguageMultiLine"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "ComputerLanguageMultiLine_" : Pop(X, FD)
                    Case "ComputerLanguageCameFromLastLine"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "ComputerLanguageCameFromLastLine_" : Pop(X, FD)
                    Case "ComputerLanguageComment"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case "ComputerLanguageExtention"
                        Y = Pop(X, FD)' Save the extension till last
                    Case "ComputerLanguageGoToNextLine"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "ComputerLanguageGoToNextLine_" : Pop(X, FD)
                    Case "ComputerLanguageVariableNameCharacters"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "ComputerLanguageVariableNameCharacters_" : Pop(X, FD)


                    Case "comment" 'Ignore the rest of the line
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "Comment" : Pop(X, FD)
                    Case "Quote"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "Quote" : Pop(X, FD)
                    Case "CameFromLastLine"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "CameFromLastLine" : Pop(X, FD)
                    Case "GotoNextLine"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & "GotoNextLine" : Pop(X, FD)
                    Case "KeyWord", "Function", "Operator"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case "Alpha"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case "Number"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case "SpecialCharacter"
                        If ThisIsAMarker2(X) > 0 Then
                            CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                        Else
                            CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                        End If
                    Case "Variable"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case "Unknown"
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                    Case Else
                        CreateFileNameFromSyntax = CreateFileNameFromSyntax & Pop(X, FD)
                End Select
            End While

            'remove any special characters from the file name
            For I = 1 To Len(CreateFileNameFromSyntax)
                While ThisIsASpecalCharacter(Mid(CreateFileNameFromSyntax, I, 1)) And PrintAbleNull(Mid(CreateFileNameFromSyntax, I, 1)) <> "_"
                    CreateFileNameFromSyntax = Mid(CreateFileNameFromSyntax, 1, I - 1) & Mid(CreateFileNameFromSyntax, I + 1, Len(CreateFileNameFromSyntax))
                    '2020 0907                    mid(CreateFileNameFromSyntax, I, 1) = "_" ' Over ride any left over special characters with an underscore
                End While
            Next
            If CreateFileNameFromSyntax = "" Or IsNothing(CreateFileNameFromSyntax) Then
                CreateFileNameFromSyntax = Int(Rnd(1) * 1000) & MakeNewName("Symbol6", LineNumber) & ".Symbol"
            Else
                'need to know if it will become a symbol or will become program code
                If Y = "" Then
                    CreateFileNameFromSyntax = CreateFileNameFromSyntax & ".symbol"
                Else
                    CreateFileNameFromSyntax = CreateFileNameFromSyntax & "." & Y
                End If
            End If
        End Function




        Public Shared Function MakeSymbolFromSyntax(COdeLine As String, UseX1 As int32, UseY1 As int32, LineNumber As int32) As int32
            Dim IndexSymbol, IndexFlowChart, IndexNamed, SavedSymbolIndex As int32
            Dim MySymbolName, MyColorName As String
            Dim SyntaxLine As String
            Dim I As int32
            Dim x1, y1 As int32
            Dim D As int32 : Dim TempXY As MyPointStructure
            Dim NumberOfPoints As int32
            MyTrace(403, "MakeSymbolFromSyntax", 10046 - 9984) ' Not sure about this line count

            MakeSymbolFromSyntax = 0 ' named index
            MySymbolName = MakeNewName("Symbol7", LineNumber)
            NumberOfPoints = 1
            FindingMyBugs(10) 'hack Least amount of checking here

            SyntaxLine = ConvertProgramText2Syntax(My_Syntax_Line_Parsed, COdeLine)

            ' 2020 08 06 added to make a named record first
            AddNewNamedRecord(MySymbolName, COdeLine, "nop", "Made with DeCompile", CreateFileNameFromSyntax(SyntaxLine, LineNumber), WhatComputerLanguage(), "FlowChart Decompile", ".01", "", SyntaxLine)
            AddNEWSymbolRecord(MySymbolName, "/Name", 0, 0, "0", "0", My_VariableName(COdeLine, NumberOfPoints, LineNumber), LineNumber) ' COdeLine)' no options for now

            FindingMyBugs(10) 'hack Least amount of checking here
            IndexSymbol = FindInSymbolList(MySymbolName)
            x1 = MyUniverse.MySymbolPoints(NumberOfPoints).X
            y1 = MyUniverse.MySymbolPoints(NumberOfPoints).Y
            AWarning(753, "This is at " & NumberOfPoints, "x=" & x1, "y=" & y1)
            IndexFlowChart = AddFlowChartRecord(MySymbolName, "/use", UseX1, UseY1, MyEnumValue("default", SymbolScreen.ToolStripDropDownRotation), 0, "errored", "", LineNumber)
            I = MyMinMax(0, 0, UBound(My_Code_Line_Parsed))
            MyMsgCtr("MakeSymbolFromSyntax", 1037, MySymbolName, COdeLine, "Index for path =" & IndexSymbol, "", "", "", "", "", My_VariableName(COdeLine, NumberOfPoints, LineNumber))

            FindingMyBugs(10) 'hack Least amount of checking here

            MyParse(My_Code_Line_Parsed, COdeLine)
            SyntaxLine = MakeStatementSyntax(My_Syntax_Line_Parsed)

            ' This should decompile a line of code, add a symbol, and lines and a syntax for it.
            'Idex = TopOfFile("Symbol", Symbol_FileCoded) + 1
            FindingMyBugs(10) 'hack Least amount of checking here
            IndexSymbol = FindInSymbolList(MySymbolName) ' Should Never Happen
            FindingMyBugs(10) 'hack Least amount of checking here
            MyMsgCtr("MakeSymbolFromSyntax", 1010, MakeStatementReplacements(COdeLine), COdeLine, MySymbolName, My_VariableName(COdeLine, NumberOfPoints, LineNumber), IndexSymbol.ToString, IndexNamed.ToString, "", "", "")
            If IndexSymbol < 1 Then
                FindingMyBugs(10) 'hack Least amount of checking here
                IndexSymbol = NewTopOfFile("Symbol", Symbol_FileCoded) '20200629 ' extra??????
                AddNEWSymbolRecord(MySymbolName, "/name", 0, 0, "0", "0", "", LineNumber) 'SyntaxLine) No Options for now ' This is adding a /name that shoule have alreasy been added.
                IndexSymbol = FindInSymbolList(MySymbolName) ' Should Never Happen
            Else
                ' Should not happen, but why are we adding a name record, when we just found a name record?
                FindingMyBugs(10) 'hack Least amount of checking here 'add a bug test for symbol with out a named record
            End If
            SavedSymbolIndex = IndexSymbol
            NumberOfPoints = 0
            I = 1
            While I < UBound(My_Syntax_Line_Parsed)
                '2020 07 28 change ifthenelse to selectcase
                Select Case ThisIsAWhat(My_Syntax_Line_Parsed(I))
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageCameFromLastLine"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageComment"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageExtention"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageGoToNextLine"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageMultiLine"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case "ComputerLanguageVariableNameCharacters"
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                    Case Nothing ' no use continueing with nothing there.
                        I = I'removed exit function
                    Case "Comment" ' We really need to save the comment into Notes
                        I = I
                    Case "keyword", "SpecialCharacter", "Function", "Operator"
                        ' We do not need a point for any keywords
                        I = I
                    Case "Quote", "Variable", "Alpha", "Number", "Unknown", "CameFromLastLine", "GotoNextLine"
                        NumberOfPoints += 1
                        IndexSymbol += 1
                        x1 = MyUniverse.MySymbolPoints(NumberOfPoints).X
                        y1 = MyUniverse.MySymbolPoints(NumberOfPoints).Y
                        AddNEWSymbolRecord(MySymbolName, "/Point", x1, y1, "both", "errored", My_VariableName(COdeLine, NumberOfPoints, LineNumber), LineNumber) ' errored as the data type
                        FindingMyBugs(10) 'hack Least amount of checking here 'hack
                        TempXY = OtherEndOfNewMadePath(D, UseX1, UseY1, x1, y1)
                        IndexFlowChart = AddFlowChartRecord(My_VariableName(COdeLine, NumberOfPoints, LineNumber), "/path", UseX1 + x1, UseY1 + y1, TempXY.X, TempXY.Y, "logic", "", LineNumber)
                        ' Not a bug Abug(751, "This is at " & MyUniverse.SymbolPointCount, "x=" & x1, "y=" & y1)
                        ConnectPath(IndexFlowChart)
                        NumberOfPoints += 1
                    Case Else
                        AWarning(999, ThisIsAWhat(My_Syntax_Line_Parsed(I)), My_Syntax_Line_Parsed(I), I)
                End Select
                I = I + 1
            End While

            'Make everything a cross
            ' Add name (If not already there)
            IndexNamed = AddNewNamedRecord(MySymbolName, COdeLine, "nop", COdeLine, CreateFileNameFromSyntax(SyntaxLine, LineNumber), WhatComputerLanguage(), "FlowChart", "0.0", "?", SyntaxLine)
            GetSelfCorrectingIndexes(MySymbolName)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, MyColorName, LineNumber)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", -MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter.ToString, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, MyColorName, LineNumber)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter.ToString, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, MyColorName, LineNumber)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", MyUniverse.SysGen.ConstantSymbolCenter, -MyUniverse.SysGen.ConstantSymbolCenter, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, MyColorName, LineNumber)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", MyUniverse.SysGen.ConstantSymbolCenter, -MyUniverse.SysGen.ConstantSymbolCenter, (-MyUniverse.SysGen.ConstantSymbolCenter).ToString, MyUniverse.SysGen.ConstantSymbolCenter.ToString, MyColorName, LineNumber)
            MyColorName = Color_FileName(MyMinMax(TopOfFile("Symbol", Symbol_FileCoded) Mod TopOfFile("color", Color_FileName, Color_iSAM_), 1, TopOfFile("Color", Color_FileName, Color_iSAM_)))
            AddNEWSymbolRecord(MySymbolName, "/Line", MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter, MyUniverse.SysGen.ConstantSymbolCenter.ToString, MyUniverse.SysGen.ConstantSymbolCenter.ToString, MyColorName, LineNumber)
            ReSortSymbolList()

            Clear_Screen(SymbolScreen.PictureBox1)
            AddSymbolToDropDown(MySymbolName)
            Application.DoEvents()
            ' Below should redraw the top of the list (providing it is not sorted (Which is is now), if it is, then it has to 
            'be changed to a FindIndexOfComboBoxList.....
            '2020 07 04 SymbolScreen.ToolStripDropDownButtonSynbolNames.SelectedIndex = MyMinMax(Idex, 1, SymbolScreen.ToolStripDropDownButtonSynbolNames.Items.Count - 1)
            SelectInToolStrip(SymbolScreen.ToolStripDropDownSelectSymbol, MySymbolName)
            Application.DoEvents()
            CheckForErrors(IndexFlowChart, IndexNamed, IndexSymbol)
            Return IndexNamed
        End Function


        Public Shared Sub AddSymbolToDropDown(MySymbolName As String)
            Dim I As Int32
            For I = 1 To FlowChartScreen.ToolStripDropDownSelectSymbol.DropDownItems.Count - 1
                If MySymbolName = FlowChartScreen.ToolStripDropDownSelectSymbol.DropDownItems.Item(I).ToString Then
                    Exit Sub ' Do Not Add it again.
                End If
                If MySymbolName = SymbolScreen.ToolStripDropDownSelectSymbol.DropDownItems.Item(I).ToString Then
                    ' This should never happen, but just in case. 
                    Exit Sub ' Do Not Add it again.
                End If
            Next
            'todo Add a check that I am not adding a symbol name twice.
            SymbolScreen.ToolStripDropDownSelectSymbol.DropDownItems.Add(MySymbolName)
            FlowChartScreen.ToolStripDropDownSelectSymbol.DropDownItems.Add(MySymbolName)
        End Sub



        Public Shared Function OtherEndOfNewMadePath(D As int32, Symbolx1 As int32, Symboly1 As int32, Pointx1 As int32, Pointy1 As int32) As MyPointStructure
            MyTrace(404, "OtherEndOfNewMadePath", 6)
            D = MyDirection(FlowChartScreen.PictureBox1, ZeroZero, MyPoint2(Pointx1, Pointy1))
            OtherEndOfNewMadePath.X = Symbolx1 + MyDirections(D, 1, 1) * Pointx1 'myuniverse.sysgen.ConstantSymbolCenter
            OtherEndOfNewMadePath.Y = Symboly1 + MyDirections(D, 1, 2) * Pointy1 'myuniverse.sysgen.ConstantSymbolCenter
        End Function

        Public Shared Function MyQuickNumbersort(ByRef MyTable As String, MyArray_Long() As int32, ByRef iSAM() As int32, minIndex As Integer, maxIndex As Integer) As int32
            Dim med_valueNumber, Med_valueIndex As int32
            Dim hiIndex As Integer
            Dim loIndex As Integer
            Dim index As Integer
            MyTrace(405, "MyQuickNumberSort", 126 - 54)

            MyQuickNumbersort = 0
            If (iSAM(1) <> 0) And (iSAM(1) = iSAM(2)) Then
                MyMsgCtr("MyQuickNumberSort", 1167, iSAM(1).ToString, iSAM(2).ToString, "", "", "", "", "", "", "")
                MyQuickNumbersort = MyQuickNumbersort + MyReSortAll_long(MyTable, MyArray_Long, iSAM)
            End If
            ' If the list has no more than 1 element, it's sorted.
            If minIndex >= maxIndex Then Exit Function

            ' Pick a dividing item.
            index = CInt((maxIndex - minIndex + 1) * Rnd() + minIndex)
            If index <= 0 Then
                MyMsgCtr("MyQuickNumberSort", 1168, index.ToString, "", "", "", "", "", "", "", "")
            End If
            If index <= 0 Then index = 1
            med_valueNumber = MyArray_Long(iSAM(index))
            Med_valueIndex = index

            ' Swap it to the front so we can find it easily.
            'iSAM(index) = iSAM(minIndex)
            SwapNn(MyTable, MyArray_Long, iSAM, index, minIndex)
            MyQuickNumbersort = MyQuickNumbersort + 1
            If MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM) = False Then Exit Function


            ' Move the items smaller than this into the left
            ' half of the list. Move the others into the right.
            loIndex = minIndex
            hiIndex = maxIndex
            Do
                ' Look down from hi for a value < med_value.
                Do While MyArray_Long(iSAM(hiIndex)) >= med_valueNumber
                    hiIndex -= 1 'hiIndex = hiIndex -1
                    If hiIndex <= loIndex Then Exit Do
                Loop
                If hiIndex <= loIndex Then
                    Swap(MyTable, loIndex, Med_valueIndex)
                    MyQuickNumbersort = MyQuickNumbersort + 1
                    MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM)
                    Exit Do
                End If

                ' Swap the lo and hi values.
                SwapNn(MyTable, MyArray_Long, iSAM, loIndex, hiIndex)
                MyQuickNumbersort = MyQuickNumbersort + 1
                MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM)

                loIndex = loIndex + 1
                Do While MyArray_Long(iSAM(loIndex)) < med_valueNumber
                    loIndex = loIndex + 1
                    If loIndex >= hiIndex Then Exit Do
                Loop
                If loIndex >= hiIndex Then
                    loIndex = hiIndex
                    Swap(MyTable, hiIndex, Med_valueIndex)
                    MyQuickNumbersort = MyQuickNumbersort + 1
                    MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM)
                    Exit Do
                End If

                ' Swap the lo and hi values.
                SwapNn(MyTable, MyArray_Long, iSAM, hiIndex, loIndex)
                MyQuickNumbersort = MyQuickNumbersort + 1
                MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM)
            Loop

            ' Sort the two sublists
            MyQuickNumbersort = MyQuickNumbersort + MyQuickNumbersort(MyTable, MyArray_Long, iSAM, minIndex, loIndex - 1)
            MyQuickNumbersort = MyQuickNumbersort + MyQuickNumbersort(MyTable, MyArray_Long, iSAM, loIndex + 1, maxIndex)
            MyCheckIndex_long(MyTable, index, MyArray_Long, iSAM)

        End Function




        Public Shared Function QuickCheckSort(FromWhere As String, ByRef MyArray() As String, ByRef iSAM() As int32, Index As int32) As Integer
            QuickCheckSort = 0
            Exit Function ' make it faster

            MyTrace(406, "QuickCheckSort", 201 - 132)
            CheckThis("QuickCheckSort", 16, MyArray, iSAM, Index)
            If Index = constantMyErrorCode Then ' Index is an error
                Abug(845, FromWhere, Index, 0)
                MyMsgCtr("QuickCheckSort", 1399, Index.ToString, "", "", "", "", "", "", "", FromWhere)
                QuickCheckSort = -1
                Exit Function
            End If
            If Index < 1L Then 'Invalid index
                MyMsgCtr("QuickCheckSort", 1398, Index.ToString, "", "", "", "", "", "", "", FromWhere)
                QuickCheckSort = -2
                Exit Function
            End If
            If Index = 0L Then ' Before my list (which starts at 1, and zero is never used)
                MyMsgCtr("QuickCheckSort", 1400, Index.ToString, "", "", "", "", "", "", "", FromWhere)
                QuickCheckSort = -3
                Exit Function
            End If
            If Index < 1L Or Index > UBound(iSAM) Then ' index is outsize the size of the MyArray
                MyMsgCtr("QuickCheckSort", 1401, Index.ToString, "", "", "", "", "", "", "", FromWhere)
                QuickCheckSort = -4
                Exit Function ' never check an index of zero or below
            End If

            If iSAM(Index) = 0 Then ' The iSAM has never been set, so an error
                Abug(844, Index, iSAM(Index), 0)
                MyMsgCtr("QuickCheckSort", 1377, Index.ToString,
                         iSAM(Index).ToString,
                         MyArray(Index), "", "", "", "", "", FromWhere)
                QuickCheckSort = -5
                Exit Function
            End If

            If iSAM(Index) = iSAM(Index - 1) Then ' duplications ISAMS in the file Must resort all
                MyMsgCtr("QuickCheckSort",
                         1252,
                        (Index - 1).ToString,
                        iSAM(Index - 1).ToString,
                        MyArray(Index - 1),
                        Index.ToString,
                        iSAM(Index).ToString,
                        MyArray(Index),
                        (Index + 1).ToString,
                        iSAM(Index + 1).ToString,
                        MyArray(Index + 1))

                QuickCheckSort = -6
            End If

            If iSAM(Index) = iSAM(Index + 1) Then ' duplications in the file
                MyMsgCtr("QuickCheckSort", 1280,
                    (Index - 1).ToString,
                    iSAM(Index - 1).ToString,
                    MyArray(Index - 1),
                    Index.ToString,
                    iSAM(Index).ToString,
                    MyArray(Index),
                    (Index + 1).ToString,
                    iSAM(Index + 1).ToString,
                    MyArray(Index + 1))

                QuickCheckSort = -7
            End If

            If MyCompared2(MyArray, iSAM, Index - 1, Index) = 1 Then 'MyCompared(MyArray(iSAM(Index - 1)), MyArray(iSAM(Index))) = 1 Then ' first iSAM is higher
                MyMsgCtr("QuickCheckSort", 1395,
                     "{" & Index - 1 & "} " & "(" & iSAM(Index - 1) & ")>" & MyArray(iSAM(Index - 1)) & "<",
                     "{" & Index & "} " & "(" & iSAM(Index) & ")>" & MyArray(iSAM(Index)) & "<",
                     "{" & Index + 1 & "} " & "(" & iSAM(Index + 1) & ")>" & MyArray(iSAM(Index + 1)) & "<",
                     MyCompared1_a(MyArray(iSAM(Index - 1)), MyArray(iSAM(Index))).ToString,
                     MyCompared1_a(MyArray(iSAM(Index)), MyArray(iSAM(Index + 1))).ToString,
                     MyCompared1_a(MyArray(iSAM(Index - 1)), MyArray(iSAM(Index))).ToString, "", "", FromWhere)
                QuickCheckSort = -8
            End If

            If MyCompared2(MyArray, iSAM, Index, Index + 1) = 1 Then 'MyCompared(MyArray(iSAM(Index)), MyArray(iSAM(Index + 1))) = 1 Then ' middle iSAM is lower
                MyMsgCtr("QuickCheckSort", 1396,
                     "{" & Index - 1 & "} " & "(" & iSAM(Index - 1) & ")>" & MyArray(iSAM(Index - 1)) & "<",
                     "{" & Index & "} " & "(" & iSAM(Index) & ")>" & MyArray(iSAM(Index)) & "<",
                     "{" & Index + 1 & "} " & "(" & iSAM(Index + 1) & ")>" & MyArray(iSAM(Index + 1)) & "<",
                     MyCompared1_a(MyArray(iSAM(Index - 1)), MyArray(iSAM(Index))).ToString,
                     MyCompared1_a(MyArray(iSAM(Index)), MyArray(iSAM(Index + 1))).ToString,
                     MyCompared1_a(MyArray(iSAM(Index)), MyArray(iSAM(Index + 1))).ToString, "", "", FromWhere)

                QuickCheckSort = -9
            End If
            ' Can Not Find A Problem at this index
        End Function


        '***********************************************************************

        ' Omit plngLeft & plngRight; they are used internally during recursion
        Public Shared Sub QuickSort3(pvarArray() As Int32, ByVal plngLeft As Int32, ByVal plngRight As Int32)
            'pvararray was variant
            Dim lngFirst As Int32
            Dim lngLast As Int32
            Dim varMid As Int32 'variant
            Dim lngIndex As Int32
            Dim varSwap As Int32 'variant
            Dim a As Int32
            Dim b As Int32
            Dim c As Int32
            MyTrace(407, "QuickSort3", 53 - 9)

            If plngRight = 0 Then
                plngLeft = LBound(pvarArray)
                plngRight = UBound(pvarArray)
            End If
            lngFirst = plngLeft
            lngLast = plngRight
            lngIndex = plngRight - plngLeft + 1
            a = CInt(lngIndex * Rnd()) + plngLeft
            b = CInt(lngIndex * Rnd()) + plngLeft
            c = CInt(lngIndex * Rnd()) + plngLeft
            If pvarArray(a) <= pvarArray(b) And pvarArray(b) <= pvarArray(c) Then
                lngIndex = b
            Else
                If pvarArray(b) <= pvarArray(a) And pvarArray(a) <= pvarArray(c) Then
                    lngIndex = a
                Else
                    lngIndex = c
                End If
            End If
            varMid = pvarArray(lngIndex)
            Do
                Do While pvarArray(lngFirst) < varMid And lngFirst < plngRight
                    lngFirst = lngFirst + 1
                Loop
                Do While varMid < pvarArray(lngLast) And lngLast > plngLeft
                    lngLast -= 1 'lngLast = lngLast -1
                Loop
                If lngFirst <= lngLast Then
                    varSwap = pvarArray(lngFirst)
                    pvarArray(lngFirst) = pvarArray(lngLast)
                    pvarArray(lngLast) = varSwap
                    lngFirst = lngFirst + 1
                    lngLast -= 1 'lngLast = lngLast -1
                End If
            Loop Until lngFirst > lngLast
            If lngLast - plngLeft < plngRight - lngFirst Then
                If plngLeft < lngLast Then QuickSort3(pvarArray, plngLeft, lngLast)
                If lngFirst < plngRight Then QuickSort3(pvarArray, lngFirst, plngRight)
            Else
                If lngFirst < plngRight Then QuickSort3(pvarArray, lngFirst, plngRight)
                If plngLeft < lngLast Then QuickSort3(pvarArray, plngLeft, lngLast)
            End If
        End Sub



        Public Shared Sub HeapSort(pvarArray() As String)
            Dim i As Int32
            Dim iMin As Int32
            Dim iMax As Int32
            Dim varSwap As String
            MyTrace(408, "HeapSort", 375 - 357)

            iMin = LBound(pvarArray)
            iMax = UBound(pvarArray)
            For i = CInt((iMax + iMin) / 2) To iMin Step -1
                Heap1(pvarArray, i, iMin, iMax)
            Next i
            For i = iMax To iMin + 1 Step -1
                varSwap = pvarArray(i)
                pvarArray(i) = pvarArray(iMin)
                pvarArray(iMin) = varSwap
                Heap1(pvarArray, iMin, iMin, i - 1)
            Next i
        End Sub

        Public Shared Sub Heap1(pvarArray() As String, ByVal i As Int32, iMin As Int32, iMax As Int32)
            Dim lngLeaf As Int32
            Dim varSwap As String
            MyTrace(409, "Heap1", 394 - 377)

            Do
                lngLeaf = i + i - (iMin - 1)
                Select Case lngLeaf
                    Case Is > iMax : Exit Do
                    Case Is < iMax : If pvarArray(lngLeaf + 1) > pvarArray(lngLeaf) Then lngLeaf = lngLeaf + 1
                End Select
                If pvarArray(i) > pvarArray(lngLeaf) Then Exit Do
                varSwap = pvarArray(i)
                pvarArray(i) = pvarArray(lngLeaf)
                pvarArray(lngLeaf) = varSwap
                i = lngLeaf
            Loop
        End Sub

        Public Shared Sub MyErrorMessages(Hiding As String, ErrorNumber As int32, Severity As String, Message As String)
            MyTrace(411, "MyErrorMessages", 411 - 396)

            Select Case LCase(Severity)
                Case "wrong"
                Case "information"
                Case "warning"
                Case "error"
                Case "display"
                Case "status"
                Case Else
                    Abug(842, Severity, 0, 0)
                    MsgBox("Invalid Message Severity in Error Message", MsgBoxStyle.Information, ErrorNumber & FD & Severity & " : " & Message & vbCrLf & "Must be :information warning wrong Error checking display")
            End Select
            OptionScreen.ComboBoxDebug.Items.Add(ErrorNumber & FD & Severity & FD & Message)
            BitSet(ErrorNumber, Hiding)
        End Sub


        Public Shared Function ReBubbleSortAll(ByRef MyTable As String, ByRef MyArray() As String, ByRef iSAM() As int32) As int32
            Dim Index, Jdex As int32
            MyTrace(412, "ReBubbleSortAll", 24 - 16)

            ReBubbleSortAll = 0
            Jdex = TopOfFile(MyTable, MyArray, iSAM)
            For Index = 1 To Jdex
                ReBubbleSortAll += (MyReSort(MyTable, MyArray, iSAM, Index))
            Next
            MyUniverse.MyCheatSheet.ColorsSorted = 0
        End Function



        Public Shared Sub Not_Used_ReBubbleSortAll(ByRef MyTable As String, MyArrayLong() As int32, ByRef iSAM() As int32)
            Dim Index, Jdex As int32
            MyTrace(413, "Not_Used_ReBubbleSortAll", 36 - 28)

            Jdex = TopOfFile(MyTable, MyArrayLong, iSAM)
            For Index = 1 To Jdex
                ReBubbleSortAt(MyTable, MyArrayLong, iSAM, Index)
            Next
        End Sub

        'Numbers
        Public Shared Function ReBubbleSortAt(ByRef MyTable As String, MyArrayLong() As int32, ByRef iSAM() As int32, IndexInput As int32) As int32
            Dim Flag, Index As int32
            MyTrace(414, "ReBubbleSortAt", 66 - 39)

            ReBubbleSortAt = 0
            Index = IndexInput
            While Index > 2 And iSAM(Index) = 0
                Index -= 1
            End While

            Flag = 1
            While Flag > 0
                Flag = 0
                If iSAM(Index) <> 0 Then
                    While Index > 2 And MyCompared2(MyArrayLong, iSAM, Index - 1, Index) > 0 'MyCompared(MyArrayLong(iSAM(Index - 1)), MyArrayLong(iSAM(Index))) > 0
                        MyMsgCtr("ReBubbleSortAt", 1016, Str(Index - 1), Str(iSAM(Index - 1)),
                                 MyArrayLong(iSAM(Index - 1)).ToString, Str(Index), Str(iSAM(Index)),
                                 MyArrayLong(iSAM(Index)).ToString, "", "", "")
                        SwapNn(MyTable, MyArrayLong, iSAM, Index - 1, Index)
                        ReBubbleSortAt = ReBubbleSortAt + 1
                        If iSAM(Index) <> 0 And iSAM(Index - 1) = iSAM(Index) Then DisplayMyStatus("8184 Index Is wrong  index=" & Index & " iSAM = " & iSAM(Index - 1) & " : " & iSAM(Index))
                        If Flag > 1 Then
                            MyMsgCtr("ReBubbleSortAt", 1020,
                                     MyArrayLong(iSAM(Index - 1)).ToString,
                                     MyArrayLong(iSAM(Index)).ToString,
                                     (Index - 1).ToString,
                                     Index.ToString,
                                     iSAM(Index - 1).ToString,
                                     iSAM(Index).ToString, "", "", "")
                        End If
                        Index -= 1
                        Flag += 1
                    End While
                End If
                Index -= 1
            End While
        End Function

        '*****************************************************
        ' Check if this is something, nothing, or flagged as nothing ('_')
        Public Shared Function IsNullOrNothing(StringA As String) As Boolean
            IsNullOrNothing = False
            If IsNothing(StringA) Then
                IsNullOrNothing = True
            ElseIf StringA = "" Then
                IsNullOrNothing = True
            ElseIf StringA = "_" Then
                IsNullOrNothing = True
            End If
        End Function


        Public Shared Function PointMatch(X1 As int32, Y1 As int32, X2 As int32, Y2 As int32) As Boolean
            MyTrace(416, "PointMatch", 9)

            If X1 = X2 Then
                If Y1 = Y2 Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Shared Sub CombineNetLinksInto(IdexNetLinks As int32, JdexNetLinks As int32)
            Dim I As int32
            Dim Temp As String
            MyTrace(417, "CombineNetLinksInto", 21)

            If IdexNetLinks = JdexNetLinks Then Exit Sub

            'Check the links of the two nets
            If NetNames(IdexNetLinks) <> NetNames(JdexNetLinks) Then
                Temp = CombineNames(NetNames(IdexNetLinks), NetNames(JdexNetLinks))
            Else
                Temp = NetNames(IdexNetLinks) ' since they match, NetLinks(JdexNetLinks))
            End If

            'The nets in this list is in Temp
            netlinks(JdexNetLinks, NetLinks(IdexNetLinks) & NetLinks(JdexNetLinks)) 'Combine the two nets
            CleanListOfNetLinks(IdexNetLinks)

            For I = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If FlowChart_TableCode(I) = "/path" Then
                    Temp = FlowChart_PathLinks_And_CompiledCode(I)
                    While Left(Temp, 1) = ","
                        Temp = Mid(Temp, 2, Len(Temp))
                    End While
                    If PopValue(Temp) = IdexNetLinks Then
                        ' Combining the two nets, and redirecting the Indexes to the new combined 
                        FlowChart_PathLinks_And_CompiledCode(I, NetLinks(JdexNetLinks))
                    End If
                End If
            Next
        End Sub


        Public Shared Function CombineNames(A As String, B As String) As String
            MyTrace(418, "CombineNames", 9)

            If InStr(A, "_&_" & B) > 0 Then 'is A&B already there?
                Return A
            ElseIf InStr(B, "_&_" & A) > 0 Then 'is B&A already there
                Return B
            End If
            Return A & "_&_" & B
        End Function


        Public Shared Sub ConnectPaths(Index1FlowChart As int32, Index2FlowChart As int32)
            Dim I As int32 ' look through all of the NetLinks
            Dim PutIt1, Putit2 As int32
            MyTrace(419, "ConnectPaths", 390 - 337)

            If Index1FlowChart = Index2FlowChart Then Exit Sub
            PutIt1 = 0
            Putit2 = 0
            For I = LBound(NetLinks_File) To UBound(NetLinks_File)
                If InStr(NetLinks(I), FD & Index1FlowChart & FD) > 0 Then
                    PutIt1 = I
                End If
                If InStr(NetLinks(I), FD & Index2FlowChart & FD) > 0 Then
                    Putit2 = I
                End If
                If PutIt1 <> 0 And Putit2 <> 0 Then Exit For
            Next

            'Everything is OK
            If PutIt1 <> 0 And Putit2 <> 0 And PutIt1 = Putit2 Then
                Exit Sub
            End If



            'One not there so add to two
            If PutIt1 = 0 And Putit2 <> 0 Then
                netlinks(Putit2, NetLinks(Putit2) & FD & Index1FlowChart & FD)
                CleanListOfNetLinks(Putit2)
                Exit Sub
            End If
            'Two not there so add to one
            If Putit2 = 0 And PutIt1 <> 0 Then
                netlinks(PutIt1, NetLinks(PutIt1) & FD & Index2FlowChart & FD)
                CleanListOfNetLinks(PutIt1)
                Exit Sub
            End If

            ' If neither one or two is there then add a new netlinks
            If PutIt1 = 0 And Putit2 = 0 Then
                I = UBound(NetLinks_File) + 1
                ReDim Preserve NetLinks_File(I)
                ReDim Preserve NetNames_File(I)
                netlinks(I, FD & Index1FlowChart & FD & Index2FlowChart & FD)
                Exit Sub
            End If

            ' Check if they are in different ones, not and fix them.
            If PutIt1 <> 0 And Putit2 <> 0 And PutIt1 <> Putit2 Then
                ' We have to connect the two nets together. 
                CombineNetLinksInto(PutIt1, Putit2)
            Else
            End If


        End Sub

        Public Shared Function ConnectPath(IndexFlowChart As int32) As int32 ' Returns the NetIndex that it is in, and cleans up (ignores what it say's it is in for now)
            Dim Connected2, IndexNetLinks1, IndexNetLinks2 As int32
            MyTrace(421, "ConnectPath", 412 - 392)

            Connected2 = PathConnectes2("/path", IndexFlowChart) ' get what else it is connected to
            IndexNetLinks1 = FindInNetLinks(IndexFlowChart) ' Get if this is already there
            IndexNetLinks2 = FindInNetLinks(Connected2) ' Get if this is already there
            If IndexNetLinks1 > 0 Then ' Found the nets that index FlowChart is in
                If IndexNetLinks2 > 0 Then ' also found that it is in this network
                    CombineNetLinksinto(IndexNetLinks1, IndexNetLinks2) ' combine them together and change all of the FlowChart links to point to the new
                    Return IndexNetLinks2
                End If
                'add into indexnetlinks1 (since 1 & 2 are together
                FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, NetLinks(IndexNetLinks1)) ' add to that net
                ' Its already in this net ''''''''NetLinks(IndexNetLinks1) = NetLinks(IndexNetLinks1) & IndexFlowChart & FD ' Add to the end of this net
            ElseIf IndexNetLinks2 > 0 Then ' We did not find the indexFlowChart in nets but did find a link of what it is connected to
                FlowChart_PathLinks_And_CompiledCode(IndexFlowChart, NetLinks(IndexNetLinks2)) ' add to that net
                netlinks(IndexNetLinks2, NetLinks(IndexNetLinks2) & IndexFlowChart & FD) ' Add to the end of this net
            End If
            Return 0
        End Function



        Public Shared Function PathConnectes2(Connectes2 As String, Idex As int32) As int32 ' return to what other FlowChart it connect to (either /use or /path)
            Dim I, Jdex, Kdex, MyTopOfFile, X1, Y1 As int32
            MyTrace(422, "PathConnectes2", 474 - 416)

            If Idex < 1 Then Return constantMyErrorCode
            For I = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                If I = Idex Then
                    ' We do not check our selfs
                Else
                    Select Case (FlowChart_TableCode(I))
                        Case "/error"'ignore
                        Case "/orgin"'ignore
                        Case "/use"
                            If Connectes2 = "/use" Then
                                GetSelfCorrectingIndexes(FlowChart_TableNamed(I)) ' make sure the Indexes is updated
                                ' This is not finding the name ERROR
                                Jdex = FindIndexIniSAMTable("named", "Do Not Add", Named_FileSymbolName, Named_File_iSAM, FlowChart_TableNamed(I)) ' Find the name then
                                If Jdex > 0 Then
                                    Kdex = Named_TableIndexes(Jdex) ' Get the shortcut to the start of the name
                                    If Kdex > 0 Then
                                        Kdex = Kdex + 1 ' move over the name
                                        MyTopOfFile = TopOfFile("symbols", Symbol_FileCoded) ' For the last symbol in the list
                                        While Symbol_TableCoded_String(Kdex) <> "/name" And Kdex <= MyTopOfFile
                                            Select Case Symbol_TableCoded_String(Kdex)
                                                Case Nothing
                                                    Exit While' Must be at the end of the list (last symbol)
                                                Case "/unknown"'ignore 
                                                Case "/line" ' ignore lines
                                                Case "/point"
                                                    X1 = FlowChart_TableX1(I) + Symbol_TableX1(Kdex)
                                                    Y1 = FlowChart_TableY1(I) + Symbol_TableY1(Kdex)

                                                    If PointMatch(FlowChart_TableX1(Idex), FlowChart_TableY1(Idex), X1, Y1) Then Return I
                                                    If PointMatch(FlowChart_TableX2_Rotation(Idex), FlowChart_TableY2_Option(Idex), X1, Y1) Then Return I

                                                Case Else
                                                    AWarning(699, "Should have programmed for ", Symbol_TableCoded_String(Kdex), Kdex)
                                                    Exit While
                                            End Select
                                            Kdex += 1 ' Try next
                                        End While
                                    End If
                                Else
                                    Abug(634, "Symbol not in short cut", I, Idex & ":" & Jdex & ":" & Kdex)
                                End If
                            End If
                        Case "/path"
                            If Connectes2 = "/path" Then
                                ' Check Points
                                If PointMatch(FlowChart_TableX1(Idex), FlowChart_TableY1(Idex), FlowChart_TableX1(I), FlowChart_TableY1(I)) Then Return I
                                If PointMatch(FlowChart_TableX1(Idex), FlowChart_TableY1(Idex), FlowChart_TableX2_Rotation(I), FlowChart_TableY2_Option(I)) Then Return I
                                If PointMatch(FlowChart_TableX2_Rotation(Idex), FlowChart_TableY2_Option(Idex), FlowChart_TableX1(I), FlowChart_TableY1(I)) Then Return I
                                If PointMatch(FlowChart_TableX2_Rotation(Idex), FlowChart_TableY2_Option(Idex), FlowChart_TableX2_Rotation(I), FlowChart_TableY2_Option(I)) Then Return I
                            End If
                    End Select
                End If
            Next
            Return 0 ' not connected anywhere
        End Function




        'MyCheckIndexs(IndexFlowChart, IndexSymbol, IndexNamed, indexcolor, indexdatatype)
        Public Shared Sub MyCheckIndexs(IndexFlowChart As Int32, IndexSymbol As Int32, IndexNamed As Int32, IndexColor As Int32, IndexDataType As Int32)
            MyTrace(423, "MyCheckIndexs", 10693 - 10598)

            If IndexSymbol > TopOfFile("Symbol", Symbol_FileCoded) Then MyMsgCtr("MyCheckIndexs 2", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")

            If IndexNamed > TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) Then MyMsgCtr("MyCheckIndexs 3", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")


            If IndexColor > TopOfFile("Color", Color_FileName, Color_iSAM_) Then MyMsgCtr("MyCheckIndexs 4", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")


            If IndexDataType > TopOfFile("DataType", DataType_FileName, DataType_iSAM_) Then MyMsgCtr("MyCheckIndexs 5", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")
            If IndexFlowChart > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")

            'Also Check these
            If FlowChart_iSAM_X1(IndexFlowChart) > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")
            If FlowChart_iSAM_Y1(IndexFlowChart) > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")
            If FlowChart_iSAM_X2(IndexFlowChart) > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")
            If FlowChart_iSAM_Y2(IndexFlowChart) > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")
            If FlowChart_iSAM_Name(IndexFlowChart) > TopOfFile("FlowChart", FlowChart_FileCoded) Then MyMsgCtr("MyCheckIndexs 1", 1433,
                    IndexFlowChart & ":" & TopOfFile("FlowChart", FlowChart_FileCoded) & vbCrLf,
                    IndexSymbol & ":" & TopOfFile("Symbol", Symbol_FileCoded) & vbCrLf,
                    IndexNamed & ":" & TopOfFile("Named", Named_FileSymbolName, Named_File_iSAM) & vbCrLf,
                    IndexColor & ":" & TopOfFile("Color", Color_FileName, Color_iSAM_) & vbCrLf,
                    IndexDataType & ":" & TopOfFile("DataType", DataType_FileName, DataType_iSAM_) & vbCrLf, "", "", "", "")

        End Sub



        Public Shared Function AWarning(BugNumber As Int32, AA As Object, BB As Object, CC As Object) As Int32
            Dim A, B, C As String
            'MyTrace(424, "AWarning", 6)
            If IsNothing(AA) Then
                A = "?"
            Else
                A = AA.ToString
            End If
            If IsNothing(BB) Then
                B = "?"
            Else
                B = BB.ToString
            End If
            If IsNothing(CC) Then
                C = "?"
            Else
                C = CC.ToString
            End If
            AWarning = 0 ' Where all of the errors are added from here
            Dump3(CStr(BugNumber) & vbTab & A.ToString & vbTab & B.ToString & vbTab & C.ToString & ".")
        End Function



        Public Shared Function Abug(BugNumber As Int32, a As Object, b As Object, c As Object) As Int32
            Dim AA, BB, CC As String
            Abug = 1 ' Where all of the errors are added from here
            MyUniverse.MyCheatSheet.BugsCounted += 1

            If IsNothing(a) Then AA = " (nil) " Else AA = a.ToString
            If IsNothing(b) Then BB = " (nil) " Else BB = b.ToString
            If IsNothing(c) Then CC = " (nil) " Else CC = c.ToString
            Dump3(CStr(BugNumber) & vbTab & AA & vbTab & BB & vbTab & CC & ".")
        End Function


        Public Shared Sub RepairNamedIndexesBug(IndexNamed As Int32) ' This is to fix named table when the symbol table is re-sorted/inserted/deleted
            Dim IndexSymbol As Int32
            MyTrace(426, "RepairNamedIndexesBug", 603 - 577)

            If IndexNamed = 1 And IsNothing(Named_FileSymbolName(1)) Then
                Exit Sub
            End If
            IndexSymbol = Named_FileIndexes(IndexNamed)
            If IndexSymbol = 1 And IsNothing(Symbol_FileSymbolName(1)) Then
                Exit Sub
            End If
            If InvalidIndex(IndexNamed, Named_FileSymbolName, Named_File_iSAM) Then
                Exit Sub
            End If
            If IndexSymbol < 1 Then ' update it if you can
                GetSelfCorrectingIndexes(Named_TableSymbolName(IndexNamed))
                Exit Sub
            End If
            If Named_FileSymbolName(IndexNamed) <> Symbol_FileSymbolName(IndexSymbol) Then
                GetSelfCorrectingIndexes(Named_TableSymbolName(IndexNamed))
                Exit Sub
            End If
            If Named_FileIndexes(IndexNamed) <> IndexSymbol Then
                GetSelfCorrectingIndexes(Named_TableSymbolName(IndexNamed))
            End If
            CheckForErrors(0, IndexNamed, IndexSymbol)
        End Sub

        '*********************************************************************************
        'Part of finding internal bugs that I think should never happen (See FindingMyBugs)
        Public Shared Function FindingSymbolOutOfXYSizeBugs(Idex As Int32) As Int32 ' Checks symbol record Idex if it is more then the allowed size. (if /point or /line)
            Dim NumberOfNames, NumberOfPoints, NumberOfLines As Int32
            MyTrace(427, "FindingSymbolOutOfXYSizeBugs", 635 - 610)

            FindingSymbolOutOfXYSizeBugs = 0
            Exit Function

            NumberOfNames = 0
            NumberOfPoints = 0
            NumberOfLines = 0
            Select Case Symbol_TableCoded_String(Idex)
                Case "/name"
                    NumberOfNames += 1
                Case "/line"
                    If MyABS(Symbol_FileX1(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(834, "FindingMyBugs: The x1 line symbol is out of bounds at ", Idex, Symbol_FileX1(Idex))
                    If MyABS(Symbol_FileY1(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(833, "FindingMyBugs: The y1 line symbol is out of bounds at ", Idex, Symbol_FileY1(Idex))
                    If MyABS(Symbol_FileX2_io(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(832, "FindingMyBugs: The x2 line symbol is out of bounds at ", Idex, Symbol_FileX2_io(Idex))
                    If MyABS(Symbol_FileY2_dt(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(831, "FindingMyBugs: The y2 line symbol is out of bounds at ", Idex, Symbol_FileY2_dt(Idex))
                    NumberOfLines += 1
                Case "/point"
                    If MyABS(Symbol_FileX1(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(829, "FindingMyBugs: The x1 point symbol is out of bounds at ", Idex, Symbol_FileX1(Idex))
                    If MyABS(Symbol_FileY1(Idex)) > MyUniverse.SysGen.ConstantSymbolCenter Then FindingSymbolOutOfXYSizeBugs += Abug(828, "FindingMyBugs: The y1 point symbol is out of bounds at ", Idex, Symbol_FileY1(Idex))
                    NumberOfPoints += 1
                Case "/unknown"
                Case Else
                    FindingSymbolOutOfXYSizeBugs += Abug(827, "FindingMyBugs: Invalid code inthe symbol table", Symbol_TableCoded_String(Idex), Symbol_TableCoded_String(Idex))
            End Select
        End Function


        Public Shared Sub Dump3(ErrorMessage As String) ' Dump every possible problems to a saved fdile (abug & Awarning)
            If SplashScreen.Visible = True Then 'hack texting to make sure that the checkedlist box is valid
            ElseIf OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(30) = True Then
                System.IO.File.AppendAllText(MyUniverse.SysGen.outputfilename3,
                                             Now() & " " & vbTab & ErrorMessage & vbTab & "Errors = " & MyUniverse.MyCheatSheet.BugsCounted & vbCrLf)
            End If
        End Sub



        Public Shared Sub Dump1() ' Dumping only the symbol table for debuging ' extra
            Dim Idex As Int32
            Dim Output As String
            MyTrace(428, "Dump1", 662 - 638)

            If Dir(MyUniverse.SysGen.outputfilename1) = "" Then ' need to create the file if it does not exist then you can ...
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(MyUniverse.SysGen.outputfilename1)
                End Using
            Else
                Kill(MyUniverse.SysGen.outputfilename1)
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(MyUniverse.SysGen.outputfilename1)
                End Using
            End If

            Using Writer As System.IO.FileStream = System.IO.File.OpenWrite(MyUniverse.SysGen.outputfilename1)
                For Idex = 1 To NewTopOfFile("symbol", Symbol_FileCoded)
                    Output = MyShowSymbolGraphic(Idex)
                    MyWrite(Idex, Writer, Output)
                Next Idex

                Writer.Close()
            End Using

        End Sub


        Public Shared Sub Dump2(MyReason As String)
            Dim Idex As Int32
            Dim Output As String
            MyTrace(431, "Dump2", 778 - 692)

            For Idex = 1 To TopOfFile("FlowChart", FlowChart_FileCoded)
                UpDateFlowChartLinks(Idex, 0)
            Next

            If Dir(MyUniverse.SysGen.outputfilename2) = "" Then ' need to create the file if it does not exist then you can ...
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(MyUniverse.SysGen.outputfilename2)
                End Using
            Else
                'System.IO.File.Create(myuniverse.sysgen.outputfilename)
                Kill(MyUniverse.SysGen.outputfilename2)
                Using Writer As System.IO.StreamWriter = System.IO.File.CreateText(MyUniverse.SysGen.outputfilename2)
                End Using
            End If
            Using Writer As System.IO.FileStream = System.IO.File.OpenWrite(MyUniverse.SysGen.outputfilename2)
                MyWrite(0, Writer, MyReason)

                '*************************************************************
                MyWrite(Idex, Writer, "FlowChart Info")
                For Idex = 1 To FlowChart_TableCount
                    Output = MyShowFlowChartRecord(Idex)
                    MyWrite(Idex, Writer, Output)
                Next
                '*************************************************************
                MyWrite(Idex, Writer, "Named Symbol Info")
                For Idex = 1 To Named_TableCount
                    Output = "Symbol Named " & MyShowNamed(Idex)
                    MyWrite(Idex, Writer, Output)
                Next Idex
                '*************************************************************
                MyWrite(Idex, Writer, "Symbol Graphics")
                For Idex = 1 To NewTopOfFile("symbol", Symbol_FileCoded)
                    Output = "Symbol Graphics " & MyShowSymbolGraphic(Idex)
                    MyWrite(Idex, Writer, Output)
                Next Idex
                '*************************************************************

                MyWrite(Idex, Writer, "Data Type")
                For Idex = 1 To DataType_TableCount
                    Output = "DataTypes " & MyShowDataTable(Idex)
                    MyWrite(Idex, Writer, Output)
                Next Idex
                '*************************************************************
                MyWrite(Idex, Writer, "Colors")
                For Idex = 1 To Color_TableCount
                    Output = "Colors "
                    If IsNothing(Color_FileName(Idex)) Then
                    Else
                        Output = Output & vbTab & "name = " & Color_FileName(Idex)
                        Output = Output & vbTab & " :Alpha,Red,Green,Blue = " & Color_FileAlpha(Idex) & FD & Color_FileRed(Idex) & FD & Color_FileGreen(Idex) & FD & Color_FileBlue(Idex)
                        Output = Output & vbTab & " :start end cap=" & Color_FileStartCap(Idex) & FD & Color_FileEndCap(Idex)
                        Output = Output & vbTab & " :style = " & Color_FileStyle(Idex)
                        MyWrite(Idex, Writer, Output)
                    End If
                Next Idex
                '*************************************************************
                MyWrite(Idex, Writer, "Key words")
                For Idex = LBound(Language_KeyWords) To UBound(Language_KeyWords)
                    MyWrite(Idex, Writer, "/Keyword=" & Language_KeyWords(Idex))
                Next Idex
                '*************************************************************
                MyWrite(Idex, Writer, "Operator character(s)")
                For Idex = LBound(Language_Operators) To UBound(Language_Operators)
                    MyWrite(Idex, Writer, "/Operator=" & Language_Operators(Idex))
                Next Idex
                '*************************************************************
                MyWrite(Idex, Writer, "Function words")
                For Idex = LBound(Language_Functions) To UBound(Language_Functions)
                    MyWrite(Idex, Writer, "/Function=" & Language_Functions(Idex))
                Next Idex

                For Idex = LBound(TraceWords) To UBound(TraceWords)
                    If IsNothing(TraceWords(Idex)) Then
                    Else
                        ' The abs is there so that it will never fail if longer than x(40) characters
                        MyWrite(Idex, Writer, "Routine = " & vbTab & TraceWords(Idex) & vbTab & " ran " & vbTab & TraceCounts(Idex) & vbTab & " times")
                    End If
                Next

                Writer.Close()
            End Using

        End Sub


        '***********************************************
        'todo need to add the button rules here
        'This is to clear the message text 
        Public Shared Function ButtonStarted(ButtonName As String) As Boolean ' Make sure that no more than X number of buttons deep (or stack over flow)
            Dim DebugTemp As Int32
            DebugTemp = MyUniverse.SysGen.NumberOfButtonsActive

            If MyUniverse.SysGen.NumberOfButtonsActive > 8 Then
                'todo turn off all button rules
                Return False ' can not do any more buttons
            End If

            MyUniverse.SysGen.NumberOfButtonsActive += 1
            Return True
        End Function

        Public Shared Function ButtonFinished(ButtonName As String) As Boolean  ' Make sure that no more than X number of buttons deep (or stack over flow)
            Dim DebugTemp As Int32
            MyUniverse.SysGen.NumberOfButtonsActive -= 1
            DebugTemp = MyUniverse.SysGen.NumberOfButtonsActive
            If MyUniverse.SysGen.NumberOfButtonsActive < 0 Then
                'todo needs to add to the dump the button list of buttons currently active.
                MsgBox("Program data error Button pushes counted wrongly needs to report what report", MsgBoxStyle.OkOnly)
            End If
            'reset all button rules if all turned off
            Return True ' toto for now All finished buttons worked and stopped
        End Function


        Public Shared Sub DisplayStatusOnly(StatusBox As String, ButtonName As String)
            StatusBox = ButtonName
            Application.DoEvents()
        End Sub


        'If the passed index is zero, then those function can not/are not checked
        Public Shared Sub CheckForErrors(indexFlowChart As int32, IndexNamed As int32, IndexSymbol As int32) ' Checks for common errors
            Dim Adex, Bdex, Cdex As int32
            Dim I, J, K As int32
            Dim DataType, PointName, Syntax As String
            Dim MyXY As MyPointStructure
            Dim MyArray(256) As String
            MyTrace(432, "CheckForErrors", 615 - 493)

            Adex = 0
            Bdex = 0
            Cdex = 0

            If IndexSymbol > 1 Then
                Cdex = IndexSymbol
                While Cdex > 0 And Symbol_TableCoded_String(Cdex) <> "/name"
                    Cdex -= 1 ' back up to the nead of the symbol
                End While
                'Check that the symbol is is the named_ name
                If IndexNamed > 0 Then
                    If Named_TableSymbolName(IndexNamed) <> Symbol_TableSymbolName(Cdex) Then
                        Abug(999, "Named and Symbol indexs are messed up ", IndexNamed & ":" & IndexSymbol, Named_TableSymbolName(IndexNamed) & " : " & Symbol_TableSymbolName(Cdex))
                        Bdex = IndexNamed
                    End If
                End If

                Cdex += 1 ' move off of the name
                While Cdex < TopOfFile("symbol", Symbol_FileCoded) And Symbol_TableCoded_String(Cdex) <> "/name"
                    If Symbol_TableCoded_String(Cdex) = "/point" Then
                        If Symbol_Table_NameOfPoint(Cdex) = "CameFrom" Then
                            Adex = Adex And 2
                        End If
                        If Symbol_Table_NameOfPoint(Cdex) = "GotoNextLine" Then
                            Adex = Adex And 4
                        End If
                        '1010 All Points have a valid Datatype
                        J = Symbol_TableY2_dt(Cdex)
                        'DataType = MyUnEnum(J, SymbolScreen.ToolStripDropDownButtonPointDataType, 0)
                        DataType = DataType_FileName(J)

                        I = FindIndexIniSAMTable("Datatype", "Donotadd", DataType_FileName, DataType_iSAM_, DataType)
                        If I = constantMyErrorCode Then
                            Abug(999, "Invalid Datatype in Symbol ", DataType, J)
                            MyFlowChartErrors(1010, 0, 0, IndexSymbol, " Symbol " & FindSymbolName(IndexSymbol))
                            '1011 All Datatype have a valid Color
                        ElseIf I >= 0 Then
                            J = FindIndexIniSAMTable("Color", "Donotadd", Color_FileName, Color_iSAM_, DataType_Color(I))
                            If J = constantMyErrorCode Then
                                Abug(999, "invalid Color for Datatype ", DataType, DataType_Color(I))
                                MyFlowChartErrors(1011, 0, 0, IndexSymbol, " DataType " & DataType)
                            End If
                        End If
                        'not tested for yet
                        '1012 All Colors are valid (in microsoft, they can only be the assigned colors, and are 'switched if wrong) ????????????????????




                        '1013 All /point names are in either the ProgramText or the Syntax
                        PointName = Symbol_File_NameOfPoint(Cdex)




                        ' We need a better check for what this should be checking 2020 09 13
                        If InStr(Named_TableProgramText(IndexNamed), MyUniverse.SysGen.RMStart & Symbol_File_NameOfPoint(Cdex) & ".") = 0 Then
                            AWarning(999, " Variable Not found in program code text ", Named_TableProgramText(IndexNamed), MyUniverse.SysGen.RMStart & Symbol_File_NameOfPoint(Cdex) & ".")
                            MyFlowChartErrors(1013, 0, 0, Cdex, " Symbol " & FindSymbolName(IndexSymbol))
                            Named_TableProgramText(IndexNamed, Named_TableProgramText(IndexNamed) & ComputerLanguageMultiLine() & MyUniverse.SysGen.RMStart & Symbol_File_NameOfPoint(Cdex) & ".pathname" & myuniverse.sysgen.rmEnd) ' Fix it 
                        End If
                    End If
                    Cdex += 1
                End While ' looping through the symbol

                Select Case Adex
                    Case 0 ' No CameFrom or Goto
                        MyFlowChartErrors(1001, 0, Bdex, Cdex, " Symbol " & FindSymbolName(IndexSymbol)) 'Error 1001 no CameFrom or goto
                        MyFlowChartErrors(1002, 0, Bdex, Cdex, " Symbol " & FindSymbolName(IndexSymbol)) 'Error 1001 no CameFrom or goto
                    Case 2
                        '1002 Symbol does not have a /point GotoNextLine
                        MyFlowChartErrors(1002, 0, Bdex, Cdex, " Symbol " & findsymbolname(IndexSymbol))
                    Case 4
                        '1001 Symbol does not have a /point CameFrom
                        MyFlowChartErrors(1001, 0, Bdex, Cdex, " Symbol " & findsymbolname(IndexSymbol))
                    Case 6 ' It has them both so this error is ok
                End Select 'checking if the symbol has camefrom and a gotonextline
                '1014 No Duplicate /point names
            End If

            'Check for the named possible errors
            If IndexNamed > 0 Then
                '1006 That all of the point names are in the syntax
                If Named_TableSyntax(IndexNamed) = "" Then
                    Abug(999, "empty syntax", IndexNamed, 0)
                    If Named_TableProgramText(IndexNamed) <> "" Then ' Can we make the syntax from the code line?
                        MyParse(MyArray, Named_TableProgramText(IndexNamed))
                        Syntax = MakeStatementSyntax(MyArray)
                        '1015 No Syntax and No Program Code to make it from
                        MyFlowChartErrors(1015, 0, IndexNamed, 0, " Symbol " & Named_TableSymbolName(IndexNamed)) ' Problem with Named only
                    End If
                    MyFlowChartErrors(1006, indexFlowChart, IndexNamed, IndexSymbol, " Symbol " & findsymbolname(IndexSymbol))
                End If
                '1007 That the syntax matches the program text.
                '1008 Make sure that the point names are in the point list
            End If


            ' Check Path
            If indexFlowChart > 0 Then
                '1009 All paths must have at least one output or constant
                Select Case FlowChart_TableCode(indexFlowChart)
                    Case "/use"
                    Case "/path"
                        MyXY.X = FlowChart_TableX1(indexFlowChart)
                        MyXY.Y = FlowChart_TableY1(indexFlowChart)
                        K = MyFindSymbolPoint(FlowChartScreen.PictureBox1, MyXY, FlowChart_TableNamed(indexFlowChart))
                        K = MyFindPoint(FlowChartScreen.PictureBox1, MyXY)
                    Case "/constant"
                    Case "/error"
                    Case Else
                End Select
                '1003 output on Symbol goes to two or more places (A symbol can come from many places, but can only goto one place)
                '1004 Points of a symbol is not connected to any path
                '1005 Paths are not connected to any symbol or constant - they must all connect to both ends to symbol or another path, or a constant
            End If
        End Sub


        Public Shared Sub MyFlowChartErrors(ErrNumber As int32, IndexFlowChart As int32, IndexNamed As int32, IndexSymbol As int32, ErrMsg As String)
            Dim MyXY As MyPointStructure
            Dim WhatDoIDoWithThis As String
            MyTrace(433, "MyFlowChartErrors", 662 - 618)

            'from the indexs tells where to put the error
            WhatDoIDoWithThis = MyMinMax(IndexFlowChart, 0, 1) & MyMinMax(IndexNamed, 0, 1) & MyMinMax(IndexSymbol, 0, 1)
            Select Case WhatDoIDoWithThis
                Case "000" ' No Indexes, 
                    MyXY.X = 0
                    MyXY.Y = 0
                    MakeErrorAt(SymbolScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & errmsg)
                    MyXY.X = 1000
                    MyXY.Y = 1000
                    MakeErrorAt(FlowChartScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "001" 'Symbol Index Only (you must be on SymbolScreen)
                    MyXY.X = Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(SymbolScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "010" 'Named Index Only (you must be on SymbolScreen)
                    MyXY.X = Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(SymbolScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "011" 'Named and Symbol Index (you must be on SymbolScreen)
                    MyXY.X = Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(SymbolScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "100" 'FlowChart index only (you must be on FlowChartScreen)
                    MyXY.X = FlowChart_TableX1(IndexFlowChart) + Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = FlowChart_TableY1(IndexFlowChart) + Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(FlowChartScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "101" 'FlowChart and Symbol index (you must be on FlowChartScreen)
                    MyXY.X = FlowChart_TableX1(IndexFlowChart) + Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = FlowChart_TableY1(IndexFlowChart) + Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(FlowChartScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "110" 'FlowChart and Named (you must be on FlowChartScreen)
                    MyXY.X = FlowChart_TableX1(IndexFlowChart) + Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = FlowChart_TableY1(IndexFlowChart) + Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(FlowChartScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
                Case "111" 'FlowChart, Named, Symbol (you must be on FlowChartScreen)
                    MyXY.X = FlowChart_TableX1(IndexFlowChart) + Symbol_TableX1(IndexSymbol) ' Assume it is a symbol
                    MyXY.Y = FlowChart_TableY1(IndexFlowChart) + Symbol_TableY1(IndexSymbol)
                    MakeErrorAt(FlowChartScreen.PictureBox1, MyXY, MyErrorList(ErrNumber - 1001) & " " & ErrMsg)
            End Select

        End Sub


        '***************************************************
        ' This should enable or disable buttons debending on the current state of the data rule 

        Public Shared Sub MyButtonsEnableRules(CurrentForm As Form)

            'Button Rules
            'disable all buttons if not language is selected
            If OptionScreen.ToolStripDropDownComputerLanguage.Text = "" Then ' No Language selected
                OptionScreen.ToolStripButtonCheckAllData.Enabled = False
                OptionScreen.ToolStripButtonDeleteErrorMsgs.Enabled = False
                OptionScreen.ToolStripButtonDeleteUnusedSymbols.Enabled = False
                OptionScreen.ToolStripButtonDump.Enabled = False
                OptionScreen.ToolStripButtonFlowChartForm_FromOptionScreen.Enabled = False
                OptionScreen.ToolStripButtonSymbolForm_FromOptionScreen.Enabled = False
            Else
                OptionScreen.ToolStripButtonCheckAllData.Enabled = True
                OptionScreen.ToolStripButtonDeleteErrorMsgs.Enabled = True
                OptionScreen.ToolStripButtonDeleteUnusedSymbols.Enabled = True
                OptionScreen.ToolStripButtonDump.Enabled = True
                OptionScreen.ToolStripButtonFlowChartForm_FromOptionScreen.Enabled = True
                OptionScreen.ToolStripButtonSymbolForm_FromOptionScreen.Enabled = True
            End If
            'Options Screen:	Show FlowChart	        
            'Options Screen:	Show Symbol Screen
            'Options Screen:	Delete Error Messages			Must have at least one error message
            'Options Screen:	Delete Unused Symbols			Must have at least one unused Symbol
            'Options Screen:	Dump data into \...
            'FlowChart Screen:	Show Symbol Screen
            'FlowChart Screen:	Show Options Screen
            'FlowChart Screen:	Show FileIO Screen
            'FlowChart Screen:	Add Path					
            'FlowChart Screen:	Select Symbol (to Add) ?????			
            'FlowChart Screen:	Add Constant				Must have constant input
            If Len(FlowChartScreen.ToolStripTextBoxMyInputText.Text) = 0 Then
                FlowChartScreen.ButtonAddConstant.Enabled = False
            Else
                FlowChartScreen.ButtonAddConstant.Enabled = True
            End If
            'FlowChart Screen:	Move Object
            'FlowChart Screen:	Delete Object
            'FlowChart Screen:	Redraw (Shows Show FlowChart Button)



            'FlowChart Screen:	Zoom In					    Must not be highest  scale
            FlowChartScreen.ButtonZoomOut.Text = MyUniverse.SysGen.MyScale.ToString
            FlowChartScreen.ButtonZoomIn.Text = MyUniverse.SysGen.MyScale.ToString
            LimitScale()
            'If MyUniverse.SysGen.MyScale <= 0.00001 Then
            ' FlowChartScreen.ButtonZoomIn.Enabled = False
            ' Else
            FlowChartScreen.ButtonZoomIn.Enabled = True
            ' End If
            'FlowChart Screen:	Zoom Out					Must Not be lowest scale
            'If MyUniverse.SysGen.MyScale > 10 Then
            ' FlowChartScreen.ButtonZoomIn.Enabled = False
            ' Else
            ' FlowChartScreen.ButtonZoomIn.Enabled = True
            ' End If

            'FlowChart Screen:	Select Data Type (For Path)

            'FlowChart Screen:	Select Symbol	?????
            'Symbol Screen:	Show FlowChart Screen	

            'Symbol Screen:	Show Options Screen

            'Compond rules for showing all these buttons
            'symbol screen : symbol name
            'Symbol Screen:	Add Symbol ??????				Must have a symbol selected
            'Symbol Screen:	Move Object	
            'Symbol Screen:	Delete Object
            'Symbol Screen:	Update Symbol				Must have made some change to the symbol????
            'If A symbol name is not there then you can not do most anything to it
            If Trim(SymbolScreen.TextBoxSymbolName.Text) = "" Then
                SymbolScreen.ToolStripButtonUpdateSymbol.Enabled = False
                SymbolScreen.ToolStripButtonAddPoint.Enabled = False
                SymbolScreen.ToolStripButtonAddLine.Enabled = False
                SymbolScreen.ToolStripButtonDelete.Enabled = False
                SymbolScreen.ToolStripButtonMove.Enabled = False
                SymbolScreen.ToolStripButtonUpdateSymbol.Enabled = False
            Else
                'Symbol Screen:	Add Line					Must ALSO have a color selected
                If Trim(SymbolScreen.ToolStripDropDownButtonColor.Text) = "" Then
                    SymbolScreen.ToolStripButtonAddLine.Enabled = False
                Else
                    SymbolScreen.ToolStripButtonAddLine.Enabled = True
                End If
                SymbolScreen.ToolStripButtonUpdateSymbol.Enabled = True
                'Symbol Screen:	Add Point 					Must also have a datatype selected
                If Trim(SymbolScreen.ToolStripDropDownDataType.Text) = "" Then
                    SymbolScreen.ToolStripButtonAddPoint.Enabled = False
                Else
                    SymbolScreen.ToolStripButtonAddPoint.Enabled = True
                End If
                SymbolScreen.ToolStripButtonDelete.Enabled = True
                SymbolScreen.ToolStripButtonMove.Enabled = True
                SymbolScreen.ToolStripButtonUpdateSymbol.Enabled = True
            End If

            '
            'Symbol Screen:	Question Mark, Check All Information		
            'Symbol Screen:	Select Data Type	
            'Symbol Screen:	Select Color
            'Symbol Screen:	Select Symbol to Add/Update 

            UpdateThePointsLineComboBox(SymbolScreen.TextBoxSymbolName.Text)
        End Sub

        '******************************************************************************
        'hack
        'This routine is here to try and find all of the possible problems that I am aware
        'of that was causing problems in not doing what I thought that it should be doing 
        'what I think the data should be doing.
        ' This is to trace down all of my know bug problems And I can put this everwhere 
        Public Shared Function FindingMyBugs(LevelOfBugChecking As Int32) As Int32 'hack
            Dim Idex, Jdex, Flag As Integer
            Dim Status As String

            Return 0

            If LevelOfBugChecking > 10 Then Return 0 ' No Checking for problems



            MyTrace(434, "FindingMyBugs", 922 - 668)
            FindingMyBugs = 0
            If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(31) = False Then Exit Function
            ' only testing for this one bug
            Idex = TopOfFile("named", Named_FileSymbolName, Named_File_iSAM)
            Jdex = Idex - 1
            If Jdex > 0 Then
                If Named_FileSymbolName(Idex) = Named_FileSymbolName(Jdex) Then ' See if two symbols are defined
                    FindingMyBugs += Abug(749, "Two symbols with the name name", Named_FileSymbolName(Idex), Named_FileSymbolName(Jdex))
                End If
            End If

            '*************************************************************
            For Idex = 1 To Named_TableCount
                ' Check for two names in the named file
                If Not IsNothing(Named_FileSymbolName(Named_File_iSAM(Idex))) Then
                    If Not IsNothing(Named_FileSymbolName(Named_File_iSAM(Idex + 1))) Then
                        If Named_FileSymbolName(Named_File_iSAM(Idex)) >= Named_FileSymbolName(Named_File_iSAM(Idex + 1)) Then
                            Abug(745, "The Named Table is out of order at " & Idex, Named_FileSymbolName(Named_File_iSAM(Idex)), Named_FileSymbolName(Named_File_iSAM(Idex + 1)))
                        End If
                    End If
                End If

                'Check for two syntax's being the same 
                If Len(Named_FileSyntax(Idex)) > 1 Then
                    For Jdex = Idex + 1 To Named_TableCount ' From the one in the list to the end
                        If Named_FileSymbolName(Idex) = Named_FileSymbolName(Jdex) Then ' See if two symbols are defined
                            FindingMyBugs += Abug(749, "Two symbols with the name name", Named_FileSymbolName(Idex), Named_FileSymbolName(Jdex))
                        End If
                        If Named_FileSyntax(Idex) = Named_FileSyntax(Jdex) Then ' See if two syntax's match (exactly)
                            Abug(750, "Two Symbols with the same syntax ", Idex & ":" & Named_FileSymbolName(Idex) & ":" & Named_FileSyntax(Idex), Jdex & ":" & Named_FileSymbolName(Jdex) & ":" & Named_FileSyntax(Jdex))
                            Application.DoEvents()
                        End If
                    Next Jdex
                End If

                ' Check for being two Isam's being the same 
                If Named_File_iSAM(Idex + 1) <> 0 And Named_File_iSAM(Idex + 1) = Named_File_iSAM(Idex) Then
                    FindingMyBugs += Abug(824, "Isam has two index to the same name", Idex, Idex + 1)
                End If

                'FindingMyBugs += FindingOutOfIsamOrder("Named", Idex, Named_FileSymbolName, Named_File_iSAM)
                Flag = 0
                For Jdex = 1 To Named_TableCount
                    If Jdex <> Idex Then
                        If Named_File_iSAM(Idex) = Named_File_iSAM(Jdex) Then
                            FindingMyBugs += Abug(818, "Named iSam has duplicated index's at: ", Idex & ":" & Named_File_iSAM(Idex), Jdex & ":" & Named_File_iSAM(Jdex))
                            Flag = Flag + 1
                        End If
                    End If
                Next Jdex

                ' Tell how many are duplicated ' Extra
                If Flag > 0 Then
                    FindingMyBugs += Abug(819, "Number of times the index's are duplicated", Flag, Flag)
                End If
            Next Idex

            '*************************************************************


            For Idex = 1 To NewTopOfFile("Symbol", Symbol_FileCoded) 'Symbol_TableCount '2020 07 19 replaced count
                FindingMyBugs += FindingSymbolOutOfXYSizeBugs(Idex) ' Check if the symbol is within the allowed bounds (??,??)

                ' Test for duplicate names in the symbol table 
                If Symbol_TableCoded_String(Idex) = "/name" Then ' Test if this is a /name record
                    For Jdex = Idex + 1 To NewTopOfFile("Symbol", Symbol_FileCoded) ' from that record to the end (since before has already been checked)
                        If Symbol_TableCoded_String(Jdex) = "/name" Then 'If this is also a /name record
                            'AWarning(950, "Checking if names match", Symbol_FileSymbolName(Idex), Symbol_FileSymbolName(Jdex)) 'hack
                            If MyCompared1_a(Symbol_FileSymbolName(Idex), Symbol_FileSymbolName(Jdex)) = 0 Then 'If they match =0
                                FindingMyBugs += Abug(771, "The same symbol name " & Symbol_FileSymbolName(Idex) & " is at two locations ",
                                     Idex & " : " & MyShowSymbolGraphic(Idex),
                                     Jdex & " : " & MyShowSymbolGraphic(Jdex))
                                Dump1()
                            End If
                        End If
                    Next Jdex
                End If


                If Symbol_FileCoded(Idex) = MyKeyword_2_Byte("/name") Then
                    If Symbol_FileCoded(Idex + 1) = MyKeyword_2_Byte("/name") Then
                        If IsNothing(Symbol_FileSymbolName(Idex)) Or IsNothing(Symbol_FileSymbolName(Idex + 1)) Then
                        Else
                            FindingMyBugs += Abug(814, "FindingMyBugs() Two name with no graphics between", Idex & ":" & Idex + 1, Symbol_FileSymbolName(Idex) & " : " & Symbol_FileSymbolName(Idex + 1))
                            If Symbol_FileSymbolName(Idex) = Symbol_FileSymbolName(Idex + 1) Then
                                FindingMyBugs += Abug(669, "FindingMybugs() Duplicated symbol name ", Idex & ":" & Idex + 1, Symbol_FileSymbolName(Idex))
                            End If
                        End If
                    End If
                End If
            Next Idex
            '*************************************************************
            For Idex = 1 To FlowChart_TableCount ' Through all of the /use/path records (and others)
                Select Case FlowChart_TableCode(Idex)
                    Case "/use"
                        ' Test that the rotation and datatype is valid
                        If FlowChart_TableX2_Rotation(Idex) > SymbolScreen.ToolStripDropDownRotation.DropDownItems.Count - 1 Then ' Check that the number of rotations against the stored balue
                            FindingMyBugs += Abug(740, MyShowFlowChartRecord(Idex), 0, 0)
                        End If
                        ' Need to check for the future options
                        If FlowChart_TableY2_Option(Idex) <> 0 Then
                            FindingMyBugs += Abug(740, MyShowFlowChartRecord(Idex), 0, 0)
                        End If
                    Case "/path" ' currently no checks (should check if connected etc...
                    Case "/constant"' currently no checks, should check that only one per path(s)
                    Case "/error", "/unknown"' Need to recheck all /errors
                    Case Nothing
                        FindingMyBugs += AWarning(804, "FindingMyBugs: invalid code in the symbol table", FlowChart_TableCode(Idex), FlowChart_PathLinks_And_CompiledCode(Idex))
                    Case Else
                        FindingMyBugs += Abug(803, "FindingMyBugs: invalid code in the symbol table", FlowChart_TableCode(Idex), FlowChart_PathLinks_And_CompiledCode(Idex))
                End Select
            Next Idex
            '*************************************************************

            For Idex = 1 To DataType_TableCount
                If DataType_iSAM_(Idex) > 0 Then 'if a valid index
                    If DataType_iSAM_(Idex) = DataType_iSAM_(Idex + 1) Then 'Is the index all messed up, with two index to the same data type name
                        FindingMyBugs += Abug(802, "The duplicate Datatype index", Idex & " : " & DataType_iSAM_(Idex), Jdex & " : " & DataType_iSAM_(Jdex))
                    End If
                End If
                'if the index is wrong then there is a problem, that needs to be fixed (Make it Black?)
                If DataType_FileColorIndex(Idex) <= 0 Then 'Invalid index Indexes
                    FindingMyBugs += Abug(801, "Invalid Datatype Color Index ", Idex & " : " & DataType_FileName(Idex), DataType_FileColorIndex(Idex)) ' Was an invalid color
                ElseIf DataType_FileColorIndex(Idex) > 0 Then ' Valid index Indexes
                    If DataType_FileColorIndex(Idex) > UBound(Color_FileName) Then 'checking if the Indexes is greater then the number of colors 
                        FindingMyBugs += Abug(799, DataType_FileName(Idex) & " points to a color non existant color : " & DataType_FileName(Idex), "Indexes" & " : " & DataType_FileColorIndex(Idex), "Maxiumn number of known colors" & " : " & UBound(Color_FileName)) ' Color number outside of the number of colors available.
                    End If
                    ' points to a valid color so skip **********************
                Else ' will never get to the else (Program problem if you do)
                    FindingMyBugs += Abug(798, "There is no color for this data type : " & DataType_FileName(Idex), Idex, DataType_FileColorIndex(Idex)) ' Should point to a valid color
                End If
                'Making sure that the data type is in order
                Select Case MyCompared3(DataType_TableName(DataType_iSAM_(Idex - 1)), DataType_TableName(DataType_iSAM_(Idex)), DataType_TableName(DataType_iSAM_(Idex + 1)))
                    Case -5 '9   -5 	A > C 'Unsorted List
                        FindingMyBugs += Abug(797, "Datatype is unsorted ERROR ", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}")
                    Case -4 ' beginning of the list so ignore it
                        '5   -4 	A=nothing And b< C
                        '7   -4 	A=Nothing
                        If Not IsNothing(DataType_TableName(DataType_iSAM_(Idex - 1))) Then ' It is not the beggining of the list
                            FindingMyBugs += Abug(796, "Datatype List Out of order", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}")
                        End If
                    Case -3 '11  -3	    A>b List out of order
                        FindingMyBugs += Abug(796, "Datatype List Out of order", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}")
                    Case -2 '12  -2 	b > C List is out of order
                        FindingMyBugs += Abug(795, "Datatype List is out of order ", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}")
                    Case -1 '3   -1	    A=b
                        FindingMyBugs += Abug(794, "Datatype List has a duplicate ", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}") ' dattype should never have a duplicate
                    Case 0  ' they are equal , which they should never be.  only one name allowed per data type
                        ' or they are between nulls or should be between -1 and +1
                        '2   0  	A And C = nothing
                        '10  0	    A<b<C 'not in the list but should go between these
                    Case 1 '4   1  	b=C  Datatype Should never have a duplicate
                        FindingMyBugs += Abug(793, "Datatype List has a duplicate ", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex)) & "} : {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}") ' dattype should never have a duplicate
                    Case 2                        '14  2  	A < b The list is ok, so ignore it
                    Case 3                        '13  3	    b < C The list is ok, so ignore it
                    Case 4'end of the list SO IGNORE IT
                        '6   4	    C=nothing And b > A
                        '8   4	    C = nothing
                    Case 5 ' idex = null Which is not a bug if -1 or +1 is also null
                        Abug(799, "The compare of the Datatypes are wrong because they are out of order", Idex, "{" & DataType_TableName(DataType_iSAM_(Idex - 1)) & "} < {" & DataType_TableName(DataType_iSAM_(Idex)) & "} < {" & DataType_TableName(DataType_iSAM_(Idex + 1)) & "}")
                        '1   5	    b=nothing
                End Select
            Next Idex
            '*************************************************************
            For Idex = 1 To Color_TableCount
                ' The color table should never be nothing
                If Not IsNothing(Color_FileName(Color_iSAM_(Idex))) Then '20200630
                    'The color table should never be nothing
                    If Not IsNothing(Color_FileName(Color_iSAM_(Idex + 1))) Then '20200630
                        ' Testing if two names are out of order
                        If Color_FileName(Color_iSAM_(Idex)) > Color_FileName(Color_iSAM_(Idex + 1)) Then '20200630
                            FindingMyBugs += Abug(782, 0, 0, 0) ' unsorted color names
                        End If
                    End If
                End If
                'Testing each to see if it is in order and returns correctly
                Select Case MyCompared3(Color_FileName(Color_iSAM_(Idex - 1)), Color_FileName(Color_iSAM_(Idex)), Color_FileName(Color_iSAM_(Idex + 1)))
                    Case -5 '9   -5 	A > C 'Unsorted List
                        FindingMyBugs += Abug(777, "color table is out of order === ", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}")
                    Case -4 ' beginning of the list so ignore it
                        '5   -4 	A=nothing And b< C
                        '7   -4 	A=Nothing
                        If Not IsNothing(Color_FileName(Color_iSAM_(Idex - 1))) Then
                            FindingMyBugs += Abug(774, "Color Table is out of order ===", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}") ' color table is out of order
                        End If
                    Case -3 '11  -3	    A>b List out of order
                        FindingMyBugs += Abug(774, "Color Table is out of order ===", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}") ' color table is out of order
                    Case -2 '12  -2 	b > C List is out of order
                        FindingMyBugs += Abug(774, "Color Table is out of order ===", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}")' color table is out of order
                    Case -1 '3   -1	    A=b
                        FindingMyBugs += Abug(774, "Color Table  has a duplicate", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}")' color table should never have a duplicate
                    Case 0  ' they are equal , which they should never be.  only one name allowed per data type
                        ' or they are between nulls or should be between -1 and +1
                        '2   0  	A And C = nothing
                        '10  0	    A<b<C 'not in the list but should go between these
                    Case 1 '4   1  	b=C  Color Table Should never have a duplicate
                        FindingMyBugs += Abug(773, "Color Table has a duplicate ===", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}")
                    Case 2                        '14  2  	A < b The list is ok, so ignore it
                    Case 3                        '13  3	    b < C The list is ok, so ignore it
                    Case 4'end of the list so Ignore it
                        '6   4	    C=nothing And b > A
                        '8   4	    C = nothing
                    Case 5 ' idex = null Which is not a bug if -1 or +1 is also null
                        FindingMyBugs += Abug(779, "The Color Table is out of Order ===", Idex, "{" & Color_FileName(Color_iSAM_(Idex - 1)) & "} < {" & Color_FileName(Color_iSAM_(Idex)) & "} < {" & Color_FileName(Color_iSAM_(Idex + 1)) & "}")
                        '1   5	    b=nothing
                End Select
            Next Idex

            '*************************************************************
            ' Check keywords, operators and functions
            Jdex = 1 'LBound(Language_KeyWords)
            For Idex = Jdex + 1 To UBound(Language_KeyWords)
                If Not IsNothing(Language_KeyWords(Idex)) Then
                    If Language_KeyWords(Idex - 1) = Language_KeyWords(Idex) Then
                        Abug(679, "Program Duplication of key word", Idex, "-->" & Language_KeyWords(Idex - 1) & "<--" & "-->" & Language_KeyWords(Idex) & "<--")
                    End If
                    If Language_KeyWords(Idex - 1) > Language_KeyWords(Idex) Then
                        Abug(679, "Program out of order of key word", Idex, "-->" & Language_KeyWords(Idex - 1) & "<--" & "-->" & Language_KeyWords(Idex) & "<--")
                    End If
                End If

                Status = ThisIsAWhat(Language_KeyWords(Idex))
                Select Case Status
                    Case "keyword"
                    Case Nothing ' Nothing is allowed? only because it might be zero index
                    Case Else
                        Abug(676, "Program data error this >" & Status & "< is not found as an keyword ", Language_KeyWords(Idex), ThisIsAWhat(Language_KeyWords(Idex)))
                End Select
            Next

            Jdex = 1 'LBound(Language_Operators)
            For Idex = Jdex To UBound(Language_Operators) - 1 '  dont cheche highest one because it might no be worted yet
                If Idex > Jdex Then
                    If Language_Operators(Idex - 1) >= Language_Operators(Idex) Then
                        Abug(679, "Program data error allowed Duplication of key word", Idex, Language_Operators(Idex))
                    End If
                End If

                Status = ThisIsAWhat(Language_Operators(Idex))
                Select Case Status
                    Case "operator"
                    Case Nothing ' Nothing is allowed? only because it might be zero index
                    Case Else
                        Abug(676, "Program data error this >" & Status & "< is not found as an operator ", Language_Operators(Idex), ThisIsAWhat(Language_Operators(Idex)))
                End Select
            Next

            Jdex = 1 'LBound(Language_Functions)
            For Idex = Jdex To UBound(Language_Functions)
                If Idex > Jdex Then
                    If Language_Functions(Idex - 1) = Language_Functions(Idex) Then
                        Abug(679, "Program data error allowed Duplication of function key word", Idex, Language_Functions(Idex))
                    End If
                    If Not IsNothing(Language_Functions(Idex)) Then
                        If Language_Functions(Idex - 1) > Language_Functions(Idex) Then
                            Abug(679, "Program data error function key word out of order", Idex, Language_Functions(Idex - 1) & " : " & Language_Functions(Idex))
                        End If
                    End If
                End If

                    Status = ThisIsAWhat(Language_Functions(Idex))
                Select Case Status
                    Case "function"
                    Case Nothing
                    Case Else
                        Abug(676, "Program Data ERROR found as a >" & Status & "< not found as a function name ", ThisIsAWhat(Language_Functions(Idex)), Language_Functions(Idex))
                End Select
            Next
        End Function

        ' Returns all of the status that I want to trace
        Public Shared Function ShowStatuss() As String
            ShowStatuss = "" ' Nothing for now
            ShowStatuss = ShowStatuss & "Problems " & MyUniverse.MyCheatSheet.BugsCounted
        End Function



        Public Shared Sub MyTrace(MyNumber As Integer, MyRoutine As String, NumberOfLineOfCode As Integer) 'hack
            'MyTrace(435, "", )'ignore - recursion
            If MyNumber < 0 Then Exit Sub
            If MyNumber > UBound(TraceWords) Then Exit Sub
            If IsNothing(TraceWords(MyNumber)) Then
                TraceWords(MyNumber) = MyRoutine
                TraceNumberOfLines(MyNumber) = NumberOfLineOfCode
            ElseIf TraceWords(MyNumber) <> MyRoutine Then
                Abug(759, "Trace(): Messages not matching for " & MyNumber, "have " & TraceWords(CInt(MyNumber)), "should be " & MyRoutine)
            End If
            'If OptionScreen.CheckedListBoxOptionSelection.GetItemChecked(29) = True Then
            ' FileInputOutputScreen.TextBox1.Text = MyRoutine & ":" & MyNumber & " : " & TraceWords(MyNumber) & " : " & MyRoutine
            ' End If
            TraceCounts(MyNumber) += 1
        End Sub


        Public Shared Sub MyAddErrorMessages()
            MyTrace(436, "MyAddErrorMessages", 11462 - 10655)
            OptionScreen.ComboBoxDebug.Items.Clear()
            ' This routine just loads the error Test for the messages, 
            '{On or off to display msgbox()}
            '{The number of the message must be between 1000-9999}
            '{an option of 
            '               "wrong"
            '               "information"
            '               "warning"
            '               "error"
            '               "display"
            '}
            'Then a string of the error message where " & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & " ... will be replaced with what the routine passes.
            ' also a few other special's such as " & myuniverse.sysgen.rmstart & "routine" & myuniverse.sysgen.rmEnd & " and " & myuniverse.sysgen.rmstart & "tracer" & myuniverse.sysgen.rmEnd & "

            MyErrorMessages("on", 1000, "Error", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)

            MyErrorMessages("on", 1001, "Error", "Opening file requires write Or read. " &
                            vbCrLf & "Programing error Not reading Or writing file " &
                            vbCrLf & "File name >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  " &
                            vbCrLf & "trying to >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< which Is Not read Or write")
            MyErrorMessages("on", 1002, "Warning", "Checked if the two strings in the list are in iSAM order low >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  high >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1003, "display", "Step " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & ": At Indexs " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " and " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " shows a code " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ". The iSAMs out of order >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<  high >" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1004, "Warning", "Checked if the two strings in the list are in iSAM order low >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  high >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1005, "Error", "Sorting did Not work! And the array Is wrong!")
            MyErrorMessages("on", 1006, "Error", "Sorting did Not work! And the array Is wrong!")
            MyErrorMessages("on", 1007, "Error", "Array length Is " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " & vbCrLf & "iSAM array length Is " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & vbCrLf & " The array And the iSAM array are differant sizes!")
            MyErrorMessages("on", 1008, "Display", "Checked if the two strings in the list:" &
                            vbCrLf & " are in iSAM order >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<< >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1009, "Information", "Compile Finished to file>" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1010, "Information", "Syntax made for symbol " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "syntax = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "  code = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "  path = " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & " Symbol Index " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & " Named index " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1011, "Error", "The Isam is zero, and there is data in the number array Index=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Isam(index) =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  Array(index) = " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1012, "Error",
                            "The found (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " with the iSAM Indexes " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " should match" &
                            vbCrLf & "The two strings are:" &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1013, "Error", "A value Is added to the list with a null before And after " &
                            vbCrLf & "(-1)" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "(+0)" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "(+1)" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "." &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1014, "information", "Trying to find >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<  At index " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1015, "Status", "Checking paths at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "< (" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1016, "Information", "Resorting with  Bubble Sorting " &
                            vbCrLf & " at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  (+0) " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " swapped higher >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " at " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & " with (+0) " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "lower >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1017, "Warning", "Index at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Found a Duplicate in the iSAM table " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " and " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1018, "Error", "We are adding iSAM to a record that has a Differant iSAM causing an Error " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1019, "Error", "The array Is wrong!  " &
                            vbCrLf & "So we are bubble sorting the array instead of quick sorting it.")
            MyErrorMessages("on", 1020, "Warning", "Swapping >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "at (+0)s " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "iSAMs " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "  ")
            'removed from findingmybugs()
            MyErrorMessages("on", 1021, "Error", "Symbol Name Not Found -->" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<---")
            MyErrorMessages("on", 1022, "Error", "Netlinks Array Boundries has been exceded  low=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " < at=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " < top=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " in list of numbers  ?=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "")
            MyErrorMessages("on", 1024, "Warning", "Can Not add to enum list in " &
                            vbCrLf & "List Name >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "Number = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "ItemNumber offset " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1026, "Information",
                            "Comparing ->" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<-with->" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            "<-- at index=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1027, "Information",
                            "At Index's = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " & " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
            vbCrLf & "Swapping iSAM's " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " & " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "With Strings >" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "< & >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "Same values being swapped")
            MyErrorMessages("on", 1028, "Information", "Get (+0) " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "code >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1029, "Information", "Testing distances betweeen points " &
                            vbCrLf & "(" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")" &
                            vbCrLf & "(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")" &
                            vbCrLf & "(" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ")" &
                            vbCrLf & "Index=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "distance 1 =" & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "distance 2 =" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1030, "Display", "NOT Compiling code " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " : " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " : " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1032, "Display", "Starting to re-paint at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "ending at " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "Number to draw " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1034, "Wrong", "Testing for change of link " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "Code =>" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "Link=>" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1035, "Error", "Because there is no / " &
                            vbCrLf & "Testing for change of link " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  " &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1036, "Error", "Because there is no / " &
                            vbCrLf & "Testing for change of link " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  " &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1037, "Information", " Making up Named " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " symbol at " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " at from unknown code " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " with first path " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1038, "Information", "Finding Point at symbol table code >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "Index " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "searching for closest points to (" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ").")
            MyErrorMessages("on", 1039, "Information", "Binary find point at symbol table code >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " & vbCrLf & " XY (" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")   " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "CurrentIndexOffset " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1048, "Error", "Color Not Defined >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< with datatype >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< at index " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " at line number " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  changed to " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd)
            'MyErrorMessages("on", 1051, "display", "Swap indexs " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & " with " & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & " " & vbCrLf & "symbol name>" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & "symbol name>" & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & "<")
            'changed from off
            MyErrorMessages("on", 1053, "Warning", "Swapping >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "with     >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "at (-1) " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "iSAM " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Number of swaps made = " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1054, "Error", "Added at (2) before (1) in table ?? added " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1059, "Information", "Inserting = >" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & "<  into Symbols Table " &
                            vbCrLf & "code = >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "named = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "Point Name =>" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "X1=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " &
                            vbCrLf & "Y1=" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " &
                            vbCrLf & "X2=" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " &
                            vbCrLf & "Y2=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1060, "Error",
                            " not able to return from list >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "inside the " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " list")
            MyErrorMessages("on", 1061, "Information", "swap  >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            'MyErrorMessages("on", 1071, "Display", "") 
            'MyErrorMessages("on", 1087, "Display", "Clearing the screen on form: >" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1089, "Information", "Find the closest (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") to start at (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1090, "Information", "Find the one and only START symbol")
            MyErrorMessages("on", 1092, "Information", "get the " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " point at (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1093, "Information", "get the " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " point from a symbol point at (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") ")
            MyErrorMessages("on", 1094, "Information", "get a symbol at (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") with a direction of " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1095, "Information", " testing if this point is outside the screen area (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1096, "warning", "Drawing nothing is ignored at (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1098, "Information", " Snap point (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") to be on a " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " grid")
            MyErrorMessages("on", 1100, "Error", "Added this symbol >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< and then could not find it again Line Number =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1101, "Information", "Exporting to file: >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1103, "Information", "Move the symbol and all of the paths at index " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " " & vbCrLf & "a distance of :(" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1104, "Information", "Checking if two symbols are to close to each other (on top) koalas923@icloud.com>" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1105, "Information", "at Index =" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " ,(" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")   and (" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1106, "Information", "at Index =" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " ,(" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")   and (" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1107, "Information", "at Index =" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " ,(" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")   and (" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1108, "Information", "Finding point test for closest now " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1109, "Information", "found closer point " &
                            vbCrLf & "new Distance" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "Old Distance " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "(+0)" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "    (" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ") " &
                            vbCrLf & "and (" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1110, "Information", "found closer point distances " &
                            vbCrLf & "Distance " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " to distance " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "from old index " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " to new index " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1111, "Information", "atXY= (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") , " &
                            vbCrLf & "in XY1=(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "), " &
                            vbCrLf & "XY2=(" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ")  " &
                            vbCrLf & "Index=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1112, "Information", "Searching for Start or Main at Code= >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " & vbCrLf & "Name= >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & "index=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1113, "Information", "Got symbol index=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " distance " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "xy=(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ") " &
                            vbCrLf & "List at=(" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ") " &
                            vbCrLf & "name=>" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1114, "Error", ">" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< is an unknown command mode")
            MyErrorMessages("on", 1116, "Error", "Not done Yet")
            MyErrorMessages("on", 1117, "Error", "I do not have anything in the case statement for a code type >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "looking for /Path, /Use, /constant, /error")
            MyErrorMessages("on", 1118, "Error", "Did not find a color or datatype =>" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<  ERROR CODE = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1119, "Information", "Match to datatype >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1120, "Error", "Not matched to color name or dattype names =>" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            'MyErrorMessages("on", 1121, "Information", "")
            'MyErrorMessages("on", 1122, "Information")
            MyErrorMessages("on", 1123, "Error", "The index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " has index outside the range " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " and " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " in the iSAM Table. " & vbCrLf & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " < " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " < " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            'MyErrorMessages("on", 1124, "Error", "")
            'MyErrorMessages("on", 1125, "Error", "")
            'MyErrorMessages("on", 1126, "Error","")
            'MyErrorMessages("on", 1127, "Display", "")
            'MyErrorMessages("on", 1128, "Display", "")
            MyErrorMessages("on", 1129, "Error", "Invalid Index for iSAM Indexes   1 <= " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  <= " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1130, "Information", "Checking new path at index= " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  (" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1131, "Information", "(" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")  to (" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "," & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1132, "Information", "at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " checking name >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                                                       "against " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "     name >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<")
            'MyErrorMessages("on", 1133, "Display", "")
            '''''MyErrorMessages("on", 1134, "Information", "Import Finished" & vbCrLf & "Number of lines=" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & vbCrLf & "Names = " & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & vbCrLf & "Symbol = " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & vbCrLf & "FlowChart = " & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & vbCrLf & "Data Types =" & myuniverse.sysgen.rmstart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & "Colors = " & myuniverse.sysgen.rmstart & "string6" & myuniverse.sysgen.rmEnd)
            'MyErrorMessages("on", 1135, "Display", "At input line number " & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1136, "Display", " Exporting Colors to file >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            'MyErrorMessages("on", 1148, "Information", "Command >" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "< Mouse= (" & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ", " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "), Button value=" & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ", Delta Value=" & myuniverse.sysgen.rmstart & "string5" & myuniverse.sysgen.rmEnd & ".")
            MyErrorMessages("on", 1149, "Display", "De-Compiling Source From file >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1158, "Error", "Invalid (+0) into Record List, (+0) less than One > " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ".")
            MyErrorMessages("on", 1159, "Error", "Expecting a /Use record And got a " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Instead.")
            MyErrorMessages("on", 1163, "Error", "Invalid Rotation =" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  named = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<.")
            MyErrorMessages("on", 1164, "Error", "There Is no name For this use record " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ".  Record " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " Has no name.")
            MyErrorMessages("on", 1167, "Error", "This should never happen  " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " <> 0 And (1)" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " = (2)" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " ")
            MyErrorMessages("On", 1168, "Error", "The (+0) should never be zero " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("On", 1169, "Error", "This should never happen (1)" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " <> 0 And (1)" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " = (2)" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " ")
            MyErrorMessages("On", 1170, "Wrong", "The index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Of a number array should not bet zero " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1183, "Display", "Swapping >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "with     >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "at (+0)s " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "iSAMs " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "Counter " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1189, "Information", "The List has nothing at (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " iSAM set to " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "FromRoutine=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "Tracer=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " ")
            'MyErrorMessages("on", 1200, "Information", "Left of Down (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1201, "Information", "Directly Down&Left (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1202, "Information", "lower of Left (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1203, "Information", "Left (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1204, "Information", "upper of left (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1205, "Information", "directly Up&Left (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1206, "Information", "Left of Up (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1207, "Information", "Up (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1208, "Information", "Directly Right&Up (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1209, "Information", "Programmer Direction Error (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            'MyErrorMessages("on", 1210, "Information", "Right of Up (" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & "," & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & ")       {(" & myuniverse.sysgen.rmstart & "string9" & myuniverse.sysgen.rmEnd & ")}")
            MyErrorMessages("on", 1211, "ERROR",
                            vbCrLf & "Line Number " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Key word   = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "input line =>" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "Unknown Information at line >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "Line of unknown >" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1212, "Error", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Do you want to add this color?" & vbCrLf & "Unknown Color :" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ":" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1214, "Error", "Unable to run because there Is no symbol with the name START Or MAIN.  You need a symbol named 'start' or a symbol named 'main' in this program")
            MyErrorMessages("on", 1215, "Error", "Found a match when binary search failed to find it between >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< AND >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1234, "Display", "Checking the " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " for duplicate names from 1 to " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1237, "Information", "Moving the ends of paths that are connected to this moved symbol " &
                            vbCrLf & "for Index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "  (" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1241, "Information", "Named_Table=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", Symbol_Table=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ", FlowChart_Table=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", DataType_Table=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", Color_Table=" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1242, "Information", "at removing " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " at index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1246, "Information", "Already have this path " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1247, "Information", "status for index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Index >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< links >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1248, "Information", "Finding all paths connected together index  = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " links >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1250, "Error", "The FlowChart index is greater than the maxiumn number of the records.  The FlowChart index of " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ".  Is greater than the maximum number in the FlowChart array " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1251, "Error", "String exceeded " & ConstantCharterLength & " characters " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1252, "Warning",
                            "Duplications in the list" &
                            vbCrLf & "(-1)=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "(+1)=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1253, "Error", " at index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Step" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & ": The iSAM Table is outside the {Min 1< " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  <" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " Max}  Value >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1254, "Error", "Indexes out of bounds.  An index Indexes is out of bounds index -1 = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " :  at iSAM(-1) " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " and (+0)" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & " at isam(+0) " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd)
            '            MyErrorMessages("on", 1255, "Information", "Compiling to file name >" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1256, "Error", "Invalid (+0) into Record List.  (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " greater than maxinum Of array size " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ".")
            MyErrorMessages("on", 1257, "Display", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Swapping >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1258, "Display", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Swapping >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "  at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            '''''''MyErrorMessages("on", 1259, "Display", "Open for file operation type read/write >" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1260, "ERROR", "Routine not written yet ! (Just returns True inside box )  (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1264, "Display", "no match found and nothing else >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<, It was added, Function = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1265, "Warning", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "() Swapping >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "  at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1266, "Display", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "() Swapping >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "  at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1268, "Error", "Unable to add the symbol name to the symbol name list >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1269, "Wrong", "Passed color name to get >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< datatype color >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< color using >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1270, "Wrong", "Found a match when none found in binary search  >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< looking for >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1273, "Information", "Invalid Rotation Number " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Name >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1274, "Information", "(" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ") >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1275, "Information", "Sitting on top of each other at (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1276, "Error", "YouHaveAnErrorMessage() " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1277, "Error", " Unknown code at (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " with code of >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1278, "Error", "Trying to draw >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1279, "Error", "Error drawing p0int invalid code= >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< name= >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< Name of Point = >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1280, "Error",
                            "Duplication in the list" &
                            vbCrLf & "(-1)=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "(+1)=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & " iSAM points to =" & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & "  Array()= >" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & "< ")
            MyErrorMessages("on", 1281, "Information", "Comparing (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " with (+0) " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " with (+0) " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1282, "Error", "symbol named >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< is on top of symbol named >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< moving away from each other.")
            MyErrorMessages("on", 1283, "Error", "Unknown command mode >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1284, "Warning", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "() Swapping >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "  at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1285, "Information",
                            "Distance = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd &
                            " x1=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            " y1=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            " x2=" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            " y2=" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd &
                            " dist1=" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            " dist2=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd &
                            " dist3=" & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd &
                            " dist4=" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1286, "Information", "Distance = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "  " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & " ")

            'changed from off
            MyErrorMessages("on", 1291, "Information", "Didn't Find DataType >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1293, "Information", ">" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<.")
            MyErrorMessages("on", 1294, "Information", ">" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< (" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ").")
            MyErrorMessages("on", 1295, "Information", "(" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            'MyErrorMessages("on", 1296, "Information", "")
            MyErrorMessages("on", 1298, "Information", "at (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1299, "Display", "Number of Symbol Names = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " ")
            'MyErrorMessages("on", 1320, "Information", "(+0) " & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1321, "Information", "XY (" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ")")
            MyErrorMessages("on", 1322, "Display", "Displaying symbol @ symbols= >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<  >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<  >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1324, "Information", "Drawing Point at (+0) " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " named >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< symbol named >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< Point Name = " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ".")
            MyErrorMessages("on", 1326, "Warning", " number of flag " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Swapping >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "at Index's " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "  " &
                            vbCrLf & "iSAMs " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & "  ")
            MyErrorMessages("on", 1327, "Display", MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "() Swapping >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< with >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< at (+0)s " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "  iSAMs " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & "  at " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)

            MyErrorMessages("on", 1332, "Error", "return of adding this symbol failed and returnd an error code " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " & vbCrLf & " Symbol name : >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1333, "Information", "Ready")
            MyErrorMessages("on", 1337, "Information", "Checking (+0) find " & vbCrLf & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " = Searching for " & vbCrLf & vbCrLf & "Before: " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & vbCrLf & "At    :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & vbCrLf & "After :" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1340, "Information",
                            "Checking (+0) find " &
                            vbCrLf & "Searching for  = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "Before:>" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "At    :>" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & "After :>" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & "<" & vbCrLf &
                            vbCrLf & "FlowChart Index:" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Named Index" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1341, "Information",
                            "Checking (+0) find " &
                            vbCrLf & "From FlowChart Searching for >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf &
                            vbCrLf & "Named Before: " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Named At    :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Named After :" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "FlowChart Index=" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Named Index =" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf &
                            vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1343, "Information",
                            "Checking (+0) find " &
                            vbCrLf & "Searching for = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf &
                            vbCrLf & "Before: " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "At    :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "After :" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "FlowChart Index=" & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Named Index=" & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1366, "Information", "Checking Index find " & vbCrLf & "Searching for =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & vbCrLf & vbCrLf & "Before: " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & vbCrLf & "At    :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & vbCrLf & "After :" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1367, "Information", "Checking Index find " & vbCrLf & "Searching for =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & vbCrLf & "Before: " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & vbCrLf & "At    :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & vbCrLf & "After :" & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & vbCrLf & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf & "Tracer = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1373, "Information", "Array iSAM is not in the correct order" & vbCrLf & "Searching for  >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & vbCrLf &
                            "(+0) -1 = >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " & vbCrLf &
                            "(+0)    = >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "< " & vbCrLf &
                            "(+0) +1 = >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "< ")
            'MyErrorMessages("on", 1374, "Information", "")
            MyErrorMessages("on", 1375, "Information", "Unknow Code " & vbCrLf & "> " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & "Code=>" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & "(" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ")-(" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ")" & vbCrLf & "Links = " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & vbCrLf & "Named = " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd & vbCrLf & "Other = " & MyUniverse.SysGen.RMStart & "string7" & myuniverse.sysgen.rmEnd & vbCrLf & "(+0) = " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1377, "Error", "Invalid iSAM(+0) of " & vbCrLf & "iSAM=" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & vbCrLf & "Array=>" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " & vbCrLf & "called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1380, "Warning", "The iSAM() points To an invalid index " &
                            vbCrLf & "iSAM=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            'MyErrorMessages("on", 1381, "Information","")
            'MyErrorMessages("on", 1382, "Information", "List Equal" & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & " compare results " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & " " & vbCrLf & "Searching for >" & myuniverse.sysgen.rmstart & "string4" & myuniverse.sysgen.rmEnd & "<" & ConstantExplainCompared)
            'MyErrorMessages("on", 1383, "Information", "Comparing " & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & " compare results " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & ConstantExplainCompared)
            'MyErrorMessages("on", 1384, "Information", "Comparing " & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string1" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & ">" & myuniverse.sysgen.rmstart & "string2" & myuniverse.sysgen.rmEnd & "<" & vbCrLf & " compare results " & myuniverse.sysgen.rmstart & "string3" & myuniverse.sysgen.rmEnd & ConstantExplainCompared)

            MyErrorMessages("on", 1385, "Error", "The array at index " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " is empty  iSAM(+0) =" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "  >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1387, "Error", "The iSAM() points To an invalid index In the array" &
                            vbCrLf & "iSAM=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1388, "Warning", "The iSAM() points To an invalid index" &
                            vbCrLf & "iSAM=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "routine=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "FromRoutine=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "Tracer=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " ")
            MyErrorMessages("on", 1389, "Warning", "The iSAM() points To an invalid index In the array" &
                            vbCrLf & "iSAM=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "(+0)=" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "routine=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "FromRoutine=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & "Tracer=" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " ")
            MyErrorMessages("on", 1390, "Warning", "Index is below One " &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1391, "Error", "Index is greater than the max size of ARRAY()" &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1392, "Error", "Index is greater than the max size of iSAM()" &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1393, "Error", "Index is greater than the max size of ARRAY()" &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1394, "Error", "Index is greater than the max size of iSAM()" &
                            vbCrLf & "Checking in routine " & MyUniverse.SysGen.RMStart & "string8" & myuniverse.sysgen.rmEnd & " called from " & MyUniverse.SysGen.RMStart & "routine" & myuniverse.sysgen.rmEnd & " tracer " & MyUniverse.SysGen.RMStart & "tracer" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1395, "Error", "The iSAM is out of order before index (Text1 & Text2)" &
                            vbCrLf & "Text1 = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "1st to 2nd = " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Text2 = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Compare test used to determine this message = " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1396, "Error", "The iSAM is out of order after index (Text2 & Text 3)" &
                            vbCrLf & "Text2 = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "2nd to 3rd = " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "text3 = " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "Compare test used to determine this message = " & MyUniverse.SysGen.RMStart & "string6" & myuniverse.sysgen.rmEnd &
                            vbCrLf & "called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1398, "Error", "Invalid (+0) of >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1399, "Error", "Invalid Index of >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1400, "Information", "Invalid (+0) of >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1401, "Information", "Invalid (+0) of >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< called from " & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd)

            MyErrorMessages("on", 1402, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1403, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1404, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1405, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1406, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1407, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1408, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1409, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1410, "Error", "Line " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", Lost the >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & " >" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "< " &
                            vbCrLf & "for symbol name >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1411, "Error", "Not Able to return a valid index for " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " " &
                            vbCrLf & " for keyword >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<" & vbCrLf &
                            " Inputline = >" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & "<" & vbCrLf &
                            "Input Line Number = " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1413, "Error", "At step " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ".  Adding blank information to the list >" & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & "<   >" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<")
            MyErrorMessages("on", 1414, "Error", " at " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & ".  blank information changed to ? in the list from line " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd & " " & vbCrLf & ">" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & "<" &
                            vbCrLf & " the format should be :" & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd &
                            vbCrLf & " inputLine is : " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1433, "Information", "#" & MyUniverse.SysGen.RMStart & "string9" & myuniverse.sysgen.rmEnd & " - FlowChart Index = " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " Symbol Index = " & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & " named index " & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd)
            MyErrorMessages("on", 1435, "Error", "Can not Find Color " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " When It should be in the colors")
            MyErrorMessages("on", 1436, "Error", "Invalid Message Error Number " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " ERROR *******")
            MyErrorMessages("on", 1437, "Information", "Unable To swap because isam points To zero " & MyUniverse.SysGen.RMStart & "string1" & myuniverse.sysgen.rmEnd & " <" & MyUniverse.SysGen.RMStart & "string2" & myuniverse.sysgen.rmEnd & "<" & MyUniverse.SysGen.RMStart & "string3" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string4" & myuniverse.sysgen.rmEnd & ", " & MyUniverse.SysGen.RMStart & "string5" & myuniverse.sysgen.rmEnd)
        End Sub
    End Class
End Namespace
