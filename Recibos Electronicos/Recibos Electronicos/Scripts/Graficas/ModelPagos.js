var graficasContext = {

    listDatosPagados: [],
    ciclos: [],
    escuelas: [],
    ObtenerDatosGraficaPagados: function (Dependencia, Ciclo_Escolar, Tipo, callBackResult) {
        var self = this;
        self.listDatosPagados.length = 0;
        $.ajax({
            type: "GET",
            cache: false,
            url: "https://sysweb.unach.mx/ApiSysweb/api/Ingresos/PagosBanco",
            success: function (resp) {
                if (resp.error === false) {
                    for (var i = 0; i < resp.resultado.length; i++) {
                        self.listDatosPagados.push({
                            Dato1: resp.resultado[i].dato1, Dato2: resp.resultado[i].dato2, Dato3: resp.resultado[i].dato3
                        });
                    }
                    callBackResult({ ressult: 'tgp' });
                }
                else {
                    $("#loading").hide();
                    callBackResult({ ressult: 'notgp', message: resp });
                }
            },
            error: function (ex) {
                if (callBackResult !== undefined) {
                    callBackResult({ ressult: 'notgp', message: ex.statusText });
                }
            }
        });
    },
    ObtenerDatosGraficaporAnio: function (callBackResult) {
        var self = this;
        self.listDatosPagados.length = 0;
        $.ajax({
            type: "GET",
            cache: false,
            url: "https://sysweb.unach.mx/ApiSysweb/api/Ingresos/PagosporEjercicio",
            success: function (resp) {
                if (resp.error === false) {
                    for (var i = 0; i < resp.resultado.length; i++) {
                        self.listDatosPagados.push({
                            Dato1: resp.resultado[i].dato1, Dato2: resp.resultado[i].dato2, Dato3: resp.resultado[i].dato3
                        });
                    }
                    callBackResult({ ressult: 'tgp' });
                }
                else {
                    $("#loading").hide();
                    callBackResult({ ressult: 'notgp', message: resp });
                }
            },
            error: function (ex) {
                if (callBackResult !== undefined) {
                    callBackResult({ ressult: 'notgp', message: ex.statusText });
                }
            }
        });
    },
};