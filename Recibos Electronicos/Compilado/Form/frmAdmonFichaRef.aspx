<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmonFichaRef.aspx.cs" Inherits="Recibos_Electronicos.Form.frmAdmonFichaRef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 119px;
        }
        .auto-style8 {
            width: 1853px;
        }
        .auto-style9 {
            width: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
            <table class="tabla_contenido">
                <tr><td>
                    <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
            <progresstemplate>
                <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
            </progresstemplate>
        </asp:UpdateProgress>                                
                </td></tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="auto-style3" valign="top">
                        &nbsp;</td>
                    <td class="auto-style8" valign="top">
                        <div class="alert alert-warning">
                            Busqueda de referencias generadas en la página SYSWEB o SIAE.
                        </div></td>
                    <td class="auto-style9" valign="top">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" valign="top">
                        <asp:Label ID="lblReferencia" runat="server" Text="Referencia:"></asp:Label>
                    </td>
                    <td class="auto-style8" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtReferencia" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtReferencia_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="text-right">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReferencia" ErrorMessage="RequiredFieldValidator" ValidationGroup="Busca">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td class="auto-style9" valign="top">
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" ValidationGroup="Busca" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" valign="top">&nbsp;</td>
                    <td class="auto-style8" valign="top">&nbsp;</td>
                    <td class="auto-style9" valign="top">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
                        <asp:GridView ID="grdFichasRef" runat="server" AutoGenerateColumns="False" CssClass="mGrid3" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="FACT_NOTAS" HeaderText="ORIGEN" />
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="REFERENCIA">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_OBSERVACIONES" HeaderText="OBSERVACIONES">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_CAPTURA" HeaderText="SE GENERO">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="FACT_TOTAL" HeaderText="IMPORTE" DataFormatString="{0:c}" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table></ContentTemplate>
    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
</asp:Content>
