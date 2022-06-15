<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRepsAspirantes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRepsAspirantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDependencia" runat="server" ClientIDMode="Predictable" Width="100%">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCiclo" runat="server" Width="100%">
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblSubTipo1" runat="server" Text="Tipo"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlTipo" runat="server" Width="100%">
                    <asp:ListItem Value="3">TODOS</asp:ListItem>
                    <asp:ListItem Value="1">REFERENCIAS</asp:ListItem>
                    <asp:ListItem Value="2">EXENTOS</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col text-right">
                <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" ValidationGroup="reporte" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
