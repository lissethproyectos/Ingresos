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

            ScriptManager.RegisterStartupScript(this, GetType(), "GridVigencias", "Vigencias();", true);
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
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#modalEliminar').modal('show');", true);

        }

        protected void grdVigencias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;
            GridView gv = sender as GridView;
            gv.EditIndex = e.NewEditIndex;
            //grdVigencias.EditIndex = e.NewEditIndex;

            Label lblFechaIni = (Label)(gv.Rows[fila].Cells[2].FindControl("lblFechaIniAct"));
            TextBox txtFechaIni = (TextBox)(gv.Rows[fila].Cells[2].FindControl("txtFechaIniAct"));
            //txtFechaIni.Text = "01/02/2023";
            CargarGrid();


        }

        protected void grdVigencias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdVigencias.Rows[e.RowIndex];
            int fila = e.RowIndex;
DateTime FechaValidaIni;
            DateTime FechaValidaFin;

            string FechaIni = Convert.ToString(((TextBox)(row.Cells[2].Controls[1])).Text);
            FechaValidaIni = Convert.ToDateTime(FechaIni);
            string FechaFin = Convert.ToString(((TextBox)(row.Cells[3].Controls[1])).Text);
            FechaValidaFin = Convert.ToDateTime(FechaFin);

            if (DateTime.TryParse(FechaIni, out FechaValidaIni) && DateTime.TryParse(FechaFin, out FechaValidaFin))
            {
                DateTime FechaInicial = FechaValidaIni;
                DateTime FechaFinal = FechaValidaFin;
                if (FechaFinal >= FechaInicial)
                {
                    ObjVigencias.ClaveConcepto = Convert.ToString(((DropDownList)(row.Cells[5].Controls[1])).SelectedValue);
                    ObjVigencias.FechaInicial = FechaInicial.Day+"/"+FechaInicial.Month + "/" +FechaInicial.Year;
                    //ObjVigencias.FechaInicial = FechaIni.ToString("dd-MM-yyyy");  // Convert.ToString(((TextBox)(row.Cells[1].Controls[0])).Text);
                    ObjVigencias.FechaFinal = FechaFinal.Day + "/" + FechaFinal.Month + "/" + FechaFinal.Year;
                    ObjVigencias.Id = Convert.ToInt32(((TextBox)(row.Cells[8].Controls[0])).Text);
                    grdVigencias.EditIndex = -1;
                    CNConcepto.ActualizarVigenciasEscuela(ObjVigencias, ref Verificador);
                    if (Verificador == "0")
                    {
                        CargarGrid();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;

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
            //modalVigencias.Show();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modalEmp", "$('#modalVigencias').modal('show')", true);
        }

        protected void ddlDependenciaA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modalVigencias.Show();
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carreras_SIAE", ref ddlCarrera, "p_escuela", ddlDependenciaA.SelectedValue, "INGRESOS");

        }

        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorGuardar.Text = string.Empty;
                ObjVigencias.Dependencia = ddlDependenciaA.SelectedValue;
                ObjVigencias.Carrera = ddlCarrera.SelectedValue;
                ObjVigencias.FechaInicial = txtFechaInicial.Text;
                ObjVigencias.FechaFinal = txtFechaFinal.Text;
                ObjVigencias.ClaveConcepto = ddlConcepto.SelectedValue;
                ObjVigencias.Descripcion = ddlConcepto.SelectedItem.Text;
                CNConcepto.InsertarExcepcionesVigenciasSIAE(ObjVigencias, ref Verificador);
                if (Verificador == "0")
                {
                    //modalVigencias.Hide();
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modalEmp", "$('#modalVigencias').modal('hide')", true);

                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    lblErrorGuardar.Text = Verificador;
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                lblErrorGuardar.Text = Verificador;
            }
        }

        protected void linkBttnEliminarReg_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            lblErrorElim.Text = string.Empty;
            try
            {
                //int fila = e.RowIndex;
                //int pagina = grdVigencias.PageSize * grdVigencias.PageIndex;
                //fila = pagina + fila;
                ObjVigencias.Id = Convert.ToInt32(grdVigencias.SelectedRow.Cells[8].Text);                
                CNConcepto.EliminarExcepcionesVigenciasSIAE(ObjVigencias, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#modalEliminar').modal('hide');", true);
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    lblErrorElim.Text = Verificador;
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                lblErrorElim.Text = Verificador;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void grdVigencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;
            int pagina = grdVigencias.PageSize * grdVigencias.PageIndex;
            fila = pagina + fila;

            GridViewRow row = grdVigencias.Rows[e.RowIndex];
            
            SesionUsu.Row = e.RowIndex;
            //ObjVigencias.Dependencia = Convert.ToString(grdVigencias.Rows[fila].Cells[0].Text);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#modalEliminar').modal('show');", true);

         

        }

    }
}