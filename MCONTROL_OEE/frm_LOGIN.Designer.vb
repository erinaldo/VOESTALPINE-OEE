<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LOGIN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LOGIN))
        Me.bt_LOGIN = New System.Windows.Forms.Button()
        Me.tbx_PASSWORD = New System.Windows.Forms.TextBox()
        Me.tbx_USER = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_CONFIRMARSENHA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_OK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bt_LOGIN
        '
        Me.bt_LOGIN.BackColor = System.Drawing.Color.Transparent
        Me.bt_LOGIN.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bt_LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_LOGIN.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_LOGIN.ForeColor = System.Drawing.Color.Black
        Me.bt_LOGIN.Image = CType(resources.GetObject("bt_LOGIN.Image"), System.Drawing.Image)
        Me.bt_LOGIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_LOGIN.Location = New System.Drawing.Point(201, 109)
        Me.bt_LOGIN.Name = "bt_LOGIN"
        Me.bt_LOGIN.Size = New System.Drawing.Size(136, 46)
        Me.bt_LOGIN.TabIndex = 2
        Me.bt_LOGIN.Text = "  Log in"
        Me.bt_LOGIN.UseVisualStyleBackColor = False
        '
        'tbx_PASSWORD
        '
        Me.tbx_PASSWORD.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_PASSWORD.Location = New System.Drawing.Point(114, 62)
        Me.tbx_PASSWORD.Name = "tbx_PASSWORD"
        Me.tbx_PASSWORD.Size = New System.Drawing.Size(223, 41)
        Me.tbx_PASSWORD.TabIndex = 1
        Me.tbx_PASSWORD.UseSystemPasswordChar = True
        '
        'tbx_USER
        '
        Me.tbx_USER.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbx_USER.Location = New System.Drawing.Point(115, 15)
        Me.tbx_USER.Name = "tbx_USER"
        Me.tbx_USER.Size = New System.Drawing.Size(222, 41)
        Me.tbx_USER.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 33)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Senha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 33)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Usuário"
        '
        'tb_CONFIRMARSENHA
        '
        Me.tb_CONFIRMARSENHA.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_CONFIRMARSENHA.Location = New System.Drawing.Point(114, 230)
        Me.tb_CONFIRMARSENHA.Name = "tb_CONFIRMARSENHA"
        Me.tb_CONFIRMARSENHA.Size = New System.Drawing.Size(223, 41)
        Me.tb_CONFIRMARSENHA.TabIndex = 8
        Me.tb_CONFIRMARSENHA.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(143, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 33)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Confirmar Senha"
        '
        'bt_OK
        '
        Me.bt_OK.BackColor = System.Drawing.Color.Transparent
        Me.bt_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bt_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_OK.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_OK.ForeColor = System.Drawing.Color.Black
        Me.bt_OK.Image = CType(resources.GetObject("bt_OK.Image"), System.Drawing.Image)
        Me.bt_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_OK.Location = New System.Drawing.Point(201, 277)
        Me.bt_OK.Name = "bt_OK"
        Me.bt_OK.Size = New System.Drawing.Size(136, 46)
        Me.bt_OK.TabIndex = 10
        Me.bt_OK.Text = "  Ok"
        Me.bt_OK.UseVisualStyleBackColor = False
        '
        'frm_LOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 171)
        Me.Controls.Add(Me.bt_OK)
        Me.Controls.Add(Me.tb_CONFIRMARSENHA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bt_LOGIN)
        Me.Controls.Add(Me.tbx_PASSWORD)
        Me.Controls.Add(Me.tbx_USER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_LOGIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_LOGIN As Button
    Friend WithEvents tbx_PASSWORD As TextBox
    Friend WithEvents tbx_USER As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_CONFIRMARSENHA As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents bt_OK As Button
End Class
