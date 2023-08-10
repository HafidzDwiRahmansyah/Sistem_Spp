Imports System.Data.Odbc
Imports System.Drawing.Printing
Public Class Form7

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form2.Show()
        Me.Hide()

    End Sub

    Sub noaktif()
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        noaktif()

        koneksi()
        cmd = New OdbcCommand("SELECT * FROM tbl_bayar", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr.GetString(1))
        Loop

    End Sub

    Private Sub ComboBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseClick
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tbl_bayar WHERE nokwi = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.GetString(2)
            TextBox3.Text = dr.GetString(3)
            TextBox1.Text = dr.GetString(5)
            TextBox4.Text = dr.GetString(4)
            TextBox6.Text = dr.GetString(6)
            TextBox7.Text = dr.GetString(7)
        End If
    End Sub

   
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()

        cmd = New OdbcCommand("SELECT * FROM tbl_bayar WHERE nokwi = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader()
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.GetString(2)
            TextBox3.Text = dr.GetString(3)
            TextBox5.Text = "Rp."
            TextBox1.Text = dr.GetString(5)
            TextBox4.Text = dr.GetString(4)
            TextBox6.Text = dr.GetString(6)
            TextBox7.Text = dr.GetString(7)
        End If
    End Sub

    Sub kosongkan()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kosongkan()
    End Sub

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub


    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 650, 350)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f8 As New Font("Montserrat", 8, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14 As New Font("Times New Roman", 12, FontStyle.Regular)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "---------------------------------------------------------------------"

        e.Graphics.DrawString("Smk Bina Mandiri Multimedia", f14, Brushes.Blue, centermargin, 10, tengah)
        e.Graphics.DrawString("Cileungsi Kidul, Cileungsi, Bogor Regency, West Java 16820", f10, Brushes.Black, centermargin, 31, tengah)
        e.Graphics.DrawString(garis, f10, Brushes.Black, centermargin, 41, tengah)


        Dim tinggi As Integer
        tinggi += 15

        e.Graphics.DrawString("Nama :", f10, Brushes.Black, 10, 60 + tinggi)
        e.Graphics.DrawString(TextBox3.Text, f10, Brushes.Black, 90, 60 + tinggi)

        e.Graphics.DrawString("Admin :", f10, Brushes.Black, 10, 100 + tinggi)
        e.Graphics.DrawString(TextBox6.Text, f10, Brushes.Black, 90, 100 + tinggi)

        e.Graphics.DrawString("Tanggal :", f10, Brushes.Black, 10, 140 + tinggi)
        e.Graphics.DrawString(TextBox4.Text, f10, Brushes.Black, 90, 140 + tinggi)

        e.Graphics.DrawString("Total :", f10, Brushes.Black, 10, 180 + tinggi)
        e.Graphics.DrawString("Rp. ", f10, Brushes.Black, 90, 180 + tinggi)
        e.Graphics.DrawString(TextBox1.Text, f10, Brushes.Black, 110, 180 + tinggi)

        e.Graphics.DrawString("Keterangan :", f10, Brushes.Black, 10, 220 + tinggi)
        e.Graphics.DrawString(TextBox7.Text, f10, Brushes.Black, 550, 220 + tinggi)

        e.Graphics.DrawString("Ini adalah salah satu bukti apabila siswa telah membayar spp", f8, Brushes.Teal, centermargin, 295, tengah)
        e.Graphics.DrawString("apa bila ada kesalahan dalam input dan lain-lainnya", f8, Brushes.Teal, centermargin, 310, tengah)
        e.Graphics.DrawString("Silahkan hubungi : 0895410871030", f8, Brushes.Teal, centermargin, 325, tengah)

    End Sub
End Class