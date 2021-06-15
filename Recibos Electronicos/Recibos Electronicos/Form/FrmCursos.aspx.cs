using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using System.IO;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace Recibos_Electronicos.Form
{
    public partial class FrmCursos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Curso ObjCurso = new Curso();
        CN_Curso CNCurso = new CN_Curso();
        private static List<Comun> ListCatConceptos = new List<Comun>();
        private static List<Comun> ListCiclo = new List<Comun>();
        private static List<Comun> ListMateria = new List<Comun>();
        private static List<Curso> ListConceptos = new List<Curso>();
        Int32[] Celdas = new Int32[] { 3, 6 };
        public String fullPathOficio;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];

            if (!IsPostBack)
            {
                SesionUsu.Editar = -1;
                Inicializar();
            }
        }

        #region <Funciones y Sub>
        private void Inicializar()
        {
            MultiView1.ActiveViewIndex = 0;            
            Cargarcombos(); 
            
        }
        private void Cargarcombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaComboG("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carreras_Verano", ref ddlPrograma, "p_dependencia", ddlDependencia.SelectedValue, "INGRESOS");
                //ddlCarrera_SelectedIndexChanged(null, null);
                



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            //lblMsj.Text = string.Empty;
            grvCursos.DataSource = null;
            grvCursos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grvCursos.DataSource = dt;
                grvCursos.DataSource = GetList();
                grvCursos.DataBind();
                if (grvCursos.Rows.Count > 0)
                    CNComun.HideColumns(grvCursos, Celdas);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<Curso> GetList()
        {
            try
            {
                List<Curso> List = new List<Curso>();
                ObjCurso.Dependencia = ddlDependencia.SelectedValue;
                ObjCurso.CicloEscolar = ddlCiclo.SelectedValue;
                ObjCurso.Evento = "VERANO"; // ddlEvento.SelectedValue;
                ObjCurso.Status = rdoListStatus.SelectedValue;
                ObjCurso.IdCarrera = "0"; //(ddlEvento.SelectedValue == "VERANO") ? "0" : Convert.ToString(ddlCarrera1.SelectedValue);
                CNCurso.CursoConsultaGrid(ObjCurso, txtBusca.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void HideColumns(GridView grdView)
        {
            grdView.HeaderRow.Cells[6].Visible = false;
            foreach (GridViewRow row in grdView.Rows)
            {
                row.Cells[6].Visible = false;
            }

        }
        private void LimpiarCampos()
        {
            //ddlDependencia.SelectedIndex = 0;
            //ddlCiclo.SelectedIndex = 0;
            //ddlCarrera.SelectedIndex = 0;
            //txtCarrera.Text = string.Empty;
            //ddlSemestre.SelectedIndex = 0;
            //ddlMateria.SelectedIndex = 0;
            //txtMateria.Text = string.Empty;
            //ddlNivel.SelectedValue = "L";
            //ddlEvento.SelectedIndex = 0;
            //ddlConcepto.SelectedIndex = 0;
            //txtImporte.Text = string.Empty;
            //rdoListStatus.SelectedValue = "A";

            ddlDependencia_SelectedIndexChanged(null, null);
            //ddlCiclo.SelectedIndex = 0;
            //ddlCarrera.SelectedIndex = 0;
            //txtCarrera.Text = string.Empty;
            //ddlSemestre.SelectedIndex = 0;
            //ddlMateria.SelectedIndex = 0;
            //txtMateria.Text = string.Empty;
            
            //ddlEvento.SelectedIndex = 0;
            //ddlConcepto.SelectedIndex = 0;
            txtImporte.Text = string.Empty;
            //imgBttnEliminar.Visible = false;
            //LinkNombreArchivo.Text = string.Empty;
            //LinkNombreArchivo.NavigateUrl = string.Empty;
            //rdoListStatus.SelectedValue = "A";
        }
        private void LimpiarCamposGuarda()
        {
            //ddlDependencia.SelectedIndex = 0;
            //ddlCiclo.SelectedIndex = 0;
            //ddlCarrera.SelectedIndex = 0;
            //txtCarrera.Text = string.Empty;
            //ddlSemestre.SelectedIndex = 0;
            //ddlMateria.SelectedIndex = 0;
            //txtMateria.Text = string.Empty;
            //ddlNivel.SelectedValue = "L";
            //ddlEvento.SelectedIndex = 0;
            //ddlConcepto.SelectedIndex = 0;
            txtImporte.Text = string.Empty;
            
            //rdoListStatus.SelectedValue = "A";
        }
        private string GuardarDatos()
        {
            ObjCurso.IdCarrera = Convert.ToString(ddlPrograma.SelectedValue);
            ObjCurso.IdMateria = Convert.ToInt32(ddlMateria.SelectedValue);
            ObjCurso.CicloEscolar = ddlCiclo.SelectedValue;
            ObjCurso.Dependencia = ddlDependencia.SelectedValue;
            ObjCurso.Semestre = Convert.ToInt32(ddlSemestre.SelectedValue);
            ObjCurso.DescCarrera = ddlPrograma.SelectedItem.Text; //  txtCarrera.Text;
            ObjCurso.DescMateria = ddlMateria.SelectedItem.Text; //txtMateria.Text;
            ObjCurso.Status = Convert.ToString(rdoListStatus.SelectedValue);
            ObjCurso.Evento = "VERANO"; //ddlEvento.SelectedValue;
            ObjCurso.Importe = Convert.ToDouble(txtImporte.Text);            
            ObjCurso.Plan = ddlPlan.SelectedValue;
            ObjCurso.IdMateriaOpt =Convert.ToInt32(ddlMateria_Opt.SelectedValue);
            //if (LinkNombreArchivo.Text != string.Empty)
            //{
            //    Copiar_a_Oficios(LinkNombreArchivo.Text);
            //    ObjCurso.Oficio = LinkNombreArchivo.Text;
            //}
            //else
            //    ObjCurso.Oficio = "";
            try
            {
                
                if (SesionUsu.Editar == 0)                
                    CNCurso.CursoInsertar(ref ObjCurso, ref Verificador);                
                else
                {
                    ObjCurso.IdCurso = Convert.ToInt32(grvCursos.Rows[grvCursos.SelectedIndex].Cells[6].Text);
                    CNCurso.CursoEditar(ref ObjCurso, ref Verificador);
                }

                return Verificador;
                //if (Verificador == "0")
                //{
                //    btnCancelar_Click(null, null);
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Materia registrada correctamente.');", true); //lblMsj.Text = ex.Message;                
                //}
                //else
                //{
                //    string Mensaje = Verificador.Replace("\r", "");
                //    Mensaje = Mensaje.Replace("\n", "");
                //    Mensaje = Mensaje.Replace("'", "");
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //}
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Mensaje);               
                return Mensaje;
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void Copiar_a_OficiosTemp(string NombreArchivo)
        {
            try
            {
                string fileName = NombreArchivo;
                string OrigenArchivo = Path.Combine(Server.MapPath("~/Oficios/Verano/"), fileName);
                string DestinoArchivo = Path.Combine(Server.MapPath("~/OficiosTemp/Verano/"), fileName);
                System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);                
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Mensaje);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void Copiar_a_Oficios(string NombreArchivo)
        {
            try
            {
                //Path.Combine(Server.MapPath("~/OficiosTemp/Verano/"), ddlCiclo.SelectedValue + "-" + ddlDependencia.SelectedValue + "-" + LinkNombreArchivo.Text);                
                string fileName = NombreArchivo; //ListOficio[i].LinkArchivo.Replace("~/OficiosTemp/Verano/", "");
                string OrigenArchivo = Path.Combine(Server.MapPath("~/OficiosTemp/Verano/"), fileName);
                string DestinoArchivo = Path.Combine(Server.MapPath("~/Oficios/Verano/"), fileName);
                System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                System.IO.File.Delete(OrigenArchivo);
                
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Mensaje);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        #endregion



        //protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlCarrera.SelectedValue == "000000")
        //        {
        //            lblOtraCarrera.Visible = true;
        //            txtCarrera.Visible = true;
        //            txtCarrera.Text = string.Empty;
        //        }
        //        else
        //        {
        //            lblOtraCarrera.Visible = false;
        //            txtCarrera.Visible = false;
        //            txtCarrera.Text = ddlCarrera.SelectedItem.Text;
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
        //    }
        //}




        protected void grvCursos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCursos.PageIndex = 0;
            grvCursos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvCursos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnGuardar_Nuevo.Visible = false;
            btnGuardar_Salir.Text = "MODIFICAR";
            //LinkNombreArchivo.Text = string.Empty;
            //LinkNombreArchivo.NavigateUrl = string.Empty;
            //imgBttnEliminar.Visible = false;

            try
            {
                int v = e.NewSelectedIndex;
                ObjCurso.IdCurso = Convert.ToInt32(grvCursos.Rows[v].Cells[6].Text);
                CNCurso.ConsultarCursoSel(ref ObjCurso, ref Verificador);
                if (Verificador == "0")
                {
                    SesionUsu.Editar = 1;
                    MultiView1.ActiveViewIndex = 1;
                    //TabContainer1.ActiveTabIndex = 0;
                    //imgBttnNuevo.Visible = false;
                    ddlDependencia.SelectedValue = ObjCurso.Dependencia;
                    ddlDependencia_SelectedIndexChanged(null, null);
                    ddlCiclo.SelectedValue = ObjCurso.CicloEscolar;
                    ddlPrograma.SelectedValue = Convert.ToString(ObjCurso.IdCarrera);
                    ddlPrograma_SelectedIndexChanged(null, null);
                    //ddlCarrera_SelectedIndexChanged(null, null);
                    ddlPlan.SelectedValue = Convert.ToString(ObjCurso.Plan);
                    ddlPlan_SelectedIndexChanged(null, null);
                    ddlMateria.SelectedValue = Convert.ToString(ObjCurso.IdMateria);
                    ddlMateria_SelectedIndexChanged(null, null);
                    ddlMateria_Opt.SelectedValue = Convert.ToString(ObjCurso.IdMateriaOpt);
                    ddlSemestre.SelectedValue = Convert.ToString(ObjCurso.Semestre);
                    //ddlEvento.SelectedValue = ObjCurso.Evento;
                    txtImporte.Text = Convert.ToString(ObjCurso.Importe);
                    rdoListStatus.SelectedValue = Convert.ToString(ObjCurso.Status);
                    //if (ObjCurso.Oficio != string.Empty)
                    //    if (ObjCurso.Oficio != null)
                    //        if (ObjCurso.Oficio != "")
                    //        {
                    //            Copiar_a_OficiosTemp(ObjCurso.Oficio);
                    //            LinkNombreArchivo.Text = ObjCurso.Oficio;
                    //            LinkNombreArchivo.NavigateUrl = "../OficiosTemp/Verano/" + ObjCurso.Oficio;
                    //            imgBttnEliminar.Visible = true;
                    //        }

                }
                else
                {
                    string Mensaje = Verificador.Replace("\r", "");
                    Mensaje = Mensaje.Replace("\n", "");
                    Mensaje = Mensaje.Replace("'", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r", "");
                Mensaje = Mensaje.Replace("\n", "");
                Mensaje = Mensaje.Replace("'", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void ddlDependencia0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ddlStatus0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {            
            MultiView1.ActiveViewIndex = 0;
            SesionUsu.Editar = -1;
            //imgBttnNuevo.Visible = true;
            CargarGrid();
        }

        //protected void ddlCiclo0_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CargarGrid();
        //}

        protected void ddlNivel0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void btnGuardar_Nuevo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            Verificador = GuardarDatos();
            if (Verificador == "0")
            {
                ddlPrograma.SelectedValue = "0";
                //ddlCarrera_SelectedIndexChanged(null, null);
                ddlSemestre.SelectedValue = "0";
                txtImporte.Text = string.Empty;
                //LinkNombreArchivo.Text = string.Empty;
                //LinkNombreArchivo.NavigateUrl = string.Empty;
            }
            else            
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == -1)            
                CargarGrid();     
            else
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carreras_Verano", ref ddlPrograma, "p_dependencia", ddlDependencia.SelectedValue, "INGRESOS");
                //ddlCarrera_SelectedIndexChanged(null, null);
            }
        }

        //protected void ddlSemestre_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Materias_Verano", ref ddlMateria,"INGRESOS");
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
        //    }
        //}

       
        

        protected void rdoListStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == -1)
            {
                CargarGrid();
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            LimpiarCamposGuarda();
        }        

        protected void grvCursos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int fila = e.RowIndex;
                Verificador = string.Empty;
                ObjCurso.IdCurso =Convert.ToInt32(grvCursos.Rows[fila].Cells[6].Text);
                CNCurso.CursoEliminar(ref ObjCurso, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        

        protected void ddlCarrera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SesionUsu.Editar == -1)
            {                
                CargarGrid();
            }
        }

        protected void imgBttnBuscaMatricula_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }
       

        protected void linBttnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Planes", ref ddlPlan, "p_carrera", ddlPrograma.SelectedValue,  "INGRESOS");
                ddlPlan_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r", "");
                Mensaje = Mensaje.Replace("\n", "");
                Mensaje = Mensaje.Replace("'", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Materias_SIAE", ref ddlMateria, "p_carrera", "p_plan", ddlPrograma.SelectedValue, ddlPlan.SelectedValue, ref ListMateria, "INGRESOS");
                ddlMateria_SelectedIndexChanged(null, null);
                ScriptManager.RegisterStartupScript(this, GetType(), "Materias", "FiltMat();", true);

            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r", "");
                Mensaje = Mensaje.Replace("\n", "");
                Mensaje = Mensaje.Replace("'", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ListMateria[ddlMateria.SelectedIndex].EtiquetaTres == "O")
                //{
                    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_MateriasOpt_SIAE", ref ddlMateria_Opt, "p_carrera", "p_plan", "p_materia", ddlPrograma.SelectedValue, ddlPlan.SelectedValue, ddlMateria.SelectedValue, "INGRESOS");
                    ScriptManager.RegisterStartupScript(this, GetType(), "Materias", "FiltMat();", true);

                //}
            }
            catch (Exception ex)
            {
                string Mensaje = ex.Message.Replace("\r", "");
                Mensaje = Mensaje.Replace("\n", "");
                Mensaje = Mensaje.Replace("'", "");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        //protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        //{
        //    btnGuardar_Nuevo.Visible = true;
        //    btnGuardar_Salir.Text = "GUARDAR Y SALIR";

        //    SesionUsu.Editar = 0;
        //    Session["Cursos"] = null;
        //    imgBttnNuevo.Visible = false;
        //    MultiView1.ActiveViewIndex = 1;
        //    LimpiarCampos();
        //}

        
        protected void btnGuardar_Salir_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            Verificador=GuardarDatos();
            if (Verificador == "0")
            {
                btnCancelar_Click(null, null);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Materia(s) registrada(s) correctamente.');", true); //lblMsj.Text = ex.Message;                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        //protected void bttnAgregaOficio_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (FileOficio.HasFile)
        //        {
        //            int fileSize = FileOficio.PostedFile.ContentLength;
        //            fullPathOficio = Path.Combine(Server.MapPath("../OficiosTemp/Verano/"), ddlCiclo.SelectedValue + "-" + ddlDependencia.SelectedValue + "-" + FileOficio.FileName);
        //            FileOficio.SaveAs(fullPathOficio);
        //            LinkNombreArchivo.Text = ddlCiclo.SelectedValue + "-"+ddlDependencia.SelectedValue+"-"+ FileOficio.FileName;
        //            LinkNombreArchivo.NavigateUrl= "../OficiosTemp/Verano/" + ddlCiclo.SelectedValue + "-" + ddlDependencia.SelectedValue + "-" + FileOficio.FileName;
        //            imgBttnEliminar.Visible = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string MsjError = (ex.Message.Length > 40) ? ex.Message.Substring(0, 40) : ex.Message;
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);

        //    }


        //}

        //protected void imgBttnEliminar_Click(object sender, ImageClickEventArgs e)
        //{            
        //    string OrigenArchivo = Path.Combine(Server.MapPath("~/OficiosTemp/Verano/"), ddlCiclo.SelectedValue + "-" + ddlDependencia.SelectedValue + "-" + LinkNombreArchivo.Text);
        //    System.IO.File.Delete(OrigenArchivo);
        //    LinkNombreArchivo.Text = string.Empty;
        //    LinkNombreArchivo.NavigateUrl = string.Empty;
        //    imgBttnEliminar.Visible = false;
        //}

        protected void bttnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar_Nuevo.Visible = true;
            btnGuardar_Salir.Text = "GUARDAR Y SALIR";

            SesionUsu.Editar = 0;
            Session["Cursos"] = null;
            //imgBttnNuevo.Visible = false;
            MultiView1.ActiveViewIndex = 1;
//            TabContainer1.ActiveTabIndex = 0;
            LimpiarCampos();
        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        //protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

       
    }
}