<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Widgets
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.EntityToolStrip = New System.Windows.Forms.ToolStrip
        Me.AddEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EditEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DeleteEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.InfoLabel = New System.Windows.Forms.Label
        Me.EntityToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.EntityMenuStrip = New ApplicationExplorer.MenuStripEx
        Me.EntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.EntityToolStrip.SuspendLayout()
        Me.EntityToolStripPanel.SuspendLayout()
        Me.EntityMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'EntityToolStrip
        '
        Me.EntityToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.EntityToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEntityToolStripButton, Me.EditEntityToolStripButton, Me.DeleteEntityToolStripButton})
        Me.EntityToolStrip.Location = New System.Drawing.Point(3, 0)
        Me.EntityToolStrip.Name = "EntityToolStrip"
        Me.EntityToolStrip.Size = New System.Drawing.Size(192, 25)
        Me.EntityToolStrip.TabIndex = 0
        Me.EntityToolStrip.Text = "ToolStrip1"
        '
        'AddEntityToolStripButton
        '
        Me.AddEntityToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_ADD2
        Me.AddEntityToolStripButton.ImageTransparentColor = System.Drawing.Color.Silver
        Me.AddEntityToolStripButton.Name = "AddEntityToolStripButton"
        Me.AddEntityToolStripButton.Size = New System.Drawing.Size(46, 22)
        Me.AddEntityToolStripButton.Text = "Add"
        Me.AddEntityToolStripButton.ToolTipText = "Add <Entity>"
        '
        'EditEntityToolStripButton
        '
        Me.EditEntityToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_EDIT2
        Me.EditEntityToolStripButton.ImageTransparentColor = System.Drawing.Color.Silver
        Me.EditEntityToolStripButton.Name = "EditEntityToolStripButton"
        Me.EditEntityToolStripButton.Size = New System.Drawing.Size(45, 22)
        Me.EditEntityToolStripButton.Text = "Edit"
        Me.EditEntityToolStripButton.ToolTipText = "Edit <Entity>"
        '
        'DeleteEntityToolStripButton
        '
        Me.DeleteEntityToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_DELETE2
        Me.DeleteEntityToolStripButton.ImageTransparentColor = System.Drawing.Color.Silver
        Me.DeleteEntityToolStripButton.Name = "DeleteEntityToolStripButton"
        Me.DeleteEntityToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.DeleteEntityToolStripButton.Text = "Delete"
        Me.DeleteEntityToolStripButton.ToolTipText = "Delete <Entity>"
        '
        'InfoLabel
        '
        Me.InfoLabel.BackColor = System.Drawing.SystemColors.Info
        Me.InfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.InfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.ForeColor = System.Drawing.SystemColors.InfoText
        Me.InfoLabel.Location = New System.Drawing.Point(256, 8)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(120, 88)
        Me.InfoLabel.TabIndex = 2
        Me.InfoLabel.Text = "Copy and paste these controls and components onto your child forms to use them."
        '
        'EntityToolStripPanel
        '
        Me.EntityToolStripPanel.Controls.Add(Me.EntityToolStrip)
        Me.EntityToolStripPanel.Location = New System.Drawing.Point(16, 96)
        Me.EntityToolStripPanel.Name = "EntityToolStripPanel"
        Me.EntityToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.EntityToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.EntityToolStripPanel.Size = New System.Drawing.Size(232, 25)
        '
        'EntityMenuStrip
        '
        Me.EntityMenuStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.EntityMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntityToolStripMenuItem})
        Me.EntityMenuStrip.Location = New System.Drawing.Point(16, 32)
        Me.EntityMenuStrip.Name = "EntityMenuStrip"
        Me.EntityMenuStrip.Size = New System.Drawing.Size(71, 24)
        Me.EntityMenuStrip.TabIndex = 3
        Me.EntityMenuStrip.Text = "MenuStrip1"
        '
        'EntityToolStripMenuItem
        '
        Me.EntityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEntityToolStripMenuItem, Me.EditEntityToolStripMenuItem, Me.DeleteEntityToolStripMenuItem})
        Me.EntityToolStripMenuItem.Name = "EntityToolStripMenuItem"
        Me.EntityToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.EntityToolStripMenuItem.Text = "<Entity>"
        '
        'AddEntityToolStripMenuItem
        '
        Me.AddEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_ADD
        Me.AddEntityToolStripMenuItem.Name = "AddEntityToolStripMenuItem"
        Me.AddEntityToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.AddEntityToolStripMenuItem.Text = "Add..."
        '
        'EditEntityToolStripMenuItem
        '
        Me.EditEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_EDIT
        Me.EditEntityToolStripMenuItem.Name = "EditEntityToolStripMenuItem"
        Me.EditEntityToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.EditEntityToolStripMenuItem.Text = "Edit"
        '
        'DeleteEntityToolStripMenuItem
        '
        Me.DeleteEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_DELETE
        Me.DeleteEntityToolStripMenuItem.Name = "DeleteEntityToolStripMenuItem"
        Me.DeleteEntityToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DeleteEntityToolStripMenuItem.Text = "Delete"
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Location = New System.Drawing.Point(16, 168)
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripPanel1.Size = New System.Drawing.Size(232, 23)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Entity MenuStrip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Entity ToolStripPanel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Blank ToolStrip"
        '
        'Widgets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.EntityToolStripPanel)
        Me.Controls.Add(Me.EntityMenuStrip)
        Me.Controls.Add(Me.InfoLabel)
        Me.Name = "Widgets"
        Me.Size = New System.Drawing.Size(383, 229)
        Me.EntityToolStrip.ResumeLayout(False)
        Me.EntityToolStrip.PerformLayout()
        Me.EntityToolStripPanel.ResumeLayout(False)
        Me.EntityToolStripPanel.PerformLayout()
        Me.EntityMenuStrip.ResumeLayout(False)
        Me.EntityMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EntityToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents EntityToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents EntityMenuStrip As ApplicationExplorer.MenuStripEx
    Friend WithEvents EntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
