using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Familiar
    {
        public void FamiliarInsertar(Alumno objFamiliar, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_NOMBRE", "P_TIPO", "P_FECHA_NACIMIENTO", "P_SEXO", "P_USUARIO", "P_ID_EMPLEADO" };
                object[] Valores = { objFamiliar.Nombre, objFamiliar.TipoPersonaStr, objFamiliar.FechaNacimiento,
                                     Convert.ToString(objFamiliar.Genero), objFamiliar.UsuNombre, objFamiliar.IdPersona };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_FAMILIARES", ref Verificador, Parametros, Valores, ParametrosOut);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

    }
}
