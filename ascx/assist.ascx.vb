
Partial Class ascx_assist
    Inherits System.Web.UI.UserControl


    Public Sub Show()
        mpeAssist.Show()
    End Sub



    Protected Sub wzdAssist_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles wzdAssist.FinishButtonClick

        Dim status As Boolean
        Dim statusAll As Boolean = False
        mpeAssist.Hide()
        With Parent.Controls(1).Controls(0).Controls(1)
            'başlangıç metni için
            Dim tmpGiris As Label = CType(.FindControl("lblGiris"), Label)
            Dim tmpGirisOk As Label = CType(.FindControl("lblGirisOk"), Label)
            status = txtBasla.Text.Trim.Length > 4
            statusSet(tmpGiris, tmpGirisOk, status)
            statusAll = status

            'key pointler için
            Dim keyYok As Boolean
            keyYok = txtKP1.Text.Trim.Length < 2 And txtKP2.Text.Trim.Length < 2 And txtKP3.Text.Trim.Length < 2 And txtKP4.Text.Trim.Length < 2 And _
                txtKP5.Text.Trim.Length < 2 And txtKP6.Text.Trim.Length < 2 And txtKP7.Text.Trim.Length < 2 And txtKP8.Text.Trim.Length < 2
            Dim tmpKeys As Label = CType(.FindControl("lblKeys"), Label)
            Dim tmpKeysOk As Label = CType(.FindControl("lblKeysOk"), Label)
            status = Not keyYok
            statusSet(tmpKeys, tmpKeysOk, status)
            statusAll = statusAll Or status
            'son metni için
            Dim tmpKapa As Label = CType(.FindControl("lblKapa"), Label)
            Dim tmpKapaOk As Label = CType(.FindControl("lblKapaOk"), Label)
            status = txtKapanis.Text.Trim.Length > 4
            statusSet(tmpKapa, tmpKapaOk, status)
            statusAll = statusAll Or status

            'paketlerin gösterilip gösterilmeyeceği
            Dim tmpPaket As Label = CType(.FindControl("lblPaket"), Label)
            Dim tmpPaketOk As Label = CType(.FindControl("lblPaketOk"), Label)
            statusSet(tmpPaket, tmpPaketOk, statusAll)





        End With

    End Sub

    Sub statusSet(ByRef ilk As Label, ByRef chk As Label, ByVal isLight As Boolean)
        If isLight Then
            ilk.ForeColor = Drawing.Color.DarkGreen
            chk.ForeColor = Drawing.Color.DarkGreen
            chk.Text = "v"

        Else
            ilk.ForeColor = Drawing.Color.FromName("#787878")
            chk.ForeColor = Drawing.Color.FromName("#787878")
            chk.Text = "x"
        End If

    End Sub
    Protected Sub wzdAssist_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles wzdAssist.NextButtonClick
        mpeAssist.Show()

    End Sub

    Protected Sub wzdAssist_PreviousButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles wzdAssist.PreviousButtonClick
        mpeAssist.Show()
    End Sub


End Class
