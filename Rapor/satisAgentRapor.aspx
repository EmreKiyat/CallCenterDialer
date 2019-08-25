<%@ Page Language="VB" AutoEventWireup="false" CodeFile="satisAgentRapor.aspx.vb" Inherits="Rapor_satisAgentRapor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 

     <asp:ScriptManager runat="server" id="scmAgntRapor"></asp:ScriptManager>

    <div>
    
    
<cc1:TabContainer id="tcForAgntRapor" runat="server" CssClass="gray raporTabContainer" >
<cc1:TabPanel ID="tcAgntTab" runat="server">
<HeaderTemplate>
    <asp:Label Font-Size="13px" ID="lblOzet" Text="Agent Satış Raporu" runat="server"></asp:Label>

</HeaderTemplate>
<ContentTemplate>


    <div style="padding-top:14px; padding-bottom:444px; margin-left:20px;">
          
         <table>
            <thead>
                <tr>
                    <td><asp:Label ID="lblBasla" runat="server" Text="Başla"></asp:Label></td>
                    <td><asp:Label ID="lblBitis" runat="server" Text="Bitiş"></asp:Label></td>
                    <td><asp:Label ID="Label1" runat="server" CssClass="rporCombo" Text="Proje"></asp:Label></td>
                    
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </thead>
            <tbody>
            
                <tr>
                    <td> <asp:TextBox ID="txtBasla" Width="80px" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="calBasla" runat="server" TargetControlID="txtBasla" 
                            Enabled="True" Format="dd.MM.yyyy"></cc1:CalendarExtender></td>
                    <td> <asp:TextBox ID="txtBitis" Width="80px" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="calBitis" runat="server" Format="dd.MM.yyyy" TargetControlID="txtBitis" 
                            Enabled="True"></cc1:CalendarExtender></td>
                    <td> <asp:DropDownList ID="cmbProje" CssClass="rporCombo" runat="server" 
                            AutoPostBack="True" > </asp:DropDownList></td>

      
                    <td></td>
                    <td><asp:Button ID="btnRapor" runat="server" Text="Raporla" /></td>
                    
                </tr>
            
            </tbody>
         </table> 
          
        
        
        
        
        <br /><br />


      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>

              
        <asp:GridView ID="grdAgentSatis" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
        ShowHeader="true"  
        >
        <EmptyDataTemplate>
            
            <div style="margin:60px;border:1px solid #dddddd;padding:30px;">
                Belirtilen kriterlerde satış datası bulunamadı.
            </div>
        
        </EmptyDataTemplate>    
        <HeaderStyle HorizontalAlign="Left" />           
        <RowStyle BackColor="Beige" ForeColor="#5E5281" />
        <AlternatingRowStyle BackColor="#ffffff" ForeColor="#6E6291"  />        
        <Columns>

        
        <asp:BoundField DataField="agentID"/>

        <asp:BoundField DataField="isAktif"/>
        <asp:BoundField DataField="roleID"/>
        <asp:BoundField DataField="isAktifInFirm"/>
        <asp:BoundField DataField="agentID"/>
        <asp:BoundField DataField="isHomeAgent"/>   <%--5--%>


        <asp:BoundField DataField="adSoyad" ItemStyle-Width="200px" />
        <asp:BoundField HeaderText="Home"/>
        <asp:BoundField HeaderText="Başlangıç" DataField="baslaTarih" />
        <asp:BoundField HeaderText="Son Giriş" DataField="LastLoginDate" />

        <asp:BoundField HeaderText="Toplam Görüşme" DataField="toplamIslem" />  <%--10--%>
        <asp:BoundField HeaderText="Toplam Onaysız" DataField="toplamSatisNotCmmttd"/>
        <asp:BoundField HeaderText="Toplam Onaylı" DataField="toplamSatisCmmttd"/>
        <asp:BoundField HeaderText="Proje Toplam" />

        <asp:BoundField HeaderText="Görüşme" DataField="aramaAdet" />
        <asp:BoundField HeaderText="Satış Onaysız" DataField="satisNotCommitted"/>
        <asp:BoundField HeaderText="Satış Onaylı" DataField="satisCommitted"/>
        <asp:BoundField HeaderText="Satış Toplam" />



            <asp:CommandField ButtonType="Link" ItemStyle-Width="40px" SelectText="Detay" ShowSelectButton="True" ControlStyle-Width="50px" />
       
          
        </Columns>
        </asp:GridView>
        

        
        </ContentTemplate>
        <Triggers>
              <asp:AsyncPostBackTrigger ControlID="btnRapor" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="cmbProje" EventName="SelectedIndexChanged" />
              
        </Triggers>

        </asp:UpdatePanel> 
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:Image ID="Image1" ImageUrl="~/images/ajax-loader.gif" runat="server" />
            </ProgressTemplate>
</asp:UpdateProgress>
    </div>
    
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
    

    </div>

        <uc1:uyari ID="ascxUyari" runat="server"  />


    </form>
</body>
</html>
