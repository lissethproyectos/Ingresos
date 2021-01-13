using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
namespace Recibos_Electronicos
{
    public partial class EnviarCorreo : System.Web.UI.UserControl
    {
        #region <Variables>
        string Verificador = string.Empty;
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Comun CNComun = new CN_Comun();
        #endregion

        //private string _IdRecibo;
        //public string IdRecibo
        //{
        //    get { return _IdRecibo; }
        //    set { _IdRecibo = value; }
        //}

        //private string _Matricula;
        //public string Matricula
        //{
        //    get { return _Matricula; }
        //    set { _Matricula = value; }
        //}

        public void Muestra()
        {
            lblCorreo.Visible = true;
            txtCorreo.Visible = true;
            bttnCorreo.Visible = true;
            bttnBuscaCorreo.Visible = true;
            txtCorreo.Text = string.Empty;

            modalCorreo.Show();
        }

        public void Oculta()
        {
            modalCorreo.Hide();
        }
        
        public string Matricula
        {
            get { return hddnMatricula.Value; }
            set { hddnMatricula.Value = value; }
        }
        
        public string Recibo
        {
            get { return hddnRecibo.Value; }
            set { hddnRecibo.Value = value; }
        }

        public string CveSysweb //Cve generada en Alumno/Cliente
        {
            get { return hddnCveSysweb.Value; }
            set { hddnCveSysweb.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensajeCorreo.Text = string.Empty;
            if (!IsPostBack)
            {
                lblCorreo.Visible = true;
                txtCorreo.Visible = true;
                bttnCorreo.Visible = true;
                bttnBuscaCorreo.Visible = true;
                txtCorreo.Text = string.Empty;                
            }
        }

        protected void bttnBuscaCorreo_Click(object sender, EventArgs e)
        {
            modalCorreo.Show();
            Verificador = string.Empty;
            try
            {                
                ObjAlumno.Matricula = hddnMatricula.Value;
                CNAlumno.ConsultarCorreoAlumno(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    if (ObjAlumno.Correo == "NN")
                        lblMensajeCorreo.Text = "No se encontro correo.";
                    else
                        txtCorreo.Text = ObjAlumno.Correo;
                }
                else
                    lblMensajeCorreo.Text = Verificador;

            }
            catch (Exception ex)
            {
                lblMensajeCorreo.Text = ex.Message;
            }
        }

        protected void bttnCorreo_Click(object sender, EventArgs e)
        {
            modalCorreo.Show();
            string ruta = string.Empty;
            string asunto = string.Empty;
            string contenido = string.Empty;
            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                //if (hddnCveSysweb.Value == "0" )
                //{
                    ruta = "https://www.sysweb.unach.mx/Ingresos/Reportes/VisualizadorCrystal.aspx?idFact=" + hddnRecibo.Value;
                    asunto = "Recibo UNACH-SYSWEB";
                    contenido = "<img src='https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png'><br /><div align=center><font size='4'><a href=\'" + ruta + "'>Recibo Oficial</a></font></div><br /><br />" + "<font size='2'>Para cualquier duda o aclaración te puedes comunicar a los siguientes telefonos:" + "<br /><br /><strong>DIRECCIÓN DE SISTEMAS DE INFORMACIÓN ADMINISTRATIVA</strong><br />Teléfono - (961) 617 80 00, Ext.: 5503, 5501, 5508 y 5509<br /><br />" +
                    "<strong>DEPARTAMENTO DE FINANZAS</strong><br />Teléfono - (961) 617 80 00, Ext.: 5108</font>";
               
                string MsjError = string.Empty;
                CNComun.EnvioCorreo(ref mmsg, asunto, contenido, txtCorreo.Text, ref MsjError);
                if (MsjError == string.Empty)
                {
                    //Enviamos el mensaje      
                    if (mmsg != null)
                    {
                        lblCorreo.Visible = false;
                        txtCorreo.Visible = false;
                        bttnCorreo.Visible = false;
                        bttnBuscaCorreo.Visible = false;
                        lblMensajeCorreo.Text = "El Recibo de Pago se ha enviado al correo " + txtCorreo.Text;
                    }
                }
                else
                    lblMensajeCorreo.Text = MsjError; // "El correo no pudo ser enviado, intentelo más tarde";
            }
            catch (Exception ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                lblMensajeCorreo.Text = ex.Message;
            }
        }

        protected void bttnCancelarCorreo_Click(object sender, EventArgs e)
        {
            modalCorreo.Hide();
        }
    }
}