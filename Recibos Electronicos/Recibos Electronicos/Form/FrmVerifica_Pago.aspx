<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVerifica_Pago.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmVerifica_Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td colspan="2" width="30%">
                &nbsp;</td>
            <td width="30%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" width="30%">
                                        <asp:Label ID="lblCiclo" runat="server" 
                    Text="Ciclo Escolar:"></asp:Label>
                                    </td>
            <td colspan="2" width="30%">
                                        <asp:DropDownList ID="ddlCiclo" runat="server" 
                    Width="400px">
                                        </asp:DropDownList>
                                    </td>
            <td width="30%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" valign="top" width="30%">
                                        <asp:Label ID="lblMatricula" runat="server" 
                    Text="Matricula:"></asp:Label>
                                    </td>
            <td valign="top" width="15%">
                                        <asp:TextBox ID="txtMatricula" runat="server" 
                    CssClass="box" MaxLength="8" TabIndex="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMatricula"
                                            ErrorMessage="*Requerido" CssClass="MsjError" 
                    ValidationGroup="buscar"></asp:RequiredFieldValidator>
                                    </td>
            <td style="width: 15%" width="15%">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgbtnBuscar" runat="server" Height="38px" 
                                    ImageUrl="~/Imagenes/Search.png" OnClick="imgbtnBuscar_Click" 
                                    ValidationGroup="buscar" Width="39px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
            <td width="30%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td align="center" colspan="2" width="30%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td width="30%">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvFacturas" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="4" 
                                    EmptyDataText="No se registraron pagos" Font-Names="Calibri" 
                                    ForeColor="#333333" GridLines="None" Width="80%">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dependencia">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FACT_TOTAL" HeaderText="Importe">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FACT_FECHA_FACTURA" HeaderText="Fecha Pago">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#469C9D" Font-Bold="True" Font-Names="Calibri" 
                                        ForeColor="White" />
                                    <PagerStyle BackColor="#469C9D" Font-Names="Calibri" ForeColor="White" 
                                        HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />

                                    <sortedascendingcellstyle backcolor="#F8FAFA" />
                                    <sortedascendingheaderstyle backcolor="#246B61" />
                                    <sorteddescendingcellstyle backcolor="#D4DFE1" />
                                    <sorteddescendingheaderstyle backcolor="#15524A" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td colspan="2" width="30%">
                &nbsp;</td>
            <td width="30%">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="30%">
                &nbsp;</td>
            <td colspan="2" width="30%">
                &nbsp;</td>
            <td width="30%">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
