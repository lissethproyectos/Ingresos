using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmPuntodeVenta : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        Factura objFichaBanc = new Factura();
        CN_Comun CNComun = new CN_Comun();
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        #region <Funciones>
        protected void Inicializar()
        {
            CargarCombos();
            CargarGrid(ref grvDatosFichaBanc);
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        public void CargarGrid(ref GridView grd)
        {
            try
            {
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetList();
                grd.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                objFichaBanc.FACT_DEPENDENCIA = ddlDependencia.SelectedValue;
                //CNFactura.FacturaConsultaGrid(Usur, ref ObjFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}