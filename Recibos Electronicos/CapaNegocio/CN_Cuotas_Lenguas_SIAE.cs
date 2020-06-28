using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cuotas_Lenguas_SIAE
    {
        public void InsertarCuotasLenguas(ref string Verificador, CuotasLenguasSIAE objCuotas)
        {
            try
            {
                CD_Cuotas_Lenguas_SIAE CDCuotas = new CD_Cuotas_Lenguas_SIAE();
                CDCuotas.InsertarCuotasLenguas(ref Verificador, objCuotas);
                //CDCuotas.(ref Verificador, objCuotas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarCuotasLenguas(CuotasLenguasSIAE objCuotas, ref List<CuotasLenguasSIAE> List)
        {
            try
            {
                CD_Cuotas_Lenguas_SIAE CDConceptoPago = new CD_Cuotas_Lenguas_SIAE();
                CDConceptoPago.ConsultarCuotasLenguas(objCuotas, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
