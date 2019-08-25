<%@ Page Title="" Language="VB" MasterPageFile="~/Master/tt.master" AutoEventWireup="false" CodeFile="agentDef2.aspx.vb" Inherits="agnt_agentDef2"  %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<img alt="" src="../images/logo/tenha2.gif" />--%>
    <asp:Image ID="imgLogo" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMainPart" Runat="Server">
    
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


    function chngBgImg(aa) {

        //document.getElementById("btnSattim").setAttribute("class", "testButonMO");
        document.getElementById(aa).style.backgroundImage = "url('../images/btn1_1.png')";
    }

    function chngBgImgO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btn1.png')";
    }

    function chngBgImgRed(aa) {
    document.getElementById(aa).style.backgroundImage = "url('../images/btnRed_1.png')";
    }

    function chngBgImgRedO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnRed.png')";
    }

    function chngBgImgGrn(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnGrn_1.png')";
    }

    function chngBgImgGrnO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnGrn.png')";
    }

    function chngBgImgAra(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnAra_1.png')";
    }
    

    function runExe() {
        var aa = document.getElementById('lblTelNo').innerText;
        var ek = document.getElementById('txtTelNoHeaderEkle').value;
        var tel = ek + aa;
        window.clipboardData.setData('text', tel);
      var launcher = new ActiveXObject("WScript.Shell");

        launcher.Run("C:/eyeBeamJS/eyeBeam.exe -dial=" + tel);
        
    }  

    function chngBgImgAraO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnAra.png')";
    }


// bir süre disable buton

    function DisableControl(controlId) {
        document.getElementById(controlId).disabled = true;
    }
    function DisableControl_SetTimeout(controlId, interval) {
        setTimeout("DisableControl('" + controlId + "')", interval);
    }
    function birSureDisable(control) {
      //  control.value = "İşlem yapılıyor...";
        DisableControl_SetTimeout(control.id, 400);
    }

    // *************************

</script>

    
       <fieldset class="reqKutular">
           <legend class="legandStyle"><asp:Label ID="lblRole" runat="server"  Text="Agent" 
                  ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">
            
        
        <asp:Label ID="lblAgentAdSoyad" runat="server" 
                   ></asp:Label>
   
           </div>
       </fieldset>
       <fieldset class="reqKutular">
           <legend class="legandStyle">
               <asp:Label ID="lblSatis" runat="server">Termin</asp:Label>
           </legend>
           <div style="margin-left:28px; margin-right:8px; font-size:18px;" >
                    <asp:Label ID="lblTerminTarih" ForeColor="#ff4545" runat="server" 
                       ></asp:Label> 
                    
           </div>
           </fieldset>
      <fieldset class="reqKutular">
           <legend class="legandStyle">Proje</legend>
           <div style="margin-left:28px; margin-right:8px; vertical-align:text-top ;text-align:right;">
                   <div style="float:right; padding-right:10px;">
                       <asp:DropDownList ID="cmbProje" runat="server" Width="200px" AutoPostBack="true" >
                       
                       </asp:DropDownList>

                   </div>
        <%--<asp:Button ID="btnChangeProje" CssClass="btnA" runat="server" Text="Proje Seç" />--%>

           </div>
      </fieldset>
    
<div style="float:left; clear:both; margin:8px; width:98%">

    <div class="tabConainer">
    <div id="divYenilemeOrMemnuniyet" runat="server" visible="false" >
<div style="margin-right:16px; font-size:11px; color:#343434; float:right;" >


    <asp:CheckBox ID="chkYenileme" Text="Yenileme" AutoPostBack="true"  runat="server" />
    <asp:CheckBox ID="chkMemnuniyet" Text="Memnuniyet" AutoPostBack="true"  runat="server" />

<%--    <asp:RadioButtonList ID="radioYenilemeOrMemnuniyet" runat="server" RepeatDirection="Horizontal" CellSpacing="5" CellPadding="3" AutoPostBack="true" >
        <asp:ListItem>Yenileme</asp:ListItem>
        <asp:ListItem>Memnuniyet</asp:ListItem>
    </asp:RadioButtonList>--%>
</div><br />
</div>
    <cc1:TabContainer ID="tabContainerAgent" runat="server" ActiveTabIndex="0" AutoPostBack="true" CssClass="gray">
    
