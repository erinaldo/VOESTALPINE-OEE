Public Class frm_SPLASH

    Private bolVERSIONCONTROLOK As Boolean = False
    Private Sub frm_SPLASH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strErro As String = ""
        Dim strControl(2) As String
        Dim bolNEWVERSION As Boolean = False

        'Me.TransparencyKey = Color.White

        Try

            lbl_REVISION.Text = strViewerVersion
            lb_APPREVISION.Text = strAppRevision
            lbl_MSG.Text = "Carregando arquivo de configuração ..."
            Me.Refresh()

            If xmlGetDataSource(strDataSource) = False Then
                lbl_MSG.Text = "inicialização interrompida ..."
                bt_Close.Visible = True
                Alert("Erro na leitura do arquivo configuração com o <b>SERVIDOR ALLEXO</b?", 5)
                Exit Sub
            Else
                If ReadDBGETVIEWERVERSION(strViewerVersion, strAppRevision, bolNEWVERSION, strERROR) = False Then
                    Alert(strERROR, 5)
                Else
                    If bolNEWVERSION = True Then
                        Alert("Uma <b>NOVA VERSÃO</b> do aplicativo CLIENT está disponível. Entre em contato com o <b>Administrador do Sistema</b> para obter a nova versão!", 10, True)
                    Else
                        bolVERSIONCONTROLOK = True
                    End If
                End If
                tmr_SPLASH.Enabled = True
            End If

        Catch ex As Exception

            lbl_MSG.Text = "inicialização interrompida ..."
            bt_Close.Visible = True
            Alert("Falha de Conexão com o <b>Servidor de Dados</b>", 5, True)
            ErrorLog(strErro)
            ErrorLog(ex.ToString)
            bt_SEARCH.Visible = True

        End Try

    End Sub
    Private Sub tmr_SPLASH_Tick(sender As Object, e As EventArgs) Handles tmr_SPLASH.Tick

        Dim strErro As String = ""
        Dim strVersion As String = Nothing
        Dim bolCONNECTED As Boolean = False

        tmr_SPLASH.Enabled = False

        If bolVERSIONCONTROLOK = False Then
            Me.Close()
            Exit Sub
        End If

        'Verificar conexão com o servidor da base de dados
        '-------------------------------------------------
        lbl_MSG.Text = "Verificando conexão com servidor de dados ..."
        Me.Refresh()

        If ReadDBCONNECT(bolCONNECTED, strErro) = False Then
            lbl_MSG.Text = "inicialização interrompida ..."
            bt_Close.Visible = True
            Alert("Falha de Conexão com o <b>Servidor de Dados</b>. Verifique se o <b>Serviço de Banco de Dados</b> está ativado ou se o <b>Servidor de Aplicação</b> está acessível.", 15, True)
            bt_SEARCH.Visible = True
            Exit Sub
        Else
            If bolCONNECTED = True Then
                ReadDBGETAPPDATA(Nothing, Nothing, Nothing, Nothing, strVersion)
                lbl_VERSION.Text = strVersion
                strAPPVERSION = strVersion
                Me.Refresh()
                Timer2.Enabled = True
            Else
                lbl_MSG.Text = "inicialização interrompida ..."
                bt_Close.Visible = True
                Alert("Falha de Conexão com o <b>Servidor Allexo</b>", 5, True)
            End If
        End If

    End Sub

    Private Sub wb_SPLASH_OptionsClick(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub wb_SPLASH_CloseClick(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub bt_Close_Click(sender As Object, e As EventArgs)

        Me.Close()

    End Sub

    Private Sub tmr_DBSEARCH_Tick(sender As Object, e As EventArgs) Handles tmr_DBSEARCH.Tick

        frm_DBSEARCH.Show()
        Me.Close()

    End Sub

    Private Sub bt_Close_Click_1(sender As Object, e As EventArgs) Handles bt_Close.Click

        Me.Close()

    End Sub

    Private Sub bt_SEARCH_Click(sender As Object, e As EventArgs) Handles bt_SEARCH.Click

        frm_DBSEARCH.Show()
        Me.Close()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        frm_LOGIN.Show()
        Me.Close()

    End Sub

End Class