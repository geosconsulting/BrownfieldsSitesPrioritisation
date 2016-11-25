Imports System.Windows.Forms

Public Class dlgCommitting

    Private Sub dlgCommitting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Select Case identificaFormChiamante
            Case "SiteBoundaries"
                frmBoundaries.Show()
            Case "SurfaceDeposit"
                frmSurfaceDeposit.Show()
            Case "Tanks"
                frmTanks.Show()
            Case "AbstractionBoreholes"
                frmAbstractionBoreholes.Show()
            Case "RiskAssessment"
                frmRiskAssessment.Show()
        End Select
    End Sub

    Private Sub dlgCommitting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'When the form loads, set the timer and set progressbar to 0
            TimerCommitting.Enabled = True
            ProgressBarCommittingChanges.Value = 0
            Me.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub TimerCommitting_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerCommitting.Tick
        If ProgressBarCommittingChanges.Value <> ProgressBarCommittingChanges.Maximum Then
            ProgressBarCommittingChanges.Value = ProgressBarCommittingChanges.Value + 25
            lblCommittingChanges.Text = "Committing changes " & ProgressBarCommittingChanges.Value & " % Complete"
            If ProgressBarCommittingChanges.Value = 100 Then
                TimerCommitting.Enabled = False
                Me.Close()
            End If
        End If
    End Sub
End Class
