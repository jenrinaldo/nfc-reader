<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SrcWin
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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SrcBtn = New System.Windows.Forms.Button()
        Me.ExtBtn = New System.Windows.Forms.Label()
        Me.TextName = New System.Windows.Forms.TextBox()
        Me.TextStat = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Disconnect = New System.Windows.Forms.Button()
        Me.connect = New System.Windows.Forms.Button()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.port = New System.Windows.Forms.Button()
        Me.clr = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(29, 77)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(225, 20)
        Me.TextId.TabIndex = 0
        Me.TextId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NIM"
        '
        'SrcBtn
        '
        Me.SrcBtn.BackColor = System.Drawing.SystemColors.Highlight
        Me.SrcBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SrcBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.SrcBtn.Location = New System.Drawing.Point(29, 162)
        Me.SrcBtn.Name = "SrcBtn"
        Me.SrcBtn.Size = New System.Drawing.Size(225, 50)
        Me.SrcBtn.TabIndex = 3
        Me.SrcBtn.Text = "SEARCH"
        Me.SrcBtn.UseVisualStyleBackColor = False
        '
        'ExtBtn
        '
        Me.ExtBtn.AutoSize = True
        Me.ExtBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtBtn.Location = New System.Drawing.Point(12, 9)
        Me.ExtBtn.Name = "ExtBtn"
        Me.ExtBtn.Size = New System.Drawing.Size(21, 20)
        Me.ExtBtn.TabIndex = 4
        Me.ExtBtn.Text = "X"
        '
        'TextName
        '
        Me.TextName.Location = New System.Drawing.Point(29, 103)
        Me.TextName.Name = "TextName"
        Me.TextName.Size = New System.Drawing.Size(225, 20)
        Me.TextName.TabIndex = 1
        Me.TextName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextStat
        '
        Me.TextStat.Location = New System.Drawing.Point(29, 129)
        Me.TextStat.Name = "TextStat"
        Me.TextStat.Size = New System.Drawing.Size(225, 20)
        Me.TextStat.TabIndex = 2
        Me.TextStat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Disconnect
        '
        Me.Disconnect.Location = New System.Drawing.Point(401, 192)
        Me.Disconnect.Name = "Disconnect"
        Me.Disconnect.Size = New System.Drawing.Size(75, 23)
        Me.Disconnect.TabIndex = 7
        Me.Disconnect.Text = "Disconnect"
        Me.Disconnect.UseVisualStyleBackColor = True
        '
        'connect
        '
        Me.connect.Location = New System.Drawing.Point(401, 168)
        Me.connect.Name = "connect"
        Me.connect.Size = New System.Drawing.Size(75, 23)
        Me.connect.TabIndex = 6
        Me.connect.Text = "Connect"
        Me.connect.UseVisualStyleBackColor = True
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(355, 141)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(121, 21)
        Me.CmbPort.TabIndex = 9
        '
        'port
        '
        Me.port.Location = New System.Drawing.Point(288, 140)
        Me.port.Name = "port"
        Me.port.Size = New System.Drawing.Size(59, 24)
        Me.port.TabIndex = 8
        Me.port.Text = "Port"
        Me.port.UseVisualStyleBackColor = True
        '
        'clr
        '
        Me.clr.Location = New System.Drawing.Point(288, 192)
        Me.clr.Name = "clr"
        Me.clr.Size = New System.Drawing.Size(75, 23)
        Me.clr.TabIndex = 10
        Me.clr.Text = "Clear"
        Me.clr.UseVisualStyleBackColor = True
        '
        'SrcWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(488, 227)
        Me.Controls.Add(Me.clr)
        Me.Controls.Add(Me.CmbPort)
        Me.Controls.Add(Me.port)
        Me.Controls.Add(Me.Disconnect)
        Me.Controls.Add(Me.connect)
        Me.Controls.Add(Me.TextStat)
        Me.Controls.Add(Me.TextName)
        Me.Controls.Add(Me.ExtBtn)
        Me.Controls.Add(Me.SrcBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SrcWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SrcBtn As Button
    Friend WithEvents ExtBtn As Label
    Friend WithEvents TextName As TextBox
    Friend WithEvents TextStat As TextBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Disconnect As Button
    Friend WithEvents connect As Button
    Friend WithEvents CmbPort As ComboBox
    Friend WithEvents port As Button
    Friend WithEvents clr As Button
End Class
