Public Class FindForm
    Inherits System.Windows.Forms.Form

    Public Event FindNext()

    Public Enum TransparencyOption
        Never = 0
        WhenInactive = 1
        Always = 2
    End Enum

    Private m_isFindNextClicked As Boolean = False
    Private m_autoTransparent As Boolean
    Private m_allowClose As Boolean

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
    Friend WithEvents FindWhatLabel As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DirectionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MatchWholeWordCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MatchCaseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents DirectionDownRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DirectionUpRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents FindWhatComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CloseOnFindCheckBox As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindForm))
        Me.FindWhatLabel = New System.Windows.Forms.Label
        Me.FindWhatComboBox = New System.Windows.Forms.ComboBox
        Me.OkButton = New System.Windows.Forms.Button
        Me.CloseButton = New System.Windows.Forms.Button
        Me.MatchWholeWordCheckBox = New System.Windows.Forms.CheckBox
        Me.MatchCaseCheckBox = New System.Windows.Forms.CheckBox
        Me.DirectionGroupBox = New System.Windows.Forms.GroupBox
        Me.DirectionDownRadioButton = New System.Windows.Forms.RadioButton
        Me.DirectionUpRadioButton = New System.Windows.Forms.RadioButton
        Me.CloseOnFindCheckBox = New System.Windows.Forms.CheckBox
        Me.DirectionGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'FindWhatLabel
        '
        resources.ApplyResources(Me.FindWhatLabel, "FindWhatLabel")
        Me.FindWhatLabel.Name = "FindWhatLabel"
        '
        'FindWhatComboBox
        '
        resources.ApplyResources(Me.FindWhatComboBox, "FindWhatComboBox")
        Me.FindWhatComboBox.Name = "FindWhatComboBox"
        '
        'OkButton
        '
        resources.ApplyResources(Me.OkButton, "OkButton")
        Me.OkButton.Name = "OkButton"
        '
        'CloseButton
        '
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.Name = "CloseButton"
        '
        'MatchWholeWordCheckBox
        '
        resources.ApplyResources(Me.MatchWholeWordCheckBox, "MatchWholeWordCheckBox")
        Me.MatchWholeWordCheckBox.Name = "MatchWholeWordCheckBox"
        '
        'MatchCaseCheckBox
        '
        resources.ApplyResources(Me.MatchCaseCheckBox, "MatchCaseCheckBox")
        Me.MatchCaseCheckBox.Name = "MatchCaseCheckBox"
        '
        'DirectionGroupBox
        '
        Me.DirectionGroupBox.Controls.Add(Me.DirectionDownRadioButton)
        Me.DirectionGroupBox.Controls.Add(Me.DirectionUpRadioButton)
        resources.ApplyResources(Me.DirectionGroupBox, "DirectionGroupBox")
        Me.DirectionGroupBox.Name = "DirectionGroupBox"
        Me.DirectionGroupBox.TabStop = False
        '
        'DirectionDownRadioButton
        '
        Me.DirectionDownRadioButton.Checked = True
        resources.ApplyResources(Me.DirectionDownRadioButton, "DirectionDownRadioButton")
        Me.DirectionDownRadioButton.Name = "DirectionDownRadioButton"
        Me.DirectionDownRadioButton.TabStop = True
        '
        'DirectionUpRadioButton
        '
        resources.ApplyResources(Me.DirectionUpRadioButton, "DirectionUpRadioButton")
        Me.DirectionUpRadioButton.Name = "DirectionUpRadioButton"
        '
        'CloseOnFindCheckBox
        '
        Me.CloseOnFindCheckBox.Checked = True
        Me.CloseOnFindCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.CloseOnFindCheckBox, "CloseOnFindCheckBox")
        Me.CloseOnFindCheckBox.Name = "CloseOnFindCheckBox"
        '
        'FindForm
        '
        Me.AcceptButton = Me.OkButton
        resources.ApplyResources(Me, "$this")
        Me.CancelButton = Me.CloseButton
        Me.Controls.Add(Me.CloseOnFindCheckBox)
        Me.Controls.Add(Me.DirectionGroupBox)
        Me.Controls.Add(Me.MatchCaseCheckBox)
        Me.Controls.Add(Me.MatchWholeWordCheckBox)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.FindWhatComboBox)
        Me.Controls.Add(Me.FindWhatLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindForm"
        Me.ShowInTaskbar = False
        Me.DirectionGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property AutoTransparent() As Boolean

        Get
            Return m_autoTransparent
        End Get

        Set(ByVal value As Boolean)
            m_autoTransparent = Value
        End Set

    End Property

    Public Property AllowClose() As Boolean

        Get
            Return m_allowClose
        End Get

        Set(ByVal value As Boolean)
            m_allowClose = Value
        End Set

    End Property

    Private Sub FindForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not m_allowClose Then
            e.Cancel = True
            Me.Visible = False

            If Not m_isFindNextClicked Then
                Me.FindWhatComboBox.Text = String.Empty
            End If
        End If

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click

        Me.Close()

    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click

        Dim findText As String = Me.FindWhatComboBox.Text

        If findText <> String.Empty Then
            Dim insertIntoHistory As Boolean = True

            If Me.FindWhatComboBox.Items.Count > 0 Then
                For index As Integer = 0 To Me.FindWhatComboBox.Items.Count - 1
                    Dim tempFindText As String = CStr(Me.FindWhatComboBox.Items.Item(index))

                    If StrComp(tempFindText, findText, CompareMethod.Text) = 0 Then
                        If Not index = 0 Then
                            Me.FindWhatComboBox.Items.RemoveAt(index)
                            insertIntoHistory = True
                            Exit For
                        Else
                            insertIntoHistory = False
                            Exit For
                        End If
                    End If
                Next index
            End If

            If insertIntoHistory Then
                Me.FindWhatComboBox.Items.Insert(0, findText)
            End If

            If Me.FindWhatComboBox.Items.Count = 21 Then
                Me.FindWhatComboBox.Items.RemoveAt(20)
            End If

            Me.FindWhatComboBox.Text = findText

            RaiseEvent FindNext()

            m_isFindNextClicked = True

            If Me.CloseOnFindCheckBox.Checked Then
                Me.Close()
            End If
        End If

    End Sub

    Private Sub FindForm_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible Then
            m_isFindNextClicked = False
        End If

    End Sub

    Private Sub FindForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        If m_autoTransparent Then
            Me.Opacity = 1
        End If

    End Sub

    Private Sub FindForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate

        If m_autoTransparent Then
            Me.Opacity = 0.8
        End If

    End Sub

End Class
