<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPagosSIAE.aspx.cs" Inherits="Recibos_Electronicos.Form.frmPagosSIAE" %>

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
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPrgNivelo" runat="server" AssociatedUpdatePanelID="updPnlNivel">
                    <ProgressTemplate>
                        <asp:Image ID="img3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div class="col-md-1">
                Ciclo
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="updPnlCiclo" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCicloEscolar" runat="server" Width="100%" CssClass="form-control">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPrgCiclo" runat="server" AssociatedUpdatePanelID="updPnlCiclo">
                    <ProgressTemplate>
                        <asp:Image ID="imgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>       
            <div class="col-md-3">
                <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia/Nombre" Visible="true" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel229" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                <asp:UpdateProgress ID="updPrReferencias" runat="server" AssociatedUpdatePanelID="UpdatePanel228">
                    <ProgressTemplate>
                        <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
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
                                <asp:TemplateField HeaderText="Pago Aplicado">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgStatus" runat="server" ImageUrl='<%# Bind("FACT_RECEPTOR_STATUS") %>' OnClick="imgStatus_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FACT_STATUS_NOTAS" />
                                <asp:BoundField DataField="FACT_STATUS" />
                                <asp:BoundField DataField="FACT_TIPO" HeaderText="Tipo" />
                                <asp:BoundField DataField="ID_FICHA_BANCARIA" />
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

    <asp:Panel ID="pnl_Alert" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
        <asp:Panel ID="pnlMsj" runat="server" Visible="False">
            <table width="100%">
                <tr>
                    <td align="left">&nbsp;</td>
                    <td>
                        <div class="card text-white bg-warning mb-3">
                            AVISO
                        </div>
                        <center>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td align="left">&nbsp;</td>
                    <td align="center">¿Esta seguro que desea modificar el pago? </td>
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
                        <asp:UpdatePanel ID="UpdatePanel227" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="CancelAlert" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="NO" />
                                &nbsp;<asp:Button ID="btnNueva" runat="server" CssClass="btn btn-primary" OnClick="btnNueva_Click" Text="SI" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>

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
                                    <div class="row">
                                        <div class="col-md-2">Escuela</div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtEscuela" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            Carrera
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtIdCarrera" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">Ciclo</div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtCiclo" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            Semestre
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtSemestre" runat="server" Width="100%"></asp:TextBox>
                                        </div>                                       
                                    </div>
                                    <div class="row">
                                         <div class="col-md-2">
                                            Matricula
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtMatricula" runat="server" Width="100%"></asp:TextBox>
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

                                        <div class="col-md-2">
                                            <asp:Label ID="lblPagoAplicado" runat="server" Text="Pago Aplicado"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:CheckBox ID="chkPagoAplicado" runat="server" Text="Si" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col font-weight-bold">
                                            <asp:Label ID="lblReferenciaOrig" runat="server" Text="Referencia SIAE"></asp:Label>
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
                                            &nbsp;<asp:Button ID="bttnConfirmaPago" runat="server" CssClass="btn btn-info" OnClick="bttnConfirmaPago_Click" Text="GUARDAR" ValidationGroup="Guardar" />
                                            &nbsp;<asp:Button ID="bttnGenerarRecibo" runat="server" CssClass="btn btn-primary" OnClick="bttnGenerarRecibo_Click" Text="GUARDAR Y GENERAR RECIBO" ValidationGroup="Multipagos" Visible="False" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="container">
                            <div class="row">
                                <div class="col">
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
                    null
                ]
            });

        }


    </script>
</asp:Content>
