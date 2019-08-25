
Partial Class ascx_uyari
    Inherits System.Web.UI.UserControl


    Public Sub uyar(ByVal uStr As String, ByVal colorCode As String, ByVal imaj As String)
        lblUyari.Text = uStr
        If imaj <> "" Then imgUyari.ImageUrl = imaj
        lblUyari.ForeColor = Drawing.Color.FromName(imaj)
        mpeUyari.Show()

    End Sub

    Protected Sub btnUTmm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUTmm.Click
        mpeUyari.Hide()
    End Sub

    Protected Sub btnCancelU_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelU.Click
        mpeUyari.Hide()
    End Sub
End Class
