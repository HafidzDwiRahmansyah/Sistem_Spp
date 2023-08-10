Imports System.Data.Odbc
Public Class Form5

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        ComboBox1.Text = "~ pilih ~"
        ComboBox2.Text = "~ pilih ~"
        ComboBox3.Text = "~ pilih ~"
        ComboBox4.Text = "~ pilih ~"
    End Sub

    Sub noaktif()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
    End Sub

    Sub aktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        noaktif()
        tampil()
        kosongkan()
        DGV.Refresh()

        Dim str As String

        str = "SELECT * FROM tabel_jurusan"
        cmd = New OdbcCommand(str, conn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            Do While dr.Read
                ComboBox1.Items.Add(dr("id_jur"))
            Loop
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aktif()
    End Sub

    Sub tampil()
        koneksi()
        da = New OdbcDataAdapter("SELECT * FROM tabel_sis", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tabel_sis")
        DGV.DataSource = (ds.Tables("tabel_sis"))
    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tabel_jurusan WHERE id_jur = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox5.Text = dr.GetString(2)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tabel_jurusan WHERE id_jur = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox5.Text = dr.GetString(2)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or TextBox8.Text = "" Or ComboBox4.Text = "" Then
            MsgBox("Mohon masukan data dengan lengkap sebelum disimpan")
        Else
            koneksi()

            sql = "INSERT INTO tabel_sis() VALUES(NULL, '" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox4.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox8.Text & "','" & TextBox7.Text & "')"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil disimpan")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MsgBox("mohon pilih nis yang akan dihapus")
        Else
            koneksi()

            sql = "DELETE FROM tabel_sis WHERE nis_siswa = '" & TextBox2.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil dihapus")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        koneksi()
        ' kita buat sqlnya, kita panggil semua table mahasiswa, yang mana hanya nim yang kita masukin aja pada textbox5 yang akan tampil
        cmd = New OdbcCommand("SELECT * FROM tabel_sis WHERE nama_sis like '%" & TextBox1.Text & "%'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        ' Jika yang kita masukan ada nim-nya maka
        If dr.HasRows Then
            ' Kita panggil koneksi
            Call koneksi()
            '  kita buat sqlnya, kita panggil semua table mahasiswa, yang mana hanya nim yang kita masukin aja pada textbox5 yang akan tampil
            da = New OdbcDataAdapter("SELECT * FROM tabel_sis WHERE nama_sis like '%" & TextBox1.Text & "%'", conn)
            ds = New DataSet
            da.Fill(ds, "tabel_sis")
            DGV.DataSource = ds.Tables("tabel_sis")
            DGV.ReadOnly = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            MsgBox("Pilih nis yang akan di update")
        Else
            koneksi()

            sql = "UPDATE tabel_sis SET nama_sis = '" & TextBox3.Text & "', kelas = '" & ComboBox4.Text & "', thn_ajar = '" & TextBox4.Text & "', nama_jurusan = '" & TextBox5.Text & "', jenis_kel = '" & ComboBox2.Text & "', wali = '" & ComboBox3.Text & "', telp_wali = '" & TextBox8.Text & "', alamat = '" & TextBox7.Text & "' WHERE nis_siswa = '" & TextBox2.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("data berhasil di update")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub
End Class