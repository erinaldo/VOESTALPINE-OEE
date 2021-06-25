Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_OPERADORES

    Private bolONADD As Boolean = False
    Private bolONEDIT As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub frm_OPERADORES_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETOPERADORES(dgv_OPERADORES, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_OPERADORES.Rows.Count > 0 Then
                bt_EXCLUIROPERADOR.Enabled = True
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub dgv_OPERADORES_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_OPERADORES.CellValueChanged

        If bolFRMINI = False And bolONADD = False Then
            dgv_OPERADORES.Rows(dgv_OPERADORES.Rows.Count - 1).Cells(6).Value = True
            bt_ADDOPERADOR.Enabled = False
            bt_EXCLUIROPERADOR.Enabled = False
            bt_CANCEL.Enabled = True
            bt_SAVE.Enabled = True
            bolONEDIT = True
        End If

    End Sub
    Private Sub bt_ADDOPERADOR_Click(sender As Object, e As EventArgs) Handles bt_ADDOPERADOR.Click

        bolONADD = True
        dgv_OPERADORES.Rows.Add()
        dgv_OPERADORES.Rows(dgv_OPERADORES.Rows.Count - 1).Cells(4).Value = True
        dgv_OPERADORES.Rows(dgv_OPERADORES.Rows.Count - 1).Cells(5).Value = True
        bt_ADDOPERADOR.Enabled = False
        bt_EXCLUIROPERADOR.Enabled = False
        bt_CANCEL.Enabled = True
        bt_SAVE.Enabled = True
        WriteDBUSERLOG("OPERADORES início de inclusão")

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub frm_OPERADORES_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("Q", "Cancelar Adição/Edição de Operador!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> dos dados do Operador?", taskResult)
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
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("Q", "Cancelar Adição/Edição de Operadores!",
                    "Deseja realmente <b>CANCELAR a Adição/Edição</b> de Operadores?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONADD = True Then
                dgv_OPERADORES.Rows.RemoveAt(dgv_OPERADORES.Rows.Count - 1)

            ElseIf bolONEDIT = True Then
                dgv_OPERADORES.Rows.Clear()
                bolFRMINI = True
                If ReadDBGETOPERADORES(dgv_OPERADORES, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
                bolFRMINI = False
            End If
            bt_ADDOPERADOR.Enabled = True
            If dgv_OPERADORES.Rows.Count > 0 Then
                bt_EXCLUIROPERADOR.Enabled = True
            End If
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_OPERADORES.EndEdit()
        For intC = 0 To dgv_OPERADORES.Rows.Count - 1
            If dgv_OPERADORES.Rows(intC).Cells(2).Value = Nothing Or dgv_OPERADORES.Rows(intC).Cells(3).Value = Nothing Then
                Alert("<b>Nome do usuário</b> e <b>Login</b> devem ser obrigatoriamente preenchidos !", 10, True)
                Exit Sub
            End If
        Next
        If WriteDBUPDATEOPERADORES(dgv_OPERADORES, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            WriteDBUSERLOG("OPERADOR dados salvos")
            bt_ADDOPERADOR.Enabled = True
            bt_EXCLUIROPERADOR.Enabled = True
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
        End If

    End Sub
    Private Sub bt_EXCLUIROPERADOR_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIROPERADOR.Click

        sMessageBox("Q", "Excluir Operador",
                    "Deseja realmente <b>EXCLUIR</b> o Operador " & dgv_OPERADORES.Rows(dgv_OPERADORES.CurrentRow.Index).Cells(2).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDELETEOPERADOR(dgv_OPERADORES.Rows(dgv_OPERADORES.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Operador Excluído com Sucesso!", 5)
                WriteDBUSERLOG("OPERADOR excluído")
                dgv_OPERADORES.Rows.RemoveAt(dgv_OPERADORES.CurrentRow.Index)
                If dgv_OPERADORES.Rows.Count = 0 Then
                    bt_EXCLUIROPERADOR.Enabled = False
                End If
            End If
        End If

    End Sub

End Class