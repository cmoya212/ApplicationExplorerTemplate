<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleForm_TextFileBrowser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleForm_TextFileBrowser))
        Me.PathTextBox = New System.Windows.Forms.TextBox
        Me.GoButton = New System.Windows.Forms.Button
        Me.FileListBox = New System.Windows.Forms.ListBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'PathTextBox
        '
        Me.PathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PathTextBox.Location = New System.Drawing.Point(3, 3)
        Me.PathTextBox.Name = "PathTextBox"
        Me.PathTextBox.Size = New System.Drawing.Size(135, 20)
        Me.PathTextBox.TabIndex = 1
        '
        'GoButton
        '
        Me.GoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoButton.Location = New System.Drawing.Point(231, 3)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(57, 21)
        Me.GoButton.TabIndex = 2
        Me.GoButton.Text = "Show"
        Me.GoButton.UseVisualStyleBackColor = True
        '
        'FileListBox
        '
        Me.FileListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileListBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileListBox.FormattingEnabled = True
        Me.FileListBox.IntegralHeight = False
        Me.FileListBox.ItemHeight = 18
        Me.FileListBox.Location = New System.Drawing.Point(3, 27)
        Me.FileListBox.Name = "FileListBox"
        Me.FileListBox.Size = New System.Drawing.Size(285, 306)
        Me.FileListBox.Sorted = True
        Me.FileListBox.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(144, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'SampleForm_TextFileBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 335)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.FileListBox)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.PathTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SampleForm_TextFileBrowser"
        Me.Text = "Documents"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Friend WithEvents FileListBox As System.Windows.Forms.ListBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
