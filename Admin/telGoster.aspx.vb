
Partial Class Admin_telGoster
    Inherits System.Web.UI.Page

    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString
    Dim datas As New datas


    Protected Sub btnAra_Click(sender As Object, e As System.EventArgs) Handles btnAra.Click



        lblUyar.Visible = False
        If txtAdSoyad.Text.Trim.Length < 4 Then
            lblUyar.Visible = True
        End If

        Dim sql As String
        sql = "select distinct d.ad1 + ' ' + d.soyad1 as adSoyad, d.tel1,d.tel2,d.tel3,e.dataPaket "
        sql += "from "
        sql += "tbMain.data d, tbMain.dataExcel e "
        sql += "where d.dataExcelID = e.dataExcelID "
        sql += "and e.firmID=" + Session("firmID").ToString
        sql += "and rtrim(d.ad1 + ' ' + d.soyad1) like '%" + txtAdSoyad.Text.Trim + "%' "
        sql += "order by d.ad1 + ' ' + d.soyad1"

        Dim gnl As New genel
        Dim dt As Data.DataTable = gnl.dataTableVerBana(sql, connStr)

        grdTelNolar.Columns(0).Visible = True
        grdTelNolar.Columns(1).Visible = True
        grdTelNolar.Columns(2).Visible = True

        grdTelNolar.DataSource = dt
        grdTelNolar.DataBind()

        grdTelNolar.Columns(0).Visible = False
        grdTelNolar.Columns(1).Visible = False
        grdTelNolar.Columns(2).Visible = False

        dt = Nothing
        gnl = Nothing

    End Sub

    Sub sessionKontrol()
        If Session.IsNewSession Then
            If IsDBNull(Session("agentID")) Or Session("agentID") = 0 Then
                Session.Abandon()
                FormsAuthentication.SignOut()
                Response.Redirect("~/default.aspx")
            End If
        End If

    End Sub


    Protected Sub grdTelNolar_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTelNolar.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'tel 1
            If e.Row.Cells(0).Text.Length > 6 Then
                e.Row.Cells(5).Text = datas.sifreCoz(e.Row.Cells(0).Text)
            Else
                e.Row.Cells(5).Text = e.Row.Cells(0).Text
            End If
            'tel 2
            If e.Row.Cells(1).Text.Length > 6 Then
                e.Row.Cells(6).Text = datas.sifreCoz(e.Row.Cells(1).Text)
            Else
                e.Row.Cells(6).Text = e.Row.Cells(1).Text
            End If

            'tel 3
            If e.Row.Cells(2).Text.Length > 6 Then
                e.Row.Cells(7).Text = datas.sifreCoz(e.Row.Cells(2).Text)
            Else
                e.Row.Cells(7).Text = e.Row.Cells(2).Text
            End If

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim pr As New proje

        Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 3)
        If dt.Rows.Count = 0 And Session("isAdmin") = 0 Then
            ascxUyari.uyar("Admin ya da Proje yöneticisi yetkiniz yok!", "#ff1111", "")
            btnAra.Enabled = False
        End If

    End Sub
End Class
