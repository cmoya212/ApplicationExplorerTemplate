''' <summary>
''' Intelligent Edit Commands Helper
''' </summary>
''' <remarks></remarks>
Public Class BasicEditHelper

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As IntPtr

    Public Enum EditFindDirection
        Down
        Up
    End Enum

    <Flags()> _
    Public Enum EditFindOptions
        MatchWholeWord = 2
        MatchCase = 4
    End Enum

    Public Enum FindStartFrom
        [Auto]
        Beginning
        [End]
    End Enum

    Public Enum FindResult
        BOF
        EOF
        OK
    End Enum

    Private m_sViablePropertiesAry As String() = {"SelectedItems", "SelectedItem", "SelectedValue", "SelectedText", "Value", "Text"}

    Public Property ViableProperties() As String()

        Get
            Return m_sViablePropertiesAry
        End Get

        Set(ByVal Value As String())
            m_sViablePropertiesAry = Value
        End Set

    End Property

    Public Sub Copy(ByVal ctl As Control)

        _Copy(ctl)

    End Sub

    Public Function CanCopy(ByVal ctl As Control) As Boolean

        Return _Copy(ctl, True)

    End Function

    Public Sub Cut(ByVal ctl As Control)

        _Cut(ctl)

    End Sub

    Public Function CanCut(ByVal ctl As Control) As Boolean

        Return _Cut(ctl, True)

    End Function

    Public Sub Paste(ByVal ctl As Control)

        _Paste(ctl)

    End Sub

    Public Function CanPaste(ByVal ctl As Control) As Boolean

        Return _Paste(ctl, True)

    End Function

    Public Sub Undo(ByVal ctl As Control)

        _Undo(ctl)

    End Sub

    Public Function CanUndo(ByVal ctl As Control) As Boolean

        Return _Undo(ctl, True)

    End Function

    Public Function CanFind(ByVal ctl As Control) As Boolean

        Return (_Find(ctl, String.Empty, FindStartFrom.[Auto], True) = FindResult.OK)

    End Function

    Public Function Find(ByVal ctl As Control, ByVal sFindText As String, ByVal iFindStartFrom As FindStartFrom, Optional ByVal bSearchBackwards As Boolean = False, Optional ByVal bMatchWholeWord As Boolean = False, Optional ByVal bCaseSensitive As Boolean = False) As FindResult

        Return _Find(ctl, sFindText, iFindStartFrom, False, bSearchBackwards, bMatchWholeWord, bCaseSensitive)

    End Function

    Private Function _Copy(ByVal ctl As Control, Optional ByVal bTestOnly As Boolean = False) As Boolean

        If TypeOf ctl Is TextBoxBase Then
            If SendMessage(ctl.Handle.ToInt32, &HD2, 0&, 0&).ToInt32 = 0 Then
                If Not bTestOnly Then
                    Dim txt As TextBoxBase = DirectCast(ctl, TextBoxBase)

                    If txt.SelectionLength = 0 Then
                        Clipboard.SetDataObject(txt.Text)
                    Else
                        txt.Copy()
                    End If
                End If

                Return True
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ComboBox Then
            If Not bTestOnly Then
                Dim cmb As ComboBox = DirectCast(ctl, ComboBox)

                If cmb.SelectionLength = 0 Then
                    Clipboard.SetDataObject(cmb.Text)
                Else
                    Clipboard.SetDataObject(cmb.SelectedText)
                End If
            End If

            Return True
        ElseIf TypeOf ctl Is ListBox Then
            Dim lst As ListBox = DirectCast(ctl, ListBox)

            If bTestOnly Then
                If lst.Items.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Dim iResult As Integer

                If lst.SelectedItems.Count > 0 Then
                    Dim dlg As New ClipboardCopyPrompt

                    If dlg.ShowDialog() = DialogResult.OK Then
                        If dlg.optChoice1.Checked Then
                            iResult = 2
                        ElseIf dlg.optChoice2.Checked Then
                            iResult = 1
                        Else
                            iResult = 1
                        End If
                    Else
                        iResult = 0
                    End If
                Else
                    iResult = 1
                End If

                Select Case iResult
                    Case 1, 2
                        Dim colItems As IEnumerable

                        Select Case iResult
                            Case 1
                                colItems = lst.Items
                            Case 2
                                colItems = lst.SelectedItems
                        End Select

                        Dim sb As New System.Text.StringBuilder

                        For Each o As Object In colItems
                            sb.Append(o.ToString() + vbCrLf)
                        Next o

                        Clipboard.SetDataObject(sb.ToString())

                        Return True
                    Case Else
                        Return False
                End Select
            End If
        ElseIf TypeOf ctl Is ListControl Then
            Dim lst As ListControl = DirectCast(ctl, ListControl)

            If Not lst.SelectedValue Is Nothing Then
                If Not bTestOnly Then
                    Clipboard.SetDataObject(lst.SelectedValue)
                End If

                Return True
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ListView Then
            Dim lvw As ListView = DirectCast(ctl, ListView)

            If bTestOnly Then
                If lvw.Items.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Dim iResult As Integer

                If lvw.SelectedItems.Count > 0 Then
                    Dim dlg As New ClipboardCopyPrompt

                    If dlg.ShowDialog() = DialogResult.OK Then
                        If dlg.optChoice1.Checked Then
                            iResult = 2
                        ElseIf dlg.optChoice2.Checked Then
                            iResult = 1
                        Else
                            iResult = 1
                        End If
                    Else
                        iResult = 0
                    End If
                Else
                    iResult = 1
                End If

                Select Case iResult
                    Case 1, 2
                        Dim colItems As IEnumerable

                        Select Case iResult
                            Case 1
                                colItems = lvw.Items
                            Case 2
                                colItems = lvw.SelectedItems
                        End Select

                        Dim sb As New System.Text.StringBuilder

                        For Each oItem As ListViewItem In colItems
                            For Each oSubItem As ListViewItem.ListViewSubItem In oItem.SubItems
                                sb.Append(oSubItem.Text + vbTab)
                            Next oSubItem

                            sb.Append(vbCrLf)
                        Next oItem

                        Clipboard.SetDataObject(sb.ToString())

                        Return True
                    Case Else
                        Return False
                End Select
            End If
        ElseIf TypeOf ctl Is TreeView Then
            'todo: add treeview capability here

            Return False
        ElseIf TypeOf ctl Is DateTimePicker Then
            Dim dtp As DateTimePicker = DirectCast(ctl, DateTimePicker)

            If Not bTestOnly Then
                Clipboard.SetDataObject(dtp.Value.ToString())
            End If

            Return True
        ElseIf TypeOf ctl Is ButtonBase Then
            If Not bTestOnly Then
                Clipboard.SetDataObject(ctl.Text)
            End If

            Return True
        ElseIf TypeOf ctl Is System.Windows.Forms.DataGrid Then
            'todo: figure out how to retrieve datagrid row data and whether datagrid supports multiselect

            'Dim grd As System.Windows.Forms.DataGrid = DirectCast(ctl, System.Windows.Forms.DataGrid)

            'If grd.IsSelected(0) Then
            '    grd.Item()
            'End If

            Return False
        Else
            If Not bTestOnly Then
                If ObjectContainsViableProperties(ctl) Then
                    Clipboard.SetDataObject(GetSelectedItemsTextFromUnknownObject(ctl))
                Else
                    SendMessage(ctl.Handle.ToInt32, &H301, 0&, 0&)
                End If
            End If

            Return True
        End If

    End Function

    Private Function _Cut(ByVal ctl As Control, Optional ByVal bTestOnly As Boolean = False) As Boolean

        If TypeOf ctl Is TextBoxBase Then
            If SendMessage(ctl.Handle.ToInt32, &HD2, 0&, 0&).ToInt32 = 0 Then
                Dim txt As TextBoxBase = DirectCast(ctl, TextBoxBase)

                If Not txt.[ReadOnly] Then
                    If txt.SelectionLength = 0 Then
                        Return False
                    Else
                        If Not bTestOnly Then
                            txt.Cut()
                        End If

                        Return True
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ComboBox Then
            Dim cmb As ComboBox = DirectCast(ctl, ComboBox)

            If Not cmb.DropDownStyle = ComboBoxStyle.DropDownList Then
                If cmb.SelectionLength = 0 Then
                    Return False
                Else
                    If Not bTestOnly Then
                        Clipboard.SetDataObject(cmb.SelectedText)
                        cmb.Text = String.Empty
                    End If

                    Return True
                End If
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ListBox Then
            Return False
        ElseIf TypeOf ctl Is ListControl Then
            Return False
        ElseIf TypeOf ctl Is ListView Then
            Return False
        ElseIf TypeOf ctl Is TreeView Then
            Return False
        ElseIf TypeOf ctl Is DateTimePicker Then
            Return False
        ElseIf TypeOf ctl Is ButtonBase Then
            Return False
        ElseIf TypeOf ctl Is System.Windows.Forms.DataGrid Then
            'todo: figure out how to retrieve datagrid row data and whether datagrid supports multiselect

            'Dim grd As System.Windows.Forms.DataGrid = DirectCast(ctl, System.Windows.Forms.DataGrid)

            'If grd.IsSelected(0) Then
            '    grd.Item()
            'End If

            Return False
        Else
            If Not bTestOnly Then
                SendMessage(ctl.Handle.ToInt32, &H300, 0&, 0&)
            End If

            Return True
        End If

    End Function

    Private Function _Paste(ByVal ctl As Control, Optional ByVal bTestOnly As Boolean = False) As Boolean

        If TypeOf ctl Is TextBoxBase Then
            Dim txt As TextBoxBase = DirectCast(ctl, TextBoxBase)

            If Not txt.[ReadOnly] AndAlso Clipboard.GetDataObject().GetDataPresent("System.String", True) Then
                If Not bTestOnly Then
                    txt.Paste()
                End If

                Return True
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ComboBox Then
            Dim cmb As ComboBox = DirectCast(ctl, ComboBox)

            If Not cmb.DropDownStyle = ComboBoxStyle.DropDownList AndAlso Clipboard.GetDataObject().GetDataPresent("System.String", True) Then
                If Not bTestOnly Then
                    If cmb.SelectionLength = 0 Then
                        cmb.Text = cmb.Text.Insert(cmb.SelectionStart, CStr(Clipboard.GetDataObject().GetData("System.String", True)))
                    Else
                        cmb.SelectedText = CStr(Clipboard.GetDataObject().GetData("System.String", True))
                    End If
                End If

                Return True
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ListBox Then
            Return False
        ElseIf TypeOf ctl Is ListControl Then
            Return False
        ElseIf TypeOf ctl Is ListView Then
            Return False
        ElseIf TypeOf ctl Is TreeView Then
            Return False
        ElseIf TypeOf ctl Is DateTimePicker Then
            Dim dtp As DateTimePicker = DirectCast(ctl, DateTimePicker)

            If Clipboard.GetDataObject().GetDataPresent("System.DateTime", True) Then
                If Not bTestOnly Then
                    dtp.Value = CDate(Clipboard.GetDataObject().GetData("System.DateTime", True))
                End If

                Return True
            ElseIf Clipboard.GetDataObject().GetDataPresent("System.String", True) Then
                If IsDate(Clipboard.GetDataObject().GetData("System.String", True)) Then
                    If Not bTestOnly Then
                        dtp.Value = CDate(Clipboard.GetDataObject().GetData("System.String", True))
                    End If

                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        ElseIf TypeOf ctl Is ButtonBase Then
            Return False
        ElseIf TypeOf ctl Is System.Windows.Forms.DataGrid Then
            'todo: figure out how to retrieve datagrid row data and whether datagrid supports multiselect

            'Dim grd As System.Windows.Forms.DataGrid = DirectCast(ctl, System.Windows.Forms.DataGrid)

            'If grd.IsSelected(0) Then
            '    grd.Item()
            'End If

            Return False
        Else
            If Not bTestOnly Then
                SendMessage(ctl.Handle.ToInt32, &H302, 0&, 0&)
            End If

            Return True
        End If

    End Function

    Public Function _Undo(ByVal ctl As Control, Optional ByVal bTestOnly As Boolean = False) As Boolean

        If TypeOf ctl Is TextBoxBase Then
            Dim txt As TextBoxBase = DirectCast(ctl, TextBoxBase)

            If txt.CanUndo Then
                If Not bTestOnly Then
                    txt.Undo()
                End If

                Return True
            Else
                Return False
            End If
        ElseIf ObjectContainsProperty(ctl, "CanUndo") Then
            Dim oPropertyInfo As System.Reflection.PropertyInfo = ctl.GetType.GetProperty("CanUndo")

            If Not oPropertyInfo Is Nothing Then
                Dim oResult As Object = ctl.GetType().InvokeMember("CanUndo", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing)

                If Not oResult Is Nothing Then
                    Try
                        If CBool(oResult) Then
                            If Not bTestOnly Then
                                Dim oMethodInfo As System.Reflection.MethodInfo = ctl.GetType.GetMethod("Undo")

                                If Not oMethodInfo Is Nothing Then
                                    ctl.GetType().InvokeMember("Undo", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.InvokeMethod, Nothing, ctl, Nothing)
                                End If
                            End If

                            Return True
                        Else
                            Return False
                        End If
                    Catch
                        Return False
                    End Try
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            If SendMessage(ctl.Handle.ToInt32, &HC6, 0&, 0&).ToInt32 <> 0 Then
                If Not bTestOnly Then
                    SendMessage(ctl.Handle.ToInt32, &H304, 0&, 0&)
                End If

                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Function _Find(ByVal ctl As Control, ByVal sFindText As String, ByVal iFindStartFrom As FindStartFrom, Optional ByVal bTestOnly As Boolean = False, Optional ByVal bSearchBackwards As Boolean = False, Optional ByVal bMatchWholeWord As Boolean = False, Optional ByVal bCaseSensitive As Boolean = False) As FindResult

        'we should really encapsulate this huge algorithm

        If Not ctl Is Nothing Then
            If (ObjectContainsProperty(ctl, "SelectionStart", True) AndAlso ObjectContainsProperty(ctl, "SelectionLength", True) AndAlso ObjectContainsProperty(ctl, "Text")) Then
                If TypeOf ctl Is TextBoxBase Then
                    If SendMessage(ctl.Handle.ToInt32, &HD2, 0&, 0&).ToInt32 <> 0 Then
                        Return FindResult.EOF
                    End If
                End If

                If Not bTestOnly Then
                    Dim oResult As Object

                    Dim sText As String = CStr(ctl.GetType().InvokeMember("Text", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing))

                    If sText <> String.Empty Then
                        Dim iSelectionStart As Integer = CInt(ctl.GetType().InvokeMember("SelectionStart", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing))
                        Dim iSelectionLength As Integer = CInt(ctl.GetType().InvokeMember("SelectionLength", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing))

                        Dim iFindStart As Integer

                        Select Case iFindStartFrom
                            Case FindStartFrom.[Auto]
                                If iSelectionLength > 0 Then
                                    If Not bSearchBackwards Then
                                        iFindStart = iSelectionStart + iSelectionLength
                                    Else
                                        iFindStart = iSelectionStart
                                    End If
                                Else
                                    iFindStart = iSelectionStart
                                End If
                            Case FindStartFrom.Beginning
                                iFindStart = 0
                            Case FindStartFrom.[End]
                                iFindStart = sText.Length - 1
                        End Select

                        Dim iCompareMethod As CompareMethod

                        If bCaseSensitive Then
                            iCompareMethod = CompareMethod.Binary
                        Else
                            iCompareMethod = CompareMethod.Text
                        End If

                        Dim iFoundPos As Integer

                        Dim bSearchAgain As Boolean = True

                        Do While bSearchAgain
                            If Not bSearchBackwards Then
                                iFoundPos = InStr(iFindStart + 1, sText, sFindText, iCompareMethod)
                            Else
                                If iFindStart = sText.Length Then
                                    iFindStart -= 1
                                End If

                                iFoundPos = InStrRev(sText, sFindText, iFindStart + 1, iCompareMethod)
                            End If

                            bSearchAgain = False

                            If iFoundPos > 0 Then
                                If bMatchWholeWord Then
                                    If Not IsWholeWord(sText, iFoundPos - 1, sFindText.Length) Then
                                        bSearchAgain = True
                                    End If

                                    If bSearchAgain Then
                                        If Not bSearchBackwards Then
                                            iFindStart = (iFoundPos - 1) + sFindText.Length
                                        Else
                                            iFindStart = iFoundPos - 2
                                        End If
                                    End If
                                End If

                                If Not bSearchAgain Then
                                    iFoundPos -= 1

                                    iSelectionStart = iFoundPos
                                    iSelectionLength = sFindText.Length

                                    ctl.GetType().InvokeMember("SelectionStart", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, ctl, New Object() {iSelectionStart})
                                    ctl.GetType().InvokeMember("SelectionLength", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, ctl, New Object() {iSelectionLength})

                                    Return FindResult.OK
                                End If
                            Else
                                If bSearchBackwards Then
                                    Return FindResult.BOF
                                Else
                                    Return FindResult.EOF
                                End If
                            End If
                        Loop
                    Else
                        If bSearchBackwards Then
                            Return FindResult.BOF
                        Else
                            Return FindResult.EOF
                        End If
                    End If
                End If

                Return FindResult.OK
            ElseIf ObjectContainsProperty(ctl, "Items") AndAlso (ObjectContainsProperty(ctl, "SelectedIndex", True) OrElse ObjectContainsProperty(ctl, "SelectedItem", True) OrElse ObjectContainsProperty(ctl, "SelectedItems")) Then
                Dim oResult As Object = ctl.GetType().InvokeMember("Items", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing)

                If TypeOf oResult Is IList Then
                    If Not bTestOnly Then
                        Dim iSelectMode As Integer

                        If ObjectContainsProperty(ctl, "SelectedIndex") Then
                            iSelectMode = 1
                        ElseIf ObjectContainsProperty(ctl, "SelectedItem") Then
                            iSelectMode = 2
                        ElseIf ObjectContainsProperty(ctl, "SelectedItems") Then
                            iSelectMode = 3
                        End If

                        Dim colItems As IList = CType(oResult, IList)

                        Dim oSelectedItem As Object     '1
                        Dim iSelectedIndex As Integer   '2
                        Dim colSelectedItems As IList   '3

                        Select Case iSelectMode
                            Case 1
                                iSelectedIndex = CInt(ctl.GetType().InvokeMember("SelectedIndex", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing))
                            Case 2
                                oSelectedItem = ctl.GetType().InvokeMember("SelectedIndex", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing)
                            Case 3
                                colSelectedItems = CType(ctl.GetType().InvokeMember("SelectedItems", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, ctl, Nothing), IList)
                        End Select

                        Dim iFindStart As Integer

                        Select Case iFindStartFrom
                            Case FindStartFrom.[Auto]
                                Select Case iSelectMode
                                    Case 1
                                        If iSelectedIndex >= 0 Then
                                            iFindStart = iSelectedIndex
                                        Else
                                            iFindStart = 0
                                        End If
                                    Case 2
                                        If Not oSelectedItem Is Nothing Then
                                            iFindStart = colItems.IndexOf(oSelectedItem)
                                        End If
                                    Case 3
                                        If colSelectedItems.Count > 0 Then
                                            iFindStart = colItems.IndexOf(colSelectedItems.Item(colSelectedItems.Count - 1))
                                        Else
                                            iFindStart = 0
                                        End If
                                End Select
                            Case FindStartFrom.Beginning
                                iFindStart = -1
                            Case FindStartFrom.[End]
                                iFindStart = colItems.Count
                        End Select

                        Dim iFindEnd As Integer
                        Dim iFindStep As Integer

                        If bSearchBackwards Then
                            iFindEnd = 0
                            iFindStart -= 1
                            iFindStep = -1

                            If iFindStart < 0 Then
                                Return FindResult.BOF
                            End If
                        Else
                            iFindStart += 1
                            iFindEnd = colItems.Count - 1
                            iFindStep = 1

                            If iFindStart > colItems.Count - 1 Then
                                Return FindResult.EOF
                            End If
                        End If

                        Dim iCompareMethod As CompareMethod

                        If bCaseSensitive Then
                            iCompareMethod = CompareMethod.Binary
                        Else
                            iCompareMethod = CompareMethod.Text
                        End If

                        For iPosX As Integer = iFindStart To iFindEnd Step iFindStep
                            Dim sText As String = ""
                            Dim oItem As Object = colItems.Item(iPosX)

                            If TypeOf oItem Is IEnumerable AndAlso Not TypeOf oItem Is System.String Then
                                Dim sb As New System.Text.StringBuilder

                                For Each oSubItem As Object In CType(oItem, IEnumerable)
                                    sb.Append(GetTextFromUnknownObject(oSubItem) + vbCrLf)
                                Next oSubItem

                                sText = sb.ToString()
                            ElseIf TypeOf oItem Is System.String Then
                                sText = CStr(oItem)
                            Else
                                sText = GetTextFromUnknownObject(oItem)
                            End If

                            If sText <> String.Empty Then
                                Dim bSearchAgain As Boolean = True
                                Dim iFindSubStart As Integer = 0

                                Do While bSearchAgain
                                    bSearchAgain = False

                                    If Not iFindSubStart < 0 Or iFindSubStart > sText.Length Then
                                        Dim iFoundPos As Integer = InStr(iFindSubStart + 1, sText, sFindText, iCompareMethod)

                                        If iFoundPos > 0 Then
                                            If bMatchWholeWord Then
                                                If Not IsWholeWord(sText, iFoundPos - 1, sFindText.Length) Then
                                                    iFindSubStart = (iFoundPos - 1) + sFindText.Length
                                                    bSearchAgain = True
                                                End If
                                            End If

                                            If Not bSearchAgain Then
                                                Select Case iSelectMode
                                                    Case 1
                                                        ctl.GetType().InvokeMember("SelectedIndex", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, ctl, New Object() {iPosX})
                                                        Return FindResult.OK
                                                    Case 2
                                                        ctl.GetType().InvokeMember("SelectedItem", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, ctl, New Object() {oItem})
                                                        Return FindResult.OK
                                                    Case 3
                                                        If Not CType(colSelectedItems, Object).GetType.GetMethod("Add") Is Nothing Then
                                                            colSelectedItems.Add(oItem)
                                                            Return FindResult.OK
                                                        ElseIf Not oItem.GetType.GetProperty("Selected") Is Nothing Then
                                                            oItem.GetType().InvokeMember("Selected", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, oItem, New Object() {True})
                                                            Return FindResult.OK
                                                        End If
                                                End Select
                                            End If
                                        End If
                                    End If
                                Loop
                            End If
                        Next iPosX

                        If bSearchBackwards Then
                            Return FindResult.BOF
                        Else
                            Return FindResult.EOF
                        End If
                    End If

                    Return FindResult.OK
                Else
                    Return FindResult.EOF
                End If
            Else
                Return FindResult.EOF
            End If
        Else
            Return FindResult.EOF
        End If

    End Function

    Public Function ObjectContainsViableProperties(ByVal obj As Object) As Boolean

        For Each sProperty As String In m_sViablePropertiesAry
            If ObjectContainsProperty(obj, sProperty) Then
                Return True
            End If
        Next sProperty

        Return False

    End Function

    Public Function GetSelectedItemsTextFromUnknownObject(ByVal obj As Object) As String

        For Each sProperty As String In m_sViablePropertiesAry
            If ObjectContainsProperty(obj, sProperty) Then
                Return GetPropertyValueTextFromUnknownObject(obj, sProperty)
            End If
        Next sProperty

        Return obj.ToString()

    End Function

    Public Function ObjectContainsProperty(ByVal obj As Object, ByVal prop As String, Optional ByVal bNotReadOnly As Boolean = False) As Boolean

        Try
            Dim oPropertyInfo As System.Reflection.PropertyInfo = obj.GetType().GetProperty(prop)

            If Not oPropertyInfo Is Nothing Then
                If Not bNotReadOnly Then
                    Return True
                Else
                    If oPropertyInfo.CanWrite Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        Catch
            Return False
        End Try

    End Function

    Public Function GetPropertyValueTextFromUnknownObject(ByVal obj As Object, ByVal prop As String) As String

        Dim oPropertyInfo As System.Reflection.PropertyInfo = obj.GetType().GetProperty(prop)

        If Not oPropertyInfo Is Nothing Then
            Dim oResult As Object = obj.GetType().InvokeMember(prop, System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, obj, Nothing)

            If TypeOf oResult Is IEnumerable And Not TypeOf oResult Is System.String Then
                Dim col As IEnumerable = CType(oResult, IEnumerable)
                Dim sb As New System.Text.StringBuilder

                For Each o As Object In col
                    sb.Append(GetTextFromUnknownObject(o) + vbCrLf)
                Next o

                Return sb.ToString()
            Else
                Return GetTextFromUnknownObject(oResult)
            End If
        Else
            Return GetTextFromUnknownObject(obj)
        End If

    End Function

    Public Function GetTextFromUnknownObject(ByVal obj As Object) As String

        Dim oResult As Object
        Dim oPropertyInfo As System.Reflection.PropertyInfo

        oPropertyInfo = obj.GetType.GetProperty("Text")

        If Not oPropertyInfo Is Nothing Then
            oResult = obj.GetType().InvokeMember("Text", System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.GetProperty, Nothing, obj, Nothing)

            If Not oResult Is Nothing Then
                Return oResult.ToString()
            Else
                Return obj.ToString()
            End If
        Else
            Return obj.ToString()
        End If

    End Function

    Public Function IsWholeWord(ByVal sText As String, ByVal iWordStart As Integer, ByVal iWordLength As Integer) As Boolean

        If Not iWordStart <= 0 Then
            If IsAlphaChar(sText.Chars(iWordStart - 1)) Then
                Return False
            End If
        End If

        If Not iWordStart + iWordLength >= sText.Length Then
            If IsAlphaChar(sText.Chars((iWordStart) + iWordLength)) Then
                Return False
            End If
        End If

        Return True

    End Function

    Public Function IsAlphaChar(ByVal c As Char) As Boolean

        Dim iAsciiCode As Integer = Asc(c)

        Return ((iAsciiCode >= 65 And iAsciiCode <= 90) Or (iAsciiCode >= 97 And iAsciiCode <= 122))

    End Function

End Class
