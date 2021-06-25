Public Class frm_MAQUINA
    Private Sub frm_MAQUINA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ReadMachines(cb_MAQUINA, cb_MAQUINAID, strErro) = False Then
            Beep()
            MsgBox("Falha na Leitura das Máquinas Cadastradas", MsgBoxStyle.OkOnly, "Erro de Leitura de Tabela")
            Exit Sub
        Else
            If strMaquinaId > 0 Then
                For intC = 0 To cb_MAQUINAID.Items.Count - 1
                    If cb_MAQUINAID.Items(intC) = strMaquinaId Then
                        cb_MAQUINA.SelectedIndex = intC
                    End If
                Next
            End If
            If cb_MAQUINA.Items.Count > 0 Then
                bt_ESCOLHER.Enabled = True
            End If
        End If

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex

    End Sub
    Private Sub bt_ESCOLHER_Click(sender As Object, e As EventArgs) Handles bt_ESCOLHER.Click

        strMaquinaId = cb_MAQUINAID.SelectedItem
        strMAQUINANAME = cb_MAQUINA.SelectedItem
        bolSELECTED = True
        Me.Close()

    End Sub

End Class