<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmExentos_Copia.aspx.cs" Inherits="Recibos_Electronicos.Form.frmExentos_Copia" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>
<%@ Register src="../EnviarCorreo.ascx" tagname="uCCorreo" tagprefix="usr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .columna1 {
            width: 25%;
        }
        .auto-style1 {
            width: 160px;
        }
        .auto-style14 {
            width: 11%;
        }
        .auto-style20 {
            margin-left: 40px;
        }
        
        /*.overlay  
        {
          position: fixed;
          z-index: 98;
          top: 0px;
          left: 0px;
          right: 0px;
          bottom: 0px;
          background-color: #aaa; 
          filter: alpha(opacity=80); 
          opacity: 0.8; 
        }
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height: 80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
          width: 30px;
          height: 30px;
        }*/
        .auto-style23 {
            width: 71px;
        }
        .auto-style40 {
            width: 14%;
        }
        .auto-style41 {
            width: 57px;
        }
        .auto-style42 {
            width: 112px;
        }
        .auto-style46 {
            width: 157px;
        }
        .auto-style47 {
            width: 73px;
        }
        .auto-style49 {
            width: 27px;
        }
        .auto-style51 {
            background-color: #d9edf7;
            color: #31708f; /*background-color:#F8CBAD;
    color:#C55A11;*/;
            font-size: 12px;
            margin-left: 1px;
            padding: 8px 10px 8px 10px;
            box-sizing: border-box;
            -moz-box-sizing: border-box; /*Firefox*/;
            -webkit-box-sizing: border-box; /*Safari*/;
            border-radius: 3px 3px 3px 3px;
            -moz-border-radius: 3px 3px 3px 3px;
            -webkit-border-radius: 3px 3px 3px 3px;
            border: 1px solid #bce8f1;
        }
        .auto-style55 {
            width: 6%;
        }
        .auto-style56 {
            min-height: 350px;
            height: 702px;
            overflow: auto;
            width: 100%;
        }
        .columna2 {
            width: 12%;
        }
        .columna3 {
            width: 38%;
        }
        .auto-style63 {
            width: 106px;
            text-align: left;
        }
        .auto-style64 {
            width: 424px;
            text-align: left;
        }
        .auto-style65 {
            width: 424px;
        }
        .auto-style70 {
            width: 14px;
        }
        .auto-style71 {
            width: 328px;
        }
        .auto-style72 {
            width: 103px;
            text-align: left;
        }
        .auto-style74 {
            width: 437px;
        }
        .auto-style75 {
            width: 126px;
        }
        .auto-style76 {
            width: 109px;
        }
        .auto-style77 {
            width: 497px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
                <div align="center">
                    <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="updPnlMultiview">
            <progresstemplate>
                <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
            </progresstemplate>
        </asp:UpdateProgress>                                                
                </div>                                        
                <asp:UpdatePanel ID="updPnlMultiview" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">                                
                                        <table style="width:100%;">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="grvStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvStatus_PageIndexChanging" PageSize="5" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Dependencia" HeaderText="Revisar">
                                                            <HeaderStyle Font-Bold="True" Font-Size="14px" ForeColor="#ffffff" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TotalMatricula" HeaderText="Solicitados">
                                                            <HeaderStyle Font-Bold="True" Font-Size="14px" ForeColor="#ffffff" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style14">
                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:DropDownList ID="ddlDependencia" runat="server" ClientIDMode="Predictable" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="auto-style14">
                                                    <asp:Label ID="lblNivel1" runat="server" Text="Nivel:"></asp:Label>
                                                </td>
                                                <td class="columna1">
                                                    <asp:DropDownList ID="ddlNivel1" runat="server" ClientIDMode="Predictable" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td width="20%" align="right">
                                                                <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:"></asp:Label>
                                                            </td>
                                                            <td width="30%">
                                                                <asp:DropDownList ID="ddlCiclo" runat="server" Width="100%">
                                                                </asp:DropDownList>
                                                                </td>
                                                            <td width="20%" class="derecha">
                                                                <asp:Label ID="lblSubTipo1" runat="server" Text="Tipo:"></asp:Label>
                                                            </td>
                                                            <td width="30%">
                                                                <asp:DropDownList ID="ddlSubTipo1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged">
                                                                    <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                                    <asp:ListItem>RECARGO</asp:ListItem>
                                                                    <asp:ListItem>EXENTO</asp:ListItem>
                                                                    <asp:ListItem>DESCUENTO</asp:ListItem>
                                                                    <asp:ListItem Value="CUOTA_NORMAL">CUOTA NORMAL</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td class="auto-style14">
                                                    <asp:Label ID="lblStatus_Ini" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td class="columna1">
                                                    <asp:DropDownList ID="ddlStatus_Ini" runat="server" AutoPostBack="False" TabIndex="3" Width="100%">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <table width="100%">
                                                        <tr valign="top">
                                                            <td width="80%">
                                                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" PlaceHolder="Nombre ó Matricula" TabIndex="4" Visible="true" Width="95%"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
                                                            </td>
                                                            <td align="right">
                                                                <asp:ImageButton ID="imgBttnNuevo0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style14">
                                                    &nbsp;</td>
                                                <td class="columna1">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>                                           
                                            <tr>
                                                <td colspan="3">
                                                   
                                                            <asp:GridView ID="grvAlumnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se encontro ningún registro" GridLines="None" OnPageIndexChanging="grvAlumnos_PageIndexChanging" onrowdeleting="grvAlumnos_RowDeleting" OnSelectedIndexChanged="grvAlumnos_SelectedIndexChanged" PageSize="12" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="IdPersona" HeaderText="id" />
                                                                    <asp:BoundField DataField="GenerarPermiso" SortExpression="GenerarPermiso" />
                                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dep." />
                                                                    <asp:BoundField DataField="ConceptoDescuento" HeaderText="ConceptoDescuento" />
                                                                    <asp:BoundField DataField="Matricula" HeaderText="Matric">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Ciclo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDetalle" runat="server" ToolTip='<%# Bind("Observaciones") %>' Text='<%# Bind("CicloEscolar") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="TipoDescuento" HeaderText="Tipo Descuento" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="StatusMatricula" HeaderText="Status">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Referencia" HeaderText="Referencia">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="PorcentajeDescuento" HeaderText="Porcentaje" />
                                                                    <asp:ImageField DataImageUrlField="OficioTiene" DataImageUrlFormatString="~/Imagenes/Adjunto{0}.png">
                                                                    </asp:ImageField>
                                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/edit.png" SelectText="Editar" ShowSelectButton="True" />
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgBttnCancelar" runat="server" ImageUrl="~/Imagenes/del.PNG" OnClick="imgBttnCancelar_Click" style="width: 20px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Recibo en Cero">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="ckbGenerar" runat="server" AutoPostBack="true" Checked='<%# Bind("GenerarRecibo") %>' Enabled="true" OnCheckedChanged="ckbGenerar_CheckedChanged" Text="Generar" ValidationGroup='<%# DataBinder.Eval(Container.DataItem, "IdPersona") %>' />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:CheckBox ID="ckbGenerar0" runat="server" Checked='<%# Bind("GenerarRecibo") %>' />
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Enviar Recibo">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" Visible='<%# Bind("registro.Habil") %>' />
                                                                            <asp:Image ID="imgBttnCorreo2" runat="server" ImageUrl="~/Imagenes/correo2_enabled.png" Visible='<%# Bind("registro.Inhabil") %>' />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Nivel" />
                                                                    <asp:BoundField DataField="Carrera" HeaderText="Carrera" />
                                                                    <asp:TemplateField HeaderText="Ver Recibo">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="~/Imagenes/recibo.png" OnClick="imgBttnRecibo_Click" Visible='<%# Bind("registro.Habil") %>' />
                                                                            <asp:Image ID="imgBttnRecibo2" runat="server" ImageUrl="~/Imagenes/recibo2_enabled.png" Visible='<%# Bind("registro.Inhabil") %>' />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="registro.EtiquetaSiete" HeaderText="Asociado" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                                <HeaderStyle CssClass="enc10px" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                            </asp:GridView>                                                       
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="derecha">
                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                    <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:HiddenField ID="hddnCancelar" runat="server" />
                                                    <ajaxToolkit:ModalPopupExtender ID="modalCancelar" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlObs_Cancelacion" TargetControlID="hddnCancelar">
                                                    </ajaxToolkit:ModalPopupExtender>
                                                    <asp:HiddenField ID="hddnGenRecibo" runat="server" />
                                                    <ajaxToolkit:ModalPopupExtender ID="MPPAlert" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnl_Alert" TargetControlID="hddnGenRecibo">
                                                    </ajaxToolkit:ModalPopupExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Panel ID="pnl_Alert" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td>
                                                                    <div class="titulo_pop">
                                                                        AVISO
                                                                    </div>
                                                                    <center>
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td align="center">¿Esta seguro que desea generar el recibo en cero? </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td align="center">
                                                                    <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel227">
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
                                                                            <asp:Button ID="CancelAlert" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="NO" />
                                                                            &nbsp;<asp:Button ID="btnNueva" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnNueva_Click" Text="SI" />
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
                                                <td colspan="3">
                                                    <usr:uCCorreo ID="PnlCorreo" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Panel ID="pnlObs_Cancelacion" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td class="auto-style20" colspan="3">
                                                                    <div class="titulo_pop">
                                                                        Motivos de la Cancelación</div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;</td>
                                                                <td width="60%">&nbsp;</td>
                                                                <td width="20%">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" valign="top" width="20%">
                                                                    <asp:Label ID="lblObservaciones_C" runat="server" Text="Observaciones:"></asp:Label>
                                                                </td>
                                                                <td width="60%">
                                                                    <asp:TextBox ID="txtObservaciones_C" runat="server" Height="117px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                </td>
                                                                <td width="20%">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;</td>
                                                                <td align="center" width="60%">
                                                                    <asp:Button ID="btnGuardar_C" runat="server" Cssclass="btn btn-blue-grey" Height="45px" onclick="btnGuardar_C_Click" Text="GUARDAR" />
                                                                    &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" Height="45px" onclick="btnCancelar_C_Click" Text="CANCELAR" />
                                                                </td>
                                                                <td width="20%">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;</td>
                                                                <td width="60%">&nbsp;</td>
                                                                <td width="20%">
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="20%">&nbsp;</td>
                                                                <td width="60%">&nbsp;</td>
                                                                <td width="20%">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>                                   
                            </asp:View>
                            <asp:View ID="View2" runat="server">                                
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" CssClass="ajax__myTab" Width="100%" OnActiveTabChanged="TabContainer1_ActiveTabChanged1">
                                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                            <HeaderTemplate>
                                                                (1) Datos del Alumno
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td valign="top" colspan="2">
                                                                            <div class="mensaje_naranja">
                                                                                Para activar las siguientes pestañas debe proporcionar los datos del alumno.
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1" valign="top">
                                                                            <asp:Label ID="lblGrupo" runat="server" Text="Evento:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <asp:DropDownList ID="ddlEvento" runat="server" AutoPostBack="True" TabIndex="4" Width="85%">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1" valign="top">
                                                                            <asp:Label ID="lblMatricula" runat="server" Text="No. de Ficha / Matricula / Id Sysweb"></asp:Label>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td class="auto-style23" valign="top">
                                                                                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="box" MaxLength="8" TabIndex="4" Width="80px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMatricula" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:ImageButton ID="imgBttnBuscarMat" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscarMat_Click" />
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:Button ID="Registrar" runat="server" CssClass="btn3" OnClick="Registrar_Click" Text="Registrar Matrícula" Visible="False" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1" valign="top">
                                                                            <asp:Label ID="lblNivel0" runat="server" Text="Nivel:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:ListBox ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="250px"></asp:ListBox>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1" valign="top">
                                                                            <asp:Label ID="lblDependencia_D" runat="server" Text="Dependencia:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top">
                                                                                    <asp:DropDownList ID="ddlDependencia_D" runat="server" AutoPostBack="True" ClientIDMode="Predictable" Enabled="False" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" TabIndex="1" Width="85%">
                                                                                    </asp:DropDownList>                                                                               
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependencia_D" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblCarrera0" runat="server" Text="Carrera:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                                    <asp:DropDownList ID="ddlCarrera" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" TabIndex="6" Width="85%">
                                                                                    </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar:" Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                                    <asp:TextBox ID="txtCarrera" runat="server" CssClass="box" Visible="False" Width="85%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="box" Enabled="False" MaxLength="700" ReadOnly="True" TabIndex="5" Width="85%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblPaterno" runat="server" Text="Apellido Paterno:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPaterno" runat="server" Enabled="False" TabIndex="4" Width="85%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblMaterno" runat="server" Text="Apellido Materno:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMaterno" runat="server" Enabled="False" TabIndex="5" Width="85%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td class="auto-style3">
                                                                                        <asp:TextBox ID="txtFechaNacimiento" runat="server" Enabled="False"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaNacimiento" PopupButtonID="imgCalNac" BehaviorID="_content_CalendarExtender1" />
                                                        <asp:ImageButton ID="imgCalNac" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        

                                                                                    </td>
                                                                                    <td align="right" class="auto-style4">
                                                                                        <asp:Label ID="lblGenero" runat="server" Text="Sexo:"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                                <asp:RadioButtonList ID="rdoBttnLstGenero" runat="server" Enabled="False" RepeatDirection="Horizontal">
                                                                                                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                                                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="auto-style1">
                                                                            <asp:Label ID="lblSemestre" runat="server" Text="Semestre:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td class="auto-style3">
                                                                                        <asp:TextBox ID="txtSemestre" runat="server" CssClass="box" TabIndex="7" Width="50px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td align="right" class="auto-style4">
                                                                                        &#160;</td>
                                                                                    <td>
                                                                                                &#160;</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtGrupo" runat="server" CssClass="box" TabIndex="8" Width="50px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                            <HeaderTemplate>
                                                                (2) Datos de la Exención
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr valign="top">
                                                                        <td valign="top" class="auto-style14">
                                                                            <asp:Label ID="lblNivel_D" runat="server" Text="Ciclo Escolar:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" class="auto-style40">
                                                                                    <customControl:GroupDropDownList ID="ddlCiclo_D" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCiclo_D_SelectedIndexChanged" Width="300px"></customControl:GroupDropDownList>
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                                    &#160;</td>
                                                                        <td align="left" valign="top" class="auto-style47">
                                                                            <asp:Label ID="lblFechaInicial" runat="server" Text="Fecha Ini:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" colspan="2">
                                                                        <table width="100%"  >
                                                                            <tr>
                                                                                <td class="auto-style41">
                                                                                    <asp:TextBox ID="txtFechaInicial" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFechaInicial" PopupButtonID="imgCalendarioIni" BehaviorID="_content_CalendarExtenderIni" />
                                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif"/>
                                                                                </td>
                                                                                <td class="auto-style42" align="right">
                                                                                    <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Fin:"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style49">
                                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFinal" BehaviorID="_content_CalendarExtenderFin" />
                                                                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        </td>
                                                                        <td>
                                                                            &#160;</td>
                                                                    </tr>
                                                                    <tr valign="top">
                                                                        <td class="auto-style14" valign="top">
                                                                            <asp:Label ID="lblSubTipo" runat="server" Text="Tipo:"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style40" valign="top">
                                                                                    <asp:DropDownList ID="ddlSubTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged" Width="300px">
                                                                                        <asp:ListItem Value="X">--SELECCIONAR--</asp:ListItem>
                                                                                        <asp:ListItem>RECARGO</asp:ListItem>
                                                                                        <asp:ListItem>EXENTO</asp:ListItem>
                                                                                        <asp:ListItem>DESCUENTO</asp:ListItem>
                                                                                        <asp:ListItem Value="CUOTA_NORMAL">CUOTA NORMAL</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                        </td>
                                                                        <td align="right" valign="top">
                                                                            &#160;</td>
                                                                        <td align="left" valign="top" class="auto-style47">
                                                                            <asp:Label ID="lblTipo" runat="server" Text="SubTipo:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top">
                                                                                    <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" Width="300px" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                        </td>
                                                                        <td align="right">&#160;</td>
                                                                        <td>&#160;</td>
                                                                    </tr>
                                                                    <tr valign="top">
                                                                        <td valign="top" class="auto-style14">
                                                                            <asp:Label ID="lblStatus1" runat="server" Font-Bold="False" Text="Estatus:"></asp:Label>
                                                                        </td>
                                                                        <td valign="top" class="auto-style40">
                                                                            <asp:UpdatePanel ID="UpdatePanel231" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:DropDownList ID="ddlStatus" runat="server" TabIndex="11" Width="300px">
                                                                                    </asp:DropDownList>
                                                                                    <asp:Label ID="lblEstatusA" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td align="right" valign="top">&nbsp;</td>
                                                                        <td align="left" valign="top" colspan="2">
                                                                            <asp:UpdatePanel ID="UpdatePanel233" runat="server">
                                                                                <ContentTemplate>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td class="auto-style47" valign="top">
                                                                                                <asp:UpdatePanel ID="UpdatePanel234" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Label ID="lblPorcentaje" runat="server" Text="% Descuento:"></asp:Label>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                            <td class="auto-style13" valign="top">
                                                                                                <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="box" TabIndex="13" Width="50px">100</asp:TextBox>
                                                                                            </td>
                                                                                            <td class="auto-style13" valign="top">
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPorcentaje" CssClass="MsjError" ErrorMessage="*Requerido" SetFocusOnError="True" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator ID="RangeValidator3" runat="server" ControlToValidate="txtPorcentaje" SetFocusOnError="True" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$">*Formato (999.99)</asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td align="right">&#160;</td>
                                                                        <td>&#160;</td>
                                                                    </tr>
                                                                    <tr valign="top">
                                                                        <td class="auto-style14" valign="top">
                                                                                    <asp:Label ID="lblEmpleado" runat="server" Font-Bold="False" Text="Padre/Madre:"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style40" valign="top">
                                                                                    <asp:DropDownList ID="ddlEmpleado" runat="server" Width="300px">
                                                                                        <asp:ListItem Value="0">AGREGAR--&gt;</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left" valign="top" colspan="3">
                                                                                    <table style="width:100%;">
                                                                                        <tr>
                                                                                            <td class="auto-style70">
                                                                                                <ajaxToolkit:ModalPopupExtender ID="modalEmpleado" runat="server" TargetControlID="hddnEmp" PopupControlID="pnlEmpleado" BehaviorID="_content_modalEmpleado" DynamicServicePath="" BackgroundCssClass="modalBackground_Proy">
                                                                                                </ajaxToolkit:ModalPopupExtender>
                                                                                                <asp:ImageButton ID="imgBttnEmpleado" runat="server" ImageUrl="~/Imagenes/2.png" OnClick="imgBttnEmpleado_Click" ToolTip="Asociar" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:ImageButton ID="imgBttnBorrarEmpleado" runat="server" ImageUrl="~/Imagenes/1.png" OnClick="imgBttnBorrarEmpleado_Click" ToolTip="Eliminar Asociación" Visible="False" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:HiddenField ID="hddnEmp" runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                        </td>
                                                                        <td align="right">&#160;</td>
                                                                        <td>&#160;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="7" valign="top">
                                                                            <asp:UpdatePanel ID="updPnlConceptos" runat="server">
                                                                                <ContentTemplate>
                                                                                    <table style="width:100%;">
                                                                                        <tr>
                                                                                            <td align="center" colspan="2" valign="top">
                                                                                                        <asp:Label ID="lblMsjGuardar" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center" class="mensaje_celeste" style="width:50%;" valign="top">CONCEPTOS DISPONIBLES:</td>
                                                                                            <td align="center" class="mensaje_celeste" style="width:50%;" valign="top">CONCEPTOS AGREGADOS:</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="left" style="width:50%;" valign="top">
                                                                                                <div id="divGrid" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                                                    <asp:GridView ID="grvConceptosCat" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnSelectedIndexChanged="grvConceptosCat_SelectedIndexChanged" Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="ClaveDetalle" HeaderText="Cve.">
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:BoundField DataField="DescripcionDetalle" HeaderText="Descripción">
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Importe">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:TextBox ID="txtImporte" runat="server" Visible='<%# Bind("VisibleTxtImporte") %>' Enabled='<%# Bind("Habilita") %>' TabIndex="14" Text='<%# Bind("ImporteDetalle") %>' Width="80px"></asp:TextBox>
                                                                                                                <asp:Label ID="lblImporte" runat="server" Visible='<%# Bind("VisibleLblImporte") %>' Text="----"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:BoundField DataField="ImporteDetalle" />
                                                                                                        <asp:CommandField SelectText="Agregar" ShowSelectButton="True" />
                                                                                                    </Columns>
                                                                                                    <FooterStyle CssClass="enc" />
                                                                                                    <HeaderStyle CssClass="enc" />
                                                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                                    <SelectedRowStyle CssClass="sel" />
                                                                                                </asp:GridView>
                                                                                                </div>
                                                                                            </td>
                                                                                            <td align="right" style="width:50%;" valign="top">
                                                                                                <div id="divGrid2" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                                                    <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptos_PageIndexChanging" OnRowDeleting="grvConceptos_RowDeleting" Width="100%">
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="ClaveDetalle" HeaderText="Cve.">
                                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="DescripcionDetalle" HeaderText="Descripción">
                                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="ImporteDetalleInicio" HeaderText="Importe Original">
                                                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="ImporteDetalle" HeaderText="Importe">
                                                                                                            <HeaderStyle HorizontalAlign="Right" />
                                                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="TipoRegistro" />
                                                                                                            <asp:CommandField ShowDeleteButton="True" />
                                                                                                        </Columns>
                                                                                                        <FooterStyle CssClass="enc" />
                                                                                                        <HeaderStyle CssClass="enc" />
                                                                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                                        <SelectedRowStyle CssClass="sel" />
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <div align="center">
                                                                                <asp:UpdateProgress ID="updProgConceptos" runat="server" AssociatedUpdatePanelID="updPnlConceptos">
                                                                                    <progresstemplate>
                                                                                        <asp:Image ID="imgddlTipo0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                    </progresstemplate>
                                                                                </asp:UpdateProgress>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="7">&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                                            <HeaderTemplate>
                                                                (3) Oficios
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td class="columna2">
                                                                            <asp:Label ID="lblOficio" runat="server" Text="Número de Oficio:"></asp:Label>
                                                                        </td>
                                                                        <td class="columna3">
                                                                            <asp:TextBox ID="txtOficio" runat="server" CssClass="box" MaxLength="200" TabIndex="16"></asp:TextBox>
                                                                        </td>
                                                                        <td class="columna2">
                                                                            <asp:Label ID="lblFecha_Oficio0" runat="server" Text="Fecha del Oficio:"></asp:Label>
                                                                        </td>
                                                                        <td class="columna3">
                                                                            <asp:TextBox ID="txtFechaO" runat="server" CssClass="box" onkeyup="javascript:this.value='';" TabIndex="17" Width="80px"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="calendarioFechaOficio" runat="server" BehaviorID="_content_calendarioFechaOficio" PopupButtonID="imgCalendarioOficio" TargetControlID="txtFechaO" />
                                                                            <asp:ImageButton ID="imgCalendarioOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="columna2">
                                                                            <asp:Label ID="lblAutorizado" runat="server" Text="Autorizado Por:"></asp:Label>
                                                                        </td>
                                                                        <td class="columna3">
                                                                            <asp:TextBox ID="txtAutorizado" runat="server" CssClass="box" MaxLength="700" TabIndex="18" Width="80%"></asp:TextBox>
                                                                        </td>
                                                                        <td class="columna2">
                                                                            <asp:Label ID="lblSolicitado" runat="server" Text="Solicitado Por:"></asp:Label>&#160;</td>
                                                                        <td class="columna3">
                                                                            <asp:TextBox ID="txtSolicitado" runat="server" CssClass="box" MaxLength="700" TabIndex="18" Width="80%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <div class="mensaje_naranja">
                                                                                <asp:UpdatePanel ID="UpdatePanel229" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table style="width:100%;">
                                                                                            <tr>
                                                                                                <td align="left" style="border-width: 0px; " valign="top">
                                                                                                    <asp:Label ID="lblArchivos" runat="server" Font-Bold="True" Text="*Solo formatos PDF, JPG Y PNG"></asp:Label>
                                                                                                    <asp:FileUpload ID="FileOficio" runat="server" />
                                                                                                    <asp:HyperLink ID="LinkNombreArchivo" runat="server" Target="_blank">[LinkNombreArchivo]</asp:HyperLink>
                                                                                                </td>
                                                                                                <td style="border-style: 0; border-color: 0; border-width: 0px; width:50%" valign="top">
                                                                                                    <asp:Button ID="bttnAgregaOficio" runat="server" CssClass="btn3" Font-Size="Smaller" OnClick="bttnAgregaOficio_Click" Text="ADJUNTAR" Width="100px" />
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                    <triggers>
                                                                                        <asp:PostBackTrigger ControlID="bttnAgregaOficio" />
                                                                                    </triggers>
                                                                                </asp:UpdatePanel>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="columna2">&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                        <td>&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="4">
                                                                            <asp:GridView ID="grvOficios" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay oficios registrados" OnRowDeleting="grvOficios_RowDeleting" Width="55%">
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="NombreArchivo" HeaderText="Archivo">
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkArchivo") %>' Target="_blank">Ver</asp:HyperLink>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField ShowDeleteButton="True">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:CommandField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <HeaderStyle CssClass="enc" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="columna2">&nbsp;</td>
                                                                        <td class="columna3">&nbsp;</td>
                                                                        <td class="columna2">&nbsp;</td>
                                                                        <td class="columna3">&nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                    </ajaxToolkit:TabContainer>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <div class="cuadro_botones">
                                                        <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnGuardar_Click" TabIndex="20" Text="GUARDAR" ValidationGroup="guardar" />
                                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="CANCELAR" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width:100%;">
                                                        <tr valign="top">
                                                            <td class="auto-style46">
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel238" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="auto-style46">
                                                                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="box" Height="80px" MaxLength="1024" TabIndex="19" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="auto-style46" align="center">
                                                                &nbsp;</td>
                                                            <td>                                                                
                                                                <asp:Panel ID="pnlEmpleado" runat="server" CssClass="TituloModalPopupMsg" Height="420px" Width="694px">
                                                                    <div align="center">
                                                                    <asp:UpdateProgress ID="updProEmpleados" runat="server" AssociatedUpdatePanelID="updPnlEmpleados">
                                                                        <progresstemplate>
                                                                            <asp:Image ID="imgEmpleados" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </progresstemplate>
                                                                    </asp:UpdateProgress>
                                                                    </div>
                                                                    <asp:UpdatePanel ID="updPnlEmpleados" runat="server">
                                                                    <ContentTemplate>
                                                                        
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="mensaje_naranja" valign="top">
                                                                                        <asp:Label ID="lblAlumno" runat="server" Text=""></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:MultiView ID="mltViewFamiliares" runat="server" ActiveViewIndex="0">
                                                                                            <asp:View ID="View4" runat="server">
                                                                                                <table style="width:100%;">
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="3" valign="top">
                                                                                                            <fieldset>
                                                                                                                <legend>Seleccionar Empleado</legend>
                                                                                                                <table style="width: 100%;">
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style75">Buscar:</td>
                                                                                                                        <td class="auto-style74">
                                                                                                                            <asp:TextBox ID="txtNombreEmp" runat="server" Width="100%" PlaceHolder="Nombre Paterno Materno"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:ImageButton ID="imgBttnBuscarEmp" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscarEmp_Click" ValidationGroup="EmpleadoBusca" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="auto-style75">&nbsp;</td>
                                                                                                                        <td class="auto-style74">
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNombreEmp" ErrorMessage="*Requerido" ValidationGroup="EmpleadoBusca"></asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td colspan="3">
                                                                                                                            <asp:GridView ID="grvEmpleados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningun registro." OnPageIndexChanging="grvEmpleados_PageIndexChanging" OnSelectedIndexChanged="grvEmpleados_SelectedIndexChanged" PageSize="6" Width="100%">
                                                                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                                                                                <Columns>
                                                                                                                                    <asp:BoundField DataField="IdPersona" />
                                                                                                                                    <asp:BoundField DataField="TipoPersonaStr" HeaderText="TIPO PERSONAL">
                                                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Dependencia" HeaderText="DEP.">
                                                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="Nombre" HeaderText="NOMBRE COMPLETO">
                                                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:BoundField DataField="NoControl" HeaderText="PLAZA">
                                                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                                                    </asp:BoundField>
                                                                                                                                    <asp:CommandField SelectText="BUSCAR BENEFICIARIOS" ShowSelectButton="True" />
                                                                                                                                </Columns>
                                                                                                                                <FooterStyle CssClass="enc" />
                                                                                                                                <HeaderStyle CssClass="enc" />
                                                                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                                                            </asp:GridView>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </fieldset>

                                                                                                        </td>
                                                                                                    </tr>    
                                                                                                
                                                                                                    <tr>
                                                                                                        <td align="left" colspan="3" valign="top">
                                                                                                        <fieldset>
                                                                                                                <legend>Seleccionar Beneficiario</legend>
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td class="auto-style76"><asp:Label ID="lblHijo" runat="server" Text="Beneficiario(s):"></asp:Label></td>
                                                                                                                    <td class="auto-style77"><asp:UpdatePanel ID="UpdatePanel243" runat="server">
                                                                                                                <ContentTemplate>
                                                                                                                    <asp:DropDownList ID="ddlHijo" runat="server" Font-Size="12px" Width="100%">
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHijo" ErrorMessage="*Requerido" InitialValue="9999999" ValidationGroup="Empleado"></asp:RequiredFieldValidator>
                                                                                                                </ContentTemplate>
                                                                                                            </asp:UpdatePanel></td>
                                                                                                                    <td><asp:ImageButton ID="bttnNuevoHijo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="bttnNuevoHijo_Click" ValidationGroup="Nuevo Beneficiario" /></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td class="auto-style76">&nbsp;</td>
                                                                                                                    <td class="auto-style77"><asp:DropDownList ID="ddlParentesco" runat="server" Visible="False" Width="100%">
                                                                                                            </asp:DropDownList></td>
                                                                                                                    <td>&nbsp;</td>
                                                                                                                </tr>                                                                                                            
                                                                                                            </table>
                                                                                                        </fieldset>
                                                                                                            </td>
                                                                                                    </tr>
                                                                                                
                                                                                                    <tr>
                                                                                                        <td colspan="3" align="center">
                                                                                                            <asp:Button ID="bttnSalirEmp" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnSalirEmp_Click" Text="SALIR" />
                                                                                                            &nbsp;<asp:Button ID="bttnAgregarEmp" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnAgregarEmp_Click" Text="AGREGAR" ValidationGroup="Empleado" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="auto-style72">
                                                                                                            &nbsp;</td>
                                                                                                        <td class="auto-style71">&nbsp;</td>
                                                                                                        <td>&nbsp;</td>
                                                                                                    </tr>                                                                                                                                                                                           
                                                                                                </table>
                                                                                            </asp:View>
                                                                                            <asp:View ID="View5" runat="server">
                                                                                                <table style="width:100%;">
                                                                                                    <tr>
                                                                                                        <td class="auto-style51" colspan="4" align="center">
                                                                                                            <asp:Label ID="lblEtParentesco" runat="server" Text="Familiares"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="auto-style55">&nbsp;</td>
                                                                                                        <td class="auto-style63">
                                                                                                            <asp:Label ID="lblNombreFamiliar" runat="server" Text="Nombre:"></asp:Label>
                                                                                                        </td>
                                                                                                        <td class="auto-style64">
                                                                                                            <asp:TextBox ID="txtNombreFamiliar" runat="server" PlaceHolder="Nombre Ap. Paterno Ap. Materno" Width="90%"></asp:TextBox>
                                                                                                        </td>
                                                                                                        <td class="izquierda">&nbsp;</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="auto-style55">&nbsp;</td>
                                                                                                        <td class="auto-style63">
                                                                                                            <asp:Label ID="lblParentesco" runat="server" Text="Parentesco:"></asp:Label>
                                                                                                        </td>
                                                                                                        <td class="auto-style64">
                                                                                                            <asp:DropDownList ID="ddlParentescoFam" runat="server" Width="90%">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td class="izquierda">&nbsp;</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="4">
                                                                                                            <asp:Button ID="bttnSalirFam" runat="server" Cssclass="btn btn-blue-grey" Text="SALIR" OnClick="bttnSalirFam_Click" />
                                                                                                            &nbsp;<asp:Button ID="bttnAgregarFam" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnAgregarFam_Click" Text="GUARDAR" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="auto-style55">&nbsp;</td>
                                                                                                        <td class="auto-style63">&nbsp;</td>
                                                                                                        <td class="auto-style65">&nbsp;</td>
                                                                                                        <td class="izquierda">&nbsp;</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:View>
                                                                                        </asp:MultiView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>                                                                    
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="frm_linea">
                                                        <div class="frm_campo3_gd frm_campo3_md">
                                                            <div class="cuadro_naranja" style="min-height: 80px">
                                                                <h3>Solicitó</h3>
                                                                <br />
                                                                <asp:Label ID="lblUsuSolicitado" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblFechaSolicitado" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="frm_campo3_gd frm_campo3_md">
                                                            <div class="cuadro_celeste" style="min-height: 80px">
                                                                <h3>Autorizó</h3>
                                                                <br />
                                                                <asp:Label ID="lblUsuAutorizado" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblFechaAutorizado" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="frm_campo3_gd frm_campo3_md">
                                                            <div class="cuadro_morado" style="min-height: 80px">
                                                                <h3>Generó Recibo</h3>
                                                                <br />
                                                                <asp:Label ID="lblUsuGenerar" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblFechaGenerar" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style16"></td>
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
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>                                    
                            </asp:View>
                            <asp:View ID="View3" runat="server"><div align="center">
                                                <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3_">
                                                    <ProgressTemplate><asp:Image ID="Image855" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." /></ProgressTemplate>
                                                </asp:UpdateProgress>
                                </div>
                                                <asp:UpdatePanel ID="UpdatePanel3_" runat="server">
                                                    <ContentTemplate>
                                                        <div align="right">
                                                        <asp:Button ID="btnRegresar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnRegresar_Click" Text="Regresar" Visible="False"/>
                                                        </div>
                                                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor" style="height: 500px" width="100%"></iframe>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>           
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                                                                &nbsp;</td>
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
        <tr>
            <td>&nbsp;</td>
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
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                                                                                        <asp:GridView ID="grvHijos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No existen beneficiarios para el empleado." Width="100%">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="IdPersona" />
                                                                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento">
                                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                                </asp:BoundField>
                                                                                                <asp:CommandField ShowDeleteButton="True" />
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                        </asp:GridView>
                                                                                    </td>
        </tr>
    </table>
</asp:Content>
