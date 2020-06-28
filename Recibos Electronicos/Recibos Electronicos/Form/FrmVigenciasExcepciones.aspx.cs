using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using System.Data;

namespace Recibos_Electronicos.Form
{
    public partial class FrmVigenciasExcepciones : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = { 4, 5 };
        Sesion SesionUsu = new Sesion();
        ConceptoPago ObjVigencias = new ConceptoPago();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        CN_Comun CNComun = new CN_Comun();
        string Verificador = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }

        #region <Botones y Eventos>
        private void Inicializar()
        {
            CargarCombos();
        }

        private void CargarCombos()
        {

            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_DependenciasUnach", ref ddlDependenciaA, "p_nivel", "L", "INGRESOS");
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_DependenciasUnach", ref ddlDependencia, "p_nivel", "L", "INGRESOS");
                imgBttnBuscar_Click(null, null);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                grdVigencias.DataSource = dt;
                grdVigencias.DataSource = GetList();
                grdVigencias.DataBind();
                //if (grdVigencias.Rows.Count > 0)
                //    CNComun.HideColumns(grdVigencias, Celdas);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<ConceptoPago> GetList()
        {
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjVigencias.Dependencia = ddlDependencia.SelectedValue;
                CNConcepto.ConsultarExcepcionesVigenciasSIAE(ObjVigencias, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void DDLNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int S = grdVigencias.EditIndex;
            if (grdVigencias.EditIndex >= 0)
                grdVigencias.EditIndex = -1;

            CargarGrid();
        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {



            GridViewRow row = grdVigencias.Rows[e.RowIndex];
            int fila = e.RowIndex;
            string FechaIni = Convert.ToString(((TextBox)(row.Cells[1].Controls[0])).Text);
            string FechaFin = Convert.ToString(((TextBox)(row.Cells[2].Controls[0])).Text);
            DateTime FechaValidaIni = new DateTime();
            FechaValidaIni = DateTime.Parse(FechaIni);
            //if (FechaValidaIni == true)
            //{

            //    ObjVigencias.FechaInicial = FechaIni;
            //    ObjVigencias.FechaFinal = FechaFin;
            //}
            ObjVigencias.Nivel = grdVigencias.Rows[e.RowIndex].Cells[4].Text; //grdVigencias.Rows[fila].Cells[4].Text;  //  row.Cells[4].Text;
            ObjVigencias.ClaveConcepto = grdVigencias.Rows[fila].Cells[5].Text;  //row.Cells[5].Text;
            ObjVigencias.Periodo = Convert.ToChar(grdVigencias.Rows[fila].Cells[3].ToString());  //Convert.ToChar(row.Cells[3].ToString());
            grdVigencias.EditIndex = -1;
            //CNConcepto.ActualizarVigenciasSIAE(ObjVigencias,  ref Verificador);
            //if (Verificador == "0")
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
            //else
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;


            //CargarGrid();
        }

        protected void grdVigencias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //List<Poliza_Detalle> ListPDet = new List<Poliza_Detalle>();
            //ListPDet = (List<Poliza_Detalle>)Session["PolizaDet"];
            grdVigencias.EditIndex = -1;
            CargarGrid();
        }

        protected void grdVigencias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdVigencias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //int Row = e.NewEditIndex;
            //GridViewRow currentRow = this.grdVigencias.Rows[e.NewEditIndex];
            grdVigencias.EditIndex = e.NewEditIndex;
            //ImageButton imgBttn = currentRow.FindControl("imgCalendarioIni") as ImageButton;
            //TextBox txtFechIni = currentRow.FindControl("txtFecha_Factura_Ini") as TextBox;
            //imgBttn.Visible = true;
            //txtFechIni.Enabled = true;
            CargarGrid();


        }

        protected void grdVigencias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdVigencias.Rows[e.RowIndex];
            int fila = e.RowIndex;
            string FechaIni = Convert.ToString(((TextBox)(row.Cells[1].Controls[0])).Text);
            string FechaFin = Convert.ToString(((TextBox)(row.Cells[2].Controls[0])).Text);
            DateTime FechaValidaIni;
            DateTime FechaValidaFin;
            if (DateTime.TryParse(FechaIni, out FechaValidaIni) && DateTime.TryParse(FechaFin, out FechaValidaFin))
            {
                DateTime FechaInicial = Convert.ToDateTime(FechaIni);
                DateTime FechaFinal = Convert.ToDateTime(FechaFin);
                if (FechaFinal >= FechaInicial)
                {
                    ObjVigencias.Nivel = row.Cells[4].Text;
                    ObjVigencias.ClaveConcepto = row.Cells[5].Text;
                    ObjVigencias.Periodo = Convert.ToChar(row.Cells[3].Text);
                    ObjVigencias.FechaInicial = FechaIni; // Convert.ToString(((TextBox)(row.Cells[1].Controls[0])).Text);
                    ObjVigencias.FechaFinal = FechaFin; //Convert.ToString(((TextBox)(row.Cells[2].Controls[0])).Text);
                    grdVigencias.EditIndex = -1;
                    //CNConcepto.ActualizarVigenciasSIAE(ObjVigencias, ref Verificador);
                    //if (Verificador == "0")
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
                    //else
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;

                    //CargarGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'La fecha final debe ser mayor a la inicial.');", true); //lblMsj.Text = ex.Message;

            }

            else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Fecha invalida favor de verificar.');", true); //lblMsj.Text = ex.Message;


        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            modalVigencias.Show();
        }

        protected void ddlDependenciaA_SelectedIndexChanged(object sender, EventArgs e)
        {
            modalVigencias.Show();
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carreras_SIAE", ref ddlCarrera, "p_escuela", ddlDependenciaA.SelectedValue, "INGRESOS");

        }

        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Verificador = string.Empty;
                ObjVigencias.Dependencia = ddlDependenciaA.SelectedValue;
                ObjVigencias.Carrera = ddlCarrera.SelectedValue;
                ObjVigencias.FechaInicial = txtFechaInicial.Text;
                ObjVigencias.FechaFinal = txtFechaFinal.Text;
                CNConcepto.InsertarExcepcionesVigenciasSIAE(ObjVigencias, ref Verificador);
                if (Verificador == "0")
                {
                    modalVigencias.Hide();
                    CargarGrid();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void bttnSalirEmp_Click(object sender, EventArgs e)
        {
            modalVigencias.Hide();
        }
    }
}