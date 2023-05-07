<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SymbolWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SymbolWindow))
        Me.ToolStripSymbolTop = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonOptionForm_FromSymbolWindow = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAddPoint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAddLine = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonNewSymbol = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonUpdateSymbol = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.LabelProgramStatus = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSymbolBottom = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownSelectSymbol = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownRotation = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownDataType = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownPathLineStyle = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownButtonColor = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownLineWidth = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownInputOutput = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownNumberOfBytes = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripDropDownPathStart = New System.Windows.Forms.ToolStripDropDownButton()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownPathEnd = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNamedSymbolName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxNamedNameOfFile = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxNamedStroke = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxNamedOpCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxSymbolVersionAuthor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxNamedNotes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxNamedProgramText = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxNamedSyntax = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxNamedDescription = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ComboBoxPointNameList = New System.Windows.Forms.ComboBox()
        Me.ComboBoxLineNameList = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.HelpProviderSymbolWindow = New System.Windows.Forms.HelpProvider()
        Me.HelpProviderPictureBox1 = New System.Windows.Forms.HelpProvider()
        Me.ToolStripSymbolTop.SuspendLayout()
        Me.ToolStripSymbolBottom.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSymbolTop
        '
        Me.ToolStripSymbolTop.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStripSymbolTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonFlowChartForm_FromSymbolWindow, Me.ToolStripButtonOptionForm_FromSymbolWindow, Me.ToolStripButtonAddPoint, Me.ToolStripButtonAddLine, Me.ToolStripButtonMove, Me.ToolStripButtonDelete, Me.ToolStripButtonNewSymbol, Me.ToolStripButtonUpdateSymbol, Me.ToolStripTextBox1, Me.LabelProgramStatus})
        Me.ToolStripSymbolTop.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripSymbolTop.Name = "ToolStripSymbolTop"
        Me.ToolStripSymbolTop.Size = New System.Drawing.Size(1051, 55)
        Me.ToolStripSymbolTop.TabIndex = 0
        Me.ToolStripSymbolTop.Text = "ToolStrip1"
        '
        'ToolStripButtonFlowChartForm_FromSymbolWindow
        '
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.Image = CType(resources.GetObject("ToolStripButtonFlowChartForm_FromSymbolWindow.Image"), System.Drawing.Image)
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.Name = "ToolStripButtonFlowChartForm_FromSymbolWindow"
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonFlowChartForm_FromSymbolWindow.Text = "FlowChart Window"
        '
        'ToolStripButtonOptionForm_FromSymbolWindow
        '
        Me.ToolStripButtonOptionForm_FromSymbolWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonOptionForm_FromSymbolWindow.Image = CType(resources.GetObject("ToolStripButtonOptionForm_FromSymbolWindow.Image"), System.Drawing.Image)
        Me.ToolStripButtonOptionForm_FromSymbolWindow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOptionForm_FromSymbolWindow.Name = "ToolStripButtonOptionForm_FromSymbolWindow"
        Me.ToolStripButtonOptionForm_FromSymbolWindow.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonOptionForm_FromSymbolWindow.Text = "Symbol Window"
        '
        'ToolStripButtonAddPoint
        '
        Me.ToolStripButtonAddPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAddPoint.Image = CType(resources.GetObject("ToolStripButtonAddPoint.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddPoint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddPoint.Name = "ToolStripButtonAddPoint"
        Me.ToolStripButtonAddPoint.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonAddPoint.Text = "Add Point"
        '
        'ToolStripButtonAddLine
        '
        Me.ToolStripButtonAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAddLine.Image = CType(resources.GetObject("ToolStripButtonAddLine.Image"), System.Drawing.Image)
        Me.ToolStripButtonAddLine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddLine.Name = "ToolStripButtonAddLine"
        Me.ToolStripButtonAddLine.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonAddLine.Text = "Add Line"
        '
        'ToolStripButtonMove
        '
        Me.ToolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMove.Image = CType(resources.GetObject("ToolStripButtonMove.Image"), System.Drawing.Image)
        Me.ToolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMove.Name = "ToolStripButtonMove"
        Me.ToolStripButtonMove.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonMove.Text = "Move"
        '
        'ToolStripButtonDelete
        '
        Me.ToolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDelete.Image = CType(resources.GetObject("ToolStripButtonDelete.Image"), System.Drawing.Image)
        Me.ToolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
        Me.ToolStripButtonDelete.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonDelete.Text = "Delete"
        '
        'ToolStripButtonNewSymbol
        '
        Me.ToolStripButtonNewSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonNewSymbol.Image = CType(resources.GetObject("ToolStripButtonNewSymbol.Image"), System.Drawing.Image)
        Me.ToolStripButtonNewSymbol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNewSymbol.Name = "ToolStripButtonNewSymbol"
        Me.ToolStripButtonNewSymbol.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonNewSymbol.Text = "New Symbol"
        '
        'ToolStripButtonUpdateSymbol
        '
        Me.ToolStripButtonUpdateSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonUpdateSymbol.Image = CType(resources.GetObject("ToolStripButtonUpdateSymbol.Image"), System.Drawing.Image)
        Me.ToolStripButtonUpdateSymbol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonUpdateSymbol.Name = "ToolStripButtonUpdateSymbol"
        Me.ToolStripButtonUpdateSymbol.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButtonUpdateSymbol.Text = "Update Symbol"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(123, 55)
        '
        'LabelProgramStatus
        '
        Me.LabelProgramStatus.Name = "LabelProgramStatus"
        Me.LabelProgramStatus.Size = New System.Drawing.Size(39, 52)
        Me.LabelProgramStatus.Text = "Status"
        '
        'ToolStripSymbolBottom
        '
        Me.HelpProviderPictureBox1.SetHelpNavigator(Me.ToolStripSymbolBottom, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.HelpProviderSymbolWindow.SetHelpString(Me.ToolStripSymbolBottom, "SymbolSceen")
        Me.HelpProviderPictureBox1.SetHelpString(Me.ToolStripSymbolBottom, "PictureBox1")
        Me.ToolStripSymbolBottom.ImageScalingSize = New System.Drawing.Size(48, 48)
        Me.ToolStripSymbolBottom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownSelectSymbol, Me.ToolStripDropDownRotation, Me.ToolStripDropDownDataType, Me.ToolStripDropDownPathLineStyle, Me.ToolStripDropDownButtonColor, Me.ToolStripDropDownLineWidth, Me.ToolStripDropDownInputOutput, Me.ToolStripDropDownNumberOfBytes, Me.ToolStripDropDownPathStart, Me.ToolStripDropDownPathEnd})
        Me.ToolStripSymbolBottom.Location = New System.Drawing.Point(0, 55)
        Me.ToolStripSymbolBottom.Name = "ToolStripSymbolBottom"
        Me.HelpProviderSymbolWindow.SetShowHelp(Me.ToolStripSymbolBottom, True)
        Me.HelpProviderPictureBox1.SetShowHelp(Me.ToolStripSymbolBottom, True)
        Me.ToolStripSymbolBottom.Size = New System.Drawing.Size(1051, 55)
        Me.ToolStripSymbolBottom.TabIndex = 2
        Me.ToolStripSymbolBottom.Text = "ToolStrip3"
        '
        'ToolStripDropDownSelectSymbol
        '
        Me.ToolStripDropDownSelectSymbol.Image = CType(resources.GetObject("ToolStripDropDownSelectSymbol.Image"), System.Drawing.Image)
        Me.ToolStripDropDownSelectSymbol.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownSelectSymbol.Name = "ToolStripDropDownSelectSymbol"
        Me.ToolStripDropDownSelectSymbol.Size = New System.Drawing.Size(92, 52)
        Me.ToolStripDropDownSelectSymbol.Text = "Start"
        Me.ToolStripDropDownSelectSymbol.ToolTipText = "select a symbol to edit"
        '
        'ToolStripDropDownRotation
        '
        Me.ToolStripDropDownRotation.Image = CType(resources.GetObject("ToolStripDropDownRotation.Image"), System.Drawing.Image)
        Me.ToolStripDropDownRotation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownRotation.Name = "ToolStripDropDownRotation"
        Me.ToolStripDropDownRotation.Size = New System.Drawing.Size(106, 52)
        Me.ToolStripDropDownRotation.Text = "Default"
        Me.ToolStripDropDownRotation.ToolTipText = "select the rotation of the next symbol to place on the FlotChart"
        '
        'ToolStripDropDownDataType
        '
        Me.ToolStripDropDownDataType.Image = CType(resources.GetObject("ToolStripDropDownDataType.Image"), System.Drawing.Image)
        Me.ToolStripDropDownDataType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownDataType.Name = "ToolStripDropDownDataType"
        Me.ToolStripDropDownDataType.Size = New System.Drawing.Size(97, 52)
        Me.ToolStripDropDownDataType.Text = "Logic"
        Me.ToolStripDropDownDataType.ToolTipText = "select the type of data for the next point placed "
        '
        'ToolStripDropDownPathLineStyle
        '
        Me.ToolStripDropDownPathLineStyle.Image = CType(resources.GetObject("ToolStripDropDownPathLineStyle.Image"), System.Drawing.Image)
        Me.ToolStripDropDownPathLineStyle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownPathLineStyle.Name = "ToolStripDropDownPathLineStyle"
        Me.ToolStripDropDownPathLineStyle.Size = New System.Drawing.Size(94, 52)
        Me.ToolStripDropDownPathLineStyle.Text = "Solid"
        '
        'ToolStripDropDownButtonColor
        '
        Me.ToolStripDropDownButtonColor.Image = CType(resources.GetObject("ToolStripDropDownButtonColor.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButtonColor.Name = "ToolStripDropDownButtonColor"
        Me.ToolStripDropDownButtonColor.Size = New System.Drawing.Size(96, 52)
        Me.ToolStripDropDownButtonColor.Text = "Black"
        '
        'ToolStripDropDownLineWidth
        '
        Me.ToolStripDropDownLineWidth.Image = CType(resources.GetObject("ToolStripDropDownLineWidth.Image"), System.Drawing.Image)
        Me.ToolStripDropDownLineWidth.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownLineWidth.Name = "ToolStripDropDownLineWidth"
        Me.ToolStripDropDownLineWidth.Size = New System.Drawing.Size(74, 52)
        Me.ToolStripDropDownLineWidth.Text = "8"
        '
        'ToolStripDropDownInputOutput
        '
        Me.ToolStripDropDownInputOutput.Image = CType(resources.GetObject("ToolStripDropDownInputOutput.Image"), System.Drawing.Image)
        Me.ToolStripDropDownInputOutput.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownInputOutput.Name = "ToolStripDropDownInputOutput"
        Me.ToolStripDropDownInputOutput.Size = New System.Drawing.Size(93, 52)
        Me.ToolStripDropDownInputOutput.Text = "Both"
        '
        'ToolStripDropDownNumberOfBytes
        '
        Me.ToolStripDropDownNumberOfBytes.Image = CType(resources.GetObject("ToolStripDropDownNumberOfBytes.Image"), System.Drawing.Image)
        Me.ToolStripDropDownNumberOfBytes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownNumberOfBytes.Name = "ToolStripDropDownNumberOfBytes"
        Me.ToolStripDropDownNumberOfBytes.Size = New System.Drawing.Size(74, 52)
        Me.ToolStripDropDownNumberOfBytes.Text = "4"
        '
        'ToolStripDropDownPathStart
        '
        Me.ToolStripDropDownPathStart.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem})
        Me.ToolStripDropDownPathStart.Image = CType(resources.GetObject("ToolStripDropDownPathStart.Image"), System.Drawing.Image)
        Me.ToolStripDropDownPathStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownPathStart.Name = "ToolStripDropDownPathStart"
        Me.ToolStripDropDownPathStart.Size = New System.Drawing.Size(87, 52)
        Me.ToolStripDropDownPathStart.Text = "Flat"
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'ToolStripDropDownPathEnd
        '
        Me.ToolStripDropDownPathEnd.Image = CType(resources.GetObject("ToolStripDropDownPathEnd.Image"), System.Drawing.Image)
        Me.ToolStripDropDownPathEnd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownPathEnd.Name = "ToolStripDropDownPathEnd"
        Me.ToolStripDropDownPathEnd.Size = New System.Drawing.Size(87, 52)
        Me.ToolStripDropDownPathEnd.Text = "Flat"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.PictureBox1.Location = New System.Drawing.Point(10, 141)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(212, 199)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(252, 118)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Symbol Name"
        '
        'TextBoxNamedSymbolName
        '
        Me.TextBoxNamedSymbolName.Location = New System.Drawing.Point(394, 118)
        Me.TextBoxNamedSymbolName.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedSymbolName.Name = "TextBoxNamedSymbolName"
        Me.TextBoxNamedSymbolName.Size = New System.Drawing.Size(124, 20)
        Me.TextBoxNamedSymbolName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(252, 141)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Point Names"
        '
        'TextBoxNamedNameOfFile
        '
        Me.TextBoxNamedNameOfFile.Location = New System.Drawing.Point(394, 189)
        Me.TextBoxNamedNameOfFile.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedNameOfFile.Name = "TextBoxNamedNameOfFile"
        Me.TextBoxNamedNameOfFile.Size = New System.Drawing.Size(124, 20)
        Me.TextBoxNamedNameOfFile.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 189)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Filename"
        '
        'TextBoxNamedStroke
        '
        Me.TextBoxNamedStroke.Location = New System.Drawing.Point(394, 212)
        Me.TextBoxNamedStroke.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedStroke.Name = "TextBoxNamedStroke"
        Me.TextBoxNamedStroke.Size = New System.Drawing.Size(124, 20)
        Me.TextBoxNamedStroke.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(252, 212)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Stroke"
        '
        'TextBoxNamedOpCode
        '
        Me.TextBoxNamedOpCode.Location = New System.Drawing.Point(394, 237)
        Me.TextBoxNamedOpCode.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedOpCode.Name = "TextBoxNamedOpCode"
        Me.TextBoxNamedOpCode.Size = New System.Drawing.Size(124, 20)
        Me.TextBoxNamedOpCode.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 237)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Op Code"
        '
        'TextBoxSymbolVersionAuthor
        '
        Me.TextBoxSymbolVersionAuthor.Location = New System.Drawing.Point(394, 258)
        Me.TextBoxSymbolVersionAuthor.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxSymbolVersionAuthor.Name = "TextBoxSymbolVersionAuthor"
        Me.TextBoxSymbolVersionAuthor.Size = New System.Drawing.Size(124, 20)
        Me.TextBoxSymbolVersionAuthor.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 258)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Version/Author"
        '
        'TextBoxNamedNotes
        '
        Me.TextBoxNamedNotes.Location = New System.Drawing.Point(394, 279)
        Me.TextBoxNamedNotes.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedNotes.Multiline = True
        Me.TextBoxNamedNotes.Name = "TextBoxNamedNotes"
        Me.TextBoxNamedNotes.Size = New System.Drawing.Size(252, 73)
        Me.TextBoxNamedNotes.TabIndex = 12
        Me.TextBoxNamedNotes.Text = "notes:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(252, 279)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Notes"
        '
        'TextBoxNamedProgramText
        '
        Me.TextBoxNamedProgramText.Location = New System.Drawing.Point(394, 358)
        Me.TextBoxNamedProgramText.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedProgramText.Multiline = True
        Me.TextBoxNamedProgramText.Name = "TextBoxNamedProgramText"
        Me.TextBoxNamedProgramText.Size = New System.Drawing.Size(250, 47)
        Me.TextBoxNamedProgramText.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(252, 358)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Macro Text"
        '
        'TextBoxNamedSyntax
        '
        Me.TextBoxNamedSyntax.Location = New System.Drawing.Point(394, 407)
        Me.TextBoxNamedSyntax.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedSyntax.Multiline = True
        Me.TextBoxNamedSyntax.Name = "TextBoxNamedSyntax"
        Me.TextBoxNamedSyntax.Size = New System.Drawing.Size(250, 18)
        Me.TextBoxNamedSyntax.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(252, 407)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Syntax"
        '
        'TextBoxNamedDescription
        '
        Me.TextBoxNamedDescription.Location = New System.Drawing.Point(397, 456)
        Me.TextBoxNamedDescription.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBoxNamedDescription.Multiline = True
        Me.TextBoxNamedDescription.Name = "TextBoxNamedDescription"
        Me.TextBoxNamedDescription.Size = New System.Drawing.Size(246, 18)
        Me.TextBoxNamedDescription.TabIndex = 13
        Me.TextBoxNamedDescription.Text = "Description"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(256, 456)
        Me.Label12.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Description"
        '
        'Timer1
        '
        '
        'ComboBoxPointNameList
        '
        Me.ComboBoxPointNameList.FormattingEnabled = True
        Me.ComboBoxPointNameList.ItemHeight = 13
        Me.ComboBoxPointNameList.Location = New System.Drawing.Point(394, 141)
        Me.ComboBoxPointNameList.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxPointNameList.Name = "ComboBoxPointNameList"
        Me.ComboBoxPointNameList.Size = New System.Drawing.Size(124, 21)
        Me.ComboBoxPointNameList.TabIndex = 26
        '
        'ComboBoxLineNameList
        '
        Me.ComboBoxLineNameList.FormattingEnabled = True
        Me.ComboBoxLineNameList.ItemHeight = 13
        Me.ComboBoxLineNameList.Location = New System.Drawing.Point(394, 165)
        Me.ComboBoxLineNameList.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBoxLineNameList.Name = "ComboBoxLineNameList"
        Me.ComboBoxLineNameList.Size = New System.Drawing.Size(124, 21)
        Me.ComboBoxLineNameList.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(252, 165)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Lines"
        '
        'SymbolWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1051, 529)
        Me.Controls.Add(Me.ComboBoxLineNameList)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBoxPointNameList)
        Me.Controls.Add(Me.TextBoxNamedSyntax)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextBoxNamedDescription)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBoxNamedNotes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxNamedProgramText)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBoxNamedStroke)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxNamedOpCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxSymbolVersionAuthor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxNamedNameOfFile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxNamedSymbolName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ToolStripSymbolBottom)
        Me.Controls.Add(Me.ToolStripSymbolTop)
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "SymbolWindow"
        Me.Text = "SymbolWindow"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripSymbolTop.ResumeLayout(False)
        Me.ToolStripSymbolTop.PerformLayout()
        Me.ToolStripSymbolBottom.ResumeLayout(False)
        Me.ToolStripSymbolBottom.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripSymbolTop As ToolStrip
    Friend WithEvents ToolStripSymbolBottom As ToolStrip
    Friend WithEvents ToolStripButtonFlowChartForm_FromSymbolWindow As ToolStripButton
    Friend WithEvents ToolStripButtonOptionForm_FromSymbolWindow As ToolStripButton
    Friend WithEvents ToolStripButtonAddPoint As ToolStripButton
    Friend WithEvents ToolStripButtonAddLine As ToolStripButton
    Friend WithEvents ToolStripButtonMove As ToolStripButton
    Friend WithEvents ToolStripButtonDelete As ToolStripButton
    Friend WithEvents ToolStripButtonNewSymbol As ToolStripButton
    Friend WithEvents ToolStripButtonUpdateSymbol As ToolStripButton
    Friend WithEvents ToolStripDropDownSelectSymbol As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButtonColor As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownLineWidth As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownInputOutput As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownNumberOfBytes As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownDataType As ToolStripDropDownButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNamedSymbolName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxNamedNameOfFile As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxNamedStroke As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxNamedOpCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxSymbolVersionAuthor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxNamedNotes As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxNamedProgramText As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxNamedSyntax As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxNamedDescription As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripDropDownPathLineStyle As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownRotation As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownPathStart As ToolStripDropDownButton
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownPathEnd As ToolStripDropDownButton
    Friend WithEvents ComboBoxPointNameList As ComboBox
    Friend WithEvents ComboBoxLineNameList As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents HelpProviderSymbolWindow As HelpProvider
    Friend WithEvents HelpProviderPictureBox1 As HelpProvider
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents LabelProgramStatus As ToolStripLabel
End Class
