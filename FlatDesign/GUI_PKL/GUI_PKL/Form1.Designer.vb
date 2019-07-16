<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.PanelMENU = New System.Windows.Forms.Panel()
        Me.PnlRead = New System.Windows.Forms.Panel()
        Me.PnlWrite = New System.Windows.Forms.Panel()
        Me.Read = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Write = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BunifuCustomLabel4 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.BunifuCustomLabel3 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Ext = New System.Windows.Forms.Button()
        Me.Fingerprint = New Bunifu.Framework.UI.BunifuImageButton()
        Me.RFID = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelFinger = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.NoJari = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.NimFinger = New System.Windows.Forms.Label()
        Me.PanelWrite = New System.Windows.Forms.Panel()
        Me.Ext2 = New System.Windows.Forms.Button()
        Me.BtnWrite = New System.Windows.Forms.Button()
        Me.Label1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.NIMWrite = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.TxtNIM_Write = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.CheckRFID = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.CheckFngr = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.PanelRead = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NIM = New System.Windows.Forms.TextBox()
        Me.balasan = New System.Windows.Forms.Label()
        Me.Nama = New System.Windows.Forms.Label()
        Me.BunifuCustomLabel2 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.BunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Stts = New System.Windows.Forms.Label()
        Me.BtnCon = New System.Windows.Forms.Button()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.BtnScanPort = New System.Windows.Forms.Button()
        Me.BtnDiscon = New System.Windows.Forms.Button()
        Me.Jam = New System.Windows.Forms.Label()
        Me.Tanggal = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.BunifuGradientPanel1.SuspendLayout()
        Me.PanelMENU.SuspendLayout()
        CType(Me.Fingerprint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RFID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelFinger.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWrite.SuspendLayout()
        Me.PanelRead.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 30
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.Controls.Add(Me.PanelMENU)
        Me.BunifuGradientPanel1.Controls.Add(Me.Panel2)
        Me.BunifuGradientPanel1.Controls.Add(Me.BunifuCustomLabel4)
        Me.BunifuGradientPanel1.Controls.Add(Me.BunifuCustomLabel3)
        Me.BunifuGradientPanel1.Controls.Add(Me.Ext)
        Me.BunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.LightCoral
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.CadetBlue
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.MediumPurple
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.BlanchedAlmond
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(188, 421)
        Me.BunifuGradientPanel1.TabIndex = 0
        '
        'PanelMENU
        '
        Me.PanelMENU.BackColor = System.Drawing.Color.Transparent
        Me.PanelMENU.Controls.Add(Me.PnlRead)
        Me.PanelMENU.Controls.Add(Me.PnlWrite)
        Me.PanelMENU.Controls.Add(Me.Read)
        Me.PanelMENU.Controls.Add(Me.Write)
        Me.PanelMENU.Location = New System.Drawing.Point(3, 154)
        Me.PanelMENU.Name = "PanelMENU"
        Me.PanelMENU.Size = New System.Drawing.Size(211, 94)
        Me.PanelMENU.TabIndex = 20
        '
        'PnlRead
        '
        Me.PnlRead.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.PnlRead.Location = New System.Drawing.Point(6, 11)
        Me.PnlRead.Name = "PnlRead"
        Me.PnlRead.Size = New System.Drawing.Size(5, 28)
        Me.PnlRead.TabIndex = 4
        '
        'PnlWrite
        '
        Me.PnlWrite.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.PnlWrite.Location = New System.Drawing.Point(6, 62)
        Me.PnlWrite.Name = "PnlWrite"
        Me.PnlWrite.Size = New System.Drawing.Size(5, 28)
        Me.PnlWrite.TabIndex = 5
        '
        'Read
        '
        Me.Read.Activecolor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Read.BackColor = System.Drawing.Color.Transparent
        Me.Read.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Read.BorderRadius = 0
        Me.Read.ButtonText = "       Daftar Hadir"
        Me.Read.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Read.DisabledColor = System.Drawing.Color.Gray
        Me.Read.Font = New System.Drawing.Font("Segoe UI Light", 11.75!)
        Me.Read.Iconcolor = System.Drawing.Color.Transparent
        Me.Read.Iconimage = Nothing
        Me.Read.Iconimage_right = Nothing
        Me.Read.Iconimage_right_Selected = Nothing
        Me.Read.Iconimage_Selected = Nothing
        Me.Read.IconMarginLeft = 0
        Me.Read.IconMarginRight = 0
        Me.Read.IconRightVisible = True
        Me.Read.IconRightZoom = 0R
        Me.Read.IconVisible = True
        Me.Read.IconZoom = 90.0R
        Me.Read.IsTab = False
        Me.Read.Location = New System.Drawing.Point(-1, 5)
        Me.Read.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Read.Name = "Read"
        Me.Read.Normalcolor = System.Drawing.Color.Transparent
        Me.Read.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Read.OnHoverTextColor = System.Drawing.Color.White
        Me.Read.selected = True
        Me.Read.Size = New System.Drawing.Size(190, 41)
        Me.Read.TabIndex = 2
        Me.Read.Text = "       Daftar Hadir"
        Me.Read.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Read.Textcolor = System.Drawing.Color.White
        Me.Read.TextFont = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Write
        '
        Me.Write.Activecolor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Write.BackColor = System.Drawing.Color.Transparent
        Me.Write.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Write.BorderRadius = 0
        Me.Write.ButtonText = "       Registrasi"
        Me.Write.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Write.DisabledColor = System.Drawing.Color.Gray
        Me.Write.Font = New System.Drawing.Font("Segoe UI Light", 11.75!)
        Me.Write.Iconcolor = System.Drawing.Color.Transparent
        Me.Write.Iconimage = Nothing
        Me.Write.Iconimage_right = Nothing
        Me.Write.Iconimage_right_Selected = Nothing
        Me.Write.Iconimage_Selected = Nothing
        Me.Write.IconMarginLeft = 0
        Me.Write.IconMarginRight = 0
        Me.Write.IconRightVisible = True
        Me.Write.IconRightZoom = 0R
        Me.Write.IconVisible = True
        Me.Write.IconZoom = 90.0R
        Me.Write.IsTab = False
        Me.Write.Location = New System.Drawing.Point(-1, 56)
        Me.Write.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Write.Name = "Write"
        Me.Write.Normalcolor = System.Drawing.Color.Transparent
        Me.Write.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Write.OnHoverTextColor = System.Drawing.Color.White
        Me.Write.selected = False
        Me.Write.Size = New System.Drawing.Size(190, 41)
        Me.Write.TabIndex = 3
        Me.Write.Text = "       Registrasi"
        Me.Write.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Write.Textcolor = System.Drawing.Color.White
        Me.Write.TextFont = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(3, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(55, 56)
        Me.Panel2.TabIndex = 18
        '
        'BunifuCustomLabel4
        '
        Me.BunifuCustomLabel4.AutoSize = True
        Me.BunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent
        Me.BunifuCustomLabel4.Font = New System.Drawing.Font("Century Gothic", 7.5!)
        Me.BunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BunifuCustomLabel4.Location = New System.Drawing.Point(56, 37)
        Me.BunifuCustomLabel4.Name = "BunifuCustomLabel4"
        Me.BunifuCustomLabel4.Size = New System.Drawing.Size(126, 15)
        Me.BunifuCustomLabel4.TabIndex = 17
        Me.BunifuCustomLabel4.Text = "UNIVERSITAS BRAWIJAYA"
        '
        'BunifuCustomLabel3
        '
        Me.BunifuCustomLabel3.AutoSize = True
        Me.BunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuCustomLabel3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BunifuCustomLabel3.Location = New System.Drawing.Point(55, 16)
        Me.BunifuCustomLabel3.Name = "BunifuCustomLabel3"
        Me.BunifuCustomLabel3.Size = New System.Drawing.Size(134, 21)
        Me.BunifuCustomLabel3.TabIndex = 16
        Me.BunifuCustomLabel3.Text = "PERPUSTAKAAN"
        '
        'Ext
        '
        Me.Ext.BackColor = System.Drawing.Color.Transparent
        Me.Ext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ext.FlatAppearance.BorderSize = 0
        Me.Ext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Ext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Ext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ext.Font = New System.Drawing.Font("Segoe UI Light", 11.75!)
        Me.Ext.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Ext.Location = New System.Drawing.Point(-4, 385)
        Me.Ext.Name = "Ext"
        Me.Ext.Size = New System.Drawing.Size(196, 40)
        Me.Ext.TabIndex = 4
        Me.Ext.Text = "KELUAR"
        Me.Ext.UseVisualStyleBackColor = False
        '
        'Fingerprint
        '
        Me.Fingerprint.BackColor = System.Drawing.Color.Transparent
        Me.Fingerprint.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fingerprint.Image = CType(resources.GetObject("Fingerprint.Image"), System.Drawing.Image)
        Me.Fingerprint.ImageActive = Nothing
        Me.Fingerprint.Location = New System.Drawing.Point(364, 324)
        Me.Fingerprint.Name = "Fingerprint"
        Me.Fingerprint.Size = New System.Drawing.Size(73, 55)
        Me.Fingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Fingerprint.TabIndex = 23
        Me.Fingerprint.TabStop = False
        Me.Fingerprint.Zoom = 10
        '
        'RFID
        '
        Me.RFID.BackColor = System.Drawing.Color.Transparent
        Me.RFID.Cursor = System.Windows.Forms.Cursors.Default
        Me.RFID.Image = CType(resources.GetObject("RFID.Image"), System.Drawing.Image)
        Me.RFID.ImageActive = Nothing
        Me.RFID.Location = New System.Drawing.Point(466, 327)
        Me.RFID.Name = "RFID"
        Me.RFID.Size = New System.Drawing.Size(68, 52)
        Me.RFID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RFID.TabIndex = 21
        Me.RFID.TabStop = False
        Me.RFID.Zoom = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PanelFinger)
        Me.Panel1.Controls.Add(Me.PanelWrite)
        Me.Panel1.Controls.Add(Me.CheckRFID)
        Me.Panel1.Controls.Add(Me.CheckFngr)
        Me.Panel1.Controls.Add(Me.RFID)
        Me.Panel1.Controls.Add(Me.Fingerprint)
        Me.Panel1.Controls.Add(Me.PanelRead)
        Me.Panel1.Location = New System.Drawing.Point(187, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(542, 386)
        Me.Panel1.TabIndex = 1
        '
        'PanelFinger
        '
        Me.PanelFinger.Controls.Add(Me.Label2)
        Me.PanelFinger.Controls.Add(Me.RichTextBox1)
        Me.PanelFinger.Controls.Add(Me.NoJari)
        Me.PanelFinger.Controls.Add(Me.PictureBox2)
        Me.PanelFinger.Controls.Add(Me.NimFinger)
        Me.PanelFinger.Location = New System.Drawing.Point(80, 103)
        Me.PanelFinger.Name = "PanelFinger"
        Me.PanelFinger.Size = New System.Drawing.Size(394, 204)
        Me.PanelFinger.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Label2"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(42, 55)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(182, 96)
        Me.RichTextBox1.TabIndex = 38
        Me.RichTextBox1.Text = ""
        '
        'NoJari
        '
        Me.NoJari.FormattingEnabled = True
        Me.NoJari.Items.AddRange(New Object() {"Left Pinkie", "Left Ring", "Left Middle", "Left Index", "Left Thumb", "Right Thumb", "Right Index", "Right Middle", "Right Ring", "Right Pinkie"})
        Me.NoJari.Location = New System.Drawing.Point(42, 30)
        Me.NoJari.Name = "NoJari"
        Me.NoJari.Size = New System.Drawing.Size(182, 21)
        Me.NoJari.TabIndex = 37
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(233, 29)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(124, 138)
        Me.PictureBox2.TabIndex = 36
        Me.PictureBox2.TabStop = False
        '
        'NimFinger
        '
        Me.NimFinger.AutoSize = True
        Me.NimFinger.Cursor = System.Windows.Forms.Cursors.Default
        Me.NimFinger.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.NimFinger.Location = New System.Drawing.Point(38, 5)
        Me.NimFinger.Name = "NimFinger"
        Me.NimFinger.Size = New System.Drawing.Size(27, 21)
        Me.NimFinger.TabIndex = 35
        Me.NimFinger.Text = "ID"
        '
        'PanelWrite
        '
        Me.PanelWrite.BackColor = System.Drawing.Color.Transparent
        Me.PanelWrite.Controls.Add(Me.Ext2)
        Me.PanelWrite.Controls.Add(Me.BtnWrite)
        Me.PanelWrite.Controls.Add(Me.Label1)
        Me.PanelWrite.Controls.Add(Me.NIMWrite)
        Me.PanelWrite.Controls.Add(Me.TxtNIM_Write)
        Me.PanelWrite.Controls.Add(Me.Panel8)
        Me.PanelWrite.Location = New System.Drawing.Point(70, 118)
        Me.PanelWrite.Name = "PanelWrite"
        Me.PanelWrite.Size = New System.Drawing.Size(416, 166)
        Me.PanelWrite.TabIndex = 2
        '
        'Ext2
        '
        Me.Ext2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Ext2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.Ext2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.Ext2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.Ext2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ext2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Ext2.Location = New System.Drawing.Point(242, 98)
        Me.Ext2.Name = "Ext2"
        Me.Ext2.Size = New System.Drawing.Size(115, 41)
        Me.Ext2.TabIndex = 22
        Me.Ext2.Text = "BATAL"
        Me.Ext2.UseVisualStyleBackColor = True
        '
        'BtnWrite
        '
        Me.BtnWrite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnWrite.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.BtnWrite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.BtnWrite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.BtnWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnWrite.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.BtnWrite.Location = New System.Drawing.Point(107, 98)
        Me.BtnWrite.Name = "BtnWrite"
        Me.BtnWrite.Size = New System.Drawing.Size(115, 41)
        Me.BtnWrite.TabIndex = 21
        Me.BtnWrite.Text = "TULIS"
        Me.BtnWrite.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "TETAP TEMPELKAN KARTU PADA READER"
        '
        'NIMWrite
        '
        Me.NIMWrite.AutoSize = True
        Me.NIMWrite.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NIMWrite.Location = New System.Drawing.Point(61, 69)
        Me.NIMWrite.Name = "NIMWrite"
        Me.NIMWrite.Size = New System.Drawing.Size(40, 20)
        Me.NIMWrite.TabIndex = 17
        Me.NIMWrite.Text = "NIM"
        '
        'TxtNIM_Write
        '
        Me.TxtNIM_Write.BackColor = System.Drawing.Color.White
        Me.TxtNIM_Write.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNIM_Write.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNIM_Write.Location = New System.Drawing.Point(107, 68)
        Me.TxtNIM_Write.Name = "TxtNIM_Write"
        Me.TxtNIM_Write.Size = New System.Drawing.Size(249, 19)
        Me.TxtNIM_Write.TabIndex = 16
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Coral
        Me.Panel8.Location = New System.Drawing.Point(107, 89)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(249, 1)
        Me.Panel8.TabIndex = 15
        '
        'CheckRFID
        '
        Me.CheckRFID.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckRFID.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckRFID.Checked = True
        Me.CheckRFID.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckRFID.ForeColor = System.Drawing.Color.White
        Me.CheckRFID.Location = New System.Drawing.Point(445, 342)
        Me.CheckRFID.Name = "CheckRFID"
        Me.CheckRFID.Size = New System.Drawing.Size(20, 20)
        Me.CheckRFID.TabIndex = 28
        '
        'CheckFngr
        '
        Me.CheckFngr.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckFngr.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.CheckFngr.Checked = True
        Me.CheckFngr.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.CheckFngr.ForeColor = System.Drawing.Color.White
        Me.CheckFngr.Location = New System.Drawing.Point(349, 342)
        Me.CheckFngr.Name = "CheckFngr"
        Me.CheckFngr.Size = New System.Drawing.Size(20, 20)
        Me.CheckFngr.TabIndex = 27
        '
        'PanelRead
        '
        Me.PanelRead.BackColor = System.Drawing.Color.Transparent
        Me.PanelRead.Controls.Add(Me.PictureBox1)
        Me.PanelRead.Controls.Add(Me.NIM)
        Me.PanelRead.Controls.Add(Me.balasan)
        Me.PanelRead.Controls.Add(Me.Nama)
        Me.PanelRead.Controls.Add(Me.BunifuCustomLabel2)
        Me.PanelRead.Controls.Add(Me.Panel9)
        Me.PanelRead.Controls.Add(Me.BunifuCustomLabel1)
        Me.PanelRead.Controls.Add(Me.Panel10)
        Me.PanelRead.Location = New System.Drawing.Point(3, 15)
        Me.PanelRead.Name = "PanelRead"
        Me.PanelRead.Size = New System.Drawing.Size(531, 275)
        Me.PanelRead.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(403, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 143)
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'NIM
        '
        Me.NIM.BackColor = System.Drawing.Color.White
        Me.NIM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NIM.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.NIM.Location = New System.Drawing.Point(142, 9)
        Me.NIM.Name = "NIM"
        Me.NIM.Size = New System.Drawing.Size(247, 20)
        Me.NIM.TabIndex = 31
        '
        'balasan
        '
        Me.balasan.AutoSize = True
        Me.balasan.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.balasan.Location = New System.Drawing.Point(4, 249)
        Me.balasan.Name = "balasan"
        Me.balasan.Size = New System.Drawing.Size(67, 20)
        Me.balasan.TabIndex = 26
        Me.balasan.Text = "balasan"
        '
        'Nama
        '
        Me.Nama.AutoSize = True
        Me.Nama.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nama.Location = New System.Drawing.Point(137, 39)
        Me.Nama.Name = "Nama"
        Me.Nama.Size = New System.Drawing.Size(99, 21)
        Me.Nama.TabIndex = 24
        Me.Nama.Text = "label nama"
        '
        'BunifuCustomLabel2
        '
        Me.BunifuCustomLabel2.AutoSize = True
        Me.BunifuCustomLabel2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel2.Location = New System.Drawing.Point(10, 40)
        Me.BunifuCustomLabel2.Name = "BunifuCustomLabel2"
        Me.BunifuCustomLabel2.Size = New System.Drawing.Size(57, 20)
        Me.BunifuCustomLabel2.TabIndex = 23
        Me.BunifuCustomLabel2.Text = "NAMA"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Coral
        Me.Panel9.Location = New System.Drawing.Point(140, 60)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(249, 1)
        Me.Panel9.TabIndex = 22
        '
        'BunifuCustomLabel1
        '
        Me.BunifuCustomLabel1.AutoSize = True
        Me.BunifuCustomLabel1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel1.Location = New System.Drawing.Point(10, 12)
        Me.BunifuCustomLabel1.Name = "BunifuCustomLabel1"
        Me.BunifuCustomLabel1.Size = New System.Drawing.Size(40, 20)
        Me.BunifuCustomLabel1.TabIndex = 20
        Me.BunifuCustomLabel1.Text = "NIM"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Coral
        Me.Panel10.Location = New System.Drawing.Point(141, 32)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(249, 1)
        Me.Panel10.TabIndex = 19
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.Controls.Add(Me.Stts)
        Me.Panel4.Controls.Add(Me.BtnCon)
        Me.Panel4.Controls.Add(Me.CmbPort)
        Me.Panel4.Controls.Add(Me.BtnScanPort)
        Me.Panel4.Controls.Add(Me.BtnDiscon)
        Me.Panel4.Controls.Add(Me.Jam)
        Me.Panel4.Controls.Add(Me.Tanggal)
        Me.Panel4.Location = New System.Drawing.Point(184, 385)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(546, 40)
        Me.Panel4.TabIndex = 1
        '
        'Stts
        '
        Me.Stts.AutoSize = True
        Me.Stts.Font = New System.Drawing.Font("Segoe UI Historic", 8.0!)
        Me.Stts.Location = New System.Drawing.Point(438, 4)
        Me.Stts.Name = "Stts"
        Me.Stts.Size = New System.Drawing.Size(39, 13)
        Me.Stts.TabIndex = 18
        Me.Stts.Text = "Status"
        '
        'BtnCon
        '
        Me.BtnCon.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCon.ForeColor = System.Drawing.Color.White
        Me.BtnCon.Location = New System.Drawing.Point(348, 4)
        Me.BtnCon.Name = "BtnCon"
        Me.BtnCon.Size = New System.Drawing.Size(87, 27)
        Me.BtnCon.TabIndex = 4
        Me.BtnCon.Text = "CONNECT"
        Me.BtnCon.UseVisualStyleBackColor = False
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(215, 7)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(121, 21)
        Me.CmbPort.TabIndex = 15
        '
        'BtnScanPort
        '
        Me.BtnScanPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnScanPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnScanPort.ForeColor = System.Drawing.Color.White
        Me.BtnScanPort.Location = New System.Drawing.Point(161, 4)
        Me.BtnScanPort.Name = "BtnScanPort"
        Me.BtnScanPort.Size = New System.Drawing.Size(50, 27)
        Me.BtnScanPort.TabIndex = 3
        Me.BtnScanPort.Text = "PORT"
        Me.BtnScanPort.UseVisualStyleBackColor = False
        '
        'BtnDiscon
        '
        Me.BtnDiscon.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnDiscon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDiscon.ForeColor = System.Drawing.Color.White
        Me.BtnDiscon.Location = New System.Drawing.Point(348, 4)
        Me.BtnDiscon.Name = "BtnDiscon"
        Me.BtnDiscon.Size = New System.Drawing.Size(87, 27)
        Me.BtnDiscon.TabIndex = 17
        Me.BtnDiscon.Text = "DISCONNECT"
        Me.BtnDiscon.UseVisualStyleBackColor = False
        '
        'Jam
        '
        Me.Jam.AutoSize = True
        Me.Jam.Font = New System.Drawing.Font("Segoe UI Historic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Jam.Location = New System.Drawing.Point(11, 22)
        Me.Jam.Name = "Jam"
        Me.Jam.Size = New System.Drawing.Size(41, 15)
        Me.Jam.TabIndex = 1
        Me.Jam.Text = "Label2"
        '
        'Tanggal
        '
        Me.Tanggal.AutoSize = True
        Me.Tanggal.Font = New System.Drawing.Font("Segoe UI Historic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tanggal.Location = New System.Drawing.Point(9, 3)
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.Size = New System.Drawing.Size(46, 17)
        Me.Tanggal.TabIndex = 0
        Me.Tanggal.Text = "Label1"
        '
        'Timer1
        '
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'SerialPort1
        '
        '
        'Timer2
        '
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.ClientSize = New System.Drawing.Size(731, 421)
        Me.Controls.Add(Me.BunifuGradientPanel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.BunifuGradientPanel1.ResumeLayout(False)
        Me.BunifuGradientPanel1.PerformLayout()
        Me.PanelMENU.ResumeLayout(False)
        CType(Me.Fingerprint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RFID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelFinger.ResumeLayout(False)
        Me.PanelFinger.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWrite.ResumeLayout(False)
        Me.PanelWrite.PerformLayout()
        Me.PanelRead.ResumeLayout(False)
        Me.PanelRead.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Tanggal As Label
    Friend WithEvents Jam As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BtnCon As Button
    Friend WithEvents CmbPort As ComboBox
    Friend WithEvents BtnScanPort As Button
    Friend WithEvents BtnDiscon As Button
    Friend WithEvents Stts As Label
    Friend WithEvents Ext As Button
    Friend WithEvents PanelRead As Panel
    Friend WithEvents PanelWrite As Panel
    Friend WithEvents Label1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents NIMWrite As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents TxtNIM_Write As TextBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Nama As Label
    Friend WithEvents BunifuCustomLabel2 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents BunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Timer3 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents BtnWrite As Button
    Friend WithEvents Ext2 As Button
    Friend WithEvents BunifuCustomLabel4 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents BunifuCustomLabel3 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RFID As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents Fingerprint As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents PanelMENU As Panel
    Friend WithEvents PnlRead As Panel
    Friend WithEvents PnlWrite As Panel
    Friend WithEvents Read As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Write As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents NIM As TextBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents balasan As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckRFID As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents CheckFngr As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents PanelFinger As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents NoJari As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents NimFinger As Label
End Class
