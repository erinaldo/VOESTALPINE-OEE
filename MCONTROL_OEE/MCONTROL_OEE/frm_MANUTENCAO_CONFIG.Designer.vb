<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_MANUTENCAO_CONFIG
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MANUTENCAO_CONFIG))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_CANCEL = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.ep_NIVEL1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dgv_MOTIVOSPARADA = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn5 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewLabelXColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dgv_MOTIVOSAGUARDANDO = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.ExpandableSplitter2 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dgv_MOTIVOSBOTAOFECHARPARADA = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn2 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxXColumn2 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.ep_NIVEL1.SuspendLayout()
        CType(Me.dgv_MOTIVOSPARADA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.dgv_MOTIVOSAGUARDANDO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.dgv_MOTIVOSBOTAOFECHARPARADA, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SAVE, Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(1080, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 12
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_SAVE
        '
        Me.bt_SAVE.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SAVE.Enabled = False
        Me.bt_SAVE.Image = CType(resources.GetObject("bt_SAVE.Image"), System.Drawing.Image)
        Me.bt_SAVE.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.SubItemsExpandWidth = 14
        Me.bt_SAVE.Text = "Salvar Alterações"
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
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_CANCEL})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_CANCEL
        '
        Me.bt_CANCEL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_CANCEL.Enabled = False
        Me.bt_CANCEL.Image = CType(resources.GetObject("bt_CANCEL.Image"), System.Drawing.Image)
        Me.bt_CANCEL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_CANCEL.Name = "bt_CANCEL"
        Me.bt_CANCEL.Text = "Cancelar Alterações"
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
        'ep_NIVEL1
        '
        Me.ep_NIVEL1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ep_NIVEL1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ep_NIVEL1.Controls.Add(Me.dgv_MOTIVOSPARADA)
        Me.ep_NIVEL1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ep_NIVEL1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ep_NIVEL1.ExpandButtonVisible = False
        Me.ep_NIVEL1.HideControlsWhenCollapsed = True
        Me.ep_NIVEL1.Location = New System.Drawing.Point(0, 67)
        Me.ep_NIVEL1.Name = "ep_NIVEL1"
        Me.ep_NIVEL1.Size = New System.Drawing.Size(354, 487)
        Me.ep_NIVEL1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ep_NIVEL1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ep_NIVEL1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ep_NIVEL1.Style.BorderColor.Color = System.Drawing.Color.Black
        Me.ep_NIVEL1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ep_NIVEL1.Style.GradientAngle = 90
        Me.ep_NIVEL1.TabIndex = 20
        Me.ep_NIVEL1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ep_NIVEL1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ep_NIVEL1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ep_NIVEL1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ep_NIVEL1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ep_NIVEL1.TitleStyle.GradientAngle = 90
        Me.ep_NIVEL1.TitleText = "Motivos de Parada  para Indicadores da Manutenção"
        '
        'dgv_MOTIVOSPARADA
        '
        Me.dgv_MOTIVOSPARADA.AllowUserToAddRows = False
        Me.dgv_MOTIVOSPARADA.AllowUserToDeleteRows = False
        Me.dgv_MOTIVOSPARADA.AllowUserToResizeRows = False
        Me.dgv_MOTIVOSPARADA.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSPARADA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_MOTIVOSPARADA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_MOTIVOSPARADA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn5, Me.DataGridViewLabelXColumn8, Me.Column3})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_MOTIVOSPARADA.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_MOTIVOSPARADA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_MOTIVOSPARADA.EnableHeadersVisualStyles = False
        Me.dgv_MOTIVOSPARADA.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_MOTIVOSPARADA.Location = New System.Drawing.Point(0, 26)
        Me.dgv_MOTIVOSPARADA.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_MOTIVOSPARADA.MultiSelect = False
        Me.dgv_MOTIVOSPARADA.Name = "dgv_MOTIVOSPARADA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSPARADA.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgv_MOTIVOSPARADA.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_MOTIVOSPARADA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_MOTIVOSPARADA.Size = New System.Drawing.Size(354, 461)
        Me.dgv_MOTIVOSPARADA.TabIndex = 15
        '
        'DataGridViewLabelXColumn5
        '
        Me.DataGridViewLabelXColumn5.HeaderText = "Id"
        Me.DataGridViewLabelXColumn5.Name = "DataGridViewLabelXColumn5"
        Me.DataGridViewLabelXColumn5.Visible = False
        '
        'DataGridViewLabelXColumn8
        '
        Me.DataGridViewLabelXColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "N2"
        Me.DataGridViewLabelXColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewLabelXColumn8.HeaderText = "Descrição"
        Me.DataGridViewLabelXColumn8.Name = "DataGridViewLabelXColumn8"
        Me.DataGridViewLabelXColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLabelXColumn8.Width = 80
        '
        'Column3
        '
        Me.Column3.Checked = True
        Me.Column3.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Column3.CheckValue = "N"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Considerar"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 70
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.Black
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.ForeColor = System.Drawing.Color.Black
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.Black
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.Black
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(354, 67)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(5, 487)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 21
        Me.ExpandableSplitter1.TabStop = False
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.dgv_MOTIVOSAGUARDANDO)
        Me.ExpandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.ExpandButtonVisible = False
        Me.ExpandablePanel1.HideControlsWhenCollapsed = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(359, 67)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(365, 487)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.Color = System.Drawing.Color.Black
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 25
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Motivos de Aguardando a Manutenção"
        '
        'dgv_MOTIVOSAGUARDANDO
        '
        Me.dgv_MOTIVOSAGUARDANDO.AllowUserToAddRows = False
        Me.dgv_MOTIVOSAGUARDANDO.AllowUserToDeleteRows = False
        Me.dgv_MOTIVOSAGUARDANDO.AllowUserToResizeRows = False
        Me.dgv_MOTIVOSAGUARDANDO.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSAGUARDANDO.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_MOTIVOSAGUARDANDO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_MOTIVOSAGUARDANDO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxXColumn1})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_MOTIVOSAGUARDANDO.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_MOTIVOSAGUARDANDO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_MOTIVOSAGUARDANDO.EnableHeadersVisualStyles = False
        Me.dgv_MOTIVOSAGUARDANDO.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_MOTIVOSAGUARDANDO.Location = New System.Drawing.Point(0, 26)
        Me.dgv_MOTIVOSAGUARDANDO.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_MOTIVOSAGUARDANDO.MultiSelect = False
        Me.dgv_MOTIVOSAGUARDANDO.Name = "dgv_MOTIVOSAGUARDANDO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSAGUARDANDO.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        Me.dgv_MOTIVOSAGUARDANDO.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgv_MOTIVOSAGUARDANDO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_MOTIVOSAGUARDANDO.Size = New System.Drawing.Size(365, 461)
        Me.dgv_MOTIVOSAGUARDANDO.TabIndex = 15
        '
        'DataGridViewLabelXColumn1
        '
        Me.DataGridViewLabelXColumn1.HeaderText = "Id"
        Me.DataGridViewLabelXColumn1.Name = "DataGridViewLabelXColumn1"
        Me.DataGridViewLabelXColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Format = "N2"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn1.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = "N"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "Considerar"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        Me.DataGridViewCheckBoxXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxXColumn1.Width = 70
        '
        'ExpandableSplitter2
        '
        Me.ExpandableSplitter2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.ExpandLineColor = System.Drawing.Color.Black
        Me.ExpandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.ForeColor = System.Drawing.Color.Black
        Me.ExpandableSplitter2.GripDarkColor = System.Drawing.Color.Black
        Me.ExpandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.ExpandableSplitter2.HotBackColor2 = System.Drawing.Color.Empty
        Me.ExpandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.HotExpandLineColor = System.Drawing.Color.Black
        Me.ExpandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ExpandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.ExpandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter2.Location = New System.Drawing.Point(724, 67)
        Me.ExpandableSplitter2.Name = "ExpandableSplitter2"
        Me.ExpandableSplitter2.Size = New System.Drawing.Size(5, 487)
        Me.ExpandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter2.TabIndex = 32
        Me.ExpandableSplitter2.TabStop = False
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel2.Controls.Add(Me.dgv_MOTIVOSBOTAOFECHARPARADA)
        Me.ExpandablePanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.HideControlsWhenCollapsed = True
        Me.ExpandablePanel2.Location = New System.Drawing.Point(729, 67)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(351, 487)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.Color = System.Drawing.Color.Black
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 36
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Motivos Fechamento Exclusivo da Manutenção"
        '
        'dgv_MOTIVOSBOTAOFECHARPARADA
        '
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.AllowUserToAddRows = False
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.AllowUserToDeleteRows = False
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.AllowUserToResizeRows = False
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn2, Me.DataGridViewTextBoxColumn2, Me.DataGridViewCheckBoxXColumn2})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.EnableHeadersVisualStyles = False
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Location = New System.Drawing.Point(0, 26)
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.MultiSelect = False
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Name = "dgv_MOTIVOSBOTAOFECHARPARADA"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.Size = New System.Drawing.Size(351, 461)
        Me.dgv_MOTIVOSBOTAOFECHARPARADA.TabIndex = 15
        '
        'DataGridViewLabelXColumn2
        '
        Me.DataGridViewLabelXColumn2.HeaderText = "Id"
        Me.DataGridViewLabelXColumn2.Name = "DataGridViewLabelXColumn2"
        Me.DataGridViewLabelXColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.Format = "N2"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descrição"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewCheckBoxXColumn2
        '
        Me.DataGridViewCheckBoxXColumn2.Checked = True
        Me.DataGridViewCheckBoxXColumn2.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn2.CheckValue = "N"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn2.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewCheckBoxXColumn2.HeaderText = "Considerar"
        Me.DataGridViewCheckBoxXColumn2.Name = "DataGridViewCheckBoxXColumn2"
        Me.DataGridViewCheckBoxXColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxXColumn2.Width = 70
        '
        'frm_MANUTENCAO_CONFIG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 554)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandableSplitter2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.ep_NIVEL1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_MANUTENCAO_CONFIG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuração de Dados da Manutenção"
        Me.ep_NIVEL1.ResumeLayout(False)
        CType(Me.dgv_MOTIVOSPARADA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.dgv_MOTIVOSAGUARDANDO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.dgv_MOTIVOSBOTAOFECHARPARADA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_CANCEL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ep_NIVEL1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgv_MOTIVOSPARADA As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgv_MOTIVOSAGUARDANDO As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewLabelXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents DataGridViewLabelXColumn5 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewLabelXColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents ExpandableSplitter2 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgv_MOTIVOSBOTAOFECHARPARADA As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewLabelXColumn2 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxXColumn2 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
