<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.read = New System.Windows.Forms.RichTextBox()
        Me.write = New System.Windows.Forms.RichTextBox()
        Me.port = New System.Windows.Forms.Button()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.connect = New System.Windows.Forms.Button()
        Me.Disconnect = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.clr = New System.Windows.Forms.Button()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'read
        '
        Me.read.Location = New System.Drawing.Point(12, 12)
        Me.read.Name = "read"
        Me.read.Size = New System.Drawing.Size(390, 347)
        Me.read.TabIndex = 0
        Me.read.Text = ""
        '
        'write
        '
        Me.write.Location = New System.Drawing.Point(463, 12)
        Me.write.Name = "write"
        Me.write.Size = New System.Drawing.Size(390, 347)
        Me.write.TabIndex = 1
        Me.write.Text = ""
        '
        'port
        '
        Me.port.Location = New System.Drawing.Point(41, 366)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(59, 24)
        Me.port.TabIndex = 2
        Me.port.Text = "Port"
        Me.port.UseVisualStyleBackColor = True
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(108, 367)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(121, 21)
        Me.CmbPort.TabIndex = 3
        '
        'connect
        '
        Me.connect.Location = New System.Drawing.Point(246, 366)
        Me.connect.Name = "connect"
        Me.connect.Size = New System.Drawing.Size(75, 23)
        Me.connect.TabIndex = 4
        Me.connect.Text = "Connect"
        Me.connect.UseVisualStyleBackColor = True
        '
        'Disconnect
        '
        Me.Disconnect.Location = New System.Drawing.Point(246, 390)
        Me.Disconnect.Name = "Disconnect"
        Me.Disconnect.Size = New System.Drawing.Size(75, 23)
        Me.Disconnect.TabIndex = 5
        Me.Disconnect.Text = "Disconnect"
        Me.Disconnect.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        '
        'clr
        '
        Me.clr.Location = New System.Drawing.Point(778, 366)
        Me.clr.Name = "clr"
        Me.clr.Size = New System.Drawing.Size(75, 23)
        Me.clr.TabIndex = 6
        Me.clr.Text = "Clear"
        Me.clr.UseVisualStyleBackColor = True
        '
        'btnWrite
        '
        Me.btnWrite.Location = New System.Drawing.Point(463, 366)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(75, 23)
        Me.btnWrite.TabIndex = 7
        Me.btnWrite.Text = "Write"
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(463, 365)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Write"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 425)
        Me.Controls.Add(Me.btnWrite)
        Me.Controls.Add(Me.clr)
        Me.Controls.Add(Me.Disconnect)
        Me.Controls.Add(Me.connect)
        Me.Controls.Add(Me.CmbPort)
        Me.Controls.Add(Me.port)
        Me.Controls.Add(Me.write)
        Me.Controls.Add(Me.read)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents read As RichTextBox
    Friend WithEvents write As RichTextBox
    Friend WithEvents port As Button
    Friend WithEvents CmbPort As ComboBox
    Friend WithEvents connect As Button
    Friend WithEvents Disconnect As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents clr As Button
    Friend WithEvents btnWrite As Button
    Friend WithEvents Button1 As Button
End Class