<cc1:TabPanel ID="tabMusteri1" runat="server">
<HeaderTemplate>
<label style="font-size:14px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#555;">Müşteri Bilgileri</label>
</HeaderTemplate>
<ContentTemplate>       

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>

        <div class="tabMusteri" >
        
        <div class="sol" style="width:85%;margin-top:12px;">

            <asp:Label ID="lblBayBayan" runat="server" CssClass="txt disabled" Width="2em" ></asp:Label>

            <asp:Label ID="lblAdSoyad" CssClass="txt disabled" Width="20em" runat="server"></asp:Label>

            <asp:Label ID="lblTelNo" runat="server" ClientIDMode="Static" CssClass="txt disabled sag"></asp:Label>
            <asp:TextBox ID="txtTelNoHeaderEkle" ClientIDMode="Static"  Width="27px" CssClass="txt sag" Font-Size="13px" Height="20px" runat="server"></asp:TextBox>
           
        </div>
        <div class="sag">
                        <asp:Button ID="btnAra" CssClass="agentButonlarAra agentButonlarBgAra sag" runat="server" Text="Ara" 
                ClientIDMode="Static"  onmouseover="chngBgImgAra('btnAra')" onmouseout="chngBgImgAraO('btnAra')"
                />
        </div>
            <div style="float:left; clear:both; margin-left:4em; margin-top:.6em">
                <asp:ImageButton ID="btnAdSoy1" ImageUrl="../images/1.png" runat="server" />
                <asp:ImageButton ID="btnAdSoy2" ImageUrl="../images/2.png" runat="server" />
                <asp:ImageButton ID="btnAdSoy3" ImageUrl="../images/3.png" runat="server" />


                <asp:ImageButton ID="btnAdSoyEkleDuzelt" ToolTip="Müşteri Ekle - Düzelt" 
                    style="margin-left:2em" ImageUrl="../images/user.png" runat="server" 
                    />
           
            </div>
            <div style="float:right; margin-right:10em; margin-top:.6em">
            <asp:ImageButton ID="btnTel1" ImageUrl="../images/1.png" runat="server" />
            <asp:ImageButton ID="btnTel2" ImageUrl="../images/2.png" runat="server" />
            <asp:ImageButton ID="btnTel3" ImageUrl="../images/3.png" runat="server" />
            <asp:ImageButton ID="btnTelEkleDuzelt" ToolTip="Tel No Ekle - Düzelt" 
                    style="margin-left:2em" ImageUrl="../images/phone.png" runat="server" />
            
            </div>
            <br />
           <div style="clear:both; background-color:#fefefe; color:#777; border-bottom:solid 1px #ddd; height:1.3em;text-align:right; padding-right:8px;">
               <asp:Label ID="lblRecNo" runat="server" Font-Size="11px" Text="23445"></asp:Label>
           </div>
           
           <div style="background-color:#fffff1; width:100%;">
                <fieldset class="reqAdres">

                    <legend class="legandStyleAdres">
                        <asp:Label ID="Label1" runat="server" 
                            Text="Bilgiler"></asp:Label>
                    </legend>
                    <div style="margin-left:28px; margin-right:8px;">
                        <asp:Label ID="Label15" Text="Adres:" runat="server"></asp:Label><br />
                        <asp:Label ID="lblAdres1" runat="server"></asp:Label><br />
                        <asp:Label ID="lblAdres2PlusPostaKod" runat="server"></asp:Label><asp:Label ID="lblPostaKod" runat="server"></asp:Label><br />
                        <br /><asp:Label ID="lblSehir" runat="server"></asp:Label>
                        <br /><hr style=" color:#efefef; height:1px;width:96%" />
                        <br /><br />
                        e-Posta: <asp:Label ID="lblEMail" runat="server"></asp:Label>

                    </div>
           </fieldset>  
           
                <fieldset class="reqAdres">

                    <legend class="legandStyleAdres">
                        <asp:Label ID="Label5" runat="server"
                            Text="Diğer"></asp:Label>
                    </legend>
                    <div style="margin-left:28px; margin-right:8px;">
                    <table>
                    <tr>
                    <td ><asp:Label ID="lblH1" CssClass="digerHead" runat="server"></asp:Label></td>
                    </tr><tr>
                    <td ><asp:Label ID="lblf1" runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblH2" CssClass="digerHead"  runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblf2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                    <td><asp:Label ID="lblH3" CssClass="digerHead"  runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblf3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                    <td><asp:Label ID="lblH4" CssClass="digerHead"  runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblf4" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                    <td> <asp:Label ID="lblH5" CssClass="digerHead"  runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblf5" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                    <td><asp:Label ID="lblH6" CssClass="digerHead"  runat="server"></asp:Label></td>
                    </tr><tr>
                    <td><asp:Label ID="lblf6" runat="server"></asp:Label></td>
                    </tr>
                    </table>


                    </div>
            </fieldset>

                <fieldset class="reqAdres" style="width:34%">
                           <legend class="legandStyleAdres"><asp:Label ID="Label2" runat="server"  
                   Text="Önceki Görüşmeler" ></asp:Label></legend>
           <div style="margin-left:14px; margin-right:6px; overflow:auto;">
               
               
               
               
        <asp:GridView ID="grdOncekiGorusmeler" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
        ShowHeader="false"  
        >
            
           
        <RowStyle CssClass="grdRowStyle" />
        <AlternatingRowStyle CssClass="grdARowStyle" />        
        <Columns>
        
        <asp:BoundField DataField="islemID"/>
        <asp:BoundField DataField="agentID" />
        <asp:BoundField DataField="globalID"/>
        <asp:BoundField DataField="tarih" ItemStyle-Width="100px" />
        <asp:BoundField DataField="islemTR" ItemStyle-Width="100px" />
            <asp:CommandField ButtonType="Link" ItemStyle-Width="40px" SelectText="Detay" ShowSelectButton="True" ControlStyle-Width="50px" />
        
       

          
        </Columns>
        </asp:GridView>
        

 

           </div>
           </fieldset>       
           </div>


           <div style="float:left;clear:left; background-color:#fff; width:100%; height:100%; margin-top:15px;">
                <fieldset class="reqAdres" >
                           <legend class="legandStyleAdres"><asp:Label ID="Label3" runat="server"  
                   Text="Mesajlar" ></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">
           
           
           </div>
           </fieldset>     

                <fieldset class="reqAdres" >
                           <legend class="legandStyleAdres"><asp:Label ID="Label4" runat="server"  
                   Text="Notlarım"></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">

           </div> 
           </fieldset> 


          <fieldset class="reqAdres" style="width:34%">
                           <legend class="legandStyleAdres"><asp:Label ID="Label6" runat="server"  
                   Text="RandevuS"></asp:Label></legend>
           <div style="margin-left:10px; margin-right:4px; overflow:auto; height:200px;">

                   <asp:GridView ID="grdRandevuS" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
        ShowHeader="false"  
        >
            
           
        <RowStyle CssClass="grdRowStyle" />
        <AlternatingRowStyle CssClass="grdARowStyle"  />        
        <Columns>
        
        <asp:BoundField DataField="havuzID"/>
        <asp:BoundField DataField="adSoyad" />
        <asp:BoundField DataField="termin"/>

          <%--  <asp:CommandField ButtonType="Link" ItemStyle-Width="40px" SelectText="ÖneAl" ShowSelectButton="True" ControlStyle-Width="50px" />
        --%>
       

          
        </Columns>
        </asp:GridView>

           </div> 
           </fieldset> 


            </div>

        </div> 



</ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy1" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy2" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy3" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel1" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel2" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel3" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnSattim" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnSatilmadi" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnSonraAra" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnUlasilamadi" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnYanlisEksikNo" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTekrarArama" EventName="Click" />

<%-- <asp:AsyncPostBackTrigger ControlID="chkYenileme" EventName="CheckedChanged" />
  <asp:AsyncPostBackTrigger ControlID="chkMemnuniyet" EventName="CheckedChanged" />--%>


 
 

</Triggers>
</asp:UpdatePanel> 

</ContentTemplate>

</cc1:TabPanel>


<cc1:TabPanel ID="tabSatis" runat="server" >
<HeaderTemplate>
<label style="font-size:14px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#555;">Satışlarım</label>
</HeaderTemplate>
<ContentTemplate>

       <asp:UpdatePanel ID="updSatislarim" runat="server" >
       <ContentTemplate>
        <div class="tabMusteri" >

        <div style="float:right;clear:right;font-size:16px;color:#434343;margin:6px;">
            <asp:Label ID="Label9" runat="server" Text="Satiş Adet: "></asp:Label>
            <asp:Label ID="lblSatislarimAdet" runat="server"></asp:Label>
        </div>
        <div style="float:left;clear:both;font-size:12px;color:#434343;margin:8px;margin-top:14px;">

      <asp:GridView ID="grdSatislarim" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="12px" Font-Names="Verdana">
            
           
        <RowStyle BackColor="Beige" ForeColor="#343434" />
        <AlternatingRowStyle BackColor="#ffffff" ForeColor="#434343" />
        <Columns>
        
        <asp:BoundField DataField="havuzID"/>
        <asp:BoundField DataField="dataID"/>

        <asp:BoundField HeaderText="Ad-Soyad" DataField="musAdSoyad" ItemStyle-Width="150px" />
        
        <asp:BoundField HeaderText="Satış Saat" DataField="rDate" ItemStyle-Width="150px" />
        <asp:BoundField DataField="islem" />
        
        <asp:BoundField HeaderText="Kontroller" DataField="adSoyad" ItemStyle-Width="150px" />
        <asp:BoundField HeaderText="Durum" />
  
      <asp:ButtonField CommandName="btnSatisSelfOnay" Text="Onay" ButtonType="Link" ControlStyle-CssClass="buttonZ" ControlStyle-Width="30px"/>
      <asp:ButtonField CommandName="btnSatisSelfIptal" Text="İptal" ButtonType="Link" ControlStyle-CssClass="buttonZ" ControlStyle-Width="30px"/>

        <asp:BoundField DataField="tel1" Visible="false" /> <%--9--%>
        <asp:BoundField HeaderText="Tel" />

        </Columns>
        </asp:GridView>
            
        </div> 
        </div> 
        </ContentTemplate>
        <Triggers>
        
                <asp:AsyncPostBackTrigger ControlID="tabContainerAgent" EventName="ActiveTabChanged" />
        </Triggers>
        
       </asp:UpdatePanel>

