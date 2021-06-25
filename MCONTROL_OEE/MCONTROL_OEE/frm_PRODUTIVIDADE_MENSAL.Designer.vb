<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PRODUTIVIDADE_MENSAL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PRODUTIVIDADE_MENSAL))
        Me.ribBar_ETH = New DevComponents.DotNetBar.RibbonBar()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.bt_GERARREPORT = New DevComponents.DotNetBar.ButtonItem()
        Me.bt_SAIR = New DevComponents.DotNetBar.ButtonItem()
        Me.tb_ANO = New System.Windows.Forms.TextBox()
        Me.cb_MES = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tmr_PRODUTIVIDADE_MENSAL = New System.Windows.Forms.Timer(Me.components)
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
        Me.ribBar_ETH.Size = New System.Drawing.Size(320, 67)
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
        'tb_ANO
        '
        Me.tb_ANO.Location = New System.Drawing.Point(192, 96)
        Me.tb_ANO.Name = "tb_ANO"
        Me.tb_ANO.Size = New System.Drawing.Size(56, 22)
        Me.tb_ANO.TabIndex = 1
        '
        'cb_MES
        '
        Me.cb_MES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MES.FormattingEnabled = True
        Me.cb_MES.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cb_MES.Items.AddRange(New Object() {"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"})
        Me.cb_MES.Location = New System.Drawing.Point(67, 94)
        Me.cb_MES.Name = "cb_MES"
        Me.cb_MES.Size = New System.Drawing.Size(112, 24)
        Me.cb_MES.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Ano"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(64, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Mês"
        '
        'tmr_PRODUTIVIDADE_MENSAL
        '
        Me.tmr_PRODUTIVIDADE_MENSAL.Interval = 1000
        '
        'frm_PRODUTIVIDADE_MENSAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 130)
        Me.Controls.Add(Me.tb_ANO)
        Me.Controls.Add(Me.cb_MES)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ribBar_ETH)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_PRODUTIVIDADE_MENSAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produtividade - MENSAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ribBar_ETH As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents bt_GERARREPORT As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bt_SAIR As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tb_ANO As TextBox
    Friend WithEvents cb_MES As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tmr_PRODUTIVIDADE_MENSAL As Timer
End Class
