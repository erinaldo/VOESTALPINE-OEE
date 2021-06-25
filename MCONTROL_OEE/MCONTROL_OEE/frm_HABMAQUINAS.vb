Imports DevComponents.DotNetBar

Public Class frm_HABMAQUINAS
    Private Sub frm_HABMAQUINAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETMACHINE_HABDESAB(lb_MAQUINAS, lb_MAQUINASID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub lb_MAQUINAS_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_MAQUINAS.ItemCheck

        For intC = 0 To lb_MAQUINASID.Items.Count - 1
            lb_MAQUINASID.SetItemCheckState(intC, 0)
        Next
        For intC = 0 To lb_MAQUINAS.CheckedItems.Count - 1
            For intC2 = 0 To lb_MAQUINASID.Items.Count - 1
                If lb_MAQUINAS.CheckedItems(intC).Text.Contains(lb_MAQUINAS.Items(intC2)) And
                   lb_MAQUINAS.CheckedItems(intC).Text.Length = lb_MAQUINAS.Items(intC2).ToString.Length Then
                    lb_MAQUINASID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next

    End Sub
    Private Sub bt_SALVAR_Click(sender As Object, e As EventArgs) Handles bt_SALVAR.Click

        If WriteDBUPDATEHABMAQUINAS(lb_MAQUINASID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados atualizados com sucesso!", 5)
        End If

    End Sub
End Class