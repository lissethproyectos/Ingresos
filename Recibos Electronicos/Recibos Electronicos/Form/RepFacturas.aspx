<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepFacturas.aspx.cs" Inherits="Recibos_Electronicos.Form.RepFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Js/jsGeneral.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia Inicial
            </div>
            <div class="col-md-10">
                <asp:DropDownList
                    ID="ddlDependencia" runat="server" Width="100%"
                    OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Dependencia Final
            </div>
            <div class="col-md-10">
                <asp:DropDownList
                    ID="ddlDependenciaFinal" runat="server" Width="100%"
                    OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Ejercicio
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="DDLEjercicio" runat="server"
                    OnSelectedIndexChanged="DDLEjercicio_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-1">
                Status
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem>SOLICITADO</asp:ListItem>
                    <asp:ListItem>FACTURADO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkBttnReporte" runat="server" CssClass="btn btn-primary" OnClick="linkBttnReporte_Click"><i class="fa fa-print" aria-hidden="true"></i> Reporte</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj1" runat="server" Text="Label" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                            style="height: 500px" width="100%"></iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
