Public Class frm_APONTAMENTODIARIO_GRUPO
    Private Sub frm_APONTAMENTODIARIO_GRUPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim intANO As Integer = 0

        intANO = Now.Year - 2019
        For intC = 0 To intANO
            cb_ANO.Items.Add(2019 + intC)
        Next

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_REPORTAPONTAMENTO_GRUPO.Enabled = True
        F1.Show()
        If WriteDBREPORTAPONTAMENTO_GRUPO(intUSERID, cb_MES.SelectedIndex, cb_ANO.SelectedItem, strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTAPONTAMENTO_GRUPO_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTAPONTAMENTO_GRUPO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_APONTAMENTO_GRUPO
        Dim F2 As New frm_REPORT_AMARRADOS_SEMTURNO

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frmWAIT" Then
                bolFound = True
                Exit For
            End If
        Next

        If bolFound = False Then
            tmr_REPORTAPONTAMENTO_GRUPO.Enabled = False
            Me.Enabled = True
            F1.Show()
            If _clsAMARRADOS.Count > 0 Then
                If WriteDBREPORT_TEMPOCALENDARIO(intUSERID, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    F2.Show()
                End If
            End If
        End If

    End Sub
    Private Sub cb_MES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MES.SelectedIndexChanged

        Dim intMES As Integer = 0
        Dim strMES As String = Nothing
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim intDAYS As Integer = 0

        If cb_ANO.SelectedIndex >= 0 Then
            bt_GERARREPORT.Enabled = True
        End If

    End Sub
    Private Sub tb_ANO_TextChanged(sender As Object, e As EventArgs)

        bt_GERARREPORT.Enabled = False

    End Sub

    Private Sub cb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_ANO.SelectedIndexChanged

        Dim intMES As Integer = 0
        Dim strMES As String = Nothing
        Dim dtimeDATAINICIAL As DateTime = Nothing
        Dim dtimeDATAFINAL As DateTime = Nothing
        Dim intDAYS As Integer = 0

        If cb_MES.SelectedIndex >= 0 Then
            bt_GERARREPORT.Enabled = True
        End If

    End Sub

End Class