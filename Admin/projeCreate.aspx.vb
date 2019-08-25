Imports System.Data.SqlClient

Partial Class Admin_projeCreate
    Inherits System.Web.UI.Page

    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString



    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        mpeAgnt.Hide()

    End Sub

    Protected Sub btnAgentIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentIptal.Click
        mpeAgnt.Hide()

    End Sub


    Protected Sub btnAgentSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentSec.Click


        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("agentID")
        dt.Columns.Add("adSoyad")
        dt.Columns.Add("roleID")
        dt.Columns.Add("role")
        dt.Columns.Add("isHomeAgent")
        Dim i As Integer
        Dim chked As Boolean
        Dim numOfAgnt As Integer = 0
        Dim numOfCont As Integer = 0
        Dim numOfSrmlu As Integer = 0
        Dim roleID As Integer

        With grdAgentForProje

            For i = 0 To .Rows.Count - 1

                chked = CType(.Rows(i).Cells(5).Controls(1), CheckBox).Checked

                If chked Then
                    roleID = CType(.Rows(i).Cells(7).Controls(1), DropDownList).SelectedValue
                    Select Case roleID
                        Case 1
                            numOfAgnt += 1
                        Case 2
                            numOfCont += 1
                        Case 3
                            numOfSrmlu += 1

                    End Select

                    dr = dt.NewRow
                    dr("agentID") = .Rows(i).Cells(0).Text
                    dr("adSoyad") = .Rows(i).Cells(1).Text
                    dr("roleID") = roleID
                    dr("role") = CType(.Rows(i).Cells(7).Controls(1), DropDownList).SelectedItem.Text
                    dr("isHomeAgent") = .Rows(i).Cells(3).Text
                    dt.Rows.Add(dr)
                End If

            Next

            grdAgntProje.Columns(0).Visible = True
            grdAgntProje.Columns(2).Visible = True

            grdAgntProje.DataSource = dt
            grdAgntProje.DataBind()

            grdAgntProje.Columns(0).Visible = False
            grdAgntProje.Columns(2).Visible = False

            grdAgntProje.ToolTip = "Agent: " + numOfAgnt.ToString + ", Kontroller: " + numOfCont.ToString + ", Proje Sorumlusu: " + numOfSrmlu.ToString

            mpeAgnt.Hide()
        End With

    End Sub

    Protected Sub grdAgntProje_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgntProje.RowCreated
        ' e.Row.Cells(0).Visible = False
    End Sub

    Protected Sub grdAgntProje_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgntProje.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim rol As Integer = CInt(e.Row.Cells(2).Text)
            Dim isHome As Integer = CInt(e.Row.Cells(4).Text)
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


            If isHome = 1 Then
                Dim img As New Image
                img.ImageUrl = "..\images\home.png"
                img.AlternateText = "Home Agnt"
                img.ToolTip = "Home Agent"
                e.Row.Cells(4).Controls.Add(img)

            Else

                e.Row.Cells(4).Text = "-"
            End If


        End If

    End Sub

    Protected Sub grdAgentForProje_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgentForProje.RowCreated
        'e.Row.Cells(0).Visible = False
        'e.Row.Cells(4).Visible = False


    End Sub

    Protected Sub grdAgentForProje_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgentForProje.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then


            'Dim rol As Integer = CInt(e.Row.Cells(3).Text)
            Dim isHome As Integer = CInt(e.Row.Cells(3).Text)
            Dim numOfProje As Integer = CInt(e.Row.Cells(6).Text)   'agent üzerine tanımlı proje sayısı - 0 olanları öne getirip color'unu green yapar

            If numOfProje = 0 Then
                e.Row.BackColor = Drawing.Color.FromName("#eeffcc")
            End If

            'daha önce seçilmiş agentleri ve rollerini default getirmek için
            Dim i As Integer
            For i = 0 To grdAgntProje.Rows.Count - 1
                If e.Row.Cells(0).Text = grdAgntProje.Rows(i).Cells(0).Text Then
                    CType(e.Row.Cells(5).Controls(1), CheckBox).Checked = True
                    CType(e.Row.Cells(7).Controls(1), DropDownList).SelectedIndex = CInt(grdAgntProje.Rows(i).Cells(2).Text) - 1

                End If
            Next

            '********************

            If isHome = 1 Then
                Dim img As New Image
                img.ImageUrl = "..\images\home.png"
                img.AlternateText = "Home Agnt"
                img.ToolTip = "Home Agent"
                e.Row.Cells(4).Controls.Add(img)

            End If

        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            grdAgntProje.DataSource = Nothing
            grdAgntProje.DataBind()

            grdDataProje.DataSource = Nothing
            grdDataProje.DataBind()

            grdSatisPaket.DataSource = Nothing
            grdSatisPaket.DataBind()

        End If

    End Sub



    Protected Sub btnAssist_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAssist.Click
        ascxAssist.Show()
        Dim assistBasla As String
        With ascxAssist.Controls(2).Controls(1).Controls(0).Controls(1)
            assistBasla = CType(.FindControl("txtBasla"), TextBox).Text
            If assistBasla.Length > 4 Then lblGiris.ForeColor = Drawing.Color.Blue
        End With

    End Sub

    Protected Sub btnKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKaydet.Click


        If chkSelfController.SelectedIndex < 0 Then
            ascxUyari.uyar("Kontroller türünü seçmelisiniz. Kayıt iptal edildi!", "#ff5545", "")
            Exit Sub
        End If

        If txtProjeAdi.Text.Trim.Length < 2 Then
            ascxUyari.uyar("Bir proje adı girmelisiniz. Kayıt iptal edildi!", "#ff5545", "")
            Exit Sub
        End If


        Dim assistBasla As String
        Dim assistKey1 As String
        Dim assistKey2 As String
        Dim assistKey3 As String
        Dim assistKey4 As String
        Dim assistKey5 As String
        Dim assistKey6 As String
        Dim assistKey7 As String
        Dim assistKey8 As String
        Dim assistKey9 As String
        Dim assistKey10 As String
        Dim assistChkPaket As Integer = 1
        Dim assistSon As String

        With ascxAssist.Controls(2).Controls(1).Controls(0).Controls(1)
            assistBasla = CType(.FindControl("txtBasla"), TextBox).Text.Trim
            assistKey1 = CType(.FindControl("txtKP1"), TextBox).Text.Trim
            assistKey2 = CType(.FindControl("txtKP2"), TextBox).Text.Trim
            assistKey3 = CType(.FindControl("txtKP3"), TextBox).Text.Trim
            assistKey4 = CType(.FindControl("txtKP4"), TextBox).Text.Trim
            assistKey5 = CType(.FindControl("txtKP5"), TextBox).Text.Trim
            assistKey6 = CType(.FindControl("txtKP6"), TextBox).Text.Trim
            assistKey7 = CType(.FindControl("txtKP7"), TextBox).Text.Trim
            assistKey8 = CType(.FindControl("txtKP8"), TextBox).Text.Trim
            assistKey9 = CType(.FindControl("txtKP9"), TextBox).Text.Trim
            assistKey10 = CType(.FindControl("txtKP10"), TextBox).Text.Trim
            assistChkPaket = IIf(CType(.FindControl("chkSatisPaket"), CheckBox).Checked, 1, 0)
            assistSon = CType(.FindControl("txtKapanis"), TextBox).Text.Trim
        End With


        Dim dtEkip As Data.DataTable = getEkipFromGrid()
        Dim dtDataPaket As Data.DataTable = getDataPaketFromGrid()
        Dim dtSatisPaket As Data.DataTable = getSatisPaketFromGrid()
        Dim dtSatisFields As Data.DataTable = getSatisFieldFromGrid()

        If dtSatisPaket.Rows.Count < 1 Then
            ascxUyari.uyar("En az 1 satış paketi tanımlamalısın! Kayıt iptal edildi!", "#ff5545", "")
            Exit Sub
        End If


        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.createProje"



        cmd.Parameters.AddWithValue("@ekip", dtEkip)
        cmd.Parameters.AddWithValue("@dataPaket", dtDataPaket)
        cmd.Parameters.AddWithValue("@satisPaket", dtSatisPaket)
        cmd.Parameters.AddWithValue("@satisFields", dtSatisFields)

        cmd.Parameters.AddWithValue("@projeAdi", txtProjeAdi.Text.Trim)
        cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text.Trim)
        cmd.Parameters.AddWithValue("@selfController", chkSelfController.SelectedValue)
        cmd.Parameters.AddWithValue("@assistGiris", assistBasla)
        cmd.Parameters.AddWithValue("@assistPaketGoster", assistChkPaket)
        cmd.Parameters.AddWithValue("@key1", assistKey1)
        cmd.Parameters.AddWithValue("@key2", assistKey2)
        cmd.Parameters.AddWithValue("@key3", assistKey3)
        cmd.Parameters.AddWithValue("@key4", assistKey4)
        cmd.Parameters.AddWithValue("@key5", assistKey5)
        cmd.Parameters.AddWithValue("@key6", assistKey6)
        cmd.Parameters.AddWithValue("@key7", assistKey7)
        cmd.Parameters.AddWithValue("@key8", assistKey8)
        cmd.Parameters.AddWithValue("@key9", assistKey9)
        cmd.Parameters.AddWithValue("@key10", assistKey10)

        cmd.Parameters.AddWithValue("@assistKapa", assistSon)
        cmd.Parameters.AddWithValue("@agentID", Session("agentID"))           'admin kişisinin kullanıcı id'si si
        cmd.Parameters.AddWithValue("@firmID", Session("firmID"))
        cmd.Parameters.AddWithValue("@paraBirimi", radioParaBirimi.SelectedValue)

        cmd.ExecuteNonQuery()

        conn.Close()
        cmd.Dispose()

    End Sub

    Function getEkipFromGrid() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        Dim dtt0 As Data.DataColumn = New Data.DataColumn("userID", System.Type.GetType("System.Int32"))
        Dim dtt1 As Data.DataColumn = New Data.DataColumn("roleID", System.Type.GetType("System.Int32"))

        dt.Columns.Add(dtt0)
        dt.Columns.Add(dtt1)

        Dim i As Integer
        With grdAgntProje
            For i = 0 To .Rows.Count - 1
                dr = dt.NewRow
                dr(0) = CInt(.Rows(i).Cells(0).Text)
                dr(1) = CInt(.Rows(i).Cells(2).Text)
                dt.Rows.Add(dr)
            Next

        End With

        Return dt
    End Function

    Function getDataPaketFromGrid() As Data.DataTable
        Dim dt As New Data.DataTable

        Dim dr As Data.DataRow

        Dim dtt0 As Data.DataColumn = New Data.DataColumn("ID", System.Type.GetType("System.Int32"))

        dt.Columns.Add(dtt0)

        Dim i As Integer
        '  With grdDataPaket
        With grdDataProje
            For i = 0 To .Rows.Count - 1
                dr = dt.NewRow
                dr(0) = CInt(.Rows(i).Cells(0).Text)
                dt.Rows.Add(dr)
            Next

        End With

        Return dt
    End Function


    Function getSatisFieldFromGrid() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        Dim dtt0 As Data.DataColumn = New Data.DataColumn("fieldAd", System.Type.GetType("System.String"))
        Dim dtt1 As Data.DataColumn = New Data.DataColumn("isSifre", System.Type.GetType("System.Int32"))
        Dim dtt2 As Data.DataColumn = New Data.DataColumn("isSilAfterSale", System.Type.GetType("System.Int32"))


        dt.Columns.Add(dtt0)
        dt.Columns.Add(dtt1)
        dt.Columns.Add(dtt2)


        Dim i As Integer
        Dim isSifre As Integer
        Dim isGecici As Integer
        With grdSatisFields
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(1).Text = "Şifreli" Then isSifre = 1 Else isSifre = 0
                If .Rows(i).Cells(2).Text = "Gecici" Then isGecici = 1 Else isGecici = 0

                dr = dt.NewRow
                dr(0) = .Rows(i).Cells(0).Text
                dr(1) = isSifre
                dr(2) = isGecici

                dt.Rows.Add(dr)
            Next

        End With
        Return dt
    End Function
    Function getSatisPaketFromGrid() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        Dim dtt0 As Data.DataColumn = New Data.DataColumn("paketAdi", System.Type.GetType("System.String"))
        Dim dtt1 As Data.DataColumn = New Data.DataColumn("paketAciklama", System.Type.GetType("System.String"))
        Dim dtt2 As Data.DataColumn = New Data.DataColumn("birimFiyat", System.Type.GetType("System.Double"))
        Dim dtt3 As Data.DataColumn = New Data.DataColumn("toplamFiyat", System.Type.GetType("System.Double"))
        Dim dtt4 As Data.DataColumn = New Data.DataColumn("yenilemePeriod", System.Type.GetType("System.Int32"))

        dt.Columns.Add(dtt0)
        dt.Columns.Add(dtt1)
        dt.Columns.Add(dtt2)
        dt.Columns.Add(dtt3)
        dt.Columns.Add(dtt4)

        Dim i As Integer
        With grdSatisPaket
            For i = 0 To .Rows.Count - 1
                dr = dt.NewRow
                dr(0) = .Rows(i).Cells(0).Text
                dr(1) = .Rows(i).Cells(1).Text
                dr(2) = CDbl(.Rows(i).Cells(2).Text)
                dr(3) = CDbl(.Rows(i).Cells(3).Text)
                dr(4) = CInt(.Rows(i).Cells(4).Text)
                dt.Rows.Add(dr)
            Next

        End With
        Return dt
    End Function


    Protected Sub btnDataPaketEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDataPaketEkle.Click
        ' Session("firmID") = 1 'TODO -- sil
        Dim firmID As Integer = Session("firmID")
        ' ascxDataPaket.selectDataPaket(Session("firmID"))

        Dim datas As New datas
        Dim dt As New Data.DataTable
        dt = datas.getActiveDataPaket(firmID)


        grdDataPaket.Columns(0).Visible = True
        grdDataPaket.Columns(5).Visible = True
        grdDataPaket.DataSource = dt
        grdDataPaket.DataBind()

        grdDataPaket.Columns(0).Visible = False
        grdDataPaket.Columns(5).Visible = False

        mpeDataPaket.Show()

    End Sub

    Protected Sub btnDataIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataIptal.Click
        mpeDataPaket.Hide()

    End Sub

    Protected Sub btnCancelDP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelDP.Click
        mpeDataPaket.Hide()
    End Sub

    Protected Sub btnDataSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataSec.Click


        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("dataExcelID")
        dt.Columns.Add("dataPaket")
        dt.Columns.Add("aciklama")
        dt.Columns.Add("CreateDate")
        dt.Columns.Add("numOfRec")
        Dim i As Integer
        Dim chked As Boolean

        With grdDataPaket

            For i = 0 To .Rows.Count - 1
                chked = CType(.Rows(i).Cells(4).Controls(1), CheckBox).Checked

                If chked Then
                    dr = dt.NewRow
                    dr("dataExcelID") = .Rows(i).Cells(0).Text
                    dr("dataPaket") = .Rows(i).Cells(1).Text

                    dr("CreateDate") = .Rows(i).Cells(2).Text
                    dr("numOfRec") = .Rows(i).Cells(3).Text
                    dr("aciklama") = .Rows(i).Cells(5).Text
                    dt.Rows.Add(dr)

                End If

            Next
        End With

        grdDataProje.Columns(0).Visible = True
        grdDataProje.Columns(4).Visible = True

        grdDataProje.DataSource = dt
        grdDataProje.DataBind()
        grdDataProje.Columns(0).Visible = False
        grdDataProje.Columns(4).Visible = False


        mpeDataPaket.Hide()

    End Sub

    Protected Sub grdDataProje_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDataProje.RowDataBound


        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.ToolTip = e.Row.Cells(4).Text

        End If
        

    End Sub

    Protected Sub grdDataPaket_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDataPaket.RowDataBound
        'daha önce seçilmiş agentleri ve rollerini default getirmek için
        Dim i As Integer
        For i = 0 To grdDataProje.Rows.Count - 1
            If e.Row.Cells(0).Text = grdDataProje.Rows(i).Cells(0).Text Then
                CType(e.Row.Cells(4).Controls(1), CheckBox).Checked = True


            End If
        Next

        '********************
    End Sub

    Protected Sub chkSelfController_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelfController.SelectedIndexChanged
        If chkSelfController.SelectedValue = "0" Then
            Dim isThereKontroller As Boolean = isKontrollerDefined()
            If isThereKontroller Then
                ascxUyari.uyar("Ekip seçiminde proje için kontroller seçimi yaptınız. Agent kontroller seçeneği için ekipten kontroller seçeneğini çıkarmalısınız.", "#ff5545", "")
            End If

        End If
    End Sub

    Function isKontrollerDefined() As Boolean

        Dim res As Boolean = False

        For i = 0 To grdAgntProje.Rows.Count - 1
            If grdAgntProje.Rows(i).Cells(2).Text = "2" Then res = True
        Next
        Return res

    End Function

    Protected Sub btnSatisPaketEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSatisPaketEkle.Click
        'popupdaki bilgileri ana sayfadaki gride aktarır

        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("paketAdi")
        dt.Columns.Add("paketAciklama")
        dt.Columns.Add("birimFiyat")
        dt.Columns.Add("toplamFiyat")
        dt.Columns.Add("yenilemePeriod")

        Dim i As Integer
        With grdSatisPaket
            For i = 0 To .Rows.Count - 1

                dr = dt.NewRow
                dr("paketAdi") = .Rows(i).Cells(0).Text
                dr("paketAciklama") = .Rows(i).Cells(1).Text
                dr("birimFiyat") = .Rows(i).Cells(2).Text
                dr("toplamFiyat") = .Rows(i).Cells(3).Text
                dr("yenilemePeriod") = .Rows(i).Cells(4).Text
                dt.Rows.Add(dr)
            Next

        End With

        grdForProjePaket.DataSource = dt
        grdForProjePaket.DataBind()

        dt.Dispose()

        mpeSatisPaket.Show()
    End Sub

    Protected Sub btnCancelPrPaket_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelPrPaket.Click
        mpeSatisPaket.Hide()

    End Sub

    Protected Sub btnIptalPrPaket_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIptalPrPaket.Click
        mpeSatisPaket.Hide()

    End Sub

    Protected Sub btnTamamPrPaket_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTamamPrPaket.Click

        If radioParaBirimi.SelectedIndex < 0 Then
            'ascxUyari.uyar("Proje paketlerinde kullanılan para birimi seçimini yapmalısın.", "#343434", "")
            'Exit Sub
            lblParaBirimUyari.Visible = True
            Exit Sub
        End If


        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("paketAdi")
        dt.Columns.Add("paketAciklama")
        dt.Columns.Add("birimFiyat")
        dt.Columns.Add("toplamFiyat")
        dt.Columns.Add("yenilemePeriod")

        Dim i As Integer
        With grdForProjePaket
            For i = 0 To .Rows.Count - 1

                dr = dt.NewRow
                dr("paketAdi") = .Rows(i).Cells(0).Text
                dr("paketAciklama") = .Rows(i).Cells(1).Text
                dr("birimFiyat") = .Rows(i).Cells(2).Text
                dr("toplamFiyat") = .Rows(i).Cells(3).Text
                dr("yenilemePeriod") = .Rows(i).Cells(4).Text
                dt.Rows.Add(dr)
            Next

        End With

        grdSatisPaket.DataSource = dt
        grdSatisPaket.DataBind()

        dt.Dispose()

        mpeSatisPaket.Hide()
    End Sub

    Protected Sub btnPaketEkle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaketEkle.Click



        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("paketAdi")
        dt.Columns.Add("paketAciklama")
        dt.Columns.Add("birimFiyat")
        dt.Columns.Add("toplamFiyat")
        dt.Columns.Add("yenilemePeriod")

        Dim i As Integer
        With grdForProjePaket
            For i = 0 To .Rows.Count - 1
                dr = dt.NewRow
                dr("paketAdi") = .Rows(i).Cells(0).Text
                dr("paketAciklama") = .Rows(i).Cells(1).Text
                dr("birimFiyat") = .Rows(i).Cells(2).Text
                dr("toplamFiyat") = .Rows(i).Cells(3).Text
                dr("yenilemePeriod") = .Rows(i).Cells(4).Text
                dt.Rows.Add(dr)
            Next

        End With

        Dim pA As String = IIf(txtPaketAdi.Text.Trim = "", " ", txtPaketAdi.Text.Trim)
        Dim aC As String = IIf(txtAciklama.Text.Trim = "", " ", txtAciklama.Text.Trim)
        Dim bF As String = IIf(txtBirimFiyat.Text.Trim = "", " ", txtBirimFiyat.Text.Trim)
        Dim tF As String = IIf(txtToplamFiyat.Text.Trim = "", " ", txtToplamFiyat.Text.Trim)
        Dim yP As String = IIf(txtYenileme.Text.Trim = "", " ", txtYenileme.Text.Trim)

        dr = dt.NewRow
        dr("paketAdi") = pA
        dr("paketAciklama") = aC
        dr("birimFiyat") = bF
        dr("toplamFiyat") = tF
        dr("yenilemePeriod") = yP
        dt.Rows.Add(dr)

        grdForProjePaket.DataSource = dt
        grdForProjePaket.DataBind()
        '5094mf kompressör pressi ile alakalı problem -- kenan

        '    grdForProjePaket.Rows.add()
        txtPaketAdi.Text = ""
        txtAciklama.Text = ""
        txtBirimFiyat.Text = ""
        txtToplamFiyat.Text = ""
        txtYenileme.Text = ""
        dt.Dispose()

        mpeSatisPaket.Show()

    End Sub

    Protected Sub grdForProjePaket_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdForProjePaket.RowDeleting
       
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("paketAdi")
        dt.Columns.Add("paketAciklama")
        dt.Columns.Add("birimFiyat")
        dt.Columns.Add("toplamFiyat")

        Dim i As Integer
        With grdForProjePaket
            For i = 0 To .Rows.Count - 1
                If i <> e.RowIndex Then

                    dr = dt.NewRow
                    dr("paketAdi") = .Rows(i).Cells(0).Text
                    dr("paketAciklama") = .Rows(i).Cells(1).Text
                    dr("birimFiyat") = .Rows(i).Cells(2).Text
                    dr("toplamFiyat") = .Rows(i).Cells(3).Text
                    dt.Rows.Add(dr)
                End If
            Next

        End With

        grdForProjePaket.DataSource = dt
        grdForProjePaket.DataBind()

    End Sub


    Protected Sub btnSatisFieldEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSatisFieldEkle.Click
        mpeFields.Show()
        txtFieldAd1.Focus()

    End Sub

    Protected Sub btnFieldIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFieldIptal.Click
        mpeFields.Hide()

    End Sub

    Protected Sub btnKapaFields_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnKapaFields.Click
        mpeFields.Hide()
    End Sub

    'Protected Sub radioField1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioField1.CheckedChanged
    '    If radioField1.Checked Then
    '        disableChkBoxes(1)
    '        enableChkBoxes(2)
    '        enableChkBoxes(3)
    '        enableChkBoxes(4)
    '        enableChkBoxes(5)
    '        enableChkBoxes(6)
    '        enableChkBoxes(7)
    '        enableChkBoxes(8)
    '    End If
    'End Sub


    Sub enableChkBoxes(ByVal rowNo As Integer)

        Select rowNo
            Case 1
                chkFieldSifre1.Enabled = True
                chkFieldSilAfter1.Enabled = True
            Case 2
                chkFieldSifre2.Enabled = True
                chkFieldSilAfter2.Enabled = True
            Case 3
                chkFieldSifre3.Enabled = True
                chkFieldSilAfter3.Enabled = True
            Case 4
                chkFieldSifre4.Enabled = True
                chkFieldSilAfter4.Enabled = True
            Case 5
                chkFieldSifre5.Enabled = True
                chkFieldSilAfter5.Enabled = True
            Case 6
                chkFieldSifre6.Enabled = True
                chkFieldSilAfter6.Enabled = True
            Case 7
                chkFieldSifre7.Enabled = True
                chkFieldSilAfter7.Enabled = True


        End Select

    End Sub
    Sub disableChkBoxes(ByVal rowNo As Integer)

        Select Case rowNo
            Case 1
                chkFieldSifre1.Checked = False
                chkFieldSifre1.Enabled = False
                chkFieldSilAfter1.Checked = False
                chkFieldSilAfter1.Enabled = False

            Case 2
                chkFieldSifre2.Checked = False
                chkFieldSifre2.Enabled = False
                chkFieldSilAfter2.Checked = False
                chkFieldSilAfter2.Enabled = False

            Case 3
                chkFieldSifre3.Checked = False
                chkFieldSifre3.Enabled = False
                chkFieldSilAfter3.Checked = False
                chkFieldSilAfter3.Enabled = False

            Case 4
                chkFieldSifre4.Checked = False
                chkFieldSifre4.Enabled = False
                chkFieldSilAfter4.Checked = False
                chkFieldSilAfter4.Enabled = False

            Case 5
                chkFieldSifre5.Checked = False
                chkFieldSifre5.Enabled = False
                chkFieldSilAfter5.Checked = False
                chkFieldSilAfter5.Enabled = False

            Case 6
                chkFieldSifre6.Checked = False
                chkFieldSifre6.Enabled = False
                chkFieldSilAfter6.Checked = False
                chkFieldSilAfter6.Enabled = False

            Case 7
                chkFieldSifre7.Checked = False
                chkFieldSifre7.Enabled = False
                chkFieldSilAfter7.Checked = False
                chkFieldSilAfter7.Enabled = False





        End Select
    End Sub




    Function numOfSifreliField() As Integer

        Dim cnt As Integer = 0
        If chkFieldSifre1.Checked Then cnt += 1
        If chkFieldSifre2.Checked Then cnt += 1
        If chkFieldSifre3.Checked Then cnt += 1
        If chkFieldSifre4.Checked Then cnt += 1
        If chkFieldSifre5.Checked Then cnt += 1
        If chkFieldSifre6.Checked Then cnt += 1
        If chkFieldSifre7.Checked Then cnt += 1


        If cnt > 2 Then
            lblFields.Text = "performans sebebi ile 2'den fazla şifreli alan kullanılmaz."
        Else
            lblFields.Text = ""
        End If
        Return cnt
    End Function
    Protected Sub chkFieldSifre1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre1.CheckedChanged
        If chkFieldSifre1.Checked Then
            If numOfSifreliField > 2 Then
                chkFieldSifre1.Checked = False
                Exit Sub

            End If
            chkFieldSilAfter1.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSifre2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre2.CheckedChanged
        If chkFieldSifre2.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre2.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter2.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSifre3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre3.CheckedChanged
        If chkFieldSifre3.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre3.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter3.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSifre4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre4.CheckedChanged
        If chkFieldSifre4.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre4.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter4.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSifre5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre5.CheckedChanged
        If chkFieldSifre5.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre5.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter5.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSifre6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre6.CheckedChanged
        If chkFieldSifre6.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre6.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter6.Checked = False
        End If
    End Sub


    Protected Sub chkFieldSifre7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSifre7.CheckedChanged
        If chkFieldSifre7.Checked Then
            If numOfSifreliField() > 2 Then
                chkFieldSifre7.Checked = False
                Exit Sub
            End If

            chkFieldSilAfter7.Checked = False
        End If
    End Sub



    Protected Sub chkFieldSilAfter1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter1.CheckedChanged
        If chkFieldSilAfter1.Checked Then
            chkFieldSifre1.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter2.CheckedChanged
        If chkFieldSilAfter2.Checked Then
            chkFieldSifre2.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter3.CheckedChanged
        If chkFieldSilAfter3.Checked Then
            chkFieldSifre3.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter4.CheckedChanged
        If chkFieldSilAfter4.Checked Then
            chkFieldSifre4.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter5.CheckedChanged
        If chkFieldSilAfter5.Checked Then
            chkFieldSifre5.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter6.CheckedChanged
        If chkFieldSilAfter6.Checked Then
            chkFieldSifre6.Checked = False
        End If
    End Sub

    Protected Sub chkFieldSilAfter7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFieldSilAfter7.CheckedChanged
        If chkFieldSilAfter7.Checked Then
            chkFieldSifre7.Checked = False
        End If
    End Sub



    Protected Sub lnkIptal1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal1.Click
        txtFieldAd1.Text = ""
        enableChkBoxes(1)
        chkFieldSifre1.Checked = False
        chkFieldSilAfter1.Checked = False
        '    radioField1.Checked = False

    End Sub

    Protected Sub lnkIptal2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal2.Click
        txtFieldAd2.Text = ""
        enableChkBoxes(2)
        chkFieldSifre2.Checked = False
        chkFieldSilAfter2.Checked = False


    End Sub

    Protected Sub lnkIptal3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal3.Click
        txtFieldAd3.Text = ""
        enableChkBoxes(3)
        chkFieldSifre3.Checked = False
        chkFieldSilAfter3.Checked = False


    End Sub

    Protected Sub lnkIptal4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal4.Click
        txtFieldAd4.Text = ""
        enableChkBoxes(4)
        chkFieldSifre4.Checked = False
        chkFieldSilAfter4.Checked = False


    End Sub

    Protected Sub lnkIptal5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal5.Click
        txtFieldAd5.Text = ""
        enableChkBoxes(5)
        chkFieldSifre5.Checked = False
        chkFieldSilAfter5.Checked = False


    End Sub

    Protected Sub lnkIptal6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal6.Click
        txtFieldAd6.Text = ""
        enableChkBoxes(6)
        chkFieldSifre6.Checked = False
        chkFieldSilAfter6.Checked = False


    End Sub

    Protected Sub lnkIptal7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkIptal7.Click
        txtFieldAd7.Text = ""
        enableChkBoxes(7)
        chkFieldSifre7.Checked = False
        chkFieldSilAfter7.Checked = False


    End Sub


    Protected Sub btnFieldTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFieldTamam.Click

        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow


        dt.Columns.Add("fieldAd")
        dt.Columns.Add("isSifre")
        dt.Columns.Add("isSilAfterSale")

        Dim i As Integer = 0
        If txtFieldAd1.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd1.Text.Trim
            If chkFieldSifre1.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter1.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd2.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd2.Text.Trim
            If chkFieldSifre2.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter2.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd3.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd3.Text.Trim
            If chkFieldSifre3.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter3.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd4.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd4.Text.Trim
            If chkFieldSifre4.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter4.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd5.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd5.Text.Trim
            If chkFieldSifre5.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter5.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd6.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd6.Text.Trim
            If chkFieldSifre6.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter6.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If
        If txtFieldAd7.Text.Trim <> "" Then
            dr = dt.NewRow
            dr("fieldAd") = txtFieldAd7.Text.Trim
            If chkFieldSifre7.Checked Then dr("isSifre") = "Şifreli" Else dr("isSifre") = "-"
            If chkFieldSilAfter7.Checked Then dr("isSilAfterSale") = "Gecici" Else dr("isSilAfterSale") = "-"
            dt.Rows.Add(dr)
            i += 1
        End If



        grdSatisFields.DataSource = dt
        grdSatisFields.DataBind()
        mpeFields.Hide()


    End Sub

    Protected Sub btnAgentEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgentEkle.Click
        'ascxAgentEkle.selectAgents(Session("firmID"))

        Dim agnt As New agents
        Dim dt As New Data.DataTable

        'Session("firmID") = 1 'TODO - silll
        dt = agnt.getAgentsActive(Session("firmID"))

        grdAgentForProje.Columns(0).Visible = True
        grdAgentForProje.Columns(3).Visible = True
        grdAgentForProje.Columns(6).Visible = True

        grdAgentForProje.DataSource = dt
        grdAgentForProje.DataBind()

        grdAgentForProje.Columns(0).Visible = False
        grdAgentForProje.Columns(3).Visible = False
        grdAgentForProje.Columns(6).Visible = False

        mpeAgnt.Show()
    End Sub
End Class
