<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="Recibos_Electronicos.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap 101 Template</title>
    <!-- Bootstrap -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
 <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
<ajaxToolkit:Accordion ID="Accordion1" runat="server" FadeTransitions="True" FramesPerSecond="50" HeaderCssClass="accordionCabecera" HeaderSelectedCssClass="cssHeaderSelected" Height="700px" RequireOpenedPane="False" SelectedIndex="-1" TransitionDuration="200" Width="100%" CssClass="accordion">
                                                            <Panes>
                                                                <ajaxToolkit:AccordionPane runat="server">
                                                                    <Header>
                                                                        Datos del Voucher
                                                                    </Header>
                                                                    <Content>
                                                                        <div class="container-fluid">
                                                                            <div class="row">
                                                                                <div class="col-md-1">Folio</div>
                                                                                <div class="col-md-1">
                                                                                    <asp:TextBox ID="txtFolio" runat="server" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Datos del Voucher - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </div>
                                                                                <div class="col-md-1">Fecha Pago</div>
                                                                                <div class="col-md-2">
                                                                                    <asp:TextBox ID="txtFecha" runat="server" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                                                                                    <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Datos del Voucher - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </div>
                                                                                <div class="col-md-1">Importe</div>
                                                                                <div class="col-md-1">
                                                                                    <asp:TextBox ID="txtImporte" runat="server" Width="100%"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporte" ErrorMessage="*Importe(Datos del Voucher - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:CheckBox ID="chkIvaDes" runat="server" AutoPostBack="True" Text="¿Con IVA desglozado?" OnCheckedChanged="chkIvaDes_CheckedChanged" />
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </div>
                                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div class="row" runat="server" id="rowIvaDesglozado" visible="false">
                                                                                        <div class="col-md-1">IVA</div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:TextBox ID="txtIvaDes" runat="server" Width="100%"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="reqIvaDes" runat="server" ControlToValidate="txtIvaDes" ErrorMessage="*Iva (Datos del Voucher - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-md-1">Total</div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:TextBox ID="txtTotalDes" runat="server" Width="100%"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="reqTotDes" runat="server" ControlToValidate="txtTotalDes" ErrorMessage="*Total (Datos del Voucher - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <div class="row">
                                                                                <div class="col">
                                                                                    <div class="alert-warning">
                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <div class="container-fluid">
                                                                                                    <div class="note note-warning" style="font-size: 14px">
                                                                                                        <div class="row">
                                                                                                            <div class="col">
                                                                                                                Anexar Voucher
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="row">
                                                                                                            <div class="col">
                                                                                                                <div class="col font-weight-bold">
                                                                                                                    *Solo formatos PNG, JPG y PDF
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Archivo XML" ControlToValidate="fileVoucher" Text="* Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="row">
                                                                                                            <div class="col-md-8">
                                                                                                                <asp:FileUpload ID="fileVoucher" runat="server" Height="30px" />
                                                                                                            </div>
                                                                                                            <div class="col-md-4">
                                                                                                                <asp:Button ID="btnVoucher" runat="server" CssClass="btn btn-blue-grey" OnClick="btnVoucher_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="row">
                                                                                                            <div class="col-md-6">
                                                                                                                <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                            </div>

                                                                                                            <div class="col-md-6">
                                                                                                                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                                                                    <ContentTemplate>
                                                                                                                        <asp:LinkButton ID="linkBttnEliminarVoucher" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarVoucher_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                                    </ContentTemplate>
                                                                                                                </asp:UpdatePanel>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="btnVoucher" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </Content>
                                                                </ajaxToolkit:AccordionPane>
                                                                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1" CssClass="note-info">
                                                                    <Header>
                                                                        Datos del Oficio <i class="fa fa-file-text" aria-hidden="true"></i>
                                                                    </Header>
                                                                    <Content>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="container-fluid">
                                                                                    <div class="row">
                                                                                        <div class="col-md-2">
                                                                                            Núm. de Oficio
                                                                                        </div>
                                                                                        <div class="col-md-3">
                                                                                            <asp:TextBox ID="txtNumOficio" runat="server"></asp:TextBox>
                                                                                        </div>
                                                                                        <div class="col-md-1">
                                                                                            <asp:RequiredFieldValidator ID="valNumOficio" runat="server" ControlToValidate="txtNumOficio" ErrorMessage="*Número de Oficio (Pestania 2-&gt;Datos del Oficio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-md-2">
                                                                                            Fecha Oficio
                                                                                        </div>
                                                                                        <div class="col-md-4">
                                                                                            <asp:TextBox ID="txtFechaOficio" runat="server"></asp:TextBox>
                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtFechaOficio" />
                                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaOficio" ErrorMessage="*Fecha Oficio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="container-fluid">
                                                                                    <div class="note note-warning" style="font-size: 14px">
                                                                                        <div class="row">
                                                                                            <div class="col">
                                                                                                Anexar Oficio
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col">
                                                                                                <div class="col font-weight-bold">
                                                                                                    *Solo formatos PNG, JPG y PDF
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileOficio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-md-8">
                                                                                                <asp:FileUpload ID="fileOficio" runat="server" Height="30px" />
                                                                                            </div>
                                                                                            <div class="col-md-4">
                                                                                                <asp:Button ID="btnOficio" runat="server" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="btnOficio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="row">
                                                                                            <div class="col-md-4">
                                                                                                <asp:HyperLink ID="lblArchivoOficio" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                            </div>
                                                                                            <div class="col-md-4">
                                                                                                <asp:LinkButton ID="linkBttnEliminarOficio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarOficio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:PostBackTrigger ControlID="btnOficio" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                    </Content>
                                                                </ajaxToolkit:AccordionPane>
                                                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                                    <Header>
                                                                        Importe/Convenio <i class="fa fa-money" aria-hidden="true"></i>
                                                                    </Header>
                                                                    <Content>
                                                                        <asp:UpdatePanel ID="updPnlConvenio" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="container-fluid">
                                                                                    <div class="row">
                                                                                        <div class="col-md-1">
                                                                                            Importe
                                                                                        </div>
                                                                                        <div class="col-md-2">
                                                                                            <asp:TextBox ID="txtImporteConvenio" runat="server" Width="100px"></asp:TextBox>


                                                                                            <asp:RequiredFieldValidator ID="valImpConvenio" runat="server" ControlToValidate="txtImporteConvenio" ErrorMessage="*Importe (Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                        <div class="col-md-2">
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
                                                                                        <div class="col-md-2">
                                                                                            Observaciones
                                                                                        </div>
                                                                                        <div class="col-md-10">
                                                                                            <asp:TextBox ID="txtObservacionesConvenio" runat="server" Height="100px" PlaceHolder="Especificar concepto de la factura, el importe total, en caso de que aplique desglosar IVA." TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="row">
                                                                                        <div class="col">
                                                                                            <div class="note note-warning" style="font-size: 14px">
                                                                                                <div class="row">
                                                                                                    <div class="col">
                                                                                                        Anexar Convenio
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col font-weight-bold">
                                                                                                        *Solo formatos PNG, JPG y PDF
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="fileConvenio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
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
                                                                                                    <div class="col-md-10">
                                                                                                        <asp:HyperLink ID="lblArchivoConvenio" runat="server" Target="_blank">[lblArchivoConvenio]</asp:HyperLink>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
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
    </form>
</body>
</html>
