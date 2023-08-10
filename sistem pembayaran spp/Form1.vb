Imports System.Data.Odbc
Public Class Form1

    Sub kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Mohon isi dengan lengkap sebelum login")
        Else
            koneksi()

            cmd = New OdbcCommand("SELECT * FROM tabel_admin WHERE username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                MsgBox("Login gagal")
                MsgBox("Mohon masukan data yang valid")
                Exit Sub
            Else
                If TextBox2.Text <> dr.Item("password") Then
                    MsgBox("Password salah")
                    TextBox2.Focus()
                Else
                    Form2.Show()
                    Me.Hide()
                    Form2.nama.Text = dr!nama
                    Form6.TextBox6.Text = dr!nama
                    Form6.TextBox3.Text = Today
                End If
            End If
        End If


        ' If TextBox1.Text = "" Or TextBox2.Text = "" Then
        ' MsgBox("Mohon isi data dengan lengkap")
        ' ElseIf (TextBox1.Text = "hafidz" And TextBox2.Text = "hafidz123") Then
        ' MsgBox("Login berhasil")
        ' kosongkan()
        ' Form2.Show()
        ' Me.Hide()
        ' Else
        ' MsgBox("Login Gagal")
        ' MsgBox("Silahkan masukan username dan password dengan valid")
        ' kosongkan()
        ' End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If TextBox2.UseSystemPasswordChar = True Then

            ' show password
            TextBox2.UseSystemPasswordChar = False

        Else

            ' hide password
            TextBox2.UseSystemPasswordChar = True

        End If

    End Sub

End Class
