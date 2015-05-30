<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HScaleRB
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DrawPanel = New System.Windows.Forms.Panel()
        Me.GridCB = New System.Windows.Forms.CheckBox()
        Me.sdsdsd = New System.Windows.Forms.GroupBox()
        Me.HNullRB = New System.Windows.Forms.RadioButton()
        Me.HSquaredEuclideanRB = New System.Windows.Forms.RadioButton()
        Me.HEuclideanRB = New System.Windows.Forms.RadioButton()
        Me.HDiagonalRB = New System.Windows.Forms.RadioButton()
        Me.HScaleNUD = New System.Windows.Forms.NumericUpDown()
        Me.HManatthanRB = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DrawPanelEventClickLB = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TextLB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TileLB = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.actLB = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpostaComeStartPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpostaComeEndPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.sdsdsd.SuspendLayout()
        CType(Me.HScaleNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'DrawPanel
        '
        Me.DrawPanel.BackColor = System.Drawing.Color.White
        Me.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DrawPanel.Location = New System.Drawing.Point(12, 12)
        Me.DrawPanel.Name = "DrawPanel"
        Me.DrawPanel.Size = New System.Drawing.Size(512, 512)
        Me.DrawPanel.TabIndex = 0
        '
        'GridCB
        '
        Me.GridCB.AutoSize = True
        Me.GridCB.Location = New System.Drawing.Point(945, 691)
        Me.GridCB.Name = "GridCB"
        Me.GridCB.Size = New System.Drawing.Size(45, 17)
        Me.GridCB.TabIndex = 2
        Me.GridCB.Text = "Grid"
        Me.GridCB.UseVisualStyleBackColor = True
        '
        'sdsdsd
        '
        Me.sdsdsd.Controls.Add(Me.HNullRB)
        Me.sdsdsd.Controls.Add(Me.HSquaredEuclideanRB)
        Me.sdsdsd.Controls.Add(Me.HEuclideanRB)
        Me.sdsdsd.Controls.Add(Me.HDiagonalRB)
        Me.sdsdsd.Controls.Add(Me.HScaleNUD)
        Me.sdsdsd.Controls.Add(Me.HManatthanRB)
        Me.sdsdsd.Location = New System.Drawing.Point(679, 12)
        Me.sdsdsd.Name = "sdsdsd"
        Me.sdsdsd.Size = New System.Drawing.Size(108, 152)
        Me.sdsdsd.TabIndex = 6
        Me.sdsdsd.TabStop = False
        Me.sdsdsd.Text = "Heuristic"
        '
        'HNullRB
        '
        Me.HNullRB.AutoSize = True
        Me.HNullRB.Location = New System.Drawing.Point(6, 111)
        Me.HNullRB.Name = "HNullRB"
        Me.HNullRB.Size = New System.Drawing.Size(43, 17)
        Me.HNullRB.TabIndex = 5
        Me.HNullRB.Text = "Null"
        Me.HNullRB.UseVisualStyleBackColor = True
        '
        'HSquaredEuclideanRB
        '
        Me.HSquaredEuclideanRB.AutoSize = True
        Me.HSquaredEuclideanRB.Location = New System.Drawing.Point(6, 88)
        Me.HSquaredEuclideanRB.Name = "HSquaredEuclideanRB"
        Me.HSquaredEuclideanRB.Size = New System.Drawing.Size(112, 17)
        Me.HSquaredEuclideanRB.TabIndex = 4
        Me.HSquaredEuclideanRB.Text = "Squaed Euclidean"
        Me.HSquaredEuclideanRB.UseVisualStyleBackColor = True
        '
        'HEuclideanRB
        '
        Me.HEuclideanRB.AutoSize = True
        Me.HEuclideanRB.Location = New System.Drawing.Point(6, 65)
        Me.HEuclideanRB.Name = "HEuclideanRB"
        Me.HEuclideanRB.Size = New System.Drawing.Size(72, 17)
        Me.HEuclideanRB.TabIndex = 3
        Me.HEuclideanRB.Text = "Euclidean"
        Me.HEuclideanRB.UseVisualStyleBackColor = True
        '
        'HDiagonalRB
        '
        Me.HDiagonalRB.AutoSize = True
        Me.HDiagonalRB.Location = New System.Drawing.Point(6, 42)
        Me.HDiagonalRB.Name = "HDiagonalRB"
        Me.HDiagonalRB.Size = New System.Drawing.Size(67, 17)
        Me.HDiagonalRB.TabIndex = 2
        Me.HDiagonalRB.Text = "Diagonal"
        Me.HDiagonalRB.UseVisualStyleBackColor = True
        '
        'HScaleNUD
        '
        Me.HScaleNUD.DecimalPlaces = 6
        Me.HScaleNUD.Location = New System.Drawing.Point(1, 126)
        Me.HScaleNUD.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.HScaleNUD.Name = "HScaleNUD"
        Me.HScaleNUD.Size = New System.Drawing.Size(101, 20)
        Me.HScaleNUD.TabIndex = 1
        Me.HScaleNUD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'HManatthanRB
        '
        Me.HManatthanRB.AutoSize = True
        Me.HManatthanRB.Checked = True
        Me.HManatthanRB.Location = New System.Drawing.Point(6, 20)
        Me.HManatthanRB.Name = "HManatthanRB"
        Me.HManatthanRB.Size = New System.Drawing.Size(76, 17)
        Me.HManatthanRB.TabIndex = 0
        Me.HManatthanRB.TabStop = True
        Me.HManatthanRB.Text = "Manhattan"
        Me.HManatthanRB.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DrawPanelEventClickLB)
        Me.GroupBox4.Location = New System.Drawing.Point(530, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(143, 152)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mouse_click"
        '
        'DrawPanelEventClickLB
        '
        Me.DrawPanelEventClickLB.FormattingEnabled = True
        Me.DrawPanelEventClickLB.Items.AddRange(New Object() {"SetTile", "Spawn HSActor", "Remove Actor"})
        Me.DrawPanelEventClickLB.Location = New System.Drawing.Point(6, 20)
        Me.DrawPanelEventClickLB.Name = "DrawPanelEventClickLB"
        Me.DrawPanelEventClickLB.Size = New System.Drawing.Size(120, 121)
        Me.DrawPanelEventClickLB.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TextLB})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 711)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1354, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TextLB
        '
        Me.TextLB.Name = "TextLB"
        Me.TextLB.Size = New System.Drawing.Size(30, 17)
        Me.TextLB.Text = "(0,0)"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(13, 588)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(512, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Renderizza full"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TileLB)
        Me.GroupBox1.Location = New System.Drawing.Point(536, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 152)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tile"
        '
        'TileLB
        '
        Me.TileLB.FormattingEnabled = True
        Me.TileLB.Location = New System.Drawing.Point(6, 20)
        Me.TileLB.Name = "TileLB"
        Me.TileLB.Size = New System.Drawing.Size(120, 121)
        Me.TileLB.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 617)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(512, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Renderizza"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 646)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(512, 23)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Fissa la mappa come Oggetto  da spostare"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Controls.Add(Me.Button14)
        Me.GroupBox3.Controls.Add(Me.Button13)
        Me.GroupBox3.Controls.Add(Me.Button12)
        Me.GroupBox3.Controls.Add(Me.Button11)
        Me.GroupBox3.Controls.Add(Me.Button10)
        Me.GroupBox3.Controls.Add(Me.Button9)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(536, 328)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 177)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Spostamento"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(33, 32)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(76, 20)
        Me.NumericUpDown1.TabIndex = 24
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(96, 135)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(32, 32)
        Me.Button14.TabIndex = 23
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(58, 135)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(32, 32)
        Me.Button13.TabIndex = 22
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(20, 134)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(32, 32)
        Me.Button12.TabIndex = 21
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(96, 97)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(32, 32)
        Me.Button11.TabIndex = 20
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(58, 97)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(32, 32)
        Me.Button10.TabIndex = 19
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(20, 97)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(32, 32)
        Me.Button9.TabIndex = 18
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(96, 59)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 32)
        Me.Button8.TabIndex = 17
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(58, 59)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(32, 32)
        Me.Button7.TabIndex = 16
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(20, 59)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(32, 32)
        Me.Button6.TabIndex = 15
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(30, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NON FISSATO"
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(6, 132)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(122, 23)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "Genera labirinto"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button16)
        Me.GroupBox5.Controls.Add(Me.Button15)
        Me.GroupBox5.Controls.Add(Me.Button17)
        Me.GroupBox5.Controls.Add(Me.Button18)
        Me.GroupBox5.Controls.Add(Me.Button24)
        Me.GroupBox5.Controls.Add(Me.Button19)
        Me.GroupBox5.Controls.Add(Me.Button23)
        Me.GroupBox5.Controls.Add(Me.Button22)
        Me.GroupBox5.Controls.Add(Me.Button21)
        Me.GroupBox5.Location = New System.Drawing.Point(536, 511)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(137, 166)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Labirinto"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.Location = New System.Drawing.Point(96, 95)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(32, 32)
        Me.Button16.TabIndex = 33
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.Red
        Me.Button17.Location = New System.Drawing.Point(58, 95)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(32, 32)
        Me.Button17.TabIndex = 32
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.White
        Me.Button18.Location = New System.Drawing.Point(20, 94)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(32, 32)
        Me.Button18.TabIndex = 31
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.White
        Me.Button24.Location = New System.Drawing.Point(20, 19)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(32, 32)
        Me.Button24.TabIndex = 25
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.Red
        Me.Button19.Location = New System.Drawing.Point(96, 57)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(32, 32)
        Me.Button19.TabIndex = 30
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.Red
        Me.Button23.Location = New System.Drawing.Point(58, 19)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(32, 32)
        Me.Button23.TabIndex = 26
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.White
        Me.Button22.Location = New System.Drawing.Point(96, 19)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(32, 32)
        Me.Button22.TabIndex = 27
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.Red
        Me.Button21.Location = New System.Drawing.Point(20, 57)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(32, 32)
        Me.Button21.TabIndex = 28
        Me.Button21.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.actLB)
        Me.GroupBox6.Location = New System.Drawing.Point(679, 170)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(108, 152)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Attori"
        '
        'actLB
        '
        Me.actLB.ContextMenuStrip = Me.ContextMenuStrip1
        Me.actLB.FormattingEnabled = True
        Me.actLB.Location = New System.Drawing.Point(7, 20)
        Me.actLB.Name = "actLB"
        Me.actLB.Size = New System.Drawing.Size(95, 121)
        Me.actLB.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ImpostaComeStartPointToolStripMenuItem, Me.ImpostaComeEndPointToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 92)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(204, 22)
        Me.ToolStripMenuItem1.Text = "Rimuovi"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(204, 22)
        Me.ToolStripMenuItem2.Text = "Fissalo"
        '
        'ImpostaComeStartPointToolStripMenuItem
        '
        Me.ImpostaComeStartPointToolStripMenuItem.Name = "ImpostaComeStartPointToolStripMenuItem"
        Me.ImpostaComeStartPointToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImpostaComeStartPointToolStripMenuItem.Text = "Imposta come startPoint"
        '
        'ImpostaComeEndPointToolStripMenuItem
        '
        Me.ImpostaComeEndPointToolStripMenuItem.Name = "ImpostaComeEndPointToolStripMenuItem"
        Me.ImpostaComeEndPointToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImpostaComeEndPointToolStripMenuItem.Text = "Imposta come endPoint"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(837, 691)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "timer"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button1)
        Me.GroupBox7.Controls.Add(Me.Button20)
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Location = New System.Drawing.Point(680, 328)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(107, 100)
        Me.GroupBox7.TabIndex = 19
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "PathFinding"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Distanza"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(5, 39)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(96, 23)
        Me.Button20.TabIndex = 1
        Me.Button20.Text = "Trova"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RadioButton1.Location = New System.Drawing.Point(7, 16)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "A* (AStar)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'HScaleRB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.sdsdsd)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GridCB)
        Me.Controls.Add(Me.DrawPanel)
        Me.Name = "HScaleRB"
        Me.Text = "Renderizza 1"
        Me.sdsdsd.ResumeLayout(False)
        Me.sdsdsd.PerformLayout()
        CType(Me.HScaleNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DrawPanel As System.Windows.Forms.Panel
    Friend WithEvents GridCB As System.Windows.Forms.CheckBox
    Friend WithEvents sdsdsd As System.Windows.Forms.GroupBox
    Friend WithEvents HScaleNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents HManatthanRB As System.Windows.Forms.RadioButton
    Friend WithEvents HDiagonalRB As System.Windows.Forms.RadioButton
    Friend WithEvents HEuclideanRB As System.Windows.Forms.RadioButton
    Friend WithEvents HSquaredEuclideanRB As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TextLB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DrawPanelEventClickLB As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TileLB As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents actLB As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents ImpostaComeStartPointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpostaComeEndPointToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents HNullRB As System.Windows.Forms.RadioButton

End Class
