Imports System.IO.Ports
Imports System.Management
Imports System.Text.RegularExpressions
Imports System.Media
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim reader As MySqlDataReader
    Dim Conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim Query As String
    Dim string1 As String
    Dim string2 As String
    Dim hasil As String
    Dim baudrate As String = "9600"
    Dim waktu As Integer = 0
    Dim numbers As String = "1234567890"
    Dim Flag As Integer
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fingerprint.Enabled = False
        RFID.Enabled = False
        NIM.Enabled = False

        Timer1.Enabled = True
        Timer3.Enabled = False

        BtnCon.Enabled = False
        Write.Enabled = False
        Read.Enabled = False

        PnlWrite.Hide()
        PanelWrite.Hide()

        PnlRead.Hide()
        PanelRead.Hide()

        TxtNIM_Write.Text = ""

        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "Select * FROM Win32_PnPEntity")
            For Each queryObj As ManagementObject In searcher.Get()
                If InStr(queryObj("Name"), ("COM")) > 0 Then
                    If queryObj("Description") = "USB-SERIAL CH340" Then
                        string1 = queryObj("Description")
                        string2 = queryObj("Name")
                        hasil = string2.Replace(string1, "")
                        hasil = hasil.Replace("(", "")
                        hasil = hasil.Replace(")", "")
                        hasil = hasil.Replace(" ", "")
                        If string1 = "USB-SERIAL CH340" Then
                            SerialPort1.BaudRate = baudrate
                            SerialPort1.PortName = hasil
                            SerialPort1.Parity = Parity.None
                            SerialPort1.StopBits = StopBits.One
                            SerialPort1.Handshake = Handshake.None
                            SerialPort1.Encoding = System.Text.Encoding.Default
                            SerialPort1.Open()



                            BtnDiscon.Enabled = True
                            BtnDiscon.BringToFront()

                            BtnCon.Enabled = False
                            BtnCon.SendToBack()

                            BtnScanPort.Enabled = False
                            CmbPort.DroppedDown = False
                            CmbPort.Enabled = False
                            CmbPort.Text = hasil

                            Read.Enabled = True
                            Write.Enabled = True

                            PnlRead.Show()
                            PanelRead.Show()

                            NIM.Focus()
                        Else
                            CmbPort.Enabled = True
                            CmbPort.DroppedDown = True
                            BtnScanPort.Enabled = True

                            BtnCon.Enabled = False
                            BtnCon.BringToFront()

                            BtnDiscon.Enabled = False
                            BtnDiscon.SendToBack()

                            Write.Enabled = False
                        End If
                    End If
                End If
            Next
        Catch err As ManagementException
            MsgBox("Port terlepas!")
        End Try


    End Sub


    Private Sub Ext_Click(sender As Object, e As EventArgs) Handles Ext.Click
        Me.Close()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Apa anda yakin menutup aplikasi?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If

    End Sub
    Private Sub BtnScanPort_Click(sender As Object, e As EventArgs) Handles BtnScanPort.Click
        CmbPort.Items.Clear()
        Dim myPort As Array
        Dim i As Integer

        myPort = IO.Ports.SerialPort.GetPortNames()
        CmbPort.Items.AddRange(myPort)
        i = CmbPort.Items.Count
        i = i - i

        Try
            CmbPort.SelectedIndex = i
            BtnCon.Enabled = True
            BtnCon.BringToFront()
            CmbPort.DroppedDown = True
        Catch ex As Exception
            MessageBox.Show("Com port Not detected", "Warning!", MessageBoxButtons.OK)
            CmbPort.Text = ""
            Call Form1_Load(Me, e)
        End Try
    End Sub

    Private Sub BtnCon_Click(sender As Object, e As EventArgs) Handles BtnCon.Click
        BtnCon.Enabled = False
        BtnCon.SendToBack()
        BtnScanPort.Enabled = False
        CmbPort.Enabled = False
        CmbPort.DroppedDown = False

        SerialPort1.BaudRate = baudrate
        SerialPort1.PortName = CmbPort.SelectedItem
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()


        NIM.Focus()

        BtnDiscon.Enabled = True
        BtnDiscon.BringToFront()

        Write.Enabled = True
        Read.Enabled = True

        PnlRead.Show()
        PanelRead.Show()

    End Sub

    Private Sub BtnDiscon_Click(sender As Object, e As EventArgs) Handles BtnDiscon.Click
        BtnDiscon.Enabled = False
        BtnCon.Enabled = False
        BtnScanPort.Enabled = True

        BtnCon.BringToFront()
        BtnDiscon.SendToBack()


        Write.Enabled = False
        Read.Enabled = False

        PnlRead.Hide()
        PnlWrite.Hide()
        PanelRead.Hide()

        NIM.Enabled = False

        SerialPort1.Close()

        CmbPort.Text = ""
        Status.Text = ""
        NIM.Text = ""
        Nama.Text = ""
        TxtNIM_Write.Text = ""
    End Sub


    Private Sub Read_Click(sender As Object, e As EventArgs) Handles Read.Click
        PanelRead.Hide()
        PanelWrite.Hide()

        PnlRead.Show()
        PanelRead.Show()

        PnlWrite.Hide()
        PanelWrite.Hide()

        TxtNIM_Write.Text = ""
        Status.Text = ""

        NIM.Focus()

    End Sub

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click
        PnlWrite.Show()


        PnlRead.Hide()
        PanelRead.Hide()
        PanelWrite.Show()

        Read.Enabled = False
        Write.Enabled = False
        Ext.Enabled = False

        Status.Text = ""
        TxtNIM_Write.Text = ""
        TxtNIM_Write.Focus()

        SerialPort1.Write("write" & "#")
        waktu = 25
        Timer3.Enabled = True

        Status.Hide()

    End Sub

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        SerialPort1.Write(TxtNIM_Write.Text & "*")
        Timer3.Enabled = False
        waktu = 0

        Read.Enabled = True
        Write.Enabled = True
        Ext.Enabled = True

        Status.Show()

        PanelRead.Show()
        PnlRead.Show()

        PnlWrite.Hide()
        PanelWrite.Hide()

    End Sub
    Private Sub TxtNIM_Write_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNIM_Write.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnWrite.PerformClick()
        End If

    End Sub

    Private Sub Ext2_Click(sender As Object, e As EventArgs) Handles Ext2.Click
        Status.Show()
        PnlWrite.Hide()
        PanelWrite.Hide()

        PanelRead.Show()
        PnlRead.Show()

        Read.Enabled = True
        Write.Enabled = True
        Ext.Enabled = True

        SerialPort1.Write("DataKosong" & "*")
        Timer3.Enabled = False
        waktu = 0

    End Sub


    Private Sub TxtNIM_Write_TextChanged(sender As Object, e As EventArgs) Handles TxtNIM_Write.TextChanged
        Dim theText As String = TxtNIM_Write.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TxtNIM_Write.SelectionStart
        Dim Change As Integer
        For x As Integer = 0 To TxtNIM_Write.Text.Length - 1
            Letter = TxtNIM_Write.Text.Substring(x, 1)
            If numbers.Contains(Letter) = False Then
                SystemSounds.Beep.Play()
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next
        TxtNIM_Write.Text = theText
        TxtNIM_Write.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Tanggal.Text = Date.Now.ToString("dddd, dd MMM yyyy")
        Jam.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If waktu > 0 Then
            waktu -= 1
        Else
            Timer3.Enabled = False
            TxtNIM_Write.Text = ""
            SerialPort1.Write("DataisEmpty" & "*")

            Read.Enabled = True
            Write.Enabled = True
            Ext.Enabled = True

            Status.Show()

            PanelRead.Show()
            PnlRead.Show()

            PnlWrite.Hide()
            PanelWrite.Hide()
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())    ' read text from serial data
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)
        If Me.NIM.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.NIM.Text &= [text]
        End If


    End Sub

    Private Sub NIM_TextChanged(sender As Object, e As EventArgs) Handles NIM.TextChanged
        Dim bfr As String
        bfr = NIM.Text

        Conn = New MySqlConnection
        Conn.ConnectionString = "server = localhost; userid = root; password =; database = inlislite_v3"

        Try
            If Regex.IsMatch(NIM.Text, "^[0-9 ]+$") Then
                If NIM.Text <> "" Then
                    Status.Text = ""

                    Conn.Open()
                    Query = "SELECT * FROM `members` WHERE MemberNo = '" & NIM.Text & "'"
                    COMMAND = New MySqlCommand(Query, Conn)
                    reader = COMMAND.ExecuteReader()
                    If reader.Read() = True Then
                        Nama.Text = reader("FullName".ToString())
                        reader.Close()
                        Query = "CALL GetTimeDif('" & NIM.Text & "');"
                        COMMAND = New MySqlCommand(Query, Conn)
                        reader = COMMAND.ExecuteReader()
                        If reader.Read() = True Then
                            Try
                                Flag = reader.GetInt16("Date")
                                If Flag = 0 Then
                                    MessageBox.Show("Sudah")
                                    Nama.Text = ""
                                    NIM.Text = ""
                                    Conn.Close()
                                ElseIf Flag < 0 Then
                                    Query = "CALL InsertGuessBook('" & NIM.Text & "');"
                                    reader.Close()
                                    COMMAND = New MySqlCommand(Query, Conn)
                                    reader = COMMAND.ExecuteReader()
                                    MessageBox.Show("Selamat Datang!")
                                    Nama.Text = ""
                                    NIM.Text = ""
                                    Conn.Close()
                                End If
                            Catch ex As Exception
                                Query = "CALL InsertGuessBook('" & NIM.Text & "');"
                                reader.Close()
                                COMMAND = New MySqlCommand(Query, Conn)
                                reader = COMMAND.ExecuteReader()
                                MessageBox.Show("Selamat Datang!")
                                Nama.Text = ""
                                NIM.Text = ""
                                Conn.Close()
                            End Try
                        End If
                    ElseIf NIM.Text.Contains("Done") Then
                        Nama.Text = ""
                        NIM.Text = ""
                    Else
                        Nama.Text = "NIM Tidak Terdaftar"
                    End If
                End If
            Else
                NIM.Text = ""
                Nama.Text = ""
            End If

        Catch ex As Exception
            BtnDiscon.Enabled = False
            BtnCon.Enabled = False
            BtnScanPort.Enabled = True

            BtnCon.BringToFront()
            BtnDiscon.SendToBack()


            Write.Enabled = False
            Read.Enabled = False

            PnlRead.Hide()
            PnlWrite.Hide()
            PanelRead.Hide()

            SerialPort1.Close()

            CmbPort.Text = ""
            Status.Text = ""
            NIM.Text = ""
            Nama.Text = ""
            TxtNIM_Write.Text = ""
        End Try
    End Sub

End Class
