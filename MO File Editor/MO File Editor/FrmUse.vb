Public Class FrmUse

    Private Sub use_btn_Click(sender As Object, e As EventArgs) Handles use_btn.Click
        Me.Hide()
    End Sub

    Private Sub FrmUse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub
End Class