<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.ApplicationIconPictureBox = New System.Windows.Forms.PictureBox
        Me.ApplicationTitleLabel = New System.Windows.Forms.Label
        Me.ApplicationVersionLabel = New System.Windows.Forms.Label
        Me.ApplicationCopyrightLabel = New System.Windows.Forms.Label
        Me.MoreInfoLabel = New System.Windows.Forms.Label
        Me.OkButton = New System.Windows.Forms.Button
        Me.SystemInfoButton = New System.Windows.Forms.Button
        Me.HeaderPanel = New System.Windows.Forms.Panel
        Me.CompanyNameLabel = New System.Windows.Forms.LinkLabel
        Me.ApplicationDetailsTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AppExploreInfoLinkLabel = New System.Windows.Forms.LinkLabel
        CType(Me.ApplicationIconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ApplicationIconPictureBox
        '
        resources.ApplyResources(Me.ApplicationIconPictureBox, "ApplicationIconPictureBox")
        Me.ApplicationIconPictureBox.Name = "ApplicationIconPictureBox"
        Me.ApplicationIconPictureBox.TabStop = False
        '
        'ApplicationTitleLabel
        '
        resources.ApplyResources(Me.ApplicationTitleLabel, "ApplicationTitleLabel")
        Me.ApplicationTitleLabel.Name = "ApplicationTitleLabel"
        Me.ApplicationTitleLabel.UseMnemonic = False
        '
        'ApplicationVersionLabel
        '
        resources.ApplyResources(Me.ApplicationVersionLabel, "ApplicationVersionLabel")
        Me.ApplicationVersionLabel.Name = "ApplicationVersionLabel"
        Me.ApplicationVersionLabel.UseMnemonic = False
        '
        'ApplicationCopyrightLabel
        '
        resources.ApplyResources(Me.ApplicationCopyrightLabel, "ApplicationCopyrightLabel")
        Me.ApplicationCopyrightLabel.Name = "ApplicationCopyrightLabel"
        Me.ApplicationCopyrightLabel.UseMnemonic = False
        '
        'MoreInfoLabel
        '
        resources.ApplyResources(Me.MoreInfoLabel, "MoreInfoLabel")
        Me.MoreInfoLabel.Name = "MoreInfoLabel"
        Me.MoreInfoLabel.UseMnemonic = False
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.OkButton, "OkButton")
        Me.OkButton.Name = "OkButton"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'SystemInfoButton
        '
        resources.ApplyResources(Me.SystemInfoButton, "SystemInfoButton")
        Me.SystemInfoButton.Name = "SystemInfoButton"
        Me.SystemInfoButton.UseVisualStyleBackColor = True
        '
        'HeaderPanel
        '
        Me.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.HeaderPanel.Controls.Add(Me.CompanyNameLabel)
        resources.ApplyResources(Me.HeaderPanel, "HeaderPanel")
        Me.HeaderPanel.Name = "HeaderPanel"
        '
        'CompanyNameLabel
        '
        resources.ApplyResources(Me.CompanyNameLabel, "CompanyNameLabel")
        Me.CompanyNameLabel.DisabledLinkColor = System.Drawing.Color.Black
        Me.CompanyNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.CompanyNameLabel.LinkColor = System.Drawing.Color.Black
        Me.CompanyNameLabel.Name = "CompanyNameLabel"
        Me.CompanyNameLabel.TabStop = True
        Me.CompanyNameLabel.UseMnemonic = False
        '
        'ApplicationDetailsTextBox
        '
        resources.ApplyResources(Me.ApplicationDetailsTextBox, "ApplicationDetailsTextBox")
        Me.ApplicationDetailsTextBox.Name = "ApplicationDetailsTextBox"
        Me.ApplicationDetailsTextBox.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.Label1.UseMnemonic = False
        '
        'AppExploreInfoLinkLabel
        '
        resources.ApplyResources(Me.AppExploreInfoLinkLabel, "AppExploreInfoLinkLabel")
        Me.AppExploreInfoLinkLabel.Name = "AppExploreInfoLinkLabel"
        Me.AppExploreInfoLinkLabel.TabStop = True
        '
        'AboutForm
        '
        Me.AcceptButton = Me.OkButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OkButton
        Me.Controls.Add(Me.AppExploreInfoLinkLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ApplicationDetailsTextBox)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.SystemInfoButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.MoreInfoLabel)
        Me.Controls.Add(Me.ApplicationCopyrightLabel)
        Me.Controls.Add(Me.ApplicationVersionLabel)
        Me.Controls.Add(Me.ApplicationTitleLabel)
        Me.Controls.Add(Me.ApplicationIconPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.ShowInTaskbar = False
        CType(Me.ApplicationIconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel.ResumeLayout(False)
        Me.HeaderPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApplicationIconPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ApplicationTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ApplicationVersionLabel As System.Windows.Forms.Label
    Friend WithEvents ApplicationCopyrightLabel As System.Windows.Forms.Label
    Friend WithEvents MoreInfoLabel As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents SystemInfoButton As System.Windows.Forms.Button
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents CompanyNameLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ApplicationDetailsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AppExploreInfoLinkLabel As System.Windows.Forms.LinkLabel
End Class
