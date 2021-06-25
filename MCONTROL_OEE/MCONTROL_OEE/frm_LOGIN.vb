
Imports DevComponents.DotNetBar
Imports System.ComponentModel

Public Class frm_LOGIN

    Private bolFormOpen As Boolean = False
    Private bolStep2 As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub bt_VIEW_MouseDown(sender As Object, e As MouseEventArgs)

        tbx_PASSWORD.UseSystemPasswordChar = False
        tbx_PASSWORD.Text = tbx_PASSWORD.Text
        Me.Refresh()

    End Sub
    Private Sub bt_VIEW_MouseLeave(sender As Object, e As EventArgs)

        tbx_PASSWORD.UseSystemPasswordChar = True

    End Sub
    Private Sub bt_LOGIN_Click(sender As Object, e As EventArgs) Handles bt_LOGIN.Click

        Dim strErro As String = ""
        Dim bolResult As Boolean = False
        Dim bolChangeLogin As Boolean = False
        Dim bolChangePassword As Boolean = False
        Dim strPreferences(10) As String

        Try

            If tbx_USER.Text = "" Or tbx_PASSWORD.Text = "" Then
                Alert("<b>ALERTA omniViewer</b> - <b>Obrigatório</b> preencher os campos <b>usuário</b> e <b>senha</b>!", 5, True)
                Exit Sub
            End If

            ReadDBLOGIN(tbx_USER.Text, tbx_PASSWORD.Text, strErro, bolResult)

            If bolResult = False And strErro = "" Then
                Alert("<b>Usuário</b> e/ou <b>senha</b> inválidos!", 10, True)
                tbx_PASSWORD.Text = ""
                tbx_USER.Text = ""
                tbx_USER.Focus()
                Exit Sub

            ElseIf strErro <> "" Then
                'Falha interna quando da tentativa de Login
                '///////////////////////////////////////////
                Alert(strErro, 5)
                Exit Sub

            ElseIf bolResult = True Then

                WriteDBUSERLOG("Login")

                'Verifica se precisa alterar Login e/ou Senha no primeiro Login
                '//////////////////////////////////////////////////////////////
                If WriteDBCHECKPC(intUSERID, bolChangeLogin, bolChangePassword, strErro) = False Then
                    Alert(strErro, 5)
                Else
                    If bolChangeLogin = True Or bolChangePassword = True Then
                        bolStep2 = True
                        Me.Size = New Size(290, 320)
                        bt_LOGIN.Enabled = False
                        bt_VIEW.Enabled = False
                        tbx_USER.Enabled = False
                        tbx_PASSWORD.Enabled = False
                        If bolChangeLogin = True And bolChangePassword = True Then
                            Information("Entre com o novo Login e Senha para acessar o sistema!", 5)
                        ElseIf bolChangeLogin = True And bolChangePassword = False Then
                            Information("Entre com o novo Login para acessar o sistema!", 5)
                        ElseIf bolChangeLogin = False And bolChangePassword = True Then
                            Information("Entre com a nova senha para acessar o sistema!", 5)
                        End If

                        If bolChangeLogin = True Then
                            tbx_NEWLOGIN.Enabled = True
                            tbx_NEWLOGIN.Text = ""
                        Else
                            tbx_NEWLOGIN.Text = tbx_USER.Text
                            tbx_NEWLOGIN.Enabled = False
                        End If
                        If bolChangePassword = True Then
                            tbx_NEWPASSWORD.Enabled = True
                            tbx_NEWPASSWORD.Text = ""
                            tbx_CONFIRMPASS.Enabled = True
                            tbx_CONFIRMPASS.Text = ""
                        Else
                            tbx_NEWPASSWORD.Enabled = False
                            tbx_NEWPASSWORD.Text = ""
                            tbx_CONFIRMPASS.Enabled = False
                            tbx_CONFIRMPASS.Text = ""
                        End If
                    Else

                        Information("Aguarde. Conectando com o servidor ...", 5)

                        For Each frmForm In My.Application.OpenForms
                            If (frmForm.Name = frm_MAIN.Name) Then
                                bolFormOpen = True
                            End If
                        Next

                        If RELEASEALLMENU(strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        Else
                            If ReadDBGETBLOCKS(intUSERID, strERROR) = False Then
                                Alert(strERROR, 5)
                                Exit Sub
                            End If

                            If bolFormOpen = False Then
                                frm_MAIN.Show()
                            Else
                                frm_MAIN.Enabled = True
                            End If
                            Me.Close()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

            Alert("Falha interna na execução do objeto <b>frm_LOGIN.bt_LOGIN!</b>", 5)
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub Button2_MouseDown(sender As Object, e As MouseEventArgs) Handles bt_VIEW.MouseDown

        tbx_PASSWORD.UseSystemPasswordChar = False
        tbx_PASSWORD.Text = tbx_PASSWORD.Text
        Me.Refresh()

    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles bt_VIEW.MouseLeave

        tbx_PASSWORD.UseSystemPasswordChar = True

    End Sub
    Private Sub bt_EXIT2_Click(sender As Object, e As EventArgs)

        For Each form In My.Application.OpenForms
            If form.Name = "frm_MAIN" Then
                sMessageBox("Q", "Sair do Aplicativo", "Não existem usuários logados no momento. Confirma a finalização do aplicativo?", taskResult)
                If taskResult = eTaskDialogResult.Yes Then
                    frm_MAIN.Close()
                    Me.Close()
                End If
                Exit Sub
            End If
        Next
        Me.Close()

    End Sub
    Private Sub bt_CONFIRMCHANGE_Click(sender As Object, e As EventArgs) Handles bt_CONFIRMCHANGE.Click

        Dim strPreferences(10) As String
        Dim strERRO As String = Nothing

        If tbx_NEWPASSWORD.Text <> tbx_CONFIRMPASS.Text Then
            Alert("A <b>confirmação de senha não confere com a nova senha</b> digitada!", 5, True)
        Else
            If WriteDBCHANGECREDENTIALS(intUSERID, tbx_NEWLOGIN.Text, tbx_NEWPASSWORD.Text, strERRO) = False Then
                Alert(strERRO, 5)
                Exit Sub
            Else

                WriteDBUSERLOG("Login/Senha Alterados")
                WriteDBUSERLOG("Login")

                For Each frmForm In My.Application.OpenForms
                    If (frmForm.Name = frm_MAIN.Name) Then
                        bolFormOpen = True
                    End If
                Next

                'Abre Form Principal
                '-------------------
                If bolFormOpen = False Then
                    frm_MAIN.Show()
                Else
                    frm_MAIN.Enabled = True
                End If
                Me.Close()
            End If
        End If

    End Sub
    Private Sub frm_LOGIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Dim k As String
        k = e.KeyChar.ToString
        If k = vbCr Then
            If bolStep2 = False Then
                bt_LOGIN.PerformClick()
            Else
                bt_CONFIRMCHANGE.PerformClick()
            End If
        End If

    End Sub
    Private Sub frm_LOGIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim bolFormOpen As Boolean = False

        If strUSERNAME = Nothing Then
            For Each frmForm In My.Application.OpenForms
                If (frmForm.Name = frm_MAIN.Name) Then
                    bolFormOpen = True
                End If
            Next
            If bolFormOpen = True Then
                frm_MAIN.Close()
            End If
        End If

    End Sub

    Private Sub frm_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class