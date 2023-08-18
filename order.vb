Imports System.Data.SqlClient
Public Class order
    Dim Con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator\Documents\pharmadbproject.mdf;Integrated Security=True;Connect Timeout=30")
        Private Sub FillProduct()
            Con.Open()
        Dim sql = "select * from ProductTbl"
            Dim cmd As New SqlCommand(sql, Con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim Tbl As New DataTable()
            adapter.Fill(Tbl)
            ProdIdCb.DataSource = Tbl
        ProdIdCb.DisplayMember = "ProductID"
        ProdIdCb.ValueMember = "ProductID"
            Con.Close()
        End Sub
        Private Sub FillCustomer()
            Con.Open()
        Dim sql = "select * from CustomerTbl"
            Dim cmd As New SqlCommand(sql, Con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim Tbl As New DataTable()
            adapter.Fill(Tbl)
            CustIdCb.DataSource = Tbl
        CustIdCb.DisplayMember = "CustId"
        CustIdCb.ValueMember = "CustId"
            Con.Close()
    End Sub

        Private Sub FetchName()
            Con.Open()
        Dim query = "select * from CustomerTbl where CustId=" & CustIdCb.SelectedValue.ToString() & ""
            Dim cmd As New SqlCommand(query, Con)
            Dim dt As New DataTable
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
       While reader.Read
            CustNameTb.Text = reader(1).ToString()
        End While
        Con.Close()
        End Sub
        Dim prodname As String
        Dim prodprice As Integer
        Dim AvailprodQty As Integer
        Private Sub FetchData()
            Con.Open()
        Dim query = "select * from ProductTbl where ProductID=" & ProdIdCb.SelectedValue & ""
            Dim cmd As New SqlCommand(query, Con)
            Dim dt As New DataTable
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While reader.Read
            prodname = reader(1).ToString()
            prodprice = reader(3).ToString()
                AvailprodQty = Convert.ToInt32(reader(2).ToString())
                ProdNameTb.Text = prodname
            End While
            Con.Close()
        End Sub
    Public Sub populate()
        Con.Open()
        Dim sql = "select * from OrderTb"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        OrderDGV.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
        Private Sub Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            FillProduct()
            FillCustomer()
            populate()
        End Sub

        Private Sub CustIdCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CustIdCb.SelectionChangeCommitted
            FetchName()
        End Sub

        Private Sub ProdIdCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ProdIdCb.SelectionChangeCommitted
            FetchData()
        End Sub
        Dim newQty
        Private Sub Updateprod()
            newQty = AvailprodQty - Convert.ToInt32(QuantityTb.Text)
            Con.Open()
        Dim sql = "update ProductTb set Quantity=" & newQty & " where ProductID=" & ProdIdCb.SelectedItem.ToString() & ""
            Dim cmd As New SqlCommand(sql, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
            populate()

        End Sub
        Dim Grtot = 0, i = 0, Total = 0
        
    

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
         e.Graphics.DrawString("MS VISION PHARMA", New Font("Times New Roman", 34, FontStyle.Bold), Brushes.MidnightBlue, 210, 80)

        Dim bm As New Bitmap(Me.BillDGV.Width, Me.BillDGV.Height)
        BillDGV.DrawToBitmap(bm, New Rectangle(0, 0, 1100, 2000))
        e.Graphics.DrawImage(bm, 155, 200)
        e.Graphics.DrawString("TOTAL AMOUNT Rs" + Grtot.ToString, New Font("Times New Roman", 26, FontStyle.Bold), Brushes.DarkGreen, 250, 450)
        e.Graphics.DrawString("Thanks For Getting Orders From Us", New Font("Times New Roman", 32, FontStyle.Bold), Brushes.DarkGoldenrod, 115, 500)
        e.Graphics.DrawString("STAY SAFE", New Font("Century Gothic", 28, FontStyle.Bold), Brushes.DarkRed, 320, 580)
    End Sub


    Dim available
    Private Sub fetchqty()
        Con.Open()
        Dim sql = "select Quantity from ProductTbl where ProductID='" & ProdIdCb.SelectedValue.ToString() & "'  "
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            available = reader(0)
        End While
        Con.Close()
    End Sub
    Private Sub Addbillbtn_Click(sender As Object, e As EventArgs) Handles Addbillbtn.Click
        fetchqty()
        Dim i = 0
        If QuantityTb.Text > available Then
            MsgBox("No Enought in Stock")
        ElseIf QuantityTb.Text = "" Then
            MsgBox("Enter a Quantity")

        Else
            Dim rnum As Integer = BillDGV.Rows.Add()
            i = i + 1
            Total = prodprice * Convert.ToInt32(QuantityTb.Text)
            BillDGV.Rows.Item(rnum).Cells("column1").Value = i
            BillDGV.Rows.Item(rnum).Cells("column2").Value = ProdNameTb.Text
            BillDGV.Rows.Item(rnum).Cells("column3").Value = prodprice
            BillDGV.Rows.Item(rnum).Cells("column4").Value = QuantityTb.Text
            BillDGV.Rows.Item(rnum).Cells("column5").Value = Total

            Grtot = Grtot + Total
            Amountlbl.Text = Grtot

        End If
    End Sub

    Private Sub insertbillbtn_Click(sender As Object, e As EventArgs) Handles insertbillbtn.Click
        If CustNameTb.Text = "" Then
            MsgBox("select Customer Name")
        Else
            Try
                Con.Open()
                Dim query As String
                query = "insert into OrderTb values(" & OrderId.Text & "," & CustIdCb.SelectedValue.ToString() & ",'" & CustNameTb.Text & "','" & Amountlbl.Text & "','" & DateTimePicker1.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Order Added Successfully")
                Con.Close()
                populate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub printbtn_Click(sender As Object, e As EventArgs) Handles printbtn.Click
        PrintPreviewDialog1.Show()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        OrderId.Text = ""
        CustIdCb.Text = ""
        CustNameTb.Text = ""
        ProdIdCb.Text = ""
        ProdNameTb.Text = ""
        QuantityTb.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        homeproduct.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        check.Show()
    End Sub
End Class
