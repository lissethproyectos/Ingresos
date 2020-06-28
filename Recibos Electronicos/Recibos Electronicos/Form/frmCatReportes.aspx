<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatReportes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 139px;
        }
        .auto-style3 {
            width: 282px;
        }
        .auto-style4 {
            width: 171px;
        }
        .auto-style5 {
            width: 245px;
        }
        .auto-style6 {
            width: 282px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%;">
                            <tr valign="top">
                                <td class="auto-style2">Dependencia:</td>
                                <td colspan="3">
                                    <asp:UpdatePanel ID="updPnlDep" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td><asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="updPnlDep">
                                <ProgressTemplate>
                                    <asp:Image ID="imgDep" runat="server" Height="36px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." Width="36px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Fecha Inicial:</td>
                                <td class="auto-style4">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="right" class="auto-style5">Fecha Final:</td>
                                <td class="auto-style3">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Tipo:</td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                        <asp:ListItem Value="1">Por Dependencia</asp:ListItem>
                                        <asp:ListItem Value="2">Por Dependencia y Carreras</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style3">
                                    <asp:Button ID="bttnCatReembolsables" runat="server" Cssclass="btn btn-blue-grey" Text="Catálogo de Conceptos Reembolsables" OnClick="bttnCatReembolsables_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td class="auto-style6" align="right">
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td class="auto-style5">&nbsp;</td>
                                <td align="right" class="auto-style6">
                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                    &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                    </asp:View>
                    <asp:View ID="View6" runat="server">
                    </asp:View>
                    <asp:View ID="View7" runat="server">
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
