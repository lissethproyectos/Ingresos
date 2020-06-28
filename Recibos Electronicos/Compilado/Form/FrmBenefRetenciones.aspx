<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmBenefRetenciones.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmBenefRetenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 228px;
        }
        .auto-style4 {
            width: 231px;
        }
        .auto-style5 {
            width: 159px;
        }
        .auto-style6 {
            width: 107px;
        }
        .auto-style7 {
            width: 163px;
        }
        .auto-style8 {
            width: 202px;
        }
        .auto-style9 {
            width: 190px;
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
                                        <td class="auto-style7" valign="top">
                                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="updPnlDep" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="95%">
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
                                        <td class="auto-style7" valign="top">
                                            <asp:Label ID="lblMes" runat="server" Text="Periodo de Pago:"></asp:Label>
                                        </td>
                                        <td>
                                            <table width="100%">
                                                <tr>
                                                    <td class="auto-style5" valign="top"><asp:DropDownList ID="DDLMes" runat="server">
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
                                            </asp:DropDownList></td>
                                                    <td class="auto-style6">
                                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            &nbsp;
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7" valign="top">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" valign="top" align="center" >
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvDatosRetenciones" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="grvDatosRetenciones_SelectedIndexChanged" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="beneficiario" HeaderText="MATRICULA" />
                                                            <asp:BoundField DataField="concepto" HeaderText="DEPENDENCIA" />
                                                            <asp:BoundField DataField="descripcion" HeaderText="PERIODO DE PAGO" />
                                                            <asp:BoundField DataField="referencia" HeaderText="REFERENCIA" />
                                                            <asp:BoundField DataField="total" HeaderText="TOTAL" />
                                                            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                                                        </Columns>
                                                                                   <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" />   
                        </asp:GridView>

                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7" valign="top">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7" valign="top">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style7" valign="top">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%">
                                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        (1) Póliza y Cédula
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width:100%;">
                                                            <tr>
                                                                <td class="auto-style8">
                                                                    <asp:Label ID="lblMes0" runat="server" Text="Periodo de Pago:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DDLMes0" runat="server">
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
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style8">
                                                                    <asp:Label ID="Label4" runat="server" Text="# de Póliza:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style8">
                                                                    <asp:Label ID="Label5" runat="server" Text="# de Cédula:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style8">&#160;</td>
                                                                <td align="right">
                                                                    <asp:Button ID="Button1" runat="server" Text="&gt;Siguiente" />
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style8">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                    <HeaderTemplate>
                                                        (2) Datos del Beneficiario
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width:100%;">
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label7" runat="server" Text="Tipo de Beneficiario:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList4" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label6" runat="server" Text="Beneficiario:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="Label8" runat="server" Text="Conceptos:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList5" runat="server" Width="100%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="lblTipo" runat="server" Text="Retención:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style3">
                                                                    <asp:Label ID="lblBeneficiario" runat="server" Text="Percepción:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <table style="width:100%;">
                                                                        <tr>
                                                                            <td class="auto-style9">
                                                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="bttnAgregar" runat="server" Text="AGREGAR" ValidationGroup="Beneficiario" />
                                                                            </td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="3">
                                                                    <asp:GridView ID="grvBeneficiarios" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="tipo_beneficiario" HeaderText="TIPO BENEFICIARIO" />
                                                                            <asp:BoundField DataField="beneficiario" HeaderText="BENEFICIARIO" />
                                                                            <asp:BoundField DataField="concepto" HeaderText="CONCEPTO" />
                                                                            <asp:BoundField DataField="retencion" HeaderText="$ RETENCIÓN" />
                                                                            <asp:BoundField DataField="percepcion" HeaderText="$ PERCEPCIÓN" />
                                                                            <asp:CommandField ShowDeleteButton="True" />
                                                                        </Columns>
                                                                        <FooterStyle CssClass="enc" />
                                                                        <HeaderStyle CssClass="enc" />
                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle CssClass="sel" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="3">
                                                                    <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                                                    &#160;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                            </ajaxToolkit:TabContainer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
