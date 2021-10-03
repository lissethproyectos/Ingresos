<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMensajes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmMensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View2" runat="server">
                        <div class="row">
                        <div class="col text-center">
                            <asp:UpdateProgress ID="updPgrMsj" runat="server" AssociatedUpdatePanelID="updPnlMsj">
                                <ProgressTemplate>
                                    <asp:Image ID="Image88" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlMsj" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvMensajes" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowDeleting="grvMensajes_RowDeleting" OnSelectedIndexChanged="grvMensajes_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="IdMensaje" HeaderText="IdMensaje" />
                                                <asp:BoundField DataField="Tipo_Usuario" HeaderText="Tipo Usuario" >
                                                    <ItemStyle Font-Bold="True" /></asp:BoundField>
                                                <asp:BoundField DataField="TMensaje" HeaderText="Mensaje"></asp:BoundField>
                                                <asp:BoundField DataField="Status" HeaderText="Status">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_inicial" HeaderText="Fecha Inicial" />
                                                <asp:BoundField DataField="Fecha_inicial" HeaderText="Fecha Final" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkBttnEditar" runat="server" CommandName="Select" Width="100%">Editar</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Button ID="bttnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-info" OnClick="bttnNuevo_Click" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkBttnEliminar" runat="server" CommandName="Delete" Width="100%" OnClientClick="return confirm('¿Desea eliminar el registro?');">Eliminar</asp:LinkButton>
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

                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <div class="row">
                            <div class="col-md-2">Tipo de Usuario</div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DDLTipoUsu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoUsu_SelectedIndexChanged">
                                            <asp:ListItem Value="3">Usuario Dependencia</asp:ListItem>
                                            <asp:ListItem Value="1">Alumno</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Dependencia
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Fecha Inicial
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtFecha_Inicial" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Inicial" />
                                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="col-md-1">
                                F Final
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtFecha_Final" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Final" />
                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="col-md-1">
                                Status
                            </div>
                            <div class="col-md-2">
                                <asp:RadioButtonList ID="rdoBttnStatus" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <ajaxToolkit:HtmlEditorExtender ID="editorMensaje" runat="server" DisplaySourceTab="True" TargetControlID="txtMensaje" EnableSanitization="False">
                                    <Toolbar>
                                        <ajaxToolkit:Undo />
                                        <ajaxToolkit:Redo />
                                        <ajaxToolkit:Bold />
                                        <ajaxToolkit:Italic />
                                        <ajaxToolkit:Underline />
                                        <ajaxToolkit:StrikeThrough />
                                        <ajaxToolkit:Subscript />
                                        <ajaxToolkit:Superscript />
                                        <ajaxToolkit:JustifyLeft />
                                        <ajaxToolkit:JustifyCenter />
                                        <ajaxToolkit:JustifyRight />
                                        <ajaxToolkit:JustifyFull />
                                        <ajaxToolkit:InsertOrderedList />
                                        <ajaxToolkit:InsertUnorderedList />
                                        <ajaxToolkit:CreateLink />
                                        <ajaxToolkit:UnLink />
                                        <ajaxToolkit:RemoveFormat />
                                        <ajaxToolkit:SelectAll />
                                        <ajaxToolkit:UnSelect />
                                        <ajaxToolkit:Delete />
                                        <ajaxToolkit:Cut />
                                        <ajaxToolkit:Copy />
                                        <ajaxToolkit:Paste />
                                        <ajaxToolkit:BackgroundColorSelector />
                                        <ajaxToolkit:ForeColorSelector />
                                        <ajaxToolkit:FontNameSelector />
                                        <ajaxToolkit:FontSizeSelector />
                                        <ajaxToolkit:Indent />
                                        <ajaxToolkit:Outdent />
                                        <ajaxToolkit:InsertHorizontalRule />
                                        <ajaxToolkit:HorizontalSeparator />
                                        <ajaxToolkit:InsertImage />
                                    </Toolbar>
                                </ajaxToolkit:HtmlEditorExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" TabIndex="15" Text="GUARDAR" ValidationGroup="guardar" />
                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="16" Text="CANCELAR" />
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">       
        function Mensajes() {
            //$('input[type=search]').val('');
            $('#<%= grvMensajes.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvMensajes.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };
    </script>
</asp:Content>
