Imports System.Data.SqlClient
Public Class user
    Dim conn As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet

    Public Sub display()
        conn.Open()
        Dim sql = "select * from usertb"
        adapter = New SqlDataAdapter(sql, conn)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet
        adapter.Fill(ds)
        UserDGV.DataSource = ds.Tables(0)
        conn.Close()
    End Sub
   
    Private Sub UserDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles UserDGV.CellContentClick, UserDGV.CellClick
        useridtx.Text = UserDGV.SelectedCells.Item(0).Value.ToString()
        usernametx.Text = UserDGV.SelectedCells.Item(1).Value.ToString()
        passtx.Text = UserDGV.SelectedCells.Item(2).Value.ToString()
        phonetx.Text = UserDGV.SelectedCells.Item(3).Value.ToString()


    End Sub
    Private Sub Addbtn_Click(sender As Object, e As EventArgs) Handles Addbtn.Click
        
        If useridtx.Text = "" Or usernametx.Text = "" Or passtx.Text = "" Or phonetx.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        ElseIf phonetx.Text.Length > 10 Then
            MsgBox("Phone numbers must be of a maximum of digits long")
            phonetx.Text = Strings.Left(phonetx.Text, phonetx.Text.Length - 1)
            phonetx.Text = ""
        ElseIf phonetx.Text.Length < 10 Then
            MsgBox("your Phone numbers contain below 10 digits")
            phonetx.Text = ""

        Else
            Try
                conn.Open()
                Dim sql = "INSERT INTO usertb values('" & useridtx.Text & "','" & usernametx.Text & "','" & passtx.Text & "','" & phonetx.Text & "')"
                cmd = New SqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Users Added Successfully", MsgBoxStyle.Information, "Insert")
                conn.Close()
                display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub


    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click
      
        If useridtx.Text = "" Or usernametx.Text = "" Or passtx.Text = "" Or phonetx.Text = "" Then
            MsgBox("Select the row for delete", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim result As DialogResult = MsgBox("You want to delete seleted details", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
            If result = Windows.Forms.DialogResult.Yes Then
                Dim sql = "DELETE FROM usertb WHERE userid='" & useridtx.Text & "'"
                cmd = New SqlCommand(sql, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Selected user details Deleted Successfully", MsgBoxStyle.Information, "Delete")
                conn.Close()
                display()
                Exit Sub
            ElseIf result = Windows.Forms.DialogResult.No Then
                MsgBox("Operation Cancelled", MsgBoxStyle.Information, "Cancel")
            End If
        End If
    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click
        useridtx.Text = ""
        usernametx.Text = ""
        passtx.Text = ""
        phonetx.Text = ""
    End Sub

  

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Home.Show()
    End Sub




    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If u_search.Text = "" Then
            MsgBox("Please enter the user_ID", MsgBoxStyle.Exclamation, "Alert")

        Else
            conn.Open()
            Dim sql = "SELECT * FROM usertb WHERE userid='" & u_search.Text & "'"
            cmd = New SqlCommand(sql, conn)
            adapter = New SqlDataAdapter(cmd)
            ds = New DataSet
            adapter.Fill(ds)
            UserDGV.DataSource = ds.Tables(0)
            conn.Close()

        End If


    End Sub

    Private Sub RetriveButton_Click(sender As Object, e As EventArgs) Handles RetriveButton.Click
        display()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If passtx.UseSystemPasswordChar = True Then
            passtx.UseSystemPasswordChar = False
        Else
            passtx.UseSystemPasswordChar = True
        End If
    End Sub
End Class