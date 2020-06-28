<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepFacturas.aspx.cs" Inherits="Recibos_Electronicos.Form.RepFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="../Js/jsGeneral.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:700px;" align="center">
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>

                Ejercicio:</td>
            <td colspan="2">

                <asp:DropDownList ID="DDLEjercicio" runat="server" 
                    onselectedindexchanged="DDLEjercicio_SelectedIndexChanged">
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td align="right">

                Dependencia:</td>
            
            <td align="left" colspan="2">
                <asp:DropDownList 
                    ID="ddlDependencia" runat="server" Width="600px" 
                    onselectedindexchanged="ddlDependencia_SelectedIndexChanged">
                </asp:DropDownList>

            </td>
            
        </tr>
        <tr>
            <td valign="top">

                Status:</td>
            <td valign="top">

                <asp:DropDownList ID="ddlStatus" runat="server" Width="250px">
                    <asp:ListItem>SOLICITADO</asp:ListItem>
                    <asp:ListItem>FACTURADO</asp:ListItem>
                </asp:DropDownList>

            </td>
            <td valign="top">

                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btn_Aceptar" runat="server" CssClass="button" Height="45px" 
                            onclick="Button1_Click" Text="Ver reporte" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
        <tr>
            <td valign="top">

                &nbsp;</td>
            <td valign="top">

                &nbsp;</td>
            <td valign="top">

                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                 <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                            style="height: 500px" width="100%"></iframe>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
        </tr>
        <tr>
            <td colspan="3">

                &nbsp;</td>
        </tr>
        </table>
</asp:Content>
