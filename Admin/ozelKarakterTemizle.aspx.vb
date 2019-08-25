
Partial Class Admin_ozelKarakterTemizle
    Inherits System.Web.UI.Page

    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click
        Dim adm As New admin
        Try
            adm.updateTurkishCharProblemByDataID(CInt(txtHavuzID.Text.Trim))
            ascxUyari.uyar("Data Temizleme işlemi yapıldı, Agent ekran işlemini tekrar deneyebilir.", "#343434", "")

        Catch ex As Exception
            ascxUyari.uyar("Data Temizleme işlemi gerçekleşmedi", "#343434", "")

        End Try

    End Sub
End Class
