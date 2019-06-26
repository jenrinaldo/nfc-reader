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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SrcBtn = New System.Windows.Forms.Button()
        Me.ExtBtn = New System.Windows.Forms.Label()
        Me.TextName = New System.Windows.Forms.TextBox()
        Me.TextStat = New System.Windows.Forms.TextBox()
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
        'SrcWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(284, 224)
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
End Class
