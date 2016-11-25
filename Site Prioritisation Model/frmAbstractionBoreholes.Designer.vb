<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbstractionBoreholes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtSiteCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.rdbInfoYes = New System.Windows.Forms.RadioButton
        Me.rdbInfoNo = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.gpbDetails = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbLicenceStatus = New System.Windows.Forms.ComboBox
        Me.cmbVolumeAbstracted = New System.Windows.Forms.ComboBox
        Me.cmbSourceOfData = New System.Windows.Forms.ComboBox
        Me.cmbEndUse = New System.Windows.Forms.ComboBox
        Me.txtDistance = New System.Windows.Forms.TextBox
        Me.Label99 = New System.Windows.Forms.Label
        Me.txtOSTile = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNorthing = New System.Windows.Forms.TextBox
        Me.txtEasting = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNBoreholes = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.gpbDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSiteCode
        '
        Me.txtSiteCode.Cursor = System.Windows.Forms.Cursors.No
        Me.txtSiteCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode.Location = New System.Drawing.Point(12, 27)
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Site Code"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(229, 331)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 68
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'rdbInfoYes
        '
        Me.rdbInfoYes.AutoSize = True
        Me.rdbInfoYes.Location = New System.Drawing.Point(476, 16)
        Me.rdbInfoYes.Name = "rdbInfoYes"
        Me.rdbInfoYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbInfoYes.TabIndex = 77
        Me.rdbInfoYes.Text = "Yes"
        Me.rdbInfoYes.UseVisualStyleBackColor = True
        '
        'rdbInfoNo
        '
        Me.rdbInfoNo.AutoSize = True
        Me.rdbInfoNo.Location = New System.Drawing.Point(476, 40)
        Me.rdbInfoNo.Name = "rdbInfoNo"
        Me.rdbInfoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbInfoNo.TabIndex = 78
        Me.rdbInfoNo.Text = "No"
        Me.rdbInfoNo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 32)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Are there any details" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for this borehole?"
        '
        'gpbDetails
        '
        Me.gpbDetails.Controls.Add(Me.Label5)
        Me.gpbDetails.Controls.Add(Me.Label4)
        Me.gpbDetails.Controls.Add(Me.Label3)
        Me.gpbDetails.Controls.Add(Me.Label2)
        Me.gpbDetails.Controls.Add(Me.cmbLicenceStatus)
        Me.gpbDetails.Controls.Add(Me.cmbVolumeAbstracted)
        Me.gpbDetails.Controls.Add(Me.cmbSourceOfData)
        Me.gpbDetails.Controls.Add(Me.cmbEndUse)
        Me.gpbDetails.Controls.Add(Me.txtDistance)
        Me.gpbDetails.Controls.Add(Me.Label99)
        Me.gpbDetails.Controls.Add(Me.txtOSTile)
        Me.gpbDetails.Controls.Add(Me.Label11)
        Me.gpbDetails.Controls.Add(Me.txtNorthing)
        Me.gpbDetails.Controls.Add(Me.txtEasting)
        Me.gpbDetails.Controls.Add(Me.Label12)
        Me.gpbDetails.Controls.Add(Me.Label10)
        Me.gpbDetails.Enabled = False
        Me.gpbDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbDetails.Location = New System.Drawing.Point(7, 56)
        Me.gpbDetails.Name = "gpbDetails"
        Me.gpbDetails.Size = New System.Drawing.Size(536, 182)
        Me.gpbDetails.TabIndex = 80
        Me.gpbDetails.TabStop = False
        Me.gpbDetails.Text = "Details"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(282, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Licence Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(282, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 16)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Volume Abstracted M.m3/a"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(282, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Source of Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "End Use"
        '
        'cmbLicenceStatus
        '
        Me.cmbLicenceStatus.FormattingEnabled = True
        Me.cmbLicenceStatus.Location = New System.Drawing.Point(283, 148)
        Me.cmbLicenceStatus.Name = "cmbLicenceStatus"
        Me.cmbLicenceStatus.Size = New System.Drawing.Size(245, 21)
        Me.cmbLicenceStatus.TabIndex = 116
        '
        'cmbVolumeAbstracted
        '
        Me.cmbVolumeAbstracted.FormattingEnabled = True
        Me.cmbVolumeAbstracted.Location = New System.Drawing.Point(283, 91)
        Me.cmbVolumeAbstracted.Name = "cmbVolumeAbstracted"
        Me.cmbVolumeAbstracted.Size = New System.Drawing.Size(245, 21)
        Me.cmbVolumeAbstracted.TabIndex = 115
        '
        'cmbSourceOfData
        '
        Me.cmbSourceOfData.FormattingEnabled = True
        Me.cmbSourceOfData.Location = New System.Drawing.Point(283, 38)
        Me.cmbSourceOfData.Name = "cmbSourceOfData"
        Me.cmbSourceOfData.Size = New System.Drawing.Size(245, 21)
        Me.cmbSourceOfData.TabIndex = 114
        '
        'cmbEndUse
        '
        Me.cmbEndUse.FormattingEnabled = True
        Me.cmbEndUse.Location = New System.Drawing.Point(15, 148)
        Me.cmbEndUse.Name = "cmbEndUse"
        Me.cmbEndUse.Size = New System.Drawing.Size(245, 21)
        Me.cmbEndUse.TabIndex = 113
        '
        'txtDistance
        '
        Me.txtDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistance.Location = New System.Drawing.Point(181, 89)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.Size = New System.Drawing.Size(79, 22)
        Me.txtDistance.TabIndex = 108
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(12, 91)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(136, 16)
        Me.Label99.TabIndex = 112
        Me.Label99.Text = "Distance from site (m)"
        '
        'txtOSTile
        '
        Me.txtOSTile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOSTile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOSTile.Location = New System.Drawing.Point(9, 38)
        Me.txtOSTile.Name = "txtOSTile"
        Me.txtOSTile.Size = New System.Drawing.Size(78, 22)
        Me.txtOSTile.TabIndex = 105
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(191, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Northing"
        '
        'txtNorthing
        '
        Me.txtNorthing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNorthing.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNorthing.Location = New System.Drawing.Point(181, 38)
        Me.txtNorthing.Name = "txtNorthing"
        Me.txtNorthing.Size = New System.Drawing.Size(79, 22)
        Me.txtNorthing.TabIndex = 107
        '
        'txtEasting
        '
        Me.txtEasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEasting.Location = New System.Drawing.Point(93, 38)
        Me.txtEasting.Name = "txtEasting"
        Me.txtEasting.Size = New System.Drawing.Size(82, 22)
        Me.txtEasting.TabIndex = 106
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(104, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 16)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Easting"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(20, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 16)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "OS Tile"
        '
        'txtNBoreholes
        '
        Me.txtNBoreholes.Location = New System.Drawing.Point(209, 26)
        Me.txtNBoreholes.Name = "txtNBoreholes"
        Me.txtNBoreholes.Size = New System.Drawing.Size(88, 20)
        Me.txtNBoreholes.TabIndex = 81
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(205, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 16)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "N of Boreholes"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(422, 286)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 23)
        Me.btnDelete.TabIndex = 136
        Me.btnDelete.Text = "Delete Borehole"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(294, 286)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 23)
        Me.btnUpdate.TabIndex = 135
        Me.btnUpdate.Text = "Update Borehole"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCommit.Location = New System.Drawing.Point(423, 257)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(105, 23)
        Me.btnCommit.TabIndex = 134
        Me.btnCommit.Text = "Commit Changes"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(294, 257)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 23)
        Me.btnAddNew.TabIndex = 133
        Me.btnAddNew.Text = "Add New Borehole"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(26, 257)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(112, 23)
        Me.btnPrevious.TabIndex = 129
        Me.btnPrevious.Text = "Previous Borehole"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.Location = New System.Drawing.Point(152, 286)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(105, 23)
        Me.btnLast.TabIndex = 132
        Me.btnLast.Text = "Last Borehole"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(151, 257)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(105, 23)
        Me.btnNext.TabIndex = 130
        Me.btnNext.Text = "NextBorehole"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirst.Location = New System.Drawing.Point(26, 286)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(112, 23)
        Me.btnFirst.TabIndex = 131
        Me.btnFirst.Text = "First Borehole"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'frmAbstractionBoreholes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 366)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNBoreholes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.rdbInfoNo)
        Me.Controls.Add(Me.rdbInfoYes)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtSiteCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpbDetails)
        Me.Name = "frmAbstractionBoreholes"
        Me.Text = "Abstraction Boreholes"
        Me.gpbDetails.ResumeLayout(False)
        Me.gpbDetails.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents rdbInfoYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbInfoNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gpbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbLicenceStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVolumeAbstracted As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSourceOfData As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEndUse As System.Windows.Forms.ComboBox
    Friend WithEvents txtDistance As System.Windows.Forms.TextBox
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents txtOSTile As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNorthing As System.Windows.Forms.TextBox
    Friend WithEvents txtEasting As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNBoreholes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
End Class
