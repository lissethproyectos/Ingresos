using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_DetFacturaEfectivo
    {
        public void DetFacturaEfecInsertar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_DetFacturaEfectivo CDDetFacturaEfectivo = new CD_DetFacturaEfectivo();
                CDDetFacturaEfectivo.DetFacturaEfecInsertar(ListDetConc, idFactEfec, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DetFacturaEfecEditar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_DetFacturaEfectivo CDDetFacturaEfectivo = new CD_DetFacturaEfectivo();
                CDDetFacturaEfectivo.DetFacturaEfecEliminar(idFactEfec, ref Verificador);                
                CDDetFacturaEfectivo.DetFacturaEfecInsertar(ListDetConc, idFactEfec, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DetFacturaEfecConsultar(ref List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_DetFacturaEfectivo CDDetFacturaEfectivo = new CD_DetFacturaEfectivo();
                CDDetFacturaEfectivo.DetFacturaEfecConsultar(ref ListDetConc, idFactEfec, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
