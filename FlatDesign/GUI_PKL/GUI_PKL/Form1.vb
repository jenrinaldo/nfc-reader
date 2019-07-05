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
    Dim numbersAllowed As String = "1234567890"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fingerprint.Enabled = False
        RFID.Enabled = False

        Timer1.Enabled = True

        Timer2.Enabled = False
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

                            Timer2.Enabled = True

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

                        Else
                            CmbPort.Enabled = True
                            CmbPort.DroppedDown = True
                            BtnScanPort.Enabled = True

                            BtnCon.Enabled = False
                            BtnCon.BringToFront()

                            BtnDiscon.Enabled = False
                            BtnDiscon.SendToBack()

                            Timer2.Enabled = False
                            Write.Enabled = False
                        End If
                    End If
                End If
            Next
        Catch err As ManagementException
            MsgBox(err.Message)
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

        Timer2.Enabled = True

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

        Timer2.Enabled = False
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

        SerialPort1.Write("DataisEmpty" & "*")
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
            If numbersAllowed.Contains(Letter) = False Then
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Incoming As String
        Incoming = SerialPort1.ReadExisting()
        NIM.Text &= Incoming
        Status.Text &= Incoming


        If Regex.IsMatch(NIM.Text, "^[0-9 ]") Then
            Conn = New MySqlConnection
            Conn.ConnectionString = "server=localhost; userid=root; password=; database=membership"
            Conn.Open()
            Query = "SELECT waktu FROM `bukutamu` WHERE NIM = '" & NIM.Text & "'"
            COMMAND = New MySqlCommand(Query, Conn)
            reader = COMMAND.ExecuteReader()
            If NIM.Text <> "" Then
                Status.Text = ""

                Conn = New MySqlConnection
                Conn.ConnectionString = "server=localhost; userid=root; password=; database=membership"
                Conn.Open()
                Query = "SELECT nama, jenis_anggota FROM `membership` WHERE id = '" & NIM.Text & "'"
                COMMAND = New MySqlCommand(Query, Conn)
                reader = COMMAND.ExecuteReader()

                If NIM.Text.Contains("Done") Then
                    Nama.Text = ""
                    NIM.Text = ""
                ElseIf reader.Read() = False Then
                    Nama.Text = "Data Not Found"
                Else
                    'Nama.Text = TABLE.Rows(0)(0).ToString()
                    Nama.Text = reader("Nama".ToString())
                    reader.Close()

                    Query = "insert into `bukutamu` values(
                    (''), (SELECT id FROM membership WHERE id  = '" & NIM.Text & "'),
                    (SELECT nama FROM membership WHERE id = '" & NIM.Text & "'),
                    NOW())"
                    COMMAND = New MySqlCommand(Query, Conn)
                    reader = COMMAND.ExecuteReader
                    Conn.Close()
                End If
                Conn.Close()
            End If
        ElseIf Regex.IsMatch(Status.Text, "DataisEmpty") Then
            Status.Text = ""
        Else
            NIM.Text = ""
        End If

        If Regex.IsMatch(Status.Text, "^[a-z,A-Z,! ]+$") = False Then
            Status.Text = ""
        End If



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

End Class
