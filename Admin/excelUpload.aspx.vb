Imports System.IO
Imports System.Data.OleDb
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient


Partial Class Admin_excelUpload
    Inherits System.Web.UI.Page


    Dim gnl As New genel
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString



    Sub uploadAndAnalizeData()
        Dim strFileType As String
        'Dim strFileTypeSAP As String
        Dim dt As Data.DataTable


        If upFile.HasFile Then

            strFileType = Path.GetExtension(upFile.FileName).ToLower

            Dim ek1 As String = Format(Date.Today, "ddMMyyyy")
            ek1 = ek1 + "_" + Format(DateAdd(DateInterval.Hour, 3, Date.UtcNow), "HHmmss")

            Dim fl As String = "~/Admin/Uploads/" + Path.GetFileNameWithoutExtension(upFile.FileName) + ek1 + Path.GetExtension(upFile.FileName)
            lblstrFileType.Text = strFileType
            lblFL.Text = fl

            Try
                upFile.SaveAs(Server.MapPath(fl))

            Catch ex As Exception
                lblUpload.Text = "Hata: " + Err.Description
                Exit Sub
            End Try


            If (strFileType = ".xlsx" Or strFileType = ".xls") Then

                dt = fillExcelToDT(True, strFileType, fl)


                Dim numberOfRows As Integer = dt.Rows.Count
                Dim i As Integer = 0

                'column sayısına göre comboyu populate et
                radioDefinedField.Visible = True
                radioUndefField.Visible = True
                radioExcludeField.Visible = True
                cmbColumns.Visible = True
                btnColHeaderEkle.Visible = True
                cmbColumns.Items.Clear()

                For i = 1 To dt.Columns.Count
                    Dim lstItem As New ListItem
                    lstItem.Text = "sütun " + i.ToString
                    lstItem.Value = i
                    cmbColumns.Items.Add(lstItem)
                Next


                grdKayitlar.DataSource = dt
                grdKayitlar.DataBind()


                For i = 0 To cmbColumns.Items.Count - 1
                    grdKayitlar.HeaderRow.Cells(i).Text = "???"

                Next

                grdKayitlar.HeaderRow.Cells(0).BackColor = Drawing.Color.Blue

                'ds.Dispose()
                'conn.Close()

            End If
        End If
    End Sub

    Function fillExcelToDT(ByVal isSample As Boolean, ByVal strFileType As String, ByVal fl As String) As DataTable
        Dim connStr As String
        Dim conn As OleDbConnection
        Dim sql As String
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter



        Dim isHeader As String = "No"

        If chkHeaderExist.Checked Then isHeader = "Yes"
        connStr = ""
        If strFileType.Trim = ".xls" Then
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath(fl) & ";Extended Properties=""Excel 8.0;HDR=" + isHeader + ";IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath(fl) & ";Extended Properties=""Excel 12.0;HDR=" + isHeader + ";IMEX=2"""
        End If


        ' sql = "SELECT * FROM [Sheet1$]"
        conn = New OleDbConnection(connStr)
        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim sheetName As String = conn.GetSchema("Tables").Rows(0)("TABLE_NAME")
        If isSample Then
            sql = "SELECT top 20 * FROM [" + sheetName + "]"

        Else
            sql = "SELECT * FROM [" + sheetName + "]"

        End If



        Dim ds As Data.DataSet
        cmd = New OleDbCommand(sql, conn)
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)


        da.Dispose()
        conn.Close()
        conn.Dispose()


        Return ds.Tables(0)
    End Function

    Protected Sub btnAnalize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnalize.Click
        uploadAndAnalizeData()

    End Sub

    Protected Sub btnKaydet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKaydet.Click
        ' Dim dataExcelID As Integer

        If txtPaketAdi.Text.Trim.Length < 2 Then
            txtPaketAdi.Style.Add(HtmlTextWriterStyle.BorderColor, "#ec1c1c")
            txtPaketAdi.Style.Add(HtmlTextWriterStyle.BorderWidth, "2px")
            Exit Sub
        End If


        Dim datas As New datas
        If isColumnsValid() Then
            Dim dt As Data.DataTable = getUndefinedFields()
            Dim head() As String
            ReDim head(6)
            For i = 0 To 5
                head(i) = ""
            Next
            For i = 0 To dt.Rows.Count - 1
                head(i) = dt.Rows(i).Item(0)
            Next

            Dim isOk As Boolean
            isOk = insertPaketRecord(Session("firmID"), Session("agentID"), txtPaketAdi.Text.Trim, txtAciklama.Text.Trim, upFile.FileName, _
                                                  head(0), head(1), head(2), head(3), head(4), head(5), txtTelHeaderEk.Text.Trim)


            '  insertDatas(dataExcelID)



        Else
            ascxUyari.uyar("Tüm data alanları tanımlanmamış!", "#333333", "")
        End If


        'If isValid then 
    End Sub



    Protected Sub radioDefinedField_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioDefinedField.CheckedChanged
        If radioDefinedField.Checked Then
            cmbDefFields.Visible = True
            txtUnDefField.Visible = False
        End If
    End Sub

    Protected Sub radioUndefField_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioUndefField.CheckedChanged
        If radioUndefField.Checked Then
            cmbDefFields.Visible = False
            txtUnDefField.Visible = True
        End If

    End Sub

    Protected Sub radioExcludeField_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioExcludeField.CheckedChanged
        If radioExcludeField.Checked Then
            cmbDefFields.Visible = False
            txtUnDefField.Visible = False
        End If

    End Sub

    Protected Sub cmbColumns_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColumns.SelectedIndexChanged
        Dim s As Integer = cmbColumns.SelectedValue - 1

        With grdKayitlar.HeaderRow



            For i = 0 To cmbColumns.Items.Count - 1
                'grdKayitlar.HeaderRow.Cells(s).Text = "???"
                If .Cells(i).BackColor = Drawing.Color.Blue Then
                    .Cells(i).BackColor = Drawing.Color.FromName("#dddddd")
                    .Cells(i).ForeColor = Drawing.Color.FromName("#222222")
                End If
            Next
            .Cells(s).Text = "???"
            .Cells(s).BackColor = Drawing.Color.Blue
            .Cells(s).ForeColor = Drawing.Color.White

        End With
    End Sub

    Protected Sub btnColHeaderEkle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColHeaderEkle.Click

        Dim s As Integer = cmbColumns.SelectedValue - 1

        If radioDefinedField.Checked Then
            If isThisFieldExist(cmbDefFields.SelectedValue) Then
                ascxUyari.uyar("Bu Alan Kullanılmış!", "#333333", "")
            Else
                grdKayitlar.HeaderRow.Cells(s).Text = cmbDefFields.SelectedValue
                grdKayitlar.HeaderRow.Cells(s).BackColor = Drawing.Color.LightGreen
                grdKayitlar.HeaderRow.Cells(s).ForeColor = Drawing.Color.FromName("#222222")
            End If

        End If

        If radioUndefField.Checked Then
            If isThisFieldExist(txtUnDefField.Text.Trim) Then
                ascxUyari.uyar("Bu Alan Kullanılmış!", "#333333", "")
            Else
                grdKayitlar.HeaderRow.Cells(s).Text = txtUnDefField.Text.Trim
                grdKayitlar.HeaderRow.Cells(s).BackColor = Drawing.Color.Plum   'Drawing.Color.FromName("#FF99FF")
                grdKayitlar.HeaderRow.Cells(s).ForeColor = Drawing.Color.FromName("#222222")

            End If

        End If

        If radioExcludeField.Checked Then
            grdKayitlar.HeaderRow.Cells(s).Text = "xxx"
            grdKayitlar.HeaderRow.Cells(s).BackColor = Drawing.Color.Red
            For i = 0 To grdKayitlar.Rows.Count - 1
                grdKayitlar.Rows(i).Cells(s).BackColor = Drawing.Color.FromName("#dddddd")
            Next


        End If




    End Sub

    Function isColumnsValid() As Boolean


        Dim numOfCol As Integer = cmbColumns.Items.Count
        Dim isValid As Boolean = True

        'aynı column ismi birden fazla tanımlandı ise!!!
        For i = 0 To numOfCol - 1
            'grdKayitlar.HeaderRow.Cells(s).Text = "???"
            If grdKayitlar.HeaderRow.Cells(i).Text = "???" Then isValid = False
            For j = 0 To numOfCol - 1
                If i <> j Then
                    isValid = Not (grdKayitlar.HeaderRow.Cells(i).Text = grdKayitlar.HeaderRow.Cells(j).Text)
                End If
            Next
        Next
        Return isValid

    End Function

    Function isThisFieldExist(ByVal headerText As String) As Boolean


        Dim numOfCol As Integer = cmbColumns.Items.Count
        Dim isExist As Boolean = False

        'bu text birden fazla tanımlandı ise!!!
        For i = 0 To numOfCol - 1

            If headerText = grdKayitlar.HeaderRow.Cells(i).Text Then isExist = True
        Next

        Return isExist

    End Function

    Function getUndefinedFields() As Data.DataTable
        Dim dt As New Data.DataTable
        Dim i As Integer

        Dim dr As Data.DataRow
        dt.Columns.Add("unDefField")

        Dim numOfCol As Integer = grdKayitlar.HeaderRow.Cells.Count  'grdKayitlar.Columns.Count

        For i = 0 To numOfCol - 1

            If grdKayitlar.HeaderRow.Cells(i).BackColor = Drawing.Color.Plum Then    'undef field
                dr = dt.NewRow
                dr("unDefField") = grdKayitlar.HeaderRow.Cells(i).Text
                dt.Rows.Add(dr)

            End If
        Next

        Return dt
    End Function

    Function getDefinedFields() As String
        Dim i As Integer
        Dim str As String = ""

        Dim numOfCol As Integer = grdKayitlar.HeaderRow.Cells.Count

        For i = 0 To numOfCol - 1

            If grdKayitlar.HeaderRow.Cells(i).BackColor = Drawing.Color.LightGreen Then    'undef field
                str = str + "," + grdKayitlar.HeaderRow.Cells(i).Text

            End If
        Next
        ' str = Mid(str, 2)

        Return str
    End Function


    ' ''Sub insertDatas(ByVal dataExcelID As Integer)
    ' ''    Dim numOfCol As Integer = grdKayitlar.HeaderRow.Cells.Count

    ' ''    Dim sql As String = "insert into tbMain.data (dataExcelID"
    ' ''    sql = sql + getDefinedFields() + ") values (" + dataExcelID.ToString

    ' ''    Dim sql2 As String = ""
    ' ''    Dim sqlSon As String

    ' ''    For i = 0 To grdKayitlar.Rows.Count - 1
    ' ''        '******* Defiend fieldler için data insert
    ' ''        sql2 = ""
    ' ''        For k = 0 To numOfCol - 1

    ' ''            If grdKayitlar.HeaderRow.Cells(k).BackColor = Drawing.Color.LightGreen Then
    ' ''                sql2 = sql2 + "','" + grdKayitlar.Rows(i).Cells(k).Text

    ' ''            End If
    ' ''        Next


    ' ''        sql2 = Mid(sql2, 3) + "'"
    ' ''        sqlSon = sql + sql2 + ")"

    ' ''    Next

    ' ''End Sub



    Function insertPaketRecord(ByVal firmId As Integer, ByVal adminID As Integer, ByVal paketAdi As String, ByVal aciklama As String, ByVal dosyaAdi As String, _
                           ByVal h1 As String, ByVal h2 As String, ByVal h3 As String, ByVal h4 As String, ByVal h5 As String, ByVal h6 As String, ByVal tel1Head As String) As Boolean


        '  Dim dt As Data.DataTable = getUndefinedFields
        Dim dataID As Integer
        Dim isUndefExist As Boolean = False
        Dim isSccss As Boolean
        Dim sqlUD, sqlUD2 As String
        Dim dataCnt As Integer = 0  'insert edilen data sayısı
        Dim dataNot As Integer = 0  'insert edilemeyen data sayısı
        Dim blackCnt As Integer = 0  'black listteki data
        Dim conn As New SqlConnection(connStr)
        Dim datas As New datas
        Dim inBlackList As Boolean
        Dim isMukerrer As Boolean
        conn.Open()

        Dim trn As SqlTransaction
        trn = conn.BeginTransaction()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.Transaction = trn
        cmd.CommandTimeout = 400

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.uploadDataPackage"


        cmd.Parameters.AddWithValue("@firmID", firmId)
        cmd.Parameters.AddWithValue("@adminID", adminID)
        cmd.Parameters.AddWithValue("@paketAdi", paketAdi)
        cmd.Parameters.AddWithValue("@aciklama", aciklama)
        cmd.Parameters.AddWithValue("@dosyaAdi", dosyaAdi)
        cmd.Parameters.AddWithValue("@head1", h1)
        cmd.Parameters.AddWithValue("@head2", h2)
        cmd.Parameters.AddWithValue("@head3", h3)
        cmd.Parameters.AddWithValue("@head4", h4)
        cmd.Parameters.AddWithValue("@head5", h5)
        cmd.Parameters.AddWithValue("@head6", h6)
        cmd.Parameters.AddWithValue("@tel1Head", tel1Head)
        cmd.Parameters.Add("@retVal", Data.SqlDbType.Int).Direction = Data.ParameterDirection.ReturnValue

        Try
            cmd.ExecuteNonQuery()   'ana tablo
            Dim dataExcelID As Integer = CInt(cmd.Parameters("@retVal").Value.ToString())


            '******************************************************************************************
            '************ Dataların insert işlemi *****************************************************

            Dim numOfCol As Integer = grdKayitlar.HeaderRow.Cells.Count

            Dim sql As String = "insert into tbMain.data (dataExcelID"
            sql = sql + getDefinedFields() + ") values (" + dataExcelID.ToString

            Dim sql2 As String = ""
            sqlUD2 = ""
            Dim sqlSon As String
            Dim numOfUndef As Integer = 0
            Dim strTmp As String = ""

            'undef alan var mı yok mu olayı varsa undef sql'in bir kısmını oluştur..
            For k = 0 To numOfCol - 1
                If grdKayitlar.HeaderRow.Cells(k).BackColor = Drawing.Color.Plum Then
                    isUndefExist = True
                    numOfUndef += 1
                    strTmp = strTmp + ",f" + numOfUndef.ToString
                End If
            Next
            strTmp = Mid(strTmp, 2)

            '------------------------------------------------------------------
            Dim tmpVal As String = ""
            Dim RijNDaelSimple As New RijNDaelSimple

            Dim dr As Data.DataRow
            Dim dt As Data.DataTable = fillExcelToDT(False, lblstrFileType.Text, lblFL.Text)
            blackCnt = 0
            Dim mukerrerCnt As Integer = 0
            For Each dr In dt.Rows

                'For i = 0 To grdKayitlar.Rows.Count - 1        'grid yerine dataTable'den okumaya karar verdiğimden bu iptal oldu
                '******* Defiend fieldler için data insert
                sql2 = ""
                numOfUndef = 0
                sqlUD2 = ""
                inBlackList = False
                isMukerrer = False

                '*********** Black List kontrolü - Eğer Black listte ise direk looptan çık
                ''For k = 0 To numOfCol - 1
                ''    If (grdKayitlar.HeaderRow.Cells(k).Text = "tel1" Or grdKayitlar.HeaderRow.Cells(k).Text = "tel2" Or grdKayitlar.HeaderRow.Cells(k).Text = "tel3") _
                ''                And dr(k).ToString.Trim.Length > 4 Then
                ''        inBlackList = datas.isInBlackList(Session("firmID"), dr(k).ToString.Trim)

                ''    End If
                ''Next

                '----------------------------------------------------------------

                Try
                    Dim tmpTel As String = ""
                    For k = 0 To numOfCol - 1
                        tmpTel = ""
                        tmpVal = ""
                        If grdKayitlar.HeaderRow.Cells(k).BackColor = Drawing.Color.LightGreen Then
                            'sql2 = sql2 + "','" + grdKayitlar.Rows(i).Cells(k).Text.Trim.Replace("&nbsp;", "")
                            If (grdKayitlar.HeaderRow.Cells(k).Text = "tel1" Or grdKayitlar.HeaderRow.Cells(k).Text = "tel2" Or grdKayitlar.HeaderRow.Cells(k).Text = "tel3") _
                                And dr(k).ToString.Trim.Length > 4 Then

                                tmpTel = dr(k).ToString.Trim.Replace("&nbsp;", "").Replace(" ", "").Replace("-", "").Replace(".", "")

                                tmpVal = datas.sifrele(tmpTel)
                                inBlackList = inBlackList Or datas.isInBlackList(Session("firmID"), tmpTel)

                                '**** mükerrer kayıt kontrolü - sadece tel1 için yapılacak
                                If grdKayitlar.HeaderRow.Cells(k).Text = "tel1" Then
                                    isMukerrer = datas.isThisTelMukerrerInThisPaket(tmpVal, dataExcelID)
                                End If
                                '*********************************************************

                            ElseIf grdKayitlar.HeaderRow.Cells(k).Text = "terminTarih" Then 'yenileme projeleri için termin tarihi update'i defined fieldlere ekleniyo
                                tmpVal = "DATEADD(year, 1, CONVERT(SMALLDATETIME,'" + dr(k).ToString.Trim.Replace("'", "-") + "',103))"

                            Else

                                tmpVal = dr(k).ToString.Trim.Replace("&nbsp;", "").Replace("'", "-")
                            End If
                            sql2 = sql2 + "','" + tmpVal

                        End If
                        If grdKayitlar.HeaderRow.Cells(k).BackColor = Drawing.Color.Plum Then
                            '                        sqlUD2 = sqlUD2 + "','" + grdKayitlar.Rows(i).Cells(k).Text.Trim.Replace("&nbsp;", "")
                            sqlUD2 = sqlUD2 + "','" + dr(k).ToString.Trim.Replace("&nbsp;", "").Replace("'", "-")

                        End If

                    Next



                    sql2 = Mid(sql2, 2) + "'"   'virgül alınacak
                    sql2 = sql2.Replace("'DATEADD", "DATEADD")
                    sql2 = sql2.Replace(",103))'", ",103))")
                    'türkçe karakter kod değişimi - güvenlik hatasına sebep olan - 13.04.2011
                    '  ç | &#231; || Ç | &#199; 
                    '| ı | &#305; || İ | &#304; 
                    '| ğ | &#287; || Ğ | &#286; 
                    '| ö | &#246; || Ö | &#214;
                    '| ş | &#351; || Ş | &#350; 
                    '| ü | &#252; || Ü | &#220; 
                    sql2 = sql2.Replace("&#231;", "ç").Replace("&#305;", "ı").Replace("&#287;", "ğ").Replace("&#246;", "ö").Replace("&#351;", "ş").Replace("&#252;", "ü")
                    sql2 = sql2.Replace("&#199;", "Ç").Replace("&#304;", "İ").Replace("&#286;", "Ğ").Replace("&#214;", "Ö").Replace("&#350;", "Ş").Replace("&#220;", "Ü")
                    '-------------------------------
                    sqlSon = sql + sql2 + ") select scope_identity()"
                    If Not inBlackList Then

                        If Not isMukerrer Then

                        
                        cmd.CommandType = Data.CommandType.Text
                        cmd.CommandText = sqlSon
                        dataID = Integer.Parse(cmd.ExecuteScalar().ToString())
                        dataCnt += 1

                        '******* UnDefiend fieldler için data insert (varsa tabii)
                        If isUndefExist Then

                            sqlUD2 = Mid(sqlUD2, 3) + "'" 'sql'in data kısmı

                            'türkçe karakter kodu geldi ise
                            sqlUD2 = sqlUD2.Replace("&#231;", "ç").Replace("&#305;", "ı").Replace("&#287;", "ğ").Replace("&#246;", "ö").Replace("&#351;", "ş").Replace("&#252;", "ü")
                            sqlUD2 = sqlUD2.Replace("&#199;", "Ç").Replace("&#304;", "İ").Replace("&#286;", "Ğ").Replace("&#214;", "Ö").Replace("&#350;", "Ş").Replace("&#220;", "Ü")
                            '-------------------------------

                            sqlUD = "insert into tbMain.dataUndefinedFields (dataID," + strTmp + ") values (" + dataID.ToString + "," + sqlUD2 + ")"
                            cmd.CommandType = Data.CommandType.Text
                            cmd.CommandText = sqlUD
                            cmd.ExecuteNonQuery()

                            End If

                        Else
                            mukerrerCnt += 1
                        End If

                    Else
                        blackCnt += 1
                    End If 'black list

                Catch ex As Exception
                    dataNot += 1
                End Try



            Next

            trn.Commit()
            isSccss = True
            alanlariTemizle()

            '   Dim mukerrerKayit As Integer = datas.updateMukerrerForThisDataPaket(dataExcelID)




            ascxUyari.uyar("Kaydedilen data : " + dataCnt.ToString + "<br />Kaydedilemeyen data: " + dataNot.ToString + "<br />Black List data: " + blackCnt.ToString + "<br />Mükerrer data: " + mukerrerCnt.ToString, "", "~/images/ok.png")

        Catch ex As Exception
            trn.Rollback()
            isSccss = False
            ascxUyari.uyar("Data paketi aktarılamadı! <br/> Paket ismi, açıklaması ve data alanlarının doğru tanımlandığından emin olunuz.", "", "")


        End Try


        conn.Close()
        cmd.Dispose()
        Return isSccss

    End Function



    Sub alanlariTemizle()
        txtAciklama.Text = ""
        txtPaketAdi.Text = ""
        grdKayitlar.DataSource = Nothing
        grdKayitlar.DataBind()
        txtUnDefField.Text = ""
        radioDefinedField.Checked = False
        radioExcludeField.Checked = False
        radioUndefField.Checked = False

    End Sub

End Class
