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
            if (SesionUsu.Editar == -1)
                ScriptManager.RegisterStartupScript(this, GetType(), "GridEventos", "Eventos();", true);
            //}
        }


        private void CargarCombos()
        {
            CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Ejercicios_Eventos", ref ddlEjercicio, "INGRESOS");
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref DDLDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
            ddlEjercicio.SelectedIndex = 0;
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
            Int32[] Celdas1 = new Int32[] { 10, 11, 13 };
            grdEventos.DataSource = null;
            grdEventos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetListEventos();
                grdEventos.DataBind();
                //if (grdEventos.Rows.Count > 0)
                //    CNComun.HideColumns(grdEventos, Celdas1);

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

        }

        protected void grdEventos_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdEventos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

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
            //grdOficios.DataSource = null;
            //grdOficios.DataBind();
            //ConceptoCuotaLibre ObjCuotaLibre = new ConceptoCuotaLibre();
            //List<ConceptoCuotaLibre> lstCuotalibre = new List<ConceptoCuotaLibre>();

            //TipoParticipante ObjTipoParticipante = new TipoParticipante();


            //Objeventos.Eventos = grdEventos.SelectedRow.Cells[1].Text;
            //ObjCuotaLibre.Evento = grdEventos.SelectedRow.Cells[1].Text;
            //CNeventos.ConsultarUnevento(ref Objeventos, ref Verificador);
            //try
            //{
            //    if (Verificador == "0")
            //    {
            //        divFiltros.Visible = false;
            //        DDLDependencia.Enabled = false;
            //        lblCveDesc.Text = grdEventos.SelectedRow.Cells[1].Text;
            //        CargarCombos();
            //        DDLDependencia.SelectedValue = Objeventos.Dependencia;
            //        DDLDependencia.Enabled = false;
            //        txtFecha_Evento_Fin.Text = Objeventos.Fecha_final;
            //        txtFecha_Evento_Ini.Text = Objeventos.Fecha_inicial;
            //        ddlStatus.SelectedValue = Objeventos.Status;
            //        txtDescripcion.Text = Objeventos.Descripcion;
            //        txtEmail_res.Text = Objeventos.Email_Res;
            //        ddlNivel.SelectedValue = Objeventos.Nivel;
            //        ddlNivel_SelectedIndexChanged(null, null);
            //        ddlDirigido.SelectedValue = Objeventos.Tipo;
            //        rbnExclusivo.SelectedValue = Objeventos.Autorizacion;
            //        lblUsuSolicitado.Text = Objeventos.Usuario_Solicita;
            //        lblFechaSolicitado.Text = Objeventos.Fecha_Solicitud;
            //        lblUsuAutorizado.Text = Objeventos.Usuario_Autoriza;
            //        lblFechaAutorizado.Text = Objeventos.Fecha_Autorizacion;
            //        txtEspecificacion.Text = Objeventos.Observaciones;


            //        /*Obtienes la configuracioo del evento*/
            //        Session["ConfiguracionEvento"] = null;
            //        List<ConceptoCuotaLibre> lstConfiguracion = new List<ConceptoCuotaLibre>();
            //        CNeventos.ConsultarEventos_Detalle(ref ObjCuotaLibre, ref lstConfiguracion);
            //        Session["ConfiguracionEvento"] = lstConfiguracion;
            //        CargarGridConfiguracion(lstConfiguracion);


            //        /*Obtienes oficios*/
            //        Session["OficiosEvento"] = null;
            //        List<Oficio> ListOficios = new List<Oficio>();
            //        CNeventos.ConsultarOficiosEvento(grdEventos.SelectedRow.Cells[1].Text, ref ListOficios);
            //        Session["OficiosEvento"] = ListOficios;
            //        if (ListOficios.Count >= 1)
            //            CargarGridOficios(ListOficios);


            //        /*Se obtienen las matriculas auroizadas del evento*/
            //        Session["MatriculasAutorizadas"] = null;
            //        List<Alumno> ListAutorizados = new List<Alumno>();
            //        CN_Alumno CNAlumno = new CN_Alumno();
            //        Alumno ObjAlumno = new Alumno();
            //        ObjAlumno.Evento = grdEventos.SelectedRow.Cells[1].Text;
            //        CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref ListAutorizados);
            //        Session["MatriculasAutorizadas"] = ListAutorizados;
            //        if (ListAutorizados.Count >= 1)
            //            CargarGridAutorizados(ListAutorizados);


            //        MultiView1.ActiveViewIndex = 1;

            //    }
            //    else
            //    {
            //        CNComun.VerificaTextoMensajeError(ref Verificador);
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Verificador = ex.Message;
            //    CNComun.VerificaTextoMensajeError(ref Verificador);
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
            //}
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
        }

        protected void chkPonente_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            CNeventos.ConsultarCveEvento(ref Objeventos, ref Verificador);
            if (Verificador == "0")
            {
                lblCveDesc.Text = Objeventos.Eventos;
                SesionUsu.Evento = Objeventos.Eventos;
                SesionUsu.Editar = 0;
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);
            }
        }

        protected void bttnAgregarParticipante_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ConceptoCuotaLibre objDetPart = new ConceptoCuotaLibre();
                objDetPart.Evento = SesionUsu.Evento;
                objDetPart.Id_Tipo_Participante = Convert.ToInt32(DDLCatTipoParticipantes.SelectedValue);
                objDetPart.Tipo_Participante = DDLTipoParticipante.SelectedValue;
                objDetPart.Desc_Tipo_Participante = txtDescripcion.Text.ToUpper();
                objDetPart.Es_Ponente = (chkPonente.Checked == true) ? "S" : "N";
                objDetPart.Requiere_Constancia = (chkConstancia.Checked == true) ? "S" : "N";
                objDetPart.StatusDet = ddlStatusDet.SelectedValue;
                CNeventos.EventoInsertarDetPart(ref objDetPart, ref Verificador);
                if (Verificador == "0")
                    CargarGridDetPart(Convert.ToInt32(objDetPart.Id));

            }
            catch (Exception ex)
            {
                string MsjError = ex.Message.Substring(0, 30);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
            }
        }


        private void CargarGridDetPart(int Id)
        {
            int IdPart = 0;
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
            try
            {
                DataTable dt = new DataTable();
                //grdEventoConceptos.DataSource = dt;
                //grdEventoConceptos.DataSource = GetListDetPart();
                //grdEventoConceptos.DataBind();

                GridView grd = grdEventoDetalle.SelectedRow.Cells[7].FindControl("grdEventoConceptos") as GridView;
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
                objEvento.Evento = SesionUsu.Evento;
                CNeventos.ConsultarEventoDetParticipantes(objEvento, ref List);
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
                objEvento.Evento = SesionUsu.Evento;
                objEvento.Id = Convert.ToString(Id);
                CNeventos.ConsultarEventoDetConceptos(objEvento, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void ddlConceptoFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObservacion.Text = ddlConceptoFil.SelectedItem.Text.Replace(" ", "_");
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_Eventos", ref ddlConceptoFil, "p_nivel", "parametro2", ddlNivel.SelectedValue, "1", "INGRESOS");
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
                objConcepto.Evento = SesionUsu.Evento;
                CNeventos.EventoInsertarDetConcept(objConcepto, ref Verificador);
                if (Verificador == "0")
                    CargarGridConcPart(Convert.ToInt32(grdEventoDetalle.SelectedRow.Cells[0].Text));
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
            SesionUsu.Id_Persona =Convert.ToInt32(grdEventoDetalle.SelectedRow.Cells[0].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPopup", "$('#exampleModal').modal('show')", true);

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#linkBttnAgregarConcep').modal('show');", true);

        }


    }
}