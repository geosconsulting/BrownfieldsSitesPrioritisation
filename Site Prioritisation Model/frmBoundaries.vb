Imports System.Data.OleDb

Public Class frmBoundaries


    Dim query As String
    Dim strNomiCampiBoundaries As String
    Dim Site_Boundaries As String
    Dim daBoundaries As New OleDbDataAdapter
    Dim inc As Integer
    Dim MaxRows As Integer


    '####################################################################################
    'VAriables for storin values read from the database
    'STRINGS
    Dim strFacingDirection, strBoundaryConstr, strGradient, strAdjacent, strProximal As String
    Dim strOtherLandUseAdjacent, strOtherLandUseProximal As String
    Dim strHSProxLOW, strHSProxMEDIUM, strHSProxHIGH As String
    Dim blnInfoBoundary, blnAdjacentGasWorks As String
    'FLOAT.....Converted to text 
    Dim intLength, intHeigth As String
    'BOOLEANS
    Dim blnHumanSensitivityAdjLOW, blnHumanSensitivityAdjMEDIUM, blnHumanSensitivityAdjHIGH As Boolean
    Dim blnHumanSensitivityProxLOW, HumanSensitivityProxMEDIUM, HumanSensitivityProxHIGH As Boolean
    Dim blnBarrierRUN_OFF, blnBTRESPASSING, blnBAIRBORNE_DUST, blnBSF_YES, blnBSF_No, blnBSF_NK As Boolean


    Private Sub frmBoundaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ControlBox = False
        ds.Clear()

        Me.txtSiteCode.Text = strCodiceSito
        
        CaricaValoriSuFormBoundaries()
        ConnectBoundaries()
        'checkTabellaBoundaries()
        LeggiValoriTabellaBoundaries()
        ScriviValoriFormBoundaries()

    End Sub
    'Loading values on comboboxes
    Sub CaricaValoriSuFormBoundaries()

        'Choices for Facing Direction combobox
        Me.cmbFacingDirection.Items.Add("North")
        Me.cmbFacingDirection.Items.Add("North-east")
        Me.cmbFacingDirection.Items.Add("East")
        Me.cmbFacingDirection.Items.Add("South-east")
        Me.cmbFacingDirection.Items.Add("South")
        Me.cmbFacingDirection.Items.Add("South-west")
        Me.cmbFacingDirection.Items.Add("West")
        Me.cmbFacingDirection.Items.Add("North-West")

        'Choices for Boundary Construction
        Me.cmbBoundaryConstruction.Items.Add("No wall")
        Me.cmbBoundaryConstruction.Items.Add("Solid wall")
        Me.cmbBoundaryConstruction.Items.Add("Metal palisade")
        Me.cmbBoundaryConstruction.Items.Add("Wood palisade")
        Me.cmbBoundaryConstruction.Items.Add("Chain link")
        Me.cmbBoundaryConstruction.Items.Add("Hedge")
        Me.cmbBoundaryConstruction.Items.Add("Building")
        Me.cmbBoundaryConstruction.Items.Add("River/Stream")
        Me.cmbBoundaryConstruction.Items.Add("Rock face")
        Me.cmbBoundaryConstruction.Items.Add("Steel rail fence")
        Me.cmbBoundaryConstruction.Items.Add("Wooden fence posts")
        Me.cmbBoundaryConstruction.Items.Add("Other")

        'Choices for Boundary Gradient
        Me.cmbBoundaryGradient.Items.Add("Flat")
        Me.cmbBoundaryGradient.Items.Add("Slope down")
        Me.cmbBoundaryGradient.Items.Add("Slope up")
        Me.cmbBoundaryGradient.Items.Add("Terraced down")
        Me.cmbBoundaryGradient.Items.Add("Terraced down & retained")
        Me.cmbBoundaryGradient.Items.Add("Terraced up")
        Me.cmbBoundaryGradient.Items.Add("Terraced up & retained")

        'Choices for Boundary Adjacent
        Me.cmbAdjacent.Items.Add("BG Site/Gasworks")
        Me.cmbAdjacent.Items.Add("Office/Retail")
        Me.cmbAdjacent.Items.Add("Community Buildings")
        Me.cmbAdjacent.Items.Add("Car Park/Open Yard")
        Me.cmbAdjacent.Items.Add("Residential")
        Me.cmbAdjacent.Items.Add("School/Nursery")
        Me.cmbAdjacent.Items.Add("Hospital")
        Me.cmbAdjacent.Items.Add("Brewing")
        Me.cmbAdjacent.Items.Add("Food Processing")
        Me.cmbAdjacent.Items.Add("Allotments")
        Me.cmbAdjacent.Items.Add("Recreational")
        Me.cmbAdjacent.Items.Add("Animal Sanctuary")
        Me.cmbAdjacent.Items.Add("Livestock")
        Me.cmbAdjacent.Items.Add("Road/Pathway")
        Me.cmbAdjacent.Items.Add("Agricultural")
        Me.cmbAdjacent.Items.Add("Derelict/Unused")
        Me.cmbAdjacent.Items.Add("Industrial")
        Me.cmbAdjacent.Items.Add("Railway")
        Me.cmbAdjacent.Items.Add("Woodland")
        Me.cmbAdjacent.Items.Add("Water")
        Me.cmbAdjacent.Items.Add("Other")
        Me.cmbAdjacent.Items.Add("Not known")

        'Choices for Boundary Proximal
        Me.cmbProximal.Items.Add("BG Site/Gasworks")
        Me.cmbProximal.Items.Add("Office/Retail")
        Me.cmbProximal.Items.Add("Community Buildings")
        Me.cmbProximal.Items.Add("Car Park/Open Yard")
        Me.cmbProximal.Items.Add("Residential")
        Me.cmbProximal.Items.Add("School/Nursery")
        Me.cmbProximal.Items.Add("Hospital")
        Me.cmbProximal.Items.Add("Brewing")
        Me.cmbProximal.Items.Add("Food Processing")
        Me.cmbProximal.Items.Add("Allotments")
        Me.cmbProximal.Items.Add("Recreational")
        Me.cmbProximal.Items.Add("Animal Sanctuary")
        Me.cmbProximal.Items.Add("Livestock")
        Me.cmbProximal.Items.Add("Road/Pathway")
        Me.cmbProximal.Items.Add("Agricultural")
        Me.cmbProximal.Items.Add("Derelict/Unused")
        Me.cmbProximal.Items.Add("Industrial")
        Me.cmbProximal.Items.Add("Railway")
        Me.cmbProximal.Items.Add("Woodland")
        Me.cmbProximal.Items.Add("Water")
        Me.cmbProximal.Items.Add("Other")
        Me.cmbProximal.Items.Add("Not known")

    End Sub
    Sub ConnectBoundaries()

        Site_Boundaries = "Site_Boundaries" & contatoreBND
        query = "SELECT * FROM tSiteBoundaryInformation "
        daBoundaries = New OleDb.OleDbDataAdapter(query, frmMain.con)
        daBoundaries.Fill(ds, Site_Boundaries)
        checkCampiBoundaries()

    End Sub

    Private Sub chkBoundaryInfoYES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoundaryInfoYES.Click
        If Me.chkBoundaryInfoYES.Checked Then
            Me.grp_InfoBoundary.Enabled = True
        Else
            Me.grp_InfoBoundary.Enabled = False
        End If
    End Sub

    
    Sub checkCampiBoundaries()

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Site_Boundaries).Columns.Count

        MaxRows = ds.Tables(Site_Boundaries).Rows.Count
        Me.txtNBoundariesCalc.Text = MaxRows

        If MaxRows = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRows > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

        Dim strNomiCampiBoundaries As New Collection
        strNomiCampiBoundaries.Add("InfoBoundary")
        strNomiCampiBoundaries.Add("FacingDirection")
        strNomiCampiBoundaries.Add("Length")
        strNomiCampiBoundaries.Add("Heigth")
        strNomiCampiBoundaries.Add("BoundaryConstr")
        strNomiCampiBoundaries.Add("Gradient")
        strNomiCampiBoundaries.Add("AdjacentGasWorks")
        strNomiCampiBoundaries.Add("Adjacent")
        strNomiCampiBoundaries.Add("Proximal")
        strNomiCampiBoundaries.Add("OtherLandUseAdjacent")
        strNomiCampiBoundaries.Add("OtherLandUseProximal")
        strNomiCampiBoundaries.Add("HumanSensitivityAdjLOW")
        strNomiCampiBoundaries.Add("HumanSensitivityAdjMEDIUM")
        strNomiCampiBoundaries.Add("HumanSensitivityAdjHIGH")
        strNomiCampiBoundaries.Add("HumanSensitivityProxLOW")
        strNomiCampiBoundaries.Add("HumanSensitivityProxMEDIUM")
        strNomiCampiBoundaries.Add("HumanSensitivityProxHIGH")
        strNomiCampiBoundaries.Add("BarrierRUN_OFF")
        strNomiCampiBoundaries.Add("BarrierTRESPASSING")
        strNomiCampiBoundaries.Add("BarrierAIRBORNE_DUST")
        strNomiCampiBoundaries.Add("BarrierSSLF_YES")
        strNomiCampiBoundaries.Add("BarrierSSLF_NO")
        strNomiCampiBoundaries.Add("BarrierSSLF_NK")


        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiBoundaries.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Site_Boundaries).Columns(intK - 1).ColumnName = strNomiCampiBoundaries(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiBoundaries.Item(intK) & " not found")
            Exit Sub
        End Try

    End Sub

    Public Sub LeggiValoriTabellaBoundaries()

        Try
            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(0)) Then
                blnInfoBoundary = False
            Else
                blnInfoBoundary = ds.Tables(Site_Boundaries).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(1)) Then
                strFacingDirection = " "
            Else
                strFacingDirection = ds.Tables(Site_Boundaries).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(2)) Then
                intLength = 0
            Else
                intLength = ds.Tables(Site_Boundaries).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(3)) Then
                intHeigth = 0
            Else
                intHeigth = ds.Tables(Site_Boundaries).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(4)) Then
                strBoundaryConstr = " "
            Else
                strBoundaryConstr = ds.Tables(Site_Boundaries).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(5)) Then
                strGradient = " "
            Else
                strGradient = ds.Tables(Site_Boundaries).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(6)) Then
                blnAdjacentGasWorks = False
            Else
                blnAdjacentGasWorks = ds.Tables(Site_Boundaries).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(7)) Then
                strAdjacent = " "
            Else
                strAdjacent = ds.Tables(Site_Boundaries).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(8)) Then
                strProximal = " "
            Else
                strProximal = ds.Tables(Site_Boundaries).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(9)) Then
                strOtherLandUseAdjacent = " "
            Else
                strOtherLandUseAdjacent = ds.Tables(Site_Boundaries).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(10)) Then
                strOtherLandUseProximal = " "
            Else
                strOtherLandUseProximal = ds.Tables(Site_Boundaries).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(11)) Then
                blnHumanSensitivityAdjLOW = False
            Else
                blnHumanSensitivityAdjLOW = ds.Tables(Site_Boundaries).Rows(0).Item(11)
            End If


            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(12)) Then
                blnHumanSensitivityAdjMEDIUM = False
            Else
                blnHumanSensitivityAdjMEDIUM = ds.Tables(Site_Boundaries).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(13)) Then
                blnHumanSensitivityAdjHIGH = False
            Else
                blnHumanSensitivityAdjHIGH = ds.Tables(Site_Boundaries).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(14)) Then
                blnHumanSensitivityProxLOW = False
            Else
                blnHumanSensitivityProxLOW = ds.Tables(Site_Boundaries).Rows(0).Item(14)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(15)) Then
                HumanSensitivityProxMEDIUM = False
            Else
                HumanSensitivityProxMEDIUM = ds.Tables(Site_Boundaries).Rows(0).Item(15)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(16)) Then
                HumanSensitivityProxHIGH = False
            Else
                HumanSensitivityProxHIGH = ds.Tables(Site_Boundaries).Rows(0).Item(16)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(17)) Then
                blnBarrierRUN_OFF = False
            Else
                blnBarrierRUN_OFF = ds.Tables(Site_Boundaries).Rows(0).Item(17)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(18)) Then
                blnBTRESPASSING = False
            Else
                blnBTRESPASSING = ds.Tables(Site_Boundaries).Rows(0).Item(18)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(19)) Then
                blnBAIRBORNE_DUST = False
            Else
                blnBAIRBORNE_DUST = ds.Tables(Site_Boundaries).Rows(0).Item(19)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(20)) Then
                blnBSF_YES = False
            Else
                blnBSF_YES = ds.Tables(Site_Boundaries).Rows(0).Item(20)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(21)) Then
                blnBSF_No = False
            Else
                blnBSF_No = ds.Tables(Site_Boundaries).Rows(0).Item(21)
            End If

            If IsDBNull(ds.Tables(Site_Boundaries).Rows(0).Item(22)) Then
                blnBSF_NK = False
            Else
                blnBSF_NK = ds.Tables(Site_Boundaries).Rows(0).Item(22)
            End If
        Catch
            MsgBox("No records")
            blnInfoBoundary = False
            strFacingDirection = ""
            intLength = 0
            intHeigth = 0
            strBoundaryConstr = ""
            strGradient = ""
            blnAdjacentGasWorks = False
            strAdjacent = ""
            strProximal = ""
            strOtherLandUseAdjacent = ""
            strOtherLandUseProximal = ""
            blnHumanSensitivityAdjLOW = False
            blnHumanSensitivityAdjMEDIUM = False
            blnHumanSensitivityAdjHIGH = False
            blnHumanSensitivityProxLOW = False
            blnHumanSensitivityAdjMEDIUM = False
            HumanSensitivityProxHIGH = False
            blnBarrierRUN_OFF = False
            blnBTRESPASSING = False
            blnBAIRBORNE_DUST = False
            blnBSF_YES = False
            blnBSF_No = False
            blnBSF_NK = False
        End Try

    End Sub

    Public Sub ScriviValoriFormBoundaries()

        Me.chkBoundaryInfoYES.Checked = blnInfoBoundary
        Me.cmbFacingDirection.Text = strFacingDirection
        Me.txtLength.Text = intLength
        Me.txtHeight.Text = intHeigth
        Me.cmbBoundaryConstruction.Text = strBoundaryConstr 
        Me.cmbBoundaryGradient.Text = strGradient
        Me.chkFormerGasworks.Checked = blnAdjacentGasWorks
        Me.cmbAdjacent.Text = strAdjacent
        If cmbAdjacent.Text = "Other" Then
            Me.gpbAdjacentOther.Enabled = True
        End If
        Me.cmbProximal.Text = strProximal
        If cmbProximal.Text = "Other" Then
            Me.gpbProximalOther.Enabled = True
        End If
        Me.txtLandUseAdjacent.Text = strOtherLandUseAdjacent
        Me.txtLandUseProximal.Text = strOtherLandUseProximal
        Me.rdbHumanSensitivityAdj_LOW.Checked = blnHumanSensitivityAdjLOW
        Me.rdbHumanSensitivityAdj_Medium.Checked = blnHumanSensitivityAdjMEDIUM
        Me.rdbHumanSensitivityAdj_High.Checked = blnHumanSensitivityAdjHIGH
        Me.rdbHumanSensitivityProx_Low.Checked = blnHumanSensitivityProxLOW
        Me.rdbHumanSensitivityProx_Medium.Checked = blnHumanSensitivityAdjMEDIUM
        Me.rdbHumanSensitivityProx_High.Checked = HumanSensitivityProxHIGH
        Me.chkRunOFF.Checked = blnBarrierRUN_OFF
        Me.chkTrespassing.Checked = blnBTRESPASSING
        Me.chkAirborneDust.Checked = blnBAIRBORNE_DUST
        Me.rdbSubSurfaceLateralFlow_Yes.Checked = blnBSF_YES
        Me.rdbSubSurfaceLateralFlow_No.Checked = blnBSF_No
        Me.rdbSubSurfaceLateralFlow_NK.Checked = blnBSF_NK

    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click

        If cmbAdjacent.Text = "Other" Then
            Me.gpbAdjacentOther.Enabled = True
            Me.gpbAdjacentHumanSensitivity.Enabled = True

        End If

        If cmbProximal.Text = "Other" Then
            Me.gpbProximalOther.Enabled = True
            Me.gpbProximalHumanSensitivity.Enabled = True
        End If

        If inc = 1 Then
            inc = 0
            LeggiValoriTabellaBoundaries()
            ScriviValoriFormBoundaries()
        ElseIf inc > 1 Then
            inc = inc - 1
            NavigateRecords()
        ElseIf inc = -1 Then
            MsgBox("No Records Yet")
        ElseIf inc = 0 Then
            MsgBox("First Record")
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If cmbAdjacent.Text = "Other" Then
            Me.gpbAdjacentOther.Enabled = True
            Me.gpbAdjacentHumanSensitivity.Enabled = True
        End If

        If cmbProximal.Text = "Other" Then
            Me.gpbProximalOther.Enabled = True
            Me.gpbProximalHumanSensitivity.Enabled = True
        End If

        If inc <> MaxRows - 1 Then
            inc = inc + 1
            NavigateRecords()
        Else
            MsgBox("No More Rows")
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If inc <> 0 Then
            inc = 0
            LeggiValoriTabellaBoundaries()
            ScriviValoriFormBoundaries()
        End If
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If inc <> MaxRows - 1 Then
            inc = MaxRows - 1
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

        Me.chkBoundaryInfoYES.Checked = False
        Me.cmbFacingDirection.Text = " "
        Me.txtLength.Text = " "
        Me.txtHeight.Text = " "
        Me.cmbBoundaryConstruction.Text = " "
        Me.cmbBoundaryGradient.Text = " "
        Me.chkFormerGasworks.Checked = False
        Me.cmbAdjacent.Text = " "
        Me.cmbProximal.Text = " "
        Me.txtLandUseAdjacent.Text = " "
        Me.txtLandUseProximal.Text = " "
        Me.rdbHumanSensitivityAdj_LOW.Checked = False
        Me.rdbHumanSensitivityAdj_Medium.Checked = False
        Me.rdbHumanSensitivityAdj_High.Checked = False
        Me.rdbHumanSensitivityProx_Low.Checked = False
        Me.rdbHumanSensitivityProx_Medium.Checked = False
        Me.rdbHumanSensitivityProx_High.Checked = False
        Me.chkRunOFF.Checked = False
        Me.chkTrespassing.Checked = False
        Me.chkAirborneDust.Checked = False
        Me.rdbSubSurfaceLateralFlow_Yes.Checked = False
        Me.rdbSubSurfaceLateralFlow_No.Checked = False
        Me.rdbSubSurfaceLateralFlow_NK.Checked = False


    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        If inc <> -1 Then


            Dim cb As New OleDb.OleDbCommandBuilder(daBoundaries)
            Dim dsNewRow As DataRow

            dsNewRow = ds.Tables(Site_Boundaries).NewRow()

            If Me.txtLength.Text = " ." Then
                Me.txtLength.Text = 0
            End If

            If Me.txtHeight.Text = " ." Then
                Me.txtHeight.Text = 0
            End If

            dsNewRow.Item("InfoBoundary") = Me.chkBoundaryInfoYES.Checked
            dsNewRow.Item("FacingDirection") = Me.cmbFacingDirection.Text
            dsNewRow.Item("Length") = Me.txtLength.Text
            dsNewRow.Item("Heigth") = Me.txtHeight.Text
            dsNewRow.Item("BoundaryConstr") = Me.cmbBoundaryConstruction.Text
            dsNewRow.Item("Gradient") = Me.cmbBoundaryGradient.Text
            dsNewRow.Item("AdjacentGasWorks") = Me.chkFormerGasworks.Checked
            dsNewRow.Item("Adjacent") = Me.cmbAdjacent.Text
            dsNewRow.Item("Proximal") = Me.cmbProximal.Text
            dsNewRow.Item("OtherLandUseAdjacent") = Me.txtLandUseAdjacent.Text
            dsNewRow.Item("OtherLandUseProximal") = Me.txtLandUseProximal.Text
            dsNewRow.Item("HumanSensitivityAdjLOW") = Me.rdbHumanSensitivityAdj_LOW.Checked
            dsNewRow.Item("HumanSensitivityAdjMEDIUM") = Me.rdbHumanSensitivityAdj_Medium.Checked
            dsNewRow.Item("HumanSensitivityAdjHIGH") = Me.rdbHumanSensitivityAdj_High.Checked
            dsNewRow.Item("HumanSensitivityProxLOW") = Me.rdbHumanSensitivityProx_Low.Checked
            dsNewRow.Item("HumanSensitivityProxMEDIUM") = Me.rdbHumanSensitivityProx_Medium.Checked
            dsNewRow.Item("HumanSensitivityProxHIGH") = Me.rdbHumanSensitivityProx_High.Checked
            dsNewRow.Item("BarrierRUN_OFF") = Me.chkRunOFF.Checked
            dsNewRow.Item("BarrierTRESPASSING") = Me.chkTrespassing.Checked
            dsNewRow.Item("BarrierAIRBORNE_DUST") = Me.chkAirborneDust.Checked
            dsNewRow.Item("BarrierSSLF_YES") = Me.rdbSubSurfaceLateralFlow_Yes.Checked
            dsNewRow.Item("BarrierSSLF_NO") = Me.rdbSubSurfaceLateralFlow_No.Checked
            dsNewRow.Item("BarrierSSLF_NK") = Me.rdbSubSurfaceLateralFlow_NK.Checked

            ds.Tables(Site_Boundaries).Rows.Add(dsNewRow)

            MsgBox("New Record added to the Database")

            daBoundaries.Update(ds, Site_Boundaries)
            ds.Clear()
            identificaFormChiamante = "SiteBoundaries"
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
        Dim cb As New OleDb.OleDbCommandBuilder(daBoundaries)


        ds.Tables(Site_Boundaries).Rows(inc).Item(0) = Me.chkBoundaryInfoYES.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(1) = Me.cmbFacingDirection.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(2) = Me.txtLength.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(3) = Me.txtHeight.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(4) = Me.cmbBoundaryConstruction.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(5) = Me.cmbBoundaryGradient.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(6) = Me.chkFormerGasworks.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(7) = Me.cmbAdjacent.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(8) = Me.cmbProximal.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(9) = Me.txtLandUseAdjacent.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(10) = Me.txtLandUseProximal.Text
        ds.Tables(Site_Boundaries).Rows(inc).Item(11) = Me.rdbHumanSensitivityAdj_LOW.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(12) = Me.rdbHumanSensitivityAdj_Medium.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(13) = Me.rdbHumanSensitivityAdj_High.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(14) = Me.rdbHumanSensitivityProx_Low.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(15) = Me.rdbHumanSensitivityProx_Medium.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(16) = Me.rdbHumanSensitivityProx_High.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(17) = Me.chkRunOFF.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(18) = Me.chkTrespassing.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(19) = Me.chkAirborneDust.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(20) = Me.rdbSubSurfaceLateralFlow_Yes.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(21) = Me.rdbSubSurfaceLateralFlow_No.Checked
        ds.Tables(Site_Boundaries).Rows(inc).Item(22) = Me.rdbSubSurfaceLateralFlow_NK.Checked

        'UPDATE
        daBoundaries.Update(ds, Site_Boundaries)
        cb.RefreshSchema()
        daBoundaries.InsertCommand = cb.GetInsertCommand()
        daBoundaries.DeleteCommand = cb.GetDeleteCommand()
        daBoundaries.UpdateCommand = cb.GetUpdateCommand()

        MsgBox("Data updated")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim cb As New OleDb.OleDbCommandBuilder(daBoundaries)

        MaxRows = ds.Tables(Site_Boundaries).Rows.Count
        If MaxRows = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        ElseIf inc >= 0 Then
            ds.Tables(Site_Boundaries).Rows(inc).Delete()
            MaxRows = MaxRows - 1
            NavigateRecords()
            daBoundaries.Update(ds, Site_Boundaries)
            cb.RefreshSchema()
            daBoundaries.InsertCommand = cb.GetInsertCommand()
            daBoundaries.DeleteCommand = cb.GetDeleteCommand()
            daBoundaries.UpdateCommand = cb.GetUpdateCommand()
        End If
        txtNBoundariesCalc.Text = MaxRows

        If MaxRows = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnFirst.Enabled = False
            btnLast.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        ElseIf MaxRows > 0 Then
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnFirst.Enabled = True
            btnLast.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        End If

    End Sub

    Private Sub NavigateRecords()

        Try
            Me.chkBoundaryInfoYES.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(0)
        Catch ex As Exception
            Me.chkBoundaryInfoYES.Checked = False
        End Try

        Try
            Me.cmbFacingDirection.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(1)
        Catch ex As Exception
            Me.cmbFacingDirection.Text = " "
        End Try

        Try
            Me.txtLength.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(2)
        Catch ex As Exception
            Me.txtLength.Text = " "
        End Try

        Try
            Me.txtHeight.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(3)
        Catch
            Me.txtHeight.Text = " "
        End Try
        Try
            Me.cmbBoundaryConstruction.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(4)
        Catch
            Me.cmbBoundaryConstruction.Text = " "
        End Try
        Try
            Me.cmbBoundaryGradient.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(5)
        Catch
            Me.cmbBoundaryGradient.Text = " "
        End Try

        Try
            Me.chkFormerGasworks.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(6)
        Catch ex As Exception
            Me.chkFormerGasworks.Checked = False
        End Try
        Try
            Me.cmbAdjacent.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(7)
        Catch
            Me.cmbAdjacent.Text = " "
        End Try
        Try
            Me.cmbProximal.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(8)
        Catch
            Me.cmbProximal.Text = " "
        End Try

        Try
            Me.txtLandUseAdjacent.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(9)
        Catch ex As Exception
            Me.txtLandUseAdjacent.Text = " "
        End Try

        Try
            Me.txtLandUseProximal.Text = ds.Tables(Site_Boundaries).Rows(inc).Item(10)
        Catch ex As Exception
            Me.txtLandUseProximal.Text = " "
        End Try
        Try
            Me.rdbHumanSensitivityAdj_LOW.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(11)
        Catch
            Me.rdbHumanSensitivityAdj_LOW.Checked = False
        End Try
        Try
            Me.rdbHumanSensitivityAdj_Medium.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(12)
        Catch
            Me.rdbHumanSensitivityAdj_Medium.Checked = False
        End Try
        Try
            Me.rdbHumanSensitivityAdj_High.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(13)
        Catch
            Me.rdbHumanSensitivityAdj_High.Checked = False
        End Try
        Try
            Me.rdbHumanSensitivityProx_Low.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(14)
        Catch
            Me.rdbHumanSensitivityProx_Low.Checked = False
        End Try
        Try
            Me.rdbHumanSensitivityProx_Medium.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(15)
        Catch
            Me.rdbHumanSensitivityProx_Medium.Checked = False
        End Try
        Try
            Me.rdbHumanSensitivityProx_High.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(16)
        Catch
            Me.rdbHumanSensitivityProx_High.Checked = False
        End Try

        Try
            Me.chkRunOFF.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(17)
        Catch ex As Exception
            Me.chkRunOFF.Checked = False
        End Try
        Try
            Me.chkTrespassing.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(18)
        Catch
            Me.chkTrespassing.Checked = False
        End Try
        Try
            Me.chkAirborneDust.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(19)
        Catch
            Me.chkAirborneDust.Checked = False
        End Try
        Try
            Me.rdbSubSurfaceLateralFlow_Yes.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(20)
        Catch
            Me.rdbSubSurfaceLateralFlow_Yes.Checked = False
        End Try

        Try
            Me.rdbSubSurfaceLateralFlow_No.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(21)
        Catch ex As Exception
            Me.rdbSubSurfaceLateralFlow_No.Checked = False
        End Try
        Try
            Me.rdbSubSurfaceLateralFlow_NK.Checked = ds.Tables(Site_Boundaries).Rows(inc).Item(22)
        Catch
            Me.rdbSubSurfaceLateralFlow_NK.Checked = False
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
        frmMain.Show()
    End Sub

    Private Sub cmbProximal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProximal.SelectedIndexChanged

        If cmbProximal.Text = "Other" Then
            Me.gpbProximalOther.Enabled = True
            Me.gpbProximalHumanSensitivity.Enabled = True
        Else
            Me.gpbProximalOther.Enabled = False
            Me.gpbProximalHumanSensitivity.Enabled = False
        End If
    End Sub

    Private Sub cmbAdjacent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAdjacent.SelectedIndexChanged

        If cmbAdjacent.Text = "Other" Then
            Me.gpbAdjacentOther.Enabled = True
            Me.gpbAdjacentHumanSensitivity.Enabled = True
        Else
            Me.gpbAdjacentOther.Enabled = False
            Me.gpbAdjacentHumanSensitivity.Enabled = False
        End If
    End Sub


    Private Sub chkBoundaryInfoYES_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoundaryInfoYES.CheckedChanged
        If chkBoundaryInfoYES.Checked = True Then
            Me.grp_InfoBoundary.Enabled = True
            Me.gpbBoundaryASBarrier.Enabled = True
        ElseIf chkBoundaryInfoYES.Checked = False Then
            Me.grp_InfoBoundary.Enabled = False
            Me.gpbBoundaryASBarrier.Enabled = False
        End If
    End Sub
End Class