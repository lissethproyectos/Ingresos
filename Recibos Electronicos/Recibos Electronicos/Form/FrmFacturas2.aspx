<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmFacturas2.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmFacturas2" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uccorreo" TagPrefix="usr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
        //Creo una función que imprimira en la hoja el valor del porcentanje asi como el relleno de la barra de progreso
        function callprogress(vValor) {
            //vValor = vValor + 40;
            document.getElementById("getProgressBarFill").style.width = vValor + '%';
            document.getElementById("getProgressBarFill").innerHTML = vValor + '%';
        }

        function LoadPDF(valor) {
            valor = '../Facturas/PDF/' + valor + '.pdf';
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function LoadXML(valor) {
            valor = '../Facturas/XML/' + valor + '.xml';
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function LoadPDF_Nuevo(valor) {
            alert("pasa");
            valor = '../Facturas/PDF/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function LoadXML_Nuevo(valor) {
            //alert(valor);
            valor = '../Facturas/XML/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function ValidateCheckBox(sender, args) {

            //alert(document.getElementById('<%=chkConfirmaSolicitud.ClientID %>').checked);
            if (document.getElementById('<%=chkConfirmaSolicitud.ClientID %>').checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }


        function ValidateTipoPersona(sender, args) {
            var RBL = document.getElementById('<%=rdoBttnReceptorTipoPersona.ClientID %>');
            var radiobuttonlist = RBL.getElementsByTagName("input");
            var counter = 0;
            var atLeast = 1
            for (var i = 0; i < radiobuttonlist.length; i++) {
                if (radiobuttonlist[i].checked) {
                    if (radiobuttonlist[i].value == "F") {
                        if (document.getElementById('<%=txtReceptor_Rfc.ClientID %>').value.length == "13") {
                            args.IsValid = true;
                        }
                        else {

                            args.IsValid = false;
                        }
                    }
                    else {
                        if (document.getElementById('<%=txtReceptor_Rfc.ClientID %>').value.length == "12") {
                            args.IsValid = true;
                        }
                        else {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>--%>


    <%-- <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>--%>
    <asp:MultiView ID="mltViewFacturas" runat="server">
        <asp:View ID="Datos" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        Dependencia
                    </div>
                    <div class="col-md-10">
                        <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" Width="100%" CausesValidation="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">Fecha Inicial</div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                    </div>
                    <div class="col-md-2">Fecha Final</div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Fin_CalendarExtender" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </div>

                    <div class="col-md-2">
                        Status
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-11">
                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" OnTextChanged="txtReferencia_TextChanged" PlaceHolder="Referencia/Nombre" Visible="true" Width="98%"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:DropDownList ID="ddlAvance" runat="server" Visible="False">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hddnBandera" runat="server" />

                        <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Visible="False">
                            <asp:ListItem Value="R">Referenciado</asp:ListItem>
                            <asp:ListItem Value="T">Efectivo/Transferencia</asp:ListItem>
                            <asp:ListItem Value="A">Facturas Anticipadas</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="Efectivo" />
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdateProgress ID="updPnlBuscar" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                            <ProgressTemplate>
                                <asp:Image ID="imgBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                            <ProgressTemplate>
                                <asp:Image ID="imgGrid" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
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
                                            <ItemTemplate>
                                                <asp:Button ID="bttnSolFactura" runat="server" CssClass="btn btn-primary" OnClick="bttnSolFactura_Click" Text="Solicitar" Visible='<%# Bind("VISIBLE1") %>' />
                                                <asp:Button ID="bttnCancelarSol" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnCancelarSol_Click" Text="Cancelar" Visible='<%# Bind("VISIBLE2") %>' />
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
                                        <asp:TemplateField HeaderText="XML/PDF">
                                            <ItemTemplate>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="auto-style91">
                                                            <asp:DropDownList ID="ddlFacturas" runat="server" Width="100px"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:Button ID="bttnVerFactura" runat="server" CssClass="btn4" Text="Ver" /></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DOCUMENTOS">
                                            <ItemTemplate>
                                                <asp:Button ID="bttnDoctos" runat="server" CssClass="btn btn-blue-grey" Text="Ver" OnClick="bttnDoctos_Click" />
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

                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hddnDoctos" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="modalDoctos" runat="server" TargetControlID="hddnDoctos" PopupControlID="pnlDoctos" BackgroundCssClass="modalBackground_Proy"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlDoctos" runat="server" CssClass="TituloModalPopupMsg">
                <div class="card text-white bg-info mb-3">
                    <div class="card-header">Documentos</div>
                    <div class="card-body">
                        <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
                            <Columns>
                                <asp:BoundField DataField="FACT_TIPO" HeaderText="TIPO" />
                                <asp:TemplateField HeaderText="ARCHIVO">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="linkDocto" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "RUTA_ADJUNTO") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "RUTA_ADJUNTO") %></asp:HyperLink>
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
            </asp:Panel>


            <asp:HiddenField ID="hddnModal" runat="server" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlMsg" TargetControlID="hddnModal"></ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="pnlOpcConfirma" runat="server" Visible="False">

                <asp:RadioButtonList ID="rdoStatusConfirmados" runat="server" AutoPostBack="True" Font-Bold="False" Font-Size="12px" ForeColor="#333333" OnSelectedIndexChanged="rdoStatusConfirmados_SelectedIndexChanged" RepeatDirection="Horizontal" Width="95%" Height="19px">
                    <asp:ListItem Selected="True" Value="T">&nbsp;TODOS</asp:ListItem>
                    <asp:ListItem Value="N">&nbsp;(1). FALTA POR CONFIRMAR</asp:ListItem>
                    <asp:ListItem Value="S">&nbsp;(2). CONFIRMADOS</asp:ListItem>
                </asp:RadioButtonList>

                <asp:Button ID="btnConfirmar_Sol" runat="server" CssClass="btn btn-blue-grey" Height="35px" OnClick="btnConfirmar_Sol_Click" Text="APLICAR" />

            </asp:Panel>



        </asp:View>
        <asp:View ID="Reporte" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnRegresar" runat="server" CssClass="btn3" Height="40px"
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
            <table style="width: 100%;">
                <tr>
                    <td class="style25">&nbsp;</td>
                    <td class="style24">
                        <table style="width: 100%;">
                            <tr>
                                <td align="center">
                                    <asp:ValidationSummary ID="validationSumGuardar" runat="server" CssClass="mensaje_rojo" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="DatosFiscales" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ajaxToolkit:TabContainer ID="tabFacturas" runat="server" ActiveTabIndex="0" CssClass="ajax__myTab" Width="100%">
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                            <HeaderTemplate>Información de Factura</HeaderTemplate>
                                            <ContentTemplate>
                                                <br />
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Rfc" runat="server" Text="RFC:"></asp:Label></td>
                                                        <td class="style20">
                                                            <asp:TextBox ID="txtReceptor_Rfc" runat="server" TabIndex="2"></asp:TextBox><asp:RequiredFieldValidator ID="valRFC" runat="server" ControlToValidate="txtReceptor_Rfc" ErrorMessage="*RFC" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator><asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Faltan datos</asp:CustomValidator></td>
                                                        <td class="style20"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style55" valign="top">
                                                            <asp:Label ID="lblReceptorTipoPersona" runat="server" Text="Persona:"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RadioButtonList ID="rdoBttnReceptorTipoPersona" runat="server" OnSelectedIndexChanged="rdoBttnReceptorTipoPersona_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="1" AppendDataBoundItems="True" AutoPostBack="True">
                                                                        <asp:ListItem Value="F">Fisica&#160;&#160;</asp:ListItem>
                                                                        <asp:ListItem Value="M">Moral</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <asp:RequiredFieldValidator ID="valTipoPers" runat="server" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Tipo Persona" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Domicilio" runat="server" Text="Calle:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_Domicilio" runat="server" MaxLength="500" TabIndex="4" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtReceptor_Domicilio" ErrorMessage="*Calle" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Nombre" runat="server" Text="Razón Social:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="3" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtReceptor_Nombre" ErrorMessage="*Razón Social" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_CP" runat="server" Text="Código Postal:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="6" Width="20%"></asp:TextBox><asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Colonia" runat="server" Text="Colonia:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="5" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblMunicipio_Fiscal" runat="server" Text="Municipio:"></asp:Label></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="8"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Estado" runat="server" Text="Estado:"></asp:Label></td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="7"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_MetodoPago" runat="server" Text="Metodo de Pago:"></asp:Label></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlReceptor_MetodoPago" runat="server" TabIndex="9">
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
                                                            </asp:DropDownList><asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPago" ErrorMessage="*Método de Pago" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Telefono" runat="server" Text="Teléfono:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_Telefono" runat="server" MaxLength="500" TabIndex="10" Width="50%"></asp:TextBox></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55">
                                                            <asp:Label ID="lblReceptor_Correo" runat="server" Text="Correo Electrónico:"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReceptor_Correo" runat="server" MaxLength="500" TabIndex="11" Width="50%"></asp:TextBox></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left" class="auto-style55">
                                                            <asp:CheckBox ID="chkRechazado" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="14px" OnCheckedChanged="chkRechazado_CheckedChanged" Text="Rechazado" Visible="False" /><br />
                                                            <br />
                                                            <asp:Label ID="lblRechazado" runat="server" Text="Motivo del Rechazo:" Visible="False"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtObservaciones" runat="server" Height="67px" TabIndex="12" TextMode="MultiLine" Visible="False" Width="80%"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style55" valign="top">&#160;</td>
                                                        <td valign="top">&#160;</td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left" class="auto-style55">&#160;</td>
                                                        <td valign="top">
                                                            <asp:CheckBox ID="chkConfirmaSolicitud" runat="server" CssClass="mensaje_naranja" Text="*Si los datos ya han sido corregidos, puede CONFIRMAR LA SOLICITUD" ValidationGroup="DatosFiscales" Visible="False" />
                                                            <asp:CustomValidator ID="valCheck" runat="server" AutoPostBack="False" ClientValidationFunction="ValidateCheckBox" ErrorMessage="*Confirmar Solicitud" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:CustomValidator></td>
                                                        <td>&#160;</td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                            <HeaderTemplate>Detalle</HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="8">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8">
                                                                    <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContenido" FadeTransitions="True" FramesPerSecond="50" HeaderCssClass="accordionCabecera" HeaderSelectedCssClass="accordionHeaderSelected" Height="700px" RequireOpenedPane="False" SelectedIndex="-1" TransitionDuration="200" Width="100%">
                                                                        <Panes>
                                                                            <ajaxToolkit:AccordionPane runat="server">
                                                                                <Header>
<img src="../Imagenes/ico-accordion.png" alt="image01" />Datos del Voucher </Header>
                                                                                <Content>
                                                                                    <table style="width: 100%;">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblFolio" runat="server" Text="Folio:"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtFolio" runat="server" Width="100px"></asp:TextBox></td>
                                                                                            <td>
                                                                                                <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                            <td>&#160;</td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                                <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                            <td>&#160;</td>
                                                                                            <td>&#160;</td>
                                                                                            <td>&#160;</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtImporte" runat="server" Width="100px"></asp:TextBox></td>
                                                                                            <td colspan="7">
                                                                                                <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporte" ErrorMessage="*Importe(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="10">
                                                                                                <div class="mensaje_naranja">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td colspan="3">
                                                                                                                        <asp:Label ID="lblTitVoucher" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Voucher"></asp:Label></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <asp:Label ID="lblVoucher" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label></td>
                                                                                                                    <td class="auto-style7">
                                                                                                                        <asp:FileUpload ID="fileVoucher" runat="server" Height="30px" /></td>
                                                                                                                    <td class="auto-style6">
                                                                                                                        <asp:Button ID="btnVoucher" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnVoucher_Click" Text="ADJUNTAR" ValidationGroup="guardar" /></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="3">
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="auto-style38" colspan="3">
                                                                                                                        <table style="width: 60%;" width="70%">
                                                                                                                            <tr align="center">
                                                                                                                                <td style="width: 50%;">
                                                                                                                                    <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink></td>
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
                                                                                        <tr>
                                                                                            <td class="auto-style19">&#160;</td>
                                                                                            <td class="auto-style80">&#160;</td>
                                                                                            <td class="auto-style87">&#160;</td>
                                                                                            <td class="auto-style86">&#160;</td>
                                                                                            <td class="auto-style78">&#160;</td>
                                                                                            <td class="auto-style26">&#160;</td>
                                                                                            <td class="auto-style85">&#160;</td>
                                                                                            <td class="auto-style88">&#160;</td>
                                                                                            <td class="auto-style88">&#160;</td>
                                                                                            <td>&#160;</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </Content>
                                                                            </ajaxToolkit:AccordionPane>
                                                                            <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                                                                                <Header>
<img src="../Imagenes/ico-accordion.png" alt="image01" />Datos del Oficio </Header>
                                                                                <Content>
                                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="lblNumOficio" runat="server" Text="Núm. de Oficio:"></asp:Label></td>
                                                                                                    <td width="80%">
                                                                                                        <asp:TextBox ID="txtNumOficio" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="valNumOficio" runat="server" ControlToValidate="txtNumOficio" ErrorMessage="*Número de Oficio (Pestania 2-&gt;Datos del Oficio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <div class="mensaje_naranja">
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td colspan="3">
                                                                                                                        <asp:Label ID="lblTitOficio" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Oficio"></asp:Label></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <asp:Label ID="lblOficio" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label></td>
                                                                                                                    <td class="auto-style7">
                                                                                                                        <asp:FileUpload ID="fileOficio" runat="server" Height="30px" /></td>
                                                                                                                    <td class="auto-style6">
                                                                                                                        <asp:Button ID="btnOficio" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnOficio_Click" Text="ADJUNTAR" ValidationGroup="guardar" /></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="3">
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileOficio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="center" class="auto-style38" colspan="3">
                                                                                                                        <table style="width: 60%;" width="70%">
                                                                                                                            <tr align="center">
                                                                                                                                <td style="width: 50%;">
                                                                                                                                    <asp:HyperLink ID="lblArchivoOficio" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink></td>
                                                                                                                                <td style="width: 50%;">
                                                                                                                                    <asp:LinkButton ID="linkBttnEliminarOficio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarOficio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton></td>
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
<img src="../Imagenes/ico-accordion.png" alt="image01" />Importe/Convenio </Header>
                                                                                <Content>
                                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                        <ContentTemplate>
                                                                                            </table width="100%"><tr>
                                                                                                <td>
                                                                                                    <table width="100%">
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblImporteConvenio" runat="server" Text="Importe:"></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="txtImporteConvenio" runat="server"></asp:TextBox></td>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="valImpConvenio" runat="server" ControlToValidate="txtImporteConvenio" ErrorMessage="*Importe (Pestania 2-&gt;Convenio)"></asp:RequiredFieldValidator></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblIVA" runat="server" Text="IVA:"></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="txtIVA" runat="server" AutoPostBack="True" OnTextChanged="txtIVA_TextChanged" Width="100px"></asp:TextBox></td>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="valIva" runat="server" ControlToValidate="txtIVA" ErrorMessage="*Iva(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblTotal" runat="server" Text="Total:"></asp:Label></td>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="txtTotal" runat="server" Width="100px"></asp:TextBox></td>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="valTotal" runat="server" ControlToValidate="txtTotal" ErrorMessage="*Total(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top">
                                                                                                                <asp:Label ID="lblObservacionesConvenio" runat="server" Text="Observaciones:"></asp:Label></td>
                                                                                                            <td colspan="8">
                                                                                                                <asp:TextBox ID="txtObservacionesConvenio" runat="server" Height="100px" PlaceHolder="Especificar concepto de la factura, el importe total, en caso de que aplique desglosar IVA." TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            </td><tr></tr>
                                                                                            </tr><td>
                                                                                                <div class="mensaje_naranja">
                                                                                                    <table style="width: 100%;">
                                                                                                        <tr>
                                                                                                            <td colspan="3">
                                                                                                                <asp:Label ID="lblTitConvenio" runat="server" Font-Bold="True" Font-Size="Medium" Text="Anexar Convenio"></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblConvenio" runat="server" Font-Bold="True" Text="*Solo formatos PNG, JPG y PDF"></asp:Label></td>
                                                                                                            <td class="auto-style7">
                                                                                                                <asp:FileUpload ID="fileConvenio" runat="server" Height="30px" /></td>
                                                                                                            <td class="auto-style6">
                                                                                                                <asp:Button ID="btnConvenio" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnConvenio_Click" Text="ADJUNTAR" ValidationGroup="guardar" /></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="3">
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="fileConvenio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="center" class="auto-style38" colspan="3">
                                                                                                                <table style="width: 60%;" width="70%">
                                                                                                                    <tr align="center">
                                                                                                                        <td style="width: 50%;">
                                                                                                                            <asp:HyperLink ID="lblArchivoConvenio" runat="server" Target="_blank">[lblArchivoConvenio]</asp:HyperLink></td>
                                                                                                                        <td style="width: 50%;">
                                                                                                                            <asp:LinkButton ID="linkBttnEliminarConvenio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarConvenio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                            </td>
                                                                                            <table></table>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="btnConvenio" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </Content>
                                                                            </ajaxToolkit:AccordionPane>
                                                                        </Panes>
                                                                    </ajaxToolkit:Accordion>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style20">
                                                                    <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label></td>
                                                                <td colspan="2">
                                                                    <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged"></asp:DropDownList></td>
                                                                <td class="auto-style24">&#160;</td>
                                                                <td class="auto-style62">&#160;</td>
                                                                <td class="auto-style26">&#160;</td>
                                                                <td class="auto-style75">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="8">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td align="center">&#160;</td>
                                                                            <td align="center">
                                                                                <asp:CustomValidator ID="valConceptos" runat="server" ErrorMessage="*Se debe asignar al menor un concepto" OnServerValidate="ConceptosAsignados" ValidationGroup="DatosFiscales">*Conceptos Requeridos</asp:CustomValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" class="auto-style17">
                                                                                <asp:Label ID="lblConceptosDisp" runat="server" Text="Conceptos Disponibles"></asp:Label></td>
                                                                            <td align="center" class="mensaje_celeste">
                                                                                <asp:Label ID="lblConceptosAsig" runat="server" Text="Conceptos Asignados"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style18" valign="top">
                                                                                <div id="divGrid" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                                    <asp:GridView ID="grvConceptosDisp" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptosDisp_PageIndexChanging" OnSelectedIndexChanged="grvConceptosDisp_SelectedIndexChanged" Width="100%">
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
                                                                            </td>
                                                                            <td valign="top">
                                                                                <div id="divGrid" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
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
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="auto-style18">&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style20">&#160;</td>
                                                                <td class="auto-style19">&#160;</td>
                                                                <td class="auto-style62">&#160;</td>
                                                                <td class="auto-style24">&#160;</td>
                                                                <td class="auto-style62">&#160;</td>
                                                                <td class="auto-style26">&#160;</td>
                                                                <td class="auto-style75">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style20">&#160;</td>
                                                                <td class="auto-style19">&#160;</td>
                                                                <td class="auto-style62">&#160;</td>
                                                                <td class="auto-style24">&#160;</td>
                                                                <td class="auto-style62">&#160;</td>
                                                                <td class="auto-style26">&#160;</td>
                                                                <td class="auto-style75">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Imagen de la Factura">
                                            <HeaderTemplate>Archivos</HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:UpdatePanel ID="UpdatePanelFoto" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left" class="auto-style14">&#160;</td>
                                                                <td align="center">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="auto-style14">&#160;</td>
                                                                <td align="center">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="auto-style14" valign="top">
                                                                    <asp:Label ID="lblFolio_Fact_Cja" runat="server" Text="Folio de la Factura:"></asp:Label></td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFolio_Fact_Cja" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFolio_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="auto-style14" valign="top">
                                                                    <asp:Label ID="lblFecha_Fact_Cja" runat="server" Text="Fecha de la Factura:"></asp:Label></td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFecha_Fact_Cja" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtFecha_Fact_Cja_CalendarExtender" runat="server" PopupButtonID="imgFecha_Fact_Cja" TargetControlID="txtFecha_Fact_Cja" />
                                                                    <asp:ImageButton ID="imgFecha_Fact_Cja" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />&#160;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFecha_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <div class="mensaje_naranja">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="auto-style6">
                                                                                    <asp:Label ID="lblArchivos" runat="server" Font-Bold="True" Text="*Solo formatos PDF Y XML"></asp:Label></td>
                                                                                <td class="auto-style7">
                                                                                    <asp:FileUpload ID="fileFactura" runat="server" Height="30px" /></td>
                                                                                <td>
                                                                                    <asp:Button ID="btnAgregaFactura" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="btnAgregaFactura_Click" Text="ADJUNTAR" ValidationGroup="adjuntarFactura" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style6" colspan="3">
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="fileFactura" ErrorMessage="Archivo incorrecto, debe ser un PDF o XML" ValidationExpression="(.*?)\.(xml|XML|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="auto-style14">&#160;</td>
                                                                <td align="center">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="style26" colspan="2">
                                                                    <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdArchivos_RowDeleting" Width="70%">
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
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="auto-style14">&#160;</td>
                                                                <td align="center">&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnAgregaFactura" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                &#160;&#160;&#160;
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                    </ajaxToolkit:TabContainer>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnGuardarEditar_Click" TabIndex="13" Text="GUARDAR" ValidationGroup="DatosFiscales" />
                                    &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="14" Text="CANCELAR" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style25">&nbsp;</td>
                    <td align="center" class="style24">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style25">&nbsp;</td>
                    <td align="center" class="style24">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
