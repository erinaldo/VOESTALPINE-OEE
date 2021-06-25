Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_BLOQUEARREGISTROS

    Private intREGISTRO As Integer = 0
    Private taskResult As eTaskDialogResult
    Private Sub frm_BLOQUEARREGISTROS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIAL.Value = DateAdd(DateInterval.Day, -30, Now())
        dti_HINICIAL.Value = Now()
        dti_DFINAL.Value = Now()
        dti_HFINAL.Value = Now()

        bolFRMINI = True
        If ReadDBGETMACHINEMOTIVOS(cb_MAQUINA, cb_MAQUINAID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If
        bolFRMINI = False

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex
        intMACHINEID = cb_MAQUINAID.SelectedItem
        bt_PARADAS.Enabled = True
        dgv_PARADAS.Rows.Clear()

    End Sub
    Private Sub bt_PARADAS_Click(sender As Object, e As EventArgs) Handles bt_PARADAS.Click

        dgv_PARADAS.Rows.Clear()
        If ReadDBGETPARADASBLOQUEAR(dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text,
                                    dti_HFINAL.Text, intMACHINEID, dgv_PARADAS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub dgv_PARADAS_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_PARADAS.SelectionChanged

        intREGISTRO = dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(0).Value
        bt_BLOQUEAR.Enabled = True

    End Sub
    Private Sub bt_BLOQUEAR_Click(sender As Object, e As EventArgs) Handles bt_BLOQUEAR.Click

        sMessageBox("Q", "Bloquerar Registros",
                    "Deseja realmente <b>BLOQUEAR</b> os dados de Parada da Máquina <b>" & cb_MAQUINA.SelectedItem & "</b> até do dia/horário " & dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(1).Value & " " &
                    dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(2).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBBLOQUEARPARADA(cb_MAQUINAID.SelectedItem,
                                     dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(1).Value & " " & dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(2).Value, strERROR) = False Then
                Alert(strERROR, 5)
            Else
                Information("Registros BLOQUEADOS com sucesso!", 5)
                If ReadBDGETPARADASBLOQUEADAS(cb_MAQUINAID.SelectedItem, dgv_PARADAS, strERROR) = False Then
                    Alert(strERROR, 5)
                End If
            End If
        End If

    End Sub
    Private Sub frm_BLOQUEARREGISTROS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolFRMINI = True

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub

End Class