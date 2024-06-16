<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleForm_PictureBrowser
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
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image 1", 1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image 2", 0)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image 3", 3)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Image 4", 2)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleForm_PictureBrowser))
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.EntityToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.EntityToolStrip = New System.Windows.Forms.ToolStrip
        Me.AddEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EditEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.DeleteEntityToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EntityMenuStrip = New ApplicationExplorer.MenuStripEx
        Me.EntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteEntityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SomeOtherOption1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SomeOtherOption2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EntityToolStripPanel.SuspendLayout()
        Me.EntityToolStrip.SuspendLayout()
        Me.EntityMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8})
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(0, 49)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(240, 219)
        Me.ListView1.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ListView1, "Double-click to open an image")
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "BEANY.BMP")
        Me.ImageList1.Images.SetKeyName(1, "NOTEBOOK.BMP")
        Me.ImageList1.Images.SetKeyName(2, "SPEAKER.BMP")
        Me.ImageList1.Images.SetKeyName(3, "CIRCLOCK.BMP")
        '
        'EntityToolStripPanel
        '
        Me.EntityToolStripPanel.Controls.Add(Me.EntityToolStrip)
        Me.EntityToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.EntityToolStripPanel.Location = New System.Drawing.Point(0, 24)
        Me.EntityToolStripPanel.Name = "EntityToolStripPanel"
        Me.EntityToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.EntityToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.EntityToolStripPanel.Size = New System.Drawing.Size(240, 25)
        '
        'EntityToolStrip
        '
        Me.EntityToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.EntityToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEntityToolStripButton, Me.EditEntityToolStripButton, Me.DeleteEntityToolStripButton})
        Me.EntityToolStrip.Location = New System.Drawing.Point(3, 0)
        Me.EntityToolStrip.Name = "EntityToolStrip"
        Me.EntityToolStrip.Size = New System.Drawing.Size(161, 25)
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
        Me.AddEntityToolStripButton.ToolTipText = "Add Image"
        '
        'EditEntityToolStripButton
        '
        Me.EditEntityToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_EDIT2
        Me.EditEntityToolStripButton.ImageTransparentColor = System.Drawing.Color.Silver
        Me.EditEntityToolStripButton.Name = "EditEntityToolStripButton"
        Me.EditEntityToolStripButton.Size = New System.Drawing.Size(45, 22)
        Me.EditEntityToolStripButton.Text = "Edit"
        Me.EditEntityToolStripButton.ToolTipText = "Edit Image"
        '
        'DeleteEntityToolStripButton
        '
        Me.DeleteEntityToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_DELETE2
        Me.DeleteEntityToolStripButton.ImageTransparentColor = System.Drawing.Color.Silver
        Me.DeleteEntityToolStripButton.Name = "DeleteEntityToolStripButton"
        Me.DeleteEntityToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.DeleteEntityToolStripButton.Text = "Delete"
        Me.DeleteEntityToolStripButton.ToolTipText = "Delete Image"
        '
        'EntityMenuStrip
        '
        Me.EntityMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EntityToolStripMenuItem})
        Me.EntityMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.EntityMenuStrip.Name = "EntityMenuStrip"
        Me.EntityMenuStrip.Size = New System.Drawing.Size(240, 24)
        Me.EntityMenuStrip.TabIndex = 4
        Me.EntityMenuStrip.Text = "MenuStrip1"
        '
        'EntityToolStripMenuItem
        '
        Me.EntityToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEntityToolStripMenuItem, Me.EditEntityToolStripMenuItem, Me.DeleteEntityToolStripMenuItem, Me.SomeOtherOption1ToolStripMenuItem, Me.SomeOtherOption2ToolStripMenuItem})
        Me.EntityToolStripMenuItem.Name = "EntityToolStripMenuItem"
        Me.EntityToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EntityToolStripMenuItem.Text = "Image"
        '
        'AddEntityToolStripMenuItem
        '
        Me.AddEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_ADD
        Me.AddEntityToolStripMenuItem.Name = "AddEntityToolStripMenuItem"
        Me.AddEntityToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AddEntityToolStripMenuItem.Text = "Add..."
        '
        'EditEntityToolStripMenuItem
        '
        Me.EditEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_EDIT
        Me.EditEntityToolStripMenuItem.Name = "EditEntityToolStripMenuItem"
        Me.EditEntityToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.EditEntityToolStripMenuItem.Text = "Edit"
        '
        'DeleteEntityToolStripMenuItem
        '
        Me.DeleteEntityToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.ITEM_DELETE
        Me.DeleteEntityToolStripMenuItem.Name = "DeleteEntityToolStripMenuItem"
        Me.DeleteEntityToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.DeleteEntityToolStripMenuItem.Text = "Delete"
        '
        'SomeOtherOption1ToolStripMenuItem
        '
        Me.SomeOtherOption1ToolStripMenuItem.Name = "SomeOtherOption1ToolStripMenuItem"
        Me.SomeOtherOption1ToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SomeOtherOption1ToolStripMenuItem.Text = "Some other option 1"
        '
        'SomeOtherOption2ToolStripMenuItem
        '
        Me.SomeOtherOption2ToolStripMenuItem.Name = "SomeOtherOption2ToolStripMenuItem"
        Me.SomeOtherOption2ToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SomeOtherOption2ToolStripMenuItem.Text = "Some other option 2"
        '
        'SampleForm_PictureBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.EntityToolStripPanel)
        Me.Controls.Add(Me.EntityMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SampleForm_PictureBrowser"
        Me.Text = "Pictures"
        Me.EntityToolStripPanel.ResumeLayout(False)
        Me.EntityToolStripPanel.PerformLayout()
        Me.EntityToolStrip.ResumeLayout(False)
        Me.EntityToolStrip.PerformLayout()
        Me.EntityMenuStrip.ResumeLayout(False)
        Me.EntityMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents EntityMenuStrip As ApplicationExplorer.MenuStripEx
    Friend WithEvents EntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteEntityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntityToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents EntityToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteEntityToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SomeOtherOption1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SomeOtherOption2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
