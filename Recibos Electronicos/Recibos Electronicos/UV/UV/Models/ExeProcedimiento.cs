using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UV.Models
{
    public class ExeProcedimiento
    {
        #region Variable
        private OracleConnection cn;
        private OracleTransaction trans;
        OracleCommand cmd = default(OracleCommand);

        Conexion objConexion = new Conexion();

        #endregion
        public ExeProcedimiento()
        {
            Conexion objConexion = new Conexion();
            cn = objConexion.getConexion();
        }

        public OracleCommand GenerarOracleCommand(string SP, ref string Verificador, ref OracleDataReader dr, string[] ParametrosIn, object[] Valores, string[] ParametrosOut)
        {

            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string Tipo = "";
            for (int i = 0; i <= ParametrosIn.Length - 1; i++)
            {
                Tipo = Valores[i].GetType().Name;
                if (Tipo == "Double")
                {
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = 0;
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Double).Value = Valores[i];
                }
                else if (Tipo == "Int32")
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = 0;
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Int32).Value = Valores[i];
                else
                {
                    if (Valores[i] == null)
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = "";
                    else
                        cmd.Parameters.Add(ParametrosIn[i], OracleDbType.Varchar2).Value = Valores[i];
                }
            }
            for (int i = 0; i <= ParametrosOut.Length - 1; i++)
            {
                if (ParametrosOut[i]== "P_FOTOGRAFIA")
                    cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Blob, 1024).Direction = ParameterDirection.Output;
                else
                    cmd.Parameters.Add(ParametrosOut[i], OracleDbType.Varchar2, 1024).Direction = ParameterDirection.Output;
            }
            try
            {

                if (trans != null) cmd.Transaction = trans;
                if (trans == null) cn.Open();
                cmd.ExecuteNonQuery();
                Verificador = cmd.Parameters["P_Bandera"].Value.ToString();
                return cmd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public OracleCommand GenerarOracleCommandCursor(string SP, ref OracleDataReader dr, string[] Parametros, object[] Valores)
        {
            //try
            //{
            cmd = new OracleCommand(SP, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (trans != null) cmd.Transaction = trans;
            if (trans == null) cn.Open();
            //OracleParameter par1 = new OracleParameter



            if (Parametros != null)
                for (int i = 0; i <= Parametros.Length - 1; i++)
                    cmd.Parameters.Add(Parametros[i], OracleDbType.Varchar2).Value = Valores[i];

            cmd.Parameters.Add("p_registros", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
            dr = cmd.ExecuteReader();
            return cmd;

        }
        public void LimpiarOracleCommand(ref OracleCommand cmd)
        {
            try
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

        }
    }
}