<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlowChartWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlowChartWindow))
        Me.ToolStripFlowChart = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSymbolForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonOptionForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonOpenForm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownSelectSymbol = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripButtonAddPath = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAddConstant = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMoveObject = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDeleteobject = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMoveHand = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRedraw = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBoxMyInputText = New System.Windows.Forms.ToolStripTextBox()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ToolStripFlowChart.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripFlowChart
        '
        Me.ToolStripFlowChart.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStripFlowChart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSymbolForm, Me.ToolStripButtonOptionForm, Me.ToolStripButtonOpenForm, Me.ToolStripDropDownSelectSymbol, Me.ToolStripButtonAddPath, Me.ToolStripButtonAddConstant, Me.ToolStripButtonMoveObject, Me.ToolStripButtonDeleteobject, Me.ToolStripButtonMoveHand, Me.ToolStripButtonZoomIn, Me.ToolStripButtonZoomOut, Me.ToolStripButtonRedraw, Me.ToolStripTextBoxMyInputText, Me.LabelProgramStatus})
        Me.ToolStripFlowChart.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripFlowChart.Name = "ToolStripFlowChart"
        Me.ToolStripFlowChart.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStripFlowChart.Size = New System.Drawing.Size(945, 55)
        Me.ToolStripFlowChart.TabIndex = 0
        Me.ToolStripFlowChart.Text = "ToolStrip1"
        '
        'ToolStripButtonSymbolForm
        '
        Me.ToolStripButtonSymbolForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSymbolForm.Image = CType(resources.GetObject("ToolStripButtonSymbolForm.Image"), System.Drawing.Image)
        Me.ToolStripButtonSymbolForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSymbolForm.Name = "ToolStripButtonSymbolForm"
        Me.ToolStripButtonSymbolForm.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonSymbolForm.Text = "Symbol Editor"
        '
        'ToolStripButtonOptionForm
        '
        Me.ToolStripButtonOptionForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOptionForm.Image = CType(resources.GetObject("ToolStripButtonOptionForm.Image"), System.Drawing.Image)
        Me.ToolStripButtonOptionForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOptionForm.Name = "ToolStripButtonOptionForm"
        Me.ToolStripButtonOptionForm.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonOptionForm.Text = "Options"
        '
        'ToolStripButtonOpenForm
        '
        Me.ToolStripButtonOpenForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOpenForm.Image = CType(resources.GetObject("ToolStripButtonOpenForm.Image"), System.Drawing.Image)
        Me.ToolStripButtonOpenForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOpenForm.Name = "ToolStripButtonOpenForm"
        Me.ToolStripButtonOpenForm.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonOpenForm.Text = "File I/O"
        '
        'ToolStripDropDownSelectSymbol
        '
        Me.ToolStripDropDownSelectSymbol.Image = CType(resources.GetObject("ToolStripDropDownSelectSymbol.Image"), System.Drawing.Image)
        Me.ToolStripDropDownSelectSymbol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownSelectSymbol.Name = "ToolStripDropDownSelectSymbol"
        Me.ToolStripDropDownSelectSymbol.Size = New System.Drawing.Size(92, 52)
        Me.ToolStripDropDownSelectSymbol.Text = "Start"
        '
        'ToolStripButtonAddPath
        '
        Me.ToolStripButtonAddPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAddPath.Image = CType(resources.GetObject("ToolStripButtonAddPath.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddPath.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddPath.Name = "ToolStripButtonAddPath"
        Me.ToolStripButtonAddPath.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonAddPath.Text = "Add Path"
        '
        'ToolStripButtonAddConstant
        '
        Me.ToolStripButtonAddConstant.Image = CType(resources.GetObject("ToolStripButtonAddConstant.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddConstant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddConstant.Name = "ToolStripButtonAddConstant"
        Me.ToolStripButtonAddConstant.Size = New System.Drawing.Size(132, 52)
        Me.ToolStripButtonAddConstant.Text = "Add Constant"
        '
        'ToolStripButtonMoveObject
        '
        Me.ToolStripButtonMoveObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveObject.Image = CType(resources.GetObject("ToolStripButtonMoveObject.Image"), System.Drawing.Image)
        Me.ToolStripButtonMoveObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveObject.Name = "ToolStripButtonMoveObject"
        Me.ToolStripButtonMoveObject.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonMoveObject.Text = "Move"
        '
        'ToolStripButtonDeleteobject
        '
        Me.ToolStripButtonDeleteobject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDeleteobject.Image = CType(resources.GetObject("ToolStripButtonDeleteobject.Image"), System.Drawing.Image)
        Me.ToolStripButtonDeleteobject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDeleteobject.Name = "ToolStripButtonDeleteobject"
        Me.ToolStripButtonDeleteobject.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonDeleteobject.Text = "Delete"
        '
        'ToolStripButtonMoveHand
        '
        Me.ToolStripButtonMoveHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMoveHand.Image = CType(resources.GetObject("ToolStripButtonMoveHand.Image"), System.Drawing.Image)
        Me.ToolStripButtonMoveHand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMoveHand.Name = "ToolStripButtonMoveHand"
        Me.ToolStripButtonMoveHand.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonMoveHand.Text = "Move Center"
        '
        'ToolStripButtonZoomIn
        '
        Me.ToolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonZoomIn.Image = CType(resources.GetObject("ToolStripButtonZoomIn.Image"), System.Drawing.Image)
        Me.ToolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonZoomIn.Name = "ToolStripButtonZoomIn"
        Me.ToolStripButtonZoomIn.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonZoomIn.Text = "Zoom In"
        '
        'ToolStripButtonZoomOut
        '
        Me.ToolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonZoomOut.Image = CType(resources.GetObject("ToolStripButtonZoomOut.Image"), System.Drawing.Image)
        Me.ToolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonZoomOut.Name = "ToolStripButtonZoomOut"
        Me.ToolStripButtonZoomOut.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonZoomOut.Text = "Zoom Out"
        '
        'ToolStripButtonRedraw
        '
        Me.ToolStripButtonRedraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRedraw.Image = CType(resources.GetObject("ToolStripButtonRedraw.Image"), System.Drawing.Image)
        Me.ToolStripButtonRedraw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRedraw.Name = "ToolStripButtonRedraw"
        Me.ToolStripButtonRedraw.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonRedraw.Text = "Redraw"
        '
        'ToolStripTextBoxMyInputText
        '
        Me.ToolStripTextBoxMyInputText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBoxMyInputText.Name = "ToolStripTextBoxMyInputText"
        Me.ToolStripTextBoxMyInputText.Size = New System.Drawing.Size(98, 55)
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(39, 52)
        Me.LabelProgramStatus.Text = "Status"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.HelpProvider1.SetHelpNavigator(Me.PictureBox1, System.Windows.Forms.HelpNavigator.Find)
        Me.PictureBox1.Location = New System.Drawing.Point(26, 81)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.HelpProvider1.SetShowHelp(Me.PictureBox1, True)
        Me.PictureBox1.Size = New System.Drawing.Size(708, 326)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(26, 55)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(708, 25)
        Me.HScrollBar1.TabIndex = 4
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(0, 80)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(25, 326)
        Me.VScrollBar1.TabIndex = 5
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "E:\Flow Chart Help Files\FlowChartHelp011.html"
        '
        'FlowChartWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(945, 521)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ToolStripFlowChart)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "FlowChartWindow"
        Me.Text = "FlowChart Computer Languare Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripFlowChart.ResumeLayout(False)
        Me.ToolStripFlowChart.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripFlowChart As ToolStrip
    Friend WithEvents ToolStripButtonSymbolForm As ToolStripButton
    Friend WithEvents ToolStripButtonOptionForm As ToolStripButton
    Friend WithEvents ToolStripButtonOpenForm As ToolStripButton
    Friend WithEvents ToolStripButtonAddPath As ToolStripButton
    Friend WithEvents ToolStripButtonMoveObject As ToolStripButton
    Friend WithEvents ToolStripButtonDeleteobject As ToolStripButton
    Friend WithEvents ToolStripButtonAddConstant As ToolStripButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolStripButtonRedraw As ToolStripButton
    Friend WithEvents ToolStripButtonZoomIn As ToolStripButton
    Friend WithEvents ToolStripButtonZoomOut As ToolStripButton
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents ToolStripDropDownSelectSymbol As ToolStripDropDownButton
    Friend WithEvents ToolStripTextBoxMyInputText As ToolStripTextBox
    Friend WithEvents LabelProgramStatus As ToolStripLabel
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents ToolStripButtonMoveHand As ToolStripButton
End Class
