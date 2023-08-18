Imports System.Data.SqlClient

Public Class Register
    Dim sqlcon As SqlConnection
    Dim command As SqlCommand


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles reg.Click
        If txuser.Text = "" Or txphone.Text = "" Or txpass.Text = "" Or txcofpass.Text = "" Then
            MsgBox("Fill all fields")
        ElseIf txphone.Text.Length > 10 Then
            MsgBox("Phone numbers must be of a maximum of digits long")
            txphone.Text = Strings.Left(txphone.Text, txphone.Text.Length - 1)
            txphone.Text = ""
        ElseIf txphone.Text.Length < 10 Then
            MsgBox("your Phone numbers contain below 10 digits")
            txphone.Text = ""
        ElseIf txpass.Text = txcofpass.Text = False Then
            MsgBox("Password not match")
        Else
            sqlcon = New SqlConnection
            sqlcon.ConnectionString = ("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")

            Dim reader As SqlDataReader
            Dim query As String

            sqlcon.Open()
            query = "select * from usertb where userid like '" & txusid.Text & "'"
            command = New SqlCommand(query, sqlcon)
            reader = command.ExecuteReader

            If reader.Read = True Then
                MsgBox("Username already Registered")
                sqlcon.Close()

            Else
                sqlcon.Close()
                sqlcon.Open()
                query = " Insert into usertb (userid,username,password,phone)values('" & txusid.Text & "' ,'" & txuser.Text & "' ,'" & txpass.Text & "','" & txphone.Text & "' )"
                command = New SqlCommand(query, sqlcon)
                reader = command.ExecuteReader
                sqlcon.Close()
                MsgBox("Sucessfully Registered")
                Me.Close()
                login.Show()
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txpass.UseSystemPasswordChar = True Then
            txpass.UseSystemPasswordChar = False
        Else
            txpass.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If txcofpass.UseSystemPasswordChar = True Then
            txcofpass.UseSystemPasswordChar = False
        Else
            txcofpass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        login.Show()

    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txusid_TextChanged(sender As Object, e As EventArgs) Handles txusid.TextChanged

    End Sub
End Class




