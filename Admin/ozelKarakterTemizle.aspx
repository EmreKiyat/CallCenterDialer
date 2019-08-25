<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="ozelKarakterTemizle.aspx.vb" Inherits="Admin_ozelKarakterTemizle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">



    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="1900px">
    <cc1:TabPanel runat="server" ID="pnlCalisan">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Özel Karakter Temizleme"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>


<div style="float:left;clear:left; margin:14px; margin-top:24px; font-size:11px; color:#474747"">

    <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
<asp:TextBox ID="txtHavuzID" runat="server"></asp:TextBox>
<asp:Button ID="btnUpdate" runat="server" Text="Temizle" />
<br />
    <asp:Label ID="lblUyar" runat="server" visible="false" Text=""></asp:Label>
<div style="float:right; clear:left; margin:14px;">


</div>
    

</div>
        

</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
</div>


<uc1:uyari ID="ascxUyari" runat="server"  />




</asp:Content>

