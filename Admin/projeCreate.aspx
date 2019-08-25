<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="projeCreate.aspx.vb" Inherits="Admin_projeCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">



<script language="javascript" type="text/javascript" >

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
        document.getElementById(aa).style.backgroundImage = "url('../images/btnKaydet_1.png')";
    }

    function chngBgImgO(aa) {
        document.getElementById(aa).style.backgroundImage = "url('../images/btnKaydet.png')";
    }


    function chkChanged() { 
        //var chk=document.getElementById(
        alert(this);
    }
</script>

    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="650px">
    <cc1:TabPanel runat="server" ID="pnlProje">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Yeni Proje Tanımı"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>

           <fieldset class="reqKutular2" style="width:60%; height:100px;">
           <legend class="legandStyle"><asp:Label ID="lblProjeTanim" runat="server"  Text="Proje Tanım"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="updForChk">
      <ContentTemplate>
          <div style="margin-left:20px; float:left; width:98%">
            <div class="solCL" style="margin:3px; margin-left:16px;">
              <asp:Label ID="lblProjeAdi" runat="server" Text="Proje Adı:" Width="90px"></asp:Label>
              <asp:TextBox ID="txtProjeAdi" runat="server" Width="260px"></asp:TextBox>
            </div >  
            <div class="solCL" style="margin:3px; margin-left:16px;">
              <asp:Label ID="lblProjeAciklama" runat="server" Text="Proje Açıklaması:" Width="90px"></asp:Label>
              <asp:TextBox ID="txtProjeAciklama" runat="server" RenderMode="Inline" TextMode="MultiLine" Width="260px" Height="30px"></asp:TextBox>
            </div>

          </div>
     </ContentTemplate>
     </asp:UpdatePanel>
     </fieldset>


                <fieldset class="reqKutularSag" style="width:34%; height:100px;">
           <legend class="legandStyle"><asp:Label ID="Label4" runat="server"  Text="Agent Assist"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel5">
      <ContentTemplate>
          <div style="margin-left:8px; margin-right:4px; float:left; width:94%; font-size:10px; color:#787878">
            <div class="ekleButon" style="margin-bottom:8px;">
                    <asp:ImageButton ID="btnAssist" ImageUrl="../images/plus2.png" runat="server" /></div>

            <table>
                <tr>
                    <td style="width:40%">
                        <asp:Label ID="lblGiris" ClientIDMode="Static" runat="server" Text="Giriş"></asp:Label></td>
                    <td style="width:6%"><asp:Label ID="lblGirisOk" ClientIDMode="Static" runat="server" Text="x"></asp:Label></td>
                    <td style="width:2%"></td>
                    <td style="width:40%"><asp:Label ID="lblKeys" ClientIDMode="Static" runat="server" Text="Key Points"></asp:Label></td>
                    <td style="width:6%"><asp:Label ID="lblKeysOk" ClientIDMode="Static" runat="server" Text="x"></asp:Label></td>

                </tr>

                <tr>
                    <td><asp:Label ID="lblPaket" runat="server" ClientIDMode="Static" Text="Satış Paketleri"></asp:Label></td>
                    <td><asp:Label ID="lblPaketOk" runat="server" ClientIDMode="Static" Text="x"></asp:Label></td>
                    <td></td>
                    <td ><asp:Label ID="lblKapa" runat="server" ClientIDMode="Static" Text="Kapaniş"></asp:Label></td>
                    <td><asp:Label ID="lblKapaOk" runat="server" ClientIDMode="Static" Text="x"></asp:Label></td>

                </tr>



            </table>


          </div> 
    </ContentTemplate>
       </asp:UpdatePanel> 
</fieldset> 
        

