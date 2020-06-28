using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using CapaEntidad;
using CapaNegocio;
using System.Text;

namespace Recibos_Electronicos.Form
{
    public partial class frmEventos2 : System.Web.UI.Page
    {

        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Oficio CNOficio = new CN_Oficio();
        CN_Usuario CNUsuario = new CN_Usuario();

        Evento Objeventos = new Evento();
        ConceptoCuotaLibre ObjCuotaLibre = new ConceptoCuotaLibre();
        Alumno ObjAlumno = new Alumno();
        private static List<Comun> ListConceptos = new List<Comun>();
        List<ConceptoCuotaLibre> ListCL = new List<ConceptoCuotaLibre>();
        CN_Evento CNeventos = new CN_Evento();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        Oficio ObjOficio = new Oficio();
        Usuario ObjUsuario = new Usuario();
        string Verificador = string.Empty;
        string VerificadorOficios = string.Empty;
        string NombreArchivo;


        // public static int vandera = 0;

        Int32[] Celdas = new Int32[] { 7 };
        Int32[] Celdas2 = new Int32[] { 0, 1, 2 };
        Int32[] Celdas3 = new Int32[] { 7, 10 };
        Int32[] Celdas4 = new Int32[] { 0, 1, 2,4, 9 };

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                inicializar();
            }
        }

        protected void inicializar()
        {
            limpiar();
            SesionUsu.Editar = -1;
            MultiViewEventos.ActiveViewIndex = 0;

            CargarCombos();

            //txtFecha_Evento_Ini.Text = "01" + System.DateTime.Now.ToString("/MM/yyyy");
            //txtFecha_Evento_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            CargarGrid("eventos");

        }

        protected void limpiar()
        {
            btnBuscar.Visible = true;
            imgNuevo.Visible = true;

            txtFecha_Evento_Fin.Text = string.Empty;
            txtFecha_Evento_Ini.Text = string.Empty;
            txtmatricula.Text = string.Empty;

            lblEvento.Text = string.Empty;

            txtDescripcion.Text = string.Empty;
            txtEmail_res.Text = string.Empty;

            txtFecha_Evento_Ini.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha_Evento_Fin.Text = DateTime.Now.ToString("dd/MM/yyyy");


            ddlNivel.SelectedIndex = 0;


            txtObservacion.Text = string.Empty;
            txtImporte.Text = string.Empty;
            rbnExclusivo.SelectedValue = "N";
            grdCuotaLibre.DataBind();
            grdAutorizados.DataBind();


            limpia_oficio();

            pnlMatAutorizadas.Visible = false;

            ddlStatus.SelectedValue = "S";
            ddlDependencia.Enabled = true;

        }
        private List<Evento> GetList_Oficios()
        {
            try
            {
                List<Evento> List = new List<Evento>();

                Objeventos.Eventos = SesionUsu.Evento;
                CNeventos.ConsultarOficios(SesionUsu.Evento, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void limpia_oficio()
        {
            txtObservaciones_oficio.Text = string.Empty;
            txtNoOficio.Text = string.Empty;
            txtFirma.Text = string.Empty;
            txtFechaOficio.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        protected void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Evento_Perido_Pago", ref ddlTipo_Periodo, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Evento_Tipo_Persona", ref ddlTipo_Persona, "INGRESOS");


                ddlTipo_Periodo.SelectedValue = "20";
                ddlTipo_Persona.SelectedValue = "1";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);
            }
        }
        private void CargarGrid(string tipo)
        {
            try
            {
                DataTable dt = new DataTable();

                if (tipo == "eventos")
                {
                    grdEventos.DataSource = dt;

                    grdEventos.DataSource = GetList();
                    grdEventos.DataBind();

                    if (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "SA")
                    {
                        CNComun.HideColumns(grdEventos, Celdas);
                    }
                    else
                    {
                        CNComun.HideColumns(grdEventos, Celdas3);
                    }


                }

                else if (tipo == "conceptos")
                {
                    grdCuotaLibre.DataSource = dt;
                    grdCuotaLibre.DataSource = GetList_conceptos();
                    grdCuotaLibre.DataBind();

                    if (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "SA")
                    {
                        if (grdCuotaLibre.Rows.Count > 0)
                            CNComun.HideColumns(grdCuotaLibre, Celdas2);
                    }
                    else
                    {
                        if (grdCuotaLibre.Rows.Count > 0)
                            CNComun.HideColumns(grdCuotaLibre, Celdas4);
                    }

                    if (grdCuotaLibre.Rows.Count > 0) ddlNivel.Enabled = false;
                    else ddlNivel.Enabled = true;


                }

                else if (tipo == "autorizados")
                {
                    grdAutorizados.DataSource = dt;
                    grdAutorizados.DataSource = GetList_Autorizados();
                    grdAutorizados.DataBind();
                }
                else if (tipo == "oficios")
                {
                    Int32[] Celdas1 = new Int32[] { 6 };
                    grdOficios.DataSource = dt;
                    grdOficios.DataSource = GetList_Oficios();
                    grdOficios.DataBind();
                    if(grdOficios.Rows.Count>0)
                        CNComun.HideColumns(grdOficios, Celdas1);

                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Aún no se han capturado ningún importe para este evento. " + ex.Message + "');", true);

            }
        }

        private void CargarGrid(int indexCopia)
        {
            grdEventos.DataSource = null;
            grdEventos.DataBind();
            try
            {
                DataTable dt = new DataTable();
                grdEventos.DataSource = dt;
                grdEventos.DataSource = GetList();
                grdEventos.DataBind();



                if (grdEventos.Rows.Count > 0)
                {
                    CNComun.HideColumns(grdEventos, Celdas);

                }
            }
            catch (Exception ex)
            {
                //  lblMensaje.Text = ex.Message;
            }


        }




        private List<Evento> GetList()
        {
            try
            {
                List<Evento> List = new List<Evento>();

                Objeventos.Dependencia = ddlDependencia.SelectedValue;
                //Objeventos.Fecha_inicial = txtFecIniB.Text;
                //Objeventos.Fecha_final = txtFecFinB.Text;
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



        private List<ConceptoCuotaLibre> GetList_conceptos()
        {
            try
            {
                List<ConceptoCuotaLibre> List = new List<ConceptoCuotaLibre>();
                ObjCuotaLibre.Evento = SesionUsu.Evento; ;
                CNeventos.ConsultarEventos_conceptos(ref ObjCuotaLibre, ref List);

                return List;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Alumno> GetList_Autorizados()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();

                ObjAlumno.Evento = SesionUsu.Evento;
                CNAlumno.ConsultarAutorizado(ref ObjAlumno, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        protected void txtFecha_Evento_Fin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtFecha_Evento_Ini_TextChanged(object sender, EventArgs e)
        {

        }



        //protected void btn_Nuevo_Click(object sender, EventArgs e)
        //{

        //    MultiViewEventos.ActiveViewIndex = 1;

        //    habilita_campos();

        //    btnBuscar.Visible = false;
        //    imgNuevo.Visible = false;
        //    //CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel, "INGRESOS");
        //    //CargarCombos();
        //    txtFecha_Evento_Fin.Text = string.Empty;
        //    SesionUsu.Editar = 0;
        //    Session["CuotaLibre"] = null;
        //    grdCuotaLibre.DataSource = null;
        //    grdCuotaLibre.DataBind();

        //    TabPanel3.Enabled = false;
        //}

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabContainerDatos.ActiveTabIndex = TabContainerDatos.ActiveTabIndex - 1;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            GuardarDatos();

            txtObservacion.Text = txtDescripcion.Text;
            reemplazar();

        }
        private void GuardarDatos()
        {
            Objeventos.Dependencia = ddlDependencia.SelectedValue.ToString();
            Objeventos.Descripcion = txtDescripcion.Text;
            Objeventos.Eventos = lblEvento.Text;
            Objeventos.Fecha_inicial = txtFecha_Evento_Ini.Text;
            Objeventos.Fecha_final = txtFecha_Evento_Fin.Text;
            Objeventos.Email_Res = txtEmail_res.Text;
            Objeventos.Email_Corres = "";
            Objeventos.Nivel = ddlNivel.SelectedValue;
            Objeventos.Concepto = "";
            Objeventos.Status = ddlStatus.SelectedValue;
            Objeventos.Ini_Matricula = txtmatricula.Text;
            Objeventos.Autorizacion = rbnExclusivo.SelectedValue;
            Objeventos.Tipo_Periodo = ddlTipo_Periodo.SelectedValue;
            Objeventos.Tipo = ddlDirigido.SelectedValue;
            Objeventos.Observaciones = txtEspecificacion.Text;

            try
            {
                Verificador = string.Empty;

                if (SesionUsu.Editar == 0)
                {

                    CNeventos.EventoInsertar(Objeventos, SesionUsu.Usu_Nombre, ref Verificador);

                    if (Verificador == "0")
                    {
                        SesionUsu.Editar = 1;

                        lblEvento.Text = Objeventos.Eventos;
                        SesionUsu.Evento = lblEvento.Text;

                        TabContainerDatos.Tabs[1].Enabled = true;
                        TabContainerDatos.Tabs[2].Enabled = true;
                        TabContainerDatos.Tabs[3].Enabled = true;
                    }

                }
                else
                {
                    Objeventos.Eventos = SesionUsu.Evento;
                    CNeventos.EventoEditar(Objeventos, SesionUsu.Usu_Nombre, ref Verificador);
                }

                if (Verificador != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);
                }
                else
                {
                    TabContainerDatos.ActiveTabIndex = TabContainerDatos.ActiveTabIndex + 1;

                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);
            }
        }



        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid("eventos");
        }



        protected void ddlConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    ddlConcepto.Items.Clear();
            // CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Evento_Conceptos", ref ddlConcepto, "p_nivel", "p_dependencia", "p_tipo_participante", ddlNivel.SelectedValue, ddlDependencia.SelectedValue, dllTipo_Persona.SelectedValue, ref ListConceptos, "INGRESOS");

            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_todos", ref ddlConcepto0, "p_nivel", "parametro2", ddlNivel.SelectedValue, "1", ref ListConceptos, "INGRESOS");
            ddlConcepto0.Items.Add("Conceptos básicos...");
            CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Conceptos_basicos", ref ddlConceptoFil, "p_nivel", "parametro2", ddlNivel.SelectedValue, "1", ref ListConceptos, "INGRESOS");
            ddlConceptoFil.Items.Add("Más...");

            //ddlConcepto.SelectedIndex = 0;
            ddlConcepto0.SelectedIndex = 0;
        }

        protected void rdoListAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEventos_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEventos.PageIndex = 0;
            grdEventos.PageIndex = e.NewPageIndex;
            CargarGrid(0);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ObjCuotaLibre = new ConceptoCuotaLibre();

                if (ddlConceptoFil.Visible == true)
                {
                    ObjCuotaLibre.Concepto = ddlConceptoFil.SelectedValue;
                }
                else ObjCuotaLibre.Concepto = ddlConcepto0.SelectedValue;

                ObjCuotaLibre.DescConcepto = ddlConcepto0.SelectedItem.Text;
                ObjCuotaLibre.Dependencia = Convert.ToInt32(ddlDependencia.SelectedValue);
                ObjCuotaLibre.Carrera = Convert.ToInt32(ddlTipo_Persona.SelectedValue);
                ObjCuotaLibre.DescCarrera = ddlTipo_Persona.SelectedItem.Text;
                ObjCuotaLibre.Importe = Convert.ToDouble(txtImporte.Text);
                ObjCuotaLibre.Status = Convert.ToChar("A");
                string Observaciones = txtObservacion.Text;
                Observaciones = Observaciones.Replace(' ', '_');
                //Observaciones = translate(Observaciones, 'áéíóúÁÉÍÓÚ', 'aeiouAEIOU');
                //Observaciones.Normalize(NormalizationForm.FormD);
                ObjCuotaLibre.Observaciones = Observaciones.PadRight(Observaciones.Length + 1, ' ');
                ObjCuotaLibre.Evento = lblEvento.Text;

                CNeventos.insertarConceptoCuotaLibre(ref ObjCuotaLibre, ref Verificador);

                if (Verificador != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
                else
                {
                    CargarGrid("conceptos");
                    //  lblMensaje.Text = "Los datos se guardaron correctamente.";
                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
        }

        protected void ddlConcepto0_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlConcepto0.SelectedValue == "Conceptos básicos...")
            {
                ddlConcepto0.SelectedIndex = 0;
                panelConceptoTodos.Visible = false;
                panelConceptosFil.Visible = true;

            }
            else
            {
                txtObservacion.Text = ddlConcepto0.SelectedItem.Text;
                txtObservaciones_TextChanged(null, null);
            }
        }

        protected void grdCuotaLibre_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


        }

        protected void rbnExclusivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbnExclusivo.SelectedValue == "S") pnlMatAutorizadas.Visible = true;
            else pnlMatAutorizadas.Visible = false;
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBttnBuscaMatricula_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ObjAlumno.Matricula = txtMatriculaEx.Text.ToUpper();

                ObjAlumno.Evento = SesionUsu.Evento;

                CNAlumno.ConsultarAlumnoAutorizadoSel(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    lblNombreAlumno.Text = ObjAlumno.Nombre;
                    btnAgregarAlum.Visible = true;

                }
                else
                {
                    lblNombreAlumno.Text = string.Empty;
                    btnAgregarAlum.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);

            }
        }

        protected void txtMatriculaEx_TextChanged(object sender, EventArgs e)
        {


        }

        protected void btnAgregarAlum_Click(object sender, EventArgs e)
        {

            ObjAlumno.Evento = SesionUsu.Evento;
            ObjAlumno.Matricula = txtMatriculaEx.Text.ToUpper();
            ObjAlumno.Nombre = lblNombreAlumno.Text;
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            ObjAlumno.StatusMatricula = "A";

            ObjAlumno.TipoPersonaStr = "N";
            ObjAlumno.Nivel = ddlNivel.SelectedValue;
            ObjAlumno.Sede = "TUXTLA";
            try
            {

                Verificador = string.Empty;

                CNAlumno.AutorizadoInsertarMatricula(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    // lblMensaje.Text = "Los datos se guardaron correctamente.";
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);

                }

                txtMatriculaEx.Text = string.Empty;
                lblNombreAlumno.Text = string.Empty;
                txtMatriculaEx.Focus();

                CargarGrid("autorizados");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);

            }

        }

        protected void btn_Nuevo_Click(object sender, ImageClickEventArgs e)
        {
            limpiar();

            habilita_campos();
            //  Panel1.Visible = false; 
            SesionUsu.Editar = 0;

            TabContainerDatos.ActiveTabIndex = 0;
            TabContainerDatos.Tabs[1].Enabled = false;
            TabContainerDatos.Tabs[2].Enabled = false;
            TabContainerDatos.Tabs[3].Enabled = false;

            MultiViewEventos.ActiveViewIndex = 1;

            if (rbnExclusivo.SelectedValue == "S") pnlMatAutorizadas.Visible = true;
            else pnlMatAutorizadas.Visible = false;

            

        }

        private void agregar_oficio()
        {

            String fileExtension = "";
            Boolean fileOK = false;

            if (FileOficio.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(FileOficio.FileName).ToLower();

                NombreArchivo = FileOficio.FileName.ToUpper();
                NombreArchivo = NombreArchivo.Replace(" ", "_");
                NombreArchivo = NombreArchivo.Replace("%", string.Empty);

                String[] allowedExtensions =
                    {".pdf", ".png", ".jpeg", ".jpg"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        String path = Server.MapPath("~/Oficios/Eventos/");
                        string ruta_archivo = string.Empty;

                        ruta_archivo = path + NombreArchivo;
                        FileOficio.PostedFile.SaveAs(ruta_archivo);
                        NombreArchivo = NombreArchivo;


                        Objeventos.Eventos = lblEvento.Text;
                        Objeventos.Oficio = NombreArchivo;

                        Objeventos.FechaOficio = txtFechaOficio.Text;
                        Objeventos.NoOficio = txtNoOficio.Text;
                        Objeventos.Firma = txtFirma.Text;
                        Objeventos.Observaciones = txtObservaciones_oficio.Text;
                        CNeventos.Insertar_oficio(Objeventos, ref Verificador);

                        if (Verificador == "0")
                        {
                            CargarGrid("oficios");
                            TabContainerDatos.ActiveTabIndex = +TabContainerDatos.ActiveTabIndex + 1;
                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Para continuar debe adjuntar un archivo');", true);
            }
        }

        //private void Copiar_a_Oficios(List<Oficio> ListOficio)
        //{
        //    try
        //    {
        //        for (int i = 0; i < ListOficio.Count; i++)
        //        {
        //            string fileName = ListOficio[i].LinkArchivo.Replace("~/OficiosTemp/", "");
        //            string OrigenArchivo = Path.Combine(Server.MapPath("~/OficiosTemp"), ListOficio[i].NombreArchivo); //System.IO.Path.Combine(Origen, fileName);
        //            string DestinoArchivo = Path.Combine(Server.MapPath("~/Oficios/Eventos/"), ListOficio[i].NombreArchivo);  //System.IO.Path.Combine(Destino, fileName);
        //            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
        //            System.IO.File.Delete(OrigenArchivo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = ex.Message;
        //    }
        //}

        private void Copiar_a_OficiosTemp(List<Oficio> ListOficio)
        {
            try
            {
                for (int i = 0; i < ListOficio.Count; i++)
                {
                    string fileName = ListOficio[i].LinkArchivo.Replace("~/Oficios/", "");
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/Oficios"), ListOficio[i].NombreArchivo); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/OficiosTemp"), ListOficio[i].NombreArchivo);  //System.IO.Path.Combine(Destino, fileName);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);

            }
        }
        private void ImagenArchivoCargado(string NombreArchivo)
        {
            //lblMensaje.Text = string.Empty;
            //string TipoImagen;
            //try
            //{
            //    if (NombreArchivo.Contains(".JPG") || NombreArchivo.Contains(".PNG") || NombreArchivo.Contains(".GIF"))
            //        imgArchivos.ImageUrl = "~/Imagenes/" + "formatojpg.jpg";
            //    else if (NombreArchivo.Contains(".DOCX") || NombreArchivo.Contains(".DOC") || NombreArchivo.Contains(".PDF"))
            //    {
            //        TipoImagen = (NombreArchivo.Contains(".DOCX") == true) ? "word.png" : (NombreArchivo.Contains(".DOC") == true) ? "word.png" : "pdf1.jpg";
            //        imgArchivos.ImageUrl = "~/Imagenes/" + TipoImagen;
            //    }
            //    else
            //        imgArchivos.ImageUrl = "~/Imagenes/subir_archivos.PNG";
            //}
            //catch (Exception ex)
            //{
            //    lblMensaje.Text = ex.Message;
            //}
        }

        protected void bttnElimininarOficio_Click(object sender, EventArgs e)
        {
            //LinkNombreArchivo.Text = string.Empty; //FileOficio.FileName.ToUpper();
            //LinkNombreArchivo.NavigateUrl = string.Empty;
        }

        protected void ddlConceptoFil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlConceptoFil.SelectedValue == "Más...")
            {
                ddlConceptoFil.SelectedIndex = 0;
                panelConceptosFil.Visible = false;
                panelConceptoTodos.Visible = true;
            }

            else
            {
                txtObservacion.Text = ddlConceptoFil.SelectedItem.Text;
                txtObservaciones_TextChanged(null, null);
            }

            reemplazar();
        }

        private void reemplazar()
        {
            txtObservacion.Text = txtObservacion.Text.Replace(" ", "_");
            txtObservacion.Text = txtObservacion.Text + " ";
        }

        protected void btnAdjuntar_Click(object sender, EventArgs e)
        {
            elimina_documento();
            agregar_oficio();
            GuardaOficio();
            CargarGrid("oficios");
            //busca_oficio();


        }

        protected void GuardaOficio()
        {
            //Objeventos.Eventos = lblEvento.Text;
            //Objeventos.Oficio = lblOficio.Text;

            //Objeventos.FechaOficio = txtFechaOficio.Text;
            //Objeventos.NoOficio = txtNoOficio.Text;
            //Objeventos.Firma = txtFirma.Text;
            //Objeventos.Observaciones = txtObservaciones_oficio.Text;

            
            //CNeventos.Editar_oficio(Objeventos, ref Verificador);
        }

        //private void busca_oficio()
        //{
        //    try
        //    {
        //        Objeventos = new Evento();
        //        Objeventos.Eventos = SesionUsu.Evento;
        //        Verificador = string.Empty;

        //        CNeventos.ConsultarOficio(ref Objeventos, ref Verificador);

        //        if (Verificador != "0")
        //        {                 
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Ocurrió un error al buscar el registro');", true);  //lblMsj.Text = ex.Message;

        //        }
        //        else
        //        {
        //            txtFechaOficio.Text = Objeventos.FechaOficio;
        //            txtFirma.Text = Objeventos.Firma;
        //            txtNoOficio.Text = Objeventos.NoOficio;
        //            txtObservaciones_oficio.Text = Objeventos.Observaciones;
        //            lblOficio.Text = Objeventos.Oficio;
        //            lnkEliminar_Oficio.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //lblMensaje.Text = ex.Message;
        //    }

        //}

        //protected void lnkEliminar_Oficio_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Objeventos = new Evento();
        //        Objeventos.Eventos = SesionUsu.Evento;
        //        Objeventos.Oficio = "";
        //        Objeventos.FechaOficio = "";
        //        Objeventos.NoOficio = "";
        //        Objeventos.Firma = "";
        //        Objeventos.Observaciones = "";

        //        Verificador = string.Empty;
        //        CNeventos.Editar_oficio(Objeventos, ref Verificador);

        //        if (Verificador != "0")
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No se pudo eliminar el archivo');", true);

        //        }
        //        else
        //        {
        //            elimina_documento();
        //            limpia_oficio();
        //            lblOficio.Text = "Sin Oficio";
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Archivo eliminado correctamente');", true);

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        private void elimina_documento()
        {
            //if (System.IO.File.Exists(@"~/Oficios/Eventos/" + lblOficio.Text))
            //{
            //    try
            //    {
            //        System.IO.File.Delete(@"~/Oficios/Eventos/" + lblOficio.Text);
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Archivo eliminado correctamente');", true);

            //    }
            //    catch (System.IO.IOException e)
            //    {
            //        //Console.WriteLine(e.Message);
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No se pudo eliminar el archivo');", true);

            //        return;
            //    }
            //}
        }

        protected void index_linbtn(object sender, string tipo)
        {
            //LinkButton cbi = (LinkButton)(sender);
            //GridViewRow row = (GridViewRow)cbi.NamingContainer;
            //if (tipo == "eventos") grdEventos.SelectedIndex = row.RowIndex;
            //else if (tipo == "documentos") grdEventos.SelectedIndex = row.RowIndex;
            //else if (tipo == "conceptos") grdCuotaLibre.SelectedIndex = row.RowIndex;

            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            if (tipo == "eventos") grdEventos.SelectedIndex = row.RowIndex;
            else if (tipo == "documentos") grdEventos.SelectedIndex = row.RowIndex;
            else if (tipo == "conceptos") grdCuotaLibre.SelectedIndex = row.RowIndex;
            else if (tipo == "oficios") grdOficios.SelectedIndex = row.RowIndex;

        }

        //protected void lnkVerOficio_Click(object sender, EventArgs e)
        //{
        //    string ruta = "../Oficios/Eventos/" + lblOficio.Text;

        //    string _open = "window.open('" + ruta + "', '_newtab');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        //}

        protected void ctrl_editar_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, "eventos");

                SesionUsu.Editar = 1;
                btnBuscar.Visible = false;
                imgNuevo.Visible = false;


                int v = grdEventos.SelectedIndex;
                SesionUsu.Evento = grdEventos.Rows[v].Cells[1].Text;
                Objeventos.Eventos = SesionUsu.Evento;

                CNeventos.ConsultarUnevento(ref Objeventos, ref Verificador);

                if (Verificador == "0")
                {
                    CargarCombos();
                    ddlDependencia.SelectedValue = Objeventos.Dependencia;
                    txtFecha_Evento_Fin.Text = Objeventos.Fecha_final;
                    txtFecha_Evento_Ini.Text = Objeventos.Fecha_inicial;
                    ddlStatus.SelectedValue = Objeventos.Status;
                    lblEvento.Text = Objeventos.Eventos;
                    txtDescripcion.Text = Objeventos.Descripcion;
                    txtEmail_res.Text = Objeventos.Email_Res;
                    ddlNivel.SelectedValue = Objeventos.Nivel;
                    ddlNivel_SelectedIndexChanged(null, null);
                    ddlDirigido.SelectedValue = Objeventos.Tipo;
                    txtmatricula.Text = Objeventos.Ini_Matricula;
                    rbnExclusivo.SelectedValue = Objeventos.Autorizacion;
                    lblUsuSolicitado.Text = Objeventos.Usuario_Solicita;
                    lblFechaSolicitado.Text = Objeventos.Fecha_Solicitud;
                    lblUsuAutorizado.Text = Objeventos.Usuario_Autoriza;
                    lblFechaAutorizado.Text = Objeventos.Fecha_Autorizacion;
                    txtEspecificacion.Text = Objeventos.Observaciones;
                    CargarGrid("conceptos");
                    CargarGrid("autorizados");
                    CargarGrid("oficios");
                    Panel1.Visible = true;

                    //busca_oficio();

                    //FALTA LLENAR LOS CAMPOS EN LOS OBJETOS GG

                    MultiViewEventos.ActiveViewIndex = 1;
                    TabContainerDatos.ActiveTabIndex = 0;
                    TabContainerDatos.Tabs[1].Enabled = true;
                    TabContainerDatos.Tabs[2].Enabled = true;
                    TabContainerDatos.Tabs[3].Enabled = true;


                    if (SesionUsu.Usu_Central_Tipo == "A" || SesionUsu.Usu_Central_Tipo == "SA")
                    {

                    }
                    else
                    {
                        if (grdEventos.Rows[v].Cells[8].Text != "SOLICITADO")
                        {
                            inhabilita_campos();
                            btnSiguiente2.Visible = false;
                        }
                    }

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

        protected void lnkEliminarConc_Click(object sender, EventArgs e)
        {
            try
            {
                index_linbtn(sender, "conceptos");

                int v = grdCuotaLibre.SelectedIndex;

                ObjCuotaLibre.Evento = grdCuotaLibre.Rows[v].Cells[0].Text;
                ObjCuotaLibre.Id_Concepto = Convert.ToInt32(grdCuotaLibre.Rows[v].Cells[4].Text);
                ObjCuotaLibre.Carrera = Convert.ToInt32(grdCuotaLibre.Rows[v].Cells[2].Text);

                Verificador = string.Empty;
                CNeventos.Eliminar_Concepto_evento(ref ObjCuotaLibre, ref Verificador);

                if (Verificador != "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true);


                }
                else
                {
                    CargarGrid("conceptos");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);

            }

        }

        protected void lnkVerOfi_Click(object sender, EventArgs e)
        {

            string nombre_oficio = string.Empty;
            index_linbtn(sender, "oficios");
            int v = grdOficios.SelectedIndex;

            nombre_oficio = Convert.ToString(grdOficios.Rows[v].Cells[6].Text);
            string ruta = "../Oficios/Eventos/" + nombre_oficio;

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void lnkGenRef_Click(object sender, EventArgs e)
        {

            index_linbtn(sender, "eventos");


            int v = grdEventos.SelectedIndex;
            string ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx?evento=" + grdEventos.Rows[v].Cells[1].Text;

            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            MultiViewEventos.ActiveViewIndex = 0;
        }

        protected void dllTipo_Persona_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtImporte.Text = string.Empty;
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP037";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }



        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP037_Excel";
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void btnSiguiente2_Click(object sender, EventArgs e)
        {
            elimina_documento();
            agregar_oficio();
            GuardaOficio();

            //busca_oficio();

            TabContainerDatos.ActiveTabIndex = +TabContainerDatos.ActiveTabIndex + 1;
        }

        protected void ctrl_eliminar_Click(object sender, EventArgs e)
        {


            index_linbtn(sender, "eventos");

            int v = grdEventos.SelectedIndex;

            Objeventos.Status = "X";
            Objeventos.Eventos = grdEventos.Rows[v].Cells[1].Text;


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
                    CargarGrid("eventos");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Registro eliminado correctamente');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);
            }
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            inicializar();
        }


     
        private void inhabilita_campos()
        {
            txtDescripcion.Enabled = false;
            txtEmail_res.Enabled = false;
            txtFechaOficio.Enabled = false;
            txtFirma.Enabled = false;
            txtImporte.Enabled = false;
            txtmatricula.Enabled = false;
            txtNoOficio.Enabled = false;
            txtObservacion.Enabled = false;
            txtObservaciones_oficio.Enabled = false;
            ddlDependencia.Enabled = false;
            ddlDirigido.Enabled = false;
            ddlNivel.Enabled = false;
            ddlStatus.Enabled = false;
            ddlTipo_Periodo.Enabled = false;
            ddlTipo_Persona.Enabled = false;
            ddlConceptoFil.Enabled = false;

            //lnkEliminar_Oficio.Visible = false;
        }

        private void habilita_campos()
        {
            txtDescripcion.Enabled = true;
            txtEmail_res.Enabled = true;
            txtFechaOficio.Enabled = true;
            txtFirma.Enabled = true;
            txtImporte.Enabled = true;
            txtmatricula.Enabled = true;
            txtNoOficio.Enabled = true;
            txtObservacion.Enabled = true;
            txtObservaciones_oficio.Enabled = true;
            ddlDependencia.Enabled = true;
            ddlDirigido.Enabled = true;
            ddlNivel.Enabled = true;

            if (SesionUsu.Usu_Central_Tipo == "S" || SesionUsu.Usu_Central_Tipo == "SA")
                ddlStatus.Enabled = true;
            else
                ddlStatus.Enabled = false;

            ddlTipo_Periodo.Enabled = true;
            ddlTipo_Persona.Enabled = true;
            ddlConceptoFil.Enabled = true;

            //lnkEliminar_Oficio.Visible = true;


        }

        protected void ctrl_eliminarOficio_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre_oficio = string.Empty;

                Verificador = string.Empty;

                index_linbtn(sender, "oficios");
                int v = grdOficios.SelectedIndex;

                Objeventos = new Evento();
                Objeventos.Id = Convert.ToInt32(grdOficios.Rows[v].Cells[0].Text);
                CNeventos.Eliminar_Oficio(Objeventos, ref Verificador);

                if (Verificador == "0")
                {

                    //ELIMINA EL DOCUMENTO FISICO
                    nombre_oficio = Convert.ToString(grdOficios.Rows[v].Cells[4].Text);
                    if (System.IO.File.Exists(@"~/Oficios/Eventos/" + nombre_oficio))
                    {
                        try
                        {
                            System.IO.File.Delete(@"~/Oficios/Eventos/" + nombre_oficio);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(1, 'Archivo eliminado correctamente');", true);

                        }
                        catch (System.IO.IOException ee)
                        {
                            //Console.WriteLine(e.Message);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'No se pudo eliminar el archivo');", true);

                            return;
                        }
                    }


                    CargarGrid("oficios");
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


        protected void lnkVerImagenDesc_Click(object sender, EventArgs e)
        {

        }
    }
}