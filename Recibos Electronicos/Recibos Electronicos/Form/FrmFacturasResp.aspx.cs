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


namespace Recibos_Electronicos.Form
{
    public partial class FrmFacturasResp : System.Web.UI.Page
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
        CajaFactura ObjCjaFactura = new CajaFactura();        
        Factura ObjFactura = new Factura();
        ConceptoPago ObjConcepto = new ConceptoPago();
        DetConcepto ObjConceptoDet = new DetConcepto();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CN_DetFacturaEfectivo CNDetFacturaEfec = new CN_DetFacturaEfectivo();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        List<CajaFactura> ListArch = new List<CajaFactura>();
        List<Factura> ListConfirma = new List<Factura>();
        List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
        ArrayList FactConfirmados = new ArrayList();
        
        //CajaFactura cjaFact = new CajaFactura();
        public Boolean BandFact = false;
        
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();
            
            
        }

        #region <Botones y Eventos>

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            
        }
        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjCjaFactura.ItsOk = false;
            txtFecha_Fact_Cja.Text=string.Empty;
            txtFolio_Fact_Cja.Text = string.Empty;
            chkConfirmaSolicitud.Checked = false;
            ddlDependencia.Enabled = false;
            LimipiarCampos();
            //grdArchivos.DataSource = null;
            //grdArchivos.DataBind();
            //Session["Archivos"] = null;

            try
            {
                if (grdDatosFactura.SelectedRow.Cells[21].Text == "R")
                {
                    ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    lblDependencia.Visible = false;
                    ddlDependencia.Visible = false;
                    CNFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);
                }
                else
                {
                    ObjFactura.ID_FACT = grdDatosFactura.SelectedRow.Cells[0].Text;
                    CNFactura.FacturaEfectConsultaDatosFiscales(ref ObjFactura, ref Verificador);
                }


                if (Verificador == "0")
                {

                    rdoBttnReceptorTipoPersona.SelectedValue = ObjFactura.FACT_RECEPTOR_TIPO_PERS;
                    txtReceptor_Nombre.Text = ObjFactura.FACT_NOMBRE;
                    txtReceptor_Rfc.Text = ObjFactura.FACT_RECEPTOR_RFC;
                    txtReceptor_Domicilio.Text = ObjFactura.FACT_RECEPTOR_DOMICILIO;
                    txtReceptor_Colonia.Text = ObjFactura.FACT_RECEPTOR_COLONIA;
                    txtReceptor_CP.Text = ObjFactura.FACT_RECEPTOR_CP;
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

                    ddlReceptor_MetodoPago.SelectedValue = ObjFactura.FACT_RECEPTOR_METODO_PAGO;
                    txtReceptor_Telefono.Text = ObjFactura.FACT_RECEPTOR_TELEFONO;
                    txtReceptor_Correo.Text = ObjFactura.FACT_RECEPTOR_CORREO;
                    chkRechazado.Visible = (grdDatosFactura.SelectedRow.Cells[17].Text == "S") ? true : false;

                    if (ObjFactura.FACT_RECEPTOR_STATUS == "R")
                    {
                        chkConfirmaSolicitud.Visible = true;
                        chkRechazado.Checked = true;
                        //----
                        //btnGuardarEditar.ValidationGroup = "DatosFiscales";
                        txtObservaciones.Visible = true;
                        //---
                        //chkRechazado_CheckedChanged(null, null);
                        lblRechazado.Visible = true;
                        txtObservaciones.Text = ObjFactura.FACT_RECEPTOR_STATUS_NOTAS;
                        txtObservaciones.Enabled = false;                        
                        valCheck.ValidationGroup = "DatosFiscales";

                    }
                    else
                    {
                        lblRechazado.Visible = false;
                        chkRechazado.Checked = false;
                        if(ddlStatus.SelectedValue=="S")
                        {
                            btnGuardarEditar.ValidationGroup = string.Empty;
                            valLongitudRFC0.ValidationGroup = string.Empty; 
                            validationSumGuardar.ValidationGroup = string.Empty;
                        }
                        else
                        {
                            btnGuardarEditar.ValidationGroup = "RFC"; //string.Empty;
                            valLongitudRFC0.ValidationGroup = "RFC";
                            validationSumGuardar.ValidationGroup = "RFC";
                        }


                        txtObservaciones.Visible = true;                        
                        txtObservaciones.Text = string.Empty;
                        txtObservaciones.Enabled = true;
                        chkConfirmaSolicitud.Visible = false;
                        valCheck.ValidationGroup = string.Empty;
                    }



                    if (grdDatosFactura.SelectedRow.Cells[21].Text == "T")
                    {
                        ddlDependencia.SelectedValue= ObjFactura.FACT_DEPENDENCIA;
                        txtFolio.Text = ObjFactura.FACT_FOLIO;
                        txtFecha.Text = ObjFactura.FACT_FECHA_FACTURA;
                        txtImporte.Text = ObjFactura.FACT_SUBTOTAL;
                        txtImporteConvenio.Text =Convert.ToString(ObjFactura.FACT_IMPORTE_CONVENIO);
                        txtIVA.Text = ObjFactura.FACT_IMPUESTO_TASA;
                        txtTotal.Text = ObjFactura.FACT_TOTAL;
                        txtNumOficio.Text = ObjFactura.OFICIO;
                        txtObservacionesConvenio.Text = ObjFactura.FACT_NOTAS;
                        tabFacturas.Tabs[1].Visible = true;
                        tabFacturas.Tabs[2].Visible =(ddlStatus.SelectedValue == "C")? false : true;
                        valFolio.ValidationGroup = "DatosFiscales";
                        valFecha.ValidationGroup = "DatosFiscales";
                        valImporte.ValidationGroup = "DatosFiscales";
                        valIva.ValidationGroup = "DatosFiscales";
                        valTotal.ValidationGroup = "DatosFiscales";
                        DatosFacturaEfectivo();
                        SesionUsu.Editar = 2;
                    }
                    else
                    {
                        tabFacturas.Tabs[1].Visible = false;
                        valFolio.ValidationGroup = string.Empty;
                        valFecha.ValidationGroup = string.Empty;
                        valImporte.ValidationGroup = string.Empty;
                        valIva.ValidationGroup = string.Empty;
                        valTotal.ValidationGroup = string.Empty;
                        SesionUsu.Editar = 1;
                    }

                    ObjCjaFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(grdDatosFactura.SelectedRow.Cells[1].Text);
                    List<CajaFactura> ListArch = new List<CajaFactura>();
                    CNCjaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Convert.ToString(grdDatosFactura.SelectedRow.Cells[21].Text), ref ListArch);
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
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                MsjError = MsjError.Replace("\n", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); 
            }
        }
        
        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdDatosFactura.PageIndex = 0;
                grdDatosFactura.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); 
            }
        }
        protected void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }       
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 0;
            //pnlContenedor.Visible = true;
            //pnlEditar.Visible = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

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
            lblDependencia.Visible = true;
            ddlDependencia.Visible = true;
            btnGuardarEditar.ValidationGroup = "DatosFiscales";
            valLongitudRFC0.ValidationGroup = "DatosFiscales";
            validationSumGuardar.ValidationGroup = "DatosFiscales";

        }
        protected void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            try
            {

                //if (chkRechazado.Visible == true && chkRechazado.Checked == false)
                //{
                //    Page.Validate("DatosFiscales");
                //    if (Page.IsValid)
                //        Guardar();
                //}
                //else                
                //    Guardar();
                if (Page.IsValid)
                        Guardar();

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }        
        #endregion

        #region <Funciones>
        protected void Guardar()
        {
            bool ExisteConcepto800 = VerificaConceptos();
            if (ExisteConcepto800 == false || chkRechazado.Checked == true)
            {
                ObjFactura.FACT_RECEPTOR_RFC = txtReceptor_Rfc.Text;
                ObjFactura.FACT_NOMBRE = txtReceptor_Nombre.Text;
                ObjFactura.FACT_RECEPTOR_DOMICILIO = txtReceptor_Domicilio.Text;
                ObjFactura.FACT_RECEPTOR_COLONIA = txtReceptor_Colonia.Text;
                ObjFactura.FACT_RECEPTOR_CP = txtReceptor_CP.Text;
                ObjFactura.FACT_RECEPTOR_ESTADO = ddlReceptor_Estado.SelectedValue;
                ObjFactura.FACT_RECEPTOR_MUNICIPIO = ddlReceptor_Municipio.SelectedValue;
                ObjFactura.FACT_RECEPTOR_METODO_PAGO = ddlReceptor_MetodoPago.SelectedValue;
                ObjFactura.FACT_RECEPTOR_TELEFONO = txtReceptor_Telefono.Text;
                ObjFactura.FACT_RECEPTOR_CORREO = txtReceptor_Correo.Text;
                ObjFactura.FACT_RECEPTOR_TIPO_PERS = rdoBttnReceptorTipoPersona.SelectedValue;
                ObjFactura.FACT_RECEPTOR_STATUS = (chkRechazado.Checked == true) ? (chkConfirmaSolicitud.Checked == true) ? string.Empty : "R" : string.Empty;
                ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = (chkRechazado.Checked == true) ? txtObservaciones.Text : string.Empty;
                ObjFactura.FACT_CONFIRMADO = (chkRechazado.Checked == true) ? (chkConfirmaSolicitud.Checked == true) ? "S" : string.Empty : string.Empty;
                //ObjFactura.FACT_TIPO = (SesionUsu.Editar!=3)?Convert.ToString(grdDatosFactura.SelectedRow.Cells[19].Text):"T";
                ObjFactura.FACT_TIPO = ddlTipo.SelectedValue;
                ObjFactura.OFICIO = txtNumOficio.Text;
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;


                if (SesionUsu.Editar == 1)
                {
                    ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    CNFactura.FacturaEditarDatosCaja(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                }
                else
                {
                    ObjFactura.FACT_DEPENDENCIA = ddlDependencia.SelectedValue;
                    ObjFactura.FACT_FOLIO = txtFolio.Text;
                    ObjFactura.FACT_SUBTOTAL = txtImporte.Text;
                    ObjFactura.FACT_IMPORTE_CONVENIO = (txtImporteConvenio.Text == string.Empty) ? 0 : Convert.ToDouble(txtImporteConvenio.Text);
                    ObjFactura.FACT_IMPUESTO_TASA = txtIVA.Text;
                    ObjFactura.FACT_TOTAL = txtTotal.Text;
                    ObjFactura.FACT_FECHA_FACTURA = txtFecha.Text;
                    ObjFactura.EXTENSION_ADJUNTO = string.Empty;
                    ObjFactura.FACT_NOTAS = txtObservacionesConvenio.Text;
                    if (lblArchivoVoucher.NavigateUrl != string.Empty)
                        ObjFactura.RUTA_ADJUNTO = lblArchivoVoucher.Text;
                    else
                        ObjFactura.RUTA_ADJUNTO = string.Empty;

                    if (lblArchivoOficio.NavigateUrl != string.Empty)
                        ObjFactura.RUTA_ADJUNTO_OFICIO = lblArchivoOficio.Text;
                    else
                        ObjFactura.RUTA_ADJUNTO_OFICIO = string.Empty;

                    if (lblArchivoConvenio.NavigateUrl != string.Empty)
                        ObjFactura.RUTA_ADJUNTO_CONVENIO = lblArchivoConvenio.Text;
                    else
                        ObjFactura.RUTA_ADJUNTO_CONVENIO = string.Empty;


                    if (SesionUsu.Editar == 2)
                    {
                        ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                        CNFactura.FacturaEditarDatosEfect(ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);
                    }
                    else
                        CNFactura.FacturaAgregarDatosCaja(ref ObjFactura, SesionUsu.Usu_Nombre, ref Verificador);

                    if (Verificador == "0")
                    {
                        if (lblArchivoVoucher.NavigateUrl != string.Empty)
                        {
                            string OrigenArchivo = Path.Combine(Server.MapPath("~/DoctosFacturasTemp"), lblArchivoVoucher.Text);
                            string DestinoArchivo;
                            if (SesionUsu.Editar == 3)
                                DestinoArchivo = ObjFactura.ID_FACT + "-V-" + lblArchivoVoucher.Text;
                            else
                                DestinoArchivo = ObjFactura.ID_FACT + "-V-" + lblArchivoVoucher.Text.Replace(ObjFactura.ID_FACT + "-V-", string.Empty);

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
                                DestinoArchivo = ObjFactura.ID_FACT + "-O-" + lblArchivoOficio.Text;
                            else
                                DestinoArchivo = ObjFactura.ID_FACT + "-O-" + lblArchivoOficio.Text.Replace(ObjFactura.ID_FACT + "-O-", string.Empty);

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
                                DestinoArchivo = ObjFactura.ID_FACT + "-C-" + lblArchivoConvenio.Text;
                            else
                                DestinoArchivo = ObjFactura.ID_FACT + "-C-" + lblArchivoConvenio.Text.Replace(ObjFactura.ID_FACT + "-C-", string.Empty);

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
                                        CNDetFacturaEfec.DetFacturaEfecInsertar(ListDetConcepto, Convert.ToInt32(ObjFactura.ID_FACT), ref Verificador);
                                        break;
                                    case 2:
                                        CNDetFacturaEfec.DetFacturaEfecEditar(ListDetConcepto, Convert.ToInt32(ObjFactura.ID_FACT), ref Verificador);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'ERROR..');", true);
                    }
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
                            lblDependencia.Visible = true;
                            ddlDependencia.Visible = true;
                            //ddlDependencia.SelectedIndex = 0;
                            ddlStatus_SelectedIndexChanged(null, null);
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
            txtFecha_Factura_Ini.Text = "01" + System.DateTime.Now.ToString("/MM/yyyy");
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");     
                        
            Usur.Usu_Nombre=SesionUsu.Usu_Nombre;
            Usur.Usu_IdModulo = 15355;
            CargarCombos();
            imgBttnBuscar_Click(null, null);
        }
        protected void Tipo()
        {
            try
            {
                switch (ddlTipo.SelectedValue)
                {
                    case "T":
                        rdoStatusConfirmados.Items[0].Enabled = false;
                        //lblTitulo1.Text = "DEPÓSITOS EN EFECTIVO / TRANSFERENCIAS";
                        mltViewTipo.ActiveViewIndex = 0;
                        CargarGridEfectivo();                        
                        break;
                    case "R":
                        rdoStatusConfirmados.Items[0].Enabled = true;
                        //lblTitulo1.Text = "REFERENCIADO";
                        mltViewTipo.ActiveViewIndex = 0;
                        CargarGrid();                        
                        break;
                    case "A":
                        rdoStatusConfirmados.Items[0].Enabled = false;
                        //lblTitulo1.Text = "FACTURAS ANTICIPADAS";
                        mltViewTipo.ActiveViewIndex = 0;
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
            if (grvConceptos.Rows.Count >= 1 && ddlTipo.SelectedValue=="A")
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
        protected void CargarCombos()
        {
            try
            {
                if (Usur.Usu_TipoPermiso == "C")
                    CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_UR_Factura", ref ddlDependencia);
                else
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Niveles_Caja", ref ddlNivel, "INGRESOS");
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Status_Facturas", ref ddlStatus, "p_usuario", "p_tipo_factura", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue);
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
            Int32[] CeldasFacturados = { 0, 6, 7, 8, 10, 11, 13, 14, 16, 17, 18, 20, 21  };
            Int32[] CeldasSolicitados = { 0, 7, 8, 10, 11, 13, 14, 15, 16, 17, 18, 20, 21, 22 };
            Int32[] CeldasPorConfirmar = { 0, 6, 7, 8, 10, 13, 14, 15, 16, 17, 18, 21, 22 };


            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();

                if (grdDatosFactura.Rows.Count > 0)
                {
                    switch (ddlStatus.SelectedValue)
                    {
                        case "F":
                            CNComun.HideColumns(grdDatosFactura, CeldasFacturados);
                            break;
                        case "C":
                            //grdDatosFactura.Columns[8].HeaderText = "Fecha Factura";
                            //grdDatosFactura.Columns[9].HeaderText = "Fecha de Pago";
                            grdDatosFactura.HeaderRow.Cells[8].Text = "Fecha Factura";
                            grdDatosFactura.HeaderRow.Cells[9].Text = "Fecha de Pago";
                            CNComun.HideColumns(grdDatosFactura, CeldasPorConfirmar);
                            break;
                        case "S":
                            CNComun.HideColumns(grdDatosFactura, CeldasSolicitados);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridEfectivo()
        {


            Int32[] CeldasFacturados = { 0, 2, 4, 6, 7, 8, 10, 11, 13, 14, 16, 17, 18, 19, 20, 21 };
            Int32[] CeldasSolicitados = { 0, 2, 4, 7, 10, 11, 13, 15, 16, 17, 18, 19, 21, 22 };
            Int32[] CeldasPorConfirmar = { 0, 2, 3, 6, 10, 14, 15, 16, 17, 18, 19, 21, 22 };

            Int32[] CeldasFacturados_Ant = { 0, 1, 2, 3, 4, 7, 10, 11, 13, 14, 16, 17, 18, 19, 20, 21 };
            Int32[] CeldasSolicitados_Ant = { 0, 1, 2, 3, 4, 7, 10, 11, 13, 14, 15, 16, 17, 18, 19, 21, 22 };
            Int32[] CeldasPorConfirmar_Ant = { 0, 1, 2, 3, 4, 7, 9, 10, 14, 15, 16, 17, 18, 19, 21, 22 };


            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetListEfectivo();
                grdDatosFactura.DataBind();

                if (grdDatosFactura.Rows.Count > 0)
                {
                    switch (ddlStatus.SelectedValue)
                    {
                        case "F":
                            
                            CNComun.HideColumns(grdDatosFactura, (ddlTipo.SelectedValue=="T")?CeldasFacturados:CeldasFacturados_Ant);
                            break;
                        case "P":                            
                            CNComun.HideColumns(grdDatosFactura, (ddlTipo.SelectedValue == "T") ? CeldasFacturados : CeldasFacturados_Ant);
                            //grdDatosFactura.Columns[8].HeaderText = "Fecha Factura";
                            grdDatosFactura.HeaderRow.Cells[8].Text = "Fecha Factura";
                            grdDatosFactura.HeaderRow.Cells[9].Text = "Fecha de Pago";
                            break;
                        case "C":                            
                            CNComun.HideColumns(grdDatosFactura, (ddlTipo.SelectedValue == "T") ? CeldasPorConfirmar: CeldasPorConfirmar_Ant);
                            grdDatosFactura.HeaderRow.Cells[8].Text = "Fecha de Solicitud";
                            //grdDatosFactura.Columns[8].HeaderText = "Fecha de Solicitud";
                            break;
                        case "S":
                            CNComun.HideColumns(grdDatosFactura, (ddlTipo.SelectedValue == "T") ? CeldasSolicitados: CeldasSolicitados_Ant);
                            grdDatosFactura.HeaderRow.Cells[8].Text = "Fecha de Solicitud";
                            break;
                        default:
                            break;
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
                //if (grvConceptosDisp.Rows.Count > 0)                
                //    CNComun.HideColumns(grvConceptosDisp);
                
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
        //private void Columns(GridView grdView, Int32[] Celdas)
        //{
        //    for (int i = 0; i < Celdas.Length; i++)
        //    {
        //        //if (Celdas[i] == 0)
        //        //{
        //            grdView.HeaderRow.Cells[Convert.ToInt32(Celdas.GetValue(i))].Visible = false;
        //            foreach (GridViewRow row in grdView.Rows)
        //            {
        //                row.Cells[Convert.ToInt32(Celdas.GetValue(0))].Visible = false;
        //                if (row.Cells[Convert.ToInt32(Celdas.GetValue(8))].Text=="N")
        //                {
        //                    row.Cells[Convert.ToInt32(Celdas.GetValue(11))].Visible = false;
        //                }
        //            }                
        //    }
        //}
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
                CNCjaFactura.FacturaCajaConsultaGrid(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text , ddlStatus.SelectedValue.ToString(), rdoStatusConfirmados.SelectedValue, "T", ref List);
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
                ObjFactura.ID_FACT= Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNCjaFactura.FacturaDoctosConsultaGrid(ObjFactura, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<CajaFactura> GetListEfectivo()
        {
            try
            {
                List<CajaFactura> List = new List<CajaFactura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNCjaFactura.FacturaCajaEfectivoConsultaGrid(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ddlStatus.SelectedValue.ToString(), rdoStatusConfirmados.SelectedValue, ddlTipo.SelectedValue, ref List);
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
                ObjConcepto.Nivel = ddlNivel.SelectedValue;
                ObjConcepto.Status = 'A';
                CNConcepto.ConsultarConceptoPago(ref ObjConcepto, string.Empty, false, "S", "", ref List);
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
                //rdoBttnReceptorTipoPersona.SelectedValue = string.Empty;
                rdoBttnReceptorTipoPersona.SelectedValue = "F";
                rdoBttnReceptorTipoPersona_SelectedIndexChanged(null, null);
                txtReceptor_Rfc.Text = string.Empty;
                txtReceptor_Nombre.Text = string.Empty;
                txtReceptor_Domicilio.Text = string.Empty;
                txtReceptor_Colonia.Text = string.Empty;
                txtReceptor_CP.Text = string.Empty;
                ddlReceptor_Estado.SelectedValue = "8";
                ddlEstado_Fiscal_SelectedIndexChanged(null, null);
                ddlReceptor_Municipio.SelectedValue = "213";
                ddlReceptor_MetodoPago.SelectedValue = "0";
                txtReceptor_Telefono.Text = string.Empty;
                txtReceptor_Correo.Text = string.Empty;
                txtObservaciones.Text = string.Empty;
                chkRechazado.Checked = false;
                txtFolio.Text = string.Empty;
                txtFecha.Text = string.Empty;
                txtImporte.Text = string.Empty;
                txtImporteConvenio.Text = string.Empty;
                txtIVA.Text = string.Empty;
                txtTotal.Text = string.Empty;
                txtObservacionesConvenio.Text= string.Empty;
                ddlNivel.SelectedValue = "Z";
                chkConfirmaSolicitud.Visible = false;
                chkConfirmaSolicitud.Checked = false;
                valCheck.ValidationGroup = string.Empty;
                lblArchivoVoucher.NavigateUrl = string.Empty;
                lblArchivoVoucher.Text = string.Empty;
                linkBttnEliminarVoucher.Visible = false;

                lblArchivoOficio.NavigateUrl = string.Empty;
                lblArchivoOficio.Text = string.Empty;
                linkBttnEliminarOficio.Visible = false;

                lblArchivoConvenio.NavigateUrl = string.Empty;
                lblArchivoConvenio.Text = string.Empty;
                linkBttnEliminarConvenio.Visible = false;

                txtNumOficio.Text = string.Empty;
                ddlDependencia.Enabled = true;
                lblDependencia.Visible = true;
                ddlDependencia.Visible = true;
                chkRechazado.Visible = false;
                txtObservaciones.Visible = false;
                txtFecha_Fact_Cja.Enabled = true;
                txtFolio_Fact_Cja.Enabled = true;


                Session["Archivos"] = null;
                grdArchivos.DataSource = null;
                grdArchivos.DataBind();               
                Session["Conceptos"] = null;
                ddlNivel_SelectedIndexChanged(null, null);
                grvConceptos.DataSource = null;
                grvConceptos.DataBind();
                tabFacturas.ActiveTabIndex = 0;
                btnGuardarEditar.ValidationGroup = "DatosFiscales";
                valLongitudRFC0.ValidationGroup = "DatosFiscales";
                validationSumGuardar.ValidationGroup = "DatosFiscales";

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
        private void DatosFacturaEfectivo()
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


                List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                CNDetFacturaEfec.DetFacturaEfecConsultar(ref ListDetConcepto, Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text), ref Verificador);
                if (Verificador == "0")
                {
                    Session["Conceptos"] = ListDetConcepto;
                    CargarGridConceptosAsig(ListDetConcepto);
                    if (grvConceptos.Rows.Count >= 1)
                    {
                        ddlNivel.SelectedValue = ListDetConcepto[0].ClaveConcepto.Substring(0, 1);
                        ddlNivel_SelectedIndexChanged(null, null);
                    }
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
        private System.Drawing.Image Redimensionar(System.Drawing.Image image, int SizeHorizontalPercent, int SizeVerticalPercent)
        {
            //Obntenemos el ancho y el alto a partir del porcentaje de tamaño solicitado
            int anchoDestino = image.Width * SizeHorizontalPercent / 100;
            int altoDestino = image.Height * SizeVerticalPercent / 100;
            //Obtenemos la resolucion original 
            int resolucion = Convert.ToInt32(image.HorizontalResolution);
            return this.Redimensionar(image, anchoDestino, altoDestino, resolucion);
        }
        private System.Drawing.Image Redimensionar(System.Drawing.Image Imagen, int Ancho, int Alto, int resolucion)
        {
            //Bitmap sera donde trabajaremos los cambios
            using (Bitmap imagenBitmap = new Bitmap(Ancho, Alto, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(resolucion, resolucion);
                //Hacemos los cambios a ImagenBitmap usando a ImagenGraphics y la Imagen Original(Imagen)
                //ImagenBitmap se comporta como un objeto de referenciado
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Imagen.Width, Imagen.Height), GraphicsUnit.Pixel);
                    //todos los cambios hechos en imagenBitmap lo llevaremos un Image(Imagen) con nuevos datos a travez de un MemoryStream
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    Imagen = System.Drawing.Image.FromStream(imagenMemoryStream);
                }
            }
            return Imagen;
        }
        //private List<CajaFactura> GetListArchivos()
        //{
        //    try
        //    {

        //        List<CajaFactura> List = new List<CajaFactura>();
        //        Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
        //        CNCjaFactura.FacturaCajaConsultaGrid(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ddlStatus.SelectedValue.ToString(), ref List);
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


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

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgBttnNuevo.Visible = ((ddlTipo.SelectedValue == "T" || ddlTipo.SelectedValue == "A") && ddlStatus.SelectedValue=="C" ) ? true : false;
            //bttnNuevo.Visible = (ddlTipo.SelectedValue == "T" || ddlTipo.SelectedValue == "A") ? true : false;

            switch (ddlStatus.SelectedValue)
            {
                case "C":
                    pnlOpcConfirma.Visible = true;
                    hddnBandera.Value = "1";
                    tabFacturas.Tabs[2].Visible = false;
                    //bttnNuevo.Visible = (ddlTipo.SelectedValue == "T" || ddlTipo.SelectedValue == "A") ? true : false;
                    Accordion1.Panes[0].Visible = (ddlTipo.SelectedValue=="T") ? true : false;
                    Accordion1.Panes[1].Visible = (ddlTipo.SelectedValue == "T") ? false : true;
                    Accordion1.Panes[2].Visible = (ddlTipo.SelectedValue == "T") ? false : true;

                    break;
                case "S":
                    pnlOpcConfirma.Visible = false;
                    hddnBandera.Value = "0";
                    tabFacturas.Tabs[2].Visible = true;
                    //bttnNuevo.Visible = false;
                    break;
                case "F":
                    pnlOpcConfirma.Visible = false;
                    hddnBandera.Value = "0";
                    tabFacturas.Tabs[2].Visible = true;
                    Accordion1.Panes[0].Visible = (ddlTipo.SelectedValue == "A") ? true : false;
                    break;
                case "P":
                    pnlOpcConfirma.Visible = false;
                    hddnBandera.Value = "0";
                    tabFacturas.Tabs[2].Visible = true;
                    Accordion1.Panes[0].Visible = true;
                    break;
                default:
                    break;
            }

            Tipo();

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

        protected void btnConfirmar_Sol_Click(object sender, EventArgs e)
        {
             try
            {
                //ArrayList FactConfirmados = new ArrayList();
                if (Session["Facturas"] == null)
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No se registro ningún movimiento.');", true);
                else
                    ModalPopup.Show();                
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void chkConfirmado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hddnBandera.Value == "1")
                {

                    CheckBox chk = (CheckBox)sender;
                    GridViewRow gridViewRow = (GridViewRow)chk.NamingContainer;
                    int rowindex = gridViewRow.RowIndex;
                    int a = Convert.ToInt32(grdDatosFactura.Rows[rowindex].Cells[0].Text);
                    if (Session["Facturas"] == null)
                        FactConfirmados = new ArrayList();

                    else
                        FactConfirmados = (ArrayList)Session["Facturas"];


                    FactConfirmados.Add(rowindex);
                    Session["Facturas"] = FactConfirmados;

                }
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void rdoStatusConfirmados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo();
            //CargarGrid();           
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList FactConfirmados = new ArrayList();
                if (Session["Facturas"] != null)
                {
                    string confirmado_s = string.Empty;
                    string confirmado_n = string.Empty;
                    FactConfirmados = (ArrayList)Session["Facturas"];
                    foreach (int rowindex in FactConfirmados)
                    {
                        Boolean status = ((CheckBox)grdDatosFactura.Rows[rowindex].FindControl("chkConfirmado")).Checked;
                        string IdFactura = (Convert.ToString(grdDatosFactura.Rows[rowindex].Cells[16].Text) == "0") ? Convert.ToString(grdDatosFactura.Rows[rowindex].Cells[0].Text) : Convert.ToString(grdDatosFactura.Rows[rowindex].Cells[16].Text);
                        


                        if (status == true)                        
                            confirmado_s = confirmado_s + IdFactura + ",";                        
                        else                        
                            confirmado_n = confirmado_n + IdFactura + ",";                        
                    }

                    if (confirmado_s != string.Empty)                    
                        CNFactura.FacturasConfirmadas(confirmado_s, "S", ddlTipo.SelectedValue, ref Verificador);
                    

                    if (confirmado_n != string.Empty)                    
                        CNFactura.FacturasConfirmadas(confirmado_n, "N", ddlTipo.SelectedValue, ref Verificador2);
                    

                    string Msj = (Verificador != string.Empty) ? (Verificador != "0") ? Verificador : "" : "";
                    Msj = Msj + ((Verificador2 != string.Empty) ? (Verificador2 != "0") ? Verificador2 : "" : "");
                    Msj = (Msj == string.Empty) ? "Las solicitudes se han confirmado correctamente" : Msj;
                    Msj = (Msj.Length > 40) ? Msj.Substring(0, 40) : Msj;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, '" + Msj + "');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";

                    //Session["Facturas"] = null;
                    rdoStatusConfirmados_SelectedIndexChanged(null, null);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'No se confirmó ninguna factura.');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";
            }
        }

        protected void grdArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if(ddlTipo.SelectedValue=="R")
                //    CargarGrid();
                //else
                //    CargarGridEfectivo();
                //Tipo();
                ddlStatus_SelectedIndexChanged(null, null);
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

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ModalPopup.Hide();
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
            txtCorreo.Text = grdDatosFactura.SelectedRow.Cells[14].Text;
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
                CNCjaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Convert.ToString(grdDatosFactura.SelectedRow.Cells[21].Text), ref ListArch);
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
                    btnGuardarEditar.ValidationGroup = string.Empty;
                    txtObservaciones.Visible = true;
                }
                else
                {
                    btnGuardarEditar.ValidationGroup = "DatosFiscales";
                    txtObservaciones.Visible = true;
                }
            }
            else
            {
                btnGuardarEditar.ValidationGroup = "DatosFiscales";
                txtObservaciones.Visible = false;
            }
        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            mltViewFacturas.ActiveViewIndex = 2;
            SesionUsu.Editar = 3;
            LimipiarCampos();
            tabFacturas.Tabs[1].Visible = true;
            tabFacturas.Tabs[2].Visible = false;
            valFolio.ValidationGroup = "DatosFiscales";
            valFecha.ValidationGroup = "DatosFiscales";
            valImporte.ValidationGroup = "DatosFiscales";
            valIva.ValidationGroup = "DatosFiscales";
            valTotal.ValidationGroup = "DatosFiscales";
            
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
            txtTotal.Text = Convert.ToString(Convert.ToDouble(txtImporteConvenio.Text)+ Convert.ToDouble(txtIVA.Text));
        }

      

        protected void grdDatosFacturaEfectivo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Verificador = string.Empty;
            //int fila = e.RowIndex;
            //ObjCjaFactura.IdCajaFact= Convert.ToInt32(grdDatosFacturaEfectivo.Rows[fila].Cells[0].Text);
            //CNCjaFactura.FacturaCajaEfectivoBorrar(ObjCjaFactura, ref Verificador);
            //if (Verificador == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El registro fue eliminado correctamente.');", true);
            //    CargarGridEfectivo();
            //}
            //else
            //{
            //    string MsjError = (Verificador.Length > 40) ? Verificador.Substring(0, 40) : Verificador;
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            //}

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Status_Facturas", ref ddlStatus, "p_usuario", "p_tipo_factura", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue);
            ddlStatus_SelectedIndexChanged(null,null);
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
                    lblArchivoVoucher.ToolTip=fullPath;
                    linkBttnEliminarVoucher.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length>40)?ex.Message.Substring(0, 40): ex.Message;
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

        protected void grdDatosFactura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList DDL = e.Row.FindControl("ddlFacturas") as DropDownList;
            //DropDownList DDL2 = e.Row.FindControl("ddlVouchers") as DropDownList;
            if (DDL != null)            
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Facturas_Cja", ref DDL, "P_Id_Factura", "P_Tipo", e.Row.Cells[0].Text, ddlTipo.SelectedValue);
            //if (DDL2 != null)
            //    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Facturas_Cja", ref DDL, "P_Id_Factura", "P_Tipo", e.Row.Cells[0].Text, ddlTipo.SelectedValue);
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
            txtIVA.Text = Convert.ToString(Iva);
            Total = Convert.ToDouble(txtImporteConvenio.Text) + (Convert.ToDouble(txtImporteConvenio.Text) * .16);
            txtTotal.Text = Convert.ToString(Total);

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
                modalDoctos.Show();
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }




        }

        protected void bttnSalir_Click(object sender, EventArgs e)
        {
            modalDoctos.Hide();
        }
    }
}