<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewer
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
        Me.dgvBoundaries = New System.Windows.Forms.DataGridView
        Me.btnScegliCampi = New System.Windows.Forms.Button
        Me.txtSiteCode_Viewer = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        CType(Me.dgvBoundaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBoundaries
        '
        Me.dgvBoundaries.AllowUserToAddRows = False
        Me.dgvBoundaries.AllowUserToDeleteRows = False
        Me.dgvBoundaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBoundaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBoundaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvBoundaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBoundaries.EnableHeadersVisualStyles = False
        Me.dgvBoundaries.Location = New System.Drawing.Point(13, 86)
        Me.dgvBoundaries.MultiSelect = False
        Me.dgvBoundaries.Name = "dgvBoundaries"
        Me.dgvBoundaries.ReadOnly = True
        Me.dgvBoundaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBoundaries.Size = New System.Drawing.Size(672, 380)
        Me.dgvBoundaries.TabIndex = 1
        '
        'btnScegliCampi
        '
        Me.btnScegliCampi.Location = New System.Drawing.Point(313, 26)
        Me.btnScegliCampi.Name = "btnScegliCampi"
        Me.btnScegliCampi.Size = New System.Drawing.Size(131, 23)
        Me.btnScegliCampi.TabIndex = 2
        Me.btnScegliCampi.Text = "Choose Fields"
        Me.btnScegliCampi.UseVisualStyleBackColor = True
        '
        'txtSiteCode_Viewer
        '
        Me.txtSiteCode_Viewer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiteCode_Viewer.ForeColor = System.Drawing.Color.Black
        Me.txtSiteCode_Viewer.Location = New System.Drawing.Point(12, 26)
        Me.txtSiteCode_Viewer.Name = "txtSiteCode_Viewer"
        Me.txtSiteCode_Viewer.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteCode_Viewer.TabIndex = 13
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
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(610, 26)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 53
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 515)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.txtSiteCode_Viewer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnScegliCampi)
        Me.Controls.Add(Me.dgvBoundaries)
        Me.Name = "frmViewer"
        Me.Text = "List of Boundaries"
        CType(Me.dgvBoundaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents dgvBoundaries As System.Windows.Forms.DataGridView
    Friend WithEvents btnScegliCampi As System.Windows.Forms.Button
    Friend WithEvents txtSiteCode_Viewer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button

End Class
