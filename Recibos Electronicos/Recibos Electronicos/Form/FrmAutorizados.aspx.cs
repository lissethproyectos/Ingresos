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
    public partial class FrmAutorizados : System.Web.UI.Page
    {

        #region <Variables>
        string Verificador = string.Empty;
        int[] Celdas = new int[3];

        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();        
        private static List<Comun> ListEventos = new List<Comun>();
        List<Alumno> ListAlumnos = new List<Alumno>();

        #endregion

        #region <Funciones y Sub>
        private void Inicializar()
        {
            Session["DatosGridUsuarios"] = null;
            CNComun.LlenaCombo("pkg_pagos.Obt_Eventos_Generico", ref DDLEvento, "p_usuario", "p_todos", SesionUsu.Usu_Nombre.ToString(), "N", ref ListEventos, "INGRESOS");
            if (SesionUsu.Evento != "0")
            {
                DDLEvento.SelectedValue = SesionUsu.Evento;
                //DDLEvento_SelectedIndexChanged(null, null);
            }

            CargarGrid();            
        }       
        private List<Alumno> GetList()
        {
            Session["DatosGridUsuarios"] = null;
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Evento = DDLEvento.SelectedValue;                
                CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref List);
                Session["DatosGridUsuarios"] = List;
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGrid()
        {            
                grdUsuarios.DataSource = null;
                grdUsuarios.DataBind();
                DataTable dt = new DataTable();
                grdUsuarios.DataSource = dt;
                grdUsuarios.DataSource = GetList();
                grdUsuarios.DataBind();
                

                if (grdUsuarios.Rows.Count > 0)
                {


                    lblTotal.Text = ObjAlumno.TotalMatricula.ToString();
                    lblActivo.Text = ObjAlumno.NoActivo.ToString();
                    lblSuspendido.Text = ObjAlumno.NoSuspendido.ToString();
                }
                else
                {
                    lblTotal.Text = string.Empty;
                    lblActivo.Text = string.Empty;
                    lblSuspendido.Text = string.Empty;
                }           
        }
        private void Nuevo()
        {

            chkActivo.Checked = true;

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (Convert.ToString(Request.QueryString["Evento"]) != string.Empty)
                SesionUsu.Evento = Convert.ToString(Request.QueryString["Evento"]);
            else
                SesionUsu.Evento = "0";

            if (!IsPostBack)                           
                Inicializar();
            
        }
        #region <Botones y Eventos>
        protected void btnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Nuevo();
            //grdUsuarios.SelectedIndex = -1;
        }
        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMsj.Text = string.Empty;
            try
            {
                grdUsuarios.PageIndex = 0;
                grdUsuarios.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void grdUsuarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblMsj.Text = string.Empty;
            try
            {
                int v = e.NewSelectedIndex;
                ObjAlumno.Matricula = grdUsuarios.Rows[v].Cells[0].Text;
                ObjAlumno.UsuNombre = grdUsuarios.Rows[v].Cells[1].Text;
                ObjAlumno.Evento = DDLEvento.SelectedValue;
                CNAlumno.ActualizarStatusAutorizado(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {


            ObjAlumno.Evento = DDLEvento.SelectedValue;
            ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
            ObjAlumno.Nombre = txtNombre.Text;
            //ObjAlumno.UsuNombre = SesionUsu.UsuNombre;
            if (chkActivo.Checked == true)
                ObjAlumno.StatusMatricula = "A";
            else
                ObjAlumno.StatusMatricula = "B";
            //if (chkExterno.Checked == true)
            //    ObjAlumno.TipoPersonaStr = "S";
            //else
            //    ObjAlumno.TipoPersonaStr = "N";
            //ObjAlumno.Nivel = DDLNivel.SelectedValue;
            //ObjAlumno.Sede = DDLSede.SelectedValue;
            try
            {

                Verificador = string.Empty;

                CNAlumno.AutorizadoInsertar(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    lblMsj.Text = "Los datos se guardaron correctamente.";
                }

                else
                {
                    lblMsj.Text = Verificador;
                }


                Nuevo();
                CargarGrid();
                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            try
            {                
                ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                ObjAlumno.Evento = DDLEvento.SelectedValue;

                CNAlumno.ConsultarAlumnoAutorizadoSel(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    //SesionUsu  = txtMatricula.Text.ToUpper();
                    txtNombre.Text = ObjAlumno.Nombre;
                    lblMsj.Text = "";
                }
                else
                {
                    txtNombre.Text = string.Empty;
                    lblMsj.Text = Verificador;                    
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void DDLEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            try
            {
                txtMatricula.Text = string.Empty;
                txtNombre.Text = string.Empty;
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        protected void chkExterno_CheckedChanged(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtNombre.Text = "";
            lblMsj.Text = string.Empty;
            //if (chkExterno.Checked)
            //{
            //    txtMatricula.Enabled = false;
            //    txtNombre.Enabled = true;

            //}
            //else
            //{
            //    txtMatricula.Enabled = true;
            //    txtNombre.Enabled = false;
            //}
        }
        private void txtBuscar_OnKeyPress(string ctrlName, string args)
        {
            lblMsj.Text = string.Empty;
            try
            {
                ListAlumnos = (List<Alumno>)Session["DatosGridUsuarios"];
                if (ListAlumnos.Count >= 1)
                {
                    var filteredCuentas = from c in ListAlumnos
                                          where c.Matricula.Contains(txtBuscar.Text.ToUpper())
                                          select c;

                    var content = filteredCuentas.ToList<Alumno>();

                    grdUsuarios.DataSource = content;
                    grdUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        #endregion



        protected void DDLSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            ObjAlumno.Evento = DDLEvento.SelectedValue;
            ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
            ObjAlumno.Nombre = txtNombre.Text;
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            ObjAlumno.ImageStatusMatricula = "Activo.PNG";
            if (chkActivo.Checked == true)
                ObjAlumno.StatusMatricula = "A";
            else
                ObjAlumno.StatusMatricula = "B";

            ObjAlumno.TipoPersonaStr = "N";
            ObjAlumno.Nivel = ListEventos[DDLEvento.SelectedIndex].EtiquetaDos; // DDLNivel.SelectedValue;
            ObjAlumno.Sede = "TUXTLA"; // DDLSede.SelectedValue;
            try
            {

                Verificador = string.Empty;

                CNAlumno.AutorizadoInsertarMatricula(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    lblMsj.Text = "Los datos se guardaron correctamente.";
                }

                else
                {
                    lblMsj.Text = Verificador;
                }

                txtMatricula.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtMatricula.Focus();
                Nuevo();
                CargarGrid();             
            }
            catch (Exception ex)
            {
                lblMsj.Text=ex.Message;
            }
        }

        protected void imgBttnBuscaMatricula_Click(object sender, ImageClickEventArgs e)
        {
            txtMatricula_TextChanged(null, null);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            try
            {
                ListAlumnos = (List<Alumno>)Session["DatosGridUsuarios"];
                if (ListAlumnos.Count >= 1)
                {
                    var filteredCuentas = from c in ListAlumnos
                                          where c.Matricula.Contains(txtBuscar.Text.ToUpper()) || c.Nombre.Contains(txtBuscar.Text.ToUpper())
                                          select c;

                    var content = filteredCuentas.ToList<Alumno>();

                    grdUsuarios.DataSource = content;
                    grdUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        //protected void txtBuscar_TextChanged(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    lblMsj.Text = string.Empty;
        //    try
        //    {
        //        ListAlumnos = (List<Alumno>)Session["DatosGridUsuarios"];
        //        if (ListAlumnos.Count >= 1)
        //        {
        //            var filteredCuentas = from c in ListAlumnos
        //                                  where c.Matricula.Contains(txtBuscar.Text.ToUpper())
        //                                  select c;

        //            var content = filteredCuentas.ToList<Alumno>();

        //            grdUsuarios.DataSource = content;
        //            grdUsuarios.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsj.Text = ex.Message;
        //    }
        //}
    }    
}