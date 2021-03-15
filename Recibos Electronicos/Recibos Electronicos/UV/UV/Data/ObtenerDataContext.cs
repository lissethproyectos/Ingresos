using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UV.Models;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;

namespace UV.Data
{
    public class ObtenerDataContext
    {

        /*PARA LA OBTENCIÓN DE LAS CREDENCIALES*/
        public static string secretkey = "S3cr2019#un4ch&121";
        public static List<EMPLEADO> ObtenerDatosEmpleado(string Correo, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<EMPLEADO> list = new List<EMPLEADO>();
            EMPLEADO objDatosEmpleado = new EMPLEADO();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "P_CORREO" };
                object[] Valores = { Correo };
                string[] ParametrosOut = { "P_NOMBRE", "P_CATEGORIA", "P_ADSCRIPCION", "P_TIPO_PERSONAL", "P_PLAZA", "P_FOTOGRAFIA", "P_ID_EMPLEADO", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("OBT_DATOS_EMPLEADO_UV2", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objDatosEmpleado.nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);


                objDatosEmpleado.categoria = Convert.ToString(cmd.Parameters["P_CATEGORIA"].Value);
                objDatosEmpleado.adscripcion = Convert.ToString(cmd.Parameters["P_ADSCRIPCION"].Value);
                objDatosEmpleado.tipo = Convert.ToString(cmd.Parameters["P_TIPO_PERSONAL"].Value);
                objDatosEmpleado.plaza = Convert.ToString(cmd.Parameters["P_PLAZA"].Value);
                objDatosEmpleado.idemp = Convert.ToString(cmd.Parameters["P_ID_EMPLEADO"].Value);
                ObtenerFoto(ref objDatosEmpleado);

                dr.Close();


                list.Add(objDatosEmpleado);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
            //return registroAgregado;
        }
        public static void ObtenerFoto(ref EMPLEADO objFotografia)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<EMPLEADO> list = new List<EMPLEADO>();
            EMPLEADO objDatosEmpleado = new EMPLEADO();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "p_id_empleado" };
                object[] Valores = { objFotografia.idemp };


                cmd = exeProc.GenerarOracleCommandCursor("PKG_EMPLEADOS.Obt_Fotografia", ref dr, Parametros, Valores);
                //OracleCommand cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    objFotografia.foto = (byte[])dr[0];
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ValidarToken(string token, ref string correo)
        {
            //string Verificador = string.Empty;
            try
            {
                string[] tk_array = token.Split('.');

                string texto = tk_array[0] + "." + tk_array[1];

                byte[] data = System.Convert.FromBase64String(tk_array[1]);
                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                dynamic dato = JsonConvert.DeserializeObject<Object>(base64Decoded);

                // VALIDAR USUARIO
                //string correo = dato.email;
                correo = dato.email;
                bool usuario_valido = true;

                // VALIDAR NAVEGADOR
                // Pendiente: Lo siguiente en PHP se obtiene de esta forma: @$_SERVER['HTTP_USER_AGENT'] se debe hacer para C#;
                //string agent = "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Mobile Safari/537.36";
                bool navegador = true; // (dato.aud == true);

                // VALIDAR ACTIVO
                int timeSeconds = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                bool activo = ((dato.exp - timeSeconds) > 0);

                // VALIDAR INTEGRIDAD DEL TOKEN
                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretkey));
                var hash_generado = hmac.ComputeHash(Encoding.UTF8.GetBytes(texto));
                bool hash_valido = (tk_array[2] == ByteToString(hash_generado));

                // VALIDAR TODO
                bool valido = (hash_valido && usuario_valido && activo && navegador) ? true : false;

                return valido;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        

