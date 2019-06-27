Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Management
Imports System.Collections.Generic
Imports System.Linq


Public Class Form1
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data
    Dim string1 As String
    Dim string2 As String
    Dim hasil As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = False

        connect.Enabled = True
        connect.BringToFront()

        Disconnect.Enabled = False
        Disconnect.SendToBack()

        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
            For Each queryObj As ManagementObject In searcher.Get()
                If InStr(queryObj("Name"), ("COM")) > 0 Then
                    If queryObj("Description") = "USB-SERIAL CH340" Then
                        string1 = queryObj("Description")
                        string2 = queryObj("Name")
                        hasil = string2.Replace(string1, "")
                        hasil = hasil.Replace("(", "")
                        hasil = hasil.Replace(")", "")
                        hasil = hasil.Replace(" ", "")
                    End If
                End If
            Next
        Catch err As ManagementException
            MsgBox(err.Message)
        End Try

        If string1 = "USB-SERIAL CH340" Then
            SerialPort1.BaudRate = 9600
            SerialPort1.PortName = hasil
            SerialPort1.DataBits = 8
            SerialPort1.Parity = Parity.None
            SerialPort1.StopBits = StopBits.One
            SerialPort1.Handshake = Handshake.None
            SerialPort1.Encoding = System.Text.Encoding.Default
            SerialPort1.Open()

            Timer1.Enabled = True

            Disconnect.Enabled = True
            Disconnect.BringToFront()
        End If


    End Sub

    Private Sub connect_Click(sender As Object, e As EventArgs) Handles connect.Click
        connect.Enabled = False
        connect.SendToBack()

        clr.Enabled = True



    End Sub

    Private Sub port_Click(sender As Object, e As EventArgs) Handles port.Click
        GetAllSerialPortsName()

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
            Call Form1_Load(Me, e)
        End Try

        connect.Enabled = True
        connect.BringToFront()
        CmbPort.DroppedDown = True
    End Sub

    Private Sub GetAllSerialPortsName()

    End Sub

    Private Sub Disconnect_Click(sender As Object, e As EventArgs) Handles Disconnect.Click
        Disconnect.Enabled = False
        connect.Enabled = True

        connect.BringToFront()
        Disconnect.SendToBack()

        Timer1.Enabled = False
        SerialPort1.Close()
    End Sub

    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
    End Sub

    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        If Me.write.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.write.Text &= [text] 'append text
        End If
    End Sub

    Private Sub clr_Click(sender As Object, e As EventArgs) Handles clr.Click
        write.Text = ""
        Process.Start("http://127.0.0.1/loginsystem/view.php")

    End Sub

    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click
        SerialPort1.Write("write" & "#")
        write.SendToBack()
        Button1.BringToFront()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Write(read.Text & "*")
        Button1.SendToBack()
        write.BringToFront()
        read.Text = ""
    End Sub

End Class
