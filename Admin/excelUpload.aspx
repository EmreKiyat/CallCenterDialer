<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="excelUpload.aspx.vb" Inherits="Admin_excelUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">

    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="750px">
    <cc1:TabPanel runat="server" ID="pnlProje">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Data Aktarım"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>

           <fieldset class="reqKutular2" style="width:98%; height:60px;">
           <legend class="legandStyle"><asp:Label ID="lblProjeTanim" runat="server"  Text="Data Dosyası Seç"></asp:Label></legend>
           

          <div style="margin-left:20px; float:left; padding:12px; width:98%">

            <asp:FileUpload ID="upFile" runat="server" Width="30em"/> 
              <asp:CheckBox ID="chkHeaderExist" Text="Data Başlangıç Satırı?" Checked="true" runat="server" />
            <asp:Button ID="btnAnalize" runat="server" Text="Test Data" />

          </div>
               

    </fieldset>

<asp:Label ID="lblUpload" runat="server" Text="" ForeColor="Red" ></asp:Label>


      <fieldset class="reqKutular2" style="width:98%; height:70px;">
           <legend class="legandStyle"><asp:Label ID="Label2" runat="server"  Text="Data Paket Bilgileri"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel2">
      <ContentTemplate>
          <div style="margin-left:20px; float:left; padding:10px; width:98%">

          <table>
            <tr>
                <td><asp:Label ID="lblW" runat="server" Text="Paket Adı"></asp:Label><br /><asp:TextBox ID="txtPaketAdi" Width="16em" MaxLength="200" runat="server"></asp:TextBox></td>
                <td></td>
                <td><asp:Label ID="Label3" runat="server" Text="Paket Açıklama"></asp:Label><br /><asp:TextBox ID="txtAciklama" MaxLength="400" runat="server" Width="18em"></asp:TextBox></td>
                <td></td>
                <td><asp:Label ID="Label5" runat="server" Text="Tel Ek"></asp:Label><br /><asp:TextBox ID="txtTelHeaderEk" MaxLength="6" runat="server" Width="3em"></asp:TextBox></td>
                <td></td>
                <td><asp:Button ID="btnKaydet" runat="server" Text="Data Kaydet" /></td>
                
            </tr>
          </table>


          </div>

    </ContentTemplate>
    </asp:UpdatePanel>


    </fieldset>

              <fieldset class="reqKutular2" style="width:98%; height:70px;">
           <legend class="legandStyle"><asp:Label ID="Label4" runat="server"  Text="Data Alanlarının belirlenmesi"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel3">
      <ContentTemplate>
          <div style="margin-left:6px; float:left; padding:8px; width:98%; height:340px; width:96%">

            
               <asp:DropDownList ID="cmbColumns" runat="server" Visible="false" AutoPostBack="true"  >

              </asp:DropDownList>
              <asp:RadioButton ID="radioDefinedField" Text="Tanımlı Alan" Visible="false"  GroupName="defOrUnDef" runat="server" AutoPostBack="true" />

              <asp:DropDownList ID="cmbDefFields" runat="server" Visible="false" >
                
                <asp:ListItem  Text="Telefon 1" Value="tel1"></asp:ListItem>
                <asp:ListItem  Text="Telefon 2" Value="tel2"></asp:ListItem>
                <asp:ListItem  Text="telefon 3" Value="tel3"></asp:ListItem>
                <asp:ListItem  Text="Hitap 1" Value="hitap1"></asp:ListItem>
                <asp:ListItem  Text="Adı" Value="ad1"></asp:ListItem>
                <asp:ListItem  Text="Soyadı" Value="soyad1"></asp:ListItem>
                <asp:ListItem  Text="Posta Kodu" Value="postaKod"></asp:ListItem>
                <asp:ListItem  Text="Şehir" Value="sehir"></asp:ListItem>
                <asp:ListItem  Text="Adres 1" Value="adres1"></asp:ListItem>
                <asp:ListItem  Text="Adres 2" Value="adres2"></asp:ListItem>
                <asp:ListItem  Text="e-Mail" Value="eMail"></asp:ListItem>
                <asp:ListItem  Text="Termin Tarih" Value="terminTarih"></asp:ListItem>
              </asp:DropDownList>

               <asp:RadioButton ID="radioUndefField" GroupName="defOrUnDef" Text="Tanımsız Alan" runat="server" Visible="false" AutoPostBack="true" />
              <asp:TextBox ID="txtUnDefField" MaxLength="20" Visible="false" runat="server"></asp:TextBox>
              <asp:RadioButton ID="radioExcludeField" GroupName="defOrUnDef" Text="Kayıt Dışı" runat="server" Visible="false" AutoPostBack="true" />

              <asp:Button ID="btnColHeaderEkle" runat="server" Visible="false"  Text="Ekle" />

          </div>
          
    </ContentTemplate>
    </asp:UpdatePanel>


    </fieldset>


      <fieldset class="reqKutular2" style="width:98%; height:400px;">
           <legend class="legandStyle"><asp:Label ID="Label1" runat="server"  Text="Data Alanları"></asp:Label></legend>
           
   <asp:UpdatePanel runat="server" ID="UpdatePanel1">
      <ContentTemplate>
          <div style="margin-left:6px; float:left; padding:8px; width:98%; overflow:scroll; height:340px; width:96%">

            <asp:GridView ID="grdKayitlar" runat="server" >
            <HeaderStyle BackColor="#dddddd" ForeColor="#222222" Font-Bold="true" />
                </asp:GridView>


          </div>
          
    </ContentTemplate>
    </asp:UpdatePanel>


    </fieldset>



    </ContentTemplate>
    </cc1:TabPanel>
    </cc1:TabContainer>

    </div>

    <uc1:uyari ID="ascxUyari" runat="server" />

    <asp:Label ID="lblstrFileType" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="lblFL" runat="server" Text="" Visible="false"></asp:Label>


        <%--working bildirimi --%>

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

