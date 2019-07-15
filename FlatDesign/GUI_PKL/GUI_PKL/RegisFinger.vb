Public Class RegisFinger
    Public Property NIMpass As String

    Private Sub RegisFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID.Text = NIMpass
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        Form1.Show()
        Hide()

    End Sub
End Class