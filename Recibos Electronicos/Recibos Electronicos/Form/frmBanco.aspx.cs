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
    public partial class frmBanco : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        CN_Banco CNBanco = new CN_Banco();
        BancoBitacora ObjBanco = new BancoBitacora();
        List<BancoBitacora> ListArch = new List<BancoBitacora>();
        #endregion       

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> salida = new Dictionary<string, string>();
            string ruta = string.Empty;
            if (FileUpload1.HasFile)
            {
                HttpPostedFile archivo = FileUpload1.PostedFile;

                CN_Banco cnbanco = new CN_Banco();
                salida = cnbanco.CargarArchivoCaja(archivo);

                if (salida["exito"] == "1")
                {
                    Label1.CssClass = "mgg_aviso mgg_aviso_verde";
                    ruta = "../Reportes/VisualizadorCrystal.aspx?Tipo=REP049&enExcel=S";
                    string _open = "window.open('" + ruta + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else                
                    Label1.CssClass = "mgg_aviso mgg_aviso_rojo";
                

                Label1.Text = salida["mensaje"];
            }
            else
            {
                Label1.Text = "Por favor seleccione un archivo";
                Label1.CssClass = "mgg_aviso mgg_aviso_rojo";
            }
            //ObtenerBitacoraControl();
        }        
    }
}