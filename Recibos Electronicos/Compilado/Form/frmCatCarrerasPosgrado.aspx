<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatCarrerasPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatCarrerasPosgrado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 667px;
        }
        .auto-style4 {
            width: 66px;
        }
        .auto-style5 {
            width: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table  class="tabla_contenido">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                        <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
                    </td>
            <td class="auto-style3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged">
                                    <asp:ListItem Value="T">--Todos--</asp:ListItem>
                                    <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                                    <asp:ListItem Value="N">Lenguas Extranjeras</asp:ListItem>
                                    <asp:ListItem Value="E">Especialidad</asp:ListItem>
                                    <asp:ListItem Value="M">Maestría</asp:ListItem>
                                    <asp:ListItem Value="D">Doctorado</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                                    &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" valign="top">
                <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
            </td>
            <td valign="top" class="auto-style3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" CssClass="select2">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="auto-style5" valign="top">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                    <progresstemplate>
                        <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
            <td valign="top">&nbsp;</td>
            <td valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" valign="top">
                <asp:Label ID="lblBuscar" runat="server" Text="Busca:"></asp:Label>
            </td>
            <td valign="top" class="auto-style3">
                <asp:TextBox ID="txtBusca" runat="server" Width="100%" PlaceHolder="Nombre de la Carrera"></asp:TextBox>
            </td>
            <td class="auto-style5" valign="top">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td valign="top">&nbsp;</td>
            <td valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td valign="top" colspan="5" align="center">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                            <progresstemplate>
                                <asp:Image ID="Image89" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </progresstemplate>
                        </asp:UpdateProgress></td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <progresstemplate>
                                <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvCarrerasUNACH" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvCarrerasUNACH_PageIndexChanging" PageSize="20" Width="100%" EmptyDataText="No se encontro ningún registro">
                                    <Columns>
                                        <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Carrera" HeaderText="Cve. Carrera">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="enc" />
                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                    <SelectedRowStyle CssClass="sel" />
                                    <HeaderStyle CssClass="enc" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td align="right" colspan="4">
                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                    <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
