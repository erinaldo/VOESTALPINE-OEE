Imports DevComponents.DotNetBar

Public Class frm_APONTAMENTO_LIVRE
    Private Sub frm_APONTAMENTO_LIVRE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIAL.Value = DateAdd(DateInterval.Day, -30, Now())
        dti_DFINAL.Value = Now()
        dti_HINICIAL.Value = Now()
        dti_HFINAL.Value = Now()

        bolFRMINI = True
        If ReadDBGETMACHINE_PARETO(lb_MAQUINAS, lb_MAQUINASID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If
        bolFRMINI = False

    End Sub
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing
        Dim bolFOUND As Boolean = False

        If lb_MAQUINASID.CheckedItems.Count = 0 Then
            Alert("Selecione pelo menos uma máquina!", 5, True)
            Exit Sub
        End If
        Me.Enabled = False
        tmr_REPORTAPONTAMENTO.Enabled = True
        F1.Show()
        If WriteDBREPORTAPONTAMENTOLIVRE(lb_MAQUINAS, lb_MAQUINASID, intUSERID, dti_DINICIAL.Text, dti_HINICIAL.Text,
                                         dti_DFINAL.Text, dti_HFINAL.Text, reportDIASUTEIS, strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTAPONTAMENTO_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTAPONTAMENTO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_APONTAMENTO_LIVRE
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
            tmr_REPORTAPONTAMENTO.Enabled = False
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
    Private Sub lb_MAQUINAS_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_MAQUINAS.ItemCheck

        If lb_MAQUINAS.CheckedItems.Count > 0 Then
            bt_GERARREPORT.Enabled = True
        Else
            bt_GERARREPORT.Enabled = False
        End If

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
    Private Sub bt_MARCAR_Click(sender As Object, e As EventArgs) Handles bt_MARCAR.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 1)
        Next

    End Sub
    Private Sub bt_DESMARCAR_Click(sender As Object, e As EventArgs) Handles bt_DESMARCAR.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 0)
        Next

    End Sub

End Class