<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ONLINE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ONLINE))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_MOTIVO2 = New System.Windows.Forms.Label()
        Me.lb_MOTIVO = New System.Windows.Forms.Label()
        Me.lb_TEMPO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tmr_ONLINE = New System.Windows.Forms.Timer(Me.components)
        Me.lb_STATUS = New System.Windows.Forms.Label()
        Me.lb_MAQUINA = New System.Windows.Forms.Label()
        Me.lb_OP = New System.Windows.Forms.Label()
        Me.lb_PRODUTO = New System.Windows.Forms.Label()
        Me.tmr_BLINK = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_ITEM = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_MOTIVO3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_MOTIVO3)
        Me.GroupBox1.Controls.Add(Me.lbl_MOTIVO2)
        Me.GroupBox1.Controls.Add(Me.lb_MOTIVO)
        Me.GroupBox1.Controls.Add(Me.lb_TEMPO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(179, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(192, 192)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARADA"
        '
        'lbl_MOTIVO2
        '
        Me.lbl_MOTIVO2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_MOTIVO2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MOTIVO2.Location = New System.Drawing.Point(12, 122)
        Me.lbl_MOTIVO2.Name = "lbl_MOTIVO2"
        Me.lbl_MOTIVO2.Size = New System.Drawing.Size(172, 30)
        Me.lbl_MOTIVO2.TabIndex = 11
        Me.lbl_MOTIVO2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lb_MOTIVO
        '
        Me.lb_MOTIVO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_MOTIVO.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_MOTIVO.Location = New System.Drawing.Point(12, 86)
        Me.lb_MOTIVO.Name = "lb_MOTIVO"
        Me.lb_MOTIVO.Size = New System.Drawing.Size(172, 30)
        Me.lb_MOTIVO.TabIndex = 10
        Me.lb_MOTIVO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lb_TEMPO
        '
        Me.lb_TEMPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_TEMPO.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_TEMPO.Location = New System.Drawing.Point(69, 18)
        Me.lb_TEMPO.Name = "lb_TEMPO"
        Me.lb_TEMPO.Size = New System.Drawing.Size(115, 35)
        Me.lb_TEMPO.TabIndex = 9
        Me.lb_TEMPO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "MOTIVO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "TEMPO"
        '
        'tmr_ONLINE
        '
        Me.tmr_ONLINE.Interval = 5000
        '
        'lb_STATUS
        '
        Me.lb_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_STATUS.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_STATUS.Location = New System.Drawing.Point(8, 49)
        Me.lb_STATUS.Name = "lb_STATUS"
        Me.lb_STATUS.Size = New System.Drawing.Size(165, 114)
        Me.lb_STATUS.TabIndex = 9
        Me.lb_STATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_MAQUINA
        '
        Me.lb_MAQUINA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_MAQUINA.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_MAQUINA.Location = New System.Drawing.Point(8, 10)
        Me.lb_MAQUINA.Name = "lb_MAQUINA"
        Me.lb_MAQUINA.Size = New System.Drawing.Size(165, 35)
        Me.lb_MAQUINA.TabIndex = 10
        Me.lb_MAQUINA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_OP
        '
        Me.lb_OP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_OP.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_OP.Location = New System.Drawing.Point(8, 167)
        Me.lb_OP.Name = "lb_OP"
        Me.lb_OP.Size = New System.Drawing.Size(165, 35)
        Me.lb_OP.TabIndex = 11
        Me.lb_OP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lb_PRODUTO
        '
        Me.lb_PRODUTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_PRODUTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_PRODUTO.Location = New System.Drawing.Point(8, 206)
        Me.lb_PRODUTO.Name = "lb_PRODUTO"
        Me.lb_PRODUTO.Size = New System.Drawing.Size(165, 35)
        Me.lb_PRODUTO.TabIndex = 12
        Me.lb_PRODUTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmr_BLINK
        '
        Me.tmr_BLINK.Interval = 1000
        '
        'lbl_ITEM
        '
        Me.lbl_ITEM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_ITEM.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ITEM.Location = New System.Drawing.Point(104, 245)
        Me.lbl_ITEM.Name = "lbl_ITEM"
        Me.lbl_ITEM.Size = New System.Drawing.Size(69, 35)
        Me.lbl_ITEM.TabIndex = 13
        Me.lbl_ITEM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "ITEM"
        '
        'lbl_MOTIVO3
        '
        Me.lbl_MOTIVO3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_MOTIVO3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MOTIVO3.Location = New System.Drawing.Point(12, 159)
        Me.lbl_MOTIVO3.Name = "lbl_MOTIVO3"
        Me.lbl_MOTIVO3.Size = New System.Drawing.Size(172, 30)
        Me.lbl_MOTIVO3.TabIndex = 12
        Me.lbl_MOTIVO3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_ONLINE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 286)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_ITEM)
        Me.Controls.Add(Me.lb_PRODUTO)
        Me.Controls.Add(Me.lb_OP)
        Me.Controls.Add(Me.lb_MAQUINA)
        Me.Controls.Add(Me.lb_STATUS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ONLINE"
        Me.Text = "Monitoração ON-LINE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tmr_ONLINE As Timer
    Friend WithEvents lb_STATUS As Label
    Friend WithEvents lb_MAQUINA As Label
    Friend WithEvents lb_TEMPO As Label
    Friend WithEvents lb_MOTIVO As Label
    Friend WithEvents lb_OP As Label
    Friend WithEvents lb_PRODUTO As Label
    Friend WithEvents tmr_BLINK As Timer
    Friend WithEvents lbl_MOTIVO2 As Label
    Friend WithEvents lbl_ITEM As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_MOTIVO3 As Label
End Class
