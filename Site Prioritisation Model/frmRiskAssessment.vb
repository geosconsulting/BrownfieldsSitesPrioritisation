Imports System.Data.OleDb
Public Class frmRiskAssessment

    Dim contatoreRA As Integer
    Dim queryRA As String
    Dim strNomiCampiRA As String
    Dim RA_Information As String
    Dim daRA As New OleDbDataAdapter
    Dim incRA As Integer
    Dim MaxRowsRA As Integer

    '####################################################################################
    'VARIABLES FOR STORING VALUES READ FROM TABLE
    'STRINGS
    Dim strPotReceptor, strPotSource, strPotPathways, strPerPathActivity As String
    Dim strComment, strComment1, strComment2, strComment3, strRiskRanking As String
    'INTEGERS
    Dim intID As Integer

    '####################################################################################
    'SEVERAL VARIABLES FOR STORING COMMENTS
    Dim Comment, Comment1, Comment2, Comment3 As String

    Private Sub frmRiskAssessment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False
        Me.txtSiteCode.Text = strCodiceSito

        ds.Clear()

        Me.txtSiteCode.Text = strCodiceSito

        CaricaValoriComboRA()
        ConnectRA()
        checkTabellaRA()
        LeggiValoriTabellaRA()
        ScriviValoriFormRA()

        Me.txtSiteCode.Text = strCodiceSito

    End Sub

    Sub CaricaValoriComboRA()

        Me.cmbRiskRanking.Items.Add("Low")
        Me.cmbRiskRanking.Items.Add("Low-Medium")
        Me.cmbRiskRanking.Items.Add("Medium")
        Me.cmbRiskRanking.Items.Add("High-Medium")
        Me.cmbRiskRanking.Items.Add("High")

    End Sub

    Sub ConnectRA()
        'CONNECT TO DATABASE
        contatoreRA = contatoreRA + 1
        RA_Information = "Risk_Assessment" & contatoreRA

    End Sub
    Sub checkTabellaRA()

        Try
            queryRA = "SELECT * FROM tRiskReduction "
            daRA = New OleDb.OleDbDataAdapter(queryRA, frmMain.con)
            daRA.Fill(ds, RA_Information)
        Catch
            MsgBox("Table 'Risk Assessment' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(RA_Information).Columns.Count

        MaxRowsRA = ds.Tables(RA_Information).Rows.Count

        If MaxRowsRA = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsRA > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

        Dim strNomiCampiRA As New Collection
        strNomiCampiRA.Add("ID")
        strNomiCampiRA.Add("PotReceptor")
        strNomiCampiRA.Add("PotSource")
        strNomiCampiRA.Add("PotPathways")
        strNomiCampiRA.Add("PerPathActivity")
        strNomiCampiRA.Add("Comment")
        strNomiCampiRA.Add("Comment1")
        strNomiCampiRA.Add("Comment2")
        strNomiCampiRA.Add("Comment3")
        strNomiCampiRA.Add("RiskRanking")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiRA.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(RA_Information).Columns(intK - 1).ColumnName = strNomiCampiRA(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiRA.Item(intK) & " not found")
            Exit Sub
        End Try

    End Sub
    Public Sub LeggiValoriTabellaRA()
        Try
            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(0)) Then
                intID = 0
            Else
                intID = ds.Tables(RA_Information).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(1)) Then
                strPotReceptor = " "
            Else
                strPotReceptor = ds.Tables(RA_Information).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(2)) Then
                strPotSource = " "
            Else
                strPotSource = ds.Tables(RA_Information).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(3)) Then
                strPotPathways = " "
            Else
                strPotPathways = ds.Tables(RA_Information).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(4)) Then
                strPerPathActivity = " "
            Else
                strPerPathActivity = ds.Tables(RA_Information).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(5)) Then
                strComment = " "
            Else
                strComment = ds.Tables(RA_Information).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(6)) Then
                strComment1 = " "
            Else
                strComment1 = ds.Tables(RA_Information).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(7)) Then
                strComment2 = " "
            Else
                strComment2 = ds.Tables(RA_Information).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(8)) Then
                strComment3 = " "
            Else
                strComment3 = ds.Tables(RA_Information).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(RA_Information).Rows(0).Item(9)) Then
                strRiskRanking = " "
            Else
                strRiskRanking = ds.Tables(RA_Information).Rows(0).Item(9)
            End If


        Catch
            MsgBox("No records")
            intID = 0
            strPotReceptor = " "
            strPotSource = " "
            strPotPathways = " "
            strComment = " "
            strComment1 = " "
            strComment2 = " "
            strComment3 = " "
            strRiskRanking = " "
        End Try
    End Sub
    Public Sub ScriviValoriFormRA()

        Me.txtPotentialTarget.Text = strPotReceptor
        Me.txtIdentifiedSources.Text = strPotSource
        Me.txtPotentialPathways.Text = strPotPathways
        Me.txtCommentsRA.Text = strComment & strComment1 & strComment2 & strComment3
        Me.cmbRiskRanking.Text = strRiskRanking

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        frmMain.Show()
    End Sub
    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If incRA = 1 Then
            incRA = 0
            LeggiValoriTabellaRA()
            ScriviValoriFormRA()
        ElseIf incRA > 0 Then
            incRA = incRA - 1
            NavigateRecords()
        ElseIf incRA = -1 Then
            MsgBox("No Records Yet")
        ElseIf incRA = 0 Then
            MsgBox("First Record")
        End If
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If incRA <> MaxRowsRA - 1 Then
            incRA = incRA + 1
            NavigateRecords()
        Else
            MsgBox("No More Rows")
        End If
    End Sub
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If incRA <> 0 Then
            incRA = 0
            NavigateRecords()
        End If
    End Sub
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If incRA <> MaxRowsRA - 1 Then
            incRA = MaxRowsRA - 1
            NavigateRecords()
        End If
    End Sub
    Private Sub NavigateRecords()

        Try
            Me.txtPotentialTarget.Text = ds.Tables(RA_Information).Rows(incRA).Item(1)
        Catch
            Me.txtPotentialTarget.Text = " "
        End Try

        Try
            Me.txtIdentifiedSources.Text = ds.Tables(RA_Information).Rows(incRA).Item(2)
        Catch
            Me.txtIdentifiedSources.Text = " "
        End Try

        Try
            Me.txtPotentialPathways.Text = ds.Tables(RA_Information).Rows(incRA).Item(3)
        Catch
            Me.txtPotentialPathways.Text = " "
        End Try

        Try
            Me.txtCommentsRA.Text = ds.Tables(RA_Information).Rows(incRA).Item(5) & _
                                    ds.Tables(RA_Information).Rows(incRA).Item(6) & _
                                    ds.Tables(RA_Information).Rows(incRA).Item(7) & _
                                    ds.Tables(RA_Information).Rows(incRA).Item(8)
        Catch
            Me.txtCommentsRA.Text = " "
        End Try

        Try
            Me.cmbRiskRanking.Text = ds.Tables(RA_Information).Rows(incRA).Item(9)
        Catch
            Me.cmbRiskRanking.Text = " "
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

        Me.txtPotentialTarget.Text = " "
        Me.txtIdentifiedSources.Text = " "
        Me.txtPotentialPathways.Text = " "
        Me.txtCommentsRA.Text = " "
        Me.cmbRiskRanking.Text = " "

    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daRA)

        Dim dsNewRowRA As DataRow
        dsNewRowRA = ds.Tables(RA_Information).NewRow()

        dsNewRowRA.Item("PotReceptor") = Me.txtPotentialTarget.Text
        dsNewRowRA.Item("PotSource") = Me.txtIdentifiedSources.Text
        dsNewRowRA.Item("PotPathways") = Me.txtPotentialPathways.Text

        'COMMENT DIVIDED IN $ DIFFERENT FIELDS DUE TO THE LIMITATION OF MS ACCES TEXT FIELDS
        DividiCommento()
        dsNewRowRA.Item("Comment") = Comment
        dsNewRowRA.Item("Comment1") = Comment1
        dsNewRowRA.Item("Comment2") = Comment2
        dsNewRowRA.Item("Comment3") = Comment3

        dsNewRowRA.Item("RiskRanking") = Me.cmbRiskRanking.Text

        ds.Tables(RA_Information).Rows.Add(dsNewRowRA)

        daRA.Update(ds, RA_Information)

        MsgBox("New Record added to the Database")

        'UPDATE
        daRA.Update(ds, RA_Information)
        ds.Clear()
        identificaFormChiamante = "RiskAssessment"
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        DividiCommento()

        Dim cb As New OleDb.OleDbCommandBuilder(daRA)

        ds.Tables(RA_Information).Rows(incRA).Item(1) = Me.txtPotentialTarget.Text
        ds.Tables(RA_Information).Rows(incRA).Item(2) = Me.txtIdentifiedSources.Text
        ds.Tables(RA_Information).Rows(incRA).Item(3) = Me.txtPotentialPathways.Text
        ds.Tables(RA_Information).Rows(incRA).Item(5) = Comment
        ds.Tables(RA_Information).Rows(incRA).Item(6) = Comment1
        ds.Tables(RA_Information).Rows(incRA).Item(7) = Comment2
        ds.Tables(RA_Information).Rows(incRA).Item(8) = Comment3
        ds.Tables(RA_Information).Rows(incRA).Item(9) = Me.cmbRiskRanking.Text


        'Serie di update e refresh per il dataset ed il dataadapter
        daRA.Update(ds, RA_Information)
        cb.RefreshSchema()
        daRA.InsertCommand = cb.GetInsertCommand()
        daRA.DeleteCommand = cb.GetDeleteCommand()
        daRA.UpdateCommand = cb.GetUpdateCommand()

        MsgBox("Data updated")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim cb As New OleDb.OleDbCommandBuilder(daRA)

        Dim MaxRows As Integer
        MaxRows = ds.Tables(RA_Information).Rows.Count
        If MaxRows = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        Else
            ds.Tables(RA_Information).Rows(incRA).Delete()
            MaxRowsRA = MaxRowsRA - 1
            NavigateRecords()
            daRA.Update(ds, RA_Information)
        End If

        If MaxRowsRA = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRowsRA > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub txtCommentsRA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCommentsRA.TextChanged

        'Dim OneCharacter As Char
        Dim Testo As String
        Dim lunghezzaTesto As Integer


        Testo = Trim(txtCommentsRA.Text)
        lunghezzaTesto = Testo.Length


        Label7.Text = ("Number of characters is: " & lunghezzaTesto)

    End Sub


    Sub DividiCommento()
        'Dim OneCharacter As Char
        Dim Testo As String
        Dim lunghezzaTesto As Integer


        Testo = Trim(txtCommentsRA.Text)
        'MsgBox(Testo)
        lunghezzaTesto = Testo.Length
        'MsgBox(lunghezzaTesto)

        Dim numContenitori As Double
        numContenitori = lunghezzaTesto / 250

        If numContenitori <= 1 Then
            Comment = Mid(Testo, 1, 250)
        ElseIf numContenitori <= 2 And numContenitori > 1 Then
            Comment = Mid(Testo, 1, 250)
            Comment1 = Mid(Testo, 251, 250)
        ElseIf numContenitori <= 3 And numContenitori > 2 Then
            Comment = Mid(Testo, 1, 250)
            Comment1 = Mid(Testo, 251, 250)
            Comment2 = Mid(Testo, 501, 250)
        ElseIf numContenitori <= 4 And numContenitori > 3 Then
            Comment = Mid(Testo, 1, 250)
            Comment1 = Mid(Testo, 251, 250)
            Comment2 = Mid(Testo, 501, 250)
            Comment3 = Mid(Testo, 751, 250)
        End If

    End Sub

    Private Sub txtPotentialTarget_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPotentialTarget.TextChanged

    End Sub
End Class