Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports System.Threading.Thread
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports System.Drawing
Imports System
Module Module1

    Public strAppDir As String = My.Application.Info.DirectoryPath
    Public strXMLDir As String = strAppDir & "\xml"
    Public strErrorDir As String = strAppDir & "\ErrorLog\"
    Public strDataSource As String = Nothing
    Public strMachines(999) As String
    Public strDescricao(999) As String
    Public strMotivosN1(999) As String
    Public strMotivosN2(999) As String
    Public strMotivosN3(999) As String
    Public intMachines As Integer = 0
    Public strErro As String = Nothing
    Public intMotivos As Integer = 0
    Public strUsers(999, 2) As String
    Public strLogin As String = Nothing
    Public strPassword As String = Nothing
    Public strUserId As String = Nothing
    Public bolLogged As Boolean = False
    Public bol1stSTOP As Boolean = False
    Public bol1stREG As Boolean = False
    Public strDateTimeInicial As String = Nothing
    Public strDateTimeParcial As String = Nothing
    Public strDeviceId As String = Nothing
    Public strMaquinaId As String = Nothing
    Public bolIni As Boolean = True
    Public bolEditing As Boolean = False
    Public bolSaving As Boolean = False
    Public intContMCONTROL As Integer = 0
    Public strMOTIVONIVEL1 As String = Nothing
    Public strMOTIVONIVEL2 As String = Nothing
    Public strMOTIVONIVEL3 As String = Nothing
    Public intTEMPOPARADA As Integer = 0
    Public intTEMPOCONSIDERARPARADA As Integer = 0
    Public strMAQUINANAME As String = Nothing
    Public bolSELECTED As Boolean = False
    Public Sub ErrorLog(ByVal str_TXT As String)

        Dim str_LogPATH,
            str_Date As String
        Dim file_LOG As System.IO.FileStream
        Dim stm_STREAM As StreamWriter

        Try

            'Escrita no arquivo TXY
            '//////////////////////;
            str_Date = DateTime.Now.ToString("yyyy.MM.dd")
            str_LogPATH = strErrorDir & Trim(str_Date) & ".log"
            str_TXT = Chr(13) & Chr(10) & Now() & " - " & str_TXT

            If File.Exists(str_LogPATH) Then
                file_LOG = New FileStream(str_LogPATH, FileMode.Append, FileAccess.Write)
                stm_STREAM = New StreamWriter(file_LOG)
                stm_STREAM.Write(str_TXT)
                stm_STREAM.Close()
            Else
                file_LOG = New FileStream(str_LogPATH, FileMode.Create, FileAccess.Write)
                stm_STREAM = New StreamWriter(file_LOG)
                stm_STREAM.Write(str_TXT)
                stm_STREAM.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Function ReadUsuarios(ByRef cbUsers As ComboBox,
                                 ByRef strUsersData(,) As String,
                                 ByRef strErro As String) As Boolean

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtUsers As New DataSet

        Try

            ReadUsuarios = False
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores] WHERE [Ativo] = 1 ORDER BY [Nome] ASC"
            Dim sqlaUsers As New SqlDataAdapter(strCommand, conSQL)
            sqlaUsers.Fill(dtUsers, "Users")
            If dtUsers.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtUsers.Tables(0).Rows.Count - 1
                    cbUsers.Items.Add(dtUsers.Tables(0).Rows(intC).Item("Nome"))
                    strUsersData(intC, 0) = dtUsers.Tables(0).Rows(intC).Item("Id")
                    strUsersData(intC, 1) = dtUsers.Tables(0).Rows(intC).Item("Login")
                    If IsDBNull(dtUsers.Tables(0).Rows(intC).Item("Senha")) = False Then
                        strUsersData(intC, 2) = dtUsers.Tables(0).Rows(intC).Item("Senha")
                    Else
                        strUsersData(intC, 2) = Nothing
                    End If
                Next
            End If
            conSQL.Close()
            ReadUsuarios = True

        Catch ex As Exception

            strErro = "Falha interna da função ReadUsuarios"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function ReadMachines(ByRef cbMAQUINAS As ComboBox,
                                 ByRef cbMAQUINASID As ComboBox,
                                 ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMAchines As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] WHERE [Ativo] = 1 ORDER BY [Descricao] ASC"
            Dim sqlaMachine As New SqlDataAdapter(strCommand, conSQL)
            sqlaMachine.Fill(dtMAchines, "Machine")
            If dtMAchines.Tables(0).Rows.Count > 0 Then
                intMachines = dtMAchines.Tables(0).Rows.Count
                For intC = 0 To dtMAchines.Tables(0).Rows.Count - 1
                    cbMAQUINAS.Items.Add(dtMAchines.Tables(0).Rows(intC).Item("Descricao"))
                    cbMAQUINASID.Items.Add(dtMAchines.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadMachines"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function UpdateMotivos(ByRef cbMOTIVOS As ComboBox,
                                  ByRef cbMOTIVOSID As ComboBox,
                                  ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [Ativo] = 1 ORDER BY [descricao] ASC"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            If dtMotivos.Tables(0).Rows.Count > 0 Then
                intMotivos = dtMotivos.Tables(0).Rows.Count
                For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                    cbMOTIVOS.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Descricao"))
                    cbMOTIVOSID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função UpdateMotivos"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function CheckStatusMaquina(ByRef strMachineId As String,
                                       ByRef strStatus As String,
                                       ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMachine As New DataSet

        Try

            CheckStatusMaquina = False
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & strMachineId
            Dim sqlaMachine As New SqlDataAdapter(strCommand, conSQL)
            sqlaMachine.Fill(dtMachine, "Users")
            If dtMachine.Tables(0).Rows.Count > 0 Then
                If dtMachine.Tables(0).Rows(0).Item("Produzindo") = True Then
                    strStatus = "Produzindo"
                ElseIf dtMachine.Tables(0).Rows(0).Item("Parada") = True Then
                    strStatus = "Parada"
                ElseIf dtMachine.Tables(0).Rows(0).Item("NOperacional") = True Then
                    strStatus = "NOperacional"
                End If

            End If
            conSQL.Close()
            CheckStatusMaquina = True

        Catch ex As Exception

            strErro = "Falha interna da função CheckStatusMaquina"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetHorarioParada(ByRef lblText As Label,
                                     ByVal strMachineId As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMachine As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOff] IS NULL AND [MachineID] = " & strMachineId & " ORDER BY [id] DESC"
            Dim sqlaMachine As New SqlDataAdapter(strCommand, conSQL)
            sqlaMachine.Fill(dtMachine, "Machines")
            If dtMachine.Tables(0).Rows.Count > 0 Then
                lblText.Text = dtMachine.Tables(0).Rows(0).Item("DateTimeOn")
            End If
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetHorarioParada"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function CheckMotivoRegistrado(ByVal strMachineId As String,
                                          ByRef strMotivoId As String,
                                          ByRef strMotivo As String,
                                          ByRef bolAlreadyRegistred As Boolean)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMachine As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOff] IS NULL AND [MotivoId] IS NOT NULL AND [MachineID] = " & strMachineId
            Dim sqlaMachine As New SqlDataAdapter(strCommand, conSQL)
            sqlaMachine.Fill(dtMachine, "Machines")
            If dtMachine.Tables(0).Rows.Count > 0 Then
                bolAlreadyRegistred = True
                strMotivo = dtMachine.Tables(0).Rows(0).Item("Motivo")
                strMotivoId = dtMachine.Tables(0).Rows(0).Item("MotivoId")
            Else
                bolAlreadyRegistred = False
                strMotivoId = 0
            End If
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetHorarioParada"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try


    End Function
    Public Function UpdateMotivoParada(ByVal strMACHINEID As String,
                                       ByVal intMOTIVONIVEL1ID As Integer,
                                       ByVal strMOTIVONIVEL1 As String,
                                       ByVal intMOTIVONIVEL2ID As Integer,
                                       ByVal strMOTIVONIVEL2 As String,
                                       ByVal intMOTIVONIVEL3ID As Integer,
                                       ByVal strMOTIVONIVEL3 As String,
                                       ByVal strUser As String,
                                       ByVal strComentarios As String,
                                       ByRef strErro As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [MotivoId] = " & intMOTIVONIVEL1ID & ", [Motivo] = '" & strMOTIVONIVEL1 & "', " &
                    " [motivonivel2] = " & intMOTIVONIVEL2ID & ", [MotivoN2] = '" & strMOTIVONIVEL2 & "', [motivonivel3] = " & intMOTIVONIVEL3ID & ", " &
                    " [MotivoN3] = '" & strMOTIVONIVEL3 & "', [UserId] = " & strUser & ", [Comentarios] = '" & strComentarios & "', [DateTimeMotivo] = GETDATE(), [ClosedBySystem] = 0 WHERE [DateTimeOff] IS NULL AND [MachineId] = " & strMACHINEID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função UpdateMotivoParada"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function UpdateMotivoPARCIALParada(ByVal strMachineId As String,
                                              ByVal intMOTIVONIVEL1ID As Integer,
                                              ByVal strMOTIVONIVEL1 As String,
                                              ByVal intMOTIVONIVEL2ID As Integer,
                                              ByVal strMOTIVONIVEL2 As String,
                                              ByVal intMOTIVONIVEL3ID As Integer,
                                              ByVal strMOTIVONIVEL3 As String,
                                              ByVal strUser As String,
                                              ByVal strComentarios As String,
                                              ByRef strErro As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [DateTimeOff] = GETDATE(), " &
                    "[ClosedBySystem] = 0 WHERE [DateTimeOff] Is NULL And [MachineId] = " & strMachineId
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_HistoricoParadas] ([MachineId],[DateTimeOn],[MotivoId],[Motivo],[motivonivel2],[MotivoN2],[motivonivel3]," &
                    "[MotivoN3],[UserId],[Comentarios],[DateTimeMotivo]) VALUES (" &
                    strMachineId & ", GETDATE(), " & intMOTIVONIVEL1ID & ", '" & strMOTIVONIVEL1 & "', " & intMOTIVONIVEL2ID & ", '" &
                    strMOTIVONIVEL2 & "', " & intMOTIVONIVEL3ID & ", '" & strMOTIVONIVEL3 & "', " & strUser & ", '" & strComentarios & "', GETDATE())"
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()

            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função UpdateMotivoPARCFIALParada"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function GetStatusComm(ByVal strDeviceId As String,
                                  ByRef strStatus As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevice As New DataSet
        Dim dtSystem As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            strCommand = "SELECT * FROM [dbo].[exe_sysCmdControl]"
            Dim sqlaSys As New SqlDataAdapter(strCommand, conSQL)
            sqlaSys.Fill(dtSystem, "System")
            If dtSystem.Tables(0).Rows(0).Item("Pooling") = True Then
                strCommand = "SELECT * FROM [dbo].[exe_deviceControl] WHERE [DeviceId] = " & strDeviceId
                Dim sqlaDevice As New SqlDataAdapter(strCommand, conSQL)
                sqlaDevice.Fill(dtDevice, "Device")
                If dtDevice.Tables(0).Rows.Count > 0 Then
                    If dtDevice.Tables(0).Rows(0).Item("CommFail") = True Then
                        strStatus = "CommFail"
                    Else
                        strStatus = "CommOk"
                    End If
                Else
                    strStatus = "CommOFF"
                End If
            Else
                strStatus = "CommOFF"
            End If
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetStatusComm"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetDeviceId(ByVal strMachineId As String,
                                ByRef strDeviceId As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevice As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & strMachineId
            Dim sqlaDevice As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevice.Fill(dtDevice, "Device")
            strDeviceId = dtDevice.Tables(0).Rows(0).Item("DeviceId")
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetDeviceId"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetEmptyStop(ByVal strMachineId As String,
                                 ByRef bolEmpty As Boolean)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivo As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " & strMachineId & " And [MotivoId] Is NULL And [DateTimeOff] Is Not NULL"
            Dim sqlaMotivo As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivo.Fill(dtMotivo, "Motivo")
            If dtMotivo.Tables(0).Rows.Count > 0 Then
                bolEmpty = True
            Else
                bolEmpty = False
            End If
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetEmptyStop"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetMotivosEmpty(ByVal strMachineId As String,
                                    ByRef cbMOTIVOSNIVEL1 As ComboBox,
                                    ByRef cbMOTIVOSNIVEL1ID As ComboBox,
                                    ByRef dgvMotivos As DevComponents.DotNetBar.Controls.DataGridViewX)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet
        Dim dateINI As DateTime = Nothing
        Dim dateFIM As DateTime = Nothing
        Dim decTempoParada As Decimal = 0D
        Dim intHORA As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] ORDER BY [descricao]"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            If dtMotivos.Tables(0).Rows.Count > 0 Then
                intMotivos = dtMotivos.Tables(0).Rows.Count
                For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                    cbMOTIVOSNIVEL1.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Descricao"))
                    cbMOTIVOSNIVEL1ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " &
                         strMachineId & " And [MotivoId] Is NULL And [DateTimeOff] Is Not NULL ORDER BY [DateTimeOn] ASC"
            Dim sqlaParada As New SqlDataAdapter(strCommand, conSQL)
            sqlaParada.Fill(dtParada, "Parada")
            If dtParada.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtParada.Tables(0).Rows.Count - 1
                    dgvMotivos.Rows.Add()
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(0).Value = dtParada.Tables(0).Rows(intC).Item("Id")
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(1).Value = Mid(dtParada.Tables(0).Rows(intC).Item("DateTimeOn"), 1, 10)
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(2).Value = Mid(dtParada.Tables(0).Rows(intC).Item("DateTimeOn"), 12, 8)
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(3).Value = Mid(dtParada.Tables(0).Rows(intC).Item("DateTimeOff"), 1, 10)
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(4).Value = Mid(dtParada.Tables(0).Rows(intC).Item("DateTimeOff"), 12, 8)
                    dateINI = Convert.ToDateTime(dtParada.Tables(0).Rows(intC).Item("DateTimeOn"))
                    dateFIM = Convert.ToDateTime(dtParada.Tables(0).Rows(intC).Item("DateTimeOff"))
                    decTempoParada = DateDiff(DateInterval.Second, dateIni, dateFim)
                    intHORA = Int(decTempoParada / 3600)
                    decFracionario = (decTempoParada / 3600) - intHORA
                    intMINUTO = Int((decFracionario * 3600) / 60)
                    intSEGUNDO = (((decFracionario * 3600) / 60) - intMINUTO) * 60
                    If intSEGUNDO = 60 Then
                        intSEGUNDO = 0
                        intMINUTO += 1
                        If intMINUTO = 60 Then
                            intMINUTO = 0
                            intHORA += 1
                        End If
                    End If
                    dgvMotivos.Rows(dgvMotivos.Rows.Count - 1).Cells(5).Value = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                Next
            End If
            conSQL.Close()

        Catch ex As Exception

            strErro = "Falha interna da função GetMotivosEmpty"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetMotivos2(ByVal intMOTIVONIVEL1 As Integer,
                                ByRef cbMOTIVONIVEL2 As ComboBox,
                                ByRef cbMOTIVONIVEL2ID As ComboBox)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet
        Dim intMOTIVONOVEL1 As Integer = 0
        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cbMOTIVONIVEL2.Items.Clear()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVONIVEL1 & " ORDER BY [descricao]"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                cbMOTIVONIVEL2.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                cbMOTIVONIVEL2ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("id"))
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função GetMotivos2"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function GetMotivos3(ByVal intMOTIVONIVEL2 As Integer,
                                ByRef cbMOTIVONIVEL3 As ComboBox,
                                ByRef cbMOTIVONIVEL3ID As ComboBox)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet
        Dim intMOTIVONOVEL1 As Integer = 0
        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cbMOTIVONIVEL3.Items.Clear()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intMOTIVONIVEL2 & " ORDER BY [descricao]"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                cbMOTIVONIVEL3.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                cbMOTIVONIVEL3ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("id"))
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função GetMotivos3"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function SaveMotivos(ByVal intPARADAID As Integer,
                                ByVal strMachineId As String,
                                ByVal strMOTIVONIVEL1 As String,
                                ByVal intMOTIVONIVEL1ID As Integer,
                                ByVal strMOTIVONIVEL2 As String,
                                ByVal intMOTIVONIVEL2ID As Integer,
                                ByVal strMOTIVONIVEL3 As String,
                                ByVal intMOTIVONIVEL3ID As Integer,
                                ByVal strCOMENTARIOS As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet
        Dim strMotivoId As String = Nothing
        Dim cmdUpdate As New SqlCommand
        Dim strN1 As String = Nothing
        Dim strN2 As String = Nothing
        Dim strN3 As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [Motivo] = '" & strMOTIVONIVEL1 &
                    "',  [MotivoId] =  " & intMOTIVONIVEL1ID & ", [MotivoN2] = '" & strMOTIVONIVEL2 &
                    "', [motivonivel2] = " & intMOTIVONIVEL2ID & ", [MotivoN3] = '" & strMOTIVONIVEL3 &
                    "', [motivonivel3] = " & intMOTIVONIVEL3ID & ", [UserId] = " & strUserId &
                    ", [Comentarios] = '" & UCase(strCOMENTARIOS) & "', [DateTimeMotivo] = GETDATE(), [ClosedBySystem] = 0 WHERE [Id] = " & intPARADAID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função SaveMotivos"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function InicioOrdemProducao(ByVal strMachineId As String,
                                        ByVal strOrdem As String,
                                        ByRef bolAlreadyExist As Boolean,
                                        ByRef strErro As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOrdem As New DataSet

        Try

            InicioOrdemProducao = False
            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Ordem] WHERE [Ordem] = " & strOrdem
            Dim sqlaOrdem As New SqlDataAdapter(strCommand, conSQL)
            sqlaOrdem.Fill(dtOrdem, "Ordem")
            If dtOrdem.Tables(0).Rows.Count > 0 Then
                bolAlreadyExist = True
                InicioOrdemProducao = True
                Exit Function
            Else
                bolAlreadyExist = False
                cmdUpdate.Connection = conSQL
                strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_Ordem] ([Ordem], [DataInicio], [MachineId]) VALUES ('" & strOrdem & "', GETDATE(), '" & strMachineId & "')"
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            End If
            conSQL.Close()
            InicioOrdemProducao = True

        Catch ex As Exception

            strErro = "Falha interna da função InicioOrdemProducao"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function FimOrdemProducao(ByVal strMachineId As String,
                                     ByVal strOrdem As String,
                                     ByRef bolNotFound As Boolean,
                                     ByRef strErro As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOrdem As New DataSet

        Try

            FimOrdemProducao = False
            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Ordem] WHERE [Ordem] = " & strOrdem
            Dim sqlaOrdem As New SqlDataAdapter(strCommand, conSQL)
            sqlaOrdem.Fill(dtOrdem, "Ordem")
            If dtOrdem.Tables(0).Rows.Count = 0 Then
                bolNotFound = True
                FimOrdemProducao = True
                Exit Function
            Else
                bolNotFound = False
                cmdUpdate.Connection = conSQL
                strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Ordem] SET [DataFim] = GETDATE() WHERE [Ordem] = '" & strOrdem & "' AND [MachineId] = '" & strMachineId & "' AND [DataFim] IS NULL"
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            End If
            conSQL.Close()
            FimOrdemProducao = True

        Catch ex As Exception

            strErro = "Falha interna da função FimOrdemProducao"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetEmptyOrdem(ByRef bolEmpty As Boolean,
                                  ByVal strMachineId As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet

        Try

            GetEmptyOrdem = False
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Ordem] WHERE [DataFim] IS NULL AND [MachineId] = " & strMachineId
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            If dtMotivos.Tables(0).Rows.Count > 1 Then
                bolEmpty = True
            Else
                bolEmpty = False
            End If
            conSQL.Close()
            GetEmptyOrdem = True

        Catch ex As Exception

            strErro = "Falha interna da função GetEmptyOrdem"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function GetOrdensEmpty(ByVal strMachineId As String,
                                   ByRef dgvORDEM As DevComponents.DotNetBar.Controls.DataGridViewX)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOrdem As New DataSet

        Try

            GetOrdensEmpty = False
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Ordem] WHERE [DataFim] IS NULL AND [MachineId] = " & strMachineId & " ORDER BY [DataInicio]"
            Dim sqlaOrdem As New SqlDataAdapter(strCommand, conSQL)
            sqlaOrdem.Fill(dtOrdem, "Ordem")
            If dtOrdem.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtOrdem.Tables(0).Rows.Count - 1
                    dgvORDEM.Rows.Add()
                    dgvORDEM.Rows(dgvORDEM.Rows.Count - 1).Cells(0).Value = dtOrdem.Tables(0).Rows(intC).Item("Id")
                    dgvORDEM.Rows(dgvORDEM.Rows.Count - 1).Cells(1).Value = dtOrdem.Tables(0).Rows(intC).Item("Ordem")
                    dgvORDEM.Rows(dgvORDEM.Rows.Count - 1).Cells(2).Value = dtOrdem.Tables(0).Rows(intC).Item("DataInicio")
                    dgvORDEM.Rows(dgvORDEM.Rows.Count - 1).Cells(3).Value = dtOrdem.Tables(0).Rows(intC).Item("DataFim")
                Next
            End If
            conSQL.Close()
            GetOrdensEmpty = True

        Catch ex As Exception

            strErro = "Falha interna da função GetOrdensEmpty"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function SaveOrdens(ByVal strMachineId As String,
                               ByRef dgvOrdens As DevComponents.DotNetBar.Controls.DataGridViewX)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParada As New DataSet
        Dim dtMotivos As New DataSet
        Dim strMotivoId As String = Nothing
        Dim cmdUpdate As New SqlCommand

        Try

            SaveOrdens = False
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvOrdens.Rows.Count - 1
                If dgvOrdens.Rows(intC).Cells(4).Value = "True" Then
                    bolEditing = True
                    dgvOrdens.Rows(intC).Cells(4).Value = False
                    strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Ordem] SET [DataFim] = '" & dgvOrdens.Rows(intC).Cells(3).Value & "' WHERE [Id] = " & dgvOrdens.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                End If
            Next
            bolEditing = False
            conSQL.Close()
            SaveOrdens = True

        Catch ex As Exception

            strErro = "Falha interna da função SaveOrdens"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL2(ByVal intMOTIVOID As Integer,
                                           ByRef cbMOTINONIVEL2 As ComboBox,
                                           ByRef cbMOTIVONIVEL2ID As ComboBox,
                                           ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVOID & " ORDER BY [descricao] ASC"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            If dtMotivos.Tables(0).Rows.Count > 0 Then
                intMotivos = dtMotivos.Tables(0).Rows.Count
                For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                    cbMOTINONIVEL2.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                    cbMOTIVONIVEL2ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMOTIVOSNIVEL2"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL3(ByVal intMOTIVOIDNIVEL2 As Integer,
                                           ByRef cbMOTINONIVEL3 As ComboBox,
                                           ByRef cbMOTIVONIVEL3ID As ComboBox,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intMOTIVOIDNIVEL2 & " ORDER BY [descricao] ASC"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            If dtMotivos.Tables(0).Rows.Count > 0 Then
                intMotivos = dtMotivos.Tables(0).Rows.Count
                For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                    cbMOTINONIVEL3.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                    cbMOTIVONIVEL3ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMOTIVOSNIVEL3"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try


    End Function
    Public Function ReadDBGETMOTIVONIVEL2(ByVal intMACHINEID As Integer,
                                          ByVal intMOTIVONIVEL1 As Integer,
                                          ByRef cbMOTIVONIVEL2 As ComboBox,
                                          ByVal cbMOTIVONIVEL2ID As ComboBox)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet
        Dim dtsPARADA As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOff] IS NULL AND [motivonivel2] IS NOT NULL AND [MachineID] = " & intMACHINEID
            Dim sqldaPARADA As New SqlDataAdapter(strCommand, conSQL)
            dtsPARADA = New DataSet
            sqldaPARADA.Fill(dtsPARADA, "Parada")
            If dtsPARADA.Tables(0).Rows.Count > 0 Then
                For intC = 0 To cbMOTIVONIVEL2ID.Items.Count - 1
                    If cbMOTIVONIVEL2ID.Items(intC) = dtsPARADA.Tables(0).Rows(0).Item("motivonivel2") Then
                        cbMOTIVONIVEL2.SelectedIndex = intC
                        Exit For
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMOTIVONIVEL2"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVONIVEL3(ByVal intMACHINEID As Integer,
                                          ByVal intMOTIVONIVEL2 As Integer,
                                          ByRef cbMOTIVONIVEL3 As ComboBox,
                                          ByVal cbMOTIVONIVEL3ID As ComboBox)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet
        Dim dtsPARADA As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOff] IS NULL AND [motivonivel3] IS NOT NULL AND [MachineID] = " & intMACHINEID
            Dim sqldaPARADA As New SqlDataAdapter(strCommand, conSQL)
            dtsPARADA = New DataSet
            sqldaPARADA.Fill(dtsPARADA, "Parada")
            If dtsPARADA.Tables(0).Rows.Count > 0 Then
                For intC = 0 To cbMOTIVONIVEL3ID.Items.Count - 1
                    If cbMOTIVONIVEL3ID.Items(intC) = dtsPARADA.Tables(0).Rows(0).Item("motivonivel3") Then
                        cbMOTIVONIVEL3.SelectedIndex = intC
                        Exit For
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMOTIVONIVEL3"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETSTATUS(ByVal intMACHINEID As Integer,
                                    ByRef bolAGUARDANDO As Boolean,
                                    ByRef bolFINALIZAR As Boolean,
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
        Dim sqldaFINALIZAR As SqlDataAdapter
        Dim dtsFINALIZAR As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & intMACHINEID
            Dim sqlaMAQUINAS As New SqlDataAdapter(strCommand, conSQL)
            sqlaMAQUINAS.Fill(dtMAQUINAS, "Maquinas")
            If dtMAQUINAS.Tables(0).Rows(0).Item("Parada") = True Then
                strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " &
                              intMACHINEID & " AND [DateTimeOff] IS NULL"
                Dim sqlaPARADA As New SqlDataAdapter(strCommand, conSQL)
                sqlaPARADA.Fill(dtPARADA, "Parada")
                If IsDBNull(dtPARADA.Tables(0).Rows(0).Item("MotivoId")) = False Then

                    'Aguardando Manutenção
                    '/////////////////////
                    strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_aguardandomanutencao]"
                    Dim sqlaMOTIVOESPERA As New SqlDataAdapter(strCommand, conSQL)
                    sqlaMOTIVOESPERA.Fill(dtMOTIVOESPERA, "MotivoEspera")
                    For intC = 0 To dtMOTIVOESPERA.Tables(0).Rows.Count - 1
                        If dtMOTIVOESPERA.Tables(0).Rows(intC).Item("motivoid") = dtPARADA.Tables(0).Rows(0).Item("MotivoId") Then
                            bolAGUARDANDO = True
                            Exit For
                        End If
                    Next

                    'Motivo para Ativa botão Finalizar Parada
                    '/////////////////////////////////////////
                    strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_fechamentoparada]"
                    sqldaFINALIZAR = New SqlDataAdapter(strCommand, conSQL)
                    dtsFINALIZAR = New DataSet
                    sqldaFINALIZAR.Fill(dtsFINALIZAR, "Finalizar")
                    For intC = 0 To dtsFINALIZAR.Tables(0).Rows.Count - 1
                        If dtsFINALIZAR.Tables(0).Rows(intC).Item("motivoid") = dtPARADA.Tables(0).Rows(0).Item("MotivoId") Then
                            bolFINALIZAR = True
                            Exit For
                        End If
                    Next

                End If
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
    Public Function ReadDBGETCOMENTARIOS(ByVal intMACHINEID As Integer,
                                         ByRef tbCOMENTARIOS As TextBox)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMotivos As New DataSet
        Dim dtsPARADA As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOff] IS NULL AND [motivonivel2] IS NOT NULL AND [MachineID] = " & intMACHINEID
            Dim sqldaPARADA As New SqlDataAdapter(strCommand, conSQL)
            dtsPARADA = New DataSet
            sqldaPARADA.Fill(dtsPARADA, "Parada")
            If dtsPARADA.Tables(0).Rows.Count > 0 Then
                tbCOMENTARIOS.Text = dtsPARADA.Tables(0).Rows(0).Item("Comentarios")
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETCOMENTARIOS"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBFINALIZARTEMPOESGOTADO(ByVal intMACHINEID As Integer)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [DateTimeOff] = GETDATE(), " &
                    "[ClosedBySystem] = 0 WHERE [DateTimeOff] Is NULL And [MachineId] = " & intMACHINEID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_HistoricoParadas] ([MachineId],[DateTimeOn]) VALUES (" &
                    intMACHINEID & ", GETDATE())"
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()

            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função WriteDBFINALIZARTEMPOESGOTADO"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTEMPOPARADA(ByVal intMACHINEID As Integer,
                                         ByRef intTEMPOPARADA As Integer)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMAchines As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & intMACHINEID
            Dim sqlaMachine As New SqlDataAdapter(strCommand, conSQL)
            sqlaMachine.Fill(dtMAchines, "Machine")
            If dtMAchines.Tables(0).Rows.Count > 0 Then
                intTEMPOPARADA = dtMAchines.Tables(0).Rows(0).Item("TimetoOn")
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETTEMPOPARADA"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#Region "CONEXÃO AO BANCO DE DADOS"

    Public Function xmlGetDataSource(ByRef strDataSource As String)

        Dim xmlFile As New XmlDocument
        Dim xmlNodeX As XmlNode
        Dim strErro As String = Nothing

        xmlGetDataSource = False
        Try

            'Verifica se o diretório dos arquivos XML existe
            '-----------------------------------------------
            If My.Computer.FileSystem.DirectoryExists(strXMLDir) = False Then
                strErro = "<b>Diretório do sistema</b> de arquivos xml não encontrado!"
                ErrorLog(strErro)
                Exit Function
            End If

            'Verifica a existência do arquivo de configuração
            '------------------------------------------------
            If IO.File.Exists(strXMLDir & "\DBDataSource.xml") = False Then
                strErro = "Arquivo DBDataSource.xml não encontrado!"
                ErrorLog(strErro)
                Exit Function
            End If

            'Acessa arquivo xml de configuração
            '----------------------------------
            xmlFile.Load(strXMLDir & "\" & "DBDataSource.xml")
            xmlNodeX = xmlFile.SelectSingleNode("DataSource")
            strDataSource = xmlNodeX.ChildNodes(0).Attributes.GetNamedItem("Name").Value
            xmlGetDataSource = True

        Catch ex As Exception

            strErro = "Falha interna da função MControl_OEE.Module1"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function
    Public Function TestConnection(ByRef bolConnected As Boolean,
                                   ByVal strUser As String,
                                   ByVal strPassword As String)

        Dim strConn As String
        Dim strErro As String
        Dim conSQL As SqlConnection

        Try

            TestConnection = False
            strConn = "Data Source=" & strDataSource & ";User ID=" & strUser & ";Password=" & strPassword
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            If conSQL.State = ConnectionState.Open Then
                bolConnected = True
            Else
                bolConnected = False
            End If
            conSQL.Close()
            TestConnection = True

        Catch ex As Exception

            bolConnected = False
            strErro = "Falha interna da função MCOntrol_OEE.TestConnection"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Function

#End Region

#Region "LOGIN DE OPERADOR"
    Public Function WriteDBUPDATESENHA(ByVal intUSERID As Integer,
                                       ByVal strPASSWORD As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Operadores] SET [Senha] = '" & strPASSWORD & "' WHERE [id] = " & intUSERID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função WriteDBUPDATESENHA"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

End Module

