

Option Strict On
Option Infer Off
Option Compare Text
Option Explicit On
#Const MyDebug = 50


Public Class FileInputOutputWindow
    Friend Const ShowWindow As Int32 = 1
    Friend Const HideWindow As Int32 = 0

    '2********************************************************************************************
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpenFile.Click
        'Open File
        Const ButtonStartedName As String = " Opening FlowChart " '& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyOpen("read")
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '**************************************************************************
    Private Sub ToolStripButtonSaveFileAs_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSaveFileAs.Click
        'Save file
        Const ButtonStartedName As String = " Saving the FlowChart into " ''& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyOpen("write")
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '***********************************************************************
    Private Sub ToolStripButtonFlowChartToSourceCode_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartToSourceCode.Click
        'Compile
        Const ButtonStartedName As String = " Converting from the FlowChart to Source Code.File Save as " ''& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCompile(FlowChartWindow.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '1**************************************************************
    'Show FlowChart Window
    Private Sub ToolStripButtonShowFlowChart_Click(sender As Object, e As EventArgs) Handles ToolStripButtonShowFlowChart.Click
        Const ButtonStartedName As String = " Showing FlowChart Window."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowWindow, HideWindow, HideWindow, HideWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '*************************************************************
    Private Sub ToolStripButtonSourceCodeToFlowChartCode_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSourceCodeToFlowChartCode.Click
        'flow10'Private Sub FileInputOutput_ButtonSourceToFlowChart_Click(sender As Object, e As EventArgs)
        'Decompile
        Const ButtonStartedName As String = "Converting from souce code into the FlowChart."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyDeCompile(FlowChartWindow.PictureBox1, "")
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub ToolStripButtonShowOptionsWindow_Click(sender As Object, e As EventArgs) Handles ToolStripButtonShowOptionsWindow.Click
        Const ButtonStartedName As String = " Showing Option Window."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, HideWindow, ShowWindow, HideWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub ToolStripButtonShowSymbolWindow_Click(sender As Object, e As EventArgs) Handles ToolStripButtonShowSymbolWindow.Click
        Const ButtonStartedName As String = " Showing Symbol Window."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, ShowWindow, HideWindow, HideWindow)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

End Class