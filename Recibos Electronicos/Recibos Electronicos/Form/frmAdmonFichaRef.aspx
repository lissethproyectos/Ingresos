<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmonFichaRef.aspx.cs" Inherits="Recibos_Electronicos.Form.frmAdmonFichaRef" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">  
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 8.333333%;
            flex: 0 0 8.333333%;
            max-width: 8.333333%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">        
        <div class="row">
            <div class="col alert alert-info">
                Busqueda de referencias generadas en la página SYSWEB o SIAE.
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                Referencia
            </div>
            <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReferencia" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtReferencia_TextChanged"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="bttnBuscar" runat="server" CssClass="btn btn-primary" Width="100%" OnClick="bttnBuscar_Click" Text="Ver Referencias" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="col-md-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReferencia" ErrorMessage="RequiredFieldValidator" ValidationGroup="Busca">*Requerido</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgr1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="img1" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrgBuscarDatos" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="imgBuscarDatos" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdFichasRef" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="FACT_NOTAS" HeaderText="ORIGEN" />
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="REFERENCIA">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_OBSERVACIONES" HeaderText="OBSERVACIONES">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_CAPTURA" HeaderText="SE GENERO">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="FACT_TOTAL" HeaderText="IMPORTE" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Right" />
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
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="row alert alert-danger" runat="server" id="divErrorTot" visible="false">
                    <div class="col">La consulta excede los 2000 registros, favor de realizar filtros para un correcto funcionamiento.</div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">       
        function Referencias() {
            //$('input[type=search]').val('');
            $('#<%= grdFichasRef.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdFichasRef.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true
            });
        };
    </script>
</asp:Content>
