#Region "imports"
Imports System.Windows
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Web
Imports Microsoft.VisualBasic.Strings
Imports System.Math
Imports System.Object
Imports System.Threading
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Globalization
#End Region



Public Class frmMain
    Dim info_string_length As Integer = 0
    Dim hash_count As Integer = 0
    Dim file_size As Integer = 0
    Dim delta As Integer = 0
    Dim os_string_sec_length As Integer = 0
    Dim magic As Integer
    Dim info_index_offset As Integer
    Dim hash_index_offset As Integer
    Dim info_index_count As Integer
    Dim info_index_string_index As Integer

    Private Sub m_open_Click(sender As Object, e As EventArgs) Handles m_open.Click
        Dim p As String = My.Settings.path
        delta = 0 ' reset to ZERO!
        Dim index_os, index_tl, index_info As ULong
        Dim cp As ULong
        Dim enc As New System.Text.ASCIIEncoding

        OpenFile.InitialDirectory = p
        If Not OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return
        End If
        My.Settings.path = OpenFile.FileName
        Dim file_path = OpenFile.FileName
        Dim data() = System.IO.File.ReadAllBytes(file_path)
        file_size = data.Length
        If file_path.Contains(".mo_BU") Then
            file_path = file_path.Replace("mo_BU", "mo")
        Else
            If Not IO.File.Exists(file_path + "_BU") Then
                System.IO.File.WriteAllBytes(file_path + "_BU", data)
            End If
        End If
        OpenFile.FileName = file_path
        Dim ms As New MemoryStream(data)
        Dim br As New BinaryReader(ms)
        ms.Position = 0
        magic = br.ReadInt32
        If magic <> &H950412DE Then
            MsgBox("This file is NOT a WoT MO file. Magic number is wrong!", MsgBoxStyle.Exclamation, "Opps")
            Return
        End If

        Dim version = br.ReadInt32
        count = br.ReadInt32
        Dim os_index_start As ULong = br.ReadInt32 'always = 28?
        index_info = br.ReadInt32()
        info_index_offset = index_info

        hash_count = br.ReadUInt32

        Dim index_hash = br.ReadUInt32
        hash_index_offset = index_hash

        Dim unknown3 = br.ReadUInt32
        Dim n_data() As Byte
        'make room for the data
        ReDim os_strings(count)
        ReDim trans_strings(count)
        ReDim trans_strings_raw(count)
        ReDim trans_flags(count)
        ReDim trans_indices(count)
        ReDim os_indices(count)
        ReDim hash_tbl(hash_count)
        ReDim hash_indices(hash_count)
        'get hash table
        ms.Position = index_hash
        For i = 0 To hash_count - 1
            hash_tbl(i) = br.ReadInt32
        Next
        cp = os_index_start 'save .. we need it for loop
        For i = 0 To count - 1
            ms.Position = cp 'restore position
            Dim s_length = br.ReadInt32
            os_string_sec_length += s_length

            index_os = br.ReadInt32
            os_indices(i) = New indice_
            os_indices(i).len = s_length
            os_indices(i).offset = index_os

            ReDim n_data(s_length)
            cp = ms.Position
            ms.Position = index_os
            ReDim n_data(s_length)
            n_data = br.ReadBytes(s_length)
            os_strings(i) = enc.GetString(n_data)
        Next
        index_tl = br.ReadInt32
        ms.Position = index_info ' point at project info index
        info_string_length = br.ReadInt32 ' get project string length
        info_index_count = info_string_length

        index_info = br.ReadInt32 ' get start of project string
        info_index_string_index = index_info

        Dim trans_index = ms.Position ' save start of trans string indexes which is next
        ms.Position = index_info ' move to where project string is stored

        ReDim n_data(info_string_length) 'make room
        n_data = br.ReadBytes(info_string_length) ' read project info
        info_string = enc.GetString(n_data) ' convert to string
        Dim trans_strings_start = ms.Position  ' save start of trans strings - not used.. debug only
        cp = trans_index 'save for loop
        'get trans strings
        For i = 0 To count - 1
            ms.Position = cp 'restore position
            Dim s_length = br.ReadInt32
            index_os = br.ReadInt32

            trans_indices(i) = New indice_
            trans_indices(i).len = s_length
            trans_indices(i).offset = index_os
            ReDim n_data(s_length)
            cp = ms.Position ' save position
            ms.Position = index_os 'set postion
            ReDim n_data(s_length)
            n_data = br.ReadBytes(s_length)
            trans_strings(i) = enc.GetString(n_data)
            trans_strings_raw(i) = n_data
            trans_flags(i) = False
        Next

        ms.Close()
        ms.Dispose()
        m_save.Enabled = True
        m_show_strings.Enabled = True
        m_hash.Enabled = True
        'strange but some lines have a lf ctr (10) in them.. This screws up the selection in the string table form.
        For i = 0 To count - 1
            trans_strings(i) = trans_strings(i).Replace(vbLf, " ")
        Next
        If frmShowStrings.Visible Then
            'update the display of strings if they are visiable
            push_strings_to_textbox()
        End If
        search_tb.Focus()
    End Sub


    Private Sub m_save_Click(sender As Object, e As EventArgs) Handles m_save.Click

        Dim out_data((file_size + 1) - delta) As Byte 'size output buffer
        replace_bt.Enabled = False
        Dim ms As New MemoryStream(out_data)
        Dim bw As New BinaryWriter(ms)
        Dim version As Integer = 0
        Dim e_byte As Byte = 0

        'write the header and other info
        bw.Write(magic)
        bw.Write(version)
        bw.Write(count)
        bw.Write(28) ' offset to os_index_tbl
        bw.Write(info_index_offset)
        bw.Write(hash_count)
        bw.Write(hash_index_offset)
        'write origianl string lens and sizes
        For i = 0 To count - 1
            bw.Write(os_indices(i).len)
            bw.Write(os_indices(i).offset)
        Next
        'write project info size and location
        bw.Write(info_index_count)
        bw.Write(info_index_string_index)
        'write out translation lens and sizes... 
        'These are the names you see on screen
        For i = 0 To count - 2
            bw.Write(trans_indices(i).len)
            bw.Write(trans_indices(i).offset)
        Next
        'Write hash table.. Not sure what this is even for yet
        For i = 0 To hash_count - 1
            bw.Write(hash_tbl(i))
        Next
        'write out first string data
        For i = 0 To count - 1
            Dim d = System.Text.Encoding.UTF8.GetBytes(os_strings(i).ToArray) 'write as UTF8
            bw.Write(d)
            bw.Write(e_byte) 'must have a terminator
        Next
        Dim dd = System.Text.Encoding.UTF8.GetBytes(info_string.ToArray) 'write as UTF8
        bw.Write(dd)
        bw.Write(e_byte) 'must have a terminator
        For i = 0 To count - 1
            If trans_flags(i) Then
                Dim d = System.Text.Encoding.UTF8.GetBytes(trans_strings(i).ToArray) 'write as UTF8
                bw.Write(d)
                bw.Write(e_byte) 'must have a terminator
            Else
                For Each b In trans_strings_raw(i)
                    bw.Write(b)
                Next
                bw.Write(e_byte) 'must have a terminator
            End If
        Next

        ReDim Preserve out_data((file_size - 1) - delta)
        Dim p = ms.Position
        System.IO.File.WriteAllBytes(OpenFile.FileName, out_data) ' save the out_date buffer.

        'clean up
        ms.Close()
        ms.Dispose()
        replace_bt.Enabled = True
        search_tb.Focus() ' give attenting to new name text box

    End Sub


    Private Sub replace_bt_Click(sender As Object, e As EventArgs) Handles replace_bt.Click
        FrmUse.Panel1.Controls.Clear()
        If search_tb.Text.Length = 0 Then
            MsgBox("You need to enter a search string!", MsgBoxStyle.Exclamation, "Oops!")
            Return
        End If
        If new_name_tb.Text.Length = 0 Then
            MsgBox("You need enter a new replacment string!", MsgBoxStyle.Exclamation, "Oops!")
            Return
        End If
        Dim cnt As Integer = 0
        Dim index As Integer = 0
        'make sure we only found ONE instance of the search string!
        For i = 0 To count - 1
            If trans_strings(i) = search_tb.Text Then
                cnt += 1
                index = i
            End If

        Next i

        If cnt > 1 Then
            If MsgBox("I found more than one instance of " + search_tb.Text + vbCrLf _
                    + "This could mess up the game!. Do it anyways?", MsgBoxStyle.YesNo, "Not Good!") = MsgBoxResult.No Then
                Return
                FrmUse.Visible = True
            End If
        End If
        If cnt = 0 Then
            MsgBox("Name not found!", MsgBoxStyle.Exclamation, "Opps!")
            Return
        End If
        results_tb.Text = ""
        'We need the difference in size of the old and new name.
        'This is used to offset the index positions of the lookup tables.
        ReDim uselist(cnt)
        For i = 0 To cnt - 1
            uselist(cnt) = New uselist_
            uselist(i).use = False
            Dim c As New CheckBox
            c.Text = search_tb.Text
            c.Checked = False
            c.Tag = i
            AddHandler c.CheckedChanged, AddressOf handle_checked_changed
            c.Location = New Point(5, i * 25)
            FrmUse.Panel1.Controls.Add(c)
        Next
        'If cnt = 1 Then
        '    'uselist(0).use = True
        'End If
        FrmUse.StartPosition = FormStartPosition.Manual
        FrmUse.Location = New Point(Me.Location.X + Me.Width - FrmUse.Width, Me.Location.Y + Me.Height)
        FrmUse.ShowDialog()
        cnt = -1 ' needs to start and -1 !!!!
        Dim use As Boolean = False
        Dim replace_cnt As Integer = 0
        For i = 0 To count - 1

            If trans_strings(i) = search_tb.Text Then
                cnt += 1
                If uselist(cnt).use Then
                    replace_cnt += 1
                    trans_flags(i) = True
                    index = i
                    Dim d2 = trans_strings(index).Length - new_name_tb.Text.Length
                    delta += d2
                    trans_strings(index) = new_name_tb.Text
                    trans_indices(index).len = new_name_tb.Text.Length
                    'Adjust postion of all following strings positions.
                    For j = index + 1 To count
                        trans_indices(j).offset -= d2
                    Next
                End If
            End If
        Next
        results_tb.Text = new_name_tb.Text + " ----> " + search_tb.Text + " Replaced " + replace_cnt.ToString + " times."
        sb.Length = 0
        If frmShowStrings.Visible Then
            'update the display of strings if they are visiable
            push_strings_to_textbox()
        End If

        search_tb.Focus() ' give attenting to new name text box
    End Sub
    Private Sub push_strings_to_textbox()

        Dim ta = trans_strings.ToList
        ta.Sort()
        sb.Length = 0
        For Each s In ta
            If s IsNot Nothing Then
                If s.Length > 1 Then
                    sb.AppendLine(s)
                End If
            End If
        Next
        frmShowStrings.show_tb.Text = ""
        Application.DoEvents()
        frmShowStrings.show_tb.Text = sb.ToString
        frmShowStrings.show_tb.SelectionLength = 0
        frmShowStrings.show_tb.SelectionStart = 0

        Application.DoEvents()
    End Sub

    Private Sub handle_checked_changed(ByVal sender As Object, e As EventArgs)
        Dim c = DirectCast(sender, CheckBox)
        If c.Checked Then
            uselist(c.Tag).use = c.Checked
        End If
    End Sub

    Private Sub m_show_strings_Click(sender As Object, e As EventArgs) Handles m_show_strings.Click
        frmShowStrings.Visible = True
        frmShowStrings.Width = Me.Width
        frmShowStrings.Location = New Point(Me.Location.X, Me.Location.Y + Me.Height)
        push_strings_to_textbox()
    End Sub

    Private Sub m_hash_Click(sender As Object, e As EventArgs) Handles m_hash.Click
        'hash table junk which I dont understand...
        frmTable.Visible = True
        sb.Clear()
        For i = 0 To hash_count - 1
            Dim p = hash_tbl(i)
            sb.AppendLine(trans_strings(p))

        Next
        frmTable.hash_tb.Text = sb.ToString

    End Sub
End Class
