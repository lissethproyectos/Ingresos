<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRepIngresos_Varios.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRepIngresos_Varios" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 156px;
        }
        .auto-style3 {
            width: 276px;
        }
        .auto-style4 {
            width: 125px;
        }
        .auto-style5 {
            width: 275px;
        }
        .auto-style6 {
            width: 156px;
            height: 18px;
        }
        .auto-style7 {
            width: 276px;
            height: 18px;
        }
        .auto-style8 {
            width: 275px;
            height: 18px;
        }
        .auto-style9 {
            height: 18px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <table style="width: 100%;" width="100%">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                                </td>
                        <td colspan="3">
                                                                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                                                        </asp:DropDownList>
                                                                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                                </td>
                        <td class="auto-style3">         
                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                <ContentTemplate>
                                                                                   <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        
                                </ContentTemplate>
                            </asp:UpdatePanel>
            </td>
                        <td class="auto-style5"><table width="100%">
                            <tr>
                                <td class="auto-style4">
                                                                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>

                                </td>
                                <td>
                                           <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                                               <ContentTemplate>
                                                                                              <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                                     <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                                     <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                </td>
                            </tr>
                                                </table>
                                                                </td>
                        <td>             
            </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                        <td class="auto-style3">
                                                                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                        <td class="auto-style5"><table width="100%">
                            <tr>
                                <td class="auto-style4">
                                                                                                        <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                                                                                            <ContentTemplate>
                                                                                                                <asp:Label ID="lblOrdenar" runat="server" Text="Ordenar por:"></asp:Label>
                                                                                                            </ContentTemplate>
                                                                                                        </asp:UpdatePanel>

                                </td>
                                <td>
                                           <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                                               <ContentTemplate>
                                                                                              <asp:DropDownList ID="ddlOrden" runat="server">
                                                                                                  <asp:ListItem Value="1">Clave</asp:ListItem>
                                                                                                  <asp:ListItem Value="2">Descripción</asp:ListItem>
                                                                                              </asp:DropDownList>

                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                </td>
                            </tr>
                                                </table>
                                                                </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="auto-style9" align="right">
                            <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                    &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                                                    &nbsp;</td>
                        <td class="auto-style7">
                                                                &nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
