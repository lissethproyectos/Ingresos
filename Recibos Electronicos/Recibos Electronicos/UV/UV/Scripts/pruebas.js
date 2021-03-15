this.Enviar = function (valor) {
    //alert(valor);
    dependenciaslst: [],

    $.ajax({
        url: '/DesarrolloTecnologico/ListarDatosDocenteAdmivo?Plaza=3529&TipoPersonal=D',
        type: 'POST',
        headers: { 'Authorization': 'eyJOeXAiOiJKV1QiLCJhbGciOiJIUzl1NiJ9' },
        success: function (resp) {
            for (var i = 0; i < resp.length; i++) {
                self.dependenciaslst.push({ identificador: resp[i].identificador, rol: resp[i].rol, nombre: resp[i].nombre, ap_paterno: resp[i].ap_paterno });
            }
        },
        failure: function (result) {
            alert('Error: ' + result);
        }
    });
}