using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.Form
{
    public partial class frmModAlumnos : System.Web.UI.Page
    {
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CajaFactura ObjCjaFactura = new CajaFactura();
        #region<Funciones>  
        protected void Buscador1_AceptarClicked(object sender, EventArgs e)
        {
            this.Recibos.UsuNombre = SesionUsu.Usu_Nombre;
            this.Recibos.UsuNoControl = SesionUsu.Usu_NoControl;
            this.Recibos.UsuTipo = Convert.ToString(SesionUsu.Usu_TipoUsu);
            this.Recibos.Dependencia = ddlDependencia.SelectedValue;
        }

        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private List<CajaFactura> GetList()
        {
            try
            {
                List<CajaFactura> List = new List<CajaFactura>();
                ObjCjaFactura.FACT_MATRICULA = SesionUsu.Usu_Nombre;
                ObjCjaFactura.FACT_DEPENDENCIA = ddlDependencia.SelectedValue;
                CNCjaFactura.FacturaClienteConsultaGrid(ObjCjaFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", Convert.ToString(SesionUsu.Usu_TipoUsu), SesionUsu.Usu_Nombre);
                ddlDependencia_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void Inicializar()
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                CargarCombos();
                //CargarGrid();                
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void imgBttnInicio_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlDependencia.SelectedValue != "0")
                {
                    MultiView1.ActiveViewIndex = 1;
                    this.Exenciones.ConsultaGridExenciones(ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre);
                    this.CargarGrid();
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void imgBttnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void imgBttnRecibos_Click(object sender, ImageClickEventArgs e)
        {
            //Accordion1.Panes[0].
        }
    }
}