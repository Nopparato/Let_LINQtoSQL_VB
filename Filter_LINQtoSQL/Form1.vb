Option Explicit On
Option Strict On
Public Class Form1

    Dim db As New dbNorthwindDataContext()
    Dim IProduct As IQueryable(Of Product)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IProduct = From p In db.Products
        dgvProduct.DataSource = IProduct.ToList()
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim ps = From p In IProduct
                 Where (p.ProductID.ToString().Contains(txtFilter.Text.Trim()) OrElse p.ProductName.Contains(txtFilter.Text.Trim()))
        If ps.Count() > 0 Then
            dgvProduct.DataSource = ps.ToList()
        Else
            dgvProduct.DataSource = Nothing
            MessageBox.Show("เงื่อนไขที่คุณระบุไม่มี !!", "ผลการกรองข้อมูล", MessageBoxButtons.OK)
            txtFilter.Text = ""
            txtFilter.Focus()
        End If
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        dgvProduct.DataSource = IProduct.ToList()
    End Sub
End Class
