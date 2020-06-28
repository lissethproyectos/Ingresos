using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Recibos_Electronicos.Form
{
    public partial class frmGenerarReciboAsp : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Factura objFactura = new Factura();
        CN_Factura CNFactura = new CN_Factura();
        string Verificador = string.Empty;
        #endregion
        #region <Funciones>
        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                grdReferenciasAsp.DataSource = dt;
                grdReferenciasAsp.DataSource = GetList();
                grdReferenciasAsp.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }
        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                objFactura.FACT_DEPENDENCIA = ddlDependencias.SelectedValue;
                objFactura.FACT_CONFIRMADO = (chkPagados.Checked==true)?"S":"N";
                CNFactura.ConsultarRefAspirantes(objFactura, txtBuscar.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void Inicializar()
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencias, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CargarGrid();

        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();

        }

        protected void chkPagados_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void bttnGenRecibo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdReferenciasAsp.SelectedIndex = row.RowIndex;
            objFactura.ID_FICHA_BANCARIA = Convert.ToInt32(grdReferenciasAsp.SelectedRow.Cells[0].Text);

            CNFactura.Generar_Recibo_Apirante(objFactura, ref Verificador);
            if (Verificador == "0")
                CargarGrid();
            else
            {               
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void grdReferenciasAsp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReferenciasAsp.PageIndex = 0;
            grdReferenciasAsp.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
    }
}