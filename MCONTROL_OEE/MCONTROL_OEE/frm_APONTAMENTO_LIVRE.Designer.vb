﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_APONTAMENTO_LIVRE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_APONTAMENTO_LIVRE))
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_GERARREPORT = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_MARCAR = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_DESMARCAR = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_SAIR = New DevComponents.DotNetBar.ButtonItem()
        Me.dti_HFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tmr_REPORTAPONTAMENTO = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lb_MAQUINAS = New DevComponents.DotNetBar.ListBoxAdv()
        Me.lb_MAQUINASID = New DevComponents.DotNetBar.ListBoxAdv()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1, Me.bt_MARCAR, Me.bt_DESMARCAR, Me.bt_SAIR})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(406, 67)
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
        'bt_MARCAR
        '
        Me.bt_MARCAR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_MARCAR.Image = CType(resources.GetObject("bt_MARCAR.Image"), System.Drawing.Image)
        Me.bt_MARCAR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_MARCAR.Name = "bt_MARCAR"
        Me.bt_MARCAR.SubItemsExpandWidth = 14
        Me.bt_MARCAR.Text = "Marcar Todas"
        '
        'bt_DESMARCAR
        '
        Me.bt_DESMARCAR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_DESMARCAR.Image = CType(resources.GetObject("bt_DESMARCAR.Image"), System.Drawing.Image)
        Me.bt_DESMARCAR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_DESMARCAR.Name = "bt_DESMARCAR"
        Me.bt_DESMARCAR.SubItemsExpandWidth = 14
        Me.bt_DESMARCAR.Text = "Desmarcar Todas"
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
        Me.dti_HFINAL.Location = New System.Drawing.Point(168, 230)
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
        Me.dti_HFINAL.TabIndex = 3
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
        Me.dti_HINICIAL.Location = New System.Drawing.Point(168, 202)
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
        Me.dti_DFINAL.Location = New System.Drawing.Point(78, 230)
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
        Me.dti_DFINAL.TabIndex = 2
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
        Me.dti_DINICIAL.Location = New System.Drawing.Point(78, 202)
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
        Me.Label2.Location = New System.Drawing.Point(13, 233)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Data Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Data Inicial"
        '
        'tmr_REPORTAPONTAMENTO
        '
        Me.tmr_REPORTAPONTAMENTO.Interval = 1000
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lb_MAQUINAS)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 122)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Máquinas Cadastradas"
        '
        'lb_MAQUINAS
        '
        Me.lb_MAQUINAS.AutoScroll = True
        '
        '
        '
        Me.lb_MAQUINAS.BackgroundStyle.Class = "ListBoxAdv"
        Me.lb_MAQUINAS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb_MAQUINAS.CheckBoxesVisible = True
        Me.lb_MAQUINAS.CheckStateMember = Nothing
        Me.lb_MAQUINAS.ContainerControlProcessDialogKey = True
        Me.lb_MAQUINAS.DragDropSupport = True
        Me.lb_MAQUINAS.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lb_MAQUINAS.Location = New System.Drawing.Point(6, 21)
        Me.lb_MAQUINAS.Name = "lb_MAQUINAS"
        Me.lb_MAQUINAS.SelectionMode = DevComponents.DotNetBar.eSelectionMode.None
        Me.lb_MAQUINAS.Size = New System.Drawing.Size(369, 95)
        Me.lb_MAQUINAS.TabIndex = 0
        Me.lb_MAQUINAS.Text = "ListBoxAdv1"
        '
        'lb_MAQUINASID
        '
        Me.lb_MAQUINASID.AutoScroll = True
        '
        '
        '
        Me.lb_MAQUINASID.BackgroundStyle.Class = "ListBoxAdv"
        Me.lb_MAQUINASID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb_MAQUINASID.CheckBoxesVisible = True
        Me.lb_MAQUINASID.CheckStateMember = Nothing
        Me.lb_MAQUINASID.ContainerControlProcessDialogKey = True
        Me.lb_MAQUINASID.DragDropSupport = True
        Me.lb_MAQUINASID.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lb_MAQUINASID.Location = New System.Drawing.Point(350, 204)
        Me.lb_MAQUINASID.Name = "lb_MAQUINASID"
        Me.lb_MAQUINASID.Size = New System.Drawing.Size(44, 42)
        Me.lb_MAQUINASID.TabIndex = 56
        Me.lb_MAQUINASID.Text = "ListBoxAdv1"
        Me.lb_MAQUINASID.Visible = False
        '
        'frm_APONTAMENTO_LIVRE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 261)
        Me.Controls.Add(Me.lb_MAQUINASID)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dti_HFINAL)
        Me.Controls.Add(Me.dti_HINICIAL)
        Me.Controls.Add(Me.dti_DFINAL)
        Me.Controls.Add(Me.dti_DINICIAL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_APONTAMENTO_LIVRE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apontamento de Produção"
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_GERARREPORT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_SAIR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dti_HFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tmr_REPORTAPONTAMENTO As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lb_MAQUINAS As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents lb_MAQUINASID As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents bt_MARCAR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_DESMARCAR As DevComponents.DotNetBar.ButtonItem
End Class
