<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPagosPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmPagosPosgrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Escuela
            </div>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLEscuelas" runat="server" Width="100%"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Ficha/Matricula
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtMatricula" runat="server" Width="100%"></asp:TextBox>
            </div>

            <div class="col-md-2">
                <asp:UpdatePanel ID="updPnlBttnPagos" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkBttnPagos" runat="server" CssClass="btn btn-primary" OnClick="linkBttnPagos_Click">Buscar</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrBttnPagos" runat="server" AssociatedUpdatePanelID="updPnlBttnPagos">
                    <ProgressTemplate>
                        <asp:Image ID="imgPagos" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-2">
                Carreras
            </div>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLCarreras" runat="server" Width="100%" OnSelectedIndexChanged="DDLCarreras_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="00000">--TODOS--</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdPagos" runat="server" AutoGenerateColumns="False" CssClass="mGrid table  table-striped" Width="100%" OnRowEditing="grdPagos_RowEditing" OnRowUpdating="grdPagos_RowUpdating" OnRowCancelingEdit="grdPagos_RowCancelingEdit" OnSelectedIndexChanged="grdPagos_SelectedIndexChanged" EmptyDataText="No hay pagos registrados.">
                            <Columns>
                                <asp:BoundField DataField="IdRef" ReadOnly="True" >
                                    <ControlStyle CssClass="classHide" />
                                    <FooterStyle CssClass="classHide" />
                                    <HeaderStyle CssClass="classHide" />
                                    <ItemStyle CssClass="classHide" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ciclo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCiclo" runat="server" Text='<%# Bind("ciclo_actual") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCiclo" runat="server" Text='<%# Bind("ciclo_actual") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Semestre">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSemestre" runat="server" Text='<%# Bind("semestre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSemestre" runat="server" Text='<%# Bind("semestre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="concepto" HeaderText="Concepto" ReadOnly="True" />
                                <asp:TemplateField HeaderText="# Pago">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNoPago" runat="server" Text='<%# Bind("No_Pago") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoPago" runat="server" Text='<%# Bind("No_Pago") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Importe" HeaderText="Importe" ReadOnly="True" />
                                <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                                <asp:BoundField DataField="Fecha_Pago" HeaderText="Fecha de Pago" ReadOnly="True" />
                                <asp:TemplateField ShowHeader="False">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="linkBttnConcPagos" runat="server" CssClass="btn btn-grey" OnClick="linkBttnConcPagos_Click">Concentrado de Pagos</asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Ver Recibo"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="IdPago" ReadOnly="True">
                                      <ControlStyle CssClass="classHide" />
                                    <FooterStyle CssClass="classHide" />
                                    <HeaderStyle CssClass="classHide" />
                                    <ItemStyle CssClass="classHide" />
                                    </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Pagos() {
            $('#<%= grdPagos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdPagos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "order": [[1, "desc"]]
            });
        };

        function PagosUsuNormal() {
            $('#<%= grdPagos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdPagos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false,
                "order": [[1, "desc"]],
                "columns": [
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                ]
            });
        };
    </script>
</asp:Content>
