''' <summary>
''' Form to collect login credentials from the user.
''' </summary>
''' <remarks>Can be used in the MyApplication_Startup event of ApplicationEvents.vb.</remarks>
Public Class LoginForm

    Private Sub LoginForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Text = "Login - " + My.Application.Info.Title

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class