
Partial Class parolaDegis
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            txtParola1.Text = ""
            txtParola2.Text = ""
            mpePassword.Show()
        End If
    End Sub



    Protected Sub btnPasswordCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPasswordCancel.Click
        Session.Abandon()
        FormsAuthentication.SignOut()
        mpePassword.Hide()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub btnPasswordTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPasswordTamam.Click

        If txtParola1.Text.Trim <> txtParola2.Text.Trim Then
            lblStatus.Text = "Parola tutarsız, tekrar deneyin!"
            Exit Sub
        End If
        If txtParola1.Text.Trim.Length < 4 Then
            lblStatus.Text = "Parolanız en az 4 karakter olmalıdır!"
            Exit Sub
        End If

        Dim u As MembershipUser = Membership.GetUser()
        u.ChangePassword("1111", txtParola1.Text.Trim)
        lblStatus.Text = ""
        lblPassSonuc.Text = "Parolanız başarıyla değiştirildi, Lütfen tekrar giriş yapınız!"
        Session.Abandon()
        FormsAuthentication.SignOut()

        'lnkSistemeDon.Enabled = True
        mpePassword.Hide()
    End Sub


End Class
