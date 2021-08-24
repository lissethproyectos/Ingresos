<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFichaRef_Eventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmFichaRef_Eventos" %>

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
            <div class="col-md-4">
                <asp:UpdatePanel ID="updPnlDep" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2">
                Tipo de Evento
            </div>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="ddlDirigido" OnSelectedIndexChanged="ddlDirigido_SelectedIndexChanged" Width="100%">
                    <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                    <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                    <asp:ListItem Value="Z">Eventos Privados</asp:ListItem>
                    <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrg4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                    <ProgressTemplate>
                        <asp:Image ID="img4" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgDep" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No existen eventos para esta dependencia." Width="100%" OnPageIndexChanging="grdEventos_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Eventos" HeaderText="CVE." />
                                <asp:BoundField DataField="Dependencia" HeaderText="Dep.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_inicial" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Inicial">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_final" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Generar Referencia">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnEvento" runat="server" ImageUrl="~/Imagenes/referencia.PNG" OnClick="imgBttnEvento_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Ruta" />
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
        function Eventos() {
            $('#<%= grdEventos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdEventos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        }
    </script>
</asp:Content>
