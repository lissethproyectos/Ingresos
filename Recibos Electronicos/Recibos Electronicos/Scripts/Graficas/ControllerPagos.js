var root = am5.Root.new("chartdiv");
var Total = 0;
var ImporteTotal = 0;
function Grafica1() {
    $("#precarga").show();
    graficasContext.ObtenerDatosGraficaPagados("00000", "20221", "F", function (resp) {
        Total = 0;
        ImporteTotal = 0;
        switch (resp.ressult) {
            case "tgp":
                self.listDatosPagados = graficasContext.listDatosPagados;
                am5.ready(function () {
                    root.container.children.clear();
                    // Create root element
                    // https://www.amcharts.com/docs/v5/getting-started/#Root_element
                    //var root = am5.Root.new("chartdiv");
                    var data1;

                    // Set themes
                    // https://www.amcharts.com/docs/v5/concepts/themes/
                    root.setThemes([am5themes_Animated.new(root)]);


                    // Create chart
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/
                    var chart = root.container.children.push(
                        am5xy.XYChart.new(root, {
                            panX: false,
                            panY: false,
                            wheelX: "none",
                            wheelY: "none"
                        })
                    );


                    // Create axes
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
                    var yRenderer = am5xy.AxisRendererY.new(root, { minGridDistance: 30 });

                    var yAxis = chart.yAxes.push(
                        am5xy.CategoryAxis.new(root, {
                            maxDeviation: 0,
                            categoryField: "category",
                            renderer: yRenderer
                        })
                    );

                    var xAxis = chart.xAxes.push(
                        am5xy.ValueAxis.new(root, {
                            maxDeviation: 0,
                            min: 0,
                            renderer: am5xy.AxisRendererX.new(root, {})
                        })
                    );


                    // Create series
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
                    var series = chart.series.push(
                        am5xy.ColumnSeries.new(root, {
                            name: "Series 1",
                            xAxis: xAxis,
                            yAxis: yAxis,
                            valueXField: "value",
                            sequencedInterpolation: true,
                            categoryYField: "category",
                            tooltip: am5.Tooltip.new(root, {
                                pointerOrientation: "horizontal",
                                //labelText: "[bold]{value2}[/]\n{categoryY}: {valueX}"
                                labelText: "[bold]{categoryY}[/]\nNúmero Pagos:{valueX}[/]\nTotal: {value2}"
                            })
                        })
                    );

                    var columnTemplate = series.columns.template;

                    columnTemplate.setAll({
                        draggable: true,
                        cursorOverStyle: "pointer",
                        tooltipText: "{value}",
                        cornerRadiusBR: 10,
                        cornerRadiusTR: 10
                    });

                    series.bullets.push(function () {
                        return am5.Bullet.new(root, {
                            locationX: 1,
                            locationY: 0.5,
                            sprite: am5.Label.new(root, {
                                centerY: am5.p50,
                                text: "{valueX}",
                                populateText: true
                            })
                        });
                    });

                    columnTemplate.adapters.add("fill", (fill, target) => {
                        return chart.get("colors").getIndex(series.columns.indexOf(target));
                    });

                    columnTemplate.adapters.add("stroke", (stroke, target) => {
                        return chart.get("colors").getIndex(series.columns.indexOf(target));
                    });

                    columnTemplate.events.on("dragstop", () => {
                        sortCategoryAxis();
                    });

                    // Get series item by category
                    function getSeriesItem(category) {
                        for (var i = 0; i < series.dataItems.length; i++) {
                            var dataItem = series.dataItems[i];
                            if (dataItem.get("categoryY") === category) {
                                return dataItem;
                            }
                        }
                    }


                    // Axis sorting
                    function sortCategoryAxis() {
                        // Sort by value
                        series.dataItems.sort(function (x, y) {
                            return y.get("graphics").y() - x.get("graphics").y();
                        });

                        var easing = am5.ease.out(am5.ease.cubic);

                        // Go through each axis item
                        am5.array.each(yAxis.dataItems, function (dataItem) {
                            // get corresponding series item
                            var seriesDataItem = getSeriesItem(dataItem.get("category"));

                            if (seriesDataItem) {
                                // get index of series data item
                                var index = series.dataItems.indexOf(seriesDataItem);

                                var column = seriesDataItem.get("graphics");

                                // position after sorting
                                var fy =
                                    yRenderer.positionToCoordinate(yAxis.indexToPosition(index)) -
                                    column.height() / 2;

                                // set index to be the same as series data item index
                                if (index != dataItem.get("index")) {
                                    dataItem.set("index", index);

                                    // current position
                                    var x = column.x();
                                    var y = column.y();

                                    column.set("dy", -(fy - y));
                                    column.set("dx", x);

                                    column.animate({ key: "dy", to: 0, duration: 600, easing: easing });
                                    column.animate({ key: "dx", to: 0, duration: 600, easing: easing });
                                } else {
                                    column.animate({ key: "y", to: fy, duration: 600, easing: easing });
                                    column.animate({ key: "x", to: 0, duration: 600, easing: easing });
                                }
                            }
                        });

                        // Sort axis items by index.
                        // This changes the order instantly, but as dx and dy is set and animated,
                        // they keep in the same places and then animate to true positions.
                        yAxis.dataItems.sort(function (x, y) {
                            return x.get("index") - y.get("index");
                        });
                    }

                    var data = [];
                    for (var x = 0; x < self.listDatosPagados.length; x++) {
                        Total = Total + parseFloat(self.listDatosPagados[x].Dato3);
                        ImporteTotal = ImporteTotal + parseFloat(self.listDatosPagados[x].Dato2);
                        data.push({
                            "category": self.listDatosPagados[x].Dato1,
                            "value": parseFloat(self.listDatosPagados[x].Dato3),
                            "value2": parseFloat(self.listDatosPagados[x].Dato2)
                        });
                    }

                    yAxis.data.setAll(data);
                    series.data.setAll(data);


                    // Make stuff animate on load
                    // https://www.amcharts.com/docs/v5/concepts/animations/
                    series.appear(1000);
                    chart.appear(1000, 100);

                }); // end am5.ready()

                document.getElementById("ctl00_MainContent_lblNivel").innerHTML = "PAGOS: " + Total;
                document.getElementById("ctl00_MainContent_lblNive2").innerHTML = "TOTAL: " + ImporteTotal.toLocaleString('es-MX');

                $("#precarga").hide();
                break;
            case "notgp":
                document.getElementById("ctl00_MainContent_lblNivel").innerHTML = "Error al recuperar los datos, intentar más tarde."
                $("#precarga").hide();
                break;
            default:
                break;
        }
    });
};

