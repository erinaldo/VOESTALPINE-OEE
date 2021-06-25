<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CONTROLEAMARRADO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CONTROLEAMARRADO))
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_GERARREPORT = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_SAIR = New DevComponents.DotNetBar.ButtonItem()
        Me.dti_HFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.dti_DFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmr_REPORTAMARRADO = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.bt_SAIR})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(468, 67)
        Me.ribBar_ETH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ribBar_ETH.TabIndex = 13
        '
        '
        '
        Me.ribBar_ETH.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ribBar_ETH.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer1.BackgroundStyle.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.ItemContainer1.BackgroundStyle.BorderRightWidth = 1
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_GERARREPORT})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_GERARREPORT
        '
        Me.bt_GERARREPORT.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_GERARREPORT.Enabled = False
        Me.bt_GERARREPORT.Image = CType(resources.GetObject("bt_GERARREPORT.Image"), System.Drawing.Image)
        Me.bt_GERARREPORT.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_GERARREPORT.Name = "bt_GERARREPORT"
        Me.bt_GERARREPORT.SubItemsExpandWidth = 14
        Me.bt_GERARREPORT.Text = "Gerar Relatório"
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
        Me.dti_HFINAL.Location = New System.Drawing.Point(178, 143)
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
        Me.dti_HFINAL.TabIndex = 4
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
        Me.dti_HINICIAL.Location = New System.Drawing.Point(178, 115)
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
        Me.dti_HINICIAL.TabIndex = 2
        Me.dti_HINICIAL.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(378, 117)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(55, 24)
        Me.cb_MAQUINAID.TabIndex = 52
        Me.cb_MAQUINAID.Visible = False
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
        Me.dti_DFINAL.Location = New System.Drawing.Point(88, 143)
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
        Me.dti_DFINAL.TabIndex = 3
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
        Me.dti_DINICIAL.Location = New System.Drawing.Point(88, 115)
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
        Me.dti_DINICIAL.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Data Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Data Inicial"
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(88, 85)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(345, 24)
        Me.cb_MAQUINA.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Máquina"
        '
        'tmr_REPORTAMARRADO
        '
        Me.tmr_REPORTAMARRADO.Interval = 1000
        '
        'frm_CONTROLEAMARRADO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 187)
        Me.Controls.Add(Me.dti_HFINAL)
        Me.Controls.Add(Me.dti_HINICIAL)
        Me.Controls.Add(Me.cb_MAQUINAID)
        Me.Controls.Add(Me.dti_DFINAL)
        Me.Controls.Add(Me.dti_DINICIAL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb_MAQUINA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_CONTROLEAMARRADO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Amarrado"
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_GERARREPORT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_SAIR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dti_HFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents dti_DFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tmr_REPORTAMARRADO As Timer
End Class
