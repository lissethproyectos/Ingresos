/// <reference path="QRModel.js"/>

this.ObtenerQR = function (vIdFact, vIdQR) {
var isIE = /*@cc_on!@*/false || !!document.documentMode;    

    if (isIE === true || vIdQR === 0 || /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) )
    {
         var ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + vIdFact;
         window.open(ruta, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');
    }
    else
    {
        $('#precarga1').html('<div class="loading"><img src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" alt="loading"  height="42" width="42"/><br/>Un momento, por favor...</div>');
        QRContext.InfQR(vIdQR, function (resp) {
            switch (resp.ressult) {
                case "tgp":
                    var Imagen = QRContext.listaInfQR[0].Imagen;
                    $("#ctl00_MainContent_hddnImagenQR").val(Imagen);
                    var xhr = new XMLHttpRequest();
                    var ruta = "https://sysweb.unach.mx/SIVALE/Administrador/RepComprobanteFiscal_Qr";
                    xhr.responseType = "blob";
                    xhr.open("POST", ruta, true);
                    xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                    xhr.onreadystatechange = function () {//Call a function when the state changes.
                        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                            var blob = new Blob([this.response], { type: "application/pdf" });
                            link = document.createElement('a');
                            link.href = window.URL.createObjectURL(blob);
                            window.open(link, "miniContenedor", "toolbar=yes", "location=no", "menubar=yes", "resizable=yes");
                            $('#precarga1').html('');
                        }
                    };
                    xhr.send("IdFact=" + vIdFact + "&Fichero=" + Imagen);
                    

                    break;
                case "notgp":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP099&idFact=" + vIdFact;
                    window.open(ruta, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');
                    break;
                default:
                    break;
            }

        });

    }
};
