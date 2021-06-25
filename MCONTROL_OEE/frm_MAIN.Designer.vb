<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MAIN
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MAIN))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmr_STOP = New System.Windows.Forms.Timer(Me.components)
        Me.cb_MOTIVONIVEL1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_Usuarios = New System.Windows.Forms.ComboBox()
        Me.bt_Login = New System.Windows.Forms.Button()
        Me.bt_Logout = New System.Windows.Forms.Button()
        Me.gb_1 = New System.Windows.Forms.GroupBox()
        Me.tb_MAQUINA = New System.Windows.Forms.TextBox()
        Me.bt_MAQUINA = New System.Windows.Forms.Button()
        Me.bt_FINALIZAR = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pb_MOTIVO_WARNING = New System.Windows.Forms.PictureBox()
        Me.cb_MOTIVONIVEL3ID = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pb_DB_GRAY = New System.Windows.Forms.PictureBox()
        Me.pb_DB_RED = New System.Windows.Forms.PictureBox()
        Me.pb_DB_GREEN = New System.Windows.Forms.PictureBox()
        Me.cb_MOTIVONIVEL2ID = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pb_DEVICE_GRAY2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pb_DEVICE_RED = New System.Windows.Forms.PictureBox()
        Me.pb_DEVICE_GREEN = New System.Windows.Forms.PictureBox()
        Me.cb_MOTIVONIVEL1ID = New System.Windows.Forms.ComboBox()
        Me.cb_MOTIVONIVEL3 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_MOTIVONIVEL2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_RESTAM = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_COMENTARIO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_TPPARADA = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_HPPARADA = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_TTPARADA = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_HIPARADA = New System.Windows.Forms.Label()
        Me.lbl_MSTATUS = New System.Windows.Forms.Label()
        Me.bt_ALTERARMOTIVO = New System.Windows.Forms.Button()
        Me.bt_RTOTAL = New System.Windows.Forms.Button()
        Me.pb_OK = New System.Windows.Forms.PictureBox()
        Me.tmr_LOGIN = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_BLINK = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_TEMPOPARADA = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_STATUS = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_BLINKDEVICE = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_BLINKDB = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_MOTIVOS = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_ORDEM = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_PARADAFINALIZADA = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_MAQUINA = New System.Windows.Forms.Timer(Me.components)
        Me.gb_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_MOTIVO_WARNING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pb_DB_GRAY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_DB_RED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_DB_GREEN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pb_DEVICE_GRAY2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_DEVICE_RED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_DEVICE_GREEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Máquina"
        '
        'tmr_STOP
        '
        Me.tmr_STOP.Interval = 1000
        '
        'cb_MOTIVONIVEL1
        '
        Me.cb_MOTIVONIVEL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL1.Enabled = False
        Me.cb_MOTIVONIVEL1.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL1.FormattingEnabled = True
        Me.cb_MOTIVONIVEL1.IntegralHeight = False
        Me.cb_MOTIVONIVEL1.Location = New System.Drawing.Point(225, 82)
        Me.cb_MOTIVONIVEL1.Name = "cb_MOTIVONIVEL1"
        Me.cb_MOTIVONIVEL1.Size = New System.Drawing.Size(643, 51)
        Me.cb_MOTIVONIVEL1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 43)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Motivo Nível 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 57)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Operador"
        '
        'cb_Usuarios
        '
        Me.cb_Usuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Usuarios.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Usuarios.FormattingEnabled = True
        Me.cb_Usuarios.IntegralHeight = False
        Me.cb_Usuarios.Location = New System.Drawing.Point(237, 9)
        Me.cb_Usuarios.Name = "cb_Usuarios"
        Me.cb_Usuarios.Size = New System.Drawing.Size(643, 65)
        Me.cb_Usuarios.TabIndex = 9
        '
        'bt_Login
        '
        Me.bt_Login.Enabled = False
        Me.bt_Login.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_Login.Image = CType(resources.GetObject("bt_Login.Image"), System.Drawing.Image)
        Me.bt_Login.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_Login.Location = New System.Drawing.Point(884, 9)
        Me.bt_Login.Name = "bt_Login"
        Me.bt_Login.Size = New System.Drawing.Size(66, 67)
        Me.bt_Login.TabIndex = 10
        Me.bt_Login.Text = "Login"
        Me.bt_Login.UseVisualStyleBackColor = True
        '
        'bt_Logout
        '
        Me.bt_Logout.Enabled = False
        Me.bt_Logout.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_Logout.Image = CType(resources.GetObject("bt_Logout.Image"), System.Drawing.Image)
        Me.bt_Logout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_Logout.Location = New System.Drawing.Point(951, 9)
        Me.bt_Logout.Name = "bt_Logout"
        Me.bt_Logout.Size = New System.Drawing.Size(67, 67)
        Me.bt_Logout.TabIndex = 11
        Me.bt_Logout.Text = "Logout"
        Me.bt_Logout.UseVisualStyleBackColor = True
        '
        'gb_1
        '
        Me.gb_1.Controls.Add(Me.tb_MAQUINA)
        Me.gb_1.Controls.Add(Me.bt_MAQUINA)
        Me.gb_1.Controls.Add(Me.bt_FINALIZAR)
        Me.gb_1.Controls.Add(Me.GroupBox2)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL3ID)
        Me.gb_1.Controls.Add(Me.GroupBox3)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL2ID)
        Me.gb_1.Controls.Add(Me.GroupBox1)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL1ID)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL3)
        Me.gb_1.Controls.Add(Me.Label11)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL2)
        Me.gb_1.Controls.Add(Me.Label2)
        Me.gb_1.Controls.Add(Me.lbl_RESTAM)
        Me.gb_1.Controls.Add(Me.Label8)
        Me.gb_1.Controls.Add(Me.tb_COMENTARIO)
        Me.gb_1.Controls.Add(Me.Label12)
        Me.gb_1.Controls.Add(Me.lbl_TPPARADA)
        Me.gb_1.Controls.Add(Me.Label10)
        Me.gb_1.Controls.Add(Me.lbl_HPPARADA)
        Me.gb_1.Controls.Add(Me.Label9)
        Me.gb_1.Controls.Add(Me.lbl_TTPARADA)
        Me.gb_1.Controls.Add(Me.Label6)
        Me.gb_1.Controls.Add(Me.cb_MOTIVONIVEL1)
        Me.gb_1.Controls.Add(Me.Label7)
        Me.gb_1.Controls.Add(Me.lbl_HIPARADA)
        Me.gb_1.Controls.Add(Me.lbl_MSTATUS)
        Me.gb_1.Controls.Add(Me.bt_ALTERARMOTIVO)
        Me.gb_1.Controls.Add(Me.bt_RTOTAL)
        Me.gb_1.Controls.Add(Me.Label1)
        Me.gb_1.Controls.Add(Me.Label4)
        Me.gb_1.Controls.Add(Me.pb_OK)
        Me.gb_1.Enabled = False
        Me.gb_1.Location = New System.Drawing.Point(12, 80)
        Me.gb_1.Name = "gb_1"
        Me.gb_1.Size = New System.Drawing.Size(1006, 659)
        Me.gb_1.TabIndex = 12
        Me.gb_1.TabStop = False
        '
        'tb_MAQUINA
        '
        Me.tb_MAQUINA.Enabled = False
        Me.tb_MAQUINA.Font = New System.Drawing.Font("Arial Narrow", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_MAQUINA.Location = New System.Drawing.Point(225, 13)
        Me.tb_MAQUINA.Multiline = True
        Me.tb_MAQUINA.Name = "tb_MAQUINA"
        Me.tb_MAQUINA.Size = New System.Drawing.Size(643, 65)
        Me.tb_MAQUINA.TabIndex = 39
        '
        'bt_MAQUINA
        '
        Me.bt_MAQUINA.Enabled = False
        Me.bt_MAQUINA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_MAQUINA.Image = CType(resources.GetObject("bt_MAQUINA.Image"), System.Drawing.Image)
        Me.bt_MAQUINA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_MAQUINA.Location = New System.Drawing.Point(877, 13)
        Me.bt_MAQUINA.Name = "bt_MAQUINA"
        Me.bt_MAQUINA.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.bt_MAQUINA.Size = New System.Drawing.Size(119, 65)
        Me.bt_MAQUINA.TabIndex = 38
        Me.bt_MAQUINA.Text = "ESCOLHER MÁQUINA"
        Me.bt_MAQUINA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_MAQUINA.UseVisualStyleBackColor = True
        '
        'bt_FINALIZAR
        '
        Me.bt_FINALIZAR.Enabled = False
        Me.bt_FINALIZAR.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_FINALIZAR.Image = CType(resources.GetObject("bt_FINALIZAR.Image"), System.Drawing.Image)
        Me.bt_FINALIZAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_FINALIZAR.Location = New System.Drawing.Point(877, 253)
        Me.bt_FINALIZAR.Name = "bt_FINALIZAR"
        Me.bt_FINALIZAR.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.bt_FINALIZAR.Size = New System.Drawing.Size(119, 77)
        Me.bt_FINALIZAR.TabIndex = 37
        Me.bt_FINALIZAR.Text = "FINALIZAR PARADA MANUTENÇÃO"
        Me.bt_FINALIZAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_FINALIZAR.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pb_MOTIVO_WARNING)
        Me.GroupBox2.Location = New System.Drawing.Point(237, 545)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(110, 68)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MOTIVO VAZIO"
        '
        'pb_MOTIVO_WARNING
        '
        Me.pb_MOTIVO_WARNING.Image = CType(resources.GetObject("pb_MOTIVO_WARNING.Image"), System.Drawing.Image)
        Me.pb_MOTIVO_WARNING.Location = New System.Drawing.Point(32, 21)
        Me.pb_MOTIVO_WARNING.Name = "pb_MOTIVO_WARNING"
        Me.pb_MOTIVO_WARNING.Size = New System.Drawing.Size(38, 37)
        Me.pb_MOTIVO_WARNING.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_MOTIVO_WARNING.TabIndex = 18
        Me.pb_MOTIVO_WARNING.TabStop = False
        Me.pb_MOTIVO_WARNING.Visible = False
        '
        'cb_MOTIVONIVEL3ID
        '
        Me.cb_MOTIVONIVEL3ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL3ID.Location = New System.Drawing.Point(750, 223)
        Me.cb_MOTIVONIVEL3ID.Name = "cb_MOTIVONIVEL3ID"
        Me.cb_MOTIVONIVEL3ID.Size = New System.Drawing.Size(121, 24)
        Me.cb_MOTIVONIVEL3ID.TabIndex = 36
        Me.cb_MOTIVONIVEL3ID.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pb_DB_GRAY)
        Me.GroupBox3.Controls.Add(Me.pb_DB_RED)
        Me.GroupBox3.Controls.Add(Me.pb_DB_GREEN)
        Me.GroupBox3.Location = New System.Drawing.Point(121, 545)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(110, 68)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SERVIDOR MES"
        '
        'pb_DB_GRAY
        '
        Me.pb_DB_GRAY.Image = CType(resources.GetObject("pb_DB_GRAY.Image"), System.Drawing.Image)
        Me.pb_DB_GRAY.Location = New System.Drawing.Point(33, 21)
        Me.pb_DB_GRAY.Name = "pb_DB_GRAY"
        Me.pb_DB_GRAY.Size = New System.Drawing.Size(38, 37)
        Me.pb_DB_GRAY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DB_GRAY.TabIndex = 18
        Me.pb_DB_GRAY.TabStop = False
        '
        'pb_DB_RED
        '
        Me.pb_DB_RED.Image = CType(resources.GetObject("pb_DB_RED.Image"), System.Drawing.Image)
        Me.pb_DB_RED.Location = New System.Drawing.Point(33, 21)
        Me.pb_DB_RED.Name = "pb_DB_RED"
        Me.pb_DB_RED.Size = New System.Drawing.Size(38, 37)
        Me.pb_DB_RED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DB_RED.TabIndex = 17
        Me.pb_DB_RED.TabStop = False
        Me.pb_DB_RED.Visible = False
        '
        'pb_DB_GREEN
        '
        Me.pb_DB_GREEN.Image = CType(resources.GetObject("pb_DB_GREEN.Image"), System.Drawing.Image)
        Me.pb_DB_GREEN.Location = New System.Drawing.Point(33, 21)
        Me.pb_DB_GREEN.Name = "pb_DB_GREEN"
        Me.pb_DB_GREEN.Size = New System.Drawing.Size(38, 37)
        Me.pb_DB_GREEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DB_GREEN.TabIndex = 16
        Me.pb_DB_GREEN.TabStop = False
        Me.pb_DB_GREEN.Visible = False
        '
        'cb_MOTIVONIVEL2ID
        '
        Me.cb_MOTIVONIVEL2ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL2ID.Location = New System.Drawing.Point(750, 168)
        Me.cb_MOTIVONIVEL2ID.Name = "cb_MOTIVONIVEL2ID"
        Me.cb_MOTIVONIVEL2ID.Size = New System.Drawing.Size(121, 24)
        Me.cb_MOTIVONIVEL2ID.TabIndex = 35
        Me.cb_MOTIVONIVEL2ID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pb_DEVICE_GRAY2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.pb_DEVICE_RED)
        Me.GroupBox1.Controls.Add(Me.pb_DEVICE_GREEN)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 545)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 68)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BABEL FISH"
        '
        'pb_DEVICE_GRAY2
        '
        Me.pb_DEVICE_GRAY2.Image = CType(resources.GetObject("pb_DEVICE_GRAY2.Image"), System.Drawing.Image)
        Me.pb_DEVICE_GRAY2.Location = New System.Drawing.Point(34, 21)
        Me.pb_DEVICE_GRAY2.Name = "pb_DEVICE_GRAY2"
        Me.pb_DEVICE_GRAY2.Size = New System.Drawing.Size(38, 37)
        Me.pb_DEVICE_GRAY2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DEVICE_GRAY2.TabIndex = 19
        Me.pb_DEVICE_GRAY2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(456, 868)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'pb_DEVICE_RED
        '
        Me.pb_DEVICE_RED.Image = CType(resources.GetObject("pb_DEVICE_RED.Image"), System.Drawing.Image)
        Me.pb_DEVICE_RED.Location = New System.Drawing.Point(34, 21)
        Me.pb_DEVICE_RED.Name = "pb_DEVICE_RED"
        Me.pb_DEVICE_RED.Size = New System.Drawing.Size(38, 37)
        Me.pb_DEVICE_RED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DEVICE_RED.TabIndex = 16
        Me.pb_DEVICE_RED.TabStop = False
        Me.pb_DEVICE_RED.Visible = False
        '
        'pb_DEVICE_GREEN
        '
        Me.pb_DEVICE_GREEN.Image = CType(resources.GetObject("pb_DEVICE_GREEN.Image"), System.Drawing.Image)
        Me.pb_DEVICE_GREEN.Location = New System.Drawing.Point(34, 21)
        Me.pb_DEVICE_GREEN.Name = "pb_DEVICE_GREEN"
        Me.pb_DEVICE_GREEN.Size = New System.Drawing.Size(38, 37)
        Me.pb_DEVICE_GREEN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_DEVICE_GREEN.TabIndex = 15
        Me.pb_DEVICE_GREEN.TabStop = False
        Me.pb_DEVICE_GREEN.Visible = False
        '
        'cb_MOTIVONIVEL1ID
        '
        Me.cb_MOTIVONIVEL1ID.FormattingEnabled = True
        Me.cb_MOTIVONIVEL1ID.Location = New System.Drawing.Point(750, 109)
        Me.cb_MOTIVONIVEL1ID.Name = "cb_MOTIVONIVEL1ID"
        Me.cb_MOTIVONIVEL1ID.Size = New System.Drawing.Size(121, 24)
        Me.cb_MOTIVONIVEL1ID.TabIndex = 34
        Me.cb_MOTIVONIVEL1ID.Visible = False
        '
        'cb_MOTIVONIVEL3
        '
        Me.cb_MOTIVONIVEL3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL3.Enabled = False
        Me.cb_MOTIVONIVEL3.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL3.FormattingEnabled = True
        Me.cb_MOTIVONIVEL3.IntegralHeight = False
        Me.cb_MOTIVONIVEL3.Location = New System.Drawing.Point(225, 196)
        Me.cb_MOTIVONIVEL3.Name = "cb_MOTIVONIVEL3"
        Me.cb_MOTIVONIVEL3.Size = New System.Drawing.Size(643, 51)
        Me.cb_MOTIVONIVEL3.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 199)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(210, 43)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Motivo Nível 3"
        '
        'cb_MOTIVONIVEL2
        '
        Me.cb_MOTIVONIVEL2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_MOTIVONIVEL2.Enabled = False
        Me.cb_MOTIVONIVEL2.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_MOTIVONIVEL2.FormattingEnabled = True
        Me.cb_MOTIVONIVEL2.IntegralHeight = False
        Me.cb_MOTIVONIVEL2.Location = New System.Drawing.Point(225, 139)
        Me.cb_MOTIVONIVEL2.Name = "cb_MOTIVONIVEL2"
        Me.cb_MOTIVONIVEL2.Size = New System.Drawing.Size(643, 51)
        Me.cb_MOTIVONIVEL2.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 43)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Motivo Nível 2"
        '
        'lbl_RESTAM
        '
        Me.lbl_RESTAM.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RESTAM.Location = New System.Drawing.Point(126, 288)
        Me.lbl_RESTAM.Name = "lbl_RESTAM"
        Me.lbl_RESTAM.Size = New System.Drawing.Size(93, 42)
        Me.lbl_RESTAM.TabIndex = 28
        Me.lbl_RESTAM.Text = "Restam 1024 Caracteres"
        Me.lbl_RESTAM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(46, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 43)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Comentário"
        '
        'tb_COMENTARIO
        '
        Me.tb_COMENTARIO.Enabled = False
        Me.tb_COMENTARIO.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_COMENTARIO.Location = New System.Drawing.Point(225, 253)
        Me.tb_COMENTARIO.Multiline = True
        Me.tb_COMENTARIO.Name = "tb_COMENTARIO"
        Me.tb_COMENTARIO.Size = New System.Drawing.Size(487, 77)
        Me.tb_COMENTARIO.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(857, 445)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 42)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Tempo Parcial Parada"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TPPARADA
        '
        Me.lbl_TPPARADA.BackColor = System.Drawing.Color.White
        Me.lbl_TPPARADA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TPPARADA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TPPARADA.Location = New System.Drawing.Point(858, 487)
        Me.lbl_TPPARADA.Name = "lbl_TPPARADA"
        Me.lbl_TPPARADA.Size = New System.Drawing.Size(143, 53)
        Me.lbl_TPPARADA.TabIndex = 24
        Me.lbl_TPPARADA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(718, 445)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 42)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Horário Parcial Parada"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HPPARADA
        '
        Me.lbl_HPPARADA.BackColor = System.Drawing.Color.White
        Me.lbl_HPPARADA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_HPPARADA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HPPARADA.Location = New System.Drawing.Point(713, 487)
        Me.lbl_HPPARADA.Name = "lbl_HPPARADA"
        Me.lbl_HPPARADA.Size = New System.Drawing.Size(143, 53)
        Me.lbl_HPPARADA.TabIndex = 22
        Me.lbl_HPPARADA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(863, 358)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 33)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Tempo Total Parada"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TTPARADA
        '
        Me.lbl_TTPARADA.BackColor = System.Drawing.Color.White
        Me.lbl_TTPARADA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_TTPARADA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TTPARADA.Location = New System.Drawing.Point(859, 394)
        Me.lbl_TTPARADA.Name = "lbl_TTPARADA"
        Me.lbl_TTPARADA.Size = New System.Drawing.Size(145, 51)
        Me.lbl_TTPARADA.TabIndex = 20
        Me.lbl_TTPARADA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 333)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(419, 33)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Status de Funcionamento da Máquina"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(717, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 22)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Horário Inicial Parada"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HIPARADA
        '
        Me.lbl_HIPARADA.BackColor = System.Drawing.Color.White
        Me.lbl_HIPARADA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_HIPARADA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HIPARADA.Location = New System.Drawing.Point(714, 394)
        Me.lbl_HIPARADA.Name = "lbl_HIPARADA"
        Me.lbl_HIPARADA.Size = New System.Drawing.Size(143, 53)
        Me.lbl_HIPARADA.TabIndex = 16
        Me.lbl_HIPARADA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_MSTATUS
        '
        Me.lbl_MSTATUS.BackColor = System.Drawing.Color.White
        Me.lbl_MSTATUS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_MSTATUS.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MSTATUS.Location = New System.Drawing.Point(6, 374)
        Me.lbl_MSTATUS.Name = "lbl_MSTATUS"
        Me.lbl_MSTATUS.Size = New System.Drawing.Size(704, 166)
        Me.lbl_MSTATUS.TabIndex = 15
        Me.lbl_MSTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bt_ALTERARMOTIVO
        '
        Me.bt_ALTERARMOTIVO.Enabled = False
        Me.bt_ALTERARMOTIVO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ALTERARMOTIVO.Image = CType(resources.GetObject("bt_ALTERARMOTIVO.Image"), System.Drawing.Image)
        Me.bt_ALTERARMOTIVO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ALTERARMOTIVO.Location = New System.Drawing.Point(877, 157)
        Me.bt_ALTERARMOTIVO.Name = "bt_ALTERARMOTIVO"
        Me.bt_ALTERARMOTIVO.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.bt_ALTERARMOTIVO.Size = New System.Drawing.Size(119, 65)
        Me.bt_ALTERARMOTIVO.TabIndex = 14
        Me.bt_ALTERARMOTIVO.Text = "ALTERAR DADOS MOTIVO"
        Me.bt_ALTERARMOTIVO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_ALTERARMOTIVO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_ALTERARMOTIVO.UseVisualStyleBackColor = True
        '
        'bt_RTOTAL
        '
        Me.bt_RTOTAL.Enabled = False
        Me.bt_RTOTAL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_RTOTAL.Image = CType(resources.GetObject("bt_RTOTAL.Image"), System.Drawing.Image)
        Me.bt_RTOTAL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_RTOTAL.Location = New System.Drawing.Point(749, 253)
        Me.bt_RTOTAL.Name = "bt_RTOTAL"
        Me.bt_RTOTAL.Size = New System.Drawing.Size(119, 77)
        Me.bt_RTOTAL.TabIndex = 13
        Me.bt_RTOTAL.Text = "REGISTRAR NOVO MOTIVO"
        Me.bt_RTOTAL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_RTOTAL.UseVisualStyleBackColor = True
        '
        'pb_OK
        '
        Me.pb_OK.BackColor = System.Drawing.Color.Transparent
        Me.pb_OK.Image = CType(resources.GetObject("pb_OK.Image"), System.Drawing.Image)
        Me.pb_OK.Location = New System.Drawing.Point(840, 55)
        Me.pb_OK.Name = "pb_OK"
        Me.pb_OK.Size = New System.Drawing.Size(115, 107)
        Me.pb_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_OK.TabIndex = 18
        Me.pb_OK.TabStop = False
        Me.pb_OK.Visible = False
        '
        'tmr_LOGIN
        '
        Me.tmr_LOGIN.Interval = 1000
        '
        'tmr_BLINK
        '
        Me.tmr_BLINK.Interval = 1000
        '
        'tmr_TEMPOPARADA
        '
        Me.tmr_TEMPOPARADA.Interval = 1000
        '
        'tmr_STATUS
        '
        Me.tmr_STATUS.Interval = 5000
        '
        'tmr_BLINKDEVICE
        '
        Me.tmr_BLINKDEVICE.Interval = 1000
        '
        'tmr_BLINKDB
        '
        Me.tmr_BLINKDB.Interval = 1000
        '
        'tmr_MOTIVOS
        '
        Me.tmr_MOTIVOS.Interval = 1000
        '
        'tmr_ORDEM
        '
        Me.tmr_ORDEM.Interval = 1000
        '
        'tmr_PARADAFINALIZADA
        '
        Me.tmr_PARADAFINALIZADA.Interval = 1000
        '
        'tmr_MAQUINA
        '
        '
        'frm_MAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 809)
        Me.Controls.Add(Me.gb_1)
        Me.Controls.Add(Me.bt_Logout)
        Me.Controls.Add(Me.bt_Login)
        Me.Controls.Add(Me.cb_Usuarios)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_MAIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MControl_ OEE - Módulo de Apontamento de Parada de Máquina - V. 1.5.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gb_1.ResumeLayout(False)
        Me.gb_1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.pb_MOTIVO_WARNING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pb_DB_GRAY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_DB_RED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_DB_GREEN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pb_DEVICE_GRAY2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_DEVICE_RED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_DEVICE_GREEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_OK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tmr_STOP As Timer
    Friend WithEvents cb_MOTIVONIVEL1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cb_Usuarios As ComboBox
    Friend WithEvents bt_Login As Button
    Friend WithEvents bt_Logout As Button
    Friend WithEvents gb_1 As GroupBox
    Friend WithEvents bt_ALTERARMOTIVO As Button
    Friend WithEvents bt_RTOTAL As Button
    Friend WithEvents tmr_LOGIN As Timer
    Friend WithEvents lbl_MSTATUS As Label
    Friend WithEvents tmr_BLINK As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_HIPARADA As Label
    Friend WithEvents pb_OK As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lbl_TPPARADA As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_HPPARADA As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbl_TTPARADA As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pb_DEVICE_GREEN As PictureBox
    Friend WithEvents pb_DEVICE_RED As PictureBox
    Friend WithEvents pb_MOTIVO_WARNING As PictureBox
    Friend WithEvents pb_DB_RED As PictureBox
    Friend WithEvents pb_DB_GREEN As PictureBox
    Friend WithEvents tmr_TEMPOPARADA As Timer
    Friend WithEvents Label8 As Label
    Friend WithEvents tb_COMENTARIO As TextBox
    Friend WithEvents lbl_RESTAM As Label
    Friend WithEvents tmr_STATUS As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tmr_BLINKDEVICE As Timer
    Friend WithEvents tmr_BLINKDB As Timer
    Friend WithEvents pb_DB_GRAY As PictureBox
    Friend WithEvents pb_DEVICE_GRAY2 As PictureBox
    Friend WithEvents tmr_MOTIVOS As Timer
    Friend WithEvents tmr_ORDEM As Timer
    Friend WithEvents cb_MOTIVONIVEL3 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cb_MOTIVONIVEL2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cb_MOTIVONIVEL3ID As ComboBox
    Friend WithEvents cb_MOTIVONIVEL2ID As ComboBox
    Friend WithEvents cb_MOTIVONIVEL1ID As ComboBox
    Friend WithEvents bt_FINALIZAR As Button
    Friend WithEvents tmr_PARADAFINALIZADA As Timer
    Friend WithEvents bt_MAQUINA As Button
    Friend WithEvents tmr_MAQUINA As Timer
    Friend WithEvents tb_MAQUINA As TextBox
End Class
