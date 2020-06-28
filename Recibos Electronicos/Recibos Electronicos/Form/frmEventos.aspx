<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 289px;
        }
        .auto-style7 {
            width: 191px;
        }
        .auto-style10 {
            width: 149px;
        }
        .auto-style14 {
            width: 517px;
        }
        .auto-style15 {
            width: 200px;
        }
        .auto-style21 {
            width: 13px;
        }
        .auto-style24 {
            width: 14px;
        }
        .auto-style26 {
            width: 1874px;
        }
        .auto-style27 {
            width: 288px;
        }
        .auto-style29 {
            width: 585px;
        }
        .auto-style32 {
            width: 12%;
        }
        .auto-style34 {
            width: 462px;
        }
        .auto-style35 {
            width: 144px;
        }
        .auto-style36 {
            width: 458px;
        }
        .auto-style45 {
            width: 156px;
        }
        .auto-style50 {
            width: 174px;
        }
        .auto-style52 {
            width: 162px;
        }
        .auto-style53 {
            width: 99%;
        }
        .auto-style54 {
            width: 545px;
        }
        .auto-style55 {
            text-align: left;
            width: 77px;
        }
        .auto-style56 {
            width: 435px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
              

                                <table style="width: 100%;">
                                    <tr>
                                        <td class="auto-style10">
                                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                        </td>
                                        <td colspan="3">
                                                                       <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                                                           <ContentTemplate>
                                                                               <asp:DropDownList ID="DDLDependencia" runat="server" AutoPostBack="True" Width="100%">
                                                                               </asp:DropDownList>
                                                                           </ContentTemplate>
                                                                       </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="* Requerido" InitialValue="00000" ValidationGroup="Agregar">* Requerido</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">
                                            <asp:Label ID="lblStatus" runat="server" Text="Status: "></asp:Label>
                                        </td>
                                        <td class="auto-style6">
                                            <asp:DropDownList ID="ddlStatusB" runat="server">
                                                <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                <asp:ListItem Value="S">SOLICITADO</asp:ListItem>
                                                <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                                <asp:ListItem Value="B">BAJA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style7">
                                            <asp:Label ID="lblDirigido0" runat="server" Text="Tipo de Evento:"></asp:Label>
                                        </td>
                                        <td class="auto-style34">
                                            <asp:UpdatePanel ID="updPnlDirigido" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDirigido0" runat="server" AutoPostBack="True" Width="75%">
                                                        <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                        <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                        <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <table __designer:mapid="aa4" style="width:100%;">
                                                <tr __designer:mapid="aa5">
                                                    <td __designer:mapid="aa6" class="text-left">&nbsp;</td>
                                                    <td __designer:mapid="aa7" class="auto-style56">
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Para guardar el registro se requieren los siguientes campos:" ValidationGroup="guardar" />
                                                    </td>
                                                    <td __designer:mapid="aa8">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td valign="top" colspan="4">
                                            <asp:TextBox ID="txtBusqueda" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" title="Buscar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:GridView ID="grdEventos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" EmptyDataText="No hay eventos registrados." ShowHeaderWhenEmpty="True" OnPageIndexChanging="grdEventos_PageIndexChanging" OnRowEditing="grdEventos_RowEditing" OnRowCancelingEdit="grdEventos_RowCancelingEdit" OnRowUpdating="grdEventos_RowUpdating">
                                                <Columns>
                                                    <%-- <asp:CommandField HeaderText="Editar" SelectText="Editar" 
                                    ShowSelectButton="True" />
                                                            -asp:TemplateField>
                                                                <ItemTemplate>
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="dependencia" HeaderText="Depcia" ReadOnly="True" />
                                                    <asp:BoundField DataField="eventos" HeaderText="Evento" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="">
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
                                                    <asp:CommandField EditText="Editar Fechas" ShowEditButton="True" ItemStyle-ForeColor="#990033" >
                                                        <ItemStyle ForeColor="#990033" />
                                                    </asp:CommandField>
                                                    <asp:BoundField DataField="nivel" HeaderText="Nivel" ReadOnly="True" />
                                                    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Oficio(s)">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Text='<%# Bind("NoOficio") %>' Font-Size="XX-Small" Width="80px" OnClick="btnOficios_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnNuevo_Click" Text="NUEVO" ValidationGroup="Agregar" Width="70px" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit2.png" Visible='<%# Bind("EsVisible2") %>'/>
                                                            <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit.png" OnClick="imgBttnEditar_Click" Visible='<%# Bind("EsVisible") %>' />
                                                            &nbsp;<asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" OnClick="ctrl_eliminar_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NUEVA_VERSION" ReadOnly="True" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgBttnReporte" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" OnClick="imgBttnReporte_Click" Width="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style35">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style7">&nbsp;</td>
                                        <td class="auto-style36">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style35">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style7">&nbsp;</td>
                                        <td class="auto-style36">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%" CssClass="ajax__myTab">
                                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        (1) Datos Generales
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="lblCve" runat="server" Text="Clave:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:Label ID="lblCveDesc" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066CC"></asp:Label>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="Label4" runat="server" Text="¿El Evento se mostrará en? "></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:DropDownList ID="ddlDirigido" runat="server" AutoPostBack="True" Width="42%">
                                                                        <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                                                        <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                                                        <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="Label15" runat="server" Text="Nombre del Evento:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="95%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Nombre del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="Label16" runat="server" Text="E-mail Responsable:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:TextBox ID="txtEmail_res" runat="server" class="form-control" Width="40%"></asp:TextBox>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFecha_Evento_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" BehaviorID="_content_CalendarExtenderIni" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Evento_Ini" />
                                                                                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFecha_Evento_Ini" ErrorMessage="*Fecha Inicial del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFecha_Evento_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" BehaviorID="_content_CalendarExtenderFin" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Evento_Fin" />
                                                                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtFecha_Evento_Fin" ErrorMessage="*Fecha Final del Evento" ValidationGroup="guardar">*Requerido</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="Label2" runat="server" Text="Status:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server">
                                                                        <asp:ListItem Selected="True" Value="S">Solicitado</asp:ListItem>
                                                                        <asp:ListItem Value="A">Autorizado</asp:ListItem>
                                                                        <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style15">
                                                                    <asp:Label ID="Label17" runat="server" Text="Especificaciones:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style14">
                                                                    <asp:TextBox ID="txtEspecificacion" runat="server" Height="69px" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style15">&#160;</td>
                                                                <td class="auto-style14">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                    <HeaderTemplate>
                                                        (2) Configuración
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">


                                                            <tr>
                                                                <td colspan="4" valign="top" class="derecha">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="auto-style55">
                                                                                <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
                                                                            </td>
                                                                            <td class="text-left">
                                                                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="42%">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlNivel" InitialValue="Z" ValidationGroup="NewParticipante">*Requerido</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" valign="top" class="alert alert-info text-center" style="font-size: small; font-weight: bold">
                                                                    SEGMENTO PARTICIPANTE(S)</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="grvTiposParticipantes" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se ha agregado ningún tipo de participante" OnRowCancelingEdit="grvTiposParticipantes_RowCancelingEdit" OnRowEditing="grvTiposParticipantes_RowEditing" OnRowUpdating="grvTiposParticipantes_RowUpdating" OnSelectedIndexChanged="grvTiposParticipantes_SelectedIndexChanged" SelectedIndex="0" ShowHeaderWhenEmpty="True" Style="width: 100%;">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <%--                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTotConceptos" runat="server" Text='<%# Bind("Conceptos") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                                                    <asp:BoundField DataField="Participante" HeaderText="TIPO DE PARTICIPANTE" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="Tipo_Participante" HeaderText="Tipo_Participante" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="Desc_Tipo_Participante" HeaderText="DESCRIPCIÓN PARA FICHA REFERENCIADA" />
                                                                                    <asp:TemplateField HeaderText="ES PONENTE?">
                                                                                        <EditItemTemplate>
                                                                                            <asp:DropDownList ID="ddlEsPonente" runat="server" SelectedValue='<%# Bind("Es_Ponente") %>'>
                                                                                                <asp:ListItem Value="N">NO</asp:ListItem>
                                                                                                <asp:ListItem Value="S">SI</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                            <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Es_Ponente") %>'></asp:TextBox>--%>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Es_Ponente") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="REQUIERE CONSTANCIA">
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
                                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <asp:Button ID="bttnNuevoPart" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnNuevoPart_Click" Text="NUEVO" ValidationGroup="NewParticipante" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="linkVerTipoPart" runat="server" OnClick="linkVerTipoPart_Click" Visible="False">Seleccionar</asp:LinkButton>
                                                                                            &#160;<asp:LinkButton ID="linkEliminarTipoPart" runat="server" OnClick="linkEliminarTipoPart_Click" OnClientClick="return confirm('¿Eliminar registro?');">Eliminar</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField EditImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" ShowEditButton="True" />
                                                                                    <asp:BoundField DataField="Id" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <HeaderStyle CssClass="enc" Font-Size="Small" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50" valign="top">&#160;</td>
                                                                <td class="auto-style45" valign="top">&#160;</td>
                                                                <td class="auto-style54" valign="top">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>

                                                            <tr>
                                                                <td class="alert alert-info text-center" colspan="4" style="font-size: small; font-weight: bold" valign="top">SEGMENTO CONCEPTO(S)</td>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="grdCuotaLibre" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se ha agregado ningún concepto" Style="width: 100%;" ShowHeaderWhenEmpty="True" OnRowEditing="grdCuotaLibre_RowEditing" OnRowCancelingEdit="grdCuotaLibre_RowCancelingEdit" OnRowUpdating="grdCuotaLibre_RowUpdating">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Evento" HeaderText="EVENTO" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="Dependencia" HeaderText="DEPENDENCIA" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="CveConcepto" HeaderText="Concepto" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="DescConcepto" HeaderText="Desc Concep">
                                                                                    <ItemStyle Width="200px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Importe" HeaderText="IMPORTE" >
                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="STATUS">
                                                                                        <EditItemTemplate>
                                                                                            <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>--%>
                                                                                            <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("Status") %>' >
                                                                                            <asp:ListItem Value="B">BAJA</asp:ListItem>
                                                                                            <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField ShowEditButton="True" />
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <asp:Button ID="bttnNuevoConcepto" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnNuevoConcepto_Click" Text="NUEVO" ValidationGroup="NewParticipante" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="linkElminarConcepto" runat="server" OnClick="linkElminarConcepto_Click" OnClientClick="return confirm('¿Eliminar registro?');">Eliminar</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="IdConcepto" ReadOnly="True" />
                                                                                    <asp:BoundField DataField="Tipo_Participante" ReadOnly="True" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <HeaderStyle CssClass="enc" Font-Size="Small" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50">&#160;</td>
                                                                <td class="auto-style45">&#160;</td>
                                                                <td class="auto-style54">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50">&#160;</td>
                                                                <td class="auto-style45">&#160;</td>
                                                                <td class="auto-style54">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50">&#160;</td>
                                                                <td class="auto-style45">&#160;</td>
                                                                <td class="auto-style54">&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                                    <HeaderTemplate>
                                                        (3) Oficio(s)
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="4">&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td>No. de Oficio:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNoOficio" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNoOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>Fecha de Oficio:
                                                                    <asp:TextBox ID="txtFechaOficio" runat="server" AutoPostBack="True" Width="95px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="txtFechaOficio_CalendarExtender" runat="server" BehaviorID="_content_txtFechaOficio_CalendarExtender" PopupButtonID="imgCalendarOficio" TargetControlID="txtFechaOficio" />
                                                                    <asp:ImageButton ID="imgCalendarOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtNoOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Firmado por:</td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtFirma" runat="server" Width="98%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Observaciones:</td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtObservaciones_oficio" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <table style="width:100%;">
                                                                        <tr>
                                                                            <td class="auto-style26"><div class="mensaje_naranja">
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="auto-style29"><b><i class="fas fa-info-circle"></i>Solo formatos PDF, JPG Y PNG</b></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="auto-style29">
                                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:FileUpload ID="FileOficio" runat="server" />
                                                                                            <br />
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="FileOficio" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarOficio">* Requerido</asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileOficio" ErrorMessage="Archivo incorrecto, debe ser un PDF/JPG/PNG" ValidationExpression="(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                            <br />
                                                                                        </ContentTemplate>
                                                                                        <triggers>
                                                                                            <asp:PostBackTrigger ControlID="btnAgregarOficio" />
                                                                                        </triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnAgregarOficio" runat="server" CssClass="btn btn-blue-grey" OnClick="btnAgregarOficio_Click" Text="Agregar" ValidationGroup="AgregarOficio" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div></td>
                                                                            <td class="auto-style27">
                                                                                
                                                                            </td>
                                                                            <td>
                                                                                &#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td colspan="3">&#160; </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" align="center">
                                                                    <asp:GridView ID="grdOficios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="75%" OnPageIndexChanging="grdOficios_PageIndexChanging">
                                                                        <AlternatingRowStyle CssClass="alt" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="NumOficio" HeaderText="nooficio" />
                                                                            <asp:BoundField DataField="FechaOficio" HeaderText="fecha" >
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
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                                                    <HeaderTemplate>
                                                        4) Evento Exclusivo
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <div class="mensaje_naranja">
                                                                        <i class="fas fa-info-circle"></i>Utilice este apartado para convertir su evento en excluivo, es decir, solo las matrículas que usted elija podrán generar fichas referenciadas para su evento.</div>
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">
                                                                    <label style="font-weight: bold;">
                                                                    <i class="fas fa-question-circle"></i>¿Su evento es exclusivo?</label> </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbnExclusivo" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="S">Si </asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <label>
                                                                    <i class="fas fa-search"></i>Busque una matrícula y de clic en el botón agregar para añadirla a su evento exclusivo.</label>&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style32">Matrícula:</td>
                                                                <td>
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="auto-style24">
                                                                                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="imgBttnBuscaMatricula1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscaMatricula_Click" ValidationGroup="BuscaMatricula" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style32">Nombre:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="cuadros" Width="100%" Enabled="False"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnAgregarAlum" runat="server" CssClass="btn btn-info" OnClick="btnAgregarAlum_Click" Text="Agregar" />
                                                                </td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style32">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style32">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style32">
                                                                    &#160;</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBuscar" runat="server" Class="form-control" placeholder="Busqueda por Matricula/Nombre" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="imgBttnBuscaAutorizado" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscaAutorizado_Click" ValidationGroup="BuscaMatricula" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="centro" colspan="3">
                                                                    <asp:GridView ID="grdUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay usuarios registrados" GridLines="None" OnPageIndexChanging="grdUsuarios_PageIndexChanging" OnSelectedIndexChanging="grdUsuarios_SelectedIndexChanging" ShowHeaderWhenEmpty="True" Width="95%">
                                                                        <AlternatingRowStyle CssClass="alt" />
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
                                                                            <asp:BoundField DataField="TipoPersonaStr" HeaderText="Tipo">
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="StatusMatricula" HeaderText="Estatus">
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Cambiar Estatus">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl='<%# Bind("ImageStatusMatricula") %>' OnClick="ImageButton1_Click" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="UsuNombre" />
                                                                            <asp:BoundField DataField="Sede" />
                                                                            <asp:BoundField DataField="Nivel" />
                                                                        </Columns>
                                                                        <FooterStyle CssClass="enc" />
                                                                        <HeaderStyle CssClass="enc" />
                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle CssClass="sel" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="centro" colspan="3">
                                                                    <div class="centro">
                                                                        <br />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                            </ajaxToolkit:TabContainer>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
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
                                        <td class="text-center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-info" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:HiddenField ID="hddnTipoPart" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="modalTipoParticipante" runat="server" TargetControlID="hddnTipoPart" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlTipoParticipante">
                </ajaxToolkit:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:Panel ID="pnlTipoParticipante" runat="server" CssClass="TituloModalPopupMsg" Width="650px">
                    <table class="auto-style53">
                                                                                    <tr>
                                                                <td class="auto-style52">
                                                                    <asp:Label ID="lblTipoParticipante" runat="server" Text="Tipo de Participante:"></asp:Label>
                                                                                        </td>
                                                                <td>
                                                                    <asp:UpdatePanel ID="updPnlTipoPart" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="DDLTipoParticipante" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoParticipante_SelectedIndexChanged">
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
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="DDLTipoParticipante" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                                                                                        </td>
                                                            </tr>
                                                                                    <tr>
                                                                                        <td class="auto-style52">
                                                                                            <asp:Label ID="Label22" runat="server" Text="Descripción del Tipo de Participante:"></asp:Label>
                                                                                        </td>
                                                                                        <td colspan="2">
                                                                                            <asp:UpdatePanel ID="updPnlDescTipoPart" runat="server">
                                                                                                <ContentTemplate>
                                                                                                    <asp:TextBox ID="txtDesc_Tipo_Participante" runat="server" Width="100%" AutoPostBack="True"></asp:TextBox>
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                            <br />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDesc_Tipo_Participante" ErrorMessage="* Descripción" ValidationGroup="AgregaParticipante">* Requerido</asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                            <tr>
                                                                <td class="auto-style52">
                                                                    <asp:Label ID="lblPonente" runat="server" Text="¿Es ponente?"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkPonente" runat="server" Text="Si" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblConstancia" runat="server" Text="¿Requieren constancia?"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkConstancia" runat="server" Text="Si" />
                                                                </td>
                                                            </tr>
                                                                                    <tr>
                                                                                        <td valign="top" colspan="4"  class="text-center">                                                                                            
                                                                                            <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                                                                                                <ContentTemplate>
                                                                                                    <asp:Button ID="btnAgregarParticipante" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarParticipante_Click" Text="Agregar" ValidationGroup="AgregaParticipante" />
                                                                                                    &nbsp;<asp:Button ID="BttnSalirModalParticipante" runat="server" CssClass="btn btn-blue-grey" OnClick="BttnSalirModalParticipante_Click" Text="Salir" />
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="auto-style52" valign="top">&nbsp;</td>
                                                                                        <td valign="top">&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:HiddenField ID="hddnMParticipante" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="modalConceptos" runat="server" TargetControlID="hddnMParticipante" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlConceptos">
                </ajaxToolkit:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:Panel ID="pnlConceptos" runat="server" CssClass="TituloModalPopupMsg" Width="650px">
                    <table style="width: 100%;">
                                                            <tr>
                                                                <td class="auto-style50">
                                                                    <asp:Label ID="lblId_Concepto" runat="server" Text="Concepto:"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel ID="updPnlConceptos" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlConceptoFil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConceptoFil_SelectedIndexChanged" Width="100%">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlConceptoFil" InitialValue="00000" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50">
                                                                    <asp:Label ID="lblObservaciones" runat="server" Text="Descripión de Pago:"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel ID="updPnlObservacion" runat="server">
                                                                        <ContentTemplate>
                                                                    <asp:TextBox ID="txtObservacion" runat="server" OnTextChanged="txtObservaciones_TextChanged" Width="100%" AutoPostBack="True"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtObservacion" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50" valign="top">
                                                                    <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style45" valign="top">
                                                                     <asp:UpdatePanel ID="updPnlImporte" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                     </asp:UpdatePanel>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtImporte" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregaConceptos">* Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td class="auto-style54" valign="top">
                                                                    <asp:DropDownList ID="ddlTipo_Periodo" runat="server" Visible="False">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblTipo_Periodo" runat="server" Text="Pago" Visible="False"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style50" valign="top">
                                                                    <asp:Label ID="lblSatusConcep" runat="server" Text="Status:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style45" valign="top">
                                                                    <asp:CheckBox ID="chkActivo" runat="server" Checked="True" Text="Activo" />
                                                                </td>
                                                                <td class="auto-style54" valign="top">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center" valign="top" colspan="4">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="btnAgregarConcepto" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarConcepto_Click" Text="Agregar" ValidationGroup="AgregaConceptos" />
                                                                            &nbsp;<asp:Button ID="BttnSalirModalConceptos" runat="server" CssClass="btn btn-blue-grey" OnClick="BttnSalirModalConceptos_Click" Text="Salir" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text-center" colspan="4" valign="top">&nbsp;</td>
                                                            </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:HiddenField ID="hddnDoctosAdj" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="modalDoctosAdj" runat="server" TargetControlID="hddnDoctosAdj" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlDoctos">
                </ajaxToolkit:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:Panel ID="pnlDoctos" runat="server" CssClass="TituloModalPopupMsg" Width="450px">
                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td class="centro">
                                        <asp:Button ID="BttnSalirModal" runat="server" CssClass="btn btn-blue-grey" OnClick="BttnSalirModal_Click" Text="Salir" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
