<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_EDITARPARADA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_EDITARPARADA))
        Me.dti_DINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bt_LIMPARNIVEL3 = New System.Windows.Forms.Button()
        Me.bt_LIMPARMOTIVO2 = New System.Windows.Forms.Button()
        Me.cb_NIVEL3ID = New System.Windows.Forms.ComboBox()
        Me.cb_NIVEL2ID = New System.Windows.Forms.ComboBox()
        Me.cb_NIVEL1ID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_NIVEL3 = New System.Windows.Forms.ComboBox()
        Me.cb_NIVEL2 = New System.Windows.Forms.ComboBox()
        Me.cb_NIVEL1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_OPERADOR = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_COMENTARIOS = New System.Windows.Forms.TextBox()
        Me.bt_SAVE = New System.Windows.Forms.Button()
        Me.bt_CANCEL = New System.Windows.Forms.Button()
        Me.cb_OPERADORID = New System.Windows.Forms.ComboBox()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dti_DINICIAL.Location = New System.Drawing.Point(60, 69)
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
        Me.dti_DINICIAL.TabIndex = 4
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
        Me.dti_HINICIAL.Location = New System.Drawing.Point(150, 69)
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
        Me.dti_HINICIAL.TabIndex = 5
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
        Me.dti_DFINAL.Location = New System.Drawing.Point(60, 97)
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
        Me.dti_DFINAL.TabIndex = 6
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
        Me.dti_HFINAL.Location = New System.Drawing.Point(150, 97)
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
        Me.dti_HFINAL.TabIndex = 7
        Me.dti_HFINAL.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Início"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fim"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_LIMPARNIVEL3)
        Me.GroupBox1.Controls.Add(Me.bt_LIMPARMOTIVO2)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL3ID)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL2ID)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL1ID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL3)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL2)
        Me.GroupBox1.Controls.Add(Me.cb_NIVEL1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 140)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Motivo de Parada"
        '
        'bt_LIMPARNIVEL3
        '
        Me.bt_LIMPARNIVEL3.Image = CType(resources.GetObject("bt_LIMPARNIVEL3.Image"), System.Drawing.Image)
        Me.bt_LIMPARNIVEL3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_LIMPARNIVEL3.Location = New System.Drawing.Point(518, 89)
        Me.bt_LIMPARNIVEL3.Name = "bt_LIMPARNIVEL3"
        Me.bt_LIMPARNIVEL3.Size = New System.Drawing.Size(86, 25)
        Me.bt_LIMPARNIVEL3.TabIndex = 20
        Me.bt_LIMPARNIVEL3.Text = "Limpar"
        Me.bt_LIMPARNIVEL3.UseVisualStyleBackColor = True
        '
        'bt_LIMPARMOTIVO2
        '
        Me.bt_LIMPARMOTIVO2.Image = CType(resources.GetObject("bt_LIMPARMOTIVO2.Image"), System.Drawing.Image)
        Me.bt_LIMPARMOTIVO2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_LIMPARMOTIVO2.Location = New System.Drawing.Point(518, 60)
        Me.bt_LIMPARMOTIVO2.Name = "bt_LIMPARMOTIVO2"
        Me.bt_LIMPARMOTIVO2.Size = New System.Drawing.Size(86, 25)
        Me.bt_LIMPARMOTIVO2.TabIndex = 19
        Me.bt_LIMPARMOTIVO2.Text = "Limpar"
        Me.bt_LIMPARMOTIVO2.UseVisualStyleBackColor = True
        '
        'cb_NIVEL3ID
        '
        Me.cb_NIVEL3ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL3ID.FormattingEnabled = True
        Me.cb_NIVEL3ID.Location = New System.Drawing.Point(492, 90)
        Me.cb_NIVEL3ID.Name = "cb_NIVEL3ID"
        Me.cb_NIVEL3ID.Size = New System.Drawing.Size(20, 24)
        Me.cb_NIVEL3ID.TabIndex = 17
        Me.cb_NIVEL3ID.Visible = False
        '
        'cb_NIVEL2ID
        '
        Me.cb_NIVEL2ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL2ID.FormattingEnabled = True
        Me.cb_NIVEL2ID.Location = New System.Drawing.Point(492, 60)
        Me.cb_NIVEL2ID.Name = "cb_NIVEL2ID"
        Me.cb_NIVEL2ID.Size = New System.Drawing.Size(20, 24)
        Me.cb_NIVEL2ID.TabIndex = 16
        Me.cb_NIVEL2ID.Visible = False
        '
        'cb_NIVEL1ID
        '
        Me.cb_NIVEL1ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL1ID.FormattingEnabled = True
        Me.cb_NIVEL1ID.Location = New System.Drawing.Point(492, 28)
        Me.cb_NIVEL1ID.Name = "cb_NIVEL1ID"
        Me.cb_NIVEL1ID.Size = New System.Drawing.Size(20, 24)
        Me.cb_NIVEL1ID.TabIndex = 15
        Me.cb_NIVEL1ID.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Nível 3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Nível 2"
        '
        'cb_NIVEL3
        '
        Me.cb_NIVEL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL3.FormattingEnabled = True
        Me.cb_NIVEL3.Location = New System.Drawing.Point(76, 90)
        Me.cb_NIVEL3.Name = "cb_NIVEL3"
        Me.cb_NIVEL3.Size = New System.Drawing.Size(412, 24)
        Me.cb_NIVEL3.TabIndex = 12
        '
        'cb_NIVEL2
        '
        Me.cb_NIVEL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL2.FormattingEnabled = True
        Me.cb_NIVEL2.Location = New System.Drawing.Point(76, 60)
        Me.cb_NIVEL2.Name = "cb_NIVEL2"
        Me.cb_NIVEL2.Size = New System.Drawing.Size(412, 24)
        Me.cb_NIVEL2.TabIndex = 11
        '
        'cb_NIVEL1
        '
        Me.cb_NIVEL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_NIVEL1.FormattingEnabled = True
        Me.cb_NIVEL1.Location = New System.Drawing.Point(76, 28)
        Me.cb_NIVEL1.Name = "cb_NIVEL1"
        Me.cb_NIVEL1.Size = New System.Drawing.Size(412, 24)
        Me.cb_NIVEL1.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nível 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Operador"
        '
        'cb_OPERADOR
        '
        Me.cb_OPERADOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_OPERADOR.FormattingEnabled = True
        Me.cb_OPERADOR.Location = New System.Drawing.Point(101, 299)
        Me.cb_OPERADOR.Name = "cb_OPERADOR"
        Me.cb_OPERADOR.Size = New System.Drawing.Size(412, 24)
        Me.cb_OPERADOR.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tb_COMENTARIOS)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 351)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(615, 156)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Comentários"
        '
        'tb_COMENTARIOS
        '
        Me.tb_COMENTARIOS.Location = New System.Drawing.Point(19, 30)
        Me.tb_COMENTARIOS.MaxLength = 1024
        Me.tb_COMENTARIOS.Multiline = True
        Me.tb_COMENTARIOS.Name = "tb_COMENTARIOS"
        Me.tb_COMENTARIOS.Size = New System.Drawing.Size(578, 111)
        Me.tb_COMENTARIOS.TabIndex = 0
        '
        'bt_SAVE
        '
        Me.bt_SAVE.Image = CType(resources.GetObject("bt_SAVE.Image"), System.Drawing.Image)
        Me.bt_SAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_SAVE.Location = New System.Drawing.Point(554, 526)
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.Size = New System.Drawing.Size(86, 25)
        Me.bt_SAVE.TabIndex = 17
        Me.bt_SAVE.Text = "Salvar"
        Me.bt_SAVE.UseVisualStyleBackColor = True
        '
        'bt_CANCEL
        '
        Me.bt_CANCEL.Image = CType(resources.GetObject("bt_CANCEL.Image"), System.Drawing.Image)
        Me.bt_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_CANCEL.Location = New System.Drawing.Point(450, 526)
        Me.bt_CANCEL.Name = "bt_CANCEL"
        Me.bt_CANCEL.Size = New System.Drawing.Size(86, 25)
        Me.bt_CANCEL.TabIndex = 18
        Me.bt_CANCEL.Text = "Cancelar"
        Me.bt_CANCEL.UseVisualStyleBackColor = True
        '
        'cb_OPERADORID
        '
        Me.cb_OPERADORID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_OPERADORID.FormattingEnabled = True
        Me.cb_OPERADORID.Location = New System.Drawing.Point(517, 299)
        Me.cb_OPERADORID.Name = "cb_OPERADORID"
        Me.cb_OPERADORID.Size = New System.Drawing.Size(33, 24)
        Me.cb_OPERADORID.TabIndex = 19
        Me.cb_OPERADORID.Visible = False
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(350, 58)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(55, 24)
        Me.cb_MAQUINAID.TabIndex = 55
        Me.cb_MAQUINAID.Visible = False
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(60, 26)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(345, 24)
        Me.cb_MAQUINA.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "Máquina"
        '
        'frm_EDITARPARADA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 574)
        Me.Controls.Add(Me.cb_MAQUINAID)
        Me.Controls.Add(Me.cb_MAQUINA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cb_OPERADORID)
        Me.Controls.Add(Me.bt_CANCEL)
        Me.Controls.Add(Me.bt_SAVE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cb_OPERADOR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dti_DINICIAL)
        Me.Controls.Add(Me.dti_HINICIAL)
        Me.Controls.Add(Me.dti_DFINAL)
        Me.Controls.Add(Me.dti_HFINAL)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_EDITARPARADA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Parada de Máquina"
        Me.TopMost = True
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dti_DINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cb_NIVEL3 As ComboBox
    Friend WithEvents cb_NIVEL2 As ComboBox
    Friend WithEvents cb_NIVEL1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cb_OPERADOR As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tb_COMENTARIOS As TextBox
    Friend WithEvents bt_SAVE As Button
    Friend WithEvents bt_CANCEL As Button
    Friend WithEvents cb_NIVEL3ID As ComboBox
    Friend WithEvents cb_NIVEL2ID As ComboBox
    Friend WithEvents cb_NIVEL1ID As ComboBox
    Friend WithEvents cb_OPERADORID As ComboBox
    Friend WithEvents bt_LIMPARNIVEL3 As Button
    Friend WithEvents bt_LIMPARMOTIVO2 As Button
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents Label7 As Label
End Class
