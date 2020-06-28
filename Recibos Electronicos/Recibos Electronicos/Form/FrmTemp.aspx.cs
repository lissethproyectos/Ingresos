using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace Recibos_Electronicos.Form
{
    public partial class FrmTemp : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();       
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                GridView1.DataSource = dt;
                GridView1.DataSource = GetPagadas_Temp();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = ex.Message;
            }

        }
        public DataTable GetPagadas_Temp()
        {
            try
            {
                DataTable _tabla = new DataTable();
                CN_Factura CNFactura = new CN_Factura();
                CNFactura.FacturaTempConsultaGrid(ref _tabla);
                return _tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}