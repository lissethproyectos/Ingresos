<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRepsAspirantes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRepsAspirantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 206px;
        }
        .auto-style3 {
            width: 80px;
        }
        .auto-style5 {
            width: 114px;
        }
        .auto-style6 {
            width: 76px;
        }
        .auto-style7 {
            width: 134px;
        }
        .auto-style8 {
            width: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;" class="tabla_contenido">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><table style="width:100%;">
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">
                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
            <td colspan="4">
                                                    <asp:DropDownList ID="ddlDependencia" runat="server" ClientIDMode="Predictable" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                                                                &nbsp;</td>
            <td class="auto-style8">
                                                                <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:"></asp:Label>
                                                            </td>
            <td class="auto-style2">
                                                                <asp:DropDownList ID="ddlCiclo" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                                </td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">
                                                                <asp:Label ID="lblSubTipo1" runat="server" Text="Tipo:"></asp:Label>
                                                            </td>
            <td class="auto-style5">
                                                                <asp:DropDownList ID="ddlTipo" runat="server" Width="100%">
                                                                    <asp:ListItem Value="3">TODOS</asp:ListItem>
                                                                    <asp:ListItem Value="1">REFERENCIAS</asp:ListItem>
                                                                    <asp:ListItem Value="2">EXENTOS</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
            <td>
                                                                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5" align="right">
                                                                 <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                                                <ContentTemplate>
                                                                <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" ValidationGroup="reporte" />
                                                                 </ContentTemplate>
                                            </asp:UpdatePanel>
                                                            </td>
            <td>
                                                                 &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    
</asp:Content>
