using CapaEntidad;
using CapaNegocio;
using Facturapi;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos.Form
{
    public partial class frmFacturacion : System.Web.UI.Page
    {
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CajaFactura ObjCjaFactura = new CajaFactura();
        CN_Comun CNComun = new CN_Comun();
        DetFactura objDetFactura = new DetFactura();
        CN_DetFactura CNDetFactura = new CN_DetFactura();
        Factura ObjFactura = new Factura();
        CN_Factura CNFactura = new CN_Factura();
        String Verificador = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();
        }
        protected void inicializar()
        {
            //tabFacturas.ActiveTabIndex = 0;
            mltViewFacturas.ActiveViewIndex = 0;
            txtFecha_Factura_Ini.Text = "01" + System.DateTime.Now.ToString("/MM/yyyy");
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
            Usur.Usu_IdModulo = 15355;
            CargarCombos();
            //imgBttnBuscar_Click(null, null);
        }
        protected void CargarCombos()
        {
            try
            {
                if (Usur.Usu_TipoPermiso == "C")
                    CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_UR_Factura", ref ddlDependencia);
                else
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

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
            Int32[] CeldasFacturados = { 0, 1, 6, 8, 11, 12, 13, 14, 15, 16, 17 };
            Int32[] CeldasSolicitados = { 0, 7, 8, 10, 11, 13, 14, 15, 16, 17, 18, 20, 21, 22 };
            Int32[] CeldasPorConfirmar = { 0, 6, 7, 8, 10, 13, 14, 15, 16, 17, 18, 21, 22 };


            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();

                if (grdDatosFactura.Rows.Count > 0)
                    CNComun.HideColumns(grdDatosFactura, CeldasFacturados);
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private List<CajaFactura> GetList()
        {
            try
            {
                List<CajaFactura> List = new List<CajaFactura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                CNCjaFactura.FacturApiGrid(Usur, ref ObjCjaFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, "T", "T", ddlFiltro.SelectedValue, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void LimipiarCampos()
        {
            try
            {
                //rdoBttnReceptorTipoPersona.SelectedValue = string.Empty;
                rdoBttnReceptorTipoPersona.SelectedValue = "F";
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
                ddlDependencia.Enabled = true;
                ddlDependencia.Visible = true;
                Session["Archivos"] = null;
                Session["Conceptos"] = null;
                valLongitudRFC0.ValidationGroup = "DatosFiscales";
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjCjaFactura.ItsOk = false;
            ddlDependencia.Enabled = false;
            LimipiarCampos();
            try
            {
                ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);

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
                    ObjCjaFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                    ObjCjaFactura.FACT_FOLIO = Convert.ToString(grdDatosFactura.SelectedRow.Cells[1].Text);

                    mltViewFacturas.ActiveViewIndex = 1;
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

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
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

        protected void bttnGenFactura_Click(object sender, EventArgs e)
        {
            List<DetFactura> lst = new List<DetFactura>();
            objDetFactura.ID_FACT = grdDatosFactura.SelectedRow.Cells[0].Text;
            string Ruta = string.Empty;
            CNDetFactura.ObtDetFactura(objDetFactura, ref lst);
            try
            {
                var facturapi = new FacturapiClient("sk_test_eNJ362v0j4DkY4RYRe51vqmKErROlMBQ");
                if (lst.Count == 1)
                {
                    var invoice = facturapi.Invoice.CreateAsync(new Dictionary<string, object>
                    {
                        ["customer"] = new Dictionary<string, object>
                        {
                            ["legal_name"] = txtReceptor_Nombre.Text.ToUpper(),
                            ["email"] = txtReceptor_Correo.Text.ToUpper(),
                            ["tax_id"] = txtReceptor_Rfc.Text.ToUpper(),
                            ["address"] = new Dictionary<string, object>
                            {
                                ["street"] = txtReceptor_Domicilio.Text.ToUpper(),
                                ["zip"] = txtReceptor_CP.Text.ToUpper(),
                                ["neighborhood"] = txtReceptor_Colonia.Text.ToUpper(),
                                ["municipality"] = ddlReceptor_Municipio.Text.ToUpper(),
                                ["state"] = ddlReceptor_Estado.Text.ToUpper(),
                                ["country"] = "MEXICO",
                            }
                        },


                        ["payment_form"] = Facturapi.PaymentForm.DINERO_ELECTRONICO,


                        ["items"] = new Dictionary<string, object>[]
                        {                        
                            new Dictionary<string, object>
                            {
                                ["quantity"] = 1,
                                ["product"] = new Dictionary<string, object>
                                {
                                    ["description"] = lst[0].DescConcepto,
                                    ["product_key"] = "86121701",
                                    ["price"] = lst[0].FACT_TOTAL,
                                    ["tax_included"] = false,
                                    ["taxes"] = new Dictionary<string, object>[]
                                    {
                                        new Dictionary<string, object>{
                                            ["rate"] = 0.00M,
                                            ["type"] = "IVA",
                                            ["withholding"] = false,
                                            ["factor"] = "Exento"
                                        }
                                    }
                                }
                            }
                        }

                    }).GetAwaiter().GetResult();
                    CNCjaFactura.FacturApiAgregar(grdDatosFactura.SelectedRow.Cells[2].Text, Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text), Convert.ToString(invoice.Id), ref Verificador);
                    if (Verificador == "0")
                    {
                        var archivo_pdf = facturapi.Invoice.DownloadPdfAsync(invoice.Id).GetAwaiter().GetResult();
                        var archivo_xml = facturapi.Invoice.DownloadXmlAsync(invoice.Id).GetAwaiter().GetResult();
                        var ruta_pdf = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "Facturas/" + invoice.Id + ".pdf", System.IO.FileMode.Create);
                        var ruta_xml = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "Facturas/" + invoice.Id + ".xml", System.IO.FileMode.Create);
                        archivo_pdf.CopyTo(ruta_pdf);
                        archivo_xml.CopyTo(ruta_xml);
                        ruta_pdf.Close();
                        archivo_xml.Close();
                        mltViewFacturas.ActiveViewIndex = 0;
                        imgBttnBuscar_Click(null, null);
                    }
                    //Ruta = "https://www.facturapi.io/web/organization/5f9334bf1ef9810026efe49c/invoices/" + invoice.Id + "/pdf";
                }
                else if (lst.Count == 2)
                {
                    var invoice = facturapi.Invoice.CreateAsync(new Dictionary<string, object>
                    {
                        ["customer"] = new Dictionary<string, object>
                        {
                            ["legal_name"] = txtReceptor_Nombre.Text.ToUpper(),
                            ["email"] = txtReceptor_Correo.Text.ToUpper(),
                            ["tax_id"] = txtReceptor_Rfc.Text.ToUpper(),
                            ["address"] = new Dictionary<string, object>
                            {
                                ["street"] = txtReceptor_Domicilio.Text.ToUpper(),
                                ["zip"] = txtReceptor_CP.Text.ToUpper(),
                                ["neighborhood"] = txtReceptor_Colonia.Text.ToUpper(),
                                ["municipality"] = ddlReceptor_Municipio.Text.ToUpper(),
                                ["state"] = ddlReceptor_Estado.Text.ToUpper(),
                                ["country"] = "MEXICO",
                            }
                        },


                        ["payment_form"] = Facturapi.PaymentForm.DINERO_ELECTRONICO,


                        ["items"] = new Dictionary<string, object>[]
                        {
                            new Dictionary<string, object>
                            {
                                ["quantity"] = 1,
                                ["product"] = new Dictionary<string, object>
                                {
                                    ["description"] = lst[0].DescConcepto,
                                    ["product_key"] = "86121701",
                                    ["price"] = lst[0].FACT_TOTAL,
                                    ["tax_included"] = false,
                                    ["taxes"] = new Dictionary<string, object>[]
                                    {
                                        new Dictionary<string, object>{
                                            ["rate"] = 0.00M,
                                            ["type"] = "IVA",
                                            ["withholding"] = false,
                                            ["factor"] = "Exento"
                                        }
                                    }
                                }
                            },
                            new Dictionary<string, object>
                            {
                                ["quantity"] = 1,
                                ["product"] = new Dictionary<string, object>
                                {
                                    ["description"] = lst[1].DescConcepto,
                                    ["product_key"] = "86121701",
                                    ["price"] =lst[1].FACT_TOTAL,
                                    ["tax_included"] = false,
                                    ["taxes"] = new Dictionary<string, object>[]
                                    {
                                        new Dictionary<string, object>{
                                            ["rate"] = 0.00M,
                                            ["type"] = "IVA",
                                            ["withholding"] = false,
                                            ["factor"] = "Exento"
                                        }
                                    }
                                }
                            }
                        }
                    }).GetAwaiter().GetResult();
                    CNCjaFactura.FacturApiAgregar(grdDatosFactura.SelectedRow.Cells[2].Text, Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text), Convert.ToString(invoice.Id), ref Verificador);
                    if (Verificador == "0")
                    {
                        var archivo_pdf = facturapi.Invoice.DownloadPdfAsync(invoice.Id).GetAwaiter().GetResult();
                        var archivo_xml = facturapi.Invoice.DownloadXmlAsync(invoice.Id).GetAwaiter().GetResult();
                        var ruta_pdf = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "Facturas/" + invoice.Id + ".pdf", System.IO.FileMode.Create);
                        var ruta_xml = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "Facturas/" + invoice.Id + ".xml", System.IO.FileMode.Create);
                        archivo_pdf.CopyTo(ruta_pdf);
                        archivo_xml.CopyTo(ruta_xml);
                        ruta_pdf.Close();
                        archivo_xml.Close();
                        mltViewFacturas.ActiveViewIndex = 0;
                        imgBttnBuscar_Click(null, null);
                    }
                    //Ruta = "https://www.facturapi.io/web/organization/5f9334bf1ef9810026efe49c/invoices/" + invoice.Id + "/pdf";
                }

                //ScriptManager.RegisterStartupScript(this, GetType(), "PDF", "LoadPDF('" + Ruta + "');", true);

            }
            catch (FacturapiException ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);

            }
        }


        //static void DownloadZip(string invoiceId)
        //{
        //    try
        //    {
        //        var zipStream = await Facturapi.Invoice.DownloadZipAsync(invoiceId);
        //        // O bien, el XML y el PDF por separado
        //        var xmlStream = await facturapi.Invoice.DownloadXmlAsync(invoice.Id);
        //        var pdfStream = await facturapi.Invoice.DownloadPdfAsync(invoice.Id);
        //        // Y luego guardarlo en un archivo del disco duro
        //        var file = new System.IO.FileStream("C:\\route\\to\\save\\invoice.zip", FileMode.Create);
        //        zipStream.CopyTo(file);
        //        file.Close();
        //        //var stream = Facturapi.Invoice.DownloadZipAsync(invoiceId).GetAwaiter().GetResult();
        //        //var file = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\factura.zip", FileMode.Create);
        //        //stream.CopyTo(file);
        //        //file.Close();
        //        //Console.WriteLine("Invoice saved!");
        //    }
        //    catch (FacturapiException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //}


        protected void bttnCancelar_Click(object sender, EventArgs e)
        {   
            mltViewFacturas.ActiveViewIndex = 0;
        }

        protected void lnkBttnVerPDF_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            string ruta = "../Facturas/" + grdDatosFactura.SelectedRow.Cells[17].Text+".pdf";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);


            //string Ruta = "facturapi.io/web/organization/5f9334bf1ef9810026efe49c/invoices/" + grdDatosFactura.SelectedRow.Cells[17].Text + "/pdf";
            //ScriptManager.RegisterStartupScript(this, GetType(), "PDF", "LoadPDF('" + Ruta + "');", true);
        }

        protected void lnkBttnVerXML_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            string ruta = "../Facturas/" + grdDatosFactura.SelectedRow.Cells[17].Text + ".xml";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            //string Ruta = "facturapi.io/web/organization/5f9334bf1ef9810026efe49c/invoices/" + grdDatosFactura.SelectedRow.Cells[17].Text + "/xml";
            //ScriptManager.RegisterStartupScript(this, GetType(), "PDF", "LoadPDF('" + Ruta + "');", true);

        }
    }
}