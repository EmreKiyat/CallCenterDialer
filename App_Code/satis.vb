Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient

Public Class satis

    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString


    Sub writeSatisIslemleri(ByVal projeID As Integer, ByVal havuzID As Integer, ByVal islem As Integer, _
                            ByVal agentID As Integer, ByVal tutar As Decimal, ByVal note As String, _
                            ByVal customFieldID As Integer, ByVal f1 As String, ByVal f2 As String, ByVal f3 As String, _
                            ByVal f4 As String, ByVal f5 As String, ByVal f6 As String, ByVal f7 As String, _
                            ByVal satilanPaket As Data.DataTable, _
                            ByVal adres1 As String, ByVal adres2PlusPostaKod As String, ByVal postaKod As String, ByVal sehir As String, ByVal eMail As String, _
                           ByVal teslimKisi As String, ByVal teslimTel As String)  'bu parametreler sonradan ek



        'satış işleminde havuz etrafındaki işlem tablolarını + log tablolarını yazar, havuz kaydını update eder

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.writeSatisIslem"
        cmd.Parameters.AddWithValue("@satilanPaket", satilanPaket)
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@islem", islem)
        cmd.Parameters.AddWithValue("@agentID", agentID)
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

        'adres parametreleri
        cmd.Parameters.AddWithValue("@adres1", adres1)
        cmd.Parameters.AddWithValue("@adres2PlusPostaKod", adres2PlusPostaKod)
        cmd.Parameters.AddWithValue("@postaKod", postaKod)
        cmd.Parameters.AddWithValue("@sehir", sehir)
        cmd.Parameters.AddWithValue("@eMail", eMail)
        cmd.Parameters.AddWithValue("@teslimKisi", teslimKisi)
        cmd.Parameters.AddWithValue("@teslimTel", teslimTel)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub

    Sub notSoldIslemleri(ByVal projeID As Integer, ByVal havuzID As Integer, ByVal agentID As Integer, ByVal note As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.writeNotSoldIslem"

        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@note", note)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()

    End Sub


    Sub writeRandevuIslemleri(ByVal projeID As Integer, ByVal havuzID As Integer, _
                        ByVal agentID As Integer, ByVal islem As Integer, ByVal note As String, ByVal termin As DateTime)


        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.writeRandevuIslem"
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@islem", islem)
        cmd.Parameters.AddWithValue("@termin", termin)
        cmd.Parameters.AddWithValue("@note", note)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub

    Sub updateYanlisEksikNo(ByVal havuzID As Integer, ByVal agentID As Integer)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.updateYanlisEksikNo"

        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub


    Sub writeDataToBlackList(ByVal firmID As Integer, ByVal havuzID As Integer, ByVal agentID As Integer, ByVal tel1 As String, ByVal tel2 As String, ByVal tel3 As String)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.writeDataToBlackList"

        cmd.Parameters.AddWithValue("@firmID", firmID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)
        cmd.Parameters.AddWithValue("@agentID", agentID)
        cmd.Parameters.AddWithValue("@tel1", tel1)
        cmd.Parameters.AddWithValue("@tel2", tel2)
        cmd.Parameters.AddWithValue("@tel3", tel3)


        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub

    Sub gorevListesiniComplatedYap(ByVal agentGorevListID As Integer)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.gorevListesiniComplatedYap"

        cmd.Parameters.AddWithValue("@agentGorevListID", agentGorevListID)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub

    Function getSattiklarim(ByVal projeID As Integer, ByVal agentID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getSattiklarim"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@agentID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = agentID
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



    Function isYenilemeProjesi(ByVal projeID As Integer) As Integer
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.isYenilemeProjesi"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)


        Dim isYenileme As Integer = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return isYenileme

    End Function

    Function getLogo(firmID As Integer) As String
        'Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getLogo"
        cmd.Parameters.AddWithValue("@firmID", firmID)

        Dim logo As String = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return logo
    End Function

    Function isSelfKontroller(ByVal projeID As Integer) As Integer
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.isSelfKontroller"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)


        Dim isSelf As Integer = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return isSelf
    End Function


    Sub setSelfSatisOnay(ByVal projeID As Integer, ByVal havuzID As Integer, ByVal agentID As Integer)

        'bu fonksiyonun aga babası kontroller.vb'de
        'self kontroller projelerde agentin ssatışını onaylaması için
        '
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.setSelfSatisOnay"
        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@havuzID", havuzID)

        cmd.Parameters.AddWithValue("@agentID", agentID)

        cmd.ExecuteNonQuery()


        cmd.Dispose()
        conn.Close()

    End Sub

End Class
