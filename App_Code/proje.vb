Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient

Public Class proje
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString
    Dim gnl As New genel

    Function getProjectsByFirm(ByVal firmID As Integer, ByVal isActive As Boolean) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim sp As String
        If isActive Then sp = "readSp.getActiveProjectsByFirm" Else sp = "readSp.getAllProjectsByFirm"

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = sp
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



    Function getProjectsByUser(ByVal firmID As Integer, ByVal agentID As Integer, ByVal isActive As Boolean) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim sp As String
        If isActive Then sp = "zgent.getActiveProjectsByUSer" Else sp = "zgent.getAllProjectsByUser"

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = sp

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@agentID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = agentID
        cmd.Parameters.Add(myParameter)


        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()
        Return dt
    End Function



    Function getNumberOfDataInAPaket(ByVal dataExcelID As Integer) As Integer
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getNumberOfDataInAPaket"
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@dataExcelID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = dataExcelID
        cmd.Parameters.Add(myParameter)


        Dim numOfData As Integer = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return numOfData

    End Function


    Function getProjectsByUserAndRole(ByVal firmID As Integer, ByVal agentID As Integer, ByVal roleID As Integer) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim sp As String
        sp = "zgent.getActiveProjectsByUserAndRole"

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = sp

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@firmID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = firmID
        cmd.Parameters.Add(myParameter)
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@agentID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = agentID
        cmd.Parameters.Add(myParameter)
        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@roleID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = roleID
        cmd.Parameters.Add(myParameter)

        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()
        Return dt
    End Function


    Function getProjectsByFirmForCmb(ByVal firmID As Integer, ByVal isActive As Boolean) As Data.DataTable
        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim sp As String
        If isActive Then sp = "readSp.getActiveProjectsByFirmForCmb" Else sp = "readSp.getAllProjectsByFirmForCmb"

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = sp
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



    Function getProjeDataOzetToday(ByVal projeID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getProjeDataOzetToday"
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

    Function getProjeDataOzetOnLive(ByVal projeID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getProjeDataOzetOnLive"
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



    Function getProjeDataOzetProcessed(ByVal projeID As Integer) As Data.DataTable

        Dim dt As New Data.DataTable
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "readSp.getProjeDataOzetProcessed"
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

    Sub setAgentRoleInProje(ByVal projeID As Integer, ByVal roleID As Integer, ByVal agentID As Integer)
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "updateSP.setAgentRoleInProje"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)


        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@roleID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = roleID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@agentID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = agentID
        cmd.Parameters.Add(myParameter)

        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub


    Sub setAgentActivationInProje(ByVal projeID As Integer, ByVal agentID As Integer, ByVal isAktif As Integer)
        Dim myParameter As Data.SqlClient.SqlParameter
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "updateSP.setAgentActivationInProje"

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@projeID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = projeID
        cmd.Parameters.Add(myParameter)


        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@agentID"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = agentID
        cmd.Parameters.Add(myParameter)

        myParameter = cmd.CreateParameter()
        myParameter.ParameterName = "@isAktif"
        myParameter.Direction = Data.ParameterDirection.Input
        myParameter.SqlDbType = Data.SqlDbType.Int
        myParameter.Value = isAktif
        cmd.Parameters.Add(myParameter)

        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()
    End Sub

    Sub projeyeEkipEkle(ByVal dt As Data.DataTable, ByVal projeID As Integer)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.projeyeEkipEkle"
        cmd.Parameters.AddWithValue("@ekip", dt)
        cmd.Parameters.AddWithValue("@projeID", projeID)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub




End Class
