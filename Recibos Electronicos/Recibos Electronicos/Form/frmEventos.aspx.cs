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
    public partial class frmEventos : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            Int32[] Celdas1 = new Int32[] { 10, 11, 13 };
            if (!IsPostBack)
            {
                CargarCombos();
                //linkBttnBuscar_Click(null, null);
                MultiView1.ActiveViewIndex = 0;
                SesionUsu.Editar = -1;
            }

            //if (grdEventos.Rows.Count > 0)
            //{
            //    CNComun.HideColumns2(grdEventos, Celdas1);
            //if (SesionUsu.Editar == -1)
            ScriptManager.RegisterStartupScript(this, GetType(), "GridEventos", "Eventos();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ComboDepcias", "FiltDepcias();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "GridCatParticipantes", "CatParticipantes();", true);
            
            //}
        }


        private void CargarCombos()
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Ejercicios_Eventos", ref ddlEjercicio, "INGRESOS");
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
            string anio = DateTime.Now.ToString("yyyy");
            ddlEjercicio.SelectedValue = anio;
            DDLDependencia.SelectedIndex = 0;
            CargarGriEventos();

            //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
            //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Periodo_Pago", ref ddlTipo_Periodo, "INGRESOS");
            ////DDLTipoParticipante_SelectedIndexChanged(null, null);
            //ddlTipo_Periodo.SelectedValue = "20";
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            CargarGriEventos();
        }

        private void CargarGriEventos()
        {
            Int32[] Celdas1 = new Int32[] { 10, 11 };
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
        private List<Evento> GetListEventos()
        {
            try
            {
                List<Evento> List = new List<Evento>();
                Evento Objeventos = new Evento();
                Objeventos.Dependencia = DDLDependencia.SelectedValue;
                Objeventos.Status = ddlStatusB.SelectedValue;
                Objeventos.Tipo = ddlDirigido0.SelectedValue;
                Objeventos.Anio = Convert.ToInt32(ddlEjercicio.SelectedValue);
                CNeventos.ConsultarEventos(ref Objeventos, ref List, "");
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void imgBttnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grdEventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEventos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEventos.EditIndex = -1;
            CargarGriEventos();
        }

        protected void grdEventos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEventos.EditIndex = e.NewEditIndex;
            CargarGriEventos();
        }

        protected void grdEventos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            //int pagina = grdEventos.PageSize * grdEventos.PageIndex;
            //fila = pagina + fila;
            GridViewRow row = grdEventos.Rows[e.RowIndex];
            try
            {
                Evento objEvento = new Evento();
                objEvento.Eventos = row.Cells[2].Text;
                TextBox txtFechaIni_Evento = (TextBox)(row.Cells[5].FindControl("txtFechaIniG"));
                objEvento.Fecha_inicial = txtFechaIni_Evento.Text; // row.Cells[3].Text;
                TextBox txtFechaFin_Evento = (TextBox)(row.Cells[6].FindControl("txtFechaFinG"));
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

        protected void linkBttnEdit_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            MultiView1.ActiveViewIndex = 1;
            TabContainer1.ActiveTabIndex = 0;
            SesionUsu.Editar = 1;
            Verificador = string.Empty;
            lblCveDesc.Text = string.Empty;
            Inicializar();

            Objeventos.Eventos = grdEventos.SelectedRow.Cells[2].Text;
            CNeventos.ObtEvento(ref Objeventos, ref Verificador);
            try
            {
                if (Verificador == "0")
                {

                    SesionUsu.IdEvento = Objeventos.Id;
                    SesionUsu.Evento = grdEventos.SelectedRow.Cells[2].Text;
                    DDLDependencia.Enabled = false;
                    lblCveDesc.Text = grdEventos.SelectedRow.Cells[2].Text;
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
                    rbnExclusivo_SelectedIndexChanged(null, null);
                    lblUsuSolicitado.Text = Objeventos.Usuario_Solicita;
                    lblFechaSolicitado.Text = Objeventos.Fecha_Solicitud;
                    lblUsuAutorizado.Text = Objeventos.Usuario_Autoriza;
                    lblFechaAutorizado.Text = Objeventos.Fecha_Autorizacion;
                    txtEspecificacion.Text = Objeventos.Observaciones;


                    /*Obtienes la configuracioo del evento*/
                    CargarGridDetPart();



                    /*Obtienes oficios*/
                    Session["OficiosEvento"] = null;
                    List<Oficio> ListOficios = new List<Oficio>();
                    CNeventos.ConsultarOficiosEvento(SesionUsu.Evento, ref ListOficios);
                    Session["OficiosEvento"] = ListOficios;
                    if (ListOficios.Count >= 1)
                        CargarGridOficios(ListOficios);


                    /*Se obtienen las matriculas auroizadas del evento*/
                    Session["AutorizadosEvento"] = null;
                    List<Alumno> ListAutorizados = new List<Alumno>();
                    CN_Alumno CNAlumno = new CN_Alumno();
                    Alumno ObjAlumno = new Alumno();
                    ObjAlumno.Evento = SesionUsu.Evento;
                    CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref ListAutorizados);
                    Session["AutorizadosEvento"] = ListAutorizados;
                    if (ListAutorizados.Count >= 1)
                        CargarGridAutorizados(ListAutorizados);

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

        protected void DDLTipoParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLTipoParticipante.SelectedValue == "S")
                chkPonente.Enabled = false;
            else
                chkPonente.Enabled = true;

            string EsPonente = (chkPonente.Checked == true) ? "S" : "N";
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Participantes", ref DDLCatTipoParticipantes, "P_Tipo", "P_EsPonente", "P_Dependencia", DDLTipoParticipante.SelectedValue, EsPonente, DDLDependencia.SelectedValue, "INGRESOS");


        }

        protected void bttnNuevoParticipante_Click(object sender, EventArgs e)
        {
            //DDLTipoParticipanteNew.SelectedIndex = 0;
            //txtDesc_Tipo_Participante.Text = string.Empty;
            //chkPonenteNew.Checked = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupNewPart", "$('#modalPart').modal('show')", true);

        }

        protected void chkPonente_CheckedChanged(object sender, EventArgs e)
        {
            string EsPonente = (chkPonente.Checked == true) ? "S" : "N";
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Participantes", ref DDLCatTipoParticipantes, "P_Tipo", "P_EsPonente", DDLTipoParticipante.SelectedValue, EsPonente, "INGRESOS");
        }

        protected void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            CNeventos.ConsultarIdEvento(ref Objeventos, ref Verificador);
            if (Verificador == "0")
            {
                //lblCveDesc.Text = Objeventos.Eventos;
                SesionUsu.IdEvento = Objeventos.Id;
                SesionUsu.Editar = 0;
                MultiView1.ActiveViewIndex = 1;
                DDLDependencia.Enabled = true;
                lblCveDesc.Text = "---";
                Inicializar();
            }
            //CNeventos.ConsultarCveEvento(ref Objeventos, ref Verificador);
            //if (Verificador == "0")
            //{
            //    lblCveDesc.Text = Objeventos.Eventos;
            //    SesionUsu.Evento = Objeventos.Eventos;
            //    SesionUsu.Editar = 0;
            //    MultiView1.ActiveViewIndex = 1;
            //}
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
            }
        }

        private void Inicializar()
        {
            ddlDirigido.SelectedIndex = 0;
            ddlTipoAcceso.SelectedIndex = 0;
            txtDescripcion.Text = string.Empty;
            txtEmail_res.Text = string.Empty;
            txtTelResp.Text = string.Empty;
            txtFecha_Evento_Ini.Text = string.Empty;
            txtFecha_Evento_Fin.Text = string.Empty;
            ddlStatus.SelectedIndex = 0;
            rbnExclusivo.SelectedValue = "N";
            txtEspecificacion.Text = string.Empty;



            DDLTipoParticipante.SelectedIndex = 0;
            DDLTipoParticipante_SelectedIndexChanged(null, null);
            chkPonente.Checked = false;
            chkConstancia.Checked = false;
            chkPonente_CheckedChanged(null, null);
            ddlNivel.SelectedIndex = 0;
            ddlNivel_SelectedIndexChanged(null, null);
            ddlStatusPart.SelectedIndex = 0;
            grdEventoDetalle.DataSource = null;
            grdEventoDetalle.DataBind();
            Session["OficiosEvento"] = null;
            grdOficios.DataSource = null;
            grdOficios.DataBind();
            Session["AutorizadosEvento"] = null;
            grdUsuarios.DataSource = null;
            grdUsuarios.DataBind();
            TabContainer1.Tabs[3].Visible = false;
            rbnExclusivo.SelectedValue = "N";
        }
        protected void bttnAgregarParticipante_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ConceptoCuotaLibre objDetPart = new ConceptoCuotaLibre();
                //objDetPart.Evento = Convert.ToString(SesionUsu.IdEvento);
                objDetPart.IdEvento = Convert.ToInt32(SesionUsu.IdEvento);

                objDetPart.Id_Tipo_Participante = Convert.ToInt32(DDLCatTipoParticipantes.SelectedValue);
                objDetPart.Tipo_Participante = DDLTipoParticipante.SelectedValue;
                objDetPart.Desc_Tipo_Participante = txtDescripcion.Text.ToUpper();
                objDetPart.Es_Ponente = (chkPonente.Checked == true) ? "S" : "N";
                objDetPart.Requiere_Constancia = (chkConstancia.Checked == true) ? "S" : "N";
                objDetPart.Status = Convert.ToChar(ddlStatusPart.SelectedValue);
                CNeventos.EventoInsertarDetPart(ref objDetPart, ref Verificador);
                if (Verificador == "0")
                    CargarGridDetPart();
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                }


            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }


        private void CargarGridDetPart()
        {
            int IdPart = 0;
            string TipoPart = string.Empty;

            string EsPonente = "N";
            try
            {
                DataTable dt = new DataTable();
                grdEventoDetalle.DataSource = dt;
                grdEventoDetalle.DataSource = GetListDetPart();
                grdEventoDetalle.DataBind();
                foreach (GridViewRow row in grdEventoDetalle.Rows)
                {
                    //row.Cells[Convert.ToInt32(Celdas2.GetValue(i))].Visible = false;
                    IdPart = Convert.ToInt32(row.Cells[0].Text);
                    TipoPart = Convert.ToString(row.Cells[10].Text);

                    DropDownList ddlPart = (DropDownList)(row.Cells[2].FindControl("ddlPart"));
                    if (ddlPart != null)
                    {
                        Label lblEsPonente = (Label)(row.Cells[4].FindControl("lblEsPonente"));
                        EsPonente = lblEsPonente.Text;
                        CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Participantes", ref ddlPart, "P_Tipo", "P_EsPonente", "P_Dependencia", TipoPart, EsPonente, DDLDependencia.SelectedValue, "INGRESOS");
                        ddlPart.SelectedValue = Convert.ToString(row.Cells[0].Text);
                    }

                    GridView grd = row.FindControl("grdEventoConceptos") as GridView;
                    DataTable dt2 = new DataTable();
                    grd.DataSource = dt;
                    grd.DataSource = GetListDetConceptos(IdPart);
                    grd.DataBind();

                }
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGridConcPart(int IdPart)
        {
            Int32[] Celdas = new Int32[] {0, 1 };
            try
            {
                DataTable dt = new DataTable();
                //grdEventoConceptos.DataSource = dt;
                //grdEventoConceptos.DataSource = GetListDetPart();
                //grdEventoConceptos.DataBind();

                GridView grd = grdEventoDetalle.SelectedRow.Cells[8].FindControl("grdEventoConceptos") as GridView;
                DataTable dt2 = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetListDetConceptos(IdPart);
                grd.DataBind();
                CNComun.HideColumns(grd, Celdas);

                //foreach (GridViewRow row in grd.Rows)
                //{
                //    //IdPart = Convert.ToInt32(row.Cells[0].Text);
                //    //TipoPart = Convert.ToString(row.Cells[10].Text);

                //    DropDownList ddlConceptos = (DropDownList)(row.Cells[2].FindControl("ddlCatConcep"));
                //    if (ddlConceptos != null)
                //    {
                //        //Label lblEsPonente = (Label)(row.Cells[4].FindControl("lblEsPonente"));
                //        //EsPonente = lblEsPonente.Text;
                //        CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_Eventos", ref ddlConceptos, "p_nivel", "p_dependencia", "p_id_participante", grdEventos.SelectedRow.Cells[1].Text, grdEventos.SelectedRow.Cells[0].Text, Convert.ToString(row.Cells[1].Text), "INGRESOS");
                //        //CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Participantes", ref ddlPart, "P_Tipo", "P_EsPonente", "P_Dependencia", TipoPart, EsPonente, DDLDependencia.SelectedValue, "INGRESOS");
                //    }
                //}
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        private void CargarGridConcPart2(int IdPart)
        {
            try
            {
                DataTable dt = new DataTable();
                GridView grd = grdEventoDetalle.SelectedRow.Cells[8].FindControl("grdEventoConceptos") as GridView;
                DataTable dt2 = new DataTable();
                grd.DataSource = dt;
                grd.DataSource = GetListDetConceptos(IdPart);
                grd.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }


        private List<ConceptoCuotaLibre> GetListDetPart()
        {

            try
            {
                List<ConceptoCuotaLibre> List = new List<ConceptoCuotaLibre>();
                ConceptoCuotaLibre objEvento = new ConceptoCuotaLibre();
                objEvento.IdEvento = Convert.ToInt32(SesionUsu.IdEvento);
                CNeventos.ConsultarEventoDetParticipantes(objEvento, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void CargarGriCatPart()
        {
            try
            {
                DataTable dt = new DataTable();               
                grvCatParticipantes.DataSource = dt;
                grvCatParticipantes.DataSource = GetListCatParticipantes();
                grvCatParticipantes.DataBind();
            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private List<ConceptoCuotaLibre> GetListCatParticipantes()
        {

            try
            {
                List<ConceptoCuotaLibre> List = new List<ConceptoCuotaLibre>();
                ConceptoCuotaLibre objParticipante = new ConceptoCuotaLibre();
                objParticipante.Tipo_Participante = ddlCatTipPart.SelectedValue;
                CNeventos.ConsultarCatParticipantes(objParticipante, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

        private List<ConceptoCuotaLibre> GetListDetConceptos(int Id)
        {

            try
            {
                List<ConceptoCuotaLibre> List = new List<ConceptoCuotaLibre>();
                ConceptoCuotaLibre objEvento = new ConceptoCuotaLibre();
                objEvento.IdEvento = Convert.ToInt32(SesionUsu.IdEvento);
                objEvento.Id = Convert.ToString(Id);
                CNeventos.ConsultarEventoDetConceptos(objEvento, ref List);
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

        private void CargarGridOficiosSec(List<Oficio> ListOficios)
        {
            Int32[] Celdas1 = new Int32[] { 5, 6 };

            grdOficiosAdj.DataSource = null;
            grdOficiosAdj.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdOficiosAdj.DataSource = dt;
                grdOficiosAdj.DataSource = ListOficios;
                grdOficiosAdj.DataBind();
                //CNComun.HideColumns(grdOficiosAdj, Celdas1);
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
            Int32[] Celdas1 = new Int32[] { 5, 6 };
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

        protected void ddlConceptoFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObservacion.Text = ddlConceptoFil.SelectedItem.Text.Replace(" ", "_");
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_AlumnosUnachCiclo", ref ddlCiclo, "p_tipo", "p_nivel", "TODOS", ddlNivel.SelectedValue, "INGRESOS");
            ddlCiclo.SelectedIndex = 0;
        }

        protected void linkBttnAgregarConcep_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            grdEventoDetalle.SelectedIndex = row.RowIndex;
        }
        protected void bttnAgregarConcepto_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ConceptoCuotaLibre objConcepto = new ConceptoCuotaLibre();
                objConcepto.Id_Tipo_Participante = SesionUsu.Id_Persona; //Convert.ToInt32(grdEventoDetalle.SelectedRow.Cells[0].Text);
                objConcepto.Id_Concepto = Convert.ToInt32(ddlConceptoFil.SelectedValue);
                objConcepto.Importe = Convert.ToDouble(txtImporte.Text);
                objConcepto.Observaciones = txtObservacion.Text;
                objConcepto.IdEvento = Convert.ToInt32(SesionUsu.IdEvento);
                objConcepto.StatusDet = ddlStatusDet.SelectedValue;
                CNeventos.EventoInsertarDetConcept(objConcepto, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGridConcPart(Convert.ToInt32(grdEventoDetalle.SelectedRow.Cells[0].Text));
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#exampleModal').modal('hide');", true);

                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        protected void grdEventoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionUsu.Id_Persona = Convert.ToInt32(grdEventoDetalle.SelectedRow.Cells[0].Text);
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_Eventos", ref ddlConceptoFil, "p_nivel", "p_dependencia", "p_id_participante", "p_id_evento", ddlNivel.SelectedValue, DDLDependencia.SelectedValue, Convert.ToString(SesionUsu.Id_Persona), Convert.ToString(SesionUsu.IdEvento), "INGRESOS");
            txtObservacion.Text = string.Empty;
            txtImporte.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#exampleModal').modal('show')", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#linkBttnAgregarConcep').modal('show');", true);

        }

        protected void grdEventoDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            try
            {
                ConceptoCuotaLibre objEventoDetPart = new ConceptoCuotaLibre();
                objEventoDetPart.Id = Convert.ToString(grdEventoDetalle.Rows[fila].Cells[0].Text);
                objEventoDetPart.IdEvento = SesionUsu.IdEvento;
                CNeventos.EventoEliminarDetallePart(objEventoDetPart, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGridDetPart();
                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Evento objEvento = new Evento();
            ConceptoCuotaLibre objEventoDet = new ConceptoCuotaLibre();
            List<Oficio> ListOficios = new List<Oficio>();
            List<Alumno> ListAutorizados = new List<Alumno>();
            Verificador = string.Empty;
            MsjError = string.Empty;
            if (grdOficios.Rows.Count == 0 && ddlStatus.SelectedValue == "A")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Adjuntar oficio de solicitud.');", true); //lblMsj.Text = ex.Message;
            }
            else
            {
                try
                {
                    //DATOS DE ENCABEZADO
                    objEvento.Descripcion = txtDescripcion.Text.ToUpper();
                    objEvento.Dependencia = DDLDependencia.SelectedValue;
                    objEvento.Fecha_inicial = txtFecha_Evento_Ini.Text;
                    objEvento.Fecha_final = txtFecha_Evento_Fin.Text;
                    objEvento.Email_Res = txtEmail_res.Text;
                    objEvento.Email_Corres = string.Empty;
                    objEvento.Status = ddlStatus.SelectedValue;
                    objEvento.Nivel = ddlNivel.SelectedValue;
                    objEvento.Autorizacion = rbnExclusivo.SelectedValue;
                    objEvento.Tipo_Acceso = ddlDirigido.SelectedValue; //ddlTipoAcceso.SelectedValue;
                    objEvento.Observaciones = txtEspecificacion.Text.ToUpper();
                    objEvento.Nueva_Version = "S";
                    objEvento.Telefono_Responsable = txtTelResp.Text;
                    objEvento.Usuario_Solicita = SesionUsu.Usuario;
                    objEvento.Id = SesionUsu.IdEvento;
                    objEvento.Concepto = null;
                    //objEvento.

                    if (ddlStatus.SelectedValue == "A")
                        objEvento.Usuario_Autoriza = SesionUsu.Usuario;
                    if (SesionUsu.Editar == 0)
                    {
                        CNeventos.EventoInsertar(objEvento, ref Verificador);
                        if (Verificador == "0")
                        {
                            //CNeventos.EventoInsertarDetalle();
                            ListOficios = (List<Oficio>)Session["OficiosEvento"];
                            if (ListOficios != null && ListOficios.Count > 0)
                            {
                                Verificador = string.Empty;
                                CNeventos.Insertar_Oficios(objEvento.Eventos, ListOficios, ref Verificador);
                                if (Verificador != "0")
                                {
                                    if (Verificador != string.Empty)
                                        MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;
                                }
                            }

                            ListAutorizados = (List<Alumno>)Session["AutorizadosEvento"];
                            if (ListAutorizados != null && ListAutorizados.Count > 0)
                            {
                                Verificador = string.Empty;
                                CNeventos.Insertar_Autorizados(objEvento.Eventos, ddlNivel.SelectedValue, ListAutorizados, ref Verificador);

                                if (Verificador != "0")
                                {
                                    if (Verificador != string.Empty)
                                        MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;
                                }
                            }

                            if (MsjError == string.Empty)
                            {
                                CargarGriEventos();
                                MultiView1.ActiveViewIndex = 0;
                                SesionUsu.Editar = -1;
                            }
                            else
                            {
                                CNComun.VerificaTextoMensajeError(ref MsjError);
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
                            }
                        }
                        else
                        {

                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                        }
                    }
                    else
                    {
                        objEvento.Eventos = SesionUsu.Evento; // grdEventos.SelectedRow.Cells[2].Text;
                        objEvento.Id = SesionUsu.IdEvento;
                        objEvento.Usuario_Modifica = SesionUsu.Usu_Nombre;
                        CNeventos.EventoEditar(objEvento, ref Verificador);
                        if (Verificador == "0")
                        {


                            ListOficios = (List<Oficio>)Session["OficiosEvento"];
                            CNeventos.Eliminar_Oficios(objEvento, ref Verificador);
                            if (Verificador != "0")
                            {
                                if (Verificador != string.Empty)
                                {
                                    MsjError = MsjError + " ERROR AL ELIMINAR LOS OFICIOS: " + Verificador;
                                }
                            }
                            if (ListOficios != null && ListOficios.Count > 0)
                            {
                                Verificador = string.Empty;
                                CNeventos.Insertar_Oficios(objEvento.Eventos, ListOficios, ref Verificador);
                                if (Verificador != "0")
                                {
                                    if (Verificador != string.Empty)
                                        MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;
                                }

                            }

                            ListAutorizados = (List<Alumno>)Session["AutorizadosEvento"];
                            CNeventos.Eliminar_Autorizados(objEvento, ref Verificador);
                            if (Verificador != "0")
                            {
                                if (Verificador != string.Empty)
                                {
                                    MsjError = MsjError + " ERROR AL ELIMINAR MATRICULAS/CVES AUTORIZADAS: " + Verificador;
                                }
                            }
                            if (ListAutorizados != null && ListAutorizados.Count > 0)
                            {
                                CNeventos.Insertar_Autorizados(objEvento.Eventos, ddlNivel.SelectedValue, ListAutorizados, ref Verificador);
                                if (Verificador != "0")
                                {
                                    if (Verificador != string.Empty)
                                        MsjError = MsjError + " ERROR EN EL REGISTRO DE LOS OFICIOS: " + Verificador;
                                }
                            }

                            if (MsjError == string.Empty)
                            {
                                ddlDirigido0.SelectedValue = ddlDirigido.SelectedValue;
                                CargarGriEventos();
                                MultiView1.ActiveViewIndex = 0;
                                DDLDependencia.Enabled = true;
                                SesionUsu.Editar = -1;
                            }
                            else
                            {
                                CNComun.VerificaTextoMensajeError(ref MsjError);
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
                            }
                        }
                        else
                        {
                            CNComun.VerificaTextoMensajeError(ref Verificador);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Verificador = ex.Message;
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            SesionUsu.Id_Persona = 0;
            SesionUsu.IdEvento = 0; // String.Empty;
            DDLDependencia.Enabled = true;
            linkBttnBuscar_Click(null, null);
        }

        protected void grdEventoConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            try
            {
                GridView gv = sender as GridView;
                int idConcepto = Convert.ToInt32(gv.Rows[fila].Cells[1].Text);
                ConceptoCuotaLibre objEventoConcep = new ConceptoCuotaLibre();
                objEventoConcep.Id = gv.Rows[fila].Cells[0].Text;
                CNeventos.EventoEliminarDetalleConcepto(objEventoConcep, ref Verificador);
                if (Verificador == "0")
                {
                    DataTable dt = new DataTable();
                    gv.DataSource = dt;
                    gv.DataSource = GetListDetConceptos(idConcepto);
                    gv.DataBind();
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);  //lblMsj.Text = ex.Message;
            }
        }

        protected void grdEventoDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //var lbKategori = e.Row.FindControl("grdEventoConceptos") as GridView;
                //var lbAçıklama = e.Row.FindControl("lbAçıklama") as Label;
            }
        }

        protected void grdEventoConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        protected void grdEventoDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            //int pagina = grdEventoDetalle.PageSize * grdEventos.PageIndex;
            //fila = pagina + fila;
            GridViewRow row = grdEventoDetalle.Rows[e.RowIndex];
            try
            {
                ConceptoCuotaLibre objEvento = new ConceptoCuotaLibre();
                objEvento.Id = row.Cells[0].Text;
                DropDownList ddlPart = (DropDownList)(row.Cells[2].FindControl("ddlPart"));
                objEvento.Id_Tipo_Participante = Convert.ToInt32(ddlPart.SelectedValue);

                DropDownList ddlConstancia = (DropDownList)(row.Cells[4].FindControl("ddlTieneConstancia"));
                objEvento.Requiere_Constancia = ddlConstancia.SelectedValue;

                DropDownList ddlStatusPart = (DropDownList)(row.Cells[4].FindControl("ddlStatusPart"));
                objEvento.StatusDet = ddlStatusPart.SelectedValue;


                objEvento.IdEvento = SesionUsu.IdEvento;
                CNeventos.Editar_PartDet(objEvento, ref Verificador);
                if (Verificador == "0")
                {
                    grdEventoDetalle.EditIndex = -1;
                    CargarGridDetPart();
                    //CargarGriEventos();
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

        protected void grdEventoDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEventoDetalle.EditIndex = e.NewEditIndex;
            CargarGridDetPart();
        }

        protected void grdEventoDetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEventoDetalle.EditIndex = -1;
            CargarGridDetPart();
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

        protected void grdOficios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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

        protected void linkBuscarMatricula_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            Alumno objParticipante = new Alumno();
            try
            {
                objParticipante.Matricula = txtMatricula.Text.ToUpper();
                objParticipante.Evento = string.Empty;

                CNAlumno.ConsultarAlumnoAutorizadoSel(ref objParticipante, ref Verificador);
                if (Verificador == "0")
                    txtNombre.Text = objParticipante.Nombre;
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

        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdUsuarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void linkAgregarMatricula_Click(object sender, EventArgs e)
        {
            List<Alumno> ListAutorizados = new List<Alumno>();
            Alumno objAutorizado = new Alumno();
            try
            {
                objAutorizado.Matricula = txtMatricula.Text.ToUpper();
                objAutorizado.Nombre = txtNombre.Text.ToUpper();
                if (Session["AutorizadosEvento"] == null)
                {
                    ListAutorizados = new List<Alumno>();
                    ListAutorizados.Add(objAutorizado);
                }
                else
                {
                    ListAutorizados = (List<Alumno>)Session["AutorizadosEvento"];
                    ListAutorizados.Add(objAutorizado);
                }
                Session["AutorizadosEvento"] = ListAutorizados;
                CargarGridAutorizados(ListAutorizados);
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }

        }

        protected void rbnExclusivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbnExclusivo.SelectedValue == "S")
                TabContainer1.Tabs[3].Visible = true;
            else
                TabContainer1.Tabs[3].Visible = false;
        }

        protected void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ConceptoCuotaLibre objParticipante = new ConceptoCuotaLibre();
                objParticipante.Tipo_Participante = DDLTipoParticipanteNew.SelectedValue;
                objParticipante.Desc_Tipo_Participante = txtDesc_Tipo_Participante.Text.ToUpper();
                objParticipante.Es_Ponente = (chkPonenteNew.Checked == true) ? "S" : "N";
                CNeventos.Insertar_TipoPersona(objParticipante, ref Verificador);
                if (Verificador == "0")
                {
                    chkPonente.Checked = chkPonenteNew.Checked;
                    string EsPonente = (chkPonente.Checked == true) ? "S" : "N";
                    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Participantes", ref DDLCatTipoParticipantes, "P_Tipo", "P_EsPonente", DDLTipoParticipante.SelectedValue, EsPonente, "INGRESOS");
                    //modalNewParticipante.Hide();
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
        protected void DDLTipoParticipanteNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modalNewParticipante.Show();
            if (DDLTipoParticipanteNew.SelectedValue == "S")
                chkPonente.Enabled = false;
            else
                chkPonente.Enabled = true;


            txtDesc_Tipo_Participante.Text = DDLTipoParticipanteNew.SelectedItem.Text;
        }

        protected void grdEventoConceptos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;

            //GridViewRow row = grdEventoConceptos.Rows[e.RowIndex];
            try
            {
                GridView gv = sender as GridView;
                int idConcepto = Convert.ToInt32(gv.Rows[fila].Cells[0].Text);

                ConceptoCuotaLibre objEvento = new ConceptoCuotaLibre();
                objEvento.Id_Concepto = idConcepto;

                DropDownList ddlStatusConc = (DropDownList)(gv.Rows[fila].Cells[0].FindControl("ddlStatusConc"));
                objEvento.StatusDet = Convert.ToString(ddlStatusConc.SelectedValue);

                TextBox txtImporte = (TextBox)(gv.Rows[fila].Cells[0].FindControl("txtImporte"));
                objEvento.Importe = Convert.ToDouble(txtImporte.Text);

                TextBox txtDesc = (TextBox)(gv.Rows[fila].Cells[0].FindControl("txtDesc"));
                objEvento.DescConcepto = txtDesc.Text.ToUpper();

                objEvento.Id = Convert.ToString(gv.Rows[fila].Cells[0].Text);
                int idPart = Convert.ToInt32(gv.Rows[fila].Cells[1].Text);


                objEvento.IdEvento = SesionUsu.IdEvento;
                CNeventos.Editar_ConcepDet(objEvento, idConcepto, ref Verificador);
                if (Verificador == "0")
                {
                    gv.EditIndex = -1;
                    DataTable dt = new DataTable();
                    gv.DataSource = dt;
                    gv.DataSource = GetListDetConceptos(idPart);
                    gv.DataBind();
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

        protected void grdEventoConceptos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int fila = e.NewEditIndex;

            //GridViewRow row = grdEventoConceptos.Rows[e.RowIndex];
            try
            {
                GridView gv = sender as GridView;
                gv.EditIndex = e.NewEditIndex;
                int idConcepto = Convert.ToInt32(gv.Rows[fila].Cells[0].Text);
                int idPart = Convert.ToInt32(gv.Rows[fila].Cells[1].Text);

                //DropDownList ddlConceptos = (DropDownList)(gv.Rows[fila].Cells[2].FindControl("ddlCatConcep"));
                ////DropDownList ddlPart = (DropDownList)(row.Cells[2].FindControl("ddlPart"));
                //if (ddlConceptos != null)                
                //   CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_Eventos", ref ddlConceptos, "p_nivel", "p_dependencia", "p_id_participante", grdEventos.SelectedRow.Cells[1].Text, grdEventos.SelectedRow.Cells[0].Text, Convert.ToString(gv.Rows[fila].Cells[1].Text), "INGRESOS");


                DataTable dt2 = new DataTable();
                gv.DataSource = dt2;
                gv.DataSource = GetListDetConceptos(idPart);
                gv.DataBind();




                //CargarGridConcPart(idPart);

                //DataTable dt2 = new DataTable();
                //gv.DataSource = dt2;
                //gv.DataSource = GetListDetConceptos(idConcepto);
                //gv.DataBind();

                //CargarGridConcPart(idConcepto);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            }
        }

        protected void grdEventoConceptos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grdEventoConceptos.EditIndex = -1;
            //CargarGriEventos();
            //int fila = e.NewEditIndex;
            Verificador = string.Empty;
            //GridViewRow row = grdEventoConceptos.Rows[e.RowIndex];
            try
            {
                GridView gv = sender as GridView;
                int idPart = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[1].Text);
                gv.EditIndex = -1;
                DataTable dt2 = new DataTable();
                gv.DataSource = dt2;
                gv.DataSource = GetListDetConceptos(idPart);
                gv.DataBind();

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            }

        }

        protected void lnkGenRef_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grdEventos.SelectedIndex = row.RowIndex;
            string ruta = string.Empty;
            ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx?evento=" + grdEventos.SelectedRow.Cells[2].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void grvCatParticipantes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCatParticipantes.EditIndex = -1;
            CargarGriCatPart();
        }

        protected void grvCatParticipantes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCatParticipantes.EditIndex = e.NewEditIndex;
            CargarGriCatPart();
        }

        protected void grvCatParticipantes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            GridViewRow row = grvCatParticipantes.Rows[e.RowIndex];
            try
            {
                ConceptoCuotaLibre objParticipante = new ConceptoCuotaLibre();
                objParticipante.Id_Tipo_Participante =Convert.ToInt32(row.Cells[0].Text);
                TextBox txtDesc_Tipo_Participante = (TextBox)(row.Cells[1].FindControl("txtDesc_Tipo_Participante"));
                objParticipante.Desc_Tipo_Participante = txtDesc_Tipo_Participante.Text; // row.Cells[3].Text;                
                CNeventos.Editar_DescParticipante(objParticipante, ref Verificador);
                if (Verificador == "0")
                {
                    grvCatParticipantes.EditIndex = -1;
                    CargarGriCatPart();
                    CargarGridDetPart();
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

        protected void bttnBuscarPart_Click(object sender, EventArgs e)
        {
            grvCatParticipantes.EditIndex = -1;            
            CargarGriCatPart();
        }

        protected void bttnCrearPart_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            ddlCatTipPart_SelectedIndexChanged(null, null);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupNewPart", "$('#modalCatPart').modal('show')", true);
        }

        protected void btnOficios_Click(object sender, EventArgs e)
        {
            Button cbi = (Button)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            int fila = row.RowIndex;
            List<Oficio> lstOficiosAdj = new List<Oficio>();
            grdEventos.SelectedIndex = row.RowIndex;


            CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[2].Text, ref lstOficiosAdj);
            if (lstOficiosAdj.Count >= 1)
            {

                //modalDoctosAdj.Show();
                CargarGridOficiosSec(lstOficiosAdj);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopupOficios", "$('#modalOficios').modal('show')", true);

            }
        }

        protected void linkBttnReporte_Click(object sender, EventArgs e)
        {
           
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grdEventos.SelectedIndex = row.RowIndex;
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP061&Evento=" + grdEventos.SelectedRow.Cells[2].Text + "&enExcel=N";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            
        }

        protected void grdEventoConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEventos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Verificador = string.Empty;
            int fila = e.RowIndex;
            try
            {
                ConceptoCuotaLibre objEventoDetPart = new ConceptoCuotaLibre();
                objEventoDetPart.Evento = Convert.ToString(grdEventos.Rows[fila].Cells[11].Text);
                CNeventos.EventoEliminar(objEventoDetPart, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGriEventos();
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'El evento fue eliminado correctamente.');", true); //lblMsj.Text = ex.Message;

                }
                else
                {
                    CNComun.VerificaTextoMensajeError(ref Verificador);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void bttnSalirPart_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ddlCatTipPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvCatParticipantes.EditIndex = -1;
            CargarGriCatPart();
        }
    }
}