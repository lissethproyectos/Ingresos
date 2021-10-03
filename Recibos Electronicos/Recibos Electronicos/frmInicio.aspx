<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <script src="Scripts/Graficas/kpi.js"></script>
    <script type="text/javascript">
        graficasContext.ObtenerDatosGraficaPagados("00000", "20221", "F", function (resp) {
            var Total=0;
            switch (resp.ressult) {
                case "tgp":
                    self.listDatosPagados = graficasContext.listDatosPagados;
                    am4core.useTheme(am4themes_animated);
                    // Themes end

                    let chart = am4core.create("chartdiv", am4charts.PieChart3D);
                    chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

                    chart.legend = new am4charts.Legend();

                    for (var x = 0; x < self.listDatosPagados.length; x++) {
                        Total = Total + parseFloat(self.listDatosPagados[x].Dato3);
                        chart.data.push(
                            {
                                "Descripcion": self.listDatosPagados[x].Dato1,
                                "total": self.listDatosPagados[x].Dato3
                            },
                        );
                    }

                    var series = chart.series.push(new am4charts.PieSeries3D());
                    series.dataFields.value = "total";
                    series.dataFields.category = "Descripcion";
                    document.getElementById("ctl00_MainContent_lblNivel").innerHTML = Total+" PAGOS";
                    


                    break;
                case "notgp":
                    alert(resp.MENSAJE_ERROR);
                    break;
                default:
                    break;
            }
            $scope.$apply();
        });
    </script>
    <style type="text/css">
        .scroll_monitor {
            height: 450px;
            overflow: auto;
        }

         #chartdiv {
	width	: 100%;
	height	: 450px;
    }	
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <%--<div class="col-sm-2">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body">
                            <h5 style="color: #3c4044;"><i class="fa fa-sticky-note" aria-hidden="true"></i>Solicitudes de exenciones ó descuentos</h5>
                            
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <a href="Form/frmExentos.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>--%>
            <div class="col-sm-6">
                <div class="card">   
                     <%--<div class="card-footer text-muted">
                        <a href="Principal.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>--%>
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 320px">
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
            <div class="col-sm-6">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body">
                            <asp:Label ID="lblNivel" runat="server" Text="" CssClass="font-weight-bold" Font-Size="18px"></asp:Label>
                            <div id="chartdiv"></div>
                            <%--<asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdStatus_Carga_Bancos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" Visible="false">
                                        <Columns>
                                            <asp:BoundField DataField="Etiqueta" HeaderText="Banco">
                                                <ItemStyle Font-Bold="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EtiquetaDos" HeaderText="Fecha Pago" />
                                            <asp:BoundField DataField="EtiquetaCuatro" HeaderText="Total">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        

        <%--<div class="row"><div class="col text-right">
            <a href="Inicio.aspx" class="btn btn-primary btn-rounded" style="font-size:14px;">Comprobante Oficial</a>
                         </div></div>--%>
    </div>




    <script type="text/javascript" src="Scripts/jsQR2.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
