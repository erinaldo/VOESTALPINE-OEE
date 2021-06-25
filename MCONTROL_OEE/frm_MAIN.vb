Imports System.ComponentModel

Public Class frm_MAIN

    Dim bolLOGOUT As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim bolConnected As Boolean = False

        Try

            If xmlGetDataSource(strDataSource) = False Then
                Beep()
                MsgBox("Falha na leitura do arquivo de Conexão DBDataSource.xml", MsgBoxStyle.OkOnly, "Erro de Conexão")
                Exit Sub
            Else
                If TestConnection(bolConnected, "sa", "@llexo2017A") = False Then
                    pb_DB_GRAY.Visible = False
                    pb_DB_RED.Visible = True
                    pb_DB_GREEN.Visible = False
                    tmr_BLINKDB.Enabled = True
                    Beep()
                    MsgBox("Falha de Conexão com o Banco de Dados", MsgBoxStyle.OkOnly, "Erro de Conexão")
                    Exit Sub
                Else
                    If bolConnected = True Then

                        tmr_STATUS.Enabled = True
                        cb_Usuarios.Items.Add("Selecione o Usuário ...")
                        If ReadUsuarios(cb_Usuarios, strUsers, strErro) = False Then
                            Beep()
                            MsgBox("Falha na Leitura dos Usuários Cadastrados", MsgBoxStyle.OkOnly, "Erro de Leitura de Tabela")
                            Exit Sub
                        Else
                            cb_Usuarios.SelectedIndex = 0
                        End If

                    Else
                        pb_DB_GRAY.Visible = False
                        pb_DB_RED.Visible = True
                        pb_DB_GREEN.Visible = False
                        tmr_BLINKDB.Enabled = True
                        Beep()
                        MsgBox("Falha de Conexão com o Banco de Dados", MsgBoxStyle.OkOnly, "Erro de Conexão")
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception

            ErrorLog("Falha na Inicialização do Módulo Form1_Load")
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub bt_Login_Click(sender As Object, e As EventArgs) Handles bt_Login.Click

        Dim frmLogin As New frm_LOGIN

        strUserId = strUsers(cb_Usuarios.SelectedIndex - 1, 0)
        strLogin = strUsers(cb_Usuarios.SelectedIndex - 1, 1)
        strPassword = strUsers(cb_Usuarios.SelectedIndex - 1, 2)
        frmLogin.Show()
        tmr_LOGIN.Enabled = True
        Me.Enabled = False

    End Sub
    Private Sub tmr_LOGIN_Tick(sender As Object, e As EventArgs) Handles tmr_LOGIN.Tick

        Dim frmF As New frm_LOGIN
        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MControl_OEE.frm_LOGIN" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_LOGIN.Enabled = False
            Me.Enabled = True
            If bolLogged = True Then
                bt_MAQUINA.Enabled = True
                gb_1.Enabled = True
                cb_Usuarios.Enabled = False
                bt_Login.Enabled = False
                bt_Logout.Enabled = True
            End If
        End If

    End Sub
    Private Sub bt_Logout_Click(sender As Object, e As EventArgs) Handles bt_Logout.Click

        Dim intResposta As Integer = 0
        intResposta = MessageBox.Show("Confirma Logout?", "Logut do Sistema", MessageBoxButtons.YesNo)
        If intResposta = DialogResult.Yes Then
            bt_MAQUINA.Enabled = False
            tb_MAQUINA.Text = ""
            bolLOGOUT = True
            lbl_MSTATUS.Text = ""
            lbl_HIPARADA.Text = ""
            lbl_HPPARADA.Text = ""
            lbl_TPPARADA.Text = ""
            lbl_TPPARADA.Text = ""
            lbl_MSTATUS.BackColor = Color.Transparent
            lbl_MSTATUS.ForeColor = Color.Black
            cb_MOTIVONIVEL1.Enabled = False
            cb_MOTIVONIVEL1.SelectedIndex = -1
            cb_Usuarios.SelectedIndex = 0
            cb_Usuarios.Enabled = True
            bt_Login.Enabled = False
            bt_Logout.Enabled = False
            bt_RTOTAL.Enabled = False
            bt_ALTERARMOTIVO.Enabled = False
            gb_1.Enabled = False
            pb_MOTIVO_WARNING.Visible = False
            pb_OK.Visible = False
            bolLOGOUT = False
            tmr_MOTIVOS.Enabled = False
            tmr_BLINK.Enabled = False
            tmr_STOP.Enabled = False
            tmr_TEMPOPARADA.Enabled = False
            bol1stSTOP = False
        End If

    End Sub
    Private Sub tmr_STOP_Tick(sender As Object, e As EventArgs) Handles tmr_STOP.Tick

        Dim strStatus As String = Nothing
        Dim strMotivoId As String = Nothing
        Dim bolMotivoReg As Boolean = False
        Dim strMotivo As String = Nothing
        Dim strERROR As String = Nothing
        Dim bolAGUARDANDO As Boolean = False
        Dim bolFINALIZAR As Boolean = False

        tmr_STOP.Enabled = False
        If strMaquinaId >= 0 Then
            If CheckStatusMaquina(strMaquinaId, strStatus, strErro) = True Then

                If strStatus = "Produzindo" Then

                    bt_MAQUINA.Enabled = True
                    tmr_TEMPOPARADA.Enabled = False
                    tmr_BLINK.Enabled = False
                    lbl_MSTATUS.Text = "MÁQUINA EM PRODUÇÃO"
                    lbl_MSTATUS.BackColor = Color.Green
                    lbl_MSTATUS.ForeColor = Color.White
                    cb_MOTIVONIVEL1.Enabled = False
                    cb_MOTIVONIVEL2.Enabled = False
                    cb_MOTIVONIVEL3.Enabled = False
                    cb_MOTIVONIVEL3ID.Items.Clear()
                    cb_MOTIVONIVEL3.Items.Clear()
                    cb_MOTIVONIVEL2ID.Items.Clear()
                    cb_MOTIVONIVEL2.Items.Clear()
                    cb_MOTIVONIVEL1.SelectedIndex = -1
                    bt_RTOTAL.Enabled = False
                    bt_ALTERARMOTIVO.Enabled = False
                    lbl_HIPARADA.Text = ""
                    lbl_TTPARADA.Text = ""
                    lbl_HPPARADA.Text = ""
                    lbl_TPPARADA.Text = ""
                    tb_COMENTARIO.Text = ""
                    tb_COMENTARIO.Enabled = False
                    pb_OK.Visible = False
                    strMOTIVONIVEL1 = Nothing
                    strMOTIVONIVEL2 = Nothing
                    strMOTIVONIVEL3 = Nothing
                    bol1stREG = False
                    bol1stSTOP = False
                    bt_ALTERARMOTIVO.Enabled = False
                    bt_FINALIZAR.Enabled = False

                ElseIf strStatus = "NOperacional" Then

                    bt_MAQUINA.Enabled = True
                    tmr_TEMPOPARADA.Enabled = False
                    tmr_BLINK.Enabled = False
                    lbl_MSTATUS.Text = "FORA DE ESCALA DE PRODUÇÃO"
                    lbl_MSTATUS.BackColor = Color.White
                    lbl_MSTATUS.ForeColor = Color.Green
                    cb_MOTIVONIVEL1.Enabled = False
                    cb_MOTIVONIVEL1.SelectedIndex = -1
                    bt_RTOTAL.Enabled = False
                    bt_ALTERARMOTIVO.Enabled = False
                    lbl_HIPARADA.Text = ""
                    lbl_TTPARADA.Text = ""
                    lbl_HPPARADA.Text = ""
                    lbl_TPPARADA.Text = ""
                    bol1stSTOP = False
                    pb_OK.Visible = False
                    tb_COMENTARIO.Text = ""
                    tb_COMENTARIO.Enabled = False
                    strMOTIVONIVEL1 = Nothing
                    strMOTIVONIVEL2 = Nothing
                    strMOTIVONIVEL3 = Nothing
                    bol1stREG = False
                    bt_ALTERARMOTIVO.Enabled = False
                    bt_FINALIZAR.Enabled = False

                ElseIf strStatus = "Parada" Then

                    bt_MAQUINA.Enabled = False
                    If bol1stSTOP = False Then

                        bol1stSTOP = True
                        CheckMotivoRegistrado(strMaquinaId, strMotivoId, strMotivo, bolMotivoReg)
                        If bolMotivoReg = True Then
                            pb_OK.Visible = True
                            For intC = 0 To intMotivos - 1
                                If cb_MOTIVONIVEL1.Items(intC).ToString = strMotivo Then
                                    cb_MOTIVONIVEL1.SelectedIndex = intC
                                    Exit For
                                End If
                            Next
                            ReadDBGETMOTIVONIVEL2(strMaquinaId, cb_MOTIVONIVEL1ID.SelectedIndex, cb_MOTIVONIVEL2, cb_MOTIVONIVEL2ID)
                            ReadDBGETMOTIVONIVEL3(strMaquinaId, cb_MOTIVONIVEL2ID.SelectedIndex, cb_MOTIVONIVEL3, cb_MOTIVONIVEL3ID)
                            ReadDBGETCOMENTARIOS(strMaquinaId, tb_COMENTARIO)
                            strMOTIVONIVEL1 = cb_MOTIVONIVEL1ID.SelectedItem
                            strMOTIVONIVEL2 = cb_MOTIVONIVEL2ID.SelectedItem
                            strMOTIVONIVEL3 = cb_MOTIVONIVEL3ID.SelectedItem
                        Else
                            pb_OK.Visible = False
                        End If
                        tmr_BLINK.Enabled = True
                        cb_MOTIVONIVEL1.Enabled = True
                        GetHorarioParada(lbl_HIPARADA, strMaquinaId)
                        strDateTimeInicial = lbl_HIPARADA.Text
                        tmr_TEMPOPARADA.Enabled = True

                        If ReadDBGETSTATUS(strMaquinaId, bolAGUARDANDO, bolFINALIZAR, strERROR) = True Then

                            If bolAGUARDANDO = True Then
                                lbl_MSTATUS.Text = "MÁQUINA PARADA !"
                                lbl_MSTATUS.BackColor = Color.Red
                                lbl_MSTATUS.ForeColor = Color.Black
                                tmr_BLINK.Enabled = False
                            Else
                                lbl_MSTATUS.Text = "MÁQUINA PARADA !"
                                lbl_MSTATUS.BackColor = Color.Transparent
                                lbl_MSTATUS.ForeColor = Color.Black
                                tmr_BLINK.Enabled = True
                                If bolFINALIZAR = True Then
                                    bt_FINALIZAR.Enabled = True
                                Else
                                    bt_FINALIZAR.Enabled = False
                                End If
                            End If
                        End If

                    Else

                        CheckMotivoRegistrado(strMaquinaId, strMotivoId, strMotivo, bolMotivoReg)
                        If bolMotivoReg = False Then
                            If bol1stREG = False Then
                                bol1stREG = True
                                lbl_MSTATUS.Text = "MÁQUINA PARADA !"
                                lbl_MSTATUS.BackColor = Color.Red
                                lbl_MSTATUS.ForeColor = Color.White
                                tmr_BLINK.Enabled = True
                            End If
                        Else
                            If ReadDBGETSTATUS(strMaquinaId, bolAGUARDANDO, bolFINALIZAR, strERROR) = True Then

                                bt_ALTERARMOTIVO.Enabled = True
                                If bolAGUARDANDO = True Then
                                    lbl_MSTATUS.Text = "MÁQUINA PARADA !"
                                    lbl_MSTATUS.BackColor = Color.Red
                                    lbl_MSTATUS.ForeColor = Color.Black
                                    tmr_BLINK.Enabled = False
                                Else
                                    lbl_MSTATUS.BackColor = Color.Yellow
                                    lbl_MSTATUS.ForeColor = Color.Black
                                    tmr_BLINK.Enabled = False
                                    If bolFINALIZAR = True Then
                                        bt_FINALIZAR.Enabled = True
                                    Else
                                        bt_FINALIZAR.Enabled = False
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If
            End If
        End If
        tmr_STOP.Enabled = True

    End Sub
    Private Sub tmr_BLINK_Tick(sender As Object, e As EventArgs) Handles tmr_BLINK.Tick

        lbl_MSTATUS.Text = "MÁQUINA PARADA !"

        If lbl_MSTATUS.BackColor <> Color.Transparent Then
            lbl_MSTATUS.BackColor = Color.Transparent
            lbl_MSTATUS.ForeColor = Color.Black
        Else
            lbl_MSTATUS.BackColor = Color.Red
            lbl_MSTATUS.ForeColor = Color.White
        End If

    End Sub
    Private Sub bt_RTOTAL_Click(sender As Object, e As EventArgs) Handles bt_RTOTAL.Click

        Dim intResposta As Integer = 0
        Dim strMOTIVON2ID As Integer = Nothing
        Dim strMOTIVON2 As String = Nothing
        Dim strMOTIVON3ID As Integer = Nothing
        Dim strMOTIVON3 As String = Nothing

        If cb_MOTIVONIVEL3.SelectedIndex = -1 And cb_MOTIVONIVEL2.SelectedIndex >= 0 Then
            strMOTIVON2 = cb_MOTIVONIVEL2.SelectedItem
            strMOTIVON2ID = cb_MOTIVONIVEL2ID.SelectedItem
        ElseIf cb_MOTIVONIVEL3.SelectedIndex >= 0 And cb_MOTIVONIVEL2.SelectedIndex >= 0 Then
            strMOTIVON2 = cb_MOTIVONIVEL2.SelectedItem
            strMOTIVON2ID = cb_MOTIVONIVEL2ID.SelectedItem
            strMOTIVON3 = cb_MOTIVONIVEL3.SelectedItem
            strMOTIVON3ID = cb_MOTIVONIVEL3ID.SelectedItem
        End If

        If pb_OK.Visible = False Then

            intResposta = MessageBox.Show("Confirma Registro do Motivo = " & cb_MOTIVONIVEL1.Items(cb_MOTIVONIVEL1.SelectedIndex).ToString & "?", "Regtistro do Motivo de Pareada", MessageBoxButtons.YesNo)
            If intResposta = DialogResult.Yes Then
                strMOTIVONIVEL1 = cb_MOTIVONIVEL1ID.SelectedItem
                strMOTIVONIVEL2 = cb_MOTIVONIVEL2ID.SelectedItem
                strMOTIVONIVEL3 = cb_MOTIVONIVEL3ID.SelectedItem
                If UpdateMotivoParada(strMaquinaId, cb_MOTIVONIVEL1ID.SelectedItem,
                                      cb_MOTIVONIVEL1.SelectedItem, strMOTIVON2ID, strMOTIVON2, strMOTIVON3ID, strMOTIVON3,
                                      strUserId, tb_COMENTARIO.Text, strErro) = False Then
                    Beep()
                    MsgBox("Falha no registro do Motivo de Parada !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Registro Motivo Parada")
                Else
                    Beep()
                    MsgBox("Registro efetuado com sucesso !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registro Motivo Parada")
                    pb_OK.Visible = True
                End If
            End If

        Else

            If strMOTIVONIVEL1 = cb_MOTIVONIVEL1ID.SelectedItem And
               strMOTIVONIVEL2 = cb_MOTIVONIVEL2ID.SelectedItem And
               strMOTIVONIVEL3 = cb_MOTIVONIVEL3ID.SelectedItem Then
                Beep()
                MsgBox("Motivo JÁ REGISTRADO anteriormente!")
                Exit Sub
            End If
            intResposta = MessageBox.Show("Confirma NOVO REGISTRO de Parada para = " & cb_MOTIVONIVEL1.Items(cb_MOTIVONIVEL1.SelectedIndex).ToString & "?", "Regtistro do Motivo de Pareada", MessageBoxButtons.YesNo)
            If intResposta = DialogResult.Yes Then
                strMOTIVONIVEL1 = cb_MOTIVONIVEL1ID.SelectedItem
                strMOTIVONIVEL2 = cb_MOTIVONIVEL2ID.SelectedItem
                strMOTIVONIVEL3 = cb_MOTIVONIVEL3ID.SelectedItem
                If UpdateMotivoPARCIALParada(strMaquinaId, cb_MOTIVONIVEL1ID.Items(cb_MOTIVONIVEL1ID.SelectedIndex),
                                             cb_MOTIVONIVEL1.Items(cb_MOTIVONIVEL1.SelectedIndex), strMOTIVON2ID, strMOTIVON2, strMOTIVON3ID, strMOTIVON3,
                                             strUserId, tb_COMENTARIO.Text, strErro) = False Then
                    Beep()
                    MsgBox("Falha no salvamento de NOVO REGISTRO de Parada !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Registro Motivo PARCIAL Parada")
                Else
                    Beep()
                    MsgBox("Registro efetuado com sucesso !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registro Motivo PARCIAL Parada")
                    GetHorarioParada(lbl_HPPARADA, strMaquinaId)
                    strDateTimeParcial = lbl_HPPARADA.Text
                End If
            End If

        End If

    End Sub
    Private Sub cb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Usuarios.SelectedIndexChanged

        If cb_Usuarios.SelectedIndex > 0 Then
            bt_Login.Enabled = True
        Else
            bt_Login.Enabled = False
        End If

    End Sub
    Private Sub bt_RPARCIAL_Click(sender As Object, e As EventArgs) Handles bt_ALTERARMOTIVO.Click

        Dim intResposta As Integer = 0
        Dim strMOTIVON2ID As Integer = Nothing
        Dim strMOTIVON2 As String = Nothing
        Dim strMOTIVON3ID As Integer = Nothing
        Dim strMOTIVON3 As String = Nothing

        intResposta = MessageBox.Show("Confirma ATUALIZAÇÃO dos dados do Motivo de Parada?", "Atualizar Motivo de Pareada", MessageBoxButtons.YesNo)
        If intResposta = DialogResult.Yes Then
            If cb_MOTIVONIVEL3.SelectedIndex = -1 And cb_MOTIVONIVEL2.SelectedIndex >= 0 Then
                strMOTIVON2 = cb_MOTIVONIVEL2.Items(cb_MOTIVONIVEL2.SelectedIndex)
                strMOTIVON2ID = cb_MOTIVONIVEL2ID.Items(cb_MOTIVONIVEL2ID.SelectedIndex)
            ElseIf cb_MOTIVONIVEL3.SelectedIndex >= 0 And cb_MOTIVONIVEL2.SelectedIndex >= 0 Then
                strMOTIVON2 = cb_MOTIVONIVEL2.Items(cb_MOTIVONIVEL2.SelectedIndex)
                strMOTIVON2ID = cb_MOTIVONIVEL2ID.Items(cb_MOTIVONIVEL2ID.SelectedIndex)
                strMOTIVON3 = cb_MOTIVONIVEL3.Items(cb_MOTIVONIVEL3.SelectedIndex)
                strMOTIVON3ID = cb_MOTIVONIVEL3ID.Items(cb_MOTIVONIVEL3ID.SelectedIndex)
            End If
            strMOTIVONIVEL1 = cb_MOTIVONIVEL1ID.SelectedItem
            strMOTIVONIVEL2 = cb_MOTIVONIVEL2ID.SelectedItem
            strMOTIVONIVEL3 = cb_MOTIVONIVEL3ID.SelectedItem
            If UpdateMotivoParada(strMaquinaId, cb_MOTIVONIVEL1ID.Items(cb_MOTIVONIVEL1ID.SelectedIndex),
                                  cb_MOTIVONIVEL1.Items(cb_MOTIVONIVEL1.SelectedIndex), strMOTIVON2ID, strMOTIVON2, strMOTIVON3ID, strMOTIVON3,
                                  strUserId, tb_COMENTARIO.Text, strErro) = False Then
                Beep()
                MsgBox("Falha na ATUALIZAÇÃO dos dados do Motivo de Parada !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atualização Motivo Parada")
            Else
                Beep()
                MsgBox("Registro ATUALIZADO com sucesso !", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Registro Motivo PARCIAL Parada")
            End If
        End If

    End Sub
    Private Sub tmr_TEMPOPARADA_Tick(sender As Object, e As EventArgs) Handles tmr_TEMPOPARADA.Tick

        Dim dtT1 As DateTime
        Dim dtT2 As DateTime
        Dim dtNow As DateTime
        Dim intH1 As Integer = 0
        Dim intRM1 As Integer = 0
        Dim intM1 As Integer = 0
        Dim intH2 As Integer = 0
        Dim intM2 As Integer = 0
        Dim intRM2 As Integer = 0

        dtNow = Now()
        If lbl_HIPARADA.Text <> "" Then
            dtT1 = Convert.ToDateTime(lbl_HIPARADA.Text)
            intH1 = DateDiff(DateInterval.Hour, dtT1, dtNow)
            intM1 = DateDiff(DateInterval.Minute, dtT1, dtNow)
            intRM1 = intM1 - intH1 * 60
            lbl_TTPARADA.Text = intH1 & " hs. " & intRM1 & " min."
        Else
            lbl_TTPARADA.Text = ""
        End If
        If lbl_HPPARADA.Text <> "" Then
            dtT2 = Convert.ToDateTime(lbl_HPPARADA.Text)
            intH2 = DateDiff(DateInterval.Hour, dtT2, dtNow)
            intM2 = DateDiff(DateInterval.Minute, dtT2, dtNow)
            intRM2 = intM2 - intH2 * 60
            lbl_TPPARADA.Text = intH2 & " hs." & intRM2 & " min."
        Else
            lbl_TPPARADA.Text = ""
        End If

    End Sub
    Private Sub cb_Motivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL1.SelectedIndexChanged

        cb_MOTIVONIVEL1ID.SelectedIndex = cb_MOTIVONIVEL1.SelectedIndex
        tb_COMENTARIO.Text = ""
        tb_COMENTARIO.Enabled = True
        cb_MOTIVONIVEL2.Items.Clear()
        cb_MOTIVONIVEL3.Items.Clear()
        cb_MOTIVONIVEL2ID.Items.Clear()
        cb_MOTIVONIVEL3ID.Items.Clear()
        If cb_MOTIVONIVEL1.SelectedIndex >= 0 Then
            If ReadDBGETMOTIVOSNIVEL2(cb_MOTIVONIVEL1ID.Items(cb_MOTIVONIVEL1ID.SelectedIndex), cb_MOTIVONIVEL2, cb_MOTIVONIVEL2ID, strErro) = False Then
                Beep()
                MsgBox("Falha na Leitura do Motivo de Parada Nível 2!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Leitura Motivo Parada")
            Else
                If cb_MOTIVONIVEL2.Items.Count > 0 Then
                    cb_MOTIVONIVEL2.Enabled = True
                    bt_RTOTAL.Enabled = False
                Else
                    cb_MOTIVONIVEL2.Enabled = False
                    bt_RTOTAL.Enabled = True
                End If

            End If
        End If

    End Sub
    Private Sub tb_COMENTARIO_TextChanged(sender As Object, e As EventArgs) Handles tb_COMENTARIO.TextChanged

        lbl_RESTAM.Text = "Restam " & 1024 - tb_COMENTARIO.Text.Length & " Caracteres"

    End Sub
    Private Sub tmr_STATUS_Tick(sender As Object, e As EventArgs) Handles tmr_STATUS.Tick

        Dim strStatus As String = Nothing
        Dim bolConnected As Boolean = False
        Dim bolEmpty As Boolean = False
        Dim intCont As Integer = 0

        Try

            tmr_STATUS.Enabled = False
            If strMaquinaId >= 0 Then

                GetStatusComm(strMaquinaId, strStatus)
                If strStatus = "CommFail" Then
                    pb_DEVICE_GREEN.Visible = False
                    pb_DEVICE_GRAY2.Visible = True
                    tmr_BLINKDEVICE.Enabled = True
                ElseIf strStatus = "CommOk" Then
                    tmr_BLINKDEVICE.Enabled = False
                    pb_DEVICE_RED.Visible = False
                    pb_DEVICE_GRAY2.Visible = False
                    pb_DEVICE_GREEN.Visible = True
                ElseIf strStatus = "CommOFF" Then
                    tmr_BLINKDEVICE.Enabled = False
                    pb_DEVICE_RED.Visible = False
                    pb_DEVICE_GRAY2.Visible = True
                    pb_DEVICE_GREEN.Visible = False
                End If
                GetEmptyStop(strMaquinaId, bolEmpty)
                If bolEmpty = True Then
                    pb_MOTIVO_WARNING.Visible = True
                    bt_Logout.Enabled = False
                Else
                    pb_MOTIVO_WARNING.Visible = False
                    bt_Logout.Enabled = True
                End If
            Else
                tmr_BLINKDEVICE.Enabled = False
                pb_DEVICE_RED.Visible = False
                pb_DEVICE_GRAY2.Visible = True
                pb_DEVICE_GREEN.Visible = False
            End If
            If TestConnection(bolConnected, "sa", "@llexo2017A") = True Then
                If bolConnected = False Then
                    pb_DB_GRAY.Visible = False
                    pb_DB_RED.Visible = True
                    pb_DB_GREEN.Visible = False
                    tmr_BLINKDB.Enabled = True
                Else
                    pb_DB_GREEN.Visible = True
                    pb_DB_RED.Visible = False
                    pb_DB_GRAY.Visible = False
                    tmr_BLINKDB.Enabled = False
                End If
            End If
            bolEmpty = False
            tmr_STATUS.Enabled = True

        Catch ex As Exception

            tmr_STATUS.Enabled = True

        End Try

    End Sub
    Private Sub tmr_BLINKDEVICE_Tick(sender As Object, e As EventArgs) Handles tmr_BLINKDEVICE.Tick

        If pb_DEVICE_GRAY2.Visible = True Then
            pb_DEVICE_GRAY2.Visible = False
            pb_DEVICE_RED.Visible = True
        Else
            pb_DEVICE_GRAY2.Visible = True
            pb_DEVICE_RED.Visible = False
        End If

    End Sub
    Private Sub tmr_BLINKDB_Tick(sender As Object, e As EventArgs) Handles tmr_BLINKDB.Tick

        If pb_DB_GRAY.Visible = True Then
            pb_DB_GRAY.Visible = False
            pb_DB_RED.Visible = True
        Else
            pb_DB_GRAY.Visible = True
            pb_DB_RED.Visible = False
        End If

    End Sub
    Private Sub pb_MOTIVO_WARNING_Click(sender As Object, e As EventArgs) Handles pb_MOTIVO_WARNING.Click

        ' Abre tela para entrar com motivos esquecidos
        '/////////////////////////////////////////////
        Dim frm1 As New frm_MOTIVOS
        Me.Enabled = False
        tmr_MOTIVOS.Enabled = True
        frm1.Show()

    End Sub
    Private Sub tmr_MOTIVOS_Tick(sender As Object, e As EventArgs) Handles tmr_MOTIVOS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MControl_OEE.frm_MOTIVOS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MOTIVOS.Enabled = False
            Me.Enabled = True
        End If

    End Sub
    Private Sub pb_MOTIVO_WARNING_MouseMove(sender As Object, e As MouseEventArgs) Handles pb_MOTIVO_WARNING.MouseMove

        pb_MOTIVO_WARNING.Cursor = Cursors.Hand

    End Sub
    Private Sub pb_MOTIVO_WARNING_MouseLeave(sender As Object, e As EventArgs) Handles pb_MOTIVO_WARNING.MouseLeave

        pb_MOTIVO_WARNING.Cursor = Cursors.Arrow

    End Sub
    Private Sub tmr_ORDEM_Tick(sender As Object, e As EventArgs) Handles tmr_ORDEM.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MControl_OEE.frm_ORDEM" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_ORDEM.Enabled = False
            Me.Enabled = True
        End If

    End Sub
    Private Sub cb_MOTIVONIVEL2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL2.SelectedIndexChanged

        cb_MOTIVONIVEL2ID.SelectedIndex = cb_MOTIVONIVEL2.SelectedIndex
        bt_RTOTAL.Enabled = True
        tb_COMENTARIO.Text = ""
        tb_COMENTARIO.Enabled = True
        cb_MOTIVONIVEL3.Items.Clear()
        cb_MOTIVONIVEL3ID.Items.Clear()
        If cb_MOTIVONIVEL2.SelectedIndex >= 0 Then
            If ReadDBGETMOTIVOSNIVEL3(cb_MOTIVONIVEL2ID.Items(cb_MOTIVONIVEL2ID.SelectedIndex), cb_MOTIVONIVEL3, cb_MOTIVONIVEL3ID, strErro) = False Then
                Beep()
                MsgBox("Falha na Leitura do Motivo de Parada Nível 3!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Leitura Motivo Parada")
            Else
                If cb_MOTIVONIVEL3.Items.Count > 0 Then
                    cb_MOTIVONIVEL3.Enabled = True
                    bt_RTOTAL.Enabled = False
                Else
                    bt_RTOTAL.Enabled = True
                End If
            End If
        End If

    End Sub
    Private Sub cb_MOTIVONIVEL3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL3.SelectedIndexChanged

        cb_MOTIVONIVEL3ID.SelectedIndex = cb_MOTIVONIVEL3.SelectedIndex
        bt_RTOTAL.Enabled = True

    End Sub
    Private Sub frm_MAIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim intResposta As Integer = 0
        intResposta = MessageBox.Show("Confirma Saída do Aplicativo?", "Exit do Sistema", MessageBoxButtons.YesNo)
        If intResposta = DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub
    Private Sub bt_FINALIZAR_Click(sender As Object, e As EventArgs) Handles bt_FINALIZAR.Click

        Dim intResposta As Integer = 0

        intResposta = MessageBox.Show("Confirma FINALIZAÇÃO DA PARADA?", "Finalizar Parada", MessageBoxButtons.YesNo)
        If intResposta = DialogResult.Yes Then
            tmr_STOP.Enabled = False
            tmr_PARADAFINALIZADA.Enabled = True
            bt_FINALIZAR.Enabled = False
            bt_ALTERARMOTIVO.Enabled = False
            bt_RTOTAL.Enabled = False
            cb_MOTIVONIVEL1.SelectedIndex = -1
            cb_MOTIVONIVEL1.Enabled = False
            cb_MOTIVONIVEL2.Enabled = False
            cb_MOTIVONIVEL2ID.Items.Clear()
            cb_MOTIVONIVEL2.Items.Clear()
            cb_MOTIVONIVEL3.Enabled = False
            cb_MOTIVONIVEL3ID.Items.Clear()
            cb_MOTIVONIVEL3.Items.Clear()
        End If

    End Sub
    Private Sub tmr_PARADAFINALIZADA_Tick(sender As Object, e As EventArgs) Handles tmr_PARADAFINALIZADA.Tick

        Dim strStatus As String = Nothing

        lbl_MSTATUS.Text = "AGUARDANDO INÍCIO!"
        lbl_MSTATUS.BackColor = Color.White
        lbl_MSTATUS.ForeColor = Color.Black
        pb_OK.Visible = False

        tmr_PARADAFINALIZADA.Enabled = False
        If CheckStatusMaquina(strMaquinaId, strStatus, strErro) = True Then

            If strStatus = "Produzindo" Then
                intTEMPOPARADA = 0
                tmr_PARADAFINALIZADA.Enabled = False
                tmr_STOP.Enabled = True
                Exit Sub
            ElseIf strStatus = "NOperacional" Then
                intTEMPOPARADA = 0
                tmr_PARADAFINALIZADA.Enabled = False
                tmr_STOP.Enabled = True
                Exit Sub
            ElseIf strStatus = "Parada" Then
                intTEMPOPARADA += 1
                If intTEMPOPARADA > intTEMPOCONSIDERARPARADA Then
                    WriteDBFINALIZARTEMPOESGOTADO(strMaquinaId)
                    bol1stREG = False
                    bol1stSTOP = False
                    intTEMPOPARADA = 0
                    tmr_PARADAFINALIZADA.Enabled = False
                    tmr_STOP.Enabled = True
                    lbl_HPPARADA.Text = ""
                    lbl_TPPARADA.Text = ""
                    Exit Sub
                End If
            End If

        End If
        tmr_PARADAFINALIZADA.Enabled = True

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_MAQUINA.Click

        Dim frm1 As New frm_MAQUINA
        Me.Enabled = False
        tmr_MAQUINA.Enabled = True
        frm1.Show()

    End Sub
    Private Sub tmr_MAQUINA_Tick(sender As Object, e As EventArgs) Handles tmr_MAQUINA.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MControl_OEE.frm_MAQUINA" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MAQUINA.Enabled = False
            If bolSELECTED = True Then
                bolSELECTED = False
                tb_MAQUINA.Text = strMAQUINANAME
                tmr_STOP.Enabled = True
                cb_MOTIVONIVEL1.Items.Clear()
                cb_MOTIVONIVEL2.Items.Clear()
                cb_MOTIVONIVEL3.Items.Clear()
                cb_MOTIVONIVEL1ID.Items.Clear()
                cb_MOTIVONIVEL2ID.Items.Clear()
                cb_MOTIVONIVEL3ID.Items.Clear()
                If UpdateMotivos(cb_MOTIVONIVEL1, cb_MOTIVONIVEL1ID, strErro) = False Then
                    Beep()
                    MsgBox("Falha na Leitura dos Motivos de Parada", MsgBoxStyle.OkOnly, "Erro de Leitura de Tabela")
                Else
                    GetDeviceId(strMaquinaId, strDeviceId)
                    ReadDBGETTEMPOPARADA(strMaquinaId, intTEMPOCONSIDERARPARADA)
                End If
            End If
            Me.Enabled = True
        End If

    End Sub

End Class
