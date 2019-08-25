
Partial Class midPage
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

        If Not IsPostBack Then

            Dim agt As New agents
            Dim pr As New proje

            Dim MemUser As MembershipUser
            MemUser = Membership.GetUser()

            If MemUser.GetPassword = "1111" Then
                Server.Transfer("./parolaDegis.aspx")
            End If

            Dim userID As Guid = MemUser.ProviderUserKey
            Dim dt As Data.DataTable = agt.getAgentInformation(userID)

            If dt.Rows.Count > 0 Then

                Session("firmID") = dt.Rows(0).Item("firmID")
                Session("agentID") = dt.Rows(0).Item("agentID")
                Session("adSoyad") = dt.Rows(0).Item("adSoyad")     'login olan agentin
                Session("isAdmin") = dt.Rows(0).Item("isAdmin")
                Session("isYenilemeProjesi") = 0

                dt = pr.getProjectsByUser(Session("firmID"), Session("agentID"), True)
                
                If Session("isAdmin") = 1 Then

                    Response.Redirect("./Admin/projeIzle.aspx")

                Else


                    Select Case dt.Rows(0).Item("roleID")
                        Case 1  'agent
                            Response.Redirect("./agnt/agentDef2.aspx")
                        Case 2
                            Response.Redirect("./agnt/kontroller.aspx")
                        Case 3
                            Response.Redirect("~/Admin/projeIzle.aspx")




                    End Select

                End If
            Else
                ' Response.Redirect("sil.htm")
                'lblTest.Text = "-101010"
                lblThereIsNoUser.Text = "Kullanıcı kaydınız bulunamadı, lütfen sistem sorumlusuyla görüşünüz."
                Session.Abandon()
                dt.Dispose()
            End If



        End If

    End Sub



End Class
