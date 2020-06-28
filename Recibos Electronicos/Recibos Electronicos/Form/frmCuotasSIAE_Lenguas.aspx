<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCuotasSIAE_Lenguas.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCuotasSIAE_Lenguas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style13 {
            width: 20%;
        }
        .auto-style15 {
            height: 47px;
        }
        .auto-style16 {
            width: 41%;
            text-align: right;
        }
        .auto-style17 {
            width: 41%
        }
        .auto-style18 {
            width: 17%;
        }
        .auto-style19 {
            width: 37%
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="3">
                                            <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                            <table style="width:100%;">
                                                <tr>
                                                    <td class="auto-style13" valign="top">
                                                        <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:" Width="120px"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td class="auto-style13" valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDependencias" ErrorMessage="RequiredFieldValidator" ValidationGroup="Nuevo">*Requerido</asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style13" valign="top">
                                                        <asp:Label ID="lblTipo1" runat="server" Text="Tipo:"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="ddlTipo1" runat="server">
                                                            <asp:ListItem Value="T">--Todos--</asp:ListItem>
                                                            <asp:ListItem Value="5">Sabatino</asp:ListItem>
                                                            <asp:ListItem Value="6">Verano</asp:ListItem>
                                                            <asp:ListItem Value="7">Invierno</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="auto-style13" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style15" colspan="3" valign="top">
                                                        <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                                            <progresstemplate>
                                                                <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:GridView ID="grvCuotas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay cuotas registradas." OnRowDeleting="grvCuotas_RowDeleting" OnSelectedIndexChanged="grvCuotas_SelectedIndexChanged" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Escuela" HeaderText="Escuela" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                                    <asp:BoundField DataField="Importe_Ingles" HeaderText="Ingles" />
                                                    <asp:BoundField DataField="Importe_Italiano" HeaderText="Italiano" />
                                                    <asp:BoundField DataField="Importe_Frances" HeaderText="Frances" />
                                                    <asp:BoundField DataField="Importe_Aleman" HeaderText="Aleman" />
                                                    <asp:BoundField DataField="Importe_Chino" HeaderText="Chino" />
                                                    <asp:BoundField DataField="Importe_Tzotzil" HeaderText="Tzotzil" />
                                                    <asp:BoundField DataField="Importe_Tzental" HeaderText="Tzental" />
                                                    <asp:BoundField DataField="Importe_Espaniol" HeaderText="Español" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnNuevo_Click" Text="AGREGAR" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" OnClick="imgBttnEditar_Click" style="width: 20px" Visible="False" />
                                                            &nbsp;<asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="~/Imagenes/del.PNG" OnClick="imgBttnCancelar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" style="width: 20px" Visible="False" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                            <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">
                                   <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>--%>
                                       <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <asp:Panel ID="pnlCuotas" runat="server">
                                    <table style="width: 100%;">                                        
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:DropDownList ID="ddlTipo" runat="server">
                                                    <asp:ListItem Value="X">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="5">Sabatino</asp:ListItem>
                                                    <asp:ListItem Value="6">Verano</asp:ListItem>
                                                    <asp:ListItem Value="7">Invierno</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlSemestre" ErrorMessage="RequiredFieldValidator" InitialValue="X" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="auto-style17">
                                                <asp:Label ID="lblSemestre" runat="server" Text="Nivel:"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:DropDownList ID="ddlSemestre" runat="server">
                                                    <asp:ListItem Value="Z">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="0">Propedeutico</asp:ListItem>
                                                    <asp:ListItem Value="99">Preuniversitario</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSemestre" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:Label ID="lblImporte_Ingles" runat="server" Text="Importe Ingles:"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:TextBox ID="txtImporte_Ingles" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtImporte_Ingles" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" class="auto-style17">
                                                <asp:Label ID="lblImporte_Italiano" runat="server" Text="Importe Italiano:"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:TextBox ID="txtImporte_Italiano" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtImporte_Italiano" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:Label ID="lblImporte_Frances" runat="server" Text="Importe Frances:"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:TextBox ID="txtImporte_Frances" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtImporte_Frances" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="auto-style16">
                                                <asp:Label ID="lblImporte_Aleman" runat="server" Text="Importe Aleman:"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:TextBox ID="txtImporte_Aleman" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtImporte_Aleman" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:Label ID="lblImporte_Chino" runat="server" Text="Importe Chino:"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:TextBox ID="txtImporte_Chino" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtImporte_Chino" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="auto-style17">
                                                <asp:Label ID="lblImporte_Tzotzil" runat="server" Text="Importe Tzotzil:"></asp:Label>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:TextBox ID="txtImporte_Tzotzil" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style13">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtImporte_Tzotzil" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:Label ID="lblImporte_Tzental" runat="server" Text="Importe Tzental:"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:TextBox ID="txtImporte_Tzental" runat="server" Width="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtImporte_Tzental" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                            <td class="auto-style17">
                                                <asp:Label ID="lblImporte_Espaniol" runat="server" Text="Importe Español:"></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox ID="txtImporte_Espaniol" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td width="15%">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtImporte_Espaniol" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="5">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="5">
                                                <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-info" OnClick="btnGuardar_Click" TabIndex="15" Text="GUARDAR" ValidationGroup="DatosCuotas" />
                                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="16" Text="CANCELAR" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">&nbsp;</td>
                                            <td class="auto-style18">&nbsp;</td>
                                            <td class="auto-style17">&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
