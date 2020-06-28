<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmCancelaciones.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmCancelados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: justify;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblNombre_Formulario" runat="server" CssClass="titulo" Text="CANCELACIONES"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Recibo/Referencia"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="txtFolioBuscar" runat="server" Width="450px"></asp:TextBox>
                        <asp:ImageButton ID="imgbtnBuscar" runat="server" Height="38px" ImageUrl="~/Imagenes/Search.png"
                            Width="39px" OnClick="imgbtnBuscar_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblMsj" runat="server" CssClass="MsjError"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:GridView ID="grvFacturas" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CellPadding="4" Font-Names="Calibri" ForeColor="#333333" GridLines="None" 
                            onselectedindexchanged="grvFacturas_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="Id" />
                                <asp:BoundField DataField="Status_Carga" />
                                <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Matricula" />
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" />
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" />
                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Recibo" />
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" HeaderText="Fecha" />
                                <asp:TemplateField HeaderText="Estatus">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rdoListStatus" runat="server" AutoPostBack="true" 
                                            OnSelectedIndexChanged="rdoListStatus_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal" 
                                            ValidationGroup='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>'>
                                            <asp:ListItem Value="A">Activo</asp:ListItem>
                                            <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#469C9D" Font-Bold="True" Font-Names="Calibri" ForeColor="White" />
                            <PagerStyle BackColor="#469C9D" Font-Names="Calibri" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                        </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <asp:Image ID="Image1q" runat="server" Height="30px" ImageUrl="~/Imagenes/ajax_loader_gray_512.gif"
                Width="30px" ToolTip="Espere un momento, por favor.." AlternateText="Espere un momento, por favor.." />
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
