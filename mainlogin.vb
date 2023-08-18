Public Class mainlogin

    Private Sub lgbtn_Click(sender As Object, e As EventArgs) Handles lgbtn.Click
        If useridtx.Text = "Pharmavision" And passtx.Text = "Pharma1960" Then
            MsgBox("Successfully login ", MsgBoxStyle.Information)
            Home.Show()
            Me.Hide()
        Else
            MsgBox("Incorrect username or password", MsgBoxStyle.Exclamation, "Alert")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        useridtx.Text = ""
        passtx.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If passtx.UseSystemPasswordChar = True Then
            passtx.UseSystemPasswordChar = False
        Else
            passtx.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        MainProducts.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub
End Class