<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_FERIADOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_FERIADOS))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_ADDFERIADO = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_EXCLUIRFERIADO = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_CANCEL = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.dgv_FERIADOS = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewLabelXColumn9 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewLabelXColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgv_FERIADOS, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_ADDFERIADO, Me.bt_EXCLUIRFERIADO, Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(430, 74)
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
        'bt_ADDFERIADO
        '
        Me.bt_ADDFERIADO.Image = CType(resources.GetObject("bt_ADDFERIADO.Image"), System.Drawing.Image)
        Me.bt_ADDFERIADO.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_ADDFERIADO.Name = "bt_ADDFERIADO"
        Me.bt_ADDFERIADO.SubItemsExpandWidth = 14
        Me.bt_ADDFERIADO.Text = "Adicionar Feriado"
        '
        'bt_EXCLUIRFERIADO
        '
        Me.bt_EXCLUIRFERIADO.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_EXCLUIRFERIADO.Enabled = False
        Me.bt_EXCLUIRFERIADO.Image = CType(resources.GetObject("bt_EXCLUIRFERIADO.Image"), System.Drawing.Image)
        Me.bt_EXCLUIRFERIADO.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_EXCLUIRFERIADO.Name = "bt_EXCLUIRFERIADO"
        Me.bt_EXCLUIRFERIADO.Text = "Excluir Feriado"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderLeftWidth = 1
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
        'dgv_FERIADOS
        '
        Me.dgv_FERIADOS.AllowUserToAddRows = False
        Me.dgv_FERIADOS.AllowUserToDeleteRows = False
        Me.dgv_FERIADOS.AllowUserToResizeRows = False
        Me.dgv_FERIADOS.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_FERIADOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_FERIADOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FERIADOS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewLabelXColumn9, Me.DataGridViewLabelXColumn10, Me.Column3, Me.Column1, Me.Column2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_FERIADOS.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_FERIADOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_FERIADOS.EnableHeadersVisualStyles = False
        Me.dgv_FERIADOS.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_FERIADOS.Location = New System.Drawing.Point(0, 74)
        Me.dgv_FERIADOS.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_FERIADOS.MultiSelect = False
        Me.dgv_FERIADOS.Name = "dgv_FERIADOS"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_FERIADOS.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgv_FERIADOS.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_FERIADOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_FERIADOS.Size = New System.Drawing.Size(430, 249)
        Me.dgv_FERIADOS.TabIndex = 18
        '
        'DataGridViewLabelXColumn9
        '
        Me.DataGridViewLabelXColumn9.HeaderText = "Id"
        Me.DataGridViewLabelXColumn9.Name = "DataGridViewLabelXColumn9"
        Me.DataGridViewLabelXColumn9.Visible = False
        '
        'DataGridViewLabelXColumn10
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewLabelXColumn10.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewLabelXColumn10.HeaderText = "Feriado"
        Me.DataGridViewLabelXColumn10.Name = "DataGridViewLabelXColumn10"
        Me.DataGridViewLabelXColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLabelXColumn10.Width = 150
        '
        'Column3
        '
        '
        '
        '
        Me.Column3.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.HeaderText = "Data"
        Me.Column3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        '
        '
        '
        '
        '
        '
        Me.Column3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.Column3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.MonthCalendar.DisplayMonth = New Date(2020, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.Column3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Column3.Name = "Column3"
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
        'frm_FERIADOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 323)
        Me.Controls.Add(Me.dgv_FERIADOS)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_FERIADOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Feriados"
        CType(Me.dgv_FERIADOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_ADDFERIADO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_EXCLUIRFERIADO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_CANCEL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgv_FERIADOS As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewLabelXColumn9 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewLabelXColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
End Class
