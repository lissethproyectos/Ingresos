<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Recibos_Electronicos.Form.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:MultiView ID="mltViewFacturas" runat="server">
        <asp:View ID="Datos" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        Tipo
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" Width="100%" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="R">Referenciado</asp:ListItem>
                                    <asp:ListItem Value="T">Efectivo/Transferencia</asp:ListItem>
                                    <asp:ListItem Value="A">Facturas Anticipadas</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-6">
                        <div class="note note-warning" style="font-size: 14px">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblNota" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="row" runat="server" id="rowTipo">
                    <div class="col-md-2">
                        Filtro
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlFiltro" runat="server" Width="100%">
                            <asp:ListItem Value="S">Recibos con solicitud de factura</asp:ListItem>
                            <asp:ListItem Value="T">Todos los recibos</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                        Status
                    </div>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100%" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-2">
                        Dependencia
                    </div>
                    <div class="col-md-10">
                        <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%" CausesValidation="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="*Dependencia" InitialValue="00000" ValidationGroup="Efectivo" Font-Bold="True" Font-Size="14pt">*</asp:RequiredFieldValidator>--%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        Fecha Inicial
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </div>
                    <div class="col-md-2">
                        Fecha Final
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Fin_CalendarExtender" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" OnTextChanged="txtReferencia_TextChanged" PlaceHolder="Referencia/Nombre" Visible="true" Width="98%"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </div>
                </div>
            </div>
            <asp:DropDownList ID="ddlAvance" runat="server" Visible="False">
            </asp:DropDownList>
            <asp:HiddenField ID="hddnBandera" runat="server" />
            <div class="container">
                <div class="row">
                    <div class="col">
                        <asp:MultiView ID="mltViewTipo" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:Panel ID="pnlMsg" runat="server" Width="40%">
                                    <div class="card text-white bg-dark mb-3">
                                        <div class="card-header">
                                            ¿Desea cambiar estatus de la solicitud?
                                        </div>
                                        <div class="card-body">
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col text-center">
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <br />
                                                                &nbsp;&nbsp;<asp:Button ID="btnSi" runat="server" CssClass="btn btn-info" Height="40px" OnClick="btnSi_Click" Text="Si" Width="70px" />
                                                                &nbsp;<asp:Button ID="btnNo" runat="server" CssClass="btn btn-blue-grey" Height="40px" Text="No" Width="70px" OnClick="btnNo_Click" />
                                                                <br />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:HiddenField ID="hddnModal" runat="server" />
                                <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlMsg" TargetControlID="hddnModal">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="pnlOpcConfirma" runat="server" Visible="False">
                                    <asp:RadioButtonList ID="rdoStatusConfirmados" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="12px" OnSelectedIndexChanged="rdoStatusConfirmados_SelectedIndexChanged" RepeatDirection="Horizontal" Width="95%" Height="19px" Visible="False">
                                        <asp:ListItem Value="T" Selected="True">&nbsp;TODOS</asp:ListItem>
                                        <asp:ListItem Value="N">&nbsp;(1). FALTA POR CONFIRMAR</asp:ListItem>
                                        <asp:ListItem Value="S">&nbsp;(2). CONFIRMADOS</asp:ListItem>
                                    </asp:RadioButtonList>
                                </asp:Panel>
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="15" Width="100%" OnRowDeleting="grdDatosFactura_RowDeleting" OnRowDataBound="grdDatosFactura_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="Id_Fact" HeaderText="Id_Fact" SortExpression="ID" />
                                                    <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_CLIENTE" HeaderText="Nombre">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depen." SortExpression="DEPENDENCIA">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" />
                                                    <asp:BoundField DataField="FACT_FECHA_CAPTURA" HeaderText="Fecha Solicitud" />
                                                    <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Factura" SortExpression="FECHA_FACTURA">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Dias de Emisión" />
                                                    <asp:TemplateField HeaderText="Se Factura?">
                                                        <HeaderTemplate>
                                                            <asp:Button ID="btnConfirmar_Sol" runat="server" CssClass="btn btn-blue-grey" Height="35px" OnClick="btnConfirmar_Sol_Click" Text="CONFIRMAR" Visible="False" />
                                                            ¿REQUIERE FACTURA?
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkConfirmado" runat="server" AutoPostBack="True" Checked='<%# Convert.ToBoolean(Eval("FACT_CONFIRMADO")) %>' Enabled='<%# Bind("HABILITADO") %>' OnCheckedChanged="chkConfirmado_CheckedChanged" Text="Si" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" SelectText="Factura" ShowSelectButton="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField HeaderText="Eliminar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FACT_RECEPTOR_CORREO" />
                                                    <asp:TemplateField HeaderText="ENVIAR XML/PDF">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                    <asp:BoundField DataField="FACT_STATUS_CAJA" />
                                                    <asp:BoundField DataField="FACT_RECEPTOR_STATUS" />
                                                    <asp:TemplateField HeaderText="VER RECIBO">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/recibo2.png" OnClick="imgBttnRecibo_Click" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RECHAZADO">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgRechazado" runat="server" ImageUrl='<%# Bind("Ruta") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FACT_TIPO" />
                                                    <asp:TemplateField HeaderText="DOCUMENTOS">
                                                        <ItemTemplate>
                                                            <asp:Button ID="bttnDoctos" runat="server" CssClass="btn btn-blue-grey" Text="Ver" OnClick="bttnDoctos_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hddnDoctos" runat="server" />
                                <ajaxToolkit:ModalPopupExtender ID="modalDoctos" runat="server" TargetControlID="hddnDoctos" PopupControlID="pnlDoctos" BackgroundCssClass="modalBackground_Proy">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="pnlDoctos" runat="server" Width="40%">
                                    <div class="card text-white">
                                        <div class="card-header">
                                            Documentos
                                        </div>
                                        <div class="card-body">
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col text-center">
                                                        <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" BackColor="#CCCCCC">
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
                                                            <HeaderStyle CssClass="enc" />
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
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="Reporte" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-blue-grey" Height="40px"
                                    OnClick="btnRegresar_Click" Text="REGRESAR" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                            AssociatedUpdatePanelID="UpdatePanel3">
                            <ProgressTemplate>
                                <asp:Image ID="Image86" runat="server"
                                    AlternateText="Espere un momento, por favor.." Height="50px"
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                    ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0"
                                    name="miniContenedor" style="height: 500px" width="100%"></iframe>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="Facturas" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col">
                        <asp:ValidationSummary ID="validationSumGuardar" runat="server" CssClass="mensaje_rojo" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="DatosFiscales" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <ajaxToolkit:TabContainer ID="tabFacturas" runat="server" ActiveTabIndex="2" Width="100%">
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                <HeaderTemplate>
                                    <i class="fa fa-file-code-o" aria-hidden="true"></i>Información de Factura
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-2">
                                                Persona
                                            </div>
                                            <div class="col-md-4">
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
                                            <div class="col-md-2">
                                                RFC
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReceptor_Rfc" runat="server" TabIndex="2" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valRFC" runat="server" ControlToValidate="txtReceptor_Rfc" ErrorMessage="*RFC" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Faltan datos</asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Razón Social
                                            </div>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="5" Width="100%"></asp:TextBox>
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
                                            <div class="col-md-2">
                                                Colonia
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="7" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Estado
                                            </div>
                                            <div class="col-md-4">
                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="9" Width="100%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-md-2">
                                                Municipio
                                            </div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="8" Width="100%">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Código Postal
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="6" Width="100%"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2">
                                                Metodo de Pago
                                            </div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="ddlReceptor_MetodoPago" runat="server" TabIndex="10" Width="100%">
                                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="01">Efectivo</asp:ListItem>
                                                    <asp:ListItem Value="02">Cheque Nominativo</asp:ListItem>
                                                    <asp:ListItem Value="03">Transferencia Electrónica de Fondos</asp:ListItem>
                                                    <asp:ListItem Value="04">Tarjeta de Crédito</asp:ListItem>
                                                    <asp:ListItem Value="05">Monedero Electrónico</asp:ListItem>
                                                    <asp:ListItem Value="06">Dinero Electrónico</asp:ListItem>
                                                    <asp:ListItem Value="08">Vales de Despensa</asp:ListItem>
                                                    <asp:ListItem Value="28">Tarjeta de Débito</asp:ListItem>
                                                    <asp:ListItem Value="29">Tarjeta de Servicio</asp:ListItem>
                                                    <asp:ListItem Value="99">Otro</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPago" ErrorMessage="*Método de Pago" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Uso de CFDI
                                            </div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="ddlCFDI" runat="server" CssClass="custom-select" TabIndex="9">
                                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="G01">Adquisición de mercancias</asp:ListItem>
                                                    <asp:ListItem Value="G02">Devolución, descuento o bonificaciones</asp:ListItem>
                                                    <asp:ListItem Value="G03">Gastos en general</asp:ListItem>
                                                    <asp:ListItem Value="D04">Donativos</asp:ListItem>
                                                    <asp:ListItem Value="P01">Por definir</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valCFDI" runat="server" ControlToValidate="ddlCFDI" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-2">
                                                Nombre del Servicio
                                            </div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="ddlServicio" runat="server" CssClass="custom-select" TabIndex="9" Width="100%">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlServicio" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Teléfono
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReceptor_Telefono" runat="server" MaxLength="500" TabIndex="11" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                Correo Electrónico
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReceptor_Correo" runat="server" MaxLength="500" TabIndex="12" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2">
                                                Descripción
                                            </div>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtDescConcepto" runat="server" CssClass="form-control" MaxLength="500" TabIndex="2" PlaceHolder="Detalle del concepto que se requiera en la factura"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:CheckBox ID="chkRechazado" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="14px" OnCheckedChanged="chkRechazado_CheckedChanged" Text="Rechazado" Visible="False" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:Label ID="lblRechazado" runat="server" Text="Motivo del Rechazo" Visible="False"></asp:Label>
                                            </div>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtObservaciones" runat="server" Height="67px" TabIndex="13" TextMode="MultiLine" Visible="False" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:CheckBox ID="chkConfirmaSolicitud" runat="server" CssClass="mensaje_naranja" Text="*Si los datos ya han sido corregidos, puede CONFIRMAR LA SOLICITUD" ValidationGroup="DatosFiscales" Visible="False" />
                                                <asp:CustomValidator ID="valCheck" runat="server" AutoPostBack="False" ClientValidationFunction="ValidateCheckBox" ErrorMessage="*Confirmar Solicitud" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:CustomValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col text-center">
                                                <asp:Button ID="bttnGenFactura" runat="server" CssClass="btn btn-blue-grey" Text="Generar Factura" OnClick="bttnGenFactura_Click" Visible="False" />
                                                &#160;<asp:Button ID="bttnGenFactura0" runat="server" CssClass="btn btn-info" OnClick="bttnGenFactura_Click" Text="Solicitar Factura" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" Width="100%" Font-Size="14px">
                                <HeaderTemplate>
                                    <i class="fa fa-cog" aria-hidden="true"></i>Detalle
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                        <ContentTemplate>
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col">
                                                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="alert alert-dark" FadeTransitions="True" FramesPerSecond="50" HeaderCssClass="accordionCabecera" HeaderSelectedCssClass="accordionHeaderSelected" Height="700px" RequireOpenedPane="False" SelectedIndex="-1" TransitionDuration="200" Width="100%">
                                                            <Panes>
                                                                <ajaxToolkit:AccordionPane runat="server">
                                                                    <Header>
                                                                        <img src="../Imagenes/ico-accordion.png" alt="image01" />
                                                                        Datos del Voucher 
                                                                            </</Header>
                                                                    <Content>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblFolio" runat="server" Text="Folio:"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFolio" runat="server" Width="100px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>&#160;</td>
                                                                                <td>
                                                                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox>
                                                                                    <ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                    <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>&#160;</td>
                                                                                <td>&#160;</td>
                                                                                <td>&#160;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtImporte" runat="server" Width="100px"></asp:TextBox>
                                                                                </td>
                                                                                <td colspan="7">
                                                                                    <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporte" ErrorMessage="*Importe(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="10">
                                                                                    <div class="mensaje_naranja">
                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <table style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td colspan="3">
                                                                                                            <asp:Label ID="lblTitVoucher" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Voucher"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblVoucher" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label>
                                                                                                        </td>
                                                                                                        <td class="auto-style7">
                                                                                                            <asp:FileUpload ID="fileVoucher" runat="server" Height="30px" />
                                                                                                        </td>
                                                                                                        <td class="auto-style6">
                                                                                                            <asp:Button ID="btnVoucher" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnVoucher_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3">
                                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" class="auto-style38" colspan="3">
                                                                                                            <table style="width: 60%;" width="70%">
                                                                                                                <tr align="center">
                                                                                                                    <td style="width: 50%;">
                                                                                                                        <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                                    </td>
                                                                                                                    <td style="width: 50%;">
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                                                                            <ContentTemplate>
                                                                                                                                <asp:LinkButton ID="linkBttnEliminarVoucher" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarVoucher_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="btnVoucher" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </Content>
                                                                </ajaxToolkit:AccordionPane>
                                                                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1" CssClass="note-info">
                                                                    <Header>
                                                                        Datos del Oficio 
                                                                    </Header>
                                                                    <Content>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td width="20%">
                                                                                            <asp:Label ID="lblNumOficio" runat="server" Text="Núm. de Oficio:"></asp:Label>
                                                                                        </td>
                                                                                        <td width="80%">
                                                                                            <asp:TextBox ID="txtNumOficio" runat="server"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="valNumOficio" runat="server" ControlToValidate="txtNumOficio" ErrorMessage="*Número de Oficio (Pestania 2-&gt;Datos del Oficio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <div class="mensaje_naranja">
                                                                                                <table style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td colspan="3">
                                                                                                            <asp:Label ID="lblTitOficio" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Oficio"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblOficio" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label>
                                                                                                        </td>
                                                                                                        <td class="auto-style7">
                                                                                                            <asp:FileUpload ID="fileOficio" runat="server" Height="30px" />
                                                                                                        </td>
                                                                                                        <td class="auto-style6">
                                                                                                            <asp:Button ID="btnOficio" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnOficio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="3">
                                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileOficio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" class="auto-style38" colspan="3">
                                                                                                            <table style="width: 60%;" width="70%">
                                                                                                                <tr align="center">
                                                                                                                    <td style="width: 50%;">
                                                                                                                        <asp:HyperLink ID="lblArchivoOficio" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                                    </td>
                                                                                                                    <td style="width: 50%;">
                                                                                                                        <asp:LinkButton ID="linkBttnEliminarOficio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarOficio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnOficio" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </Content>
                                                                </ajaxToolkit:AccordionPane>
                                                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                                    <Header>
                                                                        Importe/Convenio 
                                                                    </Header>
                                                                    <Content>
                                                                        <asp:UpdatePanel ID="updPnlConvenio" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="container">
                                                                                    <div class="row">
                                                                                        <div class="col-md-1">
                                                                                            Importe
                                                                                        </div>
                                                                                        <div class="col-md-2">
                                                                                            <asp:TextBox ID="txtImporteConvenio" runat="server"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="valImpConvenio" runat="server" ControlToValidate="txtImporteConvenio" ErrorMessage="*Importe (Pestania 2-&gt;Convenio)"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            IVA
                                                                                        </div>
                                                                                        <div class="col-md-2">
                                                                                            <asp:TextBox ID="txtIVA" runat="server" AutoPostBack="True" OnTextChanged="txtIVA_TextChanged" Width="100px"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="valIva" runat="server" ControlToValidate="txtIVA" ErrorMessage="*Iva(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            Total
                                                                                        </div>
                                                                                        <div class="col-md-2">
                                                                                            <asp:TextBox ID="txtTotal" runat="server" Width="100px"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="valTotal" runat="server" ControlToValidate="txtTotal" ErrorMessage="*Total(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col-md-1">
                                                                                            Observaciones
                                                                                        </div>
                                                                                        <div class="col-md-11">
                                                                                            <asp:TextBox ID="txtObservacionesConvenio" runat="server" Height="100px" PlaceHolder="Especificar concepto de la factura, el importe total, en caso de que aplique desglosar IVA." TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col">
                                                                                            <div class="note note-info" style="font-size: 14px">
                                                                                                <div class="row">
                                                                                                    <div class="col">
                                                                                                        Anexar Convenio
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-10">
                                                                                                        <asp:FileUpload ID="fileConvenio" runat="server" Height="30px" />
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <asp:Button ID="btnConvenio" runat="server" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="btnConvenio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col">
                                                                                                        *Solo formatos PNG, JPG y PDF
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="fileConvenio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4">
                                                                                                        <asp:HyperLink ID="lblArchivoConvenio" runat="server" Target="_blank">[lblArchivoConvenio]</asp:HyperLink>
                                                                                                    </div>
                                                                                                    <div class="col-md-4">
                                                                                                        <asp:LinkButton ID="linkBttnEliminarConvenio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarConvenio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                        </td>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnConvenio" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </Content>
                                                                </ajaxToolkit:AccordionPane>
                                                            </Panes>
                                                        </ajaxToolkit:Accordion>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Nivel
                                                    </div>
                                                    <div class="col-md-11">
                                                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:CustomValidator ID="valConceptos" runat="server" ErrorMessage="*Se debe asignar al menor un concepto" OnServerValidate="ConceptosAsignados" ValidationGroup="DatosFiscales">*Conceptos Requeridos</asp:CustomValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class=" alert alert-dark text-center">
                                                            <strong>CONCEPTOS ASIGNADOS</strong>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class=" alert alert-dark text-center">
                                                            <strong>CONCEPTOS DISPONIBLES
                                                            </strong>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:GridView ID="grvConceptosDisp" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptosDisp_PageIndexChanging" OnSelectedIndexChanged="grvConceptosDisp_SelectedIndexChanged" Width="100%" AllowPaging="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve.">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                </asp:BoundField>
                                                                <asp:CommandField SelectText="Agregar" ShowSelectButton="True" />
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnRowDeleting="grvConceptos_RowDeleting" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve.">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                </asp:BoundField>
                                                                <asp:CommandField ShowDeleteButton="True" />
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Imagen de la Factura">
                                <HeaderTemplate>
                                    <i class="fa fa-upload" aria-hidden="true"></i>Archivos
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanelFoto" runat="server">
                                        <ContentTemplate>
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Folio de la Factura
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtFolio_Fact_Cja" runat="server" Width="100%"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFolio_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2">
                                                        Fecha de la Factura
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtFecha_Fact_Cja" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="txtFecha_Fact_Cja_CalendarExtender" runat="server" PopupButtonID="imgFecha_Fact_Cja" TargetControlID="txtFecha_Fact_Cja" />
                                                        <asp:ImageButton ID="imgFecha_Fact_Cja" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                        &#160;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFecha_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        *Solo formatos PDF Y XML
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:FileUpload ID="fileFactura" runat="server" Height="30px" />
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:Button ID="btnAgregaFactura" runat="server" CssClass="btn btn-primary" OnClick="btnAgregaFactura_Click" Text="ADJUNTAR" ValidationGroup="adjuntarFactura" />
                                                    </div>

                                                    <div class="col-md-1">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="fileFactura" ErrorMessage="Archivo incorrecto, debe ser un PDF o XML" ValidationExpression="(.*?)\.(xml|XML|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdArchivos_RowDeleting" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="Fecha_Fact_Cja" HeaderText="Fecha" />
                                                                <asp:BoundField DataField="Folio_Fact_Cja" HeaderText="Folio" />
                                                                <asp:BoundField DataField="NombreArchivo" Visible="False" />
                                                                <asp:TemplateField HeaderText="Archivo">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="linkPdf" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "NombreArchivo") %></asp:HyperLink>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ExtensionArchivo" Visible="False" />
                                                                <asp:CommandField ShowDeleteButton="True" />
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnAgregaFactura" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-right">
                        <asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-info" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="GUARDAR" ValidationGroup="DatosFiscales" />
                        &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="15" Text="CANCELAR" />
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>


</asp:Content>
