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
    public partial class frmRefVenta_PS : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Usuario Usuario = new Usuario();
        Factura ObjFactura = new Factura();

        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        CN_Alumno CNCliente = new CN_Alumno();
        CN_Factura CNFactura = new CN_Factura();


        string Verificador = string.Empty;
        string MesActual = "0";
        string WXI = string.Empty;
        List<Bien> lstBien = new List<Bien>();
        List<Bien> lstProductosAgregados = new List<Bien>();
        List<Comun> lstProductos = new List<Comun>();

        private static List<Comun> lstBienGrupo = new List<Comun>();

        Alumno ObjMatricula = new Alumno();
        string MsjError = string.Empty;
        private static List<Comun> lstCtasMayor = new List<Comun>();
        FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();
        List<ConceptoPago> ListConcepto = new List<ConceptoPago>();

        #endregion
        #region <Botones y Eventos>
        private void Iniciar()
        {

            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Productos", ref DDLCtaMayor, "INGRESOS");


        }




        private void Cargarcombos()
        {
            try
            {
                if (SesionUsu.Usu_TipoUsu == 6)
                {
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre); //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Escuelas_Externos", ref DDLDependencia, "p_nivel", "p_evento", "p_usuario", "X", "ALUMNO", "", "INGRESOS");                
                    //txtClaveSysweb.Enabled = false;
                    //imgBttnCatClientes.Enabled = false;
                }
                else
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

                //CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos", ref DDLConceptos, "INGRESOS");
                //CNComun.LlenaComboG("pkg_pagos_2016.Obt_Combo_Tipo_Ventas", ref DDLTipoVenta, ref lstBienGrupo, "INGRESOS");

                //CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Alumnos", ref DDLClientes, ref lstBienGrupo, "INGRESOS");

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridProductos()
        {
            decimal Total = 0;

            grvProductosAgregados.Visible = true;
            grvProductosAgregados.DataSource = null;
            grvProductosAgregados.DataBind();

            //if(Sesion["listaProductosAgregados"] !=null)
            if (Session["listaProductosAgregados"] != null)
                lstProductosAgregados = (List<Bien>)Session["listaProductosAgregados"];


            grvProductosAgregados.Visible = true;
            grvProductosAgregados.DataSource = lstProductosAgregados;
            grvProductosAgregados.DataBind();

            Total = lstProductosAgregados.Sum(x => Convert.ToDecimal(x.Total));
            Label lblTot = (Label)grvProductosAgregados.FooterRow.FindControl("lblGranTotal");
            lblTot.Text = Convert.ToString(Total.ToString("C"));



        }
        private void CargarGridInicio()
        {
            Int32[] Celdas1;
            if (SesionUsu.Usu_TipoUsu == 6)
                Celdas1 = new Int32[] { 0, 9, 8, 10, 12 };
            else
                Celdas1 = new Int32[] { 0, 9, 10, 11, 12 };

            grdDatosFactura.Visible = true;
            grdDatosFactura.DataSource = null;
            grdDatosFactura.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdDatosFactura.DataSource = dt;
                grdDatosFactura.DataSource = GetListInicio();
                grdDatosFactura.DataBind();
                if (grdDatosFactura.Rows.Count > 0)
                    CNComun.HideColumns(grdDatosFactura, Celdas1);
                //else
                //    grdDatosFactura.Visible = false;

                if (SesionUsu.Usu_TipoUsu == 6)
                {
                    Button bttnGenerarRef = grdDatosFactura.HeaderRow.FindControl("bttnGenerarRef") as Button;
                    bttnGenerarRef.Visible = false;
                }


                //if (ListDoctos.Count >= 1)
                //{
                //    grdDatosFactura.HeaderRow.Cells[0].Visible = false;
                //    grdDatosFactura.HeaderRow.Cells[9].Visible = false;
                //    grdDatosFactura.HeaderRow.Cells[10].Visible = false;

                //    Button ddlTipoDocto = grdDatosFactura.HeaderRow.FindControl("bttnGenerarRef") as Button;
                //    ddlTipoDocto.SelectedValue = row.Cells[0].Text;

                //    foreach (GridViewRow row in grdDatosFactura.Rows)
                //    {
                //        row.Cells[0].Visible = false;
                //        row.Cells[9].Visible = false;
                //        row.Cells[10].Visible = false;

                //        HyperLink link = row.FindControl("LinkDocto") as HyperLink;
                //        link.Text = row.Cells[1].Text;
                //        if (SesionUsu.Usu_Programa == "PIFI")
                //            link.NavigateUrl = "~/ArchivosPIFI/" + row.Cells[1].Text;
                //        else
                //            link.NavigateUrl = "~/ArchivosPROMEP/" + row.Cells[1].Text;
                //    }
                //}


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
        private void CargarGridClientes()
        {
            Int32[] Celdas1 = new Int32[] { 0, 9 };
            grvClientes.DataSource = null;
            grvClientes.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvClientes.DataSource = dt;
                grvClientes.DataSource = GetListClientes();
                grvClientes.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
        private void CargarGrid(string Filtro)
        {
            //grvInventario.DataSource = null;
            //grvInventario.DataBind();
            if (Filtro == "N")
                ViewState["Filter"] = "T";


            try
            {
                //DataTable dt = new DataTable();
                //grvInventario.DataSource = dt;
                //grvInventario.DataSource = null;
                //grvInventario.DataBind();



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
        private void CargarGridDetalle()
        {
            grvDetPago.DataSource = null;
            grvDetPago.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvDetPago.DataSource = dt;
                grvDetPago.DataSource = GetListDetalle();
                grvDetPago.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }



        private List<Bien> GetListDetalle()
        {
            try
            {
                List<Bien> List = new List<Bien>();
                Bien objBien = new Bien();
                objBien.Id_Ficha_Bancaria = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[10].Text);
                objBien.Pagado = Convert.ToString(grdDatosFactura.SelectedRow.Cells[9].Text);
                CNBien.ConsultarGridDetalle(objBien, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Factura> GetListInicio()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                //Factura objFactura = new Factura();
                //objFactura.FACT_DEPENDENCIA = DDLDependencia.SelectedValue;
                //objFactura.FACT_STATUS = DDLStatus.SelectedValue;                    
                //CNFactura.FacturaProductosConsultaGrid(DDLDependencia.SelectedValue, DDLPagado.SelectedValue, txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtBuscaRef.Text, SesionUsu.Usu_TipoUsu, SesionUsu.Usu_Nombre, ref List);
                CNFactura.FacturaProductosConsultaGrid(DDLDependencia.SelectedValue, "T", txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtBuscaRef.Text, SesionUsu.Usu_TipoUsu, SesionUsu.Usu_Nombre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Alumno> GetListClientes()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                Alumno objCliente = new Alumno();
                objCliente.Dependencia = DDLDependencia.SelectedValue;
                objCliente.Nivel = ddlNivelBusqueda.SelectedValue;
                //CNCliente.ConsultarCatClientes(ref objCliente, txtBuscaCliente.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //private void BuscaCveCliente()
        //{
        //    lblClienteNombre.Text = string.Empty;
        //    Verificador = string.Empty;
        //    try
        //    {
        //        ObjMatricula.Matricula = txtClaveSysweb.Text.ToUpper();
        //        ObjMatricula.Dependencia = DDLDependencia.SelectedValue;               
        //        CNCliente.ConsultarCliente(ref ObjMatricula, ref Verificador);
        //        if (Verificador == "0")
        //        {
        //            lblClienteNombre.Text = ObjMatricula.Nombre + ' ' + ObjMatricula.APaterno + ' ' + ObjMatricula.AMaterno;
        //        }
        //        else
        //            lblClienteNombre.Text = "El # de cliente ingresado no existe, verificar.";


        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
        //    }
        //}
        private int GetID(string Tipo)
        {
            int ID = 0;
            try
            {
                ObjFichaReferenciada = new FichaReferenciada();
                CNBien.GenerarID(ref ObjFichaReferenciada);
                ID = ObjFichaReferenciada.IdFichaBancaria;
                if (Tipo == "FichaRef")
                    hddnIdFichaRef.Value = Convert.ToString(ObjFichaReferenciada.IdFichaBancaria);

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
            return ID;

        }
        private string GetReferencia()
        {
            string Referencia = "";
            try
            {
                CNBien.GenerarReferencia(ref ObjFichaReferenciada);
                hddnReferencia.Value = ObjFichaReferenciada.Referencia;
                Referencia = ObjFichaReferenciada.Referencia;
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
            }
            return Referencia;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                ViewState["Filter"] = "T";
                Session["Inventario"] = null;
                hddnIdFichaRef.Value = "0";
                hddnTotal.Value = "0";
                Cargarcombos();
                MesActual = System.DateTime.Now.Month.ToString();
                int Mes = Convert.ToInt32(MesActual);
                if (Mes > 3)
                    Mes = Mes - 3;


                txtFecha_Factura_Ini.Text = "01/" + Mes.ToString().PadLeft(2, '0') + "/" + System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarGridInicio();
                MultiView1.ActiveViewIndex = 1;

                //DDLTipoVenta_SelectedIndexChanged(null, null);


            }

            ScriptManager.RegisterStartupScript(this, GetType(), "GridReferencias", "Referencias();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ComboClientes", "FiltClientes();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ComboProductos", "CatProductos();", true);


            //ScriptManager.RegisterStartupScript(this, GetType(), "GridCatClientes", "CatClientes();", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "GridInventario", "CatInventario();", true);

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid("N");
        }

        protected void grvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        protected void grvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grvInventario.PageIndex = 0;
            //grvInventario.PageIndex = e.NewPageIndex;

            CargarGrid("N");
        }



        protected void bttnPagar_Click(object sender, EventArgs e)
        {
            //if (hddnIdFichaRef.Value == "0")
            lblError.Text = string.Empty;
            Verificador = string.Empty;
            lblRefGen.Text = string.Empty;
            try
            {
                if (hddnIdFichaRef.Value == "0")
                {
                    ObjFichaReferenciada.IdFichaBancaria = GetID("FichaRef");
                    if (ddlNivelBusqueda.SelectedValue == "X")
                        ObjFichaReferenciada.NoControl = DDLCatClientes.SelectedValue; /*DDLCatClientes.SelectedValue; txtClaveSysweb.Text.ToUpper();*/
                    else
                        ObjFichaReferenciada.NoControl = txtClaveSysweb.Text.ToUpper();

                    ObjFichaReferenciada.Nivel = "L";
                    ObjFichaReferenciada.Dependencia = DDLDependencia.SelectedValue;
                    ObjFichaReferenciada.Carrera = "000000";
                    ObjFichaReferenciada.Nombre = lblClienteNombre.Text; //grvClientes.SelectedRow.Cells[1].Text; DDLCatClientes.SelectedItem.Text; lblClienteNombre.Text;

                    ObjFichaReferenciada.Vigencia = 7;
                    ObjFichaReferenciada.Importetotal = Convert.ToDouble(hddnTotal.Value);
                    ObjFichaReferenciada.CicloEscolar = 20;
                    ObjFichaReferenciada.Referencia = GetReferencia();
                    ObjFichaReferenciada.ConceptoRef = txtObservaciones.Text.ToUpper();
                    ObjFichaReferenciada.Grupo = "U";
                    ObjFichaReferenciada.Semestre = "0";
                    ObjFichaReferenciada.Evento = "ADMON"; //(DDLTipoVenta.SelectedValue == "1") ? "201800072" : "";
                    ObjFichaReferenciada.Referencia = hddnReferencia.Value;
                    ObjFichaReferenciada.Usuario = "VENTA_PRODUCTOS";
                    ObjFichaReferenciada.UsuarioRegistra = SesionUsu.Usu_Nombre;
                    CNBien.InsertarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);
                    if (Verificador == "0")
                    {
                        List<Bien> ListPDet = new List<Bien>();
                        lstBien = (List<Bien>)Session["Inventario"];
                        CNBien.InsertarDetalleConceptoPago(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, ref lstBien);
                        if (Verificador == "0")
                        {
                            Verificador = string.Empty;
                            CNBien.InsertarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, lstBien);
                            if (Verificador == "0")
                            {
                                //DDLTipoVenta.Enabled = false;
                                //imgBttnBuscar.Enabled = false;
                                //imgBttnCatClientes.Enabled = false;
                                //txtClaveSysweb.Enabled = false;
                                //grvInventario.Enabled = false;
                                //grvInventarioAgregado.Enabled = false;
                                lblRefGenerada.Text = hddnReferencia.Value;
                                //txtBuscaRef.Text = hddnReferencia.Value;
                                //DDLTipoVenta.Enabled = true;
                                CargarGridInicio();
                                MultiView1.ActiveViewIndex = 1;



                                //modalPagar.Show();
                            }
                            else
                            {
                                CNComun.VerificaTextoMensajeError(ref Verificador);
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                            }
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                        }
                    }
                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                    }

                }
                else
                {
                    ConceptoPago objPago = new ConceptoPago();
                    objPago.IdFichaBancaria = Convert.ToInt32(hddnIdFichaRef.Value);
                    objPago.ImporteConcepto = Convert.ToDouble(hddnTotal.Value);
                    List<Bien> ListPDet = new List<Bien>();
                    lstBien = (List<Bien>)Session["Inventario"];
                    CNBien.EditarConceptoPago(objPago, ref Verificador);
                    //CNBien.EliminarDetalleConceptoPago(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador);
                    if (Verificador == "0")
                    {
                        Verificador = string.Empty;
                        CNBien.InsertarDetalleConceptoPago(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, ref lstBien);
                        if (Verificador == "0")
                        {
                            Verificador = string.Empty;
                            CNBien.EliminarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador);
                            if (Verificador == "0")
                            {
                                CNBien.InsertarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, lstBien);
                                if (Verificador == "0")
                                {
                                    //DDLTipoVenta.Enabled = false;
                                    //imgBttnBuscar.Enabled = false;
                                    //imgBttnCatClientes.Enabled = false;
                                    //txtClaveSysweb.Enabled = false;
                                    //grvInventario.Enabled = false;
                                    //grvInventarioAgregado.Enabled = false;
                                }
                                else
                                {
                                    CNComun.VerificaTextoMensajeError(ref Verificador);
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                                }
                            }
                        }
                        lblRefGenerada.Text = hddnReferencia.Value;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPago", "$('#modalPago').modal('show')", true);
                        //modalPagar.Show();
                    }
                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;

                    }

                }
                lblRefGen.Text = "REFERENCIA: " + hddnReferencia.Value;

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
            }

        }

        protected void ddlNivelBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            lblClienteNombre.Text = string.Empty;
            try
            {

                if (ddlNivelBusqueda.SelectedValue == "X")
                {
                    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Grid_Cat_Clientes", ref DDLCatClientes, "P_DEPENDENCIA", "P_NIVEL", "P_BUSQUEDA", DDLDependencia.SelectedValue, ddlNivelBusqueda.SelectedValue, "", "INGRESOS");
                    rowCliente.Visible = true;
                    rowAlumno.Visible = false;
                    //CargarGridClientes();
                    //rowBuscaAlumno.Visible = false;
                }
                else
                {
                    rowCliente.Visible = false;
                    rowAlumno.Visible = true;
                    //grvClientes.DataSource = null;
                    //grvClientes.DataBind();
                    //rowBuscaAlumno.Visible = true;
                }



                //    rowCliente.Visible = true;
                //    rowAlumno.Visible = false; 
                //}
                //else
                //{
                //    rowCliente.Visible = false;
                //    rowAlumno.Visible = true; 
                //}
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;

            }
        }


        //protected void DDLTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (DDLTipoVenta.SelectedValue == "ACT")
        //    {
        //        lblCtaMayor.Text = "Cta de Mayor:";
        //        CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cuentas_Mayor", ref DDLCtaMayor, ref lstCtasMayor, "INGRESOS");
        //        var lst = lstCtasMayor.Find(x => x.Etiqueta.Contains("1248"));
        //        string id = lst.IdStr;
        //        DDLCtaMayor.SelectedValue = id;
        //    }
        //    else
        //    {
        //        lblCtaMayor.Text = "Productos Varios:";
        //        CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Productos", ref DDLCtaMayor, "INGRESOS");
        //    }

        //    if (DDLTipoVenta.SelectedValue == "ACT" || DDLTipoVenta.SelectedValue == "LBT")
        //    {
        //        Session["Inventario"] = null;
        //        grvInventario.DataSource = null;
        //        grvInventario.DataBind();
        //        grvInventarioAgregado.DataSource = null;
        //        grvInventarioAgregado.DataBind();
        //    }

        //    lblTipoProd.Text = DDLTipoVenta.SelectedItem.Text;
        //    if (DDLTipoVenta.SelectedValue != "LBT")
        //    {
        //        DDLConceptos.SelectedValue = "4201";
        //        reqValObservaciones.Enabled = false;
        //    }
        //    else
        //        reqValObservaciones.Enabled = true;


        //    CargarGrid();
        //    //}
        //}
        protected void imgBttnBuscarCliente_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //BuscaCveCliente();
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivelE, "p_matricula", "p_sistema", txtClaveSysweb.Text.ToUpper(), "SIST_ING", "INGRESOS");
                if (ddlNivelE.Items.Count == 1)
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Dato no encontrado, si deseas registralo dar click por única vez.');", true); //lblMsj.Text = "Dato no encontrado, si deseas registralo dar click por única vez.";


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnCancelar_C_Click(object sender, EventArgs e)
        {
            //txtBuscaRef.Text = hddnReferencia.Value;
            //DDLTipoVenta.Enabled = true;
            //CargarGridInicio();
            //MultiView1.ActiveViewIndex = 1;
            //modalPagar.Hide();
        }

        protected void imgBttnPagoEfec_Click(object sender, ImageClickEventArgs e)
        {
            //string Conceptos = "L0606-RECUPERACION POR PRODUCCION 0AGRICOLAS Y GANADEROS";
            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000&TipoPersona=" + lblClienteNombre.Text + "&Referencia=" + hddnReferencia.Value + "&Total=" + hddnTotal.Value.TrimStart('$') + "&FInicial=21/03/2019&IdConcepto=" + Conceptos + "&Observaciones=Cliente UNACH";
            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPago", "$('#modalPago').modal('show')", true);

            string ruta;
            if (SesionUsu.Editar == 1)
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + hddnIdFichaRef.Value;
                //txtBuscaRef.Text = hddnReferencia.Value;
                //DDLTipoVenta.Enabled = true;
                CargarGridInicio();
                MultiView1.ActiveViewIndex = 1;

            }
            else
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
                string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                //string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPago", "$('#modalPago').modal('show')", true);

            }
        }
        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDatosFactura.PageIndex = 0;
            grdDatosFactura.PageIndex = e.NewPageIndex;
            CargarGridInicio();
        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;


            lblRefGenerada.Text = grdDatosFactura.SelectedRow.Cells[3].Text;
            linkPago.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPago", "$('#modalPago').modal('show')", true);


        }

        protected void btnVerFactRecibo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            CargarGrid("N");
        }

        protected void bttnGenerarRef_Click(object sender, EventArgs e)
        {
            //DDLTipoVenta.Enabled = true;
            //grvInventario.Enabled = true;
            Session["listaProductosAgregados"] = null;
            grvProductosAgregados.DataSource = null;
            grvProductosAgregados.DataBind();

            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Productos_Serv", ref DDLProductos, "p_dependencia", DDLDependencia.SelectedValue, ref lstProductos, "INGRESOS");
            Session["listaProductos"] = lstProductos;
            //if (SesionUsu.Usu_TipoUsu == 6)
            //{
            //    txtClaveSysweb.Text = SesionUsu.Usu_Nombre;
            //    imgBttnBuscar_Click(null, null);
            //}
            //else
            //    txtClaveSysweb.Text = string.Empty;
            grvClientes.DataSource = null;
            grvClientes.DataBind();

            lblClienteNombre.Text = string.Empty;

            ddlNivelBusqueda_SelectedIndexChanged(null, null);


            Session["Inventario"] = null;
            grvProductosAgregados.DataSource = null;
            grvProductosAgregados.DataBind();

            //grvInventario.DataSource = null;
            //grvInventario.DataBind();

            hddnIdFichaRef.Value = "0";
            hddnReferencia.Value = "0";
            hddnTotal.Value = "0";

            /*Se limpian valores para multipagos*/
            mp_account.Value = "0";
            mp_product.Value = "0";
            mp_order.Value = "0";
            mp_reference.Value = "0";
            mp_node.Value = "0";
            mp_concept.Value = "0";
            mp_amount.Value = "0";
            mp_customername.Value = "0";
            mp_currency.Value = "0";
            mp_signature.Value = "0";
            mp_urlsuccess.Value = "0";
            mp_urlfailure.Value = "0";
            /**/

            SesionUsu.Editar = 1;
            //DDLTipoVenta.SelectedValue = "0";
            ddlNivelE.Items.Clear();
            txtClaveSysweb.Text = string.Empty;
            lblClienteNombre.Text = string.Empty;
            lblRefGen.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            ddlNivelE.Items.Clear();
            //DDLConceptos.SelectedValue = "0";
            Iniciar();
            imgBttnBuscar_Click(null, null);

            MultiView1.ActiveViewIndex = 2;
        }


        protected void DDLUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLeyDependencia.Text = DDLDependencia.SelectedItem.Text;
            CargarGridInicio();


        }



        protected void bttnDetalle_Click(object sender, EventArgs e)
        {
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            CargarGridDetalle();
            modal.Show();
        }

        protected void btnCancelar_Detalle_Click(object sender, EventArgs e)
        {
            modal.Hide();
        }

        protected void bttnReimprimir_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;


            lblRefGenerada.Text = grdDatosFactura.SelectedRow.Cells[3].Text;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupPago", "$('#modalPago').modal('show')", true);

        }



        protected void bttnVerRecibo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;

            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "ObtenerQR(" + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text) + "," + Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[12].Text) + ");", true);



            //string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void bttnBuscaRef_Click(object sender, ImageClickEventArgs e)
        {
            CargarGridInicio();
        }


        protected void imgBttnPagoTDC_Click(object sender, ImageClickEventArgs e)
        {

            //mp_account.Value = "952";
            //mp_product.Value = "1";
            //mp_order.Value = hddnIdFichaRef.Value;
            //mp_reference.Value = hddnReferencia.Value;
            //mp_node.Value = "0";
            //mp_concept.Value = "99";
            //mp_amount.Value = string.Format("{0:0.00}", hddnTotal.Value);
            //mp_customername.Value = lblClienteNombre.Text;
            //mp_currency.Value = "1";
            //mp_signature.Value = CNComun.GetSHA256(Convert.ToString(mp_order.Value + mp_reference.Value + mp_amount.Value));
            //mp_urlsuccess.Value = "https://sysweb.unach.mx/Ingresos/Form/frmRefVenta_Pat.aspx"; //"Registro_Participantes_P7.aspx";
            //mp_urlfailure.Value = "https://sysweb.unach.mx/Ingresos/Form/frmRefVenta_Pat.aspx"; // "Registro_Participantes_P7.aspx";
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "PagBancomer();", true);
            if (SesionUsu.Editar == 1)
            {
                string Total = string.Format("{0:0.00}", hddnTotal.Value);
                string _open = "window.open('" + "https://sysweb.unach.mx/FichaReferenciada/Form/PagoenLinea.aspx?order_m=" + hddnIdFichaRef.Value + "&reference_m=" + hddnReferencia.Value + "&amount_m=" + Total + "&customername_m=" + lblClienteNombre.Text + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                int IdRef = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
                string Total = string.Format("{0:0.00}", grdDatosFactura.SelectedRow.Cells[5].Text);
                string nombre = grdDatosFactura.SelectedRow.Cells[6].Text;
                string _open = "window.open('" + "https://sysweb.unach.mx/FichaReferenciada/Form/PagoenLinea.aspx?order_m=" + grdDatosFactura.SelectedRow.Cells[0].Text + "&reference_m=" + grdDatosFactura.SelectedRow.Cells[3].Text + "&amount_m=" + Total + "&customername_m=" + grdDatosFactura.SelectedRow.Cells[6].Text + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }


        }
        protected void linkBttnPagoLinea_Click(object sender, EventArgs e)
        {

            int IdRef = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
            string Total = string.Format("{0:0.00}", grdDatosFactura.SelectedRow.Cells[5].Text);
            string nombre = grdDatosFactura.SelectedRow.Cells[6].Text;
            string _open = "window.open('" + "https://sysweb.unach.mx/FichaReferenciada/Form/PagoenLinea.aspx?order_m=" + grdDatosFactura.SelectedRow.Cells[0].Text + "&reference_m=" + grdDatosFactura.SelectedRow.Cells[3].Text + "&amount_m=" + Total + "&customername_m=" + grdDatosFactura.SelectedRow.Cells[6].Text + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void bttnEliminar_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            Verificador = string.Empty;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;
            int FichaBancaria = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
            CNBien.EliminarDetallePago_Ventas(FichaBancaria, ref Verificador);
            if (Verificador == "0")
            {
                CNBien.EliminarConceptoPago(FichaBancaria, ref Verificador);
                if (Verificador == "0")
                    CargarGridInicio();
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                }
            }

        }

        protected void btnCancelar_CatClientes_Click(object sender, EventArgs e)
        {
            //modalClientes.Hide();
        }

        protected void imgBttnCatClientes_Click(object sender, ImageClickEventArgs e)
        {
            //modalClientes.Show();
            CargarGridClientes();
        }

        protected void imgBttnBuscarCatCliente_Click(object sender, ImageClickEventArgs e)
        {
            //modalClientes.Show();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalCatClientes", "$('#modalCatClientes').modal('show')", true);
            CargarGridClientes();
        }

        protected void grvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modalClientes.Show();
            string Nombre;
            txtClaveSysweb.Text = grvClientes.SelectedRow.Cells[0].Text;
            Nombre = grvClientes.SelectedRow.Cells[1].Text.Replace("Á", "A");
            Nombre = grvClientes.SelectedRow.Cells[1].Text.Replace("É", "E");
            Nombre = grvClientes.SelectedRow.Cells[1].Text.Replace("Í", "I");
            Nombre = grvClientes.SelectedRow.Cells[1].Text.Replace("Ó", "O");
            Nombre = grvClientes.SelectedRow.Cells[1].Text.Replace("Ú", "U");
            lblClienteNombre.Text = Nombre;
            //CargarGridClientes();
            //imgBttnBuscarCliente_Click(null, null);
            //modalClientes.Hide();

        }

        protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //modalClientes.Show();
            grvClientes.PageIndex = 0;
            grvClientes.PageIndex = e.NewPageIndex;
            CargarGridClientes();
        }

        protected void btnAgregar_Cliente_Click(object sender, EventArgs e)
        {
            txtClaveSysweb.Text = grvClientes.SelectedRow.Cells[0].Text;
            imgBttnBuscarCliente_Click(null, null);
            //modalClientes.Hide();
        }



        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DDLGrupo = (DropDownList)sender;
            string Tipo = DDLGrupo.SelectedValue;
            ViewState["Filter"] = DDLGrupo.SelectedValue;
            CargarGrid("S");

        }

        protected void linkBttnBuscarInv_Click(object sender, EventArgs e)
        {
            CargarGrid("N");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //DDLTipoVenta.Enabled = true;
            CargarGridInicio();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {


            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP060&dependencia=" + DDLDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=S";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);


        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP060&dependencia=" + DDLDependencia.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void ddlNivelE_SelectedIndexChanged(object sender, EventArgs e)
        {
            CN_Alumno CNAlumno = new CN_Alumno();
            try
            {
                ObjMatricula.Matricula = txtClaveSysweb.Text.ToUpper();
                ObjMatricula.Evento = "ALUMNO";
                ObjMatricula.TipoPersona = 1;
                ObjMatricula.Nivel = ddlNivelE.SelectedValue;
                CNAlumno.ConsultarDatosAlumno(ref ObjMatricula, ref Verificador);
                if (Verificador == "0")
                {
                    //ddlDependencia_D.SelectedValue = ObjMatricula.Dependencia;
                    //ddlDependencia_D_SelectedIndexChanged(null, null);
                    //try
                    //{
                    //    ddlCarrera.SelectedValue = ObjMatricula.Carrera;
                    //}
                    //catch (Exception)
                    //{
                    //    ddlCarrera.SelectedValue = "000000";
                    //}
                    //ddlCarrera_SelectedIndexChanged(null, null);
                    //txtCarrera.Text = ObjMatricula.DescCarrera;
                    lblClienteNombre.Text = ObjMatricula.Nombre + ' ' + ObjMatricula.APaterno + ' ' + ObjMatricula.AMaterno;


                }
                else
                {
                    string MsjError = "Verifique matrícula(" + txtClaveSysweb.Text + ") y/ó Nivel de Estudios(" + ddlNivelE.SelectedItem.Text + ")";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + "La matrícula no corresponde a su Dependencia/Escuela/Facultad " + ex.Message + "');", true);  //lblMsjFam.Text = Verificador;
                                                                                                                                                                                                               //lblMsj.Text = "La matrícula no corresponde a su Dependencia/Escuela/Facultad "+ex.Message;
            }

        }

        protected void linkBttnNuevoCliente_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupEmp", "$('#modalAddClientes').modal('show')", true);
            ddlTipoCli.SelectedIndex = 0;
            txtNombreCliente.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        protected void linkBttnGenPDF_Click(object sender, EventArgs e)
        {
            string ruta;
            if (SesionUsu.Editar == 1)
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + hddnIdFichaRef.Value;
                //DDLTipoVenta.Enabled = true;
                CargarGridInicio();
                MultiView1.ActiveViewIndex = 1;

            }
            else
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
                string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }



        protected void ddlTipoCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupEmp", "$('#modalAddClientes').modal('show')", true);
            rowNombre.Visible = false;
            rowPaterno.Visible = false;
            rowMaterno.Visible = false;
            rowCorreo.Visible = false;
            rowGenero.Visible = false;
            if (ddlTipoCli.SelectedValue == "X")
            {
                rowNombre.Visible = true;
                rowCorreo.Visible = true;
                lblCliente.Text = "Cliente";
            }
            else
            {
                lblCliente.Text = "Nombre";
                rowCorreo.Visible = true;
                rowGenero.Visible = true;
                rowNombre.Visible = true;
                rowPaterno.Visible = true;
                rowMaterno.Visible = true;
            }
        }

        protected void linkBttnCatCliente_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupEmp", "$('#modalCatClientes').modal('show')", true);
        }
        protected void linBttnGuardarCliente_Click(object sender, EventArgs e)
        {
            Alumno ObjAlumno = new Alumno();
            CN_Alumno CNAlumno = new CN_Alumno();
            ObjAlumno.Matricula = string.Empty;
            ObjAlumno.Nombre = txtNombreCliente.Text;
            ObjAlumno.Semestre = "0";
            ObjAlumno.Grupo = "U";
            ObjAlumno.Carrera = "";
            ObjAlumno.DescCarrera = "";
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            ObjAlumno.Nivel = ddlTipoCli.SelectedValue;
            ObjAlumno.Dependencia = DDLDependencia.SelectedValue;
            ObjAlumno.Correo = txtCorreo.Text;
            if (ddlTipoCli.SelectedValue == "X")
            {

                ObjAlumno.APaterno = ".";
                ObjAlumno.AMaterno = "";
                ObjAlumno.Genero = Convert.ToChar("M");
            }
            else
            {
                ObjAlumno.APaterno = txtPaterno.Text;
                ObjAlumno.AMaterno = txtMaterno.Text;
                ObjAlumno.Genero = Convert.ToChar(rdoGenero.SelectedValue);
            }
            ObjAlumno.StatusMatricula = "A";

            try
            {

                Verificador = string.Empty;
                CNAlumno.AlumnoInsertar(ref ObjAlumno, ref Verificador);


                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupEmp", "$('#modalAddClientes').modal('hide')", true);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos han sido modificados correctamente');", true); //lblMensaje.Text = "Los datos han sido modificados correctamente";
                    if (ddlNivelBusqueda.SelectedValue == "X")
                        CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Grid_Cat_Clientes", ref DDLCatClientes, "P_DEPENDENCIA", "P_NIVEL", "P_BUSQUEDA", DDLDependencia.SelectedValue, ddlNivelBusqueda.SelectedValue, "", "INGRESOS");

                    //CargarGridClientes();
                    //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Grid_Cat_Clientes", ref DDLCatClientes, "P_DEPENDENCIA", "P_NIVEL", "P_BUSQUEDA", DDLDependencia.SelectedValue, ddlNivelBusqueda.SelectedValue, "", "INGRESOS");
                }

                else
                {
                    lblErrorReg.Text = Verificador;
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 40) + "');", true);  //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblErrorReg.Text = ex.Message;
            }
        }

        protected void linkBttnBuscCli_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                CargarGridClientes();
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }


        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //BuscaCveCliente();
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivelE, "p_matricula", "p_sistema", txtClaveSysweb.Text.ToUpper(), "SIST_ING", "INGRESOS");
                if (ddlNivelE.Items.Count == 1)
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Dato no encontrado, si deseas registralo dar click por única vez.');", true); //lblMsj.Text = "Dato no encontrado, si deseas registralo dar click por única vez.";


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        protected void DDLCatClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCatClientes.SelectedValue == "0")
                lblClienteNombre.Text = string.Empty;
            else
                lblClienteNombre.Text = DDLCatClientes.SelectedItem.Text;
        }

        protected void linkBttnGenLink_Click(object sender, EventArgs e)
        {
            //LinkButton cbi = (LinkButton)(sender);
            //GridViewRow row = (GridViewRow)cbi.NamingContainer;
            //grdDatosFactura.SelectedIndex = row.RowIndex;

            string cadena = string.Empty;
            int id_referencia = Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
            string referencia = grdDatosFactura.SelectedRow.Cells[3].Text;
            try
            {
                cadena = CN_Token.GenerarToken(id_referencia, referencia);
                linkPago.Text = "https://sysweb.unach.mx/FichaReferenciada/Form/PagoExclusivoSYSWEB.aspx?sw_acc=" + cadena;
            }
            catch (Exception ex)
            {

            }
        }

        protected void linkBttnBuscarRef_Click(object sender, EventArgs e)
        {
            CargarGridInicio();
        }

        protected void DDLProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["listaProductos"] != null)
            {
                lstProductos = (List<Comun>)Session["listaProductos"];
                Session["Inventario"] = lstProductos;
                txtPrecio.Text = lstProductos[DDLProductos.SelectedIndex].EtiquetaDos;
                if (lstProductos[DDLProductos.SelectedIndex].EtiquetaDos == "0")
                    txtPrecio.Enabled = true;
                else
                    txtPrecio.Enabled = false;
                txtCantidad_Prod.Focus();
            }
        }

        protected void linkBttnAgregarProd_Click(object sender, EventArgs e)
        {
            Bien objBien = new Bien();
            try
            {
                if (Session["listaProductos"] != null)
                {
                    lstProductos = (List<Comun>)Session["listaProductos"];
                    if (txtPrecio.Text != null)
                    {
                        objBien.Costo = Convert.ToDouble(txtPrecio.Text);
                        objBien.Unidad_Medida = DDLUnidadMedidaProd.SelectedValue;
                        objBien.Cantidad = Convert.ToDouble(txtCantidad_Prod.Text);
                        objBien.Clave = DDLProductos.SelectedValue;
                        objBien.Descripcion = DDLProductos.SelectedItem.Text;
                        objBien.Unidad_Medida = DDLUnidadMedidaProd.SelectedValue;
                        objBien.Tipo = lstProductos[DDLProductos.SelectedIndex].EtiquetaTres;
                        objBien.Id_Inventario = lstProductos[DDLProductos.SelectedIndex].EtiquetaCuatro;
                        objBien.Id_Concepto = Convert.ToInt32(lstProductos[DDLProductos.SelectedIndex].EtiquetaCinco);
                        if (txtPrecio.Text != null && txtCantidad_Prod.Text != null)
                            objBien.Total = objBien.Cantidad * objBien.Costo;


                        if (Session["listaProductosAgregados"] != null)
                            lstProductosAgregados = (List<Bien>)Session["listaProductosAgregados"];

                        lstProductosAgregados.Add(objBien);
                        Session["listaProductosAgregados"] = lstProductosAgregados;
                        CargarGridProductos();
                    }
                }
                else
                {
                    MultiView1.ActiveViewIndex = 1;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Ocurrio un error, debera realizar el registro nuevamente.');", true); //lblMsj.Text = ex.Message;
                }

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnPagar_Click(object sender, EventArgs e)
        {
            ObjFichaReferenciada.IdFichaBancaria = GetID("FichaRef");         
            CNBien.InsertarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);
            if (Verificador == "0")
            {
                List<Bien> ListPDet = new List<Bien>();
                lstProductosAgregados = (List<Bien>)Session["listaProductosAgregados"];
                CNBien.InsertarDetalleConceptoPago(Convert.ToInt32(ObjFichaReferenciada.IdFichaBancaria), ref Verificador, ref lstProductosAgregados);
                if (Verificador == "0")
                {
                    Verificador = string.Empty;
                    CNBien.InsertarDetallePago_Ventas(ObjFichaReferenciada.IdFichaBancaria, ref Verificador, lstProductosAgregados);
                    if (Verificador == "0")
                    {
                        lblRefGenerada.Text = hddnReferencia.Value;
                        CargarGridInicio();
                        MultiView1.ActiveViewIndex = 1;
                    }
                    else
                    {
                        CNComun.VerificaTextoMensajeError(ref Verificador);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                    }
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                }
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
            }

        }


    }
}