Imports System.ComponentModel
Imports DevComponents.DotNetBar
Public Class frm_ESCALA_EXCLUIR

    Private taskResult As eTaskDialogResult
    Private Sub frm_ESCALA_EXCLUIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tb_MAQUINA.Text = strMACHINEREFNAME
        dti_DINICIAL.Value = Now()
        dti_DFINAL.Value = DateAdd(DateInterval.Day, 30, Now())
        If ReadDBGETTURNOS(intMACHINEID, cb_TURNO, cb_TURNOID, strERROR) = False Then
            Alert(strERROR, 5)
            Exit Sub
        End If

    End Sub
    Private Sub cb_TURNO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_TURNO.SelectedIndexChanged

        cb_TURNOID.SelectedIndex = cb_TURNO.SelectedIndex

    End Sub
    Private Sub bt_ADICIONARPERIODO_Click(sender As Object, e As EventArgs) Handles bt_ADICIONARPERIODO.Click

        Dim bolBLOQUEIO As Boolean = False
        Dim bolFOUND As Boolean = False

        Me.TopMost = False
        sMessageBox("Q", "Excluir Escala de Trabalho",
                    "Deseja realmente <b>EXCLUIR</b> a Escala de Trabalho " & cb_TURNO.Items(cb_TURNO.SelectedIndex) & " com Data/Hora Inicial = " &
                    dti_DINICIAL.Text & " e Data/Hora Final = " & dti_DFINAL.Text & "?", taskResult)
        If taskResult = eTaskDialogResult.Yes Then
            If ReadDBGETESCALAPARADAS(intMACHINEID, dti_DINICIAL.Text, dti_DFINAL.Text, bolFOUND, strERROR) = False Then
                Alert(strERROR, 5)
                Exit Sub
            Else
                If bolFOUND = True Then
                    sMessageBox("Q", "Produção Registrada",
                                "Um ou mais APONTAMENTOS DE PRODUÇÃOs estão registrados neste período de Escala. Deseja realmente <b>EXCLUIR</b> a Escala de Trabalho?", taskResult)
                    If taskResult <> eTaskDialogResult.Yes Then
                        Exit Sub
                    End If
                End If
                If ReadDBGETBLOQUEIOS(intMACHINEID, dti_DINICIAL.Text, bolBLOQUEIO, strERROR) = False Then
                    Alert(strERROR, 5)
                    Exit Sub
                Else
                    If bolBLOQUEIO = True Then
                        sMessageBox("Q", "Excluir Escala de Trabalho",
                               "Existem Períodos da Escala de Trabalho <b>BLOQUEADOS</b>. Deseja <b>EXCLUIR</b> as Escalas <b>não Bloqueadas</b>?", taskResult)
                        If taskResult = eTaskDialogResult.No Then
                            Exit Sub
                        End If
                    End If
                    If WriteDBDELETEPERIODO(intMACHINEID, cb_TURNOID.Items(cb_TURNOID.SelectedIndex),
                                        dti_DINICIAL.Text, dti_DFINAL.Text, strERROR) = False Then
                        Alert(strERROR, 5)
                        Exit Sub
                    Else
                        Information("Período Excluído com Sucesso!", 5)
                        WriteDBUSERLOG("ESCALA DE TRABALHO excluída")
                    End If
                End If
            End If
        End If
        Me.TopMost = True

    End Sub

End Class