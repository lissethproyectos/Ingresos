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
    public partial class frmControl_Cierre : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        Control_Cierre objControl_Cierre = new Control_Cierre();
        CN_Comun CNComun = new CN_Comun();
        CN_Control_Cierre CNControlCierre = new CN_Control_Cierre();
        Int32[] Celdas = new Int32[] { 0 };
        string Verificador = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        #region <Funciones y Sub>
        private void Inicializar()
        {
            SesionUsu.Editar = -1;
            CargarGrid();           
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvControl_Cierre.DataSource = dt;
                grvControl_Cierre.DataSource = GetList();
                grvControl_Cierre.DataBind();

                if (grvControl_Cierre.Rows.Count > 0)
                    CNComun.HideColumns(grvControl_Cierre, Celdas);


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<Control_Cierre> GetList()
        {
            try
            {
                List<Control_Cierre> List = new List<Control_Cierre>();
                objControl_Cierre.Ejercicio = Convert.ToInt32(ddlEjercicio.SelectedValue);
                objControl_Cierre.sistema = "INGRESOS";
                CNControlCierre.Control_CierreConsultaGrid(ref objControl_Cierre, txtBuscar.Text.ToUpper(), ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void grvControl_Cierre_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grvControl_Cierre_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvControl_Cierre.PageIndex = 0;
            grvControl_Cierre.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvControl_Cierre_RowEditing(object sender, GridViewEditEventArgs e)
        {           
            grvControl_Cierre.EditIndex = e.NewEditIndex;
            CargarGrid();
            DropDownList ddl = grvControl_Cierre.Rows[e.NewEditIndex].FindControl("ddlMes") as DropDownList;
            ddl.Enabled = true;
        }

        protected void EditaRegistro(object sender, GridViewUpdateEventArgs e)
        {           
            GridViewRow row = grvControl_Cierre.Rows[e.RowIndex];
            string Id = (row.Cells[5]).Text;

            int IdCC = Convert.ToInt32(row.Cells[0].Text);
            string Mes = row.Cells[2].Text; 

            try
            {
                objControl_Cierre.Id_Control_Cierre = IdCC;
                objControl_Cierre.Mes_anio = Mes + ddlEjercicio.ToString().Substring(2, 2);
                objControl_Cierre.Cierre_Definitivo = Mes + ddlEjercicio.ToString().Substring(2, 2);
                CNControlCierre.Control_CierreEditar(ref objControl_Cierre, ref Verificador);
                if (Verificador == "0")
                {
                    grvControl_Cierre.EditIndex = -1;
                    CargarGrid();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }

            }
            catch(Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void grvControl_Cierre_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvControl_Cierre.EditIndex = -1;
            CargarGrid();
        }

        protected void grvControl_Cierre_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string IdCC = e.NewValues[0].ToString();
            DropDownList ddl = (DropDownList)grvControl_Cierre.Rows[e.RowIndex].FindControl("ddlMes");
            try
            {
                objControl_Cierre.Id_Control_Cierre =Convert.ToInt32(IdCC);
                objControl_Cierre.Mes_anio = ddl.SelectedValue + ddlEjercicio.SelectedValue.Substring(2, 2);
                objControl_Cierre.Cierre_Definitivo = ddl.SelectedValue + ddlEjercicio.SelectedValue.Substring(2, 2);

                CNControlCierre.Control_CierreEditar(ref objControl_Cierre, ref Verificador);
                if (Verificador == "0")
                {
                    grvControl_Cierre.EditIndex = -1;
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
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void bttnCierreGeneral_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            DropDownList DDLMesGral = (DropDownList)grvControl_Cierre.HeaderRow.FindControl("ddlMesGral");
            try
            {                
                objControl_Cierre.Mes_anio = DDLMesGral.SelectedValue + ddlEjercicio.SelectedValue.Substring(2, 2);
                objControl_Cierre.Ejercicio =Convert.ToInt32(ddlEjercicio.SelectedValue);
                CNControlCierre.Control_CierreGral(ref objControl_Cierre, ref Verificador);
                if (Verificador == "0")
                {
                    //grvControl_Cierre.EditIndex = -1;
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
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
    }    
}