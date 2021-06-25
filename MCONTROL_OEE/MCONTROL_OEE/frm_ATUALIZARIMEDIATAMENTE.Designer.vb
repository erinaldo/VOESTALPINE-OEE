<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ATUALIZARIMEDIATAMENTE
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
        Me.tb_ATUALIZANDO = New System.Windows.Forms.Label()
        Me.cp_ATUALIZANDO = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.tmr_ATUALIZANDO = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'tb_ATUALIZANDO
        '
        Me.tb_ATUALIZANDO.AutoSize = True
        Me.tb_ATUALIZANDO.Location = New System.Drawing.Point(59, 25)
        Me.tb_ATUALIZANDO.Name = "tb_ATUALIZANDO"
        Me.tb_ATUALIZANDO.Size = New System.Drawing.Size(74, 16)
        Me.tb_ATUALIZANDO.TabIndex = 5
        Me.tb_ATUALIZANDO.Text = "Atualizando ..."
        '
        'cp_ATUALIZANDO
        '
        '
        '
        '
        Me.cp_ATUALIZANDO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cp_ATUALIZANDO.Location = New System.Drawing.Point(12, 18)
        Me.cp_ATUALIZANDO.Name = "cp_ATUALIZANDO"
        Me.cp_ATUALIZANDO.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.cp_ATUALIZANDO.Size = New System.Drawing.Size(35, 31)
        Me.cp_ATUALIZANDO.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.cp_ATUALIZANDO.TabIndex = 4
        '
        'tmr_ATUALIZANDO
        '
        Me.tmr_ATUALIZANDO.Interval = 1000
        '
        'frm_ATUALIZARIMEDIATAMENTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(157, 77)
        Me.Controls.Add(Me.tb_ATUALIZANDO)
        Me.Controls.Add(Me.cp_ATUALIZANDO)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_ATUALIZARIMEDIATAMENTE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb_ATUALIZANDO As Label
    Friend WithEvents cp_ATUALIZANDO As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents tmr_ATUALIZANDO As Timer
End Class
