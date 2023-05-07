Public Class HelpScreen
    Public Const ShowScreen As Int32 = 1
    Public Const HideScreen As Int32 = 0
    Public Const LeaveScreenAlone As Int32 = -1

    Private Sub ToolStripButtonHelpScreen_to_FlowChart_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHelpScreen_to_FlowChart.Click
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowScreen, HideScreen, HideScreen, HideScreen, HideScreen, HideScreen)
    End Sub
End Class