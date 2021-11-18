using System;
using System.Data;
using System.Linq;
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

using CapaNegocio;
using CapaEntidad;
using Facturapi;

namespace Recibos_Electronicos.Form
{
    public partial class FrmFacturas3 : System.Web.UI.Page
    {
        #region <Variables>

        String Verificador = string.Empty;
        String Verificador2 = string.Empty;
        public String fullPath;
        public String fullPath_Xml;
        public String fullPathFactura;
        public Boolean strFactura;
        public Boolean strFactura_Xml;
        Int32[] Celdas = { 0, 11, 13, 14, 15, 16 };

        public Boolean BandFact = false;
        Sesion SesionUsu = new Sesion();
        CajaFactura ObjCjaFactura = new CajaFactura();
        Factura ObjFactura = new Factura();
        Facturacion ObjFacturacion = new Facturacion();
        CN_Factura CNFactura = new CN_Factura();
        CN_Facturacion CNFacturacion = new CN_Facturacion();
        CN_DetFacturaEfectivo CNDetFacturaEfec = new CN_DetFacturaEfectivo();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        List<CajaFactura> ListArch = new List<CajaFactura>();
        CN_Comun CNComun = new CN_Comun();
        List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
        ConceptoPago ObjConcepto = new ConceptoPago();
        Usuario Usur = new Usuario();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        DetConcepto ObjConceptoDet = new DetConcepto();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();
            //else
            //    Status();



            ScriptManager.RegisterStartupScript(this, GetType(), "Grid", "Referencias();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridEfect", "ReferenciasEfect();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridConc", "ConceptosDisponibles();", true);


        }

