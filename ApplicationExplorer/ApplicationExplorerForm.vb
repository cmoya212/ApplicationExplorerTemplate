'Add all your custom code to this file. (See ApplicationExplorerForm.ExampleCode partial class for usage examples).

' *** NOTE: By default the sample mode constant in this source code may be set to
' *** a value meant to demonstrate the capabilities of ApplicationExplorerForm.
' *** Set SAMPLEMODE="None" in My Project -> Compile -> Advanced Compile Options to begin your work.  

''' <summary>
''' Full featured MDI parent frame for multiple types of applications.
''' </summary>
''' <remarks></remarks>
Public Class ApplicationExplorerForm

#If SAMPLEMODE = "None" Then

    '*** Modify these properties to customize ApplicationExplorerForm's look and feel and functionality. ***
    '*** Note: Other "Per-User" settings can be modified via MyProject->Settings. *** 

    ' Form's title if not the same as the Assembly's AppTitle.
    Private m_uiFormTitle As String = My.Application.Info.Title
    ' Most important setting... see documentation for more info.
    Private m_uiMode As UIMode = UIMode.ChildrenOnlyBased
    ' Determine which types of child windows will be inspected for ICustomUIToolsCapable.
    Private m_uiAllowToolMerging As UIToolMerging = UIToolMerging.Auto
    ' Determine which built-in toolbars to show.
    Private m_uiAllowBuiltInToolbars As UIBuiltInToolbars = UIBuiltInToolbars.Navigation

    ' Determine whether the shortcut bar (sidemenu) is displayed or not.
    Private m_uiAllowShortcutBar As UIShortcutBar = UIShortcutBar.Auto
    ' Determine whether shortcut bar clicks are handled internally using AuxViewForms.
    Private m_uiShortcutBarAuxViewHandling As UIShortcutBarAuxViewHandling = UIShortcutBarAuxViewHandling.Auto
    ' List of instantiated AuxViewForms (Master windows). (Applicable only for MultiView UIMode).
    Private m_auxViewForms As New List(Of Form)
    ' Note: m_auxViewForms must match the items created

    Private Sub PerformOnFormLoadActions()

        'Add code you would normally add to Form_Load here

        '' For MultiView UIMode normally you would want to do this at the end of this procedure
        'Me.ShortcutBarSideMenu.SelectedItemIndex = My.Settings.StartInShortcutIndex

    End Sub

    Private Sub PerformOnShortcutBarSelectionChangeActions()

        '' For MultiView UIMode, use this procedure to load up your master 
        '' window and hand it over to WindowManagerPanel Auxiliary Window property.

        '' Example:
        'If Me.ShortcutBarSideMenu.SelectedItemIndex <> -1 Then
        '    'hide the previews aux window if any
        '    If Not Me.WindowManager1.AuxiliaryWindow Is Nothing Then
        '        Me.WindowManager1.AuxiliaryWindow.Hide()
        '        Me.WindowManager1.AuxiliaryWindow = Nothing
        '    End If

        '    'get the aux window from our array and hand it over to the WindowManagerPanel
        '    Dim auxFrm As Form = m_auxViewForms.Item(Me.ShortcutBarSideMenu.SelectedItemIndex)
        '    Me.WindowManager1.AuxiliaryWindow = auxFrm
        '    auxFrm.Show()
        'Else
        '    'no item selected, get rid of the aux window
        '    If Not Me.WindowManager1.AuxiliaryWindow Is Nothing Then
        '        Me.WindowManager1.AuxiliaryWindow.Hide()
        '        Me.WindowManager1.AuxiliaryWindow = Nothing
        '    End If
        'End If

    End Sub

    Private Sub PerformOnChildWindowActivatedActions()

        'For all UIMode's, use this procedure to perform actions (if any)
        'when the user switches to a different child window.

    End Sub

    Private Sub PerformOnFormClosingActions(ByVal e As System.Windows.Forms.FormClosingEventArgs)

        'Enter any exit cleanup code here
        'This proc is called before ApplicationExplorer attempts to cleanup and close child windows

    End Sub

    Private Sub PerformOnFormClosedActions(ByVal e As System.Windows.Forms.FormClosedEventArgs)

        'Enter any exit cleanup code here

    End Sub

#End If

    Private Sub FileNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileNewToolStripMenuItem.Click

        'Add your FileNew work here

    End Sub

    Private Sub FileOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpenToolStripMenuItem.Click

        '' Example:
        'Using dlg As New OpenFileDialog
        '    dlg.Filter = "All Picture Files|*.bmp;*.gif|All Files|*.*"

        '    If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '        'add your code here

        '        AddFileToMRU(dlg.FileName)
        '    End If
        'End Using

        '' --- or ---

        '' transfer the work to one of the children:
        'Me.ActiveMdiChild.DoSomething() 'in ChildrenOnly mode
        '' or
        'Me.WindowManager1.AuxiliaryWindow.DoSomething 'in MultiView mode

    End Sub

    Private Sub FileSaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileSaveToolStripMenuItem.Click

        'Add your new FileSave work here

    End Sub

    Private Sub FileSaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileSaveAsToolStripMenuItem.Click

        'Add your new FileSaveAs work here

    End Sub

    Private Sub HandleMRUFileSelect(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim menuitem As MRUToolStripMenuItem = CType(sender, MRUToolStripMenuItem)

        '' do something with
        'menuitem.File

    End Sub

    Private Sub HelpTopicsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpTopicsToolStripMenuItem.Click

        '' Add your Help Topics work here
        '' Example:
        'Process.Start("http://www.mysite.com/mydocumentation/")
        'or
        'otherwise launch your documentation file

    End Sub

    Private Sub FileNewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileNewToolStripButton.Click

        'See corresponding MenuItem_Click

    End Sub

    Private Sub FileOpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpenToolStripButton.Click

        'See corresponding MenuItem_Click

    End Sub

    Private Sub FileSaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileSaveToolStripButton.Click

        'See corresponding MenuItem_Click

    End Sub

End Class