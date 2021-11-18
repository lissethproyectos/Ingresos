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
    public partial class FrmVigencias : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = { 4, 5, 6, 7, 8 };
        Sesion SesionUsu = new Sesion();
        ConceptoPago ObjVigencias = new ConceptoPago();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        CN_Comun CNComun = new CN_Comun();
        string Verificador = string.Empty;
        List<Comun> lstGrupo = new List<Comun>();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        #region <Botones y Eventos>
        private void Inicializar()
        {
            DDLTipo_SelectedIndexChanged(null, null);
            //CargarGrid();
        }
        private void CargarGrid()
        {
            Int32[] Celdas2 = { 0,1,2,3,4,5 };
            try
            {
                DataTable dt = new DataTable();
                grdVigencias.DataSource = dt;
                grdVigencias.DataSource = GetList();
                grdVigencias.DataBind();
                if (grdVigencias.Rows.Count > 0)
                { 
                    if (DDLSubtipo.SelectedValue == "SYSWEB" || DDLSubtipo.SelectedValue == "SYSWEB_ADMON")
                        CNComun.HideColumns(grdVigencias, Celdas2);
                    else
                        CNComun.HideColumns(grdVigencias, Celdas);
                    
                }                
                    //CNComun.HideColumns(grdVigencias, Celdas);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<ConceptoPago> GetList()
        {
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjVigencias.Tipo = DDLTipo.SelectedValue;
                ObjVigencias.Nivel = DDLSubtipo.SelectedValue;
                CNConcepto.ConsultarVigenciasSIAE(ObjVigencias, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void DDLSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int S = grdVigencias.EditIndex;
            if (grdVigencias.EditIndex >= 0)
                grdVigencias.EditIndex = -1;

            CargarGrid();
        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Subtipo_Vigencias", ref DDLSubtipo, "P_Tipo", DDLTipo.SelectedValue);
            DDLSubtipo_SelectedIndexChanged2(null, null);
        }

        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {


            GridViewRow row = grdVigencias.Rows[e.RowIndex];
            int fila = e.RowIndex;
            grdVigencias.EditIndex = -1;

            if (DDLTipo.SelectedValue == "SYSWEB")
            {
                string txtDiasVigencia = Convert.ToString(((TextBox)(row.Cells[1].Controls[7])).Text);
                CNConcepto.ActualizarVigenciasSYSWEB(ObjVigencias, ref Verificador);
            }
            else
            {
                string FechaIni = Convert.ToString(((TextBox)(row.Cells[1].Controls[0])).Text);
                string FechaFin = Convert.ToString(((TextBox)(row.Cells[2].Controls[0])).Text);
                DateTime FechaValidaIni = new DateTime();
                FechaValidaIni = DateTime.Parse(FechaIni);

                ObjVigencias.Nivel = grdVigencias.Rows[e.RowIndex].Cells[4].Text; //grdVigencias.Rows[fila].Cells[4].Text;  //  row.Cells[4].Text;
                ObjVigencias.ClaveConcepto = grdVigencias.Rows[fila].Cells[5].Text;  //row.Cells[5].Text;
                ObjVigencias.Periodo = Convert.ToChar(grdVigencias.Rows[fila].Cells[3].ToString());  //Convert.ToChar(row.Cells[3].ToString());

                CNConcepto.ActualizarVigenciasSIAE(ObjVigencias, DDLSubtipo.SelectedValue, ref Verificador);
            }
            if (Verificador == "0")
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
            else
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;


            CargarGrid();
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
            try
            {
                GridViewRow row = grdVigencias.Rows[e.RowIndex];
                int fila = e.RowIndex;


                if (DDLTipo.SelectedValue == "SYSWEB" || DDLTipo.SelectedValue == "SYSWEB_ADMON")
                {
                    TextBox txtCicloEscolar = (TextBox)(row.Cells[6].FindControl("txtCicloEscolar"));
                    string CicloEscolar = txtCicloEscolar.Text; // row.Cells[3].Text;
                    TextBox txtDias_Vigencia = (TextBox)(row.Cells[7].FindControl("txtDias_Vigencia"));
                    TextBox txtDias_Vigencia_Ev = (TextBox)(row.Cells[8].FindControl("txtDias_Vigencia_Ev"));
                    string DiasVigencia = txtDias_Vigencia.Text; // row.Cells[3].Text;
                    string DiasVigencia_Ev = txtDias_Vigencia_Ev.Text;
                    grdVigencias.EditIndex = -1;
                    ObjVigencias.DiasVigencia = Convert.ToInt32(DiasVigencia);
                    ObjVigencias.DiasVigencia_Ev = Convert.ToInt32(DiasVigencia_Ev);
                    ObjVigencias.CicloEscolar = Convert.ToInt32(CicloEscolar);
                    ObjVigencias.Tipo = DDLTipo.SelectedValue;
                    CNConcepto.ActualizarVigenciasSYSWEB(ObjVigencias, ref Verificador);
                    if (Verificador == "0")
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;

                    CargarGrid();

                }
                else
                {
                    TextBox txtFechaIni = (TextBox)(row.Cells[1].FindControl("txtFechaIni"));
                    string FechaIni = txtFechaIni.Text; // row.Cells[3].Text;
                    TextBox txtFechaFin = (TextBox)(row.Cells[2].FindControl("txtFechaFin"));
                    string FechaFin = txtFechaFin.Text; // row.Cells[3].Text;



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
                            ObjVigencias.FechaInicial = FechaIni;
                            ObjVigencias.FechaFinal = FechaFin;
                            grdVigencias.EditIndex = -1;
                            if(DDLTipo.SelectedValue== "SIAE_ANT")
                                CNConcepto.ActualizarVigenciasSIAECiclo(ObjVigencias, DDLSubtipo.SelectedValue, ref Verificador);
                            else
                                CNConcepto.ActualizarVigenciasSIAE(ObjVigencias, DDLSubtipo.SelectedValue, ref Verificador);

                            if (Verificador == "0")
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido modificados correctamente.');", true); //lblMsj.Text = ex.Message;
                            else
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;

                            CargarGrid();
                        }
                        else
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'La fecha final debe ser mayor a la inicial.');", true); //lblMsj.Text = ex.Message;

                    }

                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Fecha invalida favor de verificar.');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

       
        protected void DDLSubtipo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void DDLSubtipo_SelectedIndexChanged2(object sender, EventArgs e)
        {
            CargarGrid();

        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}