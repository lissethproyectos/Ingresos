using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Alumno
    {
        public void ConsultarCarrerasPosgrado(Alumno objAlumno, string Buscar, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarCarrerasPosgrado(objAlumno, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AjustaDependencia(ref string Dependencia, string Nivel, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AjustaDependencia(ref Dependencia, Nivel, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnosUNACH(Alumno objAlumno, string Buscar, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnosUNACH(objAlumno, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void ConsultarAspirantesUNACH(Alumno objAlumno, string Buscar, string Origen, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAspirantesUNACH(objAlumno, Buscar, Origen, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarAlumno(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumno(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarDatosAlumno(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarDatosAlumno(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarCatClientes(ref Alumno objCliente, string Buscar, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarCatClientes(ref objCliente, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarCliente(ref Alumno ObjCliente, ref string Verificador)
        {
            try
            {
                CD_Alumno CDCliente = new CD_Alumno();
                CDCliente.ConsultarCliente(ref ObjCliente, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEmpleadoMatricula(ref Alumno ObjEmpleado, string Matricula, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarEmpleadoMatricula(ref ObjEmpleado, Matricula, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoSel(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnoSel(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoStatus(ref Alumno Alumno, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnoStatus(ref Alumno, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumno(ref Alumno ObjAlumno, string Busqueda, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumno(ref ObjAlumno, Busqueda, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void AlumnoEditar(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEditar(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void AlumnoInsertar(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoInsertar(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        public void AlumnoEliminar(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEliminar(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoDescuento(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnoDescuento(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarDescuentoAutomatico(ref Alumno objAlumno, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarDescuentoAutomatico(objAlumno, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoDescuento(ref Alumno ObjAlumno, string Clasificacion, string Referencia, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnoDescuento(ref ObjAlumno, Clasificacion, Referencia, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoEditarDescuentoOld(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEditarDescuentoOld(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoEditarDescuento(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEditarDescuento(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoInsertarDescuentoOld(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoInsertarDescuentoOld(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoInsertarDescuento(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoInsertarDescuento(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoEliminarDescuento(Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEliminarDescuento(Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarStatusDescuento(Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ActualizarStatusDescuento(Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarStatusDescuento(ref Alumno ObjAlumno, string Usuario, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarStatusDescuento(ref ObjAlumno, Usuario, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GeneraReciboDescuento(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.GeneraReciboDescuento(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void GeneraExencionesAutomaticas(Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.GeneraExencionesAutomaticas(Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /*ALUMNOS O CLIENTES AUTORIZADOS PARA EVENTOS*/
        public void ConsultarAutorizado(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAutorizado(ref ObjAlumno, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoAutorizadoSel(ref Alumno Alumno, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.ConsultarAlumnoAutorizadoSel(ref Alumno, ref Verificador);
        }
        public void ActualizarStatusAutorizado(ref Alumno Alumno, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.ActualizarStatusAutorizado(ref Alumno, ref Verificador);
        }
        public void AutorizadoInsertar(ref Alumno Alumno, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.AutorizadoInsertar(ref Alumno, ref Verificador);
        }
        public void AutorizadoInsertarMatricula(ref Alumno Alumno, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.AutorizadoInsertarMatricula(ref Alumno, ref Verificador);
        }
        public void AutorizadosInsertar(string Evento, List<Alumno> lstAutorizados, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.AutorizadosInsertar(Evento, lstAutorizados, ref Verificador);
        }
        public void AutorizadosEliminar(Evento ObjEvento, ref string Verificador)
        {
            CD_Alumno CDAlumno = new CD_Alumno();
            CDAlumno.AutorizadosEliminar(ObjEvento, ref Verificador);
        }

        public void ConsultarCorreoAlumno(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarCorreoAlumno(ref ObjAlumno, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
