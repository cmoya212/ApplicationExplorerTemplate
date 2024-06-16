<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashForm))
        Me.MainPanel = New System.Windows.Forms.Panel
        Me.MoreInfoLabel = New System.Windows.Forms.Label
        Me.ApplicationVersionLabel = New System.Windows.Forms.Label
        Me.ApplicationLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.ApplicationTitleLabel = New System.Windows.Forms.Label
        Me.MainPanel.SuspendLayout()
        CType(Me.ApplicationLogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.MoreInfoLabel)
        Me.MainPanel.Controls.Add(Me.ApplicationVersionLabel)
        Me.MainPanel.Controls.Add(Me.ApplicationLogoPictureBox)
        Me.MainPanel.Controls.Add(Me.ApplicationTitleLabel)
        resources.ApplyResources(Me.MainPanel, "MainPanel")
        Me.MainPanel.Name = "MainPanel"
        '
        'MoreInfoLabel
        '
        resources.ApplyResources(Me.MoreInfoLabel, "MoreInfoLabel")
        Me.MoreInfoLabel.Name = "MoreInfoLabel"
        '
        'ApplicationVersionLabel
        '
        resources.ApplyResources(Me.ApplicationVersionLabel, "ApplicationVersionLabel")
        Me.ApplicationVersionLabel.Name = "ApplicationVersionLabel"
        '
        'ApplicationLogoPictureBox
        '
        resources.ApplyResources(Me.ApplicationLogoPictureBox, "ApplicationLogoPictureBox")
        Me.ApplicationLogoPictureBox.Name = "ApplicationLogoPictureBox"
        Me.ApplicationLogoPictureBox.TabStop = False
        '
        'ApplicationTitleLabel
        '
        resources.ApplyResources(Me.ApplicationTitleLabel, "ApplicationTitleLabel")
        Me.ApplicationTitleLabel.Name = "ApplicationTitleLabel"
        '
        'SplashForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MainPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SplashForm"
        Me.ShowInTaskbar = False
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        CType(Me.ApplicationLogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents ApplicationTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ApplicationLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ApplicationVersionLabel As System.Windows.Forms.Label
    Friend WithEvents MoreInfoLabel As System.Windows.Forms.Label
End Class
