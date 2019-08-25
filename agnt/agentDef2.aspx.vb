Imports System.Threading
Imports System.Globalization

Partial Class agnt_agentDef2
    Inherits System.Web.UI.Page

    Dim dataIsl As New dataGetirmeIslemleri
    Dim datas As New datas
    Dim sts As New satis

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  InitializeCulture()

        ' Dim aaa As String = datas.sifreCoz("QYcaEVeeqlH7shOYTpffCw==")

        If Not IsPostBack Then


            btnRandevuTamam.Attributes.Add("onClick", "return birSureDisable(this);")
            btnRandevuIptal.Attributes.Add("onClick", "return birSureDisable(this);")
            btnSatisTamam.Attributes.Add("onClick", "return birSureDisable(this);")
            btnNotSoldTamam.Attributes.Add("onClick", "return birSureDisable(this);")
            btnOnGorTamam.Attributes.Add("onClick", "return birSureDisable(this);")


            imgLogo.ImageUrl = "../images/logo/" + sts.getLogo(Session("firmID"))

            btnAra.Attributes.Add("onclick", "runExe()")
            lblAgentAdSoyad.Text = Session("adSoyad")

            Dim prC As Integer = projeCombosuHazirla()

            If prC = 0 Then
                uyariDataYok.uyar("Agent olarak tanımlı olduğunuz bir proje yok!", "#ff1111", "")
                Exit Sub
            End If


            beforeDataGetirme()
            dataGetirmeIslemleri()

        End If




    End Sub

    Sub beforeDataGetirme()
        Session("isYenilemeProjesi") = sts.isYenilemeProjesi(cmbProje.SelectedValue)
        Session("isSelfKontroller") = sts.isSelfKontroller(cmbProje.SelectedValue)

        Select Case Session("isYenilemeProjesi")
            Case 1      'yenileme projesi, ön görüşme yapılmayacak
                divYenilemeOrMemnuniyet.Visible = True
                'radioYenilemeOrMemnuniyet.Enabled = False
                'radioYenilemeOrMemnuniyet.Items(0).Selected = True
                chkYenileme.Enabled = False
                chkMemnuniyet.Enabled = False
                chkYenileme.Checked = True
                btnSattim.Visible = True
                btnOnGorusme.Visible = False

            Case 2      'yenileme projesi, ön görüşme yapılacak
                divYenilemeOrMemnuniyet.Visible = True
                'radioYenilemeOrMemnuniyet.Enabled = True
                'radioYenilemeOrMemnuniyet.Items(1).Selected = True  'ön görüşme modu ile açılacak

                chkYenileme.Enabled = True
                chkMemnuniyet.Enabled = True
                chkMemnuniyet.Checked = True

                btnSattim.Visible = False
                btnOnGorusme.Visible = True

        End Select
    End Sub

    Function projeCombosuHazirla() As Integer
        Dim pr As New proje
        'Dim dt As Data.DataTable = pr.getProjectsByUser(Session("firmID"), Session("agentID"), 1)
        Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 1) '1: agent demek


        cmbProje.DataTextField = "proje"
        cmbProje.DataValueField = "projeID"

        cmbProje.DataSource = dt
        cmbProje.DataBind()

        Return dt.Rows.Count
    End Function

    Sub sessionKontrol()
        If Session.IsNewSession Then
            If IsDBNull(Session("agentID")) Or Session("agentID") = 0 Then
                Session.Abandon()
                FormsAuthentication.SignOut()
                Response.Redirect("~/default.aspx")
            End If
        End If

    End Sub

    Sub dataGetirmeIslemleri()


        '        if (Session.IsNewSession == true)
        'Server.Transfer("default.aspx");

        Dim dt As Data.DataTable
        Dim dtLog As Data.DataTable
        'görev listesinde termini gelmiş data varsa onu getir yoksa havuzdan data al, ama en önce sana kapak data varsa onu al
        '--fromWho alanı: 1:normal data(getData'da kullanılacak), 4:randevudan, 
        '		 11:controllerin geri gönderdiği, 69:manuel atanan data

        'yenileme projesi with ön memnuniyet görüşmesi olayından dolayı devre dışı bırakıldı***********************************
        ' '' '' '' ''dt = dataIsl.banaKapakDataGetir(Session("agentID"), cmbProje.SelectedValue)
        ' '' '' '' ''If dt.Rows.Count = 0 Then
        ' '' '' '' ''    dt = dataIsl.gorevListesindenDataGetir(Session("agentID"), cmbProje.SelectedValue)

        ' '' '' '' ''End If
        ' '' '' '' ''If dt.Rows.Count = 0 Then
        ' '' '' '' ''    If Session("isYenilemeProjesi") > 1 Then
        ' '' '' '' ''        dt = dataIsl.havuzdanDataGetirOrderByTermin(Session("agentID"), cmbProje.SelectedValue)

        ' '' '' '' ''    Else
        ' '' '' '' ''        dt = dataIsl.havuzdanDataGetir(Session("agentID"), cmbProje.SelectedValue)
        ' '' '' '' ''    End If

        ' '' '' '' ''End If

        Select Case Session("isYenilemeProjesi")

            Case 0      'normal proje
                dt = dataIsl.banaKapakDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)
                If dt.Rows.Count = 0 Then
                    dt = dataIsl.gorevListesindenDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)

                End If
                If dt.Rows.Count = 0 Then
                    dt = dataIsl.havuzdanDataGetir(Session("agentID"), cmbProje.SelectedValue)

                End If
            Case 1      'yenileme projesi ön görüşme yok
                dt = dataIsl.banaKapakDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)
                If dt.Rows.Count = 0 Then
                    dt = dataIsl.gorevListesindenDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)

                End If
                If dt.Rows.Count = 0 Then
                    dt = dataIsl.havuzdanDataGetirOrderByTermin(Session("agentID"), cmbProje.SelectedValue, 0)

                End If

            Case 2      'yenileme with ön görüşme

                If chkYenileme.Checked Then     'yenieleme casei - bu durumda ön görüşmesi yapılmış data getirilir sadece
                    dt = dataIsl.banaKapakDataGetir(Session("agentID"), cmbProje.SelectedValue, 1)
                    If dt.Rows.Count = 0 Then
                        dt = dataIsl.gorevListesindenDataGetir(Session("agentID"), cmbProje.SelectedValue, 1)

                    End If
                    If dt.Rows.Count = 0 Then
                        dt = dataIsl.havuzdanDataGetirOrderByTerminForMEAndDisabledAgent(Session("agentID"), cmbProje.SelectedValue, 1)

                    End If
                End If

                If chkMemnuniyet.Checked Then     'ön görüşme için data getirimi - daha önce ön görüşülmemiş
                    dt = dataIsl.banaKapakDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)
                    If dt.Rows.Count = 0 Then
                        dt = dataIsl.gorevListesindenDataGetir(Session("agentID"), cmbProje.SelectedValue, 0)

                    End If
                    If dt.Rows.Count = 0 Then
                        dt = dataIsl.havuzdanDataGetirOrderByTermin(Session("agentID"), cmbProje.SelectedValue, 0)

                    End If


                End If


        End Select


        'randevu gridi populate
        Dim agnt As New agents
        Dim dtRandevu As Data.DataTable = agnt.getMyRandevuS(Session("agentID"), cmbProje.SelectedValue)


        grdRandevuS.Columns(0).Visible = True
        grdRandevuS.DataSource = dtRandevu
        grdRandevuS.DataBind()
        grdRandevuS.Columns(0).Visible = False
        '----------------------------------------


        If dt.Rows.Count = 0 Then
            emptyFields()
            uyariDataYok.uyar("Bu proje için havuzda data bulunamadı!", "#333333", "")
            Exit Sub
        End If


        ViewState("whatGorevList") = 0
        fillFields(dt)
        'görev listesinden geliyosa (çoğunlukla) önceki işlemlerin log ve notları
        dtLog = dataIsl.dataLogGetir(dt.Rows(0).Item("havuzID"))


        grdOncekiGorusmeler.Columns(0).Visible = True
        grdOncekiGorusmeler.Columns(1).Visible = True
        grdOncekiGorusmeler.Columns(2).Visible = True


        grdOncekiGorusmeler.DataSource = dtLog
        grdOncekiGorusmeler.DataBind()

        grdOncekiGorusmeler.Columns(0).Visible = False
        grdOncekiGorusmeler.Columns(1).Visible = False
        grdOncekiGorusmeler.Columns(2).Visible = False

        '----------------------- Görev Listesinden gelen data ise popup çıksın -------------------

        If ViewState("whatGorevList") <> 1 Then

            Dim knt As New kontroller
            Dim dtNote As Data.DataTable = knt.getNotesOnSale(dt.Rows(0).Item("havuzID"))
            rptNotlar.DataSource = dtNote
            rptNotlar.DataBind()
        End If

        If ViewState("whatGorevList") = 11 Then 'kontrollerden dönen
            lblFromGorevList.Text = "Kontroller'den dönen kayıt!"
            mpeFromGorevList.Show()
        End If

        If ViewState("whatGorevList") = 4 Then 'randevu ile gelen
            lblFromGorevList.Text = "Randevu ile gelen kayıt!"
            mpeFromGorevList.Show()
        End If

        '-------------------------------------------------
    End Sub

    Sub fillFields(ByVal dt As Data.DataTable)
        Dim datas As New datas
        Dim tel1, tel2, tel3 As String

        'atanan görev ise bunları belirt
        ViewState("whatGorevList") = dt.Rows(0).Item("fromWho") '1 ise havuzdan ya da kapaktan gelme
        ViewState("agentGorevListID") = dt.Rows(0).Item("agentGorevListID") 'görev listesinden gelmiyosa data 0 döner

        '-------------------------
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
            setAppearanceTelButons()
            'adres + e-mail
            lblAdres1.Text = IIf(IsDBNull(.Item("adres1")), "", .Item("adres1"))
            lblAdres2PlusPostaKod.Text = IIf(IsDBNull(.Item("adres2")), "", .Item("adres2"))
            lblPostaKod.Text = IIf(IsDBNull(.Item("postaKod")), "", .Item("postaKod"))
            lblSehir.Text = IIf(IsDBNull(.Item("sehir")), "", .Item("sehir"))
            lblEMail.Text = IIf(IsDBNull(.Item("eMail")), "", .Item("eMail"))

            txtAdres1.Text = IIf(IsDBNull(.Item("adres1")), "", .Item("adres1"))
            txtAdres2PlusPostaKod.Text = IIf(IsDBNull(.Item("adres2")), "", .Item("adres2"))
            txtPostaKod.Text = IIf(IsDBNull(.Item("postaKod")), "", .Item("postaKod"))
            txtSehir.Text = IIf(IsDBNull(.Item("sehir")), "", .Item("sehir"))
            txtEMail.Text = IIf(IsDBNull(.Item("eMail")), "", .Item("eMail"))

            'default bu deger gelir satışta değişebilir
            txtTeslimKisi.Text = ViewState("adSoyad1")
            txtTeslimTel.Text = ViewState("tel1")
            '----------------------------------------

            txtTelNoHeaderEkle.Text = IIf(IsDBNull(.Item("tel1Head")), "", .Item("tel1Head"))

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

            If Session("isYenilemeProjesi") > 0 Then
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

        btnTel2.ImageUrl = "../images/2g.png"
        btnTel2.Enabled = False
        btnTel3.ImageUrl = "../images/3g.png"
        btnTel3.Enabled = False

        'adres + e-mail
        lblAdres1.Text = ""
        lblAdres2PlusPostaKod.Text = ""
        lblSehir.Text = ""
        lblEMail.Text = ""
        lblPostaKod.Text = ""
        txtAdres1.Text = ""
        txtAdres2PlusPostaKod.Text = ""
        txtPostaKod.Text = ""
        txtSehir.Text = ""
        txtEMail.Text = ""

        txtTeslimKisi.Text = ""
        txtTeslimTel.Text = ""

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

        grdOncekiGorusmeler.DataSource = Nothing
        grdOncekiGorusmeler.DataBind()

        grdRandevuS.DataSource = Nothing
        grdRandevuS.DataBind()


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

    'Public Sub testDataEkle()
    '    Dim dt As New Data.DataTable
    '    Dim dr As Data.DataRow
    '    dt.Columns.Add("tarih")
    '    dt.Columns.Add("proje")
    '    dt.Columns.Add("islem")

    '    dr = dt.NewRow()
    '    dr("tarih") = "17.03.2010"
    '    dr("proje") = "Sony Oyun Satış"
    '    dr("islem") = "Alınmadı"
    '    dt.Rows.Add(dr)

    '    dr = dt.NewRow()
    '    dr("tarih") = "06.08.2010"
    '    dr("proje") = "Dergi Abone Satış"
    '    dr("islem") = "Aldı"
    '    dt.Rows.Add(dr)

    '    grdOncekiGorusmeler.DataSource = dt
    '    grdOncekiGorusmeler.DataBind()


    'End Sub
    'Protected Overrides Sub InitializeCulture()
    '    ' Dim dil As String = Request("DropDownList1") ' dropdowndan gelen deger
    '    ' If String.IsNullOrEmpty(dil) Then dil = "Auto" ' eger dil bossa otamatik olarak belirle
    '    'UICulture = "en-US"
    '    'Culture = "en-US"

    '    ' Dim mLabel As Label = CType(Master.FindControl("lblLangHidden"), Label)

    '    'Dim lang As String = mLabel.Text  '"tr-TR"
    '    'If lang = "" Then lang = "tr-TR"


    '    Dim lang As String = Request("lng") ' "tr-TR"
    '    If lang = "" Then lang = "tr-TR"
    '    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang)

    '    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang)


    'End Sub


    Protected Sub btnSonraAra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSonraAra.Click

        txtRandevuAcikla.Text = ""
        txtTarih.Text = ""
        txtXGun.Text = ""
        txtZaman.Text = ""
        rd1Gun.Checked = False
        rd2Gun.Checked = False
        rdXGun.Checked = False
        rdTarihSaat.Checked = False
        mpeSonraAra.Show()
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        mpeSonraAra.Hide()

    End Sub




    Protected Sub rd1Gun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd1Gun.CheckedChanged
        If rd1Gun.Checked Then rd1Gun.Focus()

    End Sub

    Protected Sub rdXGun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdXGun.CheckedChanged
        If rdXGun.Checked Then txtXGun.Focus()

    End Sub

    Protected Sub rd2Gun_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rd2Gun.CheckedChanged
        If rd2Gun.Checked Then rd2Gun.Focus()
    End Sub

    Protected Sub rdTarihSaat_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTarihSaat.CheckedChanged
        If rdTarihSaat.Checked Then txtTarih.Focus()
    End Sub


    Protected Sub btnAdSoy1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy1.Click
        sessionKontrol()

        lblAdSoyad.Text = ViewState("adSoyad1")
    End Sub

    Protected Sub btnAdSoy2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy2.Click
        sessionKontrol()
        lblAdSoyad.Text = ViewState("adSoyad2")
    End Sub

    Protected Sub btnAdSoy3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdSoy3.Click
        sessionKontrol()
        lblAdSoyad.Text = ViewState("adSoyad3")
    End Sub

    Protected Sub btnTel1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel1.Click
        sessionKontrol()
        lblTelNo.Text = ViewState("tel1")
    End Sub

    Protected Sub btnTel2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel2.Click
        sessionKontrol()
        lblTelNo.Text = ViewState("tel2")
    End Sub

    Protected Sub btnTel3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTel3.Click
        sessionKontrol()
        lblTelNo.Text = ViewState("tel3")
    End Sub

    Protected Sub btnSattim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSattim.Click
        sessionKontrol()

        customSatisFieldleriInitiate()
        satisPaketleriInitiate()
        lblToplamUcret.Text = ""

        lblSatisPopupBaslik.Text = cmbProje.SelectedItem.Text
        lblSatisPopupBaslikAlt.Text = lblBayBayan.Text + " " + lblAdSoyad.Text

        mpeSatis.Show()

    End Sub
    Sub satisPaketleriInitiate()
        Dim dt As Data.DataTable = dataIsl.getProjeSatisPaket(cmbProje.SelectedValue)

        grdSatisPaket.Columns(0).Visible = True
        grdSatisPaket.Columns(7).Visible = True
        grdSatisPaket.DataSource = dt
        grdSatisPaket.DataBind()
        grdSatisPaket.Columns(0).Visible = False
        grdSatisPaket.Columns(7).Visible = False
    End Sub

    Sub customSatisFieldleriInitiate()
        Dim cusFieldExist As Boolean = False
        Dim dtCFDef As Data.DataTable = dataIsl.getCustomFieldsOnSaleDef(cmbProje.SelectedValue, CInt(lblRecNo.Text))

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

                'If Not IsDBNull(.Rows(0).Item("fNotAd")) Then
                '    cusFieldExist = True
                lblNot.Text = "Not" '.Rows(0).Item("fNotAd")
                '    txtNot.Text = getCustFieldIcerik(.Rows(0).Item("fNot"), 0)
                txtNot.Text = ""
                If Not cusFieldExist Then txtNot.Focus()
                'End If

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


    Sub setVisibilityOfImg(ByVal isSifreli As Integer, ByVal isSil As Integer, ByRef imgSif As Image, ByRef imgSil As Image)
        If isSifreli = 1 Then
            imgSif.Visible = True
        End If
        If isSil = 1 Then
            imgSil.Visible = True
        End If
    End Sub

    Protected Sub btnSatisIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatisIptal.Click

        sessionKontrol()
        mpeSatis.Hide()

    End Sub

    Protected Sub btnSatisCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSatisCancel.Click
        sessionKontrol()
        mpeSatis.Hide()

    End Sub

 

    Protected Sub btnToplamUcret_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToplamUcret.Click
        sessionKontrol()
        lblToplamUcret.Text = getSatisToplam.ToString

    End Sub

    Function getSatisToplam() As Decimal
        Dim i As Integer
        Dim chkd As Boolean
        Dim isAnyPaketSelected As Boolean = False
        Dim toplam As Decimal = 0
        Dim adet As Integer
        Dim fiyat As Decimal

        With grdSatisPaket
            For i = 0 To .Rows.Count - 1
                chkd = CType(.Rows(i).Cells(6).Controls(1), CheckBox).Checked
                If chkd Then
                    isAnyPaketSelected = True
                    adet = CInt(CType(.Rows(i).Cells(5).Controls(1), TextBox).Text)
                    fiyat = CDec(.Rows(i).Cells(3).Text)

                    toplam += adet * fiyat

                End If
            Next

        End With
        If isAnyPaketSelected And toplam = 0 Then toplam = 1

        Return toplam

    End Function

    Protected Sub btnSatisTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatisTamam.Click

        sessionKontrol()

        Dim f1 As String = getFieldValue(txtCF1.Text, txtCF1.Visible, imgCFSifre1.Visible)  'sifreli alansa şifreleyip alıyor, kullanılmayan alansa "" geliyo
        Dim f2 As String = getFieldValue(txtCF2.Text, txtCF2.Visible, imgCFSifre2.Visible)
        Dim f3 As String = getFieldValue(txtCF3.Text, txtCF3.Visible, imgCFSifre3.Visible)
        Dim f4 As String = getFieldValue(txtCF4.Text, txtCF4.Visible, imgCFSifre4.Visible)
        Dim f5 As String = getFieldValue(txtCF5.Text, txtCF5.Visible, imgCFSifre5.Visible)
        Dim f6 As String = getFieldValue(txtCF6.Text, txtCF6.Visible, imgCFSifre6.Visible)
        Dim f7 As String = getFieldValue(txtCF7.Text, txtCF7.Visible, imgCFSifre7.Visible)

        Dim customFieldID As Integer = ViewState("customFieldDataVar")   'henüz kayıt yoksa 0 varsa id'si geliyo

        Dim dt As Data.DataTable = getSatisPaketFromGrid


        Dim tutar As Decimal = getSatisToplam()
        If tutar = 0 Then
            Exit Sub
        End If


        sts.writeSatisIslemleri(cmbProje.SelectedValue, CInt(lblRecNo.Text), 1, Session("agentID"), tutar, txtNot.Text.Trim, _
                                customFieldID, f1, f2, f3, f4, f5, f6, f7, dt, txtAdres1.Text.Trim, txtAdres2PlusPostaKod.Text.Trim, txtPostaKod.Text.Trim, _
                                txtSehir.Text.Trim, txtEMail.Text.Trim, txtTeslimKisi.Text.Trim, txtTeslimTel.Text.Trim)


        'görev listesinden alındı ise complated'ini 1 yap
        If ViewState("agentGorevListID") <> 0 Then
            sts.gorevListesiniComplatedYap(ViewState("agentGorevListID"))
            Dim knt As New kontroller
            knt.releaseDataByKontroller(CInt(lblRecNo.Text))
        End If

        'yeni data getir
        dataGetirmeIslemleri()
        mpeSatis.Hide()

    End Sub

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

    Function getFieldValue(ByVal str As String, ByVal isFieldExist As Boolean, ByVal isSifre As Boolean) As String
        Dim tmpStr As String = ""

        If isFieldExist Then
            If isSifre Then
                tmpStr = datas.sifrele(str)
            Else
                tmpStr = str
            End If

        End If

        Return tmpStr

    End Function



    Protected Sub btnNotSoldIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNotSoldIptal.Click
        mpeNotSold.Hide()

    End Sub

    Protected Sub btnNotSoldCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNotSoldCancel.Click

        sessionKontrol()
        mpeNotSold.Hide()

    End Sub

    Protected Sub btnSatilmadi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSatilmadi.Click

        sessionKontrol()
        txtNotSold.Text = ""
        mpeNotSold.Show()

    End Sub

    Protected Sub btnNotSoldTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNotSoldTamam.Click
        sessionKontrol()
        sts.notSoldIslemleri(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), txtNotSold.Text.Trim)

        'görev listesinden alındı ise complated'ini 1 yap
        If ViewState("agentGorevListID") <> 0 Then
            sts.gorevListesiniComplatedYap(ViewState("agentGorevListID"))
        End If

        dataGetirmeIslemleri()
        mpeNotSold.Hide()


    End Sub

    Protected Sub btnRandevuTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRandevuTamam.Click

        sessionKontrol()
        Dim isSelected As Boolean = isTarihSelected()
        If Not isSelected Then Exit Sub

        Dim termin As DateTime = computeTerminTarih()
        sts.writeRandevuIslemleri(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), 4, txtRandevuAcikla.Text.Trim, termin)
        dataGetirmeIslemleri()
        mpeSonraAra.Hide()

    End Sub

    Function isTarihSelected() As Boolean
        Dim isSelected As Boolean = False
        If rd1Gun.Checked Then
            isSelected = True
        End If
        If rd2Gun.Checked Then
            isSelected = True
        End If
        '  If rdXGun.Checked Then   'seçmeden zaman girebiliyolar
        If txtXGun.Text.Length > 0 And IsNumeric(txtXGun.Text.Trim) Then
            isSelected = True
            rdXGun.Checked = True
        End If
        'End If
        '  If rdTarihSaat.Checked Then
        If txtTarih.Text.Trim.Length > 3 And txtZaman.Text.Trim.Length > 3 Then
            isSelected = True
            rdTarihSaat.Checked = True
        End If
        'End If
        Return isSelected
    End Function
    Function computeTerminTarih() As DateTime
        Dim tt As DateTime
        Dim tmpS As String

        If rd1Gun.Checked Then
            tt = DateAdd(DateInterval.Day, 1, DateAdd(DateInterval.Hour, 3, Date.UtcNow))
        End If
        If rd2Gun.Checked Then
            tt = DateAdd(DateInterval.Day, 2, DateAdd(DateInterval.Hour, 3, Date.UtcNow))
        End If
        If rdXGun.Checked Then
            tt = DateAdd(DateInterval.Day, CInt(txtXGun.Text), DateAdd(DateInterval.Hour, 3, Date.UtcNow))
        End If

        If rdTarihSaat.Checked Then
            tmpS = txtTarih.Text + " " + txtZaman.Text

            Dim DTFI As New System.Globalization.DateTimeFormatInfo
            DTFI.ShortDatePattern = "MM/dd/yyyy HH:mm"
            tt = DateTime.Parse(tmpS, DTFI)

        End If

        Return tt
    End Function

    Protected Sub btnUlasilamadi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUlasilamadi.Click
        'iki gün sonraya işlemID=3 ile randevu verilir
        If ViewState("whatGorevList") = 3 Then 'zaten ulaşılamayan dan gelen data ise yeni randevu almadan geç, böylece ulaşılamayan data en fazla 2 defa gelir!


            sts.gorevListesiniComplatedYap(ViewState("agentGorevListID"))

        Else

            Dim termin As DateTime = DateAdd(DateInterval.Day, 2, DateAdd(DateInterval.Hour, 3, Date.UtcNow))
            sts.writeRandevuIslemleri(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), 3, "", termin)
        End If

        dataGetirmeIslemleri()

    End Sub

    Protected Sub btnYanlisEksikNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYanlisEksikNo.Click
        sessionKontrol()

        sts.updateYanlisEksikNo(CInt(lblRecNo.Text), Session("agentID"))
        'görev listesinden alındı ise complated'ini 1 yap
        If ViewState("agentGorevListID") <> 0 Then
            sts.gorevListesiniComplatedYap(ViewState("agentGorevListID"))
        End If

        dataGetirmeIslemleri()

    End Sub


    Protected Sub btnTekrarArama_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTekrarArama.Click
        'black liste ekle
        sessionKontrol()
        '
        sts.writeDataToBlackList(Session("firmID"), CInt(lblRecNo.Text), Session("agentID"), ViewState("tel1"), ViewState("tel2"), ViewState("tel3"))

        'görev listesinden alındı ise complated'ini 1 yap
        If ViewState("agentGorevListID") <> 0 Then
            sts.gorevListesiniComplatedYap(ViewState("agentGorevListID"))
        End If

        dataGetirmeIslemleri()


    End Sub

    Protected Sub btnFromGorevListCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFromGorevListCancel.Click
        sessionKontrol()
        mpeFromGorevList.Hide()
    End Sub

    Protected Sub btnFromGorevListTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFromGorevListTamam.Click
        sessionKontrol()
        mpeFromGorevList.Hide()
    End Sub

    Protected Sub tabContainerAgent_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabContainerAgent.ActiveTabChanged

        sessionKontrol()
        If tabContainerAgent.ActiveTabIndex = 1 Then
            populateGrdSatislarim()

        End If
        If tabContainerAgent.ActiveTabIndex = 2 Then
            populateAgents(cmbProje.SelectedValue)

        End If


    End Sub

    Sub populateAgents(ByVal projeID As Integer)

        lblProjeSatisAdet.Text = 0
        Dim ag As New agents
        Dim dt As Data.DataTable = ag.getAgentsByProject(projeID)

        grdAgents.Columns(0).Visible = True
        grdAgents.Columns(1).Visible = True
        grdAgents.Columns(2).Visible = True
        grdAgents.Columns(3).Visible = True
        grdAgents.Columns(4).Visible = True
        grdAgents.Columns(5).Visible = True
        grdAgents.Columns(6).Visible = True


        grdAgents.DataSource = dt
        grdAgents.DataBind()

        grdAgents.Columns(0).Visible = False
        grdAgents.Columns(1).Visible = False
        grdAgents.Columns(2).Visible = False
        grdAgents.Columns(3).Visible = False
        grdAgents.Columns(4).Visible = False
        grdAgents.Columns(5).Visible = False
        grdAgents.Columns(6).Visible = False

        dt.Dispose()
        ag = Nothing

    End Sub

    Sub populateGrdSatislarim()
        Dim dt As Data.DataTable

        dt = sts.getSattiklarim(cmbProje.SelectedValue, Session("agentID"))

        grdSatislarim.Columns(1).Visible = True
        grdSatislarim.Columns(7).Visible = True
        grdSatislarim.Columns(8).Visible = True
        grdSatislarim.Columns(9).Visible = True

        grdSatislarim.DataSource = dt
        grdSatislarim.DataBind()

        grdSatislarim.Columns(1).Visible = False
        grdSatislarim.Columns(9).Visible = False
        If Session("isSelfKontroller") = 0 Then
            grdSatislarim.Columns(7).Visible = False
            grdSatislarim.Columns(8).Visible = False

        End If
        lblSatislarimAdet.Text = dt.Rows.Count.ToString

        dt.Dispose()

    End Sub
    Protected Sub grdSatislarim_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSatislarim.RowCommand


        sessionKontrol()

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        Dim row As GridViewRow = grdSatislarim.Rows(index)
        Dim havuzID As Integer = CInt(row.Cells(0).Text)

        If e.CommandName = "btnSatisSelfOnay" Then
            sts.setSelfSatisOnay(cmbProje.SelectedValue, havuzID, Session("agentID"))
            populateGrdSatislarim()

        End If
        If e.CommandName = "btnSatisSelfIptal" Then
            Dim knt As New kontroller
            knt.agenteGeriGonder(cmbProje.SelectedValue, havuzID, Session("agentID"), Session("agentID"), "***System Not: Satıştan iptal.")
            populateGrdSatislarim()
            uyariDataYok.uyar("İptal edilen satış data ekranınıza dönecektir (aktif datadan sonra ilk kayıt olarak), burdan randevu ya da satılamadı gibi işlemleri yapabilirsiniz.", "", "")
        End If

    End Sub

    Protected Sub grdSatislarim_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSatislarim.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim islem As Integer = CInt(e.Row.Cells(4).Text)

            Dim onayButon As LinkButton = CType(e.Row.Cells(7).Controls(0), LinkButton)
            Dim iptalButon As LinkButton = CType(e.Row.Cells(8).Controls(0), LinkButton)


            Dim durum As String = ""
            Select Case islem
                Case 1
                    If e.Row.Cells(5).Text.Trim.Length > 3 Then 'kontroller ad soyad alanı 1
                        durum = "Kontroller onayında."
                    Else
                        durum = "Onay listesinde."
                    End If

                Case 5
                    durum = "Onaylandı."
                    onayButon.Enabled = False


                Case 11
                    durum = "Geri gönderildi."
                    onayButon.Enabled = False
                    iptalButon.Enabled = False

            End Select
            e.Row.Cells(6).Text = durum

            'tel gösterme durumları

            Dim sifreliTel As String = e.Row.Cells(9).Text
            Try
                If Len(sifreliTel.Trim) > 6 Then
                    e.Row.Cells(10).Text = datas.sifreCoz(sifreliTel)
                Else
                    e.Row.Cells(10).Text = sifreliTel.Trim
                End If
            Catch ex As Exception

            End Try


            '---------

        End If
    End Sub

    Protected Sub cmbProje_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProje.SelectedIndexChanged

        sessionKontrol()
        beforeDataGetirme()
        dataGetirmeIslemleri()

    End Sub

    Protected Sub btnRandevuIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRandevuIptal.Click
        sessionKontrol()
        mpeSonraAra.Hide()
    End Sub

    Protected Sub grdOncekiGorusmeler_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOncekiGorusmeler.SelectedIndexChanged

        sessionKontrol()
        Dim knt As New kontroller
        Dim dtNote As Data.DataTable = knt.getNotesOnSale(CInt(lblRecNo.Text))

        rptNotlar.DataSource = dtNote
        rptNotlar.DataBind()
        dtNote.Dispose()
        lblFromGorevList.Text = "Önceki görüşme logları!"
        mpeFromGorevList.Show()
        

    End Sub



    Protected Sub chkYenileme_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkYenileme.CheckedChanged

        sessionKontrol()

        If chkYenileme.Checked Then
            btnSattim.Visible = True
            btnOnGorusme.Visible = False
            chkMemnuniyet.Checked = False
            dataGetirmeIslemleri()

        End If
    End Sub

    Protected Sub chkMemnuniyet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMemnuniyet.CheckedChanged

        sessionKontrol()
        If chkMemnuniyet.Checked Then
            btnSattim.Visible = False
            btnOnGorusme.Visible = True
            chkYenileme.Checked = False
            dataGetirmeIslemleri()

        End If
    End Sub


    Protected Sub btnOnGorusme_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOnGorusme.Click

        sessionKontrol()
        txtOnGorNote.Text = ""
        mpeOnGor.Show()

        'txtOnGorNote.Focus()

    End Sub

    Protected Sub btnOnGorIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOnGorIptal.Click
        sessionKontrol()
        mpeOnGor.Hide()

    End Sub

    Protected Sub btnOnGorCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOnGorCancel.Click
        sessionKontrol()
        mpeOnGor.Hide()

    End Sub

    Protected Sub btnOnGorTamam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOnGorTamam.Click
        sessionKontrol()
        datas.writeOnGorusme(cmbProje.SelectedValue, CInt(lblRecNo.Text), Session("agentID"), txtOnGorNote.Text.Trim)
        dataGetirmeIslemleri()
        mpeOnGor.Hide()

    End Sub


    Protected Sub grdAgents_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgents.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim agentID As Integer = CInt(e.Row.Cells(0).Text)
            Dim isHome As Integer = CInt(e.Row.Cells(1).Text)
            Dim numOfProje As Integer = CInt(e.Row.Cells(2).Text)
            Dim roleID As Integer = CInt(e.Row.Cells(4).Text)
            Dim isAktif As Integer = CInt(e.Row.Cells(3).Text)
            Dim bugunSatis As Integer = CInt(e.Row.Cells(14).Text)

            lblProjeSatisAdet.Text = CInt(lblProjeSatisAdet.Text) + bugunSatis


            If isAktif = 0 Then
                CType(e.Row.Cells(15).Controls(1), Image).ImageUrl = "~/images/grid/userGray.png"
                CType(e.Row.Cells(17).Controls(0), LinkButton).Text = "Ekle"
            End If

            If isHome = 1 Then
                Dim img As New Image
                img.ImageUrl = "..\images\home.png"
                img.AlternateText = "Home Agnt"
                img.ToolTip = "Home Agent"
                e.Row.Cells(7).Controls.Add(img)

            Else

                e.Row.Cells(7).Text = ""
            End If

            If isAktif = 0 Then
                e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#ececec")
            End If

            If roleID = 2 Then

                e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FCFCE9")
            End If
            If roleID = 3 Then

                e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#C9E2E9")
            End If


        End If

    End Sub

    Protected Sub txtXGun_TextChanged(sender As Object, e As System.EventArgs) Handles txtXGun.TextChanged
        rdXGun.Checked = True

    End Sub
End Class
