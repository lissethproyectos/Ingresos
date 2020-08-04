using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Calendario
    {
        public void ConsultarCalendario(Calendario ObjCalendario, ref List<Calendario> List)
        {
            try
            {
                CD_Calendario CDCalendario = new CD_Calendario();
                CDCalendario.CalendarioConsultaGrid(ObjCalendario, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
