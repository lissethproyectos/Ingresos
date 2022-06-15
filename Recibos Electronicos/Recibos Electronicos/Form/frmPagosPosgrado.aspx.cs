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
    public partial class frmPagosPosgrado : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        CN_PagosPosgrado CNPagos = new CN_PagosPosgrado();
        Sesion SesionUsu = new Sesion();
        PagosPosgrado objPagos = new PagosPosgrado();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();

            if (SesionUsu.Usu_Central_Tipo == "SA" || SesionUsu.Usu_Central_Tipo=="A")
                ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "Pagos();", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "PagosUsuNormal();", true);

        }
        private void Inicializar()
        {
            //lblMsj.Text = string.Empty;
            try
            {
                Cargarcombos();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private void Cargarcombos()

        {
            try
            {
                CNComun.LlenaCombo("PKG_POSGRADO.Obt_Combo_Escuelas", ref DDLEscuelas, "p_usuario", SesionUsu.Usu_Nombre, "SIAE");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] { 0,9,10 };
            Int32[] CeldasAdmin = new Int32[] { 0, 10 };
            try
            {
                DataTable dt = new DataTable();
                grdPagos.DataSource = dt;
                grdPagos.DataSource = GetList();
                grdPagos.DataBind();
                if (grdPagos.Rows.Count > 0)
                {
                    if (SesionUsu.Usu_Central_Tipo== "SA" || SesionUsu.Usu_Central_Tipo == "A")
                        CNComun.HideColumns(grdPagos, CeldasAdmin);
                    else
                        CNComun.HideColumns(grdPagos, Celdas);
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private List<PagosPosgrado> GetList()
        {
            try
            {
                List<PagosPosgrado> List = new List<PagosPosgrado>();
                objPagos.Matricula = txtMatricula.Text;
                objPagos.Escuela = DDLEscuelas.SelectedValue;
                objPagos.Carrera = DDLCarreras.SelectedValue;
                CNPagos.ConsultarPagosPosgrado(objPagos, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void linkBttnPagos_Click(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_POSGRADO.Obt_Combo_Carreras_Alum", ref DDLCarreras, "P_Matricula", txtMatricula.Text, "SIAE");
            CargarGrid();
        }

        protected void DDLCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void grdPagos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPagos.EditIndex = e.NewEditIndex;
            CargarGrid();
        }

        protected void grdPagos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            //int pagina = grdEventos.PageSize * grdEventos.PageIndex;
            //fila = pagina + fila;
            GridViewRow row = grdPagos.Rows[e.RowIndex];
            try
            {
                PagosPosgrado objPago = new PagosPosgrado();
                objPago.IdRef = Convert.ToInt32(row.Cells[0].Text);
                TextBox txtSemestre = (TextBox)(row.Cells[2].FindControl("txtSemestre"));
                objPago.Semestre = Convert.ToInt32(txtSemestre.Text);
                TextBox txtNoPago = (TextBox)(row.Cells[4].FindControl("txtNoPago"));
                objPago.No_Pago = Convert.ToInt32(txtNoPago.Text);
                TextBox txtCiclo = (TextBox)(row.Cells[4].FindControl("txtCiclo"));
                objPago.Ciclo_Actual = Convert.ToString(txtCiclo.Text);
                //TextBox txtFechaIni_Evento = (TextBox)(row.Cells[5].FindControl("txtFechaIniG"));
                //objEvento.Fecha_inicial = txtFechaIni_Evento.Text; // row.Cells[3].Text;
                //TextBox txtFechaFin_Evento = (TextBox)(row.Cells[6].FindControl("txtFechaFinG"));
                //objEvento.Fecha_final = txtFechaFin_Evento.Text;
                objPago.IdPago= Convert.ToInt32(row.Cells[10].Text);
                CNPagos.EditarPagosPosgrado(objPago, ref Verificador);
                if (Verificador == "0")
                {
                    grdPagos.EditIndex = -1;
                    CargarGrid();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void grdPagos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPagos.EditIndex = -1;
            CargarGrid();
        }

        protected void grdPagos_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP060&Dependencia=" + DDLEscuelas.SelectedValue + "&Matricula=" + txtMatricula.Text + "&IdCarrera=" + DDLCarreras.SelectedValue + "&enExcel=N";
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REPSCE_001&Referencia=" + grdPagos.SelectedRow.Cells[6].Text + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void linkBttnConcPagos_Click(object sender, EventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REPSCE_002&Dependencia=" + DDLEscuelas.SelectedValue + "&Matricula=" + txtMatricula.Text + "&IdCarrera=" + DDLCarreras.SelectedValue + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
    }
}