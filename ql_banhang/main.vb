Public Class main

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sanpham.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nhanvien.show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        about.Show()
    End Sub
End Class