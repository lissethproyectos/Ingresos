<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />

    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" CssClass="select2">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="row">
                                    <div class="col-md-2">
                                        Año
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlEjercicio" runat="server" Width="100%"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-1">
                                        Status
                                    </div>
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddlStatusB" runat="server" Width="100%">
                                            <asp:ListItem Value="T">TODOS</asp:ListItem>
                                            <asp:ListItem Value="S">SOLICITADO</asp:ListItem>
                                            <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                            <asp:ListItem Value="B">BAJA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        Tipo de Evento
                                    </div>
                                    <div class="col-md-2">
                                        <asp:UpdatePanel ID="updPnlDirigido" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlDirigido0" runat="server" AutoPostBack="True" Width="100%">
                                                    <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                    <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                    <asp:ListItem Value="P">Eventos Privados</asp:ListItem>
                                                    <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click"><i class="fa fa-search" aria-hidden="true"></i> Buscar</asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:UpdatePanel ID="updPnlEventos" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" EmptyDataText="No hay eventos registrados." OnRowEditing="grdEventos_RowEditing" OnRowCancelingEdit="grdEventos_RowCancelingEdit" OnRowUpdating="grdEventos_RowUpdating">
                                                    <Columns>
                                                        <asp:BoundField DataField="dependencia" HeaderText="DEPCIA" ReadOnly="True" />
                                                        <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="True" />
                                                        <asp:BoundField DataField="eventos" HeaderText="CVE" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="EVENTO">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkGenRef" runat="server" ToolTip="Generar Referencia"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="status" HeaderText="STATUS" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="FECHA INICIO">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtFechaIniG" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="calExtFechaIni" runat="server" TargetControlID="txtFechaIniG" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FECHA FINAL">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtFechaFinG" runat="server" Text='<%# Bind("fecha_final") %>'></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFinG" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha_final") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField EditText="Editar Fechas" ShowEditButton="True" ItemStyle-ForeColor="#990033" HeaderText="VIGENCIA">
                                                            <ItemStyle ForeColor="#990033" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField HeaderText="OFICIO(S)">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" Height="25px" Text='<%# Bind("NoOficio") %>' Width="80px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-warning" Text="NUEVO" ValidationGroup="Agregar" OnClick="bttnNuevo_Click" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%--                                                        &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit2.png" Visible='<%# Bind("EsVisible2") %>' />--%>
                                                                <asp:LinkButton ID="linkBttnEditEnabled" runat="server" Visible='<%# Bind("EsVisible2") %>'><i class="fa fa-pencil  fa-2x disabled" aria-hidden="true"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="linkBttnEdit" runat="server" Visible='<%# Bind("EsVisible") %>' OnClick="linkBttnEdit_Click"><i class="fa fa-pencil  fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="linkBttnEliminar" runat="server"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="linkBttnReporte" runat="server"><i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i></asp:LinkButton>

                                                                <%--<asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit.png" OnClick="imgBttnEditar_Click" Visible='<%# Bind("EsVisible") %>' />--%>
                                                                <%--                                                        &nbsp;<asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" />--%>
                                                                <%--&nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" Width="20px" />--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NUEVA_VERSION" ReadOnly="True" />
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" BackColor="#595959" ForeColor="White" Font-Size="10px" BorderColor="White" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%" CssClass="tabs-blue-grey" Font-Names="Calibri">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                        <HeaderTemplate>
                                            Datos Generales
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
                                        <ContentTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col text-center">
                                                        <asp:UpdateProgress ID="updMV" runat="server" AssociatedUpdatePanelID="updPnlTipoPart0">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgMV" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Tipo de Participante
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
                                                    </div>
                                                    <div class="col-md-2">
                                                        ¿Es ponente?
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                            <ContentTemplate>
                                                                <asp:CheckBox ID="chkPonente" runat="server" AutoPostBack="True" OnCheckedChanged="chkPonente_CheckedChanged" Text="Si" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:Label ID="lblConstancia" runat="server" Text="¿Requieren constancia?"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:CheckBox ID="chkConstancia" runat="server" Text="Si" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Participantes
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:UpdatePanel ID="updPnlCatTipoParticipantes" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLCatTipoParticipantes" runat="server" Width="100%" class="form-select">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Status
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:DropDownList ID="ddlStatusDet" runat="server">
                                                            <asp:ListItem Selected="True" Value="S">Solicitado</asp:ListItem>
                                                            <asp:ListItem Value="A">Autorizado</asp:ListItem>
                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Nivel
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:UpdatePanel ID="updPnlNivel" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-1">
                                                        <asp:Button ID="bttnAgregarParticipante" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="bttnAgregarParticipante_Click" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdEventoDetalle" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" OnSelectedIndexChanged="grdEventoDetalle_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ID" HeaderText="ID">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Tipo_Participante" HeaderText="TIPO PARTICIPANTE">
                                                                            <ItemStyle BackColor="#FFFF66" Font-Bold="True" VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Participante" HeaderText="PARTICIPANTE">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Es_Ponente" HeaderText="¿ES PONENTE?">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Requiere_Constancia" HeaderText="CONSTANCIA">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="ELIMINAR">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkBttnEliminarDet" runat="server" CssClass="btn btn-blue-grey"><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkBttnAgregarConcep" runat="server" CausesValidation="False" CommandName="Select"  CssClass="btn btn-blue-grey"><i aria-hidden="true" class="fa fa-plus-square"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CONCEPTOS">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="grdEventoConceptos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" ShowHeaderWhenEmpty="True" Width="100%" EmptyDataText="No existen conceptos asignados.">
                                                                                            <Columns>
                                                                                                <asp:BoundField HeaderText="CONCEPTO" DataField="DescConcepto" />
                                                                                                <asp:BoundField HeaderText="IMPORTE" DataField="IMPORTE" />
                                                                                                <asp:BoundField DataField="DescCarrera" HeaderText="DESCRIPCIÓN" />
                                                                                                <asp:CommandField ShowDeleteButton="True" />
                                                                                            </Columns>
                                                                                            <EmptyDataRowStyle ForeColor="Red" />
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>

                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="50%" />
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
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                        <ContentTemplate>
                                            asas
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">Conceptos</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlConceptoFil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConceptoFil_SelectedIndexChanged" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Descripción de Pago</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlObservacion" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtObservacion" runat="server" AutoPostBack="True" Width="100%"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtObservacion" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">Importe</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox runat="server" ID="txtImporte"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="bttnAgregarConc" runat="server" Text="AGREGAR" class="btn btn-primary" OnClick="bttnAgregarConcepto_Click"/>
                    <asp:Button ID="bttnSalirConc" runat="server" Text="SALIR" class="btn btn-blue-grey" data-dismiss="modal"/>                    
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function Eventos() {

            $('#<%= grdEventos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdEventos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });

        }

        function FiltDepcias() {
            $(".select2").select2();
        }
    </script>
</asp:Content>
