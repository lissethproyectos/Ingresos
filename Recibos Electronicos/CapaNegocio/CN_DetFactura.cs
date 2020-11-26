using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_DetFactura
    {
        public void ObtDetFactura(DetFactura objDetFactura, ref List<DetFactura> lstFactDet)
        {
            try
            {
                CD_DetFactura CDDetFactura = new CD_DetFactura();
                CDDetFactura.ObtDetFactura(objDetFactura, ref lstFactDet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DetFacturaInsertar(ref DetFactura DetFactura, ref string Verificador)
        {
            try
            {
                CD_DetFactura CDDetFactura = new CD_DetFactura();
                CDDetFactura.DetFacturaInsertar(ref DetFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DetFacturaAgregar(int IdFact, List<DetFactura> listDetFact, ref string Verificador)
        {
            try
            {
                CD_DetFactura CDDetFactura = new CD_DetFactura();
                CDDetFactura.DetFacturaAgregar(IdFact, listDetFact, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DetFacturaBorrar(ref DetFactura DetFactura, ref string Verificador)
        {
            try
            {
                CD_DetFactura CDDetFactura = new CD_DetFactura();
                CDDetFactura.DetFacturaBorrar(ref DetFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DetFacturaEliminar(int IdFact, ref string Verificador)
        {
            try
            {
                CD_DetFactura CDDetFactura = new CD_DetFactura();
                CDDetFactura.DetFacturaEliminar(IdFact, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
