Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Data.SqlClient
Imports System.Net.Mail

Public Class forKaydol
    Dim connStr As String = ConfigurationManager.ConnectionStrings("ArgeCS").ToString

    Sub memCreateUser(ByVal firmID As Integer, ByVal userID As Guid, ByVal isHomeAgent As Integer, ByVal adSoyad As String, ByVal tcKimlik As String, ByVal cepTel As String, ByVal evTel As String, _
                      ByVal eMail As String, ByVal dil As String, ByVal adres As String, ByVal note As String, ByVal agntProje As Data.DataTable)


        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "writeSP.createUserX"



        cmd.Parameters.AddWithValue("@firmID", firmID)
        cmd.Parameters.AddWithValue("@userID", userID)
        '   cmd.Parameters.AddWithValue("@gorev", gorev) 'bu proje bilgisi ile gönderilecek
        cmd.Parameters.AddWithValue("@isHomeAgent", isHomeAgent)
        cmd.Parameters.AddWithValue("@adSoyad", adSoyad)
        cmd.Parameters.AddWithValue("@tcKimlik", tcKimlik)
        cmd.Parameters.AddWithValue("@cepTel", cepTel)
        cmd.Parameters.AddWithValue("@evTel", evTel)
        cmd.Parameters.AddWithValue("@eMail", eMail)
        cmd.Parameters.AddWithValue("@dil", dil)
        cmd.Parameters.AddWithValue("@adres", adres)
        cmd.Parameters.AddWithValue("@note", note)
        cmd.Parameters.AddWithValue("@agntProje", agntProje)        'table-valued parameter


        cmd.ExecuteNonQuery()


        conn.Close()
        cmd.Dispose()

    End Sub



End Class
