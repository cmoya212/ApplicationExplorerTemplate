Public Class SampleForm_PictureBrowser
    Implements ICustomUIToolsCapable

    Public Function GetMenus() As System.Windows.Forms.MenuStrip Implements ICustomUIToolsCapable.GetMenus

        Return Me.EntityMenuStrip

    End Function

    Public Function GetToolbars() As System.Windows.Forms.ToolStripPanel Implements ICustomUIToolsCapable.GetToolbars

        Return Me.EntityToolStripPanel

    End Function

    Public Function PreferUnclutteredView() As Boolean Implements ICustomUIToolsCapable.PreferUnclutteredView

    End Function

    Public Function PreferToolbarOnSecondRow() As Boolean Implements ICustomUIToolsCapable.PreferToolbarOnSecondRow

    End Function

    Private Sub AddImages()

        Dim dlg As New OpenFileDialog

        dlg.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.jpeg|All Files|*.*"
        dlg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures

        If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For Each file As String In dlg.FileNames
                Dim image As Image = System.Drawing.Image.FromFile(file)
                Me.ImageList1.Images.Add(image)
                Me.ListView1.Items.Add(System.IO.Path.GetFileName(file), Me.ImageList1.Images.Count - 1)
            Next file
        End If

        dlg.Dispose()

    End Sub

    Private Sub EditSelectedImages()

        For Each item As ListViewItem In Me.ListView1.SelectedItems
            Dim frm As New SampleForm_PictureViewer

            frm.Text = item.Text
            frm.PictureBox1.BackgroundImage = item.ImageList.Images(item.ImageIndex)

            Broadcasting.SendNotification(Me, BroadcastingCommonCodes.OPENCHILD, frm)
        Next item

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        EditSelectedImages()

    End Sub

    Private Sub DeleteSelectedImages()

        For Each item As ListViewItem In Me.ListView1.SelectedItems
            Me.ListView1.Items.Remove(item)
        Next item

    End Sub

    Private Sub AddEntityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEntityToolStripMenuItem.Click

        AddImages()

    End Sub

    Private Sub AddEntityToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEntityToolStripButton.Click

        AddImages()

    End Sub

    Private Sub EditEntityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditEntityToolStripMenuItem.Click

        EditSelectedImages()

    End Sub

    Private Sub EditEntityToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditEntityToolStripButton.Click

        EditSelectedImages()

    End Sub

    Private Sub DeleteEntityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteEntityToolStripMenuItem.Click

        DeleteSelectedImages()

    End Sub

    Private Sub DeleteEntityToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteEntityToolStripButton.Click

        DeleteSelectedImages()

    End Sub

End Class