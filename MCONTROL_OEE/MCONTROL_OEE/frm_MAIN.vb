Imports System.Data.Sql
Imports DevComponents.DotNetBar
Imports System.Net
Imports System.ComponentModel

Public Class frm_MAIN

    Private taskResult As eTaskDialogResult
    Private Sub frm_MAIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If xmlGetDataSource(strDataSource) = False Then
            Alert("Falha interna da função <b>mod_OEE.xmlGetDataSource</b>!", 5)
            ErrorLog(strERROR)
            Exit Sub
        End If
        Me.Text = "Allexo - Sistema OEE - v. " & strViewerVersion & " (" & strAppRevision & ")"

    End Sub
    Private Sub tmr_MAQUINAS_Tick(sender As Object, e As EventArgs) Handles tmr_MAQUINAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MAQUINAS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MAQUINAS.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_PARADAS_Click(sender As Object, e As EventArgs) Handles bt_PARADAS.Click

        Dim F1 As New frm_MOTIVOPARADAS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MOTIVOPARADAS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_MOTIVOPARADAS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_MOTIVOPARADAS_Tick(sender As Object, e As EventArgs) Handles tmr_MOTIVOPARADAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MOTIVOPARADAS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MOTIVOPARADAS.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_OPERADORES_Click(sender As Object, e As EventArgs) Handles bt_OPERADORES.Click

        Dim F1 As New frm_OPERADORES
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_OPERADORES", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_OPERADORES.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_OPERADORES_Tick(sender As Object, e As EventArgs) Handles tmr_OPERADORES.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_OPERADORES" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_OPERADORES.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub tmr_ESCALA_Tick(sender As Object, e As EventArgs) Handles tmr_ESCALA.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_ESCALA" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_OPERADORES.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_HISTORICOPARADAS_Click(sender As Object, e As EventArgs) Handles bt_HISTORICOPARADAS.Click

        Dim F1 As New frm_HISTORICOPARADAS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_HISTORICOPARADAS", bolOpen, intIndex)
        If bolOpen = False Then
            bolEDITARPARADAS = False
            tmr_HISTORICOPARADAS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_HISTORICOPARADAS_Tick(sender As Object, e As EventArgs) Handles tmr_HISTORICOPARADAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_HISTORICOPARADAS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_HISTORICOPARADAS.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles bt_EDITARPARADAS.Click

        Dim F1 As New frm_HISTORICOPARADAS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolEDITARPARADAS = True
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_HISTORICOPARADAS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_HISTORICOPARADAS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_LOGOUT1_Click(sender As Object, e As EventArgs) Handles bt_LOGOUT1.Click

        Dim strErro As String = ""

        Try

            sMessageBox("Q", "Logout do Aplicativo", "Deseja realmente fazer <b>logout</b>?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                WriteDBUSERLOG("Logout realizado")
                Me.Enabled = False
                frm_LOGIN.Show()
            Else
                Me.Enabled = True
            End If

        Catch ex As Exception

            strErro = "Falha interna da função <b>frm_MAIN.bt_LOGOUT_Click</b>!"
            Alert(strErro, 5)
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub bt_LOGOUT2_Click(sender As Object, e As EventArgs) Handles bt_LOGOUT2.Click

        Dim strErro As String = ""

        Try

            sMessageBox("Q", "Logout do Aplicativo", "Deseja realmente fazer <b>logout</b>?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                WriteDBUSERLOG("Logout realizado")
                Me.Enabled = False
                frm_LOGIN.Show()
            Else
                Me.Enabled = True
            End If

        Catch ex As Exception

            strErro = "Falha interna da função <b>frm_MAIN.bt_LOGOUT_Click</b>!"
            Alert(strErro, 5)
            ErrorLog(strErro)
            ErrorLog(ex.ToString)

        End Try

    End Sub
    Private Sub bt_SAIR2_Click(sender As Object, e As EventArgs) Handles bt_SAIR2.Click

        Me.Close()

    End Sub
    Private Sub bt_SAIR1_Click(sender As Object, e As EventArgs) Handles bt_SAIR1.Click

        Me.Close()

    End Sub
    Private Sub frm_MAIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        sMessageBox("Q", "Saída do Sistema", "Confirma saída do Aplicativo?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            WriteDBUSERLOG("Saída do Aplicativo")
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub
    Private Sub bt_USUARIOS_Click(sender As Object, e As EventArgs) Handles bt_USUARIOS.Click

        Dim F1 As New frm_PERFILUSUÁRIOS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolEDITARPARADAS = True
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_PERFILUSUÁRIOS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_PERFIL.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_PERFIL_Tick(sender As Object, e As EventArgs) Handles tmr_PERFIL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_PERFILUSUÁRIOS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_PERFIL.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub tmr_REPORT_PARETO_Tick(sender As Object, e As EventArgs) Handles tmr_CHART_PARETO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_CHART_PARETO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_PERFIL.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_PARETO_Click_1(sender As Object, e As EventArgs) Handles bt_PARETO.Click

        Dim F1 As New frm_CHART_PARETO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolEDITARPARADAS = True
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_CHART_PARETO", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_CHART_PARETO.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_ONLINE_Click(sender As Object, e As EventArgs) Handles bt_ONLINE.Click

        Dim intFORMS As Integer = 0

        If ReadDBONLINE(intFORMS, cb_MDIPARENT.Checked, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If intFORMS > 0 Then
                tmr_ONLINE.Enabled = True
                bt_ONLINE.Enabled = False
                bt_CLOSEONLINE.Enabled = True
            End If
        End If

    End Sub
    Private Sub tmr_ONLINE_Tick(sender As Object, e As EventArgs) Handles tmr_ONLINE.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_ONLINE" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_ONLINE.Enabled = False
            bt_ONLINE.Enabled = True
            bt_CLOSEONLINE.Enabled = False
        End If

    End Sub
    Private Sub bt_LOG_Click(sender As Object, e As EventArgs)

        Dim F1 As New frm_LOGUSER
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_LOGUSER", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_LOGUSER.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_LOGUSER_Tick(sender As Object, e As EventArgs) Handles tmr_LOGUSER.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_LOGUSER" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_LOGUSER.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub tmr_PRODUTIVIDADE_Tick(sender As Object, e As EventArgs) Handles tmr_PRODUTIVIDADE.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_PRODUTIVIDADE" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_PRODUTIVIDADE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub tmr_MANUTENCAO_Tick(sender As Object, e As EventArgs) Handles tmr_MANUTENCAO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MANUTENCAO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MANUTENCAO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_CONFIGMANUTENCAO_Click(sender As Object, e As EventArgs) Handles bt_CONFIGMANUTENCAO.Click

        Dim F1 As New frm_MANUTENCAO_CONFIG
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MANUTENCAO_CONFIG", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MANUTENCAOCONFIG.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_MANUTENCAOCONFIG_Tick(sender As Object, e As EventArgs) Handles tmr_MANUTENCAOCONFIG.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MANUTENCAO_CONFIG" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MANUTENCAO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_CLOSEONLINE_Click(sender As Object, e As EventArgs) Handles bt_CLOSEONLINE.Click

        Dim FL1 As New frm_ONLINE

        Dim frmCollection = System.Windows.Forms.Application.OpenForms
        For i = frmCollection.Count - 1 To 0 Step -1
            If frmCollection.Item(i).Name = FL1.Name Then
                frmCollection.Item(i).Close()
            End If
        Next i
        bt_ONLINE.Enabled = True
        bt_CLOSEONLINE.Enabled = False

    End Sub
    Private Sub bt_TILEV2_Click(sender As Object, e As EventArgs) Handles bt_TILEV2.Click

        Me.LayoutMdi(MdiLayout.TileVertical)

    End Sub
    Private Sub bt_TILEH2_Click(sender As Object, e As EventArgs) Handles bt_TILEH2.Click

        Me.LayoutMdi(MdiLayout.TileHorizontal)

    End Sub
    Private Sub tmr_APONTAMENTO_Tick(sender As Object, e As EventArgs) Handles tmr_APONTAMENTO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim strERROR As String = Nothing

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_APONTAMENTODIARIO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub tmr_MAQUINASGRUPO_Tick(sender As Object, e As EventArgs) Handles tmr_MAQUINASGRUPO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MAQUINAS_GRUPO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_MAQUINASGRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_APTMAQUINA_Click(sender As Object, e As EventArgs) Handles bt_APTMAQUINA.Click

        Dim F1 As New frm_APONTAMENTODIARIO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_APONTAMENTODIARIO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_APONTAMENTO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_APONTAMENTO_GRUPO_Tick(sender As Object, e As EventArgs) Handles tmr_APONTAMENTO_GRUPO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_APONTAMENTO_GRUPO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO_GRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click

        Dim F1 As New frm_FERIADOS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_FERIADOS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_FERIADOS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_FERIADOS_Tick(sender As Object, e As EventArgs) Handles tmr_FERIADOS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_FERIADOS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO_GRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_REPORT_TEMPOLCALENDARIO_Click(sender As Object, e As EventArgs) Handles bt_REPORT_TEMPOLCALENDARIO.Click

        Dim F1 As New frm_TEMPOCALENDARIO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_TEMPOCALENDARIO", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_TEMPOCALENDARIO.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_TEMPOCALENDARIO_Tick(sender As Object, e As EventArgs) Handles tmr_TEMPOCALENDARIO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_TEMPOCALENDARIO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO_GRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click

        Dim F1 As New frm_PRODUTIVIDADE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolRELATORIOLIVRE = True
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_PRODUTIVIDADE", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_PRODUTIVIDADE.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub ButtonItem1_Click_1(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Dim F1 As New frm_APONTAMENTODIARIO_GRUPO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_APONTAMENTODIARIO_GRUPO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_APONTAMENTO_GRUPO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        Dim F1 As New frm_PRODUTIVIDADE_ANOFISCAL
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_PRODUTIVIDADE_ANOFISCAL", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_PRODUTIVIDADE_ANOFISCAL.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_PRODUTIVIDADE_ANOFISCAL_Tick(sender As Object, e As EventArgs) Handles tmr_PRODUTIVIDADE_ANOFISCAL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_PRODUTIVIDADE_ANOFISCAL" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO_GRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click

        Dim F1 As New frm_PRODUTIVIDADE_MENSAL
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_PRODUTIVIDADE_MENSAL", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_PRODUTIVIDADE_MENSAL.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_PRODUTIVIDADE_MENSAL_Tick(sender As Object, e As EventArgs) Handles tmr_PRODUTIVIDADE_MENSAL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_PRODUTIVIDADE_MENSAL" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_PRODUTIVIDADE_MENSAL.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_REPORTPRODUTIVIDADE_DIARIO.Enabled = True
        F1.Show()
        If WriteDBREPORTPRODUTIVIDADE_GRUPO_DIARIO(strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTPRODUTIVIDADE_DIARIO_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTPRODUTIVIDADE_DIARIO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_PRODUTIVIDADE_GRUPO

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frmWAIT" Then
                bolFound = True
                Exit For
            End If
        Next

        If bolFound = False Then
            tmr_REPORTPRODUTIVIDADE_DIARIO.Enabled = False
            Me.Enabled = True
            F1.Show()
        End If

    End Sub
    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click

        Dim F1 As New frm_ESCALA
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_ESCALA", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_ESCALA.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click

        Dim F1 As New frm_ATUALIZARIMEDIATAMENTE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        sMessageBox("Q", "Atualizar TEMPO CALENDARIO IMEDIATAMENTE", "Deseja realmente <b>ATUALIZAR IMEDIATAMENTE</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then

            WriteDBTCOK(1)
            ribPanel_CONFIG.Enabled = False
            ribPanel_MAIN.Enabled = False
            ribPanel_REPORT.Enabled = False
            ribPanel_GRAFICOS.Enabled = False
            CheckFormisAlreadyOpen("MCONTROL_OEE.frm_ATUALIZARIMEDIATAMENTE", bolOpen, intIndex)
            If bolOpen = False Then
                tmr_ATUALIZARIMEDIATAMENTE.Enabled = True
                WriteDBUSERLOG("COMANDO ATUALIZAR IMEDIATAMENTE executado")
                F1.MdiParent = Me
                F1.Show()
            Else
                If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                    frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
                Else
                    frmCollection.Item(intIndex).BringToFront()
                End If
            End If
        End If

    End Sub
    Private Sub tmr_ATUALIZARIMEDIATAMENTE_Tick(sender As Object, e As EventArgs) Handles tmr_ATUALIZARIMEDIATAMENTE.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_ATUALIZARIMEDIATAMENTE" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTO_GRUPO.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem9_Click(sender As Object, e As EventArgs) Handles ButtonItem9.Click

        Dim F1 As New frm_PRODUTIVIDADE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolRELATORIOLIVRE = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_PRODUTIVIDADE", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_PRODUTIVIDADE.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_PARCIAL_Click(sender As Object, e As EventArgs) Handles bt_PARCIAL.Click

        Dim F1 As New frmWAIT
        Dim strERROR As String = Nothing

        Me.Enabled = False
        tmr_REPORTAPONTAMENTO_PARCIAL.Enabled = True
        F1.Show()
        reportDIASUTEIS = 1
        If WriteDBREPORTAPONTAMENTO_PARCIAL(intUSERID, strERROR) = False Then
            Alert(strERROR, 5)
            bolREPORTOK = True
        Else
            bolREPORTOK = True
        End If

    End Sub
    Private Sub tmr_REPORTAPONTAMENTO_PARCIAL_Tick(sender As Object, e As EventArgs) Handles tmr_REPORTAPONTAMENTO_PARCIAL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim F1 As New frm_REPORT_APONTAMENTO_GRUPO
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
            tmr_REPORTAPONTAMENTO_PARCIAL.Enabled = False
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
    Private Sub ButtonItem11_Click(sender As Object, e As EventArgs)

        Dim F1 As New frm_MANUTENCAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        bolMANUTENCAOGRUPO = False
        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MANUTENCAO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MANUTENCAO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs)

        Dim F1 As New frm_MANUTENCAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        bolMANUTENCAOGRUPO = True
        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MANUTENCAO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MANUTENCAO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_BLQUEAR_Click(sender As Object, e As EventArgs) Handles bt_BLQUEAR.Click

        Dim F1 As New frm_BLOQUEIO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        bolMANUTENCAOGRUPO = True
        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_BLOQUEIO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_BLOQUEARREGISTROS.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_BLOQUEARREGISTROS_Tick(sender As Object, e As EventArgs) Handles tmr_BLOQUEARREGISTROS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_BLOQUEIO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_OPERADORES.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_REPORTAMARRADOS_Click(sender As Object, e As EventArgs) Handles bt_REPORTAMARRADOS.Click

        Dim F1 As New frm_CONTROLEAMARRADO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        bolMANUTENCAOGRUPO = True
        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolRELATORIOLIVRE = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_CONTROLEAMARRADO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_AMARRADO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_AMARRADO_Tick(sender As Object, e As EventArgs) Handles tmr_AMARRADO.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_CONTROLEAMARRADO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_OPERADORES.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_FILTROLIVRE_Click(sender As Object, e As EventArgs) Handles bt_FILTROLIVRE.Click

        Dim F1 As New frm_APONTAMENTO_LIVRE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        bolRELATORIOLIVRE = True
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_APONTAMENTO_LIVRE", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_APONTAMENTOLIVRE.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_APONTAMENTOLIVRE_Tick(sender As Object, e As EventArgs) Handles tmr_APONTAMENTOLIVRE.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_APONTAMENTO_LIVRE" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTOLIVRE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_DEFINIRONLINE_Click(sender As Object, e As EventArgs) Handles bt_DEFINIRONLINE.Click

        Dim F1 As New frm_CONFIGONLIE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_CONFIGONLIE", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_CONFIGONLINE.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_CONFIGONLINE_Tick(sender As Object, e As EventArgs) Handles tmr_CONFIGONLINE.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_CONFIGONLIE" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTOLIVRE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_GRUPOMAQUINAS_Click(sender As Object, e As EventArgs) Handles bt_GRUPOMAQUINAS.Click

        Dim F1 As New frm_MAQUINAS_GRUPO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MAQUINAS_GRUPO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MAQUINASGRUPO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_GRUPOMASTER_Click(sender As Object, e As EventArgs) Handles bt_GRUPOMASTER.Click

        Dim F1 As New frm_MAQUINAS_MASTER
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MAQUINAS_MASTER", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MAQUINASMASTER.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_MAQUINASMASTER_Tick(sender As Object, e As EventArgs) Handles tmr_MAQUINASMASTER.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MAQUINAS_MASTER" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTOLIVRE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_MANUTENCAO_Click(sender As Object, e As EventArgs) Handles bt_MANUTENCAO.Click

        Dim F1 As New frm_MANUTENCAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MANUTENCAO", bolOpen, intIndex)
        If bolOpen = False Then
            F1.MdiParent = Me
            tmr_MANUTENCAO.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_CADASTROMAQUINAS_Click(sender As Object, e As EventArgs) Handles bt_CADASTROMAQUINAS.Click

        Dim F1 As New frm_MAQUINAS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_MAQUINAS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_MAQUINAS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub bt_MAQUINAONOFF_Click(sender As Object, e As EventArgs) Handles bt_MAQUINAONOFF.Click

        Dim F1 As New frm_HABMAQUINAS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_HABMAQUINAS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_HABMAQUINAS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_HABMAQUINAS_Tick(sender As Object, e As EventArgs) Handles tmr_HABMAQUINAS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_HABMAQUINAS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTOLIVRE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem10_Click_1(sender As Object, e As EventArgs) Handles ButtonItem10.Click

        Dim F1 As New frm_EDITAROPS
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_EDITAROPS", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_EDITAROPS.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_EDITAROPS_Tick(sender As Object, e As EventArgs) Handles tmr_EDITAROPS.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_EDITAROPS" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_APONTAMENTOLIVRE.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_BABEL_Click(sender As Object, e As EventArgs) Handles bt_BABEL.Click

        Dim F1 As New frm_BABEL
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        ribPanel_CONFIG.Enabled = False
        ribPanel_MAIN.Enabled = False
        ribPanel_REPORT.Enabled = False
        ribPanel_GRAFICOS.Enabled = False
        CheckFormisAlreadyOpen("MCONTROL_OEE.frm_BABEL", bolOpen, intIndex)
        If bolOpen = False Then
            tmr_BABEL.Enabled = True
            F1.MdiParent = Me
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_BABEL_Tick(sender As Object, e As EventArgs) Handles tmr_BABEL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_BABEL" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_BABEL.Enabled = False
            ribPanel_CONFIG.Enabled = True
            ribPanel_MAIN.Enabled = True
            ribPanel_REPORT.Enabled = True
            ribPanel_GRAFICOS.Enabled = True
        End If

    End Sub
    Private Sub bt_RESETSERVER_Click(sender As Object, e As EventArgs) Handles bt_RESETSERVER.Click

        Dim F1 As New frm_ATUALIZARIMEDIATAMENTE
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        sMessageBox("Q", "Atualizar BABEL IMEDIATAMENTE", "Deseja realmente <b>ATUALIZAR IMEDIATAMENTE</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then

            WriteDBTCOK(1)
            ribPanel_CONFIG.Enabled = False
            ribPanel_MAIN.Enabled = False
            ribPanel_REPORT.Enabled = False
            ribPanel_GRAFICOS.Enabled = False
            CheckFormisAlreadyOpen("MCONTROL_OEE.frm_ATUALIZARIMEDIATAMENTE", bolOpen, intIndex)
            If bolOpen = False Then
                tmr_ATUALIZARIMEDIATAMENTE.Enabled = True
                WriteDBUSERLOG("COMANDO ATUALIZAR IMEDIATAMENTE executado")
                F1.MdiParent = Me
                F1.Show()
            Else
                If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                    frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
                Else
                    frmCollection.Item(intIndex).BringToFront()
                End If
            End If
        End If

    End Sub

End Class

