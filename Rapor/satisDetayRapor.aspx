<%@ Page Language="VB" AutoEventWireup="false" CodeFile="satisDetayRapor.aspx.vb" Inherits="Rapor_satisDetayRapor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<%--    <link href="../css/tabs/core.css" rel="stylesheet" type="text/css" />--%>
    <link href="../css/tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../css/rapor.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" id="scmnRapor"></asp:ScriptManager>

    <div>
    
    
<cc1:TabContainer id="tcForRaporOzet" runat="server" CssClass="gray raporTabContainer" >
<cc1:TabPanel ID="tcPRTab" runat="server">
<HeaderTemplate>
    <asp:Label Font-Size="13px" ID="lblOzet" Text="Detaylı Satış Raporu" runat="server"></asp:Label>

</HeaderTemplate>
<ContentTemplate>


    <div style="padding-top:14px; padding-bottom:444px; margin-left:20px;">
          
         <table>
            <thead>
                <tr>
                    <td><asp:Label ID="lblBasla" runat="server" Text="Başla"></asp:Label></td>
                    <td><asp:Label ID="lblBitis" runat="server" Text="Bitiş"></asp:Label></td>
                    <td><asp:Label ID="Label1" runat="server" CssClass="rporCombo" Text="Proje"></asp:Label></td>
                    <td><asp:Label ID="Label2" runat="server" CssClass="rporCombo" Text="Agent"></asp:Label></td>
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
                    <td>
                    <asp:UpdatePanel ID="updForAgentCmb" runat="server">
                    <ContentTemplate>
                     <asp:DropDownList ID="cmbAgent" CssClass="rporCombo" runat="server"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmbProje" EventName="SelectedIndexChanged" />
                   
                    </Triggers>
                    </asp:UpdatePanel>
<asp:UpdateProgress ID="updProcessForAgntCmb" runat="server" AssociatedUpdatePanelID="updForAgentCmb">
<ProgressTemplate>
    <asp:Image ID="Image112e" ImageUrl="~/images/ajax-loader.gif" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>

                    </td>
                    <td></td>
                    <td><asp:Button ID="btnRapor" runat="server" Text="Raporla" /></td>
                    <td><asp:Button ID="btnExcel" runat="server" Enabled="False" Text="Excel'e Al" /></td>
                </tr>
            
            </tbody>
         </table> 
          
            
        
        
        
        <br /><br />


      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>

              
        <asp:GridView ID="grdSatisDetay" runat="server" CellPadding="2" ClientIDMode="Predictable" 
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

        
        <asp:BoundField DataField="havuzID"/>
        <asp:BoundField DataField="dataID" />
        <asp:BoundField DataField="projeID"/>
        <asp:BoundField HeaderText="Home" DataField="isHomeAgent"/>
        <asp:BoundField HeaderText="Tarih" DataField="processTarih"/>
        <asp:BoundField HeaderText="Termin" DataField="terminTarih" />
        <asp:BoundField HeaderText="Müşteri" DataField="adSoyad"/>

        <asp:TemplateField>
        <HeaderTemplate>Tel</HeaderTemplate>
        <ItemTemplate>
        <asp:Label ID="lblPdd" runat="server" Text='<%# getSifresizTel(Eval("tel1")) %>' />
        
        </ItemTemplate>
        
        </asp:TemplateField>
        <%--<asp:BoundField DataField="tel1"/>--%>
        <asp:BoundField HeaderText="Adres" DataField="adres" />
        <asp:BoundField HeaderText="Şehir" DataField="sehir"/>

        <asp:BoundField HeaderText="eMail" DataField="eMail" ItemStyle-Width="100px" />

        <asp:BoundField HeaderText="Agent" DataField="satanAgent" ItemStyle-Width="100px" />
         <asp:BoundField HeaderText="Ön Görüşen" DataField="onGorusenAgent" ItemStyle-Width="100px" />

         <asp:BoundField HeaderText="Data Paket" DataField="dataPaket" ItemStyle-Width="100px" />

          <%--  <asp:CommandField ButtonType="Link" ItemStyle-Width="40px" SelectText="Detay" ShowSelectButton="True" ControlStyle-Width="50px" />--%>
       
          
        </Columns>
        </asp:GridView>
        

        
        </ContentTemplate>
        <Triggers>
              <asp:AsyncPostBackTrigger ControlID="btnRapor" EventName="Click" />
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
