using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos.Form
{
    public partial class FrmCancelados : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;

        Sesion SesionUsu = new Sesion();
        Factura ObjFactura = new Factura();
        CN_Factura CNFacturas = new CN_Factura();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
           
        }
        #region <Botones y Eventos>
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            lblMsj.Text = string.Empty;
            CargarGrid();
            
        }
        protected void rdoListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObjFactura.ID_FACT = Convert.ToString(DataBinder.Eval(sender, "ValidationGroup").ToString());
                ObjFactura.Status_Carga = Convert.ToString(DataBinder.Eval(sender, "SelectedValue").ToString());
                CNFacturas.FacturaEditarEstatus(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                    lblMsj.Text = "El estatus ha sido modificado correctamente";
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        #endregion
        #region <Funciones y Sub>

        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                ObjFactura.FACT_FOLIO = txtFolioBuscar.Text.ToUpper();
                CNFacturas.FacturaConsultarCancelados(ref ObjFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvFacturas.DataSource = dt;
                grvFacturas.DataSource = GetList();
                grvFacturas.DataBind();
                if (grvFacturas.Rows.Count > 0)
                    HideColumns(grvFacturas);
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        private void HideColumns(GridView grdView)
        {

            grdView.HeaderRow.Cells[0].Visible = false;
            grdView.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow row in grdView.Rows)
            {
                row.Cells[0].Visible = false;
                RadioButtonList rbl = (RadioButtonList)row.FindControl("rdoListStatus");
                rbl.SelectedValue = Convert.ToString(row.Cells[1].Text);
                row.Cells[1].Visible = false;
                
            }

        }
        #endregion

        protected void grvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





       
    }
}