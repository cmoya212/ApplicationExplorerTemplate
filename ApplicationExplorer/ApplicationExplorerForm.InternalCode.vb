'This partial class contains the plumbing for ApplicationExplorerForm's
'built-in features. Much of it is modifiable... but do so with caution.
'For most situations, YOU DO NOT NEED TO MODIFY THIS FILE. you should be
'able to do ALL your work in the ApplicationExplorerForm.vb class file...
'NOT here.

Partial Class ApplicationExplorerForm

#Region "Settings Enums"

    Private Enum UIMode
        ''' <summary>
        ''' Simple tabbed multiple document interface.
        ''' </summary>
        ChildrenOnlyBased = 0
        ''' <summary>
        ''' Master windows with tabbed children interface.
        ''' </summary>
        MultiViewBased = 1
        ''' <summary>
        ''' Simple dialog-based interface with only one master window.
        ''' </summary>
        SingleViewBased = 2
    End Enum

    Private Enum UIModeViewBasedOrientation
        ''' <summary>
        ''' Child windows are oriented on the bottom and the Auxiliary Window Pane is oriented at the top (Classic Outlook-esque Style).
        ''' </summary>
        ''' <remarks>This setting is only applicable for MultiViewBased UIMode.</remarks>
        Bottom = 0
        ''' <summary>
        ''' Child windows are oriented on the right and the Auxiliary Window Pane is oriented on the left (Outlook 2003 Style).
        ''' </summary>
        ''' <remarks>This setting is only applicable for MultiViewBased UIMode.</remarks>
        Right = 1
    End Enum

    Private Enum UIToolMerging
        ''' <summary>
        ''' Menu and toolbar merging is dependent on UIMode.
        ''' </summary>
        ''' <remarks>ChildrenOnly: All windows participate in merging. MultiView: Only the current master window participates in merging.</remarks>
        Auto = 0
        ''' <summary>
        ''' Any window with the focus will have its menus and toolbars merged with ApplicationExplorer.
        ''' </summary>
        ''' <remarks></remarks>
        All = 1
    End Enum

    Private Enum UIBuiltInToolbars
        ''' <summary>
        ''' Default: Show standard built-in Back/Forward toolbar... suitable for all applications.
        ''' </summary>
        ''' <remarks>ApplicationExplorer contains built-in code to allow for Back/Fwd cycling through windows.</remarks>
        Navigation = 0
        ''' <summary>
        ''' Show File/Open/Save toolbar.
        ''' </summary>
        ''' <remarks>File operations must be customized in the event handlers for the toolbar and menu items.</remarks>
        FileOperations = 1
        ''' <summary>
        ''' Show both sets of built-in toolbars.
        ''' </summary>
        Both = 2
        ''' <summary>
        ''' Don't display the built-in toolbars.
        ''' </summary>
        Neither = 3
    End Enum

    Public Enum UIShortcutBar
        ''' <summary>
        ''' ShortcutBar's initial visibility is dependent on UIMode.
        ''' </summary>
        ''' <remarks>MultiViewBased UIMode will show the Shortcut SideBar, the others will not.</remarks>
        Auto = 0
        ''' <summary>
        ''' Shortcut SideBar is initially visible.
        ''' </summary>
        Visible = 1
        ''' <summary>
        ''' Shortcut SideBar is initially not visible.
        ''' </summary>
        ''' <remarks></remarks>
        NotVisible = 2
    End Enum

    Public Enum UIShortcutBarAuxViewHandling
        ''' <summary>
        ''' Automatically show Master Aux windows using the Shortcut SideBar.
        ''' </summary>
        Auto = 0
        ''' <summary>
        ''' Manually handle Shortcut SideBar clicks.
        ''' </summary>
        Manual = 1
    End Enum

#End Region

#Region "Internal Properties"

    'do not modify the following variables

    Private WithEvents m_notifier As Notifier = Broadcasting.Notifier

    Private WithEvents m_findForm As FindForm
    Private m_suppressIndicateControlOnFind As Boolean = False

    Private m_loading As Boolean = False
    Private m_tdiMode As Boolean = True
    Private m_forwardNavHistoryStack As New ArrayList
    Private m_backNavHistoryStack As New ArrayList
    Private m_suspendNavHistoryUpdating As Boolean = False
    Private WithEvents m_currentMergedForm As Form
    Private m_currentMergedToolStrips As New List(Of MergedUITool)
    Private m_currentMergedMenuItems As New List(Of MergedUITool)
    Private WithEvents m_statusStack As New StatusStack

    Private Class MergedUITool
        Public Tool As Object
        Public OriginalToolVisibility As Boolean
        Public OriginalToolLocation As Point
        Public OriginalParent As Object
        Public OriginalParentVisibility As Boolean

        Public Sub New(ByVal toolObject As Object, ByVal originalToolVisibility As Boolean, ByVal originalToolLocation As Point, ByVal originalParentObject As Object, ByVal originalParentVisibility As Boolean)
            Me.Tool = toolObject
            Me.OriginalToolVisibility = originalToolVisibility
            Me.OriginalToolLocation = originalToolLocation
            Me.OriginalParent = originalParentObject
            Me.OriginalParentVisibility = originalParentVisibility
        End Sub
    End Class

    Private Class MRUToolStripMenuItem
        Inherits ToolStripMenuItem

        Public File As String = String.Empty
    End Class

#End Region

#Region "Initialization Code"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' do not modify
        m_findForm = New FindForm
        m_findForm.Owner = Me
        m_findForm.SetBounds(Me.Left + 20, Me.Top + 20, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)

        ' Add any additional customization here.

    End Sub

    Private Sub ApplicationExplorerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_loading = True

        'these methods should always occur in this order
        InitVolatileSettings()
        InitializeSettings()
        SetStartupFormBounds()
        UpdateUITexts()
        UpdateUIModeLookAndFeel()
        UpdateVolatileSettings()
        UpdateAllowableNavigateOptions()

        If m_uiMode <> UIMode.SingleViewBased Then
            If My.Settings.ClassicMDI Then
                PrepForClassicMDI()
            Else
                PrepForTDI()
            End If
        End If

        ' "inform" the *main* partial class of Form_Load... this lessens the need to modify this file
        PerformOnFormLoadActions()
        MergeChildTools()

        If m_uiShortcutBarAuxViewHandling = UIShortcutBarAuxViewHandling.Auto AndAlso m_uiAllowShortcutBar <> UIShortcutBar.NotVisible Then
            PrepShortcutSideBar()

            If Me.ShortcutBarSideMenu.Items.Count > 0 Then
                Me.ShortcutBarSideMenu.SelectedItemIndex = My.Settings.StartInShortcutIndex
            End If
        End If

        ResetNavHistory()

        If Me.WindowState <> My.Settings.MainWindowWindowState Then
            Me.WindowState = My.Settings.MainWindowWindowState
        End If

        m_loading = False

    End Sub

    Private Sub ResetNavHistory()

        ClearNavHistory()
        UpdateNavHistory()

    End Sub

    Private Sub PrepShortcutSideBar()

        If Me.ShortcutBarSideMenu.Items.Count > 0 Then
            For index As Integer = 0 To Me.ShortcutBarSideMenu.Items.Count - 1
                Try
                    RemoveHandler m_auxViewForms.Item(index).FormClosing, AddressOf HandleAuxViewFormClosing
                Catch
                    'do nothing
                End Try
            Next index
        End If

        Me.ShortcutBarSideMenu.Items.Clear()
        Me.ShortcutBarImageList.Images.Clear()

        Dim count As Integer

        For Each frm As Form In m_auxViewForms
            Me.ShortcutBarImageList.Images.Add(frm.Icon)
            Me.ShortcutBarSideMenu.Items.Add(New SideMenu.SideMenuItem(frm.Text, count))
            AddHandler frm.FormClosing, AddressOf HandleAuxViewFormClosing
            count += 1
        Next frm

    End Sub

    Private Sub HandleAuxViewFormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MsgBox(My.Resources.WindowCloseDisallowMessage, MsgBoxStyle.Exclamation)
        Else
            RemoveHandler DirectCast(sender, Form).FormClosing, AddressOf HandleAuxViewFormClosing
        End If

    End Sub

    Private Sub PrepForTDI()

        RemoveMergedTools(False)

        Me.WindowManagerPanel1.AutoDetectMdiChildWindows = False
        Me.WindowManagerPanel1.Visible = True
        Me.WindowToolStripMenuItem.Visible = True
        Me.ClassicWindowToolStripMenuItem.Visible = False

        Select Case m_uiMode
            Case UIMode.ChildrenOnlyBased
                Me.HeaderPanel.Visible = False
            Case UIMode.MultiViewBased
                Me.HeaderPanel.Visible = True
            Case UIMode.SingleViewBased
                Me.HeaderPanel.Visible = False
        End Select

        Me.ShortcutBarSideMenu.SelectedItemIndex = -1
        Me.WindowManagerPanel1.AuxiliaryWindow = Nothing

        If m_auxViewForms.Count > 0 Then
            For Each frm As Form In m_auxViewForms
                frm.Hide()
            Next frm
        End If

        For Each frm As Form In Me.MdiChildren
            If Not m_auxViewForms.Contains(frm) Then
                WindowManagerPanel1.AddWindow(frm)
            End If
        Next frm

        Me.WindowManagerPanel1.AutoDetectMdiChildWindows = True

        If Me.ShortcutBarSideMenu.Items.Count > 0 Then
            Me.ShortcutBarSideMenu.SelectedItemIndex = 0
        End If

        If Me.MdiChildren.Length > 0 Then
            Me.MdiChildren(0).BringToFront()
        End If

        m_tdiMode = True

        ResetNavHistory()

    End Sub

    Private Sub PrepForClassicMDI()

        RemoveMergedTools(False)

        Me.WindowManagerPanel1.AutoDetectMdiChildWindows = False
        Me.WindowManagerPanel1.Visible = False
        Me.WindowToolStripMenuItem.Visible = False
        Me.ClassicWindowToolStripMenuItem.Visible = True
        Me.HeaderPanel.Visible = False

        Me.ShortcutBarSideMenu.SelectedItemIndex = -1
        Dim auxiliaryWindow As Form = Me.WindowManagerPanel1.AuxiliaryWindow
        Me.WindowManagerPanel1.AuxiliaryWindow = Nothing

        Dim wrappedWindows As MDIWindowManager.WrappedWindowCollection = Me.WindowManagerPanel1.GetAllWindows()

        For Each wrappedWindow As MDIWindowManager.WrappedWindow In wrappedWindows
            Me.WindowManagerPanel1.RemoveWindow(wrappedWindow)
            wrappedWindow.AdjustFormProperties(False)
            wrappedWindow.Window = Nothing
        Next wrappedWindow

        If Me.MdiChildren.Length > 0 Then
            Me.MdiChildren(0).BringToFront()
        End If

        If m_auxViewForms.Count > 0 Then
            For Each frm As Form In m_auxViewForms
                If Not frm.MdiParent Is Me Then
                    frm.MdiParent = Me
                End If
                frm.Show()
            Next frm
        End If

        If Me.ShortcutBarSideMenu.Items.Count > 0 Then
            Me.ShortcutBarSideMenu.SelectedItemIndex = 0
        End If

        m_tdiMode = False

        ResetNavHistory()
        MergeChildTools()

    End Sub

    Private Sub ApplicationExplorerForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Using status As StatusStackItem = Broadcasting.CreateStatusTicket(Me)
            status.SetBusyMessage("Closing...", False)
            PerformOnFormClosingActions(e)
            CommitStartupFormBounds()
            CommitVolatileSettings()
            CloseAllWindows()
        End Using

    End Sub

    Private Sub ApplicationExplorerForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        PerformOnFormClosedActions(e)

    End Sub

