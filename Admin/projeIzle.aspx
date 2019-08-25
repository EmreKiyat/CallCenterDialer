<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="projeIzle.aspx.vb" Inherits="Admin_projeIzle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">
<script type="text/jscript">

    // bir süre disable buton

    function DisableControl(controlId) {
        document.getElementById(controlId).disabled = true;
    }
    function DisableControl_SetTimeout(controlId, interval) {
        setTimeout("DisableControl('" + controlId + "')", interval);
    }
    function birSureDisable(control) {
        //  control.value = "İşlem yapılıyor...";
        DisableControl_SetTimeout(control.id, 600);
        return true;

    }

    // *************************


</script>



    <div class="adminFirstDiv">
      <asp:UpdatePanel runat="server" ID="updProj">
      <ContentTemplate>

    <div class="sag" style="height:20px;">
        <asp:DropDownList ID="cmbProjeSecim" runat="server" CssClass="projeCombo" AutoPostBack="true" >

       </asp:DropDownList>
    </div>
    <div class="sag" style="padding-bottom:3px; margin-right:3px; font-size:10px;">
        <asp:RadioButton ID="radioActivePR" GroupName="aaw" Text="Active" Checked="true" runat="server" AutoPostBack="true" />
        <asp:RadioButton ID="radioTumPR" GroupName="aaw" Text="Tüm" runat="server" AutoPostBack="true"/>

<%--        <asp:RadioButtonList id="radioActiveOrTum" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                <asp:ListItem Text="Active Projeler" Selected="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="Tüm Projeler" Value="2"></asp:ListItem>
        </asp:RadioButtonList>--%>
    </div> 
    
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="600px" CssClass="gray">
    <cc1:TabPanel runat="server" ID="pnlProje">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Proje İzleme"></asp:Label>
    
</HeaderTemplate>
    


<ContentTemplate>
      <div style="padding:3px; width:100%;margin-left:6px;margin-top:16px;clear:left;float:left;">
      
      <div class="projeOzet">
        <div class="projeOzetHead">Toplam Data</div>
        <div class="projeOzetIn"><asp:Label ID="lblTum" runat="server"></asp:Label>


</div>
      </div>

      <div class="projeOzet">
        <div class="projeOzetHead">Toplam Arama</div>
        <div class="projeOzetIn"><asp:Label ID="lblArama" runat="server"></asp:Label>


</div>
      </div>


      <div class="projeOzet">
        <div class="projeOzetHead">Aktif Data</div>
        <div class="projeOzetIn"><asp:Label ID="lblNotProcessed" runat="server"></asp:Label>


</div>
      </div>

      <div class="projeOzet">
        <div class="projeOzetHead">Onaylı Satış</div>
        <div class="projeOzetIn"><asp:Label ID="lblSoldCommitted" runat="server"></asp:Label>


</div>
      </div>

      <div class="projeOzet" style="background-color:#f1fac0">
        <div class="projeOzetHead" style="background-color:#BCDD5A">Bugün Arama</div>
        <div class="projeOzetIn"><asp:Label ID="lblBuGunArama" runat="server"></asp:Label>


</div>
      </div>

      <div class="projeOzet" style="background-color:#f1fac0">
        <div class="projeOzetHead" style="background-color:#BCDD5A">Bugün Satış</div>
        <div class="projeOzetIn"><asp:Label ID="lblBuGunSatis" runat="server"></asp:Label>


</div>
      </div>


    <div style="float:right; margin-right:40px; font-size:11px;">
        
        <a href="../Rapor/satisDetayRapor.aspx" target="_blank" >Detay Satış Raporu</a>
        <a href="../Rapor/satisAgentRapor.aspx" target="_blank" >Agent Satış Raporu</a>
        
    </div>    

<div>
     <cc1:TabContainer ID="tabProjeOzet" runat="server" CssClass="gray solCL tabCon" 
              AutoPostBack="True" >
              
              <cc1:TabPanel runat="server" ID="tabExcel"><HeaderTemplate>
    <asp:Label ID="Label1" runat="server" Text="Data Paketleri"></asp:Label>
    
</HeaderTemplate>
<ContentTemplate>
               <div class="ekleButon" style="margin:4px;">
                    <asp:ImageButton ID="btnDataPaketEkle" ImageUrl="../images/plus2.png" runat="server" />



                </div>
                <div style="margin:6px;">
                 
                    <asp:GridView ID="grdExcel" runat="server" BorderStyle="None" CellSpacing="4" 
                        AutoGenerateColumns="False" ClientIDMode="Predictable">
