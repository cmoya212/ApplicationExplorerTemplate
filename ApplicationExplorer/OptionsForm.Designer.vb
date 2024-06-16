<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TabbedWindowsCheckbox = New System.Windows.Forms.CheckBox
        Me.StartInLabel = New System.Windows.Forms.Label
        Me.StartInComboBox = New System.Windows.Forms.ComboBox
        Me.ShortcutBarCheckBox = New System.Windows.Forms.CheckBox
        Me.StatusBarCheckBox = New System.Windows.Forms.CheckBox
        Me.ToolbarCheckBox = New System.Windows.Forms.CheckBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.OkButton = New System.Windows.Forms.Button
        Me.CloseButton = New System.Windows.Forms.Button
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabbedWindowsCheckbox)
        Me.GroupBox1.Controls.Add(Me.StartInLabel)
        Me.GroupBox1.Controls.Add(Me.StartInComboBox)
        Me.GroupBox1.Controls.Add(Me.ShortcutBarCheckBox)
        Me.GroupBox1.Controls.Add(Me.StatusBarCheckBox)
        Me.GroupBox1.Controls.Add(Me.ToolbarCheckBox)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'TabbedWindowsCheckbox
        '
        resources.ApplyResources(Me.TabbedWindowsCheckbox, "TabbedWindowsCheckbox")
        Me.TabbedWindowsCheckbox.Name = "TabbedWindowsCheckbox"
        Me.TabbedWindowsCheckbox.UseVisualStyleBackColor = True
        '
        'StartInLabel
        '
        resources.ApplyResources(Me.StartInLabel, "StartInLabel")
        Me.StartInLabel.Name = "StartInLabel"
        '
        'StartInComboBox
        '
        Me.StartInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StartInComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.StartInComboBox, "StartInComboBox")
        Me.StartInComboBox.Name = "StartInComboBox"
        '
        'ShortcutBarCheckBox
        '
        resources.ApplyResources(Me.ShortcutBarCheckBox, "ShortcutBarCheckBox")
        Me.ShortcutBarCheckBox.Name = "ShortcutBarCheckBox"
        Me.ShortcutBarCheckBox.UseVisualStyleBackColor = True
        '
        'StatusBarCheckBox
        '
        resources.ApplyResources(Me.StatusBarCheckBox, "StatusBarCheckBox")
        Me.StatusBarCheckBox.Name = "StatusBarCheckBox"
        Me.StatusBarCheckBox.UseVisualStyleBackColor = True
        '
        'ToolbarCheckBox
        '
        resources.ApplyResources(Me.ToolbarCheckBox, "ToolbarCheckBox")
        Me.ToolbarCheckBox.Name = "ToolbarCheckBox"
        Me.ToolbarCheckBox.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'OkButton
        '
        resources.ApplyResources(Me.OkButton, "OkButton")
        Me.OkButton.Name = "OkButton"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'OptionsForm
        '
        Me.AcceptButton = Me.OkButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelButton
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsForm"
        Me.ShowInTaskbar = False
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolbarCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShortcutBarCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StatusBarCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents StartInLabel As System.Windows.Forms.Label
    Friend WithEvents StartInComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TabbedWindowsCheckbox As System.Windows.Forms.CheckBox
End Class
