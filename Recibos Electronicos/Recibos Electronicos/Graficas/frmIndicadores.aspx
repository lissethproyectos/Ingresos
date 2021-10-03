<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIndicadores.aspx.cs" Inherits="Recibos_Electronicos.Graficas.frmIndicadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style>
        #chartdiv {
	width	: 100%;
	height	: 500px;
    }	
    </style>
    <%--<script src="../amcharts/amcharts.js"></script>
    <script src="../amcharts/pie.js"></script>--%>
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <script src="../Scripts/Graficas/kpi.js"></script>
    <script type="text/javascript">
        graficasContext.ObtenerDatosGraficaPagados("00000", "20221", "F", function (resp) {
            switch (resp.ressult) {
                case "tgp":
                    self.listDatosPagados = graficasContext.listDatosPagados;
                    am4core.useTheme(am4themes_animated);
                    // Themes end

                    let chart = am4core.create("chartdiv", am4charts.PieChart3D);
                    chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

                    chart.legend = new am4charts.Legend();

                    for (var x = 0; x < self.listDatosPagados.length; x++) {
                        chart.data.push(
                            {
                                "Descripcion": self.listDatosPagados[x].Dato1,
                                "total": self.listDatosPagados[x].Dato2
                            },                           
                        );
                    }

                    var series = chart.series.push(new am4charts.PieSeries3D());
                    series.dataFields.value = "total";
                    series.dataFields.category = "Descripcion";

                    break;
                case "notgp":
                    alert(resp.MENSAJE_ERROR);
                    break;
                default:
                    break;
            }
            $scope.$apply();
        });
        //var chart = AmCharts.makeChart("chartdiv", {
        //    "type": "pie",
        //    "theme": "light",
        //    "dataProvider": [{
        //        "country": "Lithuania",
        //        "litres": 501.9
        //    }, {
        //        "country": "Czech Republic",
        //        "litres": 301.9
        //    }, {
        //        "country": "Ireland",
        //        "litres": 201.1
        //    }, {
        //        "country": "Germany",
        //        "litres": 165.8
        //    }, {
        //        "country": "Australia",
        //        "litres": 139.9
        //    }, {
        //        "country": "Austria",
        //        "litres": 128.3
        //    }, {
        //        "country": "UK",
        //        "litres": 99
        //    }, {
        //        "country": "Belgium",
        //        "litres": 60
        //    }, {
        //        "country": "The Netherlands",
        //        "litres": 50
        //    }],
        //    "alphaField": "alpha",
        //    "valueField": "litres",
        //    "titleField": "country",
        //    "balloon": {
        //        "fixedPosition": true
        //    }
        //});

        //document.getElementById("update").addEventListener('click', function () {
        //    var thresholdValue = +document.getElementById('percent').value;
        //    if (!thresholdValue) {
        //        chart.dataProvider.forEach(function (dataItem) {
        //            dataItem[chart.alphaField] = 1;
        //        })
        //    }
        //    else {
        //        chart.chartData.forEach(function (dataItem, idx) {
        //            if (dataItem.percents <= thresholdValue) {
        //                dataItem.dataContext[chart.alphaField] = 0;
        //                // or
        //                // chart.dataProvider[idx][chart.alphaField] = 0;
        //            }
        //            else {
        //                dataItem.dataContext[chart.alphaField] = 1;
        //            }
        //        })
        //    }
        //    chart.validateData();
        //});
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="chartdiv"></div>		
</asp:Content>
