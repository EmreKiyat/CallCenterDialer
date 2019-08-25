Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient

Public Class admin

    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString

    Sub updateUlasilamayanlarAsComplatedByPaket(ByVal excelID As Integer, projeID As Integer)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zAdmin.updateUlasilamayanlarAsComplatedByPaket"

        cmd.Parameters.AddWithValue("@excelID", excelID)
        cmd.Parameters.AddWithValue("@projeID", projeID)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub

    Sub updateComplatedUlasilamayanlarTekrarGelsinByPaket(ByVal excelID As Integer, projeID As Integer)
        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zAdmin.updateComplatedUlasilamayanlarTekrarGelsinByPaket"

        cmd.Parameters.AddWithValue("@excelID", excelID)
        cmd.Parameters.AddWithValue("@projeID", projeID)

        cmd.ExecuteNonQuery()

        cmd.Dispose()
        conn.Close()
    End Sub



    Function getComplatedUlasilamayanSayisi(ByVal projeID As Integer, excelID As Integer) As Integer

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zAdmin.getComplatedUlasilamayanSayisi"

        cmd.Parameters.AddWithValue("@excelID", excelID)
        cmd.Parameters.AddWithValue("@projeID", projeID)


        Dim cnt As Integer = cmd.ExecuteScalar


        conn.Close()
        cmd.Dispose()

        Return cnt

    End Function


    Sub updateTurkishCharProblemByDataID(ByVal havuzID As Integer)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "zgent.zzzUpdateTurkishCharProblemByDataID"

        cmd.Parameters.AddWithValue("@havuzID", havuzID)


        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()



    End Sub




End Class
