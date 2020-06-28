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
    public partial class frmRedirect_SysEmpleados : System.Web.UI.Page
    {
        String Verificador = string.Empty;
        Usuario ObjUsuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Usuario CNUsuario = new CN_Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid Token = Guid.NewGuid();

            Verificador = String.Empty;
            ObjUsuario = new Usuario();
            SesionUsu = (Sesion)Session["Usuario"];


            ObjUsuario.Token = Convert.ToString(Token);
            ObjUsuario.CUsuario = SesionUsu.Usu_Nombre;

            CNUsuario.Inserta_Token_Emp(ref ObjUsuario, ref Verificador);

            string _open = "window.open('" + "https://sysweb.unach.mx/basicos?token=" + Token + "&SourceID=frmEmpleados&Psy=14" + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
    }
}