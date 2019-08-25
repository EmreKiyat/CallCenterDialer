
Partial Class agnt_kontroller
    Inherits System.Web.UI.Page
    Dim knt As New kontroller
    Dim sts As New satis


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            imgLogo.ImageUrl = "../images/logo/" + sts.getLogo(Session("firmID"))

            btnAra.Attributes.Add("onclick", "runExe()")
            btnLobListeYenile.Attributes.Add("onClick", "return birSureDisable(this);")
            lnkSerbestBirak.Attributes.Add("onClick", "return birSureDisable(this);")
            btnSatisOnay.Attributes.Add("onClick", "return birSureDisable(this);")
            btnGeriGonder.Attributes.Add("onClick", "return birSureDisable(this);")
            btnSoldOnayTamam.Attributes.Add("onClick", "return birSureDisable(this);")
            btnGeriGonder.Attributes.Add("onClick", "return birSureDisable(this);")


            lblAgentAdSoyad.Text = Session("adSoyad")

            Dim prC As Integer = projeCombosuHazirla()


            If prC = 0 Then
                ascxUyari.uyar("Kontroller olarak tanımlı olduğunuz bir proje yok!", "#ff1111", "")
                btnSatisOnay.Enabled = False
                btnGeriGonder.Enabled = False
                Exit Sub
            End If

            Session("isYenilemeProjesi") = sts.isYenilemeProjesi(cmbProje.SelectedValue)

            getSatilanDataFromList(0)
            satilanListesiPopulate()

        End If
    End Sub

    Sub getSatilanDataFromList(ByVal havuzID As Integer)
        'havuzID 0 ise satılanlar havuzundan tarihi en eski olan bi tane alır, yok eğer >0 ise kontroller listeden seçmiş demektir onu alır
        emptyFields()
        Dim dt As Data.DataTable
        If havuzID = 0 Then
            dt = knt.getASatilanDataFromList(cmbProje.SelectedValue, Session("agentID"))
        Else
            dt = knt.getTheSatilanDataFromList(havuzID, Session("agentID"))
        End If

        If dt.Rows.Count = 0 Then
            ' emptyFields()
            Exit Sub
        End If
        Dim dataIsl As New dataGetirmeIslemleri

        fillFields(dt)
        'görev listesinden geliyosa (çoğunlukla) önceki işlemlerin log ve notları
        Dim realHavuzID As Integer = dt.Rows(0).Item("havuzID")
        Dim dtLog As Data.DataTable = dataIsl.dataLogGetir(realHavuzID)
        customSatisFieldleriInitiate(realHavuzID)


        grdOncekiGorusmeler.Columns(0).Visible = True
        grdOncekiGorusmeler.Columns(1).Visible = True
        grdOncekiGorusmeler.Columns(2).Visible = True


        grdOncekiGorusmeler.DataSource = dtLog
        grdOncekiGorusmeler.DataBind()

        grdOncekiGorusmeler.Columns(0).Visible = False
        grdOncekiGorusmeler.Columns(1).Visible = False
        grdOncekiGorusmeler.Columns(2).Visible = False

        Dim dtNote As Data.DataTable = knt.getNotesOnSale(realHavuzID)
        rptNotlar.DataSource = dtNote
        rptNotlar.DataBind()


        satisPaketleriInitiate()

    End Sub
    Sub satilanListesiPopulate()

        Dim dt As Data.DataTable = knt.getSatilanList(cmbProje.SelectedValue)

        grdKontrollerList.Columns(0).Visible = True
        grdKontrollerList.Columns(1).Visible = True
        grdKontrollerList.Columns(2).Visible = True
        grdKontrollerList.Columns(6).Visible = True
        grdKontrollerList.DataSource = dt
        grdKontrollerList.DataBind()
        grdKontrollerList.Columns(0).Visible = False
        grdKontrollerList.Columns(1).Visible = False
        grdKontrollerList.Columns(2).Visible = False
        grdKontrollerList.Columns(6).Visible = False
        lblSatisToplamLab.Text = "Toplam: "
    End Sub
    Function projeCombosuHazirla() As Integer
        Dim pr As New proje
        Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 2) '2: kontroller demek


        cmbProje.DataTextField = "proje"
        cmbProje.DataValueField = "projeID"

        cmbProje.DataSource = dt
        cmbProje.DataBind()

        Return dt.Rows.Count

    End Function



    '**************************************** Ekran FILL İŞLEMLERİ*********************************************************

    Sub fillFields(ByVal dt As Data.DataTable)
        Dim datas As New datas
        Dim tel1, tel2, tel3 As String
        If dt.Rows.Count = 0 Then
            emptyFields()
            Exit Sub

        End If



        With dt.Rows(0)
            'isim soyisim
            lblBayBayan.Text = IIf(IsDBNull(.Item("hitap1")), "", .Item("hitap1"))
            lblAdSoyad.Text = IIf(IsDBNull(.Item("ad1")), "", .Item("ad1")) + " " + IIf(IsDBNull(.Item("soyad1")), "", .Item("soyad1"))
            ViewState("adSoyad1") = lblAdSoyad.Text
            ViewState("adSoyad2") = IIf(IsDBNull(.Item("ad2")), "", .Item("ad2")) + " " + IIf(IsDBNull(.Item("soyad2")), "", .Item("soyad2"))    'butonlara basınca kullanmak için
            ViewState("adSoyad3") = IIf(IsDBNull(.Item("ad3")), "", .Item("ad3")) + " " + IIf(IsDBNull(.Item("soyad3")), "", .Item("soyad3"))


            setAppearanceAdSoyadButons()
            'telefon bilgileri
            tel1 = IIf(IsDBNull(.Item("tel1")), "", .Item("tel1"))
            If tel1.Length > 14 Then tel1 = datas.sifreCoz(tel1)
            tel2 = IIf(IsDBNull(.Item("tel2")), "", .Item("tel2"))
            If tel2.Length > 14 Then tel2 = datas.sifreCoz(tel2)
            tel3 = IIf(IsDBNull(.Item("tel3")), "", .Item("tel3"))
            If tel3.Length > 14 Then tel3 = datas.sifreCoz(tel3)

            lblTelNo.Text = tel1
            ViewState("tel1") = tel1
            ViewState("tel2") = tel2
            ViewState("tel3") = tel3

            txtTelNoHeaderEkle.Text = IIf(IsDBNull(.Item("tel1Head")), "", .Item("tel1Head"))

            setAppearanceTelButons()
            'adres + e-mail
            txtAdres1.Text = IIf(IsDBNull(.Item("adres1")), "", .Item("adres1"))
            txtAdres2PlusPostaKod.Text = IIf(IsDBNull(.Item("adres2")), "", .Item("adres2"))
            txtPostaKod.Text = IIf(IsDBNull(.Item("postaKod")), "", .Item("postaKod"))
            txtSehir.Text = IIf(IsDBNull(.Item("sehir")), "", .Item("sehir"))
            txtEMail.Text = IIf(IsDBNull(.Item("eMail")), "", .Item("eMail"))
            'havuzID
            lblRecNo.Text = IIf(IsDBNull(.Item("havuzID")), "", .Item("havuzID"))
            'diğer bilgileri
            lblH1.Text = IIf(IsDBNull(.Item("head1")), "", .Item("head1"))
            lblH2.Text = IIf(IsDBNull(.Item("head2")), "", .Item("head2"))
            lblH3.Text = IIf(IsDBNull(.Item("head3")), "", .Item("head3"))
            lblH4.Text = IIf(IsDBNull(.Item("head4")), "", .Item("head4"))
            lblH5.Text = IIf(IsDBNull(.Item("head5")), "", .Item("head5"))
            lblH6.Text = IIf(IsDBNull(.Item("head6")), "", .Item("head6"))
            lblf1.Text = IIf(IsDBNull(.Item("f1")), "", .Item("f1"))
            lblf2.Text = IIf(IsDBNull(.Item("f2")), "", .Item("f2"))
            lblf3.Text = IIf(IsDBNull(.Item("f3")), "", .Item("f3"))
            lblf4.Text = IIf(IsDBNull(.Item("f4")), "", .Item("f4"))
            lblf5.Text = IIf(IsDBNull(.Item("f5")), "", .Item("f5"))
            lblf6.Text = IIf(IsDBNull(.Item("f6")), "", .Item("f6"))

            lblSatanAgent.Text = IIf(IsDBNull(.Item("adSoyad")), "", .Item("adSoyad"))
            ViewState("satanAgentID") = IIf(IsDBNull(.Item("agentID")), "", .Item("agentID"))
            Dim isHome As Integer = IIf(IsDBNull(.Item("isHomeAgent")), 0, .Item("isHomeAgent"))
            If isHome = 1 Then imgIsHome.Visible = True Else imgIsHome.Visible = False
            lblSatisSaat.Text = IIf(IsDBNull(.Item("rDate")), 0, .Item("rDate").ToString)


            If Session("isYenilemeProjesi") = 1 Then
                lblTerminTarih.Text = IIf(IsDBNull(.Item("terminDate")), "", .Item("terminDate"))
            Else
                lblTerminTarih.Text = ""
            End If

        End With
    End Sub

    Sub emptyFields()
        lblTerminTarih.Text = ""
        lblBayBayan.Text = ""
        lblAdSoyad.Text = ""
        ViewState("adSoyad1") = ""
        ViewState("adSoyad2") = ""
        ViewState("adSoyad3") = ""

        'btnAdSoy1.ImageUrl = "../images/1g.png"
        'btnAdSoy1.Enabled = False
        btnAdSoy2.ImageUrl = "../images/2g.png"
        btnAdSoy2.Enabled = False
        btnAdSoy3.ImageUrl = "../images/3g.png"
        btnAdSoy3.Enabled = False


        'telefon bilgileri

        lblTelNo.Text = ""
        ViewState("tel1") = ""
        ViewState("tel2") = ""
        ViewState("tel3") = ""

        txtTelNoHeaderEkle.Text = ""

        'btnTel1.ImageUrl = "../images/1g.png"
        'btnTel1.Enabled = False
        btnTel2.ImageUrl = "../images/2g.png"
        btnTel2.Enabled = False
        btnTel3.ImageUrl = "../images/3g.png"
        btnTel3.Enabled = False

        'adres + e-mail
        txtAdres1.Text = ""
        txtAdres2PlusPostaKod.Text = ""
        txtPostaKod.Text = ""
        txtPostaKod.Text = ""
        txtSehir.Text = ""
        txtEMail.Text = ""
        'havuzID
        lblRecNo.Text = ""
        'diğer bilgileri
        lblH1.Text = ""
        lblH2.Text = ""
        lblH3.Text = ""
        lblH4.Text = ""
        lblH5.Text = ""
        lblH6.Text = ""
        lblf1.Text = ""
        lblf2.Text = ""
        lblf3.Text = ""
        lblf4.Text = ""
        lblf5.Text = ""
        lblf6.Text = ""

        txtCF1.Text = ""
        txtCF2.Text = ""
        txtCF3.Text = ""
        txtCF4.Text = ""
        txtCF5.Text = ""
        txtCF6.Text = ""
        txtCF7.Text = ""

        lblCF1.Text = ""
        lblCF2.Text = ""
        lblCF3.Text = ""
        lblCF4.Text = ""
        lblCF5.Text = ""
        lblCF6.Text = ""
        lblCF7.Text = ""

        lblSatanAgent.Text = ""

        imgIsHome.Visible = False
        lblSatisSaat.Text = ""


        grdSatisPaket.DataSource = Nothing
        grdSatisPaket.DataBind()

        grdOncekiGorusmeler.DataSource = Nothing
        grdOncekiGorusmeler.DataBind()

        lblSatisToplamLab.Text = ""
        lblSatisToplam.Text = ""


    End Sub


    Sub setAppearanceTelButons()
        If ViewState("tel2").ToString.Trim.Length < 5 Then
            btnTel2.ImageUrl = "../images/2g.png"
            btnTel2.Enabled = False
        Else
            btnTel2.ImageUrl = "../images/2.png"
            btnTel2.Enabled = True
            btnTel2.ToolTip = ViewState("tel2").ToString.Trim
        End If

        If ViewState("tel3").ToString.Trim.Length < 5 Then
            btnTel3.ImageUrl = "../images/3g.png"
            btnTel3.Enabled = False
        Else
            btnTel3.ImageUrl = "../images/3.png"
            btnTel3.Enabled = True
            btnTel3.ToolTip = ViewState("tel3").ToString.Trim
        End If
        btnTel1.ToolTip = ViewState("tel1").ToString.Trim
    End Sub

    Sub setAppearanceAdSoyadButons()
        If ViewState("adSoyad2").ToString.Trim.Length < 2 Then
            btnAdSoy2.ImageUrl = "../images/2g.png"
            btnAdSoy2.Enabled = False
        Else
            btnAdSoy2.ImageUrl = "../images/2.png"
            btnAdSoy2.Enabled = True
            btnAdSoy2.ToolTip = ViewState("adSoyad2").ToString.Trim
        End If

        If ViewState("adSoyad3").ToString.Trim.Length < 2 Then
            btnAdSoy3.ImageUrl = "../images/3g.png"
            btnAdSoy3.Enabled = False
        Else
            btnAdSoy3.ImageUrl = "../images/3.png"
            btnAdSoy3.Enabled = True
            btnAdSoy3.ToolTip = ViewState("adSoyad3").ToString.Trim
        End If
        btnAdSoy1.ToolTip = ViewState("adSoyad1").ToString.Trim
    End Sub

    '**********************************************************************************************************************

    Protected Sub grdKontrollerList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdKontrollerList.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim isKontrollerAtanmis As Integer = CInt(e.Row.Cells(6).Text)
            If isKontrollerAtanmis > 0 Then
                e.Row.BackColor = Drawing.Color.FromName("#dddddd")

                CType(e.Row.Cells(7).Controls(0), LinkButton).Enabled = False


            End If
        End If
    End Sub




    Sub customSatisFieldleriInitiate(ByVal havuzID As Integer)
        Dim dataIsl As New dataGetirmeIslemleri
        Dim cusFieldExist As Boolean = False
        Dim dtCFDef As Data.DataTable = dataIsl.getCustomFieldsOnSaleDef(cmbProje.SelectedValue, havuzID)

        'daha önce data girilmiş - bu satış kaydet sırasında mevcut field'i update mi yoksa yeni data insert mi kararı için kullanılacak
        'ViewState("customFieldsDefID") = dtCFDef.Rows(0).Item("customFieldsDefID")
        If IsDBNull(dtCFDef.Rows(0).Item("customFieldID")) Then
            ViewState("customFieldDataVar") = 0
        Else
            ViewState("customFieldDataVar") = dtCFDef.Rows(0).Item("customFieldID")

        End If
        '------
        Dim tmpStr As String = ""
        unvisibleCustomSatisFields()
        With dtCFDef
            If .Rows.Count > 0 Then
                If Not IsDBNull(.Rows(0).Item("f1Ad")) Then
                    cusFieldExist = True
                    lblCF1.Text = .Rows(0).Item("f1Ad")
                    txtCF1.Text = getCustFieldIcerik(.Rows(0).Item("f1"), .Rows(0).Item("f1Sifreli"))
                    lblCF1.Visible = True
                    txtCF1.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f1Sifreli"), .Rows(0).Item("f1DeleteAfterSale"), imgCFSifre1, imgCFSil1)
                    If Not cusFieldExist Then txtCF1.Focus()

                End If
                If Not IsDBNull(.Rows(0).Item("f2Ad")) Then
                    cusFieldExist = True
                    lblCF2.Text = .Rows(0).Item("f2Ad")
                    txtCF2.Text = getCustFieldIcerik(.Rows(0).Item("f2"), .Rows(0).Item("f2Sifreli"))

                    lblCF2.Visible = True
                    txtCF2.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f2Sifreli"), .Rows(0).Item("f2DeleteAfterSale"), imgCFSifre2, imgCFSil2)
                    If Not cusFieldExist Then txtCF2.Focus()

                End If
                If Not IsDBNull(.Rows(0).Item("f3Ad")) Then
                    cusFieldExist = True
                    lblCF3.Text = .Rows(0).Item("f3Ad")
                    txtCF3.Text = getCustFieldIcerik(.Rows(0).Item("f3"), .Rows(0).Item("f3Sifreli"))

                    lblCF3.Visible = True
                    txtCF3.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f3Sifreli"), .Rows(0).Item("f3DeleteAfterSale"), imgCFSifre3, imgCFSil3)
                    If Not cusFieldExist Then txtCF3.Focus()
                End If
                If Not IsDBNull(.Rows(0).Item("f4Ad")) Then
                    cusFieldExist = True
                    lblCF4.Text = .Rows(0).Item("f4Ad")
                    txtCF4.Text = getCustFieldIcerik(.Rows(0).Item("f4"), .Rows(0).Item("f4Sifreli"))

                    lblCF4.Visible = True
                    txtCF4.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f4Sifreli"), .Rows(0).Item("f4DeleteAfterSale"), imgCFSifre4, imgCFSil4)
                    If Not cusFieldExist Then txtCF4.Focus()
                End If
                If Not IsDBNull(.Rows(0).Item("f5Ad")) Then
                    cusFieldExist = True
                    lblCF5.Text = .Rows(0).Item("f5Ad")
                    txtCF5.Text = getCustFieldIcerik(.Rows(0).Item("f5"), .Rows(0).Item("f5Sifreli"))

                    lblCF5.Visible = True
                    txtCF5.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f5Sifreli"), .Rows(0).Item("f5DeleteAfterSale"), imgCFSifre5, imgCFSil5)
                    If Not cusFieldExist Then txtCF5.Focus()
                End If
                If Not IsDBNull(.Rows(0).Item("f6Ad")) Then
                    cusFieldExist = True
                    lblCF6.Text = .Rows(0).Item("f6Ad")
                    txtCF6.Text = getCustFieldIcerik(.Rows(0).Item("f6"), .Rows(0).Item("f6Sifreli"))

                    lblCF6.Visible = True
                    txtCF6.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f6Sifreli"), .Rows(0).Item("f6DeleteAfterSale"), imgCFSifre6, imgCFSil6)
                    If Not cusFieldExist Then txtCF6.Focus()
                End If
                If Not IsDBNull(.Rows(0).Item("f7Ad")) Then
                    cusFieldExist = True
                    lblCF7.Text = .Rows(0).Item("f7Ad")
                    txtCF7.Text = getCustFieldIcerik(.Rows(0).Item("f7"), .Rows(0).Item("f7Sifreli"))

                    lblCF7.Visible = True
                    txtCF7.Visible = True
                    setVisibilityOfImg(.Rows(0).Item("f7Sifreli"), .Rows(0).Item("f7DeleteAfterSale"), imgCFSifre7, imgCFSil7)
                    If Not cusFieldExist Then txtCF7.Focus()
                End If

            End If
        End With
    End Sub

    Function getCustFieldIcerik(ByVal str As Object, ByVal sifreli As Integer) As String


        Dim aStr As String
        If IsDBNull(str) Then aStr = "" Else aStr = str.ToString

        Dim tmpStr As String = ""
        Dim datas As New datas

        If sifreli = 1 And aStr.Length > 8 Then
            tmpStr = datas.sifreCoz(str)
        Else
            tmpStr = aStr
        End If

        Return tmpStr
    End Function

    Sub setVisibilityOfImg(ByVal isSifreli As Integer, ByVal isSil As Integer, ByRef imgSif As Image, ByRef imgSil As Image)
        If isSifreli = 1 Then
            imgSif.Visible = True
        End If
        If isSil = 1 Then
            imgSil.Visible = True
        End If
    End Sub

    Sub unvisibleCustomSatisFields()
        lblCF1.Visible = False
        lblCF2.Visible = False
        lblCF3.Visible = False
        lblCF4.Visible = False
        lblCF5.Visible = False
        lblCF6.Visible = False
        lblCF7.Visible = False
        txtCF1.Visible = False
        txtCF2.Visible = False
        txtCF3.Visible = False
        txtCF4.Visible = False
        txtCF5.Visible = False
        txtCF6.Visible = False
        txtCF7.Visible = False
        imgCFSifre1.Visible = False
        imgCFSifre2.Visible = False
        imgCFSifre3.Visible = False
        imgCFSifre4.Visible = False
        imgCFSifre5.Visible = False
        imgCFSifre6.Visible = False
        imgCFSifre7.Visible = False
        imgCFSil1.Visible = False
        imgCFSil2.Visible = False
        imgCFSil3.Visible = False
        imgCFSil4.Visible = False
        imgCFSil5.Visible = False
        imgCFSil6.Visible = False
        imgCFSil7.Visible = False

    End Sub

    Function getSatisToplam() As Decimal

        Dim i As Integer
        Dim chkd As Boolean
        Dim toplam As Decimal = 0
        Dim adet As Integer
        Dim fiyat As Decimal

        With grdSatisPaket
            For i = 0 To .Rows.Count - 1
                chkd = CType(.Rows(i).Cells(6).Controls(1), CheckBox).Checked
                If chkd Then
                    adet = CInt(CType(.Rows(i).Cells(5).Controls(1), TextBox).Text)
                    fiyat = CDec(.Rows(i).Cells(3).Text)

                    toplam += adet * fiyat

                End If
            Next

        End With
        Return toplam

    End Function


    Function getSatisPaketFromGrid() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim chkd As Boolean


        Dim dr As Data.DataRow
        dt.Columns.Add("paketID", GetType(Integer))

        dt.Columns.Add("satilanAdet", GetType(Integer))
        dt.Columns.Add("birimFiyat", GetType(Decimal))
        dt.Columns.Add("yenilemePeriod", GetType(Integer))
        '  dt.Columns.Add("yenilemeTarih", GetType(DateTime))

        With grdSatisPaket
            For i = 0 To .Rows.Count - 1
                chkd = CType(.Rows(i).Cells(6).Controls(1), CheckBox).Checked
                If chkd Then
                    dr = dt.NewRow()
                    dr("paketID") = .Rows(i).Cells(0).Text
                    dr("satilanAdet") = CInt(CType(.Rows(i).Cells(5).Controls(1), TextBox).Text)
                    dr("birimFiyat") = CDec(.Rows(i).Cells(3).Text)
                    dr("yenilemePeriod") = CInt(.Rows(i).Cells(7).Text)

                    dt.Rows.Add(dr)

                End If
            Next

        End With

        Return dt
    End Function

    Sub satisPaketleriInitiate()
        Dim dataIsl As New dataGetirmeIslemleri
        Dim dt As Data.DataTable = dataIsl.getProjeSatisPaket(cmbProje.SelectedValue)

        grdSatisPaket.Columns(0).Visible = True
        grdSatisPaket.Columns(7).Visible = True
        grdSatisPaket.DataSource = dt
        grdSatisPaket.DataBind()
        grdSatisPaket.Columns(0).Visible = False
        grdSatisPaket.Columns(7).Visible = False


        lblSatisToplam.Text = getSatisToplam()

        'agentten gelen orjinal satış paketini gridden çıkarır - rowdatabound olayından sonra, 
        'daha sonra cont. değişiklik yapıp yapmadığı nı bulmak için
        Dim dtS As Data.DataTable = getSatisPaketFromGrid()
        ViewState("satisPaketFromAgent") = dtS
        '****************************************

    End Sub


    Protected Sub grdSatisPaket_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSatisPaket.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim paketID As Integer = Convert.ToInt32(e.Row.Cells(0).Text)
            Dim havuzID As Integer = Convert.ToInt32(lblRecNo.Text)
            Dim dt As Data.DataTable = knt.isSoldThisPaket(havuzID, paketID)
            If dt.Rows.Count > 0 Then
                Dim adet As Integer = CInt(dt.Rows(0).Item("adet"))

                If adet > 0 Then
                    CType(e.Row.Cells(5).Controls(1), TextBox).Text = adet.ToString
                    CType(e.Row.Cells(6).Controls(1), CheckBox).Checked = True

                    'teslim adres get - bu ilerde her bir satılan paket ve adet için ayrılması gerek
                    txtAdres1.Text = IIf(IsDBNull(dt.Rows(0).Item("teslimAddr1")), "", dt.Rows(0).Item("teslimAddr1"))
                    txtAdres2PlusPostaKod.Text = IIf(IsDBNull(dt.Rows(0).Item("teslimAddr2")), "", dt.Rows(0).Item("teslimAddr2"))
                    txtPostaKod.Text = IIf(IsDBNull(dt.Rows(0).Item("postaKod")), "", dt.Rows(0).Item("postaKod"))
                    txtSehir.Text = IIf(IsDBNull(dt.Rows(0).Item("teslimSehir")), "", dt.Rows(0).Item("teslimSehir"))

                    txtTeslimKisi.Text = IIf(IsDBNull(dt.Rows(0).Item("teslimKisi")), "", dt.Rows(0).Item("teslimKisi"))
                    txtTeslimTel.Text = IIf(IsDBNull(dt.Rows(0).Item("teslimTel")), "", dt.Rows(0).Item("teslimTel"))
                End If

            End If

            dt.Dispose()
        End If
    End Sub



    Protected Sub btnAdSoy1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy1.Click
        lblAdSoyad.Text = ViewState("adSoyad1")
    End Sub

    Protected Sub btnAdSoy2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy2.Click
        lblAdSoyad.Text = ViewState("adSoyad2")
    End Sub

    Protected Sub btnAdSoy3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy3.Click
        lblAdSoyad.Text = ViewState("adSoyad3")
    End Sub

    Protected Sub btnTel1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel1.Click
        lblTelNo.Text = ViewState("tel1")
    End Sub

    Protected Sub btnTel2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel2.Click
        lblTelNo.Text = ViewState("tel2")
    End Sub

    Protected Sub btnTel3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel3.Click
        lblTelNo.Text = ViewState("tel3")
    End Sub

    Protected Sub btnGeriGonder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeriGonder.Click
        txtGeriGonderNot.Text = ""
        txtGeriGonderNot.Focus()
        mpeGeriGonder.Show()


    End Sub

    Protected Sub chkKontAuto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkKontAuto.CheckedChanged
        If chkKontAuto.Checked = True Then
            If canvasOrtu.Visible Then

                canvasOrtu.Visible = False
                getSatilanDataFromList(0)
                satilanListesiPopulate()
            End If
        End If
    End Sub

    'Protected Sub btnSerbestBirak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSerbestBirak.Click
    '    canvasOrtu.Visible = True
    '    chkKontAuto.Checked = False
    '    knt.releaseDataByKontroller(Convert.ToInt32(lblRecNo.Text))
    '    emptyFields()
    '    satilanListesiPopulate()

    'End Sub




    Protected Sub grdKontrollerList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdKontrollerList.SelectedIndexChanged
        Dim row As GridViewRow = grdKontrollerList.SelectedRow
        Dim havuzID As String = row.Cells(0).Text
        Dim infS As String = ""
        Dim islem As Integer
        Dim kontrollerID As Integer
        Dim isTakenByOtherKont As Boolean = False

        Dim dt As Data.DataTable = knt.isTakenByOtherKontroller(havuzID)
        islem = dt.Rows(0).Item("islem")
        kontrollerID = dt.Rows(0).Item("kontrollerID")

        If islem <> 1 Then
            Select Case islem
                Case 11
                    infS = "Başka bir kontroller tarafından agente geri gönderilmiştir. Lütfen başka bir kayıt seçin."
                Case 5
                    infS = "Başka bir kontroller tarafından satış onaylanmıştır. Lütfen başka bir kayıt seçin."
            End Select
            isTakenByOtherKont = True
        Else
            If kontrollerID <> 0 Then
                infS = "Bu kayıt başka bir kontroller tarafından alınmıştır, başka bir kayıt seçin ya da ilgili kontrollerden kaydın serbest bırakılmasını talep edin!"
                isTakenByOtherKont = True
            End If
            
        End If
        If isTakenByOtherKont Then
            satilanListesiPopulate()
            ascxUyari.uyar(infS, "#ff2222", "")
            Exit Sub
        End If

        If canvasOrtu.Visible Then
            canvasOrtu.Visible = False

        Else    'yani kontroller üzerinde data varsa
            knt.releaseDataByKontroller(Convert.ToInt32(lblRecNo.Text))
            emptyFields()

            chkKontAuto.Checked = False

        End If

        getSatilanDataFromList(havuzID)     'seçilen datayı getirir


        satilanListesiPopulate()

    End Sub

    Protected Sub btnLobListeYenile_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLobListeYenile.Click
        satilanListesiPopulate()
    End Sub

    Protected Sub cmbProje_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProje.SelectedIndexChanged

        Session("isYenilemeProjesi") = sts.isYenilemeProjesi(cmbProje.SelectedValue)

        getSatilanDataFromList(0)
        satilanListesiPopulate()

    End Sub

    Protected Sub lnkSerbestBirak_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSerbestBirak.Click

        If Not canvasOrtu.Visible Then

            canvasOrtu.Visible = True
            chkKontAuto.Checked = False
            Try


                knt.releaseDataByKontroller(Convert.ToInt32(lblRecNo.Text))
                emptyFields()
                satilanListesiPopulate()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnSatisOnay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatisOnay.Click

        txtNotbyKont.Text = ""
        txtNotbyKont.Focus()
        mpeSoldOnay.Show()



    End Sub

    Function isSatisPaketChanged(ByVal dtSon As Data.DataTable, ByVal dtFromAgent As Data.DataTable) As Boolean
        'agentin yolladığı satılan paket listesi ile kontrollerin onaydaki listesi karşılaştırılır.. farklı ise kontrollerinki kaydedilecek, eskisi history de loglanacak
        Dim degisti As Boolean = False
        Dim itemFound As Boolean
        Dim i, k As Integer
        If dtSon.Rows.Count = dtFromAgent.Rows.Count Then
            For i = 0 To dtSon.Rows.Count - 1
                itemFound = False
                For k = 0 To dtFromAgent.Rows.Count - 1
                    If dtSon.Rows(i).Item("paketID") = dtFromAgent.Rows(k).Item("paketID") And dtSon.Rows(i).Item("satilanAdet") = dtFromAgent.Rows(k).Item("satilanAdet") Then

                        itemFound = True

                    End If
                Next
                If Not itemFound Then
                    degisti = True
                    Exit For    ''bi kere değiti ise devam etmeye gerek yok

                End If
            Next
            'karşılaştırmayı bir de tersten yapmak lazım yoksa kontrollerin kaldırdığı bir paket varsa bunu kaçırırız ... tabi degisti true ise gerek yok zaten dön babam dönmeye
            If Not degisti Then
                For k = 0 To dtFromAgent.Rows.Count - 1
                    itemFound = False
                    For i = 0 To dtFromAgent.Rows.Count - 1
                        If dtSon.Rows(i).Item("paketID") = dtFromAgent.Rows(k).Item("paketID") And dtSon.Rows(i).Item("satilanAdet") = dtFromAgent.Rows(k).Item("satilanAdet") Then

                            itemFound = True

                        End If
                    Next
                    If Not itemFound Then
                        degisti = True
                        Exit For    ''bi kere değiti ise devam etmeye gerek yok

                    End If
                Next
            End If

        Else
            degisti = True      'paket sayıları değişti ise zaten değişmiştir
        End If
        Return degisti



        'dt.Columns.Add("paketID", GetType(Integer))

        'dt.Columns.Add("satilanAdet", GetType(Integer))
    End Function
    Function getFieldValue(ByVal str As String, ByVal isFieldExist As Boolean, ByVal isSifre As Boolean) As String
        Dim tmpStr As String = ""
        Dim datas As New datas

        If isFieldExist Then
            If isSifre Then
                tmpStr = datas.sifrele(str)
            Else
                tmpStr = str
            End If

        End If

        Return tmpStr

    End Function

    Protected Sub btnSoldOnayTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSoldOnayTamam.Click

        Dim f1 As String = getFieldValue(txtCF1.Text, txtCF1.Visible, imgCFSifre1.Visible)  'sifreli alansa şifreleyip alıyor, kullanılmayan alansa "" geliyo
        Dim f2 As String = getFieldValue(txtCF2.Text, txtCF2.Visible, imgCFSifre2.Visible)
        Dim f3 As String = getFieldValue(txtCF3.Text, txtCF3.Visible, imgCFSifre3.Visible)
        Dim f4 As String = getFieldValue(txtCF4.Text, txtCF4.Visible, imgCFSifre4.Visible)
        Dim f5 As String = getFieldValue(txtCF5.Text, txtCF5.Visible, imgCFSifre5.Visible)
        Dim f6 As String = getFieldValue(txtCF6.Text, txtCF6.Visible, imgCFSifre6.Visible)
        Dim f7 As String = getFieldValue(txtCF7.Text, txtCF7.Visible, imgCFSifre7.Visible)

        Dim customFieldID As Integer = ViewState("customFieldDataVar")   'henüz kayıt yoksa 0 varsa id'si geliyo

        Dim dt As Data.DataTable = getSatisPaketFromGrid()


        Dim tutar As Decimal = getSatisToplam()
        If tutar = 0 Then
            Exit Sub
        End If

        Dim isChanged As Boolean = isSatisPaketChanged(dt, ViewState("satisPaketFromAgent"))

        If isChanged Then
            knt.setSatisOnayWithPaketChange(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), tutar, txtNotbyKont.Text.Trim, _
                                customFieldID, f1, f2, f3, f4, f5, f6, f7, dt, txtAdres1.Text.Trim, txtAdres2PlusPostaKod.Text.Trim, txtPostaKod.Text.Trim, txtSehir.Text.Trim, txtTeslimKisi.Text.Trim, txtTeslimTel.Text.Trim)
        Else
            knt.setSatisOnay(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), txtNotbyKont.Text.Trim, _
                                customFieldID, f1, f2, f3, f4, f5, f6, f7, txtAdres1.Text.Trim, txtAdres2PlusPostaKod.Text.Trim, txtPostaKod.Text.Trim, txtSehir.Text.Trim, txtTeslimKisi.Text.Trim, txtTeslimTel.Text.Trim)
        End If
        'sts.writeSatisIslemleri


        If chkKontAuto.Checked Then
            getSatilanDataFromList(0)
            satilanListesiPopulate()
        Else
            satilanListesiPopulate()
            emptyFields()
            canvasOrtu.Visible = True

        End If

        mpeSoldOnay.Hide()


    End Sub

    Protected Sub btnSoldOnayIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSoldOnayIptal.Click
        mpeSoldOnay.Hide()

    End Sub

    Protected Sub btnSoldOnayCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSoldOnayCancel.Click
        mpeSoldOnay.Hide()

    End Sub

    Protected Sub btnGeriGonderTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeriGonderTamam.Click


        knt.agenteGeriGonder(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), ViewState("satanAgentID"), txtGeriGonderNot.Text.Trim)



        If chkKontAuto.Checked Then
            getSatilanDataFromList(0)
            satilanListesiPopulate()
        Else
            satilanListesiPopulate()
            emptyFields()
            canvasOrtu.Visible = True

        End If

        mpeGeriGonder.Hide()
    End Sub

    Protected Sub btnGeriGonderIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeriGonderIptal.Click
        mpeGeriGonder.Hide()
    End Sub

    Protected Sub btnGeriGonderCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGeriGonderCancel.Click
        mpeGeriGonder.Hide()
    End Sub

    Protected Sub timerSatisList_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerSatisList.Tick
        If lblRecNo.Text.Trim.Length < 1 And chkKontAuto.Checked Then
            getSatilanDataFromList(0)
        End If
        satilanListesiPopulate()
    End Sub

    Protected Sub grdOncekiGorusmeler_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOncekiGorusmeler.SelectedIndexChanged


        Dim dtNote As Data.DataTable = knt.getNotesOnSale(CInt(lblRecNo.Text))

        rptNotlarPop.DataSource = dtNote
        rptNotlarPop.DataBind()
        dtNote.Dispose()
        lblFromGorevList.Text = "Önceki görüşme logları!"
        mpeFromGorevList.Show()

    End Sub


    Protected Sub btnFromGorevListCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFromGorevListCancel.Click
        mpeFromGorevList.Hide()

    End Sub

    Protected Sub btnFromGorevListTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFromGorevListTamam.Click
        mpeFromGorevList.Hide()
    End Sub
End Class
