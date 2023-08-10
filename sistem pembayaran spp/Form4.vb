Imports System.Data.Odbc
Public Class Form4

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aktif()
    End Sub

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Sub noaktif()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Sub aktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        noaktif()
        kosongkan()
        tampil()
    End Sub

    Sub tampil()
        koneksi()

        da = New OdbcDataAdapter("SELECT * FROM tabel_jurusan", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tabel_jurusan")
        DGV.DataSource = (ds.Tables("tabel_jurusan"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("mohon lengkapi data terlebih dahulu sebelum disimpan")
        Else
            koneksi()

            sql = "INSERT INTO tabel_jurusan() VALUES(NULL,'" & TextBox2.Text & "','" & TextBox3.Text & "')"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil disimpan")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Then
            MsgBox("mohon masukan nama jurusan yang ingin dihapus")
        Else
            sql = "DELETE FROM tabel_jurusan WHERE nama_jur = '" & TextBox3.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub
End Class