<div style="width:47%" class="sol">
     <fieldset class="reqKutular2" style="width:100%; height:170px;">
        <legend class="legandStyle"><asp:Label ID="lblSatisPAket" runat="server"  Text="Proje Satış Paketleri"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel1">
      
      <ContentTemplate>
      
          <div style="margin-left:4px; margin-right:6px; float:left; width:98%">

                   <div class="ekleButon">
                    <asp:ImageButton ID="btnSatisPaketEkle" ImageUrl="../images/plus2.png" runat="server" /></div>
           

           <div style="margin-left:10px; height:140px; overflow:auto;">

                               <asp:GridView ID="grdSatisPaket" runat="server" ClientIDMode="Static" CssClass="gridProjCreate"
                    AutoGenerateColumns="false" BorderStyle="None" ShowHeader="false"  >
                    <EmptyDataTemplate>
                    
                        <div style="margin:30px; margin-top:30px; font-size:11px; font-style:italic;">
                            <asp:Label ID="Label3" runat="server" Text="Projeye şimdi Satış Paketi ekleyebilirsiniz ya da daha sonra <b>Proje İzleme</b> ekranından satış paketi eklemeniz mümkün."></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="popGridRow"/>
                    <AlternatingRowStyle BackColor="#fdfdfd"/>

            <Columns>
                <asp:BoundField DataField="paketAdi" ItemStyle-Width="38%" />
                <asp:BoundField DataField="paketAciklama" ItemStyle-Width="30%" ItemStyle-Wrap="true"  />
        
                <asp:BoundField DataField="birimFiyat" ItemStyle-Width="12%" ItemStyle-CssClass="ortala" />
                <asp:BoundField DataField="toplamFiyat" ItemStyle-Width="12%" ItemStyle-CssClass="ortala" />
                <asp:BoundField DataField="yenilemePeriod" ItemStyle-Width="6%" ItemStyle-CssClass="ortala" />
            </Columns>
                    </asp:GridView> 

       


           </div> 

          </div>
     </ContentTemplate>
     
     </asp:UpdatePanel>
     </fieldset>





     <fieldset class="reqKutular2" style="width:100%; height:170px;">
        <legend class="legandStyle"><asp:Label ID="Label1" runat="server"  Text="Proje Data Paketleri"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel2">
      
      <ContentTemplate>
      
          <div style="margin-left:28px; margin-right:8px; float:left; width:90%">

                          <div class="ekleButon">
                    <asp:ImageButton ID="btnDataPaketEkle" ImageUrl="../images/plus2.png" runat="server" /></div>
           
           <div style="height:140px; overflow:auto;">

               <asp:GridView ID="grdDataProje" runat="server" ClientIDMode="Static" CssClass="gridProjCreate"
                    AutoGenerateColumns="false" BorderStyle="None" ShowHeader="false"  >
                    <EmptyDataTemplate>
                    
                        <div style="margin:30px; margin-top:30px; font-size:11px; font-style:italic;">
                            <asp:Label ID="Label3" runat="server" Text="Projeye şimdi Data Paketi ekleyebilirsiniz ya da daha sonra <b>Proje İzleme</b> ekranından data paketi eklemeniz mümkün."></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="popGridRow"/>
                    <AlternatingRowStyle BackColor="#fdfdfd"/>

                    <Columns>
                    
                    <asp:BoundField DataField="dataExcelID" />
                    <asp:BoundField DataField="dataPaket" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="CreateDate" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="numOfRec" ItemStyle-Width="70px"  ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="aciklama" />

                    
                    
                    </Columns>


                    </asp:GridView> 

           </div> 

          </div>
     </ContentTemplate>
     
     </asp:UpdatePanel>
     </fieldset>


          <fieldset class="reqKutular2" style="width:100%; height:150px;">
        <legend class="legandStyle"><asp:Label ID="Label12" runat="server"  Text="Satış Bilgisi Alanları"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel8">
      
      <ContentTemplate>
      
          <div style="margin-left:28px; margin-right:8px; float:left; width:90%">

                          <div class="ekleButon">
                    <asp:ImageButton ID="btnSatisFieldEkle" ImageUrl="../images/plus2.png" runat="server" /></div>
           
           <div>

                        <asp:GridView ID="grdSatisFields" runat="server" ClientIDMode="Static" CssClass="gridProjCreate"
                    AutoGenerateColumns="false" BorderStyle="None" ShowHeader="false"  >
                    <EmptyDataTemplate>
                    
                        <div style="margin:30px; margin-top:30px; font-size:11px; font-style:italic;">
                            <asp:Label ID="Label3" runat="server" Text="Satış sırasında agentin müşteriden alacağı bilgi alanlarını tanımlayın."></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="popGridRow"/>
                    <AlternatingRowStyle BackColor="#fdfdfd"/>

                    <Columns>
                    
                   
                    <asp:BoundField DataField="fieldAd" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="isSifre" ItemStyle-HorizontalAlign="Center" />
                  
                    <asp:BoundField DataField="isSilAfterSale" />

                    
                    
                    </Columns>


                    </asp:GridView> 
      
           </div> 
           </div> 
    
     </ContentTemplate>
     </asp:UpdatePanel> 
     </fieldset> 


