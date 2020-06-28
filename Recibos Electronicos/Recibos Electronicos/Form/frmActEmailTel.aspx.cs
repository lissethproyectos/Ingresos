using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace Recibos_Electronicos.Form
{
    public partial class frmActEmailTel : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CN_Usuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Usuario Usuario2 = new Usuario();
        public Sesion SesionUsu = new Sesion();

        protected string Urlaccion = "";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                lblNombre.Text = SesionUsu.Usu_Nombre;
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";


            if (txtCorreo.Text != "" & txtTeléfono.Text != "")
            {


                Verificador = string.Empty;
                Usuario.Usu_Nombre = SesionUsu.Usu_Nombre;
                Usuario.Correo = txtCorreo.Text;
                Usuario.Telefono = txtTeléfono.Text;
                
                CN_Usuario.Act_Correo_Telefono(Usuario, ref Verificador);

                if (Verificador != "0")
                {
                    lblMensaje.Text = Verificador;
                }
                else
                {
                    Response.Redirect("~/index.aspx", false);
                }
                
            }
            
            else
            {
                lblMensaje.Text = "Para continuar, Debe ingresar un correo electrónico y un téléfono.";
            }
        }


    }
}