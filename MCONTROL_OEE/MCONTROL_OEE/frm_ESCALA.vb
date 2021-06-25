Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_ESCALA

    Private strDATAINICIAL As String = False
    Private strDATAFINAL As String = Nothing
    Private strTURNOTAG As String = Nothing
    Private strPERIODO As String = Nothing
    Private strTIMEMARKED As String = Nothing
    Private taskResult As eTaskDialogResult
    Private strTIMETURNOS(99, 3) As String
    Private dtimeBLOQUEIO As DateTime = Nothing
    Private Sub frm_ESCALA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIALPESQUISA.Value = Now()
        dti_DFINALPESQUISA.Value = DateAdd(DateInterval.Day, 30, Now())

        bolFRMINI = True
        If ReadDBGETMACHINEMOTIVOS(cb_MAQUINA, cb_MAQUINAID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If
        bolFRMINI = False

    End Sub
    Private Sub bt_TURNO_Click(sender As Object, e As EventArgs) Handles bt_TURNO.Click

        Dim F1 As New frm_TURNO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_TURNO", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_TURNO.Enabled = True
            Me.Enabled = False
            bolFRMINI = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_TURNO_Tick(sender As Object, e As EventArgs) Handles tmr_TURNO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_TURNO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_TURNO.Enabled = False
            Me.Enabled = True
            cb_TURNO.Items.Clear()
            cb_TURNOID.Items.Clear()
            dti_HINICIAL1.Text = Nothing
            dti_HFINAL1.Text = Nothing
            dti_HINICIAL1.Enabled = False
            dti_HFINAL1.Enabled = False
            If ReadDBGETTURNOS(cb_MAQUINAID.SelectedItem, cb_TURNO, cb_TURNOID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()


    End Sub
    Private Sub bt_ADICIONARPERIODO_Click(sender As Object, e As EventArgs) Handles bt_ADICIONARPERIODO.Click

        Dim dateINICIAL As Date
        Dim dateFINAL As Date
        Dim intDAYS As Integer = 0

        If dti_HINICIAL1.Value = Nothing Or dti_HFINAL1.Value = Nothing Then
            Alert("Informar pelo menos a <b>HORA INICIAL</b> e <b>HORA FINAL</b> do primeiro período!", 10, True)
            Exit Sub
        End If

        If dti_DINICIALADD.Value = Nothing Or dti_DFINALADD.Value = Nothing Then
            Alert("Informar <b>DATA INICIAL</b> e <b>DATA FINAL</b> do período para gerar a escala!", 10, True)
            Exit Sub
        End If

        dateINICIAL = Convert.ToDateTime(dti_DINICIALADD.Text)
        dateFINAL = Convert.ToDateTime(dti_DFINALADD.Text)
        intDAYS = DateDiff(DateInterval.Day, dateINICIAL, dateFINAL)
        If intDAYS < 0 Then
            Alert("A <b>DATA FINAL</b> deve ser igual ou maior que a <b>DATA INICIAL<b>!", 5, True)
            Exit Sub
        End If

        'TURNO 1
        '///////
        dateINICIAL = Convert.ToDateTime(dti_DINICIALADD.Text & " " & dti_HINICIAL1.Text)
        dateFINAL = Convert.ToDateTime(dti_DFINALADD.Text & " " & dti_HFINAL1.Text)
        intDAYS = DateDiff(DateInterval.Minute, dateINICIAL, dateFINAL)
        If intDAYS < 0 Then
            Alert("A <b>HORA FINAL</b> do <b>PRIMEIRO PERÍODO</b> deve ser maior que a <b>HORA INICIAL</b>!", 5, True)
            Exit Sub
        End If

        If cb_TURNO.SelectedIndex < 0 Then
            Alert("Selecione primeiro o <b>TURNO</b> à ser inserido!", 5, True)
            Exit Sub
        End If

        If WriteDBINCLUIRTURNO(cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex), cb_TURNOID.Items(cb_TURNOID.SelectedIndex), cb_FIMDESEMANA.Checked,
                               dti_DINICIALADD.Text, dti_DFINALADD.Text, dti_HINICIAL1.Text, dti_HFINAL1.Text, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Turno <b>" & cb_TURNO.Items(cb_TURNO.SelectedIndex) & "</b> incluído com sucesso!", 5)
            WriteDBUSERLOG("ESCALA DE TRABALHO incluída")
        End If

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        gb_INCLUIRPERIODOS.Enabled = True
        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex
        bt_ATUALIZARESCALA.Enabled = True
        bt_TURNO.Enabled = True
        bt_DEFINIRPERIODO.Enabled = True
        intMACHINEID = cb_MAQUINAID.SelectedItem
        If ReadDBGETTURNOSESCALA(intMACHINEID, cb_TURNO, cb_TURNOID, strTIMETURNOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            bt_ADICIONARPERIODO.Enabled = False
            cv_ESCALA.CalendarModel.Appointments.Clear()
        End If

    End Sub
    Private Sub cb_TURNO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_TURNO.SelectedIndexChanged

        cb_TURNOID.SelectedIndex = cb_TURNO.SelectedIndex
        dti_DINICIALADD.Enabled = True
        dti_DFINALADD.Enabled = True
        dti_HINICIAL1.Enabled = True
        dti_HFINAL1.Enabled = True
        bt_ADICIONARPERIODO.Enabled = True

    End Sub
    Private Sub bt_ATUALIZARESCALA_Click(sender As Object, e As EventArgs) Handles bt_ATUALIZARESCALA.Click

        cv_ESCALA.CalendarModel.Appointments.Clear()
        If ReadDBGETSCHEDULE(cv_ESCALA, cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex),
                             dti_DINICIALPESQUISA.Text, dti_DFINALPESQUISA.Text, dtimeBLOQUEIO, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If cv_ESCALA.CalendarModel.Appointments.Count > 0 Then
                cb_TIPOESCALA.Enabled = True
                cb_TIPOESCALA.SelectedIndex = 3
                bt_EXCLUIR.Enabled = True
            Else
                cb_TIPOESCALA.Enabled = False
                cb_TIPOESCALA.SelectedIndex = -1
                bt_EXCLUIR.Enabled = False
            End If
        End If

    End Sub
    Private Sub cb_TIPOESCALA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_TIPOESCALA.SelectedIndexChanged

        If cb_TIPOESCALA.SelectedIndex = 0 Then
            cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Year
        ElseIf cb_TIPOESCALA.SelectedIndex = 1 Then
            cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day
        ElseIf cb_TIPOESCALA.SelectedIndex = 2 Then
            cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month
        ElseIf cb_TIPOESCALA.SelectedIndex = 3 Then
            cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week
        ElseIf cb_TIPOESCALA.SelectedIndex = 4 Then
            cv_ESCALA.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.TimeLine
        End If

    End Sub
    Private Sub cv_SCHEDULE_ItemClick(sender As Object, e As EventArgs) Handles cv_ESCALA.ItemClick

        Dim appESCALA As DevComponents.Schedule.Model.Appointment

        Try

            appESCALA = cv_ESCALA.SelectedAppointments.Item(0).ModelItem
            strDATAINICIAL = appESCALA.StartTime.ToString
            strDATAFINAL = appESCALA.EndTime.ToString
            strTURNOTAG = appESCALA.Tag
            strPERIODO = appESCALA.Subject

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ExcluirPeríodoDeFuncionamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRPERIODO.Click

        Dim bolFOUND As Boolean = False

        If cv_ESCALA.SelectedAppointments.Count > 0 Then
            sMessageBox("A", "Excluir Escala de Trabalho",
                        "Deseja realmente <b>EXCLUIR</b> a Escala de Trabalho " & strPERIODO & " com Data/Hora Inicial = " &
                        strDATAINICIAL & " e Data/Hora Final = " & strDATAFINAL & "?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                If ReadDBGETPARADAESCALA(cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex), strTURNOTAG, bolFOUND, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolFOUND = True Then
                        sMessageBox("Q", "Produção Registrada",
                                    "Um ou mais APONTAMENTOS DE PRODUÇÃO estão registrados neste período de Escala. Deseja realmente <b>EXCLUIR</b> a Escala de Trabalho?", taskResult)
                        If taskResult <> eTaskDialogResult.Yes Then
                            Exit Sub
                        End If
                    End If
                    If WriteDBDELETETAG(cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex), strTURNOTAG, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    Else
                        For intC = cv_ESCALA.CalendarModel.Appointments.Count - 1 To 0 Step -1
                            If cv_ESCALA.CalendarModel.Appointments(intC).Tag = strTURNOTAG Then
                                cv_ESCALA.CalendarModel.Appointments.RemoveAt(intC)
                            End If
                        Next
                        Information("Período Excluído com Sucesso!", 5)
                        WriteDBUSERLOG("PERÍODO DE TRABALHO excluído")
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub cms_CV_Opening(sender As Object, e As CancelEventArgs) Handles cms_CV.Opening

        If cv_ESCALA.SelectedAppointments.Count > 0 Then
            If dtimeBLOQUEIO = Nothing Then
                bt_EXCLUIRPERIODO.Enabled = True
            Else
                If DateDiff(DateInterval.Minute, Convert.ToDateTime(strDATAFINAL), dtimeBLOQUEIO) < 0 Then
                    bt_EXCLUIRPERIODO.Enabled = True
                Else
                    bt_EXCLUIRPERIODO.Enabled = False
                End If
            End If
        End If

    End Sub
    Private Sub bt_EXCLUIR_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIR.Click

        Dim F1 As New frm_ESCALA_EXCLUIR
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_ESCALA_EXCLUIR", bolOpen, intIndex)
        intMACHINEID = cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex)
        strMACHINEREFNAME = cb_MAQUINA.Items(cb_MAQUINA.SelectedIndex)
        If bolOpen = False Then
            tmr_ESCALA.Enabled = True
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
    Private Sub tmr_ESCALA_Tick(sender As Object, e As EventArgs) Handles tmr_ESCALA.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_ESCALA_EXCLUIR" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_ESCALA.Enabled = False
            cv_ESCALA.CalendarModel.Appointments.Clear()
            If ReadDBGETSCHEDULE(cv_ESCALA, cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex),
                                 dti_DINICIALPESQUISA.Text, dti_DFINALPESQUISA.Text, dtimeBLOQUEIO, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If cv_ESCALA.CalendarModel.Appointments.Count > 0 Then
                    cb_TIPOESCALA.Enabled = True
                    cb_TIPOESCALA.SelectedIndex = 3
                    bt_EXCLUIR.Enabled = True
                Else
                    cb_TIPOESCALA.Enabled = False
                    cb_TIPOESCALA.SelectedIndex = -1
                    bt_EXCLUIR.Enabled = False
                End If
            End If
            Me.Enabled = True
        End If

    End Sub
    Private Sub frm_ESCALA_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolFRMINI = True

    End Sub
    Private Sub bt_DEFINIRPERIODO_Click(sender As Object, e As EventArgs) Handles bt_DEFINIRPERIODO.Click

        Dim F1 As New frm_DEFINIRPERIODO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_DEFINIRPERIODO", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_DEFINIRPERIODO.Enabled = True
            Me.Enabled = False
            bolFRMINI = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_DEFINIRPERIODO_Tick(sender As Object, e As EventArgs) Handles tmr_DEFINIRPERIODO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_DEFINIRPERIODO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_DEFINIRPERIODO.Enabled = False
            Me.Enabled = True
        End If

    End Sub

End Class