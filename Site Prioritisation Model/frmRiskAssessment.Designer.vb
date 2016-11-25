<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRiskAssessment
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
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.txtSiteCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPotentialTarget = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbRiskRanking = New System.Windows.Forms.ComboBox
        Me.txtIdentifiedSources = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPotentialPathways = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCommentsRA = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(540, 447)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 83
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(395, 465)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 23)
        Me.btnDelete.TabIndex = 91
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(288, 465)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 23)
        Me.btnUpdate.TabIndex = 90
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(395, 436)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(98, 23)
        Me.btnCommit.TabIndex = 89
        Me.btnCommit.Text = "Commit Changes"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(288, 436)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(93, 23)
        Me.btnAddNew.TabIndex = 88
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(22, 436)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(96, 23)
        Me.btnPrevious.TabIndex = 84
        Me.btnPrevious.Text = "Previous "
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(136, 465)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(95, 23)
        Me.btnLast.TabIndex = 87
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(135, 436)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(96, 23)
        Me.btnNext.TabIndex = 85
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(22, 465)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(96, 23)
        Me.btnFirst.TabIndex = 86
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'txtSiteCode
        '
        Me.txtSiteCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode.Location = New System.Drawing.Point(14, 31)
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Site Code"
        '
        'txtPotentialTarget
        '
        Me.txtPotentialTarget.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPotentialTarget.Location = New System.Drawing.Point(12, 82)
        Me.txtPotentialTarget.Multiline = True
        Me.txtPotentialTarget.Name = "txtPotentialTarget"
        Me.txtPotentialTarget.Size = New System.Drawing.Size(143, 68)
        Me.txtPotentialTarget.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label2.Location = New System.Drawing.Point(25, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Potential Targets"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(540, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Risk Ranking"
        '
        'cmbRiskRanking
        '
        Me.cmbRiskRanking.FormattingEnabled = True
        Me.cmbRiskRanking.Location = New System.Drawing.Point(523, 82)
        Me.cmbRiskRanking.Name = "cmbRiskRanking"
        Me.cmbRiskRanking.Size = New System.Drawing.Size(132, 21)
        Me.cmbRiskRanking.TabIndex = 92
        '
        'txtIdentifiedSources
        '
        Me.txtIdentifiedSources.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIdentifiedSources.Location = New System.Drawing.Point(161, 82)
        Me.txtIdentifiedSources.Multiline = True
        Me.txtIdentifiedSources.Name = "txtIdentifiedSources"
        Me.txtIdentifiedSources.Size = New System.Drawing.Size(157, 68)
        Me.txtIdentifiedSources.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label3.Location = New System.Drawing.Point(182, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Identified Sources"
        '
        'txtPotentialPathways
        '
        Me.txtPotentialPathways.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPotentialPathways.Location = New System.Drawing.Point(324, 82)
        Me.txtPotentialPathways.Multiline = True
        Me.txtPotentialPathways.Name = "txtPotentialPathways"
        Me.txtPotentialPathways.Size = New System.Drawing.Size(193, 68)
        Me.txtPotentialPathways.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label5.Location = New System.Drawing.Point(353, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Potential Pathways"
        '
        'txtCommentsRA
        '
        Me.txtCommentsRA.Location = New System.Drawing.Point(14, 188)
        Me.txtCommentsRA.Multiline = True
        Me.txtCommentsRA.Name = "txtCommentsRA"
        Me.txtCommentsRA.Size = New System.Drawing.Size(641, 217)
        Me.txtCommentsRA.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label6.Location = New System.Drawing.Point(12, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 16)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Comments (1000 max)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 413)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 102
        '
        'frmRiskAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 499)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCommentsRA)
        Me.Controls.Add(Me.txtPotentialPathways)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIdentifiedSources)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPotentialTarget)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbRiskRanking)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.txtSiteCode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRiskAssessment"
        Me.Text = "frmRiskAssessment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPotentialTarget As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbRiskRanking As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdentifiedSources As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPotentialPathways As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCommentsRA As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
