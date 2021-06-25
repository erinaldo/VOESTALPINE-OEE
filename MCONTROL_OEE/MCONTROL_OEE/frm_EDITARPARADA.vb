Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_EDITARPARADA

    Private taskResult As eTaskDialogResult
    Private Sub frm_EDITARPARADA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        If ReadDBGETMACHINEMOTIVOS(cb_MAQUINA, cb_MAQUINAID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If
        If bolADDPARADA = True Then
            dti_DINICIAL.Text = Now.ToString
            dti_HINICIAL.Text = Now.ToString
            dti_DFINAL.Text = Now.ToString
            dti_HFINAL.Text = Now.ToString

            If ReadDBGETMOTIVOSPARADANEW(cb_NIVEL1, cb_NIVEL1ID, cb_OPERADOR, cb_OPERADORID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        Else
            If ReadDBGETMOTIVOSPARADA(intPARADAID, cb_NIVEL1, cb_NIVEL1ID, cb_NIVEL2, cb_NIVEL2ID, cb_NIVEL3,
                                     cb_NIVEL3ID, cb_OPERADOR, cb_OPERADORID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If ReadDBGEDADOSPARADA(intPARADAID, dti_DINICIAL, dti_HINICIAL, dti_DFINAL,
                                       dti_HFINAL, tb_COMENTARIOS, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub cb_NIVEL1ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL1ID.SelectedIndexChanged

        cb_NIVEL1.SelectedIndex = cb_NIVEL1ID.SelectedIndex

    End Sub
    Private Sub cb_NIVEL2ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL2ID.SelectedIndexChanged

        cb_NIVEL2.SelectedIndex = cb_NIVEL2ID.SelectedIndex

    End Sub
    Private Sub cb_NIVEL3ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL3ID.SelectedIndexChanged

        cb_NIVEL3.SelectedIndex = cb_NIVEL3ID.SelectedIndex

    End Sub
    Private Sub cb_NIVEL1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL1.SelectedIndexChanged

        If bolFRMINI = False Then
            cb_NIVEL1ID.SelectedIndex = cb_NIVEL1.SelectedIndex
            cb_NIVEL2.Items.Clear()
            cb_NIVEL2ID.Items.Clear()
            cb_NIVEL3.Items.Clear()
            cb_NIVEL3ID.Items.Clear()
            If ReadDBGETMOTIVOSNIVEL2PARADA(cb_NIVEL1ID.Items(cb_NIVEL1ID.SelectedIndex), cb_NIVEL2, cb_NIVEL2ID, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub cb_NIVEL2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL2.SelectedIndexChanged

        If bolFRMINI = False Then
            cb_NIVEL2ID.SelectedIndex = cb_NIVEL2.SelectedIndex
            cb_NIVEL3.Items.Clear()
            cb_NIVEL3ID.Items.Clear()
            If cb_NIVEL2ID.SelectedIndex <> -1 Then
                If ReadDBGETMOTIVOSNIVEL3PARADA(cb_NIVEL2ID.Items(cb_NIVEL2ID.SelectedIndex), cb_NIVEL3, cb_NIVEL3ID, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        Me.TopMost = False
        sMessageBox("Q", "Editar Parada",
                    "Deseja realmente <b>EDITAR</b> os dados da Parada?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If cb_NIVEL1ID.SelectedIndex = -1 Or cb_OPERADORID.SelectedIndex = -1 Then
                Alert("Preencha todos os dados obrigatórios!", 10, True)
                Exit Sub
            End If
            If bolADDPARADA = False Then
                If WriteDBUPDATEPARADA(intPARADAID, dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text, dti_HFINAL.Text,
                                       cb_NIVEL1.Text, cb_NIVEL2.Text, cb_NIVEL3.Text, cb_NIVEL1ID.Text,
                                       cb_NIVEL2ID.Text, cb_NIVEL3ID.Text, cb_OPERADORID.Text, tb_COMENTARIOS.Text, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    Information("Dados da parada editados com sucesso!", 5)
                    Me.Close()
                End If
            Else
                If WriteDBADDPARADA(cb_MAQUINAID.SelectedItem, dti_DINICIAL.Text, dti_HINICIAL.Text, dti_DFINAL.Text, dti_HFINAL.Text,
                                    cb_NIVEL1.Text, cb_NIVEL2.Text, cb_NIVEL3.Text, cb_NIVEL1ID.Text,
                                    cb_NIVEL2ID.Text, cb_NIVEL3ID.Text, cb_OPERADORID.Text, tb_COMENTARIOS.Text, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    Information("Dados da parada editados com sucesso!", 5)
                    Me.Close()
                End If
            End If
            bolPARADAEDITADA = True
        Else
            Me.TopMost = True
        End If

    End Sub
    Private Sub cb_OPERADORID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_OPERADORID.SelectedIndexChanged

        cb_OPERADOR.SelectedIndex = cb_OPERADORID.SelectedIndex

    End Sub
    Private Sub cb_OPERADOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_OPERADOR.SelectedIndexChanged

        cb_OPERADORID.SelectedIndex = cb_OPERADOR.SelectedIndex

    End Sub
    Private Sub bt_LIMPARMOTIVO2_Click(sender As Object, e As EventArgs) Handles bt_LIMPARMOTIVO2.Click

        cb_NIVEL2ID.SelectedIndex = -1

    End Sub
    Private Sub bt_LIMPARNIVEL3_Click(sender As Object, e As EventArgs) Handles bt_LIMPARNIVEL3.Click

        cb_NIVEL3ID.SelectedIndex = -1

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        Me.TopMost = False
        sMessageBox("Q", "Cancelar Editar Parada",
                   "Deseja realmente <b>CANCELAR A EDIÇÃO</b> dos dados da Parada?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            Me.Close()
        Else
            Me.TopMost = True
        End If

    End Sub
    Private Sub frm_EDITARPARADA_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        bolFRMINI = True

    End Sub
    Private Sub cb_NIVEL3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_NIVEL3.SelectedIndexChanged

        If bolFRMINI = False Then
            cb_NIVEL3ID.SelectedIndex = cb_NIVEL3.SelectedIndex
        End If

    End Sub
    Private Sub cb_MAQUINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_MAQUINA.SelectedIndexChanged

        cb_MAQUINAID.SelectedIndex = cb_MAQUINA.SelectedIndex

    End Sub

End Class