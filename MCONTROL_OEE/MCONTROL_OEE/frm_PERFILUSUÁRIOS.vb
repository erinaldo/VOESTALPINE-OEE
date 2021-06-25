Imports DevComponents.AdvTree

Public Class frm_PERFILUSUÁRIOS

    Private intOnGoing As Integer = 0
    Private bolSTART As Boolean = False
    Private Sub bt_REMOVEADD_Click(sender As Object, e As EventArgs) Handles bt_REMOVEADD.Click

        bolFRMINI = True
        Me.Close()


    End Sub
    Private Sub frm_PERFILUSUÁRIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strImagesAG(9999, 1) As String
        Dim strERROR As String = Nothing

        If ReadDBGETUSERS(cb_USER, cb_USERID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If ReadXMLGETMENUS(advt_MENUS, strImagesAG, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If FilladvTreeMENUIMages(advt_MENUS, strImagesAG, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub cb_USER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_USER.SelectedIndexChanged

        Dim strERROR = False

        cb_USERID.SelectedIndex = cb_USER.SelectedIndex
        gb_MENU.Enabled = True
        If ReadDBRGETUSERBLOCK(advt_MENUS, cb_USERID.Items(cb_USERID.SelectedIndex), strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub advt_MENUS_AfterCheck(sender As Object, e As AdvTreeCellEventArgs) Handles advt_MENUS.AfterCheck

        Dim strTag As String = Nothing

        If bolSTART = False Then

            strTag = e.Cell.Parent.Tag
            If intOnGoing = 0 Then
                intOnGoing = 1
                For intC = 0 To advt_MENUS.Nodes.Count - 1
                    'Nivel RiPanel
                    '/////////////
                    If advt_MENUS.Nodes(intC).Tag = strTag Then
                        If advt_MENUS.Nodes(intC).Checked = True Then
                            If advt_MENUS.Nodes(intC).HasChildNodes Then
                                'RibTab
                                For intCX = 0 To advt_MENUS.Nodes(intC).Nodes.Count - 1
                                    advt_MENUS.Nodes(intC).Nodes(intCX).Checked = True
                                    If advt_MENUS.Nodes(intC).Nodes(intCX).HasChildNodes Then
                                        'Button1
                                        For intCx1 = 0 To advt_MENUS.Nodes(intC).Nodes(intCX).Nodes.Count - 1
                                            advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Checked = True
                                            If advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).HasChildNodes Then
                                                'Button2
                                                For intCX2 = 0 To advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Nodes.Count - 1
                                                    advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Nodes(intCX2).Checked = True
                                                Next
                                            End If
                                        Next
                                    End If
                                Next
                            End If
                        Else
                            If advt_MENUS.Nodes(intC).HasChildNodes Then
                                'RibTab
                                '//////
                                For intCX = 0 To advt_MENUS.Nodes(intC).Nodes.Count - 1
                                    advt_MENUS.Nodes(intC).Nodes(intCX).Checked = False
                                    If advt_MENUS.Nodes(intC).Nodes(intCX).HasChildNodes Then
                                        'Button1
                                        For intCx1 = 0 To advt_MENUS.Nodes(intC).Nodes(intCX).Nodes.Count - 1
                                            advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Checked = False
                                            If advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).HasChildNodes Then
                                                'Button2
                                                For intCX2 = 0 To advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Nodes.Count - 1
                                                    advt_MENUS.Nodes(intC).Nodes(intCX).Nodes(intCx1).Nodes(intCX2).Checked = False
                                                Next
                                            End If
                                        Next
                                    End If
                                Next

                            End If
                        End If
                    Else
                        If advt_MENUS.Nodes(intC).HasChildNodes Then
                            For intC2 = 0 To advt_MENUS.Nodes(intC).Nodes.Count - 1
                                'Nível Tab
                                '/////////
                                If advt_MENUS.Nodes(intC).Nodes(intC2).Tag = strTag Then
                                    If advt_MENUS.Nodes(intC).Nodes(intC2).Checked = True Then
                                        If advt_MENUS.Nodes(intC).Nodes(intC2).HasChildNodes Then
                                            For intCX1 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                                'Button1
                                                advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Checked = True
                                                If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).HasChildNodes Then
                                                    For intCx2 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Nodes.Count - 1
                                                        'Button2
                                                        advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Nodes(intCx2).Checked = True
                                                    Next
                                                End If
                                            Next
                                        End If
                                    Else
                                        If advt_MENUS.Nodes(intC).Nodes(intC2).HasChildNodes Then
                                            For intCX1 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                                'Button1
                                                advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Checked = False
                                                advt_MENUS.Nodes(intC).Nodes(intC2).Checked = False
                                                advt_MENUS.Nodes(intC).Checked = False
                                                If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).HasChildNodes Then
                                                    For intCx2 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Nodes.Count - 1
                                                        'Button2
                                                        advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intCX1).Nodes(intCx2).Checked = False
                                                    Next
                                                End If
                                            Next
                                        End If
                                    End If
                                Else
                                    If advt_MENUS.Nodes(intC).Nodes(intC2).HasChildNodes Then
                                        For intc3 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes.Count - 1
                                            'Nível Button1
                                            '/////////////
                                            If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Tag = strTag Then
                                                If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Checked = True Then
                                                    If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).HasChildNodes Then
                                                        'Button2
                                                        For intCX = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes.Count - 1
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes(intCX).Checked = True
                                                        Next
                                                    End If
                                                Else
                                                    If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).HasChildNodes Then
                                                        'Button2
                                                        For intCX = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes.Count - 1
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes(intCX).Checked = False
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Checked = False
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Checked = False
                                                            advt_MENUS.Nodes(intC).Checked = False
                                                        Next
                                                    End If
                                                End If
                                            Else
                                                If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).HasChildNodes Then
                                                    For intC4 = 0 To advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes.Count - 1
                                                        If advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes(intC4).Checked = False Then
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Nodes(intC4).Checked = False
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Nodes(intc3).Checked = False
                                                            advt_MENUS.Nodes(intC).Nodes(intC2).Checked = False
                                                            advt_MENUS.Nodes(intC).Checked = False
                                                        End If
                                                    Next
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
                intOnGoing = 0
            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim strERROR As String = Nothing
        If WriteDBUPDATEBLOCK(advt_MENUS, cb_USERID.Items(cb_USERID.SelectedIndex), strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            Information("Dados Salvos com sucesso!", 5)
        End If

    End Sub

End Class