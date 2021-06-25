Public Class frm_LOGIN
    Private Sub frm_LOGIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        Dim k As String

        k = e.KeyChar.ToString
        If k = vbCr Then
            bt_LOGIN.PerformClick()
        End If

    End Sub
    Private Sub bt_LOGIN_Click(sender As Object, e As EventArgs) Handles bt_LOGIN.Click

        bolLogged = False
        If strPassword <> Nothing Then
            If strLogin = tbx_USER.Text And strPassword = tbx_PASSWORD.Text Then
                bolLogged = True
                Me.Close()
            Else
                bolLogged = False
                Beep()
                MsgBox("Usuário e/ou Senha inválidos", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Login")
            End If
        Else
            If strLogin = tbx_USER.Text Then
                Me.Size = New Size(374, 373)
            Else
                Beep()
                MsgBox("Usuário inválidos", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Login")
            End If
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_OK.Click

        If tbx_PASSWORD.Text = tb_CONFIRMARSENHA.Text Then
            If WriteDBUPDATESENHA(strUserId, tb_CONFIRMARSENHA.Text) = False Then
                Beep()
                MsgBox("Erro na escrita de atualização de senha no banco de dados!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Login")
            Else
                bolLogged = True
                Me.Close()
            End If
        Else
            Beep()
            MsgBox("Confirmação de senha não confere!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Login")
        End If

    End Sub
End Class