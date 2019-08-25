<%@ Page Title="" Language="VB" MasterPageFile="~/Master/tt.master" AutoEventWireup="false" CodeFile="kontroller.aspx.vb" Inherits="agnt_kontroller" %>

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
           <div style="margin-left:28px; margin-right:8px;">
                                      <asp:Label ID="lblTerminTarih" runat="server" 
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

    <div class="tabConainerList">
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            CssClass="gray">
<cc1:TabPanel ID="TabPanel1" runat="server" >
<HeaderTemplate>
<label style="font-size:14px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#555;">Agent Satış</label>
</HeaderTemplate>
<ContentTemplate>       

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

        <div class="tabContList" >
           <div style="font-size:11px; color:#444;"> 
            <asp:CheckBox ID="chkKontAuto" Checked="true" AutoPostBack="true" Text="Otomatik Yükle" runat="server" /><span style="text-align:right; float:right;">
            
                <asp:ImageButton ID="btnLobListeYenile" AlternateText="Yenile" ToolTip="Listeyi Yenile" ImageUrl="~/images/btn/refresh.png" runat="server" />
            </span>
           </div> 

       <div style="float:left;clear:left;margin:2px; margin-top:10px; border:1px solid #dddddd">
    
        <asp:GridView ID="grdKontrollerList" runat="server" CellPadding="2" ClientIDMode="Predictable" ShowHeader="false" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
         >
            
           
        <RowStyle CssClass="gridRow" />
        <AlternatingRowStyle CssClass="gridRowA"/>        
        <Columns>

        <asp:BoundField DataField="havuzID" Visible="false" />
        <asp:BoundField DataField="agentID"  ItemStyle-Width="250px"/>
        <asp:BoundField DataField="dataID" ItemStyle-Width="80px"/>
        <asp:BoundField DataField="adSoyad" ItemStyle-Width="100px" />
        <asp:BoundField DataField="rDate" ItemStyle-Width="100px" />
        <asp:BoundField DataField="terminTarih" ItemStyle-Width="20px" />
        <asp:BoundField DataField="kontrollerID" Visible="false" />
        <asp:CommandField SelectText="Seç" ButtonType="Link" ShowSelectButton="true" ControlStyle-CssClass="buttonZ" />            
    
        </Columns>
        </asp:GridView>

    </div>


        </div>

</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="timerSatisList" EventName="Tick" />
  <%--  <asp:AsyncPostBackTrigger ControlID="btnGeriGonder" EventName="Click" />--%>
    

</Triggers>
</asp:UpdatePanel>
</ContentTemplate>
</cc1:TabPanel>  

</cc1:TabContainer> 
</div> 

     <div class="tabConainerCont"> <div style="float:right;">
         <asp:LinkButton ID="lnkSerbestBirak" runat="server">Kaydı Serbest Bırak</asp:LinkButton></div>
    <cc1:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
            CssClass="gray">
            
<cc1:TabPanel ID="tabMusteri1" runat="server" >
<HeaderTemplate>
<label style="font-size:14px; font-family:Verdana @Arial Unicode MS; padding:4px; color:#555;">Müşteri Bilgileri</label>
</HeaderTemplate>

