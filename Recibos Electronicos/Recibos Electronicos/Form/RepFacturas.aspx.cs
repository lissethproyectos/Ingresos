using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
namespace Recibos_Electronicos.Form
{

    public partial class RepFacturas : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
            {
                //Response.Write("<script  language='javascript'>callprogress(80);</script>");                
                inicializar();
            }
        }
        protected void inicializar()
        {
            CNComun.LlenaCombo("pkg_felectronica.Obt_Combo_Ejercicio", ref DDLEjercicio);
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependencia, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
            CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependenciaFinal, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);

        }

        protected void DDLEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(ddlStatus.SelectedValue=="SOLICITADO")
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteFactura('" + DDLEjercicio.SelectedValue + "','" + ddlDependencia.SelectedValue + "','" + ddlStatus.SelectedValue + "');", true);            
            else
            {
                string fecha_inicial = "01/01/" + DDLEjercicio.SelectedValue;
                string fecha_final = "31/12/" + DDLEjercicio.SelectedValue;
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP068&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + fecha_inicial + "&FFinal=" + fecha_final + "&dependencia_fin=" + ddlDependenciaFinal.SelectedValue;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            }

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void linkBttnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus.SelectedValue == "SOLICITADO")
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteFactura('" + DDLEjercicio.SelectedValue + "','" + ddlDependencia.SelectedValue + "','" + ddlStatus.SelectedValue + "');", true);
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP017&Ejercicio=" + DDLEjercicio.SelectedValue + "&Dependencia=" + ddlDependencia.SelectedValue + "&Status=" + ddlStatus.SelectedValue;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    //window.open('../Reportes/VisualizadorCrystal.aspx?Tipo=REP017&Ejercicio=' + Ejercicio + '&Dependencia=' + Dependencia + '&Status=' + Status, 'miniContenedor', 'toolbar=no', 'location=no', 'menubar=no');
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

                }
                else
                {
                    string fecha_inicial = "01/01/" + DDLEjercicio.SelectedValue;
                    string fecha_final = "31/12/" + DDLEjercicio.SelectedValue;
                    //string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP068&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + fecha_inicial + "&FFinal=" + fecha_final;
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP068&dependencia=" + ddlDependencia.SelectedValue + "&FInicial=" + fecha_inicial + "&FFinal=" + fecha_final + "&dependencia_fin=" + ddlDependenciaFinal.SelectedValue;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal(0, 'Error en la recuperación de los datos.')", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + Verificador + "');", true);  //lblMsjFam.Text = Verificador;

            }
        }
    }  
}