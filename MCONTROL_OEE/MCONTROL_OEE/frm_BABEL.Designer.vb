<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BABEL
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_BABEL))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_ADDBABEL = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.dgv_BABEL = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn5 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewLabelXColumn8 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column16 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewCheckBoxColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.cms_BABEL = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bt_EDITARBABEL = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_HABILITAR_BABEL = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_DESABILITAR_BABEL = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bt_EXCLUIR_BABEL = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmr_EDIT_BABEL = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv_BABEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_BABEL.SuspendLayout()
        Me.SuspendLayout()
        '
        'ribBar_ETH
        '
        Me.ribBar_ETH.AutoOverflowEnabled = True
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_ADDBABEL, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(509, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 28
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_ADDBABEL
        '
        Me.bt_ADDBABEL.Image = CType(resources.GetObject("bt_ADDBABEL.Image"), System.Drawing.Image)
        Me.bt_ADDBABEL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_ADDBABEL.Name = "bt_ADDBABEL"
        Me.bt_ADDBABEL.SubItemsExpandWidth = 14
        Me.bt_ADDBABEL.Text = "Adicionar BABEL"
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
        'dgv_BABEL
        '
        Me.dgv_BABEL.AllowUserToAddRows = False
        Me.dgv_BABEL.AllowUserToDeleteRows = False
        Me.dgv_BABEL.AllowUserToResizeRows = False
        Me.dgv_BABEL.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_BABEL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_BABEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_BABEL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn5, Me.DataGridViewLabelXColumn8, Me.Column16, Me.Column1, Me.DataGridViewCheckBoxColumn1})
        Me.dgv_BABEL.ContextMenuStrip = Me.cms_BABEL
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_BABEL.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_BABEL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_BABEL.EnableHeadersVisualStyles = False
        Me.dgv_BABEL.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_BABEL.Location = New System.Drawing.Point(0, 67)
        Me.dgv_BABEL.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_BABEL.MultiSelect = False
        Me.dgv_BABEL.Name = "dgv_BABEL"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_BABEL.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgv_BABEL.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_BABEL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_BABEL.Size = New System.Drawing.Size(509, 382)
        Me.dgv_BABEL.TabIndex = 29
        '
        'DataGridViewLabelXColumn5
        '
        Me.DataGridViewLabelXColumn5.HeaderText = "Id"
        Me.DataGridViewLabelXColumn5.Name = "DataGridViewLabelXColumn5"
        Me.DataGridViewLabelXColumn5.Visible = False
        '
        'DataGridViewLabelXColumn8
        '
        Me.DataGridViewLabelXColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "N2"
        Me.DataGridViewLabelXColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewLabelXColumn8.HeaderText = "Dispositivo"
        Me.DataGridViewLabelXColumn8.Name = "DataGridViewLabelXColumn8"
        Me.DataGridViewLabelXColumn8.ReadOnly = True
        Me.DataGridViewLabelXColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLabelXColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewLabelXColumn8.Width = 150
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column16.HeaderText = "Descrição"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column16.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id SAP"
        Me.Column1.Name = "Column1"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.Checked = True
        Me.DataGridViewCheckBoxColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxColumn1.CheckValue = "N"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Ativo"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.Width = 37
        '
        'cms_BABEL
        '
        Me.cms_BABEL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cms_BABEL.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bt_EDITARBABEL, Me.bt_HABILITAR_BABEL, Me.bt_DESABILITAR_BABEL, Me.ToolStripSeparator1, Me.bt_EXCLUIR_BABEL})
        Me.cms_BABEL.Name = "cms_BABEL"
        Me.cms_BABEL.Size = New System.Drawing.Size(181, 120)
        '
        'bt_EDITARBABEL
        '
        Me.bt_EDITARBABEL.Name = "bt_EDITARBABEL"
        Me.bt_EDITARBABEL.Size = New System.Drawing.Size(180, 22)
        Me.bt_EDITARBABEL.Text = "Editar BABEL"
        '
        'bt_HABILITAR_BABEL
        '
        Me.bt_HABILITAR_BABEL.Name = "bt_HABILITAR_BABEL"
        Me.bt_HABILITAR_BABEL.Size = New System.Drawing.Size(180, 22)
        Me.bt_HABILITAR_BABEL.Text = "Habilitar BABEL"
        '
        'bt_DESABILITAR_BABEL
        '
        Me.bt_DESABILITAR_BABEL.Name = "bt_DESABILITAR_BABEL"
        Me.bt_DESABILITAR_BABEL.Size = New System.Drawing.Size(180, 22)
        Me.bt_DESABILITAR_BABEL.Text = "Desabilitar BABEL"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'bt_EXCLUIR_BABEL
        '
        Me.bt_EXCLUIR_BABEL.Name = "bt_EXCLUIR_BABEL"
        Me.bt_EXCLUIR_BABEL.Size = New System.Drawing.Size(180, 22)
        Me.bt_EXCLUIR_BABEL.Text = "Excluir BABEL"
        '
        'tmr_EDIT_BABEL
        '
        Me.tmr_EDIT_BABEL.Interval = 1000
        '
        'frm_BABEL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 449)
        Me.Controls.Add(Me.dgv_BABEL)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_BABEL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de BABEL"
        CType(Me.dgv_BABEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_BABEL.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_ADDBABEL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgv_BABEL As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewLabelXColumn5 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewLabelXColumn8 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column16 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents cms_BABEL As ContextMenuStrip
    Friend WithEvents bt_EDITARBABEL As ToolStripMenuItem
    Friend WithEvents bt_HABILITAR_BABEL As ToolStripMenuItem
    Friend WithEvents bt_DESABILITAR_BABEL As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents bt_EXCLUIR_BABEL As ToolStripMenuItem
    Friend WithEvents tmr_EDIT_BABEL As Timer
End Class
