using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Facturacion
    {
        public void FacturaConsultaDatosFiscales(ref Facturacion ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Facturacion DatosFactura = new CD_Facturacion();
                DatosFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEfectConsultaDatosFiscales(ref Facturacion ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Facturacion DatosFactura = new CD_Facturacion();
                DatosFactura.FacturaEfectConsultaDatosFiscales(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaActDatosCaja(Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Facturacion DatosFactura = new CD_Facturacion();
                DatosFactura.FacturaActDatosCaja(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarDatosEfect2(Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Facturacion DatosFactura = new CD_Facturacion();
                DatosFactura.FacturaEditarDatosEfect2(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaAgregarDatosCaja2(ref Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Facturacion DatosFactura = new CD_Facturacion();
                DatosFactura.FacturaAgregarDatosCaja2(ref ObjFactura, UsuarioNombre, ref Verificador);
                //DatosFactura.FacturaAgregarDatosCaja(ref ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDetInsertar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDDetFacturaEfectivo = new CD_Facturacion();
                CDDetFacturaEfectivo.FacturaDetInsertar(ListDetConc, idFactEfec, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDetEditar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDDetFacturaEfectivo = new CD_Facturacion();
                CDDetFacturaEfectivo.FacturaDetEliminar(idFactEfec, ref Verificador);
                CDDetFacturaEfectivo.FacturaDetInsertar(ListDetConc, idFactEfec, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDetConsultar(ref List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaDetConsultar(ref ListDetConc, idFactEfec);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FacturaEfectStatusConsultar(Facturacion objFacturacion, ref List<Facturacion> ListDetConc)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaEfectStatusConsultar(objFacturacion,ref ListDetConc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaSolConsultaGrid(Usuario ObjUsuario, ref Facturacion objFacturacion, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string Status, string Confirmados, string Tipo, ref List<Facturacion> List)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaSolConsultaGrid(ObjUsuario, ref objFacturacion, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados, Tipo, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaSolBorrar(Facturacion ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaSolBorrar(ObjFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDoctoAgregar(string Usuario, ref List<CajaFactura> List, int IdFactura, string RutaServ, string Tipo, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaDoctoAgregar(Usuario, ref List, IdFactura, RutaServ, Tipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDoctoBorrar(Facturacion ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaDoctoBorrar(ObjFactura, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaHistSolConsultaGrid(Facturacion objFacturacion, ref List<Facturacion> List)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaHistSolConsultaGrid(objFacturacion, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDoctosConsultaGrid(Facturacion ObjFactura, ref List<Facturacion> List)
        {
            try
            {
                CD_Facturacion CDFacturacion = new CD_Facturacion();
                CDFacturacion.FacturaDoctosConsultaGrid(ObjFactura, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