        /*PARA LA OBTENCIÓN DE LA ENCUESTA DOCENTE*/
        public static string secretkey2 = "un4ch#1nnov4ndo$#";
        public static List<DOCENTE> ObtenerDatosDocente(string Correo, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<DOCENTE> list = new List<DOCENTE>();
            DOCENTE objDatosEmpleado = new DOCENTE();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "P_CORREO" };
                object[] Valores = { Correo };
                string[] ParametrosOut = { "P_NOMBRE", "P_CATEGORIA", "P_ADSCRIPCION", "P_TIPO_PERSONAL", "P_PLAZA", "P_FOTOGRAFIA", "P_ID_EMPLEADO", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("OBT_DATOS_EMPLEADO_UV2", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objDatosEmpleado.nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                //objDatosEmpleado.identificador = Convert.ToInt32(cmd.Parameters["P_ID"].Value);
                //objDatosEmpleado.idemp = Convert.ToString(cmd.Parameters["P_ID_EMPLEADO"].Value);
                string idemp = Convert.ToString(cmd.Parameters["P_ID_EMPLEADO"].Value);
                objDatosEmpleado.identificador = Convert.ToInt32(idemp);
                dr.Close();

                ObtenerFotoDocente(ref objDatosEmpleado, idemp);




                list.Add(objDatosEmpleado);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
            //return registroAgregado;
        }
        public static void ObtenerFotoDocente(ref DOCENTE objFotografia, string idemp)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<DOCENTE> list = new List<DOCENTE>();
            DOCENTE objDatosEmpleado = new DOCENTE();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "p_id_empleado" };
                object[] Valores = { idemp };


                cmd = exeProc.GenerarOracleCommandCursor("PKG_EMPLEADOS.Obt_Fotografia", ref dr, Parametros, Valores);
                //OracleCommand cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    objFotografia.foto = (byte[])dr[0];
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool ValidarTokenDocente(string token, ref string correo)
        {
            //string Verificador = string.Empty;
            try
            {
                string[] tk_array = token.Split('.');

                string texto = tk_array[0] + "." + tk_array[1];

                byte[] data = System.Convert.FromBase64String(tk_array[1]);
                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                dynamic dato = JsonConvert.DeserializeObject<Object>(base64Decoded);

                // VALIDAR USUARIO
                //string correo = dato.email;
                correo = dato.id;
                bool usuario_valido = true;

                // VALIDAR NAVEGADOR
                // Pendiente: Lo siguiente en PHP se obtiene de esta forma: @$_SERVER['HTTP_USER_AGENT'] se debe hacer para C#;
                //string agent = "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Mobile Safari/537.36";
                bool navegador = true; // (dato.aud == true);

                // VALIDAR ACTIVO
                int timeSeconds = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                bool activo = ((dato.exp - timeSeconds) > 0);

                // VALIDAR INTEGRIDAD DEL TOKEN
                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretkey2));
                var hash_generado = hmac.ComputeHash(Encoding.UTF8.GetBytes(texto));
                bool hash_valido = (tk_array[2] == ByteToString(hash_generado));

                // VALIDAR TODO
                bool valido = (hash_valido && usuario_valido && activo && navegador) ? true : false;

