<%@ Page Language="VB" AutoEventWireup="false" CodeFile="parolaDegis.aspx.vb" Inherits="parolaDegis" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="css/satis.css" rel="stylesheet" type="text/css" />
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

    //enter key kontrol-textboxlarda entere basarsa bişi yapma - emr
    function enterKeyPress(e) {
        if (window.event) { e = window.event; }
        if (e.keyCode == 13) {
            return false;
        }
    }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smMidPage" runat="server">
</asp:ScriptManager>

    <div>
     
        <div style="margin:200px; font-size:12px;  color:#343434; font-family:Verdana;">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
            <asp:Label ID="lblPassSonuc" runat="server" Text=""></asp:Label><br />
            <%--<asp:LinkButton ID="lnkSistemeDon" runat="server" Enabled="false">Devam etmek için...</asp:LinkButton>--%>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPasswordTamam" EventName="Click" />
            </Triggers>
</asp:UpdatePanel> 
        </div>
     

    </div>



    
        <%--  parola değiştirmek için --%>

             <asp:Button ID="btnPasswordHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpePassword" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlPassword"
                 TargetControlID="btnPasswordHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlPassword" CssClass="popupNotSold" runat="server" >
    
 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnPasswordCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="lblFromGorevList" runat="server" CssClass="hLabel">Parola Değişikliği...</asp:Label>  <br />    
<asp:Label ID="lblPassDegisecekKisi" runat="server" CssClass="hLabel"></asp:Label>

<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">

    <div class="satisUndefFieldAna" >

            
        <asp:Label ID="Label1" runat="server" Width="120px" Text="Yeni Parola:"></asp:Label><asp:TextBox ID="txtParola1" TextMode="Password" onkeydown="return enterKeyPress(event);" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Width="120px" Text="Yeni Parola(Tekrar):"></asp:Label><asp:TextBox ID="txtParola2" TextMode="Password" onkeydown="return enterKeyPress(event);" runat="server"></asp:TextBox>
            
    </div>
    <div>
        <asp:Label ID="lblStatus" runat="server" ForeColor=""></asp:Label>
    </div>

</div>        
      </div>  
       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnPasswordTamam"
         onmouseover="chngBgImgPopTamam('btnPasswordTamam')" onmouseout="chngBgImgPopTamamO('btnPasswordTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>

        
    </asp:UpdatePanel>

    </asp:Panel>



    </form>
</body>
</html>
