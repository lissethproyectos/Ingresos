<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFichaRef_Eventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmFichaRef_Eventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 186px;
        }
        .auto-style2 {
            width: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;" class="tabla_contenido">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" valign="top">
                            Dependencia:</td>
            <td valign="top" colspan="2">
                            <asp:UpdatePanel ID="updPnlDep" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" valign="top">Tipo de Evento:</td>
            <td class="auto-style2" valign="top">
                <asp:DropDownList runat="server" ID="ddlDirigido" OnSelectedIndexChanged="ddlDirigido_SelectedIndexChanged">
                    <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                    <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                    <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" valign="top">
                                                        Evento(s):</td>
            <td colspan="2">
                            <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>
                                    <asp:Image ID="imgDep" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No existen eventos para esta dependencia." Width="100%" AllowPaging="True" OnPageIndexChanging="grdEventos_PageIndexChanging">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Eventos" HeaderText="CVE." />
                                                                                <asp:BoundField DataField="Dependencia" HeaderText="Dep.">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Fecha_inicial" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Inicial">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Fecha_final" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Generar Referencia">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="imgBttnEvento" runat="server" ImageUrl="~/Imagenes/referencia.PNG" OnClick="imgBttnEvento_Click" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Ruta" />
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
            <td class="auto-style1">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
