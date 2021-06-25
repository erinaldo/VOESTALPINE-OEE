<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_HABMAQUINAS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_HABMAQUINAS))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_MAQUINAS = New DevComponents.DotNetBar.ListBoxAdv()
        Me.bt_SALVAR = New System.Windows.Forms.Button()
        Me.lb_MAQUINASID = New DevComponents.DotNetBar.ListBoxAdv()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lb_MAQUINAS)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 289)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Máquinas Cadastradas"
        '
        'lb_MAQUINAS
        '
        Me.lb_MAQUINAS.AutoScroll = True
        '
        '
        '
        Me.lb_MAQUINAS.BackgroundStyle.Class = "ListBoxAdv"
        Me.lb_MAQUINAS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb_MAQUINAS.CheckBoxesVisible = True
        Me.lb_MAQUINAS.CheckStateMember = Nothing
        Me.lb_MAQUINAS.ContainerControlProcessDialogKey = True
        Me.lb_MAQUINAS.DragDropSupport = True
        Me.lb_MAQUINAS.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lb_MAQUINAS.Location = New System.Drawing.Point(6, 21)
        Me.lb_MAQUINAS.Name = "lb_MAQUINAS"
        Me.lb_MAQUINAS.SelectionMode = DevComponents.DotNetBar.eSelectionMode.None
        Me.lb_MAQUINAS.Size = New System.Drawing.Size(461, 262)
        Me.lb_MAQUINAS.TabIndex = 0
        Me.lb_MAQUINAS.Text = "ListBoxAdv1"
        '
        'bt_SALVAR
        '
        Me.bt_SALVAR.Image = CType(resources.GetObject("bt_SALVAR.Image"), System.Drawing.Image)
        Me.bt_SALVAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_SALVAR.Location = New System.Drawing.Point(389, 326)
        Me.bt_SALVAR.Name = "bt_SALVAR"
        Me.bt_SALVAR.Size = New System.Drawing.Size(96, 29)
        Me.bt_SALVAR.TabIndex = 54
        Me.bt_SALVAR.Text = "     Salvar"
        Me.bt_SALVAR.UseVisualStyleBackColor = True
        '
        'lb_MAQUINASID
        '
        Me.lb_MAQUINASID.AutoScroll = True
        '
        '
        '
        Me.lb_MAQUINASID.BackgroundStyle.Class = "ListBoxAdv"
        Me.lb_MAQUINASID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lb_MAQUINASID.CheckBoxesVisible = True
        Me.lb_MAQUINASID.CheckStateMember = Nothing
        Me.lb_MAQUINASID.ContainerControlProcessDialogKey = True
        Me.lb_MAQUINASID.DragDropSupport = True
        Me.lb_MAQUINASID.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lb_MAQUINASID.Location = New System.Drawing.Point(12, 318)
        Me.lb_MAQUINASID.Name = "lb_MAQUINASID"
        Me.lb_MAQUINASID.Size = New System.Drawing.Size(119, 48)
        Me.lb_MAQUINASID.TabIndex = 55
        Me.lb_MAQUINASID.TabStop = False
        Me.lb_MAQUINASID.Text = "ListBoxAdv1"
        Me.lb_MAQUINASID.Visible = False
        '
        'frm_HABMAQUINAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 378)
        Me.Controls.Add(Me.lb_MAQUINASID)
        Me.Controls.Add(Me.bt_SALVAR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_HABMAQUINAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habilitar/Desabilitar Máquinas para os Relatórios"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lb_MAQUINAS As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents bt_SALVAR As Button
    Friend WithEvents lb_MAQUINASID As DevComponents.DotNetBar.ListBoxAdv
End Class
