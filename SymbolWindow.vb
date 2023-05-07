
Option Strict On
Option Explicit On
Option Infer Off
Option Compare Text
#Const MyDebug = 50


'todo bugs it does not save a new symbol 


Public Class SymbolWindow
    Friend Const ShowWindow As Int32 = 1
    Friend Const HideWindow As Int32 = 0


    Private Sub SymbolWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Const ButtonStartedName As String = "Symbol Window Resize"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 98 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(48, ButtonStartedName)
        End If
        'MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        ResizeMe()
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1) 'todo Check that this should redraw the Window????????
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        'MyFlowChartNameSpace.F_C.MSG_Ainfo(2363, MyFlowChartNameSpace.F_C.MyShowPicture(True, Me.PictureBox1), "", "")
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Const ButtonStartedName As String = "Symbol Window Mouse Down "
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(49, ButtonStartedName & e.X.ToString & "," & e.Y.ToString)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseDown"
        MyFlowChartNameSpace.F_C.MyMouseDown(e) 'Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        'Dim Temp As Int32
        Const ButtonStartedName As String = "Symbol Window Mouse Up "
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(50, ButtonStartedName & e.X.ToString & "," & e.Y.ToString)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseUp"
        MyFlowChartNameSpace.F_C.MyMouseUp(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.MyDoEvents()
        'Temp = MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantSymbolCenter '+ MyFlowChartNameSpace.F_C..myuniverse.SysGen.Constants.constantSymbolCenter
        If Me.ToolStripDropDownSelectSymbol.ToString = "" Then
            MyFlowChartNameSpace.F_C.MSG_Abug(2007, "Symbol Name is not select ? ", "What Goes Here?", "")
        Else
            MyFlowChartNameSpace.F_C.PaintEach(Me.PictureBox1,
     MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.ZeroZero,'MyFlowChartNameSpace.F_C.MyPoint1XY(Temp, Temp),
     Me.ToolStripDropDownSelectSymbol.ToString,'flow10'Me.ToolStripDropDownSelectSymbol.ToString,
     "default")
        End If

        'clear out the symbol and then fill it up
        MyFlowChartNameSpace.F_C.ClearSymbolDisplay()

        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Const ButtonStartedName As String = "Symbol Window   Mouse Movement"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(51, ButtonStartedName & e.X.ToString & "," & e.Y.ToString)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseMove"
        MyFlowChartNameSpace.F_C.MyMouseMove(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        'MyFlowChartNameSpace.F_C.DisplayStatus(me.labelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ComboBoxColor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = "Symbol Window Color Index Changed"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(52, ButtonStartedName & Me.ToolStripDropDownButtonColor.Name & " = " & e.ToString)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ChangeOptionsWindowSelectedIndex("Color", Me.ToolStripDropDownButtonColor, sender.ToString)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ComboBoxDataType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim DataTypeName As String
        Dim I As Int32
        Const ButtonStartedName As String = "Symbol Window Data Type index changed."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(53, ButtonStartedName & " to " & Me.ToolStripDropDownDataType.Text)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub

        'todo Possible Error
        'todo Double check that I want the data type to be a color name
        'todo Put here the drop dows of items that can be changed for this Data type
        DataTypeName = Me.ToolStripDropDownButtonColor.Text

        I = MyFlowChartNameSpace.F_C.FindiSAM_IN_Table("DataType", "DoNotAdd" _
         , MyFlowChartNameSpace.F_C.DataType_FileName _
         , MyFlowChartNameSpace.F_C.DataType_Name_iSAM _
         , DataTypeName)
        If I = -1 Then
            Exit Sub
        End If
        'show (to allow updating)
        Me.TextBoxNamedDescription.Text = MyFlowChartNameSpace.F_C.DataType_TableDescribtion(I)
        Me.ToolStripDropDownNumberOfBytes.Text = MyFlowChartNameSpace.F_C.DataType_TableNumberOfBytes(I)


        'ERROR ???
        'Should this look up the name of the color?
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedColor = Str(MyFlowChartNameSpace.F_C.DataType_TableColorIndex(I))

        Me.ToolStripDropDownLineWidth.Text = MyFlowChartNameSpace.F_C.DataType_TableWidth(I).ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ComboBoxDataType_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        Dim Temp As Int32
        Const ButtonStartedName As String = "Symbol Window  DataType Index changed."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(54, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Temp = MyFlowChartNameSpace.F_C.FindIndexIniSAMTable("Datatype",
                 "Donotadd",
                 MyFlowChartNameSpace.F_C.DataType_FileName,
                 MyFlowChartNameSpace.F_C.DataType_Name_iSAM,
                 Me.ToolStripDropDownButtonColor.Text)

        Me.TextBoxNamedDescription.Text = MyFlowChartNameSpace.F_C.DataType_TableDescribtion(Temp)
        Me.ToolStripDropDownButtonColor.Text = MyFlowChartNameSpace.F_C.Color_TableName(MyFlowChartNameSpace.F_C.DataType_TableColorIndex(Temp))

        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedColor = Me.ToolStripDropDownButtonColor.Text

        Me.ToolStripDropDownInputOutput.Text = "both" ' Just to make it something
        Me.ToolStripDropDownNumberOfBytes.Text = MyFlowChartNameSpace.F_C.DataType_TableNumberOfBytes(Temp)
        Me.ToolStripDropDownLineWidth.Text = MyFlowChartNameSpace.F_C.DataType_TableWidth(Temp).ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Const ButtonStartedName As String = "Symbol Window  Timer Ticked."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(55, ButtonStartedName & " = " & e.ToString)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.TimerTicked(sender, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxProgramText_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedProgramText.TextChanged
        Dim Temp(256) As String
        Const ButtonStartedName As String = "Symbol Window  Making New Syntax from change in program code."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(56, ButtonStartedName & vbCrLf & Me.TextBoxNamedProgramText.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.TextBoxNamedProgramText.Text = " Program Macro Code" Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)

        MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.Path_Names = MyFlowChartNameSpace.F_C.MyParse(Temp, Me.TextBoxNamedProgramText.Text)
        MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.Path_NamesCounted = MyFlowChartNameSpace.F_C.CountPathNames(MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.Path_Names)
        Me.TextBoxNamedSyntax.Text = MyFlowChartNameSpace.F_C.MakeStatementSintax(Temp)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = "Symbol Window  Displaying FlowChart."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(57, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowWindow, HideWindow, HideWindow, HideWindow)
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdaddsymbol" ' Always Go to Add Symbol incase you actually did anything to a symbol and changed the Command String Mode
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '******************************************************************
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddPoint.Click
        Const ButtonStartedName As String = "Symbol Window  Command Add Point."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(58, ButtonStartedName & vbTab & e.ToString)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.AddPointNameToDropDownX(Me.ToolStripTextBox1.Text)
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdAddPoint"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '******************************************************************

    Private Sub ToolStripButtonNewSymbol_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNewSymbol.Click
        'flow10'If Me.ToolStripTextBox1.ToString = "" Then Exit Sub
        'flow10'Me.TextBoxSymbolName.Text = Me.ToolStripTextBox1.ToString
        Const ButtonStartedName As String = "Symbol Window  New Symbol add ." ' ->" & Me.ToolStripTextBox1.ToString & "-<"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(59, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub

        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = "" ' Get rid of old symbol name

        Me.TextBoxNamedDescription.Text = ""
        Me.TextBoxNamedProgramText.Text = ""
        Me.TextBoxNamedSymbolName.Text = ""
        Me.TextBoxNamedNameOfFile.Text = ""
        Me.TextBoxNamedNotes.Text = ""
        Me.TextBoxNamedOpCode.Text = ""
        Me.TextBoxNamedStroke.Text = ""
        Me.ToolStripDropDownNumberOfBytes.Text = ""
        Me.ComboBoxPointNameList.Text = ""
        Me.ComboBoxLineNameList.Text = ""
        Me.TextBoxSymbolVersionAuthor.Text = ""
        Me.TextBoxNamedSyntax.Text = ""
        Me.ToolStripDropDownLineWidth.Text = ""
        MyFlowChartNameSpace.F_C.MyDoEvents()
        'MyFlowChartNameSpace.F_C.AddNewSymbol(Me.ToolStripTextBox1.ToString) 'todo This is not passing the correct symbol name of the existing list box
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '******************************************************************
    Private Sub ToolStripButtonAddLine_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddLine.Click
        Const ButtonStartedName As String = "Symbol Window Add Line."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(60, ButtonStartedName & e.ToString)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.ToolStripTextBox1.Text = "" Then
            'make up a name for the line
            Me.ToolStripTextBox1.Text = MyFlowChartNameSpace.F_C.MakeNewName("NoName", sender.ToString)
        End If
        MyFlowChartNameSpace.F_C.AddLineNameToDropDown(Me.ToolStripTextBox1.Text)

        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdAddLine"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '******************************************************************
    Private Sub ToolStripButtonMove_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMove.Click
        Const ButtonStartedName As String = "Symbol Window  Command Move."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(61, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdMove"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************
    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        Const ButtonStartedName As String = "Symbol Window  Command Delete Object."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(62, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmddelete"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************
    '''Update the Symbol (rewrite if old, create if old)
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButtonUpdateSymbol.Click
        Const ButtonStartedName As String = "Symbol Window  Update Symbol record ."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(63, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.TextBoxNamedSymbolName.Text.Length < 1 Then
            MyFlowChartNameSpace.F_C.MSG_Abug(993, "A symbol name is required ", "", "")
            MyFlowChartNameSpace.F_C.A_Hint(914, "SymbolWindow", "No new symbol name entered.", "Symbol name is empty")
            Exit Sub
        End If
        MyFlowChartNameSpace.F_C.MyUpdateSymbolRecordFromSymbolWindow(Me.TextBoxNamedSymbolName.Text)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    '*****************************************************
    Private Sub ToolStripButtonFlowChartForm(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartForm_FromSymbolWindow.Click
        Const ButtonStartedName As String = "Symbol Window  Displaying FlowChart."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(64, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedColor = e.ToString
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowWindow, HideWindow, HideWindow, HideWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    Private Sub ToolStripButtonOptionForm_FromSymbolWindow_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOptionForm_FromSymbolWindow.Click
        Const ButtonStartedName As String = "Symbol Window  Displaying the Option Window."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(65, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, HideWindow, ShowWindow, HideWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    'Private Sub ToolStripDropDownButtonColor_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButtonColor.Click
    ' Const ButtonStartedName As String = "Symbol Window Select Color"
    ' MyFlowChartNameSpace.F_C.FindingMyBugs(100)
    ' If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
    ' MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedColor = sender.ToString 'Me.ToolStripDropDownButtonColor.Text
    ' MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
    ' MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    ' End Sub


    Private Sub ToolStripTextBox1_LostFocus(sender As Object, e As EventArgs) Handles ToolStripTextBox1.LostFocus
        Const ButtonStartedName As String = "Symbol Window Symbol text box Lost Focus"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(66, ButtonStartedName)
        End If
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedSymbolName.Text = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        '    'todo  Need to add this symbol at some time (just not when the program makes this lostfocus appear.)

        If MyFlowChartNameSpace.F_C.MyLeft(Me.ToolStripTextBox1.Text, 1) = "/" Then
            MyFlowChartNameSpace.F_C.ImportLineOrFile(Me.ToolStripTextBox1.Text)
            Me.ToolStripTextBox1.Text = "" 'delete the /dirictive
            MyFlowChartNameSpace.F_C.MyDoEvents()
        End If
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules() ' Reset the buttons to work now.(Can add symbol button at least)
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub '


    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs)
        'This could be eight a symbol name, or ...( See constant in FlowChart Window also)
        Const ButtonStartedName As String = "Symbol Window Input Click"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(19, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules() ' Reset the buttons to work now.(Can add symbol button at least)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub SymbolWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SavedState As Boolean
        Const ButtonStartedName As String = "Symbol Window  Load"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(20, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        'MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        SavedState = Me.Visible
        Me.Visible = True
        ResizeMe()
        Me.Visible = SavedState
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules() ' Reset the buttons to work now.(Can add symbol button at least)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        'MyFlowChartNameSpace.F_C.FindingMyBugs(16)
    End Sub

    Private Sub ResizeMe()
        Dim LeftText, LeftLabel, TextWidth, TextHeight As Integer
        If Me.Visible = False Then Exit Sub
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(21, "Symbol window re size me ()")
        End If
        If Me.Width < Me.PictureBox1.Width + 200 Then
            Me.Width = Me.PictureBox1.Width + 200
            MyFlowChartNameSpace.F_C.MyDoEvents() 'hack
        End If
        Me.PictureBox1.Top = Me.ToolStripSymbolBottom.Top + Me.ToolStripSymbolBottom.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls


        Me.PictureBox1.Width = CInt(MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantSymbolCenter * 2 * MyFlowChartNameSpace.F_C.MyUniverse.SysGen.MySymbolScale) + 2
        Me.PictureBox1.Height = CInt(MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantSymbolCenter * 2 * MyFlowChartNameSpace.F_C.MyUniverse.SysGen.MySymbolScale) + 2

        LeftLabel = Me.PictureBox1.Width + Me.PictureBox1.Left + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        LeftText = LeftLabel + 250
        TextWidth = (Me.Width - LeftText) - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls * 4
        TextHeight = CInt(((Me.Height - Me.PictureBox1.Top) - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls * 4) / 18)

        ResizeTextBox(Me.Label1, Me.TextBoxNamedSymbolName, Me.PictureBox1.Top, LeftLabel, LeftText, TextHeight, 0, 1, TextWidth)
        ResizeComboBox(Me.Label2, Me.ComboBoxPointNameList, Me.Label1.Top, LeftLabel, LeftText, TextHeight, TextHeight, 2, TextWidth)
        ResizeComboBox(Me.Label8, Me.ComboBoxLineNameList, Me.Label2.Top, LeftLabel, LeftText, TextHeight, TextHeight, 3, TextWidth)
        ResizeTextBox(Me.Label3, Me.TextBoxNamedNameOfFile, Me.Label8.Top, LeftLabel, LeftText, TextHeight, TextHeight, 4, TextWidth)
        ResizeTextBox(Me.Label4, Me.TextBoxNamedStroke, Me.Label3.Top, LeftLabel, LeftText, TextHeight, TextHeight, 5, TextWidth)
        ResizeTextBox(Me.Label5, Me.TextBoxNamedOpCode, Me.Label4.Top, LeftLabel, LeftText, TextHeight, TextHeight, 6, TextWidth)
        ResizeTextBox(Me.Label6, Me.TextBoxSymbolVersionAuthor, Me.Label5.Top, LeftLabel, LeftText, TextHeight, TextHeight, 7, TextWidth)
        ResizeTextBox(Me.Label7, Me.TextBoxNamedNotes, Me.Label6.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight, 8, TextWidth)
        ResizeTextBox(Me.Label9, Me.TextBoxNamedProgramText, Me.Label7.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 9, TextWidth)
        ResizeTextBox(Me.Label11, Me.TextBoxNamedSyntax, Me.Label9.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 10, TextWidth)
        ResizeTextBox(Me.Label12, Me.TextBoxNamedDescription, Me.Label11.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 11, TextWidth)
        'MyFlowChartNameSpace.F_C.MSG_Ainfo(2364, MyFlowChartNameSpace.F_C.MyShowPicture(True, Me.PictureBox1), "", "")
    End Sub

    Private Sub ResizeTextBox(L As Label, T As TextBox, LastTop As Integer, lastLeftLabel As Integer, LastLeftText As Integer, SetHeight As Integer, MoveHeight As Integer, MyTabIndex As Integer, TextWidth As Integer)
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 90 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(22, "Symbol Window re size text box()")
        End If
        L.Top = LastTop + MoveHeight + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        L.Width = LastTop : L.Left = lastLeftLabel : L.Height = SetHeight
        T.Top = L.Top : T.Left = LastLeftText : T.Height = SetHeight : T.TabIndex = MyTabIndex
        T.Width = TextWidth
        MyFlowChartNameSpace.F_C.MyDoEvents()
    End Sub

    Private Sub ResizeComboBox(L As Label, T As ComboBox, LastTop As Integer, lastLeftLabel As Integer, LastLeftText As Integer, SetHeight As Integer, MoveHeight As Integer, MyTabIndex As Integer, TextWidth As Integer)
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 90 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(23, "Symbol Window re size combo box()")
        End If
        L.Top = LastTop + MoveHeight + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        L.Width = LastTop : L.Left = lastLeftLabel : L.Height = SetHeight
        T.Top = L.Top : T.Left = LastLeftText : T.Height = SetHeight : T.TabIndex = MyTabIndex
        T.Width = TextWidth
        MyFlowChartNameSpace.F_C.MyDoEvents()
    End Sub

    Private Sub ToolStripDropDownSelectSymbol_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownSelectSymbol.DropDownItemClicked
        'todo see why a new symbol is not showing up when a symbol is select with the drop down
        Const ButtonStartedName As String = "Symbol Window  Select Item Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(24, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownSelectSymbol.Text = sender.ToString
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = sender.ToString
        MyFlowChartNameSpace.F_C.MSG_Ainfo1(451, "Symbol selected ", MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName, "?")
        MyFlowChartNameSpace.F_C.DisplaySymbolText(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        Me.ToolStripDropDownSelectSymbol.Text = Me.ToolStripDropDownSelectSymbol.ToString
        Me.TextBoxNamedSymbolName.Text = MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName 'Me.ToolStripDropDownSelectSymbol.ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If Me.ToolStripDropDownSelectSymbol.ToString = "" Then
            MyFlowChartNameSpace.F_C.MSG_Abug(2007, "Symbol Name is not select ? ", "What Goes Here?", "")
        Else
            MyFlowChartNameSpace.F_C.PaintEach(Me.PictureBox1,
     MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.ZeroZero,'MyFlowChartNameSpace.F_C.MyPoint1XY(Temp, Temp),
     Me.ToolStripDropDownSelectSymbol.ToString,'flow10'Me.ToolStripDropDownSelectSymbol.ToString,
     "default")
        End If
    End Sub

    Private Sub ToolStripDropDownRotation_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownRotation.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window Rotation Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(25, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedRotation = e.ClickedItem.ToString
        Me.ToolStripDropDownRotation.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownDataType_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownDataType.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window DataType Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(26, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyDoEvents()
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedDataType = e.ClickedItem.Text
        Me.ToolStripDropDownDataType.Text = e.ClickedItem.Text
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    Private Sub ToolStripDropDownPathLineStyle_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathLineStyle.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window  Line Style Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(27, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedPathLineStyle = e.ClickedItem.ToString
        Me.ToolStripDropDownPathLineStyle.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ToolStripDropDownButtonColor_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownButtonColor.DropDownItemClicked
        MyFlowChartNameSpace.F_C.MyDoEvents()
        Const ButtonStartedName As String = "Symbol Window  Color Item Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(28, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedColor = e.ClickedItem.ToString
        Me.ToolStripDropDownButtonColor.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ToolStripDropDownLineWidth_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownLineWidth.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window Line Width item Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(29, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedPathLineStyle = e.ClickedItem.ToString
        Me.ToolStripDropDownLineWidth.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ToolStripDropDownInputOutput_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownInputOutput.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window Input Output Item Clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(30, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedInputOutput = e.ClickedItem.Text
        Me.ToolStripDropDownInputOutput.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ToolStripDropDownNumberOfBytes_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownNumberOfBytes.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window NoBytes item clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(32, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedNumberOfBytes = e.ClickedItem.ToString
        Me.ToolStripDropDownNumberOfBytes.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    Private Sub ToolStripDropDownPathStart_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathStart.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window Start Cap item clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(33, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedPathStart = e.ClickedItem.ToString
        Me.ToolStripDropDownPathStart.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ToolStripDropDownPathEnd_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathEnd.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Window End Cap item clicked"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(34, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedPathEnd = e.ClickedItem.ToString
        Me.ToolStripDropDownPathEnd.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxNamedSymbolName_LostFocus(sender As Object, e As EventArgs) Handles TextBoxNamedSymbolName.LostFocus
        Dim IndexNamed, IndexSymbol As Int32
        Const ButtonStartedName As String = "Symbol Window Lost Focus"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(35, ButtonStartedName & " to " & Me.TextBoxNamedSymbolName.Text)
        End If

        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub

        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedSymbolName.ToString = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        'MyFlowChartNameSpace.F_C.FindingMyBugs(17)
        'DOC if the symbol name changes then add this symbol , other wise, I should delete it and then write over again.
        IndexSymbol = MyFlowChartNameSpace.F_C.FindInSymbolList(Me.TextBoxNamedSymbolName.Text)
        'MyFlowChartNameSpace.F_C.FindingMyBugs(18) '
        If IndexSymbol = -1 Then 'if no symbol graphics then
            ' we just lost focus, not changed anything 
        Else
            IndexNamed = MyFlowChartNameSpace.F_C.FindInNamedList(Me.ToolStripDropDownSelectSymbol.ToString)
            If IndexNamed <> MyFlowChartNameSpace.F_C.constantMyErrorCode Then
                'todo this is changed the start to something left over somewhere.
                If MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName <> Me.TextBoxNamedSymbolName.SelectedText Then
                    MyFlowChartNameSpace.F_C.MSG_Ainfo(423, "rename symbol : ",
        MyFlowChartNameSpace.F_C.HighLight(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName),
        MyFlowChartNameSpace.F_C.HighLight(Me.TextBoxNamedSymbolName.SelectedText))
                    'DOC this should change from the old selected to the new select symbol name.''
                    MyFlowChartNameSpace.F_C.MyRenameSymbol(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName, Me.TextBoxNamedSymbolName.SelectedText)
                    MyFlowChartNameSpace.F_C.Named_FileNameOfFile(CInt(MyFlowChartNameSpace.F_C.Named_FileSymbolName_iSAM(IndexNamed))) = Me.TextBoxNamedSymbolName.ToString
                    Me.ToolStripDropDownSelectSymbol.DropDownItems.Clear()
                    MyFlowChartNameSpace.F_C.FillAllDropdowns("start")
                End If
            End If
        End If
        'MyFlowChartNameSpace.F_C.MyTrace(1, "Symbol Window Lost Focus")
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        'Check that this symbol is all OK
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(36, "SymbolWindow  start tool strip menu item clicked()")
        End If
        MyFlowChartNameSpace.F_C.MSG_Ainfo(447, "Menu item selected", sender.ToString, e.ToString)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedDescription_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedDescription.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 95 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(37, "SymbolWindow  text box named description text changed () to " & Me.TextBoxNamedDescription.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedNameOfFile_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedNameOfFile.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(38, "SymbolWindow  textboxnamednameoffile changed () " & Me.TextBoxNamedNameOfFile.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedNotes_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedNotes.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 98 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(39, "SymbolWindow text box named notes text changed () " & Me.TextBoxNamedNotes.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedOpCode_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedOpCode.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(40, "SymbolWindow  text box named op code text changed () " & Me.TextBoxNamedOpCode.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedStroke_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedStroke.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(41, "SymbolWindow  text box named stroke text changed ()" & Me.TextBoxNamedStroke.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedSymbolName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedSymbolName.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(42, "SymbolWindow  text box named symbol name text changed () " & Me.TextBoxNamedSymbolName.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxNamedSyntax_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedSyntax.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(43, "SymbolWindow  text box named symtax text changed() to " & Me.TextBoxNamedSyntax.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub TextBoxSymbolVersionAuthor_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSymbolVersionAuthor.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(44, "SymbolWindow  text box symbol version author text changed() " & Me.TextBoxSymbolVersionAuthor.Text)
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SymbolChanged = True
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub ToolStripDropDownSelectSymbol_TextChanged(sender As Object, e As EventArgs) Handles ToolStripDropDownSelectSymbol.TextChanged
        'todo see why a new symbol is not showing up when a symbol is select with the drop down
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 98 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(45, "SymbolWindow  tool strip drop down select symbol text changed () " & Me.ToolStripDropDownSelectSymbol.Text)
        End If
        If MyFlowChartNameSpace.F_C.MyUniverse.ProgramAlive = False Then Exit Sub

        If Me.ToolStripDropDownSelectSymbol.Text <> sender.ToString Then 'if it's not alread done
            Me.ToolStripDropDownSelectSymbol.Text = sender.ToString
            Exit Sub
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = sender.ToString
        Me.TextBoxNamedSymbolName.Text = MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName
        If FlowChartWindow.ToolStripDropDownSelectSymbol.Text <> sender.ToString Then
            FlowChartWindow.ToolStripDropDownSelectSymbol.Text = sender.ToString
        End If
    End Sub

    Private Sub ToolStripDropDownSelectSymbol_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownSelectSymbol.Click
        Const ButtonStartedName As String = "Symbol Window  Select Item Clicked "
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownSelectSymbol.Text = sender.ToString
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = sender.ToString
        MyFlowChartNameSpace.F_C.MSG_Ainfo1(451, "Symbol selected ", MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName, "?")
        MyFlowChartNameSpace.F_C.DisplaySymbolText(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        Me.ToolStripDropDownSelectSymbol.Text = Me.ToolStripDropDownSelectSymbol.ToString
        Me.TextBoxNamedSymbolName.Text = MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName 'Me.ToolStripDropDownSelectSymbol.ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)

        If Me.ToolStripDropDownSelectSymbol.ToString = "" Then
            MyFlowChartNameSpace.F_C.MSG_Abug(2007, "Symbol Name is not select ? ", "What Goes Here?", "")
        Else
            MyFlowChartNameSpace.F_C.PaintEach(Me.PictureBox1,
     MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.ZeroZero,'MyFlowChartNameSpace.F_C.MyPoint1XY(Temp, Temp),
     Me.ToolStripDropDownSelectSymbol.ToString,'flow10'Me.ToolStripDropDownSelectSymbol.ToString,
     "default")
        End If



    End Sub

    Private Sub ToolStripTextBox1_Enter(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Enter
        Const ButtonStartedName As String = "Text Data Entered "
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(47, ButtonStartedName & " to " & Me.ToolStripTextBox1.Text)
        End If
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripTextBox1.Text = sender.ToString
        MyFlowChartNameSpace.F_C.MSG_Ainfo1(451, "text entered ", Me.ToolStripTextBox1.Text, "?")
        MyFlowChartNameSpace.F_C.DisplayMyStatus(Me.ToolStripTextBox1.Text)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.FindingMyBugs(100)

        If Me.ToolStripDropDownSelectSymbol.ToString = "" Then
            MyFlowChartNameSpace.F_C.MSG_Abug(2007, "Symbol Name is not select ? ", "What Goes Here?", "")
        Else
            MyFlowChartNameSpace.F_C.PaintEach(Me.PictureBox1,
     MyFlowChartNameSpace.F_C.MyUniverse.MyStaticData.ZeroZero,
     Me.ToolStripDropDownSelectSymbol.ToString,
     "default")
        End If
        MyFlowChartNameSpace.F_C.MyDeCompileLine(Me.ToolStripTextBox1.Text)

    End Sub

    Private Sub ComboBoxLineNameList_Enter(sender As Object, e As EventArgs) Handles ComboBoxLineNameList.Enter
        Dim Z1 As String, Z2 As String
        Dim I As Int32
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(47, "name of line set to " & Me.ComboBoxLineNameList.Text)
        End If

        Z2 = ComboBoxLineNameList.Text
        Z2 = MyFlowChartNameSpace.F_C.Pop(Z2, MyFlowChartNameSpace.F_C.FD)
        If Z2 = "" Then
            Exit Sub
        End If

        For I = 0 To Me.ComboBoxLineNameList.Items.Count - 1
            Z1 = sender.ToString
            Z1 = MyFlowChartNameSpace.F_C.Pop(Z1, MyFlowChartNameSpace.F_C.FD)
            If Z1 = Z2 Then
                Exit Sub
            End If
        Next
        Me.ComboBoxLineNameList.Items.Add(sender.ToString)
        MyFlowChartNameSpace.F_C.MyDoEvents()
    End Sub

    Private Sub ComboBoxPointNameList_Enter(sender As Object, e As EventArgs) Handles ComboBoxPointNameList.Enter
        Dim Z1 As String, Z2 As String
        Dim I As Int32
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(47, "point name entered " & Me.ComboBoxPointNameList.Text)
        End If

        Z2 = ComboBoxPointNameList.Text
        Z2 = MyFlowChartNameSpace.F_C.Pop(Z2, MyFlowChartNameSpace.F_C.FD)
        If Z2 = "" Then 'if nothing in the text field then do nothing
            Exit Sub
        End If
        For I = 0 To Me.ComboBoxPointNameList.Items.Count - 1
            Z1 = Me.ComboBoxPointNameList.Items(I).ToString
            Z1 = MyFlowChartNameSpace.F_C.Pop(Z1, MyFlowChartNameSpace.F_C.FD)
            If Z1 = Z2 Then
                Exit Sub
            End If
        Next
        Me.ComboBoxPointNameList.Items.Add(Z2)
        MyFlowChartNameSpace.F_C.MyDoEvents()

    End Sub
End Class