#If SAMPLEMODE = "None" Then

    Private Sub InitializeSettings()
        'For Sample Code Use
    End Sub

#End If

    Private Sub UpdateUIModeLookAndFeel()

        Select Case m_uiMode
            Case UIMode.ChildrenOnlyBased
                Me.HeaderPanel.Visible = False
                Me.WindowToolStripMenuItem.Visible = Not My.Settings.ClassicMDI
                Me.FileCloseToolStripMenuItem.Visible = True

                If Not My.Settings.ShowShortcutBarInit Then
                    Select Case m_uiAllowShortcutBar
                        Case UIShortcutBar.Auto, UIShortcutBar.NotVisible
                            My.Settings.ShowShortcutBar = False
                        Case UIShortcutBar.Visible
                            My.Settings.ShowShortcutBar = True
                    End Select
                End If

                Me.WindowOrientationToolStripMenuItem.Visible = False

                Me.WindowManagerPanel1.Orientation = MDIWindowManager.WindowManagerOrientation.Top
                Me.WindowManagerPanel1.ShowTitle = False
                Me.WindowManagerPanel1.Height = 26
                Me.WindowManagerPanel1.AllowUserVerticalRepositioning = False
            Case UIMode.MultiViewBased, UIMode.SingleViewBased
                Select Case m_uiMode
                    Case UIMode.MultiViewBased
                        Me.HeaderPanel.Visible = True
                        Me.WindowToolStripMenuItem.Visible = Not My.Settings.ClassicMDI
                        Me.FileCloseToolStripMenuItem.Visible = True

                        If Not My.Settings.ShowShortcutBarInit Then
                            Select Case m_uiAllowShortcutBar
                                Case UIShortcutBar.Auto, UIShortcutBar.Visible
                                    My.Settings.ShowShortcutBar = True
                                Case UIShortcutBar.NotVisible
                                    My.Settings.ShowShortcutBar = False
                            End Select
                        End If
                    Case UIMode.SingleViewBased
                        Me.HeaderPanel.Visible = False
                        Me.WindowToolStripMenuItem.Visible = False
                        Me.ClassicWindowToolStripMenuItem.Visible = False
                        Me.FileCloseToolStripMenuItem.Visible = False

                        If Not My.Settings.ShowShortcutBarInit Then
                            Select Case m_uiAllowShortcutBar
                                Case UIShortcutBar.Auto
                                    My.Settings.ShowShortcutBar = False
                                Case UIShortcutBar.Visible
                                    My.Settings.ShowShortcutBar = True
                                Case UIShortcutBar.NotVisible
                                    My.Settings.ShowShortcutBar = False
                            End Select
                        End If
                End Select

                Me.WindowOrientationToolStripMenuItem.Visible = True
        End Select

        Select Case m_uiAllowBuiltInToolbars
            Case UIBuiltInToolbars.Both
                Me.FileOperationsToolStrip.Visible = True
                Me.NavigationToolStrip.Visible = True
            Case UIBuiltInToolbars.FileOperations
                Me.FileOperationsToolStrip.Visible = True
                Me.NavigationToolStrip.Visible = False
            Case UIBuiltInToolbars.Navigation
                Me.FileOperationsToolStrip.Visible = False
                Me.NavigationToolStrip.Visible = True
            Case UIBuiltInToolbars.Neither
                Me.FileOperationsToolStrip.Visible = False
                Me.NavigationToolStrip.Visible = False
        End Select

    End Sub

    Private Sub UpdateUITexts()

        UpdateTitleBarText()
        Me.HelpAboutToolStripMenuItem.Text = "&" + My.Resources.AboutLabel + " " + My.Application.Info.Title

    End Sub

    Private Sub UpdateTitleBarText()

        Select Case m_uiMode
            Case UIMode.ChildrenOnlyBased
                If Not Me.ActiveMdiChild Is Nothing Then
                    Me.Text = Me.ActiveMdiChild.Text + " - " + m_uiFormTitle
                Else
                    Me.Text = m_uiFormTitle
                End If
            Case UIMode.MultiViewBased
                If Me.ShortcutBarSideMenu.SelectedItemIndex <> -1 Then
                    Me.Text = Me.ShortcutBarSideMenu.SelectedItem.Text + " - " + m_uiFormTitle
                Else
                    Me.Text = m_uiFormTitle
                End If
            Case UIMode.SingleViewBased
                Me.Text = m_uiFormTitle
        End Select

    End Sub

#End Region

#Region "Settings Load/Save Code"

    Private Sub InitVolatileSettings()

        If My.Settings.AppLastUIMode <> m_uiMode Then
            My.Settings.Reset()
            My.Settings.AppLastUIMode = m_uiMode
            Debug.WriteLine("*** ApplicationExplorer user settings reinitialized ***")
        End If

    End Sub

    Private Sub UpdateVolatileSettings()

        Me.ToolStripPanel1.Visible = My.Settings.ShowToolbar
        Me.StatusStrip1.Visible = My.Settings.ShowStatusBar
        Me.ShortcutBarSplitter.Visible = My.Settings.ShowShortcutBar
        Me.ShortcutBarSideMenu.Visible = My.Settings.ShowShortcutBar

        If m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased Then
            SetWindowManagerOrientation(CType(My.Settings.OpenWindowsOrientation, UIModeViewBasedOrientation))
        End If

        If My.Settings.MRU Is Nothing Then
            My.Settings.MRU = New System.Collections.Specialized.NameValueCollection
        End If

    End Sub

    Private Sub CommitVolatileSettings()

        My.Settings.ShowToolbar = Me.ToolStripPanel1.Visible
        My.Settings.ShowStatusBar = Me.StatusStrip1.Visible
        My.Settings.ShowShortcutBar = Me.ShortcutBarSideMenu.Visible
        My.Settings.ShowShortcutBarInit = True

        Select Case Me.WindowManagerPanel1.Orientation
            Case MDIWindowManager.WindowManagerOrientation.Bottom
                My.Settings.OpenWindowsOrientation = CInt(UIModeViewBasedOrientation.Bottom)
            Case MDIWindowManager.WindowManagerOrientation.Right
                My.Settings.OpenWindowsOrientation = CInt(UIModeViewBasedOrientation.Right)
        End Select

        'My.Settings.MRU = New System.Collections.Specialized.StringCollection

        'For Each s As String In m_recentFileList
        '   My.Settings.MRU.Add(s)
        'Next s

    End Sub

    Private Sub SetStartupFormBounds()

        Dim startupBounds As Rectangle = Me.Bounds

        If My.Settings.MainWindowLocation.X < 0 Or My.Settings.MainWindowLocation.Y < 0 Then
            startupBounds.Location = New Point(0, 0)
        Else
            startupBounds.Location = My.Settings.MainWindowLocation
        End If

        If My.Settings.MainWindowSize.Width < 0 Or My.Settings.MainWindowSize.Height < 0 Then
            'do nothing, use designed form size
        Else
            startupBounds.Size = My.Settings.MainWindowSize
        End If

        If startupBounds.Right > My.Computer.Screen.WorkingArea.Right Or startupBounds.Bottom > My.Computer.Screen.WorkingArea.Bottom Then
            startupBounds.Location = New Point(0, 0)
        End If

        Me.Bounds = startupBounds

    End Sub

    Private Sub CommitStartupFormBounds()

        If Me.WindowState = FormWindowState.Minimized Then
            My.Settings.MainWindowWindowState = FormWindowState.Normal
        Else
            My.Settings.MainWindowWindowState = Me.WindowState
        End If

        If Me.WindowState = FormWindowState.Minimized Or Me.WindowState = FormWindowState.Maximized Then
            My.Settings.MainWindowLocation = Me.RestoreBounds.Location
            My.Settings.MainWindowSize = Me.RestoreBounds.Size
        Else
            My.Settings.MainWindowLocation = Me.Location
            My.Settings.MainWindowSize = Me.Size
        End If

    End Sub

