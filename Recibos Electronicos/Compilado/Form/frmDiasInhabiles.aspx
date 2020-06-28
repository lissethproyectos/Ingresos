<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDiasInhabiles.aspx.cs" Inherits="Recibos_Electronicos.Form.frmDiasInhabiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 263px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" align="right">
                                        <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio:"></asp:Label>
                                    </td>
            <td>
                <asp:DropDownList ID="ddlEjercicio" runat="server">
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                                                <asp:GridView ID="grvDiasInhabiles" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False"                                             
                                            EmptyDataText="No se encontró el recibo." CssClass="mGrid" Width="70%" OnPageIndexChanging="grvReferenciasSIAE_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="DIA INHÁBIL" />
                                                        <asp:BoundField HeaderText="DIA HÁBIL" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/del.PNG" ShowSelectButton="True" />
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
