using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        public void ConsultarEmpleado(ref Persona ObjEmpleado, ref List<Persona> List)
        {
            try
            {
                CD_Empleado CDEmpleado = new CD_Empleado();
                CDEmpleado.ConsultarEmpleado(ref ObjEmpleado, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarHijos(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            try
            {
                CD_Empleado CDEmpleado = new CD_Empleado();
                CDEmpleado.ConsultarHijos(ref ObjAlumno, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
