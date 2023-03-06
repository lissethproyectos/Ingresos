﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmExentos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmExentos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<%@ Register Src="../EnviarCorreo.ascx" TagName="uCCorreo" TagPrefix="usr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Scripts/select2/js/select2.min.js"></script>
    <link href="../Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <style type="text/css">
        .overlay {
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

        .overlayContent {
            z-index: 99;
            margin: 250px auto;
            width: 80px;
            height: 80px;
        }

            .overlayContent h2 {
                font-size: 18px;
                font-weight: bold;
                color: #000;
            }

            .overlayContent img {
                width: 30px;
                height: 30px;
            }

        .nav-tabs .nav-link {
            border: 1px solid #f8f9fa;
            border-top-left-radius: .25rem;
            border-top-right-radius: .25rem;
            font-size: 13px;
        }

        .nav-tabs li a {
            padding: 8px 40px;
            border: 1px solid #ededed;
            border-top: 2px solid #dfdfdf;
            border-right: 0px none;
            background: #65635d;
            color: #fff;
            border-radius: 0px;
            margin-right: 0px;
            /* border-color: #cdcdcd; */
            font-weight: bold;
            transition: all 0.3s ease-in 0s;
        }

        .btn-tipo {
            margin: 0.375rem;
            color: #fff;
            word-wrap: break-word;
            white-space: normal;
            cursor: pointer;
            border: 0;
            border-radius: 0.125rem;
            box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
            transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
            /* padding: 0.84rem 2.14rem; */
            font-size: 0.71rem;
            background-color: #007bff;
        }

            .btn-tipo option {
                background-color: #007bff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlMultiview" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col">
                                            <asp:UpdatePanel ID="updPnlStatusSol" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grvStatus" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="mGrid">
                                                        <Columns>
                                                            <asp:BoundField DataField="Dependencia" HeaderText="Revisar">
                                                                <HeaderStyle Font-Bold="True" Font-Size="14px" ForeColor="#333333" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TotalMatricula" HeaderText="Solicitados">
                                                                <HeaderStyle Font-Bold="True" Font-Size="14px" ForeColor="#333333" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle CssClass="enc" />
                                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                        <RowStyle Font-Size="14px" />
                                                        <SelectedRowStyle CssClass="sel" />
                                                        <HeaderStyle CssClass="enc" Font-Size="12px" HorizontalAlign="Center" ForeColor="#333333" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-1">
                                            <asp:Label ID="lblDependencia" runat="server" Text="Depcia"></asp:Label>
                                        </div>

                                        <div class="col-md-11">
                                            <asp:UpdatePanel ID="updPnlDepcia" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1">Alumno / Aspirante</div>
                                        <div class="col-md-2">
                                            <asp:UpdatePanel ID="updPnlddlTipoPers1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlTipoPers1" runat="server" CssClass="btn btn-tipo dropdown-toggle browser-default custom-select custom-select-lg mb-3">
                                                        <asp:ListItem Value="UNACH">UNACH</asp:ListItem>
                                                        <asp:ListItem Value="PSU">PSU</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label ID="lblNivel1" runat="server" Text="Nivel"></asp:Label>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:UpdatePanel ID="updPnlNivel" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlNivel1" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:UpdatePanel ID="updPnlCiclo" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCiclo" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1">
                                            <asp:Label ID="lblSubTipo1" runat="server" Text="Tipo"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:UpdatePanel ID="updPnlSubtipo1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSubTipo1" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged">
                                                        <asp:ListItem Value="T">TODOS</asp:ListItem>
                                                        <asp:ListItem>RECARGO</asp:ListItem>
                                                        <asp:ListItem>EXENTO</asp:ListItem>
                                                        <asp:ListItem>DESCUENTO</asp:ListItem>
                                                        <asp:ListItem Value="CUOTA_NORMAL">CUOTA NORMAL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label ID="lblStatus_Ini" runat="server" Text="Status"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:UpdatePanel ID="updPnlStatusIni" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlStatus_Ini" runat="server" AutoPostBack="False" TabIndex="3" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtReferencia" runat="server" PlaceHolder="Nombre ó Matricula" TabIndex="4" Visible="true" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-right">
                                            <asp:UpdatePanel ID="updPnlBuscarExenciones" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="linkBttnBuscarEx" runat="server" CssClass="btn btn-warning" OnClick="linkBttnBuscarEx_Click"><i class="fa fa-search" aria-hidden="true"></i>Ver Exenciones</asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="linkBttnNewEx" runat="server" CssClass="btn btn-blue-grey" OnClick="linkBttnNewEx_Click" ValidationGroup="Nuevo"><i class="fa fa-plus-square" aria-hidden="true"></i> Nuevo</asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:UpdateProgress ID="updPrgBuscarExenciones" runat="server" AssociatedUpdatePanelID="updPnlBuscarExenciones">
                                                <ProgressTemplate>
                                                    <asp:Image ID="img2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:UpdateProgress ID="updPgrAlumnos" runat="server" AssociatedUpdatePanelID="updPnlAlumnos">
                                                <ProgressTemplate>
                                                    <asp:Image ID="img1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div style="overflow-x: auto;">
                                                <asp:UpdatePanel ID="updPnlAlumnos" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grvAlumnos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnRowDeleting="grvAlumnos_RowDeleting" OnSelectedIndexChanged="grvAlumnos_SelectedIndexChanged" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="IdPersona" HeaderText="id" />
                                                                <asp:BoundField DataField="GenerarPermiso" SortExpression="GenerarPermiso" />
                                                                <asp:BoundField DataField="Dependencia" HeaderText="Depcia" />
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
                                                                        <asp:Label ID="lblDetalle" runat="server" Text='<%# Bind("CicloEscolar") %>' CssClass="font-weight-bold"></asp:Label>
                                                                        &nbsp;<asp:Label ID="lblPeriodo" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
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
                                                                <asp:TemplateField HeaderText="Recibo en Cero">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ckbGenerar" runat="server" AutoPostBack="true" Checked='<%# Bind("GenerarRecibo") %>' Enabled="true" OnCheckedChanged="ckbGenerar_CheckedChanged" Text="Generar" ValidationGroup='<%# DataBinder.Eval(Container.DataItem, "IdPersona") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="ckbGenerar0" runat="server" Checked='<%# Bind("GenerarRecibo") %>' />
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Adj">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("OficioTiene") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>

                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("OficioTiene", "~/Imagenes/Adjunto{0}.png") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkBttnEditar" runat="server" OnClick="linkBttnEditar_Click"><i aria-hidden="true" class="fa fa-pencil-square-o fa-2x"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Conf">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkBttnCancelar" runat="server" OnClick="linkBttnCancelar_Click"><i class="fa fa-cog fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Enviar">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkBttnCorreo" runat="server" Visible='<%# Bind("registro.Habil") %>' OnClick="linkBttnCorreo_Click"><i class="fa fa-envelope fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                        <%--<asp:LinkButton ID="linkBttnCorreo2" runat="server" Visible='<%# Bind("registro.Inhabil") %>'><i class="fa fa-envelope-o fa-2x" aria-hidden="true"></i></asp:LinkButton>--%>
                                                                        <%--                                                            <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" Visible='<%# Bind("registro.Habil") %>' />--%>
                                                                        <%--                                                            <asp:Image ID="imgBttnCorreo2" runat="server" ImageUrl="~/Imagenes/correo2_enabled.png" Visible='<%# Bind("registro.Inhabil") %>' />--%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Nivel" />
                                                                <asp:BoundField DataField="Carrera" HeaderText="Carrera" />
                                                                <asp:TemplateField HeaderText="Recibo">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkBttnRecibo" runat="server" OnClick="linkBttnRecibo_Click" Visible='<%# Bind("registro.Habil") %>'><i class="fa fa-file fa-2x" aria-hidden="true"></i></asp:LinkButton>

                                                                        <%--<asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="~/Imagenes/recibo.png" OnClick="imgBttnRecibo_Click" Visible='<%# Bind("registro.Habil") %>' />--%>
                                                                        <%--<asp:Image ID="imgBttnRecibo2" runat="server" ImageUrl="~/Imagenes/recibo2_enabled.png" Visible='<%# Bind("registro.Inhabil") %>' />--%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="registro.EtiquetaSiete" HeaderText="Asociado">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Reporte">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBttnReporteDesc" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" OnClick="imgBttnReporteDesc_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CicloAlu" />
                                                                <asp:BoundField DataField="TipoAlumno" />
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
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:UpdatePanel ID="updPnlReportes" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                    <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <asp:HiddenField ID="hddnCancelar" runat="server" />
                                <ajaxToolkit:ModalPopupExtender ID="modalCancelar" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlObs_Cancelacion" TargetControlID="hddnCancelar" CancelControlID="btnCancelar_C">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:HiddenField ID="hddnGenRecibo" runat="server" />
                                <asp:Panel ID="pnlObs_Cancelacion" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                    <table style="width: 100%; z-index: 200;" class="card text-white bg-dark mb-3">
                                        <tr>
                                            <td class="auto-style20" colspan="3">
                                                <div>
                                                    Motivos de la Cancelación
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%">&nbsp;</td>
                                            <td width="60%">&nbsp;</td>
                                            <td width="20%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="20%" class="text-left">Status:</td>
                                            <td width="60%">
                                                <asp:DropDownList ID="ddlStatusRegistro" runat="server">
                                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                    <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                                    <asp:ListItem Value="E">Eliminado</asp:ListItem>
                                                    <asp:ListItem Value="A">Activado</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlStatusRegistro" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="CambiaStatus">*Requerido</asp:RequiredFieldValidator>
                                            </td>
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
                                                <asp:UpdatePanel ID="updPnlGuardarStus" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnGuardar_C" runat="server" CssClass="btn btn-info" Height="45px" OnClick="btnGuardar_C_Click" Text="GUARDAR" ValidationGroup="CambiaStatus" />
                                                        &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btnCancelar_C_Click" Text="CANCELAR" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td width="20%">&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <usr:uCCorreo ID="PnlCorreo" runat="server" />

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col">
                                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="100%" OnActiveTabChanged="TabContainer1_ActiveTabChanged1" ScrollBars="Both">
                                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                    <HeaderTemplate>
                                                        <i class="fa fa fa-user fa-2x" aria-hidden="true"></i>&nbsp;Datos del Alumno
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    Evento
                                                                </div>
                                                                <div class="col-md-10">
                                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlEvento" runat="server" AutoPostBack="True" TabIndex="4" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <hr />
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="updPgrTipoPers" runat="server" AssociatedUpdatePanelID="updPnlTipoPers">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgTipoPers" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrMatricula" runat="server" AssociatedUpdatePanelID="UpdMatricula">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="ImgMatricula" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrCiclo" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrPanel6" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgNivel" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">Alumno</div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="updPnlTipoPers" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlTipoPers" runat="server" CssClass="btn btn-tipo dropdown-toggle browser-default custom-select custom-select-lg mb-3" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoPers_SelectedIndexChanged">
                                                                                <asp:ListItem Value="UNACH">UNACH</asp:ListItem>
                                                                                <asp:ListItem Value="PSU">PSU</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-3 text-right">
                                                                    Ficha/Matricula/Id Sysweb
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"
                                                                            TabIndex="2" MaxLength="9" CausesValidation="True"
                                                                            ValidationGroup="gpoBusca">
                                                                        </asp:TextBox>
                                                                        <asp:UpdatePanel ID="UpdMatricula" runat="server">
                                                                            <ContentTemplate>
                                                                                <span class="input-group">
                                                                                    <asp:LinkButton ID="linkBttnBuscar" runat="server" CssClass="btn btn-warning form-control" OnClick="linkBttnBuscar_Click">
                                                                                        <i class="fa fa-search" aria-hidden="true"></i>Buscar
                                                                                    </asp:LinkButton>
                                                                                    <asp:LinkButton ID="Registrar" runat="server" CssClass="btn btn-blue-grey" Visible="false">Agregar</asp:LinkButton>
                                                                                </span>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMatricula" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row" id="rowTipoAlu" runat="server">
                                                                <div class="col-md-1">
                                                                    Generación
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlCicloAlum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCicloAlum_SelectedIndexChanged" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="ddlCicloAlum" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="BuscarAlu" InitialValue="0" TabIndex="3"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    Nivel
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged1" AutoPostBack="true">
                                                                                <asp:ListItem Value="Z">--NINGÚN REGISTRO--</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="ddlNivel" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="BuscarAlu" InitialValue="Z"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    Dependencia
                                                                </div>
                                                                <div class="col-md-11">
                                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlDependencia_D" runat="server" AutoPostBack="True" ClientIDMode="Predictable" Enabled="False" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" TabIndex="1" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependencia_D" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    Carrera
                                                                </div>
                                                                <div class="col-md-11">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlCarrera" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" TabIndex="6" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    <asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar" Visible="False"></asp:Label>
                                                                </div>
                                                                <div class="col-md-11">
                                                                    <asp:TextBox ID="txtCarrera" runat="server" Visible="False" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="updPnlNombre" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtNombre" runat="server" Enabled="False" MaxLength="700" ReadOnly="True" TabIndex="5" CssClass="form-control"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    Paterno
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtPaterno" runat="server" Enabled="False" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    Materno
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtMaterno" runat="server" Enabled="False" TabIndex="5" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" Enabled="False" Width="80%"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaNacimiento" PopupButtonID="imgCalNac" BehaviorID="_content_CalendarExtender1" />
                                                                    <asp:ImageButton ID="imgCalNac" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                </div>
                                                                <div class="col-md-1 text-right">
                                                                    Sexo
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                                                                        <asp:ListItem Value="F">Femenino</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-md-1 text-right">
                                                                    Semestre
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:TextBox ID="txtSemestre" runat="server" TabIndex="7" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-1 text-right">
                                                                    Grupo
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control" TabIndex="8" Width="100%"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                    <HeaderTemplate>
                                                        <i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i>&nbsp;Datos de la Exención
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="updPgrAgrEmp" runat="server" AssociatedUpdatePanelID="updPnlAgrEmp">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgAgrEmp" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrPanel7" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgPanel7" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrPanel4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgPanel4" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="UpdPgrPanel5" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgPanel5" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">Ciclo de Exención</div>
                                                                <div class="col-md-5">
                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>
                                                                            <customControl:GroupDropDownList ID="ddlCiclo_D" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCiclo_D_SelectedIndexChanged" CssClass="form-control"></customControl:GroupDropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">Fecha Ini</div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtFechaInicial" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFechaInicial" PopupButtonID="imgCalendarioIni" BehaviorID="_content_CalendarExtenderIni" />
                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                                                                </div>
                                                                <div class="col-md-1">Fecha Fin</div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFinal" BehaviorID="_content_CalendarExtenderFin" />
                                                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">Tipo</div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlSubTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged" CssClass="form-control">
                                                                                <asp:ListItem Value="X">--SELECCIONAR--</asp:ListItem>
                                                                                <asp:ListItem>RECARGO</asp:ListItem>
                                                                                <asp:ListItem>EXENTO</asp:ListItem>
                                                                                <asp:ListItem>DESCUENTO</asp:ListItem>
                                                                                <asp:ListItem Value="CUOTA_NORMAL">CUOTA NORMAL</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">SubTipo</div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">Estatus</div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel231" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlStatus" runat="server" TabIndex="11" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="lblEstatusA" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2 text-right">
                                                                    <asp:UpdatePanel ID="UpdatePanel234" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblPorcentaje" runat="server" Text="% Descuento"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtPorcentaje" runat="server" TabIndex="13" CssClass="form-control">100</asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPorcentaje" CssClass="MsjError" ErrorMessage="*Requerido" SetFocusOnError="True" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    <asp:Label ID="lblEmpleado" runat="server" Font-Bold="False" Text="Empleado UNACH"></asp:Label>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="0">AGREGAR--&gt;</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="hddnEmp" runat="server" />
                                                                </div>
                                                                <div class="col-md-2 text-left">
                                                                    <asp:UpdatePanel ID="updPnlAgrEmp" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="linkBttnEmpleado" CssClass="btn btn-blue-grey" runat="server" OnClick="linkBttnEmpleado_Click"><i class="fa fa-user-plus fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="linkBttnBorrarEmpleado" CssClass="btn btn-danger" runat="server" OnClick="linkBttnBorrarEmpleado_Click"><i class="fa fa-user-times fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="UpdatePanel244" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Label ID="lblErrorBuscEmp" runat="server" CssClass="mensaje_rojo" Visible="False" Width="100%"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:Label ID="lblMsjGuardar" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6 alert alert-warning  font-weight-bold">
                                                                    Conceptos Disponibles
                                                                </div>
                                                                <div class="col-md-6 alert alert-warning  font-weight-bold">
                                                                    Conceptos Agregados
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="updPgrConceptos" runat="server" AssociatedUpdatePanelID="updPnlConceptos">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgConc" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col text-center">
                                                                    <asp:UpdateProgress ID="updPgrConcAsig" runat="server" AssociatedUpdatePanelID="updPnlConcAsig">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imgConcAsig" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div id="divGrid" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                        <asp:UpdatePanel ID="updPnlConceptos" runat="server">
                                                                            <ContentTemplate>
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
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div id="divGrid2" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">
                                                                        <asp:UpdatePanel ID="updPnlConcAsig" runat="server">
                                                                            <ContentTemplate>
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
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" CssClass="nav nav-tabs">
                                                    <HeaderTemplate>
                                                        <i class="fa fa-upload fa-2x" aria-hidden="true"></i>&nbsp;Oficio(s)
                                                    </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    Número de Oficio
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txtOficio" runat="server" CssClass="form-control" MaxLength="200" TabIndex="16"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    Fecha del Oficio
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:TextBox ID="txtFechaO" runat="server" CssClass="form-control" onkeyup="javascript:this.value='';" TabIndex="17" Width="100%"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <ajaxToolkit:CalendarExtender ID="calendarioFechaOficio" runat="server" BehaviorID="_content_calendarioFechaOficio" PopupButtonID="imgCalendarioOficio" TargetControlID="txtFechaO" />
                                                                    <asp:ImageButton ID="imgCalendarioOficio" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-2">
                                                                    Autorizado Por
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="updPnlAutorizado" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlLAutorizado" runat="server" CssClass="form-control" Visible="False"></asp:DropDownList>
                                                                            <asp:TextBox ID="txtAutorizado" runat="server" CssClass="form-control" TabIndex="18"></asp:TextBox>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    Solicitado Por
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txtSolicitado" runat="server" CssClass="form-control" MaxLength="700" TabIndex="18"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-11">
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="input-group mb-3">
                                                                                <div class="input-group-prepend">
                                                                                    <span class="input-group-text">PDF</span>
                                                                                </div>
                                                                                <div style="width: 90%">
                                                                                    <asp:FileUpload ID="FileOficio" runat="server" class="form-control" Height="40px" Width="100%" />
                                                                                </div>
                                                                                <div class="input-group-append">
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileOficio" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF|png|PNG|jpeg|JPEG|jpg|JPG|gif|GIF)$"></asp:RegularExpressionValidator>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="bttnAgregaOficio" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:Button ID="bttnAgregaOficio" runat="server" CssClass="btn btn-dark" OnClick="bttnAgregaOficio_Click" Text="Adjuntar" />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:GridView ID="grvOficios" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay oficios registrados" OnRowDeleting="grvOficios_RowDeleting" Width="100%">
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
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                            </ajaxToolkit:TabContainer>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-center">
                                            <asp:UpdateProgress ID="updPgrGuardar" runat="server" AssociatedUpdatePanelID="updPnlGuardar">
                                                <ProgressTemplate>
                                                    <asp:Image ID="img3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col text-right">
                                            <asp:UpdatePanel ID="updPnlGuardar" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="Cancelar" />
                                                    &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" TabIndex="20" Text="Guardar" ValidationGroup="guardar" />
                                                    &nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">Observaciones</div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" Height="80px" MaxLength="1024" TabIndex="19" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                                                <div class="card">
                                                    <div class="card-body">
                                                        <h5 class="card-title">Generó Recibo</h5>
                                                        <p class="card-text">
                                                            <asp:Label ID="lblUsuGenerar" runat="server"></asp:Label>
                                                        </p>
                                                        <p class="card-text">
                                                            <asp:Label ID="lblFechaGenerar" runat="server"></asp:Label>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div align="center">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3_">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image855" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3_" runat="server">
                                    <ContentTemplate>
                                        <div align="right">
                                            <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" Text="Regresar" Visible="False" />
                                        </div>
                                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor" style="height: 500px" width="100%"></iframe>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <div class="row">
            <div class="col">
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
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalPagos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">

        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modConceptos">Información de la Referencia</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col font-weight-bold">
                                AVISO
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">¿Esta seguro que desea generar el recibo en cero?</div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel227">
                                    <ProgressTemplate>
                                        <div class="overlay">
                                            <div class="overlayContent">
                                                <asp:Image ID="Image13" runat="server" Height="19px" ImageUrl="~/Imagenes/loader.gif" Width="220px" />
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdatePanel ID="UpdatePanel227" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnNueva" runat="server" CssClass="btn btn-info" OnClick="btnNueva_Click" Text="SI" />
                                        &nbsp;<asp:Button ID="CancelAlert" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="NO" />
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalEmpleado">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Personal UNACH</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <div class="container">
                                <div class="row">
                                    <div class="col alert alert-warning">
                                        <asp:Label ID="lblAlumno" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrBuscarEmp" runat="server" AssociatedUpdatePanelID="updPnlBuscarEmp">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgBuscarEmp" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrEmpleados" runat="server" AssociatedUpdatePanelID="updPnlEmpleados">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgEmpleados" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <%--<div class="row">
                                                            <div class="col text-center">
                                                                <asp:UpdateProgress ID="updPgrAddEmp" runat="server" AssociatedUpdatePanelID="updPnlAddEmp">
                                                                    <ProgressTemplate>
                                                                        <asp:Image ID="imgAddEmp" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </div>
                                                        </div>--%>
                                <div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrHijo" runat="server" AssociatedUpdatePanelID="updPnlHijo">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgHijo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <asp:MultiView ID="mltViewFamiliares" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View4" runat="server">
                                        <div class="row">
                                            <div class="col">
                                                Personal
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtNombreEmp" runat="server" PlaceHolder="Nombre Paterno Materno" CssClass="form-control"></asp:TextBox>
                                                    <div class="input-group-append">
                                                        <asp:UpdatePanel ID="updPnlBuscarEmp" runat="server">
                                                            <ContentTemplate>
                                                                <asp:ImageButton ID="imgBttnBuscarEmp" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscarEmp_Click" ValidationGroup="EmpleadoBusca" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtNombreEmp" ErrorMessage="*Requerido" ValidationGroup="EmpleadoBusca"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:UpdatePanel ID="updPnlEmpleados" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grvEmpleados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningun registro." OnPageIndexChanging="grvEmpleados_PageIndexChanging" OnSelectedIndexChanged="grvEmpleados_SelectedIndexChanged" PageSize="6" Width="100%">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <Columns>
                                                                <asp:BoundField DataField="IdPersona" />
                                                                <asp:BoundField DataField="TipoPersonaStr" HeaderText="TIPO PERSONAL">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Dependencia" HeaderText="DEPCIA">
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
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lblHijo" runat="server" Text="Beneficiario(s)"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <div class="input-group">
                                                    <asp:UpdatePanel ID="updPnlHijo" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlHijo" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHijo" ErrorMessage="*Requerido" InitialValue="9999999" ValidationGroup="Empleado"></asp:RequiredFieldValidator>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="input-group-prepend">
                                                        <asp:ImageButton ID="bttnNuevoHijo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" Height="45px" OnClick="bttnNuevoHijo_Click" ValidationGroup="Nuevo Beneficiario" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:DropDownList ID="ddlParentesco" runat="server" Visible="False" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-right">
                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                    <ContentTemplate>
                                                        <button type="button" class="btn btn-blue-grey" data-dismiss="modal">CERRAR</button>
                                                        <asp:Button ID="bttnAgregarEmp" runat="server" CssClass="btn btn-primary" OnClick="bttnAgregarEmp_Click" Text="AGREGAR" ValidationGroup="Empleado" />


                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                    </asp:View>
                                    <asp:View ID="View5" runat="server">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col">
                                                    <h4>
                                                        <asp:Label ID="lblEtParentesco" runat="server" Text="Familiares"></asp:Label>
                                                    </h4>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <asp:Label ID="lblNombreFamiliar" runat="server" Text="Nombre"></asp:Label>
                                                </div>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtNombreFamiliar" runat="server" PlaceHolder="Nombre Ap. Paterno Ap. Materno" Width="90%"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <asp:Label ID="lblParentesco" runat="server" Text="Parentesco"></asp:Label>
                                                </div>
                                                <div class="col-md-10">
                                                    <asp:DropDownList ID="ddlParentescoFam" runat="server" Width="90%">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col text-right">
                                                    <asp:Button ID="bttnSalirFam" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnSalirFam_Click" Text="REGRESAR" />
                                                    &nbsp;<asp:Button ID="bttnAgregarFam" runat="server" CssClass="btn btn-info" OnClick="bttnAgregarFam_Click" Text="GUARDAR" />
                                                </div>
                                            </div>
                                        </div>
                                    </asp:View>
                                </asp:MultiView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
      
<%--        $(document).ready(function () {
            var tableExentosAdmin = $('#<%= grvAlumnos.ClientID %>').DataTable();

            tableExentosAdmin
                .clear()
                .draw();



            
        };



        function FiltEventos() {
            $('#<%= ddlEvento.ClientID %>').select2();
        };

        function ExentosNormal() {
            $('#<%= grvAlumnos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvAlumnos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "columns": [
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                ]
            })
        };
--%>

        function ExentosAdmin() {
            $('#<%= grvAlumnos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvAlumnos.ClientID %>').find("tr:first"))).DataTable()({
                "destroy": true,
                "stateSave": true,
                "columns": [
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                ]
            })
        };

       <%-- function Monitor() {
            $('#<%= grvStatus.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvStatus.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };--%>

    </script>
</asp:Content>
