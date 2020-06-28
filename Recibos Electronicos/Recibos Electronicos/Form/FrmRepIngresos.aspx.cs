using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRepIngresos : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        List<ConceptoPago> ListDetConcepto = new List<ConceptoPago>();
        ConceptoPago ObjConceptos = new ConceptoPago();
        CN_ConceptoPago CNConceptos = new CN_ConceptoPago();

        protected string UrlReporte = null;

        #endregion
        protected string Conceptos_Seleccionados()
        {
            string Conceptos = string.Empty;
            string ConceptosSeleccionados;
            int UltimoReg;

            var checkedCvesConceptos = from GridViewRow msgRow in grvConceptos.Rows
                                       where ((CheckBox)msgRow.FindControl("chkConcepto")).Checked
                                       select (String)(grvConceptos.DataKeys[msgRow.RowIndex].Value.ToString());

            foreach (var CveConcepto in checkedCvesConceptos)
            {
                Conceptos = Conceptos + CveConcepto + ",";
            }

            UltimoReg = Conceptos.Length;
            if (UltimoReg > 0)
                ConceptosSeleccionados = Conceptos.Substring(0, UltimoReg - 1);
            else
                ConceptosSeleccionados = string.Empty;

            return ConceptosSeleccionados;
        }
        protected void Seleccionar_Todos()
        {
            var checkedCvesConceptos = from GridViewRow msgRow in grvConceptos.Rows
                                       where ((CheckBox)msgRow.FindControl("chkConcepto")).Checked
                                       select (String)(grvConceptos.DataKeys[msgRow.RowIndex].Value.ToString());
        }

        protected void Inicializar()
        {
            txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            if(UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                lblCiclo.Visible = true;
                ddlCiclo.Visible = true;
                lblFecha_Factura_Ini.Visible = false;
                txtFecha_Factura_Ini.Visible = false;
                lblFecha_Factura_Fin.Visible = false;
                txtFecha_Factura_Fin.Visible = false;
                lblNivel.Visible = false;
                DDLNivel.Visible = false;
                lblOrdenar.Visible = false;
                ddlOrden.Visible = false;
                lblConceptos.Visible = false;
                grvConceptos.Visible = false;
                imgCalendarioIni.Visible = false;
                imgCalendarioFin.Visible = false;
                divGrid.Style.Add("display", "none");
                txtBuscar.Visible = false;
                imgBttnBuscar.Visible = false;

            }


            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
                CNComun.LlenaComboG("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                DDLNivel.SelectedIndex = 0;
                DDLNivel_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<ConceptoPago> GetListConceptos(bool Habilitado)
        {
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjConceptos.Nivel = DDLNivel.SelectedValue;
                ObjConceptos.Status = 'A';
                CNConceptos.ConceptoConsultaGrid(ref ObjConceptos, ddlOrden.SelectedValue, Habilitado, txtBuscar.Text.ToUpper(), ref List);
                return List;
            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGridCatConceptos(bool Habilitado)
        {
            //Int32[] Celdas1 = new Int32[] { 2, 3 };
            //Int32[] Celdas2 = new Int32[] { 3 };
            try
            {
                DataTable dt = new DataTable();
                grvConceptos.DataSource = dt;
                grvConceptos.DataSource = GetListConceptos(Habilitado);
                grvConceptos.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];


            UrlReporte = Convert.ToString(Request.QueryString["SourceID"]);

            if (!IsPostBack)
                Inicializar();
        }

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);
        }

        protected void grvConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConceptos.PageIndex = 0;
            grvConceptos.PageIndex = e.NewPageIndex;
            CargarGridCatConceptos(false);
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo="+ UrlReporte + "&dependencia=" + ddlDependencia.SelectedValue + "&ciclo=" + ddlCiclo.SelectedValue + "&enExcel=N";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            else
            {
                string ConceptosSeleccionados = string.Empty;
                CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
                bool ValorActual = chkTodosConceptos.Checked;

                if (DDLNivel.SelectedValue == "T" && ValorActual == true)
                    ConceptosSeleccionados = "TODOS";
                else
                    ConceptosSeleccionados = Conceptos_Seleccionados();


                if (ConceptosSeleccionados != string.Empty)
                {
                    if (UrlReporte == "REP038") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP039") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP039&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP040") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP040&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    else if (UrlReporte == "REP041") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP041&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;

            }
        }

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = string.Empty;

            if (UrlReporte == "REP045" || UrlReporte == "REP046")
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo="+ UrlReporte + "&dependencia=" + ddlDependencia.SelectedValue + "&ciclo=" + ddlCiclo.SelectedValue + "&enExcel=S";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }
            else
            {

                string ConceptosSeleccionados = string.Empty;
                CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
                bool ValorActual = chkTodosConceptos.Checked;

                if (DDLNivel.SelectedValue == "T" && ValorActual == true)
                    ConceptosSeleccionados = "TODOS";
                else
                    ConceptosSeleccionados = Conceptos_Seleccionados();




                if (ConceptosSeleccionados != string.Empty)
                {
                    if (UrlReporte == "REP038") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    else if (UrlReporte == "REP039") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP039&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    else if (UrlReporte == "REP040") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP040&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";





                    else if (UrlReporte == "REP041") ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP041&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void chkTodosConc_CheckedChanged(object sender, EventArgs e)
        {
            bool ValorActual;
            CheckBox chkTodosConc = (CheckBox)sender;
            ValorActual = chkTodosConc.Checked;
            CargarGridCatConceptos(chkTodosConc.Checked);

            CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
            chkTodosConceptos.Checked = ValorActual;
            //chkTodosConc.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;

            //((CheckBox)Header.FindControl("chkTodosConc")).Checked = ValorActual;
            //chkTodosConc.Checked = ValorActual;                       
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridCatConceptos(false);
        }
    }
}