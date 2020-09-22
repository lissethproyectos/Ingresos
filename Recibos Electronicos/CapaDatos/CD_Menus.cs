using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;
using System.Xml;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Menus
    {
        public void LlenarMenus(ref Menu Mnu, ref Menus DatosMenu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader dr = null;
                

                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        DatosMenu.UsuarioNombre  ,   
                                        DatosMenu.Grupo,  
                                   };
                 Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);

                 MenuItem m1 = new MenuItem("Inicio", "0", "", "index.aspx");
                 Mnu.Items.Add(m1);

                 if (dr.HasRows)
                 {

                     while (dr.Read())
                     {
                         MenuItem mnuMenuItem = new MenuItem();

                         if (dr["padre"].ToString() == string.Empty)
                         {
                             mnuMenuItem.Value = dr["id"].ToString();
                             mnuMenuItem.Text = dr["descripcion"].ToString();
                             mnuMenuItem.NavigateUrl = dr["clave"].ToString();
                             Mnu.Items.Add(mnuMenuItem);
                             AddMenuItem(mnuMenuItem, ref DatosMenu);
                         }
                     }
                      dr.Close();
                 }
                

                 m1 = new MenuItem("Ayuda", "0", "", "Acceso.aspx");
                 Mnu.Items.Add(m1);

                 MenuItem m2 = new MenuItem("Directorio", "0", "", "~/Ayuda/sysweb_Directorio.pdf", "_blanck");
                 m1.ChildItems.Add(m2);

                 MenuItem m3 = new MenuItem("Guía Rápida", "0", "", "~/Ayuda/sysweb_Guia_Rapida.pdf", "_blanck");
                 m1.ChildItems.Add(m3);

                 MenuItem m4 = new MenuItem("Proceso de Ingresos", "0", "", "~/Ayuda/sysweb_Proceso_de_ingresos.pdf", "_blanck");
                 m1.ChildItems.Add(m4);

                 MenuItem m5 = new MenuItem("Proceso de Exenciones", "0", "", "~/Ayuda/sysweb_Procedimiento_de_Exencion.pdf", "_blanck");
                 m1.ChildItems.Add(m5);

                 MenuItem m6 = new MenuItem("Pagos Fuera del País", "0", "", "~/Ayuda/sysweb_Transferencias_Internacionales.pdf", "_blanck");
                 m1.ChildItems.Add(m6);

                 m1 = new MenuItem("Salir", "0", "", "Acceso.aspx");
                 Mnu.Items.Add(m1);
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        protected void AddMenuItem(MenuItem mnuItem, ref Menus mnu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader reader = null;


                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        mnu.UsuarioNombre,   
                                        mnu.Grupo,  
                                   };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref reader, Parametros, Valores);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItem mnuNewMenuItem = new MenuItem();
                        if (reader["id_padre"].ToString().Equals(mnuItem.Value))
                        {
                            mnuNewMenuItem.Value = reader["id"].ToString();
                            mnuNewMenuItem.Text = reader["descripcion"].ToString();
                            mnuNewMenuItem.NavigateUrl = reader["clave"].ToString();
                            mnuItem.ChildItems.Add(mnuNewMenuItem);
                            AddMenuItem(mnuNewMenuItem, ref mnu);
                        }
                    }
                    reader.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void GenerateXMLFile(Menus mnu, string fullPath)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            //Create XML
            Encoding enc = Encoding.UTF8;
            XmlTextWriter objXMLTW = new XmlTextWriter(fullPath, enc);
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_usuario", "p_grupo" };
                object[] Valores = { mnu.Usuario, mnu.Grupo };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref dr, Parametros, Valores);
                if (dr.HasRows)
                {

                    objXMLTW.WriteStartDocument();//xml document open
                    //'Top level (Parent element)
                    //root node open
                    objXMLTW.WriteStartElement("siteMap");
                    //first Node of the Menu open
                    objXMLTW.WriteStartElement("siteMapNode");
                    //Title attribute set
                    objXMLTW.WriteAttributeString("title", "INICIO");
                    objXMLTW.WriteAttributeString("description", "INICIO");//Description attribute set
                    objXMLTW.WriteAttributeString("url", "Inicio.aspx");//URL attribu



                    while (dr.Read())
                    {
                        if (dr["padre"].ToString() == string.Empty)
                        {
                            int MasterID = Convert.ToInt32(dr["id"].ToString());
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", dr["descripcion"].ToString().ToUpper());
                            objXMLTW.WriteAttributeString("description", dr["descripcion"].ToString().ToUpper());
                            if (dr["clave"].ToString().Contains(".aspx"))
                                objXMLTW.WriteAttributeString("url", dr["clave"].ToString());
                            else
                                objXMLTW.WriteAttributeString("url", "Default.aspx?mnu=" + dr["cve"].ToString());



                            //objXMLTW.WriteAttributeString("url", dr["clave"].ToString());
                            ChildMaster(objXMLTW, mnu, MasterID);
                            objXMLTW.WriteEndElement();
                        }
                    }
                    dr.Close();


                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "PASSWORD");
                    objXMLTW.WriteAttributeString("description", "PASSWORD");
                    objXMLTW.WriteAttributeString("url", "https://ldapauthmaster.unach.mx/pssform_resetaccount.php");
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteStartElement("siteMapNode");
                    objXMLTW.WriteAttributeString("title", "SALIR");
                    objXMLTW.WriteAttributeString("description", "SALIR");
                    objXMLTW.WriteAttributeString("url", "Acceso.aspx");
                    objXMLTW.WriteEndElement();

                    objXMLTW.WriteEndElement();
                    objXMLTW.WriteEndDocument();
                }

                //Close the siteMapNode        
                //objXMLTW.WriteEndElement();//Close the first siteMapNode
                //objXMLTW.WriteEndDocument();//xml document closed
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objXMLTW.Flush();
                objXMLTW.Close();
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        protected void ChildMaster(XmlTextWriter objXMLTW, Menus mnu, Int32 Id)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;            
            try
            {
                OracleDataReader reader = null;
                string[] Parametros = { "p_usuario", "p_grupo" };
                object[] Valores = { mnu.Usuario, mnu.Grupo };
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Sistemas", ref reader, Parametros, Valores);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ChildMasterID = Convert.ToInt32(reader["id"].ToString());
                        if (Convert.ToInt32(reader["id_padre"].ToString()) == Id)
                        {
                            objXMLTW.WriteStartElement("siteMapNode");
                            objXMLTW.WriteAttributeString("title", reader["descripcion"].ToString());
                            objXMLTW.WriteAttributeString("description", reader["descripcion"].ToString());
                            if (reader["clave"].ToString().Contains(".aspx"))
                                objXMLTW.WriteAttributeString("url", reader["clave"].ToString());
                            else
                                objXMLTW.WriteAttributeString("url", "Default.aspx?mnu=" + reader["cve"].ToString());

                            //objXMLTW.WriteAttributeString("url", "Default.aspx?cve=" + reader["id"].ToString());

                            //if (reader["clave"].ToString().Contains("Monitor"))
                            //    objXMLTW.WriteAttributeString("url", reader["clave"].ToString()+"?mnt=001");

                            //ddMenuItem(mnuNewMenuItem, ref mnu);
                            ChildMaster(objXMLTW, mnu, ChildMasterID);
                            objXMLTW.WriteEndElement();
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

        public void LlenarTree(ref TreeView Arbolito, Menus objMenu, ref List<Menus> List)
        {

            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = {
                                        "P_ID_SISTEMA",
                                        "P_USUARIO",
                                        "P_PADRE"
                                      };
                object[] Valores = {
                                        objMenu.Grupo,
                                        objMenu.Usuario,
                                        objMenu.Padre
                                   };
                string Usuario = objMenu.Usuario;
                int Grupo = objMenu.Grupo;
                Cmd = CDDatos.GenerarOracleCommandCursor("Pkg_Contratos.Obt_Tree_Menu", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        objMenu = new Menus();
                        objMenu.Id = Convert.ToInt32(dr["id"].ToString());
                        objMenu.Descripcion = Convert.ToString(dr["descripcion"].ToString());
                        objMenu.Navigate_Url = Convert.ToString(dr["clave"].ToString());
                        objMenu.Padre = Convert.ToString(dr["padre"].ToString());
                        objMenu.Clave = Convert.ToString(dr["clave"].ToString());
                        objMenu.Id_Padre = Convert.ToInt32(dr["id_padre"].ToString());

                        objMenu.Usuario = Usuario;
                        objMenu.Grupo = Grupo;
                        List.Add(objMenu);
                        //LlenarTree(ref Arbolito, objMenu, ref List);

                    }
                    dr.Close();
                }


                BindTree(List, null, Arbolito);
                //Arbolito.CollapseAll();
                dr.Close();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

        private void BindTree(IEnumerable<Menus> list, TreeNode parentNode, TreeView tree)
        {
            var nodes = list.Where(x => parentNode == null ? x.Padre == "0" : x.Id_Padre == int.Parse(parentNode.Value));
            foreach (var node in nodes)
            {
                //TreeNode newNode = new TreeNode(node.Descripcion_Proyecto, node.IdProy.ToString());
                TreeNode newNode = new TreeNode(node.Descripcion, node.Id.ToString(),"",node.Navigate_Url,"");


                if (node.Padre == "0")
                {
                    //if (node.Nivel > 6)
                    //parentNode.ImageUrl = "../Imagenes/add.png";
                    //newNode.Expand();
                    tree.Nodes.Add(newNode);
                    tree.CollapseAll();
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                   
                }
                BindTree(list, newNode, tree);
            }
        }


    }
}
