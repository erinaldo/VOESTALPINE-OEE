ECHO OFF

REM Inicio do Batch
REM Remove todos os arquivos e diretórios dentro da pasta omniViewer

REM SET FOLDER="C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE"
REM CD /D %FOLDER%
REM FOR /F "DELIMS=" %%i IN ('DIR /B') DO (RMDIR "%%i" /S/Q || DEL "%%i" /S/Q)

REM Copia arquivos do MCONTROL_OEE

XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\MCONTROL_OEE\bin\Debug\MCONTROL_OEE.exe.config" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\MCONTROL_OEE\bin\Debug\MCONTROL_OEE.exe" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\MCONTROL_OEE\bin\Debug\clsMCONTROL_OEE_img.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\Program Files (x86)\DotNetBar for Windows Forms\DevComponents.DotNetBar.Charts.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\Program Files (x86)\DotNetBar for Windows Forms\DevComponents.DotNetBar.SuperGrid.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\Program Files (x86)\DotNetBar for Windows Forms\DevComponents.DotNetBar2.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\Program Files (x86)\DotNetBar for Windows Forms\DevComponents.Instrumentation.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\Program Files (x86)\DotNetBar for Windows Forms\DevComponents.DotNetBar.Schedule.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.ReportingServices.ReportViewerControl.Winforms.140.1000.523\lib\net40\Microsoft.ReportViewer.Common.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.ReportingServices.ReportViewerControl.Winforms.140.1000.523\lib\net40\Microsoft.ReportViewer.DataVisualization.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.ReportingServices.ReportViewerControl.Winforms.140.1000.523\lib\net40\Microsoft.ReportViewer.Design.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.ReportingServices.ReportViewerControl.Winforms.140.1000.523\lib\net40\Microsoft.ReportViewer.ProcessingObjectModel.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.ReportingServices.ReportViewerControl.Winforms.140.1000.523\lib\net40\Microsoft.ReportViewer.WinForms.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\packages\Microsoft.SqlServer.Types.14.0.314.76\lib\net40\Microsoft.SqlServer.Types.dll" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\"
MKDIR "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\applog"
MKDIR "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\reports"
MKDIR "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\xml"
XCOPY "C:\VOESTALPINE - DEV\MCONTROL_OEE\MCONTROL_OEE\bin\Debug\xml\*.xml" "C:\VOESTALPINE - DEV\_DEPLOY\MCONTROL_OEE\xml\"