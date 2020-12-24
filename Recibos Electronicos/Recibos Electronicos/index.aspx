<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Recibos_Electronicos.index" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<%@ Register TagPrefix="customControl" Namespace="CapaNegocio" Assembly="CapaNegocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        
        .style2 {
            width: 95px;
        }

        .style3 {
            width: 145px;
        }

        .style5 {
            width: 126px;
        }

        .auto-style2 {
            width: 160px;
        }

        .auto-style3 {
            width: 171px;
        }

        .auto-style5 {
            width: 192px;
        }

        .auto-style6 {
            width: 117px;
        }
        .auto-style7 {
            width: 680px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="tabla_contenido">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>       
        <tr>
            <td align="left">
                <table style="width: 100%; height: auto;" __designer:mapid="23">
                    <tr __designer:mapid="2b0">
                        <td align="left" class="style3" __designer:mapid="2b1" valign="top">
                            <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:" Visible="False"></asp:Label>
                        </td>
                        <td __designer:mapid="2b2" valign="top">
                            <asp:UpdatePanel ID="updPnlDep" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlDependencia" runat="server" Visible="False" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="updPnlDep">
                                <ProgressTemplate>
                                    <asp:Image ID="imgDep" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlContenor" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Panel ID="pnlRangoFecha" runat="server" Height="100%">
                                            <table style="width: 100%; height: auto;">
                                                <tr>
                                                    <td align="left" class="style3" valign="top">
                                                        <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                    </td>
                                                    <td class="auto-style2" valign="top">
                                                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                                                    <td align="right" class="style2" valign="top">
                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:" Width="145px"></asp:Label>
                                                    </td>
                                                    <td class="auto-style3" valign="top">
                                                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                            <ContentTemplate>
                                                                &nbsp;
                                                                <asp:LinkButton ID="linkBttnCatReembolsables" runat="server" Font-Bold="True" ForeColor="#333333" OnClick="linkBttnCatReembolsables_Click" Visible="False">Catálogo de Conceptos Reembolsables</asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Panel ID="pnlEjercicio" runat="server" Visible="false" Height="100%">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="left" class="style3">
                                                        <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DDLEjercicio" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DDLMes" runat="server"
                                                            OnSelectedIndexChanged="DDLMes_SelectedIndexChanged">
                                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblMes_Fin" runat="server">Mes Final:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DDLMes_Fin" runat="server">
                                                            <asp:ListItem Value="01">Enero</asp:ListItem>
                                                            <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                            <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                            <asp:ListItem Value="04">Abril</asp:ListItem>
                                                            <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                            <asp:ListItem Value="06">Junio</asp:ListItem>
                                                            <asp:ListItem Value="07">Julio</asp:ListItem>
                                                            <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                            <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblReferencia" runat="server" Text="Busca:"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <table style="width:100%;">
                                            <tr>
                                                <td class="auto-style7">
                                                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" OnTextChanged="txtReferencia_TextChanged" PlaceHolder="Referencia, folio ó nombre" Visible="true" Width="95%"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-info" OnClick="btnConsultar_Click" Text="CONSULTAR" ValidationGroup="Buscar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3" valign="top">
                                        <asp:Label ID="lblNivel" runat="server" Text="Nivel:" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3" valign="top">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="auto-style5">
                                                    <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="DDLNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged" Visible="False">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="right" class="auto-style6">
                                                    <asp:Label ID="lblConceptos" runat="server" Text="Conceptos:" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                                        <ContentTemplate>
                                                            <customControl:GroupDropDownList ID="DDLConceptos" runat="server" Visible="False" Width="100%">
                                                            </customControl:GroupDropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <%--<asp:DropDownList ID="DDLConceptos" runat="server" Width="100%" Visible="False">
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:"></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <asp:DropDownList ID="ddlCiclo" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCiclo_SelectedIndexChanged" Width="350px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblTipo" runat="server" Text="Tipo Descuento:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" TabIndex="10"
                                            Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblStatus0" runat="server" Text="Estatus:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdoListStatus" runat="server"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                            <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4">
                                        <asp:Panel ID="pnlEvento" runat="server" Visible="False">
                                            <table style="width: 100%;">
                                                <tr valign="top">
                                                    <td align="left" class="style3">
                                                        <asp:Label ID="Evento" runat="server" Text="Evento:"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:UpdatePanel ID="updPnlEventos" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No existen eventos para esta dependencia." OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" Width="100%" AllowPaging="True" OnPageIndexChanging="grdEventos_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Eventos" HeaderText="CVE." />
                                                                        <asp:BoundField DataField="Dependencia" HeaderText="Dep.">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Fecha_inicial" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Inicial">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Fecha_final" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Generar Referencia">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgBttnEvento" runat="server" ImageUrl="~/Imagenes/referencia.PNG" OnClick="imgBttnEvento_Click" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Ruta" />
                                                                    </Columns>
                                                                    <FooterStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:UpdateProgress ID="updPrgEventos" runat="server" AssociatedUpdatePanelID="updPnlEventos">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgEventos" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                                    ToolTip="Espere un momento, por favor.." />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>

                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div class="cuadro_botones">
                                            <asp:HiddenField ID="hddnRepRetenciones" runat="server" />
                                            <ajaxToolkit:ModalPopupExtender ID="modalRepRetenciones" runat="server" TargetControlID="hddnRepRetenciones" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlRepRetenciones">
                                            </ajaxToolkit:ModalPopupExtender>
                                            &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                            &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                            &nbsp;<asp:ImageButton ID="imgBttnEstadisticas" runat="server" ImageUrl="~/Imagenes/estadisticas.png" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>       
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image23" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="centro">
            <div class="mensaje_naranja">                        
                        <asp:HiddenField ID="hddnImagenQR" runat="server" />                        
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
                <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDatosFactura" runat="server" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged"
                            EmptyDataText="El banco no reporto pagos, para el rango de fecha especificado..."
                            DataKeyNames="ID_FACT"
                            AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" CssClass="mGrid" Width="100%" PageSize="20" ShowHeaderWhenEmpty="True">
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                                    SortExpression="FECHA_FACTURA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" HeaderText="Importe" SortExpression="Importe">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep." SortExpression="DEPENDENCIA"></asp:BoundField>
                                <asp:TemplateField HeaderText="Enviar Recibo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Ver" ShowSelectButton="True"
                                    HeaderText="Ver Recibo" ButtonType="Image" SelectImageUrl="~/Imagenes/recibo2.png">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" OnClick="btnEditar_Click" Text="Editar" ForeColor="Black" ID="btnEditar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'></asp:LinkButton>
                                        <%--<asp:ImageButton AlternateText="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'
                                            ImageUrl="~/Imagenes/files_edit.png" ID="btnEditar" runat="server"></asp:ImageButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FACT_MATRICULA" />
                                <asp:BoundField DataField="ID_CODIGO_QR" />
                            </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <usr:uCCorreo ID="PnlCorreo" runat="server" />

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanelGrid">
                    <ProgressTemplate>
                        <asp:Image ID="Image3" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnRegresar_Click"
                            Text="REGRESAR" Visible="False" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlEditar" Visible="false" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtnombre" runat="server" Width="450px" CssClass="box"
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblNombre1" runat="server" Text="Carrera:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCarrera" runat="server" Width="450px" CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblNombre0" runat="server" Text="Matrícula/Aspirante:"
                                            Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMatricula" runat="server" Width="150px" CssClass="box"
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblNombre2" runat="server" Text="Referencia:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReferenciaSel" runat="server" Enabled="False" Width="450px"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblFecha" runat="server" Text="Fecha:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFecha" runat="server" Enabled="false" Width="150px"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblImporte" runat="server" Text="Importe:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtImporte" runat="server" Width="150px" Enabled="False"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblImporte0" runat="server" Text="Folio del Recibo:"
                                            Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFolioRec" runat="server" Enabled="False" Width="150px"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblImporte1" runat="server" Text="Folio Bancario:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFolioBancario" runat="server" Enabled="False" Width="450px"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3">
                                        <asp:Label ID="lblImporte2" runat="server" Text="Banco:" Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtBanco" runat="server" Enabled="False" Width="150px"
                                            CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="style3" valign="top">
                                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"
                                            Width="145px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtObservaciones" runat="server" Height="50px"
                                            TextMode="MultiLine" Width="450px" CssClass="box"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblMsjEditar" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn" Text="GUARDAR"
                                            OnClick="btnGuardar_Click" />
                                        &nbsp;
                                 <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" Text="CANCELAR"
                                     OnClick="btnCancelar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="Image5" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>                        
                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                            style="height: 500px" width="100%"></iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                                                    <asp:Panel ID="pnlRepRetenciones" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td>
                                                                    <div class="titulo_pop">
                                                                        REPORTES DE RETENCIONES</div>
                                                                    <center>
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td align="center">Tipo de Reporte:</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td align="center">
                                                                    &nbsp;<asp:UpdatePanel ID="UpdatePanel43" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlTipoRep" runat="server">
                                                                                <asp:ListItem Value="1">Por Folios</asp:ListItem>
                                                                                <asp:ListItem Value="2">Por Conceptos</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel227">
                                                                        <progresstemplate>
                                                                            <div class="overlay">
                                                                                <div class="overlayContent">
                                                                                    <asp:Image ID="Image13" runat="server" Height="19px" ImageUrl="~/Imagenes/loader.gif" Width="220px" />
                                                                                </div>
                                                                            </div>
                                                                        </progresstemplate>
                                                                    </asp:UpdateProgress>
                                                                    <asp:UpdatePanel ID="UpdatePanel227" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="CancelAlert" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="CANCELAR"/>
                                                                            &nbsp;<asp:Button ID="btnVerRep" runat="server" CssClass="btn" OnClick="btnVerRep_Click" Text="VER"/>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlBancos" runat="server"
                    Width="45%" CssClass="TituloModalPopupMsg">
                    <table width="100%">
                        <tr>
                            <td align="left" colspan="2">
                                <div class="titulo_pop">
                                    <label class="importante">Importante:</label>Si usted realizó su pago en ventanilla bancaria en las últimas 24 horas y en algunos de los siguientes bancos, es probable que aún no se encuentre su <a>Recibo Oficial</a>, si es así,favor de intentarlo más tarde.
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdStatus_Carga_Bancos" runat="server" AutoGenerateColumns="False" CssClass="mGrid mGrid15px" Width="50%">
                                            <Columns>
                                                <asp:BoundField DataField="Etiqueta" HeaderText="BANCO" />
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                            <HeaderStyle CssClass="enc" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                &nbsp;<br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="background-color: #f0f0f0">
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        &nbsp;&nbsp;<asp:Button ID="btnSalir" runat="server" CssClass="btn"
                                            Text="Aceptar" OnClick="btnSalir_Click" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
                </ajaxToolkit:ModalPopupExtender>

                <%--<asp:ImageButton AlternateText="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'
                                            ImageUrl="~/Imagenes/files_edit.png" ID="btnEditar" runat="server"></asp:ImageButton>--%>

                <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg" Width="500px">
                    <asp:ImageButton ID="imgCerrar" runat="server" CssClass="cerrar_pop" ImageUrl="https://sysweb.unach.mx/resources/imagenes/cerrar.png" Width="10px" />
                    <div class="titulo_pop">
                        AVISO
                    </div>
                    <center>
                <br />
         <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
                    </center>
                    <div class="info_pop gris_11px izquierda">
                        <asp:UpdatePanel ID="UpdatePanel40" runat="server">
                            <ContentTemplate>
                                <div style="overflow-y: scroll; height: 300px;">
                                    <asp:Label ID="lblMsg_Observaciones" runat="server" Text="Una mentalidad positiva te ayuda a triunfar. Piensa bien, para vivir mejor"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="esp_botones">
                        <asp:Button ID="btnCancelar0" runat="server" CssClass="btn btn-blue-grey" Text="Continuar" />
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
<script src="Scripts/jsQR.js"></script>
<script src="Scripts/QRModel.js"></script>
</asp:Content>
