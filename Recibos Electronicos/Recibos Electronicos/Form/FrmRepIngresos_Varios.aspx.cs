using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRepIngresos_Varios : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        List<ConceptoPago> ListDetConcepto = new List<ConceptoPago>();
        ConceptoPago ObjConceptos = new ConceptoPago();
        CN_ConceptoPago CNConceptos = new CN_ConceptoPago();

        protected string UrlReporte = null;

        #endregion
        
        protected void Inicializar()
        {
            txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            if(UrlReporte == "REP054")
            {
               
                //lblFecha_Factura_Ini.Visible = false;
                //txtFecha_Factura_Ini.Visible = false;
                //lblFecha_Factura_Fin.Visible = false;
                //txtFecha_Factura_Fin.Visible = false;
                lblNivel.Visible = false;
                DDLNivel.Visible = false;
                lblOrdenar.Visible = false;
                ddlOrden.Visible = false;
                
                //imgCalendarioIni.Visible = false;
                //imgCalendarioFin.Visible = false;
                

            }


            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
                DDLNivel.SelectedIndex = 0;
                DDLNivel_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];


            UrlReporte = Convert.ToString(Request.QueryString["SourceID"]);

            if (!IsPostBack)
                Inicializar();
        }

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarGridCatConceptos(false);
        }

       

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;           
            if (UrlReporte == "REP054") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP054&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&enExcel=N";
            //else if (UrlReporte == "REP039") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP039&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
            //else if (UrlReporte == "REP040") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP040&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
            //else if (UrlReporte == "REP041") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP041&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);               
        }

       


        

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;
            if (UrlReporte == "REP054") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP054&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&enExcel=S";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}