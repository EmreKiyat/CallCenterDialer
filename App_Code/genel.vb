Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration.ConfigurationSettings


Public Class genel
    Dim connTF As String = AppSettings.Get("TFConnectionString")

    Public Sub alBunuCalistir(ByVal sql As String, ByVal connStr As String)

        Dim conn As New SqlConnection(connStr)
        conn.Open()

        Dim trans As SqlTransaction
        trans = conn.BeginTransaction()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.Transaction = trans
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        trans.Commit()
        conn.Close()

    End Sub


    Public Function dataSetVerBana(ByVal sql As String, ByVal connStr As String, ByVal fill As String) As Data.DataSet

        Dim ds As New Data.DataSet
        Dim conn As New SqlConnection(connStr)

        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = sql
        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(ds, fill)

        conn.Close()
        cmd.Dispose()
        Return ds

    End Function


    Public Function dataTableVerBana(ByVal sql As String, ByVal connStr As String) As Data.DataTable

        Dim dt As New Data.DataTable
        Dim conn As New SqlConnection(connStr)

        conn.Open()

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = sql
        Dim da As New Data.SqlClient.SqlDataAdapter(cmd)

        da.Fill(dt)

        conn.Close()
        cmd.Dispose()
        Return dt

    End Function

    Public Function integerVerBana(ByVal sql As String, ByVal connStr As String) As Integer
        Dim rtrn As Integer
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = sql
        rtrn = cmd.ExecuteScalar
        conn.Close()
        Return CInt(rtrn)

    End Function


    Public Function stringVerBana(ByVal sql As String, ByVal connStr As String) As String
        Dim rtrn As String = ""
        Dim conn As New SqlConnection(connStr)
        conn.Open()
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = Data.CommandType.Text
        cmd.CommandText = sql
        rtrn = cmd.ExecuteScalar
        conn.Close()
        Return rtrn

    End Function


    Public Sub mailGonder(ByVal mSubject As String, ByVal mBody As String, ByVal ne As String)
        Dim too As String = ""
        Dim ds As New Data.DataSet
        Dim dr As Data.DataRow


        Dim mFrom As String = "transferFiyat@arcelik.com"

        Dim msg As MailMessage = New MailMessage()

        ds = dataSetVerBana("select email from mail_bildirim_listesi where tocc='to' and ne='" + ne + "'", connTF, "EMAIL")
        For Each dr In ds.Tables(0).Rows
            msg.To.Add(New MailAddress(dr("EMAIL")))
            'too = too + ";" + dr("EMAIL")
        Next
        'msg.To.Add(New MailAddress("emre.kiyat@arcelik.com"))

        msg.Body = mBody
        msg.Subject = mSubject
        msg.From = New MailAddress(mFrom)


        '        msg.CC.Add(mCC)

        msg.IsBodyHtml = True

        Dim SmtpMail As New SmtpClient("arsmtp")
        SmtpMail.UseDefaultCredentials = True
        SmtpMail.Send(msg)

        '        MsgBox("mesaj gönderildi")

    End Sub


    Public Sub mailGonderBilgi(ByVal mSubject As String, ByVal mBody As String, ByVal too1 As String)


        Dim mFrom As String = "transferFiyat@arcelik.com"

        Dim msg As MailMessage = New MailMessage()

        msg.To.Add(New MailAddress(too1))
        'msg.To.Add(New MailAddress(too2))


        msg.Body = mBody
        msg.Subject = mSubject
        msg.From = New MailAddress(mFrom)


        '        msg.CC.Add(mCC)

        msg.IsBodyHtml = True

        Dim SmtpMail As New SmtpClient("arsmtp")
        SmtpMail.UseDefaultCredentials = True
        SmtpMail.Send(msg)

        '        MsgBox("mesaj gönderildi")

    End Sub

End Class
