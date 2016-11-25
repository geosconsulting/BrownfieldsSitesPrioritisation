Imports System.Data.OleDb
Public Class frmTanks

    Dim contatoreTANK As Integer
    Dim queryTANK As String
    Dim strNomiCampiTanks As String
    Dim Tank_Information As String
    Dim daTanks As New OleDbDataAdapter
    Dim incTank As Integer
    Dim MaxRowsTank As Integer

    '####################################################################################
    'VARIABLES for storing the values read from the database
    'STRINGS
    Dim strTankContent As String
    'BOOLEANS
    Dim blnTankLocationSurface, blnTankLocationBuried, blnTankIsolatedYes, blnTankIsolatedNo As String
    Dim blnTankTypeGasHolder, blnTankTypeTankTarWell As Boolean

    Private Sub frmTanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.txtSiteCode.Text = strCodiceSito

        ds.Clear()

        Me.txtSiteCode.Text = strCodiceSito


        CaricaValoriComboContentsTank()
        ConnectTanks()
        checkTabellaTanks()
        LeggiValoriTabellaTanks()
        ScriviValoriFormTanks()

        Me.txtNTanks.Text = MaxRowsTank

    End Sub
    Sub CaricaValoriComboContentsTank()

        Me.cmbContentsOfTheTank.Items.Add("Liquid: Tar")
        Me.cmbContentsOfTheTank.Items.Add("Liquid: Oil")
        Me.cmbContentsOfTheTank.Items.Add("Liquid: Ammoniacal Liquor")
        Me.cmbContentsOfTheTank.Items.Add("Liquid: Diesel/Petrol")
        Me.cmbContentsOfTheTank.Items.Add("Emulsified Tar/Water")
        Me.cmbContentsOfTheTank.Items.Add("Tarry Solid")
        Me.cmbContentsOfTheTank.Items.Add("Spent Oxide/Foul Lime")
        Me.cmbContentsOfTheTank.Items.Add("Clinker/Coal/Coke")
        Me.cmbContentsOfTheTank.Items.Add("Mixed Solid Wastes")
        Me.cmbContentsOfTheTank.Items.Add("Clean/Inert Backfill")
        Me.cmbContentsOfTheTank.Items.Add("Concrete Base")
        Me.cmbContentsOfTheTank.Items.Add("Existing Gasholder")
        Me.cmbContentsOfTheTank.Items.Add("LNG/LPG")
        Me.cmbContentsOfTheTank.Items.Add("Empty")
        Me.cmbContentsOfTheTank.Items.Add("Not known")

    End Sub
    Sub ConnectTanks()

        contatoreTANK = contatoreTANK + 1
        Tank_Information = "Tank_Information" & contatoreTANK

    End Sub
    Sub checkTabellaTanks()

        Try
            queryTANK = "SELECT * FROM tTankInformation "
            daTanks = New OleDb.OleDbDataAdapter(queryTANK, frmMain.con)
            daTanks.Fill(ds, Tank_Information)
        Catch
            MsgBox("Table 'Tank Information' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Tank_Information).Columns.Count

        MaxRowsTank = ds.Tables(Tank_Information).Rows.Count

        If MaxRowsTank = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsTank > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

        Dim strNomiCampiTanks As New Collection
        strNomiCampiTanks.Add("TankLocationSurface")
        strNomiCampiTanks.Add("TankLocationBuried")
        strNomiCampiTanks.Add("TankIsolatedYes")
        strNomiCampiTanks.Add("TankIsolatedNo")
        strNomiCampiTanks.Add("TankTypeGasHolder")
        strNomiCampiTanks.Add("TankTypeTankTarWell")
        strNomiCampiTanks.Add("TankContent")
        strNomiCampiTanks.Add("DummyPrimaryKey")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiTanks.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Tank_Information).Columns(intK - 1).ColumnName = strNomiCampiTanks(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiTanks.Item(intK) & " not found")
            Exit Sub
        End Try

    End Sub
    Public Sub LeggiValoriTabellaTanks()
        Try
            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(0)) Then
                blnTankLocationSurface = False
            Else
                blnTankLocationSurface = ds.Tables(Tank_Information).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(1)) Then
                blnTankLocationBuried = False
            Else
                blnTankLocationBuried = ds.Tables(Tank_Information).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(2)) Then
                blnTankIsolatedYes = False
            Else
                blnTankIsolatedYes = ds.Tables(Tank_Information).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(3)) Then
                blnTankIsolatedNo = False
            Else
                blnTankIsolatedNo = ds.Tables(Tank_Information).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(4)) Then
                blnTankTypeGasHolder = False
            Else
                blnTankTypeGasHolder = ds.Tables(Tank_Information).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(5)) Then
                blnTankTypeTankTarWell = False
            Else
                blnTankTypeTankTarWell = ds.Tables(Tank_Information).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Tank_Information).Rows(0).Item(6)) Then
                strTankContent = " "
            Else
                strTankContent = ds.Tables(Tank_Information).Rows(0).Item(6)
            End If
        Catch
            MsgBox("No records")
            blnTankLocationSurface = False
            blnTankLocationBuried = False
            blnTankIsolatedYes = False
            blnTankIsolatedNo = False
            blnTankTypeGasHolder = False
            blnTankTypeTankTarWell = False
            strTankContent = " "
        End Try
    End Sub
    Public Sub ScriviValoriFormTanks()

        Me.rdbAtThesurface.Checked = blnTankLocationSurface
        Me.rdbBuried.Checked = blnTankLocationBuried
        Me.rdbIsolatedYes.Checked = blnTankIsolatedYes
        Me.rdbIsolatedNO.Checked = blnTankIsolatedNo
        Me.rdbGasHolder.Checked = blnTankTypeGasHolder
        Me.rdbTankTarWell.Checked = blnTankTypeTankTarWell
        Me.cmbContentsOfTheTank.Text = strTankContent

    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        frmMain.Show()
    End Sub
    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click


        If incTank = 1 Then
            incTank = 0
            LeggiValoriTabellaTanks()
            ScriviValoriFormTanks()
        ElseIf incTank > 0 Then
            incTank = incTank - 1
            NavigateRecords()
        ElseIf incTank = -1 Then
            MsgBox("No Records Yet")
        ElseIf incTank = 0 Then
            MsgBox("First Record")
        End If

    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If incTank <> MaxRowsTank - 1 Then
            incTank = incTank + 1
            NavigateRecords()
        Else
            MsgBox("No More Rows")
        End If
    End Sub
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If incTank <> 0 Then
            incTank = 0
            NavigateRecords()
        End If
    End Sub
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If incTank <> MaxRowsTank - 1 Then
            incTank = MaxRowsTank - 1
            NavigateRecords()
        End If
    End Sub
    Private Sub NavigateRecords()

        Try
            Me.rdbAtThesurface.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(0)
        Catch
            Me.rdbAtThesurface.Checked = False
        End Try

        Try
            Me.rdbBuried.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(1)
        Catch
            Me.rdbBuried.Checked = False
        End Try

        Try
            Me.rdbIsolatedYes.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(2)
        Catch
            Me.rdbIsolatedYes.Checked = False
        End Try

        Try
            Me.rdbIsolatedNO.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(3)
        Catch
            Me.rdbIsolatedNO.Checked = False
        End Try

        Try
            Me.rdbGasHolder.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(4)
        Catch
            Me.rdbGasHolder.Checked = False
        End Try

        Try
            Me.rdbTankTarWell.Checked = ds.Tables(Tank_Information).Rows(incTank).Item(5)
        Catch ex As Exception
            Me.rdbTankTarWell.Checked = False
        End Try
        Try
            Me.cmbContentsOfTheTank.Text = ds.Tables(Tank_Information).Rows(incTank).Item(6)
        Catch
            Me.cmbContentsOfTheTank.Text = " "
        End Try

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


        Me.rdbAtThesurface.Checked = False
        Me.rdbBuried.Checked = False
        Me.rdbIsolatedYes.Checked = False
        Me.rdbIsolatedNO.Checked = False
        Me.rdbGasHolder.Checked = False
        Me.rdbTankTarWell.Checked = False
        Me.cmbContentsOfTheTank.Text = " "

    End Sub
    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click

        Dim cb As New OleDb.OleDbCommandBuilder(daTanks)
        Dim dsNewRowTank As DataRow

        dsNewRowTank = ds.Tables(Tank_Information).NewRow()

        dsNewRowTank.Item("TankLocationSurface") = Me.rdbAtThesurface.Checked
        dsNewRowTank.Item("TankLocationBuried") = Me.rdbBuried.Checked
        dsNewRowTank.Item("TankIsolatedYes") = Me.rdbIsolatedYes.Checked
        dsNewRowTank.Item("TankIsolatedNo") = Me.rdbIsolatedNO.Checked
        dsNewRowTank.Item("TankTypeGasHolder") = Me.rdbGasHolder.Checked
        dsNewRowTank.Item("TankTypeTankTarWell") = Me.rdbTankTarWell.Checked
        dsNewRowTank.Item("TankContent") = Me.cmbContentsOfTheTank.Text

        ds.Tables(Tank_Information).Rows.Add(dsNewRowTank)

        daTanks.Update(ds, Tank_Information)

        MsgBox("New Record added to the Database")

        'UPDATE
        daTanks.Update(ds, Tank_Information)
        ds.Clear()
        identificaFormChiamante = "Tanks"
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

    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim cb As New OleDb.OleDbCommandBuilder(daTanks)

        Dim MaxRows As Integer
        MaxRows = ds.Tables(Tank_Information).Rows.Count
        If MaxRows = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        Else
            ds.Tables(Tank_Information).Rows(incTank).Delete()
            MaxRowsTank = MaxRowsTank - 1
            NavigateRecords()
            daTanks.Update(ds, Tank_Information)
        End If

        Me.txtNTanks.Text = MaxRowsTank

        If MaxRowsTank = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsTank > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daTanks)

        ds.Tables(Tank_Information).Rows(incTank).Item(0) = Me.rdbAtThesurface.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(1) = Me.rdbBuried.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(2) = Me.rdbIsolatedYes.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(3) = Me.rdbIsolatedNO.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(4) = Me.rdbGasHolder.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(5) = Me.rdbTankTarWell.Checked
        ds.Tables(Tank_Information).Rows(incTank).Item(6) = Me.cmbContentsOfTheTank.Text

        daTanks.Update(ds, Tank_Information)
        cb.RefreshSchema()
        daTanks.InsertCommand = cb.GetInsertCommand()
        daTanks.DeleteCommand = cb.GetDeleteCommand()
        daTanks.UpdateCommand = cb.GetUpdateCommand()

        MsgBox("Data updated")
    End Sub

    
End Class