</ContentTemplate>
</cc1:TabPanel> 



<cc1:TabPanel ID="tabProjeSatis" runat="server" >
<HeaderTemplate>
<label style="font-size:14px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#555;">Proje Satışlar</label>
</HeaderTemplate>
<ContentTemplate>

       <asp:UpdatePanel ID="updProjeSatislar" runat="server" >
       <ContentTemplate>
        <div class="tabMusteri" >

        <div style="float:right;clear:right;font-size:16px;color:#434343;margin:6px;">
            <asp:Label ID="Label18" runat="server" Text="Proje Satiş Adet: "></asp:Label>
            <asp:Label ID="lblProjeSatisAdet" runat="server" Text="0"></asp:Label>
        </div>
        <div style="float:left;clear:both;font-size:12px;color:#434343;margin:8px;margin-top:14px;">




   
                <asp:GridView ID="grdAgents" runat="server" BorderStyle="None" CellSpacing="4" AutoGenerateColumns="False" ClientIDMode="Predictable" ShowHeader="True">
                    <RowStyle CssClass="gridRow"/>
                    <HeaderStyle Font-Bold="False" Font-Size="11px" />
                  <%--  <AlternatingRowStyle CssClass="gridRowAlt" />--%>

                    <Columns>
                        <asp:BoundField DataField="agentID" Visible="false"  />
                        <asp:BoundField DataField="isHomeAgent" Visible="false"  />
                      <asp:BoundField DataField="numOfProje" Visible="false"  />
                      <asp:BoundField DataField="isAktif" Visible="false"  />
                      <asp:BoundField DataField="roleID" Visible="false"  />
                      <asp:BoundField DataField="isAktifInFirm" Visible="false"  />
                      <asp:BoundField DataField="isDefault" Visible="false"  />

                      <asp:BoundField ItemStyle-Width="2em" />  <%--7--%>
                        <asp:BoundField DataField="adSoyad" ItemStyle-Width="24em" HeaderText="Ad-Soyad"/>
                        <asp:BoundField DataField="baslaTarih" ItemStyle-Width="7em" HeaderText="Başlangıç"/>
                        <asp:BoundField DataField="LastLoginDate" ItemStyle-Width="7em" HeaderText="Son Giriş"/>
                        <asp:BoundField DataField="toplamIslem" HeaderText="T.Arama" ItemStyle-Width="3em" ItemStyle-HorizontalAlign="Right"/> <%--arama (10) --%>
                        <asp:BoundField DataField="toplamSatis" HeaderText="T.Satış" ItemStyle-Width="3em" ItemStyle-HorizontalAlign="Right"/> <%--satış (11)--%>
                        <asp:BoundField DataField="bugunIslem" HeaderText="Bugün Ara" ItemStyle-Width="3em" ItemStyle-HorizontalAlign="Right"/> <%--bugün arama--%>
                        <asp:BoundField DataField="bugunSatis" HeaderText="Bugün Satış" ItemStyle-Width="3em" ItemStyle-HorizontalAlign="Right"/> <%--bugün satış--%>

                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="imgIsLiveAgnt" ClientIDMode="Predictable" ImageUrl="~/images/grid/user.png" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        

                    </Columns>
                    </asp:GridView>






        </div> 
        </div> 
        </ContentTemplate>
        <Triggers>
        
                <asp:AsyncPostBackTrigger ControlID="tabContainerAgent" EventName="ActiveTabChanged" />
        </Triggers>
        
       </asp:UpdatePanel>

