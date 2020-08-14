<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatCarrerasPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatCarrerasPosgrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 667px;
        }

        .auto-style4 {
            width: 66px;
        }

        .auto-style5 {
            width: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged">
                            <asp:ListItem Value="T">--Todos--</asp:ListItem>
                            <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                            <asp:ListItem Value="N">Lenguas Extranjeras</asp:ListItem>
                            <asp:ListItem Value="E">Especialidad</asp:ListItem>
                            <asp:ListItem Value="M">Maestría</asp:ListItem>
                            <asp:ListItem Value="D">Doctorado</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" CssClass="select2">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                    <ProgressTemplate>
                        <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblBuscar" runat="server" Text="Busca:"></asp:Label>
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="txtBusca" runat="server" Width="100%" PlaceHolder="Por nombre ó id de la carrera"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                    <ProgressTemplate>
                        <asp:Image ID="Image89" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvCarrerasUNACH" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvCarrerasUNACH_PageIndexChanging" PageSize="20" Width="100%" EmptyDataText="No se encontro ningún registro">
                            <Columns>
                                <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Dependencia" HeaderText="Dependencia">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescCarrera" HeaderText="Carrera">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Carrera" HeaderText="Cve. Carrera">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
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

        <div class="row">
            <div class="col text-right">
                <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
