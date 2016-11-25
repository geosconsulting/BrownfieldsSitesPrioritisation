Public Class frmNuovaRef

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click

        NuovoTitolo = Me.txtNuovoTitolo.Text
        NuovoAutore = Me.txtNuovoAutore.Text
        NuovaData = Me.dtpNuovaData.Value

        frmMain.aggiungiRiga()
        Me.Close()
    End Sub

   
    Private Sub frmNuovaRef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class