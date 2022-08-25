using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace Recibos_Electronicos.Form
{
    public partial class FrmConceptos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        ConceptoPago ObjConcepto = new ConceptoPago();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        //List<ConceptoPago> ListConceptos = new List<ConceptoPago>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                Inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "Grid", "Conceptos();", true);
        }

        #region <Botones y Eventos>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                string Host = Request.ServerVariables["REMOTE_HOST"].ToString();
                string User = Request.ServerVariables["REMOTE_USER"].ToString();


                ObjConcepto.IdConcepto = SesionUsu.Id_Concepto;
                ObjConcepto.ClaveConcepto = txtClave.Text;
                ObjConcepto.Descripcion = txtConcepto.Text;
                ObjConcepto.ImporteConcepto = Convert.ToDouble(txtImporte.Text);
                ObjConcepto.Status = Convert.ToChar(rdoStatus.SelectedValue);
                //ObjConcepto.Usu_Nombre = SesionUsu.Usu_Nombre + ' ' + IP + ' ' + Host + ' ' + User;
                if (chkEmitir_Via_Web.Checked)
                    ObjConcepto.EmitirWeb = 'S';
                else
                    ObjConcepto.EmitirWeb = 'N';
                if (chkCobro_x_Materia.Checked)
                    ObjConcepto.CobroXMateria = 'S';
                else
                    ObjConcepto.CobroXMateria = 'N';
                ObjConcepto.MaxMateria = txtMaximo_Materias.Text;
                if (chkPermite_Duplicidad.Checked)
                    ObjConcepto.PermiteDuplicidad = 'S';
                else
                    ObjConcepto.PermiteDuplicidad = 'N';
                if (chkAplica_Descuento.Checked)
                    ObjConcepto.AplicaDescuento = 'S';
                else
                    ObjConcepto.AplicaDescuento = 'N';
                if (chkSeleccionable.Checked)
                    ObjConcepto.Bloqueado = 'N'; //'S';
                else
                    ObjConcepto.Bloqueado = 'S'; //'N';
                ObjConcepto.FechaInicial = txtFecha_Inicial.Text;
                ObjConcepto.FechaFinal = txtFecha_Final.Text;
                ObjConcepto.Porcentaje = txtPorcentaje.Text;
                ObjConcepto.Observaciones = txtObservaciones.Text;
                ObjConcepto.Usu_Nombre = SesionUsu.Usu_Nombre;

                if (SesionUsu.Editar == 0)
                    CNConcepto.InsertarConceptoPago(ref Verificador, ObjConcepto);
                else
                    CNConcepto.ActualizaConceptoPago(ref Verificador, ref ObjConcepto);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";
                    mltViewConceptos.ActiveViewIndex = 0;
                    Session["GridConceptos"] = null;
                    CargarGrid();
                    //Nuevo();
                    //Inicializar();

                }
                else
                {
                    //lblMsj.Text = Verificador;
                    Verificador = Verificador.Substring(0, 30);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;

                //lblMsj.Text = ex.Message; 
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mltViewConceptos.ActiveViewIndex = 0;
            Nuevo();
        }
        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {

            string status = "S"; // (CkbEstatus.Checked==true) ? "S" : "N";            
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP024&Nivel=" + ddlNivel.SelectedValue + "&status=" + status;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string status = "S"; //(CkbEstatus.Checked == true) ? "S" : "N";
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP025&Nivel=" + ddlNivel.SelectedValue + "&status=" + status;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
        protected void CkbEstatus_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            //mltViewConceptos.SetActiveView(Hoja2);
            mltViewConceptos.ActiveViewIndex = 1;
            SesionUsu.Editar = 0;
            SesionUsu.Id_Concepto = 0;
            Nuevo();
        }
        protected void linkBttnAgregarReg_Click(object sender, EventArgs e)
        {
            mltViewConceptos.ActiveViewIndex = 1;
            SesionUsu.Editar = 0;
            SesionUsu.Id_Concepto = 0;
            Nuevo();
        }
        protected void grvConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConceptos.PageIndex = 0;
            grvConceptos.PageIndex = e.NewPageIndex;
            CargarGrid();

        }
        protected void grvConceptos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                ObjConcepto.IdConcepto = Convert.ToInt32(grvConceptos.Rows[e.NewSelectedIndex].Cells[0].Text);
                SesionUsu.Id_Concepto = ObjConcepto.IdConcepto;
                CNConcepto.ConsultarConceptoPago(ref Verificador, ref ObjConcepto);
                if (Verificador == "0")
                {

                    txtClave.Text = ObjConcepto.ClaveConcepto;
                    txtConcepto.Text = ObjConcepto.Descripcion;
                    txtImporte.Text = Convert.ToString(ObjConcepto.ImporteConcepto);
                    rdoStatus.SelectedValue = Convert.ToString(ObjConcepto.Status);
                    if (ObjConcepto.EmitirWeb == 'S')
                        chkEmitir_Via_Web.Checked = true;
                    else
                        chkEmitir_Via_Web.Checked = false;
                    if (ObjConcepto.CobroXMateria == 'S')
                        chkCobro_x_Materia.Checked = true;
                    else
                        chkCobro_x_Materia.Checked = false;
                    txtMaximo_Materias.Text = ObjConcepto.MaxMateria;
                    if (ObjConcepto.PermiteDuplicidad == 'S')
                        chkPermite_Duplicidad.Checked = true;
                    else
                        chkPermite_Duplicidad.Checked = false;
                    if (ObjConcepto.AplicaDescuento == 'S')
                        chkAplica_Descuento.Checked = true;
                    else
                        chkAplica_Descuento.Checked = false;
                    if (ObjConcepto.Bloqueado == 'S')
                        chkSeleccionable.Checked = false; //true;
                    else
                        chkSeleccionable.Checked = true; //false;
                    txtFecha_Inicial.Text = ObjConcepto.FechaInicial;
                    txtFecha_Final.Text = ObjConcepto.FechaFinal;
                    txtPorcentaje.Text = ObjConcepto.Porcentaje;
                    txtObservaciones.Text = ObjConcepto.Observaciones;
                    mltViewConceptos.ActiveViewIndex = 1;
                    SesionUsu.Editar = 1;
                }
                else
                {
                    txtClave.Text = string.Empty;
                    txtConcepto.Text = string.Empty;
                    txtImporte.Text = string.Empty;
                    rdoStatus.SelectedValue = "A";
                    chkEmitir_Via_Web.Checked = false;
                    chkCobro_x_Materia.Checked = false;
                    txtMaximo_Materias.Text = string.Empty;
                    chkPermite_Duplicidad.Checked = false;
                    chkAplica_Descuento.Checked = false;
                    chkSeleccionable.Checked = false;
                    txtFecha_Inicial.Text = string.Empty;
                    txtFecha_Final.Text = string.Empty;
                    txtPorcentaje.Text = string.Empty;
                    txtObservaciones.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        #endregion
        #region <Funciones y Sub>

        private void Inicializar()
        {
            mltViewConceptos.ActiveViewIndex = 0;
            //Session["GridConceptos"] = null;
            CargarCombos();
            CargarGrid();
        }
        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                ddlNivel.SelectedValue = "L";
                //ddlNivel.Items.Insert(0, new ListItem("--Todos--", "T"));
                //ddlNivel.Items.Remove(ddlNivel.Items[1]);
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void Nuevo()
        {
            txtClave.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtImporte.Text = string.Empty;
            rdoStatus.SelectedValue = "A";
            chkEmitir_Via_Web.Checked = false;
            chkCobro_x_Materia.Checked = false;
            txtMaximo_Materias.Text = string.Empty;
            chkPermite_Duplicidad.Checked = false;
            chkAplica_Descuento.Checked = false;
            chkSeleccionable.Checked = false;
            txtFecha_Inicial.Text = string.Empty;
            txtFecha_Final.Text = string.Empty;
            txtPorcentaje.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            chkTipo.Checked = false;

        }
        private List<ConceptoPago> GetList()
        {

            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                string Tipo = string.Empty;
                ObjConcepto.Nivel = ddlNivel.SelectedValue;
                //if (CkbEstatus.Checked)
                //    ObjConcepto.Status = 'S';
                //else
                //    ObjConcepto.Status = 'N';

                ObjConcepto.Status = 'S';

                Tipo = (chkTipo.Checked == true) ? "N" : "S";

                CNConcepto.ConsultarConceptoPago(ref ObjConcepto, "1", false, Tipo, "", ref List);



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
                grvConceptos.DataSource = dt;
                grvConceptos.DataSource = GetList();
                grvConceptos.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void HideColumns(GridView grdView)
        {

            grdView.HeaderRow.Cells[0].Visible = false;
            foreach (GridViewRow row in grdView.Rows)
            {
                row.Cells[0].Visible = false;
            }

        }


        #endregion

        protected void ddlOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }


        protected void imgBttnCopiar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvConceptos.SelectedIndex = row.RowIndex;
            lblMsjCopia.Text = "Se copia el número de concepto " + grvConceptos.SelectedRow.Cells[2].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupClonar", "$('#modalClonar').modal('show')", true);
            //modal.Show();
        }

        protected void btnGuardar_C_Click(object sender, EventArgs e)
        {
            ObjConcepto.Id = Convert.ToInt32(grvConceptos.SelectedRow.Cells[0].Text);
            ObjConcepto.ClaveConcepto = Convert.ToString(grvConceptos.SelectedRow.Cells[2].Text);
            ObjConcepto.Seleccionable = (chkTipoC.Checked == true) ? "N" : "S";
            Verificador = string.Empty;
            CNConcepto.ClonarConcepto(ObjConcepto, SesionUsu.Usu_Nombre, ref Verificador);
            if (Verificador == "0")
            {
                Inicializar();
                //modal.Hide();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El registro fue duplicado correctamente.');", true);

            }
            else
            {
                string MsjError = Verificador.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            //Session["GridConceptos"] = null;
            CargarGrid();
        }

        protected void btnCancelar_C_Click(object sender, EventArgs e)
        {
            //modal.Hide();
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}