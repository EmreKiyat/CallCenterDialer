<%@ Control Language="VB" AutoEventWireup="false" CodeFile="yeniDataPaket.ascx.vb" Inherits="ascx_yeniDataPaket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<script type="text/jscript">
    function chngBgImgPopTamam(aa) {

        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popTamam_1.png')";
    }

    function chngBgImgPopTamamO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popTamam.png')";
    }

    function chngBgImgPopIptal(aa) {

        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popIptal_1.png')";
    }

    function chngBgImgPopIptalO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popIptal.png')";
    }
</script>

             <asp:Button ID="btnHiddenD" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeDataPaket" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlDataP"
                 TargetControlID="btnHiddenD">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlDataP" CssClass="popupAgnt" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancelDP" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblDataPopupBaslik" runat="server" CssClass="hLabel" Text="Data Paketi Ekle "></asp:Label>    
<br /><asp:Label ID="lblDataPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    


<div style="margin-left:20px;">
        <asp:GridView ID="grdDataPaket" runat="server" CellPadding="2" ClientIDMode="Predictable"  
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="#cccccc" CssClass="grid" 
        Font-Size="11px" Font-Names="Verdana" AllowPaging="True" PageSize="20"
        AllowSorting="True" ShowHeader="false" RowStyle-CssClass="popGridRow">
            
            <PagerSettings PageButtonCount="6" Position="TopAndBottom" />

            <AlternatingRowStyle BackColor="#fdfdfd"/>
        
        <Columns>
        
        <asp:BoundField DataField="dataExcelID" />
        <asp:BoundField DataField="dataPaket" ItemStyle-Width="240px" />
        
        <asp:BoundField DataField="CreateDate" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        <asp:BoundField DataField="numOfRec" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        

       <%--4--%>
               <asp:TemplateField>

               <ItemStyle CssClass="ortala" />
               <ItemTemplate>
               
               <asp:CheckBox ID="chkDataSec" ClientIDMode="Predictable" runat="server"/>
               
               </ItemTemplate>
         </asp:TemplateField> 
          
         <asp:BoundField DataField="aciklama" />

        </Columns>
        </asp:GridView>
</div>        
      </div>  
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnDataSec"
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />
       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnDataIptal" 
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
       
          

       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdDataPaket" EventName="PageIndexChanging" />

</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>
