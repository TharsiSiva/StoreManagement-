Imports System.Data.SqlClient
Public Class category
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet
    Dim cmd As SqlCommand
    Public Sub display()
        Con.Open()
        Dim sql = "SELECT * FROM CategoryTbl"
        adapter = New SqlDataAdapter(sql, Con)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet
        adapter.Fill(ds)
        CategoryDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        If C_id.Text = "" Or C_name.Text = "" Or C_Brand.Text = "" Then
            MsgBox("Incomplete data", MsgBoxStyle.Exclamation, "Atert")
        Else
            con.Open()
            Dim sql = "INSERT INTO CategoryTbl values('" & C_id.Text & "','" & C_name.Text & "','" & C_Brand.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Category Added Successfully", MsgBoxStyle.Information, "Insert")
            con.Close()
            display()
        End If
    End Sub
   
    Private Sub RetriveButton_Click(sender As Object, e As EventArgs) Handles RetriveButton.Click
        display()
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If C_id.Text = "" Or C_name.Text = "" Or C_Brand.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        Else
            con.Open()
            Dim sql = "UPDATE CategoryTbl SET Category_Name='" & C_name.Text & "',Brand='" & C_Brand.Text & "' WHERE Category_ID='" & C_id.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Category Updated Successfully", MsgBoxStyle.Information, "Update")
            con.Close()
            display()
        End If
    End Sub
    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If C_id.Text = "" Or C_name.Text = "" Or C_Brand.Text = "" Then
            MsgBox("Select the row for delete", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim result As DialogResult = MsgBox("You want to delete this category details", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
            If result = Windows.Forms.DialogResult.Yes Then
                Dim sql = "DELETE FROM  CategoryTbl WHERE Category_ID='" & C_id.Text & "'"
                cmd = New SqlCommand(sql, con)
                con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("category Deleted Successfully", MsgBoxStyle.Information, "Delete")
                con.Close()
                display()
                Exit Sub
            ElseIf result = Windows.Forms.DialogResult.No Then
                MsgBox("Operation Cancelled", MsgBoxStyle.Information, "Cancel")
            End If
        End If
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If C_search.Text = "" Then
            MsgBox("Please enter the Category_ID", MsgBoxStyle.Exclamation, "Alert")

        Else
            Con.Open()
            Dim sql = "SELECT * FROM CategoryTbl WHERE Category_ID='" & C_search.Text & "'"
            cmd = New SqlCommand(sql, Con)
            adapter = New SqlDataAdapter(cmd)
            ds = New DataSet
            adapter.Fill(ds)
            CategoryDGV.DataSource = ds.Tables(0)
            Con.Close()

        End If

    End Sub



    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        Me.Hide()
        Home.Show()
    End Sub

  

    Private Sub CategoryDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CategoryDGV.CellContentClick, CategoryDGV.CellClick
        C_id.Text = CategoryDGV.SelectedCells.Item(0).Value.ToString()
        C_name.Text = CategoryDGV.SelectedCells.Item(1).Value.ToString()
        C_Brand.Text = CategoryDGV.SelectedCells.Item(2).Value.ToString()


    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        C_id.Text = ""
        C_name.Text = ""
        C_Brand.Text = ""
        C_search.Text = ""
    End Sub
End Class