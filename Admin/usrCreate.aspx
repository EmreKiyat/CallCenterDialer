<%@ Page Title="" Language="VB" MasterPageFile="~/Master/ttAdmin.master" AutoEventWireup="false" CodeFile="usrCreate.aspx.vb" Inherits="Admin_usrCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rightPart" Runat="Server">
    <div class="adminFirstDiv">
    <cc1:TabContainer ID="TabContainer1" runat="server" Height="500px">
    <cc1:TabPanel runat="server" ID="pnlCalisan">
    <HeaderTemplate>
        <asp:Label ID="lblUserCreate" runat="server" Text="Yeni Çalışan"></asp:Label>
    </HeaderTemplate>
    <ContentTemplate>

      
                 



<div style="float:right; width:24%; font-size:11px; color:#575757"">
                <asp:CheckBox ID="isHomeAgent" Text="Home Agent" runat="server"/>  
    </div>
   


          
       <fieldset class="reqKutular2" style="width:97%; height:19em">
           <legend class="legandStyle"><asp:Label ID="lblGenel" runat="server"  Text="Genel Bilgiler"></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">     
            
     <div style="margin:10px; float:left; clear:left; font-size:11px; color:#575757">      
     <div class="empCreateFormSutun1">
         <asp:Label ID="lblAdSoyad" runat="server" Text="Ad-Soyad: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtAdSoyad" runat="server" Width="14em"></asp:TextBox>
     </div>
     
          <div class="empCreateFormSutun2">
         <asp:Label ID="lblKimlikNo" runat="server" Text="TC Kimlik No: " Width="10em"></asp:Label>
         
         <asp:TextBox ID="txtKimlikNo" runat="server" Width="14em"></asp:TextBox>
     </div>

     <div class="empCreateFormSutun1">
         <asp:Label ID="lblCepTel" runat="server" Text="Cep Tel: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtCepTel" runat="server" Width="14em"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="Label2" runat="server" Text="Ev Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtEvTel" runat="server" Width="14em"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun1">
         <asp:Label ID="lblEMail" runat="server" Text="E-Mail: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtEMail" runat="server" Width="14em"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblDil" runat="server" Text="Dil" Width="10em"></asp:Label>
          <asp:DropDownList ID="cmbDil" runat="server" Width="14em">
            <asp:ListItem Text="Turkish" Value="tr-TR"></asp:ListItem>
            <asp:ListItem Text="Deutsch" Value="de-DE"></asp:ListItem>
            <asp:ListItem Text="English" Value="en_US"></asp:ListItem>
          </asp:DropDownList>


     </div>
     
     <div class="empCreateFormSutun1">
         <asp:Label ID="lblAdres" runat="server" Text="Adres: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtAdres" runat="server" Width="14em" Height="4em" TextMode="MultiLine"></asp:TextBox>
     </div>
     <div class="empCreateFormSutun2">
         <asp:Label ID="lblNot" runat="server" Text="Not: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtNot" runat="server" Width="14em" Height="4em" TextMode="MultiLine"></asp:TextBox>
     </div>     
     </div>    
     
           </div> 
     </fieldset>
         
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>
           <fieldset class="reqKutular" style="width:57%; height:12em">
           <legend class="legandStyle"><asp:Label ID="lblProje" runat="server"  Text="Agent Proje"></asp:Label></legend>
           <div style="margin-left:28px; margin-right:8px;">     
                <div class="ekleButon">
                    <asp:ImageButton ID="btnProjeEkleAgent" ImageUrl="../images/plus.gif" runat="server" /></div>

                <div class="solCL" style="width:100%; padding-top:12px;">
                    <asp:GridView ID="grdProjeAgnt" runat="server" AutoGenerateColumns="false" BorderStyle="None"  ShowHeader="false" >
                    
                    <RowStyle ForeColor="#444444"/>
                    <AlternatingRowStyle BackColor="#eeeeee"/>
                      <Columns>
                      <asp:BoundField DataField="projeID" ItemStyle-CssClass="hidden"/>
                      
                      <asp:BoundField DataField="proje" ItemStyle-Width="250px"/>
                      <asp:BoundField DataField="projeTarih" ItemStyle-HorizontalAlign="Right"  ItemStyle-Width="80px"/>    
                      <asp:BoundField DataField="role" ItemStyle-Width="250px"/>
                      <asp:BoundField DataField="roleID" ItemStyle-CssClass="hidden"/>
                      </Columns>
                    </asp:GridView>

                     
                </div>   
                 
           </div> 
           </fieldset>
           </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnProjeSec" EventName="click" />
          </Triggers>
          
          </asp:UpdatePanel>
          


           <br />
           <div style="float:left; clear:both; padding:10px; font-size:10px; color:#888888">

               <br /><asp:Label ID="lblChkUser" runat="server"></asp:Label>
           </div>


           <div style="float:right; text-align:right; padding:10px; clear:both;">
               <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" /></div>      
         
            </ContentTemplate> 
