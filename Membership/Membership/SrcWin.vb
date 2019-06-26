Imports System
Imports System.IO.Ports
Imports MySql.Data.MySqlClient

Public Class SrcWin
    Dim Conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim Query As String
    Delegate Sub SetTextCallback(ByVal [text] As String)

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


    Private Sub SrcWin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = False

        connect.Enabled = False
        connect.BringToFront()

        Disconnect.Enabled = False
        Disconnect.SendToBack()

    End Sub
    Private Sub connect_Click(sender As Object, e As EventArgs) Handles connect.Click
        connect.Enabled = False
        connect.SendToBack()

        clr.Enabled = True

        SerialPort1.BaudRate = 9600
        SerialPort1.PortName = CmbPort.SelectedItem
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()

        Timer1.Enabled = True


        Disconnect.Enabled = True
        Disconnect.BringToFront()
    End Sub

    Private Sub port_Click(sender As Object, e As EventArgs) Handles port.Click
        CmbPort.Items.Clear()
        Dim myPort As Array
        Dim i As Integer

        myPort = IO.Ports.SerialPort.GetPortNames()
        CmbPort.Items.AddRange(myPort)
        i = CmbPort.Items.Count
        i = i - i

        Try
            CmbPort.SelectedIndex = i
        Catch ex As Exception
            Dim result As DialogResult
            result = MessageBox.Show("Com port not detected", "Warning!", MessageBoxButtons.OK)
            CmbPort.Text = ""
            Call SrcWin_Load(Me, e)
        End Try
        connect.Enabled = True
        connect.BringToFront()
        CmbPort.DroppedDown = True
    End Sub

    Private Sub Disconnect_Click(sender As Object, e As EventArgs) Handles Disconnect.Click
        Disconnect.Enabled = False
        connect.Enabled = True

        connect.BringToFront()
        Disconnect.SendToBack()

        Timer1.Enabled = False
        SerialPort1.Close()

        TextId.Text = ""
        TextName.Text = ""
        TextStat.Text = ""

    End Sub

    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        If Me.TextId.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.TextId.Text &= [text] 'append text
        End If
    End Sub

    Private Sub clr_Click(sender As Object, e As EventArgs) Handles clr.Click
        TextId.Text = ""
        TextName.Text = ""
        TextStat.Text = ""
    End Sub

End Class
