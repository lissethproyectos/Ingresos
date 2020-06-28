<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmConceptos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmConceptos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--Datos para el calendario-->
    <link href='../Css/plain.css' media='screen' rel='Stylesheet' type='text/css' />
    <script src="../Js/Calendario/Validacion.js" type="text/javascript"></script>
    <script src="../Js/Calendario/prototype.js?1195078948" type="text/javascript"></script>
    <script src="../Js/Calendario/calendar_date_select.js?1196707120" type="text/javascript"></script>
    <script src="../Js/Calendario/format_spanish.js?1195078948" type="text/javascript">        function DIV1_onclick() { }
    </script>
    <!--Fin de datos para el calendario-->
    <style type="text/css">
        .style1
        {
            width: 467px;
        }
        .style4
        {
        }
        .style5
        {
        }
        .style10
        {
        }
        .style12
        {
            width: 140px;
        }
        .style15
        {
        }
        .style17
        {
        }
        .style18
        {
        }
        .style19
        {
            width: 184px;
        }
        .style20
        {
            width: 184px;
        }
        .style21
        {
        }
        .style22
        {
        }
        .style23
        {
        }
        .style25
        {
            width: 24px;
        }
        .auto-style1 {
            height: 22px;
        }
        .auto-style4 {
            margin-left: 40px;
        }
        .auto-style6 {
            width: 55%;
        }
        .auto-style7 {
            width: 332px;
        }
        .auto-style11 {
            width: 180px;
        }
        .auto-style12 {
            width: 37%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <table class="tabla_contenido" width="100%">
        <tr>
            <td align="center">
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="mltViewConceptos" runat="server">
                            <asp:View ID="Hoja1" runat="server">
                                <table style="width: 100%;" align="center">
                                    <tr>
                                        <td class="auto-style11">
                                            <asp:Label ID="lblNivel0" runat="server" Text="Nivel de Estudios:"></asp:Label>
                                        </td>
                                        <td class="auto-style7">
                                            <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" TabIndex="1" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFecha_Factura_Fin0" runat="server" Text="Ordenar por:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlOrden" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrden_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Clave</asp:ListItem>
                                                <asp:ListItem Value="2">Descripción</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style11">
                                            <asp:Label ID="lblTipo" runat="server" Text="Exclusivos para eventos:"></asp:Label>
                                        </td>
                                        <td class="auto-style7">
                                                    <asp:CheckBox ID="chkTipo" runat="server" AutoPostBack="True" OnCheckedChanged="chkTipo_CheckedChanged" Text="Si" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style11" valign="top">
                                            <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                        </td>
                                        <td class="auto-style7" valign="top">
                                            <asp:TextBox ID="txtBuscar" runat="server" Width="100%" PlaceHolder="Por Clave, Descripcion o Id"></asp:TextBox>
                                        </td>
                                        <td align="right" valign="top">&nbsp;</td>
                                        <td valign="top">
                                            <table class="auto-style12">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Label ID="lblStatus0" runat="server" Text="Estatus:" Visible="False"></asp:Label>
                                            <asp:CheckBox ID="CkbEstatus" runat="server" AutoPostBack="True" Checked="True" Enabled="False" OnCheckedChanged="CkbEstatus_CheckedChanged" TabIndex="2" Text="Mostrar los conceptos Activos" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <div style="overflow-y:scroll; height:300px;">
                                            <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False"                                                
                                                OnPageIndexChanging="grvConceptos_PageIndexChanging" 
                                                onselectedindexchanging="grvConceptos_SelectedIndexChanging" CssClass="mGrid" Width="100%">                                                
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
                                                    <asp:CommandField ShowSelectButton="True" SelectText="Editar" ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" HeaderText="Editar" >
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" /></asp:CommandField>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div class="cuadro_botones"><asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" onclick="imgBttnReporte_Click" />
&nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" onclick="imgBttnExportar_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style4" colspan="4">
                                            <asp:HiddenField ID="hddnModal" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modal" runat="server" PopupControlID="pnlClonarConcepto" TargetControlID="hddnModal" BackgroundCssClass="modalBackground_Proy">
                                            </ajaxToolkit:ModalPopupExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style4" colspan="4">
                                            <asp:Panel ID="pnlClonarConcepto" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="auto-style20" colspan="3">
                                                            <div class="titulo_pop">
                                                                <asp:Label ID="lblMsjCopia" runat="server" Text="Se copia el número de concepto "></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">&nbsp;</td>
                                                        <td width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style6" valign="top">
                                                            <asp:Label ID="lblTipo_C" runat="server" Text="¿Concepto exclusivo para evento?"></asp:Label>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkTipoC" runat="server" Text="Si" />
                                                        </td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style6" valign="top">&nbsp;</td>
                                                        <td width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:Button ID="btnGuardar_C" runat="server" Cssclass="btn btn-info" Height="45px" onclick="btnGuardar_C_Click" Text="CLONAR" />
                                                            &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" Height="45px" onclick="btnCancelar_C_Click" Text="CANCELAR" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">&nbsp;</td>
                                                        <td width="60%">&nbsp;</td>
                                                        <td width="20%">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style6">&nbsp;</td>
                                                        <td width="60%">&nbsp;</td>
                                                        <td width="20%">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="Hoja2" runat="server">
                                <table style="width: 100%;" align="center">
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="lblClave" runat="server" Text="Clave:"></asp:Label>
                                        </td>
                                        <td class="style5" colspan="7">
                                            <asp:TextBox ID="txtClave" runat="server" CssClass="box" MaxLength="200" 
                                                TabIndex="1"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="txtClave" CssClass="MsjError" ErrorMessage="*Requerido" 
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="lblConcepto" runat="server" Text="Concepto:"></asp:Label>
                                        </td>
                                        <td class="style5" colspan="7">
                                            <asp:TextBox ID="txtConcepto" runat="server" Style="margin-left: 0px" Width="450px"
                                                CssClass="box" MaxLength="500" TabIndex="2"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="txtConcepto" CssClass="MsjError" ErrorMessage="*Requerido" 
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtImporte" runat="server" CssClass="box" MaxLength="10" 
                                                TabIndex="3"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Requerido" 
                                                ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="style12">
                                            &nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                ControlToValidate="txtImporte" CssClass="MsjError" Display="Dynamic" 
                                                ErrorMessage="* Solo Números" ValidationExpression="\d+" 
                                                ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style21" colspan="8">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style15" align="left" colspan="8">
                                            <table style="width: 90%;">
                                                <tr>
                                                    <td align="left" class="style19">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                                    </td>
                                                    <td align="left" class="style17" colspan="2">
                                                        <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" 
                                                            TabIndex="4">
                                                            <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                                            <asp:ListItem Value="B">Baja</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style1" colspan="3">
                                                        <asp:CheckBox ID="chkEmitir_Via_Web" runat="server"
                                                            Text="Mostrar en Ficha Referenciadas" TabIndex="5" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="3">
                                                        <asp:CheckBox ID="chkAplica_Descuento" runat="server" Text="Mostrar en Modulo de Exenciones" 
                                                            TabIndex="9" />
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style19" colspan="2">
                                                        <asp:CheckBox ID="chkCobro_x_Materia" runat="server" TabIndex="6" Text="Cobro por Materia" />
                                                    </td>
                                                    <td align="right" class="style20">
                                                        <asp:Label ID="lblMaximo_Materias" runat="server" Text="Maximo Num. de Materias:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtMaximo_Materias" runat="server" CssClass="box" MaxLength="2" TabIndex="7" Text="0" Width="50px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMaximo_Materias" CssClass="MsjError" Display="Dynamic" ErrorMessage="* Solo Números" ValidationExpression="\d+" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style18" colspan="4">
                                                        <asp:CheckBox ID="chkPermite_Duplicidad" runat="server" 
                                                            Text="Duplicar el concepto (en caso de CONSTANCIAS DIVERSAS u otros)" 
                                                            TabIndex="8" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="style18" colspan="4">
                                                        <asp:CheckBox ID="chkSeleccionable" runat="server"
                                                            Text="Aplica para eventos" TabIndex="10" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style21" colspan="8">
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style19" colspan="2">
                                            <asp:Label ID="lblFecha_Inicial" runat="server" Text="Fecha Inicial de Cobro:"></asp:Label>
                                        </td>
                                        <td align="left" class="style10">
                                            <asp:TextBox ID="txtFecha_Inicial" runat="server" Width="100px" CssClass="box" 
                                                MaxLength="10" TabIndex="11"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Inicial" PopupButtonID="imgCalendarioIni" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                            
                                        </td>
                                        <td class="style12">
                                            <asp:Label ID="lblFecha_Final" runat="server" Text="Fecha Final de Cobro:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFecha_Final" runat="server" Width="100px" CssClass="box" 
                                                MaxLength="10" TabIndex="12"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" TargetControlID="txtFecha_Final" PopupButtonID="imgCalendarioFin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style4" colspan="5">
                                            <asp:Label ID="lblPorcentaje" runat="server" Text="Porcentaje para aplicar la Ley 80-20:"></asp:Label>
                                            <asp:TextBox ID="txtPorcentaje" runat="server" Width="50px" CssClass="box" 
                                                Rows="3" TabIndex="13"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                ControlToValidate="txtPorcentaje" CssClass="MsjError" Display="Dynamic" 
                                                ErrorMessage="*Sólo Números" MaximumValue="100" MinimumValue="0" Type="Integer" 
                                                ValidationGroup="guardar"></asp:RangeValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25" valign="top">
                                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Height="127px" 
                                                TextMode="MultiLine" Width="100%"
                                                CssClass="box" MaxLength="1000" TabIndex="14"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style23" align="center" colspan="8">
                                            <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-info" Height="45px" Text="GUARDAR" TabIndex="15" ValidationGroup="guardar" 
                                                onclick="btnGuardar_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnCancelar" runat="server"
                                                CssClass="btn btn-blue-grey" Height="45px" Text="CANCELAR" 
                                                TabIndex="16" onclick="btnCancelar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style25">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td class="style10">
                                            &nbsp;
                                        </td>
                                        <td class="style12">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        </table>
</asp:Content>
