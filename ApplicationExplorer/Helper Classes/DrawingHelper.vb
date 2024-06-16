Public Class DrawingHelper

    Public Shared Sub IndicateControl(ByVal ctl As Control)

        If Not ctl Is Nothing Then
            Dim iDelay As Integer = 50

            If Not ctl.Parent Is Nothing Then
                Dim rect As Rectangle = ctl.Parent.RectangleToScreen(ctl.Bounds)

                For x As Integer = 1 To 6
                    ControlPaint.DrawReversibleFrame(rect, Color.Black, FrameStyle.Thick)
                    Threading.Thread.Sleep(iDelay)
                Next x
            End If
        End If

    End Sub

    Private Declare Auto Function PathCompactPathEx Lib "shlwapi.dll" (ByVal pszOut As String, ByVal pszSrc As String, ByVal cchMax As Integer, ByVal dwFlags As Integer) As Boolean

    Public Shared Function PathCompactPath(ByVal path As String, Optional ByVal maxChars As Integer = 34) As String

        Dim newPath As String = New String(" "c, maxChars)

        PathCompactPathEx(newPath, path, newPath.Length, 0)

        Return newPath.Trim(ChrW(0))

    End Function

End Class
