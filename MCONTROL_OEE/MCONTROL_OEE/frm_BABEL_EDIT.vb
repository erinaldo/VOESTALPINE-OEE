Public Class frm_BABEL_EDIT
    Private Sub bt_CANCELAR_Click(sender As Object, e As EventArgs) Handles bt_CANCELAR.Click

        Me.Close()

    End Sub
    Private Sub frm_BABEL_EDIT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strERROR As String = Nothing

        If ReadDBGETMAQUINA_BABEL(cb_MAQUINA, cb_MAQUINA_ID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

        If bolBABELNEW = True Then
            cb_ENABLED.Checked = True
        Else
            cb_ENABLED.Checked = bolENABLED
            tb_DESCRICAO.Text = strDEVICENAME
            tb_SAPID.Text = strSAPID
            If CheckMAQUINABABEL(cb_MAQUINA_ID, cb_MAQUINA, intDEVICEID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If ReadDBGETSIGNALS(intDEVICEID, tb_ON, tb_OFF, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub bt_SALVAR_Click(sender As Object, e As EventArgs) Handles bt_SALVAR.Click

        Dim ResultadoDialogo As DialogResult
        Dim strERROR As String = Nothing

        If tb_DESCRICAO.Text = Nothing Or tb_SAPID.Text = Nothing Or cb_MAQUINA.SelectedIndex < 0 Then
            Alert("Prencha primeiro todos os dados para salvar", 5, True)
            Exit Sub
        End If

        If bolBABELNEW = True Then
            ResultadoDialogo = MsgBox("Confirma Inclusão de novo BABEL?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Incluir Novo Babel")
            If ResultadoDialogo = DialogResult.Yes Then
                If WriteDBADDNEWBABEL(cb_ENABLED.Checked, tb_DESCRICAO.Text, tb_SAPID.Text, cb_MAQUINA_ID.SelectedItem,
                                      tb_ON.Text, tb_OFF.Text, strERROR) = False Then
                    Alert(strERROR, 5)
                Else
                    Information("BABEL incluído com sucesso!", 5)
                End If
            End If
            Else
            ResultadoDialogo = MsgBox("Confirma Edição dos dados do BABEL?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Editar Babel")
            If ResultadoDialogo = DialogResult.Yes Then
                If WriteDBUPDATEBABEL(intDEVICEID, tb_DESCRICAO.Text, tb_SAPID.Text, cb_MAQUINA_ID.SelectedItem,
                                      tb_ON.Text, tb_OFF.Text, strERROR) = False Then
                    Alert(strERROR, 5)
                Else
                    Information("Dados alterados com sucesso!", 5)
                End If
            End If
        End If

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINA_ID.SelectedIndex = cb_MAQUINA.SelectedIndex

    End Sub

End Class