</div>

<div class="sag" style="width:47%; margin-right:23px;">

          <fieldset class="reqKutular2" style="width:100%; height:460px;">
        <legend class="legandStyle"><asp:Label ID="Label2" runat="server"  Text="Proje Ekibi"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel3">
      
      <ContentTemplate>
      
          <div style="margin-left:28px; margin-right:8px; float:left; width:90%">

                <div class="ekleButon">
                    <asp:ImageButton ID="btnAgentEkle" ImageUrl="../images/plus2.png" runat="server" /></div>
           
           <div>
                    <asp:GridView ID="grdAgntProje" runat="server" ClientIDMode="Static" CssClass="gridProjCreate"
                    AutoGenerateColumns="false" BorderStyle="None" ShowHeader="false"  >
                    <EmptyDataTemplate>
                    
                        <div style="margin:30px; margin-top:50px; font-size:11px; font-style:italic;">
                            <asp:Label ID="Label3" runat="server" Text="Projeye şimdi Agent ekleyebilirsiniz ya da daha sonra <b>Proje İzleme</b> ekranından agent eklemeniz mümkün."></asp:Label>
                            <br /><br />
                            <asp:Label ID="Label5" runat="server" Text="Bu alanda proje sorumlusu ve kontroller seçimi de yapabilirsiniz."></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="popGridRow"/>
                    

                    <Columns>
        
                    <asp:BoundField DataField="agentID" />
                    <asp:BoundField HeaderText="Agent" DataField="adSoyad" ItemStyle-Width="130px" />
                    <asp:BoundField DataField="roleID" />
                    <asp:BoundField HeaderText="Role" DataField="role" ItemStyle-Width="70px"  ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField HeaderText="Home Agent" DataField="isHomeAgent" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />

                      </Columns>
                    </asp:GridView>

           </div>

          </div>
     </ContentTemplate>
     
     </asp:UpdatePanel>
     </fieldset>    


            <div class="sol" style="clear:left;font-size:11px;color:#343434;margin-top:12px;">

           <asp:RadioButtonList ID="chkSelfController" runat="server" AutoPostBack="true" ToolTip="Projede bir kontroler yoksa, satışın kesinleşmesi durumunda, Agent kendi satışının onayını ya da iptalini kendisi yapar, bunun için Agent Kontroller seçeneğini, diğer durumda ise Proje Kontroller seçeneğini seçiniz." RepeatDirection="Horizontal">
           <asp:ListItem Text="Agent Controller" Value="1"></asp:ListItem>
           <asp:ListItem Text="Proje Controller" Value="0"></asp:ListItem>
           </asp:RadioButtonList>
       </div> 
     <div class="sag" style="clear:right">
            <asp:Button ID="btnKaydet" runat="server" CssClass="kaydetButonlar kaydetButonlarBg" 
            ClientIDMode="Static"  onmouseover="chngBgImg('btnKaydet')" onmouseout="chngBgImgO('btnKaydet')"
            Text="Kaydet" />
     </div>
    

