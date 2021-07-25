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
    public partial class frmEventos3 : System.Web.UI.Page
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
            Int32[] Celdas1 = new Int32[] { 10 };
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

        private void CargarGridConceptos(List<TipoParticipante> ListConceptos)
        {
            Int32[] Celdas = new Int32[] { 8,9};
            List<Concepto> lstConceptos = new List<Concepto>();
            grdCuotaLibre.DataSource = null;
            grdCuotaLibre.DataBind();

            try
            {
                DataTable dt = new DataTable();
                grdCuotaLibre.DataSource = dt;
                if (ListConceptos.Count >= 1)
                {
                    var lstConceptos2 = ListConceptos[grvTiposParticipantes.SelectedIndex].Conceptos;
                    var lstConceptosNew = lstConceptos2.Where(x => x.Eliminar == "N").ToList();
                    grdCuotaLibre.DataSource = lstConceptosNew;
                }
                else                
                    grdCuotaLibre.DataSource = lstConceptos;
                
                grdCuotaLibre.DataBind();
                if(grdCuotaLibre.Rows.Count>=1)
                    CNComun.HideColumns(grdCuotaLibre, Celdas);

            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        private void CargarGridParticipantes(List<TipoParticipante> LisParticipantes)
        {
            Int32[] Celdas = new Int32[] { 8 };

            grvTiposParticipantes.DataSource = null;
            grvTiposParticipantes.DataBind();

            List<TipoParticipante> list = LisParticipantes.Where(x => x.Eliminar == "N").ToList();


            try
            {
                DataTable dt = new DataTable();
                grvTiposParticipantes.DataSource = dt;
                grvTiposParticipantes.DataSource = list;
                grvTiposParticipantes.DataBind();
                if (grvTiposParticipantes.Rows.Count >= 1)
                    CNComun.HideColumns(grvTiposParticipantes, Celdas);



            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        //private void CargarGridParticipantes(List<ConceptoCuotaLibre> LisParticipantes)
        //{
        //    //Int32[] Celdas1 = new Int32[] { 0, 1, 3, 12 };
        //    grvTiposParticipantes.DataSource = null;
        //    grvTiposParticipantes.DataBind();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        grvTiposParticipantes.DataSource = dt;
        //        grvTiposParticipantes.DataSource = LisParticipantes;
        //        grvTiposParticipantes.DataBind();
        //        //if (grvTiposParticipantes.Rows.Count > 0)
        //        //    CNComun.HideColumns(grdCuotaLibre, Celdas1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MsjError = ex.Message;
        //        CNComun.VerificaTextoMensajeError(ref MsjError);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
        //    }
        //}



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
            Int32[] Celdas1 = new Int32[] { 5, 6 };

            grdOficios.DataSource = null;
            grdOficios.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdOficios.DataSource = dt;
                grdOficios.DataSource = ListOficios;
                grdOficios.DataBind();
                CNComun.HideColumns(grdOficios, Celdas1);
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Ocurrió un problema al cargar los datos: " + MsjError + "');", true);
            }
        }

        private void CargarGridOficiosAdj(List<Oficio> ListOficios)
        {
            grdOficiosAdj.DataSource = null;
            grdOficiosAdj.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdOficiosAdj.DataSource = dt;
                grdOficiosAdj.DataSource = ListOficios;
                grdOficiosAdj.DataBind();
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
        

        //protected void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    ConceptoCuotaLibre objConcepto = new ConceptoCuotaLibre();
        //    List<ConceptoCuotaLibre> lstConcepto = new List<ConceptoCuotaLibre>();

        //    //Evento_Tipo_Participante objParticipante = new Evento_Tipo_Participante();
        //    //List<Evento_Tipo_Participante> lstParticipantes = new List<Evento_Tipo_Participante>();


        //    /*Tipo de Participantes*/
        //    objConcepto.Tipo_Participante = hddnParticipante.Value; //lblTipoParticipanteNew.Text;
        //    objConcepto.Desc_Tipo_Participante = lblDescTipoParticipanteNew.Text;
        //    objConcepto.Requiere_Constancia = hddnConstancia.Value;
        //    objConcepto.Es_Ponente = hddnPonente.Value;
        //    objConcepto.Participante = lblTipoParticipanteNew.Text; //hddnParticipante.Value;
        //    objConcepto.Grupo_Numero = hddnNum.Value;



        //    /*Conceptos del Evento*/
        //    objConcepto.Dependencia = Convert.ToInt32(DDLDependencia.SelectedValue);
        //    objConcepto.Concepto = ddlConceptoFil.SelectedValue;
        //    objConcepto.Evento = "";                        
        //    objConcepto.Importe = Convert.ToDouble(txtImporte.Text);


           

        //    string Obs = txtObservacion.Text.ToUpper().Replace("Ñ", "N");            
        //    objConcepto.Observaciones = Obs + " ";
            
        //    if (Session["ConceptosEvento"] != null)                            
        //        lstConcepto=(List<ConceptoCuotaLibre>)Session["ConceptosEvento"];

        //    lstConcepto.Add(objConcepto);
        //    Session["ConceptosEvento"] = lstConcepto;
        //    CargarGridConceptos(lstConcepto);

        //}

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGriEventos();
        }

        protected void lnkGenRef_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;            
            grdEventos.SelectedIndex = row.RowIndex;
            string ruta = string.Empty;
            if (grdEventos.SelectedRow.Cells[10].Text=="S")
                ruta = "https://sysweb.unach.mx/FichaReferenciadaNew/Form/Registro_Participantes.aspx?evento=" + grdEventos.SelectedRow.Cells[1].Text;
            else
                ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx?evento=" + grdEventos.SelectedRow.Cells[1].Text;


            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            ddlTipo_Periodo.SelectedValue = "20";
            TabContainer1.ActiveTabIndex = 0;
            MultiView1.ActiveViewIndex = 1;
            SesionUsu.Editar = 0;
            lblCveDesc.Text = string.Empty;
            //Session["ParticipantesEvento"] = null;
            Session["ConceptosEvento"] = null;
            Session["OficiosEvento"] = null;
            Session["MatriculasAutorizadas"] = null;
            Session["ParticipantesEvento"] = null;


            //hddnPonente.Value = string.Empty;
            //hddnConstancia.Value = string.Empty;
            //hddnTipoParticipante.Value = string.Empty;
            //hddnParticipante.Value = string.Empty;
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            CargarGridParticipantes(lstParticipantes);
            CargarGridConceptos(lstParticipantes);
            //grdCuotaLibre.DataSource = null;
            //grdCuotaLibre.DataBind();

            grdOficios.DataSource = null;
            grdOficios.DataBind();

            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();

            txtDescripcion.Text = string.Empty;
            txtFecha_Evento_Ini.Text = string.Empty;
            txtFecha_Evento_Fin.Text = string.Empty;
            txtEspecificacion.Text = string.Empty;
            DDLDependencia.Enabled = true;
            ddlNivel.SelectedValue = "Z";
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
            List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();

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

                if (SesionUsu.Editar == 0)
                {
                    CNeventos.EventoEspecialInsertar(Objeventos, SesionUsu.Usu_Nombre, "S", ref Verificador);
                    if (Verificador == "0")
                    {
                        lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
                        if (lstParticipantes != null && lstParticipantes.Count > 0)
                        {
                            Verificador = string.Empty;
                            CNeventos.EventoInsertarDetalle(lstParticipantes, Objeventos.Eventos, ref Verificador);
                        }

                        if (Verificador != "0")
                            MsjError = MsjError + " ERROR EN EL REGISTRO DEL DETALLE " + Verificador;                                                    

                        Verificador = string.Empty;
                        ListOficios = (List<Oficio>)Session["OficiosEvento"];
                        if (ListOficios!=null && ListOficios.Count > 0)
                            CNeventos.Insertar_Oficios(Objeventos.Eventos, ListOficios, ref Verificador);

                        if (Verificador != "0")
                            if (Verificador !=string.Empty)
                                MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;

                        Verificador = string.Empty;
                        ListAutorizados = (List<Alumno>)Session["MatriculasAutorizadas"];
                        if (ListAutorizados != null && ListAutorizados.Count > 0)
                            CNAlumno.AutorizadosInsertar(Objeventos.Eventos, ListAutorizados, ref Verificador);
                        if (Verificador != "0" && Verificador != string.Empty)
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
                    Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;
                    CNeventos.EventoEditar(Objeventos, SesionUsu.Usu_Nombre, ref Verificador);
                    if (Verificador == "0")
                    {

                        Verificador = "0";
                        lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];
                        List<Concepto> lstConceptosVarios = lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>();
                        CNeventos.EventoEliminarDetalleConcepto(lstConceptosVarios, ref Verificador);
                        if (Verificador != "0")
                            MsjError = MsjError + " ERROR EN LA ELIMINACIÓN DE CONCEPTO(S) " + Verificador;


                        Verificador = "0";
                        lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
                        CNeventos.EventoEliminarDetalleParticipante(lstParticipantes, ref Verificador);
                        if (Verificador != "0")                                                    
                            MsjError = MsjError + " ERROR EN LA ELIMINACIÓN DE TIPO(S) DE PARTICIPANTE(S) " + Verificador;


                        Verificador = "0";
                        CNeventos.EventoEditarDetalle(lstParticipantes, Objeventos.Eventos, ref Verificador);
                        if (Verificador != "0" && Verificador != string.Empty)                                                    
                            MsjError = MsjError + " ERROR EN LA EDICIÓN " + Verificador;


                        Verificador = string.Empty;
                        CNeventos.EventoInsertarDetalle(lstParticipantes, Objeventos.Eventos, ref Verificador);
                        if (Verificador != "0" && Verificador != string.Empty)
                            MsjError = MsjError + " ERROR EN EL REGISTRO DEL DETALLE " + Verificador;


                        Verificador = string.Empty;
                        ListOficios = (List<Oficio>)Session["OficiosEvento"];
                        if (ListOficios.Count > 0)
                        {                            
                            CNeventos.Eliminar_Oficios(Objeventos, ref Verificador);
                            if (Verificador == "0")
                                try
                                {
                                    CNeventos.Insertar_Oficios(Objeventos.Eventos, ListOficios, ref Verificador);
                                }
                                catch (Exception ex)
                                {
                                    Verificador = ex.Message;
                                    CNComun.VerificaTextoMensajeError(ref Verificador);
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'ERROR EN EL REGISTRO DE LOS DOCUMENTOS ADJUNTOS, " + Verificador + "');", true);
                                }

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
                            DDLDependencia.Enabled = true;
                            CargarGriEventos();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ Verificador + "');", true);
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DDLDependencia.Enabled = true;
        }

        protected void ctrl_eliminar_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grdEventos.SelectedIndex = row.RowIndex;


            Objeventos.Status = "X";
            Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;


            try
            {
                Verificador = string.Empty;
                CNeventos.EventoEditarStatus(ref Objeventos, ref Verificador);

                if (Verificador != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No se pudo eliminar el registro');", true);

                }
                else
                {
                    CargarGriEventos();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Registro eliminado correctamente');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);
            }

        }

        protected void ddlConceptoFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            modalConceptos.Show();
            txtObservacion.Text = ddlConceptoFil.SelectedItem.Text.Replace(" ", "_");
        }

        //protected void chkCRequeridos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (chkCRequeridos.SelectedValue == "PERIODO_PAGO")
        //    {
        //        ddlTipo_Periodo.Visible = true;
        //        lblTipo_Periodo.Visible = true;
        //    }
        //    else
        //    {
        //        ddlTipo_Periodo.Visible = false;
        //        lblTipo_Periodo.Visible = false;
        //        ddlTipo_Periodo.SelectedValue = "20";
        //    }
        //}

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
            modalTipoParticipante.Show();            
            txtDesc_Tipo_Participante.Text = DDLTipoParticipante.SelectedItem.Text;
            if (DDLTipoParticipante.SelectedValue == "S")
                chkPonente.Enabled = false;
            else
                chkPonente.Enabled = true;
        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionUsu.Editar = 1;
            Verificador = string.Empty;
            //btnBuscar.Visible = false;
            lblCveDesc.Text = string.Empty;
            grdCuotaLibre.DataSource = null;
            grdCuotaLibre.DataBind();

            grdOficios.DataSource = null;
            grdOficios.DataBind();

            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();

            ConceptoCuotaLibre ObjCuotaLibre = new ConceptoCuotaLibre();
            List<ConceptoCuotaLibre> lstCuotalibre = new List<ConceptoCuotaLibre>();
            Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;
            ObjCuotaLibre.Evento = grdEventos.SelectedRow.Cells[1].Text;
            CNeventos.ConsultarUnevento(ref Objeventos, ref Verificador);
            try
            {
                if (Verificador == "0")
                {
                    lblCveDesc.Text= grdEventos.SelectedRow.Cells[1].Text;
                    CargarCombos();
                    DDLDependencia.SelectedValue = Objeventos.Dependencia;
                    DDLDependencia.Enabled = false;
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
                    //Session["ConceptosEvento"]=null;
                    //List<TipoParticipante> ListCuotalibre = new List<TipoParticipante>();
                    //CNeventos.ConsultarEventos_Detalle(ref ObjCuotaLibre, ref ListCuotalibre);
                    //Session["ConceptosEvento"] = ListCuotalibre;
                    //if (ListCuotalibre.Count >= 1)
                    //    CargarGridConceptos(ListCuotalibre);

                    /*Obtienes oficios*/
                    Session["OficiosEvento"] = null;
                    List<Oficio> ListOficios = new List<Oficio>();
                    CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[1].Text, ref ListOficios);
                    Session["OficiosEvento"] = ListOficios;
                    if(ListOficios.Count>=1)
                        CargarGridOficios(ListOficios);                    


                    /*Se obtienen las matriculas auroizadas del evento*/
                    Session["MatriculasAutorizadas"] = null;
                    List<Alumno> ListAutorizados = new List<Alumno>();
                    CN_Alumno CNAlumno = new CN_Alumno();
                    Alumno ObjAlumno = new Alumno();
                    ObjAlumno.Evento = grdEventos.SelectedRow.Cells[1].Text;
                    CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref ListAutorizados);
                    Session["MatriculasAutorizadas"] = ListAutorizados;
                    if (ListAutorizados.Count >= 1)                    
                        CargarGridAutorizados(ListAutorizados);
                    

                    MultiView1.ActiveViewIndex = 1;
                    //TabContainer1.ActiveTabIndex = 0;
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
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
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
                LinkButton cbi = (LinkButton)(sender);
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

        protected void imgBttnElminar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grdCuotaLibre.SelectedIndex = row.RowIndex;
            try
            {
                int pagina = grdCuotaLibre.PageSize * grdCuotaLibre.PageIndex;
                fila = pagina + fila;
                List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
                lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];
                lstConceptos.RemoveAt(fila);
                Session["ParticipantesEvento"] = lstConceptos;
                CargarGridConceptos(lstConceptos);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void BttnSalirModal_Click(object sender, EventArgs e)
        {
            modalDoctosAdj.Hide();            
        }

        protected void btnOficios_Click(object sender, EventArgs e)
        {
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            List<Oficio> lstOficiosAdj = new List<Oficio>();
            grdEventos.SelectedIndex = row.RowIndex;


            CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[1].Text, ref lstOficiosAdj);
            if (lstOficiosAdj.Count >= 1)
            {
                modalDoctosAdj.Show();
                CargarGridOficiosAdj(lstOficiosAdj);
            }

        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            TabContainer1.ActiveTabIndex= 0;
            SesionUsu.Editar = 1;
            Verificador = string.Empty;
            lblCveDesc.Text = string.Empty;
            grdCuotaLibre.DataSource = null;
            grdCuotaLibre.DataBind();

            grdOficios.DataSource = null;
            grdOficios.DataBind();

            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();

            ConceptoCuotaLibre ObjCuotaLibre = new ConceptoCuotaLibre();
            List<ConceptoCuotaLibre> lstCuotalibre = new List<ConceptoCuotaLibre>();

            TipoParticipante ObjTipoParticipante = new TipoParticipante();
            //List<Evento_Tipo_Participante> lstTipoParticipantes = new List<Evento_Tipo_Participante>();


            Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;
            ObjCuotaLibre.Evento = grdEventos.SelectedRow.Cells[1].Text;
            //ObjTipoParticipante.Evento = grdEventos.SelectedRow.Cells[1].Text;
            CNeventos.ConsultarUnevento(ref Objeventos, ref Verificador);
            try
            {
                if (Verificador == "0")
                {
                    lblCveDesc.Text = grdEventos.SelectedRow.Cells[1].Text;
                    CargarCombos();
                    DDLDependencia.SelectedValue = Objeventos.Dependencia;
                    DDLDependencia.Enabled = false;
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


                    /*Obtienes los tipos de participantes*/
                    Session["ParticipantesEvento"] = null;
                    List<TipoParticipante> ListParticipante = new List<TipoParticipante>();
                    CNeventos.ConsultarEventoParticipantes(grdEventos.SelectedRow.Cells[1].Text, ref ObjTipoParticipante, ref ListParticipante);
                    Session["ParticipantesEvento"] = ListParticipante;
                    CargarGridParticipantes(ListParticipante);                                     
                    grvTiposParticipantes_SelectedIndexChanged(null, null);



                    /*Obtienes oficios*/
                    Session["OficiosEvento"] = null;
                    List<Oficio> ListOficios = new List<Oficio>();
                    CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[1].Text, ref ListOficios);
                    Session["OficiosEvento"] = ListOficios;
                    if (ListOficios.Count >= 1)
                        CargarGridOficios(ListOficios);


                    /*Se obtienen las matriculas auroizadas del evento*/
                    Session["MatriculasAutorizadas"] = null;
                    List<Alumno> ListAutorizados = new List<Alumno>();
                    CN_Alumno CNAlumno = new CN_Alumno();
                    Alumno ObjAlumno = new Alumno();
                    ObjAlumno.Evento = grdEventos.SelectedRow.Cells[1].Text;
                    CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref ListAutorizados);
                    Session["MatriculasAutorizadas"] = ListAutorizados;
                    if (ListAutorizados.Count >= 1)
                        CargarGridAutorizados(ListAutorizados);


                    MultiView1.ActiveViewIndex = 1;

                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

        protected void grdEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEventos.PageIndex = 0;
            grdEventos.PageIndex = e.NewPageIndex;
            CargarGriEventos();
        }

        protected void grvTipoParticipantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modalConceptos.Show();
        }

        protected void btnAgregarParticipante_Click(object sender, EventArgs e)
        {

            TipoParticipante objParticipante = new TipoParticipante();
            List<TipoParticipante> lstParticipante = new List<TipoParticipante>();
            string RequiereConstancia=(chkConstancia.Checked == true) ? "S" : "N";
            string Es_Ponente = (chkPonente.Checked == true) ? "S" : "N";

            objParticipante.Participante = DDLTipoParticipante.SelectedItem.Text;
            objParticipante.Tipo_Participante = DDLTipoParticipante.SelectedValue;
            objParticipante.Desc_Tipo_Participante = txtDesc_Tipo_Participante.Text.ToUpper();
            objParticipante.Es_Ponente = Es_Ponente;
            objParticipante.Requiere_Constancia = RequiereConstancia;
            objParticipante.Id = "0";
            objParticipante.Nuevo = "S";
            objParticipante.Eliminar = "N";
            if (Session["ParticipantesEvento"] != null)
                lstParticipante = (List<TipoParticipante>)Session["ParticipantesEvento"];

            lstParticipante.Add(objParticipante);
            Session["ParticipantesEvento"] = lstParticipante;
            CargarGridParticipantes(lstParticipante);


            modalTipoParticipante.Hide();
            

        }

        protected void BttnSalirModalConceptos_Click(object sender, EventArgs e)
        {
            modalConceptos.Hide();
            //modalConceptos.Hide();
        }

        protected void imgBttnVer_Click(object sender, ImageClickEventArgs e)
        {
            //    Verificador = string.Empty;
            //    ImageButton cbi = (ImageButton)(sender);
            //    GridViewRow row = (GridViewRow)cbi.NamingContainer;
            //    int fila = row.RowIndex;
            //    grvTiposParticipantes.SelectedIndex = row.RowIndex;
            //    try
            //    {


            //    }

            //    catch (Exception ex)
            //    {
            //        Verificador = ex.Message;
            //        CNComun.VerificaTextoMensajeError(ref Verificador);
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            //    }
        }

        //protected void imgBttnElminarParticipante_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton cbi = (ImageButton)(sender);
        //    GridViewRow row = (GridViewRow)cbi.NamingContainer;
        //    int fila = row.RowIndex;
        //    grvTiposParticipantes.SelectedIndex = row.RowIndex;
        //    try
        //    {
        //        int pagina = grvTiposParticipantes.PageSize * grvTiposParticipantes.PageIndex;
        //        fila = pagina + fila;
        //        List<ConceptoCuotaLibre> lstParticipante = new List<ConceptoCuotaLibre>();
        //        lstParticipante = (List<ConceptoCuotaLibre>)Session["ParticipantesEvento"];
        //        lstParticipante.RemoveAt(fila);
        //        Session["ParticipantesEvento"] = lstParticipante;
        //        CargarGridParticipantes(lstParticipante);

        //    }
        //    catch (Exception ex)
        //    {
        //        Verificador = ex.Message;
        //        CNComun.VerificaTextoMensajeError(ref Verificador);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

        //    }
        //}

        protected void btnAgregarPart_Click(object sender, EventArgs e)
        {
            //hddnPonente.Value = string.Empty;
            //hddnConstancia.Value = string.Empty;
            //hddnTipoParticipante.Value = string.Empty;
            //hddnParticipante.Value = string.Empty;
            //hddnNum.Value =Convert.ToString(Convert.ToInt32(hddnNum) + 1);
            modalConceptos.Show();
        }

        protected void bttnNuevoPart_Click(object sender, EventArgs e)
        {
            DDLTipoParticipante.SelectedIndex = 0;
            txtDesc_Tipo_Participante.Text = string.Empty;
            chkPonente.Checked = false;
            chkConstancia.Checked = false;
            modalTipoParticipante.Show();
        }

        protected void btnAgregarConcepto_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            modalConceptos.Show();
            TipoParticipante objParticipante = new TipoParticipante();
            Concepto objConcepto = new Concepto();
            List<TipoParticipante> lstParticipante = new List<TipoParticipante>();
            try
            {

                if (SesionUsu.Editar == 0)
                {
                    objConcepto.Dependencia = DDLDependencia.SelectedValue;
                    objConcepto.Evento = "--";
                }
                else
                {
                    objConcepto.Dependencia = grdEventos.SelectedRow.Cells[0].Text;
                    objConcepto.Evento = grdEventos.SelectedRow.Cells[1].Text;
                }

                objConcepto.Editar = "N";
                objConcepto.Eliminar = "N";
                objConcepto.Tipo_Participante= grvTiposParticipantes.SelectedRow.Cells[1].Text;
                objConcepto.IdConcepto = 0;
                objConcepto.CveConcepto = ddlConceptoFil.SelectedValue;
                objConcepto.DescConcepto = txtObservacion.Text.ToUpper();
                objConcepto.Importe = Convert.ToDouble(txtImporte.Text);
                objConcepto.Status = (chkActivo.Checked == true) ? "A" : "B";
                objConcepto.Nuevo = "S";
                //objParticipante.Conceptos.Add(objConcepto);

                if (Session["ParticipantesEvento"] != null)
                    lstParticipante = (List<TipoParticipante>)Session["ParticipantesEvento"];



                lstParticipante[grvTiposParticipantes.SelectedIndex].Conceptos.Add(objConcepto);


                Session["ParticipantesEvento"] = lstParticipante;
                CargarGridConceptos(lstParticipante);
                modalConceptos.Hide();

                //modalTipoParticipante.Hide();

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
             }
        }

        protected void imgBttnAgregarConc_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grvTiposParticipantes.SelectedIndex = row.RowIndex;
            ddlConceptoFil.SelectedIndex = 0;
            txtObservacion.Text = string.Empty;
            txtImporte.Text = string.Empty;
            modalConceptos.Show();
        }

        protected void BttnSalirModalParticipante_Click(object sender, EventArgs e)
        {
            modalTipoParticipante.Hide();
        }

        protected void imgBttnDetalle_Click(object sender, ImageClickEventArgs e)
        {
            List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grvTiposParticipantes.SelectedIndex = row.RowIndex;
            if (Session["ParticipantesEvento"] != null)
                lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];

            CargarGridConceptos(lstConceptos);
            //var lstConceptos2 = lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos;


        }

        protected void imgBttnElminarParticipante_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grvTiposParticipantes.SelectedIndex = row.RowIndex;
            try
            {
                int pagina = grvTiposParticipantes.PageSize * grvTiposParticipantes.PageIndex;
                fila = pagina + fila;
                List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
                List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
                lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
                lstParticipantes.RemoveAt(fila);
                Session["ParticipantesEvento"] = lstParticipantes;
                CargarGridParticipantes(lstParticipantes);
                CargarGridConceptos(lstConceptos);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void imgBttnElminarConcepto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grdCuotaLibre.SelectedIndex = row.RowIndex;
            int IdParticipante = grvTiposParticipantes.SelectedIndex;
            List<Concepto> lstConceptosVarios = new List<Concepto>();
            Concepto objConcepto = new Concepto();
            try
            {
                int pagina = grdCuotaLibre.PageSize * grdCuotaLibre.PageIndex;
                fila = pagina + fila;
                List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
                lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];
                lstConceptosVarios=lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>();
                lstConceptosVarios.RemoveAt(fila);
                lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.Clear();
                for (int idx = 0; idx < lstConceptosVarios.Count; idx++)
                {
                    objConcepto.CveConcepto = lstConceptosVarios[idx].CveConcepto;
                    objConcepto.DescConcepto = lstConceptosVarios[idx].DescConcepto;
                    objConcepto.Importe = lstConceptosVarios[idx].Importe;
                    objConcepto.Evento = lstConceptosVarios[idx].Evento;
                    objConcepto.Dependencia = lstConceptosVarios[idx].Dependencia;
                    objConcepto.Status = lstConceptosVarios[idx].Status;
                    lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.Add(objConcepto);
                }

                //new System.Collections.Generic.HashSetDebugView<CapaEntidad.Concepto>(new System.Collections.Generic.Mscorlib_CollectionDebugView<CapaEntidad.TipoParticipante>(lstConceptos).Items[0].Conceptos).Items[0]
                //    lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>().r
                //new System.Collections.Generic.HashSetDebugView<CapaEntidad.Concepto>(new System.Collections.Generic.Mscorlib_CollectionDebugView<CapaEntidad.TipoParticipante>(lstConceptos).Items[0].Conceptos).Items[1]
                Session["ParticipantesEvento"] = lstConceptos;
                CargarGridConceptos(lstConceptos);
                

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }

        }

        protected void grdEventos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEventos.EditIndex = e.NewEditIndex;
            CargarGriEventos();
            //((DropDownList)grdEventos.Rows[e.NewEditIndex].FindControl("DDLUnidadMedida")).Enabled = true;
            //((TextBox)grvInventarioAgregado.Rows[e.NewEditIndex].FindControl("txtCantidad")).Enabled = true;

        }

        protected void grdEventos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEventos.EditIndex = -1;
            CargarGriEventos();
        }

        protected void grdEventos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            int pagina = grdEventos.PageSize * grdEventos.PageIndex;
            fila = pagina + fila;            
            GridViewRow row = grdEventos.Rows[e.RowIndex];
            try
            {
                Evento objEvento = new Evento();
                objEvento.Eventos = row.Cells[1].Text;
                TextBox txtFechaIni_Evento = (TextBox)(row.Cells[3].FindControl("txtFechaIniG"));
                objEvento.Fecha_inicial = txtFechaIni_Evento.Text; // row.Cells[3].Text;
                TextBox txtFechaFin_Evento = (TextBox)(row.Cells[4].FindControl("txtFechaFinG"));
                objEvento.Fecha_final = txtFechaFin_Evento.Text;
                CNeventos.Editar_VigenciaEvento(objEvento, ref Verificador);
                if (Verificador == "0")
                {
                    grdEventos.EditIndex = -1;
                    CargarGriEventos();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void grvTiposParticipantes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvTiposParticipantes.EditIndex = e.NewEditIndex;
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
            CargarGridParticipantes(lstParticipantes);
        }

        protected void linkVerTipoPart_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            try
            {
                int fila = row.RowIndex;
                grvTiposParticipantes.SelectedIndex = row.RowIndex;
                if (Session["ParticipantesEvento"] != null)
                    lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];

                CargarGridConceptos(lstConceptos);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void linkAgregarTipoPart_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;

            try
            {
                grvTiposParticipantes.SelectedIndex = row.RowIndex;
                ddlConceptoFil.SelectedIndex = 0;
                txtObservacion.Text = string.Empty;
                txtImporte.Text = string.Empty;
                modalConceptos.Show();

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }

        }

        protected void linkEliminarTipoPart_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grvTiposParticipantes.SelectedIndex = row.RowIndex;
            try
            {
                int pagina = grvTiposParticipantes.PageSize * grvTiposParticipantes.PageIndex;
                fila = pagina + fila;
                List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
                List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
                lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
                //lstParticipantes.RemoveAt(fila);
                lstParticipantes[fila].Eliminar = "S";                
                Session["ParticipantesEvento"] = lstParticipantes;
                CargarGridParticipantes(lstParticipantes);
                CargarGridConceptos(lstConceptos);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

        protected void grvTiposParticipantes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
            grvTiposParticipantes.EditIndex = -1;
            CargarGridParticipantes(lstParticipantes);

        }

        protected void linkElminarConcepto_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grdCuotaLibre.SelectedIndex = row.RowIndex;
            int IdParticipante = grvTiposParticipantes.SelectedIndex;
            List<Concepto> lstConceptosVarios = new List<Concepto>();
            Concepto objConcepto = new Concepto();
            try
            {
                int pagina = grdCuotaLibre.PageSize * grdCuotaLibre.PageIndex;
                fila = pagina + fila;
                List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
                lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];

                //var lstConceptos2 = lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos;
                

                lstConceptosVarios = lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>();
                var lstConceptosNew = lstConceptosVarios.Where(x => x.Eliminar == "N").ToList();
                //lstConceptosVarios.RemoveAt(fila);
                lstConceptosNew[fila].Eliminar = "S";
               
                Session["ParticipantesEvento"] = lstConceptos;
                CargarGridConceptos(lstConceptos);


            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }

        }

        protected void grdCuotaLibre_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCuotaLibre.EditIndex = e.NewEditIndex;
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
            CargarGridConceptos(lstParticipantes);
        }

        protected void grvTiposParticipantes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int fila = e.RowIndex;
            int pagina = grvTiposParticipantes.PageSize * grvTiposParticipantes.PageIndex;
            fila = pagina + fila;
            GridViewRow row = grvTiposParticipantes.Rows[e.RowIndex];


            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];


            lstParticipantes[fila].Desc_Tipo_Participante = Convert.ToString(((TextBox)(row.Cells[2].Controls[0])).Text);
            DropDownList ddlEsPonente = (DropDownList)(row.Cells[3].FindControl("ddlEsPonente"));
            lstParticipantes[fila].Es_Ponente = ddlEsPonente.SelectedValue;
            DropDownList ddlRequiereConstancia = (DropDownList)(row.Cells[4].FindControl("ddlRequiereConstancia"));
            lstParticipantes[fila].Requiere_Constancia = ddlRequiereConstancia.SelectedValue;

            grvTiposParticipantes.EditIndex = -1;
            Session["ParticipantesEvento"] = lstParticipantes;
            CargarGridParticipantes(lstParticipantes);

        }

        protected void grdCuotaLibre_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int fila = e.RowIndex;
            int pagina = grdCuotaLibre.PageSize * grdCuotaLibre.PageIndex;
            fila = pagina + fila;
            GridViewRow row = grdCuotaLibre.Rows[e.RowIndex];


            Concepto objConcepto = new Concepto();
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];


            if (Session["ParticipantesEvento"] != null)
                lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];



            DropDownList ddlStatus = (DropDownList)(row.Cells[5].FindControl("ddlStatus"));

            List<Concepto> lstConceptosTodos = lstParticipantes[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>();

            //lstConceptosVarios = lstConceptos[grvTiposParticipantes.SelectedIndex].Conceptos.ToList<Concepto>();
            var lstConceptos = lstConceptosTodos.Where(x => x.Eliminar == "N").ToList();

            //List<Concepto> lstConceptos
            lstConceptos[fila].DescConcepto = Convert.ToString(((TextBox)(row.Cells[3].Controls[0])).Text);
            lstConceptos[fila].Importe = Convert.ToDouble(((TextBox)(row.Cells[4].Controls[0])).Text);
            lstConceptos[fila].Status = ddlStatus.SelectedValue;

            //lstParticipantes[grvTiposParticipantes.SelectedIndex].Conceptos.Add(objConcepto);


            grdCuotaLibre.EditIndex = -1;
            Session["ParticipantesEvento"] = lstParticipantes;
            CargarGridConceptos(lstParticipantes);            

        }

        protected void grdCuotaLibre_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            List<TipoParticipante> lstParticipantes = new List<TipoParticipante>();
            lstParticipantes = (List<TipoParticipante>)Session["ParticipantesEvento"];
            grdCuotaLibre.EditIndex = -1;
            CargarGridConceptos(lstParticipantes);

        }

        protected void bttnNuevoConcepto_Click(object sender, EventArgs e)
        {
            string Tipo = grvTiposParticipantes.SelectedRow.Cells[0].Text;


            ddlConceptoFil.SelectedIndex = 0;
            txtObservacion.Text = string.Empty;
            txtImporte.Text = string.Empty;
            modalConceptos.Show();

        }

        protected void grvTiposParticipantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            try
            {
                if (Session["ParticipantesEvento"] != null)
                    lstConceptos = (List<TipoParticipante>)Session["ParticipantesEvento"];

                CargarGridConceptos(lstConceptos);
            }

            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP061&Evento=" + grdEventos.SelectedRow.Cells[1].Text+ "&enExcel=N";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }
    }
}