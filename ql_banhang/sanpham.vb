Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class sanpham
    Dim tb As New DataTable
    Dim connectstr As String = "workstation id=ps02166.mssql.somee.com;packet size=4096;user id=ql_banhang;pwd=Abc12345;data source=ps02166.mssql.somee.com;persist security info=False;initial catalog=ps02166"

    Private Sub sanpam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ketnoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from San_pham", ketnoi)

        Try
            sqlAdapter.Fill(tb)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub
    Public Sub LoadData()
        Dim ketnoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from San_pham", ketnoi)
        Try
            sqlAdapter.Fill(tb)
        Catch ex As Exception
        End Try
        DataGridView1.DataSource = tb
        ketnoi.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "insert into San_Pham values(@Ma_SP,@Ngaysanxaut_SP,@Chuthich_SP,@SoLuong_SP,@Loai_sanpham_Maloai_SP)"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            'thêm dữ liệu
            com.Parameters.AddWithValue("@Ma_SP", TextBox1.Text)

            com.Parameters.AddWithValue("@Ngaysanxaut_SP", TextBox2.Text)

            com.Parameters.AddWithValue("@Chuthich_SP", TextBox3.Text)

            com.Parameters.AddWithValue("@Soluong_SP", TextBox4.Text)

            com.Parameters.AddWithValue("@Loai_sanpham_Maloai_SP", TextBox5.Text)

            'thực thi truy vấn và sử dữ liệu
            com.ExecuteNonQuery()
            'đóng kết nối
            ketnoi.Close()
            MessageBox.Show("ket noi thanh cong")
        Catch ex As Exception
            MessageBox.Show("ket noi khong thanh cong")
        End Try
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        tb.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = tb.DefaultView
        LoadData()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        TextBox1.Text = DataGridView1.Item(0, index).Value
        TextBox2.Text = DataGridView1.Item(1, index).Value
        TextBox3.Text = DataGridView1.Item(2, index).Value
        TextBox4.Text = DataGridView1.Item(3, index).Value
        TextBox5.Text = DataGridView1.Item(4, index).Value

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "Update San_pham Set Loai_sanpham_Maloai_SP = @Loai_sanpham_Maloai_SP, ngaysanxaut_SP = @ngaysanxaut_SP, chuthich_SP = @chuthich_SP, Soluong_SP = @Soluong_SP WHERE Ma_SP = @Ma_SP"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            'thêm dữ liệu
            com.Parameters.AddWithValue("@Ma_SP", TextBox1.Text)

            com.Parameters.AddWithValue("@ngaysanxaut_SP", TextBox2.Text)

            com.Parameters.AddWithValue("@chuthich_SP", TextBox3.Text)

            com.Parameters.AddWithValue("@Soluong_SP", TextBox4.Text)

            com.Parameters.AddWithValue("@Loai_sanpham_Maloai_SP", TextBox5.Text)

            'thực thi truy vấn và sử dữ liệu
            com.ExecuteNonQuery()
            'đóng kết nối
            ketnoi.Close()
            MessageBox.Show("Sửa thành công ")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công ")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub sanpham_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "Delete From San_pham Where Ma_SP = @Ma_SP"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            com.Parameters.AddWithValue("@Ma_SP", TextBox1.Text)
            com.ExecuteNonQuery()
            ketnoi.Close()
        Catch ex As Exception
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub
End Class