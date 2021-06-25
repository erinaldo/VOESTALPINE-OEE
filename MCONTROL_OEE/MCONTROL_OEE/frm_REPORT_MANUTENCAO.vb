Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.IO
Public Class frm_REPORT_MANUTENCAO
    Private Sub frm_REPORT_MANUTENCAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim newPageSettings As New System.Drawing.Printing.PageSettings
        Dim Param1 As New ReportParameter("rpDATAINICIAL", reportDATAINICIAL)
        Dim Param2 As New ReportParameter("rpDATAFINAL", reportDATAFINAL)
        Dim Param3 As New ReportParameter("rpMAQUINA", reportMAQUINA)
        Dim Param4 As New ReportParameter("rpMTBF", sreportMTBF)
        Dim Param5 As New ReportParameter("rpMTTR", sreportMTTR)
        Dim Param6 As New ReportParameter("rpDISPONIBILIDADE", reportDISPONIBILIDADE)
        Dim Param7 As New ReportParameter("rpMTAM", sreportMTAM)

        rv_REPORT.LocalReport.ReportEmbeddedResource = "MCONTROL_OEE.report_MANUTENCAO.rdlc"
        rv_REPORT.LocalReport.SetParameters(Param1)
        rv_REPORT.LocalReport.SetParameters(Param2)
        rv_REPORT.LocalReport.SetParameters(Param3)
        rv_REPORT.LocalReport.SetParameters(Param4)
        rv_REPORT.LocalReport.SetParameters(Param5)
        rv_REPORT.LocalReport.SetParameters(Param6)
        rv_REPORT.LocalReport.SetParameters(Param7)

        newPageSettings.Margins = New System.Drawing.Printing.Margins(20, 10, 10, 10)
        rv_REPORT.SetPageSettings(newPageSettings)
        Me.rv_REPORT.RefreshReport()

    End Sub

End Class