using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmBenefRetenciones : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        #endregion

        #region <Funciones>
        protected void Inicializar()
        {
            MultiView1.ActiveViewIndex = 0;
            CargarCombos();
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

       
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void grvDatosRetenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
    }
}