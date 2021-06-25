<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWAIT
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cp_PROGRESS = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.tmr_REPORT = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Gerando Relatório"
        '
        'cp_PROGRESS
        '
        '
        '
        '
        Me.cp_PROGRESS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cp_PROGRESS.Location = New System.Drawing.Point(12, 12)
        Me.cp_PROGRESS.Name = "cp_PROGRESS"
        Me.cp_PROGRESS.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.cp_PROGRESS.Size = New System.Drawing.Size(40, 30)
        Me.cp_PROGRESS.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.cp_PROGRESS.TabIndex = 2
        Me.cp_PROGRESS.TabStop = False
        '
        'tmr_REPORT
        '
        Me.tmr_REPORT.Interval = 500
        '
        'frmWAIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(200, 59)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cp_PROGRESS)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWAIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aguarde ..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cp_PROGRESS As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents tmr_REPORT As System.Windows.Forms.Timer
End Class
