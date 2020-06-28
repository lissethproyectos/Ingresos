using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Linq;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRepIngresos2 : System.Web.UI.Page
    {


        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        List<ConceptoPago> ListDetConcepto = new List<ConceptoPago>();
        ConceptoPago ObjConceptos = new ConceptoPago();
        CN_ConceptoPago CNConceptos = new CN_ConceptoPago();
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
            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref DDLNivel, "INGRESOS");
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
                CNConceptos.ConceptoConsultaGrid(ref ObjConceptos, ddlOrden.SelectedValue, Habilitado, "", ref List);
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
            string ConceptosSeleccionados=string.Empty;
            CheckBox chkTodosConceptos = (CheckBox)grvConceptos.HeaderRow.FindControl("chkTodosConc");
            bool ValorActual = chkTodosConceptos.Checked;

            if (DDLNivel.SelectedValue == "T" && ValorActual == true)
                ConceptosSeleccionados = "TODOS";
            else
                ConceptosSeleccionados =Conceptos_Seleccionados();


            if (ConceptosSeleccionados != string.Empty)
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=N";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;


        }

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridCatConceptos(false);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ConceptosSeleccionados = string.Empty;
            ConceptosSeleccionados = Conceptos_Seleccionados();
            if (ConceptosSeleccionados != string.Empty)
            {

                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP038&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&dependencia=" + ddlDependencia.SelectedValue + "&IdConcepto=" + ConceptosSeleccionados + "&enExcel=S";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Debe seleccionar al menos un concepto.');", true); //lblMsj.Text = ex.Message;
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
    }
}