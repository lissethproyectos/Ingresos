using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.ControlUsuario
{
    public partial class Exenciones : System.Web.UI.UserControl
    {

        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Comun CNComun = new CN_Comun();
        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Matricula;
        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }

        #region<Funciones>
        private List<Alumno> GetList(string Dependencia, string Matricula)
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Dependencia = Dependencia;
                ObjAlumno.CicloEscolar = "0";
                ObjAlumno.StatusMatricula = "A";
                ObjAlumno.Nivel = "L";
                CNAlumno.ConsultarAlumnoDescuento(ref ObjAlumno, "T", Matricula, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultaGridExenciones(string Dependencia, string Matricula)
        {
            try
            {
                Int32[] Celdas = new Int32[] { 0, 1, 3, 10 };
                DataTable dt = new DataTable();
                grvAlumnos.DataSource = dt;
                grvAlumnos.DataSource = GetList(Dependencia, Matricula);
                grvAlumnos.DataBind();
                if (grvAlumnos.Rows.Count > 0)                
                     CNComun.HideColumns(grvAlumnos,Celdas);

                
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void grvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}