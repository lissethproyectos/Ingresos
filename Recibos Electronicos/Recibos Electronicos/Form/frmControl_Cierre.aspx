<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControl_Cierre.aspx.cs" Inherits="Recibos_Electronicos.Form.frmControl_Cierre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
        .auto-style2 {
            width: 265px;
        }
        .auto-style3 {
            height: 18px;
            width: 265px;
        }
        .auto-style5 {
            height: 18px;
            width: 1050px;
        }
        .auto-style6 {
            height: 18px;
            width: 691px;
        }
        .auto-style7 {
            height: 18px;
            width: 1363px;
        }
        .auto-style8 {
            height: 18px;
            width: 1350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;" class="tabla_contenido">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblAnio" runat="server" Text="Ejercicio:"></asp:Label>
            </td>
            <td class="auto-style8" align="left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlEjercicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEjercicio_SelectedIndexChanged">
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="auto-style5" align="right">
                Clave/Descripción Dependencia:</td>
            <td class="auto-style7" align="right">
                <asp:TextBox ID="txtBuscar" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style6" align="right">
                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click"/>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" align="center" colspan="5">
<asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel4" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image88" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." AlternateText="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvControl_Cierre" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" CellPadding="4" CssClass="mGrid" GridLines="Vertical" onpageindexchanging="grvControl_Cierre_PageIndexChanging" onselectedindexchanging="grvControl_Cierre_SelectedIndexChanging" PageSize="15" Width="100%" OnRowEditing="grvControl_Cierre_RowEditing" OnRowUpdating="grvControl_Cierre_RowUpdating" OnRowCancelingEdit="grvControl_Cierre_RowCancelingEdit">
                            <Columns>
                                <asp:BoundField DataField="Id_Control_Cierre" HeaderText="ID">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DEPENDENCIA" HeaderText="CVE" ReadOnly="True">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescDependencia" HeaderText="DEPENDENCIA" ReadOnly="True" />
                                <asp:TemplateField HeaderText="CIERRE">
                                    <HeaderTemplate>
                                        &nbsp;<table style="width:100%;">
                                            <tr>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMesGral" ErrorMessage="*Requerido" Font-Size="Smaller" InitialValue="0" ValidationGroup="vMesGral"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMesGral" runat="server" SelectedValue='<%# Bind("Mes_anio") %>' ValidationGroup="vMesGral">
                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                        <asp:ListItem Value="00">Apertura</asp:ListItem>
                                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                                        <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                        <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                        <asp:ListItem Value="04">Abril</asp:ListItem>
                                                        <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                        <asp:ListItem Value="06">Junio</asp:ListItem>
                                                        <asp:ListItem Value="07">Julio</asp:ListItem>
                                                        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                        <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="bttnCierreGeneral" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnCierreGeneral_Click" Text="GENERAL" ValidationGroup="vMesGral" />
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlMes" runat="server" Enabled="False" SelectedValue='<%# Bind("Mes_anio") %>'>
                                            <asp:ListItem Value="00">Apertura</asp:ListItem>
                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30%" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" CancelText="CANCELAR" DeleteText="ELIMINAR" EditText="EDITAR" UpdateText="ACTUALIZAR" />
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td colspan="4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td colspan="4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
