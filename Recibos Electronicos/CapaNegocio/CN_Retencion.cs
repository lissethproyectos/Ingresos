using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Retencion
    {
        public void ConsultarBeneficiarios(ref Retencion ObjRetenciones, ref List<Retencion> List, string Busqueda)
        {
            try
            {
                CD_Retencion CDRetencion = new CD_Retencion();
                CDRetencion.ConsultarBeneficiarios(ref ObjRetenciones, ref List, Busqueda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarConceptos(ref Retencion ObjRetenciones, ref List<Retencion> List)
        {
            try
            {
                CD_Retencion CDRetencion = new CD_Retencion();
                CDRetencion.ConsultarConceptos(ref ObjRetenciones, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
