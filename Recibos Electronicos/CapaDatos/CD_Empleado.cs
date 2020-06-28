using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Empleado
    {
        public void ConsultarEmpleado( ref Persona ObjEmpleado, ref List<Persona> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_nombre",
                                        //"p_apellidos",
                                        "p_id_empleado"
                };
                object[] Valores = { ObjEmpleado.Nombre, /*ObjEmpleado.APaterno,*/ ObjEmpleado.IdPersona };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Empleados", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjEmpleado = new Persona();
                    ObjEmpleado.Nombre = Convert.ToString(dr.GetValue(0));
                    ObjEmpleado.IdPersona = Convert.ToInt32(dr.GetValue(1));
                    ObjEmpleado.Dependencia = Convert.ToString(dr.GetValue(2));
                    ObjEmpleado.TipoPersonaStr = Convert.ToString(dr.GetValue(3));
                    ObjEmpleado.NoControl = Convert.ToString(dr.GetValue(4));
                    List.Add(ObjEmpleado);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public void ConsultarHijos(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_id_empleado" };
                object[] Valores = { ObjAlumno.IdPersona };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Hijos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.IdPersona = Convert.ToInt32(dr.GetValue(0));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(1));
                    //ObjAlumno.FechaNacimiento = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.Parentesco = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjAlumno);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
    }
}
