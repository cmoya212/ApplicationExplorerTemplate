Public Class SampleForm_PictureViewer
    Implements ICustomUIToolsCapable

    Public Function GetMenus() As System.Windows.Forms.MenuStrip Implements ICustomUIToolsCapable.GetMenus

    End Function

    Public Function GetToolbars() As System.Windows.Forms.ToolStripPanel Implements ICustomUIToolsCapable.GetToolbars

        Return Me.ToolStripPanel1

    End Function

    Public Function PreferToolbarOnSecondRow() As Boolean Implements ICustomUIToolsCapable.PreferToolbarOnSecondRow

    End Function

    Public Function PreferUnclutteredView() As Boolean Implements ICustomUIToolsCapable.PreferUnclutteredView

    End Function

End Class