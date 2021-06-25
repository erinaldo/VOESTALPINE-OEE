<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CONFIGONLIE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CONFIGONLIE))
        Me.bt_EXCLUIRFERIADO = New DevComponents.DotNetBar.ButtonItem()
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.bt_MARCAR = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_UNMARK = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_SAVE = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPane1 = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.advTree_Dev = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_DESMARCAR = New DevComponents.DotNetBar.ButtonItem()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        CType(Me.advTree_Dev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ribBar_ETH.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_MARCAR, Me.bt_UNMARK, Me.ItemContainer3, Me.ButtonItem2})
        Me.ribBar_ETH.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ribBar_ETH.Location = New System.Drawing.Point(0, 0)
        Me.ribBar_ETH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ribBar_ETH.Name = "ribBar_ETH"
        Me.ribBar_ETH.Size = New System.Drawing.Size(348, 74)
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
        'bt_MARCAR
        '
        Me.bt_MARCAR.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_MARCAR.Enabled = False
        Me.bt_MARCAR.Image = CType(resources.GetObject("bt_MARCAR.Image"), System.Drawing.Image)
        Me.bt_MARCAR.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_MARCAR.Name = "bt_MARCAR"
        Me.bt_MARCAR.SubItemsExpandWidth = 14
        Me.bt_MARCAR.Text = "Marcar Todas"
        '
        'bt_UNMARK
        '
        Me.bt_UNMARK.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.bt_UNMARK.Enabled = False
        Me.bt_UNMARK.Image = CType(resources.GetObject("bt_UNMARK.Image"), System.Drawing.Image)
        Me.bt_UNMARK.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_UNMARK.Name = "bt_UNMARK"
        Me.bt_UNMARK.SubItemsExpandWidth = 14
        Me.bt_UNMARK.Text = "Desmarcar Todas"
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
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.bt_SAVE})
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
        Me.bt_SAVE.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.Text = " Salvar"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = CType(resources.GetObject("ButtonItem2.Image"), System.Drawing.Image)
        Me.ButtonItem2.ImageAlt = CType(resources.GetObject("ButtonItem2.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItemsExpandWidth = 14
        Me.ButtonItem2.Text = "Sair"
        '
        'NavigationPane1
        '
        Me.NavigationPane1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.NavigationPane1.CanCollapse = True
        Me.NavigationPane1.ConfigureAddRemoveVisible = False
        Me.NavigationPane1.ConfigureItemVisible = False
        Me.NavigationPane1.ConfigureNavOptionsVisible = False
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPane1.ForeColor = System.Drawing.Color.White
        Me.NavigationPane1.ItemPaddingBottom = 2
        Me.NavigationPane1.ItemPaddingTop = 2
        Me.NavigationPane1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 74)
        Me.NavigationPane1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.NavigationBarHeight = 59
        Me.NavigationPane1.Padding = New System.Windows.Forms.Padding(1)
        Me.NavigationPane1.Size = New System.Drawing.Size(348, 417)
        Me.NavigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPane1.TabIndex = 21
        '
        '
        '
        Me.NavigationPane1.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPane1.TitlePanel.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPane1.TitlePanel.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Location = New System.Drawing.Point(1, 1)
        Me.NavigationPane1.TitlePanel.Name = "panelTitle"
        Me.NavigationPane1.TitlePanel.Size = New System.Drawing.Size(346, 24)
        Me.NavigationPane1.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPane1.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.NavigationPane1.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.NavigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPane1.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPane1.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPane1.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPane1.TitlePanel.TabIndex = 0
        Me.NavigationPane1.TitlePanel.Text = "Máquinas"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.NavigationPanePanel1.Controls.Add(Me.advTree_Dev)
        Me.NavigationPanePanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(1, 25)
        Me.NavigationPanePanel1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.ButtonItem3
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(346, 332)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 10
        '
        'advTree_Dev
        '
        Me.advTree_Dev.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advTree_Dev.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advTree_Dev.BackgroundStyle.Class = "TreeBorderKey"
        Me.advTree_Dev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advTree_Dev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advTree_Dev.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advTree_Dev.Location = New System.Drawing.Point(0, 0)
        Me.advTree_Dev.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.advTree_Dev.Name = "advTree_Dev"
        Me.advTree_Dev.NodesConnector = Me.NodeConnector1
        Me.advTree_Dev.NodeStyle = Me.ElementStyle1
        Me.advTree_Dev.PathSeparator = ";"
        Me.advTree_Dev.Size = New System.Drawing.Size(346, 332)
        Me.advTree_Dev.Styles.Add(Me.ElementStyle1)
        Me.advTree_Dev.TabIndex = 6
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
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Checked = True
        Me.ButtonItem3.Image = CType(resources.GetObject("ButtonItem3.Image"), System.Drawing.Image)
        Me.ButtonItem3.ImageAlt = CType(resources.GetObject("ButtonItem3.ImageAlt"), System.Drawing.Image)
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.OptionGroup = "navBar"
        Me.ButtonItem3.Text = "Máquinas"
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
        'frm_CONFIGONLIE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 491)
        Me.Controls.Add(Me.NavigationPane1)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_CONFIGONLIE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar ONLINE"
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        CType(Me.advTree_Dev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bt_EXCLUIRFERIADO As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_SAVE As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents NavigationPane1 As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Friend WithEvents advTree_Dev As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_DESMARCAR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_MARCAR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_UNMARK As DevComponents.DotNetBar.ButtonItem
End Class
