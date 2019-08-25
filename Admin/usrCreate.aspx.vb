
Partial Class Admin_usrCreate
    Inherits System.Web.UI.Page

    Dim forKaydol As New forKaydol




    Protected Sub btnProjeEkleAgent_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnProjeEkleAgent.Click
        preparePopup()

        mpe.Show()

    End Sub



    Private Sub preparePopup()
        Dim dt As Data.DataTable
        Dim forP As New proje
        dt = forP.getProjectsByFirm(Session("firmID"), True)

        
        grdProjeForAgent.DataSource = dt
        grdProjeForAgent.DataBind()
        dt.Dispose()
    End Sub


    Protected Sub btnProjeIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProjeIptal.Click
        mpe.Hide()

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        mpe.Hide()
    End Sub

    Protected Sub btnProjeSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProjeSec.Click

        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("projeID")
        dt.Columns.Add("projeTarih")
        dt.Columns.Add("proje")
        dt.Columns.Add("roleID")
        dt.Columns.Add("role")
        Dim i As Integer
        Dim chked As Boolean

        Dim roleID As Integer
        Dim role As String

        With grdProjeForAgent

            For i = 0 To .Rows.Count - 1

                chked = CType(.Rows(i).Cells(5).Controls(1), CheckBox).Checked



                If chked Then
                    roleID = CType(.Rows(i).Cells(6).Controls(1), DropDownList).SelectedValue
                    role = CType(.Rows(i).Cells(6).Controls(1), DropDownList).SelectedItem.Text

                    dr = dt.NewRow
                    dr("projeID") = .Rows(i).Cells(0).Text
                    dr("proje") = .Rows(i).Cells(1).Text
                    dr("projeTarih") = .Rows(i).Cells(2).Text
                    dr("roleID") = roleID
                    dr("role") = role
                    dt.Rows.Add(dr)
                End If

            Next

        End With


        grdProjeAgnt.DataSource = dt
        grdProjeAgnt.DataBind()




        mpe.Hide()


    End Sub

    Protected Sub btnKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKaydet.Click




        Dim aa As MembershipUserCollection

        aa = Membership.FindUsersByEmail(txtEMail.Text.Trim)
        If aa.Count > 0 Then
            lblChkUser.Style.Add(HtmlTextWriterStyle.Color, "#ff0000")
            lblChkUser.Text = "Bu mail adresi kullanılıyor."
            Exit Sub

        End If


        Dim b As MembershipUser
        'Dim isOnline As Boolean = b.IsOnline

        Try
            Dim password As String = "1111" 'Membership.GeneratePassword(4, 0)

            b = Membership.CreateUser(txtEMail.Text.Trim, password, txtEMail.Text.Trim)

            b.IsApproved = True

            Membership.UpdateUser(b)


            '********* araProje ve araSorumlu tableValued data oluşturulması

            Dim dt As New Data.DataTable

            Dim dr As Data.DataRow

            dt.Columns.Add("projeID")
            dt.Columns.Add("roleID")
            dt.Columns.Add("isDefault")


            With grdProjeAgnt
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        dr = dt.NewRow
                        dr("projeID") = .Rows(i).Cells(0).Text
                        dr("roleID") = .Rows(i).Cells(4).Text
                        If i = 0 Then dr("isDefault") = 1 Else dr("isDefault") = 0
                        dt.Rows.Add(dr)
                    Next

                End If

            End With
 

            '*****************************************************************
            Dim isHome As Integer = 0
            If isHomeAgent.Checked Then isHome = 1
            forKaydol.memCreateUser(Session("firmID"), b.ProviderUserKey, isHome, txtAdSoyad.Text.Trim, _
                                     txtKimlikNo.Text.Trim, txtCepTel.Text.Trim, txtEvTel.Text.Trim, txtEMail.Text.Trim, cmbDil.SelectedValue.ToString, _
                                      txtAdres.Text.Trim, txtNot.Text.Trim, dt)

            'Session.Abandon()

            'Server.Transfer("kayitsn.aspx")
            lblChkUser.Style.Add(HtmlTextWriterStyle.Color, "#088A4B")
            lblChkUser.Text = txtAdSoyad.Text.Trim + " kaydedildi."
            emtyFields()

        Catch ex As Exception

            'lblKaydedilmedi.Text = "Başarısız Kayıt. Kayıt işlemin gerçekleşmedi (" + i.ToString + " - " + ex.Message + ")."
            lblChkUser.Style.Add(HtmlTextWriterStyle.Color, "#ff0000")
            lblChkUser.Text = "Başarısız Kayıt. Kayıt işlemin gerçekleşmedi."
        End Try




    End Sub

    Sub emtyFields()
        txtAdres.Text = ""
        txtAdSoyad.Text = ""
        txtCepTel.Text = ""
        txtEMail.Text = ""
        txtEvTel.Text = ""
        txtKimlikNo.Text = ""
        txtNot.Text = ""
        isHomeAgent.Checked = False
        grdProjeAgnt.DataSource = Nothing
        grdProjeAgnt.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim pr As New proje

            Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 3)
            If dt.Rows.Count = 0 And Session("isAdmin") = 0 Then
                ascxUyari.uyar("Admin ya da Proje yöneticisi yetkiniz yok!", "#ff1111", "")
                Exit Sub
            End If

        End If
    End Sub
End Class
