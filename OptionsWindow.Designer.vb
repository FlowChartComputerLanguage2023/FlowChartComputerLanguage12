<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OptionsWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsWindow))
        Me.ToolStripOption = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSymbolForm_FromOptionsWindow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeleteErrorMsgs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeleteUnusedSymbols = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCheckAllData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDump = New System.Windows.Forms.ToolStripButton()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxPathName = New System.Windows.Forms.ToolStripComboBox()
        Me.ComboBoxDebug = New System.Windows.Forms.ComboBox()
        Me.CheckedListBoxOptionSelection = New System.Windows.Forms.CheckedListBox()
        Me.ListBoxLanguage = New System.Windows.Forms.ListBox()
        Me.ListBoxDialect = New System.Windows.Forms.ListBox()
        Me.ToolStripOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripOption
        '
        Me.ToolStripOption.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStripOption.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonFlowChartForm_FromOptionsWindow, Me.ToolStripButtonSymbolForm_FromOptionsWindow, Me.ToolStripButtonDeleteErrorMsgs, Me.ToolStripButtonDeleteUnusedSymbols, Me.ToolStripButtonCheckAllData, Me.ToolStripButtonDump, Me.LabelProgramStatus, Me.ToolStripComboBoxPathName})
        Me.ToolStripOption.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripOption.Name = "ToolStripOption"
        Me.ToolStripOption.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripOption.Size = New System.Drawing.Size(703, 55)
        Me.ToolStripOption.TabIndex = 0
        Me.ToolStripOption.Text = "ToolStrip1"
        '
        'ToolStripButtonFlowChartForm_FromOptionsWindow
        '
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.Image = CType(resources.GetObject("ToolStripButtonFlowChartForm_FromOptionsWindow.Image"), System.Drawing.Image)
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.Name = "ToolStripButtonFlowChartForm_FromOptionsWindow"
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonFlowChartForm_FromOptionsWindow.Text = "ToolStripButton1"
        '
        'ToolStripButtonSymbolForm_FromOptionsWindow
        '
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.Image = CType(resources.GetObject("ToolStripButtonSymbolForm_FromOptionsWindow.Image"), System.Drawing.Image)
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.Name = "ToolStripButtonSymbolForm_FromOptionsWindow"
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonSymbolForm_FromOptionsWindow.Text = "ToolStripButton2"
        '
        'ToolStripButtonDeleteErrorMsgs
        '
        Me.ToolStripButtonDeleteErrorMsgs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDeleteErrorMsgs.Image = CType(resources.GetObject("ToolStripButtonDeleteErrorMsgs.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeleteErrorMsgs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeleteErrorMsgs.Name = "ToolStripButtonDeleteErrorMsgs"
        Me.ToolStripButtonDeleteErrorMsgs.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonDeleteErrorMsgs.Text = "ToolStripButton4"
        '
        'ToolStripButtonDeleteUnusedSymbols
        '
        Me.ToolStripButtonDeleteUnusedSymbols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDeleteUnusedSymbols.Image = CType(resources.GetObject("ToolStripButtonDeleteUnusedSymbols.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeleteUnusedSymbols.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeleteUnusedSymbols.Name = "ToolStripButtonDeleteUnusedSymbols"
        Me.ToolStripButtonDeleteUnusedSymbols.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonDeleteUnusedSymbols.Text = "ToolStripButton5"
        '
        'ToolStripButtonCheckAllData
        '
        Me.ToolStripButtonCheckAllData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCheckAllData.Image = CType(resources.GetObject("ToolStripButtonCheckAllData.Image"), System.Drawing.Image)
        Me.ToolStripButtonCheckAllData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCheckAllData.Name = "ToolStripButtonCheckAllData"
        Me.ToolStripButtonCheckAllData.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonCheckAllData.Text = "ToolStripButton7"
        '
        'ToolStripButtonDump
        '
        Me.ToolStripButtonDump.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDump.Image = CType(resources.GetObject("ToolStripButtonDump.Image"), System.Drawing.Image)
        Me.ToolStripButtonDump.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDump.Name = "ToolStripButtonDump"
        Me.ToolStripButtonDump.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonDump.Text = "ToolStripButton10"
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(42, 52)
        Me.LabelProgramStatus.Text = "Status:"
        '
        'ToolStripComboBoxPathName
        '
        Me.ToolStripComboBoxPathName.Name = "ToolStripComboBoxPathName"
        Me.ToolStripComboBoxPathName.Size = New System.Drawing.Size(75, 55)
        '
        'ComboBoxDebug
        '
        Me.ComboBoxDebug.FormattingEnabled = True
        Me.ComboBoxDebug.Location = New System.Drawing.Point(304, 362)
        Me.ComboBoxDebug.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxDebug.Name = "ComboBoxDebug"
        Me.ComboBoxDebug.Size = New System.Drawing.Size(370, 21)
        Me.ComboBoxDebug.TabIndex = 3
        '
        'CheckedListBoxOptionSelection
        '
        Me.CheckedListBoxOptionSelection.FormattingEnabled = True
        Me.CheckedListBoxOptionSelection.Location = New System.Drawing.Point(10, 57)
        Me.CheckedListBoxOptionSelection.Margin = New System.Windows.Forms.Padding(1)
        Me.CheckedListBoxOptionSelection.Name = "CheckedListBoxOptionSelection"
        Me.CheckedListBoxOptionSelection.Size = New System.Drawing.Size(136, 139)
        Me.CheckedListBoxOptionSelection.TabIndex = 4
        '
        'ListBoxLanguage
        '
        Me.ListBoxLanguage.FormattingEnabled = True
        Me.ListBoxLanguage.Location = New System.Drawing.Point(397, 189)
        Me.ListBoxLanguage.Margin = New System.Windows.Forms.Padding(1)
        Me.ListBoxLanguage.Name = "ListBoxLanguage"
        Me.ListBoxLanguage.Size = New System.Drawing.Size(94, 134)
        Me.ListBoxLanguage.TabIndex = 6
        '
        'ListBoxDialect
        '
        Me.ListBoxDialect.FormattingEnabled = True
        Me.ListBoxDialect.Location = New System.Drawing.Point(597, 212)
        Me.ListBoxDialect.Margin = New System.Windows.Forms.Padding(1)
        Me.ListBoxDialect.Name = "ListBoxDialect"
        Me.ListBoxDialect.Size = New System.Drawing.Size(77, 108)
        Me.ListBoxDialect.TabIndex = 7
        '
        'OptionsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 393)
        Me.Controls.Add(Me.ListBoxDialect)
        Me.Controls.Add(Me.ListBoxLanguage)
        Me.Controls.Add(Me.CheckedListBoxOptionSelection)
        Me.Controls.Add(Me.ComboBoxDebug)
        Me.Controls.Add(Me.ToolStripOption)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "OptionsWindow"
        Me.Text = "OptionsWindow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripOption.ResumeLayout(False)
        Me.ToolStripOption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripOption As ToolStrip
    Friend WithEvents ToolStripButtonFlowChartForm_FromOptionsWindow As ToolStripButton
    Friend WithEvents ToolStripButtonSymbolForm_FromOptionsWindow As ToolStripButton
    Friend WithEvents ToolStripButtonDeleteErrorMsgs As ToolStripButton
    Friend WithEvents ToolStripButtonDeleteUnusedSymbols As ToolStripButton
    Friend WithEvents ToolStripButtonCheckAllData As ToolStripButton
    Friend WithEvents ToolStripButtonDump As ToolStripButton
    Friend WithEvents ComboBoxDebug As ComboBox
    Friend WithEvents CheckedListBoxOptionSelection As CheckedListBox
    Friend WithEvents LabelProgramStatus As ToolStripLabel
    Friend WithEvents ListBoxLanguage As ListBox
    Friend WithEvents ToolStripComboBoxPathName As ToolStripComboBox
    Friend WithEvents ListBoxDialect As ListBox
End Class
