Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient


Public Class agents
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString
    Dim gnl As New genel

    Function getAgentsActive(ByVal firmID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getActiveAgents"
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

    Function getActiveAgentsNotInProject(ByVal firmID As Integer, ByVal projeID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getActiveAgentsNotInProject"
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


    Function getAgentsByProject(ByVal projeID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getAgentsByProject"
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
        '
    End Function

    Function getAgentsByProjectByDate(ByVal projeID As Integer, ByVal baslaTarih As String, ByVal bitisTarih As String) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getAgentsByProjectByDate"

        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@baslaTarih", baslaTarih)
        cmd.Parameters.AddWithValue("@bitisTarih", bitisTarih)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
        '
    End Function


    Function getAgentsByProjectForCmb(ByVal projeID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getAgentsByProjectForCmb"
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

        '
    End Function


    Function getAllAgentsForCombo(firmID As Integer) As Data.DataTable
        'agentDetail ekranı combosu için

        Dim dt As New Data.DataTable

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getAllAgentsForCombo"

        cmd.Parameters.AddWithValue("@firmID", firmID)



        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt
    End Function

    Function getProjeDataOzetByAgent(ByVal agentID As Integer, ByVal projeID As Integer) As Data.DataTable
        'bir agentin adetlerini, satış durumu, satlamayanlar sayııs vs. verir
        'projeIzle ekranında grdAgent'i populate etmek için - rowDataBoundunda
        Dim dt As New Data.DataTable

        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getProjeDataOzetByAgent"

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

    Function getAgentInformation(ByVal userID As Guid) As Data.DataTable
        'agentID ve firmID'yi döndürür, loginde sessionlara atamak için
        Dim dt As New Data.DataTable

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getAgentInformation"


        cmd.Parameters.AddWithValue("@userID", userID)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function


    Function getMyRandevuS(agentID As Integer, projeID As Integer) As Data.DataTable
        'randevu listesi

        Dim dt As New Data.DataTable

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.getMyRandevuS"


        cmd.Parameters.AddWithValue("@projeID", projeID)
        cmd.Parameters.AddWithValue("@agentID", agentID)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()

        Return dt

    End Function



    Sub disableAgentByEMail(email As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.disableAgentByEMail"

        cmd.Parameters.AddWithValue("@eMail", email)



        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub

    Sub enableAgentByEMail(email As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.enableAgentByEMail"

        cmd.Parameters.AddWithValue("@eMail", email)

        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub

End Class
