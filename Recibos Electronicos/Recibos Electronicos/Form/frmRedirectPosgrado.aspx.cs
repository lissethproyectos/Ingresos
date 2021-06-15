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
    public partial class frmRedirectPosgrado : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Usuario Usuario = new Usuario();
        CN_Usuario CNUsuario = new CN_Usuario();
        string Verificador = string.Empty;
        string Ruta = string.Empty;
        string WXI = string.Empty;
        string Formulario;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Usuario.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNUsuario.EncriptarUsuario(Usuario, ref WXI, ref Verificador);                
                if (Request.QueryString["formulario"] != null)
                    Formulario = Request.QueryString["formulario"];
                else
                    Formulario = "0";

                if (Verificador == "0" && Formulario != "0")
                {
                    //Ruta = "https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=" + WXI + "&Formulario=" + Formulario;
                    //frmPosgrado.Src = Ruta;
                    //frmPosgrado.
                    //this.frmPosgrado.Attributes.Add("src", Ruta);
                    //this.Master.iframe.Attributes.Add("src", "some.aspx");



                    ScriptManager.RegisterStartupScript(this, GetType(), "Usuarios", "RedirectSysPosgrado('" + WXI + "', '"+ Formulario + "');", true);
                    //Ruta = "RedirectIngMVC('" + WXI + "', '" + Formulario + "')";
                }
                else
                    Response.Redirect("../index.aspx", false);
                
            }
        }

        protected void imgBttnRedirect_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            Usuario.Usu_Nombre = SesionUsu.Usu_Nombre;
            if (Request.QueryString["formulario"] != null)
                Formulario = Request.QueryString["formulario"];
            else
                Formulario = "0";

            CNUsuario.EncriptarUsuario(Usuario, ref WXI, ref Verificador);
            if(Verificador=="0")
                ScriptManager.RegisterStartupScript(this, GetType(), "Usuarios", "RedirectIngMVC('" + WXI + "', '" + Formulario + "');", true);

        }
    }
}