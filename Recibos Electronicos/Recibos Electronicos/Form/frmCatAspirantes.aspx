<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatAspirantes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatAspirantes" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>--%>
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="select2" Width="100%">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Nivel
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%">
                            <asp:ListItem Value="T">--Todos--</asp:ListItem>
                            <asp:ListItem Value="Z">Seleccionar Nivel</asp:ListItem>
                            <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                            <asp:ListItem Value="M">Maestria</asp:ListItem>
                            <asp:ListItem Value="E">Especialidad</asp:ListItem>
                            <asp:ListItem Value="D">Doctorado</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNivel" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="BuscaAlumnos">*</asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                Ciclo Escolar
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="updPnlCiclo" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCicloEscolar" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlCicloEscolar_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Origen
            </div>
            <div class="col-md-4">
                        <asp:DropDownList ID="ddlOrigen" runat="server" Width="100%">
                            <asp:ListItem>TODOS</asp:ListItem>
                            <asp:ListItem>ACEPTADO</asp:ListItem>
                            <asp:ListItem>ASPIRANTE</asp:ListItem>
                        </asp:DropDownList>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="txtBuscar" runat="server" PlaceHolder="Matricula/Nombre" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" ValidationGroup="BuscaAlumnos" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrgBuscar" runat="server" AssociatedUpdatePanelID="UpdatePanel13">
                    <ProgressTemplate>
                        <asp:Image ID="imgPrgBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updProgCiclo" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgProgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvAspirantes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvAlumnosUNACH_PageIndexChanging" PageSize="20" Width="100%" Font-Size="Small">
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
        <div class="row">
            <div class="col text-right">
                <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
            </div>
        </div>
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