                return valido;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static string secretkey3 = "eyJOeXAiOiJKV1QiLCJhbGciOiJIUzl1NiJ9.ey";
        public static List<EMP_DOCENTE> ObtenerDatosDocenteBiblioteca(string Plaza, string TipoPersonal, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<EMP_DOCENTE> list = new List<EMP_DOCENTE>();
            EMP_DOCENTE objDatosEmpleado = new EMP_DOCENTE();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "P_PLAZA", "P_TIPO" };
                object[] Valores = { Plaza, TipoPersonal };
                string[] ParametrosOut = { "P_ROL", "P_NOMBRE", "AP_PATERNO", "AP_MATERNO", "P_GENERO", "P_CAMPUS", "P_ADSCRIPCION", "P_ID_EMPLEADO", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("OBT_DATOS_DOCENTE_ADMIVO", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objDatosEmpleado.rol = Convert.ToString(cmd.Parameters["P_ROL"].Value);
                objDatosEmpleado.nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                objDatosEmpleado.ap_paterno = Convert.ToString(cmd.Parameters["AP_PATERNO"].Value);
                objDatosEmpleado.ap_materno = Convert.ToString(cmd.Parameters["AP_MATERNO"].Value);
                objDatosEmpleado.genero = Convert.ToString(cmd.Parameters["P_GENERO"].Value);
                objDatosEmpleado.facultad = Convert.ToString(cmd.Parameters["P_ADSCRIPCION"].Value);
                string Identificador = Convert.ToString(cmd.Parameters["P_ID_EMPLEADO"].Value);
                objDatosEmpleado.identificador = Convert.ToInt32(Identificador);
                list.Add(objDatosEmpleado);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
            //return registroAgregado;
        }
        public static List<EMP_ADMIVO> ObtenerDatosAdmivoBiblioteca(string Plaza, string TipoPersonal, ref string Verificador)
        {
            OracleCommand cmd = null;
            ExeProcedimiento exeProc = new ExeProcedimiento();
            List<EMP_ADMIVO> list = new List<EMP_ADMIVO>();
            EMP_ADMIVO objDatosEmpleadoAdmivo = new EMP_ADMIVO();
            try
            {

                OracleDataReader dr = null;
                string[] Parametros = { "P_PLAZA", "P_TIPO" };
                object[] Valores = { Plaza, TipoPersonal };
                string[] ParametrosOut = { "P_ROL", "P_NOMBRE", "AP_PATERNO", "AP_MATERNO", "P_GENERO", "P_CAMPUS", "P_ADSCRIPCION", "P_ID_EMPLEADO", "P_BANDERA" };
                cmd = exeProc.GenerarOracleCommand("OBT_DATOS_DOCENTE_ADMIVO", ref Verificador, ref dr, Parametros, Valores, ParametrosOut);
                objDatosEmpleadoAdmivo.rol = Convert.ToString(cmd.Parameters["P_ROL"].Value);
                objDatosEmpleadoAdmivo.nombre = Convert.ToString(cmd.Parameters["P_NOMBRE"].Value);
                objDatosEmpleadoAdmivo.ap_paterno = Convert.ToString(cmd.Parameters["AP_PATERNO"].Value);
                objDatosEmpleadoAdmivo.ap_materno = Convert.ToString(cmd.Parameters["AP_MATERNO"].Value);
                objDatosEmpleadoAdmivo.genero = Convert.ToString(cmd.Parameters["P_GENERO"].Value);
                objDatosEmpleadoAdmivo.adscripcion = Convert.ToString(cmd.Parameters["P_ADSCRIPCION"].Value);
                string Identificador = Convert.ToString(cmd.Parameters["P_ID_EMPLEADO"].Value);
                objDatosEmpleadoAdmivo.identificador = Convert.ToInt32(Identificador);
                list.Add(objDatosEmpleadoAdmivo);

            }
            catch (Exception ex)
            {
                Verificador = ex.Message;
            }
            finally
            {
                exeProc.LimpiarOracleCommand(ref cmd);
            }
            return list;
            //return registroAgregado;
        }

        public static bool ValidarTokenDocenteAdmivo(string token, ref string plaza, ref string tipo_personal)
        {
            //string Verificador = string.Empty;
            try
            {
                string[] tk_array = token.Split('.');

                string texto = tk_array[0] + "." + tk_array[1];

                byte[] data = System.Convert.FromBase64String(tk_array[1]);
                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                dynamic dato = JsonConvert.DeserializeObject<Object>(base64Decoded);

                // VALIDAR USUARIO
                plaza = dato.plaza;
                tipo_personal = dato.tipo_personal;
                bool usuario_valido = true;

                // VALIDAR NAVEGADOR
                // Pendiente: Lo siguiente en PHP se obtiene de esta forma: @$_SERVER['HTTP_USER_AGENT'] se debe hacer para C#;
                //string agent = "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Mobile Safari/537.36";
                bool navegador = true; // (dato.aud == true);

                // VALIDAR ACTIVO
                int timeSeconds = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                bool activo = ((dato.exp - timeSeconds) > 0);

                // VALIDAR INTEGRIDAD DEL TOKEN
                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretkey3));
                var hash_generado = hmac.ComputeHash(Encoding.UTF8.GetBytes(texto));
                bool hash_valido = (tk_array[2] == ByteToString(hash_generado));

                // VALIDAR TODO
                bool valido = (hash_valido && usuario_valido && activo && navegador) ? true : false;

                return valido;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */

            return sbinary.ToLower();
        }
        static public string obtenerValor(string propiedad, string token)
        {
            string[] tk_array = token.Split('.');
            byte[] data = System.Convert.FromBase64String(tk_array[1]);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
            dynamic dato = JsonConvert.DeserializeObject<Object>(base64Decoded);
            return dato[propiedad];
        }
    }
}