using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_DetConcepto
    {
        public void ConsultarDetConcepto(ref DetConcepto ObjDetConcepto, ref List<DetConcepto> List)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.ConsultarDetConcepto(ref ObjDetConcepto, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarCatConceptoDescuento(string TipoAlumno, DetConcepto ObjDetConcepto, string TipoDescuento, ref List<DetConcepto> List)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.ConsultarCatConceptoDescuento(TipoAlumno, ObjDetConcepto, TipoDescuento, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ValidarMateria(ref string Verificador, ref DetConcepto ObjConcepto)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.ValidarMateria( ref ObjConcepto,ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarDetConcepto(ref string Verificador, ref DetConcepto ObjConcepto)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.InsertarDetConcepto( ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarDetDescuento(List<DetConcepto> ListDetConc, Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.InsertarDetDescuento(ListDetConc, ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarDetDescuento(List<DetConcepto> ListDetConc, Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.EliminarDetDescuento(ObjAlumno, ref Verificador);
                CDDetConcepto.InsertarDetDescuento(ListDetConc, ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarDetDescuento(DetConcepto ObjDetConcepto, int IdDescuento, ref List<DetConcepto> List)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.ConsultarDetDescuento(ObjDetConcepto, IdDescuento, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarDetConcepto(ref string Verificador, ref DetConcepto ObjConcepto)
        {
            try
            {
                CD_DetConcepto CDDetConcepto = new CD_DetConcepto();
                CDDetConcepto.EliminarDetConcepto(ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
