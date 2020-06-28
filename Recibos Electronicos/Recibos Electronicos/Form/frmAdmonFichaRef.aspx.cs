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
    public partial class frmAdmonFichaRef : System.Web.UI.Page
    {
        #region <Variables>
        Int32[] Celdas = { 4, 5 };
        Sesion SesionUsu = new Sesion();
        Factura ObjFichaRef = new Factura();
        CN_Comun CNComun = new CN_Comun();
        CN_Factura CNFactura = new CN_Factura();
        string Verificador = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                txtReferencia.Focus();
            else
            {
                if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
                {
                    string s = Request.Params["__EVENTTARGET"];
                    if ((Request.Params["__EVENTTARGET"] == this.txtReferencia.UniqueID) /*+&& (Request.Params["__EVENTARGUMENT"] == "actualizar_label")*/)
                    {
                        this.imgBttnBuscar.Focus();
                    }
                }
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }


        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                grdFichasRef.DataSource = dt;
                grdFichasRef.DataSource = GetList();
                grdFichasRef.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                CNFactura.FichaRefConsultaGrid(ObjFichaRef, txtReferencia.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            this.imgBttnBuscar.Focus();

        }
    }
}