<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MOTIVOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MOTIVOS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.dgv_MOTIVOS = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cb_MOTIVONIVEL1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_MOTIVONIVEL2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cb_MOTIVONIVEL3 = New System.Windows.Forms.ComboBox()
        Me.cb_MOTIVONIVEL1ID = New System.Windows.Forms.ComboBox()
        Me.cb_MOTIVONIVEL2ID = New System.Windows.Forms.ComboBox()
        Me.cb_MOTIVONIVEL3ID = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tb_COMENTARIOS = New System.Windows.Forms.TextBox()
        Me.Column6 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column2 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column4 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column5 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Alterado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgv_MOTIVOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ribBar_ETH
        '
        Me.ribBar_ETH.AutoOverflowEnabled = True
        Me.ribBar_ETH.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ribBar_ETH.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribBar_ETH.ContainerControlProcessDialogKey = True
        Me.ribBar_ETH.Dock = System.Windows.Forms.DockStyle.Top
        Me.ribBar_ETH.DragDropSupport = True
        Me.ribBar_ETH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(1029, 46)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 10
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderRightWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SAVE})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_SAVE
        '
        Me.bt_SAVE.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SAVE.Enabled = False
        Me.bt_SAVE.Image = CType(resources.GetObject("bt_SAVE.Image"), System.Drawing.Image)
        Me.bt_SAVE.ImageAlt = CType(resources.GetObject("bt_SAVE.ImageAlt"), System.Drawing.Image)
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.Text = " Salvar"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImageAlt = CType(resources.GetObject("ButtonItem1.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.SubItemsExpandWidth = 14
        Me.ButtonItem1.Text = "Sair"
        '
        'dgv_MOTIVOS
        '
        Me.dgv_MOTIVOS.AllowUserToAddRows = False
        Me.dgv_MOTIVOS.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_MOTIVOS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_MOTIVOS.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_MOTIVOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_MOTIVOS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column3, Me.Column2, Me.Column4, Me.Column5, Me.Alterado})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_MOTIVOS.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_MOTIVOS.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgv_MOTIVOS.EnableHeadersVisualStyles = False
        Me.dgv_MOTIVOS.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgv_MOTIVOS.Location = New System.Drawing.Point(0, 46)
        Me.dgv_MOTIVOS.Name = "dgv_MOTIVOS"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOS.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_MOTIVOS.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_MOTIVOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_MOTIVOS.Size = New System.Drawing.Size(615, 354)
        Me.dgv_MOTIVOS.TabIndex = 11
        '
        'cb_MOTIVONIVEL1
        '
        Me.cb_MOTIVONIVEL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL1.FormattingEnabled = True
        Me.cb_MOTIVONIVEL1.Location = New System.Drawing.Point(7, 21)
        Me.cb_MOTIVONIVEL1.Name = "cb_MOTIVONIVEL1"
        Me.cb_MOTIVONIVEL1.Size = New System.Drawing.Size(377, 31)
        Me.cb_MOTIVONIVEL1.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_MOTIVONIVEL1)
        Me.GroupBox1.Location = New System.Drawing.Point(621, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MOTIVO NIVEL 1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_MOTIVONIVEL2)
        Me.GroupBox2.Location = New System.Drawing.Point(621, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MOTIVO NIVEL 2"
        '
        'cb_MOTIVONIVEL2
        '
        Me.cb_MOTIVONIVEL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL2.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL2.FormattingEnabled = True
        Me.cb_MOTIVONIVEL2.Location = New System.Drawing.Point(6, 21)
        Me.cb_MOTIVONIVEL2.Name = "cb_MOTIVONIVEL2"
        Me.cb_MOTIVONIVEL2.Size = New System.Drawing.Size(378, 31)
        Me.cb_MOTIVONIVEL2.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cb_MOTIVONIVEL3)
        Me.GroupBox3.Location = New System.Drawing.Point(621, 189)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(396, 62)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MOTIVO NIVEL 3"
        '
        'cb_MOTIVONIVEL3
        '
        Me.cb_MOTIVONIVEL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL3.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL3.FormattingEnabled = True
        Me.cb_MOTIVONIVEL3.Location = New System.Drawing.Point(6, 21)
        Me.cb_MOTIVONIVEL3.Name = "cb_MOTIVONIVEL3"
        Me.cb_MOTIVONIVEL3.Size = New System.Drawing.Size(378, 31)
        Me.cb_MOTIVONIVEL3.TabIndex = 12
        '
        'cb_MOTIVONIVEL1ID
        '
        Me.cb_MOTIVONIVEL1ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL1ID.Location = New System.Drawing.Point(627, 100)
        Me.cb_MOTIVONIVEL1ID.Name = "cb_MOTIVONIVEL1ID"
        Me.cb_MOTIVONIVEL1ID.Size = New System.Drawing.Size(41, 24)
        Me.cb_MOTIVONIVEL1ID.TabIndex = 16
        Me.cb_MOTIVONIVEL1ID.Visible = False
        '
        'cb_MOTIVONIVEL2ID
        '
        Me.cb_MOTIVONIVEL2ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL2ID.Location = New System.Drawing.Point(627, 168)
        Me.cb_MOTIVONIVEL2ID.Name = "cb_MOTIVONIVEL2ID"
        Me.cb_MOTIVONIVEL2ID.Size = New System.Drawing.Size(41, 24)
        Me.cb_MOTIVONIVEL2ID.TabIndex = 17
        Me.cb_MOTIVONIVEL2ID.Visible = False
        '
        'cb_MOTIVONIVEL3ID
        '
        Me.cb_MOTIVONIVEL3ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL3ID.Location = New System.Drawing.Point(627, 238)
        Me.cb_MOTIVONIVEL3ID.Name = "cb_MOTIVONIVEL3ID"
        Me.cb_MOTIVONIVEL3ID.Size = New System.Drawing.Size(41, 24)
        Me.cb_MOTIVONIVEL3ID.TabIndex = 18
        Me.cb_MOTIVONIVEL3ID.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tb_COMENTARIOS)
        Me.GroupBox4.Location = New System.Drawing.Point(621, 258)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(396, 130)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "COMENTÁRIOS"
        '
        'tb_COMENTARIOS
        '
        Me.tb_COMENTARIOS.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_COMENTARIOS.Location = New System.Drawing.Point(7, 21)
        Me.tb_COMENTARIOS.MaxLength = 128
        Me.tb_COMENTARIOS.Multiline = True
        Me.tb_COMENTARIOS.Name = "tb_COMENTARIOS"
        Me.tb_COMENTARIOS.Size = New System.Drawing.Size(377, 102)
        Me.tb_COMENTARIOS.TabIndex = 0
        '
        'Column6
        '
        Me.Column6.HeaderText = "Id"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Data Inicial"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.Column1.Width = 120
        '
        'Column3
        '
        Me.Column3.HeaderText = "Hora Inicial"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "Data Final"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.TextAlignment = System.Drawing.StringAlignment.Center
        Me.Column2.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Hora Final"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 120
        '
        'Column5
        '
        Me.Column5.HeaderText = "Tempo"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 80
        '
        'Alterado
        '
        Me.Alterado.HeaderText = "Alterado"
        Me.Alterado.Name = "Alterado"
        Me.Alterado.Visible = False
        '
        'frm_MOTIVOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 400)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cb_MOTIVONIVEL2ID)
        Me.Controls.Add(Me.cb_MOTIVONIVEL3ID)
        Me.Controls.Add(Me.cb_MOTIVONIVEL1ID)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_MOTIVOS)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_MOTIVOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paradas sem Motivo informado"
        Me.TopMost = True
        CType(Me.dgv_MOTIVOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgv_MOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cb_MOTIVONIVEL1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cb_MOTIVONIVEL2 As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cb_MOTIVONIVEL3 As ComboBox
    Friend WithEvents cb_MOTIVONIVEL1ID As ComboBox
    Friend WithEvents cb_MOTIVONIVEL2ID As ComboBox
    Friend WithEvents cb_MOTIVONIVEL3ID As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents tb_COMENTARIOS As TextBox
    Friend WithEvents Column6 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column2 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column4 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column5 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Alterado As DataGridViewCheckBoxColumn
End Class
