using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CapaEntidad;
using CapaNegocio;
using System.Data;

namespace Recibos_Electronicos
{
    public partial class SiteAdmin : System.Web.UI.MasterPage
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Menus menu = new Menus();
        Comun comun = new Comun();
        ConceptoPago ObjVigencias = new ConceptoPago();
        CN_Menus CN_mnu = new CN_Menus();
        CN_Comun CN_comun = new CN_Comun();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        CN_Calendario CNCalendario = new CN_Calendario();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            //if (!IsPostBack)            
            Inicializar();

        }
        #region <Funciones y Sub>
        //private void CargarGrid()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        grvCalendarPagos.DataSource = dt;
        //        grvCalendarPagos.DataSource = GetList();
        //        grvCalendarPagos.DataBind();                
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsjE.Text = ex.Message;
        //    }
        //}
        private void CargarGrid()
        {

            try
            {
                DataTable dt = new DataTable();
                //grdVigencias.DataSource = dt;
                //grdVigencias.DataSource = GetListVigencias();
                //grdVigencias.DataBind();
                //if (grdVigencias.Rows.Count > 0)
                //    CNComun.HideColumns(grdVigencias, Celdas);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, '" + ex.Message.Substring(0, 20) + "');", true); //lblMsj.Text = ex.Message;
            }
        }

        private List<ConceptoPago> GetListVigencias()
        {
            try
            {
                List<ConceptoPago> List = new List<ConceptoPago>();
                ObjVigencias.Nivel = "L";
                CNConcepto.ConsultarVigenciasActSIAE(ObjVigencias, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Calendario> GetList()
        {
            try
            {
                List<Calendario> List = new List<Calendario>();
                Calendario objCalendario = new Calendario();
                objCalendario.NumMes = "07";
                CNCalendario.ConsultarCalendario(objCalendario, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Inicializar()
        {
            string siteMap = string.Empty;
            try
            {
                bttnCorreoUnach.Text = SesionUsu.Correo_UNACH;
                lblUsuario.Text = SesionUsu.Nombre_Completo; //"Usuario:  " + SesionUsu.Usu_Nombre;
                menu.NombreMenu = "MenuTop";
                menu.Usuario = SesionUsu.Usuario;
                menu.Grupo = 14;

                if (SesionUsu.Usu_TipoUsu == 3)
                {
                    siteMap = "ArchivosMenu/Web" + SesionUsu.Usuario + ".sitemap";
                    CargarGrid();
                    //calPagosUNACH.SelectedDate.Day = "05";
                    //for (int i = 0; i <= calPagosUNACH.SelectedDates.Count - 1; i++)
                    //{
                    //    calPagosUNACH.SelectedDate[i].bac
                    //}
                    //calPagosUNACH.SelectedDates=
                }

                else if (SesionUsu.Usu_TipoUsu == 1 || SesionUsu.Usu_TipoUsu == 2 || SesionUsu.Usu_TipoUsu == 4 || SesionUsu.Usu_TipoUsu == 6)
                    siteMap = "ArchivosMenuAlumno/WebAlumno.sitemap";

                else
                    siteMap = string.Empty;


                string fullPath = Path.Combine(Server.MapPath("~"), siteMap);
                if (!File.Exists(fullPath))
                    CN_mnu.GenerateXMLFile(menu, fullPath);

                XmlSiteMapProvider testXmlProvider = new XmlSiteMapProvider();
                NameValueCollection providerAttributes = new NameValueCollection(1);
                providerAttributes.Add("siteMapFile", siteMap);
                testXmlProvider.Initialize("MyXmlSiteMapProvider", providerAttributes);
                testXmlProvider.BuildSiteMap();
                SiteMapDataSource smd = new SiteMapDataSource();
                smd.ShowStartingNode = false;
                smd.Provider = testXmlProvider;
                SiteMapPath1.Provider = testXmlProvider;
                MenuTop.DataSource = smd;
                MenuTop.DataBind();

                foreach (TreeNode item in MenuTop.Nodes)
                {
                    string NombreMenu = item.Text.ToUpper();
                    switch (NombreMenu)
                    {
                        case "INGRESOS":
                            item.Text = "<i class='fa fa-home'></i> " + item.Text.ToUpper();
                            //MenuTop.Items.[0].Text = "<span class='nav-link fa fa-home'> " + item.Text.ToUpper() + "</span>";
                            break;
                        case "CATÁLOGOS":
                            item.Text = "<i class='fa fa-book'></i> " + item.Text.ToUpper();
                            break;
                        case "ADMINISTRACIÓN":
                            item.Text = "<i class='fa fa-cog'></i> " + item.Text.ToUpper();
                            break;
                        case "REPORTES":
                            item.Text = "<i class='fa fa-print'></i> " + item.Text.ToUpper();
                            break;
                        case "ESTADISTICAS":
                            item.Text = "<i class='fa fa-file-image-o'></i> " + item.Text.ToUpper();
                            break;
                        case "FACTURAS":
                            item.Text = "<i class='fa fa-file'></i> " + item.Text.ToUpper();
                            break;
                        case "AYUDA":
                            item.Text = "<i class='fa fa-users'></i> " + item.Text.ToUpper();
                            break;
                        case "PASSWORD":
                            item.Text = "<i class='fa fa-lock'></i> " + item.Text.ToUpper();
                            break;
                        case "SALIR":
                            item.Text = "<i class='fa fa-arrow-circle-left'></i> " + item.Text.ToUpper();
                            break;
                        default:
                            //Console.WriteLine("Default case");
                            break;

                    }


                }




                CN_comun.Consultar_Total_Visitas(ref comun);
                //lblContador_Visitas.Text = comun.Contador_Visitas;

                //CN_comun.LlenaCombo("Pkg_Contratos.Obt_Combo_Sistemas", ref ddlSistemas, "p_usuario", SesionUsu.Usu_Nombre);
            }
            catch (Exception ex)
            {

                //lblMsjE.Text = ex.Message;
            }
        }
        #endregion

        protected void MenuTop_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnSistemas_Click(object sender, EventArgs e)
        {
            //if (ddlSistemas.SelectedValue != "X")
            //    Response.Redirect(ddlSistemas.SelectedValue);
        }

        protected void bttnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Acceso.aspx", false);
        }
    }
}