Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Resources

Public Class frmMain

    Dim nomefile As String
    Dim testoConnessione As String
    Dim testFile As System.IO.FileInfo
    Dim folderPath As String
    Dim fileName As String

    Dim MaxRows As Integer

    'Dim ds As New DataSet
    Dim daRefer As OleDb.OleDbDataAdapter
    Dim sqlRefer As String

    Dim indiceRiga As Integer
    Dim DummyPrimary As Integer
    Dim DocTitle, Author, DateRef As String

    Dim valoreOriginale As String
    Dim valoreNuovo As String

    'Connection to the Access Database
    Public con As New System.Data.OleDb.OleDbConnection

    Dim daSiteInformation, daSurfaceDetails, daSubSurfaceConditions, daYourDetails As OleDb.OleDbDataAdapter
    Dim daComments, daGWAbstraction, daSWEnvironment, daContaminantsPathways, daSiteStatus, daRef As OleDb.OleDbDataAdapter

    ' Strings for retriving the data to fill the Data Adapters 
    Dim sql, sqlSD, sqlSSC, sqlYD, sqlC, sqlGWA, sqlCP, sqlRef As String

    Dim contatore, inc As Integer

    '####################################################################################
    'Name of all the data adapters for each TAB in the main Window
    Dim Site_Information, Surface_Details, SubSurface_Conditions, Your_Details, Tabella_Commenti As String
    Dim GroundWater_Abstraction, SurfaceWater_Environment, Contamination_Pathway, SiteStatus, Refer As String

    '####################################################################################
    'Variables for the controls of Site Information on TAB1
    'strings
    Dim strFileLoc, strNomeSito, strAddress1, strAddress2 As String
    Dim strTown, strCounty, strPostCode, strLocalAuthority, strNG_Square, strSiteGradient As String
    Dim strDirectionSlope, strSiteOccupation, strSiteUse1, strSiteUse2, strSiteUse3, Comments As String
    'integer
    Dim intEasting, intNorthing, intNoPartsSite As Integer
    'Double
    Dim dblOperational, dblSiteSize, intAnnualRainfall As Double
    'Booleans
    Dim blnCoalGasification, blnCoalCarbonisation, blnGasPurification As Boolean
    Dim blnOilReforming, blnGasStorage, blnNoGasworksUses, blnCWGPlant As Boolean

    '####################################################################################
    'Variables for the controls of Surface Details on TAB2
    'Strings
    Dim intCovBuildStruct, intCovHardstand, intCovExpSoil, intCovVeg, intCovGravel, intCovPerm, intCovImperm, intCovOther As Integer
    'Booleans
    Dim blnSurfDetInfoYes, blnSurfDetInfoNo, blnOverallNatYes, blnOverallNatNo, blnFloodHistYes, blnFloodHistNo, blnStandHistYes, blnStandHistNo As Boolean

    '####################################################################################
    'Variabili di lettura del SubSurface Conditions su TAB3
    'Strings
    Dim PerchedWT, SupDep, BedGeol As String
    'INTERI
    Dim GasBoundX, ElectricBoundX, WaterBoundX, TelecomBoundX, SewersBoundX As Integer
    'Float
    Dim MaxThickMG, MaxThickSD As Double
    'Booleans
    Dim MadeGroundPresent, MadeGroundNotPresent, MadeGroundNKnown, MadeGroundCont, MadeGroundContNo, MadeGroundContNK As Boolean
    Dim SupDepPresent, SupDepPresentNo, SupDepPresentNK, SupDepCont, SupDepContNo, GasSer As Boolean
    Dim ElectricSer, WaterSer, TelecomSer, SewersSer, NoSer As Boolean

    '####################################################################################
    'Variables for the controls of Ground Water Abstraction TAB4
    'Strings
    Dim AquiClass, AquiVul, DataSource As String
    'Booleans
    Dim AquiContam, AquiContamNo, AquiContamNK, SiteSource, SiteSourceNo, SiteSourceNK, LatFlow, LatFlowNo, LatFlowNK, SPZ, SPZNo, SPZNK As Boolean

    '####################################################################################
    'Variables for the controls of Surface Water Environment TAB5
    'double
    Dim dblWBDistSite1, dblWBDistSite2, dblWBDistSite3, dblTTDistSite1, dblTTDistSite2, dblTTDistSite3 As Double
    'Strings
    Dim strWBtype1, strWBtype2, strWBtype3, strExistGQAWatQual1, strExistGQAWatQual2, strExistGQAWatQual3 As String
    Dim strFlowRate1, strFlowRate2, strFlowRate3, strTargType1, strTargType2, strTargType3, strSWendUse As String
    'Booleans
    Dim blnNoInfoWB, blnNoInfoSenTarg, blnSWuse, blnSWuseNo, blnSWuseNK As Boolean

    '####################################################################################
    'Variables for the controls of Contamination Pathways TAB6
    'Strings
    Dim strSRO_ActionTaken, strOEH_ActionTaken, strDP_ActionTaken, strAirB_ActionTaken As String
    Dim strVF_ActionTaken, strLF_ActionTaken, strLF_DirPlume, strVC_TypeCond As String
    'Booleans
    Dim blnSRO_InfPath, blnSRO_KnwnPath, blnSRO_CrssBoundContam, blnSRO_Addressed As Boolean
    Dim blnOEH_InfPath, blnOEH_KnwnPath, blnOEH_CrssBoundContam, blnOEH_Addressed As Boolean
    Dim blnDP_InfPath, blnDP_KnwnPath, blnDP_CrssBoundContam, blnDP_Addressed As Boolean
    Dim blnAirB_InfPath, blnAirB_KnwnPath, blnAirB_CrssBoundContam, blnAirB_Addressed As Boolean
    Dim blnVF_InfPath, blnVF_KnwnPath, blnVF_CrssBoundContam, blnVF_Addressed As Boolean
    Dim blnLF_InfPath, blnLF_KnwnPath, blnLF_CrssBoundContam, blnLF_Addressed As Boolean
    Dim blnVC_InfPath, blnVC_KnwnPath, blnVC_Sealed, blnVC_SealedNo, blnVC_SealedNK As Boolean

    '####################################################################################
    'Variables for the controls of References su TAB7 
    'Strings
    Dim strSiteStatus As String

    '####################################################################################
    'Variables for the controls of Comments su TAB8 12 
    'In order to write up to 3060 carachters 12 variables have been prepared
    Dim Comment1, Comment2, Comment3, Comment4, Comment5, Comment6 As String
    Dim Comment7, Comment8, Comment9, Comment10, Comment11, Comment12 As String

    Private Sub TabSiteInformation_Click(sender As Object, e As EventArgs) Handles TabSiteInformation.Click

    End Sub

    Private Sub OleDbConnection1_InfoMessage(sender As Object, e As OleDbInfoMessageEventArgs) Handles OleDbConnection1.InfoMessage

    End Sub

    Private Sub DataArchiveBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles DataArchiveBindingSource.CurrentChanged

    End Sub

    '####################################################################################
    'Variables for the controls of Your Details on TAB9 
    'Strings
    Dim YourName, CompanyNameDetails, CompanyAddress1, CompanyAddress2 As String
    Dim Town, County, PostCode, CompanyTelNumber, YourExtension As String
    'date
    Dim DataCompilazione As Date

    '####################################################################################
    'Variables used for CROSS CHECK in the last TAB
    '####################################################################################
    Dim conLista, conOp, conNop As New System.Data.OleDb.OleDbConnection
    Dim dsSiteList, dsSiteOpS, dsSiteNOps As New DataSet
    Dim daSiteList, daSiteOps, daSiteNOps As OleDbDataAdapter
    Dim tabellaListaSiti, tabellaSiteCode As String
    Dim testoconnessioneLista As String
    Dim querySiteList, querySiteOps, querySiteNOps As String
    Dim stringaYOP, stringaNOP As String
    Dim SitelistAttivo As String
    Dim nomefilePDF As String

    '####################################################################################
    'Variables used for FLAGGING ASSUMED DATA DURING PRIORITISATION
    '####################################################################################
    Dim FLAG_HAZARDTANKS, FLAGAIRBORNE, FLAG_GROUNDWATER As Integer

    'Opening the Main Window 
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ControlBox = False

        'Opening a MS Access connection for the first time?
        contatore = 0

        Me.ToolTipDistance.IsBalloon = True

        '***********************************************************************
        'Loading data on various COmboBOX placed in the Main Window
        '***********************************************************************
        CaricaValoriSuiCombo()

        'C:\Users\Fabio\Documents\Visual Studio 2015\Projects\Site Prioritisation Model Calc\EM_ModelSiteList.mdb

        'Connection to the MASTER DATABASE - Is a Static Connection
        testoconnessioneLista = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";" &
                       "User ID=Admin;Data Source= C:\Users\Fabio\Documents\Visual Studio 2015\Projects\Site Prioritisation Model Calc\EM_ModelSiteList.mdb;"

        conLista.ConnectionString = testoconnessioneLista

        'Try
        ' conLista.Open()
        'Catch ex As Exception
        '
        'MsgBox("Master Database not found ", MsgBoxStyle.Critical, "Master Database deleted or moved")
        'MsgBox("Please copy a valid version of the database or reinstall the software", MsgBoxStyle.OkOnly, "Master Database deleted or moved")
        'Me.Close()
        'Exit Sub
        'End Try

        'Fill retrieves rows from the data source by using the SELECT statement
        'OleDbDataAdapter1.Fill(DataSet11)

        'querySiteList = "SELECT * FROM Data_Archive"
        'daSiteList = New OleDbDataAdapter(querySiteList, conLista)
        'tabellaListaSiti = "Lista Siti"


    End Sub

    'Loading all needed values for the vatious comboboxes on the Main Window
    Sub CaricaValoriSuiCombo()

        'Choices Site Gradient combobox
        Me.cmbSiteGradient.Items.Add("Embanked")
        Me.cmbSiteGradient.Items.Add("Level")
        Me.cmbSiteGradient.Items.Add("Not known")
        Me.cmbSiteGradient.Items.Add("Sloped")
        Me.cmbSiteGradient.Items.Add("Terraced")

        'Choices Direction Slope combobox
        Me.cmbDirectionSlope.Items.Add("No slope")
        Me.cmbDirectionSlope.Items.Add("North")
        Me.cmbDirectionSlope.Items.Add("North-east")
        Me.cmbDirectionSlope.Items.Add("East")
        Me.cmbDirectionSlope.Items.Add("South-east")
        Me.cmbDirectionSlope.Items.Add("South")
        Me.cmbDirectionSlope.Items.Add("South-west")
        Me.cmbDirectionSlope.Items.Add("West")
        Me.cmbDirectionSlope.Items.Add("North-West")
        Me.cmbDirectionSlope.Items.Add("Not known")

        'Choices Site Occupation combobox
        Me.cmbSiteOccupation.Items.Add("Frequently")
        Me.cmbSiteOccupation.Items.Add("24 hours")
        Me.cmbSiteOccupation.Items.Add("Working hours")
        Me.cmbSiteOccupation.Items.Add("Infrequently")
        Me.cmbSiteOccupation.Items.Add("Not known")

        'Choices per Perched ComboBox su tab3
        Me.cmbPerchedWaterTable_2.Items.Add("Present (known from SI)")
        Me.cmbPerchedWaterTable_2.Items.Add("Suspected (Desk Study)")
        Me.cmbPerchedWaterTable_2.Items.Add("Not present (known from SI)")
        Me.cmbPerchedWaterTable_2.Items.Add("Not suspected (Desk Study)")
        Me.cmbPerchedWaterTable_2.Items.Add("Not known")

        'Choices per BedRock Geology ComboBox su tab3
        Me.cmbBedrockGeology_2.Items.Add("Chalk/Limestone")
        Me.cmbBedrockGeology_2.Items.Add("Sandstone/Sands")
        Me.cmbBedrockGeology_2.Items.Add("Granite/Basalt")
        Me.cmbBedrockGeology_2.Items.Add("Silts/Clays")
        Me.cmbBedrockGeology_2.Items.Add("Coal Measures")
        Me.cmbBedrockGeology_2.Items.Add("Metamorphic (Schists etc.)")
        Me.cmbBedrockGeology_2.Items.Add("Slate/Shale/Marl")
        Me.cmbBedrockGeology_2.Items.Add("Mercia Mudstone")
        Me.cmbBedrockGeology_2.Items.Add("Other")
        Me.cmbBedrockGeology_2.Items.Add("Not known")

        'Choices per Type of Deposit ComboBox su tab3
        Me.cmbTypeOfDeposit_2.Items.Add("Clay, Silts")
        Me.cmbTypeOfDeposit_2.Items.Add("Sand, Gravel")
        Me.cmbTypeOfDeposit_2.Items.Add("Clay/Silt over Sand/Gravel")
        Me.cmbTypeOfDeposit_2.Items.Add("Sand/Gravel over Clay/Silt")
        Me.cmbTypeOfDeposit_2.Items.Add("Not known")

        'Choices per NRA Aquifer Classification  ComboBox su tab4
        Me.cmbNRAAquiferClassification_3.Items.Add("Major")
        Me.cmbNRAAquiferClassification_3.Items.Add("Minor")
        Me.cmbNRAAquiferClassification_3.Items.Add("Non-aquifer")
        Me.cmbNRAAquiferClassification_3.Items.Add("Unclassified")

        'Choices per NRA Aquifer Vulnerability ComboBox su tab4
        Me.cmbNRAAquiferVulnerability_3.Items.Add("High")
        Me.cmbNRAAquiferVulnerability_3.Items.Add("Medium")
        Me.cmbNRAAquiferVulnerability_3.Items.Add("Low")
        Me.cmbNRAAquiferVulnerability_3.Items.Add("Unclassified")

        'Choices per Current Site Status ComboBox su References
        Me.cmbCurrentSiteStatus_6.Items.Add("Historical Reports (Pre v2.1)")
        Me.cmbCurrentSiteStatus_6.Items.Add("Desk Study")
        Me.cmbCurrentSiteStatus_6.Items.Add("Site Investigation")
        Me.cmbCurrentSiteStatus_6.Items.Add("Supplementary Site Investigation")
        Me.cmbCurrentSiteStatus_6.Items.Add("Remediation Close-out")

        'Choices per Data Source ComboBox su tab4
        Me.cmbDataSource_3.Items.Add("Environment Agency")
        Me.cmbDataSource_3.Items.Add("1:1,000,000 Map")
        Me.cmbDataSource_3.Items.Add("1:100,000 Map")
        Me.cmbDataSource_3.Items.Add("Regional Appendix")
        Me.cmbDataSource_3.Items.Add("Scotland-Classified by R & T")
        Me.cmbDataSource_3.Items.Add("Not Sourced")

        'Choices per cmbWaterBodyType ComboBox su tab5
        Me.cmbWaterBodyType1_4.Items.Add(" ")
        Me.cmbWaterBodyType1_4.Items.Add("River")
        Me.cmbWaterBodyType1_4.Items.Add("Stream")
        Me.cmbWaterBodyType1_4.Items.Add("Canal")
        Me.cmbWaterBodyType1_4.Items.Add("Lake")
        Me.cmbWaterBodyType1_4.Items.Add("Reservoir")
        Me.cmbWaterBodyType1_4.Items.Add("Sea")
        Me.cmbWaterBodyType1_4.Items.Add("Drainage Ditch")
        Me.cmbWaterBodyType1_4.Items.Add("Ornamental Lake")

        Me.cmbWaterBodyType2_4.Items.Add(" ")
        Me.cmbWaterBodyType2_4.Items.Add("River")
        Me.cmbWaterBodyType2_4.Items.Add("Stream")
        Me.cmbWaterBodyType2_4.Items.Add("Canal")
        Me.cmbWaterBodyType2_4.Items.Add("Lake")
        Me.cmbWaterBodyType2_4.Items.Add("Reservoir")
        Me.cmbWaterBodyType2_4.Items.Add("Sea")
        Me.cmbWaterBodyType2_4.Items.Add("Drainage Ditch")
        Me.cmbWaterBodyType2_4.Items.Add("Ornamental Lake")

        Me.cmbWaterBodyType3_4.Items.Add(" ")
        Me.cmbWaterBodyType3_4.Items.Add("River")
        Me.cmbWaterBodyType3_4.Items.Add("Stream")
        Me.cmbWaterBodyType3_4.Items.Add("Canal")
        Me.cmbWaterBodyType3_4.Items.Add("Lake")
        Me.cmbWaterBodyType3_4.Items.Add("Reservoir")
        Me.cmbWaterBodyType3_4.Items.Add("Sea")
        Me.cmbWaterBodyType3_4.Items.Add("Drainage Ditch")
        Me.cmbWaterBodyType3_4.Items.Add("Ornamental Lake")

        'Choices for cmbGQAWaterQuality ComboBox on tab5 3 controls repeated
        Me.cmbGQAWaterQuality1_4.Items.Add(" ")
        Me.cmbGQAWaterQuality1_4.Items.Add("Good")
        Me.cmbGQAWaterQuality1_4.Items.Add("Fair")
        Me.cmbGQAWaterQuality1_4.Items.Add("Poor")
        Me.cmbGQAWaterQuality1_4.Items.Add("Bad")
        Me.cmbGQAWaterQuality1_4.Items.Add("Unclassified")

        Me.cmbGQAWaterQuality2_4.Items.Add(" ")
        Me.cmbGQAWaterQuality2_4.Items.Add("Good")
        Me.cmbGQAWaterQuality2_4.Items.Add("Fair")
        Me.cmbGQAWaterQuality2_4.Items.Add("Poor")
        Me.cmbGQAWaterQuality2_4.Items.Add("Bad")
        Me.cmbGQAWaterQuality2_4.Items.Add("Unclassified")

        Me.cmbGQAWaterQuality3_4.Items.Add(" ")
        Me.cmbGQAWaterQuality3_4.Items.Add("Good")
        Me.cmbGQAWaterQuality3_4.Items.Add("Fair")
        Me.cmbGQAWaterQuality3_4.Items.Add("Poor")
        Me.cmbGQAWaterQuality3_4.Items.Add("Bad")
        Me.cmbGQAWaterQuality3_4.Items.Add("Unclassified")

        'Choices for cmbFlowRate ComboBox su tab5
        Me.cmbFlowRate1_4.Items.Add(" ")
        Me.cmbFlowRate1_4.Items.Add("0 - 2.5 CuM/Sec")
        Me.cmbFlowRate1_4.Items.Add("2.5 - 10 CuM/Sec")
        Me.cmbFlowRate1_4.Items.Add("10 - 40 CuM/Sec")
        Me.cmbFlowRate1_4.Items.Add("40 - 80 CuM/Sec")
        Me.cmbFlowRate1_4.Items.Add("> 80 CuM/Sec")
        Me.cmbFlowRate1_4.Items.Add("Unclassified")
        Me.cmbFlowRate1_4.Items.Add("Tidal")

        Me.cmbFlowRate2_4.Items.Add(" ")
        Me.cmbFlowRate2_4.Items.Add("0 - 2.5 CuM/Sec")
        Me.cmbFlowRate2_4.Items.Add("2.5 - 10 CuM/Sec")
        Me.cmbFlowRate2_4.Items.Add("10 - 40 CuM/Sec")
        Me.cmbFlowRate2_4.Items.Add("40 - 80 CuM/Sec")
        Me.cmbFlowRate2_4.Items.Add("> 80 CuM/Sec")
        Me.cmbFlowRate2_4.Items.Add("Unclassified")
        Me.cmbFlowRate2_4.Items.Add("Tidal")

        Me.cmbFlowRate3_4.Items.Add(" ")
        Me.cmbFlowRate3_4.Items.Add("0 - 2.5 CuM/Sec")
        Me.cmbFlowRate3_4.Items.Add("2.5 - 10 CuM/Sec")
        Me.cmbFlowRate3_4.Items.Add("10 - 40 CuM/Sec")
        Me.cmbFlowRate3_4.Items.Add("40 - 80 CuM/Sec")
        Me.cmbFlowRate3_4.Items.Add("> 80 CuM/Sec")
        Me.cmbFlowRate3_4.Items.Add("Unclassified")
        Me.cmbFlowRate3_4.Items.Add("Tidal")

        'Choices for cmbSensitiveEnvironmentalTargetsType ComboBox on tab5
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add(" ")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("SSSI")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("National Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Marine Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Conservation Area")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Special Protection Area")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Livestock")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Crops")
        Me.cmbSensitiveEnvironmentalTargetsType1_4.Items.Add("Game Animals")

        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add(" ")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("SSSI")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("National Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Marine Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Conservation Area")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Special Protection Area")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Livestock")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Crops")
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Items.Add("Game Animals")

        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add(" ")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("SSSI")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("National Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Marine Nature Reserve")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Conservation Area")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Special Protection Area")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Livestock")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Crops")
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Items.Add("Game Animals")

        'Choices per cmbNearestOne ComboBox on tab5
        Me.cmbNearestOne_4.Items.Add(" ")
        Me.cmbNearestOne_4.Items.Add("Public Water Supply")
        Me.cmbNearestOne_4.Items.Add("Private Potable Supply")
        Me.cmbNearestOne_4.Items.Add("Food Processing")
        Me.cmbNearestOne_4.Items.Add("Agriculture")
        Me.cmbNearestOne_4.Items.Add("Industrial")
        Me.cmbNearestOne_4.Items.Add("Leisure")
        Me.cmbNearestOne_4.Items.Add("Other")
        Me.cmbNearestOne_4.Items.Add("Not known")

        'Choices for various Action Taken on Tab 6 
        Me.cmb15_5.Items.Add(" ")
        Me.cmb15_5.Items.Add("None")
        Me.cmb15_5.Items.Add("Temp. surface encapsulation")
        Me.cmb15_5.Items.Add("Source removal")
        Me.cmb15_5.Items.Add("Barrier")
        Me.cmb15_5.Items.Add("Other")

        Me.cmb25_5.Items.Add(" ")
        Me.cmb25_5.Items.Add("None")
        Me.cmb25_5.Items.Add("Source removal")
        Me.cmb25_5.Items.Add("Source encapsulation")
        Me.cmb25_5.Items.Add("Barrier")
        Me.cmb25_5.Items.Add("Other")

        Me.cmb35_5.Items.Add(" ")
        Me.cmb35_5.Items.Add("None")
        Me.cmb35_5.Items.Add("Source removal")
        Me.cmb35_5.Items.Add("Source encapsulation")
        Me.cmb35_5.Items.Add("Block drain/pipe")
        Me.cmb35_5.Items.Add("Other")

        Me.cmb45_5.Items.Add(" ")
        Me.cmb45_5.Items.Add("None")
        Me.cmb45_5.Items.Add("Source removal")
        Me.cmb45_5.Items.Add("Source encapsulation")
        Me.cmb45_5.Items.Add("Barrier")
        Me.cmb45_5.Items.Add("Other")

        Me.cmb55_5.Items.Add(" ")
        Me.cmb55_5.Items.Add("None")
        Me.cmb55_5.Items.Add("Source removal")
        Me.cmb55_5.Items.Add("Source encapsulation")
        Me.cmb55_5.Items.Add("Pump & Treat")
        Me.cmb55_5.Items.Add("Bioremediation")
        Me.cmb55_5.Items.Add("Other")

        Me.cmb65_5.Items.Add(" ")
        Me.cmb65_5.Items.Add("None")
        Me.cmb65_5.Items.Add("Source removal")
        Me.cmb65_5.Items.Add("Source encapsulation")
        Me.cmb65_5.Items.Add("Pump & Treat")
        Me.cmb65_5.Items.Add("Barrier Wall")
        Me.cmb65_5.Items.Add("Bioremediation")
        Me.cmb65_5.Items.Add("Other")

        Me.cmb83_5.Items.Add(" ")
        Me.cmb83_5.Items.Add("North")
        Me.cmb83_5.Items.Add("North-east")
        Me.cmb83_5.Items.Add("East")
        Me.cmb83_5.Items.Add("South-east")
        Me.cmb83_5.Items.Add("South")
        Me.cmb83_5.Items.Add("South-west")
        Me.cmb83_5.Items.Add("West")
        Me.cmb83_5.Items.Add("North-west")

        Me.cmb115_5.Items.Add(" ")
        Me.cmb115_5.Items.Add("Water Wells")
        Me.cmb115_5.Items.Add("Mine Shafts")
        Me.cmb115_5.Items.Add("Foundations")
        Me.cmb115_5.Items.Add("Geological Features")
        Me.cmb115_5.Items.Add("Other")

    End Sub

    Private Sub btn_Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Load.Click

        Me.txtComments.Clear()

        Comment1 = " "
        Comment2 = " "
        Comment3 = " "
        Comment4 = " "
        Comment5 = " "
        Comment6 = " "
        Comment7 = " "
        Comment8 = " "
        Comment9 = " "
        Comment10 = " "
        Comment11 = " "
        Comment12 = " "

        'Delete the values from the controls on the TAB Assessment and disable all controls
        Me.gpbPathways.Enabled = False
        Me.gpbTargets.Enabled = False
        Me.gpbPrioritise.Enabled = False
        Me.gpbHazard.Enabled = False
        Me.gpbPollutantLinkages.Enabled = False
        Me.gpbDataCheck.Enabled = False
        Me.txt_CheckBoundaries.Text = " "
        Me.txt_CheckBoreholes.Text = " "
        Me.txt_CheckSurfaceDeposits.Text = " "
        Me.txt_CheckTanks.Text = " "
        Me.txt_CheckReferences.Text = " "
        Me.txtPathwayAssessment.Text = " "
        Me.txtDrainsPipesAssessment.Text = " "
        Me.txtLateralFlowAssessment.Text = " "
        Me.txtVerticalFlowAssessment.Text = " "
        Me.txtAirborneAssessment.Text = " "
        Me.txtSurfaceWaterRank.Text = " "
        Me.txtGroundwaterRank.Text = " "
        Me.txtEnvironmentRank.Text = " "
        Me.txtOnsiteHumans_Assessment.Text = " "
        Me.txtOffSiteHumansAssessment.Text = " "
        Me.txtHazardTanks.Text = " "
        Me.txt_HPTScore3.Text = " "
        Me.txt_HPTScore4.Text = " "
        Me.txtWeighting_HPT_Score3.Text = " "
        Me.txtWeighting_HPT_Score4.Text = " "
        Me.txtWeightingDSValue.Text = " "
        Me.txtDSPriority.Text = " "
        Me.txtSiteStatusPrioritisation.Text = " "

        'The data grid for references is emptied
        ds.Clear()
        DataGridReferences_6.DataSource = Nothing
        DataGridReferences_6.Rows.Clear()


        'Show the window for opening a database - THIS IS A LIVE CONNECTION THAT CHANGES LOADING A NEW FILE
        OpenFileDialog1.ShowDialog()
        nomefile = OpenFileDialog1.FileName

        If nomefile = "" Then
            MsgBox("Data loading cancelled...", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Dim lunghezza As Integer
        lunghezza = nomefile.Length
        Dim nometemplate As String
        nometemplate = Mid(nomefile, lunghezza - 14, 15)

        If nometemplate = "NG Database.ngd" Then
            Dim risposta As String
            risposta = MsgBox("NG Database is an empty database template.Before you can start entering" & Chr(13) & " the data you must save it with a different name now! (e.g. SiteName.ngd)", MsgBoxStyle.OkCancel, "Start a new database")
            If risposta = 1 Then
                If copiaNG() = 2 Then
                    Exit Sub
                Else
                    abuonfine()
                End If
            ElseIf risposta = 2 Then
                Exit Sub
            End If
        Else
            'The file is valid and can be loaded so call the rountine for open it
            abuonfine()
        End If
    End Sub
    Private Sub abuonfine()

        ToolStripStatusLabel2.Text = "Now using file " & nomefile

        Connect()
        checkTabellaSiteInformation()
        checkTabellaSurfaceDetails()
        checkTabellaSubSurface_Conditions()
        checkTabellaYour_Details()
        checkTabellaCommenti()
        checkTabellaGroundWater_Abstraction()
        checkTabellaSurfaceWater_Environment()
        checkTabellaContaminationPathways()
        checkTabellaReference()
        LeggiValoreSiteStatus()

        'Recalculate the values of the  tab prioritisation
        txt_CheckSiteCode.Text = strCodiceSito

        'BUttons for showing boundaries, tanks, boreholes e surface deposits are activated
        Me.btnSurfaceDepositsShow.Enabled = True
        Me.btnTanksShow.Enabled = True
        Me.btnBoreholesShow.Enabled = True
        Me.btnBoundariesShow.Enabled = True
        Me.btn_CommitChanges.Enabled = True
        Me.btn_SaveAs.Enabled = True
        Me.btnRiskAssessment.Enabled = True


        'GLOBAL VARIABLES READY TO BE FILLED BY NEW VALUES
        TANKHAZ_SiteTankScore = Nothing
        PollutionEventRunOff = Nothing
        PollutionEventDrainsPipes = Nothing
        PollutionEventLateralFlows = Nothing
        PollutionEventScoreA = Nothing
        PollutionEventScoreB = Nothing
        PollutionEventAquifer = Nothing
        PollutionEventAirborne = Nothing
        HPT_Score3 = Nothing
        HPT_Score4 = Nothing
        DSPriority = Nothing

    End Sub

    'Open the template database and save it with another name
    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveAs.Click


        Dim FileToCopy As String
        Dim NewCopy As String

        FileToCopy = nomefile

        testFile = My.Computer.FileSystem.GetFileInfo(nomefile)
        folderPath = testFile.DirectoryName
        fileName = testFile.Name


        Dim saveFileDialog1 As New SaveFileDialog()
        Dim risposta As Integer

        saveFileDialog1.Filter = "National Grid Database Format (*.ngd)|*.ngd"
        risposta = saveFileDialog1.ShowDialog()


        Dim Nuovo As String
        Nuovo = saveFileDialog1.FileName

        If Nuovo = "" Then
            MessageBox.Show("File not saved!", "No file name provided", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim estensione As String = Microsoft.VisualBasic.Right(Nuovo, 3)
        If estensione = "ngd" Then
            NewCopy = Nuovo
        Else
            NewCopy = Nuovo & ".ngd"
        End If

        If System.IO.File.Exists(FileToCopy) = True Then
            Try
                System.IO.File.Copy(FileToCopy, NewCopy)
                MsgBox("File Copied")
            Catch
                System.IO.File.Delete(NewCopy)
                System.IO.File.Copy(FileToCopy, NewCopy)
                MsgBox("File Copied")
            End Try
        End If


    End Sub

    'Copy the curent database and save it with another name
    Private Function copiaNG()

        Dim FileToCopy As String
        Dim NewCopy As String

        FileToCopy = nomefile

        testFile = My.Computer.FileSystem.GetFileInfo(nomefile)
        folderPath = testFile.DirectoryName
        fileName = testFile.Name


        Dim saveFileDialog1 As New SaveFileDialog()
        Dim risposta As Integer

        saveFileDialog1.Filter = "National Grid Database Format (*.ngd)|*.ngd"
        risposta = saveFileDialog1.ShowDialog()

        If risposta = 2 Then
            copiaNG = risposta
            Exit Function
        End If

        Dim Nuovo As String
        Nuovo = saveFileDialog1.FileName

        If Nuovo = "" Then
            MessageBox.Show("File not saved!", "No file name provided", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Exclamation)
            copiaNG = Nothing
            Exit Function
        End If

        Dim estensione As String = Microsoft.VisualBasic.Right(Nuovo, 3)
        If estensione = "ngd" Then
            NewCopy = Nuovo
        Else
            NewCopy = Nuovo & ".ngd"
        End If

        If System.IO.File.Exists(FileToCopy) = True Then
            Try
                System.IO.File.Copy(FileToCopy, NewCopy)
                MsgBox("New database created and ready")
            Catch
                System.IO.File.Delete(NewCopy)
                System.IO.File.Copy(FileToCopy, NewCopy)
                MsgBox("New database created and ready")
            End Try
        End If

        nomefile = Nuovo

    End Function

    'Open and Close of the current database - This is a dynamic link
    Sub Connect()

        'Opening Database
        testoConnessione = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";" & _
                       "User ID=Admin;Data Source= " & nomefile & ";Mode=Sha" & _
                       "re Deny None;Extended Properties="""";" & _
                       "Jet OLEDB:System database="""";Jet OLEDB:Regis" & _
                       "try Path="""";Jet OLEDB:Database Password="""";" & _
                       "Jet OLEDB:Engine Type=5;Jet OLEDB:Dat" & _
                       "abase Locking Mode=1;Jet OLEDB:Global Partial " & _
                       "Bulk Ops=2;Jet OLEDB:Global Bulk T" & _
                       "ransactions=1;Jet OLEDB:New Database " & _
                       "Password="""";Jet OLEDB:Create System Databas" & _
                       "e=False;Jet OLEDB:Encrypt Database=False;" & _
                       "Jet OLEDB:Don't Copy Locale on Compact=" & _
                       "False;Jet OLEDB:Compact Without Replica " & _
                       "Repair=False;Jet OLEDB:SFP=False"

        'Connection for each table of the database
        If contatore > 0 Then
            Disconnect()
            con.ConnectionString = testoConnessione
            contatore = contatore + 1
            Site_Information = "Site_Information" & contatore
            Surface_Details = "Surface_Details" & contatore
            SubSurface_Conditions = "SubSurface_Conditions" & contatore
            GroundWater_Abstraction = "GroundWater_Abstraction" & contatore
            SurfaceWater_Environment = "SurfaceWater_Environment" & contatore
            Contamination_Pathway = "Contamination_Pathway" & contatore
            SiteStatus = "SiteStatus" & contatore
            Refer = "References" & contatore
            Tabella_Commenti = "Tabella_Commenti" & contatore
            Your_Details = "Your_Details" & contatore
        Else
            con.ConnectionString = testoConnessione
            contatore = contatore + 1
            Site_Information = "Site_Information" & contatore
            Surface_Details = "Surface_Details" & contatore
            SubSurface_Conditions = "SubSurface_Conditions" & contatore
            GroundWater_Abstraction = "GroundWater_Abstraction" & contatore
            SurfaceWater_Environment = "SurfaceWater_Environment" & contatore
            Contamination_Pathway = "Contamination_Pathway" & contatore
            SiteStatus = "SiteStatus" & contatore
            Refer = "References" & contatore
            Tabella_Commenti = "Tabella_Commenti" & contatore
            Your_Details = "Your_Details" & contatore
        End If

        Try
            con.Open()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Sub Disconnect()
        'Disconnect the current database
        Try
            con.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    'Closing the form procedure for saving data
    Private Sub btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exit.Click


        Dim rispostaUscitaMaster As Integer
        rispostaUscitaMaster = MsgBox("Do you want backup the master database?", MsgBoxStyle.YesNo, "Backup Master Database!")
        If rispostaUscitaMaster = 6 Then
            Dim FileToCopy As String
            Dim NewCopy As String

            FileToCopy = "C:\Program Files\SPM_Calc\EM_ModelSiteList.mdb"

            testFile = My.Computer.FileSystem.GetFileInfo(FileToCopy)
            folderPath = testFile.DirectoryName
            fileName = testFile.Name

            Dim saveFileDialog1 As New SaveFileDialog()
            Dim risposta As Integer

            saveFileDialog1.Filter = "Master Database Format (*.mdb)|*.mdb"
            risposta = saveFileDialog1.ShowDialog()

            Dim Nuovo As String
            Nuovo = saveFileDialog1.FileName

            If Nuovo = "" Then
                MessageBox.Show("File not saved!", "No file name provided", _
                                            MessageBoxButtons.OK, _
                                            MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim estensione As String = Microsoft.VisualBasic.Right(Nuovo, 3)
            If estensione = "mdb" Then
                NewCopy = Nuovo
            Else
                NewCopy = Nuovo & ".mdb"
            End If

            If System.IO.File.Exists(FileToCopy) = True Then
                Try
                    System.IO.File.Copy(FileToCopy, NewCopy)
                    MsgBox("File Copied")
                Catch
                    System.IO.File.Delete(NewCopy)
                    System.IO.File.Copy(FileToCopy, NewCopy)
                    MsgBox("File Copied")
                End Try
            End If
        ElseIf rispostaUscitaMaster = 7 Then
            Me.Close()
            Exit Sub
        End If


    End Sub

    'Update Site Code on every TAB
    Sub aggiornaSiteCode()
        Me.txtSiteCode_1.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_2.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_3.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_4.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_5.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_6.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_7.Text = Me.txtSiteCode.Text
        Me.txtSiteCode_8.Text = Me.txtSiteCode.Text
    End Sub
   
    Private Sub txtSiteCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSiteCode.LostFocus
        aggiornaSiteCode()
    End Sub

    'Tooltip message for the SITE Code
    Private Sub txtSiteCode_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSiteCode.MouseHover

        ToolTipSiteCode.SetToolTip(txtSiteCode, "The site code is a mandatory information and can be " & Chr(13) & "found in the list of properties managed by National Grid")
        ToolTipSiteCode.SetToolTip(txtSiteCode_1, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_2, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_3, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_4, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_5, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_6, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_7, "Change this value in the first tab 'Site Information'")
        ToolTipSiteCode.SetToolTip(txtSiteCode_8, "Change this value in the first tab 'Site Information'")

    End Sub

    'Selection of the appropriate update procedure according with the active TAB
    Private Sub btn_CommitChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CommitChanges.Click

        Dim nomeTabAttivo As String

        nomeTabAttivo = AllTabs.SelectedTab.Name

        Select Case nomeTabAttivo
            'tab 0
            Case "TabSiteInformation"
                UpdateTabellaSiteInformation()
                'tab 1
            Case "tabSurfaceDetails"
                ControllaSommeTextBoxes()
                If ControllaSommeTextBoxes() > 100 Then
                    MsgBox("The sum of surfaces is more than 100%. Changes cannot be committed", MsgBoxStyle.Critical, "Error")
                    Ristabilisci_Valori_Superfici()
                    Exit Sub
                End If
                ControllaPermImperm()
                If ControllaPermImperm() > 100 Then
                    MsgBox("The sum of permeable and impermeable surfaces is more than 100%. Changes cannot be committed", MsgBoxStyle.Critical, "Error")
                    Ristabilisci_Valori_PermImperm()
                    Exit Sub
                End If
                UpdateTabellaSurfaceDetails()
                'tab 2
            Case "TabSubSurfaceConditions"
                UpdateTabellaSubSurfaceConditions()
                'tab 3
            Case "TabGroundwaterAbstraction"
                UpdateTabellaGroundWater_Abstraction()
                'tab 4
            Case "TabSurfaceWaterEnvironment"
                If (txtSensitiveEnvironmentalTargetsDistance1_4.Text = " .") Or (txtSensitiveEnvironmentalTargetsDistance2_4.Text = " .") Or (txtSensitiveEnvironmentalTargetsDistance3_4.Text = " .") Then
                    MsgBox("Sorry, only digits (0-9) are allowed in distances, no spaces no characters", MsgBoxStyle.OkOnly, "Error")
                    Exit Sub
                Else
                    UpdateTabellaSurfaceWater_Environment()
                End If
                'UpdateTabellaSurfaceWater_Environment()
                'tab 5
            Case "TabContaminationPathways"
                UpdateTabellaContaminationPathways()
                'tab 6
            Case "TabReferences"
                UpdateTabellaReferencesSiteStatus()
                'tab 7
            Case "TabComments"
                UpdateTabellaComments()
                'tab 8
            Case "TabYourDetails"
                UpdateTabellaYourDetails()
                'tab 9
        End Select

    End Sub

    'ActivatePanels
    Private Sub rdbSurfaceDetailsNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSurfaceDetailsNo_1.Click
        Me.gpbPercentages.Enabled = False
        Me.gpbPermeableImpermeableMaterial.Enabled = False
        Me.gpbFloodingHistory.Enabled = False
        'Me.gpbNatureOfMaterial.Enabled = False
        Me.gpbStandingWaterHistory.Enabled = False
        Me.gpdCoveredOtherMaterial.Enabled = False
    End Sub
    Private Sub rdbSurfaceDetailsYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSurfaceDetailsYes_1.Click
        Me.gpbPercentages.Enabled = True
        Me.gpbPermeableImpermeableMaterial.Enabled = True
        Me.gpbFloodingHistory.Enabled = True
        Me.gpbStandingWaterHistory.Enabled = True
        Me.gpdCoveredOtherMaterial.Enabled = True
    End Sub
    Private Sub rdbMadeGroundYes_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbMadeGroundYes_2.Click
        Me.gpbMadeGroundContinuous.Enabled = True
    End Sub
    Private Sub rdbMadeGroundNK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbMadeGroundNK_2.Click
        Me.gpbMadeGroundContinuous.Enabled = False
    End Sub
    Private Sub rdbMadeGroundNO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbMadeGroundNO_2.Click
        Me.gpbMadeGroundContinuous.Enabled = False
    End Sub
    Private Sub rdbSuperficialDepositYes_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSuperficialDepositYes_2.Click
        Me.gpbTypeOfDeposit.Enabled = True
    End Sub
    Private Sub rdbSuperficialDepositNO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSuperficialDepositNO_2.Click
        Me.gpbTypeOfDeposit.Enabled = False
    End Sub
    Private Sub rdbSuperficialDepositNK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSuperficialDepositNK_2.Click
        Me.gpbTypeOfDeposit.Enabled = False
    End Sub
    Private Sub chkWater_2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWater_2.CheckedChanged
        If chkWater_2.Checked Then
            Me.txtWaterCrossing_2.Enabled = True
        Else
            Me.txtWaterCrossing_2.Enabled = False
        End If
    End Sub
    Private Sub rdbUnderlyingAquiferYES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbUnderlyingAquiferYES_3.Click
        Me.gpbUnderlyingAquiferSourceContamination.Enabled = True
    End Sub
    Private Sub rdbUnderlyingAquiferNK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbUnderlyingAquiferNK_3.Click
        Me.gpbUnderlyingAquiferSourceContamination.Enabled = False
    End Sub
    Private Sub rdbUnderlyingAquiferNO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbUnderlyingAquiferNO_3.Click
        Me.gpbUnderlyingAquiferSourceContamination.Enabled = False
    End Sub
    Private Sub chkWaterBodies_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWaterBodies_4.CheckStateChanged
        If chkWaterBodies_4.Checked = False Then
            Me.gpbWaterBodies.Enabled = True
        ElseIf chkWaterBodies_4.Checked = True Then
            Me.gpbWaterBodies.Enabled = False
        End If
    End Sub
    Private Sub chkSensitiveEnvironmentalTargets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSensitiveEnvironmentalTargets_4.CheckedChanged
        If Me.chkSensitiveEnvironmentalTargets_4.Checked = False Then
            Me.gpbSensitiveEnvironmentalTargets.Enabled = True
        ElseIf Me.chkSensitiveEnvironmentalTargets_4.Checked = True Then
            Me.gpbSensitiveEnvironmentalTargets.Enabled = False
        End If
    End Sub
    Private Sub rdbSurfaceWaterUseYES_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSurfaceWaterUseYES_4.Click
        Me.gpbSurfaceWaterUseNearest.Enabled = True
    End Sub
    Private Sub rdbSurfaceWaterUseNO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSurfaceWaterUseNO_4.Click
        Me.gpbSurfaceWaterUseNearest.Enabled = False
    End Sub
    Private Sub rdbSurfaceWaterUseNK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSurfaceWaterUseNK_4.Click
        Me.gpbSurfaceWaterUseNearest.Enabled = False
    End Sub
    Private Sub chkGas_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGas_2.CheckedChanged

        If chkGas_2.Checked Then
            Me.txtGasCrossing_2.Enabled = True
        Else
            Me.txtGasCrossing_2.Enabled = False
        End If
    End Sub
    Private Sub chkElectricity_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkElectricity_2.CheckedChanged
        If chkElectricity_2.Checked Then
            Me.txtElectricityCrossing_2.Enabled = True
        Else
            Me.txtElectricityCrossing_2.Enabled = False
        End If
    End Sub
    Private Sub chkTelecom_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTelecom_2.CheckedChanged
        If chkTelecom_2.Checked = True Then
            Me.txtTelecomCrossing_2.Enabled = True
        Else
            Me.txtTelecomCrossing_2.Enabled = False
        End If
    End Sub
    Private Sub chkSewers_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSewers_2.CheckedChanged
        If chkSewers_2.Checked = True Then
            Me.txtSewerCrossing_2.Enabled = True
        Else
            Me.txtSewerCrossing_2.Enabled = False
        End If
    End Sub
    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged

        'Dim OneCharacter As Char
        Dim Testo As String
        Dim lunghezzaTesto As Integer

        Testo = Trim(txtComments.Text)
        lunghezzaTesto = Testo.Length

        Label103.Text = ("Number of characters is: " & lunghezzaTesto)

    End Sub

    'Check on data entry
    Private Sub txtSensitiveEnvironmentalTargetsDistance1_4_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtSensitiveEnvironmentalTargetsDistance1_4.MaskInputRejected
        ToolTipDistance.ToolTipTitle = "Invalid Input"
        ToolTipDistance.Show("Sorry, only digits (0-9) are allowed in distances", txtSensitiveEnvironmentalTargetsDistance1_4, 5000)
    End Sub
    Private Sub txtSensitiveEnvironmentalTargetsDistance2_4_MaskInputRejected(ByVal sender As Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtSensitiveEnvironmentalTargetsDistance2_4.MaskInputRejected
        ToolTipDistance.ToolTipTitle = "Invalid Input"
        ToolTipDistance.Show("Sorry, only digits (0-9) are allowed in distances", txtSensitiveEnvironmentalTargetsDistance1_4, 5000)
    End Sub
    Private Sub txtSensitiveEnvironmentalTargetsDistance3_4_MaskInputRejected(ByVal sender As Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtSensitiveEnvironmentalTargetsDistance3_4.MaskInputRejected
        ToolTipDistance.ToolTipTitle = "Invalid Input"
        ToolTipDistance.Show("Sorry, only digits (0-9) are allowed in distances", txtSensitiveEnvironmentalTargetsDistance1_4, 5000)
    End Sub
    Private Function ControllaSommeTextBoxes()

        Dim sommasuperfici As Integer
        sommasuperfici = Val(Me.txtBuildingStructure_1.Text) + Val(Me.txtHardstanding_1.Text) + Val(Me.txtExposedSoil_1.Text) + Val(Me.txtVegetationScrub_1.Text) + Val(Me.txtGravelLoose_1.Text) + Val(Me.txtCoveredOtherMaterial_1.Text)
        ControllaSommeTextBoxes = sommasuperfici

    End Function
    Private Sub Ristabilisci_Valori_Superfici()

        'intCovBuildStruct = ds.Tables(Surface_Details).Rows(0).Item(2)
        Me.txtBuildingStructure_1.Text = intCovBuildStruct
        'intCovHardstand = ds.Tables(Surface_Details).Rows(0).Item(3)
        Me.txtHardstanding_1.Text = intCovHardstand '4
        'intCovExpSoil = ds.Tables(Surface_Details).Rows(0).Item(4)
        Me.txtExposedSoil_1.Text = intCovExpSoil '5
        'intCovVeg = ds.Tables(Surface_Details).Rows(0).Item(5)
        Me.txtVegetationScrub_1.Text = intCovVeg '6   
        'intCovGravel = ds.Tables(Surface_Details).Rows(0).Item(6)
        Me.txtGravelLoose_1.Text = intCovGravel '7
        'intCovOther = ds.Tables(Surface_Details).Rows(0).Item(9)
        Me.txtCoveredOtherMaterial_1.Text = intCovOther '8
    End Sub
    Private Function ControllaPermImperm()

        Dim sommaPermImperm As Integer
        sommaPermImperm = Val(Me.txtPermeableMaterial_1.Text) + Val(Me.txtImpermeableMaterial_1.Text)
        ControllaPermImperm = sommaPermImperm

    End Function
    Private Sub Ristabilisci_Valori_PermImperm()
        'intCovPerm = ds.Tables(Surface_Details).Rows(0).Item(7)
        Me.txtPermeableMaterial_1.Text = intCovPerm '9
        'intCovImperm = ds.Tables(Surface_Details).Rows(0).Item(8)
        Me.txtImpermeableMaterial_1.Text = intCovImperm '10
    End Sub
    Private Sub txtCoveredOtherMaterial_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoveredOtherMaterial_1.TextChanged
        If txtCoveredOtherMaterial_1.Text <> "0" Then
            rdbPermeable_1.Enabled = True
            rdbImpermeable_1.Enabled = True
        Else
            rdbPermeable_1.Enabled = False
            rdbImpermeable_1.Enabled = False
        End If
    End Sub
    Private Sub chkNoInformation_2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNoInformation_2.Click
        If chkNoInformation_2.Checked = True Then
            Me.chkGas_2.Enabled = False
            Me.chkElectricity_2.Enabled = False
            Me.chkWater_2.Enabled = False
            Me.chkTelecom_2.Enabled = False
            Me.chkSewers_2.Enabled = False
        Else
            Me.chkGas_2.Enabled = True
            Me.chkElectricity_2.Enabled = True
            Me.chkWater_2.Enabled = True
            Me.chkTelecom_2.Enabled = True
            Me.chkSewers_2.Enabled = True
        End If
    End Sub
    Private Sub chkNoGasworksUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoGasworksUsers.CheckedChanged
        If Me.chkNoGasworksUsers.Checked = True Then
            Me.chkCoalGasification.Enabled = False
            Me.chkCoalCarbonisationOnly.Enabled = False
            Me.chkGasPurificationOnly.Enabled = False
            Me.chkOilReformingPlant.Enabled = False
            Me.chkCWGPlant.Enabled = False
            Me.chkGasStorage.Enabled = False
        Else
            Me.chkCoalGasification.Enabled = True
            Me.chkCoalCarbonisationOnly.Enabled = True
            Me.chkGasPurificationOnly.Enabled = True
            Me.chkOilReformingPlant.Enabled = True
            Me.chkCWGPlant.Enabled = True
            Me.chkGasStorage.Enabled = True
        End If

    End Sub
    Private Sub chk63_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk63_5.CheckedChanged
        If chk63_5.Checked = True Then
            cmb83_5.Enabled = True
        ElseIf chk63_5.Checked = False Then
            cmb83_5.Enabled = False
        End If
    End Sub

    'Automatic Update leaving each TAB
    Private Sub TabSiteInformation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabSiteInformation.Leave
        If nomefile <> "" Then
            UpdateTabellaSiteInformation()
        End If
    End Sub
    Private Sub tabSurfaceDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabSurfaceDetails.Leave
        If nomefile <> "" Then
            UpdateTabellaSurfaceDetails()
        End If
    End Sub
    Private Sub TabSubSurfaceConditions_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabSubSurfaceConditions.Leave
        If nomefile <> "" Then
            UpdateTabellaSubSurfaceConditions()
        End If
    End Sub
    Private Sub TabGroundwaterAbstraction_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabGroundwaterAbstraction.Leave
        If nomefile <> "" Then
            UpdateTabellaGroundWater_Abstraction()
        End If
    End Sub
    Private Sub TabSurfaceWaterEnvironment_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabSurfaceWaterEnvironment.Leave
        If nomefile <> "" Then
            UpdateTabellaSurfaceWater_Environment()
        End If
    End Sub
    Private Sub TabContaminationPathways_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContaminationPathways.Leave
        If nomefile <> "" Then
            UpdateTabellaContaminationPathways()
        End If
    End Sub
    Private Sub TabReferences_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabReferences.Leave
        If nomefile <> "" Then
            UpdateTabellaReferencesSiteStatus()
        End If
    End Sub
    Private Sub TabComments_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabComments.Leave
        If nomefile <> "" Then
            UpdateTabellaComments()
        End If
    End Sub
    Private Sub TabYourDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabYourDetails.Leave
        If nomefile <> "" Then
            UpdateTabellaYourDetails()
        End If
    End Sub

    'Tab 1
    Sub checkTabellaSiteInformation()

        'First Datadapter filled
        Try
            sql = "SELECT * FROM tSiteInformation"
            daSiteInformation = New OleDb.OleDbDataAdapter(sql, con)
            daSiteInformation.Fill(ds, Site_Information)
        Catch
            MsgBox("Table 'Site Information ' not found")
            Exit Sub
        End Try

        'check field names for SiteInformation
        Dim strNomiCampi As New Collection
        strNomiCampi.Add("Operational")
        strNomiCampi.Add("SiteCode")
        strNomiCampi.Add("SiteName")
        strNomiCampi.Add("Address1")
        strNomiCampi.Add("Address2")
        strNomiCampi.Add("Town")
        strNomiCampi.Add("County")
        strNomiCampi.Add("Postcode")
        strNomiCampi.Add("LocalAuthority")
        strNomiCampi.Add("NGSquare")
        strNomiCampi.Add("Easting")
        strNomiCampi.Add("Northing")
        strNomiCampi.Add("SiteSize")
        strNomiCampi.Add("NoPartsSite")
        strNomiCampi.Add("SiteGradient")
        strNomiCampi.Add("SlopeDirection")
        strNomiCampi.Add("AnnualRainfall")
        strNomiCampi.Add("SiteOccupation")
        strNomiCampi.Add("CoalGasification")
        strNomiCampi.Add("CoalCarbonisation")
        strNomiCampi.Add("GasPurification")
        strNomiCampi.Add("OilReforming")
        strNomiCampi.Add("CWGPlant")
        strNomiCampi.Add("GasStorage")
        strNomiCampi.Add("NoGasworksUses")
        strNomiCampi.Add("SiteUse1")
        strNomiCampi.Add("SiteUse2")
        strNomiCampi.Add("SiteUse3")
        strNomiCampi.Add("FileLoc")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampi.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Site_Information).Columns(intK - 1).ColumnName = strNomiCampi(intK) Then
                End If
            Next
        Catch
            MsgBox("Campo " & intK & " - " & strNomiCampi.Item(intK) & " non trovato")
            Exit Sub
        End Try

        'In order to avoid an error for DBNULL is necessary to fill the variables with 0/space
        LeggiValoriTabellaSiteInformation()
        ScriviValoriTabSiteInformation()


    End Sub
    Public Sub LeggiValoriTabellaSiteInformation()

        Try
            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(0)) Then
                strCodiceSito = " "
            Else
                strCodiceSito = ds.Tables(Site_Information).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(1)) Then
                dblOperational = False
            Else
                dblOperational = ds.Tables(Site_Information).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(2)) Then
                strNomeSito = " "
            Else
                strNomeSito = ds.Tables(Site_Information).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(3)) Then
                strAddress1 = " "
            Else
                strAddress1 = ds.Tables(Site_Information).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(4)) Then
                strAddress2 = " "
            Else
                strAddress2 = ds.Tables(Site_Information).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(5)) Then
                strTown = " "
            Else
                strTown = ds.Tables(Site_Information).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(6)) Then
                strCounty = " "
            Else
                strCounty = ds.Tables(Site_Information).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(7)) Then
                strPostCode = " "
            Else
                strPostCode = ds.Tables(Site_Information).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(8)) Then
                strLocalAuthority = " "
            Else
                strLocalAuthority = ds.Tables(Site_Information).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(9)) Then
                strNG_Square = " "
            Else
                strNG_Square = ds.Tables(Site_Information).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(10)) Then
                intEasting = 0
            Else
                intEasting = ds.Tables(Site_Information).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(11)) Then
                intNorthing = "0"
            Else
                intNorthing = ds.Tables(Site_Information).Rows(0).Item(11)
            End If


            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(12)) Then
                dblSiteSize = "0"
            Else
                dblSiteSize = ds.Tables(Site_Information).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(13)) Then
                intNoPartsSite = "0"
            Else
                intNoPartsSite = ds.Tables(Site_Information).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(14)) Then
                strSiteGradient = " "
            Else
                strSiteGradient = ds.Tables(Site_Information).Rows(0).Item(14)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(15)) Then
                strDirectionSlope = " "
            Else
                strDirectionSlope = ds.Tables(Site_Information).Rows(0).Item(15)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(16)) Then
                intAnnualRainfall = "0"
            Else
                intAnnualRainfall = ds.Tables(Site_Information).Rows(0).Item(16)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(17)) Then
                strSiteOccupation = " "
            Else
                strSiteOccupation = ds.Tables(Site_Information).Rows(0).Item(17)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(18)) Then
                blnCoalGasification = False
            Else
                blnCoalGasification = ds.Tables(Site_Information).Rows(0).Item(18)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(19)) Then
                blnCoalCarbonisation = False
            Else
                blnCoalCarbonisation = ds.Tables(Site_Information).Rows(0).Item(19)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(20)) Then
                blnGasPurification = False
            Else
                blnGasPurification = ds.Tables(Site_Information).Rows(0).Item(20)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(21)) Then
                blnOilReforming = False
            Else
                blnOilReforming = ds.Tables(Site_Information).Rows(0).Item(21)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(22)) Then
                blnCWGPlant = False
            Else
                blnCWGPlant = ds.Tables(Site_Information).Rows(0).Item(22)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(23)) Then
                blnGasStorage = False
            Else
                blnGasStorage = ds.Tables(Site_Information).Rows(0).Item(23)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(24)) Then
                blnNoGasworksUses = False
            Else
                blnNoGasworksUses = ds.Tables(Site_Information).Rows(0).Item(24)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(25)) Then
                strSiteUse1 = " "
            Else
                strSiteUse1 = ds.Tables(Site_Information).Rows(0).Item(25)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(26)) Then
                strSiteUse2 = " "
            Else
                strSiteUse2 = ds.Tables(Site_Information).Rows(0).Item(26)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(27)) Then
                strSiteUse3 = " "
            Else
                strSiteUse3 = ds.Tables(Site_Information).Rows(0).Item(27)
            End If

            If IsDBNull(ds.Tables(Site_Information).Rows(0).Item(28)) Then
                strFileLoc = nomefile.ToString
            Else
                strFileLoc = ds.Tables(Site_Information).Rows(0).Item(28)
            End If

        Catch
            dblOperational = False
            strCodiceSito = " "
            strNomeSito = " "
            strAddress1 = " "
            strAddress2 = " "
            strTown = " "
            strCounty = " "
            strPostCode = " "
            strLocalAuthority = " "
            strNG_Square = " "
            intEasting = 0
            intNorthing = 0
            dblSiteSize = 0.0
            intNoPartsSite = 0
            strSiteGradient = " "
            strDirectionSlope = " "
            intAnnualRainfall = 0
            strSiteOccupation = " "
            blnCoalGasification = False
            blnCoalCarbonisation = False
            blnGasPurification = False
            blnOilReforming = False
            blnCWGPlant = False
            blnGasStorage = False
            blnNoGasworksUses = False
            strSiteUse1 = " "
            strSiteUse2 = " "
            strSiteUse3 = " "
            strFileLoc = nomefile.ToString
        End Try


    End Sub
    Sub ScriviValoriTabSiteInformation()

        aggiornaSiteCode()

        'Write the values gathered from the database into the right control on tab Site Information
        Me.chkOperational.Checked = dblOperational
        Me.txtSiteName.Text = strNomeSito
        Me.txtAddress1.Text = strAddress1
        Me.txtAddress2.Text = strAddress2
        Me.txtTown.Text = strTown
        Me.txtCounty.Text = strCounty
        Me.txtPostcode.Text = strPostCode
        Me.txtLocalAuthority.Text = strLocalAuthority
        Me.txtNGsquare.Text = strNG_Square
        Me.txtEasting.Text = intEasting
        Me.txtNorthing.Text = intNorthing
        Me.txtSiteSize.Text = dblSiteSize
        Me.nudNPartSize.Value = intNoPartsSite
        Me.cmbSiteGradient.Text = strSiteGradient
        Me.cmbDirectionSlope.Text = strDirectionSlope
        Me.txtAnnualRainfall.Text = intAnnualRainfall
        Me.cmbSiteOccupation.Text = strSiteOccupation
        Me.chkCoalGasification.Checked = blnCoalGasification
        Me.chkCoalCarbonisationOnly.Checked = blnCoalCarbonisation
        Me.chkGasPurificationOnly.Checked = blnGasPurification
        Me.chkOilReformingPlant.Checked = blnOilReforming
        Me.chkCWGPlant.Checked = blnCWGPlant
        Me.chkGasStorage.Checked = blnGasStorage
        Me.chkNoGasworksUsers.Checked = blnNoGasworksUses
        Me.txtSiteUse1.Text = strSiteUse1
        Me.txtSiteUse2.Text = strSiteUse2
        Me.txtSiteUse3.Text = strSiteUse3

    End Sub
    Sub UpdateTabellaSiteInformation()
        Dim ComandoUpdateDB As System.Data.OleDb.OleDbCommand
        ComandoUpdateDB = New System.Data.OleDb.OleDbCommand

        ' SQL string for updating the table
        ComandoUpdateDB.CommandText = "UPDATE tSiteInformation SET Operational=" & Me.chkOperational.Checked & "," & _
                                                "SiteCode = " & " '" & Me.txtSiteCode.Text & "'" & "," & _
                                                "SiteName = " & " '" & Me.txtSiteName.Text & "'" & "," & _
                                                "Address1 = " & " '" & Me.txtAddress1.Text & "'" & "," & _
                                                "Address2 = " & " '" & Me.txtAddress2.Text & "'" & "," & _
                                                "Town = " & " '" & Me.txtTown.Text & "'" & "," & _
                                                "County = " & " '" & Me.txtCounty.Text & "'" & "," & _
                                                "Postcode = " & " '" & Me.txtPostcode.Text & "'" & "," & _
                                                "LocalAuthority = " & " '" & Me.txtLocalAuthority.Text & "'" & "," & _
                                                "NGSquare = " & " '" & Me.txtNGsquare.Text & "'" & "," & _
                                                "Easting = " & " '" & Me.txtEasting.Text & "'" & "," & _
                                                "Northing = " & " '" & Me.txtNorthing.Text & "'" & "," & _
                                                "SiteSize = " & " '" & Me.txtSiteSize.Text & "'" & "," & _
                                                "NoPartsSite = " & " '" & Me.nudNPartSize.Text & "'" & "," & _
                                                "SiteGradient = " & " '" & Me.cmbSiteGradient.Text & "'" & "," & _
                                                "SlopeDirection = " & " '" & Me.cmbDirectionSlope.Text & "'" & "," & _
                                                "AnnualRainfall = " & " '" & Me.txtAnnualRainfall.Text & "'" & "," & _
                                                "SiteOccupation = " & " '" & Me.cmbSiteOccupation.Text & "'" & "," & _
                                                "CoalGasification = " & Me.chkCoalGasification.Checked & "," & _
                                                "CoalCarbonisation = " & Me.chkCoalCarbonisationOnly.Checked & "," & _
                                                "GasPurification = " & Me.chkGasPurificationOnly.Checked & "," & _
                                                "OilReforming = " & Me.chkOilReformingPlant.Checked & "," & _
                                                "CWGPlant = " & Me.chkCWGPlant.Checked & "," & _
                                                "GasStorage = " & Me.chkGasStorage.Checked & "," & _
                                                "NoGasworksUses = " & Me.chkNoGasworksUsers.Checked & "," & _
                                                "SiteUse1 = " & " '" & Me.txtSiteUse1.Text & "'" & "," & _
                                                "SiteUse2 = " & " '" & Me.txtSiteUse2.Text & "'" & "," & _
                                                "SiteUse3 = " & " '" & Me.txtSiteUse2.Text & "'" & "," & _
                                                "FileLoc = " & " '" & strFileLoc & "'" & " ; "

        'Opening the connection for update
        ComandoUpdateDB.Connection = con
        Try
            daSiteInformation.UpdateCommand = ComandoUpdateDB
            daSiteInformation.UpdateCommand.ExecuteNonQuery()
        Catch

            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try
    End Sub
    '**************************************************************************************
    '**************************************************************************************
    '*******SAME 4 ROUNTINES FRO ALL THE TABS OF THE MAIN WINDOW
    '**************************************************************************************
    '**************************************************************************************

    'Tab 2
    Sub checkTabellaSurfaceDetails()

        Try
            sqlSD = "SELECT * FROM tSurfaceDetails"
            daSurfaceDetails = New OleDb.OleDbDataAdapter(sqlSD, con)
            daSurfaceDetails.Fill(ds, Surface_Details)
        Catch
            MsgBox("Table 'Surface Details' not found in the database", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Surface_Details).Columns.Count

        Dim MaxRows As Integer
        MaxRows = ds.Tables(Surface_Details).Rows.Count
        Dim strNomiCampiSD As New Collection
        strNomiCampiSD.Add("SurfDetInfoYes") '1
        strNomiCampiSD.Add("SurfDetInfoNo") '2
        strNomiCampiSD.Add("CovBuildStruct") '3
        strNomiCampiSD.Add("CovHardstand") '4
        strNomiCampiSD.Add("CovExpSoil") '5
        strNomiCampiSD.Add("CovVeg") '6
        strNomiCampiSD.Add("CovGravel") '7
        strNomiCampiSD.Add("CovPerm") '8
        strNomiCampiSD.Add("CovImperm") '9
        strNomiCampiSD.Add("CovOther") '10
        strNomiCampiSD.Add("OverallNatYes") '11
        strNomiCampiSD.Add("OverallNatNo") '12
        strNomiCampiSD.Add("FloodHistYes") '13
        strNomiCampiSD.Add("FloodHistNo") '14
        strNomiCampiSD.Add("StandHistYes") '15
        strNomiCampiSD.Add("StandHistNo") '16

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiSD.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Surface_Details).Columns(intK - 1).ColumnName = strNomiCampiSD(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiSD.Item(intK) & " not found")
            Exit Sub
        End Try
        LeggiValoriTabellaSurfaceDetails()
        ScriviValoriTabSurfaceDetails()

    End Sub
    Public Sub LeggiValoriTabellaSurfaceDetails()

        Try
            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(0)) Then
                blnSurfDetInfoYes = False
            Else
                blnSurfDetInfoYes = ds.Tables(Surface_Details).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(1)) Then
                blnSurfDetInfoNo = False
            Else
                blnSurfDetInfoNo = ds.Tables(Surface_Details).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(2)) Then
                intCovBuildStruct = 0
            Else
                intCovBuildStruct = ds.Tables(Surface_Details).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(3)) Then
                intCovHardstand = 0
            Else
                intCovHardstand = ds.Tables(Surface_Details).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(4)) Then
                intCovExpSoil = 0
            Else
                intCovExpSoil = ds.Tables(Surface_Details).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(5)) Then
                intCovVeg = 0
            Else
                intCovVeg = ds.Tables(Surface_Details).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(6)) Then
                intCovGravel = 0
            Else
                intCovGravel = ds.Tables(Surface_Details).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(7)) Then
                intCovPerm = 0
            Else
                intCovPerm = ds.Tables(Surface_Details).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(8)) Then
                intCovImperm = 0
            Else
                intCovImperm = ds.Tables(Surface_Details).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(9)) Then
                intCovOther = 0
            Else
                intCovOther = ds.Tables(Surface_Details).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(10)) Then
                blnOverallNatYes = False
            Else
                blnOverallNatYes = ds.Tables(Surface_Details).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(11)) Then
                blnOverallNatNo = False
            Else
                blnOverallNatNo = ds.Tables(Surface_Details).Rows(0).Item(11)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(12)) Then
                blnFloodHistYes = False
            Else
                blnFloodHistYes = ds.Tables(Surface_Details).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(13)) Then
                blnFloodHistNo = False
            Else
                blnFloodHistNo = ds.Tables(Surface_Details).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(14)) Then
                blnStandHistYes = False
            Else
                blnStandHistYes = ds.Tables(Surface_Details).Rows(0).Item(14)
            End If

            If IsDBNull(ds.Tables(Surface_Details).Rows(0).Item(15)) Then
                blnStandHistNo = False
            Else
                blnStandHistNo = ds.Tables(Surface_Details).Rows(0).Item(15)
            End If
        Catch
            blnSurfDetInfoYes = False
            blnSurfDetInfoNo = False
            intCovBuildStruct = 0
            intCovHardstand = 0
            intCovExpSoil = 0
            intCovVeg = 0
            intCovGravel = 0
            intCovPerm = 0
            intCovImperm = 0
            intCovOther = 0
            blnOverallNatYes = False
            blnOverallNatNo = False
            blnFloodHistYes = False
            blnFloodHistNo = False
            blnStandHistYes = False
            blnStandHistNo = False
        End Try
    End Sub
    Sub ScriviValoriTabSurfaceDetails()

        Me.txtSiteCode.Text = strCodiceSito
        aggiornaSiteCode()

        Me.rdbSurfaceDetailsYes_1.Checked = blnSurfDetInfoYes '1
        If blnSurfDetInfoYes = True Then
            gpbPercentages.Enabled = True
            gpdCoveredOtherMaterial.Enabled = True
            gpbFloodingHistory.Enabled = True
            gpbStandingWaterHistory.Enabled = True
            gpbPermeableImpermeableMaterial.Enabled = True
        End If
        Me.rdbSurfaceDetailsNo_1.Checked = blnSurfDetInfoNo '2
        Me.txtBuildingStructure_1.Text = intCovBuildStruct '3
        Me.txtHardstanding_1.Text = intCovHardstand '4
        Me.txtExposedSoil_1.Text = intCovExpSoil '5
        Me.txtVegetationScrub_1.Text = intCovVeg '6
        Me.txtGravelLoose_1.Text = intCovGravel '7
        Me.txtCoveredOtherMaterial_1.Text = intCovOther '8
        Me.txtPermeableMaterial_1.Text = intCovPerm '9
        Me.txtImpermeableMaterial_1.Text = intCovImperm '10
        Me.rdbPermeable_1.Checked = blnOverallNatYes '11 
        Me.rdbImpermeable_1.Checked = blnOverallNatNo '12
        Me.rdbFloodingYes_1.Checked = blnFloodHistYes '13
        Me.rdbFloodingNO_1.Checked = blnFloodHistNo '14
        Me.rdbStandingWaterYes_1.Checked = blnStandHistYes '15
        Me.rdbStandingWaterNO_1.Checked = blnStandHistNo '16

        If txtCoveredOtherMaterial_1.Text <> "0" Then
            rdbPermeable_1.Enabled = True
            rdbImpermeable_1.Enabled = True
        Else
            rdbPermeable_1.Enabled = False
            rdbImpermeable_1.Enabled = False
        End If

    End Sub
    Sub UpdateTabellaSurfaceDetails()

        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand


        ComandoUpdateDBSF.CommandText = "UPDATE tSurfaceDetails SET SurfDetInfoYes=" & Me.rdbSurfaceDetailsYes_1.Checked & "," & _
                                                "SurfDetInfoNo = " & Me.rdbSurfaceDetailsNo_1.Checked & "," & _
                                                "CovBuildStruct = " & " '" & Me.txtBuildingStructure_1.Text & "'" & "," & _
                                                "CovHardstand = " & " '" & Me.txtHardstanding_1.Text & "'" & "," & _
                                                "CovExpSoil = " & " '" & Me.txtExposedSoil_1.Text & "'" & "," & _
                                                "CovVeg = " & " '" & Me.txtVegetationScrub_1.Text & "'" & "," & _
                                                "CovGravel = " & " '" & Me.txtGravelLoose_1.Text & "'" & "," & _
                                                "CovPerm = " & " '" & Me.txtPermeableMaterial_1.Text & "'" & "," & _
                                                "CovImperm = " & " '" & Me.txtImpermeableMaterial_1.Text & "'" & "," & _
                                                "CovOther = " & " '" & Me.txtCoveredOtherMaterial_1.Text & "'" & "," & _
                                                "OverallNatYes = " & Me.rdbPermeable_1.Checked & "," & _
                                                "OverallNatNo = " & Me.rdbImpermeable_1.Checked & "," & _
                                                "FloodHistYes = " & Me.rdbFloodingYes_1.Checked & "," & _
                                                "FloodHistNo = " & Me.rdbFloodingNO_1.Checked & "," & _
                                                "StandHistYes = " & Me.rdbStandingWaterYes_1.Checked & "," & _
                                                "StandHistNo = " & Me.rdbStandingWaterNO_1.Checked & " ; "

        ComandoUpdateDBSF.Connection = con
        Try
            daSurfaceDetails.UpdateCommand = ComandoUpdateDBSF
            daSurfaceDetails.UpdateCommand.ExecuteNonQuery()
        Catch

            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    'Tab 3
    Sub checkTabellaSubSurface_Conditions()

        Try
            sqlSSC = "SELECT * FROM tSubSurface"
            daSubSurfaceConditions = New OleDb.OleDbDataAdapter(sqlSSC, con)
            daSubSurfaceConditions.Fill(ds, SubSurface_Conditions)
        Catch
            MsgBox("Table 'Sub-Surface Conditions' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(SubSurface_Conditions).Columns.Count

        Dim strNomiCampiSSC As New Collection
        strNomiCampiSSC.Add("MadeGroundPresent") '1 
        strNomiCampiSSC.Add("MadeGroundNotPresent") '2
        strNomiCampiSSC.Add("MadeGroundNKnown") '3
        strNomiCampiSSC.Add("MadeGroundCont") '4 
        strNomiCampiSSC.Add("MadeGroundContNo") '5 
        strNomiCampiSSC.Add("MadeGroundContNK") '6 
        strNomiCampiSSC.Add("MaxThickMG") '7 
        strNomiCampiSSC.Add("PerchedWT") '8
        strNomiCampiSSC.Add("SupDepPresent") '9
        strNomiCampiSSC.Add("SupDepPresentNo") '10
        strNomiCampiSSC.Add("SupDepPresentNK") '11
        strNomiCampiSSC.Add("SupDep") '12 
        strNomiCampiSSC.Add("SupDepCont") '13
        strNomiCampiSSC.Add("SupDepContNo") '14
        strNomiCampiSSC.Add("MaxThickSD") '15
        strNomiCampiSSC.Add("BedGeol") '16
        strNomiCampiSSC.Add("GasSer") '17
        strNomiCampiSSC.Add("GasBoundX") '18
        strNomiCampiSSC.Add("ElectricSer") '19
        strNomiCampiSSC.Add("ElectricBoundX") '20
        strNomiCampiSSC.Add("WaterSer") '21
        strNomiCampiSSC.Add("WaterBoundX") '22
        strNomiCampiSSC.Add("TelecomSer") '23
        strNomiCampiSSC.Add("TelecomBoundX") '24
        strNomiCampiSSC.Add("SewersSer") '25
        strNomiCampiSSC.Add("SewersBoundX") '26
        strNomiCampiSSC.Add("NoSer") '27

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiSSC.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(SubSurface_Conditions).Columns(intK - 1).ColumnName = strNomiCampiSSC(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiSSC.Item(intK) & " not found")
            Exit Sub
        End Try

        'Sostituisco i NULLI/VUOTI con 0/spazio a seconda che siano numeri o testi
        LeggiValoriTabellaSubSurfaceConditions()
        ScriviValoriTabSubSurfaceConditions()

    End Sub
    Public Sub LeggiValoriTabellaSubSurfaceConditions()

        'MsgBox("Passo da leggi Valori subSurface Conditions")
        Try
            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(0)) Then
                MadeGroundPresent = False
            Else
                MadeGroundPresent = ds.Tables(SubSurface_Conditions).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(1)) Then
                MadeGroundNotPresent = False
            Else
                MadeGroundNotPresent = ds.Tables(SubSurface_Conditions).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(2)) Then
                MadeGroundNKnown = False
            Else
                MadeGroundNKnown = ds.Tables(SubSurface_Conditions).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(3)) Then
                MadeGroundCont = False
            Else
                MadeGroundCont = ds.Tables(SubSurface_Conditions).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(4)) Then
                MadeGroundContNo = False
            Else
                MadeGroundContNo = ds.Tables(SubSurface_Conditions).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(5)) Then
                MadeGroundContNK = False
            Else
                MadeGroundContNK = ds.Tables(SubSurface_Conditions).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(6)) Then
                MaxThickMG = 0
            Else
                MaxThickMG = ds.Tables(SubSurface_Conditions).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(7)) Then
                SupDepPresent = False
            Else
                SupDepPresent = ds.Tables(SubSurface_Conditions).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(8)) Then
                SupDepPresentNo = False
            Else
                SupDepPresentNo = ds.Tables(SubSurface_Conditions).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(9)) Then
                SupDepPresentNK = False
            Else
                SupDepPresentNK = ds.Tables(SubSurface_Conditions).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(10)) Then
                PerchedWT = " "
            Else
                PerchedWT = ds.Tables(SubSurface_Conditions).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(11)) Then
                SupDep = " "
            Else
                SupDep = ds.Tables(SubSurface_Conditions).Rows(0).Item(11)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(12)) Then
                SupDepCont = " "
            Else
                SupDepCont = ds.Tables(SubSurface_Conditions).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(13)) Then
                SupDepContNo = " "
            Else
                SupDepContNo = ds.Tables(SubSurface_Conditions).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(14)) Then
                MaxThickSD = 0
            Else
                MaxThickSD = ds.Tables(SubSurface_Conditions).Rows(0).Item(14)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(15)) Then
                BedGeol = " "
            Else
                BedGeol = ds.Tables(SubSurface_Conditions).Rows(0).Item(15)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(16)) Then
                GasSer = False
            Else
                GasSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(16)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(17)) Then
                GasBoundX = 0
            Else
                GasBoundX = ds.Tables(SubSurface_Conditions).Rows(0).Item(17)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(18)) Then
                ElectricSer = False
            Else
                ElectricSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(18)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(19)) Then
                ElectricBoundX = " "
            Else
                ElectricBoundX = ds.Tables(SubSurface_Conditions).Rows(0).Item(19)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(20)) Then
                WaterSer = False
            Else
                WaterSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(20)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(21)) Then
                WaterBoundX = " "
            Else
                WaterBoundX = ds.Tables(SubSurface_Conditions).Rows(0).Item(21)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(22)) Then
                TelecomSer = False
            Else
                TelecomSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(22)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(23)) Then
                TelecomBoundX = 0
            Else
                TelecomBoundX = ds.Tables(SubSurface_Conditions).Rows(0).Item(23)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(24)) Then
                SewersSer = False
            Else
                SewersSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(24)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(25)) Then
                SewersBoundX = 0
            Else
                SewersBoundX = ds.Tables(SubSurface_Conditions).Rows(0).Item(25)
            End If

            If IsDBNull(ds.Tables(SubSurface_Conditions).Rows(0).Item(26)) Then
                NoSer = False
            Else
                NoSer = ds.Tables(SubSurface_Conditions).Rows(0).Item(26)
            End If
        Catch
            MadeGroundPresent = False
            MadeGroundNotPresent = False
            MadeGroundNKnown = False
            MadeGroundCont = False
            MadeGroundContNo = False
            MadeGroundContNK = False
            MaxThickMG = 0
            SupDepPresent = False
            SupDepPresentNo = False
            SupDepPresentNK = False
            PerchedWT = " "
            SupDep = " "
            SupDepCont = False
            SupDepContNo = False
            MaxThickSD = 0
            BedGeol = " "
            GasSer = False
            GasBoundX = 0
            ElectricSer = False
            ElectricBoundX = 0
            WaterSer = False
            WaterBoundX = 0
            TelecomSer = False
            TelecomBoundX = 0
            SewersSer = False
            SewersBoundX = 0
            NoSer = False

        End Try

    End Sub
    Sub ScriviValoriTabSubSurfaceConditions()

        Try
            'I valori su tab Sub Surface Conditions 
            Me.rdbMadeGroundYes_2.Checked = MadeGroundPresent '1
            If MadeGroundPresent = True Then
                gpbMadeGroundContinuous.Enabled = True
            End If
            Me.rdbMadeGroundNO_2.Checked = MadeGroundNotPresent '2
            Me.rdbMadeGroundNK_2.Checked = MadeGroundNKnown '3 
            Me.rdbMadeGroundContinuousYES_2.Checked = MadeGroundCont '4
            Me.rdbMadeGroundContinuousNO_2.Checked = MadeGroundContNo '5 
            Me.rdbMadeGroundContinuousNK_2.Checked = MadeGroundContNK '6
            Me.txtMaxThick_MadeGround_2.Text = MaxThickMG '7 
            Me.rdbSuperficialDepositYes_2.Checked = SupDepPresent '8
            If SupDepPresent = True Then
                gpbTypeOfDeposit.Enabled = True
            End If
            Me.rdbSuperficialDepositNO_2.Checked = SupDepPresentNo '9
            Me.rdbSuperficialDepositNK_2.Checked = SupDepPresentNK '10
            Me.cmbPerchedWaterTable_2.Text = PerchedWT '11
            Me.cmbTypeOfDeposit_2.Text = SupDep '12
            Me.rdbSuperficialDepositContinuousYES_2.Checked = SupDepCont '13
            Me.rdbSuperficialDepositContinuousNO_2.Checked = SupDepContNo '14
            Me.txtMaximumThickness_2.Text = MaxThickSD '15
            Me.cmbBedrockGeology_2.Text = BedGeol '16
            Me.chkGas_2.Checked = GasSer '17
            Me.txtGasCrossing_2.Text = GasBoundX '18
            Me.chkElectricity_2.Checked = ElectricSer '19
            Me.txtElectricityCrossing_2.Text = ElectricBoundX '20
            Me.chkWater_2.Checked = WaterSer '21
            Me.txtWaterCrossing_2.Text = WaterBoundX '22
            Me.chkTelecom_2.Checked = TelecomSer '23
            Me.txtTelecomCrossing_2.Text = TelecomBoundX '24
            Me.chkSewers_2.Checked = SewersSer '25
            Me.txtSewerCrossing_2.Text = SewersBoundX '26
            Me.chkNoInformation_2.Checked = NoSer '27
        Catch ex As Exception
            MsgBox("Error writing values in" & SubSurface_Conditions)
            Exit Sub
        End Try

        If chkNoInformation_2.Checked = True Then
            Me.chkGas_2.Enabled = False
            Me.chkElectricity_2.Enabled = False
            Me.chkWater_2.Enabled = False
            Me.chkTelecom_2.Enabled = False
            Me.chkSewers_2.Enabled = False
        Else
            Me.chkGas_2.Enabled = True
            Me.chkElectricity_2.Enabled = True
            Me.chkWater_2.Enabled = True
            Me.chkTelecom_2.Enabled = True
            Me.chkSewers_2.Enabled = True
        End If

    End Sub
    Sub UpdateTabellaSubSurfaceConditions()

        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDBSF.CommandText = "UPDATE tSubSurface SET MadeGroundPresent=" & Me.rdbMadeGroundYes_2.Checked & "," & _
                                                "MadeGroundNotPresent = " & Me.rdbMadeGroundNO_2.Checked & "," & _
                                                "MadeGroundNKnown=" & Me.rdbMadeGroundNK_2.Checked & "," & _
                                                "MadeGroundCont = " & Me.rdbMadeGroundContinuousYES_2.Checked & "," & _
                                                "MadeGroundContNo = " & Me.rdbMadeGroundContinuousNO_2.Checked & "," & _
                                                "MadeGroundContNK = " & Me.rdbMadeGroundContinuousNK_2.Checked & "," & _
                                                "MaxThickMG = " & " '" & Me.txtMaxThick_MadeGround_2.Text & "'" & "," & _
                                                "SupDepPresent = " & Me.rdbSuperficialDepositYes_2.Checked & "," & _
                                                "SupDepPresentNo = " & Me.rdbSuperficialDepositNO_2.Checked & "," & _
                                                "SupDepPresentNK = " & Me.rdbSuperficialDepositNK_2.Checked & "," & _
                                                "PerchedWT = " & " '" & Me.cmbPerchedWaterTable_2.Text & "'" & "," & _
                                                "SupDep = " & " '" & Me.cmbTypeOfDeposit_2.Text & "'" & "," & _
                                                "SupDepCont = " & Me.rdbSuperficialDepositContinuousYES_2.Checked & "," & _
                                                "SupDepContNo = " & Me.rdbSuperficialDepositContinuousNO_2.Checked & "," & _
                                                "MaxThickSD = " & " '" & Me.txtMaximumThickness_2.Text & "'" & "," & _
                                                "BedGeol = " & " '" & Me.cmbBedrockGeology_2.Text & "'" & "," & _
                                                "GasSer = " & Me.chkGas_2.Checked & "," & _
                                                "GasBoundX = " & " '" & Me.txtGasCrossing_2.Text & "'" & "," & _
                                                "ElectricSer = " & Me.chkElectricity_2.Checked & "," & _
                                                "ElectricBoundX = " & " '" & Me.txtElectricityCrossing_2.Text & "'" & "," & _
                                                "WaterSer = " & Me.chkWater_2.Checked & "," & _
                                                "WaterBoundX = " & " '" & Me.txtWaterCrossing_2.Text & "'" & "," & _
                                                "TelecomSer = " & Me.chkTelecom_2.Checked & "," & _
                                                "TelecomBoundX = " & " '" & Me.txtTelecomCrossing_2.Text & "'" & "," & _
                                                "SewersSer = " & Me.chkSewers_2.Checked & "," & _
                                                "SewersBoundX = " & " '" & Me.txtSewerCrossing_2.Text & "'" & "," & _
                                                "NoSer = " & Me.chkNoInformation_2.Checked & " ; "

        'Ricordiamoci sempre che la connessione va aperta per il comando UPDATE
        ComandoUpdateDBSF.Connection = con
        Try
            daSubSurfaceConditions.UpdateCommand = ComandoUpdateDBSF
            daSubSurfaceConditions.UpdateCommand.ExecuteNonQuery()
        Catch
            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Tab 4
    Sub checkTabellaGroundWater_Abstraction()

        Try
            sqlGWA = "SELECT * FROM tGWAbstr"
            daGWAbstraction = New OleDb.OleDbDataAdapter(sqlGWA, con)
            daGWAbstraction.Fill(ds, GroundWater_Abstraction)
        Catch
            MsgBox("Table 'GroundWater_Abstraction' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(GroundWater_Abstraction).Columns.Count

        Dim strNomiCampiGWA As New Collection
        strNomiCampiGWA.Add("AquiClass")
        strNomiCampiGWA.Add("AquiVul")
        strNomiCampiGWA.Add("DataSource")
        strNomiCampiGWA.Add("AquiContam")
        strNomiCampiGWA.Add("AquiContamNo")
        strNomiCampiGWA.Add("AquiContamNK")
        strNomiCampiGWA.Add("SiteSource")
        strNomiCampiGWA.Add("SiteSourceNo")
        strNomiCampiGWA.Add("SiteSourceNK")
        strNomiCampiGWA.Add("LatFlow")
        strNomiCampiGWA.Add("LatFlowNo")
        strNomiCampiGWA.Add("LatFlowNK")
        strNomiCampiGWA.Add("SPZ")
        strNomiCampiGWA.Add("SPZNo")
        strNomiCampiGWA.Add("SPZNK")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiGWA.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(GroundWater_Abstraction).Columns(intK - 1).ColumnName = strNomiCampiGWA(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiGWA.Item(intK) & " not found")
            Exit Sub
        End Try

        LeggiValoriTabellaGroundWater_Abstraction()
        ScriviValoriTabGroundWater_Abstraction()

    End Sub
    Public Sub LeggiValoriTabellaGroundWater_Abstraction()

        Try
            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(0)) Then
                AquiClass = " "
            Else
                AquiClass = ds.Tables(GroundWater_Abstraction).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(1)) Then
                AquiVul = " "
            Else
                AquiVul = ds.Tables(GroundWater_Abstraction).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(2)) Then
                DataSource = " "
            Else
                DataSource = ds.Tables(GroundWater_Abstraction).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(3)) Then
                AquiContam = False
            Else
                AquiContam = ds.Tables(GroundWater_Abstraction).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(4)) Then
                AquiContamNo = False
            Else
                AquiContamNo = ds.Tables(GroundWater_Abstraction).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(5)) Then
                AquiContamNK = False
            Else
                AquiContamNK = ds.Tables(GroundWater_Abstraction).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(6)) Then
                SiteSource = False
            Else
                SiteSource = ds.Tables(GroundWater_Abstraction).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(7)) Then
                SiteSourceNo = False
            Else
                SiteSourceNo = ds.Tables(GroundWater_Abstraction).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(8)) Then
                SiteSourceNK = False
            Else
                SiteSourceNK = ds.Tables(GroundWater_Abstraction).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(9)) Then
                LatFlow = False
            Else
                LatFlow = ds.Tables(GroundWater_Abstraction).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(10)) Then
                LatFlowNo = False
            Else
                LatFlowNo = ds.Tables(GroundWater_Abstraction).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(11)) Then
                LatFlowNK = False
            Else
                LatFlowNK = ds.Tables(GroundWater_Abstraction).Rows(0).Item(11)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(12)) Then
                SPZ = False
            Else
                SPZ = ds.Tables(GroundWater_Abstraction).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(13)) Then
                SPZNo = False
            Else
                SPZNo = ds.Tables(GroundWater_Abstraction).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(GroundWater_Abstraction).Rows(0).Item(14)) Then
                SPZNK = False
            Else
                SPZNK = ds.Tables(GroundWater_Abstraction).Rows(0).Item(14)
            End If

        Catch ex As Exception
            AquiClass = " "
            AquiVul = " "
            DataSource = " "
            AquiContam = False
            AquiContamNo = False
            AquiContamNK = False
            SiteSource = False
            SiteSourceNo = False
            SiteSourceNK = False
            LatFlow = False
            LatFlowNo = False
            LatFlowNK = False
            SPZ = False
            SPZNo = False
            SPZNK = False
        End Try

    End Sub
    Sub ScriviValoriTabGroundWater_Abstraction()
        Try
            Me.cmbNRAAquiferClassification_3.Text = AquiClass
            Me.cmbNRAAquiferVulnerability_3.Text = AquiVul
            Me.cmbDataSource_3.Text = DataSource
            Me.rdbUnderlyingAquiferYES_3.Checked = AquiContam
            If AquiContam = True Then
                gpbUnderlyingAquiferSourceContamination.Enabled = True
            End If
            Me.rdbUnderlyingAquiferNO_3.Checked = AquiContamNo
            Me.rdbUnderlyingAquiferNK_3.Checked = AquiContamNK
            Me.rdbUnderlyingAquiferSourceContaminationYES_3.Checked = SiteSource
            Me.rdbUnderlyingAquiferSourceContaminationNO_3.Checked = SiteSourceNo
            Me.rdbUnderlyingAquiferSourceContaminationNK_3.Checked = SiteSourceNK
            Me.rdbLateralFlowYES_3.Checked = LatFlow
            Me.rdbLateralFlowNO_3.Checked = LatFlowNo
            Me.rdbLateralFlowNK_3.Checked = LatFlowNK
            Me.rdbSourceProtectionZoneYES_3.Checked = SPZ
            Me.rdbSourceProtectionZoneNO_3.Checked = SPZNo
            Me.rdbSourceProtectionZoneNK_3.Checked = SPZNK
        Catch ex As Exception
            MsgBox("Error Writing values to" & GroundWater_Abstraction)
            Exit Sub
        End Try
    End Sub
    Sub UpdateTabellaGroundWater_Abstraction()

        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDBSF.CommandText = "UPDATE tGWAbstr SET AquiClass=" & "'" & Me.cmbNRAAquiferClassification_3.Text & "'" & "," & _
                                                "AquiVul = " & " '" & Me.cmbNRAAquiferVulnerability_3.Text & "'" & "," & _
                                                "DataSource = " & " '" & Me.cmbDataSource_3.Text & "'" & "," & _
                                                "AquiContam = " & Me.rdbUnderlyingAquiferYES_3.Checked & "," & _
                                                "AquiContamNo = " & Me.rdbUnderlyingAquiferNO_3.Checked & "," & _
                                                "AquiContamNK = " & Me.rdbUnderlyingAquiferNK_3.Checked & "," & _
                                                "SiteSource = " & Me.rdbUnderlyingAquiferSourceContaminationYES_3.Checked & "," & _
                                                "SiteSourceNo = " & Me.rdbUnderlyingAquiferSourceContaminationNO_3.Checked & "," & _
                                                "SiteSourceNK = " & Me.rdbUnderlyingAquiferSourceContaminationNK_3.Checked & "," & _
                                                "LatFlow = " & Me.rdbLateralFlowYES_3.Checked & "," & _
                                                "LatFlowNo = " & Me.rdbLateralFlowNO_3.Checked & "," & _
                                                "LatFlowNK = " & Me.rdbLateralFlowNK_3.Checked & "," & _
                                                "SPZ = " & Me.rdbSourceProtectionZoneYES_3.Checked & "," & _
                                                "SPZNo = " & Me.rdbSourceProtectionZoneNO_3.Checked & "," & _
                                                "SPZNK = " & Me.rdbSourceProtectionZoneNK_3.Checked & " ; "


        ComandoUpdateDBSF.Connection = con
        Try
            daGWAbstraction.UpdateCommand = ComandoUpdateDBSF
            daGWAbstraction.UpdateCommand.ExecuteNonQuery()
        Catch

            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Tab 5
    Sub checkTabellaSurfaceWater_Environment()

        Try
            sqlGWA = "SELECT * FROM tSWEnviro"
            daSWEnvironment = New OleDb.OleDbDataAdapter(sqlGWA, con)
            daSWEnvironment.Fill(ds, SurfaceWater_Environment)
        Catch
            MsgBox("Table 'Surface Water_Environment not found!")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(SurfaceWater_Environment).Columns.Count

        Dim strNomiCampiSWE As New Collection
        strNomiCampiSWE.Add("noInfoWB") '1
        strNomiCampiSWE.Add("WBtype1") '2
        strNomiCampiSWE.Add("WBtype2") '3
        strNomiCampiSWE.Add("WBtype3") '4 
        strNomiCampiSWE.Add("WBDistSite1") '5
        strNomiCampiSWE.Add("WBDistSite2") '6
        strNomiCampiSWE.Add("WBDistSite3") '7 
        strNomiCampiSWE.Add("ExistGQAWatQual1") '8
        strNomiCampiSWE.Add("ExistGQAWatQual2") '9
        strNomiCampiSWE.Add("ExistGQAWatQual3") '10
        strNomiCampiSWE.Add("FlowRate1") '11
        strNomiCampiSWE.Add("FlowRate2") '12
        strNomiCampiSWE.Add("FlowRate3") '13
        strNomiCampiSWE.Add("noInfoSenTarg") '14
        strNomiCampiSWE.Add("TTDistSite1")  '15
        strNomiCampiSWE.Add("TTDistSite2") '16
        strNomiCampiSWE.Add("TTDistSite3") '17
        strNomiCampiSWE.Add("TargType1") '18
        strNomiCampiSWE.Add("TargType2") '19
        strNomiCampiSWE.Add("TargType3") '20
        strNomiCampiSWE.Add("SWuse") '21
        strNomiCampiSWE.Add("SWuseNo") '22
        strNomiCampiSWE.Add("SWuseNK") '23
        strNomiCampiSWE.Add("SWendUse") '24


        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiSWE.Count)
        'MsgBox(intNumCampiLetti & " - " & intNumCampiAspettati & " - " & SurfaceWater_Environment)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(SurfaceWater_Environment).Columns(intK - 1).ColumnName = strNomiCampiSWE(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiSWE.Item(intK) & " not found")
            Exit Sub
        End Try

        'Sostituisco i NULLI/VUOTI con 0/spazio a seconda che siano numeri o testi
        LeggiValoriTabellaSurfaceWater_Environment()
        ScriviValoriTabSurfaceWater_Environment()

    End Sub
    Public Sub LeggiValoriTabellaSurfaceWater_Environment()

        Try
            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(0)) Then
                blnNoInfoWB = False
            Else
                blnNoInfoWB = ds.Tables(SurfaceWater_Environment).Rows(0).Item(0)

            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(1)) Then
                strWBtype1 = " "
            Else
                strWBtype1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(2)) Then
                strWBtype2 = " "
            Else
                strWBtype2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(3)) Then
                strWBtype3 = " "
            Else
                strWBtype3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(4)) Then
                dblWBDistSite1 = 0
            Else
                dblWBDistSite1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(5)) Then
                dblWBDistSite2 = 0
            Else
                dblWBDistSite2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(6)) Then
                dblWBDistSite3 = 0
            Else
                dblWBDistSite3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(7)) Then
                strExistGQAWatQual1 = " "
            Else
                strExistGQAWatQual1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(8)) Then
                strExistGQAWatQual2 = " "
            Else
                strExistGQAWatQual2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(9)) Then
                strExistGQAWatQual3 = " "
            Else
                strExistGQAWatQual3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(9)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(10)) Then
                strFlowRate1 = " "
            Else
                strFlowRate1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(11)) Then
                strFlowRate2 = " "
            Else
                strFlowRate2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(11)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(12)) Then
                strFlowRate3 = " "
            Else
                strFlowRate3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(13)) Then
                blnNoInfoSenTarg = False
            Else
                blnNoInfoSenTarg = ds.Tables(SurfaceWater_Environment).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(14)) Then
                dblTTDistSite1 = 0
            Else
                dblTTDistSite1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(14)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(15)) Then
                dblTTDistSite2 = 0
            Else
                dblTTDistSite2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(15)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(16)) Then
                dblTTDistSite3 = 0
            Else
                dblTTDistSite3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(16)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(17)) Then
                strTargType1 = " "
            Else
                strTargType1 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(17)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(18)) Then
                strTargType2 = " "
            Else
                strTargType2 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(18)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(19)) Then
                strTargType3 = " "
            Else
                strTargType3 = ds.Tables(SurfaceWater_Environment).Rows(0).Item(19)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(20)) Then
                blnSWuse = False
            Else
                blnSWuse = ds.Tables(SurfaceWater_Environment).Rows(0).Item(20)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(21)) Then
                blnSWuseNo = False
            Else
                blnSWuseNo = ds.Tables(SurfaceWater_Environment).Rows(0).Item(21)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(22)) Then
                blnSWuseNK = False
            Else
                blnSWuseNK = ds.Tables(SurfaceWater_Environment).Rows(0).Item(22)
            End If

            If IsDBNull(ds.Tables(SurfaceWater_Environment).Rows(0).Item(23)) Then
                strSWendUse = " "
            Else
                strSWendUse = ds.Tables(SurfaceWater_Environment).Rows(0).Item(23)
            End If
        Catch ex As Exception
            blnNoInfoWB = False
            strWBtype1 = " "
            strWBtype2 = " "
            strWBtype3 = " "
            dblWBDistSite1 = 0
            dblWBDistSite2 = 0
            dblWBDistSite3 = 0
            strExistGQAWatQual1 = " "
            strExistGQAWatQual2 = " "
            strExistGQAWatQual3 = " "
            strFlowRate1 = " "
            strFlowRate2 = " "
            strFlowRate3 = " "
            blnNoInfoSenTarg = False
            dblTTDistSite1 = 0
            dblTTDistSite2 = 0
            dblTTDistSite3 = 0
            strTargType1 = " "
            strTargType2 = " "
            strTargType3 = " "
            blnSWuse = False
            blnSWuseNo = False
            blnSWuseNK = False
            strSWendUse = " "

        End Try
    End Sub
    Sub ScriviValoriTabSurfaceWater_Environment()

        Me.chkWaterBodies_4.Checked = blnNoInfoWB
        If blnNoInfoWB = True Then
            gpbWaterBodies.Enabled = True
        End If

        Me.cmbWaterBodyType1_4.Text = strWBtype1
        Me.cmbWaterBodyType2_4.Text = strWBtype2
        Me.cmbWaterBodyType3_4.Text = strWBtype3

        Me.txtWaterBodyTypeDistance1_4.Text = dblWBDistSite1
        Me.txtWaterBodyTypeDistance2_4.Text = dblWBDistSite2
        Me.txtWaterBodyTypeDistance3_4.Text = dblWBDistSite3

        Me.cmbGQAWaterQuality1_4.Text = strExistGQAWatQual1
        Me.cmbGQAWaterQuality2_4.Text = strExistGQAWatQual2
        Me.cmbGQAWaterQuality3_4.Text = strExistGQAWatQual3

        Me.cmbFlowRate1_4.Text = strFlowRate1
        Me.cmbFlowRate2_4.Text = strFlowRate2
        Me.cmbFlowRate3_4.Text = strFlowRate3

        Me.chkSensitiveEnvironmentalTargets_4.Checked = blnNoInfoSenTarg
        If blnNoInfoSenTarg = False Then
            gpbSensitiveEnvironmentalTargets.Enabled = True
        End If

        Me.txtSensitiveEnvironmentalTargetsDistance1_4.Text = dblTTDistSite1
        Me.txtSensitiveEnvironmentalTargetsDistance2_4.Text = dblTTDistSite2
        Me.txtSensitiveEnvironmentalTargetsDistance3_4.Text = dblTTDistSite3

        Me.cmbSensitiveEnvironmentalTargetsType1_4.Text = strTargType1
        Me.cmbSensitiveEnvironmentalTargetsType2_4.Text = strTargType2
        Me.cmbSensitiveEnvironmentalTargetsType3_4.Text = strTargType3

        Me.rdbSurfaceWaterUseYES_4.Checked = blnSWuse
        If blnSWuse = True Then
            gpbSurfaceWaterUseNearest.Enabled = True
        End If

        Me.rdbSurfaceWaterUseNO_4.Checked = blnSWuseNo
        Me.rdbSurfaceWaterUseNK_4.Checked = blnSWuseNK

        Me.cmbNearestOne_4.Text = strSWendUse

    End Sub
    Sub checkDistanzeSurfaceWater_Environment()
        If Me.txtWaterBodyTypeDistance1_4.Text = " " Then
            Me.txtWaterBodyTypeDistance1_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

        If Me.txtWaterBodyTypeDistance2_4.Text = " " Then
            Me.txtWaterBodyTypeDistance2_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

        If Me.txtWaterBodyTypeDistance3_4.Text = " " Then
            Me.txtWaterBodyTypeDistance3_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

        If Me.txtSensitiveEnvironmentalTargetsDistance1_4.Text = " " Then
            Me.txtSensitiveEnvironmentalTargetsDistance1_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

        If Me.txtSensitiveEnvironmentalTargetsDistance2_4.Text = " " Then
            Me.txtSensitiveEnvironmentalTargetsDistance2_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

        If Me.txtSensitiveEnvironmentalTargetsDistance3_4.Text = " " Then
            Me.txtSensitiveEnvironmentalTargetsDistance3_4.Text = 0
            MsgBox("Invalid value in 'Distance from site' in row 1")
            Exit Sub
        End If

    End Sub
    Sub UpdateTabellaSurfaceWater_Environment()

        checkDistanzeSurfaceWater_Environment()


        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDBSF.CommandText = "UPDATE tSWEnviro SET noInfoWB=" & Me.chkWaterBodies_4.Checked & "," & _
                                                "WBtype1 = " & " '" & Me.cmbWaterBodyType1_4.Text & "'" & "," & _
                                                "WBtype2 = " & " '" & Me.cmbWaterBodyType2_4.Text & "'" & "," & _
                                                "WBtype3 = " & " '" & Me.cmbWaterBodyType3_4.Text & "'" & "," & _
                                                "WBDistSite1 = " & " '" & Me.txtWaterBodyTypeDistance1_4.Text & "'" & "," & _
                                                "WBDistSite2 = " & " '" & Me.txtWaterBodyTypeDistance2_4.Text & "'" & "," & _
                                                "WBDistSite3 = " & " '" & Me.txtWaterBodyTypeDistance3_4.Text & "'" & "," & _
                                                "ExistGQAWatQual1 = " & " '" & Me.cmbGQAWaterQuality1_4.Text & "'" & "," & _
                                                "ExistGQAWatQual2 = " & " '" & Me.cmbGQAWaterQuality2_4.Text & "'" & "," & _
                                                "ExistGQAWatQual3 = " & " '" & Me.cmbGQAWaterQuality3_4.Text & "'" & "," & _
                                                "FlowRate1 = " & " '" & Me.cmbFlowRate1_4.Text & "'" & "," & _
                                                "FlowRate2 = " & " '" & Me.cmbFlowRate2_4.Text & "'" & "," & _
                                                "FlowRate3 = " & " '" & Me.cmbFlowRate3_4.Text & "'" & "," & _
                                                "noInfoSenTarg = " & Me.chkSensitiveEnvironmentalTargets_4.Checked & "," & _
                                                "TTDistSite1 = " & " '" & Me.txtSensitiveEnvironmentalTargetsDistance1_4.Text & "'" & "," & _
                                                "TTDistSite2 = " & " '" & Me.txtSensitiveEnvironmentalTargetsDistance2_4.Text & "'" & "," & _
                                                "TTDistSite3 = " & " '" & Me.txtSensitiveEnvironmentalTargetsDistance3_4.Text & "'" & "," & _
                                                "TargType1 = " & " '" & Me.cmbSensitiveEnvironmentalTargetsType1_4.Text & "'" & "," & _
                                                "TargType2 = " & " '" & Me.cmbSensitiveEnvironmentalTargetsType2_4.Text & "'" & "," & _
                                                "TargType3 = " & " '" & Me.cmbSensitiveEnvironmentalTargetsType3_4.Text & "'" & "," & _
                                                "SWuse = " & Me.rdbSurfaceWaterUseYES_4.Checked & "," & _
                                                "SWuseNo = " & Me.rdbSurfaceWaterUseNO_4.Checked & "," & _
                                                "SWuseNK = " & Me.rdbSurfaceWaterUseNK_4.Checked & "," & _
                                                "SWendUse = " & " '" & Me.cmbNearestOne_4.Text & "'" & " ; "


        ComandoUpdateDBSF.Connection = con
        Try
            daSWEnvironment.UpdateCommand = ComandoUpdateDBSF
            daSWEnvironment.UpdateCommand.ExecuteNonQuery()
        Catch

            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Tab 6
    Sub checkTabellaContaminationPathways()

        Try
            sqlCP = "SELECT * FROM tContaminationPathways"
            daContaminantsPathways = New OleDb.OleDbDataAdapter(sqlCP, con)
            daContaminantsPathways.Fill(ds, Contamination_Pathway)
        Catch
            MsgBox("Table 'Contamination Pathway' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Contamination_Pathway).Columns.Count


        Dim strNomiCampiCP As New Collection
        strNomiCampiCP.Add("SRO_InfPath")
        strNomiCampiCP.Add("SRO_KnwnPath")
        strNomiCampiCP.Add("SRO_CrssBoundContam")
        strNomiCampiCP.Add("SRO_Addressed")
        strNomiCampiCP.Add("SRO_ActionTaken")
        strNomiCampiCP.Add("OEH_InfPath")
        strNomiCampiCP.Add("OEH_KnwnPath")
        strNomiCampiCP.Add("OEH_CrssBoundContam")
        strNomiCampiCP.Add("OEH_Addressed")
        strNomiCampiCP.Add("OEH_ActionTaken")
        strNomiCampiCP.Add("DP_InfPath")
        strNomiCampiCP.Add("DP_KnwnPath")
        strNomiCampiCP.Add("DP_CrssBoundContam")
        strNomiCampiCP.Add("DP_Addressed")
        strNomiCampiCP.Add("DP_ActionTaken")
        strNomiCampiCP.Add("AirB_InfPath")
        strNomiCampiCP.Add("AirB_KnwnPath")
        strNomiCampiCP.Add("AirB_CrssBoundContam")
        strNomiCampiCP.Add("AirB_Addressed")
        strNomiCampiCP.Add("AirB_ActionTaken")
        strNomiCampiCP.Add("VF_InfPath")
        strNomiCampiCP.Add("VF_KnwnPath")
        strNomiCampiCP.Add("VF_CrssBoundContam")
        strNomiCampiCP.Add("VF_Addressed")
        strNomiCampiCP.Add("VF_ActionTaken")
        strNomiCampiCP.Add("LF_InfPath")
        strNomiCampiCP.Add("LF_KnwnPath")
        strNomiCampiCP.Add("LF_CrssBoundContam")
        strNomiCampiCP.Add("LF_Addressed")
        strNomiCampiCP.Add("LF_ActionTaken")
        strNomiCampiCP.Add("LF_DirPlume")
        strNomiCampiCP.Add("VC_InfPath")
        strNomiCampiCP.Add("VC_KnwnPath")
        strNomiCampiCP.Add("VC_Sealed")
        strNomiCampiCP.Add("VC_SealedNo")
        strNomiCampiCP.Add("VC_SealedNK")
        strNomiCampiCP.Add("VC_TypeCond")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiCP.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Contamination_Pathway).Columns(intK - 1).ColumnName = strNomiCampiCP(intK) Then
                End If
            Next
        Catch
            MsgBox("Field " & intK & " - " & strNomiCampiCP.Item(intK) & " not found")
            Exit Sub
        End Try

        LeggiValoriTabellaContaminationPathways()
        ScriviValoriTabContaminationPathways()

    End Sub
    Public Sub LeggiValoriTabellaContaminationPathways()

        Try
            '************************************************************************
            'Reading for the first row of the checkboxes
            '************************************************************************
            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(0)) Then
                blnSRO_InfPath = False
            Else
                blnSRO_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(1)) Then
                blnSRO_KnwnPath = False
            Else
                blnSRO_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(1)

            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(2)) Then
                blnSRO_CrssBoundContam = False
            Else
                blnSRO_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(3)) Then
                blnSRO_Addressed = False
            Else
                blnSRO_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(4)) Then
                strSRO_ActionTaken = " "
            Else
                strSRO_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(4)
            End If

            '************************************************************************
            'Reading for the second row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(5)) Then
                blnOEH_InfPath = False
            Else
                blnOEH_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(6)) Then
                blnOEH_KnwnPath = False
            Else
                blnOEH_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(7)) Then
                blnOEH_CrssBoundContam = False
            Else
                blnOEH_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(8)) Then
                blnOEH_Addressed = False
            Else
                blnOEH_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(9)) Then
                strOEH_ActionTaken = " "
            Else
                strOEH_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(9)
            End If

            '************************************************************************
            'Reading for the third row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(10)) Then
                blnDP_InfPath = False
            Else
                blnDP_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(10)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(11)) Then
                blnDP_KnwnPath = False
            Else
                blnDP_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(11)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(12)) Then
                blnDP_CrssBoundContam = False
            Else
                blnDP_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(12)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(13)) Then
                blnDP_Addressed = False
            Else
                blnDP_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(13)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(14)) Then
                strDP_ActionTaken = " "
            Else
                strDP_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(14)
            End If

            '************************************************************************
            'Reading for the fourth row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(15)) Then
                blnAirB_InfPath = False
            Else
                blnAirB_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(15)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(16)) Then
                blnAirB_KnwnPath = False
            Else
                blnAirB_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(16)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(17)) Then
                blnAirB_CrssBoundContam = False
            Else
                blnAirB_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(17)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(18)) Then
                blnAirB_Addressed = False
            Else
                blnAirB_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(18)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(19)) Then
                strAirB_ActionTaken = " "
            Else
                strAirB_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(19)
            End If

            '************************************************************************
            'Reading for the fifth row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(20)) Then
                blnVF_InfPath = False
            Else
                blnVF_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(20)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(21)) Then
                blnVF_KnwnPath = False
            Else
                blnVF_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(21)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(22)) Then
                blnVF_CrssBoundContam = False
            Else
                blnVF_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(22)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(23)) Then
                blnVF_Addressed = False
            Else
                blnVF_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(23)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(24)) Then
                strVF_ActionTaken = " "
            Else
                strVF_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(24)
            End If

            '************************************************************************
            'Reading for the sixth row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(25)) Then
                blnLF_InfPath = False
            Else
                blnLF_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(25)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(26)) Then
                blnLF_KnwnPath = False
            Else
                blnLF_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(26)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(27)) Then
                blnLF_CrssBoundContam = False
            Else
                blnLF_CrssBoundContam = ds.Tables(Contamination_Pathway).Rows(0).Item(27)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(28)) Then
                blnLF_Addressed = False
            Else
                blnLF_Addressed = ds.Tables(Contamination_Pathway).Rows(0).Item(28)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(29)) Then
                strLF_ActionTaken = " "
            Else
                strLF_ActionTaken = ds.Tables(Contamination_Pathway).Rows(0).Item(29)
            End If

            '************************************************************************
            'Reading for the seventh row of the checkboxes
            '************************************************************************

            '************************************************************************
            'Reading for the eighth row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(30)) Then
                strLF_DirPlume = " "
            Else
                strLF_DirPlume = ds.Tables(Contamination_Pathway).Rows(0).Item(30)
            End If

            '************************************************************************
            'Reading for the ninth row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(31)) Then
                blnVC_InfPath = False
            Else
                blnVC_InfPath = ds.Tables(Contamination_Pathway).Rows(0).Item(31)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(32)) Then
                blnVC_KnwnPath = False
            Else
                blnVC_KnwnPath = ds.Tables(Contamination_Pathway).Rows(0).Item(32)
            End If

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(33)) Then
                blnVC_SealedNo = False
            Else
                blnVC_SealedNo = ds.Tables(Contamination_Pathway).Rows(0).Item(33)
            End If

            '************************************************************************
            'Reading for the tenth row of the checkboxes
            '************************************************************************
            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(34)) Then
                blnVC_Sealed = False
            Else
                blnVC_Sealed = ds.Tables(Contamination_Pathway).Rows(0).Item(34)
            End If


            '************************************************************************
            'Reading for the eleventh row of the checkboxes
            '************************************************************************

            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(35)) Then
                blnVC_SealedNK = False
            Else
                blnVC_SealedNK = ds.Tables(Contamination_Pathway).Rows(0).Item(35)
            End If


            If IsDBNull(ds.Tables(Contamination_Pathway).Rows(0).Item(36)) Then
                strVC_TypeCond = " "
            Else
                strVC_TypeCond = ds.Tables(Contamination_Pathway).Rows(0).Item(36)
            End If

        Catch ex As Exception
            blnSRO_InfPath = False
            blnSRO_KnwnPath = False
            blnSRO_CrssBoundContam = False
            blnSRO_Addressed = False
            strSRO_ActionTaken = " "
            blnOEH_InfPath = False
            blnOEH_KnwnPath = False
            blnOEH_CrssBoundContam = False
            blnOEH_Addressed = False
            strOEH_ActionTaken = " "
            blnDP_InfPath = False
            blnDP_KnwnPath = False
            blnDP_CrssBoundContam = False
            blnDP_Addressed = False
            strDP_ActionTaken = " "
            blnAirB_InfPath = False
            blnAirB_KnwnPath = False
            blnAirB_CrssBoundContam = False
            blnAirB_Addressed = False
            strAirB_ActionTaken = " "
            blnVF_InfPath = False
            blnVF_KnwnPath = False
            blnVF_CrssBoundContam = False
            blnVF_Addressed = False
            strVF_ActionTaken = " "
            blnLF_InfPath = False
            blnLF_KnwnPath = False
            blnLF_CrssBoundContam = False
            blnLF_Addressed = False
            strLF_ActionTaken = " "
            strLF_DirPlume = " "
            blnVC_InfPath = False
            blnVC_KnwnPath = False
            blnVC_SealedNo = False
            blnVC_Sealed = False
            blnVC_SealedNK = False
            strVC_TypeCond = " "

        End Try

    End Sub
    Sub ScriviValoriTabContaminationPathways()

        'WRITING DATA READ IN THE PREVIOUS ROUTINE
        'First ROW
        Me.chk11_5.Checked = blnSRO_InfPath
        Me.chk12_5.Checked = blnSRO_KnwnPath
        Me.chk13_5.Checked = blnSRO_CrssBoundContam
        Me.chk14_5.Checked = blnSRO_Addressed
        Me.cmb15_5.Text = strSRO_ActionTaken

        'SECOND ROW
        Me.chk21_5.Checked = blnOEH_InfPath
        Me.chk22_5.Checked = blnOEH_KnwnPath
        Me.chk23_5.Checked = blnOEH_CrssBoundContam
        Me.chk24_5.Checked = blnOEH_Addressed
        Me.cmb25_5.Text = strOEH_ActionTaken

        'THIRD ROW
        Me.chk31_5.Checked = blnDP_InfPath
        Me.chk32_5.Checked = blnDP_KnwnPath
        Me.chk33_5.Checked = blnDP_CrssBoundContam
        Me.chk34_5.Checked = blnDP_Addressed
        Me.cmb35_5.Text = strDP_ActionTaken

        'FOURTH ROW
        Me.chk41_5.Checked = blnAirB_InfPath
        Me.chk42_5.Checked = blnAirB_KnwnPath
        Me.chk43_5.Checked = blnAirB_CrssBoundContam
        Me.chk44_5.Checked = blnAirB_Addressed
        Me.cmb45_5.Text = strAirB_ActionTaken

        'FIFTH ROW
        Me.chk51_5.Checked = blnVF_InfPath
        Me.chk52_5.Checked = blnVF_KnwnPath
        Me.chk53_5.Checked = blnVF_CrssBoundContam
        Me.chk54_5.Checked = blnVF_Addressed
        Me.cmb55_5.Text = strVF_ActionTaken

        'SIXTH ROW
        Me.chk61_5.Checked = blnLF_InfPath
        Me.chk62_5.Checked = blnLF_KnwnPath
        Me.chk63_5.Checked = blnLF_CrssBoundContam
        Me.chk64_5.Checked = blnLF_Addressed
        Me.cmb65_5.Text = strLF_ActionTaken

        'EIGHTH ROW
        Me.cmb83_5.Text = strLF_DirPlume

        'NINTH ROW
        Me.chk91_5.Checked = blnVC_InfPath
        Me.chk92_5.Checked = blnVC_KnwnPath
        Me.rdb94_5.Checked = blnVC_SealedNo

        'TANTH ROW
        Me.rdb104_5.Checked = blnVC_Sealed

        'ELEVENTH ROW
        Me.rdb114_5.Checked = blnVC_SealedNK
        Me.cmb115_5.Text = strVC_TypeCond


    End Sub
    Sub UpdateTabellaContaminationPathways()

        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDBSF.CommandText = "UPDATE tContaminationPathways SET SRO_InfPath=" & Me.chk11_5.Checked & "," & _
                                                "SRO_KnwnPath = " & Me.chk12_5.Checked & "," & _
                                                "SRO_CrssBoundContam = " & Me.chk13_5.Checked & "," & _
                                                "SRO_Addressed = " & Me.chk14_5.Checked & "," & _
                                                "SRO_ActionTaken = " & " '" & Me.cmb15_5.Text & "'" & "," & _
                                                "OEH_InfPath = " & Me.chk21_5.Checked & "," & _
                                                "OEH_KnwnPath = " & Me.chk22_5.Checked & "," & _
                                                "OEH_CrssBoundContam = " & Me.chk23_5.Checked & "," & _
                                                "OEH_Addressed = " & Me.chk24_5.Checked & "," & _
                                                "OEH_ActionTaken = " & " '" & Me.cmb25_5.Text & "'" & "," & _
                                                "DP_InfPath = " & Me.chk31_5.Checked & "," & _
                                                "DP_KnwnPath = " & Me.chk32_5.Checked & "," & _
                                                "DP_CrssBoundContam = " & Me.chk33_5.Checked & "," & _
                                                "DP_Addressed = " & Me.chk34_5.Checked & "," & _
                                                "DP_ActionTaken = " & " '" & Me.cmb35_5.Text & "'" & "," & _
                                                "AirB_InfPath = " & Me.chk41_5.Checked & "," & _
                                                "AirB_KnwnPath = " & Me.chk42_5.Checked & "," & _
                                                "AirB_CrssBoundContam = " & Me.chk43_5.Checked & "," & _
                                                "AirB_Addressed = " & Me.chk44_5.Checked & "," & _
                                                "AirB_ActionTaken = " & " '" & Me.cmb45_5.Text & "'" & "," & _
                                                "VF_InfPath = " & Me.chk51_5.Checked & "," & _
                                                "VF_KnwnPath = " & Me.chk52_5.Checked & "," & _
                                                "VF_CrssBoundContam = " & Me.chk53_5.Checked & "," & _
                                                "VF_Addressed = " & Me.chk54_5.Checked & "," & _
                                                "VF_ActionTaken = " & " '" & Me.cmb55_5.Text & "'" & "," & _
                                                "LF_InfPath = " & Me.chk61_5.Checked & "," & _
                                                "LF_KnwnPath = " & Me.chk62_5.Checked & "," & _
                                                "LF_CrssBoundContam = " & Me.chk63_5.Checked & "," & _
                                                "LF_Addressed = " & Me.chk64_5.Checked & "," & _
                                                "LF_ActionTaken = " & " '" & Me.cmb65_5.Text & "'" & "," & _
                                                "LF_DirPlume = " & " '" & Me.cmb83_5.Text & "'" & "," & _
                                                "VC_InfPath = " & Me.chk91_5.Checked & "," & _
                                                "VC_KnwnPath = " & Me.chk92_5.Checked & "," & _
                                                "VC_SealedNo = " & Me.rdb94_5.Checked & "," & _
                                                "VC_Sealed = " & Me.rdb104_5.Checked & "," & _
                                                "VC_SealedNK = " & Me.rdb114_5.Checked & "," & _
                                                "VC_TypeCond = " & " '" & Me.cmb115_5.Text & "'" & " ; "


        ComandoUpdateDBSF.Connection = con
        Try
            daContaminantsPathways.UpdateCommand = ComandoUpdateDBSF
            daContaminantsPathways.UpdateCommand.ExecuteNonQuery()
        Catch
            MessageBox.Show("Problem updating the database", "Please, check the data entered a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Tab 7
    Private Sub LeggiValoreSiteStatus()

        '*************************************************************************
        'LOAD DATA ON THE COMBOBOX
        '*************************************************************************
        Try
            sqlRef = "SELECT * FROM tSiteStatus"
            daSiteStatus = New OleDb.OleDbDataAdapter(sqlRef, con)
            daSiteStatus.Fill(ds, SiteStatus)
        Catch
            MsgBox("Table 'Site Status' not found")
            Exit Sub
        End Try

        If IsDBNull(ds.Tables(SiteStatus).Rows(0).Item(0)) Then
            strSiteStatus = " "
        Else
            strSiteStatus = ds.Tables(SiteStatus).Rows(0).Item(0)
        End If

        'WRITE DATA ON THE COMBOBOX
        Me.cmbCurrentSiteStatus_6().Text() = strSiteStatus

    End Sub
    Sub UpdateTabellaReferencesSiteStatus()

        Dim ComandoUpdateDBSF As System.Data.OleDb.OleDbCommand
        ComandoUpdateDBSF = New System.Data.OleDb.OleDbCommand

        ' Update  combo
        ComandoUpdateDBSF.CommandText = "UPDATE tSiteStatus SET SiteStatus=" & "'" & Me.cmbCurrentSiteStatus_6().Text & "'" & " ; "

        ComandoUpdateDBSF.Connection = con
        Try
            daSiteInformation.UpdateCommand = ComandoUpdateDBSF
            daSiteInformation.UpdateCommand.ExecuteNonQuery()
        Catch

            MessageBox.Show("No database loaded", "Please, load a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

    End Sub
    Sub checkTabellaReference()

        Dim refer_Load As String
        refer_Load = "Referenze"

        Dim sqlReferLoad As String

        sqlReferLoad = "SELECT DummyPrimary,DocTitle ,Author,DateRef  FROM tReferences"
        Dim daReferLoad As OleDbDataAdapter
        daReferLoad = New OleDb.OleDbDataAdapter(sqlReferLoad, con)
        Try
            daReferLoad.Fill(ds, refer_Load)
        Catch
            MsgBox("Malformed Reference Table", MsgBoxStyle.Information, "Error")
            Exit Sub
        End Try


        MaxRows = ds.Tables(refer_Load).Rows.Count
        If MaxRows = 0 Then
            Me.btnDeleteRef.Enabled = False
        Else
            Me.btnDeleteRef.Enabled = True
        End If

        Dim data_table As New DataTable("Tabella")
        daReferLoad.Fill(data_table)
        DataGridReferences_6.DataSource = data_table
        DataGridReferences_6.Columns(0).HeaderText = "Key"
        DataGridReferences_6.Columns(1).HeaderText = "Document Title"
        DataGridReferences_6.Columns(2).HeaderText = "Author"
        DataGridReferences_6.Columns(3).HeaderText = "Reference Date"

        ' Set column alignments.
        For c As Integer = 0 To DataGridReferences_6.Columns.Count - 1
            Select Case DataGridReferences_6.Columns(c).ValueType.ToString
                Case "System.Decimal"  'Currency.
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Format = "c"
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "System.DateTime" 'Date.
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Format = "d"
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "System.String"
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Format = ""
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "System.Single"    'One digit after the decimal point.
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Format = ".0"
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else       'Probably number.
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Format = ""
                    DataGridReferences_6.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next c

    End Sub
    Private Sub btnAddRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRef.Click
        If nomefile = "" Then
            MsgBox("No Database loaded", MsgBoxStyle.Critical, "Please Load a database")
            Exit Sub
        End If
        frmNuovaRef.Show()
    End Sub
    Private Sub btnDeleteRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRef.Click

        If nomefile = "" Then
            MsgBox("No Database loaded", MsgBoxStyle.Critical, "Please Load a database")
            Exit Sub
        End If

        'cancellaRiga()
        Dim refer_Togli As String
        refer_Togli = "ReferenzeTogli"

        Dim sqlReferTogli As String
        sqlReferTogli = "SELECT * FROM tReferences"

        Dim daReferTogli As OleDbDataAdapter
        daReferTogli = New OleDb.OleDbDataAdapter(sqlReferTogli, con)
        daReferTogli.Fill(ds, refer_Togli)

        Dim cb As New OleDb.OleDbCommandBuilder(daReferTogli)

        Dim numrows As Integer
        numrows = ds.Tables(refer_Togli).Rows.Count - 1


        If MessageBox.Show("Do you really want to delete this Record?", _
        "Delete", MessageBoxButtons.YesNo, _
        MessageBoxIcon.Warning) = DialogResult.No Then
            MsgBox("Operation Cancelled")
            Exit Sub
        Else
            Try
                indiceRiga = Me.DataGridReferences_6.CurrentCell.RowIndex
                ds.Tables(refer_Togli).Rows(indiceRiga).Delete()
                If indiceRiga = 0 Then
                    indiceRiga = 1
                ElseIf indiceRiga > 0 Then
                    indiceRiga = 0
                End If
                daReferTogli.Update(ds, refer_Togli)
                checkTabellaReference()
            Catch
                MsgBox("Problem updating the database. Please close and reopen the " & nomefile & " database!")
            End Try
        End If

        If numrows = -1 Then
            Me.btnDeleteRef.Enabled = False
            Exit Sub
        End If

        'End If
    End Sub
    Sub aggiungiRiga()

        Dim refer_Aggiungi As String
        refer_Aggiungi = "ReferenzeAggiungi"

        Dim sqlReferAggiungi As String
        sqlReferAggiungi = "SELECT * FROM tReferences"

        Dim daReferAggiungi As OleDbDataAdapter
        daReferAggiungi = New OleDb.OleDbDataAdapter(sqlReferAggiungi, con)
        daReferAggiungi.Fill(ds, refer_Aggiungi)

        'CHECK Dummy Primary
        Dim contaRigheReference As Integer
        Dim daReference As New OleDbDataAdapter
        Dim qry_PrimaryReference As String
        Dim Reference As String
        Reference = "Primary_Reference"
        NuovaDummy = MaxRows + 1

        'Try
        qry_PrimaryReference = "SELECT tReferences.DummyPrimary FROM tReferences"
        daReference = New OleDb.OleDbDataAdapter(qry_PrimaryReference, con)
        daReference.Fill(ds, Reference)
        contaRigheReference = ds.Tables(Reference).Rows.Count

        Dim Dummy As Integer
        Dim rigaAttivaReference As Integer

        For rigaAttivaReference = 0 To contaRigheReference - 1
            Dummy = ds.Tables(Reference).Rows(rigaAttivaReference).Item("DummyPrimary")
            If NuovaDummy = Dummy Then
                NuovaDummy = NuovaDummy + 10
            End If
        Next

        If indiceRiga <> -1 Then

            Dim cb As New OleDb.OleDbCommandBuilder(daReferAggiungi)
            Dim dsNewRow As DataRow

            MaxRows = ds.Tables(refer_Aggiungi).Rows.Count
            dsNewRow = ds.Tables(refer_Aggiungi).NewRow()

            dsNewRow.Item("DummyPrimary") = NuovaDummy
            dsNewRow.Item("DocTitle") = NuovoTitolo
            dsNewRow.Item("Author") = NuovoAutore
            dsNewRow.Item("DateRef") = NuovaData

            ds.Tables(refer_Aggiungi).Rows.Add(dsNewRow)
            daReferAggiungi.Update(ds, refer_Aggiungi)

            checkTabellaReference()

        End If

    End Sub

    'Tab 8
    Sub checkTabellaCommenti()

      
        Try
            sqlC = "SELECT * FROM tSiteComments"
            daComments = New OleDb.OleDbDataAdapter(sqlC, con)
            daComments.Fill(ds, Tabella_Commenti)
        Catch
            MsgBox("Table 'Comments' not found")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Tabella_Commenti).Columns.Count

        Dim strNomiCampiC As New Collection
        strNomiCampiC.Add("SiteComments")
        strNomiCampiC.Add("SiteComments1")
        strNomiCampiC.Add("SiteComments2")
        strNomiCampiC.Add("SiteComments3")
        strNomiCampiC.Add("SiteComments4")
        strNomiCampiC.Add("SiteComments5")
        strNomiCampiC.Add("SiteComments6")
        strNomiCampiC.Add("SiteComments7")
        strNomiCampiC.Add("SiteComments8")
        strNomiCampiC.Add("SiteComments9")
        strNomiCampiC.Add("SiteComments10")
        strNomiCampiC.Add("SiteComments11")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiC.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Tabella_Commenti).Columns(intK - 1).ColumnName = strNomiCampiC(intK) Then
                End If
            Next
        Catch
            MsgBox("Fields incomplete " & intK & " - " & strNomiCampiC.Item(intK))
            Exit Sub
        End Try

        LeggiValoriTabellaSiteInformationComments()
        ScriviValoriTabComments()

    End Sub
    Public Sub LeggiValoriTabellaSiteInformationComments()
        Try
            If IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(0)) Then
                Comment1 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(1)) Then
                Comment2 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(2)) Then
                Comment3 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(3)) Then
                Comment4 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(4)) Then
                Comment5 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(5)) Then
                Comment6 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(6)) Then
                Comment7 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(7)) Then
                Comment8 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(8)) Then
                Comment9 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(9)) Then
                Comment10 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(10)) Then
                Comment11 = " "
            ElseIf IsDBNull(ds.Tables(Tabella_Commenti).Rows(0).Item(11)) Then
                Comment12 = " "
            Else
                Comment1 = ds.Tables(Tabella_Commenti).Rows(0).Item(0)
                Comment2 = ds.Tables(Tabella_Commenti).Rows(0).Item(1)
                Comment3 = ds.Tables(Tabella_Commenti).Rows(0).Item(2)
                Comment4 = ds.Tables(Tabella_Commenti).Rows(0).Item(3)
                Comment5 = ds.Tables(Tabella_Commenti).Rows(0).Item(4)
                Comment6 = ds.Tables(Tabella_Commenti).Rows(0).Item(5)
                Comment7 = ds.Tables(Tabella_Commenti).Rows(0).Item(6)
                Comment8 = ds.Tables(Tabella_Commenti).Rows(0).Item(7)
                Comment9 = ds.Tables(Tabella_Commenti).Rows(0).Item(8)
                Comment10 = ds.Tables(Tabella_Commenti).Rows(0).Item(9)
                Comment11 = ds.Tables(Tabella_Commenti).Rows(0).Item(10)
                Comment11 = ds.Tables(Tabella_Commenti).Rows(0).Item(11)
            End If
        Catch
            MsgBox(Err.Description)
        End Try

    End Sub
    Sub ScriviValoriTabComments()
        Comments = Comment1 & Comment2 & Comment3 & Comment4 & Comment5 & Comment6 & Comment7 & Comment8 & Comment9 & Comment10 & Comment11 & Comment12
        Me.txtComments.Text = Comments
    End Sub
    Sub UpdateTabellaComments()

        DividiCommento()

        Dim ComandoUpdateDB As System.Data.OleDb.OleDbCommand
        ComandoUpdateDB = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDB.CommandText = "UPDATE tSiteComments SET SiteComments =" & "'" & Comment1 & "'" & "," & _
                                                                "SiteComments1 = " & " '" & Comment2 & "'" & "," & _
                                                                "SiteComments2 = " & " '" & Comment3 & "'" & "," & _
                                                                "SiteComments3 = " & " '" & Comment4 & "'" & "," & _
                                                                "SiteComments4 = " & " '" & Comment5 & "'" & "," & _
                                                                "SiteComments5 = " & " '" & Comment6 & "'" & "," & _
                                                                "SiteComments6 = " & " '" & Comment7 & "'" & "," & _
                                                                "SiteComments7 = " & " '" & Comment8 & "'" & "," & _
                                                                "SiteComments8 = " & " '" & Comment9 & "'" & "," & _
                                                                "SiteComments9 = " & " '" & Comment10 & "'" & "," & _
                                                                "SiteComments10 = " & " '" & Comment11 & "'" & "," & _
                                                                "SiteComments11 = " & " '" & Comment12 & "'" & " ; "

        ComandoUpdateDB.Connection = con
        Try
            daComments.UpdateCommand = ComandoUpdateDB
            daComments.UpdateCommand.ExecuteNonQuery()
        Catch
            MsgBox(Err.Description)
        End Try

    End Sub

    'Comment is split in several variables due to the limitation of 255 characters of the Access DATABASE
    Sub DividiCommento()
        'Dim OneCharacter As Char
        Dim Testo As String
        Dim lunghezzaTesto As Integer


        Testo = Trim(txtComments.Text)
        lunghezzaTesto = Testo.Length

        Dim numContenitori As Double
        numContenitori = lunghezzaTesto / 250

        If numContenitori <= 1 Then
            Comment1 = Mid(Testo, 1, 250)
        ElseIf numContenitori <= 2 And numContenitori > 1 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
        ElseIf numContenitori <= 3 And numContenitori > 2 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
        ElseIf numContenitori <= 4 And numContenitori > 3 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
        ElseIf numContenitori <= 5 And numContenitori > 4 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
        ElseIf numContenitori <= 6 And numContenitori > 5 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
        ElseIf numContenitori <= 7 And numContenitori > 6 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
            Comment7 = Mid(Testo, 1501, 250)
        ElseIf numContenitori <= 8 And numContenitori > 7 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
            Comment7 = Mid(Testo, 1501, 250)
            Comment8 = Mid(Testo, 1751, 250)
        ElseIf numContenitori <= 9 And numContenitori > 8 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
            Comment7 = Mid(Testo, 1501, 250)
            Comment8 = Mid(Testo, 1751, 250)
            Comment9 = Mid(Testo, 2001, 250)
        ElseIf numContenitori <= 10 And numContenitori > 9 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
            Comment7 = Mid(Testo, 1501, 250)
            Comment8 = Mid(Testo, 1751, 250)
            Comment9 = Mid(Testo, 2001, 250)
            Comment10 = Mid(Testo, 2251, 250)
        ElseIf numContenitori <= 11 And numContenitori > 10 Then
            Comment1 = Mid(Testo, 1, 250)
            Comment2 = Mid(Testo, 251, 250)
            Comment3 = Mid(Testo, 501, 250)
            Comment4 = Mid(Testo, 751, 250)
            Comment5 = Mid(Testo, 1001, 250)
            Comment6 = Mid(Testo, 1251, 250)
            Comment7 = Mid(Testo, 1501, 250)
            Comment8 = Mid(Testo, 1751, 250)
            Comment9 = Mid(Testo, 2001, 250)
            Comment10 = Mid(Testo, 2251, 250)
            Comment11 = Mid(Testo, 2501, 250)
        End If

    End Sub

    'Tab 9
    Sub checkTabellaYour_Details()

        Try
            sqlYD = "SELECT * FROM tYourDetails"
            daYourDetails = New OleDb.OleDbDataAdapter(sqlYD, con)
            daYourDetails.Fill(ds, Your_Details)
        Catch
            MsgBox("Tabella Your Details non trovata")
            Exit Sub
        End Try

        Dim intNumCampiLetti As Integer
        intNumCampiLetti = ds.Tables(Your_Details).Columns.Count

        Dim strNomiCampiYD As New Collection
        strNomiCampiYD.Add("YourName")
        strNomiCampiYD.Add("CompanyName")
        strNomiCampiYD.Add("CompanyAddress1")
        strNomiCampiYD.Add("CompanyAddress2")
        strNomiCampiYD.Add("Town")
        strNomiCampiYD.Add("County")
        strNomiCampiYD.Add("PostCode")
        strNomiCampiYD.Add("CompanyTelNumber")
        strNomiCampiYD.Add("YourExtension")
        strNomiCampiYD.Add("Data_Compilazione")

        Dim intNumCampiAspettati As Integer
        intNumCampiAspettati = CStr(strNomiCampiYD.Count)

        Dim intK As Integer
        Try
            For intK = 1 To intNumCampiAspettati
                If ds.Tables(Your_Details).Columns(intK - 1).ColumnName = strNomiCampiYD(intK) Then
                End If
            Next
        Catch
            MsgBox("Campo " & intK & " - " & strNomiCampiYD.Item(intK) & " non trovato")
            Exit Sub
        End Try

        LeggiValoriTabellaYourDetails()
        ScriviValoriTabYourDetails()

    End Sub
    Public Sub LeggiValoriTabellaYourDetails()

        Try
            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(0)) Then
                YourName = " "
            Else
                YourName = ds.Tables(Your_Details).Rows(0).Item(0)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(1)) Then
                CompanyNameDetails = " "
            Else
                CompanyNameDetails = ds.Tables(Your_Details).Rows(0).Item(1)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(2)) Then
                CompanyAddress1 = " "
            Else
                CompanyAddress1 = ds.Tables(Your_Details).Rows(0).Item(2)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(3)) Then
                CompanyAddress2 = " "
            Else
                CompanyAddress2 = ds.Tables(Your_Details).Rows(0).Item(3)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(4)) Then
                Town = " "
            Else
                Town = ds.Tables(Your_Details).Rows(0).Item(4)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(5)) Then
                County = " "
            Else
                County = ds.Tables(Your_Details).Rows(0).Item(5)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(6)) Then
                PostCode = " "
            Else
                PostCode = ds.Tables(Your_Details).Rows(0).Item(6)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(7)) Then
                CompanyTelNumber = " "
            Else
                CompanyTelNumber = ds.Tables(Your_Details).Rows(0).Item(7)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(8)) Then
                YourExtension = " "
            Else
                YourExtension = ds.Tables(Your_Details).Rows(0).Item(8)
            End If

            If IsDBNull(ds.Tables(Your_Details).Rows(0).Item(9)) Then
                DataCompilazione = "01/01/2007"
            Else
                DataCompilazione = ds.Tables(Your_Details).Rows(0).Item(9)
            End If
        Catch

            YourName = " "
            CompanyNameDetails = " "
            CompanyAddress1 = " "
            CompanyAddress2 = " "
            Town = " "
            County = " "
            PostCode = " "
            CompanyTelNumber = " "
            YourExtension = " "
            DataCompilazione = "01/01/2007"

        End Try

    End Sub
    Sub ScriviValoriTabYourDetails()

        Me.txtYourName_8.Text = YourName
        Me.txtCompanyName_8.Text = CompanyNameDetails
        Me.txtCompanyAddress1_8.Text = CompanyAddress1
        Me.txtCompanyAddress2_8.Text = CompanyAddress2
        Me.txtTown_8.Text = Town
        Me.txtCounty_8.Text = County
        Me.txtPostCode_8.Text = PostCode
        Me.txtCompanyTelNumber_8.Text = CompanyTelNumber
        Me.txtYourExtension_8.Text = YourExtension
        Me.DateTimePicker_8.Text = DataCompilazione

    End Sub
    Sub UpdateTabellaYourDetails()
        Dim ComandoUpdateDB As System.Data.OleDb.OleDbCommand
        ComandoUpdateDB = New System.Data.OleDb.OleDbCommand

        ComandoUpdateDB.CommandText = "UPDATE tYourDetails SET YourName =" & "'" & Me.txtYourName_8.Text & "'" & "," & _
                                                "CompanyName = " & " '" & Me.txtCompanyName_8.Text & "'" & "," & _
                                                "CompanyAddress1 = " & " '" & Me.txtCompanyAddress1_8.Text & "'" & "," & _
                                                "CompanyAddress2 = " & " '" & Me.txtCompanyAddress2_8.Text & "'" & "," & _
                                                "Town = " & " '" & Me.txtTown_8.Text & "'" & "," & _
                                                "County = " & " '" & Me.txtCounty_8.Text & "'" & "," & _
                                                "Postcode = " & " '" & Me.txtPostCode_8.Text & "'" & "," & _
                                                "CompanyTelNumber = " & " '" & Me.txtCompanyTelNumber_8.Text & "'" & "," & _
                                                "YourExtension = " & " '" & Me.txtYourExtension_8.Text & "'" & "," & _
                                                "Data_Compilazione = " & " '" & Me.DateTimePicker_8.Value & "'" & " ; "

        ComandoUpdateDB.Connection = con
        Try
            daYourDetails.UpdateCommand = ComandoUpdateDB
            daYourDetails.UpdateCommand.ExecuteNonQuery()
        Catch
            MessageBox.Show("No database loaded", "Please, load a database", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try
    End Sub

    'Call external FORMS
    '***********************************************************************
    'IS THE DATABASE OPEN?
    Private Sub btnBoundariesShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoundariesShow.Click
        If nomefile = "" Then
            MessageBox.Show("No database loaded", "Please, load a database", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Hide()
        frmBoundaries.Show()

    End Sub
    Private Sub btnTanksShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTanksShow.Click

        If nomefile = "" Then
            MessageBox.Show("No database loaded", "Please, load a database", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Hide()
        frmTanks.Show()
    End Sub
    Private Sub btnBoreholesShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoreholesShow.Click

        If nomefile = "" Then
            MessageBox.Show("No database loaded", "Please, load a database", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Hide()
        frmAbstractionBoreholes.Show()
    End Sub
    Private Sub btnSurfaceDepositsShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSurfaceDepositsShow.Click
        If nomefile = "" Then
            MessageBox.Show("No database loaded", "Please, load a database", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Hide()
        frmSurfaceDeposit.Show()
    End Sub
    Private Sub btnRiskAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRiskAssessment.Click
        If nomefile = "" Then
            MessageBox.Show("No database loaded", "Please, load a database", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Hide()
        frmRiskAssessment.Show()
    End Sub

    'STARTING PRIORITISATION
    Private Sub btnAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssessment.Click

        If nomefile = "" Then
            MsgBox("Please load a database before running the prioritisation", MsgBoxStyle.Critical, "Database not loaded.")
            Exit Sub
        End If

        Me.gpbPathways.Enabled = True
        Me.gpbTargets.Enabled = True
        Me.gpbHazard.Enabled = True
        Me.gpbPrioritise.Enabled = True
        Me.gpbPollutantLinkages.Enabled = True
        Me.gpbDataCheck.Enabled = True

        Check_Boundaries()
        Check_Boreholes()
        Check_SurfaceDeposit()
        Check_Tanks()
        Check_Ref()

        Dim dblHazardTank As Double
        dblHazardTank = Hazards_Tanks()
        If FLAG_HAZARDTANKS = 1 Then
            Me.txtHazardTanks.ForeColor = Color.Red
            Me.txtHazardTanks.Text = dblHazardTank
        Else
            Me.txtHazardTanks.ForeColor = Color.Black
            Me.txtHazardTanks.Text = dblHazardTank
        End If
        Me.txtHazardTanks.Text = dblHazardTank

        Dim dblRunOff_Assessment As Double
        dblRunOff_Assessment = Runoff_AssessmentProcedure()
        Me.txtPathwayAssessment.Text = dblRunOff_Assessment

        Dim dblDrainsPipes_Assessment As Double
        dblDrainsPipes_Assessment = Drains_Pipes()
        Me.txtDrainsPipesAssessment.Text = dblDrainsPipes_Assessment

        Dim dblLateralFlow_Assessment As Double
        dblLateralFlow_Assessment = Lateral_Flow()
        Me.txtLateralFlowAssessment.Text = dblLateralFlow_Assessment

        Dim dblVerticalFlow_Assessment As Double
        dblVerticalFlow_Assessment = Vertical_Flow()
        Me.txtVerticalFlowAssessment.Text = dblVerticalFlow_Assessment

        Dim dblAirborne_Assessment As Double
        dblAirborne_Assessment = Airborne()
        If FLAGAIRBORNE = 1 Then
            Me.txtAirborneAssessment.ForeColor = Color.Red
            Me.txtAirborneAssessment.Text = dblAirborne_Assessment
        Else
            Me.txtAirborneAssessment.ForeColor = Color.Black
            Me.txtAirborneAssessment.Text = dblAirborne_Assessment
        End If

        Dim dblSurface_Water_Rank As Double
        dblSurface_Water_Rank = TARGET_SurfaceWater()
        Me.txtSurfaceWaterRank.Text = dblSurface_Water_Rank

        Dim dblGroundwater_Rank As Double
        dblGroundwater_Rank = TARGET_Groundwater()
        If FLAG_GROUNDWATER = 1 Then
            Me.txtGroundwaterRank.ForeColor = Color.Red
            Me.txtGroundwaterRank.Text = dblGroundwater_Rank
        Else
            Me.txtGroundwaterRank.ForeColor = Color.Black
            Me.txtGroundwaterRank.Text = dblGroundwater_Rank
        End If

        Dim dblEnvironment_Rank As Double
        dblEnvironment_Rank = TARGET_Environment()
        Me.txtEnvironmentRank.Text = dblEnvironment_Rank

        Dim dblOnsiteHumans_Assessment As Double
        dblOnsiteHumans_Assessment = TARGET_OnsiteHumans()
        Me.txtOnsiteHumans_Assessment.Text = dblOnsiteHumans_Assessment

        Dim dblOffsiteHumans_Assessment As Double
        dblOffsiteHumans_Assessment = TARGET_OffsiteHumans()
        Me.txtOffSiteHumansAssessment.Text = dblOffsiteHumans_Assessment

        PollutionEvent()

        Dim dblHTPScore3 As Double
        dblHTPScore3 = PollutantLinkage3()
        Me.txt_HPTScore3.Text = dblHTPScore3

        Dim dblHTPScore4 As Double
        dblHTPScore4 = PollutantLinkage4()
        Me.txt_HPTScore4.Text = dblHTPScore4

        PRIORITISE()

        'WRITING INTO THE MASTER DATABASE
        checkDoppio()

    End Sub

    'Calculating the numbers of BOUNDARIES,TANKS,BOREHOLES,ETC....
    Private Sub Check_Boundaries()

        ds.Clear()
        Dim contaRigheBoundaries As Integer
        Dim daBoundaries As New OleDbDataAdapter
        Dim qry_Boundaries As String

        Try
            qry_Boundaries = "SELECT * FROM tSiteBoundaryInformation"
            daBoundaries = New OleDb.OleDbDataAdapter(qry_Boundaries, con)
            daBoundaries.Fill(ds, "Boundaries")
            contaRigheBoundaries = ds.Tables("Boundaries").Rows.Count
        Catch
            contaRigheBoundaries = 0

        End Try

        Me.txt_CheckBoundaries.Text = contaRigheBoundaries

    End Sub
    Private Sub Check_Boreholes()
        ds.Clear()
        Dim contaRigheBoreholes As Integer
        Dim daBoreholes As New OleDbDataAdapter
        Dim qry_Boreholes As String

        Try
            qry_Boreholes = "SELECT * FROM tAbstractionBoreHoles"
            daBoreholes = New OleDb.OleDbDataAdapter(qry_Boreholes, con)
            daBoreholes.Fill(ds, "Boreholes")
            contaRigheBoreholes = ds.Tables("Boreholes").Rows.Count
        Catch
            contaRigheBoreholes = 0
        End Try

        Me.txt_CheckBoreholes.Text = contaRigheBoreholes


    End Sub
    Private Sub Check_SurfaceDeposit()
        ds.Clear()
        Dim contaRigheSurfaceDeposit As Integer
        Dim daSurfaceDeposit As New OleDbDataAdapter
        Dim qry_SurfaceDeposit As String

        Try
            qry_SurfaceDeposit = "SELECT * FROM tSurfaceDeposit"
            daSurfaceDeposit = New OleDb.OleDbDataAdapter(qry_SurfaceDeposit, con)
            daSurfaceDeposit.Fill(ds, "Surface Deposits")
            contaRigheSurfaceDeposit = ds.Tables("Surface Deposits").Rows.Count
        Catch
            contaRigheSurfaceDeposit = 0

        End Try

        Me.txt_CheckSurfaceDeposits.Text = contaRigheSurfaceDeposit


    End Sub
    Private Sub Check_Tanks()
        ds.Clear()
        Dim contaRigheTanks As Integer
        Dim daTanks As New OleDbDataAdapter
        Dim qry_Tanks As String

        Try
            qry_Tanks = "SELECT * FROM tTankInformation "
            daTanks = New OleDb.OleDbDataAdapter(qry_Tanks, con)
            daTanks.Fill(ds, "Tanks")
            contaRigheTanks = ds.Tables("Tanks").Rows.Count

        Catch
            contaRigheTanks = 0

        End Try

        Me.txt_CheckTanks.Text = contaRigheTanks


    End Sub
    Private Sub Check_Ref()

        ds.Clear()
        Dim numrows As Integer

        Try

            Dim refer_Check As String
            refer_Check = "ReferenzeCheck"

            Dim sqlReferCheck As String
            sqlReferCheck = "SELECT * FROM tReferences"

            Dim daReferTogli As OleDbDataAdapter
            daReferTogli = New OleDb.OleDbDataAdapter(sqlReferCheck, con)
            daReferTogli.Fill(ds, refer_Check)

            Dim cb As New OleDb.OleDbCommandBuilder(daReferTogli)

            numrows = ds.Tables(refer_Check).Rows.Count

        Catch
            MsgBox("Problem reading records from table 'References' ")
        End Try

        Me.txt_CheckReferences.Text = numrows


    End Sub

    '****************HAZARDS**********************
    'Hazards:Tanks NEcessary for Pollutant Linkage 4
    Private Function Hazards_Tanks() As Double

        FLAG_HAZARDTANKS = 0
        ds.Clear()
        'Are all boundaries BARRIER for Airborne
        Dim contaRigheTanks As Integer
        Dim daTanksHazard As New OleDbDataAdapter
        Dim qry_TanksHazard As String
        Dim tabellaTanksHazard As String
        tabellaTanksHazard = "TanksHazard"

        Try
            qry_TanksHazard = "SELECT * FROM tTankInformation"
            daTanksHazard = New OleDb.OleDbDataAdapter(qry_TanksHazard, con)
            daTanksHazard.Fill(ds, tabellaTanksHazard)
            contaRigheTanks = ds.Tables(tabellaTanksHazard).Rows.Count
            'MsgBox(contaRigheTanks)
        Catch
            MsgBox("Problem with table Tanks for hazard calculation. Is the table open or has the database been modified manually?")
        End Try

        If contaRigheTanks = 0 Then
            MsgBox("No information for Tanks entered in database" & Chr(13) & "Assuming worst case scenario for Hazard Tanks", MsgBoxStyle.Critical, "Prioritisation")
            FLAG_HAZARDTANKS = 1
            Hazards_Tanks = 0.3
            Exit Function
        End If

        Dim LocationTank(contaRigheTanks - 1) As String
        Dim SizeTank(contaRigheTanks - 1) As String
        Dim ContentsTank(contaRigheTanks - 1) As String

        Dim ScoreLocationTank(contaRigheTanks - 1), ScoreSizeTank(contaRigheTanks - 1), ScoreContentsTank(contaRigheTanks - 1) As Double
        Dim rigaAttivaTanks As Integer

        'IS the content clean?
        For rigaAttivaTanks = 0 To contaRigheTanks - 1
            ContentsTank(rigaAttivaTanks) = ds.Tables(tabellaTanksHazard).Rows(rigaAttivaTanks).Item("TankContent")
            If ContentsTank(rigaAttivaTanks) IsNot "Clean/Inert Backfill" Then
                If ContentsTank(rigaAttivaTanks) = "Liquid: Tar" Or ContentsTank(rigaAttivaTanks) = "Liquid: Oil" Or ContentsTank(rigaAttivaTanks) = "Liquid: Ammoniacal Liquor" Or ContentsTank(rigaAttivaTanks) = "Liquid: Diesel/Petrol" Or ContentsTank(rigaAttivaTanks) = "Emulsified Tar/Water" Or ContentsTank(rigaAttivaTanks) = "Not known" Or ContentsTank(rigaAttivaTanks) = "Tarry Solid" Then
                    ScoreContentsTank(rigaAttivaTanks) = 1
                ElseIf ContentsTank(rigaAttivaTanks) = "Spent Oxide/Foul Lime" Or ContentsTank(rigaAttivaTanks) = "Clinker/Coal/Coke" Or ContentsTank(rigaAttivaTanks) = "Mixed Solid Wastes" Then
                    ScoreContentsTank(rigaAttivaTanks) = 0.5
                Else
                    ScoreContentsTank(rigaAttivaTanks) = 0
                End If
            End If

            'SUM TANK SIZE
            SizeTank(rigaAttivaTanks) = ds.Tables(tabellaTanksHazard).Rows(rigaAttivaTanks).Item("TankTypeGasHolder")
            If SizeTank(rigaAttivaTanks) = True Then
                ScoreSizeTank(rigaAttivaTanks) = 1
            Else
                SizeTank(rigaAttivaTanks) = ds.Tables(tabellaTanksHazard).Rows(rigaAttivaTanks).Item("TankTypeTankTarWell")
                If SizeTank(rigaAttivaTanks) = False Then
                    MsgBox("Value for tank type not entered")
                End If
                ScoreSizeTank(rigaAttivaTanks) = 0.8
            End If


            'SUM TANK LOCATION
            LocationTank(rigaAttivaTanks) = ds.Tables(tabellaTanksHazard).Rows(rigaAttivaTanks).Item("TankLocationSurface")
            If LocationTank(rigaAttivaTanks) = True Then
                ScoreLocationTank(rigaAttivaTanks) = 0.5
            Else
                LocationTank(rigaAttivaTanks) = ds.Tables(tabellaTanksHazard).Rows(rigaAttivaTanks).Item("TankLocationBuried")
                If SizeTank(rigaAttivaTanks) = False Then
                    MsgBox("Value for tank location not entered")
                End If
                ScoreLocationTank(rigaAttivaTanks) = 1
            End If
        Next


        ' LxSxC for each tank
        Dim LSCRigaAttiva As Integer
        Dim LSCTank(contaRigheTanks - 1) As Double
        Dim TotalTANKHAZ_TankScore As Double
        For LSCRigaAttiva = 0 To contaRigheTanks - 1
            LSCTank(LSCRigaAttiva) = ScoreLocationTank(LSCRigaAttiva) * ScoreSizeTank(LSCRigaAttiva) * ScoreContentsTank(LSCRigaAttiva)
            'MsgBox(LSCTank(LSCRigaAttiva))
            TotalTANKHAZ_TankScore = TotalTANKHAZ_TankScore + LSCTank(LSCRigaAttiva)
        Next


        Dim TANKHAZ_TankScoreA As Double
        TANKHAZ_TankScoreA = ((TotalTANKHAZ_TankScore / (contaRigheTanks))) * 0.7


        Dim TANKHAZ_TankScoreB As Double
        TANKHAZ_TankScoreB = (contaRigheTanks) / 50

        If TANKHAZ_TankScoreB > 0.3 Then
            TANKHAZ_TankScoreB = 0.3
        End If

        TANKHAZ_SiteTankScore = TANKHAZ_TankScoreA + TANKHAZ_TankScoreB
        Hazards_Tanks = TANKHAZ_SiteTankScore

    End Function

    '****************PATHWAYS**********************
    'Pathway Assessment
    Private Function Runoff_AssessmentProcedure() As Double

        If blnSRO_CrssBoundContam = True Then
            Runoff_AssessmentProcedure = 1
            Exit Function
        End If
        'MsgBox("blnSRO_CrssBoundContam=" = blnSRO_CrssBoundContam.ToString)

        Dim intSommaNonHardstanding As Integer
        intSommaNonHardstanding = intCovExpSoil + intCovVeg + intCovGravel
        'MsgBox(intSommaNonHardstanding)

        Dim intSommaHardstanding As Integer
        intSommaHardstanding = intCovBuildStruct + intCovHardstand

        Dim step1 As String
        If intSommaNonHardstanding < intSommaHardstanding Or blnFloodHistYes = True Or blnStandHistYes = True Then
            step1 = "Yes"
        Else
            step1 = "No"
        End If

        Dim step2 As String
        If strSiteGradient = "Sloped" Or strSiteGradient = "Embanked" Or strSiteGradient = "Terraced" Then
            step2 = "Yes"
        Else
            step2 = "No"
        End If

        'Check if the boundary is a barrier 
        Dim BarrierRunOffDownGradient As Boolean
        Dim qry_RunOffDownGradient As String
        Dim daBoundariesRunOff As New OleDbDataAdapter
        Dim Site_Boundaries As String
        Site_Boundaries = "Site_Boundaries"

        Try
            qry_RunOffDownGradient = "SELECT tSiteBoundaryInformation.BoundaryConstr,tSiteBoundaryInformation.BarrierRUN_OFF FROM tSiteBoundaryInformation WHERE FacingDirection ='" & strDirectionSlope & "'"
            daBoundariesRunOff = New OleDb.OleDbDataAdapter(qry_RunOffDownGradient, con)
            daBoundariesRunOff.Fill(ds, Site_Boundaries)
            BarrierRunOffDownGradient = ds.Tables(Site_Boundaries).Rows(0).Item("BarrierRUN_OFF")
            'MsgBox(BarrierRunOffDownGradient)
        Catch
            'MsgBox("No information of barriers to run-off for downgradient slope")
        End Try


        Dim step3 As String
        If BarrierRunOffDownGradient = False Then
            step3 = "No"
        Else
            step3 = "Yes"
        End If

        'ARE ALL BOUNDARIES A BARRIER?
        Dim contaBarriere As Integer = 0
        Dim contaRighe As Integer = 0
        Dim tuttiBarrierRunOffDownGradient As Boolean
        Dim qry_RunOffDownGradientTutti As String
        Dim Site_Boundaries_Tutti As String
        Site_Boundaries_Tutti = "Site_Boundaries_Tutti"
        Try
            qry_RunOffDownGradientTutti = "SELECT tSiteBoundaryInformation.BarrierRUN_OFF FROM tSiteBoundaryInformation"
            daBoundariesRunOff = New OleDb.OleDbDataAdapter(qry_RunOffDownGradientTutti, con)
            daBoundariesRunOff.Fill(ds, Site_Boundaries_Tutti)
            contaRighe = ds.Tables(Site_Boundaries_Tutti).Rows.Count
            Dim rigaAttiva As Integer
            For rigaAttiva = 0 To contaRighe - 1
                tuttiBarrierRunOffDownGradient = ds.Tables(Site_Boundaries_Tutti).Rows(rigaAttiva).Item("BarrierRUN_OFF")
                If tuttiBarrierRunOffDownGradient = True Then
                    contaBarriere = contaBarriere + 1

                End If
            Next rigaAttiva
        Catch
            MsgBox("Problem calculating Runoff Pathway Assessment Procedure")
        End Try

        If contaRighe = 0 Then
            MsgBox("No information for 'Site Boundaries' entered in database" & Chr(13) & "It's impossible to rank Pathway:Run-off", MsgBoxStyle.Critical, "Stopping calculation......")
            Exit Function
        End If


        Dim step4 As String
        If contaBarriere <> contaRighe Then
            step4 = "No"
            'MsgBox("Not all barriers to Run-Off")
        Else
            step4 = "Yes"
            'MsgBox("All barriers Run-Off")
        End If

        '**********************************************
        'Decisioni
        '**********************************************

        'Step 1 "YES"
        If step1 = "Yes" And step2 = "Yes" And step3 = "No" Then
            Runoff_AssessmentProcedure = 1
        End If

        If step1 = "Yes" And step2 = "Yes" And step3 = "Yes" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "Yes" And step2 = "No" And step3 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "Yes" And step2 = "No" And step4 = "Yes" Then
            Runoff_AssessmentProcedure = 0.5
        End If

        If step1 = "Yes" And step2 = "No" And step4 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        'Step 1 "NO"
        If step1 = "No" And step2 = "No" And step3 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "No" And step2 = "No" And step4 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "No" And step2 = "No" And step4 = "Yes" Then
            Runoff_AssessmentProcedure = 0.5
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "Yes" Then
            Runoff_AssessmentProcedure = 0.5
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "No" Then
            Runoff_AssessmentProcedure = 0.75
        End If


    End Function
    'Drains Pipes
    Private Function Drains_Pipes() As Double

        'Dim intDrainsPipes_Assessment As Integer

        'Known cross-boundary=YES and Remedial measure=NO
        Dim step1 As String
        If blnDP_CrssBoundContam = True And blnDP_Addressed = False Then
            Drains_Pipes = 1
            Exit Function
        Else : step1 = "No"
        End If

        Dim step2 As String
        If blnDP_KnwnPath = True Then
            step2 = "Yes"
        Else
            step2 = "No"
        End If

        Dim step3 As String
        If GasSer = True Or ElectricSer = True Or WaterSer = True Or TelecomSer = True Or SewersSer = True Then
            step3 = "Yes"
        Else
            step3 = "No"
        End If

        '**********************************************
        'Decisioni
        '**********************************************
        'Step 2 
        If step1 = "No" And step2 = "Yes" Then
            Drains_Pipes = 1
        End If

        If step1 = "No" And step2 = "No" And step3 = "Yes" Then
            Drains_Pipes = 1
        End If

        If step1 = "No" And step2 = "No" And step3 = "No" Then
            Drains_Pipes = 0.5
        End If

    End Function
    'Lateral Flows
    Private Function Lateral_Flow() As Double

        Dim step1 As String
        If blnLF_KnwnPath = True Then
            step1 = "Yes"
        Else : step1 = "No"
        End If

        Dim step2 As String
        If strLF_ActionTaken = "Barrier Wall" Then
            step2 = "yes"
        Else
            step2 = "No"
        End If

        Dim step3 As String
        If PerchedWT = "Present (known from SI)" Or PerchedWT = "Suspected (Desk Study)" Then
            step3 = "Yes"
        Else
            step3 = "No"
        End If

        Dim step4 As String
        If MadeGroundPresent = True Or SupDepPresent = True Then
            step4 = "Yes"
        Else
            step4 = "No"
        End If

        '**********************************************
        'Decisioni
        '**********************************************
        If step1 = "Yes" And step2 = "No" Then
            Lateral_Flow = 1
        End If

        If step1 = "Yes" And step2 = "Yes" Then
            Lateral_Flow = 0.5
        End If

        If step1 = "No" And step2 = "No" And step3 = "No" Then
            Lateral_Flow = 0.5
        End If

        If step1 = "No" And step2 = "No" And step3 = "Yes" Then
            Lateral_Flow = 0.75
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "No" Then
            Lateral_Flow = 0.75
        End If

        If step1 = "No" And step2 = "Yes" And step3 = "Yes" Then
            Lateral_Flow = 1
        End If

    End Function
    'Lateral Flows
    Private Function Vertical_Flow() As Double

        Dim step1 As String
        If blnVF_KnwnPath = True Then
            Vertical_Flow = 1
            Exit Function
        Else : step1 = "No"
        End If

        Dim step2 As String
        If AquiVul = "High" Then
            step2 = "HIGH"
        ElseIf AquiVul = "Medium" Then
            step2 = "MEDIUM"
        ElseIf AquiVul = "Low" Then
            step2 = "LOW"
        Else
            step2 = "LOW"
        End If

        Dim step3 As String
        If blnVC_KnwnPath = True Then
            step3 = "Yes"
        Else
            step3 = "No"
        End If

        Dim step4 As String
        If blnVC_Sealed = True Then
            step4 = "Yes"
        Else
            step4 = "No"
        End If

        '**********************************************
        'Decisioni
        '**********************************************
        If step1 = "No" And step2 = "HIGH" Then
            Vertical_Flow = 1
        End If

        If step1 = "No" And step2 = "MEDIUM" And step3 = "No" Then
            Vertical_Flow = 0.75
        End If

        If step1 = "No" And step2 = "MEDIUM" And step3 = "Yes" And step4 = "No" Then
            Vertical_Flow = 1
        End If

        If step1 = "No" And step2 = "MEDIUM" And step3 = "Yes" And step4 = "Yes" Then
            Vertical_Flow = 0.75
        End If

        If step1 = "No" And step2 = "LOW" And step3 = "No" Then
            Vertical_Flow = 0.5
        End If

        If step1 = "No" And step2 = "LOW" And step3 = "Yes" And step4 = "No" Then
            Vertical_Flow = 0.75
        End If

        If step1 = "No" And step2 = "LOW" And step3 = "Yes" And step4 = "Yes" Then
            Vertical_Flow = 0.5
        End If


    End Function
    'Airborne
    Private Function Airborne() As Double

        FLAGAIRBORNE = 0
        Dim step1 As String
        If blnAirB_KnwnPath = True Then
            step1 = "Yes"
        Else
            step1 = "No"
        End If

        Dim step2 As String
        If strAirB_ActionTaken = "Barrier" Then
            step2 = "Yes"
        Else
            step2 = "No"
        End If

        'Controllo se tutti i confini sono una barriera per Airborne
        Dim contaBarriere As Integer
        Dim contaRighe As Integer
        Dim daBoundariesAirBorne As New OleDbDataAdapter
        Dim tuttiBarrierAirBorne As Boolean
        Dim qry_AirBorneBarrierTutti As String
        Dim Site_Boundaries_Tutti_AirBorne As String
        Site_Boundaries_Tutti_AirBorne = "Site_Boundaries_Tutti_AirBorne"
        Try
            qry_AirBorneBarrierTutti = "SELECT tSiteBoundaryInformation.BarrierAIRBORNE_DUST FROM tSiteBoundaryInformation"
            daBoundariesAirBorne = New OleDb.OleDbDataAdapter(qry_AirBorneBarrierTutti, con)
            daBoundariesAirBorne.Fill(ds, Site_Boundaries_Tutti_AirBorne)
            contaRighe = ds.Tables(Site_Boundaries_Tutti_AirBorne).Rows.Count
            'MsgBox("Righe Boundaries for Airborne=" & contaRighe)
            Dim rigaAttiva As Integer
            For rigaAttiva = 0 To contaRighe - 1
                tuttiBarrierAirBorne = ds.Tables(Site_Boundaries_Tutti_AirBorne).Rows(rigaAttiva).Item("BarrierAIRBORNE_DUST")
                If tuttiBarrierAirBorne = True Then
                    contaBarriere = contaBarriere + 1
                End If
            Next rigaAttiva
            'MsgBox("Barriere=" & contaBarriere)
        Catch
            MsgBox("Problem Airborne")
        End Try

        Dim step3 As String
        If contaBarriere <> contaRighe Then
            step3 = "No"
            'MsgBox("Not all barriers to AirBorne")
        Else
            step3 = "Yes"
            'MsgBox("All barriers Run-AirBorne")
        End If

        'Controllo se i depositi siperficiali "Superficial Deposit" possono essere mobilizzati dal vento
        Dim contaDepositMobilisedWind As Integer
        Dim contaRigheDepositMobilisedWind As Integer
        Dim daDepositMobilisedWind As New OleDbDataAdapter

        Dim tuttiDepositMobilisedWind As Boolean
        Dim qry_DepositMobilisedWindTutti As String
        Dim DepositsMobilisedbyWind As String
        DepositsMobilisedbyWind = "DepositsMobilisedbyWind"
        Try
            qry_DepositMobilisedWindTutti = "SELECT tSurfaceDeposit.SUDDepoMobilYES FROM tSurfaceDeposit"
            daDepositMobilisedWind = New OleDb.OleDbDataAdapter(qry_DepositMobilisedWindTutti, con)
            daDepositMobilisedWind.Fill(ds, DepositsMobilisedbyWind)
            contaRigheDepositMobilisedWind = ds.Tables(DepositsMobilisedbyWind).Rows.Count
            'MsgBox("Righe Surface Deposit=" & contaRigheDepositMobilisedWind)
            Dim rigaAttivaDeposit As Integer
            For rigaAttivaDeposit = 0 To contaRigheDepositMobilisedWind - 1
                tuttiDepositMobilisedWind = ds.Tables(DepositsMobilisedbyWind).Rows(rigaAttivaDeposit).Item("SUDDepoMobilYES")
                If tuttiDepositMobilisedWind = True Then
                    contaDepositMobilisedWind = contaDepositMobilisedWind + 1
                End If
            Next rigaAttivaDeposit
            'MsgBox("Barriere=" & contaBarriere)
        Catch
            MsgBox("Problem reading values for Pathways:Airborne")
        End Try

        If contaRigheDepositMobilisedWind = 0 Then
            FLAGAIRBORNE = 1
            MsgBox("No information for 'Surface Deposit' entered in database" & Chr(13) & "Assuming worst case scenario to rank Pathways:Airborne", MsgBoxStyle.Critical, "Prioritisation")
            Airborne = 1
            Exit Function
        End If

        Dim step4 As String
        If contaDepositMobilisedWind <> contaRigheDepositMobilisedWind Then
            step4 = "No"
            'MsgBox("Not all barriers to Wind")
        Else
            step4 = "Yes"
            'MsgBox("All barriers Wind")
        End If

        '**********************************************
        'Decisioni
        '**********************************************
        If step1 = "Yes" And step2 = "Yes" Then
            Airborne = 0.5
        End If

        If step1 = "Yes" And step2 = "No" Then
            Airborne = 1
        End If

        If step1 = "No" And step3 = "No" Then
            Airborne = 1
        End If

        If step1 = "No" And step3 = "Yes" And step4 = "Yes" Then
            Airborne = 0.75
        End If

        If step1 = "No" And step3 = "Yes" And step4 = "No" Then
            Airborne = 0.5
        End If

    End Function

    '****************TARGETS**********************
    'Surface Waters
    Private Function TARGET_SurfaceWater() As Double

        'Distanza prima Surface Water
        Dim step1_1 As Double
        If dblWBDistSite1 > 0 And dblWBDistSite1 <= 500 Then
            step1_1 = 0.2
        ElseIf dblWBDistSite1 > 590 And dblWBDistSite1 <= 1000 Then
            step1_1 = 0.1
        ElseIf dblWBDistSite1 > 1000 Then
            step1_1 = 0
        Else
            step1_1 = 0
        End If

        'Distanza seconda Surface Water
        Dim step1_2 As Double
        If dblWBDistSite2 > 0 And dblWBDistSite2 <= 500 Then
            step1_2 = 0.2
        ElseIf dblWBDistSite2 > 500 And dblWBDistSite2 <= 1000 Then
            step1_2 = 0.1
        ElseIf dblWBDistSite2 > 1000 Then
            step1_2 = 0
        Else
            step1_2 = 0
        End If

        'Distanza terza Surface Water
        Dim step1_3 As Double
        If dblWBDistSite3 > 0 And dblWBDistSite3 <= 500 Then
            step1_3 = 0.2
        ElseIf dblWBDistSite3 > 500 And dblWBDistSite3 <= 1000 Then
            step1_3 = 0.1
        ElseIf dblWBDistSite3 > 1000 Then
            step1_3 = 0
        Else
            step1_3 = 0
        End If

        'Calcolo valore DISTANCE TO SURFACE WATER
        Dim valStep1 As Double
        valStep1 = step1_1 + step1_2 + step1_3
        'MsgBox("Distances " & valStep1)

        'Qualita prima Surface Water
        Dim step2_1 As Double
        If strExistGQAWatQual1 = "Good" Or strExistGQAWatQual1 = "Fair" Then
            step2_1 = 0.2
        ElseIf strExistGQAWatQual1 = "Poor" Or strExistGQAWatQual1 = "Unclassified" Then
            step2_1 = 0.1
        ElseIf strExistGQAWatQual1 = "Bad" Then
            step2_1 = 0
        Else
            step2_1 = 0
        End If

        'Qualita prima Surface Water
        Dim step2_2 As Double
        If strExistGQAWatQual2 = "Good" Or strExistGQAWatQual2 = "Fair" Then
            step2_2 = 0.2
        ElseIf strExistGQAWatQual2 = "Poor" Or strExistGQAWatQual2 = "Unclassified" Then
            step2_2 = 0.1
        ElseIf strExistGQAWatQual2 = "Bad" Then
            step2_2 = 0
        Else
            step2_2 = 0
        End If

        'Qualita prima Surface Water
        Dim step2_3 As Double
        If strExistGQAWatQual3 = "Good" Or strExistGQAWatQual3 = "Fair" Then
            step2_3 = 0.2
        ElseIf strExistGQAWatQual3 = "Poor" Or strExistGQAWatQual3 = "Unclassified" Then
            step2_3 = 0.1
        ElseIf strExistGQAWatQual3 = "Bad" Then
            step2_3 = 0
        Else
            step2_3 = 0
        End If

        'Calcolo valore EXISTING WATER QUALITY
        Dim valStep2 As Double
        valStep2 = step2_1 + step2_2 + step2_3
        'MsgBox("Water Quality " & valStep2)

        'Attenuation capacity prima Surface Water
        Dim step3_1 As Double
        If strFlowRate1 = "0 - 2.5 CuM/Sec" Or strFlowRate1 = "Unclassified" Then
            step3_1 = 0.2
        ElseIf strFlowRate1 = "2.5 - 10 CuM/Sec" Then
            step3_1 = 0.15
        ElseIf strFlowRate1 = "10 - 40 CuM/Sec" Then
            step3_1 = 0.1
        ElseIf strFlowRate1 = "40 - 80 CuM/Sec" Then
            step3_1 = 0
        Else
            step3_1 = 0
        End If


        'Attenuation capacity seconda Surface Water
        Dim step3_2 As Double
        If strFlowRate2 = "0 - 2.5 CuM/Sec" Or strFlowRate2 = "Unclassified" Then
            step3_2 = 0.2
        ElseIf strFlowRate2 = "2.5 - 10 CuM/Sec" Then
            step3_2 = 0.15
        ElseIf strFlowRate2 = "10 - 40 CuM/Sec" Then
            step3_2 = 0.1
        ElseIf strFlowRate2 = "40 - 80 CuM/Sec" Then
            step3_2 = 0
        Else
            step3_2 = 0
        End If


        'Attenuation capacity terza Surface Water
        Dim step3_3 As Double
        If strFlowRate3 = "0 - 2.5 CuM/Sec" Or strFlowRate3 = "Unclassified" Then
            step3_3 = 0.2
        ElseIf strFlowRate3 = "2.5 - 10 CuM/Sec" Then
            step3_3 = 0.15
        ElseIf strFlowRate3 = "10 - 40 CuM/Sec" Then
            step3_3 = 0.1
        ElseIf strFlowRate2 = "40 - 80 CuM/Sec" Then
            step3_3 = 0
        Else
            step3_3 = 0
        End If

        'Calcolo valore EXISTING WATER QUALITY
        Dim valStep3 As Double
        valStep3 = step3_1 + step3_2 + step3_3
        'MsgBox("Flow Rates " & valStep3)

        Dim D As Double
        D = valStep1 + valStep2 + valStep3

        Dim E As Double
        If D > 0.6 Then
            E = 0.6
        ElseIf D <= 0.6 Then
            E = D
        End If

        Dim F As Double
        If blnSWuse = True Then
            F = 0.4
        ElseIf blnSWuseNo = True Or blnSWuseNK = True Then
            F = 0
        End If

        Dim G As Double
        G = E + F
        TARGET_SurfaceWater = G

    End Function
    'Groundwater
    Private Function TARGET_Groundwater() As Double

        FLAG_GROUNDWATER = 0

        ds.Clear()

        'Distanza prima Surface Water
        Dim step1 As Double
        If SPZ = True Or SPZNK = True Then
            step1 = 0.5
        ElseIf SPZNo = True Then
            step1 = 0
        Else
            step1 = 0
        End If

        'Estraggo valori di Volume e Uso per ogni Borehole
        Dim contaRigheTabBorehole As Integer
        Dim daBoreholes As New OleDbDataAdapter
        Dim qry_Volume_Use_Boreholes As String
        Dim Boreholes As String
        Boreholes = "Boreholes_Vol_Use"

        Try
            qry_Volume_Use_Boreholes = "SELECT tAbstractionBoreHoles.ABHEndUse,tAbstractionBoreHoles.ABHVolumeAbstracted FROM tAbstractionBoreHoles"
            daBoreholes = New OleDb.OleDbDataAdapter(qry_Volume_Use_Boreholes, con)
            daBoreholes.Fill(ds, Boreholes)
            contaRigheTabBorehole = ds.Tables(Boreholes).Rows.Count
            'MsgBox("Righe Boreholes= " & contaRigheTabBorehole)
        Catch ex As Exception
            MsgBox("No values for 'Abstraction' and 'Volume' from database" & Chr(13) & "Have you entered those values?", MsgBoxStyle.Information, )
        End Try

        If contaRigheTabBorehole = 0 Then
            FLAG_GROUNDWATER = 1
            MsgBox("No information for Boreholes entered in database" & Chr(13) & "Assuming worst case scenario for Target Groundwater", MsgBoxStyle.Critical, "Prioritisation")
            TARGET_Groundwater = 1
            Exit Function
        End If

        Dim volXuso(contaRigheTabBorehole) As Double

        Dim rigaAttivaBoreholes As Integer
        Dim Volume, Uso As String
        Dim VolumeRank, UsoRank As Double
        Try
            For rigaAttivaBoreholes = 0 To contaRigheTabBorehole - 1
                Volume = ds.Tables(Boreholes).Rows(rigaAttivaBoreholes).Item("ABHVolumeAbstracted")
                'MsgBox(Volume)
                If Volume = "> 2" Then
                    VolumeRank = 1
                ElseIf Volume = "0.5 - 2.0" Then
                    VolumeRank = 0.9
                ElseIf Volume = "0.2 - 0.5" Then
                    VolumeRank = 0.3
                ElseIf Volume = "0.05 - 0.2" Then
                    VolumeRank = 0.2
                ElseIf Volume = "< 0.05" Then
                    VolumeRank = 0.1
                ElseIf Volume = "Not known" Then
                    VolumeRank = 1
                Else
                    VolumeRank = 0
                End If

                Uso = ds.Tables(Boreholes).Rows(rigaAttivaBoreholes).Item("ABHEndUse")
                'MsgBox(Uso)
                If Uso = "Public Water Supply" Then
                    UsoRank = 1
                ElseIf Uso = "Other" Then
                    UsoRank = 0.1
                ElseIf Uso = "Agriculture" Or Uso = "Domestic/Agriculture" Then
                    UsoRank = 0.2
                ElseIf Uso = "Industrial" Then
                    UsoRank = 0.1
                ElseIf Uso = "Food Processing" Or Uso = "Brewing" Then
                    UsoRank = 1
                ElseIf Uso = "Not known" Then
                    UsoRank = 1
                ElseIf Uso = "Private Potable" Then
                    UsoRank = 1
                ElseIf Uso = "Not known (not PWS)" Then
                    UsoRank = 0.1
                Else
                    UsoRank = 0
                End If
                volXuso(rigaAttivaBoreholes) = VolumeRank * UsoRank
            Next rigaAttivaBoreholes
        Catch
            Exit Function
        End Try

        Dim totalVolXUso As Double
        Dim listaValori As Integer
        For listaValori = 0 To contaRigheTabBorehole - 1
            totalVolXUso = totalVolXUso + volXuso(listaValori)
        Next
        'MsgBox(totalVolXUso)

        Dim UnadjustedBoreholeScore As Double
        UnadjustedBoreholeScore = totalVolXUso / 4

        'MsgBox(UnadjustedBoreholeScore)

        If UnadjustedBoreholeScore > 0.5 Then
            TARGET_Groundwater = 0.5
        Else
            TARGET_Groundwater = UnadjustedBoreholeScore
        End If

    End Function
    'Environment
    Private Function TARGET_Environment() As Double

        'Distances from Sensitive Environmental Target in Surface Water & Environment
        Dim step1 As Double
        'If dblTTDistSite1 = "" Then
        'step1 = 0
        If dblTTDistSite1 = 0 Then
            step1 = 1
        ElseIf dblTTDistSite1 > 0 And dblTTDistSite1 <= 100 Then
            step1 = 0.9
        ElseIf dblTTDistSite1 > 100 And dblTTDistSite1 <= 200 Then
            step1 = 0.8
        ElseIf dblTTDistSite1 > 200 And dblTTDistSite1 <= 300 Then
            step1 = 0.7
        ElseIf dblTTDistSite1 > 300 And dblTTDistSite1 <= 400 Then
            step1 = 0.6
        ElseIf dblTTDistSite1 > 400 And dblTTDistSite1 <= 500 Then
            step1 = 0.5
        ElseIf dblTTDistSite1 > 500 And dblTTDistSite1 <= 600 Then
            step1 = 0.4
        ElseIf dblTTDistSite1 > 600 And dblTTDistSite1 <= 700 Then
            step1 = 0.3
        ElseIf dblTTDistSite1 > 700 And dblTTDistSite1 <= 800 Then
            step1 = 0.2
        ElseIf dblTTDistSite1 > 800 And dblTTDistSite1 <= 1000 Then
            step1 = 0.1
        Else
            step1 = 0
        End If

        'Distanza seconda Sensitive Environmentla Target in Surface Water & Environment
        Dim step2 As Double
        'If dblTTDistSite2 = "" Then
        'step2 = 0
        If dblTTDistSite2 = 0 Then
            step2 = 1
        ElseIf dblTTDistSite2 > 0 And dblTTDistSite2 <= 100 Then
            step2 = 0.9
        ElseIf dblTTDistSite2 > 100 And dblTTDistSite2 <= 200 Then
            step2 = 0.8
        ElseIf dblTTDistSite2 > 200 And dblTTDistSite2 <= 300 Then
            step2 = 0.7
        ElseIf dblTTDistSite2 > 300 And dblTTDistSite2 <= 400 Then
            step2 = 0.6
        ElseIf dblTTDistSite2 > 400 And dblTTDistSite2 <= 500 Then
            step2 = 0.5
        ElseIf dblTTDistSite2 > 500 And dblTTDistSite2 <= 600 Then
            step2 = 0.4
        ElseIf dblTTDistSite2 > 600 And dblTTDistSite2 <= 700 Then
            step2 = 0.3
        ElseIf dblTTDistSite2 > 700 And dblTTDistSite2 <= 800 Then
            step2 = 0.2
        ElseIf dblTTDistSite2 > 800 And dblTTDistSite2 <= 1000 Then
            step2 = 0.1
        Else
            step2 = 0
        End If

        'Distanza terza Sensitive Environmentla Target in Surface Water & Environment
        Dim step3 As Double
        'If dblTTDistSite3 = "" Then
        'step3 = 0
        If dblTTDistSite3 = 0 Then
            step3 = 1
        ElseIf dblTTDistSite3 > 0 And dblTTDistSite3 <= 100 Then
            step3 = 0.9
        ElseIf dblTTDistSite3 > 100 And dblTTDistSite3 <= 200 Then
            step3 = 0.8
        ElseIf dblTTDistSite3 > 200 And dblTTDistSite3 <= 300 Then
            step3 = 0.7
        ElseIf dblTTDistSite3 > 300 And dblTTDistSite3 <= 400 Then
            step3 = 0.6
        ElseIf dblTTDistSite3 > 400 And dblTTDistSite3 <= 500 Then
            step3 = 0.5
        ElseIf dblTTDistSite3 > 500 And dblTTDistSite3 <= 600 Then
            step3 = 0.4
        ElseIf dblTTDistSite3 > 600 And dblTTDistSite3 <= 700 Then
            step3 = 0.3
        ElseIf dblTTDistSite3 > 700 And dblTTDistSite3 <= 800 Then
            step3 = 0.2
        ElseIf dblTTDistSite3 > 800 And dblTTDistSite3 <= 1000 Then
            step3 = 0.1
        Else
            step3 = 0
        End If

        Dim MediaEnvironment As Double
        MediaEnvironment = (step1 + step2 + step3) / 3

        TARGET_Environment = MediaEnvironment

    End Function
    'Off-site Humans
    Private Function TARGET_OffsiteHumans() As Double

        ds.Clear()
        'Controllo se tutti i confini sono una barriera per Airborne
        Dim contaRigheSurroundingBoundaries As Integer
        Dim daBoundariesSurroundingBoundaries As New OleDbDataAdapter
        Dim qry_SurroundingBoundariesTutti As String
        Dim Site_Boundaries_SurroundingLandUse As String
        Site_Boundaries_SurroundingLandUse = "SurroundingLandUse"


        Try
            qry_SurroundingBoundariesTutti = "SELECT * FROM tSiteBoundaryInformation"
            daBoundariesSurroundingBoundaries = New OleDb.OleDbDataAdapter(qry_SurroundingBoundariesTutti, con)
            daBoundariesSurroundingBoundaries.Fill(ds, Site_Boundaries_SurroundingLandUse)
            contaRigheSurroundingBoundaries = ds.Tables(Site_Boundaries_SurroundingLandUse).Rows.Count
            'MsgBox(contaRigheSurroundingBoundaries)
        Catch
            MsgBox("Problem with Off-site Humans data")
        End Try

        Dim LandUseAdjacent(contaRigheSurroundingBoundaries - 1) As String
        Dim LandUseProximal(contaRigheSurroundingBoundaries - 1) As String

        Dim totalRankAdjacent, totalRankProximal As Integer
        Dim rankAdjacent(contaRigheSurroundingBoundaries - 1) As Integer
        Dim rankProximal(contaRigheSurroundingBoundaries - 1) As Integer
        Dim rigaAttivaSurroundingLandUse As Integer
        For rigaAttivaSurroundingLandUse = 0 To contaRigheSurroundingBoundaries - 1
            If IsDBNull(ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("Adjacent")) Then
                LandUseAdjacent(rigaAttivaSurroundingLandUse) = " "
            Else
                LandUseAdjacent(rigaAttivaSurroundingLandUse) = ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("Adjacent")
                'MsgBox("Adjacent= " & LandUseAdjacent(rigaAttivaSurroundingLandUse) & "/  Proximal=" & LandUseProximal(rigaAttivaSurroundingLandUse))
                If LandUseAdjacent(rigaAttivaSurroundingLandUse) <> "Other" Then
                    If LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Office/Retail" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Brewing" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Car park/Open Yard" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Residential" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "School/Nursery" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Hospital" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Allotments" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Recreational" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Animal Sanctuary" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Road/Pathway" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Derelict/Unused" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Water" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "BG Site/Gasworks" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 0
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Livestock" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Industrial" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Food Processing" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf LandUseAdjacent(rigaAttivaSurroundingLandUse) = "Not known" Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    Else
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 0
                    End If
                Else
                    If ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("HumanSensitivityAdjLOW") = True Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 0
                    ElseIf ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("HumanSensitivityAdjMEDIUM") = True Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 2
                    ElseIf ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("HumanSensitivityAdjHIGH") = True Then
                        rankAdjacent(rigaAttivaSurroundingLandUse) = 4
                    End If
                End If
            End If

            totalRankAdjacent = totalRankAdjacent + rankAdjacent(rigaAttivaSurroundingLandUse)

            If IsDBNull(ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("Proximal")) Then
                LandUseProximal(rigaAttivaSurroundingLandUse) = " "
            Else
                LandUseProximal(rigaAttivaSurroundingLandUse) = ds.Tables(Site_Boundaries_SurroundingLandUse).Rows(rigaAttivaSurroundingLandUse).Item("Proximal")
                If LandUseProximal(rigaAttivaSurroundingLandUse) = "Office/Retail" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Brewing" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Car park/Open Yard" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Residential" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "School/Nursery" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Hospital" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Allotments" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Recreational" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Animal Sanctuary" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Road/Pathway" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Derelict/Unused" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Water" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "BG Site/Gasworks" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 0
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Livestock" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 2
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Industrial" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Food Processing" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                ElseIf LandUseProximal(rigaAttivaSurroundingLandUse) = "Not known" Then
                    rankProximal(rigaAttivaSurroundingLandUse) = 1
                Else
                    rankProximal(rigaAttivaSurroundingLandUse) = 0
                End If
            End If
            totalRankProximal = totalRankProximal + rankProximal(rigaAttivaSurroundingLandUse)
        Next rigaAttivaSurroundingLandUse

        'MsgBox("Total Adjacent= " & totalRankAdjacent & "/  Total Proximal=" & totalRankProximal)

        Dim sum2SubTotals As Integer
        sum2SubTotals = totalRankAdjacent + totalRankProximal

        Dim Max As Integer
        Max = contaRigheSurroundingBoundaries * 4
        'MsgBox(Max)

        If (sum2SubTotals / Max) > 1 Then
            TARGET_OffsiteHumans = 1
        Else
            TARGET_OffsiteHumans = sum2SubTotals / Max
        End If


    End Function
    'On-site humans
    Private Function TARGET_OnsiteHumans() As Double

        ds.Clear()

        'Controllo se tutti i confini sono una barriera per Airborne
        Dim contaBarriereTrespassing As Integer
        Dim contaRigheTrespassing As Integer
        Dim daBoundariesTrespassing As New OleDbDataAdapter
        Dim tuttiBarrierTrespassing As Boolean
        Dim qry_TrespassingBarrierTutti As String
        Dim Site_Boundaries_Tutti_Trespassing As String
        Site_Boundaries_Tutti_Trespassing = "Site_Boundaries_Tutti_Trespassing"
        Try
            qry_TrespassingBarrierTutti = "SELECT tSiteBoundaryInformation.BarrierTRESPASSING FROM tSiteBoundaryInformation"
            daBoundariesTrespassing = New OleDb.OleDbDataAdapter(qry_TrespassingBarrierTutti, con)
            daBoundariesTrespassing.Fill(ds, Site_Boundaries_Tutti_Trespassing)
            contaRigheTrespassing = ds.Tables(Site_Boundaries_Tutti_Trespassing).Rows.Count
            'MsgBox("Righe righe Site boundaries in Barriere Trespassing =" & contaRigheTrespassing)
            Dim rigaAttivaTrespassing As Integer
            For rigaAttivaTrespassing = 0 To contaRigheTrespassing - 1
                tuttiBarrierTrespassing = ds.Tables(Site_Boundaries_Tutti_Trespassing).Rows(rigaAttivaTrespassing).Item("BarrierTRESPASSING")
                If tuttiBarrierTrespassing = True Then
                    contaBarriereTrespassing = contaBarriereTrespassing + 1
                End If
            Next rigaAttivaTrespassing
            'MsgBox("Barriere trespassing=" & contaBarriereTrespassing)
        Catch
            MsgBox("No valid values or no boundaries entered in database" & Chr(13) & "It's impossible to rank fot Target In-Site Humans", MsgBoxStyle.Critical, "Stopping calculation......")
            Exit Function
        End Try

        Dim step1 As String
        If contaRigheTrespassing <> contaBarriereTrespassing Then
            step1 = "No"
            'MsgBox("Not all barriers to Trespassing")
        Else
            step1 = "Yes"
            'MsgBox("All barriers to Trespassing")
        End If

        Dim step2 As String
        If strSiteOccupation = "24 hours" Or strSiteOccupation = "Not known" Or strSiteOccupation = "Working hours" Or strSiteOccupation = "Frequently" Then
            step2 = "Yes"
        ElseIf strSiteOccupation = "Infrequently" Then
            step2 = "No"
        Else
            step2 = "No"
        End If

        '**********************************************
        'Decisioni
        '**********************************************
        If step1 = "No" Then
            TARGET_OnsiteHumans = 1
        End If

        If step1 = "Yes" And step2 = "Yes" Then
            TARGET_OnsiteHumans = 1
        End If

        If step1 = "Yes" And step2 = "No" Then
            TARGET_OnsiteHumans = 0
        End If

    End Function

    'Visualization of multiple data in Form Viewer
    Private Sub btn_ViewBoundaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewBoundaries.Click
        identificaFormChiamanteGrid = "Boundaries"
        frmViewer.Show()
    End Sub
    Private Sub btn_ViewBoreholes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewBoreholes.Click
        identificaFormChiamanteGrid = "Boreholes"
        frmViewer.Show()
    End Sub
    Private Sub btn_ViewSurfaceDeposit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewSurfaceDeposit.Click

        identificaFormChiamanteGrid = "SurfaceDeposit"
        frmViewer.Show()
    End Sub
    Private Sub btn_ViewTanks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewTanks.Click

        identificaFormChiamanteGrid = "Tanks"
        frmViewer.Show()
    End Sub

    'CALCULATING POLLUTION EVENTS
    Private Sub PollutionEvent()

        If blnSRO_CrssBoundContam = True And blnSRO_Addressed = False Then
            PollutionEventRunOff = 1
        ElseIf blnSRO_CrssBoundContam = True And blnSRO_Addressed = True Then
            PollutionEventRunOff = 0
        End If

        If blnDP_CrssBoundContam = True And blnDP_Addressed = False Then
            PollutionEventDrainsPipes = 1
        ElseIf blnDP_CrssBoundContam = True And blnDP_Addressed = True Then
            PollutionEventDrainsPipes = 0
        End If

        If blnLF_CrssBoundContam = True And blnLF_Addressed = False Then
            PollutionEventLateralFlows = 1
        ElseIf blnLF_CrssBoundContam = True And blnLF_Addressed = True Then
            PollutionEventLateralFlows = 0
        End If

        'MsgBox("PollutionEventScoreA " & PollutionEventScoreA)
        PollutionEventScoreA = PollutionEventRunOff + PollutionEventDrainsPipes + PollutionEventLateralFlows
        'MsgBox("PollutionEventScoreA " & PollutionEventScoreA)

        'MsgBox("PollutionEventScoreB " & PollutionEventScoreB)
        PollutionEventScoreB = PollutionEventDrainsPipes + PollutionEventLateralFlows
        'MsgBox("PollutionEventScoreB " & PollutionEventScoreB)

        If Me.rdbUnderlyingAquiferYES_3.Checked = True And Me.rdbUnderlyingAquiferSourceContaminationYES_3.Checked = True Then
            PollutionEventAquifer = 1
        ElseIf Me.rdbUnderlyingAquiferYES_3.Checked = True And Me.rdbUnderlyingAquiferSourceContaminationNK_3.Checked = True Then
            PollutionEventAquifer = 1
        Else
            PollutionEventAquifer = 0
        End If

        If Me.chk43_5.Checked = True And Me.chk44_5.Checked = False Then
            PollutionEventAirborne = 1
        ElseIf Me.chk43_5.Checked = True And Me.chk44_5.Checked = True Then
            PollutionEventAirborne = 0
        End If

    End Sub

    'CALCULATING POLLUTANT LINKAGES
    Private Function PollutantLinkage3() As Double

        Dim Path_CalcB As Double
        If PollutionEventLateralFlows <= PollutionEventDrainsPipes Then
            Path_CalcB = PollutionEventDrainsPipes
        Else
            Path_CalcB = PollutionEventLateralFlows
        End If

        Dim Target_CalcA1 As Double
        If Val(Me.txtOffSiteHumansAssessment.Text) = 0 Then
            Target_CalcA1 = Me.txtEnvironmentRank.Text
        Else
            Target_CalcA1 = Me.txtOffSiteHumansAssessment.Text
        End If

        Dim Target_CalcA2 As Double
        If Val(Me.txtSurfaceWaterRank.Text) < 0.1 Then
            Target_CalcA2 = Target_CalcA1
        Else
            Target_CalcA2 = Val(Me.txtSurfaceWaterRank.Text)
        End If

        Dim TANKHAZ_SiteTankScore As Double
        TANKHAZ_SiteTankScore = Val(Me.txtHazardTanks.Text)

        'MsgBox(PollutionEventScoreB)
        If PollutionEventScoreB > 0 Then
            HPT_Score3 = Target_CalcA2
        Else
            HPT_Score3 = TANKHAZ_SiteTankScore * Path_CalcB * Target_CalcA2
        End If

        PollutantLinkage3 = HPT_Score3

    End Function
    Private Function PollutantLinkage4() As Double

        'STEP A
        Dim Target_CalcB1 As Double
        If Val(Me.txtSurfaceWaterRank.Text) < 0.1 Then
            Target_CalcB1 = Val(Me.txtEnvironmentRank.Text)
        Else
            Target_CalcB1 = Val(Me.txtSurfaceWaterRank.Text)
        End If

        'STEP B
        Dim Target_CalcB2 As Double
        If Me.txtGroundwaterRank.Text = 0 Then
            Target_CalcB2 = Target_CalcB1
        Else
            Target_CalcB2 = Val(Me.txtGroundwaterRank.Text)
        End If

        Dim TANKHAZ_SiteTankScore As Double
        TANKHAZ_SiteTankScore = Val(Me.txtHazardTanks.Text)

        'STEP B
        If PollutionEventAquifer = 1 Then
            HPT_Score4 = Target_CalcB2
        Else
            HPT_Score4 = TANKHAZ_SiteTankScore * Val(Me.txtVerticalFlowAssessment.Text) * Target_CalcB2
        End If

        PollutantLinkage4 = HPT_Score4

    End Function

    'PRIORITISE SITE USING REVISED SCORING SYSTEM
    Private Sub PRIORITISE()

        'STEP C
        Dim Weighting_HPT_Score3 As Integer
        If HPT_Score3 >= 0.42 Then
            Weighting_HPT_Score3 = 100
        ElseIf HPT_Score3 >= 0.2 And HPT_Score3 < 0.42 Then
            Weighting_HPT_Score3 = 3
        ElseIf HPT_Score3 > 0 And HPT_Score3 < 0.2 Then
            Weighting_HPT_Score3 = 2
        Else
            Weighting_HPT_Score3 = 1
        End If
        'MsgBox(Weighting_HPT_Score3)
        Me.txtWeighting_HPT_Score3.Text = Weighting_HPT_Score3

        'STEP D
        Dim Weighting_HPT_Score4 As Integer
        If HPT_Score4 >= 0.35 Then
            Weighting_HPT_Score4 = 100
        ElseIf HPT_Score4 >= 0.25 And HPT_Score4 < 0.35 Then
            Weighting_HPT_Score4 = 3
        ElseIf HPT_Score4 > 0 And HPT_Score4 < 0.25 Then
            Weighting_HPT_Score4 = 2
        Else
            Weighting_HPT_Score4 = 1
        End If
        'MsgBox(Weighting_HPT_Score4)
        Me.txtWeighting_HPT_Score4.Text = Weighting_HPT_Score4

        'STEP G
        Dim WeightingDSValue As Integer
        WeightingDSValue = Weighting_HPT_Score3 * Weighting_HPT_Score4
        Me.txtWeightingDSValue.Text = WeightingDSValue

        'STEP H Modified Fabio Lana 28 Settembre 2007
        If WeightingDSValue = 10000 Then
            DSPriority = "High"
        ElseIf WeightingDSValue >= 100 And WeightingDSValue <= 300 Then
            DSPriority = "Medium"
        Else
            DSPriority = "Low"
        End If

        Me.txtSiteStatusPrioritisation.Text = Me.cmbCurrentSiteStatus_6.Text

        Me.txtDSPriority.Text = DSPriority
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        AboutBox1.Show()
    End Sub

    'MANAGE THE LIST OF ALL SITES
    Private Function checkDoppio() As String

        Dim contaSites As Integer
        contaSites = DataSet11.Tables("Data_Archive").Rows.Count

        If contaSites = 0 Then
            aggiungisitoPrimo()
            Exit Function
        End If

        Dim tabellaSiteList As String
        tabellaSiteList = "Data_Archive"

        Dim SiteList(contaSites - 1) As String
        Dim SiteCodProgr(contaSites - 1) As Integer
        Dim rigaAttivaSiteList As Integer


        Dim ilSiteCodeOPSnonOPS As String
        If chkOperational.Checked Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-YOp"
        ElseIf chkOperational.Checked = False Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-NOp"
        End If

        Dim status As String
        'Dim CodStatus As Integer
        For rigaAttivaSiteList = 0 To contaSites - 1
            SiteList(rigaAttivaSiteList) = DataSet11.Tables(tabellaSiteList).Rows(rigaAttivaSiteList).Item("SiteCode")
            SitelistAttivo = SiteList(rigaAttivaSiteList)

            If SitelistAttivo = ilSiteCodeOPSnonOPS Then
                upgradaSito(rigaAttivaSiteList)
                Exit Function
                'status = rigaAttivaSiteList
            End If
        Next

        aggiungisito()

    End Function
    Private Sub aggiungisito()

        Dim contaSites As Integer
        contaSites = DataSet11.Tables("Data_Archive").Rows.Count

        Dim tabellaSiteList As String
        tabellaSiteList = "Data_Archive"

        Dim SiteCodProgr(contaSites - 1) As Integer
        Dim rigaAttivaSiteList As Integer
        Dim CodStatus As Integer = 0

        For rigaAttivaSiteList = 0 To contaSites - 1
            If contaSites = 0 Then
                Exit For
            Else
                CodStatus = contaSites
            End If
        Next

        Dim i As Integer
        Dim rw As DataRow
        'Add a new row 
        rw = DataSet11.Tables(0).NewRow

        rw.Item("Progr") = CodStatus
        Dim ilSiteCodeOPSnonOPS As String
        If chkOperational.Checked Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-YOp"
        ElseIf chkOperational.Checked = False Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-NOp"
        End If

        rw.Item("SiteCode") = ilSiteCodeOPSnonOPS
        rw.Item("MentLocCode") = Me.txtSiteName.Text
        rw.Item("SiteAddress") = Me.txtAddress1.Text
        rw.Item("SiteStatus") = Me.cmbCurrentSiteStatus_6.Text
        rw.Item("DSPriority") = DSPriority 'Me.txtDSPriority.Text
        rw.Item("W_HPT_Score3") = Me.txtWeighting_HPT_Score3.Text
        rw.Item("W_HPT_Score4") = Me.txtWeighting_HPT_Score4.Text
        rw.Item("R_HPT_Score3") = Me.txt_HPTScore3.Text
        rw.Item("R_HPT_Score4") = Me.txt_HPTScore4.Text
        rw.Item("Off-site_HS") = Me.txtOffSiteHumansAssessment.Text
        rw.Item("On-site_HS") = Me.txtOnsiteHumans_Assessment.Text
        rw.Item("FileLoc") = nomefile.ToString

        Try
            DataSet11.Tables(0).Rows.Add(rw)
            'Update the Student table in the testdb database.
            i = OleDbDataAdapter1.Update(DataSet11)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

      
        MessageBox.Show("Site ADDED to Master Database", "Master Database Modified", MessageBoxButtons.OK)

    End Sub
    Private Sub aggiungisitoPrimo()

        'IT IS THE FIRST SITE?
        Dim tabellaSiteList As String
        tabellaSiteList = "Data_Archive"

        Dim CodStatus As Integer = 0

        Dim i As Integer
        Dim rw As DataRow

        'Add a new row 
        rw = DataSet11.Tables(0).NewRow

        rw.Item("Progr") = CodStatus
        Dim ilSiteCodeOPSnonOPS As String
        If chkOperational.Checked Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-YOp"
        ElseIf chkOperational.Checked = False Then
            ilSiteCodeOPSnonOPS = Me.txt_CheckSiteCode.Text & "-NOp"
        End If

        rw.Item("SiteCode") = ilSiteCodeOPSnonOPS
        rw.Item("MentLocCode") = Me.txtSiteName.Text
        rw.Item("SiteAddress") = Me.txtAddress1.Text
        rw.Item("SiteStatus") = Me.cmbCurrentSiteStatus_6.Text
        rw.Item("DSPriority") = DSPriority 'Me.txtDSPriority.Text
        rw.Item("W_HPT_Score3") = Me.txtWeighting_HPT_Score3.Text
        rw.Item("W_HPT_Score4") = Me.txtWeighting_HPT_Score4.Text
        rw.Item("R_HPT_Score3") = Me.txt_HPTScore3.Text
        rw.Item("R_HPT_Score4") = Me.txt_HPTScore4.Text
        rw.Item("Off-site_HS") = Me.txtOffSiteHumansAssessment.Text
        rw.Item("On-site_HS") = Me.txtOnsiteHumans_Assessment.Text
        rw.Item("FileLoc") = nomefile.ToString

        Try
            DataSet11.Tables(0).Rows.Add(rw)
            'Update the table
            i = OleDbDataAdapter1.Update(DataSet11)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        MessageBox.Show("Site ADDED to Master Database", "Master Database Modified", MessageBoxButtons.OK)

    End Sub

    Private Function upgradaSito(ByVal rigadaupgradare) As Integer

        Dim contaSites As Integer
        contaSites = DataSet11.Tables("Data_Archive").Rows.Count
        'MsgBox(contaSites)

        Dim tabellaSiteList As String
        tabellaSiteList = "Data_Archive"

        Dim SiteCodProgr(contaSites - 1) As Integer
        Dim rigaAttivaSiteList As Integer

        Dim CodStatus As Integer
        'For rigaAttivaSiteList = 0 To contaSites - 1
        SiteCodProgr(rigaAttivaSiteList) = DataSet11.Tables(tabellaSiteList).Rows(rigadaupgradare).Item("Progr")
        CodStatus = SiteCodProgr(rigaAttivaSiteList)
        'Next

        'MsgBox(CodStatus)
        Dim colProgrCode As String
        colProgrCode = "Progr"

        Dim valSiteProgrCode As Object
        valSiteProgrCode = CodStatus

        Dim i, rwno As Integer
        rwno = rigadaupgradare

        'Le colonne dell'UPGRADE
        Dim colSiteCode, colMentLocCode, colSiteAddress, colSiteStatus, colDSPriority, ColFileLoc As String
        Dim colW_HPT_Score3, colW_HPT_Score4, colR_HPT_Score3, colR_HPT_Score4, colOffsite_HS, colOnsite_HS As String

        colSiteCode = "SiteCode"
        colMentLocCode = "MentLocCode"
        colSiteAddress = "SiteAddress"
        colSiteStatus = "SiteStatus"
        colDSPriority = "DSPriority"
        colW_HPT_Score3 = "W_HPT_Score3"
        colW_HPT_Score4 = "W_HPT_Score4"
        colR_HPT_Score3 = "R_HPT_Score3"
        colR_HPT_Score4 = "R_HPT_Score4"
        colOffsite_HS = "Off-site_HS"
        colOnsite_HS = "On-site_HS"
        ColFileLoc = "FileLoc"

        Dim valSiteCode, valMentLocCode, valSiteAddress, valSiteStatus, valDSPriority, ValFileLoc As Object
        Dim valW_HPT_Score3, valW_HPT_Score4, valR_HPT_Score3, valR_HPT_Score4, valOffsite_HS, valOnsite_HS As String

        valSiteCode = SitelistAttivo 'Me.txt_CheckSiteCode.Text
        valMentLocCode = Me.txtSiteName.Text
        valSiteAddress = Me.txtAddress1.Text
        valSiteStatus = Me.cmbCurrentSiteStatus_6.Text
        valDSPriority = DSPriority 'Me.txtDSPriority.Text
        valW_HPT_Score3 = Me.txtWeighting_HPT_Score3.Text
        valW_HPT_Score4 = Me.txtWeighting_HPT_Score4.Text
        valR_HPT_Score3 = Me.txt_HPTScore3.Text
        valR_HPT_Score4 = Me.txt_HPTScore4.Text
        valOffsite_HS = Me.txtOffSiteHumansAssessment.Text
        valOnsite_HS = Me.txtOnsiteHumans_Assessment.Text
        ValFileLoc = nomefile.ToString


        Try
            'Update columns in table Data_Archive of the MASTER DATABASE
            DataSet11.Tables(0).Rows(rwno).Item(colProgrCode) = valSiteProgrCode
            DataSet11.Tables(0).Rows(rwno).Item(colSiteCode) = valSiteCode
            DataSet11.Tables(0).Rows(rwno).Item(colMentLocCode) = valMentLocCode
            DataSet11.Tables(0).Rows(rwno).Item(colSiteAddress) = valSiteAddress
            DataSet11.Tables(0).Rows(rwno).Item(colSiteStatus) = valSiteStatus
            DataSet11.Tables(0).Rows(rwno).Item(colDSPriority) = valDSPriority
            DataSet11.Tables(0).Rows(rwno).Item(colW_HPT_Score3) = valW_HPT_Score3
            DataSet11.Tables(0).Rows(rwno).Item(colW_HPT_Score4) = valW_HPT_Score4
            DataSet11.Tables(0).Rows(rwno).Item(colR_HPT_Score3) = valR_HPT_Score3
            DataSet11.Tables(0).Rows(rwno).Item(colR_HPT_Score4) = valR_HPT_Score4
            DataSet11.Tables(0).Rows(rwno).Item(colOffsite_HS) = valOffsite_HS
            DataSet11.Tables(0).Rows(rwno).Item(colOnsite_HS) = valOnsite_HS
            DataSet11.Tables(0).Rows(rwno).Item(ColFileLoc) = ValFileLoc

            'Update table
            i = OleDbDataAdapter1.Update(DataSet11)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Site UPDATED in Master Database", "Master Database Modified", MessageBoxButtons.OK)

    End Function

    'Load values in the DATAGRID
    Private Sub SiteCodeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SiteCodeComboBox.SelectedIndexChanged

        Dim contaSites As Integer
        contaSites = DataSet11.Tables("Data_Archive").Rows.Count
        'MsgBox("numero Siti =" & contaSites)
        If contaSites = 1 Then Exit Sub

        If SiteCodeComboBox.Text = "" Then Exit Sub

        Dim checkYNOP As String
        checkYNOP = Microsoft.VisualBasic.Right(Trim(SiteCodeComboBox.Text), 4)
        If checkYNOP = "-YOp" Then
            'MsgBox("Selezionato Operational")
            stringaYOP = Microsoft.VisualBasic.Left(SiteCodeComboBox.Text, SiteCodeComboBox.Text.Length - 4) & "-YOp"
            stringaNOP = Microsoft.VisualBasic.Left(SiteCodeComboBox.Text, SiteCodeComboBox.Text.Length - 4) & "-NOp"
            'MsgBox(stringaNOP & "-" & stringaNOP)
        ElseIf checkYNOP = "-NOp" Then
            'MsgBox("Selezionato NON Operational")
            stringaYOP = Microsoft.VisualBasic.Left(SiteCodeComboBox.Text, SiteCodeComboBox.Text.Length - 4) & "-YOp"
            stringaNOP = Microsoft.VisualBasic.Left(SiteCodeComboBox.Text, SiteCodeComboBox.Text.Length - 4) & "-NOp"
            'MsgBox(stringaNOP & "-" & stringaNOP)
        End If

        Dim dsSiteAttivaOPS As New DataSet
        Dim daSiteDSAttivaOPS As OleDbDataAdapter
        Dim queryOPS As String
        queryOPS = "SELECT DSPriority,MentLocCode FROM Data_Archive WHERE SiteCode='" & stringaYOP & "'"
        daSiteDSAttivaOPS = New OleDbDataAdapter(queryOPS, conLista)
        daSiteDSAttivaOPS.Fill(dsSiteAttivaOPS, "tabellaFileLoc")

        Dim righe As Integer
        righe = dsSiteAttivaOPS.Tables(0).Rows.Count
        'MsgBox(righe)

        If righe = 0 Then
            GoTo salto_1
            'Exit Sub
        End If

        Dim PL3_PL4Ops, NomePL3_PL4Ops As String
        Try
            PL3_PL4Ops = dsSiteAttivaOPS.Tables(0).Rows(0).Item("DSPriority")
            txtPL3_PL4Ops.Text = PL3_PL4Ops
            NomePL3_PL4Ops = dsSiteAttivaOPS.Tables(0).Rows(0).Item("MentLocCode")
            txtNomeOPS.Text = NomePL3_PL4Ops
            dsSiteAttivaOPS.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Query Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

salto_1:
        Dim dsSiteAttivaNOPS As New DataSet
        Dim daSiteDSAttivaNOPS As OleDbDataAdapter
        Dim queryNOPS As String
        queryNOPS = "SELECT DSPriority,MentLocCode FROM Data_Archive WHERE SiteCode='" & stringaNOP & "'"
        daSiteDSAttivaNOPS = New OleDbDataAdapter(queryNOPS, conLista)
        daSiteDSAttivaNOPS.Fill(dsSiteAttivaNOPS, "tabellaFileLoc")
        Dim righeNOPS As Integer
        righeNOPS = dsSiteAttivaNOPS.Tables(0).Rows.Count
        'MsgBox(righe)

        If righeNOPS = 0 Then
            GoTo salto_2
        End If

        Dim PL3_PL4NOps As String 'NomePL3_PL4NOps
        Try
            PL3_PL4NOps = dsSiteAttivaNOPS.Tables(0).Rows(0).Item("DSPriority")
            txtPL3_PL4NonOps.Text = PL3_PL4NOps
            'NomePL3_PL4NOps = dsSiteAttivaNOPS.Tables(0).Rows(0).Item("MentLocCode")
            'txtNomeNOPS.Text = NomePL3_PL4NOps
            dsSiteAttivaNOPS.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Query Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

salto_2:
        connettiOP()
        connettiNOP()

    End Sub
    Private Sub connettiOP()

        conOp.Close()

        Dim dsSiteListRiceviFile As New DataSet
        Dim daSiteListRiceviFile As OleDbDataAdapter

        Dim testoconnessioneOP As String
        dsSiteList.Clear()


        Dim query As String
        query = "SELECT FileLoc FROM Data_Archive WHERE SiteCode='" & stringaYOP & "'"
        daSiteListRiceviFile = New OleDbDataAdapter(query, conLista)
        daSiteListRiceviFile.Fill(dsSiteList, "tabellaFileLoc")


        Dim righe As Integer
        righe = dsSiteList.Tables(0).Rows.Count
        'MsgBox(righe)

        If righe = 0 Then
            MsgBox("No database for Operational Site")
            dgvOps.Hide()
            connettiNOP()
            'Exit Sub
        End If

        Dim ricevofileloc As String

        Try
            ricevofileloc = dsSiteList.Tables(0).Rows(0).Item("FileLoc")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Query Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

        'CONNECTION TO THE  Access DATABASE FOR OPERATIONAL SITE
        testoconnessioneOP = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";" & _
                       "User ID=Admin;Data Source=" & ricevofileloc & ";"

        conOp.ConnectionString = testoconnessioneOP

        Try
            conOp.Open()
            'MsgBox("Tabella operational open")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


        querySiteOps = "SELECT PotReceptor,PotSource,PotPathways,RiskRanking FROM tRiskReduction"
        daSiteOps = New OleDbDataAdapter(querySiteOps, conOp)
        tabellaListaSiti = "RiskReduction"

        Try
            dsSiteOpS.Clear()
            daSiteOps.Fill(dsSiteOpS, tabellaListaSiti)
            Dim righeRiskAssess As Integer
            righeRiskAssess = dsSiteOpS.Tables(0).Rows.Count
            If righeRiskAssess = 0 Then
                MsgBox("No Risk Assessment records for Operational Site")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        dgvOps.Show()
        dgvOps.DataSource = dsSiteOpS
        dgvOps.DataMember = tabellaListaSiti
        dgvOps.Columns(0).HeaderText = "Potential Receptor"
        dgvOps.Columns(1).HeaderText = "Potential Source"
        dgvOps.Columns(2).HeaderText = "Potential Pathway Activity"
        dgvOps.Columns(3).HeaderText = "Risk Ranking"
        dgvOps.Refresh()
    End Sub
    Private Sub connettiNOP()

        conNop.Close()

        Dim dsSiteListRiceviFile As New DataSet
        Dim daSiteListRiceviFile As OleDbDataAdapter

        Dim testoconnessioneNOP As String
        dsSiteList.Clear()

        Dim query As String
        query = "SELECT FileLoc FROM Data_Archive WHERE SiteCode='" & stringaNOP & "'"
        daSiteListRiceviFile = New OleDbDataAdapter(query, conLista)
        daSiteListRiceviFile.Fill(dsSiteList, "tabellaFileLoc")


        Dim righe As Integer
        righe = dsSiteList.Tables(0).Rows.Count
        'MsgBox(righe)

        If righe = 0 Then
            MsgBox("No database for Non Operational Site")
            dgvNonOps.Hide()
            Exit Sub
        End If

        Dim ricevofileloc As String

        Try
            ricevofileloc = dsSiteList.Tables(0).Rows(0).Item("FileLoc")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Query Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

        'CONNECTION TO THE  Access DATABASE FOR NON OPERATIONAL SITE
        testoconnessioneNOP = "Provider=Microsoft.Jet.OLEDB.4.0;Password="""";" & _
                       "User ID=Admin;Data Source=" & ricevofileloc & ";"

        conNop.ConnectionString = testoconnessioneNOP

        Try
            conNop.Open()
            'MsgBox("Tabella operational open")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


        querySiteNOps = "SELECT PotReceptor ,PotSource ,PotPathways,RiskRanking FROM tRiskReduction"
        daSiteNOps = New OleDbDataAdapter(querySiteNOps, conNop)
        tabellaListaSiti = "RiskReduction"

        Try
            dsSiteNOps.Clear()
            daSiteNOps.Fill(dsSiteNOps, tabellaListaSiti)
            Dim righeRiskAssess As Integer
            righeRiskAssess = dsSiteNOps.Tables(0).Rows.Count
            If righeRiskAssess = 0 Then
                MsgBox("No Risk Assessment records for Non Operational Site")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        dgvNonOps.Show()
        dgvNonOps.DataSource = dsSiteNOps
        dgvNonOps.DataMember = tabellaListaSiti
        dgvNonOps.Columns(0).HeaderText = "Potential Receptor"
        dgvNonOps.Columns(1).HeaderText = "Potential Source"
        dgvNonOps.Columns(2).HeaderText = "Potential Pathway Activity"
        dgvNonOps.Columns(3).HeaderText = "Risk Ranking"
        dgvNonOps.Refresh()
    End Sub

    'SHOWING PDF
    Private Sub btnLoadPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPDF.Click
        OpenFileDialog2.ShowDialog()

        'Dim sceltoPDF As String
        'sceltoPDF = OpenFileDialog2.FileName
        'If OpenFileDialog2.ShowDialog.Cancel Then
        'MsgBox("PDF file loading cancelled...", MsgBoxStyle.Critical, "Error")
        'Exit Sub
        'Else
        'nomefilePDF = OpenFileDialog2.FileName
        'End If

       
    End Sub

    Private Sub OpenFileDialog2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenFileDialog2.Disposed
        'If nomefilePDF = "" Then
        'MsgBox("Data loading cancelled...", MsgBoxStyle.Critical, "Error")
        'Exit Sub
        'End If
    End Sub
    Private Sub OpenFileDialog2_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk

        Dim nomefilePDF As String


        nomefilePDF = OpenFileDialog2.FileName

        'If nomefilePDF = "" Then
        'MsgBox("Data loading cancelled...", MsgBoxStyle.Critical, "Error")
        'Exit Sub
        'End If

        'frmPDF.AxAcroPDF1.src = nomefilePDF
        'frmPDF.Show()

    End Sub

    
    
End Class
