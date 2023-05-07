
#Const MyDebug = 50

Public Class OptionsWindow
    Friend Const ShowWindow As Int32 = 1
    Friend Const HideWindow As Int32 = 0
    Friend Const LeaveWindowAlone As Int32 = -1

    'todo : No selection on the line/widths on the option Window

    '5********************************************
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCheckAllData.Click
        Const ButtonStartedName As String = " Checking All information."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(1, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.MSG_Abug(2000, " Click Check All Button ", "Started ", Now.ToString)
        MyFlowChartNameSpace.F_C.CheckAll()
        MyFlowChartNameSpace.F_C.MSG_Abug(2001, " Click Check All Button ", "Finished", Now.ToString)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    '1*********************************************
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFlowChartForm_FromOptionsWindow.Click
        Const ButtonStartedName As String = "Displaying FlowChart Window."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(2, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.ShowAllForms(ShowWindow, HideWindow, HideWindow, LeaveWindowAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '2************************************************
    Private Sub ToolStripButtonSymbolForm_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSymbolForm_FromOptionsWindow.Click
        Const ButtonStartedName As String = " Displaying Symbol Window."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(3, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.MSG_Ainfo(2003, "Switching to Symbol Window from Option Window ", MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.SelectedSymbolName, ButtonStartedName)
        MyFlowChartNameSpace.F_C.ShowAllForms(HideWindow, ShowWindow, HideWindow, LeaveWindowAlone)
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '3****************************************************
    Private Sub ToolStripButtonDeleteErrorMsgs_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDeleteErrorMsgs.Click
        Const ButtonStartedName As String = " Deleting all Error Messages in the FlowChart."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(4, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.MSG_Abug(2004, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DeleteAllErrorMessages()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '4******************************************************
    Private Sub ToolStripButtonDeleteUnusedSymbols_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDeleteUnusedSymbols.Click
        Const ButtonStartedName As String = " Deleting all symbols that were not used in the FlowChart."
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(5, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.MSG_Abug(2005, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyRemoveAllUnusedSymbols()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub
    '6*******************************************************
    Private Sub ToolStripButtonDump_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDump.Click
        Const ButtonStartedName As String = ".CHECK:   \symbolDump.txt and also \FlowChartDump.txt"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(6, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.MSG_Abug(2006, "", "", ButtonStartedName)
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        MyFlowChartNameSpace.F_C.Dump3(2313, "ButtonPressed")
        MyFlowChartNameSpace.F_C.Dump1()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName) : MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
        MyFlowChartNameSpace.F_C.MyButtonsEnableRules()
    End Sub

    Private Sub OptionsWindow_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Const ButtonStartedName As String = "Resize Option Window"
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 98 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(7, "Option Window - " + ButtonStartedName)
        End If
        MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName)
        Resizeme()
        MyFlowChartNameSpace.F_C.ButtonFinished(ButtonStartedName)
        MyFlowChartNameSpace.F_C.DisplayStatus(Me.LabelProgramStatus.Text, ButtonStartedName)
    End Sub

    '    Private Sub OptionsWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    ' Get them in the right place to start with
    '    Const ButtonStartedName As String = "Option Window Loading"
    '    If MyFlowChartNameSpace.F_C.ButtonStarted(ButtonStartedName) = False Then Exit Sub
    '    Resizeme()
    '    End Sub


    Private Sub Resizeme()
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 91 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(8, "Option Window - Resize Me()")
        End If
        Me.CheckedListBoxOptionSelection.Top = Me.ToolStripOption.Top + Me.ToolStripOption.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        Me.ComboBoxDebug.Top = Me.ToolStripOption.Top + Me.ToolStripOption.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls

        Me.CheckedListBoxOptionSelection.Width = CInt(Me.Width / 3 - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls)
        Me.ComboBoxDebug.Width = CInt((Me.Width / 3) * 2 - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls * 10)

        Me.ComboBoxDebug.Left = Me.CheckedListBoxOptionSelection.Left + Me.CheckedListBoxOptionSelection.Width + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls * 4

        Me.CheckedListBoxOptionSelection.Height = Me.Height - Me.CheckedListBoxOptionSelection.Top - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls * 10

        Me.ListBoxLanguage.Left = Me.CheckedListBoxOptionSelection.Left + Me.CheckedListBoxOptionSelection.Width + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        Me.ListBoxLanguage.Top = Me.ComboBoxDebug.Top + Me.ComboBoxDebug.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        Me.ListBoxLanguage.Height = Me.CheckedListBoxOptionSelection.Top + Me.CheckedListBoxOptionSelection.Height - Me.ListBoxLanguage.Top
        Me.ListBoxLanguage.Width = CInt((Me.Width - Me.CheckedListBoxOptionSelection.Width - MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls) / 2)

        Me.ListBoxDialect.Left = Me.ListBoxLanguage.Left + Me.ListBoxLanguage.Width + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        Me.ListBoxDialect.Top = Me.ComboBoxDebug.Top + Me.ComboBoxDebug.Height + MyFlowChartNameSpace.F_C.MyUniverse.SysGen.Constants.constantDistanceBetweenControls
        Me.ListBoxDialect.Height = Me.ListBoxLanguage.Height
        Me.ListBoxDialect.Width = Me.ListBoxLanguage.Width
    End Sub






    ' removed when I changed to have sub items (Dialects) of the computer languages 
    Private Sub ListboxLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxLanguage.SelectedValueChanged
        Dim X As String
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(9, "Option Window - Selected Language Index Changed")
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.C_L_LanguageClassName = CStr(Me.ListBoxLanguage.SelectedItem)
        X = MyFlowChartNameSpace.F_C.FindLanguageClassName(MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.C_L_Directory)
        MyFlowChartNameSpace.F_C.MakeDialectListFromFile(X)
    End Sub

    Private Sub ListboxDialect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxDialect.SelectedIndexChanged
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 96 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(10, "Option Window - Selected Dialect Index Changed")
        End If
        MyFlowChartNameSpace.F_C.MyUniverse.ProgramOptions.C_L_DialectName = CStr(Me.ListBoxDialect.SelectedItem)
        MyFlowChartNameSpace.F_C.ListBoxLanguageDialect()
    End Sub

End Class