<ContentTemplate>       

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
       <div id="canvasOrtu" runat="server" class="canvasOrtu" visible="false" >Agent satış listesinden seçim yapın ya da <i>Otomatik Yükleme</i>'yi işaretleyin!</div>
        <div class="tabMusteri" >
        
        <div class="sol" style="width:85%;margin-top:12px;">

            <asp:Label ID="lblBayBayan" runat="server" CssClass="txt disabled" Width="2em" ></asp:Label>

            <asp:Label ID="lblAdSoyad" CssClass="txt disabled" Width="20em" runat="server"></asp:Label>

            <asp:Label ID="lblTelNo" runat="server" ClientIDMode="Static" CssClass="txt disabled sag"></asp:Label>
            <asp:TextBox ID="txtTelNoHeaderEkle" ClientIDMode="Static"  Width="27px" CssClass="txt sag"  Font-Size="13px" runat="server"></asp:TextBox>
           
        </div>
        <div class="sag">
                        <asp:Button ID="btnAra" CssClass="agentButonlarAra agentButonlarBgAra sag" runat="server" Text="Ara" 
                ClientIDMode="Static"  onmouseover="chngBgImgAra('btnAra')" onmouseout="chngBgImgAraO('btnAra')"
                 />
        </div>
            <div style="float:left; clear:both; margin-left:4em; margin-top:.6em">
                <asp:ImageButton ID="btnAdSoy1" ImageUrl="../images/1.png" runat="server" 
                     />
                <asp:ImageButton ID="btnAdSoy2" ImageUrl="../images/2.png" runat="server" 
                    />
                <asp:ImageButton ID="btnAdSoy3" ImageUrl="../images/3.png" runat="server" 
                    />


                <asp:ImageButton ID="btnAdSoyEkleDuzelt" ToolTip="Müşteri Ekle - Düzelt" 
                    style="margin-left:2em" ImageUrl="../images/user.png" runat="server" 
                   />
           
            </div>
            <div style="float:right; margin-right:10em; margin-top:.6em">
            <asp:ImageButton ID="btnTel1" ImageUrl="../images/1.png" runat="server" />
            <asp:ImageButton ID="btnTel2" ImageUrl="../images/2.png" runat="server" />
            <asp:ImageButton ID="btnTel3" ImageUrl="../images/3.png" runat="server" />
            <asp:ImageButton ID="btnTelEkleDuzelt" ToolTip="Tel No Ekle - Düzelt" 
                    style="margin-left:2em" ImageUrl="../images/phone.png" runat="server" 
                     />
            
            </div>
            <br />
           <div style="clear:both; background-color:#fefefe; color:#777; border-bottom:solid 1px #ddd; height:1.3em;text-align:right; padding-right:8px;">
               <asp:Label ID="lblRecNo" runat="server" Font-Size="11px" Text="23445"></asp:Label>
           </div>
           
<div style="background-color:#fffff1; width:100%;">

     <fieldset class="reqAdresKont">

                    <legend class="legandStyleAdresKont">
                        <asp:Label ID="Label1" runat="server" 
                            Text="Bilgiler"></asp:Label>
                    </legend>
                    <div style="margin-left:14px; margin-right:8px; font-size:11px; color:#434343">
                        Adres 1:<%--<asp:Label ID="lblAdres1" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtAdres1" MaxLength="120" Width="200px" runat="server"></asp:TextBox>
                        <br />
                        
                        Adres 2 + PostaKod:<%--<asp:Label ID="lblAdres2PlusPostaKod" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtAdres2PlusPostaKod" MaxLength="120" Width="200px" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtPostaKod" MaxLength="10" Width="60px" runat="server"></asp:TextBox>
                        <br />
                        Şehir:<%--<asp:Label ID="lblSehir" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtSehir" Width="200px" MaxLength="20" runat="server"></asp:TextBox>
                        <br /><br />
                        e-Posta: <%--<asp:Label ID="lblEMail" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtEMail" Width="200px" MaxLength="250" runat="server"></asp:TextBox>
                        Teslim Kişi: <%--<asp:Label ID="lblEMail" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtTeslimKisi" Width="200px" MaxLength="100" runat="server"></asp:TextBox>
