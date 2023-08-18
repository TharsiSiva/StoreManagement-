Imports System.Data.SqlClient
Public Class customer
    Dim Con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet

    Public Sub display()
        Con.Open()
        Dim sql = "select * from CustomerTbl"
        adapter = New SqlDataAdapter(sql, Con)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet
        adapter.Fill(ds)
        CustomerDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub CustomerDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CustomerDGV.CellContentClick, CustomerDGV.CellClick
        CustId.Text = CustomerDGV.SelectedCells.Item(0).Value.ToString()
        CustName.Text = CustomerDGV.SelectedCells.Item(1).Value.ToString()
        CustPhone.Text = CustomerDGV.SelectedCells.Item(2).Value.ToString()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CustId.Text = "" Or CustName.Text = "" Or CustPhone.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        ElseIf CustPhone.Text.Length > 10 Then
            MsgBox("Phone numbers must be of a maximum of digits long")
            CustPhone.Text = Strings.Left(CustPhone.Text, CustPhone.Text.Length - 1)
            CustPhone.Text = ""
        ElseIf CustPhone.Text.Length < 10 Then
            MsgBox("your Phone numbers contain below 10 digits")
            CustPhone.Text = ""
        Else
            Try
                Con.Open()
                Dim sql = "INSERT INTO CustomerTbl values('" & CustId.Text & "','" & CustName.Text & "','" & CustPhone.Text & " ')"
                cmd = New SqlCommand(sql, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Customer Added Successfully", MsgBoxStyle.Information, "Insert")
                Con.Close()
                display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
   
    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CustId.Text = ""
        CustName.Text = ""
        CustPhone.Text = ""
        C_search.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CustId.Text = "" Or CustName.Text = "" Or CustPhone.Text = "" Then
            MsgBox("Select the row for delete", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim result As DialogResult = MsgBox("You want to delete this Customer details", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
            If result = Windows.Forms.DialogResult.Yes Then
                Dim sql = "DELETE FROM CustomerTbl WHERE CustId='" & CustId.Text & "'"
                cmd = New SqlCommand(sql, Con)
                Con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Customer Deleted Successfully", MsgBoxStyle.Information, "Delete")
                Con.Close()
                display()
                Exit Sub
            ElseIf result = Windows.Forms.DialogResult.No Then
                MsgBox("Operation Cancelled", MsgBoxStyle.Information, "Cancel")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CustId.Text = "" Or CustName.Text = "" Or CustPhone.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        Else
            Try
                Con.Open()
                Dim sql = "UPDATE CustomerTbl SET CustId='" & CustId.Text & "',CustName='" & CustName.Text & "',CustPhone='" & CustPhone.Text & "'WHERE CustId='" & CustId.Text & "'"
                cmd = New SqlCommand(sql, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Customers Updated Successfully", MsgBoxStyle.Information, "Update")
                Con.Close()
                display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Home.Show()
    End Sub
  
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If C_search.Text = "" Then
            MsgBox("Please enter the user_ID", MsgBoxStyle.Exclamation, "Alert")

        Else
            Con.Open()
            Dim sql = "SELECT * FROM CustomerTbl WHERE CustId='" & C_search.Text & "'"
            cmd = New SqlCommand(sql, Con)
            adapter = New SqlDataAdapter(cmd)
            ds = New DataSet
            adapter.Fill(ds)
            CustomerDGV.DataSource = ds.Tables(0)
            Con.Close()

        End If

    End Sub

    Private Sub RetriveButton_Click_1(sender As Object, e As EventArgs) Handles RetriveButton.Click
        display()
    End Sub
End Class