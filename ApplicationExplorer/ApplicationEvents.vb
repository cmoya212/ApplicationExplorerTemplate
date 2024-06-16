Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            WaitForSplashScreenCreation()

            ''Use the following code to display a login form
            'If Not IsStartupValid() Then
            '    If Not Me.SplashScreen Is Nothing Then
            '        Me.HideSplashScreen()
            '    End If

            '    e.Cancel = True
            'End If

        End Sub

        'Use the following code to display a login form
        Private Function IsStartupValid() As Boolean

            'Dim result As Boolean

            'Using dlg As New LoginForm
            '    dlg.ShowInTaskbar = True
            '    dlg.StartPosition = FormStartPosition.CenterScreen
            '    dlg.TopMost = True

            '    If dlg.ShowDialog() = DialogResult.OK Then
            '        'add your validation code here 
            '        'check login and cancel out if necessesary.
            '        result = True
            '    Else
            '        result = False
            '    End If
            'End Using

            'Return result

        End Function

        Private Sub WaitForSplashScreenCreation()

            If Not Me.SplashScreen Is Nothing Then
                While Not Me.SplashScreen.IsHandleCreated
                    System.Threading.Thread.Sleep(100)
                End While
            End If

        End Sub

    End Class

End Namespace

