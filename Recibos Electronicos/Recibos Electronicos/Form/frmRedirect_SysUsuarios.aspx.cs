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
    public partial class frmRedirect_SysUsuarios : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Usuario Usuario = new Usuario();
        CN_Usuario CNUsuario = new CN_Usuario();
        string Verificador = string.Empty;
        string WXI = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //mp_sistema.Value = "14";
                //mp_nombre_sistema.Value = "COIN - Control de Ingresos";
                //mp_subsistema.Value = "0";
                //mp_usuario.Value = SesionUsu.Usu_Nombre;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "RedirectSysUsuarios();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Usuarios", "RedirectSysUsuarios(14,'" + SesionUsu.Usu_Nombre + "', 'COIN - Control de Ingresos');", true);

            }
        }
    }
}