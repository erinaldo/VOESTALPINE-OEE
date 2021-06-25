Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Charts
Public Class frm_CHART_PARETO
    Private Sub frm_CHART_PARETO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIAL.Text = DateAdd(DateInterval.Day, -30, Now())
        dti_HINICIAL.Text = DateAdd(DateInterval.Day, -30, Now())
        dti_DFINAL.Text = Now()
        dti_HFINAL.Text = Now()

        If ReadDBGETMACHINE_PARETO(lb_MAQUINAS, lb_MAQUINASID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If ReadDBGETNIVEL1(lb_NIVEL1, lb_NIVEL1ID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub bt_REFRESH_Click(sender As Object, e As EventArgs) Handles bt_REFRESH.Click

        Dim chartPARETO As ChartXy = TryCast(ChartControl1.ChartPanel.ChartContainers("ChartXY"), ChartXy)
        Dim chartPARETO2 As ChartXy = TryCast(ChartControl2.ChartPanel.ChartContainers("ChartXY"), ChartXy)

        If ReadDBCHART_PARETO(dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text,
                              dti_HFINAL.Text, lb_MAQUINASID, lb_NIVEL1ID, lbl_NIVEL2ID,
                              lb_NIVEL3ID, lb_TURNOS, chartPARETO, chartPARETO2, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            bt_EXCEL.Enabled = True
        End If

    End Sub
    Private Sub cms_MAQUINAS_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_MAQUINAS.Opening

        If lb_MAQUINAS.Items.Count > 0 Then
            bt_MAQUINAS_SELECTALL.Enabled = True
            bt_MAQUINAS_UNSELECTALL.Enabled = True
        Else
            bt_MAQUINAS_SELECTALL.Enabled = False
            bt_MAQUINAS_UNSELECTALL.Enabled = False
        End If

    End Sub
    Private Sub bt_MAQUINAS_SELECTALL_Click(sender As Object, e As EventArgs) Handles bt_MAQUINAS_SELECTALL.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 1)
        Next

    End Sub
    Private Sub bt_MAQUINAS_UNSELECTALL_Click(sender As Object, e As EventArgs) Handles bt_MAQUINAS_UNSELECTALL.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 0)
        Next

    End Sub
    Private Sub lb_TURNOS_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_TURNOS.ItemCheck

        'For intC = 0 To lb_TURNOSID.Items.Count - 1
        '    lb_TURNOSID.SetItemCheckState(intC, 0)
        'Next
        'For intC = 0 To lb_TURNOS.CheckedItems.Count - 1
        '    For intC2 = 0 To lb_TURNOS.Items.Count - 1
        '        If lb_TURNOS.CheckedItems(intC).Text.Contains(lb_TURNOS.Items(intC2)) Then
        '            lb_TURNOSID.SetItemCheckState(intC2, 1)
        '        End If
        '    Next
        'Next

    End Sub
    Private Sub lb_MAQUINAS_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_MAQUINAS.ItemCheck

        For intC = 0 To lb_MAQUINASID.Items.Count - 1
            lb_MAQUINASID.SetItemCheckState(intC, 0)
        Next
        If lb_MAQUINAS.CheckedItems.Count > 0 Then
            bt_REFRESH.Enabled = True
        Else
            bt_REFRESH.Enabled = False
        End If
        For intC = 0 To lb_MAQUINAS.CheckedItems.Count - 1
            For intC2 = 0 To lb_MAQUINASID.Items.Count - 1
                If lb_MAQUINAS.CheckedItems(intC).Text.Contains(lb_MAQUINAS.Items(intC2)) And
                   lb_MAQUINAS.CheckedItems(intC).Text.Length = lb_MAQUINAS.Items(intC2).ToString.Length Then
                    lb_MAQUINASID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next
        ' lb_TURNOS.Items.Clear()
        ' lb_TURNOSID.Items.Clear()
        ' If lb_MAQUINAS.CheckedItems.Count = 1 Then
        '     For intC = 0 To lb_MAQUINASID.CheckedItems.Count - 1
        '         If ReadFBGETTURNOS_PARETO(lb_MAQUINASID.CheckedItems(intC).ToString, lb_TURNOS, lb_TURNOSID, strERROR) = False Then
        '             Alert(strERROR, 5)
        '             Exit Sub
        '         End If
        '     Next
        ' End If


    End Sub
    Private Sub lb_NIVEL1_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_NIVEL1.ItemCheck

        For intC = 0 To lb_NIVEL1ID.Items.Count - 1
            lb_NIVEL1ID.SetItemCheckState(intC, 0)
        Next
        For intC = 0 To lb_NIVEL1.CheckedItems.Count - 1
            For intC2 = 0 To lb_NIVEL1ID.Items.Count - 1
                If lb_NIVEL1.CheckedItems(intC).Text.Contains(lb_NIVEL1.Items(intC2)) And
                   lb_NIVEL1.CheckedItems(intC).Text.Length = lb_NIVEL1.Items(intC2).ToString.Length Then
                    lb_NIVEL1ID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next
        If ReadDBGETNIVEL2(lb_NIVEL1ID, lb_NIVEL2, lbl_NIVEL2ID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

        For intC = 0 To lbl_NIVEL2ID.Items.Count - 1
            lbl_NIVEL2ID.SetItemCheckState(intC, 0)
        Next
        For intC = 0 To lb_NIVEL2.CheckedItems.Count - 1
            For intC2 = 0 To lbl_NIVEL2ID.Items.Count - 1
                If lb_NIVEL2.CheckedItems(intC).Text.Contains(lb_NIVEL2.Items(intC2)) And
                   lb_NIVEL2.CheckedItems(intC).Text.Length = lb_NIVEL2.Items(intC2).ToString.Length Then
                    lbl_NIVEL2ID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next
        If ReadDBGETNIVEL3(lbl_NIVEL2ID, lb_NIVEL3, lb_NIVEL3ID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub lb_NIVEL2_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_NIVEL2.ItemCheck

        For intC = 0 To lbl_NIVEL2ID.Items.Count - 1
            lbl_NIVEL2ID.SetItemCheckState(intC, 0)
        Next
        For intC = 0 To lb_NIVEL2.CheckedItems.Count - 1
            For intC2 = 0 To lbl_NIVEL2ID.Items.Count - 1
                If lb_NIVEL2.CheckedItems(intC).Text.Contains(lb_NIVEL2.Items(intC2)) And
                   lb_NIVEL2.CheckedItems(intC).Text.Length = lb_NIVEL2.Items(intC2).ToString.Length Then
                    lbl_NIVEL2ID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next
        If ReadDBGETNIVEL3(lbl_NIVEL2ID, lb_NIVEL3, lb_NIVEL3ID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub lb_NIVEL3_ItemCheck(sender As Object, e As ListBoxAdvItemCheckEventArgs) Handles lb_NIVEL3.ItemCheck

        For intC = 0 To lb_NIVEL3ID.Items.Count - 1
            lb_NIVEL3ID.SetItemCheckState(intC, 0)
        Next
        For intC = 0 To lb_NIVEL3.CheckedItems.Count - 1
            For intC2 = 0 To lb_NIVEL3ID.Items.Count - 1
                If lb_NIVEL3.CheckedItems(intC).Text.Contains(lb_NIVEL3.Items(intC2)) And
                   lb_NIVEL3.CheckedItems(intC).Text.Length = lb_NIVEL3.Items(intC2).ToString.Length Then
                    lb_NIVEL3ID.SetItemCheckState(intC2, 1)
                End If
            Next
        Next

    End Sub
    Private Sub bt_EXCEL_Click(sender As Object, e As EventArgs) Handles bt_EXCEL.Click

        If WriteDBEXPORTEXCEL(dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text,
                              dti_HFINAL.Text, lb_MAQUINASID, lb_NIVEL1ID, lbl_NIVEL2ID,
                              lb_NIVEL3ID, lb_TURNOS, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("EXCEL gerado com sucesso!", 5)
        End If

    End Sub
    Private Sub bt_MARCAR_Click(sender As Object, e As EventArgs) Handles bt_MARCAR.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 1)
        Next

    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        For intC = 0 To lb_MAQUINAS.Items.Count - 1
            lb_MAQUINAS.SetItemCheckState(intC, 0)
        Next

    End Sub

End Class