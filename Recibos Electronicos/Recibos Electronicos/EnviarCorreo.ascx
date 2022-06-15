<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EnviarCorreo.ascx.cs" Inherits="Recibos_Electronicos.EnviarCorreo" %>
<asp:HiddenField ID="hddnCorreo" runat="server" />
<asp:HiddenField ID="hddnCveSysweb" runat="server" />
<ajaxToolkit:ModalPopupExtender ID="modalCorreo" runat="server"
    TargetControlID="hddnCorreo" PopupControlID="pnlCorreo"
    BackgroundCssClass="modalBackground_Proy">
</ajaxToolkit:ModalPopupExtender>

<asp:Panel ID="pnlCorreo" runat="server">
    <div class="card">
        <div class="card-header">
            <strong>Enviar Recibo Oficial</strong>
        </div>
        <div class="card-body">
            <div class="container">
                <div class="row">
                    <div class="col">
                        <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMensajeCorreo" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblCorreo" runat="server" Text="Correo"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-7">
                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hddnMatricula" runat="server" />
                                <asp:HiddenField ID="hddnRecibo" runat="server" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        <asp:UpdatePanel ID="UpdatePanel38" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="bttnBuscaCorreo" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnBuscaCorreo_Click" Text="Buscar Correo" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                            <ProgressTemplate>
                                <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." Height="50px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel38">
                            <ProgressTemplate>
                                <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-primary" Height="40px" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                                &nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" Height="40px" OnClick="bttnCancelarCorreo_Click" Text="Salir" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Panel>
