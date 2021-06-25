<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MOTIVOSPARADAS_ORIENTACAO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MOTIVOSPARADAS_ORIENTACAO))
        Me.tb_ORIENTACAO = New System.Windows.Forms.TextBox()
        Me.bt_SAVE = New System.Windows.Forms.Button()
        Me.bt_CANCELAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb_ORIENTACAO
        '
        Me.tb_ORIENTACAO.Location = New System.Drawing.Point(13, 16)
        Me.tb_ORIENTACAO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tb_ORIENTACAO.MaxLength = 1024
        Me.tb_ORIENTACAO.Multiline = True
        Me.tb_ORIENTACAO.Name = "tb_ORIENTACAO"
        Me.tb_ORIENTACAO.Size = New System.Drawing.Size(426, 116)
        Me.tb_ORIENTACAO.TabIndex = 0
        '
        'bt_SAVE
        '
        Me.bt_SAVE.Image = CType(resources.GetObject("bt_SAVE.Image"), System.Drawing.Image)
        Me.bt_SAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_SAVE.Location = New System.Drawing.Point(338, 139)
        Me.bt_SAVE.Name = "bt_SAVE"
        Me.bt_SAVE.Size = New System.Drawing.Size(101, 28)
        Me.bt_SAVE.TabIndex = 1
        Me.bt_SAVE.Text = "Salvar"
        Me.bt_SAVE.UseVisualStyleBackColor = True
        '
        'bt_CANCELAR
        '
        Me.bt_CANCELAR.Image = CType(resources.GetObject("bt_CANCELAR.Image"), System.Drawing.Image)
        Me.bt_CANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_CANCELAR.Location = New System.Drawing.Point(231, 139)
        Me.bt_CANCELAR.Name = "bt_CANCELAR"
        Me.bt_CANCELAR.Size = New System.Drawing.Size(101, 28)
        Me.bt_CANCELAR.TabIndex = 2
        Me.bt_CANCELAR.Text = "Cancelar"
        Me.bt_CANCELAR.UseVisualStyleBackColor = True
        '
        'frm_MOTIVOSPARADAS_ORIENTACAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 182)
        Me.ControlBox = False
        Me.Controls.Add(Me.bt_CANCELAR)
        Me.Controls.Add(Me.bt_SAVE)
        Me.Controls.Add(Me.tb_ORIENTACAO)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_MOTIVOSPARADAS_ORIENTACAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orientação para Motivo de Parada"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb_ORIENTACAO As TextBox
    Friend WithEvents bt_SAVE As Button
    Friend WithEvents bt_CANCELAR As Button
End Class
