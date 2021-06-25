Imports System.ComponentModel

Public Class frm_ORDEM
    Private Sub dgv_ORDEM_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ORDEM.CellValueChanged

        If bolIni = False And bolEditing = False And bolSaving = False Then
            dgv_ORDEM.Rows(dgv_ORDEM.CurrentRow.Index).Cells(4).Value = True
            bt_SAVE.Enabled = True
        End If

    End Sub
    Private Sub frm_ORDEM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            bolIni = True
            GetOrdensEmpty(strMaquinaId, dgv_ORDEM)
            bolIni = False

        Catch ex As Exception

            ErrorLog("Falha no módulo frm_ORDEM")
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_ORDEM.EndEdit()
        If SaveOrdens(strMaquinaId, dgv_ORDEM) = True Then
            bolSaving = True
            Beep()
            MsgBox("Dados atualizados com sucesso")
            dgv_ORDEM.Rows.Clear()
            Array.Clear(strMotivosN1, 0, strMotivosN1.Length)
            GetOrdensEmpty(strMaquinaId, dgv_ORDEM)
            bolSaving = False
        Else
            Beep()
            MsgBox("Falha no salvamento dos dados de Ordem de Produção!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro interno")
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub
    Private Sub frm_ORDEM_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolIni = True

    End Sub

End Class