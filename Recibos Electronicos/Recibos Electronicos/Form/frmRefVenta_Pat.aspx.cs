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
    public partial class frmRefVenta_Pat : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Usuario Usuario = new Usuario();
        Factura ObjFactura = new Factura();

        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Comun CNComun = new CN_Comun();
        CN_Bien CNBien = new CN_Bien();
        CN_Alumno CNCliente =new CN_Alumno();
        CN_Factura CNFactura = new CN_Factura();


        string Verificador = string.Empty;
        string WXI = string.Empty;
        List<Bien>lstBien = new List<Bien>();
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
            //MultiView1.ActiveViewIndex = 1;
            if (DDLTipoVenta.SelectedValue == "ACT")
            {
                lblCtaMayor.Text = "Cta de Mayor:";
                CNComun.LlenaCombo("PKG_CONTABILIDAD.Obt_Combo_Cuentas_Mayor", ref DDLCtaMayor, ref lstCtasMayor, "INGRESOS");
                var lst = lstCtasMayor.Find(x => x.Etiqueta.Contains("1248"));
                string id = lst.IdStr;
                DDLCtaMayor.SelectedValue = id;
            }
            else
            {
                lblCtaMayor.Text = "Productos Varios:";
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Productos", ref DDLCtaMayor, "INGRESOS");
            }
        }

        private void BindGrupo(DropDownList DDLGrupo)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_GrupoServicio", ref DDLGrupo, "p_dependencia", "p_tipo_venta",  DDLDependencia.SelectedValue, DDLTipoVenta.SelectedValue, "INGRESOS");
                //DDLGrupo.SelectedIndex = 0;
                //DDLGrupo.Items.Remove(ddlTipo.Items.FindByValue("ACT"));
                DDLGrupo.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
            }
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
                CNComun.LlenaComboG("pkg_pagos_2016.Obt_Combo_Tipo_Ventas", ref DDLTipoVenta, ref lstBienGrupo, "INGRESOS");


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridInicio()
        {
            Int32[] Celdas1;
            if (SesionUsu.Usu_TipoUsu==6)
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
            grvInventario.DataSource = null;
            grvInventario.DataBind();
            if(Filtro=="N")
                ViewState["Filter"] = "T";


            try
            {
                DataTable dt = new DataTable();
                grvInventario.DataSource = dt;
                grvInventario.DataSource = GetList(Filtro);
                grvInventario.DataBind();
                if (grvInventario.Rows.Count >= 1)
                {
                    DropDownList DDLGrupo = (DropDownList)grvInventario.HeaderRow.FindControl("ddlGrupo");
                    if (DDLTipoVenta.SelectedValue == "LBT" || DDLTipoVenta.SelectedValue == "CONSULTA" || DDLTipoVenta.SelectedValue == "SERVICIO")
                        this.BindGrupo(DDLGrupo);
                    else
                        DDLGrupo.Visible = false;
                }

                if (grvInventario.Rows.Count > 0)
                {
                    //if (DDLTipoVenta.SelectedValue == "PPE" || DDLTipoVenta.SelectedValue == "PAG" || DDLTipoVenta.SelectedValue == "LBT")
                    if (DDLTipoVenta.SelectedValue != "ACT" || (DDLTipoVenta.SelectedValue == "LBT" || DDLTipoVenta.SelectedValue == "CONSULTA" || DDLTipoVenta.SelectedValue == "SERVICIO"))
                    {
                        int[] Celdas2 = { 0, 1, 3, 6, 7, 8 };
                        for (int i = 0; i < Celdas2.Length; i++)
                        {
                            grvInventario.HeaderRow.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            //DropDownList DDLFechaPago = (DropDownList)grvInventario.HeaderRow.FindControl("DDLSubTipoVenta");
                            foreach (GridViewRow row in grvInventario.Rows)
                            {
                                row.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            }
                        }

                    }
                    else
                    {
                        int[] Celdas1 = { 6, 7, 8 };
                        CNComun.HideColumns(grvInventario, Celdas1);
                    }
                }
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

        private void CargarGridAgregados(List<Bien>lstBien)
        {

            grvInventarioAgregado.DataSource = null;
            grvInventarioAgregado.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvInventarioAgregado.DataSource = dt;
                grvInventarioAgregado.DataSource = lstBien;
                grvInventarioAgregado.DataBind();
                double Total=0;

                if (grvInventarioAgregado.Rows.Count > 0)
                {
                    if (DDLTipoVenta.SelectedValue == "ACT" /*|| DDLTipoVenta.SelectedValue == "LBT"*/)
                    {
                        int[] Celdas1 = { 5,6,7,10,11,12,13,14 };
                        for (int i = 0; i < Celdas1.Length; i++)
                        {
                            grvInventarioAgregado.HeaderRow.Cells[Convert.ToInt32(Celdas1.GetValue(i))].Visible = false;
                            grvInventarioAgregado.FooterRow.Cells[Convert.ToInt32(Celdas1.GetValue(i))].Visible = false;

                            foreach (GridViewRow row in grvInventarioAgregado.Rows)
                            {
                                row.Cells[Convert.ToInt32(Celdas1.GetValue(i))].Visible = false;
                            }
                        }
                        Total = lstBien.Sum(x => Convert.ToDouble(x.Costo));

                    }
                    else if (DDLTipoVenta.SelectedValue == "LBT" || DDLTipoVenta.SelectedValue == "CONSULTA" || DDLTipoVenta.SelectedValue == "SERVICIO")
                    {
                        int[] Celdas2 = { 0, 1, 3, 10, 11, 12, 13, 14 };
                        double GranTotal = 0;
                        for (int i = 0; i < Celdas2.Length; i++)
                        {
                            grvInventarioAgregado.HeaderRow.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            grvInventarioAgregado.FooterRow.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            //grvInventarioAgregado.HeaderRow.Cells[4].Text = "CANTIDAD";
                            //grvInventarioAgregado.HeaderRow.Cells[6].Text = "COSTO";
                            foreach (GridViewRow row in grvInventarioAgregado.Rows)
                            {
                                row.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            }
                        }
                        

                        foreach (GridViewRow row in grvInventarioAgregado.Rows)
                        {
                            //row.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            DropDownList ddl = row.FindControl("DDLUnidadMedida") as DropDownList;
                                ddl.SelectedValue = row.Cells[11].Text;
                                if (ddl.SelectedValue == "0")
                                    ddl.SelectedValue = "4";

                                TextBox txt = row.FindControl("txtCantidad") as TextBox;
                                txt.Text = row.Cells[12].Text;
                                if (txt.Text == "0")
                                    txt.Text = "1";

                                if (txt.Text==string.Empty)                                
                                    txt.Text = "1";

                                Label lbl = row.FindControl("lblTotU") as Label;
                                if (row.Cells[4].Text != "0")
                                    if (row.Cells[4].Text != string.Empty)
                                        if (row.Cells[4].Text != "")
                                        {
                                            lbl.Text = Convert.ToString(Convert.ToInt32(row.Cells[4].Text) * Convert.ToInt32(txt.Text));
                                            GranTotal = GranTotal + Convert.ToDouble(Convert.ToInt32(row.Cells[4].Text) * Convert.ToInt32(txt.Text));

                                        }

                            }
                        

                        Total = GranTotal; //lstBien.Sum(x => Convert.ToDecimal(x.Total));


                    }


                    else
                    {
                        int[] Celdas2 = { 0, 1, 3, 10, 11,12,13,14 };
                        for (int i = 0; i < Celdas2.Length; i++)
                        {
                            grvInventarioAgregado.HeaderRow.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            grvInventarioAgregado.FooterRow.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                            grvInventarioAgregado.HeaderRow.Cells[4].Text = "CANTIDAD";
                            grvInventarioAgregado.HeaderRow.Cells[6].Text = "COSTO";

                            foreach (GridViewRow row in grvInventarioAgregado.Rows)
                            {
                                row.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                                DropDownList ddl = row.FindControl("DDLUnidadMedida") as DropDownList;
                                ddl.SelectedValue = row.Cells[11].Text;

                                TextBox txt = row.FindControl("txtCantidad") as TextBox;
                                txt.Text = row.Cells[12].Text;

                                Label lbl = row.FindControl("lblTotU") as Label;
                                lbl.Text = row.Cells[10].Text;

                            }
                        }
                        Total = lstBien.Sum(x => Convert.ToDouble(x.Total));


                    }

                    
                    Label lblTot = (Label)grvInventarioAgregado.FooterRow.FindControl("lblTotal");
                    lblTot.Text = Convert.ToString(Total.ToString("C"));
                    hddnTotal.Value = Convert.ToString(Total);
                    if (hddnTotal.Value != "0")
                    {
                        Button btnPagar = (Button)grvInventarioAgregado.HeaderRow.FindControl("bttnPagar");
                        btnPagar.Enabled = true;
                        btnPagar.CssClass = "btn5";
                        btnPagar.ToolTip = string.Empty;
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }
        private List<Bien> GetList(string Filtro)
        {
            try
            {
                List<Bien> List = new List<Bien>();
                Bien Parametros = new Bien();
                if (DDLTipoVenta.SelectedValue == "ACT")
                {
                    if(lstCtasMayor.Count == 0) //if (lstCtasMayor[DDLCtaMayor.SelectedIndex].Etiqueta == null)
                            Parametros.Cta_Mayor = "0";
                    else
                        Parametros.Cta_Mayor = lstCtasMayor[DDLCtaMayor.SelectedIndex].Etiqueta;
                }
                else
                    Parametros.Cta_Mayor = "0";

                Parametros.Dependencia = DDLDependencia.SelectedValue;
                Parametros.Estatus = "A";
                if(Filtro=="S")
                    CNBien.ConsultarGrid(DDLTipoVenta.SelectedValue, Parametros, txtBusqueda.Text.ToUpper(), ViewState["Filter"].ToString(), ref List);
                else
                    CNBien.ConsultarGrid(DDLTipoVenta.SelectedValue, Parametros, txtBusqueda.Text.ToUpper(), "T", ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                CNFactura.FacturaProductosConsultaGrid(DDLDependencia.SelectedValue, DDLPagado.SelectedValue, txtFecha_Factura_Ini.Text, txtFecha_Factura_Fin.Text, txtBuscaRef.Text, SesionUsu.Usu_TipoUsu, SesionUsu.Usu_Nombre, ref List);                
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
                CNCliente.ConsultarCatClientes(ref objCliente, txtBuscaCliente.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void BuscaCveCliente()
        {
            lblClienteNombre.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                ObjMatricula.Matricula = txtClaveSysweb.Text.ToUpper();
                ObjMatricula.Dependencia = DDLDependencia.SelectedValue;
                //ObjMatricula.Evento = "ALUMNO";
                //ObjMatricula.TipoPersona = 1;
                //ObjMatricula.Nivel = "X";
                CNCliente.ConsultarCliente(ref ObjMatricula, ref Verificador);
                if (Verificador == "0")
                {
                    lblClienteNombre.Text = ObjMatricula.Nombre + ' ' + ObjMatricula.APaterno + ' ' + ObjMatricula.AMaterno;
                }
                else
                    lblClienteNombre.Text = "El # de cliente ingresado no existe, verificar.";


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private int GetID(string Tipo)
        {
            int ID = 0;
            try
            {
                ObjFichaReferenciada = new FichaReferenciada();
                CNBien.GenerarID(ref ObjFichaReferenciada);
                ID = ObjFichaReferenciada.IdFichaBancaria;
                if (Tipo=="FichaRef")
                    hddnIdFichaRef.Value = Convert.ToString(ObjFichaReferenciada.IdFichaBancaria);

            }
            catch (Exception ex)
            {
                string MsjError= ex.Message;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPopoverPDF();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "PopExcel", "openPopoverEXCEL();", true);

            if (!IsPostBack)
            {
                ViewState["Filter"] = "T";

                Session["Inventario"] = null;
                hddnIdFichaRef.Value = "0";
                //lblTotal.Text = string.Empty;
                hddnTotal.Value = "0";
                Cargarcombos();
                txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
                txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarGridInicio();
                MultiView1.ActiveViewIndex = 1;

                //DDLTipoVenta_SelectedIndexChanged(null, null);

            }
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid("N");
        }

        protected void grvInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (DDLTipoVenta.SelectedValue != "0")
            {
            
                Bien objBien = new Bien();
                List<Bien> lstBien = new List<Bien>();
                objBien.Tipo = DDLTipoVenta.SelectedValue; // lstBienGrupo[DDLTipoVenta.SelectedIndex].Clasificacion;// DDLTipoVenta.DataGroupField; //DDLTipoVenta.SelectedValue;
                objBien.TipoGrupo = lstBienGrupo[DDLTipoVenta.SelectedIndex].Clasificacion;// DDLTipoVenta.DataGroupField; //DDLTipoVenta.SelectedValue;
                objBien.Producto = grvInventario.SelectedRow.Cells[7].Text.Replace("Ñ", "NI");
                objBien.Id_Inventario = Convert.ToString(grvInventario.SelectedRow.Cells[6].Text);
                objBien.No_Inventario = grvInventario.SelectedRow.Cells[0].Text;
                objBien.Clave = grvInventario.SelectedRow.Cells[1].Text.Replace("&#209;", "NI");
                objBien.Clave = objBien.Clave.Replace("&nbsp;", " ");
                objBien.Descripcion = grvInventario.SelectedRow.Cells[7].Text;
                objBien.Id_Concepto =Convert.ToInt32(grvInventario.SelectedRow.Cells[8].Text);
                

                objBien.Poliza = grvInventario.SelectedRow.Cells[3].Text;
                objBien.Costo = Convert.ToDouble(grvInventario.SelectedRow.Cells[4].Text);
                objBien.Total = Convert.ToDouble(grvInventario.SelectedRow.Cells[4].Text);
                if (Convert.ToDouble(grvInventario.SelectedRow.Cells[4].Text) == 0)
                {
                    objBien.Unidad_Medida = "0";
                    objBien.Cantidad = 0;
                }

                else
                {
                    objBien.Unidad_Medida = "1";
                    objBien.Cantidad = 1;
                }

                if (Session["Inventario"] != null)
                {
                    lstBien = (List<Bien>)Session["Inventario"];
                    var lst = lstBien.Find(x => x.Id_Inventario.Contains(objBien.Id_Inventario));
                    if (DDLTipoVenta.SelectedValue == "ACT")
                    {
                        if (lst != null)
                            lblError.Text = "Ya existe este número de Inventario, verificar.";
                        else
                            lstBien.Add(objBien);

                    }
                    else
                        lstBien.Add(objBien);


                }
                else
                    lstBien.Add(objBien);

                //lstBien.Add(objBien);
                Session["Inventario"] = lstBien;
                CargarGridAgregados(lstBien);
            }
            else
                lblError.Text = "Debes seleccionar un tipo de venta.";
        }

        protected void grvInventarioAgregado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblError.Text = string.Empty;
            List<Bien> lstBien = new List<Bien>();
            lstBien = (List<Bien>)Session["Inventario"];

            int fila = e.RowIndex;
            int pagina = grvInventarioAgregado.PageSize * grvInventarioAgregado.PageIndex;
            fila = pagina + fila;


            //grvInventario_PageIndexChanging(null, null);
            GridViewRow row = grvInventarioAgregado.Rows[e.RowIndex]; 
            double Costo = 0;
            if (((TextBox)(row.Cells[4].Controls[0])).Text == null || ((TextBox)(row.Cells[4].Controls[0])).Text == string.Empty)
                lstBien[fila].Costo = 0;
            else {
                lstBien[fila].Costo = Convert.ToDouble(((TextBox)(row.Cells[4].Controls[0])).Text);
                Costo = Convert.ToDouble(((TextBox)(row.Cells[4].Controls[0])).Text);
            }

            DropDownList ddl = (DropDownList)(row.Cells[5].FindControl("DDLUnidadMedida"));
            TextBox txt = (TextBox)(row.Cells[6].FindControl("txtCantidad"));
            if (DDLTipoVenta.SelectedValue == "LBT" || DDLTipoVenta.SelectedValue == "CONSULTA" || DDLTipoVenta.SelectedValue == "SERVICIO")
            {                
                
                double Cantidad = Convert.ToDouble(txt.Text);
                double Tot = Costo * Cantidad;
                if (ddl.SelectedValue != "0")
                {
                    if (Tot > 0)
                    {
                        Label lbl = (Label)(row.Cells[7].FindControl("lblTotU"));
                        lbl.Text = Convert.ToString(Tot);

                    }
                    lstBien[fila].Unidad_Medida = ddl.SelectedValue;
                    lstBien[fila].Total = Convert.ToDouble(Tot);
                    lstBien[fila].Cantidad = Cantidad;
                    lstBien[fila].Costo = Costo;
                    grvInventarioAgregado.EditIndex = -1;
                    Session["Inventario"] = lstBien;
                    CargarGridAgregados(lstBien);


                }
                else
                {
                    lblError.Text = "Debe seleccionar una Unidad de Medida.";
                    
                }

            }
            else
            {
                lstBien[fila].Unidad_Medida = ddl.SelectedValue;
                lstBien[fila].Total = Convert.ToDouble(txt.Text)*Costo;
                lstBien[fila].Cantidad = Convert.ToDouble(txt.Text);
                lstBien[fila].Costo = Costo;
                grvInventarioAgregado.EditIndex = -1;
                Session["Inventario"] = lstBien;
                CargarGridAgregados(lstBien);



            }



            //grvInventarioAgregado.EditIndex = -1;
            //Session["Inventario"] = lstBien;
            //CargarGridAgregados(lstBien);
        }
        //protected void grvInventarioAgregado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    lblError.Text = string.Empty;
        //    List<Bien> lstBien = new List<Bien>();
        //    lstBien = (List<Bien>)Session["Inventario"];

        //    int fila = e.RowIndex;
        //    int pagina = grvInventarioAgregado.PageSize * grvInventarioAgregado.PageIndex;
        //    fila = pagina + fila;


        //    GridViewRow row = grvInventarioAgregado.Rows[e.RowIndex];  //grvInventarioAgregado.Rows[e.RowIndex];


        //    double Costo = 0;
        //    if (((TextBox)(row.Cells[4].Controls[0])).Text == null || ((TextBox)(row.Cells[4].Controls[0])).Text == string.Empty)
        //        lstBien[e.RowIndex].Costo = 0;
        //    else {
        //        lstBien[e.RowIndex].Costo = Convert.ToDouble(((TextBox)(row.Cells[4].Controls[0])).Text);
        //        Costo = Convert.ToDouble(((TextBox)(row.Cells[4].Controls[0])).Text);
        //    }

        //    DropDownList ddl = (DropDownList)(row.Cells[5].FindControl("DDLUnidadMedida"));
        //    TextBox txt = (TextBox)(row.Cells[6].FindControl("txtCantidad"));
        //    if (DDLTipoVenta.SelectedValue == "LBT")
        //    {

        //        double Cantidad = Convert.ToDouble(txt.Text);
        //        double Tot = Costo * Cantidad;
        //        if (ddl.SelectedValue != "0")
        //        {
        //            if (Tot > 0)
        //            {
        //                Label lbl = (Label)(row.Cells[7].FindControl("lblTotU"));
        //                lbl.Text = Convert.ToString(Tot);

        //            }
        //            lstBien[e.RowIndex].Unidad_Medida = ddl.SelectedValue;
        //            lstBien[e.RowIndex].Total = Convert.ToDouble(Tot);
        //            lstBien[e.RowIndex].Cantidad = Cantidad;
        //            lstBien[e.RowIndex].Costo = Costo;
        //            grvInventarioAgregado.EditIndex = -1;
        //            Session["Inventario"] = lstBien;
        //            CargarGridAgregados(lstBien);


        //        }
        //        else
        //        {
        //            lblError.Text = "Debe seleccionar una Unidad de Medida.";

        //        }

        //    }
        //    else
        //    {
        //        lstBien[e.RowIndex].Unidad_Medida = ddl.SelectedValue;
        //        lstBien[e.RowIndex].Total = Convert.ToDouble(txt.Text) * Costo;
        //        lstBien[e.RowIndex].Cantidad = Convert.ToDouble(txt.Text);
        //        lstBien[e.RowIndex].Costo = Costo;
        //        grvInventarioAgregado.EditIndex = -1;
        //        Session["Inventario"] = lstBien;
        //        CargarGridAgregados(lstBien);



        //    }



        //    //grvInventarioAgregado.EditIndex = -1;
        //    //Session["Inventario"] = lstBien;
        //    //CargarGridAgregados(lstBien);
        //}

        protected void grvInventarioAgregado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvInventarioAgregado.EditIndex = e.NewEditIndex;
            List<Bien> lstBien = new List<Bien>();
            lstBien = (List<Bien>)Session["Inventario"];
            CargarGridAgregados(lstBien);
            ((DropDownList)grvInventarioAgregado.Rows[e.NewEditIndex].FindControl("DDLUnidadMedida")).Enabled = true;
            ((TextBox)grvInventarioAgregado.Rows[e.NewEditIndex].FindControl("txtCantidad")).Enabled = true;

        }

        protected void grvInventarioAgregado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Bien> ListPDet = new List<Bien>();
            lstBien = (List<Bien>)Session["Inventario"];
            grvInventarioAgregado.EditIndex = -1;
            CargarGridAgregados(lstBien);
        }

        protected void grvInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvInventario.PageIndex = 0;
            grvInventario.PageIndex = e.NewPageIndex;

            CargarGrid("N");
        }

        protected void grvInventarioAgregado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvInventarioAgregado.PageIndex = 0;
            grvInventarioAgregado.PageIndex = e.NewPageIndex;
            List<Bien> ListPDet = new List<Bien>();
            lstBien = (List<Bien>)Session["Inventario"];
            CargarGridAgregados(lstBien);
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
                    ObjFichaReferenciada.NoControl = txtClaveSysweb.Text.ToUpper();
                    ObjFichaReferenciada.Nivel = "L";
                    ObjFichaReferenciada.Dependencia = DDLDependencia.SelectedValue;
                    ObjFichaReferenciada.Carrera = "000000";
                    ObjFichaReferenciada.Nombre = lblClienteNombre.Text;

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
                                DDLTipoVenta.Enabled = false;
                                //imgBttnBuscar.Enabled = false;
                                //imgBttnCatClientes.Enabled = false;
                                //txtClaveSysweb.Enabled = false;
                                //grvInventario.Enabled = false;
                                //grvInventarioAgregado.Enabled = false;
                                lblRefGenerada.Text = hddnReferencia.Value;
                                modalPagar.Show();
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
                                    DDLTipoVenta.Enabled = false;
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
                        modalPagar.Show();
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

        //protected void bttnPagar_Click(object sender, EventArgs e)
        //{
        //    //if (hddnIdFichaRef.Value == "0")
        //    lblError.Text = string.Empty;
        //    Verificador = string.Empty;
        //    lblRefGen.Text = string.Empty;
        //    try
        //    {
        //        if (hddnIdFichaRef.Value == "0")
        //        {
        //            ObjFichaReferenciada.IdFichaBancaria = GetID("FichaRef");
        //            ObjFichaReferenciada.NoControl = txtClaveSysweb.Text;
        //            ObjFichaReferenciada.Nivel = "L";
        //            ObjFichaReferenciada.Dependencia = DDLDependencia.SelectedValue;
        //            ObjFichaReferenciada.Carrera = "000000";
        //            ObjFichaReferenciada.Nombre = lblClienteNombre.Text;

        //            ObjFichaReferenciada.Vigencia = 7;
        //            ObjFichaReferenciada.Importetotal = Convert.ToDouble(hddnTotal.Value);
        //            ObjFichaReferenciada.CicloEscolar = 20;
        //            ObjFichaReferenciada.Referencia = GetReferencia();
        //            ObjFichaReferenciada.ConceptoRef = txtObservaciones.Text.ToUpper();
        //            ObjFichaReferenciada.Grupo = "U";
        //            ObjFichaReferenciada.Semestre = "0";
        //            ObjFichaReferenciada.Evento = "ADMON"; //(DDLTipoVenta.SelectedValue == "1") ? "201800072" : "";
        //            ObjFichaReferenciada.Referencia = hddnReferencia.Value;
        //            ObjFichaReferenciada.Usuario = "VENTA_PRODUCTOS";
        //            ObjFichaReferenciada.UsuarioRegistra = SesionUsu.Usu_Nombre;
        //            CNBien.InsertarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);
        //            if (Verificador == "0")
        //            {
        //                List<ConceptoPago> lstConceptos = new List<ConceptoPago>();
        //                ConceptoPago objPago = new ConceptoPago();
        //                objPago.Id = GetID("FichaRefConceptos");
        //                objPago.IdFichaBancaria = Convert.ToInt32(hddnIdFichaRef.Value);
        //                objPago.IdConcepto = Convert.ToInt32(DDLConceptos.SelectedValue);
        //                objPago.ImporteConcepto = Convert.ToDouble(hddnTotal.Value);
        //                objPago.Anexo = "";
        //                lstConceptos.Add(objPago);
        //                CNBien.InsertarConceptoPago(ref Verificador, ref lstConceptos);
        //                if (Verificador == "0")
        //                {
        //                    Verificador = string.Empty;
        //                    List<Bien> ListPDet = new List<Bien>();
        //                    lstBien = (List<Bien>)Session["Inventario"];
        //                    CNBien.InsertarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, lstBien);
        //                    if (Verificador == "0")
        //                    {
        //                        lblRefGenerada.Text = hddnReferencia.Value;
        //                        modalPagar.Show();
        //                    }
        //                    else
        //                    {
        //                        CNComun.VerificaTextoMensajeError(ref Verificador);
        //                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
        //                    }
        //                }
        //                else
        //                {
        //                    CNComun.VerificaTextoMensajeError(ref Verificador);
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
        //                }
        //            }
        //            else
        //            {
        //                CNComun.VerificaTextoMensajeError(ref Verificador);
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
        //            }

        //        }
        //        else
        //        {
        //            ConceptoPago objPago = new ConceptoPago();
        //            objPago.IdFichaBancaria = Convert.ToInt32(hddnIdFichaRef.Value);
        //            objPago.ImporteConcepto = Convert.ToDouble(hddnTotal.Value);
        //            CNBien.EditarConceptoPago(objPago, ref Verificador);
        //            if (Verificador == "0")
        //            {
        //                Verificador = string.Empty;
        //                List<Bien> ListPDet = new List<Bien>();
        //                lstBien = (List<Bien>)Session["Inventario"];
        //                CNBien.EliminarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador);
        //                if (Verificador == "0")
        //                {
        //                    CNBien.InsertarDetallePago_Ventas(Convert.ToInt32(hddnIdFichaRef.Value), ref Verificador, lstBien);
        //                    if (Verificador == "0")
        //                    {
        //                        //lblRefGen.Text = hddnReferencia.Value;
        //                        //lblRefGenerada.Text = hddnReferencia.Value;
        //                        modalPagar.Show();
        //                    }
        //                    else
        //                    {
        //                        CNComun.VerificaTextoMensajeError(ref Verificador);
        //                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
        //                    }
        //                }
        //            }
        //            lblRefGenerada.Text = hddnReferencia.Value;
        //            modalPagar.Show();
        //        }
        //        lblRefGen.Text = "REFERENCIA: " + hddnReferencia.Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        string MsjError = ex.Message;
        //        CNComun.VerificaTextoMensajeError(ref MsjError);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
        //    }

        //}


        protected void DDLTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (DDLTipoVenta.SelectedValue != "LBT")
                //{
                //    DDLConceptos.SelectedValue = "4201";
                //    reqValObservaciones.Enabled = false;
                //}
                //else
                //    reqValObservaciones.Enabled = true;



                if (grvInventarioAgregado.Rows.Count >= 1)
                {
                    lstBien = (List<Bien>)Session["Inventario"];
                    var existe = lstBien.Find(x => x.TipoGrupo.Contains(lstBienGrupo[DDLTipoVenta.SelectedIndex].Clasificacion));
                    if (existe == null)//(DDLTipoVenta.SelectedValue == "ACT" || DDLTipoVenta.SelectedValue == "LBT"))
                        modalTipo.Show();
                    else
                        CargarGrid("N");
                }
                else
                {
                    CargarGrid("N");
                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true); //lblMsj.Text = ex.Message;

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
                    CNComun.LlenaLista("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivel, "p_matricula", "p_sistema", txtClaveSysweb.Text.ToUpper(), "SIST_ING", "INGRESOS");
                    if (ddlNivel.Items.Count == 1)                    
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
            txtBuscaRef.Text = hddnReferencia.Value;
            DDLTipoVenta.Enabled = true;
            CargarGridInicio();
            MultiView1.ActiveViewIndex = 1;
            modalPagar.Hide();
        }

        protected void imgBttnPagoEfec_Click(object sender, ImageClickEventArgs e)
        {
            //string Conceptos = "L0606-RECUPERACION POR PRODUCCION 0AGRICOLAS Y GANADEROS";
            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000&TipoPersona=" + lblClienteNombre.Text + "&Referencia=" + hddnReferencia.Value + "&Total=" + hddnTotal.Value.TrimStart('$') + "&FInicial=21/03/2019&IdConcepto=" + Conceptos + "&Observaciones=Cliente UNACH";
            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);


            
            string ruta;
            if (SesionUsu.Editar == 1)
            {
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + hddnIdFichaRef.Value;
                txtBuscaRef.Text = hddnReferencia.Value;
                DDLTipoVenta.Enabled = true;
                CargarGridInicio();
                MultiView1.ActiveViewIndex = 1;

            }
            else
                ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;            


            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void grdDatosFactura_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDatosFactura.PageIndex = 0;
            grdDatosFactura.PageIndex = e.NewPageIndex;
            CargarGridInicio();
        }

        protected void grdDatosFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnVerFactRecibo_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            CargarGrid("N");
        }

        protected void bttnGenerarRef_Click(object sender, EventArgs e)
        {
            DDLTipoVenta.Enabled = true;
            imgBttnBuscar.Enabled = true;
            imgBttnCatClientes.Enabled = true;
            grvInventario.Enabled = true;
            grvInventarioAgregado.Enabled = true;

            if (SesionUsu.Usu_TipoUsu == 6)
            {
                txtClaveSysweb.Text = SesionUsu.Usu_Nombre;
                imgBttnBuscar_Click(null, null);
            }
            else
                txtClaveSysweb.Text = string.Empty; 
            
            Session["Inventario"] = null;
            grvInventarioAgregado.DataSource = null;
            grvInventarioAgregado.DataBind();

            grvInventario.DataSource = null;
            grvInventario.DataBind();

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
            DDLTipoVenta.SelectedValue = "0";
            ddlNivel.Items.Clear();
            txtClaveSysweb.Text = string.Empty;
            lblClienteNombre.Text = string.Empty;
            lblRefGen.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            ddlNivel.Items.Clear();
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
            //CargarGridInicio();
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
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdDatosFactura.SelectedIndex = row.RowIndex;


            lblRefGenerada.Text = grdDatosFactura.SelectedRow.Cells[3].Text;
            modalPagar.Show();
            //Button cbi = (Button)(sender);
            //GridViewRow row = (GridViewRow)cbi.NamingContainer;
            //grdDatosFactura.SelectedIndex = row.RowIndex;
            //string Observaciones = "";
            //string Conceptos = "L0606-RECUPERACION POR PRODUCCION 0AGRICOLAS Y GANADEROS";
            //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + grdDatosFactura.SelectedRow.Cells[0].Text;
            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void grvInventarioAgregado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                int pagina = grvInventario.PageSize * grvInventario.PageIndex;
                fila = pagina + fila;
                List<Bien> lstBien = new List<Bien>();
                lstBien = (List<Bien>)Session["Inventario"];
                lstBien.RemoveAt(fila);
                Session["Inventario"] = lstBien;
                CargarGridAgregados(lstBien);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }

        protected void bttnVerRecibo_Click(object sender, EventArgs e)
        {
            Button cbi = (Button)(sender);
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

        protected void btnPagar_Click(object sender, EventArgs e)
        {

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
                int IdRef= Convert.ToInt32(grdDatosFactura.SelectedRow.Cells[0].Text);
                string Total = string.Format("{0:0.00}", grdDatosFactura.SelectedRow.Cells[5].Text);
                string nombre = grdDatosFactura.SelectedRow.Cells[6].Text;
                string _open = "window.open('" + "https://sysweb.unach.mx/FichaReferenciada/Form/PagoenLinea.aspx?order_m=" + grdDatosFactura.SelectedRow.Cells[0].Text + "&reference_m=" + grdDatosFactura.SelectedRow.Cells[3].Text + "&amount_m=" + Total + "&customername_m=" + grdDatosFactura.SelectedRow.Cells[6].Text + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }


        }

        protected void bttnEliminar_Click(object sender, EventArgs e)
        {
            SesionUsu.Editar = 0;
            Verificador = string.Empty;
            Button cbi = (Button)(sender);
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
            modalClientes.Hide();
        }

        protected void imgBttnCatClientes_Click(object sender, ImageClickEventArgs e)
        {
            modalClientes.Show();
            CargarGridClientes();
        }

        protected void imgBttnBuscarCatCliente_Click(object sender, ImageClickEventArgs e)
        {
            modalClientes.Show();
            CargarGridClientes();
        }

        protected void grvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modalClientes.Show();
            txtClaveSysweb.Text = grvClientes.SelectedRow.Cells[0].Text;
            imgBttnBuscarCliente_Click(null, null);
            modalClientes.Hide();

        }

        protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            modalClientes.Show();
            grvClientes.PageIndex = 0;
            grvClientes.PageIndex = e.NewPageIndex;
            CargarGridClientes();
        }

        protected void btnAgregar_Cliente_Click(object sender, EventArgs e)
        {
            txtClaveSysweb.Text = grvClientes.SelectedRow.Cells[0].Text;
            imgBttnBuscarCliente_Click(null, null);
            modalClientes.Hide();
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            Session["Inventario"] = null;
            grvInventario.DataSource = null;
            grvInventario.DataBind();
            grvInventarioAgregado.DataSource = null;
            grvInventarioAgregado.DataBind();
            CargarGrid("N");
        }

        protected void CancelAlert_Click(object sender, EventArgs e)
        {
            DDLTipoVenta.SelectedValue = "0";
            modalTipo.Hide();
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList DDLGrupo = (DropDownList)sender;
            string Tipo = DDLGrupo.SelectedValue;
            ViewState["Filter"] = DDLGrupo.SelectedValue;
            CargarGrid("S");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            DDLTipoVenta.Enabled = true;
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

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CN_Alumno CNAlumno = new CN_Alumno();
            try
            {
                ObjMatricula.Matricula = txtClaveSysweb.Text.ToUpper();
                ObjMatricula.Evento = "ALUMNO";
                ObjMatricula.TipoPersona = 1;
                ObjMatricula.Nivel = ddlNivel.SelectedValue;
                CNAlumno.ConsultarAlumno(ref ObjMatricula, ref Verificador);
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
                    lblClienteNombre.Text = ObjMatricula.Nombre + ' ' + ObjMatricula.APaterno+' '+ ObjMatricula.AMaterno;

                    
                }
                else
                {
                    string MsjError = "Verifique matrícula(" + txtClaveSysweb.Text + ") y/ó Nivel de Estudios(" + ddlNivel.SelectedItem.Text + ")";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsjFam.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + "La matrícula no corresponde a su Dependencia/Escuela/Facultad " + ex.Message + "');", true);  //lblMsjFam.Text = Verificador;
                //lblMsj.Text = "La matrícula no corresponde a su Dependencia/Escuela/Facultad "+ex.Message;
            }

        }
    }
}