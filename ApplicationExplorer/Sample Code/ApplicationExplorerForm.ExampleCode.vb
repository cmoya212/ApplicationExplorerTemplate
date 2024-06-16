Partial Class ApplicationExplorerForm

    'Change SAMPLEMODE constant in Project Properties -> Compile Options to one of the 
    'following values to to run different examples.
    'None
    'ChildrenOnly
    'MultiView
    'MultiView2
    'SingleView

    'Please note: "My.Settings" User Settings are reset each time sample code runs. 
    'During normal runtime (SAMPLEMODE="None") user settings are saved when the app closes.

#Region "ChildrenOnly Example"

#If SAMPLEMODE = "ChildrenOnly" Then
    '----------------------------------------------------------------------------------------
    'ChildrenOnly mode is a simple pure tabbed mdi UI.

    Private m_uiFormTitle As String = My.Application.Info.Title
    Private m_uiMode As UIMode = UIMode.ChildrenOnlyBased
    Private m_uiAllowToolMerging As UIToolMerging = UIToolMerging.Auto
    Private m_uiAllowBuiltInToolbars As UIBuiltInToolbars = UIBuiltInToolbars.Navigation
    Private m_uiAllowShortcutBar As UIShortcutBar = UIShortcutBar.Auto
    Private m_uiShortcutBarAuxViewHandling As UIShortcutBarAuxViewHandling = UIShortcutBarAuxViewHandling.Auto
    Private m_auxViewForms As New List(Of Form)

    Private Sub InitializeSettings()

        'this should not be called during normal usage.
        My.Settings.Reset()

    End Sub

    Private Sub PerformOnFormLoadActions()

        'load up the intro child window
        Dim frm1 As New SampleForm_TextViewer
        frm1.Text = "Intro"
        frm1.TextBox1.Text = "See ""ApplicationExplorer Overview.doc"" for details about each type of UIMode available."
        frm1.MdiParent = Me
        frm1.Show()

        'load up another (more full-featured) child window for good measure
        Dim frm2 As New WebBrowserForm
        frm2.Text = "My Corporate Intranet"
        frm2.InitialUrl = "HOME"
        frm2.MdiParent = Me
        frm2.Show()

        'load up another (more full-featured) child window for good measure
        Dim frm3 As New SampleForm_PictureBrowser
        frm3.Text = "Image Browser"
        frm3.MdiParent = Me
        frm3.Show()

        frm1.BringToFront()

    End Sub

    Private Sub PerformOnShortcutBarSelectionChangeActions()

    End Sub

    Private Sub PerformOnChildWindowActivatedActions()

    End Sub

    Private Sub PerformOnFormClosingActions(ByVal e As System.Windows.Forms.FormClosingEventArgs)

    End Sub

    Private Sub PerformOnFormClosedActions(ByVal e As System.Windows.Forms.FormClosedEventArgs)

    End Sub

    '----------------------------------------------------------------------------------------
#End If

#End Region

#Region "MultiView Example"

#If SAMPLEMODE = "MultiView" Then
    '----------------------------------------------------------------------------------------
    'MultiView is an advanced 2 or 3 pane Master/Details or Outlook-esque 
    'style UI with a primary window presented as a "pane" and child windows 
    'opened at it's bottom or right side.

    Private m_uiFormTitle As String = My.Application.Info.Title
    Private m_uiMode As UIMode = UIMode.MultiViewBased
    Private m_uiAllowToolMerging As UIToolMerging = UIToolMerging.Auto
    Private m_uiAllowBuiltInToolbars As UIBuiltInToolbars = UIBuiltInToolbars.Navigation
    Private m_uiAllowShortcutBar As UIShortcutBar = UIShortcutBar.Auto
    Private m_uiShortcutBarAuxViewHandling As UIShortcutBarAuxViewHandling = UIShortcutBarAuxViewHandling.Auto
    Private m_auxViewForms As New List(Of Form)(New Form() {New SampleForm_PictureBrowser, New SampleForm_TextFileBrowser, New WebBrowserForm})

    Private Sub InitializeSettings()

        'this should not be called during normal usage.
        'My.Settings.Reset()

    End Sub

    Private Sub PerformOnFormLoadActions()

        'load up the intro child window
        Dim frm As New SampleForm_TextViewer
        frm.Text = "Intro"
        frm.TextBox1.Text = "See ""ApplicationExplorer Overview.doc"" for details about each type of UIMode available."
        frm.MdiParent = Me
        frm.Show()

        With CType(m_auxViewForms.Item(2), WebBrowserForm)
            .InitialUrl = "http://www.cflashsoft.com"
        End With

    End Sub

    Private Sub PerformOnShortcutBarSelectionChangeActions()

    End Sub

    Private Sub PerformOnChildWindowActivatedActions()

    End Sub

    Private Sub PerformOnFormClosingActions(ByVal e As System.Windows.Forms.FormClosingEventArgs)

    End Sub

    Private Sub PerformOnFormClosedActions(ByVal e As System.Windows.Forms.FormClosedEventArgs)

    End Sub

    '----------------------------------------------------------------------------------------
