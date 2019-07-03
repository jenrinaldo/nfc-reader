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
        TxtUsr.Enabled = False
        TxtPass.Enabled = False
        Login.Enabled = False

        PnlWrite.Hide()
        PanelLogin.Hide()
        PanelWrite.Hide()

        PnlRead.Show()
        PanelRead.Show()

        TxtUsr.Text = ""
        TxtPass.Text = ""
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

                            TxtUsr.Enabled = True
                            TxtPass.Enabled = True
                            Login.Enabled = True

                        Else
                            CmbPort.Enabled = True
                            CmbPort.DroppedDown = True
                            BtnScanPort.Enabled = True

                            BtnCon.Enabled = False
                            BtnCon.BringToFront()

                            BtnDiscon.Enabled = False
                            BtnDiscon.SendToBack()

                            Timer2.Enabled = False
                            TxtUsr.Enabled = False
                            TxtPass.Enabled = False
                            Login.Enabled = False

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
        TxtUsr.Enabled = True
        TxtPass.Enabled = True
        Login.Enabled = True

        BtnDiscon.Enabled = True
        BtnDiscon.BringToFront()
    End Sub

    Private Sub BtnDiscon_Click(sender As Object, e As EventArgs) Handles BtnDiscon.Click
        BtnDiscon.Enabled = False
        BtnCon.Enabled = False
        BtnScanPort.Enabled = True
        CmbPort.Text = ""

        BtnCon.BringToFront()
        BtnDiscon.SendToBack()

        Timer2.Enabled = False
        TxtUsr.Enabled = False
        TxtPass.Enabled = False
        Login.Enabled = False
        SerialPort1.Close()


        NIM.Text = ""
        Nama.Text = ""
        TxtNIM_Write.Text = ""
        TxtUsr.Text = ""
        TxtPass.Text = ""
    End Sub


    Private Sub Read_Click(sender As Object, e As EventArgs) Handles Read.Click
        PanelRead.Hide()
        PanelWrite.Hide()
        PanelLogin.Hide()

        PnlRead.Show()
        PanelRead.Show()

        PnlWrite.Hide()
        PanelLogin.Hide()
        PanelWrite.Hide()

        TxtUsr.Text = ""
        TxtPass.Text = ""
        TxtNIM_Write.Text = ""
        Status.Text = ""

    End Sub

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click
        PnlWrite.Show()
        PanelLogin.Show()

        PnlRead.Hide()
        PanelRead.Hide()
        PanelWrite.Hide()


        Status.Hide()

        TxtUsr.Focus()


    End Sub
    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        If TxtUsr.Text = "admin" And TxtPass.Text = "admin" Then
            MsgBox("Login Success", MsgBoxStyle.Information, "Login")
            PanelWrite.Show()

            Read.Enabled = False
            Write.Enabled = False
            Ext.Enabled = False

            PanelLogin.Hide()
            TxtUsr.Text = ""
            TxtPass.Text = ""
            TxtNIM_Write.Text = ""

            SerialPort1.Write("write" & "#")
            waktu = 30
            Timer3.Enabled = True

            TxtNIM_Write.Focus()
        Else
            If TxtUsr.Text = "" And TxtPass.Text = "" Then
                MsgBox("No Username and Password found!", MsgBoxStyle.Critical, "Error")
            Else
                If TxtUsr.Text = "" Then
                    MsgBox("No Username found!", MsgBoxStyle.Critical, "Error")
                Else
                    If TxtPass.Text = "" Then
                        MsgBox("No Password found!", MsgBoxStyle.Critical, "Error")
                    Else
                        MsgBox("Invalid Username and/or Password!", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        SerialPort1.Write(TxtNIM_Write.Text & "*")
        Timer3.Enabled = False
        waktu = 0

        Read.Enabled = True
        Write.Enabled = True
        Ext.Enabled = True

        Status.Show()
        PanelLogin.Show()
        PanelWrite.Hide()
    End Sub

    Private Sub Ext2_Click(sender As Object, e As EventArgs) Handles Ext2.Click
        Status.Show()
        PanelLogin.Show()
        PanelWrite.Hide()

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
            If NIM.Text <> "" Then
                Status.Text = ""

                Conn = New MySqlConnection
                Conn.ConnectionString = "server=localhost; userid=root; password=; database=membership"
                Conn.Open()
                Query = "SELECT nama, jenis_anggota FROM `membership` WHERE id = '" & NIM.Text & "'"
                COMMAND = New MySqlCommand(Query, Conn)
                Dim ADAPTER As New MySqlDataAdapter(COMMAND)
                Dim TABLE As New DataTable()
                ADAPTER.Fill(TABLE)

                If NIM.Text.Contains("Done") Then
                    Nama.Text = ""
                    NIM.Text = ""
                ElseIf ADAPTER.Fill(TABLE) < 1 Then
                    Nama.Text = "Data Not Found"
                Else
                    Nama.Text = TABLE.Rows(0)(0).ToString()
                    Conn.Close()
                    Conn.Open()
                    Query = "insert into `bukutamu` values(
                    (SELECT id FROM membership WHERE id  = '" & NIM.Text & "'),
                    (SELECT nama FROM membership WHERE id = '" & NIM.Text & "'),
                    CURRENT_TIME)"
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
            MsgBox("Time is over!")
            TxtNIM_Write.Text = ""
            PanelWrite.Hide()
            PanelLogin.Show()
            Read.Enabled = True
            Write.Enabled = True
            Ext.Enabled = True
        End If
    End Sub

    Private Sub TxtUsr_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsr.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login.PerformClick()
        End If
    End Sub

    Private Sub TxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login.PerformClick()
        End If
    End Sub

    Private Sub TxtNIM_Write_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNIM_Write.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnWrite.PerformClick()
        End If

    End Sub

End Class
