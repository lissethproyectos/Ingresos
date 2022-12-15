<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <%--<script src="Scripts/Graficas/kpi.js"></script>--%>


    <style type="text/css">
        /* .scroll_monitor {
            height: 450px;
            overflow: auto;
        }*/

        #chartdiv {
            width: 100%;
            height: 450px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-5">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 400px;">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblMsg_Observaciones" runat="server" Visible="False"></asp:Label>
                                    <asp:GridView ID="grvStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" Width="100%" CssClass="mGrid" EmptyDataText="Sin solicitudes"
                                        ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="Dependencia" HeaderText="Revisar Solicitudes">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalMatricula" HeaderText="Tot">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle Font-Bold="False" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpdatePanelGridMonitor" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdMonitor" runat="server" AllowPaging="True"
                                        AutoGenerateColumns="False" OnPageIndexChanging="grdMonitor_PageIndexChanging"
                                        Width="100%" PageSize="20" CssClass="mGrid" CellSpacing="1">
                                        <Columns>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Revisar Incidencias">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle Font-Bold="False" />
                                        <SelectedRowStyle CssClass="sel" />

                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="text-center">
                                <asp:UpdateProgress ID="updPnlCC" runat="server" AssociatedUpdatePanelID="UpdatePanelGridMonitor">
                                    <ProgressTemplate>
                                        <asp:Image ID="img5" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
            <div class="col-sm-7">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 400px;">
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:UpdatePanel ID="updPnlTipoRep" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlTipoRep" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlTipoRep_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Ingresos por Banco</asp:ListItem>
                                                <asp:ListItem Value="2">Ingresos por Mes</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-md-4 text-right">
                                    <asp:LinkButton ID="linkBttnVerRecibos" runat="server" CssClass="btn btn-warning" OnClick="linkBttnVerRecibos_Click"><i class="fa fa-file"></i> Ver Recibos</asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblNivel" runat="server" Text="" CssClass="font-weight-bold" Font-Size="16px"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblNive2" runat="server" Text="" CssClass="font-weight-bold" Font-Size="16px"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-center">
                                    <div id="precarga">
                                        <input type="image" class="center" src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="width: 50px; height: 50px" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div id="chartdiv"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript" src="Scripts/jsQR2.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
    <script type="text/javascript" src="https://cdn.amcharts.com/lib/5/index.js"></script>
    <script type="text/javascript" src="https://cdn.amcharts.com/lib/5/xy.js"></script>
    <script type="text/javascript" src="https://cdn.amcharts.com/lib/5/themes/Animated.js"></script>
    <script type="text/javascript" src="Scripts/Graficas/ControllerPagos.js"></script>
    <script type="text/javascript" src="Scripts/Graficas/ModelPagos.js"></script>
</asp:Content>
