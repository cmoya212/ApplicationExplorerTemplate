''' <summary>
''' Used by ApplicationExplorer to determine if a child window can implement its own custom "Find" operations.
''' </summary>
''' <remarks></remarks>
Public Interface ICustomEditFindCapable

    Function WillHandleFindOperations() As Boolean
    Function CanFind() As Boolean
    Function CanFindNext() As Boolean
    Function PerformFind() As Boolean
    Function PerformFind(ByVal text As String, ByVal direction As BasicEditHelper.EditFindDirection, ByVal options As BasicEditHelper.EditFindOptions) As Boolean
    Function PerformFindNext() As Boolean

End Interface
