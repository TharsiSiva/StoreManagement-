﻿Public Class pharmaloading

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Dim percentage As String
        percentage = Convert.ToString(ProgressBar1.Value)
        Percentagerlb.Text = percentage + "%"
        If ProgressBar1.Value = 100 Then
            Me.Hide()
            Dim login = New login
            mainlogin.Show()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class
