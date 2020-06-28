using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.ControlUsuario
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        Factura ObjFactura = new Factura();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        Usuario objUsuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        Int32[] Celdas = { 0, 9, 10 };

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Matricula;
        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }

        private string _UsuTipo;
        public string UsuTipo
        {
            get { return _UsuTipo; }
            set { _UsuTipo = value; }
        }

        private string _UsuNombre;
        public string UsuNombre
        {
            get { return _UsuNombre; }
            set { _UsuNombre = value; }
        }

        private string _UsuNoControl;
        public string UsuNoControl
        {
            get { return _UsuNoControl; }
            set { _UsuNoControl = value; }
        }

        #region <Funciones>
      
        public event EventHandler AceptarClicked;
        protected virtual void OnClick(object sender)
        {
            if (this.AceptarClicked != null)
            {
                this.AceptarClicked(sender, new EventArgs());
                ConsultaGridRecibos(this.Dependencia,this.UsuNombre,this.UsuNoControl,this.UsuTipo);
            }
        }



        public void ConsultaGridRecibos(string Dependencia, string NombreUsuario, string NoControlUsuario, string TipoUsuario)
        {
            try
            {
                grdDatosFactura.DataSource = GetList(Dependencia, NombreUsuario, NoControlUsuario, TipoUsuario);
                grdDatosFactura.DataBind();

                if (grdDatosFactura.Rows.Count > 0)
                    CNComun.HideColumns(grdDatosFactura, Celdas);


            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private List<Factura> GetList(string Dependencia, string NombreUsuario, string NoControlUsuario, string TipoUsuario)
        {
            try
            {
                List<Factura> List = new List<Factura>();
                objUsuario.Usu_Nombre = NombreUsuario;
                objUsuario.Usu_NoControl = NoControlUsuario;
                objUsuario.Usu_TipoUsu =Convert.ToInt32(TipoUsuario);
                CNFactura.FacturaConsultaGrid(objUsuario, ref ObjFactura, Dependencia, txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ref List);
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
            if(!IsPostBack)
            {
                txtFecha_Factura_Ini.Text = "01/01/"+System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                //imgBttnBuscar_Click(null, null);
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            OnClick(sender);
            //grdDatosFactura.DataSource = GetList(this.Dependencia, this.UsuNombre,this.UsuNoControl,this.UsuTipo);
            //grdDatosFactura.DataBind();

            //if (grdDatosFactura.Rows.Count > 0)
            //    CNComun.HideColumns(grdDatosFactura, Celdas);
        }

        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}