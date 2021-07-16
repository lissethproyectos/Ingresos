<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConfiguracionEventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmConfiguracionEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style29 {
            width: 585px;
        }

        #scrolly {
            width: 1000px;
            height: 400px;
            overflow: auto;
            overflow-y: auto;
            margin: 0 auto;
            white-space: nowrap;
        }

        .scrolling-table-container {
    height: 378px;
    overflow-x: scroll;
    overflow-y: hidden;
}
        /*.TituloModalPopupMsg{
            z-index: 2 !important;
        }
        .modalBackground_Proy{
            z-index: 1 !important;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="True" Width="100%">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="* Requerido" InitialValue="00000" ValidationGroup="Agregar">* Requerido</asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row" id="divFiltros" runat="server">
                                <div class="col-md-2">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                </div>
                                <div class="col-md-4">

                                    <asp:DropDownList ID="ddlStatusB" runat="server" Width="100%">
                                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                                        <asp:ListItem Value="S">SOLICITADO</asp:ListItem>
                                        <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                        <asp:ListItem Value="B">BAJA</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblDirigido0" runat="server" Text="Tipo de Evento"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:UpdatePanel ID="updPnlDirigido" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDirigido0" runat="server" AutoPostBack="True" Width="100%">
                                                <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Para guardar el registro se requieren los siguientes campos:" ValidationGroup="guardar" />

                                </div>
                            </div>
                        </ContentTemplate>

                    </asp:UpdatePanel>

                </div>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col text-center">
                            <asp:UpdateProgress ID="updMV" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                                <ProgressTemplate>
                                    <asp:Image ID="imgMV" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txtBusqueda" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" title="Buscar" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col">
                                                <asp:GridView ID="grdEventos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" EmptyDataText="No hay eventos registrados." ShowHeaderWhenEmpty="True" OnPageIndexChanging="grdEventos_PageIndexChanging" OnRowEditing="grdEventos_RowEditing" OnRowCancelingEdit="grdEventos_RowCancelingEdit" OnRowUpdating="grdEventos_RowUpdating">
                                                    <Columns>
                                                        <asp:BoundField DataField="dependencia" HeaderText="Depcia" ReadOnly="True" />
                                                        <asp:BoundField DataField="eventos" HeaderText="Cve" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="Evento">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkGenRef" runat="server" OnClick="lnkGenRef_Click" ToolTip="Generar Referencia"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fecha inicial">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtFechaIniG" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="calExtFechaIni" runat="server" TargetControlID="txtFechaIniG" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Fecha final">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtFechaFinG" runat="server" Text='<%# Bind("fecha_final") %>'></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFinG" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha_final") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField EditText="Editar Fechas" ShowEditButton="True" ItemStyle-ForeColor="#990033" HeaderText="Vigencia">
                                                            <ItemStyle ForeColor="#990033" />
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="nivel" HeaderText="Nivel" ReadOnly="True" />
                                                        <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-mdb-color" OnClick="bttnNuevo_Click" Text="NUEVO" ValidationGroup="Agregar" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit2.png" Visible='<%# Bind("EsVisible2") %>' />
                                                                <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit.png" OnClick="imgBttnEditar_Click" Visible='<%# Bind("EsVisible") %>' />
                                                                &nbsp;<asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" OnClick="ctrl_eliminar_Click" />
                                                                &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" OnClick="imgBttnReporte_Click" Width="20px" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Oficio(s)">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Text='<%# Bind("NoOficio") %>' Font-Size="XX-Small" Width="80px" OnClick="btnOficios_Click" Height="25px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NUEVA_VERSION" ReadOnly="True" />
                                                        <asp:TemplateField></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Evento Exclusivo">
                                                            <ItemTemplate>
                                                                <asp:Button ID="bttnAgregarParticipantes" runat="server" CssClass="btn btn-blue-grey" Text="AGREGAR CVES" Visible='<%# Bind("VisibleAutorizacion") %>' Font-Size="9px" OnClick="bttnAgregarParticipantes_Click" Height="25px" Width="80px" />
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
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%" CssClass="styleTab" ScrollBars="Horizontal">
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                            <HeaderTemplate>
                                                (1) Datos Generales
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblCve" runat="server" Text="Clave"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblCveDesc" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066CC"></asp:Label>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:Label ID="Label4" runat="server" Text="¿El Evento se mostrará en? "></asp:Label>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:DropDownList ID="ddlDirigido" runat="server" AutoPostBack="True" Width="100%">
                                                                <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                                <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                                <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="Label15" runat="server" Text="Nombre del Evento"></asp:Label>
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:TextBox ID="txtDescripcion" runat="server" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Nombre del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="Label16" runat="server" Text="E-mail Responsable"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:TextBox ID="txtEmail_res" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:TextBox ID="txtFecha_Evento_Ini" runat="server" AutoPostBack="True" onkeyup="javascript:this.value='';" Width="70%"></asp:TextBox>
                                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFecha_Evento_Ini" ErrorMessage="*Fecha Inicial del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" BehaviorID="_content_CalendarExtenderIni" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Evento_Ini" />

                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:TextBox ID="txtFecha_Evento_Fin" runat="server" AutoPostBack="True" onkeyup="javascript:this.value='';" Width="70%"></asp:TextBox>
                                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtFecha_Evento_Fin" ErrorMessage="*Fecha Final del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" BehaviorID="_content_CalendarExtenderFin" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Evento_Fin" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                                <asp:ListItem Selected="True" Value="S">Solicitado</asp:ListItem>
                                                                <asp:ListItem Value="A">Autorizado</asp:ListItem>
                                                                <asp:ListItem Value="B">Baja</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-3 font-weight-bold">
                                                            ¿Su evento es exclusivo?
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:RadioButtonList ID="rbnExclusivo" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="S">Si </asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="Label17" runat="server" Text="Especificaciones"></asp:Label>
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:TextBox ID="txtEspecificacion" runat="server" Height="69px" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                            <HeaderTemplate>
                                                (2) Configuración
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:DropDownList ID="ddlTipo_Periodo" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblTipoParticipante0" runat="server" Text="Tipo de Participante"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:UpdatePanel ID="updPnlTipoPart0" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DDLTipoParticipante" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="DDLTipoParticipante_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                        <asp:ListItem Value="S">Alumno/Cliente UNACH</asp:ListItem>
                                                                        <asp:ListItem Value="SX">Alumno Externo</asp:ListItem>
                                                                        <asp:ListItem Value="E">Empleado UNACH</asp:ListItem>
                                                                        <asp:ListItem Value="X">Público General</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="DDLTipoParticipante" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaConceptos">* Requerido</asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Button ID="bttnNuevoParticipante" runat="server" CssClass="btn btn-blue-grey" Text="Crear" OnClick="bttnNuevoParticipante_Click" />
                                                            <ajaxToolkit:ModalPopupExtender ID="modalNewParticipante" runat="server" TargetControlID="bttnNuevoParticipante" BehaviorID="_content_modalNewParticipante" CancelControlID="BttnSalirModalParticipante" DynamicServicePath="" PopupControlID="pnlTipoParticipante" BackgroundCssClass="modalBackground_Proy">
                                                            </ajaxToolkit:ModalPopupExtender>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="lblPonente" runat="server" Text="¿Es ponente?"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="chkPonente" runat="server" AutoPostBack="True" OnCheckedChanged="chkPonente_CheckedChanged" Text="Si" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Label ID="lblConstancia" runat="server" Text="¿Requieren constancia?"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:CheckBox ID="chkConstancia" runat="server" Text="Si" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblTipoParticipante1" runat="server" Text="Participantes"></asp:Label>
                                                        </div>
                                                        <div class="col-md-10">

                                                            <asp:DropDownList ID="DDLCatTipoParticipantes" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="DDLCatTipoParticipantes" InitialValue="9999999999" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblNivel" runat="server" Text="Nivel"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblId_Concepto" runat="server" Text="Concepto"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:DropDownList ID="ddlConceptoFil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConceptoFil_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                            <asp:UpdatePanel ID="updPnlConceptos" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlConceptoFil" InitialValue="00000" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblObservaciones" runat="server" Text="Descripión de Pago"></asp:Label>
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:UpdatePanel ID="updPnlObservacion" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtObservacion" runat="server" AutoPostBack="True" OnTextChanged="txtObservaciones_TextChanged" Width="100%"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtObservacion" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <asp:Label ID="lblImporte" runat="server" Text="Importe"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                            <asp:UpdatePanel ID="updPnlImporte" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtImporte" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregaConceptos">* Requerido</asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-2 text-xl-right">
                                                            <asp:Label ID="lblSatusConcep" runat="server" Text="Status"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <asp:CheckBox ID="chkActivo" runat="server" Checked="True" Text="Activo" />
                                                            &#160;<asp:Button ID="btnAgregarConcepto" runat="server" CssClass="btn btn-blue-grey" OnClick="btnAgregarConcepto_Click" Text="Agregar" ValidationGroup="AgregaConceptos" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col text-center card-header">
                                                            PARTICIPANTE(S) Y CONCEPTO(S)
                                                               
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">

                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="scrolling-table-container">
                                                                        <asp:GridView ID="grvTiposParticipantes" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se ha agregado ningún tipo de participante" OnRowCancelingEdit="grvTiposParticipantes_RowCancelingEdit" OnRowEditing="grvTiposParticipantes_RowEditing" OnRowUpdating="grvTiposParticipantes_RowUpdating" SelectedIndex="0" ShowHeaderWhenEmpty="True" Style="width: 100%;">
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <Columns>

                                                                                <asp:BoundField DataField="Participante" HeaderText="TIPO DE PARTICIPANTE" ReadOnly="True">
                                                                                    <ItemStyle Font-Bold="True" Font-Size="Small" ForeColor="#006600" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Tipo_Participante" HeaderText="Participante" ReadOnly="True" />
                                                                                <asp:BoundField DataField="Id_Tipo_Participante" ReadOnly="True" HeaderText="Id TipoPart" />
                                                                                <asp:BoundField DataField="Desc_Tipo_Participante" HeaderText="DESCRIPCIÓN PARA FICHA REFERENCIADA" ReadOnly="True" />
                                                                                <asp:BoundField DataField="ES_PONENTE" HeaderText="¿Es Ponente?" ReadOnly="True" />
                                                                                <asp:TemplateField HeaderText="¿Constancia?">
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlRequiereConstancia" runat="server" SelectedValue='<%# Bind("Requiere_Constancia") %>'>
                                                                                            <asp:ListItem Value="N">NO</asp:ListItem>
                                                                                            <asp:ListItem Value="S">SI</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Requiere_Constancia") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Concepto" HeaderText="Concepto" ReadOnly="True" />
                                                                                <asp:BoundField DataField="Id_Concepto" HeaderText="Id Conc." ReadOnly="True" />
                                                                                <asp:BoundField DataField="Observaciones" HeaderText="Desc. Pago">
                                                                                    <ItemStyle Height="50px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Importe" HeaderText="Importe" />
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                    <EditItemTemplate>
                                                                                        <asp:DropDownList ID="ddlStatusConc" runat="server" SelectedValue='<%# Bind("STATUS") %>'>
                                                                                            <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblStatusConc" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:CommandField EditImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" ShowEditButton="True" />
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <%--                                                                                            <asp:LinkButton ID="linkVerTipoPart" runat="server" OnClick="linkVerTipoPart_Click" Visible="False">Seleccionar</asp:LinkButton>--%>&#160;<asp:LinkButton ID="linkEliminarTipoPart" runat="server" OnClick="linkEliminarTipoPart_Click" OnClientClick="return confirm('¿Eliminar registro?');">Eliminar</asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <FooterStyle CssClass="enc" />
                                                                            <HeaderStyle CssClass="enc" Font-Size="Small" />
                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                            <RowStyle Font-Size="XX-Small" />
                                                                            <SelectedRowStyle CssClass="sel" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Panel ID="pnlTipoParticipante" runat="server" CssClass="TituloModalPopupMsg" Width="650px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td class="auto-style75">
                                                                <asp:Label ID="lblTipoParticipante" runat="server" Text="Tipo de Participante:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="updPnlTipoPart" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="DDLTipoParticipanteNew" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoParticipanteNew_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                            <asp:ListItem Value="S">Alumno/Cliente UNACH</asp:ListItem>
                                                                            <asp:ListItem Value="SX">Alumno Externo</asp:ListItem>
                                                                            <asp:ListItem Value="E">Empleado UNACH</asp:ListItem>
                                                                            <asp:ListItem Value="X">Público General</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <br />
                                                            </td>
                                                            <td>&#160;</td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="DDLTipoParticipanteNew" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style75">
                                                                <asp:Label ID="Label22" runat="server" Text="Descripción del Tipo de Participante:"></asp:Label>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:UpdatePanel ID="updPnlDescTipoPart" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtDesc_Tipo_Participante" runat="server" Width="100%"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDesc_Tipo_Participante" ErrorMessage="* Descripción" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style75">
                                                                <asp:Label ID="lblPonente0" runat="server" Text="¿Es ponente?"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:CheckBox ID="chkPonenteNew" runat="server" AutoPostBack="True" OnCheckedChanged="chkPonenteNew_CheckedChanged" Text="Si" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>&#160;</td>
                                                            <td>&#160;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="text-center" colspan="4" valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button ID="btnAgregarParticipante" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarParticipante_Click" Text="Agregar" ValidationGroup="AgregaParticipante" />
                                                                        &#160;<asp:Button ID="BttnSalirModalParticipante" runat="server" CssClass="btn btn-blue-grey" Text="Salir" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style75" valign="top">&#160;</td>
                                                            <td valign="top">&#160;</td>
                                                            <td>&#160;</td>
                                                            <td>&#160;</td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                            <HeaderTemplate>
                                                (3) Oficio(s)
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-md-2">No. de Oficio</div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox ID="txtNoOficio" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNoOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">*Requerido</asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-2">Fecha de Oficio</div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox ID="txtFechaOficio" runat="server" AutoPostBack="True" Width="95px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="txtFechaOficio_CalendarExtender" runat="server" BehaviorID="_content_txtFechaOficio_CalendarExtender" PopupButtonID="imgCalendarOficio" TargetControlID="txtFechaOficio" />
                                                            <asp:ImageButton ID="imgCalendarOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtNoOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">*Requerido</asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            Firmado por
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox ID="txtFirma" runat="server" Width="100%"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            Observaciones
                                                        </div>
                                                        <div class="col-md-4">
                                                            <asp:TextBox ID="txtObservaciones_oficio" runat="server" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row alert alert-info">
                                                        <div class="col-md-4">
                                                            <i class="fas fa-info-circle"></i>Solo formatos PDF, JPG Y PNG</b></td>
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileOficio" runat="server" />
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="FileOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">* Requerido</asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileOficio" ErrorMessage="Archivo incorrecto, debe ser un PDF/JPG/PNG" ValidationExpression="(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                    <br />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="btnAgregarOficio" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <asp:Button ID="btnAgregarOficio" runat="server" CssClass="btn btn-blue-grey" OnClick="btnAgregarOficio_Click" Text="Agregar" ValidationGroup="AgregarOficio" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:GridView ID="grdOficios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnPageIndexChanging="grdOficios_PageIndexChanging">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="NumOficio" HeaderText="# Oficio" />
                                                                    <asp:BoundField DataField="FechaOficio" HeaderText="fecha">
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FirmaOficio" HeaderText="Firma" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkArchivo") %>' Target="_blank">Ver</asp:HyperLink>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="ctrl_eliminarOficio" runat="server" OnClientClick="return confirm('¿Eliminar registro?');" ToolTip="Eliminar" OnClick="ctrl_eliminarOficio_Click"><img src="https://sysweb.unach.mx/resources/imagenes/del.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NombreArchivo" />
                                                                    <asp:BoundField DataField="Observaciones" />
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
                                        </ajaxToolkit:TabPanel>
                                    </ajaxToolkit:TabContainer>
                                    <br />
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col">
                                                <div class="card-deck">
                                                    <div class="card border-info mb-3 font-weight-bold">
                                                        <div class="card-body">
                                                            <h5 class="card-title">Solicitó</h5>
                                                            <p class="card-text  text-info">
                                                                <asp:Label ID="lblUsuSolicitado" runat="server"></asp:Label>
                                                            </p>
                                                        </div>
                                                        <div class="card-footer">
                                                            <small class="text-muted">
                                                                <asp:Label ID="lblFechaSolicitado" runat="server"></asp:Label></small>
                                                        </div>
                                                    </div>
                                                    <div class="card border-info mb-3 font-weight-bold">
                                                        <div class="card-body">
                                                            <h5 class="card-title">Autorizó</h5>
                                                            <p class="card-text text-info">
                                                                <asp:Label ID="lblUsuAutorizado" runat="server"></asp:Label>
                                                            </p>
                                                        </div>
                                                        <div class="card-footer">
                                                            <small class="text-muted">
                                                                <asp:Label ID="lblFechaAutorizado" runat="server"></asp:Label>
                                                            </small>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-right">
                                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:HiddenField ID="hddnDoctosAdj" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="modalDoctosAdj" runat="server" TargetControlID="hddnDoctosAdj" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlDoctos">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="pnlDoctos" runat="server" CssClass="TituloModalPopupMsg" Width="450px">
                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                        <ContentTemplate>
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col">
                                        <asp:GridView ID="grdOficiosAdj" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grdOficios_PageIndexChanging" Width="100%">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <Columns>
                                                <asp:BoundField DataField="NumOficio" HeaderText="nooficio" />
                                                <asp:BoundField DataField="FechaOficio" HeaderText="fecha">
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FirmaOficio" HeaderText="Firma" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Bind("LinkArchivo") %>' Target="_blank">Ver</asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <HeaderStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Button ID="BttnSalirModal" runat="server" CssClass="btn btn-blue-grey" OnClick="BttnSalirModal_Click" Text="Salir" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>
        </div>

    </div>
</asp:Content>
