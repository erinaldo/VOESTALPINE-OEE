Public Class frm_BABEL
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs)

        Me.Close()

    End Sub
    Private Sub frm_BABEL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strERRO As String = Nothing

        If ReadDBGETDEVICES_BABEL(dgv_BABEL, strERRO) = False Then
            Alert(strERRO, 5)
            Exit Sub
        Else
            If dgv_BABEL.Rows.Count > 0 Then
                intDEVICEID = dgv_BABEL.Rows(0).Cells(0).Value
                strDEVICENAME = dgv_BABEL.Rows(0).Cells(1).Value
                strSAPID = dgv_BABEL.Rows(0).Cells(3).Value
                bolENABLED = dgv_BABEL.Rows(0).Cells(4).Value
            End If
        End If

    End Sub
    Private Sub dgv_BABEL_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_BABEL.SelectionChanged

        Try

            intDEVICEID = dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(0).Value
            strDEVICENAME = dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(1).Value
            strSAPID = dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(3).Value
            bolENABLED = dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(4).Value

        Catch ex As Exception

        End Try

    End Sub
    Private Sub bt_ADDBABEL_Click(sender As Object, e As EventArgs) Handles bt_ADDBABEL.Click

        Dim F1 As New frm_BABEL_EDIT
        bolBABELNEW = True

        tmr_EDIT_BABEL.Enabled = True
        Me.Enabled = False
        F1.Show()

    End Sub
    Private Sub tmr_EDIT_BABEL_Tick(sender As Object, e As EventArgs) Handles tmr_EDIT_BABEL.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False
        Dim strERRO As String = Nothing

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_BABEL_EDIT" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            tmr_EDIT_BABEL.Enabled = False
            dgv_BABEL.Rows.Clear()
            If ReadDBGETDEVICES_BABEL(dgv_BABEL, strERRO) = False Then
                Alert(strERRO, 5)
                Exit Sub
            Else
                If dgv_BABEL.Rows.Count > 0 Then
                    intDEVICEID = dgv_BABEL.Rows(0).Cells(0).Value
                    strDEVICENAME = dgv_BABEL.Rows(0).Cells(1).Value
                    strSAPID = dgv_BABEL.Rows(0).Cells(3).Value
                    bolENABLED = dgv_BABEL.Rows(0).Cells(4).Value
                End If
            End If
            Me.Enabled = True
        End If

    End Sub
    Private Sub ButtonItem1_Click_1(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        Me.Close()

    End Sub
    Private Sub bt_EDITARBABEL_Click(sender As Object, e As EventArgs) Handles bt_EDITARBABEL.Click

        Dim F1 As New frm_BABEL_EDIT
        bolBABELNEW = False

        tmr_EDIT_BABEL.Enabled = True
        Me.Enabled = False
        F1.Show()

    End Sub
    Private Sub cms_BABEL_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_BABEL.Opening

        Try

            If dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(4).Value = True Then
                bt_HABILITAR_BABEL.Enabled = False
                bt_DESABILITAR_BABEL.Enabled = True
            Else
                bt_HABILITAR_BABEL.Enabled = True
                bt_DESABILITAR_BABEL.Enabled = False
            End If

        Catch ex As Exception

            bt_HABILITAR_BABEL.Enabled = False
            bt_DESABILITAR_BABEL.Enabled = False
            bt_EXCLUIR_BABEL.Enabled = False

        End Try

    End Sub
    Private Sub bt_HABILITAR_BABEL_Click(sender As Object, e As EventArgs) Handles bt_HABILITAR_BABEL.Click

        Dim ResultadoDialogo As New DialogResult
        Dim strERROR As String = Nothing

        ResultadoDialogo = MsgBox("Deseja Habilitar o BABEL da Máquina " &
                                  dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(1).Value & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Habilitar Babel")
        If ResultadoDialogo = DialogResult.Yes Then
            If WriteDBHABDESABBABEL(intDEVICEID, 1, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                dgv_BABEL.Rows.Clear()
                If ReadDBGETDEVICES_BABEL(dgv_BABEL, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_BABEL.Rows.Count > 0 Then
                        intDEVICEID = dgv_BABEL.Rows(0).Cells(0).Value
                        strDEVICENAME = dgv_BABEL.Rows(0).Cells(1).Value
                        strSAPID = dgv_BABEL.Rows(0).Cells(3).Value
                        bolENABLED = dgv_BABEL.Rows(0).Cells(4).Value
                    End If
                End If
                Information("BABEL Habilitado com sucesso!", 5)
            End If
        End If

    End Sub
    Private Sub bt_DESABILITAR_BABEL_Click(sender As Object, e As EventArgs) Handles bt_DESABILITAR_BABEL.Click

        Dim ResultadoDialogo As New DialogResult
        Dim strERROR As String = Nothing

        ResultadoDialogo = MsgBox("Deseja Desabilitar o BABEL da Máquina " &
                                  dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(1).Value & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Habilitar Babel")
        If ResultadoDialogo = DialogResult.Yes Then
            If WriteDBHABDESABBABEL(intDEVICEID, 0, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("BABEL Desabilitado com sucesso!", 5)
                dgv_BABEL.Rows.Clear()
                If ReadDBGETDEVICES_BABEL(dgv_BABEL, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_BABEL.Rows.Count > 0 Then
                        intDEVICEID = dgv_BABEL.Rows(0).Cells(0).Value
                        strDEVICENAME = dgv_BABEL.Rows(0).Cells(1).Value
                        strSAPID = dgv_BABEL.Rows(0).Cells(3).Value
                        bolENABLED = dgv_BABEL.Rows(0).Cells(4).Value
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub bt_EXCLUIR_BABEL_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIR_BABEL.Click

        Dim ResultadoDialogo As New DialogResult
        Dim strERROR As String = Nothing

        ResultadoDialogo = MsgBox("Deseja EXCLUIR o BABEL da Máquina " &
                                  dgv_BABEL.Rows(dgv_BABEL.CurrentRow.Index).Cells(1).Value & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Habilitar Babel")
        If ResultadoDialogo = DialogResult.Yes Then
            If WriteDBDELETEBABEL(intDEVICEID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                Information("BABEL EXCLUÍDO com sucesso!", 5)
                dgv_BABEL.Rows.Clear()
                If ReadDBGETDEVICES_BABEL(dgv_BABEL, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_BABEL.Rows.Count > 0 Then
                        intDEVICEID = dgv_BABEL.Rows(0).Cells(0).Value
                        strDEVICENAME = dgv_BABEL.Rows(0).Cells(1).Value
                        strSAPID = dgv_BABEL.Rows(0).Cells(3).Value
                        bolENABLED = dgv_BABEL.Rows(0).Cells(4).Value
                    End If
                End If
            End If
        End If

    End Sub

End Class