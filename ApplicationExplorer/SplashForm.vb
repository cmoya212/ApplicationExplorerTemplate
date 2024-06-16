''' <summary>
''' Splash form displayed during startup.
''' </summary>
''' <remarks>Used during app startup (see MyProject->Application).</remarks>
Public Class SplashForm

    Private Sub SplashForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ApplicationTitleLabel.Text = My.Application.Info.Title
        Me.ApplicationVersionLabel.Text = My.Resources.VersionLabel + " " + My.Application.Info.Version.ToString()

    End Sub

End Class