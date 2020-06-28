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
    public partial class FrmAlumnos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        int[] Celdas = new int[6];

        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        
        #region <Botones y Eventos>
        //protected void btnNuevo_Click(object sender, EventArgs e)
        //{
        //    lblMsj.Text = string.Empty;
        //    pnlDatos_Alumno.Visible = true;
        //    pnlPrincipal.Visible = false;
        //    SesionUsu.Editar = 0;
        //    txtMatricula.Enabled = true;
        //    Nuevo();

        //}
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlDatos_Alumno.Visible = false;
            pnlPrincipal.Visible = true;
            Nuevo();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();

        }
        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {

            pnlPrincipal.Visible = false;
            btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteAlumnos('" + ddlDependencia.SelectedValue + "','" + ddlNivel.SelectedValue + "');", true);

        }
        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            pnlPrincipal.Visible = false;
            btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteAlumnosExcel('" + ddlDependencia.SelectedValue + "','" + ddlNivel.SelectedValue + "');", true);
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Visible = true;
            btnRegresar.Visible = false;
            
        }
        protected void grvAlumnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lblMsj.Text = string.Empty;
            txtMatricula.Enabled = true;
            try
            {
                int v = e.NewSelectedIndex;
                ObjAlumno.Matricula = grvAlumnos.Rows[v].Cells[0].Text;
                ObjAlumno.Dependencia = grvAlumnos.Rows[v].Cells[7].Text; //ddlDependencia.SelectedValue;
                ObjAlumno.Nivel = grvAlumnos.Rows[v].Cells[8].Text; //ddlNivel.SelectedValue;
                ObjAlumno.IdPersona =Convert.ToInt32(grvAlumnos.Rows[v].Cells[6].Text);
                CNAlumno.ConsultarAlumnoSel(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    pnlDatos_Alumno.Visible = true;
                    pnlPrincipal.Visible = false;
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
                    txtMatricula.Text = grvAlumnos.Rows[v].Cells[0].Text;
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
                    //txtMatricula.Enabled = false;
                }
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
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
            //ddlStatus_SelectedIndexChanged(null, null);
        }
        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {            
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
                //lblMsj.Text = string.Empty;                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;


            }
        }
        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;            
        }
        protected void ddlDependencia_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "p_nivel", "p_dependencia", ddlNivel_D.SelectedValue, ddlDependencia_D.SelectedValue, "INGRESOS");
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "p_nivel", "p_dependencia", ddlNivel_D.SelectedValue, ddlDependencia_D.SelectedValue, "INGRESOS");
                ddlCarrera_SelectedIndexChanged(null, null);
                //if (ddlCarrera.Items.Count >= 1)
                //{
                //    string valorCarrera = ddlCarrera.SelectedValue;
                //    ddlCarrera.Items.RemoveAt(0);
                //    ddlCarrera.Items.Insert(0, new ListItem("--SIN ESPECIFICAR--", valorCarrera));
                //}
                //else
                //{
                //    ddlCarrera.DataSource = null;
                //    ddlCarrera.DataBind();
                //}
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
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
                pnlDatos_Alumno.Visible = true;
                pnlPrincipal.Visible = false;
                ddlDependencia_D.SelectedValue = SesionUsu.Dependencia;
                ddlDependencia_D_SelectedIndexChanged(null,null);
                ddlNivel_D.SelectedValue = SesionUsu.NivelEstudio;
                txtMatricula.Text = SesionUsu.Matricula;
            }
            txtBusqueda.Focus();
            //else
                //CargarGrid();
        }
        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                ddlDependencia_SelectedIndexChanged(null, null);                
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel_D, "INGRESOS");
                //ddlNivel_D.Items.RemoveAt(0);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia_D, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Escuelas_Externos", ref ddlDependencia_D, "p_nivel", "p_evento", "p_usuario", ddlNivel_D.SelectedValue, "ADMON", SesionUsu.Usu_Nombre, "INGRESOS");
                //ddlDependencia_D_SelectedIndexChanged(null, null);
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "INGRESOS");
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Carrera_Posgrado", ref ddlCarrera0, "INGRESOS");
                //if (ddlCarrera.SelectedValue == "000000")
                //{
                //    lblOtraCarrera.Visible = true;
                //    txtCarrera.Visible = true;
                //}
                //else
                //{
                //    lblOtraCarrera.Visible = false;
                //    txtCarrera.Visible = false;
                //    txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                //}
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
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
                    ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.Rows[grvAlumnos.SelectedIndex].Cells[6].Text);
                    CNAlumno.AlumnoEditar(ref ObjAlumno, ref Verificador);
                }

                if (Verificador == "0")
                {
                    lblMsj.Text = "Los datos se guardaron correctamente.";
                    if (SesionUsu.Exento == 'S')
                    {
                        SesionUsu.Matricula = ObjAlumno.Matricula;
                        SesionUsu.NivelEstudio = ddlNivel_D.SelectedValue;
                        SesionUsu.Dependencia = ddlDependencia_D.SelectedValue;
                        Response.Redirect("FrmExentos2.aspx", false);

                    }
                    else
                    {
                        pnlDatos_Alumno.Visible = false;
                        pnlPrincipal.Visible = true;
                        Nuevo();
                        CargarGrid();
                    }
                }

                else
                {
                    //pnlDatos_Alumno.Visible = false;
                    //pnlPrincipal.Visible = true;
                    //Nuevo();
                    //CargarGrid();
                    lblMsj.Text = Verificador;
                }



            }
            catch (Exception ex)
            {
                lblMsj.Text=ex.Message;
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
            try
            {
                DataTable dt = new DataTable();
                grvAlumnos.DataSource = dt;
                grvAlumnos.DataSource = GetList();
                grvAlumnos.DataBind();
                if (grvAlumnos.Rows.Count > 0)
                    HideColumns(grvAlumnos);
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        private void Nuevo()
        {
            lblMsj.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtSemestre.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            rdoGenero.SelectedValue = "M";
            //if(ddlNivel.SelectedValue!= "Z")
             
            ddlNivel_D.SelectedValue = ddlNivel.SelectedValue;
            ddlDependencia_D.SelectedValue = ddlDependencia.SelectedValue;
            ddlDependencia_D_SelectedIndexChanged(null, null);            
        }
        private void HideColumns(GridView grdView)
        {
            //grdView.HeaderRow.Cells[6].Visible = false;
            //foreach (GridViewRow row in grdView.Rows)
            //{
            //    row.Cells[6].Visible = false;
            //}
        }
        #endregion

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            lblMsj.Text = string.Empty;
            CargarGrid();
        }

        

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblMsj.Text = string.Empty;
            pnlDatos_Alumno.Visible = true;
            pnlPrincipal.Visible = false;
            SesionUsu.Editar = 0;
            txtMatricula.Enabled = true;
            Nuevo();
        }

        protected void grvAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                Verificador = string.Empty;
                ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.Rows[fila].Cells[6].Text);
                CNAlumno.AlumnoEliminar(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                    lblMsj.Text = Verificador;
                //grvAlumnos.DataSource = ListArch;
                //grvAlumnos.DataBind();
            }

            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            } 
        }

        protected void linkBttnEliminar_Click(object sender, EventArgs e)
        {

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
            lblMsj.Text = string.Empty;
            CargarGrid();
        }

        protected void linkBttnEnviarCorreo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            lblMsj.Text = string.Empty;
            try
            {
                grvAlumnos.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grvAlumnos.SelectedRow.Cells[0].Text;                
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
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
    }
}