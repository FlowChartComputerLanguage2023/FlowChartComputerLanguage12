
Public Class OptionScreen
    Public Const ShowScreen As Int32 = 1
    Public Const HideScreen As Int32 = 0
    Public Const LeaveScreenAlone As Int32 = -1

    'todo : No selection on the line/widths on the option screen

    '5********************************************
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCheckAllData.Click
        Const ButtonStartedName As String = " Checking All information."
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.Abug(9010, " Click Check All Button ", "Started ", Now)
        MyFlowChartNameSpace.F_C.CheckAll()
        MyFlowChartNameSpace.F_C.Abug(9011, " Click Check All Button ", "Finished", Now)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '1*********************************************
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartForm_FromOptionScreen.Click
        Const ButtonStartedName As String = "Displaying FlowChart Screen."
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowScreen, HideScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '2************************************************
    Private Sub ToolStripButtonSymbolForm_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSymbolForm_FromOptionScreen.Click
        Const ButtonStartedName As String = " Displaying Symbol Screen."
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.Abug(9013, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ShowAllForms(HideScreen, ShowScreen, HideScreen, LeaveScreenAlone, LeaveScreenAlone, LeaveScreenAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '3****************************************************
    Private Sub ToolStripButtonDeleteErrorMsgs_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDeleteErrorMsgs.Click
        Const ButtonStartedName As String = " Deleting all Error Messages in the FlowChart."
        MyFlowChartNameSpace.F_C.Abug(9014, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DeleteAllErrorMessages()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '4******************************************************
    Private Sub ToolStripButtonDeleteUnusedSymbols_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDeleteUnusedSymbols.Click
        Const ButtonStartedName As String = " Deleting all symbols that were not used in the FlowChart."
        MyFlowChartNameSpace.F_C.Abug(9015, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyRemoveAllUnusedSymbols()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub
    '6*******************************************************
    Private Sub ToolStripButtonDump_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDump.Click
        Const ButtonStartedName As String = ".   CHECK:   \symbolDump.txt and also \FlowChartDump.txt"
        MyFlowChartNameSpace.F_C.Abug(9016, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.Dump2("ButtonPressed")
        MyFlowChartNameSpace.F_C.Dump1()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    Private Sub OptionScreen_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Const ButtonStartedName As String = "Resize Option Screen"
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        Resizeme()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '    Private Sub OptionScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    ' Get them in the right place to start with
    '    Const ButtonStartedName As String = "Option Screen Loading"
    '    If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
    '        Resizeme()
    '    End Sub


    Private Sub Resizeme()
        Me.CheckedListBoxOptionSelection.Top = Me.ToolStrip1.Top + Me.ToolStrip1.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        Me.ComboBoxDebug.Top = Me.ToolStrip1.Top + Me.ToolStrip1.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls

        Me.CheckedListBoxOptionSelection.Width = Me.Width / 3 - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls
        Me.ComboBoxDebug.Width = (Me.Width / 3) * 2 - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls * 10

        Me.ComboBoxDebug.Left = Me.CheckedListBoxOptionSelection.Left + Me.CheckedListBoxOptionSelection.Width + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls * 4

        Me.CheckedListBoxOptionSelection.Height = Me.Height - Me.CheckedListBoxOptionSelection.Top - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.constantDistanceBetweenControls * 10
    End Sub


    Private Sub ToolStripDropDownComputerLanguage_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripDropDownComputerLanguage.DropDownItemClicked
        Const ButtonStartedName As String = "Computer language is : "
        If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub

        MyFlowChartNameSpace.F_C.UpDateComputerLanguage()
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules(Me)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatusOnly(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

End Class
