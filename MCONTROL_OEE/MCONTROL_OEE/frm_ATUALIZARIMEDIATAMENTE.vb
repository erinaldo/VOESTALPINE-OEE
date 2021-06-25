Public Class frm_ATUALIZARIMEDIATAMENTE

    Private intCONTADOR As Integer = 0
    Private intCONTADORTOTAL As Integer = 0
    Private Sub frm_ATUALIZARIMEDIATAMENTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tb_ATUALIZANDO.Select()
        cp_ATUALIZANDO.IsRunning = True
        tmr_ATUALIZANDO.Enabled = True

    End Sub
    Private Sub tmr_ATUALIZANDO_Tick(sender As Object, e As EventArgs) Handles tmr_ATUALIZANDO.Tick

        Dim intCOMMAND As Integer = 0

        intCONTADOR += 1
        If intCONTADOR = 5 Then
            intCONTADOR = 0
            intCONTADORTOTAL += 1
            If ReadDBGETTC(intCOMMAND) = False Then
                Alert("Erro interno da Funcção de Atualização do Tempo Calendário", 5)
                tmr_ATUALIZANDO.Enabled = False
                Me.Close()
            Else
                If intCOMMAND = 0 Then
                    Information("Tempo Calendário atualizado com sucesso!", 5)
                    tmr_ATUALIZANDO.Enabled = False
                    Me.Close()
                End If
            End If
            If intCONTADORTOTAL > 5 Then
                Alert("Falha na Atualização do Tempo Calendário", 5, True)
                tmr_ATUALIZANDO.Enabled = False
                Me.Close()
            End If
        End If

    End Sub

End Class