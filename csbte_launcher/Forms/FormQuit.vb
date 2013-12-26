Public Class FormQuit

    Private Sub FormQuit_Closing(sender As Object, e As EventArgs) Handles Me.FormClosing
        FormMain.Enabled = True
    End Sub

    Private Sub CsoButton2_Click(sender As Object, e As EventArgs) Handles CsoButton2.Click
        Application.Exit()
    End Sub

    Private Sub CsoButton1_Click(sender As Object, e As EventArgs) Handles CsoButton1.Click
        Me.Close()
    End Sub
End Class