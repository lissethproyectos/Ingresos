<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmConceptos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmConceptos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="mltViewConceptos" runat="server">
                            <asp:View ID="Hoja1" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-2">
                                            Nivel de Estudios
                                        </div>
                                        <div class="col-4">
                                            <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" TabIndex="1" Width="100%">
                                            </asp:DropDownList>
                                        </div>                                                                       
                                        <div class="col-2">
                                            Exclusivos para eventos
                                        </div>
                                        <div class="col-1 text-left">
                                            <asp:CheckBox ID="chkTipo" runat="server" AutoPostBack="True" OnCheckedChanged="chkTipo_CheckedChanged" Text="Si" />
                                        </div>
                                        <%--<div class="col-1">
                                            <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                        </div>--%>
                                        <div class="col-1">
                                            <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" />
                                        </div>
                                        <div class="col-1">
                                            </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False"
                                                OnSelectedIndexChanging="grvConceptos_SelectedIndexChanging" CssClass="mGrid" Width="100%" ShowHeaderWhenEmpty="True">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                                    <asp:BoundField DataField="DescNivel" HeaderText="Nivel" />
                                                    <asp:BoundField DataField="ClaveConcepto" HeaderText="Clave" />
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Concepto" />
                                                    <asp:BoundField DataField="ImporteConcepto" HeaderText="Importe" />
                                                    <asp:BoundField DataField="StatusStr" HeaderText="Status" />
                                                    <asp:BoundField DataField="CobroXMateriaStr" HeaderText="Cobro por Materia" />
                                                    <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:CommandField ShowSelectButton="True" SelectText="Editar" ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" HeaderText="Editar">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField HeaderText="Clonar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnCopiar" runat="server" ImageUrl="~/Imagenes/copiar_y_pegar.png" OnClick="imgBttnCopiar_Click" />
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
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                            &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                        </div>
                                    </div>

                                    <%--<asp:HiddenField ID="hddnModal" runat="server" />
                                    <ajaxToolkit:ModalPopupExtender ID="modal" runat="server" PopupControlID="pnlClonarConcepto" TargetControlID="hddnModal" BackgroundCssClass="modalBackground_Proy">
                                    </ajaxToolkit:ModalPopupExtender>--%>

                                    
                            </asp:View>
                            <asp:View ID="Hoja2" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-2">
                                            Clave
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtClave" runat="server" CssClass="box" MaxLength="200"
                                                TabIndex="1"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="txtClave" CssClass="MsjError" ErrorMessage="*Requerido"
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2">
                                            Concepto
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtConcepto" runat="server" Width="100%"
                                                CssClass="box" MaxLength="500" TabIndex="2"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="txtConcepto" CssClass="MsjError" ErrorMessage="*Requerido"
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Importe
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtImporte" runat="server" CssClass="box" MaxLength="10"
                                                TabIndex="3"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Requerido"
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtImporte" CssClass="MsjError" Display="Dynamic"
                                                ErrorMessage="* Solo Números" ValidationExpression="\d+"
                                                ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-md-2">
                                            Status
                                        </div>
                                        <div class="col-md-4">
                                            <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal"
                                                TabIndex="4">
                                                <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                                <asp:ListItem Value="B">Baja</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkEmitir_Via_Web" runat="server"
                                                Text="Mostrar en Ficha Referenciadas" TabIndex="5" />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkAplica_Descuento" runat="server" Text="Mostrar en Modulo de Exenciones"
                                                TabIndex="9" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkCobro_x_Materia" runat="server" TabIndex="6" Text="Cobro por Materia" />
                                        </div>
                                        <div class="col-md-3">
                                            Maximo Num. de Materias
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtMaximo_Materias" runat="server" CssClass="box" MaxLength="2" TabIndex="7" Text="0" Width="50px"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMaximo_Materias" CssClass="MsjError" Display="Dynamic" ErrorMessage="* Solo Números" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkPermite_Duplicidad" runat="server"
                                                Text="Duplicar el concepto (en caso de CONSTANCIAS DIVERSAS u otros)"
                                                TabIndex="8" />
                                        </div>
                                        <div class="col-md-6">
                                            <asp:CheckBox ID="chkSeleccionable" runat="server"
                                                Text="Aplica para eventos" TabIndex="10" />
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-2">
                                            Fecha Inicial de Cobro
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtFecha_Inicial" runat="server" Width="100px" CssClass="box"
                                                MaxLength="10" TabIndex="11"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Inicial" PopupButtonID="imgCalendarioIni" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </div>
                                        <div class="col-md-2">
                                            Fecha Final de Cobro
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtFecha_Final" runat="server" Width="100px" CssClass="box"
                                                MaxLength="10" TabIndex="12"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" TargetControlID="txtFecha_Final" PopupButtonID="imgCalendarioFin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </div>
                                        <div class="col-md-2">
                                            Porcentaje para aplicar la Ley 80-20 Institucional
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPorcentaje" runat="server" Width="50px" CssClass="box"
                                                Rows="3" TabIndex="13"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server"
                                                ControlToValidate="txtPorcentaje" CssClass="MsjError" Display="Dynamic"
                                                ErrorMessage="*Sólo Números" MaximumValue="100" MinimumValue="0" Type="Integer"
                                                ValidationGroup="guardar"></asp:RangeValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2">
                                            Observaciones
                                        </div>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Height="127px"
                                                TextMode="MultiLine" Width="100%"
                                                CssClass="box" MaxLength="1000" TabIndex="14"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-info" Height="45px" Text="GUARDAR" TabIndex="15" ValidationGroup="guardar"
                                                OnClick="btnGuardar_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnCancelar" runat="server"
                                                CssClass="btn btn-blue-grey" Height="45px" Text="CANCELAR"
                                                TabIndex="16" OnClick="btnCancelar_Click" />
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
    <div class="modal fade" id="modalClonar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="modOficios">Clonar</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col font-weight-bold">
                                                                <asp:Label ID="lblMsjCopia" runat="server" Text="Se copia el número de concepto "></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-8">
                                                                <asp:Label ID="lblTipo_C" runat="server" Text="¿Concepto exclusivo para evento?"></asp:Label>
                                                                </div>
                                                            <div class="col-md-2">
                                                                <asp:CheckBox ID="chkTipoC" runat="server" Text="Si" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col text-right">
                                                                <asp:Button ID="btnGuardar_C" runat="server" CssClass="btn btn-info" Height="45px" OnClick="btnGuardar_C_Click" Text="CLONAR" />
<%--                                                                &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btnCancelar_C_Click" Text="CANCELAR" />--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
      <script type="text/javascript">
          <%--function Conceptos() {
              $('#<%= grvConceptos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvConceptos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
          }--%>
          function Conceptos() {
              //$('input[type=search]').val('');
              $('#<%= grvConceptos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvConceptos.ClientID %>').find("tr:first"))).DataTable({
                  "destroy": true,
                  "stateSave": true
               });
          };
      </script>

</asp:Content>


