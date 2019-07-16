Imports System.IO.Ports
Imports System.Management
Imports System.Text.RegularExpressions
Imports System.Media
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim WithEvents FpVer As New FlexCodeSDK.FinFPVer
    Dim WithEvents FpReg As New FlexCodeSDK.FinFPReg
    Dim uniqueTemplate As Boolean
    Dim userid As String
    Dim finum As Integer
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
    Dim Flag As Integer
    Dim statusFP As Boolean
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conn = New MySqlConnection
        Conn.ConnectionString = "server = localhost; userid = root; password = ; database = inlislite_v3"
        Conn.Open()
        FpVer = New FlexCodeSDK.FinFPVer
        FpVer.AddDeviceInfo("K520J00874", "06E-B04-3C7-413-D26", "1L6D-450D-E57E-D237-B9D8-7RG2")
        FpVer.SetMaxTemplate(100000)
        FpVer.FPVerificationStart()
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

        PnlRead.Hide()
        PanelRead.Hide()

        Stts.Text = ""
        Nama.Text = ""
        balasan.Text = ""

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
            FPLogin()
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
            FPLogin()
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
        If Write.Enabled = True Then
            FpReg = New FlexCodeSDK.FinFPReg
            FpReg.AddDeviceInfo("K520J00874", "06E-B04-3C7-413-D26", "1L6D-450D-E57E-D237-B9D8-7RG2")
            FpReg.FPRegistrationStart("YourSecretKey" & TextBox1.Text)
            ItIsUniqueTemplate = False
        End If   
    End Sub 

    Private Sub FpReg_FPSamplesNeeded(ByVal Samples As Short) Handles FpReg.FPSamplesNeeded
        Label1.Text = Str(Samples) & "x"
    End Sub

    Private Sub FPLogin()
        Dim commText As String = "SELECT MemberNo, FullName, Template, FingerIndex FROM Members"
        Dim sqlCommand As New MySqlCommand(commText, Conn)
        Dim rd As MySqlDataReader = sqlCommand.ExecuteReader()
        While rd.Read
            FpVer.FPLoad(rd.GetString(0), rd.GetString(3), rd.GetString(2), "YourSecretKey")
        End While
        FpVer.FPVerificationStart()
        rd.Close()
    End Sub

    Private Sub FPVer_FPVerificationID(ByVal ID As String, ByVal FingerNr As FlexCodeSDK.FingerNumber) Handles FpVer.FPVerificationID
        userid = ID
        finum = FingerNr
    End Sub

    Private Sub FPVer_FPVerificationImage() Handles FpVer.FPVerificationImage
        Dim imgFile As System.IO.FileStream = New System.IO.FileStream(My.Application.Info.DirectoryPath & "\FPTemp.BMP", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
        Dim fileBytes(imgFile.Length) As Byte
        imgFile.Read(fileBytes, 0, fileBytes.Length)
        imgFile.Close()
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(fileBytes)
        PictureBox1.Image = Image.FromStream(ms)
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

    Private Sub tampil()
        Read.Enabled = True
        PnlRead.Show()
        PanelRead.Show()
    End Sub

    Private Sub sembunyi()
        PnlRead.Hide()
        PnlWrite.Hide()
        PanelRead.Hide()

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
                MsgBox("Please connect the device to USB port or Add a device")
                If CheckFngr.Checked = True Then
                    CheckFngr.Checked = False
                    CheckFngr.Enabled = True
                End If
                If CheckRFID.Checked = False Then
                    sembunyi()
                End If
            Case FlexCodeSDK.VerificationStatus.v_NotMatch
                Stts.Text = "No match"
            Case FlexCodeSDK.VerificationStatus.v_OK
                MsgBox("Match")
            Case FlexCodeSDK.VerificationStatus.v_PoorImageQuality
                MsgBox("Poor image quality")
            Case FlexCodeSDK.VerificationStatus.v_VerificationFailed
                MsgBox("Verification failed")
            Case FlexCodeSDK.VerificationStatus.v_VerifyCaptureStop
                MsgBox("Stop verify")
            Case Else
                statusFP = False
                CheckFngr.Checked = True
        End Select
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
        PanelRead.Hide()
        PanelWrite.Hide()

        PnlRead.Show()
        PanelRead.Show()

        PnlWrite.Hide()
        PanelWrite.Hide()
    End Sub

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click
        PnlWrite.Show()

        PnlRead.Hide()
        PanelRead.Hide()
        PanelWrite.Show()

        Read.Enabled = False
        Write.Enabled = False
        Ext.Enabled = False

        TxtNIM_Write.Text = ""
        TxtNIM_Write.Focus()

        SerialPort1.Write("write" & "#")
        waktu = 25
        Timer3.Enabled = True
    End Sub
    Private Sub passing()
        Dim obj As New RegisFinger
        obj.NIMpass = TxtNIM_Write.Text
        obj.Show()
    End Sub

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        SerialPort1.Write(TxtNIM_Write.Text & "*")
        Timer3.Enabled = False
        waktu = 0

        RegisFinger.Show()
        Hide()

        Read.Enabled = True
        Write.Enabled = True
        Ext.Enabled = True

        PanelRead.Show()
        PnlRead.Show()

        PnlWrite.Hide()
        PanelWrite.Hide()

    End Sub

    Private Sub TxtNIM_Write_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNIM_Write.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnWrite.PerformClick()
            passing()
        End If
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
                    PictureBox1.Image = Nothing
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
                        Nama.Text = "NIM Tidak Terdaftar"
                    End If
                    Conn.Close()
                End If
            ElseIf Regex.IsMatch(NIM.Text, "DataKosong") Then
                NIM.Text = ""
                Stts.Text = "Data Kosong"
            ElseIf Regex.IsMatch(NIM.Text, "Write success!") Then
                NIM.Text = ""
                'obj.StatusRFID = "Penulisan RFID Tag Sukses"
                'obj.Show()
            ElseIf Regex.IsMatch(NIM.Text, "Write failed!") Then
                NIM.Text = ""
                'obj.StatusRFID = "Penulisan RFID Tag Gagal"
                'obj.Show()
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

    End Sub

    Private Sub CheckFngr_Click(sender As Object, e As EventArgs) Handles CheckFngr.Click
        FpVer.FPVerificationStop()
        FpVer.AddDeviceInfo("K520J00874", "06E-B04-3C7-413-D26", "1L6D-450D-E57E-D237-B9D8-7RG2")
        FpVer.FPVerificationStart()
        tampil()
        PictureBox1.Image = Nothing
        If CheckFngr.Checked = True Then
            CheckFngr.Enabled = False
        End If
    End Sub

End Class
