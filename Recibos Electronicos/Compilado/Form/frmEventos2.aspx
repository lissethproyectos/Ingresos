<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos2.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventos2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="tabla_contenido">
                <tr>
                    <td style="width: 120px;">Dependencia:</td>
                    <td>
                        <asp:DropDownList ID="ddlDependencia" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="ddlDependencia" InitialValue="00000"
                            ValidationGroup="guardar">* Elija una Dependencia</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--     modificar desde aqui--%>
                        <asp:MultiView ID="MultiViewEventos" runat="server">
                            <asp:View ID="View1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%; border-spacing: 0;">

                                            <tr>
                                                <td style="width: 120px;" valign="top">Status:
                                                </td>
                                                <td colspan="2" valign="top">
                                                    <asp:DropDownList ID="ddlStatusB" runat="server">
                                                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                        <asp:ListItem Value="S">SOLICITADO</asp:ListItem>
                                                        <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                                        <asp:ListItem Value="B">BAJA</asp:ListItem>

                                                    </asp:DropDownList>
                                                    <br />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 120px;" valign="top">
                                                    <asp:Label ID="lblDirigido0" runat="server" Text="Tipo de Evento:"></asp:Label>
                                                </td>
                                                <td colspan="2" valign="top">
                                                    <asp:DropDownList ID="ddlDirigido0" runat="server" AutoPostBack="True" Width="42%">
                                                        <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                        <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                        <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">Descripción:</td>
                                                <td valign="top">
                                                    <asp:TextBox ID="txtBusqueda" runat="server" Width="100%"></asp:TextBox></td>
                                                <td valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" title="Buscar" />
                                                            <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="btn_Nuevo_Click" title="Nuevo" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False"
                                                        CssClass="mGrid" AllowPaging="True"
                                                        OnPageIndexChanged="grdEventos_PageIndexChanged"
                                                        OnPageIndexChanging="grdEventos_PageIndexChanging" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="dependencia" HeaderText="Depcia" />
                                                            <asp:BoundField DataField="eventos" HeaderText="Evento" />

                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ToolTip="Generar Referencia" ID="lnkGenRef" OnClick="lnkGenRef_Click"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="fecha_inicial" HeaderText="Fecha inicial" />
                                                            <asp:BoundField DataField="fecha_final" HeaderText="Fecha final" />
                                                            <asp:BoundField DataField="nivel" HeaderText="Nivel" />
                                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                                            <asp:BoundField DataField="Oficio" HeaderText="Oficio" />

                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ToolTip="Ver Oficio" ID="lnkVerOfi" OnClick="lnkVerOfi_Click"> <%# DataBinder.Eval(Container.DataItem, "Oficio_s")%></asp:LinkButton>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ToolTip="Editar" ID="ctrl_editar" OnClick="ctrl_editar_Click"><img src="https://sysweb.unach.mx/resources/imagenes/edit.png" /> </asp:LinkButton>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="ctrl_eliminar" runat="server" OnClick="ctrl_eliminar_Click" ToolTip="Eliminar" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');"><img src="https://sysweb.unach.mx/resources/imagenes/del.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%-- <asp:CommandField HeaderText="Editar" SelectText="Editar" 
                                    ShowSelectButton="True" />
                                                            -asp:TemplateField>
                                                                <ItemTemplate>
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
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
                                                <td colspan="3">
                                                    <div class="cuadro_botones">
                                                        &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                        &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="cuadro_botones">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnListado" runat="server" CssClass="btn3" Height="45px" OnClick="btnListado_Click" Text="Regresar al Listado" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <cc1:TabContainer ID="TabContainerDatos" runat="server" ActiveTabIndex="2" CssClass="ajax__myTab" Width="100%">
                                                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>(1) Datos Generales
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <asp:Panel ID="Panel1" runat="server"><tr><td width="20%"><asp:Label ID="Label14" runat="server" Text="Cve. del Evento:"></asp:Label></td><td><asp:Label ID="lblEvento" runat="server" Font-Bold="True"></asp:Label></td></tr><tr><td colspan="3">&#160;</td></tr></asp:Panel>
                                                            <tr>
                                                                <td width="16%">¿El Evento se mostrará en? </td><td><asp:DropDownList ID="ddlDirigido" runat="server" AutoPostBack="True" Width="42%"><asp:ListItem Value="P">Eventos Especiales</asp:ListItem><asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem><asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                                </asp:DropDownList></td></tr><tr><td><asp:Label ID="Label15" runat="server" Text="Nombre del Evento:"></asp:Label></td><td><asp:TextBox ID="txtDescripcion" runat="server" Width="95%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label16" runat="server" Text="E-mail Responsable:"></asp:Label></td><td><asp:TextBox ID="txtEmail_res" runat="server" class="form-control" Width="40%"></asp:TextBox></td></tr><tr><td></td><td>
                                                            <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label><table><tr><td><asp:TextBox ID="txtFecha_Evento_Ini" runat="server" AutoPostBack="True" OnTextChanged="txtFecha_Evento_Ini_TextChanged" Width="95px"></asp:TextBox><asp:ImageButton ID="ImgCalendarFechaIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" /><cc1:CalendarExtender ID="CalendarFechaIni" runat="server" BehaviorID="_content_CalendarFechaIni" PopupButtonID="ImgCalendarFechaIni" TargetControlID="txtFecha_Evento_Ini" /></td><td></td><td><asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                                                <asp:TextBox ID="txtFecha_Evento_Fin" runat="server" AutoPostBack="True" OnTextChanged="txtFecha_Evento_Fin_TextChanged" Width="95px"></asp:TextBox><asp:ImageButton ID="ImgCalendarFechaFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" /><cc1:CalendarExtender ID="CalendarFechaFin" runat="server" BehaviorID="_content_CalendarFechaFin" PopupButtonID="ImgCalendarFechaFin" TargetControlID="txtFecha_Evento_Fin" /><asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtFecha_Evento_Fin" ErrorMessage="RequiredFieldValidator" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator></td></tr></table></td></tr><asp:Panel ID="Panel3" runat="server" Visible="False"><tr><td>
                                                                <asp:Label ID="Label21" runat="server" Text="Requiere Autorización:"></asp:Label></td><td><asp:RadioButtonList ID="rdoListAutorizacion" runat="server" OnSelectedIndexChanged="rdoListAutorizacion_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Value="S">Si</asp:ListItem><asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                            </asp:RadioButtonList></td></tr><tr><td><asp:Label ID="Label20" runat="server" Text="Matricula Inicial:"></asp:Label></td><td><asp:TextBox ID="txtmatricula" runat="server" Width="218px"></asp:TextBox></td></tr></asp:Panel><asp:Panel ID="Panel4" runat="server" Visible="False"><tr><td><asp:Label ID="lblTipo_Periodo0" runat="server" Text="Periodo de Pago:"></asp:Label></td><td>qweqeqewqew<asp:DropDownList ID="ddlTipo_Periodo" runat="server" Enabled="False">
                                                            </asp:DropDownList></td></tr></asp:Panel><tr><td><asp:Label ID="Label18" runat="server" Text="Nivel de Estudio:"></asp:Label></td><td><asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="42%">
                                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlNivel" InitialValue="Z" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label2" runat="server" Text="Status:"></asp:Label></td><td><asp:DropDownList ID="ddlStatus" runat="server"><asp:ListItem Selected="True" Value="S">Solicitado</asp:ListItem><asp:ListItem Value="A">Autorizado</asp:ListItem><asp:ListItem Value="B">Baja</asp:ListItem>
                                                                </asp:DropDownList></td></tr><tr><td valign="top">Especificaciones:</td><td><asp:TextBox ID="txtEspecificacion" runat="server" Height="69px" TextMode="MultiLine"></asp:TextBox></td></tr><tr><td align="right" colspan="2" width="100%"><asp:Button ID="btn_guardar" runat="server" Cssclass="btn btn-info" Height="45px" OnClick="btn_guardar_Click" Text="Guardar" ValidationGroup="guardar" />&#160;&#160; </td></tr></table>
                                                    </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1"><HeaderTemplate>(2) Oficio
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="3">&#160;</td></tr><tr><td>No. de Oficio:</td><td><asp:TextBox ID="txtNoOficio" runat="server"></asp:TextBox></td><td>Fecha de Oficio: <asp:TextBox ID="txtFechaOficio" runat="server" AutoPostBack="True" OnTextChanged="txtFecha_Evento_Ini_TextChanged" Width="95px"></asp:TextBox><asp:ImageButton ID="imgCalendarOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" /><cc1:CalendarExtender ID="CalendarOficio" runat="server" BehaviorID="_content_CalendarOficio" PopupButtonID="imgCalendarOficio" TargetControlID="txtFechaOficio" /></td></tr><tr><td colspan="3">&#160;</td></tr><tr><td></td>
                                                            <td colspan="2">Firmado por:
                                                            <asp:TextBox ID="txtFirma" runat="server" Width="98%"></asp:TextBox></td></tr><tr><td>Observaciones:</td><td colspan="2"><asp:TextBox ID="txtObservaciones_oficio" runat="server" Width="100%"></asp:TextBox></td></tr><tr><td colspan="3">&#160;</td></tr><tr><td colspan="3"><div class="mensaje_naranja"><table style="width: 100%;"><tr><td><b><i class="fas fa-info-circle"></i>Solo formatos PDF, JPG Y PNG</b></td></tr><tr><td><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
                                                            <asp:FileUpload ID="FileOficio" runat="server" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSiguiente2" />
                                                            </Triggers>
                                                            </asp:UpdatePanel></td><td><asp:Button ID="btnAdjuntar" runat="server" CssClass="btn3" Height="34px" OnClick="btnAdjuntar_Click" Text="Adjuntar" ValidationGroup="guardar" Visible="False" /></td></tr></table></div></td></tr><tr><td colspan="3">&#160;</td></tr><tr><td colspan="3"><div class="cuadro_botones"><asp:Button ID="btnSiguiente2" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnSiguiente2_Click" Text="Agregar" />&#160;<asp:Button ID="Button1" runat="server" CssClass="btn btn-blue-grey" OnClick="btn_cancelar_Click" Text="Regresar" /></div></td></tr><tr><td></td><td colspan="2">&#160; </td></tr><tr><td colspan="3">
                                                            <asp:GridView ID="grdOficios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%"><AlternatingRowStyle CssClass="alt" /><Columns><asp:BoundField DataField="Id" HeaderText="id" /><asp:BoundField DataField="NoOficio" HeaderText="nooficio" /><asp:BoundField DataField="FechaOficio" HeaderText="fecha" /><asp:BoundField DataField="Firma" HeaderText="Firma" /><asp:TemplateField><ItemTemplate><asp:LinkButton ID="lnkVerOfi" runat="server" OnClick="lnkVerOfi_Click" ToolTip="Ver Oficio"> <%# DataBinder.Eval(Container.DataItem, "Oficio")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                            </asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="ctrl_eliminarOficio" runat="server" OnClick="ctrl_eliminarOficio_Click" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" ToolTip="Eliminar"><img src="https://sysweb.unach.mx/resources/imagenes/del.png" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                            </asp:TemplateField><asp:BoundField DataField="Oficio" />
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            </asp:GridView></td></tr></table>
                                                    </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>(3) Importes
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="mensaje_naranja">
                                                                        <i class="fas fa-arrow-alt-circle-right"></i>A continuación deberá elegir un concepto e ingresar su descripción.<b> Recuerde que esta descripción es la que le aparece a los alumnos o clientes al elegir el concepto a pagar y es el que sale impreso en la ficha refenciada de pago.</b> </div><br /></td></tr><tr><td><asp:Label ID="lblId_Concepto" runat="server" Text="Concepto:"></asp:Label></td><td><asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><asp:Panel ID="panelConceptosFil" runat="server" Visible="true"><asp:DropDownList ID="ddlConceptoFil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConceptoFil_SelectedIndexChanged" Width="80%">
                                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddlConceptoFil" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="agregar"></asp:RequiredFieldValidator></asp:Panel><asp:Panel ID="panelConceptoTodos" runat="server" Visible="false"><asp:DropDownList ID="ddlConcepto0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConcepto0_SelectedIndexChanged" Width="80%">
                                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="ddlConcepto0" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="agregar" InitialValue="00000"></asp:RequiredFieldValidator></asp:Panel>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel></td></tr><tr><td><asp:Label ID="lblObservaciones" runat="server" Text="Descripión de Pago:"></asp:Label></td><td><label style="color: red; font-size: 15px;"><i class="fas fa-info-circle"></i>IMPORTANTE: La descripción no debe contener símbolos raros ni acentos.</label> <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:TextBox ID="txtObservacion" runat="server" AutoPostBack="True" OnTextChanged="txtObservaciones_TextChanged" Width="80%"></asp:TextBox>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel></td></tr><tr><td><asp:Label ID="lblTipo_Persona" runat="server" Text="Tipo de Participante:"></asp:Label></td><td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:DropDownList ID="ddlTipo_Persona" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllTipo_Persona_SelectedIndexChanged" Style="width: 50%">
                                                                </asp:DropDownList>
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel></td></tr><tr><td class="auto-style1" valign="top"><asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label></td><td class="auto-style1"><table><tr><td><asp:TextBox ID="txtImporte" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Solo Números" ValidationExpression="^(-?\d{0,13}\.\d{0,2}|\d{0,13})$" ValidationGroup="agregar"></asp:RegularExpressionValidator></td><td><asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate>
                                                                <asp:Button ID="btnAgregar" runat="server" CssClass="btn3" Height="34px" OnClick="btnAgregar_Click" Text="Agregar" ValidationGroup="agregar" />
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel></td></tr></table></td></tr><tr><td colspan="2">&#160; <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel20"><progresstemplate><asp:Image ID="Image4" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." /></progresstemplate>
                                                                </asp:UpdateProgress></td></tr><tr><td colspan="2"><asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:GridView ID="grdCuotaLibre" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se ha agregado ningún concepto" OnRowDeleting="grdCuotaLibre_RowDeleting" Style="width: 100%;"><Columns><asp:BoundField DataField="EVENTO" HeaderText="EVENTO" /><asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" /><asp:BoundField DataField="CARRERA" HeaderText="CARRERA" /><asp:BoundField DataField="DescCarrera" HeaderText="Tipo Participante" /><asp:BoundField DataField="ID_CONCEPTO" HeaderText="IDENTIFICADOR" />
                                                                <asp:BoundField DataField="DescConcepto" HeaderText="Concepto" />
                                                                <asp:BoundField DataField="OBSERVACIONES" HeaderText="Desc Concep" ItemStyle-Width="200px"><ItemStyle /></asp:BoundField><asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE" /><asp:BoundField DataField="STATUS" HeaderText="STATUS" /><asp:TemplateField HeaderText="Acciones"><ItemTemplate><asp:LinkButton ID="lnkEliminarConc" runat="server" OnClick="lnkEliminarConc_Click" ToolTip="Eliminar"><img src="https://sysweb.unach.mx/resources/imagenes/del.png" />
                                                                                        </asp:LinkButton>
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
                                                                </asp:UpdatePanel></td></tr><tr><td colspan="2"><div class="cuadro_botones"><asp:Button ID="Button3" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btn_cancelar_Click" Text="Regresar" /></div></td></tr></tr></table>
                                                    </ContentTemplate>
                                                    </cc1:TabPanel>
                                                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3"><HeaderTemplate>(4) Evento Exclusivo
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div class="mensaje_naranja">
                                                                        <i class="fas fa-info-circle"></i>Utilice este apartado para convertir su evento en excluivo, es decir, solo las matrículas que usted elija podrán generar fichas referenciadas para su evento.</div><br /><br /></td></tr><tr><td style="width: 30%"><label style="font-weight: bold;"><i class="fas fa-question-circle"></i>¿Su evento es exclusivo?</label> </td><td><asp:RadioButtonList ID="rbnExclusivo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbnExclusivo_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Value="S">Si </asp:ListItem><asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                </asp:RadioButtonList></td><td></td></tr><tr><td colspan="3"><br /><table style="width: 100%"><tr><td colspan="3"><label><i class="fas fa-search"></i>Busque una matrícula y de clic en el botón agregar para añadirla a su evento exclusivo.</label> </td></tr><tr><td>Matrícula:</td><td colspan="2"><asp:TextBox ID="txtMatriculaEx" runat="server"></asp:TextBox><asp:ImageButton ID="imgBttnBuscaMatricula" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscaMatricula_Click" ValidationGroup="BuscaMatricula" /></td></tr><tr><td></td>
                                                            <td width="30%">Nombre:
                                                            <asp:Label ID="lblNombreAlumno" runat="server" Font-Size="12px" ForeColor="#0070c0" Text=""></asp:Label></td><td>&#160;&#160;&#160;&#160;&#160; <asp:Button ID="btnAgregarAlum" runat="server" CssClass="btn3" OnClick="btnAgregarAlum_Click" Text="Agregar" Visible="false" /></td></tr><asp:Panel ID="pnlMatAutorizadas" runat="server"><tr><td colspan="3"><br /><br /><asp:GridView ID="grdAutorizados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se ha agregado ninguna matrícula" OnPageIndexChanged="grdEventos_PageIndexChanged" OnPageIndexChanging="grdEventos_PageIndexChanging" Width="100%"><Columns><asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" /><asp:BoundField DataField="TipoPersonaStr" HeaderText="Tipo Persona" /><asp:BoundField DataField="StatusMatricula" HeaderText="Status" /><asp:TemplateField HeaderText="Cambiar Estatus"><ItemTemplate><asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl='<%# Bind("ImageStatusMatricula") %>' OnClick="ImageButton1_Click" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            </asp:GridView></td></tr></asp:Panel><tr><td align="right" colspan="3"><br /><br /><asp:Button ID="btnGuardar2" runat="server" Cssclass="btn btn-blue-grey" Height="45px" OnClick="btnGuardar2_Click" Text="Guardar" ValidationGroup="guardar" Width="84px" /></td></tr></table></td></tr></table>
                                                    </ContentTemplate>
                                                    </cc1:TabPanel>
                                                </cc1:TabContainer>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="izquierda">
                                                <div class="frm_linea">
                                                        <div class="frm_campo5_gd  frm_campo5_md">
                                                            <div class="cuadro_naranja" style="min-height: 80px">
                                                                <h3>Solicitó</h3>
                                                                <br />
                                                                <asp:Label ID="lblUsuSolicitado" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblFechaSolicitado" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="frm_campo5_gd frm_campo5_md">
                                                            <div class="cuadro_celeste" style="min-height: 80px">
                                                                <h3>Autorizó</h3>
                                                                <br />
                                                                <asp:Label ID="lblUsuAutorizado" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblFechaAutorizado" runat="server"></asp:Label>
                                                            </div>
                                                        </div>                                                        
                                                    </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>



                            </asp:View>
                        </asp:MultiView>

                    </td>
                </tr>

            </table>


            <%--    terminar de modificar aquí--%>
            </td>
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
