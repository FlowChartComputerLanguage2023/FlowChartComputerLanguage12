

Module NotesBugsEtcNoCode
    'key task list words
    'h ack   		'Still Needs to be Looked at
    't odo   		'Things that I have not programmed yet
    'u ndone 	'Things that might not be working, but I have not checked or fixed.

    'Ones that I am also using now that I have found this. 12-18-2020
    'Done   Items that I have fixed and throught with (maybe again, and again and they keep breaking)
    'Document   This Is something that should be in the documenations somewhere.
    'bug    A bug I have found (But can work around it for now)


    'ToDo List *************************************************
    'todo make the text different colors for different display option items (Not working yet)
    'todo fix bug the /error is being inserted into the wrong symbol (The one before it.)
    'todo kill all dump file ehen you start and also when you import another dump file (delete the old, and also the new)
    'todo bug, it does not add a point to a new symbol (from tutor lesson 5)
    'todo Need a button to save all of the symbols into seperate file (later all that have changed)
    'todo Add /Grid=Symbol grid (default 250), Point Grid (defaul 50), Path grid (default 50), Line grid (default 1)
    'todo change the slash for imports into something else (not used in any language), so this they are never confused with any language
    'todo add /Replace=from text, to text
    'todo make the output code ability to write each section of code then put them all together in order.
    'todo add /order= (Global, routines(Top, code, end))  [ Which means all globals, then the top/code/end of each main)] (, means then next, ( means all symbols connected top-code/end before then next )
    'todo autoroute when you decompile (Make sure that I am getting the name of the variable as the name on the path.
    'todo make sure that there is a format for /set...
    'todo add option to output Format, colors, datatype, ...
    'todo decompile does not connect the paths
    'todo check that the names of the veriables are being used for the path name in decompile
    'Done Getting into loop that blows the stack (somewhere inside the decompile, while cleaning up the links
    'Done add imports to change the locations of the automatic points when decompiling - ImportSymbolPointPreference
    'Done add imports to where each of the points in symbol creation goes.
    'Done Added to imports /Set
    'doc /set=delimiters,{[(,)]}
    'doc /Set=Options,1-32 Turns on this option
    'doc /Set=Scale,625-10000
    'doc /Set=Spacing, 500-2500
    'doc /Set=Dump,/Dump1.txt,/Dump2.txt,/Dump3.txt
    'doc /Set=points,Index,X,Y
    'doc /Set=Language,0,1,2,3,4,5,6,7,8,9,10
    'doc        0 Computer language name
    'doc        1 Case sensitive'IGNORING FOR NOW
    'doc        2 in line comment
    'doc        3 extension 
    'doc        4 Statement on same line
    'doc        5 line-continuation character 
    'doc        6 Additional Characters allowed in Names  
    'doc        7 Goto syntax format rmstart & "(" & myuniverse.sysgen.rmEnd
    'doc        8 CameFrom syntax format (alisa for label, line number, etc) rmstart & ")" & myuniverse.sysgen.rmEnd
    'doc        9 Option number list
    'doc        10 reserved

    'Done It is not selecting or changeing languages on toolstripSelectButton_Click
    'Done strighten up the dump of the information (Add tabs, to make it easier to see inside of excel)
    'Good Enough Add a splash screen (to hide all of the startups. 
    'Good enough If flash screen visible then do not show any other screens as visible  (Still lets FlowChart Screen flash, Cause I donot want to change the startup screeen, cause I'm lazy)
    'done The Functions/Operators/Keywords are not inputing correctly 
    'done need to start with a scale 2 or 3 times zoomed out (changed to be .0625 or zoomed in 16 times)
    'todo (needs to be checked) see about not letting the buttons be clicked twice 
    '      do not let more than two or three work at the same time! because it overflows the stack)
    'Done turn the default for output line number option off
    'Done FIX it only outputs one /function, /operator, /keyword
    'todo check that it is writting out all of the op[tions.
    'todo Write all of the set options
    'todo it did Not output /options
    'Done donot output  anything starting with zzzzzzzzz(Or maybe ZZZZZZZZZZ)
    'done donot output symbol zzzzzzzzzSymbol
    'todo /error is not being put in the symbol that caused it to have an error.
    'todo on save file, it should have the extension of the language type, instead of .source or .src    'ToDo Change Sort to be a Insert Sort
    'todo Add to the options list : Auto Path Datatype to Point Datatype
    'todo Add to the options list : auto complete paths
    'todo Add to the options list : auto route paths
    'todo Add to the options list : auto move symbols
    'todo Add to the options list : auto flip symbols
    ' DOC
    'DOC in the symbol screen, you can only add points and lines after you have first got a symname.
    'Done Need a status bar showing progress of the fileio
    'Done The selected symbol is no longer showing in the symbol text box in symbol screen

    'Done on the startup of the option screen, no button should be enabled until a language is selected.
    'done The add point and add line is not working in the symbol screen (First thing )
    'todo it is not redrawing when you add a point in the symbol screen
    'toto make newsymbol button have color (to be able to show when it's disabled)
    'Done on the flowchartscreen make the add line in color to show when it's disabled
    'Done on the symbol screen make the line/point width/size in color to show when it's disabled
    'Done on the symbol screen make the start and stop line colored  
    'Done button rules on the symbol screen if there is nothing in the symbolname then disable buttons and dropdowns
    'DONE need to add new rule s if the buttons are available or not
    'done symbol screen add point button			Must have symbol displayed, and a point on the list with a name (make a default name to begin with for now, and all options selected with default
    'Done symbol screen add line button			Must have a symbol displayed, color, width
    'Done symbol screen Move object button			must have an point,line
    'Done symbol screen Delete button			must have a point line
    'Done symbol screen New Symbol button			Must have a new Symbol Name
    'Done symbol screen update symbol button			Must have made changes to the symbol
    'Done symbol screen Symbol select dropdown 		
    'Done symbol screen button
    'Done symbol screen button
    'Done it duplicates the symbol name when you tab off from changing the symbol name (instead of adding new symbol)
    'Done add some color to the fileio icons
    'todo 'bug : Show FlowChart	- has to double click to get button to work the first time on the option screen
    'Done Show Symbol Screen
    'Done check FlowChart Screen starting up:
    'Done Show Symbol Screen startup 
    'Done Show Options Screen
    'Done Show FileInputOutput Screen
    'todo Need to add expressions (variable/constant (then optional) [operator expression] , and list variable/constant (then optional) [ "," list]  
    ' make two kinds of variables, one is one one 
    ' Ideas (make the name of the point an expression), 
    '       (make all variables into expandable options by adding an operator to an point (new button to add it to a point)
    '   Add List and Expressions to Syntax
    'Done  make a checklist of QC on what to check (and check steps along the way. of how to check)
    'ToDo  Write a quick tutorial to start using 
    'ToDo  Write a book on FlowChart Computer Language (trademark, and register)
    'ToDo  Error - All pen objects can not be assigned values (startcap, endcap, style, ...)
    'ToDo   The toolstrip drop down will switch screens because I am setting the text from the symbol to the flowchart screen, (Needs a workaround)
    'ToDo   ALSO it does not let me select from the drop down.
    'ToDo   Make sure that drillUP gets the name of the last file opened.
    'ToDo   Make sure that drillDOWN gets the name of the Current file opened.
    'ToDo   the FILE IO screen 1. buttons needs to be hit twice to work, 2. the files with the right extensions are not displayed
    'ToDo   Check that all of the buttons work (After changing them from buttons to toolstripbuttons, and toolstripdrop downs)
    'ToDo   on the flowchart screen pressing to show the symbol screen, the message is adding a symbol to the flowchart
    'ToDo   Needs to pre-set defaults in the options screen for input/output, width, #bytes (Color drop down, and DataType drop down)'ToDo   The Show FlowChart button in the options screen does not take you to the FlowChart
    'ToDo   The select symbol in the FlowChart screen does not work
    'ToDo   Changeing the computer language needs to have program status updated
    'ToDo   The button to select a symbol in the symbol screen does not get the symbol data
    'ToDo   in the options screen , button deelte unused symbol toool tip is wrong
    'ToDo   need a subroutine to enable or disable the function buttons (IE can not select a symbol , if there are no symbols
    'ToDo   bug in decompile, it will put in the /use symbol twice (with paths)
    'ToDo   Bug in counting the atom after it is being parsed, it is done twice, both different from each other.
    'ToDo   Need to add the datatypes and colors to the dropdowns on FlowChartScreen (maybe remove them from the symbols form.
    'ToDo   need to start to chack all of the buttons to make sure they work
    'ToDo   need to write the auto router to run on the added symbols from compileline()
    'ToDo   Need to add to Expresion, List, optional
    'ToDo   all symbols must have one /point name 'CameFrom' and one /point 'GotoNextLine'  {Even if not uses such as start and end/return}
    'ToDo   If not then must have the program add those to the symbol???????? (Yes for now)
    'ToDo   AND leave an error message that we did that.
    'ToDo   need to make the points automatically from the names on the symbol screen
    'ToDo   The variable names are not getting to the paths (and/or to the point names)
    'ToDo   The /use links are not correctly getting the value of the [variable(s)]  ??.value =
    'ToDo   The /use links are not getting the variable name correctly (uses constantvariable etc)
    'ToDo   The /use is getting between the quotes
    'ToDo   The FlowChartdump show multiply symbols with the same name 
    'ToDo   The output show functions with ==COS, and multiply times.
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
    'ToDo   the NEW paths are not where the symbols are.  NEED to CHECK them when they are made to make sure they are all aligned
    'ToDo   added checkpathconnected() to make sure that a path is connected to another Path or connected to a symbol point
    'ToDo   Lowest abug(739
    'ToDo   The paths made might not be at the symbol points, (ie 100 or more off)
    'ToDo   must add a timer to move/check paths and also move/check symbols, are not on top of each other.
    'ToDo   path making rule A. must have symbol with only two points above and below each other.
    'ToDo   MUST FIX THE NEXT ONE TO FIND THE PROBLEM OF TWO NAMES
    'ToDo   The /name is getting into the table twice
    'ToDo   Making points in the symbol creation of keywords (it should not do that)
    'ToDo   Need to allow expresion to happen, that just grows the points and operators along on e of the 16 directions that is available now.
    'ToDo  1. The path names should be the name of the decomplie variable . 
    'ToDo  2. The names of the files need to com from or also add the languages being used, and to whate is there now.  
    'ToDo   Change the location of added points for decompile to a table 2020 07 26 (Which is puting them close but needs it done better.
    'ToDo   Added checkboxes for all of the languages (and a few move for the future )
    'ToDo   2020 07 25 started to add language specific information to the program
    'ToDo   added CR LF and TAB as special character in ThisIsASpecial() 2020 07 25
    'ToDo   need to have an option for usery1 > ???? to allow longer/bigger FlowCharts 
    'ToDo   rewrote the makeitbigger() to use the file_counter and then but a makitbigger in each topoffile call
    'ToDo   I made a bug when I took out a bunch of ByRef'ToDo  s keywords. 
    'todo connect the point/line lists up to be able to change the information about a point make sure that If a point name is changed then also change that information in the /point and also in the program code (What problems that could cause!!
    'todo the points and lines need to ba editable/changable from the symbol screen
    'ToDo   Need to add import & options for: What special characters are allowed in a variable name)
    'ToDo                                     What special characters are allowed in a variable name
    'ToDo                                     what is the field seperator for input files (and import option
    'ToDo                                     Changing the error message text (and maybe the level?)
    'ToDo   Need to output all of the parameters into the export file
    'ToDo     CheckBox-, -X, -Y
    'ToDo         DisplaySymbolName
    'ToDo         DisplayPointNames
    'ToDo         Constants
    'ToDo         Names
    'ToDo         ErrorText
    'ToDo         Reserved99
    'ToDo         InputOutPu
    'ToDo         IDStroke
    'ToDo         FileName
    'ToDo         AutoConnect
    'ToDo         Notes
    'ToDo         Opcode
    'ToDo         IndexShortCutPointer
    'ToDo         CodeOrthogonalPaths
    'ToDo         MakePathsSnapToPoints
    'ToDo         AutoMoveSymbols
    'ToDo         Reserved1
    'ToDo         Reserved2
    'ToDo         OutPutLineNumbers
    'ToDo         ShowPathNames


    'ToDo  Checking buttons:

    'ToDo  Options Screen:
    'ToDo  	Show FlowChart	
    'ToDo  	Show Symbol Screen
    'ToDo  	Delete Error Messages
    'ToDo  	Delete Unused Symbols
    'ToDo  	Dump data into \...
    'ToDo  FlowChart Screen:
    'ToDo  	Show Symbol Screen
    'ToDo  	Show Options Screen
    'ToDo  	Show FileInputOutput Screen
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
    'ToDo  Symbol Screen
    'ToDo  	Show FlowChart Screen
    'ToDo  	Show Options Screen
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
    'ToDo   during decompile it does not display the symbols on the FlowChartScreen screen while it is working.  
    'ToDo   The parsed() is not correctly telling the syntax of the program text (problems with 1. 2.)
    'ToDo   not able to add points or lines now. (They do not show up)
    'ToDo   Need to be able to name points (Or add them (from the program text[]) and let them only be moved and not added?????)
    'ToDo   need to check that datatypes or line colors are selected first before adding them
    'ToDo   Changed around SymbolScreen and made the picture bigger.
    'ToDo   Does not draw the symbol on SymbolScreen when active
    'ToDo   Changed MyInsertSymbol() to have the index where to insert it at 2020 07 18 (Mistake on my part, opps)
    'ToDo   copy2screen???  on SymbolScreen only changes it to -500,-500 instead of the actural conversion
    'ToDo   Compileing is finding the closest to the symbol instead of the closest to the point of the symbol.
    'ToDo  x Bug is that the name of the symbol is used instead of the name of the point in compile()
    'ToDo   Invalid message of path goes nowhere on symbols.
    'ToDo  BUG The Symbol Points are no longer where they should be.
    'ToDo   The symbol screen selects the wrong symbol (the one below the one selected)
    'ToDo   SymbolScreen needs heading above the four dropdowns
    'ToDo   Inserting symbol(s) graphics in the endinstead of inserting them where they belong!!!!!!
    'ToDo   The arrors for the points are not the correct color for the data type.
    'ToDo   datatypes are not getting sorted before exporting
    'ToDo   does not overwrite the /programtext created by this program. (Should I even Have it, and do I have to have it?)
    'ToDo   need to output /color /datatype X/keywords all in order 
    'ToDo   missing flip-flop and options in the /use
    'ToDo   not outputing last /path
    'ToDo   path names switched to be first!! (So what is the new last item? suppost to be now ( I forgot))
    'ToDo   missing the options on save'ToDo  s
    'ToDo   MISSING /POINT IN SAVE'ToDo  S
    'ToDo   output the symbol name in the point now (Does not need it?!)
    'ToDo   does not save the /keywords
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
    'ToDo   Need to add the level of debug showing to OptionScreen
    'ToDo   Added combo boxs on form 3, and they are getting duplicated.
    'ToDo   document the import/export files formats and options.
    'ToDo   Export no longet outputs correctly, and all ENUMS are output as numbers, not the text they represent.
    'ToDo   Need to change it so that any /USE with the symbol only having a goto (and no CameFrom) is used instead of the 'ToDo  start'ToDo   symbol
    'ToDo   Need to add a disply of the visual stroke movements in SymbolScreen (symbol)
    'ToDo   Need to not show FlowChartScreen when importing (only OptionScreen) then switch back
    'ToDo   Need to add findFirstXY() to speed up checking 
    'ToDo   Change all of my constants to be on OptionScreen as variables
    'ToDo   On OptionScreen add a list of the points and text boxes of what they stand for. (Like the other combo boxes)
    'ToDo   I have paths at 1000, -20000 but it will not draw or show below Y = 0 (About)
    'ToDo  Need to go through from a started file making everythink for a demo (writting down the steps, to show how its done)
    'ToDo   CHECK EACH OF THE FOLLOWING ROUTINES IF THEY NEED TO BE RUN AND ARE TAKING TO LONG'ToDo  
    'ToDo   MyCompared3                              ran 14446 times
    'ToDo   InvalidIndex                             ran 8450 times
    'ToDo   MyMakeArraySizesBigger                   ran 3567 times
    'ToDo   Pop                                      ran 3217 times
    'ToDo   DataType_TableName                       ran 2926 times
    'ToDo   MyCompared1                              ran 2024 times
    'ToDo   MyEnumValue                              ran 1869 times
    'ToDo   FileCounter                              ran 1694 times
    'ToDo   FileCounter                              ran 1694 times
    'ToDo   Color_TableName                          ran 1590 times
    'ToDo   MyUnEnum                                 ran 1455 times
    'ToDo   WhatComputerLanguage                     ran 1443 times
    'ToDo   TopOfFile                                ran 1390 times
    'ToDo  ======================================================================
    'ToDo  Phase two, 
    'ToDo         Need to make a Screen layout (And page layout)
    'ToDo         Needd to make symbols that are controlable
    'ToDo     on SymbolScreen:
    'ToDo         disable add point if: 1, datatype not check , number of bytes, size of line
    'ToDo         disable add line if : 1, color not selected.
    'ToDo         if a color is selected then clear the datatype, and the add button
    'ToDo         disable the add point and line if the number of bytes or line width is not filled in (IE: non zero)
    'ToDo   Need to add in /#program text the ability to test for conditions
    'ToDo  
    'ToDo  Phase Three, need to decompile from any source into a FlowChart (Minor advancement 2020 07 14)
    'ToDo         (Making it automatic to a FlowChart from a language source program) ditto
    'ToDo         Using the symbols /programtext to decompile into ditto
    'ToDo  Screen still does not show ALL of the FlowChart on the top and left.
    'ToDo  Paths have no width showing (Should be a min of ...
    'ToDo   Need to have an option for the path to snap to the closes point that matches the same datatype (ie logic to logic, integer to integer, real to real AX to AX, Eb to Eb  etc)
    'ToDo  Need to Add to make sure that every /name in symbols has a name in Named_file also
    'ToDo  Need to remove unused symboles from lib
    'ToDo  need to add symbols only from other files (import NEW symbols only from file)
    'ToDo  Need to be able to creat new symbols
    'ToDo   need to add /stroke to let users id symbols without naming them
    'ToDo   Unable to change the font size in MyDrawText(), Need to change it so that the size of the letters are changeable
    'ToDo   Need to have drilldown() only work on a selected symbol()
    'ToDo     then needs to add auto rount (around ever thing that is already there)
    'ToDo   need allow the Numberal options of:
    'ToDo   	Grid Snap (10/19/18 added, a c heck box, but not change the amount)
    'ToDo  	In C heck, the direction to move symbols (and paths) on top of each other.
    'ToDo   Need to c heck for paths ontop of each other.
    'ToDo   need to set the focus back to the text boxes after pushing a button (and making the button 'ToDo  show pushed'ToDo  
    'ToDo   C heck if an error message ready exist at that XY
    'ToDo   Button in options to delete all Error messages on the screen
    'ToDo   Change Error messages to 'pictures' of what;'s wrong.'
    'ToDo   Add an /Include Filename.ext (to recursively call import)
    'ToDo   Does not allow colors other than those with the name pens.color (Which I put into init( ))
    'ToDo   Does not allow to edit the color or datatype support files.
    '
    'ToDo need to have the select symbol dropdown be a tree - select each letter until you get to the end, or a form with all of the symbol pictures displayed
    '
    ' Added
    ' Added error messages if problem of not enough data in the import file.
    ' Option to not move symbols in when c hecking (and fixing)
    ' To speed things up, make 4 iSAM MyArrays for the FlowChart (for pointers to the X1, Y1, X2, Y2, then sort those MyArrays) To help find the Inswx to XY's fast er 10/22/2018
    ' Add /Author & Version Date for symbols 10/31/2018
    'only export if there is data (If not isnothing() then don't)
    '
    ' Fixed
    ' Need to have a resort, which will only sort the last addedd item in the sorted file. *10/`/18
    ' Need to create a file when trying to write/export 10/15/18
    ' Need to add back in the color names in the Color file 10/15/18
    ' need to add buttons on SymbolScreen (to work on Symbolfile) just like FlowChartScreen (That works on the FlowChart file) 10/15/18
    ' Neded to add a listbox of colors, and datatypes 10/15/18
    ' delete button in SymbolScreen - seems to delete the whole symbol, not a line or point 10/18/18
    ' need to add the commands Add path, symbol, line, point . . . constant
    ' Need to get constant value from input line, and add constant
    ' Need to make move symbol also move the connected points of paths (each point of the symbol's xy moved ALL paths Points)
    ' Needs to limit the symbol size (constant for now -constantSymbolCenter to constantSymbolCenter) 10/18/18
    ' Delete a point in symbols will delete all of the other information in Nmaed. 10/19/18
    ' Need to allow editing of all symbol points (Data Type , Input/output)? Nope, Can delete and add faster
    ' Need to edit Symbol information: 10/19/18
    '	NEW Symbol Name, 
    '	Filename (to get/save to), 
    '	Opcode?, 
    '	Notes, 
    '	Language used, 
    '	Stroke used
    ' needs to add orthanganol option 10/19/18
    'Need to name points (Currently defaults to DataTypeName) 10/22/18 (Changed the datafile also)
    'Need to have OptionScreen full screen
    'Corrected Snap from xy/50 to (xy-(50/2))/50 so that it snaps on the closest grid 10/31/2018
    'Get rid of the constant..... rewrite enum() and unenum()... and get over ride information from a file. 11/12/2018
    'Write in a method of debugging everything in steps of testing. 11/12/2018
    ' expresion <=- variable
    ' expresion <=- variable {operator} expresion 
    ' expresion <=- variable {operator} ( expresion )
    ' expresion <=- ( expresion )
    ' expresion <=- ( expresion ) {operator} variable
    ' expresion <=- expresion {operator} expresion
    'todo Put back in the expired date.
    '************ Finished *******************************************************************************************

    ' #Const MyDug = "on"
    ' #If MyDebug = "on"
    ' #elseif
    ' #else
    ' #End If
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
    'ToDo   QC This: fixed 2020 08 26 The arrows of symbols are not pointing the correct direction.  Need to check it in 
    'ToDo   QC This: 20200714 Fixed Its no longer drawing the symbols, because the named_pointer () is not pointing to the right place anymore. (since I took it out of the redraw to speed things up)
    'ToDo   QC This: 2020 06 29 change to NOT have sym_Files... have an index (Since the pointer has to come from the Names_FilesPointer())
    'ToDo   QC This:  Added FindingMyBugs(), Abug(,) a lot of places 'ToDo   QC This: 20200625-2020?? ??
    'ToDo   QC This:  FIXED Data problem -  THE /LINE COLORS CAME OUT ALL THE SAME (AT LEAST FOR THE sTART AND END)
    'ToDo   QC This:  DONE Trying to get horz and virt scroll bars to show up (at least - first)
    'ToDo   QC This:  fixed? Error the name of the point is going into the datatype
    'ToDo   QC This:  fixed? Make sure that all of the index' s is pointing to the correct file/table
    'ToDo   QC This:  fixed? The Data Type is not working!!!
    'ToDo   QC This: 3/12/19 Added "EXTRA" to any code that I think should not be there, because I put it in to find errors, or avoid other errors
    'ToDo   QC This: 4/12/19 Some where the iSAM is being duplicated, so that there is two with the number number after sorting
    'ToDo   QC This:  Changed all of the bubble sort to quick sort. (Changed it all back because of so many problems with it)
    'ToDo   QC This: problems with always sorting when it shouldn't 
    'ToDo   QC This: sorted wrong, And cant find it in the list (When I step through the list I find it)
    'ToDo   QC This:  Need to see that the sort is ALWAYS working
    'ToDo   QC This: Add in /Options=
    'ToDo   QC This:  /option=50,{on,off}       turn on and off stuff that will crash the program
    'ToDo   QC This:  /option=51,on         turn on everything messages, and displays
    'ToDo   QC This:  /option=52,on         turn off all display messages
    'ToDo   QC This:  /option=53,off        Turn off all information messages
    'ToDo   QC This:  /option=54,off        Turn off all Warning messages
    'ToDo   QC This:  /option=55,off        turn off all wrong messages
    'ToDo   QC This: add in /colors linetypes and linestyles support file 
    'ToDo   QC This:  need to allow input of the offset for text displaying of a symbols code/notes/etc
    'ToDo   QC This:  Need to see why it is taking so much time now? to redisplay
    'ToDo   QC This: Add in /Rotation file (And all ofther files besides color and datatype)
    'ToDo   QC This: I should stop sorting the symbols, and replace them with an iSAM MyArray of pointers that is sorted to the MyArrays
    'ToDo   QC This: Change it so that input and output files are source code files with comments for the FlowChart information
    'ToDo   QC This:  I have lost all of the lines of symbols. (because of the pointers from Named_tablepointer() being wrong 20200714)
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
    'ToDo   QC This:  Should select one from the list. (Or make up your own libararys)
    'ToDo   QC This:  {} is optional input and can be ignored, or not entered.
    'ToDo   QC This:  /Stroke={}
    'ToDo   QC This:  /Notes={}
    'ToDo   QC This:  /Version={}
    'ToDo   QC This:  /Author={}
    'ToDo   QC This:  /OpCode={}
    ' 
    'ToDo   QC This:  Path names will be over written if named 'noname' or two differant names are in the same path.
    'ToDo   QC This:  Rotation options are:
    'ToDo   QC This:        Default, Flip, Flop, Rotate90, Rotate180, Rotate270, FlipRotate90, FlipRotate180, FlipRotate270, FlopRotate90, FlopRotate180, FlopRotate270, FlipFlop
    'ToDo   QC This: 	flip is side to side exchange
    'ToDo   QC This: 	flop is top and bottom exchange
    'ToDo   QC This: 	FlipFlop is the same as rotate180
    'ToDo   QC This:  /Path=x1, y1, x2, y2, Data type, Name
    'ToDo   QC This:  /Use=X, Y, rotation, Name
    'ToDo   QC This:  /Constant=Name, X, Y,  Value
    'ToDo   QC This:  /programtext= Text [replacements] text ...

    'ToDo   QC This:  example
    'ToDo   QC This:  /name Start
    'ToDo   QC This:  /Point=0,250,OutPut,GOTO,Logic
    'ToDo   QC This:  /Point=250,0,output,CommandLine,String
    'ToDo   QC This:  /programtext=main, Jump [GOTO]
    'ToDo   QC This:  /programtext=main, CmdLine: [CommandLine]
    'ToDo   QC This:  /programtext=main, ;This Is The Start of The Program
    'ToDo   QC This:  /Use=X, Y, rotation, Name

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
    'ToDo   QC This: Limits symbol=(-250,-250)-(250,250)
    'ToDo   QC This: Limits symbol points 121
    'ToDo   QC This:  Need to get rid of the radio buttons, and replace it with a DropDown with the parameters
    'ToDo   QC This:  It is not matching correctly symbols already defined syntax match.
    'ToDo   QC This:  Need index on syntax() to make it faster to find
    'ToDo   QC This:  (fixed) The saved file has _ in the path name, but no where in the data during input/output
    'ToDo   QC This:  Export() /name=,= fixed 2020 07 28
    'ToDo   QC This:  Need to add /Function and /Operators= (and act like keywords for now)
    'ToDo   QC This:  need to add ThisisanOperator() for +-/* and functions ABS, Sin, COS etc (Just line keywords, but in a different file.
    'ToDo   QC This:  Character set over 128
    'ToDo   QC This: Bug recursive resort runs out of memory(stack)2020 09 20
    'ToDo   QC This: Need to add the type ([{Label}]) instead of variable for after gotos
    'ToDo   QC This: need to change the syntax to be [point.name] format
    'ToDo   QC This: Dump the Trace also with a dump 
    'ToDo   QC This: replacing [ with ([{ and so on........
    'ToDo   QC This:  Need to update the /language options if they are on the line
    'ToDo   QC This:  Need to add fields to change the computer language definations.
    'ToDo   QC This:  Need to be able to input each of the languages fields via inports 'ToDo   QC This: /language='ToDo   QC This: 
    'ToDo   QC This: The status text line on symbolscreen is to high and covered by the buttons 12-11-2020
    'ToDo   QC This:  on the options screen when it first comes up, need to set defaults
    'ToDo   QC This:  also needs to have the pathstart, end, rotation, ... set
    'ToDo   QC This: FlowChart screen Select Symbol is a button, and should be a dropdown
    'ToDo   QC This:  File i/o screen needs tip text set
    'ToDo   QC This:  reformated the trace output in dump()
    'ToDo   QC This:  FlowChart screen the program status is stuck behind the toolstrip
    'ToDo   QC This: Changed orginal stat to be Max (and then never changes it, lets the user change it - Except FileInputOutput should always be normalized)
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
    'ToDo   QC This: Bug: When the Symbol screen first comes up, the program status Text Box is in the wrong place, (after any resize, it corrects itself)
    'ToDo   QC This:  Fixed above (And other things), by making everything inside a toolstrip....12-16-2020  After I lost everthing from flowchart004 and made flowchart10 (three digit to two digit versions now (Major and Minor)
    'ToDo   QC This:  The flowchart screen no longer appears after the options screen
    'Done : No selection on the line/widths on the option screen
    'Done check Options Screen starting up:



    'fixed bugs and todo list
    'fixed 2020 08 26 The arrows of symbols are not pointing the correct direction.  Need to check it in 
    '20200714 Fixed Its no longer drawing the symbols, because the named_Indexes () is not pointing to the right place anymore. (since I took it out of the redraw to speed things up)
    '2020 06 29 change to NOT have sym_Files... have an index (Since the Indexes has to come from the Names_FilesIndexes())
    ' Added FindingMyBugs(), Abug(,) a lot of places '20200625-2020?? ??
    ' FIXED Data problem -  THE /LINE COLORS CAME OUT ALL THE SAME (AT LEAST FOR THE sTART AND END)
    ' DONE Trying to get horz and virt scroll bars to show up (at least - first)
    ' fixed? Error the name of the point is going into the datatype
    ' fixed? Make sure that all of the index' s is pointing to the correct file/table
    ' fixed? The Data Type is not working!!!
    '3/12/19 Added "EXTRA" to any code that I think should not be there, because I put it in to find errors, or avoid other errors
    '4/12/19 Some where the iSAM is being duplicated, so that there is two with the number number after sorting
    ' Changed all of the bubble sort to quick sort. (Changed it all back because of so many problems with it)
    'problems with always sorting when it shouldn't 
    'sorted wrong, And cant find it in the list (When I step through the list I find it)
    ' Need to see that the sort is ALWAYS working
    'Add in /Options=
    ' /option=50,{on,off}       turn on and off stuff that will crash the program
    ' /option=51,on         turn on everything messages, and displays
    ' /option=52,on         turn off all display messages
    ' /option=53,off        Turn off all information messages
    ' /option=54,off        Turn off all Warning messages
    ' /option=55,off        turn off all wrong messages
    'add in /colors linetypes and linestyles support file 
    ' need to allow input of the offset for text displaying of a symbols code/notes/etc
    ' Need to see why it is taking so much time now? to redisplay
    'Add in /Rotation file (And all ofther files besides color and datatype)
    'I should stop sorting the symbols, and replace them with an iSAM MyArray of Indexess that is sorted to the MyArrays
    'Change it so that input and output files are source code files with comments for the FlowChart information
    ' I have lost all of the lines of symbols. (because of the Indexess from Named_tableIndexes() being wrong 20200714)
    ' The colors of lines are not yet displayeed *10/9/18 They disappeared again
    'Lost all lines in symbols.
    'Need to also rotate symbols
    'Add to input file /Options=name of option, value to set to  (Only some options, and all of the error/information messages)
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
    ' Should select one from the list. (Or make up your own libararys)
    ' {} is optional input and can be ignored, or not entered.
    ' /Stroke={}
    ' /Notes={}
    ' /Version={}
    ' /Author={}
    ' /OpCode={}
    ' 
    ' Path names will be over written if named 'noname' or two differant names are in the same path.
    ' Rotation options are:
    '       Default, Flip, Flop, Rotate90, Rotate180, Rotate270, FlipRotate90, FlipRotate180, FlipRotate270, FlopRotate90, FlopRotate180, FlopRotate270, FlipFlop
    '	flip is side to side exchange
    '	flop is top and bottom exchange
    '	FlipFlop is the same as rotate180
    ' /Path=x1, y1, x2, y2, Data type, Name
    ' /Use=X, Y, rotation, Name
    ' /Constant=Name, X, Y,  Value
    ' /programtext= Text [replacements] text ...

    ' example
    ' /name Start
    ' /Point=0,250,OutPut,GOTO,Logic
    ' /Point=250,0,output,CommandLine,String
    ' /programtext=main, Jump [GOTO]
    ' /programtext=main, CmdLine: [CommandLine]
    ' /programtext=main, ;This Is The Start of The Program
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
    'Limits symbol=(-250,-250)-(250,250)
    'Limits symbol points 121
    ' Need to get rid of the radio buttons, and replace it with a combobox with the parameters
    ' It is not matching correctly symbols already defined syntax match.
    ' Need index on syntax() to make it faster to find
    ' (fixed) The saved file has _ in the path name, but no where in the data during input/output
    ' Export() /name=,= fixed 2020 07 28
    ' Need to add /Function and /Operators= (and act like keywords for now)
    ' need to add ThisisanOperator() for +-/* and functions ABS, Sin, COS etc (Just line keywords, but in a different file.
    ' Character set over 128
    'Bug recursive resort runs out of memory(stack)2020 09 20
    'Need to add the type ([{Label}]) instead of variable for after gotos
    'need to change the syntax to be [point.name] format
    'Dump the Trace also with a dump 
    'replacing [ with ([{ and so on........
    ' Need to update the /language options if they are on the line
    ' Need to add fields to change the computer language definations.
    ' Need to be able to input each of the languages fields via inports '/language='
    'The status text line on symbolscreen is to high and covered by the buttons 12-11-2020
    ' on the options screen when it first comes up, need to set defaults
    ' also needs to have the pathstart, end, rotation, ... set
    'FlowChart screen Select Symbol is a button, and should be a dropdown
    ' File i/o screen needs tip text set
    ' reformated the trace output in dump()
    ' FlowChart screen the program status is stuck behind the toolstrip
    'Changed orginal stat to be Max (and then never changes it, lets the user change it - Except FileIO should always be normalized)

End Module
