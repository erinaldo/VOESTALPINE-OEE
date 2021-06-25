Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_BLOQUEIO

    Private strDATAINICIAL As String = False
    Private strDATAFINAL As String = Nothing
    Private strTURNOTAG As String = Nothing
    Private strPERIODO As String = Nothing
    Private dtimeBLOQUEIO As DateTime = Nothing
    Private taskResult As eTaskDialogResult
    Private Sub frm_BLOQUEIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIALPESQUISA.Value = Now()
        dti_DFINALPESQUISA.Value = DateAdd(DateInterval.Day, 30, Now())

        bolFRMINI = True
        If ReadDBGETMACHINEMOTIVOS(cb_MAQUINA, cb_MAQUINAID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If
        bolFRMINI = False

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex

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
            Else
                cb_TIPOESCALA.Enabled = False
                cb_TIPOESCALA.SelectedIndex = -1
            End If
        End If

    End Sub
    Private Sub cv_ESCALA_ItemClick(sender As Object, e As EventArgs) Handles cv_ESCALA.ItemClick

        Dim appESCALA As DevComponents.Schedule.Model.Appointment

        Try

            appESCALA = cv_ESCALA.SelectedAppointments.Item(0).ModelItem
            strDATAINICIAL = appESCALA.StartTime.ToString
            strDATAFINAL = appESCALA.EndTime.ToString
            strTURNOTAG = appESCALA.Tag
            strPERIODO = appESCALA.Subject
            bt_BLOQUEAR.Enabled = True

        Catch ex As Exception

        End Try

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
    Private Sub bt_BLOQUEAR_Click(sender As Object, e As EventArgs) Handles bt_BLOQUEAR.Click

        sMessageBox("Q", "Bloquerar Registros",
                    "Deseja realmente <b>BLOQUEAR TEMPO CALENDÁRIO</b> e <b>PARADAS REGISTRADAS</b> até do dia/horário " & strDATAFINAL & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If WriteDBBLOQUEARTEMPOCALENDARIO(cb_MAQUINAID.SelectedItem, strDATAFINAL, strERROR) = False Then
                Alert(strERROR, 5)
            Else
                cv_ESCALA.CalendarModel.Appointments.Clear()
                If ReadDBGETSCHEDULE(cv_ESCALA, cb_MAQUINAID.Items(cb_MAQUINAID.SelectedIndex),
                             dti_DINICIALPESQUISA.Text, dti_DFINALPESQUISA.Text, dtimeBLOQUEIO, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If cv_ESCALA.CalendarModel.Appointments.Count > 0 Then
                        cb_TIPOESCALA.Enabled = True
                        cb_TIPOESCALA.SelectedIndex = 3
                    Else
                        cb_TIPOESCALA.Enabled = False
                        cb_TIPOESCALA.SelectedIndex = -1
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub

End Class