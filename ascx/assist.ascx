<%@ Control Language="VB" AutoEventWireup="false" CodeFile="assist.ascx.vb" Inherits="ascx_assist" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Button ID="btnShow" runat="server" Style="display: none;" />

<asp:Panel ID="pnlPopupAsst" runat="server" CssClass="popupAgnt">

<asp:UpdatePanel ID="updPnlAssist" runat="server">
<ContentTemplate>
    <div>
    
        <asp:Wizard ID="wzdAssist" runat="server"  BorderWidth="1px" CellPadding="4" 
            NavigationButtonStyle-CssClass="popButonTamamBg popButonTamam"
            CellSpacing="2" DisplaySideBar="False" 
            FinishCompleteButtonText="Tamam" 
            FinishPreviousButtonText="Önceki" StartNextButtonText="Sonraki" StepNextButtonText="Sonraki" StepPreviousButtonText="Önceki">
           


            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Başlangıç" StepType="Start" >

                        <div class="wizardStepMainDiv">
                        <div class="hLabel">
                            Agent başlangıç konuşması
                        </div>

                        <div style="text-align:center;">
                            <asp:TextBox ID="txtBasla" runat="server" ClientIDMode="Static" CssClass="wizardTxt" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStep2" runat="server" Title="Key Points">
                   <div class="wizardStepMainDiv">
                        <div class="hLabel">
                            Belirtilmesi gereken önemli noktalar
                        </div>
                        <div style="margin-left:22px; color:#464646; margin-right:20px;">
                            
                            <table>
                                <tr>
                                    <td>1.</td>
                                    <td><asp:TextBox ID="txtKP1" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>2.</td>
                                    <td><asp:TextBox ID="txtKP2" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>3.</td>
                                    <td><asp:TextBox ID="txtKP3" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>4.</td>
                                    <td><asp:TextBox ID="txtKP4" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>5.</td>
                                    <td><asp:TextBox ID="txtKP5" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td><asp:TextBox ID="txtKP6" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>7.</td>
                                    <td><asp:TextBox ID="txtKP7" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>8.</td>
                                    <td><asp:TextBox ID="txtKP8" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>9.</td>
                                    <td><asp:TextBox ID="txtKP9" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>10.</td>
                                    <td><asp:TextBox ID="txtKP10" runat="server" ClientIDMode="Static" CssClass="wizardTxt2"></asp:TextBox></td>
                                </tr>
                            </table>
                        </div>

                   </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStep4" runat="server" Title="Satış Paketleri">
                   <div class="wizardStepMainDiv">
                       <div class="hLabel">
                            Satış Paketleri Gösterimi
                        </div>
                        <div style="margin-left:22px; color:#464646; margin-right:20px; margin-top:40px;">
                            <asp:CheckBox ID="chkSatisPaket" Checked="true" ClientIDMode="Static" Text="Satış Paketlerini Göster" runat="server" />
                        </div> 
                       

                   </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep5" runat="server" Title="Kapanış">

                        <div class="wizardStepMainDiv">
                        <div class="hLabel">
                            Agent kapanış konuşması
                        </div>

                        <div style="text-align:center;">
                            <asp:TextBox ID="txtKapanis" runat="server" ClientIDMode="Static" CssClass="wizardTxt" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        </div>

                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>

</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="wzdAssist" EventName="NextButtonClick" />
</Triggers>    
</asp:UpdatePanel>

</asp:Panel> 

<cc1:ModalPopupExtender ID="mpeAssist" runat="server" TargetControlID="btnShow" 
PopupControlID="pnlPopupAsst" BackgroundCssClass="modalBackground" />