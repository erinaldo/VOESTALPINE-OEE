<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PERFILUSUÁRIOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PERFILUSUÁRIOS))
        Me.gb_MENU = New System.Windows.Forms.GroupBox()
        Me.advt_MENUS = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bt_REMOVEADD = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_USERID = New System.Windows.Forms.ComboBox()
        Me.cb_USER = New System.Windows.Forms.ComboBox()
        Me.gb_MENU.SuspendLayout()
        CType(Me.advt_MENUS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_MENU
        '
        Me.gb_MENU.Controls.Add(Me.advt_MENUS)
        Me.gb_MENU.Enabled = False
        Me.gb_MENU.Location = New System.Drawing.Point(12, 84)
        Me.gb_MENU.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.gb_MENU.Name = "gb_MENU"
        Me.gb_MENU.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.gb_MENU.Size = New System.Drawing.Size(328, 315)
        Me.gb_MENU.TabIndex = 34
        Me.gb_MENU.TabStop = False
        Me.gb_MENU.Text = "Itens de Menu para Bloquear"
        '
        'advt_MENUS
        '
        Me.advt_MENUS.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advt_MENUS.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advt_MENUS.BackgroundStyle.Class = "TreeBorderKey"
        Me.advt_MENUS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advt_MENUS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.advt_MENUS.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advt_MENUS.Location = New System.Drawing.Point(3, 20)
        Me.advt_MENUS.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.advt_MENUS.Name = "advt_MENUS"
        Me.advt_MENUS.NodesConnector = Me.NodeConnector1
        Me.advt_MENUS.NodeStyle = Me.ElementStyle1
        Me.advt_MENUS.PathSeparator = ";"
        Me.advt_MENUS.Size = New System.Drawing.Size(322, 290)
        Me.advt_MENUS.Styles.Add(Me.ElementStyle1)
        Me.advt_MENUS.TabIndex = 14
        Me.advt_MENUS.Text = "AdvTree1"
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
        'Button1
        '
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(258, 408)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 28)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "    Salvar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'bt_REMOVEADD
        '
        Me.bt_REMOVEADD.Image = CType(resources.GetObject("bt_REMOVEADD.Image"), System.Drawing.Image)
        Me.bt_REMOVEADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_REMOVEADD.Location = New System.Drawing.Point(170, 408)
        Me.bt_REMOVEADD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bt_REMOVEADD.Name = "bt_REMOVEADD"
        Me.bt_REMOVEADD.Size = New System.Drawing.Size(82, 28)
        Me.bt_REMOVEADD.TabIndex = 35
        Me.bt_REMOVEADD.Text = "    Cancelar"
        Me.bt_REMOVEADD.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cb_USERID)
        Me.GroupBox1.Controls.Add(Me.cb_USER)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 64)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuário"
        '
        'cb_USERID
        '
        Me.cb_USERID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_USERID.FormattingEnabled = True
        Me.cb_USERID.Location = New System.Drawing.Point(234, 34)
        Me.cb_USERID.Name = "cb_USERID"
        Me.cb_USERID.Size = New System.Drawing.Size(65, 24)
        Me.cb_USERID.TabIndex = 1
        Me.cb_USERID.Visible = False
        '
        'cb_USER
        '
        Me.cb_USER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_USER.FormattingEnabled = True
        Me.cb_USER.Location = New System.Drawing.Point(6, 22)
        Me.cb_USER.Name = "cb_USER"
        Me.cb_USER.Size = New System.Drawing.Size(316, 24)
        Me.cb_USER.TabIndex = 0
        '
        'frm_PERFILUSUÁRIOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 444)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bt_REMOVEADD)
        Me.Controls.Add(Me.gb_MENU)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_PERFILUSUÁRIOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perfil de Usuários"
        Me.gb_MENU.ResumeLayout(False)
        CType(Me.advt_MENUS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gb_MENU As GroupBox
    Friend WithEvents advt_MENUS As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Button1 As Button
    Friend WithEvents bt_REMOVEADD As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cb_USER As ComboBox
    Friend WithEvents cb_USERID As ComboBox
End Class
