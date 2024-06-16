''' <summary>
''' Used by ApplicationExplorer to determine if a child window will respond to the built-in Refresh/Stop commands.
''' </summary>
''' <remarks></remarks>
Public Interface IRefreshCapable

    Function CanRefresh() As Boolean
    Function CanRefreshCancel() As Boolean
    Sub PerformRefresh()
    Sub PerformRefreshCancel()

End Interface
