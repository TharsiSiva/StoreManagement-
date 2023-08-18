Public Class homeproduct

    Private Sub productbtn_Click(sender As Object, e As EventArgs) Handles productbtn.Click
        product.Show()
        Me.Hide()
    End Sub

    Private Sub usersbtn_Click(sender As Object, e As EventArgs)
        user.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        changepassword.Show()
    End Sub

    Private Sub orderbtn_Click(sender As Object, e As EventArgs) Handles orderbtn.Click
        Me.Hide()
        order.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        changepassword.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        login.Show()
    End Sub
End Class