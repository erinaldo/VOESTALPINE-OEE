Imports System.Data.SqlClient
Public Class frm_ONLINE

    Private intBABELFISHID As Integer
    Private intMAQUINAID As Integer
    Private strREFERENCIA As String
    Private colorLABEL As Color
    Private bolBLK1st As Boolean = False
    Private Sub frm_ONLINE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        intBABELFISHID = intMACHINEID
        If ReadDBGETMAQUINANAME(intBABELFISHID, intMAQUINAID, lb_MAQUINA.Text, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            tmr_ONLINE.Enabled = True
        End If

    End Sub
    Private Function ReadDBGETMAQUINANAME(ByVal intBABELID As Integer,
                                          ByRef intMAQUINA_ID As Integer,
                                          ByRef strMAQUINANAME As String,
                                          ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtMAQUINAS As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = "SELECT exe_MCONTROL_OEE_Maquinas.Id AS maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                                   "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices ON exe_MCONTROL_OEE_Maquinas.Id = " &
                                   "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences ON " &
                                   "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                                   "exe_MCONTROL_OEE_Maquinas.Ativo = 1 AND exe_MCONTROL_BABELFISH_idreferences.babelfish_id = " & intBABELID

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaMAQUINAS As New SqlDataAdapter(strCommand, conSQL)
            sqlaMAQUINAS.Fill(dtMAQUINAS, "Maquinas")
            intMAQUINA_ID = dtMAQUINAS.Tables(0).Rows(0).Item("maquinaid")
            strMAQUINANAME = dtMAQUINAS.Tables(0).Rows(0).Item("descricao")
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMAQUINANAME"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Private Sub tmr_ONLINE_Tick(sender As Object, e As EventArgs) Handles tmr_ONLINE.Tick

        Dim bolPARADA As Boolean = False
        Dim bolAGUARDANDO As Boolean = False
        Dim bolNOESCALA As Boolean = False
        Dim bolNOMOTIVO As Boolean = False
        Dim bolCOMMOK As Boolean = False
        Dim bolNOSTATUS As Boolean = False
        Dim bolPRODUZINDO As Boolean = False

        tmr_ONLINE.Enabled = False
        If ReadDBGETCOMMSTATUS(intBABELFISHID, bolCOMMOK, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If bolCOMMOK = True Then

                If ReadDBGETSTATUS(intMAQUINAID, lb_STATUS.Text, bolPARADA, bolAGUARDANDO, bolNOMOTIVO, bolNOESCALA, bolNOSTATUS, bolPRODUZINDO,
                                   lb_TEMPO.Text, lb_MOTIVO.Text, lbl_MOTIVO2.Text, lbl_MOTIVO3.Text, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolPRODUZINDO = True Then
                        bolBLK1st = False
                        colorLABEL = Color.Green
                        lb_STATUS.ForeColor = Color.White
                        lb_TEMPO.Text = Nothing
                        lb_MOTIVO.Text = Nothing
                        tmr_BLINK.Enabled = False
                        If ReadDBGETOPPRODUTO(lb_OP.Text, lb_PRODUTO.Text, strERROR) = False Then
                            Alert(strERROR, 5)
                        Else
                            If ReadDBGETITEM(lb_OP.Text, lbl_ITEM.Text, strERROR) = False Then
                                Alert(strERROR, 5)
                            End If
                        End If
                    ElseIf bolNOESCALA = True Then
                        'FORA DE ESCALA
                        '//////////////
                        bolBLK1st = False
                        colorLABEL = Color.Gray
                        lb_STATUS.ForeColor = Color.Black
                        tmr_BLINK.Enabled = False
                        lb_OP.Text = Nothing
                        lb_PRODUTO.Text = Nothing
                    ElseIf bolPARADA = True And bolNOMOTIVO = False And bolAGUARDANDO = True Then
                        'AGUARDANDO MANUTENÇÃO
                        '/////////////////////
                        bolBLK1st = False
                        colorLABEL = Color.Red
                        lb_STATUS.ForeColor = Color.Black
                        tmr_BLINK.Enabled = False
                        If ReadDBGETOPPRODUTO(lb_OP.Text, lb_PRODUTO.Text, strERROR) = False Then
                            Alert(strERROR, 5)
                        Else
                            If ReadDBGETITEM(lb_OP.Text, lbl_ITEM.Text, strERROR) = False Then
                                Alert(strERROR, 5)
                            End If
                        End If
                    ElseIf bolPARADA = True And bolNOMOTIVO = False And bolAGUARDANDO = False Then
                        'AGUARDANDO MANUTENÇÃO
                        '/////////////////////
                        bolBLK1st = False
                        colorLABEL = Color.Yellow
                        lb_STATUS.ForeColor = Color.Black
                        tmr_BLINK.Enabled = False
                    ElseIf bolPARADA = True And bolNOMOTIVO = True Then
                        'PARADA SEM MOTIVO REGISTRADO
                        '////////////////////////////
                        colorLABEL = Color.Red
                        lb_STATUS.ForeColor = Color.Black
                        If bolBLK1st = False Then
                            bolBLK1st = True
                            tmr_BLINK.Enabled = True
                        End If
                        If ReadDBGETOPPRODUTO(lb_OP.Text, lb_PRODUTO.Text, strERROR) = False Then
                            Alert(strERROR, 5)
                        Else
                            If ReadDBGETITEM(lb_OP.Text, lbl_ITEM.Text, strERROR) = False Then
                                Alert(strERROR, 5)
                            End If
                        End If
                    ElseIf bolNOSTATUS = True Then
                        bolBLK1st = False
                        colorLABEL = Color.Transparent
                        lb_STATUS.ForeColor = Color.Black
                        lb_TEMPO.Text = Nothing
                        lb_MOTIVO.Text = Nothing
                        lb_OP.Text = Nothing
                        lb_PRODUTO.Text = Nothing
                        tmr_BLINK.Enabled = False
                    End If
                End If
            Else

                'Falha de Comunicação com o BABEL FISH
                '/////////////////////////////////////
                bolBLK1st = False
                lb_TEMPO.Text = Nothing
                lb_MOTIVO.Text = Nothing
                lb_OP.Text = Nothing
                lb_PRODUTO.Text = Nothing
                colorLABEL = Color.Black
                lb_STATUS.ForeColor = Color.White
                lb_STATUS.Text = "FALHA LINK BABEL FISH"

            End If
        End If
        lb_STATUS.BackColor = colorLABEL
        tmr_ONLINE.Enabled = True

    End Sub
    Private Function ReadDBGETOPPRODUTO(ByRef strOP As String,
                                        ByRef strPRODUTO As String,
                                        ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtOP As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_opstatus] WHERE [machineid] = " & intBABELFISHID &
                                   " AND [endofop] = 0 ORDER BY [id] DESC"

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaOP As New SqlDataAdapter(strCommand, conSQL)
            sqlaOP.Fill(dtOP, "OP")
            If dtOP.Tables(0).Rows.Count > 0 Then
                strOP = dtOP.Tables(0).Rows(0).Item("opnumber")
                strPRODUTO = UCase(dtOP.Tables(0).Rows(0).Item("description"))
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETOPPRODUTO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Private Function ReadDBGETITEM(ByRef strOP As String,
                                   ByRef strITEM As String,
                                   ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtITEM As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_opstatus] WHERE [machineid] = " & intBABELFISHID &
                                   " AND CAST([opnumber] AS INT) = " & Val(strOP) & " ORDER BY [data_hora_inicio] DESC"

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaITEM As New SqlDataAdapter(strCommand, conSQL)
            sqlaITEM.Fill(dtITEM, "Item")
            If dtITEM.Tables(0).Rows.Count > 0 Then
                If dtITEM.Tables(0).Rows(0).Item("itemstatus") = 1 Then
                    strITEM = dtITEM.Tables(0).Rows(0).Item("item_ordem")
                Else
                    strITEM = ""
                End If
            Else
                strITEM = ""
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETITEM"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Private Function ReadDBGETSTATUS(ByVal intMACHINEID As Integer,
                                     ByRef strSTATUS As String,
                                     ByRef bolPARADA As Boolean,
                                     ByRef bolAGUARDANDO As Boolean,
                                     ByRef bolNOMOTIVO As Boolean,
                                     ByRef bolNOESCALA As Boolean,
                                     ByRef bolNOSTATUS As Boolean,
                                     ByRef bolPRODUZINDO As Boolean,
                                     ByRef strTEMPO As String,
                                     ByRef strMOTIVO As String,
                                     ByRef strMOTIVO2 As String,
                                     ByRef strMOTIVO3 As String,
                                     ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtMAQUINAS As New DataSet
        Dim dtPARADA As New DataSet
        Dim dtMOTIVOESPERA As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = Nothing
        Dim intMOTIVOPARADA As Integer = 0
        Dim dtimePARADA As DateTime = Nothing
        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intRMINUTO As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & intMACHINEID
            Dim sqlaMAQUINAS As New SqlDataAdapter(strCommand, conSQL)
            sqlaMAQUINAS.Fill(dtMAQUINAS, "Maquinas")
            If dtMAQUINAS.Tables(0).Rows(0).Item("Produzindo") = True Then
                strMOTIVO = Nothing
                strTEMPO = Nothing
                strSTATUS = "MÁQUINA EM PRODUÇÃO"
                bolPRODUZINDO = True
            ElseIf dtMAQUINAS.Tables(0).Rows(0).Item("Parada") = True Then
                strSTATUS = "MÁQUINA PARADA"
                bolPARADA = True
                strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " &
                              intMACHINEID & " AND [DateTimeOff] IS NULL"
                Dim sqlaPARADA As New SqlDataAdapter(strCommand, conSQL)
                sqlaPARADA.Fill(dtPARADA, "Parada")
                If IsDBNull(dtPARADA.Tables(0).Rows(0).Item("MotivoId")) = False Then
                    strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_aguardandomanutencao]"
                    Dim sqlaMOTIVOESPERA As New SqlDataAdapter(strCommand, conSQL)
                    sqlaMOTIVOESPERA.Fill(dtMOTIVOESPERA, "MotivoEspera")
                    strMOTIVO = UCase(dtPARADA.Tables(0).Rows(0).Item("Motivo"))
                    If IsDBNull(dtPARADA.Tables(0).Rows(0).Item("MotivoN2")) = False Then
                        strMOTIVO2 = UCase(dtPARADA.Tables(0).Rows(0).Item("MotivoN2"))
                    End If
                    If IsDBNull(dtPARADA.Tables(0).Rows(0).Item("MotivoN3")) = False Then
                        strMOTIVO3 = UCase(dtPARADA.Tables(0).Rows(0).Item("MotivoN3"))
                    End If
                    For intC = 0 To dtMOTIVOESPERA.Tables(0).Rows.Count - 1
                        If dtMOTIVOESPERA.Tables(0).Rows(intC).Item("motivoid") = dtPARADA.Tables(0).Rows(0).Item("MotivoId") Then
                            bolAGUARDANDO = True
                            Exit For
                        End If
                    Next
                Else
                    bolNOMOTIVO = True
                    strMOTIVO = Nothing
                    strMOTIVO2 = Nothing
                    strMOTIVO3 = Nothing
                End If
                dtimePARADA = Convert.ToDateTime(dtPARADA.Tables(0).Rows(0).Item("DateTimeOn"))
                intHORA = DateDiff(DateInterval.Hour, dtimePARADA, Now())
                intMINUTO = DateDiff(DateInterval.Minute, dtimePARADA, Now())
                intRMINUTO = intMINUTO - (intHORA * 60)
                strTEMPO = intHORA & " hs. " & intRMINUTO & " min."
            ElseIf dtMAQUINAS.Tables(0).Rows(0).Item("NOperacional") = True Then
                strMOTIVO = Nothing
                strMOTIVO2 = Nothing
                strMOTIVO3 = Nothing
                strTEMPO = Nothing
                strSTATUS = "FORA DE ESCALA DE PRODUÇÃO"
                bolNOESCALA = True
            Else
                strMOTIVO = Nothing
                strMOTIVO2 = Nothing
                strMOTIVO3 = Nothing
                strTEMPO = Nothing
                strSTATUS = "AGUARDE ..."
                bolNOESCALA = False
                bolNOSTATUS = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETSTATUS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Private Sub tmr_BLINK_Tick(sender As Object, e As EventArgs) Handles tmr_BLINK.Tick

        If colorLABEL <> Color.Green Or colorLABEL <> Color.Gray Then
            If lb_STATUS.BackColor = Color.Transparent Then
                lb_STATUS.BackColor = colorLABEL
                lb_STATUS.ForeColor = Color.White
            Else
                lb_STATUS.BackColor = Color.Transparent
                lb_STATUS.ForeColor = Color.Black
            End If
        Else
            lb_STATUS.BackColor = Color.Green
        End If

    End Sub
    Private Function ReadDBGETCOMMSTATUS(ByVal intBABELID As Integer,
                                         ByRef bolCOMMOK As Boolean,
                                         ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtCOMM As New DataSet
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT exe_deviceControl.CommFail FROM exe_MCONTROL_BABELFISH_idreferences LEFT JOIN " &
                       "exe_deviceControl ON exe_MCONTROL_BABELFISH_idreferences.device_id = exe_deviceControl.DeviceId " &
                       "WHERE exe_MCONTROL_BABELFISH_idreferences.babelfish_id = " & intBABELID
            Dim sqlaCOMM As New SqlDataAdapter(strQUERY, conSQL)
            sqlaCOMM.Fill(dtCOMM, "Comunicacao")
            If dtCOMM.Tables(0).Rows(0).Item("CommFail") = True Then
                bolCOMMOK = False
            Else
                bolCOMMOK = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETCOMMSTATUS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

End Class