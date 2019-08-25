Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient
Public Class datas
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString
    Dim gnl As New genel

    Function getActiveDataPaket(ByVal firmID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getActiveDataPaket"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function

    Function getActiveDataPaketHavuzHaric(ByVal firmID As Integer, ByVal projeID As Integer) As Data.DataTable
        'projeye henüz eklenmemiş paketleri listeler -- paket ekle popup da zaten eklenmişler gelmemesi için
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getActiveDataPaketHavuzHaric"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function

    Function getActiveDataPaketByProje(ByVal firmID As Integer, ByVal projeID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getActiveDataPaketByProje"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function



    Sub paketAktifPasifChangeByProje(ByVal excelID As Integer, ByVal projeId As Integer, ByVal durum As Integer)

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "updateSP.paketAktifPasifChange"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@excelID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = excelID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeId
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@durum"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = durum
        cmd.Parameters.Add(myParameter)


        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()


    End Sub

    Function isInBlackList(ByVal firmID As Integer, ByVal sTel As String) As Boolean
        Dim ret As Boolean

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)

        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.isInBlackList"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@telNo"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.VarChar
        myParameter.Value = sTel
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)
        If dt.Rows.Count > 0 Then ret = True Else ret = False

        conn.Close()
        cmd.Dispose()



        Return ret
    End Function

    Function getDataByPaketForBlackKontrol(ByVal excelID As Integer) As Data.DataTable
        'datanın havuza transferi öncesinde black list kontrolü için
        '
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getDataByExcelForBlackKontrol"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@excelID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = excelID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function


    Sub setDataAsBlack(ByVal dataID As Integer)
        'black liste ekleme değil-havuza transfer sırasında dataların black kontrolü için
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "updateSP.setDataAsBlack"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@dataID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = dataID
        cmd.Parameters.Add(myParameter)


        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub


    Function sifrele(ByVal str As String) As String
        Dim cryp As String
        Dim RijNDaelSimple As New RijNDaelSimple
        cryp = RijNDaelSimple.Encrypt(str, "annvs", "slr1496", "SHA1", 1, "1234567890123456", 128)

        Return cryp
    End Function
    Function sifreCoz(ByVal cryp As String) As String
        Dim str As String
        Dim RijNDaelSimple As New RijNDaelSimple
        str = RijNDaelSimple.Decrypt(cryp, "annvs", "slr1496", "SHA1", 1, "1234567890123456", 128)

        Return str
    End Function

    Sub transferDataToHavuzForThisProject(ByVal projeID As Integer, ByVal excelID As Integer)

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.dataToHavuz"
        cmd.CommandTimeout = 600


        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@excelID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = excelID
        cmd.Parameters.Add(myParameter)


        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub

    Sub addDataPaketToProje(ByVal dt As Data.DataTable, ByVal projeID As Integer)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.addDataPaketToProje"

        cmd.Parameters.AddWithValue("@excelIdSet", dt)
        cmd.Parameters.AddWithValue("@projeID", projeID)

        cmd.ExecuteNonQuery()

        conn.Close()

    End Sub


    Function isThisTelMukerrerInThisPaket(tmpTel As String, dataExcelID As String) As Boolean
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSP.isThisTelMukerrerInThisPaket"

        cmd.Parameters.AddWithValue("@tel1", tmpTel)
        cmd.Parameters.AddWithValue("@dataExcelID", dataExcelID)

        'cmd.ExecuteNonQuery()
        Dim ret As Integer = cmd.ExecuteScalar()

        conn.Close()

        Return ret > 0

    End Function

    Function getPaketinHavuzDetaili(ByVal excelID As Integer, ByVal projeID As Integer) As Data.DataTable
        'bir data paketin adetlerini, satış durumu, satlamayanlar sayııs vs. verir
        'projeIzle ekranında grdExcel'i populate etmek için - rowDataBoundunda
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getProjeDataOzetByExcel"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@dataExcelID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = excelID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function



    Sub writeOnGorusme(ByVal projeID As Integer, ByVal havuzID As Integer, ByVal agentID As Integer, ByVal note As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.writeOnGorusme"

        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@note", note)

        cmd.ExecuteNonQuery()

        conn.Close()


    End Sub


    Function getSatisDataRapor(ByVal projeID As Integer, ByVal baslaTarih As String, ByVal bitisTarih As String) As Data.DataTable

        '-- Description:	tarih aralığında proje bazında onaylanmış satış dataları detayı
        '-- date bilgisi yyyymmdd formatında varchar olarak gönderilmeli
        Dim dt As New Data.DataTable
        '  Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getSatisDataRapor"

        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@baslaTarih", baslaTarih)
        cmd.Parameters.AddWithValue("@bitisTarih", bitisTarih)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function



    Function getSatisDataRaporByAgent(ByVal projeID As Integer, ByVal agentID As Integer, ByVal baslaTarih As String, ByVal bitisTarih As String) As Data.DataTable

        '-- Description:	tarih aralığında proje bazında onaylanmış satış dataları detayı
        '-- date bilgisi yyyymmdd formatında varchar olarak gönderilmeli
        Dim dt As New Data.DataTable
        '  Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getSatisDataRaporByAgent"

        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@baslaTarih", baslaTarih)
        cmd.Parameters.AddWithValue("@bitisTarih", bitisTarih)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function
End Class
