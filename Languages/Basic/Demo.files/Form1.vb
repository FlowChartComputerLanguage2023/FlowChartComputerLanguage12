
Option Strict On
Option Infer Off
Option Compare Text
Option Explicit On

Public Class FlowChartScreen

    Public Const ShowScreen As Int32 = 1
    Public Const HideScreen As Int32 = 0
    Public Const LeaveScreenAlone As Int32 = -1
    'flow10'This belongs in status or option screen*************************???????
    Private Sub ButtonCheck_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = " CheckAll."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.CheckAll()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    'flow10' This belongs in FiliIOScreen
    Private Sub ButtonCompile_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = " MyCompile."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCompile(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    'flow10'This belongs in FileInputOutputScreen
    Private Sub Decompile_Click(sender As Object, e As EventArgs)
        Const ButtonStartedName As String = " MyDeCompile."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyDeCompile(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '****************************************************************
    ' 10 This is used to redraw the FlowChart (Cause it gets messed up, and I have to fix that one of these days)
    Private Sub ToolStripButtonRedraw_Click(sender As Object, e As EventArgs) Handles ButtonRedraw.Click
        Const ButtonStartedName As String = " Redraw."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Screen(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    ' 11 This is used to enlarge the flowchart. (You see a part of the picture)
    Private Sub ToolStripButtonZoomIn_Click(sender As Object, e As EventArgs) Handles ButtonZoomIn.Click
        Const ButtonStartedName As String = " Zoom in."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyZoomIn(e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '****************************************************************
    ' 12 This is used to reduce the flowchart on the screen (You can see more of the picture)
    Private Sub ToolStripButtonZoomOut_Click(sender As Object, e As EventArgs) Handles ButtonZoomOut.Click
        Const ButtonStartedName As String = " Zoom Out."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyZoomOut(e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    '****************************************************************
    ' 8 This is used to put a constant (entered in the textbox on the toolstrip)
    'You should/(Must?) place it on a path (end points or turn of a path)
    Private Sub ToolStripButtonAddConstant_Click(sender As Object, e As EventArgs) Handles ButtonAddConstant.Click
        Const ButtonStartedName As String = " Command Add Constant."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdaddconstant"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub FlowChartScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Const ButtonStartedName As String = "Loading Start Screen"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Init()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    '****************************************************************
    'This goto the FlowChartScreen
    Private Sub ButtonSymbolForm_Click(sender As Object, e As EventArgs) Handles ButtonSymbolForm.Click
        Const ButtonStartedName As String = " Showing the symbol screen."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdaddsymbol"
        MyFlowChartNameSpace.F_C.ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    '****************************************************************
    '6 This moves what ever is closest to where the mouseUP is
    Private Sub ButtonMoveObject_Click(sender As Object, e As EventArgs) Handles ButtonMoveObject.Click
        Const ButtonStartedName As String = " Command Move Object."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdmove"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    ' This will delete what ever is closest to the mouse down
    ' Advise that you move first to somewhere that is clear, and then delete it.
    Private Sub ButtonDeleteobject_Click(sender As Object, e As EventArgs) Handles ButtonDeleteobject.Click
        Const ButtonStartedName As String = " Command Delete Object."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmddelete"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Const ButtonStartedName As String = "FLowChart Screen H Scroll"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Screen(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Const ButtonStartedName As String = "FlowChart Screen V Scrool"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.Clear_Screen(Me.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub


    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Const ButtonStartedName As String = "FlowChart Screen Mouse Down"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mousedown"
        MyFlowChartNameSpace.F_C.MyMouseDown(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Const ButtonStartedName As String = "FlowChart Screen Mouse Up"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mouseup"
        MyFlowChartNameSpace.F_C.MyMouseUp(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Const ButtonStartedName As String = "FlowChart Screen Mouse Move"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyUniverse.MyMouseAndDrawing.MouseStatus = "mousemove"
        MyFlowChartNameSpace.F_C.MyMouseMove(Me.PictureBox1, e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel
        Const ButtonStartedName As String = "FlowChart Screen Mouse Wheel Moved"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyMouseWheel(e)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    '3 This goes to the FileInputOutput screen
    Private Sub ToolStripButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpenForm.Click
        Const ButtonStartedName As String = " Displaying File Input/Output and status'."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideScreen, HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '****************************************************************
    '2This goes to the optionScreen
    Private Sub ToolStripButtonOptions_Click(sender As Object, e As EventArgs) Handles ButtonOptionForm.Click
        Const ButtonStartedName As String = " Displaying Options."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideScreen, HideScreen, ShowScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '****************************************************************
    '4 This set the mode to add a path when clicking the first end of the line, holding to the last end of the line
    Private Sub ToolStripButtonAddPath_Click(sender As Object, e As EventArgs) Handles ButtonAddPath.Click
        Const ButtonStartedName As String = " AddPath."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCmdModeString = "cmdaddpath"
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub



    '**************************************************************
    'This sill compile the textbox into code. (Must determine if this is a compile or a add constant)
    'Error (Will convert code to FlowChart, when I use this as a constant data enter field from AddConstant)
    Private Sub ToolStripTextBoxMyInputText_LostFocus(sender As Object, e As EventArgs) Handles ToolStripTextBoxMyInputText.LostFocus
        Const ButtonStartedName As String = "FlowChart Screen Input lost focus"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        If Mid(Me.ToolStripTextBoxMyInputText.Text, 1, 1) = "/" Then
            MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.Inputline = Me.ToolStripTextBoxMyInputText.Text
            MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.KeyLine = MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.Inputline
            MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.KeyLine = MyFlowChartNameSpace.F_C.MyFixLine(MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.KeyLine)
            MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.LineNumberIn = MyFlowChartNameSpace.F_C.MyUniverse.MySS.Inputs.LineNumberIn + 1
            MyFlowChartNameSpace.F_C.ImportLine(Me.PictureBox1)
            Me.ToolStripTextBoxMyInputText.Text = "" ' clear out the command
        Else
            MyFlowChartNameSpace.F_C.MyDeCompileLine(Me.PictureBox1, Me.ToolStripTextBoxMyInputText.Text)
            Me.ToolStripTextBoxMyInputText.Text = "" ' clear out the command
        End If
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ToolStripDropDownSelectSymbolX_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownSelectSymbol.Click
        Const ButtonStartedName As String = "FlowChart Screen Select Symbol X Click"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        SymbolScreen.ToolStripDropDownSelectSymbol.Text = Me.ToolStripDropDownSelectSymbol.Text
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub FlowChartScreen_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'FIXED ?this caused recursion and needs to be repaired
        Const ButtonStartedName As String = "FlowChart Screen Redraw from Resize"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        ResizeMe()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub ResizeMe()
        Dim X As Int32
        X = MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls

        Me.VScrollBar1.Left = X
        Me.HScrollBar1.Left = Me.VScrollBar1.Width + X
        Me.PictureBox1.Left = Me.HScrollBar1.Left

        Me.HScrollBar1.Top = Me.ToolStrip1.Height + X
        Me.VScrollBar1.Top = Me.HScrollBar1.Top + Me.HScrollBar1.Height
        Me.PictureBox1.Top = Me.HScrollBar1.Top + Me.HScrollBar1.Height

        Me.HScrollBar1.Width = Me.Width - (Me.VScrollBar1.Left + Me.VScrollBar1.Width) - X * 6
        Me.PictureBox1.Width = Me.Width - (Me.VScrollBar1.Left + Me.VScrollBar1.Width) - X * 6

        Me.VScrollBar1.Height = Me.Height - Me.VScrollBar1.Top - X * 10
        Me.PictureBox1.Height = Me.VScrollBar1.Height

        ' Now Set the scroll bars 

        Me.HScrollBar1.Minimum = 1
        Me.HScrollBar1.Maximum = 32000
        Me.HScrollBar1.LargeChange = 1000
        Me.HScrollBar1.SmallChange = 100

        Me.VScrollBar1.Minimum = 1
        Me.VScrollBar1.Maximum = 32000
        Me.VScrollBar1.LargeChange = 1000
        Me.VScrollBar1.SmallChange = 100

    End Sub

    Private Sub ToolStripDropDownSelectSymbol_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownSelectSymbol.DropDownItemClicked
        Const ButtonStartedName As String = "FlowChart Screen Select Symbol Drop Down Button"
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        Me.ToolStripDropDownSelectSymbol.Text = e.ClickedItem.ToString()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
    End Sub
End Class



