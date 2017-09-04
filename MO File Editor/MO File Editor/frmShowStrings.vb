Public Class frmShowStrings


    Private Sub show_tb_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles show_tb.MouseDoubleClick
        Dim a = show_tb.GetLineFromCharIndex(show_tb.GetFirstCharIndexOfCurrentLine())
        show_tb.Select(show_tb.GetFirstCharIndexOfCurrentLine(), show_tb.Lines(a).Length)
        If show_tb.SelectionLength > 0 Then
            frmMain.search_tb.Text = show_tb.Lines(a)
        End If
    End Sub
End Class