Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_EDITAROPS

    Private taskResult As eTaskDialogResult
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub

    Private Sub frm_EDITAROPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ReadDBGETOPSDELETADAS(dgv_OPS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_OPS.Rows.Count > 0 Then
                dgv_OPS.Rows(0).Selected = True
                bt_RECUPERAOP.Enabled = True
            End If
        End If

    End Sub
    Private Sub bt_RECUPERAOP_Click(sender As Object, e As EventArgs) Handles bt_RECUPERAOP.Click

        sMessageBox("Q", "Recuperar OP Deletada",
                    "Deseja realmente <b>RECUPERAR</b> a OP <b>" & dgv_OPS.Rows(dgv_OPS.CurrentRow.Index).Cells(2).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then

            If WriteDBUNDELETEOP(dgv_OPS.Rows(dgv_OPS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                dgv_OPS.Rows.Clear()
                If ReadDBGETOPSDELETADAS(dgv_OPS, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_OPS.Rows.Count > 0 Then
                        dgv_OPS.Rows(0).Selected = True
                        bt_RECUPERAOP.Enabled = True
                    End If
                End If
            End If

        End If

    End Sub

End Class