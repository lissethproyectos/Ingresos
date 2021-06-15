<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatReportes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 139px;
        }

        .auto-style3 {
            width: 282px;
        }

        .auto-style4 {
            width: 171px;
        }

        .auto-style5 {
            width: 245px;
        }

        .auto-style6 {
            width: 282px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-2">
                                    Dependencia
                                </div>
                                <div class="col-md-10">
                                    <asp:UpdatePanel ID="updPnlDep" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-center">
                                    <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="updPnlDep">
                                        <ProgressTemplate>
                                            <asp:Image ID="imgDep" runat="server" Height="36px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                ToolTip="Espere un momento, por favor.." Width="36px" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    Fecha Inicial
                                </div>
                                <div class="col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                            <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-2">
                                    Fecha Final
                                </div>
                                <div class="col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                            <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    Tipo
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlTipo" runat="server" Width="100%">
                                        <asp:ListItem Value="1">Por Dependencia</asp:ListItem>
                                        <asp:ListItem Value="3">Por Dependencia y Nivel</asp:ListItem>
                                        <asp:ListItem Value="2">Por Dependencia y Carreras</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="bttnCatReembolsables" runat="server" CssClass="btn btn-blue-grey" Text="Catálogo de Conceptos Reembolsables" OnClick="bttnCatReembolsables_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-right">
                                    <asp:UpdatePanel ID="updPnlReportes" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                            &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
