using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_SIAE
    {
        public void SIAEConsultaGrid(Factura ObjFactura, ref List<Factura> List)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ConsultaGridInscripciones(ObjFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RefSIAEConsultaGrid(Factura ObjFactura, ref List<Factura> List)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ConsultaGridRefSIAE(ObjFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RefSyswebConsultaGrid(Factura ObjFactura, ref List<Factura> List)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ConsultaGridRefSysweb(ObjFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarStatusSIAE(Factura ObjFactura, string Usuario, ref string Verificador)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ActualizarStatusSIAE(ObjFactura, Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConfirmarPagoSIAE(Factura ObjFactura, string Usuario, ref string Verificador)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ConfirmarPagoSIAE(ObjFactura, Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarDatosSIAE(Factura ObjFactura, string ReferenciaPagada, string Usuario, ref string Verificador)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.ActualizarDatosSIAE(ObjFactura, ReferenciaPagada, Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void SIAEConsultaDatosPago(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_SIAE CDSIAE = new CD_SIAE();
                CDSIAE.SIAEConsultaDatosPago(ref ObjFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
