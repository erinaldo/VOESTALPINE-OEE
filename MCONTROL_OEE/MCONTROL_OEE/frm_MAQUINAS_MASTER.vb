Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_MAQUINAS_MASTER

    Private bolONADD As Boolean = False
    Private bolONEDIT As Boolean = False
    Private bolONSAVING As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub frm_MAQUINAS_MASTER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETGRUPOSMASTER(dgv_GRUPOSMASTER, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If ReadDBGETGRUPOSSEMVINCULO(dgv_GRUPOSEMVINCULO, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If dgv_GRUPOSMASTER.Rows.Count > 0 Then
                    bt_EXCLUIRGRUPO.Enabled = True
                    If ReadDBGETGRUPOSCOMVINCULO(dgv_GRUPOCOMVINCULO, dgv_GRUPOSMASTER.Rows(0).Cells(0).Value, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    End If
                End If
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub dgv_GRUPOSMASTER_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_GRUPOSMASTER.SelectionChanged

        dgv_GRUPOCOMVINCULO.Rows.Clear()
        If dgv_GRUPOSMASTER.Rows.Count > 0 Then
            If ReadDBGETGRUPOSCOMVINCULO(dgv_GRUPOCOMVINCULO, dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub cms_VINCULAR_Opening(sender As Object, e As CancelEventArgs) Handles cms_VINCULAR.Opening

        If dgv_GRUPOSEMVINCULO.Rows.Count = 0 Then
            bt_VINCULAR.Enabled = False
        End If

    End Sub
    Private Sub bt_VINCULAR_Click(sender As Object, e As EventArgs) Handles bt_VINCULAR.Click

        sMessageBox("Q", "Vincular Máquina x Grupo",
                    "Deseja <b>VINCULAR</b> O Grupo <b>" &
                    dgv_GRUPOSEMVINCULO.Rows(dgv_GRUPOSEMVINCULO.CurrentRow.Index).Cells(1).Value & "</b> ao Grupo Master <b>" &
                    dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBVINCULARGRUPOMASTER(dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value,
                                          dgv_GRUPOSEMVINCULO.Rows(dgv_GRUPOSEMVINCULO.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Grupo Vinculado com Sucesso!", 5)
                dgv_GRUPOSEMVINCULO.Rows.RemoveAt(dgv_GRUPOSEMVINCULO.CurrentRow.Index)
                dgv_GRUPOCOMVINCULO.Rows.Clear()
                If ReadDBGETGRUPOSCOMVINCULO(dgv_GRUPOCOMVINCULO, dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If

        End If

    End Sub
    Private Sub cms_DESVINCULAR_Opening(sender As Object, e As CancelEventArgs) Handles cms_DESVINCULAR.Opening

        If dgv_GRUPOCOMVINCULO.Rows.Count = 0 Then
            bt_DESVINCULAR.Enabled = False
        End If

    End Sub
    Private Sub bt_DESVINCULAR_Click(sender As Object, e As EventArgs) Handles bt_DESVINCULAR.Click

        sMessageBox("Q", "Desvincular Grupo x Grupo Master",
                   "Deseja <b>DESVINCULAR</b> o Grupo <b>" &
                    dgv_GRUPOCOMVINCULO.Rows(dgv_GRUPOCOMVINCULO.CurrentRow.Index).Cells(1).Value & "</b> ao Grupo <b>" &
                    dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDESVINCULARGRUPO(dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value,
                                       dgv_GRUPOCOMVINCULO.Rows(dgv_GRUPOCOMVINCULO.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Grupo Desvinculado com Sucesso!", 5)
                dgv_GRUPOCOMVINCULO.Rows.RemoveAt(dgv_GRUPOCOMVINCULO.CurrentRow.Index)
                dgv_GRUPOSEMVINCULO.Rows.Clear()
                If ReadDBGETGRUPOSSEMVINCULO(dgv_GRUPOSEMVINCULO, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub dgv_GRUPOSMASTER_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_GRUPOSMASTER.CellValueChanged

        If bolFRMINI = False And bolONADD = False And bolONSAVING = False Then
            dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(3).Value = True
            bolONEDIT = True
            bt_ADDGRUPO.Enabled = False
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
            bt_EXCLUIRGRUPO.Enabled = False
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        bolONSAVING = True
        If WriteDBSAVEGRUPOSMASTER(dgv_GRUPOSMASTER, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            WriteDBUSERLOG("Dados do GRUPO MASTER salvos")
            bt_ADDGRUPO.Enabled = True
            bt_EXCLUIRGRUPO.Enabled = True
            bt_CANCEL.Enabled = False
            bt_SAVE.Enabled = False
        End If
        bolONSAVING = False

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("Q", "Cancelar Inclusão/Edição",
                    "Deseja <b>CANCELAR</b> as ALTERAÇÕES realizadas?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONADD = True Then
                bolONADD = False
                dgv_GRUPOSMASTER.Rows.RemoveAt(dgv_GRUPOSMASTER.Rows.Count - 1)
                bt_ADDGRUPO.Enabled = True
                bt_SAVE.Enabled = False
                bt_CANCEL.Enabled = False
                If dgv_GRUPOSMASTER.Rows.Count = 0 Then
                    bt_EXCLUIRGRUPO.Enabled = False
                Else
                    bt_EXCLUIRGRUPO.Enabled = True
                End If
            ElseIf bolONEDIT = True Then
                bolONEDIT = True
                dgv_GRUPOSMASTER.Rows.Clear()
                If ReadDBGETGRUPOSMASTER(dgv_GRUPOSMASTER, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If ReadDBGETGRUPOSSEMVINCULO(dgv_GRUPOSEMVINCULO, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    Else
                        If dgv_GRUPOSMASTER.Rows.Count > 0 Then
                            bt_EXCLUIRGRUPO.Enabled = True
                            If ReadDBGETGRUPOSCOMVINCULO(dgv_GRUPOCOMVINCULO, dgv_GRUPOSMASTER.Rows(0).Cells(0).Value, strERROR) = False Then
                                Alert(strERROR, 5)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub bt_ADDGRUPO_Click(sender As Object, e As EventArgs) Handles bt_ADDGRUPO.Click

        bolONADD = True
        dgv_GRUPOSMASTER.Rows.Add()
        dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.Rows.Count - 1).Cells(2).Value = True
        bt_ADDGRUPO.Enabled = False
        bt_SAVE.Enabled = True
        bt_CANCEL.Enabled = True
        bt_EXCLUIRGRUPO.Enabled = False
        WriteDBUSERLOG("Inicio adicionar GRUPO MASTER")

    End Sub
    Private Sub bt_EXCLUIRGRUPO_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRGRUPO.Click

        Dim bolUSED As Boolean = False

        sMessageBox("Q", "Excluir Grupo Master",
                    "Deseja realmente <b>EXCLUIR</b> o Grupo Master " &
                    dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(1).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If ReadDBCHECKUSOGRUPOMASTER(dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value, bolUSED, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If bolUSED = True Then
                    Alert("O Grupo " & dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(1).Value & " está associado a um oi mais Grupos de Máquinas." &
                          " Para excluir é necessário primeiro remover o vínculo!", 10, True)
                    Exit Sub
                Else
                    If WriteDBDELETEGRUPOMASTER(dgv_GRUPOSMASTER.Rows(dgv_GRUPOSMASTER.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    Else
                        Information("Grupo Master Excluído com Sucesso!", 5)
                        WriteDBUSERLOG("GRUPO MASTER excluído")
                        dgv_GRUPOSMASTER.Rows.RemoveAt(dgv_GRUPOSMASTER.CurrentRow.Index)
                        If dgv_GRUPOSMASTER.Rows.Count = 0 Then
                            bt_EXCLUIRGRUPO.Enabled = False
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub frm_MAQUINAS_MASTER_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("Q", "Cancelas Adição/Edição de Operador!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> dos dados do Grupo Master?", taskResult)
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
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub

End Class