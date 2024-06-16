''' <summary>
''' Class to keep a backtrackable stack of statusbar messages.
''' </summary>
''' <remarks></remarks>
Public Class StatusStack

    Public Event CurrentItemChanged As EventHandler

    Private m_statusItems As New List(Of StatusStackItem)

    Public Function GetCurrentItem() As StatusStackItem

        If m_statusItems.Count > 0 Then
            Return m_statusItems.Item(m_statusItems.Count - 1)
        Else
            Return Nothing
        End If

    End Function

    Public Sub AddItem(ByVal item As StatusStackItem)

        If Not m_statusItems.Contains(item) Then
            m_statusItems.Add(item)
            AddStatusStackItemEventHandlers(item)
            OnCurrentItemChanged(EventArgs.Empty)
        Else
            If Not item Is GetCurrentItem() Then
                m_statusItems.Remove(item)
                m_statusItems.Add(item)
                OnCurrentItemChanged(EventArgs.Empty)
            End If
        End If

    End Sub

    Public Sub RemoveItem(ByVal item As StatusStackItem)

        If m_statusItems.Contains(item) Then
            Dim isCurrentItem As Boolean = (item Is GetCurrentItem())

            RemoveStatusStackItemEventHandlers(item)
            m_statusItems.Remove(item)

            If isCurrentItem Then
                OnCurrentItemChanged(EventArgs.Empty)
            End If
        End If

    End Sub

    Public Function GetAllItems() As List(Of StatusStackItem)

        Return New List(Of StatusStackItem)(m_statusItems)

    End Function

    Public Sub RemoveAllItems()

        If m_statusItems.Count > 0 Then
            For index As Integer = m_statusItems.Count - 1 To 0 Step -1
                RemoveItem(m_statusItems.Item(index))
            Next index
        End If

    End Sub

    Private Sub AddStatusStackItemEventHandlers(ByVal item As StatusStackItem)

        AddHandler item.Disposed, AddressOf HandleStatusStackItemDispose
        AddHandler item.MessageChanged, AddressOf HandleStatusStackItemPropertyChanged
        AddHandler item.ProgressChanged, AddressOf HandleStatusStackItemPropertyChanged

    End Sub

    Private Sub RemoveStatusStackItemEventHandlers(ByVal item As StatusStackItem)

        RemoveHandler item.Disposed, AddressOf HandleStatusStackItemDispose
        RemoveHandler item.MessageChanged, AddressOf HandleStatusStackItemPropertyChanged
        RemoveHandler item.ProgressChanged, AddressOf HandleStatusStackItemPropertyChanged

    End Sub

    Private Sub HandleStatusStackItemDispose(ByVal sender As Object, ByVal e As EventArgs)

        RemoveItem(DirectCast(sender, StatusStackItem))

    End Sub

    Private Sub HandleStatusStackItemPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is GetCurrentItem() Then
            OnCurrentItemChanged(EventArgs.Empty)
        End If

    End Sub

    Protected Overridable Sub OnCurrentItemChanged(ByVal e As EventArgs)

        RaiseEvent CurrentItemChanged(Me, e)

    End Sub

End Class

