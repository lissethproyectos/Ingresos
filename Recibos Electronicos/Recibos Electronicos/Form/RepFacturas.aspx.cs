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

    public partial class RepFacturas : System.Web.UI.Page
    {

        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //Response.Write("<script  language='javascript'>callprogress(80);</script>");                
                inicializar();
            }
        }
        protected void inicializar()
        {
            CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_Ejercicio", ref DDLEjercicio);
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            
        }

        protected void DDLEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteFactura('" + DDLEjercicio.SelectedValue + "','" + ddlDependencia.SelectedValue + "','" + ddlStatus.SelectedValue + "');", true);            
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }  
}