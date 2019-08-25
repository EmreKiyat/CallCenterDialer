Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient

Public Class kontroller
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString

    Function getSatilanList(ByVal projeID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.getSatilanList"
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

    Function getASatilanDataFromList(ByVal projeID As Integer, ByVal kontrollerID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.getASatilanDataFromList"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@kontrollerID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = kontrollerID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function

    Function getTheSatilanDataFromList(ByVal havuzID As Integer, ByVal kontrollerID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.getTheSatilanDataFromList"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@havuzID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = havuzID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@kontrollerID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = kontrollerID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function
    Function isSoldThisPaket(ByVal havuzID As Integer, ByVal paketID As Integer) As Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.isSoldThisPaket"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@havuzID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = havuzID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@paketID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = paketID
        cmd.Parameters.Add(myParameter)


        Dim dt As New Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        ' Dim adet As Integer = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return dt

    End Function



    Sub releaseDataByKontroller(ByVal havuzID As Integer)
        'kontrollerın üzerindeki datayı serbest bırakması için.. ekranını kapama ya da başka bir datayı almak için
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.updateReleaseDataByKontroller"
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()

    End Sub

    Function getNotesOnSale(ByVal havuzID As Integer) As Data.DataTable
        'satışı yapan agentin notlarını alır, satış gidip geldi ise o notları da alır-kontrollerin notları dahil
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.getNotesOnSaleFull"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@havuzID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = havuzID
        cmd.Parameters.Add(myParameter)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt


    End Function
    Sub setSatisOnayWithPaketChange(ByVal projeID As Integer, ByVal havuzID As Integer, _
                        ByVal kontrollerID As Integer, ByVal tutar As Decimal, ByVal note As String, _
                        ByVal customFieldID As Integer, ByVal f1 As String, ByVal f2 As String, ByVal f3 As String, _
                        ByVal f4 As String, ByVal f5 As String, ByVal f6 As String, ByVal f7 As String, _
                        ByVal satilanPaket As Data.DataTable, ByVal adres1 As String, ByVal adres2 As String, ByVal postaKod As String, ByVal sehir As String, ByVal teslimKisi As String, ByVal teslimTel As String)


        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.setSatisOnayWithPaketChange"
        cmd.Parameters.AddWithValue("@satilanPaket", satilanPaket)
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)

        cmd.Parameters.AddWithValue("@kontrollerID", kontrollerID)
        cmd.Parameters.AddWithValue("@tutar", tutar)
        cmd.Parameters.AddWithValue("@note", note)

        cmd.Parameters.AddWithValue("@customFieldID", customFieldID)

        cmd.Parameters.AddWithValue("@f1", f1)
        cmd.Parameters.AddWithValue("@f2", f2)
        cmd.Parameters.AddWithValue("@f3", f3)
        cmd.Parameters.AddWithValue("@f4", f4)
        cmd.Parameters.AddWithValue("@f5", f5)
        cmd.Parameters.AddWithValue("@f6", f6)
        cmd.Parameters.AddWithValue("@f7", f7)

        cmd.Parameters.AddWithValue("@adres1", adres1)
        cmd.Parameters.AddWithValue("@adres2", adres2)
        cmd.Parameters.AddWithValue("@postaKod", postaKod)
        cmd.Parameters.AddWithValue("@sehir", sehir)
        cmd.Parameters.AddWithValue("@teslimKisi", teslimKisi)
        cmd.Parameters.AddWithValue("@teslimTel", teslimTel)


        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()

    End Sub

    Sub setSatisOnay(ByVal projeID As Integer, ByVal havuzID As Integer, _
                    ByVal kontrollerID As Integer, ByVal note As String, _
                    ByVal customFieldID As Integer, ByVal f1 As String, ByVal f2 As String, ByVal f3 As String, _
                    ByVal f4 As String, ByVal f5 As String, ByVal f6 As String, ByVal f7 As String, ByVal adres1 As String, ByVal adres2 As String, ByVal postaKod As String, ByVal sehir As String, ByVal teslimKisi As String, ByVal teslimTel As String)



        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.setSatisOnay"
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)

        cmd.Parameters.AddWithValue("@kontrollerID", kontrollerID)
        cmd.Parameters.AddWithValue("@note", note)

        cmd.Parameters.AddWithValue("@customFieldID", customFieldID)

        cmd.Parameters.AddWithValue("@f1", f1)
        cmd.Parameters.AddWithValue("@f2", f2)
        cmd.Parameters.AddWithValue("@f3", f3)
        cmd.Parameters.AddWithValue("@f4", f4)
        cmd.Parameters.AddWithValue("@f5", f5)
        cmd.Parameters.AddWithValue("@f6", f6)
        cmd.Parameters.AddWithValue("@f7", f7)

        cmd.Parameters.AddWithValue("@adres1", adres1)
        cmd.Parameters.AddWithValue("@adres2", adres2)
        cmd.Parameters.AddWithValue("@postaKod", postaKod)
        cmd.Parameters.AddWithValue("@sehir", sehir)
        cmd.Parameters.AddWithValue("@teslimKisi", teslimKisi)
        cmd.Parameters.AddWithValue("@teslimTel", teslimTel)

        cmd.ExecuteNonQuery()


        cmd.Dispose()
        conn.Close()

    End Sub




    Function isTakenByOtherKontroller(ByVal havuzID As Integer) As Data.DataTable
        'bir satış kaydı başka bir kontroller tarafından üzerine alındıysa, işlemID,kontrollerID sini döner (bitirmiş mi hala üzerinde mi, geri mi yollamış)

        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.isTakenByOtherKontroller"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@havuzID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = havuzID
        cmd.Parameters.Add(myParameter)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt


    End Function

    Sub agenteGeriGonder(ByVal projeID As Integer, ByVal havuzID As Integer, ByVal kontrollerID As Integer, ByVal agentID As Integer, ByVal note As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zCont.agenteGeriGonder"
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@kontrollerID", kontrollerID)
        cmd.Parameters.AddWithValue("@note", note)

        
        cmd.ExecuteNonQuery()


        cmd.Dispose()
        conn.Close()

    End Sub

End Class
