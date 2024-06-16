Public Class MenuStripEx
    Inherits System.Windows.Forms.MenuStrip

    Protected Overrides Sub OnItemAdded(ByVal e As System.Windows.Forms.ToolStripItemEventArgs)

        MyBase.OnItemAdded(e)
        PerformSmartHide()

    End Sub

    Protected Overrides Sub OnItemRemoved(ByVal e As System.Windows.Forms.ToolStripItemEventArgs)

        MyBase.OnItemRemoved(e)
        PerformSmartHide()

    End Sub

    Protected Overrides Sub OnCreateControl()

        MyBase.OnCreateControl()
        PerformSmartHide()

    End Sub

    Private Sub PerformSmartHide()

        'Maybe(I) 'm missing something but I couldn't find a way to make an empty menustrip
        Me.Visible = (Me.Items.Count > 0)

    End Sub

End Class
