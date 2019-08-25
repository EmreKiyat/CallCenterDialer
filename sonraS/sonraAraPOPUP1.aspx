<%@ Page Title="" Language="VB" MasterPageFile="~/Master/tt.master" AutoEventWireup="false" CodeFile="sonraAraPOPUP1.aspx.vb" Inherits="sonraSIL_sonraAraPOPUP1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMainPart" Runat="Server">

<style>
.testButon
{
 width:124px;
 height:48px;
 background-image:url('../images/btn1.png');  
 margin:10px;
 border-width:0px;
 background-color:transparent;
 
}

</style>

<script type="text/jscript">
    function chngBgImg() {

        //document.getElementById("btnSattim").setAttribute("class", "testButonMO");
        document.getElementById("btnSattim").style.backgroundImage = "url('../images/btn1_1.png')"
    }

    function chngBgImgO() {

        document.getElementById("btnSattim").style.backgroundImage = "url('../images/btn1.png')"
    }

</script>

<div style=" width:50%">
<div style="font-family:Verdana; font-size:11px; float:left; margin-right:4em; height:13em" >
        <ul style="list-style-type:none; line-height:30px">
        <li>
            <asp:RadioButton ID="rd1Gun" GroupName="aa" runat="server" />
             1 Gün sonra</li>
        <li>
            <asp:RadioButton ID="rd2Gun" GroupName="aa" runat="server" /> 2 Gün sonra</li>
        <li>
            <asp:RadioButton ID="rdXGun" GroupName="aa" runat="server" />
            <asp:TextBox CssClass="txt2" ID="txtXGun" Width="40px" runat="server"></asp:TextBox> Gün sonra</li>
        <li>
            
            <asp:RadioButton ID="rdTarihSaat" GroupName="aa" runat="server" />
                    <asp:TextBox ID="txtTarih" CssClass="txt2" Width="66px"  runat="server"></asp:TextBox>
        <cc1:CalendarExtender ID="calBasla" runat="server" TargetControlID="txtTarih">
        </cc1:CalendarExtender>
        <asp:TextBox ID="txtZaman"  Width="40px" CssClass="txt2" runat="server"></asp:TextBox> Tarih ve Saatinde
         <cc1:MaskedEditExtender runat="server" MaskType="Time" Mask="99:99" ErrorTooltipEnabled="true" MessageValidatorTip="true" TargetControlID="txtZaman"></cc1:MaskedEditExtender>   
            </li>
        </ul>
        <br />
        
</div>
<div style="font-family:Verdana; font-size:11px; float:left; height:13em; padding-top:4.6em;">

Not:
<br />
    <asp:TextBox ID="txtAcikla" CssClass="txtMultiLine" MaxLength="500" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
       <div style="clear:both; float:right; text-align:center; margin-right:15px;">
        <asp:Button runat="server" Text="Tamam" CssClass="buttonTamam" ID="btnSonraTamam" />
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnSonraIptal" />
       
       <asp:Button runat="server" Text="İptal" CssClass="testButon" ClientIDMode="Static"  ID="btnSattim" onmouseover="chngBgImg()" onmouseout="chngBgImgO()" />
           
       <%--<img src="cooltext495439856.png" onmouseover="this.src='cooltext495439856MouseOver.png';" onmouseout="this.src='cooltext495439856.png';" />--%>

       </div> 

</div>
</asp:Content>



