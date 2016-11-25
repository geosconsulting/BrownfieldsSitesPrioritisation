<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceDeposit
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
        Me.btnExit = New System.Windows.Forms.Button
        Me.txtSiteCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gpbDetails = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTypeOfDeposit = New System.Windows.Forms.ComboBox
        Me.cmbTemporalMeasures = New System.Windows.Forms.ComboBox
        Me.txtOtherType = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtApproxThickness = New System.Windows.Forms.TextBox
        Me.txtAreaAffected = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.txtNSurfaceDeposit = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpDepositAccessedPeople = New System.Windows.Forms.GroupBox
        Me.rdbDepositAccessd_NO = New System.Windows.Forms.RadioButton
        Me.rdbDepositAccessd_YES = New System.Windows.Forms.RadioButton
        Me.Label68 = New System.Windows.Forms.Label
        Me.grpDepositMobilisedAirorneDust = New System.Windows.Forms.GroupBox
        Me.rdbDepositMobilised_NO = New System.Windows.Forms.RadioButton
        Me.rdbDepositMobilised_YES = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.DateTimePicker_SUD = New System.Windows.Forms.TextBox
        Me.gpbDetails.SuspendLayout()
        Me.grpDepositAccessedPeople.SuspendLayout()
        Me.grpDepositMobilisedAirorneDust.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(231, 402)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 83
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtSiteCode
        '
        Me.txtSiteCode.Cursor = System.Windows.Forms.Cursors.No
        Me.txtSiteCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode.Location = New System.Drawing.Point(14, 27)
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Site Code"
        '
        'gpbDetails
        '
        Me.gpbDetails.Controls.Add(Me.DateTimePicker_SUD)
        Me.gpbDetails.Controls.Add(Me.Label4)
        Me.gpbDetails.Controls.Add(Me.Label3)
        Me.gpbDetails.Controls.Add(Me.Label2)
        Me.gpbDetails.Controls.Add(Me.cmbTypeOfDeposit)
        Me.gpbDetails.Controls.Add(Me.cmbTemporalMeasures)
        Me.gpbDetails.Controls.Add(Me.txtOtherType)
        Me.gpbDetails.Controls.Add(Me.Label11)
        Me.gpbDetails.Controls.Add(Me.txtApproxThickness)
        Me.gpbDetails.Controls.Add(Me.txtAreaAffected)
        Me.gpbDetails.Controls.Add(Me.Label12)
        Me.gpbDetails.Controls.Add(Me.Label10)
        Me.gpbDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbDetails.Location = New System.Drawing.Point(10, 56)
        Me.gpbDetails.Name = "gpbDetails"
        Me.gpbDetails.Size = New System.Drawing.Size(536, 181)
        Me.gpbDetails.TabIndex = 84
        Me.gpbDetails.TabStop = False
        Me.gpbDetails.Text = "For each type of deposit:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(287, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Date installed"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Type of Deposit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 16)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Temporary remedial measures"
        '
        'cmbTypeOfDeposit
        '
        Me.cmbTypeOfDeposit.FormattingEnabled = True
        Me.cmbTypeOfDeposit.Location = New System.Drawing.Point(15, 39)
        Me.cmbTypeOfDeposit.Name = "cmbTypeOfDeposit"
        Me.cmbTypeOfDeposit.Size = New System.Drawing.Size(245, 21)
        Me.cmbTypeOfDeposit.TabIndex = 114
        '
        'cmbTemporalMeasures
        '
        Me.cmbTemporalMeasures.FormattingEnabled = True
        Me.cmbTemporalMeasures.Location = New System.Drawing.Point(15, 148)
        Me.cmbTemporalMeasures.Name = "cmbTemporalMeasures"
        Me.cmbTemporalMeasures.Size = New System.Drawing.Size(245, 21)
        Me.cmbTemporalMeasures.TabIndex = 113
        '
        'txtOtherType
        '
        Me.txtOtherType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOtherType.Location = New System.Drawing.Point(416, 39)
        Me.txtOtherType.Name = "txtOtherType"
        Me.txtOtherType.Size = New System.Drawing.Size(107, 22)
        Me.txtOtherType.TabIndex = 105
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(287, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 32)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Approximate thickness " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(maximum if uneven)"
        '
        'txtApproxThickness
        '
        Me.txtApproxThickness.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproxThickness.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtApproxThickness.Location = New System.Drawing.Point(438, 87)
        Me.txtApproxThickness.Name = "txtApproxThickness"
        Me.txtApproxThickness.Size = New System.Drawing.Size(85, 22)
        Me.txtApproxThickness.TabIndex = 107
        '
        'txtAreaAffected
        '
        Me.txtAreaAffected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaAffected.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAreaAffected.Location = New System.Drawing.Point(164, 80)
        Me.txtAreaAffected.Name = "txtAreaAffected"
        Me.txtAreaAffected.Size = New System.Drawing.Size(82, 22)
        Me.txtAreaAffected.TabIndex = 106
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(12, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 32)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Area of Site Affected" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "            (%)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(287, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 16)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "If ""Other"", state type"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(420, 367)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 23)
        Me.btnDelete.TabIndex = 128
        Me.btnDelete.Text = "Delete Deposit"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(292, 367)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 23)
        Me.btnUpdate.TabIndex = 127
        Me.btnUpdate.Text = "Update Deposit"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCommit.Location = New System.Drawing.Point(421, 338)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(105, 23)
        Me.btnCommit.TabIndex = 126
        Me.btnCommit.Text = "Commit Changes"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(292, 338)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 23)
        Me.btnAddNew.TabIndex = 125
        Me.btnAddNew.Text = "Add New Deposit"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(24, 338)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(112, 23)
        Me.btnPrevious.TabIndex = 121
        Me.btnPrevious.Text = "Previous Deposit"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.Location = New System.Drawing.Point(150, 367)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(105, 23)
        Me.btnLast.TabIndex = 124
        Me.btnLast.Text = "Last Deposit"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(149, 338)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(105, 23)
        Me.btnNext.TabIndex = 122
        Me.btnNext.Text = "Next Deposit"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirst.Location = New System.Drawing.Point(24, 367)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(112, 23)
        Me.btnFirst.TabIndex = 123
        Me.btnFirst.Text = "First Deposit"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtNSurfaceDeposit
        '
        Me.txtNSurfaceDeposit.Cursor = System.Windows.Forms.Cursors.No
        Me.txtNSurfaceDeposit.Location = New System.Drawing.Point(222, 27)
        Me.txtNSurfaceDeposit.Name = "txtNSurfaceDeposit"
        Me.txtNSurfaceDeposit.Size = New System.Drawing.Size(137, 20)
        Me.txtNSurfaceDeposit.TabIndex = 129
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(225, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 16)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "N of Surface Deposit"
        '
        'grpDepositAccessedPeople
        '
        Me.grpDepositAccessedPeople.Controls.Add(Me.rdbDepositAccessd_NO)
        Me.grpDepositAccessedPeople.Controls.Add(Me.rdbDepositAccessd_YES)
        Me.grpDepositAccessedPeople.Controls.Add(Me.Label68)
        Me.grpDepositAccessedPeople.Location = New System.Drawing.Point(10, 243)
        Me.grpDepositAccessedPeople.Name = "grpDepositAccessedPeople"
        Me.grpDepositAccessedPeople.Size = New System.Drawing.Size(260, 89)
        Me.grpDepositAccessedPeople.TabIndex = 131
        Me.grpDepositAccessedPeople.TabStop = False
        '
        'rdbDepositAccessd_NO
        '
        Me.rdbDepositAccessd_NO.AutoSize = True
        Me.rdbDepositAccessd_NO.Location = New System.Drawing.Point(209, 47)
        Me.rdbDepositAccessd_NO.Name = "rdbDepositAccessd_NO"
        Me.rdbDepositAccessd_NO.Size = New System.Drawing.Size(39, 17)
        Me.rdbDepositAccessd_NO.TabIndex = 137
        Me.rdbDepositAccessd_NO.TabStop = True
        Me.rdbDepositAccessd_NO.Text = "No"
        Me.rdbDepositAccessd_NO.UseVisualStyleBackColor = True
        '
        'rdbDepositAccessd_YES
        '
        Me.rdbDepositAccessd_YES.AutoSize = True
        Me.rdbDepositAccessd_YES.Location = New System.Drawing.Point(209, 24)
        Me.rdbDepositAccessd_YES.Name = "rdbDepositAccessd_YES"
        Me.rdbDepositAccessd_YES.Size = New System.Drawing.Size(43, 17)
        Me.rdbDepositAccessd_YES.TabIndex = 136
        Me.rdbDepositAccessd_YES.TabStop = True
        Me.rdbDepositAccessd_YES.Text = "Yes"
        Me.rdbDepositAccessd_YES.UseVisualStyleBackColor = True
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(9, 28)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(185, 32)
        Me.Label68.TabIndex = 135
        Me.Label68.Text = "Can this deposit be accessed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "by people on site?"
        '
        'grpDepositMobilisedAirorneDust
        '
        Me.grpDepositMobilisedAirorneDust.Controls.Add(Me.rdbDepositMobilised_NO)
        Me.grpDepositMobilisedAirorneDust.Controls.Add(Me.rdbDepositMobilised_YES)
        Me.grpDepositMobilisedAirorneDust.Controls.Add(Me.Label5)
        Me.grpDepositMobilisedAirorneDust.Location = New System.Drawing.Point(286, 243)
        Me.grpDepositMobilisedAirorneDust.Name = "grpDepositMobilisedAirorneDust"
        Me.grpDepositMobilisedAirorneDust.Size = New System.Drawing.Size(260, 89)
        Me.grpDepositMobilisedAirorneDust.TabIndex = 138
        Me.grpDepositMobilisedAirorneDust.TabStop = False
        '
        'rdbDepositMobilised_NO
        '
        Me.rdbDepositMobilised_NO.AutoSize = True
        Me.rdbDepositMobilised_NO.Location = New System.Drawing.Point(205, 47)
        Me.rdbDepositMobilised_NO.Name = "rdbDepositMobilised_NO"
        Me.rdbDepositMobilised_NO.Size = New System.Drawing.Size(39, 17)
        Me.rdbDepositMobilised_NO.TabIndex = 140
        Me.rdbDepositMobilised_NO.TabStop = True
        Me.rdbDepositMobilised_NO.Text = "No"
        Me.rdbDepositMobilised_NO.UseVisualStyleBackColor = True
        '
        'rdbDepositMobilised_YES
        '
        Me.rdbDepositMobilised_YES.AutoSize = True
        Me.rdbDepositMobilised_YES.Location = New System.Drawing.Point(205, 24)
        Me.rdbDepositMobilised_YES.Name = "rdbDepositMobilised_YES"
        Me.rdbDepositMobilised_YES.Size = New System.Drawing.Size(43, 17)
        Me.rdbDepositMobilised_YES.TabIndex = 139
        Me.rdbDepositMobilised_YES.TabStop = True
        Me.rdbDepositMobilised_YES.Text = "Yes"
        Me.rdbDepositMobilised_YES.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 32)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Can this deposit be mobilised" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as an airborne dust?"
        '
        'DateTimePicker_SUD
        '
        Me.DateTimePicker_SUD.Location = New System.Drawing.Point(399, 150)
        Me.DateTimePicker_SUD.Name = "DateTimePicker_SUD"
        Me.DateTimePicker_SUD.Size = New System.Drawing.Size(125, 20)
        Me.DateTimePicker_SUD.TabIndex = 121
        '
        'frmSurfaceDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 432)
        Me.Controls.Add(Me.grpDepositMobilisedAirorneDust)
        Me.Controls.Add(Me.grpDepositAccessedPeople)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNSurfaceDeposit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.txtSiteCode)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.gpbDetails)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnNext)
        Me.Name = "frmSurfaceDeposit"
        Me.Text = "Surface Deposits"
        Me.gpbDetails.ResumeLayout(False)
        Me.gpbDetails.PerformLayout()
        Me.grpDepositAccessedPeople.ResumeLayout(False)
        Me.grpDepositAccessedPeople.PerformLayout()
        Me.grpDepositMobilisedAirorneDust.ResumeLayout(False)
        Me.grpDepositMobilisedAirorneDust.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTypeOfDeposit As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTemporalMeasures As System.Windows.Forms.ComboBox
    Friend WithEvents txtOtherType As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtApproxThickness As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaAffected As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNSurfaceDeposit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpDepositAccessedPeople As System.Windows.Forms.GroupBox
    Friend WithEvents rdbDepositAccessd_NO As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDepositAccessd_YES As System.Windows.Forms.RadioButton
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents grpDepositMobilisedAirorneDust As System.Windows.Forms.GroupBox
    Friend WithEvents rdbDepositMobilised_NO As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDepositMobilised_YES As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_SUD As System.Windows.Forms.TextBox
End Class
