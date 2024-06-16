''' <summary>
''' Form to collect settings options from the user.
''' </summary>
''' <remarks>Used by the Tools|Options menu item in ApplicationExplorerForm. 
''' Modify the code to add your own settings.</remarks>
Public Class OptionsForm

    Private Sub OptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ToolbarCheckBox.Checked = My.Settings.ShowToolbar
        Me.StatusBarCheckBox.Checked = My.Settings.ShowStatusBar
        Me.ShortcutBarCheckBox.Checked = My.Settings.ShowShortcutBar
        Me.TabbedWindowsCheckbox.Checked = Not My.Settings.ClassicMDI

        If Me.StartInComboBox.Items.Count > 0 Then
            Me.StartInComboBox.Enabled = True
            Me.StartInComboBox.SelectedIndex = My.Settings.StartInShortcutIndex
        Else
            Me.StartInComboBox.Enabled = False
            Me.StartInComboBox.SelectedIndex = -1
        End If

    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click

        My.Settings.ShowToolbar = Me.ToolbarCheckBox.Checked
        My.Settings.ShowStatusBar = Me.StatusBarCheckBox.Checked
        My.Settings.ShowShortcutBar = Me.ShortcutBarCheckBox.Checked
        My.Settings.StartInShortcutIndex = Me.StartInComboBox.SelectedIndex
        My.Settings.ClassicMDI = Not Me.TabbedWindowsCheckbox.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class