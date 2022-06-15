using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region <Variables>
        //Int32[] Celdas = { 0, 7, 10 };
        //private string[] UsuariosSuper = {"JFREDY", "NESTOR", "GAVA", "ADOMINGUEZ","LUISH","LISSETH","OMAR","VELASCO","MARCOSA", "VICENTE", "NIVETTE", "JMOLINA", "FRANCISCO", "OSMANDI", "GEORGINA", "YARINA", "NORMAV", "BEATRIZ" };
        Factura ObjFactura = new Factura();
        Alumno ObjAlumno = new Alumno();
        Comun ObjComun = new Comun();
        Evento ObjEvento = new Evento();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Evento CNEvento = new CN_Evento();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        CN_Facturacion CNFacturacion = new CN_Facturacion();
        string Verificador = "";
        public String fullPath;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "GridRecibos", "Recibos();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridMonitor", "Monitor();", true);
        }

        protected void inicializar()
        {

            multView.ActiveViewIndex = 0;
            CargarCombos();

            if (Convert.ToString(SesionUsu.Usu_TipoUsu) == "3")
            {
                lblDependencia.Visible = true;
                ddlDependencia.Visible = true;
                txtFecha_Factura_Ini.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                //if (Request.QueryString["reporte"] == null && Request.QueryString["modulo"] == null && Request.QueryString["Evento"] == null)
                //    busca_informativa();

                if (SesionUsu.Usu_Central == "S")
                    CargarGridMonitor(ref grdMonitor);
                else
                    grdMonitor.Visible = false;
            }
            else
            {
                SesionUsu.Usu_Central = "N";
                txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                grdMonitor.Visible = false;
                busca_informativa();
            }

            CargarGridBancos();
            CargarGrid();
            txtReferencia.Focus();
        }

        private void CargarGridBancos()
        {
            try
            {
                List<Comun> ListAlumno = new List<Comun>();
                List<Comun> ListUsuario = new List<Comun>();
                DataTable dt = new DataTable();
                GetListBancos(ref ListAlumno, ref ListUsuario);
                if (ListUsuario.Count >= 1)
                {
                    if (SesionUsu.Usu_TipoUsu == 1)
                    {
                        if (ListAlumno.Count > 0)
                        {
                            grdStatus_Carga_Bancos.DataSource = dt;
                            grdStatus_Carga_Bancos.DataSource = ListAlumno;
                            grdStatus_Carga_Bancos.DataBind();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "gridBancosAlumnos", "$('#modalBancosAlumnos').modal('show')", true);

                        }
                    }
                    else
                    {
                        grdStatus_Carga.DataSource = dt;
                        grdStatus_Carga.DataSource = ListUsuario;
                        grdStatus_Carga.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void GetListBancos(ref List<Comun> ListAlumno, ref List<Comun> ListUsuario)
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == 1)
                    CNFactura.Obt_Grid_Status_Bancos(ObjComun, ref ListAlumno);

                CNFactura.Obt_Grid_Status_Bancos_Usu(ObjComun, ref ListUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void busca_informativa()
        {
            lblMensaje.Text = string.Empty;

            try
            {
                string Observaciones = string.Empty;
                CNComun.Consultar_Observaciones(SesionUsu.Usu_Nombre, 14, Convert.ToString(SesionUsu.Usu_TipoUsu), ref Observaciones, SesionUsu.Usu_Central, ref Verificador);
                //CNComun.Consultar_Observaciones(SesionUsu.Usu_Nombre, 14, Convert.ToString(SesionUsu.Usu_TipoUsu), ref Observaciones, ref Verificador);
                if (Verificador == "0")
                {
                    if (Observaciones.Length > 1)
                    {
                        lblMsg_Observaciones.Text = Observaciones;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "gridMensajes", "$('#modalMsgs').modal('show')", true);

                    }
                }
                else
                {
                    lblMensaje.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void CargarGridMonitor(ref GridView grd)
        {
            try
            {
                Int32[] Celdas = new Int32[] { 2, 4 };
                DataTable dt = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetDatos_Monitor();
                grd.DataBind();

                if (grd.Rows.Count > 0)
                    CNComun.HideColumns(grd, Celdas);


                grd.SelectedIndex = 0;
                if (grd.SelectedRow.Cells[2].Text.Contains("1"))
                {
                    grd.SelectedRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#ebccd1");
                    grd.SelectedRow.Font.Bold = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        public List<Comun> GetDatos_Monitor()
        {

            try
            {
                List<Comun> List = new List<Comun>();
                CNFactura.ErroresConsultaGrid(SesionUsu.Usu_Nombre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarGrid()
        {
            divErrorTot.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetList();
                grdDatosFactura.DataBind();





                if (grdDatosFactura.Rows.Count > 0)
                {
                   

                    if (SesionUsu.Usu_TipoUsu == 4 || SesionUsu.Usu_TipoUsu == 7)//Muestra la columna Editar
                    {
                        Int32[] Celdas = { 0, 11, 12 };
                        CNComun.HideColumns(grdDatosFactura, Celdas);
                    }
                    else
                    {
                        Int32[] Celdas = { 0, 11, 12, 13 };
                        CNComun.HideColumns(grdDatosFactura, Celdas);
                    }


                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                Usur.Usu_Nombre = SesionUsu.Usu_Nombre;
                Usur.Usu_NoControl = SesionUsu.Usu_NoControl;
                Usur.Usu_TipoUsu = SesionUsu.Usu_TipoUsu;
                CNFactura.FacturaConsultaGrid(Usur, ref ObjFactura, ddlDependencia.SelectedValue.ToString(), txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtReferencia.Text, ref List);
                if (List.Count >= 4000)
                {
                    List = null;
                    divErrorTot.Visible = true;
                }
                
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_CodFiscal", ref ddlCodigoFiscal);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            lblMensaje.Text = string.Empty;
            CargarGrid();

        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            lblMensaje.Text = string.Empty;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grdDatosFactura.SelectedRow.Cells[8].Text;
                PnlCorreo.Recibo = grdDatosFactura.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDatosFactura.PageIndex = 0;
            grdDatosFactura.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pnlContenor.Visible = false;
            //btnRegresar.Visible = true;
            pnlReciboOficial.Visible = true;
            btnRegresar.Visible = true;
            grdDatosFactura.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ObtenerQR(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + "," + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[12].Text) + ");", true);
        }

        protected void grdMonitor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMonitor.PageIndex = 0;
            grdMonitor.PageIndex = e.NewPageIndex;
            CargarGridMonitor(ref grdMonitor);
        }

        protected void grdMonitor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int fila = e.RowIndex;

            try
            {
                string Observaciones = Convert.ToString(grdMonitor.Rows[fila].Cells[4].Text); //grdMonitor.SelectedRow.Cells[4].Text;
                CNFactura.FacturaEditarEstatusRevisado(Observaciones, SesionUsu.Usu_Nombre, ref Verificador);
                if (Verificador == "0")
                    CargarGridMonitor(ref grdMonitor);
                else
                {
                    string Msj = Verificador;
                    CNComun.VerificaTextoMensajeError(ref Msj);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
                }

            }
            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }

       

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            grdDatosFactura.Visible = true;
            //pnlContenor.Visible = true;
            pnlReciboOficial.Visible = false;
            btnRegresar.Visible = false;
        }

        protected void bttnBuscar_Click(object sender, EventArgs e)
        {
            grdDatosFactura.Visible = true;
            pnlReciboOficial.Visible = false;
            btnRegresar.Visible = false;
            CargarGrid();
        }

        protected void grdDoctosFactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdDatosFactura.PageIndex = 0;
                grdDatosFactura.PageIndex = e.NewPageIndex;
                CargarGridDoctos();
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

        private List<Facturacion> GetListDoctos()
        {
            try
            {
                List<Facturacion> List = new List<Facturacion>();
                Facturacion objFacturacion = new Facturacion();
                objFacturacion.ID_FACT = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNFacturacion.FacturaDoctosConsultaGrid(objFacturacion, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgBttnFact_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                CargarGridDoctos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gridDoctos", "$('#modalDoctos').modal('show')", true);

            }


            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkVerFactura_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                CargarGridDoctos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gridDoctos", "$('#modalDoctos').modal('show')", true);
            }


            catch (Exception ex)
            {
                string Msj = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnSolicitar_Click(object sender, EventArgs e)
        {
            multView.ActiveViewIndex = 1;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            txtReceptor_Rfc.Focus();
            try
            {
                ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);

                if (Verificador == "0")
                {
                    rdoBttnReceptorTipoPersona.SelectedValue = ObjFactura.FACT_RECEPTOR_TIPO_PERS;
                    rdoBttnReceptorTipoPersona_SelectedIndexChanged(null, null);
                    txtReceptor_Nombre.Text = ObjFactura.FACT_NOMBRE;
                    txtReceptor_Rfc.Text = ObjFactura.FACT_RECEPTOR_RFC;
                    txtReceptor_Domicilio.Text = ObjFactura.FACT_RECEPTOR_DOMICILIO;
                    txtReceptor_Colonia.Text = ObjFactura.FACT_RECEPTOR_COLONIA;
                    txtReceptor_CP.Text = ObjFactura.FACT_RECEPTOR_CP;

                    CNComun.LlenaCombo("PKG_CONTRATOS.Obt_Combo_Estados", ref ddlReceptor_Estado, "p_pais", "1");
                    ddlReceptor_Estado.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                    ddlEstado_Fiscal_SelectedIndexChanged(null, null);

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

                    ddlCodigoFiscal.SelectedValue = ObjFactura.FACT_RECEPTOR_CODIGO;
                    ddlCodigoFiscal_SelectedIndexChanged(null, null);

                    ddlCFDI.SelectedValue = ObjFactura.CFDI;
                    txtDescConcepto.Text = ObjFactura.FACT_OBSERVACIONES;
                    lblConceptosFac.Text = ObjFactura.FACT_CONCEPTOS;
                    lblImporte.Text = ObjFactura.FACT_IMPORTE;
                    txtReceptor_NumExt.Text = ObjFactura.NUMERO_EXTERIOR;
                    txtReceptor_NumInt.Text = ObjFactura.NUMERO_INTERIOR;
                    if (ObjFactura.ADJUNTO_CONSTANCIA != string.Empty)
                    {
                        linkConstancia.NavigateUrl = "ArchivosFacturas/" + ObjFactura.ADJUNTO_CONSTANCIA;
                        linkConstancia.Text = ObjFactura.ADJUNTO_CONSTANCIA;
                        linkConstancia.ToolTip = ObjFactura.ADJUNTO_CONSTANCIA;
                        linkBttnEliminarConstancia.Visible = true;
                    }

                    //multView.ActiveViewIndex = 1;

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

        protected void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (linkConstancia.NavigateUrl == string.Empty && rdoBttnReceptorTipoPersona.SelectedValue == "F")                
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'La constancia fiscal es requerida, favor de adjuntar.');", true);  //lblMsj.Text = ex.Message;                
                else                
                    Guardar();
            }
        }

        protected void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            multView.ActiveViewIndex = 0;
        }

        protected void rdoBttnReceptorTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBttnReceptorTipoPersona.SelectedValue == "F")
            {
                txtReceptor_Rfc.MaxLength = 13;
                reqCodigo.ValidationGroup = "DatosFiscales";
            }
            else
            {
                txtReceptor_Rfc.MaxLength = 12;
                reqCodigo.ValidationGroup = string.Empty;
            }
        }

        protected void Guardar()
        {
            string Usuario;
            try
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
                ObjFactura.FACT_RECEPTOR_STATUS = string.Empty; //"R";
                ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = string.Empty;
                ObjFactura.FACT_CONFIRMADO = "N"; // "S"; //string.Empty; ;
                ObjFactura.CFDI = ddlCFDI.SelectedValue;
                ObjFactura.FACT_RECEPTOR_CODIGO = ddlCodigoFiscal.SelectedValue;

                ObjFactura.FACT_TIPO_SERVICIO = "0"; // ddlServicio.SelectedValue;
                ObjFactura.FACT_OBSERVACIONES = txtDescConcepto.Text.ToUpper();
                ObjFactura.FACT_RECEPTOR_FORMA_PAGO = ddlForma_Pago.SelectedValue;
                if (SesionUsu.Usu_TipoUsu == 4 || SesionUsu.Usu_TipoUsu == 7)
                    Usuario = Convert.ToString(grdDatosFactura.SelectedRow.Cells[8].Text);
                else
                    Usuario = SesionUsu.Usu_Nombre;

                ObjFactura.NUMERO_EXTERIOR = (txtReceptor_NumExt.Text == null || txtReceptor_NumExt.Text == string.Empty) ? "0" : txtReceptor_NumExt.Text;
                ObjFactura.NUMERO_INTERIOR = (txtReceptor_NumInt.Text == null || txtReceptor_NumInt.Text == string.Empty) ? "0" : txtReceptor_NumInt.Text;
                ObjFactura.ADJUNTO_CONSTANCIA = linkConstancia.Text;


                ObjFactura.ID_FACT = Convert.ToString(grdDatosFactura.SelectedRow.Cells[0].Text);
                CNFactura.FacturaEditarDatosCaja(ObjFactura, Usuario, ref Verificador);

                if (Verificador == "0")
                {
                    multView.ActiveViewIndex = 0;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Su solicitud será revisada.');", true); //lblMensaje.Text = Verificador;
                }

                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true); //lblMensaje.Text = Verificador;
                }

            }
            catch (Exception ex)
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true); //lblMensaje.Text = Verificador;

            }

        }

        protected void linkBttnCorreo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            lblMensaje.Text = string.Empty;
            try
            {
                grdDatosFactura.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grdDatosFactura.SelectedRow.Cells[8].Text;
                PnlCorreo.Recibo = grdDatosFactura.SelectedRow.Cells[0].Text;
                PnlCorreo.Muestra();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

      
        protected void linkBttnConstancia_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileConstancia.HasFile)
                {
                    int fileSize = fileConstancia.PostedFile.ContentLength;
                    fullPath = Path.Combine(Server.MapPath("ArchivosFacturas/"), "CONSTANCIA-" + grdDatosFactura.SelectedRow.Cells[0].Text + "-" + fileConstancia.FileName);

                    fileConstancia.SaveAs(fullPath);
                    linkConstancia.NavigateUrl = "ArchivosFacturas/CONSTANCIA-" + grdDatosFactura.SelectedRow.Cells[0].Text + "-" + fileConstancia.FileName;
                    linkConstancia.Text = "CONSTANCIA-" + grdDatosFactura.SelectedRow.Cells[0].Text + "-" + fileConstancia.FileName;
                    linkConstancia.ToolTip = fullPath;
                    linkBttnEliminarConstancia.Visible = true;

                    //collapse1.Attributes["class"] = "collapse multi-collapse show";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Collapse2", "Collapse2();", true);
                }

            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }
        protected void linkBttnEliminarConstancia_Click(object sender, EventArgs e)
        {
            //linkBttnEliminarConstancia
            try
            {
                System.IO.File.Delete(linkConstancia.ToolTip);
                linkConstancia.NavigateUrl = string.Empty;
                linkConstancia.Text = string.Empty;
                linkConstancia.ToolTip = string.Empty;
                linkBttnEliminarConstancia.Visible = false;
            }
            catch (Exception ex)
            {
                string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void ddlCodigoFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_TipoCfdi", ref ddlCFDI, "p_cod_fiscal", "p_tipo_persona", ddlCodigoFiscal.SelectedValue, rdoBttnReceptorTipoPersona.SelectedValue);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
            }
        }
    }
}