</ContentTemplate>
</cc1:TabPanel> 










    </cc1:TabContainer>
    </div>
    
    <div style="width:16%; float:right;height:24px;">
    </div>
    <div class="actionContainer">
        
        <asp:Button ID="btnSattim" CssClass="agentButonlar agentButonlarBgGrn" runat="server" Text="Satildi"
            ClientIDMode="Static"  onmouseover="chngBgImgGrn('btnSattim')" onmouseout="chngBgImgGrnO('btnSattim')" />

<%--ön görüşme modülü için--%>
        <asp:Button ID="btnOnGorusme" Visible="false" CssClass="agentButonlar agentButonlarBgGrn" runat="server" Text="Olumlu Ön Görüşme"
            ClientIDMode="Static"  onmouseover="chngBgImgGrn('btnOnGorusme')" onmouseout="chngBgImgGrnO('btnOnGorusme')" />


        <asp:Button CssClass="agentButonlar agentButonlarBgGri" runat="server"  id="btnSatilmadi"  Text="Satilmadi"
            ClientIDMode="Static" onmouseover="chngBgImg('btnSatilmadi')" onmouseout="chngBgImgO('btnSatilmadi')" />
        <asp:Button ID="btnSonraAra" CssClass="agentButonlar agentButonlarBgGri" runat="server" 
            ClientIDMode="Static"  onmouseover="chngBgImg('btnSonraAra')" onmouseout="chngBgImgO('btnSonraAra')" Text="Randevu" />
        <asp:Button ID="btnUlasilamadi" CssClass="agentButonlar agentButonlarBgGri" runat="server" 
            ClientIDMode="Static"  onmouseover="chngBgImg('btnUlasilamadi')" onmouseout="chngBgImgO('btnUlasilamadi')"
            Text="Ulaşılamadı"/><br /><br />
        <asp:Button ID="btnYanlisEksikNo" CssClass="agentButonlar agentButonlarBgRed" runat="server" 
            ClientIDMode="Static"  onmouseover="chngBgImgRed('btnYanlisEksikNo')" onmouseout="chngBgImgRedO('btnYanlisEksikNo')"
            Text="Yanlış/Eksik Tel"/>
        <asp:Button ID="btnTekrarArama" CssClass="agentButonlar agentButonlarBgRed" runat="server" ToolTip="Numara Black List'e eklenir, datadan çıkarılır." 
            ClientIDMode="Static"  onmouseover="chngBgImgRed('btnTekrarArama')" onmouseout="chngBgImgRedO('btnTekrarArama')"
            Text="Tekrar Aranmasın"/>
            <%--TODO:tekrar aranmasın popupında yanlış no seçeneği olmalı--%>
    <hr />  
    </div>
    



</div>




             <asp:Button ID="btnHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeSonraAra" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="panelSonraAra" 
                 TargetControlID="btnHidden">
                 
             </cc1:ModalPopupExtender>
             

<asp:Panel runat="server"  ID="panelSonraAra" CssClass="popupSonraAra">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblSubsPopupBaslik" runat="server" CssClass="hLabel" Text="Daha Sonra Ara"></asp:Label>    
<br /><asp:Label ID="lblSubsPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    




