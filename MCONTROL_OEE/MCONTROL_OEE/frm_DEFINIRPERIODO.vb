Public Class frm_DEFINIRPERIODO
    Private Sub frm_DEFINIRPERIODO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ReadDBGETPERIODOTRABALHO(intMACHINEID, dti_HINICIAL, dti_HFINAL, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        If WriteDBSAVEPERIODOTRABALHO(intMACHINEID, dti_HINICIAL, dti_HFINAL, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados salvos com sucesso!", 5)
            WriteDBUSERLOG("PERÍODO DE TRABALHO salvo")
        End If

    End Sub

End Class