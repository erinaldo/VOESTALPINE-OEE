Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Threading
Imports DevComponents.DotNetBar.Charts
Module mod_OEE

    'IDENTIFICAÇÃO DE VERSÃ0
    '////////////////////////
    Public strViewerVersion As String = "1.9.3"
    Public strAppRevision As String = "1.06.2521"
    Private strAppDir As String = My.Application.Info.DirectoryPath
    Private strErrorDir As String = strAppDir & "\applog\"
    Private strXMLDir As String = strAppDir & "\xml\"
    Public imgMFiles As New clsMCONTROL_OEE_img.clsMCONTROL_OEE_img
    Public strERROR As String = Nothing
    Public strDataSource As String = Nothing
    Public intDEVICEID As Integer = 0
    Public bolFRMINI As Boolean = True
    Public bolDEVICECHANGED As Boolean = False
    Public intMACHINEROWINDEX As Integer = 0
    Public strMACHINEREFNAME As String = Nothing
    Public intMACHINEID As Integer = 0
    Public strSELECTEDVARIABLE As String = Nothing
    Public bolSELECTEDVARIABLE As Boolean = False
    Public strVARIABLE As String = 0
    Public strDEVICEREF As String = Nothing
    Public strORIENTACAO As String = Nothing
    Public bolORIENTACAO As Boolean = False
    Public bolESCALACONFIRMED As Boolean = False
    Public strESCALAINICIAL As String = Nothing
    Public strESCALAFINAL As String = Nothing
    Public bolEDITARPARADAS As Boolean = False
    Public intPARADAID As Integer = 0
    Public bolADDPARADA As Boolean = False
    Public strGROUP As String = Nothing
    Public strUSERNAME As String
    Public intUSERID As Integer
    Public strAPPVERSION As String = Nothing
    Public bolPARADAEDITADA As Boolean = False

    'Relatório de Paradas
    '/////////////////////
    Public reportDATAINICIAL As String = Nothing
    Public reportDATAFINAL As String = Nothing
    Public reportMAQUINA As String = Nothing
    Public reportOP As String = Nothing
    Public bolREPORTOK As Boolean = False
    Public reportTOTALTIME As String = Nothing

    'Relatório Produtividade
    '///////////////////////
    Public reportTONELAGEM As Decimal = 0D
    Public reportMETROS As Decimal = 0D
    Public reportHORASDISPONIVEL As Integer = 0
    Public sreportHORASDISPONIVEL As String
    Public reportHORASPARADA As Integer = 0
    Public sreportHORASPARADA As String
    Public reportHORASTEMPOUTIL As Integer = 0
    Public sreportHORASTEMPOUTIL As String
    Public reportHORASSETUP As Integer = 0
    Public sreportHORASSETUP As String
    Public reportHORASPARADAPERCENTUAL As Decimal = 0D
    Public reportHORASTEMPOUTILPERCENTUAL As Decimal = 0D
    Public reportHORASSETUPPERCENTUAL As Decimal = 0D
    Public reportHORASTESTE As Integer = 0
    Public sreportHORASTESTE As String
    Public reportHORASTESTEPERCENTUAL As Decimal = 0D
    Public reportMTBF As Decimal = 0D
    Public sreportMTBF As String
    Public reportMTTR As Decimal = 0D
    Public reportMTAM As Integer = 0
    Public sreportMTAM As String
    Public sreportMTTR As String
    Public reportDISPONIBILIDADE As Decimal = 0D
    Public reportRELATORIONOME As String = Nothing
    Public bolRELATORIOLIVRE As Boolean = False

    'Relatório de Apontamento
    '/////////////////////////
    Public reportDIASUTEIS As String = Nothing
    Public reportTOTALDIASUTEIS As String = Nothing

    'Relatório de Manuntenção
    '////////////////////////
    Public bolMANUTENCAOGRUPO As Boolean = False

    'Excel
    '/////
    Private strEXPORT As String = strAppDir & "\export\"
    Private strMODELS As String = strAppDir & "\models\"

    'Cadastro de BABEL
    '/////////////////
    Public bolBABELNEW As Boolean = False
    Public strDEVICENAME As String = Nothing
    Public strSAPID As String = Nothing
    Public bolENABLED As Boolean = False

    'Amarrados sem turno
    '////////////////////
    Public _clsAMARRADOS As New List(Of clsAMARRADOS_SEMTURNO)

#Region "CONEXÃO AO BANCO DE DADOS"
    Public Function xmlGetDataSource(ByRef strDataSource As String)

        Dim xmlFile As New XmlDocument
        Dim xmlNodeX As XmlNode

        Try

            'Verifica se o diretório dos arquivos XML existe
            '-----------------------------------------------
            If My.Computer.FileSystem.DirectoryExists(strXMLDir) = False Then
                strERROR = "<b>Diretório do sistema</b> de arquivos xml não encontrado!"
                ErrorLog(strERROR)
                Return False
            End If

            'Verifica a existência do arquivo de configuração
            '------------------------------------------------
            If IO.File.Exists(strXMLDir & "\DBDataSource.xml") = False Then
                strERROR = "Arquivo DBDataSource.xml não encontrado!"
                ErrorLog(strERROR)
                Return False
            End If

            'Acessa arquivo xml de configuração
            '----------------------------------
            xmlFile.Load(strXMLDir & "\" & "DBDataSource.xml")
            xmlNodeX = xmlFile.SelectSingleNode("DataSource")
            strDataSource = xmlNodeX.ChildNodes(0).Attributes.GetNamedItem("Name").Value
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função modPCP.xmlGetDataSource!"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function xmlWriteServer(ByVal strServer As String)

        Dim xmlFile As New XmlDocument
        Dim xmlNode As XmlNode
        Dim strErro As String = Nothing
        Dim strFile As String = "DBDataSource.xml"
        Try


            'Verifica a existência do arquivo de configuração
            '------------------------------------------------
            If IO.File.Exists(strXMLDir & "\" & strFile) = False Then
                strErro = "Arquivo <b>" & strFile & "</b> não encontrado!"
                ErrorLog(strErro)
                Return False
            End If

            'Acessa arquivo xml de configuração
            '----------------------------------
            xmlFile.Load(strXMLDir & "\" & strFile)
            xmlNode = xmlFile.SelectSingleNode("DataSource")
            xmlNode.ChildNodes(0).InnerText = strServer
            xmlFile.Save(strXMLDir & "\" & strFile)
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <bxmlWriteServer</b>!"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBLOGIN(ByVal strUser As String,
                                ByVal strPassword As String,
                                ByRef strErro As String,
                                ByRef bolResult As Boolean)

        Dim dtUsers As New DataSet
        Dim conSQL As SqlConnection
        Dim cmdRead As String = "SELECT * FROM [dbo].[exe_user]"
        Dim strConn As String = Nothing
        Dim cmdAdd As New SqlCommand
        Dim strP1 As String = Nothing
        Dim strP2 As String = Nothing
        bolResult = False

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL

            Dim sqlaUsers As New SqlDataAdapter(cmdRead, conSQL)
            sqlaUsers.Fill(dtUsers, "usuarios")

            If dtUsers.Tables(0).Rows.Count > 0 Then
                For intCount = 0 To dtUsers.Tables(0).Rows.Count - 1
                    If Trim(dtUsers.Tables(0).Rows(intCount).Item("Login")) = Trim(strUser) Then
                        If Trim(dtUsers.Tables(0).Rows(intCount).Item("Password")) = Trim(strPassword) Then
                            strGROUP = Trim(dtUsers.Tables(0).Rows(intCount).Item("Group"))
                            strUSERNAME = Trim(dtUsers.Tables(0).Rows(intCount).Item("Name"))
                            intUSERID = Val(dtUsers.Tables(0).Rows(intCount).Item("Id"))
                            bolResult = True
                            conSQL.Close()
                            Return False
                        End If
                    End If
                Next
            Else
                strErro = "Não foram encontrados <b>usuários</b> cadastrados!"
                conSQL.Close()
                Return False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBLOGIN!</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCONNECT(ByRef bolCONNECTED As Boolean,
                                  ByRef strErro As String) As Boolean

        Dim strConn As String
        Dim conSQL As SqlConnection

        strConn = "Data Source=" & strDataSource &
                  ";Initial Catalog=oViewer;" &
                  "User ID=oVViewers;Password=@allexoNew2017"

        Try

            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            If conSQL.State = ConnectionState.Open Then
                bolCONNECTED = True
            Else
                strErro = "Falha ao tentar conexão com o banco de dados do sistema!"
                ErrorLog(strErro)
                bolCONNECTED = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            bolCONNECTED = False
            Return False

        End Try

    End Function
    Public Function ReadDBGETAPPDATA(ByRef strDevices As String,
                                     Optional ByRef strViewers As String = Nothing,
                                     Optional ByRef cBlock As Boolean = False,
                                     Optional ByRef strCommTypes As String = Nothing,
                                     Optional ByRef strVersion As String = Nothing)

        Dim dtStatus As New DataSet
        Dim conSQL As SqlConnection
        Dim strCmdStatus As String = "SELECT * FROM [dbo].[cfg_appData]"
        Dim strConn As String
        Dim strErro As String = Nothing
        Dim strP1 As String = Nothing
        Dim cmdUpdate As New SqlCommand

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaStatus As New SqlDataAdapter(strCmdStatus, conSQL)
            sqlaStatus.Fill(dtStatus, "appData")
            strDevices = dtStatus.Tables(0).Rows(0).Item("nPD")
            strViewers = dtStatus.Tables(0).Rows(0).Item("nPV")
            strCommTypes = dtStatus.Tables(0).Rows(0).Item("CTypes")
            strVersion = dtStatus.Tables(0).Rows(0).Item("AppModel")
            If IsDBNull(dtStatus.Tables(0).Rows(0).Item("cBlock")) = False Then
                cBlock = dtStatus.Tables(0).Rows(0).Item("cBlock")
            Else
                cBlock = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETAPPDATA"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBCHECKPC(ByVal intUserId As String,
                                   ByRef bolChangeLogin As Boolean,
                                   ByRef bolChangePassword As Boolean,
                                   ByRef strErro As String) As Boolean

        Dim strConn As String = Nothing
        Dim strReadLog As String = Nothing
        Dim strReadUsers As String = Nothing
        Dim dtLogUsers As New DataSet
        Dim dtUsers As New DataSet
        Dim conSQL As SqlConnection

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()


            strReadLog = "SELECT * FROM [dbo].[exe_userLog] Where [UserId] = " & Trim(Str(intUserId))
            Dim sqlaUserLog As New SqlDataAdapter(strReadLog, conSQL)
            sqlaUserLog.Fill(dtLogUsers, "LogUsers")
            If dtLogUsers.Tables(0).Rows.Count = 1 Then
                strReadUsers = "SELECT * FROM [dbo].[exe_user] Where Id = " & Trim(Str(intUserId))
                Dim sqlaUser As New SqlDataAdapter(strReadUsers, conSQL)
                sqlaUser.Fill(dtUsers, "Users")
                bolChangeLogin = dtUsers.Tables(0).Rows(0).Item("mcLogin")
                bolChangePassword = dtUsers.Tables(0).Rows(0).Item("mcPassword")
            Else
                bolChangeLogin = False
                bolChangePassword = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>WriteDBCHECKPC!</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETVIEWERVERSION(ByVal strVERSION As String,
                                           ByVal strBUILD As String,
                                           ByRef bolNEW As Boolean,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String = Nothing
        Dim sqlcmdVERSION As New SqlCommand
        Dim dtsVERSION As New DataSet
        Dim arrVERSION As Array
        Dim arrBUILD As Array
        Dim arrCONTROL As Array
        Dim arrVERSIONVIEWER As Array
        Dim arrBUILDVIEWER As Array
        Dim bolNEWER As Boolean = False
        Dim intYEARVIEWER As Integer = 0
        Dim intYEAR As Integer = 0
        Dim intDAYVIEWER As Integer = 0
        Dim intDAY As Integer = 0
        Dim intMONTH As Integer = 0
        Dim intMONTHVIEWER As Integer = 0
        Dim intBUILD As Integer = 0
        Dim intBUILDVIEWER As Integer = 0
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            arrVERSIONVIEWER = Split(strVERSION, ".")
            arrBUILDVIEWER = Split(strBUILD, ".")
            sqlcmdVERSION.Connection = conSQL
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_versioncontrol]"
            Dim sqlaVERSION As New SqlDataAdapter(strCommand, conSQL)
            sqlaVERSION.Fill(dtsVERSION, "VersionControl")
            If dtsVERSION.Tables(0).Rows.Count > 0 Then

                arrCONTROL = Split(dtsVERSION.Tables(0).Rows(0).Item("viewer"), "#")
                arrVERSION = Split(arrCONTROL(0), ".")
                arrBUILD = Split(arrCONTROL(1), ".")

                'Versão
                '///////
                If Val(arrVERSIONVIEWER(0)) < Val(arrVERSION(0)) Then
                    bolNEW = True
                    Return True
                ElseIf Val(arrVERSIONVIEWER(0)) = Val(arrVERSION(0)) Then
                    If Val(arrVERSIONVIEWER(1)) < Val(arrVERSION(1)) Then
                        bolNEW = True
                        Return True
                    ElseIf Val(arrVERSIONVIEWER(1)) = Val(arrVERSION(1)) Then
                        If Val(arrVERSIONVIEWER(2)) < Val(arrVERSION(2)) Then
                            bolNEW = True
                            Return True
                        ElseIf Val(arrVERSIONVIEWER(2)) > Val(arrVERSION(2)) Then
                            bolNEWER = True
                        End If
                    Else
                        bolNEWER = True
                    End If
                Else
                    bolNEWER = True
                End If

                If bolNEWER = True Then
                    sqlcmdVERSION.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_versioncontrol] SET [viewer] = '" & strVERSION & "#" & strBUILD & "'"
                    sqlcmdVERSION.ExecuteNonQuery()
                    conSQL.Close()
                    Return True
                End If

                'Build
                '//////
                intYEAR = Val(Mid(arrBUILD(2), 3, 2))
                intYEARVIEWER = Val(Mid(arrBUILDVIEWER(2), 3, 2))
                intDAY = Val(Mid(arrBUILD(2), 1, 2))
                intDAYVIEWER = Val(Mid(arrBUILDVIEWER(2), 1, 2))
                intMONTH = Val(arrBUILD(1))
                intMONTHVIEWER = Val(arrBUILDVIEWER(1))
                intBUILD = Val(arrBUILD(0))
                intBUILDVIEWER = Val(arrBUILDVIEWER(0))
                If intYEARVIEWER < intYEAR Then
                    bolNEW = True
                    Return True
                ElseIf intYEARVIEWER = intYEAR Then
                    If intMONTHVIEWER < intMONTH Then
                        bolNEW = True
                        Return True
                    ElseIf intMONTHVIEWER = intMONTH Then
                        If intDAYVIEWER < intDAY Then
                            bolNEW = True
                            Return True
                        ElseIf intDAYVIEWER = intDAY Then
                            If intBUILDVIEWER < intBUILD Then
                                bolNEW = True
                                Return True
                            ElseIf intBUILDVIEWER > intBUILD Then
                                bolNEWER = True
                            End If
                        Else
                            bolNEWER = True
                        End If
                    Else
                        bolNEWER = True
                    End If
                Else
                    bolNEWER = True
                End If
            Else
                sqlcmdVERSION.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_versioncontrol] ([viewer]) VALUES ('" & strVERSION & "#" & strBUILD & "')"
                sqlcmdVERSION.ExecuteNonQuery()
            End If
            If bolNEWER = True Then
                sqlcmdVERSION.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_versioncontrol] SET [viewer] = '" & strVERSION & "#" & strBUILD & "'"
                sqlcmdVERSION.ExecuteNonQuery()
                conSQL.Close()
                Return True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>MCONTROL_OEE.ReadDBGETVIEWERVERSION</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBCHANGECREDENTIALS(ByVal intUSERID As Integer,
                                             ByVal strUSERLOGIN As String,
                                             ByVal strUSERPASSWORD As String,
                                             ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim strQUERY As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqlcmdLOGIN As New SqlCommand

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdLOGIN.Connection = conSQL

            sqlcmdLOGIN.CommandText = "UPDATE [dbo].[exe_user] SET [Login] = '" & Trim(strUSERLOGIN) & "', [Password] = '" & Trim(strUSERPASSWORD) & "', [mcLogin] = 0, [mcPassword] = 0 WHERE [Id] = " & intUSERID
            sqlcmdLOGIN.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBCHANGECREDENTIALS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "MÁQUINAS"
    Public Function ReadDBGETMACHINE(ByRef dgvMACHINE As DevComponents.DotNetBar.Controls.DataGridViewX,
                                     ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] ORDER BY [Descricao] ASC"
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtMaquinas.Tables(0).Rows.Count - 1
                    dgvMACHINE.Rows.Add()
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(0).Value = dtMaquinas.Tables(0).Rows(intC).Item("Id")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(1).Value = dtMaquinas.Tables(0).Rows(intC).Item("Descricao")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(2).Value = dtMaquinas.Tables(0).Rows(intC).Item("Ativo")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(5).Value = dtMaquinas.Tables(0).Rows(intC).Item("nobabel")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função GetMachines"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMACHINECONFIG(ByVal strMachineId As String,
                                           ByRef tbVariavel As System.Windows.Forms.TextBox,
                                           ByRef cbProduzindo As System.Windows.Forms.ComboBox,
                                           ByRef tbProduzindo As System.Windows.Forms.TextBox,
                                           ByRef cbParada As System.Windows.Forms.ComboBox,
                                           ByRef tbParada As System.Windows.Forms.TextBox,
                                           ByRef tbDeviceId As System.Windows.Forms.TextBox,
                                           ByRef bolFound As Boolean,
                                           ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & strMachineId
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                bolFound = True
                tbVariavel.Text = dtDevices.Tables(0).Rows(0).Item("OnOffVariable")
                cbProduzindo.Text = dtDevices.Tables(0).Rows(0).Item("StateON")
                tbProduzindo.Text = dtDevices.Tables(0).Rows(0).Item("TimetoOn")
                cbParada.Text = dtDevices.Tables(0).Rows(0).Item("StateOFF")
                tbParada.Text = dtDevices.Tables(0).Rows(0).Item("TimetoOff")
                tbDeviceId.Text = dtDevices.Tables(0).Rows(0).Item("DeviceId")
            Else
                bolFound = False
                tbVariavel.Text = ""
                cbProduzindo.Text = ""
                tbProduzindo.Text = ""
                cbParada.Text = ""
                tbParada.Text = ""
                tbDeviceId.Text = ""
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMACHINECONFIG"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETDEVICENAME(ByVal intMACHINEID As Integer,
                                        ByRef tbDEVICEREF As TextBox,
                                        ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM cfg_deviceList INNER JOIN exe_MCONTROL_OEE_Devices ON cfg_deviceList.id = " &
                         "exe_MCONTROL_OEE_Devices.DeviceId WHERE exe_MCONTROL_OEE_Devices.Machine = " & intMACHINEID
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                tbDEVICEREF.Text = dtMaquinas.Tables(0).Rows(0).Item("ReferenceName")
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETDEVICENAME"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEMACHINEDATA(ByVal dgvMAQUINA As DevComponents.DotNetBar.Controls.DataGridViewX,
                                             ByRef strErro As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strB1 As String = Nothing
        Dim strB2 As String = Nothing
        Dim sqldaMAQUINA As SqlDataAdapter
        Dim dtsMAQUINA As DataSet
        Dim strQUERY As String = Nothing
        Dim strORIGINALMACHINEID As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim sqldaRTDATA(999) As SqlDataAdapter
        Dim dtsRTDATA(999) As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvMAQUINA.Rows.Count - 1
                If dgvMAQUINA.Rows(intC).Cells(2).Value = True Then
                    strB1 = "1"
                Else
                    strB1 = "0"
                End If
                If dgvMAQUINA.Rows(intC).Cells(5).Value = True Then
                    strB2 = "1"
                Else
                    strB2 = "0"
                End If

                If dgvMAQUINA.Rows(intC).Cells(3).Value = True Then
                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_Maquinas] ([Referencia],[Descricao],[Ativo],[nobabel]) VALUES ('', '" & dgvMAQUINA.Rows(intC).Cells(1).Value &
                           "', " & strB1 & ", " & strB2 & ")"
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] ORDER BY [Id] DESC"
                    sqldaMAQUINA = New SqlDataAdapter(strQUERY, conSQL)
                    dtsMAQUINA = New DataSet
                    sqldaMAQUINA.Fill(dtsMAQUINA, "Maquinas")
                    dgvMAQUINA.Rows(intC).Cells(0).Value = dtsMAQUINA.Tables(0).Rows(0).Item("id")

                    'Atualiza Tabela de Status de Máquinas
                    '/////////////////////////////////////
                    If strB1 = "1" Then
                        strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_MStatus] ([Id_Maquina],[Produzindo],[Parada],[NOperacional]) VALUES (" &
                            dtsMAQUINA.Tables(0).Rows(0).Item("id") & ", 0, 0, 0)"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                    End If

                    dgvMAQUINA.Rows(intC).Cells(3).Value = False
                    strORIGINALMACHINEID = dtsMAQUINA.Tables(0).Rows(0).Item("id")
                    strMACHINEID = Convert.ToInt32(strORIGINALMACHINEID).ToString("D6")
                    strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"
                    strQUERY = "CREATE TABLE oViewer.dbo." & strTABLENAME & " (id int IDENTITY, date_shift date NOT NULL, " &
                               "time_begin varchar(5) Not NULL, time_end varchar(5) Not NULL, shift_id int NOT NULL)"
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()

                    If strB2 = 1 Then
                        strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_dvcRTData"
                        strQUERY = "INSERT INTO [dbo].[" & strTABLENAME & "] ([ED_1],[ED_2],[ED_3],[ED_4],[ED_5],[ED_6],[ED_7],[ED_8],[ED_9],[ED_10],[ED_11]," &
                                   "[ED_12],[ED_13],[ED_14],[ED_15],[ED_16],[EA_1],[EA_2],[EA_3],[EA_4],[EA_5],[EA_6],[EA_7],[EA_8],[EA_9],[EA_10],[EA_11]," &
                                   "[EA_12],[EA_13],[EA_14],[EA_15],[EA_16]) VALUES (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"
                        cmdUpdate.CommandText = strQUERY
                        cmdUpdate.ExecuteNonQuery()
                    End If

                ElseIf dgvMAQUINA.Rows(intC).Cells(4).Value = True Then

                    strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Maquinas] Set [Descricao] = '" & dgvMAQUINA.Rows(intC).Cells(1).Value &
                            "', [Ativo] = " & strB1 & ", [nobabel] = " & strB2 & " WHERE [Id] = " & dgvMAQUINA.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    If strB1 = "0" Then
                        strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & dgvMAQUINA.Rows(intC).Cells(0).Value
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                    Else
                        strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & dgvMAQUINA.Rows(intC).Cells(0).Value
                        sqldaMAQUINA = New SqlDataAdapter(strQUERY, conSQL)
                        dtsMAQUINA = New DataSet
                        sqldaMAQUINA.Fill(dtsMAQUINA, "Maquinas")
                        If dtsMAQUINA.Tables(0).Rows.Count = 0 Then
                            strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_MStatus] ([Id_Maquina],[Produzindo],[Parada],[NOperacional]) VALUES (" &
                                     dtsMAQUINA.Tables(0).Rows(0).Item("id") & ", 0, 0, 0)"
                            cmdUpdate.CommandText = strP1
                            cmdUpdate.ExecuteNonQuery()
                        End If
                    End If
                    dgvMAQUINA.Rows(intC).Cells(4).Value = False
                    If strB2 = 1 Then
                        strORIGINALMACHINEID = dgvMAQUINA.Rows(intC).Cells(0).Value
                        strMACHINEID = Convert.ToInt32(strORIGINALMACHINEID).ToString("D6")
                        strTABLENAME = "exe_" & strMACHINEID & "_dvcRTData"
                        strQUERY = "SELECT * FROM [dbo].[" & strTABLENAME & "]"
                        sqldaRTDATA(intC) = New SqlDataAdapter(strQUERY, conSQL)
                        dtsRTDATA(intC) = New DataSet
                        sqldaRTDATA(intC).Fill(dtsRTDATA(intC), "RTData")
                        If dtsRTDATA(intC).Tables(0).Rows.Count = 0 Then
                            strQUERY = "INSERT INTO [dbo].[" & strTABLENAME & "] ([ED_1],[ED_2],[ED_3],[ED_4],[ED_5],[ED_6],[ED_7],[ED_8],[ED_9],[ED_10],[ED_11]," &
                                       "[ED_12],[ED_13],[ED_14],[ED_15],[ED_16],[EA_1],[EA_2],[EA_3],[EA_4],[EA_5],[EA_6],[EA_7],[EA_8],[EA_9],[EA_10],[EA_11]," &
                                       "[EA_12],[EA_13],[EA_14],[EA_15],[EA_16]) VALUES (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"
                            cmdUpdate.CommandText = strQUERY
                            cmdUpdate.ExecuteNonQuery()
                        End If
                    End If
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>WriteDBUPDATEMACHINEDATA</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATESINAISCONTROLE(ByVal intMACHINEID As Integer,
                                                ByVal intDEVICEID As Integer,
                                                ByVal strVARIAVEL As String,
                                                ByVal strPRODUZINDO As String,
                                                ByVal intTEMPOPRODUZINDO As String,
                                                ByVal strPARADA As String,
                                                ByVal intTEMPOPARADA As Integer,
                                                ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "Select * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & intMACHINEID
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            cmdUpdate.Connection = conSQL
            If dtDevices.Tables(0).Rows.Count > 0 Then
                strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Devices] SET [DeviceId] = " & intDEVICEID & ", [OnOffVariable] = '" & strVARIAVEL &
                        "', [StateON] = '" & strPRODUZINDO & "', [StateOff] = '" & strPARADA & "', [TimetoOff] = '" &
                        intTEMPOPARADA & "', [TimetoOn] = '" & intTEMPOPRODUZINDO & "' WHERE [Machine] = " & intMACHINEID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            Else
                strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_Devices] ([Machine], [DeviceId], [OnOffVariable], [StateON], [StateOFF], [TimetoOff], [TimetoOn]) VALUES (" _
                                                                      & intMACHINEID & ", " & intDEVICEID & ", '" & strVARIAVEL & "', '" & strPRODUZINDO & "', '" & strPARADA & "', " & intTEMPOPARADA & ", " & intTEMPOPRODUZINDO & ")"
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUPDATESINAISCONTROLE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHECKUSEDMACHINE(ByVal intMAQUINAID As Integer,
                                           ByRef bolUSED As Boolean,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " & intMAQUINAID
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                bolUSED = True
            Else
                bolUSED = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKUSEDMACHINE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEMAQUINA(ByVal intMAQUINAID As Integer,
                                         ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim restrictions(3) As String
        Dim strTableName As String = Nothing
        Dim dbTbl As DataTable
        Dim strOriginalMachineId As String = Nothing
        Dim strMachineId As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_Maquinas] WHERE [Id] = " & intMAQUINAID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_MStatus] WHERE [Id_Maquina] = " & intMAQUINAID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & intMAQUINAID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            strOriginalMachineId = intMAQUINAID
            If Val(strOriginalMachineId) <= 9 Then
                strMachineId = "00000" & strOriginalMachineId
            ElseIf Val(strOriginalMachineId) >= 10 And Val(strOriginalMachineId) <= 99 Then
                strMachineId = "0000" & strOriginalMachineId
            ElseIf Val(strOriginalMachineId) >= 100 And Val(strOriginalMachineId) <= 999 Then
                strMachineId = "000" & strOriginalMachineId
            ElseIf Val(strOriginalMachineId) >= 1000 And Val(strOriginalMachineId) <= 9999 Then
                strMachineId = "00" & strOriginalMachineId
            ElseIf Val(strOriginalMachineId) >= 10000 And Val(strOriginalMachineId) <= 99999 Then
                strMachineId = "0" & strOriginalMachineId
            ElseIf Val(strOriginalMachineId) >= 100000 Then
                strMachineId = strOriginalMachineId
            End If
            strTableName = "exe_MCONTROL_OEE_" & strMachineId & "_Days"
            restrictions(2) = strTableName
            dbTbl = conSQL.GetSchema("Tables", restrictions)
            If dbTbl.Rows.Count > 0 Then
                strP1 = "DROP TABLE [dbo].[" & strTableName & "]"
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEMAQUINA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMACHINE_HABDESAB(ByRef lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                              ByRef lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                              ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsMAQUINAS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_Maquinas ORDER BY [Descricao] ASC"
            Dim sqlaMAQUINAS As New SqlDataAdapter(strCommand, conSQL)
            sqlaMAQUINAS.Fill(dtsMAQUINAS, "Máquinas")
            If dtsMAQUINAS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsMAQUINAS.Tables(0).Rows.Count - 1
                    lbMAQUINA.Items.Add(dtsMAQUINAS.Tables(0).Rows(intC).Item("Descricao"))
                    lbMAQUINAID.Items.Add(dtsMAQUINAS.Tables(0).Rows(intC).Item("id"))
                    If dtsMAQUINAS.Tables(0).Rows(intC).Item("Ativo") = True Then
                        lbMAQUINA.SetItemCheckState(lbMAQUINA.Items.Count - 1, 1)
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMACHINE_HABDESAB"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEHABMAQUINAS(ByRef lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                             ByRef strERROR As String)

        Dim strQUERY As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdHAB As New SqlCommand
        Dim intMAQUINAID As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdHAB.Connection = conSQL
            sqlcmdHAB.CommandText = "UPDATE [exe_MCONTROL_OEE_Maquinas] SET [Ativo] = 0"
            sqlcmdHAB.ExecuteNonQuery()
            For intC = 0 To lbMAQUINAID.CheckedItems.Count - 1
                intMAQUINAID = lbMAQUINAID.CheckedItems(intC).Text
                sqlcmdHAB.CommandText = "UPDATE [exe_MCONTROL_OEE_Maquinas] SET [Ativo] = 1 WHERE [Id] = " & intMAQUINAID
                sqlcmdHAB.ExecuteNonQuery()
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUPDATEHABMAQUINAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "DEVICES"
    Public Function ReadDBGETDEVICES(ByRef dgvDevices As DevComponents.DotNetBar.Controls.DataGridViewX,
                                     ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[cfg_deviceList]"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvDevices.Rows.Add()
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("Id")
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("ReferenceName")
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(2).Value = dtDevices.Tables(0).Rows(intC).Item("DeviceFullName")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função GetDevices"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETDEVICEMACHINE(ByVal intMACHINEID As Integer,
                                           ByRef intDEVICEID As Integer,
                                           ByRef strERRO As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [Machine] = " & intMACHINEID
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                intDEVICEID = dtDevices.Tables(0).Rows(0).Item("DeviceId")
            Else
                intDEVICEID = 0
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERRO = "Falha interna da função ReadDBGETDEVICEMACHINE"
            ErrorLog(strERRO)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETVARIABLES(ByVal strOriginalDeviceId As String,
                                       ByRef dgvVariables As DevComponents.DotNetBar.Controls.DataGridViewX,
                                       ByRef strErro As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim strDeviceId As String = Nothing
        Dim strTableName As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strDeviceId = Convert.ToInt32(strOriginalDeviceId).ToString("D6")
            strTableName = "exe_" & strDeviceId & "_dvcDataHeader"
            strCommand = "SELECT * FROM [dbo].[" & strTableName & "] WHERE [VarGroup] = 'Entradas Digitais'"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvVariables.Rows.Add()
                    dgvVariables.Rows(dgvVariables.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("VarSymbol")
                    dgvVariables.Rows(dgvVariables.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("VarName")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETVARIABLES"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "MOTIVO PARADAS"
    Public Function ReadDBGETMACHINEMOTIVOS(ByRef cbMAQUINA As ComboBox,
                                            ByRef cbMAQUINAID As ComboBox,
                                            ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] WHERE [Ativo] = 1 ORDER BY [Descricao] ASC"
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtMaquinas.Tables(0).Rows.Count - 1
                    cbMAQUINA.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Descricao"))
                    cbMAQUINAID.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMACHINEMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOS(ByRef dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                     ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] ORDER BY [descricao] ASC"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvMOTIVOS.Rows.Add()
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("Id")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("Descricao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(1).ReadOnly = True
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(2).Value = dtDevices.Tables(0).Rows(intC).Item("Orientacao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(2).ReadOnly = True
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(3).Value = dtDevices.Tables(0).Rows(intC).Item("Ativo")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(6).Value = dtDevices.Tables(0).Rows(intC).Item("setup")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(7).Value = dtDevices.Tables(0).Rows(intC).Item("testes")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(8).Value = dtDevices.Tables(0).Rows(intC).Item("paradaprogramada")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(9).Value = dtDevices.Tables(0).Rows(intC).Item("tempoliquido")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBSAVEMOTIVOS(ByVal dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                       ByVal intNIVEL As Integer,
                                       ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim strB1 As String = Nothing
        Dim strB2 As String = Nothing
        Dim strB3 As String = Nothing
        Dim strB4 As String = Nothing
        Dim strB5 As String = Nothing
        Dim sqldaMOTIVO As SqlDataAdapter
        Dim dtsMOTIVO As DataSet
        Dim sqldaSETUP(999) As SqlDataAdapter
        Dim dtsSETUP(999) As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvMOTIVOS.Rows.Count - 1
                If intNIVEL = 1 Then

                    If dgvMOTIVOS.Rows(intC).Cells(3).Value = True Then
                        strB1 = "1"
                    Else
                        strB1 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(6).Value = True Then
                        strB2 = "1"
                    Else
                        strB2 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(7).Value = True Then
                        strB3 = "1"
                    Else
                        strB3 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(8).Value = True Then
                        strB4 = "1"
                    Else
                        strB4 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(9).Value = True Then
                        strB5 = "1"
                    Else
                        strB5 = "0"
                    End If

                    'NEW
                    '////
                    If dgvMOTIVOS.Rows(intC).Cells(4).Value = True Then

                        strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_motivosnivel1] ([descricao],[orientacao],[ativo],[setup],[testes],[paradaprogramada],[tempoliquido]) VALUES ('" &
                                dgvMOTIVOS.Rows(intC).Cells(1).Value & "', '" & dgvMOTIVOS.Rows(intC).Cells(2).Value & "', " & strB1 & ", " & strB2 & ", " & strB3 & ", " & strB4 & ", " & strB5 & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        dgvMOTIVOS.Rows(intC).Cells(4).Value = False
                        strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] ORDER BY [Id] DESC"
                        sqldaMOTIVO = New SqlDataAdapter(strQUERY, conSQL)
                        dtsMOTIVO = New DataSet
                        sqldaMOTIVO.Fill(dtsMOTIVO, "Motivo")
                        dgvMOTIVOS.Rows(intC).Cells(0).Value = dtsMOTIVO.Tables(0).Rows(0).Item("Id")

                        'EDIT
                        '/////
                    ElseIf dgvMOTIVOS.Rows(intC).Cells(5).Value = True Then

                        strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_motivosnivel1] SET [descricao] = '" & dgvMOTIVOS.Rows(intC).Cells(1).Value &
                                "', [orientacao] = '" & dgvMOTIVOS.Rows(intC).Cells(2).Value & "', [ativo] = " & strB1 & ", [setup] = " & strB2 & ", [testes] = " & strB3 & ", [paradaprogramada] = " & strB4 & ", [tempoliquido] = " & strB5 & " WHERE [Id] = " &
                                dgvMOTIVOS.Rows(intC).Cells(0).Value
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        dgvMOTIVOS.Rows(intC).Cells(5).Value = False

                    End If

                ElseIf intNIVEL = 2 Then

                    If dgvMOTIVOS.Rows(intC).Cells(4).Value = True Then
                        strB1 = "1"
                    Else
                        strB1 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(5).Value = True Then
                        strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_motivosnivel2] ([idnivel1],[Descricao],[Orientacao],[Ativo]) VALUES (" &
                                 dgvMOTIVOS.Rows(intC).Cells(1).Value & ", '" & dgvMOTIVOS.Rows(intC).Cells(2).Value & "', '" &
                                 dgvMOTIVOS.Rows(intC).Cells(3).Value & "', " & strB1 & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] ORDER BY [Id] DESC"
                        sqldaMOTIVO = New SqlDataAdapter(strQUERY, conSQL)
                        dtsMOTIVO = New DataSet
                        sqldaMOTIVO.Fill(dtsMOTIVO, "Motivo")
                        dgvMOTIVOS.Rows(intC).Cells(0).Value = dtsMOTIVO.Tables(0).Rows(0).Item("Id")
                        dgvMOTIVOS.Rows(intC).Cells(5).Value = False

                    ElseIf dgvMOTIVOS.Rows(intC).Cells(6).Value = True Then
                        strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_motivosnivel2] SET [Descricao] = '" & dgvMOTIVOS.Rows(intC).Cells(2).Value &
                                "', [Orientacao] = '" & dgvMOTIVOS.Rows(intC).Cells(3).Value & "', [Ativo] = " & strB1 & " WHERE [Id] = " &
                                dgvMOTIVOS.Rows(intC).Cells(0).Value
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        dgvMOTIVOS.Rows(intC).Cells(6).Value = False
                    End If

                ElseIf intNIVEL = 3 Then
                    If dgvMOTIVOS.Rows(intC).Cells(4).Value = True Then
                        strB1 = "1"
                    Else
                        strB1 = "0"
                    End If
                    If dgvMOTIVOS.Rows(intC).Cells(5).Value = True Then
                        strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_motivosnivel3] ([idnivel2],[Descricao],[Orientacao],[Ativo]) VALUES (" &
                                 dgvMOTIVOS.Rows(intC).Cells(1).Value & ", '" & dgvMOTIVOS.Rows(intC).Cells(2).Value & "', '" &
                                 dgvMOTIVOS.Rows(intC).Cells(3).Value & "', " & strB1 & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] ORDER BY [Id] DESC"
                        sqldaMOTIVO = New SqlDataAdapter(strQUERY, conSQL)
                        dtsMOTIVO = New DataSet
                        sqldaMOTIVO.Fill(dtsMOTIVO, "Motivo")
                        dgvMOTIVOS.Rows(intC).Cells(0).Value = dtsMOTIVO.Tables(0).Rows(0).Item("Id")
                        dgvMOTIVOS.Rows(intC).Cells(5).Value = False

                    ElseIf dgvMOTIVOS.Rows(intC).Cells(6).Value = True Then
                        strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_motivosnivel3] SET [Descricao] = '" & dgvMOTIVOS.Rows(intC).Cells(2).Value & "', " &
                                " [Orientacao] = '" & dgvMOTIVOS.Rows(intC).Cells(3).Value & "', [Ativo] = " & strB1 & " WHERE [Id] = " &
                                dgvMOTIVOS.Rows(intC).Cells(0).Value
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        dgvMOTIVOS.Rows(intC).Cells(6).Value = False
                    End If

                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBSAVEMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try
    End Function
    Public Function ReadDBGETMOTIVOSNIVEL2(ByVal intIDNIVEL1 As Integer,
                                           ByRef dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intIDNIVEL1 & " ORDER BY [descricao] ASC"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvMOTIVOS.Rows.Add()
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("id")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("idnivel1")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(2).Value = dtDevices.Tables(0).Rows(intC).Item("Descricao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(3).Value = dtDevices.Tables(0).Rows(intC).Item("Orientacao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(3).ReadOnly = True
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(4).Value = dtDevices.Tables(0).Rows(intC).Item("Ativo")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL2"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL3(ByVal intIDNIVEL2 As Integer,
                                           ByRef dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intIDNIVEL2 & " ORDER BY [descricao] ASC"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvMOTIVOS.Rows.Add()
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("id")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("idnivel2")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(2).Value = dtDevices.Tables(0).Rows(intC).Item("Descricao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(3).Value = dtDevices.Tables(0).Rows(intC).Item("Orientacao")
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(3).ReadOnly = True
                    dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(4).Value = dtDevices.Tables(0).Rows(intC).Item("Ativo")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL3"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGEDADOSPARADA(ByVal intPARADAID As Integer,
                                        ByRef dtiDINI As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                        ByRef dtiHINI As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                        ByRef dtiDFIM As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                        ByRef dtiHFIM As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                        ByRef tbCOMENTARIOS As TextBox,
                                        ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim dtsMACHINE As New DataSet
        Dim intMACHINEID As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [Id] = " & intPARADAID
            Dim sqlaMACHINE As New SqlDataAdapter(strCommand, conSQL)
            sqlaMACHINE.Fill(dtsMACHINE, "Maquina")
            dtiDINI.Text = Mid(dtsMACHINE.Tables(0).Rows(0).Item("DateTimeOn"), 1, 10)
            dtiHINI.Text = Mid(dtsMACHINE.Tables(0).Rows(0).Item("DateTimeOn"), 11, 8)
            dtiDFIM.Text = Mid(dtsMACHINE.Tables(0).Rows(0).Item("DateTimeOff"), 1, 10)
            dtiHFIM.Text = Mid(dtsMACHINE.Tables(0).Rows(0).Item("DateTimeOff"), 11, 8)
            tbCOMENTARIOS.Text = dtsMACHINE.Tables(0).Rows(0).Item("Comentarios")
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETPARADAS(ByVal strDataInicial As String,
                                     ByVal strHORAINICIAL As String,
                                     ByVal strDataFinal As String,
                                     ByVal strHORAFINAL As String,
                                     ByVal lblMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                     ByRef dgvPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                     ByVal intMOTIVON1ID As Integer,
                                     ByVal intMOTIVON2ID As Integer,
                                     ByVal intMOTIVON3ID As Integer,
                                     ByVal bolSEMMOTIVOS As Boolean,
                                     ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtParadas As New DataSet
        Dim dateIni As DateTime
        Dim dateFim As DateTime
        Dim decTempoParada As Decimal = 0D
        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim sqlaOPERADOR(999) As SqlDataAdapter
        Dim dtsOPERADOR(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim intTEMPOTOTALPARADA As Integer = 0
        Dim dtimeREGISTROBLOQUEIO As DateTime = Nothing
        Dim dtimePARADA As DateTime = Nothing
        Dim sqldaBLOQUEIO(9999) As SqlDataAdapter
        Dim dtsBLOQUEIO(9999) As DataSet
        Dim sqldaAMARRADO(9999) As SqlDataAdapter
        Dim dtsAMARRADO(9999) As DataSet

        Dim dtimePARADAON As DateTime
        Dim dtimePARADAOFF As DateTime
        Dim sqlparams(1) As SqlClient.SqlParameter

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strNEWDATAINICIAL = strDataInicial & " " & strHORAINICIAL
            strNEWDATAFINAL = strDataFinal & " " & strHORAFINAL

            strCommand = "Select exe_MCONTROL_OEE_HistoricoParadas.Id, exe_MCONTROL_OEE_HistoricoParadas.MachineId, exe_MCONTROL_OEE_HistoricoParadas.DateTimeOn, exe_MCONTROL_OEE_HistoricoParadas.DateTimeOff, " &
                         "exe_MCONTROL_OEE_HistoricoParadas.Motivo, exe_MCONTROL_OEE_HistoricoParadas.MotivoId, exe_MCONTROL_OEE_HistoricoParadas.MotivoN2, " &
                         "exe_MCONTROL_OEE_HistoricoParadas.MotivoN3, exe_MCONTROL_OEE_Operadores.Nome, exe_MCONTROL_OEE_Maquinas.Descricao AS centrotrabalho, exe_MCONTROL_OEE_HistoricoParadas.Comentarios " &
                         "FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] INNER JOIN [dbo].[exe_MCONTROL_OEE_Maquinas] ON exe_MCONTROL_OEE_HistoricoParadas.MachineId = exe_MCONTROL_OEE_Maquinas.Id " &
                         "LEFT JOIN exe_MCONTROL_OEE_Operadores ON exe_MCONTROL_OEE_HistoricoParadas.UserId = exe_MCONTROL_OEE_Operadores.Id " &
                         "WHERE [DateTimeOn] >= @DI AND [DateTimeOff] IS NOT NULL AND [DateTimeOff] <= @DF "
            If lblMAQUINAID.CheckedItems.Count > 1 Then
                For intC = 0 To lblMAQUINAID.CheckedItems.Count - 1
                    If intC = 0 Then
                        strCommand &= "AND ([MachineId] = " & lblMAQUINAID.CheckedItems(intC).ToString
                    Else
                        strCommand &= " OR [MachineId] = " & lblMAQUINAID.CheckedItems(intC).ToString
                    End If
                Next
                strCommand &= ")"
            Else
                strCommand &= " And [MachineId] = " & lblMAQUINAID.CheckedItems(0).ToString
            End If
            If bolSEMMOTIVOS = True Then
                strCommand &= " AND [Motivo] IS NOT NULL"
            End If
            If intMOTIVON1ID > 0 Then
                strCommand &= " AND [MotivoId] = " & intMOTIVON1ID
            End If
            If intMOTIVON2ID > 0 Then
                strCommand &= " AND [motivonivel2] = " & intMOTIVON2ID
            End If
            If intMOTIVON3ID > 0 Then
                strCommand &= " AND [motivonivel3] = " & intMOTIVON3ID
            End If
            strCommand &= " ORDER BY [DateTimeOn] ASC"
            Dim sqlaParadas As New SqlDataAdapter(strCommand, conSQL)
            sqlaParadas.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strNEWDATAINICIAL)))
            sqlaParadas.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strNEWDATAFINAL)))
            sqlaParadas.Fill(dtParadas, "Paradas")

            If dtParadas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtParadas.Tables(0).Rows.Count - 1

                    dgvPARADAS.Rows.Add()
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(0).Value = dtParadas.Tables(0).Rows(intC).Item("Id")
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(1).Value = dtParadas.Tables(0).Rows(intC).Item("MachineId")
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(2).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"), 1, 10)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(3).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"), 12, 8)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(4).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"), 1, 10)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(5).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"), 12, 8)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(6).Value = ""
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(7).Value = dtParadas.Tables(0).Rows(intC).Item("centrotrabalho")

                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("Nome")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(8).Value = dtParadas.Tables(0).Rows(intC).Item("Nome")
                    End If
                    dtimePARADAON = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"))
                    dtimePARADAOFF = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"))

                    'Itens
                    '//////
                    strCommand = "SELECT * FROM exe_MCONTROL_BABELFISH_opstatus INNER JOIN exe_MCONTROL_BABELFISH_babelmachine_reference ON exe_MCONTROL_BABELFISH_opstatus.machineid = " &
                                 "exe_MCONTROL_BABELFISH_babelmachine_reference.babelfish_id WHERE [itemstatus] = 0 AND [data_hora_inicio] <= @DI " &
                                 "AND [data_hora_fim] >= @DF AND exe_MCONTROL_BABELFISH_babelmachine_reference.machineid = " & dtParadas.Tables(0).Rows(intC).Item("MachineId")
                    sqldaAMARRADO(intC) = New SqlDataAdapter(strCommand, conSQL)
                    dtsAMARRADO(intC) = New DataSet
                    sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimePARADAON))
                    sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimePARADAOFF))
                    sqldaAMARRADO(intC).Fill(dtsAMARRADO(intC), "Amarrado")
                    If dtsAMARRADO(intC).Tables(0).Rows.Count > 0 Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(9).Value = dtsAMARRADO(intC).Tables(0).Rows(0).Item("opnumber")
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(10).Value = dtsAMARRADO(intC).Tables(0).Rows(0).Item("item_ordem")
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(11).Value = dtsAMARRADO(intC).Tables(0).Rows(0).Item("material")
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(12).Value = dtsAMARRADO(intC).Tables(0).Rows(0).Item("description")
                    Else
                    End If
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(13).Value = ""
                    dateIni = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"))
                    dateFim = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"))
                    decTempoParada = DateDiff(DateInterval.Second, dateIni, dateFim)
                    intTEMPOTOTALPARADA += DateDiff(DateInterval.Second, dateIni, dateFim)
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
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(14).Value = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(15).Value = (decTempoParada / 60).ToString("F2")
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("Motivo")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(16).Value = dtParadas.Tables(0).Rows(intC).Item("Motivo")
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(23).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoId")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("MotivoN2")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(17).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoN2")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("MotivoN3")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(18).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoN3")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("Comentarios")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(19).Value = dtParadas.Tables(0).Rows(intC).Item("Comentarios")
                    End If
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(23).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoId")
                Next
                dgvPARADAS.Rows.Add()
                dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(13).Value = "Total"
                intHORA = Int(intTEMPOTOTALPARADA / 3600)
                decFracionario = (intTEMPOTOTALPARADA / 3600) - intHORA
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
                dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(14).Value = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(15).Value = (intTEMPOTOTALPARADA / 60).ToString("F2")
                For intC = 0 To dgvPARADAS.Rows.Count - 2
                    strCommand = "Select * FROM [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio] WHERE [maquinaid] = " & dgvPARADAS.Rows(intC).Cells(1).Value
                    sqldaBLOQUEIO(intC) = New SqlDataAdapter(strCommand, conSQL)
                    dtsBLOQUEIO(intC) = New DataSet
                    sqldaBLOQUEIO(intC).Fill(dtsBLOQUEIO(intC), "Bloqueios")
                    If dtsBLOQUEIO(intC).Tables(0).Rows.Count > 0 Then
                        dtimeREGISTROBLOQUEIO = Convert.ToDateTime(dtsBLOQUEIO(intC).Tables(0).Rows(0).Item("data"))
                        For intC2 = 0 To dgvPARADAS.Rows.Count - 2
                            dtimePARADA = Convert.ToDateTime(dgvPARADAS.Rows(intC2).Cells(2).Value & " " & dgvPARADAS.Rows(intC2).Cells(3).Value)
                            If DateDiff(DateInterval.Second, dtimePARADA, dtimeREGISTROBLOQUEIO) >= 0 Then
                                For intC3 = 2 To 19
                                    dgvPARADAS.Rows(intC2).Cells(intC3).Style.BackColor = Color.Yellow
                                Next
                                dgvPARADAS.Rows(intC2).Cells(20).Value = True
                            Else
                                dgvPARADAS.Rows(intC2).Cells(20).Value = False
                            End If
                        Next
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETPARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETOPS(ByVal intMACHINEID As Integer,
                                 ByRef lbOPS As ListBox,
                                 ByRef lbOPSAUX As ListBox,
                                 ByRef strDATA As String,
                                 ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOrdem As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_Devices INNER JOIN exe_MCONTROL_BABELFISH_idreferences ON " &
                         "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id INNER JOIN " &
                         "exe_MCONTROL_BABELFISH_opstatus ON exe_MCONTROL_BABELFISH_idreferences.babelfish_id = " &
                         "exe_MCONTROL_BABELFISH_opstatus.machineid WHERE exe_MCONTROL_OEE_Devices.Machine = " & intMACHINEID &
                         " AND exe_MCONTROL_BABELFISH_opstatus.opstatus = 0 AND [DateTime] >= convert(datetime, '" & strDATA & " 00:00:00',103)"
            Dim sqlaOrdem As New SqlDataAdapter(strCommand, conSQL)
            sqlaOrdem.Fill(dtOrdem, "Ordem")
            If dtOrdem.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtOrdem.Tables(0).Rows.Count - 1
                    lbOPS.Items.Add(dtOrdem.Tables(0).Rows(intC).Item("opnumber"))
                    lbOPSAUX.Items.Add(dtOrdem.Tables(0).Rows(intC).Item("opnumber"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função GetOrdens"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEMOTIVOPARADA(ByVal intMOTIVOID As Integer,
                                              ByVal intNIVEL As Integer,
                                              ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim sqldaMOTIVOSN2 As SqlDataAdapter
        Dim dtsMOTIVOSN2 As DataSet
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            If intNIVEL = 1 Then
                strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [id] = " & intMOTIVOID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVOID
                sqldaMOTIVOSN2 = New SqlDataAdapter(strQUERY, conSQL)
                dtsMOTIVOSN2 = New DataSet
                sqldaMOTIVOSN2.Fill(dtsMOTIVOSN2, "MotivosNivel2")
                For intC = 0 To dtsMOTIVOSN2.Tables(0).Rows.Count - 1
                    strQUERY = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " &
                               dtsMOTIVOSN2.Tables(0).Rows(intC).Item("id")
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()
                Next
                strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVOID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            ElseIf intNIVEL = 2 Then
                strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [id] = " & intMOTIVOID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
                strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intMOTIVOID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            ElseIf intNIVEL = 3 Then
                strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [id] = " & intMOTIVOID
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEMOTIVOPARADA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHECKUSOMOTIVO(ByVal intMOTIVOID As Integer,
                                         ByVal intMOTIVONIVEL As Integer,
                                         ByRef bolUSED As Boolean,
                                         ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtNIVEL1 As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            If intMOTIVONIVEL = 1 Then
                strCommand = "Select * FROM exe_MCONTROL_OEE_HistoricoParadas WHERE [MotivoId] = " & intMOTIVOID
            ElseIf intMOTIVONIVEL = 2 Then
                strCommand = "Select * FROM exe_MCONTROL_OEE_HistoricoParadas WHERE [motivonivel2] = " & intMOTIVOID
            ElseIf intMOTIVONIVEL = 3 Then
                strCommand = "Select * FROM exe_MCONTROL_OEE_HistoricoParadas WHERE [motivonivel3] = " & intMOTIVOID
            End If
            Dim sqlaNIVEL1 As New SqlDataAdapter(strCommand, conSQL)
            sqlaNIVEL1.Fill(dtNIVEL1, "Nivel1")
            If dtNIVEL1.Tables(0).Rows.Count > 0 Then
                bolUSED = True
            Else
                bolUSED = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKUSOMOTIVO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSMANUTENCAO(ByVal dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                               ByVal dgvMOTIVOSWAIT As DevComponents.DotNetBar.Controls.DataGridViewX,
                                               ByVal dgvMOTIVOSFECHAMENTO As DevComponents.DotNetBar.Controls.DataGridViewX,
                                               ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaMOTIVOS As SqlDataAdapter
        Dim dtsMOTIVOS As DataSet
        Dim sqldaMANUTENCAO As SqlDataAdapter
        Dim dtsMANUTENCAO As DataSet
        Dim sqldaAGUARDANDO As SqlDataAdapter
        Dim dtsAGUARDANDO As DataSet
        Dim bolFOUND As Boolean = False
        Dim sqldaFECHAMENTO As SqlDataAdapter
        Dim dtsFECHAMENTO As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            'Manutenção
            '//////////
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_motivosnivel1 ORDER BY [descricao] ASC"
            sqldaMOTIVOS = New SqlDataAdapter(strCommand, conSQL)
            dtsMOTIVOS = New DataSet
            sqldaMOTIVOS.Fill(dtsMOTIVOS, "Motivos")

            'Manutenção
            '//////////
            For intC = 0 To dtsMOTIVOS.Tables(0).Rows.Count - 1
                dgvMOTIVOS.Rows.Add()
                dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(0).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("id")
                dgvMOTIVOS.Rows(dgvMOTIVOS.Rows.Count - 1).Cells(1).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("descricao")
            Next
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_motivos_manutencao"
            sqldaMANUTENCAO = New SqlDataAdapter(strCommand, conSQL)
            dtsMANUTENCAO = New DataSet
            sqldaMANUTENCAO.Fill(dtsMANUTENCAO, "Manutencao")
            If dtsMANUTENCAO.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dgvMOTIVOS.Rows.Count - 1
                    For intC2 = 0 To dtsMANUTENCAO.Tables(0).Rows.Count - 1
                        If dtsMANUTENCAO.Tables(0).Rows(intC2).Item("motivoid") = dgvMOTIVOS.Rows(intC).Cells(0).Value Then
                            dgvMOTIVOS.Rows(intC).Cells(2).Value = True
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        dgvMOTIVOS.Rows(intC).Cells(2).Value = False
                    Else
                        bolFOUND = False
                    End If
                Next
            End If

            'Aguardando Manutenção
            '//////////////////////
            For intC = 0 To dtsMOTIVOS.Tables(0).Rows.Count - 1
                dgvMOTIVOSWAIT.Rows.Add()
                dgvMOTIVOSWAIT.Rows(dgvMOTIVOSWAIT.Rows.Count - 1).Cells(0).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("id")
                dgvMOTIVOSWAIT.Rows(dgvMOTIVOSWAIT.Rows.Count - 1).Cells(1).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("descricao")
            Next
            bolFOUND = False
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_motivos_aguardandomanutencao"
            sqldaAGUARDANDO = New SqlDataAdapter(strCommand, conSQL)
            dtsAGUARDANDO = New DataSet
            sqldaAGUARDANDO.Fill(dtsAGUARDANDO, "Aguardando")
            If dtsAGUARDANDO.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dgvMOTIVOSWAIT.Rows.Count - 1
                    For intC2 = 0 To dtsAGUARDANDO.Tables(0).Rows.Count - 1
                        If dtsAGUARDANDO.Tables(0).Rows(intC2).Item("motivoid") = dgvMOTIVOSWAIT.Rows(intC).Cells(0).Value Then
                            dgvMOTIVOSWAIT.Rows(intC).Cells(2).Value = True
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        dgvMOTIVOSWAIT.Rows(intC).Cells(2).Value = False
                    Else
                        bolFOUND = False
                    End If
                Next
            End If

            'Fechamento Manutenção
            '//////////////////////
            For intC = 0 To dtsMOTIVOS.Tables(0).Rows.Count - 1
                dgvMOTIVOSFECHAMENTO.Rows.Add()
                dgvMOTIVOSFECHAMENTO.Rows(dgvMOTIVOSFECHAMENTO.Rows.Count - 1).Cells(0).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("id")
                dgvMOTIVOSFECHAMENTO.Rows(dgvMOTIVOSFECHAMENTO.Rows.Count - 1).Cells(1).Value = dtsMOTIVOS.Tables(0).Rows(intC).Item("descricao")
            Next
            bolFOUND = False
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_motivos_fechamentoparada"
            sqldaFECHAMENTO = New SqlDataAdapter(strCommand, conSQL)
            dtsFECHAMENTO = New DataSet
            sqldaFECHAMENTO.Fill(dtsFECHAMENTO, "Fechamento")
            If dtsFECHAMENTO.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dgvMOTIVOSFECHAMENTO.Rows.Count - 1
                    For intC2 = 0 To dtsFECHAMENTO.Tables(0).Rows.Count - 1
                        If dtsFECHAMENTO.Tables(0).Rows(intC2).Item("motivoid") = dgvMOTIVOSFECHAMENTO.Rows(intC).Cells(0).Value Then
                            dgvMOTIVOSFECHAMENTO.Rows(intC).Cells(2).Value = True
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        dgvMOTIVOSFECHAMENTO.Rows(intC).Cells(2).Value = False
                    Else
                        bolFOUND = False
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSMANUTENCAO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WrtiteDBUPDATEMOTIVOSMANUTENCAO(ByVal dgvMOTIVOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                                    ByVal dgvMOTIVOSWAIT As DevComponents.DotNetBar.Controls.DataGridViewX,
                                                    ByVal dgvMOTIVOSFECHAMENTO As DevComponents.DotNetBar.Controls.DataGridViewX,
                                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim sqlcmdUPDATE As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPDATE.Connection = conSQL

            'Manutenção
            '//////////
            sqlcmdUPDATE.CommandText = "DELETE FROM exe_MCONTROL_OEE_motivos_manutencao"
            sqlcmdUPDATE.ExecuteNonQuery()
            For intC = 0 To dgvMOTIVOS.Rows.Count - 1
                If dgvMOTIVOS.Rows(intC).Cells(2).Value = True Then
                    sqlcmdUPDATE.CommandText = "INSERT INTO exe_MCONTROL_OEE_motivos_manutencao ([motivoid]) VALUES (" &
                                               dgvMOTIVOS.Rows(intC).Cells(0).Value & ")"
                    sqlcmdUPDATE.ExecuteNonQuery()
                End If
            Next

            'Aguardando
            '//////////
            sqlcmdUPDATE.CommandText = "DELETE FROM exe_MCONTROL_OEE_motivos_aguardandomanutencao"
            sqlcmdUPDATE.ExecuteNonQuery()
            For intC = 0 To dgvMOTIVOSWAIT.Rows.Count - 1
                If dgvMOTIVOSWAIT.Rows(intC).Cells(2).Value = True Then
                    sqlcmdUPDATE.CommandText = "INSERT INTO exe_MCONTROL_OEE_motivos_aguardandomanutencao ([motivoid]) VALUES (" &
                                               dgvMOTIVOSWAIT.Rows(intC).Cells(0).Value & ")"
                    sqlcmdUPDATE.ExecuteNonQuery()
                End If
            Next

            'Fechamento
            '//////////
            sqlcmdUPDATE.CommandText = "DELETE FROM exe_MCONTROL_OEE_motivos_fechamentoparada"
            sqlcmdUPDATE.ExecuteNonQuery()
            For intC = 0 To dgvMOTIVOSFECHAMENTO.Rows.Count - 1
                If dgvMOTIVOSFECHAMENTO.Rows(intC).Cells(2).Value = True Then
                    sqlcmdUPDATE.CommandText = "INSERT INTO exe_MCONTROL_OEE_motivos_fechamentoparada ([motivoid]) VALUES (" &
                                               dgvMOTIVOSFECHAMENTO.Rows(intC).Cells(0).Value & ")"
                    sqlcmdUPDATE.ExecuteNonQuery()
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WrtiteDBUPDATEMOTIVOSMANUTENCAO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "OPERADORES"
    Public Function ReadDBGETOPERADORES(ByRef dgvOPERADOR As DevComponents.DotNetBar.Controls.DataGridViewX,
                                        ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOperadores As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores]"
            Dim sqlaOperadores As New SqlDataAdapter(strCommand, conSQL)
            sqlaOperadores.Fill(dtOperadores, "Operadores")
            If dtOperadores.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtOperadores.Tables(0).Rows.Count - 1
                    dgvOPERADOR.Rows.Add()
                    dgvOPERADOR.Rows(dgvOPERADOR.Rows.Count - 1).Cells(0).Value = dtOperadores.Tables(0).Rows(intC).Item("Id")
                    dgvOPERADOR.Rows(dgvOPERADOR.Rows.Count - 1).Cells(2).Value = dtOperadores.Tables(0).Rows(intC).Item("Nome")
                    dgvOPERADOR.Rows(dgvOPERADOR.Rows.Count - 1).Cells(3).Value = dtOperadores.Tables(0).Rows(intC).Item("Login")
                    dgvOPERADOR.Rows(dgvOPERADOR.Rows.Count - 1).Cells(4).Value = dtOperadores.Tables(0).Rows(intC).Item("Ativo")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETOPERADORES"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try


    End Function
    Public Function WriteDBUPDATEOPERADORES(ByVal dgvOPERADORES As DevComponents.DotNetBar.Controls.DataGridViewX,
                                            ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim strB1 As String = Nothing
        Dim sqldaOPERADOR As SqlDataAdapter
        Dim dtsOPERADOR As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvOPERADORES.Rows.Count - 1
                If dgvOPERADORES.Rows(intC).Cells(4).Value = True Then
                    strB1 = "1"
                Else
                    strB1 = "0"
                End If

                If dgvOPERADORES.Rows(intC).Cells(5).Value = True Then
                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_Operadores] ([Nome],[Login],[Ativo]) VALUES ('" & dgvOPERADORES.Rows(intC).Cells(2).Value & "', '" &
                            dgvOPERADORES.Rows(intC).Cells(3).Value & "', " & strB1 & ")"
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores] ORDER BY [Id] DESC"
                    sqldaOPERADOR = New SqlDataAdapter(strQUERY, conSQL)
                    dtsOPERADOR = New DataSet
                    sqldaOPERADOR.Fill(dtsOPERADOR, "Operador")
                    dgvOPERADORES.Rows(intC).Cells(0).Value = dtsOPERADOR.Tables(0).Rows(0).Item("Id")
                    dgvOPERADORES.Rows(intC).Cells(5).Value = False

                ElseIf dgvOPERADORES.Rows(intC).Cells(6).Value = True Then
                    strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_Operadores] SET [Nome] = '" & dgvOPERADORES.Rows(intC).Cells(2).Value & "', " &
                            "[Login] = '" & dgvOPERADORES.Rows(intC).Cells(3).Value & "', [Ativo] = " & strB1 &
                            " WHERE [Id] = " & dgvOPERADORES.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    dgvOPERADORES.Rows(intC).Cells(6).Value = False
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUPDATEOPERADORES"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEOPERADOR(ByVal intOPERADORID As Integer,
                                          ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
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
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_Operadores] WHERE [id] = " & intOPERADORID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEMOTIVOPARADA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "ESCALA DE TRABALHO"
    Public Function ReadDBGETESCALATRABALHO(ByVal strMachineId As String,
                                            ByVal strDATAINICIAL As String,
                                            ByVal strDATAFINAL As String,
                                            ByRef dgvMACHINE As DevComponents.DotNetBar.Controls.DataGridViewX,
                                            ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet
        Dim strMachineNewId As String = Nothing
        Dim strMachineTable As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strMachineNewId = Convert.ToInt32(strMachineId).ToString("D6")
            strMachineTable = "[dbo].[exe_MCONTROL_OEE_" & strMachineNewId & "_Days] WHERE [Data] >= '" & strDATAINICIAL & "' AND [Data] <= '" & strDATAFINAL & "'"
            strCommand = "SELECT * FROM " & strMachineTable & " ORDER BY [Data] ASC"
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtMaquinas.Tables(0).Rows.Count - 1
                    dgvMACHINE.Rows.Add()
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(0).Value = dtMaquinas.Tables(0).Rows(intC).Item("Data")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(1).Value = dtMaquinas.Tables(0).Rows(intC).Item("DayOfWeek")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(2).Value = dtMaquinas.Tables(0).Rows(intC).Item("DayOff")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(3).Value = dtMaquinas.Tables(0).Rows(intC).Item("T1HoraIni")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(4).Value = dtMaquinas.Tables(0).Rows(intC).Item("T1HoraFim")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(5).Value = dtMaquinas.Tables(0).Rows(intC).Item("T2HoraIni")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(6).Value = dtMaquinas.Tables(0).Rows(intC).Item("T2HoraFim")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(7).Value = dtMaquinas.Tables(0).Rows(intC).Item("T3HoraIni")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(8).Value = dtMaquinas.Tables(0).Rows(intC).Item("T3HoraFim")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(9).Value = dtMaquinas.Tables(0).Rows(intC).Item("T4HoraIni")
                    dgvMACHINE.Rows(dgvMACHINE.Rows.Count - 1).Cells(10).Value = dtMaquinas.Tables(0).Rows(intC).Item("T4HoraFim")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função GetEscalaTrabalho"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBGERARESCALA(ByVal strMachineId As String,
                                       ByVal strDataInicial As String,
                                       ByVal strDataFinal As String,
                                       ByVal bolSeg1 As Boolean,
                                       ByVal bolTer1 As Boolean,
                                       ByVal bolQua1 As Boolean,
                                       ByVal bolQui1 As Boolean,
                                       ByVal bolSex1 As Boolean,
                                       ByVal bolSab1 As Boolean,
                                       ByVal bolDom1 As Boolean,
                                       ByVal bolSeg2 As Boolean,
                                       ByVal bolTer2 As Boolean,
                                       ByVal bolQua2 As Boolean,
                                       ByVal bolQui2 As Boolean,
                                       ByVal bolSex2 As Boolean,
                                       ByVal bolSab2 As Boolean,
                                       ByVal bolDom2 As Boolean,
                                       ByVal bolSeg3 As Boolean,
                                       ByVal bolTer3 As Boolean,
                                       ByVal bolQua3 As Boolean,
                                       ByVal bolQui3 As Boolean,
                                       ByVal bolSex3 As Boolean,
                                       ByVal bolSab3 As Boolean,
                                       ByVal bolDom3 As Boolean,
                                       ByVal bolP11 As Boolean,
                                       ByVal bolP21 As Boolean,
                                       ByVal bolP31 As Boolean,
                                       ByVal bolP41 As Boolean,
                                       ByVal bolP12 As Boolean,
                                       ByVal bolP22 As Boolean,
                                       ByVal bolP32 As Boolean,
                                       ByVal boLp42 As Boolean,
                                       ByVal bolP13 As Boolean,
                                       ByVal bolP23 As Boolean,
                                       ByVal bolP33 As Boolean,
                                       ByVal bolP43 As Boolean,
                                       ByVal strHI11 As String,
                                       ByVal strHF11 As String,
                                       ByVal strHI21 As String,
                                       ByVal strHF21 As String,
                                       ByVal strHI31 As String,
                                       ByVal strHF31 As String,
                                       ByVal strHI41 As String,
                                       ByVal strHF41 As String,
                                       ByVal strHI12 As String,
                                       ByVal strHF12 As String,
                                       ByVal strHI22 As String,
                                       ByVal strHF22 As String,
                                       ByVal strHI32 As String,
                                       ByVal strHF32 As String,
                                       ByVal strHI42 As String,
                                       ByVal strHF42 As String,
                                       ByVal strHI13 As String,
                                       ByVal strHF13 As String,
                                       ByVal strHI23 As String,
                                       ByVal strHF23 As String,
                                       ByVal strHI33 As String,
                                       ByVal strHF33 As String,
                                       ByVal strHI43 As String,
                                       ByVal strHF43 As String,
                                       ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strOriginalMachineId As String
        Dim strTableName As String
        Dim dataInicial As Date
        Dim dataFinal As Date
        Dim intDays As Integer = 0
        Dim dateEscala As Date
        Dim strDayOfWeek As String = Nothing
        Dim bolFound As Boolean = False

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strOriginalMachineId = strMachineId
            strMachineId = Convert.ToInt32(strOriginalMachineId).ToString("D6")
            strTableName = "exe_MCONTROL_OEE_" & strMachineId & "_Days"
            cmdUpdate.Connection = conSQL
            strP1 = "DELETE FROM " & strTableName & " WHERE [Data] >= '" & Mid(strDataInicial, 1, 10) & "' AND [Data] <= '" & Mid(strDataFinal, 1, 10) & "'"
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            dataInicial = Convert.ToDateTime(strDataInicial)
            dataFinal = Convert.ToDateTime(strDataFinal)
            intDays = DateDiff(DateInterval.Day, dataInicial, dataFinal)
            For IntC = 0 To intDays
                bolFound = False
                dateEscala = DateAdd(DateInterval.Day, IntC, dataInicial)
                strDayOfWeek = dateEscala.DayOfWeek.ToString
                strP1 = Nothing
                strP1 = "INSERT INTO " & strTableName & " ([Data], "
                If (strDayOfWeek = "Monday" And bolSeg1 = True) Or (strDayOfWeek = "Tuesday" And bolTer1 = True) Or (strDayOfWeek = "Wednesday" And bolQua1 = True) Or (strDayOfWeek = "Thursday" And bolQui1 = True) Or (strDayOfWeek = "Friday" And bolSex1 = True) Or (strDayOfWeek = "Saturday" And bolSab1 = True) Or (strDayOfWeek = "Sunday" And bolDom1 = True) Then
                    If bolP11 = True Then
                        strP1 = strP1 + " [T1HoraIni], [T1HoraFim]"
                    End If
                    If bolP21 = True Then
                        strP1 = strP1 + " , [T2HoraIni], [T2HoraFim]"
                    End If
                    If bolP31 = True Then
                        strP1 = strP1 + " , [T3HoraIni], [T3HoraFim]"
                    End If
                    If bolP41 = True Then
                        strP1 = strP1 + " , [T4HoraIni], [T4HoraFim]"
                    End If

                    strP1 = strP1 & ", [DayOff], [DayOfWeek]) VALUES('" & Mid(dateEscala.ToString, 1, 10) & "', '"
                    If bolP11 = True Then
                        If strHI11.Length < 19 Then
                            strHI11 = strHI11 & " 00:00:00"
                        End If
                        If strHF11.Length < 19 Then
                            strHF11 = strHF11 & " 00:00:00"
                        End If
                        strP1 = strP1 + Mid(strHI11, 12, 5) & "', '" & Mid(strHF11, 12, 5) & "'"
                    End If
                    If bolP21 = True Then
                        If strHI21.Length < 19 Then
                            strHI21 = strHI21 & " 00:00:00"
                        End If
                        If strHF21.Length < 19 Then
                            strHF21 = strHF21 & " 00:00:00"
                        End If
                        strP1 = strP1 + " , '" & Mid(strHI21, 12, 5) & "', '" & Mid(strHF21, 12, 5) & "'"
                    End If
                    If bolP31 = True Then
                        If strHI31.Length < 19 Then
                            strHI31 = strHI31 & " 00:00:00"
                        End If
                        If strHF31.Length < 19 Then
                            strHF31 = strHF31 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI31, 12, 5) & "', '" & Mid(strHF31, 12, 5) & "'"
                    End If
                    If bolP41 = True Then
                        If strHI41.Length < 19 Then
                            strHI41 = strHI41 & " 00:00:00"
                        End If
                        If strHF41.Length < 19 Then
                            strHF41 = strHF41 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI41, 12, 5) & "', '" & Mid(strHF41, 12, 5) & "'"
                    End If
                    strP1 = strP1 & ", 0, '" & strDayOfWeek & "'"
                    bolFound = True
                End If


                If (strDayOfWeek = "Monday" And bolSeg2 = True) Or (strDayOfWeek = "Tuesday" And bolTer2 = True) Or (strDayOfWeek = "Wednesday" And bolQua2 = True) Or (strDayOfWeek = "Thursday" And bolQui2 = True) Or (strDayOfWeek = "Friday" And bolSex2 = True) Or (strDayOfWeek = "Saturday" And bolSab2 = True) Or (strDayOfWeek = "Sunday" And bolDom2 = True) Then
                    If bolP12 = True Then
                        strP1 = strP1 + " [T1HoraIni], [T1HoraFim]"
                    End If
                    If bolP22 = True Then
                        strP1 = strP1 + " , [T2HoraIni], [T2HoraFim]"
                    End If
                    If bolP32 = True Then
                        strP1 = strP1 + " , [T3HoraIni], [T3HoraFim]"
                    End If
                    If boLp42 = True Then
                        strP1 = strP1 + " , [T4HoraIni], [T4HoraFim]"
                    End If
                    strP1 = strP1 & ", [DayOff], [DayOfWeek]) VALUES('" & Mid(dateEscala.ToString, 1, 10) & "', '"
                    If bolP12 = True Then
                        If strHI12.Length < 19 Then
                            strHI12 = strHI12 & " 00:00:00"
                        End If
                        If strHF12.Length < 19 Then
                            strHF12 = strHF12 & " 00:00:00"
                        End If
                        strP1 = strP1 + Mid(strHI12, 12, 5) & "', '" & Mid(strHF12, 12, 5) & "'"
                    End If
                    If bolP22 = True Then
                        If strHI22.Length < 19 Then
                            strHI22 = strHI22 & " 00:00:00"
                        End If
                        If strHF22.Length < 19 Then
                            strHF22 = strHF22 & " 00:00:00"
                        End If
                        strP1 = strP1 + " , '" & Mid(strHI22, 12, 5) & "', '" & Mid(strHF22, 12, 5) & "'"
                    End If
                    If bolP32 = True Then
                        If strHI32.Length < 19 Then
                            strHI32 = strHI32 & " 00:00:00"
                        End If
                        If strHF32.Length < 19 Then
                            strHF32 = strHF32 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI32, 12, 5) & "', '" & Mid(strHF32, 12, 5) & "'"
                    End If
                    If boLp42 = True Then
                        If strHI42.Length < 19 Then
                            strHI42 = strHI42 & " 00:00:00"
                        End If
                        If strHF42.Length < 19 Then
                            strHF42 = strHF42 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI42, 12, 5) & "', '" & Mid(strHF42, 12, 5) & "'"
                    End If
                    strP1 = strP1 & ", 0, '" & strDayOfWeek & "'"
                    bolFound = True
                End If


                If (strDayOfWeek = "Monday" And bolSeg3 = True) Or (strDayOfWeek = "Tuesday" And bolTer3 = True) Or (strDayOfWeek = "Wednesday" And bolQua3 = True) Or (strDayOfWeek = "Thursday" And bolQui3 = True) Or (strDayOfWeek = "Friday" And bolSex3 = True) Or (strDayOfWeek = "Saturday" And bolSab3 = True) Or (strDayOfWeek = "Sunday" And bolDom3 = True) Then
                    If bolP13 = True Then
                        strP1 = strP1 + " [T1HoraIni], [T1HoraFim]"
                    End If
                    If bolP23 = True Then
                        strP1 = strP1 + " , [T2HoraIni], [T2HoraFim]"
                    End If
                    If bolP33 = True Then
                        strP1 = strP1 + " , [T3HoraIni], [T3HoraFim]"
                    End If
                    If bolP43 = True Then
                        strP1 = strP1 + " , [T4HoraIni], [T4HoraFim]"
                    End If
                    strP1 = strP1 & ", [DayOff], [DayOfWeek]) VALUES('" & Mid(dateEscala.ToString, 1, 10) & "', '"
                    If bolP13 = True Then
                        If strHI13.Length < 19 Then
                            strHI13 = strHI13 & " 00:00:00"
                        End If
                        If strHF13.Length < 19 Then
                            strHF13 = strHF13 & " 00:00:00"
                        End If
                        strP1 = strP1 + Mid(strHI13, 12, 5) & "', '" & Mid(strHF13, 12, 5) & "'"
                    End If
                    If bolP23 = True Then
                        If strHI23.Length < 19 Then
                            strHI23 = strHI23 & " 00:00:00"
                        End If
                        If strHF23.Length < 19 Then
                            strHF23 = strHF23 & " 00:00:00"
                        End If
                        strP1 = strP1 + " , '" & Mid(strHI23, 12, 5) & "', '" & Mid(strHF23, 12, 5) & "'"
                    End If
                    If bolP33 = True Then
                        If strHI33.Length < 19 Then
                            strHI33 = strHI33 & " 00:00:00"
                        End If
                        If strHF33.Length < 19 Then
                            strHF33 = strHF33 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI33, 12, 5) & "', '" & Mid(strHF33, 12, 5) & "'"
                    End If
                    If bolP43 = True Then
                        If strHI43.Length < 19 Then
                            strHI33 = strHI43 & " 00:00:00"
                        End If
                        If strHF43.Length < 19 Then
                            strHF43 = strHF43 & " 00:00:00"
                        End If
                        strP1 = strP1 + " ,'" & Mid(strHI43, 12, 5) & "', '" & Mid(strHF43, 12, 5) & "'"
                    End If
                    strP1 = strP1 & ", 0, '" & strDayOfWeek & "'"
                    bolFound = True
                End If
                strP1 = strP1 & ")"
                If bolFound = False Then
                    strP1 = "INSERT INTO " & strTableName & " ([Data], [DayOff], [DayOfWeek]) VALUES ('" & Mid(dateEscala.ToString, 1, 10) & "', 1, '" & strDayOfWeek & "')"
                End If
                cmdUpdate.CommandText = strP1
                cmdUpdate.ExecuteNonQuery()
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBGERARESCALA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBVERIFICAESCALA(ByVal strMachineId As String,
                                         ByVal strDataInicial As String,
                                         ByVal strDataFinal As String,
                                         ByRef bolColision As Boolean,
                                         ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDays As New DataSet
        Dim strOriginalMachineId As String
        Dim strTableName As String

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strOriginalMachineId = strMachineId
            strMachineId = Convert.ToInt32(strOriginalMachineId).ToString("D6")
            strTableName = "exe_MCONTROL_OEE_" & strMachineId & "_Days"
            strCommand = "Select * FROM " & strTableName & " WHERE [Data] >= '" & Mid(strDataInicial, 1, 10) & "' AND [Data] <= '" & Mid(strDataFinal, 1, 10) & "'"
            Dim sqlaDays As New SqlDataAdapter(strCommand, conSQL)
            sqlaDays.Fill(dtDays, "Days")
            If dtDays.Tables(0).Rows.Count > 0 Then
                bolColision = True
            Else
                bolColision = False
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBVERIFICAESCALA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEESCALA(ByVal intMACHINEID As Integer,
                                        ByVal strDATAINICIAL As String,
                                        ByVal strDATAFINAL As String,
                                        ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strOriginalMachineId As String
        Dim strTableName As String
        Dim strMACHINEID As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strOriginalMachineId = intMACHINEID
            strMACHINEID = Convert.ToInt32(strOriginalMachineId).ToString("D6")
            strTableName = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"
            cmdUpdate.Connection = conSQL
            strP1 = "DELETE FROM " & strTableName & " WHERE [Data] >= '" & strDATAINICIAL & "' AND [Data] <= '" & strDATAFINAL & "'"
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEESCALA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTURNOS(ByVal intMAQUINAID As Integer,
                                    ByRef cbTURNO As ComboBox,
                                    ByRef cbTURNOID As ComboBox,
                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cbTURNO.Items.Clear()
            cbTURNOID.Items.Clear()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_turnos WHERE [idmaquina] = " & intMAQUINAID & " ORDER BY [nome] ASC"
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If dtTURNOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtTURNOS.Tables(0).Rows.Count - 1
                    cbTURNO.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("nome"))
                    cbTURNOID.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTURNOSESCALA(ByVal intMAQUINAID As Integer,
                                          ByRef cbTURNO As ComboBox,
                                          ByRef cbTURNOID As ComboBox,
                                          ByRef strTIME(,) As String,
                                          ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cbTURNO.Items.Clear()
            cbTURNOID.Items.Clear()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_turnos WHERE [idmaquina] = " & intMAQUINAID & " ORDER BY [nome] ASC"
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If dtTURNOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtTURNOS.Tables(0).Rows.Count - 1
                    cbTURNO.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("nome"))
                    cbTURNOID.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTURNOS_EDIT(ByVal intMACHINEID As Integer,
                                         ByRef dgvTURNO As DevComponents.DotNetBar.Controls.DataGridViewX,
                                         ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_turnos WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If dtTURNOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtTURNOS.Tables(0).Rows.Count - 1
                    dgvTURNO.Rows.Add()
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(0).Value = dtTURNOS.Tables(0).Rows(intC).Item("id")
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(1).Value = dtTURNOS.Tables(0).Rows(intC).Item("nome")
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(2).Value = dtTURNOS.Tables(0).Rows(intC).Item("horainicial1")
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(3).Value = dtTURNOS.Tables(0).Rows(intC).Item("horafinal1")
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(4).Value = dtTURNOS.Tables(0).Rows(intC).Item("horainicial2")
                    dgvTURNO.Rows(dgvTURNO.Rows.Count - 1).Cells(5).Value = dtTURNOS.Tables(0).Rows(intC).Item("horafinal2")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOS_EDIT"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATETURNO(ByVal intMACHINEID As Integer,
                                       ByVal dgvTURNO As DevComponents.DotNetBar.Controls.DataGridViewX,
                                       ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim strB1 As String = Nothing
        Dim sqldaTURNO As SqlDataAdapter
        Dim dtsTURNO As DataSet
        Dim strQUERY As String = Nothing
        Dim strHORAINICIAL1 As String = Nothing
        Dim strHORAFINAL1 As String = Nothing
        Dim strHORAINICIAL2 As String = Nothing
        Dim strHORAFINAL2 As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvTURNO.Rows.Count - 1

                If dgvTURNO.Rows(intC).Cells(2).Value.ToString.Length > 5 Then
                    strHORAINICIAL1 = Mid(dgvTURNO.Rows(intC).Cells(2).Value, 12, 5)
                Else
                    strHORAINICIAL1 = dgvTURNO.Rows(intC).Cells(2).Value
                End If
                If dgvTURNO.Rows(intC).Cells(3).Value.ToString.Length > 5 Then
                    strHORAFINAL1 = Mid(dgvTURNO.Rows(intC).Cells(3).Value, 12, 5)
                Else
                    strHORAFINAL1 = dgvTURNO.Rows(intC).Cells(3).Value
                End If
                If IsDBNull(dgvTURNO.Rows(intC).Cells(4).Value) = False Then
                    If dgvTURNO.Rows(intC).Cells(4).Value <> Nothing Then
                        If dgvTURNO.Rows(intC).Cells(4).Value.ToString.Length > 5 Then
                            strHORAINICIAL2 = Mid(dgvTURNO.Rows(intC).Cells(4).Value, 12, 5)
                        Else
                            strHORAINICIAL2 = dgvTURNO.Rows(intC).Cells(4).Value
                        End If
                    Else
                        strHORAINICIAL2 = Nothing
                    End If
                Else
                    strHORAINICIAL2 = Nothing
                End If
                If IsDBNull(dgvTURNO.Rows(intC).Cells(5).Value) = False Then
                    If dgvTURNO.Rows(intC).Cells(5).Value <> Nothing Then
                        If dgvTURNO.Rows(intC).Cells(5).Value.ToString.Length > 5 Then
                            strHORAFINAL2 = Mid(dgvTURNO.Rows(intC).Cells(5).Value, 12, 5)
                        Else
                            strHORAFINAL2 = dgvTURNO.Rows(intC).Cells(5).Value
                        End If
                    Else
                        strHORAFINAL2 = Nothing
                    End If
                Else
                    strHORAFINAL2 = Nothing
                End If

                If dgvTURNO.Rows(intC).Cells(6).Value = True Then
                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_turnos] ([idmaquina],[nome],[horainicial1],[horafinal1],[horainicial2],[horafinal2]) VALUES (" &
                            intMACHINEID & ", '" & dgvTURNO.Rows(intC).Cells(1).Value & "', '" & strHORAINICIAL1 & "','" & strHORAFINAL1 & "', '" &
                            strHORAINICIAL2 & "','" & strHORAFINAL2 & "')"
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [Id] DESC"
                    sqldaTURNO = New SqlDataAdapter(strQUERY, conSQL)
                    dtsTURNO = New DataSet
                    sqldaTURNO.Fill(dtsTURNO, "Turno")
                    dgvTURNO.Rows(intC).Cells(0).Value = dtsTURNO.Tables(0).Rows(0).Item("Id")
                    dgvTURNO.Rows(intC).Cells(6).Value = False

                ElseIf dgvTURNO.Rows(intC).Cells(7).Value = True Then
                    strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_turnos] SET [nome] = '" & dgvTURNO.Rows(intC).Cells(1).Value & "', " &
                            "[horainicial1] = '" & strHORAINICIAL1 & "', " &
                            "[horafinal1] = '" & strHORAFINAL1 & "', " &
                            "[horainicial2] = '" & strHORAINICIAL2 & "', " &
                            "[horafinal2] = '" & strHORAFINAL2 & "' " &
                            "WHERE [Id] = " & dgvTURNO.Rows(intC).Cells(0).Value & " AND [idmaquina] = " & intMACHINEID
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    dgvTURNO.Rows(intC).Cells(7).Value = False
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUPDATETURNO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETETURNO(ByVal intTURNOID As Integer,
                                       ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
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
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [id] = " & intTURNOID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEMOTIVOPARADA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBINCLUIRTURNO(ByVal intMAQUINAID As Integer,
                                        ByVal intTURNOID As Integer,
                                        ByVal bolWEEKEND As Boolean,
                                        ByVal strDATAINICIAL As String,
                                        ByVal strDATAFINAL As String,
                                        ByVal strHORAINICIAL1 As String,
                                        ByVal strHORAFINAL1 As String,
                                        ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dateINICIAL As Date = Nothing
        Dim dateFINAL As Date = Nothing
        Dim dateINCLUDE As Date = Nothing
        Dim dateEXTRA As Date = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim intDAYS As Integer = 0
        Dim strDIAINCIALCOMP As String = Nothing
        Dim strDIAFINALCOMP As String = Nothing
        Dim intBOLNEXTDAY As Boolean = False
        Dim strDAYOFWEEK As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            dateINICIAL = Convert.ToDateTime(strDATAINICIAL)
            dateFINAL = Convert.ToDateTime(strDATAFINAL)
            strMACHINEID = intMAQUINAID.ToString("D6")
            strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"

            'Elimina dados anteriores
            '////////////////////////
            strDIAINCIALCOMP = strDATAINICIAL & " " & strHORAINICIAL1
            strDIAFINALCOMP = strDATAINICIAL & " " & strHORAFINAL1
            intDAYS = DateDiff(DateInterval.Hour, Convert.ToDateTime(strDIAINCIALCOMP), Convert.ToDateTime(strDIAFINALCOMP))
            If intDAYS < 0 Then
                intBOLNEXTDAY = True
                dateEXTRA = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(strDATAFINAL))
            Else
                dateEXTRA = Convert.ToDateTime(strDATAFINAL)
            End If

            'Insere turno
            '////////////
            intDAYS = DateDiff(DateInterval.Day, dateINICIAL, dateFINAL)
            If intDAYS > 0 Then
                For intC = 0 To intDAYS
                    dateINCLUDE = DateAdd(DateInterval.Day, intC, dateINICIAL)
                    strDAYOFWEEK = dateINCLUDE.DayOfWeek.ToString
                    If intBOLNEXTDAY = False Then
                        If bolWEEKEND = True And (strDAYOFWEEK = "Saturday" Or strDAYOFWEEK = "Sunday") Then
                            GoTo NextDay
                        Else
                            strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(dateINCLUDE.ToString, 1, 10) & "',103)" &
                                        ", '" & strHORAINICIAL1 & "', '" & strHORAFINAL1 & "', " & intTURNOID & ")"
                            cmdUpdate.CommandText = strP1
                            cmdUpdate.ExecuteNonQuery()
                        End If
                    Else
                        If bolWEEKEND = True And (strDAYOFWEEK = "Saturday" Or strDAYOFWEEK = "Sunday") Then
                            GoTo NextDay
                        Else
                            strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(dateINCLUDE.ToString, 1, 10) & "',103)" &
                                       ", '" & strHORAINICIAL1 & "', '23:59:59', " & intTURNOID & ")"
                            cmdUpdate.CommandText = strP1
                            cmdUpdate.ExecuteNonQuery()
                            strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(DateAdd(DateInterval.Day, 1, dateINCLUDE).ToString, 1, 10) & "',103)" &
                                       ", '00:00:00', '" & strHORAFINAL1 & "', " & intTURNOID & ")"
                            cmdUpdate.CommandText = strP1
                            cmdUpdate.ExecuteNonQuery()
                        End If
                    End If

NextDay:
                Next

            Else
                dateINCLUDE = dateINICIAL
                strDAYOFWEEK = dateINCLUDE.DayOfWeek.ToString
                If intBOLNEXTDAY = False Then
                    If bolWEEKEND = True And (strDAYOFWEEK = "Saturday" Or strDAYOFWEEK = "Sunday") Then
                        GoTo NextDay2
                    Else
                        strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(dateINCLUDE.ToString, 1, 10) & "',103)" &
                               ", '" & strHORAINICIAL1 & "', '" & strHORAFINAL1 & "', " & intTURNOID & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                    End If
                Else
                    If bolWEEKEND = True And (strDAYOFWEEK = "Saturday" Or strDAYOFWEEK = "Sunday") Then
                        GoTo NextDay2
                    Else
                        strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(dateINCLUDE.ToString, 1, 10) & "',103)" &
                                   ", '" & strHORAINICIAL1 & "', '23:59:59', " & intTURNOID & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                        strP1 = "INSERT INTO [dbo].[" & strTABLENAME & "] ([date_shift],[time_begin],[time_end],[shift_id]) VALUES (convert(smalldatetime, '" & Mid(DateAdd(DateInterval.Day, 1, dateINCLUDE).ToString, 1, 10) & "',103)" &
                                   ", '00:00:00', '" & strHORAFINAL1 & "', " & intTURNOID & ")"
                        cmdUpdate.CommandText = strP1
                        cmdUpdate.ExecuteNonQuery()
                    End If
                End If

NextDay2:
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBINCLUIRTURNO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETSCHEDULE(ByRef cvESCALA As DevComponents.DotNetBar.Schedule.CalendarView,
                                      ByVal intMAQUINAID As Integer,
                                      ByVal strDATAINICIAL As String,
                                      ByVal strDATAFINAL As String,
                                      ByRef dtimeBLOQUEIO As DateTime,
                                      ByRef strERROR As String)

        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dateINICIAL As Date = Nothing
        Dim dateFINAL As Date = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim sqldaESCALA As SqlDataAdapter
        Dim dtsESCALA As DataSet
        Dim sqldaTURNO As SqlDataAdapter
        Dim dtsTURNO As DataSet
        Dim appESCALA(9999) As DevComponents.Schedule.Model.Appointment
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim dataINCICIAL As DateTime = Nothing
        Dim dataFINAL As DateTime = Nothing
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                    ";Initial Catalog=oViewer;" &
                    "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos]"
            sqldaTURNO = New SqlDataAdapter(strQUERY, conSQL)
            dtsTURNO = New DataSet
            sqldaTURNO.Fill(dtsTURNO, "Turno")
            strMACHINEID = intMAQUINAID.ToString("D6")
            strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"

            strQUERY = "SELECT * FROM [dbo].[" & strTABLENAME & "] WHERE [date_shift] >= convert(smalldatetime, '" & strDATAINICIAL & "',103) AND [date_shift] <= convert(smalldatetime, '" & strDATAFINAL & "',103)"
            sqldaESCALA = New SqlDataAdapter(strQUERY, conSQL)
            dtsESCALA = New DataSet
            sqldaESCALA.Fill(dtsESCALA, "Escala")

            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] WHERE [maquinaid] = " & intMAQUINAID
            sqldaBLOQUEIO = New SqlDataAdapter(strQUERY, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueio")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                dtimeBLOQUEIO = Convert.ToDateTime(dtsBLOQUEIO.Tables(0).Rows(0).Item("datetime"))
            End If
            If dtsESCALA.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsESCALA.Tables(0).Rows.Count - 1
                    appESCALA(intC) = New DevComponents.Schedule.Model.Appointment
                    For intC2 = 0 To dtsTURNO.Tables(0).Rows.Count - 1
                        If dtsESCALA.Tables(0).Rows(intC).Item("shift_id") = dtsTURNO.Tables(0).Rows(intC2).Item("id") Then
                            appESCALA(intC).Subject = dtsTURNO.Tables(0).Rows(intC2).Item("nome")
                            If dtsTURNO.Tables(0).Rows(intC2).Item("nome") = "DIA" Then
                                appESCALA(intC).CategoryColor = DevComponents.Schedule.Model.Appointment.CategoryGreen
                            ElseIf dtsTURNO.Tables(0).Rows(intC2).Item("nome") = "NOITE" Then
                                appESCALA(intC).CategoryColor = DevComponents.Schedule.Model.Appointment.CategoryBlue
                            ElseIf dtsTURNO.Tables(0).Rows(intC2).Item("nome") = "EXTRA DIA" Then
                                appESCALA(intC).CategoryColor = DevComponents.Schedule.Model.Appointment.CategoryYellow
                            ElseIf dtsTURNO.Tables(0).Rows(intC2).Item("nome") = "EXTRA NOITE" Then
                                appESCALA(intC).CategoryColor = DevComponents.Schedule.Model.Appointment.CategoryRed
                            End If
                        End If
                    Next
                    appESCALA(intC).Tag = dtsESCALA.Tables(0).Rows(intC).Item("shift_id") & "#" & dtsESCALA.Tables(0).Rows(intC).Item("id")
                    strDINICIAL = dtsESCALA.Tables(0).Rows(intC).Item("date_shift") & " " & dtsESCALA.Tables(0).Rows(intC).Item("time_begin")
                    strDFINAL = dtsESCALA.Tables(0).Rows(intC).Item("date_shift") & " " & dtsESCALA.Tables(0).Rows(intC).Item("time_end")
                    appESCALA(intC).StartTime = Convert.ToDateTime(strDINICIAL)
                    appESCALA(intC).EndTime = Convert.ToDateTime(strDFINAL)
                    appESCALA(intC).Locked = True
                    If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                        If DateDiff(DateInterval.Minute, Convert.ToDateTime(strDFINAL), dtimeBLOQUEIO) >= 0 Then
                            appESCALA(intC).TimeMarkedAs = "OutOfOffice"
                        End If
                    Else
                        appESCALA(intC).TimeMarkedAs = "Default"
                    End If
                    cvESCALA.CalendarModel.Appointments.Add(appESCALA(intC))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETSCHEDULE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETETAG(ByVal intMAQUINAID As Integer,
                                     ByVal strTURNOTAG As String,
                                     ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim arrTURNO As Array
        Dim intTURNOID As Integer = 0
        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strMACHINEID = intMAQUINAID.ToString("D6")
            arrTURNO = Split(strTURNOTAG, "#")
            intTURNOID = arrTURNO(1)
            strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"
            strP1 = "DELETE FROM [dbo].[" & strTABLENAME & "] WHERE [id] = " & intTURNOID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEPERIODO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETPARADAESCALA(ByVal intMAQUINAID As Integer,
                                          ByVal strTURNOTAG As String,
                                          ByRef bolFOUND As Boolean,
                                          ByRef strERROR As String)

        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim arrTURNO As Array
        Dim intTURNOID As Integer = 0
        Dim sqldaTURNO As SqlDataAdapter
        Dim dtsTURNO As DataSet
        Dim dtsPRODUCAO As DataSet
        Dim sqldaPRODUCAO As SqlDataAdapter
        Dim dtimeTURNOINI As DateTime = Nothing
        Dim dtimeTURNOFIM As DateTime = Nothing
        Dim strTURNOINI As String = Nothing
        Dim strTURNOFIM As String = Nothing
        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strMACHINEID = intMAQUINAID.ToString("D6")
            arrTURNO = Split(strTURNOTAG, "#")
            intTURNOID = arrTURNO(1)
            strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"
            strP1 = "SELECT * FROM [dbo].[" & strTABLENAME & "] WHERE [id] = " & intTURNOID
            sqldaTURNO = New SqlDataAdapter(strP1, conSQL)
            dtsTURNO = New DataSet
            sqldaTURNO.Fill(dtsTURNO, "Turnos")
            strTURNOINI = dtsTURNO.Tables(0).Rows(0).Item("date_shift") & " " & dtsTURNO.Tables(0).Rows(0).Item("time_begin")
            strTURNOFIM = dtsTURNO.Tables(0).Rows(0).Item("date_shift") & " " & dtsTURNO.Tables(0).Rows(0).Item("time_end")
            dtimeTURNOINI = Convert.ToDateTime(strTURNOINI)
            dtimeTURNOFIM = Convert.ToDateTime(strTURNOFIM)
            strP1 = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] INNER JOIN exe_MCONTROL_BABELFISH_idreferences ON exe_MCONTROL_BABELFISH_amarrado.id_maquinario = exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                    "WHERE exe_MCONTROL_BABELFISH_idreferences.device_id = " & intMAQUINAID & " AND [data_recebido] >= convert(datetime, '" & strTURNOINI & "',103)" &
                    " AND [data_recebido] < convert(datetime, '" & strTURNOFIM & "',103)"
            sqldaPRODUCAO = New SqlDataAdapter(strP1, conSQL)
            dtsPRODUCAO = New DataSet
            sqldaPRODUCAO.Fill(dtsPRODUCAO, "Producao")
            If dtsPRODUCAO.Tables(0).Rows.Count > 0 Then
                bolFOUND = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETPARADAESCALA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETESCALAPARADAS(ByVal intMAQUINAID As Integer,
                                           ByVal strTURNOINI As String,
                                           ByVal strTURNOFIM As String,
                                           ByRef bolFOUND As Boolean,
                                           ByRef strERROR As String)

        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim intTURNOID As Integer = 0
        Dim dtsPARADAS As DataSet
        Dim sqldaPARADAS As SqlDataAdapter
        Dim dtimeTURNOINI As DateTime = Nothing
        Dim dtimeTURNOFIM As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strP1 = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] INNER JOIN exe_MCONTROL_BABELFISH_idreferences ON exe_MCONTROL_BABELFISH_amarrado.id_maquinario = exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                    "WHERE exe_MCONTROL_BABELFISH_idreferences.device_id = " & intMAQUINAID & " AND [data_recebido] >= convert(datetime, '" & strTURNOINI & " 00:00:00',103)" &
                    " AND [data_recebido] < convert(datetime, '" & strTURNOFIM & " 23:59:59',103)"
            sqldaPARADAS = New SqlDataAdapter(strP1, conSQL)
            dtsPARADAS = New DataSet
            sqldaPARADAS.Fill(dtsPARADAS, "Paradas")
            If dtsPARADAS.Tables(0).Rows.Count > 0 Then
                bolFOUND = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETESCALAPARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEPERIODO(ByVal intMAQUINAID As Integer,
                                         ByVal strTURNOTAG As String,
                                         ByVal strDATAINICIAL As String,
                                         ByVal strDATAFINAL As String,
                                         ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim arrTURNO As Array
        Dim intTURNOID As Integer = 0
        Dim strQUERY As String = Nothing
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet
        Dim dtimeDELETEINICIAL As DateTime
        Dim dtimeDELETEFINAL As DateTime
        Dim dtimeBLOQUEIO As DateTime

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strMACHINEID = intMAQUINAID.ToString("D6")
            arrTURNO = Split(strTURNOTAG, "#")
            intTURNOID = arrTURNO(0)
            strTABLENAME = "exe_MCONTROL_OEE_" & strMACHINEID & "_Days"
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] WHERE [maquinaid] = " & intMAQUINAID
            sqldaBLOQUEIO = New SqlDataAdapter(strQUERY, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueio")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                dtimeDELETEINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDELETEFINAL = Convert.ToDateTime(strDATAFINAL)
                dtimeBLOQUEIO = Convert.ToDateTime(Mid(dtsBLOQUEIO.Tables(0).Rows(0).Item("datetime"), 1, 10))
                If dtimeBLOQUEIO >= dtimeDELETEINICIAL And dtimeBLOQUEIO <= dtimeDELETEFINAL Then
                    strDATAINICIAL = Mid(dtsBLOQUEIO.Tables(0).Rows(0).Item("datetime"), 1, 10)
                End If
                strP1 = "DELETE FROM [dbo].[" & strTABLENAME & "] WHERE [shift_id] = " & intTURNOID &
                        " AND [date_shift] > convert(smalldatetime, '" & strDATAINICIAL & "',103) AND [date_shift] <= convert(smalldatetime, '" & strDATAFINAL & "',103)"
            Else
                strP1 = "DELETE FROM [dbo].[" & strTABLENAME & "] WHERE [shift_id] = " & intTURNOID &
                        " AND [date_shift] >= convert(smalldatetime, '" & strDATAINICIAL & "',103) AND [date_shift] <= convert(smalldatetime, '" & strDATAFINAL & "',103)"
            End If
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEPERIODO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteBDSETPOOLING(ByVal intVALUE As Integer,
                                      ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            cmdUpdate.CommandText = "UPDATE [dbo].[exe_sysCmdControl] SET [Pooling] = " & intVALUE
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteBDSETPOOLING"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTURNOMAQUINA(ByVal intMACHINEID As Integer,
                                          ByRef cbTURNOINICIAL As ComboBox,
                                          ByRef cbTURNOINICIALID As ComboBox,
                                          ByRef cbTURNOFINAL As ComboBox,
                                          ByRef cbTURNOFINALID As ComboBox,
                                          ByRef strERROR As String)



        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaPERIODO As SqlDataAdapter
        Dim dtsPERIODO As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
            sqldaPERIODO = New SqlDataAdapter(strQUERY, conSQL)
            dtsPERIODO = New DataSet
            sqldaPERIODO.Fill(dtsPERIODO, "Periodo")
            If dtsPERIODO.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsPERIODO.Tables(0).Rows.Count - 1
                    cbTURNOINICIAL.Items.Add(dtsPERIODO.Tables(0).Rows(intC).Item("nome"))
                    cbTURNOINICIALID.Items.Add(dtsPERIODO.Tables(0).Rows(intC).Item("id"))
                    cbTURNOFINAL.Items.Add(dtsPERIODO.Tables(0).Rows(intC).Item("nome"))
                    cbTURNOFINALID.Items.Add(dtsPERIODO.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOMAQUINA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETPERIODOTRABALHO(ByVal intMACHINEID As Integer,
                                             ByRef dtiHINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                             ByRef dtiHFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                             ByRef strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaPERIODO As SqlDataAdapter
        Dim dtsPERIODO As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
            sqldaPERIODO = New SqlDataAdapter(strQUERY, conSQL)
            dtsPERIODO = New DataSet
            sqldaPERIODO.Fill(dtsPERIODO, "Periodo")
            If dtsPERIODO.Tables(0).Rows.Count > 0 Then
                If IsDBNull(dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")) = False Then
                    dtiHINICIAL.Value = dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                End If
                If IsDBNull(dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")) = False Then
                    dtiHFINAL.Value = dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")
                End If
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOMAQUINA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBSAVEPERIODOTRABALHO(ByVal intMACHINEID As Integer,
                                               ByVal dtiHINICIAL As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                               ByVal dtiHFINAL As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                               ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaTURNO As SqlDataAdapter
        Dim dtsTURNO As DataSet
        Dim strQUERY As String = Nothing
        Dim bolFOUND As Boolean = False
        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
            sqldaTURNO = New SqlDataAdapter(strQUERY, conSQL)
            dtsTURNO = New DataSet
            sqldaTURNO.Fill(dtsTURNO, "Turno")
            If dtsTURNO.Tables(0).Rows.Count > 0 Then
                cmdUpdate.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_periodotrabalho] SET [horarioinicial] = '" & dtiHINICIAL.Text & "', " &
                                        "[horariofinal] = '" & dtiHFINAL.Text & "' WHERE [maquinaid] = " & intMACHINEID
            Else
                cmdUpdate.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_periodotrabalho] ([maquinaid],[horarioinicial],[horariofinal]) VALUES " &
                                        "(" & intMACHINEID & ", '" & dtiHINICIAL.Text & "','" & dtiHFINAL.Text & "')"
            End If
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBSAVEPERIODOTRABALHO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETBLOQUEIOS(ByVal intMAQUINAID As Integer,
                                       ByVal strDATA As String,
                                       ByRef bolBLOQUEIO As Boolean,
                                       ByRef strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dateINICIAL As Date = Nothing
        Dim dateFINAL As Date = Nothing
        Dim strMACHINEID As String = Nothing
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet
        Dim dtimeBLOQUEIO As DateTime = Nothing
        Dim dtimeESCALA As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                    ";Initial Catalog=oViewer;" &
                    "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] WHERE [maquinaid] = " & intMAQUINAID
            sqldaBLOQUEIO = New SqlDataAdapter(strQUERY, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueio")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                dtimeBLOQUEIO = Convert.ToDateTime(dtsBLOQUEIO.Tables(0).Rows(0).Item("datetime"))
                dtimeESCALA = Convert.ToDateTime(strDATA)
                If DateDiff(DateInterval.Minute, dtimeBLOQUEIO, dtimeESCALA) < 0 Then
                    bolBLOQUEIO = True
                End If
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETBLOQUEIOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBTCOK(ByVal intCOMMAND As Integer)

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
            strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_tccontrol] SET [control] = " & intCOMMAND
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBTCOK"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTC(ByRef intCONTROL As Integer)

        Dim conSQL As SqlConnection
        Dim strConn As String
        Dim strQUERY As String = Nothing
        Dim sqldaCONTROL As SqlDataAdapter
        Dim dtsCONTROL As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_tccontrol]"
            sqldaCONTROL = New SqlDataAdapter(strQUERY, conSQL)
            dtsCONTROL = New DataSet
            sqldaCONTROL.Fill(dtsCONTROL, "Control")
            intCONTROL = dtsCONTROL.Tables(0).Rows(0).Item("control")
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTC"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "FUNÇÕES DE USO GERAL"
    Public Function Alert(ByVal strErro As String,
                         ByVal intTime As Integer,
                         Optional ByVal bolWarning As Boolean = False)

        If bolWarning = False Then
            DesktopAlert.Show("<b>omniViewer Alerta</b> - " & strErro, ChrW(&HF06A).ToString(),
                        eSymbolSet.Awesome, System.Drawing.Color.Red,
                        eDesktopAlertColor.Black, eAlertPosition.BottomRight, intTime, 1, AddressOf AlertClicked)
        Else
            DesktopAlert.Show("<b>omniViewer Alerta</b> - " & strErro, ChrW(&HF071).ToString(),
                        eSymbolSet.Awesome, System.Drawing.Color.Yellow,
                        eDesktopAlertColor.Black, eAlertPosition.BottomRight, intTime, 1, AddressOf AlertClicked)
        End If
        Return True

    End Function
    Private Sub AlertClicked(ByVal alertId As Long)

    End Sub
    Public Function Information(ByVal strInfo As String,
                                ByVal intTime As Integer)

        DesktopAlert.Show("<b>omniViewer Informa</b> - " & strInfo, ChrW(&HF024).ToString(),
                          eSymbolSet.Awesome, System.Drawing.Color.Green,
                          eDesktopAlertColor.Black, eAlertPosition.BottomRight, intTime, 1, AddressOf InfoClicked)
        Return True

    End Function
    Private Sub InfoClicked(ByVal InfoId As Long)

    End Sub
    Public Function sMessageBox(ByVal strImage As String,
                                ByVal strTitle As String,
                                ByVal strText As String,
                                ByRef taskResult As eTaskDialogResult)

        Dim imgIcon As eTaskDialogIcon
        If strImage = "I" Then
            imgIcon = eTaskDialogIcon.Exclamation
        ElseIf strImage = "Q" Then
            imgIcon = eTaskDialogIcon.Information2
        ElseIf strImage = "A" Then
            imgIcon = eTaskDialogIcon.Exclamation
        End If

        Dim info As New TaskDialogInfo("omniViewer", imgIcon, strTitle, strText, eTaskDialogButton.Yes + eTaskDialogButton.No)
        taskResult = TaskDialog.Show(info)
        Return True

    End Function
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
    Public Function CheckFormisAlreadyOpen(ByVal strForm As String,
                                           ByRef bolOpen As Boolean,
                                           ByRef intIndex As Integer)


        Try

            Dim arrForms As Array
            Dim arrFormName As Array
            Dim strFormName As String = Nothing

            'Veirifica para saber se o form do dispositivo já está aberto
            '////////////////////////////////////////////////////////////

            arrForms = Application.OpenForms.OfType(Of Form).ToArray
            For intC = 0 To arrForms.Length - 1
                arrFormName = Split(arrForms(intC).ToString, ",")
                strFormName = Trim(arrFormName(0).ToString)
                If strFormName = strForm Then
                    intIndex = intC
                    bolOpen = True
                    Return True
                End If
            Next
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>modPCP.CheckFormisAlreadyOpen</b>!"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function GetImage(ByVal resourceName As String) As Image

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim my_namespace As String = a.GetName().Name.ToString

        Try

            Dim stream As Stream = a.GetManifestResourceStream(my_namespace + "." + resourceName)
            Return DirectCast(Bitmap.FromStream(stream), Bitmap)

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

#End Region

#Region "LOG DO SISTEMA"
    Public Function WriteDBUSERLOG(ByVal strAction As String,
                                   Optional ByVal strDeviceFullName As String = Nothing)

        Dim strConn As String = Nothing
        Dim cmdAdd As New SqlCommand
        Dim strP1 As String = Nothing
        Dim strP2 As String = Nothing
        Dim strErro As String = Nothing
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            If strDeviceFullName = Nothing Then
                strP1 = "INSERT INTO [dbo].[exe_userLog] ([DateTime],[UserId],[UserName],[Action]) VALUES "
                strP2 = "(GETDATE(), " & intUSERID & ", '" & strUSERNAME & "', '" & strAction & "')"
            Else
                strP1 = "INSERT INTO [dbo].[exe_userLog] ([DateTime],[UserId],[DeviceFullName],[UserName],[Action]) VALUES "
                strP2 = "(GETDATE(), " & intUSERID & ", '" & strDeviceFullName & "', '" & strUSERNAME & "', '" & strAction & "')"
            End If
            cmdAdd.CommandText = strP1 & strP2
            cmdAdd.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>WriteDBUSERLOG</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "PERFIL DE USUÁRIO"
    Public Function ReadDBGETUSERS(ByRef cbUSER As ComboBox,
                                   ByRef cbUSERID As ComboBox,
                                   ByRef strERROR As String)

        Dim strConn As String = Nothing
        Dim dtUsers As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = "SELECT * FROM [dbo].[exe_user] ORDER BY [Name] ASC"

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaUsers As New SqlDataAdapter(strCommand, conSQL)
            sqlaUsers.Fill(dtUsers, "Usuários")
            If dtUsers.Tables(0).Rows.Count > 0 Then
                For intCount = 0 To dtUsers.Tables(0).Rows.Count - 1
                    cbUSER.Items.Add(dtUsers.Tables(0).Rows(intCount).Item("Name"))
                    cbUSERID.Items.Add(dtUsers.Tables(0).Rows(intCount).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>ReadDBGETUSERS!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try



    End Function
    Public Function ReadXMLGETMENUS(ByRef advTree As DevComponents.AdvTree.AdvTree,
                                    ByRef strImagesAG(,) As String,
                                    ByRef strErro As String)


        Dim xmlFile As New XmlDocument
        Dim xmlNode1 As XmlNode
        Dim intNodes As Integer = 0
        Dim intR As Integer = 0
        Dim intL1 As Integer = 0
        Dim intL2 As Integer = 0
        Dim advTreeNode(9999) As DevComponents.AdvTree.Node
        Dim intImages As Integer = 0

        Try

            'Verifica a existência do arquivo de permissões por grupo de usuários
            '--------------------------------------------------------------------
            If IO.File.Exists(strXMLDir & "\" & "MCONTROL_OEE_itensmenu.xml") = False Then
                strErro = "Arquivo <b>MCONTROL_OEE_itensmenu.xml</b> não encontrado!"
                ErrorLog(strErro)
                Return False
            End If

            xmlFile.Load(strXMLDir & "\" & "MCONTROL_OEE_itensmenu.xml")
            xmlNode1 = xmlFile.SelectSingleNode("oVObjStructure/Form[1]")
            For intC = 4 To xmlNode1.ChildNodes.Count - 1
                'Nivel RibPanel
                '--------------
                advTreeNode(intNodes) = New DevComponents.AdvTree.Node
                advTreeNode(intNodes).Text = xmlNode1.ChildNodes(intC).ChildNodes(0).InnerText
                advTreeNode(intNodes).Tag = xmlNode1.ChildNodes(intC).ChildNodes(1).InnerText
                advTreeNode(intNodes).CheckBoxVisible = True
                strImagesAG(intImages, 0) = xmlNode1.ChildNodes(intC).ChildNodes(1).InnerText
                strImagesAG(intImages, 1) = xmlNode1.ChildNodes(intC).ChildNodes(2).InnerText
                advTree.Nodes.Add(advTreeNode(intNodes))
                intNodes += 1
                intImages += 1
                If xmlNode1.ChildNodes(intC).ChildNodes.Count > 2 Then
                    If xmlNode1.ChildNodes(intC).ChildNodes(3).ChildNodes.Count > 3 Then
                        For intC2 = 3 To xmlNode1.ChildNodes(intC).ChildNodes.Count - 1
                            'Nivel RibBar
                            '------------
                            advTreeNode(intNodes) = New DevComponents.AdvTree.Node
                            advTreeNode(intNodes).Text = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(0).InnerText
                            advTreeNode(intNodes).Tag = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(1).InnerText
                            advTreeNode(intNodes).CheckBoxVisible = True
                            strImagesAG(intImages, 0) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(1).InnerText
                            strImagesAG(intImages, 1) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(2).InnerText
                            advTree.Nodes(intR).Nodes.Add(advTreeNode(intNodes))
                            intNodes += 1
                            intImages += 1
                            If xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes.Count > 3 Then
                                'Nivel l1Button
                                '--------------
                                For intC3 = 3 To xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes.Count - 1
                                    advTreeNode(intNodes) = New DevComponents.AdvTree.Node
                                    advTreeNode(intNodes).Text = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(0).InnerText
                                    advTreeNode(intNodes).Tag = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(1).InnerText
                                    advTreeNode(intNodes).CheckBoxVisible = True
                                    strImagesAG(intImages, 0) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(1).InnerText
                                    strImagesAG(intImages, 1) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(2).InnerText
                                    advTree.Nodes(intR).Nodes(intL1).Nodes.Add(advTreeNode(intNodes))
                                    intNodes += 1
                                    intImages += 1
                                    If xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes.Count > 3 Then
                                        'Nivel l2Button
                                        '--------------
                                        For intC4 = 3 To xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes.Count - 1
                                            advTreeNode(intNodes) = New DevComponents.AdvTree.Node
                                            advTreeNode(intNodes).Text = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(0).InnerText
                                            advTreeNode(intNodes).Tag = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(1).InnerText
                                            advTreeNode(intNodes).CheckBoxVisible = True
                                            strImagesAG(intImages, 0) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(1).InnerText
                                            strImagesAG(intImages, 1) = xmlNode1.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(2).InnerText
                                            advTree.Nodes(intR).Nodes(intL1).Nodes(intL2).Nodes.Add(advTreeNode(intNodes))
                                            intNodes += 1
                                            intImages += 1
                                        Next
                                    End If
                                    intL2 += 1
                                Next
                            End If
                            intL1 += 1
                            intL2 = 0
                        Next
                    End If
                End If
                intR += 1
                intL1 = 0
            Next
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>ReadXMLGETMENUS</b>!"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function FilladvTreeMENUIMages(ByVal advTree As DevComponents.AdvTree.AdvTree,
                                          ByVal strImagesAG(,) As String,
                                          ByRef strErro As String)

        Try

            For intc = 0 To advTree.Nodes.Count - 1
                advTree.Nodes(intc).Image = ReadDBGETIMAGES(advTree.Nodes(intc).Tag, strImagesAG)
                If advTree.Nodes(intc).Nodes.Count > 0 Then
                    For intC2 = 0 To advTree.Nodes(intc).Nodes.Count - 1
                        advTree.Nodes(intc).Nodes(intC2).Image = ReadDBGETIMAGES(advTree.Nodes(intc).Nodes(intC2).Tag, strImagesAG)
                        If advTree.Nodes(intc).Nodes(intC2).Nodes.Count > 0 Then
                            For intC3 = 0 To advTree.Nodes(intc).Nodes(intC2).Nodes.Count - 1
                                advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Image = ReadDBGETIMAGES(advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Tag, strImagesAG)
                                If advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Nodes.Count > 0 Then
                                    For intC4 = 0 To advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Nodes.Count - 1
                                        advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Nodes(intC4).Image = ReadDBGETIMAGES(advTree.Nodes(intc).Nodes(intC2).Nodes(intC3).Nodes(intC4).Tag, strImagesAG)
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>mod_MAIN.FillavTreeMENUIMages</b>!"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETIMAGES(ByVal strTag As String,
                                    ByVal strImagesAG(,) As String)

        Try

            For intC = 0 To 9999
                If strImagesAG(intC, 0) = strTag Then
                    Return imgMFiles.GetImage(strImagesAG(intC, 1))
                End If
            Next
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>ReadDBGETIMAGES!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEBLOCK(ByVal advTree As DevComponents.AdvTree.AdvTree,
                                       ByVal intUSERID As Integer,
                                       ByRef strErro As String)

        Dim cmdAdd As New SqlCommand
        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim strP2 As String = Nothing
        Dim strB1 As String = Nothing
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_userblock] Where [userid] = " & intUSERID
            cmdDelete.ExecuteNonQuery()

            For intC = 0 To advTree.Nodes.Count - 1
                'Nível RibPannel
                '////////////
                If advTree.Nodes(intC).Checked = True Then
                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_userblock] ([userid],[menutag]) VALUES (" & intUSERID & " ,'" & advTree.Nodes(intC).Tag & "')"
                    cmdAdd.CommandText = strP1
                    cmdAdd.ExecuteNonQuery()
                End If
                If advTree.Nodes(intC).HasChildNodes Then
                    For intC2 = 0 To advTree.Nodes(intC).Nodes.Count - 1
                        'Nível RibBar
                        '/////////////
                        If advTree.Nodes(intC).Nodes(intC2).Checked = True Then
                            strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_userblock] ([userid],[menutag]) VALUES (" & intUSERID & " ,'" & advTree.Nodes(intC).Nodes(intC2).Tag & "')"
                            cmdAdd.CommandText = strP1
                            cmdAdd.ExecuteNonQuery()
                        End If
                        If advTree.Nodes(intC).Nodes(intC2).HasChildNodes Then
                            For intC3 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                'Nível Button1
                                '/////////////
                                If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = True Then
                                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_userblock] ([userid],[menutag]) VALUES (" & intUSERID & " ,'" & advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Tag & "')"
                                    cmdAdd.CommandText = strP1
                                    cmdAdd.ExecuteNonQuery()
                                End If
                                If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).HasChildNodes Then
                                    For intC4 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes.Count - 1
                                        'Nível Button2
                                        '/////////////
                                        If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes(intC4).Checked = True Then
                                            strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_userblock] ([userid],[menutag]) VALUES (" & intUSERID & " ,'" & advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes(intC4).Tag & "')"
                                            cmdAdd.CommandText = strP1
                                            cmdAdd.ExecuteNonQuery()
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>clsoVDBASQL.DBUpdateBlock!</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBRGETUSERBLOCK(ByRef advTree As DevComponents.AdvTree.AdvTree,
                                        ByVal intUSEIRID As Integer,
                                        ByRef strErro As String)

        Dim strConn As String
        Dim strCommand As String = Nothing
        Dim dtGroup As New DataSet
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_userblock] WHERE [userid] =" & intUSEIRID
            Dim sqlaUsers As New SqlDataAdapter(strCommand, conSQL)
            sqlaUsers.Fill(dtGroup, "Grupos")
            For intC = 0 To advTree.Nodes.Count - 1
                advTree.Nodes(intC).Checked = False
                If advTree.Nodes(intC).Nodes.Count > 0 Then
                    For intC2 = 0 To advTree.Nodes(intC).Nodes.Count - 1
                        advTree.Nodes(intC).Nodes(intC2).Checked = False
                        If advTree.Nodes(intC).Nodes(intC2).Nodes.Count > 0 Then
                            For intC3 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = False
                                If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes.Count > 0 Then
                                    For intC4 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes.Count - 1
                                        advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes(intC4).Checked = False
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
            If dtGroup.Tables(0).Rows.Count > 0 Then
                For intC = 0 To advTree.Nodes.Count - 1
                    For intCX = 0 To dtGroup.Tables(0).Rows.Count - 1
                        If advTree.Nodes(intC).Tag = dtGroup.Tables(0).Rows(intCX).Item("MenuTag") Then
                            advTree.Nodes(intC).Checked = True
                            Exit For
                        End If
                    Next
                    If advTree.Nodes(intC).HasChildNodes Then
                        For intC2 = 0 To advTree.Nodes(intC).Nodes.Count - 1
                            For intCX = 0 To dtGroup.Tables(0).Rows.Count - 1
                                If advTree.Nodes(intC).Nodes(intC2).Tag = dtGroup.Tables(0).Rows(intCX).Item("MenuTag") Then
                                    advTree.Nodes(intC).Nodes(intC2).Checked = True
                                    Exit For
                                End If
                            Next
                            If advTree.Nodes(intC).Nodes(intC2).HasChildNodes Then
                                For intC3 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                    For intCX = 0 To dtGroup.Tables(0).Rows.Count - 1
                                        If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Tag = dtGroup.Tables(0).Rows(intCX).Item("MenuTag") Then
                                            advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = True
                                            Exit For
                                        End If
                                    Next
                                    If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).HasChildNodes Then
                                        For intc4 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes.Count - 1
                                            For intCX = 0 To dtGroup.Tables(0).Rows.Count - 1
                                                If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes(intc4).Tag = dtGroup.Tables(0).Rows(intCX).Item("MenuTag") Then
                                                    advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Nodes(intc4).Checked = True
                                                    Exit For
                                                End If
                                            Next
                                        Next
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>ReadDBRGETUSERBLOCK!</b>"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETBLOCKS(ByVal intUSERID As Integer,
                                    ByRef strERROR As String) As Boolean

        Dim arrStr As Array
        Dim intNN1 As Integer = 0
        Dim intNN2 As Integer = 0
        Dim intNN3 As Integer = 0
        Dim strN1 As String = Nothing
        Dim strN2 As String = Nothing
        Dim bolLock As Boolean = False
        Dim intBLOCKS As Integer = 0
        Dim k As String = Nothing
        Dim strMENUTAG(999) As String
        Dim strMENUTAGBLOCKED(999) As String
        Dim strMENUNAME(999) As String
        Dim intMENUTAG As Integer = 0
        Try

            If ReadXMLGETMENUSTAG(intMENUTAG, strMENUNAME, strMENUTAG, strERROR) = False Then
                Return False
            Else
                If ReadDBGETUSERBLOCKS(intUSERID, strMENUTAGBLOCKED, intBLOCKS, strERROR) = False Then
                    Return False
                End If
            End If

            'Torna Tudo Visivel para depois esconder de acordo com os bloqueios
            '//////////////////////////////////////////////////////////////////

            frm_MAIN.ribTab_CFG.Visible = True
            frm_MAIN.ribTab_MAIN.Visible = True
            frm_MAIN.ribTab_REPORT.Visible = True

            'Configurações e Ferramentas
            '///////////////////////////

            For intC = 0 To frm_MAIN.ribControl_MAIN.Controls.Count - 1
                If frm_MAIN.ribControl_MAIN.Controls(intC).HasChildren Then
                    For intC2 = 0 To frm_MAIN.ribControl_MAIN.Controls(intC).Controls.Count - 1
                        frm_MAIN.ribControl_MAIN.Controls(intC).Controls(intC2).Visible = True
                    Next
                End If
            Next

            'Controle de Acesso
            '==================
            For intC = 0 To frm_MAIN.rb_ACCESS.Items.Count - 1
                frm_MAIN.rb_ACCESS.Items(intC).Visible = True
                If frm_MAIN.rb_ACCESS.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_ACCESS.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_ACCESS.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'Cadastros Operacionais
            '//////////////////////
            For intC = 0 To frm_MAIN.rb_CADASTROS.Items.Count - 1
                frm_MAIN.rb_CADASTROS.Items(intC).Visible = True
                If frm_MAIN.rb_CADASTROS.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_CADASTROS.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_CADASTROS.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'Ferramentas
            '===========
            For intC = 0 To frm_MAIN.rb_FERRAMENTAS.Items.Count - 1
                frm_MAIN.rb_FERRAMENTAS.Items(intC).Visible = True
                If frm_MAIN.rb_FERRAMENTAS.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_FERRAMENTAS.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_FERRAMENTAS.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'Principal
            '/////////

            'Controle de Acesso
            '==================
            For intC = 0 To frm_MAIN.rb_ACCESS2.Items.Count - 1
                frm_MAIN.rb_ACCESS2.Items(intC).Visible = True
                If frm_MAIN.rb_ACCESS2.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_ACCESS2.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_ACCESS2.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'Máquinas
            '========
            For intC = 0 To frm_MAIN.rb_MAQUINAS.Items.Count - 1
                frm_MAIN.rb_MAQUINAS.Items(intC).Visible = True
                If frm_MAIN.rb_MAQUINAS.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_MAQUINAS.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_MAQUINAS.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'Relatórios
            '//////////

            'Relatórios
            '==========
            For intC = 0 To frm_MAIN.rb_REPORT.Items.Count - 1
                frm_MAIN.rb_REPORT.Items(intC).Visible = True
                If frm_MAIN.rb_REPORT.Items(intC).SubItems.Count > 0 Then
                    For intC2 = 0 To frm_MAIN.rb_REPORT.Items(intC).SubItems.Count - 1
                        frm_MAIN.rb_REPORT.Items(intC).SubItems(intC2).Visible = True
                    Next
                End If
            Next

            'BLOQUEIOS
            '/////////
            For intC = 0 To intMENUTAG
                arrStr = Split(strMENUTAG(intC), ".")
                If arrStr.Length = 2 Then
                    'Controle de enabled/disable a nível de RibbonPanel/RibonTab
                    '////////////////////////////////////////////////////////////
                    For intC2 = 0 To intBLOCKS - 1
                        If strMENUTAG(intC) = strMENUTAGBLOCKED(intC2) Then
                            If strMENUNAME(intC) = "ribPanel_CONFIG" Then
                                frm_MAIN.ribTab_CFG.Visible = False
                            ElseIf strMENUNAME(intC) = "ribPanel_MAIN" Then
                                frm_MAIN.ribTab_MAIN.Visible = False
                            ElseIf strMENUNAME(intC) = "ribPanel_REPORT" Then
                                frm_MAIN.ribTab_REPORT.Visible = False
                            End If
                            bolLock = True
                            GoTo NextItem
                        End If
                    Next

                ElseIf arrStr.Length = 3 Then

                    'Controle de enabled/disable a nível de Ribbon Bar
                    '/////////////////////////////////////////////////

                    For intC2 = 0 To intBLOCKS - 1
                        If strMENUTAG(intC) = strMENUTAGBLOCKED(intC2) Then
                            strN2 = strMENUNAME(intC)
                            strN1 = Mid(strMENUTAG(intC), 1, 3)
                            For intCX = 0 To intMENUTAG
                                If strMENUTAG(intCX) = strN1 Then
                                    strN1 = strMENUNAME(intCX)
                                    Exit For
                                End If
                            Next
                            strN2 = strMENUNAME(intC)
                            frm_MAIN.ribControl_MAIN.Controls(strN1).Controls(strN2).Visible = False
                            bolLock = True
                            GoTo NextItem
                        End If
                    Next

                ElseIf arrStr.Length = 4 Then

                    For intC2 = 0 To intBLOCKS - 1
                        If strMENUTAG(intC) = strMENUTAGBLOCKED(intC2) Then
                            intNN1 = Val(arrStr(1))
                            intNN2 = Val(arrStr(2))
                            strN1 = strMENUNAME(intC)
                            If intNN1 = 1 And intNN2 = 1 Then

                                'Controle de Acesso - Menu Configurações
                                '///////////////////////////////////////

                                For intC3 = 0 To frm_MAIN.rb_ACCESS.Items.Count - 1
                                    If frm_MAIN.rb_ACCESS.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_ACCESS.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_ACCESS.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_ACCESS.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_ACCESS.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_ACCESS.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If
                                Next

                            ElseIf intNN1 = 1 And intNN2 = 2 Then

                                'Cadastros Operacionais
                                '//////////////////////

                                For intC3 = 0 To frm_MAIN.rb_CADASTROS.Items.Count - 1
                                    If frm_MAIN.rb_CADASTROS.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_CADASTROS.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_CADASTROS.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_CADASTROS.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_CADASTROS.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_CADASTROS.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If
                                Next

                            ElseIf intNN1 = 1 And intNN2 = 3 Then

                                'Ferramentas
                                '///////////

                                For intC3 = 0 To frm_MAIN.rb_FERRAMENTAS.Items.Count - 1
                                    If frm_MAIN.rb_FERRAMENTAS.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_FERRAMENTAS.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_FERRAMENTAS.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If

                                Next

                            ElseIf intNN1 = 2 And intNN2 = 1 Then

                                'Controle de Acesso 2 - Menu Principal
                                '/////////////////////////////////////

                                For intC3 = 0 To frm_MAIN.rb_ACCESS2.Items.Count - 1
                                    If frm_MAIN.rb_ACCESS2.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_ACCESS2.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_ACCESS2.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_ACCESS2.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_ACCESS2.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_ACCESS2.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If

                                Next

                            ElseIf intNN1 = 2 And intNN2 = 2 Then

                                'Máquinas
                                '////////

                                For intC3 = 0 To frm_MAIN.rb_MAQUINAS.Items.Count - 1
                                    If frm_MAIN.rb_MAQUINAS.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_MAQUINAS.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_MAQUINAS.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If
                                Next

                            ElseIf intNN1 = 3 And intNN2 = 1 Then

                                'Relatórios
                                '//////////

                                For intC3 = 0 To frm_MAIN.rb_REPORT.Items.Count - 1
                                    If frm_MAIN.rb_REPORT.Items(intC3).IsContainer Then
                                        For intCX1 = 0 To frm_MAIN.rb_REPORT.Items(intC3).SubItems.Count - 1
                                            If frm_MAIN.rb_REPORT.Items(intC3).SubItems(intCX1).Name = strN1 Then
                                                frm_MAIN.rb_REPORT.Items(intC3).SubItems(intCX1).Visible = False
                                                bolLock = True
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If frm_MAIN.rb_REPORT.Items(intC3).Name = strN1 Then
                                            frm_MAIN.rb_REPORT.Items(intC3).Visible = False
                                            bolLock = True
                                            Exit For
                                        End If
                                    End If
                                Next

                            End If
                        End If
                    Next

                ElseIf arrStr.Length = 5 Then

                    For intC2 = 0 To intBLOCKS - 1

                        If strMENUTAG(intC) = strMENUTAGBLOCKED(intC2) Then
                            intNN1 = Val(arrStr(1))
                            intNN2 = Val(arrStr(2))
                            strN1 = strMENUNAME(intC)

                            If intNN1 = 1 And intNN2 = 1 Then

                                'Controle de Acesso - Menu Configurações
                                '///////////////////////////////////////

                                For intC3 = 0 To frm_MAIN.rb_ACCESS.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_ACCESS.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_ACCESS.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_ACCESS.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            ElseIf intNN1 = 1 And intNN2 = 2 Then

                                'Cadastros Operacionais
                                '//////////////////////

                                For intC3 = 0 To frm_MAIN.rb_CADASTROS.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_CADASTROS.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_CADASTROS.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_CADASTROS.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            ElseIf intNN1 = 1 And intNN2 = 3 Then

                                'Ferramentas
                                '///////////

                                For intC3 = 0 To frm_MAIN.rb_FERRAMENTAS.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_FERRAMENTAS.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            ElseIf intNN1 = 2 And intNN2 = 1 Then

                                'Controle de Acesso 2 - Menu Principal
                                '/////////////////////////////////////

                                For intC3 = 0 To frm_MAIN.rb_ACCESS2.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_ACCESS2.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_ACCESS2.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_ACCESS2.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            ElseIf intNN1 = 2 And intNN2 = 2 Then

                                'Máquinas
                                '////////

                                For intC3 = 0 To frm_MAIN.rb_MAQUINAS.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_MAQUINAS.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            ElseIf intNN1 = 3 And intNN2 = 1 Then

                                'Relatórios
                                '//////////

                                For intC3 = 0 To frm_MAIN.rb_REPORT.Items.Count - 1
                                    For intC4 = 0 To frm_MAIN.rb_REPORT.Items(intC3).SubItems.Count - 1
                                        If frm_MAIN.rb_REPORT.Items(intC3).SubItems(intC4).Name = strN1 Then
                                            frm_MAIN.rb_REPORT.Items(intC3).SubItems(intC4).Visible = False
                                            bolLock = True
                                            GoTo NextItem
                                        End If
                                    Next
                                Next

                            End If
                        End If
                    Next

                End If
NextItem:

            Next
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>ReadDBGETBLOCKS</b>!"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadXMLGETMENUSTAG(ByRef intMENUTAG As Integer,
                                       ByRef strMENUNAME() As String,
                                       ByRef strMENUTAG() As String,
                                       ByRef strErro As String) As Boolean

        Dim intCObj As Integer = 0

        Try
            'Verifica a existência do arquivo de configuração
            '------------------------------------------------
            If IO.File.Exists(strXMLDir & "\MCONTROL_OEE_itensmenu.xml") = False Then
                strErro = "Arquivo MCONTROL_OEE_itensmenu.xml não encontrado!"
                ErrorLog(strErro)
                Return False
            End If

            'Acessa arquivo xml de configuração
            '----------------------------------
            Dim xmlFile As New XmlDocument

            xmlFile.Load(strXMLDir & "\MCONTROL_OEE_itensmenu.xml")
            Dim xmlNodes As XmlNodeList

            'lê a estrutura de menus A nível de RibTab
            '-----------------------------------------
            xmlNodes = xmlFile.GetElementsByTagName("RibTab")
            For intC = 0 To xmlNodes.Count - 1
                strMENUNAME(intCObj) = xmlNodes.Item(intC).Attributes.GetNamedItem("Name").Value
                strMENUTAG(intCObj) = xmlNodes.Item(intC).ChildNodes(1).InnerText
                intCObj += 1
            Next

            'lê a estrutura de menus A nível de RibBar
            '-----------------------------------------
            xmlNodes = xmlFile.GetElementsByTagName("RibBar")
            For intC = 0 To xmlNodes.Count - 1
                strMENUNAME(intCObj) = xmlNodes.Item(intC).Attributes.GetNamedItem("Name").Value
                strMENUTAG(intCObj) = xmlNodes.Item(intC).ChildNodes(1).InnerText
                intCObj += 1
            Next

            xmlNodes = xmlFile.GetElementsByTagName("l1Button")
            For intC = 0 To xmlNodes.Count - 1
                strMENUNAME(intCObj) = xmlNodes.Item(intC).Attributes.GetNamedItem("Name").Value
                strMENUTAG(intCObj) = xmlNodes.Item(intC).ChildNodes(1).InnerText
                intCObj += 1
            Next

            xmlNodes = xmlFile.GetElementsByTagName("l2Button")
            For intC = 0 To xmlNodes.Count - 1
                strMENUNAME(intCObj) = xmlNodes.Item(intC).Attributes.GetNamedItem("Name").Value
                strMENUTAG(intCObj) = xmlNodes.Item(intC).ChildNodes(1).InnerText
                intCObj += 1
            Next

            xmlNodes = xmlFile.GetElementsByTagName("l3Button")
            For intC = 0 To xmlNodes.Count - 1
                strMENUNAME(intCObj) = xmlNodes.Item(intC).Attributes.GetNamedItem("Name").Value
                strMENUTAG(intCObj) = xmlNodes.Item(intC).ChildNodes(1).InnerText
                intCObj += 1
            Next
            intMENUTAG = intCObj - 1
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função <b>ReadXMLGETMENUSTAG!"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETUSERBLOCKS(ByVal intUSERID As String,
                                        ByRef strMENUTAGBLOCKED() As String,
                                        ByRef intBLOCKS As Integer,
                                        ByRef strERROR As String)

        Dim strConn As String
        Dim strCommand As String = Nothing
        Dim dtGroup As New DataSet
        Dim conSQL As SqlConnection

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_userblock] WHERE [userid] =" & intUSERID
            Dim sqlaUsers As New SqlDataAdapter(strCommand, conSQL)
            sqlaUsers.Fill(dtGroup, "Grupos")
            If dtGroup.Tables(0).Rows.Count > 0 Then
                intBLOCKS = dtGroup.Tables(0).Rows.Count
                For intC = 0 To dtGroup.Tables(0).Rows.Count - 1
                    strMENUTAGBLOCKED(intC) = dtGroup.Tables(0).Rows(intC).Item("menutag")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>ReadDBGETUSERBLOCKS!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function RELEASEALLMENU(ByRef strERROR As String) As Boolean

        'LIBERA O ACESSO A TODOS OS OBJETOS DO FORMULÁRIO MAIN
        '=====================================================
        Dim arrStr As Array
        Dim intNN1, intNN2 As Integer
        Dim strN1, strN2 As String
        Dim intMENUTAG As Integer = 0
        Dim strMENUNAME(999) As String
        Dim strMENUTAG(999) As String

        Try
            If ReadXMLGETMENUSTAG(intMENUTAG, strMENUNAME, strMENUTAG, strERROR) = False Then
                Return False
            End If

            For intC2 = 0 To intMENUTAG
                arrStr = Split(strMENUTAG(intC2), ".")

                If arrStr.Length = 2 Then

                    frm_MAIN.ribControl_MAIN.Controls(strMENUNAME(intC2)).Enabled = True
                    frm_MAIN.ribControl_MAIN.Controls(strMENUNAME(intC2)).Visible = True

                ElseIf arrStr.Length = 3 Then

                    strN1 = Mid(strMENUTAG(intC2), 1, 3)
                    For intC3 = 0 To intMENUTAG
                        If strMENUTAG(intC3) = strN1 Then
                            strN1 = strMENUNAME(intC3)
                            Exit For
                        End If
                    Next
                    strN2 = strMENUNAME(intC2)
                    frm_MAIN.ribControl_MAIN.Controls(strN1).Controls(strN2).Enabled = True

                ElseIf arrStr.Length = 4 Then

                    intNN1 = Val(arrStr(1))
                    intNN2 = Val(arrStr(2))

                    'Controle de Acesso
                    '==================
                    If intNN1 = 1 And intNN2 = 1 Then
                        For intC4 = 0 To frm_MAIN.rb_ACCESS.Items.Count - 1
                            If frm_MAIN.rb_ACCESS.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_ACCESS.Items(intC4).Enabled = True
                                For intC5 = 0 To frm_MAIN.rb_ACCESS.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_ACCESS.Items(intC4).SubItems(intC5).Enabled = True
                                    If frm_MAIN.rb_ACCESS.Items(intC4).SubItems(intC5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_ACCESS.Items(intC4).SubItems(intC5).SubItems.Count - 1
                                            frm_MAIN.rb_ACCESS.Items(intC4).SubItems(intC5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_ACCESS.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Cadastros Operacionais
                    '======================
                    If intNN1 = 1 And intNN2 = 2 Then
                        For intC4 = 0 To frm_MAIN.rb_CADASTROS.Items.Count - 1
                            If frm_MAIN.rb_CADASTROS.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_CADASTROS.Items(intC4).Enabled = True
                                For intC5 = 0 To frm_MAIN.rb_CADASTROS.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_CADASTROS.Items(intC4).SubItems(intC5).Enabled = True
                                    If frm_MAIN.rb_CADASTROS.Items(intC4).SubItems(intC5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_CADASTROS.Items(intC4).SubItems(intC5).SubItems.Count - 1
                                            frm_MAIN.rb_CADASTROS.Items(intC4).SubItems(intC5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_CADASTROS.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Ferramentas
                    '===========
                    If intNN1 = 1 And intNN2 = 3 Then
                        For intC4 = 0 To frm_MAIN.rb_FERRAMENTAS.Items.Count - 1
                            If frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_FERRAMENTAS.Items(intC4).Enabled = True
                                For intC5 = 0 To frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems(intC5).Enabled = True
                                    If frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems(intC5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems(intC5).SubItems.Count - 1
                                            frm_MAIN.rb_FERRAMENTAS.Items(intC4).SubItems(intC5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_FERRAMENTAS.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Controle de Acesso 2
                    '====================
                    If intNN1 = 2 And intNN2 = 1 Then
                        For intC4 = 0 To frm_MAIN.rb_ACCESS2.Items.Count - 1
                            If frm_MAIN.rb_ACCESS2.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_ACCESS2.Items(intC4).Enabled = True
                                For intC5 = 0 To frm_MAIN.rb_ACCESS2.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_ACCESS2.Items(intC4).SubItems(intC5).Enabled = True
                                    If frm_MAIN.rb_ACCESS2.Items(intC4).SubItems(intC5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_ACCESS2.Items(intC4).SubItems(intC5).SubItems.Count - 1
                                            frm_MAIN.rb_ACCESS2.Items(intC4).SubItems(intC5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_ACCESS2.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Máquinas
                    '========
                    If intNN1 = 2 And intNN2 = 2 Then
                        For intC4 = 0 To frm_MAIN.rb_MAQUINAS.Items.Count - 1
                            If frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_MAQUINAS.Items(intC4).Enabled = True
                                For intC5 = 0 To frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems(intC5).Enabled = True
                                    If frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems(intC5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems(intC5).SubItems.Count - 1
                                            frm_MAIN.rb_MAQUINAS.Items(intC4).SubItems(intC5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_MAQUINAS.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Gráficos
                    '========
                    If intNN1 = 3 And intNN2 = 1 Then
                        For intC4 = 0 To frm_MAIN.rb_GRAFICOS.Items.Count - 1
                            If frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_GRAFICOS.Items(intC4).Enabled = True
                                For INTc5 = 0 To frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems(INTc5).Enabled = True
                                    If frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems(INTc5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems(INTc5).SubItems.Count - 1
                                            frm_MAIN.rb_GRAFICOS.Items(intC4).SubItems(INTc5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_GRAFICOS.Items(intC4).Enabled = True
                            End If
                        Next
                    End If

                    'Relatórios
                    '==========
                    If intNN1 = 4 And intNN2 = 1 Then
                        For intC4 = 0 To frm_MAIN.rb_REPORT.Items.Count - 1
                            If frm_MAIN.rb_REPORT.Items(intC4).SubItems.Count > 0 Then
                                frm_MAIN.rb_REPORT.Items(intC4).Enabled = True
                                For INTc5 = 0 To frm_MAIN.rb_REPORT.Items(intC4).SubItems.Count - 1
                                    frm_MAIN.rb_REPORT.Items(intC4).SubItems(INTc5).Enabled = True
                                    If frm_MAIN.rb_REPORT.Items(intC4).SubItems(INTc5).SubItems.Count > 0 Then
                                        For IntCX = 0 To frm_MAIN.rb_REPORT.Items(intC4).SubItems(INTc5).SubItems.Count - 1
                                            frm_MAIN.rb_REPORT.Items(intC4).SubItems(INTc5).SubItems(IntCX).Enabled = True
                                        Next
                                    End If
                                Next
                            Else
                                frm_MAIN.rb_REPORT.Items(intC4).Enabled = True
                            End If
                        Next
                    End If


                End If
            Next
            frm_MAIN.ribControl_MAIN.Refresh()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>RELEASEALLMENU</b>!"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "GRÁFICOS - PARETO"
    Public Function ReadDBGETMACHINE_PARETO(ByRef lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                            ByRef lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                            ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_Maquinas ORDER BY [Descricao] ASC"
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If dtTURNOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtTURNOS.Tables(0).Rows.Count - 1
                    lbMAQUINA.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("Descricao"))
                    lbMAQUINAID.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMACHINE_PARETO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadFBGETTURNOS_PARETO(ByVal intMACHINEID As Integer,
                                           ByRef lbTURNO As DevComponents.DotNetBar.ListBoxAdv,
                                           ByRef lbTURNOID As DevComponents.DotNetBar.ListBoxAdv,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_turnos WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If dtTURNOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtTURNOS.Tables(0).Rows.Count - 1
                    lbTURNO.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("nome"))
                    lbTURNOID.Items.Add(dtTURNOS.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadFBGETTURNOS_PARETO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETNIVEL1(ByRef lbNIVEL1 As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef lbNIVEL1ID As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtNIVEL1 As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "Select * FROM exe_MCONTROL_OEE_motivosnivel1 ORDER BY [descricao] ASC"
            Dim sqlaNIVEL1 As New SqlDataAdapter(strCommand, conSQL)
            sqlaNIVEL1.Fill(dtNIVEL1, "Nivel1")
            If dtNIVEL1.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtNIVEL1.Tables(0).Rows.Count - 1
                    lbNIVEL1.Items.Add(dtNIVEL1.Tables(0).Rows(intC).Item("descricao"))
                    lbNIVEL1ID.Items.Add(dtNIVEL1.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETNIVEL1"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETNIVEL2(ByVal lbNIVEL1ID As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef lbNIVEL2 As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef lbNIVEL2ID As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqlaNIVEL2(999) As SqlDataAdapter
        Dim dtNIVEL2(999) As DataSet
        Dim strNIVEL1 As String
        Dim arrNIVEL2 As Array
        Dim strNIVEL2 As String = Nothing
        Dim bolFOUND As Boolean = False

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            'Remove os itens descelecionados
            '////////////////////////////////
            If lbNIVEL1ID.CheckedItems.Count = 0 Then
                lbNIVEL2.Items.Clear()
                lbNIVEL2ID.Items.Clear()
            Else
                For intC = lbNIVEL2ID.Items.Count - 1 To 0 Step -1
                    arrNIVEL2 = Split(lbNIVEL2ID.Items(intC), "#")
                    For intC2 = 0 To lbNIVEL1ID.CheckedItems.Count - 1
                        If arrNIVEL2(0).ToString = lbNIVEL1ID.CheckedItems(intC2).ToString Then
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        lbNIVEL2.Items.RemoveAt(intC)
                        lbNIVEL2ID.Items.RemoveAt(intC)
                    Else
                        bolFOUND = False
                    End If
                Next
            End If

            'Inclui items
            '////////////
            For intC = 0 To lbNIVEL1ID.CheckedItems.Count - 1
                strNIVEL1 = lbNIVEL1ID.CheckedItems(intC).Text
                strCommand = "Select * FROM exe_MCONTROL_OEE_motivosnivel2 WHERE [idnivel1] = " & strNIVEL1 & " ORDER BY [descricao] ASC"
                sqlaNIVEL2(intC) = New SqlDataAdapter(strCommand, conSQL)
                dtNIVEL2(intC) = New DataSet
                sqlaNIVEL2(intC).Fill(dtNIVEL2(intC), "Nivel2")
                If dtNIVEL2(intC).Tables(0).Rows.Count > 0 Then
                    bolFOUND = False
                    For intC2 = 0 To lbNIVEL2ID.Items.Count - 1
                        arrNIVEL2 = Split(lbNIVEL2ID.Items(intC2), "#")
                        If strNIVEL1 = arrNIVEL2(0) Then
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        For intC2 = 0 To dtNIVEL2(intC).Tables(0).Rows.Count - 1
                            lbNIVEL2.Items.Add(dtNIVEL2(intC).Tables(0).Rows(intC2).Item("descricao"))
                            lbNIVEL2ID.Items.Add(strNIVEL1 & "#" & dtNIVEL2(intC).Tables(0).Rows(intC2).Item("id"))
                        Next
                    End If
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETNIVEL2"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETNIVEL3(ByVal lbNIVEL2ID As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef lbNIVEL3 As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef lbNIVEL3ID As DevComponents.DotNetBar.ListBoxAdv,
                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqlaNIVEL3(999) As SqlDataAdapter
        Dim dtNIVEL3(999) As DataSet
        Dim arrNIVEL2 As Array
        Dim strNIVEL2 As String
        Dim arrNIVEL3 As Array
        Dim strNIVEL3 As String = Nothing
        Dim bolFOUND As Boolean = False

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            'Remove os itens descelecionados
            '////////////////////////////////
            If lbNIVEL2ID.CheckedItems.Count = 0 Then
                lbNIVEL3.Items.Clear()
                lbNIVEL3ID.Items.Clear()
            Else
                For intC = lbNIVEL3ID.Items.Count - 1 To 0 Step -1
                    arrNIVEL3 = Split(lbNIVEL3ID.Items(intC), "#")
                    For intC2 = 0 To lbNIVEL2ID.CheckedItems.Count - 1
                        If arrNIVEL3(0).ToString = lbNIVEL2ID.CheckedItems(intC2).ToString Then
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        lbNIVEL3.Items.RemoveAt(intC)
                        lbNIVEL3ID.Items.RemoveAt(intC)
                    Else
                        bolFOUND = False
                    End If
                Next
            End If

            'Inclui items
            '////////////
            For intC = 0 To lbNIVEL2ID.CheckedItems.Count - 1
                arrNIVEL2 = Split(lbNIVEL2ID.CheckedItems(intC).Text, "#")
                strNIVEL2 = arrNIVEL2(1).ToString
                strCommand = "Select * FROM exe_MCONTROL_OEE_motivosnivel3 WHERE [idnivel2] = " & strNIVEL2 & " ORDER BY [descricao] ASC"
                sqlaNIVEL3(intC) = New SqlDataAdapter(strCommand, conSQL)
                dtNIVEL3(intC) = New DataSet
                sqlaNIVEL3(intC).Fill(dtNIVEL3(intC), "Nivel3")
                If dtNIVEL3(intC).Tables(0).Rows.Count > 0 Then
                    bolFOUND = False
                    For intC2 = 0 To lbNIVEL3ID.Items.Count - 1
                        arrNIVEL3 = Split(lbNIVEL3ID.Items(intC2), "#")
                        If strNIVEL2 = arrNIVEL3(0) Then
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        For intC2 = 0 To dtNIVEL3(intC).Tables(0).Rows.Count - 1
                            lbNIVEL3.Items.Add(dtNIVEL3(intC).Tables(0).Rows(intC2).Item("descricao"))
                            lbNIVEL3ID.Items.Add(strNIVEL2 & "#" & dtNIVEL3(intC).Tables(0).Rows(intC2).Item("id"))
                        Next
                    End If
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETNIVEL3"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHART_PARETO(ByVal strDATAINICIAL As String,
                                       ByVal strHORAINICIAL As String,
                                       ByVal strDATAFINAL As String,
                                       ByVal strHORAFINAL As String,
                                       ByVal lbMAQUINASID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL1ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL2ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL3ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbTURNO As DevComponents.DotNetBar.ListBoxAdv,
                                       ByRef Chart As DevComponents.DotNetBar.Charts.ChartXy,
                                       ByRef Chart2 As DevComponents.DotNetBar.Charts.ChartXy,
                                       ByRef strERROR As String)


        Dim strQUERY As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaPARADAS As SqlDataAdapter
        Dim dtPARADAS As DataSet
        Dim strMOTIVOS(99, 10) As String
        Dim intPARADAS As Integer = 0
        Dim intTIMEPARADA As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim chrtSeries As ChartSeries
        Dim chrtPoints As SeriesPoint
        Dim chrtSeries2 As ChartSeries
        Dim chrtPoints2 As SeriesPoint
        Dim arrNIVEL As Array
        Dim strTURNOS(99, 1) As String
        Dim intTURNOS As Integer = 0
        Dim sqldaTURNOS(99) As SqlDataAdapter
        Dim dtTURNOS(99) As DataSet
        Dim strQUERYTURNO As String = Nothing
        Dim dateDAYINI As DateTime = Nothing
        Dim dateDAYEND As DateTime = Nothing
        Dim dateBEGIN As DateTime = Nothing
        Dim dateFINISH As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim arrDAY As Array = Nothing
        Dim dateDAY As DateTime = Nothing
        Dim strDAY As String = Nothing
        Dim strTEMP(3) As String
        Dim intCONTROLE As Integer = 0
        Dim decTTOTALPARADAS As Decimal = 0D

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            'Seleção de Máquinas
            '///////////////////
            If lbMAQUINASID.CheckedItems.Count = 1 Then
                strQUERY = "Select * FROM [exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " &
                            lbMAQUINASID.CheckedItems(0).ToString & " "
            Else
                For intC = 0 To lbMAQUINASID.CheckedItems.Count - 1
                    If intC = 0 Then
                        strQUERY = "Select * FROM [exe_MCONTROL_OEE_HistoricoParadas] WHERE ([MachineId] = " &
                                   lbMAQUINASID.CheckedItems(intC).ToString & " "
                    Else
                        strQUERY += "Or [MachineId] = " & lbMAQUINASID.CheckedItems(intC).ToString & " "
                    End If
                Next
                strQUERY = Mid(strQUERY, 1, strQUERY.Length - 1)
                strQUERY += ")"
            End If

            'Seleção do Motivo de Parada de Máquina
            '//////////////////////////////////////
            If lbNIVEL1ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL1ID.CheckedItems.Count - 1
                    If intC = 0 Then
                        strQUERY += "And ([MotivoId] = " & lbNIVEL1ID.CheckedItems(intC).ToString & " "
                    Else
                        strQUERY += "Or [MotivoId] = " & lbNIVEL1ID.CheckedItems(intC).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            If lbNIVEL2ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL2ID.CheckedItems.Count - 1
                    arrNIVEL = Split(lbNIVEL2ID.CheckedItems(intC).ToString, "#")
                    If intC = 0 Then
                        strQUERY += " And ([motivonivel2] = " & arrNIVEL(1).ToString & " "
                    Else
                        strQUERY += "Or [motivonivel2] = " & arrNIVEL(1).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            If lbNIVEL3ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL3ID.CheckedItems.Count - 1
                    arrNIVEL = Split(lbNIVEL3ID.CheckedItems(intC).ToString, "#")
                    If intC = 0 Then
                        strQUERY += "And ([motivonivel3] = " & arrNIVEL(1).ToString & " "
                    Else
                        strQUERY += "Or [motivonivel3] = " & arrNIVEL(1).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            'Turno
            '//////
            If lbTURNO.CheckedItems.Count > 0 Then
                For intC = 0 To lbTURNO.CheckedItems.Count - 1
                    strQUERYTURNO = "Select * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [nome] = '" & lbTURNO.CheckedItems(intC).ToString & "'"
                    sqldaTURNOS(intC) = New SqlDataAdapter(strQUERYTURNO, conSQL)
                    dtTURNOS(intC) = New DataSet
                    sqldaTURNOS(intC).Fill(dtTURNOS(intC), "Turnos")
                    For intC2 = 0 To dtTURNOS(intC).Tables(0).Rows.Count - 1
                        strTURNOS(intTURNOS, 0) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial1")
                        strTURNOS(intTURNOS, 1) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horafinal1")
                        If dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial2") <> Nothing Then
                            intTURNOS += 1
                            strTURNOS(intTURNOS, 0) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial2")
                            strTURNOS(intTURNOS, 1) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horafinal2")
                        End If
                        intTURNOS += 1
                    Next
                Next
            End If

            strQUERY += " And [DateTimeOn] >= @DI AND [DateTimeOff] Is Not NULL And [DateTimeOff] <= @DF AND [MotivoId] IS NOT NULL"
            sqldaPARADAS = New SqlDataAdapter(strQUERY, conSQL)
            dtPARADAS = New DataSet
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)))
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)))
            sqldaPARADAS.Fill(dtPARADAS, "Paradas")
            If dtPARADAS.Tables(0).Rows.Count > 0 Then
                For intC2 = 0 To dtPARADAS.Tables(0).Rows.Count - 1
                    If intTURNOS > 0 Then
                        For intC3 = 0 To intTURNOS - 1
                            bolFOUND = False
                            arrDAY = Split(dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn"), " ")
                            dateDAYINI = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 0))
                            dateDAYEND = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 1))
                            intDAYS = DateDiff(DateInterval.Minute, dateDAYINI, dateDAYEND)
                            If intDAYS < 0 Then
                                dateDAY = Convert.ToDateTime(arrDAY(0).ToString)
                                dateDAY = DateAdd(DateInterval.Day, 1, dateDAY)
                                arrDAY = Split(dateDAY, " ")
                                dateDAYEND = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 1))
                            End If
                            If dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") <= dateDAYINI And
                                   dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") >= dateDAYEND Then

                                dateBEGIN = dateDAYINI
                                dateFINISH = dateDAYEND
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") >= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") <= dateDAYEND Then

                                dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                                dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") <= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") > dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") <= dateDAYEND Then

                                dateBEGIN = dateDAYINI
                                dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") >= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") < dateDAYEND And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") >= dateDAYEND Then

                                dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                                dateFINISH = dateDAYEND
                                bolFOUND = True

                            End If
                            If bolFOUND = True Then
                                bolFOUND = False
                                If intPARADAS > 0 Then
                                    For intC4 = 0 To intPARADAS - 1
                                        If strMOTIVOS(intC4, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId") Then
                                            intTIMEPARADA = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                                            strMOTIVOS(intC4, 2) = Convert.ToInt32(strMOTIVOS(intC4, 2)) + intTIMEPARADA
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next
                                    If bolFOUND = False Then
                                        strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                                        intPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If
                                Else
                                    strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                    strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                    strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                                    intPARADAS += 1
                                End If
                            End If
                        Next

                    Else
                        dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                        dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                        If intPARADAS > 0 Then
                            For intC4 = 0 To intPARADAS - 1
                                If strMOTIVOS(intC4, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId") Then
                                    intTIMEPARADA = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                                    strMOTIVOS(intC4, 2) = Convert.ToInt32(strMOTIVOS(intC4, 2)) + intTIMEPARADA
                                    bolFOUND = True
                                    Exit For
                                End If
                            Next
                            If bolFOUND = False Then
                                strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                                intPARADAS += 1
                            Else
                                bolFOUND = False
                            End If
                        Else
                            strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                            strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                            strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Second, dateBEGIN, dateFINISH)
                            intPARADAS += 1
                        End If
                    End If

                Next
            End If
            conSQL.Close()

            'Coloca o gráfico do maior valor pelo menor valor
            '/////////////////////////////////////////////////
            If intPARADAS > 1 Then
                intCONTROLE = 1
                For intC = 0 To intPARADAS - 2
                    strTEMP(0) = strMOTIVOS(intC, 0)
                    strTEMP(1) = strMOTIVOS(intC, 1)
                    strTEMP(2) = strMOTIVOS(intC, 2)
                    For intC2 = intCONTROLE To intPARADAS - 1
                        If Val(strTEMP(2)) < Val(strMOTIVOS(intC2, 2)) Then
                            strMOTIVOS(intC, 0) = strMOTIVOS(intC2, 0)
                            strMOTIVOS(intC, 1) = strMOTIVOS(intC2, 1)
                            strMOTIVOS(intC, 2) = strMOTIVOS(intC2, 2)
                            strMOTIVOS(intC2, 0) = strTEMP(0)
                            strMOTIVOS(intC2, 1) = strTEMP(1)
                            strMOTIVOS(intC2, 2) = strTEMP(2)
                            strTEMP(0) = strMOTIVOS(intC, 0)
                            strTEMP(1) = strMOTIVOS(intC, 1)
                            strTEMP(2) = strMOTIVOS(intC, 2)
                        End If
                    Next
                    intCONTROLE += 1
                Next
            End If

            For intC = 0 To intPARADAS - 1
                strMOTIVOS(intC, 2) = Convert.ToInt32(strMOTIVOS(intC, 2)) / 60
            Next
            'Geração do Gráfico
            '//////////////////

            Chart.ChartSeries.Clear()
            Chart.BarWidthRatio = 3
            Chart.AxisY.AxisAlignment = AxisAlignment.Far 'Y no lado esquerdo do gráfico
            Chart.AxisY.Title.RotateDegrees = Style.RotateDegrees.Rotate270
            Chart.AxisY.Title.ChartTitleVisualStyle.Alignment = Style.Alignment.TopCenter
            Chart.AxisY.Title.Text = "minutos"
            Chart.AxisX.Visible = True
            Chart.AxisX.MajorGridLines.GridLinesVisualStyle.LinePattern = Style.LinePattern.Dash
            Chart.Legend.Visible = False
            Chart.ChartCrosshair.Visible = False
            chrtSeries = New ChartSeries
            Chart.ChartSeries.Add(chrtSeries)
            Chart.ChartSeries(0).SeriesType = SeriesType.VerticalBar 'linha
            Chart.ChartSeries(0).PointLabelDisplayMode = PointLabelDisplayMode.AllSeriesPoints
            For intC = 0 To intPARADAS - 1
                chrtPoints = New SeriesPoint
                chrtPoints.ValueX = strMOTIVOS(intC, 1)
                chrtPoints.ValueY = New Object() {CType(Convert.ToDecimal(strMOTIVOS(intC, 2)), Object)}
                Chart.ChartSeries(0).SeriesPoints.Add(chrtPoints)
            Next

            Chart2.ChartSeries.Clear()
            Chart2.BarWidthRatio = 3
            Chart2.AxisY.AxisAlignment = AxisAlignment.Far 'Y no lado esquerdo do gráfico
            Chart2.AxisY.Title.RotateDegrees = Style.RotateDegrees.None
            Chart2.AxisY.Title.Text = "%"
            Chart2.AxisY.Visible = True
            Chart2.AxisX.Visible = True
            Chart2.AxisX.MajorGridLines.GridLinesVisualStyle.LinePattern = Style.LinePattern.Dash
            Chart2.Legend.Visible = False
            Chart2.ChartCrosshair.Visible = False

            For intC = 0 To intPARADAS - 1
                decTTOTALPARADAS += Convert.ToDecimal(strMOTIVOS(intC, 2))
            Next
            chrtSeries2 = New ChartSeries
            Chart2.ChartSeries.Add(chrtSeries2)
            Chart2.ChartSeries(0).PointLabelDisplayMode = PointLabelDisplayMode.AllSeriesPoints
            For intC = intPARADAS - 1 To 0 Step -1
                Chart2.ChartSeries(0).SeriesType = SeriesType.HorizontalBar
                chrtPoints2 = New SeriesPoint
                chrtPoints2.ValueX = strMOTIVOS(intC, 1)
                chrtPoints2.ValueY = New Object() {CType((Convert.ToDecimal(strMOTIVOS(intC, 2)) / decTTOTALPARADAS) * 100, Object)}
                Chart2.ChartSeries(0).SeriesPoints.Add(chrtPoints2)
            Next

            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHART_PARETO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBEXPORTEXCEL(ByVal strDATAINICIAL As String,
                                       ByVal strHORAINICIAL As String,
                                       ByVal strDATAFINAL As String,
                                       ByVal strHORAFINAL As String,
                                       ByVal lbMAQUINASID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL1ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL2ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbNIVEL3ID As DevComponents.DotNetBar.ListBoxAdv,
                                       ByVal lbTURNO As DevComponents.DotNetBar.ListBoxAdv,
                                       ByRef strERROR As String)

        Dim strQUERY As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaPARADAS As SqlDataAdapter
        Dim dtPARADAS As DataSet
        Dim strMOTIVOS(99, 10) As String
        Dim intPARADAS As Integer = 0
        Dim intTIMEPARADA As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim arrNIVEL As Array
        Dim strTURNOS(99, 1) As String
        Dim intTURNOS As Integer = 0
        Dim sqldaTURNOS(99) As SqlDataAdapter
        Dim dtTURNOS(99) As DataSet
        Dim strQUERYTURNO As String = Nothing
        Dim dateDAYINI As DateTime = Nothing
        Dim dateDAYEND As DateTime = Nothing
        Dim dateBEGIN As DateTime = Nothing
        Dim dateFINISH As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim arrDAY As Array = Nothing
        Dim dateDAY As DateTime = Nothing
        Dim strDAY As String = Nothing
        Dim strTEMP(3) As String
        Dim intCONTROLE As Integer = 0
        Dim intTTOTALPARADAS As Integer = 0

        'Excel
        '//////
        Dim objEXCEL As Object
        Dim objWORKBOOK As Object
        Dim strFILENAME As String = "PARETO_PARADAS_"
        Dim strMONTH As String
        Dim strHOUR As String
        Dim strMINUTE As String
        Dim dtsFIRME As New DataSet
        Dim intIDX As Integer = 0
        Dim arrOV As Array = Nothing
        Dim strPRIOITY As String = Nothing
        Dim decInteger As Decimal = 0D
        Dim decFracionario As Decimal = 0D
        Dim decTOTAL As Decimal = 0D

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            'Seleção de Máquinas
            '///////////////////
            If lbMAQUINASID.CheckedItems.Count = 1 Then
                strQUERY = "Select * FROM [exe_MCONTROL_OEE_HistoricoParadas] WHERE [MachineId] = " &
                            lbMAQUINASID.CheckedItems(0).ToString & " "
            Else
                For intC = 0 To lbMAQUINASID.CheckedItems.Count - 1
                    If intC = 0 Then
                        strQUERY = "Select * FROM [exe_MCONTROL_OEE_HistoricoParadas] WHERE ([MachineId] = " &
                                   lbMAQUINASID.CheckedItems(intC).ToString & " "
                    Else
                        strQUERY += "Or [MachineId] = " & lbMAQUINASID.CheckedItems(intC).ToString & " "
                    End If
                Next
                strQUERY = Mid(strQUERY, 1, strQUERY.Length - 1)
                strQUERY += ")"
            End If

            'Seleção do Motivo de Parada de Máquina
            '//////////////////////////////////////
            If lbNIVEL1ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL1ID.CheckedItems.Count - 1
                    If intC = 0 Then
                        strQUERY += "And ([MotivoId] = " & lbNIVEL1ID.CheckedItems(intC).ToString & " "
                    Else
                        strQUERY += "Or [MotivoId] = " & lbNIVEL1ID.CheckedItems(intC).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            If lbNIVEL2ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL2ID.CheckedItems.Count - 1
                    arrNIVEL = Split(lbNIVEL2ID.CheckedItems(intC).ToString, "#")
                    If intC = 0 Then
                        strQUERY += " And ([motivonivel2] = " & arrNIVEL(1).ToString & " "
                    Else
                        strQUERY += "Or [motivonivel2] = " & arrNIVEL(1).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            If lbNIVEL3ID.CheckedItems.Count > 0 Then
                For intC = 0 To lbNIVEL3ID.CheckedItems.Count - 1
                    arrNIVEL = Split(lbNIVEL3ID.CheckedItems(intC).ToString, "#")
                    If intC = 0 Then
                        strQUERY += "And ([motivonivel3] = " & arrNIVEL(1).ToString & " "
                    Else
                        strQUERY += "Or [motivonivel3] = " & arrNIVEL(1).ToString & " "
                    End If
                Next
                strQUERY += ") "
            End If

            'Turno
            '//////
            If lbTURNO.CheckedItems.Count > 0 Then
                For intC = 0 To lbTURNO.CheckedItems.Count - 1
                    strQUERYTURNO = "Select * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [nome] = '" & lbTURNO.CheckedItems(intC).ToString & "'"
                    sqldaTURNOS(intC) = New SqlDataAdapter(strQUERYTURNO, conSQL)
                    dtTURNOS(intC) = New DataSet
                    sqldaTURNOS(intC).Fill(dtTURNOS(intC), "Turnos")
                    For intC2 = 0 To dtTURNOS(intC).Tables(0).Rows.Count - 1
                        strTURNOS(intTURNOS, 0) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial1")
                        strTURNOS(intTURNOS, 1) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horafinal1")
                        If dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial2") <> Nothing Then
                            intTURNOS += 1
                            strTURNOS(intTURNOS, 0) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horainicial2")
                            strTURNOS(intTURNOS, 1) = dtTURNOS(intC).Tables(0).Rows(intC2).Item("horafinal2")
                        End If
                        intTURNOS += 1
                    Next
                Next
            End If

            strQUERY += " And [DateTimeOn] >= @DI AND [DateTimeOff] Is Not NULL And [DateTimeOff] <= @DF AND [MotivoId] IS NOT NULL"
            sqldaPARADAS = New SqlDataAdapter(strQUERY, conSQL)
            dtPARADAS = New DataSet
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)))
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)))
            sqldaPARADAS.Fill(dtPARADAS, "Paradas")
            If dtPARADAS.Tables(0).Rows.Count > 0 Then
                For intC2 = 0 To dtPARADAS.Tables(0).Rows.Count - 1
                    If intTURNOS > 0 Then
                        For intC3 = 0 To intTURNOS - 1
                            bolFOUND = False
                            arrDAY = Split(dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn"), " ")
                            dateDAYINI = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 0))
                            dateDAYEND = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 1))
                            intDAYS = DateDiff(DateInterval.Minute, dateDAYINI, dateDAYEND)
                            If intDAYS < 0 Then
                                dateDAY = Convert.ToDateTime(arrDAY(0).ToString)
                                dateDAY = DateAdd(DateInterval.Day, 1, dateDAY)
                                arrDAY = Split(dateDAY, " ")
                                dateDAYEND = Convert.ToDateTime(arrDAY(0).ToString & " " & strTURNOS(intC3, 1))
                            End If
                            If dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") <= dateDAYINI And
                                   dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") >= dateDAYEND Then

                                dateBEGIN = dateDAYINI
                                dateFINISH = dateDAYEND
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") >= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") <= dateDAYEND Then

                                dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                                dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") <= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") > dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") <= dateDAYEND Then

                                dateBEGIN = dateDAYINI
                                dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                                bolFOUND = True

                            ElseIf dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") >= dateDAYINI And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn") < dateDAYEND And
                                      dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff") >= dateDAYEND Then

                                dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                                dateFINISH = dateDAYEND
                                bolFOUND = True

                            End If
                            If bolFOUND = True Then
                                bolFOUND = False
                                If intPARADAS > 0 Then
                                    For intC4 = 0 To intPARADAS - 1
                                        If strMOTIVOS(intC4, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId") Then
                                            intTIMEPARADA = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                                            strMOTIVOS(intC4, 2) = Convert.ToInt32(strMOTIVOS(intC4, 2)) + intTIMEPARADA
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next
                                    If bolFOUND = False Then
                                        strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                                        intPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If
                                Else
                                    strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                    strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                    strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                                    intPARADAS += 1
                                End If
                            End If
                        Next

                    Else
                        dateBEGIN = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOn")
                        dateFINISH = dtPARADAS.Tables(0).Rows(intC2).Item("DateTimeOff")
                        If intPARADAS > 0 Then
                            For intC4 = 0 To intPARADAS - 1
                                If strMOTIVOS(intC4, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId") Then
                                    intTIMEPARADA = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                                    strMOTIVOS(intC4, 2) = Convert.ToInt32(strMOTIVOS(intC4, 2)) + intTIMEPARADA
                                    bolFOUND = True
                                    Exit For
                                End If
                            Next
                            If bolFOUND = False Then
                                strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                                strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                                strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                                intPARADAS += 1
                            Else
                                bolFOUND = False
                            End If
                        Else
                            strMOTIVOS(intPARADAS, 0) = dtPARADAS.Tables(0).Rows(intC2).Item("MotivoId")
                            strMOTIVOS(intPARADAS, 1) = dtPARADAS.Tables(0).Rows(intC2).Item("Motivo")
                            strMOTIVOS(intPARADAS, 2) = DateDiff(DateInterval.Minute, dateBEGIN, dateFINISH)
                            intPARADAS += 1
                        End If
                    End If

                Next
            End If
            conSQL.Close()

            'Coloca o gráfico do maior valor pelo menor valor
            '/////////////////////////////////////////////////
            If intPARADAS > 1 Then
                intCONTROLE = 1
                For intC = 0 To intPARADAS - 2
                    strTEMP(0) = strMOTIVOS(intC, 0)
                    strTEMP(1) = strMOTIVOS(intC, 1)
                    strTEMP(2) = strMOTIVOS(intC, 2)
                    For intC2 = intCONTROLE To intPARADAS - 1
                        If Val(strTEMP(2)) < Val(strMOTIVOS(intC2, 2)) Then
                            strMOTIVOS(intC, 0) = strMOTIVOS(intC2, 0)
                            strMOTIVOS(intC, 1) = strMOTIVOS(intC2, 1)
                            strMOTIVOS(intC, 2) = strMOTIVOS(intC2, 2)
                            strMOTIVOS(intC2, 0) = strTEMP(0)
                            strMOTIVOS(intC2, 1) = strTEMP(1)
                            strMOTIVOS(intC2, 2) = strTEMP(2)
                            strTEMP(0) = strMOTIVOS(intC, 0)
                            strTEMP(1) = strMOTIVOS(intC, 1)
                            strTEMP(2) = strMOTIVOS(intC, 2)
                        End If
                    Next
                    intCONTROLE += 1
                Next
            End If

            'Exporta para o Excel
            '////////////////////

            strDAY = Now.Day.ToString("D2")
            strMONTH = Now.Month.ToString("D2")
            strHOUR = Now.Hour.ToString("D2")
            strMINUTE = Now.Minute.ToString("D2")
            objEXCEL = CreateObject("Excel.Application")
            objWORKBOOK = objEXCEL.Workbooks.Open(Filename:=strMODELS & strFILENAME & ".xls", UpdateLinks:=False, ReadOnly:=False)
            objWORKBOOK.Worksheets("P1").activate()
            For intC = 0 To intPARADAS - 1
                intIDX = intC + 5
                objWORKBOOK.ActiveSheet.range("A" & intIDX).value = strMOTIVOS(intC, 1)
                decInteger = Int(Convert.ToInt32(strMOTIVOS(intC, 2)) / 60)
                decFracionario = (Convert.ToInt32(strMOTIVOS(intC, 2)) / 60) - decInteger
                objWORKBOOK.ActiveSheet.range("B" & intIDX).value = Format(decInteger, "00").ToString & ":" & Format((decFracionario * 60), "00") & ":00"
                objWORKBOOK.ActiveSheet.range("C" & intIDX).value = strMOTIVOS(intC, 2)
                decTOTAL += Convert.ToInt32(strMOTIVOS(intC, 2))
            Next
            decInteger = Int(decTOTAL / 60)
            decFracionario = (decTOTAL / 60) - decInteger
            objWORKBOOK.ActiveSheet.range("B42").value = Format(decInteger, "00").ToString & ":" & Format((decFracionario * 60), "00") & ":00"
            objEXCEL.ActiveWorkbook.Saveas(strEXPORT & strFILENAME & strDAY & strMONTH & strHOUR & strMINUTE & ".xls")
            objEXCEL.Quit()
            Return True

        Catch ex As Exception

            objEXCEL.Quit()
            strERROR = "Falha interna da função ReadDBCHART_PARETO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "RELATÓRIOS"

    'APONTAMENTO
    '///////////
    Public Function WriteDBREPORTAPONTAMENTO(ByVal intMACHINEID As Integer,
                                             ByVal intUSERID As Integer,
                                             ByVal intMES As Integer,
                                             ByVal intANO As Integer,
                                             ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaESCALA As SqlDataAdapter
        Dim dtsESCALA As DataSet
        Dim sqldaTURNOS As SqlDataAdapter
        Dim dtsTURNOS As DataSet
        Dim sqldaAMARRADO As SqlDataAdapter
        Dim dtsAMARRADO As DataSet
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim strQUERY As String = Nothing
        Dim intTURNOS As Integer = 0
        Dim strTURNOS(10, 10) As String
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim dtimeDATAAMARRADO As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim strMACHINEID As String = Nothing
        Dim strMACHINETABLE As String = Nothing
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim bolNEXTDAY As Boolean = False
        Dim intTURNO As Integer = 0
        Dim intTURNOINDEX As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim intMAQUINAID As Integer = 0
        Dim decPESOTURNOINDETERMINADO As Decimal = 0D
        Dim decMETROSINDETERMIANDO As Decimal = 0D
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim strMES As String = Nothing
        Dim strTURNO As String = Nothing
        Dim decNODIAM As Decimal = 0D
        Dim decTOTAL As Decimal = 0D
        Dim decTOTALM As Decimal = 0D
        Dim decMEDIADIARIAM As Decimal = 0D
        Dim decMEDIADIARIA As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strDATAINICIALHOJE As String = Nothing
        Dim strDATAFINALHOJE As String = Nothing
        Dim dtimeDATAINICIALHOJE As DateTime = Nothing
        Dim dtimeDATAFINALHOJE As DateTime = Nothing
        Dim dtimeDATAAMARRADOHOJE As Date = Nothing
        Dim strPESOHOJE As String = Nothing
        Dim strMETROSHOJE As String = Nothing
        Dim decPESOTOTAL As Decimal = 0D
        Dim decMETROSTOTAL As Decimal = 0D
        Dim sqldaPERIODO As SqlDataAdapter
        Dim dtsPERIODO As DataSet
        Dim sqldaTURNOBASE As SqlDataAdapter
        Dim dtsTURNOBASE As DataSet
        Dim intDIASUTEIS As Integer = 0
        Dim intDIASUTEISHOJE As Integer = 0

        Dim strHOJEKG As String = Nothing
        Dim strHOJEM As String = Nothing
        Dim strHOJEPC As String = Nothing
        Dim decTURNOINDETERMINADOKG As Decimal = 0D
        Dim decTURNOINDETERMINADOPC As Decimal = 0D
        Dim decTURNOINDETERMINADOM As Decimal = 0D
        Dim decMEDIADIARIAKG As Decimal = 0D
        Dim decMEDIADIARIAPC As Decimal = 0D
        Dim decTOTALKG As Decimal = 0D
        Dim decTOTALPC As Decimal = 0D

        Dim sqldaDAHOJE As SqlDataAdapter
        Dim dtsDAHOJE As DataSet
        Dim decPESOHOJE As Decimal = 0D
        Dim decMETROSHOJE As Decimal = 0D
        Dim decPECASHOJE As Decimal = 0D
        Dim sqldaESCALAHOJE As SqlDataAdapter '
        Dim dtsESCALAHOJE As DataSet

        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim dtimeFERIADO As DateTime
        Dim intMESATUAL As Integer = 0
        Dim intANOATUAL As Integer = 0

        Try

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_apontamento] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            intMES += 1
            ReadDBGETDIASUTEIS(intMACHINEID, intDIASUTEIS, intMES, intANO)
            If intMES < 10 Then
                strMES = "0" & intMES
            Else
                strMES = intMES.ToString
            End If
            dtimeDATAINICIAL = Convert.ToDateTime("01/" & strMES & "/" & intANO)
            dtimeDATAFINAL = Now()
            intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
            If intDAYS > 31 Or intDAYS < 0 Then
                intDIASUTEISHOJE = intDIASUTEIS
            Else
                ReadDBGETDIASUTEISHOJE(intMACHINEID, intDIASUTEISHOJE, intMES, intANO, Now.ToString)
            End If

            reportDIASUTEIS = intDIASUTEISHOJE
            reportTOTALDIASUTEIS = intDIASUTEIS

            strDATAINICIAL = "01/" & strMES & "/" & intANO
            dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
            dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATAINICIAL))
            strDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10)
            If DateDiff(DateInterval.Day, dtimeDATAFINAL, Now()) < 0 Then
                strDATAFINAL = Mid(Convert.ToString(DateAdd(DateInterval.Day, -1, Now())), 1, 10)
            End If
            dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL & " 23:59:59")

            If dtimeDATAFINAL.DayOfWeek.ToString = "Sunday" Then
                dtimeDATAFINAL = DateAdd(DateInterval.Day, -2, dtimeDATAFINAL)
            ElseIf dtimeDATAFINAL.DayOfWeek.ToString = "Saturday" Then
                dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, dtimeDATAFINAL)
            End If

            reportDATAINICIAL = Mid(strDATAINICIAL, 1, 10)
            reportDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10)

            intMESATUAL = Now.Month
            intANOATUAL = Now.Year

            'Verifica quais os turnos cadastrados da máquina para ajustar a data final
            '/////////////////////////////////////////////////////////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
            sqldaTURNOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsTURNOS = New DataSet
            sqldaTURNOS.Fill(dtsTURNOS, "Turnos")

            If dtsTURNOS.Tables(0).Rows.Count = 0 Then
                strERROR = "Não existem Turnos cadastrados para esta Máquina!"
                Return False
            End If

            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
            sqldaPERIODO = New SqlDataAdapter(strQUERY, conSQL)
            dtsPERIODO = New DataSet
            sqldaPERIODO.Fill(dtsPERIODO, "Periodo")

            If dtsPERIODO.Tables(0).Rows.Count = 0 Then
                strERROR = "Não existem Turnos cadastrados para esta Máquina!"
                Return False
            End If

            strDINICIAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
            strDFINAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")

            intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
            If intDAYS < 0 Then
                dtimeDATAFINAL = DateAdd(DateInterval.Day, 1, dtimeDATAFINAL)
            End If

            strDATAINICIAL = Mid(dtimeDATAINICIAL.ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
            strDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")
            dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
            dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)

            'Verifica se a data final é um feriado
            '//////////////////////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] DESC"
            sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsFERIADOS = New DataSet
            sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")
            intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
            For intC2 = 0 To dtsFERIADOS.Tables(0).Rows.Count - 1
                dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS.Tables(0).Rows(intC2).Item("data"))
                If dtimeFERIADO = dtimeDATAFINAL Then
                    dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, dtimeDATAFINAL)
                End If
            Next

            dtimeDATAINICIALHOJE = Convert.ToDateTime(Mid(DateAdd(DateInterval.Day, -1, dtimeDATAFINAL).ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial"))
            dtimeDATAFINALHOJE = dtimeDATAFINAL

            If intMES > intMESATUAL And intANO <= intANOATUAL Then
                dtimeDATAINICIALHOJE = DateAdd(DateInterval.Day, -1, dtimeDATAINICIALHOJE)
                strDINICIAL = Mid(dtimeDATAINICIALHOJE.ToString, 1, 10)
                strDINICIAL &= " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                dtimeDATAINICIALHOJE = Convert.ToDateTime(strDINICIAL)
            End If

            'Busca Turnos
            '////////////
            strMACHINEID = intMACHINEID.ToString("D6")
            strMACHINETABLE = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
            strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                       strDATAINICIAL & "',103) AND [date_shift] <= convert(date, '" &
                       strDATAFINAL & "',103) ORDER BY [date_shift] ASC"
            sqldaESCALA = New SqlDataAdapter(strQUERY, conSQL)
            dtsESCALA = New DataSet
            sqldaESCALA.Fill(dtsESCALA, "Escala")

            If dtsESCALA.Tables(0).Rows.Count = 0 Then
                strERROR = "Não existe Tempo Calendário cadastrado para esta Máquina!"
                Return False
            End If

            'Amarrado
            '////////
            strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                       "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                       "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                       "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                       "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
            sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
            dtsBABEL = New DataSet
            sqldaBABEL.Fill(dtsBABEL, "BABEL")
            intMAQUINAID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                       "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
            sqldaAMARRADO = New SqlDataAdapter(strQUERY, conSQL)
            dtsAMARRADO = New DataSet
            sqldaAMARRADO.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL)))
            sqldaAMARRADO.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL)))
            sqldaAMARRADO.Fill(dtsAMARRADO, "Amarrado")

            Dim dtimeDATAINICIALESCALA As DateTime
            Dim dtimeDATAFINALESCALA As DateTime

            _clsAMARRADOS.Clear()

            For intC2 = 0 To dtsAMARRADO.Tables(0).Rows.Count - 1
                For intC3 = 0 To dtsESCALA.Tables(0).Rows.Count - 1
                    dtimeDATAAMARRADO = Convert.ToDateTime(dtsAMARRADO.Tables(0).Rows(intC2).Item("data_recebido"))
                    dtimeDATAINICIALESCALA = Convert.ToDateTime(dtsESCALA.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                dtsESCALA.Tables(0).Rows(intC3).Item("time_begin"))
                    dtimeDATAFINALESCALA = Convert.ToDateTime(dtsESCALA.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                              dtsESCALA.Tables(0).Rows(intC3).Item("time_end"))

                    bolFOUND = False
                    If dtimeDATAAMARRADO >= dtimeDATAINICIALESCALA And dtimeDATAAMARRADO <= dtimeDATAFINALESCALA Then

                        If intTURNO = 0 Then
                            strTURNOS(intTURNO, 0) = dtsESCALA.Tables(0).Rows(intC3).Item("shift_id")
                            intTURNOINDEX = 0
                            intTURNO += 1
                        Else
                            For intC4 = 0 To intTURNO - 1
                                If dtsESCALA.Tables(0).Rows(intC3).Item("shift_id") = strTURNOS(intC4, 0) Then
                                    intTURNOINDEX = intC4
                                    bolFOUND = True
                                    Exit For
                                End If
                            Next
                            If bolFOUND = False Then
                                strTURNOS(intTURNO, 0) = dtsESCALA.Tables(0).Rows(intC3).Item("shift_id")
                                intTURNOINDEX = intTURNO
                                intTURNO += 1
                            Else
                                bolFOUND = False
                            End If
                        End If
                        strTURNOS(intTURNOINDEX, 1) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                     (Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("peso")))
                        If dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "M" Then
                            strTURNOS(intTURNOINDEX, 2) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                          Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("qtd"))
                        ElseIf dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                            strTURNOS(intTURNOINDEX, 5) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                          Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("qtd"))
                        End If
                        bolFOUND = True
                        Exit For
                    End If
                Next
                If bolFOUND = False Then
                    _clsAMARRADOS.Add(New clsAMARRADOS_SEMTURNO(intUSERID,
                                                                dtsAMARRADO.Tables(0).Rows(intC2).Item("centro_trabalho"),
                                                                dtsAMARRADO.Tables(0).Rows(intC2).Item("ordem"),
                                                                dtsAMARRADO.Tables(0).Rows(intC2).Item("num_hu"),
                                                                dtsAMARRADO.Tables(0).Rows(intC2).Item("lote"),
                                                                dtsAMARRADO.Tables(0).Rows(intC2).Item("data_recebido")))
                    decTURNOINDETERMINADOKG += Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                              (Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("peso")))
                    If dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "M" Then
                        decTURNOINDETERMINADOM = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                 Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("qtd"))
                    ElseIf dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                        decTURNOINDETERMINADOPC = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                  Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC2).Item("qtd"))
                    End If
                End If
            Next

            'Quantidade produzida no dia
            '////////////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                       "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
            sqldaDAHOJE = New SqlDataAdapter(strQUERY, conSQL)
            dtsDAHOJE = New DataSet
            sqldaDAHOJE.SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIALHOJE))
            sqldaDAHOJE.SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINALHOJE))
            sqldaDAHOJE.Fill(dtsDAHOJE, "DAHoje")

            strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                       Mid(dtimeDATAINICIALHOJE.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                       Mid(dtimeDATAFINALHOJE.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
            sqldaESCALAHOJE = New SqlDataAdapter(strQUERY, conSQL)
            dtsESCALAHOJE = New DataSet
            sqldaESCALAHOJE.Fill(dtsESCALAHOJE, "EscalaHoje")

            'Dia de Hoje
            '///////////
            If dtsDAHOJE.Tables(0).Rows.Count > 0 Then
                For intC2 = 0 To dtsDAHOJE.Tables(0).Rows.Count - 1
                    For intC3 = 0 To dtsESCALAHOJE.Tables(0).Rows.Count - 1
                        dtimeDATAAMARRADO = Convert.ToDateTime(dtsDAHOJE.Tables(0).Rows(intC2).Item("data_recebido"))
                        dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALAHOJE.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                              dtsESCALAHOJE.Tables(0).Rows(intC3).Item("time_begin"))
                        dtimeDATAFINAL = Convert.ToDateTime(dtsESCALAHOJE.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                            dtsESCALAHOJE.Tables(0).Rows(intC3).Item("time_end"))
                        bolFOUND = False
                        If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then
                            For intC4 = 0 To intTURNO - 1
                                If strTURNOS(intC4, 0) = dtsESCALAHOJE.Tables(0).Rows(intC3).Item("shift_id") Then
                                    strTURNOS(intC4, 3) = Val(strTURNOS(intC4, 3)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("peso")
                                    If dtsDAHOJE.Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                        strTURNOS(intC4, 4) = Val(strTURNOS(intC4, 4)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("qtd")
                                    ElseIf dtsDAHOJE.Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                        strTURNOS(intC4, 6) = Val(strTURNOS(intC4, 6)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("qtd")
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next
            End If

            If intTURNO > 0 Then
                For intC2 = 0 To intTURNO - 1
                    strTURNOS(intC2, 1) = Convert.ToDecimal(strTURNOS(intC2, 1)) / 1000
                    strTURNOS(intC2, 3) = Convert.ToDecimal(strTURNOS(intC2, 3)) / 1000
                    For intC3 = 0 To dtsTURNOS.Tables(0).Rows.Count - 1
                        If Val(strTURNOS(intC2, 0)) = dtsTURNOS.Tables(0).Rows(intC3).Item("id") Then
                            strTURNO = dtsTURNOS.Tables(0).Rows(intC3).Item("nome")
                            Exit For
                        End If
                    Next
                    decTOTALM = Convert.ToInt32(strTURNOS(intC2, 2))
                    If strTURNOS(intC2, 2) = Nothing Then
                        strTURNOS(intC2, 2) = "0"
                    End If
                    If strTURNOS(intC2, 5) = Nothing Then
                        strTURNOS(intC2, 5) = "0"
                    End If
                    decMEDIADIARIAKG = Convert.ToDecimal(strTURNOS(intC2, 1)) / intDIASUTEISHOJE
                    decMEDIADIARIAM = (Convert.ToDecimal(strTURNOS(intC2, 2)) / intDIASUTEISHOJE)
                    decMEDIADIARIAPC = (Convert.ToDecimal(strTURNOS(intC2, 5)) / intDIASUTEISHOJE)
                    If strTURNOS(intC2, 3) = Nothing Then
                        strHOJEKG = "0"
                    Else
                        strHOJEKG = strTURNOS(intC2, 3)
                    End If
                    If strTURNOS(intC2, 4) = Nothing Then
                        strHOJEM = "0"
                    Else
                        strHOJEM = Convert.ToDecimal(strTURNOS(intC2, 4))
                    End If
                    If strTURNOS(intC2, 6) = Nothing Then
                        strHOJEPC = "0"
                    Else
                        strHOJEPC = Convert.ToDecimal(strTURNOS(intC2, 6)) / intDIASUTEISHOJE
                    End If
                    If intDIASUTEIS = intDIASUTEISHOJE Then
                        decTOTALKG = Convert.ToDecimal(strTURNOS(intC2, 1))
                        decTOTALM = Convert.ToDecimal(strTURNOS(intC2, 2))
                        decTOTALPC = Convert.ToDecimal(strTURNOS(intC2, 5))
                    Else
                        decTOTALKG = (Convert.ToDecimal(strTURNOS(intC2, 1)) / intDIASUTEISHOJE) * intDIASUTEIS
                        decTOTALM = ((Convert.ToDecimal(strTURNOS(intC2, 2)) / intDIASUTEISHOJE) * intDIASUTEIS)
                        decTOTALPC = ((Convert.ToDecimal(strTURNOS(intC2, 5)) / intDIASUTEISHOJE) * intDIASUTEIS)
                    End If
                    strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento] ([userid],[turno],[nodia],[total],[mediadiaria]," &
                               "[nodiam],[totalm],[mediadiariam],[peso],[metros],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                               intUSERID & ", '" & strTURNO & "', " & strHOJEKG.Replace(",", ".") & ", " & strTURNOS(intC2, 1).Replace(",", ".") &
                               ", " & decMEDIADIARIAKG.ToString.Replace(",", ".") & ", " & strHOJEM.Replace(",", ".") & ", " &
                               strTURNOS(intC2, 2).ToString.Replace(",", ".") & ", " & decMEDIADIARIAM.ToString.Replace(",", ".") & ", " &
                               decTOTALKG.ToString.Replace(",", ".") & ", " & decTOTALM.ToString.Replace(",", ".") & ", " &
                               strHOJEPC.Replace(",", ".") & ", " & strTURNOS(intC2, 5).Replace(",", ".") & ", " &
                               decMEDIADIARIAPC.ToString.Replace(",", ".") & ", " & decTOTALPC.ToString.Replace(",", ".") & ")"
                    sqlcmdREPORT.CommandText = strQUERY
                    sqlcmdREPORT.ExecuteNonQuery()
                Next

            Else
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
                sqldaTURNOBASE = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOBASE = New DataSet
                sqldaTURNOBASE.Fill(dtsTURNOBASE, "TurnoBase")
                For intC2 = 0 To dtsTURNOBASE.Tables(0).Rows.Count - 1
                    strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento] ([userid],[turno],[nodia],[total],[mediadiaria]," &
                               "[nodiam],[totalm],[mediadiariam],[peso],[metros],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                               intUSERID & ", '" & dtsTURNOBASE.Tables(0).Rows(intC2).Item("nome") & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"
                    sqlcmdREPORT.CommandText = strQUERY
                    sqlcmdREPORT.ExecuteNonQuery()
                Next

            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTAPONTAMENTO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTAPONTAMENTOLIVRE(ByVal lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                                  ByVal lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                                  ByVal intUSERID As Integer,
                                                  ByVal strDATAINICIAL As String,
                                                  ByVal strHORAINICIAL As String,
                                                  ByVal strDATAFINAL As String,
                                                  ByVal strHORAFINAL As String,
                                                  ByVal intDIASUTEIS As Integer,
                                                  ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaESCALA As SqlDataAdapter
        Dim dtsESCALA As DataSet
        Dim sqldaTURNOS As SqlDataAdapter
        Dim dtsTURNOS As DataSet
        Dim sqldaAMARRADO As SqlDataAdapter
        Dim dtsAMARRADO As DataSet
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim strQUERY As String = Nothing
        Dim intTURNOS As Integer = 0
        Dim strTURNOS(10, 10) As String
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim dtimeDATAAMARRADO As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim strMACHINEID As String = Nothing
        Dim strMACHINETABLE As String = Nothing
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim bolNEXTDAY As Boolean = False
        Dim intTURNO As Integer = 0
        Dim intTURNOINDEX As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim intMAQUINAID As Integer = 0
        Dim decPESOTURNOINDETERMINADO As Decimal = 0D
        Dim decMETROSINDETERMIANDO As Decimal = 0D
        Dim strMES As String = Nothing
        Dim strTURNO As String = Nothing
        Dim decNODIAM As Decimal = 0D
        Dim decTOTAL As Decimal = 0D
        Dim decTOTALM As Decimal = 0D
        Dim decMEDIADIARIAM As Decimal = 0D
        Dim decMEDIADIARIA As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strDATAINICIALHOJE As String = Nothing
        Dim strDATAFINALHOJE As String = Nothing
        Dim dtimeDATAINICIALHOJE As DateTime = Nothing
        Dim dtimeDATAFINALHOJE As DateTime = Nothing
        Dim dtimeDATAAMARRADOHOJE As Date = Nothing
        Dim strPESOHOJE As String = Nothing
        Dim strMETROSHOJE As String = Nothing
        Dim decPESOTOTAL As Decimal = 0D
        Dim decMETROSTOTAL As Decimal = 0D
        Dim sqldaPERIODO As SqlDataAdapter
        Dim dtsPERIODO As DataSet
        Dim sqldaTURNOBASE As SqlDataAdapter
        Dim dtsTURNOBASE As DataSet
        Dim strMAQUINA As String = Nothing

        Dim strHOJEKG As String = Nothing
        Dim strHOJEM As String = Nothing
        Dim strHOJEPC As String = Nothing
        Dim decTURNOINDETERMINADOKG As Decimal = 0D
        Dim decTURNOINDETERMINADOPC As Decimal = 0D
        Dim decTURNOINDETERMINADOM As Decimal = 0D
        Dim decMEDIADIARIAKG As Decimal = 0D
        Dim decMEDIADIARIAPC As Decimal = 0D
        Dim decTOTALKG As Decimal = 0D
        Dim decTOTALPC As Decimal = 0D

        Dim sqldaDAHOJE As SqlDataAdapter
        Dim dtsDAHOJE As DataSet
        Dim sqldaESCALAHOJE As SqlDataAdapter '
        Dim dtsESCALAHOJE As DataSet

        Try

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_apontamento_livre] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            reportDATAINICIAL = strDATAINICIAL & " " & strHORAINICIAL
            dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)
            dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL & " " & Mid(strHORAFINAL, 1, 5))
            reportDATAFINAL = strDATAFINAL & " " & strHORAFINAL

            intDIASUTEIS = 0
            ReadDBGETDIASUTEISPERIODO(intDIASUTEIS, strDATAINICIAL, strHORAINICIAL, strDATAFINAL, strHORAFINAL, strERROR)
            If intDIASUTEIS <= 0 Then intDIASUTEIS = 1
            reportDIASUTEIS = intDIASUTEIS

            _clsAMARRADOS.Clear()

            For intCX = 0 To lbMAQUINAID.CheckedItems.Count - 1

                intMACHINEID = Val(lbMAQUINAID.CheckedItems(intCX).ToString)
                strMAQUINA = lbMAQUINA.CheckedItems(intCX).ToString

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS = New DataSet
                sqldaTURNOS.Fill(dtsTURNOS, "Turnos")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO = New DataSet
                sqldaPERIODO.Fill(dtsPERIODO, "Periodo")
                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                strDFINAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")
                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))

                dtimeDATAINICIALHOJE = Convert.ToDateTime(Mid(DateAdd(DateInterval.Day, -1, dtimeDATAFINAL).ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial"))
                dtimeDATAFINALHOJE = dtimeDATAFINAL

                'Busca Turnos
                '////////////
                strMACHINEID = intMACHINEID.ToString("D6")
                strMACHINETABLE = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                            Mid(dtimeDATAINICIAL.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                            Mid(dtimeDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALA = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALA = New DataSet
                sqldaESCALA.SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaESCALA.SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaESCALA.Fill(dtsESCALA, "Escala")

                'Amarrado
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                           "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                           "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                           "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                           "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
                sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL = New DataSet
                sqldaBABEL.Fill(dtsBABEL, "BABEL")
                intMAQUINAID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= convert(datetime, '" &
                           dtimeDATAINICIAL.ToString & "',103) AND [data_recebido] <= convert(datetime, '" &
                           dtimeDATAFINAL.ToString & "',103) AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
                sqldaAMARRADO = New SqlDataAdapter(strQUERY, conSQL)
                dtsAMARRADO = New DataSet
                sqldaAMARRADO.Fill(dtsAMARRADO, "Amarrado")

                Array.Clear(strTURNOS, 0, strTURNOS.Length)
                intTURNO = 0

                For intC = 0 To dtsAMARRADO.Tables(0).Rows.Count - 1
                    For intC2 = 0 To dtsESCALA.Tables(0).Rows.Count - 1
                        dtimeDATAAMARRADO = Convert.ToDateTime(dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido"))
                        dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALA.Tables(0).Rows(intC2).Item("date_shift") & " " &
                                                              dtsESCALA.Tables(0).Rows(intC2).Item("time_begin"))
                        dtimeDATAFINAL = Convert.ToDateTime(dtsESCALA.Tables(0).Rows(intC2).Item("date_shift") & " " &
                                                            dtsESCALA.Tables(0).Rows(intC2).Item("time_end"))

                        bolFOUND = False
                        If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then

                            If intTURNO = 0 Then
                                strTURNOS(intTURNO, 0) = dtsESCALA.Tables(0).Rows(intC2).Item("shift_id")
                                intTURNOINDEX = 0
                                intTURNO += 1
                            Else
                                For intC3 = 0 To intTURNO - 1
                                    If dtsESCALA.Tables(0).Rows(intC2).Item("shift_id") = strTURNOS(intC3, 0) Then
                                        intTURNOINDEX = intC3
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next
                                If bolFOUND = False Then
                                    strTURNOS(intTURNO, 0) = dtsESCALA.Tables(0).Rows(intC2).Item("shift_id")
                                    intTURNOINDEX = intTURNO
                                    intTURNO += 1
                                Else
                                    bolFOUND = False
                                End If
                            End If
                            strTURNOS(intTURNOINDEX, 1) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                          Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("peso"))
                            If dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                strTURNOS(intTURNOINDEX, 2) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                              Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("qtd"))
                            ElseIf dtsAMARRADO.Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                strTURNOS(intTURNOINDEX, 5) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                              Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("qtd"))
                            End If
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        _clsAMARRADOS.Add(New clsAMARRADOS_SEMTURNO(intUSERID,
                                                                    dtsAMARRADO.Tables(0).Rows(intC).Item("centro_trabalho"),
                                                                    dtsAMARRADO.Tables(0).Rows(intC).Item("ordem"),
                                                                    dtsAMARRADO.Tables(0).Rows(intC).Item("num_hu"),
                                                                    dtsAMARRADO.Tables(0).Rows(intC).Item("lote"),
                                                                    dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido")))
                        decPESOTURNOINDETERMINADO += Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                     Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("peso"))
                        If dtsAMARRADO.Tables(0).Rows(intC).Item("unidade") = "M" Then
                            decTURNOINDETERMINADOM = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                              Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("qtd"))
                        ElseIf dtsAMARRADO.Tables(0).Rows(intC).Item("unidade") = "PC" Then
                            decTURNOINDETERMINADOPC = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                      Convert.ToDecimal(dtsAMARRADO.Tables(0).Rows(intC).Item("qtd"))
                        End If
                    End If
                Next

                'Quantidade produzida no dia
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                           "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
                sqldaDAHOJE = New SqlDataAdapter(strQUERY, conSQL)
                dtsDAHOJE = New DataSet
                sqldaDAHOJE.SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIALHOJE))
                sqldaDAHOJE.SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINALHOJE))
                sqldaDAHOJE.Fill(dtsDAHOJE, "DAHoje")

                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                           Mid(dtimeDATAINICIALHOJE.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                           Mid(dtimeDATAFINALHOJE.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAHOJE = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAHOJE = New DataSet
                sqldaESCALAHOJE.Fill(dtsESCALAHOJE, "EscalaHoje")

                'Dia de Hoje
                '///////////
                If dtsDAHOJE.Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsDAHOJE.Tables(0).Rows.Count - 1
                        For intC3 = 0 To dtsESCALAHOJE.Tables(0).Rows.Count - 1
                            dtimeDATAAMARRADO = Convert.ToDateTime(dtsDAHOJE.Tables(0).Rows(intC2).Item("data_recebido"))
                            dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALAHOJE.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                  dtsESCALAHOJE.Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeDATAFINAL = Convert.ToDateTime(dtsESCALAHOJE.Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                dtsESCALAHOJE.Tables(0).Rows(intC3).Item("time_end"))
                            bolFOUND = False
                            If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then
                                For intC4 = 0 To intTURNO - 1
                                    If strTURNOS(intC4, 0) = dtsESCALAHOJE.Tables(0).Rows(intC3).Item("shift_id") Then
                                        strTURNOS(intC4, 3) = Val(strTURNOS(intC4, 3)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("peso")
                                        If dtsDAHOJE.Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                            strTURNOS(intC4, 4) = Val(strTURNOS(intC4, 4)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("qtd")
                                        ElseIf dtsDAHOJE.Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                            strTURNOS(intC4, 6) = Val(strTURNOS(intC4, 6)) + dtsDAHOJE.Tables(0).Rows(intC2).Item("qtd")
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                If intTURNO > 0 Then
                    For intC = 0 To intTURNO - 1
                        strTURNOS(intC, 1) = Convert.ToDecimal(strTURNOS(intC, 1)) / 1000
                        strTURNOS(intC, 3) = Convert.ToDecimal(strTURNOS(intC, 3)) / 1000
                        For intC2 = 0 To dtsTURNOS.Tables(0).Rows.Count - 1
                            If Val(strTURNOS(intC, 0)) = dtsTURNOS.Tables(0).Rows(intC2).Item("id") Then
                                strTURNO = dtsTURNOS.Tables(0).Rows(intC2).Item("nome")
                                Exit For
                            End If
                        Next
                        decTOTALM = Convert.ToInt32(strTURNOS(intC, 2))
                        If strTURNOS(intC, 2) = Nothing Then
                            strTURNOS(intC, 2) = "0"
                        End If
                        If strTURNOS(intC, 5) = Nothing Then
                            strTURNOS(intC, 5) = "0"
                        End If
                        decMEDIADIARIAKG = Convert.ToDecimal(strTURNOS(intC, 1)) / intDIASUTEIS
                        decMEDIADIARIAM = (Convert.ToDecimal(strTURNOS(intC, 2)) / intDIASUTEIS)
                        decMEDIADIARIAPC = (Convert.ToDecimal(strTURNOS(intC, 5)) / intDIASUTEIS)
                        If strTURNOS(intC, 3) = Nothing Then
                            strHOJEKG = "0"
                        Else
                            strHOJEKG = strTURNOS(intC, 3)
                        End If
                        If strTURNOS(intC, 4) = Nothing Then
                            strHOJEM = "0"
                        Else
                            strHOJEM = Convert.ToDecimal(strTURNOS(intC, 4))
                        End If
                        If strTURNOS(intC, 6) = Nothing Then
                            strHOJEPC = "0"
                        Else
                            strHOJEPC = Convert.ToDecimal(strTURNOS(intC, 6)) / intDIASUTEIS
                        End If
                        If intDIASUTEIS = intDIASUTEIS Then
                            decTOTALKG = Convert.ToDecimal(strTURNOS(intC, 1))
                            decTOTALM = Convert.ToDecimal(strTURNOS(intC, 2))
                            decTOTALPC = Convert.ToDecimal(strTURNOS(intC, 5))
                        Else
                            decTOTALKG = (Convert.ToDecimal(strTURNOS(intC, 1)) / intDIASUTEIS) * intDIASUTEIS
                            decTOTALM = ((Convert.ToDecimal(strTURNOS(intC, 2)) / intDIASUTEIS) * intDIASUTEIS)
                            decTOTALPC = ((Convert.ToDecimal(strTURNOS(intC, 5)) / intDIASUTEIS) * intDIASUTEIS)
                        End If
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_livre] ([userid],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                                   "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                                   intUSERID & ", '" & strMAQUINA & "', '" & strTURNO & "', " & strHOJEKG.Replace(",", ".") & ", " & strTURNOS(intC, 1).Replace(",", ".") &
                                   ", " & decMEDIADIARIAKG.ToString.Replace(",", ".") & ", " & strHOJEM.Replace(",", ".") & ", " &
                                   strTURNOS(intC, 2).Replace(",", ".") & ", " & decMEDIADIARIAM.ToString.Replace(",", ".") & ", " &
                                   decTOTALKG.ToString.Replace(",", ".") & ", " & decTOTALM.ToString.Replace(",", ".") & ", " &
                                   intDIASUTEIS & ", " & strHOJEPC.Replace(",", ".") & ", " & strTURNOS(intC, 5).Replace(",", ".") & ", " &
                                   decMEDIADIARIAPC.ToString.Replace(",", ".") & ", " & decTOTALPC.ToString.Replace(",", ".") & ")"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next
                Else
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
                    sqldaTURNOBASE = New SqlDataAdapter(strQUERY, conSQL)
                    dtsTURNOBASE = New DataSet
                    sqldaTURNOBASE.Fill(dtsTURNOBASE, "TurnoBase")
                    For intC2 = 0 To dtsTURNOBASE.Tables(0).Rows.Count - 1
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_livre] ([userid],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                                   "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis], [nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                                   intUSERID & ", '" & strMAQUINA & "', ' " & dtsTURNOBASE.Tables(0).Rows(intC2).Item("nome") & "', 0, 0, 0, 0, 0, 0, 0, 0, " & intDIASUTEIS & ", 0, 0, 0, 0)"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTAPONTAMENTOLIVRE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTAPONTAMENTO_GRUPO(ByVal intUSERID As Integer,
                                                   ByVal intMES As Integer,
                                                   ByVal intANO As Integer,
                                                   ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaESCALA(999) As SqlDataAdapter
        Dim dtsESCALA(999) As DataSet
        Dim sqldaTURNOS(999) As SqlDataAdapter
        Dim dtsTURNOS(999) As DataSet
        Dim sqldaTURNOBASE(999) As SqlDataAdapter
        Dim dtsTURNOBASE(999) As DataSet
        Dim sqldaAMARRADO(999) As SqlDataAdapter
        Dim dtsAMARRADO(999) As DataSet
        Dim sqldaBABEL(999) As SqlDataAdapter
        Dim dtsBABEL(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim intTURNOS As Integer = 0
        Dim strTURNOS(10, 10) As String
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim dtimeDATAAMARRADO As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim strMACHINEID As String = Nothing
        Dim strMACHINETABLE As String = Nothing
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim bolNEXTDAY As Boolean = False
        Dim intTURNO As Integer = 0
        Dim intTURNOINDEX As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim intMAQUINAID As Integer = 0

        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim strMES As String = Nothing
        Dim strTURNO As String = Nothing
        Dim decNODIAM As Decimal = 0D
        Dim decTOTAL As Decimal = 0D

        Dim strDATAINICIALHOJE As String = Nothing
        Dim strDATAFINALHOJE As String = Nothing
        Dim dtimeDATAINICIALHOJE As DateTime = Nothing
        Dim dtimeDATAFINALHOJE As DateTime = Nothing
        Dim dtimeDATAAMARRADOHOJE As Date = Nothing
        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim sqldaPERIODO As SqlDataAdapter
        Dim dtsPERIODO As DataSet
        Dim dtimeDATAINICIALESCALA As DateTime = Nothing
        Dim dtimeDATAFINALESCALA As DateTime = Nothing
        Dim intMACHINEIDBABEL As Integer = 0
        Dim intDIASUTEIS As Integer = 0
        Dim intDIASUTEISHOJE As Integer = 0
        Dim strGRUPOMASTER As String = Nothing

        Dim strHOJEKG As String = Nothing
        Dim strHOJEM As String = Nothing
        Dim strHOJEPC As String = Nothing
        Dim decTURNOINDETERMINADOKG As Decimal = 0D
        Dim decTURNOINDETERMINADOPC As Decimal = 0D
        Dim decTURNOINDETERMINADOM As Decimal = 0D
        Dim decMEDIADIARIAM As Decimal = 0D
        Dim decMEDIADIARIAKG As Decimal = 0D
        Dim decMEDIADIARIAPC As Decimal = 0D
        Dim decTOTALKG As Decimal = 0D
        Dim decTOTALM As Decimal = 0D
        Dim decTOTALPC As Decimal = 0D

        Dim sqldaDAHOJE(99) As SqlDataAdapter
        Dim dtsDAHOJE(99) As DataSet
        Dim sqldaESCALAHOJE(99) As SqlDataAdapter '
        Dim dtsESCALAHOJE(99) As DataSet

        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False

        Dim intMESATUAL As Integer = 0
        Dim intANOATUAL As Integer = 0
        Dim strDATA As String = Nothing

        Try

            'strTURNOS(x, 0) = id do turno
            'strTURNOS(x, 1) = peso acumulados
            'strTURNOS(x, 2) = quantidade acumulada (M)
            'strTURNOS(x, 3) = peso do dia
            'strTURNOS(x, 4) = quantidade do dia (M)
            'strTURNOS(x, 5) = quantidade acumulada (PC)
            'strTURNOS(x, 6) = quantidade do dia (PC)

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            strQUERY = "SELECT exe_MCONTROL_OEE_gruposmaster.gruponome AS grupomaster, exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN " &
                       "exe_MCONTROL_OEE_Maquinas ON exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id INNER JOIN exe_MCONTROL_OEE_master_grupos " &
                       "ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_master_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_gruposmaster ON " &
                       "exe_MCONTROL_OEE_gruposmaster.id = exe_MCONTROL_OEE_master_grupos.masterid WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                       "ORDER BY grupomaster, gruponome, maquinanome"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            'Data Inicial e Final
            '////////////////////
            intMES += 1
            If intMES < 10 Then
                strMES = "0" & intMES
            Else
                strMES = intMES.ToString
            End If
            strDATAINICIAL = "01/" & strMES & "/" & intANO
            reportDATAINICIAL = strDATAINICIAL

            _clsAMARRADOS.Clear()

            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                strGRUPOMASTER = dtsGRUPOS.Tables(0).Rows(intC).Item("grupomaster")
                intDIASUTEIS = 0
                intDIASUTEISHOJE = 0

                ReadDBGETDIASUTEIS(dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid"), intDIASUTEIS, intMES, intANO)
                If intMES < 10 Then
                    strMES = "0" & intMES
                Else
                    strMES = intMES.ToString
                End If
                dtimeDATAINICIAL = Convert.ToDateTime("01/" & strMES & "/" & intANO)
                dtimeDATAFINAL = Now()
                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
                If intDAYS > 31 Or intDAYS < 0 Then
                    intDIASUTEISHOJE = intDIASUTEIS
                Else
                    ReadDBGETDIASUTEISHOJE(dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid"), intDIASUTEISHOJE, intMES, intANO, Now.ToString)
                End If

                reportDIASUTEIS = intDIASUTEISHOJE
                reportTOTALDIASUTEIS = intDIASUTEIS

                strDATAINICIAL = "01/" & strMES & "/" & intANO
                dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATAINICIAL))
                strDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10)
                If DateDiff(DateInterval.Day, dtimeDATAFINAL, Now()) < 0 Then
                    strDATAFINAL = Mid(Convert.ToString(DateAdd(DateInterval.Day, -1, Now())), 1, 10)
                End If
                dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL & " 23:59:59")

                If dtimeDATAFINAL.DayOfWeek.ToString = "Sunday" Then
                    dtimeDATAFINAL = DateAdd(DateInterval.Day, -2, dtimeDATAFINAL)
                ElseIf dtimeDATAFINAL.DayOfWeek.ToString = "Saturday" Then
                    dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, dtimeDATAFINAL)
                End If

                reportDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10)
                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO = New DataSet
                sqldaPERIODO.Fill(dtsPERIODO, "Periodo")

                If dtsPERIODO.Tables(0).Rows.Count > 0 Then
                    strDINICIAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                    strDFINAL = "01/01/2020 " & " " & dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")
                Else
                    GoTo NextMachine
                End If

                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
                If intDAYS < 0 Then
                    dtimeDATAFINAL = DateAdd(DateInterval.Day, 1, dtimeDATAFINAL)
                End If

                strDATAINICIAL = Mid(dtimeDATAINICIAL.ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                strDATAFINAL = Mid(dtimeDATAFINAL.ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horariofinal")
                dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)

                'Verifica se a data final é um feriado
                '//////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] DESC"
                sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
                dtsFERIADOS = New DataSet
                sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")
                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
                For intC2 = 0 To dtsFERIADOS.Tables(0).Rows.Count - 1
                    dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS.Tables(0).Rows(intC2).Item("data"))
                    If dtimeFERIADO = dtimeDATAFINAL Then
                        dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, dtimeDATAFINAL)
                    End If
                Next

                dtimeDATAINICIALHOJE = Convert.ToDateTime(Mid(DateAdd(DateInterval.Day, -1, dtimeDATAFINAL).ToString, 1, 10) & " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial"))
                dtimeDATAFINALHOJE = dtimeDATAFINAL

                intMESATUAL = Now.Month
                intANOATUAL = Now.Year
                If intMES > intMESATUAL And intANO <= intANOATUAL Then
                    dtimeDATAINICIALHOJE = DateAdd(DateInterval.Day, -1, dtimeDATAINICIALHOJE)
                    strDINICIAL = Mid(dtimeDATAINICIALHOJE.ToString, 1, 10)
                    strDINICIAL &= " " & dtsPERIODO.Tables(0).Rows(0).Item("horarioinicial")
                    dtimeDATAINICIALHOJE = Convert.ToDateTime(strDINICIAL)
                End If

                'Busca Turnos
                '////////////
                strMACHINEID = intMACHINEID.ToString("D6")
                strMACHINETABLE = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                            Mid(dtimeDATAINICIAL.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                            Mid(dtimeDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALA(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALA(intC) = New DataSet
                sqldaESCALA(intC).Fill(dtsESCALA(intC), "Escala")

                If dtsESCALA(intC).Tables(0).Rows.Count = 0 Then
                    GoTo NextMachine
                End If

                'Amarrado
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                            "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                            "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                            "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                            "exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID & " AND exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                            "ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
                sqldaBABEL(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL(intC) = New DataSet
                sqldaBABEL(intC).Fill(dtsBABEL(intC), "BABEL")
                intMACHINEIDBABEL = dtsBABEL(intC).Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                           "AND [id_maquinario] = " & intMACHINEIDBABEL & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
                sqldaAMARRADO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsAMARRADO(intC) = New DataSet
                sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaAMARRADO(intC).Fill(dtsAMARRADO(intC), "Amarrado")

                intTURNO = 0
                Array.Clear(strTURNOS, 0, strTURNOS.Length)
                decTURNOINDETERMINADOM = 0
                decTURNOINDETERMINADOPC = 0

                For intC2 = 0 To dtsAMARRADO(intC).Tables(0).Rows.Count - 1
                    For intC3 = 0 To dtsESCALA(intC).Tables(0).Rows.Count - 1
                        dtimeDATAAMARRADO = Convert.ToDateTime(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("data_recebido"))
                        dtimeDATAINICIALESCALA = Convert.ToDateTime(dtsESCALA(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                     dtsESCALA(intC).Tables(0).Rows(intC3).Item("time_begin"))
                        dtimeDATAFINALESCALA = Convert.ToDateTime(dtsESCALA(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                  dtsESCALA(intC).Tables(0).Rows(intC3).Item("time_end"))

                        bolFOUND = False
                        If dtimeDATAAMARRADO >= dtimeDATAINICIALESCALA And dtimeDATAAMARRADO <= dtimeDATAFINALESCALA Then

                            If intTURNO = 0 Then
                                strTURNOS(intTURNO, 0) = dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id")
                                intTURNOINDEX = 0
                                intTURNO += 1
                            Else
                                For intC4 = 0 To intTURNO - 1
                                    If dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id") = strTURNOS(intC4, 0) Then
                                        intTURNOINDEX = intC4
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next
                                If bolFOUND = False Then
                                    strTURNOS(intTURNO, 0) = dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id")
                                    intTURNOINDEX = intTURNO
                                    intTURNO += 1
                                Else
                                    bolFOUND = False
                                End If
                            End If
                            strTURNOS(intTURNOINDEX, 1) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                         (Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("peso")))
                            If dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                strTURNOS(intTURNOINDEX, 2) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                              Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                            ElseIf dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                strTURNOS(intTURNOINDEX, 5) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                              Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                            End If
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        _clsAMARRADOS.Add(New clsAMARRADOS_SEMTURNO(intUSERID,
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("centro_trabalho"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("ordem"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("num_hu"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("lote"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("data_recebido")))
                        decTURNOINDETERMINADOKG += Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                  (Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("peso")))
                        If dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                            decTURNOINDETERMINADOM = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                     Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                        ElseIf dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                            decTURNOINDETERMINADOPC = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                      Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                        End If
                    End If
                Next

                'Quantidade produzida no dia
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                            "AND [id_maquinario] = " & intMACHINEIDBABEL & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
                sqldaDAHOJE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsDAHOJE(intC) = New DataSet
                sqldaDAHOJE(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIALHOJE))
                sqldaDAHOJE(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINALHOJE))
                sqldaDAHOJE(intC).Fill(dtsDAHOJE(intC), "DAHoje")

                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                            Mid(dtimeDATAINICIALHOJE.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                            Mid(dtimeDATAFINALHOJE.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAHOJE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAHOJE(intC) = New DataSet
                sqldaESCALAHOJE(intC).Fill(dtsESCALAHOJE(intC), "EscalaHoje")

                'Dia de Hoje
                '///////////
                If dtsDAHOJE(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsDAHOJE(intC).Tables(0).Rows.Count - 1
                        For intC3 = 0 To dtsESCALAHOJE(intC).Tables(0).Rows.Count - 1
                            dtimeDATAAMARRADO = Convert.ToDateTime(dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("data_recebido"))
                            dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                  dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeDATAFINAL = Convert.ToDateTime(dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("time_end"))
                            bolFOUND = False
                            If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then
                                For intC4 = 0 To intTURNO - 1
                                    If strTURNOS(intC4, 0) = dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("shift_id") Then
                                        strTURNOS(intC4, 3) = Val(strTURNOS(intC4, 3)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("peso")
                                        If dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                            strTURNOS(intC4, 4) = Val(strTURNOS(intC4, 4)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("qtd")
                                        ElseIf dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                            strTURNOS(intC4, 6) = Val(strTURNOS(intC4, 6)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("qtd")
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                If intTURNO > 0 Then
                    For intC2 = 0 To intTURNO - 1
                        strTURNOS(intC2, 1) = Convert.ToDecimal(strTURNOS(intC2, 1)) / 1000
                        strTURNOS(intC2, 3) = Convert.ToDecimal(strTURNOS(intC2, 3)) / 1000
                        For intC3 = 0 To dtsTURNOS(intC).Tables(0).Rows.Count - 1
                            If Val(strTURNOS(intC2, 0)) = dtsTURNOS(intC).Tables(0).Rows(intC3).Item("id") Then
                                strTURNO = dtsTURNOS(intC).Tables(0).Rows(intC3).Item("nome")
                                Exit For
                            End If
                        Next
                        decTOTALM = Convert.ToInt32(strTURNOS(intC2, 2))
                        If strTURNOS(intC2, 2) = Nothing Then
                            strTURNOS(intC2, 2) = "0"
                        End If
                        If strTURNOS(intC2, 5) = Nothing Then
                            strTURNOS(intC2, 5) = "0"
                        End If
                        decMEDIADIARIAKG = Convert.ToDecimal(strTURNOS(intC2, 1)) / intDIASUTEISHOJE
                        decMEDIADIARIAM = (Convert.ToDecimal(strTURNOS(intC2, 2)) / intDIASUTEISHOJE)
                        decMEDIADIARIAPC = (Convert.ToDecimal(strTURNOS(intC2, 5)) / intDIASUTEISHOJE)
                        If strTURNOS(intC2, 3) = Nothing Then
                            strHOJEKG = "0"
                        Else
                            strHOJEKG = strTURNOS(intC2, 3)
                        End If
                        If strTURNOS(intC2, 4) = Nothing Then
                            strHOJEM = "0"
                        Else
                            strHOJEM = Convert.ToDecimal(strTURNOS(intC2, 4))
                        End If
                        If strTURNOS(intC2, 6) = Nothing Then
                            strHOJEPC = "0"
                        Else
                            strHOJEPC = Convert.ToDecimal(strTURNOS(intC2, 6)) / intDIASUTEISHOJE
                        End If
                        If intDIASUTEIS = intDIASUTEISHOJE Then
                            decTOTALKG = Convert.ToDecimal(strTURNOS(intC2, 1))
                            decTOTALM = Convert.ToDecimal(strTURNOS(intC2, 2))
                            decTOTALPC = Convert.ToDecimal(strTURNOS(intC2, 5))
                        Else
                            decTOTALKG = (Convert.ToDecimal(strTURNOS(intC2, 1)) / intDIASUTEISHOJE) * intDIASUTEIS
                            decTOTALM = ((Convert.ToDecimal(strTURNOS(intC2, 2)) / intDIASUTEISHOJE) * intDIASUTEIS)
                            decTOTALPC = ((Convert.ToDecimal(strTURNOS(intC2, 5)) / intDIASUTEISHOJE) * intDIASUTEIS)
                        End If
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] ([userid],[grupomaster],[grupomaquina],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                               "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis],[totaldiasuteis],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                               intUSERID & ", '" & strGRUPOMASTER & "', '" & dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome") & "', '" &
                               dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome") & "', '" &
                               strTURNO & "', " & strHOJEKG.Replace(",", ".") & ", " & strTURNOS(intC2, 1).Replace(",", ".") &
                               ", " & decMEDIADIARIAKG.ToString.Replace(",", ".") & ", " & strHOJEM.Replace(",", ".") & ", " &
                               strTURNOS(intC2, 2).Replace(",", ".") & ", " & decMEDIADIARIAM.ToString.Replace(",", ".") & ", " &
                               decTOTALKG.ToString.Replace(",", ".") & ", " & decTOTALM.ToString.Replace(",", ".") & ", " &
                               intDIASUTEISHOJE & ", " & intDIASUTEIS & ", " & strHOJEPC.Replace(",", ".") & ", " & strTURNOS(intC2, 5).Replace(",", ".") & ", " &
                               decMEDIADIARIAPC.ToString.Replace(",", ".") & ", " & decTOTALPC.ToString.Replace(",", ".") & ")"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next

                Else
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
                    sqldaTURNOBASE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                    dtsTURNOBASE(intC) = New DataSet
                    sqldaTURNOBASE(intC).Fill(dtsTURNOBASE(intC), "TurnoBase")
                    For intC2 = 0 To dtsTURNOBASE(intC).Tables(0).Rows.Count - 1
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] ([userid],[grupomaster],[grupomaquina],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                               "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis],[totaldiasuteis],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                               intUSERID & ", '" & strGRUPOMASTER & "', '" & dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome") & "', '" &
                               dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome") & "', '" &
                               dtsTURNOBASE(intC).Tables(0).Rows(intC2).Item("nome") & "', 0, 0, 0, 0, 0, 0, 0, 0, " & intDIASUTEISHOJE & ", " & intDIASUTEIS & ", 0, 0, 0, 0)"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next

                End If

NextMachine:

            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTAPONTAMENTO_GRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTAPONTAMENTO_PARCIAL(ByVal intUSERID As Integer,
                                                     ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaESCALA(999) As SqlDataAdapter
        Dim dtsESCALA(999) As DataSet
        Dim sqldaTURNOS(999) As SqlDataAdapter
        Dim dtsTURNOS(999) As DataSet
        Dim sqldaAMARRADO(999) As SqlDataAdapter
        Dim dtsAMARRADO(999) As DataSet
        Dim sqldaBABEL(999) As SqlDataAdapter
        Dim dtsBABEL(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim intTURNOS As Integer = 0
        Dim strTURNOS(10, 10) As String
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim dtimeDATAAMARRADO As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim strMACHINEID As String = Nothing
        Dim strMACHINETABLE As String = Nothing
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim bolNEXTDAY As Boolean = False
        Dim intTURNO As Integer = 0
        Dim intTURNOINDEX As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim intMAQUINAID As Integer = 0
        Dim decPESOTURNOINDETERMINADO As Decimal = 0D
        Dim decMETROSINDETERMIANDO As Decimal = 0D
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim strMES As String = Nothing
        Dim strTURNO As String = Nothing
        Dim decNODIAM As Decimal = 0D
        Dim decTOTAL As Decimal = 0D
        Dim decTOTALM As Decimal = 0D
        Dim decMEDIADIARIAM As Decimal = 0D
        Dim decMEDIADIARIA As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strDATAINICIALHOJE As String = Nothing
        Dim strDATAFINALHOJE As String = Nothing
        Dim dtimeDATAINICIALHOJE As DateTime = Nothing
        Dim dtimeDATAFINALHOJE As DateTime = Nothing
        Dim dtimeDATAAMARRADOHOJE As Date = Nothing
        Dim strPESOHOJE As String = Nothing
        Dim strMETROSHOJE As String = Nothing
        Dim decPESOTOTAL As Decimal = 0D
        Dim decMETROSTOTAL As Decimal = 0D
        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim sqldaPERIODO(99) As SqlDataAdapter
        Dim dtsPERIODO(99) As DataSet

        Dim dtsFERIADOS(99) As DataSet
        Dim sqldaFERIADOS(99) As SqlDataAdapter
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim intDIASUTEIS As Integer = 0
        Dim intDIASUTEISHOJE As Integer = 0
        Dim dtimeDATA As DateTime = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim intMES As Integer = 0
        Dim sqldaTURNOBASE(999) As SqlDataAdapter
        Dim dtsTURNOBASE(999) As DataSet

        Dim strHOJEKG As String = Nothing
        Dim strHOJEM As String = Nothing
        Dim strHOJEPC As String = Nothing
        Dim decTURNOINDETERMINADOKG As Decimal = 0D
        Dim decTURNOINDETERMINADOPC As Decimal = 0D
        Dim decTURNOINDETERMINADOM As Decimal = 0D
        Dim decMEDIADIARIAKG As Decimal = 0D
        Dim decMEDIADIARIAPC As Decimal = 0D
        Dim decTOTALKG As Decimal = 0D
        Dim decTOTALPC As Decimal = 0D
        Dim strGRUPOMASTER As String = Nothing

        Dim sqldaDAHOJE(99) As SqlDataAdapter
        Dim dtsDAHOJE(99) As DataSet
        Dim sqldaESCALAHOJE(99) As SqlDataAdapter '
        Dim dtsESCALAHOJE(99) As DataSet
        Dim strDATA As String = Nothing

        Try

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            strQUERY = "SELECT exe_MCONTROL_OEE_gruposmaster.gruponome AS grupomaster, exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN " &
                       "exe_MCONTROL_OEE_Maquinas ON exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id INNER JOIN exe_MCONTROL_OEE_master_grupos " &
                       "ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_master_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_gruposmaster ON " &
                       "exe_MCONTROL_OEE_gruposmaster.id = exe_MCONTROL_OEE_master_grupos.masterid WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                       "ORDER BY grupomaster, gruponome, maquinanome"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")


            'Data Inicial e Final
            '////////////////////
            strDATAINICIAL = Mid(Now(), 1, 10)
            reportDATAINICIAL = strDATAINICIAL
            reportDATAFINAL = strDATAINICIAL

            _clsAMARRADOS.Clear()

            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")
                strGRUPOMASTER = dtsGRUPOS.Tables(0).Rows(intC).Item("grupomaster")
                intDIASUTEIS = 1
                intDIASUTEISHOJE = 1

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO(intC) = New DataSet
                sqldaPERIODO(intC).Fill(dtsPERIODO(intC), "Periodo")

                If dtsPERIODO(intC).Tables(0).Rows.Count = 0 Then
                    GoTo NextMachine
                End If

                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horarioinicial")
                dtimeDATAINICIAL = Convert.ToDateTime(Mid(Now().ToString, 1, 10) & " " & Mid(strDINICIAL, 12, 8))
                dtimeDATAFINAL = Now()

                dtimeDATAINICIALHOJE = dtimeDATAINICIAL
                dtimeDATAFINALHOJE = dtimeDATAFINAL

                'Total de Dias Úteis
                '///////////////////
                intDIASUTEIS = 0
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
                sqldaFERIADOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsFERIADOS(intC) = New DataSet
                sqldaFERIADOS(intC).Fill(dtsFERIADOS(intC), "Feriados")
                intMES = Now().Month
                If intMES < 10 Then
                    strMES = "0" & intMES
                Else
                    strMES = intMES.ToString
                End If
                dtimeDATA = Convert.ToDateTime("01/" & strMES & "/" & Now().Year.ToString)
                strDATAINICIAL = dtimeDATA.ToString
                dtimeDATA = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATA))
                For intC2 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                    If dtimeDATA = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC2).Item("data")) Then
                        dtimeDATA = DateAdd(DateInterval.Day, -1, dtimeDATA)
                        If dtimeDATA.DayOfWeek.ToString = "Sunday" Then
                            dtimeDATA = DateAdd(DateInterval.Day, -2, dtimeDATA)
                        ElseIf dtimeDATA.DayOfWeek.ToString = "Saturday" Then
                            dtimeDATA = DateAdd(DateInterval.Day, -1, dtimeDATA)
                        End If
                    End If
                Next
                dtimeDATAINI = Convert.ToDateTime(Mid(strDATAINICIAL, 1, 10) & " 00:00:00")
                dtimeDATAFIM = Convert.ToDateTime(Mid(dtimeDATA.ToString, 1, 10) & " 23:59:59")

                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINI, dtimeDATAFIM)
                If intDAYS > 0 Then
                    For intC2 = 0 To intDAYS
                        strDATA = DateAdd(DateInterval.Day, intC2, dtimeDATAINI).ToShortDateString()
                        dtimeDATA = Convert.ToDateTime(strDATA)
                        For intC3 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                            dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC3).Item("data"))
                            If dtimeFERIADO = dtimeDATA Then
                                bolFERIADO = True
                                Exit For
                            End If
                        Next
                        If bolFERIADO = False Then
                            If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                                intDIASUTEIS += 1
                            End If
                        Else
                            bolFERIADO = False
                        End If
                    Next
                End If
                reportTOTALDIASUTEIS = intDIASUTEIS

                'Busca Turnos
                '////////////
                strMACHINEID = intMACHINEID.ToString("D6")
                strMACHINETABLE = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                            Mid(dtimeDATAINICIAL.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                            Mid(dtimeDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALA(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALA(intC) = New DataSet
                sqldaESCALA(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaESCALA(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaESCALA(intC).Fill(dtsESCALA(intC), "Escala")

                If dtsESCALA(intC).Tables(0).Rows.Count = 0 Then
                    GoTo NextMachine
                End If

                'Amarrado
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                           "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                           "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                           "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                           "exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID & " AND exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                           "ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
                sqldaBABEL(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL(intC) = New DataSet
                sqldaBABEL(intC).Fill(dtsBABEL(intC), "BABEL")
                intMAQUINAID = dtsBABEL(intC).Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                           "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_hora_inicio] ASC"
                sqldaAMARRADO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsAMARRADO(intC) = New DataSet
                sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIALHOJE))
                sqldaAMARRADO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINALHOJE))
                sqldaAMARRADO(intC).Fill(dtsAMARRADO(intC), "Amarrado")
                intTURNO = 0
                Array.Clear(strTURNOS, 0, strTURNOS.Length)
                decPESOTURNOINDETERMINADO = 0
                decMETROSINDETERMIANDO = 0

                For intC2 = 0 To dtsAMARRADO(intC).Tables(0).Rows.Count - 1
                    For intC3 = 0 To dtsESCALA(intC).Tables(0).Rows.Count - 1
                        dtimeDATAAMARRADO = Convert.ToDateTime(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("data_recebido"))
                        dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALA(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                              dtsESCALA(intC).Tables(0).Rows(intC3).Item("time_begin"))
                        dtimeDATAFINAL = Convert.ToDateTime(dtsESCALA(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                            dtsESCALA(intC).Tables(0).Rows(intC3).Item("time_end"))

                        bolFOUND = False
                        If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then

                            If intTURNO = 0 Then
                                strTURNOS(intTURNO, 0) = dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id")
                                intTURNOINDEX = 0
                                intTURNO += 1
                            Else
                                For intC4 = 0 To intTURNO - 1
                                    If dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id") = strTURNOS(intC4, 0) Then
                                        intTURNOINDEX = intC4
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next
                                If bolFOUND = False Then
                                    strTURNOS(intTURNO, 0) = dtsESCALA(intC).Tables(0).Rows(intC3).Item("shift_id")
                                    intTURNOINDEX = intTURNO
                                    intTURNO += 1
                                Else
                                    bolFOUND = False
                                End If
                            End If
                            strTURNOS(intTURNOINDEX, 1) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                          Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("peso"))
                            If dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                strTURNOS(intTURNOINDEX, 2) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                              Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                            ElseIf dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                strTURNOS(intTURNOINDEX, 5) = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                              Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                            End If
                            bolFOUND = True
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        _clsAMARRADOS.Add(New clsAMARRADOS_SEMTURNO(intUSERID,
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("centro_trabalho"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("ordem"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("num_hu"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("lote"),
                                                                    dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("data_recebido")))
                        decPESOTURNOINDETERMINADO += Convert.ToDecimal(strTURNOS(intTURNOINDEX, 1)) +
                                                     Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("peso"))
                        If dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                            decTURNOINDETERMINADOM = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 2)) +
                                                              Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                        ElseIf dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                            decTURNOINDETERMINADOPC = Convert.ToDecimal(strTURNOS(intTURNOINDEX, 5)) +
                                                      Convert.ToDecimal(dtsAMARRADO(intC).Tables(0).Rows(intC2).Item("qtd"))
                        End If
                    End If
                Next

                'Quantidade produzida no dia
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                           "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
                sqldaDAHOJE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsDAHOJE(intC) = New DataSet
                sqldaDAHOJE(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIALHOJE))
                sqldaDAHOJE(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINALHOJE))
                sqldaDAHOJE(intC).Fill(dtsDAHOJE(intC), "DAHoje")

                strQUERY = "SELECT * FROM " & strMACHINETABLE & " WHERE [date_shift] >= convert(Date, '" &
                            Mid(dtimeDATAINICIALHOJE.ToString, 1, 10) & "',103) AND [date_shift] <= convert(date, '" &
                            Mid(dtimeDATAFINALHOJE.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAHOJE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAHOJE(intC) = New DataSet
                sqldaESCALAHOJE(intC).Fill(dtsESCALAHOJE(intC), "EscalaHoje")

                'Dia de Hoje
                '///////////
                If dtsDAHOJE(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsDAHOJE(intC).Tables(0).Rows.Count - 1
                        For intC3 = 0 To dtsESCALAHOJE(intC).Tables(0).Rows.Count - 1
                            dtimeDATAAMARRADO = Convert.ToDateTime(dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("data_recebido"))
                            dtimeDATAINICIAL = Convert.ToDateTime(dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                  dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeDATAFINAL = Convert.ToDateTime(dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("date_shift") & " " &
                                                                dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("time_end"))
                            bolFOUND = False
                            If dtimeDATAAMARRADO >= dtimeDATAINICIAL And dtimeDATAAMARRADO <= dtimeDATAFINAL Then
                                For intC4 = 0 To intTURNO - 1
                                    If strTURNOS(intC4, 0) = dtsESCALAHOJE(intC).Tables(0).Rows(intC3).Item("shift_id") Then
                                        strTURNOS(intC4, 3) = Val(strTURNOS(intC4, 3)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("peso")
                                        If dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("unidade") = "M" Then
                                            strTURNOS(intC4, 4) = Val(strTURNOS(intC4, 4)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("qtd")
                                        ElseIf dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("unidade") = "PC" Then
                                            strTURNOS(intC4, 6) = Val(strTURNOS(intC4, 6)) + dtsDAHOJE(intC).Tables(0).Rows(intC2).Item("qtd")
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                If intTURNO > 0 Then
                    For intC2 = 0 To intTURNO - 1
                        strTURNOS(intC2, 1) = Convert.ToDecimal(strTURNOS(intC2, 1)) / 1000
                        strTURNOS(intC2, 3) = Convert.ToDecimal(strTURNOS(intC2, 3)) / 1000
                        For intC3 = 0 To dtsTURNOS(intC).Tables(0).Rows.Count - 1
                            If Val(strTURNOS(intC2, 0)) = dtsTURNOS(intC).Tables(0).Rows(intC3).Item("id") Then
                                strTURNO = dtsTURNOS(intC).Tables(0).Rows(intC3).Item("nome")
                                Exit For
                            End If
                        Next
                        decTOTALM = Convert.ToInt32(strTURNOS(intC2, 2))
                        If strTURNOS(intC2, 2) = Nothing Then
                            strTURNOS(intC2, 2) = "0"
                        End If
                        If strTURNOS(intC2, 5) = Nothing Then
                            strTURNOS(intC2, 5) = "0"
                        End If
                        decMEDIADIARIAKG = Convert.ToDecimal(strTURNOS(intC2, 1)) / intDIASUTEISHOJE
                        decMEDIADIARIAM = (Convert.ToDecimal(strTURNOS(intC2, 2)) / intDIASUTEISHOJE)
                        decMEDIADIARIAPC = (Convert.ToDecimal(strTURNOS(intC2, 5)) / intDIASUTEISHOJE)
                        If strTURNOS(intC2, 3) = Nothing Then
                            strHOJEKG = "0"
                        Else
                            strHOJEKG = strTURNOS(intC2, 3)
                        End If
                        If strTURNOS(intC2, 4) = Nothing Then
                            strHOJEM = "0"
                        Else
                            strHOJEM = Convert.ToDecimal(strTURNOS(intC2, 4))
                        End If
                        If strTURNOS(intC2, 6) = Nothing Then
                            strHOJEPC = "0"
                        Else
                            strHOJEPC = Convert.ToDecimal(strTURNOS(intC2, 6)) / intDIASUTEISHOJE
                        End If
                        decTOTALKG = (Convert.ToDecimal(strTURNOS(intC2, 1))) * intDIASUTEIS
                        decTOTALM = ((Convert.ToDecimal(strTURNOS(intC2, 2))) * intDIASUTEIS)
                        decTOTALPC = ((Convert.ToDecimal(strTURNOS(intC2, 5))) * intDIASUTEIS)
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] ([userid],[grupomaster],[grupomaquina],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                                   "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis],[totaldiasuteis],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                                   intUSERID & ", '" & strGRUPOMASTER & "', '" & dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome") & "', '" &
                                   dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome") & "', '" &
                                   strTURNO & "', " & strHOJEKG.Replace(",", ".") & ", " & strTURNOS(intC2, 1).Replace(",", ".") &
                                   ", " & decMEDIADIARIAKG.ToString.Replace(",", ".") & ", " & strHOJEM.Replace(",", ".") & ", " &
                                   strTURNOS(intC2, 2).Replace(",", ".") & ", " & decMEDIADIARIAM.ToString.Replace(",", ".") & ", " &
                                   decTOTALKG.ToString.Replace(",", ".") & ", " & decTOTALM.ToString.Replace(",", ".") & ", 1, 1, " &
                                   strHOJEPC.Replace(",", ".") & ", " & strTURNOS(intC2, 5).Replace(",", ".") & ", " &
                                   decMEDIADIARIAPC.ToString.Replace(",", ".") & ", " & decTOTALPC.ToString.Replace(",", ".") & ")"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next
                Else
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID & " ORDER BY [nome] ASC"
                    sqldaTURNOBASE(intC) = New SqlDataAdapter(strQUERY, conSQL)
                    dtsTURNOBASE(intC) = New DataSet
                    sqldaTURNOBASE(intC).Fill(dtsTURNOBASE(intC), "TurnoBase")
                    For intC2 = 0 To dtsTURNOBASE(intC).Tables(0).Rows.Count - 1
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] ([userid],[grupomaster],[grupomaquina],[maquina],[turno],[nodia],[total],[mediadiaria]," &
                                   "[nodiam],[totalm],[mediadiariam],[peso],[metros],[diasuteis],[totaldiasuteis],[nodiapecas],[totalpecas],[mediadiariapecas],[pecas]) VALUES (" &
                                   intUSERID & ", '" & strGRUPOMASTER & "', '" & dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome") & "', '" &
                                   dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome") & "', '" &
                                   dtsTURNOBASE(intC).Tables(0).Rows(intC2).Item("nome") & "', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0)"
                        sqlcmdREPORT.CommandText = strQUERY
                        sqlcmdREPORT.ExecuteNonQuery()
                    Next
                End If

NextMachine:

            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTAPONTAMENTO_GRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'PRODUTIVIDADE
    '/////////////
    Public Function WriteDBREPORTPRODUTIVIDADE(ByVal intMACHINEID As Integer,
                                               ByVal strDATAINICIAL As String,
                                               ByVal strDATAFINAL As String,
                                               ByVal strHORAINICIAL As String,
                                               ByVal strHORAFINAL As String,
                                               ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtESCALAS As New DataSet
        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim bolNEWDAY As Boolean = False
        Dim strTURNOHORAINICIAL As String = Nothing
        Dim strTURNOHORAFINAL As String = Nothing
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing
        Dim sqldaPARADAS As SqlDataAdapter
        Dim dtsPARADAS As DataSet
        Dim sqldaTESTES As SqlDataAdapter
        Dim dtsTESTES As DataSet
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim strMOTIVOPARADA(999, 5) As String
        Dim bolFOUND As Boolean = False
        Dim intCONTPARADAS As Integer = 0
        Dim intPARADAS As Decimal = 0D
        Dim intCONTROLE As Integer = 0
        Dim strMOTIVOPARADATEMP(5) As String
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim intBABELID As Integer = 0
        Dim sqldaPRODUCAO As SqlDataAdapter
        Dim dtsPRODUCAO As DataSet
        Dim decPESOTOTAL As Decimal = 0D
        Dim decCOMPRIMENTOTAL As Decimal = 0D

        Dim sqldaPPROG As SqlDataAdapter
        Dim dtsPPROG As DataSet
        Dim decPPROG As Decimal = 0D
        Dim dtimePPROGINI As DateTime = Nothing
        Dim dtimePPROGFIM As DateTime = Nothing

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Dim dtimeESCALAINICIAL As DateTime = Nothing
        Dim dtimeESCALAFIM As DateTime = Nothing
        Dim dtimePARADAINICIAL As DateTime = Nothing
        Dim dtimePARADAFINAL As DateTime = Nothing
        Dim dtimeNOVAPARADAINICIAL As DateTime = Nothing

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_produtividade] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            strMACHINEID = intMACHINEID.ToString("D6")
            strNEWDATAINICIAL = strDATAINICIAL & " " & strHORAINICIAL
            strNEWDATAFINAL = strDATAFINAL & " " & strHORAFINAL
            dtimeDATAINI = Convert.ToDateTime(strNEWDATAINICIAL)
            dtimeDATAFIM = Convert.ToDateTime(strNEWDATAFINAL)
            strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
            strQUERY = "SELECT * FROM " & strTABLENAME & " WHERE [date_shift] >= convert(Date, '" &
                       Mid(dtimeDATAINI.ToString, 1, 10) & "' ,103) And [date_shift] <= convert(Date, '" &
                       Mid(dtimeDATAFIM.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
            Dim sqlaESCALAS As New SqlDataAdapter(strQUERY, conSQL)
            sqlaESCALAS.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(Mid(strNEWDATAINICIAL, 1, 10))))
            sqlaESCALAS.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(Mid(strNEWDATAFINAL, 1, 10))))
            sqlaESCALAS.Fill(dtESCALAS, "Escalas")

            'Cálculo de Disponibilidade
            '//////////////////////////
            If dtESCALAS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtESCALAS.Tables(0).Rows.Count - 1
                    strDATADAYSINI = dtESCALAS.Tables(0).Rows(intC).Item("date_shift") & " " & dtESCALAS.Tables(0).Rows(intC).Item("time_begin")
                    strDATADAYSFIM = dtESCALAS.Tables(0).Rows(intC).Item("date_shift") & " " & dtESCALAS.Tables(0).Rows(intC).Item("time_end")
                    dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                    dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                    If dtimeDATADAYSINI >= dtimeDATAINI And dtimeDATADAYSFIM <= dtimeDATAFIM Then
                        reportHORASDISPONIVEL += DateDiff(DateInterval.Second, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                    End If
                Next
            End If

            'Verifica Paradas Programadas
            '////////////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                       "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 1"
            sqldaPPROG = New SqlDataAdapter(strQUERY, conSQL)
            dtsPPROG = New DataSet
            sqldaPPROG.SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINI))
            sqldaPPROG.SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFIM))
            sqldaPPROG.Fill(dtsPPROG, "ParadasProgramadas")
            If dtsPPROG.Tables(0).Rows.Count > 0 Then
                For intC2 = 0 To dtsPPROG.Tables(0).Rows.Count - 1
                    dtimePPROGINI = Convert.ToDateTime(dtsPPROG.Tables(0).Rows(intC2).Item("DateTimeOn"))
                    dtimePPROGFIM = Convert.ToDateTime(dtsPPROG.Tables(0).Rows(intC2).Item("DateTimeOff"))
                    decPPROG += DateDiff(DateInterval.Second, dtimePPROGINI, dtimePPROGFIM)
                Next
            End If
            reportHORASDISPONIVEL -= decPPROG
            intHORA = Int(reportHORASDISPONIVEL / 3600)
            decFracionario = (reportHORASDISPONIVEL / 3600) - intHORA
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
            sreportHORASDISPONIVEL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")

            'Motivos Testes
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [testes] = 1"
            sqldaTESTES = New SqlDataAdapter(strQUERY, conSQL)
            dtsTESTES = New DataSet
            sqldaTESTES.Fill(dtsTESTES, "Testes")


            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] INNER JOIN exe_MCONTROL_OEE_motivosnivel1 ON " &
                       "exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                       "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 0"
            sqldaPARADAS = New SqlDataAdapter(strQUERY, conSQL)
            dtsPARADAS = New DataSet
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINI))
            sqldaPARADAS.SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFIM))
            sqldaPARADAS.Fill(dtsPARADAS, "Paradas")
            If dtsPARADAS.Tables(0).Rows.Count > 0 Then

                For intC = 0 To dtsPARADAS.Tables(0).Rows.Count - 1

                    dtimePARADAINICIAL = dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn")
                    dtimePARADAFINAL = dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff")

                    For intC2 = 0 To dtESCALAS.Tables(0).Rows.Count - 1

                        dtimeESCALAINICIAL = Convert.ToDateTime(dtESCALAS.Tables(0).Rows(intC2).Item("date_shift") & " " & dtESCALAS.Tables(0).Rows(intC2).Item("time_begin"))
                        dtimeESCALAFIM = Convert.ToDateTime(dtESCALAS.Tables(0).Rows(intC2).Item("date_shift") & " " & dtESCALAS.Tables(0).Rows(intC2).Item("time_end"))
                        If dtimePARADAINICIAL >= dtimeESCALAINICIAL And dtimePARADAINICIAL <= dtimeESCALAFIM Then
                            bolFOUND = True
                            Exit For
                        End If

                    Next

                    If bolFOUND = True Then

                        bolFOUND = False
                        If intCONTPARADAS = 0 Then

                            If IsDBNull(dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")) = False Then

                                'Setup
                                '//////
                                For intC2 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                    If dtsSETUP.Tables(0).Rows(intC2).Item("id") = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId") Then
                                        reportHORASSETUP += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                          dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next

                                'Testes
                                '///////
                                For intC2 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                    If IsDBNull(dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")) = False Then
                                        If dtsTESTES.Tables(0).Rows(intC2).Item("id") = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId") Then
                                            reportHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                              dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    End If
                                Next

                                'É relamente uma parada
                                '///////////////////////
                                If bolFOUND = False Then
                                    strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS.Tables(0).Rows(intC).Item("Motivo")
                                    strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")
                                    strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                                   dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                    reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                       dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                    intCONTPARADAS += 1
                                Else
                                    bolFOUND = False
                                End If

                            Else

                                strMOTIVOPARADA(intCONTPARADAS, 0) = "INDETERMINADO"
                                strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                                strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                               dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                   dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                intCONTPARADAS += 1

                            End If

                        Else

                            If IsDBNull(dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")) = False Then

                                'Setup
                                '//////
                                For intC2 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                    If dtsSETUP.Tables(0).Rows(intC2).Item("id") = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId") Then
                                        reportHORASSETUP += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                          dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next

                                'Testes
                                '///////
                                For intC2 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                    If IsDBNull(dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")) = False Then
                                        If dtsTESTES.Tables(0).Rows(intC2).Item("id") = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId") Then
                                            reportHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                              dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    End If
                                Next

                                If bolFOUND = False Then
                                    For intC2 = 0 To intCONTPARADAS - 1
                                        If dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId") = strMOTIVOPARADA(intC2, 1) Then
                                            bolFOUND = True
                                            strMOTIVOPARADA(intC2, 2) = Val(strMOTIVOPARADA(intC2, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                         dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                            reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                               dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                            Exit For
                                        End If
                                    Next
                                    If bolFOUND = True Then
                                        bolFOUND = False
                                    Else
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS.Tables(0).Rows(intC).Item("Motivo")
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS.Tables(0).Rows(intC).Item("MotivoId")
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                                       dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                           dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    End If
                                Else
                                    bolFOUND = False
                                End If

                            Else

                                'Parada sem motivo registrado
                                '////////////////////////////
                                For intC2 = 0 To intCONTPARADAS - 1
                                    If strMOTIVOPARADA(intC2, 1) = "9999" Then
                                        bolFOUND = True
                                        strMOTIVOPARADA(intC2, 2) = Val(strMOTIVOPARADA(intC2, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                     dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                           dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                        Exit For
                                    End If
                                Next
                                If bolFOUND = True Then
                                    bolFOUND = False
                                Else
                                    strMOTIVOPARADA(intCONTPARADAS, 0) = "INDETERMINADO"
                                    strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                                    strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                                                   dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                    reportHORASPARADA += DateDiff(DateInterval.Second, dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOn"),
                                                                                       dtsPARADAS.Tables(0).Rows(intC).Item("DateTimeOff"))
                                    intCONTPARADAS += 1
                                End If
                            End If
                        End If
                    End If

                Next

                If reportHORASSETUP > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "SETUP"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = "0"
                    strMOTIVOPARADA(intCONTPARADAS, 2) = reportHORASSETUP
                    intCONTPARADAS += 1
                End If

                If reportHORASTESTE > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = "0"
                    strMOTIVOPARADA(intCONTPARADAS, 2) = reportHORASTESTE
                    intCONTPARADAS += 1
                End If

            End If

            'Coloca em Ordem Crescente de tempo as paradas
            '/////////////////////////////////////////////
            If intCONTPARADAS > 1 Then
                intCONTROLE = 1
                For intC = 0 To intCONTPARADAS - 2
                    strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC, 0)
                    strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC, 1)
                    strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC, 2)
                    strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC, 3)
                    strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC, 4)
                    strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC, 5)
                    For intC2 = intCONTROLE To intCONTPARADAS - 1
                        If Convert.ToInt32(strMOTIVOPARADATEMP(2)) < Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) Then
                            strMOTIVOPARADA(intC, 0) = strMOTIVOPARADA(intC2, 0)
                            strMOTIVOPARADA(intC, 1) = strMOTIVOPARADA(intC2, 1)
                            strMOTIVOPARADA(intC, 2) = strMOTIVOPARADA(intC2, 2)
                            strMOTIVOPARADA(intC, 3) = strMOTIVOPARADA(intC2, 3)
                            strMOTIVOPARADA(intC, 4) = strMOTIVOPARADA(intC2, 4)
                            strMOTIVOPARADA(intC, 5) = strMOTIVOPARADA(intC2, 5)
                            strMOTIVOPARADA(intC2, 0) = strMOTIVOPARADATEMP(0)
                            strMOTIVOPARADA(intC2, 1) = strMOTIVOPARADATEMP(1)
                            strMOTIVOPARADA(intC2, 2) = strMOTIVOPARADATEMP(2)
                            strMOTIVOPARADA(intC2, 3) = strMOTIVOPARADATEMP(3)
                            strMOTIVOPARADA(intC2, 4) = strMOTIVOPARADATEMP(4)
                            strMOTIVOPARADA(intC2, 5) = strMOTIVOPARADATEMP(5)
                            strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC, 0)
                            strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC, 1)
                            strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC, 2)
                            strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC, 3)
                            strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC, 4)
                            strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC, 5)
                        End If
                    Next
                    intCONTROLE += 1
                Next
            End If

            'Horas Paradas
            '/////////////
            intHORA = Int(reportHORASPARADA / 3600)
            decFracionario = (reportHORASPARADA / 3600) - intHORA
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
            sreportHORASPARADA = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

            'Setup
            '/////
            intHORA = Int(reportHORASSETUP / 3600)
            decFracionario = (reportHORASSETUP / 3600) - intHORA
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
            sreportHORASSETUP = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

            'Testes
            '//////
            intHORA = Int(reportHORASTESTE / 3600)
            decFracionario = (reportHORASTESTE / 3600) - intHORA
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
            sreportHORASTESTE = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

            'Disponibilidade
            '///////////////
            If reportHORASDISPONIVEL > 0 Then
                reportDISPONIBILIDADE = (reportHORASDISPONIVEL - (reportHORASPARADA + reportHORASSETUP + reportHORASTESTE)) / reportHORASDISPONIVEL
            Else
                reportDISPONIBILIDADE = 0
            End If

            'Tempo Útil
            '///////////

            reportHORASTEMPOUTIL = reportHORASDISPONIVEL - (reportHORASPARADA + reportHORASSETUP + reportHORASTESTE)
            intHORA = Int(reportHORASTEMPOUTIL / 3600)
            decFracionario = (reportHORASTEMPOUTIL / 3600) - intHORA
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
            sreportHORASTEMPOUTIL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

            If reportHORASDISPONIVEL > 0 Then
                reportHORASTEMPOUTILPERCENTUAL = reportHORASTEMPOUTIL / reportHORASDISPONIVEL
                reportHORASPARADAPERCENTUAL = reportHORASPARADA / reportHORASDISPONIVEL
                reportHORASSETUPPERCENTUAL = reportHORASSETUP / reportHORASDISPONIVEL
                reportHORASTESTEPERCENTUAL = reportHORASTESTE / reportHORASDISPONIVEL
            Else
                reportHORASTEMPOUTILPERCENTUAL = 0
                reportHORASPARADAPERCENTUAL = 0
                reportHORASSETUPPERCENTUAL = 0
                reportHORASTESTEPERCENTUAL = 0
            End If

            'Produção
            '////////
            strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                       "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                       "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                       "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                       "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
            sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
            dtsBABEL = New DataSet
            sqldaBABEL.Fill(dtsBABEL, "BABEL")
            intBABELID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
            strQUERY = "SELECT SUM([exe_MCONTROL_BABELFISH_amarrado].[peso]) AS pesototal, SUM(CAST([exe_MCONTROL_BABELFISH_amarrado].[qtd] AS INT)) " &
                       "as metrostotal FROM exe_MCONTROL_BABELFISH_amarrado WHERE [id_maquinario] = '" & intBABELID &
                       "' And [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] >= @DI AND " &
                       "[exe_MCONTROL_BABELFISH_amarrado].[data_recebido] <= @DF AND [unidade] = 'M' AND [exe_MCONTROL_BABELFISH_amarrado].[deleted] = 0"
            sqldaPRODUCAO = New SqlDataAdapter(strQUERY, conSQL)
            dtsPRODUCAO = New DataSet
            sqldaPRODUCAO.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strNEWDATAINICIAL)))
            sqldaPRODUCAO.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strNEWDATAFINAL)))
            sqldaPRODUCAO.Fill(dtsPRODUCAO, "Producao")
            If IsDBNull(dtsPRODUCAO.Tables(0).Rows(0).Item("pesototal")) = False Then
                reportTONELAGEM = Convert.ToDecimal(dtsPRODUCAO.Tables(0).Rows(0).Item("pesototal")) / 1000
            Else
                reportTONELAGEM = 0D
            End If
            If IsDBNull(dtsPRODUCAO.Tables(0).Rows(0).Item("metrostotal")) = False Then
                reportMETROS = Convert.ToDecimal(dtsPRODUCAO.Tables(0).Rows(0).Item("metrostotal"))
            Else
                reportMETROS = 0D
            End If

            'Registro de Paradas
            '///////////////////

            Dim intTEMPOPARADASSEGUNDOS As Integer = 0

            For intC = 0 To intCONTPARADAS - 1
                intHORA = Int(strMOTIVOPARADA(intC, 2) / 3600)
                decFracionario = (strMOTIVOPARADA(intC, 2) / 3600) - intHORA
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
                intTEMPOPARADASSEGUNDOS = intMINUTO * 60 + intSEGUNDO
                strMOTIVOPARADA(intC, 3) = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                If reportHORASDISPONIVEL > 0 Then
                    strMOTIVOPARADA(intC, 4) = Convert.ToInt32(strMOTIVOPARADA(intC, 2)) / reportHORASDISPONIVEL
                Else
                    strMOTIVOPARADA(intC, 4) = 0
                End If
                strMOTIVOPARADA(intC, 4) = strMOTIVOPARADA(intC, 4).Replace(",", ".")
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_produtividade] ([userid],[motivoparada]," &
                                           "[tempominutos],[tempototal],[percentual],[tempoParadaSegundos]) VALUES (" & intUSERID & ", '" &
                                           strMOTIVOPARADA(intC, 0) & "', " & (Convert.ToInt32(strMOTIVOPARADA(intC, 2)) / 60).ToString.Replace(",", ".") & ", '" &
                                           strMOTIVOPARADA(intC, 3) & "', " & strMOTIVOPARADA(intC, 4).Replace(",", ".") & ", " & intTEMPOPARADASSEGUNDOS & ")"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTPRODUTIVIDADE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTPRODUTIVIDADE_GRUPO(ByVal intANOFISCAL As Integer,
                                                     ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim bolNEWDAY As Boolean = False
        Dim strTURNOHORAINICIAL As String = Nothing
        Dim strTURNOHORAFINAL As String = Nothing
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing

        Dim sqldaTESTES As SqlDataAdapter
        Dim dtsTESTES As DataSet

        Dim strMOTIVOPARADA(999, 5) As String
        Dim bolFOUND As Boolean = False
        Dim intCONTPARADAS As Integer = 0
        Dim intPARADAS As Decimal = 0D
        Dim intCONTROLE As Integer = 0
        Dim strMOTIVOPARADATEMP(5) As String
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim intBABELID As Integer = 0

        Dim decPESOTOTAL As Decimal = 0D
        Dim decCOMPRIMENTOTAL As Decimal = 0D

        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim intMES As Integer = 0
        Dim intANO As Integer = 0
        Dim dtimeDATA As DateTime = Nothing
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim sqldaESCALAS(99) As SqlDataAdapter
        Dim dtsESCALAS(99) As DataSet
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim sqldaPARADAS(99) As SqlDataAdapter
        Dim dtsPARADAS(99) As DataSet
        Dim sqldaPRODUCAO(99) As SqlDataAdapter
        Dim dtsPRODUCAO(99) As DataSet
        Dim strGRUPONOME As String = Nothing
        Dim strMAQUINANOME As String = Nothing
        Dim decTONELADAS As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strHORASTESTE As String = Nothing
        Dim strHORASETUP As String = Nothing
        Dim strHORASPARADAS As String = Nothing
        Dim strHORASDISPONIVEL As String = Nothing
        Dim decHORASPARADAS As Decimal = 0D
        Dim decHORASETUP As Decimal = 0D
        Dim decHORASTESTE As Decimal = 0D
        Dim decHORASDISPONIVEL As Decimal = 0D
        Dim decDISPONIBILIDADE As Decimal = 0D
        Dim decHORASTEMPOUTIL As Decimal = 0D
        Dim strHORASTEMPOUTIL As String = Nothing
        Dim decHORASTEMPOUTILPERCENTUAL As Decimal = 0D
        Dim decHORASPARADAPERCENTUAL As Decimal = 0D
        Dim decHORASSETUPPERCENTUAL As Decimal = 0D
        Dim decHORASTESTEPERCENTUAL As Decimal = 0D
        Dim strPARADAS(99) As String
        Dim strPARADASTEMPOTOTAL(99) As String
        Dim intDAYS As Integer = 0
        Dim dtsFERIADOS(99) As DataSet
        Dim sqldaFERIADOS(99) As SqlDataAdapter
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim intDIASUTEIS As Integer = 0
        Dim sqldaPERIODO(99) As SqlDataAdapter
        Dim dtsPERIODO(99) As DataSet
        Dim strPERIODOTINI As String = Nothing
        Dim strPERIODOTFIM As String = Nothing
        Dim dtimePERIODOTINI As DateTime = Nothing
        Dim dtimePERIODOTFIM As DateTime = Nothing
        Dim bolFOUNDTINI As Boolean = False
        Dim bolFOUNDTFIM As Boolean = False
        Dim decTOTALHORASMES As Decimal = 0D
        Dim strTOTALHORASMES As String = Nothing
        Dim decHORASUTILIZACAO As Decimal = 0D
        Dim decSETUPHORAS As Decimal = 0D
        Dim bolINDETERMINADO As Boolean = False
        Dim intINDETERMINADO As Integer = 0
        Dim dtimeINICIOANOFISCAL As DateTime
        Dim dtimeFIMANOFISCAL As DateTime

        Dim sqldaPPROG(99) As SqlDataAdapter
        Dim dtsPPROG(99) As DataSet
        Dim decPPROG As Decimal = 0D
        Dim dtimePPROGINI As DateTime = Nothing
        Dim dtimePPROGFIM As DateTime = Nothing

        Dim sqldaTURNOS(99) As SqlDataAdapter
        Dim dtsTURNOS(99) As DataSet
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim dtimeDATAINICIAL As DateTime
        Dim dtimeDATAFINAL As DateTime

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Dim dtimeESCALAINICIAL As DateTime = Nothing
        Dim dtimeESCALAFIM As DateTime = Nothing
        Dim dtimePARADAINICIAL As DateTime = Nothing
        Dim dtimePARADAFINAL As DateTime = Nothing
        Dim dtimeNOVAPARADAINICIAL As DateTime = Nothing
        Dim strDATA As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            strQUERY = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, exe_MCONTROL_OEE_maquinas_grupos.maquinaid " &
                       "as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = " &
                       "exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_Maquinas ON " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                       "AND (exe_MCONTROL_OEE_gruposdemaquinas.id = 1 OR exe_MCONTROL_OEE_gruposdemaquinas.id = 2) ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")

            'Motivos Testes
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [testes] = 1"
            sqldaTESTES = New SqlDataAdapter(strQUERY, conSQL)
            dtsTESTES = New DataSet
            sqldaTESTES.Fill(dtsTESTES, "Testes")

            'Horas/Motivos
            '/////////////
            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")

                strDATAINICIAL = "01/04/" & intANOFISCAL - 1 & " 00:00:00"
                dtimeINICIOANOFISCAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeFIMANOFISCAL = DateAdd(DateInterval.Year, 1, dtimeINICIOANOFISCAL)
                dtimeFIMANOFISCAL = DateAdd(DateInterval.Day, -1, dtimeFIMANOFISCAL)
                dtimeFIMANOFISCAL = DateAdd(DateInterval.Second, 86399, dtimeFIMANOFISCAL)
                If DateDiff(DateInterval.Day, Now(), dtimeFIMANOFISCAL) > 0 Then
                    intMES = Now().Month - 1
                    intANO = Now().Year
                    If intMES = 0 Then
                        intMES = 12
                        intANO = intANO - 1
                    End If
                    dtimeDATA = Convert.ToDateTime("01/" & intMES & "/" & intANO)
                    dtimeDATAFIM = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATA))
                    strDATAFINAL = Convert.ToDateTime(Mid(dtimeDATAFIM.ToString, 1, 10) & " 23:59:59")
                    dtimeDATAFIM = Convert.ToDateTime(strDATAFINAL)
                    dtimeFIMANOFISCAL = dtimeDATAFIM
                Else
                    intMES = Val(Mid(dtimeFIMANOFISCAL.ToString, 4, 2))
                    intANO = Val(Mid(dtimeFIMANOFISCAL.ToString, 7, 4))
                    dtimeDATAFIM = dtimeFIMANOFISCAL
                End If
                reportDATAFINAL = Mid(dtimeDATAFIM.ToString, 1, 10)

                dtimeDATA = Convert.ToDateTime("01/" & intMES & "/" & intANO)
                dtimeDATAFIM = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATA))
                strDATAFINAL = Convert.ToDateTime(Mid(dtimeDATAFIM.ToString, 1, 10) & " 23:59:59")
                dtimeDATAFIM = Convert.ToDateTime(strDATAFINAL)

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO(intC) = New DataSet
                sqldaPERIODO(intC).Fill(dtsPERIODO(intC), "Periodo")
                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horarioinicial")
                strDFINAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horariofinal")

                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
                If intDAYS < 0 Then
                    dtimeFIMANOFISCAL = DateAdd(DateInterval.Day, 1, dtimeFIMANOFISCAL)
                End If
                strDATAINICIAL = Mid(dtimeINICIOANOFISCAL.ToString, 1, 10) & " " & Mid(strDINICIAL, 12, 9)
                strDATAFINAL = Mid(dtimeFIMANOFISCAL.ToString, 1, 10) & " " & Mid(strDFINAL, 12, 9)
                dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)

                'Total de Dias Úteis
                '///////////////////
                intDIASUTEIS = 0
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
                sqldaFERIADOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsFERIADOS(intC) = New DataSet
                sqldaFERIADOS(intC).Fill(dtsFERIADOS(intC), "Feriados")
                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
                If intDAYS > 0 Then
                    For intC2 = 0 To intDAYS
                        strDATA = DateAdd(DateInterval.Day, intC2, dtimeDATAINICIAL).ToShortDateString()
                        dtimeDATA = Convert.ToDateTime(strDATA)
                        For intC3 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                            dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC3).Item("data"))
                            If dtimeFERIADO = dtimeDATA Then
                                bolFERIADO = True
                                Exit For
                            End If
                        Next
                        If bolFERIADO = False Then
                            If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                                intDIASUTEIS += 1
                            End If
                        Else
                            bolFERIADO = False
                        End If
                    Next
                End If

                decTOTALHORASMES = intDIASUTEIS * 16.9166666667D * 3600 '(horas de trabalho por dia * 60 para dar em minutos)
                intHORA = Int(decTOTALHORASMES / 3600)
                decFracionario = (decTOTALHORASMES / 3600) - intHORA
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
                strTOTALHORASMES = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                strMACHINEID = intMACHINEID.ToString("D6")

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strGRUPONOME = dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome")
                strMAQUINANOME = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome")
                strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strTABLENAME & " WHERE [date_shift] >= convert(Date, '" &
                           Mid(dtimeDATAINICIAL.ToString, 1, 10) & "' ,103) And [date_shift] <= convert(Date, '" &
                           Mid(dtimeDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAS(intC) = New DataSet
                sqldaESCALAS(intC).Fill(dtsESCALAS(intC), "Escalas")

                'Zeramentos
                '////////////
                decHORASDISPONIVEL = 0D
                decHORASETUP = 0D
                decHORASTESTE = 0D
                decHORASPARADAS = 0D
                intCONTPARADAS = 0
                bolINDETERMINADO = False
                intINDETERMINADO = 0
                Array.Clear(strMOTIVOPARADA, 0, strMOTIVOPARADA.Length)

                'Cálculo de Disponibilidade
                '//////////////////////////
                If dtsESCALAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1
                        strDATADAYSINI = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_begin")
                        strDATADAYSFIM = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_end")
                        dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                        dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                        If dtimeDATADAYSINI >= dtimeDATAINICIAL And dtimeDATADAYSFIM <= dtimeDATAFINAL Then
                            decHORASDISPONIVEL += DateDiff(DateInterval.Second, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                        End If
                    Next
                End If

                'Verifica Paradas Programadas
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 1"
                sqldaPPROG(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPPROG(intC) = New DataSet
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPPROG(intC).Fill(dtsPPROG(intC), "ParadasProgramadas")
                decPPROG = 0D
                If dtsPPROG(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPPROG(intC).Tables(0).Rows.Count - 1
                        dtimePPROGINI = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOn"))
                        dtimePPROGFIM = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                        decPPROG += DateDiff(DateInterval.Second, dtimePPROGINI, dtimePPROGFIM)
                    Next
                End If
                decHORASDISPONIVEL -= decPPROG
                If decHORASDISPONIVEL < 0 Then
                    decHORASDISPONIVEL = 0
                End If
                intHORA = Int(decHORASDISPONIVEL / 3600)
                decFracionario = (decHORASDISPONIVEL / 3600) - intHORA
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
                strHORASDISPONIVEL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] INNER JOIN exe_MCONTROL_OEE_motivosnivel1 ON " &
                           "exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI " &
                           "AND [DateTimeOff] <= @DF AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 0"
                sqldaPARADAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPARADAS(intC) = New DataSet
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPARADAS(intC).Fill(dtsPARADAS(intC), "Paradas")

                If dtsPARADAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPARADAS(intC).Tables(0).Rows.Count - 1

                        dtimePARADAINICIAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn")
                        dtimePARADAFINAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff")

                        For intC3 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1

                            dtimeESCALAINICIAL = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeESCALAFIM = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_end"))
                            If dtimePARADAINICIAL >= dtimeESCALAINICIAL And dtimePARADAINICIAL <= dtimeESCALAFIM Then
                                bolFOUND = True
                                Exit For
                            End If

                        Next

                        If bolFOUND = True Then

                            bolFOUND = False
                            If intCONTPARADAS = 0 Then

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    'É relamente uma parada
                                    '///////////////////////
                                    If bolFOUND = False Then
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                       dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If

                            Else

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    If bolFOUND = False Then
                                        For intC3 = 0 To intCONTPARADAS - 1
                                            If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = strMOTIVOPARADA(intC3, 1) Then
                                                bolFOUND = True
                                                strMOTIVOPARADA(intC3, 2) = Val(strMOTIVOPARADA(intC3, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                 dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                Exit For
                                            End If
                                        Next
                                        If bolFOUND = True Then
                                            bolFOUND = False
                                        Else
                                            strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                            strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                            strMOTIVOPARADA(intCONTPARADAS, 2) = strMOTIVOPARADA(intCONTPARADAS, 2) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            intCONTPARADAS += 1
                                        End If
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    'Parada sem motivo registrado
                                    '/////////////////////////////

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If
                            End If
                        End If
                    Next
                End If

                bolFOUND = False
                If bolINDETERMINADO = True Then
                    For intC2 = 0 To intCONTPARADAS - 1
                        If strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                            bolFOUND = True
                            strMOTIVOPARADA(intC2, 2) = Val(strMOTIVOPARADA(intC2, 2)) + intINDETERMINADO
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        strMOTIVOPARADA(intCONTPARADAS, 0) = "OUTROS"
                        strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                        strMOTIVOPARADA(intCONTPARADAS, 2) = intINDETERMINADO
                        decHORASPARADAS += intINDETERMINADO
                        intCONTPARADAS += 1
                    End If
                End If

                If decHORASETUP > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "SETUP"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASETUP
                    intCONTPARADAS += 1
                End If

                If decHORASTESTE > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASTESTE
                    intCONTPARADAS += 1
                End If

                'Coloca em Ordem Crescente de tempo as paradas
                '/////////////////////////////////////////////
                If intCONTPARADAS > 1 Then
                    intCONTROLE = 1
                    For intC2 = 0 To intCONTPARADAS - 2
                        strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                        strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                        strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                        strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                        strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                        strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                        For intC3 = intCONTROLE To intCONTPARADAS - 1
                            If Convert.ToInt32(strMOTIVOPARADATEMP(2)) < Convert.ToInt32(strMOTIVOPARADA(intC3, 2)) Then
                                strMOTIVOPARADA(intC2, 0) = strMOTIVOPARADA(intC3, 0)
                                strMOTIVOPARADA(intC2, 1) = strMOTIVOPARADA(intC3, 1)
                                strMOTIVOPARADA(intC2, 2) = strMOTIVOPARADA(intC3, 2)
                                strMOTIVOPARADA(intC2, 3) = strMOTIVOPARADA(intC3, 3)
                                strMOTIVOPARADA(intC2, 4) = strMOTIVOPARADA(intC3, 4)
                                strMOTIVOPARADA(intC2, 5) = strMOTIVOPARADA(intC3, 5)
                                strMOTIVOPARADA(intC3, 0) = strMOTIVOPARADATEMP(0)
                                strMOTIVOPARADA(intC3, 1) = strMOTIVOPARADATEMP(1)
                                strMOTIVOPARADA(intC3, 2) = strMOTIVOPARADATEMP(2)
                                strMOTIVOPARADA(intC3, 3) = strMOTIVOPARADATEMP(3)
                                strMOTIVOPARADA(intC3, 4) = strMOTIVOPARADATEMP(4)
                                strMOTIVOPARADA(intC3, 5) = strMOTIVOPARADATEMP(5)
                                strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                                strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                                strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                                strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                                strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                                strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                            End If
                        Next
                        intCONTROLE += 1
                    Next
                End If

                'Horas Paradas
                '/////////////
                intHORA = Int(decHORASPARADAS / 3600)
                decFracionario = (decHORASPARADAS / 3600) - intHORA
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
                strHORASPARADAS = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Setup
                '/////
                intHORA = Int(decHORASETUP / 3600)
                decFracionario = (decHORASETUP / 3600) - intHORA
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
                strHORASETUP = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Testes
                '//////
                intHORA = Int(decHORASTESTE / 3600)
                decFracionario = (decHORASTESTE / 3600) - intHORA
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
                strHORASTESTE = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Disponibilidade
                '///////////////
                If decHORASDISPONIVEL > 0 Then
                    decDISPONIBILIDADE = (decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)) / decHORASDISPONIVEL
                Else
                    decDISPONIBILIDADE = 0
                End If

                '%Utilização
                '///////////
                If decTOTALHORASMES > 0 Then
                    decHORASUTILIZACAO = decHORASDISPONIVEL / decTOTALHORASMES
                Else
                    decHORASUTILIZACAO = 0D
                End If

                'Tempo Útil
                '///////////
                decHORASTEMPOUTIL = decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)
                If decHORASTEMPOUTIL < 0 Then
                    decHORASTEMPOUTIL = 0
                End If
                intHORA = Int(decHORASTEMPOUTIL / 3600)
                decFracionario = (decHORASTEMPOUTIL / 3600) - intHORA
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
                strHORASTEMPOUTIL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                If decHORASDISPONIVEL > 0 Then
                    decHORASTEMPOUTILPERCENTUAL = decHORASTEMPOUTIL / decHORASDISPONIVEL
                    decHORASPARADAPERCENTUAL = decHORASPARADAS / decHORASDISPONIVEL
                    decHORASSETUPPERCENTUAL = decHORASETUP / decHORASDISPONIVEL
                    decHORASTESTEPERCENTUAL = decHORASTESTE / decHORASDISPONIVEL
                Else
                    decHORASTEMPOUTILPERCENTUAL = 0
                    decHORASPARADAPERCENTUAL = 0
                    decHORASSETUPPERCENTUAL = 0
                    decHORASTESTEPERCENTUAL = 0
                End If

                'Produção
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                          "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                          "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                          "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                          "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
                sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL = New DataSet
                sqldaBABEL.Fill(dtsBABEL, "BABEL")
                intBABELID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT SUM([exe_MCONTROL_BABELFISH_amarrado].[peso]) AS pesototal, SUM(CAST([exe_MCONTROL_BABELFISH_amarrado].[qtd] AS INT)) " &
                          "as metrostotal FROM exe_MCONTROL_BABELFISH_amarrado WHERE [id_maquinario] = '" & intBABELID &
                          "' And [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] >= @DI AND " &
                          "[exe_MCONTROL_BABELFISH_amarrado].[data_recebido] <= @DF AND [unidade] = 'M' AND [exe_MCONTROL_BABELFISH_amarrado].[deleted] = 0"
                sqldaPRODUCAO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPRODUCAO(intC) = New DataSet
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPRODUCAO(intC).Fill(dtsPRODUCAO(intC), "Producao")
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) = False Then
                    decTONELADAS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) / 1000
                Else
                    decTONELADAS = 0D
                End If
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal")) = False Then
                    decMETROS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal"))
                Else
                    decMETROS = 0D
                End If

                'Registro na Base de Dados
                '/////////////////////////
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] ([userid]," &
                                          "[grupomaquina],[maquina],[toneladas],[metros],[tempoutil],[tempoutilpercentual]," &
                                          "[setup],[setuppercentual],[testes],[testespercentual],[paradas],[paradaspercentual]," &
                                          "[tempodisponivel]) VALUES (" & intUSERID & ", '" & strGRUPONOME & "', '" & strMAQUINANOME & "', " &
                                           decTONELADAS.ToString.Replace(",", ".") & ", " & decMETROS.ToString.Replace(",", ".") & ", '" &
                                           strHORASTEMPOUTIL & "', " & decHORASTEMPOUTILPERCENTUAL.ToString.Replace(",", ".") & ", '" &
                                           strHORASETUP & "', " & decHORASSETUPPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASTESTE & "', " &
                                           decHORASTESTEPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASPARADAS & "', " &
                                           decHORASPARADAPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASDISPONIVEL & "')"
                sqlcmdREPORT.ExecuteNonQuery()

                'Valores
                '///////
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [tempoutilvalor] = " & decHORASTEMPOUTIL.ToString.Replace(",", ".") & ", " &
                                           "[setupvalor] = " & decHORASETUP & ", [testesvalor] = " & decHORASTESTE & ", " &
                                           "[paradasvalor] = " & decHORASPARADAS & ", [tempodisponivelvalor] = " & decHORASDISPONIVEL & " WHERE [userid] = " & intUSERID & " And [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()


                decTONELADAS = 0D
                decMETROS = 0D

                'Demais Motivos
                '//////////////
                Array.Clear(strPARADAS, 0, 99)
                For intC2 = 0 To 20
                    strPARADASTEMPOTOTAL(intC2) = 0
                Next

                For intC2 = 0 To intCONTPARADAS - 1
                    intHORA = Int(Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600)
                    decFracionario = (Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600) - intHORA
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
                    strMOTIVOPARADA(intC2, 5) = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    If strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO ELÉTRICA" Then
                        strPARADAS(0) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(0) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO MECÂNICA" Then
                        strPARADAS(1) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(1) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AJUSTES NA PRODUÇÃO" Then
                        strPARADAS(2) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(2) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FERRAMENTAL" Then
                        strPARADAS(3) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(3) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "SETUP" Then
                        strPARADAS(4) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(4) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS - PROBLEMAS NA PRODUÇÃO" Then
                        strPARADAS(5) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(5) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "TROCA DE MATERIAL AUXILIAR" Then
                        strPARADAS(6) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(6) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "BALANÇA" Then
                        strPARADAS(7) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(7) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "DESARME DA MÁQUINA" Then
                        strPARADAS(8) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(8) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "REUNIÃO/TREINAMENTO/CIP/MODELLINE" Then
                        strPARADAS(9) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(9) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AGUARDANDO MANUTENÇÃO" Then
                        strPARADAS(10) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(10) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "ESPERA DE PONTE ROLANTE" Then
                        strPARADAS(11) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(11) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MÃO DE OBRA" Then
                        strPARADAS(12) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(12) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MATÉRIA-PRIMA" Then
                        strPARADAS(13) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(13) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE ORDEM " Then
                        strPARADAS(14) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(14) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FAZER EMENDA" Then
                        strPARADAS(15) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(15) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LIMPEZA" Then
                        strPARADAS(16) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(16) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS" Then
                        strPARADAS(17) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(17) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PARADA INEXISTENTE" Then
                        strPARADAS(18) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(18) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PROBLEMAS SAP/MES" Then
                        strPARADAS(19) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(19) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                        strPARADAS(20) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(20) = strMOTIVOPARADA(intC2, 2)
                    End If
                Next

                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [parada_1] = '" & strPARADAS(0) & "', " &
                                           "[parada_2] = '" & strPARADAS(1) & "', " &
                                           "[parada_3] = '" & strPARADAS(2) & "', " &
                                           "[parada_4] = '" & strPARADAS(3) & "', " &
                                           "[parada_5] = '" & strPARADAS(4) & "', " &
                                           "[parada_6] = '" & strPARADAS(5) & "', " &
                                           "[parada_7] = '" & strPARADAS(6) & "', " &
                                           "[parada_8] = '" & strPARADAS(7) & "', " &
                                           "[parada_9] = '" & strPARADAS(8) & "', " &
                                           "[parada_10] = '" & strPARADAS(9) & "', " &
                                           "[parada_11] = '" & strPARADAS(10) & "', " &
                                           "[parada_12] = '" & strPARADAS(11) & "', " &
                                           "[parada_13] = '" & strPARADAS(12) & "', " &
                                           "[parada_14] = '" & strPARADAS(13) & "', " &
                                           "[parada_15] = '" & strPARADAS(14) & "', " &
                                           "[parada_16] = '" & strPARADAS(15) & "', " &
                                           "[parada_17] = '" & strPARADAS(16) & "', " &
                                           "[parada_18] = '" & strPARADAS(17) & "', " &
                                           "[parada_19] = '" & strPARADAS(18) & "', " &
                                           "[parada_20] = '" & strPARADAS(19) & "', " &
                                           "[parada_21] = '" & strPARADAS(20) & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [paradavalor_1] = " & strPARADASTEMPOTOTAL(0) & ", " &
                                           "[paradavalor_2] = " & strPARADASTEMPOTOTAL(1) & ", " &
                                           "[paradavalor_3] = " & strPARADASTEMPOTOTAL(2) & ", " &
                                           "[paradavalor_4] = " & strPARADASTEMPOTOTAL(3) & ", " &
                                           "[paradavalor_5] = " & strPARADASTEMPOTOTAL(4) & ", " &
                                           "[paradavalor_6] = " & strPARADASTEMPOTOTAL(5) & ", " &
                                           "[paradavalor_7] = " & strPARADASTEMPOTOTAL(6) & ", " &
                                           "[paradavalor_8] = " & strPARADASTEMPOTOTAL(7) & ", " &
                                           "[paradavalor_9] = " & strPARADASTEMPOTOTAL(8) & ", " &
                                           "[paradavalor_10] =" & strPARADASTEMPOTOTAL(9) & ", " &
                                           "[paradavalor_11] =" & strPARADASTEMPOTOTAL(10) & ", " &
                                           "[paradavalor_12] =" & strPARADASTEMPOTOTAL(11) & ", " &
                                           "[paradavalor_13] =" & strPARADASTEMPOTOTAL(12) & ", " &
                                           "[paradavalor_14] =" & strPARADASTEMPOTOTAL(13) & ", " &
                                           "[paradavalor_15] =" & strPARADASTEMPOTOTAL(14) & ", " &
                                           "[paradavalor_16] =" & strPARADASTEMPOTOTAL(15) & ", " &
                                           "[paradavalor_17] =" & strPARADASTEMPOTOTAL(16) & ", " &
                                           "[paradavalor_18] =" & strPARADASTEMPOTOTAL(17) & ", " &
                                           "[paradavalor_19] =" & strPARADASTEMPOTOTAL(18) & ", " &
                                           "[paradavalor_20] =" & strPARADASTEMPOTOTAL(19) & ", " &
                                           "[paradavalor_21] =" & strPARADASTEMPOTOTAL(20) & " WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [utilizacao] = " & decHORASUTILIZACAO.ToString.Replace(",", ".") & ", " &
                                           "[diasuteis] = " & intDIASUTEIS & ", [horasmes] = '" & strTOTALHORASMES & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [grupomaquina] = '1.3 ESPECIAL' WHERE [maquina] = 'F07 MEINCOL 2'"
            sqlcmdREPORT.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTPRODUTIVIDADE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTPRODUTIVIDADE_GRUPO_MENSAL(ByVal intMES As String,
                                                            ByVal intANO As Integer,
                                                            ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim bolNEWDAY As Boolean = False
        Dim strTURNOHORAINICIAL As String = Nothing
        Dim strTURNOHORAFINAL As String = Nothing
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing

        Dim sqldaTESTES As SqlDataAdapter
        Dim dtsTESTES As DataSet

        Dim strMOTIVOPARADA(999, 5) As String
        Dim bolFOUND As Boolean = False
        Dim intCONTPARADAS As Integer = 0
        Dim intPARADAS As Decimal = 0D
        Dim intCONTROLE As Integer = 0
        Dim strMOTIVOPARADATEMP(5) As String
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim intBABELID As Integer = 0

        Dim decPESOTOTAL As Decimal = 0D
        Dim decCOMPRIMENTOTAL As Decimal = 0D

        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim dtimeDATA As DateTime = Nothing
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim sqldaESCALAS(99) As SqlDataAdapter
        Dim dtsESCALAS(99) As DataSet
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim sqldaPARADAS(99) As SqlDataAdapter
        Dim dtsPARADAS(99) As DataSet
        Dim sqldaPRODUCAO(99) As SqlDataAdapter
        Dim dtsPRODUCAO(99) As DataSet
        Dim strGRUPONOME As String = Nothing
        Dim strMAQUINANOME As String = Nothing
        Dim decTONELADAS As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strHORASTESTE As String = Nothing
        Dim strHORASETUP As String = Nothing
        Dim strHORASPARADAS As String = Nothing
        Dim strHORASDISPONIVEL As String = Nothing
        Dim decHORASPARADAS As Decimal = 0D
        Dim decHORASETUP As Decimal = 0D
        Dim decHORASTESTE As Decimal = 0D
        Dim decHORASDISPONIVEL As Decimal = 0D
        Dim decDISPONIBILIDADE As Decimal = 0D
        Dim decHORASTEMPOUTIL As Decimal = 0D
        Dim strHORASTEMPOUTIL As String = Nothing
        Dim decHORASTEMPOUTILPERCENTUAL As Decimal = 0D
        Dim decHORASPARADAPERCENTUAL As Decimal = 0D
        Dim decHORASSETUPPERCENTUAL As Decimal = 0D
        Dim decHORASTESTEPERCENTUAL As Decimal = 0D
        Dim strPARADAS(99) As String
        Dim strPARADASTEMPOTOTAL(99) As String
        Dim intDAYS As Integer = 0
        Dim dtsFERIADOS(99) As DataSet
        Dim sqldaFERIADOS(99) As SqlDataAdapter
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim intDIASUTEIS As Integer = 0
        Dim sqldaPERIODO(99) As SqlDataAdapter
        Dim dtsPERIODO(99) As DataSet
        Dim strPERIODOTINI As String = Nothing
        Dim strPERIODOTFIM As String = Nothing
        Dim dtimePERIODOTINI As DateTime = Nothing
        Dim dtimePERIODOTFIM As DateTime = Nothing
        Dim bolFOUNDTINI As Boolean = False
        Dim bolFOUNDTFIM As Boolean = False
        Dim decTOTALHORASMES As Decimal = 0D
        Dim strTOTALHORASMES As String = Nothing
        Dim decHORASUTILIZACAO As Decimal = 0D
        Dim decSETUPHORAS As Decimal = 0D
        Dim bolINDETERMINADO As Boolean = False
        Dim intINDETERMINADO As Integer = 0
        Dim bolMESINCOMPLETO As Boolean = False
        Dim dtimeDATAFINALINICIAL As String = Nothing
        Dim strGRUPOMASTER As String = Nothing

        Dim sqldaPPROG(99) As SqlDataAdapter
        Dim dtsPPROG(99) As DataSet
        Dim decPPROG As Decimal = 0D
        Dim dtimePPROGINI As DateTime = Nothing
        Dim dtimePPROGFIM As DateTime = Nothing

        Dim sqldaTURNOS(99) As SqlDataAdapter
        Dim dtsTURNOS(99) As DataSet
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim dtimeDATAINICIAL As DateTime
        Dim dtimeDATAFINAL As DateTime

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Dim dtimeESCALAINICIAL As DateTime = Nothing
        Dim dtimeESCALAFIM As DateTime = Nothing
        Dim dtimePARADAINICIAL As DateTime = Nothing
        Dim dtimePARADAFINAL As DateTime = Nothing
        Dim dtimeNOVAPARADAINICIAL As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            strQUERY = "SELECT exe_MCONTROL_OEE_gruposmaster.gruponome AS grupomaster, exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_maquinas_grupos.grupoid " &
                       "INNER JOIN exe_MCONTROL_OEE_Maquinas ON exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id " &
                       "INNER JOIN exe_MCONTROL_OEE_master_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_master_grupos.grupoid " &
                       "INNER JOIN exe_MCONTROL_OEE_gruposmaster ON exe_MCONTROL_OEE_gruposmaster.id = exe_MCONTROL_OEE_master_grupos.masterid " &
                       "WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 AND (exe_MCONTROL_OEE_gruposdemaquinas.id = 1 OR exe_MCONTROL_OEE_gruposdemaquinas.id = 2) " &
                       "ORDER BY grupomaster, gruponome, exe_MCONTROL_OEE_Maquinas.Descricao ASC"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")

            'Motivos Testes
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [testes] = 1"
            sqldaTESTES = New SqlDataAdapter(strQUERY, conSQL)
            dtsTESTES = New DataSet
            sqldaTESTES.Fill(dtsTESTES, "Testes")

            'Horas/Motivos
            '/////////////
            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")

                strDATAINICIAL = "01/" & intMES & "/" & intANO & " 00:00:00"
                dtimeDATAINI = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFIM = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATAINI))
                strDATAFINAL = Convert.ToDateTime(Mid(dtimeDATAFIM.ToString, 1, 10) & " 23:59:59")
                dtimeDATAFIM = Convert.ToDateTime(strDATAFINAL)
                dtimeDATAFINALINICIAL = dtimeDATAFIM
                reportDATAFINAL = Mid(strDATAFINAL, 1, 10)

                If DateDiff(DateInterval.Hour, dtimeDATAFIM, Now()) < 0 Then
                    dtimeDATAFIM = Convert.ToDateTime(Mid(DateAdd(DateInterval.Day, -1, Now()).ToString, 1, 10) & " 23:59:59")
                    reportDATAFINAL = Mid(dtimeDATAFIM.ToString, 1, 10)
                    dtimeDATAFINALINICIAL = dtimeDATAFIM
                    bolMESINCOMPLETO = True
                End If

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO(intC) = New DataSet
                sqldaPERIODO(intC).Fill(dtsPERIODO(intC), "Periodo")
                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horarioinicial")
                strDFINAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horariofinal")

                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
                If intDAYS < 0 Then
                    dtimeDATAFIM = DateAdd(DateInterval.Day, 1, dtimeDATAFIM)
                End If
                strDATAINICIAL = Mid(dtimeDATAINI.ToString, 1, 10) & " " & Mid(strDINICIAL, 12, 9)
                strDATAFINAL = Mid(dtimeDATAFIM.ToString, 1, 10) & " " & Mid(strDFINAL, 12, 9)
                dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)

                'Total de Dias Úteis
                '///////////////////
                intDIASUTEIS = 0
                Dim strDATA As String = Nothing

                If bolMESINCOMPLETO = False Then
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
                    sqldaFERIADOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                    dtsFERIADOS(intC) = New DataSet
                    sqldaFERIADOS(intC).Fill(dtsFERIADOS(intC), "Feriados")
                    intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
                    If intDAYS > 0 Then
                        For intC2 = 0 To intDAYS
                            strDATA = DateAdd(DateInterval.Day, intC2, dtimeDATAINICIAL).ToShortDateString()
                            dtimeDATA = Convert.ToDateTime(strDATA)
                            For intC3 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                                dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC3).Item("data"))
                                If dtimeFERIADO = dtimeDATA Then
                                    bolFERIADO = True
                                    Exit For
                                End If
                            Next
                            If bolFERIADO = False Then
                                If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                                    intDIASUTEIS += 1
                                End If
                            Else
                                bolFERIADO = False
                            End If
                        Next
                    End If

                    decTOTALHORASMES = intDIASUTEIS * 16.9166666667D * 3600
                    intHORA = Int(decTOTALHORASMES / 3600)
                    decFracionario = (decTOTALHORASMES / 3600) - intHORA
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
                    strTOTALHORASMES = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                Else
                    strTOTALHORASMES = "00:00:00"
                End If

                strMACHINEID = intMACHINEID.ToString("D6")

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strGRUPOMASTER = dtsGRUPOS.Tables(0).Rows(intC).Item("grupomaster")
                strGRUPONOME = dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome")
                strMAQUINANOME = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome")
                strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strTABLENAME & " WHERE [date_shift] >= convert(Date, '" &
                           Mid(dtimeDATAINICIAL.ToString, 1, 10) & "' ,103) And [date_shift] <= convert(Date, '" &
                           Mid(dtimeDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAS(intC) = New DataSet
                sqldaESCALAS(intC).Fill(dtsESCALAS(intC), "Escalas")

                'Zeramentos
                '////////////
                decHORASDISPONIVEL = 0D
                decHORASETUP = 0D
                decHORASTESTE = 0D
                decHORASPARADAS = 0D
                intCONTPARADAS = 0
                intINDETERMINADO = 0
                bolINDETERMINADO = False
                Array.Clear(strMOTIVOPARADA, 0, strMOTIVOPARADA.Length)

                'Cálculo de Disponibilidade
                '//////////////////////////
                If dtsESCALAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1
                        strDATADAYSINI = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_begin")
                        strDATADAYSFIM = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_end")
                        dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                        dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                        If dtimeDATADAYSINI >= dtimeDATAINICIAL And dtimeDATADAYSFIM <= dtimeDATAFINAL Then
                            decHORASDISPONIVEL += DateDiff(DateInterval.Second, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                        End If
                    Next
                End If

                'Verifica Paradas Programadas
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 1"
                sqldaPPROG(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPPROG(intC) = New DataSet
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPPROG(intC).Fill(dtsPPROG(intC), "ParadasProgramadas")
                decPPROG = 0D
                If dtsPPROG(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPPROG(intC).Tables(0).Rows.Count - 1
                        dtimePPROGINI = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOn"))
                        dtimePPROGFIM = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                        decPPROG += DateDiff(DateInterval.Second, dtimePPROGINI, dtimePPROGFIM)
                    Next
                End If
                decHORASDISPONIVEL -= decPPROG
                If decHORASDISPONIVEL < 0 Then
                    decHORASDISPONIVEL = 0
                End If
                intHORA = Int(decHORASDISPONIVEL / 3600)
                decFracionario = (decHORASDISPONIVEL / 3600) - intHORA
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
                strHORASDISPONIVEL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Paradas registradas no período
                '///////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF" &
                           " AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 0"
                sqldaPARADAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPARADAS(intC) = New DataSet
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPARADAS(intC).Fill(dtsPARADAS(intC), "Paradas")

                If dtsPARADAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPARADAS(intC).Tables(0).Rows.Count - 1

                        dtimePARADAINICIAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn")
                        dtimePARADAFINAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff")

                        For intC3 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1

                            dtimeESCALAINICIAL = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeESCALAFIM = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_end"))
                            If dtimePARADAINICIAL >= dtimeESCALAINICIAL And dtimePARADAINICIAL <= dtimeESCALAFIM Then
                                bolFOUND = True
                                Exit For
                            End If

                        Next

                        If bolFOUND = True Then

                            bolFOUND = False
                            If intCONTPARADAS = 0 Then

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    'É relamente uma parada
                                    '///////////////////////
                                    If bolFOUND = False Then
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                       dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If

                            Else

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    If bolFOUND = False Then
                                        For intC3 = 0 To intCONTPARADAS - 1
                                            If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = strMOTIVOPARADA(intC3, 1) Then
                                                bolFOUND = True
                                                strMOTIVOPARADA(intC3, 2) = Val(strMOTIVOPARADA(intC3, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                                           dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                 dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                Exit For
                                            End If
                                        Next
                                        If bolFOUND = True Then
                                            bolFOUND = False
                                        Else
                                            strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                            strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                            strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                           dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            intCONTPARADAS += 1
                                        End If
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    'Parada sem motivo registrado
                                    '////////////////////////////

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If
                            End If
                        End If
                    Next
                End If

                bolFOUND = False
                If bolINDETERMINADO = True Then
                    For intC2 = 0 To intCONTPARADAS - 1
                        If strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                            bolFOUND = True
                            strMOTIVOPARADA(intC2, 2) = Val(strMOTIVOPARADA(intC2, 2)) + intINDETERMINADO
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        strMOTIVOPARADA(intCONTPARADAS, 0) = "OUTROS"
                        strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                        strMOTIVOPARADA(intCONTPARADAS, 2) = intINDETERMINADO
                        intCONTPARADAS += 1
                    End If
                End If

                If decHORASETUP > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "SETUP"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASETUP
                    intCONTPARADAS += 1
                End If

                If decHORASTESTE > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASTESTE
                    intCONTPARADAS += 1
                End If

                'Coloca em Ordem Crescente de tempo as paradas
                '/////////////////////////////////////////////
                If intCONTPARADAS > 1 Then
                    intCONTROLE = 1
                    For intC2 = 0 To intCONTPARADAS - 2
                        strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                        strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                        strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                        strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                        strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                        strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                        For intC3 = intCONTROLE To intCONTPARADAS - 1
                            If Convert.ToInt32(strMOTIVOPARADATEMP(2)) < Convert.ToInt32(strMOTIVOPARADA(intC3, 2)) Then
                                strMOTIVOPARADA(intC2, 0) = strMOTIVOPARADA(intC3, 0)
                                strMOTIVOPARADA(intC2, 1) = strMOTIVOPARADA(intC3, 1)
                                strMOTIVOPARADA(intC2, 2) = strMOTIVOPARADA(intC3, 2)
                                strMOTIVOPARADA(intC2, 3) = strMOTIVOPARADA(intC3, 3)
                                strMOTIVOPARADA(intC2, 4) = strMOTIVOPARADA(intC3, 4)
                                strMOTIVOPARADA(intC2, 5) = strMOTIVOPARADA(intC3, 5)
                                strMOTIVOPARADA(intC3, 0) = strMOTIVOPARADATEMP(0)
                                strMOTIVOPARADA(intC3, 1) = strMOTIVOPARADATEMP(1)
                                strMOTIVOPARADA(intC3, 2) = strMOTIVOPARADATEMP(2)
                                strMOTIVOPARADA(intC3, 3) = strMOTIVOPARADATEMP(3)
                                strMOTIVOPARADA(intC3, 4) = strMOTIVOPARADATEMP(4)
                                strMOTIVOPARADA(intC3, 5) = strMOTIVOPARADATEMP(5)
                                strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                                strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                                strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                                strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                                strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                                strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                            End If
                        Next
                        intCONTROLE += 1
                    Next
                End If

                'Horas Paradas
                '/////////////
                intHORA = Int(decHORASPARADAS / 3600)
                decFracionario = (decHORASPARADAS / 3600) - intHORA
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
                strHORASPARADAS = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Setup
                '/////
                intHORA = Int(decHORASETUP / 3600)
                decFracionario = (decHORASETUP / 3600) - intHORA
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
                strHORASETUP = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Testes
                '//////
                intHORA = Int(decHORASTESTE / 3600)
                decFracionario = (decHORASTESTE / 3600) - intHORA
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
                strHORASTESTE = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Disponibilidade
                '///////////////
                If decHORASDISPONIVEL > 0 Then
                    decDISPONIBILIDADE = (decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)) / decHORASDISPONIVEL
                Else
                    decDISPONIBILIDADE = 0
                End If

                '%Utilização
                '///////////
                If decTOTALHORASMES > 0 Then
                    decHORASUTILIZACAO = decHORASDISPONIVEL / decTOTALHORASMES
                Else
                    decHORASUTILIZACAO = 0D
                End If
                If bolMESINCOMPLETO = True Then
                    decHORASUTILIZACAO = 0D
                End If

                'Tempo Útil
                '///////////
                decHORASTEMPOUTIL = decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)
                If decHORASTEMPOUTIL < 0 Then
                    decHORASTEMPOUTIL = 0
                End If
                intHORA = Int(decHORASTEMPOUTIL / 3600)
                decFracionario = (decHORASTEMPOUTIL / 3600) - intHORA
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
                strHORASTEMPOUTIL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                If decHORASDISPONIVEL > 0 Then
                    decHORASTEMPOUTILPERCENTUAL = decHORASTEMPOUTIL / decHORASDISPONIVEL
                    decHORASPARADAPERCENTUAL = decHORASPARADAS / decHORASDISPONIVEL
                    decHORASSETUPPERCENTUAL = decHORASETUP / decHORASDISPONIVEL
                    decHORASTESTEPERCENTUAL = decHORASTESTE / decHORASDISPONIVEL
                Else
                    decHORASTEMPOUTILPERCENTUAL = 0
                    decHORASPARADAPERCENTUAL = 0
                    decHORASSETUPPERCENTUAL = 0
                    decHORASTESTEPERCENTUAL = 0
                End If

                'Produção
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                          "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                          "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                          "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                          "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
                sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL = New DataSet
                sqldaBABEL.Fill(dtsBABEL, "BABEL")
                intBABELID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT SUM([exe_MCONTROL_BABELFISH_amarrado].[peso]) AS pesototal, SUM(CAST([exe_MCONTROL_BABELFISH_amarrado].[qtd] AS INT)) " &
                          "as metrostotal FROM exe_MCONTROL_BABELFISH_amarrado WHERE [id_maquinario] = '" & intBABELID &
                          "' And [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] >= @DI AND " &
                          "[exe_MCONTROL_BABELFISH_amarrado].[data_recebido] <= @DF AND [unidade] = 'M' AND [exe_MCONTROL_BABELFISH_amarrado].[deleted] = 0"
                sqldaPRODUCAO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPRODUCAO(intC) = New DataSet
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPRODUCAO(intC).Fill(dtsPRODUCAO(intC), "Producao")
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) = False Then
                    decTONELADAS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) / 1000
                Else
                    decTONELADAS = 0D
                End If
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal")) = False Then
                    decMETROS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal"))
                Else
                    decMETROS = 0D
                End If

                'Registro na Base de Dados
                '/////////////////////////
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] ([userid]," &
                                          "[grupomaster],[grupomaquina],[maquina],[toneladas],[metros],[tempoutil],[tempoutilpercentual]," &
                                          "[setup],[setuppercentual],[testes],[testespercentual],[paradas],[paradaspercentual]," &
                                          "[tempodisponivel]) VALUES (" & intUSERID & ", '" & strGRUPOMASTER & "', '" & strGRUPONOME & "', '" & strMAQUINANOME & "', " &
                                           decTONELADAS.ToString.Replace(",", ".") & ", " & decMETROS.ToString.Replace(",", ".") & ", '" &
                                           strHORASTEMPOUTIL & "', " & decHORASTEMPOUTILPERCENTUAL.ToString.Replace(",", ".") & ", '" &
                                           strHORASETUP & "', " & decHORASSETUPPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASTESTE & "', " &
                                           decHORASTESTEPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASPARADAS & "', " &
                                           decHORASPARADAPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASDISPONIVEL & "')"
                sqlcmdREPORT.ExecuteNonQuery()

                'Valores
                '///////
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [tempoutilvalor] = " & decHORASTEMPOUTIL.ToString.Replace(",", ".") & ", " &
                                           "[setupvalor] = " & decHORASETUP & ", [testesvalor] = " & decHORASTESTE & ", " &
                                           "[paradasvalor] = " & decHORASPARADAS & ", [tempodisponivelvalor] = " & decHORASDISPONIVEL & " WHERE [userid] = " & intUSERID & " And [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()


                decTONELADAS = 0D
                decMETROS = 0D


                'Demais Motivos
                '//////////////
                Array.Clear(strPARADAS, 0, 99)
                For intC2 = 0 To 20
                    strPARADASTEMPOTOTAL(intC2) = 0
                Next

                For intC2 = 0 To intCONTPARADAS - 1
                    intHORA = Int(Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600)
                    decFracionario = (Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600) - intHORA
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
                    strMOTIVOPARADA(intC2, 5) = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    If strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO ELÉTRICA" Then
                        strPARADAS(0) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(0) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO MECÂNICA" Then
                        strPARADAS(1) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(1) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AJUSTES NA PRODUÇÃO" Then
                        strPARADAS(2) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(2) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FERRAMENTAL" Then
                        strPARADAS(3) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(3) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "SETUP" Then
                        strPARADAS(4) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(4) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS - PROBLEMAS NA PRODUÇÃO" Then
                        strPARADAS(5) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(5) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "TROCA DE MATERIAL AUXILIAR" Then
                        strPARADAS(6) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(6) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "BALANÇA" Then
                        strPARADAS(7) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(7) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "DESARME DA MÁQUINA" Then
                        strPARADAS(8) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(8) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "REUNIÃO/TREINAMENTO/CIP/MODELLINE" Then
                        strPARADAS(9) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(9) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AGUARDANDO MANUTENÇÃO" Then
                        strPARADAS(10) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(10) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "ESPERA DE PONTE ROLANTE" Then
                        strPARADAS(11) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(11) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MÃO DE OBRA" Then
                        strPARADAS(12) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(12) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MATÉRIA-PRIMA" Then
                        strPARADAS(13) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(13) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE ORDEM " Then
                        strPARADAS(14) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(14) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FAZER EMENDA" Then
                        strPARADAS(15) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(15) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LIMPEZA" Then
                        strPARADAS(16) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(16) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS" Then
                        strPARADAS(17) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(17) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PARADA INEXISTENTE" Then
                        strPARADAS(18) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(18) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PROBLEMAS SAP/MES" Then
                        strPARADAS(19) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(19) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                        strPARADAS(20) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(20) = strMOTIVOPARADA(intC2, 2)
                    End If
                Next

                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [parada_1] = '" & strPARADAS(0) & "', " &
                                           "[parada_2] = '" & strPARADAS(1) & "', " &
                                           "[parada_3] = '" & strPARADAS(2) & "', " &
                                           "[parada_4] = '" & strPARADAS(3) & "', " &
                                           "[parada_5] = '" & strPARADAS(4) & "', " &
                                           "[parada_6] = '" & strPARADAS(5) & "', " &
                                           "[parada_7] = '" & strPARADAS(6) & "', " &
                                           "[parada_8] = '" & strPARADAS(7) & "', " &
                                           "[parada_9] = '" & strPARADAS(8) & "', " &
                                           "[parada_10] = '" & strPARADAS(9) & "', " &
                                           "[parada_11] = '" & strPARADAS(10) & "', " &
                                           "[parada_12] = '" & strPARADAS(11) & "', " &
                                           "[parada_13] = '" & strPARADAS(12) & "', " &
                                           "[parada_14] = '" & strPARADAS(13) & "', " &
                                           "[parada_15] = '" & strPARADAS(14) & "', " &
                                           "[parada_16] = '" & strPARADAS(15) & "', " &
                                           "[parada_17] = '" & strPARADAS(16) & "', " &
                                           "[parada_18] = '" & strPARADAS(17) & "', " &
                                           "[parada_19] = '" & strPARADAS(18) & "', " &
                                           "[parada_20] = '" & strPARADAS(19) & "', " &
                                           "[parada_21] = '" & strPARADAS(20) & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [paradavalor_1] = " & strPARADASTEMPOTOTAL(0) & ", " &
                                           "[paradavalor_2] = " & strPARADASTEMPOTOTAL(1) & ", " &
                                           "[paradavalor_3] = " & strPARADASTEMPOTOTAL(2) & ", " &
                                           "[paradavalor_4] = " & strPARADASTEMPOTOTAL(3) & ", " &
                                           "[paradavalor_5] = " & strPARADASTEMPOTOTAL(4) & ", " &
                                           "[paradavalor_6] = " & strPARADASTEMPOTOTAL(5) & ", " &
                                           "[paradavalor_7] = " & strPARADASTEMPOTOTAL(6) & ", " &
                                           "[paradavalor_8] = " & strPARADASTEMPOTOTAL(7) & ", " &
                                           "[paradavalor_9] = " & strPARADASTEMPOTOTAL(8) & ", " &
                                           "[paradavalor_10] =" & strPARADASTEMPOTOTAL(9) & ", " &
                                           "[paradavalor_11] =" & strPARADASTEMPOTOTAL(10) & ", " &
                                           "[paradavalor_12] =" & strPARADASTEMPOTOTAL(11) & ", " &
                                           "[paradavalor_13] =" & strPARADASTEMPOTOTAL(12) & ", " &
                                           "[paradavalor_14] =" & strPARADASTEMPOTOTAL(13) & ", " &
                                           "[paradavalor_15] =" & strPARADASTEMPOTOTAL(14) & ", " &
                                           "[paradavalor_16] =" & strPARADASTEMPOTOTAL(15) & ", " &
                                           "[paradavalor_17] =" & strPARADASTEMPOTOTAL(16) & ", " &
                                           "[paradavalor_18] =" & strPARADASTEMPOTOTAL(17) & ", " &
                                           "[paradavalor_19] =" & strPARADASTEMPOTOTAL(18) & ", " &
                                           "[paradavalor_20] =" & strPARADASTEMPOTOTAL(19) & ", " &
                                           "[paradavalor_21] =" & strPARADASTEMPOTOTAL(20) & " WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [utilizacao] = " & decHORASUTILIZACAO.ToString.Replace(",", ".") & ", " &
                                           "[diasuteis] = " & intDIASUTEIS & ", [horasmes] = '" & strTOTALHORASMES & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [grupomaquina] = '1.3 ESPECIAL' WHERE [maquina] = 'F07 MEINCOL 2'"
            sqlcmdREPORT.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTPRODUTIVIDADE_GRUPO_MENSAL"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTPRODUTIVIDADE_GRUPO_DIARIO(ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim bolNEWDAY As Boolean = False
        Dim strTURNOHORAINICIAL As String = Nothing
        Dim strTURNOHORAFINAL As String = Nothing
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing

        Dim sqldaTESTES As SqlDataAdapter
        Dim dtsTESTES As DataSet

        Dim strMOTIVOPARADA(999, 5) As String
        Dim bolFOUND As Boolean = False
        Dim intCONTPARADAS As Integer = 0
        Dim intPARADAS As Decimal = 0D
        Dim intCONTROLE As Integer = 0
        Dim strMOTIVOPARADATEMP(5) As String
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim intBABELID As Integer = 0

        Dim decPESOTOTAL As Decimal = 0D
        Dim decCOMPRIMENTOTAL As Decimal = 0D

        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim dtimeDATA As DateTime = Nothing
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim sqldaESCALAS(99) As SqlDataAdapter
        Dim dtsESCALAS(99) As DataSet
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim sqldaPARADAS(99) As SqlDataAdapter
        Dim dtsPARADAS(99) As DataSet
        Dim sqldaPRODUCAO(99) As SqlDataAdapter
        Dim dtsPRODUCAO(99) As DataSet
        Dim sqldaPPROG(99) As SqlDataAdapter
        Dim dtsPPROG(99) As DataSet
        Dim strGRUPONOME As String = Nothing
        Dim strMAQUINANOME As String = Nothing
        Dim decTONELADAS As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strHORASTESTE As String = Nothing
        Dim strHORASETUP As String = Nothing
        Dim strHORASPARADAS As String = Nothing
        Dim strHORASDISPONIVEL As String = Nothing
        Dim decHORASPARADAS As Decimal = 0D
        Dim decHORASETUP As Decimal = 0D
        Dim decHORASTESTE As Decimal = 0D
        Dim decHORASDISPONIVEL As Decimal = 0D
        Dim decDISPONIBILIDADE As Decimal = 0D
        Dim decHORASTEMPOUTIL As Decimal = 0D
        Dim strHORASTEMPOUTIL As String = Nothing
        Dim decHORASTEMPOUTILPERCENTUAL As Decimal = 0D
        Dim decHORASPARADAPERCENTUAL As Decimal = 0D
        Dim decHORASSETUPPERCENTUAL As Decimal = 0D
        Dim decHORASTESTEPERCENTUAL As Decimal = 0D
        Dim strPARADAS(99) As String
        Dim strPARADASTEMPOTOTAL(99) As String
        Dim intDAYS As Integer = 0
        Dim dtsFERIADOS(99) As DataSet
        Dim sqldaFERIADOS(99) As SqlDataAdapter
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim intDIASUTEIS As Integer = 0
        Dim sqldaPERIODO(99) As SqlDataAdapter
        Dim dtsPERIODO(99) As DataSet
        Dim strPERIODOTINI As String = Nothing
        Dim strPERIODOTFIM As String = Nothing
        Dim dtimePERIODOTINI As DateTime = Nothing
        Dim dtimePERIODOTFIM As DateTime = Nothing
        Dim bolFOUNDTINI As Boolean = False
        Dim bolFOUNDTFIM As Boolean = False
        Dim decTOTALHORASMES As Decimal = 0D
        Dim strTOTALHORASMES As String = Nothing
        Dim decHORASUTILIZACAO As Decimal = 0D
        Dim decSETUPHORAS As Decimal = 0D
        Dim decPPROG As Decimal = 0D
        Dim dtimePPROGINI As DateTime = Nothing
        Dim dtimePPROGFIM As DateTime = Nothing

        Dim sqldaTURNOS(99) As SqlDataAdapter
        Dim dtsTURNOS(99) As DataSet
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim dtimeDATAINICIAL As DateTime
        Dim dtimeDATAFINAL As DateTime

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Dim dtimeESCALAINICIAL As DateTime = Nothing
        Dim dtimeESCALAFIM As DateTime = Nothing
        Dim dtimePARADAINICIAL As DateTime = Nothing
        Dim dtimePARADAFINAL As DateTime = Nothing
        Dim dtimeNOVAPARADAINICIAL As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            strQUERY = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, exe_MCONTROL_OEE_maquinas_grupos.maquinaid " &
                       "as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = " &
                       "exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_Maquinas ON " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                       "AND (exe_MCONTROL_OEE_gruposdemaquinas.id = 1 OR exe_MCONTROL_OEE_gruposdemaquinas.id = 2) " &
                       "ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")

            'Motivos Testes
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [testes] = 1"
            sqldaTESTES = New SqlDataAdapter(strQUERY, conSQL)
            dtsTESTES = New DataSet
            sqldaTESTES.Fill(dtsTESTES, "Testes")

            'Horas/Motivos
            '/////////////
            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")

                dtimeDATA = DateAdd(DateInterval.Day, -1, Now())
                If dtimeDATA.DayOfWeek.ToString = "Sunday" Then
                    dtimeDATA = DateAdd(DateInterval.Day, -2, dtimeDATA)
                ElseIf dtimeDATA.DayOfWeek.ToString = "Saturday" Then
                    dtimeDATA = DateAdd(DateInterval.Day, -1, dtimeDATA)
                End If

                'Total de Dias Úteis
                '///////////////////
                intDIASUTEIS = 0
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
                sqldaFERIADOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsFERIADOS(intC) = New DataSet
                sqldaFERIADOS(intC).Fill(dtsFERIADOS(intC), "Feriados")

                For intC2 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                    If dtimeDATA = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC2).Item("data")) Then
                        dtimeDATA = DateAdd(DateInterval.Day, -1, dtimeDATA)
                        If dtimeDATA.DayOfWeek.ToString = "Sunday" Then
                            dtimeDATA = DateAdd(DateInterval.Day, -2, dtimeDATA)
                        ElseIf dtimeDATA.DayOfWeek.ToString = "Saturday" Then
                            dtimeDATA = DateAdd(DateInterval.Day, -1, dtimeDATA)
                        End If
                    End If
                Next
                dtimeDATAINI = Convert.ToDateTime(Mid(dtimeDATA.ToString, 1, 10) & " 00:00:00")
                dtimeDATAFIM = Convert.ToDateTime(Mid(dtimeDATA.ToString, 1, 10) & " 23:59:59")
                strDATAINICIAL = Mid(dtimeDATA.ToString, 1, 10)
                strDATAFINAL = Mid(dtimeDATA.ToString, 1, 10)
                reportRELATORIONOME = "ACUMULADO DIÁRIO - " & strDATAINICIAL
                reportDATAINICIAL = Mid(strDATAINICIAL, 1, 10)
                reportDATAFINAL = Mid(strDATAFINAL, 1, 10)

                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINI, dtimeDATAFIM)
                Dim strDATA As String = Nothing
                If intDAYS > 0 Then
                    For intC2 = 0 To intDAYS
                        strDATA = DateAdd(DateInterval.Day, intC2, dtimeDATAINI).ToShortDateString()
                        dtimeDATA = Convert.ToDateTime(strDATA)
                        For intC3 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                            dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC3).Item("data"))
                            If dtimeFERIADO = dtimeDATA Then
                                bolFERIADO = True
                                Exit For
                            End If
                        Next
                        If bolFERIADO = False Then
                            If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                                intDIASUTEIS += 1
                            End If
                        Else
                            bolFERIADO = False
                        End If
                    Next
                End If

                intDIASUTEIS = 1
                decTOTALHORASMES = intDIASUTEIS * 16.9166666667D * 3600
                intHORA = Int(decTOTALHORASMES / 3600)
                decFracionario = (decTOTALHORASMES / 3600) - intHORA
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
                strTOTALHORASMES = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                If intMACHINEID <= 9 Then
                    strMACHINEID = "00000" & intMACHINEID
                ElseIf intMACHINEID >= 10 And intMACHINEID <= 99 Then
                    strMACHINEID = "0000" & intMACHINEID
                ElseIf intMACHINEID >= 100 And intMACHINEID <= 999 Then
                    strMACHINEID = "000" & intMACHINEID
                ElseIf intMACHINEID >= 1000 And intMACHINEID <= 9999 Then
                    strMACHINEID = "00" & intMACHINEID
                ElseIf intMACHINEID >= 10000 And intMACHINEID <= 99999 Then
                    strMACHINEID = "0" & intMACHINEID
                ElseIf intMACHINEID >= 100000 Then
                    strMACHINEID = intMACHINEID
                End If

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & intMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & intMACHINEID
                sqldaPERIODO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO(intC) = New DataSet
                sqldaPERIODO(intC).Fill(dtsPERIODO(intC), "Periodo")
                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horarioinicial")
                strDFINAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horariofinal")

                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
                If intDAYS < 0 Then
                    dtimeDATAFIM = DateAdd(DateInterval.Day, 1, dtimeDATAFIM)
                End If
                strDATAINICIAL = Mid(dtimeDATAINI.ToString, 1, 10) & " " & Mid(strDINICIAL, 12, 9)
                strDATAFINAL = Mid(dtimeDATAFIM.ToString, 1, 10) & " " & Mid(strDFINAL, 12, 9)
                dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)

                strGRUPONOME = dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome")
                strMAQUINANOME = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome")
                strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strTABLENAME & " WHERE [date_shift] >= convert(Date, '" &
                           Mid(strDATAINICIAL.ToString, 1, 10) & "' ,103) And [date_shift] <= convert(Date, '" &
                           Mid(strDATAFINAL.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAS(intC) = New DataSet
                sqldaESCALAS(intC).Fill(dtsESCALAS(intC), "Escalas")

                'Zeramentos
                '////////////
                decHORASDISPONIVEL = 0D
                decHORASETUP = 0D
                decHORASTESTE = 0D
                decHORASPARADAS = 0D
                intCONTPARADAS = 0
                Array.Clear(strMOTIVOPARADA, 0, strMOTIVOPARADA.Length)

                'Cálculo de Disponibilidade
                '//////////////////////////
                If dtsESCALAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1
                        strDATADAYSINI = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_begin")
                        strDATADAYSFIM = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_end")
                        dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                        dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                        If dtimeDATADAYSINI >= dtimeDATAINICIAL And dtimeDATADAYSFIM <= dtimeDATAFINAL Then
                            decHORASDISPONIVEL += DateDiff(DateInterval.Second, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                        End If
                    Next
                End If

                'Verifica Paradas Programadas
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 1"
                sqldaPPROG(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPPROG(intC) = New DataSet
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPPROG(intC).Fill(dtsPPROG(intC), "ParadasProgramadas")
                decPPROG = 0D
                If dtsPPROG(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPPROG(intC).Tables(0).Rows.Count - 1
                        dtimePPROGINI = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOn"))
                        dtimePPROGFIM = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                        decPPROG += DateDiff(DateInterval.Second, dtimePPROGINI, dtimePPROGFIM)
                    Next
                End If
                decHORASDISPONIVEL -= decPPROG
                If decHORASDISPONIVEL < 0 Then
                    decHORASDISPONIVEL = 0
                End If
                intHORA = Int(decHORASDISPONIVEL / 3600)
                decFracionario = (decHORASDISPONIVEL / 3600) - intHORA
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
                strHORASDISPONIVEL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 0"
                sqldaPARADAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPARADAS(intC) = New DataSet
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPARADAS(intC).Fill(dtsPARADAS(intC), "Paradas")

                If dtsPARADAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPARADAS(intC).Tables(0).Rows.Count - 1

                        dtimePARADAINICIAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn")
                        dtimePARADAFINAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff")

                        For intC3 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1

                            dtimeESCALAINICIAL = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeESCALAFIM = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_end"))
                            If dtimePARADAINICIAL >= dtimeESCALAINICIAL And dtimePARADAINICIAL <= dtimeESCALAFIM Then
                                bolFOUND = True
                                Exit For
                            End If

                        Next

                        If bolFOUND = True Then

                            bolFOUND = False
                            If intCONTPARADAS = 0 Then

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    'É relamente uma parada
                                    '///////////////////////
                                    If bolFOUND = False Then
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                       dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    strMOTIVOPARADA(intCONTPARADAS, 0) = "INDETERMINADO"
                                    strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                                    strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                   dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    intCONTPARADAS += 1

                                End If

                            Else

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    If bolFOUND = False Then
                                        For intC3 = 0 To intCONTPARADAS - 1
                                            If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = strMOTIVOPARADA(intC3, 1) Then
                                                bolFOUND = True
                                                strMOTIVOPARADA(intC3, 2) = Val(strMOTIVOPARADA(intC3, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                 dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                Exit For
                                            End If
                                        Next
                                        If bolFOUND = True Then
                                            bolFOUND = False
                                        Else
                                            strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                            strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                            strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                           dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            intCONTPARADAS += 1
                                        End If
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    'Parada sem motivo registrado
                                    '////////////////////////////
                                    For intC3 = 0 To intCONTPARADAS - 1
                                        If strMOTIVOPARADA(intC3, 1) = "9999" Then
                                            bolFOUND = True
                                            strMOTIVOPARADA(intC3, 2) = Val(strMOTIVOPARADA(intC3, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            Exit For
                                        End If
                                    Next
                                    If bolFOUND = True Then
                                        bolFOUND = False
                                    Else
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = "INDETERMINADO"
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                       dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If

                If decHORASETUP > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "SETUP"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASETUP
                    intCONTPARADAS += 1
                End If

                If decHORASTESTE > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASTESTE
                    intCONTPARADAS += 1
                End If

                'Coloca em Ordem Crescente de tempo as paradas
                '/////////////////////////////////////////////
                If intCONTPARADAS > 1 Then
                    intCONTROLE = 1
                    For intC2 = 0 To intCONTPARADAS - 2
                        strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                        strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                        strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                        strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                        strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                        strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                        For intC3 = intCONTROLE To intCONTPARADAS - 1
                            If Convert.ToInt32(strMOTIVOPARADATEMP(2)) < Convert.ToInt32(strMOTIVOPARADA(intC3, 2)) Then
                                strMOTIVOPARADA(intC2, 0) = strMOTIVOPARADA(intC3, 0)
                                strMOTIVOPARADA(intC2, 1) = strMOTIVOPARADA(intC3, 1)
                                strMOTIVOPARADA(intC2, 2) = strMOTIVOPARADA(intC3, 2)
                                strMOTIVOPARADA(intC2, 3) = strMOTIVOPARADA(intC3, 3)
                                strMOTIVOPARADA(intC2, 4) = strMOTIVOPARADA(intC3, 4)
                                strMOTIVOPARADA(intC2, 5) = strMOTIVOPARADA(intC3, 5)
                                strMOTIVOPARADA(intC3, 0) = strMOTIVOPARADATEMP(0)
                                strMOTIVOPARADA(intC3, 1) = strMOTIVOPARADATEMP(1)
                                strMOTIVOPARADA(intC3, 2) = strMOTIVOPARADATEMP(2)
                                strMOTIVOPARADA(intC3, 3) = strMOTIVOPARADATEMP(3)
                                strMOTIVOPARADA(intC3, 4) = strMOTIVOPARADATEMP(4)
                                strMOTIVOPARADA(intC3, 5) = strMOTIVOPARADATEMP(5)
                                strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                                strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                                strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                                strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                                strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                                strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                            End If
                        Next
                        intCONTROLE += 1
                    Next
                End If

                'Horas Paradas
                '/////////////
                intHORA = Int(decHORASPARADAS / 3600)
                decFracionario = (decHORASPARADAS / 3600) - intHORA
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
                strHORASPARADAS = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Setup
                '/////
                intHORA = Int(decHORASETUP / 3600)
                decFracionario = (decHORASETUP / 3600) - intHORA
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
                strHORASETUP = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Testes
                '//////
                intHORA = Int(decHORASTESTE / 3600)
                decFracionario = (decHORASTESTE / 3600) - intHORA
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
                strHORASTESTE = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Disponibilidade
                '///////////////
                If decHORASDISPONIVEL > 0 Then
                    decDISPONIBILIDADE = (decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)) / decHORASDISPONIVEL
                Else
                    decDISPONIBILIDADE = 0
                End If

                '%Utilização
                '///////////
                If decTOTALHORASMES > 0 Then
                    decHORASUTILIZACAO = decHORASDISPONIVEL / decTOTALHORASMES
                Else
                    decHORASUTILIZACAO = 0D
                End If

                'Tempo Útil
                '///////////
                decHORASTEMPOUTIL = decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)
                If decHORASTEMPOUTIL < 0 Then
                    decHORASTEMPOUTIL = 0
                End If
                intHORA = Int(decHORASTEMPOUTIL / 3600)
                decFracionario = (decHORASTEMPOUTIL / 3600) - intHORA
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
                strHORASTEMPOUTIL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                If decHORASDISPONIVEL > 0 Then
                    decHORASTEMPOUTILPERCENTUAL = decHORASTEMPOUTIL / decHORASDISPONIVEL
                    decHORASPARADAPERCENTUAL = decHORASPARADAS / decHORASDISPONIVEL
                    decHORASSETUPPERCENTUAL = decHORASETUP / decHORASDISPONIVEL
                    decHORASTESTEPERCENTUAL = decHORASTESTE / decHORASDISPONIVEL
                Else
                    decHORASTEMPOUTILPERCENTUAL = 0
                    decHORASPARADAPERCENTUAL = 0
                    decHORASSETUPPERCENTUAL = 0
                    decHORASTESTEPERCENTUAL = 0
                End If

                'Produção
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                           "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                           "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                           "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                           "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
                sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL = New DataSet
                sqldaBABEL.Fill(dtsBABEL, "BABEL")
                intBABELID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT SUM([exe_MCONTROL_BABELFISH_amarrado].[peso]) AS pesototal, SUM(CAST([exe_MCONTROL_BABELFISH_amarrado].[qtd] AS INT)) " &
                           "as metrostotal FROM exe_MCONTROL_BABELFISH_amarrado WHERE [id_maquinario] = '" & intBABELID &
                           "' And [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] >= @DI AND " &
                           "[exe_MCONTROL_BABELFISH_amarrado].[data_recebido] <= @DF AND [unidade] = 'M' AND [exe_MCONTROL_BABELFISH_amarrado].[deleted] = 0"
                sqldaPRODUCAO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPRODUCAO(intC) = New DataSet
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINICIAL))
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFINAL))
                sqldaPRODUCAO(intC).Fill(dtsPRODUCAO(intC), "Producao")
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) = False Then
                    decTONELADAS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) / 1000
                Else
                    decTONELADAS = 0D
                End If
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal")) = False Then
                    decMETROS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal"))
                Else
                    decMETROS = 0D
                End If

                'Registro na Base de Dados
                '/////////////////////////
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] ([userid]," &
                                           "[grupomaquina],[maquina],[toneladas],[metros],[tempoutil],[tempoutilpercentual]," &
                                           "[setup],[setuppercentual],[testes],[testespercentual],[paradas],[paradaspercentual]," &
                                           "[tempodisponivel]) VALUES (" & intUSERID & ", '" & strGRUPONOME & "', '" & strMAQUINANOME & "', " &
                                            decTONELADAS.ToString.Replace(",", ".") & ", " & decMETROS.ToString.Replace(",", ".") & ", '" &
                                            strHORASTEMPOUTIL & "', " & decHORASTEMPOUTILPERCENTUAL.ToString.Replace(",", ".") & ", '" &
                                            strHORASETUP & "', " & decHORASSETUPPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASTESTE & "', " &
                                            decHORASTESTEPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASPARADAS & "', " &
                                            decHORASPARADAPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASDISPONIVEL & "')"
                sqlcmdREPORT.ExecuteNonQuery()

                'Valores
                '///////
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [tempoutilvalor] = " & decHORASTEMPOUTIL.ToString.Replace(",", ".") & ", " &
                                           "[setupvalor] = " & decHORASETUP & ", [testesvalor] = " & decHORASTESTE & ", " &
                                           "[paradasvalor] = " & decHORASPARADAS & ", [tempodisponivelvalor] = " & decHORASDISPONIVEL & " WHERE [userid] = " & intUSERID & " And [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()


                decTONELADAS = 0D
                decMETROS = 0D

                'Demais Motivos
                '//////////////
                Array.Clear(strPARADAS, 0, 99)
                For intC2 = 0 To 20
                    strPARADASTEMPOTOTAL(intC2) = 0
                Next

                For intC2 = 0 To intCONTPARADAS - 1
                    intHORA = Int(Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600)
                    decFracionario = (Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600) - intHORA
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
                    strMOTIVOPARADA(intC2, 5) = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    If strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO ELÉTRICA" Then
                        strPARADAS(0) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(0) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO MECÂNICA" Then
                        strPARADAS(1) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(1) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AJUSTES NA PRODUÇÃO" Then
                        strPARADAS(2) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(2) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FERRAMENTAL" Then
                        strPARADAS(3) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(3) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "SETUP" Then
                        strPARADAS(4) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(4) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS - PROBLEMAS NA PRODUÇÃO" Then
                        strPARADAS(5) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(5) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "TROCA DE MATERIAL AUXILIAR" Then
                        strPARADAS(6) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(6) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "BALANÇA" Then
                        strPARADAS(7) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(7) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "DESARME DA MÁQUINA" Then
                        strPARADAS(8) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(8) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "REUNIÃO/TREINAMENTO/CIP/MODELLINE" Then
                        strPARADAS(9) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(9) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AGUARDANDO MANUTENÇÃO" Then
                        strPARADAS(10) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(10) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "ESPERA DE PONTE ROLANTE" Then
                        strPARADAS(11) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(11) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MÃO DE OBRA" Then
                        strPARADAS(12) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(12) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MATÉRIA-PRIMA" Then
                        strPARADAS(13) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(13) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE ORDEM " Then
                        strPARADAS(14) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(14) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FAZER EMENDA" Then
                        strPARADAS(15) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(15) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LIMPEZA" Then
                        strPARADAS(16) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(16) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS" Then
                        strPARADAS(17) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(17) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PARADA INEXISTENTE" Then
                        strPARADAS(18) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(18) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PROBLEMAS SAP/MES" Then
                        strPARADAS(19) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(19) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                        strPARADAS(20) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(20) = strMOTIVOPARADA(intC2, 2)
                    End If
                Next

                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [parada_1] = '" & strPARADAS(0) & "', " &
                                           "[parada_2] = '" & strPARADAS(1) & "', " &
                                           "[parada_3] = '" & strPARADAS(2) & "', " &
                                           "[parada_4] = '" & strPARADAS(3) & "', " &
                                           "[parada_5] = '" & strPARADAS(4) & "', " &
                                           "[parada_6] = '" & strPARADAS(5) & "', " &
                                           "[parada_7] = '" & strPARADAS(6) & "', " &
                                           "[parada_8] = '" & strPARADAS(7) & "', " &
                                           "[parada_9] = '" & strPARADAS(8) & "', " &
                                           "[parada_10] = '" & strPARADAS(9) & "', " &
                                           "[parada_11] = '" & strPARADAS(10) & "', " &
                                           "[parada_12] = '" & strPARADAS(11) & "', " &
                                           "[parada_13] = '" & strPARADAS(12) & "', " &
                                           "[parada_14] = '" & strPARADAS(13) & "', " &
                                           "[parada_15] = '" & strPARADAS(14) & "', " &
                                           "[parada_16] = '" & strPARADAS(15) & "', " &
                                           "[parada_17] = '" & strPARADAS(16) & "', " &
                                           "[parada_18] = '" & strPARADAS(17) & "', " &
                                           "[parada_19] = '" & strPARADAS(18) & "', " &
                                           "[parada_20] = '" & strPARADAS(19) & "', " &
                                           "[parada_21] = '" & strPARADAS(20) & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [paradavalor_1] = " & strPARADASTEMPOTOTAL(0) & ", " &
                                           "[paradavalor_2] = " & strPARADASTEMPOTOTAL(1) & ", " &
                                           "[paradavalor_3] = " & strPARADASTEMPOTOTAL(2) & ", " &
                                           "[paradavalor_4] = " & strPARADASTEMPOTOTAL(3) & ", " &
                                           "[paradavalor_5] = " & strPARADASTEMPOTOTAL(4) & ", " &
                                           "[paradavalor_6] = " & strPARADASTEMPOTOTAL(5) & ", " &
                                           "[paradavalor_7] = " & strPARADASTEMPOTOTAL(6) & ", " &
                                           "[paradavalor_8] = " & strPARADASTEMPOTOTAL(7) & ", " &
                                           "[paradavalor_9] = " & strPARADASTEMPOTOTAL(8) & ", " &
                                           "[paradavalor_10] =" & strPARADASTEMPOTOTAL(9) & ", " &
                                           "[paradavalor_11] =" & strPARADASTEMPOTOTAL(10) & ", " &
                                           "[paradavalor_12] =" & strPARADASTEMPOTOTAL(11) & ", " &
                                           "[paradavalor_13] =" & strPARADASTEMPOTOTAL(12) & ", " &
                                           "[paradavalor_14] =" & strPARADASTEMPOTOTAL(13) & ", " &
                                           "[paradavalor_15] =" & strPARADASTEMPOTOTAL(14) & ", " &
                                           "[paradavalor_16] =" & strPARADASTEMPOTOTAL(15) & ", " &
                                           "[paradavalor_17] =" & strPARADASTEMPOTOTAL(16) & ", " &
                                           "[paradavalor_18] =" & strPARADASTEMPOTOTAL(17) & ", " &
                                           "[paradavalor_19] =" & strPARADASTEMPOTOTAL(18) & ", " &
                                           "[paradavalor_20] =" & strPARADASTEMPOTOTAL(19) & ", " &
                                           "[paradavalor_21] =" & strPARADASTEMPOTOTAL(20) & " WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [utilizacao] = 0, " &
                                           "[diasuteis] = 0, [horasmes] = '00:00:00' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [grupomaquina] = '1.3 ESPECIAL' WHERE [maquina] = 'F07 MEINCOL 2'"
            sqlcmdREPORT.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTPRODUTIVIDADE_GRUPO_DIARIO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTPRODUTIVIDADE_GRUPO_LIVRE(ByVal lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                                           ByVal lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                                           ByVal strDATAINICIAL As String,
                                                           ByVal strHORAINICIAL As String,
                                                           ByVal strDATAFINAL As String,
                                                           ByVal strHORAFINAL As String,
                                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection

        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim bolNEWDAY As Boolean = False
        Dim strTURNOHORAINICIAL As String = Nothing
        Dim strTURNOHORAFINAL As String = Nothing
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing

        Dim sqldaTESTES As SqlDataAdapter
        Dim dtsTESTES As DataSet

        Dim strMOTIVOPARADA(999, 5) As String
        Dim bolFOUND As Boolean = False
        Dim intCONTPARADAS As Integer = 0
        Dim intPARADAS As Decimal = 0D
        Dim intCONTROLE As Integer = 0
        Dim strMOTIVOPARADATEMP(5) As String
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim intBABELID As Integer = 0

        Dim decPESOTOTAL As Decimal = 0D
        Dim decCOMPRIMENTOTAL As Decimal = 0D

        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim dtimeDATA As DateTime = Nothing
        Dim sqldaESCALAS(99) As SqlDataAdapter
        Dim dtsESCALAS(99) As DataSet
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim sqldaPARADAS(99) As SqlDataAdapter
        Dim dtsPARADAS(99) As DataSet
        Dim sqldaPRODUCAO(99) As SqlDataAdapter
        Dim dtsPRODUCAO(99) As DataSet
        Dim strGRUPONOME As String = Nothing
        Dim strMAQUINANOME As String = Nothing
        Dim decTONELADAS As Decimal = 0D
        Dim decMETROS As Decimal = 0D
        Dim strHORASTESTE As String = Nothing
        Dim strHORASETUP As String = Nothing
        Dim strHORASPARADAS As String = Nothing
        Dim strHORASDISPONIVEL As String = Nothing
        Dim decHORASPARADAS As Decimal = 0D
        Dim decHORASETUP As Decimal = 0D
        Dim decHORASTESTE As Decimal = 0D
        Dim decHORASDISPONIVEL As Decimal = 0D
        Dim decDISPONIBILIDADE As Decimal = 0D
        Dim decHORASTEMPOUTIL As Decimal = 0D
        Dim strHORASTEMPOUTIL As String = Nothing
        Dim decHORASTEMPOUTILPERCENTUAL As Decimal = 0D
        Dim decHORASPARADAPERCENTUAL As Decimal = 0D
        Dim decHORASSETUPPERCENTUAL As Decimal = 0D
        Dim decHORASTESTEPERCENTUAL As Decimal = 0D
        Dim strPARADAS(99) As String
        Dim strPARADASTEMPOTOTAL(99) As String
        Dim intDAYS As Integer = 0
        Dim dtsFERIADOS(99) As DataSet
        Dim sqldaFERIADOS(99) As SqlDataAdapter
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim intDIASUTEIS As Integer = 0
        Dim sqldaPERIODO(99) As SqlDataAdapter
        Dim dtsPERIODO(99) As DataSet
        Dim strPERIODOTINI As String = Nothing
        Dim strPERIODOTFIM As String = Nothing
        Dim dtimePERIODOTINI As DateTime = Nothing
        Dim dtimePERIODOTFIM As DateTime = Nothing
        Dim bolFOUNDTINI As Boolean = False
        Dim bolFOUNDTFIM As Boolean = False
        Dim decTOTALHORASMES As Decimal = 0D
        Dim strTOTALHORASMES As String = Nothing
        Dim decHORASUTILIZACAO As Decimal = 0D
        Dim decSETUPHORAS As Decimal = 0D
        Dim bolINDETERMINADO As Boolean
        Dim intINDETERMINADO As Integer = 0
        Dim strQ2 As String = Nothing

        Dim sqldaPPROG(99) As SqlDataAdapter
        Dim dtsPPROG(99) As DataSet
        Dim decPPROG As Decimal = 0D
        Dim dtimePPROGINI As DateTime = Nothing
        Dim dtimePPROGFIM As DateTime = Nothing

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0

        Dim dtimeESCALAINICIAL As DateTime = Nothing
        Dim dtimeESCALAFIM As DateTime = Nothing
        Dim dtimePARADAINICIAL As DateTime = Nothing
        Dim dtimePARADAFINAL As DateTime = Nothing
        Dim dtimeNOVAPARADAINICIAL As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            If lbMAQUINAID.CheckedItems.Count > 1 Then
                strQ2 = " AND (maquinaid = "
                For intC = 0 To lbMAQUINAID.CheckedItems.Count - 1
                    strQ2 &= lbMAQUINAID.CheckedItems(intC).ToString() & " OR maquinaid = "
                Next
                strQ2 = Mid(strQ2, 1, strQ2.Length - 16)
                strQ2 &= ")"
            Else
                strQ2 = "AND maquinaid = " & lbMAQUINAID.CheckedItems(0).ToString
            End If
            strQUERY = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, exe_MCONTROL_OEE_maquinas_grupos.maquinaid " &
                       "as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = " &
                       "exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_Maquinas ON " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " & strQ2 &
                       " ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            dtimeDATAINI = Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)
            dtimeDATAFIM = Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)
            reportDATAFINAL = strDATAFINAL & " " & strHORAFINAL

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")

            'Motivos Testes
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [testes] = 1"
            sqldaTESTES = New SqlDataAdapter(strQUERY, conSQL)
            dtsTESTES = New DataSet
            sqldaTESTES.Fill(dtsTESTES, "Testes")

            'Horas/Motivos
            '/////////////
            Dim strDATA As String = Nothing

            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")

                'Total de Dias Úteis
                '///////////////////
                intDIASUTEIS = 0
                'ReadDBGETDIASUTEIS(intMACHINEID, intDIASUTEIS, intMES, intANO)
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
                sqldaFERIADOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsFERIADOS(intC) = New DataSet
                sqldaFERIADOS(intC).Fill(dtsFERIADOS(intC), "Feriados")
                intDAYS = DateDiff(DateInterval.Day, dtimeDATAINI, dtimeDATAFIM)
                If intDAYS > 0 Then
                    For intC2 = 0 To intDAYS
                        strDATA = DateAdd(DateInterval.Day, intC2, dtimeDATAINI).ToShortDateString()
                        dtimeDATA = Convert.ToDateTime(strDATA)
                        For intC3 = 0 To dtsFERIADOS(intC).Tables(0).Rows.Count - 1
                            dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS(intC).Tables(0).Rows(intC3).Item("data"))
                            If dtimeFERIADO = dtimeDATA Then
                                bolFERIADO = True
                                Exit For
                            End If
                        Next
                        If bolFERIADO = False Then
                            If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                                intDIASUTEIS += 1
                            End If
                        Else
                            bolFERIADO = False
                        End If
                    Next
                ElseIf intDIASUTEIS = 0 Then
                    intDIASUTEIS = 1
                End If

                decTOTALHORASMES = intDIASUTEIS * 16.9166666667D * 3600
                intHORA = Int(decTOTALHORASMES / 3600)
                decFracionario = (decTOTALHORASMES / 3600) - intHORA
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
                strTOTALHORASMES = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                strMACHINEID = intMACHINEID.ToString("D6")

                strGRUPONOME = dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome")
                strMAQUINANOME = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome")
                strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strTABLENAME & " WHERE [date_shift] >= convert(Date, '" &
                           Mid(dtimeDATAINI.ToString, 1, 10) & "' ,103) And [date_shift] <= convert(Date, '" &
                           Mid(dtimeDATAFIM.ToString, 1, 10) & "',103) ORDER BY [date_shift] ASC"
                sqldaESCALAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALAS(intC) = New DataSet
                sqldaESCALAS(intC).Fill(dtsESCALAS(intC), "Escalas")

                'Zeramentos
                '////////////
                decHORASDISPONIVEL = 0D
                decHORASETUP = 0D
                decHORASTESTE = 0D
                decHORASPARADAS = 0D
                intCONTPARADAS = 0
                bolINDETERMINADO = False
                intINDETERMINADO = False
                Array.Clear(strMOTIVOPARADA, 0, strMOTIVOPARADA.Length)

                'Cálculo de Disponibilidade
                '//////////////////////////
                If dtsESCALAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1
                        strDATADAYSINI = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_begin")
                        strDATADAYSFIM = dtsESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC2).Item("time_end")
                        dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                        dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                        If dtimeDATADAYSINI >= dtimeDATAINI And dtimeDATADAYSFIM <= dtimeDATAFIM Then
                            decHORASDISPONIVEL += DateDiff(DateInterval.Second, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                        End If
                    Next
                End If

                'Verifica Paradas Programadas
                '////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 1"
                sqldaPPROG(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPPROG(intC) = New DataSet
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL)))
                sqldaPPROG(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL)))
                sqldaPPROG(intC).Fill(dtsPPROG(intC), "ParadasProgramadas")
                decPPROG = 0D
                If dtsPPROG(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPPROG(intC).Tables(0).Rows.Count - 1
                        dtimePPROGINI = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOn"))
                        dtimePPROGFIM = Convert.ToDateTime(dtsPPROG(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                        decPPROG += DateDiff(DateInterval.Second, dtimePPROGINI, dtimePPROGFIM)
                    Next
                End If
                decHORASDISPONIVEL -= decPPROG
                If decHORASDISPONIVEL < 0 Then
                    decHORASDISPONIVEL = 0
                End If
                intHORA = Int(decHORASDISPONIVEL / 3600)
                decFracionario = (decHORASDISPONIVEL / 3600) - intHORA
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
                strHORASDISPONIVEL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] LEFT JOIN exe_MCONTROL_OEE_motivosnivel1 ON exe_MCONTROL_OEE_HistoricoParadas.MotivoId = exe_MCONTROL_OEE_motivosnivel1.id WHERE [DateTimeOn] >= @DI AND [DateTimeOff] <= @DF " &
                           "AND [MachineId] = " & intMACHINEID & " AND exe_MCONTROL_OEE_motivosnivel1.paradaprogramada = 0"
                sqldaPARADAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPARADAS(intC) = New DataSet
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)))
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)))
                sqldaPARADAS(intC).Fill(dtsPARADAS(intC), "Paradas")

                If dtsPARADAS(intC).Tables(0).Rows.Count > 0 Then
                    For intC2 = 0 To dtsPARADAS(intC).Tables(0).Rows.Count - 1

                        dtimePARADAINICIAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn")
                        dtimePARADAFINAL = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff")

                        For intC3 = 0 To dtsESCALAS(intC).Tables(0).Rows.Count - 1

                            dtimeESCALAINICIAL = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_begin"))
                            dtimeESCALAFIM = Convert.ToDateTime(dtsESCALAS(intC).Tables(0).Rows(intC3).Item("date_shift") & " " & dtsESCALAS(intC).Tables(0).Rows(intC3).Item("time_end"))
                            If dtimePARADAINICIAL >= dtimeESCALAINICIAL And dtimePARADAINICIAL <= dtimeESCALAFIM Then
                                bolFOUND = True
                                Exit For
                            End If

                        Next

                        If bolFOUND = True Then

                            bolFOUND = False
                            If intCONTPARADAS = 0 Then

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    'É relamente uma parada
                                    '///////////////////////
                                    If bolFOUND = False Then
                                        strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                        strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                        strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        intCONTPARADAS += 1
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If

                            Else

                                If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then

                                    'Setup
                                    '//////
                                    For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                        If dtsSETUP.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                            decHORASETUP += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                          dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            bolFOUND = True
                                            Exit For
                                        End If
                                    Next

                                    'Testes
                                    '///////
                                    For intC3 = 0 To dtsTESTES.Tables(0).Rows.Count - 1
                                        If IsDBNull(dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")) = False Then
                                            If dtsTESTES.Tables(0).Rows(intC3).Item("id") = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") Then
                                                decHORASTESTE += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                               dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                bolFOUND = True
                                                Exit For
                                            End If
                                        End If
                                    Next

                                    If bolFOUND = False Then
                                        For intC3 = 0 To intCONTPARADAS - 1
                                            If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = strMOTIVOPARADA(intC3, 1) Then
                                                bolFOUND = True
                                                strMOTIVOPARADA(intC3, 2) = Val(strMOTIVOPARADA(intC3, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                                           dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                 dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                                Exit For
                                            End If
                                        Next
                                        If bolFOUND = True Then
                                            bolFOUND = False
                                        Else
                                            strMOTIVOPARADA(intCONTPARADAS, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("Motivo")
                                            strMOTIVOPARADA(intCONTPARADAS, 1) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId")
                                            strMOTIVOPARADA(intCONTPARADAS, 2) = Val(strMOTIVOPARADA(intCONTPARADAS, 2)) + DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                             dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            intCONTPARADAS += 1
                                        End If
                                    Else
                                        bolFOUND = False
                                    End If

                                Else

                                    bolINDETERMINADO = True
                                    intINDETERMINADO += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                      dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                    decHORASPARADAS += DateDiff(DateInterval.Second, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                     dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))

                                End If
                            End If
                        End If
                    Next
                End If

                bolFOUND = False
                If bolINDETERMINADO = True Then
                    For intC2 = 0 To intCONTPARADAS - 1
                        If strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                            bolFOUND = True
                            strMOTIVOPARADA(intC2, 2) = Val(strMOTIVOPARADA(intC2, 2)) + intINDETERMINADO
                            Exit For
                        End If
                    Next
                    If bolFOUND = False Then
                        strMOTIVOPARADA(intCONTPARADAS, 0) = "OUTROS"
                        strMOTIVOPARADA(intCONTPARADAS, 1) = "9999"
                        strMOTIVOPARADA(intCONTPARADAS, 2) = intINDETERMINADO
                        decHORASPARADAS += intINDETERMINADO
                        intCONTPARADAS += 1
                    End If
                End If

                If decHORASETUP > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "SETUP"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASETUP
                    intCONTPARADAS += 1
                End If

                If decHORASTESTE > 0 Then
                    strMOTIVOPARADA(intCONTPARADAS, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS"
                    strMOTIVOPARADA(intCONTPARADAS, 1) = 0
                    strMOTIVOPARADA(intCONTPARADAS, 2) = decHORASTESTE
                    intCONTPARADAS += 1
                End If

                'Coloca em Ordem Crescente de tempo as paradas
                '/////////////////////////////////////////////
                If intCONTPARADAS > 1 Then
                    intCONTROLE = 1
                    For intC2 = 0 To intCONTPARADAS - 2
                        strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                        strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                        strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                        strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                        strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                        strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                        For intC3 = intCONTROLE To intCONTPARADAS - 1
                            If Convert.ToInt32(strMOTIVOPARADATEMP(2)) < Convert.ToInt32(strMOTIVOPARADA(intC3, 2)) Then
                                strMOTIVOPARADA(intC2, 0) = strMOTIVOPARADA(intC3, 0)
                                strMOTIVOPARADA(intC2, 1) = strMOTIVOPARADA(intC3, 1)
                                strMOTIVOPARADA(intC2, 2) = strMOTIVOPARADA(intC3, 2)
                                strMOTIVOPARADA(intC2, 3) = strMOTIVOPARADA(intC3, 3)
                                strMOTIVOPARADA(intC2, 4) = strMOTIVOPARADA(intC3, 4)
                                strMOTIVOPARADA(intC2, 5) = strMOTIVOPARADA(intC3, 5)
                                strMOTIVOPARADA(intC3, 0) = strMOTIVOPARADATEMP(0)
                                strMOTIVOPARADA(intC3, 1) = strMOTIVOPARADATEMP(1)
                                strMOTIVOPARADA(intC3, 2) = strMOTIVOPARADATEMP(2)
                                strMOTIVOPARADA(intC3, 3) = strMOTIVOPARADATEMP(3)
                                strMOTIVOPARADA(intC3, 4) = strMOTIVOPARADATEMP(4)
                                strMOTIVOPARADA(intC3, 5) = strMOTIVOPARADATEMP(5)
                                strMOTIVOPARADATEMP(0) = strMOTIVOPARADA(intC2, 0)
                                strMOTIVOPARADATEMP(1) = strMOTIVOPARADA(intC2, 1)
                                strMOTIVOPARADATEMP(2) = strMOTIVOPARADA(intC2, 2)
                                strMOTIVOPARADATEMP(3) = strMOTIVOPARADA(intC2, 3)
                                strMOTIVOPARADATEMP(4) = strMOTIVOPARADA(intC2, 4)
                                strMOTIVOPARADATEMP(5) = strMOTIVOPARADA(intC2, 5)
                            End If
                        Next
                        intCONTROLE += 1
                    Next
                End If

                'Horas Paradas
                '/////////////
                intHORA = Int(decHORASPARADAS / 3600)
                decFracionario = (decHORASPARADAS / 3600) - intHORA
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
                strHORASPARADAS = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Setup
                '/////
                intHORA = Int(decHORASETUP / 3600)
                decFracionario = (decHORASETUP / 3600) - intHORA
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
                strHORASETUP = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Testes
                '//////
                intHORA = Int(decHORASTESTE / 3600)
                decFracionario = (decHORASTESTE / 3600) - intHORA
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
                strHORASTESTE = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                'Disponibilidade
                '///////////////
                If decHORASDISPONIVEL > 0 Then
                    decDISPONIBILIDADE = (decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)) / decHORASDISPONIVEL
                Else
                    decDISPONIBILIDADE = 0
                End If

                '%Utilização
                '///////////
                If decTOTALHORASMES > 0 Then
                    decHORASUTILIZACAO = decHORASDISPONIVEL / decTOTALHORASMES
                Else
                    decHORASUTILIZACAO = 0D
                End If

                'Tempo Útil
                '///////////
                decHORASTEMPOUTIL = decHORASDISPONIVEL - (decHORASPARADAS + decHORASETUP + decHORASTESTE)
                If decHORASTEMPOUTIL < 0 Then
                    decHORASTEMPOUTIL = 0
                End If
                intHORA = Int(decHORASTEMPOUTIL / 3600)
                decFracionario = (decHORASTEMPOUTIL / 3600) - intHORA
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
                strHORASTEMPOUTIL = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")

                If decHORASDISPONIVEL > 0 Then
                    decHORASTEMPOUTILPERCENTUAL = decHORASTEMPOUTIL / decHORASDISPONIVEL
                    decHORASPARADAPERCENTUAL = decHORASPARADAS / decHORASDISPONIVEL
                    decHORASSETUPPERCENTUAL = decHORASETUP / decHORASDISPONIVEL
                    decHORASTESTEPERCENTUAL = decHORASTESTE / decHORASDISPONIVEL
                Else
                    decHORASTEMPOUTILPERCENTUAL = 0
                    decHORASPARADAPERCENTUAL = 0
                    decHORASSETUPPERCENTUAL = 0
                    decHORASTESTEPERCENTUAL = 0
                End If

                'Produção
                '////////
                strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                          "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                          "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                          "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                          "exe_MCONTROL_OEE_Maquinas.Ativo = 1 And exe_MCONTROL_OEE_Maquinas.Id = " & intMACHINEID
                sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
                dtsBABEL = New DataSet
                sqldaBABEL.Fill(dtsBABEL, "BABEL")
                intBABELID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
                strQUERY = "SELECT SUM([exe_MCONTROL_BABELFISH_amarrado].[peso]) AS pesototal, SUM(CAST([exe_MCONTROL_BABELFISH_amarrado].[qtd] AS INT)) " &
                          "as metrostotal FROM exe_MCONTROL_BABELFISH_amarrado WHERE [id_maquinario] = '" & intBABELID &
                          "' And [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] >= @DI AND [exe_MCONTROL_BABELFISH_amarrado].[data_recebido] <= @DF AND [unidade] = 'M' " &
                          "AND [exe_MCONTROL_BABELFISH_amarrado].[deleted] = 0"
                sqldaPRODUCAO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPRODUCAO(intC) = New DataSet
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)))
                sqldaPRODUCAO(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)))
                sqldaPRODUCAO(intC).Fill(dtsPRODUCAO(intC), "Producao")
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) = False Then
                    decTONELADAS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("pesototal")) / 1000
                Else
                    decTONELADAS = 0D
                End If
                If IsDBNull(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal")) = False Then
                    decMETROS = Convert.ToDecimal(dtsPRODUCAO(intC).Tables(0).Rows(0).Item("metrostotal"))
                Else
                    decMETROS = 0D
                End If

                'Registro na Base de Dados
                '/////////////////////////
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] ([userid]," &
                                          "[grupomaquina],[maquina],[toneladas],[metros],[tempoutil],[tempoutilpercentual]," &
                                          "[setup],[setuppercentual],[testes],[testespercentual],[paradas],[paradaspercentual]," &
                                          "[tempodisponivel]) VALUES (" & intUSERID & ", '" & strGRUPONOME & "', '" & strMAQUINANOME & "', " &
                                           decTONELADAS.ToString.Replace(",", ".") & ", " & decMETROS.ToString.Replace(",", ".") & ", '" &
                                           strHORASTEMPOUTIL & "', " & decHORASTEMPOUTILPERCENTUAL.ToString.Replace(",", ".") & ", '" &
                                           strHORASETUP & "', " & decHORASSETUPPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASTESTE & "', " &
                                           decHORASTESTEPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASPARADAS & "', " &
                                           decHORASPARADAPERCENTUAL.ToString.Replace(",", ".") & ", '" & strHORASDISPONIVEL & "')"
                sqlcmdREPORT.ExecuteNonQuery()

                'Valores
                '///////
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [tempoutilvalor] = " & decHORASTEMPOUTIL.ToString.Replace(",", ".") & ", " &
                                           "[setupvalor] = " & decHORASETUP & ", [testesvalor] = " & decHORASTESTE & ", " &
                                           "[paradasvalor] = " & decHORASPARADAS & ", [tempodisponivelvalor] = " & decHORASDISPONIVEL & " WHERE [userid] = " & intUSERID & " And [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()


                decTONELADAS = 0D
                decMETROS = 0D

                'Demais Motivos
                '//////////////
                Array.Clear(strPARADAS, 0, 99)
                For intC2 = 0 To 20
                    strPARADASTEMPOTOTAL(intC2) = 0
                Next

                For intC2 = 0 To intCONTPARADAS - 1
                    intHORA = Int(Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600)
                    decFracionario = (Convert.ToInt32(strMOTIVOPARADA(intC2, 2)) / 3600) - intHORA
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
                    strMOTIVOPARADA(intC2, 5) = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    If strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO ELÉTRICA" Then
                        strPARADAS(0) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(0) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "MANUTENÇÃO MECÂNICA" Then
                        strPARADAS(1) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(1) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AJUSTES NA PRODUÇÃO" Then
                        strPARADAS(2) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(2) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FERRAMENTAL" Then
                        strPARADAS(3) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(3) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "SETUP" Then
                        strPARADAS(4) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(4) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS - PROBLEMAS NA PRODUÇÃO" Then
                        strPARADAS(5) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(5) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "TROCA DE MATERIAL AUXILIAR" Then
                        strPARADAS(6) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(6) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "BALANÇA" Then
                        strPARADAS(7) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(7) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "DESARME DA MÁQUINA" Then
                        strPARADAS(8) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(8) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "REUNIÃO/TREINAMENTO/CIP/MODELLINE" Then
                        strPARADAS(9) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(9) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "AGUARDANDO MANUTENÇÃO" Then
                        strPARADAS(10) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(10) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "ESPERA DE PONTE ROLANTE" Then
                        strPARADAS(11) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(11) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MÃO DE OBRA" Then
                        strPARADAS(12) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(12) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE MATÉRIA-PRIMA" Then
                        strPARADAS(13) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(13) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FALTA DE ORDEM " Then
                        strPARADAS(14) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(14) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "FAZER EMENDA" Then
                        strPARADAS(15) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(15) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LIMPEZA" Then
                        strPARADAS(16) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(16) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "LOTE PILOTO/TESTE EQUIPAMENTOS" Then
                        strPARADAS(17) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(17) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PARADA INEXISTENTE" Then
                        strPARADAS(18) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(18) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "PROBLEMAS SAP/MES" Then
                        strPARADAS(19) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(19) = strMOTIVOPARADA(intC2, 2)
                    ElseIf strMOTIVOPARADA(intC2, 0) = "OUTROS" Then
                        strPARADAS(20) = strMOTIVOPARADA(intC2, 5)
                        strPARADASTEMPOTOTAL(20) = strMOTIVOPARADA(intC2, 2)
                    End If
                Next

                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [parada_1] = '" & strPARADAS(0) & "', " &
                                           "[parada_2] = '" & strPARADAS(1) & "', " &
                                           "[parada_3] = '" & strPARADAS(2) & "', " &
                                           "[parada_4] = '" & strPARADAS(3) & "', " &
                                           "[parada_5] = '" & strPARADAS(4) & "', " &
                                           "[parada_6] = '" & strPARADAS(5) & "', " &
                                           "[parada_7] = '" & strPARADAS(6) & "', " &
                                           "[parada_8] = '" & strPARADAS(7) & "', " &
                                           "[parada_9] = '" & strPARADAS(8) & "', " &
                                           "[parada_10] = '" & strPARADAS(9) & "', " &
                                           "[parada_11] = '" & strPARADAS(10) & "', " &
                                           "[parada_12] = '" & strPARADAS(11) & "', " &
                                           "[parada_13] = '" & strPARADAS(12) & "', " &
                                           "[parada_14] = '" & strPARADAS(13) & "', " &
                                           "[parada_15] = '" & strPARADAS(14) & "', " &
                                           "[parada_16] = '" & strPARADAS(15) & "', " &
                                           "[parada_17] = '" & strPARADAS(16) & "', " &
                                           "[parada_18] = '" & strPARADAS(17) & "', " &
                                           "[parada_19] = '" & strPARADAS(18) & "', " &
                                           "[parada_20] = '" & strPARADAS(19) & "', " &
                                           "[parada_21] = '" & strPARADAS(20) & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [paradavalor_1] = " & strPARADASTEMPOTOTAL(0) & ", " &
                                           "[paradavalor_2] = " & strPARADASTEMPOTOTAL(1) & ", " &
                                           "[paradavalor_3] = " & strPARADASTEMPOTOTAL(2) & ", " &
                                           "[paradavalor_4] = " & strPARADASTEMPOTOTAL(3) & ", " &
                                           "[paradavalor_5] = " & strPARADASTEMPOTOTAL(4) & ", " &
                                           "[paradavalor_6] = " & strPARADASTEMPOTOTAL(5) & ", " &
                                           "[paradavalor_7] = " & strPARADASTEMPOTOTAL(6) & ", " &
                                           "[paradavalor_8] = " & strPARADASTEMPOTOTAL(7) & ", " &
                                           "[paradavalor_9] = " & strPARADASTEMPOTOTAL(8) & ", " &
                                           "[paradavalor_10] =" & strPARADASTEMPOTOTAL(9) & ", " &
                                           "[paradavalor_11] =" & strPARADASTEMPOTOTAL(10) & ", " &
                                           "[paradavalor_12] =" & strPARADASTEMPOTOTAL(11) & ", " &
                                           "[paradavalor_13] =" & strPARADASTEMPOTOTAL(12) & ", " &
                                           "[paradavalor_14] =" & strPARADASTEMPOTOTAL(13) & ", " &
                                           "[paradavalor_15] =" & strPARADASTEMPOTOTAL(14) & ", " &
                                           "[paradavalor_16] =" & strPARADASTEMPOTOTAL(15) & ", " &
                                           "[paradavalor_17] =" & strPARADASTEMPOTOTAL(16) & ", " &
                                           "[paradavalor_18] =" & strPARADASTEMPOTOTAL(17) & ", " &
                                           "[paradavalor_19] =" & strPARADASTEMPOTOTAL(18) & ", " &
                                           "[paradavalor_20] =" & strPARADASTEMPOTOTAL(19) & ", " &
                                           "[paradavalor_21] =" & strPARADASTEMPOTOTAL(20) & " WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
                sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [utilizacao] = " & decHORASUTILIZACAO.ToString.Replace(",", ".") & ", " &
                                           "[diasuteis] = " & intDIASUTEIS & ", [horasmes] = '" & strTOTALHORASMES & "' WHERE [userid] = " & intUSERID & " AND [maquina] = '" & strMAQUINANOME & "'"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            sqlcmdREPORT.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_report_produtividade_grupomaquinas] SET [grupomaquina] = '1.3 ESPECIAL' WHERE [maquina] = 'F07 MEINCOL 2'"
            sqlcmdREPORT.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTPRODUTIVIDADE_GRUPO_MENSAL"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'PARADAS
    '//////
    Public Function WriteDBREPORTPARADAS(ByVal dgvPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                         ByVal intUSERID As Integer,
                                         ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strB1 As String = Nothing
        Dim strB2 As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_paradas] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()
            For intC = 0 To dgvPARADAS.Rows.Count - 2
                If dgvPARADAS.Rows(intC).Cells(21).Value = True Then
                    strB1 = "1"
                Else
                    strB1 = "0"
                End If
                If dgvPARADAS.Rows(intC).Cells(22).Value = True Then
                    strB2 = "1"
                Else
                    strB2 = "0"
                End If
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_paradas] ([userid],[dataindex],[dataon],[horaon],[dataoff],[horaoff],[database],[centrotrabalho]," &
                                           "[usuario],[ordem],[item],[codigomaterial],[material],[turno],[totaltimeh],[totaltimemin],[motivonivel1],[motivonivel2]," &
                                           "[motivonivel3],[semcalendario],[paradaprogramada]) VALUES (" &
                                            intUSERID & ", convert(datetime, '" & dgvPARADAS.Rows(intC).Cells(2).Value & " " & dgvPARADAS.Rows(intC).Cells(3).Value & "',103) , '" &
                                            dgvPARADAS.Rows(intC).Cells(2).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(3).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(4).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(5).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(6).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(7).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(8).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(9).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(10).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(11).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(12).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(13).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(14).Value & "', " &
                                            dgvPARADAS.Rows(intC).Cells(15).Value.ToString.Replace(",", ".") & ", '" &
                                            dgvPARADAS.Rows(intC).Cells(16).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(17).Value & "', '" &
                                            dgvPARADAS.Rows(intC).Cells(18).Value & "', " & strB1 & ", " & strB2 & ")"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            reportTOTALTIME = dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(14).Value
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETPARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadBDGETMOTIVONIVEL1(ByRef cbMOTIVOS As ComboBox,
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
                For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                    cbMOTIVOS.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Descricao"))
                    cbMOTIVOSID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadBDGETMOTIVONIVEL1"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL2PARADAS(ByVal intMOTIVONIVEL1 As Integer,
                                                  ByRef cbMOTIVONIVEL2 As ComboBox,
                                                  ByRef cbMOTIVONIVEL2ID As ComboBox,
                                                  ByRef strERROR As String)

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
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVONIVEL1 & " ORDER BY [descricao] ASC"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                cbMOTIVONIVEL2.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                cbMOTIVONIVEL2ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("id"))
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL2PARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL3PARADAS(ByVal intMOTIVONIVEL2 As Integer,
                                                  ByRef cbMOTIVONIVEL3 As ComboBox,
                                                  ByRef cbMOTIVONIVEL3ID As ComboBox,
                                                  ByRef strERROR As String)

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
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intMOTIVONIVEL2 & " ORDER BY [descricao] ASC"
            Dim sqlaMotivos As New SqlDataAdapter(strCommand, conSQL)
            sqlaMotivos.Fill(dtMotivos, "Motivo")
            For intC = 0 To dtMotivos.Tables(0).Rows.Count - 1
                cbMOTIVONIVEL3.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("descricao"))
                cbMOTIVONIVEL3ID.Items.Add(dtMotivos.Tables(0).Rows(intC).Item("id"))
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL3PARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHECKPPROGRAMADA(ByRef advtPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByRef strERROR As String)

        Dim sqldaPARADA As SqlDataAdapter
        Dim dtsPARADA As DataSet
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim intMOTIVOPARADA As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM  exe_MCONTROL_OEE_motivosnivel1 WHERE [paradaprogramada] = 1"
            sqldaPARADA = New SqlDataAdapter(strQUERY, conSQL)
            dtsPARADA = New DataSet
            sqldaPARADA.Fill(dtsPARADA, "ParadaProgramada")
            If dtsPARADA.Tables(0).Rows.Count > 0 Then
                For intC = 0 To advtPARADAS.Rows.Count - 2
                    If IsDBNull(advtPARADAS.Rows(intC).Cells(23).Value) = False Then
                        intMOTIVOPARADA = advtPARADAS.Rows(intC).Cells(23).Value
                        For intC2 = 0 To dtsPARADA.Tables(0).Rows.Count - 1
                            If intMOTIVOPARADA = dtsPARADA.Tables(0).Rows(intC2).Item("id") Then
                                advtPARADAS.Rows(intC).Cells(22).Value = True
                            End If
                        Next
                    End If
                Next
            End If

            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKTEMPOCALENDARIO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'MANUTENÇÃO
    '//////////
    Public Function WriteDBREPORTMANUTENCAO_GRUPO(ByVal lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                                  ByVal lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                                  ByVal strDATAINICIAL As String,
                                                  ByVal strDATAFINAL As String,
                                                  ByVal strHORAINICIAL As String,
                                                  ByVal strHORAFINAL As String,
                                                  ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqlaESCALAS(99) As SqlDataAdapter
        Dim dtESCALAS(99) As DataSet
        Dim dtPRODUTIVIDADE As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim decInteger As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim strTEMPOTOTAL As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim decTEMPOTOTAL As Decimal = 0D
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strTABLENAME As String = Nothing
        Dim strDATAINI As String = Nothing
        Dim strDATAFIM As String = Nothing
        Dim intDATA As Integer = 0
        Dim strDATADAYSINI As String = Nothing
        Dim strDATADAYSFIM As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeDATADAYSINI As DateTime = Nothing
        Dim dtimeDATADAYSFIM As DateTime = Nothing
        Dim sqldaPARADAS(99) As SqlDataAdapter
        Dim dtsPARADAS(99) As DataSet
        Dim intCONTPARADAS As Integer = 0
        Dim sqldaSETUP As SqlDataAdapter
        Dim dtsSETUP As DataSet
        Dim sqldaWAIT As SqlDataAdapter
        Dim dtsWAIT As DataSet
        Dim intCONTWAIT As Integer = 0
        Dim sqldaGRUPOS As SqlDataAdapter
        Dim dtsGRUPOS As DataSet
        Dim strQ2 As String = Nothing
        Dim sqldaPARADAPROG As SqlDataAdapter
        Dim dtsPARADAPROG As DataSet
        Dim sqldaAGUARDANDO As SqlDataAdapter
        Dim dtsAGUARDANDO As DataSet
        Dim intMESESCALA As Integer = 0
        Dim intMESPARADA As Integer = 0
        Dim intHORASDISPONIVEL(99, 1) As Integer
        Dim intPARADAS(99, 1) As Integer
        Dim intTOTALPARADAS As Integer = 0
        Dim intPPROG As Integer = 0
        Dim intSETUP As Integer = 0
        Dim intWAIT As Integer = 0
        Dim intTOTALWAIT(99, 1) As Integer
        Dim intTOTALSETUP(99, 1) As Integer
        Dim bolFOUND As Boolean = False
        Dim intPARADACOUNT As Integer = 0
        Dim decMTBF As Decimal = 0D
        Dim decMTTR As Decimal = 0D
        Dim decMTAM As Decimal = 0D
        Dim decPARADA As Decimal = 0D
        Dim decDISPONIBILIDADE As Decimal = 0D
        Dim decWAIT As Decimal = 0D
        Dim decSETUP As Decimal = 0D
        Dim sqldaMOTIVOMANUTENCAO As SqlDataAdapter
        Dim dtsMOTIVOMANUTENCAO As DataSet
        Dim intMOTIVOMANUT As Integer = 0

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_manutencao] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            If lbMAQUINAID.CheckedItems.Count > 1 Then
                strQ2 = " AND (maquinaid = "
                For intC = 0 To lbMAQUINAID.CheckedItems.Count - 1
                    strQ2 &= lbMAQUINAID.CheckedItems(intC).ToString() & " OR maquinaid = "
                Next
                strQ2 = Mid(strQ2, 1, strQ2.Length - 16)
                strQ2 &= ")"
            Else
                strQ2 = "AND maquinaid = " & lbMAQUINAID.CheckedItems(0).ToString
            End If
            strQUERY = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.nome AS gruponome, exe_MCONTROL_OEE_maquinas_grupos.maquinaid " &
                       "as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao as maquinanome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                       "INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = " &
                       "exe_MCONTROL_OEE_maquinas_grupos.grupoid INNER JOIN exe_MCONTROL_OEE_Maquinas ON " &
                       "exe_MCONTROL_OEE_maquinas_grupos.maquinaid = exe_MCONTROL_OEE_Maquinas.Id WHERE exe_MCONTROL_OEE_Maquinas.Ativo = 1 " & strQ2 &
                       " ORDER BY gruponome, maquinanome ASC"
            sqldaGRUPOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsGRUPOS = New DataSet
            sqldaGRUPOS.Fill(dtsGRUPOS, "Grupos")

            'Motivos de SETUP
            '////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [setup] = 1"
            sqldaSETUP = New SqlDataAdapter(strQUERY, conSQL)
            dtsSETUP = New DataSet
            sqldaSETUP.Fill(dtsSETUP, "Setup")
            intSETUP = dtsSETUP.Tables(0).Rows.Count - 1

            'Aguardando Manutenção
            '/////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_aguardandomanutencao]"
            sqldaWAIT = New SqlDataAdapter(strQUERY, conSQL)
            dtsWAIT = New DataSet
            sqldaWAIT.Fill(dtsWAIT, "Wait")
            intCONTWAIT = dtsWAIT.Tables(0).Rows.Count

            'Paradas Programadas
            '////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1] WHERE [paradaprogramada] = 1"
            sqldaPARADAPROG = New SqlDataAdapter(strQUERY, conSQL)
            dtsPARADAPROG = New DataSet
            sqldaPARADAPROG.Fill(dtsPARADAPROG, "ParadaProg")
            intPPROG = dtsPARADAPROG.Tables(0).Rows.Count

            'Paradas Programadas
            '////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_manutencao]"
            sqldaMOTIVOMANUTENCAO = New SqlDataAdapter(strQUERY, conSQL)
            dtsMOTIVOMANUTENCAO = New DataSet
            sqldaMOTIVOMANUTENCAO.Fill(dtsMOTIVOMANUTENCAO, "MotivoManutencao")
            intMOTIVOMANUT = dtsMOTIVOMANUTENCAO.Tables(0).Rows.Count

            'Aguardando Manutenção
            '////////////////////
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivos_aguardandomanutencao]"
            sqldaAGUARDANDO = New SqlDataAdapter(strQUERY, conSQL)
            dtsAGUARDANDO = New DataSet
            sqldaAGUARDANDO.Fill(dtsAGUARDANDO, "Aguardando")
            intWAIT = dtsAGUARDANDO.Tables(0).Rows.Count - 1

            'Horas/Motivos
            '/////////////
            For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1

                intMACHINEID = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")
                strMACHINEID = intMACHINEID.ToString("D6")
                strNEWDATAINICIAL = strDATAINICIAL & " " & strHORAINICIAL
                strNEWDATAFINAL = strDATAFINAL & " " & strHORAFINAL
                dtimeDATAINI = Convert.ToDateTime(strNEWDATAINICIAL)
                dtimeDATAFIM = Convert.ToDateTime(strNEWDATAFINAL)
                strTABLENAME = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"

                reportDATAINICIAL = strNEWDATAINICIAL
                reportDATAFINAL = strNEWDATAFINAL

                strQUERY = "SELECT date_shift, time_begin, time_end, DATEPART(MONTH,[date_shift]) as DateTimeMonth FROM " &
                           strTABLENAME & " WHERE [date_shift] >= @DI AND [date_shift] <= @DF ORDER BY [date_shift] ASC, [time_begin] ASC"
                sqlaESCALAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtESCALAS(intC) = New DataSet
                sqlaESCALAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strNEWDATAINICIAL)))
                sqlaESCALAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strNEWDATAFINAL)))
                sqlaESCALAS(intC).Fill(dtESCALAS(intC), "Escalas")

                Array.Clear(intHORASDISPONIVEL, 0, intHORASDISPONIVEL.Length)
                Array.Clear(intPARADAS, 0, intPARADAS.Length)
                Array.Clear(intTOTALSETUP, 0, intTOTALSETUP.Length)
                Array.Clear(intTOTALWAIT, 0, intTOTALWAIT.Length)
                intMESESCALA = 0
                intMESPARADA = 0
                intPARADACOUNT = 0

                'Cálculo de Disponibilidade
                '//////////////////////////
                If dtESCALAS(intC).Tables(0).Rows.Count > 0 Then
                    intHORASDISPONIVEL(intMESESCALA, 0) = dtESCALAS(intC).Tables(0).Rows(0).Item("DateTimeMonth")
                    For intC2 = 0 To dtESCALAS(intC).Tables(0).Rows.Count - 1
                        If dtESCALAS(intC).Tables(0).Rows(intC2).Item("DateTimeMonth") > intHORASDISPONIVEL(intMESESCALA, 0) Then
                            intMESESCALA += 1
                            intHORASDISPONIVEL(intMESESCALA, 0) = dtESCALAS(intC).Tables(0).Rows(intC2).Item("DateTimeMonth")
                        End If
                        strDATADAYSINI = dtESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtESCALAS(intC).Tables(0).Rows(intC2).Item("time_begin")
                        strDATADAYSFIM = dtESCALAS(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtESCALAS(intC).Tables(0).Rows(intC2).Item("time_end")
                        dtimeDATADAYSINI = Convert.ToDateTime(strDATADAYSINI)
                        dtimeDATADAYSFIM = Convert.ToDateTime(strDATADAYSFIM)
                        intHORASDISPONIVEL(intMESESCALA, 1) += DateDiff(DateInterval.Minute, dtimeDATADAYSINI, dtimeDATADAYSFIM)
                    Next
                End If
                For intC2 = 0 To intMESESCALA
                    If intMESESCALA > 1 Then
                        strQ2 = " AND (DATEPART(MONTH,DateTimeOn) = "
                        For intC3 = 0 To intMESESCALA - 1
                            strQ2 &= intHORASDISPONIVEL(intC3, 0) & " OR DATEPART(MONTH,DateTimeOn) = "
                        Next
                        strQ2 = Mid(strQ2, 1, strQ2.Length - 33)
                        strQ2 &= ")"
                    Else
                        strQ2 = " AND DATEPART(MONTH,DateTimeOn) = " & intHORASDISPONIVEL(0, 0)
                    End If
                Next
                strQUERY = "SELECT DateTimeOn, DateTimeOff, MotivoId, DATEPART(MONTH,DateTimeOn) as DateTimeMonth FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] " &
                           "WHERE [DateTimeOn] >= @DI AND [DateTimeOn] <= @DF AND [MotivoId] IS NOT NULL AND [MachineId] = " & intMACHINEID & strQ2 & " ORDER BY DateTimeOn ASC"
                sqldaPARADAS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPARADAS(intC) = New DataSet
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", dtimeDATAINI))
                sqldaPARADAS(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", dtimeDATAFIM))
                sqldaPARADAS(intC).Fill(dtsPARADAS(intC), "Paradas")
                If dtsPARADAS(intC).Tables(0).Rows.Count > 0 Then
                    intPARADAS(intMESPARADA, 0) = dtsPARADAS(intC).Tables(0).Rows(0).Item("DateTimeMonth")
                    For intC2 = 0 To dtsPARADAS(intC).Tables(0).Rows.Count - 1
                        If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeMonth") > intPARADAS(intMESPARADA, 0) Then
                            intMESPARADA += 1
                            intPARADAS(intMESPARADA, 0) = dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeMonth")
                        End If
                        If intPPROG > 0 Then
                            For intC3 = 0 To dtsPARADAPROG.Tables(0).Rows.Count - 1
                                If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = dtsPARADAPROG.Tables(0).Rows(intC3).Item("Id") Then
                                    bolFOUND = True
                                    Exit For
                                End If
                            Next
                        End If
                        If bolFOUND = True Then
                            bolFOUND = False
                        Else
                            If intSETUP > 0 Then
                                For intC3 = 0 To dtsSETUP.Tables(0).Rows.Count - 1
                                    If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = dtsSETUP.Tables(0).Rows(intC3).Item("id") Then
                                        intTOTALSETUP(intMESPARADA, 1) += DateDiff(DateInterval.Minute, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                        dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                        bolFOUND = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If bolFOUND = True Then
                                bolFOUND = False
                            Else
                                If intWAIT > 0 Then
                                    For intC3 = 0 To dtsWAIT.Tables(0).Rows.Count - 1
                                        If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = dtsWAIT.Tables(0).Rows(intC3).Item("motivoid") Then
                                            intTOTALWAIT(intMESPARADA, 1) += DateDiff(DateInterval.Minute, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                           dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            Exit For
                                        End If
                                    Next
                                End If
                                If intMOTIVOMANUT > 0 Then
                                    For intC3 = 0 To dtsMOTIVOMANUTENCAO.Tables(0).Rows.Count - 1
                                        If dtsPARADAS(intC).Tables(0).Rows(intC2).Item("MotivoId") = dtsMOTIVOMANUTENCAO.Tables(0).Rows(intC3).Item("motivoid") Then
                                            intPARADAS(intMESPARADA, 1) += DateDiff(DateInterval.Minute, dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOn"),
                                                                                                         dtsPARADAS(intC).Tables(0).Rows(intC2).Item("DateTimeOff"))
                                            intPARADACOUNT += 1
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Next
                End If
                For intC2 = 0 To intMESESCALA
                    For intC3 = 0 To intMESPARADA
                        decPARADA = 0D
                        If intHORASDISPONIVEL(intC2, 0) = intPARADAS(intC3, 0) Then
                            decPARADA = intPARADAS(intC3, 1)
                            Exit For
                        End If
                    Next
                    For intC3 = 0 To intMESPARADA
                        decWAIT = 0D
                        If intHORASDISPONIVEL(intC2, 0) = intTOTALWAIT(intC3, 0) Then
                            decWAIT = intTOTALWAIT(intC3, 1)
                            Exit For
                        End If
                    Next
                    For intC3 = 0 To intMESPARADA
                        decSETUP = 0D
                        If intHORASDISPONIVEL(intC2, 0) = intTOTALSETUP(intC3, 0) Then
                            decSETUP = intTOTALSETUP(intC3, 1)
                            Exit For
                        End If
                    Next

                    If intPARADACOUNT > 0 Then
                        decMTTR = decPARADA / intPARADACOUNT
                        decMTAM = decWAIT / intPARADACOUNT
                        decMTBF = (intHORASDISPONIVEL(intC2, 1) - decPARADA) / intPARADACOUNT
                        If decMTBF < 0D Then decMTBF = 0D
                    Else
                        decMTBF = 0D
                        decMTTR = 0D
                        decMTAM = 0D
                    End If
                    If intHORASDISPONIVEL(intC2, 1) > 0 Then
                        decDISPONIBILIDADE = (intHORASDISPONIVEL(intC2, 1) - decPARADA - decSETUP) / intHORASDISPONIVEL(intC2, 1)
                    Else
                        decDISPONIBILIDADE = 0D
                    End If
                    If decDISPONIBILIDADE < 0D Then decDISPONIBILIDADE = 0D
                    sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_manutencao] ([userid],[grupomaquina],[maquina],[mtbf],[mttr],[mtam],[disponibilidade],[mes]) VALUES (" &
                                               intUSERID & ", '" & dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome") & "', '" &
                                               dtsGRUPOS.Tables(0).Rows(intC).Item("maquinanome") & "', " & decMTBF.ToString.Replace(",", ".") & ", " &
                                               decMTTR.ToString.Replace(",", ".") & ", " & decMTAM.ToString.Replace(",", ".") & ", " & decDISPONIBILIDADE.ToString.Replace(",", ".") & ", " &
                                               intHORASDISPONIVEL(intC2, 0) & ")"
                    sqlcmdREPORT.ExecuteNonQuery()
                Next
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTMANUTENCAO_GRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'TEMPO CALENDÁRIO
    '////////////////
    Public Function ReadDBCHECKTEMPOCALENDARIO(ByRef advtPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                               ByVal strDATAINICIAL As String,
                                               ByVal strDATAFINAL As String,
                                               ByRef bolFOUND As Boolean,
                                               ByRef strERROR As String)

        Dim sqldaESCALA(9999) As SqlDataAdapter
        Dim dtsESCALA(9999) As DataSet
        Dim sqldaTURNO(9999) As SqlDataAdapter
        Dim dtsTURNO(9999) As DataSet
        Dim dtimeDATAINICIALPARADA As DateTime = Nothing
        Dim dtimeDATAFINALPARADA As DateTime = Nothing
        Dim dtimeDATAINICIALTURNO As DateTime = Nothing
        Dim dtimeDATAFINALTURNO As DateTime = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim strMACHINEID As String = Nothing
        Dim strMACHINETABLE As String = Nothing
        Dim bolVALIDO As Boolean = False
        Dim intMACHINEID As Integer = 0
        Dim dtimeTURNOFINAL As DateTime = Nothing
        Dim bolDIA As Boolean = False
        Dim dtimeTURNO2INICIAL As DateTime = Nothing
        Dim dtimeTURNO2FINAL As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            For intC = 0 To advtPARADAS.Rows.Count - 2
                intMACHINEID = advtPARADAS.Rows(intC).Cells(1).Value
                strMACHINEID = intMACHINEID.ToString("D6")
                strMACHINETABLE = "[dbo].[exe_MCONTROL_OEE_" & strMACHINEID & "_Days]"
                strQUERY = "SELECT * FROM " & strMACHINETABLE & " INNER JOIN exe_MCONTROL_OEE_turnos ON exe_MCONTROL_OEE_turnos.id = exe_MCONTROL_OEE_" &
                           strMACHINEID & "_Days.shift_id WHERE [date_shift] >= @DI AND [date_shift] <= @DF ORDER BY [date_shift] ASC"
                sqldaESCALA(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsESCALA(intC) = New DataSet
                sqldaESCALA(intC).SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL)))
                sqldaESCALA(intC).SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL)))
                sqldaESCALA(intC).Fill(dtsESCALA(intC), "Escala")
                dtimeDATAINICIALPARADA = Convert.ToDateTime(advtPARADAS.Rows(intC).Cells(2).Value & " " & advtPARADAS.Rows(intC).Cells(3).Value)
                dtimeDATAFINALPARADA = Convert.ToDateTime(advtPARADAS.Rows(intC).Cells(4).Value & " " & advtPARADAS.Rows(intC).Cells(5).Value)
                For intC2 = 0 To dtsESCALA(intC).Tables(0).Rows.Count - 1
                    dtimeDATAINICIALTURNO = dtsESCALA(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALA(intC).Tables(0).Rows(intC2).Item("time_begin")
                    dtimeDATAFINALTURNO = dtsESCALA(intC).Tables(0).Rows(intC2).Item("date_shift") & " " & dtsESCALA(intC).Tables(0).Rows(intC2).Item("time_end")
                    If DateDiff(DateInterval.Minute, dtimeDATAINICIALTURNO, dtimeDATAFINALTURNO) < 0 Then
                        dtimeDATAFINALTURNO = DateAdd(DateInterval.Day, 1, dtimeDATAFINALTURNO)
                    End If
                    If dtimeDATAINICIALPARADA >= dtimeDATAINICIALTURNO And dtimeDATAINICIALPARADA <= dtimeDATAFINALTURNO Then
                        bolVALIDO = True
                        advtPARADAS.Rows(intC).Cells(13).Value = dtsESCALA(intC).Tables(0).Rows(intC2).Item("nome")
                        Exit For
                    End If
                Next
                If bolVALIDO = False Then
                    advtPARADAS.Rows(intC).Cells(21).Value = True
                Else
                    bolVALIDO = False
                End If
                strQUERY = "SELECT * FROM exe_MCONTROL_OEE_periodotrabalho WHERE [maquinaid] = " & intMACHINEID
                sqldaTURNO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNO(intC) = New DataSet
                sqldaTURNO(intC).Fill(dtsTURNO(intC), "Turno")
                dtimeDATAINICIALTURNO = Convert.ToDateTime(Mid(dtimeDATAINICIALPARADA.ToString, 1, 10) & " " & dtsTURNO(intC).Tables(0).Rows(0).Item("horarioinicial"))
                dtimeDATAFINALTURNO = Convert.ToDateTime(Mid(dtimeDATAINICIALPARADA.ToString, 1, 10) & " " & dtsTURNO(intC).Tables(0).Rows(0).Item("horariofinal"))
                If dtimeDATAFINALTURNO < dtimeDATAINICIALTURNO Then
                    dtimeDATAFINALTURNO = DateAdd(DateInterval.Day, 1, dtimeDATAFINALTURNO)
                End If
                If dtimeDATAINICIALPARADA >= dtimeDATAINICIALTURNO And dtimeDATAFINALPARADA <= dtimeDATAFINALTURNO Then
                    advtPARADAS.Rows(intC).Cells(6).Value = Mid(dtimeDATAINICIALPARADA.ToString, 1, 10)
                Else
                    advtPARADAS.Rows(intC).Cells(6).Value = Mid((DateAdd(DateInterval.Day, -1, dtimeDATAINICIALPARADA)).ToString, 1, 10)
                End If

            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKTEMPOCALENDARIO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBREPORTTEMPOCALENDARIO(ByVal lbMAQUINA As DevComponents.DotNetBar.ListBoxAdv,
                                                 ByVal lbMAQUINAID As DevComponents.DotNetBar.ListBoxAdv,
                                                 ByVal strDATAINICIALORIGINAL As String,
                                                 ByVal strDATAFINALORIGINAL As String,
                                                 ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strMachineNewId As String = Nothing
        Dim strMachineTable As String = Nothing
        Dim sqldaTC As SqlDataAdapter
        Dim dtsTC As DataSet
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim dtimeDATAINICIALPERIODO As DateTime = Nothing
        Dim dtimeDATAFINALPERIODO As DateTime = Nothing
        Dim intTEMPO As Integer = 0
        Dim strTURNO As String = Nothing
        Dim sqlcmdREPORT As New SqlCommand
        Dim strDIA As String = Nothing
        Dim strVERTORTURNO(9, 4) As String
        Dim intCT As Integer = 0
        Dim bolFOUND As Boolean = False
        Dim strMACHINEID As String = Nothing
        Dim strMAQUINA As String = Nothing
        Dim sqldaTURNOS(999) As SqlDataAdapter
        Dim dtsTURNOS(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim sqldaPERIODO(999) As SqlDataAdapter
        Dim dtsPERIODO(999) As DataSet
        Dim intDAYS As Integer = 0
        Dim strDINICIAL As String = Nothing
        Dim strDFINAL As String = Nothing
        Dim dtimeDATAINI As DateTime = Nothing
        Dim dtimeDATAFIM As DateTime = Nothing
        Dim dtimeTINICIAL As DateTime = Nothing
        Dim dtimeTFINAL As DateTime = Nothing
        Dim intID As Integer = 0
        Dim strNOMEMAQUINA As String = Nothing
        Dim strDATAINICIAL As String = Nothing
        Dim strDATAFINAL As String = Nothing
        Dim intCONTADOR As Integer = 0

        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0
        Dim decFRACIONARIO As Decimal = 0D
        Dim strTEMPO As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_tempocalendario] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            For intC = 0 To lbMAQUINAID.CheckedItems.Count - 1

                strMACHINEID = Val(lbMAQUINAID.CheckedItems(intC).ToString)
                strMAQUINA = lbMAQUINA.CheckedItems(intC).ToString
                dtimeDATAINI = Convert.ToDateTime(strDATAINICIALORIGINAL & " 00:00:00")
                dtimeDATAFIM = Convert.ToDateTime(strDATAFINALORIGINAL & " 23:59:00")
                strMachineNewId = Convert.ToInt32(strMACHINEID).ToString("D6")

                'Verifica quais os turnos cadastrados da máquina para ajustar a data final
                '/////////////////////////////////////////////////////////////////////////
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_turnos] WHERE [idmaquina] = " & strMACHINEID
                sqldaTURNOS(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsTURNOS(intC) = New DataSet
                sqldaTURNOS(intC).Fill(dtsTURNOS(intC), "Turnos")

                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_periodotrabalho] WHERE [maquinaid] = " & strMACHINEID
                sqldaPERIODO(intC) = New SqlDataAdapter(strQUERY, conSQL)
                dtsPERIODO(intC) = New DataSet
                sqldaPERIODO(intC).Fill(dtsPERIODO(intC), "Periodo")
                strDINICIAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horarioinicial")
                strDFINAL = "01/01/2020 " & " " & dtsPERIODO(intC).Tables(0).Rows(0).Item("horariofinal")

                intDAYS = DateDiff(DateInterval.Second, Convert.ToDateTime(strDINICIAL), Convert.ToDateTime(strDFINAL))
                If intDAYS < 0 Then
                    dtimeDATAFIM = DateAdd(DateInterval.Day, 1, dtimeDATAFIM)
                End If
                strDATAINICIAL = Mid(dtimeDATAINI.ToString, 1, 10) & " " & Mid(strDINICIAL, 12, 9)
                strDATAFINAL = Mid(dtimeDATAFIM.ToString, 1, 10) & " " & Mid(strDFINAL, 12, 9)
                dtimeDATAINICIALPERIODO = Convert.ToDateTime(strDATAINICIAL)
                dtimeDATAFINALPERIODO = Convert.ToDateTime(strDATAFINAL)

                strCommand = "SELECT exe_MCONTROL_OEE_" & strMachineNewId & "_Days.date_shift, exe_MCONTROL_OEE_" & strMachineNewId &
                             "_Days.time_begin, exe_MCONTROL_OEE_" & strMachineNewId & "_Days.time_end, exe_MCONTROL_OEE_turnos.nome, exe_MCONTROL_OEE_turnos.id FROM " &
                             "exe_MCONTROL_OEE_" & strMachineNewId & "_Days INNER Join exe_MCONTROL_OEE_turnos On exe_MCONTROL_OEE_" &
                             strMachineNewId & "_Days.shift_id = exe_MCONTROL_OEE_turnos.id WHERE [date_shift] >= @DI AND [date_shift] <= @DF ORDER BY [date_shift], [time_begin] ASC"
                sqldaTC = New SqlDataAdapter(strCommand, conSQL)
                dtsTC = New DataSet
                sqldaTC.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(Mid(strDATAINICIAL, 1, 10))))
                sqldaTC.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(Mid(strDATAFINAL, 1, 10))))
                sqldaTC.Fill(dtsTC, "TC")
                intCT = 0
                intCONTADOR = 0
                Array.Clear(strVERTORTURNO, 0, strVERTORTURNO.Length)

                For intC2 = 0 To dtsTC.Tables(0).Rows.Count - 1

                    dtimeDATAINICIAL = Convert.ToDateTime(dtsTC.Tables(0).Rows(intC2).Item("date_shift") & " " &
                                                          dtsTC.Tables(0).Rows(intC2).Item("time_begin"))
                    dtimeDATAFINAL = Convert.ToDateTime(dtsTC.Tables(0).Rows(intC2).Item("date_shift") & " " &
                                                        dtsTC.Tables(0).Rows(intC2).Item("time_end"))

                    If dtimeDATAINICIAL >= dtimeDATAINICIALPERIODO And dtimeDATAFINAL <= dtimeDATAFINALPERIODO Then

                        strTURNO = dtsTC.Tables(0).Rows(intC2).Item("nome")
                        intTEMPO = DateDiff(DateInterval.Minute, dtimeDATAINICIAL, dtimeDATAFINAL)
                        intID = dtsTC.Tables(0).Rows(intC2).Item("id")
                        If intCONTADOR = 0 Then
                            strVERTORTURNO(intCT, 0) = strTURNO
                            strVERTORTURNO(intCT, 1) = intTEMPO
                            strVERTORTURNO(intCT, 2) = dtsTC.Tables(0).Rows(intC2).Item("date_shift")
                            strVERTORTURNO(intCT, 3) = intID
                            strVERTORTURNO(intCT, 4) = dtimeDATAINICIAL.ToString
                            intCT += 1
                            intCONTADOR += 1
                        Else
                            If Val(strVERTORTURNO(intCT - 1, 3)) <> dtsTC.Tables(0).Rows(intC2).Item("id") Then
                                For intC3 = 0 To intCT - 1
                                    intHORA = Int(Val(strVERTORTURNO(intC3, 1)) / 60)
                                    decFRACIONARIO = (Val(strVERTORTURNO(intC3, 1)) / 60) - intHORA
                                    intMINUTO = Int((decFRACIONARIO * 60))
                                    intSEGUNDO = (((decFRACIONARIO * 60)) - intMINUTO) * 60
                                    If intSEGUNDO = 60 Then
                                        intSEGUNDO = 0
                                        intMINUTO += 1
                                        If intMINUTO = 60 Then
                                            intMINUTO = 0
                                            intHORA += 1
                                        End If
                                    End If
                                    strTEMPO = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                                    sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_tempocalendario] ([userid],[maquina],[data],[turno],[tempo],[tempohhmm]) VALUES (" &
                                                                intUSERID & ", '" & strMAQUINA & "', convert(datetime, '" & strVERTORTURNO(intC3, 2) & "',103), '" &
                                                                strVERTORTURNO(intC3, 0) & "', " & strVERTORTURNO(intC3, 1) & ", '" & strTEMPO & "')"
                                    sqlcmdREPORT.ExecuteNonQuery()
                                Next
                                Array.Clear(strVERTORTURNO, 0, strVERTORTURNO.Length)
                                intCT = 0
                                strVERTORTURNO(intCT, 0) = strTURNO
                                strVERTORTURNO(intCT, 1) = intTEMPO
                                strVERTORTURNO(intCT, 2) = dtsTC.Tables(0).Rows(intC2).Item("date_shift")
                                strVERTORTURNO(intCT, 3) = intID
                                strVERTORTURNO(intCT, 4) = dtimeDATAINICIAL.ToString
                                intCT += 1
                            Else
                                For intC3 = 0 To intCT - 1
                                    If strVERTORTURNO(intC3, 0) <> Nothing Then
                                        If Val(strVERTORTURNO(intC3, 3)) = intID And Mid(strVERTORTURNO(intC3, 4), 12, 8) <> Mid(dtimeDATAINICIAL.ToString, 12, 8) Then
                                            strVERTORTURNO(intC3, 1) = Val(strVERTORTURNO(intC3, 1)) + intTEMPO
                                            bolFOUND = True
                                            Exit For
                                        ElseIf Val(strVERTORTURNO(intC3, 3)) = intID And strVERTORTURNO(intC3, 4) = dtimeDATAINICIAL.ToString Then
                                            Exit For
                                        End If
                                    Else
                                        Exit For
                                    End If
                                Next
                                If bolFOUND = False Then
                                    strVERTORTURNO(intCT, 0) = strTURNO
                                    strVERTORTURNO(intCT, 1) = intTEMPO
                                    strVERTORTURNO(intCT, 2) = dtsTC.Tables(0).Rows(intC2).Item("date_shift")
                                    strVERTORTURNO(intCT, 3) = intID
                                    strVERTORTURNO(intCT, 4) = dtimeDATAINICIAL.ToString
                                    intCT += 1
                                Else
                                    bolFOUND = False
                                End If
                            End If
                        End If

                    End If
                Next
                intHORA = Int(Val(strVERTORTURNO(intCT - 1, 1)) / 60)
                decFRACIONARIO = (Val(strVERTORTURNO(intCT - 1, 1)) / 60) - intHORA
                intMINUTO = Int((decFRACIONARIO * 60))
                intSEGUNDO = (((decFRACIONARIO * 60)) - intMINUTO) * 60
                If intSEGUNDO = 60 Then
                    intSEGUNDO = 0
                    intMINUTO += 1
                    If intMINUTO = 60 Then
                        intMINUTO = 0
                        intHORA += 1
                    End If
                End If
                strTEMPO = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                sqlcmdREPORT.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_tempocalendario] ([userid],[maquina],[data],[turno],[tempo],[tempohhmm]) VALUES (" &
                                                              intUSERID & ", '" & strMAQUINA & "', convert(datetime, '" & strVERTORTURNO(intCT - 1, 2) & "',103), '" &
                                                              strVERTORTURNO(intCT - 1, 0) & "', " & strVERTORTURNO(intCT - 1, 1) & ", '" & strTEMPO & "')"
                sqlcmdREPORT.ExecuteNonQuery()
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTTEMPOCALENDARIO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'AMARRADO
    '////////
    Public Function WriteDBREPORTAMARRADO(ByVal intMAQUINAID As Integer,
                                          ByVal strDATAINICIAL As String,
                                          ByVal strHORAINICIAL As String,
                                          ByVal strDATAFINAL As String,
                                          ByVal strHORAFINAL As String,
                                          ByRef strERROR As String)



        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaAMARRADO As SqlDataAdapter
        Dim dtsAMARRADO As DataSet
        Dim sqldaBABEL As SqlDataAdapter
        Dim dtsBABEL As DataSet
        Dim strQUERY As String = Nothing

        Try

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdREPORT.Connection = conSQL
            sqlcmdREPORT.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_amarrado] WHERE [userid] = " & intUSERID
            sqlcmdREPORT.ExecuteNonQuery()

            'Amarrado
            '////////
            strQUERY = "Select exe_MCONTROL_OEE_Maquinas.Id As maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                       "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices On exe_MCONTROL_OEE_Maquinas.Id = " &
                       "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences On " &
                       "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id WHERE " &
                       "exe_MCONTROL_OEE_Maquinas.Id = " & intMAQUINAID & " And exe_MCONTROL_OEE_Maquinas.Ativo = 1 " &
                       "ORDER BY exe_MCONTROL_OEE_Maquinas.Descricao ASC"
            sqldaBABEL = New SqlDataAdapter(strQUERY, conSQL)
            dtsBABEL = New DataSet
            sqldaBABEL.Fill(dtsBABEL, "BABEL")
            intMAQUINAID = dtsBABEL.Tables(0).Rows(0).Item("babelfish_id")
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [data_recebido] >= @DI AND [data_recebido] <= @DF " &
                       "AND [id_maquinario] = " & intMAQUINAID & " AND [deleted] = 0 ORDER BY [data_recebido] ASC"
            sqldaAMARRADO = New SqlDataAdapter(strQUERY, conSQL)
            dtsAMARRADO = New DataSet
            sqldaAMARRADO.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)))
            sqldaAMARRADO.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)))
            sqldaAMARRADO.Fill(dtsAMARRADO, "Amarrado")
            If dtsAMARRADO.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsAMARRADO.Tables(0).Rows.Count - 1
                    If dtsAMARRADO.Tables(0).Rows(intC).Item("unidade") = "M" Then
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_amarrado] ([userid],[data_recebido],[datahora],[hora],[ordemproducao],[descricaomaterial]," &
                                   "[unidade],[peso],[pecas],[metros],[materialId],[comprimento],[numHU]) VALUES (" & intUSERID & ", convert(datetime, '" & dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido") & "',103) , convert(date, '" & Mid(dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido"), 1, 10) & "',103)" & ", '" &
                                   Mid(dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido"), 12, 8) & "', '" &
                                   dtsAMARRADO.Tables(0).Rows(intC).Item("ordem") & "', '" & dtsAMARRADO.Tables(0).Rows(intC).Item("descricao_material") & "', '" &
                                   dtsAMARRADO.Tables(0).Rows(intC).Item("unidade") & "', " & dtsAMARRADO.Tables(0).Rows(intC).Item("peso").ToString.Replace(",", ".") & ", " &
                                   dtsAMARRADO.Tables(0).Rows(intC).Item("pecas_hu") & ", " & dtsAMARRADO.Tables(0).Rows(intC).Item("qtd").ToString.Replace(",", ".") & ", '" &
                                   dtsAMARRADO.Tables(0).Rows(intC).Item("material") & "', " & dtsAMARRADO.Tables(0).Rows(intC).Item("comprimento") & ", " &
                                   dtsAMARRADO.Tables(0).Rows(intC).Item("num_hu") & ")"
                    Else
                        strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_amarrado] ([userid],[data_recebido],[datahora],[hora],[ordemproducao],[descricaomaterial]," &
                                 "[unidade],[peso],[pecas],[metros],[materialId],[comprimento],[numHU]) VALUES (" & intUSERID & ", convert(datetime, '" & dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido") & "',103), convert(date, '" & Mid(dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido"), 1, 10) & "',103)" & ", '" &
                                 Mid(dtsAMARRADO.Tables(0).Rows(intC).Item("data_recebido"), 12, 8) & "', '" &
                                 dtsAMARRADO.Tables(0).Rows(intC).Item("ordem") & "', '" & dtsAMARRADO.Tables(0).Rows(intC).Item("descricao_material") & "', '" &
                                 dtsAMARRADO.Tables(0).Rows(intC).Item("unidade") & "', " & dtsAMARRADO.Tables(0).Rows(intC).Item("peso").ToString.Replace(",", ".") & ", " &
                                 dtsAMARRADO.Tables(0).Rows(intC).Item("pecas_hu") & ", 0, '" &
                                 dtsAMARRADO.Tables(0).Rows(intC).Item("material") & "', " & dtsAMARRADO.Tables(0).Rows(intC).Item("comprimento") & ", " &
                                 dtsAMARRADO.Tables(0).Rows(intC).Item("num_hu") & ")"
                    End If
                    sqlcmdREPORT.CommandText = strQUERY
                    sqlcmdREPORT.ExecuteNonQuery()
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORTAPONTAMENTO_GRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try


    End Function
    Public Function ReadDBGETOPSDELETADAS(ByRef dgvOPS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                          ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdREPORT As New SqlCommand
        Dim strConn As String
        Dim sqldaOP As SqlDataAdapter
        Dim dtsOP As DataSet
        Dim strQUERY As String = Nothing

        Try

            'Acha os turnos da máquina para montar os resumos
            '////////////////////////////////////////////////
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_amarrado] WHERE [deleted] = 1"
            sqldaOP = New SqlDataAdapter(strQUERY, conSQL)
            dtsOP = New DataSet
            sqldaOP.Fill(dtsOP, "OP")
            If dtsOP.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsOP.Tables(0).Rows.Count - 1
                    dgvOPS.Rows.Add()
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(0).Value = dtsOP.Tables(0).Rows(intC).Item("id")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(1).Value = dtsOP.Tables(0).Rows(intC).Item("data_recebido")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(2).Value = dtsOP.Tables(0).Rows(intC).Item("ordem")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(3).Value = dtsOP.Tables(0).Rows(intC).Item("cliente")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(4).Value = dtsOP.Tables(0).Rows(intC).Item("centro_trabalho")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(5).Value = dtsOP.Tables(0).Rows(intC).Item("material")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(6).Value = dtsOP.Tables(0).Rows(intC).Item("descricao_material")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(7).Value = dtsOP.Tables(0).Rows(intC).Item("lote")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(8).Value = dtsOP.Tables(0).Rows(intC).Item("item_ordem")
                    dgvOPS.Rows(dgvOPS.Rows.Count - 1).Cells(9).Value = dtsOP.Tables(0).Rows(intC).Item("num_hu")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETOPSDELETADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUNDELETEOP(ByVal intOPID As Integer,
                                      ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "UPDATE [dbo].[exe_MCONTROL_BABELFISH_amarrado] SET [deleted] = 0 WHERE [Id] = " & intOPID
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUNDELETEOP"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

    'CONTROLE DE DATAS E HORÁRIOS
    '////////////////////////////
    Public Function ReadDBGETDIASUTEIS(ByVal intMAQUINAID As Integer,
                                       ByRef intDIASUTEIS As Integer,
                                       ByVal intMES As Integer,
                                       ByVal strANO As String)

        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim dtimeDATA As DateTime = Nothing
        Dim strMES As String = Nothing
        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim strDATA As String = Nothing

        Try

            If intMES < 10 Then
                strMES = "0" & intMES
            Else
                strMES = intMES.ToString
            End If

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
            sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsFERIADOS = New DataSet
            sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")

            dtimeDATAINICIAL = Convert.ToDateTime("01/" & strMES & "/" & strANO)
            dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtimeDATAINICIAL))
            intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
            If intDAYS > 0 Then
                For intC = 0 To intDAYS
                    strDATA = DateAdd(DateInterval.Day, intC, dtimeDATAINICIAL).ToShortDateString
                    dtimeDATA = Convert.ToDateTime(strDATA)
                    For intC2 = 0 To dtsFERIADOS.Tables(0).Rows.Count - 1
                        dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS.Tables(0).Rows(intC2).Item("data"))
                        If dtimeFERIADO = dtimeDATA Then
                            bolFERIADO = True
                            Exit For
                        End If
                    Next
                    If bolFERIADO = False Then
                        If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                            intDIASUTEIS += 1
                        End If
                    Else
                        bolFERIADO = False
                    End If
                Next
            Else
                intDIASUTEIS = "0"
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETDIASUTEIS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETDIASUTEISPERIODO(ByRef intDIASUTEIS As Integer,
                                              ByVal strDATAINICIAL As String,
                                              ByVal strHORAINICIAL As String,
                                              ByVal strDATAFINAL As String,
                                              ByVal strHORAFINAL As String,
                                              ByRef strERROR As String)

        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim dtimeDATA As DateTime = Nothing
        Dim strMES As String = Nothing
        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False
        Dim strDATA As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
            sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsFERIADOS = New DataSet
            sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")

            dtimeDATAINICIAL = Convert.ToDateTime(strDATAINICIAL & " " & strHORAINICIAL)
            dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL & " " & strHORAFINAL)
            intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
            If intDAYS > 0 Then
                For intC = 0 To intDAYS
                    strDATA = DateAdd(DateInterval.Day, intC, dtimeDATAINICIAL).ToShortDateString
                    dtimeDATA = Convert.ToDateTime(strDATA)
                    For intC2 = 0 To dtsFERIADOS.Tables(0).Rows.Count - 1
                        dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS.Tables(0).Rows(intC2).Item("data"))
                        If dtimeFERIADO = dtimeDATA Then
                            bolFERIADO = True
                            Exit For
                        End If
                    Next
                    If bolFERIADO = False Then
                        If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                            intDIASUTEIS += 1
                        End If
                    Else
                        bolFERIADO = False
                    End If
                Next
                intDIASUTEIS = intDIASUTEIS
            Else
                intDIASUTEIS = 0
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETDIASUTEISPERIODO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETDIASUTEISHOJE(ByVal intMAQUINAID As Integer,
                                           ByRef intDIASUTEIS As Integer,
                                           ByVal intMES As Integer,
                                           ByVal strANO As String,
                                           ByVal strDATAFINAL As String)

        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim intDAYS As Integer = 0
        Dim dtimeDATA As DateTime = Nothing
        Dim strMES As String = Nothing
        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim dtimeFERIADO As DateTime = Nothing
        Dim bolFERIADO As Boolean = False

        Try

            If intMES < 10 Then
                strMES = "0" & intMES
            Else
                strMES = intMES.ToString
            End If

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
            sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
            dtsFERIADOS = New DataSet
            sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")

            dtimeDATAINICIAL = Convert.ToDateTime("01/" & strMES & "/" & strANO)
            dtimeDATAFINAL = Convert.ToDateTime(strDATAFINAL)
            dtimeDATAFINAL = DateAdd(DateInterval.Day, -1, dtimeDATAFINAL)
            intDAYS = DateDiff(DateInterval.Day, dtimeDATAINICIAL, dtimeDATAFINAL)
            If intDAYS > 0 Then
                For intC = 0 To intDAYS
                    dtimeDATA = DateAdd(DateInterval.Day, intC, dtimeDATAINICIAL)
                    For intC2 = 0 To dtsFERIADOS.Tables(0).Rows.Count - 1
                        dtimeFERIADO = Convert.ToDateTime(dtsFERIADOS.Tables(0).Rows(intC2).Item("data"))
                        If dtimeFERIADO = dtimeDATA Then
                            bolFERIADO = True
                            Exit For
                        End If
                    Next
                    If bolFERIADO = False Then
                        If dtimeDATA.DayOfWeek.ToString <> "Saturday" And dtimeDATA.DayOfWeek.ToString <> "Sunday" Then
                            intDIASUTEIS += 1
                        End If
                    Else
                        bolFERIADO = False
                    End If
                Next
            Else
                intDIASUTEIS = 0
            End If
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETDIASUTEIS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "EDITAR PARADA"
    Public Function ReadDBGETMOTIVOSNIVEL2PARADA(ByVal intIDNIVEL1 As Integer,
                                                 ByRef cbNIVEL2 As ComboBox,
                                                 ByRef cbNIVEL2ID As ComboBox,
                                                 ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intIDNIVEL1 & " ORDER BY [descricao] ASC"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    cbNIVEL2.Items.Add(dtDevices.Tables(0).Rows(intC).Item("descricao"))
                    cbNIVEL2ID.Items.Add(dtDevices.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL2PARADA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSNIVEL3PARADA(ByVal intIDNIVEL2 As Integer,
                                                 ByRef cbNIVEL3 As ComboBox,
                                                 ByRef cbNIVEL3ID As ComboBox,
                                                 ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intIDNIVEL2 & " ORDER BY [descricao] ASC"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    cbNIVEL3.Items.Add(dtDevices.Tables(0).Rows(intC).Item("descricao"))
                    cbNIVEL3ID.Items.Add(dtDevices.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOSNIVEL3PARADA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEPARADA(ByVal intPARADAID As Integer,
                                        ByVal strDATAINICIAL As String,
                                        ByVal strHoraINICIAL As String,
                                        ByVal strDATAFINAL As String,
                                        ByVal strHORAFINAL As String,
                                        ByVal strNIVEL1 As String,
                                        ByVal strNIVEL2 As String,
                                        ByVal strNIVEL3 As String,
                                        ByVal strNIVEL1ID As String,
                                        ByVal strNIVEL2ID As String,
                                        ByVal strNIVEL3ID As String,
                                        ByVal intOPERADORID As Integer,
                                        ByVal strCOMENTARIOS As String,
                                        ByRef strERROR As String)

        Dim cmdAdd As New SqlCommand
        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim strQUERY As String = Nothing
        Dim strDATAON As String = Nothing
        Dim strDATAOFF As String = Nothing
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            strDATAON = strDATAINICIAL & " " & strHoraINICIAL
            strDATAOFF = strDATAFINAL & " " & strHORAFINAL
            If strNIVEL2ID = Nothing And strNIVEL3ID = Nothing Then
                strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [DateTimeOn] =  convert(smalldatetime, '" & strDATAON & "',103), " &
                           " [DateTimeOff] = convert(smalldatetime, '" & strDATAOFF & "',103), [MotivoId] = " & strNIVEL1ID & ", " &
                           " [Motivo] = '" & strNIVEL1 & "', [motivonivel2] = NULL, [MotivoN2] = NULL, [motivonivel3] = NULL " &
                           ", [MotivoN3] = NULL, [UserId] = " & intOPERADORID & ", [Comentarios] = '" &
                           strCOMENTARIOS & "' WHERE [Id] = " & intPARADAID

            ElseIf strNIVEL2ID <> Nothing And strNIVEL3ID = Nothing Then
                strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [DateTimeOn] =  convert(smalldatetime, '" & strDATAON & "',103), " &
                           " [DateTimeOff] = convert(smalldatetime, '" & strDATAOFF & "',103), [MotivoId] = " & strNIVEL1ID & ", " &
                           " [Motivo] = '" & strNIVEL1 & "', [motivonivel2] = " & strNIVEL2ID & ", [MotivoN2] = '" & strNIVEL2 & "', [motivonivel3] = NULL " &
                           ", [MotivoN3] = NULL, [UserId] = " & intOPERADORID & ", [Comentarios] = '" &
                           strCOMENTARIOS & "' WHERE [Id] = " & intPARADAID

            ElseIf strNIVEL2ID <> Nothing And strNIVEL3ID <> Nothing Then
                strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_HistoricoParadas] SET [DateTimeOn] =  convert(smalldatetime, '" & strDATAON & "',103), " &
                           " [DateTimeOff] = convert(smalldatetime, '" & strDATAOFF & "',103), [MotivoId] = " & strNIVEL1ID & ", " &
                           " [Motivo] = '" & strNIVEL1 & "', [motivonivel2] = " & strNIVEL2ID & ", [MotivoN2] = '" & strNIVEL2 & "', [motivonivel3] = " &
                            strNIVEL3ID & ", [MotivoN3] = '" & strNIVEL3 & "', [UserId] = " & intOPERADORID & ", [Comentarios] = '" &
                            strCOMENTARIOS & "' WHERE [Id] = " & intPARADAID
            End If
            cmdAdd.CommandText = strQUERY
            cmdAdd.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>clsoVDBASQL.WriteDBUPDATEPARADA!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSPARADA(ByVal intPARADAID As Integer,
                                          ByRef cbNIVEL1 As ComboBox,
                                          ByRef cbNIVEL1ID As ComboBox,
                                          ByRef cbNIVEL2 As ComboBox,
                                          ByRef cbNIVEL2ID As ComboBox,
                                          ByRef cbNIVEL3 As ComboBox,
                                          ByRef cbNIVEL3ID As ComboBox,
                                          ByRef cbOPERADOR As ComboBox,
                                          ByRef cbOPERADORID As ComboBox,
                                          ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim dtsPARADA As New DataSet
        Dim intMACHINEID As Integer = 0
        Dim sqlaOPERADOR As SqlDataAdapter
        Dim dtsOPERADOR As DataSet
        Dim sqlaNIVEL1 As SqlDataAdapter
        Dim sqlaNIVEL2 As SqlDataAdapter
        Dim sqlaNIVEL3 As SqlDataAdapter
        Dim dtsNIVEL1 As DataSet
        Dim dtsNIVEL2 As DataSet
        Dim dtsNIVEL3 As DataSet
        Dim strQUERY As String = Nothing
        Dim intOPERADOR As Integer = -1
        Dim intMOTIVONIVEL1 As Integer = -1
        Dim intMOTIVONIVEL2 As Integer = -1
        Dim intMOTIVONIVEL3 As Integer = -1
        Dim intCOUNTN3 As Integer = 0

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [Id] = " & intPARADAID
            Dim sqlaMACHINE As New SqlDataAdapter(strCommand, conSQL)
            sqlaMACHINE.Fill(dtsPARADA, "Maquina")
            intMACHINEID = dtsPARADA.Tables(0).Rows(0).Item("MachineId")
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores]"
            sqlaOPERADOR = New SqlDataAdapter(strQUERY, conSQL)
            dtsOPERADOR = New DataSet
            sqlaOPERADOR.Fill(dtsOPERADOR, "Operador")
            For intC = 0 To dtsOPERADOR.Tables(0).Rows.Count - 1
                cbOPERADOR.Items.Add(dtsOPERADOR.Tables(0).Rows(intC).Item("Nome"))
                cbOPERADORID.Items.Add(dtsOPERADOR.Tables(0).Rows(intC).Item("id"))
            Next
            For intC = 0 To cbOPERADORID.Items.Count - 1
                If IsDBNull(dtsPARADA.Tables(0).Rows(0).Item("UserId")) = False Then
                    If dtsPARADA.Tables(0).Rows(0).Item("UserId") = cbOPERADORID.Items(intC) Then
                        cbOPERADOR.SelectedIndex = intC
                        Exit For
                    End If
                End If
            Next
            cbNIVEL1.Items.Clear()
            cbNIVEL1ID.Items.Clear()
            cbNIVEL2.Items.Clear()
            cbNIVEL2ID.Items.Clear()
            cbNIVEL3.Items.Clear()
            cbNIVEL3ID.Items.Clear()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1]"
            sqlaNIVEL1 = New SqlDataAdapter(strQUERY, conSQL)
            dtsNIVEL1 = New DataSet
            sqlaNIVEL1.Fill(dtsNIVEL1, "Nivel1")
            If dtsNIVEL1.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsNIVEL1.Tables(0).Rows.Count - 1
                    cbNIVEL1.Items.Add(dtsNIVEL1.Tables(0).Rows(intC).Item("Descricao"))
                    cbNIVEL1ID.Items.Add(dtsNIVEL1.Tables(0).Rows(intC).Item("id"))
                Next
                If IsDBNull(dtsPARADA.Tables(0).Rows(0).Item("MotivoId")) = False Then
                    For intC = 0 To cbNIVEL1ID.Items.Count - 1
                        If cbNIVEL1ID.Items(intC) = dtsPARADA.Tables(0).Rows(0).Item("MotivoId") Then
                            cbNIVEL1ID.SelectedIndex = intC
                            intMOTIVONIVEL1 = cbNIVEL1ID.Items(intC)
                            Exit For
                        End If
                    Next
                End If
                If intMOTIVONIVEL1 > 0 Then
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel2] WHERE [idnivel1] = " & intMOTIVONIVEL1
                    sqlaNIVEL2 = New SqlDataAdapter(strQUERY, conSQL)
                    dtsNIVEL2 = New DataSet
                    sqlaNIVEL2.Fill(dtsNIVEL2, "Nivel2")
                    If dtsNIVEL2.Tables(0).Rows.Count > 0 Then
                        For intC2 = 0 To dtsNIVEL2.Tables(0).Rows.Count - 1
                            cbNIVEL2.Items.Add(dtsNIVEL2.Tables(0).Rows(intC2).Item("descricao"))
                            cbNIVEL2ID.Items.Add(dtsNIVEL2.Tables(0).Rows(intC2).Item("id"))
                        Next
                        If IsDBNull(dtsPARADA.Tables(0).Rows(0).Item("motivonivel2")) = False Then
                            For intC = 0 To cbNIVEL2ID.Items.Count - 1
                                If cbNIVEL2ID.Items(intC) = dtsPARADA.Tables(0).Rows(0).Item("motivonivel2") Then
                                    cbNIVEL2ID.SelectedIndex = intC
                                    intMOTIVONIVEL2 = cbNIVEL2ID.Items(intC)
                                    Exit For
                                End If
                            Next
                        End If
                        If intMOTIVONIVEL2 > 0 Then
                            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel3] WHERE [idnivel2] = " & intMOTIVONIVEL2
                            sqlaNIVEL3 = New SqlDataAdapter(strQUERY, conSQL)
                            dtsNIVEL3 = New DataSet
                            sqlaNIVEL3.Fill(dtsNIVEL3, "Nivel3")
                            If dtsNIVEL3.Tables(0).Rows.Count > 0 Then
                                For intC3 = 0 To dtsNIVEL3.Tables(0).Rows.Count - 1
                                    cbNIVEL3.Items.Add(dtsNIVEL3.Tables(0).Rows(intC3).Item("descricao"))
                                    cbNIVEL3ID.Items.Add(dtsNIVEL3.Tables(0).Rows(intC3).Item("id"))
                                Next
                            End If
                            If IsDBNull(dtsPARADA.Tables(0).Rows(0).Item("motivonivel3")) = False Then
                                For intC = 0 To cbNIVEL3ID.Items.Count - 1
                                    If cbNIVEL3ID.Items(intC) = dtsPARADA.Tables(0).Rows(0).Item("motivonivel3") Then
                                        cbNIVEL3ID.SelectedIndex = intC
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If

            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMOTIVOSPARADANEW(ByRef cbNIVEL1 As ComboBox,
                                              ByRef cbNIVEL1ID As ComboBox,
                                              ByRef cbOPERADOR As ComboBox,
                                              ByRef cbOPERADORID As ComboBox,
                                              ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim dtsPARADA As New DataSet
        Dim intMACHINEID As Integer = 0
        Dim sqlaOPERADOR As SqlDataAdapter
        Dim dtsOPERADOR As DataSet
        Dim sqlaNIVEL1 As SqlDataAdapter
        Dim dtsNIVEL1 As DataSet
        Dim strQUERY As String = Nothing
        Dim intOPERADOR As Integer = -1

        Try


            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores]"
            sqlaOPERADOR = New SqlDataAdapter(strQUERY, conSQL)
            dtsOPERADOR = New DataSet
            sqlaOPERADOR.Fill(dtsOPERADOR, "Operador")
            For intC = 0 To dtsOPERADOR.Tables(0).Rows.Count - 1
                cbOPERADOR.Items.Add(dtsOPERADOR.Tables(0).Rows(intC).Item("Nome"))
                cbOPERADORID.Items.Add(dtsOPERADOR.Tables(0).Rows(intC).Item("id"))
            Next
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_motivosnivel1]"
            sqlaNIVEL1 = New SqlDataAdapter(strQUERY, conSQL)
            dtsNIVEL1 = New DataSet
            sqlaNIVEL1.Fill(dtsNIVEL1, "Nivel1")
            If dtsNIVEL1.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsNIVEL1.Tables(0).Rows.Count - 1
                    cbNIVEL1.Items.Add(dtsNIVEL1.Tables(0).Rows(intC).Item("Descricao"))
                    cbNIVEL1ID.Items.Add(dtsNIVEL1.Tables(0).Rows(intC).Item("id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMOTIVOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBADDPARADA(ByVal intMACHINEID As Integer,
                                     ByVal strDATAINICIAL As String,
                                     ByVal strHoraINICIAL As String,
                                     ByVal strDATAFINAL As String,
                                     ByVal strHORAFINAL As String,
                                     ByVal strNIVEL1 As String,
                                     ByVal strNIVEL2 As String,
                                     ByVal strNIVEL3 As String,
                                     ByVal strNIVEL1ID As String,
                                     ByVal strNIVEL2ID As String,
                                     ByVal strNIVEL3ID As String,
                                     ByVal intOPERADORID As Integer,
                                     ByVal strCOMENTARIOS As String,
                                     ByRef strERROR As String)

        Dim cmdAdd As New SqlCommand
        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim strQUERY As String = Nothing
        Dim strDATAON As String = Nothing
        Dim strDATAOFF As String = Nothing
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            strDATAON = strDATAINICIAL & " " & strHoraINICIAL & ":00"
            strDATAOFF = strDATAFINAL & " " & strHORAFINAL & ":00"
            If strNIVEL2ID = Nothing And strNIVEL3ID = Nothing Then
                strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_HistoricoParadas] ([MachineId],[DateTimeOn],[DateTimeOff],[MotivoId],[Motivo],[UserId],[Comentarios]) VALUES (" & intMACHINEID &
                           ", convert(smalldatetime, '" & strDATAON & "',103), convert(smalldatetime, '" & strDATAOFF & "',103), " & strNIVEL1ID & ", '" &
                           strNIVEL1 & "', " & intOPERADORID & ", '" & strCOMENTARIOS & "')"

            ElseIf strNIVEL2ID <> Nothing And strNIVEL3ID = Nothing Then
                strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_HistoricoParadas] ([MachineId],[DateTimeOn],[DateTimeOff],[MotivoId],[Motivo],[motivonivel2]," &
                           "[MotivoN2],[UserId],[Comentarios]) VALUES (" & intMACHINEID & ", convert(smalldatetime, '" & strDATAON & "',103), convert(smalldatetime, '" & strDATAOFF & "',103), " & strNIVEL1ID & ", '" &
                           strNIVEL1 & "', " & strNIVEL2ID & ", '" & strNIVEL2 & "', " & intOPERADORID & ", '" & strCOMENTARIOS & "')"

            ElseIf strNIVEL2ID <> Nothing And strNIVEL3ID <> Nothing Then
                strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_HistoricoParadas] ([MachineId],[DateTimeOn],[DateTimeOff],[MotivoId],[Motivo],[motivonivel2]," &
                           "[MotivoN2],[motivonivel3],[MotivoN3],[UserId],[Comentarios]) VALUES (" & intMACHINEID & ", convert(smalldatetime, '" & strDATAON & "',103), convert(smalldatetime, '" & strDATAOFF & "',103), " & strNIVEL1ID & ", '" &
                           strNIVEL1 & "', " & strNIVEL2ID & ", '" & strNIVEL2 & "', " & strNIVEL3ID & ", '" & strNIVEL3 & "', " & intOPERADORID & ", '" & strCOMENTARIOS & "')"
            End If
            cmdAdd.CommandText = strQUERY
            cmdAdd.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>clsoVDBASQL.WriteDBUPDATEPARADA!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEPARADA(ByVal intPARADAID As Integer,
                                        ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [Id] = " & intPARADAID
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>clsoVDBASQL.WriteDBDELETEPARADA!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETTURNOHORARIO(ByVal intTURNOID As Integer,
                                          ByRef dtimeDATA As DevComponents.Editors.DateTimeAdv.DateTimeInput,
                                          ByVal strTIPO As String,
                                          ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtTURNOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM exe_MCONTROL_OEE_turnos WHERE [id] = " & intTURNOID
            Dim sqlaTURNOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaTURNOS.Fill(dtTURNOS, "Turnos")
            If strTIPO = "ini" Then
                dtimeDATA.Value = dtTURNOS.Tables(0).Rows(0).Item("horainicial1")
            Else
                If IsDBNull(dtTURNOS.Tables(0).Rows(0).Item("horainicial2")) = False Then
                    If dtTURNOS.Tables(0).Rows(0).Item("horainicial2") <> Nothing Then
                        dtimeDATA.Value = dtTURNOS.Tables(0).Rows(0).Item("horafinal2")
                    Else
                        dtimeDATA.Value = dtTURNOS.Tables(0).Rows(0).Item("horafinal1")
                    End If
                Else
                    dtimeDATA.Value = dtTURNOS.Tables(0).Rows(0).Item("horafinal1")
                End If
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETTURNOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETOPDATAS(ByVal strOP As String,
                                     ByRef strDATAINICIAL As String,
                                     ByRef strDATAFINAL As String,
                                     ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtOrdem As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_opstatus] WHERE [opnumber] = '" & strOP & "' ORDER BY [datetime] ASC"
            Dim sqlaOrdem As New SqlDataAdapter(strCommand, conSQL)
            sqlaOrdem.Fill(dtOrdem, "Ordem")
            strDATAFINAL = dtOrdem.Tables(0).Rows(dtOrdem.Tables(0).Rows.Count - 1).Item("datetime")
            strDATAINICIAL = dtOrdem.Tables(0).Rows(0).Item("datetime")
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função GetOrdens"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETPARADASBLOQUEAR(ByVal strDataInicial As String,
                                             ByVal strHORAINICIAL As String,
                                             ByVal strDataFinal As String,
                                             ByVal strHORAFINAL As String,
                                             ByVal strMachineId As String,
                                             ByRef dgvPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                             ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet
        Dim dtParadas As New DataSet
        Dim dateIni As DateTime
        Dim dateFim As DateTime
        Dim decTempoParada As Decimal = 0D
        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim sqlaOPERADOR(999) As SqlDataAdapter
        Dim dtsOPERADOR(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim intTEMPOTOTALPARADA As Integer = 0
        Dim dtimeREGISTROBLOQUEIO As DateTime = Nothing
        Dim dtimePARADA As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strNEWDATAINICIAL = strDataInicial & " " & strHORAINICIAL
            strNEWDATAFINAL = strDataFinal & " " & strHORAFINAL
            strCommand = "Select * FROM [dbo].[exe_MCONTROL_OEE_HistoricoParadas] WHERE [DateTimeOn] >= @DI AND [DateTimeOff] IS NOT NULL AND [DateTimeOff] <= @DF AND [MachineId] = " &
                         strMachineId & " ORDER BY [DateTimeOn] ASC"
            Dim sqlaParadas As New SqlDataAdapter(strCommand, conSQL)
            sqlaParadas.SelectCommand.Parameters.Add(New SqlParameter("DI", Convert.ToDateTime(strNEWDATAINICIAL)))
            sqlaParadas.SelectCommand.Parameters.Add(New SqlParameter("DF", Convert.ToDateTime(strNEWDATAFINAL)))
            sqlaParadas.Fill(dtParadas, "Paradas")
            If dtParadas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtParadas.Tables(0).Rows.Count - 1
                    dgvPARADAS.Rows.Add()
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(0).Value = dtParadas.Tables(0).Rows(intC).Item("Id")
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(1).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"), 1, 10)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(2).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"), 12, 8)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(3).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"), 1, 10)
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(4).Value = Mid(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"), 12, 8)
                    dateIni = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOn"))
                    dateFim = Convert.ToDateTime(dtParadas.Tables(0).Rows(intC).Item("DateTimeOff"))
                    decTempoParada = DateDiff(DateInterval.Second, dateIni, dateFim)
                    intTEMPOTOTALPARADA += DateDiff(DateInterval.Second, dateIni, dateFim)
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
                    dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(5).Value = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("Motivo")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(6).Value = dtParadas.Tables(0).Rows(intC).Item("Motivo")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("MotivoN2")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(7).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoN2")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("MotivoN3")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(8).Value = dtParadas.Tables(0).Rows(intC).Item("MotivoN3")
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("UserId")) = False Then
                        strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Operadores] WHERE [Id] = " & dtParadas.Tables(0).Rows(intC).Item("UserId")
                        sqlaOPERADOR(intC) = New SqlDataAdapter(strQUERY, conSQL)
                        dtsOPERADOR(intC) = New DataSet
                        sqlaOPERADOR(intC).Fill(dtsOPERADOR(intC), "Operador")
                        If dtsOPERADOR(intC).Tables(0).Rows.Count > 0 Then
                            dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(9).Value = dtsOPERADOR(intC).Tables(0).Rows(0).Item("Nome")
                        End If
                    End If
                    If IsDBNull(dtParadas.Tables(0).Rows(intC).Item("Comentarios")) = False Then
                        dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(10).Value = dtParadas.Tables(0).Rows(intC).Item("Comentarios")
                    End If
                Next
            End If
            dgvPARADAS.Rows.Add()
            dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(4).Value = "Total"
            intHORA = Int(intTEMPOTOTALPARADA / 3600)
            decFracionario = (intTEMPOTOTALPARADA / 3600) - intHORA
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
            dgvPARADAS.Rows(dgvPARADAS.Rows.Count - 1).Cells(5).Value = Format(intHORA, "00").ToString & ":" & Format(intMINUTO, "00") & ":" & Format(intSEGUNDO, "00")
            strCommand = "Select * FROM [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio] WHERE [maquinaid] = " & strMachineId
            sqldaBLOQUEIO = New SqlDataAdapter(strCommand, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueios")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                dtimeREGISTROBLOQUEIO = Convert.ToDateTime(dtsBLOQUEIO.Tables(0).Rows(0).Item("data"))
                For intC = 0 To dgvPARADAS.Rows.Count - 2
                    dtimePARADA = Convert.ToDateTime(dgvPARADAS.Rows(intC).Cells(1).Value)
                    If DateDiff(DateInterval.Second, dtimePARADA, dtimeREGISTROBLOQUEIO) >= 0 Then
                        For intC2 = 1 To 10
                            dgvPARADAS.Rows(intC).Cells(intC2).Style.BackColor = Color.Yellow
                        Next
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETPARADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBBLOQUEARPARADA(ByVal intMAQUINAID As Integer,
                                          ByVal strDATA As String,
                                          ByRef strERROR As String)

        Dim cmdAdd As New SqlCommand
        Dim strConn As String
        Dim strQUERY As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio] WHERE [maquinaid] = " & intMAQUINAID
            sqldaBLOQUEIO = New SqlDataAdapter(strQUERY, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueio")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio] SET [data] = convert(datetime, '" & strDATA & "',103) WHERE [maquinaid] = " & intMAQUINAID
            Else
                strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio] ([maquinaid],[data]) VALUES (" & intMAQUINAID & ", convert(datetime, '" & strDATA & "',103))"
            End If
            cmdAdd.CommandText = strQUERY
            cmdAdd.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>clsoVDBASQL.WriteDBBLOQUEARPARADA!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBBLOQUEARTEMPOCALENDARIO(ByVal intMAQUINAID As Integer,
                                                   ByVal strDATA As String,
                                                   ByRef strERROR As String)

        Dim cmdAdd As New SqlCommand
        Dim strConn As String
        Dim strQUERY As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdAdd.Connection = conSQL
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] WHERE [maquinaid] = " & intMAQUINAID
            sqldaBLOQUEIO = New SqlDataAdapter(strQUERY, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueio")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] SET [datetime] = convert(datetime, '" & strDATA & "',103) WHERE [maquinaid] = " & intMAQUINAID
            Else
                strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_tempocalendario_bloqueio] ([maquinaid],[datetime]) VALUES (" & intMAQUINAID & ", convert(datetime, '" & strDATA & "',103))"
            End If
            cmdAdd.CommandText = strQUERY
            cmdAdd.ExecuteNonQuery()
            conSQL.Close()
            If WriteDBBLOQUEARPARADA(intMAQUINAID, strDATA, strERROR) = False Then
                Return False
            End If
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função <b>clsoVDBASQL.WriteDBBLOQUEARTEMPOCALENDARIO!</b>"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadBDGETPARADASBLOQUEADAS(ByVal intMAQUINAID As Integer,
                                               ByRef dgvPARADAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                               ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim sqldaBLOQUEIO As SqlDataAdapter
        Dim dtsBLOQUEIO As DataSet
        Dim dtParadas As New DataSet
        Dim decTempoParada As Decimal = 0D
        Dim intHORA As Integer = 0
        Dim intMINUTO As Integer = 0
        Dim intSEGUNDO As Integer = 0
        Dim decFracionario As Decimal = 0D
        Dim sqlaOPERADOR(999) As SqlDataAdapter
        Dim dtsOPERADOR(999) As DataSet
        Dim strQUERY As String = Nothing
        Dim dateDATAFINAL As Date = Nothing
        Dim strNEWDATAINICIAL As String = Nothing
        Dim strNEWDATAFINAL As String = Nothing
        Dim intTEMPOTOTALPARADA As Integer = 0
        Dim dtimeREGISTROBLOQUEIO As DateTime = Nothing
        Dim dtimePARADA As DateTime = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "Select * FROM [dbo].[exe_MCONTROL_OEE_historicoparadas_bloqueio]"
            sqldaBLOQUEIO = New SqlDataAdapter(strCommand, conSQL)
            dtsBLOQUEIO = New DataSet
            sqldaBLOQUEIO.Fill(dtsBLOQUEIO, "Bloqueios")
            If dtsBLOQUEIO.Tables(0).Rows.Count > 0 Then
                dtimeREGISTROBLOQUEIO = Convert.ToDateTime(dtsBLOQUEIO.Tables(0).Rows(0).Item("data"))
                For intC = 0 To dgvPARADAS.Rows.Count - 2
                    dtimePARADA = Convert.ToDateTime(dgvPARADAS.Rows(intC).Cells(1).Value)
                    If DateDiff(DateInterval.Second, dtimePARADA, dtimeREGISTROBLOQUEIO) >= 0 Then
                        For intC2 = 1 To 10
                            dgvPARADAS.Rows(intC).Cells(intC2).Style.BackColor = Color.Yellow
                        Next
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadBDGETPARADASBLOQUEADAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "FERIADOS"
    Public Function ReadDBGETFERIADOS(ByRef dgvFERIADOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                      ByRef strERROR As String)


        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtFERIADOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [data] ASC"
            Dim sqlaFERIADOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaFERIADOS.Fill(dtFERIADOS, "Feriados")
            If dtFERIADOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtFERIADOS.Tables(0).Rows.Count - 1
                    dgvFERIADOS.Rows.Add()
                    dgvFERIADOS.Rows(dgvFERIADOS.Rows.Count - 1).Cells(0).Value = dtFERIADOS.Tables(0).Rows(intC).Item("Id")
                    dgvFERIADOS.Rows(dgvFERIADOS.Rows.Count - 1).Cells(1).Value = dtFERIADOS.Tables(0).Rows(intC).Item("feriado")
                    dgvFERIADOS.Rows(dgvFERIADOS.Rows.Count - 1).Cells(2).Value = dtFERIADOS.Tables(0).Rows(intC).Item("data")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETFERIADOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEFERIADOS(ByVal dgvFERIADOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                          ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim strB1 As String = Nothing
        Dim sqldaFERIADOS As SqlDataAdapter
        Dim dtsFERIADOS As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvFERIADOS.Rows.Count - 1

                If dgvFERIADOS.Rows(intC).Cells(3).Value = True Then
                    strP1 = "INSERT INTO [dbo].[exe_MCONTROL_OEE_feriados] ([feriado],[data]) VALUES ('" & dgvFERIADOS.Rows(intC).Cells(1).Value &
                            "', convert(datetime, '" & dgvFERIADOS.Rows(intC).Cells(2).Value & "',103))"
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_feriados] ORDER BY [Id] DESC"
                    sqldaFERIADOS = New SqlDataAdapter(strQUERY, conSQL)
                    dtsFERIADOS = New DataSet
                    sqldaFERIADOS.Fill(dtsFERIADOS, "Feriados")
                    dgvFERIADOS.Rows(intC).Cells(0).Value = dtsFERIADOS.Tables(0).Rows(0).Item("id")
                    dgvFERIADOS.Rows(intC).Cells(3).Value = False

                ElseIf dgvFERIADOS.Rows(intC).Cells(4).Value = True Then
                    strP1 = "UPDATE [dbo].[exe_MCONTROL_OEE_feriados] SET [feriado] = '" & dgvFERIADOS.Rows(intC).Cells(1).Value & "', " &
                            "[data] = convert(datetime, '" & dgvFERIADOS.Rows(intC).Cells(2).Value & "',103) WHERE [Id] = " &
                            dgvFERIADOS.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strP1
                    cmdUpdate.ExecuteNonQuery()
                    dgvFERIADOS.Rows(intC).Cells(4).Value = False
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBUPDATEFERIADOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEFERIADO(ByVal intFERIADOID As Integer,
                                         ByRef strERROR As String)

        Dim cmdUpdate As New SqlCommand
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
            strP1 = "DELETE FROM [dbo].[exe_MCONTROL_OEE_feriados] WHERE [id] = " & intFERIADOID
            cmdUpdate.CommandText = strP1
            cmdUpdate.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEFERIADO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMAQUINAS(ByRef cbiMAQUINA As DevComponents.DotNetBar.ComboBoxItem,
                                      ByRef cbiMAQUINAID As DevComponents.DotNetBar.ComboBoxItem,
                                      ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] ORDER BY [Descricao] ASC"
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtMaquinas.Tables(0).Rows.Count - 1
                    cbiMAQUINA.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Descricao"))
                    cbiMAQUINAID.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Id"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMAQUINAS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "ON-LINE"
    Public Function ReadDBONLINE(ByRef intFORMS As Integer,
                                 ByVal bolMDIPARENT As Boolean,
                                 ByRef strERROR As String)

        Dim frmONLINE As frm_ONLINE
        Dim strConn As String = Nothing
        Dim dtMAQUINAS As New DataSet
        Dim conSQL As SqlConnection
        Dim strCommand As String = "SELECT exe_MCONTROL_OEE_Maquinas.Descricao, exe_MCONTROL_BABELFISH_idreferences.babelfish_id " &
                                    "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_Devices ON exe_MCONTROL_OEE_Maquinas.Id = " &'
                                    "exe_MCONTROL_OEE_Devices.Machine INNER JOIN exe_MCONTROL_BABELFISH_idreferences ON " &
                                    "exe_MCONTROL_OEE_Devices.DeviceId = exe_MCONTROL_BABELFISH_idreferences.device_id " &
                                    "INNER JOIN exe_MCONTROL_OEE_useronline ON exe_MCONTROL_BABELFISH_idreferences.device_id = exe_MCONTROL_OEE_useronline.deviceid WHERE " &
                                    "exe_MCONTROL_OEE_Maquinas.Ativo = 1 AND exe_MCONTROL_OEE_useronline.userid = " & intUSERID & " ORDER BY [Descricao] DESC"

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            Dim sqlaMAQUINAS As New SqlDataAdapter(strCommand, conSQL)
            sqlaMAQUINAS.Fill(dtMAQUINAS, "Maquinas")
            If dtMAQUINAS.Tables(0).Rows.Count > 0 Then
                intFORMS = dtMAQUINAS.Tables(0).Rows.Count
                For intC = 0 To dtMAQUINAS.Tables(0).Rows.Count - 1
                    frmONLINE = New frm_ONLINE
                    intMACHINEID = dtMAQUINAS.Tables(0).Rows(intC).Item("babelfish_id")
                    If bolMDIPARENT = False Then
                        frmONLINE.MdiParent = frm_MAIN
                    End If
                    frmONLINE.Show()
                Next
            Else

            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBONLINE"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMAQUINASONLINE(ByRef advTree As DevComponents.AdvTree.AdvTree,
                                            ByRef intDEVICES As Integer,
                                            ByRef strErro As String)

        Dim strNodeP As String = Nothing
        Dim strNodeS As String = Nothing
        Dim strNodeCU As String = Nothing
        Dim sqlaNodeP As SqlDataAdapter
        Dim sqlaNodeS As SqlDataAdapter
        Dim dtNodeP As New DataSet
        Dim dtNodeS As New DataSet
        Dim dtNodeCU As New DataSet
        Dim advTreeNode(999) As DevComponents.AdvTree.Node
        Dim strConn As String = Nothing
        Dim arrNodeD As Array
        Dim strP As String = Nothing
        Dim strS As String = Nothing
        Dim strD As String = Nothing
        Dim intNode As Integer = 0
        Dim intNodeP As Integer = 0
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim sqldaDEVICES As SqlDataAdapter
        Dim dtsDEVICES As DataSet
        Dim strDevices(999, 9) As String
        Dim arrNodeP As Array
        Dim arrNodeS As Array

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            strQUERY = "SELECT * FROM [dbo].[cfg_deviceList] ORDER BY [ReferenceName] ASC"
            sqldaDEVICES = New SqlDataAdapter(strQUERY, conSQL)
            dtsDEVICES = New DataSet
            sqldaDEVICES.Fill(dtsDEVICES, "Devices")

            'Coloca os Devices
            '/////////////////
            If dtsDEVICES.Tables(0).Rows.Count > 0 Then
                intDevices = dtsDEVICES.Tables(0).Rows.Count
                For intC = 0 To dtsDEVICES.Tables(0).Rows.Count - 1
                    strDevices(intC, 0) = dtsDEVICES.Tables(0).Rows(intC).Item("Id")
                    strDevices(intC, 1) = dtsDEVICES.Tables(0).Rows(intC).Item("CodeId")
                    strDevices(intC, 2) = dtsDEVICES.Tables(0).Rows(intC).Item("ReferenceName")
                    strDevices(intC, 3) = dtsDEVICES.Tables(0).Rows(intC).Item("DeviceFullName")
                    strDevices(intC, 4) = dtsDEVICES.Tables(0).Rows(intC).Item("InstallTag")
                Next
            End If

            strNodeP = "SELECT * FROM [dbo].[cfg_installation] WHERE [Tag] LIKE '%P%'"
            sqlaNodeP = New SqlDataAdapter(strNodeP, conSQL)
            sqlaNodeP.Fill(dtNodeP, "NodeP")

            strNodeS = "SELECT * FROM [dbo].[cfg_installation] WHERE [Tag] LIKE '%S%'"
            sqlaNodeS = New SqlDataAdapter(strNodeS, conSQL)
            sqlaNodeS.Fill(dtNodeS, "NodeS")

            'Coloca o Projeto
            '////////////////
            For intC = 0 To dtNodeP.Tables(0).Rows.Count - 1
                advTreeNode(intNode) = New DevComponents.AdvTree.Node
                advTreeNode(intNode).Text = dtNodeP.Tables(0).Rows(intC).Item("Name")
                advTreeNode(intNode).Tag = dtNodeP.Tables(0).Rows(intC).Item("Tag")
                advTreeNode(intNode).Selectable = False
                advTree.Nodes.Add(advTreeNode(intNode))
                intNode += 1
            Next

            'Coloca os Sites
            '///////////////
            For intC = 0 To dtNodeS.Tables(0).Rows.Count - 1
                For intC2 = 0 To advTree.Nodes.Count - 1
                    arrNodeP = Split(advTree.Nodes(intC2).Tag, ".")
                    arrNodeS = Split(dtNodeS.Tables(0).Rows(intC).Item("Tag"), ".")
                    strP = Mid(arrNodeP(0).ToString, 2, arrNodeP(0).ToString.Length)
                    strS = Mid(arrNodeS(0).ToString, 2, arrNodeS(0).ToString.Length)
                    If strP = strS Then
                        advTreeNode(intNode) = New DevComponents.AdvTree.Node
                        advTreeNode(intNode).Text = dtNodeS.Tables(0).Rows(intC).Item("Name")
                        advTreeNode(intNode).Tag = dtNodeS.Tables(0).Rows(intC).Item("Tag")
                        advTree.Nodes(intC2).Nodes.Add(advTreeNode(intNode))
                        intNode += 1
                    End If
                Next
            Next


            'Coloca os Devices
            '/////////////////
            For intC = 0 To intDEVICES - 1
                If strDevices(intC, 0) <> Nothing Then
                    arrNodeD = Split(strDevices(intC, 4), ".")
                    If arrNodeD.Length = 1 Then
                        strD = Mid(arrNodeD(0).ToString, 2, arrNodeD(0).ToString.Length)
                        For intC2 = 0 To advTree.Nodes.Count - 1
                            strP = Mid(advTree.Nodes(intC2).Tag.ToString, 2, advTree.Nodes(intC2).Tag.ToString.Length)
                            If strP = strD Then
                                advTreeNode(intC) = New DevComponents.AdvTree.Node
                                advTreeNode(intC).Tag = "D" & strDevices(intC, 0)
                                advTreeNode(intC).Text = strDevices(intC, 2) & " - " & strDevices(intC, 3) & " (*)"
                                advTreeNode(intC).CheckBoxVisible = True
                                advTree.Nodes(intC2).Nodes.Add(advTreeNode(intC))
                            End If
                        Next
                    Else
                        strD = Mid(arrNodeD(0).ToString, 2, arrNodeD(0).ToString.Length) & "." & arrNodeD(1).ToString
                        For intC2 = 0 To advTree.Nodes.Count - 1
                            For intC3 = 0 To advTree.Nodes(intC2).Nodes.Count - 1
                                If Mid(advTree.Nodes(intC2).Nodes(intC3).Tag, 1, 1) <> "D" Then
                                    arrNodeS = Split(advTree.Nodes(intC2).Nodes(intC3).Tag, ".")
                                    strS = Mid(arrNodeS(0).ToString, 2, arrNodeD(0).ToString.Length) & "." & arrNodeS(1).ToString
                                    If strS = strD Then
                                        advTreeNode(intC) = New DevComponents.AdvTree.Node
                                        advTreeNode(intC).Text = strDevices(intC, 2) & " - " & strDevices(intC, 3)
                                        advTreeNode(intC).Tag = "D" & strDevices(intC, 0)
                                        advTreeNode(intC).CheckBoxVisible = True
                                        advTree.Nodes(intC2).Nodes(intC3).Nodes.Add(advTreeNode(intC))
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Next

            'Verifica se algum site ficou sem dispositivos e esconde para não poluir a visualização
            '///////////////////////////////////////////////////////////////////////////////////////

            For intC = 0 To advTree.Nodes.Count - 1
                If advTree.Nodes(intC).HasChildNodes = False Then
                    advTree.Nodes(intC).Visible = False
                End If
            Next

            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMAQUINASONLINE"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETUSERONLINE(ByRef advTree As DevComponents.AdvTree.AdvTree,
                                        ByRef intUSERID As Integer,
                                        ByRef strErro As String)

        Dim strConn As String = Nothing
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim sqldaDEVICES As SqlDataAdapter
        Dim dtsDEVICES As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()

            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_useronline] WHERE [userid] = " & intUSERID
            sqldaDEVICES = New SqlDataAdapter(strQUERY, conSQL)
            dtsDEVICES = New DataSet
            sqldaDEVICES.Fill(dtsDEVICES, "Devices")
            If dtsDEVICES.Tables(0).Rows.Count > 0 Then
                For intC = 0 To advTree.Nodes.Count - 1
                    For intC2 = 0 To advTree.Nodes(intC).Nodes.Count - 1
                        For intC3 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                            For intC4 = 0 To dtsDEVICES.Tables(0).Rows.Count - 1
                                If Mid(advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Tag, 2, advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Tag.ToString.Length) = dtsDEVICES.Tables(0).Rows(intC4).Item("deviceid") Then
                                    advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = True
                                End If

                            Next
                        Next
                    Next
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETUSERONLINE"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBSAVEUSERONLINE(ByRef advTree As DevComponents.AdvTree.AdvTree,
                                          ByRef intUSERID As Integer,
                                          ByRef strErro As String)

        Dim strConn As String = Nothing
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim sqlcmdONLINE As New SqlCommand

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdONLINE.Connection = conSQL
            sqlcmdONLINE.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_useronline] WHERE [userid] = " & intUSERID
            sqlcmdONLINE.ExecuteNonQuery()
            For intC = 0 To advTree.Nodes.Count - 1
                For intC2 = 0 To advTree.Nodes(intC).Nodes.Count - 1
                    For intC3 = 0 To advTree.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                        If advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = True Then
                            sqlcmdONLINE.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_useronline] ([userid],[deviceid]) VALUES (" & intUSERID & ", " &
                                                        Mid(advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).Tag, 2, advTree.Nodes(intC).Nodes(intC2).Nodes(intC3).ToString.Length) & ")"
                            sqlcmdONLINE.ExecuteNonQuery()
                        End If
                    Next
                Next
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função WriteDBSAVEUSERONLINE"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "GRUPO DE MÁQUINAS"
    Public Function ReadDBGETGRUPOS(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                    ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_gruposdemaquinas] ORDER BY [nome] ASC"
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvGRUPOS.Rows.Add()
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("id")
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("nome")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETGRUPOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHECKUSOGRUPO(ByVal intGRUPOID As Integer,
                                        ByRef bolUSED As Boolean,
                                        ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_maquinas_grupos] WHERE [grupoid] = " & intGRUPOID
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                bolUSED = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKUSOGRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEGRUPO(ByVal intGRUPOID As Integer,
                                       ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_gruposdemaquinas] WHERE [Id] = " & intGRUPOID
            cmdDelete.ExecuteNonQuery()
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_master_grupos] WHERE [Grupoid] = " & intGRUPOID
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEGRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMAQVINCULADAS(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByVal intGRUPOID As Integer,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT exe_MCONTROL_OEE_Maquinas.id as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao " &
                         "FROM exe_MCONTROL_OEE_MAQUINAS INNER JOIN exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_Maquinas.Id = " &
                         "exe_MCONTROL_OEE_maquinas_grupos.maquinaid WHERE exe_MCONTROL_OEE_maquinas_grupos.grupoid = " & intGRUPOID &
                         " ORDER BY [Descricao] ASC"
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvGRUPOS.Rows.Add()
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("Descricao")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETGRUPOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMAQSEMVINCULO(ByRef dgvMAQUINAS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT exe_MCONTROL_OEE_Maquinas.id as maquinaid, exe_MCONTROL_OEE_Maquinas.Descricao, " &
                         "exe_MCONTROL_OEE_maquinas_grupos.grupoid FROM exe_MCONTROL_OEE_MAQUINAS LEFT JOIN " &
                         "exe_MCONTROL_OEE_maquinas_grupos ON exe_MCONTROL_OEE_Maquinas.Id = exe_MCONTROL_OEE_maquinas_grupos.maquinaid " &
                         "WHERE exe_MCONTROL_OEE_maquinas_grupos.grupoid IS NULL"
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvMAQUINAS.Rows.Add()
                    dgvMAQUINAS.Rows(dgvMAQUINAS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("maquinaid")
                    dgvMAQUINAS.Rows(dgvMAQUINAS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("Descricao")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETMAQSEMVINCULO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBVINCULARMAQUINA(ByVal intGRUPOID As Integer,
                                           ByVal intMAQUINAID As Integer,
                                           ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_maquinas_grupos] ([maquinaid],[grupoid]) VALUES (" &
                                    intMAQUINAID & ", " & intGRUPOID & ")"
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBVINCULARMAQUINA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDESVINCULARMAQUINA(ByVal intGRUPOID As Integer,
                                              ByVal intMAQUINAID As Integer,
                                              ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_maquinas_grupos] WHERE [maquinaid] = " & intMAQUINAID &
                                    " AND [grupoid] = " & intGRUPOID
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDESVINCULARMAQUINA"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBSAVEGRUPOS(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                      ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaGRUPO As SqlDataAdapter
        Dim dtsGRUPO As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvGRUPOS.Rows.Count - 1

                If dgvGRUPOS.Rows(intC).Cells(2).Value = True Then
                    strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_gruposdemaquinas] ([nome]) VALUES ('" &
                            dgvGRUPOS.Rows(intC).Cells(1).Value & "')"
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_gruposdemaquinas] ORDER BY [Id] DESC"
                    sqldaGRUPO = New SqlDataAdapter(strQUERY, conSQL)
                    dtsGRUPO = New DataSet
                    sqldaGRUPO.Fill(dtsGRUPO, "Grupo")
                    dgvGRUPOS.Rows(intC).Cells(0).Value = dtsGRUPO.Tables(0).Rows(0).Item("Id")
                    dgvGRUPOS.Rows(intC).Cells(2).Value = False

                ElseIf dgvGRUPOS.Rows(intC).Cells(3).Value = True Then
                    strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_gruposdemaquinas] SET [nome] = '" & dgvGRUPOS.Rows(intC).Cells(1).Value & "'" &
                            " WHERE [Id] = " & dgvGRUPOS.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()
                    dgvGRUPOS.Rows(intC).Cells(3).Value = False
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBSAVEGRUPOS"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETGRUPOSMASTER(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                          ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_gruposmaster] ORDER BY [gruponome] ASC"
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvGRUPOS.Rows.Add()
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("id")
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("gruponome")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETGRUPOSMASTER"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETGRUPOSSEMVINCULO(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                              ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.id as grupoid, exe_MCONTROL_OEE_gruposdemaquinas.nome FROM " &
                         "exe_MCONTROL_OEE_gruposdemaquinas LEFT JOIN exe_MCONTROL_OEE_master_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = " &
                         "exe_MCONTROL_OEE_master_grupos.grupoid WHERE exe_MCONTROL_OEE_master_grupos.masterid Is NULL ORDER BY [nome] ASC"
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvGRUPOS.Rows.Add()
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("grupoid")
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("nome")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETGRUPOSSEMVINCULO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETGRUPOSCOMVINCULO(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                              ByVal intGRUPOMASTER As Integer,
                                              ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT exe_MCONTROL_OEE_gruposdemaquinas.id as grupoid, exe_MCONTROL_OEE_gruposdemaquinas.nome FROM exe_MCONTROL_OEE_gruposdemaquinas " &
                         "INNER JOIN exe_MCONTROL_OEE_master_grupos ON exe_MCONTROL_OEE_gruposdemaquinas.id = exe_MCONTROL_OEE_master_grupos.grupoid " &
                         "WHERE exe_MCONTROL_OEE_master_grupos.masterid = " & intGRUPOMASTER
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtsGRUPOS.Tables(0).Rows.Count - 1
                    dgvGRUPOS.Rows.Add()
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(0).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("grupoid")
                    dgvGRUPOS.Rows(dgvGRUPOS.Rows.Count - 1).Cells(1).Value = dtsGRUPOS.Tables(0).Rows(intC).Item("nome")
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBGETGRUPOSCOMVINCULO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBVINCULARGRUPOMASTER(ByVal intGRUPOMASTER As Integer,
                                               ByVal intGRUPO As Integer,
                                               ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_master_grupos] ([masterid],[grupoid]) VALUES (" &
                                    intGRUPOMASTER & ", " & intGRUPO & ")"
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBVINCULARGRUPOMASTER"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try


    End Function
    Public Function WriteDBDESVINCULARGRUPO(ByVal intGRUPOMASTER As Integer,
                                            ByVal intGRUPO As Integer,
                                            ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_master_grupos] WHERE [masterid] = " & intGRUPOMASTER &
                                    " AND [grupoid] = " & intGRUPO
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDESVINCULARGRUPO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBSAVEGRUPOSMASTER(ByRef dgvGRUPOS As DevComponents.DotNetBar.Controls.DataGridViewX,
                                            ByRef strERROR As String)


        Dim cmdUpdate As New SqlCommand
        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaGRUPO As SqlDataAdapter
        Dim dtsGRUPO As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdUpdate.Connection = conSQL
            For intC = 0 To dgvGRUPOS.Rows.Count - 1

                If dgvGRUPOS.Rows(intC).Cells(2).Value = True Then
                    strQUERY = "INSERT INTO [dbo].[exe_MCONTROL_OEE_gruposmaster] ([gruponome]) VALUES ('" &
                               dgvGRUPOS.Rows(intC).Cells(1).Value & "')"
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()
                    strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_gruposmaster] ORDER BY [Id] DESC"
                    sqldaGRUPO = New SqlDataAdapter(strQUERY, conSQL)
                    dtsGRUPO = New DataSet
                    sqldaGRUPO.Fill(dtsGRUPO, "Grupo")
                    dgvGRUPOS.Rows(intC).Cells(0).Value = dtsGRUPO.Tables(0).Rows(0).Item("Id")
                    dgvGRUPOS.Rows(intC).Cells(2).Value = False

                ElseIf dgvGRUPOS.Rows(intC).Cells(3).Value = True Then
                    strQUERY = "UPDATE [dbo].[exe_MCONTROL_OEE_gruposmaster] SET [gruponome] = '" & dgvGRUPOS.Rows(intC).Cells(1).Value & "'" &
                               " WHERE [Id] = " & dgvGRUPOS.Rows(intC).Cells(0).Value
                    cmdUpdate.CommandText = strQUERY
                    cmdUpdate.ExecuteNonQuery()
                    dgvGRUPOS.Rows(intC).Cells(3).Value = False
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBSAVEGRUPOSMASTER"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBCHECKUSOGRUPOMASTER(ByVal intGRUPOID As Integer,
                                              ByRef bolUSED As Boolean,
                                              ByRef strERROR As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtsGRUPOS As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_master_grupos] WHERE [masterid] = " & intGRUPOID
            Dim sqlaGRUPOS As New SqlDataAdapter(strCommand, conSQL)
            sqlaGRUPOS.Fill(dtsGRUPOS, "Grupos")
            If dtsGRUPOS.Tables(0).Rows.Count > 0 Then
                bolUSED = True
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função ReadDBCHECKUSOGRUPOMASTER"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEGRUPOMASTER(ByVal intGRUPOID As Integer,
                                             ByRef strERROR As String)

        Dim cmdDelete As New SqlCommand
        Dim strConn As String
        Dim conSQL As SqlConnection

        Try
            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVViewers;Password=@allexoNew2017"

            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            cmdDelete.Connection = conSQL
            cmdDelete.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_gruposmaster] WHERE [Id] = " & intGRUPOID
            cmdDelete.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBDELETEGRUPOMASTER"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "CADASTRO BABEL"
    Public Function ReadDBGETDEVICES_BABEL(ByRef dgvDevices As DevComponents.DotNetBar.Controls.DataGridViewX,
                                           ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtDevices As New DataSet
        Dim sqldaIDREFERENCES As SqlDataAdapter
        Dim dtsIDREFERENCES As DataSet
        Dim strQUERY As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[cfg_deviceList]"
            Dim sqlaDevices As New SqlDataAdapter(strCommand, conSQL)
            sqlaDevices.Fill(dtDevices, "Devices")
            If dtDevices.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtDevices.Tables(0).Rows.Count - 1
                    dgvDevices.Rows.Add()
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(0).Value = dtDevices.Tables(0).Rows(intC).Item("Id")
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(1).Value = dtDevices.Tables(0).Rows(intC).Item("ReferenceName")
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(2).Value = dtDevices.Tables(0).Rows(intC).Item("DeviceFullName")
                    dgvDevices.Rows(dgvDevices.Rows.Count - 1).Cells(4).Value = dtDevices.Tables(0).Rows(intC).Item("Enabled")
                Next
            End If
            For intC = 0 To dgvDevices.Rows.Count - 1
                strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_idreferences] WHERE [device_id] = " & dgvDevices.Rows(intC).Cells(0).Value
                sqldaIDREFERENCES = New SqlDataAdapter(strQUERY, conSQL)
                dtsIDREFERENCES = New DataSet
                sqldaIDREFERENCES.Fill(dtsIDREFERENCES, "IdReferences")
                If dtsIDREFERENCES.Tables(0).Rows.Count > 0 Then
                    dgvDevices.Rows(intC).Cells(3).Value = dtsIDREFERENCES.Tables(0).Rows(0).Item("babelfish_id")
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função GetDevices"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBUPDATEBABEL(ByVal _intDEVICEID As Integer,
                                       ByVal _strDEVICENAME As String,
                                       ByVal _strSAPID As String,
                                       ByVal _intMAQUINAID As Integer,
                                       ByVal _intTIMEON As Integer,
                                       ByVal _intTIMEOFF As Integer,
                                       ByRef _strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim sqlcmdUPDATE As New SqlCommand

        Try

            strConn = "Data Source=" & strDataSource &
                   ";Initial Catalog=oViewer;" &
                   "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPDATE.Connection = conSQL
            sqlcmdUPDATE.CommandText = "UPDATE [dbo].[exe_MCONTROL_BABELFISH_idreferences] SET [babelfish_id] = " & _strSAPID & " WHERE [device_id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "UPDATE [dbo].[exe_MCONTROL_BABELFISH_babelmachine_reference] SET [babelfish_id] = " & _strSAPID & ", [machineid] = " & _intMAQUINAID & " WHERE [device_id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "UPDATE [dbo].[exe_MCONTROL_OEE_Devices] SET [Machine] = " & _intMAQUINAID & ", [TimetoOn] = " & _intTIMEON &
                                       ", [TimetoOff] = " & _intTIMEOFF & " WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função WriteDBUPDATEBABEL"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETMAQUINA_BABEL(ByRef _cbMAQUINA As ComboBox,
                                           ByRef _cbMAQUINAID As ComboBox,
                                           ByRef strErro As String)

        Dim strCommand As String = Nothing
        Dim strConn As String
        Dim strP1 As String = Nothing
        Dim conSQL As SqlConnection
        Dim dtMaquinas As New DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strCommand = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Maquinas] ORDER BY [Descricao] ASC"
            Dim sqlaMaquinas As New SqlDataAdapter(strCommand, conSQL)
            sqlaMaquinas.Fill(dtMaquinas, "Maquinas")
            If dtMaquinas.Tables(0).Rows.Count > 0 Then
                For intC = 0 To dtMaquinas.Tables(0).Rows.Count - 1
                    _cbMAQUINAID.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Id"))
                    _cbMAQUINA.Items.Add(dtMaquinas.Tables(0).Rows(intC).Item("Descricao"))
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            strErro = "Falha interna da função ReadDBGETMACHINE_BABEL"
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function CheckMAQUINABABEL(ByVal _cbMAQUINAID As ComboBox,
                                      ByRef _cbMAQUINA As ComboBox,
                                      ByVal _intDEVICEID As Integer,
                                      ByRef _strERROR As String)

        Dim strQUERY As String = Nothing
        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqldaMAQUINA_REF As SqlDataAdapter
        Dim dtsMAQUINA_REF As DataSet
        Dim intMAQUINAID As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_BABELFISH_babelmachine_reference] WHERE [device_id] = " & _intDEVICEID
            sqldaMAQUINA_REF = New SqlDataAdapter(strQUERY, conSQL)
            dtsMAQUINA_REF = New DataSet
            sqldaMAQUINA_REF.Fill(dtsMAQUINA_REF, "Maquina")
            If dtsMAQUINA_REF.Tables(0).Rows.Count > 0 Then
                intMAQUINAID = dtsMAQUINA_REF.Tables(0).Rows(0).Item("machineid")
                For intC = 0 To _cbMAQUINAID.Items.Count - 1
                    If _cbMAQUINAID.Items(intC) = intMAQUINAID Then
                        _cbMAQUINA.SelectedIndex = intC
                        Exit For
                    End If
                Next
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função CheckMAQUINABABEL"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBHABDESABBABEL(ByVal _intDEVICEID As Integer,
                                         ByVal _intCOMANDO As Integer,
                                         ByRef _strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdUPDATE As New SqlCommand

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPDATE.Connection = conSQL
            sqlcmdUPDATE.CommandText = "UPDATE [dbo].[cfg_deviceList] SET [Enabled~] = " & _intCOMANDO & " WHERE [Id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função WriteDBHABDESABBABEL"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function ReadDBGETSIGNALS(ByVal _intDEVICEID As Integer,
                                     ByRef _tbON As TextBox,
                                     ByRef _tbOFF As TextBox,
                                     ByRef _strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim strQUERY As String = Nothing
        Dim sqldaSIGNALS As SqlDataAdapter
        Dim dtsSIGNALS As DataSet

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strQUERY = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [DeviceId] = " & _intDEVICEID
            sqldaSIGNALS = New SqlDataAdapter(strQUERY, conSQL)
            dtsSIGNALS = New DataSet
            sqldaSIGNALS.Fill(dtsSIGNALS, "Sinais")
            If dtsSIGNALS.Tables(0).Rows.Count > 0 Then
                _tbON.Text = dtsSIGNALS.Tables(0).Rows(0).Item("TimetoON")
                _tbOFF.Text = dtsSIGNALS.Tables(0).Rows(0).Item("TimetoOff")
            End If
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função ReadDBGETSIGNALS"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBDELETEBABEL(ByVal _intDEVICEID As Integer,
                                       ByRef _strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdUPDATE As New SqlCommand
        Dim strDEVICE As String = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                    ";Initial Catalog=oViewer;" &
                    "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            strDEVICE = _intDEVICEID.ToString("D6")
            sqlcmdUPDATE.Connection = conSQL
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[cfg_deviceList] WHERE [Id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[cfg_deviceControl] WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[cfg_deviceVarListRead] WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[cfg_deviceVarListWrite] WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[cfg_deviceFrmControl] WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_BABELFISH_babelmachine_reference] WHERE [device_id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_Devices] WHERE [DeviceId] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_BABELFISH_idreferences] WHERE [device_id] = " & _intDEVICEID
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DROP TABLE exe_" & strDEVICE & "_dvcData"
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DROP TABLE exe_" & strDEVICE & "_dvcRTData"
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DROP TABLE exe_" & strDEVICE & "_dvcDataHeader"
            sqlcmdUPDATE.ExecuteNonQuery()
            sqlcmdUPDATE.CommandText = "DROP TABLE exe_" & strDEVICE & "_dvcCF"
            sqlcmdUPDATE.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função WriteDBDELETEBABEL"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function
    Public Function WriteDBADDNEWBABEL(ByVal _bolENABLED As Boolean,
                                       ByVal _strDEVICENAME As String,
                                       ByVal _strSAPID As String,
                                       ByVal _intMAQUINAID As Integer,
                                       ByVal _intONTIME As Integer,
                                       ByVal _intOFFTIME As Integer,
                                       ByRef _strERROR As String)

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdUPTADE As New SqlCommand
        Dim strFILE As String = Nothing
        Dim xmlNode As XmlNode
        Dim xmlFile As New XmlDocument
        Dim strENABLED As String = Nothing
        Dim strQUERY As String = Nothing
        Dim sqldaDEVICE As SqlDataAdapter
        Dim dtsDEVICE As DataSet
        Dim strVARLISTREAD(9999, 3) As String
        Dim strVARLISTWRITE(9999) As String
        Dim intCOUNT As Integer = 0
        Dim intCOUNT_WRITE As Integer = 0
        Dim strVARGROUP As String = Nothing
        Dim strVARIABLE(99, 1) As String
        Dim intVARIABLE As Integer = 0
        Dim strP1 As String = Nothing
        Dim strP2 As String = Nothing
        Dim strDEVICETABLE As String = Nothing
        Dim _intDEVICEID As Integer = 0

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPTADE.Connection = conSQL

            strFILE = "oVLib1900.xml"

            'Verifica a existência do arquivo de configuração
            '////////////////////////////////////////////////
            If IO.File.Exists(strXMLDir & "\" & strFILE) = False Then
                _strERROR = "Arquivo <b>" & strFILE & "</b> não encontrado!"
                ErrorLog(_strERROR)
                Exit Function
            End If

            If _bolENABLED = True Then
                strENABLED = "1"
            Else
                strENABLED = "0"
            End If

            sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[cfg_deviceList] ([DeviceFullName],[ReferenceName],[Supplyer],[CodeId],[CodeDriver]," &
                                       "[Enabled],[FixedRegTime],[DeviceTimeStamp],[Lite],[ADataRecovery]) VALUES (" &
                                       "'BABEL FISH 1.0.0', '" & _strDEVICENAME & "', 'BTI', '1900', '1900', " & strENABLED & ", 0, 0, 0, 0)"
            sqlcmdUPTADE.ExecuteNonQuery()

            strQUERY = "SELECT * FROM [dbo].[cfg_deviceList] ORDER BY [Id] DESC"
            sqldaDEVICE = New SqlDataAdapter(strQUERY, conSQL)
            dtsDEVICE = New DataSet
            sqldaDEVICE.Fill(dtsDEVICE, "Device")
            _intDEVICEID = dtsDEVICE.Tables(0).Rows(0).Item("Id")

            sqlcmdUPTADE.CommandText = "UPDATE [dbo].[cfg_deviceList] SET [objectTag] = 'D" & _intDEVICEID & "' WHERE [Id] = " & _intDEVICEID
            sqlcmdUPTADE.ExecuteNonQuery()

            'Variáveis para Leitura
            '//////////////////////
            xmlFile.Load(strXMLDir & "\" & strFILE)
            xmlNode = xmlFile.SelectSingleNode("oVDeviceDescriptor/Variables/VarListRead")
            If xmlNode.ChildNodes.Count > 0 Then
                For intC = 0 To xmlNode.ChildNodes.Count - 1
                    For intC2 = 1 To xmlNode.ChildNodes(intC).ChildNodes.Count - 1

                        sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[cfg_deviceVarListRead] ([DeviceId],[MasterGroup],[VarGroup]) VALUES (" &
                                                   _intDEVICEID & ", '" & xmlNode.ChildNodes(intC).ChildNodes(0).ChildNodes(3).InnerText & "', '" &
                                                   xmlNode.ChildNodes(intC).ChildNodes(intC2).Attributes.GetNamedItem("Name").Value & "')"
                        sqlcmdUPTADE.ExecuteNonQuery()

                    Next
                Next
            End If

            'Variáveis para Escrita
            '//////////////////////
            xmlNode = xmlFile.SelectSingleNode("oVDeviceDescriptor/Variables/VarListWrite")
            If xmlNode.ChildNodes.Count > 0 Then
                For intC = 0 To xmlNode.ChildNodes.Count - 1
                    For intC2 = 1 To xmlNode.ChildNodes(intC).ChildNodes.Count - 1
                        For intC3 = 0 To xmlNode.ChildNodes(intC).ChildNodes(intC2).ChildNodes.Count - 1

                            strVARLISTWRITE(intCOUNT_WRITE) = xmlNode.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(0).InnerText
                            sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[cfg_deviceVarListWrite] ([DeviceId],[VarGroup],[Variable],[SN],[LimitHigh],[limitLow],[Type]) VALUES (" &
                                                       _intDEVICEID & ", '" & xmlNode.ChildNodes(intC).ChildNodes(intC2).Attributes.GetNamedItem("Name").Value & "', '" &
                                                       xmlNode.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(0).InnerText & "', '" &
                                                       xmlNode.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(1).InnerText & "', 0, 0, '" &
                                                       xmlNode.ChildNodes(intC).ChildNodes(intC2).ChildNodes(intC3).ChildNodes(4).InnerText & "')"
                            sqlcmdUPTADE.ExecuteNonQuery()
                            intCOUNT_WRITE += 1

                        Next
                    Next
                Next
            End If

            'FRM Info
            '////////
            xmlNode = xmlFile.SelectSingleNode("oVDeviceDescriptor/Variables/FrmInfo")
            If xmlNode.ChildNodes.Count > 0 Then

                For intC = 0 To xmlNode.ChildNodes.Count - 1
                    strVARGROUP = xmlNode.ChildNodes(intC).Attributes.GetNamedItem("Name").Value
                    Array.Clear(strVARIABLE, 0, strVARIABLE.Length)
                    intVARIABLE = 0
                    For intC2 = 0 To xmlNode.ChildNodes(intC).ChildNodes.Count - 1
                        If xmlNode.ChildNodes(intC).ChildNodes(intC2).InnerText <> Nothing Then
                            strVARIABLE(intC2, 0) = xmlNode.ChildNodes(intC).ChildNodes(intC2).Attributes.GetNamedItem("Type").Value
                            strVARIABLE(intC2, 1) = xmlNode.ChildNodes(intC).ChildNodes(intC2).InnerText
                            intVARIABLE += 1
                        End If
                    Next
                    If intVARIABLE > 0 Then
                        strP1 = "INSERT INTO [dbo].[exe_deviceFrmControl] ([DeviceId],[VarName]"
                        For intC2 = 0 To intVARIABLE - 1
                            strP1 &= ",[" & strVARIABLE(intC2, 0) & "]"
                        Next
                        strP1 &= ") VALUES (" & _intDEVICEID & ", '" & strVARGROUP & "',"
                        For intC2 = 0 To intVARIABLE - 1
                            strP1 &= Convert.ToDecimal(strVARIABLE(intC2, 1)).ToString.Replace(",", ".") & ", "
                        Next
                        strP1 = Mid(strP1, 1, strP1.Length - 2) & ")"
                        sqlcmdUPTADE.CommandText = strP1
                        sqlcmdUPTADE.ExecuteNonQuery()
                    End If
                Next
            End If

            'Cria tabela _dvcData
            '////////////////////
            xmlNode = xmlFile.SelectSingleNode("oVDeviceDescriptor/Variables/VarListRead")
            For intC2 = 0 To xmlNode.ChildNodes.Count - 1
                For intC3 = 1 To xmlNode.ChildNodes(intC2).ChildNodes.Count - 1
                    For intC4 = 0 To xmlNode.ChildNodes(intC2).ChildNodes(intC3).ChildNodes.Count - 1
                        strVARLISTREAD(intCOUNT, 0) = xmlNode.ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).Attributes.GetNamedItem("Name").Value
                        strVARLISTREAD(intCOUNT, 1) = xmlNode.ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(0).InnerText
                        strVARLISTREAD(intCOUNT, 2) = xmlNode.ChildNodes(intC2).ChildNodes(intC3).ChildNodes(intC4).ChildNodes(1).InnerText
                        strVARLISTREAD(intCOUNT, 3) = xmlNode.ChildNodes(intC2).ChildNodes(intC3).Attributes.GetNamedItem("Name").Value
                        intCOUNT += 1
                    Next
                Next
            Next

            strDEVICETABLE = _intDEVICEID.ToString("D6")
            strP1 = "CREATE TABLE [dbo].[exe_" & strDEVICETABLE & "_dvcData] ([DateTime] [smalldatetime], [CommFail] [bit], ["
            For intC = 0 To intCOUNT - 1
                strP1 &= strVARLISTREAD(intC, 1) & "] [decimal] (18, 3) NULL, ["
            Next
            strP1 = Mid(strP1, 1, strP1.Length - 2)
            strP1 &= ") On [PRIMARY]"
            sqlcmdUPTADE.CommandText = strP1
            sqlcmdUPTADE.ExecuteNonQuery()

            'Cria tabela _dvcRTData
            '////////////////////
            strP1 = "CREATE TABLE [dbo].[exe_" & strDEVICETABLE & "_dvcRTData] (["
            For intC = 0 To intCOUNT - 1
                strP1 &= strVARLISTREAD(intC, 1) & "] [decimal] (18, 3) NULL, ["
            Next
            strP1 = Mid(strP1, 1, strP1.Length - 2)
            strP1 &= ") On [PRIMARY]"
            sqlcmdUPTADE.CommandText = strP1
            sqlcmdUPTADE.ExecuteNonQuery()

            'Cria tabela _dvcDataHeader
            '//////////////////////////
            sqlcmdUPTADE.CommandText = "CREATE TABLE [dbo].[exe_" & strDEVICETABLE & "_dvcDataHeader] ([VarName] [Varchar](128) Not NULL, [VarGroup] [Varchar](50) Not NULL, [VarSymbol] [Varchar](50) Not NULL, [SN] [Varchar](50)) On [PRIMARY]"
            sqlcmdUPTADE.ExecuteNonQuery()
            For intC = 0 To intCOUNT - 1
                sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[exe_" & strDEVICETABLE & "_dvcDataHeader] ([VarName],[VarGroup],[VarSymbol],[SN]) VALUES ('" &
                                           strVARLISTREAD(intC, 0) & "', '" & strVARLISTREAD(intC, 3) & "', '" &
                                           strVARLISTREAD(intC, 1) & "', '" & strVARLISTREAD(intC, 2) & "')"
                sqlcmdUPTADE.ExecuteNonQuery()
            Next

            'Cria tabela _dvcCF
            '//////////////////
            sqlcmdUPTADE.CommandText = "CREATE TABLE [dbo].[exe_" & strDEVICETABLE & "_dvcCF] ([VarName] [Varchar](128) Not NULL, [VarSymbol] [Varchar] (50) Not NULL, [DateTime] [smalldatetime], [OriginalValue] [decimal](18, 3)) On [PRIMARY]"
            sqlcmdUPTADE.ExecuteNonQuery()

            'Cria tabela na deviceControl
            '////////////////////////////
            If _bolENABLED = True Then
                sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[exe_deviceControl] ([DeviceId],[NetworkAddress],[RealTimeRead],[ReadParam],[WriteParam],[ParamGroup],[MemoryDownload],[ADR],[DateBegin],[DateEnd],[TimeBegin],[TimeEnd],[Status],[Progress],[CommFail],[AlarmOn],[overWrite]) VALUES " &
                                           "(" & _intDEVICEID & ", 0,0,0,0,'',0,0,'','','','','',0,0,0,0)"
                sqlcmdUPTADE.ExecuteNonQuery()
            End If

            'Cria as tabelas para controle do OEE
            '////////////////////////////////////

            sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_Devices] ([Machine],[DeviceId],[OnOffVariable],[StateON],[StateOFF],[TimetoOn],[TimetoOff]) VALUES (" &
                                        _intMAQUINAID & ", " & _intDEVICEID & ", 'ED_1', 'On', 'Off', " & _intONTIME & ", " & _intOFFTIME & ")"
            sqlcmdUPTADE.ExecuteNonQuery()
            sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_BABELFISH_babelmachine_reference] ([babelfish_id],[device_id],[machineid]) VALUES (" &
                                       _strSAPID & ", " & _intDEVICEID & ", " & _intMAQUINAID & ")"
            sqlcmdUPTADE.ExecuteNonQuery()
            sqlcmdUPTADE.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_BABELFISH_idreferences] ([babelfish_id],[device_id],[comm_status]) VALUES (" &
                                       _strSAPID & ", " & _intDEVICEID & ", GETDATE())"
            sqlcmdUPTADE.ExecuteNonQuery()
            conSQL.Close()
            Return True

        Catch ex As Exception

            _strERROR = "Falha interna da função WriteDBADDNEWBABEL"
            ErrorLog(_strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

#Region "AMARRADOS SEM TEMPO CALENDÁRIO"
    Public Function WriteDBREPORT_TEMPOCALENDARIO(ByVal _intUSERID As Integer,
                                                  ByRef strERROR As String)

        Dim conSQL As SqlConnection
        Dim sqlcmdUPDATE As New SqlCommand
        Dim strConn As String

        Try

            strConn = "Data Source=" & strDataSource &
                      ";Initial Catalog=oViewer;" &
                      "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPDATE.Connection = conSQL
            sqlcmdUPDATE.CommandText = "DELETE FROM [dbo].[exe_MCONTROL_OEE_report_amarrados_semturno] WHERE [user_id] = " & _intUSERID
            sqlcmdUPDATE.ExecuteNonQuery()
            For intC = 0 To _clsAMARRADOS.Count - 1
                sqlcmdUPDATE.CommandText = "INSERT INTO [dbo].[exe_MCONTROL_OEE_report_amarrados_semturno] ([user_id],[centro_trabalho],[ordem],[num_hu],[lote],[data_recebido]) VALUES (" &
                                           _intUSERID & ", '" & _clsAMARRADOS.Item(intC).strCENTRO_TRABALHO & "', '" &
                                           _clsAMARRADOS.Item(intC).strORDEM & "', '" & _clsAMARRADOS.Item(intC).strNUMHU & "', '" &
                                           _clsAMARRADOS.Item(intC).strLOTE & "', '" & _clsAMARRADOS.Item(intC).dtimeRECEBIDO & "')"
                sqlcmdUPDATE.ExecuteNonQuery()
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            strERROR = "Falha interna da função WriteDBREPORT_TEMPOCALENDARIO"
            ErrorLog(strERROR)
            ErrorLog(ex.ToString)
            Return False

        End Try

    End Function

#End Region

    Public Function AjustarTabelas()

        Dim strConn As String
        Dim conSQL As SqlConnection
        Dim sqlcmdUPTADE As New SqlCommand
        Dim sqldaDAYS As SqlDataAdapter
        Dim dtsDAYS As DataSet
        Dim strDAYS As String = Nothing
        Dim strTABLE As String = Nothing
        Dim strQUERY As String = Nothing
        Dim intID As Integer = 0
        Dim strHBEGIN1 As String = Nothing
        Dim strHEND1 As String = Nothing
        Dim strHBEGIN2 As String = Nothing
        Dim strHEND2 As String = Nothing
        Dim strNEWEND As String = Nothing
        Dim arrEND As Array = Nothing

        Try

            strConn = "Data Source=" & strDataSource &
                     ";Initial Catalog=oViewer;" &
                     "User ID=oVServices;Password=@allexoNew2017"
            conSQL = New SqlConnection(strConn)
            conSQL.Open()
            sqlcmdUPTADE.Connection = conSQL
            strTABLE = "exe_MCONTROL_OEE_turnos"
            strQUERY = "SELECT * FROM [dbo].[" & strTABLE & "] ORDER BY [Id] ASC"
            sqldaDAYS = New SqlDataAdapter(strQUERY, conSQL)
            dtsDAYS = New DataSet
            sqldaDAYS.Fill(dtsDAYS, "Days")
            For intC2 = 0 To dtsDAYS.Tables(0).Rows.Count - 1
                intID = dtsDAYS.Tables(0).Rows(intC2).Item("Id")
                strHBEGIN1 = dtsDAYS.Tables(0).Rows(intC2).Item("horainicial1")
                strHEND1 = dtsDAYS.Tables(0).Rows(intC2).Item("horafinal1")
                strHBEGIN2 = dtsDAYS.Tables(0).Rows(intC2).Item("horainicial2")
                strHEND2 = dtsDAYS.Tables(0).Rows(intC2).Item("horafinal2")
                sqlcmdUPTADE.CommandText = "UPDATE [dbo].[" & strTABLE & "] SET [horainicial1] = '" & strHBEGIN1 & ":00', [horafinal1] = '" & strHEND1 & ":59' WHERE [id] = " & intID
                sqlcmdUPTADE.ExecuteNonQuery()
                If dtsDAYS.Tables(0).Rows(intC2).Item("horainicial2") <> Nothing Then
                    sqlcmdUPTADE.CommandText = "UPDATE [dbo].[" & strTABLE & "] SET [horainicial2] = '" & strHBEGIN2 & ":00', [horafinal2] = '" & strHEND2 & ":59' WHERE [id] = " & intID
                    sqlcmdUPTADE.ExecuteNonQuery()
                End If
            Next
            conSQL.Close()
            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

End Module
