<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SPLASH
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SPLASH))
        Me.tmr_SPLASH = New System.Windows.Forms.Timer(Me.components)
        Me.bt_Close = New System.Windows.Forms.Button()
        Me.lbl_MSG = New System.Windows.Forms.Label()
        Me.lbl_REVISION = New System.Windows.Forms.Label()
        Me.lbl_VERSION = New System.Windows.Forms.Label()
        Me.tmr_DBSEARCH = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bt_SEARCH = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lb_APPREVISION = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmr_SPLASH
        '
        Me.tmr_SPLASH.Interval = 5000
        '
        'bt_Close
        '
        resources.ApplyResources(Me.bt_Close, "bt_Close")
        Me.bt_Close.Name = "bt_Close"
        Me.bt_Close.UseVisualStyleBackColor = True
        '
        'lbl_MSG
        '
        Me.lbl_MSG.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.lbl_MSG, "lbl_MSG")
        Me.lbl_MSG.ForeColor = System.Drawing.Color.Black
        Me.lbl_MSG.Name = "lbl_MSG"
        '
        'lbl_REVISION
        '
        Me.lbl_REVISION.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.lbl_REVISION, "lbl_REVISION")
        Me.lbl_REVISION.ForeColor = System.Drawing.Color.Black
        Me.lbl_REVISION.Name = "lbl_REVISION"
        '
        'lbl_VERSION
        '
        Me.lbl_VERSION.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.lbl_VERSION, "lbl_VERSION")
        Me.lbl_VERSION.ForeColor = System.Drawing.Color.Black
        Me.lbl_VERSION.Name = "lbl_VERSION"
        '
        'tmr_DBSEARCH
        '
        Me.tmr_DBSEARCH.Interval = 3000
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(230, Byte), Integer))
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'bt_SEARCH
        '
        resources.ApplyResources(Me.bt_SEARCH, "bt_SEARCH")
        Me.bt_SEARCH.Name = "bt_SEARCH"
        Me.bt_SEARCH.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Interval = 3000
        '
        'lb_APPREVISION
        '
        Me.lb_APPREVISION.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.lb_APPREVISION, "lb_APPREVISION")
        Me.lb_APPREVISION.ForeColor = System.Drawing.Color.Black
        Me.lb_APPREVISION.Name = "lb_APPREVISION"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(112, Byte), Integer))
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Name = "Label3"
        '
        'frm_SPLASH
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lb_APPREVISION)
        Me.Controls.Add(Me.bt_SEARCH)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_VERSION)
        Me.Controls.Add(Me.lbl_REVISION)
        Me.Controls.Add(Me.lbl_MSG)
        Me.Controls.Add(Me.bt_Close)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_SPLASH"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmr_SPLASH As Timer
    Friend WithEvents bt_Close As Button
    Friend WithEvents lbl_MSG As Label
    Friend WithEvents lbl_REVISION As Label
    Friend WithEvents lbl_VERSION As Label
    Friend WithEvents tmr_DBSEARCH As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents bt_SEARCH As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents lb_APPREVISION As Label
    Friend WithEvents Label3 As Label
End Class
