<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRetenciones.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRetenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 228px;
        }
        .auto-style5 {
            width: 159px;
        }
        .auto-style6 {
            width: 107px;
        }
        .auto-style8 {
            width: 114px;
        }
        .auto-style9 {
            height: 24px;
        }
        .auto-style10 {
            width: 187px;
        }
        .auto-style11 {
            width: 227px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;" class="tabla_contenido">
        <tr>
            <td>
                <div class="mensaje">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>             
                </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="auto-style8" valign="top">
                                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="updPnlDep" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDependencia" runat="server" Width="95%">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                                    <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="updPnlDep">
                                                        <progresstemplate>
                                    <asp:Image ID="imgDep" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                </progresstemplate>
                                                    </asp:UpdateProgress>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8" valign="top">
                                            <asp:Label ID="lblAnio" runat="server" Text="Año:"></asp:Label>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td class="auto-style5" valign="top">
                                                        <asp:DropDownList ID="DDLAnio" runat="server" Width="150px">
                                                            <asp:ListItem>2017</asp:ListItem>
                                                            <asp:ListItem>2016</asp:ListItem>
                                                            <asp:ListItem>2015</asp:ListItem>
                                                            <asp:ListItem>2014</asp:ListItem>
                                                            <asp:ListItem>2013</asp:ListItem>
                                                            <asp:ListItem>2012</asp:ListItem>
                                                            <asp:ListItem>2011</asp:ListItem>
                                                            <asp:ListItem>2010</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="auto-style5" valign="top">
                                                        <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style5" valign="top">
                                                        <asp:DropDownList ID="DDLMes" runat="server" Width="150px">
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
                                                    <td class="auto-style6" align="center">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8" valign="top">
                                            <asp:Label ID="lblAnio0" runat="server" Text="Buscar:"></asp:Label>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtBuscar" runat="server" Width="500px"></asp:TextBox>
                                                    </td>
                                                    <td align="center" class="auto-style6">
                                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" Visible="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" valign="top" align="center">
                                            <asp:UpdateProgress ID="updPrgBenef" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                                <progresstemplate>
                                                    <asp:Image ID="imgddlTipo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" valign="top">
                                            <asp:UpdatePanel ID="updPnlBenef" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvBeneficiarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%" OnPageIndexChanging="grvBeneficiarios_PageIndexChanging" OnSelectedIndexChanged="grvBeneficiarios_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="dependencia" HeaderText="DEP." />
                                                            <asp:BoundField DataField="tipo_beneficiario" HeaderText="TIPO" />
                                                            <asp:BoundField DataField="beneficiario" HeaderText="BENEFICIARIO" />
                                                            <asp:BoundField DataField="poliza" HeaderText="# DE PÓLIZA" />
                                                            <asp:BoundField DataField="cedula" HeaderText="# DE CÉDULA" />
                                                            <asp:BoundField DataField="cargo" HeaderText="CARGO" />
                                                            <asp:BoundField DataField="abono" HeaderText="ABONO" />
                                                            <asp:CommandField ShowSelectButton="True" />
                                                            <asp:BoundField DataField="MesAnio" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server">Realizar Pago</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="3" class="auto-style9">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style9" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblNombreBenfeciario" runat="server" Font-Bold="True" Font-Size="13pt"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style9" colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdateProgress ID="updPrgDetalle" runat="server" AssociatedUpdatePanelID="updPnlDetalle">
                                                <progresstemplate>
                                                    <asp:Image ID="imgddlTipo0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:UpdatePanel ID="updPnlDetalle" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvDetalle" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%" OnSelectedIndexChanged="grvDetalle_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="Cuenta" HeaderText="CTA." />
                                                            <asp:BoundField DataField="concepto" HeaderText="CONCEPTO" />
                                                            <asp:BoundField DataField="cargo" HeaderText="CARGO" />
                                                            <asp:BoundField DataField="abono" HeaderText="ABONO" />
                                                            <asp:CommandField SelectText="Asociar" ShowSelectButton="True" />
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
                                        <td class="auto-style3">
                                            <asp:HiddenField ID="hddnBeneficiario" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modalBenef" runat="server" PopupControlID="pnlBeneficiario" TargetControlID="hddnBeneficiario" BackgroundCssClass="modalBackground_Proy">
                                            </ajaxToolkit:ModalPopupExtender>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel ID="pnlBeneficiario" runat="server" CssClass="TituloModalPopupMsg" Width="850px">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td class="auto-style10">&nbsp;</td>
                                                        <td class="auto-style11">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10" valign="top">
                                                            <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
                                                        </td>
                                                        <td class="auto-style11" valign="top">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DDLTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                                                                        <asp:ListItem Value="X">--Elegir--</asp:ListItem>
                                                                        <asp:ListItem Value="TCH003">Proveedor</asp:ListItem>
                                                                        <asp:ListItem Value="TCH001">Empleado</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DDLTipo" ErrorMessage="*Requerido" InitialValue="X" ValidationGroup="Beneficiario"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <asp:UpdateProgress ID="updPrgDetalle0" runat="server" AssociatedUpdatePanelID="updPnlDetalle">
                                                                <progresstemplate>
                                                                    <asp:Image ID="imgddlTipo1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                </progresstemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                        <td valign="top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10">
                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblBeneficiario" runat="server" Text="Proveedor:"></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="DDLBeneficiario" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDLBeneficiario" ErrorMessage="*Requerido" ValidationGroup="Beneficiario"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10">
                                                            <asp:Label ID="Label4" runat="server" Text="Concepto:"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="DDLConcepto" runat="server">
                                                                <asp:ListItem Value="767">IMPUESTOS SOBRE NOMINA</asp:ListItem>
                                                                <asp:ListItem Value="759">ISPT (051)</asp:ListItem>
                                                                <asp:ListItem Value="3">ISR HONORARIOS ASIMILADOS A SALARIOS</asp:ListItem>
                                                                <asp:ListItem Value="4">ISR POR ARRENDAMIENTO</asp:ListItem>
                                                                <asp:ListItem Value="5">ISSS POR FINIQUITOS</asp:ListItem>
                                                                <asp:ListItem Value="6">IVA POR PAGAR</asp:ListItem>
                                                                <asp:ListItem Value="7">IVA RETENIDO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10">
                                                            <asp:Label ID="Label5" runat="server" Text="Impuesto:"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtImpuesto" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:Button ID="bttnAgregar" runat="server" Cssclass="btn btn-blue-grey" Text="AGREGAR" ValidationGroup="Beneficiario" OnClick="bttnAgregar_Click1" />
                                                            &nbsp;<asp:Button ID="bttnSalir" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnSalir_Click" Text="CANCELAR" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10">&nbsp;</td>
                                                        <td class="auto-style11">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:GridView ID="grvImpuestos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="tipo_beneficiario" HeaderText="TIPO" />
                                                    <asp:BoundField DataField="beneficiario" HeaderText="EMPLEADO" />
                                                    <asp:BoundField DataField="concepto" HeaderText="CONCEPTO" />
                                                    <asp:BoundField DataField="impuesto" HeaderText="IMPUESTO" />
                                                    <asp:CommandField ShowDeleteButton="True" />
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
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
