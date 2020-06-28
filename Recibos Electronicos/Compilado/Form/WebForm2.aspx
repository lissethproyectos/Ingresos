<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Recibos_Electronicos.Form.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:Accordion ID="Accordion1" runat="server" Height="250px" Width="848px">
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ContentCssClass="" HeaderCssClass="">
                <Header>Datos del Voucher</Header>
                <Content>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblFolio" runat="server" Text="Folio:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFolio" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                            </td>
                            <td>&#160;</td>
                            <td>
                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                            </td>
                            <td>&#160;</td>
                            <td>&#160;</td>
                            <td>&#160;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtImporte" runat="server" AutoPostBack="True" OnTextChanged="txtImporte_TextChanged" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporte" ErrorMessage="*Importe(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                            </td>
                            <td>&#160;</td>
                            <td>
                                <asp:Label ID="lblIVA" runat="server" Text="IVA:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIVA" runat="server" AutoPostBack="True" OnTextChanged="txtIVA_TextChanged" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="valIva" runat="server" ControlToValidate="txtIVA" ErrorMessage="*Iva(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Label ID="lblTotal" runat="server" Text="Total:"></asp:Label>
                            </td>
                            <td class="auto-style88">
                                <asp:TextBox ID="txtTotal" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="valTotal" runat="server" ControlToValidate="txtTotal" ErrorMessage="*Total(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div class="mensaje_naranja">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblTitVoucher" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Voucher"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblVoucher" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label>
                                                    </td>
                                                    <td class="auto-style7">
                                                        <asp:FileUpload ID="fileVoucher" runat="server" Height="30px" />
                                                    </td>
                                                    <td class="auto-style6">
                                                        <asp:Button ID="btnVoucher" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnVoucher_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="auto-style38" colspan="3">
                                                        <table style="width: 60%;" width="70%">
                                                            <tr align="center">
                                                                <td style="width: 50%;">
                                                                    <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                </td>
                                                                <td style="width: 50%;">
                                                                    <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="linkBttnEliminarVoucher" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarVoucher_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnVoucher" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19">&#160;</td>
                            <td class="auto-style80">&#160;</td>
                            <td class="auto-style87">&#160;</td>
                            <td class="auto-style86">&#160;</td>
                            <td class="auto-style78">&#160;</td>
                            <td class="auto-style26">&#160;</td>
                            <td class="auto-style85">&#160;</td>
                            <td class="auto-style88">&#160;</td>
                            <td class="auto-style88">&#160;</td>
                            <td>&#160;</td>
                        </tr>
                    </table>

                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" ContentCssClass="" HeaderCssClass="">
                <Header>2</Header>
                <Content>asas</Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" ContentCssClass="" HeaderCssClass="">
                <Header>3</Header>
                <Content>asas</Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>
</asp:Content>
