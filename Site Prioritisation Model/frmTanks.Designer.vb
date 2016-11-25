<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTanks
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
        Me.gpbTankLocation = New System.Windows.Forms.GroupBox
        Me.rdbBuried = New System.Windows.Forms.RadioButton
        Me.rdbAtThesurface = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbContentsOfTheTank = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.gpbTankType = New System.Windows.Forms.GroupBox
        Me.rdbTankTarWell = New System.Windows.Forms.RadioButton
        Me.rdbGasHolder = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbIsolatedNO = New System.Windows.Forms.RadioButton
        Me.rdbIsolatedYes = New System.Windows.Forms.RadioButton
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNTanks = New System.Windows.Forms.TextBox
        Me.gpbTankLocation.SuspendLayout()
        Me.gpbTankType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSiteCode
        '
        Me.txtSiteCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode.Location = New System.Drawing.Point(14, 24)
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Site Code"
        '
        'gpbTankLocation
        '
        Me.gpbTankLocation.Controls.Add(Me.rdbBuried)
        Me.gpbTankLocation.Controls.Add(Me.rdbAtThesurface)
        Me.gpbTankLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTankLocation.Location = New System.Drawing.Point(14, 82)
        Me.gpbTankLocation.Name = "gpbTankLocation"
        Me.gpbTankLocation.Size = New System.Drawing.Size(208, 109)
        Me.gpbTankLocation.TabIndex = 59
        Me.gpbTankLocation.TabStop = False
        Me.gpbTankLocation.Text = "Where is the tank located?"
        '
        'rdbBuried
        '
        Me.rdbBuried.AutoSize = True
        Me.rdbBuried.Location = New System.Drawing.Point(45, 67)
        Me.rdbBuried.Name = "rdbBuried"
        Me.rdbBuried.Size = New System.Drawing.Size(61, 17)
        Me.rdbBuried.TabIndex = 1
        Me.rdbBuried.TabStop = True
        Me.rdbBuried.Text = "Buried"
        Me.rdbBuried.UseVisualStyleBackColor = True
        '
        'rdbAtThesurface
        '
        Me.rdbAtThesurface.AutoSize = True
        Me.rdbAtThesurface.Location = New System.Drawing.Point(45, 32)
        Me.rdbAtThesurface.Name = "rdbAtThesurface"
        Me.rdbAtThesurface.Size = New System.Drawing.Size(105, 17)
        Me.rdbAtThesurface.TabIndex = 0
        Me.rdbAtThesurface.TabStop = True
        Me.rdbAtThesurface.Text = "At the surface"
        Me.rdbAtThesurface.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(249, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 16)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "What are the contents of the tank?"
        '
        'cmbContentsOfTheTank
        '
        Me.cmbContentsOfTheTank.FormattingEnabled = True
        Me.cmbContentsOfTheTank.Location = New System.Drawing.Point(247, 262)
        Me.cmbContentsOfTheTank.Name = "cmbContentsOfTheTank"
        Me.cmbContentsOfTheTank.Size = New System.Drawing.Size(208, 21)
        Me.cmbContentsOfTheTank.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "e.g. barrier wall (if not known put no)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "For each Tank:"
        '
        'gpbTankType
        '
        Me.gpbTankType.Controls.Add(Me.rdbTankTarWell)
        Me.gpbTankType.Controls.Add(Me.rdbGasHolder)
        Me.gpbTankType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTankType.Location = New System.Drawing.Point(247, 82)
        Me.gpbTankType.Name = "gpbTankType"
        Me.gpbTankType.Size = New System.Drawing.Size(208, 109)
        Me.gpbTankType.TabIndex = 60
        Me.gpbTankType.TabStop = False
        Me.gpbTankType.Text = "What is the tank type?"
        '
        'rdbTankTarWell
        '
        Me.rdbTankTarWell.AutoSize = True
        Me.rdbTankTarWell.Location = New System.Drawing.Point(45, 67)
        Me.rdbTankTarWell.Name = "rdbTankTarWell"
        Me.rdbTankTarWell.Size = New System.Drawing.Size(108, 17)
        Me.rdbTankTarWell.TabIndex = 1
        Me.rdbTankTarWell.TabStop = True
        Me.rdbTankTarWell.Text = "Tank/Tar Well"
        Me.rdbTankTarWell.UseVisualStyleBackColor = True
        '
        'rdbGasHolder
        '
        Me.rdbGasHolder.AutoSize = True
        Me.rdbGasHolder.Location = New System.Drawing.Point(45, 32)
        Me.rdbGasHolder.Name = "rdbGasHolder"
        Me.rdbGasHolder.Size = New System.Drawing.Size(88, 17)
        Me.rdbGasHolder.TabIndex = 0
        Me.rdbGasHolder.TabStop = True
        Me.rdbGasHolder.Text = "Gas Holder"
        Me.rdbGasHolder.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbIsolatedNO)
        Me.GroupBox1.Controls.Add(Me.rdbIsolatedYes)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 207)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 101)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Is the tank bounded or isolated?"
        '
        'rdbIsolatedNO
        '
        Me.rdbIsolatedNO.AutoSize = True
        Me.rdbIsolatedNO.Location = New System.Drawing.Point(81, 74)
        Me.rdbIsolatedNO.Name = "rdbIsolatedNO"
        Me.rdbIsolatedNO.Size = New System.Drawing.Size(41, 17)
        Me.rdbIsolatedNO.TabIndex = 1
        Me.rdbIsolatedNO.TabStop = True
        Me.rdbIsolatedNO.Text = "No"
        Me.rdbIsolatedNO.UseVisualStyleBackColor = True
        '
        'rdbIsolatedYes
        '
        Me.rdbIsolatedYes.AutoSize = True
        Me.rdbIsolatedYes.Location = New System.Drawing.Point(81, 47)
        Me.rdbIsolatedYes.Name = "rdbIsolatedYes"
        Me.rdbIsolatedYes.Size = New System.Drawing.Size(46, 17)
        Me.rdbIsolatedYes.TabIndex = 0
        Me.rdbIsolatedYes.TabStop = True
        Me.rdbIsolatedYes.Text = "Yes"
        Me.rdbIsolatedYes.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(199, 398)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 72
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(360, 355)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 23)
        Me.btnDelete.TabIndex = 80
        Me.btnDelete.Text = "Delete Tank"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(253, 355)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 23)
        Me.btnUpdate.TabIndex = 79
        Me.btnUpdate.Text = "Update Tank"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(360, 326)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(98, 23)
        Me.btnCommit.TabIndex = 78
        Me.btnCommit.Text = "Commit Changes"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(253, 326)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(93, 23)
        Me.btnAddNew.TabIndex = 77
        Me.btnAddNew.Text = "Add New Tank"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(10, 326)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(96, 23)
        Me.btnPrevious.TabIndex = 73
        Me.btnPrevious.Text = "Previous Tank"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(124, 355)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(95, 23)
        Me.btnLast.TabIndex = 76
        Me.btnLast.Text = "LastTank"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(123, 326)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(96, 23)
        Me.btnNext.TabIndex = 74
        Me.btnNext.Text = "Next Tank"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(10, 355)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(96, 23)
        Me.btnFirst.TabIndex = 75
        Me.btnFirst.Text = "First Tank"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.Label2.Location = New System.Drawing.Point(252, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Number of Tanks"
        '
        'txtNTanks
        '
        Me.txtNTanks.Cursor = System.Windows.Forms.Cursors.No
        Me.txtNTanks.Location = New System.Drawing.Point(369, 24)
        Me.txtNTanks.Name = "txtNTanks"
        Me.txtNTanks.Size = New System.Drawing.Size(86, 20)
        Me.txtNTanks.TabIndex = 82
        '
        'frmTanks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 433)
        Me.Controls.Add(Me.txtNTanks)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpbTankType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbContentsOfTheTank)
        Me.Controls.Add(Me.gpbTankLocation)
        Me.Controls.Add(Me.txtSiteCode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTanks"
        Me.Text = "List of Tanks"
        Me.gpbTankLocation.ResumeLayout(False)
        Me.gpbTankLocation.PerformLayout()
        Me.gpbTankType.ResumeLayout(False)
        Me.gpbTankType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpbTankLocation As System.Windows.Forms.GroupBox
    Friend WithEvents rdbBuried As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAtThesurface As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbContentsOfTheTank As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gpbTankType As System.Windows.Forms.GroupBox
    Friend WithEvents rdbTankTarWell As System.Windows.Forms.RadioButton
    Friend WithEvents rdbGasHolder As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbIsolatedNO As System.Windows.Forms.RadioButton
    Friend WithEvents rdbIsolatedYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNTanks As System.Windows.Forms.TextBox
End Class
