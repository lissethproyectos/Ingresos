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
    public partial class frmCatAlumnos : System.Web.UI.Page
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
            grvAlumnosUNACH.DataSource = null;
            grvAlumnosUNACH.DataBind();
            ViewState["Filter"] = "0000";
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Grid_Combo_Cat_Depcias", ref ddlDependencias);

                if (ddlNivel.Items.Count >= 1)
                {
                    ddlNivel.Items.Insert(0, new ListItem("--Todos--", "T"));
                    ddlNivel_SelectedIndexChanged(null, null);
                }
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
                grvAlumnosUNACH.DataSource = dt;
                grvAlumnosUNACH.DataSource = GetList();
                grvAlumnosUNACH.DataBind();
                if (grvAlumnosUNACH.Rows.Count >= 1)
                {
                    if (grvAlumnosUNACH.Rows.Count > 0 && (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "N"))
                        CNComun.HideColumns(grvAlumnosUNACH, Celdas);
                    else
                        CNComun.HideColumns(grvAlumnosUNACH, CeldasAdmin);
                }

                //DropDownList ddlCicloEscolar = (DropDownList)grvAlumnosUNACH.HeaderRow.FindControl("ddlCiclo");
                //this.BindCiclo(ddlCicloEscolar);


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void BindCiclo(DropDownList ddlCicloEscolar)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_tipo", "p_nivel", "p_busca", "p_dependencia", ddlTipo.SelectedValue, ddlNivel.SelectedValue, txtBuscar.Text, ddlDependencias.SelectedValue, "INGRESOS");
                ddlCicloEscolar.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
            }
            catch (Exception ex)
            {
                string Msj=ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Msj + "');", true);  //lblMsjFam.Text = Verificador;
            }
        }

        private List<Alumno> GetList()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.TipoPersonaStr = ddlTipo.SelectedValue;
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                ObjAlumno.Dependencia = ddlDependencias.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCicloEscolar.SelectedValue;  //ViewState["Filter"].ToString();
                CNAlumno.ConsultarAlumnosUNACH(ObjAlumno, txtBuscar.Text, ref List);
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


            ScriptManager.RegisterStartupScript(this, GetType(), "GridAlumnos", "CatAlumnos();", true);
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void grvAlumnosUNACH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvAlumnosUNACH.PageIndex = 0;
                grvAlumnosUNACH.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message.Substring(0, 40) + "');", true);
            }

        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP043&TipoPersona=" + ddlTipo.SelectedValue + "&Nivel=" + ddlNivel.SelectedValue + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP043Excel&TipoPersona=" + ddlTipo.SelectedValue + "&Nivel=" + ddlNivel.SelectedValue+ "&enExcel=S";
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
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_nivel", "p_tipo", ddlNivel.SelectedValue, ddlTipo.SelectedValue, "INGRESOS");
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_nivel", "p_tipo", ddlNivel.SelectedValue, ddlTipo.SelectedValue, "INGRESOS");
        }
    }
}