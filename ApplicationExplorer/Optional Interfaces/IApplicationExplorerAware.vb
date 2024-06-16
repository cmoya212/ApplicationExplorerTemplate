''' <summary>
''' Used by ApplicationExplorer to inform child windows of aspects of the main interface.
''' </summary>
''' <remarks></remarks>
Public Interface IApplicationExplorerAware

    Sub OnApplicationExplorerInit()
    Sub OnWindowPopOut(ByVal e As System.ComponentModel.CancelEventArgs)

End Interface