#End Region

#Region "Navigation Code"

    Private Sub ApplicationExplorerForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

        If m_uiMode = UIMode.ChildrenOnlyBased OrElse (m_uiMode = UIMode.MultiViewBased AndAlso Not m_tdiMode) Then
            UpdateTitleBarText()
            MergeChildTools()
        End If

        UpdateNavHistory()
        PerformOnChildWindowActivatedActions()

        If m_uiMode = UIMode.ChildrenOnlyBased OrElse (m_uiMode = UIMode.MultiViewBased AndAlso Not m_tdiMode) OrElse m_uiMode = UIMode.SingleViewBased Then
            'should call MergeChildTools again in case ChildWindowActivated method in the other partial class loaded a new window
            MergeChildTools()
        End If

        UpdateAllToolItems()

    End Sub

    Private Sub ShortcutBarSideMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As SideMenu.SelectedIndexEventArgs) Handles ShortcutBarSideMenu.SelectedIndexChanged

        If Me.ShortcutBarSideMenu.SelectedItemIndex <> -1 Then
            Me.HeaderTitleLabel.Text = Me.ShortcutBarSideMenu.SelectedItem.Text
        Else
            Me.HeaderTitleLabel.Text = String.Empty
            'Me.HeaderTitleLabel.Text = m_uiFormTitle
        End If

        UpdateTitleBarText()

        If m_uiShortcutBarAuxViewHandling = UIShortcutBarAuxViewHandling.Auto Then
            If m_tdiMode Then
                If Me.ShortcutBarSideMenu.SelectedItemIndex >= 0 AndAlso m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased Then
                    MergeChildTools()
                End If
            End If

            SwitchAuxViewForm(Me.ShortcutBarSideMenu.SelectedItemIndex)

            If m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased Then
                'should call MergeChildTools again in case ChildWindowActivated method in the other partial class loaded a new window
                MergeChildTools()
            End If
        Else
            PerformOnShortcutBarSelectionChangeActions()
        End If

        If m_uiMode = UIMode.MultiViewBased Then
            If Not Me.WindowManagerPanel1.AuxiliaryWindow Is Nothing AndAlso TypeOf Me.WindowManagerPanel1.AuxiliaryWindow Is ICustomUIToolsCapable Then
                If CType(Me.WindowManagerPanel1.AuxiliaryWindow, ICustomUIToolsCapable).PreferUnclutteredView Then
                    Me.WindowManagerPanel1.MinMode = True
                Else
                    Me.WindowManagerPanel1.MinMode = False
                End If
            Else
                Me.WindowManagerPanel1.MinMode = False
            End If
        End If

        UpdateAllToolItems()

    End Sub

    Private Sub SwitchAuxViewForm(ByVal index As Integer)

        If index <> -1 Then
            Dim auxFrm As Form = m_auxViewForms.Item(Me.ShortcutBarSideMenu.SelectedItemIndex)

            If My.Settings.ClassicMDI Then
                auxFrm.MdiParent = Me
                auxFrm.Show()
                auxFrm.BringToFront()
                Me.ShortcutBarSideMenu.SelectedItemIndex = -1
            Else
                Me.WindowManagerPanel1.AuxiliaryWindow = auxFrm
            End If
        Else
            Me.WindowManagerPanel1.AuxiliaryWindow = Nothing
        End If

        UpdateNavHistory()

    End Sub

    Private Function GetActiveControlOrForm() As Control

        If Not Me.ActiveControl Is Nothing AndAlso TypeOf Me.ActiveControl Is Form Then
            If Not DirectCast(Me.ActiveControl, Form).ActiveControl Is Nothing Then
                Return DirectCast(Me.ActiveControl, Form).ActiveControl
            Else
                Return Me.ActiveControl
            End If
        Else
            Return Me
        End If

    End Function

    Private Sub UpdateShortcutsMenuItems()

        Dim sideMenuMirrorItems As New List(Of ToolStripMenuItem)

        For Each item As ToolStripItem In Me.ViewToolStripMenuItem.DropDownItems
            If CStr(item.Tag) = "SideMenuItem" Then
                sideMenuMirrorItems.Add(CType(item, ToolStripMenuItem))
            End If
        Next item

        If sideMenuMirrorItems.Count <> Me.ShortcutBarSideMenu.Items.Count Then
            If sideMenuMirrorItems.Count < Me.ShortcutBarSideMenu.Items.Count Then
                For count As Integer = 1 To Me.ShortcutBarSideMenu.Items.Count - sideMenuMirrorItems.Count
                    Dim newMenuItem As New ToolStripMenuItem

                    newMenuItem.Tag = "SideMenuItem"

                    sideMenuMirrorItems.Add(newMenuItem)
                    Me.ViewToolStripMenuItem.DropDownItems.Insert(sideMenuMirrorItems.Count - 1, newMenuItem)
                    AddHandler newMenuItem.Click, AddressOf HandleShortcutsMenuItemClick
                Next count
            Else
                For count As Integer = 1 To sideMenuMirrorItems.Count - Me.ShortcutBarSideMenu.Items.Count
                    RemoveHandler sideMenuMirrorItems.Item(0).Click, AddressOf HandleShortcutsMenuItemClick
                    sideMenuMirrorItems.RemoveAt(0)
                    Me.ViewToolStripMenuItem.DropDownItems.RemoveAt(0)
                Next count
            End If
        End If

        For index As Integer = 0 To Me.ShortcutBarSideMenu.Items.Count - 1
            With sideMenuMirrorItems.Item(index)
                .Text = Me.ShortcutBarSideMenu.Items.Item(index).Text

                If Not Me.ShortcutBarSideMenu.Items.Item(index).ImageList Is Nothing AndAlso Me.ShortcutBarSideMenu.Items.Item(index).ImageIndex >= 0 Then
                    .Image = Me.ShortcutBarSideMenu.Items.Item(index).ImageList.Images(Me.ShortcutBarSideMenu.Items.Item(index).ImageIndex)
                    .ImageTransparentColor = Me.ShortcutBarSideMenu.Items.Item(index).ImageList.TransparentColor
                Else
                    .Image = Nothing
                End If

                If index = Me.ShortcutBarSideMenu.SelectedItemIndex Then
                    .CheckState = CheckState.Checked
                Else
                    .CheckState = CheckState.Unchecked
                End If
            End With
        Next index

        If Me.ShortcutBarSideMenu.Items.Count = 1 Then
            sideMenuMirrorItems.Item(0).Visible = False
        End If

        Me.ViewSepToolStripMenuItem1.Visible = (Me.ShortcutBarSideMenu.Items.Count > 1)

    End Sub

    Private Sub UpdateAllToolItems()

        UpdateMRUMenuItems()
        UpdateEditMenuItems()
        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub UpdateEditMenuItems()

        Me.EditUndoToolStripMenuItem.Enabled = True
        Me.EditCutToolStripMenuItem.Enabled = True
        Me.EditCopyToolStripMenuItem.Enabled = True
        Me.EditPasteToolStripMenuItem.Enabled = True
        Me.EditFindToolStripMenuItem.Enabled = True
        Me.EditFindNextToolStripMenuItem.Enabled = True

        If TypeOf Me.ActiveMdiChild Is ICustomEditOperationsCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).WillHandleClipboardOperations Then
            Dim frm As ICustomEditOperationsCapable = CType(Me.ActiveMdiChild, ICustomEditOperationsCapable)

            Me.EditUndoToolStripMenuItem.Enabled = frm.CanUndo()
            Me.EditCopyToolStripMenuItem.Enabled = frm.CanCopy()
            Me.EditCutToolStripMenuItem.Enabled = frm.CanCut()
            Me.EditPasteToolStripMenuItem.Enabled = frm.CanPaste()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                If TypeOf ctl Is Form Then
                    Me.EditUndoToolStripMenuItem.Enabled = False
                    Me.EditCutToolStripMenuItem.Enabled = False
                    Me.EditCopyToolStripMenuItem.Enabled = False
                    Me.EditPasteToolStripMenuItem.Enabled = False
                Else
                    Dim editHelper As New BasicEditHelper

                    Me.EditUndoToolStripMenuItem.Enabled = editHelper.CanUndo(ctl)
                    Me.EditCutToolStripMenuItem.Enabled = editHelper.CanCut(ctl)
                    Me.EditCopyToolStripMenuItem.Enabled = editHelper.CanCopy(ctl)
                    Me.EditPasteToolStripMenuItem.Enabled = editHelper.CanPaste(ctl)
                End If
            Else
                Me.EditUndoToolStripMenuItem.Enabled = False
                Me.EditCutToolStripMenuItem.Enabled = False
                Me.EditCopyToolStripMenuItem.Enabled = False
                Me.EditPasteToolStripMenuItem.Enabled = False
            End If
        End If

        If TypeOf Me.ActiveMdiChild Is ICustomEditFindCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditFindCapable).WillHandleFindOperations Then
            Dim frm As ICustomEditFindCapable = CType(Me.ActiveMdiChild, ICustomEditFindCapable)

            Me.EditFindToolStripMenuItem.Enabled = frm.CanFind()
            Me.EditFindNextToolStripMenuItem.Enabled = frm.CanFindNext()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                If TypeOf ctl Is Form Then
                    Me.EditFindToolStripMenuItem.Enabled = False
                    Me.EditFindNextToolStripMenuItem.Enabled = False
                Else
                    Dim editHelper As New BasicEditHelper

                    Me.EditFindToolStripMenuItem.Enabled = editHelper.CanFind(ctl)

                    If Me.EditFindToolStripMenuItem.Enabled Then
                        Me.EditFindNextToolStripMenuItem.Enabled = (m_findForm.FindWhatComboBox.Text <> String.Empty)
                    Else
                        Me.EditFindNextToolStripMenuItem.Enabled = False
                    End If

                End If
            Else
                Me.EditFindToolStripMenuItem.Enabled = False
                Me.EditFindNextToolStripMenuItem.Enabled = False
            End If
        End If

    End Sub

    Private Sub UpdateMRUMenuItems()

        For index As Integer = Me.FileToolStripMenuItem.DropDownItems.Count - 1 To 0 Step -1
            Dim menuitem As ToolStripItem = Me.FileToolStripMenuItem.DropDownItems.Item(index)

            If TypeOf menuitem Is MRUToolStripMenuItem Then
                Me.FileToolStripMenuItem.DropDownItems.Remove(menuitem)
            End If
            'If TypeOf menuitem.Tag Is KeyValuePair(Of String, String) Then
            '    Dim tagitem As KeyValuePair(Of String, String) = CType(menuitem.Tag, KeyValuePair(Of String, String))

            '    If tagitem.Key = "MRU" Then
            '        Me.FileToolStripMenuItem.DropDownItems.Remove(menuitem)
            '    End If
            'End If
        Next index

        If Not My.Settings.MRU Is Nothing Then
            Dim startIndex As Integer = Me.FileToolStripMenuItem.DropDownItems.IndexOf(FileMRUSep1ToolStripMenuItem) + 1
            Dim tally As Integer = 0
            Dim tallyMax As Integer = My.Settings.MRUDisplayMax

            For Each file As String In My.Settings.MRU
                Dim newitem As New MRUToolStripMenuItem()

                newitem.Text = "&" + (tally + 1).ToString("G") + " " + DrawingHelper.PathCompactPath(file)
                newitem.File = file

                Me.FileToolStripMenuItem.DropDownItems.Insert(startIndex, newitem)

                startIndex += 1
                tally += 1

                If tally = tallyMax Then
                    Exit For
                End If
            Next file

            FileMRUSep2ToolStripMenuItem.Visible = (My.Settings.MRU.Count > 0)
        Else
            FileMRUSep2ToolStripMenuItem.Visible = False
        End If

    End Sub

    Private Sub HandleShortcutsMenuItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.ShortcutBarSideMenu.SelectedItemIndex = Me.ViewToolStripMenuItem.DropDownItems.IndexOf(CType(sender, ToolStripItem))

    End Sub

    Private Sub AddWindowToNavHistory(ByVal frm As Form)

        If Not m_backNavHistoryStack.Count = 0 Then
            If m_backNavHistoryStack.Item(0) Is frm Then
                Return
            End If
        End If

        RemoveWindowFromNavHistory(frm)
        m_backNavHistoryStack.Insert(0, frm)

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub RemoveWindowFromNavHistory(ByVal frm As Form)

        Do While m_forwardNavHistoryStack.Contains(frm)
            m_forwardNavHistoryStack.Remove(frm)
        Loop

        Do While m_backNavHistoryStack.Contains(frm)
            m_backNavHistoryStack.Remove(frm)
        Loop

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub AddViewIndexToNavHistory(ByVal index As Integer)

        If Not m_backNavHistoryStack.Count = 0 Then
            If TypeOf m_backNavHistoryStack.Item(0) Is Integer Then
                If CInt(m_backNavHistoryStack.Item(0)) = index Then
                    Return
                End If
            End If
        End If

        RemoveViewIndexFromNavHistory(index)
        m_backNavHistoryStack.Insert(0, index)

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub RemoveViewIndexFromNavHistory(ByVal index As Integer)

        Do While m_forwardNavHistoryStack.Contains(index)
            m_forwardNavHistoryStack.Remove(index)
        Loop

        Do While m_backNavHistoryStack.Contains(index)
            m_backNavHistoryStack.Remove(index)
        Loop

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub UpdateNavHistory()

        If m_tdiMode Then
            Select Case m_uiMode
                Case UIMode.ChildrenOnlyBased
                    If Not Me.ActiveMdiChild Is Nothing Then
                        AddWindowToNavHistory(Me.ActiveMdiChild)
                    End If
                Case UIMode.MultiViewBased
                    If Not Me.ShortcutBarSideMenu.SelectedItemIndex = -1 Then
                        AddViewIndexToNavHistory(Me.ShortcutBarSideMenu.SelectedItemIndex)
                    End If
            End Select
        Else
            If Not Me.ActiveMdiChild Is Nothing Then
                AddWindowToNavHistory(Me.ActiveMdiChild)
            End If
        End If

    End Sub

    Private Sub ClearNavHistory()

        m_forwardNavHistoryStack.Clear()
        m_backNavHistoryStack.Clear()

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub PerformSmartNavHistoryWindowSwitch(ByVal stepDirection As Integer)

        Dim activeForm As Form

        Select Case m_uiMode
            Case UIMode.ChildrenOnlyBased
                activeForm = Me.ActiveMdiChild
            Case UIMode.MultiViewBased, UIMode.SingleViewBased
                activeForm = Me.WindowManagerPanel1.AuxiliaryWindow
        End Select

        If TypeOf activeForm Is IBrowseCapable AndAlso ((stepDirection < 0 And CType(activeForm, IBrowseCapable).CanGoBack) OrElse (stepDirection > 0 And CType(activeForm, IBrowseCapable).CanGoForward)) Then
            Select Case stepDirection
                Case Is < 0
                    If Not CType(activeForm, IBrowseCapable).GoBack() Then
                        PerformNavHistoryWindowSwitch(stepDirection)
                    End If
                Case Is > 0
                    If Not CType(activeForm, IBrowseCapable).GoForward() Then
                        PerformNavHistoryWindowSwitch(stepDirection)
                    End If
            End Select
        Else
            PerformNavHistoryWindowSwitch(stepDirection)
        End If

    End Sub

    Private Sub PerformNavHistoryWindowSwitch(ByVal stepDirection As Integer)

        'todo: modify so that iDirection can be many
        Dim bOKToMove As Boolean = False

        Select Case stepDirection
            Case Is < 0
                If m_backNavHistoryStack.Count > 1 Then 'assume 1 is always the current view
                    If Not m_backNavHistoryStack.Item(0) Is Nothing Then
                        m_forwardNavHistoryStack.Insert(0, m_backNavHistoryStack.Item(0))
                        m_backNavHistoryStack.RemoveAt(0)
                        bOKToMove = True
                    End If
                End If
            Case Is > 0
                If m_forwardNavHistoryStack.Count > 0 Then
                    If Not m_forwardNavHistoryStack.Item(0) Is Nothing Then
                        m_backNavHistoryStack.Insert(0, m_forwardNavHistoryStack.Item(0))
                        m_forwardNavHistoryStack.RemoveAt(0)
                        bOKToMove = True
                    End If
                End If
        End Select

        'todo: need to add logic for Classic MDI mode
        If bOKToMove Then
            If m_backNavHistoryStack.Count > 0 Then
                If Not m_backNavHistoryStack.Item(0) Is Nothing Then
                    If m_tdiMode Then
                        Select Case m_uiMode
                            Case UIMode.ChildrenOnlyBased
                                SwitchToCurrentHistoryWindow(stepDirection)
                            Case UIMode.MultiViewBased, UIMode.SingleViewBased
                                SwitchToCurrentHistoryViewIndex()
                        End Select
                    Else
                        SwitchToCurrentHistoryWindow(stepDirection)
                    End If
                Else
                    m_backNavHistoryStack.RemoveAt(0)
                End If
            End If
        End If

        UpdateAllowableNavigateOptions()

    End Sub

    Private Sub SwitchToCurrentHistoryWindow(ByVal stepDirection As Integer)

        Dim frm As Form = CType(m_backNavHistoryStack.Item(0), Form)

        If Not frm.IsDisposed Then
            If frm.MdiParent Is Me Then
                'm_bSuspendHistoryUpdating = True
                ''SideMenu1.SelectedItemIndex = -1
                'm_bSuspendHistoryUpdating = False
                frm.Show()

                'DrawingHelper.IndicateControl(frm)

                Try
                    frm.Focus()
                Catch
                    'do nothing
                End Try
            Else
                m_backNavHistoryStack.RemoveAt(0)
                PerformNavHistoryWindowSwitch(stepDirection)
            End If
        Else
            m_backNavHistoryStack.RemoveAt(0)
            PerformNavHistoryWindowSwitch(stepDirection)
        End If

    End Sub

    Private Sub SwitchToCurrentHistoryViewIndex()

        Me.ShortcutBarSideMenu.SelectedItemIndex = CType(m_backNavHistoryStack.Item(0), Integer)

    End Sub

    Private Sub UpdateAllowableNavigateOptions()

        Dim activeForm As Form

        Select Case m_uiMode
            Case UIMode.ChildrenOnlyBased
                activeForm = Me.ActiveMdiChild
            Case UIMode.MultiViewBased, UIMode.SingleViewBased
                activeForm = Me.WindowManagerPanel1.AuxiliaryWindow
        End Select

        If TypeOf activeForm Is IBrowseCapable Then
            Dim browseCapableForm As IBrowseCapable = CType(activeForm, IBrowseCapable)

            If Not browseCapableForm.CanGoBack() AndAlso Not m_backNavHistoryStack.Count > 1 Then
                Me.ViewGotoBackToolStripMenuItem.Enabled = False
            Else
                Me.ViewGotoBackToolStripMenuItem.Enabled = True
            End If

            If Not browseCapableForm.CanGoForward() AndAlso Not m_forwardNavHistoryStack.Count > 0 Then
                Me.ViewGotoForwardToolStripMenuItem.Enabled = False
            Else
                Me.ViewGotoForwardToolStripMenuItem.Enabled = True
            End If
        Else
            Me.ViewGotoBackToolStripMenuItem.Enabled = m_backNavHistoryStack.Count > 1
            Me.ViewGotoForwardToolStripMenuItem.Enabled = m_forwardNavHistoryStack.Count > 0
        End If

        If TypeOf activeForm Is IRefreshCapable Then
            Dim refreshCapableForm As IRefreshCapable = CType(activeForm, IRefreshCapable)

            Me.ViewRefreshToolStripMenuItem.Enabled = refreshCapableForm.CanRefresh()
            Me.ViewStopToolStripMenuItem.Enabled = refreshCapableForm.CanRefreshCancel()
        Else
            Me.ViewRefreshToolStripMenuItem.Enabled = False
            Me.ViewStopToolStripMenuItem.Enabled = False
        End If

        Me.NavBackToolStripButton.Enabled = Me.ViewGotoBackToolStripMenuItem.Enabled
        Me.NavForwardToolStripButton.Enabled = Me.ViewGotoForwardToolStripMenuItem.Enabled
        Me.NavRefreshToolStripButton.Enabled = Me.ViewRefreshToolStripMenuItem.Enabled
        Me.NavCancelToolStripButton.Enabled = Me.ViewStopToolStripMenuItem.Enabled

    End Sub

    Private Sub ViewGotoBackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGotoBackToolStripMenuItem.Click

        PerformMoveBackInWindowHistory(True)

    End Sub

    Private Sub ViewGotoForwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGotoForwardToolStripMenuItem.Click

        PerformMoveForwardInWindowHistory(True)

    End Sub

    Private Sub NavBackToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBackToolStripButton.Click

        PerformMoveBackInWindowHistory(True)

    End Sub

    Private Sub NavForwardToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavForwardToolStripButton.Click

        PerformMoveForwardInWindowHistory(True)

    End Sub

    Private Sub WindowToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles WindowToolStripMenuItem.DropDownOpening

        For index As Integer = Me.WindowToolStripMenuItem.DropDownItems.Count - 1 To 0 Step -1
            Dim item As ToolStripItem = Me.WindowToolStripMenuItem.DropDownItems.Item(index)

            If TypeOf item.Tag Is MDIWindowManager.WrappedWindowMenuItem Then
                RemoveHandler item.Click, AddressOf HandleWindowSwitchMenuItemClick
                Me.WindowToolStripMenuItem.DropDownItems.Remove(item)
                CType(item.Tag, MDIWindowManager.WrappedWindowMenuItem).Dispose()
                item.Tag = Nothing
                item.Dispose()
            End If
        Next index

        Dim menuItems As MenuItem() = Me.WindowManagerPanel1.GetAllWindowsMenu(9, True)

        If Not menuItems Is Nothing AndAlso menuItems.Length > 0 Then
            For Each item As MDIWindowManager.WrappedWindowMenuItem In menuItems
                Dim newItem As New ToolStripMenuItem

                newItem.Text = item.Text
                newItem.Checked = item.Checked
                newItem.Tag = item

                Me.WindowToolStripMenuItem.DropDownItems.Add(newItem)
                AddHandler newItem.Click, AddressOf HandleWindowSwitchMenuItemClick
            Next item
        End If

        Me.WindowToolStripMenuItem.DropDownItems.Remove(Me.WindowMoreWindowsToolStripMenuItem)
        Me.WindowToolStripMenuItem.DropDownItems.Add(Me.WindowMoreWindowsToolStripMenuItem)

    End Sub

    Private Sub HandleWindowSwitchMenuItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CType(CType(sender, ToolStripMenuItem).Tag, MDIWindowManager.WrappedWindowMenuItem).PerformClick()

    End Sub

    Private Sub WindowMoreWindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowMoreWindowsToolStripMenuItem.Click

        ShowAllWindowsDialog()

    End Sub

    Private Sub WindowHTileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowHTileToolStripMenuItem.Click

        HTileCurrentWindow()

    End Sub

    Private Sub WindowTileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowTileToolStripMenuItem.Click

        TileCurrentWindow()

    End Sub

    Private Sub WindowPopOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowPopOutToolStripMenuItem.Click

        PopOutCurrentWindow()

    End Sub

    Private Sub WindowCloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowCloseAllToolStripMenuItem.Click

        CloseAllTabbedChildWindows()

    End Sub

    Private Sub WindowOrientationToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles WindowOrientationToolStripMenuItem.DropDownOpening

        Me.WindowOrientationBottomToolStripMenuItem.Checked = False
        Me.WindowOrientationRightToolStripMenuItem.Checked = False

        Select Case Me.WindowManagerPanel1.Orientation
            Case MDIWindowManager.WindowManagerOrientation.Bottom
                Me.WindowOrientationBottomToolStripMenuItem.Checked = True
            Case MDIWindowManager.WindowManagerOrientation.Right
                Me.WindowOrientationRightToolStripMenuItem.Checked = True
        End Select

    End Sub

    Private Sub WindowOrientationBottomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowOrientationBottomToolStripMenuItem.Click

        SetWindowManagerOrientation(UIModeViewBasedOrientation.Bottom)

    End Sub

    Private Sub WindowOrientationRightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowOrientationRightToolStripMenuItem.Click

        SetWindowManagerOrientation(UIModeViewBasedOrientation.Right)

    End Sub

    Private Sub ClassicWindowCascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassicWindowCascadeToolStripMenuItem.Click

        LayoutMdi(MdiLayout.Cascade)

    End Sub

    Private Sub ClassicWindowTileHorizontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassicWindowTileHorizontToolStripMenuItem.Click

        LayoutMdi(MdiLayout.TileHorizontal)

    End Sub

    Private Sub ClassicWindowTileVerticallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassicWindowTileVerticallyToolStripMenuItem.Click

        LayoutMdi(MdiLayout.TileVertical)

    End Sub

    Private Sub MergeChildTools()

        Me.SuspendLayout()

        RemoveMergedTools(True)

        Dim frm As Form

        If m_uiAllowToolMerging = UIToolMerging.All OrElse (m_uiAllowToolMerging = UIToolMerging.Auto AndAlso m_uiMode = UIMode.ChildrenOnlyBased) OrElse Not m_tdiMode Then
            If m_tdiMode OrElse (Not m_tdiMode AndAlso m_uiMode = UIMode.ChildrenOnlyBased) OrElse (Not m_tdiMode And m_uiMode = UIMode.MultiViewBased And m_auxViewForms.Contains(Me.ActiveMdiChild)) Then
                frm = Me.ActiveMdiChild
            End If
        ElseIf m_uiAllowToolMerging = UIToolMerging.Auto AndAlso (m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased) Then
            frm = Me.WindowManagerPanel1.AuxiliaryWindow
        End If

        If Not frm Is Nothing Then
            If TypeOf frm Is ICustomUIToolsCapable Then
                Dim customUIToolsCapableForm As ICustomUIToolsCapable = CType(frm, ICustomUIToolsCapable)

                Dim toolstrippanel As ToolStripPanel = customUIToolsCapableForm.GetToolbars()

                If Not toolstrippanel Is Nothing Then
                    For Each item As Control In toolstrippanel.Controls
                        If TypeOf item Is ToolStrip Then
                            Dim toolstrip As ToolStrip = CType(item, ToolStrip)
                            m_currentMergedToolStrips.Add(New MergedUITool(toolstrip, toolstrip.Visible, toolstrip.Location, toolstrippanel, toolstrippanel.Visible))
                        End If
                    Next item

                    For Each item As MergedUITool In m_currentMergedToolStrips
                        Dim row As Integer = 0

                        If customUIToolsCapableForm.PreferToolbarOnSecondRow Then
                            row = 1
                        Else
                            row = 0
                        End If

                        If ToolStripPanel1.Rows.Length < row + 1 Then
                            Me.ToolStripPanel1.Join(CType(item.Tool, ToolStrip), row)
                        Else
                            Me.ToolStripPanel1.Join(CType(item.Tool, ToolStrip), GetRightmostPoint(Me.ToolStripPanel1, row))
                        End If
                    Next item

                    toolstrippanel.Visible = False
                End If

                Dim menustrip As MenuStrip = customUIToolsCapableForm.GetMenus()

                If Not menustrip Is Nothing Then
                    For Each menuitem As ToolStripMenuItem In menustrip.Items
                        m_currentMergedMenuItems.Add(New MergedUITool(menuitem, menuitem.Visible, Nothing, menustrip, menustrip.Visible))
                    Next menuitem

                    Dim position As Integer = 3

                    For Each item As MergedUITool In m_currentMergedMenuItems
                        Me.MenuStrip1.Items.Insert(position, CType(item.Tool, ToolStripMenuItem))
                        position += 1
                    Next item

                    menustrip.Visible = False
                End If

                m_currentMergedForm = frm
            Else
                m_currentMergedForm = Nothing
            End If
        Else
            m_currentMergedForm = Nothing
        End If

        Me.ResumeLayout()

    End Sub

    Private Function GetRightmostPoint(ByVal toolStripPanel As ToolStripPanel, ByVal row As Integer) As Point

        Dim edge As Integer = toolStripPanel.RowMargin.Left

        For Each toolstrip As ToolStrip In toolStripPanel.Controls
            If toolstrip.Visible Then
                If toolStripPanel.PointToRow(toolstrip.Location) Is toolStripPanel.Rows(row) Then
                    If toolstrip.Right > edge Then
                        edge = toolstrip.Right
                    End If
                End If
            End If
        Next toolstrip

        Return New Point(edge, Me.ToolStripPanel1.Rows(row).Bounds.Top)

    End Function

    Private Sub RemoveMergedTools(Optional ByVal merging As Boolean = False)

        If Not merging Then
            Me.SuspendLayout()
        End If

        Dim currentMergedToolStripsClone As New List(Of MergedUITool)

        For Each item As MergedUITool In m_currentMergedToolStrips
            currentMergedToolStripsClone.Add(item)
        Next item

        Dim currentMergedMenuItemsClone As New List(Of MergedUITool)

        For Each item As MergedUITool In m_currentMergedMenuItems
            currentMergedMenuItemsClone.Add(item)
        Next item

        For Each item As MergedUITool In currentMergedToolStripsClone
            Dim toolstrip As ToolStrip = CType(item.Tool, ToolStrip)
            Dim originalparent As Control = CType(item.OriginalParent, Control)

            Dim removeHandled As Boolean = False

            If Not originalparent Is Nothing Then
                If Not originalparent.IsDisposed Then
                    If TypeOf originalparent Is ToolStripPanel Then
                        CType(originalparent, ToolStripPanel).Join(toolstrip, GetRightmostPoint(CType(originalparent, ToolStripPanel), 0))
                    Else
                        originalparent.Controls.Add(toolstrip)
                    End If

                    originalparent.Visible = False
                    'originalparent.Visible = item.OriginalParentVisibility
                    removeHandled = True
                End If
            End If

            If Not removeHandled Then
                If Me.ToolStripPanel1.Controls.Contains(toolstrip) Then
                    Me.ToolStripPanel1.Controls.Remove(toolstrip)
                End If
            End If

            m_currentMergedToolStrips.Remove(item)
        Next

        For Each item As MergedUITool In currentMergedMenuItemsClone
            Dim menuitem As ToolStripMenuItem = CType(item.Tool, ToolStripMenuItem)
            Dim originalparent As MenuStrip = CType(item.OriginalParent, MenuStrip)

            Dim removeHandled As Boolean = False

            If Not originalparent Is Nothing Then
                If Not originalparent.IsDisposed Then
                    originalparent.Items.Add(menuitem)

                    ' If originalparent.FindForm.MdiParent IsNot Me Then
                    'Stop
                    'End If
                    originalparent.Visible = False
                    'originalparent.Visible = item.OriginalParentVisibility
                    'menuitem.Visible = item.OriginalToolVisibility
                    removeHandled = True
                End If
            End If

            If Not removeHandled Then
                If Me.MenuStrip1.Items.Contains(menuitem) Then
                    Me.MenuStrip1.Items.Remove(menuitem)
                End If
            End If

            m_currentMergedMenuItems.Remove(item)
        Next item

        m_currentMergedForm = Nothing

        If Not merging Then
            Me.ResumeLayout()
        End If

    End Sub

    Private Sub NavRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavRefreshToolStripButton.Click, ViewRefreshToolStripMenuItem.Click

        PerformRefresh()

    End Sub

    Private Sub NavCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NavCancelToolStripButton.Click, ViewStopToolStripMenuItem.Click

        PerformRefreshCancel()

    End Sub

    Private Sub WindowManagerPanel1_WindowClosed(ByVal sender As Object, ByVal e As MDIWindowManager.WrappedWindowClosedEventArgs) Handles WindowManagerPanel1.WindowClosed

        RemoveWindowFromNavHistory(e.WrappedWindow.Window)

    End Sub

    Private Sub WindowManagerPanel1_WindowPoppingIn(ByVal sender As Object, ByVal e As MDIWindowManager.WrappedWindowCancelEventArgs) Handles WindowManagerPanel1.WindowPoppingIn

        If Not e.Cancel Then
            RestoreUIToolsForPoppedWindow(e.WrappedWindow.Window, False)
        End If

    End Sub

    Private Sub WindowManagerPanel1_WindowPoppingOut(ByVal sender As Object, ByVal e As MDIWindowManager.WrappedWindowCancelEventArgs) Handles WindowManagerPanel1.WindowPoppingOut

        If Not e.Cancel AndAlso TypeOf e.WrappedWindow.Window Is IApplicationExplorerAware Then
            Dim eventArgs As New System.ComponentModel.CancelEventArgs

            DirectCast(e.WrappedWindow.Window, IApplicationExplorerAware).OnWindowPopOut(eventArgs)

            If eventArgs.Cancel Then
                e.Cancel = True
                MsgBox(My.Resources.PopoutDisallowMessage)
            Else
                RemoveWindowFromNavHistory(e.WrappedWindow.Window)
                RestoreUIToolsForPoppedWindow(e.WrappedWindow.Window, True)
            End If
        Else
            RestoreUIToolsForPoppedWindow(e.WrappedWindow.Window, True)
        End If

    End Sub

    Private Sub ApplicationExplorerForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        'kludge: the assigned accelerator on Edit|FindNext doesn't always work. so this helps.
        If e.KeyCode = Keys.F3 Then
            e.Handled = True
            UpdateEditMenuItems()
            If Me.EditFindNextToolStripMenuItem.Enabled Then
                PerformFindNext()
            End If
        ElseIf e.KeyCode = Keys.F5 Then
            e.Handled = True
            UpdateEditMenuItems()
            If Me.ViewRefreshToolStripMenuItem.Enabled Then
                PerformRefresh()
            End If
        End If

    End Sub

