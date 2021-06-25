<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MAQUINA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MAQUINA))
        Me.cb_MAQUINA = New System.Windows.Forms.ComboBox()
        Me.cb_MAQUINAID = New System.Windows.Forms.ComboBox()
        Me.bt_ESCOLHER = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cb_MAQUINA
        '
        Me.cb_MAQUINA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MAQUINA.DropDownWidth = 800
        Me.cb_MAQUINA.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MAQUINA.FormattingEnabled = True
        Me.cb_MAQUINA.IntegralHeight = False
        Me.cb_MAQUINA.Location = New System.Drawing.Point(12, 12)
        Me.cb_MAQUINA.Name = "cb_MAQUINA"
        Me.cb_MAQUINA.Size = New System.Drawing.Size(643, 65)
        Me.cb_MAQUINA.TabIndex = 1
        '
        'cb_MAQUINAID
        '
        Me.cb_MAQUINAID.FormattingEnabled = True
        Me.cb_MAQUINAID.Location = New System.Drawing.Point(534, 83)
        Me.cb_MAQUINAID.Name = "cb_MAQUINAID"
        Me.cb_MAQUINAID.Size = New System.Drawing.Size(121, 24)
        Me.cb_MAQUINAID.TabIndex = 34
        Me.cb_MAQUINAID.Visible = False
        '
        'bt_ESCOLHER
        '
        Me.bt_ESCOLHER.Enabled = False
        Me.bt_ESCOLHER.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ESCOLHER.Image = CType(resources.GetObject("bt_ESCOLHER.Image"), System.Drawing.Image)
        Me.bt_ESCOLHER.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ESCOLHER.Location = New System.Drawing.Point(536, 113)
        Me.bt_ESCOLHER.Name = "bt_ESCOLHER"
        Me.bt_ESCOLHER.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.bt_ESCOLHER.Size = New System.Drawing.Size(119, 65)
        Me.bt_ESCOLHER.TabIndex = 39
        Me.bt_ESCOLHER.Text = "ESCOLHER MÁQUINA"
        Me.bt_ESCOLHER.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_ESCOLHER.UseVisualStyleBackColor = True
        '
        'frm_MAQUINA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 187)
        Me.Controls.Add(Me.bt_ESCOLHER)
        Me.Controls.Add(Me.cb_MAQUINAID)
        Me.Controls.Add(Me.cb_MAQUINA)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_MAQUINA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Escolher Máquina"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cb_MAQUINA As ComboBox
    Friend WithEvents cb_MAQUINAID As ComboBox
    Friend WithEvents bt_ESCOLHER As Button
End Class
