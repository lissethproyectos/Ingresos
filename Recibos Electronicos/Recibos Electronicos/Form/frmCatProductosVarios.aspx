<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatProductosVarios.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatProductosVarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="mGrid" Width="100%" ScrollBars="Horizontal">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                    <HeaderTemplate>
                        Productos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col text-center">
                                    <asp:UpdateProgress ID="updPgrProductos" runat="server"
                                        AssociatedUpdatePanelID="updPnlProductos">
                                        <ProgressTemplate>
                                            <asp:Image ID="imgProd" runat="server"
                                                AlternateText="Espere un momento, por favor.." Height="50px"
                                                ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                ToolTip="Espere un momento, por favor.." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="updPnlProductos" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvProductos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No hay productos registrados." OnPageIndexChanging="grvProductos_PageIndexChanging" OnRowCancelingEdit="grvProductos_RowCancelingEdit" OnRowEditing="grvProductos_RowEditing" OnRowUpdating="grvProductos_RowUpdating" Width="100%" ShowHeaderWhenEmpty="True">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tipo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Id_Inventario" HeaderText="# Producto" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                        <ItemStyle Width="45%" />
                                                    </asp:BoundField>
                                                    <asp:CommandField ShowEditButton="True" EditImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Button ID="bttnAgregar" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnAgregar_Click" Text="AGREGAR" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkEliminar" runat="server" OnClick="linkEliminar_Click" OnClientClick="return confirm('¿Eliminar registro?');">Eliminar</asp:LinkButton>
<%--<asp:LinkButton ID="linkBttnEliminar" runat="server" CausesValidation="False" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');"  OnClick="linkEliminar_Click" ><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>--%>
                                                        </ItemTemplate>

                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <HeaderStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Servicios
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-2">
                                    Dependencia
                                </div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDLDependencia2" runat="server" ClientIDMode="Predictable" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DDLDependencia2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtBuscar" runat="server" Width="100%" Placeholder="Grupo/Descripción"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                </div>
                            </div>
