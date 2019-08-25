

Partial Class Master_tt
    Inherits System.Web.UI.MasterPage



    'Protected Sub btnTR_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTR.Click

    '    Dim ss As String ' = Request.Url.ToString()
    '    ss = Request.Url.AbsolutePath

    '    'ss = Request.Url.PathAndQuery
    '    Response.Redirect(ss + "?lng=tr-TR")
    '    ' lblLangHidden.Text = "tr-TR"
    'End Sub

    'Protected Sub btnEn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEn.Click
    '    'lblLangHidden.Text = "en-US"
    '    Dim ss As String = Request.Url.AbsolutePath
    '    Response.Redirect(ss + "?lng=en-US")
    'End Sub




    Protected Sub btnCik_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCik.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("~/default.aspx")

    End Sub
End Class

