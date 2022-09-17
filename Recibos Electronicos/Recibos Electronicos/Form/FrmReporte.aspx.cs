using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace Recibos_Electronicos.Form
{
    public partial class FrmReporte : System.Web.UI.Page
    {
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        string MsjError = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Usuario"];
            if (!IsPostBack)
                inicializar();
        }

       


        protected void inicializar()
        {
            txtFecha_Factura_Ini.Text = "01/01/" + System.DateTime.Now.Year.ToString();
            txtFecha_Factura_Fin.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            if (Request.QueryString["reporte"] == "REP033")
            {
                imgBttnExportar.Visible = true;
                imgBttnReporte.Visible = true;
                divEventos.Visible = false;
                divDepcias.Visible = true;
                divFechas.Visible = true;
            }
            else if (Request.QueryString["reporte"] == "REP030")
            {
                imgBttnExportar.Visible = true;
                imgBttnReporte.Visible = true;
                divEventos.Visible = false;
                divDepcias.Visible = true;
                divFechas.Visible = true;
            }
            else if (Request.QueryString["reporte"] == "REP029")
            {
                imgBttnExportar.Visible = true;
                imgBttnReporte.Visible = true;
                divEventos.Visible = false;
                divDepcias.Visible = true;
                divFechas.Visible = true;
            }

            else if (Request.QueryString["reporte"] == "REP048")
            {
                divDepcias.Visible = false;
                divEventos.Visible = false;
                divFechas.Visible = true;
                imgBttnExportar.Visible = true;
                imgBttnReporte.Visible = true;
            }

            else
            {
                divDepcias.Visible = true;
                divEventos.Visible = true;
                divFechas.Visible = false;
                imgBttnExportar.Visible = true;
                imgBttnReporte.Visible = true;
            }
                
                CargarCombos();            
        }
        protected void CargarCombos()
        {
            //lblMsj.Text = string.Empty;
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependenciaIni, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_UR", ref ddlDependenciaFin, "p_tipo_usuario", "p_usuario", SesionUsu.Usu_TipoUsu.ToString(), SesionUsu.Usu_Nombre);
                //if(ddlDependenciaIni.SelectedValue== "00000")
                //    ddlDependenciaIni.Items.RemoveAt(0);

                //if (ddlDependenciaFin.SelectedValue == "00000")
                //    ddlDependenciaFin.Items.RemoveAt(0);

                ddlDependenciaFin_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }
        }

       

        protected void ddlDependenciaFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Eventos_Rep", ref ddlEventos, "p_dependencia_ini", "p_dependencia_fin", "p_usuario", ddlDependenciaIni.SelectedValue, ddlDependenciaFin.SelectedValue, SesionUsu.Usu_Nombre, "INGRESOS");
            }
            catch (Exception ex)
            {
                MsjError = ex.Message;
                CNComun.VerificaTextoMensajeError(ref MsjError);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);
            }

        }

        protected void imgBttnReporte_Click(object sender, ImageClickEventArgs e)
        {

            
            if (Request.QueryString["reporte"] == "REP029")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP029&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP030")
            {                              
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP030&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP033")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP033&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP048")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP048&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text+ "&enExcel=N";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                if (ddlTipo.SelectedValue == "1")                {

                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP027&Evento=" + ddlEventos.SelectedValue + "&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&enExcel=N";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                {
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP028&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&usuario=" + SesionUsu.Usu_Nombre;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
            }
            

        }

        protected void DDLMesIni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgBttnExportar_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["reporte"] == "REP029")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP031&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP030")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP032&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP033")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP034&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text;
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (Request.QueryString["reporte"] == "REP048")
            {
                string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP048&FInicial=" + txtFecha_Factura_Ini.Text + "&FFinal=" + txtFecha_Factura_Fin.Text + "&enExcel=S";
                string _open = "window.open('" + ruta + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }

            else
            {
                if (ddlTipo.SelectedValue == "1")
                {

                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP027&Evento=" + ddlEventos.SelectedValue + "&Usuario=" + SesionUsu.Usu_Nombre + "&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&enExcel=S";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }

                else
                {
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP028&dependencia=" + ddlDependenciaIni.SelectedValue + "&dependencia_fin=" + ddlDependenciaFin.SelectedValue + "&usuario=" + SesionUsu.Usu_Nombre;
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
            }

        }
    }
}