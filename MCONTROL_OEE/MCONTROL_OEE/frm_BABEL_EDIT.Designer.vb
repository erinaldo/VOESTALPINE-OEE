<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BABEL_EDIT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_BABEL_EDIT))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_DESCRICAO = New System.Windows.Forms.TextBox()
        Me.tb_SAPID = New System.Windows.Forms.TextBox()
        Me.bt_SALVAR = New System.Windows.Forms.Button()
        Me.bt_CANCELAR = New System.Windows.Forms.Button()
        Me.cb_ENABLED = New System.Windows.Forms.CheckBox()
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.cb_MAQUINA_ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_ON = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_OFF = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descrição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID SAP"
        '
        'tb_DESCRICAO
        '
        Me.tb_DESCRICAO.Location = New System.Drawing.Point(80, 69)
        Me.tb_DESCRICAO.MaxLength = 32
        Me.tb_DESCRICAO.Name = "tb_DESCRICAO"
        Me.tb_DESCRICAO.Size = New System.Drawing.Size(192, 22)
        Me.tb_DESCRICAO.TabIndex = 2
        '
        'tb_SAPID
        '
        Me.tb_SAPID.Location = New System.Drawing.Point(79, 101)
        Me.tb_SAPID.Name = "tb_SAPID"
        Me.tb_SAPID.Size = New System.Drawing.Size(193, 22)
        Me.tb_SAPID.TabIndex = 3
        '
        'bt_SALVAR
        '
        Me.bt_SALVAR.Location = New System.Drawing.Point(179, 248)
        Me.bt_SALVAR.Name = "bt_SALVAR"
        Me.bt_SALVAR.Size = New System.Drawing.Size(93, 32)
        Me.bt_SALVAR.TabIndex = 4
        Me.bt_SALVAR.Text = "Salvar"
        Me.bt_SALVAR.UseVisualStyleBackColor = True
        '
        'bt_CANCELAR
        '
        Me.bt_CANCELAR.Location = New System.Drawing.Point(80, 248)
        Me.bt_CANCELAR.Name = "bt_CANCELAR"
        Me.bt_CANCELAR.Size = New System.Drawing.Size(93, 32)
        Me.bt_CANCELAR.TabIndex = 5
        Me.bt_CANCELAR.Text = "Cancelar"
        Me.bt_CANCELAR.UseVisualStyleBackColor = True
        '
        'cb_ENABLED
        '
        Me.cb_ENABLED.AutoSize = True
        Me.cb_ENABLED.Location = New System.Drawing.Point(80, 33)
        Me.cb_ENABLED.Name = "cb_ENABLED"
        Me.cb_ENABLED.Size = New System.Drawing.Size(73, 20)
        Me.cb_ENABLED.TabIndex = 6
        Me.cb_ENABLED.Text = "Habilitado"
        Me.cb_ENABLED.UseVisualStyleBackColor = True
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.Location = New System.Drawing.Point(79, 137)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(193, 24)
        Me.cb_MAQUINA.TabIndex = 7
        '
        'cb_MAQUINA_ID
        '
        Me.cb_MAQUINA_ID.FormattingEnabled = True
        Me.cb_MAQUINA_ID.Location = New System.Drawing.Point(79, 286)
        Me.cb_MAQUINA_ID.Name = "cb_MAQUINA_ID"
        Me.cb_MAQUINA_ID.Size = New System.Drawing.Size(48, 24)
        Me.cb_MAQUINA_ID.TabIndex = 8
        Me.cb_MAQUINA_ID.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Máquina"
        '
        'tb_ON
        '
        Me.tb_ON.Location = New System.Drawing.Point(79, 177)
        Me.tb_ON.Name = "tb_ON"
        Me.tb_ON.Size = New System.Drawing.Size(48, 22)
        Me.tb_ON.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tempo ON"
        '
        'tb_OFF
        '
        Me.tb_OFF.Location = New System.Drawing.Point(79, 210)
        Me.tb_OFF.Name = "tb_OFF"
        Me.tb_OFF.Size = New System.Drawing.Size(48, 22)
        Me.tb_OFF.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tempo OFF"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(132, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "seg."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(133, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "seg."
        '
        'frm_BABEL_EDIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 330)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tb_OFF)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tb_ON)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb_MAQUINA_ID)
        Me.Controls.Add(Me.cb_MAQUINA)
        Me.Controls.Add(Me.cb_ENABLED)
        Me.Controls.Add(Me.bt_CANCELAR)
        Me.Controls.Add(Me.bt_SALVAR)
        Me.Controls.Add(Me.tb_SAPID)
        Me.Controls.Add(Me.tb_DESCRICAO)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_BABEL_EDIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dados do BABEL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_DESCRICAO As TextBox
    Friend WithEvents tb_SAPID As TextBox
    Friend WithEvents bt_SALVAR As Button
    Friend WithEvents bt_CANCELAR As Button
    Friend WithEvents cb_ENABLED As CheckBox
    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents cb_MAQUINA_ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_ON As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tb_OFF As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
