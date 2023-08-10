Imports System.Data.Odbc
Public Class Form3

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Sub noaktif()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
    End Sub

    Sub aktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Sub tampil()
        koneksi()

        da = New OdbcDataAdapter("SELECT * FROM tabel_admin", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tabel_admin")
        DGV.DataSource = (ds.Tables("tabel_admin"))
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        noaktif()
        DGV.Refresh()
        kosongkan()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aktif()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Mohon lengkapi data terlebih dahulu sebelum disimpan")
        Else
            koneksi()

            sql = "INSERT INTO tabel_admin() VALUES('" & DBNull.Value & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil disimpan")
            DGV.Refresh()
            kosongkan()
            tampil()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MsgBox("Mohon pilih username yang akan dihapus")
        Else
            koneksi()

            sql = "DELETE FROM tabel_admin WHERE username = '" & TextBox2.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            DGV.Refresh()
            kosongkan()
            tampil()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            MsgBox("Mohon masukan username yang ingin di update")
        Else
            sql = "UPDATE tabel_admin SET nama = '" & TextBox3.Text & "', password = '" & TextBox4.Text & "', telepon = '" & TextBox5.Text & "' WHERE username = '" & TextBox2.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            DGV.Refresh()
            kosongkan()
            tampil()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        koneksi()
        ' kita buat sqlnya, kita panggil semua table mahasiswa, yang mana hanya nim yang kita masukin aja pada textbox5 yang akan tampil
        cmd = New OdbcCommand("SELECT * FROM tabel_admin WHERE username like '%" & TextBox1.Text & "%'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        ' Jika yang kita masukan ada nim-nya maka
        If dr.HasRows Then
            ' Kita panggil koneksi
            Call koneksi()
            '  kita buat sqlnya, kita panggil semua table mahasiswa, yang mana hanya nim yang kita masukin aja pada textbox5 yang akan tampil
            da = New OdbcDataAdapter("SELECT * FROM tabel_admin WHERE username like '%" & TextBox1.Text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "tabel_admin")
            DGV.DataSource = ds.Tables("tabel_admin")
            DGV.ReadOnly = True
        End If
    End Sub
End Class