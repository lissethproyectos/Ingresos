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
    public partial class frmCatProductosVarios : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Bien objBien = new Bien();
        Bien objServicio = new Bien();
        CN_Bien CNBien = new CN_Bien();
        CN_Comun CNComun = new CN_Comun();
        string Verificador = string.Empty;
        string MsjError = string.Empty;
        List<Comun> ListConceptos = new List<Comun>();
        #endregion
        #region <Grids>
        private void CargarCombos()
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipo_Ventas", ref DDLTipo, "INGRESOS");
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia2, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Conceptos_ProdServi", ref DDLConcepto, ref ListConceptos, "INGRESOS" );
            //ListConceptos = (List<Comun>)Session["Conceptos"];
            Session["Conceptos"] = ListConceptos;

            DDLDependencia2_SelectedIndexChanged(null, null);
        }
        private string GuardarServicio()
        {
            Verificador = string.Empty;
            ListConceptos = (List<Comun>)Session["Conceptos"];
            objServicio.Dependencia = DDLDependencia.SelectedValue;
            objServicio.Clave = txtClave.Text;
            objServicio.Descripcion = txtDescripcion2.Text;
            objServicio.Total = Convert.ToDouble(txtImporte.Text);
            objServicio.Estatus = "A";
            //objServicio.Concepto = DDLConcepto.SelectedValue; //"L0609";
            objServicio.Concepto = ListConceptos[DDLConcepto.SelectedIndex].Etiqueta;

            objServicio.Grupo= DDLGrupo.SelectedValue;
            objServicio.TipoGrupo = DDLRubro.SelectedValue;
            //objServicio.Id_Concepto =Convert.ToInt32(ListConceptos[DDLConcepto.SelectedIndex].Etiqueta);
            objServicio.Id_Concepto = Convert.ToInt32(DDLConcepto.SelectedValue);

            CNBien.InsertarServicio(objServicio, ref Verificador);
            return Verificador;
           
        }

        private string ModificarServicio()
        {
            Verificador = string.Empty;
            ListConceptos = (List<Comun>)Session["Conceptos"];

            objServicio.Id_Inventario = grvServicios.SelectedRow.Cells[0].Text;
            objServicio.Dependencia = DDLDependencia2.SelectedValue;
            objServicio.Clave = txtClave.Text;
            objServicio.Descripcion = txtDescripcion2.Text;
            objServicio.Total = Convert.ToDouble(txtImporte.Text);
            objServicio.Concepto = Convert.ToString(ListConceptos[DDLConcepto.SelectedIndex].Etiqueta);  //DDLConcepto.SelectedValue;
            objServicio.Grupo = DDLGrupo.SelectedValue;
            objServicio.TipoGrupo = DDLRubro.SelectedValue;
            string pruebas = DDLConcepto.SelectedItem.Text;
            objServicio.Id_Concepto =Convert.ToInt32(DDLConcepto.SelectedValue); // Convert.ToInt32(ListConceptos[DDLConcepto.SelectedIndex].Etiqueta);
            CNBien.EditarBien(objServicio, ref Verificador);
            return Verificador;

        }

        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] { 4 };
            try
            {
                DataTable dt = new DataTable();
                grvProductos.DataSource = dt;
                grvProductos.DataSource = GetList();
                grvProductos.DataBind();
                //CNComun.HideColumns(grvProductos,Celdas);
                DropDownList DDLTipo = (DropDownList)grvProductos.HeaderRow.FindControl("ddlTipo");
                this.BindTipo(DDLTipo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridServicios()
        {
            Int32[] Celdas = new Int32[] { 10 };
            try
            {
                DataTable dt = new DataTable();
                grvServicios.DataSource = dt;
                grvServicios.DataSource = GetListServicios();
                grvServicios.DataBind();
                CNComun.HideColumns(grvServicios, Celdas);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<Bien> GetList()
        {
            try
            {
                List<Bien> List = new List<Bien>();
                CNBien.ConsultarGridCatProductosServicios(ViewState["Filter"].ToString(), ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Bien> GetListServicios()
        {
            try
            {
                List<Bien> List = new List<Bien>();
                CNBien.ConsultarGridServicios(DDLDependencia2.SelectedValue, txtBuscar.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region <Funciones>
        private void LimpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
        }
        private void BindTipo(DropDownList ddlTipo)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipo_Ventas", ref ddlTipo, "INGRESOS");
                ddlTipo.Items.Remove(ddlTipo.Items.FindByValue("ACT"));

                ddlTipo.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                ViewState["Filter"] = "0";
                Session["Conceptos"]=null;
                CargarGrid();
                CargarCombos();
                CargarGridServicios();
                TabContainer1.ActiveTabIndex = 0;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "GridProductos", "Productos();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridServicios", "Servicios();", true);

        }

        protected void bttnAgregar2_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            btnGuardar_Salir2.Text = "GUARDAR Y SALIR";
            btnGuardar2.Visible = true;
            DDLDependencia.SelectedValue = DDLDependencia2.SelectedValue;
            txtClave.Text = string.Empty;
            txtDescripcion2.Text = string.Empty;
            txtImporte.Text = string.Empty;
            multiview.ActiveViewIndex = 1;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modalProd').modal('show')", true);
            //modal.Show();
        }


        protected void bttnAgregar_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            btnGuardar_Salir2.Text = "GUARDAR Y SALIR";
            btnGuardar2.Visible = true;
            multiview.ActiveViewIndex = 0;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modalProd').modal('show')", true);
            //modal.Show();
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //modal.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modal').modal('show')", true);
            Bien objBien = new Bien();
            objBien.Tipo = DDLTipo.SelectedValue;
            objBien.Descripcion = txtDescripcion.Text.ToUpper();
            try {
                CNBien.InsertarBien(objBien, ref Verificador);
                if (Verificador == "0")
                {
                    //lblMsj.Text = "Agregado correctamente.";
                    LimpiarCampos();
                    CargarGrid();
                }
                else
                    lblMsj.Text = Verificador;
            }
            catch(Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;

            }
        }

        protected void btnCancelar_C_Click(object sender, EventArgs e)
        {
            //modal.Hide();
        }

        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBttn = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvProductos.SelectedIndex = row.RowIndex;
            Verificador = string.Empty;
            Bien objBien = new Bien();
            objBien.Id_Inventario = grvProductos.SelectedRow.Cells[1].Text;
            CNBien.EliminarBien(objBien, ref Verificador);
            if (Verificador == "0")
                CargarGrid();
            else {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void grvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvProductos.EditIndex = e.NewEditIndex;
            CargarGrid();
        }

        protected void grvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvProductos.EditIndex = -1;
            CargarGrid();
        }

        protected void btnGuardar_Salir_Click(object sender, EventArgs e)
        {
            //modal.Show();
            Bien objBien = new Bien();
            objBien.Descripcion = txtDescripcion.Text.ToUpper();
            objBien.Tipo = DDLTipo.SelectedValue;
            try
            {
                CNBien.InsertarBien(objBien, ref Verificador);
                if (Verificador == "0")
                {
                    LimpiarCampos();
                    CargarGrid();
                    //modal.Hide();
                }
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;

            }
        }

        protected void grvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            List<Bien> lstBien = new List<Bien>();
            Bien objBien = new Bien();
            GridViewRow row = grvProductos.Rows[e.RowIndex];
            objBien.Id_Inventario = grvProductos.Rows[e.RowIndex].Cells[1].Text.ToString();
            TextBox txt = (TextBox)grvProductos.Rows[e.RowIndex].Cells[2].Controls[0];
            objBien.Descripcion = txt.Text;
            CNBien.EditarProducto(objBien, ref Verificador);
            if (Verificador == "0")
            {
                grvProductos.EditIndex = -1;
                CargarGrid();
            }
            else {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void grvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProductos.PageIndex = 0;
            grvProductos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTipo = (DropDownList)sender;
            string Tipo = ddlTipo.SelectedValue;
            ViewState["Filter"] = ddlTipo.SelectedValue;
            CargarGrid();
        }

        protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(DDLTipo.SelectedValue!="ACT")

        }

        protected void DDLDependencia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLDependencia.SelectedValue = DDLDependencia2.SelectedValue;
            CargarGridServicios();
        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                Verificador = string.Empty;
                Verificador = GuardarServicio();
                if (Verificador == "0")
                {
                    txtClave.Text = string.Empty;
                    txtDescripcion2.Text = string.Empty;
                    txtImporte.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnGuardar_Salir2_Click(object sender, EventArgs e)
        {
            try
            {
                Verificador = string.Empty;
                if (SesionUsu.Editar == 0)
                    Verificador = GuardarServicio();
                else
                    Verificador = ModificarServicio();
                
                if (Verificador == "0")
                {
                    CargarGridServicios();
                    //modal.Hide();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }

            }
        
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnCancelar_C2_Click(object sender, EventArgs e)
        {
            CargarGridServicios();
            //modal.Hide();
        }

        protected void imgBttnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBttn = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvServicios.SelectedIndex = row.RowIndex;
            objBien.Id_Inventario = grvServicios.SelectedRow.Cells[0].Text;
            CNBien.EliminarServicio(objBien, ref Verificador);
            if(Verificador=="0")
                CargarGridServicios();
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }


        }

        

        protected void grvServicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvServicios.PageIndex = 0;
            grvServicios.PageIndex = e.NewPageIndex;
            CargarGridServicios();
        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgBttn = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvServicios.SelectedIndex = row.RowIndex;
            objBien.Id_Inventario = grvServicios.SelectedRow.Cells[0].Text;
            SesionUsu.Editar = 1;
            try
            {
                CNBien.ConsultarServicio(ref objBien, ref Verificador);
                if (Verificador == "0")
                {
                    DDLDependencia.SelectedValue = objBien.Dependencia;
                    DDLGrupo.SelectedValue = objBien.Grupo;
                    DDLRubro.SelectedValue = objBien.TipoGrupo;
                    txtClave.Text = objBien.Clave;
                    //DDLConcepto.SelectedIndex
                    DDLConcepto.SelectedValue =Convert.ToString(objBien.Id_Concepto); //.Concepto;
                    txtDescripcion2.Text = objBien.Descripcion;
                    txtImporte.Text = Convert.ToString(objBien.Costo);
                    btnGuardar_Salir2.Text = "MODIFICAR";
                    btnGuardar2.Visible = false;
                    //modal.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modalProd').modal('show')", true);
                    multiview.ActiveViewIndex = 1;
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridServicios();
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP058&dependencia=" + DDLDependencia2.SelectedValue + "&Observaciones=" + txtBuscar.Text.ToUpper() + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP058&dependencia=" + DDLDependencia2.SelectedValue + "&Observaciones=" + txtBuscar.Text.ToUpper() + "&enExcel=S";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void linkEliminar_Click(object sender, EventArgs e)
        {
            LinkButton imgBttn = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvProductos.SelectedIndex = row.RowIndex;
            Verificador = string.Empty;
            Bien objBien = new Bien();
            objBien.Id_Inventario = grvProductos.SelectedRow.Cells[1].Text;
            CNBien.EliminarBien(objBien, ref Verificador);
            if (Verificador == "0")
                CargarGrid();
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnEliminarConc_Click(object sender, EventArgs e)
        {
            LinkButton imgBttn = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvServicios.SelectedIndex = row.RowIndex;
            objBien.Id_Inventario = grvServicios.SelectedRow.Cells[0].Text;
            CNBien.EliminarServicio(objBien, ref Verificador);
            if (Verificador == "0")
                CargarGridServicios();
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnEditarConc_Click(object sender, EventArgs e)
        {
            LinkButton imgBttn = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)imgBttn.NamingContainer;
            grvServicios.SelectedIndex = row.RowIndex;
            objBien.Id_Inventario = grvServicios.SelectedRow.Cells[0].Text;
            SesionUsu.Editar = 1;
            try
            {
                CNBien.ConsultarServicio(ref objBien, ref Verificador);
                if (Verificador == "0")
                {
                    DDLDependencia.SelectedValue = objBien.Dependencia;
                    DDLGrupo.SelectedValue = objBien.Grupo;
                    DDLRubro.SelectedValue = objBien.TipoGrupo;
                    txtClave.Text = objBien.Clave;
                    //DDLConcepto.SelectedIndex
                    DDLConcepto.SelectedValue = Convert.ToString(objBien.Id_Concepto); //.Concepto;
                    txtDescripcion2.Text = objBien.Descripcion;
                    txtImporte.Text = Convert.ToString(objBien.Costo);
                    btnGuardar_Salir2.Text = "MODIFICAR";
                    btnGuardar2.Visible = false;
                    //modal.Show();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#modalProd').modal('show')", true);
                    multiview.ActiveViewIndex = 1;
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }
    }
}