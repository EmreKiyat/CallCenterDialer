
Partial Class Rapor_satisAgentRapor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Dim pr As New proje

            Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 3)
            If dt.Rows.Count = 0 And Session("isAdmin") = 0 Then
                ascxUyari.uyar("Admin ya da Proje yöneticisi yetkiniz yok!", "#ff1111", "")
                Exit Sub
            End If


            calBasla.SelectedDate = Today
            calBitis.SelectedDate = Today
            txtBasla.Text = calBasla.SelectedDate
            txtBitis.Text = calBitis.SelectedDate
            
            populateProjectCombo()




        End If
    End Sub


    Sub populateProjectCombo()
        Dim rpr As New proje
        Dim dt As Data.DataTable
        dt = rpr.getProjectsByFirmForCmb(Session("firmID"), 1)

        cmbProje.DataTextField = "proje"
        cmbProje.DataValueField = "projeID"
        cmbProje.DataSource = dt
        cmbProje.DataBind()

    End Sub

    Protected Sub btnRapor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRapor.Click

        Dim agnt As New agents

        Dim baslaTarih As String
        Dim bitisTarih As String
        Dim dt As Data.DataTable

        baslaTarih = Mid(txtBasla.Text, 7) + Mid(txtBasla.Text, 4, 2) + Mid(txtBasla.Text, 1, 2) + " 00:01"
        bitisTarih = Mid(txtBitis.Text, 7) + Mid(txtBitis.Text, 4, 2) + Mid(txtBitis.Text, 1, 2) + " 23:59"

        dt = agnt.getAgentsByProjectByDate(cmbProje.SelectedValue, baslaTarih, bitisTarih)

        grdAgentSatis.DataSource = dt
        grdAgentSatis.DataBind()

    End Sub

    Protected Sub grdAgentSatis_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgentSatis.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            
            Dim rol As Integer = CInt(e.Row.Cells(2).Text)
            Dim isHome As Integer = CInt(e.Row.Cells(5).Text)
            Dim isAktif As Integer = CInt(e.Row.Cells(1).Text)
            Dim isAktifInFirm As Integer = CInt(e.Row.Cells(3).Text)
            Dim a1 As Integer = 0
            Dim a2 As Integer = 0
            Dim b1 As Integer = 0
            Dim b2 As Integer = 0

            
            Select Case rol
                Case 1
                    e.Row.Cells(3).Text = "Agent"
                Case 2
                    e.Row.Cells(3).Text = "Kontrol"
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FCFCE9")
                Case 3
                    e.Row.Cells(3).Text = "Pr.Srmlu"
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#C9E2E9")
                Case Else
                    e.Row.Cells(3).Text = "?"
            End Select

            If (isAktif + isAktifInFirm) < 2 Then
                e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#dddddd")
            End If


            If isHome = 1 Then
                Dim img As New Image
                img.ImageUrl = "..\images\home.png"
                img.AlternateText = "Home Agnt"
                img.ToolTip = "Home Agent"
                e.Row.Cells(7).Controls.Add(img)
            Else
                e.Row.Cells(7).Text = "-"
            End If



            a1 = CInt(e.Row.Cells(11).Text) 'onaysız
            a2 = CInt(e.Row.Cells(12).Text) 'onaylı
            e.Row.Cells(13).Text = (a1 + a2).ToString 'proje Toplam

            a1 = CInt(e.Row.Cells(15).Text)
            a2 = CInt(e.Row.Cells(16).Text)
            e.Row.Cells(17).Text = (a1 + a2).ToString 'belirtilen tarihlerde proje Toplam


        End If


    End Sub

    Protected Sub cmbProje_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbProje.SelectedIndexChanged
        Dim dt As Data.DataTable
        dt = Nothing
        grdAgentSatis.DataSource = dt
        grdAgentSatis.DataBind()

    End Sub
End Class
