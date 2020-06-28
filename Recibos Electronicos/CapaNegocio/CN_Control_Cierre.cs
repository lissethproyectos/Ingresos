using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Control_Cierre
    {
        //--Datos del SAF--//
        public void Control_CierreConsultaGrid(ref Control_Cierre ObjControl_Cierre, string Buscar, ref List<Control_Cierre> List)
        {
            try
            {

                CD_Control_Cierre CDControl_Cierre = new CD_Control_Cierre();
                CDControl_Cierre.Control_CierreConsultaGrid(ref ObjControl_Cierre, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Control_CierreEditar(ref Control_Cierre ObjControl_Cierre, ref string Verificador)
        {
            CD_Control_Cierre CDControl_Cierre = new CD_Control_Cierre();
            CDControl_Cierre.Control_CierreEditar(ref ObjControl_Cierre, ref Verificador);
        }

        public void Control_CierreGral(ref Control_Cierre ObjControl_Cierre, ref string Verificador)
        {
            CD_Control_Cierre CDControl_Cierre = new CD_Control_Cierre();
            CDControl_Cierre.Control_CierreGral(ref ObjControl_Cierre, ref Verificador);
        }
    }
}
