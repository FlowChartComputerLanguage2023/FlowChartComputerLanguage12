

Option Strict On
    Option Explicit On
    Option Infer Off
    Option Compare Text

Public Class SymbolScreen
    Public Const ShowScreen As Int32 = 1
    Public Const HideScreen As Int32 = 0
    Public Const LeaveScreenAlone As Int32 = -1

    Private Sub SymbolScreen_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Const ButtonStartedName As String = "Symbol Screen Resize"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        ResizeMe()
        MyFlowChartNameSpace.F_C.Clear_Screen(Me.PictureBox1) 'todo Check that this should redraw the screen????????
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Const ButtonStartedName As String = "Mouse Down"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseDown"
        MyFlowChartNameSpace.F_C.MyMouseDown(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Dim Temp As Int32
        Const ButtonStartedName As String = "Mouse Up"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseUp"
        MyFlowChartNameSpace.F_C.MyMouseUp(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.Clear_Screen(Me.PictureBox1)
        Application.DoEvents()
        Temp = MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantSymbolCenter '+ MyFlowChartNameSpace.F_C..myuniverse.sysgen.constantSymbolCenter
        If Me.ToolStripDropDownSelectSymbol.ToString = "" Then 'flow10'Me.ToolStripDropDownSelectSymbol.ToString = "" Then
            MyFlowChartNameSpace.F_C.Abug(9998, "What Goes Here?", "", "")
        Else
            MyFlowChartNameSpace.F_C.PaintEach(Me.PictureBox1,
                     MyFlowChartNameSpace.F_C.MyPoint1(Temp, Temp),
                     Me.ToolStripDropDownSelectSymbol.ToString,'flow10'Me.ToolStripDropDownSelectSymbol.ToString,
                     "default")
        End If
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Const ButtonStartedName As String = "Symbol Screen  Mouse Movement"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "MouseMove"
        MyFlowChartNameSpace.F_C.MyMouseMove(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ComboBoxColor_SelectedIndexChanged(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = "Color Index Changed"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ChangeOptionScreenSelectedIndex(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ComboBoxDataType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim DataTypeName As String
        Dim I As Int32
        Const ButtonStartedName As String = "Data Type index changed."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub

        'todo Possible Error
        'todo Double check that I want the data type to be a color name
        'todo Put here the drop dows of items that can be changed for this Data type
        DataTypeName = Me.ToolStripDropDownButtonColor.Text

        I = MyFlowChartNameSpace.F_C.FindiSAM_IN_Table("DataType", "DoNotAdd" _
                         , MyFlowChartNameSpace.F_C.DataType_FileName _
                         , MyFlowChartNameSpace.F_C.DataType_iSAM_ _
                         , DataTypeName)
        If I = -1 Then
            Exit Sub
        End If
        'show (to allow updating)
        Me.TextBoxNamedDescription.Text = MyFlowChartNameSpace.F_C.DataType_TableDescribtion(I)
        Me.ToolStripDropDownNumberOfBytes.Text = MyFlowChartNameSpace.F_C.DataType_TableNumberOfBytes(I)


        'ERROR ???
        'Should this look up the name of the color?
        MyFlowChartNameSpace.F_C.MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME = Str(MyFlowChartNameSpace.F_C.DataType_TableColorIndex(I))

        Me.ToolStripDropDownLineWidth.Text = MyFlowChartNameSpace.F_C.DataType_TableWidth(I).ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ComboBoxDataType_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        Dim Temp As Int32
        Const ButtonStartedName As String = " DataType Index changed."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Temp = MyFlowChartNameSpace.F_C.FindIndexIniSAMTable("Datatype",
                                                                 "Donotadd",
                                                                 MyFlowChartNameSpace.F_C.DataType_FileName,
                                                                 MyFlowChartNameSpace.F_C.DataType_iSAM_,
                                                                 Me.ToolStripDropDownButtonColor.Text)

        Me.TextBoxNamedDescription.Text = MyFlowChartNameSpace.F_C.DataType_TableDescribtion(Temp)
        Me.ToolStripDropDownButtonColor.Text = MyFlowChartNameSpace.F_C.Color_TableName(MyFlowChartNameSpace.F_C.DataType_TableColorIndex(Temp))

        MyFlowChartNameSpace.F_C.MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME = Me.ToolStripDropDownButtonColor.Text

        Me.ToolStripDropDownInputOutput.Text = "both" ' Just to make it something
        Me.ToolStripDropDownNumberOfBytes.Text = MyFlowChartNameSpace.F_C.DataType_TableNumberOfBytes(Temp)
        Me.ToolStripDropDownLineWidth.Text = MyFlowChartNameSpace.F_C.DataType_TableWidth(Temp).ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Const ButtonStartedName As String = " Timer Ticked."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.TimerTicked(sender, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxProgramText_TextChanged(sender As Object, e As EventArgs) Handles TextBoxProgramText.TextChanged
        Const ButtonStartedName As String = " Making New Syntax from change in program code."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.TextBoxProgramText.Text = " Program Macro Code" Then Exit Sub
        Dim Temp(256) As String
        MyFlowChartNameSpace.F_C.MyParse(Temp, Me.TextBoxProgramText.Text)
        Me.TextBoxNamedSyntax.Text = MyFlowChartNameSpace.F_C.MakeStatementSyntax(Temp)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = " Displaying FlowChart."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdaddsymbol" ' Always Go to Add Symbol incase you actually did anything to a symbol and changed the Command String Mode
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '******************************************************************
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddPoint.Click
        Const ButtonStartedName As String = " Command Add Point."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdAddPoint"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************

    Private Sub ToolStripButtonNewSymbol_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNewSymbol.Click
        'flow10'If Me.ToolStripTextBox1.ToString = "" Then Exit Sub
        'flow10'Me.TextBoxSymbolName.Text = Me.ToolStripTextBox1.ToString
        Const ButtonStartedName As String = " New Symbol add ." ''''''''''''''' ->" & Me.ToolStripTextBox1.ToString & "-<"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.TextBoxNamedDescription.Text = ""
        Me.TextBoxProgramText.Text = ""
        Me.TextBoxNamedFilename.Text = ""
        Me.TextBoxNamedFilename.Text = ""
        Me.TextBoxNamedNotes.Text = ""
        Me.TextBoxNamedOpCode.Text = ""
        Me.TextBoxNamedStroke.Text = ""
        Me.ToolStripDropDownNumberOfBytes.Text = ""
        Me.ComboBoxPointNameList.Text = ""
        Me.ComboBoxLineNameList.Text = ""
        Me.TextBoxSymbolVersionAuthor.Text = ""
        Me.TextBoxNamedSyntax.Text = ""
        Me.ToolStripDropDownLineWidth.Text = ""
        Application.DoEvents()
        MyFlowChartNameSpace.F_C.AddNewSymbol(Me.ToolStripTextBox1.ToString) 'todo This is not passing the correct symbol name of the existing list box
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************
    Private Sub ToolStripButtonAddLine_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddLine.Click
        Const ButtonStartedName As String = "Add Line."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdAddLine"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '******************************************************************
    Private Sub ToolStripButtonMove_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMove.Click
        Const ButtonStartedName As String = " Command Move."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdMove"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************
    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        Const ButtonStartedName As String = " Command Delete Object."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdDelete"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '******************************************************************

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButtonUpdateSymbol.Click
        Const ButtonStartedName As String = " Update Symbol record ."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.UpdateSymbolRecordFromSymbolScreen()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    '*****************************************************
    Private Sub ToolStripButtonFlowChartForm(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartForm_FromSymbolScreen.Click
        Const ButtonStartedName As String = " Displaying FlowChart."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    Private Sub ToolStripButtonOptionForm_FromSymbolScreen_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOptionForm_FromSymbolScreen.Click
        Const ButtonStartedName As String = " Displaying the Option Screen."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxNamedStroke_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedStroke.TextChanged
        Dim index As Int32
        Const ButtonStartedName As String = " Symbol Stroke changed."
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedStroke.ToString = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        index = MyFlowChartNameSpace.F_C.FindIndexIniSAMTable("Named", "add",
                                                                  MyFlowChartNameSpace.F_C.Named_FileSymbolName,
                                                                 MyFlowChartNameSpace.F_C.Named_File_iSAM,
                                                                Me.ToolStripDropDownSelectSymbol.ToString)
        If index = -1 Then
        Else
            MyFlowChartNameSpace.F_C.Named_TableSymbolName(index, Me.TextBoxNamedStroke.ToString)
        End If
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxNamedOpCode_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedOpCode.TextChanged
        Dim index As Integer
        Const ButtonStartedName As String = " Opcode changed."
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedOpCode.ToString = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        index = CInt(MyFlowChartNameSpace.F_C.FindiSAM_IN_Table("Named", "add",
                                                                  MyFlowChartNameSpace.F_C.Named_FileSymbolName,
                                                                  MyFlowChartNameSpace.F_C.Named_File_iSAM,
                                                              Me.ToolStripDropDownSelectSymbol.ToString))
        If index = -1 Then
        Else
            MyFlowChartNameSpace.F_C.Named_FileOpCode(CInt(MyFlowChartNameSpace.F_C.Named_File_iSAM(CInt(index)))) = Me.TextBoxNamedOpCode.ToString
        End If

        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxNamedNotes_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedNotes.TextChanged
        Dim index As Integer
        Const ButtonStartedName As String = " Notes Changed."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedNotes.ToString = "" Then Exit Sub
        index = CInt(MyFlowChartNameSpace.F_C.FindiSAM_IN_Table("Named", "add",
                                                                  MyFlowChartNameSpace.F_C.Named_FileSymbolName,
                                                                  MyFlowChartNameSpace.F_C.Named_File_iSAM,
                                                               Me.ToolStripDropDownSelectSymbol.ToString))
        If index = -1 Then
        Else
            MyFlowChartNameSpace.F_C.Named_FileNotes(CInt(MyFlowChartNameSpace.F_C.Named_File_iSAM(index))) = Me.TextBoxNamedNotes.ToString
        End If

        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxNamedFilename_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNamedFilename.TextChanged
        Dim index As Integer
        Const ButtonStartedName As String = " Symbol File Name Changed."
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxNamedFilename.ToString = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        index = CInt(MyFlowChartNameSpace.F_C.FindiSAM_IN_Table("Named", "add",
                                                              MyFlowChartNameSpace.F_C.Named_FileSymbolName,
                                                              MyFlowChartNameSpace.F_C.Named_File_iSAM,
                                                             Me.ToolStripDropDownSelectSymbol.ToString))
        If index = -1 Then
        Else
            MyFlowChartNameSpace.F_C.Named_FileNameOfFile(CInt(MyFlowChartNameSpace.F_C.Named_File_iSAM(index))) = Me.TextBoxNamedFilename.ToString
        End If
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ToolStripDropDownButtonColor_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButtonColor.Click
        Const ButtonStartedName As String = "Symbol Screen Select Color"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyDefaults.ConstantDEFAULTCOLORNAME = Me.ToolStripDropDownButtonColor.Text
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    Private Sub TextBoxSymbolName_LostFocus(sender As Object, e As EventArgs) Handles TextBoxSymbolName.LostFocus
        Const ButtonStartedName As String = "Symbol Screen Symbol Name Lost Focus"
        If Me.Visible = False Then Exit Sub
        If Me.TextBoxSymbolName.Text = "" Then Exit Sub
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Me.TextBoxSymbolName.Text = "New Symbol Name Here" Then Exit Sub ' To make sure that a new symbol name is added.
        MyFlowChartNameSpace.F_C.AddNewSymbol(Me.TextBoxSymbolName.Text.ToString)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click
        'This could be eight a symbol name, or ...( See constant in FlowChart Screen also)
        Const ButtonStartedName As String = "Symbol Screen Input Click"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me) ' Reset the buttons to work now. (Can add symbol button at least)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub SymbolScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SavedState As Boolean
        Const ButtonStartedName As String = "Symbol Screen  Load"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        SavedState = Me.Visible
        Me.Visible = True
        ResizeMe()
        Me.Visible = SavedState
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ResizeMe()
        Dim LeftText, LeftLabel, TextWidth, TextHeight As Integer
        If Me.Visible = False Then Exit Sub
        If Me.Width < Me.PictureBox1.Width + 200 Then
            Application.DoEvents() 'hack
            Me.Width = Me.PictureBox1.Width + 200
            Application.DoEvents() 'hack
        End If
        Me.PictureBox1.Top = Me.ToolStrip3.Top + Me.ToolStrip3.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        Me.PictureBox1.Width = 512
        Me.PictureBox1.Height = 512

        LeftLabel = Me.PictureBox1.Width + Me.PictureBox1.Left + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        LeftText = LeftLabel + 125
        TextWidth = (Me.Width - LeftText) - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls * 4
        TextHeight = CInt(((Me.Height - Me.PictureBox1.Top) - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls * 4) / 18)

        ResizeTextBox(Me.Label1, Me.TextBoxSymbolName, Me.PictureBox1.Top, LeftLabel, LeftText, TextHeight, 0, 1, TextWidth)
        ResizeComboBox(Me.Label2, Me.ComboBoxPointNameList, Me.Label1.Top, LeftLabel, LeftText, TextHeight, TextHeight, 2, TextWidth)
        ResizeComboBox(Me.Label8, Me.ComboBoxLineNameList, Me.Label2.Top, LeftLabel, LeftText, TextHeight, TextHeight, 3, TextWidth)
        ResizeTextBox(Me.Label3, Me.TextBoxNamedFilename, Me.Label8.Top, LeftLabel, LeftText, TextHeight, TextHeight, 4, TextWidth)
        ResizeTextBox(Me.Label4, Me.TextBoxNamedStroke, Me.Label3.Top, LeftLabel, LeftText, TextHeight, TextHeight, 5, TextWidth)
        ResizeTextBox(Me.Label5, Me.TextBoxNamedOpCode, Me.Label4.Top, LeftLabel, LeftText, TextHeight, TextHeight, 6, TextWidth)
        ResizeTextBox(Me.Label6, Me.TextBoxSymbolVersionAuthor, Me.Label5.Top, LeftLabel, LeftText, TextHeight, TextHeight, 7, TextWidth)
        ResizeTextBox(Me.Label7, Me.TextBoxNamedNotes, Me.Label6.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight, 8, TextWidth)
        ResizeTextBox(Me.Label9, Me.TextBoxProgramText, Me.Label7.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 9, TextWidth)
        ResizeTextBox(Me.Label11, Me.TextBoxNamedSyntax, Me.Label9.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 10, TextWidth)
        ResizeTextBox(Me.Label12, Me.TextBoxNamedDescription, Me.Label11.Top, LeftLabel, LeftText, TextHeight * 2, TextHeight * 2, 11, TextWidth)

    End Sub

    Private Sub ResizeTextBox(L As Label, T As TextBox, LastTop As Integer, lastLeftLabel As Integer, LastLeftText As Integer, SetHeight As Integer, MoveHeight As Integer, MyTabIndex As Integer, TextWidth As Integer)
        L.Top = LastTop + MoveHeight + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        L.Width = LastTop : L.Left = lastLeftLabel : L.Height = SetHeight
        T.Top = L.Top : T.Left = LastLeftText : T.Height = SetHeight : T.TabIndex = MyTabIndex
        T.Width = TextWidth
        Application.DoEvents()
    End Sub

    Private Sub ResizeComboBox(L As Label, T As ComboBox, LastTop As Integer, lastLeftLabel As Integer, LastLeftText As Integer, SetHeight As Integer, MoveHeight As Integer, MyTabIndex As Integer, TextWidth As Integer)
        L.Top = LastTop + MoveHeight + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        L.Width = LastTop : L.Left = lastLeftLabel : L.Height = SetHeight
        T.Top = L.Top : T.Left = LastLeftText : T.Height = SetHeight : T.TabIndex = MyTabIndex
        T.Width = TextWidth
        Application.DoEvents()
    End Sub






    Private Sub ToolStripDropDownSelectSymbol_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownSelectSymbol.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen  Select Item Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownSelectSymbol.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        Me.ToolStripDropDownSelectSymbol.Text = Me.ToolStripDropDownSelectSymbol.ToString
        Me.TextBoxSymbolName.Text = Me.ToolStripDropDownSelectSymbol.ToString
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ToolStripDropDownRotation_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownRotation.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen Rotation Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownRotation.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownDataType_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownDataType.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen DataType Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownDataType.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownPathLineStyle_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathLineStyle.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen  Line Style Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownPathLineStyle.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownButtonColor_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownButtonColor.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen  Color Item Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownButtonColor.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownLineWidth_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownLineWidth.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen Line Width item Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownLineWidth.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownInputOutput_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownInputOutput.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen Input Output Item Clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownInputOutput.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownNumberOfBytes_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownNumberOfBytes.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen NoBytes item clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownNumberOfBytes.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownPathStart_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathStart.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen Start Cap item clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownPathStart.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    Private Sub ToolStripDropDownPathEnd_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownPathEnd.DropDownItemClicked
        Const ButtonStartedName As String = "Symbol Screen End Cap item clicked"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownPathEnd.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub TextBoxSymbolName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSymbolName.TextChanged
        Const ButtonStartedName As String = "Symbol Screen Symbol Name Text Changed"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        'TODO ERROR THIS HAS NOT BEEN WRITTEN
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

End Class