<div style="font-family:Verdana; font-size:11px; float:left; margin-right:4em; height:13em" >
        <ul style="list-style-type:none; line-height:30px">
        <li>
            <asp:RadioButton ID="rd1Gun" GroupName="aa" runat="server" />
             1 Gün sonra</li>
        <li>
            <asp:RadioButton ID="rd2Gun" GroupName="aa" runat="server" /> 2 Gün sonra</li>
        <li>
            <asp:RadioButton ID="rdXGun" GroupName="aa" runat="server" AutoPostBack="True" />
            <asp:TextBox CssClass="txt2" ID="txtXGun" Width="40px" runat="server"></asp:TextBox> Gün sonra</li>
        <li>
            
            <asp:RadioButton ID="rdTarihSaat" GroupName="aa" runat="server"  AutoPostBack="True" />
                    <asp:TextBox ID="txtTarih" CssClass="txt2" Width="66px"  runat="server"></asp:TextBox>
        <cc1:CalendarExtender ID="calBasla" runat="server" TargetControlID="txtTarih">
        </cc1:CalendarExtender>
        <asp:TextBox ID="txtZaman"  Width="40px" CssClass="txt2" runat="server"></asp:TextBox> Tarih ve Saatinde
         <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Time" Mask="99:99" ErrorTooltipEnabled="true" MessageValidatorTip="true" TargetControlID="txtZaman"></cc1:MaskedEditExtender>   
            </li>
        </ul>
        <br />
        
</div>
<div style="font-family:Verdana; font-size:11px; float:left; clear:left; padding-top:1em; margin-left:4em;">

Not:
<br />
    <asp:TextBox ID="txtRandevuAcikla" CssClass="txtMultiLine" MaxLength="500" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<div style="clear:both; float:right; text-align:center; margin-right:2em; margin-top:1em;">


        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnRandevuIptal" 
        onmouseover="chngBgImgPopIptal('btnRandevuIptal')" onmouseout="chngBgImgPopIptalO('btnRandevuIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnRandevuTamam"
         onmouseover="chngBgImgPopTamam('btnRandevuTamam')" onmouseout="chngBgImgPopTamamO('btnRandevuTamam')" ClientIDMode="Static" />  
       
       </div> 

</div> 

</ContentTemplate>
</asp:UpdatePanel>


</asp:Panel>




<%--Satış Popup Paneli--%>

             <asp:Button ID="btnHiddenD" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeSatis" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlSatis"
                 TargetControlID="btnHiddenD">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlSatis" CssClass="popupSatis" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnSatisCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:480px">
<asp:Label ID="lblSatisPopupBaslik" runat="server" CssClass="hLabel" Text="Satış"></asp:Label>    
<br /><asp:Label ID="lblSatisPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    