</div>
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
</div>


<%--Agent Seçim POPUP'ı--%>

             <asp:Button ID="btnHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeAgnt" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="Panel1"
                 TargetControlID="btnHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="Panel1" CssClass="popupAgnt" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
        <div style="margin:12px"><img src="../images/agntGreen.png" />
<asp:Label ID="lblSubsPopupBaslik" runat="server" CssClass="hLabel" Text="Agent Ekle "></asp:Label>    
</div><br />    


<div style="margin-left:20px;">
        <asp:GridView ID="grdAgentForProje" runat="server" CellPadding="2" ClientIDMode="Predictable"  
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="#cccccc" CssClass="grid" 
        Font-Size="11px" Font-Names="Verdana" AllowPaging="True" PageSize="20"
        AllowSorting="True" ShowHeader="false" RowStyle-CssClass="popGridRow">
            
            <PagerSettings PageButtonCount="6" Position="TopAndBottom" />


        
        <Columns>
        
        <asp:BoundField DataField="agentID" />
        <asp:BoundField DataField="adSoyad" ItemStyle-Width="130px" />
        <asp:BoundField DataField="CreateDate" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />

<%--<asp:BoundField DataField="roleID" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"  />--%>

         
        
<asp:BoundField DataField="isHomeAgent" />

<asp:BoundField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" />

  
       
               <asp:TemplateField>

               <ItemStyle CssClass="ortala" />
               <ItemTemplate>
               
               <asp:CheckBox ID="chkAgentSec" ClientIDMode="Predictable" runat="server"/>
               
               </ItemTemplate>
         </asp:TemplateField> 
          <asp:BoundField DataField="numOfProje" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30px" />      

              <%--rol seçim combosu için--%>
    <asp:TemplateField>
    <ItemStyle HorizontalAlign="Center"  />
    <ItemTemplate>
    
        <asp:DropDownList ID="cmbRoleSecim" runat="server" Font-Size="11px" >
            <asp:ListItem  Text="Agent" Selected="True" Value="1"></asp:ListItem>
            <asp:ListItem Text="Kontroller" Value="2" ></asp:ListItem>
            <asp:ListItem Text="Proje Sorumlusu" Value="3"></asp:ListItem>

        </asp:DropDownList>
    </ItemTemplate>
    
    </asp:TemplateField> 

        </Columns>
        </asp:GridView>
</div>        
      </div>  
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptalBg popButonIptal sag" ID="btnAgentIptal"
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
        
        <asp:Button runat="server" Text="Tamam" CssClass="popButonTamamBg popButonTamam sag" ID="btnAgentSec"
        onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />
       


       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdAgentForProje" EventName="PageIndexChanging" />

</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>

    <uc1:assist runat="server" ID="ascxAssist"/>
    <uc1:uyari runat="server" ID="ascxUyari" />
<%--    <uc1:dataPaket runat="server" ID="ascxDataPaket" />--%>


<%--Data PAket Seçim Popup--%>

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
    
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancelDP" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblDataPopupBaslik" runat="server" CssClass="hLabel" Text="Data Paketi Ekle "></asp:Label>    
<br /><asp:Label ID="lblDataPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    


<div style="margin-left:20px; overflow:scroll;  height :280px">
        <asp:GridView ID="grdDataPaket" runat="server" CellPadding="2" ClientIDMode="Predictable"  
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="#cccccc" CssClass="grid" 
        Font-Size="11px" Font-Names="Verdana" 
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

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnDataIptal" 
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnDataSec"
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdDataPaket" EventName="PageIndexChanging" />

</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>



    <%--Proje Paketi Ekleme Olayı--%>

    
                 <asp:Button ID="btnHiddenPP" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeSatisPaket" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlSatisPaket"
                 TargetControlID="btnHiddenPP">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlSatisPaket" CssClass="popupPaket" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancelPrPaket" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblProjePaketPopupBaslik" runat="server" CssClass="hLabel" Text="Proje Paketi Ekle "></asp:Label>    