        #region <Botones y Eventos>

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }
        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            bttnVerRecibo.Visible = false;
            ObjCjaFactura.ItsOk = false;
            txtFecha_Fact_Cja.Text = string.Empty;
            txtFolio_Fact_Cja.Text = string.Empty;
            chkConfirmaSolicitud.Checked = false;
            //ddlDependencia.Enabled = false;
            LimipiarCampos();
            rowSolicitarFactura.Visible = false;
            tabFacturas.Tabs[1].Visible = false;

            Status();
            pnl1.Enabled = true;
            rowPnl1.Visible = false;
            try
            {

                ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);
                bttnVerRecibo.Visible = true;

                if (Verificador == "0")
                {
                    ddlDependencia2.Enabled = false;
                    ddlDependencia2.SelectedValue = ObjFactura.FACT_DEPENDENCIA;
                    rdoBttnReceptorTipoPersona.SelectedValue = ObjFactura.FACT_RECEPTOR_TIPO_PERS;
                    txtReceptor_Nombre.Text = ObjFactura.FACT_NOMBRE;
                    txtReceptor_Rfc.Text = ObjFactura.FACT_RECEPTOR_RFC;
                    txtReceptor_Domicilio.Text = ObjFactura.FACT_RECEPTOR_DOMICILIO;
                    txtReceptor_Colonia.Text = ObjFactura.FACT_RECEPTOR_COLONIA;
                    txtReceptor_CP.Text = ObjFactura.FACT_RECEPTOR_CP;
                    txtReceptor_NumExt.Text = ObjFactura.NUMERO_EXTERIOR;
                    txtReceptor_NumInt.Text = ObjFactura.NUMERO_INTERIOR;
                    try
                    {
                        ddlReceptor_Estado.SelectedValue = ObjFactura.FACT_RECEPTOR_ESTADO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_Estado.SelectedValue = "8";
                        ObjFactura.FACT_RECEPTOR_MUNICIPIO = "213";
                    }
                    ddlEstado_Fiscal_SelectedIndexChanged(null, null);

                    try
                    {
                        ddlReceptor_Municipio.SelectedValue = ObjFactura.FACT_RECEPTOR_MUNICIPIO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_Municipio.SelectedIndex = 0;
                    }

                    try
                    {
                        ddlReceptor_MetodoPago.SelectedValue = ObjFactura.FACT_RECEPTOR_METODO_PAGO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_MetodoPago.SelectedIndex = 0;
                    }

                    ddlForma_Pago.SelectedValue = ObjFactura.FACT_RECEPTOR_FORMA_PAGO;
                    txtReceptor_Telefono.Text = ObjFactura.FACT_RECEPTOR_TELEFONO;
                    txtReceptor_Correo.Text = ObjFactura.FACT_RECEPTOR_CORREO;
                    ddlCFDI.SelectedValue = ObjFactura.CFDI;
                    txtDescConcepto.Text = ObjFactura.FACT_OBSERVACIONES;
                    btnGuardarEditar.ValidationGroup = "DatosFiscales";

                    if (grdDatosFactura.SelectedRow.Cells[19].Text == "R")
                    {
                        chkConfirmaSolicitud.Visible = true;
                        chkRechazado.Checked = true;
                        rowObservaciones.Visible = true;
                        txtObservaciones.Text = ObjFactura.FACT_RECEPTOR_STATUS_NOTAS;
                        txtObservaciones.Enabled = false;
                    }
                    else if (grdDatosFactura.SelectedRow.Cells[19].Text == "S" && ddlStatus.SelectedValue=="S")
                    {
                        btnGuardarEditar.ValidationGroup = "DatosFiscalesCaja"; // string.Empty;
                        chkRechazado.Visible = true;
                        txtObservaciones.Enabled = true;
                    }
                    else if (grdDatosFactura.SelectedRow.Cells[19].Text == "S" && ddlStatus.SelectedValue == "C")
                    {
                        rowSolicitarFactura.Visible = true;
                        chkSolicitar.Checked = true;
                    }
                    else if (grdDatosFactura.SelectedRow.Cells[19].Text == "F" && ddlStatus.SelectedValue=="C")
                    {
                        pnl1.Enabled = false;
                        rowPnl1.Visible = true;
                    }
                    else
                    {
                        rowSolicitarFactura.Visible = (ddlStatus.SelectedValue == "C") ? true : false;
                        
                    }

                    lblConceptosFac.Text = ObjFactura.FACT_CONCEPTOS;
                    lblImporte.Text = ObjFactura.FACT_IMPORTE;

                    tabFacturas.Tabs[1].Visible = false;
                    SesionUsu.Editar = 1;



                    ObjCjaFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(grdDatosFactura.SelectedRow.Cells[1].Text);
                    List<CajaFactura> ListArch = new List<CajaFactura>();
                    CNCjaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Convert.ToString(grdDatosFactura.SelectedRow.Cells[22].Text), ref ListArch);
                    DataTable dt = new DataTable();
                    grdArchivos.DataSource = dt;
                    grdArchivos.DataSource = ListArch;
                    grdArchivos.DataBind();
                    Session["Archivos"] = ListArch;
                    mltViewFacturas.ActiveViewIndex = 2;
                    //tabFacturas.Tabs[1].Visible = false;
                }

                else
                {
                    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error en la recuperación de los datos.')", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;

            }
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 0;
            //pnlContenedor.Visible = true;
            //pnlEditar.Visible = false;
        }

        protected void btnAgregaFactura_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileFactura.HasFile)
                {
                    int fileSize = fileFactura.PostedFile.ContentLength;
                    //fullPath = Path.Combine(Server.MapPath("../Facturas/PDF/"), fileFactura.FileName);
                    //fileFactura.SaveAs(fullPath);
                    fullPathFactura = Path.Combine(Server.MapPath("../ArchivosFacturasTemp/"), fileFactura.FileName);
                    fileFactura.SaveAs(fullPathFactura);
                    ObjCjaFactura.Fecha_Fact_Cja = txtFecha_Fact_Cja.Text;
                    ObjCjaFactura.Folio_Fact_Cja = txtFolio_Fact_Cja.Text;
                    ObjCjaFactura.NombreArchivo = fileFactura.FileName;
                    ObjCjaFactura.Ruta = "../ArchivosFacturasTemp/" + fileFactura.FileName; //fullPath;
                    ObjCjaFactura.ExtensionArchivo = Path.GetExtension(fileFactura.FileName);
                    if (Session["Archivos"] == null)
                    {
                        ListArch = new List<CajaFactura>();
                        ListArch.Add(ObjCjaFactura);
                    }
                    else
                    {
                        ListArch = (List<CajaFactura>)Session["Archivos"];
                        ListArch.Add(ObjCjaFactura);
                    }

                    if (ListArch.Count >= 1)
                    {
                        txtFecha_Fact_Cja.Enabled = false;
                        txtFolio_Fact_Cja.Enabled = false;
                    }

                    Session["Archivos"] = ListArch;
                    grdArchivos.DataSource = ListArch;
                    grdArchivos.DataBind();
                    //txtFecha_Fact_Cja.Text = string.Empty;
                    //txtFolio_Fact_Cja.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);

            }


        }
        protected void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            mltViewFacturas.ActiveViewIndex = 0;
        }
        protected void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (ddlTipo.SelectedValue == "R")
                        Guardar();
                    else
                        GuardarEfect();

                    linkBttnBuscar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        #endregion

        #region <Funciones>
        //protected void Guardar()
        //{
        //    bool ExisteConcepto800 = VerificaConceptos();
        //    if (ExisteConcepto800 == false || chkRechazado.Checked == true)
        //    {
        //        ObjFactura.FACT_TIPO = ddlTipo.SelectedValue;
        //        ObjFactura.FACT_DEPENDENCIA = ddlDependencia2.SelectedValue;
        //        ObjFactura.FACT_RECEPTOR_RFC = txtReceptor_Rfc.Text;
        //        ObjFactura.FACT_RECEPTOR_TIPO_PERS = rdoBttnReceptorTipoPersona.SelectedValue;
        //        ObjFactura.FACT_NOMBRE = txtReceptor_Nombre.Text;
        //        ObjFactura.FACT_RECEPTOR_DOMICILIO = txtReceptor_Domicilio.Text;
        //        ObjFactura.FACT_RECEPTOR_COLONIA = txtReceptor_Colonia.Text;                
        //        ObjFactura.FACT_RECEPTOR_ESTADO = ddlReceptor_Estado.SelectedValue;
        //        ObjFactura.FACT_RECEPTOR_MUNICIPIO = ddlReceptor_Municipio.SelectedValue;
        //        ObjFactura.FACT_RECEPTOR_CP = txtReceptor_CP.Text;
        //        ObjFactura.FACT_RECEPTOR_METODO_PAGO = ddlReceptor_MetodoPago.SelectedValue;
        //        ObjFactura.FACT_RECEPTOR_FORMA_PAGO = ddlForma_Pago.SelectedValue;
        //        ObjFactura.CFDI = ddlCFDI.SelectedValue;
        //        ObjFactura.FACT_RECEPTOR_TELEFONO = txtReceptor_Telefono.Text;
        //        ObjFactura.FACT_RECEPTOR_CORREO = txtReceptor_Correo.Text;                
        //        ObjFactura.FACT_RECEPTOR_STATUS = "C";
        //        ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = (chkRechazado.Checked == true) ? txtObservaciones.Text : string.Empty;

        //        if (chkRechazado.Checked == true)
        //            ObjFactura.FACT_CONFIRMADO = (chkRechazado.Checked == true) ? (chkConfirmaSolicitud.Checked == true) ? "S" : string.Empty : string.Empty;
        //        else
        //            ObjFactura.FACT_CONFIRMADO = chkSolicitar.Checked == true ? "S" : "N";


        //        ObjFactura.FACT_OBSERVACIONES = txtDescConcepto.Text.ToUpper();


        //            ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
        //            CNFactura.FacturaActDatosCaja(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);


        //        if (Verificador == "0")
        //        {
        //            CNCjaFactura.FacturaCajaBorrar(ObjFactura, ref Verificador);
        //            if (Verificador == "0")
        //            {
        //                if (grdArchivos.Rows.Count > 0)
        //                {
        //                    //fullPath = Path.Combine(Server.MapPath("../Facturas/PDF/"));
        //                    //ListArch = (List<CajaFactura>)Session["Archivos"];
        //                    //CNCjaFactura.FacturaCajaAgregar(SesionUsu.Usu_Nombre, ref ListArch, ObjFactura, fullPath, ref Verificador);


        //                    fullPath = Path.Combine(Server.MapPath("../ArchivosFacturasTemp/"));
        //                    ListArch = (List<CajaFactura>)Session["Archivos"];
        //                    CNCjaFactura.FacturaCajaAgregar(SesionUsu.Usu_Nombre, ref ListArch, Convert.ToInt32(ObjFactura.ID_FACT), fullPath, ddlTipo.SelectedValue, ref Verificador);

        //                }


        //                if (Verificador == "0")
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true);
        //                    mltViewFacturas.ActiveViewIndex = 0;
        //                    Status();
        //                    ddlDependencia.SelectedIndex = 0;
        //                    ddlDependencia_SelectedIndexChanged(null, null);
        //                    SesionUsu.Editar = 0;
        //                }
        //                else
        //                {
        //                    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
        //                }
        //            }
        //            else
        //            {
        //                string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
        //            }
        //        }
        //        else
        //        {
        //            string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
        //        }
        //    }
        //    else
        //    {
        //        //Accordion1.RequireOpenedPane
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se debe adjuntar el Convenio para los conceptos 800.');", true);  //lblMsj.Text = ex.Message;
        //    }

        //}
        protected void Guardar()
        {
            bool ExisteConcepto800 = VerificaConceptos();
            if (ExisteConcepto800 == false || chkRechazado.Checked == true)
            {
                ObjFactura.FACT_TIPO = ddlTipo.SelectedValue;
                ObjFactura.FACT_DEPENDENCIA = ddlDependencia2.SelectedValue;
                ObjFactura.FACT_RECEPTOR_RFC = txtReceptor_Rfc.Text;
                ObjFactura.FACT_RECEPTOR_TIPO_PERS = rdoBttnReceptorTipoPersona.SelectedValue;
                ObjFactura.FACT_NOMBRE = txtReceptor_Nombre.Text;
                ObjFactura.FACT_RECEPTOR_DOMICILIO = txtReceptor_Domicilio.Text;
                ObjFactura.FACT_RECEPTOR_COLONIA = txtReceptor_Colonia.Text;
                ObjFactura.FACT_RECEPTOR_ESTADO = ddlReceptor_Estado.SelectedValue;
                ObjFactura.FACT_RECEPTOR_MUNICIPIO = ddlReceptor_Municipio.SelectedValue;
                ObjFactura.FACT_RECEPTOR_CP = txtReceptor_CP.Text;
                ObjFactura.FACT_RECEPTOR_METODO_PAGO = ddlReceptor_MetodoPago.SelectedValue;
                ObjFactura.FACT_RECEPTOR_FORMA_PAGO = ddlForma_Pago.SelectedValue;
                ObjFactura.CFDI = ddlCFDI.SelectedValue;
                ObjFactura.FACT_RECEPTOR_TELEFONO = txtReceptor_Telefono.Text;
                ObjFactura.FACT_RECEPTOR_CORREO = txtReceptor_Correo.Text;
                ObjFactura.FACT_RECEPTOR_STATUS = "C";
                ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = (chkRechazado.Checked == true) ? txtObservaciones.Text : string.Empty;

                if (chkRechazado.Checked == true)
                {
                    if (ddlStatus.SelectedValue == "C" && chkConfirmaSolicitud.Checked==true)
                        ObjFactura.FACT_RECEPTOR_STATUS = "S";

                    ObjFactura.FACT_CONFIRMADO = (chkRechazado.Checked == true) ? (chkConfirmaSolicitud.Checked == true) ? "S" : string.Empty : string.Empty;
                }
                else
                    ObjFactura.FACT_CONFIRMADO = chkSolicitar.Checked == true ? "S" : "N";


                if (ddlStatus.SelectedValue == "C" && chkSolicitar.Checked == true)
                    ObjFactura.FACT_RECEPTOR_STATUS = "S";
                else if(grdArchivos.Rows.Count>=1 && ddlStatus.SelectedValue=="S" )
                    ObjFactura.FACT_RECEPTOR_STATUS = "F";
                else if (ddlStatus.SelectedValue == "S" && chkRechazado.Checked == true)
                    ObjFactura.FACT_RECEPTOR_STATUS = "R";



                ObjFactura.FACT_OBSERVACIONES = txtDescConcepto.Text.ToUpper();


                //ObjFactura.FACT_TIPO = (SesionUsu.Editar!=3)?Convert.ToString(grdDatosFactura.SelectedRow.Cells[19].Text):"T";

                //ObjFactura.OFICIO = txtNumOficio.Text;
                //ObjFactura.FECHA_OFICIO = txtFechaOficio.Text;
                //Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                ObjFactura.NUMERO_EXTERIOR = (txtReceptor_NumExt.Text==null || txtReceptor_NumExt.Text == string.Empty) ?"0": txtReceptor_NumExt.Text;
                ObjFactura.NUMERO_INTERIOR = (txtReceptor_NumInt.Text == null || txtReceptor_NumInt.Text == string.Empty) ? "0" : txtReceptor_NumInt.Text;

                if (SesionUsu.Editar == 1)
                {
                    ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    CNFactura.FacturaActDatosCaja(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                }

                if (Verificador == "0")
                {
                    CNCjaFactura.FacturaCajaBorrar(ObjFactura, ref Verificador);
                    if (Verificador == "0")
                    {
                        if (grdArchivos.Rows.Count > 0)
                        {
                            //fullPath = Path.Combine(Server.MapPath("../Facturas/PDF/"));
                            //ListArch = (List<CajaFactura>)Session["Archivos"];
                            //CNCjaFactura.FacturaCajaAgregar(SesionUsu.Usu_Nombre, ref ListArch, ObjFactura, fullPath, ref Verificador);


                            fullPath = Path.Combine(Server.MapPath("../ArchivosFacturasTemp/"));
                            ListArch = (List<CajaFactura>)Session["Archivos"];
                            CNCjaFactura.FacturaCajaAgregar(SesionUsu.Usu_Nombre, ref ListArch, Convert.ToInt32(ObjFactura.ID_FACT), fullPath, ddlTipo.SelectedValue, ref Verificador);

                        }


                        if (Verificador == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true);
                            mltViewFacturas.ActiveViewIndex = 0;
                            Status();
                            ddlDependencia.SelectedIndex = 0;
                            ddlDependencia_SelectedIndexChanged(null, null);
                            SesionUsu.Editar = 0;
                        }
                        else
                        {
                            string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                        }
                    }
                    else
                    {
                        string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
                    }
                }
                else
                {
                    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
                }
            }
            else
            {
                //Accordion1.RequireOpenedPane
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se debe adjuntar el Convenio para los conceptos 800.');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void GuardarEfect()
        {
            bool ExisteConcepto800 = VerificaConceptos();
            if (ExisteConcepto800 == false || chkRechazado.Checked == true)
            {
                ObjFacturacion.TIPO = ddlTipo.SelectedValue;
                ObjFacturacion.DEPENDENCIA = ddlDependencia2.SelectedValue;
                ObjFacturacion.RECEPTOR_RFC = txtReceptor_Rfc.Text;
                ObjFacturacion.RECEPTOR_TIPO_PERS = rdoBttnReceptorTipoPersona.SelectedValue;
                ObjFacturacion.RECEPTOR_NOMBRE = txtReceptor_Nombre.Text;
                ObjFacturacion.RECEPTOR_DOMICILIO = txtReceptor_Domicilio.Text;
                ObjFacturacion.RECEPTOR_COLONIA = txtReceptor_Colonia.Text;
                ObjFacturacion.RECEPTOR_ESTADO = ddlReceptor_Estado.SelectedValue;
                ObjFacturacion.RECEPTOR_MUNICIPIO = ddlReceptor_Municipio.SelectedValue;
                ObjFacturacion.RECEPTOR_CP = txtReceptor_CP.Text;
                ObjFacturacion.NUMERO_EXTERIOR = txtReceptor_NumExt.Text;
                ObjFacturacion.NUMERO_INTERIOR = txtReceptor_NumInt.Text;
                ObjFacturacion.RECEPTOR_METODO_PAGO = ddlReceptor_MetodoPago.SelectedValue;
                ObjFacturacion.RECEPTOR_METODO_PAGO_FA = ddlReceptor_MetodoPagoFA.SelectedValue;
                ObjFacturacion.FOLIO_PAGADO = txtFolioFactPagada.Text;
                ObjFacturacion.RECEPTOR_FORMA_PAGO = ddlForma_Pago.SelectedValue;
                ObjFacturacion.CFDI = ddlCFDI.SelectedValue;
                ObjFacturacion.RECEPTOR_TELEFONO = txtReceptor_Telefono.Text;
                ObjFacturacion.RECEPTOR_CORREO = txtReceptor_Correo.Text;
                ObjFacturacion.RECEPTOR_STATUS = "C";
                ObjFacturacion.RECEPTOR_STATUS_NOTAS = (chkRechazado.Checked == true) ? txtObservaciones.Text : string.Empty;

                if (chkRechazado.Checked == true)
                {
                    //if(ddlStatus.SelectedValue=="C")
                    ObjFacturacion.CONFIRMADO = (chkRechazado.Checked == true) ? (chkConfirmaSolicitud.Checked == true) ? "S" : string.Empty : string.Empty;
                    //else

                }
                else
                    ObjFacturacion.CONFIRMADO = chkSolicitar.Checked == true ? "S" : "N";


                ObjFacturacion.OBSERVACIONES = txtDescConcepto.Text.ToUpper();

                //Datos del Voucher
                ObjFacturacion.FOLIO_PAGO = txtFolio.Text;
                ObjFacturacion.FECHA_PAGO = txtFecha.Text;
                ObjFacturacion.IMPORTE_PAGO = (txtImporteDeposito.Text == string.Empty) ? 0 : Convert.ToDouble(txtImporteDeposito.Text);  //Convert.ToDouble(txtImporteDeposito.Text);
                ObjFacturacion.IVA_PAGO = (txtIvaDeposito.Text == string.Empty) ? 0 : Convert.ToDouble(txtIvaDeposito.Text); //Convert.ToDouble(txtIvaDeposito.Text);
                ObjFacturacion.TOTAL_PAGO = (txtTotalDeposito.Text == string.Empty) ? 0 : Convert.ToDouble(txtTotalDeposito.Text);  //Convert.ToDouble(txtTotalDeposito.Text);
                ObjFacturacion.RUTA_ADJUNTO = string.Empty;

                //Datos del Oficio
                ObjFacturacion.NUM_OFICIO = txtNumOficio.Text;
                ObjFacturacion.FECHA_OFICIO = txtFechaOficio.Text;
                ObjFacturacion.RUTA_ADJUNTO_OFICIO = string.Empty;

                //Datos del Convenio
                ObjFacturacion.IMPORTE_CONVENIO = (txtImporteConvenio.Text == string.Empty) ? 0 : Convert.ToDouble(txtImporteConvenio.Text);
                ObjFacturacion.IVA_CONVENIO = (txtIVAConvenio.Text == string.Empty) ? 0 : Convert.ToDouble(txtIVAConvenio.Text); //Convert.ToDouble(txtIVAConvenio.Text);
                ObjFacturacion.TOTAL_CONVENIO = (txtTotalConvenio.Text == string.Empty) ? 0 : Convert.ToDouble(txtTotalConvenio.Text); //Convert.ToDouble(txtTotalConvenio.Text);
                ObjFacturacion.OBSERVACIONES_CONVENIO = txtObservacionesConvenio.Text;
                ObjFacturacion.RUTA_ADJUNTO_CONVENIO = string.Empty;

                //REP
                ObjFacturacion.FECHA_REP = txtFechaRep.Text;
                ObjFacturacion.FOLIO_REP = txtNumREP.Text;
                ObjFacturacion.RUTA_ADJUNTO_REP = string.Empty;

                if (grdArchivos.Rows.Count > 0 && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "S")
                    ObjFacturacion.RECEPTOR_STATUS = "F";
                else if (grdArchivos.Rows.Count > 0 && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "P")
                    ObjFacturacion.RECEPTOR_STATUS = "E";
                else if (grdArchivos.Rows.Count > 0 && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "F")
                {
                    if (txtFolio.Text != string.Empty && txtFecha.Text != string.Empty && txtImporteDeposito.Text != string.Empty)
                        ObjFacturacion.RECEPTOR_STATUS = "P";
                }
                else
                {
                    if (chkRechazado.Checked == true && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "C")
                    {
                        if (chkConfirmaSolicitud.Checked == true)
                            ObjFacturacion.RECEPTOR_STATUS = "S";
                    }
                    else if (chkRechazado.Checked == true && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "S")
                        ObjFacturacion.RECEPTOR_STATUS = "R";
                    else if (txtNumREP.Text != string.Empty && txtFechaRep.Text != string.Empty && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "F")
                        ObjFacturacion.RECEPTOR_STATUS = "P";
                    else
                    {
                        if (chkConfirmaSolicitud.Checked == true)
                            ObjFacturacion.RECEPTOR_STATUS = "S";
                        if (chkSolicitar.Checked == true)
                            ObjFacturacion.RECEPTOR_STATUS = "S";
                    }
                }

                if (lblArchivoVoucher.NavigateUrl != string.Empty)
                    ObjFacturacion.RUTA_ADJUNTO = lblArchivoVoucher.Text;
                else
                    ObjFacturacion.RUTA_ADJUNTO = string.Empty;

                if (lblArchivoOficio.NavigateUrl != string.Empty)
                    ObjFacturacion.RUTA_ADJUNTO_OFICIO = lblArchivoOficio.Text;
                else
                    ObjFacturacion.RUTA_ADJUNTO_OFICIO = string.Empty;

                if (lblArchivoConvenio.NavigateUrl != string.Empty)
                    ObjFacturacion.RUTA_ADJUNTO_CONVENIO = lblArchivoConvenio.Text;
                else
                    ObjFacturacion.RUTA_ADJUNTO_CONVENIO = string.Empty;
                if (lblArchivoREP.NavigateUrl != string.Empty)
                    ObjFacturacion.RUTA_ADJUNTO_REP = lblArchivoREP.Text;
                else
                    ObjFacturacion.RUTA_ADJUNTO_REP = string.Empty;


                if (SesionUsu.Editar == 2)
                {
                    ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text);
                    CNFacturacion.FacturaEditarDatosEfect2(ObjFacturacion, SesionUsu.Usu_Nombre, ref Verificador);
                }

                else
                    CNFacturacion.FacturaAgregarDatosCaja2(ref ObjFacturacion, SesionUsu.Usu_Nombre, ref Verificador);

                if (Verificador == "0")
                {
                    if (lblArchivoVoucher.NavigateUrl != string.Empty)
                    {
                        string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), lblArchivoVoucher.Text);
                        string DestinoArchivo;
                        if (SesionUsu.Editar == 3)
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-V-" + lblArchivoVoucher.Text;
                        else
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-V-" + lblArchivoVoucher.Text.Replace(ObjFacturacion.ID_FACT + "-V-", string.Empty);

                        DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), DestinoArchivo);
                        if (System.IO.File.Exists(OrigenArchivo))
                        {
                            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                            System.IO.File.Delete(OrigenArchivo);
                        }
                    }

                    if (lblArchivoOficio.NavigateUrl != string.Empty)
                    {
                        string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), lblArchivoOficio.Text);
                        string DestinoArchivo;
                        if (SesionUsu.Editar == 3)
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-O-" + lblArchivoOficio.Text;
                        else
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-O-" + lblArchivoOficio.Text.Replace(ObjFacturacion.ID_FACT + "-O-", string.Empty);

                        DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), DestinoArchivo);
                        if (System.IO.File.Exists(OrigenArchivo))
                        {
                            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                            System.IO.File.Delete(OrigenArchivo);
                        }
                    }

                    if (lblArchivoConvenio.NavigateUrl != string.Empty)
                    {
                        string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), lblArchivoConvenio.Text);
                        string DestinoArchivo;
                        if (SesionUsu.Editar == 3)
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-C-" + lblArchivoConvenio.Text;
                        else
                            DestinoArchivo = ObjFacturacion.ID_FACT + "-C-" + lblArchivoConvenio.Text.Replace(ObjFacturacion.ID_FACT + "-C-", string.Empty);

                        DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), DestinoArchivo);
                        if (System.IO.File.Exists(OrigenArchivo))
                        {
                            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                            System.IO.File.Delete(OrigenArchivo);
                        }
                    }

                    if (grvConceptos.Rows.Count > 0)
                    {
                        ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                        if (ListDetConcepto.Count >= 1)
                        {
                            switch (SesionUsu.Editar)
                            {
                                case 3:
                                    CNFacturacion.FacturaDetInsertar(ListDetConcepto, Convert.ToInt32(ObjFacturacion.ID_FACT), ref Verificador);
                                    break;
                                case 2:
                                    CNFacturacion.FacturaDetEditar(ListDetConcepto, Convert.ToInt32(ObjFacturacion.ID_FACT), ref Verificador);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
                }


                if (Verificador == "0")
                {
                    CNFacturacion.FacturaDoctoBorrar(ObjFacturacion, ref Verificador);
                    if (Verificador == "0")
                    {
                        if (grdArchivos.Rows.Count > 0)
                        {
                            fullPath = Path.Combine(Server.MapPath("../ArchivosFacturasTemp/"));
                            ListArch = (List<CajaFactura>)Session["Archivos"];
                            CNFacturacion.FacturaDoctoAgregar(SesionUsu.Usu_Nombre, ref ListArch, Convert.ToInt32(ObjFacturacion.ID_FACT), fullPath, ddlTipo.SelectedValue, ref Verificador);
                        }


                        if (Verificador == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true);
                            mltViewFacturas.ActiveViewIndex = 0;
                            Status();
                            ddlDependencia.SelectedIndex = 0;
                            ddlDependencia_SelectedIndexChanged(null, null);
                            SesionUsu.Editar = 0;
                        }
                        else
                        {
                            string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                        }
                    }
                    else
                    {
                        string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
                    }
                }
                else
                {
                    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = Verificador;
                }
            }
            else
            {
                //Accordion1.RequireOpenedPane
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Se debe adjuntar el Convenio para los conceptos 800.');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void inicializar()
        {
            tabFacturas.ActiveTabIndex = 0;
            mltViewFacturas.ActiveViewIndex = 0;
            txtFecha_Factura_Ini.Text = "01/01" + System.DateTime.Now.ToString("/yyyy"); //DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CargarCombos();
            ddlTipo_SelectedIndexChanged(null, null);
            linkBttnBuscar_Click(null, null);
        }
        protected void Tipo()
        {


            try
            {
                switch (ddlTipo.SelectedValue)
                {
                    case "T":
                        CargarGridEfectivo();
                        break;
                    case "R":
                        CargarGrid();
                        break;
                    case "A":
                        CargarGridEfectivo();
                        break;

                    default:
                        break;
                }
                Session["Facturas"] = null;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        protected bool VerificaConceptos()
        {
            try
            {
                if (grvConceptos.Rows.Count >= 1 && ddlTipo.SelectedValue == "A")
                {
                    if (lblArchivoConvenio.Text == string.Empty)
                    {
                        if (Session["Conceptos"] != null)
                        {
                            ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                            var filtro = from c in ListDetConcepto
                                         where c.ClaveConcepto.Substring(2, 1).Contains("8") //txtSearch.Text
                                         select c;
                            if (filtro.Count() >= 1)
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        protected void CargarCombos()
        {
            try
            {
                if (Usur.Usu_TipoPermiso == "C")
                {
                    CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_UR_Factura", ref ddlDependencia);
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia2, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

                }
                else
                {
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia2, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                }

                //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipo_Servicios_F", ref ddlServicio, "INGRESOS");
                //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles_Caja", ref ddlNivel, "INGRESOS");
                //CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Status_Facturas", ref ddlStatus, "p_usuario", "p_tipo_factura", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue);
                CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_Avance_Factura", ref ddlAvance);
                CNComun.LlenaCombo("PKG_CONTRATOS.Obt_Combo_Estados", ref ddlReceptor_Estado, "p_pais", "1");
                ddlReceptor_Estado.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                ddlEstado_Fiscal_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void CargarGrid()
        {
            /*Int32[] CeldasFacturados = { 0, 8, 10, 11, 13, 14, 15, 16, 17 };
            Int32[] CeldasSolicitados = { 0, 8, 10, 11, 12, 13, 14, 15, 16, 17 };
            Int32[] CeldasPorConfirmar = { 0, 10, 11, 12, 13, 14, 15, 17 };*/
            Int32[] CeldasFacturados = { 0, 7, 8, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25, 26 }; //{ 0, 6, 7, 9, 10, 11, 13, 14, 16, 17, 18, 20, 21, 23, 24, 25, 26 };
            Int32[] CeldasSolicitados = { 0, 7, 8, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            Int32[] CeldasPorConfirmar = { 0, 6, 7, 12, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25, 26 };


            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();

                
                switch (ddlStatus.SelectedValue)
                {
                    case "F":
                        if (grdDatosFactura.Rows.Count >= 1)
                            StyleColumnas(grdDatosFactura, CeldasFacturados);
                        //OcultaColumnas(grdDatosFactura, CeldasFacturados);
                        break;
                    case "C":
                        //grdDatosFactura.HeaderRow.Cells[8].Text = "Fecha Pago";
                        if (grdDatosFactura.Rows.Count >= 1)
                            StyleColumnas(grdDatosFactura, CeldasPorConfirmar);

                        //CNComun.HideColumns(grdDatosFactura, CeldasPorConfirmar);
                        break;
                    case "S":
                        if (grdDatosFactura.Rows.Count >= 1)
                            StyleColumnas(grdDatosFactura, CeldasSolicitados);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        public void StyleColumnas(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                grdView.FooterRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {

                    if (row.Cells[26].Text == "RED")
                        row.BackColor = Color.FromName("#f38383b0");
                    else if (row.Cells[26].Text == "YELLOW")
                        row.BackColor = Color.FromName("#eded75");

                    LinkButton linkBttnDocto = (LinkButton)(row.Cells[23].FindControl("linkBttnFacturaRef"));
                    linkBttnDocto.Visible = false;

                    if (row.Cells[19].Text == "R")
                    {
                        row.Cells[11].BackColor = System.Drawing.Color.Red;
                        row.Cells[11].ForeColor = System.Drawing.Color.White;

                    }
                    else if (row.Cells[19].Text == "S")
                    {
                        row.Cells[11].BackColor = System.Drawing.Color.Green;
                        row.Cells[11].ForeColor = System.Drawing.Color.White;
                        //linkBttnCancelar.Visible = true;
                    }
                    else if (row.Cells[19].Text == "F")
                    {
                        //linkEditar.Visible = false;
                        //linkBttnDocto.Visible = true;
                        linkBttnDocto.Visible = true;
                        row.Cells[11].BackColor = System.Drawing.Color.CadetBlue; //Color.FromName("#275090"); //System.Drawing.Color.DarkBlue;
                        row.Cells[11].ForeColor = System.Drawing.Color.White;
                    }

                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }

        public void StyleColumnasEfec(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                //grdView.FooterRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {

                    if (row.Cells[28].Text == "RED")
                        row.BackColor = Color.FromName("#f38383b0");
                    else if (row.Cells[28].Text == "YELLOW")
                        row.BackColor = Color.FromName("#eded75");

                    //LinkButton linkDoctos = (LinkButton)(row.Cells[20].FindControl("linkBttnFactura"));
                    //linkDoctos.Visible = true;

                    LinkButton linkEditar = (LinkButton)(row.Cells[20].FindControl("linkBttnEditar0"));
                    linkEditar.Visible = true;

                    LinkButton linkBttnDocto = (LinkButton)(row.Cells[20].FindControl("linkBttnFactura"));
                    linkBttnDocto.Visible = false;

                    LinkButton linkBttnCancelar = (LinkButton)(row.Cells[21].FindControl("linkBttnCancelar0"));
                    linkBttnCancelar.Visible = false;
                    

                    if (row.Cells[24].Text == "R")
                    {
                        row.Cells[18].BackColor = System.Drawing.Color.Red;
                        row.Cells[18].ForeColor = System.Drawing.Color.White;

                    }
                    else if (row.Cells[24].Text == "S")
                    {
                        row.Cells[18].BackColor = System.Drawing.Color.Green;
                        row.Cells[18].ForeColor = System.Drawing.Color.White;
                        //linkBttnCancelar.Visible = true;
                    }
                    else if (row.Cells[24].Text == "F")
                    {
                        linkEditar.Visible = false;
                        linkBttnDocto.Visible = true;
                        row.Cells[18].BackColor = System.Drawing.Color.CadetBlue; //Color.FromName("#275090"); //System.Drawing.Color.DarkBlue;
                        row.Cells[18].ForeColor = System.Drawing.Color.White;
                    }
                    else if (row.Cells[24].Text == "P")
                    {
                        linkEditar.Visible = false;
                        linkBttnDocto.Visible = true;
                        row.Cells[18].BackColor = System.Drawing.Color.YellowGreen;
                        row.Cells[18].ForeColor = System.Drawing.Color.White;
                    }
                    else if (row.Cells[24].Text == "E")
                    {
                        linkEditar.Visible = false;
                        linkBttnDocto.Visible = true;
                        row.Cells[18].BackColor = System.Drawing.Color.DarkGray;
                        row.Cells[18].ForeColor = System.Drawing.Color.White;
                    }
                    else if (row.Cells[24].Text == "C")
                    {
                        linkBttnCancelar.Visible = true;
                        //LinkButton linkEditar = (LinkButton)(row.Cells[20].FindControl("linkBttnEditar0"));
                        //linkEditar.Visible = true;

                        //LinkButton linkBttnDocto = (LinkButton)(row.Cells[20].FindControl("linkBttnFactura"));
                        //linkBttnDocto.Visible = false;

                    }

                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }


        public void OcultaColumnas(GridView grdView, Int32[] Columnas)
        {
            for (int i = 0; i < Columnas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                //grdView.FooterRow.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Columnas.GetValue(i))].Visible = false;
                }
            }
        }

        private void CargarGridEfectivo()
        {


            try
            {
                DataTable dt = new DataTable();
                grdDatosFacturaEfect.DataSource = dt;
                grdDatosFacturaEfect.DataSource = GetListEfectivo();
                grdDatosFacturaEfect.DataBind();
                if (ddlTipo.SelectedValue == "T")
                {
                    Int32[] Celdas = { 0, 4, 5, 11, 12, 13, 14, 15, 22, 23, 24, 25, 26, 27, 28, 29 };
                    Int32[] CeldasSolicitados = { 0, 4, 5, 11, 12, 13, 14, 15, 22, 23, 24, 25, 26, 27, 28, 29 };
                    Int32[] CeldasFacturados = { 0, 4, 5, 11, 12, 13, 14, 15, 21, 22, 23, 24, 25, 26, 27, 28 };
                    if (ddlStatus.SelectedValue == "F")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasFacturados);
                    else if (ddlStatus.SelectedValue == "S")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasSolicitados);
                    else
                        StyleColumnasEfec(grdDatosFacturaEfect, Celdas);

                }
                else
                {
                    Int32[] Celdas = { 0, 6, 7, 8, 9, 10, 14, 15, 22, 23, 24, 25, 26, 27, 28, 29 };
                    Int32[] CeldasSolicitados = { 0, 6, 7, 8, 9, 10, 14, 15, 20, 22, 23, 24, 25, 26, 27, 28 };
                    Int32[] CeldasFacturados = { 0, 8, 9, 11, 12, 14, 15, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
                    Int32[] CeldasPagados = { 0, 8, 9, 11, 12, 14, 15, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
                    Int32[] CeldasPUE = { 0, 8, 9, 11, 12, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
                    if (ddlStatus.SelectedValue == "F")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasFacturados);
                    else if (ddlStatus.SelectedValue == "S")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasSolicitados);
                    else if (ddlStatus.SelectedValue == "P")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasPagados);
                    else if (ddlStatus.SelectedValue == "E")
                        StyleColumnasEfec(grdDatosFacturaEfect, CeldasPUE);
                    else
                    {

                        StyleColumnasEfec(grdDatosFacturaEfect, Celdas);
                    }

                }



            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }
        private void CargarGridConceptosDisp()
        {
            //Int32[] CeldasConcep = { 0, 11, 13, 14, 15 };
            try
            {
                DataTable dt = new DataTable();
                grvConceptosDisp.DataSource = dt;
                grvConceptosDisp.DataSource = GetListConceptos();
                grvConceptosDisp.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridArchivos()
        {
            try
            {
                DataTable dt = new DataTable();
                grdArchivos.DataSource = dt;
                grdArchivos.DataSource = GetList();
                grdArchivos.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void CargarGridDoctos()
        {
            try
            {
                DataTable dt = new DataTable();
                grdDoctosFactura.DataSource = dt;
                grdDoctosFactura.DataSource = GetListDoctos();
                grdDoctosFactura.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void CargarGridDoctosEfect()
        {
            try
            {
                DataTable dt = new DataTable();
                grdDoctosFactura.DataSource = dt;
                grdDoctosFactura.DataSource = GetListDoctosEfect();
                grdDoctosFactura.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        private void CargarGridHist()
        {
            //Int32[] CeldasConcep = { 0, 11, 13, 14, 15 };
            try
            {
                DataTable dt = new DataTable();
                grdBitacora.DataSource = dt;
                grdBitacora.DataSource = GetListHistoricos();
                grdBitacora.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGridHistRef()
        {
            //Int32[] CeldasConcep = { 0, 11, 13, 14, 15 };
            try
            {
                DataTable dt = new DataTable();
                grdBitacora.DataSource = dt;
                grdBitacora.DataSource = GetListHistoricosRef();
                grdBitacora.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void HideColumns(GridView grdView, Int32[] Celdas)
        {
            for (int i = 0; i < Celdas.Length; i++)
            {
                grdView.HeaderRow.Cells[Convert.ToInt32(Celdas.GetValue(i))].Visible = false;
                foreach (GridViewRow row in grdView.Rows)
                {
                    row.Cells[Convert.ToInt32(Celdas.GetValue(i))].Visible = false;
                }
            }
        }
        private List<CajaFactura> GetList()
        {
            try
            {
                List<CajaFactura> List = new List<CajaFactura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                //CNCjaFactura.FacturaCajaConsultaGrid(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ddlStatus.SelectedValue.ToString(), ddlFiltro.SelectedValue, ddlFiltro.SelectedValue, ref List);
                CNCjaFactura.FacturaCajaConsultaGrid3(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ddlStatus.SelectedValue.ToString(), ddlFiltro.SelectedValue, ddlFiltro.SelectedValue, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Factura> GetListDoctos()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNCjaFactura.FacturaDoctosConsultaGrid(ObjFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Facturacion> GetListDoctosEfect()
        {
            try
            {
                List<Facturacion> List = new List<Facturacion>();
                if(ddlTipo.SelectedValue=="R")
                    ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
                else
                    ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text);

                CNFacturacion.FacturaDoctosConsultaGrid(ObjFacturacion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Facturacion> GetListEfectivo()
        {
            try
            {
                List<Facturacion> List = new List<Facturacion>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNFacturacion.FacturaSolConsultaGrid(Usur, ref ObjFacturacion, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, ""/*txtReferencia.Text*/, ddlStatus.SelectedValue.ToString(), "T", ddlTipo.SelectedValue, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<ConceptoPago> GetListConceptos()
        {
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjConcepto.Status = 'A';
                CNConcepto.ConsultarTipoServicio(ObjConcepto, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Facturacion> GetListHistoricos()
        {
            try
            {
                List<Facturacion> List = new List<Facturacion>();
                ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text);
                CNFacturacion.FacturaHistSolConsultaGrid(ObjFacturacion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Facturacion> GetListHistoricosRef()
        {
            try
            {
                List<Facturacion> List = new List<Facturacion>();
                ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNCjaFactura.FacturaHistSolConsultaGrid(ObjFacturacion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGridConceptosAsig(List<DetConcepto> ListConceptos)
        {
            try
            {
                grvConceptos.DataSource = ListConceptos;
                grvConceptos.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void LimipiarCampos()
        {
            try
            {
                txtReceptor_Rfc.Text = string.Empty;
                rdoBttnReceptorTipoPersona.SelectedValue = "F";
                rdoBttnReceptorTipoPersona_SelectedIndexChanged(null, null);
                txtReceptor_Nombre.Text = string.Empty;
                txtReceptor_Domicilio.Text = string.Empty;
                txtReceptor_Colonia.Text = string.Empty;
                txtReceptor_NumExt.Text = string.Empty;
                txtReceptor_NumInt.Text = string.Empty;
                ddlReceptor_Estado.SelectedValue = "8";
                ddlEstado_Fiscal_SelectedIndexChanged(null, null);
                ddlReceptor_Municipio.SelectedValue = "213";
                txtReceptor_CP.Text = string.Empty;
                ddlReceptor_MetodoPago.SelectedIndex = 0;
                ddlForma_Pago.SelectedIndex = 0;
                ddlCFDI.SelectedIndex = 0;
                txtReceptor_Telefono.Text = string.Empty;
                txtReceptor_Correo.Text = string.Empty;
                txtDescConcepto.Text = string.Empty;
                chkSolicitar.Checked = false;
                txtObservaciones.Text = string.Empty;
                chkRechazado.Checked = false;


                //Datos del Voucher
                txtFolio.Text = string.Empty;
                txtFecha.Text = string.Empty;
                txtImporteDeposito.Text = string.Empty;
                chkIvaDes.Checked = false;
                chkIvaDes_CheckedChanged(null, null);
                txtIvaDeposito.Text = string.Empty;
                txtTotalDeposito.Text = string.Empty;
                txtFolioFactPagada.Text = string.Empty;
                ddlReceptor_MetodoPagoFA.SelectedIndex = 0;


                //Datos del Oficio
                txtNumOficio.Text = string.Empty;
                txtFechaOficio.Text = string.Empty;


                //Importe/Convenio
                txtImporteConvenio.Text = string.Empty;
                txtIVAConvenio.Text = string.Empty;
                txtTotalConvenio.Text = string.Empty;
                txtObservacionesConvenio.Text = string.Empty;

                //REP
                txtFechaRep.Text = string.Empty;
                txtNumREP.Text = string.Empty;



                chkConfirmaSolicitud.Visible = false;
                chkConfirmaSolicitud.Checked = false;
                lblArchivoVoucher.NavigateUrl = string.Empty;
                lblArchivoVoucher.Text = string.Empty;
                linkBttnEliminarVoucher.Visible = false;

                lblArchivoOficio.NavigateUrl = string.Empty;
                lblArchivoOficio.Text = string.Empty;
                linkBttnEliminarOficio.Visible = false;

                lblArchivoConvenio.NavigateUrl = string.Empty;
                lblArchivoConvenio.Text = string.Empty;
                linkBttnEliminarConvenio.Visible = false;

                ddlDependencia.Enabled = true;
                ddlDependencia.Visible = true;
                chkRechazado.Visible = false;
                rowObservaciones.Visible = false;
                txtFecha_Fact_Cja.Enabled = true;
                txtFolio_Fact_Cja.Enabled = true;
                ddlCFDI.SelectedIndex = 0;
                txtDescConcepto.Text = string.Empty;
                ddlForma_Pago.SelectedIndex = 0;

                Session["Archivos"] = null;
                grdArchivos.DataSource = null;
                grdArchivos.DataBind();
                Session["Conceptos"] = null;
                ddlNivel_SelectedIndexChanged(null, null);
                grvConceptos.DataSource = null;
                grvConceptos.DataBind();
                tabFacturas.ActiveTabIndex = 0;
                chkSolicitar.Checked = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarVoucher()
        {
            fullPath = Path.Combine(Server.MapPath("../DoctosFacturas/"), fileFactura.FileName);
            fileVoucher.SaveAs(fullPath);
        }
        private void DatosFacturaEfectivo(Facturacion ObjFactura)
        {
            try
            {
                if (ObjFactura.RUTA_ADJUNTO != string.Empty)
                {
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), ObjFactura.RUTA_ADJUNTO); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), ObjFactura.RUTA_ADJUNTO);
                    if (System.IO.File.Exists(OrigenArchivo))
                    {
                        System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                        lblArchivoVoucher.NavigateUrl = "../DoctosFacturasTemp/" + ObjFactura.RUTA_ADJUNTO;
                        lblArchivoVoucher.Text = ObjFactura.RUTA_ADJUNTO;
                        linkBttnEliminarVoucher.Visible = true;
                    }
                }

                if (ObjFactura.RUTA_ADJUNTO_OFICIO != string.Empty)
                {
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), ObjFactura.RUTA_ADJUNTO_OFICIO); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), ObjFactura.RUTA_ADJUNTO_OFICIO);
                    if (System.IO.File.Exists(OrigenArchivo))
                    {
                        System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                        lblArchivoOficio.NavigateUrl = "../DoctosFacturasTemp/" + ObjFactura.RUTA_ADJUNTO_OFICIO;
                        lblArchivoOficio.Text = ObjFactura.RUTA_ADJUNTO_OFICIO;
                        linkBttnEliminarOficio.Visible = true;
                    }
                }

                if (ObjFactura.RUTA_ADJUNTO_CONVENIO != string.Empty)
                {
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), ObjFactura.RUTA_ADJUNTO_CONVENIO); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), ObjFactura.RUTA_ADJUNTO_CONVENIO);
                    if (System.IO.File.Exists(OrigenArchivo))
                    {
                        System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                        lblArchivoConvenio.NavigateUrl = "../DoctosFacturasTemp/" + ObjFactura.RUTA_ADJUNTO_CONVENIO;
                        lblArchivoConvenio.Text = ObjFactura.RUTA_ADJUNTO_CONVENIO;
                        linkBttnEliminarConvenio.Visible = true;
                    }
                }

                if (ObjFactura.RUTA_ADJUNTO_REP != string.Empty)
                {
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturas"), ObjFactura.RUTA_ADJUNTO_REP); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), ObjFactura.RUTA_ADJUNTO_REP);
                    if (System.IO.File.Exists(OrigenArchivo))
                    {
                        System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                        lblArchivoREP.NavigateUrl = "../DoctosFacturasTemp/" + ObjFactura.RUTA_ADJUNTO_REP;
                        lblArchivoREP.Text = ObjFactura.RUTA_ADJUNTO_REP;
                        linkBttnEliminarREP.Visible = true;
                    }
                }


                List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                CNDetFacturaEfec.DetFacturaEfecConsultar(ref ListDetConcepto, Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text), ref Verificador);
                if (Verificador == "0")
                {
                    Session["Conceptos"] = ListDetConcepto;
                    CargarGridConceptosAsig(ListDetConcepto);
                    //if (grvConceptos.Rows.Count >= 1)
                    //{
                    //    ddlNivel.SelectedValue = ListDetConcepto[0].ClaveConcepto.Substring(0, 1);
                    //    ddlNivel_SelectedIndexChanged(null, null);
                    //}
                }
                else
                {
                    Verificador = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
                }

                mltViewFacturas.ActiveViewIndex = 2;
                //tabFacturas.Tabs[2].Visible = true;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);
            }
        }

        #endregion



        protected void linkPdf_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "LoadPDF_Nuevo('" + Convert.ToString(DataBinder.Eval(sender, "CommandArgument").ToString()) + "');", true);
            //linkPdf.OnClientClick = "LoadPDF_Nuevo('" +  Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString()) + "')";
            //SesionUsu.Id_Comprobante = Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());

        }



        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 0;
        }

        //protected void Status2()
        //{
        //    if (ddlTipo.SelectedValue == "R")
        //    {
        //        LinkButton linkBttnAgregarReg = (LinkButton)(grdDatosFactura.HeaderRow.Cells[11].FindControl("linkBttnAgregarReg0"));
        //        linkBttnAgregarReg.Visible = (ddlStatus.SelectedValue == "S") ? false : true;
        //    }

        //    switch (ddlStatus.SelectedValue)
        //    {
        //        case "C":
        //            hddnBandera.Value = "1";
        //            tabFacturas.Tabs[2].Visible = false;
        //            tabFacturas.Tabs[1].Visible = true;
        //            if (ddlTipo.SelectedValue == "T")
        //            {
        //                collapse1.Visible = true;
        //                collapse2.Visible = false;
        //                collapse3.Visible = false;
        //            }
        //            else
        //            {
        //                collapse1.Visible = false;
        //                collapse2.Visible = true;
        //                collapse3.Visible = true;
        //            }

        //            break;
        //        case "S":
        //            hddnBandera.Value = "0";
        //            if (ddlTipo.SelectedValue == "T" || ddlTipo.SelectedValue == "A")
        //                tabFacturas.Tabs[1].Visible = true;
        //            else
        //                tabFacturas.Tabs[1].Visible = false;

        //            tabFacturas.Tabs[2].Visible = true;

        //            if (ddlTipo.SelectedValue == "T")
        //            {
        //                collapse1.Visible = true;
        //                collapse2.Visible = false;
        //                collapse3.Visible = false;
        //            }
        //            else
        //            {
        //                collapse1.Visible = false;
        //                collapse2.Visible = true;
        //                collapse3.Visible = true;
        //            }
        //            break;
        //        case "F":
        //            hddnBandera.Value = "0";
        //            if (ddlTipo.SelectedValue == "A")
        //            {
        //                tabFacturas.Tabs[1].Visible = true;
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar1", "VerCollapse1();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar2", "VerCollapse2();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar3", "VerCollapse3();", true);

        //            }
        //            else if (ddlTipo.SelectedValue == "T")
        //            {
        //                collapse1.Visible = true;
        //                collapse2.Visible = false;
        //                collapse3.Visible = false;
        //            }


        //            //Accordion1.Panes[0].Visible = true;
        //            //Accordion1.Panes[1].Visible = (ddlTipo.SelectedValue == "A") ? true : false;
        //            //Accordion1.Panes[2].Visible = (ddlTipo.SelectedValue == "A") ? true : false;


        //            else
        //                tabFacturas.Tabs[1].Visible = false;

        //            tabFacturas.Tabs[2].Visible = true;
        //            break;
        //        case "P":
        //            hddnBandera.Value = "0";
        //            if (ddlTipo.SelectedValue == "T")
        //            {
        //                tabFacturas.Tabs[1].Visible = true;
        //                tabFacturas.Tabs[2].Visible = true;

        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar1", "VerCollapse1();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar2", "OcultarCollapse2();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar3", "OcultarCollapse3();", true);

        //            }
        //            else if (ddlTipo.SelectedValue == "A")
        //            {
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar1", "VerCollapse1();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar2", "VerCollapse2();", true);
        //                ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar3", "VerCollapse3();", true);

        //            }
        //            //Accordion1.Panes[0].Visible = true;
        //            //    Accordion1.Panes[1].Visible = (ddlTipo.SelectedValue == "A") ? true : false;
        //            //    Accordion1.Panes[2].Visible = (ddlTipo.SelectedValue == "A") ? true : false;


        //            else
        //                tabFacturas.Tabs[1].Visible = false;


        //            //tabFacturas.Tabs[2].Visible = true;
        //            //Accordion1.Panes[0].Visible = true;
        //            break;
        //        default:
        //            break;
        //    }
        //}
        protected void Status()
        {
            rowFA.Visible = false;
            pnl1.Enabled = true;
            rowPnl1.Visible = false;

            pnl2.Enabled = true;
            rowPnl2.Visible = false;
            switch (ddlStatus.SelectedValue)
            {
                case "C":
                    hddnBandera.Value = "1";
                    tabFacturas.Tabs[2].Visible = false;
                    tabFacturas.Tabs[1].Visible = true;
                    if (ddlTipo.SelectedValue == "T")
                    {
                        collapse1.Visible = true;
                        collapse2.Visible = false;
                        collapse3.Visible = false;
                        collapse4.Visible = false;
                    }
                    else
                    {
                        collapse1.Visible = false;
                        collapse2.Visible = true;
                        collapse3.Visible = true;
                        collapse4.Visible = false;
                    }

                    break;
                case "S":
                    hddnBandera.Value = "0";
                    if (ddlTipo.SelectedValue == "T" || ddlTipo.SelectedValue == "A")
                        tabFacturas.Tabs[1].Visible = true;
                    else
                        tabFacturas.Tabs[1].Visible = false;

                    tabFacturas.Tabs[2].Visible = true;

                    if (ddlTipo.SelectedValue == "T")
                    {
                        collapse1.Visible = true;
                        collapse2.Visible = false;
                        collapse3.Visible = false;
                        collapse4.Visible = false;
                    }
                    else
                    {
                        collapse1.Visible = false;
                        collapse2.Visible = true;
                        collapse3.Visible = true;
                        collapse4.Visible = false;
                    }
                    break;
                case "F":
                    hddnBandera.Value = "0";
                    if (ddlTipo.SelectedValue == "A")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        collapse1.Visible = true;
                        collapse2.Visible = true;
                        collapse3.Visible = true;
                        collapse4.Visible = false;
                        rowFA.Visible = true;
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar1", "VerCollapse1();", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar2", "VerCollapse2();", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar3", "VerCollapse3();", true);
                    }
                    else if (ddlTipo.SelectedValue == "T")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        pnl1.Enabled = false;
                        pnl2.Enabled = false;
                        rowPnl1.Visible = true;
                        rowPnl2.Visible = true;
                        collapse1.Visible = true;
                        collapse2.Visible = false;
                        collapse3.Visible = false;
                        collapse4.Visible = false;
                    }
                    else
                        tabFacturas.Tabs[1].Visible = false;

                    tabFacturas.Tabs[2].Visible = true;
                    break;
                case "P":
                    hddnBandera.Value = "0";
                    if (ddlTipo.SelectedValue == "T")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        tabFacturas.Tabs[2].Visible = true;


                        collapse1.Visible = true;
                        collapse2.Visible = false;
                        collapse3.Visible = false;
                        collapse4.Visible = false;
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar1", "VerCollapse1();", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar2", "OcultarCollapse2();", true);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "CollapseActualizar3", "OcultarCollapse3();", true);

                    }
                    else if (ddlTipo.SelectedValue == "A")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        collapse1.Visible = true;
                        collapse2.Visible = true;
                        collapse3.Visible = true;
                        collapse4.Visible = true;
                        rowFA.Visible = true;
                    }
                    else
                        tabFacturas.Tabs[1].Visible = false;
                    break;
                case "E":
                    hddnBandera.Value = "0";
                    if (ddlTipo.SelectedValue == "T")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        tabFacturas.Tabs[2].Visible = true;

                        collapse1.Visible = true;
                        collapse2.Visible = false;
                        collapse3.Visible = false;
                        collapse4.Visible = false;

                    }
                    else if (ddlTipo.SelectedValue == "A")
                    {
                        tabFacturas.Tabs[1].Visible = true;
                        collapse1.Visible = true;
                        collapse2.Visible = true;
                        collapse3.Visible = true;
                        collapse4.Visible = true;
                        rowFA.Visible = true;
                    }
                    break;
                default:
                    break;
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CajaFactura> lst = new List<CajaFactura>();
            grdDatosFactura.DataSource = lst;
            grdDatosFactura.DataBind();
            grdDatosFactura.ShowHeader = true;
            //LinkButton linkBttnAgregarReg = (LinkButton)(grdDatosFactura.HeaderRow.Cells[11].FindControl("linkBttnAgregarReg"));



            rowFiltro1.Visible = false;
            rowFiltro2.Visible = false;
            rowInfAdicional.Visible = false;
            //linkBttnAgregarReg.Visible = false;
            //tabFacturas.Tabs[3].Visible = false;
            try

            {



                if (ddlTipo.SelectedValue == "R")
                {
                    lblNota.Text = "<strong>" + ddlTipo.SelectedItem.Text + ":</strong> son los pagos realizados a través de una ficha referenciada (SYSWEB).";
                    rowFiltro1.Visible = true;
                    rowFiltro2.Visible = true;
                    rowInfAdicional.Visible = true;
                    lblEtFormaBusqueda.Text = "Fecha de Pago";
                    grdDatosFactura.Visible = true;
                    grdDatosFacturaEfect.Visible = false;
                }
                else if (ddlTipo.SelectedValue == "T")
                {
                    lblEtFormaBusqueda.Text = "Fecha Depósito";
                    lblNota.Text = "<strong>" + ddlTipo.SelectedItem.Text + ":</strong> son los depósitos realizados directamente a la cuenta de la UNACH.";
                    grdDatosFactura.Visible = false;
                    grdDatosFacturaEfect.Visible = true;
                }
                else if (ddlTipo.SelectedValue == "A")
                {
                    if (ddlStatus.SelectedValue == "F")
                        lblEtFormaBusqueda.Text = "Fecha Factura";
                    else
                        lblEtFormaBusqueda.Text = "Fecha de Solicitud";

                    lblNota.Text = "<strong>" + ddlTipo.SelectedItem.Text + ":</strong> para emitir facturas anticipadas con método de pago PUE(pago en una sola exhibición) y forma de pago ( transferencia electrónica, tarjeta de crédito, tarjeta de débito etc.),la fecha límite de pago es el último día del mes en la que se haya emitido la factura, si el pago es realizado en el siguiente mes la factura se cancelara y se emitirá una nueva factura con las siglas PPD (pago en parcialidades o diferido) y forma de pago (por definir).";
                    grdDatosFactura.Visible = false;
                    grdDatosFacturaEfect.Visible = true;

                }

                linkBttnBuscar_Click(null, null);
                //if (ddlStatus.SelectedValue == "C" && ddlTipo.SelectedValue != "R")
                //    linkBttnAgregarReg.Visible = true;
                //CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Status_Facturas", ref ddlStatus, "p_usuario", "p_tipo_factura", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue);
                //ddlStatus_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Status_Facturas", ref ddlStatus, "p_usuario", "p_tipo_factura", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue);
            ddlStatus_SelectedIndexChanged(null, null);
        }

        protected void grdArchivos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                List<CajaFactura> ListArch = new List<CajaFactura>();
                ListArch = (List<CajaFactura>)Session["Archivos"];
                ListArch.RemoveAt(fila);
                Session["Archivos"] = ListArch;
                grdArchivos.DataSource = ListArch;
                grdArchivos.DataBind();

                if (grdArchivos.Rows.Count >= 1)
                {
                    txtFecha_Fact_Cja.Enabled = false;
                    txtFolio_Fact_Cja.Enabled = false;
                }
                else
                {
                    txtFecha_Fact_Cja.Enabled = true;
                    txtFolio_Fact_Cja.Enabled = true;
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        protected void rdoStatusConfirmados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo();
            //CargarGrid();           
        }


        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Tipo();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }



        protected void ddlEstado_Fiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_CONTRATOS.Obt_Combo_Municipios", ref ddlReceptor_Municipio, "p_edo", ddlReceptor_Estado.SelectedValue);
                ddlReceptor_Municipio.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        protected void imgBttnRepComprobante_Click(object sender, ImageClickEventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 1;
            SesionUsu.Id_Comprobante = Convert.ToInt32(DataBinder.Eval(sender, "CommandArgument").ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteRecibo(" + SesionUsu.Id_Comprobante + ");", true);

        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            txtCorreo.Text = grdDatosFactura.SelectedRow.Cells[15].Text;
            modalCorreo.Show();
        }

        protected void bttnCorreo_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            string asunto = string.Empty;
            string contenido = string.Empty;
            lblMensajeCorreo.Text = string.Empty;
            ObjCjaFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
            modalCorreo.Show();
            try
            {
                List<CajaFactura> ListArch = new List<CajaFactura>();
                CNCjaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Convert.ToString(grdDatosFactura.SelectedRow.Cells[22].Text), ref ListArch);
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                asunto = "Factura UNACH-SYSWEB";
                contenido = "<img src='https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png'><br /><div align=center><font size='4'><a href=\'" + ruta + "'>Factura Electrónica</a></font></div><br /><br />" + "<font size='2'>Para cualquier duda o aclaración te puedes comunicar a los siguientes telefonos:" + "<br /><br /><strong>DEPARTAMENTO DE CAJA GENERAL </strong><br />Teléfono - (961) 617 80 00, Ext.: 1024</font>" +
                    "<strong>DIRECCIÓN DE SISTEMAS DE INFORMACIÓN ADMINISTRATIVA</strong><br />Teléfono - (961) 617 80 00, Ext.: 1302, 5519, 5520 y 5087<br /><br />" +
                    "Este correo electrónico puede contener información confidencial, sólo está dirigida al destinatario del mismo, la información puede ser privilegiada. Está prohibido que cualquier persona distinta al destinatario copie o distribuya este correo. Si usted no es el destinatario, por favor notifíque esto de inmediato";
                string MsjError = string.Empty;
                CNComun.EnvioCorreoAdjunto(ref mmsg, ListArch, asunto, contenido, txtCorreo.Text, ref MsjError);
                if (MsjError == string.Empty)
                {
                    if (mmsg != null)
                    {
                        modalCorreo.Hide();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'La Factura se ha enviado al correo');", true);
                    }
                    else
                        lblMensajeCorreo.Text = "Error en el envio de los archivos."; // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
                }
                else
                    lblMensajeCorreo.Text = MsjError;
            }
            catch (Exception ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                lblMensajeCorreo.Text = ex.Message;
                //string MsjError = ex.Message;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }

        }

        protected void bttnCancelarCorreo_Click(object sender, EventArgs e)
        {
            modalCorreo.Hide();
        }

        protected void chkRechazado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRechazado.Checked == true)
            {
                if (chkConfirmaSolicitud.Visible == false)
                {
                    rowObservaciones.Visible = true;
                }
                else
                {
                    rowObservaciones.Visible = true;
                }
            }
            else
            {
                rowObservaciones.Visible = false;
            }
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 2;
            SesionUsu.Editar = 3;
            LimipiarCampos();
            tabFacturas.Tabs[1].Visible = true;
            tabFacturas.Tabs[2].Visible = false;
            chkConfirmaSolicitud.Visible = true;
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridConceptosDisp();
        }

        protected void grvConceptosDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjConceptoDet.ClaveConcepto = grvConceptosDisp.SelectedRow.Cells[0].Text;
            ObjConceptoDet.Descripcion = grvConceptosDisp.SelectedRow.Cells[1].Text;
            if (Session["Conceptos"] == null)
            {
                ListDetConcepto = new List<DetConcepto>();
                ListDetConcepto.Add(ObjConceptoDet);
            }
            else
            {
                ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                ListDetConcepto.Add(ObjConceptoDet);
            }

            Session["Conceptos"] = ListDetConcepto;
            CargarGridConceptosAsig(ListDetConcepto);

        }

        protected void grvConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvConceptos.PageSize * grvConceptos.PageIndex;
                fila = pagina + fila;
                List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                ListDetConcepto.RemoveAt(fila);
                Session["Conceptos"] = ListDetConcepto;
                CargarGridConceptosAsig(ListDetConcepto);
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void txtIVA_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Collapse3", "Collapse3();", true);
            txtTotalConvenio.Text = Convert.ToString(Convert.ToDouble(txtImporteConvenio.Text) + Convert.ToDouble(txtIVAConvenio.Text));
        }

        protected void btnVoucher_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileVoucher.HasFile)
                {
                    int fileSize = fileVoucher.PostedFile.ContentLength;
                    fullPath = Path.Combine(Server.MapPath("../DoctosFacturasTemp/"), fileVoucher.FileName);
                    fileVoucher.SaveAs(fullPath);
                    lblArchivoVoucher.NavigateUrl = "../DoctosFacturasTemp/" + fileVoucher.FileName;
                    lblArchivoVoucher.Text = fileVoucher.FileName;
                    lblArchivoVoucher.ToolTip = fullPath;
                    linkBttnEliminarVoucher.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }


        }

        protected void bttnAgregarREP_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileREP.HasFile)
                {
                    int fileSize = fileREP.PostedFile.ContentLength;
                    fullPath = Path.Combine(Server.MapPath("../DoctosFacturasTemp/"), fileREP.FileName);
                    fileREP.SaveAs(fullPath);
                    lblArchivoREP.NavigateUrl = "../DoctosFacturasTemp/" + fileREP.FileName;
                    lblArchivoREP.Text = fileREP.FileName;
                    lblArchivoREP.ToolTip = fullPath;
                    linkBttnEliminarREP.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void linkBttnEliminarREP_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(lblArchivoREP.ToolTip);
                lblArchivoREP.NavigateUrl = string.Empty;
                lblArchivoREP.Text = string.Empty;
                lblArchivoREP.ToolTip = string.Empty;
                lblArchivoREP.Visible = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void linkBttnEliminarVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(lblArchivoVoucher.ToolTip);
                lblArchivoVoucher.NavigateUrl = string.Empty;
                lblArchivoVoucher.Text = string.Empty;
                lblArchivoVoucher.ToolTip = string.Empty;
                linkBttnEliminarVoucher.Visible = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }



        protected void grdDatosFactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            ObjCjaFactura.IdCajaFact = Convert.ToInt32(grdDatosFactura.Rows[fila].Cells[0].Text);
            CNCjaFactura.FacturaCajaEfectivoBorrar(ObjCjaFactura, ref Verificador);
            if (Verificador == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El registro fue eliminado correctamente.');", true);
                CargarGridEfectivo();
            }
            else
            {
                string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void grvConceptosDisp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConceptosDisp.PageIndex = 0;
            grvConceptosDisp.PageIndex = e.NewPageIndex;
            CargarGridConceptosDisp();
        }

        protected void imgBttnRecibo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + ");", true);
            string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == 0)
                ddlTipo_SelectedIndexChanged(null, null);
        }

        protected void linkBttnEliminarOficio_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(lblArchivoOficio.ToolTip);
                lblArchivoOficio.NavigateUrl = string.Empty;
                lblArchivoOficio.Text = string.Empty;
                lblArchivoOficio.ToolTip = string.Empty;
                linkBttnEliminarOficio.Visible = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }

        }





        protected void btnOficio_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileOficio.HasFile)
                {
                    int fileSize = fileOficio.PostedFile.ContentLength;
                    fullPath = Path.Combine(Server.MapPath("../DoctosFacturasTemp/"), fileOficio.FileName);
                    //if (fileSize > 52000)
                    //{
                    //    System.Drawing.Image ImageDraw = System.Drawing.Image.FromFile(fullPath);
                    //    ImageDraw = this.Redimensionar(ImageDraw, 30, 30);
                    //    fullPath = "../Facturas/IMAGES/" + fileOficio.FileName;
                    //    ImageDraw.Save(fullPath);
                    //    ImageDraw.Dispose();
                    //}
                    //else
                    //    fileOficio.SaveAs(fullPath);

                    fileOficio.SaveAs(fullPath);
                    lblArchivoOficio.NavigateUrl = "../DoctosFacturasTemp/" + fileOficio.FileName;
                    lblArchivoOficio.Text = fileOficio.FileName;
                    lblArchivoOficio.ToolTip = fullPath;
                    linkBttnEliminarOficio.Visible = true;

                    collapse1.Attributes["class"] = "collapse multi-collapse show";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Collapse1", "Collapse1();", true);
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }

        }

        protected void btnConvenio_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileConvenio.HasFile)
                {
                    int fileSize = fileConvenio.PostedFile.ContentLength;
                    fullPath = Path.Combine(Server.MapPath("../DoctosFacturasTemp/"), fileConvenio.FileName);
                    fileConvenio.SaveAs(fullPath);
                    lblArchivoConvenio.NavigateUrl = "../DoctosFacturasTemp/" + fileConvenio.FileName;
                    lblArchivoConvenio.Text = fileConvenio.FileName;
                    lblArchivoConvenio.ToolTip = fullPath;
                    linkBttnEliminarConvenio.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }


        }

        protected void linkBttnEliminarConvenio_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete(lblArchivoConvenio.ToolTip);
                lblArchivoConvenio.NavigateUrl = string.Empty;
                lblArchivoConvenio.Text = string.Empty;
                lblArchivoConvenio.ToolTip = string.Empty;
                linkBttnEliminarConvenio.Visible = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }


        }

        protected void imgBttnPdf_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;

            string ruta = "../ArchivosFacturas/" + grdDatosFactura.SelectedRow.Cells[22].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void bttnVerFactura_Click(object sender, EventArgs e)
        {
            Button Bttn = (Button)(sender);
            GridViewRow row = (GridViewRow)Bttn.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;

            DropDownList DDL = (DropDownList)(row.Cells[20].FindControl("ddlFacturas"));
            string ruta = "../ArchivosFacturas/" + DDL.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void rdoBttnReceptorTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBttnReceptorTipoPersona.SelectedValue == "F")
                txtReceptor_Rfc.MaxLength = 13;
            else
                txtReceptor_Rfc.MaxLength = 12;
        }

        protected void ValidaLongitudRFC(object sender, ServerValidateEventArgs e)
        {
            if (e.Value.Length == 8)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        protected void txtImporteConvenio_TextChanged(object sender, EventArgs e)
        {
            double Total = 0;
            double Iva = 0;

            Iva = (Convert.ToDouble(txtImporteConvenio.Text) * .16);
            txtIVAConvenio.Text = Convert.ToString(Iva);
            Total = Convert.ToDouble(txtImporteConvenio.Text) + (Convert.ToDouble(txtImporteConvenio.Text) * .16);
            txtTotalConvenio.Text = Convert.ToString(Total);

        }

        protected void ConceptosAsignados(object source, ServerValidateEventArgs args)
        {
            if (grvConceptos.Rows.Count >= 1)
                args.IsValid = true;
            else
                args.IsValid = false;

        }

        protected void bttnDoctos_Click(object sender, EventArgs e)
        {

            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                CargarGridDoctos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupBitacora", "$('#modalFacturas').modal('show')", true);
                //modalDoctos.Show();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }




        }

        protected void bttnAdd_Click(object sender, EventArgs e)
        {
            chkRechazado.Visible = false;
            rowObservaciones.Visible = false;
            bttnVerRecibo.Visible = false;
            ddlDependencia2.SelectedValue = ddlDependencia.SelectedValue;
            ddlDependencia2.Enabled = true;
            //lblDependencia.Text = ddlDependencia.SelectedItem.Text;

            if (ddlTipo.SelectedValue == "T")
            {

                tabFacturas.Tabs[1].Visible = true;
                if (ddlStatus.SelectedValue == "C")
                    tabFacturas.Tabs[2].Visible = false;

                LimipiarCampos();
                SesionUsu.Editar = 3;
            }
            else
            {
                if (ddlStatus.SelectedValue == "C")
                    tabFacturas.Tabs[2].Visible = false;


                LimipiarCampos();
                SesionUsu.Editar = 3;
            }

            grdArchivos.DataSource = null;
            grdArchivos.DataBind();
            Session["Archivos"] = null;
            mltViewFacturas.ActiveViewIndex = 2;
        }

        protected void linkBttnBuscarRFC_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ObjCjaFactura.FACT_RECEPTOR_RFC = txtReceptor_Rfc.Text.ToUpper();
                CNCjaFactura.ObtenerDatosFiscales(ref ObjCjaFactura, ref Verificador);
                if (Verificador == "0")
                {
                    txtReceptor_Nombre.Text = ObjCjaFactura.FACT_NOMBRE;
                    txtReceptor_Colonia.Text = ObjCjaFactura.FACT_RECEPTOR_COLONIA;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                mltViewTipo.ActiveViewIndex = 0;
                if (ddlTipo.SelectedValue == "R")
                    CargarGrid();
                else
                    CargarGridEfectivo();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void linkBttnVerRecibo_Click(object sender, EventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
        protected void bttnVerRecibo_Click(object sender, EventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void linkBttnCorreo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            txtCorreo.Text = grdDatosFactura.SelectedRow.Cells[15].Text;
            modalCorreo.Show();
        }

        protected void linkBttnRecibo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + ");", true);
            string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }


        protected void grvConceptosDisp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void linkBttnAgregarReg_Click(object sender, EventArgs e)
        {
            chkRechazado.Visible = false;
            rowObservaciones.Visible = false;
            bttnVerRecibo.Visible = false;
            ddlDependencia2.SelectedValue = ddlDependencia.SelectedValue;
            ddlDependencia2.Enabled = true;
            LimipiarCampos();
            SesionUsu.Editar = 3;
            Status();
            rowSolicitarFactura.Visible = true;
            grdArchivos.DataSource = null;
            grdArchivos.DataBind();
            Session["Archivos"] = null;
            mltViewFacturas.ActiveViewIndex = 2;
        }

        protected void chkIvaDes_CheckedChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Collapse1", "Collapse1();", true);
            if (chkIvaDes.Checked == true)
                rowIvaDeposito.Visible = true;
            else
            {
                txtIvaDeposito.Text = string.Empty;
                txtTotalDeposito.Text = string.Empty;
                rowIvaDeposito.Visible = false;
            }
        }

        protected void linkBttnBitacora_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupBitacora", "$('#modalBitacora').modal('show')", true);
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFacturaEfect.SelectedIndex = row.RowIndex;
            CargarGridHist();
        }

        protected void linkBttnBitacoraRef_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupBitacora", "$('#modalBitacora').modal('show')", true);
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            CargarGridHistRef();
        }

        protected void grdDatosFacturaEfect_SelectedIndexChanged(object sender, EventArgs e)
        {
            bttnVerRecibo.Visible = false;
            ObjCjaFactura.ItsOk = false;
            txtFecha_Fact_Cja.Text = string.Empty;
            txtFolio_Fact_Cja.Text = string.Empty;
            chkConfirmaSolicitud.Checked = false;
            //ddlDependencia.Enabled = false;
            LimipiarCampos();
            rowSolicitarFactura.Visible = false;
            tabFacturas.Tabs[1].Visible = false;

            Status();

            try
            {

                ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text);
                CNFacturacion.FacturaEfectConsultaDatosFiscales(ref ObjFacturacion, ref Verificador);

                if (Verificador == "0")
                {
                    ddlDependencia2.Enabled = false;
                    ddlDependencia2.SelectedValue = ObjFacturacion.DEPENDENCIA;
                    txtReceptor_Rfc.Text = ObjFacturacion.RECEPTOR_RFC;
                    rdoBttnReceptorTipoPersona.SelectedValue = ObjFacturacion.RECEPTOR_TIPO_PERS;
                    txtReceptor_Nombre.Text = ObjFacturacion.RECEPTOR_NOMBRE;
                    txtReceptor_Domicilio.Text = ObjFacturacion.RECEPTOR_DOMICILIO;
                    txtReceptor_Colonia.Text = ObjFacturacion.RECEPTOR_COLONIA;
                    txtReceptor_NumInt.Text = ObjFacturacion.NUMERO_INTERIOR;
                    txtReceptor_NumExt.Text = ObjFacturacion.NUMERO_EXTERIOR;
                    txtReceptor_CP.Text = ObjFacturacion.RECEPTOR_CP;
                    try
                    {
                        ddlReceptor_Estado.SelectedValue = ObjFacturacion.RECEPTOR_ESTADO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_Estado.SelectedValue = "8";
                        ObjFacturacion.RECEPTOR_MUNICIPIO = "213";
                    }
                    ddlEstado_Fiscal_SelectedIndexChanged(null, null);

                    try
                    {
                        ddlReceptor_Municipio.SelectedValue = ObjFacturacion.RECEPTOR_MUNICIPIO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_Municipio.SelectedIndex = 0;
                    }

                    try
                    {
                        ddlReceptor_MetodoPago.SelectedValue = ObjFacturacion.RECEPTOR_METODO_PAGO;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_MetodoPago.SelectedIndex = 0;
                    }

                    try
                    {
                        ddlReceptor_MetodoPagoFA.SelectedValue = ObjFacturacion.RECEPTOR_METODO_PAGO_FA;
                    }
                    catch (Exception)
                    {
                        ddlReceptor_MetodoPagoFA.SelectedIndex = 0;
                    }

                    ddlForma_Pago.SelectedValue = ObjFacturacion.RECEPTOR_FORMA_PAGO;
                    ddlCFDI.SelectedValue = ObjFacturacion.CFDI;
                    txtReceptor_Telefono.Text = ObjFacturacion.RECEPTOR_TELEFONO;
                    txtReceptor_Correo.Text = ObjFacturacion.RECEPTOR_CORREO;
                    txtDescConcepto.Text = ObjFacturacion.OBSERVACIONES;
                    txtObservaciones.Text = ObjFacturacion.RECEPTOR_STATUS_NOTAS;
                    chkSolicitar.Checked = ObjFacturacion.CONFIRMADO == "S" ? true : false;
                    rowSolicitarFactura.Visible = true;
                    rowObservaciones.Visible = false;
                    txtObservaciones.Enabled = true;
                    btnGuardarEditar.ValidationGroup = "DatosFiscales";
                    if (ddlStatus.SelectedValue == "C" && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "S")
                        chkRechazado.Visible = false;
                    else if (ddlStatus.SelectedValue == "C" && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "R")
                    {
                        chkConfirmaSolicitud.Visible = true;
                        rowSolicitarFactura.Visible = false;
                        rowObservaciones.Visible = true;
                        txtObservaciones.Enabled = false;
                    }
                    else if (ddlStatus.SelectedValue == "S" && grdDatosFacturaEfect.SelectedRow.Cells[24].Text == "S")
                    {
                        btnGuardarEditar.ValidationGroup = string.Empty;
                        chkRechazado.Visible = true;
                        btnGuardarEditar.ValidationGroup = "DatosFiscalesCaja";
                    }
                    else
                        chkRechazado.Visible = false;

                    lblConceptosFac.Text = ObjFacturacion.CONCEPTOS;


                    //rowObservaciones.Visible = true;
                    //txtObservaciones.Enabled = true;
                    //rowSolicitarFactura.Visible = ddlStatus.SelectedValue == "C" ? true : false;
                    //rowObservaciones.Visible = false;


                    SesionUsu.Editar = 2;

                    //Voucher
                    txtFolio.Text = ObjFacturacion.FOLIO_PAGO;
                    txtFecha.Text = ObjFacturacion.FECHA_PAGO;
                    txtImporteDeposito.Text = Convert.ToString(ObjFacturacion.IMPORTE_PAGO);
                    txtIvaDeposito.Text = Convert.ToString(ObjFacturacion.IVA_PAGO);
                    txtTotalDeposito.Text = Convert.ToString(ObjFacturacion.TOTAL_PAGO);
                    txtFolioFactPagada.Text = Convert.ToString(ObjFacturacion.FOLIO_PAGADO);
                    ddlReceptor_MetodoPagoFA.SelectedValue = ObjFacturacion.RECEPTOR_METODO_PAGO_FA;
                    if (ObjFacturacion.IVA_PAGO != 0 && ObjFacturacion.TOTAL_PAGO != 0)
                    {
                        chkIvaDes.Checked = true;
                        chkIvaDes_CheckedChanged(null, null);
                    }
                    //Oficio
                    txtNumOficio.Text = ObjFacturacion.NUM_OFICIO;
                    txtFechaOficio.Text = ObjFacturacion.FECHA_OFICIO;

                    //Convenio
                    txtImporteConvenio.Text = Convert.ToString(ObjFacturacion.IMPORTE_CONVENIO);
                    txtIVAConvenio.Text = Convert.ToString(ObjFacturacion.IVA_CONVENIO);
                    txtTotalConvenio.Text = Convert.ToString(ObjFacturacion.TOTAL_CONVENIO);


                    //REP
                    txtFechaRep.Text= ObjFacturacion.FECHA_REP;
                    txtNumREP.Text = ObjFacturacion.FOLIO_REP;

                    //Doctos
                    DatosFacturaEfectivo(ObjFacturacion);


                    //Conceptos
                    List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                    CNFacturacion.FacturaDetConsultar(ref ListDetConcepto, Convert.ToInt32(grdDatosFacturaEfect.SelectedRow.Cells[0].Text), ref Verificador);
                    if (Verificador == "0")
                    {
                        Session["Conceptos"] = ListDetConcepto;
                        CargarGridConceptosAsig(ListDetConcepto);
                    }
                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
                    }

                    //Facturas
                    ObjCjaFactura.ID_FACT = Convert.ToString(grdDatosFacturaEfect.SelectedRow.Cells[0].Text);
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(grdDatosFacturaEfect.SelectedRow.Cells[6].Text);
                    List<CajaFactura> ListArch = new List<CajaFactura>();
                    CNCjaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Convert.ToString(grdDatosFacturaEfect.SelectedRow.Cells[27].Text), ref ListArch);
                    DataTable dt = new DataTable();
                    grdArchivos.DataSource = dt;
                    grdArchivos.DataSource = ListArch;
                    grdArchivos.DataBind();
                    Session["Archivos"] = ListArch;




                    mltViewFacturas.ActiveViewIndex = 2;
                    //tabFacturas.Tabs[1].Visible = false;
                }

                else
                {
                    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error en la recuperación de los datos.')", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;

            }

        }

        protected void linkBttnFactura_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFacturaEfect.SelectedIndex = row.RowIndex;
            CargarGridDoctosEfect();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupBitacora", "$('#modalFacturas').modal('show')", true);
        }
        protected void linkBttnFacturaRef_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            CargarGridDoctosEfect();
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupBitacora", "$('#modalFacturas').modal('show')", true);
        }
        protected void grdDatosFacturaEfect_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            ObjFacturacion.ID_FACT = Convert.ToInt32(grdDatosFacturaEfect.Rows[fila].Cells[0].Text);
            CNFacturacion.FacturaSolBorrar(ObjFacturacion, ref Verificador);
            if (Verificador == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El registro fue eliminado correctamente.');", true);
                CargarGridEfectivo();
            }
            else
            {
                string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }


        }
    }
}