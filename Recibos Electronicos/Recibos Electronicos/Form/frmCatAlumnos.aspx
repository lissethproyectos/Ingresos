<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatAlumnos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatAlumnos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }

        .auto-style4 {
            width: 15%;
        }

        .auto-style11 {
            width: 32%;
        }

        .auto-style12 {
            width: 69%;
        }

        .auto-style13 {
            width: 992px;
        }

        .auto-style14 {
            width: 100%;
        }

        .auto-style17 {
            width: 19%;
        }

        .auto-style18 {
            width: 18%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        Tipo:
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" CssClass="form-control">
                                    <asp:ListItem Value="TODOS">TODOS</asp:ListItem>
                                    <asp:ListItem>ACEPTADO</asp:ListItem>
                                    <asp:ListItem>ASPIRANTE</asp:ListItem>
                                    <asp:ListItem>ALUMNO</asp:ListItem>
                                    <asp:ListItem>EGRESADO</asp:ListItem>
                                    <asp:ListItem>ALUMNO LENGUAS</asp:ListItem>
                                    <asp:ListItem>CLIENTE UNACH</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        Nivel:
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNivel" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="BuscaAlumnos">*</asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">Ciclo Escolar:</div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCicloEscolar" runat="server" AutoPostBack="True" CssClass="form-control">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-md-2">
                        Dependencia:
                    </div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-md-2">Buscar:</div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtBuscar" runat="server" PlaceHolder="Matricula/Nombre" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" ValidationGroup="BuscaAlumnos" />
                    </div>
                    <div class="col-md-3">
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row text-center">
                    <div class="col">
                        <asp:UpdateProgress ID="updProgCiclo" runat="server" AssociatedUpdatePanelID="UpdatePanel10">
                            <ProgressTemplate>
                                <asp:Image ID="imgProgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="col">
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                            <ProgressTemplate>
                                <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="col">
                        <div style="overflow-x: auto;">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grvAlumnosUNACH" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro." OnPageIndexChanging="grvAlumnosUNACH_PageIndexChanging" PageSize="20" Width="100%" Font-Size="Small">
                                        <Columns>
                                            <asp:BoundField DataField="TipoPersonaStr" HeaderText="Origen" />
                                            <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Ciclo Escolar<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlCiclo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCiclo_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CicloEscolar") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CicloEscolar" HeaderText="Ciclo Escolar">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Matricula" HeaderText="Mat/Ficha" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Observaciones" HeaderText="Esquema" />
                                            <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                            <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                            <asp:BoundField DataField="Password" HeaderText="Password" />
                                            <asp:TemplateField HeaderText="Página">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("LinkEsquema") %>' Text='<%# Bind("Esquema") %>' Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                <div class="row text-right">
                    <div class="col">
                        <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                        <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
