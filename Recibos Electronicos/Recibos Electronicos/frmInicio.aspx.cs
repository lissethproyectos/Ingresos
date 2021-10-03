using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos
{
    public partial class frmInicio : System.Web.UI.Page
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
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        string Verificador = "";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                busca_informativa();
                CargarGridStatus();
                CargarGridMonitor(ref grdMonitor);
                CargarGridBancos();

            }
        }

        private void busca_informativa()
        {
            //lblMensaje.Text = string.Empty;

            try
            {
                string Observaciones = string.Empty;
                CNComun.Consultar_Observaciones(SesionUsu.Usu_Nombre, 14, Convert.ToString(SesionUsu.Usu_TipoUsu), ref Observaciones, SesionUsu.Usu_Central, ref Verificador);
                if (Verificador == "0")
                {
                    if (Observaciones.Length > 1)
                    {
                        lblMsg_Observaciones.Text = Observaciones;
                        //ModalPopupExtender.Show();
                    }
                }
                else
                {
                    lblMsg_Observaciones.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsg_Observaciones.Text = ex.Message;
            }
        }
        private void CargarGridMonitor(ref GridView grd)
        {
            try
            {
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetDatos_Monitor();
                grd.DataBind();

            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
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

        private void CargarGridBancos()
        {
            try
            {
                List<Comun> ListAlumno = new List<Comun>();
                List<Comun> ListUsuario = new List<Comun>();
                DataTable dt = new DataTable();
                GetListBancos(ref ListUsuario);
                if (ListUsuario.Count >= 1)
                {
                    //grdStatus_Carga_Bancos.DataSource = dt;
                    //grdStatus_Carga_Bancos.DataSource = ListUsuario;
                    //grdStatus_Carga_Bancos.DataBind();
                }
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGridStatus()
        {
            try
            {
                DataTable dt = new DataTable();
                grvStatus.DataSource = dt;
                grvStatus.DataSource = GetListStatus();
                grvStatus.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<Alumno> GetListStatus()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                CNAlumno.ConsultarStatusDescuento(ref ObjAlumno, SesionUsu.Usu_Nombre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GetListBancos(ref List<Comun> ListUsuario)
        {
            try
            {
                CNFactura.Obt_Grid_Status_Bancos_Monitor(ObjComun, ref ListUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void grdMonitor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMonitor.PageIndex = 0;
            grdMonitor.PageIndex = e.NewPageIndex;
            CargarGridMonitor(ref grdMonitor);
        }

    }
}