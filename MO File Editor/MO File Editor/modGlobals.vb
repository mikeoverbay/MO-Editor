Imports System.Text
Module modGlobals
    Public os_strings() As String
    Public trans_strings() As String
    Public trans_strings_raw() As Array
    Public trans_flags() As Boolean
    Public hash_tbl() As Integer
    Public os_indices() As indice_
    Public hash_indices() As indice_
    Public trans_indices() As indice_
    Public Structure indice_
        Public len As Integer
        Public offset As Integer
    End Structure
    Public count As Integer
    Public info_string As String
    Public sb As New StringBuilder
    Public uselist() As uselist_
    Public Structure uselist_
        Public use As Boolean
    End Structure
End Module
