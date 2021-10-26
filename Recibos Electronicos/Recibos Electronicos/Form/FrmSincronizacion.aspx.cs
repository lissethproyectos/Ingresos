using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CapaEntidad;
using CapaNegocio;
using System.Diagnostics;
using System.Security.Permissions;

#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace Recibos_Electronicos.Form
{

    public partial class FrmSincronizacion : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;

        Sesion SesionUsu = new Sesion();
        Registro ObjRegistros = new Registro();
        CN_Registro CNRegistros = new CN_Registro();
        CN_Comun CNComun = new CN_Comun();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                Inicializar();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "GridSincronizacion", "Sincronizacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridMaterializadas", "Materializadas();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridInhabiles", "Inhabiles();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridInhabilesRecibos", "InhabilesRecibos();", true);            
        }
        #region <Botones y Eventos>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            //CargarGridMatricula();
        }
        protected void linkSincronizar_Click(object sender, EventArgs e)
        {

            try
            {
                //string pathArchivoBat = (@"C:\Users\Admin\Documents\Visual Studio 2010\Projects\Recibos Electronicos3\Recibos Electronicos\bat\respaldobd.bat");
                //Process proceso = new Process();
                //proceso.StartInfo.FileName = pathArchivoBat;
                //proceso.Start();
                //proceso.WaitForExit();           

                Process process = new Process();
                process.StartInfo.FileName = @"C:\Users\Admin\Documents\run.bat";
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();


            }
            catch
            {

            }

        }


        protected void grvDatos_Grals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grvDatos_Grals.PageIndex = 0;
            //grvDatos_Grals.PageIndex = e.NewPageIndex;
            //CargarGridMatricula();
        }

        protected void grvRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRegistros.PageIndex = 0;
            grvRegistros.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            //mltViewSauce.ActiveViewIndex = 0;

        }
        protected void imgBttnConsulta_Mat_Click(object sender, ImageClickEventArgs e)
        {
            lblMsj.Text = string.Empty;
            //mltViewSauce.SetActiveView(vwConsulaMat);
        }

        #endregion
        #region <Funciones y Sub>

        private void Inicializar()
        {
            //mltViewSauce.SetActiveView(vwSincroniza);
            CargarGrid();
            CargarGridVistasMaterializadas();
            CargarGrid_view_inhabiles();
            CargarGrid_view_inhabiles_recibos();
        }
        private List<Registro> GetList1()
        {
            try
            {
                List<Registro> List = new List<Registro>();

                CNRegistros.ConsultarRegistros1(ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Registro> GetList()
        {
            try
            {
                List<Registro> List = new List<Registro>();

                CNRegistros.ConsultarRegistros(ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Registro> GetList2()
        {
            try
            {
                List<Registro> List = new List<Registro>();

                CNRegistros.ConsultarRegistros2(ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Registro> GetListRecibos()
        {
            try
            {
                List<Registro> List = new List<Registro>();
                CNRegistros.ConsultarRegistrosRecibos(ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //private List<Registro> GetListMatricula()
        //{
        //    try
        //    {
        //        List<Registro> List = new List<Registro>();
        //        ObjRegistros.Matricula = txtMatricula.Text.ToUpper();
        //        CNRegistros.ConsultarRegistroMatricula(ref ObjRegistros, ref List);
        //        txtNombre.Text = ObjRegistros.Nombre;
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        private void CargarGridVistasMaterializadas()
        {
            try
            {
                DataTable dt = new DataTable();
                rgvVMaterializadas.DataSource = dt;
                rgvVMaterializadas.DataSource = GetList1();
                rgvVMaterializadas.DataBind();
                //if (grvRegistros.Rows.Count > 0)
                //    if (grvRegistros.Rows[0].Cells[3].Text == "0")
                //        grvRegistros.Columns[5].Visible = true;
                //    else
                //        grvRegistros.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }


        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvRegistros.DataSource = dt;
                grvRegistros.DataSource = GetList();
                grvRegistros.DataBind();
                //if (grvRegistros.Rows.Count > 0)
                //    if (grvRegistros.Rows[0].Cells[3].Text == "0")
                //        grvRegistros.Columns[5].Visible = true;
                //    else
                //        grvRegistros.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        private void CargarGrid_view_inhabiles()
        {
            try
            {
                DataTable dt = new DataTable();
                grvInhabiles.DataSource = dt;
                grvInhabiles.DataSource = GetList2();
                grvInhabiles.DataBind();

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }

        private void CargarGrid_view_inhabiles_recibos()
        {
            try
            {
                DataTable dt = new DataTable();
                grvInhabilesRecibos.DataSource = dt;
                grvInhabilesRecibos.DataSource = GetListRecibos();
                grvInhabilesRecibos.DataBind();

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        //private void CargarGridMatricula()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        grvDatos_Grals.DataSource = dt;
        //        grvDatos_Grals.DataSource = GetListMatricula();
        //        grvDatos_Grals.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsj.Text = ex.Message;
        //    }
        //}

        #endregion

        protected void grvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rgvVMaterializadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            rgvVMaterializadas.PageIndex = 0;
            rgvVMaterializadas.PageIndex = e.NewPageIndex;
            CargarGridVistasMaterializadas();
        }

        protected void rgvVMaterializadas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                rgvVMaterializadas.SelectedIndex = row.RowIndex;
                ObjRegistros.name = rgvVMaterializadas.SelectedRow.Cells[0].Text;

                CNRegistros.refresh_vmaterilaizada(ObjRegistros, ref Verificador);
                if (Verificador == "0")
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'La información se ha sincronizado correctamente');", true); //lblMsj.Text = ex.Message;blMsj.Text = "La información se ha sincronizado correctamente";
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void rgv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnhabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                CNRegistros.habilita_vmaterilaizada(ObjRegistros, ref Verificador);
                if (Verificador == "0")
                    lblMsj.Text = "La información se ha sincronizado correctamente";
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void grvInhabilesRecibos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjRegistros.name = grvInhabilesRecibos.SelectedRow.Cells[0].Text;
            CNRegistros.refresh_vmaterilaizada_recibos(ObjRegistros, ref Verificador);
            if (Verificador == "0")
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'La información se ha sincronizado correctamente');", true); //lblMsj.Text = ex.Message;blMsj.Text = "La información se ha sincronizado correctamente";
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }
    }

}