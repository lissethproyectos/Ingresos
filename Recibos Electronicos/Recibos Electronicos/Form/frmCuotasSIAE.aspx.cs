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
    public partial class frmCuotasSIAE : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        DetConcepto objCuotas =new DetConcepto();
        CN_ConceptoPago CNCuotas = new CN_ConceptoPago();
        string Verificador = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }

        #region <Funciones>
        protected void Inicializar()
        {
            MultiView1.ActiveViewIndex = 0;
            if (Request.QueryString["tipo"] != null)
                SesionUsu.Reporte = Request.QueryString["tipo"];
            else
                SesionUsu.Reporte = string.Empty;

            if (SesionUsu.Reporte == "LNG")
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR_Lenguas", ref ddlDependencias);
            else
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependenciasFiltro, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencias, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            }

            ddlDependencias_SelectedIndexChanged(null, null);
        }

        protected void LimpiarCampos()
        {
            
            txtImporte.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtExtemporaneo.Text = string.Empty;

        }

        private void CargarGrid()
        {
            
            try
            {
                DataTable dt = new DataTable();
                grvCuotas.DataSource = dt;
                grvCuotas.DataSource = GetList();
                grvCuotas.DataBind();
                if (grvCuotas.Rows.Count >= 1)
                {
                    if (SesionUsu.Reporte == "LNG")
                    {
                        int[] Columnas = new int[] { 2, 8 };
                        CNComun.HideColumns(grvCuotas, Columnas);
                    }
                    else
                    {
                        int[] Columnas = new int[] { 2, 8 };
                        CNComun.HideColumns(grvCuotas, Columnas);
                    }
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }

        private List<DetConcepto> GetList()
        {
            try
            {
                List<DetConcepto> List = new List<DetConcepto>();
                objCuotas.Dependencia = ddlDependenciasFiltro.SelectedValue;
                objCuotas.TipoRegistro = ddlTipo.SelectedValue;
                CNCuotas.ConsultarCuotasSIAE(objCuotas,"", "", ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objCuotas.Dependencia = ddlDependencias.SelectedValue;
                objCuotas.Semestre = ddlSemestre.SelectedValue;
                objCuotas.ImporteConcepto =Convert.ToDouble(txtImporte.Text);
                objCuotas.ImporteDetalle= Convert.ToDouble(txtExtemporaneo.Text);
                objCuotas.Porcentaje = txtDescuento.Text;
                if (SesionUsu.Editar == 0)
                    CNCuotas.InsertarCuotasSIAE(ref Verificador, objCuotas);

                else
                    CNCuotas.ActualizarCuotasSIAE(objCuotas, ref Verificador);
              
                if (Verificador == "0")
                {
                    CargarGrid();
                    MultiView1.ActiveViewIndex = 0;
                    containerTipo.Visible = true;
                    ddlDependenciasFiltro.SelectedValue = ddlDependencias.SelectedValue;
                }
                else
                {
                    Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    Verificador = Verificador.Replace("\n", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }

       
        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarCampos();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void grvCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                objCuotas.Dependencia = Convert.ToString(grvCuotas.SelectedRow.Cells[2].Text);
                objCuotas.Semestre = Convert.ToString(grvCuotas.SelectedRow.Cells[9].Text);
                objCuotas.TipoRegistro = Convert.ToString(grvCuotas.SelectedRow.Cells[0].Text);

                ddlDependencias.SelectedValue = objCuotas.Dependencia;
                if (SesionUsu.Reporte == "LNG")
                    ddlSemestre.SelectedValue = Convert.ToString(grvCuotas.SelectedRow.Cells[3].Text);
                else
                    ddlSemestre.SelectedValue = objCuotas.Semestre;

                CNCuotas.ObtenerCuotasSIAE(ref Verificador, objCuotas);
                if (Verificador == "0")
                {
                    LimpiarCampos();
                    MultiView1.ActiveViewIndex = 1;                    
                    txtImporte.Text =Convert.ToString(objCuotas.ImporteConcepto);
                    txtExtemporaneo.Text = Convert.ToString(objCuotas.ImporteDetalle);
                    txtDescuento.Text = Convert.ToString(objCuotas.Porcentaje);
                }
                else
                {
                    Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    Verificador = Verificador.Replace("\n", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void grvCuotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                Verificador = string.Empty;
                objCuotas.Dependencia = Convert.ToString(grvCuotas.Rows[fila].Cells[2].Text);
                objCuotas.Semestre = Convert.ToString(grvCuotas.Rows[fila].Cells[9].Text);
                CNCuotas.EliminarCuotasSIAE(ref Verificador, objCuotas);                
                if (Verificador == "0")
                    CargarGrid();
                else
                {
                    Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    Verificador = Verificador.Replace("\n", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }

            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvCuotas.SelectedIndex = row.RowIndex;
            rowExtemporaneo.Visible = true;
            containerTipo.Visible = false;
            //txtExtemporaneo.Visible=true;
            //lblExtemporaneo.Visible = true;

            //imgBttnBuscar.Visible = true;
            try
            {
                objCuotas.Dependencia = Convert.ToString(grvCuotas.SelectedRow.Cells[2].Text);
                objCuotas.TipoRegistro = Convert.ToString(grvCuotas.SelectedRow.Cells[0].Text);

                //objCuotas.Dependencia = ddlDependencias.SelectedValue;
                if (SesionUsu.Reporte == "LNG")
                {
                    //txtExtemporaneo.Visible = false;
                    //lblExtemporaneo.Visible = false;
                    //imgBttnBuscar.Visible = false;
                    rowExtemporaneo.Visible=false;
                    objCuotas.Semestre = Convert.ToString(grvCuotas.SelectedRow.Cells[8].Text);
                }
                else
                    objCuotas.Semestre = Convert.ToString(grvCuotas.SelectedRow.Cells[3].Text);

                CNCuotas.ObtenerCuotasSIAE(ref Verificador, objCuotas);
                if (Verificador == "0")
                {
                    LimpiarCampos();
                    MultiView1.ActiveViewIndex = 1;
                    SesionUsu.Editar = 1;
                    ddlDependencias.SelectedValue = Convert.ToString(grvCuotas.SelectedRow.Cells[2].Text);
                    ddlSemestre.SelectedValue = Convert.ToString(grvCuotas.SelectedRow.Cells[3].Text); //Convert.ToString(grvCuotas.SelectedRow.Cells[3].Text);
                    txtImporte.Text = Convert.ToString(objCuotas.ImporteConcepto);
                    txtExtemporaneo.Text = Convert.ToString(objCuotas.ImporteDetalle);
                    txtDescuento.Text = Convert.ToString(objCuotas.Porcentaje);
                }
                else
                {
                    Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    Verificador = Verificador.Replace("\n", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            containerTipo.Visible = false;
            SesionUsu.Editar = 0;
            MultiView1.ActiveViewIndex = 1;
        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            containerTipo.Visible = true;
        }

        protected void grvCuotas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCuotas.PageIndex = 0;
            grvCuotas.PageIndex = e.NewPageIndex;
            CargarGrid();

        }

        protected void bttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}