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
    public partial class frmRedirect : System.Web.UI.Page
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
                Usuario.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNUsuario.EncriptarUsuario(Usuario, ref WXI, ref Verificador);
                if (Verificador == "0")                                    
                    Response.Redirect("https://sysweb.unach.mx/INGRESOS2/Home/Index?WXI=" + WXI);                
                else
                    Response.Redirect("../index.aspx", false);
                
            }
        }
    }
}