<AlternatingRowStyle CssClass="gridRowAlt" />
<Columns>
<asp:BoundField DataField="dataExcelID"/>
<asp:BoundField DataField="isAktif"/>
<asp:BoundField DataField="isStarted"/>
<asp:BoundField DataField="dataPaket">
<ItemStyle Width="24em"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="createDate" HeaderText="Create">
<ItemStyle Width="7em"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="NumOfData" >    <%--5--%>
<ItemStyle HorizontalAlign="Right" Width="5em"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Satılan" >
<ItemStyle HorizontalAlign="Right" Width="5em"></ItemStyle>
</asp:BoundField>
<asp:BoundField HeaderText="Aktif" >
<ItemStyle HorizontalAlign="Right" Width="5em"></ItemStyle>
</asp:BoundField>
<asp:BoundField>
<ItemStyle HorizontalAlign="Right" Width="3em"></ItemStyle>
</asp:BoundField>
<asp:TemplateField><ItemTemplate>
                            <asp:Image ID="imgIsLive" ImageUrl="~/images/grid/dbGr.png" runat="server" />
                        
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowSelectButton="True" >
<controlstyle cssclass="buttonZ" width="50px"></controlstyle>
</asp:CommandField>


<asp:ButtonField CommandName="btnPaketDetay" Text="Detay" ButtonType="Image" ImageUrl="~/images/grid/detay.png"/>

<asp:BoundField Visible="false"  />     <%--12 : satılamayan--%>
<asp:BoundField Visible="false"  />
<asp:BoundField Visible="false"  />
<asp:BoundField Visible="false"  />
<asp:BoundField Visible="false"  />
<asp:BoundField Visible="false"  />
<asp:BoundField Visible="false"  />     <%--18:blackList--%>
<asp:BoundField Visible="false"  />     <%--19: onaysız satış--%>

<%--<asp:ButtonField CommandName="btnPaketDiger" Text="Diğer" ButtonType="Image" ImageUrl="~/images/grid/wizard.png"/>
--%>
</Columns>

<HeaderStyle Font-Bold="False" Font-Size="11px" />

<RowStyle CssClass="gridRow"/>
</asp:GridView>



                </div>

    
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" ID="tabAgent"><HeaderTemplate>
    <asp:Label ID="Label2" runat="server" Text="Proje Agentler"></asp:Label>
    
</HeaderTemplate>
<ContentTemplate>
                   <div class="ekleButon" style="margin:4px;">
                    <asp:ImageButton ID="btnAgentEkle" ImageUrl="../images/plus2.png" runat="server" />
                </div>
                <div style="margin:6px;">

                <asp:GridView ID="grdAgents" runat="server" BorderStyle="None" CellSpacing="4" AutoGenerateColumns="False" ClientIDMode="Predictable" ShowHeader="True">
                    <RowStyle CssClass="gridRow"/>
                    <HeaderStyle Font-Bold="False" Font-Size="11px" />
                    <%--<AlternatingRowStyle CssClass="gridRowAlt" />--%>



                    <Columns>
                        <asp:BoundField DataField="agentID" Visible="false"  />
                        <asp:BoundField DataField="isHomeAgent" Visible="false"  />
                      <asp:BoundField DataField="numOfProje" Visible="false"  />
                      <asp:BoundField DataField="isAktif" Visible="false"  />
                      <asp:BoundField DataField="roleID" Visible="false"  />
                      <asp:BoundField DataField="isAktifInFirm" Visible="false"  />
                      <asp:BoundField DataField="isDefault" Visible="false"  />

                      <asp:BoundField ItemStyle-Width="2em" />
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
                        
        
                <asp:ButtonField CommandName="btnFieldRolDegis" Text="Rol" ButtonType="Link" ControlStyle-CssClass="buttonZ" ControlStyle-Width="30px"/>
                <asp:ButtonField CommandName="btnFieldAgentCikarEkle" Text="Çıkar" ButtonType="Link" ControlStyle-CssClass="buttonZ" ControlStyle-Width="30px"/>

        

                    </Columns>
                    </asp:GridView>

                </div> 
    
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" ID="tabSatPaket"><HeaderTemplate>
    <asp:Label ID="Label3" runat="server" Text="Satış Paketleri"></asp:Label>
    
