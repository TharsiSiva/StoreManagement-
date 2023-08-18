Imports System.Data.SqlClient
Public Class login
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        useridtx.Text = ""
        passtx.Text = ""
    End Sub

    Private Sub lgbtn_Click(sender As Object, e As EventArgs) Handles lgbtn.Click
        If useridtx.Text = "" Then
            MsgBox("Enter the User Name")
        ElseIf passtx.Text = "" Then
            MsgBox("Enter the Password")
        Else
            con.Open()
            Dim query = "select * from usertb where userid='" & useridtx.Text & "' and password='" & passtx.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Wrong username or password ")
            Else
                homeproduct.Show()
                Me.Hide()

            End If
            con.Close()
        End If
        useridtx.Text = ""
        passtx.Text = ""
    End Sub


    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If passtx.UseSystemPasswordChar = True Then
            passtx.UseSystemPasswordChar = False
        Else
            passtx.UseSystemPasswordChar = True
        End If
    End Sub

   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Register.Show()

    End Sub
End Class