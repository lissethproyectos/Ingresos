using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ConceptoPago
    {

        public void ConceptoConsultaGrid(ref ConceptoPago ObjConceptoPago, string Orden, bool Habilitado, string Buscar, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConceptoConsultaGrid(ref ObjConceptoPago, Orden, Habilitado, Buscar, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarConceptoPago(ref ConceptoPago ObjConceptoPago, string Orden, bool Habilitado, string Tipo, string Busca, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarConceptoPago(ref ObjConceptoPago, Orden, Habilitado, Tipo, Busca, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarConceptoPago(ref string Verificador, ref ConceptoPago objConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarConceptoPago(ref Verificador, ref objConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarConceptoPago(ref string Verificador, ConceptoPago ObjConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.InsertarConceptoPago(ref Verificador, ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ClonarConcepto(ConceptoPago objConcepto, string Usuario, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ClonarConcepto(objConcepto, Usuario, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizaConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ActualizaConceptoPago(ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.EliminarConceptoPago(ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConfigurarConceptoPago(ref ConceptoPago ConceptoPago, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConfigurarConceptoPago(ref ConceptoPago, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ValidarConcepto(ref ConceptoPago ConceptoPago, ref string Verificador, ref string Mensaje)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ValidarConcepto(ref ConceptoPago, ref Verificador, ref Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarVigenciasSIAE(ConceptoPago ObjVigencias, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarVigenciasSIAE(ObjVigencias, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarExcepcionesVigenciasSIAE(ConceptoPago ObjVigencias, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarExcpcionesVigenciasSIAE(ObjVigencias, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarVigenciasSIAE(ConceptoPago ObjVigencias, string TipoCarrera, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ActualizarVigenciasSIAE(ObjVigencias, TipoCarrera, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarExcepcionesVigenciasSIAE(ConceptoPago ObjVigencias, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.InsertarExcepcionesVigenciasSIAE(ObjVigencias, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarCuotasSIAE(DetConcepto objCuotas, string Tipo, string SubTipo, ref List<DetConcepto> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarCuotasSIAE(objCuotas, Tipo, SubTipo, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.InsertarCuotasSIAE(ref Verificador, objCuotas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarCuotasSIAE(DetConcepto objCuotas, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ActualizarCuotasSIAE(objCuotas, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarCuotasLenguasSIAE(ref string Verificador, string Tipo, DetConcepto objCuotas)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.InsertarCuotasLenguasSIAE(ref Verificador, Tipo, objCuotas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarCuotasLenguasSIAE(ref string Verificador, string Tipo, DetConcepto objCuotas)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ActualizarCuotasLenguasSIAE(ref Verificador, Tipo, objCuotas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObtenerCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ObtenerCuotasSIAE(ref Verificador, objCuotas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.EliminarCuotasSIAE(ref Verificador, objCuotas);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
