Public Class SampleForm_TextFileBrowser

    Private m_lastPath As String = String.Empty

    Private Sub SampleForm_TextFileBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RefreshFileList(My.Computer.FileSystem.SpecialDirectories.Desktop)

    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click

        RefreshFileList(PathTextBox.Text)

    End Sub

    Private Sub RefreshFileList(ByVal path As String)

        If My.Computer.FileSystem.DirectoryExists(path) Then
            Dim folders As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetDirectories(path)
            Dim files As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchTopLevelOnly, "*.txt", "*.log", "*.xml", "*.ini")

            FileListBox.Items.Clear()
            FileListBox.Items.Add("<..>")

            For Each folder As String In folders
                FileListBox.Items.Add("<" + My.Computer.FileSystem.GetName(folder) + ">")
            Next folder

            For Each file As String In files
                FileListBox.Items.Add(My.Computer.FileSystem.GetName(file))
            Next file

            m_lastPath = path
            PathTextBox.Text = path
        Else
            MsgBox("Path not found", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub FileListBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FileListBox.MouseDoubleClick

        If Not Me.FileListBox.SelectedItem Is Nothing Then
            Dim itemText As String = CStr(Me.FileListBox.SelectedItem)

            If itemText = "<..>" Then
                Dim dirInfo As System.IO.DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(m_lastPath)

                If Not dirInfo.Parent Is Nothing Then
                    RefreshFileList(dirInfo.Parent.FullName)
                End If
            ElseIf itemText.Substring(0, 1) = "<" Then
                RefreshFileList(System.IO.Path.Combine(m_lastPath, itemText.Replace("<"c, String.Empty).Replace(">"c, String.Empty)))
            Else
                Try
                    Dim text As String = My.Computer.FileSystem.ReadAllText(System.IO.Path.Combine(m_lastPath, itemText))
                    Dim frm As New SampleForm_TextViewer

                    frm.Text = itemText
                    frm.TextBox1.Text = text

                    Broadcasting.SendNotification(Me, BroadcastingCommonCodes.OPENCHILD, frm)
                Catch ex As Exception
                    MsgBox("Could not load file.", MsgBoxStyle.Critical)
                End Try
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        MsgBox("Display purposes only")

    End Sub

End Class