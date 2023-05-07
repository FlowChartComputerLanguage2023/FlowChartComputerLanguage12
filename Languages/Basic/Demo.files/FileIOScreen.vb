

Option Strict On
Option Infer Off
Option Compare Text
Option Explicit On


Public Class FileInputOutputScreen
    Public Const ShowScreen As Int32 = 1
    Public Const HideScreen As Int32 = 0
    Public Const LeaveScreenAlone As Int32 = -1
    '2********************************************************************************************
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpenFile.Click
        'Open File
        Const ButtonStartedName As String = " Opening FlowChart " ''''''''''''''''''& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyOpen(SymbolScreen.PictureBox1, "read")
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '**************************************************************************
    Private Sub ToolStripButtonSaveFileAs_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSaveFileAs.Click
        'Save file
        Const ButtonStartedName As String = " Saving the FlowChart into " ''''''''''''''''& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyOpen(SymbolScreen.PictureBox1, "write")
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '***********************************************************************
    Private Sub ToolStripButtonFlowChartToSourceCode_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartToSourceCode.Click
        'Compile
        Const ButtonStartedName As String = " Converting from the FlowChart to Source Code.  File Save as " '''''''& MyFlowChartNameSpace.F_C.DrillDown_FileName & "."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyCompile(SymbolScreen.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '1**************************************************************
    'Show FlowChart Screen
    Private Sub ToolStripButtonShowFlowChart_Click(sender As Object, e As EventArgs) Handles ToolStripButtonShowFlowChart.Click
        Const ButtonStartedName As String = " Showing FlowChart Screen."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowScreen, HideScreen, HideScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '*************************************************************
    Private Sub ToolStripButtonSourceCodeToFlowChartCode_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSourceCodeToFlowChartCode.Click
        'flow10'Private Sub FileInputOutput_ButtonSourceToFlowChart_Click(sender As Object, e As EventArgs)
        'Decompile
        Const ButtonStartedName As String = "Converting from souce code into the FlowChart."
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
        MyFlowChartNameSpace.F_C.MyDeCompile(SymbolScreen.PictureBox1)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
End Class