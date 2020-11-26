<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReporteGrals.aspx.cs" Inherits="Recibos_Electronicos.Reportes.frmReporteGrals" %>

<%@ Register TagPrefix="customControl" Namespace="CapaNegocio" Assembly="CapaNegocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Fecha Inicial
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
            </div>
            <div class="col-md-2">
                Fecha Final
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
            </div>
            <div class="col-md-2">
                Nivel
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                Conceptos
            </div>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>
                        <customControl:GroupDropDownList ID="DDLConceptos" runat="server" Width="100%">
                        </customControl:GroupDropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-right">
                &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