#End If

#End Region

#Region "MultiView Example 2"

#If SAMPLEMODE = "MultiView2" Then
    '----------------------------------------------------------------------------------------
    'Here we're trying to accomplish a mixture of MultiView and SingleView...
    'like a SingleView UI but with child windows.

    Private m_uiFormTitle As String = My.Application.Info.Title
    Private m_uiMode As UIMode = UIMode.MultiViewBased
    Private m_uiAllowToolMerging As UIToolMerging = UIToolMerging.Auto
    Private m_uiAllowBuiltInToolbars As UIBuiltInToolbars = UIBuiltInToolbars.FileOperations
    Private m_uiAllowShortcutBar As UIShortcutBar = UIShortcutBar.NotVisible
    Private m_auxViewForms As New List(Of Form)(New Form() {New SampleForm_PictureBrowser})

    Private Sub InitializeSettings()

        'this should not be called during normal usage.
        My.Settings.Reset()

    End Sub

    Private Sub PerformOnFormLoadActions()

        'for this sample, get rid of any shortcut bar items that may have been created at design-time
        Me.ShortcutBarSideMenu.Items.Clear()

        'load up the intro child window
        Dim frm As New SampleForm_TextViewer
        frm.Text = "Intro"
        frm.TextBox1.Text = "See ""ApplicationExplorer Overview.doc"" for details about each type of UIMode available."
        frm.MdiParent = Me
        frm.Show()

        'load up the single aux "view" window and hand it over to WindowManagerPanel
        Me.WindowManagerPanel1.AuxiliaryWindow = m_auxViewForms.Item(0)
        Me.HeaderTitleLabel.Text = m_auxViewForms.Item(0).Text
        m_auxViewForms.Item(0).Show()

    End Sub

    Private Sub PerformOnShortcutBarSelectionChangeActions()

    End Sub

    Private Sub PerformOnChildWindowActivatedActions()

    End Sub

    Private Sub PerformOnFormClosingActions(ByVal e As System.Windows.Forms.FormClosingEventArgs)

    End Sub

    Private Sub PerformOnFormClosedActions(ByVal e As System.Windows.Forms.FormClosedEventArgs)

    End Sub

    '----------------------------------------------------------------------------------------
#End If

#End Region

#Region "SingleView Example"

#If SAMPLEMODE = "SingleView" Then
    '----------------------------------------------------------------------------------------
    'SingleView mode is a simple single form or dialog-based UI but with all 
    'the built-in benefits of ApplicationExplorer.

    Private m_uiFormTitle As String = My.Application.Info.Title
    Private m_uiMode As UIMode = UIMode.SingleViewBased
    Private m_uiAllowToolMerging As UIToolMerging = UIToolMerging.Auto
    Private m_uiAllowBuiltInToolbars As UIBuiltInToolbars = UIBuiltInToolbars.FileOperations
    Private m_uiAllowShortcutBar As UIShortcutBar = UIShortcutBar.Auto
    Private m_auxViewForms As New List(Of Form)

    Private Sub InitializeSettings()

        'this should not be called during normal usage.
        My.Settings.Reset()

    End Sub

    Private Sub PerformOnFormLoadActions()

        'for this sample, get rid of any shortcut bar items that may have been created at design-time
        Me.ShortcutBarSideMenu.Items.Clear()

        'load up the single window and hand it over to WindowManagerPanel
        'Dim frm As New WebBrowserForm
        'frm.InitialUrl = "HOME"
        'Me.WindowManagerPanel1.AuxiliaryWindow = frm
        'frm.Show()

        Dim frm As New SampleForm_PictureBrowser
        Me.WindowManagerPanel1.AuxiliaryWindow = frm
        frm.Show()

        'this is normally called on the ShortcutBar's selected item change event... 
        'but since we're not using the shortcut bar, we need to call it manually.
        MergeChildTools()

    End Sub

    Private Sub PerformOnShortcutBarSelectionChangeActions()

    End Sub

    Private Sub PerformOnChildWindowActivatedActions()

    End Sub

    Private Sub PerformOnFormClosingActions(ByVal e As System.Windows.Forms.FormClosingEventArgs)

    End Sub

    Private Sub PerformOnFormClosedActions(ByVal e As System.Windows.Forms.FormClosedEventArgs)

    End Sub

    '----------------------------------------------------------------------------------------
#End If

#End Region

End Class