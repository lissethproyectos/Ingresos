using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Menus
    {

        public void LlenarMenus(ref Menu MenuT, ref Menus menu)
        {
            try
            {
                CD_Menus claseCapaDatos = new CD_Menus();
                claseCapaDatos.LlenarMenus(ref  MenuT, ref menu);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GenerateXMLFile(Menus mnu, string fullPath)
        {
            try
            {
                CD_Menus CDMnu = new CD_Menus();
                CDMnu.GenerateXMLFile(mnu, fullPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LlenarTree(ref TreeView Arbol, Menus objMenu, ref List<Menus> List)
        {
            try
            {
                CD_Menus claseCapaDatos = new CD_Menus();
                claseCapaDatos.LlenarTree(ref Arbol, objMenu, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
