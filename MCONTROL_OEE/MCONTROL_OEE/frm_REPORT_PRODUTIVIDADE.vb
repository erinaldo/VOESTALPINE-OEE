Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.IO
Public Class frm_REPORT_PRODUTIVIDADE
    Private Sub frm_REPORT_PRODUTIVIDADE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim newPageSettings As New System.Drawing.Printing.PageSettings
        Dim DSource As New ReportDataSource
        Dim dtsREPORT As New DataSet
        Dim dtsACCESS As New DataSet
        Dim dtsALARMS As New DataSet
        Dim dtsKEYS As New DataSet
        Dim dtsLOCK As New DataSet
        Dim cmdRead As String = Nothing
        Dim strConn As String = Nothing
        Dim conSQL As SqlConnection

        Dim Param1 As New ReportParameter("rpTONELAGEM", reportTONELAGEM)
        Dim Param2 As New ReportParameter("rpDATAINICIAL", reportDATAINICIAL)
        Dim Param3 As New ReportParameter("rpDATAFINAL", reportDATAFINAL)
        Dim Param4 As New ReportParameter("rpMAQUINA", reportMAQUINA)
        Dim Param5 As New ReportParameter("rpMETROS", reportMETROS)
        Dim Param6 As New ReportParameter("rpTEMPOUTIL", sreportHORASTEMPOUTIL)
        Dim Param7 As New ReportParameter("rpTEMPOUTIL_PERCENTUAL", reportHORASTEMPOUTILPERCENTUAL)
        Dim Param8 As New ReportParameter("rpSETUP", sreportHORASSETUP)
        Dim Param9 As New ReportParameter("rpSETUP_PERCENTUAL", reportHORASSETUPPERCENTUAL)
        Dim Param10 As New ReportParameter("rpTESTES", reportHORASTESTE)
        Dim Param11 As New ReportParameter("rpTESTES_PERCENTUAL", reportHORASTESTEPERCENTUAL)
        Dim Param12 As New ReportParameter("rpPARADAS", sreportHORASPARADA)
        Dim Param13 As New ReportParameter("rpPARADAS_PERCENTUAL", reportHORASPARADAPERCENTUAL)
        Dim Param14 As New ReportParameter("rpTEMPODISPONIVEL", sreportHORASDISPONIVEL)
        Dim Param15 As New ReportParameter("rpDISPONIBILIDADE_PERCENTUAL", reportDISPONIBILIDADE)

        rv_REPORT.LocalReport.ReportEmbeddedResource = "MCONTROL_OEE.report_PRODUTIVIDADE.rdlc"
        rv_REPORT.LocalReport.SetParameters(Param1)
        rv_REPORT.LocalReport.SetParameters(Param2)
        rv_REPORT.LocalReport.SetParameters(Param3)
        rv_REPORT.LocalReport.SetParameters(Param4)
        rv_REPORT.LocalReport.SetParameters(Param5)
        rv_REPORT.LocalReport.SetParameters(Param6)
        rv_REPORT.LocalReport.SetParameters(Param7)
        rv_REPORT.LocalReport.SetParameters(Param8)
        rv_REPORT.LocalReport.SetParameters(Param9)
        rv_REPORT.LocalReport.SetParameters(Param10)
        rv_REPORT.LocalReport.SetParameters(Param11)
        rv_REPORT.LocalReport.SetParameters(Param12)
        rv_REPORT.LocalReport.SetParameters(Param13)
        rv_REPORT.LocalReport.SetParameters(Param14)
        rv_REPORT.LocalReport.SetParameters(Param15)

        strConn = "Data Source=" & strDataSource &
                  ";Initial Catalog=oViewer;" &
                  "User ID=oVViewers;Password=@allexoNew2017"
        conSQL = New SqlConnection(strConn)
        conSQL.Open()

        cmdRead = "SELECT * FROM [dbo].[exe_MCONTROL_OEE_report_produtividade] WHERE [userid] = " & intUSERID
        Dim sqlaREPORT As New SqlDataAdapter(cmdRead, conSQL)
        sqlaREPORT.Fill(dtsREPORT, "Report")
        rv_REPORT.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", dtsREPORT.Tables(0)))
        conSQL.Close()

        rv_REPORT.AutoSizeMode = AutoSizeMode.GrowAndShrink
        'newPageSettings.Margins = New System.Drawing.Printing.Margins(20, 10, 10, 10)
        'rv_REPORT.SetPageSettings(newPageSettings)
        Me.rv_REPORT.RefreshReport()

    End Sub

End Class