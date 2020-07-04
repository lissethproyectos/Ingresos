<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Recibos_Electronicos.Inicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 178px;
        }

        .auto-style4 {
            width: 781px;
            text-align: center;
        }


        .auto-style6 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col">
                    <div style="overflow-x: auto; display: block;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdStatus_Carga" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" PageSize="3" Width="100%">
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
                                        <asp:BoundField DataField="EtiquetaCinco" FooterText="BANCOMER" HeaderText="BANCOMER">
                                            <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EtiquetaDos" FooterText="BANAMEX" HeaderText="BANAMEX">
                                            <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EtiquetaCuatro" FooterText="BANORTE" HeaderText="BANORTE">
                                            <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EtiquetaSeis" FooterText="VISA/MASTERCARD" HeaderText="VISA">
                                            <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle CssClass="enc" />
                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                    <RowStyle Font-Size="14px" />
                                    <SelectedRowStyle CssClass="sel" />
                                    <HeaderStyle CssClass="enc" Font-Size="12px" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass="alt" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col">
                    <div style="overflow-x: auto;">

                        <asp:UpdatePanel ID="UpdatePanelGridMonitor" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdMonitor" runat="server" AllowPaging="True"
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
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <div class="card bg-light mb-3">
                        <div class="card-header">
                            <h7>
                                <i class="fa fa-info-circle" aria-hidden="true"></i> IMPORTANTE</h7>
                        </div>
                        <div class="card-body">
                            <p class="card-text black-text">
                                Si el pago se realizó en Sábado ó Domingo, el COMPROBANTE OFICIAL estará disponible a partir del Martes inmediato.Para días inhábiles, aplica el mismo criterio; el COMPROBANTE OFICIAL estará disponible un dia después al día hábil inmediato. Para dudas o aclaraciones al correo depfin@unach.mx ó sysweb@unach.mx.
                                <%--<asp:Button ID="bttnBuscar" runat="server" OnClick="bttnBuscar_Click" CssClass="btn_buscar" Text="Buscar" Font-Size="14px" />--%>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                </div>
                <div class="col-md-9">
                    <asp:UpdatePanel ID="updPnlDep" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDependencia" CssClass="form-control" runat="server" Width="100%">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar" CssClass="alert alert-danger">*Elegir una Dependencia</asp:RequiredFieldValidator>

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
        </div>
        <div class="container">
            <div class="row">
                <div class="col">
                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                </div>
                <div class="col">
                    <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col">
                    <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                </div>
                <div class="col">

                    <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblReferencia" runat="server" Text="Referencia/nombre/folio:"></asp:Label>
                </div>
                <div class="col-md-9">

                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia, folio ó nombre" Visible="true"></asp:TextBox>
                        <div class="input-group-append">
                            <span class="input-group-text_buscar" id="basic-addon2">
                                <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                                    <ContentTemplate>
                                        <%--<asp:Button ID="bttnBuscar" runat="server" OnClick="bttnBuscar_Click" CssClass="btn_buscar" Text="Buscar" Font-Size="14px" />--%>
                                        <button runat="server" id="bttnBuscar" onserverclick="bttnBuscar_Click" class="btn-buscar btn-primary" validationgroup="Buscar">
                                            <i class="fa fa-search" aria-hidden="true"></i>
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
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm">
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
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <div style="overflow-x: auto;">
                        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="ID_FACT" EmptyDataText="El banco no reporto pagos, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="20" ShowHeaderWhenEmpty="True" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
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
                                        <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep." SortExpression="DEPENDENCIA"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Enviar Recibo">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Image" HeaderText="Ver Recibo" SelectImageUrl="~/Imagenes/recibo2.png" SelectText="Ver" ShowSelectButton="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>' ForeColor="Black" Text="Editar"></asp:LinkButton>
                                                <%--<asp:ImageButton AlternateText="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'
                                            ImageUrl="~/Imagenes/files_edit.png" ID="btnEditar" runat="server"></asp:ImageButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FACT_MATRICULA" />
                                        <asp:BoundField DataField="ID_CODIGO_QR" />
                                        <asp:TemplateField HeaderText="Ver Factura" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBttnFact" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Imagenes/fact_xml.png" Text="Seleccionar" />
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
        <asp:HiddenField ID="hddnFactura" runat="server" />

        <div class="container">
            <div class="row">
                <div class="col-sm text-center">
                    <div id="precarga1" class="auto-style4" style="width: 100%"></div>
                </div>
            </div>
        </div>
        <div class="container">
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
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:UpdateProgress ID="updProg" runat="server" AssociatedUpdatePanelID="updPnl">
                        <ProgressTemplate>
                            <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                ToolTip="Espere un momento, por favor.." />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
        <div class="container">
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
        <div class="container">
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
    </div>





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

<asp:Panel ID="pnlDoctos" runat="server" Width="40%">
                                                                                <div class="card text-white bg-dark mb-3">
                                                                                    <div class="card-header">
                                                                                        Documentos
                                                                                    </div>
                                                                                    <div class="card-body">
                                                                                        <div class="container">
                                                                                            <div class="row">
                                                                                                <div class="col text-center">
                                                                                                    <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" Width="100%" BackColor="#CCCCCC" OnPageIndexChanging="grdDoctosFactura_PageIndexChanging">
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
                                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col text-center">
                                                                                                    <asp:Button ID="bttnSalir" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnSalir_Click" Text="SALIR" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </asp:Panel>



    <script type="text/javascript" src="Scripts/jsQR.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