<div style="margin-left:10px; height:230px; overflow:auto;">
        <asp:GridView ID="grdForProjePaket" runat="server" CellPadding="2" ClientIDMode="Static" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="#cccccc" CssClass="grid" 
        Font-Size="11px" Font-Names="Verdana"
        ShowHeader="false" RowStyle-CssClass="popGridRow">
      

            <AlternatingRowStyle BackColor="#fdfdfd"/>
        
        <Columns>
        
        <asp:BoundField DataField="paketAdi" ItemStyle-Width="140px" />
        <asp:BoundField DataField="paketAciklama" ItemStyle-Width="140px" ItemStyle-Wrap="true"  />
        
        <asp:BoundField DataField="birimFiyat" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        <asp:BoundField DataField="toplamFiyat" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        <asp:BoundField DataField="yenilemePeriod" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        <asp:CommandField ShowDeleteButton="true"  />
<%--
               <asp:TemplateField>

               <ItemStyle CssClass="ortala" />
               <ItemTemplate>
               
                   <asp:Button ID="btnSil" runat="server" Text="Sil" ClientIDMode="Predictable"  />
               </ItemTemplate>
         </asp:TemplateField> --%>
          
    

        </Columns>
        </asp:GridView>
</div> 

<hr style="color:#dfdfdf; border:1px solid" />
<table>
    <tbody style="font-size:10px; font-family:Verdana; color:#455534; margin-left:14px;">
    <tr>
      <td><asp:Label ID="Label6" runat="server" CssClass="vAllgnBottom" Height="25px" Text="Paket Adı"></asp:Label><br /><asp:TextBox ID="txtPaketAdi" CssClass="txtPop" Width="100px" runat="server"></asp:TextBox></td>
      <td><asp:Label ID="Label7" runat="server" Height="25px" Text="Açıklama"></asp:Label><br /><asp:TextBox ID="txtAciklama" CssClass="txtPop" Width="170px" runat="server"></asp:TextBox></td>

      <td><asp:Label ID="Label8" runat="server" Height="25px" Text="Birim Fiyat"></asp:Label><br /><asp:TextBox CssClass="txtPop textRight" ID="txtBirimFiyat" Width="40px" runat="server"></asp:TextBox></td>
      <td><asp:Label ID="Label9" runat="server" Height="25px" Text="Toplam Fiyat"></asp:Label><br /><asp:TextBox ID="txtToplamFiyat" CssClass="txtPop textRight" Width="40px" runat="server"></asp:TextBox></td>
      <td><asp:Label ID="Label11" runat="server" Height="25px" Text="Yenileme Period(ay)"></asp:Label><br /><asp:TextBox ID="txtYenileme" CssClass="txtPop textRight" Width="40px" runat="server"></asp:TextBox></td>

      <td><asp:Label ID="Label10" runat="server" Height="15px" Text=" "></asp:Label><asp:Button ID="btnPaketEkle" runat="server" Text="Ekle" /></td> 
    </tr>
  </tbody>


</table>
  <hr style="color:#dfdfdf;border:1px solid" />
      </div>  
       
       <div style="font-size:10px; font-family:Verdana; color:#455534; margin-top:17px; margin-left:14px; float:left; clear:left;">
       
           <asp:RadioButtonList ID="radioParaBirimi" runat="server" RepeatDirection="Horizontal" CellPadding="10">
            <asp:ListItem Text="€" Value="€"></asp:ListItem>
            <asp:ListItem Text="TL" Value="TL"></asp:ListItem>
            <asp:ListItem Text="$" Value="$"></asp:ListItem>
           </asp:RadioButtonList>
           <asp:Label ID="lblParaBirimUyari" runat="server" Text="Para Birimi Giriniz." ForeColor="#ff3333" Visible="false" ></asp:Label>

       </div>
       


       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnIptalPrPaket" 
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnTamamPrPaket"
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdForProjePaket" EventName="PageIndexChanging" />
<asp:AsyncPostBackTrigger ControlID="btnPaketEkle" EventName="Click" />

