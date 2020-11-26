using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Factura
    {
        public void Obt_Status_Carga(ref DataTable _tabla)
        {
            try
            {
                CD_Factura CDFactura = new CD_Factura();
                CDFactura.Status_Carga(ref _tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Obt_Grid_Status_Bancos_Usu(Comun ObjComun, ref List<Comun> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.Obt_Grid_Status_Bancos_Usu(ObjComun, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Obt_Grid_Status_Bancos(Comun ObjComun, ref List<Comun> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.Obt_Grid_Status_Bancos(ObjComun, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaTempConsultaGrid(ref DataTable _tabla)
        {
            try
            {
                CD_Factura CDFactura = new CD_Factura();
                CDFactura.FacturaTempConsultaGrid(ref _tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ErroresConsultaGrid(string Usuario, ref List<Comun> List)
        {
            try
            {
                CD_Factura CDFactura = new CD_Factura();
                CDFactura.ErroresConsultaGrid(Usuario, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaGrid(Usuario ObjUsuario, ref Factura ObjFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaGrid(ObjUsuario, ref ObjFactura, Dependencia, FechaInicial, FechaFinal, Referencia, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEventosConsultaGrid(ref Factura ObjFactura, Usuario objUsuario, string Evento, string Busqueda, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEventosConsultaGrid(ref ObjFactura, objUsuario, Evento, Busqueda, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaProductosConsultaGrid(string Dependencia, string Pagado, string FechaInicial, string FechaFinal, string Buscar, int TipoUsuario, string CveCliente, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaProductosConsultaGrid(Dependencia, Pagado, FechaInicial, FechaFinal, Buscar, TipoUsuario, CveCliente, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaGridRetenciones(Usuario ObjUsuario, ref Factura ObjFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string MesPago, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaGridRetenciones(ObjUsuario, ref ObjFactura, Dependencia, FechaInicial, FechaFinal, Referencia, MesPago, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaDetalleConsultaGrid(ref DetFactura ObjDetFactura, ref List<DetFactura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaDetalleConsultaGrid(ref ObjDetFactura, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditar(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditar(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FacturaEliminar(Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEliminar(ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarDatos(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditarDatos(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturasConfirmadas(string id_facturas, string confirmadas, string Tipo, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturasConfirmadas(id_facturas, confirmadas, Tipo, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarDatosCaja(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditarDatosCaja(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarDatosEfect(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditarDatosEfect(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaAgregarDatosCaja(ref Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        //public void FacturaAgregarDatosCaja(ref Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaAgregarDatosCaja(ref ObjFactura, UsuarioNombre, ref Verificador);
                //DatosFactura.FacturaAgregarDatosCaja(ref ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsulta(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsulta(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaDatos(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaDatos(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaDatosFiscales(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaDatosFiscales(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEfectConsultaDatosFiscales(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEfectConsultaDatosFiscales(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaId(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaId(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultarCancelados(ref Factura ObjFactura, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultarCancelados(ref ObjFactura, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Obt_Mensaje(ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.Obt_Mensaje(ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarEstatus(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditarEstatus(ObjFactura, UsuarioNombre, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaEditarEstatusRevisado(string Observaciones, string Usuario, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaEditarEstatusRevisado(Observaciones, Usuario, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FacturaConsultaPago_Sauce(ref Factura ObjFactura, String Ciclo_Escolar, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaPago_Sauce(ref ObjFactura, Ciclo_Escolar, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FacturaConsultaGrid_Ref_Sauce(Factura ObjFactura, String Ciclo_Escolar, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaConsultaGrid_Ref_Sauce(ObjFactura, Ciclo_Escolar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void FichaRefConsultaGrid(Factura ObjFactura, string Busca, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FichaRefConsultaGrid(ObjFactura, Busca, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FacturaReporteExcel(Factura ObjFactura, string fecha_ini, string fecha_fin, string dependencia, string concepto, ref DataTable _tabla)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.FacturaReporteExcel(ObjFactura, fecha_ini, fecha_fin, dependencia, concepto, ref _tabla);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Generar_Recibo_OnLine(Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.Generar_Recibo_OnLine(ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ConsultarRefAspirantes(Factura ObjFactura, string Busqueda, ref List<Factura> List)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.ConsultarRefAspirantes(ObjFactura, Busqueda, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarRFC(ref Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.ConsultarRFC(ref ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Generar_Recibo_Apirante(Factura ObjFactura, ref string Verificador)
        {
            try
            {
                CD_Factura DatosFactura = new CD_Factura();
                DatosFactura.Generar_Recibo_Apirante(ObjFactura, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
