using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.Form
{
    public partial class frmCatAspirantes : System.Web.UI.Page
    {
        #region <Variables>

        String Verificador = string.Empty;
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();

        //CajaFactura cjaFact = new CajaFactura();
        public Boolean BandFact = false;


        #endregion
        #region <Funciones>
        protected void Inicializar()
        {
            CargarCombos();
            ddlNivel.SelectedValue = "L";
            ddlNivel_SelectedIndexChanged(null, null);
            grvAspirantes.DataSource = null;
            grvAspirantes.DataBind();
            ViewState["Filter"] = "0000";
        }
        protected void CargarCombos()
        {
            try
            {
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencias, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

                //if (ddlNivel.Items.Count >= 1)
                //{
                //    ddlNivel.Items.Insert(0, new ListItem("--Todos--", "T"));
                //    ddlNivel_SelectedIndexChanged(null, null);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message.Substring(0, 40) + "');", true);
            }
        }
        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] { 2, 10, 11, 12 };
            Int32[] CeldasAdmin = new Int32[] { 2 };
            try
            {
                DataTable dt = new DataTable();
                grvAspirantes.DataSource = dt;
                grvAspirantes.DataSource = GetList();
                grvAspirantes.DataBind();
                if(grvAspirantes.Rows.Count> 0 &&  (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "N"))                
                    CNComun.HideColumns(grvAspirantes, Celdas);
                else
                    CNComun.HideColumns(grvAspirantes, CeldasAdmin);

                //DropDownList ddlCicloEscolar = (DropDownList)grvAlumnosUNACH.HeaderRow.FindControl("ddlCiclo");
                //this.BindCiclo(ddlCicloEscolar);


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
                ObjAlumno.TipoPersonaStr = ddlOrigen.SelectedValue; // "TODOS";
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                ObjAlumno.Dependencia = ddlDependencias.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCicloEscolar.SelectedValue;  //ViewState["Filter"].ToString();
                CNAlumno.ConsultarAspirantesUNACH(ObjAlumno, txtBuscar.Text, ddlOrigen.SelectedValue, ref List);
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
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void grvAlumnosUNACH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvAspirantes.PageIndex = 0;
                grvAspirantes.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message.Substring(0, 40) + "');", true);
            }

        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP059&dependencia="+ddlDependencias.SelectedValue+"&Nivel=" + ddlNivel.SelectedValue + "&ciclo=" + ddlCicloEscolar.SelectedValue + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP059&TipoPersona=TODOS&Nivel=" + ddlNivel.SelectedValue+ "&enExcel=S";
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP059&dependencia="+ddlDependencias.SelectedValue+"&Nivel=" + ddlNivel.SelectedValue + "&ciclo=" + ddlCicloEscolar.SelectedValue + "&enExcel=S";

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void ddlCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCiclo = (DropDownList)sender;
            string Ciclo = ddlCiclo.SelectedValue;
            ViewState["Filter"] = ddlCiclo.SelectedValue;
            CargarGrid();
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_nivel", "p_tipo", ddlNivel.SelectedValue, "TODOS", "INGRESOS");
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_nivel", "p_tipo", ddlNivel.SelectedValue, "TODOS", "INGRESOS");
        }

        protected void ddlCicloEscolar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}