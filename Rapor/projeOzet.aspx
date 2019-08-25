<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="projeOzet.aspx.vb" Inherits="Rapor_projeOzet" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">



    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="530px">
<cc1:TabPanel ID="tabMusteri1" runat="server" meta:resourcekey="tabMusteri1Resource1">
<HeaderTemplate>
<label style="font-size:13px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#444;">Dergi Abone Satış - Proje Durum Raporu</label>
</HeaderTemplate>

<ContentTemplate> 

<div>    
       <fieldset class="reqKutular" style="height:120px; width:47%">
           <legend class="legandStyle"><asp:Label ID="lblRole" runat="server"  Text="Genel Bilgi" 
                   ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">
            
        
   <table style="width: 99%; font-family:Verdana, Geneva, Tahoma, sans-serif; font-size: 11px; color: #333333;">
	<tr style="height:20px; ">
		<td>Proje Tarihi</td>
		<td>12.04.2010</td>
	</tr>
	<tr style="height:20px;background-color:#eee;">
		<td>Agent</td>
		<td>44</td>
	</tr>
	<tr style="height:20px;">
		<td>Data Adet</td>
		<td>72.671 (4 paket)</td>
	</tr>
	<tr style="height:20px;background-color:#eee;">
		<td>Proje Sorumlusu</td>
		<td>Salim Güneş</td>
	</tr>

</table>

           </div>
       </fieldset>

       <fieldset class="reqKutular" style="height:120px; width:47%">
           <legend class="legandStyle"><asp:Label ID="Label1" runat="server"  Text="Satış Özet" 
                   ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">
            
        
   <table style="width: 99%; font-family:Verdana, Geneva, Tahoma, sans-serif; font-size: 11px; color: #333333;">
	<thead>
	<tr style="height:20px; background-color:#bbb; color:#fdfdfd; font-weight:bold;">
	<td></td>
	<td>Görüşme</td>
	<td>Satış Adet</td>
	<td>Satış %</td>
	

	</tr></thead>
	<tr  style="height:20px; background-color:#eee;">
		<td>Bu Gün</td>
		<td class="raporAllignRight">844</td>
		<td class="raporAllignRight">117</td>
		<td class="raporAllignRight">13,8</td>
	
	</tr>
	<tr style="height:20px; ">
		<td>Bu Ay</td>
		<td class="raporAllignRight">7.566</td>
		<td class="raporAllignRight">945</td>
		<td class="raporAllignRight">12,4</td>
	
	</tr>
	<tr style="height:20px; background-color:#eee;">
		<td>Toplam Satış</td>
		<td class="raporAllignRight">57.394</td>
		<td class="raporAllignRight">7.051</td>
		<td class="raporAllignRight">12,3</td>
							
	</tr>


</table>

           </div>
       </fieldset>

    
              <fieldset class="reqKutular" style="height:200px; width:47%">
           <legend class="legandStyle"><asp:Label ID="Label2" runat="server"  Text="Satış Detay - Aylara göre" 
                   ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">
          
             <table style="width: 99%; font-family:Verdana, Geneva, Tahoma, sans-serif; font-size: 11px; color: #333333;">
	<thead>
	<tr style="height:20px; background-color:#bbb; color:#fdfdfd; font-weight:bold;">
	<td></td>
	<td>Görüşme</td>
	<td>Satış Adet</td>
	<td>Satış %</td>
	

	</tr></thead>


	<tr style="height:20px; background-color:#eee;">
		<td>Ocak, 11</td>
		<td class="raporAllignRight">7.566</td>
		<td class="raporAllignRight">945</td>
		<td class="raporAllignRight">12,4</td>
	
	</tr>
	<tr  style="height:20px; ">
		<td>Aralık, 10</td>
		<td class="raporAllignRight">9.355</td>
		<td class="raporAllignRight">1.283</td>
		<td class="raporAllignRight">13,7</td>
	
	</tr>

	<tr style="height:20px; background-color:#eee;">
		<td>Kasım, 10</td>
		<td class="raporAllignRight">11.862</td>
		<td class="raporAllignRight">1.712</td>
		<td class="raporAllignRight">14,4</td>
							
	</tr>
    	<tr style="height:20px;">
		<td>Ekim, 10</td>
		<td class="raporAllignRight">10.441</td>
		<td class="raporAllignRight">1.307</td>
		<td class="raporAllignRight">12,5</td>
							
	</tr>
    	<tr style="height:20px; background-color:#eee;">
		<td>Eylül, 10</td>
		<td class="raporAllignRight">9.959</td>
		<td class="raporAllignRight">1.102</td>
		<td class="raporAllignRight">11,0</td>
							
	</tr>
    	<tr style="height:20px;">
		<td>Ağustos, 10</td>
		<td class="raporAllignRight">8.211</td>
		<td class="raporAllignRight">702</td>
		<td class="raporAllignRight">8,5</td>
							
	</tr>


</table>

           </div> 
           </fieldset> 
              <fieldset class="reqKutular" style="height:200px; width:47%">
           <legend class="legandStyle"><asp:Label ID="Label3" runat="server"  Text="Satış Detay - Paket Satışları" 
                   ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">


   <table style="width: 99%; font-family:Verdana, Geneva, Tahoma, sans-serif; font-size: 11px; color: #333333;">
	<thead>
	<tr style="height:20px; background-color:#bbb; color:#fdfdfd; font-weight:bold;">
	<td></td>
	
	<td>Satış Adet</td>
	<td>Satış %</td>
	

	</tr></thead>
	<tr  style="height:20px; background-color:#eee;">
		<td>6 Ay Abonelik</td>
	
		<td class="raporAllignRight">1.655</td>
		<td class="raporAllignRight">23,4</td>
	
	</tr>
	<tr style="height:20px; ">
		<td>1 Yıl Abonelik</td>
	
		<td class="raporAllignRight">5.111</td>
		<td class="raporAllignRight">72,5</td>
	
	</tr>
	<tr style="height:20px; background-color:#eee;">
		<td>2 Yıl Abonelik</td>
	
		<td class="raporAllignRight">285</td>
		<td class="raporAllignRight">4,0</td>
							
	</tr>


</table>



           </div> 
           </fieldset> 


</div>
    
</ContentTemplate> 
</cc1:TabPanel> 
</cc1:TabContainer> 


</asp:Content>

