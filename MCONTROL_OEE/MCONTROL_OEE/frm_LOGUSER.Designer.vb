<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_LOGUSER
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LOGUSER))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.dti_DINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HINICIAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_DFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dti_HFINAL = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ItemContainer6 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem5 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ControlContainerItem6 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem7 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ControlContainerItem8 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SELECTALL = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_UNSELECTALL = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_USERSSELECTED = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_CRESC = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_DECRESC = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_REFRESH = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPane1 = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.advTree_Var = New DevComponents.AdvTree.AdvTree()
        Me.advTree_Users = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.bt_USERS = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPanePanel2 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.advTree_DEVICES = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector3 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.dgv_DATA = New System.Windows.Forms.DataGridView()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.RibbonBar1.SuspendLayout()
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        CType(Me.advTree_Var, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.advTree_Var.SuspendLayout()
        CType(Me.advTree_Users, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationPanePanel2.SuspendLayout()
        CType(Me.advTree_DEVICES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Controls.Add(Me.dti_DINICIAL)
        Me.RibbonBar1.Controls.Add(Me.dti_HINICIAL)
        Me.RibbonBar1.Controls.Add(Me.dti_DFINAL)
        Me.RibbonBar1.Controls.Add(Me.dti_HFINAL)
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer6, Me.ItemContainer7, Me.ItemContainer5, Me.bt_CRESC, Me.bt_DECRESC, Me.bt_REFRESH})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(860, 81)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 5
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        Me.dti_DINICIAL.Location = New System.Drawing.Point(6, 20)
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
        Me.dti_DINICIAL.TabIndex = 0
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
        Me.dti_HINICIAL.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dti_HINICIAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HINICIAL.IsPopupCalendarOpen = False
        Me.dti_HINICIAL.Location = New System.Drawing.Point(6, 45)
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
        Me.dti_HINICIAL.TabIndex = 1
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
        Me.dti_DFINAL.Location = New System.Drawing.Point(95, 20)
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
        Me.dti_HFINAL.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dti_HFINAL.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dti_HFINAL.IsPopupCalendarOpen = False
        Me.dti_HFINAL.Location = New System.Drawing.Point(95, 45)
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
        'ItemContainer6
        '
        '
        '
        '
        Me.ItemContainer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer6.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer6.Name = "ItemContainer6"
        Me.ItemContainer6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.ControlContainerItem5, Me.ControlContainerItem6})
        '
        '
        '
        Me.ItemContainer6.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "      Data Inicial"
        '
        'ControlContainerItem5
        '
        Me.ControlContainerItem5.AllowItemResize = False
        Me.ControlContainerItem5.Control = Me.dti_DINICIAL
        Me.ControlContainerItem5.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem5.Name = "ControlContainerItem5"
        '
        'ControlContainerItem6
        '
        Me.ControlContainerItem6.AllowItemResize = False
        Me.ControlContainerItem6.Control = Me.dti_HINICIAL
        Me.ControlContainerItem6.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem6.Name = "ControlContainerItem6"
        '
        'ItemContainer7
        '
        '
        '
        '
        Me.ItemContainer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer7.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer7.Name = "ItemContainer7"
        Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.ControlContainerItem7, Me.ControlContainerItem8})
        '
        '
        '
        Me.ItemContainer7.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.Text = "      Data Final"
        '
        'ControlContainerItem7
        '
        Me.ControlContainerItem7.AllowItemResize = False
        Me.ControlContainerItem7.Control = Me.dti_DFINAL
        Me.ControlContainerItem7.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem7.Name = "ControlContainerItem7"
        '
        'ControlContainerItem8
        '
        Me.ControlContainerItem8.AllowItemResize = False
        Me.ControlContainerItem8.Control = Me.dti_HFINAL
        Me.ControlContainerItem8.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem8.Name = "ControlContainerItem8"
        '
        'ItemContainer5
        '
        '
        '
        '
        Me.ItemContainer5.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ItemContainer5.BackgroundStyle.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.ItemContainer5.BackgroundStyle.BorderRightWidth = 1
        Me.ItemContainer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer5.Name = "ItemContainer5"
        Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SELECTALL, Me.bt_UNSELECTALL, Me.bt_USERSSELECTED})
        '
        '
        '
        Me.ItemContainer5.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'bt_SELECTALL
        '
        Me.bt_SELECTALL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_SELECTALL.Image = CType(resources.GetObject("bt_SELECTALL.Image"), System.Drawing.Image)
        Me.bt_SELECTALL.ImageAlt = CType(resources.GetObject("bt_SELECTALL.ImageAlt"), System.Drawing.Image)
        Me.bt_SELECTALL.Name = "bt_SELECTALL"
        Me.bt_SELECTALL.Text = "Marcar todas os Usuários"
        '
        'bt_UNSELECTALL
        '
        Me.bt_UNSELECTALL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_UNSELECTALL.Image = CType(resources.GetObject("bt_UNSELECTALL.Image"), System.Drawing.Image)
        Me.bt_UNSELECTALL.ImageAlt = CType(resources.GetObject("bt_UNSELECTALL.ImageAlt"), System.Drawing.Image)
        Me.bt_UNSELECTALL.Name = "bt_UNSELECTALL"
        Me.bt_UNSELECTALL.Text = "Desmarcar todos"
        '
        'bt_USERSSELECTED
        '
        Me.bt_USERSSELECTED.AutoCheckOnClick = True
        Me.bt_USERSSELECTED.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_USERSSELECTED.Image = CType(resources.GetObject("bt_USERSSELECTED.Image"), System.Drawing.Image)
        Me.bt_USERSSELECTED.ImageAlt = CType(resources.GetObject("bt_USERSSELECTED.ImageAlt"), System.Drawing.Image)
        Me.bt_USERSSELECTED.Name = "bt_USERSSELECTED"
        Me.bt_USERSSELECTED.Text = "Usuários Específicos"
        Me.bt_USERSSELECTED.Visible = False
        '
        'bt_CRESC
        '
        Me.bt_CRESC.AutoCheckOnClick = True
        Me.bt_CRESC.Checked = True
        Me.bt_CRESC.Image = CType(resources.GetObject("bt_CRESC.Image"), System.Drawing.Image)
        Me.bt_CRESC.ImageAlt = CType(resources.GetObject("bt_CRESC.ImageAlt"), System.Drawing.Image)
        Me.bt_CRESC.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_CRESC.Name = "bt_CRESC"
        Me.bt_CRESC.SubItemsExpandWidth = 14
        Me.bt_CRESC.Text = "Antigos Primeiro"
        '
        'bt_DECRESC
        '
        Me.bt_DECRESC.AutoCheckOnClick = True
        Me.bt_DECRESC.Image = CType(resources.GetObject("bt_DECRESC.Image"), System.Drawing.Image)
        Me.bt_DECRESC.ImageAlt = CType(resources.GetObject("bt_DECRESC.ImageAlt"), System.Drawing.Image)
        Me.bt_DECRESC.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_DECRESC.Name = "bt_DECRESC"
        Me.bt_DECRESC.SubItemsExpandWidth = 14
        Me.bt_DECRESC.Text = "Novos Primeiro"
        '
        'bt_REFRESH
        '
        Me.bt_REFRESH.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_REFRESH.Image = CType(resources.GetObject("bt_REFRESH.Image"), System.Drawing.Image)
        Me.bt_REFRESH.ImageAlt = CType(resources.GetObject("bt_REFRESH.ImageAlt"), System.Drawing.Image)
        Me.bt_REFRESH.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_REFRESH.Name = "bt_REFRESH"
        Me.bt_REFRESH.SubItemsExpandWidth = 14
        Me.bt_REFRESH.Text = "Atualizar"
        '
        'NavigationPane1
        '
        Me.NavigationPane1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.NavigationPane1.CanCollapse = True
        Me.NavigationPane1.ConfigureAddRemoveVisible = False
        Me.NavigationPane1.ConfigureItemVisible = False
        Me.NavigationPane1.ConfigureNavOptionsVisible = False
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel2)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPane1.ForeColor = System.Drawing.Color.White
        Me.NavigationPane1.ItemPaddingBottom = 2
        Me.NavigationPane1.ItemPaddingTop = 2
        Me.NavigationPane1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_USERS})
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 81)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.NavigationBarHeight = 59
        Me.NavigationPane1.Padding = New System.Windows.Forms.Padding(1)
        Me.NavigationPane1.Size = New System.Drawing.Size(177, 289)
        Me.NavigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPane1.TabIndex = 12
        '
        '
        '
        Me.NavigationPane1.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPane1.TitlePanel.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPane1.TitlePanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Location = New System.Drawing.Point(1, 1)
        Me.NavigationPane1.TitlePanel.Name = "panelTitle"
        Me.NavigationPane1.TitlePanel.Size = New System.Drawing.Size(175, 24)
        Me.NavigationPane1.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPane1.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.NavigationPane1.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.NavigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPane1.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPane1.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPane1.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPane1.TitlePanel.TabIndex = 0
        Me.NavigationPane1.TitlePanel.Text = "Usuários"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel1.Controls.Add(Me.advTree_Var)
        Me.NavigationPanePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(1, 25)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.bt_USERS
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(175, 204)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 10
        '
        'advTree_Var
        '
        Me.advTree_Var.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advTree_Var.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree_Var.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree_Var.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree_Var.Controls.Add(Me.advTree_Users)
        Me.advTree_Var.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advTree_Var.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree_Var.Location = New System.Drawing.Point(0, 0)
        Me.advTree_Var.Name = "advTree_Var"
        Me.advTree_Var.NodesConnector = Me.NodeConnector1
        Me.advTree_Var.NodeStyle = Me.ElementStyle1
        Me.advTree_Var.PathSeparator = ";"
        Me.advTree_Var.Size = New System.Drawing.Size(175, 204)
        Me.advTree_Var.Styles.Add(Me.ElementStyle1)
        Me.advTree_Var.TabIndex = 6
        '
        'advTree_Users
        '
        Me.advTree_Users.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advTree_Users.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree_Users.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree_Users.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree_Users.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advTree_Users.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree_Users.Location = New System.Drawing.Point(0, 0)
        Me.advTree_Users.Name = "advTree_Users"
        Me.advTree_Users.NodesConnector = Me.NodeConnector2
        Me.advTree_Users.NodeStyle = Me.ElementStyle2
        Me.advTree_Users.PathSeparator = ";"
        Me.advTree_Users.Size = New System.Drawing.Size(175, 204)
        Me.advTree_Users.Styles.Add(Me.ElementStyle2)
        Me.advTree_Users.TabIndex = 7
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle2
        '
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ControlText
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'bt_USERS
        '
        Me.bt_USERS.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_USERS.Checked = True
        Me.bt_USERS.Image = CType(resources.GetObject("bt_USERS.Image"), System.Drawing.Image)
        Me.bt_USERS.ImageAlt = CType(resources.GetObject("bt_USERS.ImageAlt"), System.Drawing.Image)
        Me.bt_USERS.Name = "bt_USERS"
        Me.bt_USERS.OptionGroup = "navBar"
        Me.bt_USERS.Text = "Usuários"
        '
        'NavigationPanePanel2
        '
        Me.NavigationPanePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel2.Controls.Add(Me.advTree_DEVICES)
        Me.NavigationPanePanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel2.Location = New System.Drawing.Point(1, 1)
        Me.NavigationPanePanel2.Name = "NavigationPanePanel2"
        Me.NavigationPanePanel2.ParentItem = Nothing
        Me.NavigationPanePanel2.Size = New System.Drawing.Size(175, 228)
        Me.NavigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel2.Style.GradientAngle = 90
        Me.NavigationPanePanel2.TabIndex = 14
        '
        'advTree_DEVICES
        '
        Me.advTree_DEVICES.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advTree_DEVICES.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree_DEVICES.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree_DEVICES.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree_DEVICES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advTree_DEVICES.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree_DEVICES.Location = New System.Drawing.Point(0, 0)
        Me.advTree_DEVICES.Name = "advTree_DEVICES"
        Me.advTree_DEVICES.NodesConnector = Me.NodeConnector3
        Me.advTree_DEVICES.NodeStyle = Me.ElementStyle3
        Me.advTree_DEVICES.PathSeparator = ";"
        Me.advTree_DEVICES.Size = New System.Drawing.Size(175, 228)
        Me.advTree_DEVICES.Styles.Add(Me.ElementStyle3)
        Me.advTree_DEVICES.TabIndex = 8
        '
        'NodeConnector3
        '
        Me.NodeConnector3.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle3
        '
        Me.ElementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.TextColor = System.Drawing.SystemColors.ControlText
        '
        'dgv_DATA
        '
        Me.dgv_DATA.AllowUserToAddRows = False
        Me.dgv_DATA.AllowUserToDeleteRows = False
        Me.dgv_DATA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_DATA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_DATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_DATA.Location = New System.Drawing.Point(177, 81)
        Me.dgv_DATA.Name = "dgv_DATA"
        Me.dgv_DATA.ReadOnly = True
        Me.dgv_DATA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_DATA.ShowEditingIcon = False
        Me.dgv_DATA.Size = New System.Drawing.Size(683, 289)
        Me.dgv_DATA.TabIndex = 15
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
        Me.ExpandableSplitter1.ForeColor = System.Drawing.Color.White
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
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(177, 81)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(5, 289)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 16
        Me.ExpandableSplitter1.TabStop = False
        '
        'frm_LOGUSER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 370)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.dgv_DATA)
        Me.Controls.Add(Me.NavigationPane1)
        Me.Controls.Add(Me.RibbonBar1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_LOGUSER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Atividades de Usuários"
        Me.RibbonBar1.ResumeLayout(False)
        CType(Me.dti_DINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HINICIAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_DFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dti_HFINAL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        CType(Me.advTree_Var, System.ComponentModel.ISupportInitialize).EndInit()
        Me.advTree_Var.ResumeLayout(False)
        CType(Me.advTree_Users, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationPanePanel2.ResumeLayout(False)
        CType(Me.advTree_DEVICES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_DATA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents dti_DINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_DFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dti_HFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ItemContainer6 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem5 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem6 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem7 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem8 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_SELECTALL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_UNSELECTALL As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_USERSSELECTED As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_CRESC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_DECRESC As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_REFRESH As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPane1 As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents advTree_Var As DevComponents.AdvTree.AdvTree
    Friend WithEvents advTree_Users As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents bt_USERS As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgv_DATA As System.Windows.Forms.DataGridView
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents NavigationPanePanel2 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents advTree_DEVICES As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector3 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
End Class
