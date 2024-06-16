Public Class ClipboardCopyPrompt
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents optChoice1 As System.Windows.Forms.RadioButton
    Friend WithEvents optChoice2 As System.Windows.Forms.RadioButton
    Friend WithEvents lblCopy As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClipboardCopyPrompt))
        Me.optChoice1 = New System.Windows.Forms.RadioButton
        Me.optChoice2 = New System.Windows.Forms.RadioButton
        Me.lblCopy = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'optChoice1
        '
        resources.ApplyResources(Me.optChoice1, "optChoice1")
        Me.optChoice1.Name = "optChoice1"
        '
        'optChoice2
        '
        Me.optChoice2.Checked = True
        resources.ApplyResources(Me.optChoice2, "optChoice2")
        Me.optChoice2.Name = "optChoice2"
        Me.optChoice2.TabStop = True
        '
        'lblCopy
        '
        resources.ApplyResources(Me.lblCopy, "lblCopy")
        Me.lblCopy.Name = "lblCopy"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'ClipboardCopyPrompt
        '
        Me.AcceptButton = Me.btnOK
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblCopy)
        Me.Controls.Add(Me.optChoice2)
        Me.Controls.Add(Me.optChoice1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClipboardCopyPrompt"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Me.DialogResult = DialogResult.OK

    End Sub

End Class
