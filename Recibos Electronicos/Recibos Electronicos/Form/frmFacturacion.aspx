<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFacturacion.aspx.cs" Inherits="Recibos_Electronicos.Form.frmFacturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
        //Creo una función que imprimira en la hoja el valor del porcentanje asi como el relleno de la barra de progreso
        function callprogress(vValor) {
            //vValor = vValor + 40;
            document.getElementById("getProgressBarFill").style.width = vValor + '%';
            document.getElementById("getProgressBarFill").innerHTML = vValor + '%';
        }

        function LoadPDF(ruta) {
            window.open(ruta, '_blank');
        }

    </script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }

        .overlayContent {
            z-index: 99;
            margin: 250px auto;
            width: 80px;
            height: 80px;
        }

            .overlayContent h2 {
                font-size: 18px;
                font-weight: bold;
                color: #000;
            }

            .overlayContent img {
                width: 30px;
                height: 30px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay">
                <div class="overlayContent">
                    <asp:Image ID="Image13" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="mltViewFacturas" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="container">
                                    <div class="row" style="display: none">
                                        <div class="col-md-2">
                                            Dependencia
                                        </div>
                                        <div class="col-md-10">
                                            <%--<asp:UpdatePanel ID="UpdatePanel48" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%" CausesValidation="True">
                                            </asp:DropDownList>
                                            <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none">
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
                                        <div class="col-md-1">
                                            Filtro
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlFiltro" runat="server" Width="100%">
                                                <asp:ListItem Value="S">Recibos con solicitud de factura</asp:ListItem>
                                                <asp:ListItem Value="T">Todos los recibos</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="alert  alert-info">
                                                Aqui podras crear y consultar tus facturas electrónicas, debes ingresar la referencia de pago de 26 digitos.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-11">
                                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" PlaceHolder="Referencia/Nombre" Visible="true" Width="98%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">

                                            <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="15" Width="100%">
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
                                                    <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Pago" SortExpression="FECHA_FACTURA">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Datos Fiscales" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <%--<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" Text="Factura" />--%>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="btn btn-blue-grey" Visible='<%# Bind("VISIBLE2") %>'><i class="fa fa-pencil-square-o"></i> Solicitar Factura</asp:LinkButton>
                                                            <asp:LinkButton ID="lnkBttnVerPDF" runat="server" CssClass="btn btn-info" Visible='<%# Bind("VISIBLE1") %>' OnClick="lnkBttnVerPDF_Click"><i class="fa fa-file-pdf-o"></i> PDF</asp:LinkButton>
                                                            <asp:LinkButton ID="lnkBttnVerXML" runat="server" CssClass="btn btn-blue-grey" Visible='<%# Bind("VISIBLE1") %>' OnClick="lnkBttnVerXML_Click"><i class="fa fa-file-code-o"></i> XML</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FACT_RECEPTOR_CORREO" />
                                                    <asp:TemplateField HeaderText="ENVIAR XML/PDF">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/correo2.png" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                    <asp:BoundField DataField="FACT_STATUS_CAJA" />
                                                    <asp:BoundField DataField="FACT_RECEPTOR_STATUS" />
                                                    <asp:TemplateField HeaderText="VER RECIBO">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBttnVerRecibo" runat="server"><i class="fa fa-file-text"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_FACT_EFEC" />
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
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="container">
                                    <h4>Datos Fiscales</h4>
                                    <hr>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Persona
                                        </div>
                                        <div class="col-md-4">
                                            <%-- <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:RadioButtonList ID="rdoBttnReceptorTipoPersona" runat="server" RepeatDirection="Horizontal" TabIndex="3" AppendDataBoundItems="True" AutoPostBack="True">
                                                <asp:ListItem Value="F">Fisica&#160;&#160;</asp:ListItem>
                                                <asp:ListItem Value="M">Moral</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--</ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                            <asp:RequiredFieldValidator ID="valTipoPers" runat="server" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Tipo Persona" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            RFC
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_Rfc" runat="server" TabIndex="2" Width="100%"></asp:TextBox><asp:RequiredFieldValidator ID="valRFC" runat="server" ControlToValidate="txtReceptor_Rfc" ErrorMessage="*RFC" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Faltan datos</asp:CustomValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Razón Social
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="5" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtReceptor_Nombre" ErrorMessage="*Razón Social" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            Calle
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_Domicilio" runat="server" MaxLength="500" TabIndex="4" Width="100%"></asp:TextBox><asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtReceptor_Domicilio" ErrorMessage="*Calle" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Colonia
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="7" Width="100%"></asp:TextBox><asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            Estado
                                        </div>
                                        <div class="col-md-4">
                                            <%-- <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="9" Width="100%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                            <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Municipio
                                        </div>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="8" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            Código Postal
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="6" Width="100%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
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
                                        <div class="col-md-2">
                                            Teléfono
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtReceptor_Telefono" runat="server" MaxLength="500" TabIndex="11" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Correo Electrónico
                                        </div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtReceptor_Correo" runat="server" MaxLength="500" TabIndex="12" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            &nbsp;
                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:Button ID="bttnCancelar" runat="server" CssClass="btn btn-light" OnClick="bttnCancelar_Click" Text="Salir" />
                                            &nbsp;<asp:Button ID="bttnGenFactura" runat="server" CssClass="btn btn-info" Text="Generar Factura" OnClick="bttnGenFactura_Click" />
                                            <br />
                                            <%-- </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
