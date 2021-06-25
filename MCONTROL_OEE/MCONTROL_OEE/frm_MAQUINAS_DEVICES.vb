Public Class frm_MAQUINAS_DEVICES
    Private Sub frm_MAQUINAS_DEVICES_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim bolFOUND As Boolean = False

        bolDEVICECHANGED = True
        Me.Text = "Sinais de Controle - " & strMACHINEREFNAME
        If ReadDBGETDEVICES(dgv_Devices, strERROR) = False Then
            Alert(strERROR, 10)
            Exit Sub
        Else
            If dgv_Devices.Rows.Count > 0 Then
                If ReadDBGETDEVICEMACHINE(intMACHINEID, intDEVICEID, strERROR) = False Then
                    Alert(strERROR, 10)
                    Exit Sub
                Else
                    dgv_Variaveis.Rows.Clear()
                    If intDEVICEID > 0 Then
                        For intC = 0 To dgv_Devices.Rows.Count - 1
                            If intDEVICEID = Val(dgv_Devices.Rows(intC).Cells(0).Value) Then
                                dgv_Devices.Rows(intC).Cells(1).Selected = True
                                Exit For
                            End If
                        Next
                        If ReadDBGETVARIABLES(intDEVICEID, dgv_Variaveis, strERROR) = False Then
                            Alert(strERROR, 10)
                            Exit Sub
                        Else
                            If dgv_Variaveis.Rows.Count > 0 And strSELECTEDVARIABLE <> Nothing Then
                                For intC = 0 To dgv_Variaveis.Rows.Count - 1
                                    If dgv_Variaveis.Rows(intC).Cells(0).Value = strSELECTEDVARIABLE Then
                                        dgv_Variaveis.Rows(intC).Selected = True
                                        Exit For
                                    End If '
                                Next
                            End If
                        End If
                    Else
                        If ReadDBGETVARIABLES(dgv_Devices.Rows(0).Cells(0).Value, dgv_Variaveis, strERROR) = False Then
                            Alert(strERROR, 10)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        bolDEVICECHANGED = False

    End Sub
    Private Sub dgv_Devices_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_Devices.SelectionChanged

        Dim bolFOUND As Boolean = False

        If bolDEVICECHANGED = False Then
            intDEVICEID = dgv_Devices.Rows(dgv_Devices.CurrentRow.Index).Cells(0).Value
            dgv_Variaveis.Rows.Clear()
            If ReadDBGETVARIABLES(dgv_Devices.Rows(dgv_Devices.CurrentRow.Index).Cells(0).Value, dgv_Variaveis, strERROR) = False Then
                Alert(strERROR, 10)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub cms_VARIAVEIS_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_VARIAVEIS.Opening

        If dgv_Variaveis.Rows.Count = 0 Then
            tsmi_SELECIONAR.Enabled = False
        End If

    End Sub
    Private Sub tsmi_SELECIONAR_Click(sender As Object, e As EventArgs) Handles tsmi_SELECIONAR.Click

        bolSELECTEDVARIABLE = True
        strVARIABLE = dgv_Variaveis.Rows(dgv_Variaveis.CurrentRow.Index).Cells(0).Value
        intDEVICEID = dgv_Devices.Rows(dgv_Devices.CurrentRow.Index).Cells(0).Value
        strDEVICEREF = dgv_Devices.Rows(dgv_Devices.CurrentRow.Index).Cells(1).Value
        bolSELECTEDVARIABLE = True
        Me.Close()

    End Sub

End Class