</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>




        <%--Satış Fields Ekleme Olayı--%>

    
                 <asp:Button ID="btnHiddenFields" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeFields" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlFields"
                 TargetControlID="btnHiddenFields">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlFields" CssClass="popupPaket" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnKapaFields" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="Label13" runat="server" CssClass="hLabel" Text="Satış Bilgi Alanı Ekle"></asp:Label>    



<div style="margin-left:10px; margin-top:22px; height:230px; overflow:auto;">

<table>
    
<thead>
    <tr style="font-size:10px; font-family:Verdana; color:#222; margin-left:14px;">
        <th></th>
        <th>Alan Adı</th>
        <th>Şifrelenecek mi?</th>
        <th>Satış Sonrası silinsin mi?</th>
    </tr>
</thead>
<tbody style="font-size:10px; font-family:Verdana; color:#455534; margin-left:14px; text-align:center;">

    <tr>
      <td>1</td>  
      <td><asp:TextBox ID="txtFieldAd1" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>
      <td><asp:CheckBox ID="chkFieldSifre1" runat="server"  AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter1" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal1" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>2</td>  
      <td><asp:TextBox ID="txtFieldAd2" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>

      <td><asp:CheckBox ID="chkFieldSifre2" runat="server"  AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter2" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal2" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>3</td>  
      <td><asp:TextBox ID="txtFieldAd3" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>
 
      <td><asp:CheckBox ID="chkFieldSifre3" runat="server"  AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter3" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal3" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>4</td>  
      <td><asp:TextBox ID="txtFieldAd4" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>

      <td><asp:CheckBox ID="chkFieldSifre4" runat="server"  AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter4" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal4" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>5</td>  
      <td><asp:TextBox ID="txtFieldAd5" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>

      <td><asp:CheckBox ID="chkFieldSifre5" runat="server" AutoPostBack="true"  /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter5" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal5" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>6</td>  
      <td><asp:TextBox ID="txtFieldAd6" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>
     
      <td><asp:CheckBox ID="chkFieldSifre6" runat="server"  AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter6" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal6" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>

    <tr>
    <td>7</td>  
      <td><asp:TextBox ID="txtFieldAd7" CssClass="txtPop" Width="160px" runat="server" MaxLength="99"></asp:TextBox></td>
    <%--  <td><asp:RadioButton ID="radioField7" GroupName="isAc" runat="server" AutoPostBack="true" /></td>--%>
      <td><asp:CheckBox ID="chkFieldSifre7" runat="server" AutoPostBack="true" /></td>
      <td><asp:CheckBox ID="chkFieldSilAfter7" runat="server"  AutoPostBack="true" /></td>
      <td><asp:LinkButton ID="lnkIptal7" Text="iptal" runat="server"></asp:LinkButton></td>  
    </tr>




  </tbody>


</table>


</div> 

<div style= "margin-left:8px;float:left;clear:left">
        <asp:Label ID="lblFields" runat="server" ForeColor="Red" ></asp:Label>
 </div>

<div style= "margin:8px;float:left;clear:left">
        <asp:Label ID="Label14" runat="server" Text="* Bir Not(açıklama) alanı sistem tarafından otomatik olarak eklenecektir, bu tür bir alan tanımlamayınız." ></asp:Label>
 </div>

      </div>  
       

       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnFieldIptal" 
        onmouseover="chngBgImgPopIptal('btnFieldIptal')" onmouseout="chngBgImgPopIptalO('btnFieldIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnFieldTamam"
         onmouseover="chngBgImgPopTamam('btnFieldTamam')" onmouseout="chngBgImgPopTamamO('btnFieldTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   
        <Triggers>

<asp:AsyncPostBackTrigger ControlID="btnFieldTamam" EventName="Click" />



</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>



</asp:Content>

