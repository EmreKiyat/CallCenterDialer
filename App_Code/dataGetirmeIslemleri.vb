Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient


Public Class dataGetirmeIslemleri

    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString

    Function havuzdanDataGetir(ByVal agentID As Integer, ByVal projeID As Integer) As Data.DataTable
        '
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getData"

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

    Function havuzdanDataGetirOrderByTerminForMEAndDisabledAgent(ByVal agentID As Integer, ByVal projeID As Integer, ByVal onGorusuldu As Integer) As Data.DataTable
        'yenileme projeleri için
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.havuzdanDataGetirOrderByTerminForMEAndDisabledAgent"

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

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@onGorusuldu"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = onGorusuldu
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function

    Function havuzdanDataGetirOrderByTermin(ByVal agentID As Integer, ByVal projeID As Integer, ByVal onGorusuldu As Integer) As Data.DataTable
        'yenileme projeleri için
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getDataOrderByTermin"

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

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@onGorusuldu"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = onGorusuldu
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function


    Function gorevListesindenDataGetir(ByVal agentID As Integer, ByVal projeID As Integer, ByVal onGorusuldu As Integer) As Data.DataTable

        '
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getDataAgentGorev"

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
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@onGorusuldu"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = onGorusuldu
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function

    Function banaKapakDataGetir(ByVal agentID As Integer, ByVal projeID As Integer, ByVal onGorusuldu As Integer) As Data.DataTable

        '
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getDataBanaKapak"

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

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@onGorusuldu"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = onGorusuldu
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function

    Function dataLogGetir(ByVal havuzID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getDataLog"

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

    Function getCustomFieldsOnSaleDef(ByVal projeID As Integer, ByVal havuzID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getCustomFieldsOnSaleDef"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)

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


    Function getProjeSatisPaket(ByVal projeID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getProjeSatisPaket"

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


End Class
