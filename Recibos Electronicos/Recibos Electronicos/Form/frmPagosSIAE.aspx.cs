using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using System.Data;

namespace Recibos_Electronicos.Form
{
    public partial class frmPagosSIAE : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        CN_Factura CNFactura = new CN_Factura();
        CN_SIAE CNSIAE = new CN_SIAE();
        Sesion SesionUsu = new Sesion();
        Factura objFactura = new Factura();
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
                Inicializar();
            else
            {
                if ((Request.Params["__EVENTTARGET"] != null) && (Request.Params["__EVENTARGUMENT"] != null))
                {
                    if ((Request.Params["__EVENTTARGET"] == this.txtReferencia.UniqueID) /*+&& (Request.Params["__EVENTARGUMENT"] == "actualizar_label")*/)
                    {
                        this.imgBttnBuscar.Focus();
                    }
                }
            }
        }
        #region <Botones y Eventos>
        private void Cargarcombos()
        {
            try
            {
                //CNComun.LlenaCombo("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                //ddlCiclo.SelectedValue = System.DateTime.Now.ToString("yyyy");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Bancos", ref ddlBanco);

                
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void Inicializar()
        {
            try
            {
                if(SesionUsu.Usu_Central_Tipo != "SA")
                    Response.Redirect("index.aspx", false);


                //string s=SesionUsu.Usu_Central_Tipo;
                Cargarcombos();
                txtReferencia.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGrid()
        {
            Verificador = string.Empty;
            Int32[] Celdas = new Int32[] { 0, 9, 10 };
            try
            {
                DataTable dt = new DataTable();
                grvReferenciasSIAE.DataSource = dt;
                grvReferenciasSIAE.DataSource = GetList();
                grvReferenciasSIAE.DataBind();
                if (grvReferenciasSIAE.Rows.Count > 0)
                    CNComun.HideColumns(grvReferenciasSIAE, Celdas);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                objFactura.CICLO_ESCOLAR = "20"; //ddlCiclo.SelectedValue;
                objFactura.FACT_REFERENCIA = txtReferencia.Text;
                //CNSIAE.SIAEConsultaGrid(objFactura, ref List);
                CNSIAE.RefSIAEConsultaGrid(objFactura, ref List);                
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();

        }

        protected void imgStatus_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            txtFolioBanco.Text = string.Empty;
            txtFechaPago.Text = string.Empty;
            ddlBanco.SelectedIndex = 0;
            txtReferenciaOrig.Text = string.Empty;
            chkPagoAplicado.Checked = false;
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvReferenciasSIAE.SelectedIndex = row.RowIndex;
            objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
            CNSIAE.SIAEConsultaDatosPago(ref objFactura, ref Verificador);
            if (grvReferenciasSIAE.SelectedRow.Cells[11].Text == "TITULO" || grvReferenciasSIAE.SelectedRow.Cells[11].Text == "EXTRAORDINARIO")
                bttnGenerarRecibo.Visible = true;// (grvReferenciasSIAE.SelectedRow.Cells[11].Text == "TITULO") ? true : false;
            else
                bttnGenerarRecibo.Visible = false;


            if (Verificador=="0")
            {
                txtFolioBanco.Text = objFactura.FACT_FOLIOBANCARIO;
                txtFechaPago.Text = objFactura.FACT_FECHA_FACTURA;
                try
                {
                    ddlBanco.SelectedValue = objFactura.FACT_BANCO;
                }
                catch
                {
                    ddlBanco.SelectedIndex = 0;
                }

                txtReferenciaOrig.Text = objFactura.FACT_REFERENCIA;
                chkPagoAplicado.Checked = (objFactura.FACT_CONFIRMADO=="S")?true:false;
            }
            modalAlert.Show();
        }

        protected void CancelAlert_Click(object sender, EventArgs e)
        {
            modalAlert.Hide();
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                objFactura.FACT_STATUS = grvReferenciasSIAE.SelectedRow.Cells[10].Text;
                objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
                CNSIAE.ConfirmarPagoSIAE(objFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    modalAlert.Hide();
                    CargarGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                                                                                                                                          //lblMsj.Text = ex.Message;
            }

        }

        protected void btnNueva_Click1(object sender, EventArgs e)
        {

            try
            {
                objFactura.FACT_STATUS = (grvReferenciasSIAE.SelectedRow.Cells[9].Text=="I")?"Z":"I";
                objFactura.ID_FACT=grvReferenciasSIAE.SelectedRow.Cells[0].Text;
                CNSIAE.ActualizarStatusSIAE(objFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    modalAlert.Hide();
                    CargarGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                                                                                                                                          //lblMsj.Text = ex.Message;
            }

        }

        protected void grvReferenciasSIAE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvReferenciasSIAE.PageIndex = 0;
            grvReferenciasSIAE.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void bttnConfirmaPago_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                Verificador=ConfirmarPagoSIAE();
                if (Verificador == "0")
                {
                    modalAlert.Hide();
                    CargarGrid();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                                                                                                                                          //lblMsj.Text = ex.Message;
            }
        }

        protected string ConfirmarPagoSIAE()
        {
            string RefPag = string.Empty;

            objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells [0].Text;
            objFactura.FACT_FOLIOBANCARIO = txtFolioBanco.Text;
            objFactura.FACT_FECHA_FACTURA = txtFechaPago.Text;
            objFactura.FACT_BANCO = ddlBanco.SelectedValue;
            objFactura.FACT_REFERENCIA = txtReferenciaOrig.Text;
            objFactura.FACT_CONFIRMADO = (chkPagoAplicado.Checked == true) ? "S" : "N";
            RefPag= (txtReferenciaPagada.Text == string.Empty) ? txtReferenciaOrig.Text : txtReferenciaPagada.Text;   
            CNSIAE.ActualizarDatosSIAE(objFactura, RefPag, SesionUsu.Usu_Nombre, ref Verificador);
            return Verificador;
        }

    protected void bttnSalir_Click(object sender, EventArgs e)
        {
            modalAlert.Hide();
        }

        protected void bttnGenerarRecibo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            modalAlert.Show();

            chkPagoAplicado.Checked = true;
            Verificador=ConfirmarPagoSIAE();
            if (Verificador == "0")
            {

                objFactura.ID_FICHA_BANCARIA = Convert.ToInt32(grvReferenciasSIAE.SelectedRow.Cells[12].Text);
                objFactura.multipago.Order = txtFolioBanco.Text;
                try
                {
                    if (Convert.ToInt32(grvReferenciasSIAE.SelectedRow.Cells[12].Text) != 0)
                    {
                        CNFactura.Generar_Recibo_OnLine(objFactura, ref Verificador);
                        if (Verificador == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'EL RECIBO SE GENERO CORRECTAMENTE.');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                            txtReferencia.Text = Convert.ToString(grvReferenciasSIAE.SelectedRow.Cells[5].Text);
                            modalAlert.Hide();
                            CargarGrid();
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                        }
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'NO EXISTE REGISTRO EN SYSWEB');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                }
                catch (Exception ex)
                {
                    Verificador = ex.Message;
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                }
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }
        }
    }
}
