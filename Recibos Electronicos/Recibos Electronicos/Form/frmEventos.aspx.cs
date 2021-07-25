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
    public partial class frmEventos : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Usuario Usuario = new Usuario();
        Factura ObjFactura = new Factura();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        CN_Alumno CNCliente = new CN_Alumno();
        CN_Factura CNFactura = new CN_Factura();
        CN_Evento CNeventos = new CN_Evento();
        CN_Alumno CNAlumno = new CN_Alumno();
        Evento Objeventos = new Evento();
        string Verificador = string.Empty;
        string MsjError = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            Int32[] Celdas1 = new Int32[] { 10, 11, 13 };
            if (!IsPostBack)
            {
                CargarCombos();
                //linkBttnBuscar_Click(null, null);
                MultiView1.ActiveViewIndex = 0;
            }

            //if (grdEventos.Rows.Count > 0)
            //{
            //    CNComun.HideColumns2(grdEventos, Celdas1);
                ScriptManager.RegisterStartupScript(this, GetType(), "GridEventos", "Eventos();", true);
            //}
        }


        private void CargarCombos()
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Ejercicios_Eventos", ref ddlEjercicio, "INGRESOS");
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            ddlEjercicio.SelectedIndex = 0;
            DDLDependencia.SelectedIndex = 0;
            CargarGriEventos();

            //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
            //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Periodo_Pago", ref ddlTipo_Periodo, "INGRESOS");
            ////DDLTipoParticipante_SelectedIndexChanged(null, null);
            //ddlTipo_Periodo.SelectedValue = "20";
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGriEventos();
        }

        private void CargarGriEventos()
        {
            Int32[] Celdas1 = new Int32[] { 10, 11, 13 };
            grdEventos.DataSource = null;
            grdEventos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();
                //if (grdEventos.Rows.Count > 0)
                //    CNComun.HideColumns(grdEventos, Celdas1);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> List = new List<Evento>();
                Evento Objeventos = new Evento();
                Objeventos.Dependencia = DDLDependencia.SelectedValue;
                Objeventos.Status = ddlStatusB.SelectedValue;
                Objeventos.Tipo = ddlDirigido0.SelectedValue;
                Objeventos.Anio = Convert.ToInt32(ddlEjercicio.SelectedValue);
                CNeventos.ConsultarEventos(ref Objeventos, ref List, "");
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEventos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grdEventos_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdEventos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}