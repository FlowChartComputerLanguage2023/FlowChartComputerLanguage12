


Option Strict On
Option Infer Off
Option Compare Text
Option Explicit On

Imports System.ComponentModel
#Const MyDebug = 50

Public Class FlowChartWindow


    'DONE KINDA, NEEDS WORK todo added splash Window (do above, or OK button to start up window.

    Friend Const ShowWindow As Int32 = 1
    Friend Const HideWindow As Int32 = 0
    Friend Const LeaveWindowAlone As Int32 = -1
    'flow10'This belongs in status or option Window*************************???????






    Private Sub ButtonCheck_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = "Flow Chart  CheckAll."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 68 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(95, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.CheckAll()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub



    '****************************************************************
    ' 10 This is used to redraw the FlowChart (Cause it gets messed up, and I have to fix that one of these days)
    Private Sub ToolStripButtonRedraw_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRedraw.Click
        Const ButtonStartedName As String = "Flow Chart  Redraw."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 65 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(68, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    ' 11 This is used to enlarge the flowchart.(You see a part of the picture)
    Private Sub ToolStripButtonZoomIn_Click(sender As Object, e As EventArgs) Handles ToolStripButtonZoomIn.Click
        Const ButtonStartedName As String = "Flow Chart  Zoom in."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 68 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(69, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.MyFlowChartScale /= MyFlowChartNameSpace.F_C.ConstantFlowChartScaleChange
        MyFlowChartNameSpace.F_C.LimitScale()
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)

        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '****************************************************************
    ' 12 This is used to reduce the flowchart on the Window (You can see more of the picture)
    Private Sub ToolStripButtonZoomOut_Click(sender As Object, e As EventArgs) Handles ToolStripButtonZoomOut.Click
        Const ButtonStartedName As String = "Flow Chart  Zoom Out."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 68 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(70, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.MyFlowChartScale /= MyFlowChartNameSpace.F_C.ConstantFlowChartScaleChange
        MyFlowChartNameSpace.F_C.LimitScale()
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub


    '****************************************************************
    ' 8 This is used to put a constant (entered in the textbox on the toolstrip)
    'You should/(Must?) place it on a path (end points or turn of a path)
    Private Sub ToolStripButtonAddConstant_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddConstant.Click
        Const ButtonStartedName As String = "Flow Chart  Command Add Constant."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(71, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdaddconstant"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub FlowChartWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Const ButtonStartedName As String = "Flow Chart Window Starting"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 93 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(72, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, HideWindow, ShowWindow, HideWindow)
    End Sub



    '****************************************************************
    'This goto the FlowChartWindow
    Private Sub ButtonSymbolForm_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSymbolForm.Click
        Const ButtonStartedName As String = "Flow Chart  Showing the symbol Window."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(73, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdaddsymbol"
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, ShowWindow, HideWindow, LeaveWindowAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub


    '****************************************************************
    '6 This moves what ever is closest to where the mouseUP is
    Private Sub ButtonMoveObject_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMoveObject.Click
        Const ButtonStartedName As String = "Flow Chart  Command Move Object."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(74, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdmove"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '****************************************************************
    ' This will delete what ever is closest to the mouse down
    ' Advise that you move first to somewhere that is clear, and then delete it.
    Private Sub ButtonDeleteobject_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDeleteobject.Click
        Const ButtonStartedName As String = "Flow Chart  Command Delete Object."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(75, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmddelete"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub



    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Const ButtonStartedName As String = "Flow Chart FLowChart Window H Scroll"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(76, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Const ButtonStartedName As String = "Flow Chart FlowChart Window V scroll"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(77, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Window(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Const ButtonStartedName As String = "Flow Chart FlowChart Window Mouse Down"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(78, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mousedown"
        MyFlowChartNameSpace.F_C.MyMouseDown(e) 'Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Const ButtonStartedName As String = "Flow Chart FlowChart Window Mouse Up"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(79, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mouseup"
        MyFlowChartNameSpace.F_C.MyMouseUp(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Const ButtonStartedName As String = "Flow Chart FlowChart Window Mouse Move"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 75 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(80, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mousemove"
        MyFlowChartNameSpace.F_C.MyMouseMove(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName & ".Command set to " & MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString & ", " & e.X.ToString & "," & e.Y.ToString & " (" & e.Button.ToString & ", " & e.Clicks.ToString & ")")
    End Sub

    Private Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel
        Const ButtonStartedName As String = "FlowChart Window Mouse Wheel Moved"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(81, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyMouseWheel(e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName & " Scale set to  " & MyFlowChartNameSpace.F_C.MyUniverse.SysGen.MyFlowChartScale.ToString)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '****************************************************************
    '3 This goes to the FileInputOutput Window
    Private Sub ToolStripButtonOpen_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpenForm.Click
        Const ButtonStartedName As String = "Flow Chart  Displaying File Input/Output and status'."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(82, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, HideWindow, HideWindow, ShowWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '****************************************************************
    '2This goes to the optionWindow
    Private Sub ToolStripButtonOptions_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOptionForm.Click
        Const ButtonStartedName As String = "Flow Chart  Displaying Options."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 68 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(83, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, HideWindow, ShowWindow, LeaveWindowAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '****************************************************************
    '4 This set the mode to add a path when clicking the first end of the line, holding to the last end of the line
    Private Sub ToolStripButtonAddPath_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddPath.Click
        Const ButtonStartedName As String = "Flow Chart  AddPath."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(84, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdaddpath"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    Private Sub ToolStripDropDownSelectSymbolX_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownSelectSymbol.Click
        Const ButtonStartedName As String = "FlowChart Window Select Symbol X Click"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(85, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = Me.ToolStripDropDownSelectSymbol.Text
        SymbolWindow.ToolStripDropDownSelectSymbol.Text = MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub FlowChartWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'FIXED ?this caused recursion and needs to be repaired
        Const ButtonStartedName As String = "FlowChart Window Redraw from Resize"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(86, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        ResizeMe()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        'MyFlowChartNameSpace.F_C.MSG_Ainfo(2361, MyFlowChartNameSpace.F_C.MyShowPicture(True, Me.PictureBox1), "", "")
    End Sub

    Private Sub ResizeMe()
        Dim X As Int32
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(87, "ResizeMe() Flow Chart Window")
        End If
        X = MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls

        Me.VScrollBar1.Left = X
        Me.HScrollBar1.Left = Me.VScrollBar1.Width + X
        Me.PictureBox1.Left = Me.HScrollBar1.Left

        Me.HScrollBar1.Top = Me.ToolStripFlowChart.Height + X
        Me.VScrollBar1.Top = Me.HScrollBar1.Top + Me.HScrollBar1.Height
        Me.PictureBox1.Top = Me.HScrollBar1.Top + Me.HScrollBar1.Height

        Me.HScrollBar1.Width = Me.Width - (Me.VScrollBar1.Left + Me.VScrollBar1.Width) - X * 6
        Me.PictureBox1.Width = Me.Width - (Me.VScrollBar1.Left + Me.VScrollBar1.Width) - X * 6

        Me.VScrollBar1.Height = Me.Height - Me.VScrollBar1.Top - X * 10
        Me.PictureBox1.Height = Me.VScrollBar1.Height

        ' Now Set the scroll bars 

        Me.HScrollBar1.Minimum = 1
        Me.HScrollBar1.Maximum = 1000
        Me.HScrollBar1.LargeChange = 100
        Me.HScrollBar1.SmallChange = 10

        Me.VScrollBar1.Minimum = Me.HScrollBar1.Minimum
        Me.VScrollBar1.Maximum = Me.HScrollBar1.Maximum
        Me.VScrollBar1.LargeChange = Me.HScrollBar1.LargeChange
        Me.VScrollBar1.SmallChange = Me.HScrollBar1.SmallChange

        Me.HScrollBar1.Enabled = False
        Me.VScrollBar1.Enabled = False
        MyFlowChartNameSpace.F_C.PaintAll(Me.PictureBox1, 1, MyFlowChartNameSpace.F_C.TopOfFile("FlowChart"))
    End Sub

    Private Sub ToolStripDropDownSelectSymbol_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownSelectSymbol.DropDownItemClicked
        Const ButtonStartedName As String = "FlowChart Window Select Symbol Drop Down Button"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(88, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownSelectSymbol.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub


    Private Sub ToolStripTextBoxMyInputText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToolStripTextBoxMyInputText.KeyPress
        Const ButtonStartedName As String = "Flow Chart  MyDeCompile."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(89, ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.WhatKey(e) ' Do something with any special keys
        If e.KeyChar <> vbCr Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.FlowChartTextBox = Me.ToolStripTextBoxMyInputText.ToString
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyDeCompileLine(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.FlowChartTextBox) 'MyUniverse.MySS.Inputs.KeyFile)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        Me.ToolStripTextBoxMyInputText.Text = "" 'clear out the line that was just compiled
        Me.LabelProgramStatus.Text = "" ' Blank out the syntax also
    End Sub

    Private Sub ToolStripDropDownSelectSymbol_TextChanged(sender As Object, e As EventArgs) Handles ToolStripDropDownSelectSymbol.TextChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(90, " Flowchart Window.vb -->Tool Strip Drop Down Select Symbol _Text()")
        End If

        If MyFlowChartNameSpace.F_C.MyUniverse.ProgramAlive = False Then Exit Sub
        If Me.ToolStripDropDownSelectSymbol.Text <> sender.ToString Then 'if it's not alread done
            Me.ToolStripDropDownSelectSymbol.Text = sender.ToString
            Exit Sub
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName = sender.ToString
        If SymbolWindow.ToolStripDropDownSelectSymbol.Text <> sender.ToString Then
            SymbolWindow.ToolStripDropDownSelectSymbol.Text = sender.ToString
        End If

    End Sub

    Private Sub ToolStripButtonMoveHand_Click(sender As Object, e As EventArgs) Handles ToolStripButtonMoveHand.Click
        Const ButtonStartedName As String = "FlowChart Window Hand Movement"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 67 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(91, ButtonStartedName)
        End If
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.MyCmdModeString = "cmdmovehand"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub FlowChartWindow_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If MyFlowChartNameSpace.F_C.MyUniverse.ProgramAlive = False Then
            MyFlowChartNameSpace.F_C.Init()
        End If
    End Sub


    Private Sub FlowChartWindow_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace1(1110, "Flow Chart Editor - Paint")
        End If
        MyFlowChartNameSpace.F_C.PaintAll(Me.PictureBox1, MyFlowChartNameSpace.F_C.TopOfFile("FlowChart"), MyFlowChartNameSpace.F_C.TopOfFile("FlowChart"))
    End Sub
End Class