</HeaderTemplate>
<ContentTemplate>

    
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>

</div>




    </div>  
    
</ContentTemplate>
    


</cc1:TabPanel>
    </cc1:TabContainer>

    
    </ContentTemplate>
    
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="radioActivePR" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="radioTumPR" EventName="CheckedChanged" />
        <asp:AsyncPostBackTrigger ControlID="cmbProjeSecim" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="timerProjeIzle" EventName="Tick" />

    </Triggers>
    </asp:UpdatePanel>
    </div>







                 <asp:Button ID="btnHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeDataPaketiPasifYap" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlDataPaketiPasifYap" 
                 TargetControlID="btnHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlDataPaketiPasifYap" CssClass="popupA" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnDPCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:50px">
<asp:Label ID="lblSubsPopupBaslik" runat="server" CssClass="hLabel" Text="Data Paketi Pasife Al"></asp:Label>    


        
      </div>
      <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblPasifeAlinacakProje" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        Paket: <asp:Label ID="lblPasifeAlinacakPaket" runat="server" CssClass="lbl"></asp:Label>    
      </div>  
        <br />


        <ul>
        <li>Pasife alınan (durdurulan) bir data paketi daha sonra tekrar aktif hale getirilebilir.</li>
        <li>Agentlara atanmış ya da randevulandırılmış data kayıtlarının işlemi, paket pasife alınmış olsa da, devam eder. Bu sebeple işlem, satış vs. gibi sayılarda pasife alımdan sonra da değişiklikler olabilir.</li>
       </ul>
      

       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Paketi Durdur" CssClass="buttonTamam" ID="btnDataPaketPasifeAL" />
       
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnDataPaketIptal" />
       
           <asp:Label ID="lblExcelID" runat="server" Visible="false"></asp:Label>

       </div> 
       
   </ContentTemplate>
   
        <Triggers>


</Triggers>
        
    </asp:UpdatePanel>
        


    </asp:Panel>

<%--data paketi aktif yapmak--%>

                 <asp:Button ID="btnHidden2" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeDataPaketiAktifYap" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlDataPaketiAktifYap" 
                 TargetControlID="btnHidden2">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlDataPaketiAktifYap" CssClass="popupA" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnAktifCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:50px">
<asp:Label ID="Label4" runat="server" CssClass="hLabel" Text="Data Paketi Aktife Al"></asp:Label>    


        
      </div>
      <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblAktifeAlinacakProje" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        Paket: <asp:Label ID="lblAktifeAlinacakPaket" runat="server" CssClass="lbl"></asp:Label>    
      </div>  
        <br />


        <ul>
        <li>Aktif edilen data paketi, havuzdaki bu pakete ait henüz işleme alınmamış dataları agentlere dağıtmaya devam eder.</li>
        <li></li>
       </ul>
      

       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Paket Aktivate" CssClass="buttonTamam" ID="btnDataPaketActivate" />
       
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnAktifIptal" />
       
           <asp:Label ID="lblExcelIDA" runat="server" Visible="false"></asp:Label>

       </div> 
       
   </ContentTemplate>
   
        <Triggers>


</Triggers>
        
    </asp:UpdatePanel>
        


    </asp:Panel>



<%--data paketi proje için havuza taşı --%>

                 <asp:Button ID="btnHidden3" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeDataPaketHavuza" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlDataPaketHavuza" 
                 TargetControlID="btnHidden3">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlDataPaketHavuza" CssClass="popupA" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnHavuzCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:50px">
<asp:Label ID="Label5" runat="server" CssClass="hLabel" Text="Data Paketi Havuza Taşı ve Aktivate Et"></asp:Label>    


        
      </div>
      <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblHavuzaAlinacakProje" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        Paket: <asp:Label ID="lblHavuzaAlinacakPaket" runat="server" CssClass="lbl"></asp:Label>    
      </div>  
        <br />


        <ul>
        <li>Aktif edilen data paketi datalarını proje havuzuna taşır ve agentlere dağıtmaya başlar.</li>
        <li>Taşıma sırasında Black List kontrolü yapılır, black listteki datalar havuza taşınmaz.</li>
       </ul>
      

       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Paket Aktivate" CssClass="buttonTamam" 
        ID="btnDataPaketHavuza" />
       
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnHavuzIptal" />
       
           <asp:Label ID="lblExcelIDH" runat="server" Visible="false"></asp:Label>

       </div> 
       
   </ContentTemplate>
   
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDataPaketHavuza" EventName="Click" />

