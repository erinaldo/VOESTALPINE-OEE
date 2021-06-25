<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_DBSEARCH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_DBSEARCH))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_MAIN = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_CANCEL = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SERVER = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.tb_IPEXTERNO = New DevComponents.DotNetBar.TextBoxItem()
        Me.bt_IPEXTERNO = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.cp_PROGRESS = New DevComponents.DotNetBar.CircularProgressItem()
        Me.dgv_SERVERS = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column6 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Column5 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.col_IP = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.tmr_THREAD = New System.Windows.Forms.Timer(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.tmr_EXTERNO = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv_SERVERS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribBar_MAIN
        '
        Me.ribBar_MAIN.AutoOverflowEnabled = True
        '
        '
        '
        Me.ribBar_MAIN.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_MAIN.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ribBar_MAIN.ContainerControlProcessDialogKey = True
        Me.ribBar_MAIN.Dock = System.Windows.Forms.DockStyle.Top
        Me.ribBar_MAIN.DragDropSupport = True
        Me.ribBar_MAIN.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ribBar_MAIN.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SAVE, Me.bt_CANCEL, Me.ItemContainer3, Me.ItemContainer1, Me.ItemContainer2})
        Me.ribBar_MAIN.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_MAIN.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_MAIN.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ribBar_MAIN.Name = "ribBar_MAIN"
        Me.ribBar_MAIN.Size = New System.Drawing.Size(491, 75)
        Me.ribBar_MAIN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_MAIN.TabIndex = 8
        '
        '
        '
        Me.ribBar_MAIN.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_MAIN.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_SAVE
        '
        Me.bt_SAVE.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SAVE.Image = CType(resources.GetObject("bt_SAVE.Image"), System.Drawing.Image)
        Me.bt_SAVE.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.SubItemsExpandWidth = 14
        Me.bt_SAVE.Text = "Selecionar Servidor"
        '
        'bt_CANCEL
        '
        Me.bt_CANCEL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_CANCEL.Image = CType(resources.GetObject("bt_CANCEL.Image"), System.Drawing.Image)
        Me.bt_CANCEL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_CANCEL.Name = "bt_CANCEL"
        Me.bt_CANCEL.SubItemsExpandWidth = 14
        Me.bt_CANCEL.Text = "Sair sem Salvar"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SERVER})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_SERVER
        '
        Me.bt_SERVER.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SERVER.Image = CType(resources.GetObject("bt_SERVER.Image"), System.Drawing.Image)
        Me.bt_SERVER.ImageAlt = CType(resources.GetObject("bt_SERVER.ImageAlt"), System.Drawing.Image)
        Me.bt_SERVER.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_SERVER.Name = "bt_SERVER"
        Me.bt_SERVER.SubItemsExpandWidth = 14
        Me.bt_SERVER.Text = "Servidor Externo"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.tb_IPEXTERNO, Me.bt_IPEXTERNO})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "IP/URL Servidor Externo"
        '
        'tb_IPEXTERNO
        '
        Me.tb_IPEXTERNO.Enabled = False
        Me.tb_IPEXTERNO.Name = "tb_IPEXTERNO"
        Me.tb_IPEXTERNO.TextBoxWidth = 150
        Me.tb_IPEXTERNO.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'bt_IPEXTERNO
        '
        Me.bt_IPEXTERNO.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_IPEXTERNO.Enabled = False
        Me.bt_IPEXTERNO.Image = CType(resources.GetObject("bt_IPEXTERNO.Image"), System.Drawing.Image)
        Me.bt_IPEXTERNO.ImageAlt = CType(resources.GetObject("bt_IPEXTERNO.ImageAlt"), System.Drawing.Image)
        Me.bt_IPEXTERNO.Name = "bt_IPEXTERNO"
        Me.bt_IPEXTERNO.Text = "Selecionar Servidor"
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer2.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer2.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.cp_PROGRESS})
        '
        '
        '
        Me.ItemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'cp_PROGRESS
        '
        Me.cp_PROGRESS.Name = "cp_PROGRESS"
        Me.cp_PROGRESS.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.cp_PROGRESS.ProgressColor = System.Drawing.Color.DimGray
        Me.cp_PROGRESS.Text = "  Localizando Servidor ..."
        Me.cp_PROGRESS.Visible = False
        '
        'dgv_SERVERS
        '
        Me.dgv_SERVERS.AllowUserToAddRows = False
        Me.dgv_SERVERS.AllowUserToDeleteRows = False
        Me.dgv_SERVERS.AllowUserToResizeRows = False
        Me.dgv_SERVERS.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SERVERS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_SERVERS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_SERVERS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column5, Me.col_IP})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_SERVERS.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_SERVERS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SERVERS.EnableHeadersVisualStyles = False
        Me.dgv_SERVERS.GridColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.dgv_SERVERS.Location = New System.Drawing.Point(0, 75)
        Me.dgv_SERVERS.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.dgv_SERVERS.MultiSelect = False
        Me.dgv_SERVERS.Name = "dgv_SERVERS"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_SERVERS.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgv_SERVERS.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_SERVERS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_SERVERS.Size = New System.Drawing.Size(491, 236)
        Me.dgv_SERVERS.TabIndex = 9
        '
        'Column6
        '
        Me.Column6.Checked = True
        Me.Column6.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Column6.CheckValue = "N"
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.Width = 30
        '
        'Column5
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Computador"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 248
        '
        'col_IP
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.col_IP.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_IP.HeaderText = "Servidor"
        Me.col_IP.Name = "col_IP"
        Me.col_IP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.col_IP.Width = 150
        '
        'tmr_THREAD
        '
        Me.tmr_THREAD.Interval = 1000
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'tmr_EXTERNO
        '
        '
        'frm_DBSEARCH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 311)
        Me.Controls.Add(Me.dgv_SERVERS)
        Me.Controls.Add(Me.ribBar_MAIN)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_DBSEARCH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor de Dados omniViewer"
        Me.TopMost = True
        CType(Me.dgv_SERVERS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_MAIN As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents dgv_SERVERS As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_CANCEL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents cp_PROGRESS As DevComponents.DotNetBar.CircularProgressItem
    Friend WithEvents tmr_THREAD As Timer
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents bt_SERVER As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents tb_IPEXTERNO As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents bt_IPEXTERNO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Column6 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Column5 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents col_IP As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents tmr_EXTERNO As Timer
End Class
