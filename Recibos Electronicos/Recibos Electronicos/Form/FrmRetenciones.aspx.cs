using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using CapaEntidad;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRetenciones : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        CN_Retencion CNRetencion = new CN_Retencion();
        Retencion ObjRetencion = new Retencion();
        Sesion SesionUsu = new Sesion();
        List<Retencion> ListRetencion = new List<Retencion>();

        #endregion

        #region <Funciones>
        protected void Inicializar()
        {
            MultiView1.ActiveViewIndex = 0;
            CargarCombos();
        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridBeneficiarios()
        {
            Int32[] Celdas = new Int32[] { 8 };
            try
            {
                DataTable dt = new DataTable();
                grvBeneficiarios.DataSource = dt;
                grvBeneficiarios.DataSource = GetList();
                grvBeneficiarios.DataBind();
                CNComun.HideColumns(grvBeneficiarios, Celdas);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridDetalle()
        {
            try
            {
                DataTable dt = new DataTable();
                grvDetalle.DataSource = dt;
                grvDetalle.DataSource = GetListDetalle();
                grvDetalle.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private void CargarGridConceptos(List<Retencion> ListRetencion)
        {
            lblMensaje.Text = string.Empty;
            try
            {
                grvImpuestos.DataSource = ListRetencion;
                grvImpuestos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        private List<Retencion> GetList()
        {
            try
            {
                List<Retencion> List = new List<Retencion>();
                ObjRetencion.Dependencia = ddlDependencia.SelectedValue;
                ObjRetencion.Anio = Convert.ToInt32(DDLAnio.SelectedValue);
                ObjRetencion.Mes = DDLMes.SelectedValue;                
                CNRetencion.ConsultarBeneficiarios(ref ObjRetencion, ref List, txtBuscar.Text);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Retencion> GetListDetalle()
        {
            try
            {
                List<Retencion> List = new List<Retencion>();
                ObjRetencion.Dependencia = grvBeneficiarios.SelectedRow.Cells[0].Text;
                ObjRetencion.Tipo_Beneficiario= grvBeneficiarios.SelectedRow.Cells[1].Text;
                ObjRetencion.Poliza = grvBeneficiarios.SelectedRow.Cells[3].Text;
                ObjRetencion.Cedula = grvBeneficiarios.SelectedRow.Cells[4].Text;
                ObjRetencion.MesAnio = grvBeneficiarios.SelectedRow.Cells[8].Text;
                CNRetencion.ConsultarConceptos(ref ObjRetencion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();


        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            modalBenef.Show();
            if (DDLTipo.SelectedValue == "P")
                lblBeneficiario.Text = "Proveedor:";
            else
                lblBeneficiario.Text = "Empleado:";

            CNComun.LlenaCombo("PKG_HONORARIOS.Obt_Empleados", ref DDLBeneficiario, "p_tipo_contrato", DDLTipo.SelectedValue);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void grvDatosRetenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridBeneficiarios();
        }

        

        protected void grvBeneficiarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvBeneficiarios.PageIndex = 0;
            grvBeneficiarios.PageIndex = e.NewPageIndex;
            CargarGridBeneficiarios();

        }

        protected void grvBeneficiarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            lblNombreBenfeciario.Text = grvBeneficiarios.SelectedRow.Cells[2].Text;
            Session["Impuestos"] = null;
            grvImpuestos.DataSource = null;
            grvImpuestos.DataBind();
            CargarGridDetalle();
        }

        protected void grvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvDetalle.SelectedRow.Cells[3].Text == "0")
                txtImpuesto.Text = grvDetalle.SelectedRow.Cells[2].Text;
            else
                txtImpuesto.Text = grvDetalle.SelectedRow.Cells[3].Text;

            modalBenef.Show();

        }

        protected void btnCancelarBenef_Click(object sender, EventArgs e)
        {
            modalBenef.Hide();
        }

        protected void bttnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void bttnSalir_Click(object sender, EventArgs e)
        {
            modalBenef.Hide();
        }

        protected void bttnAgregar_Click1(object sender, EventArgs e)
        {
            ObjRetencion.Tipo_Beneficiario = (DDLTipo.SelectedValue== "TCH003")?"P":"E";
            ObjRetencion.Beneficiario = DDLBeneficiario.SelectedItem.Text;
            ObjRetencion.Concepto = DDLConcepto.SelectedItem.Text;
            ObjRetencion.Impuesto =Convert.ToDouble(txtImpuesto.Text);
            if (Session["Impuestos"] == null)
            {
                ListRetencion = new List<Retencion>();
                ListRetencion.Add(ObjRetencion);
            }
            else
            {
                ListRetencion = (List<Retencion>)Session["Impuestos"];
                ListRetencion.Add(ObjRetencion);
            }

            Session["Impuestos"] = ListRetencion;
            CargarGridConceptos(ListRetencion);
            modalBenef.Hide();
        }
    }
}