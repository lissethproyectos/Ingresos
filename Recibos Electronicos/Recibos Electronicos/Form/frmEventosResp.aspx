<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventosResp.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventosResp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 289px;
        }
        .auto-style7 {
            width: 191px;
        }
        .auto-style8 {
            width: 305px;
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
        .auto-style17 {
            width: 133px;
        }
        .auto-style18 {
            width: 235px;
            text-align: right;
        }
        .auto-style19 {
            width: 146px;
        }
        .auto-style20 {
            width: 134px;
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
        .auto-style30 {
            width: 74%;
        }
        .auto-style32 {
            width: 12%;
        }
        .auto-style33 {
            font-family: Arial;
            font-size: 13px;
            padding: 7px 12px 7px 10px;
            border: 1px solid #D9D9D9;
            border-radius: 4px;
            text-decoration: none;
            background-color: #5FBA7D;
            color: #FFF;
            min-width: 100PX;
            transition: all 0.8s ease;
            margin-left: 393;
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
                                                                       <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%"></asp:DropDownList></td>
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
                                        <td class="auto-style8">
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
                                        <td class="auto-style10" valign="top">&nbsp;</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtBusqueda" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" title="Buscar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            <asp:GridView ID="grdEventos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="dependencia" HeaderText="Depcia" />
                                                    <asp:BoundField DataField="eventos" HeaderText="Evento" />
                                                    <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkGenRef" runat="server" OnClick="lnkGenRef_Click" ToolTip="Generar Referencia"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                    <asp:BoundField DataField="fecha_inicial" HeaderText="Fecha inicial" />
                                                    <asp:BoundField DataField="fecha_final" HeaderText="Fecha final" />
                                                    <asp:BoundField DataField="nivel" HeaderText="Nivel" />
                                                    <asp:BoundField DataField="status" HeaderText="Status" />
                                                    <asp:TemplateField HeaderText="Oficio(s)">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Text="5 Docto(s)" Font-Size="XX-Small" Width="80px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="https://sysweb.unach.mx/resources/imagenes/editar_grid.PNG" />
                                                    <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnNuevo_Click" Text="NUEVO" ValidationGroup="Agregar" Width="70px" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
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
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style7">&nbsp;</td>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style10">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style7">&nbsp;</td>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="100%" CssClass="ajax__myTab">
                                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        (1) Datos Generales
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <table style="width: 100%;">
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
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
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
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFecha_Evento_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" BehaviorID="_content_CalendarExtenderFin" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Evento_Fin" />
                                                                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
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
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblTipoParticipante" runat="server" Text="Tipo de Participante:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="DDLTipoParticipante" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoParticipante_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                        <asp:ListItem Value="S">Alumno UNACH</asp:ListItem>
                                                                        <asp:ListItem Value="X">Externo</asp:ListItem>
                                                                        <asp:ListItem Value="E">Empleado</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregaConceptos" ControlToValidate="DDLTipoParticipante">* Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="Label22" runat="server" Text="Descripción del Tipo de Participante:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDesc_Tipo_Participante" runat="server" Width="522px"></asp:TextBox>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr valign="top">
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblPonente" runat="server" Text="¿Es ponente?"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="auto-style19">
                                                                                <asp:CheckBox ID="chkPonente" runat="server" Text="Si" />
                                                                            </td>
                                                                            <td class="auto-style18">
                                                                                <asp:Label ID="lblConstancia" runat="server" Text="¿Requieren constancia?"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkConstancia" runat="server" Text="Si" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17" valign="top">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17" valign="top">
                                                                    <asp:Label ID="lblCRequeridos" runat="server" Text="Campos Requeridos:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBoxList ID="chkCRequeridos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkCRequeridos_SelectedIndexChanged">
                                                                        <asp:ListItem Value="PERIODO_PAGO">Periodo de Pago</asp:ListItem>
                                                                        <asp:ListItem Value="INSTITUCION">Institución</asp:ListItem>
                                                                        <asp:ListItem Value="PUESTO">Cargo o Puesto</asp:ListItem>
                                                                        <asp:ListItem Value="GRADO">Grado Máximo de Estudios</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                    <br />
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblTipo_Periodo" runat="server" Text="Periodo de Pago:" Visible="False"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTipo_Periodo" runat="server" Visible="False">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="Label23" runat="server" Text="Nivel:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="42%">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlNivel" InitialValue="Z" ValidationGroup="AgregaConceptos">*Requerido</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblId_Concepto" runat="server" Text="Concepto:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlConceptoFil" runat="server" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="ddlConceptoFil_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblObservaciones" runat="server" Text="Descripión de Pago:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtObservacion" runat="server" AutoPostBack="True" OnTextChanged="txtObservaciones_TextChanged" Width="80%"></asp:TextBox>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">
                                                                    <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                                                                </td>
                                                                <td>&#160;<table style="width: 100%;">
                                                                    <tr valign="top">
                                                                        <td class="auto-style20">
                                                                            <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtImporte" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregaConceptos">* Requerido</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn3" Height="34px" OnClick="btnAgregar_Click" Text="Agregar" ValidationGroup="AgregaConceptos" />
                                                                        </td>
                                                                    </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:GridView ID="grdCuotaLibre" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se ha agregado ningún concepto" OnSelectedIndexChanged="grdCuotaLibre_SelectedIndexChanged" Style="width: 100%;">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="EVENTO" HeaderText="EVENTO" />
                                                                                    <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPENDENCIA" />
                                                                                    <asp:BoundField DataField="Tipo_Participante" HeaderText="Tipo_Participante" />
                                                                                    <asp:BoundField DataField="Desc_Tipo_Participante" HeaderText="DESC_Tipo Participante" />
                                                                                    <asp:BoundField DataField="DescConcepto" HeaderText="Concepto" />
                                                                                    <asp:BoundField DataField="OBSERVACIONES" HeaderText="Desc Concep">
                                                                                    <ItemStyle Width="200px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE" >
                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                                                    <asp:BoundField DataField="Visible_Periodo_Pago" HeaderText="VER PERIODO DE PAGO" />
                                                                                    <asp:BoundField DataField="Visible_Institucion" HeaderText="VER INSTITUCIÓN" />
                                                                                    <asp:BoundField DataField="Visible_Puesto" HeaderText="VER PUESTO" />
                                                                                    <asp:BoundField DataField="Visible_Grado" HeaderText="VER GRADO" />
                                                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" ShowSelectButton="True" />
                                                                                    <asp:BoundField DataField="Concepto" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <HeaderStyle CssClass="enc" Font-Size="Small" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">&#160;</td>
                                                                <td>&#160;</td>
                                                                <td>&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style17">&#160;</td>
                                                                <td>&#160;</td>
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
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>No. de Oficio:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNoOficio" runat="server"></asp:TextBox>
                                                                </td>
                                                                <td>Fecha de Oficio:
                                                                    <asp:TextBox ID="txtFechaOficio" runat="server" AutoPostBack="True" Width="95px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarOficio" runat="server" BehaviorID="_content_CalendarOficio" PopupButtonID="imgCalendarOficio" TargetControlID="txtFechaOficio" />
                                                                    <asp:ImageButton ID="imgCalendarOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Firmado por:</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtFirma" runat="server" Width="98%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Observaciones:</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtObservaciones_oficio" runat="server" Width="100%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
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
                                                                <td colspan="3">&#160;</td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td colspan="2">&#160; </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center">
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
                                                                                <asp:ImageButton ID="imgBttnBuscaMatricula1" runat="server" ImageUrl="~/Imagenes/ico-usuario.png" OnClick="imgBttnBuscaMatricula_Click" ValidationGroup="BuscaMatricula" />
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
                                                                    <asp:Button ID="btnAgregarAlum" runat="server" CssClass="auto-style33" OnClick="btnAgregarAlum_Click" Text="Agregar" />
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
                                        <td align="right">
                                            <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
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
            <td class="auto-style21">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
