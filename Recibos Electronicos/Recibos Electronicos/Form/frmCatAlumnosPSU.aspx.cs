using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Form
{
    public partial class frmCatAlumnosPSU : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumnoPSU = new CN_Alumno();
        CN_Comun CNComun = new CN_Comun();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPopoverDetalle();", true);

            if (!IsPostBack)
                Inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "grdAlumnos", "AlumnosPSU();", true);
        }

        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                grvAlumnosUNACH.DataSource = dt;
                grvAlumnosUNACH.DataSource = GetList();
                grvAlumnosUNACH.DataBind();

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private List<Alumno> GetList()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                ObjAlumno.Dependencia = ddlDependencia.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCicloEscolar.SelectedValue;
                CNAlumnoPSU.ConsultarAlumnosPSU(ObjAlumno, string.Empty, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Inicializar()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Grid_Combo_Cat_DepciasPSU", ref ddlDependencia);
                CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
