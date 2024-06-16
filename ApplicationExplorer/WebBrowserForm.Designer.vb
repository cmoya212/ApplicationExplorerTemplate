<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebBrowserForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebBrowserForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.AddressToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
        Me.GoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.MainPanel = New System.Windows.Forms.Panel
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.EnhancedWebBrowser1 = New EnhancedWebBrowser.EnhancedWebBrowser
        Me.ToolStrip1.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddressToolStripComboBox, Me.GoToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(279, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'AddressToolStripComboBox
        '
        Me.AddressToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.AddressToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AddressToolStripComboBox.Name = "AddressToolStripComboBox"
        Me.AddressToolStripComboBox.Size = New System.Drawing.Size(225, 25)
        Me.AddressToolStripComboBox.ToolTipText = "Address"
        '
        'GoToolStripButton
        '
        Me.GoToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.GoLtr
        Me.GoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GoToolStripButton.Name = "GoToolStripButton"
        Me.GoToolStripButton.Size = New System.Drawing.Size(40, 22)
        Me.GoToolStripButton.Text = "Go"
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.EnhancedWebBrowser1)
        Me.MainPanel.Controls.Add(Me.ToolStripPanel1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(379, 265)
        Me.MainPanel.TabIndex = 2
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.ToolStrip1)
        Me.ToolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolStripPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(377, 25)
        '
        'EnhancedWebBrowser1
        '
        Me.EnhancedWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EnhancedWebBrowser1.Location = New System.Drawing.Point(0, 25)
        Me.EnhancedWebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.EnhancedWebBrowser1.Name = "EnhancedWebBrowser1"
        Me.EnhancedWebBrowser1.RegisterAsBrowser = False
        Me.EnhancedWebBrowser1.Size = New System.Drawing.Size(377, 238)
        Me.EnhancedWebBrowser1.TabIndex = 2
        '
        'WebBrowserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 265)
        Me.Controls.Add(Me.MainPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WebBrowserForm"
        Me.Text = "Web"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents AddressToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents GoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents EnhancedWebBrowser1 As EnhancedWebBrowser.EnhancedWebBrowser
End Class
