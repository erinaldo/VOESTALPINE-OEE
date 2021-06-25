Public Class frm_PRODUTIVIDADE_MENSAL
    Private Sub frm_PRODUTIVIDADE_MENSAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tb_ANO.Text = Now.Year

    End Sub
    Private Sub cb_MES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MES.SelectedIndexChanged

        bt_GERARREPORT.Enabled = True

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_PRODUTIVIDADE_MENSAL.Enabled = True
        F1.Show()
        reportDATAINICIAL = "01/" & Format(cb_MES.SelectedIndex + 1, "00") & "/" & tb_ANO.Text
        reportRELATORIONOME = "ACUMULADO MENSAL - " & UCase(cb_MES.SelectedItem)
        If WriteDBREPORTPRODUTIVIDADE_GRUPO_MENSAL(cb_MES.SelectedIndex + 1, tb_ANO.Text, strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_PRODUTIVIDADE_MENSAL_Tick(sender As Object, e As EventArgs) Handles tmr_PRODUTIVIDADE_MENSAL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_PRODUTIVIDADE_GRUPO

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frmWAIT" Then
                bolFound = True
                Exit For
            End If
        Next

        If bolFound = False Then
            tmr_PRODUTIVIDADE_MENSAL.Enabled = False
            Me.Enabled = True
            F1.Show()
        End If

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub

End Class