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

namespace Recibos_Electronicos.Form
{
    public partial class frmEventosResp : System.Web.UI.Page
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
        CN_Evento CNeventos = new CN_Evento();
        CN_Alumno CNAlumno = new CN_Alumno();
        Evento Objeventos = new Evento();
        string Verificador = string.Empty;
        string MsjError = string.Empty;
        #endregion
        #region <Funciones>
        private void CargarCombos()
        {
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Periodo_Pago", ref ddlTipo_Periodo, "INGRESOS");
            ddlTipo_Periodo.SelectedValue = "20";
        }

        private void CargarGriEventos()
        {
            Int32[] Celdas1 = new Int32[] { 0 };
            grdEventos.DataSource = null;
            grdEventos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();
                if (grdEventos.Rows.Count > 0)
                    CNComun.HideColumns(grdEventos, Celdas1);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + ex.Message + "');", true);
            }
        }

        private void CargarGridConceptos(List<ConceptoCuotaLibre> ListConceptos)
        {
            Int32[] Celdas1 = new Int32[] { 0, 1, 2 };
            grdCuotaLibre.DataSource = null;
            grdCuotaLibre.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdCuotaLibre.DataSource = dt;
                grdCuotaLibre.DataSource = ListConceptos;
                grdCuotaLibre.DataBind();
                if (grdCuotaLibre.Rows.Count > 0)
                    CNComun.HideColumns(grdCuotaLibre, Celdas1);
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> List = new List<Evento>();
                Evento Objeventos = new Evento();
                Objeventos.Dependencia = DDLDependencia.SelectedValue;               
                Objeventos.Status = ddlStatusB.SelectedValue;
                Objeventos.Tipo = ddlDirigido0.SelectedValue;
                CNeventos.ConsultarEventos(ref Objeventos, ref List, txtBusqueda.Text);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarGridOficios(List<Oficio> ListOficios)
        {
            //Int32[] Celdas1 = new Int32[] { 0, 1, 2 };
            grdOficios.DataSource = null;
            grdOficios.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdOficios.DataSource = dt;
                grdOficios.DataSource = ListOficios;
                grdOficios.DataBind();
                //if (grdOficios.Rows.Count > 0)
                //    CNComun.HideColumns(grdOficios, Celdas1);
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        private void CargarGridAutorizados(List<Alumno> ListAutorizados)
        {
            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdUsuarios.DataSource = dt;
                grdUsuarios.DataSource = ListAutorizados;
                grdUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                CargarCombos();
                imgbtnBuscar_Click(null, null);
                MultiView1.ActiveViewIndex = 0;
            }
        }
        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ConceptoCuotaLibre objConcepto = new ConceptoCuotaLibre();
            List<ConceptoCuotaLibre> lstConcepto = new List<ConceptoCuotaLibre>();
            objConcepto.Dependencia = Convert.ToInt32(DDLDependencia.SelectedValue);            
            objConcepto.Carrera = 0; // Convert.ToInt32(DDLTipoParticipante.SelectedValue);
            objConcepto.Concepto = ddlConceptoFil.SelectedValue;
            objConcepto.Evento = "";                        
            objConcepto.Importe = Convert.ToDouble(txtImporte.Text);
            objConcepto.Tipo_Participante = DDLTipoParticipante.SelectedValue;
            objConcepto.Desc_Tipo_Participante = txtDesc_Tipo_Participante.Text;
            objConcepto.Visible_Periodo_Pago=(chkCRequeridos.Items[0].Selected==true)? "S" : "N";
            objConcepto.Visible_Institucion = (chkCRequeridos.Items[1].Selected == true) ? "S" : "N";
            objConcepto.Visible_Puesto = (chkCRequeridos.Items[2].Selected == true) ? "S" : "N";
            objConcepto.Visible_Grado = (chkCRequeridos.Items[3].Selected == true) ? "S" : "N";
            objConcepto.Requiere_Constancia= (chkConstancia.Checked == true) ? "S" : "N";

            objConcepto.Es_Ponente = (chkPonente.Checked == true) ? "S" : "N";
            string Obs = txtObservacion.Text.ToUpper().Replace("Ñ", "N");            
            objConcepto.Observaciones = Obs + " ";
            
            if (Session["ConceptosEvento"] != null)                            
                lstConcepto=(List<ConceptoCuotaLibre>)Session["ConceptosEvento"];

            lstConcepto.Add(objConcepto);
            Session["ConceptosEvento"] = lstConcepto;
            CargarGridConceptos(lstConcepto);

        }

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGriEventos();
        }

        protected void lnkGenRef_Click(object sender, EventArgs e)
        {

        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            ddlTipo_Periodo.SelectedValue = "20";
            TabContainer1.ActiveTabIndex = 0;
            MultiView1.ActiveViewIndex = 1;
            SesionUsu.Editar = 0;
            Session["ConceptosEvento"] = null;
            grdCuotaLibre.DataSource = null;
            grdCuotaLibre.DataBind();
        }

        protected void ctrl_eliminar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_Todos", ref ddlConceptoFil, "p_nivel", "parametro2", ddlNivel.SelectedValue, "1", "INGRESOS");

        }

        protected void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            MsjError = string.Empty;
            List<ConceptoCuotaLibre> lstConceptos = new List<ConceptoCuotaLibre>();
            List<Oficio> ListOficios = new List<Oficio>();
            List<Alumno> ListAutorizados = new List<Alumno>();
            try
            {
                Objeventos.Dependencia =DDLDependencia.SelectedValue.ToString();
                Objeventos.Descripcion = txtDescripcion.Text;
                //Objeventos.Eventos = lblEvento.Text;
                Objeventos.Fecha_inicial = txtFecha_Evento_Ini.Text;
                Objeventos.Fecha_final = txtFecha_Evento_Fin.Text;
                Objeventos.Email_Res = txtEmail_res.Text;
                Objeventos.Email_Corres = "";
                Objeventos.Nivel = ddlNivel.SelectedValue;
                Objeventos.Concepto = "";
                Objeventos.Status = ddlStatus.SelectedValue;
                Objeventos.Ini_Matricula = "";// txtmatricula.Text;
                Objeventos.Autorizacion = rbnExclusivo.SelectedValue;
                Objeventos.Tipo_Periodo = "20"; //ddlTipo_Periodo.SelectedValue;
                Objeventos.Tipo = ddlDirigido.SelectedValue;
                Objeventos.Observaciones = txtEspecificacion.Text;
                Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;

                if (SesionUsu.Editar == 0)
                {
                    CNeventos.EventoInsertar(Objeventos, SesionUsu.Usu_Nombre, ref Verificador);
                    if (Verificador == "0")
                    {
                        lstConceptos = (List<ConceptoCuotaLibre>)Session["ConceptosEvento"];
                        if (lstConceptos.Count > 0)
                        {
                            Verificador = string.Empty;
                            //CNeventos.EventoInsertarDetalle(lstConceptos, Objeventos.Eventos, ref Verificador);
                        }

                        if (Verificador != "0")
                            MsjError = MsjError + " ERROR EN EL REGISTRO DEL DETALLE " + Verificador;                                                    

                        Verificador = string.Empty;
                        ListOficios = (List<Oficio>)Session["OficiosEvento"];
                        if (ListOficios.Count > 0)
                            CNeventos.Insertar_Oficios(Objeventos.Eventos, ListOficios, ref Verificador);

                        if (Verificador != "0")
                            MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;

                        Verificador = string.Empty;
                        ListAutorizados = (List<Alumno>)Session["MatriculasAutorizadas"];
                        if (ListAutorizados.Count > 0)
                            CNAlumno.AutorizadosInsertar(Objeventos.Eventos, ListAutorizados, ref Verificador);
                        if (Verificador != "0")
                            MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS AUTORIZADOS: " + Verificador;

                        if (MsjError != string.Empty)
                        {
                            CNComun.VerificaTextoMensajeError(ref MsjError);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 0;
                            CargarGriEventos();
                        }


                    }
                    else
                        MsjError = "NO SE PUDO GUARDAR EL EVENTO: "+Verificador;

                }
                else
                {
                    CNeventos.EventoEditar(Objeventos, SesionUsu.Usu_Nombre, ref Verificador);
                    if (Verificador == "0")
                    {
                        Verificador = string.Empty;
                        lstConceptos = (List<ConceptoCuotaLibre>)Session["ConceptosEvento"];
                        CNeventos.EventoEliminarDetalle(grdEventos.SelectedRow.Cells[1].Text, ref Verificador);
                        if (Verificador != "0")                                                    
                            MsjError = MsjError + " ERROR EN LA ELIMINACIÓN DEL DETALLE " + Verificador;

                        Verificador = string.Empty;
                        //CNeventos.EventoInsertarDetalle(lstConceptos, Objeventos.Eventos, ref Verificador);
                        if (Verificador != "0")                                                    
                            MsjError = MsjError + " ERROR EN EL REGISTRO DEL DETALLE " + Verificador;

                        Verificador = string.Empty;
                        ListOficios = (List<Oficio>)Session["OficiosEvento"];
                        if (ListOficios.Count > 0)
                        {                            
                            CNeventos.Eliminar_Oficios(Objeventos, ref Verificador);
                            if (Verificador == "0")
                                CNeventos.Insertar_Oficios(Objeventos.Eventos, ListOficios, ref Verificador);
                            else
                                MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;


                        }

                        ListAutorizados = (List<Alumno>)Session["MatriculasAutorizadas"];
                        if (ListAutorizados.Count > 0)
                        {
                            Verificador = string.Empty;
                            CNAlumno.AutorizadosEliminar(Objeventos, ref Verificador);
                            if (Verificador == "0")
                                CNAlumno.AutorizadosInsertar(Objeventos.Eventos, ListAutorizados, ref Verificador);
                            else
                                MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS AUTORIZADOS: " + Verificador;

                        }


                        if (MsjError != string.Empty)
                        {
                            CNComun.VerificaTextoMensajeError(ref MsjError);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 0;
                            CargarGriEventos();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ MsjError + "');", true);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;

        }

        protected void ctrl_eliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlConceptoFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObservacion.Text = ddlConceptoFil.SelectedItem.Text.Replace(" ", "_");
        }

        protected void chkCRequeridos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCRequeridos.SelectedValue == "PERIODO_PAGO")
            {
                ddlTipo_Periodo.Visible = true;
                lblTipo_Periodo.Visible = true;
            }
            else
            {
                ddlTipo_Periodo.Visible = false;
                lblTipo_Periodo.Visible = false;
                ddlTipo_Periodo.SelectedValue = "20";
            }
        }

        protected void grdUsuarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnAgregarAlum_Click(object sender, EventArgs e)
        {
            List<Alumno> lstAlumnos = new List<Alumno>();
            Alumno ObjAlumno = new Alumno();
            ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
            ObjAlumno.Nombre = txtNombre.Text;
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            ObjAlumno.ImageStatusMatricula ="Activo.PNG";
            ObjAlumno.StatusMatricula = "A";            
            ObjAlumno.TipoPersonaStr = "N";
            ObjAlumno.Nivel = ddlNivel.SelectedValue;
            ObjAlumno.Sede = "TUXTLA"; 

            try
            {
                if (Session["MatriculasAutorizadas"] != null)
                {
                    lstAlumnos = (List<Alumno>)Session["MatriculasAutorizadas"];
                }
                lstAlumnos.Add(ObjAlumno);
                Session["MatriculasAutorizadas"] = lstAlumnos;
                CargarGridAutorizados(lstAlumnos);
                txtMatricula.Text = string.Empty;
                txtNombre.Text = string.Empty;

            }
            catch(Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

        protected void DDLTipoParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDesc_Tipo_Participante.Text = DDLTipoParticipante.SelectedItem.Text;
        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionUsu.Editar = 1;
            //btnBuscar.Visible = false;
            ConceptoCuotaLibre ObjCuotaLibre = new ConceptoCuotaLibre();
            List<ConceptoCuotaLibre> lstCuotalibre = new List<ConceptoCuotaLibre>();
            Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;
            ObjCuotaLibre.Evento = grdEventos.SelectedRow.Cells[1].Text;
            CNeventos.ConsultarUnevento(ref Objeventos, ref Verificador);
            try
            {
                if (Verificador == "0")
                {
                    CargarCombos();
                    DDLDependencia.SelectedValue = Objeventos.Dependencia;
                    txtFecha_Evento_Fin.Text = Objeventos.Fecha_final;
                    txtFecha_Evento_Ini.Text = Objeventos.Fecha_inicial;
                    ddlStatus.SelectedValue = Objeventos.Status;
                    txtDescripcion.Text = Objeventos.Descripcion;
                    txtEmail_res.Text = Objeventos.Email_Res;
                    ddlNivel.SelectedValue = Objeventos.Nivel;
                    ddlNivel_SelectedIndexChanged(null, null);
                    ddlDirigido.SelectedValue = Objeventos.Tipo;
                    rbnExclusivo.SelectedValue = Objeventos.Autorizacion;
                    lblUsuSolicitado.Text = Objeventos.Usuario_Solicita;
                    lblFechaSolicitado.Text = Objeventos.Fecha_Solicitud;
                    lblUsuAutorizado.Text = Objeventos.Usuario_Autoriza;
                    lblFechaAutorizado.Text = Objeventos.Fecha_Autorizacion;
                    txtEspecificacion.Text = Objeventos.Observaciones;


                    /*Obtienes los conceptos de pago*/
                    Session["ConceptosEvento"]=null;
                    List<ConceptoCuotaLibre> ListCuotalibre = new List<ConceptoCuotaLibre>();
                    CNeventos.ConsultarEventos_Detalle(ref ObjCuotaLibre, ref ListCuotalibre);
                    Session["ConceptosEvento"] = ListCuotalibre;
                    CargarGridConceptos(ListCuotalibre);

                    /*Obtienes oficios*/
                    Session["OficiosEvento"] = null;
                    List<Oficio> ListOficios = new List<Oficio>();
                    CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[1].Text, ref ListOficios);
                    Session["OficiosEvento"] = ListOficios;
                    CargarGridOficios(ListOficios);


                    /*Se obtienen las matriculas auroizadas del evento*/
                    Session["MatriculasAutorizadas"] = null;
                    List<Alumno> ListAutorizados = new List<Alumno>();
                    CN_Alumno CNAlumno = new CN_Alumno();
                    Alumno ObjAlumno = new Alumno();
                    ObjAlumno.Evento = grdEventos.SelectedRow.Cells[1].Text;
                    CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref ListAutorizados);
                    Session["MatriculasAutorizadas"] = ListAutorizados;

                    MultiView1.ActiveViewIndex = 1;
                    //CargarGrid("conceptos");
                    //CargarGrid("autorizados");
                    //CargarGrid("oficios");



                    //MultiViewEventos.ActiveViewIndex = 1;
                    //TabContainerDatos.ActiveTabIndex = 0;
                    //TabContainerDatos.Tabs[1].Enabled = true;
                    //TabContainerDatos.Tabs[2].Enabled = true;
                    //TabContainerDatos.Tabs[3].Enabled = true;


                    //if (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "SA")
                    //{

                    //}
                    //else
                    //{
                    //    if (grdEventos.Rows[v].Cells[8].Text != "SOLICITADO")
                    //    {
                    //        inhabilita_campos();
                    //        btnSiguiente2.Visible = false;
                    //    }
                    //}

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);
            }
        }

        protected void grdCuotaLibre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente2_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarOficio_Click(object sender, EventArgs e)
        {
            string fullPath;
            int fileSize;
            string NombreArchivo;
            try
            {
                if (FileOficio.HasFile)
                {
                    fileSize = FileOficio.PostedFile.ContentLength;
                    NombreArchivo = FileOficio.FileName.ToUpper();
                    NombreArchivo = NombreArchivo.Replace(" ", "_");
                    NombreArchivo = NombreArchivo.Replace("%", string.Empty);
                    fullPath = Path.Combine(Server.MapPath("~/Oficios/Eventos"), NombreArchivo);
                    FileOficio.SaveAs(fullPath);


                    List<Oficio> ListOficios;
                    Oficio objOficio = new Oficio();
                    objOficio.NumOficio = txtNoOficio.Text;
                    objOficio.FechaOficio = txtFechaOficio.Text;
                    objOficio.FirmaOficio = txtFirma.Text;
                    objOficio.Observaciones = txtObservaciones_oficio.Text;
                    objOficio.NombreArchivo = NombreArchivo;
                    objOficio.LinkArchivo = "~/Oficios/Eventos/" + NombreArchivo;
                    if (Session["OficiosEvento"] == null)
                    {
                        ListOficios = new List<Oficio>();
                        ListOficios.Add(objOficio);
                    }
                    else
                    {
                        ListOficios = (List<Oficio>)Session["OficiosEvento"];
                        ListOficios.Add(objOficio);
                    }

                    Session["OficiosEvento"] = ListOficios;
                    CargarGridOficios(ListOficios);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

        

        protected void ctrl_eliminarOficio_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton cbi = (ImageButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                int fila = row.RowIndex;
                grdOficios.SelectedIndex = row.RowIndex;
                int pagina = grdOficios.PageSize * grdOficios.PageIndex;
                fila = pagina + fila;
                List<Oficio> ListOficios = new List<Oficio>();
                ListOficios = (List<Oficio>)Session["OficiosEvento"];
                ListOficios.RemoveAt(fila);
                Session["OficiosEvento"] = ListOficios;
                CargarGridOficios(ListOficios);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void grdOficios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOficios.PageIndex = e.NewPageIndex;
            List<Oficio> ListOficios = new List<Oficio>();
            ListOficios = (List<Oficio>)Session["OficiosEvento"];
            CargarGridOficios(ListOficios);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBttnBuscaAutorizado_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            Alumno ObjAlumno = new Alumno();
            try
            {
                List<Alumno> lstAlumnos = new List<Alumno>();

                if (Session["MatriculasAutorizadas"] != null)
                {
                    lstAlumnos = (List<Alumno>)Session["MatriculasAutorizadas"];
                    var filtered = from c in lstAlumnos
                                               where c.Matricula.Contains(txtBuscar.Text.ToUpper())  || c.Nombre.Contains(txtBuscar.Text.ToUpper())
                                               select c;

                    var content = filtered.ToList<Alumno>();
                    grdUsuarios.DataSource = content;
                    grdUsuarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void imgBttnBuscaMatricula_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            Alumno ObjAlumno = new Alumno();
            CN_Alumno CNAlumno =new CN_Alumno();
            try
            {
                ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                ObjAlumno.Evento = "";
                CNAlumno.ConsultarAlumnoAutorizadoSel(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")                
                    txtNombre.Text = ObjAlumno.Nombre;
                else                
                    txtNombre.Text = string.Empty;
                
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }
    }
}