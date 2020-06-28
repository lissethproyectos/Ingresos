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
    public partial class DefaultAlumnos : System.Web.UI.Page
    {
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CajaFactura ObjCjaFactura = new CajaFactura();
        #region<Funciones>  
        protected void Buscador1_AceptarClicked(object sender, EventArgs e)
        {
            this.Recibos.UsuNombre = SesionUsu.Usu_Nombre;
            this.Recibos.UsuNoControl = SesionUsu.Usu_NoControl;
            this.Recibos.UsuTipo = Convert.ToString(SesionUsu.Usu_TipoUsu);
            this.Recibos.Dependencia = ddlDependencia.SelectedValue;
        }
        protected void BuscadorFacturas_AceptarClicked(object sender, EventArgs e)
        {
            this.Facturas.UsuNombre = SesionUsu.Usu_Nombre;
            this.Facturas.Dependencia = ddlDependencia.SelectedValue;
            //this.Facturas.ConsultaGridFacturas(ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre);

        }
        public void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", Convert.ToString(SesionUsu.Usu_TipoUsu), SesionUsu.Usu_Nombre);
                ddlDependencia_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void Inicializar()
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                CargarCombos();
                if (Convert.ToString(SesionUsu.Usu_TipoUsu) == "2")
                    imgBttnDescuentos.Visible = false;
                //CargarGrid();                
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
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
        protected void imgBttnInicio_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
        }
        protected void imgBttnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void imgBttnRecibos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlDependencia.SelectedValue != "0")
                {
                    MultiView1.ActiveViewIndex = 1;
                    MultiView2.ActiveViewIndex = 0;
                    this.Recibos.ConsultaGridRecibos(ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre, SesionUsu.Usu_NoControl, Convert.ToString(SesionUsu.Usu_TipoUsu));

                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }

        }
        protected void imgBttnFacturas0_Click(object sender, ImageClickEventArgs e)
        {
            imgBttnFacturas_Click(null, null);
        }
        protected void imgBttnFacturas_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlDependencia.SelectedValue != "0")
                {
                    MultiView1.ActiveViewIndex = 1;
                    MultiView2.ActiveViewIndex = 2;
                    this.Facturas.ConsultaGridFacturas(ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre);
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }

        }
        protected void imgBttnDescuentos1_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void imgBttnDescuentos_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlDependencia.SelectedValue != "0")
                {
                    MultiView1.ActiveViewIndex = 1;
                    MultiView2.ActiveViewIndex = 0;
                    this.Exenciones.ConsultaGridExenciones(ddlDependencia.SelectedValue, SesionUsu.Usu_Nombre);
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }


        }

        protected void imgBttnRecibos0_Click(object sender, ImageClickEventArgs e)
        {
            imgBttnRecibos_Click(null, null);
        }
    }
}