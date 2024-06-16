''' <summary>
''' Used by ApplicationExplorer to retrieve toolbars and menus from a child window to merge with it's own built-in menu bar and toolbars.
''' </summary>
''' <remarks></remarks>
Public Interface ICustomUIToolsCapable

    Function GetMenus() As MenuStrip
    Function GetToolbars() As ToolStripPanel
    Function PreferUnclutteredView() As Boolean
    Function PreferToolbarOnSecondRow() As Boolean

End Interface