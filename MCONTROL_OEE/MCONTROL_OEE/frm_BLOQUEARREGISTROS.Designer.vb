<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BLOQUEARREGISTROS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_BLOQUEARREGISTROS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_PARADAS = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_BLOQUEAR = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_SAIR = New DevComponents.DotNetBar.ButtonItem()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.dti_HFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel()
        Me.dgv_PARADAS = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column19 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.DataGridViewDateTimeInputColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column4 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column17 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column5 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column20 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column18 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column2 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column3 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column1 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.Column21 = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.PanelEx1.SuspendLayout()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.dgv_PARADAS, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_PARADAS, Me.bt_BLOQUEAR, Me.bt_SAIR})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(1095, 67)
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
        'bt_PARADAS
        '
        Me.bt_PARADAS.Enabled = False
        Me.bt_PARADAS.Image = CType(resources.GetObject("bt_PARADAS.Image"), System.Drawing.Image)
        Me.bt_PARADAS.ImageAlt = CType(resources.GetObject("bt_PARADAS.ImageAlt"), System.Drawing.Image)
        Me.bt_PARADAS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_PARADAS.Name = "bt_PARADAS"
        Me.bt_PARADAS.SubItemsExpandWidth = 14
        Me.bt_PARADAS.Text = "Listar Paradas"
        '
        'bt_BLOQUEAR
        '
        Me.bt_BLOQUEAR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_BLOQUEAR.Enabled = False
        Me.bt_BLOQUEAR.Image = CType(resources.GetObject("bt_BLOQUEAR.Image"), System.Drawing.Image)
        Me.bt_BLOQUEAR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_BLOQUEAR.Name = "bt_BLOQUEAR"
        Me.bt_BLOQUEAR.SubItemsExpandWidth = 14
        Me.bt_BLOQUEAR.Text = "Bloquear Registros"
        '
        'bt_SAIR
        '
        Me.bt_SAIR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SAIR.Image = CType(resources.GetObject("bt_SAIR.Image"), System.Drawing.Image)
        Me.bt_SAIR.ImageAlt = CType(resources.GetObject("bt_SAIR.ImageAlt"), System.Drawing.Image)
        Me.bt_SAIR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_SAIR.Name = "bt_SAIR"
        Me.bt_SAIR.SubItemsExpandWidth = 14
        Me.bt_SAIR.Text = "Sair"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.dti_HFINAL)
        Me.PanelEx1.Controls.Add(Me.dti_HINICIAL)
        Me.PanelEx1.Controls.Add(Me.dti_DFINAL)
        Me.PanelEx1.Controls.Add(Me.dti_DINICIAL)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.cb_MAQUINAID)
        Me.PanelEx1.Controls.Add(Me.cb_MAQUINA)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 67)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1095, 114)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 24
        '
        'dti_HFINAL
        '
        Me.dti_HFINAL.AutoAdvance = True
        '
        '
        '
        Me.dti_HFINAL.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_HFINAL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_HFINAL.ButtonDropDown.Visible = True
        Me.dti_HFINAL.CustomFormat = "00:00"
        Me.dti_HFINAL.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.dti_HFINAL.DefaultInputValues = False
        Me.dti_HFINAL.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime
        Me.dti_HFINAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HFINAL.IsPopupCalendarOpen = False
        Me.dti_HFINAL.Location = New System.Drawing.Point(174, 74)
        '
        '
        '
        '
        '
        '
        Me.dti_HFINAL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_HFINAL.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_HFINAL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_HFINAL.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_HFINAL.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HFINAL.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_HFINAL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL.MonthCalendar.TodayButtonVisible = True
        Me.dti_HFINAL.MonthCalendar.Visible = False
        Me.dti_HFINAL.Name = "dti_HFINAL"
        Me.dti_HFINAL.Size = New System.Drawing.Size(84, 22)
        Me.dti_HFINAL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_HFINAL.TabIndex = 34
        Me.dti_HFINAL.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'dti_HINICIAL
        '
        Me.dti_HINICIAL.AutoAdvance = True
        '
        '
        '
        Me.dti_HINICIAL.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_HINICIAL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_HINICIAL.ButtonDropDown.Visible = True
        Me.dti_HINICIAL.CustomFormat = "00:00"
        Me.dti_HINICIAL.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.dti_HINICIAL.DefaultInputValues = False
        Me.dti_HINICIAL.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime
        Me.dti_HINICIAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HINICIAL.IsPopupCalendarOpen = False
        Me.dti_HINICIAL.Location = New System.Drawing.Point(174, 46)
        '
        '
        '
        '
        '
        '
        Me.dti_HINICIAL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_HINICIAL.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_HINICIAL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_HINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_HINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_HINICIAL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL.MonthCalendar.TodayButtonVisible = True
        Me.dti_HINICIAL.MonthCalendar.Visible = False
        Me.dti_HINICIAL.Name = "dti_HINICIAL"
        Me.dti_HINICIAL.Size = New System.Drawing.Size(84, 22)
        Me.dti_HINICIAL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_HINICIAL.TabIndex = 33
        Me.dti_HINICIAL.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'dti_DFINAL
        '
        Me.dti_DFINAL.AutoAdvance = True
        '
        '
        '
        Me.dti_DFINAL.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DFINAL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINAL.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DFINAL.ButtonDropDown.Visible = True
        Me.dti_DFINAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DFINAL.IsPopupCalendarOpen = False
        Me.dti_DFINAL.Location = New System.Drawing.Point(84, 74)
        '
        '
        '
        '
        '
        '
        Me.dti_DFINAL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINAL.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DFINAL.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DFINAL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINAL.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DFINAL.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DFINAL.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINAL.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DFINAL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINAL.MonthCalendar.TodayButtonVisible = True
        Me.dti_DFINAL.Name = "dti_DFINAL"
        Me.dti_DFINAL.Size = New System.Drawing.Size(84, 22)
        Me.dti_DFINAL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DFINAL.TabIndex = 30
        '
        'dti_DINICIAL
        '
        Me.dti_DINICIAL.AutoAdvance = True
        '
        '
        '
        Me.dti_DINICIAL.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DINICIAL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIAL.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DINICIAL.ButtonDropDown.Visible = True
        Me.dti_DINICIAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DINICIAL.IsPopupCalendarOpen = False
        Me.dti_DINICIAL.Location = New System.Drawing.Point(84, 46)
        '
        '
        '
        '
        '
        '
        Me.dti_DINICIAL.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIAL.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DINICIAL.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DINICIAL.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIAL.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIAL.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DINICIAL.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIAL.MonthCalendar.TodayButtonVisible = True
        Me.dti_DINICIAL.Name = "dti_DINICIAL"
        Me.dti_DINICIAL.Size = New System.Drawing.Size(84, 22)
        Me.dti_DINICIAL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DINICIAL.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Data Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Data Inicial"
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(374, 48)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(55, 24)
        Me.cb_MAQUINAID.TabIndex = 2
        Me.cb_MAQUINAID.Visible = False
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(84, 16)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(345, 24)
        Me.cb_MAQUINA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Máquina"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExpandablePanel1.Controls.Add(Me.dgv_PARADAS)
        Me.ExpandablePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel1.ExpandButtonVisible = False
        Me.ExpandablePanel1.HideControlsWhenCollapsed = True
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 181)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(1095, 305)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 28
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Histórico de Paradas"
        '
        'dgv_PARADAS
        '
        Me.dgv_PARADAS.AllowUserToAddRows = False
        Me.dgv_PARADAS.AllowUserToDeleteRows = False
        Me.dgv_PARADAS.AllowUserToResizeRows = False
        Me.dgv_PARADAS.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_PARADAS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_PARADAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_PARADAS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column19, Me.DataGridViewDateTimeInputColumn1, Me.Column4, Me.Column17, Me.Column5, Me.Column20, Me.Column18, Me.Column2, Me.Column3, Me.Column1, Me.Column21})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_PARADAS.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv_PARADAS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_PARADAS.EnableHeadersVisualStyles = False
        Me.dgv_PARADAS.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgv_PARADAS.Location = New System.Drawing.Point(0, 26)
        Me.dgv_PARADAS.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.dgv_PARADAS.Name = "dgv_PARADAS"
        Me.dgv_PARADAS.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_PARADAS.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.dgv_PARADAS.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgv_PARADAS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_PARADAS.Size = New System.Drawing.Size(1095, 279)
        Me.dgv_PARADAS.TabIndex = 15
        '
        'Column19
        '
        Me.Column19.HeaderText = "Id"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Visible = False
        '
        'DataGridViewDateTimeInputColumn1
        '
        Me.DataGridViewDateTimeInputColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Format = "d"
        Me.DataGridViewDateTimeInputColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDateTimeInputColumn1.HeaderText = "Data Inicial"
        Me.DataGridViewDateTimeInputColumn1.Name = "DataGridViewDateTimeInputColumn1"
        Me.DataGridViewDateTimeInputColumn1.ReadOnly = True
        Me.DataGridViewDateTimeInputColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDateTimeInputColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewDateTimeInputColumn1.Width = 85
        '
        'Column4
        '
        Me.Column4.HeaderText = "Horário Inicial"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 85
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column17.HeaderText = "Data Final"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column17.Width = 85
        '
        'Column5
        '
        Me.Column5.HeaderText = "Horário Final"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 85
        '
        'Column20
        '
        Me.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column20.HeaderText = "Tempo Parada"
        Me.Column20.MinimumWidth = 100
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column18.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column18.HeaderText = "Motivo Parada Nível 1"
        Me.Column18.MinimumWidth = 150
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column18.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.Column18.Width = 150
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Motivo Parada Nível 2"
        Me.Column2.MinimumWidth = 150
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = "Motivo Parada Nível 3"
        Me.Column3.MinimumWidth = 150
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column1.HeaderText = "Operador"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column21
        '
        Me.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column21.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column21.HeaderText = "Comentários"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Width = 73
        '
        'frm_BLOQUEARREGISTROS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 486)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_BLOQUEARREGISTROS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bloqueio de Registros"
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.dgv_PARADAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_PARADAS As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_BLOQUEAR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_SAIR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents dti_HFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgv_PARADAS As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column19 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents DataGridViewDateTimeInputColumn1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column4 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column17 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column5 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column20 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column18 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column2 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column3 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column1 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents Column21 As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
End Class
