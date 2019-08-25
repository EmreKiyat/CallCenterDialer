
Partial Class Master_ttAdmin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sts As New satis
            imgLogoM.ImageUrl = "../images/logo/" + sts.getLogo(Session("firmID"))
            lblAgentAdSoyad.Text = Session("adSoyad")

            Dim pr As New proje
            Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 3)

            If Session("isAdmin") = 0 And dt.Rows.Count = 0 Then
                lnkDataYukle.Enabled = False
                lnkProjeCreate.Enabled = False
                lnkKarakterTemizle.Enabled = False
                lnkAgentCreate.Enabled = False
                lnkProjeIzle.Enabled = False
                lnkTelBul.Enabled = False

            End If
        End If
    End Sub

    Protected Sub lnkDataYukle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDataYukle.Click
        Server.Transfer("~/Admin/excelUpload.aspx")
    End Sub

    Protected Sub lnkProjeCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProjeCreate.Click
        Server.Transfer("~/Admin/projeCreate.aspx")
    End Sub

    Protected Sub lnkAgentCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAgentCreate.Click
        Server.Transfer("~/Admin/usrCreate.aspx")
    End Sub

    Protected Sub lnkProjeIzle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProjeIzle.Click
        Server.Transfer("~/Admin/projeIzle.aspx")
    End Sub

    Protected Sub lnkTelBul_Click(sender As Object, e As System.EventArgs) Handles lnkTelBul.Click
        Server.Transfer("~/Admin/telGoster.aspx")
    End Sub


    Protected Sub lnkKarakterTemizle_Click(sender As Object, e As System.EventArgs) Handles lnkKarakterTemizle.Click
        Server.Transfer("~/Admin/ozelKarakterTemizle.aspx")
    End Sub

    Protected Sub lnkAgentDetail_Click(sender As Object, e As System.EventArgs) Handles lnkAgentDetail.Click
        Server.Transfer("~/Admin/agentDetail.aspx")
    End Sub
End Class

