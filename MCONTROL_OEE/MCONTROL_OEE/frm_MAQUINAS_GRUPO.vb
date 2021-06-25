Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_MAQUINAS_GRUPO

    Private bolONADD As Boolean = False
    Private bolONEDIT As Boolean = False
    Private bolONSAVING As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub frm_MAQUINAS_GRUPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETGRUPOS(dgv_GRUPOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_GRUPOS.Rows.Count > 0 Then
                bt_EXCLUIRGRUPO.Enabled = True
                If ReadDBGETMAQVINCULADAS(dgv_MAQCOMVINCULO, dgv_GRUPOS.Rows(0).Cells(0).Value, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
            If ReadDBGETMAQSEMVINCULO(dgv_MAQSEMVINCULO, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub bt_ADDGRUPO_Click(sender As Object, e As EventArgs) Handles bt_ADDGRUPO.Click

        bolONADD = True
        dgv_GRUPOS.Rows.Add()
        dgv_GRUPOS.Rows(dgv_GRUPOS.Rows.Count - 1).Cells(2).Value = True
        bt_ADDGRUPO.Enabled = False
        bt_SAVE.Enabled = True
        bt_CANCEL.Enabled = True
        bt_EXCLUIRGRUPO.Enabled = False
        WriteDBUSERLOG("Inicio adicionar GRUPO MÁQUINAS")

    End Sub
    Private Sub dgv_GRUPOS_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_GRUPOS.CellValueChanged

        If bolFRMINI = False And bolONADD = False And bolONSAVING = False Then
            dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(3).Value = True
            bolONEDIT = True
            bt_ADDGRUPO.Enabled = False
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
            bt_EXCLUIRGRUPO.Enabled = False
        End If

    End Sub
    Private Sub bt_EXCLUIRGRUPO_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRGRUPO.Click

        Dim bolUSED As Boolean = False

        sMessageBox("Q", "Excluir Grupo",
                    "Deseja realmente <b>EXCLUIR</b> o Grupo de Máquinas " &
                    dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(1).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If ReadDBCHECKUSOGRUPO(dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value, bolUSED, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If bolUSED = True Then
                    Alert("O Grupo " & dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(1).Value & " está associado a uma mais máquinas." &
                          " Para excluir é necessário primeiro remover o vínculo!", 10, True)
                    Exit Sub
                Else
                    If WriteDBDELETEGRUPO(dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    Else
                        Information("Grupo Excluído com Sucesso!", 5)
                        WriteDBUSERLOG("GRUPO MÁQUINAS EXCLUÍDO")
                        dgv_GRUPOS.Rows.RemoveAt(dgv_GRUPOS.CurrentRow.Index)
                        If dgv_GRUPOS.Rows.Count = 0 Then
                            bt_EXCLUIRGRUPO.Enabled = False
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub cms_VINCULAR_Opening(sender As Object, e As CancelEventArgs) Handles cms_VINCULAR.Opening

        If dgv_MAQSEMVINCULO.Rows.Count = 0 Then
            bt_VINCULAR.Enabled = False
        End If

    End Sub
    Private Sub bt_DESVINCULAR_Click(sender As Object, e As EventArgs) Handles bt_DESVINCULAR.Click

        sMessageBox("Q", "Desvincular Máquina x Grupo",
                    "Deseja <b>DESVINCULAR</b> a Máquina <b>" &
                     dgv_MAQCOMVINCULO.Rows(dgv_MAQCOMVINCULO.CurrentRow.Index).Cells(1).Value & "</b> ao Grupo <b>" &
                     dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDESVINCULARMAQUINA(dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value,
                                         dgv_MAQCOMVINCULO.Rows(dgv_MAQCOMVINCULO.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Máquina Desvinculada com Sucesso!", 5)
                dgv_MAQCOMVINCULO.Rows.RemoveAt(dgv_MAQCOMVINCULO.CurrentRow.Index)
                dgv_MAQSEMVINCULO.Rows.Clear()
                If ReadDBGETMAQSEMVINCULO(dgv_MAQSEMVINCULO, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub cms_DESVINCULAR_Opening(sender As Object, e As CancelEventArgs) Handles cms_DESVINCULAR.Opening

        If dgv_MAQCOMVINCULO.Rows.Count = 0 Then
            bt_DESVINCULAR.Enabled = False
        End If

    End Sub
    Private Sub dgv_GRUPOS_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_GRUPOS.SelectionChanged

        dgv_MAQCOMVINCULO.Rows.Clear()
        If ReadDBGETMAQVINCULADAS(dgv_MAQCOMVINCULO, dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub bt_VINCULAR_Click(sender As Object, e As EventArgs) Handles bt_VINCULAR.Click

        sMessageBox("Q", "Vincular Máquina x Grupo",
                   "Deseja <b>VINCULAR</b> a Máquina <b>" &
                   dgv_MAQSEMVINCULO.Rows(dgv_MAQSEMVINCULO.CurrentRow.Index).Cells(1).Value & "</b> ao Grupo <b>" &
                   dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBVINCULARMAQUINA(dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value,
                                      dgv_MAQSEMVINCULO.Rows(dgv_MAQSEMVINCULO.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("Máquina Vinculada com Sucesso!", 5)
                dgv_MAQSEMVINCULO.Rows.RemoveAt(dgv_MAQSEMVINCULO.CurrentRow.Index)
                dgv_MAQCOMVINCULO.Rows.Clear()
                If ReadDBGETMAQVINCULADAS(dgv_MAQCOMVINCULO, dgv_GRUPOS.Rows(dgv_GRUPOS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If

        End If

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("Q", "Cancelar Inclusão/Edição",
                    "Deseja <b>CANCELAR</b> as ALTERAÇÕES realizadas?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONADD = True Then
                bolONADD = False
                dgv_GRUPOS.Rows.RemoveAt(dgv_GRUPOS.Rows.Count - 1)
                bt_ADDGRUPO.Enabled = True
                bt_SAVE.Enabled = False
                bt_CANCEL.Enabled = False
                If dgv_GRUPOS.Rows.Count = 0 Then
                    bt_EXCLUIRGRUPO.Enabled = False
                Else
                    bt_EXCLUIRGRUPO.Enabled = True
                End If
            ElseIf bolONEDIT = True Then
                bolONEDIT = True
                dgv_GRUPOS.Rows.Clear()
                If ReadDBGETGRUPOS(dgv_GRUPOS, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_GRUPOS.Rows.Count > 0 Then
                        If ReadDBGETMAQVINCULADAS(dgv_MAQCOMVINCULO, dgv_GRUPOS.Rows(0).Cells(0).Value, strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        bolONSAVING = True
        If WriteDBSAVEGRUPOS(dgv_GRUPOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            WriteDBUSERLOG("Dados do GRUPO MÁQUINA salvo")
            bt_ADDGRUPO.Enabled = True
            bt_EXCLUIRGRUPO.Enabled = True
            bt_CANCEL.Enabled = False
            bt_SAVE.Enabled = False
        End If
        bolONSAVING = False

    End Sub
    Private Sub frm_MAQUINAS_GRUPO_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("Q", "Cancelas Adição/Edição de Operador!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> dos dados do Grupo de Máquinas?", taskResult)
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

End Class