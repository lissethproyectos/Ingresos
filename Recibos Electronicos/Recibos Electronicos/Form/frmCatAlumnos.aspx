<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatAlumnos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatAlumnos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>--%>
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-9">
                <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Tipo
            </div>
            <div class="col-md-3">
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
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPnlTipo" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
                    <ProgressTemplate>
                        <asp:Image ID="img5" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>

            </div>
            <div class="col-md-1">
                Ciclo              
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="updPnlCiclo" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCicloEscolar" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPrgCiclo" runat="server" AssociatedUpdatePanelID="updPnlCiclo">
                    <ProgressTemplate>
                        <asp:Image ID="img3" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>

            </div>
        </div>
    </div>
    <div class="container">

        <div class="row">
            <div class="col-md-2">Nivel</div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNivel" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="BuscaAlumnos">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPrgPnl7" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                    <ProgressTemplate>
                        <asp:Image ID="img2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>


            </div>
            <div class="col-md-1">Buscar</div>
            <div class="col-md-3">
                <asp:TextBox ID="txtBuscar" runat="server" Width="100%" PlaceHolder="Matricula/Nombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" ValidationGroup="BuscaAlumnos" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdateProgress ID="updPrgBuscar" runat="server" AssociatedUpdatePanelID="updPnlBuscar">
                    <ProgressTemplate>
                        <asp:Image ID="imgBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row text-center">
            <div class="col">
                <asp:UpdateProgress ID="updGrid" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgGrid" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row text-center">
            <div class="col-md-11">
                <div style="overflow-x: auto;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grvAlumnosUNACH" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvAlumnosUNACH_PageIndexChanging" PageSize="20" Width="100%" Font-Size="Small">
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
                                    <asp:BoundField DataField="Correo_Instituicional" HeaderText="Correo Instituicional" />
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
            <div class="col-md-11">
                <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
            </div>
        </div>
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script type="text/javascript">
     function CatAlumnos() {
            $('#<%= grvAlumnosUNACH.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvAlumnosUNACH.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };
    </script>
</asp:Content>
