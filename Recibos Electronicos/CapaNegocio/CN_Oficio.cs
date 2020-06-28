using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Oficio
    {
        public void OficioInsertar(List<Oficio> ListOficio, Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_Oficio CDOficio = new CD_Oficio();
                CDOficio.OficioInsertar(ListOficio, ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void OficioEditar(List<Oficio> ListOficio, Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_Oficio CDOficio = new CD_Oficio();
                CDOficio.OficioEditar(ListOficio, ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void OficioEliminar(Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_Oficio CDOficio = new CD_Oficio();
                CDOficio.OficioEliminar(ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void OficioConsultaGrid(ref Oficio ObjOficio, ref List<Oficio> List)
        {
            try
            {
                CD_Oficio CDOficio = new CD_Oficio();
                CDOficio.OficioConsultaGrid(ref ObjOficio, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarIdOficio(ref Oficio Oficio, ref string Verificador)
        {
            try
            {
                CD_Oficio CDOficio = new CD_Oficio();
                CDOficio.ConsultarIdOficio(ref Oficio, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
