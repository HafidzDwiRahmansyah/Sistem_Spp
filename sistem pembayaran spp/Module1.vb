Imports System.Data.Odbc
Module Module1
    Public conn As OdbcConnection
    Public ds As DataSet
    Public dr As OdbcDataReader
    Public da As OdbcDataAdapter
    Public cmd As OdbcCommand
    Public sql As String

    Sub koneksi()
        sql = "Driver={MySQL ODBC 5.1 Driver};server=localhost;uid=root;database=db_spp;port=3306;"
        conn = New OdbcConnection(sql)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
