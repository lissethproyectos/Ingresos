<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />

    <style type="text/css">
        .scrollGrid {
            overflow-x: scroll;
            overflow-y: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-1">
                Depcia
            </div>
            <div class="col-md-9">
                <asp:UpdatePanel ID="updPnlDepcia" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" CssClass="select2" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="reqDepcia" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="*Dependencia" ValidationGroup="guardar" InitialValue="00000">*Requerido</asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="updPnlCrearPart" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="bttnCrearPart" runat="server" CssClass="btn btn-grey" OnClick="bttnCrearPart_Click" Text="Catálogo Participantes" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrBuscarDatos" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgDatos" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1">
                                        Año
                                    </div>
                                    <div class="col-md-1">
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
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="updPnlDirigido" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlDirigido0" runat="server" Width="100%">
                                                    <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                    <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                    <asp:ListItem Value="Z">Eventos Privados</asp:ListItem>
                                                    <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click"><i class="fa fa-search" aria-hidden="true"></i> Ver Eventos</asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrEventos" runat="server" AssociatedUpdatePanelID="updPnlEventos">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgEventos" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <asp:UpdatePanel ID="updPnlEventos" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" EmptyDataText="No hay eventos registrados." OnRowEditing="grdEventos_RowEditing" OnRowCancelingEdit="grdEventos_RowCancelingEdit" OnRowUpdating="grdEventos_RowUpdating" ShowHeaderWhenEmpty="True" OnRowDeleting="grdEventos_RowDeleting">
                                                    <Columns>
                                                        <asp:BoundField DataField="dependencia" HeaderText="DEPCIA" ReadOnly="True" />
                                                        <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="True" />
                                                        <asp:BoundField DataField="eventos" HeaderText="CVE" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="EVENTO">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkGenRef" runat="server" OnClick="lnkGenRef_Click" ToolTip="Generar Referencia"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="status" HeaderText="STATUS" ReadOnly="True">
                                                            <ItemStyle Font-Bold="True" Font-Size="14px" />
                                                        </asp:BoundField>
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
                                                                <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" Height="25px" Text='<%# Bind("NoOficio") %>' Width="80px" OnClick="btnOficios_Click" />
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
                                                                &nbsp;<asp:LinkButton ID="linkBttnEliminar" runat="server" OnClientClick="return confirm('¿Eliminar registro?');" CommandName="Delete"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="linkBttnReporte" runat="server" OnClick="linkBttnReporte_Click"><i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i></asp:LinkButton>

                                                                <%--<asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit.png" OnClick="imgBttnEditar_Click" Visible='<%# Bind("EsVisible") %>' />--%>
                                                                <%--                                                        &nbsp;<asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" />--%>
                                                                <%--&nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" Width="20px" />--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NUEVA_VERSION" ReadOnly="True">
                                                            <ItemStyle Width="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Eventos" />
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
                                <div class="row">
                                    <div class="col text-right">
                                        <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" Visible="False" />
                                        &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" Font-Names="Calibri" Height="100%">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                        <HeaderTemplate>
                                            Datos Generales
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Clave
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:Label ID="lblCveDesc" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066CC">---</asp:Label>
                                                    </div>
                                                    <div class="col-md-3 text-right">
                                                        ¿El Evento se mostrará en?
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="ddlDirigido" runat="server" AutoPostBack="True" CssClass="form-control">
                                                            <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                            <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                            <asp:ListItem Value="Z">Eventos Privados</asp:ListItem>
                                                            <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Tipo Acceso
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:DropDownList ID="ddlTipoAcceso" runat="server" CssClass="form-control" Enabled="False">
                                                            <asp:ListItem Value="P">Público General</asp:ListItem>
                                                            <asp:ListItem Value="A">Administradores</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Nombre del Evento
                                                    </div>
                                                    <div class="col-md-11">
                                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Nombre del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        @Responsable
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtEmail_res" runat="server" class="form-control" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Tel Responsable
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtTelResp" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Página Web
                                                    </div>
                                                    <div class="col-md-5">
                                                        <asp:TextBox ID="txtUrlEvento" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Fecha Ini
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtFecha_Evento_Ini" runat="server" AutoPostBack="True" onkeyup="javascript:this.value='';" Width="70%"></asp:TextBox>
                                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFecha_Evento_Ini" ErrorMessage="*Fecha Inicial del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" BehaviorID="_content_CalendarExtenderIni" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Evento_Ini" />

                                                    </div>
                                                    <div class="col-md-1">
                                                        Fecha Final
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtFecha_Evento_Fin" runat="server" AutoPostBack="True" onkeyup="javascript:this.value='';" Width="70%"></asp:TextBox>
                                                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtFecha_Evento_Fin" ErrorMessage="*Fecha Final del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" BehaviorID="_content_CalendarExtenderFin" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Evento_Fin" />
                                                    </div>
                                                </div>
                                                <hr />
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Ciclo
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlCiclo" runat="server" CssClass="form-control"></asp:DropDownList>
                                                       <%-- <div class="input-group mb-3">
                                                            <asp:ListBox ID="lstCiclo" runat="server" CssClass="form-control"></asp:ListBox>
                                                            <span id="basic-addon3">
                                                                <asp:LinkButton ID="linkBttnAgregarCiclo" CssClass="input-group-text btn-grey" runat="server" data-toggle="modal" data-target="#modalCiclos"><i class="fa fa-plus-circle" aria-hidden="true"></i>&nbsp;Agregar</asp:LinkButton>
                                                            </span>
                                                        </div>--%>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Status
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                            <asp:ListItem Selected="True" Value="S">Solicitado</asp:ListItem>
                                                            <asp:ListItem Value="A">Autorizado</asp:ListItem>
                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-2 font-weight-bold">
                                                        ¿Evento exclusivo?
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:UpdatePanel ID="updPnlEvExc" runat="server">
                                                            <ContentTemplate>
                                                                <asp:RadioButtonList ID="rbnExclusivo" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbnExclusivo_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Value="S">Si
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Nota
                                                    </div>
                                                    <div class="col-md-11">
                                                        <asp:TextBox ID="txtEspecificacion" runat="server" Height="69px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                        <HeaderTemplate>
                                            Participantes y Conceptos
                                        </HeaderTemplate>
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
                                                    <div class="col-md-1">
                                                        Tipo de Participante
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:UpdatePanel ID="updPnlTipoPart0" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLTipoParticipante" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoParticipante_SelectedIndexChanged" CssClass="form-control">
                                                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                    <asp:ListItem Value="S">Alumno/Cliente UNACH</asp:ListItem>
                                                                    <asp:ListItem Value="SX">Alumno Externo</asp:ListItem>
                                                                    <asp:ListItem Value="E">Empleado UNACH</asp:ListItem>
                                                                    <asp:ListItem Value="X">Público General</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="DDLTipoParticipante" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaPart">* Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:LinkButton ID="linkBttnNuevoParticipante" runat="server" CssClass="btn btn-info" OnClick="linkBttnNuevoParticipante_Click" Font-Size="9px"><i class="fa fa-user fa-2x"></i>&nbsp;Crear</asp:LinkButton>

                                                    </div>
                                                    <div class="col-md-1">
                                                        ¿Es ponente?
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                            <ContentTemplate>
                                                                <asp:CheckBox ID="chkPonente" runat="server" AutoPostBack="True" OnCheckedChanged="chkPonente_CheckedChanged" Text="Si" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-2 text-right">
                                                        ¿Requieren constancia?
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:CheckBox ID="chkConstancia" runat="server" Text="Si" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Nivel
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:UpdatePanel ID="updPnlNivel" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <br />
                                                        <asp:RequiredFieldValidator ID="reqNivel" runat="server" ControlToValidate="ddlNivel" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="AgregaPart">* Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Participantes
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:UpdatePanel ID="updPnlCatTipoParticipantes" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="DDLCatTipoParticipantes" runat="server" CssClass="form-control" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="reqTipPart" runat="server" ControlToValidate="DDLCatTipoParticipantes" ErrorMessage="Participante" InitialValue="9999999999" ValidationGroup="AgregaPart">* Requerido</asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Status Part
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:UpdatePanel ID="updAgregaPart" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlStatusPart" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:LinkButton ID="linkBttnAgregarParticipante" runat="server" Width="100px" OnClick="linkBttnAgregarParticipante_Click" CssClass="btn btn-info" ValidationGroup="AgregaPart" Font-Size="9px"><i class="fa fa-chevron-circle-down fa-2x" aria-hidden="true"></i>&nbsp;Agregar</asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="col text-center">
                                                    <asp:UpdateProgress ID="pgrAgregaPart" runat="server" AssociatedUpdatePanelID="updAgregaPart">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="imgAgregaPart" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                                ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                                <div class="row">
                                                    <div class="col text-center">
                                                        <asp:UpdateProgress ID="updPgrEventoDetalle" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgDatosDet" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col" style="overflow-x: scroll; overflow-y: hidden;">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdEventoDetalle" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid" OnSelectedIndexChanged="grdEventoDetalle_SelectedIndexChanged" OnRowDeleting="grdEventoDetalle_RowDeleting" OnRowDataBound="grdEventoDetalle_RowDataBound" OnRowUpdating="grdEventoDetalle_RowUpdating" OnRowEditing="grdEventoDetalle_RowEditing" OnRowCancelingEdit="grdEventoDetalle_RowCancelingEdit" EmptyDataText="No hay conceptos registrados." ShowHeaderWhenEmpty="True">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Id_Tipo_Participante" HeaderText="ID" ReadOnly="True">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Desc_Tipo_Participante" HeaderText="TIPO PARTICIPANTE" ReadOnly="True">
                                                                            <ItemStyle BackColor="#FFFF66" Font-Bold="True" VerticalAlign="Top" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="PARTICIPANTE">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlPart" runat="server" Width="100%">
                                                                                </asp:DropDownList>
                                                                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Participante") %>'></asp:Label>--%>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPart" runat="server" Text='<%# Bind("Participante") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="STATUS">
                                                                            <EditItemTemplate>
                                                                                <%--                                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STATUS") %>'></asp:TextBox>--%>
                                                                                <asp:DropDownList ID="ddlStatusPart" runat="server">
                                                                                    <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="¿ES PONENTE?">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEsPonente" runat="server" Text='<%# Bind("Es_Ponente") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CONSTANCIA">
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlTieneConstancia" runat="server">
                                                                                    <asp:ListItem Value="S">SI</asp:ListItem>
                                                                                    <asp:ListItem Value="N">NO</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Requiere_Constancia") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="EDITAR" ShowHeader="False">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                                                                &#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"><i class="fa fa-pencil fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BORRAR">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkBttnEliminarDet" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Se borraran también los CONCEPTOS ¿desea eliminar este registro?.');"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ShowHeader="False" HeaderText="AGREGAR">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkBttnAgregarConcep" runat="server" CausesValidation="False" CommandName="Select"><i aria-hidden="true" class="fa fa-plus-square fa-2x"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CONCEPTOS">
                                                                            <ItemTemplate>
                                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="grdEventoConceptos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" ShowHeaderWhenEmpty="True" Width="100%" EmptyDataText="No existen conceptos asignados." OnRowDeleting="grdEventoConceptos_RowDeleting" OnRowDataBound="grdEventoConceptos_RowDataBound" OnRowUpdating="grdEventoConceptos_RowUpdating" OnRowEditing="grdEventoConceptos_RowEditing" OnRowCancelingEdit="grdEventoConceptos_RowCancelingEdit" OnSelectedIndexChanged="grdEventoConceptos_SelectedIndexChanged">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                                                                                                <asp:BoundField DataField="Id_Tipo_Participante" HeaderText="IDP" ReadOnly="True" />
                                                                                                <asp:TemplateField HeaderText="CONCEPTO">
                                                                                                    <%--<EditItemTemplate>
                                                                                                        <asp:DropDownList ID="ddlCatConcep" runat="server"></asp:DropDownList>
                                                                                                    </EditItemTemplate>--%>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DescConcepto") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="STATUS">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:DropDownList ID="ddlStatusConc" runat="server">
                                                                                                            <asp:ListItem Value="A">Alta</asp:ListItem>
                                                                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                        <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("STATUS") %>'></asp:TextBox>--%>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="IMPORTE">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:TextBox ID="txtImporte" runat="server" Text='<%# Bind("IMPORTE") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("IMPORTE") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="DESCRIPCIÓN">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:TextBox ID="txtDesc" runat="server" Text='<%# Bind("DescCarrera") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DescCarrera") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="ID_CONCEPTO" HeaderText="ID CONC" />
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <ItemTemplate>
                                                                                                        <%--                                                                                                        <asp:LinkButton ID="linkBttnEliminarConc" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar"></asp:LinkButton>--%>
                                                                                                        <asp:LinkButton ID="linkBttnEliminarConc" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                                                                                        &#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"><i class="fa fa-pencil  fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
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
                                                                        <asp:BoundField DataField="Tipo_Participante" HeaderText="TP" ReadOnly="True">
                                                                            <ItemStyle VerticalAlign="Top" />
                                                                        </asp:BoundField>
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
                                        <HeaderTemplate>
                                            Oficios
                                        </HeaderTemplate>
                                        <ContentTemplate>
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
                                            <div class="row">
                                                <div class="col-md-11">
                                                    <div class="mb-3">
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <asp:FileUpload ID="FileOficio" runat="server" class="form-control" type="file" />
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
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnAgregarOficio" runat="server" CssClass="btn btn-info" Text="Agregar" ValidationGroup="AgregarOficio" OnClick="btnAgregarOficio_Click" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col text-center">
                                                    <asp:UpdateProgress ID="updPgrOficios" runat="server" AssociatedUpdatePanelID="updPnlOficios">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="imgOficios" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                                ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <asp:UpdatePanel ID="updPnlOficios" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdOficios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnPageIndexChanging="grdOficios_PageIndexChanging">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="NumOficio" HeaderText="# OFICIO" />
                                                                    <asp:BoundField DataField="FechaOficio" HeaderText="FECHA">
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="FirmaOficio" HeaderText="FIRMA" />
                                                                    <asp:TemplateField HeaderText="VER">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkArchivo") %>' Target="_blank"><i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i></asp:HyperLink>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="BORRAR">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="ctrl_eliminarOficio" runat="server" OnClientClick="return confirm('¿Eliminar registro?');" ToolTip="Eliminar" OnClick="ctrl_eliminarOficio_Click"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NombreArchivo" />
                                                                    <asp:BoundField DataField="Observaciones" />
                                                                </Columns>
                                                                <FooterStyle CssClass="enc" />
                                                                <HeaderStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                        <HeaderTemplate>
                                            Activación Clientes
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-md-1">
                                                        Matricula
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtMatricula" runat="server" Width="100%"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:LinkButton ID="linkBuscarMatricula" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBuscarMatricula_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txtNombre" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:LinkButton ID="linkAgregarMatricula" runat="server" Width="100%" CssClass="btn btn-info" Text="Agregar" OnClick="linkAgregarMatricula_Click"></asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdUsuarios" runat="server" AllowPaging="True"
                                                                    AutoGenerateColumns="False"
                                                                    EmptyDataText="No hay usuarios registrados" GridLines="None"
                                                                    OnPageIndexChanging="grdUsuarios_PageIndexChanging"
                                                                    OnSelectedIndexChanging="grdUsuarios_SelectedIndexChanging"
                                                                    ShowHeaderWhenEmpty="True" Width="100%" CssClass="mGrid" OnRowDeleting="grdUsuarios_RowDeleting">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula">
                                                                            <FooterStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Alumno">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"><i aria-hidden="true" class="fa fa-trash fa-2x"></i></asp:LinkButton>
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
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                                <div class="container-fluid">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrGuardarEv" runat="server" AssociatedUpdatePanelID="updPnlGuardarEv">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgGuardarEv" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div class="row">
                                        <div class="col text-left">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="guardar" HeaderText="Estos campos son requeridos:" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:UpdatePanel ID="updPnlGuardarEv" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="linkBttnCancelar" runat="server" CssClass="btn btn-grey" OnClick="linkBttnCancelar_Click"><i class="fa fa-chevron-left fa-2x" aria-hidden="true"></i> Salir</asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="linkBttnGuardar" runat="server" CssClass="btn btn-primary" OnClick="linkBttnGuardar_Click" ValidationGroup="guardar"><i class="fa fa-floppy-o fa-2x" aria-hidden="true"></i> Guardar</asp:LinkButton>
                                                    &nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <div class="card-deck">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <h5 class="card-title">Solicitó</h5>
                                                        <p class="card-text">
                                                            <asp:Label ID="lblUsuSolicitado" runat="server"></asp:Label>
                                                        </p>
                                                        <p class="card-text">
                                                            <small class="text-muted">
                                                                <asp:Label ID="lblFechaSolicitado" runat="server"></asp:Label>
                                                            </small>
                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="card">
                                                    <div class="card-body">
                                                        <h5 class="card-title">Autorizó</h5>
                                                        <p class="card-text">
                                                            <asp:Label ID="lblUsuAutorizado" runat="server"></asp:Label>
                                                        </p>
                                                        <p class="card-text">
                                                            <small class="text-muted">
                                                                <asp:Label ID="lblFechaAutorizado" runat="server"></asp:Label>
                                                            </small>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="row">
                                    <div class="col-md-1">Participantes</div>
                                    <div class="col-md-4">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCatTipPart" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCatTipPart_SelectedIndexChanged">
                                                    <asp:ListItem Value="S">Alumno/Cliente UNACH</asp:ListItem>
                                                    <asp:ListItem Value="SX">Alumno Externo</asp:ListItem>
                                                    <asp:ListItem Value="E">Empleado UNACH</asp:ListItem>
                                                    <asp:ListItem Value="X">Público General</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <%--<div class="col-md-3">
                                            <asp:UpdatePanel ID="updPnlBuscaPart" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="bttnBuscarPart" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="bttnBuscarPart_Click" Width="100%" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>--%>
                                </div>
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrBuscaPart" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgBuscaPart" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:UpdatePanel ID="updPnlCatPart" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grvCatParticipantes" runat="server" CssClass="sem table table-striped table-bordered table-hover" AutoGenerateColumns="False" Width="100%" OnRowCancelingEdit="grvCatParticipantes_RowCancelingEdit" OnRowEditing="grvCatParticipantes_RowEditing" OnRowUpdating="grvCatParticipantes_RowUpdating">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id_Tipo_Participante" HeaderText="ID" ReadOnly="True" />
                                                        <asp:TemplateField HeaderText="TIPO PARTICIPANTE">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtDesc_Tipo_Participante" runat="server" Text='<%# Bind("Desc_Tipo_Participante") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesc_Tipo_Participante" runat="server" Text='<%# Bind("Desc_Tipo_Participante") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Es_Ponente" HeaderText="¿ES PONENTE?" ReadOnly="True" />
                                                        <asp:CommandField EditText="Editar" ShowEditButton="True" ItemStyle-ForeColor="#990033">
                                                            <ItemStyle ForeColor="#990033" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnBorrarPart" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar este registro?.');" Text="Eliminar"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
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
                                <div class="row">
                                    <div class="col text-right">
                                        <asp:Button ID="bttnSalirPart" runat="server" Text="Salir" CssClass="btn btn-blue-grey" OnClick="bttnSalirPart_Click" />
                                    </div>
                                </div>
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
                    <h5 class="modal-title" id="exampleModalLabel">Conceptos
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
                                        <asp:RequiredFieldValidator ID="reqConc" runat="server" ControlToValidate="ddlConceptoFil" ValidationGroup="AgregaConceptos" InitialValue="0">*Requerido</asp:RequiredFieldValidator>
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
                            <div class="col-md-6">Importe</div>
                            <div class="col-md-6">Status</div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="txtImporte"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlStatusDet" runat="server" Width="100%">
                                    <asp:ListItem Value="A">Alta</asp:ListItem>
                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrGuardarConc" runat="server" AssociatedUpdatePanelID="updPnlGuardarConc">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgGuardarConc" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="updPnlGuardarConc" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="bttnAgregarConc" runat="server" Text="AGREGAR" class="btn btn-primary" OnClick="bttnAgregarConcepto_Click" />
                                    <asp:Button ID="bttnSalirConc" runat="server" Text="SALIR" class="btn btn-blue-grey" data-dismiss="modal" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalPart" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalParticipantes">Participantes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">Tipo de Participante</div>
                        </div>
                        <div class="row">
                            <div class="col">
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="DDLTipoParticipanteNew" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                Descripción del Tipo de Participante
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlDescTipoPart" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDesc_Tipo_Participante" runat="server" Width="100%"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDesc_Tipo_Participante" ErrorMessage="* Descripción" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                ¿Es ponente?
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkPonenteNew" runat="server" Text="Si" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col text-right">
                            <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="Button2" runat="server" Text="Salir" class="btn btn-blue-grey" data-dismiss="modal" />
                                    <asp:Button ID="btnAgregarParticipante" runat="server" CssClass="btn btn-info" OnClick="btnAgregarParticipante_Click" Text="Agregar" ValidationGroup="AgregaParticipante" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="modalOficios" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modOficios">Oficios</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLTipoParticipanteNew" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalCiclos" tabindex="-1" role="dialog" aria-labelledby="modalCiclos" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modCiclos">Ciclos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                Ciclo
                            </div>
                            <div class="col-md-4">
                                <%--<asp:DropDownList ID="ddlCiclo" runat="server" CssClass="form-control"></asp:DropDownList>--%>
                                <%--<asp:TextBox ID="txtCicloNuevo" runat="server" CssClass="form-control"></asp:TextBox>--%>
                            </div>
                        </div>
                        <%-- <div class="row">
                            <div class="col-md-2">
                                Descripción
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtDescCiclo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col text-right">
                                <asp:LinkButton ID="LinkButton4" runat="server" data-dismiss="modal" aria-label="Close" CssClass="btn btn-blue-grey">Cancelar</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-info">Guardar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
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

        function CatParticipantes() {

            $('#<%= grvCatParticipantes.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvCatParticipantes.ClientID %>').find("tr:first"))).DataTable({
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
