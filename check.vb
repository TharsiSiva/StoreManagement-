Imports System.Data.SqlClient
Public Class check
    Dim Con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub FillProduct()
        Con.Open()
        Dim sql = "select * from ProductTbl"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        ProdIDCb.DataSource = Tbl
        ProdIDCb.DisplayMember = "ProductID"
        ProdIDCb.ValueMember = "ProductID"
        Con.Close()
    End Sub
    Private Sub fetchqty()
        Con.Open()
        Dim sql = "select Quantity from ProductTbl where ProductID='" & ProdIDCb.SelectedValue.ToString() & "'  "
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            MsgBox("AVAILABLE STOCk IS  :" + reader(0).ToString())
        End While
        Con.Close()
    End Sub
    Private Sub check_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillProduct()
    End Sub

    Private Sub ProdnameCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ProdIDCb.SelectionChangeCommitted
        fetchqty()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProdIDCb.Text = ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ProdITCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProdIDCb.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Hide()
    End Sub
End Class