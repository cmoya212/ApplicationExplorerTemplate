''' <summary>
''' Traditional message broadcast class used to communicate commands and data.
''' </summary>
''' <remarks></remarks>
Public Class Notifier

    Public Event Notify As EventHandler(Of NotifyEventArgs)

    Public Sub SendNotification(ByVal source As Object, ByVal message As String, ByVal data As Object)

        OnNotify(New NotifyEventArgs(source, message, data))

    End Sub

    Public Sub SendNotification(ByVal source As Object, ByVal message As String, ByVal data As Object, ByVal destinationId As Integer)

        OnNotify(New NotifyEventArgs(source, message, data, destinationId))

    End Sub

    Protected Overridable Sub OnNotify(ByVal e As NotifyEventArgs)

        RaiseEvent Notify(Me, e)

    End Sub

    Public Class NotifyEventArgs
        Inherits System.ComponentModel.HandledEventArgs

        Private m_source As Object
        Private m_message As String = String.Empty
        Private m_data As Object
        Private m_destinationId As Integer

        Public ReadOnly Property Source() As Object

            Get
                Return m_source
            End Get

        End Property

        Public ReadOnly Property Message() As String

            Get
                Return m_message
            End Get

        End Property

        Public ReadOnly Property Data() As Object

            Get
                Return m_data
            End Get

        End Property

        Public ReadOnly Property DestinationId() As Integer

            Get
                Return m_destinationId
            End Get

        End Property

        Public Sub New(ByVal source As Object, ByVal message As String, ByVal data As Object)

            m_source = source
            m_message = message
            m_data = data

        End Sub

        Public Sub New(ByVal source As Object, ByVal message As String, ByVal data As Object, ByVal destinationId As Integer)

            m_source = source
            m_message = message
            m_data = data
            m_destinationId = destinationId

        End Sub

    End Class

End Class