#End Region

#Region "Event Handlers & Misc Code"

    Private Sub FileExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub FileCloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileCloseToolStripMenuItem.Click

        CloseCurrentWindow()

    End Sub

    Private Sub ViewToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.DropDownOpening

        UpdateShortcutsMenuItems()

        Me.ShowToolbarToolStripMenuItem.Checked = Me.ToolStripPanel1.Visible
        Me.ShowStatusBarToolStripMenuItem.Checked = Me.StatusStrip1.Visible
        Me.ShowShortcutBarToolStripMenuItem.Checked = Me.ShortcutBarSideMenu.Visible

    End Sub

    Private Sub EditToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.DropDownOpening

        UpdateEditMenuItems()

    End Sub

    Private Sub ShowToolbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolbarToolStripMenuItem.Click

        Me.ToolStripPanel1.Visible = Not Me.ToolStripPanel1.Visible

    End Sub

    Private Sub HelpAboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpAboutToolStripMenuItem.Click

        ShowHelpAboutDialog()

    End Sub

    Private Sub ShowStatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowStatusBarToolStripMenuItem.Click

        Me.StatusStrip1.Visible = Not Me.StatusStrip1.Visible

    End Sub

    Private Sub ShowShortcutBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowShortcutBarToolStripMenuItem.Click

        Me.ShortcutBarSplitter.Visible = Not Me.ShortcutBarSplitter.Visible
        Me.ShortcutBarSideMenu.Visible = Not Me.ShortcutBarSideMenu.Visible

    End Sub

    Private Sub ToolsOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsOptionsToolStripMenuItem.Click

        ShowOptionsDialog()

    End Sub

    Private Sub EditUndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUndoToolStripMenuItem.Click

        PerformEditUndo()

    End Sub

    Private Sub EditCutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditCutToolStripMenuItem.Click

        PerformEditCut()

    End Sub

    Private Sub EditCopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditCopyToolStripMenuItem.Click

        PerformEditCopy()

    End Sub

    Private Sub EditPasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditPasteToolStripMenuItem.Click

        PerformEditPaste()

    End Sub

    Private Sub EditFindToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditFindToolStripMenuItem.Click

        ShowEditFindDialog()

    End Sub

    Private Sub EditFindNextToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditFindNextToolStripMenuItem.Click

        PerformFindNext()

    End Sub

    Private Sub m_findForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_findForm.Activated

        If Not m_suppressIndicateControlOnFind Then

            Dim originalOpacity As Double = m_findForm.Opacity

            m_findForm.Opacity = 0.5
            m_findForm.Refresh()

            DrawingHelper.IndicateControl(GetActiveControlOrForm())

            m_findForm.Opacity = originalOpacity
        End If

    End Sub

    Private Sub m_findForm_FindNext() Handles m_findForm.FindNext

        PerformFindNext()

    End Sub

    Private Sub m_currentMergedForm_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_currentMergedForm.ParentChanged

        Dim frm As Form = CType(sender, Form)

        If Not frm.IsDisposed Then
            RestoreUIToolsForPoppedWindow(frm, Not (frm.MdiParent Is Me))
        End If

        Debug.WriteLine("ChildWindowParentChanged" + Now().ToString())

    End Sub

    Private Sub RestoreUIToolsForPoppedWindow(ByVal frm As Form, ByVal outside As Boolean)

        If Not frm.IsDisposed Then
            If TypeOf frm Is ICustomUIToolsCapable Then
                Dim customUIToolsCapableForm As ICustomUIToolsCapable = CType(frm, ICustomUIToolsCapable)
                Dim menustrip As MenuStrip = customUIToolsCapableForm.GetMenus()
                Dim toolstrippanel As ToolStripPanel = customUIToolsCapableForm.GetToolbars()

                If outside Then
                    If frm Is m_currentMergedForm Then
                        RemoveMergedTools()
                    End If
                    If Not menustrip Is Nothing Then
                        menustrip.Visible = True
                    End If
                    If Not toolstrippanel Is Nothing Then
                        toolstrippanel.Visible = True
                    End If
                Else
                    If frm Is m_currentMergedForm Then
                        RemoveMergedTools()
                    End If
                    If Not menustrip Is Nothing Then
                        menustrip.Visible = False
                    End If
                    If Not toolstrippanel Is Nothing Then
                        toolstrippanel.Visible = False
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub m_notifier_Notify(ByVal sender As Object, ByVal e As Notifier.NotifyEventArgs) Handles m_notifier.Notify

        If Not m_loading Then
            Dim sourceForm As Form

            If TypeOf e.Source Is Form Then
                sourceForm = DirectCast(e.Source, Form)
            End If

            Select Case e.Message
                Case Broadcasting.PredefinedMessages.CreateStatusStackItem
                    If Not e.Handled Then
                        If Not sourceForm Is Nothing AndAlso (IsMyChildForm(sourceForm) OrElse sourceForm Is Me) Then
                            m_statusStack.AddItem(DirectCast(e.Data, StatusStackItem))
                            e.Handled = True
                        End If
                    End If
                Case Broadcasting.PredefinedMessages.SetStatusProgress
                    If Not e.Handled Then
                        If Not sourceForm Is Nothing AndAlso (IsMyChildForm(sourceForm) OrElse sourceForm Is Me) Then
                            If TypeOf e.Data Is Boolean Then
                                SetStatusProgress(CBool(e.Data))
                            ElseIf TypeOf e.Data Is String Then
                                Dim values As String() = CStr(e.Data).Split(","c)
                                SetStatusProgress(CInt(values(0)), CInt(values(1)), CInt(values(2)))
                            End If
                        End If
                    End If
                Case Broadcasting.PredefinedMessages.SetStatusText
                    If Not e.Handled Then
                        If Not sourceForm Is Nothing AndAlso (IsMyChildForm(sourceForm) OrElse sourceForm Is Me) Then
                            SetStatusText(CStr(e.Data))
                        End If
                    End If
                Case Broadcasting.PredefinedMessages.UpdateCommands
                    If Not e.Handled Then
                        If Not sourceForm Is Nothing AndAlso (IsMyChildForm(sourceForm) OrElse sourceForm Is Me) Then
                            UpdateAllToolItems()
                            e.Handled = True
                        End If
                    End If
                Case Broadcasting.PredefinedMessages.OpenChild
                    If Not e.Handled Then
                        If Not sourceForm Is Nothing AndAlso (sourceForm.MdiParent Is Me OrElse sourceForm Is Me) Then
                            If Me.WindowState = FormWindowState.Minimized Then
                                Me.WindowState = FormWindowState.Normal
                            End If

                            Dim frm As Form = CType(e.Data, Form)

                            If m_uiMode <> UIMode.SingleViewBased Then
                                frm.MdiParent = Me
                            End If

                            frm.Show()

                            e.Handled = True
                        ElseIf Not sourceForm Is Nothing AndAlso Me.WindowManagerPanel1.IsWrappedWindowPoppedOut(Me.WindowManagerPanel1.GetWrapperForWindow(sourceForm)) Then
                            If Me.WindowState = FormWindowState.Minimized Then
                                Me.WindowState = FormWindowState.Normal
                            End If

                            Dim frm As Form = CType(e.Data, Form)

                            'Me.WindowManagerPanel1.PopOutWrappedWindow(Me.WindowManagerPanel1.GetWrapperForWindow(CType(e.Source, Form)))

                            If m_uiMode <> UIMode.SingleViewBased Then
                                frm.MdiParent = Me
                            End If

                            frm.Show()

                            Application.DoEvents()

                            Me.WindowManagerPanel1.PopOutWrappedWindow(Me.WindowManagerPanel1.GetWrapperForWindow(frm))

                            e.Handled = True
                        End If
                    End If
                Case "MDIMODECHANGED"
                    If My.Settings.ClassicMDI Then
                        If m_tdiMode Then
                            PrepForClassicMDI()
                        End If
                    Else
                        If Not m_tdiMode Then
                            PrepForTDI()
                        End If
                    End If
            End Select
        End If

    End Sub

    Private Sub m_statusStack_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_statusStack.CurrentItemChanged

        Dim item As StatusStackItem = m_statusStack.GetCurrentItem()

        If Not item Is Nothing Then
            If Me.ToolStripStatusLabel1.Text <> item.Message Then
                SetStatusText(item.Message, item.UseWaitCursor)
            End If

            If item.ProgressMin = -1 AndAlso item.ProgressMax = -1 AndAlso item.ProgressPosition = -1 Then
                SetStatusProgress(True)
            Else
                SetStatusProgress(item.ProgressMin, item.ProgressMax, item.ProgressPosition)
            End If
        Else
            SetStatusProgress(False)
            SetStatusText(String.Empty)
        End If

    End Sub

    Private Function IsMyChildForm(ByVal frm As Form) As Boolean

        Return (frm.MdiParent Is Me OrElse Me.WindowManagerPanel1.IsWrappedWindowPoppedOut(Me.WindowManagerPanel1.GetWrapperForWindow(frm)))

    End Function

