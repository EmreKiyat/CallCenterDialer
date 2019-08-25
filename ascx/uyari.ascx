<%@ Control Language="VB" AutoEventWireup="false" CodeFile="uyari.ascx.vb" Inherits="ascx_uyari" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/jscript">
    function chngBgImgPopTamamAA(aa) {

        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popTamam_1.png')";
    }

    function chngBgImgPopTamamAAO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btn/popTamam.png')";
    }


    </script>

             <asp:Button ID="btnHiddenU" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeUyari" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlUyar"
                 TargetControlID="btnHiddenU">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlUyar" CssClass="popupUyari" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancelU" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:200px">
        
    <div style="margin-left:30px; ">
        <asp:Image ID="imgUyari" AlternateText="Dikkat" ImageUrl="~/images/dur.png" runat="server" />
   </div>  
  
<div style="margin-left:20px; height:100px; padding:20px;">
<asp:Label ID="lblUyari" runat="server" Text=""></asp:Label>
</div>
 <div style="text-align:center;">
 
         <asp:Button runat="server" Text="Tamam" CssClass="popButonIptal popButonIptalBg"  ID="btnUTmm" 
        onmouseover="chngBgImgPopTamamAA('btnUTmm')" onmouseout="chngBgImgPopTamamAAO('btnUTmm')" ClientIDMode="Static" />


 </div>       
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
