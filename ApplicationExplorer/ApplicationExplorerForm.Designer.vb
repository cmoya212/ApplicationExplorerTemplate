<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApplicationExplorerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            RemoveMergedTools()
            components.Dispose()
            m_findForm.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationExplorerForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileSaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileMRUSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.FileMRUSep2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.FileExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditSepToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.EditCutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditPasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditSepToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.EditFindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditFindNextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewSepToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowStatusBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowShortcutBarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewSepToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ViewGotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewGotoBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewGotoForwardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewStopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewRefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolsOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClassicWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClassicWindowCascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClassicWindowTileHorizontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClassicWindowTileVerticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowHTileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowTileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowPopOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowSepToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.WindowOrientationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowOrientationRightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowOrientationBottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowCloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowSepToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.WindowMoreWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpTopicsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpSepToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpAboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileOperationsToolStrip = New System.Windows.Forms.ToolStrip
        Me.FileNewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.FileOpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.FileSaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NavigationToolStrip = New System.Windows.Forms.ToolStrip
        Me.NavBackToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NavForwardToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NavCancelToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NavRefreshToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ShortcutBarSideMenu = New SideMenu.SideMenu
        Me.ShortcutBarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.HeaderPanel = New System.Windows.Forms.Panel
        Me.HeaderTitleLabel = New System.Windows.Forms.Label
        Me.ShortcutBarSplitter = New System.Windows.Forms.Splitter
        Me.ToolStripPanel1 = New System.Windows.Forms.ToolStripPanel
        Me.WindowManagerPanel1 = New MDIWindowManager.WindowManagerPanel
        Me.MenuStrip1.SuspendLayout()
        Me.FileOperationsToolStrip.SuspendLayout()
        Me.NavigationToolStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.HeaderPanel.SuspendLayout()
        Me.ToolStripPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ClassicWindowToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.MdiWindowListItem = Me.ClassicWindowToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNewToolStripMenuItem, Me.FileOpenToolStripMenuItem, Me.FileSaveToolStripMenuItem, Me.FileSaveAsToolStripMenuItem, Me.FileCloseToolStripMenuItem, Me.FileMRUSep1ToolStripMenuItem, Me.FileMRUSep2ToolStripMenuItem, Me.FileExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'FileNewToolStripMenuItem
        '
        Me.FileNewToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.DocumentHS
        Me.FileNewToolStripMenuItem.Name = "FileNewToolStripMenuItem"
        resources.ApplyResources(Me.FileNewToolStripMenuItem, "FileNewToolStripMenuItem")
        '
        'FileOpenToolStripMenuItem
        '
        Me.FileOpenToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.openHS
        Me.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem"
        resources.ApplyResources(Me.FileOpenToolStripMenuItem, "FileOpenToolStripMenuItem")
        '
        'FileSaveToolStripMenuItem
        '
        Me.FileSaveToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.saveHS
        Me.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem"
        resources.ApplyResources(Me.FileSaveToolStripMenuItem, "FileSaveToolStripMenuItem")
        '
        'FileSaveAsToolStripMenuItem
        '
        Me.FileSaveAsToolStripMenuItem.Name = "FileSaveAsToolStripMenuItem"
        resources.ApplyResources(Me.FileSaveAsToolStripMenuItem, "FileSaveAsToolStripMenuItem")
        '
        'FileCloseToolStripMenuItem
        '
        Me.FileCloseToolStripMenuItem.Name = "FileCloseToolStripMenuItem"
        resources.ApplyResources(Me.FileCloseToolStripMenuItem, "FileCloseToolStripMenuItem")
        '
        'FileMRUSep1ToolStripMenuItem
        '
        Me.FileMRUSep1ToolStripMenuItem.Name = "FileMRUSep1ToolStripMenuItem"
        resources.ApplyResources(Me.FileMRUSep1ToolStripMenuItem, "FileMRUSep1ToolStripMenuItem")
        '
        'FileMRUSep2ToolStripMenuItem
        '
        Me.FileMRUSep2ToolStripMenuItem.Name = "FileMRUSep2ToolStripMenuItem"
        resources.ApplyResources(Me.FileMRUSep2ToolStripMenuItem, "FileMRUSep2ToolStripMenuItem")
        '
        'FileExitToolStripMenuItem
        '
        Me.FileExitToolStripMenuItem.Name = "FileExitToolStripMenuItem"
        resources.ApplyResources(Me.FileExitToolStripMenuItem, "FileExitToolStripMenuItem")
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndoToolStripMenuItem, Me.EditSepToolStripMenuItem1, Me.EditCutToolStripMenuItem, Me.EditCopyToolStripMenuItem, Me.EditPasteToolStripMenuItem, Me.EditSepToolStripMenuItem2, Me.EditFindToolStripMenuItem, Me.EditFindNextToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        '
        'EditUndoToolStripMenuItem
        '
        Me.EditUndoToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.Edit_UndoHS
        Me.EditUndoToolStripMenuItem.Name = "EditUndoToolStripMenuItem"
        resources.ApplyResources(Me.EditUndoToolStripMenuItem, "EditUndoToolStripMenuItem")
        '
        'EditSepToolStripMenuItem1
        '
        Me.EditSepToolStripMenuItem1.Name = "EditSepToolStripMenuItem1"
        resources.ApplyResources(Me.EditSepToolStripMenuItem1, "EditSepToolStripMenuItem1")
        '
        'EditCutToolStripMenuItem
        '
        Me.EditCutToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.CutHS
        Me.EditCutToolStripMenuItem.Name = "EditCutToolStripMenuItem"
        resources.ApplyResources(Me.EditCutToolStripMenuItem, "EditCutToolStripMenuItem")
        '
        'EditCopyToolStripMenuItem
        '
        Me.EditCopyToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.CopyHS
        Me.EditCopyToolStripMenuItem.Name = "EditCopyToolStripMenuItem"
        resources.ApplyResources(Me.EditCopyToolStripMenuItem, "EditCopyToolStripMenuItem")
        '
        'EditPasteToolStripMenuItem
        '
        Me.EditPasteToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.PasteHS
        Me.EditPasteToolStripMenuItem.Name = "EditPasteToolStripMenuItem"
        resources.ApplyResources(Me.EditPasteToolStripMenuItem, "EditPasteToolStripMenuItem")
        '
        'EditSepToolStripMenuItem2
        '
        Me.EditSepToolStripMenuItem2.Name = "EditSepToolStripMenuItem2"
        resources.ApplyResources(Me.EditSepToolStripMenuItem2, "EditSepToolStripMenuItem2")
        '
        'EditFindToolStripMenuItem
        '
        Me.EditFindToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.FindHS
        Me.EditFindToolStripMenuItem.Name = "EditFindToolStripMenuItem"
        resources.ApplyResources(Me.EditFindToolStripMenuItem, "EditFindToolStripMenuItem")
        '
        'EditFindNextToolStripMenuItem
        '
        Me.EditFindNextToolStripMenuItem.Name = "EditFindNextToolStripMenuItem"
        resources.ApplyResources(Me.EditFindNextToolStripMenuItem, "EditFindNextToolStripMenuItem")
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewSepToolStripMenuItem1, Me.ShowToolbarToolStripMenuItem, Me.ShowStatusBarToolStripMenuItem, Me.ShowShortcutBarToolStripMenuItem, Me.ViewSepToolStripMenuItem2, Me.ViewGotoToolStripMenuItem, Me.ViewStopToolStripMenuItem, Me.ViewRefreshToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        resources.ApplyResources(Me.ViewToolStripMenuItem, "ViewToolStripMenuItem")
        '
        'ViewSepToolStripMenuItem1
        '
        Me.ViewSepToolStripMenuItem1.Name = "ViewSepToolStripMenuItem1"
        resources.ApplyResources(Me.ViewSepToolStripMenuItem1, "ViewSepToolStripMenuItem1")
        '
        'ShowToolbarToolStripMenuItem
        '
        Me.ShowToolbarToolStripMenuItem.Name = "ShowToolbarToolStripMenuItem"
        resources.ApplyResources(Me.ShowToolbarToolStripMenuItem, "ShowToolbarToolStripMenuItem")
        '
        'ShowStatusBarToolStripMenuItem
        '
        Me.ShowStatusBarToolStripMenuItem.Name = "ShowStatusBarToolStripMenuItem"
        resources.ApplyResources(Me.ShowStatusBarToolStripMenuItem, "ShowStatusBarToolStripMenuItem")
        '
        'ShowShortcutBarToolStripMenuItem
        '
        Me.ShowShortcutBarToolStripMenuItem.Name = "ShowShortcutBarToolStripMenuItem"
        resources.ApplyResources(Me.ShowShortcutBarToolStripMenuItem, "ShowShortcutBarToolStripMenuItem")
        '
        'ViewSepToolStripMenuItem2
        '
        Me.ViewSepToolStripMenuItem2.Name = "ViewSepToolStripMenuItem2"
        resources.ApplyResources(Me.ViewSepToolStripMenuItem2, "ViewSepToolStripMenuItem2")
        '
        'ViewGotoToolStripMenuItem
        '
        Me.ViewGotoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewGotoBackToolStripMenuItem, Me.ViewGotoForwardToolStripMenuItem})
        Me.ViewGotoToolStripMenuItem.Name = "ViewGotoToolStripMenuItem"
        resources.ApplyResources(Me.ViewGotoToolStripMenuItem, "ViewGotoToolStripMenuItem")
        '
        'ViewGotoBackToolStripMenuItem
        '
        resources.ApplyResources(Me.ViewGotoBackToolStripMenuItem, "ViewGotoBackToolStripMenuItem")
        Me.ViewGotoBackToolStripMenuItem.Name = "ViewGotoBackToolStripMenuItem"
        '
        'ViewGotoForwardToolStripMenuItem
        '
        resources.ApplyResources(Me.ViewGotoForwardToolStripMenuItem, "ViewGotoForwardToolStripMenuItem")
        Me.ViewGotoForwardToolStripMenuItem.Name = "ViewGotoForwardToolStripMenuItem"
        '
        'ViewStopToolStripMenuItem
        '
        Me.ViewStopToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.Refresh_Cancel
        resources.ApplyResources(Me.ViewStopToolStripMenuItem, "ViewStopToolStripMenuItem")
        Me.ViewStopToolStripMenuItem.Name = "ViewStopToolStripMenuItem"
        '
        'ViewRefreshToolStripMenuItem
        '
        Me.ViewRefreshToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.RefreshDocView
        resources.ApplyResources(Me.ViewRefreshToolStripMenuItem, "ViewRefreshToolStripMenuItem")
        Me.ViewRefreshToolStripMenuItem.Name = "ViewRefreshToolStripMenuItem"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolsOptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        resources.ApplyResources(Me.ToolsToolStripMenuItem, "ToolsToolStripMenuItem")
        '
        'ToolsOptionsToolStripMenuItem
        '
        Me.ToolsOptionsToolStripMenuItem.Name = "ToolsOptionsToolStripMenuItem"
        resources.ApplyResources(Me.ToolsOptionsToolStripMenuItem, "ToolsOptionsToolStripMenuItem")
        '
        'ClassicWindowToolStripMenuItem
        '
        Me.ClassicWindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassicWindowCascadeToolStripMenuItem, Me.ClassicWindowTileHorizontToolStripMenuItem, Me.ClassicWindowTileVerticallyToolStripMenuItem})
        Me.ClassicWindowToolStripMenuItem.Name = "ClassicWindowToolStripMenuItem"
        resources.ApplyResources(Me.ClassicWindowToolStripMenuItem, "ClassicWindowToolStripMenuItem")
        '
        'ClassicWindowCascadeToolStripMenuItem
        '
        Me.ClassicWindowCascadeToolStripMenuItem.Name = "ClassicWindowCascadeToolStripMenuItem"
        resources.ApplyResources(Me.ClassicWindowCascadeToolStripMenuItem, "ClassicWindowCascadeToolStripMenuItem")
        '
        'ClassicWindowTileHorizontToolStripMenuItem
        '
        Me.ClassicWindowTileHorizontToolStripMenuItem.Name = "ClassicWindowTileHorizontToolStripMenuItem"
        resources.ApplyResources(Me.ClassicWindowTileHorizontToolStripMenuItem, "ClassicWindowTileHorizontToolStripMenuItem")
        '
        'ClassicWindowTileVerticallyToolStripMenuItem
        '
        Me.ClassicWindowTileVerticallyToolStripMenuItem.Name = "ClassicWindowTileVerticallyToolStripMenuItem"
        resources.ApplyResources(Me.ClassicWindowTileVerticallyToolStripMenuItem, "ClassicWindowTileVerticallyToolStripMenuItem")
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowHTileToolStripMenuItem, Me.WindowTileToolStripMenuItem, Me.WindowPopOutToolStripMenuItem, Me.WindowSepToolStripMenuItem1, Me.WindowOrientationToolStripMenuItem, Me.WindowCloseAllToolStripMenuItem, Me.WindowSepToolStripMenuItem2, Me.WindowMoreWindowsToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        resources.ApplyResources(Me.WindowToolStripMenuItem, "WindowToolStripMenuItem")
        '
        'WindowHTileToolStripMenuItem
        '
        Me.WindowHTileToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.window_htile_glyph
        resources.ApplyResources(Me.WindowHTileToolStripMenuItem, "WindowHTileToolStripMenuItem")
        Me.WindowHTileToolStripMenuItem.Name = "WindowHTileToolStripMenuItem"
        '
        'WindowTileToolStripMenuItem
        '
        Me.WindowTileToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.window_tile_glyph
        resources.ApplyResources(Me.WindowTileToolStripMenuItem, "WindowTileToolStripMenuItem")
        Me.WindowTileToolStripMenuItem.Name = "WindowTileToolStripMenuItem"
        '
        'WindowPopOutToolStripMenuItem
        '
        Me.WindowPopOutToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.window_popout_glyph
        resources.ApplyResources(Me.WindowPopOutToolStripMenuItem, "WindowPopOutToolStripMenuItem")
        Me.WindowPopOutToolStripMenuItem.Name = "WindowPopOutToolStripMenuItem"
        '
        'WindowSepToolStripMenuItem1
        '
        Me.WindowSepToolStripMenuItem1.Name = "WindowSepToolStripMenuItem1"
        resources.ApplyResources(Me.WindowSepToolStripMenuItem1, "WindowSepToolStripMenuItem1")
        '
        'WindowOrientationToolStripMenuItem
        '
        Me.WindowOrientationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowOrientationRightToolStripMenuItem, Me.WindowOrientationBottomToolStripMenuItem})
        Me.WindowOrientationToolStripMenuItem.Name = "WindowOrientationToolStripMenuItem"
        resources.ApplyResources(Me.WindowOrientationToolStripMenuItem, "WindowOrientationToolStripMenuItem")
        '
        'WindowOrientationRightToolStripMenuItem
        '
        Me.WindowOrientationRightToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.FillRight
        resources.ApplyResources(Me.WindowOrientationRightToolStripMenuItem, "WindowOrientationRightToolStripMenuItem")
        Me.WindowOrientationRightToolStripMenuItem.Name = "WindowOrientationRightToolStripMenuItem"
        '
        'WindowOrientationBottomToolStripMenuItem
        '
        Me.WindowOrientationBottomToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.FillDown
        resources.ApplyResources(Me.WindowOrientationBottomToolStripMenuItem, "WindowOrientationBottomToolStripMenuItem")
        Me.WindowOrientationBottomToolStripMenuItem.Name = "WindowOrientationBottomToolStripMenuItem"
        '
        'WindowCloseAllToolStripMenuItem
        '
        Me.WindowCloseAllToolStripMenuItem.Name = "WindowCloseAllToolStripMenuItem"
        resources.ApplyResources(Me.WindowCloseAllToolStripMenuItem, "WindowCloseAllToolStripMenuItem")
        '
        'WindowSepToolStripMenuItem2
        '
        Me.WindowSepToolStripMenuItem2.Name = "WindowSepToolStripMenuItem2"
        resources.ApplyResources(Me.WindowSepToolStripMenuItem2, "WindowSepToolStripMenuItem2")
        '
        'WindowMoreWindowsToolStripMenuItem
        '
        Me.WindowMoreWindowsToolStripMenuItem.Name = "WindowMoreWindowsToolStripMenuItem"
        resources.ApplyResources(Me.WindowMoreWindowsToolStripMenuItem, "WindowMoreWindowsToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpTopicsToolStripMenuItem, Me.HelpSepToolStripMenuItem1, Me.HelpAboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'HelpTopicsToolStripMenuItem
        '
        Me.HelpTopicsToolStripMenuItem.Image = Global.ApplicationExplorer.My.Resources.Resources.Help
        resources.ApplyResources(Me.HelpTopicsToolStripMenuItem, "HelpTopicsToolStripMenuItem")
        Me.HelpTopicsToolStripMenuItem.Name = "HelpTopicsToolStripMenuItem"
        '
        'HelpSepToolStripMenuItem1
        '
        Me.HelpSepToolStripMenuItem1.Name = "HelpSepToolStripMenuItem1"
        resources.ApplyResources(Me.HelpSepToolStripMenuItem1, "HelpSepToolStripMenuItem1")
        '
        'HelpAboutToolStripMenuItem
        '
        Me.HelpAboutToolStripMenuItem.Name = "HelpAboutToolStripMenuItem"
        resources.ApplyResources(Me.HelpAboutToolStripMenuItem, "HelpAboutToolStripMenuItem")
        '
        'FileOperationsToolStrip
        '
        resources.ApplyResources(Me.FileOperationsToolStrip, "FileOperationsToolStrip")
        Me.FileOperationsToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNewToolStripButton, Me.FileOpenToolStripButton, Me.FileSaveToolStripButton})
        Me.FileOperationsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.FileOperationsToolStrip.Name = "FileOperationsToolStrip"
        '
        'FileNewToolStripButton
        '
        Me.FileNewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FileNewToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.DocumentHS
        resources.ApplyResources(Me.FileNewToolStripButton, "FileNewToolStripButton")
        Me.FileNewToolStripButton.Name = "FileNewToolStripButton"
        '
        'FileOpenToolStripButton
        '
        Me.FileOpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FileOpenToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.openHS
        resources.ApplyResources(Me.FileOpenToolStripButton, "FileOpenToolStripButton")
        Me.FileOpenToolStripButton.Name = "FileOpenToolStripButton"
        '
        'FileSaveToolStripButton
        '
        Me.FileSaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FileSaveToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.saveHS
        resources.ApplyResources(Me.FileSaveToolStripButton, "FileSaveToolStripButton")
        Me.FileSaveToolStripButton.Name = "FileSaveToolStripButton"
        '
        'NavigationToolStrip
        '
        resources.ApplyResources(Me.NavigationToolStrip, "NavigationToolStrip")
        Me.NavigationToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NavBackToolStripButton, Me.NavForwardToolStripButton, Me.NavCancelToolStripButton, Me.NavRefreshToolStripButton})
        Me.NavigationToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.NavigationToolStrip.Name = "NavigationToolStrip"
        '
        'NavBackToolStripButton
        '
        resources.ApplyResources(Me.NavBackToolStripButton, "NavBackToolStripButton")
        Me.NavBackToolStripButton.Name = "NavBackToolStripButton"
        '
        'NavForwardToolStripButton
        '
        Me.NavForwardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.NavForwardToolStripButton, "NavForwardToolStripButton")
        Me.NavForwardToolStripButton.Name = "NavForwardToolStripButton"
        '
        'NavCancelToolStripButton
        '
        Me.NavCancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NavCancelToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.Refresh_Cancel
        resources.ApplyResources(Me.NavCancelToolStripButton, "NavCancelToolStripButton")
        Me.NavCancelToolStripButton.Name = "NavCancelToolStripButton"
        '
        'NavRefreshToolStripButton
        '
        Me.NavRefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NavRefreshToolStripButton.Image = Global.ApplicationExplorer.My.Resources.Resources.RefreshDocView
        resources.ApplyResources(Me.NavRefreshToolStripButton, "NavRefreshToolStripButton")
        Me.NavRefreshToolStripButton.Name = "NavRefreshToolStripButton"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.Spring = True
        '
        'ToolStripProgressBar1
        '
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        Me.ToolStripProgressBar1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 3)
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        '
        'ShortcutBarSideMenu
        '
        Me.ShortcutBarSideMenu.AllowReselection = False
        resources.ApplyResources(Me.ShortcutBarSideMenu, "ShortcutBarSideMenu")
        Me.ShortcutBarSideMenu.ImageList = Me.ShortcutBarImageList
        Me.ShortcutBarSideMenu.ImageSize = New System.Drawing.Size(16, 16)
        Me.ShortcutBarSideMenu.ItemBackColor1 = System.Drawing.SystemColors.Control
        Me.ShortcutBarSideMenu.ItemBackColor2 = System.Drawing.SystemColors.ControlDark
        Me.ShortcutBarSideMenu.ItemBorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ShortcutBarSideMenu.ItemForeColor = System.Drawing.SystemColors.ControlText
        Me.ShortcutBarSideMenu.ItemHeight = 30
        Me.ShortcutBarSideMenu.ItemLeftSpacing = 7
        Me.ShortcutBarSideMenu.ItemSpacing = 2
        Me.ShortcutBarSideMenu.Name = "ShortcutBarSideMenu"
        Me.ShortcutBarSideMenu.RepeatScrollSpeed = 250
        Me.ShortcutBarSideMenu.SelectedItemBackColor = System.Drawing.SystemColors.Control
        Me.ShortcutBarSideMenu.SelectedItemForeColor = System.Drawing.SystemColors.ControlText
        Me.ShortcutBarSideMenu.Style = SideMenu.SideMenu.SideMenuStyle.Professional
        Me.ShortcutBarSideMenu.TopSpacing = 2
        '
        'ShortcutBarImageList
        '
        Me.ShortcutBarImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        resources.ApplyResources(Me.ShortcutBarImageList, "ShortcutBarImageList")
        Me.ShortcutBarImageList.TransparentColor = System.Drawing.Color.Magenta
        '
        'HeaderPanel
        '
        Me.HeaderPanel.Controls.Add(Me.HeaderTitleLabel)
        resources.ApplyResources(Me.HeaderPanel, "HeaderPanel")
        Me.HeaderPanel.Name = "HeaderPanel"
        '
        'HeaderTitleLabel
        '
        resources.ApplyResources(Me.HeaderTitleLabel, "HeaderTitleLabel")
        Me.HeaderTitleLabel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.HeaderTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.HeaderTitleLabel.Name = "HeaderTitleLabel"
        '
        'ShortcutBarSplitter
        '
        resources.ApplyResources(Me.ShortcutBarSplitter, "ShortcutBarSplitter")
        Me.ShortcutBarSplitter.Name = "ShortcutBarSplitter"
        Me.ShortcutBarSplitter.TabStop = False
        '
        'ToolStripPanel1
        '
        Me.ToolStripPanel1.Controls.Add(Me.FileOperationsToolStrip)
        Me.ToolStripPanel1.Controls.Add(Me.NavigationToolStrip)
        resources.ApplyResources(Me.ToolStripPanel1, "ToolStripPanel1")
        Me.ToolStripPanel1.Name = "ToolStripPanel1"
        Me.ToolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.ToolStripPanel1.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        '
        'WindowManagerPanel1
        '
        Me.WindowManagerPanel1.AllowUserVerticalRepositioning = False
        Me.WindowManagerPanel1.AutoDetectMdiChildWindows = True
        Me.WindowManagerPanel1.AutoHide = True
        Me.WindowManagerPanel1.ButtonRenderMode = MDIWindowManager.ButtonRenderMode.Professional
        Me.WindowManagerPanel1.DisableCloseAction = False
        Me.WindowManagerPanel1.DisableHTileAction = False
        Me.WindowManagerPanel1.DisablePopoutAction = False
        Me.WindowManagerPanel1.DisableTileAction = False
        Me.WindowManagerPanel1.EnableTabPaintEvent = False
        resources.ApplyResources(Me.WindowManagerPanel1, "WindowManagerPanel1")
        Me.WindowManagerPanel1.MinMode = False
        Me.WindowManagerPanel1.Name = "WindowManagerPanel1"
        Me.WindowManagerPanel1.Orientation = MDIWindowManager.WindowManagerOrientation.Top
        Me.WindowManagerPanel1.ShowCloseButton = True
        Me.WindowManagerPanel1.ShowIcons = True
        Me.WindowManagerPanel1.ShowLayoutButtons = False
        Me.WindowManagerPanel1.ShowTitle = False
        Me.WindowManagerPanel1.Style = MDIWindowManager.TabStyle.AngledHiliteTabs
        Me.WindowManagerPanel1.TabRenderMode = MDIWindowManager.TabsProvider.Standard
        Me.WindowManagerPanel1.TitleBackColor = System.Drawing.SystemColors.ControlDark
        Me.WindowManagerPanel1.TitleForeColor = System.Drawing.SystemColors.ControlLightLight
        '
        'ApplicationExplorerForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WindowManagerPanel1)
        Me.Controls.Add(Me.ShortcutBarSplitter)
        Me.Controls.Add(Me.ShortcutBarSideMenu)
        Me.Controls.Add(Me.HeaderPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStripPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ApplicationExplorerForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.FileOperationsToolStrip.ResumeLayout(False)
        Me.FileOperationsToolStrip.PerformLayout()
        Me.NavigationToolStrip.ResumeLayout(False)
        Me.NavigationToolStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.HeaderPanel.ResumeLayout(False)
        Me.ToolStripPanel1.ResumeLayout(False)
        Me.ToolStripPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileOperationsToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ShortcutBarSideMenu As SideMenu.SideMenu
    Friend WithEvents HeaderPanel As System.Windows.Forms.Panel
    Friend WithEvents HeaderTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ShortcutBarSplitter As System.Windows.Forms.Splitter
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileNewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileOpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileSaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NavigationToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents NavBackToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NavForwardToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NavCancelToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NavRefreshToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMRUSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpAboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSepToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditFindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditFindNextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSepToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowToolbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowStatusBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowShortcutBarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSepToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewGotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewGotoBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpTopicsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpSepToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewRefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewStopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSepToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewGotoForwardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShortcutBarImageList As System.Windows.Forms.ImageList
    Friend WithEvents WindowMoreWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowHTileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowTileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowPopOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowSepToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WindowCloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowSepToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripPanel1 As System.Windows.Forms.ToolStripPanel
    Friend WithEvents WindowOrientationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowOrientationBottomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowOrientationRightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents FileMRUSep2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowManagerPanel1 As MDIWindowManager.WindowManagerPanel
    Friend WithEvents ClassicWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassicWindowCascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassicWindowTileHorizontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassicWindowTileVerticallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
