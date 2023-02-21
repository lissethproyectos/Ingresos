using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Form
{
    public partial class frmCuotasPosgrado : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        PagosPosgrado objCuotas = new PagosPosgrado();
        CN_PagosPosgrado CNCuotas = new CN_PagosPosgrado();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }
        private void Inicializar()
        {
            Verificador = string.Empty;
            try
            {
                Cargarcombos();
            }
            catch (Exception ex)
            {

                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void Cargarcombos()
        {
            Verificador = string.Empty;
            try
            {
                CNComun.LlenaCombo("PKG_POSGRADO.Obt_Combo_Escuelas", ref DDLEscuelas, "p_usuario", SesionUsu.Usu_Nombre, "SIAE");
            }
            catch (Exception ex)
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador  + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        protected void DDLEscuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_POSGRADO.Obt_Combo_Carreras", ref DDLCarreras, "p_usuario", SesionUsu.Usu_Nombre, "SIAE");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;

            }
        }

        protected void linkBttnVerCuotas_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                CargarGrid();
            }
            catch(Exception ex)
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] { 0, 9, 10 };
            Int32[] CeldasAdmin = new Int32[] { 0, 10 };
            try
            {
                DataTable dt = new DataTable();
                grdCuotas.DataSource = dt;
                grdCuotas.DataSource = GetList();
                grdCuotas.DataBind();               
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private List<PagosPosgrado> GetList()
        {
            try
            {
                List<PagosPosgrado> List = new List<PagosPosgrado>();
                //objCuotas.Matricula = txtMatricula.Text;
                objCuotas.Escuela = DDLEscuelas.SelectedValue;
                objCuotas.Carrera = DDLCarreras.SelectedValue;
                CNCuotas.ConsultarPagosPosgrado(objCuotas, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //PKG_POSGRADO.Obt_Combo_Escuelas p_usuario
        //PKG_POSGRADO.Obt_Combo_Carreras P_Dependencia
    }
}