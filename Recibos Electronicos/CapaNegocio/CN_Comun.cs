using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections;
using System.Web.UI;
using System.Net.Mail;
using System.Net.Mime;
using CapaEntidad;
using CapaDatos;
using System.IO;
using System.Security.Cryptography;

namespace CapaNegocio
{
    public class CN_Comun
    {
        //----------------Ingresando nombre de Esquema BD----------------------------------------------------------------
        public void LlenaCombo(string SP, ref DropDownList DDL, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string valor, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, valor, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string parametro2, string valor, string valor2, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, parametro2, valor, valor2, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string valor, string parametro2, string valor2, string parametro3, string valor3, ref List<Comun> Etiquetas, string UsuBD)
        //{
        //    try
        //    {
        //        List<Comun> Lista = new List<Comun>();
        //        CD_Comun CDComun = new CD_Comun();
        //        CDComun.LlenaCombo(SP, ref Lista, parametro, parametro2, parametro3, valor, valor2, valor3, UsuBD);
        //        DDL.Items.Clear();
        //        if (Lista.Count > 0)
        //        {
        //            Etiquetas = Lista;
        //            DDL.DataSource = Lista;
        //            DDL.DataValueField = "IdStr";
        //            DDL.DataTextField = "Descripcion";
        //            DDL.DataBind();
        //        }
        //        else
        //        {
        //            DDL.Items.Add("La opción no contiene datos");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string parametro2, string parametro3, string valor, string valor2, string valor3, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, parametro2, parametro3, valor, valor2, valor3, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string parametro2, string parametro3, string parametro4, string valor, string valor2, string valor3, string valor4, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, parametro2, parametro3, parametro4, valor, valor2, valor3, valor4, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string valor1, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, valor1, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string valor1, string valor2, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //-----------------------------****------------------------------------------------------------------------------------------------------------------------------------------
        public void Consultar_Total_Visitas(ref Comun ObjComun)
        {
            try
            {
                CD_Comun CDComun = new CD_Comun();
                CDComun.Consultar_Total_Visitas(ref ObjComun);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string valor1)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, valor1);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string valor1, string valor2)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, valor1, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string valor, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, valor);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaCombo(string SP, ref DropDownList DDL, string parametro, string parametro2, string valor, string valor2, ref List<Comun> Etiquetas)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro, parametro2, valor, valor2);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";

                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void HideColumns(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                grdView.FooterRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }

        public void HideEncabezado(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                //grdView.FooterRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;                
            }
        }
        public void VerificaTextoMensajeError(ref string Mensaje)
        {
            Mensaje = Mensaje.Replace("\r", "");
            Mensaje = Mensaje.Replace("\n", "");
            Mensaje = Mensaje.Replace("'", "");
            if (Mensaje.Contains("ORA-28000"))
                Mensaje = "En mantenimiento...<br>Disculpe las molestias, estamos realizando tareas de mantenimiento en este momento, volveremos a estar en línea en breve!";

            if (Mensaje.Length >= 70)
                Mensaje.Substring(0, 45);

        }
        public void EnvioCorreo(ref System.Net.Mail.MailMessage mmsg, string Asunto, string Contenido, string DirCorreo, ref string Error)
        {


            /*-------------------------MENSAJE DE CORREO----------------------*/
            //System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();  //Creamos un nuevo Objeto de mensaje            
            mmsg.To.Add(DirCorreo); //Direccion de correo electronico a la que queremos enviar el mensaje


            //Asunto
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            mmsg.Body = Contenido;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("sysweb@unach.mx");


            /*-------------------------CLIENTE DE CORREO----------------------*/
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("sysweb@unach.mx", "cfgdfsgcqsxrnioo");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                Error = (ex.Message);
            }

        }
        public void EnvioCorreoAdjunto(ref System.Net.Mail.MailMessage mmsg, List<CajaFactura> ListArch, string Asunto, string Contenido, string DirCorreo, ref string Error)
        {


            /*-------------------------MENSAJE DE CORREO----------------------*/
            //System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();  //Creamos un nuevo Objeto de mensaje            
            mmsg.To.Add(DirCorreo); //Direccion de correo electronico a la que queremos enviar el mensaje


            //Asunto
            mmsg.Subject = Asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Cuerpo del Mensaje
            mmsg.Body = Contenido;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            //mmsg.From = new System.Net.Mail.MailAddress("facturacion@unach.mx");
            mmsg.From = new System.Net.Mail.MailAddress("sysweb@unach.mx");

            // Create  the file attachment for this e-mail message.
            for (int i = 0; i < ListArch.Count; i++)
            {
                //if (ListArch[i].Ruta != null)
                if (ListArch[i].NombreArchivo != null)
                {

                    string Ruta = AppDomain.CurrentDomain.BaseDirectory + "/ArchivosFacturas/";
                    Ruta = Ruta + ListArch[i].NombreArchivo;
                    //Attachment data = new Attachment(GetStreamFile(ListArch[i].Ruta), Path.GetFileName(ListArch[i].Ruta), "application/pdf");
                    Attachment data = new Attachment(GetStreamFile(Ruta), Path.GetFileName(Ruta), "application/pdf");
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(Ruta);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(Ruta);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(Ruta);
                    // Add the file attachment to this e-mail message.
                    mmsg.Attachments.Add(data);
                    //Ruta = AppDomain.CurrentDomain.BaseDirectory + "/Facturas/PDF/";
                }
            }

            /*-------------------------CLIENTE DE CORREO----------------------*/
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
     //       cliente.Credentials =
     //new System.Net.NetworkCredential("facturacion@unach.mx", "Caja7504!");
            cliente.Credentials =
                new System.Net.NetworkCredential("sysweb@unach.mx", "cfgdfsgcqsxrnioo");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                Error = (ex.Message);
            }

        }
        public Stream GetStreamFile(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                return memStream;
            }
        }
        public void Consultar_Observaciones(string Usuario, int Id_Sistema, string TipoUsuario, ref string observaciones, string Usu_Central, ref string Verificador)
        {
            try
            {
                CD_Comun CDComun = new CD_Comun();
                CDComun.Consultar_Observaciones(Usuario, Id_Sistema, TipoUsuario, ref observaciones, Usu_Central, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LlenaLista(string SP, ref ListBox ListBox, string parametro1, string valor1, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaLista(SP, ref Lista, parametro1, valor1, UsuBD);
                ListBox.Items.Clear();
                if (Lista.Count > 0)
                {
                    ListBox.DataSource = Lista;
                    ListBox.DataValueField = "IdStr";
                    ListBox.DataTextField = "Descripcion";
                    ListBox.DataBind();
                }
                else
                {
                    ListBox.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaLista(string SP, ref ListBox ListBox, string parametro1, string valor1)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaLista(SP, ref Lista, parametro1, valor1);
                ListBox.Items.Clear();
                if (Lista.Count > 0)
                {
                    ListBox.DataSource = Lista;
                    ListBox.DataValueField = "IdStr";
                    ListBox.DataTextField = "Descripcion";
                    ListBox.DataBind();
                }
                else
                {
                    ListBox.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaLista(string SP, ref ListBox ListBox, string parametro1, string parametro2, string valor1, string valor2, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaLista(SP, ref Lista, parametro1, parametro2, valor1, valor2, UsuBD);
                ListBox.Items.Clear();
                if (Lista.Count > 0)
                {
                    ListBox.DataSource = Lista;
                    ListBox.DataValueField = "IdStr";
                    ListBox.DataTextField = "Descripcion";
                    ListBox.DataBind();
                }
                else
                {
                    ListBox.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaLista(string SP, ref ListBox ListBox, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaLista(SP, ref Lista, parametro1, parametro2, parametro3, valor1, valor2, valor3, UsuBD);
                ListBox.Items.Clear();
                if (Lista.Count > 0)
                {
                    ListBox.DataSource = Lista;
                    ListBox.DataValueField = "IdStr";
                    ListBox.DataTextField = "Descripcion";
                    ListBox.DataBind();
                }
                else
                {
                    ListBox.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //--AGRUPA ELEMENTOS EN COMBO
        public void LlenaComboG(string SP, ref GroupDropDownList DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaComboG(string SP, ref GroupDropDownList DDL, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaComboG(string SP, ref GroupDropDownList DDL, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaComboG(string SP, ref GroupDropDownList DDL, string parametro, string valor, ref List<Comun> Etiquetas, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista, parametro, valor, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    Etiquetas = Lista;
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaComboG(string SP, ref GroupDropDownList DDL, string parametro1, string valor1)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista, parametro1, valor1);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenaComboG(string SP, ref GroupDropDownList DDL, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4, string UsuBD)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaCombo(SP, ref Lista, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4, UsuBD);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataBind();

                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //--

        //--AGRUPA ELEMENTOS EN LISTAS
        public void LlenaListaG(string SP, ref GroupListBox DDL)
        {
            try
            {
                List<Comun> Lista = new List<Comun>();
                CD_Comun CDComun = new CD_Comun();
                CDComun.LlenaComboG(SP, ref Lista);
                DDL.Items.Clear();
                if (Lista.Count > 0)
                {
                    DDL.DataSource = Lista;
                    DDL.DataValueField = "IdStr";
                    DDL.DataTextField = "Descripcion";
                    DDL.DataGroupField = "Clasificacion";
                    DDL.DataBind();
                }
                else
                {
                    DDL.Items.Add("La opción no contiene datos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //--

        //--GRAFICAS
        public void Graficas(string SP, string Usuario, ref string[] datosX, ref int[] datosY, string UsuBD)
        {
            try
            {
                CD_Comun CDComun = new CD_Comun();
                CDComun.Graficas(SP, Usuario, ref datosX, ref datosY, UsuBD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetSHA256(string Signature)
        {
            string message;
            string key;
            key = "MUunlItniApcaagUotscBHainac2o0mxe1r1";
            message = Signature; //Signature.ToLower();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(key);

            HMACMD5 hmacmd5 = new HMACMD5(keyByte);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = encoding.GetBytes(message);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            string Order = ByteToString(hashmessage);
            Order = Order.ToLower();
            return Order;
        }

        public string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }

        public byte[] ConversionImagen(string nombrearchivo)
        {



            //string imagePathFolder = System.Configuration.ConfigurationManager.AppSettings["ImagePathFolder"]; // recuperar de configuración la carpeta de las imágenes
            //FileStream fs = new FileStream(System.IO.Path.Combine(imagePathFolder, nombrearchivo), FileMode.Open, FileAccess.Read); // acceder al archivo de la carpeta de las imágenes

            FileStream fs = new FileStream(nombrearchivo, FileMode.Open, FileAccess.Read);

            // Declaramos un lector binario para pasar la imagen
            // a bytes
            BinaryReader br = new BinaryReader(fs);
            byte[] imagen = new byte[(int)fs.Length];
            br.Read(imagen, 0, (int)fs.Length);
            br.Close();
            fs.Close();
            return imagen;
        }

        

    }
    [ToolboxData("<{0}:GroupDropDownList runat=server></{0}:GroupDropDownList>")]
    public class GroupDropDownList : DropDownList
    {
        [DefaultValue(""), Category("Data")]
        public virtual string DataGroupField
        {
            get
            {
                object obj = ViewState["DataGroupField"];
                if (obj != null)
                {
                    return (string)obj;
                }
                return string.Empty;
            }
            set
            {
                ViewState["DataGroupField"] = value;
            }
        }
        private bool IsGroupHasEnabledItems(string groupName)
        {
            ListItemCollection items = Items;
            for (int i = 0; i < items.Count; i++)
            {
                ListItem item = items[i];
                if (item.Attributes["DataGroupField"].Equals(groupName) && item.Enabled)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            ListItemCollection items = Items;
            int itemCount = Items.Count;
            string curGroup = String.Empty;
            bool bSelected = false;

            if (itemCount <= 0)
            {
                return;
            }

            for (int i = 0; i < itemCount; i++)
            {
                ListItem item = items[i];
                string itemGroup = item.Attributes["DataGroupField"];
                if (itemGroup != null && itemGroup != curGroup && IsGroupHasEnabledItems(itemGroup))
                {
                    if (curGroup != String.Empty)
                    {
                        writer.WriteEndTag("optgroup");
                        writer.WriteLine();
                    }

                    curGroup = itemGroup;
                    writer.WriteBeginTag("optgroup");
                    writer.WriteAttribute("label", curGroup, true);
                    writer.Write('>');
                    writer.WriteLine();
                }
                // we don't want to render disabled items
                if (item.Enabled)
                {
                    writer.WriteBeginTag("option");
                    if (item.Selected)
                    {
                        if (bSelected)
                        {
                            throw new HttpException("Cant_Multiselect_In_DropDownList");
                        }
                        bSelected = true;
                        writer.WriteAttribute("selected", "selected", false);
                    }

                    writer.WriteAttribute("value", item.Value, true);
                    writer.Write('>');
                    HttpUtility.HtmlEncode(item.Text, writer);
                    writer.WriteEndTag("option");
                    writer.WriteLine();
                }
            }
            if (curGroup != String.Empty)
            {
                writer.WriteEndTag("optgroup");
                writer.WriteLine();
            }
        }

        /// <summary>
        /// Perform data binding logic that is associated with the control
        /// </summary>
        /// <param name="e">An EventArgs object that contains the event data</param>
        protected override void OnDataBinding(EventArgs e)
        {
            // Call base method to bind data
            base.OnDataBinding(e);

            if (DataGroupField == String.Empty)
            {
                return;
            }
            // For each Item add the attribute "DataGroupField" with value from the datasource
            IEnumerable dataSource = GetResolvedDataSource(DataSource, DataMember);
            if (dataSource != null)
            {
                ListItemCollection items = Items;
                int i = 0;

                string groupField = DataGroupField;
                foreach (object obj in dataSource)
                {
                    string groupFieldValue = DataBinder.GetPropertyValue(obj, groupField, null);
                    ListItem item = items[i];
                    item.Attributes.Add("DataGroupField", groupFieldValue);
                    i++;
                }
            }

        }

        /// <summary>
        /// This is copy of the internal ListControl method
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataMember"></param>
        /// <returns></returns>
        private IEnumerable GetResolvedDataSource(object dataSource, string dataMember)
        {
            if (dataSource != null)
            {
                var source1 = dataSource as IListSource;
                if (source1 != null)
                {
                    IList list1 = source1.GetList();
                    if (!source1.ContainsListCollection)
                    {
                        return list1;
                    }
                    var list = list1 as ITypedList;
                    if (list != null)
                    {
                        var list2 = list;
                        PropertyDescriptorCollection collection1 = list2.GetItemProperties(new PropertyDescriptor[0]);
                        if ((collection1 == null) || (collection1.Count == 0))
                        {
                            throw new HttpException("ListSource_Without_DataMembers");
                        }

                        PropertyDescriptor descriptor1 = collection1[0];

                        if (!string.IsNullOrWhiteSpace(dataMember))
                        {
                            descriptor1 = collection1.Find(dataMember, true);
                        }

                        if (descriptor1 != null)
                        {
                            object obj1 = list1[0];
                            object obj2 = descriptor1.GetValue(obj1);
                            var enumerable = obj2 as IEnumerable;
                            if (enumerable != null)
                            {
                                return enumerable;
                            }
                        }
                        throw new HttpException("ListSource_Missing_DataMember");
                    }
                }
                var source = dataSource as IEnumerable;
                if (source != null)
                {
                    return source;
                }
            }
            return null;
        }
        #region Internal behaviour
        /// <summary>
        /// Saves the state of the view.
        /// </summary>
        protected override object SaveViewState()
        {
            // Create an object array with one element for the CheckBoxList's
            // ViewState contents, and one element for each ListItem in skmCheckBoxList
            var state = new object[Items.Count + 1];

            object baseState = base.SaveViewState();
            state[0] = baseState;

            // Now, see if we even need to save the view state
            bool itemHasAttributes = false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Attributes.Count == 0) continue;

                itemHasAttributes = true;

                // Create an array of the item's Attribute's keys and values
                var attribKv = new object[Items[i].Attributes.Count * 2];
                int k = 0;
                foreach (string key in Items[i].Attributes.Keys)
                {
                    attribKv[k++] = key;
                    attribKv[k++] = Items[i].Attributes[key];
                }

                state[i + 1] = attribKv;
            }

            // return either baseState or state, depending on if any ListItems had attributes
            return itemHasAttributes ? state : baseState;
        }

        /// <summary>
        /// Loads the state of the view.
        /// </summary>
        /// <param name="savedState">State of the saved.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState == null) return;

            // see if savedState is an object or object array
            var objects = savedState as object[];
            if (objects != null)
            {
                // we have an array of items with attributes
                object[] state = objects;
                base.LoadViewState(state[0]); // load the base state

                for (int i = 1; i < state.Length; i++)
                {
                    if (state[i] != null)
                    {
                        // Load back in the attributes
                        var attribKv = (object[])state[i];
                        for (int k = 0; k < attribKv.Length; k += 2)
                            Items[i - 1].Attributes.Add(attribKv[k].ToString(),
                                attribKv[k + 1].ToString());
                    }
                }
            }
            else
            {
                // we have just the base state
                base.LoadViewState(savedState);
            }
        }
        #endregion
    }

    [ToolboxData("<{0}:GroupListBox runat=server></{0}:GroupListBox>")]
    public class GroupListBox : ListBox
    {
        [DefaultValue(""), Category("Data")]
        public virtual string DataGroupField
        {
            get
            {
                object obj = ViewState["DataGroupField"];
                if (obj != null)
                {
                    return (string)obj;
                }
                return string.Empty;
            }
            set
            {
                ViewState["DataGroupField"] = value;
            }
        }
        private bool IsGroupHasEnabledItems(string groupName)
        {
            ListItemCollection items = Items;
            for (int i = 0; i < items.Count; i++)
            {
                ListItem item = items[i];
                if (item.Attributes["DataGroupField"].Equals(groupName) && item.Enabled)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            ListItemCollection items = Items;
            int itemCount = Items.Count;
            string curGroup = String.Empty;
            bool bSelected = false;

            if (itemCount <= 0)
            {
                return;
            }

            for (int i = 0; i < itemCount; i++)
            {
                ListItem item = items[i];
                string itemGroup = item.Attributes["DataGroupField"];
                if (itemGroup != null && itemGroup != curGroup && IsGroupHasEnabledItems(itemGroup))
                {
                    if (curGroup != String.Empty)
                    {
                        writer.WriteEndTag("optgroup");
                        writer.WriteLine();
                    }

                    curGroup = itemGroup;
                    writer.WriteBeginTag("optgroup");
                    writer.WriteAttribute("label", curGroup, true);
                    writer.Write('>');
                    writer.WriteLine();
                }
                // we don't want to render disabled items
                if (item.Enabled)
                {
                    writer.WriteBeginTag("option");
                    if (item.Selected)
                    {
                        if (bSelected)
                        {
                            throw new HttpException("Cant_Multiselect_In_DropDownList");
                        }
                        bSelected = true;
                        writer.WriteAttribute("selected", "selected", false);
                    }

                    writer.WriteAttribute("value", item.Value, true);
                    writer.Write('>');
                    HttpUtility.HtmlEncode(item.Text, writer);
                    writer.WriteEndTag("option");
                    writer.WriteLine();
                }
            }
            if (curGroup != String.Empty)
            {
                writer.WriteEndTag("optgroup");
                writer.WriteLine();
            }
        }

        /// <summary>
        /// Perform data binding logic that is associated with the control
        /// </summary>
        /// <param name="e">An EventArgs object that contains the event data</param>
        protected override void OnDataBinding(EventArgs e)
        {
            // Call base method to bind data
            base.OnDataBinding(e);

            if (DataGroupField == String.Empty)
            {
                return;
            }
            // For each Item add the attribute "DataGroupField" with value from the datasource
            IEnumerable dataSource = GetResolvedDataSource(DataSource, DataMember);
            if (dataSource != null)
            {
                ListItemCollection items = Items;
                int i = 0;

                string groupField = DataGroupField;
                foreach (object obj in dataSource)
                {
                    string groupFieldValue = DataBinder.GetPropertyValue(obj, groupField, null);
                    ListItem item = items[i];
                    item.Attributes.Add("DataGroupField", groupFieldValue);
                    i++;
                }
            }

        }

        /// <summary>
        /// This is copy of the internal ListControl method
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataMember"></param>
        /// <returns></returns>
        private IEnumerable GetResolvedDataSource(object dataSource, string dataMember)
        {
            if (dataSource != null)
            {
                var source1 = dataSource as IListSource;
                if (source1 != null)
                {
                    IList list1 = source1.GetList();
                    if (!source1.ContainsListCollection)
                    {
                        return list1;
                    }
                    var list = list1 as ITypedList;
                    if (list != null)
                    {
                        var list2 = list;
                        PropertyDescriptorCollection collection1 = list2.GetItemProperties(new PropertyDescriptor[0]);
                        if ((collection1 == null) || (collection1.Count == 0))
                        {
                            throw new HttpException("ListSource_Without_DataMembers");
                        }

                        PropertyDescriptor descriptor1 = collection1[0];

                        if (!string.IsNullOrWhiteSpace(dataMember))
                        {
                            descriptor1 = collection1.Find(dataMember, true);
                        }

                        if (descriptor1 != null)
                        {
                            object obj1 = list1[0];
                            object obj2 = descriptor1.GetValue(obj1);
                            var enumerable = obj2 as IEnumerable;
                            if (enumerable != null)
                            {
                                return enumerable;
                            }
                        }
                        throw new HttpException("ListSource_Missing_DataMember");
                    }
                }
                var source = dataSource as IEnumerable;
                if (source != null)
                {
                    return source;
                }
            }
            return null;
        }
        #region Internal behaviour
        /// <summary>
        /// Saves the state of the view.
        /// </summary>
        protected override object SaveViewState()
        {
            // Create an object array with one element for the CheckBoxList's
            // ViewState contents, and one element for each ListItem in skmCheckBoxList
            var state = new object[Items.Count + 1];

            object baseState = base.SaveViewState();
            state[0] = baseState;

            // Now, see if we even need to save the view state
            bool itemHasAttributes = false;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Attributes.Count == 0) continue;

                itemHasAttributes = true;

                // Create an array of the item's Attribute's keys and values
                var attribKv = new object[Items[i].Attributes.Count * 2];
                int k = 0;
                foreach (string key in Items[i].Attributes.Keys)
                {
                    attribKv[k++] = key;
                    attribKv[k++] = Items[i].Attributes[key];
                }

                state[i + 1] = attribKv;
            }

            // return either baseState or state, depending on if any ListItems had attributes
            return itemHasAttributes ? state : baseState;
        }

        /// <summary>
        /// Loads the state of the view.
        /// </summary>
        /// <param name="savedState">State of the saved.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState == null) return;

            // see if savedState is an object or object array
            var objects = savedState as object[];
            if (objects != null)
            {
                // we have an array of items with attributes
                object[] state = objects;
                base.LoadViewState(state[0]); // load the base state

                for (int i = 1; i < state.Length; i++)
                {
                    if (state[i] != null)
                    {
                        // Load back in the attributes
                        var attribKv = (object[])state[i];
                        for (int k = 0; k < attribKv.Length; k += 2)
                            Items[i - 1].Attributes.Add(attribKv[k].ToString(),
                                attribKv[k + 1].ToString());
                    }
                }
            }
            else
            {
                // we have just the base state
                base.LoadViewState(savedState);
            }
        }
        #endregion
    }

}
