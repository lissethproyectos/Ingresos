<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmAlumnos_Clientes.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmAlumnos_Clientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="~/EnviarCorreo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Js/jsGeneral.js"> </script>
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblDependencia" runat="server" Text="Dependencia"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblCarrera0" runat="server" Text="Carrera"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCarrera0" runat="server" AutoPostBack="true"
                                            ClientIDMode="Predictable" TabIndex="5"
                                             CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudio"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged1" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                    <asp:ListItem Value="T">Todos</asp:ListItem>
                                    <asp:ListItem Value="A">Activo</asp:ListItem>
                                    <asp:ListItem Value="C">Inactivos</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblNivel0" runat="server" Text="Matricula/Nombre"></asp:Label>
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                        <asp:ImageButton ID="imgBttnNuevo0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrBuscar" AssociatedUpdatePanelID="updPnlBuscar" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgBuscar" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPgrAlumnos" runat="server" AssociatedUpdatePanelID="updPnlAlumnos">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgAlumnos" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlAlumnos" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvAlumnos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvAlumnos_PageIndexChanging" OnRowDeleting="grvAlumnos_RowDeleting" OnSelectedIndexChanging="grvAlumnos_SelectedIndexChanging" PageSize="15" Width="100%" EmptyDataText="No existen registros." ShowHeaderWhenEmpty="True" ShowFooter="True">
                                            <Columns>
                                                <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                                <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Grupo" HeaderText="Grupo">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# Bind("ImageStatusMatricula") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IdPersona" HeaderText="Id" />
                                                <asp:TemplateField HeaderText="ENVIAR NOTIFICACIÓN">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EDITAR">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" OnClick="imgBttnEditar_Click" />
                                                        &nbsp;
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BORRAR">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
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
                        <hr />
                        <div class="row">
                            <div class="col text-right">
                                <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2">Dependencia</div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependencia_D" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" TabIndex="3" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependencia_D" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar">
                                        </asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Carrera</div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCarrera" runat="server" AutoPostBack="true" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged" TabIndex="4" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                            
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCarrera" runat="server" Visible="false"  CssClass="form-control" TabIndex="5" AutoPostBack="True"></asp:TextBox>
                                        <asp:TextBoxWatermarkExtender ID="txtCarrera_TextBoxWatermarkExtender" runat="server" TargetControlID="txtCarrera" WatermarkCssClass="watermarked" WatermarkText="Escriba el nombre de la carrera " />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2">
                                Nivel de Estudio
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNivel_D" runat="server" TabIndex="2" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_D_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlNivel_D" ErrorMessage="*Requerido" InitialValue="Z" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1">Matricula</div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                            </div>                           
                            <div class="col-md-1">Semestre</div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtSemestre" runat="server"  CssClass="form-control" TabIndex="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSemestre"
                                    CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar">                                        
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSemestre"
                                    CssClass="MsjError" ErrorMessage="* Solo Números" ValidationExpression="\d+"
                                    ValidationGroup="guardar" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-1">Grupo</div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtGrupo" runat="server"  CssClass="form-control" TabIndex="11"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Nombre</div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNombre"
                                    CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar">                                        
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Apellido Paterno</div>
                            <div class="col-md-4">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtPaterno" runat="server" TabIndex="8" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPaterno" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>                       
                            <div class="col-md-2">Apellido Materno</div>
                            <div class="col-md-4">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtMaterno" runat="server" TabIndex="9" CssClass="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Genero</div>
                            <div class="col-md-2">
                                <asp:RadioButtonList ID="rdoGenero" runat="server" RepeatDirection="Horizontal" TabIndex="12">
                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdoGenero" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator></td>       
                            </div>                                        
                            <div class="col-md-1">
                                Correo
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TabIndex="14"></asp:TextBox>
                            </div>
                             <div class="col-md-1">Activo</div>
                            <div class="col-md-1">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkActivo" runat="server" Checked="true" TabIndex="13" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>          
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image87" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="linkBttnSalir" runat="server" CssClass="btn btn-grey" OnClick="linkBttnSalir_Click"><i class="fa fa-arrow-circle-left fa-2x"></i> Cancelar</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="linkBtnnGuardar" runat="server" CssClass="btn btn-primary" OnClick="linkBtnnGuardar_Click" ValidationGroup="guardar"><i class="fa fa-floppy-o fa-2x" aria-hidden="true"></i> Guardar</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3_">
        <ProgressTemplate>
            <asp:Image ID="Image88" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                ToolTip="Espere un momento, por favor.." />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel3_" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-mdb-color"
                OnClick="btnRegresar_Click" Visible="False" />
            <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                style="height: 500px" width="100%"></iframe>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="modalCorreo" tabindex="-1" role="dialog" aria-labelledby="modalCorreo" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modConceptos">Conceptos</h5>

                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                Enviar Notificación
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMensajeCorreo" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCorreo0" runat="server" Width="90%"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-info" Height="40px" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                                        &nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" Height="40px" OnClick="bttnCancelarCorreo_Click" Text="Salir" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function Alumnos() {
            $('#<%= grvAlumnos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvAlumnos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "order": [[1, "desc"]]
            });
        };
    </script>
</asp:Content>