#End Region

#Region "Commands"

    Private Sub SetWindowManagerOrientation(ByVal orientation As UIModeViewBasedOrientation)

        Select Case orientation
            Case UIModeViewBasedOrientation.Bottom
                'Auxiliary window (view) on top, child windows on the bottom
                Me.WindowManagerPanel1.Orientation = MDIWindowManager.WindowManagerOrientation.Bottom
                Me.WindowManagerPanel1.AutoHide = True
                Me.WindowManagerPanel1.ShowTitle = True
                Me.WindowManagerPanel1.Height = 42
                Me.WindowManagerPanel1.AllowUserVerticalRepositioning = True
                Me.WindowManagerPanel1.Top = CInt((Me.WindowManagerPanel1.GetMDIClientAreaBounds.Height / 3) * 2)
            Case UIModeViewBasedOrientation.Right
                'another common orientation:
                'the Outlook 2003 3-pane horizontal layout
                Me.WindowManagerPanel1.Orientation = MDIWindowManager.WindowManagerOrientation.Right
                Me.WindowManagerPanel1.AutoHide = False
                Me.WindowManagerPanel1.ShowTitle = True
                Me.WindowManagerPanel1.Height = 42
                Me.WindowManagerPanel1.AllowUserVerticalRepositioning = False
                Me.WindowManagerPanel1.Width = CInt((Me.WindowManagerPanel1.GetMDIClientAreaBounds.Width / 3) * 2)
                Me.WindowManagerPanel1.Top = Me.WindowManagerPanel1.GetMDIClientAreaBounds.Top
        End Select

    End Sub

    Public Sub HTileCurrentWindow()

        Me.WindowManagerPanel1.HTileWrappedWindow(Me.WindowManagerPanel1.GetActiveWindow())

    End Sub

    Public Sub TileCurrentWindow()

        Me.WindowManagerPanel1.TileWrappedWindow(Me.WindowManagerPanel1.GetActiveWindow())

    End Sub

    Public Sub PopOutCurrentWindow()

        Me.WindowManagerPanel1.PopOutWrappedWindow(Me.WindowManagerPanel1.GetActiveWindow())

    End Sub

    Public Sub CloseAllTabbedChildWindows()

        Me.WindowManagerPanel1.CloseAllWindows()

    End Sub

    Public Sub CloseAllWindows()

        For Each frm As Form In Me.MdiChildren
            frm.Close()
            frm.Dispose()
        Next frm

    End Sub

    Public Sub CloseCurrentWindow()

        Try
            If Not Me.WindowManagerPanel1.GetActiveWindow() Is Nothing Then
                Me.WindowManagerPanel1.UserCloseWindow(Me.WindowManagerPanel1.GetActiveWindow())
            End If
        Catch
            'do nothing
        End Try

    End Sub

    Public Sub ShowAllWindowsDialog()

        Me.WindowManagerPanel1.ShowAllWindowsDialog()

    End Sub

    Public Sub ShowHelpAboutDialog()

        Using dlg As New AboutForm
            dlg.ShowDialog(Me)
        End Using

    End Sub

    Public Sub ShowOptionsDialog()

        CommitVolatileSettings()

        Using dlg As New OptionsForm
            dlg.StartInComboBox.DataSource = Me.ShortcutBarSideMenu.Items
            dlg.TabbedWindowsCheckbox.Visible = (m_uiMode <> UIMode.SingleViewBased)

            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                UpdateVolatileSettings()
            End If
        End Using

    End Sub

    Public Sub PerformEditUndo()

        If TypeOf Me.ActiveMdiChild Is ICustomEditOperationsCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).WillHandleClipboardOperations Then
            CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).PerformUndo()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                Dim editHelper As New BasicEditHelper

                If editHelper.CanUndo(ctl) Then
                    editHelper.Undo(ctl)
                End If
            End If
        End If

    End Sub

    Public Sub PerformEditCut()

        If TypeOf Me.ActiveMdiChild Is ICustomEditOperationsCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).WillHandleClipboardOperations Then
            CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).PerformCut()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                Dim editHelper As New BasicEditHelper

                If editHelper.CanCut(ctl) Then
                    editHelper.Cut(ctl)
                End If
            End If
        End If

    End Sub

    Public Sub PerformEditCopy()

        If TypeOf Me.ActiveMdiChild Is ICustomEditOperationsCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).WillHandleClipboardOperations Then
            CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).PerformCopy()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                Dim editHelper As New BasicEditHelper

                If editHelper.CanCopy(ctl) Then
                    editHelper.Copy(ctl)
                End If
            End If
        End If

    End Sub

    Public Sub PerformEditPaste()

        If TypeOf Me.ActiveMdiChild Is ICustomEditOperationsCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).WillHandleClipboardOperations Then
            CType(Me.ActiveMdiChild, ICustomEditOperationsCapable).PerformPaste()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            If Not ctl Is Nothing Then
                Dim editHelper As New BasicEditHelper

                If editHelper.CanPaste(ctl) Then
                    editHelper.Paste(ctl)
                End If
            End If
        End If

    End Sub

    Public Sub PerformRefresh()

        Dim frm As Form

        If m_uiAllowToolMerging = UIToolMerging.All OrElse (m_uiAllowToolMerging = UIToolMerging.Auto AndAlso m_uiMode = UIMode.ChildrenOnlyBased) Then
            frm = Me.ActiveMdiChild
        ElseIf m_uiAllowToolMerging = UIToolMerging.Auto AndAlso (m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased) Then
            frm = Me.WindowManagerPanel1.AuxiliaryWindow
        End If

        If Not frm Is Nothing Then
            If TypeOf frm Is IRefreshCapable Then
                CType(frm, IRefreshCapable).PerformRefresh()
            End If
        End If

    End Sub

    Public Sub PerformRefreshCancel()

        Dim frm As Form

        If m_uiAllowToolMerging = UIToolMerging.All OrElse (m_uiAllowToolMerging = UIToolMerging.Auto AndAlso m_uiMode = UIMode.ChildrenOnlyBased) Then
            frm = Me.ActiveMdiChild
        ElseIf m_uiAllowToolMerging = UIToolMerging.Auto AndAlso (m_uiMode = UIMode.MultiViewBased OrElse m_uiMode = UIMode.SingleViewBased) Then
            frm = Me.WindowManagerPanel1.AuxiliaryWindow
        End If

        If Not frm Is Nothing Then
            If TypeOf frm Is IRefreshCapable Then
                CType(frm, IRefreshCapable).PerformRefreshCancel()
            End If
        End If

    End Sub

    Public Sub ShowEditFindDialog()

        If TypeOf Me.ActiveMdiChild Is ICustomEditFindCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditFindCapable).WillHandleFindOperations Then
            CType(Me.ActiveMdiChild, ICustomEditFindCapable).PerformFind()
        Else
            DrawingHelper.IndicateControl(GetActiveControlOrForm())

            m_findForm.SetBounds(Me.Left + 20, Me.Top + 20, 0, 0, BoundsSpecified.X Or BoundsSpecified.Y)

            If Not m_findForm.Visible Then
                m_findForm.CloseButton.Text = "Cancel"
            End If

            m_suppressIndicateControlOnFind = True

            Try
                Dim transparencyOption As FindForm.TransparencyOption = ApplicationExplorer.FindForm.TransparencyOption.WhenInactive 'CType(m_oEWWApplication.LocalSettings.GetObjectValue("View", "FindWindowTransparent", transparencyOption.WhenInactive), TransparencyOption)

                Select Case transparencyOption
                    Case transparencyOption.WhenInactive
                        m_findForm.AutoTransparent = True
                        m_findForm.Opacity = 1
                    Case transparencyOption.Never
                        m_findForm.AutoTransparent = False
                        m_findForm.Opacity = 1
                    Case transparencyOption.Always
                        m_findForm.AutoTransparent = False
                        m_findForm.Opacity = 0.8
                End Select

                m_findForm.Visible = True

                Try
                    m_findForm.Focus()
                    m_findForm.FindWhatComboBox.Focus()
                Catch
                    'do nothing
                End Try
            Catch
                'do nothing
            Finally
                m_suppressIndicateControlOnFind = False
            End Try
        End If

    End Sub

    Public Sub PerformFindNext(ByVal findWhat As String)

        m_findForm.FindWhatComboBox.Text = findWhat

        PerformFindNext()

    End Sub

    Public Sub PerformFindNext(ByVal findWhat As String, ByVal searchBackwards As Boolean, ByVal matchWholeWord As Boolean, ByVal caseSensitive As Boolean)

        m_findForm.FindWhatComboBox.Text = findWhat
        m_findForm.MatchWholeWordCheckBox.Checked = matchWholeWord
        m_findForm.MatchCaseCheckBox.Checked = caseSensitive

        If searchBackwards Then
            m_findForm.DirectionUpRadioButton.Checked = True
        Else
            m_findForm.DirectionDownRadioButton.Checked = True
        End If

        PerformFindNext()

    End Sub

    Public Sub PerformFindNext()

        If TypeOf Me.ActiveMdiChild Is ICustomEditFindCapable AndAlso CType(Me.ActiveMdiChild, ICustomEditFindCapable).WillHandleFindOperations Then
            CType(Me.ActiveMdiChild, ICustomEditFindCapable).PerformFindNext()
        Else
            Dim ctl As Control = GetActiveControlOrForm()

            Dim editHelper As New BasicEditHelper

            If editHelper.CanFind(ctl) Then
                Dim findText As String = m_findForm.FindWhatComboBox.Text

                If findText <> String.Empty Then
                    Dim searchBackwards As Boolean = (m_findForm.DirectionUpRadioButton.Checked = True)
                    Dim matchWholeWord As Boolean = (m_findForm.MatchWholeWordCheckBox.Checked = True)
                    Dim caseSensitive As Boolean = (m_findForm.MatchCaseCheckBox.Checked = True)

                    Dim findResult As BasicEditHelper.FindResult

                    findResult = editHelper.Find(ctl, findText, BasicEditHelper.FindStartFrom.[Auto], searchBackwards, matchWholeWord, caseSensitive)

                    If findResult = BasicEditHelper.FindResult.BOF Or findResult = BasicEditHelper.FindResult.EOF Then
                        Dim msgText As String = String.Empty
                        Dim findStartFrom As BasicEditHelper.FindStartFrom

                        Select Case findResult
                            Case BasicEditHelper.FindResult.BOF
                                msgText = "Continue searching from the end?"
                                findStartFrom = BasicEditHelper.FindStartFrom.[End]
                            Case BasicEditHelper.FindResult.EOF
                                msgText = "Continue searching from the top?"
                                findStartFrom = BasicEditHelper.FindStartFrom.Beginning
                        End Select

                        If MsgBox("Text not found. " + msgText, MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                            findResult = editHelper.Find(ctl, findText, findStartFrom, searchBackwards, matchWholeWord, caseSensitive)

                            If findResult = BasicEditHelper.FindResult.BOF Or findResult = BasicEditHelper.FindResult.EOF Then
                                MsgBox("Text not found.", MsgBoxStyle.Information)
                            End If
                        End If
                    End If

                    Try
                        ctl.Focus()
                    Catch

                    End Try

                    m_findForm.CloseButton.Text = "Close"
                End If
            Else
                MsgBox("The selected field or control is not searchable.", MsgBoxStyle.Exclamation)
            End If
        End If

    End Sub

    Public Sub PerformMoveBackInWindowHistory(Optional ByVal respectActiveWindowCapabilities As Boolean = True)

        If respectActiveWindowCapabilities Then
            PerformSmartNavHistoryWindowSwitch(-1)
        Else
            PerformNavHistoryWindowSwitch(-1)
        End If

    End Sub

    Public Sub PerformMoveForwardInWindowHistory(Optional ByVal respectActiveWindowCapabilities As Boolean = True)

        If respectActiveWindowCapabilities Then
            PerformSmartNavHistoryWindowSwitch(1)
        Else
            PerformNavHistoryWindowSwitch(1)
        End If

    End Sub

    Public Sub SetStatusText(ByVal text As String, Optional ByVal useWaitCursor As Boolean = False)

        If text <> String.Empty Then
            If text = StatusStackItem.GenericMessage Then
                Me.ToolStripStatusLabel1.Text = My.Resources.GenericBusyMessage
            Else
                Me.ToolStripStatusLabel1.Text = text
            End If

            If Application.UseWaitCursor <> useWaitCursor Then
                If useWaitCursor Then
                    Application.UseWaitCursor = True
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Else
                    Application.UseWaitCursor = False
                    System.Windows.Forms.Cursor.Current = Cursors.Default
                End If
            End If
        Else
            Me.ToolStripStatusLabel1.Text = My.Resources.GenericReadyMessage

            If Application.UseWaitCursor Then
                Application.UseWaitCursor = False
                System.Windows.Forms.Cursor.Current = Cursors.Default
            End If
        End If

        Me.StatusStrip1.Refresh()

    End Sub

    Public Sub SetStatusProgress(ByVal value As Boolean)

        If value Then
            SetProgressBarVisibility(True)
            Me.ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
            Me.ToolStripProgressBar1.Visible = True
        Else
            SetStatusProgress(0, 0, 0)
        End If

        Me.StatusStrip1.Refresh()

    End Sub

    Public Sub SetStatusProgress(ByVal min As Integer, ByVal max As Integer, ByVal current As Integer)

        With Me.ToolStripProgressBar1
            .Style = ProgressBarStyle.Blocks

            If current = 0 Then
                SetProgressBarVisibility(False)
                .Minimum = 0
                .Maximum = 0
                .Value = 0
            Else
                .Minimum = min
                .Maximum = max
                .Value = current
                SetProgressBarVisibility(True)
            End If
        End With

        Me.StatusStrip1.Refresh()

    End Sub

    Private Sub SetProgressBarVisibility(ByVal value As Boolean)

        'must do the StatusLabel trick when showing or hiding progressbar because of a layout bug in StatusTrip
        If value Then
            If Not Me.ToolStripProgressBar1.Visible Then
                Dim statusText As String = Me.ToolStripStatusLabel1.Text
                Me.ToolStripStatusLabel1.Text = String.Empty
                'I don't really like the way this looks
                'Me.ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right
                Me.ToolStripProgressBar1.Visible = True
                Me.ToolStripStatusLabel1.Text = statusText
            End If
        Else
            If Me.ToolStripProgressBar1.Visible Then
                Dim statusText As String = Me.ToolStripStatusLabel1.Text
                Me.ToolStripStatusLabel1.Text = String.Empty
                Me.ToolStripProgressBar1.Visible = False
                'Me.ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.None
                Me.ToolStripStatusLabel1.Text = statusText
            End If
        End If

    End Sub

    Public Sub SetTitlebarText(ByVal prefixText As String)

        Me.Text = prefixText + " - " + m_uiFormTitle

    End Sub

    Public Sub AddFileToMRU(ByVal file As String)

        Dim key As String = LCase(file)

        'If m_recentFileList.Contains(key) Then
        '    m_recentFileList.Remove(key)
        'End If

        My.Settings.MRU.Remove(key)
        My.Settings.MRU.Add(key, file)

        If My.Settings.MRU.Count > My.Settings.MRUStoreMax Then
            Dim count As Integer = My.Settings.MRU.Count - My.Settings.MRUStoreMax

            For tally As Integer = 1 To count
                My.Settings.MRU.Remove(My.Settings.MRU.Keys(0))
            Next tally
        End If

        UpdateMRUMenuItems()

    End Sub

#End Region

End Class