function Grafica2() {
    $("#precarga").show();
    graficasContext.ObtenerDatosGraficaporAnio(function (resp) {
        Total = 0;
        ImporteTotal = 0;

        switch (resp.ressult) {
            case "tgp":
                self.listDatosPagados = graficasContext.listDatosPagados;
                am5.ready(function () {
                    root.container.children.clear();

                    // Create root element
                    // https://www.amcharts.com/docs/v5/getting-started/#Root_element
                    //var root = am5.Root.new("chartdiv");


                    // Set themes
                    // https://www.amcharts.com/docs/v5/concepts/themes/
                    root.setThemes([
                        am5themes_Animated.new(root)
                    ]);


                    // Create chart
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/
                    var chart2 = root.container.children.push(am5xy.XYChart.new(root, {
                        panX: true,
                        panY: true,
                        wheelX: "panX",
                        wheelY: "zoomX",
                        pinchZoomX: true
                    }));

                    // Add cursor
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/cursor/
                    var cursor = chart2.set("cursor", am5xy.XYCursor.new(root, {}));
                    cursor.lineY.set("visible", false);


                    // Create axes
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/axes/
                    var xRenderer = am5xy.AxisRendererX.new(root, { minGridDistance: 30 });
                    xRenderer.labels.template.setAll({
                        rotation: -90,
                        centerY: am5.p50,
                        centerX: am5.p100,
                        paddingRight: 15
                    });

                    var xAxis = chart2.xAxes.push(am5xy.CategoryAxis.new(root, {
                        maxDeviation: 0.3,
                        categoryField: "category",
                        renderer: xRenderer,
                        tooltip: am5.Tooltip.new(root, {})
                    }));

                    var yAxis = chart2.yAxes.push(am5xy.ValueAxis.new(root, {
                        maxDeviation: 0.3,
                        renderer: am5xy.AxisRendererY.new(root, {})
                    }));


                    // Create series
                    // https://www.amcharts.com/docs/v5/charts/xy-chart/series/
                    var series = chart2.series.push(am5xy.ColumnSeries.new(root, {
                        name: "Series 1",
                        xAxis: xAxis,
                        yAxis: yAxis,
                        valueYField: "value",
                        sequencedInterpolation: true,
                        categoryXField: "category",
                        tooltip: am5.Tooltip.new(root, {
                            labelText: "[bold]{category}[/]\nTot Pagos:{value}[/]\nTotal: {value2}"
                        })
                    }));

                    series.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5 });
                    series.columns.template.adapters.add("fill", function (fill, target) {
                        return chart2.get("colors").getIndex(series.columns.indexOf(target));
                    });

                    series.columns.template.adapters.add("stroke", function (stroke, target) {
                        return chart2.get("colors").getIndex(series.columns.indexOf(target));
                    });


                    // Set data
                    var data = [];


                    for (var x = 0; x < self.listDatosPagados.length; x++) {
                        Total = Total + parseFloat(self.listDatosPagados[x].Dato3);
                        ImporteTotal = ImporteTotal + parseFloat(self.listDatosPagados[x].Dato2);
                        data.push({
                            "category": self.listDatosPagados[x].Dato1,
                            "value": parseFloat(self.listDatosPagados[x].Dato2),
                            "value2": parseFloat(self.listDatosPagados[x].Dato3)
                        });
                    };

                    xAxis.data.setAll(data);
                    series.data.setAll(data);


                    // Make stuff animate on load
                    // https://www.amcharts.com/docs/v5/concepts/animations/
                    series.appear(1000);
                    chart2.appear(1000, 100);

                }); // end am5.ready()
                document.getElementById("ctl00_MainContent_lblNivel").innerHTML = "PAGOS: " + Total;
                document.getElementById("ctl00_MainContent_lblNive2").innerHTML = "TOTAL: " + ImporteTotal.toLocaleString('es-MX');

                $("#precarga").hide();
                break;
            case "notgp":
                document.getElementById("ctl00_MainContent_lblNivel").innerHTML = "Error al recuperar los datos, intentar más tarde."
                $("#precarga").hide();
                break;
            default:
                break;
        }
    });
}
