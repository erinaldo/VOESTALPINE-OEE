<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OPERADORES
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OPERADORES))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_ADDOPERADOR = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_EXCLUIROPERADOR = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_CANCEL = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.dgv_OPERADORES = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn9 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewLabelXColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewLabelXColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgv_OPERADORES, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_ADDOPERADOR, Me.bt_EXCLUIROPERADOR, Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(461, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 11
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_ADDOPERADOR
        '
        Me.bt_ADDOPERADOR.Image = CType(resources.GetObject("bt_ADDOPERADOR.Image"), System.Drawing.Image)
        Me.bt_ADDOPERADOR.ImageAlt = CType(resources.GetObject("bt_ADDOPERADOR.ImageAlt"), System.Drawing.Image)
        Me.bt_ADDOPERADOR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_ADDOPERADOR.Name = "bt_ADDOPERADOR"
        Me.bt_ADDOPERADOR.SubItemsExpandWidth = 14
        Me.bt_ADDOPERADOR.Text = "Adicionar Operador"
        '
        'bt_EXCLUIROPERADOR
        '
        Me.bt_EXCLUIROPERADOR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_EXCLUIROPERADOR.Enabled = False
        Me.bt_EXCLUIROPERADOR.Image = CType(resources.GetObject("bt_EXCLUIROPERADOR.Image"), System.Drawing.Image)
        Me.bt_EXCLUIROPERADOR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_EXCLUIROPERADOR.Name = "bt_EXCLUIROPERADOR"
        Me.bt_EXCLUIROPERADOR.Text = "Excluir Operador"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderRightWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SAVE, Me.bt_CANCEL})
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
        'bt_CANCEL
        '
        Me.bt_CANCEL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_CANCEL.Enabled = False
        Me.bt_CANCEL.Image = CType(resources.GetObject("bt_CANCEL.Image"), System.Drawing.Image)
        Me.bt_CANCEL.ImageAlt = CType(resources.GetObject("bt_CANCEL.ImageAlt"), System.Drawing.Image)
        Me.bt_CANCEL.Name = "bt_CANCEL"
        Me.bt_CANCEL.Text = "Cancelar"
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
        'dgv_OPERADORES
        '
        Me.dgv_OPERADORES.AllowUserToAddRows = False
        Me.dgv_OPERADORES.AllowUserToDeleteRows = False
        Me.dgv_OPERADORES.AllowUserToResizeRows = False
        Me.dgv_OPERADORES.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OPERADORES.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_OPERADORES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_OPERADORES.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn9, Me.DataGridViewLabelXColumn10, Me.DataGridViewLabelXColumn11, Me.Column3, Me.DataGridViewCheckBoxColumn2, Me.Column1, Me.Column2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_OPERADORES.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_OPERADORES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_OPERADORES.EnableHeadersVisualStyles = False
        Me.dgv_OPERADORES.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_OPERADORES.Location = New System.Drawing.Point(0, 67)
        Me.dgv_OPERADORES.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_OPERADORES.MultiSelect = False
        Me.dgv_OPERADORES.Name = "dgv_OPERADORES"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_OPERADORES.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgv_OPERADORES.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_OPERADORES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_OPERADORES.Size = New System.Drawing.Size(461, 265)
        Me.dgv_OPERADORES.TabIndex = 17
        '
        'DataGridViewLabelXColumn9
        '
        Me.DataGridViewLabelXColumn9.HeaderText = "Id"
        Me.DataGridViewLabelXColumn9.Name = "DataGridViewLabelXColumn9"
        Me.DataGridViewLabelXColumn9.Visible = False
        '
        'DataGridViewLabelXColumn10
        '
        Me.DataGridViewLabelXColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewLabelXColumn10.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewLabelXColumn10.HeaderText = "Matrícula"
        Me.DataGridViewLabelXColumn10.Name = "DataGridViewLabelXColumn10"
        Me.DataGridViewLabelXColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLabelXColumn10.Visible = False
        '
        'DataGridViewLabelXColumn11
        '
        Me.DataGridViewLabelXColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "N2"
        Me.DataGridViewLabelXColumn11.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewLabelXColumn11.HeaderText = "Nome"
        Me.DataGridViewLabelXColumn11.Name = "DataGridViewLabelXColumn11"
        Me.DataGridViewLabelXColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLabelXColumn11.Width = 61
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Login"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 59
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Ativo"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 37
        '
        'Column1
        '
        Me.Column1.HeaderText = "NEW"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "EDITED"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'frm_OPERADORES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 332)
        Me.Controls.Add(Me.dgv_OPERADORES)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_OPERADORES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operadores de Máquinas"
        CType(Me.dgv_OPERADORES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_ADDOPERADOR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_EXCLUIROPERADOR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_CANCEL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgv_OPERADORES As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewLabelXColumn9 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewLabelXColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLabelXColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
End Class
