Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Public Class frmESCALA

    Private taskResult As eTaskDialogResult
    Private Sub cb_P11_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P11.CheckedChanged

        If cb_P11.Checked = True Then
            gb_P11.Enabled = True
        Else
            gb_P11.Enabled = False
            dti_HIP11.Value = Nothing
            dti_HFP11.Value = Nothing
        End If

    End Sub
    Private Sub cb_P21_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P21.CheckedChanged

        If cb_P21.Checked = True Then
            If cb_P11.Checked = False Then
                Alert("Programe primeiro o Período 1 da ESCALA 1", 5, True)
                cb_P21.Checked = False
                Exit Sub
            Else
                gb_P21.Enabled = True
            End If
        Else
            gb_P21.Enabled = False
            dti_HIP21a.Value = Nothing
            dti_HFP21.Value = Nothing
        End If

    End Sub
    Private Sub cb_P31_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P31.CheckedChanged

        If cb_P31.Checked = True Then
            If cb_P21.Checked = False Then
                Alert("Programe primeiro o Período 2 da ESCALA 1", 5, True)
                cb_P31.Checked = False
            Else
                gb_P31.Enabled = True
            End If
        Else
            gb_P31.Enabled = False
            dti_HIP31.Value = Nothing
            dti_HFP31.Value = Nothing
        End If

    End Sub
    Private Sub cb_P41_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P41.CheckedChanged

        If cb_P41.Checked = True Then
            If cb_P31.Checked = False Then
                Alert("Programe primeiro o Período 3 da ESCALA 1", 5, True)
                cb_P41.Checked = False
            Else
                gb_P41.Enabled = True
            End If
        Else
            gb_P41.Enabled = False
            dti_HIP41.Value = Nothing
            dti_HFP41.Value = Nothing
        End If

    End Sub
    Private Sub cb_P12_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P12.CheckedChanged

        If cb_P12.Checked = True Then
            If cb_P11.Checked = False Then
                Alert("Programe primeiro os dados da ESCALA 1", 5, True)
                cb_P12.Checked = False
            Else
                gb_P12.Enabled = True
            End If
        Else
            gb_P12.Enabled = False
            dti_HIP12.Value = Nothing
            dti_HFP12.Value = Nothing
        End If

    End Sub
    Private Sub cb_P22_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P22.CheckedChanged

        If cb_P22.Checked = True Then
            If cb_P12.Checked = False Then
                Alert("Programe primeiro o Período 1 da ESCALA 2", 5, True)
                cb_P22.Checked = False
            Else
                gb_P22.Enabled = True
            End If
        Else
            gb_P22.Enabled = False
            dti_HIP22.Value = Nothing
            dti_HFP22.Value = Nothing
        End If

    End Sub
    Private Sub cb_P32_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P32.CheckedChanged

        If cb_P32.Checked = True Then
            If cb_P22.Checked = False Then
                Alert("Programe primeiro o Período 2 da ESCALA 2", 5, True)
                cb_P32.Checked = False
            Else
                gb_P32.Enabled = True
            End If
        Else
            gb_P32.Enabled = False
            dti_HIP32.Value = Nothing
            dti_HFP32.Value = Nothing
        End If

    End Sub
    Private Sub cb_P42_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P42.CheckedChanged

        If cb_P42.Checked = True Then
            If cb_P32.Checked = False Then
                Alert("Programe primeiro o Período 3 da ESCALA 2", 5, True)
                cb_P42.Checked = False
            Else
                gb_P42.Enabled = True
            End If
        Else
            gb_P42.Enabled = False
            dti_HIP42.Value = Nothing
            dti_HFP42.Value = Nothing
        End If

    End Sub
    Private Sub CB_P13_CheckedChanged(sender As Object, e As EventArgs) Handles CB_P13.CheckedChanged

        If CB_P13.Checked = True Then
            If cb_P21.Checked = False Then
                Alert("Programe primeiro a ESCALA 2", 5, True)
                CB_P13.Enabled = False
            Else
                gb_P13.Enabled = True
            End If
        Else
            gb_P13.Enabled = False
            dti_HIP13.Value = Nothing
            dti_HFP13.Value = Nothing
        End If

    End Sub
    Private Sub cb_P23_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P23.CheckedChanged

        If cb_P23.Checked = True Then
            If cb_P23.Checked = False Then
                Alert("Programe primeiro o Período 1 da ESCALA 3", 5, True)
                cb_P23.Enabled = False
            Else
                gb_P23.Enabled = True
            End If
        Else
            gb_P23.Enabled = False
            dti_HIP23.Value = Nothing
            dti_HFP23.Value = Nothing
        End If

    End Sub
    Private Sub cb_P33_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P33.CheckedChanged

        If cb_P33.Checked = True Then
            If cb_P32.Checked = False Then
                Alert("Programe primeiro o Período 2 da ESCALA 3", 5, True)
                cb_P33.Checked = False
            Else
                gb_P33.Enabled = True
            End If
        Else
            gb_P33.Enabled = False
            dti_HIP33.Value = Nothing
            dti_HFP33.Value = Nothing
        End If

    End Sub
    Private Sub cb_P43_CheckedChanged(sender As Object, e As EventArgs) Handles cb_P43.CheckedChanged

        If cb_P43.Checked = True Then
            If cb_P42.Checked = False Then
                Alert("Programe primeiro o Período 2 da ESCALA 3", 5, True)
                cb_P43.Checked = False
            Else
                gb_P43.Enabled = True
            End If
        Else
            gb_P43.Enabled = False
            dti_HIP43.Value = Nothing
            dti_HFP43a.Value = Nothing
        End If

    End Sub
    Private Sub frmESCALA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dti_DINICIAL.Value = Now()
        dti_DFINAL.Value = DateAdd(DateInterval.Day, 30, Now())

    End Sub
    Private Sub bt_GERAR_Click(sender As Object, e As EventArgs) Handles bt_GERAR.Click

        Dim dtH1 As DateTime
        Dim dtH2 As DateTime
        Dim bolColision As Boolean = False
        Dim bolOk As Boolean = False

        'VERIFICA CONSISTÊNCIA DAS PROGRAMAÇÕES
        '//////////////////////////////////////
        If dti_DINICIAL.Value = dti_DFINAL.Value Then

            If cb_P12.Checked = True Or CB_P13.Checked = True Then
                Alert("Para programar um único dia preencha apenas a ESCALA 1!", 10, True)
                Exit Sub
            ElseIf cb_P11.Checked = False Then
                Alert("Pelo menos um perído da ESCALA 1 deve ser programado!", 10, True)
                Exit Sub
            End If
        End If

        If cb_P11.Checked = False And cb_P12.Checked = False And cb_P31.Checked = False Then
            Alert("Informe pelo menos um Período na ESCALA 1", 10, True)
            Exit Sub
        End If

        'ESCALA 1
        '////////

        If cb_P11.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP11.Value)
            dtH2 = Convert.ToDateTime(dti_HFP11.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 1, da ESCALA 1 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P11.Checked = True And cb_P21.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP11.Value)
            dtH2 = Convert.ToDateTime(dti_HIP21a.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 2, da ESCALA 1 deve ser maior que o Horário Final do PERÍODO 1", 10, True)
                Exit Sub
            End If
        End If

        If cb_P21.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP21a.Value)
            dtH2 = Convert.ToDateTime(dti_HFP21.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 2, da ESCALA 1 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P21.Checked = True And cb_P31.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP21.Value)
            dtH2 = Convert.ToDateTime(dti_HIP31.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 3, da ESCALA 1 deve ser maior que o Horário Final do PERÍODO 2", 10, True)
                Exit Sub
            End If
        End If

        If cb_P31.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP31.Value)
            dtH2 = Convert.ToDateTime(dti_HFP31.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 3, da ESCALA 1 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P31.Checked = True And cb_P41.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP31.Value)
            dtH2 = Convert.ToDateTime(dti_HIP41.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 4, da ESCALA 1 deve ser maior que o Horário Final do PERÍODO 3", 10, True)
                Exit Sub
            End If
        End If

        If cb_P41.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP41.Value)
            dtH2 = Convert.ToDateTime(dti_HFP41.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 4, da ESCALA 1 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        'ESCALA 2
        '////////

        If cb_P12.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP12.Value)
            dtH2 = Convert.ToDateTime(dti_HFP12.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 1, da ESCALA 2 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P12.Checked = True And cb_P22.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP12.Value)
            dtH2 = Convert.ToDateTime(dti_HIP22.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 2, da ESCALA 2 deve ser maior que o Horário Final do PERÍODO 1", 10, True)
                Exit Sub
            End If
        End If

        If cb_P22.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP22.Value)
            dtH2 = Convert.ToDateTime(dti_HFP22.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 2, da ESCALA 2 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P22.Checked = True And cb_P32.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP22.Value)
            dtH2 = Convert.ToDateTime(dti_HIP32.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 3, da ESCALA 2 deve ser maior que o Horário Final do PERÍODO 2", 10, True)
                Exit Sub
            End If
        End If

        If cb_P32.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP32.Value)
            dtH2 = Convert.ToDateTime(dti_HFP32.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 3, da ESCALA 2 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P32.Checked = True And cb_P42.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP32.Value)
            dtH2 = Convert.ToDateTime(dti_HIP42.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 4, da ESCALA 2 deve ser maior que o Horário Final do PERÍODO 3", 10, True)
                Exit Sub
            End If
        End If

        If cb_P42.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP42.Value)
            dtH2 = Convert.ToDateTime(dti_HFP42.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 4, da ESCALA 2 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If


        'ESCALA 3
        '////////

        If CB_P13.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP13.Value)
            dtH2 = Convert.ToDateTime(dti_HFP13.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 1, da ESCALA 3 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If CB_P13.Checked = True And cb_P23.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP13.Value)
            dtH2 = Convert.ToDateTime(dti_HIP23.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 2, da ESCALA 3 deve ser maior que o Horário Final do PERÍODO 1", 10, True)
                Exit Sub
            End If
        End If

        If cb_P23.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP23.Value)
            dtH2 = Convert.ToDateTime(dti_HFP23.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 2, da ESCALA 3 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P23.Checked = True And cb_P23.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP23.Value)
            dtH2 = Convert.ToDateTime(dti_HIP33.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 3, da ESCALA 3 deve ser maior que o Horário Final do PERÍODO 2", 10, True)
                Exit Sub
            End If
        End If

        If cb_P33.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP33.Value)
            dtH2 = Convert.ToDateTime(dti_HFP33.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 3, da ESCALA 3 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_P33.Checked = True And cb_P43.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HFP33.Value)
            dtH2 = Convert.ToDateTime(dti_HIP43.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Inicial do PERÍODO 4, da ESCALA 3 deve ser maior que o Horário Final do PERÍODO 3", 10, True)
                Exit Sub
            End If
        End If

        If cb_P43.Checked = True Then
            dtH1 = Convert.ToDateTime(dti_HIP43.Value)
            dtH2 = Convert.ToDateTime(dti_HFP43a.Value)
            If dtH2 <= dtH1 Then
                Alert("O Horário Final do PERÍODO 4, da ESCALA 3 deve ser maior que o Horário Inicial", 10, True)
                Exit Sub
            End If
        End If

        If cb_Seg1.Checked = False And cb_Ter1.Checked = False And cb_Qua1.Checked = False And cb_Qui1.Checked = False And cb_Sex1.Checked = False And cb_Sab1.Checked = False And cb_Dom1.Checked = False And cb_P11.Checked = True Then
            Alert("Escolha pelo menos um dia da semana da ESCALA 1 para gerar a ESCALA", 10, True)
            Exit Sub
        End If
        If (cb_Seg1.Checked = True Or cb_Ter1.Checked = True Or cb_Qua1.Checked = True Or cb_Qui1.Checked = True Or cb_Sex1.Checked = True Or cb_Sab1.Checked = True Or cb_Dom1.Checked = True) And cb_P11.Checked = False Then
            Alert("Configure pelo menos um Período da ESCALA 1 para gerar a ESCALA", 10, True)
            Exit Sub
        End If

        If cb_Seg2.Checked = False And cb_Ter2.Checked = False And cb_Qua2.Checked = False And cb_Qui2.Checked = False And cb_Sex2.Checked = False And cb_Sab2.Checked = False And cb_Dom2.Checked = False And cb_P12.Checked = True Then
            Alert("Escolha pelo menos um dia da semana da ESCALA 2 para gerar a ESCALA", 10, True)
            Exit Sub
        End If
        If (cb_Seg2.Checked = True Or cb_Ter2.Checked = True Or cb_Qua2.Checked = True Or cb_Qui2.Checked = True Or cb_Sex2.Checked = True Or cb_Sab2.Checked = True Or cb_Dom2.Checked = True) And cb_P12.Checked = False Then
            Alert("Configure pelo menos um Período da ESCALA 2 para gerar a ESCALA", 10, True)
            Exit Sub
        End If

        If cb_Seg3.Checked = False And cb_Ter3.Checked = False And cb_Qua3.Checked = False And cb_Qui3.Checked = False And cb_Sex3.Checked = False And cb_Sab3.Checked = False And cb_Dom3.Checked = False And CB_P13.Checked = True Then
            Alert("Escolha pelo menos um dia da semana da ESCALA 3 para gerar a ESCALA", 10, True)
            Exit Sub
        End If
        If (cb_Seg3.Checked = True Or cb_Ter3.Checked = True Or cb_Qua3.Checked = True Or cb_Qui3.Checked = True Or cb_Sex3.Checked = True Or cb_Sab3.Checked = True Or cb_Dom3.Checked = True) And cb_P31.Checked = False Then
            Alert("Configure pelo menos um Período da ESCALA 3 para gerar a ESCALA", 10, True)
            Exit Sub
        End If

        If ReadDBVERIFICAESCALA(intMACHINEID, dti_DINICIAL.Value, dti_DFINAL.Value, bolColision, strERROR) = False Then
            Alert(strERROR, 10)
            Exit Sub
        Else
            If bolColision = True Then
                Me.TopMost = False
                sMessageBox("Q", "Sobrescrever dados",
                            "Deseja sobrescrever dados já existentes com as novas informações?", taskResult)

                If taskResult = eTaskDialogResult.Yes Then
                    bolOk = True
                Else
                    Exit Sub
                End If
            Else
                bolOk = True
            End If
            Me.TopMost = True
            If bolOk = True Then

                If WriteDBGERARESCALA(intMACHINEID, dti_DINICIAL.Value, dti_DFINAL.Value,
                                      cb_Seg1.Checked, cb_Ter1.Checked, cb_Qua1.Checked, cb_Qui1.Checked, cb_Sex1.Checked, cb_Sab1.Checked, cb_Dom1.Checked,
                                      cb_Seg2.Checked, cb_Ter2.Checked, cb_Qua2.Checked, cb_Qui2.Checked, cb_Sex2.Checked, cb_Sab2.Checked, cb_Dom2.Checked,
                                      cb_Seg3.Checked, cb_Ter3.Checked, cb_Qua3.Checked, cb_Qui3.Checked, cb_Sex3.Checked, cb_Sab3.Checked, cb_Dom3.Checked,
                                      cb_P11.Checked, cb_P21.Checked, cb_P31.Checked, cb_P41.Checked,
                                      cb_P12.Checked, cb_P22.Checked, cb_P32.Checked, cb_P42.Checked,
                                      CB_P13.Checked, cb_P23.Checked, cb_P33.Checked, cb_P43.Checked,
                                      dti_HIP11.Value, dti_HFP11.Value, dti_HIP21a.Value, dti_HFP21.Value, dti_HIP31.Value, dti_HFP31.Value, dti_HIP41.Value, dti_HFP41.Value,
                                      dti_HIP12.Value, dti_HFP12.Value, dti_HIP22.Value, dti_HFP22.Value, dti_HIP32.Value, dti_HFP32.Value, dti_HIP42.Value, dti_HFP42.Value,
                                      dti_HIP13.Value, dti_HFP13.Value, dti_HIP23.Value, dti_HFP23.Value, dti_HIP33.Value, dti_HFP33.Value, dti_HIP43.Value, dti_HFP43a.Value, strERROR) = False Then
                    Alert(strERROR, 10)
                    Exit Sub
                Else
                    Information("Escala gerada com sucesso!", 10)
                    bolESCALACONFIRMED = True
                    strESCALAINICIAL = dti_DINICIAL.Text
                    strESCALAFINAL = dti_DFINAL.Text
                End If

            End If
        End If

    End Sub
    Private Sub cb_Seg1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Seg1.CheckedChanged

        If cb_Seg1.Checked = True Then
            cb_Seg2.Checked = False
            cb_Seg3.Checked = False
        End If

    End Sub
    Private Sub cb_Ter1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Ter1.CheckedChanged

        If cb_Ter1.Checked = True Then
            cb_Ter2.Checked = False
            cb_Ter3.Checked = False
        End If

    End Sub
    Private Sub cb_Qua1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qua1.CheckedChanged

        If cb_Qua1.Checked = True Then
            cb_Qua2.Checked = False
            cb_Qua3.Checked = False
        End If

    End Sub
    Private Sub cb_Qui1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qui1.CheckedChanged

        If cb_Qui1.Checked = True Then
            cb_Qui2.Checked = False
            cb_Qui3.Checked = False
        End If

    End Sub
    Private Sub cb_Sex1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sex1.CheckedChanged

        If cb_Sex1.Checked = True Then
            cb_Sex2.Checked = False
            cb_Sex3.Checked = False
        End If

    End Sub
    Private Sub cb_Sab1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sab1.CheckedChanged

        If cb_Sab1.Checked = True Then
            cb_Sab2.Checked = False
            cb_Sab3.Checked = False
        End If
    End Sub
    Private Sub cb_Dom1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Dom1.CheckedChanged

        If cb_Dom1.Checked = True Then
            cb_Dom2.Checked = False
            cb_Dom3.Checked = False
        End If

    End Sub
    Private Sub cb_Seg2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Seg2.CheckedChanged

        If cb_Seg2.Checked = True Then
            cb_Seg1.Checked = False
            cb_Seg3.Checked = False
        End If

    End Sub
    Private Sub cb_Ter2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Ter2.CheckedChanged

        If cb_Ter2.Checked = True Then
            cb_Ter1.Checked = False
            cb_Ter3.Checked = False
        End If

    End Sub
    Private Sub cb_Qua2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qua2.CheckedChanged

        If cb_Qua2.Checked = True Then
            cb_Qua1.Checked = False
            cb_Qua3.Checked = False
        End If

    End Sub
    Private Sub cb_Qui2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qui2.CheckedChanged

        If cb_Qui2.Checked = True Then
            cb_Qui1.Checked = False
            cb_Qui3.Checked = False
        End If

    End Sub
    Private Sub cb_Sex2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sex2.CheckedChanged

        If cb_Sex2.Checked = True Then
            cb_Sex1.Checked = False
            cb_Sex3.Checked = False
        End If

    End Sub
    Private Sub cb_Sab2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sab2.CheckedChanged

        If cb_Sab2.Checked = True Then
            cb_Sab1.Checked = False
            cb_Sab3.Checked = False
        End If

    End Sub
    Private Sub cb_Dom2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Dom2.CheckedChanged

        If cb_Dom2.Checked = True Then
            cb_Dom1.Checked = False
            cb_Dom3.Checked = False
        End If

    End Sub
    Private Sub cb_Seg3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Seg3.CheckedChanged

        If cb_Seg3.Checked = True Then
            cb_Seg2.Checked = False
            cb_Seg3.Checked = False
        End If

    End Sub
    Private Sub cb_Ter3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Ter3.CheckedChanged

        If cb_Ter3.Checked = True Then
            cb_Ter2.Checked = False
            cb_Ter3.Checked = False
        End If

    End Sub
    Private Sub cb_Qua3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qua3.CheckedChanged

        If cb_Qua3.Checked = True Then
            cb_Qua2.Checked = False
            cb_Qua3.Checked = False
        End If

    End Sub
    Private Sub cb_Qui3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Qui3.CheckedChanged

        If cb_Qui3.Checked = True Then
            cb_Qui2.Checked = False
            cb_Qui3.Checked = False
        End If

    End Sub
    Private Sub cb_Sex3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sex3.CheckedChanged


        If cb_Sex3.Checked = True Then
            cb_Sex2.Checked = False
            cb_Sex3.Checked = False
        End If

    End Sub
    Private Sub cb_Sab3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Sab3.CheckedChanged

        If cb_Sab3.Checked = True Then
            cb_Sab2.Checked = False
            cb_Sab3.Checked = False
        End If

    End Sub
    Private Sub cb_Dom3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Dom3.CheckedChanged

        If cb_Dom3.Checked = True Then
            cb_Dom2.Checked = False
            cb_Dom3.Checked = False
        End If

    End Sub

End Class