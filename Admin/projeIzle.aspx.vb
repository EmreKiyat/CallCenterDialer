
Partial Class Admin_projeIzle
    Inherits System.Web.UI.Page
    Dim pr As New proje

    'Protected Sub radioActiveOrTum_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioActiveOrTum.SelectedIndexChanged

    '    populateProjeCombo(radioActiveOrTum.SelectedValue)


    'End Sub
    Sub populateProjeComboForPS(ByRef dt As Data.DataTable)
        cmbProjeSecim.DataSource = dt
        cmbProjeSecim.DataTextField = "proje"
        cmbProjeSecim.DataValueField = "projeID"
        cmbProjeSecim.DataBind()

        ProjeAnaBilgileriGuncelle()
        populateOzetByExcel(cmbProjeSecim.SelectedValue)

    End Sub

    Function populateProjeCombo(ByVal activeOrTum As Integer) As Boolean
        Dim dt As Data.DataTable
        Dim ret As Boolean = True
        If activeOrTum = 1 Then
            dt = pr.getProjectsByFirmForCmb(Session("firmID"), True)      'aktif projeler

        Else
            dt = pr.getProjectsByFirmForCmb(Session("firmID"), False)     'tüm projeler

        End If

        If dt.Rows.Count <> 0 Then

            cmbProjeSecim.DataSource = dt
            cmbProjeSecim.DataTextField = "proje"
            cmbProjeSecim.DataValueField = "projeID"
            cmbProjeSecim.DataBind()

            ProjeAnaBilgileriGuncelle()
            populateOzetByExcel(cmbProjeSecim.SelectedValue)
            ret = True
        Else
            ret = False

        End If
        Return ret
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim isProjeExist As Boolean = True


        If Not IsPostBack Then

            'btnDataPaketHavuza.Attributes.Add("onClick", "return birSureDisable(this);")
            'btnDataSec.Attributes.Add("onClick", "return birSureDisable(this);")

            'btnActivateUlasilamayan.Attributes.Add("onClick", "return birSureDisable(this);")
            'btnDeActivateUlasilamayan.Attributes.Add("onClick", "return birSureDisable(this);")


            Dim dt As Data.DataTable = pr.getProjectsByUserAndRole(Session("firmID"), Session("agentID"), 3)
            If dt.Rows.Count = 0 And Session("isAdmin") = 0 Then
                ascxUyari.uyar("Admin ya da Proje yöneticisi yetkiniz yok!", "#ff1111", "")
                radioTumPR.Enabled = False
                radioActivePR.Enabled = False

                Exit Sub
            End If

            If Session("isAdmin") = 1 Then
                isProjeExist = populateProjeCombo(1)
                If Not isProjeExist Then
                    ascxUyari.uyar("Tanımlı proje yok, proje tanımlama menüsünü kullanarak proje tanımı yapabilirsiniz.", "#ff1111", "")
                    Exit Sub
                End If
            End If
            If Session("isAdmin") = 0 And dt.Rows.Count <> 0 Then   'proje sorumlusu demekki
                populateProjeComboForPS(dt)
                radioTumPR.Enabled = False
                radioActivePR.Enabled = False
            End If


            ProjeAnaBilgileriGuncelle()
            If tabProjeOzet.ActiveTabIndex = 0 Then
                populateOzetByExcel(cmbProjeSecim.SelectedValue)

            End If


        End If
    End Sub

    Protected Sub radioTumPR_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioTumPR.CheckedChanged

        If radioTumPR.Checked Then populateProjeCombo(2)

    End Sub

    Protected Sub radioActivePR_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioActivePR.CheckedChanged
        If radioActivePR.Checked Then populateProjeCombo(1)
    End Sub

    Protected Sub cmbProjeSecim_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProjeSecim.SelectedIndexChanged
        '        pr.getProjDataPaketInf(cmbProjeSecim.SelectedValue)
        ProjeAnaBilgileriGuncelle()

        If tabProjeOzet.ActiveTabIndex = 0 Then
            populateOzetByExcel(cmbProjeSecim.SelectedValue)
        End If
        If tabProjeOzet.ActiveTabIndex = 1 Then
            populateAgents(cmbProjeSecim.SelectedValue)
        End If
        If tabProjeOzet.ActiveTabIndex = 2 Then
            ' populateSatisPaket(cmbProjeSecim.SelectedValue)
        End If



    End Sub


    Sub ProjeAnaBilgileriGuncelle()
        Dim dtLive As Data.DataTable = pr.getProjeDataOzetOnLive(cmbProjeSecim.SelectedValue)
        Dim dtProcessed As Data.DataTable = pr.getProjeDataOzetProcessed(cmbProjeSecim.SelectedValue)
        Dim dtBugun As Data.DataTable = pr.getProjeDataOzetToday(cmbProjeSecim.SelectedValue)

        Dim i As Integer
        Dim cntTum As Integer = 0
        Dim cntNotProcessed As Integer = 0      'islem=0 => 
        Dim cntSold As Integer = 0              'islem=1 => 
        Dim cntNotSold As Integer = 0           'islem=2
        Dim cntUlasilamadi As Integer = 0       'islem=3 =>     
        Dim cntRandevu As Integer = 0           'islem=4 =>     
        Dim cntSoldCommitted As Integer = 0     'islem=5 => 
        Dim cntYanlis As Integer = 0            'islem=6 => 
        Dim cntDataEksik As Integer = 0           'islem=7
        Dim cntBlackList As Integer = 0         'islem=99 => 
        Dim cntBugunArama As Integer = 0
        Dim cntBugunSatis As Integer = 0


        If dtLive.Rows.Count > 0 Then cntNotProcessed = dtLive.Rows(0).Item(0)

        For i = 0 To dtProcessed.Rows.Count - 1
            Select Case dtProcessed.Rows(i).Item(1)

                Case 1
                    cntSold = dtProcessed.Rows(i).Item(0)
                Case 2
                    cntNotSold = dtProcessed.Rows(i).Item(0)
                Case 3
                    cntUlasilamadi = dtProcessed.Rows(i).Item(0)
                Case 4
                    cntRandevu = dtProcessed.Rows(i).Item(0)
                Case 5
                    cntSoldCommitted = dtProcessed.Rows(i).Item(0)
                Case 6
                    cntYanlis = dtProcessed.Rows(i).Item(0)
                Case 7
                    cntDataEksik = dtProcessed.Rows(i).Item(0)
                Case 99
                    cntBlackList = dtProcessed.Rows(i).Item(0)

            End Select

            cntTum = cntTum + dtProcessed.Rows(i).Item(0)
        Next

        'bugün arama ve satış bilgisi
        'cntBugunArama = dtBugun.Rows.Count
        cntBugunArama = 0

        For i = 0 To dtBugun.Rows.Count - 1
            If dtBugun.Rows(i).Item(1) = 5 Then cntBugunSatis = dtBugun.Rows(i).Item(0)
            If dtBugun.Rows(i).Item(1) <> 88 Then cntBugunArama += dtBugun.Rows(i).Item(0)

        Next
        '**********

        lblTum.Text = Format$(cntTum + cntNotProcessed, "##,##0").ToString
        lblArama.Text = Format$(cntTum, "##,##0").ToString
        lblNotProcessed.Text = Format$(cntNotProcessed, "##,##0").ToString
        lblSoldCommitted.Text = Format$(cntSoldCommitted, "##,##0").ToString
        lblBuGunArama.Text = Format$(cntBugunArama, "##,##0").ToString
        lblBuGunSatis.Text = Format$(cntBugunSatis, "##,##0").ToString

        'lblTum.Text = Format$(133, "##,##0").ToString

    End Sub


    Sub populateOzetByExcel(ByVal projeID As Integer)
        Dim dt As Data.DataTable
        Dim data As New datas

        dt = data.getActiveDataPaketByProje(Session("firmID"), projeID)

        grdExcel.Columns(0).Visible = True
        grdExcel.Columns(1).Visible = True
        grdExcel.Columns(2).Visible = True

        grdExcel.Columns(12).Visible = True
        grdExcel.Columns(13).Visible = True
        grdExcel.Columns(14).Visible = True
        grdExcel.Columns(15).Visible = True
        grdExcel.Columns(16).Visible = True
        grdExcel.Columns(17).Visible = True
        grdExcel.Columns(18).Visible = True
        grdExcel.Columns(19).Visible = True

        grdExcel.DataSource = dt
        grdExcel.DataBind()


        grdExcel.Columns(0).Visible = False
        grdExcel.Columns(1).Visible = False
        grdExcel.Columns(2).Visible = False


        grdExcel.Columns(12).Visible = False
        grdExcel.Columns(13).Visible = False
        grdExcel.Columns(14).Visible = False
        grdExcel.Columns(15).Visible = False
        grdExcel.Columns(16).Visible = False
        grdExcel.Columns(17).Visible = False
        grdExcel.Columns(18).Visible = False
        grdExcel.Columns(19).Visible = False






    End Sub

    Protected Sub grdExcel_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdExcel.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        Dim row As GridViewRow = grdExcel.Rows(index)

        Dim dataExcelID As Integer = CInt(row.Cells(0).Text)
        Dim isAktif As Integer = CInt(row.Cells(1).Text)


        Dim isStarted As Integer = CInt(row.Cells(2).Text)


        Dim dataPaket As String = row.Cells(3).Text
        Dim createDate As String = row.Cells(4).Text
        Dim numOfData As Integer = CInt(row.Cells(5).Text)
        lblExcelIDForPAketDetayPopup.Text = dataExcelID.ToString + ". "
        lblPaketDetayProjeAdi.Text = cmbProjeSecim.SelectedItem.ToString + " - " + dataPaket

        If e.CommandName = "btnPaketDetay" Then
            Dim adm As New admin
            If isAktif = 1 And isStarted = 1 Then
                btnActivateUlasilamayan.Enabled = True
                btnDeActivateUlasilamayan.Enabled = True

            Else
                btnActivateUlasilamayan.Enabled = False
                btnDeActivateUlasilamayan.Enabled = False

            End If

            lblPaketDataAdet.Text = pr.getNumberOfDataInAPaket(dataExcelID)
            lblPaketDataHavuzAdet.Text = numOfData.ToString  'row.Cells(5).Text
            lblPaketDataOnayliSatis.Text = row.Cells(6).Text
            lblPaketDataOnaysizSatis.Text = row.Cells(19).Text
            lblPaketDataToplamSatis.Text = (CInt(lblPaketDataOnayliSatis.Text) + CInt(lblPaketDataOnaysizSatis.Text)).ToString
            lblPaketDataAktif.Text = CInt(row.Cells(7).Text)
            lblPaketDataSatilamadi.Text = row.Cells(12).Text
            lblPaketDataUlasilamayan.Text = row.Cells(13).Text
            Dim complatedUlasilamayan As Integer = adm.getComplatedUlasilamayanSayisi(cmbProjeSecim.SelectedValue, dataExcelID)
            lblPaketDataUlasilamayanComplated.Text = complatedUlasilamayan.ToString
            lblPaketDataUlasilamayanNotComp.Text = (CInt(row.Cells(13).Text) - complatedUlasilamayan).ToString

            lblPaketDataRandevuda.Text = row.Cells(14).Text
            lblPaketDataEksikHata.Text = row.Cells(15).Text

            lblPaketDataKapak.Text = (CInt(row.Cells(17).Text) + CInt(row.Cells(16).Text)).ToString '16: kontrollerden dönen (11).. kapak olarak değerlendirildi 
            lblPaketDataBlackList.Text = row.Cells(18).Text

            lblPaketDataIslemeAlinan.Text = (numOfData - CInt(lblPaketDataAktif.Text)).ToString




            mpePaketDetay.Show()

        End If


    End Sub

    Protected Sub grdExcel_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdExcel.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim excelID As Integer = CInt(e.Row.Cells(0).Text)
            Dim isAktif As Integer = CInt(e.Row.Cells(1).Text)
            Dim isStarted As Integer = CInt(e.Row.Cells(2).Text)

            Dim cntTum As Integer = 0
            Dim cntNotProcessed As Integer = 0      'islem=0 => 
            Dim cntSold As Integer = 0              'islem=1 => 
            Dim cntNotSold As Integer = 0           'islem=2
            Dim cntUlasilamadi As Integer = 0       'islem=3 =>     
            Dim cntRandevu As Integer = 0           'islem=4 =>     
            Dim cntSoldCommitted As Integer = 0     'islem=5 => 
            Dim cntYanlis As Integer = 0            'islem=6 => 
            Dim cntDataEksik As Integer = 0           'islem=7
            Dim cntBlackList As Integer = 0         'islem=99 => 
            Dim cntBugunArama As Integer = 0
            Dim cntBugunSatis As Integer = 0
            Dim kontDanDonen As Integer = 0         '11
            Dim kapakOlan As Integer = 0            '88


            Dim sImg As Image = e.Row.Cells(9).Controls(1)
            Dim lnkButon As LinkButton = e.Row.Cells(10).Controls(0)

            'Dim lnkButon As System.Web.UI.WebControls.DataControlLinkButton
            Dim dt As Data.DataTable
            Dim datas As New datas

            If isStarted = 1 Then
                dt = datas.getPaketinHavuzDetaili(excelID, cmbProjeSecim.SelectedValue)

                For i = 0 To dt.Rows.Count - 1
                    Select Case dt.Rows(i).Item(1)

                        Case 0
                            cntNotProcessed = dt.Rows(i).Item(0)
                        Case 1
                            cntSold = dt.Rows(i).Item(0)
                        Case 2
                            cntNotSold = dt.Rows(i).Item(0)
                        Case 3
                            cntUlasilamadi = dt.Rows(i).Item(0)
                        Case 4
                            cntRandevu = dt.Rows(i).Item(0)
                        Case 5
                            cntSoldCommitted = dt.Rows(i).Item(0)
                        Case 6
                            cntYanlis = dt.Rows(i).Item(0)
                        Case 7
                            cntDataEksik = dt.Rows(i).Item(0)
                        Case 11
                            kontDanDonen = dt.Rows(i).Item(0)
                        Case 88
                            kapakOlan = dt.Rows(i).Item(0)
                        Case 99
                            cntBlackList = dt.Rows(i).Item(0)

                    End Select

                    cntTum = cntTum + dt.Rows(i).Item(0)

                Next


                '0:              İşlenmeyen()
                '1:              Satılan()
                '2:              Satılamayan()
                '3:              Ulaşılamayan()
                '4:              Randevu()
                '5:              Onaylandi()
                '6	             Yanlis/Eksik No
                '11:             kont.dan(donen)
                '22:             ön(görüşme)
                '88:             Bana(Kapak)
                '99:             Black(List)

            End If

            e.Row.Cells(5).Text = cntTum
            e.Row.Cells(6).Text = cntSoldCommitted
            e.Row.Cells(7).Text = cntNotProcessed

            e.Row.Cells(12).Text = cntNotSold
            e.Row.Cells(13).Text = cntUlasilamadi
            e.Row.Cells(14).Text = cntRandevu
            e.Row.Cells(15).Text = cntYanlis
            e.Row.Cells(16).Text = kontDanDonen
            e.Row.Cells(17).Text = kapakOlan
            e.Row.Cells(18).Text = cntBlackList
            e.Row.Cells(19).Text = cntSold


            If isAktif = 1 And isStarted = 1 Then

                sImg.ImageUrl = "~/images/grid/dbGr.png"
                lnkButon.Text = "Durdur"
            Else
                If e.Row.Cells(7).Text <> "0" Then e.Row.Cells(7).Style.Add("text-decoration", "line-through")
                sImg.ImageUrl = "~/images/grid/dbGray.png"
                lnkButon.Text = "Başlat"
                If e.Row.RowState = 1 Then
                    e.Row.BackColor = Drawing.Color.FromName("#F6F4D8")
                Else
                    e.Row.BackColor = Drawing.Color.FromName("#F6F6F6")
                End If
            End If

        End If
        'DEDDC5
        'DEDEDE

    End Sub


    Protected Sub grdExcel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdExcel.SelectedIndexChanged

        Dim row As GridViewRow = grdExcel.SelectedRow
        Dim excelID As String = row.Cells(0).Text
        Dim isAktif As Integer = CInt(row.Cells(1).Text)
        Dim isStarted As Integer = CInt(row.Cells(2).Text)
        If isAktif = 1 And isStarted = 1 Then   'aktif paket - pasife alınacak

            lblPasifeAlinacakProje.Text = cmbProjeSecim.SelectedItem.Text
            lblPasifeAlinacakPaket.Text = row.Cells(3).Text
            lblExcelID.Text = excelID
            mpeDataPaketiPasifYap.Show()


        End If

        If isAktif = 1 And isStarted = 0 Then       'yeni eklenmiş paket, havuza data transferi yapılacak

            lblHavuzaAlinacakProje.Text = cmbProjeSecim.SelectedItem.Text
            lblHavuzaAlinacakPaket.Text = row.Cells(3).Text
            lblExcelIDH.Text = excelID
            mpeDataPaketHavuza.Show()


        End If

        If isAktif = 0 And isStarted = 1 Then       'paket bir süre çalıştıktan sonra pasife alınmış, havuzda datası var, sadece statusü aktif'e çekilecek
            lblAktifeAlinacakProje.Text = cmbProjeSecim.SelectedItem.Text
            lblAktifeAlinacakPaket.Text = row.Cells(3).Text
            lblExcelIDA.Text = excelID
            mpeDataPaketiAktifYap.Show()


        End If

    End Sub


    Sub controlAndUpdateDataForBlackList(ByVal excelID As Integer)
        'bir data paketteki black listleri kontrol eder isInBlack fieldini 1 yapar - daha sonra yapılacak havuz aktarımında buna göre yapacak


        Dim datas As New datas
        Dim dt As Data.DataTable
        Dim dr As Data.DataRow
        Dim tel1, tel2, tel3 As String
        Dim isInBlack As Boolean = False
        dt = datas.getDataByPaketForBlackKontrol(excelID)
        For Each dr In dt.Rows

            If dr("tel1").ToString.Length > 20 Then tel1 = datas.sifreCoz(dr("tel1")) Else tel1 = dr("tel1").ToString
            If dr("tel2").ToString.Length > 20 Then tel2 = datas.sifreCoz(dr("tel2")) Else tel2 = dr("tel2").ToString
            If dr("tel3").ToString.Length > 20 Then tel3 = datas.sifreCoz(dr("tel3")) Else tel3 = dr("tel3").ToString

            
            If tel1.Length > 5 Then isInBlack = datas.isInBlackList(Session("firmID"), tel1)
            If tel2.Length > 5 Then isInBlack = isInBlack Or datas.isInBlackList(Session("firmID"), tel2)
            If tel3.Length > 5 Then isInBlack = isInBlack Or datas.isInBlackList(Session("firmID"), tel3)
            If isInBlack Then
                datas.setDataAsBlack(dr("dataID"))

            End If
        Next

    End Sub

    Protected Sub btnDPCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDPCancel.Click
        mpeDataPaketiPasifYap.Hide()

    End Sub

    Protected Sub btnDataPaketIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataPaketIptal.Click
        mpeDataPaketiPasifYap.Hide()
    End Sub

    Protected Sub btnDataPaketPasifeAL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataPaketPasifeAL.Click
        Dim excelID As Integer = CInt(lblExcelID.Text)
        Dim projeID As Integer = CInt(cmbProjeSecim.SelectedValue)
        Dim datas As New datas
        datas.paketAktifPasifChangeByProje(excelID, projeID, 0)
        ProjeAnaBilgileriGuncelle()
        populateOzetByExcel(projeID)
        mpeDataPaketiPasifYap.Hide()

    End Sub

    Protected Sub btnAktifCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAktifCancel.Click
        mpeDataPaketiAktifYap.Hide()
    End Sub


    Protected Sub btnDataPaketActivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataPaketActivate.Click
        Dim excelID As Integer = CInt(lblExcelIDA.Text)
        Dim projeID As Integer = CInt(cmbProjeSecim.SelectedValue)
        Dim datas As New datas
        datas.paketAktifPasifChangeByProje(excelID, projeID, 1)

        ProjeAnaBilgileriGuncelle()

        populateOzetByExcel(projeID)
        mpeDataPaketiAktifYap.Hide()
    End Sub

    Protected Sub btnHavuzCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnHavuzCancel.Click
        mpeDataPaketHavuza.Hide()
    End Sub

    Protected Sub btnHavuzIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHavuzIptal.Click
        mpeDataPaketHavuza.Hide()
    End Sub


    Protected Sub btnDataPaketHavuza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataPaketHavuza.Click
        Dim excelID As Integer = CInt(lblExcelIDH.Text)
        Dim projeID As Integer = CInt(cmbProjeSecim.SelectedValue)
        Dim datas As New datas

        controlAndUpdateDataForBlackList(CInt(excelID))
        datas.transferDataToHavuzForThisProject(projeID, excelID)
        ProjeAnaBilgileriGuncelle()

        populateOzetByExcel(projeID)
        mpeDataPaketHavuza.Hide()

    End Sub


    Protected Sub btnDataPaketEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDataPaketEkle.Click
        'Session("firmID") = 1 'TODO -- sil
        Dim firmID As Integer = Session("firmID")
        ' ascxDataPaket.selectDataPaket(Session("firmID"))

        Dim datas As New datas
        Dim dt As New Data.DataTable
        dt = datas.getActiveDataPaketHavuzHaric(firmID, cmbProjeSecim.SelectedValue)


        grdDataPaket.Columns(0).Visible = True
        grdDataPaket.Columns(5).Visible = True
        grdDataPaket.DataSource = dt
        grdDataPaket.DataBind()

        grdDataPaket.Columns(0).Visible = False
        grdDataPaket.Columns(5).Visible = False

        mpeDataPaket.Show()
    End Sub

    Protected Sub btnCancelDP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelDP.Click
        mpeDataPaket.Hide()

    End Sub

    Protected Sub btnDataIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataIptal.Click
        mpeDataPaket.Hide()

    End Sub

    Protected Sub btnDataSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataSec.Click

        '   Burda direk kayıt yapacak, seçme olayı değil aslında yani
        '   data paket ve proje ara tablosuna yazar (araDataPaketProje yani)    
        '   yani projeye data paket ekleme olayı 
        '   IDs data taype kullancaz burda
        '
        Dim i As Integer
        Dim chked As Boolean
        Dim excelID As Integer
        Dim isAnySelected As Boolean = False
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        Dim dtt0 As Data.DataColumn = New Data.DataColumn("userID", System.Type.GetType("System.Int32"))
        dt.Columns.Add(dtt0)


        For i = 0 To grdDataPaket.Rows.Count - 1
            chked = CType(grdDataPaket.Rows(i).Cells(4).Controls(1), CheckBox).Checked
            If chked Then
                isAnySelected = True
                excelID = CInt(grdDataPaket.Rows(i).Cells(0).Text)
                dr = dt.NewRow
                dr(0) = excelID

                dt.Rows.Add(dr)
            End If
        Next
        If isAnySelected Then
            Dim datas As New datas
            datas.addDataPaketToProje(dt, cmbProjeSecim.SelectedValue)
            populateOzetByExcel(cmbProjeSecim.SelectedValue)

        End If
        mpeDataPaket.Hide()
    End Sub

    Protected Sub tabProjeOzet_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabProjeOzet.ActiveTabChanged
        Try
            If tabProjeOzet.ActiveTabIndex = 0 Then
                populateOzetByExcel(cmbProjeSecim.SelectedValue)
            End If
            If tabProjeOzet.ActiveTabIndex = 1 Then
                populateAgents(cmbProjeSecim.SelectedValue)
            End If
            If tabProjeOzet.ActiveTabIndex = 2 Then
                ' populateSatisPaket(cmbProjeSecim.SelectedValue)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Sub populateAgents(ByVal projeID As Integer)
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

    End Sub

    Protected Sub grdAgents_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAgents.RowCommand

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        Dim row As GridViewRow = grdAgents.Rows(index)

        Dim agentID As Integer = CInt(row.Cells(0).Text)
        Dim isHome As Integer = CInt(row.Cells(1).Text)
        Dim numOfProje As Integer = CInt(row.Cells(2).Text)
        Dim roleID As Integer = CInt(row.Cells(4).Text)
        Dim isAktif As Integer = CInt(row.Cells(3).Text)
        Dim islem As String
        If e.CommandName = "btnFieldRolDegis" Then
            lblProjeRolDegis.Text = cmbProjeSecim.SelectedItem.Text
            lblAgentRolDegis.Text = row.Cells(8).Text
            cmbRoleSecim.SelectedIndex = roleID - 1
            ViewState("agentID") = agentID

            mpeRoleDegis.Show()

        End If



        If e.CommandName = "btnFieldAgentCikarEkle" Then
            If isAktif = 1 Then
                islem = "Agent'in Projeden Çıkarılması"
                ViewState("isAktif") = 0    'aktif ise pasif yap
            Else
                islem = "Agent'in tekrar projeye eklenmesi"
                ViewState("isAktif") = 1    'pasif se aktif yapılacak
            End If

            lblAgentEkleCikarProje.Text = cmbProjeSecim.SelectedItem.Text
            lblAgentEkleCikarAd.Text = row.Cells(8).Text
            lblAgentEkleCikarIslem.Text = islem
            ViewState("agentID") = agentID


            mpeAgentEkleCikarGrid.Show()

        End If





    End Sub

    Protected Sub grdAgents_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgents.RowDataBound
        'getProjeDataOzetByAgent
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim agentID As Integer = CInt(e.Row.Cells(0).Text)
            Dim isHome As Integer = CInt(e.Row.Cells(1).Text)
            Dim numOfProje As Integer = CInt(e.Row.Cells(2).Text)
            Dim roleID As Integer = CInt(e.Row.Cells(4).Text)
            Dim isAktif As Integer = CInt(e.Row.Cells(3).Text)

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

            ' ''Dim cntSold As Integer = 0              'islem=1 => 
            ' ''Dim cntNotSold As Integer = 0           'islem=2
            ' ''Dim cntUlasilamadi As Integer = 0       'islem=3 =>     
            ' ''Dim cntRandevu As Integer = 0           'islem=4 =>     
            ' ''Dim cntSoldCommitted As Integer = 0     'islem=5 => 
            ' ''Dim cntYanlis As Integer = 0            'islem=6 => 
            ' ''Dim cntDataEksik As Integer = 0           'islem=7
            ' ''Dim cntBlackList As Integer = 0         'islem=99 => 
            ' ''Dim cntBugunArama As Integer = 0
            ' ''Dim cntBugunSatis As Integer = 0
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


    Protected Sub btnRoleDegisIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRoleDegisIptal.Click
        mpeRoleDegis.Hide()

    End Sub

    Protected Sub btnRoleDegisKapat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRoleDegisKapat.Click
        mpeRoleDegis.Hide()
    End Sub


    Protected Sub btnAgentEkelCikarPopupIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentEkelCikarPopupIptal.Click
        mpeAgentEkleCikarGrid.Hide()

    End Sub

    Protected Sub btnAgentEkleCikarPopupKapat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgentEkleCikarPopupKapat.Click
        mpeAgentEkleCikarGrid.Hide()

    End Sub

    Protected Sub btnRoleDegisKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRoleDegisKaydet.Click
        pr.setAgentRoleInProje(cmbProjeSecim.SelectedValue, cmbRoleSecim.SelectedValue, ViewState("agentID"))

        mpeRoleDegis.Hide()
        populateAgents(cmbProjeSecim.SelectedValue)
    End Sub

    Protected Sub btnAgentEkelCikarPopupKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentEkelCikarPopupKaydet.Click
        pr.setAgentActivationInProje(cmbProjeSecim.SelectedValue, ViewState("agentID"), ViewState("isAktif"))
        mpeAgentEkleCikarGrid.Hide()
        populateAgents(cmbProjeSecim.SelectedValue)

    End Sub

    Protected Sub btnAgentSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentSec.Click
        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("agentID")
        dt.Columns.Add("roleID")

        Dim i As Integer
        Dim chked As Boolean

        Dim roleID As Integer

        With grdAgentForProje

            For i = 0 To .Rows.Count - 1

                chked = CType(.Rows(i).Cells(5).Controls(1), CheckBox).Checked

                If chked Then
                    roleID = CType(.Rows(i).Cells(7).Controls(1), DropDownList).SelectedValue


                    dr = dt.NewRow
                    dr("agentID") = .Rows(i).Cells(0).Text
                    dr("roleID") = roleID

                    dt.Rows.Add(dr)
                End If

            Next

        End With

        Dim pr As New proje
        pr.projeyeEkipEkle(dt, cmbProjeSecim.SelectedValue)
        populateAgents(cmbProjeSecim.SelectedValue)
        mpeAgnt.Hide()

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        mpeAgnt.Hide()
    End Sub

    Protected Sub btnAgentIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentIptal.Click
        mpeAgnt.Hide()

    End Sub

    Protected Sub btnAgentEkle_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgentEkle.Click
        'ascxAgentEkle.selectAgents(Session("firmID"))

        Dim agnt As New agents
        Dim dt As New Data.DataTable



        dt = agnt.getActiveAgentsNotInProject(Session("firmID"), cmbProjeSecim.SelectedValue)

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

    Protected Sub grdAgentForProje_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAgentForProje.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim isHome As Integer = CInt(e.Row.Cells(3).Text)
            If isHome = 1 Then
                Dim img As New Image
                img.ImageUrl = "..\images\home.png"
                img.AlternateText = "Home Agnt"
                img.ToolTip = "Home Agent"
                e.Row.Cells(4).Controls.Add(img)

            End If


            Dim numOfProje As Integer = CInt(e.Row.Cells(6).Text)   'agent üzerine tanımlı proje sayısı - 0 olanları öne getirip color'unu green yapar

            If numOfProje = 0 Then
                e.Row.BackColor = Drawing.Color.FromName("#eeffcc")
            End If

        End If

    End Sub

    Protected Sub timerProjeIzle_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerProjeIzle.Tick
        ProjeAnaBilgileriGuncelle()
        If tabProjeOzet.ActiveTabIndex = 0 Then
            populateOzetByExcel(cmbProjeSecim.SelectedValue)

        End If

        If tabProjeOzet.ActiveTabIndex = 1 Then
            populateAgents(cmbProjeSecim.SelectedValue)
        End If

    End Sub

    Protected Sub btnPaketDetayCancel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnPaketDetayCancel.Click
        mpePaketDetay.Hide()

    End Sub



    Protected Sub btnPaketDetayTamam_Click(sender As Object, e As System.EventArgs) Handles btnPaketDetayTamam.Click
        mpePaketDetay.Hide()

    End Sub

    Protected Sub btnActivateUlasilamayan_Click(sender As Object, e As System.EventArgs) Handles btnActivateUlasilamayan.Click
        Dim adm As New admin
        adm.updateComplatedUlasilamayanlarTekrarGelsinByPaket(CInt(lblExcelIDForPAketDetayPopup.Text), cmbProjeSecim.SelectedValue)
        mpePaketDetay.Hide()
    End Sub

    Protected Sub btnDeActivateUlasilamayan_Click(sender As Object, e As System.EventArgs) Handles btnDeActivateUlasilamayan.Click
        Dim adm As New admin
        adm.updateUlasilamayanlarAsComplatedByPaket(CInt(lblExcelIDForPAketDetayPopup.Text), cmbProjeSecim.SelectedValue)
        mpePaketDetay.Hide()
    End Sub

    Protected Sub btnAktifIptal_Click(sender As Object, e As System.EventArgs) Handles btnAktifIptal.Click
        mpeDataPaketiAktifYap.Hide()
    End Sub
End Class
