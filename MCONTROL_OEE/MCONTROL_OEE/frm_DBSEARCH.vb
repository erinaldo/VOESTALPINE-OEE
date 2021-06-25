Imports System.Threading
Imports System.Data.Sql
Imports DevComponents.DotNetBar
Imports System.Net
Public Class frm_DBSEARCH

    Private SearchServer As Thread
    Private ServerExterno As Thread
    Private bolFimThread As Boolean = False
    Private bolExterno As Boolean = False
    Private bolExternoOK As Boolean = False
    Private strServers(999, 1) As String
    Private taskResult As eTaskDialogResult
    Private Sub frm_DBSEARCH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cp_PROGRESS.IsRunning = True
        cp_PROGRESS.Visible = True
        ribBar_MAIN.Enabled = False

        SearchServer = New Thread(AddressOf FindServer)
        SearchServer.IsBackground = True
        SearchServer.Start()
        tmr_THREAD.Enabled = True

    End Sub
    Private Sub FindServer()

        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim table As System.Data.DataTable = instance.GetDataSources()
        For intC = 0 To table.Rows.Count - 1
            strServers(intC, 0) = table.Rows(intC).ItemArray(0).ToString
            strServers(intC, 1) = table.Rows(intC).ItemArray(1).ToString
        Next
        bolFimThread = True

    End Sub

    Private Sub tmr_THREAD_Tick(sender As Object, e As EventArgs) Handles tmr_THREAD.Tick

        If bolFimThread = True Then
            tmr_THREAD.Enabled = False
            For intC = 0 To 999
                If strServers(intC, 0) <> Nothing Then
                    dgv_SERVERS.Rows.Add()
                    dgv_SERVERS.Rows(dgv_SERVERS.Rows.Count - 1).Cells(1).Value = strServers(intC, 0)
                    dgv_SERVERS.Rows(dgv_SERVERS.Rows.Count - 1).Cells(2).Value = strServers(intC, 1)
                Else
                    ribBar_MAIN.Enabled = True
                    cp_PROGRESS.IsRunning = False
                    cp_PROGRESS.Visible = False
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("Q", "Sair sem salvar!",
                              "Deseja realmente sair <b>sem salvar as os Dados do Servidor</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            Me.Close()
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        Dim bolFound As Boolean = False
        For intC = 0 To dgv_SERVERS.Rows.Count - 1
            If dgv_SERVERS.Rows(intC).Cells(0).Value = True Then
                strDataSource = dgv_SERVERS.Rows(intC).Cells(1).Value & "\" & dgv_SERVERS.Rows(intC).Cells(2).Value
                xmlWriteServer(strDataSource)
                bolFound = True
            End If
        Next
        If bolFound = False Then
            Alert("Selecione um dos Servidores listados", 5, True)
        Else
            frm_LOGIN.Show()
            Me.Close()
        End If

    End Sub

    Private Sub dgv_SERVERS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_SERVERS.CellContentClick

        Dim intCounter As Integer = 0

        For intC = 0 To dgv_SERVERS.Rows.Count - 1
            If dgv_SERVERS.Rows(intC).Cells(0).Value = True Then
                intCounter += 1
            End If
        Next

        If intCounter > 1 Then
            Alert("Selecione apenas um dos Servidores listados", 5, True)
            For intC = 0 To dgv_SERVERS.Rows.Count - 1
                dgv_SERVERS.Rows(intC).Cells(0).Value = False
            Next
        End If

    End Sub
    Private Sub bt_SERVER_Click(sender As Object, e As EventArgs) Handles bt_SERVER.Click

        tb_IPEXTERNO.Enabled = True
        bt_IPEXTERNO.Enabled = True

    End Sub
    Private Sub bt_IPEXTERNO_Click(sender As Object, e As EventArgs) Handles bt_IPEXTERNO.Click

        Dim IPAddress As IPAddress = Nothing
        Dim hostname As IPHostEntry = Nothing
        Dim ip() As IPAddress = Nothing
        Dim strIP As String = Nothing
        Dim bolFound As Boolean = False
        Dim obj_args(0) As Object

        If IPAddress.TryParse(tb_IPEXTERNO.Text, IPAddress) Then
            strIP = tb_IPEXTERNO.Text
        Else
            hostname = Dns.GetHostEntry(tb_IPEXTERNO.Text)
            ip = hostname.AddressList
            strIP = ip(0).ToString
        End If
        strIP = strIP & ",1433"
        strDataSource = strIP
        obj_args(0) = strIP
        cp_PROGRESS.IsRunning = True
        cp_PROGRESS.Visible = True
        ribBar_MAIN.Enabled = False

        ServerExterno = New Thread(AddressOf FindExternalServer)
        ServerExterno.IsBackground = True
        ServerExterno.Start(obj_args)
        bolFimThread = False
        tmr_EXTERNO.Enabled = True

    End Sub
    Private Function FindExternalServer(ByVal strServer)

        If ReadDBCONNECT(strDataSource, strERROR) = False Then
            bolFimThread = True
            bolExternoOK = False
            Return False
        Else
            xmlWriteServer(strDataSource)
            bolExternoOK = True
            bolFimThread = True
            Return True
        End If

    End Function
    Private Sub tmr_EXTERNO_Tick(sender As Object, e As EventArgs) Handles tmr_EXTERNO.Tick

        If bolFimThread = True Then
            tmr_EXTERNO.Enabled = False
            If bolExternoOK = False Then
                tmr_EXTERNO.Enabled = False
                Alert("Falha ao tentar conexão com o servidor <b>" & tb_IPEXTERNO.Text & "</b>", 5)
                cp_PROGRESS.IsRunning = False
                cp_PROGRESS.Visible = False
                ribBar_MAIN.Enabled = True
            Else
                frm_LOGIN.Show()
                Me.Close()
            End If
        End If

    End Sub

End Class