<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lgn2.aspx.vb" Inherits="lgn2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="lgn" runat="server" >

 <script type="text/javascript" language="javascript">



     function msgTemizle() {

         document.getElementById('<%= lblMsg.ClientID %>').innerHTML = '';

     }
     function verifyGiris() {
         var txtPosta = document.getElementById('<%= t1.ClientID %>');
         var txtPwd = document.getElementById('<%= t2.ClientID %>');
         var regex = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
         var regex2 = /;|(\-\-)|insert|update|\delete|drop |truncate|(\%27)|(\%3B)|shutdown|nowait|script/

         var s = true;

         if (!regex.test(txtPosta.value)) {
             document.getElementById('<%= lblMsg.ClientID %>').innerHTML = 'Uygun e-posta girmelisin.';
             txtPosta.focus();
             s = false;
         }

         if (regex2.test(txtPwd.value)) {
             document.getElementById('<%= lblMsg.ClientID %>').innerHTML = 'Uygun karakter ve ifadeler kullanmalısın.';
             s = false;
             txtPwd.focus();
         }

         if (s == true) document.getElementById('<%= lblMsg.ClientID %>').innerHTML = '';

         return s;


     }

</script>
    
<div style="width:950px;">


<%--ana boxxxxx--%>
<div>



<div class="baslik" style="font-size:1.2em; font-family:Verdana; color:#1161af; text-align:center;width:100%;margin-top:3em">telemarkt.net</div>

<div style="float:left; clear:both; text-align:center; width:100%;">
<div style="margin-top:20px; margin-left:auto;margin-right:auto; width:34%; font-size:11px; color:#434343; padding:8px; border:outset 1px #bbb; background-color:#fff">
<table cellpadding="0px" cellspacing="0px">
<tr>
<td><asp:Label ID="Label1" runat="server" CssClass="lblBn" Text="e-posta:"></asp:Label></td>
<td style="width:6px"></td>
<td><asp:Label ID="Label2" CssClass="lblBn" runat="server" Text="parola"></asp:Label></td>
</tr>
<tr>
<td><asp:TextBox ID="t1" CssClass="txtBn" runat="server" MaxLength="255"></asp:TextBox></td>
<td style="width:6px"></td>
<td><asp:TextBox ID="t2" CssClass="txtBn" TextMode="Password"  runat="server" MaxLength="20"></asp:TextBox></td>
</tr>
<tr>
<td colspan="3">
<asp:CheckBox ID="chkKuKi" runat="server" Text="Beni Tanı" />
<%--
<asp:LinkButton ID="lnkParolaUnut" CssClass="lnkUnut" runat="server">Parolamı unuttum</asp:LinkButton>--%>
<asp:Button ID="b1" runat="server" Text="Giriş" />
    
</td>
</tr>
<tr>
<td colspan="3">
    <div style="margin-top:2px; font-size:11px;">
            <asp:Label ID="lblMsg" EnableViewState="false"  runat="server"></asp:Label>
    </div>
</td>
</tr>
</table>
</div>
</div>






</div>
<%--ana boxxx sonu--%>    



</div>




</form>

</body>
</html>
