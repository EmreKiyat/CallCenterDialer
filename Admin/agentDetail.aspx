<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="agentDetail.aspx.vb" Inherits="Admin_agentDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">

    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="1900px">
    <cc1:TabPanel runat="server" ID="pnlCalisan">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Agent Bilgileri"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>


<div style="float:left;clear:left; margin:14px; margin-top:24px; font-size:11px; color:#474747"">

<div>
    <asp:DropDownList ID="cmbAgents" runat="server" Width="200px" AutoPostBack="true" >
    </asp:DropDownList>
    <asp:Button ID="btnAgentDetail" runat="server" Text="Agent" />

</div>

<div id="divDetail" style="float:left;clear:left; margin:10px; margin-top:22px;" visible="false" runat="server">

<div class="solCL">
    <%--<asp:Image ID="imgAgentLock" runat="server" />--%>
    <asp:Label ID="lblAdSoyad" runat="server" Font-Bold="true" Font-Size="18px" ></asp:Label>
</div>    
<%--    <asp:Label ID="lblEmail" runat="server" Font-Bold="true" Font-Size="18px" ></asp:Label>
   <br />--%>
<div style="float:right; clear:right; margin-left:20px;">  
    
    <asp:Label ID="lblStatus" Font-Bold="true" Font-Size="18px" runat="server"></asp:Label>
</div>
   
   <div style="font-size:14px; float:left; clear:both; margin:12px; margin-top:22px;">
    
    <asp:Label ID="lblLockDurum" runat="server"></asp:Label>
    <asp:Button ID="btnLock" runat="server" Text="Şifre Çöz" Enabled="false" />
    </div>

   <div style="font-size:14px; float:left; clear:both; margin:12px;">
    
    <asp:Label ID="lblSistemIcDis" runat="server"></asp:Label>
    <asp:Button ID="btnUserEngelle" runat="server" Text="Kullanıcıyı Sistemden Çıkar" />
    </div> 
</div>


</div> 
</ContentTemplate> 
</cc1:TabPanel> 
</cc1:TabContainer> 
</div> 


</asp:Content>

