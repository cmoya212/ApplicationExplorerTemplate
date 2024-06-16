''' <summary>
''' AboutBox Form.
''' </summary>
''' <remarks>Used by the built-in Help|About menu item of ApplicationExplorerForm.</remarks>
Public Class AboutForm

    Private m_systemInfoToolPath As String = String.Empty

    Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            m_systemInfoToolPath = CStr(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Shared Tools\MSINFO", "Path", String.Empty))
        Catch
            'do nothing
        End Try

        Me.SystemInfoButton.Enabled = (m_systemInfoToolPath <> String.Empty)
        Me.SystemInfoButton.Visible = (m_systemInfoToolPath <> String.Empty)

        Me.Text = My.Resources.AboutLabel + " " + My.Application.Info.Title
        Me.ApplicationIconPictureBox.Image = My.Resources.ApplicationIcon.ToBitmap()
        Me.CompanyNameLabel.Text = My.Application.Info.CompanyName
        Me.ApplicationTitleLabel.Text = My.Application.Info.Title
        Me.ApplicationVersionLabel.Text = My.Resources.VersionLabel + ": " + My.Application.Info.Version.ToString()
        Me.ApplicationCopyrightLabel.Text = My.Application.Info.Copyright

        FillApplicationDetailsBox()

    End Sub

    Private Sub FillApplicationDetailsBox()

        Dim sb As New System.Text.StringBuilder

        With sb
            'modify this to add your own details
            .AppendLine("(No Details)")
        End With

        Me.ApplicationDetailsTextBox.Text = sb.ToString()

    End Sub

    Private Sub SystemInfoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoButton.Click

        Process.Start(m_systemInfoToolPath)

    End Sub

    Private Sub CompanyNameLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles CompanyNameLabel.LinkClicked

        If My.Settings.AboutHomePageUrl.Trim() <> String.Empty Then
            Try
                Process.Start(My.Settings.AboutHomePageUrl)
            Catch
                'do nothing
            End Try
        End If

    End Sub

    Private Sub AppExploreInfoLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles AppExploreInfoLinkLabel.LinkClicked

        MsgBox("Portions of this program based on the ApplicationExplorer project by C-Flash Software. Copyright © C-Flash Software 2006.")

    End Sub

End Class