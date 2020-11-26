using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recibos_Electronicos
{
    public partial class frmInicio : System.Web.UI.Page
    {
        #region <Variables>
        //Int32[] Celdas = { 0, 7, 10 };
        //private string[] UsuariosSuper = {"JFREDY", "NESTOR", "GAVA", "ADOMINGUEZ","LUISH","LISSETH","OMAR","VELASCO","MARCOSA", "VICENTE", "NIVETTE", "JMOLINA", "FRANCISCO", "OSMANDI", "GEORGINA", "YARINA", "NORMAV", "BEATRIZ" };
        Factura ObjFactura = new Factura();
        Alumno ObjAlumno = new Alumno();
        Comun ObjComun = new Comun();
        Evento ObjEvento = new Evento();
        CN_Factura CNFactura = new CN_Factura();
        CN_Comun CNComun = new CN_Comun();
        Usuario Usur = new Usuario();
        Sesion SesionUsu = new Sesion();
        CN_Usuario CNUsuario = new CN_Usuario();
        CN_Alumno CNAlumno = new CN_Alumno();
        CN_Evento CNEvento = new CN_Evento();
        CN_CajaFactura CNCjaFactura = new CN_CajaFactura();
        string Verificador = "";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            //if (!IsPostBack)
            //    inicializar();
        }
    }
}