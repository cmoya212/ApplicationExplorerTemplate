''' <summary>
''' WebBrowser Form Template.
''' </summary>
''' <remarks>Reuse this form or copy and customize it to create a reusable web browser.</remarks>
Public Class WebBrowserForm
    Implements IApplicationExplorerAware
    Implements IBrowseCapable
    Implements IRefreshCapable
    Implements ICustomEditFindCapable
    Implements ICustomEditOperationsCapable
    Implements ICustomUIToolsCapable

    Private m_initialUrl As String = String.Empty

    ''' <summary>
    ''' Sets the initial start page to show when the form loads.
    ''' </summary>
    ''' <remarks>Set to HOME to have the browser navigate to the user's default Internet Explorer home page.</remarks>
    Public Property InitialUrl() As String

        Get
            Return m_initialUrl
        End Get

        Set(ByVal value As String)
            m_initialUrl = value
        End Set

    End Property

    Private Sub WebBrowserForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If m_initialUrl <> String.Empty Then
            If m_initialUrl = "HOME" Then
                Me.EnhancedWebBrowser1.GoHome()
            Else
                Me.EnhancedWebBrowser1.Navigate(m_initialUrl)
            End If
        End If

    End Sub

    Public Function CanGoBack() As Boolean Implements IBrowseCapable.CanGoBack

        Return Me.EnhancedWebBrowser1.CanGoBack()

    End Function

    Public Function CanGoForward() As Boolean Implements IBrowseCapable.CanGoForward

        Return Me.EnhancedWebBrowser1.CanGoForward()

    End Function

    Public Function GoBack() As Boolean Implements IBrowseCapable.GoBack

        Return Me.EnhancedWebBrowser1.GoBack()

    End Function

    Public Function GoForward() As Boolean Implements IBrowseCapable.GoForward

        Return Me.EnhancedWebBrowser1.GoForward()

    End Function

    Public Function CanRefresh() As Boolean Implements IRefreshCapable.CanRefresh

        Return True

    End Function

    Public Function CanRefreshCancel() As Boolean Implements IRefreshCapable.CanRefreshCancel

        If Not Me.EnhancedWebBrowser1.IsDisposed Then
            Return (Me.EnhancedWebBrowser1.ReadyState = WebBrowserReadyState.Loading) '(Me.WebBrowser1.ReadyState <> WebBrowserReadyState.Complete) 'And Me.WebBrowser1.ReadyState <> WebBrowserReadyState.Interactive And Me.WebBrowser1.ReadyState <> WebBrowserReadyState.Loaded)
        End If

    End Function

    Public Sub PerformRefresh() Implements IRefreshCapable.PerformRefresh

        Me.EnhancedWebBrowser1.Refresh()

    End Sub

    Public Sub PerformRefreshCancel() Implements IRefreshCapable.PerformRefreshCancel

        Me.EnhancedWebBrowser1.Stop()

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

        Broadcasting.SendNotification(Me, BroadcastingCommonCodes.UPDATECOMMANDS)

    End Sub

    Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs)

        Broadcasting.SendNotification(Me, BroadcastingCommonCodes.UPDATECOMMANDS)

    End Sub

    Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs)

        Me.AddressToolStripComboBox.Text = Me.EnhancedWebBrowser1.Url.ToString()
        Broadcasting.SendNotification(Me, BroadcastingCommonCodes.UPDATECOMMANDS)

    End Sub

    Public Function CanFind() As Boolean Implements ICustomEditFindCapable.CanFind

        Return True

    End Function

    Public Function CanFindNext() As Boolean Implements ICustomEditFindCapable.CanFindNext

        Return False

    End Function

    Public Function PerformFind() As Boolean Implements ICustomEditFindCapable.PerformFind

        Me.EnhancedWebBrowser1.ShowFindDialog()

    End Function

    Public Function PerformFind(ByVal text As String, ByVal direction As BasicEditHelper.EditFindDirection, ByVal options As BasicEditHelper.EditFindOptions) As Boolean Implements ICustomEditFindCapable.PerformFind

        Return False

    End Function

    Public Function PerformFindNext() As Boolean Implements ICustomEditFindCapable.PerformFindNext

        Return False

    End Function

    Public Function WillHandleFindOperations() As Boolean Implements ICustomEditFindCapable.WillHandleFindOperations

        Return True

    End Function

    Public Function CanCopy() As Boolean Implements ICustomEditOperationsCapable.CanCopy

        Return Me.EnhancedWebBrowser1.IsEditCopyEnabled()

    End Function

    Public Function CanCut() As Boolean Implements ICustomEditOperationsCapable.CanCut

        Return Me.EnhancedWebBrowser1.IsEditCutEnabled()

    End Function

    Public Function CanPaste() As Boolean Implements ICustomEditOperationsCapable.CanPaste

        Return Me.EnhancedWebBrowser1.IsEditPasteEnabled()

    End Function

    Public Function CanUndo() As Boolean Implements ICustomEditOperationsCapable.CanUndo

        Return Me.EnhancedWebBrowser1.IsEditUndoEnabled()

    End Function

    Public Sub PerformCopy() Implements ICustomEditOperationsCapable.PerformCopy

        Me.EnhancedWebBrowser1.ExecEditCopy()

    End Sub

    Public Sub PerformCut() Implements ICustomEditOperationsCapable.PerformCut

        Me.EnhancedWebBrowser1.ExecEditCut()

    End Sub

    Public Sub PerformPaste() Implements ICustomEditOperationsCapable.PerformPaste

        Me.EnhancedWebBrowser1.ExecEditPaste()

    End Sub

    Public Sub PerformUndo() Implements ICustomEditOperationsCapable.PerformUndo

        Me.EnhancedWebBrowser1.ExecEditUndo()

    End Sub

    Public Function WillHandleClipboardOperations() As Boolean Implements ICustomEditOperationsCapable.WillHandleClipboardOperations

        Return True

    End Function

    Private Sub WebBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs)

        If Me.EnhancedWebBrowser1.IsHandleCreated Then
            Broadcasting.SendNotification(Me, BroadcastingCommonCodes.SETSTATUSPROGRESS, "0," + CStr(e.MaximumProgress) + "," + CStr(e.CurrentProgress))
        End If

    End Sub

    Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.EnhancedWebBrowser1.IsHandleCreated Then
            Broadcasting.SendNotification(Me, BroadcastingCommonCodes.SETSTATUSTEXT, Me.EnhancedWebBrowser1.StatusText)
        End If

    End Sub

    Public Function GetMenus() As System.Windows.Forms.MenuStrip Implements ICustomUIToolsCapable.GetMenus

        Return Nothing

    End Function

    Public Function GetToolbars() As System.Windows.Forms.ToolStripPanel Implements ICustomUIToolsCapable.GetToolbars

        Return Me.ToolStripPanel1 'New ToolStrip() {ToolStrip1}

    End Function

    Public Function PreferUnclutteredView() As Boolean Implements ICustomUIToolsCapable.PreferUnclutteredView

        Return True

    End Function

    Public Function PreferToolbarOnSecondRow() As Boolean Implements ICustomUIToolsCapable.PreferToolbarOnSecondRow

        Return False

    End Function

    Private Sub GoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToolStripButton.Click

        NavigateToAddressBoxUrl()

    End Sub

    Private Sub AddressToolStripComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AddressToolStripComboBox.KeyPress

        If e.KeyChar = ChrW(Keys.Return) Then
            e.Handled = True
            NavigateToAddressBoxUrl()
        End If

    End Sub

    Private Sub NavigateToAddressBoxUrl()

        Me.EnhancedWebBrowser1.Navigate(Me.AddressToolStripComboBox.Text)

        Me.AddressToolStripComboBox.Items.Remove(Me.AddressToolStripComboBox.Text)
        Me.AddressToolStripComboBox.Items.Insert(0, Me.AddressToolStripComboBox.Text)

    End Sub

    Public Sub OnApplicationExplorerInit() Implements IApplicationExplorerAware.OnApplicationExplorerInit

    End Sub

    Public Sub OnWindowPopOut(ByVal e As System.ComponentModel.CancelEventArgs) Implements IApplicationExplorerAware.OnWindowPopOut

        e.Cancel = True

    End Sub

End Class