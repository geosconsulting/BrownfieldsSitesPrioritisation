<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCommitting
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
        Me.components = New System.ComponentModel.Container
        Me.ProgressBarCommittingChanges = New System.Windows.Forms.ProgressBar
        Me.lblCommittingChanges = New System.Windows.Forms.Label
        Me.TimerCommitting = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ProgressBarCommittingChanges
        '
        Me.ProgressBarCommittingChanges.Location = New System.Drawing.Point(192, 28)
        Me.ProgressBarCommittingChanges.Name = "ProgressBarCommittingChanges"
        Me.ProgressBarCommittingChanges.Size = New System.Drawing.Size(228, 19)
        Me.ProgressBarCommittingChanges.TabIndex = 1
        '
        'lblCommittingChanges
        '
        Me.lblCommittingChanges.AutoSize = True
        Me.lblCommittingChanges.Location = New System.Drawing.Point(10, 31)
        Me.lblCommittingChanges.Name = "lblCommittingChanges"
        Me.lblCommittingChanges.Size = New System.Drawing.Size(114, 13)
        Me.lblCommittingChanges.TabIndex = 2
        Me.lblCommittingChanges.Text = "Committing changes...."
        '
        'TimerCommitting
        '
        '
        'dlgCommitting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 84)
        Me.Controls.Add(Me.lblCommittingChanges)
        Me.Controls.Add(Me.ProgressBarCommittingChanges)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCommitting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBarCommittingChanges As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCommittingChanges As System.Windows.Forms.Label
    Friend WithEvents TimerCommitting As System.Windows.Forms.Timer

End Class
