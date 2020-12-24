using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ClosedXML.Excel;
using ClosedXML.Excel;
using System.IO;
using CapaNegocio;
using CapaEntidad;
using System.Text;
using System.Net.Mail;
using System.Net;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace Recibos_Electronicos
{
    public partial class index : System.Web.UI.Page
    {
        #region <Variables>
        //Int32[] Celdas = { 0, 7, 10 };
        //private string[] UsuariosSuper = {"JFREDY", "NESTOR", "GAVA", "ADOMINGUEZ","LUISH","LISSETH","OMAR","VELASCO","MARCOSA", "VICENTE", "NIVETTE", "JMOLINA", "FRANCISCO", "OSMANDI", "GEORGINA", "YARINA", "NORMAV", "BEATRIZ" };
        Factura ObjFactura = new Factura();
        Alumno ObjAlumno = new Alumno();
        Comun ObjComun = new Comun();
        Evento ObjEvento = new Evento();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Evento CNEvento = new CN_Evento();
        string Verificador = "";
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();
            //else
            //{
            //    precarga1
            //}
            
        }
        #region <Botones y Eventos>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (SesionUsu.Reporte == "REP003")
                ConsultaGridFacturas();
            else if(SesionUsu.Evento == "RETENCIONES")
                CargarGridRetenciones();
            else
                ConsultarReportesConceptos();

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            //grdDatosFactura.Visible = true;
            pnlContenor.Visible = true;
            btnRegresar.Visible = false;


        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                ObjFactura.ID_FACT = SesionUsu.Id_Comprobante.ToString();
                ObjFactura.FACT_NOMBRE = txtnombre.Text;
                ObjFactura.FACT_MATRICULA = txtMatricula.Text;
                ObjFactura.FACT_CARRERA = txtCarrera.Text;
                ObjFactura.FACT_OBSERVACIONES = txtObservaciones.Text;

                CNFactura.FacturaEditar(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    pnlContenor.Visible = true;
                    pnlEditar.Visible = false;
                    grdDatosFactura.Visible = true;
                    txtnombre.Text = string.Empty;
                    txtMatricula.Text = string.Empty;
                    txtCarrera.Text = string.Empty;
                    txtObservaciones.Text = string.Empty;
                    txtBanco.Text = string.Empty;
                    txtFecha.Text = string.Empty;
                    txtFolioBancario.Text = string.Empty;
                    txtFolioRec.Text = string.Empty;
                    txtImporte.Text = string.Empty;
                    txtReferenciaSel.Text = string.Empty;
                    lblMensaje.Text = "Los Datos se guardaron correctamente";
                    grdDatosFactura.Visible = true;
                    CargarGrid();
                }
                else

                    lblMsjEditar.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlContenor.Visible = true;
            pnlEditar.Visible = false;
            grdDatosFactura.Visible = true;
            txtnombre.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtBanco.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtFolioBancario.Text = string.Empty;
            txtFolioRec.Text = string.Empty;
            txtImporte.Text = string.Empty;
            txtReferenciaSel.Text = string.Empty;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
            SesionUsu.Id_Comprobante = Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
            ObjFactura.ID_FACT = Convert.ToString(SesionUsu.Id_Comprobante);
          
            CNFactura.FacturaConsulta(ref ObjFactura, ref Verificador);
            if (Verificador == "0")
            {
                txtnombre.Text = ObjFactura.FACT_NOMBRE;
                txtMatricula.Text = ObjFactura.FACT_MATRICULA;
                txtCarrera.Text = ObjFactura.FACT_CARRERA;
                txtReferenciaSel.Text = ObjFactura.FACT_REFERENCIA;
                txtObservaciones.Text = ObjFactura.FACT_OBSERVACIONES;
                txtFecha.Text = ObjFactura.FACT_FECHA_FACTURA;
                txtImporte.Text = ObjFactura.FACT_TOTAL;
                txtFolioRec.Text = ObjFactura.FACT_FOLIO;
                txtFolioBancario.Text = ObjFactura.FACT_FOLIOBANCARIO;
                txtBanco.Text = ObjFactura.FACT_BANCO;

                pnlContenor.Visible = false;
                pnlEditar.Visible = true;
                grdDatosFactura.Visible = false;

            }
            else
                lblMensaje.Text = Verificador;

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }
        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlContenor.Visible = false;
            btnRegresar.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + ");", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerRecibo(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + ", Image);", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ObtenerQR(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + "," + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[11].Text) + ");", true);


            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP099&idFact=" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text)+"&imagenQR="+ hddnImagenQR.Value;


            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            //grdDatosFactura.Visible = false;

        }




        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdDatosFactura.PageIndex = 0;
                grdDatosFactura.PageIndex = e.NewPageIndex;
                if (SesionUsu.Evento == "RETENCIONES")
                    CargarGridRetenciones();
                else
                    CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //protected void grdMonitor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdMonitor.PageIndex = 0;
        //    grdMonitor.PageIndex = e.NewPageIndex;
        //    CargarGridMonitor(ref grdMonitor);
        //}        
        #endregion
        #region <Funciones>
        protected void inicializar()
        {                    
            var Usu = SesionUsu.Usu_Nombre;            
            SesionUsu.ReporteEnExcel = "N";
            SesionUsu.ReporteconGraficas = "N";
            SesionUsu.Reporte = string.Empty;
            SesionUsu.Evento = string.Empty;
            CargarCombos();

            if (Convert.ToString(SesionUsu.Usu_TipoUsu) == "3")
            {
                lblDependencia.Visible = true;
                ddlDependencia.Visible = true;               
                txtFecha_Factura_Ini.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");                
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                if (Request.QueryString["reporte"] == null && Request.QueryString["modulo"] == null && Request.QueryString["Evento"] == null)
                    busca_informativa();

                //CargarGridMonitor(ref grdMonitor);
            }
            else
            {
                txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                //CargarGridBancos();
                busca_informativa();
            }

            if (Request.QueryString["reporte"] != null)            
                SesionUsu.Reporte = Request.QueryString["reporte"];            
            else if (Request.QueryString["modulo"] != null)
            {
                if (Request.QueryString["modulo"] == "RETENCIONES")
                {
                    SesionUsu.Evento = "RETENCIONES";
                    SesionUsu.Reporte = "REP044";
                }
            }
            else if (Request.QueryString["Evento"] != null)
                SesionUsu.Evento = Request.QueryString["Evento"];
            else
            {
                SesionUsu.Reporte = "REP003";
                SesionUsu.Evento = "NINGUNO";
                //CargarGridBancos();
                //CargarGridMonitor(ref grdMonitor);
                //ConsultaGridFacturas(); //Para no volver a cargar el grid cuando invoque a otros reportes
                
            }

            CargarGridBancos();
            ConsultaGridFacturas();
            ConsultaDDLReporte();
            DDLMes.SelectedValue = System.DateTime.Now.Month.ToString("00");
            DDLMes_Fin.SelectedValue = System.DateTime.Now.Month.ToString("00");
            txtReferencia.Focus();
        }        
        private void CargarGridMonitor(ref GridView grd)
        {
            try
            {
                Int32[] Celdas = new Int32[] { 2, 4 };
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetDatos_Monitor();
                grd.DataBind();

                if (grd.Rows.Count > 0)
                    CNComun.HideColumns(grd, Celdas);
                

                grd.SelectedIndex = 0;
                if (grd.SelectedRow.Cells[2].Text.Contains("1"))
                {
                    grd.SelectedRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#ebccd1");
                    grd.SelectedRow.Font.Bold = true;
                }            
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            //var usuAdmin = Array.FindAll(UsuariosSuper, s => s.Equals(SesionUsu.Usu_Nombre));
            
            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();                
                
                if (grdDatosFactura.Rows.Count > 0)
                {
                    if (SesionUsu.Usu_TipoUsu == 3)//Muestra la columna Editar
                    {
                        Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                        Usur.Usu_IdModulo = 15314;
                        CNUsuario.PermisoUsuario(ref Usur, ref Verificador);                        
                        grdDatosFactura.Columns[9].Visible = false;
                        if (SesionUsu.Usu_Central == "S")
                        {
                            Int32[] Celdas = { 0, 9, 10, 11 };
                            CNComun.HideColumns(grdDatosFactura, Celdas);                            
                        }
                        else
                        {
                            Int32[] Celdas = { 0, 7, 9, 10, 11 };
                            CNComun.HideColumns(grdDatosFactura, Celdas);
                        }

                    }
                    else
                    {
                        Int32[] Celdas = { 0, 7, 9, 10, 11 };
                        CNComun.HideColumns(grdDatosFactura, Celdas);
                    }


                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridRetenciones()
        {
            Int32[] Celdas = new Int32[] { 0,6,9,10 };

            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetListRetenciones();
                grdDatosFactura.DataBind();
                if (grdDatosFactura.Rows.Count > 0)
                    HideColumns(grdDatosFactura, Celdas);
            }

            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridBancos()
        {
            try
            {
                List<Comun> ListAlumno = new List<Comun>();
                List<Comun> ListUsuario = new List<Comun>();
                DataTable dt = new DataTable();
                GetListBancos(ref ListAlumno, ref ListUsuario);
                if (ListUsuario.Count >= 1)
                {
                    if (SesionUsu.Usu_TipoUsu == 1)
                    {
                        if (ListAlumno.Count > 0)
                        {
                            grdStatus_Carga_Bancos.DataSource = dt;
                            grdStatus_Carga_Bancos.DataSource = ListAlumno;
                            grdStatus_Carga_Bancos.DataBind();
                            //modalBancos.Show();
                        }
                    }
                    //else
                    //{
                        //grdStatus_Carga.DataSource = dt;
                        //grdStatus_Carga.DataSource = ListUsuario;
                        //grdStatus_Carga.DataBind();
                    //}
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridEventos()
        {
            Int32[] Celdas = { 0, 6 };
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();
                HideColumns(grdEventos, Celdas);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        public List<Comun> GetDatos_Monitor()
        {

            try
            {
                List<Comun> List = new List<Comun>();                                
                CNFactura.ErroresConsultaGrid(SesionUsu.Usu_Nombre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void GetListBancos(ref List<Comun> ListAlumno, ref List<Comun> ListUsuario)
        {
            try
            {                
                if (SesionUsu.Usu_TipoUsu == 1)
                    CNFactura.Obt_Grid_Status_Bancos(ObjComun, ref ListAlumno);
                
                    CNFactura.Obt_Grid_Status_Bancos_Usu(ObjComun, ref ListUsuario);             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                Usur.Usu_NoControl = SesionUsu.Usu_NoControl;
                Usur.Usu_TipoUsu = SesionUsu.Usu_TipoUsu;
                CNFactura.FacturaConsultaGrid(Usur, ref ObjFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ref List);
              
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Factura> GetListRetenciones()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                string Tipo=string.Empty;
                //if(ddlTipoRep.SelectedValue=="2")
                //    Tipo = ddlPeriodoPago.SelectedItem.Text;

                CNFactura.FacturaConsultaGridRetenciones(Usur, ref ObjFactura, ddlDependencia.SelectedValue, txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, Tipo, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> ListEvento = new List<Evento>();
                ObjEvento.Dependencia = ddlDependencia.SelectedValue;
                CNEvento.ConsultarEventosRef(ObjEvento, SesionUsu.Usu_Nombre, "A", "N", ref ListEvento);                
                return ListEvento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void ConsultaGridFacturas()
        {
            try
            {
                //CNFactura.Obt_Mensaje(ref Verificador);
                //if (Verificador == "0")
                //{
                //    lblMensaje.Text = string.Empty;
                //}
                //else
                //{
                //    lblMensaje.Text = Verificador;
                //}
                CargarGrid();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        protected void CargarCombos()
        {
            try
            {

                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);                
                CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_Ejercicio", ref DDLEjercicio);
                CNComun.LlenaCombo("pkg_pagos.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Tipos_Descuentos", ref ddlTipo, "INGRESOS");
                DDLConceptos.SelectedIndex = 0;
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
                //DDLNivel.Items.Insert(0, new ListItem("--TODOS--", "T"));
                DDLNivel.SelectedValue = "T";
                DDLNivel_SelectedIndexChanged(null, null);
                //ddlDependencia.SelectedIndex = 0;

                DDLEjercicio.SelectedValue = System.DateTime.Now.Year.ToString();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        protected void ConsultaDDLReporte()
        {
            pnlEjercicio.Visible = false;
            pnlRangoFecha.Visible = true;
            lblDependencia.Visible = true;
            ddlDependencia.Visible = true;
            btnConsultar.Visible = true;
            lblCiclo.Visible = false;
            ddlCiclo.Visible = false;
            ddlTipo.Visible = false;
            lblTipo.Visible = false;
            lblStatus0.Visible = false;
            rdoListStatus.Visible = false;
            //grdMonitor.Visible = false;
            //lblAvisos.Visible = false;            
            imgBttnReporte.Visible = false;
            imgBttnExportar.Visible = false;
            imgBttnEstadisticas.Visible = false;
            lblMes_Fin.Visible = false;
            DDLMes_Fin.Visible = false;
            linkBttnCatReembolsables.Visible = false;
            pnlEvento.Visible = false;
            lblConceptos.Visible = true;
            DDLConceptos.Visible = true;

            if (SesionUsu.Reporte == "000000")//Ver el Grid
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                pnlRangoFecha.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                btnConsultar.Visible = false;
                ddlDependencia_SelectedIndexChanged(null, null);                                
                pnlEvento.Visible = true;
            }
            else if(SesionUsu.Reporte == "REP003")//Ver el Grid
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = true;
                txtReferencia.Visible = true;
                grdDatosFactura.Visible = true;
                //grdMonitor.Visible = true;
                //lblAvisos.Visible = true;
            }
            else if (SesionUsu.Reporte == "REP004")//Fichas de Aspirantes
            {
                //pnlRangoFecha.Visible = false;
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                grdDatosFactura.Visible = false;
               
            }
            else if (SesionUsu.Reporte == "REP005")//Referencias Pagadas
            {
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                btnConsultar.Visible = false;
                imgBttnExportar.Visible = true;
                lblConceptos.Visible = true;
                DDLConceptos.Visible = true;
                lblNivel.Visible = true;
                DDLNivel.Visible = true;
                grdDatosFactura.Visible = false;
                //linkBttnCatReembolsables.Visible = true;

            }
            else if (SesionUsu.Reporte == "REP006")// Examen Extraordinario
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                grdDatosFactura.Visible = false;
            }
            else if (SesionUsu.Reporte == "REP007")//Ingresos Mensuales
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Text = "Mes:";
                lblMes.Visible = true;
                DDLMes.Visible = true;
                btnConsultar.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
                imgBttnEstadisticas.Visible = true;
            }
            else if (SesionUsu.Reporte == "REP008")//Ingresos Acumulados
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                btnConsultar.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
                imgBttnEstadisticas.Visible = true;

            }
            else if (SesionUsu.Reporte == "REP009")//Presupuesto por Mes
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                btnConsultar.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
            }
            else if (SesionUsu.Reporte == "REP010")//Presupuesto 80-20
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
            }
            else if (SesionUsu.Reporte == "REP011")//Estadistica de Alumnos
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
            }
            else if (SesionUsu.Reporte == "REP012")//Bitacora de Carga
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = true;
                DDLMes.Visible = true;
            }
            else if (SesionUsu.Reporte == "REP013")//Recibos Cancelados
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                btnConsultar.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
            }
            else if (SesionUsu.Reporte == "REP014")//Participantes Registrados
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = false;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                btnConsultar.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteEvento('" + SesionUsu.Reporte + "','" + SesionUsu.Evento + "');", true);
            }

            else if (SesionUsu.Reporte == "REP015")//Estadistica de Descuentos
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = false;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                lblCiclo.Visible = true;
                ddlCiclo.Visible = true;
            }


            else if (SesionUsu.Reporte == "REP016")//Estadistica de Descuentos
            {
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = false;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                ddlTipo.Visible = true;
                lblTipo.Visible = true;
                lblStatus0.Visible = true;
                rdoListStatus.Visible = true;
                lblCiclo.Visible = true;
                ddlCiclo.Visible = true;
                lblNivel.Visible = true;
                DDLNivel.Visible = true;
                lblConceptos.Visible = true;
                DDLConceptos.Visible = true;
            }

            else if (SesionUsu.Reporte == "REP018")// Cursos de Verano
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                grdDatosFactura.Visible = false;
            }

            else if (SesionUsu.Reporte == "REP019")// Multipagos
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
            }

            else if (SesionUsu.Reporte == "REP020")//Ingresos Mensuales
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;
                lblMes.Text = "Mes Inicial:";
                lblMes.Visible = true;
                DDLMes.Visible = true;
                lblMes_Fin.Visible = true;
                DDLMes_Fin.Visible = true;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
            }
            else if (SesionUsu.Reporte == "REP021")//Estadisticas de Exenciones Programadas
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = true;
                pnlRangoFecha.Visible = false;
                grdDatosFactura.Visible = false;                
                lblMes.Visible = false;
                DDLMes.Visible = false;                
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
            }

            else if (SesionUsu.Reporte == "REP022")//Conceptos Reembolsables
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                pnlEjercicio.Visible = false;
                pnlRangoFecha.Visible = true;
                grdDatosFactura.Visible = false;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                lblDependencia.Visible = true;
                ddlDependencia.Visible = true;
                linkBttnCatReembolsables.Visible = true;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
                btnConsultar.Visible = false;
            }
            else if (SesionUsu.Reporte == "REP035")// Multipagos
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                lblDependencia.Visible = false;
                ddlDependencia.Visible = false;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                lblFecha_Factura_Fin.Visible = false;
                txtFecha_Factura_Fin.Visible = false;
                imgCalendarioFin.Visible = false;
                btnConsultar.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
            }

            else if (SesionUsu.Evento == "RETENCIONES")
            {
                lblConceptos.Visible = false;
                DDLConceptos.Visible = false;
                //lblReferencia.Visible = true;
                //txtReferencia.Visible = true;
                pnlEjercicio.Visible = false;
                pnlRangoFecha.Visible = true;
                grdDatosFactura.Visible = true;
                lblMes.Visible = false;
                DDLMes.Visible = false;
                //lblDependencia.Visible = false;
                //ddlDependencia.Visible = false;
                linkBttnCatReembolsables.Visible = false;
                imgBttnReporte.Visible = false;
                imgBttnExportar.Visible = true;
                btnConsultar.Visible = true;
                GetListRetenciones();
            }

            else //REP001: Detalle de Ingresos.- REP002: Concentrado de Ingresos.- REP005: Referencia Pagadas
            {
                lblConceptos.Visible = true;
                DDLConceptos.Visible = true;
                lblReferencia.Visible = false;
                txtReferencia.Visible = false;
                grdDatosFactura.Visible = false;
                imgBttnReporte.Visible = true;
                imgBttnExportar.Visible = true;
                lblNivel.Visible = true;
                DDLNivel.Visible = true;
                btnConsultar.Visible = false;
            }
        }
        protected void ConsultarReportesConceptos()
        {
            pnlContenor.Visible = false;
            grdDatosFactura.Visible = false;
            btnRegresar.Visible = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteExportarConceptos('" + SesionUsu.Reporte + "','" + ddlDependencia.SelectedValue + "','" + txtFecha_Factura_Ini.Text + "','" + txtFecha_Factura_Fin.Text + "','" + DDLConceptos.SelectedValue + "','" + DDLEjercicio.SelectedValue + "','" + DDLMes.SelectedValue + "','" + ddlCiclo.SelectedValue + "','" + ddlTipo.SelectedValue + "','" + rdoListStatus .SelectedValue+ "','"+DDLMes_Fin.SelectedValue+"','"+SesionUsu.ReporteEnExcel+"','"+DDLNivel.SelectedValue+ "', '" + SesionUsu.ReporteconGraficas + "');", true);
            string ruta = "Reportes/VisualizadorCrystal.aspx?Tipo=" + SesionUsu.Reporte + "&CDet=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&IdConcepto=" + DDLConceptos.SelectedValue + "&Ejercicio=" + DDLEjercicio.SelectedValue + "&Mes=" + DDLMes.SelectedValue + "&ciclo=" + ddlCiclo.SelectedValue + "&TipoDesc=" + ddlTipo.SelectedValue + "&Status=" + rdoListStatus.SelectedValue+"&Nivel="+DDLNivel.SelectedValue;
            //"&Ciclo=" + ddlCiclo.SelectedValue + "&CDet=" + ddlDependencia.SelectedValue + "&status=" + ddlStatus_Ini.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);



        }
        private void HideColumns(GridView grdView, Int32[] Celdas)
        {
            for (int i = 0; i < Celdas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Celdas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Celdas.GetValue(i))].Visible = false;
                }
            }
        }        
        private void GenerarOficio()
        {
            string ruta = "Reportes/VisualizadorCrystal.aspx?idFact=" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);            
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        private void busca_informativa()
        {
            try
            {
                lblMensaje.Text = string.Empty;
                string Observaciones=string.Empty;
                CNComun.Consultar_Observaciones(SesionUsu.Usu_Nombre, 14, Convert.ToString(SesionUsu.Usu_TipoUsu), ref Observaciones, SesionUsu.Usu_Central, ref Verificador);

                if (Verificador == "0")
                {
                    if (Observaciones.Length > 1)
                    {
                        lblMsg_Observaciones.Text = Observaciones;
                        ModalPopupExtender.Show();
                    }
                }
                else
                {
                    lblMensaje.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
       
        #endregion

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            ConsultarReportesConceptos();
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.ReporteEnExcel = "S";
            if (SesionUsu.Reporte == "REP044")
                modalRepRetenciones.Show();

            else
                ConsultarReportesConceptos();
            

            SesionUsu.ReporteEnExcel = "N";            
        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DDLMes_Fin.SelectedValue = DDLMes.SelectedValue;
        }

        protected void linkBttnCatReembolsables_Click(object sender, EventArgs e)
        {
            //SesionUsu.Reporte = "REP023";
            //btnConsultar_Click(null, null);
            pnlContenor.Visible = false;
            grdDatosFactura.Visible = false;
            btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteExportarConceptos('REP023','" + ddlDependencia.SelectedValue + "','" + txtFecha_Factura_Ini.Text + "','" + txtFecha_Factura_Fin.Text + "','" + DDLConceptos.SelectedValue + "','" + DDLEjercicio.SelectedValue + "','" + DDLMes.SelectedValue + "','" + ddlCiclo.SelectedValue + "','" + ddlTipo.SelectedValue + "','" + rdoListStatus.SelectedValue + "','" + DDLMes_Fin.SelectedValue + "','" + SesionUsu.ReporteEnExcel + "','" + DDLNivel.SelectedValue + "', '"+SesionUsu.ReporteconGraficas+"');", true);

        }

        protected void linkBttnEnviarCorreo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            lblMensaje.Text = string.Empty;
            try
            {                
                grdDatosFactura.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grdDatosFactura.SelectedRow.Cells[10].Text;
                PnlCorreo.Recibo = grdDatosFactura.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //modalBancos.Hide();
        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            lblMensaje.Text = string.Empty;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grdDatosFactura.SelectedRow.Cells[10].Text;
                PnlCorreo.Recibo = grdDatosFactura.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Reporte == "000000")
            {
                if (ddlDependencia.SelectedValue == "00000")
                    //CNComun.LlenaLista("PKG_PAGOS_2016.Obt_Combo_Eventos_Rep", ref LSTEvento, "p_dependencia_ini", "p_dependencia_fin", "p_usuario", "00000", "99999", SesionUsu.Usu_Nombre, "INGRESOS");
                    CargarGridEventos();
                else
                    CargarGridEventos();
                    //CNComun.LlenaLista("PKG_PAGOS_2016.Obt_Combo_Eventos_Rep", ref LSTEvento, "p_dependencia_ini", "p_dependencia_fin", "p_usuario", ddlDependencia.SelectedValue, ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre, "INGRESOS");
            }
        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Ruta= "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx?evento="+grdEventos.SelectedRow.Cells[0].Text;
            Response.Redirect(Ruta, false);
            //Response.Write("<script>window.open('"+ Ruta + "','_blank');</script>");
        }

        protected void grdEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdEventos.PageIndex = 0;
                grdEventos.PageIndex = e.NewPageIndex;
                CargarGridEventos();                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        protected void imgBttnEvento_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            string Ruta = grdEventos.SelectedRow.Cells[6].Text;
            Response.Redirect(Ruta, false);

        }

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaComboG("PKG_FELECTRONICA_2016.Obt_Combo_Conceptos", ref DDLConceptos, "p_nivel", DDLNivel.SelectedValue);
        }

        protected void imgBttnEstadisticas_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.ReporteconGraficas = "S";
            ConsultarReportesConceptos();
            SesionUsu.ReporteconGraficas = "N";
        }

        protected void btnVerRep_Click(object sender, EventArgs e)
        {
            string ruta1 = "Reportes/VisualizadorCrystal.aspx?Tipo=REP044&CDet=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&TipoDesc=" + ddlTipoRep.SelectedValue + "&enExcel=S";
            string _open1 = "window.open('" + ruta1 + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open1, true);

        }

        protected void CancelAlert_Click(object sender, EventArgs e)
        {
            modalRepRetenciones.Hide();
        }

        //protected void imgStatus_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton cbi = (ImageButton)(sender);
        //    GridViewRow row = (GridViewRow)cbi.NamingContainer;
        //    try
        //    {
        //        grdMonitor.SelectedIndex = row.RowIndex;
        //        string Observaciones = grdMonitor.SelectedRow.Cells[4].Text;
        //        CNFactura.FacturaEditarEstatusRevisado(Observaciones, SesionUsu.Usu_Nombre, ref Verificador);
        //        if (Verificador == "0")
        //            CargarGridMonitor(ref grdMonitor);
        //        else
        //        {
        //            string Msj = Verificador;
        //            CNComun.VerificaTextoMensajeError(ref Msj);
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string Msj = ex.Message;
        //        CNComun.VerificaTextoMensajeError(ref Msj);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
        //    }

        //}

       

    }
}