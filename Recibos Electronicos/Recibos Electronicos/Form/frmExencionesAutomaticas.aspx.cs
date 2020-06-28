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
    public partial class frmExencionesAutomaticas : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        string Verificador = string.Empty;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();
        }


        public void Inicializar()
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencias, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCicloAnt, "INGRESOS");
            //ddlCiclo.Items.Remove(lis)
            ddlCiclo_SelectedIndexChanged(null, null);
            CargarGrid();
            //ddlCiclo.Items.Clear(ddlCiclo.Items.IndexOf(ddlCiclo.Items.FindByValue("20")));
        }

        private void CargarGrid()
        {
            try
            {
                //grdExentos.AllowPaging = false;
                DataTable dt = new DataTable();
                grdExentos.DataSource = dt;
                grdExentos.DataSource = GetList();
                

                grdExentos.DataBind();
                
                //Label lblTotalExentos = (Label)grdExentos.BottomPagerRow.FindControl("lblTotal");
                //lblTotalExentos.Text = Total;

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridStatusAlumno()
        {
            try
            {
                //grdExentos.AllowPaging = false;
                DataTable dt = new DataTable();
                grdStatusAlumno.DataSource = dt;
                grdStatusAlumno.DataSource = GetListStatusAlumno();


                grdStatusAlumno.DataBind();

                //Label lblTotalExentos = (Label)grdExentos.BottomPagerRow.FindControl("lblTotal");
                //lblTotalExentos.Text = Total;

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private List<Alumno> GetList()
        {
            Verificador = string.Empty;

            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Dependencia = ddlDependencias.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCiclo.SelectedValue;
                ObjAlumno.StatusMatricula = "T";
                ObjAlumno.Nivel = "L";
                ObjAlumno.TipoDescuento = (ddlSindicato.SelectedValue);
                CNAlumno.ConsultarDescuentoAutomatico(ref ObjAlumno, ref List);
                lblTotExenciones.Text =Convert.ToString(List.Count);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Alumno> GetListStatusAlumno()
        {
            Verificador = string.Empty;

            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Matricula = txtMatricula.Text;
                CNAlumno.ConsultarAlumnoStatus(ref ObjAlumno, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
            grdExentos.AllowPaging = true;
            grdExentos.PageSize = 20;
            

        }

        protected void bttnExenciones_Click(object sender, EventArgs e)
        {
            ObjAlumno.Dependencia = ddlDependencias.SelectedValue;
            ObjAlumno.CicloEscolar = ddlCiclo.SelectedValue;
            ObjAlumno.StatusMatricula = "T";
            ObjAlumno.Nivel = "L";
            ObjAlumno.TipoDescuento = ddlSindicato.SelectedValue;
            Verificador = string.Empty;
            try
            {
                CNAlumno.GeneraExencionesAutomaticas(ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        protected void bttnVerificar_Click(object sender, EventArgs e)
        {
            ObjAlumno.Matricula = txtMatricula.Text;
            CargarGridStatusAlumno();
            //CNAlumno.ConsultarAlumnoStatus(ref ObjAlumno,)
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string CicloAnt = ddlCiclo.SelectedValue;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP053&ciclo=" + ddlCiclo.SelectedValue + "&ciclo_ant=" + ddlCicloAnt.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void ddlCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCicloIni.Text = ddlCiclo.SelectedItem.Text;
            CargarGrid();
            grdExentos.AllowPaging = true;
            grdExentos.PageSize = 20;
        }

        protected void ddlSindicato_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
            grdExentos.AllowPaging = true;
            grdExentos.PageSize = 20;

        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
            grdExentos.AllowPaging = true;
            grdExentos.PageSize = 20;
        }

        protected void grdExentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdExentos.PageIndex = 0;
            grdExentos.PageIndex = e.NewPageIndex;
            CargarGrid();

        }
    }
}