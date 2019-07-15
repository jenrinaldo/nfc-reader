Public Class RegisFinger
    Public Property NIMpass As String

    Private Sub RegisFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID.Text = NIMpass
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Form1.Show()
    End Sub
End Class