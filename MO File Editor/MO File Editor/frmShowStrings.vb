Public Class frmShowStrings


    Private Sub show_tb_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles show_tb.MouseDoubleClick
        If show_tb.SelectionLength > 0 Then
            Dim s = show_tb.SelectedText
            frmMain.search_tb.Text = s
        End If
    End Sub
End Class