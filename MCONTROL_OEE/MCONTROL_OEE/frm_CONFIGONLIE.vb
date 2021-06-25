Imports DevComponents.AdvTree

Public Class frm_CONFIGONLIE
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub frm_CONFIGONLIE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim intDEVICES As Integer = 0

        If ReadDBGETMAQUINASONLINE(advTree_Dev, intDEVICES, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If intDEVICES > 0 Then
                bt_MARCAR.Enabled = True
                bt_UNMARK.Enabled = True
                If ReadDBGETUSERONLINE(advTree_Dev, intUSERID, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub bt_MARCAR_Click(sender As Object, e As EventArgs) Handles bt_MARCAR.Click

        For intC = 0 To advTree_Dev.Nodes.Count - 1
            For intC2 = 0 To advTree_Dev.Nodes(intC).Nodes.Count - 1
                For intC3 = 0 To advTree_Dev.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                    advTree_Dev.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = True
                Next
            Next
        Next

    End Sub
    Private Sub bt_UNMARK_Click(sender As Object, e As EventArgs) Handles bt_UNMARK.Click

        For intC = 0 To advTree_Dev.Nodes.Count - 1
            For intC2 = 0 To advTree_Dev.Nodes(intC).Nodes.Count - 1
                For intC3 = 0 To advTree_Dev.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                    advTree_Dev.Nodes(intC).Nodes(intC2).Nodes(intC3).Checked = False
                Next
            Next
        Next

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        If WriteDBSAVEUSERONLINE(advTree_Dev, intUSERID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
        End If

    End Sub

    Private Sub advTree_Dev_AfterCheck(sender As Object, e As AdvTreeCellEventArgs) Handles advTree_Dev.AfterCheck

        bt_SAVE.Enabled = True

    End Sub
End Class