<div style="margin-left:20px; margin-top:14px; overflow:auto;  height :440px">
      
     <div class="satisUndefFieldAna" id="div1" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF1" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF1" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
        
              <asp:Image ID="imgCFSifre1" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
              <asp:Image ID="imgCFSil1" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />
        
    </div>
    <div class="satisUndefFieldAna" id="div2" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF2" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF2" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
              <asp:Image ID="imgCFSifre2" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
              <asp:Image ID="imgCFSil2" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />

    </div>
    <div class="satisUndefFieldAna" id="div3" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF3" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF3" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
              <asp:Image ID="imgCFSifre3" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
              <asp:Image ID="imgCFSil3" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />

    </div>
    <div class="satisUndefFieldAna" id="div4" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF4" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF4" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
        <asp:Image ID="imgCFSifre4" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
        <asp:Image ID="imgCFSil4" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />

    </div>
    <div class="satisUndefFieldAna" id="div5" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF5" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF5" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
        <asp:Image ID="imgCFSifre5" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
        <asp:Image ID="imgCFSil5" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />
    </div>
    <div class="satisUndefFieldAna" id="div6" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF6" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF6" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
        <asp:Image ID="imgCFSifre6" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
        <asp:Image ID="imgCFSil6" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />

    </div>
    <div class="satisUndefFieldAna" id="div7" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblCF7" CssClass="y90" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtCF7" CssClass="y100" runat="server" MaxLength="100"></asp:TextBox></div>
        <asp:Image ID="imgCFSifre7" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3.png" runat="server" />
        <asp:Image ID="imgCFSil7" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3.png" runat="server" />

    </div>

    <%--*********sonradan eklenen adres alanları************--%>
    <div style="float:left; clear:left;border:1px solid #dddddd; background-color:#eeeeee; font-size:11px; color:#434343; width:96%" >
       <div style="margin-left:8px; padding:5px; margin-right:2px; margin-bottom:1px;" >
                        <asp:Label ID="lblAaa1" Text="Adres 1:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtAdres1" MaxLength="120" Width="300px" runat="server"></asp:TextBox>
                        <br />
                        
                        <asp:Label ID="lblasedasd" Text="Adres 2 + PostaKod:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtAdres2PlusPostaKod" MaxLength="120" Width="240px" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtPostaKod" MaxLength="10" Width="50px" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="lbltrewq" Text="Şehir:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtSehir" Width="300px" MaxLength="20" runat="server"></asp:TextBox>
                        <br /><br />
                        <asp:Label ID="lbljuytr" Text=" e-Posta:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtEMail" Width="300px" MaxLength="250" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label12" Text="Teslim Edilecek Kişi:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtTeslimKisi" Width="300px" MaxLength="100" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label13" Text="Teslim Telefon:" Width="160px" runat="server"></asp:Label>
                        <asp:TextBox ID="txtTeslimTel" Width="300px" MaxLength="40" runat="server"></asp:TextBox>
                        <br />

                    </div>
        </div>
    <%--*******************************--%>


    <div class="satisUndefFieldAna" id="div8" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="lblNot" Width="190px" runat="server"></asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtNot" CssClass="y100" Width="300px" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox></div>
    </div>

    <%--satış paket gridi--%>
    
    <div style="float:left;clear:left;margin:4px; margin-top:10px; border:1px solid #dddddd">
    
        <asp:GridView ID="grdSatisPaket" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
         >
            
           
        <RowStyle CssClass="grdRowStyle" />
        <AlternatingRowStyle CssClass="grdARowStyle"  />        
        <Columns>
        
        <asp:BoundField DataField="projePaketID" Visible="false" />
        <asp:BoundField DataField="paketAdi"  ItemStyle-Width="250px"/>
        <asp:BoundField DataField="paketBirimFiyat" ItemStyle-Width="80px"/>
        <asp:BoundField DataField="paketFiyat" ItemStyle-Width="100px" />
        <asp:BoundField DataField="paketParaBirimi" ItemStyle-Width="20px" />

    
        <asp:TemplateField>
        <HeaderTemplate>Adet</HeaderTemplate>
        <ItemTemplate>
              <asp:TextBox runat="server" Width="20px" ID="txtPaketSatisAdet" ClientIDMode="Predictable" Text="1"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
        <HeaderTemplate>Satış</HeaderTemplate>
        <ItemTemplate>
        <asp:CheckBox runat="server" ClientIDMode="Predictable" ID="chkSaledPaket">
            </asp:CheckBox>
        </ItemTemplate>
        </asp:TemplateField>
            
             <asp:BoundField DataField="yenilemePeriod" Visible="false" />
          
        </Columns>
        </asp:GridView>


    </div>
    <div style="float:right; clear:both; margin:6px;">
        <asp:Label ID="lblToplamUcret" CssClass="lblBuyuk" runat="server" ></asp:Label>
        <asp:Button ID="btnToplamUcret" runat="server" Text="Tutar" /></div>

</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnSatisIptal" 
        onmouseover="chngBgImgPopIptal('btnSatisIptal')" onmouseout="chngBgImgPopIptalO('btnSatisIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnSatisTamam"
              
         onmouseover="chngBgImgPopTamam('btnSatisTamam')" onmouseout="chngBgImgPopTamamO('btnSatisTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   
   <Triggers>
   <asp:AsyncPostBackTrigger ControlID="btnToplamUcret" EventName="Click" />
   </Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>


<%--    satılamadı paneli--%>



             <asp:Button ID="btnNotSoldHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeNotSold" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlNotSold"
                 TargetControlID="btnNotSoldHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlNotSold" CssClass="popupNotSold" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnNotSoldCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="Label7" runat="server" CssClass="hLabel" Text="Satilmadı..."></asp:Label>    
