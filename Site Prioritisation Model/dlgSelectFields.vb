Imports System.Data.OleDb

Public Class dlgSelectFields
    ' The DataGridView on the main form.
    Public TheDataGridView As DataGridView = Nothing

    ' Load the list of database fields.
    Private Sub dlgSelectFields_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Make sure TheDataGridView has been initialized.
        Debug.Assert(TheDataGridView IsNot Nothing, "TheDataGridView is Nothing")

        ' Set properties. (Done here so it's easier to find.)
        clbFields.CheckOnClick = True

        ' Fill the checked list box with the fields.
        clbFields.Items.Clear()
        For i As Integer = 0 To TheDataGridView.Columns.Count - 1
            clbFields.Items.Add(TheDataGridView.Columns(i).HeaderText)
            Dim checked As Boolean = TheDataGridView.Columns(i).Visible
            clbFields.SetItemChecked(i, checked)
        Next i
    End Sub

    ' Apply the user's selections to the DataGridView.
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        For i As Integer = 0 To TheDataGridView.Columns.Count - 1
            TheDataGridView.Columns(i).Visible = clbFields.GetItemChecked(i)
        Next i
    End Sub

    Private Sub clbFields_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbFields.SelectedIndexChanged

    End Sub
End Class