</cc1:TabPanel>
    </cc1:TabContainer>
</div>







             <asp:Button ID="btnHidden" runat="server" style="display: none;" />
             
             <cc1:ModalPopupExtender ID="mpe" runat="server" 
                 BackgroundCssClass="modalBackground" 
                 DropShadow="false" DynamicServicePath="" Enabled="true" PopupControlID="Panel1" 
                 TargetControlID="btnHidden">
                 
             </cc1:ModalPopupExtender>
             
             
                 
    <asp:Panel ID="Panel1" CssClass="popup1" runat="server" >
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div style="text-align:right; margin-top:4px; margin-right:3px;" >
        <asp:ImageButton ID="btnCancel" runat="server" CssClass="popupButon"
            ImageUrl="~/imaGes/ico2832.ico" AlternateText="Close" ToolTip="Close" />
    </div>
        
    <div style="clear:left; height:300px">
<asp:Label ID="lblSubsPopupBaslik" runat="server" CssClass="hLabel" Text="Agent Projeler "></asp:Label>    
<br /><asp:Label ID="lblSubsPopupBaslikAlt" runat="server" CssClass="hLabel" Font-Size="12px" Text=""></asp:Label>    



        <asp:GridView ID="grdProjeForAgent" runat="server" CellPadding="2" ClientIDMode="Predictable" 
        AutoGenerateColumns="False" BorderStyle="solid"  BorderColor="Beige" CssClass="grid" Font-Size="10px" Font-Names="Verdana"
        AllowPaging="True" PageSize="12"
        AllowSorting="True">
            <HeaderStyle BackColor="#CDD4F4" />
            

            <PagerSettings PageButtonCount="6" Position="TopAndBottom" />

        <RowStyle CssClass="grdRowStyle" />
        <AlternatingRowStyle CssClass="grdARowStyle" />        
        <Columns>
        
<%--        <asp:TemplateField Visible="false" >
               <ItemTemplate>
               <asp:Label ID="lblProjeID" runat="server" Text='<%# Eval("projeID") %>' />
               
               </ItemTemplate>
         </asp:TemplateField>--%> 
         
      <%--   projeID,proje,dateCreated,aciklama--%>
         <asp:BoundField DataField="projeID" ItemStyle-CssClass="hidden" ItemStyle-Width="1px" />
        <asp:BoundField HeaderText="Proje" DataField="proje" ItemStyle-Width="130px" />
        <asp:BoundField HeaderText="Proje Başlangıç" DataField="dateCreated" ItemStyle-Width="70px" />
        <asp:BoundField HeaderText="Aktif Agent" DataField="numOfAgent" ItemStyle-Width="60px" ItemStyle-CssClass="ortala" />
        <asp:BoundField HeaderText="Proje Açıklama" DataField="aciklama" ItemStyle-Width="200px"/>
       
       
               <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="Label3" runat="server" Text="Proje Seç"></asp:Label></HeaderTemplate>
               <ItemStyle CssClass="ortala" />
               <ItemTemplate>
               
               <asp:CheckBox ID="chkProjeSec" ClientIDMode="Predictable" runat="server" />
               
               </ItemTemplate>
         </asp:TemplateField> 
          
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
       <div style="clear:right; float:right; text-align:center; margin-top:20px; margin-right:15px;">
        <asp:Button runat="server" Text="Tamam" CssClass="buttonTamam" ID="btnProjeSec" />
       
        <asp:Button runat="server" Text="İptal" CssClass="buttonIptal" ID="btnProjeIptal" />
       


       </div> 
       
   </ContentTemplate>
   
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="grdProjeForAgent" EventName="PageIndexChanging" />

</Triggers>
        
    </asp:UpdatePanel>
        


    </asp:Panel>
    
    <uc1:uyari ID="ascxUyari" runat="server"  />
    
</asp:Content>

