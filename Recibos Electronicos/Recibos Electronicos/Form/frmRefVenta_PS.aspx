<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRefVenta_PS.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRefVenta_PS" %>

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

        .salir {
            background-color: #444343 !important;
        }

        .imprimir {
            background-color: #66b1b0 !important;
        }

        .input-group-text {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            padding: 0.275rem 0.75rem;
            margin-bottom: 0;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            text-align: center;
            white-space: nowrap;
            background-color: #e9ecef;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
        }

        .scroll_cat {
            max-height: 200px;
            overflow: auto;
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
                                        <div class="col-md-1">
                                            Depcia
                                        </div>
                                        <div class="col-md-11">
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
                                        <div class="col-md-1">
                                            Fecha Inicial
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </div>
                                        <div class="col-md-1">
                                            Fecha Final
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtBuscaRef" runat="server" PlaceHolder="Referencia/Folio" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:LinkButton ID="linkBttnBuscarRef" runat="server" CssClass="btn btn-primary" OnClick="linkBttnBuscarRef_Click" Width="100%">Ver Referencias</asp:LinkButton>
                                        </div>
                                    </div>
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



                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col">
                                            <h6 class="text font-weight-bold">
                                                <asp:Label ID="lblLeyDependencia" runat="server" Text=""></asp:Label>
                                            </h6>
                                        </div>
                                    </div>
                                    <h6 class="text text-dorado font-weight-bold"><i class="fa fa-user fa-2x" aria-hidden="true"></i>Cliente</h6>
                                    <hr>

                                    <div class="row">
                                        <div class="col-md-1">Tipo</div>
                                        <div class="col-md-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNivelBusqueda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNivelBusqueda_SelectedIndexChanged" CssClass="form-control">
                                                        <asp:ListItem Value="X">Clientes de la Dependencia</asp:ListItem>
                                                        <asp:ListItem Value="T">Alumnos y Clientes de la UNACH</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div id="rowAlumno" runat="server" class="col-md-8" visible="False">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    Ficha/Mat/Cve
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtClaveSysweb" runat="server" CssClass="form-control"
                                                            TabIndex="2" MaxLength="9" CausesValidation="True"
                                                            ValidationGroup="gpoBusca"></asp:TextBox>
                                                        <asp:UpdatePanel ID="UpdMatricula" runat="server">
                                                            <ContentTemplate>
                                                                <span class="input-group-addon">
                                                                    <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click"> <i class="fa fa-search" aria-hidden="true"></i>Buscar
                                                                    </asp:LinkButton>
                                                                </span>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="req3" runat="server" ControlToValidate="txtClaveSysweb" ErrorMessage="* El número del cliente es requerido." ValidationGroup="Cliente">* Requerido</asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-1">
                                                    Nivel
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:UpdatePanel ID="UpdatePanel228" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlNivelE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivelE_SelectedIndexChanged" Width="100%">
                                                                <asp:ListItem Value="N">Ninguno</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="rowCliente" class="col-md-8" runat="server">
                                            <div class="row">
                                                <div class="col-md-1">
                                                    Clientes
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLCatClientes" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDLCatClientes_SelectedIndexChanged" ValidationGroup="Pago" AutoPostBack="True"></asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:LinkButton ID="linkBttnAgregarCliente" runat="server" CssClass="form-control btn btn-info text-white"><i class="fa fa-plus-circle"></i> Nuevo</asp:LinkButton>
                                                </div>

                                                <div class="col-md-1">
                                                    <asp:RequiredFieldValidator ID="reqCliente" runat="server" ControlToValidate="DDLCatClientes" InitialValue="0" ErrorMessage="*Cliente requerido" ValidationGroup="Pago">*Cliente requerido</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1">
                                            Comprador
                                        </div>
                                        <div class="col-md-10">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="lblClienteNombre" runat="server" CssClass="alert alert-light" Enabled="false" Width="100%" Font-Bold="True" Font-Size="15px"></asp:TextBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="* El nombre del cliente requerido." ValidationGroup="Cliente" ControlToValidate="lblClienteNombre">*</asp:RequiredFieldValidator>
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
                                    <h6 class="text text-dorado font-weight-bold"><i class="fa fa-shopping-cart fa-2x" aria-hidden="true"></i>Productos</h6>
                                    <hr>
                                    <div class="row needs-validation">
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                Productos                                               
                                                <asp:DropDownList ID="DDLProductos" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DDLProductos_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="form-row">
                                                <div class="form-group col-md-6">
                                                    Cantidad
                                                <asp:TextBox ID="txtCantidad_Prod" runat="server" CssClass="form-control" onChange="focus_unidad()"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    Unidad
                                                <asp:DropDownList ID="DDLUnidadMedidaProd" runat="server" CssClass="form-control" onBlur="focus_precio()">
                                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="1">Kilo(s)</asp:ListItem>
                                                    <asp:ListItem Value="2">Litro(s)</asp:ListItem>
                                                    <asp:ListItem Value="3">Pieza(s)</asp:ListItem>
                                                    <asp:ListItem Value="4">Servicio(s)</asp:ListItem>
                                                    <asp:ListItem Value="5">Bien</asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
                                            </div>
                                            <label for="basic-url" class="form-label">Precio</label>
                                            <div class="input-group mb-3">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" onChange="focus_agregar()"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <span id="basic-addon3">
                                                    <asp:LinkButton ID="linkBttnAgregarProd" runat="server" CssClass="input-group-text" OnClick="linkBttnAgregarProd_Click" ValidationGroup="producto"> <i class="fa fa-plus-circle"></i> Agregar
                                                    </asp:LinkButton></span>
                                                <div visible="false" runat="server" id="rowErrorProd" class="alert alert-danger">
                                                    <asp:Label ID="lblErrorProd" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-7">
                                            <div class="row scroll_cat" style="height: 200px;">
                                                <div class="col">
                                                    <asp:UpdatePanel ID="updPnlProductosAgregados" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grvProductosAgregados" runat="server" AutoGenerateColumns="False" CssClass="mGrid table-striped" Width="100%" ShowFooter="True" EmptyDataText="Agregar productos o servicios al carrito." ShowHeaderWhenEmpty="True" OnRowDeleting="grvProductosAgregados_RowDeleting">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                                    <asp:BoundField DataField="Clave" HeaderText="Clave" />
                                                                    <asp:TemplateField HeaderText="Descripción">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <ItemStyle Width="70%" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Cantidad">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField ShowDeleteButton="True" />
                                                                    <asp:BoundField DataField="Id_Concepto" HeaderText="Id_Concepto">
                                                                        <ControlStyle CssClass="classHide" />
                                                                        <FooterStyle CssClass="classHide" />
                                                                        <HeaderStyle CssClass="classHide" />
                                                                        <ItemStyle CssClass="classHide" />
                                                                    </asp:BoundField>
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
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-10 text-right">
                                                    <h4 class="font-weight-bold">TOTAL</h4>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:Label ID="lblGranTotal" runat="server" Font-Bold="True" Font-Size="18pt" Text="$0.00"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblRefGen" runat="server" Font-Bold="True"></asp:Label>
                                                    <%--<asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Cliente" />--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <%--<div class="col-md-1">
                                        Observaciones
                                    </div>--%>
                                        <div class="col">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Height="65px" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Pago" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:UpdateProgress ID="updPgrSincroniza" runat="server"
                                                AssociatedUpdatePanelID="UpdatePanel15">
                                                <ProgressTemplate>
                                                    <span>
                                                        <img height="26" src="https://sysweb.unach.mx/Ingresos/Imagenes/load.gif" width="222" />
                                                    </span><span class="loading">
                                                    </span>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <%--<asp:LinkButton ID="linkBttnPagar" runat="server" CssClass="btn btn-success"><i class="fa fa-credit-card"></i> PAGAR</asp:LinkButton>--%>
                                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                <ContentTemplate>
                                                    &nbsp;<asp:LinkButton ID="btnCancelar" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export salir" OnClick="btnCancelar_Click"><i class="fa fa-arrow-circle-left"></i>Salir</asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="linkBttnPagar" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export excel" OnClick="linkBttnPagar_Click" ValidationGroup="Pago"><i class="fa fa-credit-card fa-2x"></i>Generar Referencia</asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="linkBttnNuevaRef" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export pdf" ValidationGroup="Pago" Visible="false" OnClick="linkBttnNuevaRef_Click"><i class="fa fa-credit-card fa-2x"></i>Nueva Referencia</asp:LinkButton>

                                                    &nbsp;<asp:LinkButton ID="linkBttnEnviar" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export imprimir" OnClick="linkBttnEnviar_Click" ValidationGroup="Pago" Visible="false"><i class="fa fa-envelope fa-2x"></i>Enviar referencia al correo</asp:LinkButton>

                                                    &nbsp;<asp:LinkButton ID="linkBttnReferencia" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export pdf" OnClick="linkBttnPagar_Click" ValidationGroup="Pago" Visible="False"><i class="fa fa-credit-card fa-2x"></i>Pago en Línea</asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="linkBttnPagoLinea" runat="server" class="btn btn-secondary buttons-pdf buttons-html5 btn-app export excel" OnClick="linkBttnPagar_Click" ValidationGroup="Pago" Visible="False"><i class="fa fa-credit-card fa-2x"></i>Enviar pago al correo</asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col"></div>
                                    </div>
                                    <br />
                                    <br />
                                    <asp:HiddenField ID="hddnTotal" runat="server" />
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
                            <div class="col alert alert-warning">
                                <h6><strong>IMPORTANTE: </strong>Recuerda que puedas compartir el link al cliente para que pueda realizar el pago en ventanilla o en línea.</h6>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnRedirectPagar" runat="server" CssClass="btn btn-info  buttons-pdf buttons-html5 btn-app export pdf" OnClick="linkBttnRedirectPagar_Click"><i class="fa fa-id-card fa-2x" aria-hidden="true"></i>Pagar</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- <div class="col-md-4 text-center">
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
                            </div>--%>
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
                        <%--<div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updgrBttnGenPDF" runat="server" AssociatedUpdatePanelID="updPnlBttnGenPDF">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgGenPDF" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>--%>
                        <%--<div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrBttnPagoLinea" runat="server" AssociatedUpdatePanelID="updPnlBttnPagoLinea">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgPagoLinea" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalPago2" tabindex="-1" role="dialog" aria-labelledby="exampleModalPago" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modPago2">Forma de Pago</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblRefGenerada2" runat="server" Font-Bold="True"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <div class="row alert alert-warning">
                            <div class="col">
                                Recuerda que puedes copiar el link y enviarlo al cliente para que pueda realizar su pago.
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Correo
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCorreoCliente" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rewCorreoCli" runat="server" ErrorMessage="*Correo" Text="*" ControlToValidate="txtCorreoCliente" ValidationGroup="Enviar">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-success" OnClick="linkBttnPagoLinea2_Click"><i class="fa fa-id-card fa-2x" aria-hidden="true"></i> Pagar</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-info" OnClick="linkBttnPagoLinea_Click" ValidationGroup="Enviar"><i class="fa fa-share fa-2x" aria-hidden="true"></i> Enviar forma de pago por correo</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
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

    <!-- Modal -->
    <div class="modal fade" id="modalEnviarCorreo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Enviar formas de pago a</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-2">Correo</div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtEMailCliente" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row alert alert-info">
                                <div class="col">
                                    <asp:Label ID="lblMensajeCorreo" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                <ContentTemplate>
                                    <button type="button" class="btn btn-grey" data-dismiss="modal">Cerrar</button>
                                    <asp:Button ID="bttnEnviarRef" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="bttnEnviarRef_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel22">
                                <ProgressTemplate>
                                    <asp:Image ID="imgEnvRef" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <%--<div class="modal" tabindex="-1" role="dialog" id="modalDetalle">--%>
    <div class="modal fade" id="modalDetalle" tabindex="-1" role="dialog" aria-labelledby="modalDetalleLabel" aria-hidden="true">

        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Detalle</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col text-center">
                            <asp:UpdateProgress ID="updPgrDet" runat="server" AssociatedUpdatePanelID="updPnlDet">
                                <ProgressTemplate>
                                    <asp:Image ID="imgDet" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="updPnlDet" runat="server">
                                <ContentTemplate>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Cerrar</button>
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

        function CatProductos() {
            $('#<%= DDLProductos.ClientID %>').select2();
        };

        $('#<%= DDLProductos.ClientID %>').click(function () {
            alert("paso");
        });
        function focus_unidad() {
            $('#<%= DDLUnidadMedidaProd.ClientID %>').focus();
        };
        function focus_precio() {
            $('#<%= txtPrecio.ClientID %>').focus();
        };
        function focus_agregar() {
            $('#<%= linkBttnAgregarProd.ClientID %>').focus();
        }
    </script>
    <script type="text/javascript" src="../Scripts/jsCodigoQR.js"></script>
    <script type="text/javascript" src="../Scripts/QRModel.js"></script>
</asp:Content>
