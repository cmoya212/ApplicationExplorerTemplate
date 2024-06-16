''' <summary>
''' Used by ApplicationExplorer to determine if a child window can perform clipboard operations all on its own.
''' </summary>
''' <remarks></remarks>
Public Interface ICustomEditOperationsCapable

    Function WillHandleClipboardOperations() As Boolean
    Function CanUndo() As Boolean
    Function CanCut() As Boolean
    Function CanCopy() As Boolean
    Function CanPaste() As Boolean
    Sub PerformUndo()
    Sub PerformCut()
    Sub PerformCopy()
    Sub PerformPaste()

End Interface
