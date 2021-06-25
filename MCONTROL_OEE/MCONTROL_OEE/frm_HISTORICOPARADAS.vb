Imports System.ComponentModel
Imports DevComponents.DotNetBar

Public Class frm_HISTORICOPARADAS

    Private bolOP As Boolean = False
    Private taskResult As eTaskDialogResult
    Private Sub bt_SAIR_Click(sender As Object, e As EventArgs) Handles bt_SAIR.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub frm_HISTORICOPARADAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If bolEDITARPARADAS = True Then
            dgv_PARADAS.ContextMenuStrip = cms_EDITARPARADAS
            bt_GERARREPORT.Visible = False
            bt_ADDPARADA.Enabled = True
        Else
            bt_GERARREPORT.Visible = True
            bt_ADDPARADA.Visible = False
        End If

        bolFRMINI = True
        If ReadDBGETMACHINE_PARETO(lb_MAQUINAS, lb_MAQUINASID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If ReadBDGETMOTIVONIVEL1(cb_MOTIVON1, cb_MOTIVON1ID, strERROR) = False Then
                Beep()
                MsgBox("Falha na Leitura dos Motivos de Parada", MsgBoxStyle.OkOnly, "Erro de Leitura de Tabela")
            Else
                cb_MOTIVON1.Enabled = True
            End If
        End If

        dti_DINICIAL.Value = DateAdd(DateInterval.Day, -30, Now())
        dti_HINICIAL.Value = Now()
        dti_DFINAL.Value = Now()
        dti_HFINAL.Value = Now()
        bolFRMINI = False

    End Sub
    Private Sub bt_PARADAS_Click(sender As Object, e As EventArgs) Handles bt_PARADAS.Click

        Dim bolFOUND As Boolean = False

        dgv_PARADAS.Rows.Clear()
        If ReadDBGETPARADAS(dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text,
                            dti_HFINAL.Text, lb_MAQUINASID, dgv_PARADAS,
                            cb_MOTIVON1ID.SelectedItem, cb_MOTIVON2ID.SelectedItem,
                            cb_MOTIVON3ID.SelectedItem, cb_SEMMOTIVOS.Checked, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_PARADAS.Rows.Count > 0 Then
                If ReadDBCHECKTEMPOCALENDARIO(dgv_PARADAS, dti_DINICIAL.Text, dti_DFINAL.Text, bolFOUND, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolFOUND = True Then
                        Alert("Encontrada(s) Parada(s) sem Tempo Calendário registrado!", 5, True)
                    End If
                End If
                If ReadDBCHECKPPROGRAMADA(dgv_PARADAS, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
                bt_GERARREPORT.Enabled = True
            Else
                bt_GERARREPORT.Enabled = False
            End If
        End If

    End Sub
    Private Sub cms_EDITARPAARADAS_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_EDITARPARADAS.Opening

        If dgv_PARADAS.Rows.Count > 0 Then
            If dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(20).Value = True Then
                bt_EDITARPARADAS.Enabled = False
                bt_EXCLUIRPARADA.Enabled = False
            Else
                bt_EDITARPARADAS.Enabled = True
                bt_EXCLUIRPARADA.Enabled = True
            End If

        End If

    End Sub
    Private Sub frm_HISTORICOPARADAS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolEDITARPARADAS = False
        bolFRMINI = True

    End Sub
    Private Sub bt_EDITARPARADAS_Click(sender As Object, e As EventArgs) Handles bt_EDITARPARADAS.Click

        Dim F1 As New frm_EDITARPARADA
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        Me.Enabled = False
        bolADDPARADA = False
        intPARADAID = dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(0).Value
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_EDITARPARADA", bolOpen, intIndex)
        If bolOpen = False Then
            WriteDBUSERLOG("EDITAR PARADA iniciado")
            tmr_EDITARPARADAS.Enabled = True
            Me.Enabled = False
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_EDITARPARADAS_Tick(sender As Object, e As EventArgs) Handles tmr_EDITARPARADAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_EDITARPARADA" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_EDITARPARADAS.Enabled = False
            If bolPARADAEDITADA = True Then
                bolPARADAEDITADA = False
                dgv_PARADAS.Rows.Clear()
                'If ReadDBGETPARADAS(dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text,
                '                    dti_HFINAL.Text, intMACHINEID, dgv_PARADAS, cb_MOTIVON1ID.SelectedItem,
                '                    cb_MOTIVON2ID.SelectedItem, cb_MOTIVON3ID.SelectedItem, cb_SEMMOTIVOS.Checked, strERROR) = False Then
                '    Alert(strERROR, 5)
                '    Exit Sub
                'End If
            End If
            Me.Enabled = True
        End If

    End Sub
    Private Sub bt_ADDPARADA_Click(sender As Object, e As EventArgs) Handles bt_ADDPARADA.Click

        Dim F1 As New frm_EDITARPARADA
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        Me.Enabled = False
        bolADDPARADA = True
        'intMACHINEID = cb_MAQUINAID.SelectedItem
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_EDITARPARADA", bolOpen, intIndex)
        If bolOpen = False Then
            WriteDBUSERLOG("ADICIONAR PARADA iniciado")
            tmr_EDITARPARADAS.Enabled = True
            Me.Enabled = False
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_EXCLUIRPARADA_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRPARADA.Click

        sMessageBox("Q", "Excluir Parada",
                    "Deseja realmente <b>EXCLUIR</b> os dados da Parada do dia " & dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(1).Value & " das " &
                    dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(2).Value & " até o dia " & dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(3).Value &
                    " as " & dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(4).Value & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBDELETEPARADA(dgv_PARADAS.Rows(dgv_PARADAS.CurrentRow.Index).Cells(0).Value, strERROR) = False Then
                Alert(strERROR, 5)
            Else
                dgv_PARADAS.Rows.RemoveAt(dgv_PARADAS.CurrentRow.Index)
                Information("Parada EXCLUÍDA com sucesso!", 5)
                WriteDBUSERLOG("PARADA excluída")
            End If
        End If

    End Sub
    Private Sub bt_GERARREPORT_Click(sender As Object, e As EventArgs) Handles bt_GERARREPORT.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_REPORTPARADAS.Enabled = True
        F1.Show()
        reportDATAINICIAL = dti_DINICIAL.Text
        reportDATAFINAL = dti_DFINAL.Text
        If WriteDBREPORTPARADAS(dgv_PARADAS, intUSERID, strERROR) = False Then
            Alert(strERROR, 5)
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTPARADAS_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTPARADAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_PARADAS

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frmWAIT" Then
                bolFound = True
                Exit For
            End If
        Next

        If bolFound = False Then
            tmr_REPORTPARADAS.Enabled = False
            Me.Enabled = True
            F1.Show()
        End If

    End Sub
    Private Sub cb_MOTIVON1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVON1.SelectedIndexChanged

        cb_MOTIVON1ID.SelectedIndex = cb_MOTIVON1.SelectedIndex
        cb_MOTIVON2.Items.Clear()
        cb_MOTIVON2ID.Items.Clear()
        cb_MOTIVON3.Items.Clear()
        cb_MOTIVON3ID.Items.Clear()

        If ReadDBGETMOTIVOSNIVEL2PARADAS(cb_MOTIVON1ID.SelectedItem, cb_MOTIVON2, cb_MOTIVON2ID, strERROR) = False Then
            Beep()
            MsgBox("Falha na Leitura do Motivo de Parada Nível 2!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Leitura Motivo Parada")
        Else
            cb_MOTIVON2.Enabled = True
        End If

    End Sub
    Private Sub cb_MOTIVON2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVON2.SelectedIndexChanged

        cb_MOTIVON2ID.SelectedIndex = cb_MOTIVON2.SelectedIndex
        cb_MOTIVON3.Items.Clear()
        cb_MOTIVON3ID.Items.Clear()

        If ReadDBGETMOTIVOSNIVEL3PARADAS(cb_MOTIVON2ID.SelectedItem, cb_MOTIVON3, cb_MOTIVON3ID, strERROR) = False Then
            Beep()
            MsgBox("Falha na Leitura do Motivo de Parada Nível 3!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Leitura Motivo Parada")
        Else
            cb_MOTIVON3.Enabled = True
        End If

    End Sub
    Private Sub cb_MOTIVON3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MOTIVON3.SelectedIndexChanged

        cb_MOTIVON3ID.SelectedIndex = cb_MOTIVON3.SelectedIndex

    End Sub
    Private Sub lb_MAQUINAS_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_MAQUINAS.ItemCheck

        For intC = 0 To lb_MAQUINASID.Items.Count - 1
            lb_MAQUINASID.SetItemCheckState(intC, 0)
        Next
        If lb_MAQUINAS.CheckedItems.Count > 0 Then
            bt_PARADAS.Enabled = True
        Else
            bt_PARADAS.Enabled = False
        End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cb_MOTIVON1.SelectedIndex = -1
        cb_MOTIVON2.Enabled = False
        cb_MOTIVON3.Enabled = False

    End Sub

End Class