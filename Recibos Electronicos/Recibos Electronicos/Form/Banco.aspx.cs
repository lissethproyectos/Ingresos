using CapaNegocio;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace Recibos_Electronicos
{
    public partial class Banco : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        CN_Banco CNBanco = new CN_Banco();
        BancoBitacora ObjBanco = new BancoBitacora();
        List<BancoBitacora> ListArch = new List<BancoBitacora>();
        string Verificador = string.Empty;
        #endregion
        private void BindBancoList(DropDownList ddlFechaPago)
        {
            try
            {
                CNComun.LlenaCombo("PKG_FELECTRONICA_2016.Obt_Combo_Fecha_Pago", ref ddlFechaPago);
                ddlFechaPago.Items.FindByValue(ViewState["Filter"].ToString()).Selected=true;
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);  //lblMsjFam.Text = Verificador;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //ViewState["Filter"] = "9";
                ObtenerBitacoraControl();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "gridBitacora", "Bitacora();", true);
            
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> salida = new Dictionary<string, string>();
            try
            {
                if (FileUpload1.HasFile)
                {
                    HttpPostedFile archivo = FileUpload1.PostedFile;

                    CN_Banco cnbanco = new CN_Banco();
                    salida = cnbanco.CargarArchivo(archivo);

                    if (salida["exito"] == "1")
                        Label1.CssClass = "mgg_aviso mgg_aviso_verde";

                    else
                        Label1.CssClass = "mgg_aviso mgg_aviso_rojo";

                    Label1.Text = salida["mensaje"];
                }
                else
                {
                    Label1.Text = "Por favor seleccione un archivo";
                    Label1.CssClass = "mgg_aviso mgg_aviso_rojo";
                }
                ObtenerBitacoraControl();
            }
            catch(Exception ex)
            {
                Verificador = ex.Message;
                CNComun.VerificaTextoMensajeError(ref Verificador);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + ex.Message + "');", true);  //lblMsjFam.Text = Verificador;
            }
        }

        protected void ObtenerBitacoraControl()
        {
            String fecha_i = "0";
            String fecha_f = "0";

            List<BancoBitacora> lbb = new List<BancoBitacora>();
            CN_Banco cn_banco = new CN_Banco();

            cn_banco.ObtenerBitacora(ref lbb, fecha_i, fecha_f, ddlEjercicio.SelectedValue, ddlMes.SelectedValue);
            //cn_banco.ObtenerBitacora(ref lbb, fecha_i, fecha_f, ddlEjercicio.SelectedValue, ddlMes.SelectedValue, ViewState["Filter"].ToString());


            GVBitacora.DataSource = lbb;
            GVBitacora.DataBind();

            //DropDownList DDLFechaPago = (DropDownList)GVBitacora.HeaderRow.FindControl("ddlFechaPago");
            //this.BindBancoList(DDLFechaPago);

        }

        protected void ddlFechaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlFechaPago = (DropDownList)sender;
            string Fecha= ddlFechaPago.SelectedValue;
            ViewState["Filter"] = ddlFechaPago.SelectedValue;
            ObtenerBitacoraControl();
        }

        protected void GVBitacora_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjBanco.Id = Convert.ToString(GVBitacora.SelectedRow.Cells[0].Text);
            CNBanco.ConsultarArchivo(ref ObjBanco);
            //string ruta = "../ArchivosBanco/" + ObjBanco.Archivo_nombre;
            //string _open = "window.open('" + ruta + "', '_newtab');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            //ClientScript.RegisterStartupScript(GetType(), "Mensaje", "LoadTXT();", true);
            ScriptManager.RegisterStartupScript(this, typeof(string), "SHOW_ALERT", "LoadTXT('"+ ObjBanco.Archivo_nombre + "');", true);
        }

        protected void linkArchivo_Click(object sender, EventArgs e)
        {
            LinkButton cbi = (LinkButton)(sender);
            GridViewRow row = (GridViewRow)cbi.NamingContainer;
            GVBitacora.SelectedIndex = row.RowIndex;

            ObjBanco.Id = Convert.ToString(GVBitacora.SelectedRow.Cells[0].Text);
            CNBanco.ConsultarArchivo(ref ObjBanco);
            cbi.OnClientClick = ObjBanco.Archivo_nombre;



        }

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerBitacoraControl();
            ScriptManager.RegisterStartupScript(this, GetType(), "gridBitacora", "Bitacora();", true);
        }
    }
}
