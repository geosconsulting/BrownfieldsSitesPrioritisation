Imports System.Data.OleDb
Public Class frmAbstractionBoreholes

    Dim contatoreABH As Integer
    Dim queryABH As String
    Dim strNomiCampiABH As String
    Dim Abstraction_Boreholes As String
    Dim daAbstractionBoreholes As New OleDbDataAdapter
    Dim incABH As Integer
    Dim MaxRowsABH As Integer


    '####################################################################################
    'Variables for storing values retrieved for boundaries
    'Strings
    Dim strABHOSTile, strABHEndUse, strABHSourceData, strABHVolumeAbstracted, strABHLicenseStatus As String
    'Integers
    Dim intABHEasting, intABHNorthing, intABHDistance As Integer
    'Booleans
    Dim blnABHInfoYes, blnABHInfoNo As String

    Private Sub AbstractionBoreholes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        ds.Clear()

        If rdbInfoYes.Checked Then
            gpbDetails.Enabled = True
        ElseIf rdbInfoNo.Checked Then
            gpbDetails.Enabled = False
        End If

        Me.txtSiteCode.Text = strCodiceSito

        CaricaValoriSuFormAbstractionBoreholes()
        ConnectTanks()
        checkTabellaABH()

        Me.txtNBoreholes.Text = MaxRowsABH
        LeggiValoriTabellaABH()
        ScriviValoriFormABH()

    End Sub

    Private Sub rdbInfoYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbInfoYes.CheckedChanged
        Me.gpbDetails.Enabled = True
    End Sub

    Private Sub rdbInfoYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbInfoYes.Click
        Me.gpbDetails.Enabled = True
    End Sub

    Private Sub rdbInfoNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbInfoNo.CheckedChanged
        Me.gpbDetails.Enabled = False
    End Sub

    Private Sub rdbInfoNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbInfoNo.Click
        Me.gpbDetails.Enabled = False
    End Sub

    Sub CaricaValoriSuFormAbstractionBoreholes()

        'Choices for end use combobox
        Me.cmbEndUse.Items.Add("Not known")
        Me.cmbEndUse.Items.Add("Not known (not PWS)")
        Me.cmbEndUse.Items.Add("Public Water Supply")
        Me.cmbEndUse.Items.Add("Private Potable")
        Me.cmbEndUse.Items.Add("Food Processing")
        Me.cmbEndUse.Items.Add("Brewing")
        Me.cmbEndUse.Items.Add("Agriculture")
        Me.cmbEndUse.Items.Add("Domestic/Agriculture")
        Me.cmbEndUse.Items.Add("Industrial")
        Me.cmbEndUse.Items.Add("Other")

        'Chioces for data source combobox
        Me.cmbSourceOfData.Items.Add("EA Search")
        Me.cmbSourceOfData.Items.Add("National Hydrogeological Map")
        Me.cmbSourceOfData.Items.Add("Regional Hydrogeological Map")

        'Choices for volume abstracted combobox
        Me.cmbVolumeAbstracted.Items.Add("> 2")
        Me.cmbVolumeAbstracted.Items.Add("0.5 - 2.0")
        Me.cmbVolumeAbstracted.Items.Add("0.2 - 0.5")
        Me.cmbVolumeAbstracted.Items.Add("0.05 - 0.2")
        Me.cmbVolumeAbstracted.Items.Add("< 0.05")
        Me.cmbVolumeAbstracted.Items.Add("Not known")

        'Choices for Licence Status combobox
        Me.cmbLicenceStatus.Items.Add("Pumping")
        Me.cmbLicenceStatus.Items.Add("Not Pumping")
        Me.cmbLicenceStatus.Items.Add("Revoked")
        Me.cmbLicenceStatus.Items.Add("Not known")

    End Sub

    Sub ConnectTanks()

        'Connection for each table contained in the Database
        contatoreABH = contatoreABH + 1
        Abstraction_Boreholes = "Abstraction_Boreholes" & contatoreABH

    End Sub

    Sub checkTabellaABH()

        Try
            queryABH = "SELECT * FROM tAbstractionBoreHoles "
            daAbstractionBoreholes = New OleDb.OleDbDataAdapter(queryABH, frmMain.con)
            daAbstractionBoreholes.Fill(ds, Abstraction_Boreholes)
        Catch
            MsgBox("Table 'Abstraction Boreholes' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Abstraction_Boreholes).Columns.Count

        MaxRowsABH = ds.Tables(Abstraction_Boreholes).Rows.Count

        If MaxRowsABH = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsABH > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

        'check field names Boundaries
        Dim strNomiCampiABH As New Collection
        strNomiCampiABH.Add("ABHInfoYes")
        strNomiCampiABH.Add("ABHInfoNo")
        strNomiCampiABH.Add("ABHOSTile")
        strNomiCampiABH.Add("ABHEasting")
        strNomiCampiABH.Add("ABHNorthing")
        strNomiCampiABH.Add("ABHDistance")
        strNomiCampiABH.Add("ABHEndUse")
        strNomiCampiABH.Add("ABHSourceData")
        strNomiCampiABH.Add("ABHVolumeAbstracted")
        strNomiCampiABH.Add("ABHLicenseStatus")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiABH.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Abstraction_Boreholes).Columns(intK - 1).ColumnName = strNomiCampiABH(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiABH.Item(intK) & " not found")
            Exit Sub
        End Try

    End Sub

    Public Sub LeggiValoriTabellaABH()

        Try
            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(0)) Then
                blnABHInfoYes = True
            Else
                blnABHInfoYes = ds.Tables(Abstraction_Boreholes).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(1)) Then
                blnABHInfoNo = False
            Else
                blnABHInfoNo = ds.Tables(Abstraction_Boreholes).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(2)) Then
                strABHOSTile = " "
            Else
                strABHOSTile = ds.Tables(Abstraction_Boreholes).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(3)) Then
                intABHEasting = 0
            Else
                intABHEasting = ds.Tables(Abstraction_Boreholes).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(4)) Then
                intABHNorthing = 0
            Else
                intABHNorthing = ds.Tables(Abstraction_Boreholes).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(5)) Then
                intABHDistance = 0
            Else
                intABHDistance = ds.Tables(Abstraction_Boreholes).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(6)) Then
                strABHEndUse = " "
            Else
                strABHEndUse = ds.Tables(Abstraction_Boreholes).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(7)) Then
                strABHSourceData = " "
            Else
                strABHSourceData = ds.Tables(Abstraction_Boreholes).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(8)) Then
                strABHVolumeAbstracted = " "
            Else
                strABHVolumeAbstracted = ds.Tables(Abstraction_Boreholes).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Abstraction_Boreholes).Rows(0).Item(9)) Then
                strABHLicenseStatus = " "
            Else
                strABHLicenseStatus = ds.Tables(Abstraction_Boreholes).Rows(0).Item(9)
            End If
        Catch
            MsgBox("No records")
            blnABHInfoYes = False
            blnABHInfoNo = False
            intABHEasting = 0
            intABHNorthing = 0
            intABHDistance = 0
            strABHEndUse = " "
            strABHSourceData = " "
            strABHVolumeAbstracted = " "
            strABHLicenseStatus = " "
        End Try

    End Sub

    Public Sub ScriviValoriFormABH()

        Me.rdbInfoYes.Checked = blnABHInfoYes
        If blnABHInfoYes = True Then
            gpbDetails.Enabled = True
        End If
        Me.rdbInfoNo.Checked = blnABHInfoNo
        Me.txtOSTile.Text = strABHOSTile
        Me.txtEasting.Text = intABHEasting
        Me.txtNorthing.Text = intABHNorthing
        Me.txtDistance.Text = intABHDistance
        Me.cmbEndUse.Text = strABHEndUse
        Me.cmbSourceOfData.Text = strABHSourceData
        Me.cmbVolumeAbstracted.Text = strABHVolumeAbstracted
        Me.cmbLicenceStatus.Text = strABHLicenseStatus

    End Sub

    Private Sub NavigateRecords()

        Try
            Me.rdbInfoYes.Checked = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(0)
        Catch ex As Exception
            Me.rdbInfoYes.Checked = False
        End Try
        Try
            Me.rdbInfoNo.Checked = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(1)
        Catch
            Me.rdbInfoNo.Checked = False
        End Try

        Try
            Me.txtOSTile.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(2)
        Catch
            Me.txtOSTile.Text = " "
        End Try
        Try
            Me.txtEasting.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(3)
        Catch
            Me.txtEasting.Text = " "
        End Try
        Try
            Me.txtNorthing.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(4)
        Catch
            Me.txtNorthing.Text = " "
        End Try

        Try
            Me.txtDistance.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(5)
        Catch ex As Exception
            Me.txtDistance.Text = " "
        End Try

        Try
            Me.cmbEndUse.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(6)
        Catch ex As Exception
            Me.cmbEndUse.Text = " "
        End Try

        Try
            Me.cmbSourceOfData.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(7)
        Catch ex As Exception
            Me.cmbSourceOfData.Text = " "
        End Try

        Try
            Me.cmbVolumeAbstracted.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(8)
        Catch ex As Exception
            Me.cmbVolumeAbstracted.Text = " "
        End Try
        Try
            Me.cmbLicenceStatus.Text = ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(9)
        Catch
            Me.cmbLicenceStatus.Text = " "
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnPrevious_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click

        If blnABHInfoYes = True Then
            gpbDetails.Enabled = True
        End If

        If incABH = 1 Then
            incABH = 0
            LeggiValoriTabellaABH()
            ScriviValoriFormABH()
        ElseIf incABH > 0 Then
            incABH = incABH - 1
            NavigateRecords()
        ElseIf incABH = -1 Then
            MsgBox("No Records Yet")
        ElseIf incABH = 0 Then
            MsgBox("First Record")
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click

        If blnABHInfoYes = True Then
            gpbDetails.Enabled = True
        End If

        If incABH <> 0 Then
            incABH = 0
            NavigateRecords()
        End If
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click

        If blnABHInfoYes = True Then
            gpbDetails.Enabled = True
        End If

        If incABH <> MaxRowsABH - 1 Then
            incABH = MaxRowsABH - 1
            NavigateRecords()
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If blnABHInfoYes = True Then
            gpbDetails.Enabled = True
        End If

        If incABH <> MaxRowsABH - 1 Then
            incABH = incABH + 1
            NavigateRecords()
        Else
            MsgBox("No More Rows")
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

        Me.rdbInfoYes.Checked = False
        Me.rdbInfoNo.Checked = False
        Me.txtOSTile.Text = " "
        Me.txtEasting.Text = " "
        Me.txtNorthing.Text = " "
        Me.txtDistance.Text = " "
        Me.cmbEndUse.Text = " "
        Me.cmbSourceOfData.Text = " "
        Me.cmbVolumeAbstracted.Text = " "
        Me.cmbLicenceStatus.Text = " "
    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        If incABH <> -1 Then

            Dim cb As New OleDb.OleDbCommandBuilder(daAbstractionBoreholes)
            Dim dsNewRow As DataRow

            dsNewRow = ds.Tables(Abstraction_Boreholes).NewRow()

            dsNewRow.Item("ABHInfoYes") = Me.rdbInfoYes.Checked
            dsNewRow.Item("ABHInfoNo") = Me.rdbInfoNo.Checked
            dsNewRow.Item("ABHOSTile") = Me.txtOSTile.Text
            dsNewRow.Item("ABHEasting") = Me.txtEasting.Text
            dsNewRow.Item("ABHNorthing") = Me.txtNorthing.Text
            dsNewRow.Item("ABHDistance") = Me.txtDistance.Text
            dsNewRow.Item("ABHEndUse") = Me.cmbEndUse.Text
            dsNewRow.Item("ABHSourceData") = Me.cmbSourceOfData.Text
            dsNewRow.Item("ABHVolumeAbstracted") = Me.cmbVolumeAbstracted.Text
            dsNewRow.Item("ABHLicenseStatus") = Me.cmbLicenceStatus.Text

            ds.Tables(Abstraction_Boreholes).Rows.Add(dsNewRow)

            daAbstractionBoreholes.Update(ds, Abstraction_Boreholes)

            MsgBox("New Record added to the Database")


            'Update procedures
            daAbstractionBoreholes.Update(ds, Abstraction_Boreholes)
            ds.Clear()
            identificaFormChiamante = "AbstractionBoreholes"
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
        Dim cb As New OleDb.OleDbCommandBuilder(daAbstractionBoreholes)

        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(0) = Me.rdbInfoYes.Checked
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(1) = Me.rdbInfoNo.Checked
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(2) = Me.txtOSTile.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(3) = Me.txtEasting.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(4) = Me.txtNorthing.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(5) = Me.txtDistance.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(6) = Me.cmbEndUse.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(7) = Me.cmbSourceOfData.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(8) = Me.cmbVolumeAbstracted.Text
        ds.Tables(Abstraction_Boreholes).Rows(incABH).Item(9) = Me.cmbLicenceStatus.Text

        daAbstractionBoreholes.Update(ds, Abstraction_Boreholes)
        cb.RefreshSchema()
        daAbstractionBoreholes.InsertCommand = cb.GetInsertCommand()
        daAbstractionBoreholes.DeleteCommand = cb.GetDeleteCommand()
        daAbstractionBoreholes.UpdateCommand = cb.GetUpdateCommand()
        MsgBox("Data updated")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daAbstractionBoreholes)

        Dim maxrows As Integer
        maxrows = ds.Tables(Abstraction_Boreholes).Rows.Count
        If maxrows = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        Else
            ds.Tables(Abstraction_Boreholes).Rows(incABH).Delete()
            MaxRowsABH = MaxRowsABH - 1
          
            NavigateRecords()
            daAbstractionBoreholes.Update(ds, Abstraction_Boreholes)
            cb.RefreshSchema()
            daAbstractionBoreholes.InsertCommand = cb.GetInsertCommand()
            daAbstractionBoreholes.DeleteCommand = cb.GetDeleteCommand()
            daAbstractionBoreholes.UpdateCommand = cb.GetUpdateCommand()
        End If
        Me.txtNBoreholes.Text = MaxRowsABH

        If MaxRowsABH = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsABH > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub
End Class