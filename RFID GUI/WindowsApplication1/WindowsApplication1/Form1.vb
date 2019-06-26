Imports System
Imports System.IO.Ports
Imports MySql.Data.MySqlClient

Public Class Form1

    Dim Conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim Query As String

    Private Sub Ext_Click(sender As Object, e As EventArgs) Handles Ext.Click
        Me.Close()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Apa anda yakin menutup aplikasi", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer2.Enabled = False

        BtnCon.Enabled = False
        BtnCon.BringToFront()

        BtnDiscon.Enabled = False
        BtnDiscon.SendToBack()

        Write.Enabled = False
        Login.Enabled = False

        Label1.Hide()
        TxtUsr.Hide()
        Label2.Hide()
        TxtPass.Hide()
        Login2.Hide()
        Label3.Hide()
        txtNIM_2.Hide()
        Write2.Hide()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Tanggal.Text = Date.Now.ToString("dd MMM yyyy")
        Jam.Text = Date.Now.ToString("hh:mm:ss")
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
            Dim result As DialogResult
            result = MessageBox.Show("Com port not detected", "Warning!", MessageBoxButtons.OK)
            CmbPort.Text = ""
            Call Form1_Load(Me, e)
        End Try

    End Sub

    Private Sub BtnCon_Click(sender As Object, e As EventArgs) Handles BtnCon.Click
        BtnCon.Enabled = False
        BtnCon.SendToBack()

        SerialPort1.BaudRate = 9600
        SerialPort1.PortName = CmbPort.SelectedItem
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()

        Timer2.Enabled = True


        BtnDiscon.Enabled = True
        BtnDiscon.BringToFront()

        Write.Enabled = True
        Login.Enabled = True

    End Sub

    Private Sub BtnDiscon_Click(sender As Object, e As EventArgs) Handles BtnDiscon.Click
        BtnDiscon.Enabled = False
        BtnCon.Enabled = True

        BtnCon.BringToFront()
        BtnDiscon.SendToBack()

        Timer2.Enabled = False
        SerialPort1.Close()

        Write.Enabled = False
        Login.Enabled = False

        NIM.Text = ""
        Nama.Text = ""

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Incoming As String
        Incoming = SerialPort1.ReadExisting()
        NIM.Text &= Incoming
        If NIM.Text <> "" Then
            Conn = New MySqlConnection
            Conn.ConnectionString = "server=localhost; userid=root; password=; database=membership"
            Conn.Open()

            Query = "SELECT nama, jenis_anggota FROM `membership` WHERE id = '" & NIM.Text & "'"
            COMMAND = New MySqlCommand(Query, Conn)
            Dim ADAPTER As New MySqlDataAdapter(COMMAND)
            Dim TABLE As New DataTable()
            ADAPTER.Fill(TABLE)
            If ADAPTER.Fill(TABLE) < 1 Then
                MsgBox("Data Not Found", MsgBoxStyle.Critical, "Error")
            Else
                Nama.Text = TABLE.Rows(0)(0).ToString()
            End If
            Conn.Close()
        End If
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click

    End Sub

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click

        Ext.SendToBack()
        Judul.Hide()
        LabelNama.Hide()
        LabelNIM.Hide()
        NIM.Hide()
        Nama.Hide()
        Login.Hide()
        BtnScanPort.Hide()
        CmbPort.Hide()
        BtnCon.Hide()
        BtnDiscon.Hide()
        Write.Hide()

        Ext2.BringToFront()
        Ext2.Show()

        Label1.Show()
        Label2.Show()

        TxtUsr.Show()
        TxtUsr.Enabled = True

        TxtPass.Show()
        TxtPass.Enabled = True

        Login2.Show()
        Login2.Enabled = True


    End Sub

    Private Sub Ext2_Click(sender As Object, e As EventArgs) Handles Ext2.Click
        Ext.BringToFront()
        Judul.Show()
        LabelNama.Show()
        LabelNIM.Show()
        NIM.Show()
        Nama.Show()
        Login.Show()
        BtnScanPort.Show()
        CmbPort.Show()
        BtnCon.Show()
        BtnDiscon.Show()
        Write.Show()

        Label1.Hide()
        TxtUsr.Hide()
        Label2.Hide()
        TxtPass.Hide()
        Login2.Hide()

        Label3.Hide()
        txtNIM_2.Hide()
        Write2.Hide()

    End Sub

    Private Sub Login2_Click(sender As Object, e As EventArgs) Handles Login2.Click
        If TxtUsr.Text = "admin" And TxtPass.Text = "admin" Then
            MsgBox("Login Success", MsgBoxStyle.Information, "Login")

            TxtUsr.Text = ""
            TxtPass.Text = ""

            Login2.Enabled = False
            Login2.SendToBack()
            Label1.Hide()
            Label2.Hide()

            TxtUsr.Enabled = False
            TxtUsr.SendToBack()
            TxtUsr.Hide()

            TxtPass.Enabled = False
            TxtPass.SendToBack()
            TxtPass.Hide()

            Write2.Enabled = True
            Write2.BringToFront()
            Write2.Show()

            txtNIM_2.Enabled = True
            txtNIM_2.BringToFront()
            txtNIM_2.Show()

            Label3.Show()
            SerialPort1.Write("write" & "#")


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

    Private Sub Write2_Click(sender As Object, e As EventArgs) Handles Write2.Click
        SerialPort1.Write(txtNIM_2.Text & "*")
        txtNIM_2.Text = ""



        Label3.Hide()
        txtNIM_2.Hide()
        Write2.Hide()


        Ext.BringToFront()
        Judul.Show()
        LabelNama.Show()
        LabelNIM.Show()
        NIM.Show()
        Nama.Show()
        Login.Show()
        BtnScanPort.Show()
        CmbPort.Show()
        BtnCon.Show()
        BtnDiscon.Show()
        Write.Show()
    End Sub

End Class
