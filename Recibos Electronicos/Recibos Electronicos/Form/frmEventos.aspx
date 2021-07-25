<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmEventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="DDLDependencia" runat="server" Width="100%" CssClass="select2">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div class="row">
                            <div class="col-md-2">
                                Año
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlEjercicio" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                Status
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="ddlStatusB" runat="server" Width="100%">
                                    <asp:ListItem Value="T">TODOS</asp:ListItem>
                                    <asp:ListItem Value="S">SOLICITADO</asp:ListItem>
                                    <asp:ListItem Value="A">ACTIVO</asp:ListItem>
                                    <asp:ListItem Value="B">BAJA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                Tipo de Evento
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="updPnlDirigido" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDirigido0" runat="server" AutoPostBack="True" Width="100%">
                                            <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                                            <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                                            <asp:ListItem Value="P">Eventos Privados</asp:ListItem>
                                            <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click"><i class="fa fa-search" aria-hidden="true"></i> Buscar</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlEventos" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged" EmptyDataText="No hay eventos registrados." OnRowEditing="grdEventos_RowEditing" OnRowCancelingEdit="grdEventos_RowCancelingEdit" OnRowUpdating="grdEventos_RowUpdating">
                                            <Columns>
                                                <asp:BoundField DataField="dependencia" HeaderText="DEPCIA" ReadOnly="True" />
                                                <asp:BoundField DataField="nivel" HeaderText="NIVEL" ReadOnly="True" />
                                                <asp:BoundField DataField="eventos" HeaderText="CVE" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="EVENTO">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkGenRef" runat="server" ToolTip="Generar Referencia"> <%# DataBinder.Eval(Container.DataItem, "descripcion")%></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="status" HeaderText="STATUS" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="FECHA INICIO">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFechaIniG" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="calExtFechaIni" runat="server" TargetControlID="txtFechaIniG" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha_inicial") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="FECHA FINAL">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFechaFinG" runat="server" Text='<%# Bind("fecha_final") %>'></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFinG" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha_final") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField EditText="Editar Fechas" ShowEditButton="True" ItemStyle-ForeColor="#990033" HeaderText="VIGENCIA">
                                                    <ItemStyle ForeColor="#990033" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="OFICIO(S)">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnOficios" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" Height="25px" Text='<%# Bind("NoOficio") %>' Width="80px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-warning" Text="NUEVO" ValidationGroup="Agregar" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%--                                                        &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit2.png" Visible='<%# Bind("EsVisible2") %>' />--%>
                                                        <asp:LinkButton ID="linkBttnEditEnabled" runat="server" Visible='<%# Bind("EsVisible2") %>'><i class="fa fa-pencil  fa-2x disabled" aria-hidden="true"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="linkBttnEdit" runat="server" Visible='<%# Bind("EsVisible") %>'><i class="fa fa-pencil  fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="linkBttnEliminar" runat="server"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="linkBttnReporte" runat="server"><i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i></asp:LinkButton>

                                                        <%--<asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/edit.png" OnClick="imgBttnEditar_Click" Visible='<%# Bind("EsVisible") %>' />--%>
                                                        <%--                                                        &nbsp;<asp:ImageButton ID="ctrl_eliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" />--%>
                                                        <%--&nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" Height="20px" ImageUrl="~/Imagenes/ico-pdf2.png" Width="20px" />--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NUEVA_VERSION" ReadOnly="True" />
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                            <HeaderStyle CssClass="enc" BackColor="#595959" ForeColor="White" Font-Size="10px" BorderColor="White" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function Eventos() {

            $('#<%= grdEventos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdEventos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });

        }

        function FiltDepcias() {
            $(".select2").select2();
        }
    </script>
</asp:Content>
