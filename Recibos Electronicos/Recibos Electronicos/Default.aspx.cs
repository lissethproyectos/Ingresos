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

namespace Recibos_Electronicos
{
    public partial class _Default : System.Web.UI.Page
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Menus menu = new Menus();
        CN_Menus CNMenu = new CN_Menus();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                if (SesionUsu.Usu_TipoUsu == 3)
                {

                    if (Request.QueryString["mnu"] != null)
                    {
                        SesionUsu.Reporte = Request.QueryString["mnu"];

                        Menus objMenu = new Menus();
                        objMenu.Usuario = SesionUsu.Usu_Nombre;
                        objMenu.Grupo = 14;
                        objMenu.Padre = SesionUsu.Reporte; // "ADMIN";

                        List<Menus> List = new List<Menus>();
                        CNMenu.LlenarTree(ref treeMenu, objMenu, ref List);
                        
                        treeMenu.ExpandAll();
                    }

                    else
                    {
                        string siteMap = "ArchivosMenu/Web" + SesionUsu.Usu_Nombre + ".sitemap";
                        string fullPath = Path.Combine(Server.MapPath("~"), siteMap);
                        if (File.Exists(fullPath))
                        {
                            //SiteMapDataSource1.SiteMapProvider = fullPath;
                            XmlSiteMapProvider testXmlProvider = new XmlSiteMapProvider();
                            NameValueCollection providerAttributes = new NameValueCollection(1);
                            providerAttributes.Add("siteMapFile", siteMap);
                            testXmlProvider.Initialize("MyXmlSiteMapProvider", providerAttributes);
                            testXmlProvider.BuildSiteMap();
                            SiteMapDataSource smd = new SiteMapDataSource();
                            smd.ShowStartingNode = false;
                            smd.Provider = testXmlProvider;
                            //TreeView tv2 = new TreeView();
                            treeMenu.DataSource = smd;
                            treeMenu.DataBind(); //Important or all is blank
                            //PlaceHolder1.Controls.Add(treeMenu);
                        }
                    }
                }
            }
        }
    }
}
