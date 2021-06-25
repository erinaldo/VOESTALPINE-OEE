Public Class frmWAIT
    Private Sub FrmWAIT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cp_PROGRESS.IsRunning = True
        tmr_REPORT.Enabled = True

    End Sub
    Private Sub Tmr_REPORT_Tick(sender As Object, e As EventArgs) Handles tmr_REPORT.Tick

        If bolREPORTOK = True Then
            tmr_REPORT.Enabled = False
            bolREPORTOK = False
            Me.Close()
        End If

    End Sub

End Class