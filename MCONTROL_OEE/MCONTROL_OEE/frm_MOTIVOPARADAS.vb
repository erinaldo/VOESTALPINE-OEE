Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_MOTIVOPARADAS

    Private bolNIVEL1 As Boolean = False
    Private bolNIVEL2 As Boolean = False
    Private bolNIVEL3 As Boolean = False
    Private bolADDNIVEL1 As Boolean = False
    Private bolADDNIVEL2 As Boolean = False
    Private bolADDNIVEL3 As Boolean = False
    Private taskResult As eTaskDialogResult
    Private bolDGVNIVEL1 As Boolean
    Private bolDGVNIVEL2 As Boolean
    Private bolDGVNIVEL3 As Boolean
    Private bolSAVING As Boolean = False
    Private bolDELETING As Boolean = False
    Private Sub frm_MOTIVOPARADAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bolFRMINI = True
        bt_ADDMOTIVO.Enabled = False
        dgv_MOTIVOSNIVEL1.Rows.Clear()
        dgv_MOTIVOSNIVEL2.Rows.Clear()
        dgv_MOTIVOSNIVEL3.Rows.Clear()
        If ReadDBGETMOTIVOS(dgv_MOTIVOSNIVEL1, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_MOTIVOSNIVEL1.Rows.Count > 0 Then
                bolDGVNIVEL1 = True
                'bt_EXCLUIRMOTIVO.Enabled = True
                If ReadDBGETMOTIVOSNIVEL2(dgv_MOTIVOSNIVEL1.Rows(0).Cells(0).Value, dgv_MOTIVOSNIVEL2, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If dgv_MOTIVOSNIVEL2.Rows.Count > 0 Then
                        If ReadDBGETMOTIVOSNIVEL3(dgv_MOTIVOSNIVEL2.Rows(0).Cells(0).Value, dgv_MOTIVOSNIVEL3, strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        bolFRMINI = False

    End Sub
    Private Sub cms_NIVEL1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_NIVEL1.Opening

        bt_ADDNIVEL2.Enabled = False
        bt_CADINSTNIVEL1.Enabled = False
        bt_EXCINSTNIVEL1.Enabled = False

        If dgv_MOTIVOSNIVEL1.Rows.Count > 0 Then
            If dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(0).Value <> Nothing Then
                bt_ADDNIVEL2.Enabled = True
            End If
            If dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(2).Value <> Nothing Then
                bt_CADINSTNIVEL1.Enabled = True
                bt_EXCINSTNIVEL1.Enabled = True
            Else
                bt_CADINSTNIVEL1.Enabled = True
            End If
        End If

    End Sub
    Private Sub dgv_MOTIVOSNIVEL1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSNIVEL1.CellValueChanged

        If bolFRMINI = False And bolADDNIVEL1 = False And bolSAVING = False Then
            dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(5).Value = True
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub dgv_MOTIVOSNIVEL2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSNIVEL2.CellValueChanged

        If bolFRMINI = False And bolNIVEL1 = False And bolADDNIVEL2 = False And bolSAVING = False Then
            dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(6).Value = True
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub dgv_MOTIVOSNIVEL3_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_MOTIVOSNIVEL3.CellValueChanged

        If bolFRMINI = False And bolNIVEL1 = False And bolNIVEL2 = False And bolADDNIVEL3 = False And bolSAVING = False Then
            dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(6).Value = True
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub bt_CADINSTNIVEL1_Click(sender As Object, e As EventArgs) Handles bt_CADINSTNIVEL1.Click

        Dim F1 As New frm_MOTIVOSPARADAS_ORIENTACAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        strORIENTACAO = dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(2).Value
        CheckFormisAlreadyOpen("frm_MAQUINAS", bolOpen, intIndex)
        If bolOpen = False Then
            Me.Enabled = False
            tmr_ORIENTACAONIVEL1.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_ORIENTACAONIVEL1_Tick(sender As Object, e As EventArgs) Handles tmr_ORIENTACAONIVEL1.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MOTIVOSPARADAS_ORIENTACAO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            Me.Enabled = True
            tmr_ORIENTACAONIVEL1.Enabled = False
            If bolORIENTACAO = True Then
                dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(2).Value = strORIENTACAO
                If bolADDNIVEL1 = False Then
                    dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(5).Value = True
                End If
            End If
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub ATUALIZARBOTOES(ByVal bolSAVE As Boolean)

        If bolSAVE = True Then
            bt_ADDMOTIVO.Enabled = False
            bt_SAVE.Enabled = True
            bt_CANCEL.Enabled = True
            bt_EXCLUIRMOTIVO.Enabled = False
        Else
            bt_ADDMOTIVO.Enabled = False
            bt_SAVE.Enabled = False
            bt_CANCEL.Enabled = False
            bt_EXCLUIRMOTIVO.Enabled = False
        End If

    End Sub
    Private Sub frm_MOTIVOPARADAS_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If bt_SAVE.Enabled = True Then
            sMessageBox("A", "Cancelas Adição/Edição de Motivo de Parada de Máquina!",
                        "Deseja realmente <b>SAIR e CANCELAR a Adição/Edição</b> dos dados de Parada de Máquina?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                bolFRMINI = True
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            bolFRMINI = True
        End If

    End Sub
    Private Sub bt_ADDNIVEL2_Click(sender As Object, e As EventArgs) Handles bt_ADDNIVEL2.Click

        bolADDNIVEL2 = True
        dgv_MOTIVOSNIVEL3.Rows.Clear()
        dgv_MOTIVOSNIVEL2.Rows.Add()
        dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.Rows.Count - 1).Selected = True
        dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.Rows.Count - 1).Cells(1).Value = dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(0).Value
        dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.Rows.Count - 1).Cells(3).ReadOnly = True
        dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.Rows.Count - 1).Cells(4).Value = True
        dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.Rows.Count - 1).Cells(5).Value = True
        ep_NIVEL1.Enabled = False
        ATUALIZARBOTOES(True)
        WriteDBUSERLOG("MOTIVO DE PARADA nível 2 adicionado")

    End Sub
    Private Sub CadastrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bt_CADINSTNIVEL2.Click

        Dim F1 As New frm_MOTIVOSPARADAS_ORIENTACAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        strORIENTACAO = dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(3).Value
        CheckFormisAlreadyOpen("frm_MAQUINAS", bolOpen, intIndex)
        If bolOpen = False Then
            Me.Enabled = False
            tmr_ORIENTACAONIVEL2.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If

    End Sub
    Private Sub tmr_ORIENTACAONIVEL2_Tick(sender As Object, e As EventArgs) Handles tmr_ORIENTACAONIVEL2.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MOTIVOSPARADAS_ORIENTACAO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            Me.Enabled = True
            tmr_ORIENTACAONIVEL2.Enabled = False
            If bolORIENTACAO = True Then
                dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(3).Value = strORIENTACAO
                If bolADDNIVEL2 = False Then
                    dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(6).Value = True
                End If
            End If
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub AdicionarNível3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bt_ADDNIVEL3.Click

        bolADDNIVEL3 = True
        dgv_MOTIVOSNIVEL3.Rows.Add()
        dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.Rows.Count - 1).Selected = True
        dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.Rows.Count - 1).Cells(1).Value = dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(0).Value
        dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.Rows.Count - 1).Cells(3).ReadOnly = True
        dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.Rows.Count - 1).Cells(4).Value = True
        dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.Rows.Count - 1).Cells(5).Value = True
        ep_NIVEL1.Enabled = False
        ep_NIVEL2.Enabled = False
        ATUALIZARBOTOES(True)
        WriteDBUSERLOG("MOTIVO DE PARADA nivel 3 adicionado")

    End Sub
    Private Sub cms_NIVEL2_Opening(sender As Object, e As CancelEventArgs) Handles cms_NIVEL2.Opening

        bt_ADDNIVEL3.Enabled = False
        bt_CADINSTNIVEL2.Enabled = False
        bt_EXCINSTNIVEL2.Enabled = False

        If dgv_MOTIVOSNIVEL2.Rows.Count > 0 Then
            If dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(0).Value <> Nothing Then
                bt_ADDNIVEL3.Enabled = True
            End If
            If dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(3).Value <> Nothing Then
                bt_CADINSTNIVEL2.Enabled = True
                bt_EXCINSTNIVEL2.Enabled = True
            Else
                bt_CADINSTNIVEL2.Enabled = True
            End If
        End If

    End Sub
    Private Sub bt_ADDMOTIVO_Click(sender As Object, e As EventArgs) Handles bt_ADDMOTIVO.Click

        bolADDNIVEL1 = True
        dgv_MOTIVOSNIVEL1.Rows.Add()
        dgv_MOTIVOSNIVEL2.Rows.Clear()
        dgv_MOTIVOSNIVEL3.Rows.Clear()
        dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.Rows.Count - 1).Cells(3).Value = True
        dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.Rows.Count - 1).Cells(4).Value = True
        ATUALIZARBOTOES(True)

    End Sub
    Private Sub bt_EXCINSTNIVEL1_Click(sender As Object, e As EventArgs) Handles bt_EXCINSTNIVEL1.Click

        sMessageBox("A", "Excluir Orinetações",
                    "Deseja realmente <b>EXCLUIR a ORIENTAÇÃO</b> para o motivo de Parada <b>" & dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(2).Value = Nothing
            If bolADDNIVEL1 = False Then
                dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(5).Value = True
            End If
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub bt_EXCINSTNIVEL2_Click(sender As Object, e As EventArgs) Handles bt_EXCINSTNIVEL2.Click

        sMessageBox("A", "Excluir Orinetações",
                    "Deseja realmente <b>EXCLUIR a ORIENTAÇÃO</b> para o motivo de Parada <b>" & dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(2).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(3).Value = Nothing
            If bolADDNIVEL2 = False Then
                dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(6).Value = True
            End If
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub ExcluirParadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bt_EXCINSTNIVEL3.Click

        sMessageBox("A", "Excluir Orinetações",
                   "Deseja realmente <b>EXCLUIR a ORIENTAÇÃO</b> para o motivo de Parada <b>" & dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(2).Value & "</b>?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(3).Value = Nothing
            If bolADDNIVEL3 = False Then
                dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(6).Value = True
            End If
            ATUALIZARBOTOES(True)
        End If

    End Sub
    Private Sub bt_CANCEL_Click(sender As Object, e As EventArgs) Handles bt_CANCEL.Click

        sMessageBox("A", "Cancelas Adição/Edição de Máquina!",
                    "Deseja realmente <b>CANCELAR a Adição/Edição</b> dos dados da Máquina?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            ep_NIVEL1.Enabled = True
            ep_NIVEL2.Enabled = True
            ep_NIVEL3.Enabled = True
            dgv_MOTIVOSNIVEL1.Rows.Clear()
            dgv_MOTIVOSNIVEL2.Rows.Clear()
            dgv_MOTIVOSNIVEL3.Rows.Clear()
            bolNIVEL1 = True
            If ReadDBGETMOTIVOS(dgv_MOTIVOSNIVEL1, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
            bolNIVEL1 = False
            ATUALIZARBOTOES(False)
        End If

    End Sub
    Private Sub bt_SAVE_Click(sender As Object, e As EventArgs) Handles bt_SAVE.Click

        dgv_MOTIVOSNIVEL1.EndEdit()
        dgv_MOTIVOSNIVEL2.EndEdit()
        dgv_MOTIVOSNIVEL3.EndEdit()
        bolSAVING = True
        For intC = 0 To dgv_MOTIVOSNIVEL1.Rows.Count - 1
            If dgv_MOTIVOSNIVEL1.Rows(intC).Cells(1).Value = Nothing Then
                Alert("O campo <b>DESCRIÇÃO</b> dos <b>MOTIVOS DE PARADA NÍVEL 1</b> é de preenchimento <b>OBRIGATÓRIO</b>!", 10, True)
                Exit Sub
            End If
        Next
        For intC = 0 To dgv_MOTIVOSNIVEL2.Rows.Count - 1
            If dgv_MOTIVOSNIVEL2.Rows(intC).Cells(2).Value = Nothing Then
                Alert("O campo <b>DESCRIÇÃO</b> dos <b>MOTIVOS DE PARADA NÍVEL 2</b> é de preenchimento <b>OBRIGATÓRIO</b>!", 10, True)
                Exit Sub
            End If
        Next
        For intC = 0 To dgv_MOTIVOSNIVEL3.Rows.Count - 1
            If dgv_MOTIVOSNIVEL3.Rows(intC).Cells(2).Value = Nothing Then
                Alert("O campo <b>DESCRIÇÃO</b> dos <b>MOTIVOS DE PARADA NÍVEL 3</b> é de preenchimento <b>OBRIGATÓRIO</b>!", 10, True)
                Exit Sub
            End If
        Next

        If WriteDBSAVEMOTIVOS(dgv_MOTIVOSNIVEL1, 1, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If WriteDBSAVEMOTIVOS(dgv_MOTIVOSNIVEL2, 2, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If WriteDBSAVEMOTIVOS(dgv_MOTIVOSNIVEL3, 3, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    Information("Dados salvos com sucesso!", 5)
                    WriteDBUSERLOG("Dados de MOTIVOS DE PARADA salvos")
                End If
            End If
        End If
        ep_NIVEL1.Enabled = True
        ep_NIVEL2.Enabled = True
        ep_NIVEL3.Enabled = True
        ATUALIZARBOTOES(False)
        bolSAVING = False
        bolADDNIVEL2 = False

    End Sub
    Private Sub dgv_MOTIVOSNIVEL1_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_MOTIVOSNIVEL1.SelectionChanged

        Dim intN1INDEX As Integer = 0
        bolNIVEL1 = True
        dgv_MOTIVOSNIVEL2.Rows.Clear()
        dgv_MOTIVOSNIVEL3.Rows.Clear()

        If bolDELETING = False Then
            intN1INDEX = dgv_MOTIVOSNIVEL1.CurrentRow.Index
        End If
        If ReadDBGETMOTIVOSNIVEL2(dgv_MOTIVOSNIVEL1.Rows(intN1INDEX).Cells(0).Value, dgv_MOTIVOSNIVEL2, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        Else
            If dgv_MOTIVOSNIVEL2.Rows.Count > 0 Then
                dgv_MOTIVOSNIVEL3.Rows.Clear()
                If ReadDBGETMOTIVOSNIVEL3(dgv_MOTIVOSNIVEL2.Rows(0).Cells(0).Value, dgv_MOTIVOSNIVEL3, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                End If
            End If
        End If
        bolNIVEL1 = False


    End Sub
    Private Sub dgv_MOTIVOSNIVEL2_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_MOTIVOSNIVEL2.SelectionChanged

        If bolNIVEL1 = False And bolADDNIVEL2 = False Then
            dgv_MOTIVOSNIVEL3.Rows.Clear()
            bolNIVEL2 = True
            If ReadDBGETMOTIVOSNIVEL3(dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(0).Value, dgv_MOTIVOSNIVEL3, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            End If
            bolNIVEL2 = False
        End If

    End Sub
    Private Sub CadastrarInstruçãoDeParadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bt_CADINSTNIVEL3.Click

        Dim F1 As New frm_MOTIVOSPARADAS_ORIENTACAO
        Dim bolOpen As Boolean = False
        Dim intIndex As Integer = 0
        Dim frmCollection = System.Windows.Forms.Application.OpenForms

        strORIENTACAO = dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(3).Value
        CheckFormisAlreadyOpen("frm_MAQUINAS", bolOpen, intIndex)
        If bolOpen = False Then
            Me.Enabled = False
            tmr_ORIENTACAONIVEL3.Enabled = True
            F1.Show()
        Else
            If frmCollection.Item(intIndex).WindowState = FormWindowState.Minimized Then
                frmCollection.Item(intIndex).WindowState = FormWindowState.Normal
            Else
                frmCollection.Item(intIndex).BringToFront()
            End If
        End If


    End Sub
    Private Sub tmr_ORIENTACAONIVEL3_Tick(sender As Object, e As EventArgs) Handles tmr_ORIENTACAONIVEL3.Tick

        Dim arrForms As Array
        Dim arrFormName As Array
        Dim bolFound As Boolean = False

        arrForms = Application.OpenForms.OfType(Of Form).ToArray
        For intC = 0 To arrForms.Length - 1
            arrFormName = Split(arrForms(intC).ToString, ",")
            If arrFormName(0) = "MCONTROL_OEE.frm_MOTIVOSPARADAS_ORIENTACAO" Then
                bolFound = True
            End If
        Next

        If bolFound = False Then
            Me.Enabled = True
            tmr_ORIENTACAONIVEL3.Enabled = False
            If bolORIENTACAO = True Then
                dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(3).Value = strORIENTACAO
                If bolADDNIVEL3 = False Then
                    dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(6).Value = True
                End If
                ATUALIZARBOTOES(True)
            End If
        End If

    End Sub
    Private Sub bt_EXCLUIRMOTIVO_Click(sender As Object, e As EventArgs) Handles bt_EXCLUIRMOTIVO.Click

        Dim bolUSED As Boolean = False

        If bolDGVNIVEL1 = True Then
            sMessageBox("A", "Excluir Motivo de Parada",
                        "Deseja realmente <b>EXCLUIR</b> o Motivo de Parada <b>" & dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(1).Value & "</b>?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                If ReadDBCHECKUSOMOTIVO(dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(0).Value, 1, bolUSED, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolUSED = True Then
                        Alert("Não é possível excluir o motivo " & dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(1).Value &
                              " pois o mesmo já foi usado como registro de motivo de parada!", 10, True)
                        Exit Sub
                    Else
                        If WriteDBDELETEMOTIVOPARADA(dgv_MOTIVOSNIVEL1.Rows(dgv_MOTIVOSNIVEL1.CurrentRow.Index).Cells(0).Value, 1, strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        Else
                            Information("Motivo excluído com sucesso!", 5)
                            WriteDBUSERLOG("MOTIVO DE PARADA excluído")
                            bolDELETING = True
                            dgv_MOTIVOSNIVEL1.Rows.RemoveAt(dgv_MOTIVOSNIVEL1.CurrentRow.Index)
                            dgv_MOTIVOSNIVEL2.Rows.Clear()
                            dgv_MOTIVOSNIVEL3.Rows.Clear()
                            If dgv_MOTIVOSNIVEL1.Rows.Count = 0 Then
                                bt_EXCLUIRMOTIVO.Enabled = False
                            Else
                                dgv_MOTIVOSNIVEL1.Rows(0).Selected = True
                            End If
                            bolDELETING = False
                        End If
                    End If
                End If
            End If


        ElseIf bolDGVNIVEL2 = True Then
            sMessageBox("A", "Excluir Motivo de Parada",
                        "Deseja realmente <b>EXCLUIR</b> o Motivo de Parada <b>" & dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(2).Value & "</b>?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                If ReadDBCHECKUSOMOTIVO(dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(0).Value, 2, bolUSED, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolUSED = True Then
                        Alert("Não é possível excluir o motivo " & dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(1).Value &
                              " pois o mesmo já foi usado como registro de motivo de parada!", 10, True)
                        Exit Sub
                    Else
                        If WriteDBDELETEMOTIVOPARADA(dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL2.CurrentRow.Index).Cells(1).Value, 2, strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        Else
                            Information("Motivo excluído com sucesso!", 5)
                            dgv_MOTIVOSNIVEL2.Rows.RemoveAt(dgv_MOTIVOSNIVEL2.CurrentRow.Index)
                            dgv_MOTIVOSNIVEL3.Rows.Clear()
                            If dgv_MOTIVOSNIVEL2.Rows.Count = 0 Then
                                dgv_MOTIVOSNIVEL1.Rows(0).Selected = True
                            Else
                                dgv_MOTIVOSNIVEL2.Rows(0).Selected = True
                            End If
                        End If
                    End If
                End If
            End If

        ElseIf bolDGVNIVEL3 = True Then
            sMessageBox("A", "Excluir Motivo de Parada",
                        "Deseja realmente <b>EXCLUIR</b> o Motivo de Parada <b>" & dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(2).Value & "</b>?", taskResult)
            If taskResult = eTaskDialogResult.Yes Then
                If ReadDBCHECKUSOMOTIVO(dgv_MOTIVOSNIVEL2.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(0).Value, 3, bolUSED, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolUSED = True Then
                        Alert("Não é possível excluir o motivo " & dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(1).Value &
                              " pois o mesmo já foi usado como registro de motivo de parada!", 10, True)
                        Exit Sub
                    Else
                        If WriteDBDELETEMOTIVOPARADA(dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(1).Value, 3, strERROR) = False Then
                            Alert(strERROR, 5)
                            Exit Sub
                        Else
                            Information("Motivo excluído com sucesso!", 5)
                            dgv_MOTIVOSNIVEL3.Rows.RemoveAt(dgv_MOTIVOSNIVEL3.CurrentRow.Index)
                            If dgv_MOTIVOSNIVEL3.Rows.Count = 0 Then
                                dgv_MOTIVOSNIVEL2.Rows(0).Selected = True
                            Else
                                dgv_MOTIVOSNIVEL3.Rows(0).Selected = True
                            End If
                        End If
                    End If
                End If
            End If

        End If

    End Sub
    Private Sub dgv_MOTIVOSNIVEL2_Click(sender As Object, e As EventArgs) Handles dgv_MOTIVOSNIVEL2.Click

        bolDGVNIVEL1 = False
        bolDGVNIVEL2 = True
        bolDGVNIVEL3 = False

    End Sub
    Private Sub dgv_MOTIVOSNIVEL1_Click(sender As Object, e As EventArgs) Handles dgv_MOTIVOSNIVEL1.Click

        bolDGVNIVEL1 = True
        bolDGVNIVEL2 = False
        bolDGVNIVEL3 = False

    End Sub
    Private Sub dgv_MOTIVOSNIVEL3_Click(sender As Object, e As EventArgs) Handles dgv_MOTIVOSNIVEL3.Click

        bolDGVNIVEL1 = False
        bolDGVNIVEL2 = False
        bolDGVNIVEL3 = True

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        bolFRMINI = True
        Me.Close()

    End Sub
    Private Sub cms_NIVEL3_Opening(sender As Object, e As CancelEventArgs) Handles cms_NIVEL3.Opening

        If dgv_MOTIVOSNIVEL3.Rows(dgv_MOTIVOSNIVEL3.CurrentRow.Index).Cells(3).Value <> Nothing Then
            bt_CADINSTNIVEL3.Enabled = True
            bt_EXCINSTNIVEL3.Enabled = True
        Else
            bt_CADINSTNIVEL3.Enabled = True
        End If

    End Sub

End Class