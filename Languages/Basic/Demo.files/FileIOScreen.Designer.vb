<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileInputOutputScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileInputOutputScreen))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonShowFlowChart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSaveFileAs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonFlowChartToSourceCode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSourceCodeToFlowChartCode = New System.Windows.Forms.ToolStripButton()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.TextBoxStatus11 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus10 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus9 = New System.Windows.Forms.TextBox()
        Me.TextBoxNetLinks = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus7 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus6 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus5 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus4 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus3 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus2 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus1 = New System.Windows.Forms.TextBox()
        Me.PB_LabelSizeDataType = New System.Windows.Forms.Label()
        Me.PB_LabelSizeColor = New System.Windows.Forms.Label()
        Me.PB_LabelSizeFlowChart = New System.Windows.Forms.Label()
        Me.PB_LabelSizeSymbol = New System.Windows.Forms.Label()
        Me.PB_Size5 = New System.Windows.Forms.ProgressBar()
        Me.PB_Size4 = New System.Windows.Forms.ProgressBar()
        Me.PB_Size3 = New System.Windows.Forms.ProgressBar()
        Me.PB_Size2 = New System.Windows.Forms.ProgressBar()
        Me.PB_Size1 = New System.Windows.Forms.ProgressBar()
        Me.TextBoxStatus12 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus13 = New System.Windows.Forms.TextBox()
        Me.TextBoxStatus14 = New System.Windows.Forms.TextBox()
        Me.PB_LabelSizeNamed = New System.Windows.Forms.Label()
        Me.LabelKeyWords = New System.Windows.Forms.Label()
        Me.ProgressBarKeyWords = New System.Windows.Forms.ProgressBar()
        Me.LabelOperators = New System.Windows.Forms.Label()
        Me.ProgressBarOperators = New System.Windows.Forms.ProgressBar()
        Me.LabelFunctions = New System.Windows.Forms.Label()
        Me.ProgressBarFunctions = New System.Windows.Forms.ProgressBar()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonShowFlowChart, Me.ToolStripButtonOpenFile, Me.ToolStripButtonSaveFileAs, Me.ToolStripButtonFlowChartToSourceCode, Me.ToolStripButtonSourceCodeToFlowChartCode, Me.LabelProgramStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(2324, 55)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonShowFlowChart
        '
        Me.ToolStripButtonShowFlowChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonShowFlowChart.Image = CType(resources.GetObject("ToolStripButtonShowFlowChart.Image"), System.Drawing.Image)
        Me.ToolStripButtonShowFlowChart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonShowFlowChart.Name = "ToolStripButtonShowFlowChart"
        Me.ToolStripButtonShowFlowChart.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonShowFlowChart.Text = "ToolStripButton1"
        '
        'ToolStripButtonOpenFile
        '
        Me.ToolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOpenFile.Image = CType(resources.GetObject("ToolStripButtonOpenFile.Image"), System.Drawing.Image)
        Me.ToolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOpenFile.Name = "ToolStripButtonOpenFile"
        Me.ToolStripButtonOpenFile.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonOpenFile.Text = "ToolStripButton2"
        '
        'ToolStripButtonSaveFileAs
        '
        Me.ToolStripButtonSaveFileAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSaveFileAs.Image = CType(resources.GetObject("ToolStripButtonSaveFileAs.Image"), System.Drawing.Image)
        Me.ToolStripButtonSaveFileAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSaveFileAs.Name = "ToolStripButtonSaveFileAs"
        Me.ToolStripButtonSaveFileAs.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonSaveFileAs.Text = "ToolStripButton3"
        '
        'ToolStripButtonFlowChartToSourceCode
        '
        Me.ToolStripButtonFlowChartToSourceCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFlowChartToSourceCode.Image = CType(resources.GetObject("ToolStripButtonFlowChartToSourceCode.Image"), System.Drawing.Image)
        Me.ToolStripButtonFlowChartToSourceCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFlowChartToSourceCode.Name = "ToolStripButtonFlowChartToSourceCode"
        Me.ToolStripButtonFlowChartToSourceCode.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonFlowChartToSourceCode.Text = "ToolStripButton4"
        '
        'ToolStripButtonSourceCodeToFlowChartCode
        '
        Me.ToolStripButtonSourceCodeToFlowChartCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSourceCodeToFlowChartCode.Image = CType(resources.GetObject("ToolStripButtonSourceCodeToFlowChartCode.Image"), System.Drawing.Image)
        Me.ToolStripButtonSourceCodeToFlowChartCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSourceCodeToFlowChartCode.Name = "ToolStripButtonSourceCodeToFlowChartCode"
        Me.ToolStripButtonSourceCodeToFlowChartCode.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonSourceCodeToFlowChartCode.Text = "ToolStripButton5"
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(115, 52)
        Me.LabelProgramStatus.Text = "Status"
        '
        'TextBoxStatus11
        '
        Me.TextBoxStatus11.Enabled = False
        Me.TextBoxStatus11.Location = New System.Drawing.Point(1518, 842)
        Me.TextBoxStatus11.Name = "TextBoxStatus11"
        Me.TextBoxStatus11.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus11.TabIndex = 66
        '
        'TextBoxStatus10
        '
        Me.TextBoxStatus10.Enabled = False
        Me.TextBoxStatus10.Location = New System.Drawing.Point(1518, 790)
        Me.TextBoxStatus10.Name = "TextBoxStatus10"
        Me.TextBoxStatus10.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus10.TabIndex = 65
        '
        'TextBoxStatus9
        '
        Me.TextBoxStatus9.Enabled = False
        Me.TextBoxStatus9.Location = New System.Drawing.Point(1518, 740)
        Me.TextBoxStatus9.Name = "TextBoxStatus9"
        Me.TextBoxStatus9.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus9.TabIndex = 64
        '
        'TextBoxNetLinks
        '
        Me.TextBoxNetLinks.Enabled = False
        Me.TextBoxNetLinks.Location = New System.Drawing.Point(1518, 690)
        Me.TextBoxNetLinks.Name = "TextBoxNetLinks"
        Me.TextBoxNetLinks.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxNetLinks.TabIndex = 63
        '
        'TextBoxStatus7
        '
        Me.TextBoxStatus7.Enabled = False
        Me.TextBoxStatus7.Location = New System.Drawing.Point(1518, 640)
        Me.TextBoxStatus7.Name = "TextBoxStatus7"
        Me.TextBoxStatus7.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus7.TabIndex = 62
        '
        'TextBoxStatus6
        '
        Me.TextBoxStatus6.Enabled = False
        Me.TextBoxStatus6.Location = New System.Drawing.Point(1518, 590)
        Me.TextBoxStatus6.Name = "TextBoxStatus6"
        Me.TextBoxStatus6.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus6.TabIndex = 61
        '
        'TextBoxStatus5
        '
        Me.TextBoxStatus5.Enabled = False
        Me.TextBoxStatus5.Location = New System.Drawing.Point(1518, 540)
        Me.TextBoxStatus5.Name = "TextBoxStatus5"
        Me.TextBoxStatus5.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus5.TabIndex = 60
        '
        'TextBoxStatus4
        '
        Me.TextBoxStatus4.Enabled = False
        Me.TextBoxStatus4.Location = New System.Drawing.Point(1518, 490)
        Me.TextBoxStatus4.Name = "TextBoxStatus4"
        Me.TextBoxStatus4.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus4.TabIndex = 59
        '
        'TextBoxStatus3
        '
        Me.TextBoxStatus3.Enabled = False
        Me.TextBoxStatus3.Location = New System.Drawing.Point(1518, 440)
        Me.TextBoxStatus3.Name = "TextBoxStatus3"
        Me.TextBoxStatus3.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus3.TabIndex = 58
        '
        'TextBoxStatus2
        '
        Me.TextBoxStatus2.Enabled = False
        Me.TextBoxStatus2.Location = New System.Drawing.Point(1518, 390)
        Me.TextBoxStatus2.Name = "TextBoxStatus2"
        Me.TextBoxStatus2.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus2.TabIndex = 57
        '
        'TextBoxStatus1
        '
        Me.TextBoxStatus1.Enabled = False
        Me.TextBoxStatus1.Location = New System.Drawing.Point(1518, 340)
        Me.TextBoxStatus1.Name = "TextBoxStatus1"
        Me.TextBoxStatus1.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus1.TabIndex = 56
        '
        'PB_LabelSizeDataType
        '
        Me.PB_LabelSizeDataType.AutoSize = True
        Me.PB_LabelSizeDataType.Location = New System.Drawing.Point(154, 618)
        Me.PB_LabelSizeDataType.Name = "PB_LabelSizeDataType"
        Me.PB_LabelSizeDataType.Size = New System.Drawing.Size(155, 37)
        Me.PB_LabelSizeDataType.TabIndex = 55
        Me.PB_LabelSizeDataType.Text = "DataType"
        '
        'PB_LabelSizeColor
        '
        Me.PB_LabelSizeColor.AutoSize = True
        Me.PB_LabelSizeColor.Location = New System.Drawing.Point(154, 553)
        Me.PB_LabelSizeColor.Name = "PB_LabelSizeColor"
        Me.PB_LabelSizeColor.Size = New System.Drawing.Size(110, 37)
        Me.PB_LabelSizeColor.TabIndex = 54
        Me.PB_LabelSizeColor.Text = "Colors"
        '
        'PB_LabelSizeFlowChart
        '
        Me.PB_LabelSizeFlowChart.AutoSize = True
        Me.PB_LabelSizeFlowChart.Location = New System.Drawing.Point(154, 489)
        Me.PB_LabelSizeFlowChart.Name = "PB_LabelSizeFlowChart"
        Me.PB_LabelSizeFlowChart.Size = New System.Drawing.Size(164, 37)
        Me.PB_LabelSizeFlowChart.TabIndex = 53
        Me.PB_LabelSizeFlowChart.Text = "FlowChart"
        '
        'PB_LabelSizeSymbol
        '
        Me.PB_LabelSizeSymbol.AutoSize = True
        Me.PB_LabelSizeSymbol.Location = New System.Drawing.Point(154, 425)
        Me.PB_LabelSizeSymbol.Name = "PB_LabelSizeSymbol"
        Me.PB_LabelSizeSymbol.Size = New System.Drawing.Size(139, 37)
        Me.PB_LabelSizeSymbol.TabIndex = 52
        Me.PB_LabelSizeSymbol.Text = "Symbols"
        '
        'PB_Size5
        '
        Me.PB_Size5.Enabled = False
        Me.PB_Size5.Location = New System.Drawing.Point(648, 617)
        Me.PB_Size5.Name = "PB_Size5"
        Me.PB_Size5.Size = New System.Drawing.Size(644, 58)
        Me.PB_Size5.TabIndex = 50
        '
        'PB_Size4
        '
        Me.PB_Size4.Enabled = False
        Me.PB_Size4.Location = New System.Drawing.Point(648, 552)
        Me.PB_Size4.Name = "PB_Size4"
        Me.PB_Size4.Size = New System.Drawing.Size(644, 58)
        Me.PB_Size4.TabIndex = 49
        '
        'PB_Size3
        '
        Me.PB_Size3.Enabled = False
        Me.PB_Size3.Location = New System.Drawing.Point(648, 488)
        Me.PB_Size3.Name = "PB_Size3"
        Me.PB_Size3.Size = New System.Drawing.Size(644, 58)
        Me.PB_Size3.TabIndex = 48
        '
        'PB_Size2
        '
        Me.PB_Size2.Enabled = False
        Me.PB_Size2.Location = New System.Drawing.Point(648, 424)
        Me.PB_Size2.Name = "PB_Size2"
        Me.PB_Size2.Size = New System.Drawing.Size(644, 58)
        Me.PB_Size2.TabIndex = 47
        '
        'PB_Size1
        '
        Me.PB_Size1.Enabled = False
        Me.PB_Size1.Location = New System.Drawing.Point(648, 360)
        Me.PB_Size1.Name = "PB_Size1"
        Me.PB_Size1.Size = New System.Drawing.Size(644, 58)
        Me.PB_Size1.TabIndex = 46
        '
        'TextBoxStatus12
        '
        Me.TextBoxStatus12.Enabled = False
        Me.TextBoxStatus12.Location = New System.Drawing.Point(1518, 901)
        Me.TextBoxStatus12.Name = "TextBoxStatus12"
        Me.TextBoxStatus12.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus12.TabIndex = 67
        '
        'TextBoxStatus13
        '
        Me.TextBoxStatus13.Enabled = False
        Me.TextBoxStatus13.Location = New System.Drawing.Point(1518, 951)
        Me.TextBoxStatus13.Name = "TextBoxStatus13"
        Me.TextBoxStatus13.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus13.TabIndex = 68
        '
        'TextBoxStatus14
        '
        Me.TextBoxStatus14.Enabled = False
        Me.TextBoxStatus14.Location = New System.Drawing.Point(1518, 1004)
        Me.TextBoxStatus14.Name = "TextBoxStatus14"
        Me.TextBoxStatus14.Size = New System.Drawing.Size(576, 44)
        Me.TextBoxStatus14.TabIndex = 69
        '
        'PB_LabelSizeNamed
        '
        Me.PB_LabelSizeNamed.AutoSize = True
        Me.PB_LabelSizeNamed.Location = New System.Drawing.Point(154, 360)
        Me.PB_LabelSizeNamed.Name = "PB_LabelSizeNamed"
        Me.PB_LabelSizeNamed.Size = New System.Drawing.Size(121, 37)
        Me.PB_LabelSizeNamed.TabIndex = 51
        Me.PB_LabelSizeNamed.Text = "Named"
        '
        'LabelKeyWords
        '
        Me.LabelKeyWords.AutoSize = True
        Me.LabelKeyWords.Location = New System.Drawing.Point(154, 760)
        Me.LabelKeyWords.Name = "LabelKeyWords"
        Me.LabelKeyWords.Size = New System.Drawing.Size(173, 37)
        Me.LabelKeyWords.TabIndex = 71
        Me.LabelKeyWords.Text = "Key Words"
        '
        'ProgressBarKeyWords
        '
        Me.ProgressBarKeyWords.Enabled = False
        Me.ProgressBarKeyWords.Location = New System.Drawing.Point(648, 760)
        Me.ProgressBarKeyWords.Name = "ProgressBarKeyWords"
        Me.ProgressBarKeyWords.Size = New System.Drawing.Size(644, 58)
        Me.ProgressBarKeyWords.TabIndex = 70
        '
        'LabelOperators
        '
        Me.LabelOperators.AutoSize = True
        Me.LabelOperators.Location = New System.Drawing.Point(154, 842)
        Me.LabelOperators.Name = "LabelOperators"
        Me.LabelOperators.Size = New System.Drawing.Size(160, 37)
        Me.LabelOperators.TabIndex = 73
        Me.LabelOperators.Text = "Operators"
        '
        'ProgressBarOperators
        '
        Me.ProgressBarOperators.Enabled = False
        Me.ProgressBarOperators.Location = New System.Drawing.Point(648, 842)
        Me.ProgressBarOperators.Name = "ProgressBarOperators"
        Me.ProgressBarOperators.Size = New System.Drawing.Size(644, 58)
        Me.ProgressBarOperators.TabIndex = 72
        '
        'LabelFunctions
        '
        Me.LabelFunctions.AutoSize = True
        Me.LabelFunctions.Location = New System.Drawing.Point(154, 921)
        Me.LabelFunctions.Name = "LabelFunctions"
        Me.LabelFunctions.Size = New System.Drawing.Size(157, 37)
        Me.LabelFunctions.TabIndex = 75
        Me.LabelFunctions.Text = "Functions"
        '
        'ProgressBarFunctions
        '
        Me.ProgressBarFunctions.Enabled = False
        Me.ProgressBarFunctions.Location = New System.Drawing.Point(648, 921)
        Me.ProgressBarFunctions.Name = "ProgressBarFunctions"
        Me.ProgressBarFunctions.Size = New System.Drawing.Size(644, 58)
        Me.ProgressBarFunctions.TabIndex = 74
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(1518, 1122)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(576, 44)
        Me.TextBox1.TabIndex = 76
        '
        'FileInputOutputScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2324, 1250)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LabelFunctions)
        Me.Controls.Add(Me.ProgressBarFunctions)
        Me.Controls.Add(Me.LabelOperators)
        Me.Controls.Add(Me.ProgressBarOperators)
        Me.Controls.Add(Me.LabelKeyWords)
        Me.Controls.Add(Me.ProgressBarKeyWords)
        Me.Controls.Add(Me.TextBoxStatus14)
        Me.Controls.Add(Me.TextBoxStatus13)
        Me.Controls.Add(Me.TextBoxStatus12)
        Me.Controls.Add(Me.TextBoxStatus11)
        Me.Controls.Add(Me.TextBoxStatus10)
        Me.Controls.Add(Me.TextBoxStatus9)
        Me.Controls.Add(Me.TextBoxNetLinks)
        Me.Controls.Add(Me.TextBoxStatus7)
        Me.Controls.Add(Me.TextBoxStatus6)
        Me.Controls.Add(Me.TextBoxStatus5)
        Me.Controls.Add(Me.TextBoxStatus4)
        Me.Controls.Add(Me.TextBoxStatus3)
        Me.Controls.Add(Me.TextBoxStatus2)
        Me.Controls.Add(Me.TextBoxStatus1)
        Me.Controls.Add(Me.PB_LabelSizeDataType)
        Me.Controls.Add(Me.PB_LabelSizeColor)
        Me.Controls.Add(Me.PB_LabelSizeFlowChart)
        Me.Controls.Add(Me.PB_LabelSizeSymbol)
        Me.Controls.Add(Me.PB_LabelSizeNamed)
        Me.Controls.Add(Me.PB_Size5)
        Me.Controls.Add(Me.PB_Size4)
        Me.Controls.Add(Me.PB_Size3)
        Me.Controls.Add(Me.PB_Size2)
        Me.Controls.Add(Me.PB_Size1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FileInputOutputScreen"
        Me.Text = "FileInputOutputScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonShowFlowChart As ToolStripButton
    Friend WithEvents ToolStripButtonOpenFile As ToolStripButton
    Friend WithEvents ToolStripButtonSaveFileAs As ToolStripButton
    Friend WithEvents ToolStripButtonFlowChartToSourceCode As ToolStripButton
    Friend WithEvents ToolStripButtonSourceCodeToFlowChartCode As ToolStripButton
    Friend WithEvents TextBoxStatus11 As TextBox
    Friend WithEvents TextBoxStatus10 As TextBox
    Friend WithEvents TextBoxStatus9 As TextBox
    Friend WithEvents TextBoxNetLinks As TextBox
    Friend WithEvents TextBoxStatus7 As TextBox
    Friend WithEvents TextBoxStatus6 As TextBox
    Friend WithEvents TextBoxStatus5 As TextBox
    Friend WithEvents TextBoxStatus4 As TextBox
    Friend WithEvents TextBoxStatus3 As TextBox
    Friend WithEvents TextBoxStatus2 As TextBox
    Friend WithEvents TextBoxStatus1 As TextBox
    Friend WithEvents PB_LabelSizeDataType As Label
    Friend WithEvents PB_LabelSizeColor As Label
    Friend WithEvents PB_LabelSizeFlowChart As Label
    Friend WithEvents PB_LabelSizeSymbol As Label
    Friend WithEvents PB_Size5 As ProgressBar
    Friend WithEvents PB_Size4 As ProgressBar
    Friend WithEvents PB_Size3 As ProgressBar
    Friend WithEvents PB_Size2 As ProgressBar
    Friend WithEvents PB_Size1 As ProgressBar
    Friend WithEvents TextBoxStatus12 As TextBox
    Friend WithEvents TextBoxStatus13 As TextBox
    Friend WithEvents TextBoxStatus14 As TextBox
    Friend WithEvents PB_LabelSizeNamed As Label
    Friend WithEvents LabelKeyWords As Label
    Friend WithEvents ProgressBarKeyWords As ProgressBar
    Friend WithEvents LabelOperators As Label
    Friend WithEvents ProgressBarOperators As ProgressBar
    Friend WithEvents LabelFunctions As Label
    Friend WithEvents ProgressBarFunctions As ProgressBar
    Friend WithEvents LabelProgramStatus As ToolStripLabel
    Friend WithEvents TextBox1 As TextBox
End Class
