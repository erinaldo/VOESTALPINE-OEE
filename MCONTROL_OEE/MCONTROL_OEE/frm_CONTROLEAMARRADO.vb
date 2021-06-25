Public Class frm_CONTROLEAMARRADO
    Private Sub frm_CONTROLEAMARRADO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIAL.Value = DateAdd(DateInterval.Day, -30, Now())
        dti_DFINAL.Value = Now()
        dti_HINICIAL.Value = Now()
        dti_HFINAL.Value = Now()

        bolFRMINI = True
        If bolRELATORIOLIVRE = False Then
            If ReadDBGETMACHINEMOTIVOS(cb_MAQUINA, cb_MAQUINAID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        Else
            Label1.Visible = False
            cb_MAQUINA.Visible = False
            bt_GERARREPORT.Enabled = True
        End If
        bolFRMINI = False

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex
        bt_GERARREPORT.Enabled = True

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_REPORTAMARRADO.Enabled = True
        F1.Show()
        reportDATAINICIAL = dti_DINICIAL.Text & " " & dti_HINICIAL.Text
        reportDATAFINAL = dti_DFINAL.Text & " " & dti_HFINAL.Text
        reportMAQUINA = cb_MAQUINA.SelectedItem
        If WriteDBREPORTAMARRADO(cb_MAQUINAID.SelectedItem, dti_DINICIAL.Text, dti_HINICIAL.Text,
                                 dti_DFINAL.Text, dti_HFINAL.Text, strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTAMARRADO_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTAMARRADO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_AMARRADO

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frmWAIT" Then
                bolFound = True
                Exit For
            End If
        Next

        If bolFound = False Then
            tmr_REPORTAMARRADO.Enabled = False
            Me.Enabled = True
            F1.Show()
        End If

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub

End Class