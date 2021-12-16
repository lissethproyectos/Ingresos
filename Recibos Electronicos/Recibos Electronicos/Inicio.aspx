<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Recibos_Electronicos.Inicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <style type="text/css">
        .nav-tabs .nav-link {
            border: 1px solid #f8f9fa;
            border-top-left-radius: .25rem;
            border-top-right-radius: .25rem;
            font-size: 13px;
        }

        .nav-tabs li a {
            padding: 8px 40px;
            border: 1px solid #ededed;
            border-top: 2px solid #dfdfdf;
            border-right: 0px none;
            background: #65635d;
            color: #fff;
            border-radius: 0px;
            margin-right: 0px;
            /* border-color: #cdcdcd; */
            font-weight: bold;
            transition: all 0.3s ease-in 0s;
        }

        .tab-content {
            padding: .5rem;
            /* padding-top: 2rem; */
            border-bottom-style: solid;
            border-left-style: solid;
            border-right-style: solid;
            border-width: thin;
            border-color: #cdcdcd;
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="precarga1" class="align-content-lg-center hidden"><input type="image" class="center" Height="50px" src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" />Cargando recibo...</div>--%>

    <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="multView" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <div style="overflow-x: auto; display: block;">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdStatus_Carga" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-sm" PageSize="3" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Etiqueta" DataFormatString="{0:d}" HeaderText="FICHAS PAGADAS DEL">
                                                        <HeaderStyle ForeColor="#333333" HorizontalAlign="Center" Font-Bold="True" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaTres" FooterText="SANTANDER" HeaderText="SANTANDER">
                                                        <FooterStyle HorizontalAlign="Center" />
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaSiete" FooterText="HSBC" HeaderText="HSBC">
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaCinco" FooterText="BANCOMER" HeaderText="BBVA">
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaDos" FooterText="BANAMEX" HeaderText="CITIBANAMEX">
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaCuatro" FooterText="BANORTE" HeaderText="BANORTE">
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaSiete" HeaderText="AZTECA">
                                                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" ForeColor="#333333" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EtiquetaSeis" FooterText="VISA/MASTERCARD" HeaderText="VISA">
                                                        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <RowStyle Font-Size="9px" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle Font-Size="9px" HorizontalAlign="Center" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="overflow-x: auto;">
                                    <asp:UpdatePanel ID="UpdatePanelGridMonitor" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdMonitor" runat="server"
                                                AutoGenerateColumns="False" OnPageIndexChanging="grdMonitor_PageIndexChanging"
                                                Width="100%" PageSize="20" CssClass="mGrid" OnRowDeleting="grdMonitor_RowDeleting" CellSpacing="1">
                                                <Columns>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="REVISAR">
                                                        <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Form/FrmExentos.aspx" Visible='<%# Bind("Habil") %>'>VER SOLICITUDES</asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EtiquetaDos" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkbttnEliminar" runat="server" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar el registro?');" Visible='<%# Bind("Inhabil") %>'>ELIMINAR</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EtiquetaTres" />
                                                    <asp:ImageField>
                                                    </asp:ImageField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <RowStyle Font-Bold="False" />
                                                <SelectedRowStyle CssClass="sel" />

                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                            <asp:HiddenField ID="hddnBancos" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modalBancos" runat="server" PopupControlID="pnlBancos" TargetControlID="hddnBancos" BackgroundCssClass="modalBackground_Proy" OkControlID="btnSalir">
                                            </ajaxToolkit:ModalPopupExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Pago en Ventanilla</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="pago-tdc" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Pago con Tarjeta de Crédito o Débito</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="nav-pago-cie" data-toggle="tab" href="#pago-cie" role="tab" aria-controls="pago-cie" aria-selected="false">Pago CIE</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="nav-pago-clabe" data-toggle="tab" href="#pago-clabe" role="tab" aria-controls="pago-clabe" aria-selected="false">Pago CLABE</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="nav-ayuda" data-toggle="tab" href="#ayuda" role="tab" aria-controls="ayuda" aria-selected="false"><i class="fa fa-question-circle-o" aria-hidden="true"></i>
                                            Ayuda</a>
                                    </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">El COMPROBANTE OFICIAL estará disponible al siguiente dia hábil, si el pago se realizó en Sábado ó Domingo, el COMPROBANTE OFICIAL estará disponible a partir del Martes inmediato, para días inhábiles, aplica el mismo criterio; el COMPROBANTE OFICIAL estará disponible un dia después al día hábil inmediato.</div>
                                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="pago-tdc">
                                        El COMPROBANTE OFICIAL estará disponible al momento de realizar el pago, si por algún motivo se cerro el portal de BANCOMER antes de re-direccionar a SYSWEB, SIAE ó ASPIRANTES, el comprobante oficial estara disponible al siguiente dia hábil.
                                    </div>
                                    <div class="tab-pane fade" id="pago-cie" role="tabpanel" aria-labelledby="pago-cie">
                                        El COMPROBANTE OFICIAL estará disponible hasta 72 hrs. hábiles después de haber realizado el pago en el banco que haya elegido para realizar el pago.
                                    </div>
                                    <div class="tab-pane fade" id="pago-clabe" role="tabpanel" aria-labelledby="pago-clabe">
                                        El COMPROBANTE OFICIAL estará disponible hasta 48 hrs hábiles después de haber realizado el pago.

                                    </div>
                                    <div class="tab-pane fade" id="ayuda" role="tabpanel" aria-labelledby="ayuda">
                                        Para dudas o aclaraciones al correo depfin@unach.mx ó sysweb@unach.mx.
                                    </div>

                                </div>
                                <%--<asp:Image ID="Image1" runat="server" ImageUrl='~/Imagenes/recibo3.png' Text="No"  Visible='<%# Bind("VISIBLE2") %>'/>--%>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="updPnlDep" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar" CssClass="alert alert-danger">*Elegir dependencia</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="updPnlDep">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgDep" runat="server" Height="25px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." Width="25px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%--<div id="precarga1" class="align-content-lg-center hidden"><input type="image" class="center" Height="50px" src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" />Cargando recibo...</div>--%>
                            <div class="col-md-4">
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia, folio ó nombre" Width="70%" Visible="true"></asp:TextBox>
                                    <div class="input-group-append">
                                        <span class="input-group-text_buscar" id="basic-addon2">
                                            <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                                                <ContentTemplate>
                                                    <button runat="server" id="bttnBuscar" onserverclick="bttnBuscar_Click" class="btn-buscar btn-primary" validationgroup="Buscar" style="width: 100%">
                                                        Ver Recibos
                                                    </button>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </span>
                                    </div>
                                </div>



                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPrgBuscar" runat="server" AssociatedUpdatePanelID="updPnlBuscar">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="alert alert-warning">
                                    <asp:HiddenField ID="hddnImagenQR" runat="server" />
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="text-center">
                                                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="row alert alert-danger" runat="server" id="divErrorTot" visible="false">
                            <div class="col">La consulta excede los 2000 registros, favor de realizar filtros para un correcto funcionamiento.</div>
                        </div>

                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgressFactura" runat="server" AssociatedUpdatePanelID="updPnlGridFacturas">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgPrecargaFact" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="overflow-x: auto;">
                                    <asp:UpdatePanel ID="updPnlGridFacturas" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdDatosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="ID_FACT" EmptyDataText="El banco no reporto pagos, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="20" ShowHeaderWhenEmpty="True" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                                    <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" />
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
                                                    <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep" SortExpression="DEPENDENCIA"></asp:BoundField>
                                                    <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Cve" />
                                                    <asp:TemplateField HeaderText="Enviar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" Visible="False" />
                                                            <asp:LinkButton ID="linkBttnCorreo" runat="server" OnClick="linkBttnCorreo_Click"><i class="fa fa-envelope fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ver" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Imagenes/recibo2.png" Text="Ver" Visible="False" />
                                                            <asp:LinkButton ID="linkBttnVerRecibo" runat="server" CommandName="Select"><i class="fa fa-file fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>' ForeColor="Black" Text="Editar"></asp:LinkButton>
                                                            <%--<asp:ImageButton AlternateText="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'
                                            ImageUrl="~/Imagenes/files_edit.png" ID="btnEditar" runat="server"></asp:ImageButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_CODIGO_QR" />
                                                    <asp:TemplateField HeaderText="Factura" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkVerFactura" runat="server" CssClass="btn btn-mdb-color" Visible='<%# Bind("VISIBLE1") %>' OnClick="linkVerFactura_Click"><i class="fa fa-file-pdf-o" aria-hidden="true"></i> Ver Factura</asp:LinkButton>
                                                            <asp:LinkButton ID="linkBttnSolicitar" runat="server" CssClass="btn btn-mdb-color" Visible='<%# Bind("VISIBLE2") %>' OnClick="linkBttnSolicitar_Click"><i class="fa fa-file-pdf-o" aria-hidden="true"></i> Solicitar</asp:LinkButton>
                                                            <%--                                            <asp:Label ID="lblSinFactura" runat="server" Text="NO" Visible='<%# Bind("VISIBLE2") %>'></asp:Label>--%>
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="card wizard-card ct-wizard-orange">
                        <br />
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-2">
                                    RFC
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="txtReceptor_Rfc" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                                        <%--<div class="input-group-append">
                                                        <span class="input-group-text_buscar" id="basic-addon2">
                                                            <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn-buscar btn-primary" OnClick="Button1_Click1" />
                                                        </span>
                                                    </div>--%>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    Persona
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                        <ContentTemplate>
                                            <asp:RadioButtonList ID="rdoBttnReceptorTipoPersona" runat="server" OnSelectedIndexChanged="rdoBttnReceptorTipoPersona_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="3" AppendDataBoundItems="True" AutoPostBack="True">
                                                <asp:ListItem Value="F">Fisica&#160;&#160;</asp:ListItem>
                                                <asp:ListItem Value="M">Moral</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:RequiredFieldValidator ID="valTipoPers" runat="server" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Tipo Persona" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Faltan datos</asp:CustomValidator>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-md-2">
                                    Razón Social
                                </div>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="3" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtReceptor_Nombre" ErrorMessage="*Razón Social" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Calle
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtReceptor_Domicilio" runat="server" MaxLength="500" TabIndex="4" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtReceptor_Domicilio" ErrorMessage="*Calle" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    Colonia
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="5" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Estado
                                </div>
                                <div class="col-md-3">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="6" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-1">
                                    Municipio
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="7" Width="100%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1 text-right">
                                    CP
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="8" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-2">
                                    Metodo de Pago
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlReceptor_MetodoPago" runat="server" TabIndex="9" Width="100%">
                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                        <asp:ListItem Value="PUE">[PUE] Pago en una sola exhibicion</asp:ListItem>
                                        <asp:ListItem Value="PPD">[PPD] Pago en parcialidades o diferido</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPago" ErrorMessage="*Método de Pago" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    Forma de Pago
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlForma_Pago" runat="server" TabIndex="10" Width="100%">
                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                        <asp:ListItem Value="01">[01] Efectivo</asp:ListItem>
                                        <asp:ListItem Value="02">[02] Cheque Nominativo</asp:ListItem>
                                        <asp:ListItem Value="03">[03] Transferencia Electrónica de Fondos</asp:ListItem>
                                        <asp:ListItem Value="04">[04] Tarjeta de Crédito</asp:ListItem>
                                        <asp:ListItem Value="12">[12] Dacion de Pago</asp:ListItem>
                                        <asp:ListItem Value="28">[28] Tarjeta de Débito</asp:ListItem>
                                        <asp:ListItem Value="29">[29] Tarjeta de Servicio</asp:ListItem>
                                        <asp:ListItem Value="99">[99] Por Definir</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valFP" runat="server" ControlToValidate="ddlForma_Pago" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Uso de CFDI
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlCFDI" runat="server" TabIndex="11" Width="100%">
                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                        <asp:ListItem Value="G01">Adquisición de mercancias</asp:ListItem>
                                        <asp:ListItem Value="G02">Devolución, descuento o bonificaciones</asp:ListItem>
                                        <asp:ListItem Value="G03">Gastos en general</asp:ListItem>
                                        <asp:ListItem Value="D04">Donativos</asp:ListItem>
                                        <asp:ListItem Value="P01">Por definir</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valCFDI" runat="server" ControlToValidate="ddlCFDI" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    Teléfono
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtReceptor_Telefono" runat="server" TabIndex="13" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    Email
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtReceptor_Correo" runat="server" TabIndex="14" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Inf del Pago
                                </div>
                                <div class="col-md-10">
                                    <div class="alert alert-info" id="rowInfAdicional" runat="server">

                                        <div class="row">
                                            <div class="col-md-2 font-weight-bold">
                                                Total
                                            </div>
                                            <div class="col-md-10">
                                                <asp:Label ID="lblImporte" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2 font-weight-bold">
                                                Conceptos
                                            </div>
                                            <div class="col-md-10">
                                                <asp:Label ID="lblConceptosFac" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Descripción
                                </div>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtDescConcepto" runat="server" CssClass="form-control" MaxLength="500" TabIndex="15" PlaceHolder="Detalle del concepto que se requiera en la factura" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-right">
                                    <asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-info" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="Solicitar Factura" ValidationGroup="DatosFiscales" />
                                    &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="15" Text="Salir" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hddnFactura" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="modalFactura" runat="server" TargetControlID="hddnFactura" PopupControlID="pnlDoctos" CancelControlID="bttnSalirDoctos" BackgroundCssClass="modalBackground_Proy">
    </ajaxToolkit:ModalPopupExtender>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm text-center">
                <div id="precarga1" class="auto-style4" style="width: 100%"></div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col text-center">
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-mdb-color" OnClick="btnRegresar_Click" Text="REGRESAR" Visible="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm text-center">
                <asp:UpdateProgress ID="updProg" runat="server" AssociatedUpdatePanelID="updPnl">
                    <ProgressTemplate>
                        <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm">
                <asp:UpdatePanel ID="updPnl" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlReciboOficial" runat="server">
                            <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                                style="height: 500px" width="100%"></iframe>
                        </asp:Panel>
                        <%--<div id="precarga1" class="align-content-lg-center hidden"><input type="image" class="center" Height="50px" src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" />Cargando recibo...</div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm">
                <usr:uCCorreo ID="PnlCorreo" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy" CancelControlID="btnCancelar0">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server" class="card text-white bg-dark mb-3" Width="500px">
        <div style="overflow-y: scroll; height: 200px;">
            <div class="card-header">
                AVISO
            </div>
            <div class="card-body">
                <h5 class="card-title"></h5>
                <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsg_Observaciones" runat="server" Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor" ForeColor="White" Font-Size="Medium"></asp:Label>
                        <asp:Button ID="btnCancelar0" runat="server" CssClass="btn btn-blue-grey" Text="Continuar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBancos" runat="server"
        Width="50%">
        <div class="card text-white bg-dark mb-3">
            <div class="card-header">
                IMPORTANTE
            </div>
            <div class="card-body">
                <h5 class="card-title">Si usted realizó su pago en ventanilla bancaria en las últimas 24 horas hábiles y en algunos de los siguientes bancos, es probable que aún no se encuentre su <a>Recibo Oficial</a>, si es así,favor de intentarlo más tarde.
                </h5>
                <div class="text-center">
                    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdStatus_Carga_Bancos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Etiqueta" HeaderText="BANCO" />
                                </Columns>
                                <FooterStyle CssClass="enc" />
                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" />
                                <SelectedRowStyle CssClass="sel" />
                                <HeaderStyle CssClass="enc" />
                                <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="text-center">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            &nbsp;&nbsp;<asp:Button ID="btnSalir" runat="server" CssClass="btn btn-blue-grey"
                                Text="Salir" OnClick="btnSalir_Click" />
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDoctos" runat="server" CssClass="TituloModalPopupMsg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Documentos</h5>
                <asp:LinkButton ID="linkBttnCerrarModal" runat="server"><span aria-hidden="true">&times;</span></asp:LinkButton>
            </div>
            <div class="modal-body">
                <div class="container">
                    <div class="row">
                        <div class="col text-center">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" BackColor="#CCCCCC" OnPageIndexChanging="grdDoctosFactura_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="FACT_TIPO" HeaderText="TIPO" />
                                            <asp:TemplateField HeaderText="ARCHIVO">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="linkDocto" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "RUTA_ADJUNTO") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "OFICIO") %></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <asp:Button ID="bttnSalirDoctos" runat="server" CssClass="btn btn-blue-grey" Text="SALIR" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <script type="text/javascript" src="Scripts/jsQR2.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
    <script type="text/javascript">
        function Recibos() {

            $('#<%= grdDatosFactura.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdDatosFactura.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true
            });

        }
        function Monitor() {
            $('#<%= grdMonitor.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdMonitor.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        }
    </script>
</asp:Content>

