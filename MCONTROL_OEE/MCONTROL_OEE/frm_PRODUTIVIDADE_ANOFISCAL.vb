Public Class frm_PRODUTIVIDADE_ANOFISCAL
    Private Sub frm_PRODUTIVIDADE_ANOFISCAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim intANOFISCAL As Integer = 0
        Dim dtimePRIMEIROANO As DateTime = "01/04/2019"
        Dim dtimeAGORA As DateTime = Nothing
        Dim intANO As Integer = 2020
        Dim decANOFISCAL As Decimal = 0D
        Dim decRESTO As Decimal = 0D

        dtimeAGORA = Now()
        intANOFISCAL = DateDiff(DateInterval.Day, dtimePRIMEIROANO, dtimeAGORA)
        decANOFISCAL = intANOFISCAL / 365
        intANOFISCAL = decANOFISCAL
        decRESTO = decANOFISCAL - intANOFISCAL
        If decRESTO > 0 Then
            intANOFISCAL += 1
        End If
        For intC = 0 To intANOFISCAL - 1
            cb_ANOFISCAL.Items.Add(intANO + intC)
        Next

    End Sub
    Private Sub cb_ANOFISCAL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_ANOFISCAL.SelectedIndexChanged

        bt_GERARREPORT.Enabled = True

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing
        Dim intMES As Integer = 0
        Dim strMES As String = Nothing
        Try

            Me.Enabled = False
            tmr_REPORTPRODUTIVIDADE_ANOFISCAL.Enabled = True
            F1.Show()
            reportRELATORIONOME = "ANO FISCAL " & cb_ANOFISCAL.SelectedItem
            reportDATAINICIAL = "01/04/" & Val(cb_ANOFISCAL.SelectedItem) - 1
            If WriteDBREPORTPRODUTIVIDADE_GRUPO(cb_ANOFISCAL.SelectedItem, strERROR) = False Then
                Alert(strERROR, 5)
                bolREPORTOK = True
            Else
                bolREPORTOK = True
            End If

        Catch ex As Exception


        End Try

    End Sub
    Private Sub tmr_REPORTPRODUTIVIDADE_ANOFISCAL_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTPRODUTIVIDADE_ANOFISCAL.Tick

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
            tmr_REPORTPRODUTIVIDADE_ANOFISCAL.Enabled = False
            Me.Enabled = True
            F1.Show()
        End If

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub

End Class