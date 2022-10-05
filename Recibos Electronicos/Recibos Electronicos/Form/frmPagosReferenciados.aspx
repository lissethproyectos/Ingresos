<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPagosReferenciados.aspx.cs" Inherits="Recibos_Electronicos.Form.frmPagosReferenciados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-1">
                Escuela
            </div>
            <div class="col-md-11">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLEscuela" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1">
                Origen
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlOrigen_SelectedIndexChanged">
                            <asp:ListItem Value="SIAE">Escolares</asp:ListItem>
                            <asp:ListItem Value="SYSWEB">Sysweb</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                Nivel
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="updPnlNivel" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlNivel" runat="server" Width="100%" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged">
                            <asp:ListItem Value="T">TODOS</asp:ListItem>
                            <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                            <asp:ListItem Value="E">Especialidad</asp:ListItem>
                            <asp:ListItem Value="M">Maestría</asp:ListItem>
                            <asp:ListItem Value="D">Doctorado</asp:ListItem>
                            <asp:ListItem Value="N">Lenguas Extranjeras</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-6">
                <asp:UpdatePanel ID="updPnlCiclo" runat="server">
                    <ContentTemplate>
                        <div class="row" runat="server" id="divCiclo">
                            <div class="col-md-1">
                                Ciclo
                            </div>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddlCicloEscolar" runat="server" Width="100%" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdateProgress ID="updPrgCiclo" runat="server" AssociatedUpdatePanelID="updPnlCiclo">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row" runat="server" id="divBusqueda" visible="false">
                            <div class="col-md-1">
                                Filtro
                            </div>
                            <div class="col-md-11">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBusqueda" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBusqueda_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="1">Fecha de Registro</asp:ListItem>
                                            <asp:ListItem Value="2">Referencia/Nombre</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrFechas" runat="server" AssociatedUpdatePanelID="updPnlFechas">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="imgFechas" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <asp:UpdatePanel ID="updPnlFechas" runat="server">
            <ContentTemplate>
                <div class="row" id="divFechas" runat="server">
                    <div class="col-md-1">
                        Inicio
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFechaIni" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFechaIni" PopupButtonID="imgCalendarioIni" />
                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </div>
                    <div class="col-md-1">
                        Fin
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFechaFin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFin" />
                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </div>
                    <div class="col-md-2">
                        <asp:LinkButton ID="linkBttnBusca1" runat="server" CssClass="btn btn-primary" OnClick="linkBttnBusca1_Click">Buscar</asp:LinkButton>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updPnlBuscarRef" runat="server">
            <ContentTemplate>
                <div class="row" id="rowBuscaRef" runat="server">
                    <div class="col-md-1">Buscar</div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia/Nombre"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UpdatePanel229" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="linkBttnBusca2" runat="server" CssClass="btn btn-primary" OnClick="linkBttnBusca2_Click">Buscar</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                    <ProgressTemplate>
                        <asp:Image ID="img11" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>

        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdatePgr3" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="img10" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>

        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrgNivelo" runat="server" AssociatedUpdatePanelID="updPnlNivel">
                    <ProgressTemplate>
                        <asp:Image ID="img3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>

        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel229">
                    <ProgressTemplate>
                        <asp:Image ID="imgPgrBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <%--     <asp:UpdateProgress ID="updPrReferencias" runat="server" AssociatedUpdatePanelID="UpdatePanel228">
                    <ProgressTemplate>
                        <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
                <asp:UpdateProgress ID="updPrReferencias" runat="server" AssociatedUpdatePanelID="UpdatePanel228">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="img1" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel228" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvReferenciasSIAE" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró el recibo." OnPageIndexChanging="grvReferenciasSIAE_PageIndexChanging" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="Id" />
                                <asp:BoundField DataField="CICLO_ESCOLAR" HeaderText="Ciclo Escolar" />
                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dependencia" />
                                <asp:BoundField DataField="FACT_MATRICULA" HeaderText="No. de Ficha/Matricula">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" HeaderText="Fecha de Pago">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_TIPO" HeaderText="Tipo" />
                                <asp:TemplateField HeaderText="Pago Aplicado">
                                    <ItemTemplate>
                                        <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# Bind("FACT_RECEPTOR_STATUS") %>' />
                                        <%--<asp:ImageButton ID="imgStatus" runat="server" ImageUrl='<%# Bind("FACT_RECEPTOR_STATUS") %>' OnClick="imgStatus_Click" />--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnEditar" runat="server" CssClass="btn btn-info" OnClick="linkBttnEditar_Click"><i class="fa fa-pencil" aria-hidden="true"></i>Editar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnReferencia" runat="server" CssClass="btn btn-green" OnClick="linkBttnReferencia_Click"><i class="fa fa-barcode" aria-hidden="true"></i>Referencia</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblBttnGenRecibo0" runat="server" CssClass="btn btn-grey disabled" Visible='<%# Bind("VISIBLE1") %>'><i class="fa fa-file"></i>Recibo</asp:Label>
                                        <asp:LinkButton ID="linkBttnGenRecibo0" runat="server" CssClass="btn btn-primary" OnClick="linkBttnGenRecibo_Click" Visible='<%# Bind("VISIBLE2") %>'><i class="fa fa-file"></i>Recibo</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FACT_STATUS_NOTAS" />
                                <asp:BoundField DataField="FACT_STATUS" />
                                <asp:BoundField DataField="ID_FICHA_BANCARIA" HeaderText="ID_RECIBO" />
                                <asp:BoundField DataField="FACT_TIPO_SERVICIO" />
                                <asp:BoundField DataField="ID_RECIBO" />
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
    <%-- <asp:HiddenField ID="hddnAlert" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="modalAlert" runat="server" PopupControlID="pnlDatosBanco" TargetControlID="hddnAlert" BackgroundCssClass="modalBackground_Proy">
    </ajaxToolkit:ModalPopupExtender>--%>



    <div class="modal fade" id="modalPagos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modConceptos">Información de la Referencia</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="container">
                                    <div id="pnlDatosGral" runat="server">
                                        <div class="row">
                                            <div class="col-md-2">Cve Escuela</div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtEscuela" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                Id Carrera
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtIdCarrera" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">Ciclo</div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCiclo" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                Semestre
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtSemestre" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Matricula
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                Cve Evento
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtEvento" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Nombre
                                            </div>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblBanco" runat="server" Text="Banco"></asp:Label>
                                        </div>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="ddlBanco" runat="server" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblFolioBanco" runat="server" Text="Folio"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtFolioBanco" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            (Folio Empresa)
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFolioBanco" ErrorMessage="*Folio de Banco" ValidationGroup="Multipagos">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblFechaPago" runat="server" Text="Fecha Pago"></asp:Label>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtFechaPago" runat="server" Width="80%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtFechaPago" PopupButtonID="imgCalendario" />
                                            <asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaPago" ErrorMessage="*Fecha de Pago" ValidationGroup="Multipagos">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblPagoAplicado" runat="server" Text="Pago Aplicado"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:CheckBox ID="chkPagoAplicado" runat="server" Text="Si" />
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Button ID="bttnGenerarRecibo" runat="server" CssClass="btn btn-green" OnClick="bttnGenerarRecibo_Click" Text="GENERAR RECIBO" ValidationGroup="Multipagos" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col font-weight-bold">
                                            <asp:Label ID="lblReferenciaOrig" runat="server" Text="Referencia"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:TextBox ID="txtReferenciaOrig" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col font-weight-bold">
                                            <asp:Label ID="lblReferenciaPagada" runat="server" Text="Referencia Pagada"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:TextBox ID="txtReferenciaPagada" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <button type="button" class="btn btn-grey" data-dismiss="modal">CERRAR</button>
                                            &nbsp;<asp:Button ID="bttnConfirmaPago" runat="server" CssClass="btn btn-primary" OnClick="bttnConfirmaPago_Click" Text="GUARDAR" ValidationGroup="Guardar" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="container">
                            <div class="row">
                                <div class="col text-center">
                                    <asp:UpdateProgress ID="updPrReferencias0" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <asp:Image ID="imgMultiview0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






    <script language="javascript" type="text/javascript">      
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
            }
        };



        function PagosSIAE() {

            $('#<%= grvReferenciasSIAE.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvReferenciasSIAE.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "columns": [
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                ]
            });

        }


    </script>
</asp:Content>
