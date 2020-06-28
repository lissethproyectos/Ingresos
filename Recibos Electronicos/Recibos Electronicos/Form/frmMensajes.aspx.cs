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
   
    public partial class frmMensajes : System.Web.UI.Page
    {
        #region <Variables>
        Mensaje ObjMensaje = new Mensaje();
        CN_Mensaje CNMensaje = new CN_Mensaje();
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        string Verificador = string.Empty;
        #endregion

        #region <Funciones y Sub>
        private List<Mensaje> GetList()
        {
            try
            {
                List<Mensaje> List = new List<Mensaje>();
                ObjMensaje.Tipo_Usuario = DDLTipoUsu.SelectedValue;
                ObjMensaje.Fecha_inicial = txtFecha_Inicial.Text;
                ObjMensaje.Fecha_final = txtFecha_Final.Text;
                ObjMensaje.Status = rdoBttnStatus.SelectedValue;
                CNMensaje.ConsultarMensajes(ObjMensaje, ref List);
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
                grvMensajes.DataSource = dt;
                grvMensajes.DataSource = GetList();
                grvMensajes.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }

        }
        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {                
                MultiView1.ActiveViewIndex = 0;
                CargarCombos();
                CargarGrid();
            }
        }

        protected void grvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ObjMensaje.TMensaje = txtMensaje.Text;
                ObjMensaje.Fecha_inicial = txtFecha_Inicial.Text;
                ObjMensaje.Fecha_final = txtFecha_Final.Text;
                ObjMensaje.Status = rdoBttnStatus.SelectedValue;
                ObjMensaje.Tipo_Usuario = DDLTipoUsu.SelectedValue;
                ObjMensaje.Dependencia = (DDLTipoUsu.SelectedValue=="1")?"99999":ddlDependencia.SelectedValue;
                if (SesionUsu.Editar == 0)
                    CNMensaje.MensajeInsertar(ObjMensaje, ref Verificador);
                else
                {
                    ObjMensaje.IdMensaje =Convert.ToInt32(grvMensajes.SelectedRow.Cells[0].Text);
                    CNMensaje.MensajeEditar(ObjMensaje, ref Verificador);
                }

                if (Verificador == "0")
                {
                    SesionUsu.Editar = 0;
                    MultiView1.ActiveViewIndex = 0;
                    ObjMensaje.IdMensaje = 0;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Los datos han sido guardados correctamente.');", true); //lblMsj.Text = ex.Message;
                }

                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {

            ObjMensaje.IdMensaje = Convert.ToInt32(grvMensajes.SelectedRow.Cells[0].Text);
            CNMensaje.MensajeEditar(ObjMensaje, ref Verificador);
        }

        protected void grvMensajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                Verificador = string.Empty;
                ObjMensaje.IdMensaje = Convert.ToInt32(grvMensajes.Rows[fila].Cells[0].Text);
                CNMensaje.MensajeEliminar(ObjMensaje, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                //grvAlumnos.DataSource = ListArch;
                //grvAlumnos.DataBind();
            }

            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void grvMensajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grvMensajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            SesionUsu.Editar = 1;
            try
            {                
                ObjMensaje.IdMensaje = Convert.ToInt32(grvMensajes.SelectedRow.Cells[0].Text);
                CNMensaje.ObtenerMensajes(ref ObjMensaje, ref Verificador);
                if (Verificador == "0")
                {
                    DDLTipoUsu.SelectedValue = ObjMensaje.Tipo_Usuario;
                    DDLTipoUsu_SelectedIndexChanged(null, null);
                    ddlDependencia.SelectedValue = (ObjMensaje.Tipo_Usuario == "3") ? ObjMensaje.Dependencia : "00000";
                    txtMensaje.Text = ObjMensaje.TMensaje;
                    txtFecha_Inicial.Text = ObjMensaje.Fecha_inicial;
                    txtFecha_Final.Text = ObjMensaje.Fecha_final;
                    rdoBttnStatus.SelectedValue = ObjMensaje.Status;
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void DDLTipoUsu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDependencia.Visible = (DDLTipoUsu.SelectedValue == "3") ? true : false;
            ddlDependencia.Visible = (DDLTipoUsu.SelectedValue == "3")?true:false;            
        }
    }
}