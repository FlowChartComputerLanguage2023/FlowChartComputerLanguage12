<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlowChartScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlowChartScreen))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonSymbolForm = New System.Windows.Forms.ToolStripButton()
        Me.ButtonOptionForm = New System.Windows.Forms.ToolStripButton()
        Me.ButtonOpenForm = New System.Windows.Forms.ToolStripButton()
        Me.ButtonAddPath = New System.Windows.Forms.ToolStripButton()
        Me.ButtonMoveObject = New System.Windows.Forms.ToolStripButton()
        Me.ButtonDeleteobject = New System.Windows.Forms.ToolStripButton()
        Me.ButtonAddConstant = New System.Windows.Forms.ToolStripButton()
        Me.ButtonRedraw = New System.Windows.Forms.ToolStripButton()
        Me.ButtonZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.ButtonZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownSelectSymbol = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripTextBoxMyInputText = New System.Windows.Forms.ToolStripTextBox()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonSymbolForm, Me.ButtonOptionForm, Me.ButtonOpenForm, Me.ButtonAddPath, Me.ButtonMoveObject, Me.ButtonDeleteobject, Me.ButtonAddConstant, Me.ButtonRedraw, Me.ButtonZoomIn, Me.ButtonZoomOut, Me.ToolStripDropDownSelectSymbol, Me.ToolStripTextBoxMyInputText, Me.LabelProgramStatus})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(2781, 57)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonSymbolForm
        '
        Me.ButtonSymbolForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonSymbolForm.Image = CType(resources.GetObject("ButtonSymbolForm.Image"), System.Drawing.Image)
        Me.ButtonSymbolForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSymbolForm.Name = "ButtonSymbolForm"
        Me.ButtonSymbolForm.Size = New System.Drawing.Size(52, 54)
        Me.ButtonSymbolForm.Text = "ToolStripButton1"
        '
        'ButtonOptionForm
        '
        Me.ButtonOptionForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonOptionForm.Image = CType(resources.GetObject("ButtonOptionForm.Image"), System.Drawing.Image)
        Me.ButtonOptionForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonOptionForm.Name = "ButtonOptionForm"
        Me.ButtonOptionForm.Size = New System.Drawing.Size(52, 54)
        Me.ButtonOptionForm.Text = "ToolStripButton2"
        '
        'ButtonOpenForm
        '
        Me.ButtonOpenForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonOpenForm.Image = CType(resources.GetObject("ButtonOpenForm.Image"), System.Drawing.Image)
        Me.ButtonOpenForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonOpenForm.Name = "ButtonOpenForm"
        Me.ButtonOpenForm.Size = New System.Drawing.Size(52, 54)
        Me.ButtonOpenForm.Text = "ToolStripButton3"
        '
        'ButtonAddPath
        '
        Me.ButtonAddPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddPath.Image = CType(resources.GetObject("ButtonAddPath.Image"), System.Drawing.Image)
        Me.ButtonAddPath.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddPath.Name = "ButtonAddPath"
        Me.ButtonAddPath.Size = New System.Drawing.Size(52, 54)
        Me.ButtonAddPath.Text = "ToolStripButton4"
        '
        'ButtonMoveObject
        '
        Me.ButtonMoveObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonMoveObject.Image = CType(resources.GetObject("ButtonMoveObject.Image"), System.Drawing.Image)
        Me.ButtonMoveObject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonMoveObject.Name = "ButtonMoveObject"
        Me.ButtonMoveObject.Size = New System.Drawing.Size(52, 54)
        Me.ButtonMoveObject.Text = "ToolStripButton6"
        '
        'ButtonDeleteobject
        '
        Me.ButtonDeleteobject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonDeleteobject.Image = CType(resources.GetObject("ButtonDeleteobject.Image"), System.Drawing.Image)
        Me.ButtonDeleteobject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonDeleteobject.Name = "ButtonDeleteobject"
        Me.ButtonDeleteobject.Size = New System.Drawing.Size(52, 54)
        Me.ButtonDeleteobject.Text = "ToolStripButton7"
        '
        'ButtonAddConstant
        '
        Me.ButtonAddConstant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddConstant.Image = CType(resources.GetObject("ButtonAddConstant.Image"), System.Drawing.Image)
        Me.ButtonAddConstant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddConstant.Name = "ButtonAddConstant"
        Me.ButtonAddConstant.Size = New System.Drawing.Size(52, 54)
        Me.ButtonAddConstant.Text = "ToolStripButton10"
        '
        'ButtonRedraw
        '
        Me.ButtonRedraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonRedraw.Image = CType(resources.GetObject("ButtonRedraw.Image"), System.Drawing.Image)
        Me.ButtonRedraw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRedraw.Name = "ButtonRedraw"
        Me.ButtonRedraw.Size = New System.Drawing.Size(52, 54)
        Me.ButtonRedraw.Text = "ToolStripButton16"
        '
        'ButtonZoomIn
        '
        Me.ButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonZoomIn.Image = CType(resources.GetObject("ButtonZoomIn.Image"), System.Drawing.Image)
        Me.ButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonZoomIn.Name = "ButtonZoomIn"
        Me.ButtonZoomIn.Size = New System.Drawing.Size(52, 54)
        Me.ButtonZoomIn.Text = "ToolStripButton17"
        '
        'ButtonZoomOut
        '
        Me.ButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonZoomOut.Image = CType(resources.GetObject("ButtonZoomOut.Image"), System.Drawing.Image)
        Me.ButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonZoomOut.Name = "ButtonZoomOut"
        Me.ButtonZoomOut.Size = New System.Drawing.Size(52, 54)
        Me.ButtonZoomOut.Text = "ToolStripButton18"
        '
        'ToolStripDropDownSelectSymbol
        '
        Me.ToolStripDropDownSelectSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownSelectSymbol.Image = CType(resources.GetObject("ToolStripDropDownSelectSymbol.Image"), System.Drawing.Image)
        Me.ToolStripDropDownSelectSymbol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownSelectSymbol.Name = "ToolStripDropDownSelectSymbol"
        Me.ToolStripDropDownSelectSymbol.Size = New System.Drawing.Size(79, 54)
        Me.ToolStripDropDownSelectSymbol.Text = "ToolStripDropDownButton1"
        '
        'ToolStripTextBoxMyInputText
        '
        Me.ToolStripTextBoxMyInputText.Name = "ToolStripTextBoxMyInputText"
        Me.ToolStripTextBoxMyInputText.Size = New System.Drawing.Size(300, 57)
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(262, 54)
        Me.LabelProgramStatus.Text = "ToolStripLabel1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.PictureBox1.Location = New System.Drawing.Point(32, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(2242, 927)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(32, 55)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(1188, 25)
        Me.HScrollBar1.TabIndex = 4
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(0, 87)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(25, 912)
        Me.VScrollBar1.TabIndex = 5
        '
        'FlowChartScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(19.0!, 37.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(2781, 1144)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FlowChartScreen"
        Me.Text = "FlowChart Computer Languare Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ButtonSymbolForm As ToolStripButton
    Friend WithEvents ButtonOptionForm As ToolStripButton
    Friend WithEvents ButtonOpenForm As ToolStripButton
    Friend WithEvents ButtonAddPath As ToolStripButton
    Friend WithEvents ButtonMoveObject As ToolStripButton
    Friend WithEvents ButtonDeleteobject As ToolStripButton
    Friend WithEvents ButtonAddConstant As ToolStripButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonRedraw As ToolStripButton
    Friend WithEvents ButtonZoomIn As ToolStripButton
    Friend WithEvents ButtonZoomOut As ToolStripButton
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents ToolStripDropDownSelectSymbol As ToolStripDropDownButton
    Friend WithEvents ToolStripTextBoxMyInputText As ToolStripTextBox
    Friend WithEvents LabelProgramStatus As ToolStripLabel
End Class
