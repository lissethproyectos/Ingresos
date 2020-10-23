using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaNegocio;
using CapaEntidad;


namespace Recibos_Electronicos.ControlUsuario
{
    public partial class Facturas : System.Web.UI.UserControl
    {
        #region <Variables>
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CajaFactura ObjCjaFactura = new CajaFactura();
        Sesion SesionUsu = new Sesion();
        Usuario Usur = new Usuario();
        CN_Comun CNComun = new CN_Comun();

        private string _UsuNombre;
        public string UsuNombre
        {
            get { return _UsuNombre; }
            set { _UsuNombre = value; }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        #endregion

        #region <Funciones>
        public void ConsultaGridFacturas(string Escuela, string RFC)
        {
            Int32[] CeldasFacturados = { 0, 7, 8, 10, 12 };
            DataTable dt = new DataTable();
            this.Dependencia = Escuela;
            this.UsuNombre = RFC;
            grdDatosFactura.DataSource = dt;
            grdDatosFactura.DataSource = GetList(Escuela, RFC);
            grdDatosFactura.DataBind();
            if (grdDatosFactura.Rows.Count > 0)
                CNComun.HideColumns(grdDatosFactura, CeldasFacturados);
            

        }
        private List<CajaFactura> GetList(string Dependencia, string RFC)
        {
            try
            {
                List<CajaFactura> List = new List<CajaFactura>();
                Usur.Usu_Nombre = RFC;
                CNCjaFactura.FacturaCajaConsultaGrid(Usur, ref ObjCjaFactura, Dependencia, txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, RFC, "F", "S", "T", ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public event EventHandler AceptarClicked;
        protected virtual void OnClick(object sender)
        {
            if (this.AceptarClicked != null)
            {
                this.AceptarClicked(sender, new EventArgs());
                ConsultaGridFacturas(this.Dependencia, this.UsuNombre);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            OnClick(sender);

        }

        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBttnRecibo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bttnVerFactura_Click(object sender, EventArgs e)
        {

        }

        protected void grdDatosFactura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList DDL = e.Row.FindControl("ddlFacturas") as DropDownList;
            if (DDL != null)            
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Facturas_Cja", ref DDL, "P_Id_Factura", "P_Tipo", e.Row.Cells[0].Text, "R");
            

        }
    }
}