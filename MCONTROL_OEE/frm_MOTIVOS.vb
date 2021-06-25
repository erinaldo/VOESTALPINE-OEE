Imports System.ComponentModel

Public Class frm_MOTIVOS

    Private bolONEDIT As Boolean = False
    Private Sub frm_MOTIVOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strERROR As String = Nothing

        Try
            bolIni = True
            GetMotivosEmpty(strMaquinaId, cb_MOTIVONIVEL1, cb_MOTIVONIVEL1ID, dgv_MOTIVOS)
            bolIni = False

        Catch ex As Exception

            ErrorLog("Falha no módulo frm_MOTIVOS")
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        If cb_MOTIVONIVEL1.SelectedIndex < 0 Then
            Beep()
            MsgBox("Preencha pelo menos o Motivo de Parada Nível 1!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Dados Faltantes")
            Exit Sub
        End If

        If SaveMotivos(dgv_MOTIVOS.Rows(dgv_MOTIVOS.CurrentRow.Index).Cells(0).Value,
                       strMaquinaId, cb_MOTIVONIVEL1.SelectedItem, cb_MOTIVONIVEL1ID.SelectedItem,
                       cb_MOTIVONIVEL2.SelectedItem, cb_MOTIVONIVEL2ID.SelectedItem,
                       cb_MOTIVONIVEL3.SelectedItem, cb_MOTIVONIVEL3ID.SelectedItem,
                       tb_COMENTARIOS.Text) = True Then
            bolSaving = True
            bolONEDIT = False
            Beep()
            MsgBox("Dados atualizados com sucesso")
            dgv_MOTIVOS.Rows.Clear()
            GetMotivosEmpty(strMaquinaId, cb_MOTIVONIVEL1, cb_MOTIVONIVEL1ID, dgv_MOTIVOS)
            bolSaving = False
        Else
            Beep()
            MsgBox("Falha no salvamento dos Motivos!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro interno")
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub
    Private Sub frm_MOTIVOS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolIni = True

    End Sub
    Private Sub cb_MOTIVONIVEL1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL1.SelectedIndexChanged

        cb_MOTIVONIVEL1ID.SelectedIndex = cb_MOTIVONIVEL1.SelectedIndex
        cb_MOTIVONIVEL2.Items.Clear()
        cb_MOTIVONIVEL2ID.Items.Clear()
        cb_MOTIVONIVEL3.Items.Clear()
        cb_MOTIVONIVEL3ID.Items.Clear()
        GetMotivos2(cb_MOTIVONIVEL1ID.SelectedItem, cb_MOTIVONIVEL2, cb_MOTIVONIVEL2ID)
        If cb_MOTIVONIVEL2.Items.Count = 0 Then
            bt_SAVE.Enabled = True
        Else
            bt_SAVE.Enabled = False
        End If

    End Sub
    Private Sub cb_MOTIVONIVEL2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL2.SelectedIndexChanged

        cb_MOTIVONIVEL2ID.SelectedIndex = cb_MOTIVONIVEL2.SelectedIndex
        cb_MOTIVONIVEL3.Items.Clear()
        cb_MOTIVONIVEL3ID.Items.Clear()
        GetMotivos3(cb_MOTIVONIVEL2ID.SelectedItem, cb_MOTIVONIVEL3, cb_MOTIVONIVEL3ID)
        If cb_MOTIVONIVEL3.Items.Count = 0 Then
            bt_SAVE.Enabled = True
        Else
            bt_SAVE.Enabled = False
        End If

    End Sub
    Private Sub cb_MOTIVONIVEL3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVONIVEL3.SelectedIndexChanged

        cb_MOTIVONIVEL3ID.SelectedIndex = cb_MOTIVONIVEL3.SelectedIndex
        bt_SAVE.Enabled = True

    End Sub

End Class