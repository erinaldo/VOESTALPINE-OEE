Imports DevComponents.AdvTree

Public Class frm_LOGUSER
    Private Sub frm_LOGUSER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

        'If dbaConnect.DBUserLogFillTree(advTree_Users, strErro) = False Then
        '    AlertInfo.Alert(strErro, 5)
        '    Exit Sub
        'End If
        dti_DINICIAL.Text = Now().AddDays(-1)
        dti_HINICIAL.Text = Now()
        dti_DFINAL.Text = Now()
        dti_HFINAL.Text = Now()

    End Sub
    Private Sub REFRESH_CHART()

        dgv_DATA.DataSource = Nothing
        dgv_DATA.Rows.Clear()

        'If dbaConnect.DBUserLogPopulate(dgv_DATA, advTree_Users, dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text, dti_HFINAL.Text,
        '                                bt_USERSSELECTED.Checked, bt_CRESC.Checked, bt_DECRESC.Checked, strErro) = False Then
        '    AlertInfo.Alert(strErro, 5)
        '    Exit Sub
        'End If

    End Sub
    Private Sub bt_CRESC_Click(sender As Object, e As EventArgs) Handles bt_CRESC.Click


        If bt_CRESC.Checked = True Then
            bt_DECRESC.Checked = False
        End If

    End Sub
    Private Sub bt_DECRESC_Click(sender As Object, e As EventArgs) Handles bt_DECRESC.Click

        If bt_DECRESC.Checked = True Then
            bt_CRESC.Checked = False
        End If

    End Sub
    Private Sub bt_SELECTALL_Click(sender As Object, e As EventArgs) Handles bt_SELECTALL.Click

        For intC = 0 To advTree_Users.Nodes.Count - 1
            advTree_Users.Nodes(intC).Checked = True
        Next

    End Sub
    Private Sub bt_UNSELECTALL_Click(sender As Object, e As EventArgs) Handles bt_UNSELECTALL.Click

        For intC = 0 To advTree_Users.Nodes.Count - 1
            advTree_Users.Nodes(intC).Checked = False
        Next

    End Sub
    Private Sub bt_REFRESH_Click(sender As Object, e As EventArgs) Handles bt_REFRESH.Click

        REFRESH_CHART()

    End Sub
    Private Sub bt_USERS_Click(sender As Object, e As EventArgs) Handles bt_USERS.Click

        bt_SELECTALL.Text = "Marcar todos os Usuários"
        RibbonBar1.Refresh()

    End Sub
    Private Sub bt_DEVICES_Click(sender As Object, e As EventArgs)

        bt_SELECTALL.Text = "Marcar todos os Dispositivos"
        RibbonBar1.Refresh()

    End Sub
    Private Sub advTree_DEVICES_AfterCheck(sender As Object, e As AdvTreeCellEventArgs) Handles advTree_DEVICES.AfterCheck

        Dim bolMarked As Boolean = False

        'If bolIlimitedAccess = False Then
        '    For intC = 0 To advTree_DEVICES.Nodes.Count - 1
        '        If advTree_DEVICES.Nodes(intC).Checked = True Then
        '            bolMarked = True
        '            Exit For
        '        End If
        '    Next
        '    For intC = 0 To advTree_Users.Nodes.Count - 1
        '        If advTree_Users.Nodes(intC).Checked = True Then
        '            bolMarked = True
        '            Exit For
        '        End If
        '    Next
        '    If bolMarked = True Then
        '        bt_REFRESH.Enabled = True
        '    Else
        '        bt_REFRESH.Enabled = False
        '    End If
        'End If
        RibbonBar1.Refresh()

    End Sub
    Private Sub advTree_Users_AfterCheck(sender As Object, e As AdvTreeCellEventArgs) Handles advTree_Users.AfterCheck

        Dim bolMarked As Boolean = False

        For intC = 0 To advTree_Users.Nodes.Count - 1
            If advTree_Users.Nodes(intC).Checked = True Then
                bolMarked = True
                Exit For
            End If
        Next
        If bolMarked = True Then
            bt_USERSSELECTED.Checked = True
        Else
            bt_USERSSELECTED.Checked = False
        End If
        RibbonBar1.Refresh()

    End Sub

End Class