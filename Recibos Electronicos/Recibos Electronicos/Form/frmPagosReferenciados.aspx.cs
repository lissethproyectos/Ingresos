using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
using System.Data;
using System.Globalization;

namespace Recibos_Electronicos.Form
{
    public partial class frmPagosReferenciados : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        CN_Factura CNFactura = new CN_Factura();
        CN_Alumno CNAlumno = new CN_Alumno();
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
                        this.linkBttnBusca1.Focus();
                    }
                }
            }


            if (ddlOrigen.SelectedValue == "SIAE")
                ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "PagosSIAE();", true);

            else
                ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "PagosSYSWEB();", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "GridPagosSIAE", "PagosSIAE();", true);

        }
        #region <Botones y Eventos>
        private void Cargarcombos()
        {
            try
            {
                //CNComun.LlenaCombo("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                //ddlCiclo.SelectedValue = System.DateTime.Now.ToString("yyyy");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLEscuela, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Bancos", ref ddlBanco);
                //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");



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
                if (SesionUsu.Usu_Central_Tipo != "SA")
                    Response.Redirect("index.aspx", false);


                //string s=SesionUsu.Usu_Central_Tipo;
                Cargarcombos();
                ddlOrigen.SelectedValue = "SIAE";
                ddlOrigen_SelectedIndexChanged(null, null);
                ddlNivel_SelectedIndexChanged(null, null);
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
            Int32[] Celdas = new Int32[] { 13, 14, 15, 16, 17 };
            Int32[] CeldasSysWeb = new Int32[] { 0, 8, 9, 13, 14, 15, 16, 17 };
            try
            {
                DataTable dt = new DataTable();
                grvReferenciasSIAE.DataSource = dt;
                grvReferenciasSIAE.DataSource = GetList();
                grvReferenciasSIAE.DataBind();
                if (grvReferenciasSIAE.Rows.Count > 0)
                    if (ddlOrigen.SelectedValue == "SIAE")
                    {
                        CNComun.HideColumns(grvReferenciasSIAE, Celdas);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "PagosSIAE();", true);

                    }
                    else
                    {
                        CNComun.HideColumns(grvReferenciasSIAE, CeldasSysWeb);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "GridPagos", "PagosSYSWEB();", true);
                    }

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
            string Escuela;
            Verificador = string.Empty;
            try
            {
                List<Factura> List = new List<Factura>();
                objFactura.CICLO_ESCOLAR = ddlCicloEscolar.SelectedValue;
                objFactura.FACT_NIVEL = ddlNivel.SelectedValue;
                objFactura.FACT_REFERENCIA = txtReferencia.Text;
                Escuela = DDLEscuela.SelectedValue;
                //DateTime fechaIni = txtFechaIni.Text.ToString("dd/MM/yyyy");
                CNAlumno.AjustaDependencia(ref Escuela, objFactura.FACT_NIVEL, ref Verificador);
                if (Verificador == "0")
                {
                    objFactura.FACT_DEPENDENCIA = Escuela;
                    if (ddlOrigen.SelectedValue == "SIAE")
                        CNSIAE.RefSIAEConsultaGrid(objFactura, ref List);
                    else
                    {
                        //var dateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
                        //var dateIni = DateTime.ParseExact(txtFechaIni.Text, "dd/MM/yy", dateTimeFormat);

                        //var dateTimeFormat2 = CultureInfo.InvariantCulture.DateTimeFormat;
                        //var dateFin = DateTime.ParseExact(txtFechaFin.Text, "dd/MM/yyyy", dateTimeFormat);

                        CNSIAE.RefSyswebConsultaGrid(objFactura, txtFechaIni.Text, txtFechaFin.Text, ddlBusqueda.SelectedValue, ref List); ;
                    }
                }

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
            try
            {
                Verificador = ConfirmarPagoSIAE();
                if (Verificador == "0")
                {
                    CargarGrid();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }

        }

        //protected void CancelAlert_Click(object sender, EventArgs e)
        //{
        //    modalAlert.Hide();
        //}

        protected void btnNueva_Click(object sender, EventArgs e)
        {

            try
            {
                objFactura.FACT_STATUS = grvReferenciasSIAE.SelectedRow.Cells[14].Text;
                objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
                CNSIAE.ConfirmarPagoSIAE(objFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    //modalAlert.Hide();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('hide')", true);
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
                objFactura.FACT_STATUS = (grvReferenciasSIAE.SelectedRow.Cells[13].Text == "I") ? "Z" : "I";
                objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
                CNSIAE.ActualizarStatusSIAE(objFactura, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                {
                    //modalAlert.Hide();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('hide')", true);
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
                Verificador = ConfirmarPagoSIAE();
                if (Verificador == "0")
                {
                    //modalAlert.Hide();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('hide')", true);
                    CargarGrid();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                }
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

            objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
            objFactura.FACT_FOLIOBANCARIO = txtFolioBanco.Text;
            objFactura.FACT_FECHA_FACTURA = txtFechaPago.Text;
            objFactura.FACT_BANCO = ddlBanco.SelectedValue;
            objFactura.FACT_REFERENCIA = txtReferenciaOrig.Text;
            objFactura.FACT_CONFIRMADO = (chkPagoAplicado.Checked == true) ? "S" : "N";
            objFactura.CICLO_ESCOLAR = txtCiclo.Text;
            objFactura.FACT_DEPENDENCIA = txtEscuela.Text;
            objFactura.FACT_CARRERA = txtIdCarrera.Text;
            objFactura.FACT_SEMESTRE = txtSemestre.Text;
            objFactura.FACT_MATRICULA = txtMatricula.Text;
            RefPag = txtReferenciaPagada.Text.ToUpper();//(txtReferenciaPagada.Text == string.Empty) ? txtReferenciaOrig.Text : txtReferenciaPagada.Text;
            CNSIAE.ActualizarDatosSIAE(objFactura, RefPag, SesionUsu.Usu_Nombre, ref Verificador);
            return Verificador;
        }

        //protected void bttnSalir_Click(object sender, EventArgs e)
        //    {
        //        modalAlert.Hide();
        //    }

        protected void CancelAlert_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('hide')", true);
        }

        protected void bttnGenerarRecibo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('show')", true);

            chkPagoAplicado.Checked = true;



            objFactura.ID_FICHA_BANCARIA = Convert.ToInt32(grvReferenciasSIAE.SelectedRow.Cells[15].Text);
            objFactura.multipago.Order = txtFolioBanco.Text;
            objFactura.FACT_BANCO = ddlBanco.SelectedValue;
            try
            {
                if (Convert.ToInt32(grvReferenciasSIAE.SelectedRow.Cells[15].Text) != 0 && Convert.ToString(grvReferenciasSIAE.SelectedRow.Cells[16].Text) == "SYSWEB")
                    CNFactura.Generar_Recibo_OnLine(objFactura, ref Verificador);
                else
                {
                    if (Verificador == "0")
                        CNFactura.Generar_Recibo_OnLine_SIAE(objFactura, ref Verificador);
                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                    }

                }

                if (Verificador == "0")
                {
                    txtReferencia.Text = Convert.ToString(grvReferenciasSIAE.SelectedRow.Cells[5].Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPagos", "$('#modalPagos').modal('hide')", true);
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'EL RECIBO SE GENERO CORRECTAMENTE.');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";

                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }

        }

        protected void ddlCicloEscolar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrigen.SelectedValue == "SIAE")
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCicloEscolar, "p_nivel", "p_tipo", ddlNivel.SelectedValue, "TODOS", "INGRESOS");
        }

        protected void linkBttnGenRecibo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvReferenciasSIAE.SelectedIndex = row.RowIndex;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grvReferenciasSIAE.SelectedRow.Cells[17].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Verificador = string.Empty;
                txtFolioBanco.Text = string.Empty;
                txtFechaPago.Text = string.Empty;
                ddlBanco.SelectedIndex = 0;
                txtReferenciaOrig.Text = string.Empty;
                chkPagoAplicado.Checked = false;
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvReferenciasSIAE.SelectedIndex = row.RowIndex;
                objFactura.ID_FACT = grvReferenciasSIAE.SelectedRow.Cells[0].Text;
                if (ddlOrigen.SelectedValue == "SIAE")
                {
                    pnlDatosGral.Visible = true;
                    lblReferenciaPagada.Visible = true;
                    txtReferenciaPagada.Visible = true;
                    //bttnConfirmaPago.Visible = true;
                    lblPagoAplicado.Visible = true;
                    chkPagoAplicado.Visible = true;
                    txtEvento.Visible = false;
                    bttnGenerarRecibo.Text = "GENERAR RECIBO";
                    CNSIAE.SIAEConsultaDatosPago(ref objFactura, ref Verificador);
                }
                else
                {
                    txtReferenciaOrig.Text = grvReferenciasSIAE.SelectedRow.Cells[5].Text;
                    lblReferenciaPagada.Visible = false;
                    txtReferenciaPagada.Visible = false;
                    txtEvento.Visible = true;
                    //pnlDatosGral.Visible = false;
                    //bttnConfirmaPago.Visible = false;
                    bttnGenerarRecibo.Text = "GENERAR RECIBO";
                    lblPagoAplicado.Visible = false;
                    chkPagoAplicado.Visible = false;

                    CNSIAE.SysWebConsultaDatosPago(ref objFactura, ref Verificador);



                }


                if (Verificador == "0")
                {
                    txtFolioBanco.Text = objFactura.FACT_FOLIOBANCARIO;
                    txtFechaPago.Text = objFactura.FACT_FECHA_FACTURA;
                    txtCiclo.Text = objFactura.CICLO_ESCOLAR;
                    txtEscuela.Text = objFactura.FACT_DEPENDENCIA;
                    txtIdCarrera.Text = objFactura.FACT_CARRERA;
                    txtSemestre.Text = objFactura.FACT_SEMESTRE;
                    txtMatricula.Text = objFactura.FACT_MATRICULA;
                    txtEvento.Text = objFactura.FACT_EVENTO;
                    txtNombre.Text = objFactura.FACT_NOMBRE;
                    try
                    {
                        ddlBanco.SelectedValue = objFactura.FACT_BANCO;
                    }
                    catch
                    {
                        ddlBanco.SelectedIndex = 0;
                    }

                    txtReferenciaOrig.Text = objFactura.FACT_REFERENCIA;
                    chkPagoAplicado.Checked = (objFactura.FACT_CONFIRMADO == "S") ? true : false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('show')", true);
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
            }

        }

        protected void ddlOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            string FechaIni = hoy.ToString("dd/MM/yyyy");
            string FechaFin = hoy.ToString("dd/MM/yyyy");
            grvReferenciasSIAE.DataSource = null;
            grvReferenciasSIAE.DataBind();
            if (ddlOrigen.SelectedValue == "SYSWEB")
            {
                divCiclo.Visible = false;
                divBusqueda.Visible = true;
                txtFechaIni.Text = FechaIni;
                txtFechaFin.Text = FechaFin;
                ddlBusqueda_SelectedIndexChanged(null, null);
            }
            else
            {
                divFechas.Visible = false;
                divCiclo.Visible = true;
                divBusqueda.Visible = false;
                rowBuscaRef.Visible = true;
            }
        }

        protected void linkBttnBusca2_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('show')", true);
            }
        }

        protected void linkBttnBusca1_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupError", "$('#modalPagos').modal('show')", true);
            }
        }

        protected void ddlBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBusqueda.SelectedValue == "2")
            {

                divFechas.Visible = false;
                rowBuscaRef.Visible = true;
            }
            else
            {
                divFechas.Visible = true;
                rowBuscaRef.Visible = false;
            }
        }

        protected void linkBttnReferencia_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvReferenciasSIAE.SelectedIndex = row.RowIndex;
            if (ddlOrigen.SelectedValue == "SIAE")
                ruta = "https://sysweb.unach.mx/fichaReferenciada/Reportes/VisualizadorCrystal.aspx?cverep=REP_SIAE&idFicha=" + grvReferenciasSIAE.SelectedRow.Cells[15].Text;
            else
                ruta = "https://sysweb.unach.mx/FichaReferenciada/Reportes/VisualizadorCrystal.aspx?cverep=REP_FICHA_REF&idFact=" + grvReferenciasSIAE.SelectedRow.Cells[15].Text + "&Referencia=" + grvReferenciasSIAE.SelectedRow.Cells[5].Text;

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
    }
}