<div class="row">
                                    <div class="col text-center">
                                        <asp:UpdateProgress ID="updPgrServicios" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgDatos" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                                    ToolTip="Espere un momento, por favor.." Width="50px" Height="50px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvServicios" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningun registro." PageSize="6" Width="100%" OnPageIndexChanging="grvServicios_PageIndexChanging" ShowHeaderWhenEmpty="True" AllowSorting="True">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:BoundField DataField="Id_Inventario" />
                                                    <asp:BoundField DataField="DEPENDENCIA" HeaderText="DEPCIA">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Grupo" HeaderText="GRUPO"></asp:BoundField>
                                                    <asp:BoundField DataField="TipoGrupo" HeaderText="SUBGRUPO"></asp:BoundField>
                                                    <asp:BoundField DataField="CLAVE" HeaderText="CLAVE"></asp:BoundField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCIÓN">
                                                        <ItemStyle Width="50%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="COSTO" HeaderText="IMPORTE" DataFormatString="{0:c}">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Right" Font-Bold="True" />

                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ESTATUS" HeaderText="STATUS" />
                                                    <asp:BoundField DataField="CONCEPTO" HeaderText="CONCEPTO" />
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:Button ID="bttnAgregar2" runat="server" CssClass="btn btn-blue-grey" Font-Size="X-Small" OnClick="bttnAgregar2_Click" Text="AGREGAR" Width="87px" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <%--&#160;<asp:ImageButton ID="imgBttnEliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClick="imgBttnEliminar_Click" OnClientClick="return confirm('¿Eliminar registro?');" />--%>
                                                            <asp:LinkButton ID="linkBttnEliminarConc" runat="server" CausesValidation="False" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" OnClick="linkBttnEliminarConc_Click"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="linkBttnEditarConc" runat="server" CausesValidation="False" OnClick="linkBttnEditarConc_Click"><i class="fa fa-pencil  fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            <%--&#160;<asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" OnClick="imgBttnEditar_Click" />--%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_CONCEPTO" />
                                                </Columns>
                                                <FooterStyle CssClass="enc" />
                                                <HeaderStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                    &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="modalProd" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modOficios">Productos/Servicios</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                        <ContentTemplate>
                            <asp:MultiView ID="multiview" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-2">
                                                Tipo
                                            </div>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="DDLTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                                                    <asp:ListItem Value="PPE">Producción Pecuaria</asp:ListItem>
                                                    <asp:ListItem Value="PAG">Producción Agrícola</asp:ListItem>
                                                    <asp:ListItem Value="LBT">Laboratorio</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">Descripción</div>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtDescripcion" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lblMsj" runat="server" Font-Bold="True"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-right">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="GUARDAR" ValidationGroup="Guardar" />
                                                        &nbsp;<asp:Button ID="btnGuardar_Salir" runat="server" CssClass="btn btn-info" OnClick="btnGuardar_Salir_Click" Text="GUARDAR Y SALIR" ValidationGroup="Guardar" />
                                                        &nbsp;<asp:Button ID="btnCancelar_C" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_C_Click" Text="SALIR" />

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-2">
                                                Depcia
                                            </div>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="DDLDependencia" runat="server" ClientIDMode="Predictable" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-center">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DDLDependencia" ErrorMessage="RequiredFieldValidator" ValidationGroup="Guardar" InitialValue="00000">* Requerido</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">Clave</div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtClave" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">Grupo</div>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="DDLGrupo" runat="server" Width="100%">
                                                    <asp:ListItem>CONSULTA</asp:ListItem>
                                                    <asp:ListItem>SERVICIO</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            </div>
                                        <div class="row">
                                            <div class="col-md-2">SubGrupo</div>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="DDLRubro" runat="server" Width="100%">
                                                    <asp:ListItem>ANÁLISIS DE SUELO</asp:ListItem>
                                                    <asp:ListItem>ANÁLISIS DE AGUA</asp:ListItem>
                                                    <asp:ListItem>ANÁLISIS DE COMPOSTA</asp:ListItem>
                                                    <asp:ListItem>CONSULTORIO</asp:ListItem>
                                                    <asp:ListItem>CIRUGIAS</asp:ListItem>
                                                    <asp:ListItem>LABORATORIO</asp:ListItem>
                                                    <asp:ListItem>MAQUILA</asp:ListItem>
                                                    <asp:ListItem>SERVICIO</asp:ListItem>
                                                    <asp:ListItem>RENTA DE ESPACIO</asp:ListItem>
                                                    <asp:ListItem>TERRACERÍAS</asp:ListItem>
                                                    <asp:ListItem>PAVIMENTOS</asp:ListItem>
                                                    <asp:ListItem>CONCRETO</asp:ListItem>
                                                    <asp:ListItem>ACERO</asp:ListItem>
                                                    <asp:ListItem>TABIQUES</asp:ListItem>
                                                    <asp:ListItem>LADRILLOS</asp:ListItem>
                                                    <asp:ListItem>BLOQUES</asp:ListItem>
                                                    <asp:ListItem>TABIQUES, LADRILLOS Y BLOQUES</asp:ListItem>
                                                    <asp:ListItem>MECANICA DE SUELOS</asp:ListItem>
                                                    <asp:ListItem>TECNOLOGIA DE CONCRETO</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Concepto
                                            </div>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="DDLConcepto" runat="server" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Descripción
                                            </div>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtDescripcion2" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion2" ErrorMessage="RequiredFieldValidator" ValidationGroup="Guardar">* Requerido</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                Costo
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-right">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnGuardar2" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar2_Click" Text="GUARDAR" ValidationGroup="Guardar" />
                                                        &nbsp;<asp:Button ID="btnGuardar_Salir2" runat="server" CssClass="btn btn-info" OnClick="btnGuardar_Salir2_Click" Text="GUARDAR Y SALIR" ValidationGroup="Guardar" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col text-center">
                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                                    AssociatedUpdatePanelID="UpdatePanel3">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="Image86" runat="server"
                                                            AlternateText="Espere un momento, por favor.." Height="50px"
                                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                            ToolTip="Espere un momento, por favor.." />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">    
        function Productos() {
            $('#<%= grvProductos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvProductos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function Servicios() {
            $('#<%= grvServicios.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvServicios.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };
    </script>
</asp:Content>
