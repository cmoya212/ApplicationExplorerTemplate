''' <summary>
''' Used by ApplicationExplorer to determine if a child window can respond to typical Back/Forward Navigation features.
''' </summary>
''' <remarks></remarks>
Public Interface IBrowseCapable

    Function CanGoBack() As Boolean
    Function CanGoForward() As Boolean
    Function GoBack() As Boolean
    Function GoForward() As Boolean

End Interface