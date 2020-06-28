using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace Recibos_Electronicos.Form
{
    public partial class FrmRecibos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        Int32[] Celdas = { 3 };
        double SubTotal = 0;
        private string[] UsuariosSuper = { "VICENTE", "OSMANDI", "LISSETH", "GEORGINA", "BEATRIZ" };


        CN_Comun CNComun = new CN_Comun();
        private static List<Comun> ListConceptos = new List<Comun>();
        Sesion SesionUsu = new Sesion();        
        Factura ObjFactura = new Factura();
        Alumno ObjAlumno = new Alumno();
        DetFactura ObjDetFactura = new DetFactura();        
        CN_Factura CNFacturas = new CN_Factura();
        CN_DetFactura CNDetFacturas = new CN_DetFactura();
        CN_Alumno CNAlumno = new CN_Alumno();
        List<DetFactura> ListDetConcepto = new List<DetFactura>();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            
            if (!IsPostBack)            
                Inicializar();
            //else
            //{
            //    this.txtFolioBuscar.Attributes.Add("onkeypress", "button_click(this,'" + this.imgbtnBuscar.ClientID + "')");
            //}         
            else
            {
                if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
                {
                    string s = Request.Params["__EVENTTARGET"];
                    if ((Request.Params["__EVENTTARGET"] == this.txtFolioBuscar.UniqueID) /*+&& (Request.Params["__EVENTARGUMENT"] == "actualizar_label")*/)
                    {
                        this.imgbtnBuscar.Focus();
                    }
                }
            }
        }
        #region <Botones y Eventos>
        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (SesionUsu.Editar == 1)
            {
                modal.Show();
            }
            ddlConcepto.Items.Clear();
            CNComun.LlenaComboG("pkg_pagos.Obt_Combo_Conceptos_SE", ref ddlConcepto, "p_nivel", ddlNivel.SelectedValue, ref ListConceptos, "INGRESOS");
            ddlConcepto.SelectedIndex = 0;
            ddlConcepto_SelectedIndexChanged(null, null);
        }
        protected void grvFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {            
            CargarGrid();

        }
        protected void imgBttnAgregarConcepto0_Click(object sender, ImageClickEventArgs e)
        {
            modal.Show();
        }
        protected void ddlConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == 1)
            {
                modal.Show();
            }

            if (ddlConcepto.Items.Count > 1)
            {
                txtValor_unitario.Text = ListConceptos[ddlConcepto.SelectedIndex].EtiquetaTres;
            }
        }
        protected void btnGuardar_Concep_Click(object sender, EventArgs e)
        {
            //ModalPopupExtender1.Show();
            GuardarDatos_FacturaDet();            
            LimpiarCampos();
            modal.Hide();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos_Factura();
        }
        protected void grvFacturas_Detalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int fila = e.RowIndex;
            //BorrarDatos_FacturaDet(fila);
            try
            {
                int fila = e.RowIndex;
                //int pagina = grvFacturas_Detalle.PageSize * grvFacturas_Detalle.PageIndex;
                //fila = pagina + fila;
                List<DetFactura> ListDetConcepto = new List<DetFactura>();
                ListDetConcepto = (List<DetFactura>)Session["ConceptosRecibo"];
                ListDetConcepto.RemoveAt(fila);
                Session["ConceptosRecibo"] = ListDetConcepto;
                CargarGrid_FacturaDetalle(ListDetConcepto);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }
        #endregion

        #region <Funciones y Sub>
        private void Inicializar()
        {            
            CargarCombos();
            var Usu = SesionUsu.Usu_Nombre;
            var usuAdmin = Array.FindAll(UsuariosSuper, s => s.Equals(Usu));
            if (usuAdmin.Length > 0)
            {
                txtFecha_Cfd1.Enabled = true;
                txtFecha_Dispersion.Enabled = true;
                imgCalendarioCfd1.Enabled = true;
                imgCalendarioDisp.Enabled = true;
            }
            else
            {
                txtFecha_Cfd1.Enabled = false;
                txtFecha_Dispersion.Enabled = false;
                imgCalendarioCfd1.Enabled = false;
                imgCalendarioDisp.Enabled = false;
            }
            //MultiView1.ActiveViewIndex = 0;
            txtFolioBuscar.Focus();
        }
        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                ObjFactura.FACT_FOLIO = txtFolioBuscar.Text.ToUpper();
                CNFacturas.FacturaConsultarCancelados(ref ObjFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<DetFactura> GetList_FacturaDetalle(ref DetFactura ObjDetFactura, ref List<DetFactura> List)
        {
            try
            {
                //List<DetFactura> List = new List<DetFactura>();
                CNFacturas.FacturaDetalleConsultaGrid(ref ObjDetFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] { 0, 10 };
            Int32[] CeldasAdmin = new Int32[] { 0 };

            try
            {
                DataTable dt = new DataTable();
                grvFacturas.DataSource = dt;
                grvFacturas.DataSource = GetList();
                grvFacturas.DataBind();                
                if (grvFacturas.Rows.Count > 0 && (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "N"))
                    CNComun.HideColumns(grvFacturas, Celdas);
                else
                    CNComun.HideColumns(grvFacturas, CeldasAdmin);
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }

        }
        private void CargarGrid_FacturaDetalle(List<DetFactura> ListDetConcepto)
        {
            try
            {
                DataTable dt = new DataTable();
                if (ListDetConcepto.Count > 0)
                {
                    Session["ConceptosRecibo"] = ListDetConcepto;
                    grvFacturas_Detalle.DataSource = dt;
                    grvFacturas_Detalle.DataSource = ListDetConcepto;
                    grvFacturas_Detalle.DataBind();
                    if (grvFacturas_Detalle.Rows.Count > 0)
                        HideColumns(grvFacturas_Detalle);
                }
                else
                {
                    grvFacturas_Detalle.DataSource = dt;
                    grvFacturas_Detalle.DataSource = null;
                    grvFacturas_Detalle.DataBind();
                }

            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }

        }




        private void CargarCombos()
        {
            try
            {                
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                //txtValor_unitario.Text = ListConceptos[ddlConcepto.SelectedIndex].EtiquetaDos;
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void HideColumns(GridView grdView)
        {
            SubTotal = 0;
            grdView.HeaderRow.Cells[0].Visible = false;
            //grdView.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow row in grdView.Rows)
            {
                row.Cells[0].Visible = false;
                if (grdView.ID == "grvFacturas_Detalle")
                {
                    SubTotal = Convert.ToDouble(row.Cells[5].Text) + SubTotal;
                }
                //row.Cells[1].Visible = false;
            }
            //txtTotal.Text =(grdView.ID == "grvFacturas_Detalle")? Convert.ToString(Total):"0";
            txtSubtotal.Text = (grdView.ID == "grvFacturas_Detalle") ? Convert.ToString(SubTotal) : "0";
            txtTotal.Text =(grdView.ID == "grvFacturas_Detalle") ? Convert.ToString(SubTotal + Convert.ToDouble(txtImpuesto_Tasa.Text)):"0";


        }

        private void GuardarDatos_FacturaDet()
        {
            //string cantidad = ddlConcepto.SelectedValue;
            lblMsjConc.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                ObjDetFactura.ID_FACT = grvFacturas.Rows[grvFacturas.SelectedIndex].Cells[0].Text;
                ObjDetFactura.ClaveConcepto = ListConceptos[ddlConcepto.SelectedIndex].EtiquetaCuatro;
                ObjDetFactura.DescConcepto = ddlConcepto.SelectedItem.Text;
                ObjDetFactura.Cantidad = Convert.ToInt32(txtCantidad.Text);
                ObjDetFactura.ValorUnitario = txtValor_unitario.Text;
                ObjDetFactura.Importe = Convert.ToString(Convert.ToDouble(txtValor_unitario.Text) * Convert.ToInt32(txtCantidad.Text));

                if (Session["ConceptosRecibo"] == null)
                {
                    ListDetConcepto = new List<DetFactura>();
                    ListDetConcepto.Add(ObjDetFactura);
                }
                else
                {
                    ListDetConcepto = (List<DetFactura>)Session["ConceptosRecibo"];
                    ListDetConcepto.Add(ObjDetFactura);
                }

                Session["ConceptosRecibo"] = ListDetConcepto;
                CargarGrid_FacturaDetalle(ListDetConcepto);

            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }


        }
        //private void GuardarDatos_FacturaDet()
        //{
        //    lblMsjConc.Text = string.Empty;
        //    ObjDetFactura.ID_FACT = grvFacturas.Rows[grvFacturas.SelectedIndex].Cells[0].Text;
        //    ObjDetFactura.ClaveConcepto = ListConceptos[ddlConcepto.SelectedIndex].EtiquetaCuatro;
        //    ObjDetFactura.DescConcepto = ddlConcepto.SelectedItem.Text;
        //    ObjDetFactura.Cantidad =Convert.ToInt32(txtCantidad.Text);
        //    ObjDetFactura.ValorUnitario = txtValor_unitario.Text;
        //    ObjDetFactura.Importe = txtValor_unitario.Text;
        //    try
        //    {

        //        Verificador = string.Empty;
        //        CNDetFacturas.DetFacturaInsertar(ref ObjDetFactura, ref Verificador);
        //        if (Verificador == "0")
        //        {
        //            CargarGrid_FacturaDetalle(ref ObjDetFactura);                    
        //        }

        //        else
        //        {
        //            lblMsjConc.Text = "Error(" + Verificador + ")";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsjConc.Text = ex.Message;
        //    }


        //}
        private void GuardarDatos_Factura()
        {
            ObjFactura.ID_FACT = grvFacturas.SelectedRow.Cells[0].Text; //grvFacturas.Rows[grvFacturas.SelectedIndex].Cells[0].Text;
            ObjFactura.FACT_NOMBRE = txtReceptor_Nombre.Text;
            ObjFactura.FACT_RECEPTOR_RFC = txtReceptor_Rfc.Text;
            ObjFactura.FACT_RECEPTOR_DOMICILIO=txtReceptor_Domicilio.Text;
            ObjFactura.FACT_RECEPTOR_COLONIA=txtReceptor_Colonia.Text;
            ObjFactura.FACT_RECEPTOR_LUGAR=txtReceptor_Pais.Text;
            ObjFactura.FACT_MATRICULA=txtMatricula.Text;
            ObjFactura.FACT_CARRERA=txtCarrera.Text;
            ObjFactura.FACT_DEPENDENCIA=txtDesc_Dependencia.Text;
            ObjFactura.FACT_EXPEDIDO_DOMICILIO=txtExpedido_Domicilio.Text;
            ObjFactura.FACT_EXPEDIDO_COLONIA=txtExpedido_Colonia.Text;
            ObjFactura.FACT_EXPEDIDO_PAIS = txtExpedido_Pais.Text;
            ObjFactura.FACT_OBSERVACIONES=txtNotas.Text;
            ObjFactura.FACT_SUBTOTAL =txtSubtotal.Text;
            ObjFactura.FACT_IMPUESTO_TASA = txtImpuesto_Tasa.Text;
            ObjFactura.FACT_TOTAL = txtTotal.Text;
            ObjFactura.FACT_STATUS = rdoListStatus.SelectedValue;
            ObjFactura.FACT_STATUS_NOTAS = txtStatus_Notas.Text;
            ObjFactura.FACT_FECHA_CFD = txtFecha_Cfd1.Text;
            ObjFactura.FACT_FECHA_DISPERSION = txtFecha_Dispersion.Text;
            //ObjFactura.FACT_FECHA_CFD

            try
            {
                Verificador = string.Empty;
                CNFacturas.FacturaEditarDatos(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    ListDetConcepto = (List<DetFactura>)Session["ConceptosRecibo"];
                    CNDetFacturas.DetFacturaEliminar(Convert.ToInt32(grvFacturas.SelectedRow.Cells[0].Text), ref Verificador);
                    if (Verificador == "0")
                    {
                        Verificador = string.Empty;
                        CNDetFacturas.DetFacturaAgregar(Convert.ToInt32(grvFacturas.SelectedRow.Cells[0].Text), ListDetConcepto, ref Verificador);
                        if (Verificador == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos se guardaron correctamente.');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                            pnlModificacion_Recibo.Visible = false;
                            pnlRecibos.Visible = true;
                            pnlBuscar.Visible = true;
                            SesionUsu.Editar = 0;
                            CargarGrid();
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                        }
                    }

                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;

                    }
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;

                }
            }
            catch (Exception ex)
            {
                string Msj=ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }


        }
        //private void BorrarDatos_FacturaDet(int fila)
        //{
        //    ObjDetFactura.IdDetFact = Convert.ToInt32(grvFacturas_Detalle.Rows[fila].Cells[0].Text);
        //    ObjDetFactura.ID_FACT = grvFacturas.Rows[grvFacturas.SelectedIndex].Cells[0].Text;
        //    try
        //    {
        //        Verificador = string.Empty;
        //        CNDetFacturas.DetFacturaBorrar(ref ObjDetFactura, ref Verificador);
        //        if (Verificador == "0")
        //        {                    
        //            CargarGrid_FacturaDetalle(ref ObjDetFactura);                    
        //        }

        //        else
        //        {
        //            CNComun.VerificaTextoMensajeError(ref Verificador);
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string Msj = ex.Message;
        //        CNComun.VerificaTextoMensajeError(ref Msj);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
        //    }

        //}
        private void LimpiarCampos()
        {
            lblMsjConc.Text = string.Empty;
            ddlNivel.SelectedIndex = 0;
            ddlNivel_SelectedIndexChanged(null, null);
            txtValor_unitario.Text = "";
            txtCantidad.Text = "";
        }
        #endregion

        protected void btnCancelar_Concp_Click(object sender, EventArgs e)
        {            
            LimpiarCampos();
            modal.Hide();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlModificacion_Recibo.Visible = false;
            pnlRecibos.Visible = true;
            pnlBuscar.Visible = true;
            SesionUsu.Editar = 0;
        }
        protected void grvFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFacturas.PageIndex = 0;
            grvFacturas.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int v = e.NewSelectedIndex;
            Verificador = string.Empty;
            pnlMsjReg.Visible = false;
            lblMsj2.Text = string.Empty;
            imgBttnAgregarConcepto0.Enabled = true;
            grvFacturas_Detalle.Enabled = true;
            ObjFactura.ID_FACT = grvFacturas.SelectedRow.Cells[0].Text; //grvFacturas.Rows[v].Cells[0].Text;
            ObjDetFactura.ID_FACT = grvFacturas.SelectedRow.Cells[0].Text; //grvFacturas.Rows[v].Cells[0].Text;
            Session["ConceptosRecibo"] = null;
            CNFacturas.FacturaConsultaDatos(ref ObjFactura, ref Verificador);
            if (Verificador == "0")
            {
                pnlBuscar.Visible = false;
                pnlRecibos.Visible = false;
                pnlModificacion_Recibo.Visible = true;
                txtFolio.Text = ObjFactura.FACT_FOLIO;
                txtFecha_Cfd1.Text = ObjFactura.FACT_FECHA_CFD;
                txtNo_Certificado.Text = ObjFactura.FACT_NO_CERTIFICADO;
                txtAnio_Aprobacion.Text = ObjFactura.FACT_ANIO_APROBACION;
                txtReceptor_Nombre.Text = ObjFactura.FACT_NOMBRE;
                txtReceptor_Rfc.Text = ObjFactura.FACT_RECEPTOR_RFC;
                txtReceptor_Domicilio.Text = ObjFactura.FACT_RECEPTOR_DOMICILIO;
                txtReceptor_Colonia.Text = ObjFactura.FACT_RECEPTOR_COLONIA;
                txtReceptor_Pais.Text = ObjFactura.FACT_RECEPTOR_LUGAR;
                txtMatricula.Text = ObjFactura.FACT_MATRICULA;
                txtCarrera.Text = ObjFactura.FACT_CARRERA;
                txtDesc_Dependencia.Text = ObjFactura.FACT_DEPENDENCIA;
                txtExpedido_Domicilio.Text = ObjFactura.FACT_EXPEDIDO_DOMICILIO;
                txtExpedido_Colonia.Text = ObjFactura.FACT_EXPEDIDO_COLONIA;
                txtExpedido_Pais.Text = ObjFactura.FACT_EXPEDIDO_PAIS;
                txtFecha_Cfd2.Text = ObjFactura.FACT_FECHA_CFD;
                txtFecha_Dispersion.Text = ObjFactura.FACT_FECHA_DISPERSION;
                txtNotas.Text = ObjFactura.FACT_OBSERVACIONES;
                txtCertificado.Text = ObjFactura.FACT_CERTIFICADO;
                txtSello_Digital.Text = ObjFactura.FACT_SELLO_DIGITAL;
                lblTotal_Letras.Text = ObjFactura.FACT_TOTAL_LETRAS;
                txtImpuesto_Tasa.Text = ObjFactura.FACT_IMPUESTO_TASA;
                txtSubtotal.Text = string.Empty;
                txtTotal.Text = string.Empty;
                rdoListStatus.SelectedValue = ObjFactura.FACT_STATUS;
                txtStatus_Notas.Text = ObjFactura.FACT_STATUS_NOTAS;
                txtFecha_Dispersion.Text = ObjFactura.FACT_FECHA_DISPERSION;



                if (ObjFactura.FACT_MODIFICABLE == "N")
                {
                    pnlMsjReg.Visible = true;
                    lblMsj2.Text = "Estos recibos ya están contabilizados, no se pueden modificar conceptos.";
                    imgBttnAgregarConcepto0.Enabled = false;
                    grvFacturas_Detalle.Enabled = false;
                }

                Session["ConceptosRecibo"] = null;
                List<DetFactura> ListDetConcepto = new List<DetFactura>();
                GetList_FacturaDetalle(ref ObjDetFactura, ref ListDetConcepto);
                CargarGrid_FacturaDetalle(ListDetConcepto);
                SesionUsu.Editar = 1;
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void linkBttnVer_Click(object sender, EventArgs e)
        {
            SesionUsu.Id_Comprobante = Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
            //pnlContenor.Visible = false;
            //btnRegresar.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteRecibo(" + SesionUsu.Id_Comprobante + ");", true);            
        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                grvFacturas.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grvFacturas.SelectedRow.Cells[2].Text;
                PnlCorreo.Recibo = grvFacturas.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void imgBttnRecibo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvFacturas.SelectedIndex = row.RowIndex;            
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteRecibo(" + grvFacturas.SelectedRow.Cells[0].Text + ");", true);

        }

        protected void rdoListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoListStatus.SelectedValue == "C")
                lblStatus_Notas.Text = "Motivo de la Cancelación:";
            else if (rdoListStatus.SelectedValue == "R")
                lblStatus_Notas.Text = "Observaciones del Reembolso:";
            else
                lblStatus_Notas.Text = "Notas:";

        }

        protected void btnGuardar_Concep_Continuar_Click(object sender, EventArgs e)
        {
            modal.Show();
            GuardarDatos_FacturaDet();
            txtValor_unitario.Text =string.Empty;
            txtCantidad.Text = string.Empty;
            modal.Show();
            //LimpiarCampos();
        }

        protected void imgBttnHistorico_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvFacturas.SelectedIndex = row.RowIndex;

            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP050&idFact=" + grvFacturas.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }






        //protected void linkBttnEnviarCorreo_Click(object sender, EventArgs e)
        //{
        //    LinkButton cbi = (LinkButton)(sender);
        //    GridViewRow row = (GridViewRow)cbi.NamingContainer;
        //    lblMsj.Text = string.Empty;
        //    try
        //    {
        //        grvFacturas.SelectedIndex = row.RowIndex;
        //        PnlCorreo.Matricula = grvFacturas.SelectedRow.Cells[2].Text;
        //        PnlCorreo.Recibo = grvFacturas.SelectedRow.Cells[0].Text;
        //        PnlCorreo.Muestra();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsj.Text = ex.Message;
        //    }
        //}






    }
}