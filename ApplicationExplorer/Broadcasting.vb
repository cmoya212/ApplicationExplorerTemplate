''' <summary>
''' Common broadcast commands for ApplicationExplorerForm.
''' </summary>
''' <remarks></remarks>
Public Enum BroadcastingCommonCodes
    OPENCHILD
    UPDATECOMMANDS
    SETSTATUSTEXT
    SETSTATUSPROGRESS
End Enum

''' <summary>
''' Shared functions to broadcast messages to ApplicationExplorerForm and other loaded forms.
''' </summary>
''' <remarks></remarks>
Public Class Broadcasting

    ''' <summary>
    ''' Create a status message ticket that is removed when the ticket is disposed.
    ''' </summary>
    Public Shared Function CreateStatusTicket(ByVal owner As Form) As StatusStackItem

        Dim item As New StatusStackItem(owner)

        SendNotification(owner, PredefinedMessages.CreateStatusStackItem, item, -1)

        Return item

    End Function

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal source As Object, ByVal messageCode As BroadcastingCommonCodes)

        SendNotification(source, messageCode, Nothing)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal source As Object, ByVal messageCode As BroadcastingCommonCodes, ByVal data As Object)

        Dim message As String = String.Empty

        Select Case messageCode
            Case BroadcastingCommonCodes.SETSTATUSPROGRESS
                message = PredefinedMessages.SetStatusProgress
            Case BroadcastingCommonCodes.SETSTATUSTEXT
                message = PredefinedMessages.SetStatusText
            Case BroadcastingCommonCodes.UPDATECOMMANDS
                message = PredefinedMessages.UpdateCommands
            Case BroadcastingCommonCodes.OPENCHILD
                message = PredefinedMessages.OpenChild
        End Select

        SendNotification(source, message, data)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal source As Object, ByVal message As String)

        SendNotification(source, message, Nothing)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal messageCode As BroadcastingCommonCodes)

        SendNotification(Nothing, messageCode, Nothing)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal message As String)

        SendNotification(Nothing, message, Nothing)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal source As Object, ByVal message As String, ByVal data As Object)

        Broadcasting.Notifier.SendNotification(source, message, data)

    End Sub

    ''' <summary>
    ''' Broadcast a message to other forms.
    ''' </summary>
    Public Shared Sub SendNotification(ByVal source As Object, ByVal message As String, ByVal data As Object, ByVal destinationId As Integer)

        Broadcasting.Notifier.SendNotification(source, message, data, destinationId)

    End Sub

    Public Shared WithEvents Notifier As New Notifier

    Private Shared Sub Notifier_Notify(ByVal sender As Object, ByVal e As Notifier.NotifyEventArgs) Handles Notifier.Notify

        If e.DestinationId >= 0 Then
            Try
                For Each frm As Form In My.Application.OpenForms
                    If TypeOf frm Is IBroadcastAware Then
                        If Not frm.IsDisposed Then
                            Try
                                DirectCast(frm, IBroadcastAware).MessageBroadcast(e)
                            Catch
                                'do nothing
                            End Try
                        End If
                    End If
                Next frm
            Catch
                'do nothing
            End Try
        End If

    End Sub

    Public Class PredefinedMessages

        Public Shared ReadOnly CreateStatusStackItem As String = "CREATESTATUSSTACKITEM"
        Public Shared ReadOnly OpenChild As String = "OPENCHILD"
        Public Shared ReadOnly UpdateCommands As String = "UPDATECOMMANDS"
        Public Shared ReadOnly SetStatusText As String = "SETSTATUSTEXT"
        Public Shared ReadOnly SetStatusProgress As String = "SETSTATUSPROGRESS"

    End Class

End Class