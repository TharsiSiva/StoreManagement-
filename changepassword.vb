Imports System.Data.SqlClient

Public Class changepassword
    Private Sub reg_Click(sender As Object, e As EventArgs) Handles CHANGE.Click
        Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
        Dim cmd As SqlCommand

        Dim reader As SqlDataReader
        Dim query As String

        con.Open()
        query = "select * from usertb "
        cmd = New SqlCommand(query, con)
        reader = cmd.ExecuteReader
        con.Close()

        con.Open()
        Dim sql = "UPDATE usertb SET password='" & txnewpass.Text & "'WHERE password='" & txoldpass.Text & "'"
        cmd = New SqlCommand(sql, con)

        cmd.ExecuteNonQuery()
        MsgBox("Password changed Successfully", MsgBoxStyle.Information, "Change")
        con.Close()
        Me.Hide()
        homeproduct.Show()

    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        txid.Text = ""
        txnewpass.Text = ""
        txoldpass.Text = ""

    End Sub

    Private Sub can_Click(sender As Object, e As EventArgs) Handles can.Click
        Me.Hide()
        login.Show()
    End Sub
End Class