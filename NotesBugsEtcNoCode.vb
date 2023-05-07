

'20210507 Added hand to move windown/picture box of flowchart editor

Module NotesBugsEtcNoCode
    'h ack   		'Still Needs to be Looked at
    't odo   		'Things that I have not programmed yet
    'u ndone 	'Things that might not be working, but I have not checked or fixed.
    'b u g    A bug I have found (But can work around it for now)

    'ToDo List *************************************************
    'todo /point is not getting set with the correct IO (x2) or the Y2
    'my version of BNF syntax for a computer language added
    ' syntax = syntaxword ::::: definedBNFsyntaxword[nothing or * or ? or + or - ] or 'character' or "string" or <group> or '<unicode character(s) or class of characters >'
    ' where ? means this is optional, - means but not these, * means optionally repeatable , + means
    ' (BNF) grammer defines (code) syntax defines (variables, keywords, operators, characters sets, ...)

    'the line color from a symbol is not correctly being set (on startup)
    'todo change all of the crlf to be at the end of the string, instead of the start. (boy I do everything backwards)
    'done X todo make sure that the message of select class of computer language comes up first thing 
    'done X todo then a message of select dielect of language class
    'the ? last variable is being lost when parsing or rebuilding syntax. (its now doubling any unknown point names) (see a=,b=,c=,d=,e=)
    'todo bug the symbol window width is set to black and should be a width from zero to min-grid snap/2
    'todo When using non-7 bit Ascii character set, need to fix the strings to allow for non-english characters for things.
    'todo This can be done, by making all of the constants that I have into things that can be imported....
    'todo Add a unknow/forign character set.(Myuniverse.sysgen.constants.constant----......
    'todo The above in Phase two. (maybe done)

    'todo should a /use record be in the nets table? when it connects to a point of that symbol??  or would that create 'crossnets?'
    'todo add a C_L_Label, and a C_L_Goto to hold the keyword for labels and how to goto.
    'bug the symbols are to close so that the next ones camfrom is on top of the last ones goto
    'Bug when I put a beginning path to a symbol it is connecting to another path from another symbol, and the names do not match
    'todo need to add option to save the current file, and then start for a new subroutine/function
    'todo also  This is because this version will only handle local variables.(need to add pages to have each one on it's own page, then think about globals.
    'todo need to put the current file into the title on the flowchart Window, 
    'todo and current symbol in the title of the symbol Window,  
    'todo and the computer language in the title of the option Window
    'todo Need to add camefrom/goto per line, then multiline, change to Goto/CRLF/CameFrom in the middle 
    'todo need to look at the abtract logic of multi line IF() Then Else (Case also?) Computer GoTo and other muylti goto branches
    'todo looking having syntax for the Definitions of data types (add a syntax to the datatable for "dim ?? as integer", "integer ??"    'bug flowchart output
    '   " in /ignore line
    '   in /language line
    '   in /C_L_Comment option
    '   in /option line
    '   in /keyword, /operator, /function line
    ' " and return in /color lines
    '   both in /datatype line
    '   might also be in /name line 
    ' blank line in /point
    ' the same point name is given to more than one point (To all of them the same name? (In fact they all comput as address(line number).pathname, never changes to other point names, but it has the right X,Y? I think

    'bug in the export there are /path statements (seems to be what should have been the /points, and the /points are ???)
    'todo /filename, should take out the label adder, and camefrom adder at the beginning and end 
    'bug export has ", blank lines
    'bug when exporting, the results is that every /point has the same point name.(Address----)
    'bug GotoNextLine and CameFromLine is being told that it is a path name, instead of a keyword
    'bug symbol Window always selects the last symbol
    'todo add after the keyword, the default picture lines  IE:  Blue,(-20,-20)_(20,-20)_(20,45)(0,0),  ----- where ,color name for this line, ')_(' means line from last to next,  and no - after the ) means end of the line, with new color or continue with same color of a new line
    'TODO the line numbers are not getting updated with the color of the line.
    'todo fix bug the /error is being inserted into the wrong symbol (The one before it.)
    'todo Need a button to save all of the symbols into seperate file (later all that have changed)

    'todo the datatype of the "start" is wrong when printing out in debug.
    'todo add /order= (Global, routines(Top, code, end))  [ Which means all globals, then the top/code/end of each main)] (, means then next, ( means all symbols connected top-code/end before then next )
    'todo The datatype is not giving the same (ie: it is a long, but returns word
    'todo move the fip/flop button from symbol Window to FlowChart Window
    'todo add and delete to the symbol all of the variable names in the program text box.
    'todo make the output code ability to write each section of code then put them all together in order.
    'todo need to clear out the data after the mydecompile
    'todo autoroute (option 19) when you decompile (Make sure that I am getting the name of the variable as the name on the path.
    'todo decompile does not connect the paths
    'todo check that the names of the veriables are being used for the path name in decompile
    'todo (needs to be checked) see about not letting the buttons be clicked twice 
    '  do not let more than two or three work at the same time! because it overflows the stack)
    'todo /error is not being put in the symbol that caused it to have an error.
    'todo Add to the options list : Auto Path Datatype to Point Datatype
    'todo Add to the options list : auto complete paths
    'todo Add to the options list : auto route paths
    'todo Add to the options list : auto move symbols
    'todo Add to the options list : auto flip symbols
    'Doc  .in the symbol Window, you can only add points and lines after you have first got a symname.
    'todo it is not redrawing when you add a point in the symbol Window
    'make newsymbol button have color (to be able to show when it's disabled)
    'todo 'bug : Show FlowChart	- has to double click to get button to work the first time on the option Window
    'todo need to add OptionalStart...optionalend to the syntax
    'todo Add making the syntax, only if optionalstart...end is not there.
    'todo Need to add both optional, and also select one from a list ie(variable or expression or list or alpha or numberic or alphanumberic ...ie:[variable,expression,quote] )
    'todo Need to add expressions (variable/constant (then optional) [operator expression] 
    'todo Add list variable/constant (then optional) [ "," list]  
    'todo Add Statement (with list and expression)
    'todo need to get the cpuid serial number and use it for register to get /make a register key
    'todo Add /obstruction (X only, Y only , X & Y , and fix/unfix (or locked/unlocked), or else it is just a place holder to be able to route path here.
    ' If AutoRoute is turned on, then make all available paths in an /obstruction (locked or unlocked obstruction)

    'to do make sure that the path is connected to the some other path , else auto route it, or cause an error message to be in the flowchart.

    'Todo on the select symbol, make it a tree (collectionitem in collection item based on the keyword (each keyword is a step into the tree (it End While is in t end->while-> etc)
    '   (where end-> has the list end sub, end function , end while, end if, etc.)

    'todo need to have something to say this is the end of the block/subroutine/function/name space (the end of local variables that do not connect with the rest of the flowchart automatically made symbols.
    'ie: end sub, end function, end, end namespace, end class, finish ...(Save as *.flowchart, (dont forget to add some button to save every symbol by it self))

    'todo need to add to the data table somehow, the micro text code to define every path name at the beggining of the subroutine ...

    'todo when selecting a symbol on the symbol Window, it does not update the point names used.
    'GetButtonNames()

    'todo going from Window scale to real scale is not working correctly.
    '   The height and width of picturebox1 should be -250,-250 t0 250,250 real and 0,0 to x.width,y.height Window

    'todo on the symbol Window when you enter text and it makes the syntax,
    '   I need to also fill in the point names,
    '   and make the points when finished
    '   (lost focus on the program text box
    'todo the symbols are not showing up in the image area correctly and on time.

    'todo check that all of the buttons display the hint (capture every _changed and put in a buttonrules()
    'todo change from the scrolls to let a hand move the picture.(Dyminic, then redraw without cleaning the Window first.

    'todo Ideas (make the name of the point an expression), 
    'todo   (make all variables into expandable options by adding an operator to an point (new button to add it to a point)
    'todo   Add List and Expressions to Syntax
    'ToDo  Error - All pen objects can not be assigned values (startcap, endcap, style, ...)
    'ToDo   The toolstrip drop down will switch Windows because I am setting the text from the symbol to the flowchart Window, (Needs a workaround)
    'ToDo   ALSO it does not let me select from the drop down.
    'ToDo   Make sure that drillUP gets the name of the last file opened.
    'ToDo   Make sure that drillDOWN gets the name of the Current file opened.
    'ToDo   the FILE IO Window 1.buttons needs to be hit twice to work, 2.the files with the right extensions are not displayed
    'ToDo   Check that all of the buttons work (After changing them from buttons to toolstripbuttons, and toolstripdrop downs)
    'ToDo   on the flowchart Window pressing to show the symbol Window, the message is adding a symbol to the flowchart
    'ToDo   Needs to pre-set defaults in the options Window for input/output, width, #bytes (Color drop down, and DataType drop down)'ToDo   The Show FlowChart button in the options Window does not take you to the FlowChart
    'ToDo   The select symbol in the FlowChart Window does not work
    'ToDo   Changeing the computer language needs to have program status updated
    'ToDo   The button to select a symbol in the symbol Window does not get the symbol data
    'ToDo   in the options Window , button deelte unused symbol toool tip is wrong
    'ToDo   need a subroutine to enable or disable the function buttons (IE can not select a symbol , if there are no symbols
    'ToDo   bug in decompile, it will put in the /use symbol twice (with paths)
    'ToDo   Bug in counting the atom after it is being parsed, it is done twice, both different from each other.
    'ToDo   Need to add the datatypes and colors to the dropdowns on FlowChartWindow (maybe remove them from the symbols form.
    'ToDo   need to start to chack all of the buttons to make sure they work
    'ToDo   need to write the auto route to run on the added symbols from compileline()
    'ToDo   Need to add to Expresion, List, optional
    'ToDo   all symbols must have one /point name 'CameFrom' and one /point 'GotoNext'  {Even if not uses such as start and end/return}
    'ToDo   If not then must have the program add those to the symbol???????? (Yes for now)
    'ToDo   AND leave an error message that we did that.
    'ToDo   need to make the points automatically from the names on the symbol Window
    'ToDo   The variable names are not getting to the paths (and/or to the point names)
    'ToDo   The /use links are not correctly getting the value of the [variable(s)]  ??.value =
    'ToDo   The /use links are not getting the variable name correctly (uses constantvariable etc)
    'ToDo   The /use is getting between the quotes
    'ToDo   The FlowChartdump show multiply symbols with the same name 
    'ToDo   The output show Function with ==COS, and multiply times.
    'ToDo   how do you turn off the i/o type in the symbol display
    'ToDo   why is there a number of ways to turn off the:
    'ToDo  	display symbol name		show symbol names
    'ToDo  	display point names		point names
    'ToDo  	
    'ToDo  does not update the symbol information 
    'ToDo  (ie 	syntax, 
    'ToDo  	notes, 
    'ToDo  	symbol filename, 
    'ToDo  	macro code 
    'ToDo  	point name(s)
    'ToDo  	machine code
    'ToDo  	stroke encoding
    'ToDo  	datatype
    'ToDo  	color name
    'ToDo  	width,
    'ToDo  	bytes
    'ToDo  	inputoutput)
    'ToDo   the NEW paths are not where the symbols are.NEED to CHECK them when they are made to make sure they are all aligned
    'ToDo   added checkpathconnected() to make sure that a path is connected to another Path or connected to a symbol point
    'ToDo   Lowest MSG_Abug(22 739
    'ToDo   The paths made might not be at the symbol points, (ie 100 or more off)
    'ToDo   must add a timer to move/check paths and also move/check symbols, are not on top of each other.
    'ToDo   path making rule A.must have symbol with only two points above and below each other.
    'ToDo   MUST FIX THE NEXT ONE TO FIND THE issue OF TWO NAMES
    'ToDo   The /name is getting into the table twice
    'ToDo   Making points in the symbol creation of keyWord (it should not do that)
    'ToDo   Need to allow expresion to happen, that just grows the points and Operator along on e of the 16 directions that is available now.
    'ToDo  1.The path names should be the name of the decomplie variable .
    'ToDo  2.The names of the files need to com from or also add the languages being used, and to whate is there now.
    'ToDo   Change the location of added points for decompile to a table 2020 07 26 (Which is puting them close but needs it done better.
    'ToDo   Added checkboxes for all of the languages (and a few move for the future )
    'ToDo   2020 07 25 started to add language specific information to the program
    'ToDo   added CR LF and TAB as special character in IsThisASpecial() 2020 07 25
    'ToDo   need to have an option for usery1 > ???? to allow longer/bigger FlowCharts 
    'ToDo   rewrote the makeitbigger() to use the file_counter and then but a makitbigger in each topoffile call
    'ToDo   I made a bug when I took out a bunch of ByRef'ToDo  s keyWord.
    'todo connect the point/line lists up to be able to change the information about a point make sure that If a point name is changed then also change that information in the /point and also in the program code (What issues that could cause!!
    'todo the points and lines need to ba editable/changable from the symbol Window
    'ToDo   Need to add import & options for: What special characters are allowed in a variable name)
    'ToDo         What special characters are allowed in a variable name
    'ToDo         what is the field seperator for input files (and import option
    'ToDo         Changing the error message text (and maybe the level?)
    'working on single line DeCompile bugs
    'ONGOING ADD more FindingMyBugs(), MSG_Abug( ) and awarning , and add MSG_Ainfo( ) 

    ' Add /Replace=from text, to text
    'make sure that there is a format for /set...
    ' Add language specific options to the import file, and then export them when calling all language.dll
    'check that it is writting out all of the op[tions.
    'Write all of the set options
    'it did Not output /options
    'on save file, it should have the extension of the language type, instead of .source or .src    'ToDo Change Sort to be a Insert Sort
    'Write a quick tutorial to start using 
    'Write a book on FlowChart Computer Language (trademark, and register)
    ' Add a /conversion=datatypename from, datatypename to, syntax -->{To = convertInterger2String(From)}
    ' needs the for all conversions from one datatype to another.
    ' also do something about variablename.object...check that it works
    'ToDo   Need to output all of the parameters into the export file
    'ToDo CheckBox-, -X, -Y
    'ToDo     DisplaySymbolName
    'ToDo     DisplayPointNames
    'ToDo     Constants
    'ToDo     Names
    'ToDo     ErrorText
    'ToDo     Reserved99
    'ToDo     InputOutPu
    'ToDo     IDStroke
    'ToDo     FileName
    'ToDo     AutoConnect
    'ToDo     Notes
    'ToDo     Opcode
    'ToDo     IndexShortCutPointer
    'ToDo     CodeOrthogonalPaths
    'ToDo     MakePathsSnapToPoints
    'ToDo     AutoMoveSymbols
    'ToDo     Reserved1
    'ToDo     Reserved2
    'ToDo     OutPutLineNumbers
    'ToDo     ShowPathNames
    'ToDo  Checking buttons:
    'ToDo  Options Window:
    'ToDo  	Show FlowChart	
    'ToDo  	Show Symbol Window
    'ToDo  	Delete Error Messages
    'ToDo  	Delete Unused Symbols
    'ToDo  	Dump data into \...
    'ToDo  FlowChart Window:
    'ToDo  	Show Symbol Window
    'ToDo  	Show Options Window
    'ToDo  	Show FileInputOutput Window
    'ToDo  	Add Path
    'ToDo  	Select Symbol (to Add) ?????
    'ToDo  	Add Constant
    'ToDo  	Move Object
    'ToDo  	Delete Object
    'ToDo  	Redraw (Shows Show FlowChart Button)
    'ToDo  	Zoom In
    'ToDo  	Zoom Out
    'ToDo  	Select Data Type (For Path)
    'ToDo  	Select Color
    'ToDo  	Select Symbol	?????
    'ToDo  Symbol Window
    'ToDo  	Show FlowChart Window
    'ToDo  	Show Options Window
    'ToDo  	Add Symbol ??????
    'ToDo  	Add Point 
    'ToDo  	Add Line
    'ToDo  	Move Object
    'ToDo  	Delete Object
    'ToDo  	Update Symbol
    'ToDo  	Question Mark, Check All Information
    'ToDo  	Select Data Type
    'ToDo  	Select Color
    'ToDo  	Select Symbol to Add/Update 
    'ToDo   Look into being able to change the input formats (by using the constantFormat as the guide)
    'ToDo   Long term (third phase) add line ends, with graphics, ...
    'ToDo   import()  options to change the mydirections and the flip tables
    'ToDo   add options to control the file extensions, and language test (so you only allow symbols with that language (Error message if you try to use one, and a button to get ride of all that do not work in your language(s).
    'ToDo   during decompile it does not display the symbols on the FlowChartWindow  while it is working.
    'ToDo   The parsed() is not correctly telling the syntax of the program text (issues with 1.2.)
    'ToDo   not able to add points or lines now.(They do not show up)
    'ToDo   Need to be able to name points (Or add them (from the program text[]) and let them only be moved and not added?????)
    'ToDo   need to check that datatypes or line colors are selected first before adding them
    'ToDo   Changed around SymbolWindow and made the picture bigger.
    'ToDo   Does not draw the symbol on SymbolWindow when active
    'ToDo   Changed MyInsertSymbol() to have the index where to insert it at 2020 07 18 (Mistake on my part, opps)
    'ToDo   copy2Window???  on SymbolWindow only changes it to -500,-500 instead of the actural conversion
    'ToDo   Compileing is finding the closest to the symbol instead of the closest to the point of the symbol.
    'ToDo  x Bug is that the name of the symbol is used instead of the name of the point in compile()
    'ToDo   Invalid message of path goes nowhere on symbols.
    'ToDo  BUG The Symbol Points are no longer where they should be.
    'ToDo   The symbol Window selects the wrong symbol (the one below the one selected)
    'ToDo   SymbolWindow needs heading above the four dropdowns
    'ToDo   Inserting symbol(s) graphics in the endinstead of inserting them where they belong!!!!!!
    'ToDo   The arrors for the points are not the correct color for the data type.
    'ToDo   datatypes are not getting sorted before exporting
    'ToDo   does not overwrite the /microcodetext created by this program.(Should I even Have it, and do I have to have it?)
    'ToDo   need to output /color /datatype X/keyWord all in order 
    'ToDo   missing flip-flop and options in the /use
    'ToDo   not outputing last /path
    'ToDo   path names switched to be first!! (So what is the new last item? suppost to be now ( I forgot))
    'ToDo   missing the options on save'ToDo  s
    'ToDo   MISSING /POINT IN SAVE'ToDo  S
    'ToDo   output the symbol name in the point now (Does not need it?!)
    'ToDo   does not save the /keyWord
    'ToDo   half of all time is spent comparing strings !!!!!!
    'ToDo   When looking up the color from a data type , the index of that color is not pointing to the right color.
    'ToDo   still lost paths.
    'ToDo   Going through all messages currently at 1264
    'ToDo   replaced as many _file with _table as I found 6/7/20
    'ToDo   Addthe following line everywhere that there was a swapN(...)
    'ToDo   BUG the symbol points are also no longer in the symbol picture for each symbol displayed
    'ToDo   Add in files for support to change add to
    'ToDo   Need to see why the buttons are no longer working
    'ToDo   get rid of the paths of all colors that I was testing
    'ToDo   Need to add the level of debug showing to OptionsWindow
    'ToDo   Added combo boxs on form 3, and they are getting duplicated.
    'Doc  .document the import/export files formats and options.
    'ToDo   Export no longet outputs correctly, and all ENUMS are output as numbers, not the text they represent.
    'ToDo   Need to change it so that any /USE with the symbol only having a goto (and no CameFrom) is used instead of the 'ToDo  start'ToDo   symbol
    'ToDo   Need to add a disply of the visual stroke movements in SymbolWindow (symbol)
    'ToDo   Need to not show FlowChartWindow when importing (only OptionsWindow) then switch back
    'ToDo   Need to add findFirstXY() to speed up checking 
    'ToDo   Change all of my constants to be on OptionsWindow as variables
    'ToDo   On OptionsWindow add a list of the points and text boxes of what they stand for.(Like the other combo boxes)
    'ToDo   I have paths at 1000, -20000 but it will not draw or show below Y = 0 (About)
    'ToDo  Need to go through from a started file making everythink for a demo (writting down the steps, to show how its done)
    'ToDo   CHECK EACH OF THE FOLLOWING ROUTINES IF THEY NEED TO BE RUN AND ARE TAKING TO LONG'ToDo  
    'ToDo   MyCompared3      ran 14446 times
    'ToDo   InvalidIndex         ran 8450 times
    'ToDo   MyMakeArraySizesBigger       ran 3567 times
    'ToDo   Pop          ran 3217 times
    'ToDo   DataType_TableName       ran 2926 times
    'ToDo   MyCompared1      ran 2024 times
    'ToDo   MyEnumValue      ran 1869 times
    'ToDo   FileCounter      ran 1694 times
    'ToDo   FileCounter      ran 1694 times
    'ToDo   Color_TableName      ran 1590 times
    'ToDo   MyUnEnum         ran 1455 times
    'ToDo   WhatComputerLanguage     ran 1443 times
    'ToDo   TopOfFile        ran 1390 times
    'ToDo  ======================================================================
    'ToDo  Phase two, 
    'ToDo     Need to make a Window layout (And page layout)
    'ToDo     Needd to make symbols that are controlable
    'ToDo on SymbolWindow:
    'ToDo     disable add point if: 1, datatype not check , number of bytes, size of line
    'ToDo     disable add line if : 1, color not selected.
    'ToDo     if a color is selected then clear the datatype, and the add button
    'ToDo     disable the add point and line if the number of bytes or line width is not filled in (IE: non zero)
    'ToDo   Need to add in /#program text the ability to test for conditions
    'ToDo  
    'ToDo  Phase Three, need to decompile from any source into a FlowChart (Minor advancement 2020 07 14)
    'ToDo     (Making it automatic to a FlowChart from a language source program) ditto
    'ToDo     Using the symbols /microcodetext to decompile into ditto
    'ToDo  Window still does not show ALL of the FlowChart on the top and left.
    'ToDo  Paths have no width showing (Should be a min of ...
    'ToDo   Need to have an option for the path to snap to the closes point that matches the same datatype (ie logic to logic, integer to integer, real to real AX to AX, Eb to Eb  etc)
    'ToDo  Need to Add to make sure that every /name in symbols has a name in Named_file also
    'ToDo  Need to remove unused symboles from lib
    'ToDo  need to add symbols only from other files (import NEW symbols only from file)
    'ToDo  Need to be able to creat new symbols
    'ToDo   need to add /stroke to let users id symbols without naming them
    'ToDo   Unable to change the font size in MyDrawText(), Need to change it so that the size of the letters are changeable
    'ToDo   Need to have drilldown() only work on a selected symbol()
    'ToDo then needs to add auto rount (around ever thing that is already there)
    'ToDo   need allow the Numberal options of:
    'ToDo   	Grid Snap (10/19/18 added, a c heck box, but not change the amount)
    'ToDo  	In C heck, the direction to move symbols (and paths) on top of each other.
    'ToDo   Need to c heck for paths ontop of each other.
    'ToDo   need to set the focus back to the text boxes after pushing a button (and making the button 'ToDo  show pushed'ToDo  
    'ToDo   C heck if an error message ready exist at that XY
    'ToDo   Button in options to delete all Error messages on the Window
    'ToDo   Change Error messages to 'pictures' of what;'s wrong.'
    'ToDo   Add an /Include Filename.ext (to recursively call import)
    'ToDo   Does not allow colors other than those with the name pens.color (Which I put into init( ))
    'ToDo   Does not allow to edit the color or datatype support files.
    '
    'ToDo need to have the select symbol dropdown be a tree - select each letter until you get to the end, or a form with all of the symbol pictures displayed
    'Done Added error messages if issue of not enough data in the import file.
    'todo Option to not move symbols in when c hecking (and fixing)
    'todo To speed things up, make 4 iSAM MyArrays for the FlowChart (for pointers to the X1, Y1, X2, Y2, then sort those MyArrays) To help find the Inswx to XY's fast er 10/22/2018
    'done Add /Author & Version Date for symbols 10/31/2018
    'todo  check to only export if there is data (If not MyIsNothing() then don't)
    'todo   change all from Bubble sort : Need to have a resort, which will only sort the last addedd item in the sorted file.*10/`/18
    'done Need to create a file when trying to write/export 10/15/18
    'done Need to add back in the color names in the Color file 10/15/18
    'done need to add buttons on SymbolWindow (to work on Symbolfile) just like FlowChartWindow (That works on the FlowChart file) 10/15/18
    'done Neded to add a listbox of colors, and datatypes 10/15/18
    'todo delete button in SymbolWindow - seems to delete the whole symbol, not a line or point 10/18/18
    'done need to add the commands Add path, symbol, line, point ...constant
    'done Need to get constant value from input line, and add constant
    'done Need to make move symbol also move the connected points of paths (each point of the symbol's xy moved ALL paths Points)
    'done Needs to limit the symbol size (constant for now -constantSymbolCenter to constantSymbolCenter) 10/18/18
    'todo Delete a point in symbols will delete all of the other information in Named.10/19/18
    'done Need to allow editing of all symbol points (Data Type , Input/output)? Nope, Can delete and add faster

    'todo (delete and add) Need to edit Symbol information: 10/19/18
    'todo check	NEW Symbol Name, 
    'todo check		Filename (to get/save to), 
    'todo check		Opcode?, 
    'todo check		Notes, 
    'todo check		Language used, 
    'todo check		Stroke used
    'todo check	 needs to add orthanganol option 10/19/18
    'todo check	Need to name points (Currently defaults to DataTypeName) 10/22/18 (Changed the datafile also)
    'todo check	'Need to have OptionsWindow full Window
    'todo check	'Corrected Snap from xy/50 to (xy-(50/2))/50 so that it snaps on the closest grid 10/31/2018
    'todo check	'Get rid of the constant.....rewrite enum() and unenum()...and get over ride information from a file.11/12/2018
    'todo check	'Write in a method of debugging everything in steps of testing.11/12/2018
    'todo check	' expresion <=- variable
    'todo check	' expresion <=- variable {operator} expresion 
    'todo check	' expresion <=- variable {operator} ( expresion )
    'todo check	' expresion <=- ( expresion )
    'todo check	' expresion <=- ( expresion ) {operator} variable
    'todo check	' expresion <=- expresion {operator} expresion
    'todo next version change /keywords, /operators, / function to:
    'todo next version /partsofSyntax = keyword,while
    'todo next version /partsofsyntax = operator,+
    'toto next version /partsofsyntax = declearation, declear    /syntax=declearation variable......
    'todo next version /partsofsyntax = function , abs(variable)
    'todo next version /partsofsyntax = function , call subroutinename ( variable1, variable2)
    'todo next version /partsofsyntax = expression , variable
    'todo next version /partsofsyntax = expression , ( ,  expresion,  operator,  expresion, )
    'todo next version where ??? is optional,  ???? is required
    'todo next version /partsofsyntax = expression , ??? ( , ???? variable, ??? operator, ??? variable , ??? )
    'todo next version or some other way of making syntax optional
    'todo next version /partsofsyntax
    'todo next version /partsofsyntax
    'todo check	'todo Put back in the expired date.
    '************ Finished *******************************************************************************************
    '********************************************************************************************
    '********************************************************************************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '**************Save to the end bugs that have been fixed Below ******************************
    '********************************************************************************************
    '********************************************************************************************
    '********************************************************************************************

    'ToDo  fixed bugs list
    'ToDo   QC This: fixed 2020 08 26 The arrows of symbols are not pointing the correct direction.Need to check it in 
    'ToDo   QC This: 20200714 Fixed Its no longer drawing the symbols, because the named_pointer () is not pointing to the right place anymore.(since I took it out of the redraw to speed things up)
    'ToDo   QC This: 2020 06 29 change to NOT have sym_Files...have an index (Since the pointer has to come from the Names_FilesPointer())
    'ToDo   QC This:  Added FindingMyBugs(), MSG_Abug(22 ,) a lot of places 'ToDo   QC This: 20200625-2020?? ??
    'ToDo   QC This:  FIXED Data issue -  THE /LINE COLORS CAME OUT ALL THE SAME (AT LEAST FOR THE sTART AND END)
    'ToDo   QC This:  DONE Trying to get horz and virt scroll bars to show up (at least - first)
    'ToDo   QC This:  fixed? Error the name of the point is going into the datatype
    'ToDo   QC This:  fixed? Make sure that all of the index' s is pointing to the correct file/table
    'ToDo   QC This:  fixed? The Data Type is not working!!!
    'ToDo   QC This: 3/12/19 Added "EXTRA" to any code that I think should not be there, because I put it in to find errors, or avoid other errors
    'ToDo   QC This: 4/12/19 Some where the iSAM is being duplicated, so that there is two with the number number after sorting
    'ToDo   QC This:  Changed all of the bubble sort to quick sort.(Changed it all back because of so many issues with it)
    'ToDo   QC This: issues with always sorting when it shouldn't 
    'ToDo   QC This: sorted wrong, And cant find it in the list (When I step through the list I find it)
    'ToDo   QC This:  Need to see that the sort is ALWAYS working
    'ToDo   QC This: Add in /Options=
    'ToDo   QC This:  /option=50,{on,off}   turn on and off stuff that will crash the program
    'ToDo   QC This:  /option=51,on     turn on everything messages, and displays
    'ToDo   QC This:  /option=52,on     turn off all display messages
    'ToDo   QC This:  /option=53,off    Turn off all information messages
    'ToDo   QC This:  /option=54,off    Turn off all Warning messages
    'ToDo   QC This:  /option=55,off    turn off all wrong messages
    'ToDo   QC This: add in /colors linetypes and linestyles support file 
    'ToDo   QC This:  need to allow input of the offset for text displaying of a symbols code/notes/etc
    'ToDo   QC This:  Need to see why it is taking so much time now? to redisplay
    'ToDo   QC This: Add in /Rotation file (And all ofther files besides color and datatype)
    'ToDo   QC This: I should stop sorting the symbols, and replace them with an iSAM MyArray of pointers that is sorted to the MyArrays
    'ToDo   QC This: Change it so that input and output files are source code files with comments for the FlowChart information
    'ToDo   QC This:  I have lost all of the lines of symbols.(because of the pointers from Named_tablepointer() being wrong 20200714)
    'ToDo   QC This:  The colors of lines are not yet displayeed *10/9/18 They disappeared again
    'ToDo   QC This: Lost all lines in symbols.
    'ToDo   QC This: Need to also rotate symbols
    'ToDo   QC This: Add to input file /Options=name of option, value to set to  (Only some options, and all of the error/information messages)
    'ToDo   QC This:  loses a symbol (most likely its the first symbol That I am losing)
    'ToDo   QC This: Need to name paths (Currently Defaulted to UnNamed) (changed to line_ or Path_)
    'ToDo   QC This:  Do I Need to be able to name a point (outside the datatype?) when adding a point NO
    'ToDo   QC This:  changed reduced() to TopOfFile() 2020/6/19


    'ToDo   QC This:  import file format (Internal format)
    'ToDo   QC This:  
    'ToDo   QC This:  Colors must be first (before you use them) they overwrite the standard color information
    'ToDo   QC This:  /Color=Color Name, Alpha, Red, Green, Blue, Style, StartCap, EndCap
    'ToDo   QC This:  
    'ToDo   QC This:  Data types must come second, (before you use them.)
    'ToDo   QC This:  /datatype=datatypename, Number Of Bytes, Color Name, Color Width, Describtion
    'ToDo   QC This:  
    'ToDo   QC This:  Symbols must come before FlowChart /use that calls them and after you have defined the data types and colors they call
    'ToDo   QC This:  The name must come first, afterwards they can be in any order.
    'ToDo   QC This:  Only one /name, /filename, /Version, /Author, Language, /Stroke - The last one will be used, otherwise more than one is allowed.
    'ToDo   QC This:  /Name=Symbol Name, options
    'ToDo   QC This:  /Point=X, Y, Input/Output, Data Type, Name
    'ToDo   QC This:  /Line=x1, y1, x2, y2, Color
    'ToDo   QC This:  /FileName=Device:/Path/FileName.Extension
    'ToDo   QC This:  Should select one from the list.(Or make up your own libararys)
    'ToDo   QC This:  {} is optional input and can be ignored, or not entered.
    'ToDo   QC This:  /Stroke={}
    'ToDo   QC This:  /Notes={}
    'ToDo   QC This:  /Version={}
    'ToDo   QC This:  /Author={}
    'ToDo   QC This:  /OpCode={}
    ' 
    'ToDo   QC This:  Path names will be over written if named 'noname' or two differant names are in the same path.
    'ToDo   QC This:  Rotation options are:
    'ToDo   QC This:    Default, Flip, Flop, Rotate90, Rotate180, Rotate270, FlipRotate90, FlipRotate180, FlipRotate270, FlopRotate90, FlopRotate180, FlopRotate270, FlipFlop
    'ToDo   QC This: 	flip is side to side exchange
    'ToDo   QC This: 	flop is top and bottom exchange
    'ToDo   QC This: 	FlipFlop is the same as rotate180
    'ToDo   QC This:  /Path=x1, y1, x2, y2, Data type, Name
    'ToDo   QC This:  /Use=X, Y, rotation, Name
    'ToDo   QC This:  /Constant=Name, X, Y,  Value
    'ToDo   QC This:  /microcodetext=Order, Text [replacements] text ...

    'ToDo   QC This:  replacements allowed in the program text
    'ToDo   QC This:   where [point.variable] will be used 99% of the time
    'ToDo   QC This:  [Point.variable]	[point.PathName]
    'ToDo   QC This:  [point.name]	    [Symbol.name]   [Symbol.PointName]
    'ToDo   QC This:  [point.X1]	    	[symbol.X1]
    'ToDo   QC This:  [point.y1]		    [Symbol.y1]
    'ToDo   QC This:  [point.IO]
    'ToDo   QC This:  [point.Datatype]
    'ToDo   QC This:  [point.Rotation]
    'ToDo   QC This:  [point.index]	    [symbol.index]
    'ToDo   QC This:  [point.name]	    [symbol.name]
    'ToDo   QC This:  [point.datatype]
    'ToDo   QC This:  [point.datatypedescribtion]
    'ToDo   QC This:  [point.datatypenumberofbytes]
    'ToDo   QC This: X adds /point before the /name fixed
    'ToDo   QC This: X Not correctly key words, but seeing them as variables, (Some Times, other times it does catch them
    'ToDo   QC This: Limits symbol=(-250,-250)_(250,250)
    'ToDo   QC This: Limits symbol points 121
    'ToDo   QC This:  Need to get rid of the radio buttons, and replace it with a DropDown with the parameters
    'ToDo   QC This:  It is not matching correctly symbols already defined syntax match.
    'ToDo   QC This:  Need index on syntax() to make it faster to find
    'ToDo   QC This:  (fixed) The saved file has _ in the path name, but no where in the data during input/output
    'ToDo   QC This:  Export() /name=,= fixed 2020 07 28
    'ToDo   QC This:  Need to add /Function and /Operator= (and act like keyWord for now)
    'ToDo   QC This:  need to add IsThisAnOperator() for +-/* and Function ABS, Sin, COS etc (Just line keyWord, but in a different file.
    'ToDo   QC This:  Character set over 128
    'ToDo   QC This: Bug recursive resort runs out of memory(stack)2020 09 20
    'ToDo   QC This: Need to add the type ([{Label}]) instead of variable for after gotos
    'ToDo   QC This: need to change the syntax to be [point.name] format
    'ToDo   QC This: Dump the Trace also with a dump 
    'ToDo   QC This: replacing [ with ([{ and so on........
    'ToDo   QC This:  Need to add fields to change the computer language Definitions.
    'ToDo   QC This:  Need to be able to input each of the languages fields via inports 'ToDo   QC This: /language='ToDo   QC This: 
    'ToDo   QC This: The status text line on symbolWindow is to high and covered by the buttons 12-11-2020
    'ToDo   QC This:  on the options Window when it first comes up, need to set defaults
    'ToDo   QC This:  also needs to have the pathstart, end, rotation, ...set
    'ToDo   QC This: FlowChart Window Select Symbol is a button, and should be a dropdown
    'ToDo   QC This:  File i/o Window needs tip text set
    'ToDo   QC This:  reformated the trace output in dump()
    'ToDo   QC This:  FlowChart Window the program status is stuck behind the toolstrip
    'ToDo   QC This: Changed original stat to be Max (and then never changes it, lets the user change it - Except FileInputOutput should always be normalized)
    'ToDo   QC This: List of option check boxes (and assumed XY offsets for 'ToDo   QC This: displays)
    'ToDo   QC This: 1 	AutoMoveSymbols
    'ToDo   QC This: 2 	DisplayCode
    'ToDo   QC This: 3 	DisplayConstants
    'ToDo   QC This: 4 	DisplayPointNames
    'ToDo   QC This: 5 	DisplaySymbolName
    'ToDo   QC This: 6 	DisplayErrorText
    'ToDo   QC This: 7 	DisplayFileName
    'ToDo   QC This: 8 	DisplayIDStroke
    'ToDo   QC This: 9 	DisplayIndexShortCutPointer
    'ToDo   QC This: 10 	DisplayInputOutPut
    'ToDo   QC This: 11 	DisplayNotes
    'ToDo   QC This: 12 	DisplayOpCode
    'ToDo   QC This: 13 	DisplayPathNames
    'ToDo   QC This: 14 	OutputLineNumbers
    'ToDo   QC This: 15 	OrthogonalPaths
    'ToDo   QC This: 16	    DisplayPathDataValues
    'ToDo   QC This: Bug: When the Symbol Window first comes up, the program status Text Box is in the wrong place, (after any resize, it corrects itself)
    'ToDo   QC This:  Fixed above (And other things), by making everything inside a toolstrip....12-16-2020  After I lost everthing from flowchart004 and made flowchart10 (three digit to two digit versions now (Major and Minor)
    'ToDo   QC This:  The flowchart Window no longer appears after the options Window
    'Done : No selection on the line/widths on the option Window
    'Done check Options Window starting up:



    'fixed bugs and todo list
    'fixed 2020 08 26 The arrows of symbols are not pointing the correct direction.Need to check it in 
    '20200714 Fixed Its no longer drawing the symbols, because the named_Indexes () is not pointing to the right place anymore.(since I took it out of the redraw to speed things up)
    '2020 06 29 change to NOT have sym_Files...have an index (Since the Indexes has to come from the Names_FilesIndexes())
    ' Added FindingMyBugs(), MSG_Abug(22 ,) a lot of places '20200625-2020?? ??
    ' FIXED Data issue -  THE /LINE COLORS CAME OUT ALL THE SAME (AT LEAST FOR THE sTART AND END)
    ' DONE Trying to get horz and virt scroll bars to show up (at least - first)
    ' fixed? Error the name of the point is going into the datatype
    ' fixed? Make sure that all of the index' s is pointing to the correct file/table
    ' fixed? The Data Type is not working!!!
    '3/12/19 Added "EXTRA" to any code that I think should not be there, because I put it in to find errors, or avoid other errors
    '4/12/19 Some where the iSAM is being duplicated, so that there is two with the number number after sorting
    ' Changed all of the bubble sort to quick sort.(Changed it all back because of so many issues with it)
    'issues with always sorting when it shouldn't 
    'sorted wrong, And cant find it in the list (When I step through the list I find it)
    ' Need to see that the sort is ALWAYS working
    ' Add in /Options=
    ' /option=50,{on,off}   turn on and off stuff that will crash the program
    ' /option=51,on     turn on everything messages, and displays
    ' /option=52,on     turn off all display messages
    ' /option=53,off    Turn off all information messages
    ' /option=54,off    Turn off all Warning messages
    ' /option=55,off    turn off all wrong messages
    ' Add in /colors linetypes and linestyles support file 
    ' need to allow input of the offset for text displaying of a symbols code/notes/etc
    ' Need to see why it is taking so much time now? to redisplay
    ' Add in /Rotation file (And all ofther files besides color and datatype)
    'I should stop sorting the symbols, and replace them with an iSAM MyArray of Indexess that is sorted to the MyArrays
    'Change it so that input and output files are source code files with comments for the FlowChart information
    ' I have lost all of the lines of symbols.(because of the Indexess from Named_TableSymbolIndexes() being wrong 20200714)
    ' The colors of lines are not yet displayeed *10/9/18 They disappeared again
    'Lost all lines in symbols.
    'Need to also rotate symbols
    ' Add to input file /Options=name of option, value to set to  (Only some options, and all of the error/information messages)
    ' loses a symbol (most likely its the first symbol That I am losing)
    'Need to name paths (Currently Defaulted to UnNamed) (changed to line_ or Path_)
    ' Do I Need to be able to name a point (outside the datatype?) when adding a point NO
    ' changed reduced() to TopOfFile() 2020/6/19


    ' import file format (Internal format)
    ' 
    ' Colors must be first (before you use them) they overwrite the standard color information
    ' /Color=Color Name, Alpha, Red, Green, Blue, Style, StartCap, EndCap
    ' 
    ' Data types must come second, (before you use them.)
    ' /datatype=datatypename, Number Of Bytes, Color Name, Color Width, Describtion
    ' 
    ' Symbols must come before FlowChart /use that calls them and after you have defined the data types and colors they call
    ' The name must come first, afterwards they can be in any order.
    ' Only one /name, /filename, /Version, /Author, Language, /Stroke - The last one will be used, otherwise more than one is allowed.
    ' /Name=Symbol Name, options
    ' /Point=X, Y, Input/Output, Data Type, Name
    ' /Line=x1, y1, x2, y2, Color
    ' /FileName=Device:/Path/FileName.Extension
    ' Should select one from the list.(Or make up your own libararys)
    ' {} is optional input and can be ignored, or not entered.
    ' /Stroke={}
    ' /Notes={}
    ' /Version={}
    ' /Author={}
    ' /OpCode={}
    ' 
    ' Path names will be over written if named 'noname' or two differant names are in the same path.
    ' Rotation options are:
    '   Default, Flip, Flop, Rotate90, Rotate180, Rotate270, FlipRotate90, FlipRotate180, FlipRotate270, FlopRotate90, FlopRotate180, FlopRotate270, FlipFlop
    '	flip is side to side exchange
    '	flop is top and bottom exchange
    '	FlipFlop is the same as rotate180
    ' /Path=x1, y1, x2, y2, Data type, Name
    ' /Use=X, Y, rotation, Name
    ' /Constant=Name, X, Y,  Value
    ' /microcodetext=Order, Text [replacements] text ...

    ' example
    ' /name Start
    ' /Point=0,250,OutPut,GOTO,Logic
    ' /Point=250,0,output,CommandLine,String
    ' /microcodetext=main, Jump [GOTO]
    ' /microcodetext=main, CmdLine: [CommandLine]
    ' /microcodetext=main, ;This Is The Start of The Program
    ' /Use=X, Y, rotation, Name

    ' replacements allowed in the program text
    '  where [point.variable] will be used 99% of the time
    ' [Point.variable]	[point.PathName]
    ' [point.name]	    [Symbol.name]   [Symbol.PointName]
    ' [point.X1]	    	[symbol.X1]
    ' [point.y1]		    [Symbol.y1]
    ' [point.IO]
    ' [point.Datatype]
    ' [point.Rotation]
    ' [point.index]	    [symbol.index]
    ' [point.name]	    [symbol.name]
    ' [point.datatype]
    ' [point.datatypedescribtion]
    ' [point.datatypenumberofbytes]
    'X adds /point before the /name fixed
    'X Not correctly key words, but seeing them as variables, (Some Times, other times it does catch them
    'Limits symbol=(-250,-250)_(250,250)
    'Limits symbol points 121
    ' Need to get rid of the radio buttons, and replace it with a combobox with the parameters
    ' It is not matching correctly symbols already defined syntax match.
    ' Need index on syntax() to make it faster to find
    ' (fixed) The saved file has _ in the path name, but no where in the data during input/output
    ' Export() /name=,= fixed 2020 07 28
    ' Need to add /Function and /Operator= (and act like keyWord for now)
    ' need to add IsThisAnOperator() for +-/* and Function ABS, Sin, COS etc (Just line keyWord, but in a different file.
    ' Character set over 128
    'recursive resort runs out of memory(stack)2020 09 20
    'Need to add the type ([{Label}]) instead of variable for after gotos
    'need to change the syntax to be [point.name] format
    'Dump the Trace also with a dump 
    'replacing [ with ([{ and so on........
    ' Need to update the /language options if they are on the line
    ' Need to add fields to change the computer language Definitions.
    ' Need to be able to input each of the languages fields via inports '/language='
    'The status text line on symbolWindow is to high and covered by the buttons 12-11-2020
    ' on the options Window when it first comes up, need to set defaults
    ' also needs to have the pathstart, end, rotation, ...set
    'FlowChart Window Select Symbol is a button, and should be a dropdown
    ' File i/o Window needs tip text set
    ' reformated the trace output in dump()
    ' FlowChart Window the program status is stuck behind the toolstrip
    'Changed original stat to be Max (and then never changes it, lets the user change it - Except FileIO should always be normalized)
    'Dont added dump3() for all status's and msgctr(s).Need to add an options.do dump Bugs, warnings, status's and/or msgctr(and which ones)
    'Done Added options of what to dump (bugs, warning, status, mesctr)
    'Done Getting into loop that blows the stack (somewhere inside the decompile, while cleaning up the links
    'Done add imports to change the locations of the automatic points when decompiling - ImportSymbolPointPreference
    'Done add imports to where each of the points in symbol creation goes.
    'Done Added to imports /Set
    'Done It is not selecting or changeing languages on toolstripSelectButton_Click
    'Done strighten up the dump of the information (Add tabs, to make it easier to see inside of excel)
    'Good Enough Add a splash Window (to hide all of the startups.
    'Good enough If flash Window visible then do not show any other Windows as visible  (Still lets FlowChart Window flash, Cause I donot want to change the startup screeen, cause I'm lazy)
    'done The Function/Operator/keyWord are not inputing correctly 
    'done need to start with a scale 2 or 3 times zoomed out (changed to be .0625 or zoomed in 16 times)
    'Done turn the default for output line number option off
    'Done FIX it only outputs one /function, /operator, /keyword
    'Done donot output  anything starting with zzzzzzzzz(Or maybe ZZZZZZZZZZ)
    'done donot output symbol zzzzzzzzzSymbol
    'Done Need a status bar showing progress of the fileio
    'Done The selected symbol is no longer showing in the symbol text box in symbol Window
    'Done on the startup of the option Window, no button should be enabled until a language is selected.
    'done The add point and add line is not working in the symbol Window (First thing )
    'Done on the flowchartWindow make the add line in color to show when it's disabled
    'Done on the symbol Window make the line/point width/size in color to show when it's disabled
    'Done on the symbol Window make the start and stop line colored  
    'Done button rules on the symbol Window if there is nothing in the symbolname then disable buttons and dropdowns
    'DONE need to add new rule s if the buttons are available or not
    'done symbol Window add point button			Must have symbol displayed, and a point on the list with a name (make a default name to begin with for now, and all options selected with default
    'Done symbol Window add line button			Must have a symbol displayed, color, width
    'Done symbol Window Move object button			must have an point,line
    'Done symbol Window Delete button			must have a point line
    'Done symbol Window New Symbol button			Must have a new Symbol Name
    'Done symbol Window update symbol button			Must have made changes to the symbol
    'Done symbol Window Symbol select dropdown 		
    'Done symbol Window button
    'Done symbol Window button
    'Done it duplicates the symbol name when you tab off from changing the symbol name (instead of adding new symbol)
    'Done add some color to the fileio icons
    'Done Show Symbol Window
    'Done check FlowChart Window starting up:
    'Done Show Symbol Window startup 
    'Done Show Options Window
    'Done Show FileInputOutput Window
    'Done  make a checklist of QC on what to check (and check steps along the way.of how to check)
    'Doc  .Reference number usage
    ' All of the fixes below were lost because of a bad sector on the disk drive.
    ' A1 = b+c (A1 becomes alphanumberic, then number then equal sign)
    'Todo Make sure that it is making the syntax correctly, right now N1 returns ({[Alpha]})  ({[number]}) instead of ({[variable]})
    'from the FileIo Window add the buttons to move to the Symbol or the Option Window.
    'on imported colors, if the name is not a 'standard' then find the one closest, and put it as the default for that color (keeping the name for other systems)
    'make the text different colors for different display option items (Not working yet)
    'todo change the slash for imports into something else (not used in any language), so this they are never confused with any language
    'todo need to check that the /points name is used in the syntax (Also make sure that if a statement is entered, all of the variable names have a /point
    'todo need option to NOT use the clipboard to pass and get data
    'todo change the button rules to not allow adding a /point if there is no point name in the text box name (and if the point name is not in the program text 

    'todo document code with this to make help file????????
    'User-defined types, such as a class or interface
    'Members, such as a field, event, property, function, Or subroutine.
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/c
    '<c>text</c>  
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/code
    '<code> content</code>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/example
    '<example>description</example>  
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/exception
    '<exception cref="member">description</exception>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/include
    '<include file="filename" path="tagpath[@name='id']" />
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/list
    '<list type="type">  
    '    <listheader>
    '   <term> term</term>  
    '   <description> description</description>  
    '    </listheader>  
    '   <item>
    '   <term> term</term>  
    '   <description> description</description>  
    '</item>  
    '</list>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/para
    '<para>content</para>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/param
    '<param name="name">description</param>  
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/permission
    '<permission cref="member">description</permission>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/remarks
    '<remarks>description</remarks>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/returns
    '<returns>description</returns>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/see
    '<see cref="member"/>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/seealso
    '<seealso cref="member"/>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/summary
    '<summary>description</summary>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/typeparam
    '<typeparam name="name">description</typeparam>
    'https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/xmldoc/value
    '<value>property-description</value>
    'todo add option to output Format, colors, datatype, ...
    'TODO ON THE SYMBOL Window THE COMBOBOX'S FOR POINT AND LINE NAMES START AT ZERO FOR THE FIRST ONE, (i AM COUNTING starting at one)
    'todo Symbol Window is not working, it is not getting a symbol by name, and it is adding when each letter is typed.
    'todo the issue is that the selected symbol drop down is not getting filled with the symbol names.
    'todo completely lost the select a symbol on the symbol Window.
    'todo symbol Window selecting a symbol doubles the name in the table.
    'todo need to call button rules after entering text on the symbol screem.to enable that button..
    'todo in finding my bugs, add a check for valid data types (non on start up with flowchart /err=origin......
    'todo symbol Window select symbol button is not updating the Window to the selected symbol information
    'todo Datatype 1 appears 
    'todo need the hints displayed somewhere, somehow.
    'todo add a buttons rule, there there is no input/ouput for the point, theyou can not add a point yet
    'todo need to allow imports via the flowchart Window text box input 
    'fixed the first symbol created from a source file, had camefrom twice, at the begging, and two gotos at the end
    'todo update the spalsh Window with the email 
    'bug check that the " is being replaced?




















    'Doc  ./set=delimiters,{[(,)]}
    'Doc  ./Set=Options,1-32 Turns on this option
    'Doc  ./Set=Scale,625-10000
    'Doc  ./Set=Spacing, 500-2500
    'Doc  ./Set=Dump,/steven/Dump1.txt,/steven/Dump2.txt,/steven/Dump3.txt
    'Doc  ./Set=points,Index,X,Y
    'Doc  ."
    'Symbol does not have a /point CameFrom",
    'Doc  ."1002 Symbol does not have a /point GotoNext",
    'Doc  ."1003 Symbol goes to two or more places (A symbol can come from many places, but can only goto one place)",
    'Doc  ."1004 Points of a symbol is not connected to any path",
    'Doc  ."1005 Paths are not connected to any symbol or constant - they must all connect to both ends to symbol or another path, or a constant",
    'Doc  ."1006 Not all of the point names are in the Syntax",
    'Doc  ."1007 That the Syntax matches the program text.",
    'Doc  ."1008 Make sure that the point names are in the point list",
    'Doc  ."1009 All paths must have at least one output or constant",
    'Doc  ."1010 All Points have a valid Datatype",
    'Doc  ."1011 All Datatype have a valid Color",
    'Doc  ."1012 All Colors are valid (in microsoft, they can only be the assigned colors, and are 'switched if wrong)",
    'Doc  ."1013 All /point names are in either the microcodetext or the Syntax",
    'Doc  ."1014 No Duplicate /point names",
    'Doc  ."1015 No Syntax and No Program Code to make it from"
    ' add /run to import to and from the clip board (then connect toprogram or DLL)
    '   in the /name section erase all of the that data first if a /microcodetext= (and all of the others) if nothing is after the =
    '   The idea is that it will run this probram passing by (clipboard, ...or what ever method agreed on) and returns
    '   pass /Import and return The import for a new symbol (Or to modify a symbol - it can have many symbols in it.
    '   pass /return with
    '   /symbolname= the name of the symbol (given before so that the program will know-make sure that it is returning the right symbol)
    '   /ExportPoint=datatype, ..., value for each point (including the came from and goto parameters)
    '   pass what ever other stuff that is needed
    '   returns /symbolname= symbolname (it can be a new symbolname than passed, because of the parameters passed (ie different data types)
    '   returns /Point..., /line, /value (return value when debugging ...; etc)
    '   returns anything else that can be in a symbol
    'todo  I change "_" for a null to be "```" abd caused the index to over run at places now (Should change it to Nil, or csomething else
    '/ignore=ignores anything here, and does not save it.(Junk)
    '/set=points,which text number, x, Y 
    '/set=delimiters,start of markers,([{ end string of markers}])
    '/set=language,language name, ...
    '/set=options, option message number
    '/set=scale, (625 to 100,000)
    '/set=spacing,spacing between symbols (limits 500-2500)
    '/set=dump, path/filename, path/filename, path/filename
    '/Option=number (1-998) ,  {on or off} 
    '/Option ComputerLanguage
    '/Color=Color Name ,  Alpha ,  Red ,  Green ,  Blue ,  Style ,  StartCap ,  EndCap
    '/datatype=datatypename ,  Number Of Bytes ,  Color Name ,  Color Width ,  Describtion
    '/name=  symbolname, future options
    '/Point = X ,  Y ,  {Input/Output...} ,  datatypename ,  point name
    '/Line=x1 ,  y1 ,  x2 ,  y2 ,  color name
    '/Path=Name ,  x1 ,  y1 ,  x2 ,  y2 ,  datatypename 
    '/Use=Name ,  X ,  Y ,  rotation ,  future options
    '/thiscode
    '/microcodetext=Order, example of program code.
    '/filename=symbol path/filename
    '/Language=language, 
    '/C_L_Comment=" & ComputerLanguageComment)
    '/C_L_VariableNameCharacters=" & ComputerLanguageVariableNameCharacters)
    '/C_L_Extension=" & ComputerLanguageExtension)
    '/C_L_MultiLine=" & ComputerLanguageMultiLine)
    '/stroke=future (ABCDEFGHIJKLMNOP)
    '/notes=notes to follow the symbol, save, not used, a comment about the symbol
    '/version=a string of the symbol being used (optional)
    '/author=who did this symbol
    '/opcode=the maching code for this symbol (optional future)
    '/Constant=name, X,y, Value
    '/error, name, x, y,  Name,  other things maybe
    '/delete={ANY OF THE OTHER CODES}
    '/keyword=computer language Keyword, future syntax
    '/operator=computer language operator, future syntax
    '/function=function name, future syntax
    '/drilldown=name of the previous file that you came from (selecting a symbol, and going to its detail.
    '/finish This is used to communicate with the pre and post process program
    '/FCInit		to clipboard for process program
    '/FCPre		to clipboard for process program
    '/FCPost		to clipboard for process program
    '/FCFinish		to clipboard for process program
    '/syntax= made up of the following strings:
    '   {[(ComputerLanguageMultiLine)]}
    '   {[(ComputerLanguageCameFrom)]}
    '   {[(GotoNext)]}
    '   {[(ComputerLanguageComment)]}
    '   {[(ComputerLanguageExtension)]}
    '   {[(ComputerLanguageMultiLine)]}
    '   {[(ComputerLanguageVariableNameCharacters)]}
    '   {[(CameFrom)]}
    '   {[(GotoNext)]}
    '   {[(Quote)]}
    '   {[(comment)]}
    '   {[(KeyWord)]}
    '   {[(Operator)]}
    '   {[(Function)]}
    '   {[(AlphaNumberic)]}
    '   {[(Alpha)]}
    '   {[(Number)]}
    '   {[(SpecialCharacter)]}
    '   {[(Variable)]}
    '   {[(Unknown)]}
    '   {[(List)]}
    '   {[(expression)]}
    'friend const ConstantDirectionMap As String = " " &
    'vbCrLf & "14_15__16__01_02" &
    'vbCrLf & "13__\__|___/__03" &
    'vbCrLf & "12-----0------04" &
    'vbCrLf & "11__/__|___\__05" &
    'vbCrLf & "10_09__08__07_06"

    '    friend const ConstantExplainCompared As String = vbCrLf & "Compare Results " & vbCrLf & "  -2 Top of the list" & vbCrLf & "  -1 Less than" & vbCrLf & "   0 they match" & vbCrLf & "   1 greater than" & vbCrLf & "   2 bottom of the list"
    'friend const ConstantExplainedCompared3 As String = vbCrLf & "." & vbCrLf & "." & vbCrLf &
    '    "  0 if the middle is null" & vbCrLf &
    '    "  0 if first = third are null" & vbCrLf &
    '    "then -1 if ." & Myfd("string1" ) & ".= ." & Myfd("string2" ) & "." & vbCrLf &
    '    "then  1 if ." & Myfd("string2" ) & ".= ." & Myfd("string3" ) & "." & vbCrLf &
    '    "then -4 if ." & Myfd("string1" ) & ".= Null & ." & Myfd("string2" ) & ".< ." & Myfd("string3" ) & "." & vbCrLf &
    '    "then  4 if ." & Myfd("string3" ) & ".= Null And ." & Myfd("string2" ) & ".> ." & Myfd("string1" ) & "." & vbCrLf &
    '    "then -4 if ." & Myfd("string1" ) & ".= ''" & vbCrLf &
    '    "then  4 if ." & Myfd("string3" ) & ".= ''" & vbCrLf &
    '    "then -5 if ." & Myfd("string1" ) & ".> ." & Myfd("string3" ) & ".(error in list)" & vbCrLf &
    '    "then  0 if ." & Myfd("string1" ) & ".< ." & Myfd("string2" ) & ".& ." & Myfd("string2" ) & ".< ." & Myfd("string3" ) & "." & vbCrLf &
    '    "then -3 if ." & Myfd("string1" ) & ".> ." & Myfd("string2" ) & "." & vbCrLf &
    '    "then -2 if ." & Myfd("string2" ) & ".> ." & Myfd("string3" ) & "." & vbCrLf &
    '    "then  3 if ." & Myfd("string2" ) & ".< ." & Myfd("string3" ) & "." & vbCrLf &
    '    "then  2 if ." & Myfd("string1" ) & ".> .{[(string2" ) & "." & vbCrLf &
    '    "then  5 if none of the above(Error in logic)"






    'known assumptions:
    ' Assume English (should try UTF-16 instead of ascii
    ' Assume that all variables must start with a letter, then letters or numbers or special characters    '
    ' Assume that MakePathOrthogonal adds a record at the end of the table, if not, still no harm? just slower



End Module
