Imports System.Data.OleDb

Public Class frmViewer

    ' The fields in the database
    Private m_Fields() As String

    ' True until we finish loading.
    Dim m_Loaded As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Set some properties. 
        ' (I do this here to make it easier to find them.)
        Me.txtSiteCode_Viewer.Text = strCodiceSito
        dgvBoundaries.AutoGenerateColumns = True
        dgvBoundaries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Select Case identificaFormChiamanteGrid
            Case "Boreholes"
                SelectData("SELECT * FROM tAbstractionBoreholes ")
            Case "Boundaries"
                SelectData("SELECT * FROM tSiteBoundaryInformation ")
            Case "SurfaceDeposit"
                SelectData("SELECT * FROM tSurfaceDeposit ")
            Case "Tanks"
                SelectData("SELECT * FROM tTankInformation ")
        End Select


        ' Restore the saved column visibilities.
        LoadSettings()
        m_Loaded = True


    End Sub

    ' Display data.
    Private Sub SelectData(ByVal query As String)

        ' Select the data.
        Dim data_table As New DataTable("Tabella")
        Dim da As New OleDbDataAdapter(query, frmMain.con)
        Try
            ' Get the data.
            da.Fill(data_table)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Query Error", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
        End Try

        ' Display the result.
        dgvBoundaries.DataSource = data_table

        If identificaFormChiamanteGrid = "Boreholes" Then
            'dgvOps.DataSource = dsSiteOpS
            'dgvBoundaries.DataMember = tabellaListaSiti
            dgvBoundaries.Columns(0).HeaderText = "Information Available"
            dgvBoundaries.Columns(1).HeaderText = "No Information"
            dgvBoundaries.Columns(2).HeaderText = "OS Tile"
            dgvBoundaries.Columns(3).HeaderText = "Easting"
            dgvBoundaries.Columns(4).HeaderText = "Northing"
            dgvBoundaries.Columns(5).HeaderText = "Distance"
            dgvBoundaries.Columns(6).HeaderText = "End Use"
            dgvBoundaries.Columns(7).HeaderText = "Source Data"
            dgvBoundaries.Columns(8).HeaderText = "Volume Abstracted"
            dgvBoundaries.Columns(9).HeaderText = "License Status"
            dgvBoundaries.Columns(10).HeaderText = "Primary Key"
            dgvBoundaries.Refresh()
        End If

        If identificaFormChiamanteGrid = "Boundaries" Then
            'dgvOps.DataSource = dsSiteOpS
            'dgvBoundaries.DataMember = tabellaListaSiti
            dgvBoundaries.Columns(0).HeaderText = "Information Available"
            dgvBoundaries.Columns(1).HeaderText = "Facing Direction"
            dgvBoundaries.Columns(2).HeaderText = "Length"
            dgvBoundaries.Columns(3).HeaderText = "Heigth"
            dgvBoundaries.Columns(4).HeaderText = "Boundary Construction"
            dgvBoundaries.Columns(5).HeaderText = "Gradient"
            dgvBoundaries.Columns(6).HeaderText = "Adjacent GasWorks"
            dgvBoundaries.Columns(7).HeaderText = "Adjacent"
            dgvBoundaries.Columns(8).HeaderText = "Proximal"
            dgvBoundaries.Columns(9).HeaderText = "Other Adjacent Land-Use"
            dgvBoundaries.Columns(10).HeaderText = "Other Proximal Land-Use"
            dgvBoundaries.Columns(11).HeaderText = "Human Sensitivity Adjacent Low"
            dgvBoundaries.Columns(12).HeaderText = "Human Sensitivity Adjacent Medium"
            dgvBoundaries.Columns(13).HeaderText = "Human Sensitivity Adjacent High"
            dgvBoundaries.Columns(14).HeaderText = "Human Sensitivity Proximal Low"
            dgvBoundaries.Columns(15).HeaderText = "Human Sensitivity Proximal Medium"
            dgvBoundaries.Columns(16).HeaderText = "Human Sensitivity Proximal High"
            dgvBoundaries.Columns(17).HeaderText = "Barrier to Run-Off"
            dgvBoundaries.Columns(18).HeaderText = "Barrier to Trespassing"
            dgvBoundaries.Columns(19).HeaderText = "Barrier to Airborne Dust"
            dgvBoundaries.Columns(20).HeaderText = "Sub-surface Lateral Flow"
            dgvBoundaries.Columns(21).HeaderText = "No Sub-surface Lateral Flow"
            dgvBoundaries.Columns(22).HeaderText = "Sub-surface Lateral Flow Unknown"
            dgvBoundaries.Columns(23).HeaderText = "Primary Key"
            dgvBoundaries.Refresh()
        End If

        If identificaFormChiamanteGrid = "SurfaceDeposit" Then
            'dgvOps.DataSource = dsSiteOpS
            'dgvBoundaries.DataMember = tabellaListaSiti
            dgvBoundaries.Columns(0).HeaderText = "Type of Deposit"
            dgvBoundaries.Columns(1).HeaderText = "Other"
            dgvBoundaries.Columns(2).HeaderText = "Area Affected"
            dgvBoundaries.Columns(3).HeaderText = "Approximate Thickness"
            dgvBoundaries.Columns(4).HeaderText = "Temporary Remedial"
            dgvBoundaries.Columns(5).HeaderText = "Date Installed"
            dgvBoundaries.Columns(6).HeaderText = "Accessible"
            dgvBoundaries.Columns(7).HeaderText = "Not Accessible"
            dgvBoundaries.Columns(8).HeaderText = "Mobilised Airborne"
            dgvBoundaries.Columns(9).HeaderText = "Not Mobilised Airborne"
            dgvBoundaries.Columns(10).HeaderText = "Primary Key"

            dgvBoundaries.Refresh()
        End If

        If identificaFormChiamanteGrid = "Tanks" Then
            'dgvOps.DataSource = dsSiteOpS
            'dgvBoundaries.DataMember = tabellaListaSiti
            dgvBoundaries.Columns(0).HeaderText = "Superficial"
            dgvBoundaries.Columns(1).HeaderText = "Buried"
            dgvBoundaries.Columns(2).HeaderText = "Isolated"
            dgvBoundaries.Columns(3).HeaderText = "Not Isolated"
            dgvBoundaries.Columns(4).HeaderText = "Gas Holder"
            dgvBoundaries.Columns(5).HeaderText = "Tank/Tar Well"
            dgvBoundaries.Columns(6).HeaderText = "Content"
            dgvBoundaries.Columns(7).HeaderText = "Primary Key"
            dgvBoundaries.Refresh()
        End If

        ' Set column alignments.
        For c As Integer = 0 To dgvBoundaries.Columns.Count - 1
            Select Case dgvBoundaries.Columns(c).ValueType.ToString
                Case "System.Decimal"  ' Currency.
                    dgvBoundaries.Columns(c).DefaultCellStyle.Format = "c"
                    dgvBoundaries.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "System.DateTime" ' Date.
                    dgvBoundaries.Columns(c).DefaultCellStyle.Format = "d"
                    dgvBoundaries.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "System.String"
                    dgvBoundaries.Columns(c).DefaultCellStyle.Format = ""
                    dgvBoundaries.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "System.Single"    ' One digit after the decimal point.
                    dgvBoundaries.Columns(c).DefaultCellStyle.Format = ".0"
                    dgvBoundaries.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else       ' Probably number.
                    dgvBoundaries.Columns(c).DefaultCellStyle.Format = ""
                    dgvBoundaries.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next c

    End Sub

    ' Save the application's configuration.
    Private Sub LoadSettings()

        'Caricamento dati dei combobox sul form

        ' Load the column visibilities.
        For i As Integer = 0 To dgvBoundaries.Columns.Count - 1
            Dim value As String = GetSetting( _
                Application.ProductName, _
                "ColumnVisibilities", _
                "Column" & i.ToString(), _
                "True" _
            )
            dgvBoundaries.Columns(i).Visible = Boolean.Parse(value)
        Next i

        ' Load the size.
        Dim wid As Integer = _
            Integer.Parse(GetSetting( _
                Application.ProductName, _
                "General", _
                "Width", _
                Me.Width.ToString()))
        Dim hgt As Integer = _
            Integer.Parse(GetSetting( _
                Application.ProductName, _
                "General", _
                "Height", _
                Me.Height.ToString()))
        'Me.Size = New Size(wid, hgt)

    End Sub

    ' Save the application's configuration.
    Private Sub SaveSettings()
        ' Do nothing if we're not loaded yet.
        If Not m_Loaded Then Exit Sub

        ' Save the column visibilities.
        For i As Integer = 0 To dgvBoundaries.Columns.Count - 1
            SaveSetting( _
                Application.ProductName, _
                "ColumnVisibilities", _
                "Column" & i.ToString(), _
                dgvBoundaries.Columns(i).Visible.ToString())
        Next i

        ' Save the size.
        SaveSetting( _
            Application.ProductName, _
            "General", _
            "Width", _
            Me.Width.ToString())
        SaveSetting( _
            Application.ProductName, _
            "General", _
            "Height", _
            Me.Height.ToString())

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScegliCampi.Click
        Dim dlg As New dlgSelectFields
        dlg.TheDataGridView = dgvBoundaries
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Save the settings.
            SaveSettings()
        End If
    End Sub

   
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub dgvBoundaries_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBoundaries.CellContentClick

    End Sub
End Class