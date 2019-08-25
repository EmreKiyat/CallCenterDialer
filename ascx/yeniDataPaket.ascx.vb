
Partial Class ascx_yeniDataPaket
    Inherits System.Web.UI.UserControl


    Sub selectDataPaket(ByVal firmID As Integer)

        ''Dim datas As New datas
        ''Dim dt As New Data.DataTable
        ''dt = datas.getActiveDataPaket(firmID)


        ''grdDataPaket.Columns(0).Visible = True
        ''grdDataPaket.Columns(5).Visible = True
        ''grdDataPaket.DataSource = dt
        ''grdDataPaket.DataBind()

        ''grdDataPaket.Columns(0).Visible = False
        ''grdDataPaket.Columns(5).Visible = False

        ''mpeDataPaket.Show()


    End Sub


    Protected Sub btnDataIptal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataIptal.Click
        '' mpeDataPaket.Hide()
    End Sub




    Protected Sub btnDataSec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataSec.Click
        ''Dim dt As New Data.DataTable
        ''Dim dr As Data.DataRow

        ''dt.Columns.Add("dataExcelID")
        ''dt.Columns.Add("dataPaket")
        ''dt.Columns.Add("aciklama")
        ''dt.Columns.Add("CreateDate")
        ''dt.Columns.Add("numOfRec")
        ''Dim i As Integer
        ''Dim chked As Boolean

        ''With grdDataPaket

        ''    For i = 0 To .Rows.Count - 1
        ''        chked = CType(.Rows(i).Cells(4).Controls(1), CheckBox).Checked

        ''        If chked Then
        ''            dr = dt.NewRow
        ''            dr("dataExcelID") = .Rows(i).Cells(0).Text
        ''            dr("dataPaket") = .Rows(i).Cells(1).Text

        ''            dr("CreateDate") = .Rows(i).Cells(2).Text
        ''            dr("numOfRec") = .Rows(i).Cells(3).Text
        ''            dr("aciklama") = .Rows(i).Cells(5).Text
        ''            dt.Rows.Add(dr)

        ''        End If



        ''    Next

        ''    Dim grdData As GridView = CType(Parent.Controls(1).Controls(0).Controls(1).Controls(3).Controls(0).FindControl("grdDataProje"), GridView)

        ''    grdData.DataSource = dt
        ''    grdData.DataBind()

        ''End With
        ''mpeDataPaket.Hide()

    End Sub

    Protected Sub btnCancelDP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelDP.Click
        mpeDataPaket.Hide()

    End Sub
End Class
