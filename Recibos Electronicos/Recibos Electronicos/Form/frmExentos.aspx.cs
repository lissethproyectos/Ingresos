using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;
using CapaEntidad;
using CapaNegocio;
namespace Recibos_Electronicos.Form
{
    public partial class frmExentos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        string VerificadorOficios = string.Empty;
        string VerificadorConceptos = string.Empty;
        CN_Comun CNComun = new CN_Comun();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Empleado CNEmpleado = new CN_Empleado();
        CN_Oficio CNOficio = new CN_Oficio();
        CN_Factura CNFactura = new CN_Factura();
        CN_Familiar CNFamiliar = new CN_Familiar();
        CN_DetConcepto CNDetDesc = new CN_DetConcepto();
        private static List<Comun> ListEvento = new List<Comun>();
        private static List<Comun> ListCiclo = new List<Comun>();
        private static List<Comun> ListCiclo2 = new List<Comun>();
        private static List<Comun> ListFamiliar = new List<Comun>();
        private static List<Comun> ListBeneficiario = new List<Comun>();
        //private static List<Comun> ListTiposDesc = new List<Comun>();
        private static List<Comun> ListConcepto = new List<Comun>();
        List<Oficio> ListOficio = new List<Oficio>();
        List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
        //private string[] UsuariosSuper = { "OMAR", "MARCOSA", "VICENTE", "OSMANDI" };
        private string[] ConceptosPosgrado = { "M0205", "E0205", "D0205", "M0203", "E0203", "D0203", "M0201", "E0201", "D0201", "M0301", "E0301", "D0301", };
        //string[] usuAdmin;
        Int32[] Celdas = new Int32[] { 0 };
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        Alumno ObjMatricula = new Alumno();
        Persona ObjEmpleado = new Persona();
        Alumno ObjFamiliar = new Alumno();
        Alumno ObjEmpleadoAlumno = new Alumno();
        Oficio ObjOficio = new Oficio();
        Factura ObjFactura = new Factura();
        DetConcepto ObjConcepto = new DetConcepto();
        #endregion

