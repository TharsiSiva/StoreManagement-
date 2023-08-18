Imports System.Data.SqlClient
Public Class product
    Dim Con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
    Dim adapter As SqlDataAdapter
    Dim builder As SqlCommandBuilder
    Dim ds As DataSet
    Dim cmd As SqlCommand
    Public Sub display()
        Con.Open()
        Dim sql = "SELECT * FROM ProductTbl"
        adapter = New SqlDataAdapter(sql, Con)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet
        adapter.Fill(ds)
        ProductDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub ProductDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDGV.CellClick
        P_id.Text = ProductDGV.SelectedCells.Item(0).Value.ToString()
        P_name.Text = ProductDGV.SelectedCells.Item(1).Value.ToString()
        P_qua.Text = ProductDGV.SelectedCells.Item(2).Value.ToString()
        P_pri.Text = ProductDGV.SelectedCells.Item(3).Value.ToString()
        P_des.Text = ProductDGV.SelectedCells.Item(4).Value.ToString()
        P_cat.Text = ProductDGV.SelectedCells.Item(5).Value.ToString()



    End Sub
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        If P_id.Text = "" Or P_name.Text = "" Or P_qua.Text = "" Or P_pri.Text = "" Or P_des.Text = "" Or P_cat.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        Else
            Try
                Con.Open()
                Dim sql = "INSERT INTO ProductTbl values('" & P_id.Text & "','" & P_name.Text & "'," & P_qua.Text & "," & P_pri.Text & ",'" & P_des.Text & "','" & P_cat.Text & " ')"
                cmd = New SqlCommand(sql, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Product Added Successfully", MsgBoxStyle.Information, "Insert")
                Con.Close()
                display()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        
    End Sub
   
    Private Sub RetriveButton_Click(sender As Object, e As EventArgs) Handles RetriveButton.Click
        display()
    End Sub
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If P_id.Text = "" Or P_name.Text = "" Or P_qua.Text = "" Or P_pri.Text = "" Or P_des.Text = "" Or P_cat.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim m As Integer
            m = ProductDGV.SelectedCells.Item(2).Value.ToString()
            Dim sql = "UPDATE ProductTbl SET ProductID='" & P_id.Text & "',ProductName='" & P_name.Text & "',Quantity=" & m + P_qua.Text & ",Price=" & P_pri.Text & ",Description='" & P_des.Text & "',Category='" & P_cat.Text & " 'WHERE ProductID='" & P_id.Text & "'"
            cmd = New SqlCommand(sql, Con)
            Con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Product Updated Successfully", MsgBoxStyle.Information, "Update")
            Con.Close()
            display()
        End If
    End Sub
    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If P_id.Text = "" Or P_name.Text = "" Or P_qua.Text = "" Or P_pri.Text = "" Or P_des.Text = "" Or P_cat.Text = "" Then
            MsgBox("Select the row for delete", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim result As DialogResult = MsgBox("You want to delete this Product details", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
            If result = Windows.Forms.DialogResult.Yes Then
                Dim sql = "DELETE FROM ProductTbl WHERE ProductID='" & P_id.Text & "'"
                cmd = New SqlCommand(sql, Con)
                Con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Product Deleted Successfully", MsgBoxStyle.Information, "Delete")
                Con.Close()
                display()
                Exit Sub
            ElseIf result = Windows.Forms.DialogResult.No Then
                MsgBox("Operation Cancelled", MsgBoxStyle.Information, "Cancel")
            End If
        End If

    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If P_search.Text = "" Then
            MsgBox("Please enter the user_ID", MsgBoxStyle.Exclamation, "Alert")

        Else
            Con.Open()
            Dim sql = "SELECT * FROM ProductTbl WHERE ProductID='" & P_search.Text & "'"
            cmd = New SqlCommand(sql, Con)
            adapter = New SqlDataAdapter(cmd)
            ds = New DataSet
            adapter.Fill(ds)
            ProductDGV.DataSource = ds.Tables(0)
            Con.Close()

        End If

    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        P_id.Text = ""
        P_name.Text = ""
        P_qua.Text = ""
        P_pri.Text = ""
        P_des.Text = ""
        P_cat.Text = ""
        P_search.Text = ""
    End Sub
    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        Me.Hide()
        homeproduct.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If P_id.Text = "" Or P_name.Text = "" Or P_qua.Text = "" Or P_pri.Text = "" Or P_des.Text = "" Or P_cat.Text = "" Then
            MsgBox("Incomplete Data", MsgBoxStyle.Exclamation, "Alert")
        Else
            Dim sql = "UPDATE ProductTbl SET ProductID='" & P_id.Text & "',ProductName='" & P_name.Text & "',Quantity=" & P_qua.Text & ",Price=" & P_pri.Text & ",Description='" & P_des.Text & "',Category='" & P_cat.Text & " 'WHERE ProductID='" & P_id.Text & "'"
            cmd = New SqlCommand(sql, Con)
            Con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Product Edited Successfully", MsgBoxStyle.Information, "Edit")
            Con.Close()
            display()
        End If
    End Sub

  
    Private Sub product_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class