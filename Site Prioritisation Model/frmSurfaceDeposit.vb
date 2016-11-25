Imports System.Data.OleDb

Public Class frmSurfaceDeposit

    Dim contatoreSUD As Integer
    Dim querySUD As String
    Dim strNomiCampiSUD As String
    Dim Surface_Deposit As String
    Dim daSurfaceDeposit As New OleDbDataAdapter
    Dim incSUD As Integer
    Dim MaxRowsSUD As Integer

    '####################################################################################
    'Variables for storing values read from the database
    'Strings
    Dim strSUDTypeDeposit, strSUDOther, strSUDTemoraryRemedial As String
    'Integers
    Dim intSUDAreaAffected As Integer
    'decimali
    Dim dblSUDApproximateThickness As Double
    'Boolean
    Dim blnSUDDepoAccessYES, blnSUDDepoAccessNO, blnSUDDepoMobilYES, blnSUDDepoMobilNO As String
    'Date
    Dim datSUDDateInstalled As String

    Private Sub frmSurfaceDeposit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        ds.Clear()
        Me.txtSiteCode.Text = strCodiceSito
        
        CaricaValoriSuFormSurfaceDeposit()
        ConnectSurfaceDeposit()
        checkTabellaSUD()

        Me.txtNSurfaceDeposit.Text = MaxRowsSUD

        LeggiValoriTabellaSUD()
        ScriviValoriFormSUD()
    End Sub

    'Loading Values for comboboxes
    Sub CaricaValoriSuFormSurfaceDeposit()

        Me.cmbTypeOfDeposit.Items.Add("Spent Oxide")
        Me.cmbTypeOfDeposit.Items.Add("Foul Lime")
        Me.cmbTypeOfDeposit.Items.Add("Clinker")
        Me.cmbTypeOfDeposit.Items.Add("Coal/Coke")
        Me.cmbTypeOfDeposit.Items.Add("Tar Residues")
        Me.cmbTypeOfDeposit.Items.Add("Bog Ore")
        Me.cmbTypeOfDeposit.Items.Add("Other")


        Me.cmbTemporalMeasures.Items.Add("None")
        Me.cmbTemporalMeasures.Items.Add("Fenced Off")
        Me.cmbTemporalMeasures.Items.Add("Covered")
        Me.cmbTemporalMeasures.Items.Add("Water Damping Spray")
        Me.cmbTemporalMeasures.Items.Add("Other")

    End Sub

    Sub ConnectSurfaceDeposit()

        contatoreSUD = contatoreSUD + 1
        Surface_Deposit = "Surface_Deposit" & contatoreSUD

    End Sub

    Sub checkTabellaSUD()

        Try
            querySUD = "SELECT * FROM tSurfaceDeposit "
            daSurfaceDeposit = New OleDb.OleDbDataAdapter(querySUD, frmMain.con)
            daSurfaceDeposit.Fill(ds, Surface_Deposit)
        Catch
            MsgBox("Table 'Surface Details' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Surface_Deposit).Columns.Count

        MaxRowsSUD = ds.Tables(Surface_Deposit).Rows.Count

        If MaxRowsSUD = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsSUD > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If


        Dim strNomiCampiSUD As New Collection
        strNomiCampiSUD.Add("SUDTypeDeposit")
        strNomiCampiSUD.Add("SUDOther")
        strNomiCampiSUD.Add("SUDAreaAffected")
        strNomiCampiSUD.Add("SUDApproximateThickness")
        strNomiCampiSUD.Add("SUDTemoraryRemedial")
        strNomiCampiSUD.Add("SUDDateInstalled")
        strNomiCampiSUD.Add("SUDDepoAccessYES")
        strNomiCampiSUD.Add("SUDDepoAccessNO")
        strNomiCampiSUD.Add("SUDDepoMobilYES")
        strNomiCampiSUD.Add("SUDDepoMobilNO")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiSUD.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Surface_Deposit).Columns(intK - 1).ColumnName = strNomiCampiSUD(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiSUD.Item(intK) & " not found")
            Exit Sub
        End Try

    End Sub

    Public Sub LeggiValoriTabellaSUD()

        Try

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(0)) Then
                strSUDTypeDeposit = " "
            Else
                strSUDTypeDeposit = ds.Tables(Surface_Deposit).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(1)) Then
                strSUDOther = " "
            Else
                strSUDOther = ds.Tables(Surface_Deposit).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(2)) Then
                intSUDAreaAffected = 0
            Else
                intSUDAreaAffected = ds.Tables(Surface_Deposit).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(3)) Then
                dblSUDApproximateThickness = 0.0
            Else
                dblSUDApproximateThickness = ds.Tables(Surface_Deposit).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(4)) Then
                strSUDTemoraryRemedial = " "
            Else
                strSUDTemoraryRemedial = ds.Tables(Surface_Deposit).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(5)) Then
                datSUDDateInstalled = "01/01/2007"
            Else
                datSUDDateInstalled = ds.Tables(Surface_Deposit).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(6)) Then
                blnSUDDepoAccessYES = True
            Else
                blnSUDDepoAccessYES = ds.Tables(Surface_Deposit).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(7)) Then
                blnSUDDepoAccessNO = False
            Else
                blnSUDDepoAccessNO = ds.Tables(Surface_Deposit).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(8)) Then
                blnSUDDepoMobilYES = True
            Else
                blnSUDDepoMobilYES = ds.Tables(Surface_Deposit).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Surface_Deposit).Rows(0).Item(9)) Then
                blnSUDDepoMobilNO = False
            Else
                blnSUDDepoMobilNO = ds.Tables(Surface_Deposit).Rows(0).Item(9)
            End If
        Catch ex As Exception
            MsgBox("No records")
            strSUDTypeDeposit = " "
            strSUDOther = " "
            intSUDAreaAffected = 0.0
            dblSUDApproximateThickness = 0.0
            strSUDTemoraryRemedial = " "
            datSUDDateInstalled = "01/01/2007"
            blnSUDDepoAccessYES = True
            blnSUDDepoAccessNO = False
            blnSUDDepoMobilYES = True
            blnSUDDepoMobilNO = False
        End Try

    End Sub

    Public Sub ScriviValoriFormSUD()

        Me.cmbTypeOfDeposit.Text = strSUDTypeDeposit
        Me.txtOtherType.Text = strSUDOther
        Me.txtAreaAffected.Text = intSUDAreaAffected
        Me.txtApproxThickness.Text = dblSUDApproximateThickness
        Me.cmbTemporalMeasures.Text = strSUDTemoraryRemedial
        Me.DateTimePicker_SUD.Text = datSUDDateInstalled
        Me.rdbDepositAccessd_YES.Checked = blnSUDDepoAccessYES
        Me.rdbDepositAccessd_NO.Checked = blnSUDDepoAccessNO
        Me.rdbDepositMobilised_YES.Checked = blnSUDDepoMobilYES
        Me.rdbDepositMobilised_NO.Checked = blnSUDDepoMobilNO

    End Sub

    Private Sub NavigateRecords()

        Try
            Me.cmbTypeOfDeposit.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(0)
        Catch ex As Exception
            Me.cmbTypeOfDeposit.Text = " "
        End Try

        Try
            Me.txtOtherType.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(1)
        Catch
            Me.txtOtherType.Text = " "
        End Try

        Try
            Me.txtAreaAffected.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(2)
        Catch
            Me.txtAreaAffected.Text = " "
        End Try

        Try
            Me.txtApproxThickness.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(3)
        Catch
            Me.txtApproxThickness.Text = " "
        End Try

        Try
            Me.cmbTemporalMeasures.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(4)
        Catch
            Me.cmbTemporalMeasures.Text = " "
        End Try

        Try
            Me.DateTimePicker_SUD.Text = ds.Tables(Surface_Deposit).Rows(incSUD).Item(5)
        Catch
            Me.DateTimePicker_SUD.Text = " "
        End Try

        Try
            Me.rdbDepositAccessd_YES.Checked = ds.Tables(Surface_Deposit).Rows(incSUD).Item(6)
        Catch
            Me.rdbDepositAccessd_YES.Checked = False
        End Try

        Try
            Me.rdbDepositAccessd_NO.Checked = ds.Tables(Surface_Deposit).Rows(incSUD).Item(7)
        Catch
            Me.rdbDepositAccessd_NO.Checked = False
        End Try

        Try
            Me.rdbDepositMobilised_YES.Checked = ds.Tables(Surface_Deposit).Rows(incSUD).Item(8)
        Catch
            Me.rdbDepositMobilised_YES.Checked = False
        End Try
        Try
            Me.rdbDepositMobilised_NO.Checked = ds.Tables(Surface_Deposit).Rows(incSUD).Item(9)
        Catch
            Me.rdbDepositMobilised_NO.Checked = False
        End Try

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click

        If incSUD = 1 Then
            incSUD = 0
            LeggiValoriTabellaSUD()
            ScriviValoriFormSUD()
        ElseIf incSUD > 0 Then
            incSUD = incSUD - 1
            NavigateRecords()
        ElseIf incSUD = -1 Then
            MsgBox("No Records Yet")
        ElseIf incSUD = 0 Then
            MsgBox("First Record")
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If incSUD <> MaxRowsSUD - 1 Then
            incSUD = incSUD + 1
            NavigateRecords()
        Else
            MsgBox("No More Rows")
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If incSUD <> 0 Then
            incSUD = 0
            NavigateRecords()
        End If
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If incSUD <> MaxRowsSUD - 1 Then
            incSUD = MaxRowsSUD - 1
            NavigateRecords()
        End If
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        btnCommit.Enabled = True
        btnAddNew.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        Me.btnNext.Enabled = False
        Me.btnPrevious.Enabled = False
        Me.btnFirst.Enabled = False
        Me.btnLast.Enabled = False

        Me.cmbTypeOfDeposit.Text = " "
        Me.txtOtherType.Text = " "
        Me.txtAreaAffected.Text = 0.0
        Me.txtApproxThickness.Text = 0.0
        Me.cmbTemporalMeasures.Text = " "
        Me.DateTimePicker_SUD.Text = "01/01/2007"
        Me.rdbDepositAccessd_YES.Checked = False
        Me.rdbDepositAccessd_NO.Checked = False
        Me.rdbDepositMobilised_YES.Checked = False
        Me.rdbDepositMobilised_NO.Checked = False
    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        If incSUD <> -1 Then

            Dim cb As New OleDb.OleDbCommandBuilder(daSurfaceDeposit)
            Dim dsNewRow As DataRow

            dsNewRow = ds.Tables(Surface_Deposit).NewRow()

            dsNewRow.Item("SUDTypeDeposit") = Me.cmbTypeOfDeposit.Text
            dsNewRow.Item("SUDOther") = Me.txtOtherType.Text
            dsNewRow.Item("SUDAreaAffected") = Me.txtAreaAffected.Text
            dsNewRow.Item("SUDApproximateThickness") = Me.txtApproxThickness.Text
            dsNewRow.Item("SUDTemoraryRemedial") = Me.cmbTemporalMeasures.Text
            dsNewRow.Item("SUDDateInstalled") = Me.DateTimePicker_SUD.Text
            dsNewRow.Item("SUDDepoAccessYES") = Me.rdbDepositAccessd_YES.Checked
            dsNewRow.Item("SUDDepoAccessNO") = Me.rdbDepositAccessd_NO.Checked
            dsNewRow.Item("SUDDepoMobilYES") = Me.rdbDepositMobilised_YES.Checked
            dsNewRow.Item("SUDDepoMobilNO") = Me.rdbDepositMobilised_NO.Checked

            ds.Tables(Surface_Deposit).Rows.Add(dsNewRow)

            daSurfaceDeposit.Update(ds, Surface_Deposit)

            MsgBox("New Record added to the Database")

            daSurfaceDeposit.Update(ds, Surface_Deposit)
            ds.Clear()
            identificaFormChiamante = "SurfaceDeposit"
            Me.Close()
            dlgCommitting.Show()

            btnCommit.Enabled = False
            btnAddNew.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            Me.btnNext.Enabled = True
            Me.btnPrevious.Enabled = True
            Me.btnFirst.Enabled = True
            Me.btnLast.Enabled = True

        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daSurfaceDeposit)

        ds.Tables(Surface_Deposit).Rows(incSUD).Item(0) = Me.cmbTypeOfDeposit.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(1) = Me.txtOtherType.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(2) = Me.txtAreaAffected.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(3) = Me.txtApproxThickness.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(4) = Me.cmbTemporalMeasures.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(5) = Me.DateTimePicker_SUD.Text
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(6) = Me.rdbDepositAccessd_YES.Checked
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(7) = Me.rdbDepositAccessd_NO.Checked
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(8) = Me.rdbDepositMobilised_YES.Checked
        ds.Tables(Surface_Deposit).Rows(incSUD).Item(9) = Me.rdbDepositMobilised_NO.Checked

        daSurfaceDeposit.Update(ds, Surface_Deposit)
        cb.RefreshSchema()
        daSurfaceDeposit.InsertCommand = cb.GetInsertCommand()
        daSurfaceDeposit.DeleteCommand = cb.GetDeleteCommand()
        daSurfaceDeposit.UpdateCommand = cb.GetUpdateCommand()
        MsgBox("Data updated")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daSurfaceDeposit)

        Dim maxrows As Integer
        maxrows = ds.Tables(Surface_Deposit).Rows.Count
        If maxrows = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        Else
            ds.Tables(Surface_Deposit).Rows(incSUD).Delete()
            MaxRowsSUD = MaxRowsSUD - 1
            NavigateRecords()
            daSurfaceDeposit.Update(ds, Surface_Deposit)
            cb.RefreshSchema()
            daSurfaceDeposit.InsertCommand = cb.GetInsertCommand()
            daSurfaceDeposit.DeleteCommand = cb.GetDeleteCommand()
            daSurfaceDeposit.UpdateCommand = cb.GetUpdateCommand()
        End If
        Me.txtNSurfaceDeposit.Text = MaxRowsSUD

        If MaxRowsSUD = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsSUD > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub cmbTypeOfDeposit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypeOfDeposit.SelectedIndexChanged

        If cmbTypeOfDeposit.Text = "Other" Then
            Me.txtOtherType.Enabled = True
        Else
            Me.txtOtherType.Enabled = False
        End If

    End Sub
End Class