Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_MANUTENCAO_CONFIG

    Private taskResult As eTaskDialogResult
    Private bolONSAVE As Boolean = False
    Private Sub frm_MANUTENCAO_CONFIG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETMOTIVOSMANUTENCAO(dgv_MOTIVOSPARADA, dgv_MOTIVOSAGUARDANDO, dgv_MOTIVOSBOTAOFECHARPARADA, strERROR) = False Then
            Alert(strERROR, 5)
        End If
        bolFRMINI = False

    End Sub
    Private Sub dgv_MOTIVOS_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)

        If bolFRMINI = False And bolONSAVE = False Then
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
        End If

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("A", "Cancelar Alterações",
                         "Deseja realmente <b>CANCELAR</b> as Alterações?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            dgv_MOTIVOSPARADA.Rows.Clear()
            dgv_MOTIVOSAGUARDANDO.Rows.Clear()
            dgv_MOTIVOSBOTAOFECHARPARADA.Rows.Clear()
            If ReadDBGETMOTIVOSMANUTENCAO(dgv_MOTIVOSPARADA, dgv_MOTIVOSAGUARDANDO, dgv_MOTIVOSBOTAOFECHARPARADA, strERROR) = False Then
                Alert(strERROR, 5)
            End If
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        bolONSAVE = True
        If WrtiteDBUPDATEMOTIVOSMANUTENCAO(dgv_MOTIVOSPARADA, dgv_MOTIVOSAGUARDANDO, dgv_MOTIVOSBOTAOFECHARPARADA, strERROR) = False Then
            Alert(strERROR, 5)
        Else
            Information("Daos salvos com sucesso!", 5)
            WriteDBUSERLOG("MANUTENÇÃO dados salvos")
        End If
        bolONSAVE = False

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub

    Private Sub frm_MANUTENCAO_CONFIG_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolFRMINI = True

    End Sub
    Private Sub dgv_MOTIVOSAGUARDANDO_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSAGUARDANDO.CellValueChanged

        If bolFRMINI = False And bolONSAVE = False Then
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
        End If

    End Sub
    Private Sub dgv_MOTIVOSPARADA_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSPARADA.CellValueChanged

        If bolFRMINI = False And bolONSAVE = False Then
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
        End If

    End Sub
    Private Sub dgv_MOTIVOSBOTAOFECHARPARADA_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSBOTAOFECHARPARADA.CellValueChanged

        If bolFRMINI = False And bolONSAVE = False Then
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
        End If

    End Sub

End Class