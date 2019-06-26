Imports MySql.Data.MySqlClient

Public Class SrcWin
    Dim Conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim Query As String

    Private Sub SrcBtn_Click(sender As Object, e As EventArgs) Handles SrcBtn.Click
        Conn = New MySqlConnection
        Conn.ConnectionString = "server=localhost; userid=root; password=; database=membership"
        Conn.Open()

        Query = "SELECT nama, jenis_anggota FROM `membership` WHERE id = '" & TextId.Text & "'"
        COMMAND = New MySqlCommand(Query, Conn)

        Dim ADAPTER As New MySqlDataAdapter(COMMAND)
        Dim TABLE As New DataTable()
        ADAPTER.Fill(TABLE)
        TextName.Text = TABLE.Rows(0)(0).ToString()
        TextStat.Text = TABLE.Rows(0)(1).ToString()
        Conn.Close()
    End Sub

    Private Sub ExtBtn_Click(sender As Object, e As EventArgs) Handles ExtBtn.Click
        Me.Close()
    End Sub

    Private Sub TextId_TextChanged(sender As Object, e As EventArgs) Handles TextId.TextChanged

    End Sub
End Class
