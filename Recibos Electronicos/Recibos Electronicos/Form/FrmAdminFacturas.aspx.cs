using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Form
{
    public partial class FrmAdminFacturas : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        String Verificador = string.Empty;
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }

        protected void Inicializar()
        {

            Verificador = string.Empty;
            //try
            //{
            //    List<CajaFactura> ListArch = new List<CajaFactura>();
            //    CNCjaFactura.ConsultarPdfXmlFactura(ref ListArch);
            //    CargarGridArchivos(ListArch);
            //}
            //catch (Exception ex)
            //{

            //}
        }
        private void CargarGridArchivos(List<CajaFactura> lstArchivos)
        {
            Int32[] Celdas = { 6, 7 };
            Int32[] CeldasAdmin = { 7 };
            Int32[] CeldasNormal = { 5, 6, 7 };
            try
            {
                DataTable dt = new DataTable();
                grdArchivos.DataSource = dt;
                grdArchivos.DataSource = lstArchivos;
                grdArchivos.DataBind();

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

    }
}