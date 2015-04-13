Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class Nhanvien
    Public Sub LoadData()
        Dim ketnoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from nhanvien", ketnoi)
        Try
            sqlAdapter.Fill(tb)
        Catch ex As Exception
        End Try
        DataGridView2.DataSource = tb
        ketnoi.Close()
    End Sub
    Dim tb As New DataTable
    Dim connectstr As String = "workstation id=ps02166.mssql.somee.com;packet size=4096;user id=ql_banhang;pwd=Abc12345;data source=ps02166.mssql.somee.com;persist security info=False;initial catalog=ps02166"


  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ketnoi As New SqlConnection(connectstr)
        ketnoi.Open()
        Dim stradd As String = "insert into Nhanvien values(@username,@password)"
        Dim com As New SqlCommand(stradd, ketnoi)
        Try
            'thêm dữ liệu
            com.Parameters.AddWithValue("@username", TextBox1.Text)

            com.Parameters.AddWithValue("@password", TextBox2.Text)

            'thực thi truy vấn và sử dữ liệu
            com.ExecuteNonQuery()
            'đóng kết nối
            ketnoi.Close()
        Catch ex As Exception
            MessageBox.Show("thanh cong")
        End Try
        Dim Query3 As SqlDataAdapter = New SqlDataAdapter("select * from Nhanvien", connectstr)
        tb.Clear()

        Query3.Fill(tb)
        DataGridView2.DataSource = tb.DefaultView
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim index As Integer = DataGridView2.CurrentCell.RowIndex
        TextBox1.Text = DataGridView2.Item(0, index).Value
        TextBox2.Text = DataGridView2.Item(1, index).Value
        
    End Sub

    Private Sub Nhanvien_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class