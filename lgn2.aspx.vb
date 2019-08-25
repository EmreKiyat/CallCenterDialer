
Partial Class lgn2
    Inherits System.Web.UI.Page

    Protected Sub b1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b1.Click
        If (Membership.ValidateUser(t1.Text, t2.Text)) Then

            If chkKuKi.Checked Then setKuki()

            FormsAuthentication.RedirectFromLoginPage(t1.Text, chkKuKi.Checked)

        Else
            lblMsg.Text = "Yanlış kullanıcı ya da şifre!"
        End If
    End Sub

    Sub setKuki()

        Dim ticket As New FormsAuthenticationTicket(1, _
        t1.Text, _
        DateAdd(DateInterval.Hour, 3, Date.UtcNow), _
        DateAdd(DateInterval.Hour, 3, Date.UtcNow).AddDays(330), _
        chkKuKi.Checked, _
        String.Empty, _
        FormsAuthentication.FormsCookiePath)

        Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)

        Dim authCookie9923 As New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)


        Response.Cookies.Add(authCookie9923)

    End Sub

    'Protected Sub lnkParolaUnut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkParolaUnut.Click
    '    Dim u As MembershipUser = Membership.GetUser(t1.Text.Trim, False)

    '    Dim password As String

    '    If Not u Is Nothing Then

    '        password = u.GetPassword()
    '        u.ChangePassword(password, "1111")
    '        'password = u.ResetPassword()


    '        ' parolaMail(u.Email, password)
    '        lblMsg.Text = "Parolanız '1111' olarak değiştirildi, sisteme ilk girişinizde parolanızı değiştirmeniz beklenecektir."
    '    Else
    '        lblMsg.Text = "bu mail adresi ile tanımlı bir kullanıcı yok, e-posta adresini kontrol et."
    '    End If

    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim dd As New datas
        'Dim asaa As String = dd.sifreCoz("OTgJ7/pQZdwgn94rdHS9Gg==")



        If Not IsPostBack Then
            ''Dim userIPAddress As String = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

            ''If String.IsNullOrEmpty(userIPAddress) Then
            ''    userIPAddress = Request.ServerVariables("REMOTE_ADDR")
            ''End If

            ''If userIPAddress.StartsWith("111.111.111") Or userIPAddress.StartsWith("444.444.44") Then


            ''End If

            b1.Attributes.Add("onClick", "return verifyGiris();")
            t1.Attributes.Add("onkeypress", "return msgTemizle();")
            t2.Attributes.Add("onkeypress", "return msgTemizle();")
            t1.Focus()
        End If


    End Sub
End Class
