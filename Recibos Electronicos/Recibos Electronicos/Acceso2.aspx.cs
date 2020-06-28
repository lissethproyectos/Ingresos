using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos
{
    public partial class Acceso2 : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CN_Usuario = new CN_Usuario();
        CN_Comun CNComun = new CN_Comun();
        Usuario Usuario = new Usuario();
        Sesion Sesion = new Sesion();

        protected string Token = null;
        protected string Origen = null;

        #endregion

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    Token = Convert.ToString(Request.QueryString["Token"]);

        //    if (!IsPostBack)
        //    {
        //        //ModalPopupExtender1.Show();

        //        if (Token != null)
        //        {

        //            try
        //            {
        //                Verificador = "-1";

        //                Usuario = new Usuario();
        //                Usuario.Token = Token;
        //                CN_Usuario.ValidarToken(ref Usuario, ref Verificador);

        //                if (Verificador == "0")
        //                {
        //                    txtUsuario.Text = Usuario.usuario;
        //                    txtPassword.Text = Usuario.Password;
        //                    DDLTipoUsuario.SelectedValue = "3";

        //                    btnIngresar_Click(null, null);
        //                }
        //                else
        //                {
        //                    pnlMsj.Visible = true;
        //                    lblMensaje.Text = "El Token no es válido";
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message + ".-ValidarToken");
        //            }
        //        }
        //        else
        //        {
        //            Inicializar();
        //            Session.Abandon();
        //        }

        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

            Origen = Convert.ToString(Request.QueryString["RGN"]);
            if (!IsPostBack)
            {
                if (Origen != null)
                {
                    if (Origen == "ASP")
                    {
                        DDLTipoUsuario.SelectedValue = "1";
                        DDLTipoUsuario_SelectedIndexChanged(null, null);
                        pnlMsj.Visible = true;
                        lblMensaje.Text = "Para obtener el recibo oficial ingresar al siguiente día hábil de haber realizado el pago, si se realizo el día sábado estará disponible hasta el día martes.";
                    }
                }
            }
        }

        #region <Botones> y  <Eventos>
        protected void DDLTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMsj.Visible = false;

            txtUsuario.Visible = false;
            txtPassword.Visible = false;
            txtMatricula.Visible = false;
            txtReferencia.Visible = false;
            if (DDLTipoUsuario.SelectedValue.ToString() == "1")
            {
                txtMatricula.Visible = true;
                txtMatricula.Text = string.Empty;
                txtMatricula.Focus();

            }
            else if (DDLTipoUsuario.SelectedValue.ToString() == "2")
            {
                txtUsuario.Visible = true;
                txtUsuario.Text = string.Empty;
                txtUsuario.Focus();
            }
            else if (DDLTipoUsuario.SelectedValue.ToString() == "3")
            {
                txtUsuario.Visible = true;
                txtUsuario.Text = string.Empty;
                txtPassword.Visible = true;
                txtPassword.Text = string.Empty;
                txtUsuario.Focus();
            }
            else if (DDLTipoUsuario.SelectedValue.ToString() == "4")
            {
                txtReferencia.Visible = true;
                txtReferencia.Text = string.Empty;
                txtReferencia.Focus();
            }
            else if (DDLTipoUsuario.SelectedValue.ToString() == "6")
            {
                txtUsuario.Visible = true;
            }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            pnlMsj.Visible = false;
            lblMensaje.Text = Verificador;
            try
            {
                ValidarUsuario();
                if (Verificador == "0")               
                    IniciarSesion();                
                else
                {
                    txtUsuario.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUsuario.Focus();
                    pnlMsj.Visible = true;
                    if (DDLTipoUsuario.SelectedValue == "1")
                        lblMensaje.Text = "Alumno/aspirante no encontrado, favor de verificar.";
                    else if (DDLTipoUsuario.SelectedValue=="4")
                        lblMensaje.Text = "Referencia no encontrada, favor de verificar.";
                    else
                        lblMensaje.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                pnlMsj.Visible = true;
                lblMensaje.Text = ex.Message;

            }

        }
        #endregion
        #region <Funciones y Sub>
        protected void Inicializar()
        {
            if (Request.QueryString["opc"] != null)
                if (Request.QueryString["opc"] == "1")
                {
                    DDLTipoUsuario.Items.Remove(DDLTipoUsuario.Items[1]);
                    DDLTipoUsuario.Items.Remove(DDLTipoUsuario.Items[2]);
                }
                else if (Request.QueryString["opc"] == "2")
                    DDLTipoUsuario.Items.Remove(DDLTipoUsuario.Items[2]);


            //CNComun.LlenaCombo("Pkg_Contratos.Obt_Combo_Sistemas", ref ddlSistemas, "p_usuario");
        }
        public void IniciarSesion()
        {
            try
            {
                Sesion.Usu_TipoUsu = Usuario.Usu_TipoUsu;
                Sesion.Usu_NoControl = Usuario.Usu_NoControl.ToUpper();
                Sesion.Usu_Nombre = Usuario.Usu_Nombre.ToUpper();                
                Session["Usuario"] = Sesion;
                Session.Timeout = 120;

                //Verifica que el usuario tenga correo y telefono actualizado
                if (Sesion.Usu_TipoUsu == 3)
                {
                    CN_Usuario.Verificar_Correo_Telefono(ref Sesion, ref Verificador);
                    if (Verificador == "0")
                    {
                        if (Sesion.Status == "S") Response.Redirect("index.aspx", false);
                        else Response.Redirect("Form/frmActEmailTel.aspx", false);
                    }
                }
                else if (Sesion.Usu_TipoUsu == 6)
                {
                    Response.Redirect("Form/frmRefVenta_Pat.aspx", false);
                }
                else
                    Response.Redirect("index.aspx", false);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ValidarUsuario()
        {
            try
            {
                if (DDLTipoUsuario.SelectedValue == "1")
                {
                    Usuario.Usu_Nombre = txtMatricula.Text;
                    Usuario.Usu_NoControl = string.Empty; // DDLEscuelas.SelectedValue;                    
                }
                else if (DDLTipoUsuario.SelectedValue == "2")
                {
                    Usuario.Usu_Nombre = txtUsuario.Text;
                    Usuario.Usu_NoControl = string.Empty;
                }
                else if (DDLTipoUsuario.SelectedValue == "3")
                {
                    Usuario.Usu_Nombre = txtUsuario.Text;
                    Usuario.Usu_NoControl = txtPassword.Text;
                }
                else if (DDLTipoUsuario.SelectedValue == "6")
                {
                    Usuario.Usu_Nombre = txtUsuario.Text;
                    Usuario.Usu_NoControl = string.Empty;
                }
                else
                {
                    Usuario.Usu_Nombre = txtReferencia.Text; //txtPassword.Text;
                    Usuario.Usu_NoControl = string.Empty; //txtReferencia.Text;
                }
                Usuario.Usu_TipoUsu = Convert.ToInt32(DDLTipoUsuario.SelectedValue);

                if (Usuario.Usu_TipoUsu == 3)
                {
                    CN_Usuario.ValidarUsuarioDependencia(ref Usuario, ref Verificador);
                    if (Verificador == "0")
                    {
                        Sesion.Usu_Nombre = txtUsuario.Text;
                        CN_Usuario.UsuarioCentral(ref Sesion, ref Verificador);
                    }
                }
                else if(Usuario.Usu_TipoUsu == 6)
                {
                    //CN_Usuario.ValidarCliente(ref Usuario, ref Verificador);
                    if (Verificador == "0")
                    {
                        Sesion.Usu_Nombre = txtUsuario.Text;
                        //CN_Usuario.UsuarioCentral(ref Sesion, ref Verificador);
                    }

                }

                //else
                    //CN_Usuario.ValidarUsuario(ref Usuario, ref Verificador);


                //if (Verificador == "0" && Usuario.Usu_TipoUsu == 3)
                //{
                //    Sesion.Usu_Nombre = txtUsuario.Text;
                //    CN_Usuario.UsuarioCentral(ref Sesion, ref Verificador);
                //}
            }
            catch (Exception ex)
            {
                pnlMsj.Visible = true;
                lblMensaje.Text=ex.Message;
            }
        }
        #endregion

       

        protected void ddlSistemas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnSistemas_Click(object sender, EventArgs e)
        //{
        //    if(ddlSistemas.SelectedValue!="X")
        //        Response.Redirect(ddlSistemas.SelectedValue);
        //}

        protected void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnIngresar.Focus();
        }

        //protected void txtMatricula_TextChanged(object sender, EventArgs e)
        //{
        //    lblMensaje.Text = string.Empty;
        //    Verificador = string.Empty;
        //    try
        //    {
        //        CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Escuelas_Alumno", ref DDLEscuelas, "p_matricula", txtMatricula.Text, "INGRESOS");
        //        DDLEscuelas.Visible = true;
        //        btnIngresar.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = ex.Message;
        //    }
        //}
    }
}