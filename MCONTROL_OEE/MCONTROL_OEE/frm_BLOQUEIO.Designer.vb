<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BLOQUEIO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_BLOQUEIO))
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_BLOQUEAR = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.dti_DINICIALPESQUISA = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cb_TIPOESCALA = New System.Windows.Forms.ComboBox()
        Me.dti_DFINALPESQUISA = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_ATUALIZARESCALA = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateNavigator1 = New DevComponents.DotNetBar.Schedule.DateNavigator()
        Me.cv_ESCALA = New DevComponents.DotNetBar.Schedule.CalendarView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dti_DINICIALPESQUISA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINALPESQUISA, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer3, Me.ButtonItem1})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(904, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 25
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
        Me.ItemContainer3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderLeftWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.ItemContainer3.BackgroundStyle.BorderRightWidth = 1
        Me.ItemContainer3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_BLOQUEAR})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_MAQUINAID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cb_MAQUINA)
        Me.GroupBox1.Controls.Add(Me.dti_DINICIALPESQUISA)
        Me.GroupBox1.Controls.Add(Me.cb_TIPOESCALA)
        Me.GroupBox1.Controls.Add(Me.dti_DFINALPESQUISA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.bt_ATUALIZARESCALA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 433)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(220, 15)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(55, 24)
        Me.cb_MAQUINAID.TabIndex = 43
        Me.cb_MAQUINAID.TabStop = False
        Me.cb_MAQUINAID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Máquina"
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(17, 45)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(258, 24)
        Me.cb_MAQUINA.TabIndex = 0
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
        Me.dti_DINICIALPESQUISA.Location = New System.Drawing.Point(191, 76)
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
        Me.dti_DINICIALPESQUISA.TabIndex = 1
        '
        'cb_TIPOESCALA
        '
        Me.cb_TIPOESCALA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TIPOESCALA.Enabled = False
        Me.cb_TIPOESCALA.FormattingEnabled = True
        Me.cb_TIPOESCALA.Items.AddRange(New Object() {"Anual", "Diário", "Mensal", "Semanal", "Time Line"})
        Me.cb_TIPOESCALA.Location = New System.Drawing.Point(191, 135)
        Me.cb_TIPOESCALA.Name = "cb_TIPOESCALA"
        Me.cb_TIPOESCALA.Size = New System.Drawing.Size(84, 24)
        Me.cb_TIPOESCALA.TabIndex = 3
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
        Me.dti_DFINALPESQUISA.Location = New System.Drawing.Point(191, 104)
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
        Me.dti_DFINALPESQUISA.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(125, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Formato"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(125, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Data Final"
        '
        'bt_ATUALIZARESCALA
        '
        Me.bt_ATUALIZARESCALA.Image = CType(resources.GetObject("bt_ATUALIZARESCALA.Image"), System.Drawing.Image)
        Me.bt_ATUALIZARESCALA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ATUALIZARESCALA.Location = New System.Drawing.Point(191, 165)
        Me.bt_ATUALIZARESCALA.Name = "bt_ATUALIZARESCALA"
        Me.bt_ATUALIZARESCALA.Size = New System.Drawing.Size(84, 29)
        Me.bt_ATUALIZARESCALA.TabIndex = 4
        Me.bt_ATUALIZARESCALA.Text = "     Visualisar"
        Me.bt_ATUALIZARESCALA.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(122, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Data Inicial"
        '
        'DateNavigator1
        '
        Me.DateNavigator1.CalendarView = Me.cv_ESCALA
        Me.DateNavigator1.CanvasColor = System.Drawing.SystemColors.Control
        Me.DateNavigator1.DisabledBackColor = System.Drawing.Color.Empty
        Me.DateNavigator1.Location = New System.Drawing.Point(303, 81)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.Size = New System.Drawing.Size(591, 30)
        Me.DateNavigator1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.DateNavigator1.TabIndex = 46
        Me.DateNavigator1.Text = "DateNavigator1"
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
        Me.cv_ESCALA.Size = New System.Drawing.Size(585, 367)
        Me.cv_ESCALA.TabIndex = 29
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cv_ESCALA)
        Me.GroupBox2.Location = New System.Drawing.Point(303, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 388)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        '
        'frm_BLOQUEIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 515)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DateNavigator1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_BLOQUEIO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bloqueio de Registros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dti_DINICIALPESQUISA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINALPESQUISA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dti_DINICIALPESQUISA As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cb_TIPOESCALA As ComboBox
    Friend WithEvents dti_DFINALPESQUISA As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents bt_ATUALIZARESCALA As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents DateNavigator1 As DevComponents.DotNetBar.Schedule.DateNavigator
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cv_ESCALA As DevComponents.DotNetBar.Schedule.CalendarView
    Friend WithEvents bt_BLOQUEAR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cb_MAQUINA As ComboBox
End Class
