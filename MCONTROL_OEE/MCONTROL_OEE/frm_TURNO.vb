Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_TURNO

    Private bolONADD As Boolean = False
    Private bolFRMINI As Boolean = True
    Private bolONDEDIT As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub
    Private Sub bt_TURNO_Click(sender As Object, e As EventArgs) Handles bt_TURNO.Click

        bolONADD = True
        dgv_TURNO.Rows.Add()
        dgv_TURNO.Rows(dgv_TURNO.Rows.Count - 1).Cells(6).Value = True
        bt_TURNO.Enabled = False
        bt_EXCLUIR.Enabled = False
        bt_SAVE.Enabled = True
        bt_CANCEL.Enabled = True

    End Sub
    Private Sub frm_TURNO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETTURNOS_EDIT(intMACHINEID, dgv_TURNO, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_TURNO.Rows.Count > 0 Then
                bt_EXCLUIR.Enabled = True
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub dgv_TURNO_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_TURNO.CellValueChanged

        If bolFRMINI = False And bolONADD = False Then
            bolONDEDIT = True
            dgv_TURNO.Rows(dgv_TURNO.CurrentRow.Index).Cells(7).Value = True
            bt_TURNO.Enabled = False
            bt_EXCLUIR.Enabled = False
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
        End If

    End Sub
    Private Sub frm_TURNO_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            Me.TopMost = False
            sMessageBox("A", "Cancelar Edição/Adição de Turno!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> de Turno?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                bolFRMINI = True
                e.Cancel = False
            Else
                e.Cancel = True
                Me.TopMost = True
            End If
        Else
            bolFRMINI = True
        End If

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        Me.TopMost = False
        sMessageBox("A", "Cancelar Edição/Adição de Turno!",
                    "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> de Turno?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONDEDIT = True Then
                dgv_TURNO.Rows.Clear()
                If ReadDBGETTURNOS_EDIT(intMACHINEID, dgv_TURNO, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_TURNO.Rows.Count > 0 Then
                        bt_EXCLUIR.Enabled = True
                    End If
                End If
            Else
                dgv_TURNO.Rows.RemoveAt(dgv_TURNO.Rows.Count - 1)
            End If
            bolONADD = False
            bolONDEDIT = False
        End If
        Me.TopMost = True

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_TURNO.EndEdit()
        For intC = 0 To dgv_TURNO.Rows.Count - 1
            If dgv_TURNO.Rows(intC).Cells(1).Value = Nothing Or (dgv_TURNO.Rows(intC).Cells(2).Value <> Nothing And
                                                                 dgv_TURNO.Rows(intC).Cells(2).Value = Nothing) Then
                Alert("Preencha primeiro todos os campos da Tabela!", 5, True)
                Exit For
            End If
        Next
        If WriteDBUPDATETURNO(intMACHINEID, dgv_TURNO, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            bt_TURNO.Enabled = True
            bt_EXCLUIR.Enabled = True
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
        End If

    End Sub
    Private Sub bt_EXCLUIR_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIR.Click

        Me.TopMost = False
        sMessageBox("A", "Excluir Turno!",
                    "Deseja realmente <b>EXCLUIR</b> o Turno <b>" & dgv_TURNO.Rows(dgv_TURNO.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDELETETURNO(dgv_TURNO.Rows(dgv_TURNO.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Turno Excluído com Sucesso!", 5)
                dgv_TURNO.Rows.RemoveAt(dgv_TURNO.CurrentRow.Index)
                If dgv_TURNO.Rows.Count = 0 Then
                    bt_EXCLUIR.Enabled = False
                End If
            End If
        End If

    End Sub

End Class