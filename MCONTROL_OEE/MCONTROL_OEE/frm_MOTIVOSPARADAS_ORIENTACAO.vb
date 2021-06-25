Public Class frm_MOTIVOSPARADAS_ORIENTACAO
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        strORIENTACAO = tb_ORIENTACAO.Text
        bolORIENTACAO = True
        Me.Close()

    End Sub
    Private Sub bt_CANCELAR_Click(sender As Object, e As EventArgs) Handles bt_CANCELAR.Click

        bolORIENTACAO = False
        Me.Close()

    End Sub
    Private Sub frm_MOTIVOSPARADAS_ORIENTACAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tb_ORIENTACAO.Text = strORIENTACAO

    End Sub
End Class