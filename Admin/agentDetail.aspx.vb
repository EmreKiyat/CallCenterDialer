
Partial Class Admin_agentDetail
    Inherits System.Web.UI.Page
    Dim agnt As New agents

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            bindAgentCombo()


        End If
    End Sub

    Sub bindAgentCombo()
        Dim dt As Data.DataTable = agnt.getAllAgentsForCombo(Session("firmID"))
        cmbAgents.DataTextField = "adSoyad"
        cmbAgents.DataValueField = "LoweredEmail"
        cmbAgents.DataSource = dt
        cmbAgents.DataBind()


    End Sub



    Protected Sub btnAgentDetail_Click(sender As Object, e As System.EventArgs) Handles btnAgentDetail.Click


        divDetail.Visible = True
        agentDetail()



    End Sub
    Sub agentDetail()

        Dim u As MembershipUser = Membership.GetUser(cmbAgents.SelectedValue, False)

        'Membership.ValidateUser("xxxx", "xxxx")

        If Not u Is Nothing Then
            lblAdSoyad.Text = u.UserName

            If u.IsOnline Then
                lblStatus.Text = "Online"

                lblStatus.Style.Add(HtmlTextWriterStyle.Color, "#04B404")
            Else
                lblStatus.Text = "Offline"
                lblStatus.Style.Add(HtmlTextWriterStyle.Color, "#DF0101")

            End If


            Dim islockOut As Boolean = u.IsLockedOut
            If islockOut Then
                lblLockDurum.Text = "Şifre kilitlenmiş."
                btnLock.Enabled = True
            Else
                lblLockDurum.Text = "Şifre düzgün, kilitli değil."
                btnLock.Enabled = False
            End If

            If u.IsApproved Then
                lblSistemIcDis.Text = "Onaylı kullanıcı."
                btnUserEngelle.Text = "Sistem girişini engelle"

            Else
                lblSistemIcDis.Text = "Sistem girişi engellenmiş."
                btnUserEngelle.Text = "Yetkilerini iade et"

            End If

        End If
    End Sub
    Protected Sub btnLock_Click(sender As Object, e As System.EventArgs) Handles btnLock.Click
        Dim u As MembershipUser = Membership.GetUser(cmbAgents.SelectedValue, False)

        Dim password As String

        If Not u Is Nothing Then
            u.UnlockUser()
            password = u.GetPassword()
            u.ChangePassword(password, "1111")

            Dim islockOut As Boolean = u.IsLockedOut
            If islockOut Then
                lblLockDurum.Text = "Şifre kilitlenmiş."
                btnLock.Enabled = True
            Else
                lblLockDurum.Text = "Şifre düzgün, kilitli değil."
                btnLock.Enabled = False
            End If

        End If

    End Sub

    Protected Sub btnUserEngelle_Click(sender As Object, e As System.EventArgs) Handles btnUserEngelle.Click
        Dim u As MembershipUser = Membership.GetUser(cmbAgents.SelectedValue, False)


        If Not u Is Nothing Then

            If u.IsApproved Then
                u.IsApproved = False
                agnt.disableAgentByEMail(cmbAgents.SelectedValue)

            Else
                u.IsApproved = True
                agnt.enableAgentByEMail(cmbAgents.SelectedValue)
            End If
            Membership.UpdateUser(u)
            agentDetail()


        End If
    End Sub

    Protected Sub cmbAgents_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbAgents.SelectedIndexChanged
        divDetail.Visible = False
    End Sub
End Class