<br /><asp:Label ID="Label8" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      


    <div class="satisUndefFieldAna" id="div16" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="Label16" CssClass="y90" runat="server">Not:</asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtNotSold" CssClass="y80" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox></div>
    </div>



</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnNotSoldIptal" 
        onmouseover="chngBgImgPopIptal('btnNotSoldIptal')" onmouseout="chngBgImgPopIptalO('btnNotSoldIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnNotSoldTamam"
         onmouseover="chngBgImgPopTamam('btnNotSoldTamam')" onmouseout="chngBgImgPopTamamO('btnNotSoldTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>

        
    </asp:UpdatePanel>

    </asp:Panel>

    <%--  Görevden Geldi Uyarı - mesajları gösterme paneli --%>

             <asp:Button ID="btnFromGorevListHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeFromGorevList" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlFromGorevList"
                 TargetControlID="btnFromGorevListHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlFromGorevList" CssClass="popupNotSold" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnFromGorevListCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="lblFromGorevList" runat="server" CssClass="hLabel"></asp:Label>       


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      

    <div class="satisUndefFieldAna" >


                <asp:Repeater ID="rptNotlar" runat="server">
                <ItemTemplate>
                    
                    <div class="noteRpt2">
                        <label id="Label10" style="color:Blue;"><%# DataBinder.Eval(Container.DataItem, "rDate")%></label>
                        <label id="lblUni1" style="color:green;"><%# DataBinder.Eval(Container.DataItem, "adSoyad")%></label>
                        <br />
                        <label id="Label11" ><%# DataBinder.Eval(Container.DataItem, "note")%></label>
                    </div>
                </ItemTemplate>
                </asp:Repeater>



    </div>


</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnFromGorevListTamam"
         onmouseover="chngBgImgPopTamam('btnFromGorevListTamam')" onmouseout="chngBgImgPopTamamO('btnFromGorevListTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>

        
    </asp:UpdatePanel>

    </asp:Panel>










<%--    ön görüşüldü paneli--%>



             <asp:Button ID="btnOnGorHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeOnGor" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlOnGor"
                 TargetControlID="btnOnGorHidden">

             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlOnGor" CssClass="popupNotSold" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnOnGorCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="Label14" runat="server" CssClass="hLabel" Text="Olumlu Ön Görüşme..."></asp:Label>    


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      


    <div class="satisUndefFieldAna" id="div9" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="Label17" CssClass="y90" runat="server">Not:</asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtOnGorNote" CssClass="y80" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox></div>
    </div>



</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnOnGorIptal" 
        onmouseover="chngBgImgPopIptal('btnOnGorIptal')" onmouseout="chngBgImgPopIptalO('btnOnGorIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnOnGorTamam"
              
         onmouseover="chngBgImgPopTamam('btnOnGorTamam')" onmouseout="chngBgImgPopTamamO('btnOnGorTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>

        
    </asp:UpdatePanel>

    </asp:Panel>


            
   <uc1:uyari ID="uyariDataYok" runat="server" />          


    <%--working bildirimi --%>
<%--          <div id="pnlPopup" class="itIsWorkingDiv">
         <table>
            <tr>
                <td align="center" class="itIsWorkingLbl">
                Lütfen bekleyin...
                </td>
            </tr>
            <tr>
                <td class="itIsWorkingImg">
                    <img alt="" height="20" width="20" src="../images/ajax-loader.gif" />
                </td>
            </tr>
        </table>
    </div>--%>
               <div id="pnlPopup" style="display: none; border:solid 8px #c7C6C3; position:absolute; z-index:99;">
         <table>
            <tr>
                <td align="center" style="font-size:14px; padding:14px;">
                Lütfen bekleyiniz...
                </td>
            </tr>
            <tr>
                <td style="text-align:center; vertical-align:middle; padding:24px; padding-left:76px; padding-right:76px; margin:20px;">
                    <img alt="" height="20" width="20" 
                    src="../images/ajax-loader.gif" />
                </td>
            </tr>
        </table>
    </div>

     
     <script type="text/javascript">
         // page lock - working bildirimi için gerekli
         Sys.Application.add_load(applicationLoadHandler);
         Sys.Application.add_unload(applicationUnloadHandler);
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
         Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);


</script>
<%------------%> 
</asp:Content>

