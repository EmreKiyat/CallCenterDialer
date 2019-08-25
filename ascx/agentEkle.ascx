<%@ Control Language="VB" AutoEventWireup="false" CodeFile="agentEkle.ascx.vb" Inherits="ascx_agentEkle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


             <asp:Button ID="btnHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeAgnt" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="Panel1"
                 TargetControlID="btnHidden">
                 
             </cc1:ModalPopupExtender>
             
                 
    <asp:Panel ID="Panel1" CssClass="popup1" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblSubsPopupBaslik" runat="server" CssClass="hLabel" Text="Agent Ekle "></asp:Label>    
<br /><asp:Label ID="lblSubsPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    



        <asp:GridView ID="grdAgentForProje" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
        AllowPaging="True" PageSize="20"
        AllowSorting="True">
            <HeaderStyle BackColor="#CDD4F4" />
            

            <PagerSettings PageButtonCount="6" Position="TopAndBottom" />

        <RowStyle BackColor="Beige" ForeColor="#5E5281" />
        <AlternatingRowStyle BackColor="#ffffff" ForeColor="#6E6291"  />        
        <Columns>
        
        <asp:BoundField DataField="agentID" ItemStyle-CssClass="hidden" ItemStyle-Width="1px" />
        <asp:BoundField HeaderText="Agent" DataField="adSoyad" ItemStyle-Width="130px" />
        <asp:BoundField HeaderText="Tanım Tarihi" DataField="CreateDate" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
<asp:BoundField HeaderText="Role" DataField="roleID" ItemStyle-Width="70px" />
        <asp:BoundField HeaderText="Home Agent" DataField="isHomeAgent" ItemStyle-Width="70px" />
        
       
               <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label3" runat="server" Text="Proje Seç"></asp:Label></HeaderTemplate>
               <ItemStyle CssClass="ortala" />
               <ItemTemplate>
               
               <asp:CheckBox ID="chkAgentSec" ClientIDMode="Predictable" runat="server" />
               
               </ItemTemplate>
         </asp:TemplateField> 
          
        </Columns>
        </asp:GridView>
        
      </div>  
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Tamam" CssClass="buttonTamam" ID="btnAgentSec" />
       
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnAgentIptal" />
       
       
       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdAgentForProje" EventName="PageIndexChanging" />

</Triggers>
        
    </asp:UpdatePanel>
        


    </asp:Panel>
    
    