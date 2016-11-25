<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoundaries
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.txtSiteCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkBoundaryInfoYES = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbFacingDirection = New System.Windows.Forms.ComboBox
        Me.grp_InfoBoundary = New System.Windows.Forms.GroupBox
        Me.txtHeight = New System.Windows.Forms.MaskedTextBox
        Me.txtLength = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbBoundaryGradient = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBoundaryConstruction = New System.Windows.Forms.ComboBox
        Me.gpbBoundaryASBarrier = New System.Windows.Forms.GroupBox
        Me.rdbSubSurfaceLateralFlow_NK = New System.Windows.Forms.RadioButton
        Me.rdbSubSurfaceLateralFlow_No = New System.Windows.Forms.RadioButton
        Me.rdbSubSurfaceLateralFlow_Yes = New System.Windows.Forms.RadioButton
        Me.chkAirborneDust = New System.Windows.Forms.CheckBox
        Me.chkTrespassing = New System.Windows.Forms.CheckBox
        Me.chkRunOFF = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbProximal = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbAdjacent = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkFormerGasworks = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCommit = New System.Windows.Forms.Button
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.ToolTipLength_Height = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbAdjacentOther = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtLandUseAdjacent = New System.Windows.Forms.TextBox
        Me.gpbProximalOther = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtLandUseProximal = New System.Windows.Forms.TextBox
        Me.txtNBoundariesCalc = New System.Windows.Forms.TextBox
        Me.ToolTipNBoundaries = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTipNBoundariesCalc = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbAdjacentHumanSensitivity = New System.Windows.Forms.GroupBox
        Me.rdbHumanSensitivityAdj_High = New System.Windows.Forms.RadioButton
        Me.rdbHumanSensitivityAdj_Medium = New System.Windows.Forms.RadioButton
        Me.rdbHumanSensitivityAdj_LOW = New System.Windows.Forms.RadioButton
        Me.gpbProximalHumanSensitivity = New System.Windows.Forms.GroupBox
        Me.rdbHumanSensitivityProx_High = New System.Windows.Forms.RadioButton
        Me.rdbHumanSensitivityProx_Medium = New System.Windows.Forms.RadioButton
        Me.rdbHumanSensitivityProx_Low = New System.Windows.Forms.RadioButton
        Me.grp_InfoBoundary.SuspendLayout()
        Me.gpbBoundaryASBarrier.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gpbAdjacentOther.SuspendLayout()
        Me.gpbProximalOther.SuspendLayout()
        Me.gpbAdjacentHumanSensitivity.SuspendLayout()
        Me.gpbProximalHumanSensitivity.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSiteCode
        '
        Me.txtSiteCode.Cursor = System.Windows.Forms.Cursors.No
        Me.txtSiteCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode.Location = New System.Drawing.Point(12, 26)
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Site Code"
        '
        'chkBoundaryInfoYES
        '
        Me.chkBoundaryInfoYES.AutoSize = True
        Me.chkBoundaryInfoYES.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkBoundaryInfoYES.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkBoundaryInfoYES.Location = New System.Drawing.Point(223, 71)
        Me.chkBoundaryInfoYES.Name = "chkBoundaryInfoYES"
        Me.chkBoundaryInfoYES.Size = New System.Drawing.Size(44, 17)
        Me.chkBoundaryInfoYES.TabIndex = 36
        Me.chkBoundaryInfoYES.Text = "Yes"
        Me.chkBoundaryInfoYES.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkBoundaryInfoYES.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 32)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Is there any information" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for this boundary section?"
        '
        'cmbFacingDirection
        '
        Me.cmbFacingDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacingDirection.FormattingEnabled = True
        Me.cmbFacingDirection.Location = New System.Drawing.Point(6, 36)
        Me.cmbFacingDirection.Name = "cmbFacingDirection"
        Me.cmbFacingDirection.Size = New System.Drawing.Size(150, 21)
        Me.cmbFacingDirection.TabIndex = 37
        '
        'grp_InfoBoundary
        '
        Me.grp_InfoBoundary.Controls.Add(Me.txtHeight)
        Me.grp_InfoBoundary.Controls.Add(Me.txtLength)
        Me.grp_InfoBoundary.Controls.Add(Me.Label16)
        Me.grp_InfoBoundary.Controls.Add(Me.Label6)
        Me.grp_InfoBoundary.Controls.Add(Me.Label5)
        Me.grp_InfoBoundary.Controls.Add(Me.cmbBoundaryGradient)
        Me.grp_InfoBoundary.Controls.Add(Me.Label4)
        Me.grp_InfoBoundary.Controls.Add(Me.Label3)
        Me.grp_InfoBoundary.Controls.Add(Me.cmbBoundaryConstruction)
        Me.grp_InfoBoundary.Controls.Add(Me.cmbFacingDirection)
        Me.grp_InfoBoundary.Enabled = False
        Me.grp_InfoBoundary.Location = New System.Drawing.Point(13, 94)
        Me.grp_InfoBoundary.Name = "grp_InfoBoundary"
        Me.grp_InfoBoundary.Size = New System.Drawing.Size(337, 121)
        Me.grp_InfoBoundary.TabIndex = 40
        Me.grp_InfoBoundary.TabStop = False
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(252, 37)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(74, 20)
        Me.txtHeight.TabIndex = 39
        Me.ToolTipLength_Height.SetToolTip(Me.txtHeight, "Only numbers (0-9) no spaces or characters")
        '
        'txtLength
        '
        Me.txtLength.Location = New System.Drawing.Point(172, 36)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(74, 20)
        Me.txtLength.TabIndex = 38
        Me.ToolTipLength_Height.SetToolTip(Me.txtLength, "Only numbers (0-9) no spaces or characters")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(262, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 16)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Height"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(180, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Length"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(169, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Gradient"
        '
        'cmbBoundaryGradient
        '
        Me.cmbBoundaryGradient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBoundaryGradient.FormattingEnabled = True
        Me.cmbBoundaryGradient.Location = New System.Drawing.Point(172, 91)
        Me.cmbBoundaryGradient.Name = "cmbBoundaryGradient"
        Me.cmbBoundaryGradient.Size = New System.Drawing.Size(154, 21)
        Me.cmbBoundaryGradient.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 16)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Boundary Construction"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Facing Direction"
        '
        'cmbBoundaryConstruction
        '
        Me.cmbBoundaryConstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBoundaryConstruction.FormattingEnabled = True
        Me.cmbBoundaryConstruction.Location = New System.Drawing.Point(6, 91)
        Me.cmbBoundaryConstruction.Name = "cmbBoundaryConstruction"
        Me.cmbBoundaryConstruction.Size = New System.Drawing.Size(150, 21)
        Me.cmbBoundaryConstruction.TabIndex = 40
        '
        'gpbBoundaryASBarrier
        '
        Me.gpbBoundaryASBarrier.Controls.Add(Me.rdbSubSurfaceLateralFlow_NK)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.rdbSubSurfaceLateralFlow_No)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.rdbSubSurfaceLateralFlow_Yes)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.chkAirborneDust)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.chkTrespassing)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.chkRunOFF)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.Label7)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.Label8)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.Label9)
        Me.gpbBoundaryASBarrier.Controls.Add(Me.Label10)
        Me.gpbBoundaryASBarrier.Enabled = False
        Me.gpbBoundaryASBarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbBoundaryASBarrier.Location = New System.Drawing.Point(12, 224)
        Me.gpbBoundaryASBarrier.Name = "gpbBoundaryASBarrier"
        Me.gpbBoundaryASBarrier.Size = New System.Drawing.Size(338, 158)
        Me.gpbBoundaryASBarrier.TabIndex = 47
        Me.gpbBoundaryASBarrier.TabStop = False
        Me.gpbBoundaryASBarrier.Text = "Will this boundary act as a barrier to:"
        '
        'rdbSubSurfaceLateralFlow_NK
        '
        Me.rdbSubSurfaceLateralFlow_NK.AutoSize = True
        Me.rdbSubSurfaceLateralFlow_NK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbSubSurfaceLateralFlow_NK.Location = New System.Drawing.Point(245, 137)
        Me.rdbSubSurfaceLateralFlow_NK.Name = "rdbSubSurfaceLateralFlow_NK"
        Me.rdbSubSurfaceLateralFlow_NK.Size = New System.Drawing.Size(78, 17)
        Me.rdbSubSurfaceLateralFlow_NK.TabIndex = 53
        Me.rdbSubSurfaceLateralFlow_NK.TabStop = True
        Me.rdbSubSurfaceLateralFlow_NK.Text = "Not Known"
        Me.rdbSubSurfaceLateralFlow_NK.UseVisualStyleBackColor = True
        '
        'rdbSubSurfaceLateralFlow_No
        '
        Me.rdbSubSurfaceLateralFlow_No.AutoSize = True
        Me.rdbSubSurfaceLateralFlow_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbSubSurfaceLateralFlow_No.Location = New System.Drawing.Point(246, 117)
        Me.rdbSubSurfaceLateralFlow_No.Name = "rdbSubSurfaceLateralFlow_No"
        Me.rdbSubSurfaceLateralFlow_No.Size = New System.Drawing.Size(39, 17)
        Me.rdbSubSurfaceLateralFlow_No.TabIndex = 52
        Me.rdbSubSurfaceLateralFlow_No.TabStop = True
        Me.rdbSubSurfaceLateralFlow_No.Text = "No"
        Me.rdbSubSurfaceLateralFlow_No.UseVisualStyleBackColor = True
        '
        'rdbSubSurfaceLateralFlow_Yes
        '
        Me.rdbSubSurfaceLateralFlow_Yes.AutoSize = True
        Me.rdbSubSurfaceLateralFlow_Yes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbSubSurfaceLateralFlow_Yes.Location = New System.Drawing.Point(246, 97)
        Me.rdbSubSurfaceLateralFlow_Yes.Name = "rdbSubSurfaceLateralFlow_Yes"
        Me.rdbSubSurfaceLateralFlow_Yes.Size = New System.Drawing.Size(43, 17)
        Me.rdbSubSurfaceLateralFlow_Yes.TabIndex = 51
        Me.rdbSubSurfaceLateralFlow_Yes.TabStop = True
        Me.rdbSubSurfaceLateralFlow_Yes.Text = "Yes"
        Me.rdbSubSurfaceLateralFlow_Yes.UseVisualStyleBackColor = True
        '
        'chkAirborneDust
        '
        Me.chkAirborneDust.AutoSize = True
        Me.chkAirborneDust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkAirborneDust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAirborneDust.Location = New System.Drawing.Point(246, 71)
        Me.chkAirborneDust.Name = "chkAirborneDust"
        Me.chkAirborneDust.Size = New System.Drawing.Size(44, 17)
        Me.chkAirborneDust.TabIndex = 50
        Me.chkAirborneDust.Text = "Yes"
        Me.chkAirborneDust.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkAirborneDust.UseVisualStyleBackColor = True
        '
        'chkTrespassing
        '
        Me.chkTrespassing.AutoSize = True
        Me.chkTrespassing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkTrespassing.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTrespassing.Location = New System.Drawing.Point(246, 47)
        Me.chkTrespassing.Name = "chkTrespassing"
        Me.chkTrespassing.Size = New System.Drawing.Size(44, 17)
        Me.chkTrespassing.TabIndex = 49
        Me.chkTrespassing.Text = "Yes"
        Me.chkTrespassing.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkTrespassing.UseVisualStyleBackColor = True
        '
        'chkRunOFF
        '
        Me.chkRunOFF.AutoSize = True
        Me.chkRunOFF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkRunOFF.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRunOFF.Location = New System.Drawing.Point(246, 20)
        Me.chkRunOFF.Name = "chkRunOFF"
        Me.chkRunOFF.Size = New System.Drawing.Size(44, 17)
        Me.chkRunOFF.TabIndex = 48
        Me.chkRunOFF.Text = "Yes"
        Me.chkRunOFF.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkRunOFF.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Trespassing?"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 16)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Sub-surface Lateral Flow?"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 16)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Airborne Dusts?"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 16)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Surface Run-off?"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cmbProximal)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.cmbAdjacent)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(364, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(334, 86)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Surrounding Land Use"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(169, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Proximal"
        '
        'cmbProximal
        '
        Me.cmbProximal.FormattingEnabled = True
        Me.cmbProximal.Location = New System.Drawing.Point(172, 47)
        Me.cmbProximal.Name = "cmbProximal"
        Me.cmbProximal.Size = New System.Drawing.Size(154, 21)
        Me.cmbProximal.TabIndex = 44
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Adjacent"
        '
        'cmbAdjacent
        '
        Me.cmbAdjacent.FormattingEnabled = True
        Me.cmbAdjacent.Location = New System.Drawing.Point(6, 46)
        Me.cmbAdjacent.Name = "cmbAdjacent"
        Me.cmbAdjacent.Size = New System.Drawing.Size(150, 21)
        Me.cmbAdjacent.TabIndex = 37
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkFormerGasworks)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(367, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(334, 76)
        Me.GroupBox4.TabIndex = 52
        Me.GroupBox4.TabStop = False
        '
        'chkFormerGasworks
        '
        Me.chkFormerGasworks.AutoSize = True
        Me.chkFormerGasworks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkFormerGasworks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFormerGasworks.Location = New System.Drawing.Point(267, 31)
        Me.chkFormerGasworks.Name = "chkFormerGasworks"
        Me.chkFormerGasworks.Size = New System.Drawing.Size(44, 17)
        Me.chkFormerGasworks.TabIndex = 48
        Me.chkFormerGasworks.Text = "Yes"
        Me.chkFormerGasworks.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkFormerGasworks.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(163, 32)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Is the adjacent  land part" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of a former gasworks site?"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(603, 415)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 53
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(434, 427)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(105, 23)
        Me.btnDelete.TabIndex = 61
        Me.btnDelete.Text = "Delete Boundary"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(306, 427)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 23)
        Me.btnUpdate.TabIndex = 60
        Me.btnUpdate.Text = "Update Boundary"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(435, 398)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(105, 23)
        Me.btnCommit.TabIndex = 59
        Me.btnCommit.Text = "Commit Changes"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(306, 398)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 23)
        Me.btnAddNew.TabIndex = 58
        Me.btnAddNew.Text = "Add New Boundary"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(157, 428)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(105, 23)
        Me.btnLast.TabIndex = 57
        Me.btnLast.Text = "Last Boundary"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(31, 428)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(112, 23)
        Me.btnFirst.TabIndex = 56
        Me.btnFirst.Text = "First Boundary"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(156, 399)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(105, 23)
        Me.btnNext.TabIndex = 55
        Me.btnNext.Text = "Next Boundary"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(31, 399)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(112, 23)
        Me.btnPrevious.TabIndex = 54
        Me.btnPrevious.Text = "Previous Boundary"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(217, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 16)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "N of boundaries"
        '
        'gpbAdjacentOther
        '
        Me.gpbAdjacentOther.Controls.Add(Me.Label15)
        Me.gpbAdjacentOther.Controls.Add(Me.txtLandUseAdjacent)
        Me.gpbAdjacentOther.Enabled = False
        Me.gpbAdjacentOther.Location = New System.Drawing.Point(367, 186)
        Me.gpbAdjacentOther.Name = "gpbAdjacentOther"
        Me.gpbAdjacentOther.Size = New System.Drawing.Size(153, 75)
        Me.gpbAdjacentOther.TabIndex = 64
        Me.gpbAdjacentOther.TabStop = False
        Me.gpbAdjacentOther.Text = "If ""Other"", please state:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 16)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "1) Land use"
        '
        'txtLandUseAdjacent
        '
        Me.txtLandUseAdjacent.Location = New System.Drawing.Point(5, 45)
        Me.txtLandUseAdjacent.Name = "txtLandUseAdjacent"
        Me.txtLandUseAdjacent.Size = New System.Drawing.Size(142, 20)
        Me.txtLandUseAdjacent.TabIndex = 65
        '
        'gpbProximalOther
        '
        Me.gpbProximalOther.Controls.Add(Me.Label19)
        Me.gpbProximalOther.Controls.Add(Me.txtLandUseProximal)
        Me.gpbProximalOther.Enabled = False
        Me.gpbProximalOther.Location = New System.Drawing.Point(536, 186)
        Me.gpbProximalOther.Name = "gpbProximalOther"
        Me.gpbProximalOther.Size = New System.Drawing.Size(162, 75)
        Me.gpbProximalOther.TabIndex = 65
        Me.gpbProximalOther.TabStop = False
        Me.gpbProximalOther.Text = "If ""Other"", please state:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(9, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 16)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "1) Land use"
        '
        'txtLandUseProximal
        '
        Me.txtLandUseProximal.Location = New System.Drawing.Point(4, 45)
        Me.txtLandUseProximal.Name = "txtLandUseProximal"
        Me.txtLandUseProximal.Size = New System.Drawing.Size(150, 20)
        Me.txtLandUseProximal.TabIndex = 74
        '
        'txtNBoundariesCalc
        '
        Me.txtNBoundariesCalc.Cursor = System.Windows.Forms.Cursors.No
        Me.txtNBoundariesCalc.Location = New System.Drawing.Point(220, 26)
        Me.txtNBoundariesCalc.Name = "txtNBoundariesCalc"
        Me.txtNBoundariesCalc.Size = New System.Drawing.Size(130, 20)
        Me.txtNBoundariesCalc.TabIndex = 66
        Me.ToolTipNBoundaries.SetToolTip(Me.txtNBoundariesCalc, "Inserted Until now")
        '
        'gpbAdjacentHumanSensitivity
        '
        Me.gpbAdjacentHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityAdj_High)
        Me.gpbAdjacentHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityAdj_Medium)
        Me.gpbAdjacentHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityAdj_LOW)
        Me.gpbAdjacentHumanSensitivity.Enabled = False
        Me.gpbAdjacentHumanSensitivity.Location = New System.Drawing.Point(370, 271)
        Me.gpbAdjacentHumanSensitivity.Name = "gpbAdjacentHumanSensitivity"
        Me.gpbAdjacentHumanSensitivity.Size = New System.Drawing.Size(150, 111)
        Me.gpbAdjacentHumanSensitivity.TabIndex = 67
        Me.gpbAdjacentHumanSensitivity.TabStop = False
        Me.gpbAdjacentHumanSensitivity.Text = "2) Human sensitivity"
        '
        'rdbHumanSensitivityAdj_High
        '
        Me.rdbHumanSensitivityAdj_High.AutoSize = True
        Me.rdbHumanSensitivityAdj_High.Location = New System.Drawing.Point(44, 79)
        Me.rdbHumanSensitivityAdj_High.Name = "rdbHumanSensitivityAdj_High"
        Me.rdbHumanSensitivityAdj_High.Size = New System.Drawing.Size(47, 17)
        Me.rdbHumanSensitivityAdj_High.TabIndex = 77
        Me.rdbHumanSensitivityAdj_High.TabStop = True
        Me.rdbHumanSensitivityAdj_High.Text = "High"
        Me.rdbHumanSensitivityAdj_High.UseVisualStyleBackColor = True
        '
        'rdbHumanSensitivityAdj_Medium
        '
        Me.rdbHumanSensitivityAdj_Medium.AutoSize = True
        Me.rdbHumanSensitivityAdj_Medium.Location = New System.Drawing.Point(44, 53)
        Me.rdbHumanSensitivityAdj_Medium.Name = "rdbHumanSensitivityAdj_Medium"
        Me.rdbHumanSensitivityAdj_Medium.Size = New System.Drawing.Size(62, 17)
        Me.rdbHumanSensitivityAdj_Medium.TabIndex = 76
        Me.rdbHumanSensitivityAdj_Medium.TabStop = True
        Me.rdbHumanSensitivityAdj_Medium.Text = "Medium"
        Me.rdbHumanSensitivityAdj_Medium.UseVisualStyleBackColor = True
        '
        'rdbHumanSensitivityAdj_LOW
        '
        Me.rdbHumanSensitivityAdj_LOW.AutoSize = True
        Me.rdbHumanSensitivityAdj_LOW.Location = New System.Drawing.Point(44, 27)
        Me.rdbHumanSensitivityAdj_LOW.Name = "rdbHumanSensitivityAdj_LOW"
        Me.rdbHumanSensitivityAdj_LOW.Size = New System.Drawing.Size(45, 17)
        Me.rdbHumanSensitivityAdj_LOW.TabIndex = 75
        Me.rdbHumanSensitivityAdj_LOW.TabStop = True
        Me.rdbHumanSensitivityAdj_LOW.Text = "Low"
        Me.rdbHumanSensitivityAdj_LOW.UseVisualStyleBackColor = True
        '
        'gpbProximalHumanSensitivity
        '
        Me.gpbProximalHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityProx_High)
        Me.gpbProximalHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityProx_Medium)
        Me.gpbProximalHumanSensitivity.Controls.Add(Me.rdbHumanSensitivityProx_Low)
        Me.gpbProximalHumanSensitivity.Enabled = False
        Me.gpbProximalHumanSensitivity.Location = New System.Drawing.Point(536, 271)
        Me.gpbProximalHumanSensitivity.Name = "gpbProximalHumanSensitivity"
        Me.gpbProximalHumanSensitivity.Size = New System.Drawing.Size(162, 111)
        Me.gpbProximalHumanSensitivity.TabIndex = 68
        Me.gpbProximalHumanSensitivity.TabStop = False
        Me.gpbProximalHumanSensitivity.Text = "2) Human sensitivity"
        '
        'rdbHumanSensitivityProx_High
        '
        Me.rdbHumanSensitivityProx_High.AutoSize = True
        Me.rdbHumanSensitivityProx_High.Location = New System.Drawing.Point(50, 78)
        Me.rdbHumanSensitivityProx_High.Name = "rdbHumanSensitivityProx_High"
        Me.rdbHumanSensitivityProx_High.Size = New System.Drawing.Size(47, 17)
        Me.rdbHumanSensitivityProx_High.TabIndex = 81
        Me.rdbHumanSensitivityProx_High.TabStop = True
        Me.rdbHumanSensitivityProx_High.Text = "High"
        Me.rdbHumanSensitivityProx_High.UseVisualStyleBackColor = True
        '
        'rdbHumanSensitivityProx_Medium
        '
        Me.rdbHumanSensitivityProx_Medium.AutoSize = True
        Me.rdbHumanSensitivityProx_Medium.Location = New System.Drawing.Point(50, 53)
        Me.rdbHumanSensitivityProx_Medium.Name = "rdbHumanSensitivityProx_Medium"
        Me.rdbHumanSensitivityProx_Medium.Size = New System.Drawing.Size(62, 17)
        Me.rdbHumanSensitivityProx_Medium.TabIndex = 80
        Me.rdbHumanSensitivityProx_Medium.TabStop = True
        Me.rdbHumanSensitivityProx_Medium.Text = "Medium"
        Me.rdbHumanSensitivityProx_Medium.UseVisualStyleBackColor = True
        '
        'rdbHumanSensitivityProx_Low
        '
        Me.rdbHumanSensitivityProx_Low.AutoSize = True
        Me.rdbHumanSensitivityProx_Low.Location = New System.Drawing.Point(50, 28)
        Me.rdbHumanSensitivityProx_Low.Name = "rdbHumanSensitivityProx_Low"
        Me.rdbHumanSensitivityProx_Low.Size = New System.Drawing.Size(45, 17)
        Me.rdbHumanSensitivityProx_Low.TabIndex = 79
        Me.rdbHumanSensitivityProx_Low.TabStop = True
        Me.rdbHumanSensitivityProx_Low.Text = "Low"
        Me.rdbHumanSensitivityProx_Low.UseVisualStyleBackColor = True
        '
        'frmBoundaries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 467)
        Me.Controls.Add(Me.gpbProximalHumanSensitivity)
        Me.Controls.Add(Me.gpbAdjacentHumanSensitivity)
        Me.Controls.Add(Me.txtNBoundariesCalc)
        Me.Controls.Add(Me.gpbProximalOther)
        Me.Controls.Add(Me.gpbAdjacentOther)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gpbBoundaryASBarrier)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.chkBoundaryInfoYES)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.txtSiteCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.grp_InfoBoundary)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnFirst)
        Me.Name = "frmBoundaries"
        Me.Text = "List of Boundaries"
        Me.grp_InfoBoundary.ResumeLayout(False)
        Me.grp_InfoBoundary.PerformLayout()
        Me.gpbBoundaryASBarrier.ResumeLayout(False)
        Me.gpbBoundaryASBarrier.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gpbAdjacentOther.ResumeLayout(False)
        Me.gpbAdjacentOther.PerformLayout()
        Me.gpbProximalOther.ResumeLayout(False)
        Me.gpbProximalOther.PerformLayout()
        Me.gpbAdjacentHumanSensitivity.ResumeLayout(False)
        Me.gpbAdjacentHumanSensitivity.PerformLayout()
        Me.gpbProximalHumanSensitivity.ResumeLayout(False)
        Me.gpbProximalHumanSensitivity.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtSiteCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkBoundaryInfoYES As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFacingDirection As System.Windows.Forms.ComboBox
    Friend WithEvents grp_InfoBoundary As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbBoundaryGradient As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBoundaryConstruction As System.Windows.Forms.ComboBox
    Friend WithEvents gpbBoundaryASBarrier As System.Windows.Forms.GroupBox
    Friend WithEvents chkAirborneDust As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrespassing As System.Windows.Forms.CheckBox
    Friend WithEvents chkRunOFF As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbProximal As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbAdjacent As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFormerGasworks As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents rdbSubSurfaceLateralFlow_NK As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSubSurfaceLateralFlow_No As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSubSurfaceLateralFlow_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLength As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTipLength_Height As System.Windows.Forms.ToolTip
    Friend WithEvents gpbAdjacentOther As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtLandUseAdjacent As System.Windows.Forms.TextBox
    Friend WithEvents gpbProximalOther As System.Windows.Forms.GroupBox
    Friend WithEvents txtLandUseProximal As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtNBoundariesCalc As System.Windows.Forms.TextBox
    Friend WithEvents ToolTipNBoundaries As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTipNBoundariesCalc As System.Windows.Forms.ToolTip
    Friend WithEvents gpbAdjacentHumanSensitivity As System.Windows.Forms.GroupBox
    Friend WithEvents gpbProximalHumanSensitivity As System.Windows.Forms.GroupBox
    Friend WithEvents rdbHumanSensitivityProx_High As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHumanSensitivityProx_Medium As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHumanSensitivityProx_Low As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHumanSensitivityAdj_High As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHumanSensitivityAdj_Medium As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHumanSensitivityAdj_LOW As System.Windows.Forms.RadioButton

End Class
