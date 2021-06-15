using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Form
{
    public partial class frmCatReportes : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string Verificador = string.Empty;
        string ruta = string.Empty;
        #endregion

        #region <Funciones>
        protected void Inicializar()
        {
            txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CargarCombos();
            if (Request.QueryString["reporte"] != null)
                SesionUsu.Reporte = Request.QueryString["reporte"];

            if(SesionUsu.Reporte=="REP022")
                MultiView1.ActiveViewIndex = 0;


        }

        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR_Reembolsables", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }
        #endregion

            #region <Botones y Eventos>
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }
        #endregion

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            switch (ddlTipo.SelectedValue)
            {
                case "1":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP022&CDet=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=N";
                    break;
                case "2":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP022-Carreras&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=N";
                    break;
                case "3":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP022-Nivel&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=N";
                    break;


            }

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void bttnCatReembolsables_Click(object sender, EventArgs e)
        {            
            ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP023";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            switch (ddlTipo.SelectedValue)
            {
                case "1":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP022&CDet=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=S";
                    break;
                case "2":
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP022-Carreras&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=S";
                    break;

            }

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
    }
}