using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos.Form
{
    public partial class FrmAlumnos_Clientes : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;        
        Int32[] Celdas = new Int32[] { 6, 8, 9 };
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)            
                Inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "GridAlumnos", "Alumnos();", true);
        }
        
        #region <Botones y Eventos>        
       
        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {

            //pnlPrincipal.Visible = false;
            btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteAlumnos('" + ddlDependencia.SelectedValue + "','" + ddlNivel.SelectedValue + "');", true);

        }
        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            //pnlPrincipal.Visible = false;
            btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteAlumnosExcel('" + ddlDependencia.SelectedValue + "','" + ddlNivel.SelectedValue + "');", true);
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            //pnlPrincipal.Visible = true;
            btnRegresar.Visible = false;
            
        }
        protected void grvAlumnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }
        protected void grvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlumnos.PageIndex = 0;
            grvAlumnos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCarrera.SelectedValue == "000000")
            {
                lblOtraCarrera.Visible = true;
                txtCarrera.Visible = true;
                txtCarrera.Text = string.Empty;
            }
            else
            {
                lblOtraCarrera.Visible = false;
                txtCarrera.Visible = false;
                txtCarrera.Text = ddlCarrera.SelectedItem.Text;
            }
        }
        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;    
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera0, "p_nivel", "p_dependencia", ddlNivel.SelectedValue, ddlDependencia.SelectedValue, "INGRESOS");
                if (ddlCarrera0.Items.Count >= 1)
                {
                    string valorCarrera=ddlCarrera0.SelectedValue;
                    ddlCarrera0.Items.RemoveAt(0);                    
                    ddlCarrera0.Items.Insert(0, new ListItem("TODAS", valorCarrera));                    
                }
                else
                {
                    ddlCarrera.DataSource = null;
                    ddlCarrera.DataBind();
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblMsj.Text = string.Empty;            
        }
        protected void ddlDependencia_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "p_nivel", "p_dependencia", ddlNivel_D.SelectedValue, ddlDependencia_D.SelectedValue, "INGRESOS");
                ddlCarrera_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        #endregion


        #region <Funciones y Sub>
        private void Inicializar()
        {
            CargarCombos();
            
            if (SesionUsu.Exento == 'S')
            {
                SesionUsu.Editar = 0;
                MultiView1.ActiveViewIndex = 1;
                //pnlDatos_Alumno.Visible = true;
                //pnlPrincipal.Visible = false;
                ddlDependencia_D.SelectedValue = SesionUsu.Dependencia;
                ddlDependencia_D_SelectedIndexChanged(null,null);
                ddlNivel_D.SelectedValue = SesionUsu.NivelEstudio;
                txtMatricula.Text = SesionUsu.Matricula;
            }
            txtBusqueda.Focus();
            MultiView1.ActiveViewIndex = 0;
        }
        private void CargarCombos()
        {
            Verificador = string.Empty;
            try
            {
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                //CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_DependenciasAlumnos", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                ddlDependencia_SelectedIndexChanged(null, null);                
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel_D, "INGRESOS");
                //CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_UR", ref ddlDependencia_D, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_DependenciasAlumnos", ref ddlDependencia_D, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
        private void GuardarDatos()
        {
            
            ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
            ObjAlumno.Nombre = txtNombre.Text;
            ObjAlumno.APaterno = txtPaterno.Text;
            ObjAlumno.AMaterno = txtMaterno.Text;            
            ObjAlumno.Semestre = txtSemestre.Text;
            ObjAlumno.Grupo = txtGrupo.Text;
            ObjAlumno.Carrera = ddlCarrera.SelectedValue;
            if (ddlCarrera.SelectedValue != "000000")
                txtCarrera.Text = ddlCarrera.SelectedItem.Text;
            ObjAlumno.DescCarrera = txtCarrera.Text;
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            ObjAlumno.Nivel = ddlNivel_D.SelectedValue;
            ObjAlumno.Dependencia = ddlDependencia_D.SelectedValue;
            ObjAlumno.Correo = txtCorreo.Text;
            ObjAlumno.Genero = Convert.ToChar(rdoGenero.SelectedValue);
            if (chkActivo.Checked)
                ObjAlumno.StatusMatricula = "A";
            else
                ObjAlumno.StatusMatricula = "C";
            try
            {

                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                    CNAlumno.AlumnoInsertar(ref ObjAlumno, ref Verificador);
                else
                {
                    ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.Rows[grvAlumnos.SelectedIndex].Cells[8].Text);
                    CNAlumno.AlumnoEditar(ref ObjAlumno, ref Verificador);
                }

                if (Verificador == "0")
                {
                    //lblMsj.Text = "Los datos se guardaron correctamente.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";
                    if (SesionUsu.Exento == 'S')
                    {
                        SesionUsu.Matricula = ObjAlumno.Matricula;
                        SesionUsu.NivelEstudio = ddlNivel_D.SelectedValue;
                        SesionUsu.Dependencia = ddlDependencia_D.SelectedValue;
                        Response.Redirect("FrmExentos.aspx", false);

                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 0;
                        //pnlDatos_Alumno.Visible = false;
                        //pnlPrincipal.Visible = true;
                        Nuevo();
                        CargarGrid();
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 40) + "');", true);  //lblMsj.Text = ex.Message;
                    //lblMsj.Text = Verificador;
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0,40) + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private List<Alumno> GetList()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Dependencia = ddlDependencia.SelectedValue;
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                ObjAlumno.Carrera = ddlCarrera0.SelectedValue;
                ObjAlumno.StatusMatricula = ddlStatus.SelectedValue;
                CNAlumno.ConsultarAlumno(ref ObjAlumno, txtBusqueda.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGrid()
        {
            Verificador = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                grvAlumnos.DataSource = dt;
                grvAlumnos.DataSource = GetList();
                grvAlumnos.DataBind();
                if (grvAlumnos.Rows.Count > 0)
                    CNComun.HideColumns(grvAlumnos, Celdas);

            }
            catch (Exception ex)
            {
                Verificador= ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }
        private void Nuevo()
        {
            //lblMsj.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtSemestre.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            rdoGenero.SelectedValue = "M";             
            ddlNivel_D.SelectedValue = ddlNivel.SelectedValue;
            ddlDependencia_D.SelectedValue = ddlDependencia.SelectedValue;
            ddlDependencia_D_SelectedIndexChanged(null, null);            
        }       
        #endregion

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //lblMsj.Text = string.Empty;
            CargarGrid();
        }

        

        //protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        //{
        //    lblMsj.Text = string.Empty;
        //    pnlDatos_Alumno.Visible = true;
        //    pnlPrincipal.Visible = false;
        //    SesionUsu.Editar = 0;
        //    txtMatricula.Enabled = true;
        //    Nuevo();
        //}

        protected void grvAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                int fila = e.RowIndex;
                ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.Rows[fila].Cells[8].Text);
                CNAlumno.AlumnoEliminar(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                {                                        
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

       

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            imgBttnBuscar.Focus();
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //lblMsj.Text = string.Empty;
            CargarGrid();
        }

        
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlNivel_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDependencia_D_SelectedIndexChanged(null, null);
        }

        protected void ddlNivel_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddlDependencia_SelectedIndexChanged(null, null);
        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;            
            try
            {
                grvAlumnos.SelectedIndex = row.RowIndex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupCorreo", "$('#modalCorreo').modal('show')", true);
                //modalCorreo.Show();
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void bttnCorreo_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            string asunto = string.Empty;
            string contenido = string.Empty;
            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Activacion_Cuenta.aspx?ActCtaM=" + grvAlumnos.SelectedRow.Cells[2].Text + "&ActCtaN=" + grvAlumnos.SelectedRow.Cells[1].Text;
                asunto = "Confirma tu correo/Activa tu cuenta - SYSWEB";
                contenido = "<img src='https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png'><br /><div align=center><font size='4'><a href=\'" + ruta + "'>Pagos Referenciados SYSWEB</a></font></div><br /><br />" + "<font size='2'>Se ha generado un usuario para el Sistema de Pagos Referenciados SYSWEB con esta dirección de correo electrónico.</br>" +
                            "Si tú hiciste esta solicitud, haz clic en el enlace de abajo para confirmar tu dirección de correo electrónico, activar tu cuenta y conlcuir tu proceso de registro:</br>" +
                            "<a href=\'" + ruta + "'>Confirmar tu dirección de correo electrónico </a></br></br>" +
                            "Si tú no realizaste esta solicitud, ignora este correo electrónico y no recibirás mas notificaciones al respecto.</br></br>" +
                            "<strong>SYSWEB - DIRECCIÓN DE SISTEMAS DE INFORMACIÓN ADMINISTRATIVA</strong>" +
                            "<br />Teléfono - (961) 617 80 00, Ext.: 5503, 5501, 5508 y 5509<br /><br /></font>";
                string MsjError = string.Empty;
                CNComun.EnvioCorreo(ref mmsg, asunto, contenido, txtCorreo0.Text, ref MsjError);
                if (MsjError != string.Empty)
                {
                    MsjError = MsjError.Substring(0, 30);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void bttnCancelarCorreo_Click(object sender, EventArgs e)
        {

        }

        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
            //lblMsj.Text = string.Empty;
            MultiView1.ActiveViewIndex = 1;
            //pnlDatos_Alumno.Visible = true;
            //pnlPrincipal.Visible = false;
            SesionUsu.Editar = 0;
            txtMatricula.Enabled = true;
            Nuevo();

        }

       

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBttn = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvAlumnos.SelectedIndex = row.RowIndex;


            Verificador = string.Empty;
            txtMatricula.Enabled = true;
            try
            {
                //int v = e.NewSelectedIndex;
                ObjAlumno.Matricula = grvAlumnos.SelectedRow.Cells[2].Text;
                ObjAlumno.Dependencia = grvAlumnos.SelectedRow.Cells[0].Text; //ddlDependencia.SelectedValue;
                ObjAlumno.Nivel = grvAlumnos.SelectedRow.Cells[1].Text; //ddlNivel.SelectedValue;
                ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[8].Text);
                CNAlumno.ConsultarAlumnoSel(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    MultiView1.ActiveViewIndex = 1;
                    //pnlDatos_Alumno.Visible = true;
                    //pnlPrincipal.Visible = false;
                    SesionUsu.Editar = 1;

                    ddlNivel_D.SelectedValue = ObjAlumno.Nivel; //ddlNivel.SelectedValue;
                    ddlDependencia_D.SelectedValue = ObjAlumno.Dependencia; //ddlDependencia.SelectedValue;
                    ddlDependencia_D_SelectedIndexChanged(null, null);
                    try
                    {
                        ddlCarrera.SelectedValue = ObjAlumno.Carrera;
                    }
                    catch (Exception)
                    {
                        ddlCarrera.SelectedValue = "000000";
                    }
                    ddlCarrera_SelectedIndexChanged(null, null);
                    txtCarrera.Text = ObjAlumno.DescCarrera;
                    txtMatricula.Text = grvAlumnos.SelectedRow.Cells[2].Text;
                    txtNombre.Text = ObjAlumno.Nombre;
                    txtPaterno.Text = ObjAlumno.APaterno;
                    txtMaterno.Text = ObjAlumno.AMaterno;
                    txtSemestre.Text = ObjAlumno.Semestre;
                    txtGrupo.Text = ObjAlumno.Grupo;
                    rdoGenero.SelectedValue = Convert.ToString(ObjAlumno.Genero);
                    txtCorreo.Text = ObjAlumno.Correo;

                    if (ObjAlumno.StatusMatricula == "A")
                        chkActivo.Checked = true;
                    else
                        chkActivo.Checked = false;
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            //pnlDatos_Alumno.Visible = true;
            //pnlPrincipal.Visible = false;
            SesionUsu.Editar = 0;
            txtMatricula.Enabled = true;
            Nuevo();
        }

        protected void linkBttnSalir_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Nuevo();
        }

        protected void linkBtnnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
    }
}