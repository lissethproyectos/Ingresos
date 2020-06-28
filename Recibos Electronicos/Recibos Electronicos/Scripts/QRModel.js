var QRContext = {

    listaInfQR: [],
    InfQR: function (vId, callBackResult) {
        var self = this;
        self.listaInfQR.length = 0;

        $.ajax(
            {
                type: 'GET',
                cache: false,
                url: 'https://sysweb.unach.mx/SIVALE/Administrador/ObtenerImagenQr?id=' + vId, //urlServer + 'Viaticos/ListarTipoPersonal',
                //data: { vId },
                success: function (resp) {
                    for (var i = 0; i < resp.length; i++) {
                        self.listaInfQR.push({ Imagen: resp[i].CODIGO });
                    }
                    if (callBackResult != undefined) {
                        callBackResult({ ressult: 'tgp', message: null });
                    }
                },
                error: function (ex) {
                    if (callBackResult != undefined) {
                        callBackResult({ ressult: "notgp", message: "Ocurrio un error al obtener los datos en ObtenerImagenQr." });
                    }
                }
            });
    },
}