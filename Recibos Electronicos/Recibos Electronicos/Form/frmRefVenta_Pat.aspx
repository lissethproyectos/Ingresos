<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRefVenta_Pat.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRefVenta_Pat" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="https://sysweb.unach.mx/INGRESOS/Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <script src="https://sysweb.unach.mx/INGRESOS/Scripts/select2/js/select2.min.js"></script>
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />


    <script type="text/javascript">
        function PagBancomer() {
            $('#<%= mp_account.ClientID %>').attr("name", "mp_account");
            alert($('input[name=mp_account]').val());
            $('#<%= mp_product.ClientID %>').attr("name", "mp_product");
            $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
            $('#<%= mp_reference.ClientID %>').attr("name", "mp_reference");
            $('#<%= mp_node.ClientID %>').attr("name", "mp_node");
            $('#<%= mp_concept.ClientID %>').attr("name", "mp_concept"); Obt_Grid_Cat_Clientes
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

    <style type="text/css">
        .btn-app {
            color: white;
            box-shadow: none;
            border-radius: 3px;
            position: relative;
            padding: 10px 15px;
            margin: 0;
            min-width: 40px;
            /*            max-width: 60px;
*/ text-align: center;
            border: 1px solid #ddd;
            background-color: #f4f4f4;
            font-size: 10px;
            transition: all .2s;
            background-color: steelblue !important;
        }

            .btn-app > .fa, .btn-app > .glyphicon, .btn-app > .ion {
                font-size: 20px;
                display: block;
            }

            .btn-app:hover {
                border-color: #aaa;
                transform: scale(1.1);
            }

        .pdf {
            background-color: #5e5e5e !important;
            /*background-color: #dc2f2f !important;*/
        }

        .excel {
            background-color: #3ca23c !important;
        }

        .csv {
            background-color: #a48829 !important;
        }

        .imprimir {
            background-color: #8766b1 !important;
        }
    </style>
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
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-2">
                                            Dependencia
                                        </div>
                                        <div class="col-md-10">
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLDependencia" runat="server" ClientIDMode="Predictable" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="* Seleccionar Dependencia" InitialValue="00000" ValidationGroup="GenRef">*</asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                     <%--   <div class="col-md-2">
                                            Status
                                        </div>
                                        <div class="col-md-2">
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLPagado" runat="server">
                                                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                        <asp:ListItem Value="S">PAGADOS</asp:ListItem>
                                                        <asp:ListItem Value="N">SIN PAGAR</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>--%>
                                        <div class="col-md-2">
                                            Fecha Inicial
                                        </div>
                                        <div class="col-md-2">
                                           
                                            <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>                                                    
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                  
                                        </div>
                                        <div class="col-md-2">
                                            Fecha Final
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtBuscaRef" runat="server" PlaceHolder="Referencia/Folio" Width="100%"></asp:TextBox>
                                            </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="linkBttnBuscarRef" runat="server" CssClass="btn btn-primary" OnClick="linkBttnBuscarRef_Click" Width="100%">Ver Referencias</asp:LinkButton>
                                            </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:HiddenField ID="hddnModal" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modal" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlDetalle" TargetControlID="hddnModal"></ajaxToolkit:ModalPopupExtender>
                                        </div>
                                    </div>
                                    <%--<div class="row">
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtBuscaRef" runat="server" PlaceHolder="Referencia/Folio" Width="98%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:ImageButton ID="bttnBuscaRef" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="bttnBuscaRef_Click" ValidationGroup="Busca" />
                                        </div>
                                    </div>--%>
                                    <div class="row">
                                        <div class="col">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="GenRef" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdDatosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" DataKeyNames="ID_FACT" EmptyDataText="No existen registros." OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" Width="100%" ShowHeaderWhenEmpty="True" ShowFooter="True" PageSize="11">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID" />
                                                            <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depcia" SortExpression="DEPENDENCIA" />
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
                                                                <ItemStyle HorizontalAlign="Center" Height="20%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Button ID="bttnGenerarRef" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnGenerarRef_Click" Text="NUEVA REFERENCIA" ValidationGroup="GenRef" Width="144px" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="bttnReimprimir" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE1") %>' Width="85px" CommandName="Select"><i class="fa fa-usd" aria-hidden="true"></i>
                                                                    &#160;Pagar</asp:LinkButton>&nbsp;
                                                                    <asp:LinkButton ID="bttnEliminar" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" OnClick="bttnEliminar_Click" Visible='<%# Bind("VISIBLE1") %>' Width="85px" OnClientClick="return confirm('¿Eliminar registro?');"><i class="fa fa-trash" aria-hidden="true"></i> Eliminar</asp:LinkButton><%--<asp:Button ID="bttnReimprimir" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Text="Pagar" Visible='<%# Bind("VISIBLE1") %>' Width="57px" OnClick="bttnReimprimir_Click" />&nbsp;<asp:Button ID="bttnEliminar" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" OnClick="bttnEliminar_Click" Text="Eliminar" Visible='<%# Bind("VISIBLE1") %>' Width="57px" OnClientClick="return confirm('¿Eliminar registro?');" />--%>
                                                                    <asp:LinkButton ID="bttnVerRecibo" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE2") %>' Width="190px" OnClick="bttnVerRecibo_Click"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PAGADO" />
                                                            <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="bttnReimprimirUsu6" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE1") %>' Width="85px" OnClick="bttnReimprimir_Click"><i class="fa fa-usd" aria-hidden="true"></i> Pagar</asp:LinkButton><asp:LinkButton ID="bttnVerReciboUsu6" runat="server" CssClass="btn btn-mdb-color" Font-Size="X-Small" Visible='<%# Bind("VISIBLE2") %>' Width="190px" OnClick="bttnVerRecibo_Click"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
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
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:ImageButton ID="imgBttnReporte" runat="server" data-placement="left" data-toggle="tooltip" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" title="(PDF) Aplica únicamente a pagos confirmados." />
                                            &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" data-placement="top" data-toggle="tooltip" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" title="(EXCEL) Aplica únicamente a pagos confirmados." />
                                        </div>
                                    </div>
                                    <div id="rowRep" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Button ID="bttnRegresar" runat="server" Text="Regresar" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">

                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor" style="height: 500px" width="100%"></iframe>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlDetalle" runat="server" CssClass="TituloModalPopupMsg" Width="50%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td width="20%">&nbsp;</td>
                                                <td align="center" width="60%">&nbsp;</td>
                                                <td width="20%">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style17" colspan="3">
                                                    <asp:GridView ID="grvDetPago" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%">
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
                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="container">
                                    <hr>
                                    <div class="row">
                                        <div class="col">
                                            <h4 class="secondary-heading">
                                                <asp:Label ID="lblLeyDependencia" runat="server" Text=""></asp:Label>
                                            </h4>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <section class="mx-2 pb-3">


                                                <ajaxToolkit:TabContainer ID="tabReg" runat="server" ActiveTabIndex="1" Width="100%" ScrollBar="Vertical">
                                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                        <HeaderTemplate>
                                                            <i class="fa fa-user-circle fa-2x" aria-hidden="true"></i>Datos del Cliente
                                                        </HeaderTemplate>
                                                        <ContentTemplate>

                                                            <div class="row">
                                                                <div class="col-md-2">Tipo</div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlNivelBusqueda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNivelBusqueda_SelectedIndexChanged" Width="100%">
                                                                                <asp:ListItem Value="X">Clientes de la Dependencia</asp:ListItem>
                                                                                <asp:ListItem Value="T">Alumnos y Clientes de la UNACH</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:LinkButton ID="linkBttnNuevoCliente" runat="server" Width="100%" CssClass="btn btn-primary" OnClick="linkBttnNuevoCliente_Click"><i class="fa fa-plus-square" aria-hidden="true"></i> Nuevo</asp:LinkButton>
                                                                </div>
                                                            </div>
                                                            <asp:UpdatePanel ID="updPnlAlumno" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="row" id="rowBuscaAlumno" runat="server" visible="False">
                                                                        <div class="col-md-2">Filtro</div>
                                                                        <div class="col-md-10">
                                                                            <div class="input-group">
                                                                                <asp:TextBox ID="txtBuscaCliente" runat="server" Width="85%" PlaceHolder="Nombre, paterno, materno ó matricula"></asp:TextBox>
                                                                                <span class="input-group-addon" style="width: 15%">
                                                                                    <asp:LinkButton ID="linkBttnBuscCli" runat="server" CssClass="btn btn-info" OnClick="linkBttnBuscCli_Click" Width="100%" ValidationGroup="BuscaCli"> <i class="fa fa-search" aria-hidden="true"></i>Buscar
                                                                                    </asp:LinkButton>
                                                                                </span>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* El nombre del cliente requerido (primer pestaña)." ValidationGroup="BuscaCli" ControlToValidate="txtBuscaCliente">* Requerido</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" id="rowAlumno" runat="server" visible="False">
                                                                        <div class="col-md-2">
                                                                            Ficha/Matricula/Cve
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div class="input-group">
                                                                                <asp:TextBox ID="txtClaveSysweb" runat="server" CssClass="form-control"
                                                                                    TabIndex="2" MaxLength="9" CausesValidation="True"
                                                                                    ValidationGroup="gpoBusca"></asp:TextBox>
                                                                                <asp:UpdatePanel ID="UpdMatricula" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <span class="input-group-addon">
                                                                                            <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click">                                                                   
                                                                        <i class="fa fa-search" aria-hidden="true"></i> Buscar
                                                                                            </asp:LinkButton>
                                                                                        </span>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClaveSysweb" ErrorMessage="* El número del cliente es requerido." ValidationGroup="Cliente">* Requerido</asp:RequiredFieldValidator>
                                                                        </div>
                                                                        <div class="col-md-1">
                                                                            Nivel
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <asp:UpdatePanel ID="UpdatePanel228" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:DropDownList ID="ddlNivelE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivelE_SelectedIndexChanged" Width="100%">
                                                                                        <asp:ListItem Value="N">Ninguno</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" id="rowCliente" runat="server">
                                                                        <div class="col-md-2">
                                                                            Cat Clientes
                                                                        </div>
                                                                        <div class="col-md-8">
                                                                            <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:DropDownList ID="DDLCatClientes" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="DDLCatClientes_SelectedIndexChanged" ValidationGroup="Cliente"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DDLCatClientes" InitialValue="0" ErrorMessage="RequiredFieldValidator" ValidationGroup="Cliente"></asp:RequiredFieldValidator>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>

                                                                    </div>

                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    Cliente
                                                                </div>
                                                                <div class="col-md-8">
                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="lblClienteNombre" runat="server" Enabled="false" Width="100%" Font-Bold="True" Font-Size="15px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="reqNombreCliente" runat="server" ErrorMessage="* El nombre del cliente requerido." ValidationGroup="Cliente" ControlToValidate="lblClienteNombre">* Requerido</asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel16">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="Image855" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>


                                                        </ContentTemplate>
                                                    </ajaxToolkit:TabPanel>
                                                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                        <HeaderTemplate>
                                                            <i class="fa fa-money fa-2x" aria-hidden="true"></i>Datos de la Venta
                                                        </HeaderTemplate>
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    Tipo de Venta
                                                                </div>
                                                                <div class="col-md-5">
                                                                    <customControl:GroupDropDownList ID="DDLTipoVenta" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoVenta_SelectedIndexChanged" Width="100%"></customControl:GroupDropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DDLTipoVenta" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="BuscaInventario">* Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row" id="rowNumInv" runat="server">
                                                                <div class="col-md-2">
                                                                    Descripción/# Inventario
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtBuscarInv" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:LinkButton ID="linkBttnBuscarInv" runat="server" CssClass="btn btn-primary" OnClick="linkBttnBuscarInv_Click">Buscar</asp:LinkButton>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:UpdatePanel ID="updPnlInventario" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="grvInventario" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay productos/servicios registrados" OnSelectedIndexChanged="grvInventario_SelectedIndexChanged" OnPageIndexChanging="grvInventario_PageIndexChanging" Width="100%" AllowPaging="True">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="No_Inventario" HeaderText="# Inventario">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Clave" HeaderText="# Arete" />
                                                                                    <asp:TemplateField HeaderText="Descripción">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGrupo" runat="server" Text="DESCRIPCIÓN "></asp:Label><asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged"></asp:DropDownList>
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
                                                                                    <asp:TemplateField ShowHeader="False">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Agregar"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Id_Inventario" />
                                                                                    <asp:BoundField DataField="Descripcion" />
                                                                                    <asp:BoundField DataField="Id_Concepto" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <HeaderStyle CssClass="enc" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
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
                                                                    <asp:GridView ID="grvInventarioAgregado" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay registros." OnPageIndexChanging="grvInventarioAgregado_PageIndexChanging" OnRowCancelingEdit="grvInventarioAgregado_RowCancelingEdit" OnRowEditing="grvInventarioAgregado_RowEditing" OnRowUpdating="grvInventarioAgregado_RowUpdating" Width="100%" ShowFooter="True" OnRowDeleting="grvInventarioAgregado_RowDeleting">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
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
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*Requerido">*Requerido</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCantidad" SetFocusOnError="True" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$">*Formato (999,999,999.99) 
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
                                                                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                                                                </div>
                                                                <div class="col-md-10">
                                                                    <asp:TextBox ID="txtObservaciones" runat="server" Height="65px" TextMode="MultiLine"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                        </ContentTemplate>
                                                    </ajaxToolkit:TabPanel>
                                                </ajaxToolkit:TabContainer>
                                            </section>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:HiddenField ID="hddnCambiaTipo" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="modalTipo" runat="server" TargetControlID="hddnCambiaTipo" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnl_Alert"></ajaxToolkit:ModalPopupExtender>

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

    <div class="modal fade" id="modalPago" tabindex="-1" role="dialog" aria-labelledby="exampleModalPago" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modPago">Forma de Pago</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRefGenerada" runat="server" Font-Bold="True"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 text-center">
                                <asp:UpdatePanel ID="updPnlBttnGenPDF" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnGenPDF" runat="server" CssClass="btn btn-info  buttons-pdf buttons-html5 btn-app export csv" OnClick="linkBttnGenPDF_Click"><i class="fa fa-file fa-2x" aria-hidden="true"></i>Generar Referencia</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                            
                            <div class="col-md-4 text-center">
                                <asp:UpdatePanel ID="updPnlBttnPagoLinea" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnPagoLinea" runat="server" CssClass="btn btn-info  buttons-pdf buttons-html5 btn-app export pdf" OnClick="linkBttnPagoLinea_Click"><i class="fa fa-id-card fa-2x" aria-hidden="true"></i>Pago en Línea</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-4 text-center">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnGenLink" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export excel" OnClick="linkBttnGenLink_Click"><i class="fa fa-bars fa-2x"></i>Link pago en Línea</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlPago" runat="server">
                                    <ContentTemplate>
                                        <asp:HyperLink ID="linkPago" runat="server"></asp:HyperLink>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrPago" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgPrecargaLinkPago" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updgrBttnGenPDF" runat="server" AssociatedUpdatePanelID="updPnlBttnGenPDF">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgGenPDF" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrBttnPagoLinea" runat="server" AssociatedUpdatePanelID="updPnlBttnPagoLinea">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgPagoLinea" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col text-center">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-info" Height="45px" Text="PAGAR" Visible="False" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalCatClientes" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modCatClientes">Catálogo de Clientes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-1">Filtrar</div>
                            <div class="col-md-6">
                                <%--<asp:TextBox ID="txtBuscaCliente" runat="server" Width="100%"></asp:TextBox>--%>
                            </div>
                            <div class="col-md-2">
                                <asp:ImageButton ID="imgBttnBuscarCatCliente" runat="server" Height="35px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" Width="35px" OnClick="imgBttnBuscarCatCliente_Click" />
                            </div>
                        </div>
                        <div runat="server" id="rowAgregar" visible="false">
                            <div class="row">
                                <div class="col">
                                    <asp:LinkButton ID="linkBttnAgregarCliente" runat="server" CssClass="btn btn-primary">Agregar</asp:LinkButton>
                                </div>
                            </div>
                            <div class="row" id="rowAgregarCliente">
                                <div class="col-md-2">Cliente</div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2"></div>
                            </div>
                        </div>
                        <div class="row" style="height: 400px; overflow-y: scroll;">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvClientes" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" Width="100%" OnSelectedIndexChanged="grvClientes_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="Matricula" HeaderText="# Cliente" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Descripción">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                                <asp:BoundField DataField="Esquema" HeaderText="Esquema" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" CssClass="btn btn-dark" Text="Seleccionar"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <HeaderStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalAddClientes" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modCatClientes">Catálogo de Clientes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                Nivel
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTipoCli" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCli_SelectedIndexChanged">
                                            <asp:ListItem Value="Z">--Seleccionar--</asp:ListItem>
                                            <asp:ListItem Value="X">Cliente UNACH</asp:ListItem>
                                            <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                                            <asp:ListItem Value="E">Especialidad</asp:ListItem>
                                            <asp:ListItem Value="M">Maestria</asp:ListItem>
                                            <asp:ListItem Value="D">Doctorado</asp:ListItem>
                                            <asp:ListItem Value="N">Lenguas Extranjeras</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="reqTipoCli" runat="server" ErrorMessage="*Nivel" ValidationGroup="GuadarCli" InitialValue="Z" Text="*Nivel" ControlToValidate="ddlTipoCli"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="rowNombre" visible="false">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtNombreCliente" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:RequiredFieldValidator ID="reqNom" runat="server" ErrorMessage="*Nombre" Text="*" ControlToValidate="txtNombreCliente" ValidationGroup="GuadarCli">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="updPnlPat" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="rowPaterno" visible="false">
                                    <div class="col-md-2">
                                        Paterno
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPaterno" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:RequiredFieldValidator ID="reqPat" runat="server" ErrorMessage="*Paterno" Text="*" ControlToValidate="txtPaterno" ValidationGroup="GuadarCli">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="updPnlMat" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="rowMaterno" visible="false">
                                    <div class="col-md-2">
                                        Materno
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtMaterno" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:RequiredFieldValidator ID="reqMat" runat="server" ErrorMessage="*Materno" Text="*" ControlToValidate="txtMaterno" ValidationGroup="GuadarCli">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="updPnlCorreo" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="rowCorreo" visible="false">
                                    <div class="col-md-2">Correo</div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:RequiredFieldValidator ID="reqCorreo" runat="server" ErrorMessage="*Correo" Text="*" ControlToValidate="txtCorreo" ValidationGroup="GuadarCli">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="updPnlGen" runat="server">
                            <ContentTemplate>
                                <div class="row" runat="server" id="rowGenero" visible="false">
                                    <div class="col-md-2">Género</div>
                                    <div class="col-md-10">
                                        <asp:RadioButtonList ID="rdoGenero" runat="server" RepeatDirection="Horizontal" TabIndex="12">
                                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col">
                                <asp:ValidationSummary ID="valCli" runat="server" ValidationGroup="GuadarCli" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linBttnGuardarCliente" runat="server" CssClass="btn btn-primary" OnClick="linBttnGuardarCliente_Click" ValidationGroup="GuadarCli">Guardar</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row alert alert-danger">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlError" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblErrorReg" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function Referencias() {
            $('#<%= grdDatosFactura.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdDatosFactura.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "order": [[1, "desc"]]
            });
        };

        function CatInventario() {
            $('#<%= grvInventario.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvInventario.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "order": [[1, "desc"]]
            });
        };

        function CatClientes() {
            $('#<%= grvClientes.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvClientes.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function FiltClientes() {
            $('#<%= DDLCatClientes.ClientID %>').select2();
        };

    </script>
    <script type="text/javascript" src="../Scripts/jsCodigoQR.js"></script>
    <script type="text/javascript" src="../Scripts/QRModel.js"></script>
</asp:Content>