''' <summary>
''' Disposable status ticket.
''' </summary>
''' <remarks>When disposed this object is removed from the stack and the change should be reflected in statusbars that use the StatusStack.</remarks>
Public Class StatusStackItem
    Implements IDisposable

    Public Event MessageChanged As EventHandler
    Public Event ProgressChanged As EventHandler
    Public Event Disposed As EventHandler

    Private m_source As Object
    Private m_message As String = String.Empty
    Private m_messageSwap As String = String.Empty
    Private m_genericBusyMessage As Boolean = False
    Private m_useWaitCursor As Boolean = False
    Private m_progressMin As Integer = 0
    Private m_progressMax As Integer = 0
    Private m_progressPosition As Integer = 0

    Private m_disposed As Boolean = False

    Public Shared ReadOnly GenericMessage As String = "__GENERIC__"

    Public ReadOnly Property Source() As Object

        Get
            Return m_source
        End Get

    End Property

    Public Property Message() As String

        Get
            Return m_message
        End Get

        Set(ByVal value As String)
            If m_message <> value Then
                m_genericBusyMessage = False
                m_message = value
                OnMessageChanged(EventArgs.Empty)
            End If
        End Set

    End Property

    Public Property GenericBusyMessage() As Boolean

        Get
            Return m_genericBusyMessage
        End Get

        Set(ByVal value As Boolean)
            If m_genericBusyMessage <> value Then
                m_genericBusyMessage = value
                If m_genericBusyMessage Then
                    m_messageSwap = m_message
                    m_message = StatusStackItem.GenericMessage
                    OnMessageChanged(EventArgs.Empty)
                Else
                    m_message = m_messageSwap
                    OnMessageChanged(EventArgs.Empty)
                End If
            End If
        End Set

    End Property

    Public Property UseWaitCursor() As Boolean

        Get
            Return m_useWaitCursor
        End Get

        Set(ByVal value As Boolean)
            If m_useWaitCursor <> value Then
                m_useWaitCursor = value
                OnMessageChanged(EventArgs.Empty)
            End If
        End Set

    End Property

    Public Property ProgressMin() As Integer

        Get
            Return m_progressMin
        End Get

        Set(ByVal value As Integer)
            If m_progressMin <> value Then
                m_progressMin = value
                OnProgressChanged(EventArgs.Empty)
            End If
        End Set

    End Property

    Public Property ProgressMax() As Integer

        Get
            Return m_progressMax
        End Get

        Set(ByVal value As Integer)
            If m_progressMax <> value Then
                m_progressMax = value
                OnProgressChanged(EventArgs.Empty)
            End If
        End Set

    End Property

    Public Property ProgressPosition() As Integer

        Get
            Return m_progressPosition
        End Get

        Set(ByVal value As Integer)
            If m_progressPosition <> value Then
                m_progressPosition = value
                OnProgressChanged(EventArgs.Empty)
            End If
        End Set

    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal source As Object)

        m_source = source

    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)

        If Not m_disposed Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources

            Try
                OnDisposed(EventArgs.Empty)
            Catch
                'do nothing
            End Try
        End If

        m_disposed = True

    End Sub

    Public Sub SetBusyMessage(ByVal value As Boolean, Optional ByVal useWaitCursor As Boolean = True)

        If value Then
            SetBusyMessage(StatusStackItem.GenericMessage, useWaitCursor)
        Else
            SetBusyMessage(String.Empty, False)
        End If

    End Sub

    Public Sub SetBusyMessage(ByVal message As String, Optional ByVal useWaitCursor As Boolean = True)

        If message <> String.Empty Then
            If message <> m_message OrElse useWaitCursor <> m_useWaitCursor Then
                m_message = message
                m_useWaitCursor = useWaitCursor
                OnMessageChanged(EventArgs.Empty)
            End If
        Else
            If m_message <> String.Empty OrElse m_useWaitCursor <> False Then
                m_message = String.Empty
                m_useWaitCursor = False
                OnMessageChanged(EventArgs.Empty)
            End If
        End If

    End Sub

    Public Sub SetMarqueeProgress()

        SetProgress(True)

    End Sub

    Public Sub SetProgress(ByVal value As Boolean)

        If value Then
            SetProgress(-1, -1, -1)
        Else
            SetProgress(0, 0, 0)
        End If

    End Sub

    Public Sub SetProgress(ByVal min As Integer, ByVal max As Integer, ByVal position As Integer)

        If m_progressPosition <> position OrElse m_progressMin <> min OrElse m_progressMax <> max Then
            m_progressMin = min
            m_progressMax = max
            m_progressPosition = position
            OnProgressChanged(EventArgs.Empty)
        End If

    End Sub

    Protected Overridable Sub OnMessageChanged(ByVal e As EventArgs)

        RaiseEvent MessageChanged(Me, e)

    End Sub

    Protected Overridable Sub OnProgressChanged(ByVal e As EventArgs)

        RaiseEvent ProgressChanged(Me, e)

    End Sub

    Protected Overridable Sub OnDisposed(ByVal e As EventArgs)

        RaiseEvent Disposed(Me, e)

    End Sub

End Class