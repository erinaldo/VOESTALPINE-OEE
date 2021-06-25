Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_MAQUINAS

    Private bolONEDIT As Boolean = False
    Private bolONADD As Boolean = False
    Private bolSAVING As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub frm_MAQUINAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim bolFOUND As Boolean = False

        bolFRMINI = True
        If ReadDBGETMACHINE(dgv_MACHINE, strERROR) = False Then
            Alert(strERROR, 10)
            Exit Sub
        Else
            If dgv_MACHINE.Rows.Count > 0 Then
                For intC = 0 To dgv_MACHINE.Rows.Count - 1
                    dgv_MACHINE.Rows(intC).Cells(1).ReadOnly = True
                    dgv_MACHINE.Rows(intC).Cells(2).ReadOnly = True
                    dgv_MACHINE.Rows(intC).Cells(5).ReadOnly = True
                Next
                bt_EDIT.Enabled = True
                bt_EXCLUIRMAQUINA.Enabled = True
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub bt_ADDMAQ_Click(sender As Object, e As EventArgs) Handles bt_ADDMAQ.Click

        bolONADD = True
        dgv_MACHINE.Rows.Add()
        dgv_MACHINE.Rows(dgv_MACHINE.Rows.Count - 1).Cells(2).Value = True
        dgv_MACHINE.Rows(dgv_MACHINE.Rows.Count - 1).Cells(3).Value = True
        dgv_MACHINE.Rows(dgv_MACHINE.Rows.Count - 1).Cells(1).Selected = True
        bt_EXCLUIRMAQUINA.Enabled = False
        bt_EDIT.Enabled = False
        bt_CANCEL.Enabled = True
        bt_SAVE.Enabled = True
        bt_ADDMAQ.Enabled = False

    End Sub
    Private Sub frm_MAQUINAS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("A", "Cancelas Adição/Edição de Máquina!",
                    "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> dos dados da Máquina?", taskResult)
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
    Private Sub tmr_DEVICES_Tick(sender As Object, e As EventArgs) Handles tmr_DEVICES.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MAQUINAS_DEVICES" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            Me.Enabled = True
            tmr_DEVICES.Enabled = False
            If bolSELECTEDVARIABLE = True Then
                bt_SAVE.Enabled = True
            End If
        End If

    End Sub
    Private Sub bt_EDIT_Click(sender As Object, e As EventArgs) Handles bt_EDIT.Click

        bt_ADDMAQ.Enabled = False
        bt_EXCLUIRMAQUINA.Enabled = False
        For intC = 0 To dgv_MACHINE.Rows.Count - 1
            dgv_MACHINE.Rows(intC).Cells(1).ReadOnly = False
            dgv_MACHINE.Rows(intC).Cells(2).ReadOnly = False
            dgv_MACHINE.Rows(intC).Cells(5).ReadOnly = False
        Next
        bt_CANCEL.Enabled = True
        bolONEDIT = True

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        Dim bolFOUND As Boolean = False

        sMessageBox("A", "Cancelas Adição/Edição de Máquina!",
                    "Deseja realmente <b>CANCELAR a Adição/Edição</b> dos dados da Máquina?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If bolONEDIT = True Then
                bolONEDIT = False
                bolFRMINI = True
                dgv_MACHINE.Rows.Clear()
                If ReadDBGETMACHINE(dgv_MACHINE, strERROR) = False Then
                    Alert(strERROR, 10)
                    Exit Sub
                Else
                    If dgv_MACHINE.Rows.Count > 0 Then
                        For intC = 0 To dgv_MACHINE.Rows.Count - 1
                            dgv_MACHINE.Rows(intC).Cells(1).ReadOnly = True
                            dgv_MACHINE.Rows(intC).Cells(2).ReadOnly = True
                        Next
                        bt_EDIT.Enabled = True
                        bt_EXCLUIRMAQUINA.Enabled = True
                    End If
                End If
                bolFRMINI = False
                bt_CANCEL.Enabled = False
                bt_SAVE.Enabled = False

                bt_ADDMAQ.Enabled = True
            Else
                dgv_MACHINE.Rows.RemoveAt(dgv_MACHINE.Rows.Count - 1)
                bt_ADDMAQ.Enabled = True
                bt_CANCEL.Enabled = False
                bt_SAVE.Enabled = False
                If dgv_MACHINE.Rows.Count > 0 Then
                    bt_EXCLUIRMAQUINA.Enabled = True
                    bt_EDIT.Enabled = True
                End If
            End If
        End If

    End Sub
    Private Sub dgv_MACHINE_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MACHINE.CellValueChanged

        If bolFRMINI = False And bolONEDIT = True And bolSAVING = False Then
            dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(4).Value = True
            bt_SAVE.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_MACHINE.EndEdit()
        bolSAVING = True
        If bolONADD = True Then
            If dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(1).Value = Nothing Then
                Alert("O campo <b>DESCRIÇÃO na Tabela de Máquinas</b> é obrigatório", 10, True)
                Exit Sub
            End If
        End If
        If WriteDBUPDATEMACHINEDATA(dgv_MACHINE, strERROR) = False Then
            Alert(strERROR, 10)
            Exit Sub
        Else
            Information("Dados Salvos com suceswso!", 5)
        End If
        bt_SAVE.Enabled = False
        bt_CANCEL.Enabled = False
        bt_ADDMAQ.Enabled = True
        bt_EXCLUIRMAQUINA.Enabled = True
        bt_EDIT.Enabled = True
        bolONADD = False
        bolONEDIT = False
        bolSAVING = False

    End Sub
    Private Sub tb_TempoProduzindo_TextChanged(sender As Object, e As EventArgs)

        If bolFRMINI = False And bolONEDIT = True Or bolONADD = True Then
            bt_SAVE.Enabled = True
        End If

    End Sub
    Private Sub tb_TempoParada_TextChanged(sender As Object, e As EventArgs)

        If bolFRMINI = False And bolONEDIT = True Or bolONADD = True Then
            bt_SAVE.Enabled = True
        End If

    End Sub
    Private Sub bt_EXCLUIRMAQUINA_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRMAQUINA.Click

        Dim bolUSED As Boolean = False

        sMessageBox("A", "Excluir Máquina",
                    "Deseja realmente <b>EXCLUIR</b> a Máquina <b>" & dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then

            If ReadDBCHECKUSEDMACHINE(dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(0).Value, bolUSED, strERROR) = True Then
                If bolUSED = True Then
                    Alert("Não é possível excluir o(a) " & dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(1).Value &
                          ". Já existe histórico de paradas ligado a esta máquina!", 10, True)
                    Exit Sub
                Else
                    If WriteDBDELETEMAQUINA(dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                        Alert("Falha na EXCLUSÃO do registros do(a) " & dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(1).Value, 10)
                        Exit Sub
                    Else
                        Information("Máquina excluída com sucesso!", 5)
                        dgv_MACHINE.Rows.RemoveAt(dgv_MACHINE.CurrentRow.Index)
                        If dgv_MACHINE.Rows.Count = 0 Then
                            bt_EDIT.Enabled = False
                            bt_EXCLUIRMAQUINA.Enabled = False
                        End If
                    End If
                End If
            Else
                Alert("Falha na verificação de dados do(a) " & dgv_MACHINE.Rows(dgv_MACHINE.CurrentRow.Index).Cells(1).Value, 10)
                Exit Sub
            End If
        End If

    End Sub

End Class