Teslim Tel: <%--<asp:Label ID="lblEMail" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtTeslimTel" Width="200px" MaxLength="40" runat="server"></asp:TextBox>

                    </div>
           </fieldset>  



           <fieldset class="reqAdresKont">
              <legend class="legandStyleAdresKont"><asp:Label ID="Label4" runat="server"  
                   Text="Satış Datası" ></asp:Label></legend>
           <div style="margin-left:14px; margin-right:4px; overflow:auto;">

           <div id="divF1" runat="server" class="divF">
                    <asp:Label ID="lblCF1" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF1" Width="175px" runat="server"></asp:TextBox>
              <asp:Image ID="imgCFSifre1" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
              <asp:Image ID="imgCFSil1" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

           </div><div id="divF2" runat="server" class="divF">
                    <asp:Label ID="lblCF2" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF2" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre2" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil2" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div><div id="divF3" runat="server" class="divF">
                    <asp:Label ID="lblCF3" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF3" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre3" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil3" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div><div id="divF4" runat="server" class="divF">
                    <asp:Label ID="lblCF4" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF4" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre4" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil4" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div><div id="divF5" runat="server" class="divF">
                    <asp:Label ID="lblCF5" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF5" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre5" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil5" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div><div id="divF6" runat="server" class="divF">
                    <asp:Label ID="lblCF6" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF6" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre6" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil6" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div><div id="divF7" runat="server" class="divF">
                    <asp:Label ID="lblCF7" runat="server" Text=""></asp:Label><br />
                    <asp:TextBox ID="txtCF7" Width="175px" runat="server"></asp:TextBox>
                    <asp:Image ID="imgCFSifre7" AlternateText="Şifreli Alan" ToolTip="Bu alan sistemde şifreli olarak tutulacaktır." ImageUrl="~/images/sell/Key3s.png" runat="server" />
                    <asp:Image ID="imgCFSil7" AlternateText="Satış sonrası silinecek alan" ToolTip="Bu alan sistemlerimizde kayıtlı tutulmayacaktır." ImageUrl="~/images/sell/Trash3s.png" runat="server" />

            </div>


           </div> 
           </fieldset> 

           <fieldset class="reqAdresKont" style="width:36%">
                           <legend class="legandStyleAdresKont"><asp:Label ID="Label6" runat="server"  
                   Text="Kontroller" ></asp:Label></legend>
           <div style="margin-left:12px; margin-right:5px">
                
                <div style="width:100%;height:270px; overflow:auto;">
        
                    <asp:GridView Width="95%" ID="grdSatisPaket" runat="server" CellPadding="2" ClientIDMode="Predictable" 
                        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana">
                       
                        <RowStyle CssClass="grdRowStyle"  />
                        <AlternatingRowStyle CssClass="grdARowStyle"  />        
                        <Columns>
        
                        <asp:BoundField DataField="projePaketID" Visible="false" />
                        <asp:BoundField DataField="paketAdi"  ItemStyle-Width="250px" />
                        <asp:BoundField DataField="paketBirimFiyat" Visible="false" />
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
                        <br />
                     <div style=" font-size:14px; float:right;clear:right; margin:4px;">
                    <asp:Label ID="lblSatisToplamLab" runat="server" Text="Toplam: "></asp:Label><asp:Label ID="lblSatisToplam"
                        runat="server"></asp:Label>
                    </div>

                    
                </div>

           
                <div style="width:95%; vertical-align:bottom;">
                    <asp:Button ID="btnSatisOnay" runat="server" Width="100" Height="36" Text="Onay"   />
                    <asp:Button ID="btnGeriGonder" runat="server" Width="100" Height="36" Text="Geri Gönder"  />
                
                </div>
           </div> 
           </fieldset> 
</div> 
           <div style="background-color:#fffff1; width:100%;">


<%--12345678--%>
                <fieldset class="reqAdres">
                           <legend class="legandStyleAdres"><asp:Label ID="Label3" runat="server"  
                   Text="Satış İşlem" ></asp:Label></legend>
           <div style="margin-left:14px; margin-right:6px; overflow:auto; color:#333333">
               <div class="solCL" style="margin-top:12px;font-size:11px;">
               <asp:Label ID="Label7" runat="server" Text="Agent:"></asp:Label><asp:Label ID="lblSatanAgent" runat="server" Text=""></asp:Label>
               <asp:Image ID="imgIsHome" ImageUrl="../images/home.png" Visible="false"  runat="server" />
               </div>
               <div class="solCL" style="margin-top:10px; font-size:11px;">
                <asp:Label ID="Label8" runat="server" Text="Satış İşlemi:"></asp:Label><asp:Label ID="lblSatisSaat" ForeColor="Blue" runat="server"></asp:Label>
            </div>
            <div class="solCL" style="margin-top:12px; height:200px; overflow:auto ">
            
                <asp:Label ID="Label9" runat="server" Text="Satış Not:"></asp:Label><asp:Label ID="lblSatisNot" runat="server" Text=""></asp:Label>
                <br />
                <asp:Repeater ID="rptNotlar" runat="server">
                <ItemTemplate>
                    
                    <div class="noteRpt">
                        <label id="Label10" style="color:Blue; font-size:10px;"><%# DataBinder.Eval(Container.DataItem, "rDate")%></label>
                        <label id="lblUni1" style="color:green; font-size:10px;"><%# DataBinder.Eval(Container.DataItem, "adSoyad")%></label>
                        <br />
                        <label id="Label11" ><%# DataBinder.Eval(Container.DataItem, "note")%></label>
                    </div>
                </ItemTemplate>
                </asp:Repeater>
             </div>


           </div> 
           </fieldset> 



                <fieldset class="reqAdres">

                    <legend class="legandStyleAdres">
                        <asp:Label ID="Label5" runat="server"
                            Text="Diğer"></asp:Label>
                    </legend>
                    <div style="margin-left:28px; margin-right:8px;">
                        <asp:Label ID="lblH1" runat="server">:</asp:Label><asp:Label ID="lblf1" runat="server"></asp:Label><br />
                        <asp:Label ID="lblH2" runat="server">:</asp:Label><asp:Label ID="lblf2" runat="server"></asp:Label><br />
                        <asp:Label ID="lblH3" runat="server">:</asp:Label><asp:Label ID="lblf3" runat="server"></asp:Label><br />
                        <asp:Label ID="lblH4" runat="server">:</asp:Label><asp:Label ID="lblf4" runat="server"></asp:Label><br />
                        <asp:Label ID="lblH5" runat="server">:</asp:Label><asp:Label ID="lblf5" runat="server"></asp:Label><br />
                        <asp:Label ID="lblH6" runat="server">:</asp:Label><asp:Label ID="lblf6" runat="server"></asp:Label>

                    </div>
            </fieldset>

                <fieldset class="reqAdres" style="width:36%">
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




        </div> 



</ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy1" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy2" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnAdSoy3" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel1" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel2" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnTel3" EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="btnGeriGonder" EventName="Click" />
</Triggers>
</asp:UpdatePanel> 

</ContentTemplate>


</cc1:TabPanel>
</cc1:TabContainer>


</div>
</div>


<%--   kontroller onay paneli--%>



             <asp:Button ID="btnKontOnayHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeSoldOnay" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlSoldOnay"
                 TargetControlID="btnKontOnayHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlSoldOnay" CssClass="popupNotSold" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnSoldOnayCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="Label12" runat="server" CssClass="hLabel" Text="Kontroller Satış Onayı..."></asp:Label>       


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      


    <div class="satisUndefFieldAna" id="div16" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="Label16" CssClass="y90" runat="server">Not:</asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtNotbyKont" CssClass="y80" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox></div>
    </div>



</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnSoldOnayIptal" 
        onmouseover="chngBgImgPopIptal('btnSoldOnayIptal')" onmouseout="chngBgImgPopIptalO('btnSoldOnayIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnSoldOnayTamam"
               
         onmouseover="chngBgImgPopTamam('btnSoldOnayTamam')" onmouseout="chngBgImgPopTamamO('btnSoldOnayTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>

        
    </asp:UpdatePanel>

    </asp:Panel>



    
<%--   kontroller agent'e geri gönderme paneli--%>

             <asp:Button ID="btnGeriGonderHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeGeriGonder" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlGeriGonder"
                 TargetControlID="btnGeriGonderHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlGeriGonder" CssClass="popupNotSold" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnGeriGonderCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="Label13" runat="server" CssClass="hLabel" Text="Agent'e geri gönder..."></asp:Label>       


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      


    <div class="satisUndefFieldAna" id="div1" runat="server" >
        <div class="satisUndefLabel"><asp:Label ID="Label14" CssClass="y90" runat="server">Not:</asp:Label></div>
        <div class="satisUndefText"><asp:TextBox ID="txtGeriGonderNot" CssClass="y80" runat="server" MaxLength="250" TextMode="MultiLine"></asp:TextBox></div>
    </div>



</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnGeriGonderIptal" 
        onmouseover="chngBgImgPopIptal('btnGeriGonderIptal')" onmouseout="chngBgImgPopIptalO('btnGeriGonderIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnGeriGonderTamam"
              
         onmouseover="chngBgImgPopTamam('btnGeriGonderTamam')" onmouseout="chngBgImgPopTamamO('btnGeriGonderTamam')" ClientIDMode="Static" />    

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
    
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnFromGorevListCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:240px">
<asp:Label ID="lblFromGorevList" runat="server" CssClass="hLabel"></asp:Label>       


<div style="margin-left:20px; margin-top:22px; overflow:auto;  height :420px">
      

    <div class="satisUndefFieldAna" >


                <asp:Repeater ID="rptNotlarPop" runat="server">
                <ItemTemplate>
                    
                    <div class="noteRpt">
                        <label id="Label10" style="color:Blue; font-size:10px;"><%# DataBinder.Eval(Container.DataItem, "rDate")%></label>
                        <label id="lblUni1" style="color:green; font-size:10px;"><%# DataBinder.Eval(Container.DataItem, "adSoyad")%></label>
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






    <uc1:uyari ID="ascxUyari" runat="server"  />


    <asp:Timer ID="timerSatisList" OnTick="timerSatisList_Tick" Interval="180000" runat="server" ></asp:Timer>


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

</asp:Content>

