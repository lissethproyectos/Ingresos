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
    public partial class frmCuotasSIAE_Lenguas : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        CuotasLenguasSIAE objCuotas =new CuotasLenguasSIAE();
        CN_Cuotas_Lenguas_SIAE CNCuotas = new CN_Cuotas_Lenguas_SIAE();


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
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR_Lenguas", ref ddlDependencias);           
            ddlDependencias_SelectedIndexChanged(null, null);
        }

        protected void LimpiarCampos()
        {
            
            //txtImporte_Ingles.Text = string.Empty;
            //txtDescuento.Text = string.Empty;
            //txtExtemporaneo.Text = string.Empty;

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
                   int[] Columnas = new int[] { 0 };
                   CNComun.HideColumns(grvCuotas, Columnas);
                   
                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }

        private List<CuotasLenguasSIAE> GetList()
        {
            try
            {
                List<CuotasLenguasSIAE> List = new List<CuotasLenguasSIAE>();
                objCuotas.Escuela = ddlDependencias.SelectedValue;
                objCuotas.Tipo = ddlTipo1.SelectedValue;
                CNCuotas.ConsultarCuotasLenguas(objCuotas, ref List);
                //CNCuotas.ConsultarCuotasLenguas(objCuotas,"", "", ref List);

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
            Verificador = string.Empty;
            try
            {
                objCuotas.Escuela = ddlDependencias.SelectedValue;
                objCuotas.Nivel = Convert.ToInt32(ddlSemestre.SelectedValue);
                objCuotas.Tipo = ddlTipo.SelectedValue;
                objCuotas.Importe_Ingles = Convert.ToDouble(txtImporte_Ingles.Text);
                objCuotas.Importe_Italiano = Convert.ToDouble(txtImporte_Italiano.Text);                               
                objCuotas.Importe_Frances = Convert.ToDouble(txtImporte_Frances.Text);
                objCuotas.Importe_Aleman = Convert.ToDouble(txtImporte_Aleman.Text);
                objCuotas.Importe_Chino = Convert.ToDouble(txtImporte_Chino.Text);
                objCuotas.Importe_Tzotzil = Convert.ToDouble(txtImporte_Tzotzil.Text);
                objCuotas.Importe_Tzental = Convert.ToDouble(txtImporte_Tzental.Text);
                objCuotas.Importe_Espaniol = Convert.ToDouble(txtImporte_Espaniol.Text);
                CNCuotas.InsertarCuotasLenguas(ref Verificador, objCuotas);
                if (Verificador == "0")
                {
                    MultiView1.ActiveViewIndex = 0;
                    CargarGrid();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }


            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);            }
        }

       
        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarCampos();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void grvCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verificador = string.Empty;
            //try
            //{
            //    objCuotas.Dependencia = Convert.ToString(grvCuotas.SelectedRow.Cells[2].Text);
            //    objCuotas.Semestre = Convert.ToString(grvCuotas.SelectedRow.Cells[9].Text);
            //    objCuotas.TipoRegistro = Convert.ToString(grvCuotas.SelectedRow.Cells[0].Text);

            //    ddlDependencias.SelectedValue = objCuotas.Dependencia;
            //    if (SesionUsu.Reporte == "LNG")
            //        ddlSemestre.SelectedValue = Convert.ToString(grvCuotas.SelectedRow.Cells[3].Text);
            //    else
            //        ddlSemestre.SelectedValue = objCuotas.Semestre;

            //    CNCuotas.ObtenerCuotasSIAE(ref Verificador, objCuotas);
            //    if (Verificador == "0")
            //    {
            //        LimpiarCampos();
            //        MultiView1.ActiveViewIndex = 1;                    
            //        txtImporte_Ingles.Text =Convert.ToString(objCuotas.ImporteConcepto);
            //        txtExtemporaneo.Text = Convert.ToString(objCuotas.ImporteDetalle);
            //        txtDescuento.Text = Convert.ToString(objCuotas.Porcentaje);
            //    }
            //    else
            //    {
            //        Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
            //        Verificador = Verificador.Replace("\n", "");
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            //    }

            //}
            //catch (Exception ex)
            //{
            //    Verificador = ex.Message;
            //    CNComun.VerificaTextoMensajeError(ref Verificador);
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            //}
        }

        protected void grvCuotas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //try
            //{
            //    int fila = e.RowIndex;
            //    Verificador = string.Empty;
            //    objCuotas.Dependencia = Convert.ToString(grvCuotas.Rows[fila].Cells[2].Text);
            //    objCuotas.Semestre = Convert.ToString(grvCuotas.Rows[fila].Cells[9].Text);
            //    CNCuotas.EliminarCuotasSIAE(ref Verificador, objCuotas);                
            //    if (Verificador == "0")
            //        CargarGrid();
            //    else
            //    {
            //        Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
            //        Verificador = Verificador.Replace("\n", "");
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            //    }
            //}

            //catch (Exception ex)
            //{
            //    string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
            //    MsjError = MsjError.Replace("\n", "");
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            //}
        }


        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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
        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}