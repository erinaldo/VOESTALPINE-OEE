Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.IO
Public Class frm_REPORT_AMARRADOS_SEMTURNO
    Private Sub frm_REPORT_AMARRADOS_SEMTURNO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim newPageSettings As New System.Drawing.Printing.PageSettings
        Dim DSource As New ReportDataSource
        Dim dtsREPORT As New DataSet
        Dim cmdRead As String = Nothing
        Dim strConn As String = Nothing
        Dim conSQL As SqlConnection

        rv_REPORT.LocalReport.ReportEmbeddedResource = "MCONTROL_OEE.report_AMARRADO_SEM_TC.rdlc"

        strConn = "Data Source=" & strDataSource &
                  ";Initial Catalog=oViewer;" &
                  "User ID=oVViewers;Password=@allexoNew2017"
        conSQL = New SqlConnection(strConn)
        conSQL.Open()

        cmdRead = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_report_amarrados_semturno] WHERE [user_id] = " & intUSERID & " ORDER BY [id]"
        Dim sqlaREPORT As New SqlDataAdapter(cmdRead, conSQL)
        sqlaREPORT.Fill(dtsREPORT, "Report")
        rv_REPORT.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", dtsREPORT.Tables(0)))
        conSQL.Close()

        newPageSettings.Margins = New System.Drawing.Printing.Margins(20, 10, 10, 10)
        newPageSettings.Landscape = True
        rv_REPORT.SetPageSettings(newPageSettings)
        Me.rv_REPORT.RefreshReport()

    End Sub

End Class