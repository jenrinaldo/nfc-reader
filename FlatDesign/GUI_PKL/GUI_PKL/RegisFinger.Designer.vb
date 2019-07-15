<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisFinger
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
        Me.ID = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NoJari = New System.Windows.Forms.ComboBox()
        Me.Template = New System.Windows.Forms.RichTextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ID
        '
        Me.ID.AutoSize = True
        Me.ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.ID.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.ID.Location = New System.Drawing.Point(21, 23)
        Me.ID.Name = "ID"
        Me.ID.Size = New System.Drawing.Size(27, 21)
        Me.ID.TabIndex = 0
        Me.ID.Text = "ID"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(218, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 146)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'NoJari
        '
        Me.NoJari.FormattingEnabled = True
        Me.NoJari.Location = New System.Drawing.Point(25, 48)
        Me.NoJari.Name = "NoJari"
        Me.NoJari.Size = New System.Drawing.Size(182, 21)
        Me.NoJari.TabIndex = 34
        '
        'Template
        '
        Me.Template.Location = New System.Drawing.Point(25, 76)
        Me.Template.Name = "Template"
        Me.Template.Size = New System.Drawing.Size(182, 93)
        Me.Template.TabIndex = 35
        Me.Template.Text = ""
        '
        'RegisFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 217)
        Me.Controls.Add(Me.Template)
        Me.Controls.Add(Me.NoJari)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RegisFinger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RegisFinger"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ID As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NoJari As ComboBox
    Friend WithEvents Template As RichTextBox
End Class
