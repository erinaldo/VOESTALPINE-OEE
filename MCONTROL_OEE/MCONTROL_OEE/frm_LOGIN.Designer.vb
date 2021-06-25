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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbx_USER = New System.Windows.Forms.TextBox()
        Me.tbx_PASSWORD = New System.Windows.Forms.TextBox()
        Me.bt_LOGIN = New System.Windows.Forms.Button()
        Me.bt_VIEW = New System.Windows.Forms.Button()
        Me.tbx_NEWPASSWORD = New System.Windows.Forms.TextBox()
        Me.tbx_NEWLOGIN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbx_CONFIRMPASS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bt_CONFIRMCHANGE = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(47, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(47, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Senha"
        '
        'tbx_USER
        '
        Me.tbx_USER.Location = New System.Drawing.Point(98, 31)
        Me.tbx_USER.Name = "tbx_USER"
        Me.tbx_USER.Size = New System.Drawing.Size(100, 22)
        Me.tbx_USER.TabIndex = 0
        '
        'tbx_PASSWORD
        '
        Me.tbx_PASSWORD.Location = New System.Drawing.Point(98, 61)
        Me.tbx_PASSWORD.Name = "tbx_PASSWORD"
        Me.tbx_PASSWORD.Size = New System.Drawing.Size(100, 22)
        Me.tbx_PASSWORD.TabIndex = 1
        Me.tbx_PASSWORD.UseSystemPasswordChar = True
        '
        'bt_LOGIN
        '
        Me.bt_LOGIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.bt_LOGIN.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bt_LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_LOGIN.ForeColor = System.Drawing.Color.Black
        Me.bt_LOGIN.Image = CType(resources.GetObject("bt_LOGIN.Image"), System.Drawing.Image)
        Me.bt_LOGIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_LOGIN.Location = New System.Drawing.Point(118, 89)
        Me.bt_LOGIN.Name = "bt_LOGIN"
        Me.bt_LOGIN.Size = New System.Drawing.Size(80, 28)
        Me.bt_LOGIN.TabIndex = 3
        Me.bt_LOGIN.Text = "  Log in"
        Me.bt_LOGIN.UseVisualStyleBackColor = False
        '
        'bt_VIEW
        '
        Me.bt_VIEW.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.bt_VIEW.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bt_VIEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_VIEW.ForeColor = System.Drawing.Color.Black
        Me.bt_VIEW.Image = CType(resources.GetObject("bt_VIEW.Image"), System.Drawing.Image)
        Me.bt_VIEW.Location = New System.Drawing.Point(203, 61)
        Me.bt_VIEW.Name = "bt_VIEW"
        Me.bt_VIEW.Size = New System.Drawing.Size(34, 22)
        Me.bt_VIEW.TabIndex = 2
        Me.bt_VIEW.UseVisualStyleBackColor = False
        '
        'tbx_NEWPASSWORD
        '
        Me.tbx_NEWPASSWORD.Location = New System.Drawing.Point(109, 182)
        Me.tbx_NEWPASSWORD.Name = "tbx_NEWPASSWORD"
        Me.tbx_NEWPASSWORD.Size = New System.Drawing.Size(100, 22)
        Me.tbx_NEWPASSWORD.TabIndex = 13
        Me.tbx_NEWPASSWORD.UseSystemPasswordChar = True
        '
        'tbx_NEWLOGIN
        '
        Me.tbx_NEWLOGIN.Location = New System.Drawing.Point(109, 152)
        Me.tbx_NEWLOGIN.Name = "tbx_NEWLOGIN"
        Me.tbx_NEWLOGIN.Size = New System.Drawing.Size(100, 22)
        Me.tbx_NEWLOGIN.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Nova Senha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(42, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Novo Login"
        '
        'tbx_CONFIRMPASS
        '
        Me.tbx_CONFIRMPASS.Location = New System.Drawing.Point(109, 210)
        Me.tbx_CONFIRMPASS.Name = "tbx_CONFIRMPASS"
        Me.tbx_CONFIRMPASS.Size = New System.Drawing.Size(100, 22)
        Me.tbx_CONFIRMPASS.TabIndex = 15
        Me.tbx_CONFIRMPASS.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(18, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Confirmar Senha"
        '
        'bt_CONFIRMCHANGE
        '
        Me.bt_CONFIRMCHANGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.bt_CONFIRMCHANGE.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bt_CONFIRMCHANGE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_CONFIRMCHANGE.ForeColor = System.Drawing.Color.Black
        Me.bt_CONFIRMCHANGE.Image = CType(resources.GetObject("bt_CONFIRMCHANGE.Image"), System.Drawing.Image)
        Me.bt_CONFIRMCHANGE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_CONFIRMCHANGE.Location = New System.Drawing.Point(129, 238)
        Me.bt_CONFIRMCHANGE.Name = "bt_CONFIRMCHANGE"
        Me.bt_CONFIRMCHANGE.Size = New System.Drawing.Size(80, 28)
        Me.bt_CONFIRMCHANGE.TabIndex = 16
        Me.bt_CONFIRMCHANGE.Text = "    Confirmar"
        Me.bt_CONFIRMCHANGE.UseVisualStyleBackColor = False
        '
        'frm_LOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(290, 127)
        Me.Controls.Add(Me.bt_CONFIRMCHANGE)
        Me.Controls.Add(Me.tbx_CONFIRMPASS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbx_NEWPASSWORD)
        Me.Controls.Add(Me.tbx_NEWLOGIN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bt_VIEW)
        Me.Controls.Add(Me.bt_LOGIN)
        Me.Controls.Add(Me.tbx_PASSWORD)
        Me.Controls.Add(Me.tbx_USER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_LOGIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "omniViewer Login"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbx_USER As TextBox
    Friend WithEvents tbx_PASSWORD As TextBox
    Friend WithEvents bt_LOGIN As Button
    Friend WithEvents tbx_NEWPASSWORD As TextBox
    Friend WithEvents tbx_NEWLOGIN As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbx_CONFIRMPASS As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents bt_CONFIRMCHANGE As Button
    Friend WithEvents bt_VIEW As Button
End Class
