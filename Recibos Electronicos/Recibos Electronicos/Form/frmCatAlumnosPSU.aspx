<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatAlumnosPSU.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatAlumnosPSU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">Dependencia</div>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">Ciclo</div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlCicloEscolar" runat="server" CssClass="form-control">
                    <asp:ListItem>20231</asp:ListItem>
                    <asp:ListItem>20220</asp:ListItem>
                    <asp:ListItem>20221</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">Nivel</div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" CssClass="form-control">
                    <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkBttnBuscar" runat="server" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click">Buscar</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2 text-center">
                 <asp:UpdateProgress ID="updPgrBuscar" runat="server" AssociatedUpdatePanelID="updPnlBuscar">
                    <ProgressTemplate>
                        <asp:Image ID="imgBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrAlumnosUNACH" runat="server" AssociatedUpdatePanelID="updPnlAlumnosUNACH">
                    <ProgressTemplate>
                        <asp:Image ID="img2" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlAlumnosUNACH" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grvAlumnosUNACH" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" EmptyDataText="No se encontro ningún registro.">
                            <Columns>
                                <asp:BoundField DataField="TipoPersonaStr" HeaderText="Del Extranjero" />
                                <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
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
                                <asp:BoundField DataField="StatusMatricula" HeaderText="Status" />
                                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                <asp:TemplateField HeaderText="Página">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("LinkEsquema") %>' Target="_blank" Text='<%# Bind("Esquema") %>'></asp:HyperLink>
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
    <script type="text/javascript">
        function AlumnosPSU() {
            $('#<%= grvAlumnosUNACH.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvAlumnosUNACH.ClientID %>').find("tr:first"))).DataTable({
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
    </script>
</asp:Content>
