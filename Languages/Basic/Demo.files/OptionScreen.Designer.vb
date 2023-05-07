<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OptionScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionScreen))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonFlowChartForm_FromOptionScreen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSymbolForm_FromOptionScreen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeleteErrorMsgs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeleteUnusedSymbols = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCheckAllData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDump = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownComputerLanguage = New System.Windows.Forms.ToolStripDropDownButton()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBoxDebug = New System.Windows.Forms.ComboBox()
        Me.CheckedListBoxOptionSelection = New System.Windows.Forms.CheckedListBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonFlowChartForm_FromOptionScreen, Me.ToolStripButtonSymbolForm_FromOptionScreen, Me.ToolStripButtonDeleteErrorMsgs, Me.ToolStripButtonDeleteUnusedSymbols, Me.ToolStripButtonCheckAllData, Me.ToolStripButtonDump, Me.ToolStripDropDownComputerLanguage, Me.LabelProgramStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(2293, 57)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonFlowChartForm_FromOptionScreen
        '
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.Image = CType(resources.GetObject("ToolStripButtonFlowChartForm_FromOptionScreen.Image"), System.Drawing.Image)
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.Name = "ToolStripButtonFlowChartForm_FromOptionScreen"
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonFlowChartForm_FromOptionScreen.Text = "ToolStripButton1"
        '
        'ToolStripButtonSymbolForm_FromOptionScreen
        '
        Me.ToolStripButtonSymbolForm_FromOptionScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSymbolForm_FromOptionScreen.Image = CType(resources.GetObject("ToolStripButtonSymbolForm_FromOptionScreen.Image"), System.Drawing.Image)
        Me.ToolStripButtonSymbolForm_FromOptionScreen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSymbolForm_FromOptionScreen.Name = "ToolStripButtonSymbolForm_FromOptionScreen"
        Me.ToolStripButtonSymbolForm_FromOptionScreen.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonSymbolForm_FromOptionScreen.Text = "ToolStripButton2"
        '
        'ToolStripButtonDeleteErrorMsgs
        '
        Me.ToolStripButtonDeleteErrorMsgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDeleteErrorMsgs.Image = CType(resources.GetObject("ToolStripButtonDeleteErrorMsgs.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeleteErrorMsgs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeleteErrorMsgs.Name = "ToolStripButtonDeleteErrorMsgs"
        Me.ToolStripButtonDeleteErrorMsgs.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonDeleteErrorMsgs.Text = "ToolStripButton4"
        '
        'ToolStripButtonDeleteUnusedSymbols
        '
        Me.ToolStripButtonDeleteUnusedSymbols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDeleteUnusedSymbols.Image = CType(resources.GetObject("ToolStripButtonDeleteUnusedSymbols.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeleteUnusedSymbols.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeleteUnusedSymbols.Name = "ToolStripButtonDeleteUnusedSymbols"
        Me.ToolStripButtonDeleteUnusedSymbols.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonDeleteUnusedSymbols.Text = "ToolStripButton5"
        '
        'ToolStripButtonCheckAllData
        '
        Me.ToolStripButtonCheckAllData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCheckAllData.Image = CType(resources.GetObject("ToolStripButtonCheckAllData.Image"), System.Drawing.Image)
        Me.ToolStripButtonCheckAllData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCheckAllData.Name = "ToolStripButtonCheckAllData"
        Me.ToolStripButtonCheckAllData.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonCheckAllData.Text = "ToolStripButton7"
        '
        'ToolStripButtonDump
        '
        Me.ToolStripButtonDump.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDump.Image = CType(resources.GetObject("ToolStripButtonDump.Image"), System.Drawing.Image)
        Me.ToolStripButtonDump.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDump.Name = "ToolStripButtonDump"
        Me.ToolStripButtonDump.Size = New System.Drawing.Size(52, 54)
        Me.ToolStripButtonDump.Text = "ToolStripButton10"
        '
        'ToolStripDropDownComputerLanguage
        '
        Me.ToolStripDropDownComputerLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownComputerLanguage.Image = CType(resources.GetObject("ToolStripDropDownComputerLanguage.Image"), System.Drawing.Image)
        Me.ToolStripDropDownComputerLanguage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownComputerLanguage.Name = "ToolStripDropDownComputerLanguage"
        Me.ToolStripDropDownComputerLanguage.Size = New System.Drawing.Size(79, 54)
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(123, 54)
        Me.LabelProgramStatus.Text = "Status:"
        '
        'ComboBoxDebug
        '
        Me.ComboBoxDebug.FormattingEnabled = True
        Me.ComboBoxDebug.Location = New System.Drawing.Point(964, 153)
        Me.ComboBoxDebug.Name = "ComboBoxDebug"
        Me.ComboBoxDebug.Size = New System.Drawing.Size(1163, 45)
        Me.ComboBoxDebug.TabIndex = 3
        '
        'CheckedListBoxOptionSelection
        '
        Me.CheckedListBoxOptionSelection.FormattingEnabled = True
        Me.CheckedListBoxOptionSelection.Location = New System.Drawing.Point(23, 132)
        Me.CheckedListBoxOptionSelection.Name = "CheckedListBoxOptionSelection"
        Me.CheckedListBoxOptionSelection.Size = New System.Drawing.Size(916, 862)
        Me.CheckedListBoxOptionSelection.TabIndex = 4
        '
        'OptionScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2293, 1026)
        Me.Controls.Add(Me.CheckedListBoxOptionSelection)
        Me.Controls.Add(Me.ComboBoxDebug)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "OptionScreen"
        Me.Text = "OptionScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButtonFlowChartForm_FromOptionScreen As ToolStripButton
    Friend WithEvents ToolStripButtonSymbolForm_FromOptionScreen As ToolStripButton
    Friend WithEvents ToolStripButtonDeleteErrorMsgs As ToolStripButton
    Friend WithEvents ToolStripButtonDeleteUnusedSymbols As ToolStripButton
    Friend WithEvents ToolStripButtonCheckAllData As ToolStripButton
    Friend WithEvents ToolStripButtonDump As ToolStripButton
    Friend WithEvents ComboBoxDebug As ComboBox
    Friend WithEvents CheckedListBoxOptionSelection As CheckedListBox
    Friend WithEvents ToolStripDropDownComputerLanguage As ToolStripDropDownButton
    Friend WithEvents LabelProgramStatus As ToolStripLabel
End Class
