using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.Form
{
    public partial class frmCatCarrerasPosgrado : System.Web.UI.Page
    {
        #region <Variables>

        String Verificador = string.Empty;
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();              
        #endregion
        #region <Funciones>
        protected void Inicializar()
        {
            CargarCombos();
            CargarGrid();
            //grvCarrerasUNACH.DataSource = null;
            //grvCarrerasUNACH.DataBind();
        }
        protected void CargarCombos()
        {
            try
            {
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                //if (ddlNivel.Items.Count >= 1)
                //    ddlNivel.Items.Insert(0, new ListItem("--Todos--", "T"));

                ddlNivel_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message.Substring(0, 40) + "');", true);
            }
        }
        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                grvCarrerasUNACH.DataSource = dt;
                grvCarrerasUNACH.DataSource = GetList();
                grvCarrerasUNACH.DataBind();

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
                ObjAlumno.Dependencia = ddlDependencias.SelectedValue;
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                CNAlumno.ConsultarCarrerasPosgrado(ObjAlumno, txtBusca.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                Inicializar();
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_DependenciasUnach", ref ddlDependencias, "p_nivel", ddlNivel.SelectedValue, "INGRESOS");
                ddlDependencias_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void grvCarrerasUNACH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCarrerasUNACH.PageIndex = 0;
            grvCarrerasUNACH.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();

        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP042&Nivel=" + ddlNivel.SelectedValue + "&dependencia=" + ddlDependencias.SelectedValue + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP042&Nivel=" + ddlNivel.SelectedValue + "&dependencia=" + ddlDependencias.SelectedValue + "&enExcel=S";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}