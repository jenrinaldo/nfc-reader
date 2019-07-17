Option Explicit On

Imports System.IO
Imports System.IO.Ports
Imports System.Management
Imports System.Text.RegularExpressions
Imports System.Media
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim WithEvents FpVer As New FlexCodeSDK.FinFPVer
    Dim WithEvents FpReg As New FlexCodeSDK.FinFPReg
    Dim uniqueTemplate As Boolean
    Dim Template As String
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
    Dim SN As String = "K520J00874"
    Dim Verif As String = "06E-B04-3C7-413-D26"
    Dim Activ As String = "1L6D-450D-E57E-D237-B9D8-7RG2"
    Dim Flag As Integer
    Dim statusFP As Boolean
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = New MySqlConnection
        Conn.ConnectionString = "server = localhost; userid = root; password = ; database = inlislite_v3"


        FpVer = New FlexCodeSDK.FinFPVer
        FpReg = New FlexCodeSDK.FinFPReg
        FpVer.SetMaxTemplate(100000)

        FpVer.PictureSamplePath = My.Application.Info.DirectoryPath & "\FPTemp.BMP"
        FpVer.PictureSampleHeight = Convert.ToInt32(Compatibility.VB6.PixelsToTwipsY(PictureBox1.Height))
        FpVer.PictureSampleWidth = Convert.ToInt32(Compatibility.VB6.PixelsToTwipsY(PictureBox1.Width))

        Fingerprint.Enabled = False
        CheckFngr.Enabled = False
        CheckFngr.Checked = False
        RFID.Enabled = False
        CheckRFID.Enabled = False
        CheckRFID.Checked = False
        uniqueTemplate = False
        NIM.Enabled = False

        Timer1.Enabled = True
        Timer2.Enabled = False
        Timer3.Enabled = False

        BtnCon.Enabled = False
        Write.Enabled = False
        Read.Enabled = False

        PnlWrite.Hide()
        PanelWrite.Hide()
        PanelFinger.Hide()
        PanelPW.Hide()

        PnlRead.Hide()
        PanelRead.Hide()

        Stts.Text = ""
        Nama.Text = ""
        balasan.Text = ""
        TxtNIM_Write.Text = ""

        Dim searcher As New ManagementObjectSearcher("root\CIMV2", "Select * FROM Win32_PnPEntity")
        For Each queryObj As ManagementObject In searcher.Get()
            If queryObj("Description") = "USB-SERIAL CH340" Then
                string1 = queryObj("Description")
                string2 = queryObj("Name")
                hasil = string2.Replace(string1, "")
                hasil = hasil.Replace("(", "")
                hasil = hasil.Replace(")", "")
                hasil = hasil.Replace(" ", "")
            End If
        Next

        If string1 = "USB-SERIAL CH340" And statusFP = False Then
            konek(hasil)
            tampil()
            FPVerif()
            CheckRFID.Checked = True
            CheckFngr.Checked = True
        ElseIf string1 = "USB-SERIAL CH340" And statusFP = True Then
            konek(hasil)
            tampil()
            CheckRFID.Checked = True
            CheckFngr.Checked = False
            CheckFngr.Enabled = True
        ElseIf string1 <> "USB-SERIAL CH340" And statusFP = False Then
            tampil()
            FPVerif()
            CheckRFID.Checked = False
            CheckFngr.Checked = True
        Else
            CheckRFID.Checked = False
            CheckFngr.Checked = False
            CheckFngr.Enabled = True
            sembunyi()
        End If

    End Sub

    Private Sub FPRegist()
        FpVer.FPVerificationStop()
        FpReg = New FlexCodeSDK.FinFPReg
        FpReg.AddDeviceInfo(SN, Verif, Activ)
        FpReg.FPRegistrationStart("YourSecretKey")
        uniqueTemplate = False
    End Sub

    Private Sub FpReg_FPSamplesNeeded(ByVal Samples As Short) Handles FpReg.FPSamplesNeeded
        Label2.Text = "Tempelkan Jari sebanyak 4x "
        If Str(Samples) = 4 Then
            RectangleShape2.Width = 0
        ElseIf Str(Samples) = 3 Then
            RectangleShape2.Width = 80
        ElseIf Str(Samples) = 2 Then
            RectangleShape2.Width = 160
        ElseIf Str(Samples) = 1 Then
            RectangleShape2.Width = 250
        ElseIf Str(Samples) = 0 Then
            RectangleShape2.Width = 292
            Label2.Text = "Registrasi Berhasil"
            Label3.Text = "Tempelkan lagi jari anda"
        End If
    End Sub

    Private Sub FpReg_FPRegistrationStatus(ByVal Status As FlexCodeSDK.RegistrationStatus) Handles FpReg.FPRegistrationStatus
        If Status = FlexCodeSDK.RegistrationStatus.r_OK Then
            FpReg.FPRegistrationStop()
            FPVerif()
        End If
    End Sub


    Private Sub FPVerif()
        Conn.Close()
        Conn.Open()
        FpVer.AddDeviceInfo(SN, Verif, Activ)
        Dim commText As String = "CALL GetTemplate()"
        Dim sqlCommand As New MySqlCommand(commText, Conn)
        Dim rd As MySqlDataReader = sqlCommand.ExecuteReader()
        While rd.Read
            FpVer.FPLoad(rd.GetString(0), rd.GetString(3), rd.GetString(2), "YourSecretKey")
        End While
        FpVer.FPVerificationStart()
        rd.Close()
    End Sub

    Private Sub FPVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FpVer.FPVerificationID
        Dim bls As String
        NIM.Text = ID
        bls = balasan.Text
        Stts.Text = ""
        balasan.Text = ""
        If FlexCodeSDK.VerificationStatus.v_OK = 1 Then
            MsgBox(bls)
            PictureBox1.Image = Nothing
            NIM.Text = ""
            Nama.Text = ""
        End If
    End Sub

    Private Sub FPVer_FPVerificationImage() Handles FpVer.FPVerificationImage
        Dim imgFile As FileStream = New FileStream(My.Application.Info.DirectoryPath & "\FPTemp.BMP", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim fileBytes(imgFile.Length) As Byte
        imgFile.Read(fileBytes, 0, fileBytes.Length)
        imgFile.Close()
        Dim ms As MemoryStream = New MemoryStream(fileBytes)
        PictureBox1.Image = Image.FromStream(ms)
    End Sub

    Private Sub FpReg_FPRegistrationTemplate(ByVal FPTemplate As String) Handles FpReg.FPRegistrationTemplate
        Template = FPTemplate
        RichTextBox1.Text = FPTemplate
    End Sub

    Private Sub konek(ByVal Cmb As String)
        SerialPort1.BaudRate = baudrate
        SerialPort1.PortName = Cmb
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
        CmbPort.Text = Cmb

        Timer2.Enabled = True
        CheckRFID.Checked = True


        Write.Enabled = True
    End Sub

    Private Sub fpAddToDB()
        Conn.Close()
        Conn.Open()
        Stts.Text = ""
        Dim commText As String = "CALL UpdateFinger('" & RichTextBox1.Text & "', '" & Str(NoJari.SelectedIndex) & "', '" & NimFinger.Text & "');"
        Dim sqlCommand As New MySqlCommand(commText, Conn)
        sqlCommand.ExecuteNonQuery()
        MsgBox("OK!")

        Write.Enabled = True
        Read.Enabled = True
        Ext.Enabled = True

        PnlRead.Show()
        PanelRead.Show()

        PnlWrite.Hide()
        PanelFinger.Hide()
        PanelWrite.Hide()
        PanelPW.Hide()
        FPVerif()

        NimFinger.Text = "Berhasil"
        NoJari.Text = ""
        RichTextBox1.Text = ""
        Label2.Text = ""
    End Sub

    Private Sub tampil()
        Read.Enabled = True
        PnlRead.Show()
        PanelRead.Show()
    End Sub

    Private Sub sembunyi()
        PnlRead.Hide()
        PnlWrite.Hide()
        PanelRead.Hide()
        PanelPW.Hide()

        Write.Enabled = False
        Read.Enabled = False

        CmbPort.Text = ""
        Stts.Text = ""
        NIM.Text = ""
        Nama.Text = ""
        TxtNIM_Write.Text = ""
    End Sub

    Private Sub diskonek()
        BtnDiscon.Enabled = False
        BtnCon.Enabled = False
        CmbPort.Text = ""
        BtnScanPort.Enabled = True
        CmbPort.Enabled = True

        BtnCon.BringToFront()
        BtnDiscon.SendToBack()

        Timer2.Enabled = False

        PnlWrite.Hide()
        Write.Enabled = False

        NIM.Enabled = False
        CheckRFID.Checked = False

        SerialPort1.Close()
    End Sub

    Private Sub FPVer_FPVerificationStatus(ByVal Status As FlexCodeSDK.VerificationStatus) Handles FpVer.FPVerificationStatus
        Select Case Status
            Case FlexCodeSDK.VerificationStatus.v_ActivationIncorrect
                Stts.Text = "Activation / verification code is" & vbNewLine & "incorrent or not set"
            Case FlexCodeSDK.VerificationStatus.v_FPDevFull
                Stts.Text = "Max 10 devices"
            Case FlexCodeSDK.VerificationStatus.v_FPListEmpty
                Stts.Text = "Please add templates"
            Case FlexCodeSDK.VerificationStatus.v_FPListFull
                Stts.Text = "Max 100K templates"
            Case FlexCodeSDK.VerificationStatus.v_MultiplelMatch
                Stts.Text = "Multiple match"
            Case FlexCodeSDK.VerificationStatus.v_NoDevice
                statusFP = True
                MessageBox.Show("USB Port Fingerprint Tidak Terdeteksi", "Warning!", MessageBoxButtons.OK)
                If CheckFngr.Checked = True Then
                    CheckFngr.Checked = False
                    CheckFngr.Enabled = True
                End If
                If CheckRFID.Checked = False Then
                    sembunyi()
                End If
            Case FlexCodeSDK.VerificationStatus.v_NotMatch, FlexCodeSDK.VerificationStatus.v_FPListEmpty
                Stts.Text = "No Match"
                uniqueTemplate = True
            Case FlexCodeSDK.VerificationStatus.v_PoorImageQuality
                Stts.Text = "Poor image quality"
            Case FlexCodeSDK.VerificationStatus.v_VerificationFailed
                Stts.Text = "Verification failed"
            Case FlexCodeSDK.VerificationStatus.v_VerifyCaptureStop
                Stts.Text = "Stop verify"
            Case Else
                statusFP = False
                CheckFngr.Checked = True
        End Select
        If uniqueTemplate And RichTextBox1.Text <> "" Then
            fpAddToDB()
            uniqueTemplate = False
            FpReg.FPRegistrationStop()
        End If
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
            MessageBox.Show("Port RFID Tidak Terdeteksi", "Warning!", MessageBoxButtons.OK)
            CmbPort.Text = ""
            Call Form1_Load(Me, e)
        End Try
    End Sub

    Private Sub BtnCon_Click(sender As Object, e As EventArgs) Handles BtnCon.Click
        konek(CmbPort.SelectedItem)
        tampil()
    End Sub

    Private Sub BtnDiscon_Click(sender As Object, e As EventArgs) Handles BtnDiscon.Click
        diskonek()
        If CheckFngr.Checked = False Then
            sembunyi()
        End If
    End Sub

    Private Sub Read_Click(sender As Object, e As EventArgs) Handles Read.Click
        PnlRead.Show()
        PanelRead.Show()

        PnlWrite.Hide()
        PanelFinger.Hide()
        PanelWrite.Hide()
        PanelPW.Hide()
    End Sub

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click
        PnlRead.Hide()
        PanelRead.Hide()

        PnlWrite.Show()
        PanelPW.Show()
        PanelFinger.Hide()
        PanelWrite.Hide()
        TxtUsr.Focus()
        PictureBox1.Image = Nothing
        Label3.Text = ""
    End Sub

    Private Sub TxtNIM_Write_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNIM_Write.KeyDown
        If e.KeyCode = Keys.Enter And PanelWrite.Visible = True Then
            BtnWrite.PerformClick()
        End If
    End Sub

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        SerialPort1.Write(TxtNIM_Write.Text & "*")
        Timer3.Enabled = False
        waktu = 0
        RectangleShape2.Width = 0
        Read.Enabled = False
        Write.Enabled = False
        Ext.Enabled = False

        PnlWrite.Show()
        PanelWrite.Hide()
    End Sub

    Private Sub passing()
        PnlWrite.Show()
        PanelFinger.Show()
        PanelWrite.Hide()
        PanelRead.Hide()

        Read.Enabled = False
        Write.Enabled = False
        Ext.Enabled = False

        NimFinger.Text = TxtNIM_Write.Text
    End Sub

    Private Sub gagal()
        PanelRead.Show()
        PnlRead.Show()

        PanelWrite.Hide()
        PnlWrite.Hide()
        PanelFinger.Hide()
    End Sub

    Private Sub Ext2_Click(sender As Object, e As EventArgs) Handles Ext2.Click
        Stts.Show()
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
            SerialPort1.Write("DataKosong" & "*")
            TxtNIM_Write.Text = ""

            Read.Enabled = True
            Write.Enabled = True
            Ext.Enabled = True

            Stts.Show()

            PanelRead.Show()
            PnlRead.Show()

            PnlWrite.Hide()
            PanelWrite.Hide()
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ReceivedText(SerialPort1.ReadExisting())
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
        Conn.Close()
        Try
            If Regex.IsMatch(NIM.Text, "^[0-9 ]+$") Then
                If NIM.Text <> "" Then
                    Stts.Text = ""
                    balasan.Text = ""

                    Conn.Open()
                    Query = "CALL FetchData ('" & NIM.Text & "'); "
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
                                    balasan.Text = "Terimakasih Telah Berkunjung Kembali"
                                    Conn.Close()
                                ElseIf Flag < 0 Then
                                    Query = "CALL InsertGuessBook('" & NIM.Text & "');"
                                    reader.Close()
                                    COMMAND = New MySqlCommand(Query, Conn)
                                    reader = COMMAND.ExecuteReader()
                                    balasan.Text = "Selamat Datang di Perpustakaan!"
                                    Conn.Close()
                                End If
                            Catch ex As Exception
                                Query = "CALL InsertGuessBook('" & NIM.Text & "');"
                                reader.Close()
                                COMMAND = New MySqlCommand(Query, Conn)
                                reader = COMMAND.ExecuteReader()
                                balasan.Text = "Selamat Datang di Perpustakaan!"
                                Conn.Close()
                            End Try
                        End If
                    ElseIf NIM.Text.Contains("Done") Then
                        Nama.Text = ""
                        NIM.Text = ""
                    Else
                        Nama.Text = "NIM Tak Terdaftar"
                    End If
                    Conn.Close()
                End If
            ElseIf Regex.IsMatch(NIM.Text, "DataKosong") Then
                NIM.Text = ""
                Stts.Text = "Data Kosong"
            ElseIf Regex.IsMatch(NIM.Text, "Write success!") Then
                NIM.Text = ""
                MsgBox("Penulisan RFID Tag Sukses")
                PanelFinger.Show()
                passing()
                FPRegist()
            ElseIf Regex.IsMatch(NIM.Text, "Write failed!") Then
                NIM.Text = ""
                MessageBox.Show("Penulisan RFID Tag Gagal", "Warning!", MessageBoxButtons.OK)
                gagal()
            Else
                NIM.Text = ""
                Nama.Text = ""
                balasan.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Periksa sambungan database")
            NIM.Text = ""
        End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Dim Incoming As String = SerialPort1.ReadExisting()
        Catch ex As Exception
            diskonek()
            If CheckFngr.Checked = False Then
                sembunyi()
            End If
        End Try

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Conn.Close()
        FpVer.FPListClear()
        FpVer.FPVerificationStop()
    End Sub

    Private Sub CheckFngr_Click(sender As Object, e As EventArgs) Handles CheckFngr.Click
        FpVer.AddDeviceInfo(SN, Verif, Activ)
        FpVer.FPVerificationStart()
        If CheckFngr.Checked = True Then
            CheckFngr.Enabled = False
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If TxtUsr.Text = "admin" And TxtPass.Text = "admin" Then
            FpVer.FPVerificationStop()

            PnlRead.Hide()
            PanelRead.Hide()
            PnlWrite.Show()
            PanelWrite.Show()
            PanelFinger.Hide()
            PanelPW.Hide()

            Read.Enabled = False
            Write.Enabled = False
            Ext.Enabled = False

            TxtNIM_Write.Text = ""
            TxtNIM_Write.Focus()

            Stts.Text = ""
            NimFinger.Text = ""
            NoJari.Text = ""
            RichTextBox1.Text = ""
            Label2.Text = ""
            TxtUsr.Text = ""
            TxtPass.Text = ""

            SerialPort1.Write("write" & "#")
            waktu = 25
            Timer3.Enabled = True
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

    Private Sub TxtUsr_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUsr.KeyDown
        If e.KeyCode = Keys.Enter And PanelPW.Visible = True Then
            BtnNext.PerformClick()
        End If
    End Sub

    Private Sub TxtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Enter And PanelPW.Visible = True Then
            BtnNext.PerformClick()
        End If
    End Sub

End Class
