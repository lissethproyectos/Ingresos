<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRefVenta_Pat.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRefVenta_Pat" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style15 {
            width: 16%;
        }

        .auto-style16 {
            width: 40%;
            text-align: left;
        }

        .auto-style17 {
            width: 40%;
        }

        .auto-style21 {
            width: 100%;
        }

        .auto-style22 {
            width: 14px;
        }

        .auto-style23 {
            width: 197px;
        }

        .auto-style24 {
            text-align: right;
            width: 140px;
        }

        .auto-style25 {
            text-align: right;
            width: 83px;
        }
    </style>
    <script type="text/javascript">
        function PagBancomer() {
            $('#<%= mp_account.ClientID %>').attr("name", "mp_account");
            alert($('input[name=mp_account]').val());
            $('#<%= mp_product.ClientID %>').attr("name", "mp_product");
            $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
            $('#<%= mp_reference.ClientID %>').attr("name", "mp_reference");
            $('#<%= mp_node.ClientID %>').attr("name", "mp_node");
            $('#<%= mp_concept.ClientID %>').attr("name", "mp_concept");
            $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
            $('#<%= mp_amount.ClientID %>').attr("name", "mp_amount");
            $('#<%= mp_customername.ClientID %>').attr("name", "mp_customername");
            $('#<%= mp_currency.ClientID %>').attr("name", "mp_currency");
            $('#<%= mp_signature.ClientID %>').attr("name", "mp_signature");
            $('#<%= mp_urlsuccess.ClientID%>').attr("name", "mp_urlsuccess");
            $('#<%= mp_urlfailure.ClientID %>').attr("name", "mp_urlfailure");
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').action = "https://www.adquiramexico.com.mx/clb/endpoint/unach/";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').method = "POST";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').submit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlCtaMayor" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCtaMayor" runat="server" Text="Cta de Mayor:" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="updPnlCtaMayor2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLCtaMayor" runat="server" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hddnReferencia" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hddnIdFichaRef" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="updPnlMultiview">
                    <ProgressTemplate>
                        <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgPrecarga" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlMultiview" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table class="auto-style21">
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style15">Dependencia
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLDependencia" runat="server" ClientIDMode="Predictable" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="* Seleccionar Dependencia" InitialValue="00000" ValidationGroup="GenRef">*</asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">
                                            <asp:Label ID="lblPagado" runat="server" Text="Status"></asp:Label>
                                        </td>
                                        <td>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td class="auto-style22">
                                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLPagado" runat="server">
                                                                    <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                                    <asp:ListItem Value="S">PAGADOS</asp:ListItem>
                                                                    <asp:ListItem Value="N">SIN PAGAR</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td class="auto-style24">
                                                        <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial"></asp:Label>
                                                    </td>
                                                    <td class="auto-style23">
                                                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                                                    <td class="auto-style25">
                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">
                                            <asp:HiddenField ID="hddnModal" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modal" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlDetalle" TargetControlID="hddnModal"></ajaxToolkit:ModalPopupExtender>
                                        </td>
                                        <td>
                                            <table style="width: 98%;">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtBuscaRef" runat="server" PlaceHolder="Referencia/Folio" Width="98%"></asp:TextBox>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:ImageButton ID="bttnBuscaRef" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="bttnBuscaRef_Click" ValidationGroup="Busca" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="GenRef" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" DataKeyNames="ID_FACT" EmptyDataText="No existen registros." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" Width="100%" ShowHeaderWhenEmpty="True" ShowFooter="True" PageSize="11">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID" />
                                                            <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep." SortExpression="DEPENDENCIA" />
                                                            <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA_FACTURA">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="bttnDetalle" runat="server" CssClass="btn btn-info" Font-Size="X-Small" OnClick="bttnDetalle_Click" Text="Ver Detalle" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <FooterTemplate>
                                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" data-placement="left" data-toggle="tooltip" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" title="(PDF) Aplica únicamente a pagos confirmados." />
                                                                    &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" data-placement="top" data-toggle="tooltip" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" title="(EXCEL) Aplica únicamente a pagos confirmados." />
                                                                </FooterTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:Button ID="bttnGenerarRef" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnGenerarRef_Click" Text="NUEVA REFERENCIA" ValidationGroup="GenRef" Width="144px" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<asp:Button ID="bttnReimprimir" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Text="Pagar" Visible='<%# Bind("VISIBLE1") %>' Width="57px" OnClick="bttnReimprimir_Click" />&nbsp;<asp:Button ID="bttnEliminar" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" OnClick="bttnEliminar_Click" Text="Eliminar" Visible='<%# Bind("VISIBLE1") %>' Width="57px" OnClientClick="return confirm('¿Eliminar registro?');" />--%>
                                                                    <asp:LinkButton ID="bttnReimprimir" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE1") %>' Width="85px" OnClick="bttnReimprimir_Click"><i class="fa fa-usd" aria-hidden="true"></i>
 Pagar</asp:LinkButton>&nbsp;<asp:LinkButton ID="bttnEliminar" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" OnClick="bttnEliminar_Click" Visible='<%# Bind("VISIBLE1") %>' Width="85px" OnClientClick="return confirm('¿Eliminar registro?');"><i class="fa fa-trash" aria-hidden="true"></i> Eliminar</asp:LinkButton>
                                                                    <%--<asp:Button ID="bttnVerRecibo" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Text="Ver Recibo" Visible='<%# Bind("VISIBLE2") %>' Width="190px" OnClick="bttnVerRecibo_Click" />--%>
                                                                    <asp:LinkButton ID="bttnVerRecibo" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE2") %>' Width="190px" OnClick="bttnVerRecibo_Click"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PAGADO" />
                                                            <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <%--<asp:Button ID="bttnReimprimirUsu6" runat="server" CssClass="btn btn-primary" Font-Size="X-Small" OnClick="bttnReimprimir_Click" Text="Pagar" Visible='<%# Bind("VISIBLE1") %>' Width="118px" />--%>
                                                                    <asp:LinkButton ID="bttnReimprimirUsu6" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE1") %>' Width="85px" OnClick="bttnReimprimir_Click"><i class="fa fa-usd" aria-hidden="true"></i> Pagar</asp:LinkButton>
                                                                    <asp:LinkButton ID="bttnVerReciboUsu6" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE2") %>' Width="190px" OnClick="bttnVerRecibo_Click"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
                                                                    <%--<asp:Button ID="bttnVerReciboUsu6" runat="server" CssClass="btn btn-primary" Font-Size="X-Small" OnClick="bttnVerRecibo_Click" Text="Ver Recibo" Visible='<%# Bind("VISIBLE2") %>' Width="118px" />--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ID_CODIGO_QR" />
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
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor" style="height: 500px" width="100%"></iframe>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlDetalle" runat="server" CssClass="TituloModalPopupMsg" Width="50%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td width="20%">&nbsp;</td>
                                                        <td align="center" width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style17" colspan="3">
                                                            <asp:GridView ID="grvDetPago" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="No_Inventario" HeaderText="# Inventario">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Total" HeaderText="Importe" DataFormatString="{0:C}">
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle CssClass="enc" />
                                                                <HeaderStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">&nbsp;</td>
                                                        <td align="center" width="60%">
                                                            <asp:Button ID="btnCancelar_Detalle" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btnCancelar_Detalle_Click" Text="SALIR" />
                                                        </td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">&nbsp;</td>
                                                        <td align="center" width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">&nbsp;</td>
                                                        <td align="center" width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col font-weight-bold">
                                            <asp:Label ID="lblLeyDependencia" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Tipo de Venta
                                        </div>
                                        <div class="col-md-3">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <customControl:GroupDropDownList ID="DDLTipoVenta" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoVenta_SelectedIndexChanged" Width="100%"></customControl:GroupDropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DDLTipoVenta" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="BuscaInventario">* Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            No. de Ficha/Matricula/Cve
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtClaveSysweb" runat="server" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClaveSysweb" ErrorMessage="* El número del cliente es requerido." ValidationGroup="Cliente">* Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:ImageButton ID="imgBttnBuscarCliente" runat="server" Height="35px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" ToolTip="Busca # de Cliente" OnClick="imgBttnBuscarCliente_Click" Width="35px" />
                                            &nbsp;<asp:ImageButton ID="imgBttnCatClientes" runat="server" Height="35px" ImageUrl="~/Imagenes/cliente2.png" Width="35px" ToolTip="Busca Cliente" OnClick="imgBttnCatClientes_Click" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Nivel
                                        </div>
                                        <div class="col-md-3">
                                            <asp:UpdatePanel ID="UpdatePanel228" runat="server">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%"></asp:ListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2">
                                            Cliente
                                        </div>
                                        <div class="col-md-5 alert alert-warning">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="lblClienteNombre" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="reqNombreCliente" runat="server" ErrorMessage="* El nombre del cliente requerido." ValidationGroup="Cliente" ControlToValidate="lblClienteNombre">* Requerido</asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hddnCambiaTipo" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="modalTipo" runat="server" TargetControlID="hddnCambiaTipo" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnl_Alert">
                                    </ajaxToolkit:ModalPopupExtender>
                                    <div class="row">
                                        <div class="col-md-11">
                                            <asp:TextBox ID="txtBusqueda" runat="server" PlaceHolder="# Inventario" Width="98%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" ValidationGroup="BuscaInventario" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:GridView ID="grvInventario" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay productos/servicios registrados" OnPageIndexChanging="grvInventario_PageIndexChanging" OnSelectedIndexChanged="grvInventario_SelectedIndexChanged" Width="100%">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:BoundField DataField="No_Inventario" HeaderText="# Inventario">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Clave" HeaderText="# Arete" />
                                                    <asp:TemplateField HeaderText="Descripción">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGrupo" runat="server" Text="DESCRIPCIÓN "></asp:Label>
                                                            <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Poliza" HeaderText="# Póliza" />
                                                    <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:CommandField SelectText="Agregar" ShowSelectButton="True" />
                                                    <asp:BoundField DataField="Id_Inventario" />
                                                    <asp:BoundField DataField="Descripcion" />
                                                    <asp:BoundField DataField="Id_Concepto" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <HeaderStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblRefGen" runat="server" Font-Bold="True"></asp:Label>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Cliente" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:GridView ID="grvInventarioAgregado" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay oficios registrados" OnPageIndexChanging="grvInventarioAgregado_PageIndexChanging" OnRowCancelingEdit="grvInventarioAgregado_RowCancelingEdit" OnRowEditing="grvInventarioAgregado_RowEditing" OnRowUpdating="grvInventarioAgregado_RowUpdating" Width="100%" ShowFooter="True" OnRowDeleting="grvInventarioAgregado_RowDeleting">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <%--                                                                                            <asp:BoundField HeaderText="Costo" DataField="Costo" DataFormatString="{0:c}" />--%>
                                                    <asp:BoundField DataField="No_Inventario" HeaderText="# Inventario" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Clave" HeaderText="# Arete" ReadOnly="True" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" ReadOnly="True" />
                                                    <asp:BoundField DataField="Poliza" HeaderText="# Póliza" ReadOnly="True" />
                                                    <asp:BoundField DataField="Costo" HeaderText="Costo" />
                                                    <asp:TemplateField HeaderText="Unidad de Medida">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="DDLUnidadMedida" runat="server" OnSelectedIndexChanged="DDLUnidadMedida_SelectedIndexChanged" Enabled="False">
                                                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                <asp:ListItem Value="1">Kilo(s)</asp:ListItem>
                                                                <asp:ListItem Value="2">Litro(s)</asp:ListItem>
                                                                <asp:ListItem Value="3">Pieza(s)</asp:ListItem>
                                                                <asp:ListItem Value="4">Servicio(s)</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCantidad" runat="server" Enabled="False">1</asp:TextBox><br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*Requerido">*Requerido</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCantidad" SetFocusOnError="True" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$">*Formato (999,999,999.99) 
                                                                                                                    Números</asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotU" runat="server" Text="0"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True" />
                                                    <asp:TemplateField>
                                                        <FooterTemplate>&nbsp;&nbsp;<asp:Label ID="lblTotal0" runat="server" Font-Bold="True" Font-Size="Medium" Text="TOTAL:"></asp:Label><asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Size="Medium" Text="0"></asp:Label></FooterTemplate>
                                                        <HeaderTemplate>
                                                            <asp:Button ID="bttnPagar" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnPagar_Click" Text="GENERAR REFERENCIA" Enabled="False" ValidationGroup="Cliente" ToolTip="Tienes que asignar un monto para poder habilitar el botón PAGAR." />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkEliminar" runat="server" CommandName="Delete">Eliminar</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Total" />
                                                    <asp:BoundField DataField="Unidad_Medida" />
                                                    <asp:BoundField DataField="Cantidad" />
                                                    <asp:BoundField DataField="Tipo" />
                                                    <asp:BoundField DataField="Concepto" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <HeaderStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                                        </div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Height="65px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="SALIR" />
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hddnTotal" runat="server" />
                                    <asp:Panel ID="pnl_Alert" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                        <table width="100%">
                                            <tr>
                                                <td align="left">&nbsp;</td>
                                                <td>
                                                    <div class="titulo_pop">
                                                        AVISO
                                                    </div>
                                                    <center>
                                                                                                                        </center>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;</td>
                                                <td align="center">¿Esta seguro de eliminar los productos agregados ? </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;</td>
                                                <td align="center">
                                                    <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel227">
                                                        <ProgressTemplate>
                                                            <div class="overlay">
                                                                <div class="overlayContent">
                                                                    <asp:Image ID="Image13" runat="server" Height="19px" ImageUrl="~/Imagenes/loader.gif" Width="220px" />
                                                                </div>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:UpdatePanel ID="UpdatePanel227" runat="server">
                                                        <ContentTemplate>
                                                            &nbsp;<asp:Button ID="btnSi" runat="server" CssClass="btn btn-info" OnClick="btnSi_Click" Text="SI" />
                                                            &nbsp;<asp:Button ID="btnNo" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="NO" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:HiddenField ID="hddnPagar" runat="server" />
        <asp:HiddenField ID="hddnBuscaCliente" runat="server" />
        <ajaxToolkit:ModalPopupExtender ID="modalPagar" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlForma_Pago" TargetControlID="hddnPagar">
        </ajaxToolkit:ModalPopupExtender>
        <ajaxToolkit:ModalPopupExtender ID="modalClientes" runat="server" BackgroundCssClass="modalBackground_Proy" TargetControlID="hddnBuscaCliente" PopupControlID="pnlCatClientes">
        </ajaxToolkit:ModalPopupExtender>
        <div class="row">
            <div class="col">
                <asp:Panel ID="pnlForma_Pago" runat="server" CssClass="card bg-dark text-white" Width="50%">
                    <div class="card-header font-weight-bold">
                        Métodos de Pago
                    </div>
                    <div class="card-body">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-3">
                                    REFERENCIA
                                </div>
                                <div class="col-md-9">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblRefGenerada" runat="server" Font-Bold="True"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 text-center">
                                    <asp:ImageButton ID="imgBttnPagoEfec" runat="server" ImageUrl="~/Imagenes/formaPago_Efectivo.png" OnClick="imgBttnPagoEfec_Click" />
                                </div>
                                <div class="col-md-6 text-center">
                                    <asp:ImageButton ID="imgBttnPagoTDC" runat="server" ImageUrl="~/Imagenes/formaPago_TDC.png" OnClick="imgBttnPagoTDC_Click" />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 text-center font-weight-bold">
                                    PAGO EN EFECTIVO
                                </div>
                                <div class="col-md-6 text-center font-weight-bold">
                                    CRÉDITO Ó DÉBITO/CLABE INTERBANCARIA
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-center">
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-info" Height="45px" OnClick="btnPagar_Click" Text="PAGAR" Visible="False" />
                                            &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btnCancelar_C_Click" Text="SALIR" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Panel ID="pnlCatClientes" runat="server" CssClass="TituloModalPopupMsg" Width="50%">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style16" colspan="3">
                                <div class="titulo_pop">
                                    Clientes
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">&nbsp;</td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="txtBuscaCliente" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td width="20%">
                                <asp:ImageButton ID="imgBttnBuscarCatCliente" runat="server" Height="35px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" Width="35px" OnClick="imgBttnBuscarCatCliente_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">&nbsp;</td>
                            <td align="left" width="60%">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvClientes" runat="server" AllowPaging="True" OnPageIndexChanging="grvClientes_PageIndexChanging" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%" OnSelectedIndexChanged="grvClientes_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Matricula" HeaderText="# Cliente" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Descripción">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                                <asp:BoundField DataField="Esquema" HeaderText="Esquema" />
                                                <asp:CommandField ShowSelectButton="True" SelectText="Agregar" />
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <HeaderStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="20%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">&nbsp;</td>
                            <td align="center" width="60%">&nbsp;</td>
                            <td width="20%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">&nbsp;</td>
                            <td align="center" width="60%">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        &nbsp;<asp:Button ID="btnAgregar_Cliente" runat="server" CssClass="btn btn-info" Height="45px" Text="AGREGAR" OnClick="btnAgregar_Cliente_Click" Visible="False" />
                                        &nbsp;<asp:Button ID="btnCancelar_CatClientes" runat="server" CssClass="btn btn-blue-grey" Height="45px" Text="SALIR" OnClick="btnCancelar_CatClientes_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="20%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="20%">&nbsp;</td>
                            <td align="center" width="60%">&nbsp;</td>
                            <td width="20%">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="mp_account" runat="server" Value="MPACCO" />

                        <asp:HiddenField ID="mp_product" runat="server" Value="mpproduct" />
                        <asp:HiddenField ID="mp_order" runat="server" Value="mporder" />
                        <asp:HiddenField ID="mp_reference" runat="server" Value="mpreference" />
                        <asp:HiddenField ID="mp_node" runat="server" Value="mpnode" />
                        <asp:HiddenField ID="mp_concept" runat="server" Value="mpconcept" />
                        <asp:HiddenField ID="mp_amount" runat="server" Value="mpamount" />
                        <asp:HiddenField ID="mp_customername" runat="server" Value="mpcustomername" />
                        <asp:HiddenField ID="mp_currency" runat="server" />
                        <asp:HiddenField ID="mp_signature" runat="server" />
                        <asp:HiddenField ID="mp_urlsuccess" runat="server" />
                        <asp:HiddenField ID="mp_urlfailure" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //$(function () {
        //    $('[data-toggle="tooltip"]').tooltip()
        //})

        function openPopoverPDF() {
            $('#ctl00_MainContent_grdDatosFactura_ctl12_imgBttnReporte').tooltip();
        };


        function openPopoverEXCEL() {
            $('#ctl00_MainContent_grdDatosFactura_ctl12_imgBttnExportar').tooltip();
        };



    </script>
    <script src="../Scripts/jsQR.js"></script>
    <script src="../Scripts/QRModel.js"></script>
    <script src="../Scripts/popper.js"></script>
</asp:Content>
