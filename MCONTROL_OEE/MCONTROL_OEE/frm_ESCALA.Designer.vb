<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ESCALA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ESCALA))
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_TURNO = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_EXCLUIR = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_DEFINIRPERIODO = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dti_DINICIALPESQUISA = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cb_TIPOESCALA = New System.Windows.Forms.ComboBox()
        Me.dti_DFINALPESQUISA = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_ATUALIZARESCALA = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gb_INCLUIRPERIODOS = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dti_HFINAL1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.dti_HINICIAL1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.cb_TURNOID = New System.Windows.Forms.ComboBox()
        Me.cb_FIMDESEMANA = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_ADICIONARPERIODO = New System.Windows.Forms.Button()
        Me.dti_DINICIALADD = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cb_TURNO = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dti_DFINALADD = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cv_ESCALA = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.cms_CV = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bt_EXCLUIRPERIODO = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmr_TURNO = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_ESCALA = New System.Windows.Forms.Timer(Me.components)
        Me.DateNavigator1 = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tmr_DEFINIRPERIODO = New System.Windows.Forms.Timer(Me.components)
        Me.PanelEx1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dti_DINICIALPESQUISA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINALPESQUISA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_INCLUIRPERIODOS.SuspendLayout()
        CType(Me.dti_HFINAL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DINICIALADD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINALADD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_CV.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_TURNO, Me.bt_EXCLUIR, Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(683, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 24
        Me.ribBar_ETH.TabStop = False
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_TURNO
        '
        Me.bt_TURNO.Enabled = False
        Me.bt_TURNO.Image = CType(resources.GetObject("bt_TURNO.Image"), System.Drawing.Image)
        Me.bt_TURNO.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_TURNO.Name = "bt_TURNO"
        Me.bt_TURNO.SubItemsExpandWidth = 14
        Me.bt_TURNO.Text = "Editar Turnos Trabalho"
        '
        'bt_EXCLUIR
        '
        Me.bt_EXCLUIR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_EXCLUIR.Enabled = False
        Me.bt_EXCLUIR.Image = CType(resources.GetObject("bt_EXCLUIR.Image"), System.Drawing.Image)
        Me.bt_EXCLUIR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_EXCLUIR.Name = "bt_EXCLUIR"
        Me.bt_EXCLUIR.Text = "Excluir Períodos"
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
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_DEFINIRPERIODO})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_DEFINIRPERIODO
        '
        Me.bt_DEFINIRPERIODO.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_DEFINIRPERIODO.Enabled = False
        Me.bt_DEFINIRPERIODO.Image = CType(resources.GetObject("bt_DEFINIRPERIODO.Image"), System.Drawing.Image)
        Me.bt_DEFINIRPERIODO.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_DEFINIRPERIODO.Name = "bt_DEFINIRPERIODO"
        Me.bt_DEFINIRPERIODO.Text = "Definir Período"
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
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.Controls.Add(Me.gb_INCLUIRPERIODOS)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 67)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(683, 199)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dti_DINICIALPESQUISA)
        Me.GroupBox1.Controls.Add(Me.cb_TIPOESCALA)
        Me.GroupBox1.Controls.Add(Me.dti_DFINALPESQUISA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.bt_ATUALIZARESCALA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 182)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'dti_DINICIALPESQUISA
        '
        Me.dti_DINICIALPESQUISA.AutoAdvance = True
        '
        '
        '
        Me.dti_DINICIALPESQUISA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DINICIALPESQUISA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALPESQUISA.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DINICIALPESQUISA.ButtonDropDown.Visible = True
        Me.dti_DINICIALPESQUISA.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DINICIALPESQUISA.IsPopupCalendarOpen = False
        Me.dti_DINICIALPESQUISA.Location = New System.Drawing.Point(78, 21)
        '
        '
        '
        '
        '
        '
        Me.dti_DINICIALPESQUISA.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALPESQUISA.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DINICIALPESQUISA.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DINICIALPESQUISA.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALPESQUISA.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DINICIALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DINICIALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DINICIALPESQUISA.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALPESQUISA.MonthCalendar.TodayButtonVisible = True
        Me.dti_DINICIALPESQUISA.Name = "dti_DINICIALPESQUISA"
        Me.dti_DINICIALPESQUISA.Size = New System.Drawing.Size(84, 22)
        Me.dti_DINICIALPESQUISA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DINICIALPESQUISA.TabIndex = 36
        Me.dti_DINICIALPESQUISA.TabStop = False
        '
        'cb_TIPOESCALA
        '
        Me.cb_TIPOESCALA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TIPOESCALA.Enabled = False
        Me.cb_TIPOESCALA.FormattingEnabled = True
        Me.cb_TIPOESCALA.Items.AddRange(New Object() {"Anual", "Diário", "Mensal", "Semanal", "Time Line"})
        Me.cb_TIPOESCALA.Location = New System.Drawing.Point(78, 80)
        Me.cb_TIPOESCALA.Name = "cb_TIPOESCALA"
        Me.cb_TIPOESCALA.Size = New System.Drawing.Size(84, 24)
        Me.cb_TIPOESCALA.TabIndex = 40
        Me.cb_TIPOESCALA.TabStop = False
        '
        'dti_DFINALPESQUISA
        '
        Me.dti_DFINALPESQUISA.AutoAdvance = True
        '
        '
        '
        Me.dti_DFINALPESQUISA.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DFINALPESQUISA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALPESQUISA.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DFINALPESQUISA.ButtonDropDown.Visible = True
        Me.dti_DFINALPESQUISA.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DFINALPESQUISA.IsPopupCalendarOpen = False
        Me.dti_DFINALPESQUISA.Location = New System.Drawing.Point(78, 49)
        '
        '
        '
        '
        '
        '
        Me.dti_DFINALPESQUISA.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALPESQUISA.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DFINALPESQUISA.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DFINALPESQUISA.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALPESQUISA.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DFINALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DFINALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINALPESQUISA.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DFINALPESQUISA.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALPESQUISA.MonthCalendar.TodayButtonVisible = True
        Me.dti_DFINALPESQUISA.Name = "dti_DFINALPESQUISA"
        Me.dti_DFINALPESQUISA.Size = New System.Drawing.Size(84, 22)
        Me.dti_DFINALPESQUISA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DFINALPESQUISA.TabIndex = 37
        Me.dti_DFINALPESQUISA.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Formato"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Data Final"
        '
        'bt_ATUALIZARESCALA
        '
        Me.bt_ATUALIZARESCALA.Enabled = False
        Me.bt_ATUALIZARESCALA.Image = CType(resources.GetObject("bt_ATUALIZARESCALA.Image"), System.Drawing.Image)
        Me.bt_ATUALIZARESCALA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ATUALIZARESCALA.Location = New System.Drawing.Point(78, 110)
        Me.bt_ATUALIZARESCALA.Name = "bt_ATUALIZARESCALA"
        Me.bt_ATUALIZARESCALA.Size = New System.Drawing.Size(84, 29)
        Me.bt_ATUALIZARESCALA.TabIndex = 38
        Me.bt_ATUALIZARESCALA.TabStop = False
        Me.bt_ATUALIZARESCALA.Text = "     Visualisar"
        Me.bt_ATUALIZARESCALA.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Data Inicial"
        '
        'gb_INCLUIRPERIODOS
        '
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label9)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label8)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.dti_HFINAL1)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.cb_MAQUINAID)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.dti_HINICIAL1)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label1)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.cb_MAQUINA)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.cb_TURNOID)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.cb_FIMDESEMANA)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label4)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.bt_ADICIONARPERIODO)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.dti_DINICIALADD)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.cb_TURNO)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label3)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.Label2)
        Me.gb_INCLUIRPERIODOS.Controls.Add(Me.dti_DFINALADD)
        Me.gb_INCLUIRPERIODOS.Location = New System.Drawing.Point(12, 7)
        Me.gb_INCLUIRPERIODOS.Name = "gb_INCLUIRPERIODOS"
        Me.gb_INCLUIRPERIODOS.Size = New System.Drawing.Size(469, 182)
        Me.gb_INCLUIRPERIODOS.TabIndex = 33
        Me.gb_INCLUIRPERIODOS.TabStop = False
        Me.gb_INCLUIRPERIODOS.Text = "Inclusão de Períodos"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(240, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Intervalo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(333, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 16)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "até"
        '
        'dti_HFINAL1
        '
        Me.dti_HFINAL1.AutoAdvance = True
        '
        '
        '
        Me.dti_HFINAL1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_HFINAL1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_HFINAL1.ButtonDropDown.Visible = True
        Me.dti_HFINAL1.CustomFormat = "00:00"
        Me.dti_HFINAL1.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.dti_HFINAL1.DefaultInputValues = False
        Me.dti_HFINAL1.Enabled = False
        Me.dti_HFINAL1.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime
        Me.dti_HFINAL1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HFINAL1.IsPopupCalendarOpen = False
        Me.dti_HFINAL1.Location = New System.Drawing.Point(357, 103)
        '
        '
        '
        '
        '
        '
        Me.dti_HFINAL1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_HFINAL1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_HFINAL1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL1.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_HFINAL1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_HFINAL1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HFINAL1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_HFINAL1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HFINAL1.MonthCalendar.TodayButtonVisible = True
        Me.dti_HFINAL1.MonthCalendar.Visible = False
        Me.dti_HFINAL1.Name = "dti_HFINAL1"
        Me.dti_HFINAL1.Size = New System.Drawing.Size(84, 22)
        Me.dti_HFINAL1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_HFINAL1.TabIndex = 6
        Me.dti_HFINAL1.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(220, 12)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(55, 24)
        Me.cb_MAQUINAID.TabIndex = 2
        Me.cb_MAQUINAID.TabStop = False
        Me.cb_MAQUINAID.Visible = False
        '
        'dti_HINICIAL1
        '
        Me.dti_HINICIAL1.AutoAdvance = True
        '
        '
        '
        Me.dti_HINICIAL1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_HINICIAL1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_HINICIAL1.ButtonDropDown.Visible = True
        Me.dti_HINICIAL1.CustomFormat = "00:00"
        Me.dti_HINICIAL1.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.dti_HINICIAL1.DefaultInputValues = False
        Me.dti_HINICIAL1.Enabled = False
        Me.dti_HINICIAL1.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime
        Me.dti_HINICIAL1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HINICIAL1.IsPopupCalendarOpen = False
        Me.dti_HINICIAL1.Location = New System.Drawing.Point(243, 103)
        '
        '
        '
        '
        '
        '
        Me.dti_HINICIAL1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_HINICIAL1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_HINICIAL1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL1.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_HINICIAL1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_HINICIAL1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_HINICIAL1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_HINICIAL1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_HINICIAL1.MonthCalendar.TodayButtonVisible = True
        Me.dti_HINICIAL1.MonthCalendar.Visible = False
        Me.dti_HINICIAL1.Name = "dti_HINICIAL1"
        Me.dti_HINICIAL1.Size = New System.Drawing.Size(84, 22)
        Me.dti_HINICIAL1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_HINICIAL1.TabIndex = 5
        Me.dti_HINICIAL1.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Máquina"
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(17, 42)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(258, 24)
        Me.cb_MAQUINA.TabIndex = 0
        '
        'cb_TURNOID
        '
        Me.cb_TURNOID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TURNOID.FormattingEnabled = True
        Me.cb_TURNOID.Location = New System.Drawing.Point(434, 15)
        Me.cb_TURNOID.Name = "cb_TURNOID"
        Me.cb_TURNOID.Size = New System.Drawing.Size(25, 24)
        Me.cb_TURNOID.TabIndex = 35
        Me.cb_TURNOID.TabStop = False
        Me.cb_TURNOID.Visible = False
        '
        'cb_FIMDESEMANA
        '
        Me.cb_FIMDESEMANA.AutoSize = True
        Me.cb_FIMDESEMANA.Location = New System.Drawing.Point(136, 141)
        Me.cb_FIMDESEMANA.Name = "cb_FIMDESEMANA"
        Me.cb_FIMDESEMANA.Size = New System.Drawing.Size(150, 20)
        Me.cb_FIMDESEMANA.TabIndex = 34
        Me.cb_FIMDESEMANA.Text = "Ignorar FIM DE SEMANA"
        Me.cb_FIMDESEMANA.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Turno"
        '
        'bt_ADICIONARPERIODO
        '
        Me.bt_ADICIONARPERIODO.Enabled = False
        Me.bt_ADICIONARPERIODO.Image = CType(resources.GetObject("bt_ADICIONARPERIODO.Image"), System.Drawing.Image)
        Me.bt_ADICIONARPERIODO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ADICIONARPERIODO.Location = New System.Drawing.Point(17, 136)
        Me.bt_ADICIONARPERIODO.Name = "bt_ADICIONARPERIODO"
        Me.bt_ADICIONARPERIODO.Size = New System.Drawing.Size(84, 29)
        Me.bt_ADICIONARPERIODO.TabIndex = 7
        Me.bt_ADICIONARPERIODO.Text = "     Adicionar"
        Me.bt_ADICIONARPERIODO.UseVisualStyleBackColor = True
        '
        'dti_DINICIALADD
        '
        Me.dti_DINICIALADD.AutoAdvance = True
        '
        '
        '
        Me.dti_DINICIALADD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DINICIALADD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALADD.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DINICIALADD.ButtonDropDown.Visible = True
        Me.dti_DINICIALADD.Enabled = False
        Me.dti_DINICIALADD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DINICIALADD.IsPopupCalendarOpen = False
        Me.dti_DINICIALADD.Location = New System.Drawing.Point(17, 103)
        '
        '
        '
        '
        '
        '
        Me.dti_DINICIALADD.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALADD.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DINICIALADD.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DINICIALADD.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALADD.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DINICIALADD.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DINICIALADD.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DINICIALADD.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DINICIALADD.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DINICIALADD.MonthCalendar.TodayButtonVisible = True
        Me.dti_DINICIALADD.Name = "dti_DINICIALADD"
        Me.dti_DINICIALADD.Size = New System.Drawing.Size(84, 22)
        Me.dti_DINICIALADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DINICIALADD.TabIndex = 3
        '
        'cb_TURNO
        '
        Me.cb_TURNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TURNO.FormattingEnabled = True
        Me.cb_TURNO.Location = New System.Drawing.Point(286, 42)
        Me.cb_TURNO.Name = "cb_TURNO"
        Me.cb_TURNO.Size = New System.Drawing.Size(173, 24)
        Me.cb_TURNO.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Período"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "até"
        '
        'dti_DFINALADD
        '
        Me.dti_DFINALADD.AutoAdvance = True
        '
        '
        '
        Me.dti_DFINALADD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dti_DFINALADD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALADD.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dti_DFINALADD.ButtonDropDown.Visible = True
        Me.dti_DFINALADD.Enabled = False
        Me.dti_DFINALADD.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_DFINALADD.IsPopupCalendarOpen = False
        Me.dti_DFINALADD.Location = New System.Drawing.Point(136, 104)
        '
        '
        '
        '
        '
        '
        Me.dti_DFINALADD.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALADD.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dti_DFINALADD.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dti_DFINALADD.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALADD.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dti_DFINALADD.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dti_DFINALADD.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dti_DFINALADD.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dti_DFINALADD.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dti_DFINALADD.MonthCalendar.TodayButtonVisible = True
        Me.dti_DFINALADD.Name = "dti_DFINALADD"
        Me.dti_DFINALADD.Size = New System.Drawing.Size(84, 22)
        Me.dti_DFINALADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dti_DFINALADD.TabIndex = 4
        '
        'cv_ESCALA
        '
        Me.cv_ESCALA.AutoScrollMinSize = New System.Drawing.Size(252, 980)
        Me.cv_ESCALA.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        '
        '
        '
        Me.cv_ESCALA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cv_ESCALA.ContainerControlProcessDialogKey = True
        Me.cv_ESCALA.ContextMenuStrip = Me.cms_CV
        Me.cv_ESCALA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cv_ESCALA.ForeColor = System.Drawing.Color.Black
        Me.cv_ESCALA.HighlightCurrentDay = True
        Me.cv_ESCALA.Is24HourFormat = True
        Me.cv_ESCALA.LabelTimeSlots = True
        Me.cv_ESCALA.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cv_ESCALA.Location = New System.Drawing.Point(3, 18)
        Me.cv_ESCALA.MultiUserTabHeight = 21
        Me.cv_ESCALA.Name = "cv_ESCALA"
        Me.cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week
        Me.cv_ESCALA.Size = New System.Drawing.Size(677, 385)
        Me.cv_ESCALA.TabIndex = 29
        Me.cv_ESCALA.TabStop = False
        Me.cv_ESCALA.Text = "CalendarView1"
        Me.cv_ESCALA.TimeIndicator.BorderColor = System.Drawing.Color.Empty
        Me.cv_ESCALA.TimeIndicator.IndicatorArea = DevComponents.DotNetBar.Schedule.eTimeIndicatorArea.All
        Me.cv_ESCALA.TimeIndicator.IndicatorLevel = DevComponents.DotNetBar.Schedule.eTimeIndicatorLevel.Top
        Me.cv_ESCALA.TimeIndicator.Tag = Nothing
        Me.cv_ESCALA.TimeIndicator.Thickness = 5
        Me.cv_ESCALA.TimeIndicator.Visibility = DevComponents.DotNetBar.Schedule.eTimeIndicatorVisibility.AllResources
        Me.cv_ESCALA.TimeRulerFont = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cv_ESCALA.TimeRulerFontSm = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cv_ESCALA.TimeSlotDuration = 30
        Me.cv_ESCALA.YearViewLinkView = DevComponents.DotNetBar.Schedule.eCalendarView.Month
        '
        'cms_CV
        '
        Me.cms_CV.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cms_CV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bt_EXCLUIRPERIODO})
        Me.cms_CV.Name = "cms_CV"
        Me.cms_CV.Size = New System.Drawing.Size(239, 26)
        '
        'bt_EXCLUIRPERIODO
        '
        Me.bt_EXCLUIRPERIODO.Enabled = False
        Me.bt_EXCLUIRPERIODO.Image = CType(resources.GetObject("bt_EXCLUIRPERIODO.Image"), System.Drawing.Image)
        Me.bt_EXCLUIRPERIODO.Name = "bt_EXCLUIRPERIODO"
        Me.bt_EXCLUIRPERIODO.Size = New System.Drawing.Size(238, 22)
        Me.bt_EXCLUIRPERIODO.Text = "Excluir Período de Funcionamento"
        '
        'tmr_TURNO
        '
        Me.tmr_TURNO.Interval = 1000
        '
        'tmr_ESCALA
        '
        Me.tmr_ESCALA.Interval = 1000
        '
        'DateNavigator1
        '
        Me.DateNavigator1.CalendarView = Me.cv_ESCALA
        Me.DateNavigator1.CanvasColor = System.Drawing.SystemColors.Control
        Me.DateNavigator1.DisabledBackColor = System.Drawing.Color.Empty
        Me.DateNavigator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DateNavigator1.Location = New System.Drawing.Point(0, 266)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(683, 30)
        Me.DateNavigator1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.DateNavigator1.TabIndex = 36
        Me.DateNavigator1.Text = "DateNavigator1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cv_ESCALA)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(683, 406)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        '
        'tmr_DEFINIRPERIODO
        '
        Me.tmr_DEFINIRPERIODO.Interval = 1000
        '
        'frm_ESCALA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 702)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DateNavigator1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_ESCALA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escala de Trabalho"
        Me.PanelEx1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dti_DINICIALPESQUISA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINALPESQUISA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_INCLUIRPERIODOS.ResumeLayout(False)
        Me.gb_INCLUIRPERIODOS.PerformLayout()
        CType(Me.dti_HFINAL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DINICIALADD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINALADD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_CV.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents bt_TURNO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_EXCLUIR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents cb_TURNO As ComboBox
    Friend WithEvents bt_ADICIONARPERIODO As Button
    Friend WithEvents dti_DFINALADD As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DINICIALADD As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dti_DINICIALPESQUISA As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dti_DFINALPESQUISA As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents gb_INCLUIRPERIODOS As GroupBox
    Friend WithEvents cb_FIMDESEMANA As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cv_ESCALA As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents cb_TURNOID As ComboBox
    Friend WithEvents tmr_TURNO As Timer
    Friend WithEvents bt_ATUALIZARESCALA As Button
    Friend WithEvents cb_TIPOESCALA As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cms_CV As ContextMenuStrip
    Friend WithEvents bt_EXCLUIRPERIODO As ToolStripMenuItem
    Friend WithEvents tmr_ESCALA As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dti_HFINAL1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label8 As Label
    Friend WithEvents DateNavigator1 As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents bt_DEFINIRPERIODO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tmr_DEFINIRPERIODO As Timer
End Class
