using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.ReportSource;
using System.IO;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace Recibos_Electronicos.Reportes
{

    public partial class VisualizadorCrystal : System.Web.UI.Page
    {
        private ReportDocument report = new ReportDocument();
        private System.Web.UI.Page p;
        private CN_Comun CNComun = new CN_Comun();
        private string Reporte = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string Reporte =string.Empty;
            //object[] Vhttp://localhost:5141/Reportes/VisualizadorCrystal.aspx.csalores={};

            int idFact = Convert.ToInt32(Request.QueryString["idFact"]);
            string Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            string TipoDesc = Convert.ToString(Request.QueryString["TipoDesc"]);
            string UR = Convert.ToString(Request.QueryString["CDet"]);
            string Nivel = Convert.ToString(Request.QueryString["Nivel"]);
            string FechaIn = Convert.ToString(Request.QueryString["FInicial"]);
            string FechaFi = Convert.ToString(Request.QueryString["FFinal"]);
            string Conceptos = Convert.ToString(Request.QueryString["IdConcepto"]);
            string Ejercicio = Convert.ToString(Request.QueryString["Ejercicio"]);
            string Mes = Convert.ToString(Request.QueryString["Mes"]);
            string Evento = Convert.ToString(Request.QueryString["Evento"]);
            string ciclo = Convert.ToString(Request.QueryString["ciclo"]);
            string status = Convert.ToString(Request.QueryString["status"]);
            string dependencia = Convert.ToString(Request.QueryString["dependencia"]);
            string dependencia_fin = Convert.ToString(Request.QueryString["dependencia_fin"]);
            string enExcel = Convert.ToString(Request.QueryString["enExcel"]);
            string enGraficas = Convert.ToString(Request.QueryString["enGraficas"]);
            string MesFin = Convert.ToString(Request.QueryString["MesFin"]);
            string Usuario = Convert.ToString(Request.QueryString["Usuario"]);
            string TipoPersona = Convert.ToString(Request.QueryString["TipoPersona"]);
            string ciclo_ant = Convert.ToString(Request.QueryString["ciclo_ant"]);
            string Referencia = Convert.ToString(Request.QueryString["Referencia"]);
            string Observaciones = Convert.ToString(Request.QueryString["Observaciones"]);
            string ImgQR = Convert.ToString(Request.QueryString["imagenQR"]);
            double Total = Convert.ToInt32(Request.QueryString["Total"]);
            string IdCarrera = Convert.ToString(Request.QueryString["IdCarrera"]);
            string Matricula = Convert.ToString(Request.QueryString["Matricula"]);


            switch (Tipo)
            {                               
                case "REP001":
                    object[] v1 = { FechaIn, FechaFi, UR, Conceptos, Nivel };
                    if (enExcel == "N")
                    {
                        //Reporte = "Reportes\\RepIngresosFactura.rpt";
                        Reporte = "Reportes\\REP001.rpt";
                        rptPDF_FE(Reporte, v1, "Conceptos_por_Dependencia");
                    }
                    else
                    {
                        //Reporte = "Reportes\\RepIngresosFacturaExcel.rpt";
                        Reporte = "Reportes\\REP001Excel.rpt";
                        rptExcel_FE(Reporte, v1, "Conceptos_por_Dependencia");
                    }
                    //Reporte = "Reportes\\RepIngresosFactura.rpt";                                      
                    //rptPDF_FE(Reporte, v1, "Conceptos_por_Dependencia");
                    break;
                case "REP002":                                  
                    //object[] v2 = { FechaIn, FechaFi, UR, Conceptos };
                    object[] v2 = { FechaIn, FechaFi, UR, Conceptos, Nivel };
                    if (enExcel == "N")
                    {
                        //Reporte = "Reportes\\RepConcentradoFecha.rpt";
                        Reporte = "Reportes\\REP002.rpt";
                        rptPDF_FE(Reporte, v2, "Concentrado_por_Fecha");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP002Excel.rpt";
                        rptExcel_FE(Reporte, v2, "Concentrado_por_Fecha");
                    }
                    break;
                case "REP004":
                    object[] v30= { FechaIn, FechaFi, UR };
                    //if (UR == "00000")
                    //    Reporte = "Reportes\\RepAspirantes.rpt";
                    //else
                        Reporte = "Reportes\\REP004.rpt"; //"Reportes\\RepAspirantes_Escuelas.rpt";

                    rptExcel_FE(Reporte, v30, "Aspirantes del "+ FechaIn+" al "+ FechaFi);
                    break;
                case "REP005":
                    //Reporte = "Reportes\\RepReferenciasPagadas.rpt";
                    Reporte = "Reportes\\REP005.rpt";
                    //object[] v4 = { FechaIn, FechaFi, UR, Conceptos };
                    object[] v4 = { FechaIn, FechaFi, UR, Conceptos, Nivel };
                    rptExcel_FE(Reporte, v4, "RefPagadas");
                    break;
                case "REP006":
                    Reporte = "Reportes\\RepExtraordinarios.rpt";
                    object[] v7 = { FechaIn, FechaFi, UR };
                    rptPDF_FE(Reporte, v7, "Extraordinarios");
                    break;
                case "REP007":
                    if (UR == "00000")
                        Reporte = "Reportes\\rptIngresos_Mensuales.rpt";
                    else
                        Reporte = "Reportes\\rptIngresos_Mensuales_x_Dep.rpt";
                    rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, enExcel);
                    break;
                case "REP008":
                    if (enGraficas == "S")
                    {
                        Reporte = "Reportes\\REP008_G.rpt";
                        rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, "N");
                    }
                    else
                    {
                        if (UR == "00000")
                            Reporte = "Reportes\\rptIngresos_Acumulados.rpt";
                        else
                            Reporte = "Reportes\\rptIngresos_Acumulados_x_Dep.rpt";

                        rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, enExcel);
                    }   
                    break;
                case "REP009":
                    if (UR == "00000")
                        Reporte = "Reportes\\rptIngresos_Total.rpt";
                    else
                        Reporte = "Reportes\\rptIngresos_x_Dep.rpt";
                    
                    rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, enExcel);
                    break;
                case "REP019":
                    Reporte = "Reportes\\rptMultipagos_Gral.rpt";
                    object[] v15 = { FechaIn, FechaFi };
                    rptPDF_Ingresos(Reporte, v15, "Multipagos");
                    break;

                case "REP021":
                    Reporte = "Reportes\\rptEstadisticasExenciones.rpt";                    
                    object[] v3 = { Ejercicio };
                    rptPDF_Ingresos(Reporte, v3, "Estadisticas_de_Exenciones_Programadas");
                    break;
                case "REP022":
                    object[] v5 = { UR, FechaIn, FechaFi };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP022.rpt";
                        rptPDF_FE(Reporte, v5, "Ingresos_Propios_Reembolsables");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP022_Excel.rpt";
                        rptExcel_FE(Reporte, v5, "Ingresos_Propios_Reembolsables");
                    }
                    break;
                case "REP022-Carreras":
                    object[] v46 = { dependencia, FechaIn, FechaFi };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP022_por_Carreras.rpt";
                        rptPDF_FE(Reporte, v46, "Ingresos Propios Reembolsables");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP022_por_Carreras_Excel.rpt";
                        rptExcel_FE(Reporte, v46, "Ingresos Propios Reembolsables");
                    }
                    break;
                case "REP022-Nivel":
                    object[] v51 = { dependencia, FechaIn, FechaFi };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP022-Nivel.rpt";
                        rptPDF_FE(Reporte, v51, "Ingresos Propios Reembolsables");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP022-Nivel_Excel.rpt";
                        rptExcel_FE(Reporte, v51, "Ingresos Propios Reembolsables");
                    }
                    break;
                case "REP023":
                    Reporte = "Reportes\\REP023.rpt";
                    object[] v6 = {  };
                    rptPDF_FE(Reporte, v6, "Catalogo_de_Ingresos_Reembolsables");
                    break;
                case "REP024":
                    Reporte = "Reportes\\REP024-CatConceptos.rpt";
                    object[] v8 = { Nivel, status };
                    rptPDF_Ingresos(Reporte, v8, "Catalogo_de_conceptos");
                    break;
                case "REP025":
                    Reporte = "Reportes\\REP025-CatConceptos.rpt";
                    object[] v9 = { Nivel, status };
                    rptExcel_Ingresos(Reporte, v9, "Catalogo_de_conceptos");
                    break;
                case "REP026":
                    Reporte = "Reportes\\RepEventosConcept.rpt";
                    object[] v10 = { Evento, dependencia };
                    rptExcel_Ingresos(Reporte, v10, "Eventos y sus Conceptos");
                    break;
                case "REP027":
                    object[] v11 = { Evento, Usuario, dependencia, dependencia_fin };

                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\rptEventosParticipantes.rpt";
                        rptPDF_Ingresos(Reporte, v11, "Eventos y Participantes");

                    }
                    else
                    {
                        Reporte = "Reportes\\rptEventos_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v11, "Eventos");

                    }

                    break;
                case "REP028":
                    Reporte = "Reportes\\RepEventosConcept_Excel.rpt";
                    object[] v12 = { dependencia, dependencia_fin, Usuario };
                    rptExcel_Ingresos(Reporte, v12, "Eventos y sus Conceptos");
                    break;
                case "REP029":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos.rpt";
                    object[] v13 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptPDF_Ingresos(Reporte, v13, "Retenciones de Impuestos");
                    break;
                case "REP030":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos_Deps.rpt";
                    object[] v14 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptPDF_Ingresos(Reporte, v14, "Retenciones de Impuestos por Dependencias");
                    break;
                case "REP031":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos_Excel.rpt";
                    object[] v16 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptExcel_Ingresos(Reporte, v16, "Retenciones de Impuestos");
                    break;
                case "REP032":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos_Deps_Excel.rpt";
                    object[] v17 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptExcel_Ingresos(Reporte, v17, "Retenciones de Impuestos por Dependencias");
                    break;
                case "REP033":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos_x_Periodo.rpt";
                    object[] v18 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptPDF_Ingresos(Reporte, v18, "Retenciones de Impuestos por Periodo");
                    break;
                case "REP034":
                    Reporte = "Reportes\\RepRetenciones_Rendimientos_x_Periodo_Excel.rpt";
                    object[] v19 = { Usuario, dependencia, dependencia_fin, FechaIn, FechaFi };
                    rptExcel_Ingresos(Reporte, v19, "Retenciones de Impuestos por Periodo");
                    break;
                case "REP035":
                    object[] v20 = { FechaIn };

                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP035.rpt";
                        rptPDF_Ingresos(Reporte, v20, "Concentrado de Bancos");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP035_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v20, "Concentrado de Bancos");
                    }
                    break;
                case "REP037":
                    Reporte = "Reportes\\RepEventosDetalle.rpt";
                    object[] v22 = { };
                    rptPDF_Ingresos(Reporte, v22, "Eventos Detalle");
                    break;
                case "REP037_Excel":
                    Reporte = "Reportes\\RepEventosDetalle_Excel.rpt";
                    object[] v23 = { };
                    rptExcel_Ingresos(Reporte, v23, "Eventos Detalle");
                    break;
                case "REP038":
                    object[] v24 = { FechaIn, FechaFi, dependencia, Conceptos };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP038.rpt";
                        rptPDF_FE(Reporte, v24, "Eventos Conceptos_por_Dependencia");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP038Excel.rpt";
                        rptExcel_FE(Reporte, v24, "Conceptos_por_Dependencia");
                    }
                    break;
                case "REP039":
                    object[] v25 = { FechaIn, FechaFi, dependencia, Conceptos };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP039.rpt";
                        rptPDF_FE(Reporte, v25, "Eventos Conceptos_por_Dependencia");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP039Excel.rpt";
                        rptExcel_FE(Reporte, v25, "Conceptos_por_Dependencia");
                    }
                    break;
                case "REP040":
                    object[] v26 = { FechaIn, FechaFi, dependencia, Conceptos };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP040.rpt";
                        rptPDF_FE(Reporte, v26, "Concetrado_De_Exenciones");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP040Excel.rpt";
                        rptExcel_FE(Reporte, v26, "Concetrado_De_Exenciones");
                    }
                    break;

                case "REP041":
                    object[] v27 = { FechaIn, FechaFi, dependencia, Conceptos };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP041.rpt";
                        rptPDF_FE(Reporte, v27, "Detallado_Exenciones");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP041Excel.rpt";
                        rptExcel_FE(Reporte, v27, "Detallado_Exenciones");
                    }
                    break;
                case "REP042":
                    object[] v28 = { Nivel, dependencia };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP042.rpt";
                        rptPDF_Ingresos(Reporte, v28, "Catalogo_Carreras");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP042Excel.rpt";
                        rptExcel_Ingresos(Reporte, v28, "Catalogo_Carreras");
                    }
                    break;
                case "REP043":
                    object[] v29 = { TipoPersona, Nivel, ciclo };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP043.rpt";
                        rptPDF_Ingresos(Reporte, v29, "Catalogo_Alumnos");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP043Excel.rpt";
                        rptExcel_Ingresos(Reporte, v29, "Catalogo_Alumnos");
                    }
                    break;
                case "REP044":                   
                    if (enExcel == "N")
                    {
                        object[] v31 = { UR, FechaIn, FechaFi, Mes };
                        if (TipoDesc == "1")
                            Reporte = "Reportes\\REP044.rpt";
                        else
                            Reporte = "Reportes\\REP044-2.rpt";

                        rptPDF_Ingresos(Reporte, v31, "Retenciones por Dependencia");
                    }
                    else
                    {
                        if (TipoDesc == "1")
                        {
                            object[] v31 = { UR, FechaIn, FechaFi };
                            Reporte = "Reportes\\REP044Excel.rpt";
                            rptExcel_Ingresos(Reporte, v31, "Retenciones por Dependencia");
                        }
                        else
                        {
                            object[] v31 = { UR, FechaIn, FechaFi };
                            Reporte = "Reportes\\REP044Excel-2.rpt";
                            rptExcel_Ingresos(Reporte, v31, "Retenciones por Concepto");
                        }
                        //Reporte = "Reportes\\REP044Excel.rpt";                        
                    }
                    break;
                case "REP045":
                    object[] v32 = { dependencia, ciclo };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP045.rpt";
                        rptPDF_Ingresos(Reporte, v32, "Importes de Cursos de Verano");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP045Excel.rpt";
                        rptExcel_Ingresos(Reporte, v32, "Importes de Cursos de Verano");
                    }
                    break;
                case "REP046":
                    object[] v33 = { dependencia, ciclo };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP046.rpt";
                        rptPDF_FE(Reporte, v33, "Pagos de Cursos de Verano");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP046Excel.rpt";
                        rptExcel_FE(Reporte, v33, "Pagos de Cursos de Verano");
                    }
                    break;
                case "REP048":
                    object[] v34 = { FechaIn, FechaFi };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP048.rpt";
                        rptPDF_FE(Reporte, v34, "Concentrado de Conceptos");
                    }
                    else
                    {
                        Reporte = "Reportes\\REP048Excel.rpt";
                        rptExcel_FE(Reporte, v34, "Concentrado de Conceptos");
                    }
                    break;
                case "REP049":
                    Reporte = "Reportes\\rptArchivosCaja.rpt";
                    rptExcel_FE(Reporte, "Datos Bancos");                    
                    break;
                case "REP050":
                    object[] v35 = { idFact };
                    Reporte = "Reportes\\rptHistoricoRecibos.rpt";
                    rptPDF_FE(Reporte, v35, "Historico");
                    break;
                case "REP051":
                    object[] v36 = { ciclo, UR, status };
                    Reporte = "Reportes\\rptFichasAspirantes.rpt";
                    rptExcel_FE(Reporte, v36, "Fichas de Aspirantes-Ciclo "+ciclo);
                    break;
                case "REP052":
                    object[] v37 = { dependencia, Evento,  TipoDesc};
                    Reporte = "Reportes\\REP052.rpt";
                    rptPDF_FE(Reporte, v37, "Pagos del Evento " + TipoDesc);
                    break;
                case "REP053":
                    object[] v38 = { ciclo, ciclo_ant  };
                    Reporte = "Reportes\\REP053.rpt";
                    rptPDF_Ingresos(Reporte, v38, "Exenciones Automaticas");
                    break;
                case "REP054":
                    object[] v41 = { FechaIn, FechaFi, dependencia };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP054.rpt";
                        rptPDF_FE(Reporte, v41, "Concentrado de Conceptos por Dependencia");

                    }
                    else {
                        Reporte = "Reportes\\REP054_Excel.rpt";
                        rptExcel_FE(Reporte, v41, "Concentrado de Conceptos por Dependencia");
                    }
                    break;
                case "REP055":
                    
                    if (enExcel == "N")
                    {
                        object[] v42 = { Evento, Observaciones };
                        Reporte = "Reportes\\REP055.rpt";
                        rptPDF_FE(Reporte, v42, "Evento "+Evento);

                    }
                    else {
                        object[] v70 = { Evento };
                        Reporte = "Reportes\\REP055_Excel.rpt";
                        rptExcel_FE(Reporte, v70, "Evento " + Evento);
                    }
                    break;
                case "REP056":
                    object[] v43 = { Evento };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP056.rpt";
                        rptPDF_FE(Reporte, v43, "Examen de selección - ciclo " + ciclo);

                    }
                    else {
                        Reporte = "Reportes\\REP056_Excel.rpt";
                        rptExcel_FE(Reporte, v43, "Examen de selección - ciclo " + ciclo);
                    }
                    break;
                case "REP058":
                    object[] v44 = { dependencia, Observaciones };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP058.rpt";
                        rptPDF_Ingresos(Reporte, v44, "Catalogo de Productos/Servicios");

                    }
                    else {
                        Reporte = "Reportes\\REP058_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v44, "Catalogo de Productos/Servicios");
                    }
                    break;
                case "REP059":
                    object[] v45 = { dependencia, Nivel, ciclo };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP059.rpt";
                        rptPDF_Ingresos(Reporte, v45, "Catalogo de Aspirantes");

                    }
                    else {
                        Reporte = "Reportes\\REP059_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v45, "Catalogo de Aspirantes");
                    }
                    break;
                case "REP060":
                    object[] v47 = { dependencia, FechaIn, FechaFi };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP060.rpt";
                        rptPDF_Ingresos(Reporte, v47, "Pagos Semovientes");

                    }
                    else {
                        Reporte = "Reportes\\REP060_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v47, "Pagos Semovientes");
                    }
                    break;
                case "REP061":
                    object[] v48 = { Evento };
                    if (enExcel == "N")
                    {
                        Reporte = "Reportes\\REP061.rpt";
                        rptPDF_Ingresos(Reporte, v48, "Configuracion del evento " + Evento);

                    }
                    else {
                        Reporte = "Reportes\\REP061_Excel.rpt";
                        rptExcel_Ingresos(Reporte, v48, "Configuracion del evento "+ Evento);
                    }
                    break;
                case "REP062":
                    object[] v50 = { idFact };
                    Reporte = "Reportes\\REP062.rpt";
                    rptPDF_Ingresos(Reporte, v50, "Configuracion del descuento");
                    break;
                case "REP063":
                    object[] v63 = { Evento };
                    Reporte = "Reportes\\RepComprobanteFiscal-Lote.rpt";
                    rptPDF_FE(Reporte, v63, "Recibos del Evento "+Evento);
                    break;
                case "REP064":
                    Reporte = "Reportes\\REP064.rpt";
                    if (enExcel == "N")                    
                        rptPDF_Ingresos(Reporte, "Escuelas que cobran cuota de mantenimiento");
                    else
                        rptExcel_Ingresos(Reporte, "Escuelas que cobran cuota de mantenimiento");
                    break;
                case "REP067":
                    object[] v100 = { ciclo, TipoDesc, dependencia };
                    Reporte = "Reportes\\REP067.rpt";
                    if (enExcel == "N")                    
                        rptPDF_FE(Reporte, v100, "Faltan por Pagar");
                    else
                        rptExcel_FE(Reporte, v100, "Faltan por Pagar");
                    break;
                case "REP068":
                    object[] v101 = { dependencia, FechaIn, FechaFi, dependencia_fin };
                    Reporte = "Reportes\\REP068.rpt";
                        rptPDF_FE(Reporte, v101, "Facturados");
                    break;
                case "REP070":
                    object[] v102 = { dependencia };
                    Reporte = "Reportes\\REP070_Excel.rpt";
                    rptExcel_Ingresos(Reporte, v102, "Configuracion Evento");
                    break;
                case "REP071":
                    object[] v103 = { dependencia, FechaIn, FechaFi, Conceptos };
                    Reporte = "Reportes\\RepComprobanteFiscal-Lote-Conceptos.rpt";
                    rptPDF_FE(Reporte, v103, "Lote Recibos");
                    break;

                case "REP000":
                    object[] v39 = { TipoPersona, Referencia, Total, FechaIn, Conceptos, Observaciones };
                    Reporte = "Reportes\\Ficha_Referenciada.rpt";
                    rptPDF_Ingresos(Reporte, v39, "Ficha Referenciada");
                    break;
                case "REP000-1":
                    object[] v40 = { idFact };
                    Reporte = "Reportes\\Ficha_Referenciada_Productos.rpt";
                    rptPDF_Ingresos(Reporte, v40, "Ficha Referenciada");
                    break;
                case "REPSCE_001":
                    object[] vSCE1 = { Referencia };
                    Reporte = "Reportes\\RepComprobanteFiscal_Posgrado.rpt";
                    rptPDF_FE(Reporte, vSCE1, "Ficha Referenciada");
                    break;
                case "REPSCE_002":
                    object[] vSCE2 = { dependencia, Matricula, IdCarrera };
                    Reporte = "Reportes\\rpt_PagosPosgrado.rpt";
                    rptPDF_SIAE(Reporte, vSCE2, "Pagos de "+ Matricula);
                    break;
                case "REP099":
                    //bool Existe = System.IO.File.Exists("https://sysweb.unach.mx/SIVALE2/Qr/RECIBO2019100000B1005759.png");
                    //string fichero = "https://sysweb.unach.mx/SIVALE2/Qr/RECIBO2019100000B1005759.png";
                    //object[] v49 = { idFact, fichero };
                    //Reporte = "Reportes\\RepComprobanteFiscal_QR.rpt";
                    object[] v49 = { idFact };
                    Reporte = "Reportes\\RepComprobanteFiscal.rpt";
                    rptPDF_FE(Reporte, v49, "Ficha Referenciada");
                    break;

            }


                 
            if (Tipo == "REP010")
            {
                if (UR == "00000")
                    Reporte = "Reportes\\rptPareto_Total.rpt";
                else
                    Reporte = "Reportes\\rptPareto_x_Dep.rpt";
                rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, enExcel);
            }
            else if (Tipo == "REP011")
            {
                if (UR == "00000")
                    Reporte = "Reportes\\rptEstadistica_Total.rpt";
                else
                    Reporte = "Reportes\\rptEstadistica_x_Dep.rpt";
                rptIngresos(Reporte, Ejercicio, Mes, UR, Tipo, enExcel);
            }
            else if (Tipo == "REP012")
            {
                Reporte = "Reportes\\rptBitacora_Carga.rpt";
                rptIngresos(Reporte, Ejercicio, Mes, "00000", "REP007", enExcel);
            }
            else if (Tipo == "REP013")
            {                
                if (enExcel == "S")
                {
                    Reporte = "Reportes\\rptRecibos_Cancelados_Excel.rpt";
                    object[] Valores = { Ejercicio };
                    rptIngresosEnExcel(Reporte, Valores);
                }
                else
                {
                    Reporte = "Reportes\\rptRecibos_Cancelados.rpt";
                    rptIngresos(Reporte, Ejercicio, "0", "00000", Tipo, enExcel);
                }
            }
            else if (Tipo == "REP014")
            {
                Reporte = "Reportes\\rptRegistrosEventos_Excel.rpt";
                rptExcelEvento(Reporte, Evento);
            }
            else if (Tipo == "REP015")
            {
                Reporte = "Reportes\\rptEstadisticas_Descuentos.rpt";
                rptEstadisticas_Descuentos(Reporte, UR, ciclo);
            }
            else if (Tipo == "REP016")
            {
                Reporte = "Reportes\\rptDescuentos_x_Tipo.rpt";
                rptDescuentos_x_Tipo(Reporte, UR, ciclo, Conceptos, TipoDesc, status);
            }
            else if (Tipo == "REP017")
            {
                Reporte = "Reportes\\rptStatus_Facturas.rpt";
                rptPDFFactura(Reporte, Ejercicio, dependencia, status);
            }
            else if (Tipo == "REP018")
            {
                Reporte = "Reportes\\RepCurso_de_Verano.rpt";
                rptPDFUR(Reporte, FechaIn, FechaFi, UR);
            }

            else if (Tipo == "REP020")
            {               
                Reporte = "Reportes\\REP020.rpt";                
                REP020(Reporte, Ejercicio, Mes, MesFin);
            }

            else if (Tipo == "REPA01")
            {                
                if(Nivel=="L")
                    Reporte = "Reportes\\RepAlumnosClientes.rpt";
                else
                    Reporte = "Reportes\\RepAlumnosClientesPosgrado.rpt";

                    rptPDFAlumnos(Reporte, Nivel, UR);
            }
            else if (Tipo == "REPA02")
            {
                Reporte = "Reportes\\RepAlumnosClientes_Excel.rpt";
                rptExcelAlumnos(Reporte, Nivel, UR);
            }
            else if (Tipo == "REPA03")
            {
                Reporte = "Reportes\\RepExentos.rpt";
                rptPDFExento(Reporte, ciclo, UR, status);
            }
            else if (Tipo == "REPA04")
            {
                Reporte = "Reportes\\RepExentos_Excel.rpt";
                rptExcelExento(Reporte, ciclo, UR, status);
            }
            else
            {
                Reporte = "Reportes\\RepComprobanteFiscal.rpt";
                rptPDF(Reporte, idFact);
            }

        }

        private void rptPDF_SIAE(String Reporte, object[] Parametros, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);


                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "secadmin";
                connectionInfo.Password = "secadmin34";
                SetDBLogonForReport(connectionInfo, report);

                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }

        private void rptPDF_FE(String Reporte, object[] Parametros, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);


                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcel_FE(String Reporte, object[] Parametros, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, NombreReporte);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcel_FE(String Reporte, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, NombreReporte);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDF_Ingresos(String Reporte, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);             
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcel_Ingresos(String Reporte, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }

        private void rptPDF_Ingresos(String Reporte, object[] Parametros, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcel_Ingresos(String Reporte, object[] Parametros, string NombreReporte)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);

                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, NombreReporte);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }


        private void REP020(String Reporte, string Ejercicio, string Mes, string MesFin)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Mes);
                report.SetParameterValue(2, MesFin);
                //FileStream  fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "10157.Jpg", FileMode.Open);
                //byte[] imgbyte = new byte[fs.Length + 1];
                //// read the bytes from the binary reader 
                //imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));

                //report.SetParameterValue(3, "System.Byte[]");
                //report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Multipagos");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDFSubreporte(String Reporte, object[] Parametros)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Ingresos");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptMultipagos(String Reporte, string FechaIni, string FechaFin)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, FechaIni);
                report.SetParameterValue(1, FechaFin);
                //report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Multipagos");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDF(String Reporte, int idFactura)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, idFactura);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RepComprobanteFiscal");
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {

                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDFUR(String Reporte, String FechaIn, String FechaFi, string UR)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, FechaIn);
                report.SetParameterValue(1, FechaFi);
                report.SetParameterValue(2, UR);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Extraordinario");
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {

                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptIngresos(String Reporte, String Ejercicio, String Mes, string UR, string Tipo, string EnExcel)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                if (UR == "00000")
                {
                    report.SetParameterValue(0, Ejercicio);
                    if (Tipo == "REP007")
                        report.SetParameterValue(1, Mes);
                }
                else
                {
                    report.SetParameterValue(0, UR);
                    report.SetParameterValue(1, Ejercicio);
                    if (Tipo == "REP007")
                        report.SetParameterValue(2, Mes);

                }

                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                if(EnExcel=="N")
                    report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ReporteIngresos" + UR);
                else
                    report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ReporteIngresos" + UR);

                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {

                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptIngresosEnExcel(String Reporte, object[] Parametros)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    report.SetParameterValue(i, Parametros[i]);

                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ReporteIngresos");                
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptEstadisticas_Descuentos(String Reporte, string UR, string Ciclo)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, UR);
                report.SetParameterValue(1, Ciclo);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Resumen de Descuentos");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptDescuentos_x_Tipo(String Reporte, string UR, string Ciclo, string Concepto, string TipoDescuento, string Status)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, UR);
                report.SetParameterValue(1, Ciclo);
                report.SetParameterValue(2, Concepto);
                report.SetParameterValue(3, Status);
                report.SetParameterValue(4, TipoDescuento);                
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Descuentos por Tipo");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcelUR(String Reporte, string UR)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                if (UR != "00000")
                    report.SetParameterValue(0, UR);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "Aspirantes" + UR);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcelEvento(String Reporte, string Evento)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Evento);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "Reporte" + Evento);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptVisor(String Reporte, String FechaIn, String FechaFi, String UR, String Conceptos)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, FechaIn);
                report.SetParameterValue(1, FechaFi);
                report.SetParameterValue(2, UR);
                report.SetParameterValue(3, Conceptos);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ReportePorFecha");
                CR_ComprobanteFiscal.ReportSource = report;

            }
            catch (Exception ex)
            {

            }
            finally
            {

                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptVisorExcel(String Reporte, String FechaIn, String FechaFi, String UR, String Conceptos)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, FechaIn);
                report.SetParameterValue(1, FechaFi);
                report.SetParameterValue(2, UR);
                report.SetParameterValue(3, Conceptos);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ReferenciasPagadas");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;

                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDFAlumnos(String Reporte, string Nivel, string UR)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, UR);
                report.SetParameterValue(1, Nivel);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "RepAlumnos/Clientes");
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcelAlumnos(String Reporte, string Nivel, string UR)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, UR);
                report.SetParameterValue(1, Nivel);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "RepAlumnos/ClientesExcel");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDFExento(String Reporte, string ciclo, string UR, string status)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, ciclo);
                report.SetParameterValue(1, UR);
                report.SetParameterValue(2, status);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "ExentosPDF");
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptExcelExento(String Reporte, string ciclo, string UR, string status)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, ciclo);
                report.SetParameterValue(1, UR);
                report.SetParameterValue(2, status);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "ingresos";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, false, "ExentosExcel");

            }
            catch (Exception ex)
            {

            }
            finally
            {
                CR_ComprobanteFiscal.ReportSource = report;
                report.Close();
                report.Dispose();

                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void rptPDFFactura(String Reporte, string Ejercicio, string Dependencia, string status)
        {
            try
            {

                ConnectionInfo connectionInfo = new ConnectionInfo();
                p = new System.Web.UI.Page();
                report.Load(p.Server.MapPath("~") + "\\" + Reporte);
                report.SetParameterValue(0, Ejercicio);
                report.SetParameterValue(1, Dependencia);
                report.SetParameterValue(2, status);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                connectionInfo.ServerName = "dsia";
                connectionInfo.UserID = "felectronica";
                connectionInfo.Password = "unach09";
                SetDBLogonForReport(connectionInfo, report);
                report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Resumen_Facturas");
                CR_ComprobanteFiscal.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                report.Close();
                report.Dispose();
                CR_ComprobanteFiscal.Dispose();
            }
        }
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            try
            {
                Tables tables = reportDocument.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                {
                    TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                    tableLogonInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogonInfo);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}