</Triggers>
        
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanel3" ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
            <div style="margin-left:120px;margin-bottom:10px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/yklnyr.gif" />
            </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
    


    </asp:Panel>




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


<div style="margin-left:20px; overflow:scroll; height:22em;">
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
       
              <asp:Button runat="server" Text="Paketleri Ekle" CssClass="popButonTamam popButonTamamBg sag" ID="btnDataSec"
             
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   
        <Triggers>


</Triggers>
        
    </asp:UpdatePanel>

    </asp:Panel>


<%--Agent Rol Değiştir  popup'ı--%>


             <asp:Button ID="btnHiddenRolDegis" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeRoleDegis" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlRoleDegis"
                 TargetControlID="btnHiddenRolDegis">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlRoleDegis" CssClass="popupAgnt" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnRoleDegisKapat" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="Label6" runat="server" CssClass="hLabel" Text="Çalışan Role Değişimi."></asp:Label>
<br /><asp:Label ID="lblAgentForRoleDegis" runat="server" CssClass="hLabel" Font-Size="12px"></asp:Label>

<div style="margin-left:20px; height:22em;">

      

            <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblProjeRolDegis" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        Çalışan: <asp:Label ID="lblAgentRolDegis" runat="server" CssClass="lbl"></asp:Label>    
      </div>  
        <br />



      
      <asp:DropDownList ID="cmbRoleSecim" Width="20em" runat="server" Font-Size="12px" >
            <asp:ListItem  Text="Agent" Selected="True" Value="1"></asp:ListItem>
            <asp:ListItem Text="Kontroller" Value="2" ></asp:ListItem>
            <asp:ListItem Text="Proje Sorumlusu" Value="3"></asp:ListItem>

      </asp:DropDownList>

</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnRoleDegisIptal" 
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Kaydet" CssClass="popButonTamam popButonTamamBg sag" ID="btnRoleDegisKaydet"
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   

        
    </asp:UpdatePanel>

    </asp:Panel>


    
<%--Agent ekle çıkar popup'ı--%>


             <asp:Button ID="btnAgentEkleCikarHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeAgentEkleCikarGrid" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlAgentEkleCikar"
                 TargetControlID="btnAgentEkleCikarHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlAgentEkleCikar" CssClass="popupAgnt" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnAgentEkleCikarPopupKapat" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="Label7" runat="server" CssClass="hLabel" Text="Çalışan Ekle-Çıkar."></asp:Label>
<br /><asp:Label ID="Label8" runat="server" CssClass="hLabel" Font-Size="12px"></asp:Label>

<div style="margin-left:20px; height:22em;">

      

            <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblAgentEkleCikarProje" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        Çalışan: <asp:Label ID="lblAgentEkleCikarAd" runat="server" CssClass="lbl"></asp:Label>    
        <br />
        İşlem: <asp:Label ID="lblAgentEkleCikarIslem" runat="server" CssClass="lbl"></asp:Label>  
      </div>  
        <br />



      


</div>        
      </div>  
       


       
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">

       
        <asp:Button runat="server" Text="İptal" CssClass="popButonIptal popButonIptalBg sag"  ID="btnAgentEkelCikarPopupIptal" 
        onmouseover="chngBgImgPopIptal('btnDataIptal')" onmouseout="chngBgImgPopIptalO('btnDataIptal')" ClientIDMode="Static" />
       
              <asp:Button runat="server" Text="Kaydet" CssClass="popButonTamam popButonTamamBg sag" ID="btnAgentEkelCikarPopupKaydet"
         onmouseover="chngBgImgPopTamam('btnDataSec')" onmouseout="chngBgImgPopTamamO('btnDataSec')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   

        
    </asp:UpdatePanel>

    </asp:Panel>


    <%--Paket Detay Popup--%>


             <asp:Button ID="btnPaketDetayHidden" runat="server" Visible="true" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpePaketDetay" runat="server" 
                 BackgroundCssClass="modalBackground"
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="pnlPaketDetay"
                 TargetControlID="btnPaketDetayHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="pnlPaketDetay" CssClass="popupAgntForPaketDetay" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnPaketDetayCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="Label10" runat="server" CssClass="hLabel" Text="Data Paket Detay Bilgileri."></asp:Label>


