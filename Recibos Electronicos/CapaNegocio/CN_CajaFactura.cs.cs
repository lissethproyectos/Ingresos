using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_CajaFactura
    {
        public void FacturaClienteConsultaGrid(CajaFactura ObjCjaFactura, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaClienteConsultaGrid(ObjCjaFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaConsultaGrid(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, string Dependencia, string FechaInicial, string FechaFinal, string Referencia, string Status, string Confirmados, string Comprobante, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaConsultaGrid(ObjUsuario, ref ObjCjaFactura, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados, Comprobante, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaConsultaGrid2(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, string Dependencia, string FechaInicial, string FechaFinal, string Referencia, string Status, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaConsultaGrid2(ObjUsuario, ref ObjCjaFactura, Dependencia, FechaInicial, FechaFinal, Referencia, Status, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaConsultaGrid(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string Solicitados, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaConsultaGrid(ObjUsuario, ref ObjCjaFactura, Dependencia, FechaInicial, FechaFinal, Referencia, Solicitados, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FacturaDoctosConsultaGrid(Factura ObjFactura, ref List<Factura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaDoctosConsultaGrid(ObjFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaEfectivoConsultaGrid(Usuario ObjUsuario, ref CajaFactura ObjCjaFactura, string Dependencia, string FechaInicial, string FechaFinal, string Referencia, string Status, string Confirmados, string Tipo, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();

                DatosCajaFactura.FacturaCajaEfectivoConsultaGrid(ObjUsuario, ref ObjCjaFactura, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados, Tipo, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaEfectivoBorrar(CajaFactura ObjCjaFactura, ref string Verificador)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaEfectivoBorrar(ObjCjaFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaBorrar(Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaBorrar(ObjFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaAgregar(string Usuario, ref List<CajaFactura> List, Factura objFactura, string RutaServ, ref string Verificador)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaAgregar(Usuario, ref List, objFactura, RutaServ, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaCajaAgregar(string Usuario, ref List<CajaFactura> List, int IdFactura, string RutaServ, string Tipo, ref string Verificador)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.FacturaCajaAgregar(Usuario, ref List, IdFactura, RutaServ, Tipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarPdfXmlFactura(ref CajaFactura ObjCjaFactura, string Tipo, ref List<CajaFactura> List)
        {
            try
            {
                CD_CajaFactura DatosCajaFactura = new CD_CajaFactura();
                DatosCajaFactura.ConsultarPdfXmlFactura(ref ObjCjaFactura, Tipo, ref List);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
