<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmSincronizacion.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmSincronizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <style type="text/css">
        section {
            float: left;
            width: 100%;
            background: #43cea2; /* fallback for old browsers */
            background: -webkit-linear-gradient(to left, #185a9d, #43cea2); /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to left, #185a9d, #43cea2); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            padding: 30px 0;
        }

        .card {
            -moz-box-direction: normal;
            -moz-box-orient: vertical;
            background-color: #fff;
            border-radius: 0.25rem;
            display: flex;
            flex-direction: column;
            position: relative;
            margin-bottom: 1px;
            border: none;
        }

        .card-header:first-child {
            border-radius: 0;
        }

        .card-header {
            background-color: #f7f7f9;
            margin-bottom: 0;
            padding: 20px 1.25rem;
            border: none;
        }

            .card-header a i {
                float: left;
                font-size: 25px;
                padding: 5px 0;
                margin: 0 25px 0 0px;
                color: #195C9D;
            }

            .card-header i {
                float: right;
                font-size: 30px;
                width: 1%;
                margin-top: 8px;
                margin-right: 10px;
            }

            .card-header a {
                width: 97%;
                float: left;
                color: #565656;
            }

            .card-header p {
                margin: 0;
            }

            .card-header h3 {
                margin: 0 0 0px;
                font-size: 20px;
                font-family: 'Slabo 27px', serif;
                font-weight: bold;
                color: #3fc199;
            }

        .card-block {
            -moz-box-flex: 1;
            flex: 1 1 auto;
            padding: 20px;
            color: #232323;
            box-shadow: inset 0px 4px 5px rgba(0,0,0,0.1);
            border-top: 1px soild #000;
            border-radius: 0;
        }

        .panel-group {
            margin-bottom: 20px;
        }

            .panel-group .panel {
                margin-bottom: 0;
                border-radius: 4px;
            }

        .panel-default {
            border-color: #ddd;
        }

            .panel-default > .panel-heading {
                color: #333;
                background-color: #f5f5f5;
                border-color: #ddd;
            }


        .nav-tabs .nav-link {
            border: 1px solid #f8f9fa;
            border-top-left-radius: .25rem;
            border-top-right-radius: .25rem;
            font-size: 13px;
        }

        .nav-tabs li a {
            padding: 8px 40px;
            border: 1px solid #ededed;
            border-top: 2px solid #dfdfdf;
            border-right: 0px none;
            background: #65635d;
            color: #fff;
            border-radius: 0px;
            margin-right: 0px;
            /* border-color: #cdcdcd; */
            font-weight: bold;
            transition: all 0.3s ease-in 0s;
        }

        .lds-ring {
            display: inline-block;
            position: relative;
            width: 80px;
            height: 80px;
        }

            .lds-ring div {
                box-sizing: border-box;
                display: block;
                position: absolute;
                width: 64px;
                height: 64px;
                margin: 8px;
                border: 8px solid #fff;
                border-radius: 50%;
                animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
                border-color: #fff transparent transparent transparent;
            }

                .lds-ring div:nth-child(1) {
                    animation-delay: -0.45s;
                }

                .lds-ring div:nth-child(2) {
                    animation-delay: -0.3s;
                }

                .lds-ring div:nth-child(3) {
                    animation-delay: -0.15s;
                }

        @keyframes lds-ring {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="tab-pane" id="profile" role="tabpanel" aria-labelledby="home-profile">
            <div id="accordion" role="tablist" aria-multiselectable="true">
                <div class="card">
                    <div class="card-header" role="tab" id="headingOne">
                        <div class="mb-0">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="collapsed">
                                <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                <h3>Sincronización</h3>
                                <p>Se actualizara la información utilizada por SIAE.</p>
                            </a>
                            <i class="fa fa-angle-right" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div id="collapseOne" class="collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false" style="">
                        <div class="card-block">
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="updPnlSincroniza" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvRegistros" runat="server"
                                                AutoGenerateColumns="False"
                                                EmptyDataText="La matrícula no ha realizado pagos"
                                                OnSelectedIndexChanged="grvRegistros_SelectedIndexChanged" Width="100%" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Ingresos" HeaderText="Registros INGRESOS" />
                                                    <asp:BoundField DataField="Sauce" HeaderText="Registros SAUCE" />
                                                    <asp:BoundField DataField="PendienteSincronizar"
                                                        HeaderText="Pendientes de Sincronizar" />
                                                    <asp:BoundField DataField="UltimaActualizacion"
                                                        HeaderText="Ultima Actualización" />
                                                    <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True"
                                                        Visible="False" />
                                                    <asp:TemplateField HeaderText="Acción">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkSincronizar" runat="server"
                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TIPO") %>'
                                                                CommandName="Select" ForeColor="#333333" OnClick="linkSincronizar_Click"
                                                                OnClientClick="return confirm('Esta proceso puede tardar varios minutos, ¿desea continuar?');">Sincronizar</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField DataImageUrlField="status1"
                                                        DataImageUrlFormatString="~/Imagenes/imagen{0}.png">
                                                    </asp:ImageField>
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
                            <div class="row">
                                <div class="col">
                                    <asp:UpdateProgress ID="updPgrSincroniza" runat="server"
                                        AssociatedUpdatePanelID="updPnlSincroniza">
                                        <ProgressTemplate>
                                            <span>
                                                <img height="26" src="../Imagenes/load.gif" width="222" />
                                            </span><span class="loading">Sincronizacion en Proceso…
                                            </span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" role="tab" id="heading2">
                        <div class="mb-0">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" aria-expanded="false" aria-controls="collapse2" class="collapsed">
                                <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                <h3>Vistas Materializadas Inhabiles (Referencias)</h3>
                                <p>Se habilitaran las vistas.</p>
                            </a>
                            <i class="fa fa-angle-right" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div id="collapse2" class="collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false" style="">
                        <div class="card-block">
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="updPnlVistasMat" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvInhabiles" runat="server"
                                                AutoGenerateColumns="False"
                                                EmptyDataText="NO HAY VISTAS MATERIALIZAS INHABILES"
                                                Width="100%"
                                                CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField DataField="objeto" HeaderText="Objeto" />
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
                            <div class="row">
                                <div class="col">
                                    <asp:UpdateProgress ID="updPgrVistasMat" runat="server"
                                        AssociatedUpdatePanelID="updPnlVistasMat">
                                        <ProgressTemplate>
                                            <span>
                                                <img height="26" src="../Imagenes/load.gif" width="222" />
                                            </span><span class="loading">Sincronizacion en Proceso…
                                            </span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" role="tab" id="heading5">
                        <div class="mb-0">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse5" aria-expanded="false" aria-controls="collapse5" class="collapsed">
                                <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                <h3>Vistas Materializadas Inhabiles (Recibos)</h3>
                                <p>Se habilitaran las vistas.</p>
                            </a>
                            <i class="fa fa-angle-right" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div id="collapse5" class="collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false" style="">

                        <div class="card-block">
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grvInhabilesRecibos" runat="server"
                                                AutoGenerateColumns="False"
                                                EmptyDataText="NO HAY VISTAS MATERIALIZAS INHABILES"
                                                Width="100%"
                                                CssClass="mGrid" OnSelectedIndexChanged="grvInhabilesRecibos_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:BoundField DataField="objeto" HeaderText="Objeto" />
                                                    <asp:CommandField SelectText="Actualizar" ShowSelectButton="True">
                                                        <ItemStyle Width="10%" />
                                                    </asp:CommandField>
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
                            <div class="row">
                                <div class="col">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server"
                                        AssociatedUpdatePanelID="UpdatePanel2">
                                        <ProgressTemplate>
                                            <span>
                                                <img height="26" src="../Imagenes/load.gif" width="222" />
                                            </span><span class="loading">Sincronizacion en Proceso…
                                            </span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" role="tab" id="heading3">
                        <div class="mb-0">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" aria-expanded="false" aria-controls="collapse3" class="collapsed">
                                <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                <h3>Vistas Materializadas</h3>
                                <p>Se actualizaran las vistas.</p>
                            </a>
                            <i class="fa fa-angle-right" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div id="collapse3" class="collapse" role="tabpanel" aria-labelledby="heading3" aria-expanded="false" style="">
                        <div class="card-block">
                            <div class="row">
                                <div class="col">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="rgvVMaterializadas" runat="server"
                                                AutoGenerateColumns="False"
                                                EmptyDataText="La matrícula no ha realizado pagos"
                                                OnSelectedIndexChanged="rgvVMaterializadas_SelectedIndexChanged" Width="100%" CssClass="mGrid">
                                                <Columns>
                                                    <asp:BoundField DataField="name"
                                                        HeaderText="Nombre de la Vista Materializada" />
                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha Refresh" />
                                                    <asp:BoundField DataField="hora" HeaderText="Ultima Refrescada" />
                                                    <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True"
                                                        Visible="False" />
                                                    <asp:TemplateField HeaderText="Acción">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="refresh" runat="server" OnClick="refresh_Click">Refrescar</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ImageField DataImageUrlField="status"
                                                        DataImageUrlFormatString="~/Imagenes/imagen{0}.png" ReadOnly="True">
                                                    </asp:ImageField>
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
                            <div class="row">
                                <div class="col">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server"
                                        AssociatedUpdatePanelID="updPnlVistasMat">
                                        <ProgressTemplate>
                                            <span>
                                                <img height="26" src="../Imagenes/load.gif" width="222" />
                                            </span><span class="loading">Sincronizacion en Proceso…
                                            </span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">       
        function Sincronizacion() {
            //$('input[type=search]').val('');
            $('#<%= grvRegistros.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvRegistros.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function Inhabiles() {
            //$('input[type=search]').val('');
            $('#<%= grvInhabiles.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvInhabiles.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function InhabilesRecibos() {
            //$('input[type=search]').val('');
            $('#<%= grvInhabilesRecibos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvInhabilesRecibos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function Materializadas() {
            //$('input[type=search]').val('');
            $('#<%= rgvVMaterializadas.ClientID %>').prepend($("<thead></thead>").append($('#<%= rgvVMaterializadas.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };
    </script>
    <%-- &nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td align="center" colspan="3">
                            <br />
                            <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
                            <asp:MultiView ID="mltViewSauce" runat="server">
                                <asp:View ID="vwSincroniza" runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="left" valign="top">&nbsp;</td>
                                            <td class="style4">&nbsp;
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imgBttnConsulta_Mat" runat="server" ImageUrl="../Imagenes/btnConsultar_Mat.png"
                                                    OnClick="imgBttnConsulta_Mat_Click" Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" colspan="3" width="80%">&nbsp; &nbsp; &nbsp;
                                            <table align="center" width="100%">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <ajaxToolkit:TabContainer ID="TabContainerDatos" runat="server" ActiveTabIndex="1"
                                                            CssClass="ajax__myTab" Width="100%">
                                                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server">
                                                                <HeaderTemplate>
                                                                    SINCRONIZACIÓN
                                                                </HeaderTemplate>
                                                                <ContentTemplate>

                                                                    <table align="center" frame="border" width="100%">
                                                                        <tr>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="grvRegistros" runat="server" AllowPaging="True"
                                                                                            AutoGenerateColumns="False"
                                                                                            EmptyDataText="La matrícula no ha realizado pagos"
                                                                                            OnPageIndexChanging="grvRegistros_PageIndexChanging"
                                                                                            OnSelectedIndexChanged="grvRegistros_SelectedIndexChanged" Width="100%" CssClass="mGrid">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                                                                <asp:BoundField DataField="Ingresos" HeaderText="Registros INGRESOS" />
                                                                                                <asp:BoundField DataField="Sauce" HeaderText="Registros SAUCE" />
                                                                                                <asp:BoundField DataField="PendienteSincronizar"
                                                                                                    HeaderText="Pendientes de Sincronizar" />
                                                                                                <asp:BoundField DataField="UltimaActualizacion"
                                                                                                    HeaderText="Ultima Actualización" />
                                                                                                <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True"
                                                                                                    Visible="False" />
                                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="linkSincronizar" runat="server"
                                                                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TIPO") %>'
                                                                                                            CommandName="Select" ForeColor="#333333" OnClick="linkSincronizar_Click"
                                                                                                            OnClientClick="return confirm('Esta proceso puede tardar varios minutos, ¿desea continuar?');">Sincronizar</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:ImageField DataImageUrlField="status1"
                                                                                                    DataImageUrlFormatString="~/Imagenes/imagen{0}.png">
                                                                                                </asp:ImageField>
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                                                                    AssociatedUpdatePanelID="UpdatePanel1">
                                                                                    <ProgressTemplate>
                                                                                        <span>
                                                                                            <img height="26" src="../Imagenes/load.gif" width="222" />
                                                                                        </span><span class="loading">Sincronizacion en Proceso…
                                                                                        </span>
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </table>

                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
                                                                <HeaderTemplate>
                                                                    VISTAS MATERIALIZADAS INHABILES
                                                                </HeaderTemplate>
                                                                <ContentTemplate>

                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="style8">&#160;</td>
                                                                            <td class="style9">&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style8" colspan="3">
                                                                                <asp:GridView ID="grvInhabiles" runat="server" AllowPaging="True"
                                                                                    AutoGenerateColumns="False"
                                                                                    EmptyDataText="NO HAY VISTAS MATERIALIZAS INHABILES"
                                                                                    OnPageIndexChanging="grvRegistros_PageIndexChanging" Width="100%"
                                                                                    OnSelectedIndexChanged="rgv_SelectedIndexChanged" CssClass="mGrid">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="objeto" HeaderText="Objeto" />
                                                                                    </Columns>
                                                                                    <FooterStyle CssClass="enc" />
                                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle CssClass="sel" />
                                                                                    <HeaderStyle CssClass="enc" />
                                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style8">&#160;</td>
                                                                            <td class="style9">&#160;</td>
                                                                            <td style="text-align: right">
                                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Button ID="btnhabilitar" runat="server" CssClass="btn btn-blue-grey"
                                                                                            Text="HABILITAR" OnClick="btnhabilitar_Click" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server">
                                                                <HeaderTemplate>
                                                                    VISTAS MATERIALIZADAS
                                                                </HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="rgvVMaterializadas" runat="server" AllowPaging="True"
                                                                                            AutoGenerateColumns="False"
                                                                                            EmptyDataText="La matrícula no ha realizado pagos"
                                                                                            OnPageIndexChanging="rgvVMaterializadas_PageIndexChanging"
                                                                                            OnSelectedIndexChanged="rgvVMaterializadas_SelectedIndexChanged" Width="100%" CssClass="mGrid">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="name"
                                                                                                    HeaderText="Nombre de la Vista Materializada" />
                                                                                                <asp:BoundField DataField="fecha" HeaderText="Fecha Refresh" />
                                                                                                <asp:BoundField DataField="hora" HeaderText="Ultima Refrescada" />
                                                                                                <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True"
                                                                                                    Visible="False" />
                                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="refresh" runat="server" OnClick="refresh_Click">Refrescar</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:ImageField DataImageUrlField="status"
                                                                                                    DataImageUrlFormatString="~/Imagenes/imagen{0}.png" ReadOnly="True">
                                                                                                </asp:ImageField>
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                        </asp:GridView>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">&#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </table>

                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                        </ajaxToolkit:TabContainer>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                            </td>
                                        </tr>

                                    </table>
                                </asp:View>
                                <asp:View ID="vwConsulaMat" runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="style7">&nbsp;
                                            </td>
                                            <td class="style6">&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style7">
                                                <asp:Label ID="lblMatricula" runat="server" Text="Matricula:"></asp:Label>
                                            </td>
                                            <td align="left" class="style6">
                                                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style7">
                                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                            </td>
                                            <td align="left" class="style6">
                                                <asp:TextBox ID="txtNombre" runat="server" Width="400px" Enabled="False" ReadOnly="True"></asp:TextBox>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnConsultar" runat="server" CssClass="btn3" Text="CONSULTAR" OnClick="btnConsultar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style3" colspan="3">
                                                <asp:GridView ID="grvDatos_Grals" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="grvDatos_Grals_PageIndexChanging" CssClass="mGrid">
                                                    <Columns>
                                                        <asp:BoundField DataField="BaseDatos" HeaderText="Base Datos" />
                                                        <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                                        <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                        <asp:BoundField DataField="Status" HeaderText="Estatus" />
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                        <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                                                        <asp:BoundField DataField="Banco" HeaderText="Banco" />
                                                        <asp:BoundField DataField="Folio" HeaderText="Folio" />
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="style7">&nbsp;
                                            </td>
                                            <td class="style6">&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style7" colspan="3">
                                                <asp:Button ID="btnRegresar" runat="server" CssClass="btn3" Height="36px" Text="REGRESAR"
                                                    OnClick="btnRegresar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td class="style1">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td class="style1">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td class="style1">&nbsp;
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <asp:Image ID="Image1q" runat="server" Height="30px" ImageUrl="~/Imagenes/ajax_loader_gray_512.gif"
                    Width="30px" ImageAlign="Middle" />
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
</asp:Content>