<div style="margin-left:20px; height:22em;">

      

            <br />
      <div style="margin-left:20px; margin-bottom:20px;">
        Proje: <asp:Label ID="lblExcelIDForPAketDetayPopup" runat="server" CssClass="lbl"></asp:Label>
        <asp:Label Font-Bold="true" ForeColor="blue" ID="lblPaketDetayProjeAdi" runat="server" CssClass="lbl"></asp:Label>    
        <hr />
        <br />
        <table>
        <tr>
            <td>Paketteki toplam </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataAdet" runat="server" ></asp:Label></td>
        </tr>
        
        <tr>
            <td>Havuzdaki toplam </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataHavuzAdet" runat="server" ></asp:Label></td>
        </tr>
        
        <tr>
            <td>İşleme Alınan</td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataIslemeAlinan" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>Kalan (Aktif) </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataAktif" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>Toplam Satış </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataToplamSatis" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>Onaylı satış </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataOnayliSatis" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td>Henüz onaylanmamış satış </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataOnaysizSatis" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Randevuda </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataRandevuda" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Satılamayan </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataSatilamadi" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Ulaşılamayan </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataUlasilamayan" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Ulaşılamayan (2 defa geldi) </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataUlasilamayanComplated" runat="server" ></asp:Label></td>
        </tr>
<tr>
            <td>Ulaşılamayan (tekrar gelecek) </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataUlasilamayanNotComp" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Eksik-Hatalı Tel </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataEksikHata" runat="server" ></asp:Label></td>
        </tr>



        <tr>
            <td>Ekranlarda bekleyen </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataKapak" runat="server" ></asp:Label></td>
        </tr>

        <tr>
            <td>Black Liste atılan </td>
            <td>:</td>
            <td><asp:Label ID="lblPaketDataBlackList" runat="server" ></asp:Label></td>
        </tr>
        
        </table>

        <div style="float:left; clear:left; margin-top:10px;">
            
            <asp:Button ID="btnActivateUlasilamayan" CssClass="btnUlasilamayan" runat="server" Text="Ulaşılamayanlar tekrar gelsin" 
             />
            <asp:Button ID="btnDeActivateUlasilamayan" CssClass="btnUlasilamayan" runat="server" Text="Ulaşılamayanlar tekrar gelmesin" 
             />
        </div>

      </div>  
        <br />



      


</div>        
      </div>  
       

       
       <div style="clear:right; float:right; text-align:center; margin-top:10px; margin-right:15px;">

       
   
              <asp:Button runat="server" Text="Tamam" CssClass="popButonTamam popButonTamamBg sag" ID="btnPaketDetayTamam"
         onmouseover="chngBgImgPopTamam('btnPaketDetayTamam')" onmouseout="chngBgImgPopTamamO('btnPaketDetayTamam')" ClientIDMode="Static" />    

       </div> 
       
   </ContentTemplate>
   

        
    </asp:UpdatePanel>

    </asp:Panel>




    <%--Agent Seçim POPUP'ı--%>

             <asp:Button ID="btnHiddenAgntPop" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpeAgnt" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="Panel1"
                 TargetControlID="btnHiddenAgntPop">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="Panel1" CssClass="popupAgnt" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
        <div style="margin:12px"><img alt="Agent" src="../images/agntGreen.png" />
<asp:Label ID="Label9" runat="server" CssClass="hLabel" Text="Agent Ekle "></asp:Label>    
</div><br />    


<div style="margin-left:20px;overflow:auto; height:250px">
        <asp:GridView ID="grdAgentForProje" runat="server" CellPadding="2" ClientIDMode="Predictable"  
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="#cccccc" CssClass="grid" 
        Font-Size="11px" Font-Names="Verdana"
        AllowSorting="True" ShowHeader="false" RowStyle-CssClass="popGridRow">
            
  

        
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


    <uc1:uyari ID="ascxUyari" runat="server" />


    <asp:Timer ID="timerProjeIzle" OnTick="timerProjeIzle_Tick" Interval="150000" runat="server" ></asp:Timer>
</asp:Content>

