<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LoginLabel = New System.Windows.Forms.Label
        Me.UserNameLabel = New System.Windows.Forms.Label
        Me.UserNameTextBox = New System.Windows.Forms.TextBox
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.CloseButton = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ApplicationExplorer.My.Resources.Resources.Login
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'LoginLabel
        '
        resources.ApplyResources(Me.LoginLabel, "LoginLabel")
        Me.LoginLabel.Name = "LoginLabel"
        '
        'UserNameLabel
        '
        resources.ApplyResources(Me.UserNameLabel, "UserNameLabel")
        Me.UserNameLabel.Name = "UserNameLabel"
        '
        'UserNameTextBox
        '
        resources.ApplyResources(Me.UserNameTextBox, "UserNameTextBox")
        Me.UserNameTextBox.Name = "UserNameTextBox"
        '
        'PasswordTextBox
        '
        resources.ApplyResources(Me.PasswordTextBox, "PasswordTextBox")
        Me.PasswordTextBox.Name = "PasswordTextBox"
        '
        'PasswordLabel
        '
        resources.ApplyResources(Me.PasswordLabel, "PasswordLabel")
        Me.PasswordLabel.Name = "PasswordLabel"
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.AcceptButton = Me.OKButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Controls.Add(Me.LoginLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LoginForm"
        Me.ShowInTaskbar = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LoginLabel As System.Windows.Forms.Label
    Friend WithEvents UserNameLabel As System.Windows.Forms.Label
    Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
End Class
