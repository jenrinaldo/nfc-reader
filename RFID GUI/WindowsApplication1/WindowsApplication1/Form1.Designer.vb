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
        Me.Judul = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Jam = New System.Windows.Forms.Label()
        Me.Tanggal = New System.Windows.Forms.Label()
        Me.Write = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NIM = New System.Windows.Forms.Label()
        Me.TxtUsr = New System.Windows.Forms.TextBox()
        Me.LabelNIM = New System.Windows.Forms.Label()
        Me.LabelNama = New System.Windows.Forms.Label()
        Me.Ext = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BtnScanPort = New System.Windows.Forms.Button()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.BtnCon = New System.Windows.Forms.Button()
        Me.BtnDiscon = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Login = New System.Windows.Forms.Button()
        Me.Ext2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPass = New System.Windows.Forms.TextBox()
        Me.Nama = New System.Windows.Forms.Label()
        Me.Login2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNIM_2 = New System.Windows.Forms.TextBox()
        Me.Write2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Ext3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Judul
        '
        Me.Judul.AutoSize = True
        Me.Judul.Font = New System.Drawing.Font("Tw Cen MT Condensed", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Judul.ForeColor = System.Drawing.Color.Gray
        Me.Judul.Location = New System.Drawing.Point(110, 23)
        Me.Judul.Name = "Judul"
        Me.Judul.Size = New System.Drawing.Size(163, 31)
        Me.Judul.TabIndex = 1
        Me.Judul.Text = "KEANGGOTAAN"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Jam)
        Me.Panel1.Controls.Add(Me.Tanggal)
        Me.Panel1.Controls.Add(Me.Write)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 354)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 48)
        Me.Panel1.TabIndex = 2
        '
        'Jam
        '
        Me.Jam.AutoSize = True
        Me.Jam.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Jam.Location = New System.Drawing.Point(312, 25)
        Me.Jam.Name = "Jam"
        Me.Jam.Size = New System.Drawing.Size(51, 18)
        Me.Jam.TabIndex = 7
        Me.Jam.Text = "Label1"
        '
        'Tanggal
        '
        Me.Tanggal.AutoSize = True
        Me.Tanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tanggal.Location = New System.Drawing.Point(288, 4)
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.Size = New System.Drawing.Size(51, 18)
        Me.Tanggal.TabIndex = 6
        Me.Tanggal.Text = "Label1"
        '
        'Write
        '
        Me.Write.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Write.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Write.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Write.Location = New System.Drawing.Point(0, 0)
        Me.Write.Margin = New System.Windows.Forms.Padding(0)
        Me.Write.Name = "Write"
        Me.Write.Size = New System.Drawing.Size(137, 48)
        Me.Write.TabIndex = 5
        Me.Write.Text = "Create Account"
        Me.Write.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(467, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 19)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Username"
        '
        'NIM
        '
        Me.NIM.AutoSize = True
        Me.NIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NIM.ForeColor = System.Drawing.Color.Gray
        Me.NIM.Location = New System.Drawing.Point(35, 92)
        Me.NIM.Name = "NIM"
        Me.NIM.Size = New System.Drawing.Size(0, 24)
        Me.NIM.TabIndex = 5
        '
        'TxtUsr
        '
        Me.TxtUsr.BackColor = System.Drawing.Color.White
        Me.TxtUsr.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.TxtUsr.ForeColor = System.Drawing.Color.Gray
        Me.TxtUsr.Location = New System.Drawing.Point(535, 84)
        Me.TxtUsr.Name = "TxtUsr"
        Me.TxtUsr.Size = New System.Drawing.Size(248, 29)
        Me.TxtUsr.TabIndex = 15
        '
        'LabelNIM
        '
        Me.LabelNIM.AutoSize = True
        Me.LabelNIM.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNIM.Location = New System.Drawing.Point(30, 73)
        Me.LabelNIM.Name = "LabelNIM"
        Me.LabelNIM.Size = New System.Drawing.Size(32, 19)
        Me.LabelNIM.TabIndex = 5
        Me.LabelNIM.Text = "NIM"
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.Location = New System.Drawing.Point(30, 138)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(44, 19)
        Me.LabelNama.TabIndex = 6
        Me.LabelNama.Text = "NAMA"
        '
        'Ext
        '
        Me.Ext.AutoSize = True
        Me.Ext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ext.Location = New System.Drawing.Point(54, 9)
        Me.Ext.Name = "Ext"
        Me.Ext.Size = New System.Drawing.Size(20, 20)
        Me.Ext.TabIndex = 7
        Me.Ext.Text = "X"
        '
        'Timer1
        '
        '
        'BtnScanPort
        '
        Me.BtnScanPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnScanPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnScanPort.ForeColor = System.Drawing.Color.White
        Me.BtnScanPort.Location = New System.Drawing.Point(53, 295)
        Me.BtnScanPort.Name = "BtnScanPort"
        Me.BtnScanPort.Size = New System.Drawing.Size(50, 27)
        Me.BtnScanPort.TabIndex = 8
        Me.BtnScanPort.Text = "PORT"
        Me.BtnScanPort.UseVisualStyleBackColor = False
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(107, 298)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(121, 21)
        Me.CmbPort.TabIndex = 9
        '
        'BtnCon
        '
        Me.BtnCon.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCon.ForeColor = System.Drawing.Color.White
        Me.BtnCon.Location = New System.Drawing.Point(240, 295)
        Me.BtnCon.Name = "BtnCon"
        Me.BtnCon.Size = New System.Drawing.Size(87, 27)
        Me.BtnCon.TabIndex = 12
        Me.BtnCon.Text = "CONNECT"
        Me.BtnCon.UseVisualStyleBackColor = False
        '
        'BtnDiscon
        '
        Me.BtnDiscon.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.BtnDiscon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDiscon.ForeColor = System.Drawing.Color.White
        Me.BtnDiscon.Location = New System.Drawing.Point(240, 295)
        Me.BtnDiscon.Name = "BtnDiscon"
        Me.BtnDiscon.Size = New System.Drawing.Size(87, 27)
        Me.BtnDiscon.TabIndex = 13
        Me.BtnDiscon.Text = "DISCONNECT"
        Me.BtnDiscon.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'Login
        '
        Me.Login.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Login.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login.Location = New System.Drawing.Point(29, 224)
        Me.Login.Margin = New System.Windows.Forms.Padding(0)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(325, 42)
        Me.Login.TabIndex = 5
        Me.Login.Text = "LOG IN"
        Me.Login.UseVisualStyleBackColor = False
        '
        'Ext2
        '
        Me.Ext2.AutoSize = True
        Me.Ext2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ext2.Location = New System.Drawing.Point(117, 3)
        Me.Ext2.Name = "Ext2"
        Me.Ext2.Size = New System.Drawing.Size(20, 20)
        Me.Ext2.TabIndex = 14
        Me.Ext2.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(469, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 19)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Password"
        '
        'TxtPass
        '
        Me.TxtPass.BackColor = System.Drawing.Color.White
        Me.TxtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.TxtPass.ForeColor = System.Drawing.Color.Gray
        Me.TxtPass.Location = New System.Drawing.Point(535, 114)
        Me.TxtPass.Name = "TxtPass"
        Me.TxtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPass.Size = New System.Drawing.Size(248, 29)
        Me.TxtPass.TabIndex = 16
        '
        'Nama
        '
        Me.Nama.AutoSize = True
        Me.Nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nama.ForeColor = System.Drawing.Color.Gray
        Me.Nama.Location = New System.Drawing.Point(36, 157)
        Me.Nama.Name = "Nama"
        Me.Nama.Size = New System.Drawing.Size(0, 24)
        Me.Nama.TabIndex = 15
        '
        'Login2
        '
        Me.Login2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Login2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Login2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Login2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Login2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Login2.Location = New System.Drawing.Point(680, 146)
        Me.Login2.Margin = New System.Windows.Forms.Padding(0)
        Me.Login2.Name = "Login2"
        Me.Login2.Size = New System.Drawing.Size(102, 42)
        Me.Login2.TabIndex = 18
        Me.Login2.Text = "LOGIN"
        Me.Login2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(471, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 19)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "NIM"
        '
        'txtNIM_2
        '
        Me.txtNIM_2.BackColor = System.Drawing.Color.White
        Me.txtNIM_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.txtNIM_2.ForeColor = System.Drawing.Color.Gray
        Me.txtNIM_2.Location = New System.Drawing.Point(474, 224)
        Me.txtNIM_2.Name = "txtNIM_2"
        Me.txtNIM_2.Size = New System.Drawing.Size(309, 29)
        Me.txtNIM_2.TabIndex = 20
        '
        'Write2
        '
        Me.Write2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Write2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Write2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Write2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Write2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Write2.Location = New System.Drawing.Point(681, 256)
        Me.Write2.Margin = New System.Windows.Forms.Padding(0)
        Me.Write2.Name = "Write2"
        Me.Write2.Size = New System.Drawing.Size(102, 42)
        Me.Write2.TabIndex = 21
        Me.Write2.Text = "WRITE"
        Me.Write2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Label4"
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Ext3
        '
        Me.Ext3.AutoSize = True
        Me.Ext3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ext3.Location = New System.Drawing.Point(12, 11)
        Me.Ext3.Name = "Ext3"
        Me.Ext3.Size = New System.Drawing.Size(20, 20)
        Me.Ext3.TabIndex = 23
        Me.Ext3.Text = "X"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(804, 402)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Write2)
        Me.Controls.Add(Me.txtNIM_2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NIM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Nama)
        Me.Controls.Add(Me.Login2)
        Me.Controls.Add(Me.TxtUsr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCon)
        Me.Controls.Add(Me.CmbPort)
        Me.Controls.Add(Me.TxtPass)
        Me.Controls.Add(Me.BtnScanPort)
        Me.Controls.Add(Me.Ext)
        Me.Controls.Add(Me.LabelNama)
        Me.Controls.Add(Me.LabelNIM)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Judul)
        Me.Controls.Add(Me.BtnDiscon)
        Me.Controls.Add(Me.Ext2)
        Me.Controls.Add(Me.Ext3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Judul As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Write As Button
    Friend WithEvents LabelNIM As Label
    Friend WithEvents LabelNama As Label
    Friend WithEvents Ext As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Tanggal As Label
    Friend WithEvents Jam As Label
    Friend WithEvents BtnScanPort As Button
    Friend WithEvents CmbPort As ComboBox
    Friend WithEvents BtnCon As Button
    Friend WithEvents BtnDiscon As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer2 As Timer
    Friend WithEvents NIM As Label
    Friend WithEvents Login As Button
    Friend WithEvents Ext2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtUsr As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPass As TextBox
    Friend WithEvents Nama As Label
    Friend WithEvents Login2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNIM_2 As TextBox
    Friend WithEvents Write2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Ext3 As Label
End Class
