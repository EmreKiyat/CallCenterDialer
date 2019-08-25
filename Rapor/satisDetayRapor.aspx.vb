
Partial Class Rapor_satisDetayRapor
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
            If Session("isAdmin") = 1 Then btnExcel.Enabled = True

            'TODO SİL
            ' Session("firmID") = 1

            populateProjectCombo()
            populateAgentCombo(cmbProje.SelectedValue)



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
        '  addTumuForCombos(cmbProje)


    End Sub

    Sub populateAgentCombo(ByVal projeID As Integer)
        Dim agnt As New agents

        If cmbProje.SelectedValue = 0 Then
            cmbAgent.DataSource = Nothing
            cmbAgent.DataBind()

        Else

            Dim dt As Data.DataTable = agnt.getAgentsByProjectForCmb(projeID)
            cmbAgent.DataValueField = "agentID"
            cmbAgent.DataTextField = "adSoyad"
            cmbAgent.DataSource = dt
            cmbAgent.DataBind()

        End If
        addTumuForCombos(cmbAgent)

    End Sub




    Sub addTumuForCombos(ByRef cmb As DropDownList)
        Dim lItem As New ListItem
        lItem.Text = "Tümü"
        lItem.Value = "0"
        lItem.Selected = True
        cmb.Items.Add(lItem)

    End Sub

    Protected Sub cmbProje_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProje.SelectedIndexChanged
        populateAgentCombo(cmbProje.SelectedValue)
    End Sub

    Protected Sub btnRapor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRapor.Click


        Dim datas As New datas
        Dim dt As Data.DataTable
        Dim baslaTarih As String
        Dim bitisTarih As String
 
        Try

            baslaTarih = Mid(txtBasla.Text, 7) + Mid(txtBasla.Text, 4, 2) + Mid(txtBasla.Text, 1, 2) + " 00:01"
            bitisTarih = Mid(txtBitis.Text, 7) + Mid(txtBitis.Text, 4, 2) + Mid(txtBitis.Text, 1, 2) + " 23:59"


            If cmbAgent.SelectedValue = 0 Then
                dt = datas.getSatisDataRapor(cmbProje.SelectedValue, baslaTarih, bitisTarih)

            Else
                dt = datas.getSatisDataRaporByAgent(cmbProje.SelectedValue, cmbAgent.SelectedValue, baslaTarih, bitisTarih)
            End If

            'grdSatisDetay.Columns(0).Visible = True
            grdSatisDetay.Columns(1).Visible = True
            grdSatisDetay.Columns(2).Visible = True

            grdSatisDetay.DataSource = dt
            grdSatisDetay.DataBind()

            'grdSatisDetay.Columns(0).Visible = False
            grdSatisDetay.Columns(1).Visible = False
            grdSatisDetay.Columns(2).Visible = False
            dt.Dispose()


        Catch ex As Exception

        End Try

    End Sub

    Function getSifresizTel(ByVal sifreli As String) As String
        Dim rj As New datas
        Dim sifresiz As String
        If sifreli.Length > 6 Then
            sifresiz = rj.sifreCoz(sifreli)
        Else
            sifresiz = sifreli
        End If
        Return sifresiz
        'Return "aaaaaaaaaa"
    End Function
End Class
