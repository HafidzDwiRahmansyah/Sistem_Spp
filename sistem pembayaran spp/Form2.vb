Imports System.Data.Odbc
Public Class Form2

    Private Sub LineShape1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Application.Exit()
    End Sub

    Sub total_admin()
        koneksi()

        Dim admin_cmd As New OdbcCommand
        Dim admin_stmt As String
        Dim admintotal As String

        admin_stmt = "SELECT COUNT(*) FROM tabel_admin"
        admin_cmd = New OdbcCommand(admin_stmt, conn)
        admintotal = admin_cmd.ExecuteScalar()

        lbl_admin.Text = admintotal

    End Sub

    Sub total_siswa()
        koneksi()

        Dim user_cmd As New OdbcCommand
        Dim user_stmt As String
        Dim total_siswa As String

        user_stmt = "SELECT COUNT(*) FROM tabel_sis"
        user_cmd = New OdbcCommand(user_stmt, conn)
        total_siswa = user_cmd.ExecuteScalar()

        Label9.Text = total_siswa
    End Sub

    Sub total_jurusan()
        koneksi()

        Dim jur_cmd As New OdbcCommand
        Dim jur_stmt As String
        Dim total_jur As String

        jur_stmt = "SELECT COUNT(*) FROM tabel_jurusan"
        jur_cmd = New OdbcCommand(jur_stmt, conn)
        total_jur = jur_cmd.ExecuteScalar()

        Label11.Text = total_jur
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label11.Refresh()
        Label9.Refresh()
        lbl_admin.Refresh()
        total_admin()
        total_siswa()
        total_jurusan()

        Tanggal.Text = Today

        ' koneksi()

        '' cmd = New OdbcCommand("SELECT * FROM tbl_bayar", conn)
        ' dr = cmd.ExecuteReader()
        ' While dr.Read
        ' Chart1.Series("Report").Points.AddXY(dr.GetString(3), dr.GetInt32(3))
        ' End While

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        MsgBox("Ini adalah sebuah aplikasi dekstop tentang pembayaran, disini saya mengambil ide ini dikarenakan program ini tidak terlalu sulit dan tidak terlalu mudah. Aplikasi ini masih dalam tahap pengembangan jadi apabila ada sistem yang tidak sesuai mohon maaf. Sekian Terimakasih")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        MsgBox("Kontak Developer = 0895410871030")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Jam.Text = TimeOfDay
    End Sub

    Private Sub nama_Click(sender As Object, e As EventArgs) Handles nama.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form7.Show()
        Me.Hide()
    End Sub
End Class