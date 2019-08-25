<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="telGoster.aspx.vb" Inherits="Admin_telGoster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">


    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="1900px">
    <cc1:TabPanel runat="server" ID="pnlCalisan">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Telefon No Bulucu"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>


<div style="float:left;clear:left; margin:14px; margin-top:24px; font-size:11px; color:#474747"">

    <asp:Label ID="Label1" runat="server" Text="Kişi: "></asp:Label>
<asp:TextBox ID="txtAdSoyad" runat="server"></asp:TextBox>
<asp:Button ID="btnAra" runat="server" Text="Ara" />
<br />
    <asp:Label ID="lblUyar" runat="server" visible="false" Text="En Az 4 karakter arama yapabilirsin."></asp:Label>
<div style="float:right; clear:left; margin:14px;">


        <asp:GridView ID="grdTelNolar" runat="server" AutoGenerateColumns="false" BorderStyle="None"  ShowHeader="false" >

                    <RowStyle ForeColor="#343434"/>
                    <AlternatingRowStyle BackColor="#efefef"/>
                      <Columns>
                      <asp:BoundField DataField="tel1" Visible="false" />
                      <asp:BoundField DataField="tel2" Visible="false" />
                      <asp:BoundField DataField="tel3" Visible="false" />
                      
                      <asp:BoundField DataField="adSoyad" ItemStyle-Width="250px"/>
                      <asp:BoundField DataField="dataPaket" ItemStyle-Width="180px"/>    
                      <asp:BoundField HeaderText="Tel 1" ItemStyle-Width="100px"/>
                      <asp:BoundField HeaderText="Tel 2" ItemStyle-Width="100px"/>
                      <asp:BoundField HeaderText="Tel 3" ItemStyle-Width="100px"/>
                      
                      </Columns>
                    </asp:GridView>


</div>
    


</div>
        

</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
</div>


<uc1:uyari ID="ascxUyari" runat="server"  />

</asp:Content>

