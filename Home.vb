Public Class Home

    Private Sub orderbtn_Click(sender As Object, e As EventArgs)
        Me.Hide()
        order.Show()
    End Sub
    Private Sub categorybtn_Click(sender As Object, e As EventArgs) Handles categorybtn.Click
        Me.Hide()
        category.Show()
    End Sub

    Private Sub custbtn_Click(sender As Object, e As EventArgs) Handles custbtn.Click
        Me.Hide()
        customer.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        mainlogin.Show()
    End Sub

    Private Sub productbtn_Click(sender As Object, e As EventArgs) Handles productbtn.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class