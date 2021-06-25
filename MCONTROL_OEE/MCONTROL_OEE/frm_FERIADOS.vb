Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_FERIADOS

    Private bolONADD As Boolean = False
    Private bolONEDIT As Boolean = False
    Private bolONCHANGE As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub frm_FERIADOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETFERIADOS(dgv_FERIADOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_FERIADOS.Rows.Count > 0 Then
                bt_EXCLUIRFERIADO.Enabled = True
            Else
                bt_EXCLUIRFERIADO.Enabled = False
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub bt_ADDFERIADO_Click(sender As Object, e As EventArgs) Handles bt_ADDFERIADO.Click

        bolONADD = True
        dgv_FERIADOS.Rows.Add()
        dgv_FERIADOS.Rows(dgv_FERIADOS.Rows.Count - 1).Cells(3).Value = True
        bt_ADDFERIADO.Enabled = False
        bt_EXCLUIRFERIADO.Enabled = False
        bt_CANCEL.Enabled = True
        bt_SAVE.Enabled = True
        WriteDBUSERLOG("FERIADO início de inclusão")

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_FERIADOS.EndEdit()
        For intC = 0 To dgv_FERIADOS.Rows.Count - 1
            If dgv_FERIADOS.Rows(intC).Cells(1).Value = Nothing Or dgv_FERIADOS.Rows(intC).Cells(2).Value = Nothing Then
                Alert("<b>Nome do Feriado</b> e <b>Data</b> devem ser obrigatoriamente preenchidos !", 10, True)
                Exit Sub
            End If
        Next
        If WriteDBUPDATEFERIADOS(dgv_FERIADOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            WriteDBUSERLOG("FERIADO salvo")
            bt_ADDFERIADO.Enabled = True
            bt_EXCLUIRFERIADO.Enabled = True
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
        End If

    End Sub
    Private Sub bt_EXCLUIRFERIADO_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRFERIADO.Click

        sMessageBox("Q", "Excluir Feriado",
                    "Deseja realmente <b>EXCLUIR</b> o Feriado " & dgv_FERIADOS.Rows(dgv_FERIADOS.CurrentRow.Index).Cells(1).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDELETEFERIADO(dgv_FERIADOS.Rows(dgv_FERIADOS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Feriado Excluído com Sucesso!", 5)
                WriteDBUSERLOG("FERIADO excluído")
                dgv_FERIADOS.Rows.RemoveAt(dgv_FERIADOS.CurrentRow.Index)
                If dgv_FERIADOS.Rows.Count = 0 Then
                    bt_EXCLUIRFERIADO.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("Q", "Cancelar Adição/Edição de Feriados!",
                    "Deseja realmente <b>CANCELAR a Adição/Edição</b> do Feriado?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONADD = True Then
                dgv_FERIADOS.Rows.RemoveAt(dgv_FERIADOS.Rows.Count - 1)

            ElseIf bolONEDIT = True Then
                dgv_FERIADOS.Rows.Clear()
                bolFRMINI = True
                If ReadDBGETFERIADOS(dgv_FERIADOS, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
                bolFRMINI = False
            End If
            bt_ADDFERIADO.Enabled = True
            If dgv_FERIADOS.Rows.Count > 0 Then
                bt_EXCLUIRFERIADO.Enabled = True
            End If
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()


    End Sub
    Private Sub frm_FERIADOS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("A", "Cancelas Adição/Edição de Feriado!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> do Feriado?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                bolFRMINI = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            bolFRMINI = True
        End If

    End Sub
    Private Sub dgv_FERIADOS_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_FERIADOS.CellValueChanged

        If bolFRMINI = False And bolONADD = False And bolONCHANGE = False Then
            dgv_FERIADOS.Rows(dgv_FERIADOS.Rows.Count - 1).Cells(4).Value = True
            bt_ADDFERIADO.Enabled = False
            bt_EXCLUIRFERIADO.Enabled = False
            bt_CANCEL.Enabled = True
            bt_SAVE.Enabled = True
            bolONEDIT = True
        End If

    End Sub

End Class