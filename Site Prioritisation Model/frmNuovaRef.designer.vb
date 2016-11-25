<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuovaRef
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
        Me.txtNuovoTitolo = New System.Windows.Forms.TextBox
        Me.txtNuovoAutore = New System.Windows.Forms.TextBox
        Me.btnAggiungi = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpNuovaData = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtNuovoTitolo
        '
        Me.txtNuovoTitolo.Location = New System.Drawing.Point(58, 28)
        Me.txtNuovoTitolo.Name = "txtNuovoTitolo"
        Me.txtNuovoTitolo.Size = New System.Drawing.Size(187, 20)
        Me.txtNuovoTitolo.TabIndex = 0
        '
        'txtNuovoAutore
        '
        Me.txtNuovoAutore.Location = New System.Drawing.Point(58, 69)
        Me.txtNuovoAutore.Name = "txtNuovoAutore"
        Me.txtNuovoAutore.Size = New System.Drawing.Size(187, 20)
        Me.txtNuovoAutore.TabIndex = 1
        '
        'btnAggiungi
        '
        Me.btnAggiungi.Location = New System.Drawing.Point(92, 167)
        Me.btnAggiungi.Name = "btnAggiungi"
        Me.btnAggiungi.Size = New System.Drawing.Size(75, 23)
        Me.btnAggiungi.TabIndex = 3
        Me.btnAggiungi.Text = "Add"
        Me.btnAggiungi.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Title"
        '
        'dtpNuovaData
        '
        Me.dtpNuovaData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNuovaData.Location = New System.Drawing.Point(58, 117)
        Me.dtpNuovaData.Name = "dtpNuovaData"
        Me.dtpNuovaData.Size = New System.Drawing.Size(187, 20)
        Me.dtpNuovaData.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Author"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Date"
        '
        'frmNuovaRef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 213)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpNuovaData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAggiungi)
        Me.Controls.Add(Me.txtNuovoAutore)
        Me.Controls.Add(Me.txtNuovoTitolo)
        Me.Name = "frmNuovaRef"
        Me.Text = "Add Reference"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNuovoTitolo As System.Windows.Forms.TextBox
    Friend WithEvents txtNuovoAutore As System.Windows.Forms.TextBox
    Friend WithEvents btnAggiungi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpNuovaData As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
