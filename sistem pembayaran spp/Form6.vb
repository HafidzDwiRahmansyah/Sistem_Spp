Imports System.Data.Odbc
Public Class Form6

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox7.Text = ""

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Sub noaktif()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
    End Sub

    Sub aktif()
        TextBox1.Enabled = True
        TextBox7.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
    End Sub

    Sub tampil()
        koneksi()

        da = New OdbcDataAdapter("SELECT * FROM tbl_bayar", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_bayar")
        DGV.DataSource = (ds.Tables("tbl_bayar"))
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        noaktif()
        tampil()
        kosongkan()

        TextBox3.Text = Today

        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tabel_sis", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr.GetString(1))
        Loop

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aktif()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox7.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Mohon lengkapi data terlebih dahulu")
        Else
            koneksi()

            sql = "INSERT INTO tbl_bayar() VALUES(NULL, '" & TextBox7.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox3.Text & "')"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("data berhasil disimpan")
            DGV.Refresh()
            kosongkan()
            tampil()
        End If
    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tabel_sis WHERE nis_siswa = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.GetString(2)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tabel_sis WHERE nis_siswa = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.GetString(2)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox7.Text = "" Then
            MsgBox("Mohon pilih nomer kwitansi yang akan di hapus")
        Else
            koneksi()

            sql = "DELETE FROM tbl_bayar WHERE nokwi = '" & TextBox7.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("data berhasil dihapus")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.Text = "" Or ComboBox1.Text = "" Or ComboBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Mohon lengkapi data terlebih dahulu")
        Else
            koneksi()

            sql = "UPDATE tbl_bayar SET nis = '" & ComboBox1.Text & "', nama_siswa = '" & TextBox2.Text & "', date = '" & TextBox3.Text & "', jumlah = '" & TextBox5.Text & "', nm_adm = '" & TextBox6.Text & "', ket = '" & ComboBox3.Text & "'WHERE nokwi = '" & TextBox7.Text & "';"
            cmd = New OdbcCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MsgBox("data berhasil di update")
            kosongkan()
            DGV.Refresh()
            tampil()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If ComboBox2.Text = "" Then
            MsgBox("Mohon masukan nilai terlebih dahulu sebelum menjumlahkan")
        Else
            Dim angka1, angka2, hasil As Integer

            angka1 = ComboBox2.Text
            angka2 = TextBox4.Text

            hasil = angka1 * angka2

            TextBox5.Text = hasil
        End If

    End Sub
End Class