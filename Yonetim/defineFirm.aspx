<%@ Page Language="VB" AutoEventWireup="false" CodeFile="defineFirm.aspx.vb" Inherits="Yonetim_defineFirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../css/agnt.css" rel="stylesheet" type="text/css" />
<link href="../css/formlar.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:12px; margin-top:22px">

    <div class="empCreateFormSutun1">
         <asp:Label ID="lblFirma" runat="server" Text="Firma: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtFirma" runat="server" ></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblDil" runat="server" Text="Dil: " Width="10em"></asp:Label>
                <asp:DropDownList ID="radioLang" RepeatLayout="Table" 
                    runat="server">
                    <asp:ListItem Text="tr-TR" Value="tr-TR"></asp:ListItem>
                    <asp:ListItem Text="en-US" Value="en-US"></asp:ListItem>
                    <asp:ListItem Text="de-DE" Value="de-DE"></asp:ListItem>
                </asp:DropDownList>

     </div>

    <div class="empCreateFormSutun1">
         <asp:Label ID="lblFirmaTel" runat="server" Text="Firma Tel: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtFirmaTel" runat="server"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblMail" runat="server" Text="e-mail: " Width="10em"></asp:Label>
      
     <asp:TextBox ID="txtFirmEMail" runat="server"></asp:TextBox> 
         
     </div>     

      <div class="empCreateFormSutun2">
         <asp:Label ID="lblFirmLogo" runat="server" Text="Firma Logo: " Width="10em"></asp:Label>
      
   <input type="file" id="fileFirmLogo" title="Firma Logo" runat="server" />
         
     </div>  





    <div class="empCreateFormSutun1">
         <asp:Label ID="lblFirmaCep" runat="server" Text="Firma Cep Tel: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtFirmaCep" runat="server"></asp:TextBox>
     </div>

      <div class="empCreateFormSutun2">
         <asp:Label ID="lblAdres" runat="server" Text="Adres: " Width="10em"></asp:Label>
      
     <asp:TextBox ID="txtAdres" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox> 
         
     </div> 
          
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblAciklama" runat="server" Text="Açıklama: " Width="10em"></asp:Label>
      
     <asp:TextBox ID="txtAciklama" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox> 
         
     </div>       
     
     <%--ara line--%>
     <div style="width:90%; float:left;clear:both; margin:12px; border-bottom:dotted 2px #ddd"></div>
     
     <div class="empCreateFormSutun1">
         <asp:Label ID="lblNumOFAgent" runat="server" Text="Agent sayısı: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtNumOFAgent" runat="server"></asp:TextBox>
     </div>
     
     <div class="empCreateFormSutun2">
         <asp:Label ID="lblAylikUcret" runat="server" Text="Aylık Ücret: " Width="10em"></asp:Label>
      
     <asp:TextBox ID="txtAylikUcret" runat="server"></asp:TextBox> 
         
     </div> 
     
         <%--ara line--%>
     <div style="width:90%; float:left;clear:both; margin:12px; border-bottom:dotted 2px #ddd"></div>
     
       <%--person1--%>
    <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson1Ad" runat="server" Text="İlgili Kişi 1: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson1Ad" runat="server"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson1Tel" runat="server" Text="Firma Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson1Tel" runat="server"></asp:TextBox>          
     </div>       
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson1Cep" runat="server" Text="Cep Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson1Cep" runat="server"></asp:TextBox> 
     </div>        
     
         <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson1EMail" runat="server" Text="e-mail: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson1EMail" runat="server"></asp:TextBox>
     </div>
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson1Aciklama" runat="server" Text="Açıklama: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson1Aciklama" Width="500px" runat="server"></asp:TextBox>          
     </div> 
     
         <%--ara line--%>
     <div style="width:90%; float:left;clear:both; margin:12px; border-bottom:dotted 2px #ddd"></div>
     
     <%--person2--%>
     
       <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson2Ad" runat="server" Text="İlgili Kişi 2: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson2Ad" runat="server"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson2Tel" runat="server" Text="Firma Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson2Tel" runat="server"></asp:TextBox>          
     </div>       
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson2Cep" runat="server" Text="Cep Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson2Cep" runat="server"></asp:TextBox> 
     </div>        
     
         <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson2EMail" runat="server" Text="e-mail: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson2EMail" runat="server"></asp:TextBox>
     </div>
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson2Aciklama" runat="server" Text="Açıklama: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson2Aciklama" Width="500px" runat="server"></asp:TextBox>          
     </div> 
     
         <%--ara line--%>
     <div style="width:90%; float:left;clear:both; margin:12px; border-bottom:dotted 2px #ddd"></div>
  
<%--person 3--%>
       <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson3Ad" runat="server" Text="İlgili Kişi 3: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson3Ad" runat="server"></asp:TextBox>
     </div>
     
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson3Tel" runat="server" Text="Firma Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson3Tel" runat="server"></asp:TextBox>          
     </div>       
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson3Cep" runat="server" Text="Cep Tel: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson3Cep" runat="server"></asp:TextBox> 
     </div>        
     
         <div class="empCreateFormSutun1">
         <asp:Label ID="lblPerson3EMail" runat="server" Text="e-mail: " Width="8em"></asp:Label>
         <asp:TextBox ID="txtPerson3EMail" runat="server"></asp:TextBox>
     </div>
      <div class="empCreateFormSutun2">
         <asp:Label ID="lblPerson3Aciklama" runat="server" Text="Açıklama: " Width="10em"></asp:Label>
         <asp:TextBox ID="txtPerson3Aciklama" Width="500px" runat="server"></asp:TextBox>          
     </div> 
     
         <%--ara line--%>
     <div style="width:90%; float:left;clear:both; margin:12px; border-bottom:dotted 2px #ddd"></div>
  

    </div>
    </form>
</body>
</html>
