<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVigenciasExcepciones.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmVigenciasExcepciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">Dependencia</div>
            <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencia" runat="server" ClientIDMode="Predictable" CssClass="form-control">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <hr />
        <%--<div class="row">
            <div class="col-md-2">Conceptos</div>            
            <div class="col-md-4">
                <asp:DropDownList ID="ddlConceptoFilt" runat="server" CssClass="form-control"  onChange="cboCatCog();">
                    <asp:ListItem Value="00">--TODOS--</asp:ListItem>
                                            <asp:ListItem Value="L0201">L0201-INSCRIPCION</asp:ListItem>
                                            <asp:ListItem Value="L0202">L0202-INSCRIPCION EXTEMPORANEA</asp:ListItem>
                                            <asp:ListItem Value="L0203">L0203-REINSCRIPCION</asp:ListItem>
                                            <asp:ListItem Value="L0204">L0204-REINSCRIPCION EXTEMPORANEA</asp:ListItem>
                                        </asp:DropDownList>
                </div>
            </div>--%>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdVigencias" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowCancelingEdit="grdVigencias_RowCancelingEdit" OnRowEditing="grdVigencias_RowEditing" OnRowUpdating="grdVigencias_RowUpdating" OnSelectedIndexChanged="grdVigencias_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Dependencia" HeaderText="DEPENDENCIA" ReadOnly="True" />
                                <asp:BoundField DataField="Carrera" HeaderText="CARRERA" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="FECHA INICIAL">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtFechaIniAct" runat="server" Text='<%# Bind("FechaInicial") %>' type="date"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaIniAct" runat="server" Text='<%# Bind("FechaInicial") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FECHA FINAL">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FechaFinal") %>' type="date"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FechaFinal") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveConcepto" HeaderText="CVE" ReadOnly="True" />
                                <asp:TemplateField HeaderText="CONCEPTO">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlConceptoEdit" runat="server" CssClass="form-control" SelectedValue='<%# Eval("ClaveConcepto") %>'>
                                            <asp:ListItem Value="L0201">L0201-INSCRIPCION</asp:ListItem>
                                            <asp:ListItem Value="L0202">L0202-INSCRIPCION EXTEMPORANEA</asp:ListItem>
                                            <asp:ListItem Value="L0203">L0203-REINSCRIPCION</asp:ListItem>
                                            <asp:ListItem>L0204-REINSCRIPCION EXTEMPORANEA</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Observaciones") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle BackColor="#FFFF66" Font-Bold="True" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="linkBttnActualizar" runat="server" CausesValidation="False" CommandName="Update" CssClass="btn btn-mdb-color">Actualizar</asp:LinkButton>
                                        <asp:LinkButton ID="linkBttnCancelar" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="btn btn-mdb-color">Cancelar</asp:LinkButton>

                                        <%--                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update" Text="ACTUALIZAR" />
                                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="CANCELAR" />--%>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnEditar" runat="server" CausesValidation="False" CommandName="Edit" CssClass="btn btn-mdb-color">Editar</asp:LinkButton>
                                        <%--<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/Imagenes/edit.png" Text="EDITAR" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBttnEliminar" runat="server" CausesValidation="False" CommandName="Select" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID">
                                    <ControlStyle CssClass="classHide" />
                                    <FooterStyle CssClass="classHide" />
                                    <HeaderStyle CssClass="classHide" />
                                    <ItemStyle CssClass="classHide" />
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
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalVigencias">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Agregar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblDependenciaA" runat="server" Text="Dependencia"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependenciaA" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependenciaA_SelectedIndexChanged" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlCarrera" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Concepto</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:DropDownList ID="ddlConcepto" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="L0201">L0201-INSCRIPCION</asp:ListItem>
                                    <asp:ListItem Value="L0202">L0202-INSCRIPCION EXTEMPORANEA</asp:ListItem>
                                    <asp:ListItem Value="L0203">L0203-REINSCRIPCION</asp:ListItem>
                                    <asp:ListItem>L0204-REINSCRIPCION EXTEMPORANEA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                Fecha Inicial
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtFechaInicial" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFechaInicial" PopupButtonID="imgCalendarioIni" BehaviorID="_content_CalendarExtenderIni" />
                                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                Fecha Final
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFinal" BehaviorID="_content_CalendarExtenderFin" />
                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="container">
                        <div class="row alert alert-danger">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlErrorGuardar" runat="server">
                                    <ContentTemplate>
                                        <asp:Label runat="server" Text="" ID="lblErrorGuardar"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="updPnlGuardar" runat="server">
                                    <ContentTemplate>
                                        <button type="button" class="btn btn-blue-grey" data-dismiss="modal">Salir</button>
                                        &nbsp;<asp:Button ID="bttnAgregar" runat="server" CssClass="btn btn-primary" OnClick="bttnAgregar_Click" Text="Guardar" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalEliminar">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"><i class="fa fa-trash  fa-2x" aria-hidden="true"></i> Eliminar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <br />
                    
                </div>
                <div class="modal-body">
                    <p>¿Desea eliminar este registro?</p>
                    <p>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrorElim" runat="server" Text=""></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-blue-grey" data-dismiss="modal">Cerrar</button>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="linkBttnEliminarReg" runat="server" CssClass="btn btn-danger" OnClick="linkBttnEliminarReg_Click">Eliminar</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Vigencias() {
            $('#<%= grdVigencias.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdVigencias.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };
        function cboCatCog() {
               <%-- var table = $('#<%= grdCatCOG.ClientID %>').DataTable();
                var selectedValue = $('#<%= ddlMayor.ClientID %>').val();
                table.search(selectedValue).draw();--%>




           <%-- if (selectedValue != "00") {
                var table = $('#<%= grdVigencias.ClientID %>').DataTable();
                var selectedValue = $('#<%= ddlConceptoFilt.ClientID %>').val();
                table.columns(4).search(selectedValue).draw();
            }
            else {
                $('#<%= grdVigencias.ClientID %>').DataTable().columns(4).search("").draw();
            }--%>

        };
        //$(document).ready(function () {
        //    $('.delete_employee').click(function (e) {
        //        e.preventDefault();
        //        var empid = $(this).attr('data-emp-id');
        //        var parent = $(this).parent("td").parent("tr");
        //        bootbox.dialog({
        //            message: "Estas seguro que quieres borrarlo ?",
        //            title: "<i class='glyphicon glyphicon-trash'></i> Borrar !",
        //            buttons: {
        //                success: {
        //                    label: "No",
        //                    className: "btn-success",
        //                    callback: function () {
        //                        $('.bootbox').modal('hide');
        //                    }
        //                },
        //                danger: {
        //                    label: "Borrar!",
        //                    className: "btn-danger",
        //                    callback: function () {
        //                        $.ajax({
        //                            type: 'POST',
        //                            url: 'deleteRecords.php',
        //                            data: 'empid=' + empid
        //                        })
        //                            .done(function (response) {
        //                                bootbox.alert(response);
        //                                parent.fadeOut('slow');
        //                            })
        //                            .fail(function () {
        //                                bootbox.alert('Error....');
        //                            })
        //                    }
        //                }
        //            }
        //        });
        //    });
        //});
    </script>
</asp:Content>
