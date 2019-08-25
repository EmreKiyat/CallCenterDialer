
Partial Class ascx_agentEkle
    Inherits System.Web.UI.UserControl



    Public Sub selectAgents(ByVal firmID As Integer)
        Dim agnt As New agents
        Dim dt As New Data.DataTable
        dt = agnt.getAgentsActive(firmID)
        grdAgentForProje.DataSource = dt
        grdAgentForProje.DataBind()
        mpeAgnt.Show()


    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        mpeAgnt.Hide()

    End Sub


    Protected Sub btnAgentIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentIptal.Click
        mpeAgnt.Hide()
    End Sub

    Protected Sub btnAgentSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgentSec.Click

        Dim grdAgnt As DataGrid = CType(Parent.FindControl("grdAgntProje"), DataGrid)



        Dim dt As New Data.DataTable
        Dim dr As Data.DataRow

        dt.Columns.Add("agentID")
        dt.Columns.Add("adSoyad")
        dt.Columns.Add("roleID")
        dt.Columns.Add("isHomeAgent")
        Dim i As Integer
        Dim chked As Boolean

        With grdAgentForProje

            For i = 0 To .Rows.Count - 1

                chked = CType(.Rows(i).Cells(5).Controls(1), CheckBox).Checked

                If chked Then
                    dr = dt.NewRow
                    dr("agentID") = .Rows(i).Cells(0).Text
                    dr("adSoyad") = .Rows(i).Cells(1).Text
                    dr("roleID") = .Rows(i).Cells(3).Text
                    dr("isHomeAgent") = .Rows(i).Cells(4).Text
                    dt.Rows.Add(dr)
                End If

            Next

            grdAgnt.DataSource = dt
            grdAgnt.DataBind()

            mpeAgnt.Hide()
        End With




    End Sub
End Class
