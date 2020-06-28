//Creado por: ISC. Melissa Alejandra Rodríguez González
//Correo: melissa.rodriguez@unach.mx"
function ShowValue(arg) {
    //alert(arg
    //var importes;
    //importes = document.getElementById('etiqueta_importes');
    //alert('pasa');
    //alert(navigator.appName);
    if (navigator.appName == 'Microsoft Internet Explorer') {
        document.getElementById("etiqueta_importes").innerHTML = arg;
    }
    else {
        document.getElementById('etiqueta_importes').textContent = arg;
    }
    
}
function OpenPage(url)
{
    //window.open(url, 'Contenedor','width=100%,height=100%'); //return false;
    window.frames[0].location = url;    
}

function Resaltar_On(GridView)
{
    if(GridView != null)
    {
       GridView.originalBgColor = GridView.style.backgroundColor;
       GridView.style.backgroundColor="#DBE7F6";
    }
}

function Resaltar_Off(GridView)
{
    if(GridView != null)
    {
        GridView.style.backgroundColor = GridView.originalBgColor;
    }
}

/*function VerReporte(Cdet,nivel,concepto,status)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CDet='+ Cdet +'&Nivel='+ nivel +'&Concepto='+ concepto + '&Status='+ status,'miniContenedor', 'toolbar=no', 'location=no', 'menubar=no');
  return false;
}
*/
function VerReporte_Proyectos(Id, Tipo, CveReporte, Ejercicio, Usuario, modal) {
    var modal1 = $find(modal);
    window.open('../Reportes/VisualizadorCrystal.aspx?IdProyecto=' + Id + '&Tipo=' + Tipo + '&CveReporte=' + CveReporte + '&Ejercicio=' + Ejercicio + '&Usuario=' + Usuario);
    location.href = '../Form/RepProyectos.aspx';    
    //modal1.hide();
    return false;   
}

function VerReporte(Id,Tipo,CveReporte,Ejercicio,Usuario)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?IdProyecto='+ Id +'&Tipo='+ Tipo+'&CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio+'&Usuario='+ Usuario);
  return false;
}
function VerReporteProyectos(Ejercicio,Id,CveReporte)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?Ejercicio='+ Ejercicio +'&IdProyecto='+ Id+'&CveReporte='+ CveReporte);
  return false;
}
function VerReporteAvance_Proyectos(Id,CveReporte)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?IdProyecto='+ Id+'&CveReporte='+ CveReporte);
  return false;
}
function VerReporteRelacionFacturas(IdMovimiento,CveReporte)
{
    //alert("asas");
  window.open('../Reportes/VisualizadorCrystal.aspx?IdMovimiento='+ IdMovimiento+'&CveReporte='+ CveReporte);
  return false;
}
function VerReporteRelacionChequesBMS(CveReporte,Ejercicio)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio);
  return false;
}
function prueba()
{
    alert("asas");
}
function VerReporteExportar(Opc,FInicial,FFinal)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CDet='+ Opc +'&FInicial='+ FInicial +'&FFinal='+ FFinal,'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes');
  return false;
}
function VerReporteSiga09(CveReporte,Anio,Quincena,TPersonal,Concepto)
{
    //alert(CveReporte+" - "+Anio+" - "+Quincena+" - "+TPersonal+" - "+Concepto);
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte +'&Anio='+ Anio+'&Quincena='+ Quincena+'&TPersonal='+ TPersonal+'&Concepto='+ Concepto,'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes');
  return false;
}
function VerReporteSiga09Folios(CveReporte,TipoPago,CP_Ini,CP_Fin,TipoFolios,TipoRep,NumNomina)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte +'&TipoPago='+ TipoPago+'&CP_Ini='+ CP_Ini+'&CP_Fin='+ CP_Fin +'&TipoFolios='+ TipoFolios + '&TipoRep' +TipoRep + '&NumNomina='+NumNomina,'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes');
  return false;
}

function VerReporteChequeoPoliza(CveReporte,IdMov,Cheque_o_Poliza,Impresora)
{
    if(Cheque_o_Poliza=="P")
    {
        window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte +'&IdMovimiento='+ IdMov+'&Cheque_o_Poliza='+ Cheque_o_Poliza);
    }
    else
    {
        window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte +'&IdMovimiento='+ IdMov+'&Cheque_o_Poliza='+ Cheque_o_Poliza+'&Impresora='+Impresora);
    }      
    return false;
}

function cerrar_pagina()
{
    window.top.close();
}

function VerReporteSaldosComprometidos(CveReporte,Ejercicio)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio);
  return false;
}

function VerReporteSaldosComprometidosDetalle(CveReporte,Ejercicio)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio);
  return false;
}
function VerReporteChequesUsuario(CveReporte,Ejercicio,Usuario)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio+'&Usuario='+ Usuario);
  return false;
}
function VerReporteCheques_del_BMS(CveReporte,Id)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&IdProyecto='+ Id);
  return false;
}
function VerReporteComprobaciones(CveReporte,Ejercicio,Programa,IdProyecto)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio+'&Programa='+Programa+'&IdProyecto='+IdProyecto);
  return false;
}

function VerBMS_x_Proyecto(CveReporte,Ejercicio,IdProyecto)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio+'&IdProyecto='+ IdProyecto);
  return false;
}

function VerReporteResumenOper(CveReporte,Ejercicio)
{
  window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte='+ CveReporte+'&Ejercicio='+ Ejercicio);
  return false;
}

function VerReporteObservaciones(CveReporte, Ejercicio, Usuario) {
    window.open('../Reportes/VisualizadorCrystal.aspx?CveReporte=' + CveReporte + '&Ejercicio=' + Ejercicio + '&Usuario=' + Usuario);
    return false;
}