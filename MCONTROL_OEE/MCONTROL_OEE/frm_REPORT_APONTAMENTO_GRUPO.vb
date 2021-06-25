﻿Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.IO
Public Class frm_REPORT_APONTAMENTO_GRUPO
    Private Sub frm_REPORT_APONTAMENTO_GRUPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim newPageSettings As New System.Drawing.Printing.PageSettings
        Dim DSource As New ReportDataSource
        Dim dtsREPORT As New DataSet
        Dim cmdRead As String = Nothing
        Dim strConn As String = Nothing
        Dim conSQL As SqlConnection

        Dim Param1 As New ReportParameter("rpDATAINICIAL", reportDATAINICIAL)
        Dim Param2 As New ReportParameter("rpDATAFINAL", reportDATAFINAL)
        Dim Param3 As New ReportParameter("rpDIASUTEIS", reportDIASUTEIS)
        Dim Param4 As New ReportParameter("rpTOTALDIASUTEIS", reportTOTALDIASUTEIS)

        rv_REPORT.LocalReport.ReportEmbeddedResource = "MCONTROL_OEE.report_APONTAMENTO_GRUPO.rdlc"
        rv_REPORT.LocalReport.SetParameters(Param1)
        rv_REPORT.LocalReport.SetParameters(Param2)
        rv_REPORT.LocalReport.SetParameters(Param3)
        rv_REPORT.LocalReport.SetParameters(Param4)

        strConn = "Data Source=" & strDataSource &
                  ";Initial Catalog=oViewer;" &
                  "User ID=oVViewers;Password=@allexoNew2017"
        conSQL = New SqlConnection(strConn)
        conSQL.Open()

        cmdRead = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_report_apontamento_grupomaquinas] WHERE [userid] = " & intUSERID & "ORDER BY grupomaster, grupomaquina, maquina"
        Dim sqlaREPORT As New SqlDataAdapter(cmdRead, conSQL)
        sqlaREPORT.Fill(dtsREPORT, "Report")
        rv_REPORT.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", dtsREPORT.Tables(0)))
        conSQL.Close()

        rv_REPORT.AutoSizeMode = AutoSizeMode.GrowAndShrink
        'newPageSettings.Margins = New System.Drawing.Printing.Margins(20, 10, 10, 10)
        'newPageSettings.Landscape = True
        'rv_REPORT.SetPageSettings(newPageSettings)
        Me.rv_REPORT.RefreshReport()


    End Sub
End Class