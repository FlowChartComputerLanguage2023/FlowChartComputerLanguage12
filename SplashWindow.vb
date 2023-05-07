Imports System.ComponentModel
#Const MyDebug = 85

Public NotInheritable Class SplashWindow

    'TODO: This form can easily be set as the splash Window for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashWindow1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        Me.Show()
        Me.BringToFront()
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 91 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(102, "Splash Window - _Load")
        End If
        MyFlowChartNameSpace.F_C.MyTraceSystem()
        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 50 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(103, "Application Version set to " + Version.Text)
        End If

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 50 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(101, "CopyRight set to " + Copyright.Text)
        End If
    End Sub


    Private Sub UpdateTextBox(ByVal NewText As String)
        If MyFlowChartNameSpace.F_C.MyUniverse.MyDebug > 69 Then
            MyFlowChartNameSpace.F_C.MSG_MyTrace3(1371, "Splash Window - Update Text Box")
        End If
        If Me.InvokeRequired Then
            Dim args() As String = {NewText}
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), args)
            Return
        End If
        'Label_caller.Text = phone_number
        My.Forms.FlowChartWindow.Show()
    End Sub





End Class