        #region <Botones y Eventos>
        private void BuscaEmpleado()
        {
            txtNombreEmp.Text = string.Empty;
            //txtApellidosEmp.Text = string.Empty;
            grvEmpleados.DataSource = null;
            grvEmpleados.DataBind();
            if (ddlEmpleado.SelectedValue != "0")
            {
                CargarGridEmpleados("N");
                if (grvEmpleados.Rows.Count >= 1)
                    grvEmpleados.SelectedIndex = 0;
            }
            //grvEmpleados_SelectedIndexChanged(null, null);
        }
        private void BuscaHijo(string Busca)
        {
            if (grvEmpleados.Rows.Count > 0)
            {
                //ddlHijo.Items.Clear();
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Grid_Hijos", ref ddlHijo, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Parentesco", ref ddlParentesco, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
                if (Busca == "N")
                {
                    if (ListFamiliar.Count >= 1)
                    {
                        try
                        {
                            ddlHijo.SelectedValue = ListFamiliar[ddlEmpleado.SelectedIndex].EtiquetaDos;
                        }
                        catch (Exception)
                        {
                            lblErrorBuscEmp.Visible = true;
                            lblErrorBuscEmp.Text = "No se encontro al alumno, en la asociación Empleado/Alumno, verificar.";
                            ddlHijo.SelectedValue = "9999999";
                        }
                    }
                }
            }
            else
                ddlHijo.Items.Clear();

        }
        private void BuscaDatosAlumno()
        {
            BuscaMatricula();
            EmpleadoMatricula();
            if (SesionUsu.Editar == 0)
            {
                ddlSubTipo.SelectedValue = "X";
                if (ddlCiclo_D.Items.Count >= 1)
                {
                    if (ddlNivel.SelectedValue == "M" || ddlNivel.SelectedValue == "D" || ddlNivel.SelectedValue == "E")
                    {
                        ddlCiclo_D.SelectedValue = "20";
                        ddlCiclo_D_SelectedIndexChanged(null, null);
                    }
                }
            }
        }
        private void BuscaMatricula()
        {
            //lblMsj.Text = string.Empty;
            try
            {
                ObjMatricula.Matricula = txtMatricula.Text.ToUpper();
                ObjMatricula.Evento = ddlEvento.SelectedValue;
                ObjMatricula.TipoPersona = 1;
                ObjMatricula.Nivel = ddlNivel.SelectedValue;
                ObjMatricula.CicloEscolar = ddlCicloAlum.SelectedValue;
                CNAlumno.ConsultarAlumno(ref ObjMatricula, ref Verificador);
                if (Verificador == "0")
                {
                    ddlDependencia_D.SelectedValue = ObjMatricula.Dependencia;
                    ddlDependencia_D_SelectedIndexChanged(null, null);
                    try
                    {
                        ddlCarrera.SelectedValue = ObjMatricula.Carrera;
                    }
                    catch (Exception)
                    {
                        ddlCarrera.SelectedValue = "000000";
                    }
                    ddlCarrera_SelectedIndexChanged(null, null);
                    txtCarrera.Text = ObjMatricula.DescCarrera;
                    txtNombre.Text = ObjMatricula.Nombre;
                    txtPaterno.Text = ObjMatricula.APaterno;
                    txtMaterno.Text = ObjMatricula.AMaterno;
                    txtSemestre.Text = ObjMatricula.Semestre;
                    txtGrupo.Text = ObjMatricula.Grupo;
                    txtFechaNacimiento.Text = ObjMatricula.FechaNacimiento;
                    txtFechaNacimiento.Enabled = (ObjMatricula.FechaNacimiento==string.Empty)?true:false;
                    rdoBttnLstGenero.SelectedValue =Convert.ToString(ObjMatricula.Genero);
                    TabContainer1.Tabs[1].Enabled = true;
                    TabContainer1.Tabs[2].Enabled = true;
                    //TabContainer1.ActiveTabIndex=1;
                    Registrar.Visible = false;
                }
                else
                {
                    txtSemestre.Text = string.Empty;
                    txtGrupo.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtPaterno.Text = string.Empty;
                    txtMaterno.Text = string.Empty;
                    txtFechaNacimiento.Text = string.Empty;
                    rdoBttnLstGenero.ClearSelection();
                    Registrar.Visible = true;
                    string MsjError="Verifique matrícula(" + txtMatricula.Text + ") y/ó Nivel de Estudios(" + ddlNivel.SelectedItem.Text + ") ó de Click en el botón Registrar Matrícula";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;
                    //lblMsj.Text = "Verifique matrícula(" + txtMatricula.Text + ") y/ó Nivel de Estudios(" + ddlNivel.SelectedItem.Text + ") ó de Click en el botón Registrar Matrícula";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + "La matrícula no corresponde a su Dependencia/Escuela/Facultad " + ex.Message + "');", true);  //lblMsjFam.Text = Verificador;
                //lblMsj.Text = "La matrícula no corresponde a su Dependencia/Escuela/Facultad "+ex.Message;
            }
        }
        private void EmpleadoMatricula()
        {
            //lblMsj.Text = string.Empty;
            Verificador = string.Empty;            
            try
            {
                CNAlumno.ConsultarEmpleadoMatricula(ref ObjEmpleadoAlumno, txtMatricula.Text.ToUpper(), ref Verificador);
                if (Convert.ToString(ObjEmpleadoAlumno.IdEmpleado) != "0")
                {
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleado", ref ddlEmpleado, "p_id_empleado", "p_id_familiar", Convert.ToString(ObjEmpleadoAlumno.IdEmpleado), Convert.ToString(ObjEmpleadoAlumno.IdFamiliar), ref ListFamiliar);
                    BuscaEmpleado();
                    BuscaHijo("N");
                }

                //if (Verificador == "0" && ObjEmpleadoAlumno.IdPersona != 0)
                //{
                //    rdoBttnTipoPersonal.SelectedValue = ObjEmpleadoAlumno.TipoPersonaStr;
                //    ddlDependencia_Empleado.SelectedValue = ObjEmpleadoAlumno.Dependencia;
                //    ddlDependencia_Empleado_SelectedIndexChanged(null, null);
                //    ddlEmpleado.SelectedValue = Convert.ToString(ObjEmpleadoAlumno.IdPersona);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void Cargarcombos()

        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Familiares", ref ddlParentescoFam);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel1, "INGRESOS");
                //ddlNivel.Items.Insert(0, new ListItem("NINGUNO", "0"));
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia_D, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
                ddlCiclo.Items.Insert(0, new ListItem("TODOS", "0"));
                CNComun.LlenaComboG("pkg_pagos_2016.Obt_Ciclos_Escolares", ref ddlCiclo_D, ref ListCiclo, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Eventos_Descuentos", ref ddlEvento, ref ListEvento, "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos.Obt_Status_Descuentos", ref ddlStatus_Ini, "p_usuario", "p_tipo_descuento", "p_todos", SesionUsu.Usu_Nombre, "X", "S", "INGRESOS");
                ddlStatus_Ini.SelectedValue = "S";
                //CNComun.LlenaCombo("PKG_GESTIONRH_V2.Obt_Combo_UR", ref ddlDependencia_Empleado, "p_usuario", SesionUsu.Usu_Nombre);
                //if(ddlDependencia_Empleado.Items.Count>0)
                //    this.ddlDependencia_Empleado.Items.Insert(0, new ListItem("-- Seleccione --", "X"));

                if (ddlEvento.SelectedValue == "NINGUNO")
                {
                    ddlCiclo_D.Enabled = true;
                    txtFechaInicial.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaDos;
                    txtFechaFinal.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaTres;
                }
                else
                {

                    ddlCiclo_D.Enabled = false;
                    txtFechaInicial.Text = ListEvento[ddlEvento.SelectedIndex].EtiquetaDos;
                    txtFechaFinal.Text = ListEvento[ddlEvento.SelectedIndex].EtiquetaTres;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true);  //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridCatConceptos()
        {
            Int32[] Celdas1 = new Int32[] { 2, 3 };
            Int32[] Celdas2 = new Int32[] { 3 };
            try
            {
                DataTable dt = new DataTable();
                grvConceptosCat.DataSource = dt;
                grvConceptosCat.DataSource = GetListConceptos();
                grvConceptosCat.DataBind();
                if (grvConceptosCat.Rows.Count >= 1)
                {
                    if (ddlSubTipo.SelectedValue == "RECARGO" || ddlSubTipo.SelectedValue == "CUOTA_NORMAL")
                        CNComun.HideColumns(grvConceptosCat, Celdas1);
                    else
                        CNComun.HideColumns(grvConceptosCat, Celdas2);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridStatus()
        {
            try
            {
                DataTable dt = new DataTable();
                grvStatus.DataSource = dt;
                grvStatus.DataSource = GetListStatus();
                grvStatus.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            Int32[] Celdas = new Int32[] {0, 1, 4, 12, 16, 17, 18, 19, 20, 21 };

            try
            {
                DataTable dt = new DataTable();
                grvAlumnos.DataSource = dt;
                grvAlumnos.DataSource = GetList();
                grvAlumnos.DataBind();
                if (grvAlumnos.Rows.Count > 0)
                    HideColumns(grvAlumnos);

             

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridEmpleados(string Busca)
        {
            try
            {
                DataTable dt = new DataTable();
                grvEmpleados.DataSource = dt;
                grvEmpleados.DataSource = GetListEmpleado(Busca);
                grvEmpleados.DataBind();
                //if (grvAlumnos.Rows.Count > 0)
                //{
                //    HideColumns(grvAlumnos);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridHijos()
        {
            Int32[] Celdas = new Int32[] { 0 };
            try
            {
                DataTable dt = new DataTable();
                grvHijos.DataSource = dt;
                grvHijos.DataSource = GetListHijos();
                grvHijos.DataBind();
                if (grvHijos.Rows.Count > 0)
                {
                    CNComun.HideColumns(grvHijos,Celdas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private List<Alumno> GetListStatus()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                CNAlumno.ConsultarStatusDescuento(ref ObjAlumno, SesionUsu.Usu_Nombre, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<DetConcepto> GetListConceptos()
        {
            try
            {
                List<DetConcepto> List = new List<DetConcepto>();
                ObjConcepto.Nivel = ddlNivel.SelectedValue;
                ObjConcepto.Dependencia = ddlDependencia_D.SelectedValue;
                ObjConcepto.Carrera = ddlCarrera.SelectedValue;
                CNDetDesc.ConsultarCatConceptoDescuento(ObjConcepto, ddlSubTipo.SelectedValue, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        private List<Alumno> GetList()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Dependencia = ddlDependencia.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCiclo.SelectedValue;
                ObjAlumno.StatusMatricula = ddlStatus_Ini.SelectedValue;
                ObjAlumno.Nivel = ddlNivel1.SelectedValue;
                CNAlumno.ConsultarAlumnoDescuento(ref ObjAlumno, ddlSubTipo1.SelectedValue, txtReferencia.Text, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Persona> GetListEmpleado(string Busca)
        {
            try
            {
                List<Persona> List = new List<Persona>();
                ObjEmpleado.Nombre = txtNombreEmp.Text;
                //ObjEmpleado.APaterno = txtApellidosEmp.Text;
                if(Busca=="S")
                    ObjEmpleado.IdPersona = 0;
                else
                    ObjEmpleado.IdPersona = Convert.ToInt32(ddlEmpleado.SelectedValue);

                CNEmpleado.ConsultarEmpleado(ref ObjEmpleado, ref List);                
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Alumno> GetListHijos()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.IdPersona = Convert.ToInt32(grvEmpleados.SelectedRow.Cells[0].Text);
                CNEmpleado.ConsultarHijos(ref ObjAlumno, ref List);                
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ObtIdOficio()
        {
            //lblMsj.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                CNOficio.ConsultarIdOficio(ref ObjOficio, ref Verificador);
                if (Verificador == "0")
                {
                    SesionUsu.Id_Oficio = ObjOficio.IdOficio;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridOficios(List<Oficio> ListOficios)
        {
            //lblMsj.Text = string.Empty;
            try
            {
                grvOficios.DataSource = ListOficios;
                grvOficios.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void CargarGridConceptos(List<DetConcepto> ListConceptos)
        {
            Int32[] Celdas = new Int32[] { 4 };
            Int32[] CeldasExento = new Int32[] { 2, 4 };
            Int32[] Celdas_Recargo_CN = new Int32[] { 2, 3, 4 };
            //lblMsj.Text = string.Empty;
            try
            {
                grvConceptos.DataSource = ListConceptos;
                grvConceptos.DataBind();
                if (grvConceptos.Rows.Count >= 1)
                {
                    if (ddlSubTipo.SelectedValue == "RECARGO" || (ddlSubTipo.SelectedValue == "CUOTA_NORMAL"))
                        CNComun.HideColumns(grvConceptos, Celdas_Recargo_CN);
                    else if (ddlSubTipo.SelectedValue == "EXENTO")
                        CNComun.HideColumns(grvConceptos, CeldasExento);
                    else
                        CNComun.HideColumns(grvConceptos, Celdas);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void Copiar_a_Oficios(List<Oficio> ListOficio)
        {
            try
            {
                for (int i = 0; i < ListOficio.Count; i++)
                {
                    string fileName = ListOficio[i].LinkArchivo.Replace("~/OficiosTemp/", "");
                    string OrigenArchivo = Path.Combine(Server.MapPath("~/OficiosTemp"), ListOficio[i].NombreArchivo); //System.IO.Path.Combine(Origen, fileName);
                    string DestinoArchivo = Path.Combine(Server.MapPath("~/Oficios"), ListOficio[i].NombreArchivo);  //System.IO.Path.Combine(Destino, fileName);
                    System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                    System.IO.File.Delete(OrigenArchivo);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void HideColumns(GridView grdView)
        {
            //usuAdmin = Array.FindAll(UsuariosSuper, s => s.Equals(SesionUsu.Usu_Nombre));
            grdView.HeaderRow.Cells[0].Visible = false;
            grdView.HeaderRow.Cells[1].Visible = false;
            grdView.HeaderRow.Cells[3].Visible = false;
            grdView.HeaderRow.Cells[10].Visible = false;
            grdView.HeaderRow.Cells[12].Visible = false;
            grdView.HeaderRow.Cells[16].Visible = false;
            grdView.HeaderRow.Cells[17].Visible = false;
            //grdView.HeaderRow.Cells[18].Visible = false;
            grdView.HeaderRow.Cells[19].Visible = false;
            grdView.HeaderRow.Cells[20].Visible = false;
            grdView.HeaderRow.Cells[21].Visible = false;
            //grdView.HeaderRow.Cells[13].Visible = (SesionUsu.Usu_Central=="S") ? true : false;
            //4, 12, 16, 17, 18, 19, 20
            grdView.FooterRow.Cells[0].Visible = false;
            grdView.FooterRow.Cells[1].Visible = false;
            grdView.FooterRow.Cells[3].Visible = false;
            grdView.FooterRow.Cells[10].Visible = false;
            grdView.FooterRow.Cells[12].Visible = false;
            grdView.FooterRow.Cells[16].Visible = false;
            grdView.FooterRow.Cells[17].Visible = false;
            //grdView.FooterRow.Cells[18].Visible = false;
            grdView.FooterRow.Cells[19].Visible = false;
            grdView.FooterRow.Cells[20].Visible = false;
            grdView.FooterRow.Cells[21].Visible = false;
            //grdView.FooterRow.Cells[13].Visible = (SesionUsu.Usu_Central == "S") ? true : false;


            foreach (GridViewRow row in grdView.Rows)
            {
                row.Cells[0].Visible = false;
                CheckBox cb = (CheckBox)row.FindControl("ckbGenerar");
                LinkButton linkBttnEditar=(LinkButton)row.FindControl("linkBttnEditar");
                linkBttnEditar.Visible = false;
                cb.Enabled = Convert.ToBoolean(row.Cells[1].Text);
                row.Cells[1].Visible = false;
                row.Cells[3].Visible = false;
                row.Cells[10].Visible = false;
                row.Cells[12].Visible = false;

                if (SesionUsu.Usu_Central == "S")                
                    linkBttnEditar.Visible = true;
                else
                {
                    if (row.Cells[8].Text.ToUpper() == "SOLICITADO")
                        linkBttnEditar.Visible = true;
                }

                //row.Cells[13].Visible = (SesionUsu.Usu_Central == "S") ? true : false; //(usuAdmin.Length != 0) ? true : false;
                row.Cells[16].Visible = false;
                row.Cells[17].Visible = false;
                //row.Cells[18].Visible = false;
                row.Cells[19].Visible = false;
                row.Cells[20].Visible = false;
                row.Cells[21].Visible = false;
            }

        }
        private void GuardarDatos()
        {
            if (grvConceptos.Rows.Count > 0)
            {
                ObjAlumno.CicloAlu = ddlCicloAlum.SelectedValue;
                ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                ObjAlumno.Nombre = txtNombre.Text.ToUpper();
                ObjAlumno.APaterno = txtPaterno.Text.ToUpper();
                ObjAlumno.AMaterno = txtMaterno.Text.ToUpper();
                ObjAlumno.Semestre = txtSemestre.Text;
                ObjAlumno.Grupo = txtGrupo.Text;
                ObjAlumno.DescCarrera = txtCarrera.Text.ToUpper();
                ObjAlumno.Carrera = ddlCarrera.SelectedValue;
                ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                ObjAlumno.Dependencia = ddlDependencia_D.SelectedValue;
                ObjAlumno.CicloEscolar = ddlCiclo_D.SelectedValue;
                ObjAlumno.Evento = ddlEvento.SelectedValue;
                ObjAlumno.TipoDescuento = ddlTipo.SelectedValue;
                if (lblEstatusA.Text == "Autorizado")
                    ObjAlumno.StatusMatricula = "A";
                else
                    ObjAlumno.StatusMatricula = ddlStatus.SelectedValue;
                ObjAlumno.ConceptoDescuento = grvConceptos.Rows[0].Cells[0].Text; //ddlConcepto.SelectedValue;                
                if (ddlSubTipo.SelectedValue == "DESCUENTO" || ddlSubTipo.SelectedValue == "RECARGO")
                    ObjAlumno.PorcentajeDescuento = txtPorcentaje.Text;
                else
                    ObjAlumno.PorcentajeDescuento = "100";

                try
                {

                    ObjAlumno.FechaInicial = txtFechaInicial.Text;
                ObjAlumno.FechaFinal = txtFechaFinal.Text;
                ObjAlumno.OficioSolicito = txtOficio.Text.ToUpper();
                ObjAlumno.OficioFecha = txtFechaO.Text;
                ObjAlumno.OficioFirma = txtAutorizado.Text.ToUpper();
                ObjAlumno.OficioQuienSolicita = txtSolicitado.Text.ToUpper();
                ObjAlumno.Observaciones = txtObservaciones.Text;
                ObjAlumno.IdPersona = SesionUsu.Id_Persona;
                ObjAlumno.Genero =Convert.ToChar(rdoBttnLstGenero.SelectedValue);
                ObjAlumno.FechaNacimiento = txtFechaNacimiento.Text;

                if (ddlEmpleado.SelectedValue!="0" && (ddlTipo.SelectedItem.Text.Contains("STAUNACH") || ddlTipo.SelectedItem.Text.Contains("SPAUNACH") || ddlTipo.SelectedItem.Text.Contains("Confianza")))
                {
                    ObjAlumno.NombreEmpleado = ddlEmpleado.SelectedItem.Text;
                    ObjAlumno.IdFamiliar =Convert.ToInt32(ddlHijo.SelectedValue);
                    ObjAlumno.Adscripcion = grvEmpleados.SelectedRow.Cells[2].Text;
                    ObjAlumno.TipoPersonaStr = grvEmpleados.SelectedRow.Cells[1].Text;
                    ObjAlumno.NoControl = grvEmpleados.SelectedRow.Cells[4].Text;
                    ddlParentesco.SelectedValue = ddlHijo.SelectedValue;
                    ObjAlumno.Parentesco = ddlParentesco.SelectedItem.Text; // ListBeneficiario[ddlHijo.SelectedIndex].EtiquetaDos;
                    

                    ObjAlumno.IdEmpleado = Convert.ToInt32(grvEmpleados.SelectedRow.Cells[0].Text);
                }
                else
                {
                    ObjAlumno.NombreEmpleado = string.Empty;
                    ObjAlumno.IdFamiliar = 0;
                    ObjAlumno.Adscripcion = string.Empty;
                    ObjAlumno.TipoPersonaStr = string.Empty;
                    ObjAlumno.NoControl = "0";
                    ObjAlumno.Parentesco = string.Empty;
                    ObjAlumno.IdEmpleado = 0;                                        
                }

                    //lblMsjGuardar.Text = string.Empty;
                    //lblMsj.Text = string.Empty;
                    Verificador = string.Empty;
                    VerificadorConceptos = string.Empty;
                    VerificadorOficios = string.Empty;
                    if (SesionUsu.Editar == 0)
                    {
                        if (Session["Oficios"] == null)                        
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Favor de adjuntar oficio.');", true);

                        else
                        {
                            CNAlumno.AlumnoInsertarDescuento(ref ObjAlumno, ref Verificador);
                            if (Verificador == "0")
                            {
                                ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                                CNDetDesc.InsertarDetDescuento(ListDetConcepto, ObjAlumno, ref VerificadorConceptos);
                                if (VerificadorConceptos == "0")
                                {
                                    if (Session["Oficios"] != null)
                                    {
                                        ListOficio = (List<Oficio>)Session["Oficios"];
                                        if (ListOficio.Count() >= 1)
                                            CNOficio.OficioInsertar(ListOficio, ObjAlumno, ref VerificadorOficios);
                                        else
                                            VerificadorOficios = "0";
                                    }
                                    else
                                        VerificadorOficios = "0";
                                }
                            }
                        }
                    }
                    else
                    {
                        CNAlumno.AlumnoEditarDescuento(ref ObjAlumno, ref Verificador);
                        if (Verificador == "0")
                        {
                            ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                            CNDetDesc.EditarDetDescuento(ListDetConcepto, ObjAlumno, ref VerificadorConceptos);
                            if (VerificadorConceptos == "0")
                            {
                                if (Session["Oficios"] != null)
                                {
                                    ListOficio = (List<Oficio>)Session["Oficios"];
                                    if (ListOficio.Count() >= 1)
                                        CNOficio.OficioEditar(ListOficio, ObjAlumno, ref VerificadorOficios);
                                    else
                                        CNOficio.OficioEliminar(ObjAlumno, ref VerificadorOficios);
                                }
                                else
                                    VerificadorOficios = "0";
                            }
                        }
                    }


                    if (Verificador == "0" && VerificadorOficios == "0" && VerificadorConceptos == "0")
                    {
                        if(SesionUsu.Editar == 0 && ddlStatus.SelectedValue=="A" && ddlSubTipo.SelectedValue=="EXENTO")
                            CNAlumno.GeneraReciboDescuento(ref ObjAlumno, ref Verificador);
                        else if (SesionUsu.Editar == 1 && ddlStatus.SelectedValue == "A" && ddlSubTipo.SelectedValue == "EXENTO" && (grvAlumnos.SelectedRow.Cells[9].Text==string.Empty || grvAlumnos.SelectedRow.Cells[9].Text == "&nbsp;"))
                            CNAlumno.GeneraReciboDescuento(ref ObjAlumno, ref Verificador);

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Los datos se guardaron correctamente.');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                        Copiar_a_Oficios(ListOficio);
                        Nuevo();
                        CargarGrid();
                        MultiView1.ActiveViewIndex = 0;
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ "Posible registro duplicado.. Error(" + Verificador + ")" + " " + VerificadorOficios + "');", true);  //lblMsj.Text = "Posible registro duplicado.. Error(" + Verificador + ")" + " " + VerificadorOficios;

                }


                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ ex.Message + "');", true);//lblMsj.Text = "Los datos se guardaron correctamente.";
                    //lblMsj.Text = ex.Message;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, 'Se debe agregar por lo menos un concepto.');", true); //lblMsj.Text = "Se debe agregar por lo menos un concepto.";
            }
        }
        private void Nuevo()
        {

            lblMsjGuardar.Text = string.Empty;
            //lblMsj.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            ddlCicloAlum.Items.Clear();
            txtSemestre.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            rdoBttnLstGenero.ClearSelection();
            txtPorcentaje.Text = "100";
            txtOficio.Text = string.Empty;
            txtFechaO.Text = string.Empty;
            txtAutorizado.Text = string.Empty;
            txtSolicitado.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            lblUsuSolicitado.Text = string.Empty;
            lblFechaSolicitado.Text = string.Empty;
            lblUsuAutorizado.Text = string.Empty;
            lblFechaAutorizado.Text = string.Empty;
            lblUsuGenerar.Text = string.Empty;
            lblFechaGenerar.Text = string.Empty;
            lblErrorBuscEmp.Text = string.Empty;
            lblErrorBuscEmp.Visible = false;
            //lblMsj.Text = string.Empty;
            if (ddlCiclo.SelectedValue != "0")
                ddlCiclo_D.SelectedValue = ddlCiclo.SelectedValue;

            ddlStatus.Visible = true;
            lblEstatusA.Text = string.Empty;
            ddlStatus.SelectedValue = "S";
            ddlEvento.SelectedValue = "NINGUNO";



            Session["Conceptos"] = null;
            grvConceptos.DataSource = null;
            grvConceptos.DataBind();
            grvConceptos.Enabled = true;

            //grvConceptosCat.DataSource = null;
            //grvConceptosCat.DataBind();
            
            ddlSubTipo.SelectedIndex = 0;
            ddlSubTipo_SelectedIndexChanged(null, null);
            grvConceptosCat.Enabled = true;
            //LinkNombreArchivo.NavigateUrl = string.Empty;
            //LinkNombreArchivo.Text = string.Empty;
            if (ddlEvento.SelectedValue == "NINGUNO")
            {
                ddlCiclo_D.Enabled = true;
                txtFechaInicial.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaDos;
                txtFechaFinal.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaTres;
            }
            else
            {

                ddlCiclo_D.Enabled = false;
                txtFechaInicial.Text = ListEvento[ddlEvento.SelectedIndex].EtiquetaDos;
                txtFechaFinal.Text = ListEvento[ddlEvento.SelectedIndex].EtiquetaTres;
            }


            SesionUsu.Id_Persona = 0;



            txtSemestre.Enabled = true;
            txtGrupo.Enabled = true;
            txtMatricula.Enabled = true;
            ddlNivel.Enabled = true;
            ddlStatus.Enabled = true;
            ddlCiclo_D.Enabled = true;
            ddlEvento.Enabled = true;
            ddlSubTipo.Enabled = true;
            ddlTipo.Enabled = true;
            grvConceptosCat.Enabled = true;
            txtPorcentaje.Enabled = true;
            txtFechaInicial.Enabled = true;
            txtFechaFinal.Enabled = true;
            txtOficio.Enabled = true;
            txtFechaO.Enabled = true;
            txtAutorizado.Enabled = true;
            txtSolicitado.Enabled = true;
            txtObservaciones.Enabled = true;
            ddlDependencia_D.SelectedIndex = 0;
            ddlDependencia_D_SelectedIndexChanged(null, null);
            Session["Oficios"] = null;
            grvOficios.DataSource = null;
            grvOficios.DataBind();
            //ddlNivel.Items.Clear();
            ddlEmpleado.Items.Clear();
            ddlEmpleado.Items.Insert(0, new ListItem("AGREGAR-->", "0"));
            grvEmpleados.DataSource = null;
            grvEmpleados.DataBind();
            TabContainer1.ActiveTabIndex = 0;
            TabContainer1.Tabs[1].Enabled = false;
            TabContainer1.Tabs[2].Enabled = false;
            lblAlumno.Text = string.Empty;
        }
        private void Inicializar()
        {
            //lblMsj.Text = string.Empty;
            try
            {
                MultiView1.ActiveViewIndex = 0;
                SesionUsu.Row = -1;                
                Cargarcombos();
                CargarGridStatus();
                txtReferencia.Focus();

                if (SesionUsu.Exento.ToString() != null && SesionUsu.Exento == 'S')
                {
                    MultiView1.ActiveViewIndex = 1;
                    txtMatricula.Text = SesionUsu.Matricula;
                    linkBttnBuscar_Click(null, null);
                    ddlNivel.SelectedValue = SesionUsu.NivelEstudio;
                    ddlNivel_SelectedIndexChanged(null, null);
                    SesionUsu.Exento = 'N';
                }
                else
                    CargarGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }
        private void GenerarRecibo()
        {
            ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);
            ObjAlumno.Dependencia = grvAlumnos.SelectedRow.Cells[2].Text;
            ObjAlumno.ConceptoDescuento = grvAlumnos.SelectedRow.Cells[3].Text;
            ObjAlumno.Matricula = grvAlumnos.SelectedRow.Cells[4].Text;
            ObjAlumno.Nivel = grvAlumnos.SelectedRow.Cells[16].Text;
            ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
            CNAlumno.GeneraReciboDescuento(ref ObjAlumno, ref Verificador);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPopoverDetalle();", true);

            if (!IsPostBack)          
                Inicializar();

            ScriptManager.RegisterStartupScript(this, GetType(), "Eventos", "FiltEventos();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "grdExentos", "Exentos();", true);
            if (SesionUsu.Usu_Central == "S")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "grdExentos", "ExentosA();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "grdMonitor", "Monitor();", true);
            }

        }

        protected void imgBttnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                TabContainer1.ActiveTabIndex = 0;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 0;
                Nuevo();
                ObtIdOficio();
                txtMatricula.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Registrar.Visible = false;
            try
            {
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivel, "p_matricula", "p_sistema", txtMatricula.Text.ToUpper(), "SIST_ING", "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Ciclo_Alum", ref ddlCicloAlum, "p_matricula", txtMatricula.Text.ToUpper(), "INGRESOS");
                if (ddlNivel.Items.Count == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Dato no encontrado, si deseas registralo dar click por única vez.');", true); //lblMsj.Text = "Dato no encontrado, si deseas registralo dar click por única vez.";
                    Registrar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void ddlDependencia_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDependencia_D.SelectedValue == "61401" || ddlDependencia_D.SelectedValue == "61501" || ddlDependencia_D.SelectedValue == "61301")
                    ddlDependencia_D.Enabled = true;
                else
                    ddlDependencia_D.Enabled = false;

                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "p_nivel", "p_dependencia", ddlNivel.SelectedValue, ddlDependencia_D.SelectedValue, "INGRESOS");
                if (ddlCarrera.Items.Count == 0)
                {
                    ddlCarrera.DataSource = null;
                    ddlCarrera.DataBind();
                }
                ddlCarrera_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCarrera.SelectedValue == "000000")
            {
                lblOtraCarrera.Visible = true;
                txtCarrera.Visible = true;
                txtCarrera.Text = string.Empty;
            }
            else
            {
                lblOtraCarrera.Visible = false;
                txtCarrera.Visible = false;
                txtCarrera.Text = ddlCarrera.SelectedItem.Text;
            }

        }
      
        protected void Registrar_Click(object sender, EventArgs e)
        {
            SesionUsu.Exento = 'S';
            SesionUsu.NivelEstudio = ddlNivel.SelectedValue;
            SesionUsu.Dependencia = ddlDependencia_D.SelectedValue;
            SesionUsu.Matricula = txtMatricula.Text;
            Response.Redirect("FrmAlumnos_Clientes.aspx");

        }

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaMatricula();
            EmpleadoMatricula();
            if (SesionUsu.Editar == 0)
            {
                ddlSubTipo.SelectedValue = "X";
                if (ddlCiclo_D.Items.Count >= 1)
                {
                    if (ddlNivel.SelectedValue == "M" || ddlNivel.SelectedValue == "D" || ddlNivel.SelectedValue == "E")
                    {
                        ddlCiclo_D.SelectedValue = "20";
                        ddlCiclo_D_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEmpleado.Visible = false;
            ddlEmpleado.Visible = false;
            linkBttnEmpleado.Visible = false;
            linkBttnBorrarEmpleado.Visible = false;
            try
            {
                if (ddlTipo.SelectedValue != "La opción no contiene datos")
                {
                    if (ddlTipo.SelectedItem.Text.Contains("STAUNACH") || ddlTipo.SelectedItem.Text.Contains("SPAUNACH") || ddlTipo.SelectedItem.Text.Contains("Confianza"))
                    {
                        lblEmpleado.Visible = true;
                        ddlEmpleado.Visible = true;
                        linkBttnEmpleado.Visible = true;
                        linkBttnBorrarEmpleado.Visible = true;
                    }
                    //else if (ddlTipo.SelectedItem.Text.Contains("SPAUNACH"))
                    //    rdoBttnTipoPersonal.SelectedValue = "D";
                    //else if (ddlTipo.SelectedItem.Text.Contains("Confianza"))
                    //    rdoBttnTipoPersonal.SelectedValue = "C";

                    CargarGridCatConceptos();
                    CNComun.LlenaCombo("pkg_pagos.Obt_Status_Descuentos", ref ddlStatus, "p_usuario", "p_tipo_descuento", "p_todos", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue, "N", "INGRESOS");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }
        protected void ddlCiclo_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFechaInicial.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaDos;
            txtFechaFinal.Text = ListCiclo[ddlCiclo_D.SelectedIndex].EtiquetaTres;
        }

        protected void grvConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //lblMsj.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
                int pagina = grvConceptos.PageSize * grvConceptos.PageIndex;
                fila = pagina + fila;
                List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                ListDetConcepto.RemoveAt(fila);
                Session["Conceptos"] = ListDetConcepto;
                CargarGridConceptos(ListDetConcepto);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }

        }

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            CargarGrid();
        }

        protected void grvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlumnos.PageIndex = 0;
            grvAlumnos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void grvAlumnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SesionUsu.Row = e.RowIndex;
        }

        protected void grvStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStatus.PageIndex = 0;
            grvStatus.PageIndex = e.NewPageIndex;
            CargarGridStatus();
        }

        protected void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            //imgBttnBuscar.Focus();
        }

        protected void imgBttnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            txtObservaciones_C.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                ImageButton cbi = (ImageButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                ddlStatusRegistro.SelectedIndex = 0;
                modalCancelar.Show();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }

        protected void ckbGenerar_CheckedChanged(object sender, EventArgs e)
        {
            MPPAlert.Hide();
            bool cb = Convert.ToBoolean(DataBinder.Eval(sender, "Checked"));
            CheckBox cbi = (CheckBox)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvAlumnos.SelectedIndex = row.RowIndex;

            if (cb)
            {
                SesionUsu.Id_Persona = Convert.ToInt32(DataBinder.Eval(sender, "ValidationGroup").ToString());
                MPPAlert.Show();
            }
            //else
            //    lblMsj.Text = string.Empty;

        }

        protected void imgBttnCorreo_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ImageButton cbi = (ImageButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grvAlumnos.SelectedRow.Cells[4].Text;
                ObjFactura.FACT_REFERENCIA = grvAlumnos.SelectedRow.Cells[9].Text;
                CNFactura.FacturaConsultaId(ref ObjFactura, ref Verificador);
                if (Verificador == "0")
                {
                    PnlCorreo.Recibo = ObjFactura.ID_FACT;
                    PnlCorreo.Muestra();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 30) + "');", true); //lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void grvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {

            TabContainer1.ActiveTabIndex = 0;
            MultiView1.ActiveViewIndex = 1;

            lblMsjGuardar.Text = string.Empty;
            Celdas = new Int32[] { 3 };
            ListFamiliar.Clear();
            string StatusMatricula;
            lblErrorBuscEmp.Text = string.Empty;
            lblErrorBuscEmp.Visible = false;
            //try
            //{
            //    ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);  //Convert.ToInt32(grvAlumnos.Rows[v].Cells[0].Text);
            //    SesionUsu.Id_Persona = ObjAlumno.IdPersona;
            //    ObjAlumno.CicloAlu= Convert.ToString(grvAlumnos.SelectedRow.Cells[21].Text);
            //    CNAlumno.ConsultarAlumnoDescuento(ref ObjAlumno, ref Verificador);
            //    if (Verificador == "0")
            //    {
            //        SesionUsu.Editar = 1;
            //        txtMatricula.Text = ObjAlumno.Matricula;
            //        linkBttnBuscar_Click(null, null);
            //        try
            //        {
            //            ddlCicloAlum.SelectedValue = ObjAlumno.CicloAlu;
            //        }
            //        catch
            //        {
            //            ddlCicloAlum.SelectedIndex = 0;
            //        }
            //        ddlNivel.SelectedValue = ObjAlumno.Nivel;
            //        ddlEvento.SelectedValue = ObjAlumno.Evento;
            //        BuscaDatosAlumno();
            //        ////ddlNivel_SelectedIndexChanged(null, null);
            //        //ddlCarrera.SelectedValue = ObjAlumno.Carrera;
            //        //if (ddlCarrera.SelectedValue == "000000")
            //        //{
            //        //    ddlCarrera_SelectedIndexChanged(null, null);
            //        //    txtCarrera.Text = ObjAlumno.DescCarrera;
            //        //}
            //        ddlCiclo_D.SelectedValue = ObjAlumno.CicloEscolar;
            //        txtSemestre.Text = ObjAlumno.Semestre;
            //        txtGrupo.Text = ObjAlumno.Grupo;

            //        txtPorcentaje.Text = ObjAlumno.PorcentajeDescuento;
            //        txtFechaInicial.Text = ObjAlumno.FechaInicial;
            //        txtFechaFinal.Text = ObjAlumno.FechaFinal;
            //        txtOficio.Text = ObjAlumno.OficioSolicito;
            //        txtFechaO.Text = ObjAlumno.OficioFecha;
            //        txtAutorizado.Text = ObjAlumno.OficioFirma;
            //        txtSolicitado.Text = ObjAlumno.OficioQuienSolicita;
            //        txtObservaciones.Text = ObjAlumno.Observaciones;
            //        lblUsuSolicitado.Text = ObjAlumno.SolicitoNombre;
            //        lblFechaSolicitado.Text = ObjAlumno.SolicitoFecha;
            //        lblUsuAutorizado.Text = ObjAlumno.AutorizoNombre;
            //        lblFechaAutorizado.Text = ObjAlumno.AutorizoFecha;
            //        lblUsuGenerar.Text = ObjAlumno.GeneroNombre;
            //        lblFechaGenerar.Text = ObjAlumno.GeneroFecha;
            //        SesionUsu.Id_Oficio = ObjAlumno.oficio.IdOficio;
            //        StatusMatricula = ObjAlumno.StatusMatricula;
            //        if (Convert.ToString(ObjAlumno.IdEmpleado) != "0")
            //        {
            //            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleado", ref ddlEmpleado, "p_id_empleado", "p_id_familiar", Convert.ToString(ObjAlumno.IdEmpleado), Convert.ToString(ObjAlumno.IdFamiliar), ref ListFamiliar);
            //            BuscaEmpleado();
            //            BuscaHijo("N");
            //        }
            //        else
            //        {
            //            ddlEmpleado.Items.Clear();
            //            ddlEmpleado.Items.Insert(0, new ListItem("AGREGAR-->", "0"));
            //            grvEmpleados.DataSource = null;
            //            grvEmpleados.DataBind();
            //            ddlHijo.Items.Clear();
            //            ddlParentesco.Items.Clear();
            //        }
            //        //TabContainer1.ActiveTabIndex = 0;
            //        //MultiView1.ActiveViewIndex = 1;
            //        if (StatusMatricula == "A")
            //        {
            //            txtNombre.Enabled = false;
            //            txtPaterno.Enabled = false;
            //            txtMaterno.Enabled = false;
            //            txtSemestre.Enabled = true;
            //            txtGrupo.Enabled = true;
            //            txtMatricula.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;  //(usuAdmin.Length != 0) ? true : false;
            //            //ddlNivel.Enabled = false;
            //            ddlStatus.Visible = false;
            //            lblEstatusA.Text = "Autorizado";
            //            //ddlCiclo_D.Enabled = false;
            //            ddlCiclo_D.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
            //            ddlEvento.Enabled = false;
            //            ddlSubTipo.Enabled = false;
            //            ddlTipo.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
            //            //grvConceptosCat.Enabled = false;
            //            grvConceptosCat.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
            //            txtPorcentaje.Enabled = false;
            //            txtFechaInicial.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;//(usuAdmin.Length != 0) ? true : false;
            //            txtFechaFinal.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //(usuAdmin.Length != 0) ? true : false;
            //            txtOficio.Enabled = true;
            //            txtFechaO.Enabled = true;
            //            txtAutorizado.Enabled = true;
            //            txtSolicitado.Enabled = true;
            //            txtObservaciones.Enabled = true;
            //        }
            //        else if (StatusMatricula == "C")
            //        {
            //            ddlStatus.Visible = false;
            //            lblEstatusA.Text = "Cancelado";
            //        }
            //        else
            //        {
            //            //ddlStatus.SelectedValue = ObjAlumno.StatusMatricula;
            //            txtNombre.Enabled = true;
            //            txtPaterno.Enabled = true;
            //            txtMaterno.Enabled = true;
            //            txtSemestre.Enabled = true;
            //            txtGrupo.Enabled = true;
            //            txtMatricula.Enabled = true;
            //            ddlNivel.Enabled = true;
            //            ddlStatus.Visible = true;
            //            lblEstatusA.Text = string.Empty;
            //            ddlCiclo_D.Enabled = true;
            //            ddlEvento.Enabled = true;
            //            ddlSubTipo.Enabled = true;
            //            ddlTipo.Enabled = true;
            //            grvConceptosCat.Enabled = true;
            //            txtPorcentaje.Enabled = true;
            //            txtFechaInicial.Enabled = true;
            //            txtFechaFinal.Enabled = true;
            //            txtOficio.Enabled = true;
            //            txtFechaO.Enabled = true;
            //            txtAutorizado.Enabled = true;
            //            txtSolicitado.Enabled = true;
            //            txtObservaciones.Enabled = true;
            //        }


            //        //--LIMPIA GRIDS--//
            //        Session["Oficios"] = null;
            //        Session["Conceptos"] = null;
            //        grvOficios.DataSource = null;
            //        grvOficios.DataBind();
            //        grvConceptosCat.DataSource = null;
            //        grvConceptosCat.DataBind();
            //        grvConceptos.DataSource = null;
            //        grvConceptos.DataBind();
            //        //--FIN LIMPIA GRIDS--//


            //        ddlSubTipo.SelectedValue = ObjAlumno.SubTipoDescuento;
            //        ddlSubTipo_SelectedIndexChanged(null, null);
            //        ddlTipo.SelectedValue = ObjAlumno.TipoDescuento;
            //        ddlTipo_SelectedIndexChanged(null, null);
            //        if (StatusMatricula == "A")
            //            grvConceptosCat.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //false;

            //        CNComun.LlenaCombo("pkg_pagos.Obt_Status_Descuentos", ref ddlStatus, "p_usuario", "p_tipo_descuento", "p_todos", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue, "N", "INGRESOS");
            //        if (ObjAlumno.StatusMatricula != "A")
            //            ddlStatus.SelectedValue = ObjAlumno.StatusMatricula;

            //        if (SesionUsu.Id_Oficio == 0)
            //            ObtIdOficio();

            //        //----CARGA GRID DE OFICIOS Y DE LOS CONCEPTOS AGREGADOS
            //        ObjOficio.IdDescuento = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);
            //        List<Oficio> ListOficio = new List<Oficio>();
            //        CNOficio.OficioConsultaGrid(ref ObjOficio, ref ListOficio);
            //        if (ListOficio.Count > 0)
            //        {
            //            Session["Oficios"] = ListOficio;
            //            CargarGridOficios(ListOficio);
            //            Copiar_a_OficiosTemp(ListOficio);
            //        }

            //        List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
            //        CNDetDesc.ConsultarDetDescuento(ObjConcepto, SesionUsu.Id_Persona, ref ListDetConcepto);
            //        if (ListDetConcepto.Count > 0)
            //        {
            //            Session["Conceptos"] = ListDetConcepto;
            //            CargarGridConceptos(ListDetConcepto);
            //            if (StatusMatricula == "A")
            //                grvConceptos.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //false;
            //        }


            //    }
            //    else
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = Verificador;
            //}
            //catch (Exception ex)
            //{
            //    string Mensaje = ex.Message.Replace("\r", "");
            //    Mensaje = Mensaje.Replace("\n", "");
            //    Mensaje = Mensaje.Replace("'", "");
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje.Substring(0,45) + "');", true); //lblMsj.Text = ex.Message;
            //}


        }

        protected void bttnAgregaOficio_Click(object sender, EventArgs e)
        {
            //lblMsj.Text = string.Empty;
            try
            {
                string fullPath;
                int fileSize;
                string NombreArchivo;

                if (FileOficio.HasFile)
                {
                    fileSize = FileOficio.PostedFile.ContentLength;
                    NombreArchivo = FileOficio.FileName.ToUpper();
                    NombreArchivo = NombreArchivo.Replace(" ", "_");
                    NombreArchivo = NombreArchivo.Replace("%", string.Empty);

                    if (NombreArchivo.Contains(".JPEG"))
                        NombreArchivo = SesionUsu.Id_Oficio + NombreArchivo;
                    else if (NombreArchivo.Contains(".JPG"))
                        NombreArchivo = SesionUsu.Id_Oficio + NombreArchivo;
                    else if (NombreArchivo.Contains(".GIF"))
                        NombreArchivo = SesionUsu.Id_Oficio + NombreArchivo;
                    else if (NombreArchivo.Contains(".PNG"))
                        NombreArchivo = SesionUsu.Id_Oficio + NombreArchivo;
                    else if (NombreArchivo.Contains(".PDF"))
                        NombreArchivo = SesionUsu.Id_Oficio + NombreArchivo;

                    fullPath = Path.Combine(Server.MapPath("~/OficiosTemp"), NombreArchivo);
                    FileOficio.SaveAs(fullPath);

                    if (NombreArchivo.Contains(".JPEG") || NombreArchivo.Contains(".JPG") || NombreArchivo.Contains(".PNG") || NombreArchivo.Contains(".GIF") || NombreArchivo.Contains(".PDF"))
                    {
                        //if (NombreArchivo.Contains(".JPEG") || NombreArchivo.Contains(".JPG") || NombreArchivo.Contains(".PNG") || NombreArchivo.Contains(".GIF"))
                        //{
                        //    if (fileSize > 524288)
                        //    {
                        //        System.Drawing.Image ImageDraw = System.Drawing.Image.FromFile(fullPath);
                        //        ImageDraw = this.Redimensionar(ImageDraw, 30, 30);
                        //        fullPath = "~/OficiosTemp/" + NombreArchivo;
                        //        ImageDraw.Save(fullPath);
                        //        ImageDraw.Dispose();
                        //    }
                        //}
                        ObjOficio.NombreArchivo = NombreArchivo;
                        ObjOficio.LinkArchivo = "~/OficiosTemp/" + NombreArchivo;
                        ObjOficio.RutaArchivo = fullPath;
                        ObjOficio.NumOficio =Convert.ToString(SesionUsu.Id_Oficio);
                        if (Session["Oficios"] == null)
                        {
                            ListOficio = new List<Oficio>();
                            ListOficio.Add(ObjOficio);
                        }
                        else
                        {
                            ListOficio = (List<Oficio>)Session["Oficios"];
                            ListOficio.Add(ObjOficio);
                        }

                        Session["Oficios"] = ListOficio;
                        CargarGridOficios(ListOficio);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Solo se permiten formatos: PDF, JPG, GIF y PNG');", true); //lblMsj.Text = "Solo se permiten formatos: PDF, JPG, GIF y PNG";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void grvOficios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //lblMsj.Text = string.Empty;
            try
            {
                int fila = e.RowIndex;
                int pagina = grvOficios.PageSize * grvOficios.PageIndex;
                fila = pagina + fila;
                List<Oficio> ListOficio = new List<Oficio>();
                ListOficio = (List<Oficio>)Session["Oficios"];
                ListOficio.RemoveAt(fila);
                Session["Oficios"] = ListOficio;
                CargarGridOficios(ListOficio);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }


        }

        protected void CancelAlert_Click(object sender, EventArgs e)
        {
            MPPAlert.Hide();
            foreach (GridViewRow row in grvAlumnos.Rows)
            {

                if (Convert.ToInt32(row.Cells[0].Text) == SesionUsu.Id_Persona)
                {
                    CheckBox cb = (CheckBox)row.FindControl("ckbGenerar");
                    cb.Checked = false;
                    break;
                }
            }

        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            MPPAlert.Hide();
            try
            {
                ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);
                ObjAlumno.Dependencia = grvAlumnos.SelectedRow.Cells[2].Text;
                ObjAlumno.ConceptoDescuento = grvAlumnos.SelectedRow.Cells[3].Text;
                ObjAlumno.Matricula = grvAlumnos.SelectedRow.Cells[4].Text;
                ObjAlumno.Nivel = grvAlumnos.SelectedRow.Cells[16].Text;
                ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
                CNAlumno.GeneraReciboDescuento(ref ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    CargarGrid();
                else
                {
                    string Msj=Verificador;
                    CNComun.VerificaTextoMensajeError(ref Msj);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = Verificador;
                }

            }
            catch (Exception ex)
            {
                string Msj=ex.Message;
                CNComun.VerificaTextoMensajeError(ref Msj);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Msj + "');", true); //lblMsj.Text = ex.Message;
            }

        }

        protected void btnGuardar_C_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);
                ObjAlumno.UsuNombre = SesionUsu.Usu_Nombre;
                ObjAlumno.Observaciones = txtObservaciones_C.Text;
                ObjAlumno.StatusMatricula = ddlStatusRegistro.SelectedValue;
                CNAlumno.ActualizarStatusDescuento(ObjAlumno, ref Verificador);
                if (Verificador == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Se ha modificado el status correctamente');", true); //lblMsj.Text = "Se ha cancelado el descuento correctamente";
                    SesionUsu.Row = -1;
                    CargarGrid();
                    modalCancelar.Hide();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '"+ Verificador + "');", true); //lblMsj.Text = Verificador;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void btnCancelar_C_Click(object sender, EventArgs e)
        {
            modalCancelar.Hide();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Nuevo();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void grvConceptosCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsjGuardar.Text = string.Empty;
            //lblMsj.Text = string.Empty;
            string TextImporte = string.Empty;
            bool InsertaDato = true;            
            var ExisteConcepto = Array.FindAll(ConceptosPosgrado, s => s.Equals(grvConceptosCat.SelectedRow.Cells[0].Text));
            try
            {

                TextBox myTextBox = (TextBox)(grvConceptosCat.SelectedRow.Cells[2].FindControl("txtImporte"));
                TextImporte = myTextBox.Text;
                ObjConcepto.ImporteDetalle =Convert.ToDouble(grvConceptosCat.SelectedRow.Cells[3].Text);
                if ((ddlNivel.SelectedValue=="L" || ddlNivel.SelectedValue=="N") && (ddlSubTipo.SelectedValue == "EXENTO" || ddlSubTipo.SelectedValue == "DESCUENTO") && ObjConcepto.ImporteDetalle == 0 && (TextImporte == "0" || TextImporte == string.Empty) && grvConceptosCat.SelectedRow.Cells[0].Text != "L0203" && grvConceptosCat.SelectedRow.Cells[0].Text != "L0201")
                {
                    lblMsjGuardar.Text = "Debes definir el importe.";
                    myTextBox.Focus();
                }
                else if ((ddlNivel.SelectedValue == "M" || ddlNivel.SelectedValue == "E" || ddlNivel.SelectedValue == "D") && ddlSubTipo.SelectedValue == "EXENTO" && ObjConcepto.ImporteDetalle == 0 && (TextImporte == "0" || TextImporte == string.Empty))
                {
                    lblMsjGuardar.Text = "Debes definir el importe.";
                    myTextBox.Focus();
                }
                else if ((ddlNivel.SelectedValue == "M" || ddlNivel.SelectedValue == "E" || ddlNivel.SelectedValue == "D") && ddlSubTipo.SelectedValue == "DESCUENTO" && ObjConcepto.ImporteDetalle == 0 && (TextImporte == "0" || TextImporte == string.Empty) && ExisteConcepto.Length == 0)
                {
                    lblMsjGuardar.Text = "Debes definir el importe.";
                    myTextBox.Focus();
                }

                else
                {
                    //**//
                    if (ddlDependencia_D.SelectedValue != "61601" && ddlDependencia_D.SelectedValue != "61301" && ddlDependencia_D.SelectedValue != "61401" && ddlDependencia_D.SelectedValue != "61501")
                    {
                        if (ObjConcepto.ImporteDetalle == 0 && (grvConceptosCat.SelectedRow.Cells[0].Text != "L0203" && grvConceptosCat.SelectedRow.Cells[0].Text != "L0201"))
                        {
                            if (ddlSubTipo.SelectedValue == "DESCUENTO")
                            {
                                if (ExisteConcepto.Length == 0)
                                    ObjConcepto.ImporteDetalle = Convert.ToDouble(TextImporte) - ((Convert.ToDouble(TextImporte) * Convert.ToDouble(txtPorcentaje.Text)) / 100);
                                else
                                    ObjConcepto.ImporteDetalle = Convert.ToDouble(txtPorcentaje.Text) / 100;
                            }
                            else if (ddlSubTipo.SelectedValue == "RECARGO")
                                ObjConcepto.ImporteDetalle = 1;  //Convert.ToDouble(txtPorcentaje.Text) / 100;
                            else
                                ObjConcepto.ImporteDetalle = Convert.ToDouble(TextImporte);
                        }
                        else
                        {
                            ObjConcepto.ImporteDetalle = (ddlSubTipo.SelectedValue == "DESCUENTO") ? ObjConcepto.ImporteDetalle - ((ObjConcepto.ImporteDetalle * Convert.ToDouble(txtPorcentaje.Text)) / 100) : ObjConcepto.ImporteDetalle;
                        }
                    }
                    else
                    {
                        if (TextImporte == "0" && (grvConceptosCat.SelectedRow.Cells[0].Text == "L0203" || grvConceptosCat.SelectedRow.Cells[0].Text == "L0201"))
                        {
                            lblMsjGuardar.Text = "Debes definir el importe.";
                            myTextBox.Focus();
                            InsertaDato = false;
                        }
                        else
                        {
                            ObjConcepto.ImporteDetalle = (ddlSubTipo.SelectedValue == "DESCUENTO") ? Convert.ToDouble(TextImporte) - ((Convert.ToDouble(TextImporte) * Convert.ToDouble(txtPorcentaje.Text)) / 100) : Convert.ToDouble(TextImporte);
                        }
                    }

                    if (InsertaDato == true)
                    {
                        ObjConcepto.ClaveDetalle = grvConceptosCat.SelectedRow.Cells[0].Text;
                        ObjConcepto.DescripcionDetalle = grvConceptosCat.SelectedRow.Cells[1].Text;
                        ObjConcepto.TipoRegistro = ddlSubTipo.SelectedValue;
                        ObjConcepto.ImporteDetalleInicio = Convert.ToDouble(TextImporte);
                        if (Session["Conceptos"] == null)
                        {
                            ListDetConcepto = new List<DetConcepto>();
                            ListDetConcepto.Add(ObjConcepto);
                        }
                        else
                        {
                            ListDetConcepto = (List<DetConcepto>)Session["Conceptos"];
                            ListDetConcepto.Add(ObjConcepto);
                        }

                        Session["Conceptos"] = ListDetConcepto;
                        CargarGridConceptos(ListDetConcepto);
                    }

                    //**//
                }
            }
            catch (Exception ex)
            {
                lblMsjGuardar.Text = ex.Message;
            }

        }

        protected void grvConceptosCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConceptosCat.PageIndex = 0;
            grvConceptosCat.PageIndex = e.NewPageIndex;
            CargarGridCatConceptos();
        }

        protected void grvConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grvConceptos.PageIndex = 0;
            //grvConceptos.PageIndex = e.NewPageIndex;
            //CargarGridConceptos();
        }

        protected void ddlSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsjGuardar.Text = string.Empty;

            if (grvConceptos.Rows.Count >= 1 && grvConceptos.Rows[0].Cells[4].Text!=ddlSubTipo.SelectedValue)
            {
                lblMsjGuardar.Text = "Si desea añadir otro tipo de descuento debe eliminar los conceptos agregados.";
                ddlSubTipo.SelectedValue = grvConceptos.Rows[0].Cells[4].Text;
            }
            else
            {
                ddlTipo.Items.Clear();
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipos_Descuentos", ref ddlTipo, "p_nivel", "p_tipo", ddlNivel.SelectedValue, ddlSubTipo.SelectedValue, "INGRESOS");
                ddlTipo_SelectedIndexChanged(null, null);
            }

            if (ddlSubTipo.SelectedValue == "DESCUENTO")
                { lblPorcentaje.Visible = true; txtPorcentaje.Visible = true; txtPorcentaje.Focus(); }
            else
                { lblPorcentaje.Visible = false; txtPorcentaje.Visible = false; }            

        }

        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if(TabContainer1.ActiveTabIndex==2)
            {
                if (ddlNivel.SelectedValue == "Z" || ddlNivel.Items.Count == 0)
                {
                    //lblMsj.Text = "Debes elegir el Nivel";
                    TabContainer1.ActiveTabIndex = 1;
                }
            }
        }

        protected void TabContainer1_ActiveTabChanged1(object sender, EventArgs e)
        {

        }

        //protected void ddlDependencia_Empleado_SelectedIndexChanged(object sender, EventArgs e)
        //{
            

        //    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleados", ref ddlEmpleado, "p_dependencia", "p_tipo_personal", ddlDependencia_Empleado.SelectedValue, rdoBttnTipoPersonal.SelectedValue);

        //}

        //protected void rdoBttnTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleados", ref ddlEmpleado, "p_dependencia", "p_tipo_personal", ddlDependencia_Empleado.SelectedValue, rdoBttnTipoPersonal.SelectedValue);
        //}

        protected void imgBttnBuscarEmp_Click(object sender, ImageClickEventArgs e)
        {
            modalEmpleado.Show();
            CargarGridEmpleados("S");
            if (grvEmpleados.Rows.Count >= 1)
            {
                grvEmpleados.SelectedIndex = 0;
                BuscaHijo("S");
                //grvEmpleados_SelectedIndexChanged(null, null);
            }
            else
            {
                grvHijos.DataSource = null;
                grvHijos.DataBind();
            }
        }

        protected void grvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            modalEmpleado.Show();
            if (grvEmpleados.Rows.Count > 0)
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Grid_Hijos", ref ddlHijo, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Parentesco", ref ddlParentesco, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
            }
            else
            {
                ddlHijo.Items.Clear();
            }
            //BuscaHijo();
        }

        protected void bttnSalirEmp_Click(object sender, EventArgs e)
        {
            modalEmpleado.Hide();
        }

        protected void bttnAgregarEmp_Click(object sender, EventArgs e)
        {
            ListFamiliar.Clear();
            if(grvEmpleados.Rows.Count>=1 && ddlHijo.Items.Count>=1)
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleado", ref ddlEmpleado, "p_id_empleado", "p_id_familiar", grvEmpleados.SelectedRow.Cells[0].Text, ddlHijo.SelectedValue, ref ListFamiliar);

            modalEmpleado.Hide();
        }

        protected void imgBttnEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            BuscaEmpleado();
            BuscaHijo("N");
            mltViewFamiliares.ActiveViewIndex = 0;
            lblAlumno.Text = "<strong>ALUMNO: </strong>" + txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
            modalEmpleado.Show();
        }

        protected void grvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            modalEmpleado.Show();
            grvEmpleados.PageIndex = 0;
            grvEmpleados.PageIndex = e.NewPageIndex;
            CargarGridEmpleados("S");
        }

        protected void imgBttnNuevoHijo_Click(object sender, ImageClickEventArgs e)
        {
            modalEmpleado.Show();
            txtNombreFamiliar.Text = txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
            mltViewFamiliares.ActiveViewIndex = 1;
            //lblMsjFam.Text = string.Empty;

        }

        protected void bttnAgregarFam_Click(object sender, EventArgs e)
        {
            modalEmpleado.Show();
            Verificador = string.Empty;
            try
            {
                ObjFamiliar.Nombre = txtNombreFamiliar.Text;
                ObjFamiliar.TipoPersonaStr = ddlParentescoFam.SelectedValue;
                ObjFamiliar.FechaNacimiento = txtFechaNacimiento.Text;
                ObjFamiliar.Genero =Convert.ToChar(rdoBttnLstGenero.SelectedValue);
                ObjFamiliar.UsuNombre = SesionUsu.Usu_Nombre;
                ObjFamiliar.IdPersona = Convert.ToInt32(grvEmpleados.SelectedRow.Cells[0].Text);
                CNFamiliar.FamiliarInsertar(ObjFamiliar, ref Verificador);
                if (Verificador == "0")
                {
                    //lblMsjFam.Text = "Se agrego correctamente al familiar.";
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 1, 'Se agrego correctamente al familiar.' );", true);
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Grid_Hijos", ref ddlHijo, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
                    CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Parentesco", ref ddlParentesco, "p_id_empleado", grvEmpleados.SelectedRow.Cells[0].Text);
                    mltViewFamiliares.ActiveViewIndex = 0;
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ Verificador + "');", true);  //lblMsjFam.Text = Verificador;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '"+ ex.Message + "' );", true); //lblMsjFam.Text = ex.Message;
            }
        }

        protected void bttnSalirFam_Click(object sender, EventArgs e)
        {
            modalEmpleado.Show();
            mltViewFamiliares.ActiveViewIndex = 0;            
        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REPA03&Ciclo=" + ddlCiclo.SelectedValue + "&CDet=" + ddlDependencia.SelectedValue + "&status=" + ddlStatus_Ini.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REPA04&Ciclo=" + ddlCiclo.SelectedValue + "&CDet=" + ddlDependencia.SelectedValue + "&status=" + ddlStatus_Ini.SelectedValue;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void bttnNuevoHijo_Click(object sender, EventArgs e)
        {
            modalEmpleado.Show();
            txtNombreFamiliar.Text = txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
            mltViewFamiliares.ActiveViewIndex = 1;
        }

        protected void imgBttnBorrarEmpleado_Click(object sender, ImageClickEventArgs e)
        {
            //ddlEmpleado.SelectedValue = "0";
            ddlEmpleado.Items.Clear();
            ddlEmpleado.Items.Insert(0, new ListItem("AGREGAR-->", "0"));
            grvEmpleados.DataSource = null;
            grvEmpleados.DataBind();
            ddlHijo.Items.Clear();
            ddlParentesco.Items.Clear();
        }

        protected void bttnNuevoHijo_Click(object sender, ImageClickEventArgs e)
        {
            modalEmpleado.Show();
            txtNombreFamiliar.Text = txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
            mltViewFamiliares.ActiveViewIndex = 1;

        }

        protected void imgBttnRecibo_Click(object sender, ImageClickEventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ImageButton cbi = (ImageButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                ObjFactura.FACT_REFERENCIA = grvAlumnos.SelectedRow.Cells[9].Text;
                CNFactura.FacturaConsultaId(ref ObjFactura, ref Verificador);
                if (Verificador == "0")
                {
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + Convert.ToInt32(ObjFactura.ID_FACT);
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(" + ObjFactura.ID_FACT + ");", true);
                }

                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 30) + "');", true); //lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void imgBttnReporteDesc_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton cbi = (ImageButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            grvAlumnos.SelectedIndex = row.RowIndex;
            string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP062&idFact=" + grvAlumnos.SelectedRow.Cells[0].Text;
            string _open = "window.open('" + ruta + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void linkBttnEmpleado_Click(object sender, EventArgs e)
        {
            BuscaEmpleado();
            BuscaHijo("N");
            mltViewFamiliares.ActiveViewIndex = 0;
            lblAlumno.Text = "<strong>ALUMNO: </strong>" + txtNombre.Text + " " + txtPaterno.Text + " " + txtMaterno.Text;
            modalEmpleado.Show();
        }

        protected void linkBttnBorrarEmpleado_Click(object sender, EventArgs e)
        {
            ddlEmpleado.Items.Clear();
            ddlEmpleado.Items.Insert(0, new ListItem("AGREGAR-->", "0"));
            grvEmpleados.DataSource = null;
            grvEmpleados.DataBind();
            ddlHijo.Items.Clear();
            ddlParentesco.Items.Clear();
        }

        protected void linkBttnCancelar_Click(object sender, EventArgs e)
        {
            txtObservaciones_C.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                ddlStatusRegistro.SelectedIndex = 0;
                modalCancelar.Show();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
                //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnCorreo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                PnlCorreo.Matricula = grvAlumnos.SelectedRow.Cells[4].Text;
                ObjFactura.FACT_REFERENCIA = grvAlumnos.SelectedRow.Cells[9].Text;
                CNFactura.FacturaConsultaId(ref ObjFactura, ref Verificador);
                if (Verificador == "0")
                {
                    PnlCorreo.Recibo = ObjFactura.ID_FACT;
                    PnlCorreo.Muestra();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 30) + "');", true); //lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnRecibo_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                ObjFactura.FACT_REFERENCIA = grvAlumnos.SelectedRow.Cells[9].Text;
                CNFactura.FacturaConsultaId(ref ObjFactura, ref Verificador);
                if (Verificador == "0")
                {
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?idFact=" + Convert.ToInt32(ObjFactura.ID_FACT);
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(" + ObjFactura.ID_FACT + ");", true);
                }

                else
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador.Substring(0, 30) + "');", true); //lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 30) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBuscarDatos_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                BuscaDatosAlumno();
            }
            catch (Exception ex)
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void ddlCicloAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlNivel.SelectedIndex = 0;
            //ddlDependencia_D.Items.Clear();
            ddlCarrera.SelectedIndex = 0;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtSemestre.Text = string.Empty;
            txtGrupo.Text = string.Empty;
        }

        protected void ddlNivel_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                BuscaDatosAlumno();
            }
            catch (Exception ex)
            {
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {
            Registrar.Visible = false;
            try
            {
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivel, "p_matricula", "p_sistema", txtMatricula.Text.ToUpper(), "SIST_ING", "INGRESOS");
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Ciclo_Alum", ref ddlCicloAlum, "p_matricula", txtMatricula.Text.ToUpper(), "INGRESOS");
                if (ddlNivel.Items.Count == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Dato no encontrado, si deseas registralo dar click por única vez.');", true); //lblMsj.Text = "Dato no encontrado, si deseas registralo dar click por única vez.";
                    Registrar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnEditar_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                LinkButton cbi = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)cbi.NamingContainer;
                grvAlumnos.SelectedIndex = row.RowIndex;
                TabContainer1.ActiveTabIndex = 0;
                MultiView1.ActiveViewIndex = 1;

                lblMsjGuardar.Text = string.Empty;
                Celdas = new Int32[] { 3 };
                ListFamiliar.Clear();
                string StatusMatricula;
                lblErrorBuscEmp.Text = string.Empty;
                lblErrorBuscEmp.Visible = false;
                try
                {
                    ObjAlumno.IdPersona = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);  //Convert.ToInt32(grvAlumnos.Rows[v].Cells[0].Text);
                    SesionUsu.Id_Persona = ObjAlumno.IdPersona;
                    ObjAlumno.CicloAlu = Convert.ToString(grvAlumnos.SelectedRow.Cells[21].Text);
                    CNAlumno.ConsultarAlumnoDescuento(ref ObjAlumno, ref Verificador);
                    if (Verificador == "0")
                    {
                        SesionUsu.Editar = 1;
                        txtMatricula.Text = ObjAlumno.Matricula;
                        linkBttnBuscar_Click(null, null);
                        try
                        {
                            ddlCicloAlum.SelectedValue = ObjAlumno.CicloAlu;
                        }
                        catch
                        {
                            ddlCicloAlum.SelectedIndex = 0;
                        }
                        ddlNivel.SelectedValue = ObjAlumno.Nivel;
                        ddlEvento.SelectedValue = ObjAlumno.Evento;
                        BuscaDatosAlumno();
                        ////ddlNivel_SelectedIndexChanged(null, null);
                        //ddlCarrera.SelectedValue = ObjAlumno.Carrera;
                        //if (ddlCarrera.SelectedValue == "000000")
                        //{
                        //    ddlCarrera_SelectedIndexChanged(null, null);
                        //    txtCarrera.Text = ObjAlumno.DescCarrera;
                        //}
                        ddlCiclo_D.SelectedValue = ObjAlumno.CicloEscolar;
                        txtSemestre.Text = ObjAlumno.Semestre;
                        txtGrupo.Text = ObjAlumno.Grupo;

                        txtPorcentaje.Text = ObjAlumno.PorcentajeDescuento;
                        txtFechaInicial.Text = ObjAlumno.FechaInicial;
                        txtFechaFinal.Text = ObjAlumno.FechaFinal;
                        txtOficio.Text = ObjAlumno.OficioSolicito;
                        txtFechaO.Text = ObjAlumno.OficioFecha;
                        txtAutorizado.Text = ObjAlumno.OficioFirma;
                        txtSolicitado.Text = ObjAlumno.OficioQuienSolicita;
                        txtObservaciones.Text = ObjAlumno.Observaciones;
                        lblUsuSolicitado.Text = ObjAlumno.SolicitoNombre;
                        lblFechaSolicitado.Text = ObjAlumno.SolicitoFecha;
                        lblUsuAutorizado.Text = ObjAlumno.AutorizoNombre;
                        lblFechaAutorizado.Text = ObjAlumno.AutorizoFecha;
                        lblUsuGenerar.Text = ObjAlumno.GeneroNombre;
                        lblFechaGenerar.Text = ObjAlumno.GeneroFecha;
                        SesionUsu.Id_Oficio = ObjAlumno.oficio.IdOficio;
                        StatusMatricula = ObjAlumno.StatusMatricula;
                        if (Convert.ToString(ObjAlumno.IdEmpleado) != "0")
                        {
                            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Empleado", ref ddlEmpleado, "p_id_empleado", "p_id_familiar", Convert.ToString(ObjAlumno.IdEmpleado), Convert.ToString(ObjAlumno.IdFamiliar), ref ListFamiliar);
                            BuscaEmpleado();
                            BuscaHijo("N");
                        }
                        else
                        {
                            ddlEmpleado.Items.Clear();
                            ddlEmpleado.Items.Insert(0, new ListItem("AGREGAR-->", "0"));
                            grvEmpleados.DataSource = null;
                            grvEmpleados.DataBind();
                            ddlHijo.Items.Clear();
                            ddlParentesco.Items.Clear();
                        }
                        //TabContainer1.ActiveTabIndex = 0;
                        //MultiView1.ActiveViewIndex = 1;
                        if (StatusMatricula == "A")
                        {
                            txtNombre.Enabled = false;
                            txtPaterno.Enabled = false;
                            txtMaterno.Enabled = false;
                            txtSemestre.Enabled = true;
                            txtGrupo.Enabled = true;
                            txtMatricula.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;  //(usuAdmin.Length != 0) ? true : false;
                            //ddlNivel.Enabled = false;
                            ddlStatus.Visible = false;
                            lblEstatusA.Text = "Autorizado";
                            //ddlCiclo_D.Enabled = false;
                            ddlCiclo_D.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
                            ddlEvento.Enabled = false;
                            ddlSubTipo.Enabled = false;
                            ddlTipo.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
                            //grvConceptosCat.Enabled = false;
                            grvConceptosCat.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;
                            txtPorcentaje.Enabled = false;
                            txtFechaInicial.Enabled = (SesionUsu.Usu_Central == "S") ? true : false;//(usuAdmin.Length != 0) ? true : false;
                            txtFechaFinal.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //(usuAdmin.Length != 0) ? true : false;
                            txtOficio.Enabled = true;
                            txtFechaO.Enabled = true;
                            txtAutorizado.Enabled = true;
                            txtSolicitado.Enabled = true;
                            txtObservaciones.Enabled = true;
                        }
                        else if (StatusMatricula == "C")
                        {
                            ddlStatus.Visible = false;
                            lblEstatusA.Text = "Cancelado";
                        }
                        else
                        {
                            //ddlStatus.SelectedValue = ObjAlumno.StatusMatricula;
                            txtNombre.Enabled = true;
                            txtPaterno.Enabled = true;
                            txtMaterno.Enabled = true;
                            txtSemestre.Enabled = true;
                            txtGrupo.Enabled = true;
                            txtMatricula.Enabled = true;
                            ddlNivel.Enabled = true;
                            ddlStatus.Visible = true;
                            lblEstatusA.Text = string.Empty;
                            ddlCiclo_D.Enabled = true;
                            ddlEvento.Enabled = true;
                            ddlSubTipo.Enabled = true;
                            ddlTipo.Enabled = true;
                            grvConceptosCat.Enabled = true;
                            txtPorcentaje.Enabled = true;
                            txtFechaInicial.Enabled = true;
                            txtFechaFinal.Enabled = true;
                            txtOficio.Enabled = true;
                            txtFechaO.Enabled = true;
                            txtAutorizado.Enabled = true;
                            txtSolicitado.Enabled = true;
                            txtObservaciones.Enabled = true;
                        }


                        //--LIMPIA GRIDS--//
                        Session["Oficios"] = null;
                        Session["Conceptos"] = null;
                        grvOficios.DataSource = null;
                        grvOficios.DataBind();
                        grvConceptosCat.DataSource = null;
                        grvConceptosCat.DataBind();
                        grvConceptos.DataSource = null;
                        grvConceptos.DataBind();
                        //--FIN LIMPIA GRIDS--//


                        ddlSubTipo.SelectedValue = ObjAlumno.SubTipoDescuento;
                        ddlSubTipo_SelectedIndexChanged(null, null);
                        ddlTipo.SelectedValue = ObjAlumno.TipoDescuento;
                        ddlTipo_SelectedIndexChanged(null, null);
                        if (StatusMatricula == "A")
                            grvConceptosCat.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //false;

                        CNComun.LlenaCombo("pkg_pagos.Obt_Status_Descuentos", ref ddlStatus, "p_usuario", "p_tipo_descuento", "p_todos", SesionUsu.Usu_Nombre, ddlTipo.SelectedValue, "N", "INGRESOS");
                        if (ObjAlumno.StatusMatricula != "A")
                            ddlStatus.SelectedValue = ObjAlumno.StatusMatricula;

                        if (SesionUsu.Id_Oficio == 0)
                            ObtIdOficio();

                        //----CARGA GRID DE OFICIOS Y DE LOS CONCEPTOS AGREGADOS
                        ObjOficio.IdDescuento = Convert.ToInt32(grvAlumnos.SelectedRow.Cells[0].Text);
                        List<Oficio> ListOficio = new List<Oficio>();
                        CNOficio.OficioConsultaGrid(ref ObjOficio, ref ListOficio);
                        if (ListOficio.Count > 0)
                        {
                            Session["Oficios"] = ListOficio;
                            CargarGridOficios(ListOficio);
                            Copiar_a_OficiosTemp(ListOficio);
                        }

                        List<DetConcepto> ListDetConcepto = new List<DetConcepto>();
                        CNDetDesc.ConsultarDetDescuento(ObjConcepto, SesionUsu.Id_Persona, ref ListDetConcepto);
                        if (ListDetConcepto.Count > 0)
                        {
                            Session["Conceptos"] = ListDetConcepto;
                            CargarGridConceptos(ListDetConcepto);
                            if (StatusMatricula == "A")
                                grvConceptos.Enabled = (SesionUsu.Usu_Central == "S") ? true : false; //false;
                        }


                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Verificador + "');", true); //lblMsj.Text = Verificador;
                }
                catch (Exception ex)
                {
                    string Mensaje = ex.Message.Replace("\r", "");
                    Mensaje = Mensaje.Replace("\n", "");
                    Mensaje = Mensaje.Replace("'", "");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + Mensaje.Substring(0, 45) + "');", true); //lblMsj.Text = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
            }
        }

        protected void linkBttnBuscarEx_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        protected void linkBttnNewEx_Click(object sender, EventArgs e)
        {
            try
            {
                TabContainer1.ActiveTabIndex = 0;
                MultiView1.ActiveViewIndex = 1;
                SesionUsu.Editar = 0;
                Nuevo();
                ObtIdOficio();
                txtMatricula.Focus();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message + "');", true); //lblMsj.Text = ex.Message;
            }
        }






        //protected void ddlHijo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    modalEmpleado.Show();
        //    ddlParentesco.SelectedValue = ddlHijo.SelectedValue;
        //}
    }
}