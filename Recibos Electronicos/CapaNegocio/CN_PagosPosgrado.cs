using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_PagosPosgrado
    {
        public void ConsultarPagosPosgrado(PagosPosgrado objPago, ref List<PagosPosgrado> List)
        {
            try
            {
                CD_PagosPosgrado CDAlumno = new CD_PagosPosgrado();
                CDAlumno.ConsultarPagosPosgrado(objPago, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarPagosPosgrado(PagosPosgrado objPago, ref string Verificador)
        {
            try
            {

                CD_PagosPosgrado CDPago = new CD_PagosPosgrado();
                CDPago.EditarPagosPosgrado(objPago, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
