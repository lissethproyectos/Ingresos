
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmPuntodeVenta.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmPuntodeVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 64px;
        }
        .auto-style2 {
            width: 78px;
        }
        .auto-style3 {
            width: 94px;
        }
        .auto-style4 {
            width: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 30%;">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td style="width: 50%;" valign="top">
                                    <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 20%;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 30%;" valign="top">
                                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td style="width: 50%;" valign="top" align="left">
                                    <table style="border-style: 0; border-color: 0; border-width: 0px; width: 100%; border-spacing: 0px;">
                                        <tr>
                                            <td class="auto-style1" valign="top">
                                                <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2" valign="top">
                                                <img style="cursor: pointer" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                            alt="Ver calendario" src="../Imagenes/Calendario.gif" />
                                            </td>
                                            <td align="right" class="auto-style3" valign="top">
                                                <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                            </td>
                                            <td class="auto-style4" valign="top">
                                                <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                            </td>
                                            <td valign="top">
                                                <img style="cursor: pointer" onclick="new CalendarDateSelect( $(this).previous(), {year_range:100} );"
                                            alt="Ver calendario" src="../Imagenes/Calendario.gif" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 20%;" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 30%;" valign="top">
                                    <asp:Label ID="lblReferencia" runat="server" Text="Referencia/Nombre/Matricula:"></asp:Label>
                                </td>
                                <td style="width: 50%;" valign="top">
                                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" Visible="true" Width="100%"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 20%;" valign="top">
                                    <asp:Button ID="btnBuscar" runat="server" CssClass="button" Height="36px" OnClick="btnBuscar_Click" Text="BUSCAR" Width="70px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvDatosFichaBanc" runat="server" Width="100%"  PageSize="15" BackColor="White" BorderColor="White" 
                                            BorderStyle="Outset" BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                            AutoGenerateColumns="False" AllowPaging="True">
                                                <RowStyle BackColor="#E3EAEB" ForeColor="Black" Font-Names="Calibri"></RowStyle>
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" />
                                                    <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Matricula" />
                                                    <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="FACT_OBSERVACIONES" HeaderText="Observaciones" />
                                                    <asp:CommandField ShowSelectButton="True" />
                                                </Columns>
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black"></FooterStyle>
                                                <PagerStyle HorizontalAlign="Center" BackColor="#469C9D" ForeColor="White" 
                                                    Font-Names="Calibri"></PagerStyle>
                                                <SelectedRowStyle BackColor="#D9E2E9" Font-Bold="False" ForeColor="Black">
                                                </SelectedRowStyle>
                                                <HeaderStyle BackColor="#469C9D" Font-Bold="True" ForeColor="White" 
                                                    Font-Names="Calibri"></HeaderStyle>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 30%;">&nbsp;</td>
                                <td style="width: 50%;">&nbsp;</td>
                                <td style="width: 20%;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 30%;">&nbsp;</td>
                                <td style="width: 50%;">&nbsp;</td>
                                <td style="width: 20%;">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
